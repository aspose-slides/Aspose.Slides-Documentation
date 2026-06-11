---
title: Przegląd funkcji
type: docs
weight: 20
url: /pl/python-net/features-overview/
keywords:
- funkcje
- obsługiwane platformy
- format pliku
- konwersja
- renderowanie
- drukowanie
- formatowanie
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Poznaj Aspose.Slides for Python via .NET: potężne API do tworzenia, edytowania, automatyzacji i efektywnej konwersji prezentacji PowerPoint oraz OpenDocument."
---
## **Obsługiwane platformy**
Platformy, na których można używać Aspose.Slides for Python via .NET, to Windows x64 lub x86 oraz szeroki zakres dystrybucji Linux z zainstalowanym Pythonem 3.5 lub nowszym. Dodatkowe wymagania dla docelowej platformy Linux:
- Biblioteki czasu wykonania GCC‑6 (lub nowsze)
- Zależności środowiska uruchomieniowego .NET Core. Instalacja samego środowiska .NET Core Runtime NIE jest wymagana
- Dla Pythona 3.5‑3.7: potrzebna jest wersja `pymalloc` Pythona. Opcja budowania Pythona `--with-pymalloc` jest domyślnie włączona. Zazwyczaj wersja `pymalloc` Pythona ma w nazwie pliku sufiks `m`.
- Udostępniona biblioteka `libpython`. Opcja budowania Pythona `--enable-shared` jest domyślnie wyłączona, niektóre dystrybucje Pythona nie zawierają udostępnionej biblioteki `libpython`. Dla niektórych platform Linux bibliotekę `libpython` można zainstalować przy pomocy menedżera pakietów, np.: `sudo apt-get install libpython3.7`. Częstym problemem jest instalacja biblioteki `libpython` w innym miejscu niż standardowa lokalizacja systemowa dla bibliotek współdzielonych. Problem można rozwiązać, używając opcji budowania Pythona do ustawienia alternatywnych ścieżek bibliotek lub tworząc dowiązanie symboliczne do pliku biblioteki `libpython` w standardowej lokalizacji systemowej. Zazwyczaj nazwa pliku udostępnionej biblioteki `libpython` to `libpythonX.Ym.so.1.0` dla Pythona 3.5‑3.7 lub `libpythonX.Y.so.1.0` dla Pythona 3.8 i nowszych (np.: `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

Jeśli potrzebujesz wsparcia dla większej liczby platform, poszukaj produktów „siostrzanych”, takich jak Aspose.Slides for .NET lub Aspose.Slides for Java.

## **Formaty plików i konwersje**
Aspose.Slides for Python via .NET obsługuje większość formatów dokumentów PowerPoint. Umożliwia także ich eksport do popularnych formatów szeroko używanych i wymienianych przez organizacje. Zapoznaj się ze szczegółami:

|**Funkcja**|**Opis**|
| :- | :- |
|[Microsoft PowerPoint (PPT)](/slides/pl/python-net/ppt-vs-pptx/)|Aspose.Slides for Python via .NET zapewnia najszybsze przetwarzanie tego formatu prezentacji.|
|[PPT to PPTX conversion](/slides/pl/python-net/convert-ppt-to-pptx/)|Aspose.Slides for Python via .NET obsługuje konwersję PPT do PPTX.|
|[Portable Document Format (PDF)](/slides/pl/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)|Możesz wyeksportować wszystkie obsługiwane formaty plików do dokumentów Adobe Portable Document Format (PDF) jednym wywołaniem metody.|
|[XML Parser Specification (XPS)](https://docs.aspose.com/slides/pl/python-net/convert-powerpoint-to-xps/)|Możesz wyeksportować wszystkie obsługiwane formaty plików do dokumentów XML Parser Specification (XPS) jednym wywołaniem metody.|
|[Tagged Image File Format (TIFF)](/slides/pl/python-net/convert-powerpoint-to-tiff/)|Możesz wyeksportować wszystkie obsługiwane formaty prezentacji do Tagged Image File Format (TIFF).|
|[PPTX To HTML Conversion](https://docs.aspose.com/slides/pl/python-net/convert-powerpoint-to-html/)|Aspose.Slides for Python via .NET obsługuje konwersję PresentationEx do formatu HTML.|

## **Renderowanie i drukowanie**
Aspose.Slides for Python via .NET obsługuje renderowanie slajdów w dokumentach prezentacji o wysokiej wierności do różnych formatów graficznych. Zapoznaj się ze szczegółami:

|**Funkcja**|**Opis**|
| :- | :- |
|.NET Supported Image Formats|Z Aspose.Slides for Python via .NET możesz renderować slajdy prezentacji i obrazy na slajdach do wszystkich formatów graficznych obsługiwanych przez .NET, takich jak TIFF, PNG, BMP, JPEG, GIF oraz metafile.|
|SVG Format|Aspose.Slides for Python via .NET zapewnia wbudowane metody umożliwiające eksportowanie slajdów prezentacji do formatu Scalable Vector Graphics (SVG).|
|Presentation Printing|Najnowsze wersje Aspose.Slides for Python via .NET oferują wbudowane metody drukowania z różnymi opcjami.|

## **Funkcje zawartości**
Aspose.Slides for Python via .NET umożliwia dostęp, modyfikację lub tworzenie prawie wszystkich elementów i treści dokumentów prezentacji. Zapoznaj się ze szczegółami:

|**Funkcja**|**Opis**|
| :- | :- |
|Master Slides|Master Slides określają układ zwykłych slajdów. Aspose.Slides for Python via .NET pozwala na dostęp i modyfikację Master Slides w dokumentach prezentacji.|
|Normal Slides|Z Aspose.Slides for Python via .NET możesz tworzyć nowe slajdy różnych typów; możesz także uzyskać dostęp i modyfikować istniejące slajdy w prezentacjach.|
|Cloning / Copying Slides|Aspose.Slides for Python via .NET udostępnia wbudowane metody umożliwiające klonowanie lub kopiowanie istniejących slajdów w obrębie prezentacji. Możesz także używać skopiowanych i sklonowanych slajdów z jednej prezentacji w drugiej. Ponieważ slajd odzyskuje układ z master slajdu, wbudowane metody klonowania automatycznie kopiują master przy klonowaniu.|
|Managing Slides sections|Metody organizujące slajdy w różne sekcje wewnątrz prezentacji.|
|Place Holders and Text Holders|Możesz uzyskać dostęp do placeholderów i text holderów w slajdzie. Ponadto możesz od podstaw utworzyć slajd z text holderami, używając odpowiedniej metody.|
|Header and Footers|Aspose.Slides for Python via .NET ułatwia obsługę nagłówków i stopek w slajdach.|
|Notes in Slides|Z Aspose.Slides for Python via .NET możesz uzyskać dostęp i modyfikować notatki powiązane ze slajdem oraz dodawać nowe notatki.|
|Finding a Shape|Możesz także znaleźć określony kształt na slajdzie, używając tekstu alternatywnego powiązanego z tym kształtem.|
|Backgrounds|Aspose.Slides for Python via .NET pozwala pracować z tłami powiązanymi z master lub zwykłym slajdem w prezentacji.|
|Text Boxes|Pudełka tekstowe można tworzyć od podstaw. Możesz uzyskać dostęp do istniejących pudełek tekstowych. Możesz także modyfikować ich teksty bez utraty oryginalnego formatowania.|
|Rectangle Shapes|Możesz tworzyć lub modyfikować prostokątne kształty przy użyciu Aspose.Slides for Python via .NET.|
|Poly Line Shapes|Możesz tworzyć lub modyfikować kształty linii łamanej przy użyciu Aspose.Slides for Python via .NET.|
|Ellipse Shapes|Możesz tworzyć lub modyfikować elipsy przy użyciu Aspose.Slides for Python via .NET.|
|Group Shapes|Aspose.Slides for Python via .NET obsługuje grupowanie kształtów|
|Auto Shapes|Aspose.Slides for Python via .NET obsługuje kształty automatyczne|
|SmartArt|Aspose.Slides for Python via .NET zapewnia obsługę kształtów SmartArt w MS PowerPoint|
|Charts|Aspose.Slides for Python via .NET zapewnia obsługę wykresów MSO w PowerPoint|
|Shapes Serialization|Aspose.Slides for Python via .NET obsługuje dużą liczbę kształtów. Gdy brak wsparcia dla konkretnego kształtu, możesz użyć metody serializacji, aby wyeksportować ten kształt z istniejącego slajdu i później wykorzystać go według własnych potrzeb.|
|Picture Frames|Możesz zarządzać obrazami w ramkach obrazu przy użyciu Aspose.Slides for Python via .NET.|
|Audio Frames|Możesz łączyć lub osadzać pliki audio w ramkach audio na slajdach przy użyciu Aspose.Slides for Python via .NET.|
|Video Frames|Możesz obsługiwać pliki wideo w ramkach wideo. Aspose.Slides for Python via .NET zapewnia także wsparcie dla wideo powiązanego i osadzonego.|
|OLE Frame|Możesz zarządzać obiektami OLE w ramkach OLE przy użyciu Aspose.Slides for Python via .NET.|
|Tables|Aspose.Slides for Python via .NET obsługuje tabele na slajdach.|
|ActiveX Controls|Obsługa kontrolek ActiveX|
|VBA Macros|Obsługa zarządzania makrami VBA wewnątrz prezentacji.|
|Text Frame|Możesz uzyskać dostęp do tekstu dowolnego kształtu poprzez powiązany z nim text frame.|
|Text Scanning|Możesz skanować tekst w prezentacji na poziomie prezentacji lub slajdu przy użyciu wbudowanych metod skanowania.|
|Animations|Możesz stosować animacje na kształtach.|
|Slide Shows|Aspose.Slides for Python via .NET obsługuje pokazy slajdów i przejścia między slajdami.|

## **Funkcje formatowania**
Z Aspose.Slides for Python via .NET możesz formatować teksty i kształty na slajdach w prezentacjach. Zapoznaj się ze szczegółami:

|**Funkcja**|**Opis**|
| :- | :- |
|Text Formatting|<p>W Aspose.Slides for Python via .NET możesz zarządzać tekstami poprzez text frames powiązane z kształtami. Dzięki temu możesz formatować teksty używając akapitów i fragmentów powiązanych z text frames. Te elementy tekstowe można formatować przy pomocy Aspose.Slides for Python via .NET.</p><p>- Typ czcionki</p><p>- Rozmiar czcionki</p><p>- Kolor czcionki</p><p>- Odcienie czcionki</p><p>- Wyrównanie akapitu</p><p>- Wypunktowanie akapitu</p><p>- Orientacja akapitu</p>|
|Shape Formatting|<p>W Aspose.Slides for Python via .NET podstawowym elementem slajdu jest kształt. Możesz formatować te elementy kształtów przy użyciu Aspose.Slides for Python via .NET:</p><p>- Pozycja</p><p>- Rozmiar</p><p>- Linia</p><p>- Wypełnienie (w tym wzór, gradient, jednolite)</p><p>- Tekst</p><p>- Obraz</p>|

## **FAQ**

**Czy muszę instalować Microsoft PowerPoint na serwerze/komputerze, aby biblioteka działała?**

Nie. PowerPoint nie jest wymagany; Aspose.Slides jest samodzielnym silnikiem do tworzenia, edycji, konwersji i renderowania prezentacji.

**Jak działa wielowątkowość? Czy przetwarzanie może być równoległe?**

Bezpieczne jest przetwarzanie różnych dokumentów w różnych wątkach; ten sam [presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) nie powinien być używany przez [multiple threads](/slides/pl/python-net/multithreading/) jednocześnie.

**Czy obsługiwane są hasła i szyfrowanie plików?**

Tak. [You can](/slides/pl/python-net/password-protected-presentation/) otwierać zaszyfrowane prezentacje, ustawiać lub usuwać hasło otwierające i zapisu oraz sprawdzać stan ochrony.

**Czy muszę martwić się o pakiety czcionek w kontenerach Linux?**

Tak. Zaleca się instalację popularnych pakietów czcionek i/lub wyraźne [specify font directories](/slides/pl/python-net/custom-font/) w aplikacji, aby uniknąć nieoczekiwanych podstawień.

**Czy istnieją ograniczenia wersji ewaluacyjnej?**

W [evaluation mode](/slides/pl/python-net/licensing/) do wyjścia dodawany jest znak wodny i obowiązują pewne ograniczenia; dostępna jest [30‑day temporary license](https://purchase.aspose.com/temporary-license/) umożliwiająca testowanie wszystkich funkcji.

**Czy importowanie zewnętrznych formatów do prezentacji (PDF/HTML → PPTX) jest obsługiwane?**

Tak. Możesz dodać [PDF pages and HTML content](/slides/pl/python-net/import-presentation/) do prezentacji, zamieniając je w slajdy.