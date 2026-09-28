---
title: Wymagania systemowe
type: docs
weight: 15
url: /pl/reportingservices/system-requirements/
keywords:
- wymagania systemowe
- Serwer raportowania SQL Server
- SSRS
- Serwer raportów Power BI
- .NET Framework 3.5
- Aspose.Slides for Reporting Services
description: "Sprawdź, które serwery raportów, edycje i wersja .NET Framework są potrzebne Aspose.Slides for Reporting Services przed jego instalacją."
---
## **Przegląd**

Aspose.Slides for Reporting Services działa na serwerze raportów jako rozszerzenie renderujące. Ta strona wymienia, czego potrzebuje maszyna serwera raportów przed jej [zainstalować](/slides/pl/reportingservices/installing-aspose-slides-for-reporting-services/). Microsoft PowerPoint i Microsoft Office nie są wymagane.

## **Obsługiwane serwery raportów**

- Microsoft SQL Server 2005 Reporting Services
- Microsoft SQL Server 2008 and 2008 R2 Reporting Services
- Microsoft SQL Server 2012 Reporting Services
- Microsoft SQL Server 2014 Reporting Services
- Microsoft SQL Server 2016 Reporting Services
- Microsoft SQL Server 2017 Reporting Services
- Microsoft SQL Server 2019 Reporting Services
- Power BI Report Server, dla raportów stronicowanych (RDL)

Oba serwery raportów 32‑bitowe i 64‑bitowe są obsługiwane. SQL Server 2005 używa własnej wersji rozszerzenia; wszystkie późniejsze wersje oraz Power BI Report Server używają tej samej wersji. [Instaluj ręcznie](/slides/pl/reportingservices/install-manually/) pokazuje, który plik skopiować.

Jeśli wersja Twojego serwera raportów nie znajduje się na tej liście, zapytaj na [bezpłatnym forum wsparcia](https://forum.aspose.com/c/slides/11) przed wdrożeniem.

## **Edycje serwera raportów**

Dla SQL Server 2016 Reporting Services i nowszych oraz Power BI Report Server, Microsoft obsługuje rozszerzenia renderujące w edycjach Enterprise, Standard, Developer i Evaluation; edycje Web i Express ich nie obsługują. Zobacz [funkcje Reporting Services obsługiwane w edycjach](https://learn.microsoft.com/en-us/sql/reporting-services/reporting-services-features-supported-by-the-editions-of-sql-server). Instalator MSI pomija instancje Express w SQL Server 2016 i wcześniejszych.

## **.NET Framework**

.NET Framework 3.5 musi być zainstalowany na maszynie serwera raportów. Składniki rozszerzenia są zbudowane pod środowisko wykonawcze .NET Framework 2.0, a instalator MSI zatrzymuje się z komunikatem, jeśli .NET Framework 3.5 jest nieobecny. W systemie Windows Server dodaj **.NET Framework 3.5 Features** w Kreatorze Dodawania ról i funkcji; zobacz [Instalowanie .NET Framework 3.5 w systemie Windows](https://learn.microsoft.com/en-us/dotnet/framework/install/dotnet-35-windows).

## **Uprawnienia**

Instalacja rozszerzenia zmienia pliki w folderze serwera raportów, dlatego oba sposoby instalacji wymagają praw administratora lokalnego. Jeśli uruchomisz instalator MSI bez nich, zaproponuje ponowne uruchomienie z uprawnieniami administratora.

## **FAQ**

**Czy potrzebuję Microsoft PowerPoint na serwerze raportów?**

Nie. Rozszerzenie samodzielnie tworzy prezentacje; nie jest wymagane ani PowerPoint, ani Microsoft Office.

**Czy mogę zainstalować rozszerzenie w edycji Express?**

Nie. Edycje Express nie obsługują rozszerzeń renderujących. Instalator MSI ukrywa instancje Express w SQL Server 2016 i wcześniejszych; w nowszych wersjach nie należy wybierać instancji Express.

**Jakie formaty dodaje rozszerzenie do listy eksportu?**

PPT, PPS, PPTX, PPSX, ODP i XPS. Zobacz [Obsługiwane formaty plików](/slides/pl/reportingservices/supported-file-formats/).