---
title: Konwertuj prezentacje do wielu formatów w PHP
linktitle: Konwertuj prezentację
type: docs
weight: 70
url: /pl/php-java/convert-presentation/
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
- PHP
- Aspose.Slides
description: "Konwertuj prezentacje PowerPoint i OpenDocument do formatów PPTX, PDF, HTML, obrazów, XPS, TIFF i innych przy użyciu Aspose.Slides for PHP via Java."
---
## **Przegląd**

Aspose.Slides for PHP via Java może wczytywać prezentacje PowerPoint i OpenDocument oraz zapisywać lub renderować je do wielu innych formatów bez potrzeby posiadania Microsoft PowerPoint, OpenOffice ani LibreOffice. Możesz konwertować starsze pliki PPT na nowoczesne PPTX, eksportować prezentacje do dokumentów o stałym układzie, takich jak PDF i XPS, publikować slajdy jako HTML albo renderować slajdy jako pliki graficzne do podglądów, miniatur i archiwów.

Większość konwersji dokumentów korzysta z takiego samego ogólnego przepływu pracy: wczytaj plik źródłowy, wybierz żądany format wyjściowy i zastosuj opcje specyficzne dla formatu w razie potrzeby. W przypadku formatów graficznych każdy slajd jest renderowany osobno, a następnie zapisywany jako obraz rastrowy lub wektorowy. Dedykowane artykuły wymienione poniżej zawierają szczegóły implementacji dla poszczególnych przypadków.

## **Wybierz scenariusz konwersji**

Użyj poniższych artykułów, aby uzyskać pełne przykłady w PHP oraz opcje specyficzne dla formatu.

| Scenariusz | Użyj, gdy potrzebujesz | Artykuł |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | Zmodernizować starsze pliki PPT, ujednolicić istniejące pliki PPTX lub skonwertować prezentacje OpenDocument do PowerPoint PPTX. | [Konwertuj PPT do PPTX](/slides/pl/php-java/convert-ppt-to-pptx/), [Konwertuj ODP do PPTX](/slides/pl/php-java/convert-odp-to-pptx/), [Zapisz prezentacje](/slides/pl/php-java/save-presentation/) |
| PPTX to PPT | Zapisać nowoczesną prezentację PowerPoint w starszym binarnym formacie PPT w celu zachowania kompatybilności ze starszymi procesami. | [Konwertuj PPTX do PPT](/slides/pl/php-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | Utworzyć przenośne, przeszukiwalne dokumenty o stałym układzie do udostępniania, drukowania lub archiwizacji. | [Konwertuj PowerPoint do PDF](/slides/pl/php-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | Eksportować notatki prelegenta wraz z treścią slajdów. | [Konwertuj PowerPoint do PDF z notatkami](/slides/pl/php-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | Publikować prezentacje jako strony HTML i kontrolować obrazy, czcionki, notatki oraz opcje responsywnego układu. | [Konwertuj PowerPoint do HTML](/slides/pl/php-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | Eksportować slajdy do HTML5 do przeglądania w przeglądarce z zachowaniem formatowania i interaktywności. | [Eksportuj prezentacje do HTML5](/slides/pl/php-java/export-to-html5/) |
| PPT/PPTX/ODP to PNG | Renderować każdy slajd jako obraz PNG do podglądów, miniatur lub wyjścia internetowego. | [Konwertuj PowerPoint do PNG](/slides/pl/php-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | Renderować slajdy jako obrazy JPG i kontrolować wymiary oraz jakość obrazu. | [Konwertuj PowerPoint do JPG](/slides/pl/php-java/convert-powerpoint-to-jpg/) |
| Slide to SVG | Eksportować pojedyncze slajdy jako skalowalne grafiki wektorowe. | [Renderuj slajd jako SVG](/slides/pl/php-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | Generować dokumenty XPS o stałym układzie. | [Konwertuj PowerPoint do XPS](/slides/pl/php-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | Zapisać prezentację jako wielostronicowy plik TIFF do drukowania, skanowania, faksowania lub archiwizacji. | [Konwertuj PowerPoint do TIFF](/slides/pl/php-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | Zapisać slajdy z notatkami prelegenta w formacie TIFF. | [Konwertuj PowerPoint do TIFF z notatkami](/slides/pl/php-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Markdown | Wyodrębnić treść prezentacji do formatu Markdown dla dokumentacji i przepływów pracy opartych na tekście. | [Konwertuj PowerPoint do Markdown](/slides/pl/php-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX to animated GIF | Utworzyć animowany GIF ze slajdów. | [Konwertuj PowerPoint do animowanego GIF](/slides/pl/php-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | Zbudować przepływ eksportu wideo ze slajdów prezentacji. | [Konwertuj PowerPoint do wideo](/slides/pl/php-java/convert-powerpoint-to-video/) |
| Presentation to XAML | Eksportować slajdy do XAML dla scenariuszy interfejsu PHP lub Java. | [Eksportuj prezentacje do XAML](/slides/pl/php-java/export-to-xaml/) |

Aby zobaczyć szerszą listę formatów wejściowych i wyjściowych, zobacz [Obsługiwane formaty plików](/slides/pl/php-java/supported-file-formats/).

## **Konwersja PowerPoint i OpenDocument**

Aspose.Slides for PHP via Java obsługuje konwersję z powszechnie używanych formatów prezentacji, takich jak PPT, PPTX, PPS, PPSX, POT, POTX oraz ODP. To samo API konwersji jest używane dla plików PowerPoint i OpenDocument, więc przepływ pracy, który zapisuje plik PPTX jako PDF, zazwyczaj można zastosować do pliku ODP, zmieniając jedynie plik wejściowy.

Podczas konwersji plików ODP pamiętaj, że aplikacje PowerPoint i OpenDocument nie obsługują wszystkich układów i funkcji formatowania w dokładnie ten sam sposób. Jeśli plik ODP został utworzony w LibreOffice lub OpenOffice Impress, przejrzyj wynik i skorzystaj z opcji opisanych w [Konwertuj prezentacje OpenDocument](/slides/pl/php-java/convert-openoffice-odp/) w razie potrzeby.

## **Konwersja PPT do PPTX**

PPT jest starszym binarnym formatem PowerPoint, natomiast PPTX to nowoczesny format Office Open XML. Aspose.Slides for PHP via Java zapewnia wysoką wierność konwersji PPT do PPTX, zachowując złożone struktury prezentacji, takie jak szablony, układy, slajdy, wykresy, grupowane kształty, pola zastępcze, ramki tekstowe, tekstury i wypełnienia obrazami.

Szczegóły znajdziesz w [Konwertuj PPT do PPTX](/slides/pl/php-java/convert-ppt-to-pptx/) oraz [PPT vs PPTX](/slides/pl/php-java/ppt-vs-pptx/).

## **Eksport o stałym układzie**

PDF, XPS i TIFF są przydatne, gdy wyjście ma wyglądać identycznie na wszystkich urządzeniach i nie powinno być edytowane jako prezentacja. Dedykowane artykuły o PDF, XPS i TIFF wyjaśniają, jak kontrolować zgodność, ukryte slajdy, notatki, jakość obrazu, kompresję, format pikseli i rozmiar wyjściowy.

## **Eksport HTML i obrazów**

Eksport do HTML i HTML5 jest przydatny do przeglądania w przeglądarce, publikacji internetowej i lekkiego udostępniania. Eksport obrazów jest przydatny, gdy każdy slajd ma stać się osobnym podglądem, miniaturą lub zasobem rastrowym. Skorzystaj z artykułów o PNG, JPG i SVG, aby uzyskać wskazówki dotyczące renderowania specyficzne dla formatu.

## **FAQ**

**Czy potrzebuję Microsoft PowerPoint do konwertowania prezentacji?**

Nie. Aspose.Slides for PHP via Java jest samodzielną biblioteką i nie wymaga Microsoft PowerPoint ani automatyzacji Office.

**Czy mogę konwertować wiele prezentacji jednocześnie?**

Tak. Wczytaj każdą prezentację, zapisz ją w wymaganym formacie i zwolnij obiekt prezentacji po przetworzeniu. Do przetwarzania równoległego używaj oddzielnych instancji prezentacji i stosuj wytyczne dotyczące [wielowątkowości](/slides/pl/php-java/multithreading/).

**Czy mogę eksportować tylko wybrane slajdy?**

Tak. Wiele metod eksportu pozwala przekazać indeksy slajdów lub renderować poszczególne slajdy, w zależności od formatu wyjściowego. Zobacz dedykowany artykuł dla wybranego formatu.

**Czy mogę uwzględnić ukryte slajdy przy eksporcie do PDF lub XPS?**

Tak. Skorzystaj z ustawień eksportu ukrytych slajdów opisanych w artykułach o [PDF](/slides/pl/php-java/convert-powerpoint-to-pdf/) i [XPS](/slides/pl/php-java/convert-powerpoint-to-xps/).

**Czy mogę tworzyć wyjście PDF/A?**

Tak. Dostępne są ustawienia zgodności PDF dla eksportu PDF. Szczegóły znajdziesz w [Konwertuj PowerPoint do PDF](/slides/pl/php-java/convert-powerpoint-to-pdf/).

**Jak obsługiwane są czcionki podczas konwersji?**

Aspose.Slides może używać wbudowanych czcionek, mechanizmu awaryjnego oraz ustawień podstawiania czcionek. Zobacz [Wbudowane czcionki](/slides/pl/php-java/embedded-font/), [Czcionka awaryjna](/slides/pl/php-java/fallback-font/) i [Podstawianie czcionek](/slides/pl/php-java/font-substitution/).