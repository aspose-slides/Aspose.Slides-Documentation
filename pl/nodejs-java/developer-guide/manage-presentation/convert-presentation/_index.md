---
title: Konwertuj prezentacje do wielu formatów w JavaScript
linktitle: Konwertuj prezentację
type: docs
weight: 70
url: /pl/nodejs-java/convert-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Konwertuj prezentacje PowerPoint i OpenDocument do formatów PPTX, PDF, HTML, obrazów, XPS, TIFF i innych przy użyciu Aspose.Slides dla Node.js via Java."
---
## **Przegląd**

Aspose.Slides for Node.js via Java może ładować prezentacje PowerPoint i OpenDocument oraz zapisywać je lub renderować do wielu innych formatów bez Microsoft PowerPoint, OpenOffice ani LibreOffice. Można konwertować starsze pliki PPT do nowoczesnych PPTX, eksportować prezentacje do dokumentów o stałym układzie, takich jak PDF i XPS, publikować slajdy jako HTML lub renderować slajdy jako pliki graficzne do podglądów, miniatur i archiwów.

Większość konwersji dokumentów używa tego samego ogólnego przepływu pracy: ładowania pliku źródłowego, wyboru wymaganego formatu wyjściowego oraz zastosowania opcji specyficznych dla formatu w razie potrzeby. Dla formatów graficznych każdy slajd jest renderowany osobno, a następnie zapisywany jako obraz rastrowy lub wektorowy. Dedykowane artykuły wymienione poniżej zawierają szczegóły implementacji dla każdego przypadku.

## **Wybierz scenariusz konwersji**

| Scenariusz | Użyj, gdy potrzebujesz | Artykuł |
| --- | --- | --- |
| PPT/PPTX/ODP do PPTX | Modernizuj starsze pliki PPT, normalizuj istniejące pliki PPTX lub konwertuj prezentacje OpenDocument do PowerPoint PPTX. | [Konwertuj PPT do PPTX](/slides/pl/nodejs-java/convert-ppt-to-pptx/), [Konwertuj ODP do PPTX](/slides/pl/nodejs-java/convert-odp-to-pptx/), [Zapisz prezentacje](/slides/pl/nodejs-java/save-presentation/) |
| PPTX do PPT | Zapisz nowoczesną prezentację PowerPoint w starszym binarnym formacie PPT w celu zapewnienia kompatybilności ze starszymi przepływami pracy. | [Konwertuj PPTX do PPT](/slides/pl/nodejs-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP do PDF | Utwórz przenośne, przeszukiwalne dokumenty o stałym układzie do udostępniania, drukowania lub archiwizacji. | [Konwertuj PowerPoint do PDF](/slides/pl/nodejs-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP do PDF z notatkami | Eksportuj notatki prelegenta wraz z zawartością slajdów. | [Konwertuj PowerPoint do PDF z notatkami](/slides/pl/nodejs-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP do HTML | Publikuj prezentacje jako strony HTML i kontroluj obrazy, czcionki, notatki oraz opcje responsywnego układu. | [Konwertuj PowerPoint do HTML](/slides/pl/nodejs-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP do HTML5 | Eksportuj slajdy do HTML5 do przeglądania w przeglądarce z zachowaniem formatowania i interaktywności. | [Konwertuj prezentacje do HTML5](/slides/pl/nodejs-java/export-to-html5/) |
| PPT/PPTX/ODP do PNG | Renderuj każdy slajd jako obraz PNG do podglądów, miniatur lub wyjścia webowego. | [Konwertuj PowerPoint do PNG](/slides/pl/nodejs-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP do JPG | Renderuj slajdy jako obrazy JPG i kontroluj wymiary oraz jakość obrazu. | [Konwertuj PowerPoint do JPG](/slides/pl/nodejs-java/convert-powerpoint-to-jpg/) |
| Slide do SVG | Eksportuj pojedyncze slajdy jako skalowalną grafikę wektorową. | [Renderuj slajd jako SVG](/slides/pl/nodejs-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP do XPS | Generuj dokumenty XPS o stałym układzie. | [Konwertuj PowerPoint do XPS](/slides/pl/nodejs-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP do TIFF | Zapisz prezentację jako wielostronicowy plik TIFF do drukowania, skanowania, faksu lub przepływów archiwizacji. | [Konwertuj PowerPoint do TIFF](/slides/pl/nodejs-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP do TIFF z notatkami | Zapisz slajdy z notatkami prelegenta w formacie TIFF. | [Konwertuj PowerPoint do TIFF z notatkami](/slides/pl/nodejs-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX do Markdown | Wyodrębnij zawartość prezentacji do Markdown dla dokumentacji i przepływów pracy opartych na tekście. | [Konwertuj PowerPoint do Markdown](/slides/pl/nodejs-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX do animowanego GIF | Utwórz animowany GIF ze slajdów. | [Konwertuj PowerPoint do animowanego GIF](/slides/pl/nodejs-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX do wideo | Stwórz przepływ eksportu wideo ze slajdów prezentacji. | [Konwertuj PowerPoint do wideo](/slides/pl/nodejs-java/convert-powerpoint-to-video/) |
| Presentation do XAML | Eksportuj slajdy do XAML dla scenariuszy interfejsu JavaScript lub Java. | [Eksportuj prezentacje do XAML](/slides/pl/nodejs-java/export-to-xaml/) |

Aby zobaczyć szerszą listę formatów wejściowych i wyjściowych, zobacz [Obsługiwane formaty plików](/slides/pl/nodejs-java/supported-file-formats/).

## **Konwersja PowerPoint i OpenDocument**

Aspose.Slides for Node.js via Java obsługuje konwersję z powszechnie używanych formatów prezentacji, takich jak PPT, PPTX, PPS, PPSX, POT, POTX i ODP. To samo API konwersji jest używane dla plików PowerPoint i OpenDocument, więc przepływ pracy, który zapisuje plik PPTX do PDF, można zazwyczaj zastosować do pliku ODP, zmieniając tylko plik wejściowy.

Podczas konwertowania plików ODP pamiętaj, że aplikacje PowerPoint i OpenDocument nie obsługują wszystkich funkcji układu i formatowania w dokładnie taki sam sposób. Jeśli plik ODP został utworzony w LibreOffice lub OpenOffice Impress, sprawdź wynik i użyj opcji opisanych w [Konwertuj prezentacje OpenDocument](/slides/pl/nodejs-java/convert-openoffice-odp/) gdy potrzebujesz wskazówek specyficznych dla formatu.

## **Konwersja PPT do PPTX**

PPT jest starszym binarnym formatem PowerPoint, natomiast PPTX jest nowoczesnym formatem Office Open XML. Aspose.Slides for Node.js via Java obsługuje konwersję PPT do PPTX o wysokiej wierności, zachowując złożone struktury prezentacji, takie jak wzorce, układy, slajdy, wykresy, grupowane kształty, pola zastępcze, ramki tekstowe, tekstury i wypełnienia obrazami.

Aby uzyskać szczegóły, zobacz [Konwertuj PPT do PPTX](/slides/pl/nodejs-java/convert-ppt-to-pptx/) oraz [PPT vs PPTX](/slides/pl/nodejs-java/ppt-vs-pptx/).

## **Eksport o stałym układzie**

PDF, XPS i TIFF są przydatne, gdy wynik ma wyglądać tak samo na różnych urządzeniach i nie powinien być edytowany jako prezentacja. Dedykowane artykuły o PDF, XPS i TIFF wyjaśniają, jak kontrolować zgodność, ukryte slajdy, notatki, jakość obrazu, kompresję, format pikseli i rozmiar wyjścia.

## **Eksport HTML i obrazów**

Eksport HTML i HTML5 jest przydatny do przeglądania w przeglądarce, publikacji internetowych i lekkiego udostępniania. Eksport obrazów jest przydatny, gdy każdy slajd ma stać się oddzielnym podglądem, miniaturą lub zasobem rastrowym. Skorzystaj z artykułów o PNG, JPG i SVG, aby uzyskać wskazówki dotyczące renderowania specyficzne dla formatu.

## **FAQ**

**Czy potrzebuję Microsoft PowerPoint do konwertowania prezentacji?**

Nie. Aspose.Slides for Node.js via Java jest samodzielną biblioteką i nie wymaga Microsoft PowerPoint ani automatyzacji Office.

**Czy mogę masowo konwertować wiele prezentacji?**

Tak. Załaduj każdą prezentację, zapisz ją w wymaganym formacie i zwolnij obiekt prezentacji po przetworzeniu. W celu przetwarzania równoległego użyj oddzielnych instancji prezentacji i postępuj zgodnie z wytycznymi dotyczącymi [wielowątkowość](/slides/pl/nodejs-java/multithreading/).

**Czy mogę eksportować tylko wybrane slajdy?**

Tak. Wiele metod eksportu pozwala przekazać indeksy slajdów lub renderować poszczególne slajdy, w zależności od formatu wyjściowego. Zobacz dedykowany artykuł dla wybranego formatu.

**Czy mogę uwzględnić ukryte slajdy podczas eksportu do PDF lub XPS?**

Tak. Użyj ustawień eksportu ukrytych slajdów opisanych w artykułach konwersji [PDF](/slides/pl/nodejs-java/convert-powerpoint-to-pdf/) i [XPS](/slides/pl/nodejs-java/convert-powerpoint-to-xps/).

**Czy mogę tworzyć wyjście PDF/A?**

Tak. Ustawienia zgodności PDF są dostępne przy eksporcie PDF. Zobacz [Konwertuj PowerPoint do PDF](/slides/pl/nodejs-java/convert-powerpoint-to-pdf/) po szczegóły.

**Jak czcionki są obsługiwane podczas konwersji?**

Aspose.Slides może używać wbudowanych czcionek, rezerwowych czcionek oraz ustawień substytucji czcionek. Zobacz [Wbudowane czcionki](/slides/pl/nodejs-java/embedded-font/), [Czcionka rezerwowa](/slides/pl/nodejs-java/fallback-font/), oraz [Zastąpienie czcionki](/slides/pl/nodejs-java/font-substitution/).