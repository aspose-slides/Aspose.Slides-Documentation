---
title: Konvertera presentationsbilder till bildfiler i C++
linktitle: Bild till bild
type: docs
weight: 41
url: /sv/cpp/convert-slide/
keywords:
- konvertera bild
- exportera bild
- bild till bild
- spara bild som bild
- bild till EMF
- bild till PNG
- bild till JPEG
- bild till bitmap
- bild till TIFF
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Konvertera bilder från PPT-, PPTX- och ODP-presentationer till PNG, JPEG, GIF, TIFF, EMF och andra bildformat i C++ med Aspose.Slides för C++."
---
## **Introduktion**

Aspose.Slides för C++ kan rendera enskilda bilder från PowerPoint‑ och OpenDocument‑presentationer som PNG, JPEG, GIF, TIFF och andra bildformat.

För att konvertera en bild till en bildfil, följ dessa steg:

1. Läs in presentationen med klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) .
2. Välj den bild du vill rendera.
3. Om nödvändigt, konfigurera rendering med klassen [RenderingOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/renderingoptions/) eller [TiffOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/tiffoptions/) .
4. Anropa metoden [ISlide::GetImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islide/getimage/) . Den returnerar ett [IImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iimage/)‑objekt.
5. Anropa metoden [IImage::Save](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iimage/save/) . och ange utdataformatet med ett [ImageFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imageformat/)‑värde.

## **Konvertera en bild till en PNG‑bild**

Den enklaste konverteringen använder standardinställningarna för rendering. Det resulterande [IImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iimage/)‑objektet kan bearbetas i minnet eller sparas till en fil.

Följande C++‑exempel renderar den första bilden och sparar den som en PNG‑bild:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage();
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

## **Konvertera bilder till bildfiler med anpassade storlekar**

Använd överlagringen av [ISlide::GetImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islide/getimage/) som accepterar ett [Size](https://reference.aspose.com/slides/sv/cpp/system.drawing/size/)‑värde för att rendera en bild med exakta pixelmått.

Följande exempel skapar en JPEG‑bild på 1820 × 1040 pixlar:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Drawing;

Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(imageSize);
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

## **Konvertera bilder med anteckningar och kommentarer till bildfiler**

Som standard inkluderar bildfiler inte anteckningar eller kommentarer. Tilldela ett [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/notescommentslayoutingoptions/)‑objekt till metoden [RenderingOptions::set_SlidesLayoutOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/renderingoptions/set_slideslayoutoptions/) för att styra var anteckningar och kommentarer visas.

Följande exempel placerar avkortade anteckningar under bilden och kommentarer till höger om den:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

float scaleX = 2.0f;
float scaleY = scaleX;

auto layoutOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_NotesPosition(NotesPositions::BottomTruncated);
layoutOptions->set_CommentsPosition(CommentsPositions::Right);
layoutOptions->set_CommentsAreaWidth(500);
layoutOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layoutOptions);

auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(renderingOptions, scaleX, scaleY);
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```

{{% alert title="Warning" color="warning" %}}
För konvertering av bild till bildfil, sätt inte [NotesCommentsLayoutingOptions::set_NotesPosition](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/)‑metoden till [BottomFull](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/notespositions/). Anteckningarna kan innehålla mer text än den fasta bildstorleken kan rymma. Använd istället [BottomTruncated](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/notespositions/) .
{{% /alert %}}

## **Konvertera bilder till bildfiler med TIFF‑alternativ**

Klassen [TiffOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/tiffoptions/) låter dig kontrollera storlek, upplösning och andra egenskaper för den renderade TIFF‑bilden.

Följande exempel renderar den första bilden som en TIFF‑bild på 2160 × 2880 pixlar med 300 DPI:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/TiffOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_ImageSize(Size(2160, 2880));
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(tiffOptions);
image->Save(u"output.tiff", ImageFormat::Tiff);

image->Dispose();
presentation->Dispose();
```

## **Konvertera alla bilder till bildfiler**

Iterera genom bildsamlingen för att konvertera hela presentationen till en serie bildfiler. Dolda bilder inkluderas om du inte explicit hoppar över dem.

Följande exempel renderar varje bild som en JPEG‑bild med horisontella och vertikala skalningsfaktorer på 2:

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

int32_t slideCount = presentation->get_Slides()->get_Count();
for (int32_t index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(scaleX, scaleY);
    image->Save(String::Format(u"Slide_{0}.jpg", index), ImageFormat::Jpeg);
    image->Dispose();
}

presentation->Dispose();
```

## **Skapa Enhanced Metafile‑utdata**

Enhanced Metafile (EMF) är användbart när vektorgrafik måste utbytas med Microsoft Office eller andra Windows‑program som stöder Windows‑metafiler. Till skillnad från en pixelbaserad bild kan en EMF behålla vektorritningsoperationer som kan skalas utan samma förlust av skärpa. EMF är dock främst ett kompatibilitetsformat för program med stöd för Windows‑metafiler, inte ett universellt utbytesformat. Dessutom kan komplext bildinnehåll, såsom bitmapbilder och vissa effekter, lagras som rasteriserade element i den vektormetafilikontainern.

### **Exportera en bild till EMF**

Metoden [ISlide::WriteAsEmf](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islide/writeasemf/) skriver en [ISlide](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islide/) till en målström i EMF‑format. Följande exempel läser in en presentation, väljer den första bilden och skriver den till en EMF‑filström:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto emfStream = File::Create(u"Slide_0.emf");
slide->WriteAsEmf(emfStream);

emfStream->Close();
presentation->Dispose();
```

Anroparen äger strömmen som skickas till [ISlide::WriteAsEmf](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islide/writeasemf/) och måste stänga eller disponera den. Aspose.Slides skriver vid strömmens aktuella position och lämnar strömmen öppen.

### **Konvertera en SVG‑bild till EMF och lägg till den i en presentation**

Använd [ISvgImage::WriteAsEmf](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isvgimage/writeasemf/) för att konvertera SVG‑innehåll till EMF. De resulterande bytesen kan läggas till i presentationen via [IImageCollection::AddImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iimagecollection/addimage/) och placeras på en bild med [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishapecollection/addpictureframe/).

Följande exempel skapar en [SvgImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/svgimage/) från SVG‑markup, konverterar den till en EMF‑fil i minnet, infogar metafilen på den första bilden och sparar presentationen:

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

String svgContent = u"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto emfStream = MakeObject<MemoryStream>();
svgImage->WriteAsEmf(emfStream);

auto emfData = emfStream->ToArray();
auto image = presentation->get_Images()->AddImage(emfData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20, 20, 200, 100, image);

presentation->Save(u"Presentation_with_emf.pptx", SaveFormat::Pptx);

emfStream->Close();
presentation->Dispose();
```

[ISvgImage::WriteAsEmf](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isvgimage/writeasemf/) tar inte ägandeskap över målströmmen. Efter skrivning är strömmens position i slutet av den genererade datan. Exemplet anropar [MemoryStream::ToArray](https://reference.aspose.com/slides/sv/cpp/system.io/memorystream/toarray/) för att erhålla hela bufferten oavsett strömmens aktuella position, och vidarebefordrar sedan den byte‑arrayen till [IImageCollection::AddImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iimagecollection/addimage/). Håll strömmen öppen tills konsumenten har avslutat läsningen, och stäng den därefter.

EMF‑generering är tillgänglig på de operativsystem som stöds av Aspose.Slides för C++, men rendering kan skilja sig mellan plattformar när teckensnitt eller inhemska grafikberoenden saknas. Installera de teckensnitt som används i källinnehållet eller konfigurera lämpliga ersättningar, följ [plattformskraven](/slides/sv/cpp/system-requirements/) för Aspose.Slides för C++ och validera resultatet i den mål‑EMF‑konsumerande applikationen. Linux‑ och macOS‑applikationer har ofta begränsat eller inkonsekvent stöd för att visa och redigera Windows‑metafiler.

## **Rendering av färg‑emoji**

{{% alert title="Note" color="info" %}}
För att rendera färg‑emoji korrekt när presentationens bilder konverteras till bildfiler måste de emoji‑teckensnitt som används i presentationen vara installerade och tillgängliga på systemet som utför konverteringen. Till exempel, om presentationen använder **Segoe UI Emoji** och detta teckensnitt saknas, kan emoji visas i monokrom i utskriftsbilderna.
{{% /alert %}}

## **FAQ**

**Stöder Aspose.Slides rendering av bilder med animationer?**

Nej. Metoden [ISlide::GetImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islide/getimage/) renderar en statisk bild av bilden och exporterar inte animationer.

**Kan dolda bilder exporteras som bildfiler?**

Ja. Dolda bilder kan renderas som vanliga bilder. Inkludera dem i bearbetningsloopen, som visas i exemplet ovan.

**Bevaras skuggor och andra effekter i bildfilerna?**

Ja. Aspose.Slides renderar skuggor, transparens och andra stödjade grafiska effekter i bildfilerna.