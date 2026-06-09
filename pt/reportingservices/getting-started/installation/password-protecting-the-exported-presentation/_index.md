---
title: Protegendo a Apresentação Exportada com Senha
type: docs
weight: 90
url: /pt/reportingservices/password-protecting-the-exported-presentation/
---
{{% alert color="primary" %}} 

Proteger uma apresentação com senha impede uso e acesso não autorizados. A proteção por senha é útil se você estiver criando relatórios que contenham dados sensíveis ou detalhes que somente algumas pessoas da sua organização devem visualizar.

Este artigo mostra como atualizar seu ambiente Reporting Services ou Visual Studio para permitir que você salve apresentações com proteção por senha.

{{% /alert %}} 
## **Adicionando Proteção por Senha em Apresentações Exportadas em um Ambiente Reporting Services**
Para aplicar as alterações aqui, você precisa modificar arquivos no diretório onde o Microsoft SQL Server Reporting Services está instalado.
### **Etapa 1. Localize o diretório de instalação do Reporting Server.**
O diretório raiz do Microsoft SQL Server geralmente é C:\Program Files\Microsoft SQL Server.

{{% alert color="primary" %}} 

Para sistemas de 64 bits, a instância x86 do SQL Server é instalada em C:\Program Files (x86)\Microsoft SQL Server\

{{% /alert %}} 

Microsoft SQL Server 2005 e 2008: podem existir várias instâncias do Microsoft SQL Server configuradas na máquina. Cada uma ocupa um subdiretório MSSQL.x diferente, por exemplo MSSQL.1, MSSQL.2 e assim por diante. Encontre o diretório correto C:\Program Files\Microsoft SQL Server\MSSQL.x\Reporting Services\ReportServer antes de prosseguir com as etapas seguintes.

Todos os caminhos usados abaixo referem‑se ao diretório de instalação do Microsoft SQL Server Reporting Services como <Instance>.
### **Etapa 2. Adicione o código para incluir senhas em apresentações exportadas**
Substitua as extensões de renderização Aspose.Slides for Reporting Services existentes no arquivo **rsreportserver.config**. Para isso, abra o arquivo C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rsreportserver.config. 

Encontre as opções de renderização listadas imediatamente abaixo e substitua‑as pelo código no segmento que segue.
#### **Encontrar Opções de Renderização Aspose.Slides for Reporting Service**
**<Render>**

``` xml

   ...

  <!--Comece aqui.>



  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

<!--Termine aqui.-->


</Render>



```
#### **Código de Substituição**
**<Render>**

``` xml

   ...

  <!--Comece aqui.-->


  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >


  <Configuration>				 			


	<Password>111</Password>

  </Configuration>			


 </Extension>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >


  <Configuration>				 			


	<Password>111</Password>

  </Configuration>			


 </Extension>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >


  <Configuration>				 			


	<Password>111</Password>

  </Configuration>			


 </Extension>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >


  <Configuration>				 			


	<Password>111</Password>

  </Configuration>			


 </Extension>

  <!--Termine aqui.-->


</Render>


```
### **Adicionando Proteção por Senha para Apresentações Exportadas no Visual Studio**
Para aplicar as alterações aqui, você precisa modificar o arquivo onde o Microsoft Visual Studio Report Designer está instalado.
### **Etapa 1. Abra o diretório do Visual Studio.**
- Para integrar ao Visual Studio 2005 Report Designer, abra o diretório C:\Program Files\Microsoft Visual Studio 8\Common7\IDE\PrivateAssemblies.
- Para integrar ao Visual Studio 2008 Report Designer, abra o diretório C:\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies.
### **Etapa 2. Adicione o código para incluir senha em apresentações exportadas.**
Substitua as extensões de renderização Aspose.Slides for Reporting Services existentes no arquivo **rsreportserver.config**. Para isso, abra o arquivo C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\RSReportDesigner.config (onde **<Version>** é “8” para Visual Studio 2005 ou “9.0” para Visual Studio 2008) e adicione estas linhas no elemento **<Render>**. Em seguida, substitua‑as pelo código no próximo segmento.
#### **Encontrar Opções de Renderização Aspose.Slides for Reporting Service**
**<Render>**

``` xml

   ...

  <!--Comece aqui.-->


  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

<!--Termine aqui.-->


</Render>
```
#### **Código de Substituição**
**<Render>**

``` xml

   ...

  <!--Comece aqui.-->


  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >


  <Configuration>				 		


	<Password>111</Password>

  </Configuration>			


 </Extension>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >


  <Configuration>				 		


	<Password>111</Password>

  </Configuration>			


 </Extension>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >


  <Configuration>				 		


	<Password>111</Password>

  </Configuration>			


 </Extension>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >


  <Configuration>				 		


	<Password>111</Password>

  </Configuration>			


 </Extension>

  <!--Termine aqui.-->


</Render>
```