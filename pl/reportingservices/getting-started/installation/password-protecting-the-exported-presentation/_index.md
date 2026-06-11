---
title: Zabezpieczanie hasłem wyeksportowanej prezentacji
type: docs
weight: 90
url: /pl/reportingservices/password-protecting-the-exported-presentation/
---
{{% alert color="primary" %}} 

Zabezpieczenie prezentacji hasłem zapobiega nieautoryzowanemu użyciu i dostępowi. Ochrona hasłem jest przydatna, jeśli tworzysz raporty zawierające wrażliwe dane lub szczegóły, które powinny widzieć tylko niektóre osoby w Twojej organizacji.

Ten artykuł pokazuje, jak zaktualizować środowisko Reporting Services lub Visual Studio, aby umożliwić zapisywanie prezentacji z ochroną hasłem.

{{% /alert %}} 
## **Dodawanie ochrony hasłem do wyeksportowanych prezentacji w środowisku Reporting Services**
Aby zastosować te zmiany, musisz zmodyfikować pliki w katalogu, w którym zainstalowano Microsoft SQL Server Reporting Services.
### **Krok 1. Znajdź katalog instalacyjny Reporting Server.**
Katalog główny Microsoft SQL Server znajduje się zazwyczaj w C:\Program Files\Microsoft SQL Server.

{{% alert color="primary" %}} 

W systemie 64‑bitowym instancja x86 SQL Server jest instalowana w C:\Program Files (x86)\Microsoft SQL Server\

{{% /alert %}} 

Microsoft SQL Server 2005 i 2008: Na maszynie może być skonfigurowanych kilka instancji Microsoft SQL Server. Każda zajmuje inny podkatalog MSSQL.x, na przykład MSSQL.1, MSSQL.2 i tak dalej. Znajdź prawidłowy katalog C:\Program Files\Microsoft SQL Server\MSSQL.x\Reporting Services\ReportServer przed kontynuowaniem kolejnych kroków.

Wszystkie poniższe ścieżki odwołują się do katalogu instalacyjnego Microsoft SQL Server Reporting Services jako <Instance>.
### **Krok 2. Dodaj kod umożliwiający ustawianie haseł w wyeksportowanych prezentacjach**
Zastąp istniejące rozszerzenia renderujące Aspose.Slides for Reporting Services w pliku **rsreportserver.config**. Aby to zrobić, otwórz plik C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rsreportserver.config. 

Znajdź poniżej wymienione opcje renderowania i zamień je na kod z kolejnego segmentu.
#### **Znajdź opcje renderowania Aspose.Slides for Reporting Service**
**<Render>**

``` xml

   ...

  <!--Rozpocznij tutaj.-->



  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

<!--Zakończ tutaj.-->


</Render>
```
#### **Kod zamiany**
**<Render>**

``` xml

   ...

  <!--Rozpocznij tutaj.-->



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

  <!--Zakończ tutaj.-->


</Render>
```
### **Dodawanie ochrony hasłem do wyeksportowanych prezentacji w Visual Studio**
Aby zastosować te zmiany, musisz zmodyfikować plik, w którym zainstalowano Microsoft Visual Studio Report Designer.
### **Krok 1. Otwórz katalog Visual Studio.**
- Aby zintegrować się z Report Designer w Visual Studio 2005, otwórz katalog C:\Program Files\Microsoft Visual Studio 8\Common7\IDE\PrivateAssemblies.
- Aby zintegrować się z Report Designer w Visual Studio 2008, otwórz katalog C:\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies.
### **Krok 2. Dodaj kod umożliwiający ustawianie hasła w wyeksportowanych prezentacjach.**
Zastąp istniejące rozszerzenia renderujące Aspose.Slides for Reporting Services w pliku **rsreportserver.config**. Aby to zrobić, otwórz plik C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\RSReportDesigner.config (gdzie **<Version>** to “8” dla Visual Studio 2005 lub “9.0” dla Visual Studio 2008) i dodaj te linie w elemencie **<Render>**. Następnie zamień je kodem z kolejnego segmentu kodu.
#### **Znajdź opcje renderowania Aspose.Slides for Reporting Service**
**<Render>**

``` xml

   ...

  <!--Rozpocznij tutaj.-->



  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

<!--Zakończ tutaj.-->


</Render>
```
#### **Kod zamiany**
**<Render>**

``` xml

   ...

  <!--Rozpocznij tutaj.-->


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
  <!--Zakończ tutaj.-->


</Render>
```