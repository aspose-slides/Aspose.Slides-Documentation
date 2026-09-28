---
title: Instalacja za pomocą instalatora MSI
type: docs
weight: 20
url: /pl/reportingservices/install-with-msi-installer/
keywords:
- Instalator MSI
- instalacja
- SQL Server Reporting Services
- Power BI Report Server
- Aspose.Slides for Reporting Services
description: "Zainstaluj Aspose.Slides for Reporting Services przy użyciu instalatora MSI: czego wymaga instalator, co zmienia na każdej instancji serwera raportów oraz jak sprawdzić wynik."
---
## **Instalacja**

Instalator MSI jest najprostszym sposobem instalacji Aspose.Slides for Reporting Services. Wymaga .NET Framework 3.5 oraz uprawnień administratora na serwerze raportów; zobacz [Wymagania systemowe](/slides/pl/reportingservices/system-requirements/).

1. Pobierz instalator MSI, *Aspose.Slides for Reporting Services XX.XX*, ze [strona pobierania](https://releases.aspose.com/slides/pl/reportingservices/) i skopiuj go na serwer raportów.
1. Uruchom go jako administrator. Jeśli brakuje .NET Framework 3.5, instalator zatrzyma się z komunikatem; zainstaluj funkcje .NET Framework 3.5 i uruchom go ponownie.
1. Zaakceptuj umowę licencyjną.
1. Na stronie **Custom Setup** drzewo funkcji wyświetla każdą instancję SQL Server Reporting Services i Power BI Report Server wykrytą przez instalator na komputerze. Aby pozostawić instancję bez zmian, kliknij jej ikonę i wybierz **Entire feature will be unavailable**. Wersje Express nie obsługują rozszerzeń renderowania, więc nie wybieraj instancji Express. Instalator ukrywa instancje Express SQL Server 2016 i starsze.
1. Wybierz **Next**, a następnie **Install**.

Opcjonalna funkcja **Rpl Export** nie jest zaznaczona domyślnie. Dodaje ukryte rozszerzenie zapisujące raporty w formacie RPL, co jest przydatne przy wysyłaniu raportu o problemie do Aspose; zobacz [Eksportowanie raportów do formatu RPL](/slides/pl/reportingservices/exporting-reports-to-rpl-format/).

## **Co zmienia instalator**

Instalator przechowuje swoje pliki w *Aspose\Aspose.Slides for Reporting Services* w folderze Program Files — *Program Files (x86)* w systemie Windows 64‑bit, ponieważ instalator jest pakietem 32‑bitowym. Następnie, dla każdej wybranej instancji, wykonuje:

- kopiuje *Aspose.Slides.ReportingServices.dll* do folderu *ReportServer\bin* danej instancji — wersja dla SQL Server 2005 lub wersja dla SQL Server 2008 i nowszych oraz Power BI Report Server;
- dodaje sześć rozszerzeń renderowania — ASPPT, ASPPS, ASPPTX, ASPPSX, ASXPSS i ASODP — do elementu `<Render>` w pliku *rsreportserver.config*;
- dodaje grupę kodu, która przyznaje zestawowi pełne zaufanie w pliku *rssrvpolicy.config*;
- zapisuje kopię każdego zmienianego pliku konfiguracyjnego, dodając rozszerzenie *.bak* do nazwy pliku.

[Instalacja ręczna](/slides/pl/reportingservices/install-manually/) pokazuje te zmiany krok po kroku.

Jeśli nie można skonfigurować instancji, instalator wymienia ją w komunikacie i zapisuje szczegóły w pliku *rserrors<date>.log* w folderze instalacji. Zainstaluj rozszerzenie na tej instancji ręcznie.

## **Sprawdź instalację**

Otwórz raport stronicowany w portalcie internetowym (Report Manager w SQL Server 2014 i wcześniejszych) i otwórz listę **Export**. Teraz zawiera ona następujące formaty:

- PPT – prezentacja PowerPoint via Aspose.Slides
- PPS – pokaz slajdów PowerPoint via Aspose.Slides
- PPTX – prezentacja PowerPoint 2007 via Aspose.Slides
- PPSX – pokaz slajdów PowerPoint 2007 via Aspose.Slides
- ODP – prezentacja OpenDocument via Aspose.Slides
- XPS – via Aspose.Slides

Bez licencji wyeksportowane pliki zawierają znak wodny oceny; zobacz [Licencjonowanie](/slides/pl/reportingservices/license-aspose-slides-for-reporting-services/).

## **Kiedy instalować ręcznie**

Zainstaluj rozszerzenie [ręcznie](/slides/pl/reportingservices/install-manually/) zamiast, gdy:

- instalator nie może skonfigurować instancji, na przykład z powodu ustawień zabezpieczeń na serwerze;
- po aktualizacji chcesz wymienić tylko zestaw, zamiast odinstalowywać starą wersję i uruchamiać nowy instalator.

Odinstalowanie produktu usuwa zestaw i wpisy konfiguracyjne z każdej instancji.