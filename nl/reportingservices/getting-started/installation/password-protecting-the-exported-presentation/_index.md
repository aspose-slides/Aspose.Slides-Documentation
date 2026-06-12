---
title: Wachtwoordbeveiliging van de geëxporteerde presentatie
type: docs
weight: 90
url: /nl/reportingservices/password-protecting-the-exported-presentation/
---
{{% alert color="primary" %}} 

Een presentatie met een wachtwoord beveiligen voorkomt ongeautoriseerd gebruik en toegang. Wachtwoordbeveiliging is handig als je rapporten maakt die gevoelige gegevens of details bevatten die alleen sommige personen in je organisatie mogen zien.

Dit artikel toont hoe je je Reporting Services- of Visual Studio‑omgeving kunt bijwerken zodat je presentaties kunt opslaan met wachtwoordbeveiliging.

{{% /alert %}} 
## **Wachtwoordbeveiliging toevoegen aan geëxporteerde presentaties in een Reporting Services‑omgeving**
Om de wijzigingen toe te passen, moet je bestanden wijzigen in de map waar Microsoft SQL Server Reporting Services is geïnstalleerd.
### **Stap 1. Zoek de installatiemap van de Reporting Server.**
De hoofdmap van Microsoft SQL Server is gewoonlijk C:\Program Files\Microsoft SQL Server.

{{% alert color="primary" %}} 

Voor een 64‑bit‑systeem bevindt de x86‑instantie van SQL Server zich in C:\Program Files (x86)\Microsoft SQL Server\

{{% /alert %}} 

Microsoft SQL Server 2005 en 2008: Er kunnen meerdere instanties van Microsoft SQL Server op de machine geconfigureerd zijn. Elke instantie heeft een eigen submap MSSQL.x, bijvoorbeeld MSSQL.1, MSSQL.2 enzovoort. Zoek de juiste map C:\Program Files\Microsoft SQL Server\MSSQL.x\Reporting Services\ReportServer voordat je doorgaat met de volgende stappen.

Alle hieronder gebruikte paden verwijzen naar de installatiemap van Microsoft SQL Server Reporting Services als <Instance>.
### **Stap 2. Voeg de code toe om wachtwoorden toe te voegen aan geëxporteerde presentaties**
Vervang de bestaande Aspose.Slides for Reporting Services‑renderingextensies in het **rsreportserver.config**‑bestand. Open hiervoor het bestand C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rsreportserver.config.

Zoek de hieronder direct weergegeven rendering‑opties en vervang ze door de code in het daaropvolgende segment.
#### **Zoek de Aspose.Slides for Reporting Service Rendering‑opties**
**<Render>**

``` xml

   ...

  <!--Begin hier.-->



  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

<!--Einde hier.-->


</Render>



```
#### **Vervangende code**
**<Render>**

``` xml

   ...

  <!--Begin hier.-->



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

  <!--Einde hier.-->


</Render>



```
### **Wachtwoordbeveiliging toevoegen aan geëxporteerde presentaties in Visual Studio**
Om de wijzigingen toe te passen, moet je het bestand wijzigen waar de Microsoft Visual Studio Report Designer is geïnstalleerd.
### **Stap 1. Open de Visual Studio‑map.**
- Om te integreren met Visual Studio 2005 Report Designer, open je de map C:\Program Files\Microsoft Visual Studio 8\Common7\IDE\PrivateAssemblies.
- Om te integreren met Visual Studio 2008 Report Designer, open je de map C:\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies.
### **Stap 2. Voeg de code toe om een wachtwoord toe te voegen aan geëxporteerde presentaties.**
Vervang de bestaande Aspose.Slides for Reporting Services‑renderingextensies in het **rsreportserver.config**‑bestand. Open hiervoor het bestand C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\ RSReportDesigner.config (waar **<Version>** “8” is voor Visual Studio 2005 of “9.0” voor Visual Studio 2008) en voeg deze regels toe in het **<Render>**‑element. Vervang ze daarna door de code in het volgende code‑segment.
#### **Zoek de Aspose.Slides for Reporting Service Rendering‑opties**
**<Render>**

``` xml

   ...

  <!--Begin hier.-->



  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

<!--Einde hier.-->


</Render>
```
#### **Vervangende code**
**<Render>**

``` xml

   ...

  <!--Begin hier.-->



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

  <!--Einde hier.-->


</Render>
```