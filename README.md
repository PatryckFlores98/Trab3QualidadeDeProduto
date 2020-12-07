# Trab3QualidadeDeProduto

Funcionamento:

Para executar a feature, basta compilar, acessar a tab de testes, abrir o gerenciador de testes e rodar.(Necessário estar com o Chrome atualizado, versão 87).

Foram usados MSTest.TestAdapter(1.3.2),Newtonsoft.json(10.0.3),Selenium Support(3.1.41),Selenium.Chrome.WebDriver(87.0.0),Selenium(3.1.41), SpecFlow(2.4.1),SpecFlow.MsTest(2.4.1),SpecFlow.Tools.MsBuild.Generation(2.4.1),System.ValueTuple(4.4.0),NUnit(3.12),NUnit Adapter(3.15.1),MSTestFramework(1.3.2) e Gerkin(6.0.0) no gerenciador de pacotes NuGet.

O projeto tem a pasta de Features, onde está a feature desenvolvida em forma de BDD, além da pasta Steps, onde ficam os steps da feature, e a pasta pages, onde ficam as páginas de cada step. Também há uma classe util, onde estão os métodos do selenium e uma classe SetUp, para declaração de variáveis globais e a execucão do webdriver.
