---
title: Łatwe i lekkie wdrażanie
type: docs
weight: 50
url: /pl/reportingservices/easy-and-lightweight-deployment/
description: "Dowiedz się, jak wdraża się Aspose.Slides for Reporting Services: jeden zestaw w folderze bin serwera raportów, zarejestrowany w konfiguracji serwera raportów."
---
{{% alert color="info" title="Uwaga" %}}

Aspose.Slides for Reporting Services jest rozszerzeniem renderowania dla Microsoft SQL Server Reporting Services i Power BI Report Server.  
Aspose.Slides for Reporting Services jest dostarczany jako pojedynczy instalator MSI, który może być zainstalowany na komputerach uruchamiających obsługiwany serwer raportów, 32‑bitowy lub 64‑bitowy; zobacz [Wymagania systemowe](/slides/pl/reportingservices/system-requirements/).

Również łatwo jest wdrażać i zarządzać Aspose.Slides for Reporting Services ręcznie, ponieważ składa się ono tylko z jednej wersji .NET *Aspose.Slides* *.ReportingServices.dll*, napisanego w całości w C#, zgodnego z CLS i zawierającego wyłącznie bezpieczny kod zarządzany.

{{% /alert %}}

Pobranie ZIP zawiera dwie wersje Aspose.Slides.ReportingServices.dll dla serwerów raportów:

- Bin\SSRS2005\Aspose.Slides.ReportingServices.dll – zbudowane dla Microsoft SQL Server 2005 i .NET Framework 2.0 (używać dla x86 i x64)
- Bin\Universal\Aspose.Slides.ReportingServices.dll – zbudowane dla Microsoft SQL Server 2008 i nowszych, Power BI Report Server oraz .NET Framework 2.0 (używać dla x86 i x64)

Instalator MSI instaluje te same dwie wersje i wybiera właściwą dla każdej instancji serwera raportów. [Instaluj ręcznie](/slides/pl/reportingservices/install-manually/) wymienia każdy plik w pobraniu ZIP.

Podczas instalacji Aspose.Slides.ReportingServices.dll jest kopiowany do katalogu ReportServer\bin, a plik konfiguracyjny jest aktualizowany, aby Reporting Services był świadomy nowego rozszerzenia renderowania. Kroki te są wykonywane przez instalator Aspose.Slides for Reporting Services, ale możesz je również wykonać ręcznie, jak opisano dalej w tej dokumentacji.

![todo:image_alt_text](easy-and-lightweight-deployment_1.png)

**Rysunek**: Aspose.Slides.ReportingServices.dll jest kopiowany do katalogu **ReportServer\bin**.