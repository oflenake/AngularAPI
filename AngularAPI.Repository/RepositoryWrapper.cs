using AngularAPI.Contracts;
using AngularAPI.Entities;

namespace AngularAPI.Repository
{
    /// <summary>
    /// The <see cref="RepositoryWrapper"/> class that is used by entity models and 
    /// their related entity models to access the backend repository base.
    /// </summary>
    public class RepositoryWrapper : IRepositoryWrapper
    {
        #region Fields

        private ILoggerManager _logger;
        private string _component;
        private string _process;
        private string _message;

        private RepositoryContext _repoContext;
        private IEmployeeRepository _employeeRepo;
        private IBankAccountRepository _bankaccountRepo;
        #endregion

        public IEmployeeRepository EmployeeRepository
        {
            get
            {
                _process = "EmployeeRepository";

                if (_employeeRepo == null)
                {
                    _employeeRepo = new EmployeeRepository(_logger, _repoContext);

                    _message = string.Format($"[{_component}] {_process} is 'null'. A new repository created " +
                                             $"and initialized at: '{_component}.{_process}'");
                    _logger.LogWarn($"{_message}.");
                }

                _message = string.Format($"[{_component}] {_process} wraped for database operations " +
                                         $"at: '{_component}.{_process}'");
                _logger.LogInfo($"{_message}.");

                return _employeeRepo;
            }
        }

        public IBankAccountRepository BankAccountRepository
        {
            get
            {
                _process = "BankAccountRepository";

                if (_bankaccountRepo == null)
                {
                    _bankaccountRepo = new BankAccountRepository(_logger, _repoContext);

                    _message = string.Format($"[{_component}] {_process} is 'null'. A new repository created " +
                                             $"and initialized at: '{_component}.{_process}'");
                    _logger.LogWarn($"{_message}.");
                }

                _message = string.Format($"[{_component}] {_process} wraped for database operations " +
                                         $"at: '{_component}.{_process}'");
                _logger.LogInfo($"{_message}.");

                return _bankaccountRepo;
            }
        }

        public RepositoryWrapper(ILoggerManager logger, RepositoryContext repositoryContext)
        {
            _logger = logger;
            _repoContext = repositoryContext;

            _component = "RepositoryWrapper";
            _process = "RepositoryWrapper";
            _message = string.Format($"Initializing component: '{_component}', using its constructor: '{_component}.{_process}'");

            _logger.LogInfo($"{_message}.");
        }
    }
}
