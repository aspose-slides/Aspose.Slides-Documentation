---
title: Configurando o Reporting Services
type: docs
weight: 30
url: /pt/reportingservices/setting-up-reporting-services/
---
{{% alert color="primary" %}} 

Nosso primeiro ponto no RS Server é o Reporting Services Configuration Manager. 

{{% /alert %}} 
## **Service Account**
Certifique‑se de entender qual conta de serviço está sendo usada para o Reporting Services. Se encontrarmos problemas, eles podem estar relacionados à conta de serviço que você está usando. O padrão é Network Service. Sempre que faço a implantação de novas versões, sempre utilizo Contas de Domínio, porque é aí que provavelmente surgirão problemas. Para esta configuração no meu servidor, usei uma Conta de Domínio chamada **RSService**. 
## **Web Service URL**
Precisaremos configurar a Web Service URL. Este é o diretório virtual **ReportServer** (vdir) que hospeda os Web Services usados pelo Reporting Services e com o qual o SharePoint se comunicará. A menos que você queira personalizar as propriedades do vdir (por exemplo, SSL, portas, host headers etc…), basta clicar em Aplicar aqui e estará pronto. 

![todo:image_alt_text](setting-up-reporting-services_1.png)

![todo:image_alt_text](setting-up-reporting-services_2.png)


**Figure 3**: Configurando a Web Service URL 

Quando isso for concluído, você deverá ver a figura a seguir. 

![todo:image_alt_text](setting-up-reporting-services_3.png)

**Figure 4**: Configuração bem‑sucedida da Web Service URL 
## **Database**
Precisamos criar o Banco de Dados do Catálogo do Reporting Services. Ele pode ser colocado em qualquer mecanismo de banco de dados SQL 2008 ou SQL 2008 R2. SQL11 também funcionaria, mas ainda está em BETA. Essa ação criará dois bancos de dados, **ReportServer** e **ReportServerTempDB**, por padrão. 
O outro passo importante é garantir que você escolha SharePoint Integrated como tipo de banco de dados. Uma vez feita essa escolha, ela não pode ser alterada. Consulte as Figuras 5, 6 e 7 para referência. 

![todo:image_alt_text](setting-up-reporting-services_4.png)

**Figure 5**: Criando o Banco de Dados do Report Server 

![todo:image_alt_text](setting-up-reporting-services_5.png)

**Figure 6**: Configurando o Servidor de Banco de Dados e o Tipo de Autenticação 

![todo:image_alt_text](setting-up-reporting-services_6.png)

**Figure 7**: Configurando o Nome e o Modo do Banco de Dados 

Quanto às credenciais, é assim que o Report Server se comunicará com o SQL Server. Qualquer conta que você selecionar receberá determinados direitos dentro do banco de dados do Catálogo, bem como em alguns bancos de dados de sistema via RSExecRole. O MSDB é um desses bancos de dados para uso de Subscrições, pois utilizamos o SQL Agent. 

![todo:image_alt_text](setting-up-reporting-services_7.png)

**Figure 8**: Configurando as Credenciais do Banco de Dados do Report Server 

Depois de concluir, deverá ficar semelhante à figura a seguir. 

![todo:image_alt_text](setting-up-reporting-services_8.png)


**Figure 9**: Progresso para Concluir a Configuração do Banco de Dados do Report Server 
## **Report Manager URL**
Podemos pular o Report Manager URL, pois ele não é usado quando estamos no modo SharePoint Integrated. O SharePoint é nossa interface. O Report Manager não funciona. 
## **Encryption Keys**
Faça backup das suas Encryption Keys e garanta que você saiba onde elas foram armazenadas. Se você chegar a uma situação em que precise migrar ou restaurar o Banco de Dados, precisará delas. 

![todo:image_alt_text](setting-up-reporting-services_9.png)

Isso é tudo para o Reporting Services Configuration Manager. Se você abrir a URL na aba Web Service URL, deverá aparecer algo semelhante à figura a seguir. 

![todo:image_alt_text](setting-up-reporting-services_10.png)

**Figure 12**: Acesso ao Report Server após a instalação 

O que aconteceu? O SharePoint está instalado no meu WFE e eu concluí a configuração do Reporting Services. Neste exemplo, o Reporting Services e o SharePoint estão em máquinas diferentes. Se estivessem na mesma máquina, esse erro não ocorreria. Tecnicamente, precisamos instalar o SharePoint na caixa RS. Isso significa que o IIS também será ativado.