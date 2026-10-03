---
title: Obsługiwane formaty plików
type: docs
weight: 106
url: /pl/java/supported-file-formats/
keywords:
- obsługiwane formaty plików
- ładowanie prezentacji
- import PDF
- import HTML
- zapisywanie prezentacji
- renderowanie slajdów
- PowerPoint
- OpenDocument
- PPT
- PPTX
- ODP
- PDF
- HTML
- XPS
- SVG
- XAML
- Java
- Aspose.Slides
description: "Zobacz, które formaty plików Aspose.Slides for Java może ładować, importować, zapisywać i renderować oraz które API odczytuje lub zapisuje każdy z nich."
---
## **Przegląd**

Aspose.Slides for Java otwiera i zapisuje prezentacje PowerPoint oraz OpenDocument. Importuje także zawartość PDF i HTML do slajdów, zapisuje prezentacje w formatach dokumentów, sieci i obrazów oraz renderuje pojedyncze slajdy i kształty jako obrazy. Ten artykuł wymienia wszystkie obsługiwane formaty i podaje nazwę interfejsu API, który je odczytuje lub zapisuje.

Aby zobaczyć przegląd funkcji edycji, zobacz [Przegląd funkcji](/slides/pl/java/features-overview/).

## **Obsługiwane wersje Microsoft PowerPoint**

- Microsoft PowerPoint 97
- Microsoft PowerPoint 2000
- Microsoft PowerPoint XP
- Microsoft PowerPoint 2003
- Microsoft PowerPoint 2007
- Microsoft PowerPoint 2010
- Microsoft PowerPoint 2013
- Microsoft PowerPoint 2016
- Microsoft PowerPoint 2019
- Microsoft PowerPoint for Mac
- PowerPoint for Microsoft 365 (formerly Office 365)

{{% alert color="info" title="Note" %}}
Prezentacje zapisane w PowerPoint 95 i wcześniejszych wersjach nie mogą być otwarte. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) rozpoznaje plik PowerPoint 95 i zgłasza `LoadFormat.Ppt95`, ale konstruktor [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) zgłasza [PptUnsupportedFormatException](https://reference.aspose.com/slides/pl/java/com.aspose.slides/pptunsupportedformatexception/) dla takiego pliku.
{{% /alert %}}

## **Obsługiwane formaty plików**

Tabela wykorzystuje cztery operacje:

- **Ładowanie**: konstruktor [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) otwiera plik jako edytowalną prezentację.
- **Importowanie**: metoda [SlideCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slidecollection/) tworzy slajdy z zawartości pliku i dodaje je do istniejącej prezentacji. Konstruktor Presentation nie konwertuje tych plików na slajdy.
- **Zapisywanie**: [Presentation.save](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#save-java.lang.String-int-) zapisuje prezentację do pliku lub strumienia. Każdy format oprócz XAML jest wybierany przy pomocy wartości [SaveFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/saveformat/).
- **Renderowanie**: metoda renderująca rysuje slajd lub kształt jako obraz. Formatami, które są tylko renderowane, nie są wartościami SaveFormat.

|**Format**|**Opis**|**Ładowanie / Import**|**Zapisywanie / Renderowanie**|**API**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|Prezentacja PowerPoint 97‑2003|Ładowanie|Zapisywanie|`LoadFormat.Ppt`, `SaveFormat.Ppt`|
|[POT](https://docs.fileformat.com/presentation/pot/)|Szablon PowerPoint 97‑2003|Ładowanie|Zapisywanie|`LoadFormat.Pot`, `SaveFormat.Pot`|
|[PPS](https://docs.fileformat.com/presentation/pps/)|Pokaz slajdów PowerPoint 97‑2003|Ładowanie|Zapisywanie|`LoadFormat.Pps`, `SaveFormat.Pps`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|Prezentacja PowerPoint|Ładowanie|Zapisywanie|`LoadFormat.Pptx`, `SaveFormat.Pptx`|
|[POTX](https://docs.fileformat.com/presentation/potx/)|Szablon PowerPoint|Ładowanie|Zapisywanie|`LoadFormat.Potx`, `SaveFormat.Potx`|
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|Pokaz slajdów PowerPoint|Ładowanie|Zapisywanie|`LoadFormat.Ppsx`, `SaveFormat.Ppsx`|
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|Prezentacja PowerPoint z obsługą makr|Ładowanie|Zapisywanie|`LoadFormat.Pptm`, `SaveFormat.Pptm`|
|[POTM](https://docs.fileformat.com/presentation/potm/)|Szablon PowerPoint z obsługą makr|Ładowanie|Zapisywanie|`LoadFormat.Potm`, `SaveFormat.Potm`|
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|Pokaz slajdów PowerPoint z obsługą makr|Ładowanie|Zapisywanie|`LoadFormat.Ppsm`, `SaveFormat.Ppsm`|
|[ODP](https://docs.fileformat.com/presentation/odp/)|Prezentacja OpenDocument|Ładowanie|Zapisywanie|`LoadFormat.Odp`, `SaveFormat.Odp`|
|FODP|Prezentacja Flat XML OpenDocument|Ładowanie|Zapisywanie|`LoadFormat.Fodp`, `SaveFormat.Fodp`|
|[OTP](https://docs.fileformat.com/presentation/otp/)|Szablon prezentacji OpenDocument|Ładowanie|Zapisywanie|`LoadFormat.Otp`, `SaveFormat.Otp`|
|[XML](https://docs.fileformat.com/web/xml/)|Prezentacja PowerPoint XML|Ładowanie|Zapisywanie|`SaveFormat.Xml`; wczytane pliki zgłaszają `SourceFormat.Xml` (brak wartości `LoadFormat`)|
|[PDF](https://docs.fileformat.com/pdf/)|Portable Document Format|Importowanie|Zapisywanie|`SlideCollection.addFromPdf`; `SaveFormat.Pdf`|
|[HTML](https://docs.fileformat.com/web/html/)|Hypertext Markup Language|Importowanie|Zapisywanie|`SlideCollection.addFromHtml`, `SlideCollection.insertFromHtml`; `SaveFormat.Html`, `SaveFormat.Html5`|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML Paper Specification|—|Zapisywanie|`SaveFormat.Xps`|
|[TIFF](https://docs.fileformat.com/image/tiff/)|Tagged Image File Format|—|Zapisywanie, Renderowanie|`SaveFormat.Tiff` (jedna strona na slajd); `ImageFormat.Tiff` (jeden slajd)|
|[GIF](https://docs.fileformat.com/image/gif/)|Graphics Interchange Format|—|Zapisywanie, Renderowanie|`SaveFormat.Gif` (animowany, wszystkie slajdy); `ImageFormat.Gif` (jeden slajd)|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Small Web Format (Flash)|—|Zapisywanie|`SaveFormat.Swf`|
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown|—|Zapisywanie|`SaveFormat.Md`|
|[XAML](https://docs.fileformat.com/web/xaml/)|Extensible Application Markup Language|—|Zapisywanie|`Presentation.save(IXamlOptions)`, jeden plik XAML na slajd; brak wartości `SaveFormat`|
|[PNG](https://docs.fileformat.com/image/png/)|Portable Network Graphics|—|Renderowanie|`ImageFormat.Png`|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|JPEG Image|—|Renderowanie|`ImageFormat.Jpeg`|
|[BMP](https://docs.fileformat.com/image/bmp/)|Bitmap Image|—|Renderowanie|`ImageFormat.Bmp`|
|[EMF](https://docs.fileformat.com/image/emf/)|Enhanced Metafile|—|Renderowanie|`Slide.writeAsEmf`|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Scalable Vector Graphics|—|Renderowanie|`Slide.writeAsSvg`, `Shape.writeAsSvg`|

## **Ładowanie i importowanie**

- **Ładowanie:** Przekaż ścieżkę do pliku lub strumień konstruktorowi [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#Presentation-java.lang.String-). Format jest wykrywany z zawartości; [LoadOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/loadoptions/) dostarcza ustawienia, np. hasło. Aby sprawdzić plik przed otwarciem, wywołaj [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-), który zgłasza wartość [LoadFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/loadformat/). Zwraca `LoadFormat.Unknown` dla PowerPoint XML, ale konstruktor otwiera taki plik, a [Presentation.getSourceFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#getSourceFormat--) zwraca `SourceFormat.Xml`. Zobacz [Open Presentations](/slides/pl/java/open-presentation/) i [Determine the Original Presentation Format](/slides/pl/java/detect-presentation-source-format/).
- **Importowanie:** [SlideCollection.addFromPdf](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) dodaje jeden slajd na każdą stronę PDF na koniec prezentacji. [SlideCollection.addFromHtml](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slidecollection/#addFromHtml-java.lang.String-) dodaje slajdy utworzone z HTML, a [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slidecollection/#insertFromHtml-int-java.lang.String-) wstawia je w podanej pozycji. Konstruktor Presentation nie importuje: zgłasza [PptUnsupportedFormatException](https://reference.aspose.com/slides/pl/java/com.aspose.slides/pptunsupportedformatexception/) dla pliku PDF i nie konwertuje znaczników HTML na zawartość slajdów. Zobacz [Import Presentations from PDF or HTML](/slides/pl/java/import-presentation/).

## **Zapisywanie i renderowanie**

- **Zapisywanie:** [Presentation.save](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#save-java.lang.String-int-) zapisuje prezentację w formacie określonym wartością [SaveFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/saveformat/). Przeciążenia przyjmujące obiekt opcji kontrolują wyjście, np. [PdfOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/htmloptions/), [Html5Options](https://reference.aspose.com/slides/pl/java/com.aspose.slides/html5options/), [TiffOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/tiffoptions/), oraz [GifOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/gifoptions/). Przeciążenia przyjmujące tablicę pozycji slajdów (licząc od 1) zapisują tylko wybrane slajdy; obsługują PDF, XPS, TIFF, HTML, HTML5, SWF, GIF i Markdown, ale nie formaty prezentacji ani PowerPoint XML. XAML ma własne przeciążenie, [Presentation.save](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-), które przyjmuje [IXamlOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ixamloptions/). Zobacz [Save Presentations](/slides/pl/java/save-presentation/), [Convert Presentations](/slides/pl/java/convert-presentation/), i [Export Presentations to XAML](/slides/pl/java/export-to-xaml/).
- **Renderowanie:** [Slide.getImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slide/#getImage-float-float-) i [Shape.getImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/shape/#getImage--) zwracają [IImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimage/), a [IImage.save](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimage/#save-java.lang.String-int-) zapisuje go jako PNG, JPEG, BMP, GIF lub TIFF, wybierany wartością [ImageFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imageformat/). [Presentation.getImages](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) renderuje wszystkie lub wybrane slajdy jednocześnie. [Slide.writeAsSvg](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slide/#writeAsSvg-java.io.OutputStream-) i [Shape.writeAsSvg](https://reference.aspose.com/slides/pl/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-) zapisują SVG, a [Slide.writeAsEmf](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slide/#writeAsEmf-java.io.OutputStream-) zapisuje EMF. Zobacz [Convert Presentation Slides to Images](/slides/pl/java/convert-slide/) i [Render Presentation Slides as SVG Images](/slides/pl/java/render-a-slide-as-an-svg-image/).

{{% alert color="warning" title="Warning" %}}
ImageFormat posiada także wartości `Emf`, `Wmf`, `Icon`, `Exif` i `MemoryBmp`, ale IImage.save nie generuje tych formatów: zapisany plik zawiera dane PNG. Aby uzyskać obraz EMF slajdu, użyj Slide.writeAsEmf.
{{% /alert %}}

## **FAQ**

**Czy mogę przekonwertować prezentację PPT na PPTX lub ODP?**

Tak. Otwórz plik PPT przy użyciu konstruktora Presentation i zapisz go z użyciem `SaveFormat.Pptx` lub `SaveFormat.Odp`. Zobacz [Convert PPT to PPTX](/slides/pl/java/convert-ppt-to-pptx/).

**Czy mogę otworzyć plik PDF lub HTML jako prezentację?**

Nie. Konstruktor Presentation zgłasza PptUnsupportedFormatException dla pliku PDF i nie konwertuje znaczników HTML na slajdy. Utwórz lub otwórz prezentację, zaimportuj strony PDF lub zawartość HTML przy pomocy metod kolekcji slajdów opisanych powyżej, a następnie zapisz w dowolnym obsługiwanym formacie.

**Czy mogę wczytać wyeksportowany obraz PNG lub SVG jako edytowalną prezentację?**

Nie. Wyjściowy obraz zapisuje jedynie wygląd slajdu, nie jego tekst, kształty ani wykresy. Zachowaj oryginalną prezentację, jeśli zamierzasz ją później edytować.

**Czy mogę zapisać dokumenty PDF/A lub PDF/UA?**

Tak. Przekaż wartość [PdfCompliance](https://reference.aspose.com/slides/pl/java/com.aspose.slides/pdfcompliance/) do [PdfOptions.setCompliance](https://reference.aspose.com/slides/pl/java/com.aspose.slides/pdfoptions/#setCompliance-int-): PDF/A-1a, PDF/A-1b, PDF/A-2a, PDF/A-2b, PDF/A-2u, PDF/A-3a, PDF/A-3b lub PDF/UA.

**Czy mogę sprawdzić, czy plik jest zabezpieczony hasłem przed jego otwarciem?**

Tak. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) analizuje plik bez tworzenia obiektu Presentation, a [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) informuje, czy wymagane jest hasło. Zobacz [Password-Protect Presentations](/slides/pl/java/password-protected-presentation/).