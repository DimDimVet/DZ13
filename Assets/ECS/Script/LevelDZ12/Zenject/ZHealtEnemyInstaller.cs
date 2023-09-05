using Zenject;

public class ZHealtEnemyInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        //Container.Bind<string>().FromInstance("Inject");//������� � ���������� ��� ������ � ��������� ��������
        //Container.Bind<TestZenject>().AsSingle().NonLazy();//������� ������ ����������, AsSingle() - �� ����, NonLazy() - ������ ����� �� ������

        //Container.Bind<IData>().To<TestZenject>().AsSingle().NonLazy();

        Container.Bind<IHealtEnemy>().To<HealtEnemyExecutor>().AsSingle().NonLazy();//�������������� ����� ����� ����������� ExecutorZenject
    }
}