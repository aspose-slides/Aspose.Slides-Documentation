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
- formatowanie
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Odkryj Aspose.Slides for Python via .NET: potężne API do tworzenia, edycji, automatyzacji oraz konwersji prezentacji PowerPoint i OpenDocument w sposób wydajny."
---
## **Obsługiwane platformy**
Platformy Aspose.Slides for Python via .NET mogą być używane w systemie Windows x64 lub x86 oraz w szerokiej gamie dystrybucji Linux z zainstalowanym Pythonem 3.5 lub nowszym. Istnieją dodatkowe wymagania dotyczące docelowej platformy Linux:

- Biblioteki runtime GCC‑6 (lub nowsze)
- Zależności środowiska uruchomieniowego .NET Core. Instalacja samego .NET Core Runtime nie jest wymagana
- Dla Pythona 3.5‑3.7: wymagana jest wersja Pythona z kompilacją `pymalloc`. Opcja budowania Pythona `--with-pymalloc` jest domyślnie włączona. Zwykle wersja `pymalloc` Pythona ma w nazwie pliku przyrostek `m`.
- Biblioteka współdzielona `libpython`. Opcja budowania Pythona `--enable-shared` jest domyślnie wyłączona, niektóre dystrybucje Pythona nie zawierają biblioteki `libpython`. Dla niektórych platform Linux bibliotekę `libpython` można zainstalować przy użyciu menedżera pakietów, np.: `sudo apt-get install libpython3.7`. Częstym problemem jest instalacja biblioteki `libpython` w innym miejscu niż standardowa lokalizacja systemowa dla bibliotek współdzielonych. Problem można rozwiązać, używając opcji budowania Pythona do ustawienia alternatywnych ścieżek do bibliotek podczas kompilacji Pythona lub tworząc dowiązanie symboliczne do pliku biblioteki `libpython` w standardowej lokalizacji systemowej. Zwykle nazwa pliku biblioteki współdzielonej `libpython` to `libpythonX.Ym.so.1.0` dla Pythona 3.5‑3.7 lub `libpythonX.Y.so.1.0` dla Pythona 3.8 i nowszych (np. `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

Jeśli potrzebujesz wsparcia dla większej liczby platform, sprawdź produkty „brat bliźniak” Aspose.Slides for .NET lub Aspose.Slides for Java.

## **Formaty plików i konwersje**
Aspose.Slides for Python via .NET obsługuje większość formatów dokumentów PowerPoint. Umożliwia również ich eksport do popularnych formatów, które organizacje szeroko używają i wymieniają ze sobą. Zapoznaj się ze szczegółami:

|**Funkcja**|**Opis**|
| :- | :- |
|[Microsoft PowerPoint (PPT)](/slides/pl/python-net/ppt-vs-pptx/)|Aspose.Slides for Python via .NET zapewnia najszybsze przetwarzanie tego formatu dokumentu prezentacji.|
|[PPT to PPTX conversion](/slides/pl/python-net/convert-ppt-to-pptx/)|Aspose.Slides for Python via .NET obsługuje konwersję PPT do PPTX.|
|[Portable Document Format (PDF)](/slides/pl/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)|Możesz wyeksportować wszystkie obsługiwane formaty plików do dokumentów Adobe Portable Document Format (PDF) za pomocą jednej metody.|
|[XML Parser Specification (XPS)](https://docs.aspose.com/slides/pl/python-net/convert-powerpoint-to-xps/)|Możesz wyeksportować wszystkie obsługiwane formaty plików do dokumentów XML Parser Specification (XPS) za pomocą jednej metody.|
|[Tagged Image File Format (TIFF)](/slides/pl/python-net/convert-powerpoint-to-tiff/)|Możesz wyeksportować wszystkie obsługiwane formaty plików prezentacji do Tagged Image File Format (TIFF).|
|[PPTX To HTML Conversion](https://docs.aspose.com/slides/pl/python-net/convert-powerpoint-to-html/)|Aspose.Slides for Python via .NET obsługuje konwersję PresentationEx do formatu HTML.|

## **Renderowanie prezentacji**
Aspose.Slides for Python via .NET obsługuje renderowanie slajdów w dokumentach prezentacji w wysokiej jakości do różnych formatów graficznych. Zapoznaj się ze szczegółami:

|**Funkcja**|**Opis**|
| :- | :- |
|.NET Supported Image Formats|Z Aspose.Slides for Python via .NET możesz renderować slajdy prezentacji i obrazy na slajdach do wszystkich formatów graficznych obsługiwanych przez .NET, takich jak TIFF, PNG, BMP, JPEG, GIF i metaplików.|
|SVG Format|Aspose.Slides for Python via .NET oferuje również wbudowane metody umożliwiające eksport slajdów prezentacji do formatu Scalable Vector Graphics (SVG).|

## **Funkcje zawartości**
Aspose.Slides for Python via .NET pozwala na dostęp, modyfikację lub tworzenie prawie wszystkich elementów lub treści dokumentów prezentacji. Zapoznaj się ze szczegółami:

|**Funkcja**|**Opis**|
| :- | :- |
|Master Slides|Slajdy master definiują układ normalnych slajdów. Aspose.Slides for Python via .NET pozwala na dostęp i modyfikację Slajdów master dokumentów prezentacji.|
|Normal Slides|Z Aspose.Slides for Python via .NET możesz tworzyć nowe slajdy różnych typów; możesz także uzyskać dostęp i modyfikować istniejące slajdy w prezentacjach.|
|Cloning / Copying Slides|Istnieją wbudowane metody udostępniane przez Aspose.Slides for Python via .NET, które pozwalają klonować lub kopiować istniejące slajdy w obrębie prezentacji. Możesz także używać skopiowanych i sklonowanych slajdów z jednej prezentacji do drugiej. Ponieważ slajd dziedziczy układ z slajdu master, wbudowane metody klonowania automatycznie kopiują master przy klonowaniu.|
|Managing Slides sections|Metody organizacji slajdów w różnych sekcjach wewnątrz prezentacji.|
|Place Holders and Text Holders|Możesz uzyskać dostęp do miejsc wstawiania i pól tekstowych w slajdzie. Ponadto możesz od podstaw stworzyć slajd z polami tekstowymi, używając odpowiedniej metody.|
|Header and Footers|Aspose.Slides for Python via .NET ułatwia obsługę nagłówków i stopek w slajdach.|
|Notes in Slides|Z Aspose.Slides for Python via .NET możesz uzyskać dostęp i modyfikować notatki powiązane ze slajdem oraz dodawać nowe notatki.|
|Finding a Shape|Możesz także znaleźć konkretny kształt na slajdzie, używając alternatywnego tekstu powiązanego z kształtem.|
|Backgrounds|Aspose.Slides for Python via .NET pozwala pracować z tłami powiązanymi ze slajdem master lub normalnym w prezentacji.|
|Text Boxes|Pola tekstowe mogą być tworzone od podstaw. Możesz uzyskać dostęp do istniejących pól tekstowych. Możesz także modyfikować ich teksty bez utraty pierwotnego formatowania tekstu.|
|Rectangle Shapes|Możesz tworzyć lub modyfikować prostokątne kształty przy użyciu Aspose.Slides for Python via .NET.|
|Poly Line Shapes|Możesz tworzyć lub modyfikować kształty linii łamanej przy użyciu Aspose.Slides for Python via .NET.|
|Ellipse Shapes|Możesz tworzyć lub modyfikować kształty elipsy przy użyciu Aspose.Slides for Python via .NET.|
|Group Shapes|Aspose.Slides for Python via .NET obsługuje grupowanie kształtów.|
|Auto Shapes|Aspose.Slides for Python via .NET obsługuje kształty automatyczne.|
|SmartArt|Aspose.Slides for Python via .NET zapewnia wsparcie dla kształtów SmartArt w MS PowerPoint.|
|Charts|Aspose.Slides for Python via .NET zapewnia wsparcie dla wykresów MSO w PowerPoint.|
|Shapes Serialization|Aspose.Slides for Python via .NET obsługuje dużą liczbę kształtów. Gdy brak wsparcia dla konkretnego kształtu, możesz użyć metody serializacji, aby zserializować ten kształt z istniejącego slajdu. Dzięki temu możesz dalej wykorzystywać kształt zgodnie z własnymi wymaganiami.|
|Picture Frames|Możesz zarządzać obrazami w ramach obrazów przy użyciu Aspose.Slides for Python via .NET.|
|Audio Frames|Możesz łączyć lub osadzać pliki audio w ramach audio na slajdach przy użyciu Aspose.Slides for Python via .NET.|
|Video Frames|Możesz obsługiwać pliki wideo w ramach wideo. Aspose.Slides for Python via .NET zapewnia także wsparcie dla połączonych i osadzonych wideo.|
|OLE Frame|Możesz zarządzać obiektami OLE w ramach OLE przy użyciu Aspose.Slides for Python via .NET.|
|Tables|Aspose.Slides for Python via .NET obsługuje tabele na slajdach.|
|ActiveX Controls|Wsparcie dla kontrolek ActiveX.|
|VBA Macros|Wsparcie dla zarządzania makrami VBA w prezentacjach.|
|Text Frame|Możesz uzyskać dostęp do tekstu dowolnego kształtu poprzez ramkę tekstową powiązaną z tym kształtem.|
|Text Scanning|Możesz skanować tekst w prezentacji na poziomie prezentacji lub slajdu przy użyciu wbudowanych metod skanowania.|
|Animations|Możesz stosować animacje na kształtach.|
|Slide Shows|Aspose.Slides for Python via .NET obsługuje pokazy slajdów oraz przejścia slajdów.|

## **Funkcje formatowania**
Za pomocą Aspose.Slides for Python via .NET możesz formatować teksty i kształty na slajdach w prezentacjach. Zapoznaj się ze szczegółami:

|**Funkcja**|**Opis**|
| :- | :- |
|Text Formatting|<p>Za pomocą Aspose.Slides for Python via .NET możesz zarządzać tekstami poprzez ramki tekstowe powiązane z kształtami. Dzięki temu możesz formatować teksty używając akapitów i fragmentów powiązanych z ramkami tekstowymi. Te elementy tekstowe można formatować przy użyciu Aspose.Slides for Python via .NET.</p><p>- Typ czcionki</p><p>- Rozmiar czcionki</p><p>- Kolor czcionki</p><p>- Odcienie czcionki</p><p>- Wyrównanie akapitu</p><p>- Wypunktowanie akapitu</p><p>- Orientacja akapitu</p>|
|Shape Formatting|<p>W Aspose.Slides for Python via .NET podstawowym elementem slajdu jest kształt. Możesz formatować te elementy kształtu przy użyciu Aspose.Slides for Python via .NET:</p><p>- Pozycja</p><p>- Rozmiar</p><p>- Linia</p><p>- Wypełnienie (w tym Wzór, Gradient, Jednolity)</p><p>- Tekst</p><p>- Obraz</p>|

## **FAQ**

### Czy muszę zainstalować Microsoft PowerPoint na serwerze/komputerze, aby biblioteka działała?
Nie. PowerPoint nie jest wymagany; Aspose.Slides to samodzielny silnik do tworzenia, edytowania, konwertowania i renderowania prezentacji.

### Jak działa wielowątkowość? Czy przetwarzanie może być równoległe?
Bezpieczne jest przetwarzanie różnych dokumentów w różnych wątkach; ten sam [presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) nie powinien być używany przez [multiple threads](/slides/pl/python-net/multithreading/) w tym samym czasie.

### Czy obsługiwane są hasła i szyfrowanie plików?
Tak. [You can](/slides/pl/python-net/password-protected-presentation/) otworzyć zaszyfrowane prezentacje, ustawić lub usunąć hasło otwierania i zapisu oraz sprawdzić status ochrony.

### Czy muszę dbać o pakiety czcionek w kontenerach Linux?
Tak. Zaleca się instalację popularnych pakietów czcionek i/lub wyraźne [specify font directories](/slides/pl/python-net/custom-font/) w aplikacji, aby uniknąć nieprzewidzianych podstawień.

### Czy istnieją ograniczenia w wersji ewaluacyjnej?
W [evaluation mode](/slides/pl/python-net/licensing/) do wyniku dodawany jest znak wodny i obowiązują pewne ograniczenia; dostępna jest [30-day temporary license](https://purchase.aspose.com/temporary-license/) umożliwiająca pełne testowanie funkcji.

### Czy importowanie zewnętrznych formatów do prezentacji (PDF/HTML → PPTX) jest obsługiwane?
Tak. Możesz dodać [PDF pages and HTML content](/slides/pl/python-net/import-presentation/) do prezentacji, przekształcając je w slajdy.