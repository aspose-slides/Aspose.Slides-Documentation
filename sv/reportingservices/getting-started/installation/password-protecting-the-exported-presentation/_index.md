---
title: Lösenordsskydd för den exporterade presentationen
type: docs
weight: 90
url: /sv/reportingservices/password-protecting-the-exported-presentation/
---
{{% alert color="primary" %}} 

Att skydda en presentation med lösenord förhindrar obehörig användning och åtkomst. Lösenordsskydd är användbart om du skapar rapporter som innehåller känslig data eller detaljer som bara vissa personer i din organisation ska se.

Den här artikeln visar hur du uppdaterar din Reporting Services- eller Visual Studio-miljö för att kunna spara presentationer med lösenordsskydd.

{{% /alert %}} 
## **Lägga till lösenordsskydd på exporterade presentationer i en Reporting Services-miljö**
För att tillämpa ändringarna här måste du ändra filer i den katalog där Microsoft SQL Server Reporting Services är installerat.
### **Steg 1. Hitta installationskatalogen för Reporting Server.**
Rotkatalogen för Microsoft SQL Server är vanligtvis C:\Program Files\Microsoft SQL Server.

{{% alert color="primary" %}} 

För 64‑bitssystem installeras x86‑instansen av SQL Server i C:\Program Files (x86)\Microsoft SQL Server\

{{% /alert %}} 

Microsoft SQL Server 2005 och 2008: Det kan finnas flera instanser av Microsoft SQL Server konfigurerade på maskinen. Varje instans använder en annan MSSQL.x‑undermapp, till exempel MSSQL.1, MSSQL.2 osv. Hitta rätt katalog C:\Program Files\Microsoft SQL Server\MSSQL.x\Reporting Services\ReportServer innan du fortsätter med följande steg.

Alla sökvägar som används nedan refererar till installationskatalogen för Microsoft SQL Server Reporting Services som <Instance>.
### **Steg 2. Lägg till koden för att lägga till lösenord till exporterade presentationer**
Ersätt de befintliga Aspose.Slides för Reporting Services-renderingstilläggen i filen **rsreportserver.config**. Gör så här: öppna filen C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rsreportserver.config.

Hitta renderingalternativen som listas omedelbart nedan och ersätt dem med koden i segmentet som följer.
#### **Hitta Aspose.Slides för Reporting Service renderingsalternativ**
**<Render>**

``` xml

   ...

  <!--Starta här.>



  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

<!--Avsluta här.-->


</Render>



```
#### **Ersättningskod**
**<Render>**

``` xml

   ...

  <!--Starta här.-->



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

  <!--Avsluta här.-->


</Render>



```
### **Lägga till lösenordsskydd för exporterade presentationer i Visual Studio**
För att tillämpa ändringarna här måste du ändra filen där Microsoft Visual Studio Report Designer är installerad.
### **Steg 1. Öppna Visual Studio-katalogen.**
- För att integrera med Visual Studio 2005 Report Designer, öppna katalogen C:\Program Files\Microsoft Visual Studio 8\Common7\IDE\PrivateAssemblies.
- För att integrera med Visual Studio 2008 Report Designer, öppna katalogen C:\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies.
### **Steg 2. Lägg till koden för att lägga till lösenord till exporterade presentationer.**
Ersätt de befintliga Aspose.Slides för Reporting Services-renderingstilläggen i filen **rsreportserver.config**. Gör så här: öppna filen C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\RSReportDesigner.config (där **<Version>** är “8” för Visual Studio 2005 eller “9.0” för Visual Studio 2008) och lägg till dessa rader i elementet **<Render>**. Ersätt sedan dem med koden i nästa kodsegment.
#### **Hitta Aspose.Slides för Reporting Service renderingsalternativ**
**<Render>**

``` xml

   ...

  <!--Starta här.-->



  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

<!--Avsluta här.-->


</Render>



```
#### **Ersättningskod**
**<Render>**

``` xml

   ...

  <!--Starta här.-->


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

  <!--Avsluta här.-->


</Render>



```