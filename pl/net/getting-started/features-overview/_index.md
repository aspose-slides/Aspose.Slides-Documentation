---
title: Przegląd funkcji
type: docs
weight: 94
url: /pl/net/features-overview/
keywords:
- funkcje
- obsługiwane platformy
- formaty plików
- konwersja
- renderowanie
- zawartość prezentacji
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Przejrzyj, co obejmuje Aspose.Slides for .NET przed jego oceną: obsługiwane platformy, formaty plików, renderowanie slajdów oraz zawartość, którą możesz tworzyć i edytować."
---
## **Przegląd**

Aspose.Slides for .NET to biblioteka klas służąca do tworzenia, odczytywania, edytowania, konwertowania i renderowania prezentacji PowerPoint oraz OpenDocument. Nie posiada własnego interfejsu użytkownika i nie wymaga Microsoft PowerPoint ani Office, dzięki czemu można jej używać w aplikacjach konsolowych, aplikacjach desktopowych takich jak Windows Forms, aplikacjach webowych oraz usługach webowych. Ten artykuł podsumowuje zakres biblioteki i odsyła do artykułów opisujących poszczególne obszary.

## **Obsługiwane platformy**

Aspose.Slides for .NET jest dystrybuowany jako dwa pakiety NuGet z tym samym API:

|**Pakiet**|**Komponenty w pakiecie**|**Systemy operacyjne**|
| :- | :- | :- |
|[Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/)|.NET Framework 4.6.2, .NET Standard 2.0 i .NET 6. Używaj z .NET Framework 4.6.2 lub nowszym, lub z .NET 6 lub nowszym.|Windows. Linux i macOS z biblioteką `libgdiplus` oraz przełącznikiem `System.Drawing.EnableUnixSupport`.|
|[Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/)|.NET 6. Używaj z .NET 6 lub nowszym.|Windows (x86, x64), Linux (x64 z glibc 2.23 lub nowszym, ARM64 z glibc 2.39 lub nowszym) i macOS (x64, ARM64).|

[Installation](/slides/pl/net/installation/) wyjaśnia, który pakiet wybrać i czego każdy z nich potrzebuje w systemie Linux. [System Requirements](/slides/pl/net/system-requirements/) wymienia szczegółowo obsługiwane platformy.

## **Formaty plików i konwersje**

Aspose.Slides otwiera i zapisuje prezentacje w formatach PPT, PPTX, PPS, POT, PPSX, POTX, PPTM, PPSM, POTM, ODP, OTP, FODP oraz PowerPoint XML. Importuje treść PDF i HTML do slajdów, a zapisuje prezentacje jako PDF, XPS, HTML, HTML5, TIFF, animowany GIF, SWF, Markdown i XAML. [Supported File Formats](/slides/pl/net/supported-file-formats/) wymienia każdy format wraz z API, które go odczytuje lub zapisuje.

|**Funkcja**|**Opis**|
| :- | :- |
|[PPT and PPTX](/slides/pl/net/ppt-vs-pptx/)|Odczytuje i zapisuje zarówno binarny format PowerPoint 97-2003, jak i format Office Open XML.|
|[PPT to PPTX conversion](/slides/pl/net/convert-ppt-to-pptx/)|Konwertuje starsze prezentacje PPT do formatu PPTX.|
|[Portable Document Format (PDF)](/slides/pl/net/convert-powerpoint-to-pdf/)|Eksportuje prezentacje do PDF, w tym dokumenty PDF/A i PDF/UA.|
|[XML Paper Specification (XPS)](/slides/pl/net/convert-powerpoint-to-xps/)|Eksportuje prezentacje do dokumentów XPS.|
|[Tagged Image File Format (TIFF)](/slides/pl/net/convert-powerpoint-to-tiff/)|Eksportuje prezentacje do obrazów TIFF.|
|[HTML](/slides/pl/net/convert-powerpoint-to-html/)|Eksportuje prezentacje do HTML i HTML5.|
|[PDF and HTML import](/slides/pl/net/import-presentation/)|Tworzy slajdy z stron PDF oraz treści HTML.|

## **Renderowanie prezentacji**

Aspose.Slides renderuje slajdy i poszczególne kształty jako obrazy PNG, JPEG, BMP, GIF, TIFF i SVG oraz slajdy jako pliki metafile EMF. Zobacz [Convert Presentation Slides to Images](/slides/pl/net/convert-slide/), [Render a Slide as an SVG Image](/slides/pl/net/render-a-slide-as-an-svg-image/) i [Create Shape Thumbnails](/slides/pl/net/create-shape-thumbnails/).

## **Funkcje zawartości**

Aspose.Slides pozwala tworzyć, odczytywać i modyfikować prawie całą zawartość prezentacji:

|**Obszar**|**Co możesz zrobić**|
| :- | :- |
|[Slides](/slides/pl/net/presentation-slide/)|Dodawaj, kopiuj, zmieniaj kolejność i usuwaj slajdy; stosuj układy i szablony; organizuj slajdy w sekcje; zmieniaj rozmiar slajdu.|
|[Design](/slides/pl/net/presentation-design/)|Ustawiaj tła, kolory motywu, nagłówki i stopki oraz czcionki.|
|[Text](/slides/pl/net/manage-text/)|Twórz i edytuj ramki tekstowe, akapity i fragmenty; ustawiaj czcionki, kolory, wypunktowanie i wyrównanie; wyszukuj i zamieniaj tekst.|
|[Shapes](/slides/pl/net/powerpoint-shapes/)|Twórz AutoShape'y, linie, łączniki, grupy kształtów i ramki obrazów; ustawiaj pozycję, rozmiar, linię oraz wypełnienie jednolite, gradientowe lub wzorcowe; znajdź kształt po jego alternatywnym tekście.|
|[Tables](/slides/pl/net/powerpoint-table/), [charts](/slides/pl/net/powerpoint-charts/), and [SmartArt](/slides/pl/net/powerpoint-smartart/)|Twórz i edytuj tabele, wykresy Microsoft Office oraz diagramy SmartArt.|
|[Media](/slides/pl/net/manage-media-files/), [OLE objects](/slides/pl/net/manage-ole/), and [ActiveX controls](/slides/pl/net/activex/)|Dodawaj osadzone lub powiązane ramki audio i wideo, osadzaj obiekty OLE oraz dodawaj, modyfikuj lub usuwaj kontrolki ActiveX.|
|[Notes](/slides/pl/net/presentation-notes/) and [comments](/slides/pl/net/presentation-comments/)|Dodawaj, odczytuj i edytuj notatki prelegenta oraz komentarze recenzji.|
|[Animation](/slides/pl/net/powerpoint-animation/) and [transitions](/slides/pl/net/slide-transition/)|Stosuj efekty animacji do kształtów, ustawiaj przejścia slajdów oraz konfigurować ustawienia pokazu slajdów.|
|[Security](/slides/pl/net/presentation-security/)|Szyfruj prezentacje hasłem, ustaw ochronę przed zapisem i pracuj z podpisami cyfrowymi.|
|[VBA macros](/slides/pl/net/presentation-via-vba/)|Dodawaj, wyodrębniaj i usuwaj moduły VBA w prezentacjach z włączonymi makrami.|
|[Properties](/slides/pl/net/presentation-properties/)|Odczytuj i edytuj właściwości dokumentu.|

## **FAQ**

**Czy muszę zainstalować Microsoft PowerPoint na serwerze lub komputerze, aby biblioteka działała?**

Nie. PowerPoint nie jest wymagany; Aspose.Slides to samodzielny silnik do tworzenia, edytowania, konwertowania i renderowania prezentacji.

**Jak działa wielowątkowość? Czy przetwarzanie może być równoległe?**

Można bezpiecznie przetwarzać różne dokumenty w różnych wątkach; ten sam obiekt [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) nie powinien być używany przez [wiele wątków](/slides/pl/net/multithreading/) jednocześnie.

**Czy obsługiwane są hasła i szyfrowanie plików?**

Tak. [Możesz](/slides/pl/net/password-protected-presentation/) otwierać zaszyfrowane prezentacje, ustawiać lub usuwać hasło otwarcia i zapisu oraz sprawdzać status ochrony.

**Czy muszę dbać o czcionki w kontenerach Linux?**

Tak. Czcionki używane w Twoich prezentacjach, lub odpowiednie ich zamienniki, muszą być zainstalowane w systemie, aby tekst renderował się prawidłowo. Możesz także [określić katalogi czcionek](/slides/pl/net/custom-font/) w swojej aplikacji. [Installation](/slides/pl/net/installation/) wymienia wymagania Linux dla każdego pakietu.

**Czy istnieją ograniczenia w wersji ewaluacyjnej?**

Tak. Bez [licencji](/slides/pl/net/licensing/) Aspose.Slides dodaje znak wodny oceny do każdego zapisanego slajdu oraz obcina tekst odczytany z prezentacji. Dostępna jest [30‑dniowa licencja tymczasowa](https://purchase.aspose.com/temporary-license/) umożliwiająca pełne testowanie funkcji.

**Czy importowanie zewnętrznych formatów do prezentacji (PDF lub HTML do PPTX) jest obsługiwane?**

Tak. Możesz dodać [strony PDF i treść HTML](/slides/pl/net/import-presentation/) do prezentacji, przekształcając je w slajdy.