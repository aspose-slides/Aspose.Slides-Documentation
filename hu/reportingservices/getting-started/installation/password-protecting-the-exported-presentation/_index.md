---
title: Exportált prezentáció jelszóval védése
type: docs
weight: 90
url: /hu/reportingservices/password-protecting-the-exported-presentation/
---
{{% alert color="primary" %}} 
A prezentáció jelszóval való védelme megakadályozza a jogosulatlan használatot és hozzáférést. A jelszóvédelem hasznos, ha olyan jelentéseket készít, amelyek érzékeny adatokat vagy olyan részleteket tartalmaznak, amelyeket csak a szervezet bizonyos tagjai láthatnak.

Ez a cikk bemutatja, hogyan frissítheti a Reporting Services vagy Visual Studio környezetet, hogy lehetővé tegye a prezentációk jelszóval való mentését.
{{% /alert %}} 
## **Jelszóvédelem hozzáadása az exportált prezentációkhoz Reporting Services környezetben**
A módosítások alkalmazásához módosítania kell a fájlokat abban a könyvtárban, ahol a Microsoft SQL Server Reporting Services telepítve van.
### **1. lépés. Keresse meg a Reporting Server telepítési könyvtárát.**
A Microsoft SQL Server gyökérkönyvtára általában a C:\Program Files\Microsoft SQL Server.

{{% alert color="primary" %}} 
64 bites rendszer esetén az SQL Server x86 példánya a C:\Program Files (x86)\Microsoft SQL Server\ könyvtárban van telepítve.
{{% /alert %}} 

Microsoft SQL Server 2005 és 2008: A gépen több Microsoft SQL Server példány is konfigurálva lehet. Minden egy külön MSSQL.x almappát foglal el, például MSSQL.1, MSSQL.2 stb. A következő lépések előtt keresse meg a megfelelő C:\Program Files\Microsoft SQL Server\MSSQL.x\Reporting Services\ReportServer könyvtárat.

Az alább használt összes útvonal a Microsoft SQL Server Reporting Services telepítési könyvtárára vonatkozik <Instance>.
### **2. lépés. Adja hozzá a kódot a jelszavak exportált prezentációkhoz**
Az **rsreportserver.config** fájlban cserélje le a meglévő Aspose.Slides for Reporting Services renderelési kiterjesztéseket. Ehhez nyissa meg a C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rsreportserver.config fájlt. 

Keresse meg az azonnal alább felsorolt renderelési beállításokat, és cserélje le őket az azt követő kódrészletben található kóddal.
#### **Keresse meg az Aspose.Slides for Reporting Service renderelési beállításait**
**<Render>**

``` xml

   ...

  <!--Kezdje itt.-->



  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

<!--Itt vége.-->


</Render>



```
#### **Csere kódja**
**<Render>**

``` xml

   ...

  <!--Kezdje itt.-->


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
  <!--Itt vége.-->


</Render>


```
### **Jelszóvédelem hozzáadása az exportált prezentációkhoz Visual Studio-ban**
A módosítások alkalmazásához módosítania kell a fájlt, ahol a Microsoft Visual Studio Report Designer telepítve van.
### **1. lépés. Nyissa meg a Visual Studio könyvtárát.**
- A Visual Studio 2005 Report Designerrel való integrációhoz nyissa meg a C:\Program Files\Microsoft Visual Studio 8\Common7\IDE\PrivateAssemblies könyvtárat.
- A Visual Studio 2008 Report Designerrel való integrációhoz nyissa meg a C:\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies könyvtárat.
### **2. lépés. Adja hozzá a kódot a jelszó exportált prezentációkhoz.**
Az **rsreportserver.config** fájlban cserélje le a meglévő Aspose.Slides for Reporting Services renderelési kiterjesztéseket. Ehhez nyissa meg a C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\ RSReportDesigner.config fájlt (ahol **<Version>** „8” a Visual Studio 2005-hez vagy „9.0” a Visual Studio 2008-hoz), és adja hozzá ezeket a sorokat a **<Render>** elemhez. Ezután cserélje le őket a következő kódrészletben található kóddal.
#### **Keresse meg az Aspose.Slides for Reporting Service renderelési beállításait**
**<Render>**

``` xml

   ...

  <!--Kezdje itt.-->



  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

<!--Itt vége.-->


</Render>



```
#### **Csere kódja**
**<Render>**

``` xml

   ...

  <!--Kezdje itt.-->


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
  <!--Itt vége.-->


</Render>


```