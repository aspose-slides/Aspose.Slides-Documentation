---
title: Konwertowanie prezentacji na wiele formatów w JavaScript
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
description: "Konwertuj prezentacje PowerPoint i OpenDocument do PPTX, PDF, HTML, obrazów, XPS, TIFF i innych za pomocą Aspose.Slides dla Node.js poprzez Java."
---
## **Przegląd**

Aspose.Slides for Node.js via Java może wczytywać prezentacje PowerPoint i OpenDocument oraz zapisywać lub renderować je do wielu innych formatów bez potrzeby Microsoft PowerPoint, OpenOffice lub LibreOffice. Możesz konwertować starsze pliki PPT na nowoczesne PPTX, eksportować prezentacje do dokumentów o stałym układzie, takich jak PDF i XPS, publikować slajdy jako HTML lub renderować slajdy jako pliki graficzne do podglądów, miniatur i archiwów.

Większość konwersji dokumentów używa tego samego ogólnego przepływu pracy: wczytaj plik źródłowy, wybierz wymaganą format wyjściowy i w razie potrzeby zastosuj opcje specyficzne dla formatu. Dla formatów graficznych każdy slajd jest renderowany osobno, a następnie zapisywany jako obraz rastrowy lub wektorowy. Poniżej znajdują się dedykowane artykuły opisujące szczegóły implementacji dla każdego przypadku.

## **Wybierz scenariusz konwersji**

Użyj poniższych artykułów, aby uzyskać pełne przykłady JavaScript oraz opcje specyficzne dla formatu.

| Scenariusz | Użyj, gdy potrzebujesz | Artykuł |
| --- | --- | --- |
| PPT/PPTX/ODP do PPTX | Modernizować starsze pliki PPT, ujednolicić istniejące pliki PPTX lub przekonwertować prezentacje OpenDocument na PowerPoint PPTX. | [Konwertuj PPT do PPTX](/slides/pl/nodejs-java/convert-ppt-to-pptx/), [Konwertuj ODP do PPTX](/slides/pl/nodejs-java/convert-odp-to-pptx/), [Zapisz prezentacje](/slides/pl/nodejs-java/save-presentation/) |
| PPTX do PPT | Zapisz nowoczesną prezentację PowerPoint w starszym formacie binarnym PPT w celu zapewnienia kompatybilności ze starszymi procesami. | [Konwertuj PPTX do PPT](/slides/pl/nodejs-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP do PDF | Utwórz przenośne, przeszukiwalne dokumenty o stałym układzie do udostępniania, drukowania lub archiwizacji. | [Konwertuj PowerPoint do PDF](/slides/pl/nodejs-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP do PDF z notatkami | Eksportuj notatki prelegenta wraz z treścią slajdów. | [Konwertuj PowerPoint do PDF z notatkami](/slides/pl/nodejs-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP do HTML | Publikuj prezentacje jako strony HTML i kontroluj obrazy, czcionki, notatki oraz opcje responsywnego układu. | [Konwertuj PowerPoint do HTML](/slides/pl/nodejs-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP do HTML5 | Eksportuj slajdy do HTML5, aby umożliwić przeglądanie w przeglądarce przy zachowaniu formatowania i interaktywności. | [Konwertuj prezentacje do HTML5](/slides/pl/nodejs-java/export-to-html5/) |
| PPT/PPTX/ODP do PNG | Renderuj każdy slajd jako obraz PNG do podglądów, miniatur lub wyjścia internetowego. | [Konwertuj PowerPoint do PNG](/slides/pl/nodejs-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP do JPG | Renderuj slajdy jako obrazy JPG i kontroluj wymiary oraz jakość obrazu. | [Konwertuj PowerPoint do JPG](/slides/pl/nodejs-java/convert-powerpoint-to-jpg/) |
| Slajd do SVG | Eksportuj pojedyncze slajdy jako skalowalne grafiki wektorowe. | [Renderuj slajd jako SVG](/slides/pl/nodejs-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP do XPS | Generuj dokumenty XPS o stałym układzie. | [Konwertuj PowerPoint do XPS](/slides/pl/nodejs-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP do TIFF | Zapisz prezentację jako wielostronicowy plik TIFF do druku, skanowania, faksu lub archiwizacji. | [Konwertuj PowerPoint do TIFF](/slides/pl/nodejs-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP do TIFF z notatkami | Zapisz slajdy z notatkami prelegenta w formacie TIFF. | [Konwertuj PowerPoint do TIFF z notatkami](/slides/pl/nodejs-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX do Markdown | Wyodrębnij treść prezentacji do formatu Markdown dla dokumentacji i procesów tekstowych. | [Konwertuj PowerPoint do Markdown](/slides/pl/nodejs-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP do XML | Utwórz tekstowy PowerPoint XML Presentation do inspekcji, porównań, rozwiązywania problemów lub procesów opartych na XML. | [Konwertuj PowerPoint do XML](/slides/pl/nodejs-java/convert-powerpoint-to-xml/) |
| PPT/PPTX do animowanego GIF | Utwórz animowany GIF ze slajdów. | [Konwertuj PowerPoint do animowanego GIF](/slides/pl/nodejs-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX do wideo | Zbuduj przepływ pracy eksportu wideo z slajdów prezentacji. | [Konwertuj PowerPoint do wideo](/slides/pl/nodejs-java/convert-powerpoint-to-video/) |
| Prezentacja do XAML | Eksportuj slajdy do XAML dla scenariuszy interfejsu JavaScript lub Java. | [Eksportuj prezentacje do XAML](/slides/pl/nodejs-java/export-to-xaml/) |

Aby zobaczyć pełniejszą listę formatów wejściowych i wyjściowych, zobacz [Obsługiwane formaty plików](/slides/pl/nodejs-java/supported-file-formats/).

## **Konwersja PowerPoint i OpenDocument**

Aspose.Slides for Node.js via Java obsługuje konwersję z powszechnie używanych formatów prezentacji, takich jak PPT, PPTX, PPS, PPSX, POT, POTX i ODP. To samo API konwersji jest używane dla plików PowerPoint i OpenDocument, więc przepływ pracy, który zapisuje plik PPTX jako PDF, może zazwyczaj zostać zastosowany do pliku ODP, zmieniając jedynie plik wejściowy.

Podczas konwersji plików ODP pamiętaj, że aplikacje PowerPoint i OpenDocument nie obsługują każdego układu i elementu formatowania w dokładnie taki sam sposób. Jeśli plik ODP został utworzony w LibreOffice lub OpenOffice Impress, przejrzyj wynik i użyj opcji opisanych w [Konwertuj prezentacje OpenDocument](/slides/pl/nodejs-java/convert-openoffice-odp/) w razie potrzeby uzyskania wskazówek specyficznych dla formatu.

## **Konwersja PPT do PPTX**

PPT to starszy binarny format PowerPoint, natomiast PPTX to nowoczesny format Office Open XML. Aspose.Slides for Node.js via Java zapewnia wysoką wierność konwersji PPT do PPTX przy zachowaniu złożonych struktur prezentacji, takich jak szablony, układy, slajdy, wykresy, grupowane kształty, pola zastępcze, ramki tekstowe, tekstury i wypełnienia obrazem.

Szczegóły znajdziesz w [Konwertuj PPT do PPTX](/slides/pl/nodejs-java/convert-ppt-to-pptx/) oraz [PPT vs PPTX](/slides/pl/nodejs-java/ppt-vs-pptx/).

## **Eksport o stałym układzie**

PDF, XPS i TIFF są przydatne, gdy wynik ma wyglądać tak samo na wszystkich urządzeniach i nie powinien być edytowany jako prezentacja. Dedykowane artykuły o PDF, XPS i TIFF wyjaśniają, jak kontrolować zgodność, ukryte slajdy, notatki, jakość obrazu, kompresję, format pikseli i rozmiar wyjścia.

## **Eksport HTML i obrazów**

Eksport do HTML i HTML5 jest przydatny do przeglądania w przeglądarce, publikacji internetowej i lekkiego udostępniania. Eksport obrazów jest użyteczny, gdy każdy slajd musi stać się osobnym podglądem, miniaturą lub zasobem rastrowym. Skorzystaj z artykułów o PNG, JPG i SVG, aby uzyskać wskazówki dotyczące renderowania w zależności od formatu.

## **FAQ**

**Czy potrzebuję Microsoft PowerPoint do konwertowania prezentacji?**

Nie. Aspose.Slides for Node.js via Java jest samodzielną biblioteką i nie wymaga Microsoft PowerPoint ani automatyzacji Office.

**Czy mogę konwertować wsadowo wiele prezentacji?**

Tak. Wczytaj każdą prezentację, zapisz ją w wymaganym formacie i zwolnij obiekt prezentacji po zakończeniu przetwarzania. W przypadku przetwarzania równoległego używaj osobnych instancji prezentacji i postępuj zgodnie z wytycznymi dotyczącymi [wielowątkowości](/slides/pl/nodejs-java/multithreading/).

**Czy mogę eksportować tylko wybrane slajdy?**

Tak. Wiele metod eksportu pozwala przekazać indeksy slajdów lub renderować pojedyncze slajdy, w zależności od formatu wyjściowego. Zobacz dedykowany artykuł dla wybranego formatu.

**Czy mogę uwzględnić ukryte slajdy przy eksporcie do PDF lub XPS?**

Tak. Skorzystaj z ustawień eksportu ukrytych slajdów opisanych w artykułach o [PDF](/slides/pl/nodejs-java/convert-powerpoint-to-pdf/) i [XPS](/slides/pl/nodejs-java/convert-powerpoint-to-xps/).

**Czy mogę stworzyć wyjście PDF/A?**

Tak. Ustawienia zgodności PDF są dostępne przy eksporcie do PDF. Szczegóły znajdziesz w [Konwertuj PowerPoint do PDF](/slides/pl/nodejs-java/convert-powerpoint-to-pdf/).

**Jak obsługiwane są czcionki podczas konwersji?**

Aspose.Slides może korzystać z czcionek osadzonych, zapasowych oraz substytucji czcionek. Zobacz [Czcionka osadzona](/slides/pl/nodejs-java/embedded-font/), [Czcionka zapasowa](/slides/pl/nodejs-java/fallback-font/) oraz [Substytucja czcionek](/slides/pl/nodejs-java/font-substitution/).