---
title: Łatwe i lekkie wdrożenie
type: docs
weight: 50
url: /pl/reportingservices/easy-and-lightweight-deployment/
---
{{% alert color="primary" %}} 

Aspose.Slides for Reporting Services jest [rozszerzeniem renderującym](http://msdn2.microsoft.com/en-us/library/ms154606.aspx) dla Microsoft SQL Server Reporting Services. 
Aspose.Slides for Reporting Services jest dostarczany jako pojedynczy instalator MSI, który może być zainstalowany na komputerach uruchamiających jedną z następujących: 

- Microsoft SQL Server 2005 Reporting Services (32-bit i 64-bit)
- Microsoft SQL Server 2008 Reporting Services (32-bit i 64-bit)

Jest również łatwo wdrożyć i zarządzać Aspose.Slides for Reporting Services ręcznie, ponieważ składa się tylko z jednej biblioteki .NET *Aspose.Slides* *.ReportingServices.dll*, napisanej w pełni w C#, zgodnej z CLS i zawierającej wyłącznie bezpieczny kod zarządzany. 

{{% /alert %}} 

Instalator MSI i pobranie ZIP zawierają Aspose.Slides for ReportingServices: 

- Bin\SSRS2005\Aspose.Slides.ReportingServices.dll – zbudowany dla Microsoft SQL Server 2005 i .NET Framework 2.0 (używany dla x86 i x64)
- Bin\SSRS2008\Aspose.Slides.ReportingServices.dll – zbudowany dla Microsoft SQL Server 2008 i .NET Framework 2.0 (używany dla x86 i x64)

Podczas instalacji plik Aspose.Slides.ReportingServices.dll jest kopiowany do katalogu ReportServer\bin, a plik konfiguracyjny jest aktualizowany, aby Reporting Services był świadomy nowego rozszerzenia renderującego. Kroki te są wykonywane przez instalator Aspose.Slides for Reporting Services, ale możesz je również wykonać ręcznie, jak opisano dalej w tej dokumentacji. 

![todo:image_alt_text](easy-and-lightweight-deployment_1.png)

**Rysunek**: Aspose.Slides.ReportingServices.dll jest kopiowany do katalogu **ReportServer\bin**.