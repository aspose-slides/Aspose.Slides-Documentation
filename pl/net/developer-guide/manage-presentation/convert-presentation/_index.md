---
title: Konwertuj prezentacje do wielu formatów w .NET
linktitle: Konwertuj prezentację
type: docs
weight: 70
url: /pl/net/convert-presentation/
keywords:
- konwertuj prezentację
- eksportuj prezentację
- PPT do PPTX
- PPTX do PPT
- ODP do PPTX
- PPT do PDF
- PPTX do PDF
- ODP do PDF
- PPT do HTML
- PPTX do HTML
- ODP do HTML
- PPT do PNG
- PPTX do PNG
- ODP do PNG
- PPTX do JPG
- ODP do JPG
- PPT do XPS
- PPTX do XPS
- ODP do XPS
- PPT do TIFF
- PPTX do TIFF
- ODP do TIFF
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Konwertuj prezentacje PowerPoint i OpenDocument do PPTX, PDF, HTML, obrazów, XPS, TIFF i innych za pomocą Aspose.Slides dla .NET."
---
## **Przegląd**

Aspose.Slides for .NET może ładować prezentacje PowerPoint i OpenDocument oraz zapisywać lub renderować je do wielu innych formatów bez Microsoft PowerPoint, OpenOffice ani LibreOffice. Możesz konwertować starsze pliki PPT do nowoczesnych PPTX, eksportować prezentacje do dokumentów o stałym układzie, takich jak PDF i XPS, publikować slajdy jako HTML lub renderować slajdy jako pliki graficzne do podglądów, miniatur i archiwów.

Większość konwersji dokumentów używa tego samego ogólnego przebiegu pracy: załaduj plik źródłowy, wybierz wymaganą format wyjściowy i w razie potrzeby zastosuj opcje specyficzne dla formatu. Dla formatów graficznych każdy slajd renderowany jest osobno, a następnie zapisywany jako obraz rastrowy lub wektorowy. Dedykowane artykuły zamieszczone poniżej zawierają szczegóły implementacji dla każdego przypadku.

## **Wybierz scenariusz konwersji**

Użyj poniższych artykułów, aby uzyskać pełne przykłady C# i opcje specyficzne dla formatu.

| Scenariusz | Użyj, gdy potrzebujesz | Artykuł |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | Uaktualnij starsze pliki PPT, znormalizuj istniejące pliki PPTX lub skonwertuj prezentacje OpenDocument do PowerPoint PPTX. | [Konwertuj PPT do PPTX](/slides/pl/net/convert-ppt-to-pptx/), [Konwertuj ODP do PPTX](/slides/pl/net/convert-odp-to-pptx/), [Zapisz prezentacje](/slides/pl/net/save-presentation/) |
| PPTX to PPT | Zapisz nowoczesną prezentację PowerPoint w starszym binarnym formacie PPT, aby zapewnić kompatybilność ze starszymi przepływami pracy. | [Konwertuj PPTX do PPT](/slides/pl/net/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | Utwórz przenośne, przeszukiwalne dokumenty o stałym układzie do udostępniania, drukowania lub archiwizacji. | [Konwertuj PowerPoint do PDF](/slides/pl/net/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | Eksportuj notatki prelegenta wraz z zawartością slajdów. | [Konwertuj PowerPoint do PDF z notatkami](/slides/pl/net/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | Opublikuj prezentacje jako strony HTML i kontroluj obrazy, czcionki, notatki oraz opcje responsywnego układu. | [Konwertuj PowerPoint do HTML](/slides/pl/net/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | Eksportuj slajdy do HTML5 do przeglądania w przeglądarce z zachowaniem formatowania i interaktywności. | [Konwertuj prezentacje do HTML5](/slides/pl/net/export-to-html5/) |
| PPT/PPTX/ODP to PNG | Renderuj każdy slajd jako obraz PNG do podglądów, miniaturek lub wyjścia internetowego. | [Konwertuj PowerPoint do PNG](/slides/pl/net/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | Renderuj slajdy jako obrazy JPG i kontroluj wymiary oraz jakość obrazu. | [Konwertuj PowerPoint do JPG](/slides/pl/net/convert-powerpoint-to-jpg/) |
| Slide to SVG | Eksportuj pojedyncze slajdy jako skalowalne grafiki wektorowe. | [Renderuj slajd jako SVG](/slides/pl/net/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | Generuj dokumenty XPS o stałym układzie. | [Konwertuj PowerPoint do XPS](/slides/pl/net/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | Zapisz prezentację jako wielostronicowy plik TIFF do drukowania, skanowania, faksu lub archiwizacji. | [Konwertuj PowerPoint do TIFF](/slides/pl/net/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | Zapisz slajdy z notatkami prelegenta w formacie TIFF. | [Konwertuj PowerPoint do TIFF z notatkami](/slides/pl/net/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Word | Konwertuj slajdy do dokumentu Word, gdy potrzebny jest format dokumentu. | [Konwertuj PowerPoint do Word](/slides/pl/net/convert-powerpoint-to-word/) |
| PPT/PPTX to Markdown | Wyodrębnij zawartość prezentacji do formatu Markdown do dokumentacji i przepływów pracy opartych na tekście. | [Konwertuj PowerPoint do Markdown](/slides/pl/net/convert-powerpoint-to-markdown/) |
| PPT/PPTX to animated GIF | Utwórz animowany GIF ze slajdów. | [Konwertuj PowerPoint do animowanego GIF](/slides/pl/net/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | Zbuduj przepływ eksportu wideo ze slajdów prezentacji. | [Konwertuj PowerPoint do wideo](/slides/pl/net/convert-powerpoint-to-video/) |
| Presentation to XAML | Eksportuj slajdy do XAML dla scenariuszy interfejsu UI w .NET. | [Eksportuj prezentacje do XAML](/slides/pl/net/export-to-xaml/) |

Aby zobaczyć szerszą listę formatów wejściowych i wyjściowych, zobacz [Obsługiwane formaty plików](/slides/pl/net/supported-file-formats/).

## **Konwersja PowerPoint i OpenDocument**

Aspose.Slides for .NET obsługuje konwersję z powszechnie używanych formatów prezentacji, takich jak PPT, PPTX, PPS, PPSX, POT, POTX i ODP. Ten sam interfejs API konwersji jest używany zarówno dla plików PowerPoint, jak i OpenDocument, więc przepływ pracy, który zapisuje plik PPTX do PDF, zwykle może być zastosowany do pliku ODP po zmianie jedynie pliku wejściowego.

Podczas konwertowania plików ODP pamiętaj, że aplikacje PowerPoint i OpenDocument nie obsługują każdej funkcji układu i formatowania w dokładnie taki sam sposób. Jeśli plik ODP został utworzony w LibreOffice lub OpenOffice Impress, sprawdź wynik i skorzystaj z opcji opisanych w [Convert OpenDocument Presentations](/slides/pl/net/convert-openoffice-odp/) gdy potrzebne są wskazówki specyficzne dla formatu.

## **Konwersja PPT do PPTX**

PPT jest starszym binarnym formatem PowerPoint, natomiast PPTX jest nowoczesnym formatem Office Open XML. Aspose.Slides for .NET zapewnia wysokiej wierności konwersję PPT do PPTX, zachowując skomplikowane struktury prezentacji, takie jak mastery, układy, slajdy, wykresy, grupowane kształty, placeholdery, ramki tekstowe, tekstury i wypełnienia obrazami.

Szczegóły znajdziesz w [Convert PPT to PPTX](/slides/pl/net/convert-ppt-to-pptx/) oraz [PPT vs PPTX](/slides/pl/net/ppt-vs-pptx/).

## **Eksport o stałym układzie**

PDF, XPS i TIFF są przydatne, gdy wyjście ma wyglądać tak samo na wszystkich urządzeniach i nie powinno być edytowane jako prezentacja. Użyj [PdfOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/pdfoptions/), [XpsOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/xpsoptions/) i [TiffOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/tiffoptions/), aby kontrolować zgodność, ukryte slajdy, notatki, jakość obrazu, kompresję, format pikseli i rozmiar wyjścia.

## **Eksport HTML i obrazów**

Eksport HTML i HTML5 jest przydatny do przeglądania w przeglądarce, publikacji internetowej i lekkiego udostępniania. Eksport obrazów jest przydatny, gdy każdy slajd musi stać się oddzielnym podglądem, miniaturą lub zasobem rastrowym. Skorzystaj z artykułów dotyczących PNG, JPG i SVG, aby uzyskać wskazówki dotyczące renderowania specyficzne dla formatu.

## **FAQ**

**Czy potrzebuję Microsoft PowerPoint do konwertowania prezentacji?**

Nie. Aspose.Slides for .NET jest samodzielną biblioteką i nie wymaga Microsoft PowerPoint ani automatyzacji Office.

**Czy mogę wsadowo konwertować wiele prezentacji?**

Tak. Załaduj każdą prezentację, zapisz ją w wymaganym formacie i zwolnij obiekt `Presentation` po przetworzeniu. Do przetwarzania równoległego używaj osobnych instancji prezentacji i przestrzegaj wskazówek dotyczących [multithreading](/slides/pl/net/multithreading/).

**Czy mogę eksportować tylko wybrane slajdy?**

Tak. Wiele metod eksportu pozwala przekazać indeksy slajdów lub renderować pojedyncze slajdy, w zależności od formatu wyjściowego. Zobacz dedykowany artykuł dla wybranego formatu.

**Czy mogę uwzględnić ukryte slajdy przy eksporcie do PDF lub XPS?**

Tak. Użyj właściwości `ShowHiddenSlides` w [PdfOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/pdfoptions/) lub [XpsOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/xpsoptions/).

**Czy mogę utworzyć wyjście PDF/A?**

Tak. Ustawienia zgodności PDF są dostępne poprzez [PdfOptions.Compliance](https://reference.aspose.com/slides/pl/net/aspose.slides.export/pdfoptions/compliance/) oraz [PdfCompliance](https://reference.aspose.com/slides/pl/net/aspose.slides.export/pdfcompliance/).

**Jak obsługiwane są czcionki podczas konwersji?**

Aspose.Slides może używać czcionek osadzonych, mechanizmu fallback oraz ustawień podstawiania czcionek. Zobacz [Embedded Font](/slides/pl/net/embedded-font/), [Fallback Font](/slides/pl/net/fallback-font/) i [Font Substitution](/slides/pl/net/font-substitution/).