---
title: Ochrana heslem exportované prezentace
type: docs
weight: 90
url: /cs/reportingservices/password-protecting-the-exported-presentation/
---
{{% alert color="primary" %}} 

Ochrana prezentace heslem zabraňuje neoprávněnému použití a přístupu. Ochrana heslem je užitečná, pokud vytváříte zprávy, které obsahují citlivá data nebo podrobnosti, které by měly vidět jen některé osoby ve vaší organizaci.

{{% /alert %}} 
## **Přidání ochrany heslem k exportovaným prezentacím v prostředí Reporting Services**
Chcete‑li použít změny zde, musíte upravit soubory v adresáři, kde je nainstalováno Microsoft SQL Server Reporting Services.
### **Krok 1. Najděte instalační adresář Reporting Serveru.**
Kořenový adresář Microsoft SQL Serveru je obvykle C:\Program Files\Microsoft SQL Server.

{{% alert color="primary" %}} 

Pro 64‑bitové systémy je instance x86 SQL Serveru nainstalována v C:\Program Files (x86)\Microsoft SQL Server\

{{% /alert %}} 

Microsoft SQL Server 2005 a 2008: Na počítači může být nakonfiguroáno několik instancí Microsoft SQL Serveru. Každá používá jiný podsložku MSSQL.x, například MSSQL.1, MSSQL.2 a tak dále. Před pokračováním v dalších krocích najděte správný adresář C:\Program Files\Microsoft SQL Server\MSSQL.x\Reporting Services\ReportServer.

Všechny níže použité cesty odkazují na instalační adresář Microsoft SQL Server Reporting Services jako <Instance>.
### **Krok 2. Přidejte kód pro přidání hesel k exportovaným prezentacím**
Nahraďte existující rozšíření vykreslování Aspose.Slides pro Reporting Services v souboru **rsreportserver.config**. K tomu otevřete soubor C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rsreportserver.config.

Najděte níže uvedené možnosti vykreslování a nahraďte je kódem v následujícím úseku.
#### **Najděte možnosti vykreslování Aspose.Slides pro Reporting Service**
**<Render>**

``` xml

   ...

  <!--Začněte zde.-->



  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

<!--Ukončete zde.-->


</Render>



```
#### **Nahrazovací kód**
**<Render>**

``` xml

   ...

  <!--Začněte zde.-->



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

  <!--Ukončete zde.-->


</Render>



```
### **Přidání ochrany heslem k exportovaným prezentacím ve Visual Studio**
Pro aplikaci změn zde musíte upravit soubor, kde je nainstalován Microsoft Visual Studio Report Designer.
### **Krok 1. Otevřete adresář Visual Studio.**
- Pro integraci s Report Designerem ve Visual Studio 2005 otevřete adresář C:\Program Files\Microsoft Visual Studio 8\Common7\IDE\PrivateAssemblies.
- Pro integraci s Report Designerem ve Visual Studio 2008 otevřete adresář C:\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies.
### **Krok 2. Přidejte kód pro přidání hesla k exportovaným prezentacím.**
Nahraďte existující rozšíření vykreslování Aspose.Slides pro Reporting Services v souboru **rsreportserver.config**. K tomu otevřete soubor C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\ RSReportDesigner.config (kde **<Version>** je “8” pro Visual Studio 2005 nebo “9.0” pro Visual Studio 2008) a přidejte tyto řádky do elementu **<Render>**. Pak je nahraďte kódem v následujícím úseku.
#### **Najděte možnosti vykreslování Aspose.Slides pro Reporting Service**
**<Render>**

``` xml

   ...

  <!--Začněte zde.-->



  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

<!--Ukončete zde.-->


</Render>



```
#### **Nahrazovací kód**
**<Render>**

``` xml

   ...

  <!--Začněte zde.-->



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

  <!--Ukončete zde.-->


</Render>



```