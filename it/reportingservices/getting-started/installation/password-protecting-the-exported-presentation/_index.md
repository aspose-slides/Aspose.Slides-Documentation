---
title: Protezione con password della presentazione esportata
type: docs
weight: 90
url: /it/reportingservices/password-protecting-the-exported-presentation/
---
{{% alert color="primary" %}} 

Proteggere una presentazione con password impedisce l'uso e l'accesso non autorizzati. La protezione con password è utile se si creano report contenenti dati sensibili o dettagli che solo alcune persone della propria organizzazione dovrebbero vedere.

Questo articolo mostra come aggiornare l'ambiente Reporting Services o Visual Studio per consentire di salvare le presentazioni con protezione tramite password.

{{% /alert %}} 
## **Aggiungere la protezione con password alle presentazioni esportate in un ambiente Reporting Services**
Per applicare le modifiche, è necessario modificare i file nella directory in cui è installato Microsoft SQL Server Reporting Services.
### **Passo 1. Individua la directory di installazione del Reporting Server.**
La directory principale di Microsoft SQL Server è solitamente C:\Program Files\Microsoft SQL Server.

{{% alert color="primary" %}} 

Per i sistemi a 64 bit, l'istanza x86 di SQL Server è installata in C:\Program Files (x86)\Microsoft SQL Server\

{{% /alert %}} 

Microsoft SQL Server 2005 e 2008: potrebbero esserci diverse istanze di Microsoft SQL Server configurate sul computer. Ognuna occupa una diversa sottodirectory MSSQL.x, ad esempio MSSQL.1, MSSQL.2 e così via. Individua la corretta directory C:\Program Files\Microsoft SQL Server\MSSQL.x\Reporting Services\ReportServer prima di procedere con i passaggi successivi.

Tutti i percorsi usati di seguito si riferiscono alla directory di installazione di Microsoft SQL Server Reporting Services come <Instance>.
### **Passo 2. Aggiungi il codice per impostare le password alle presentazioni esportate**
Sostituisci le estensioni di rendering esistenti di Aspose.Slides for Reporting Services nel file **rsreportserver.config**. Per farlo, apri il file C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rsreportserver.config.

Trova le opzioni di rendering elencate subito sotto e sostituiscile con il codice nel segmento successivo.
#### **Trova le opzioni di rendering di Aspose.Slides for Reporting Service**
**<Render>**

``` xml

   ...

  <!--Inizia qui.>



  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

<!--Fine qui.-->


</Render>



```
#### **Codice di sostituzione**
**<Render>**

``` xml

   ...

  <!--Inizia qui.>



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

  <!--Fine qui.-->


</Render>



```
### **Aggiungere la protezione con password alle presentazioni esportate in Visual Studio**
Per applicare le modifiche, è necessario modificare il file in cui è installato Microsoft Visual Studio Report Designer.
### **Passo 1. Apri la directory di Visual Studio.**
- Per integrare il Report Designer di Visual Studio 2005, apri la directory C:\Program Files\Microsoft Visual Studio 8\Common7\IDE\PrivateAssemblies.
- Per integrare il Report Designer di Visual Studio 2008, apri la directory C:\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies.
### **Passo 2. Aggiungi il codice per impostare la password alle presentazioni esportate.**
Sostituisci le estensioni di rendering esistenti di Aspose.Slides for Reporting Services nel file **rsreportserver.config**. Per farlo, apri il file C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\ RSReportDesigner.config (dove **<Version>** è “8” per Visual Studio 2005 o “9.0” per Visual Studio 2008) e aggiungi queste righe nell'elemento **<Render>**. Quindi sostituiscile con il codice nel segmento di codice successivo.
#### **Trova le opzioni di rendering di Aspose.Slides for Reporting Service**
**<Render>**

``` xml

   ...

  <!--Inizia qui.>



  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

<!--Fine qui.-->


</Render>



```
#### **Codice di sostituzione**
**<Render>**

``` xml

   ...

  <!--Inizia qui.>



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

  <!--Fine qui.-->


</Render>



```