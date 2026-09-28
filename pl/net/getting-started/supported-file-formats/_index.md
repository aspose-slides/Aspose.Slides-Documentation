---
title: Obsługiwane formaty plików
type: docs
weight: 96
url: /pl/net/supported-file-formats/
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
- .NET
- C#
- Aspose.Slides
description: "Zobacz, które formaty plików Aspose.Slides dla .NET może ładować, importować, zapisywać i renderować, oraz które API odczytuje lub zapisuje każdy z nich."
---
## **Przegląd**

Aspose.Slides for .NET otwiera i zapisuje prezentacje PowerPoint oraz OpenDocument. Importuje również treści PDF i HTML do slajdów, zapisuje prezentacje w formatach dokumentu, sieci i obrazu oraz renderuje pojedyncze slajdy i kształty jako obrazy. Ten artykuł wymienia każdy obsługiwany format i podaje nazwę interfejsu API, który go odczytuje lub zapisuje.

Oba pakiety NuGet, Aspose.Slides.NET i Aspose.Slides.NET6.CrossPlatform, obsługują te same formaty; zobacz [Installation](/slides/pl/net/installation/), aby wybrać pomiędzy nimi. Aby uzyskać przegląd funkcji edycji, zobacz [Features Overview](/slides/pl/net/features-overview/).

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
- PowerPoint dla Microsoft 365 (dawniej Office 365)

{{% alert color="info" title="Note" %}}

Prezentacje zapisane w PowerPoint 95 i wcześniejszych wersjach nie mogą być otwarte. [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) rozpoznaje plik PowerPoint 95 i zgłasza `LoadFormat.Ppt95`, ale konstruktor [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) rzuca [PptUnsupportedFormatException](https://reference.aspose.com/slides/net/aspose.slides/pptunsupportedformatexception/) dla takiego pliku.

{{% /alert %}}

## **Obsługiwane formaty plików**

Ta tabela używa czterech operacji:

- **Load**: konstruktor [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) otwiera plik jako edytowalną prezentację.
- **Import**: metoda [SlideCollection](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) tworzy slajdy z zawartości pliku i dodaje je do istniejącej prezentacji. Konstruktor Presentation nie ładuje tych plików jako prezentacji.
- **Save**: [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) zapisuje prezentację do pliku lub strumienia. Każdy format oprócz XAML jest wybierany za pomocą wartości [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/).
- **Render**: metoda renderująca rysuje slajd lub kształt jako obraz. Formaty które są jedynie renderowane nie są wartościami SaveFormat.

|**Format**|**Opis**|**Load / Import**|**Save / Render**|**API**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|Prezentacja PowerPoint 97-2003|Load|Save|`LoadFormat.Ppt`, `SaveFormat.Ppt`|
|[POT](https://docs.fileformat.com/presentation/pot/)|Szablon PowerPoint 97-2003|Load|Save|`LoadFormat.Pot`, `SaveFormat.Pot`|
|[PPS](https://docs.fileformat.com/presentation/pps/)|Pokaz slajdów PowerPoint 97-2003|Load|Save|`LoadFormat.Pps`, `SaveFormat.Pps`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|Prezentacja PowerPoint|Load|Save|`LoadFormat.Pptx`, `SaveFormat.Pptx`|
|[POTX](https://docs.fileformat.com/presentation/potx/)|Szablon PowerPoint|Load|Save|`LoadFormat.Potx`, `SaveFormat.Potx`|
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|Pokaz slajdów PowerPoint|Load|Save|`LoadFormat.Ppsx`, `SaveFormat.Ppsx`|
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|Prezentacja PowerPoint z obsługą makr|Load|Save|`LoadFormat.Pptm`, `SaveFormat.Pptm`|
|[POTM](https://docs.fileformat.com/presentation/potm/)|Szablon PowerPoint z obsługą makr|Load|Save|`LoadFormat.Potm`, `SaveFormat.Potm`|
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|Pokaz slajdów PowerPoint z obsługą makr|Load|Save|`LoadFormat.Ppsm`, `SaveFormat.Ppsm`|
|[ODP](https://docs.fileformat.com/presentation/odp/)|Prezentacja OpenDocument|Load|Save|`LoadFormat.Odp`, `SaveFormat.Odp`|
|FODP|Prezentacja Flat XML OpenDocument|Load|Save|`LoadFormat.Fodp`, `SaveFormat.Fodp`|
|[OTP](https://docs.fileformat.com/presentation/otp/)|Szablon prezentacji OpenDocument|Load|Save|`LoadFormat.Otp`, `SaveFormat.Otp`|
|[XML](https://docs.fileformat.com/web/xml/)|Prezentacja PowerPoint XML|Load|Save|`SaveFormat.Xml`; loaded files report `SourceFormat.Xml` (there is no `LoadFormat` value)|
|[PDF](https://docs.fileformat.com/pdf/)|Format dokumentu przenośnego|Import|Save|`SlideCollection.AddFromPdf`; `SaveFormat.Pdf`|
|[HTML](https://docs.fileformat.com/web/html/)|Język znaczników hipertekstowych|Import|Save|`SlideCollection.AddFromHtml`, `SlideCollection.InsertFromHtml`; `SaveFormat.Html`, `SaveFormat.Html5`|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|Specyfikacja papieru XML|—|Save|`SaveFormat.Xps`|
|[TIFF](https://docs.fileformat.com/image/tiff/)|Format pliku obrazu TIFF|—|Save, Render|`SaveFormat.Tiff`; `ImageFormat.Tiff` (one slide)|
|[GIF](https://docs.fileformat.com/image/gif/)|Format wymiany grafiki|—|Save, Render|`SaveFormat.Gif` (animated, all slides); `ImageFormat.Gif` (one slide)|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Mały format internetowy (Flash)|—|Save|`SaveFormat.Swf`|
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown|—|Save|`SaveFormat.Md`|
|[XAML](https://docs.fileformat.com/web/xaml/)|Rozszerzalny język znaczników aplikacji|—|Save|`Presentation.Save(IXamlOptions)`, one XAML file per slide; not a `SaveFormat` value|
|[PNG](https://docs.fileformat.com/image/png/)|Przenośna grafika sieciowa|—|Render|`ImageFormat.Png`|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|Obraz JPEG|—|Render|`ImageFormat.Jpeg`|
|[BMP](https://docs.fileformat.com/image/bmp/)|Obraz bitmapowy|—|Render|`ImageFormat.Bmp`|
|[EMF](https://docs.fileformat.com/image/emf/)|Ulepszony metafile|—|Render|`Slide.WriteAsEmf`|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Skalowalna grafika wektorowa|—|Render|`Slide.WriteAsSvg`, `Shape.WriteAsSvg`|

## **Ładowanie i importowanie**

- **Load:** Przekaż ścieżkę do pliku lub strumień do konstruktora [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/). Format jest wykrywany z zawartości; [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) umożliwia podanie ustawień, takich jak hasło. Aby sprawdzić plik przed jego otwarciem, wywołaj [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/), który zwraca wartość [LoadFormat](https://reference.aspose.com/slides/net/aspose.slides/loadformat/). Zwraca `LoadFormat.Unknown` dla PowerPoint XML, ale konstruktor otwiera taki plik, a [Presentation.SourceFormat](https://reference.aspose.com/slides/net/aspose.slides/presentation/sourceformat/) wtedy zwraca `SourceFormat.Xml`. Zobacz [Open Presentations](/slides/pl/net/open-presentation/) i [Determine the Original Presentation Format](/slides/pl/net/detect-presentation-source-format/).
- **Import:** [SlideCollection.AddFromPdf](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addfrompdf/) dodaje jedną slajd na stronę PDF na koniec prezentacji. [SlideCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addfromhtml/) dodaje slajdy utworzone z HTML, a [SlideCollection.InsertFromHtml](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/insertfromhtml/) wstawia je w podanej pozycji. Konstruktor Presentation nie importuje: rzuca [PptUnsupportedFormatException](https://reference.aspose.com/slides/net/aspose.slides/pptunsupportedformatexception/) dla pliku PDF i nie konwertuje znaczników HTML na zawartość slajdu. Zobacz [Import Presentations from PDF or HTML](/slides/pl/net/import-presentation/).

## **Zapisywanie i renderowanie**

- **Save:** [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) zapisuje prezentację w formacie określonym przez wartość [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/). Przeciążenia przyjmujące obiekt opcji kontrolują wyjście, np. [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/), [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/), [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/), i [GifOptions](https://reference.aspose.com/slides/net/aspose.slides.export/gifoptions/). Przeciążenia przyjmujące tablicę pozycji slajdów (rozpoczynając od 1) zapisują tylko te slajdy; obsługują PDF, XPS, TIFF, HTML, HTML5, SWF, GIF i Markdown, ale nie formaty prezentacji ani PowerPoint XML. XAML ma własne przeciążenie przyjmujące [IXamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions/). Zobacz [Save Presentations](/slides/pl/net/save-presentation/), [Convert Presentations](/slides/pl/net/convert-presentation/), i [Export Presentations to XAML](/slides/pl/net/export-to-xaml/).
- **Render:** [Slide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/) i [Shape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) zwracają [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/), a [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) zapisuje go jako PNG, JPEG, BMP, GIF lub TIFF, wybrany przy pomocy wartości [ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/). [Presentation.GetImages](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages/) renderuje wszystkie slajdy lub wybrane slajdy jednocześnie. [Slide.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/slide/writeassvg/) i [Shape.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) zapisują SVG, a [Slide.WriteAsEmf](https://reference.aspose.com/slides/net/aspose.slides/slide/writeasemf/) zapisuje EMF. Zobacz [Convert Presentation Slides to Images](/slides/pl/net/convert-slide/) i [Render a Slide as an SVG Image](/slides/pl/net/render-a-slide-as-an-svg-image/).

{{% alert color="warning" title="Warning" %}}

ImageFormat posiada także wartości `Emf`, `Wmf`, `Icon`, `Exif` i `MemoryBmp`, ale IImage.Save nie generuje tych formatów: zapisany plik zawiera dane PNG. Aby uzyskać obraz EMF slajdu, użyj Slide.WriteAsEmf.

{{% /alert %}}

## **FAQ**

**Czy mogę przekonwertować prezentację PPT na PPTX lub ODP?**

Tak. Otwórz plik PPT przy użyciu konstruktora Presentation i zapisz go przy użyciu `SaveFormat.Pptx` lub `SaveFormat.Odp`. Zobacz [Convert PPT to PPTX](/slides/pl/net/convert-ppt-to-pptx/).

**Czy mogę otworzyć plik PDF lub HTML jako prezentację?**

Nie. Utwórz lub otwórz prezentację, zaimportuj strony PDF lub treść HTML przy użyciu metod kolekcji slajdów opisanych powyżej, a następnie zapisz ją w dowolnym obsługiwanym formacie.

**Czy mogę wczytać wyeksportowany obraz PNG lub SVG jako edytowalną prezentację?**

Nie. Eksport obrazu odzwierciedla wygląd slajdu, a nie jego tekst, kształty ani wykresy. Zachowaj oryginalną prezentację, jeśli potrzebujesz później edytować.

**Czy mogę zapisać dokumenty PDF/A lub PDF/UA?**

Tak. Ustaw [PdfOptions.Compliance](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/compliance/) na wartość [PdfCompliance](https://reference.aspose.com/slides/net/aspose.slides.export/pdfcompliance/), np.: PDF/A-1a, PDF/A-1b, PDF/A-2a, PDF/A-2b, PDF/A-2u, PDF/A-3a, PDF/A-3b lub PDF/UA.

**Czy mogę sprawdzić, czy plik jest chroniony hasłem przed jego otwarciem?**

Tak. [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) analizuje plik bez tworzenia obiektu Presentation, a jego właściwość [IsPasswordProtected](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/ispasswordprotected/) informuje, czy wymagane jest hasło. Zobacz [Password-Protect Presentations](/slides/pl/net/password-protected-presentation/).

**Czy dwa pakiety NuGet obsługują różne formaty?**

Nie. Aspose.Slides.NET i Aspose.Slides.NET6.CrossPlatform mają te same wartości LoadFormat i SaveFormat oraz te same metody importu i renderowania. Różnią się platformą, na której działają i wymaganiami tych platform; zobacz [Installation](/slides/pl/net/installation/).