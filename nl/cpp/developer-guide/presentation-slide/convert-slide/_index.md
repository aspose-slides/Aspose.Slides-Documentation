---
title: "Dia's van presentaties converteren naar afbeeldingen in C++"
linktitle: "Dia naar afbeelding"
type: docs
weight: 41
url: /nl/cpp/convert-slide/
keywords:
- "dia converteren"
- "dia exporteren"
- "dia naar afbeelding"
- "dia opslaan als afbeelding"
- "dia naar EMF"
- "dia naar PNG"
- "dia naar JPEG"
- "dia naar bitmap"
- "dia naar TIFF"
- "PowerPoint"
- "OpenDocument"
- "presentatie"
- "C++"
- "Aspose.Slides"
description: "Convert dia's van PPT, PPTX en ODP presentaties naar PNG, JPEG, GIF, TIFF, EMF en andere afbeeldingsformaten in C++ met Aspose.Slides voor C++."
---
## **Introductie**

Aspose.Slides for C++ kan individuele dia's uit PowerPoint- en OpenDocument‑presentaties renderen als PNG, JPEG, GIF, TIFF en andere afbeeldingsformaten.

Om een dia om te zetten naar een afbeelding, volgt u deze stappen:

1. Laad de presentatie met de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse.
2. Selecteer de dia die u wilt renderen.
3. Indien nodig, configureer de rendering met de [RenderingOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/renderingoptions/) of [TiffOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/tiffoptions/) klasse.
4. Roep de [ISlide::GetImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islide/getimage/) methode aan. Deze retourneert een [IImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iimage/) object.
5. Roep de [IImage::Save](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iimage/save/) methode aan en specificeer het uitvoerformaat met een [ImageFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imageformat/) waarde.

## **Een dia naar een PNG‑afbeelding converteren**

De eenvoudigste conversie gebruikt de standaard renderinginstellingen. Het resulterende [IImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iimage/) object kan in het geheugen worden verwerkt of naar een bestand worden opgeslagen.

Het volgende C++‑voorbeeld rendert de eerste dia en slaat deze op als een PNG‑afbeelding:

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

## **Dia's naar afbeeldingen converteren met aangepaste afmetingen**

Gebruik de overload van [ISlide::GetImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islide/getimage/) die een [Size](https://reference.aspose.com/slides/nl/cpp/system.drawing/size/) waarde accepteert om een dia te renderen met exacte pixelafmetingen.

Het volgende voorbeeld maakt een JPEG‑afbeelding van 1820 × 1040:

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

## **Dia's met notities en opmerkingen naar afbeeldingen converteren**

Standaard bevatten dia‑afbeeldingen geen notities of opmerkingen. Ken een [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/notescommentslayoutingoptions/) object toe aan de methode [RenderingOptions::set_SlidesLayoutOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/renderingoptions/set_slideslayoutoptions/) om te bepalen waar notities en opmerkingen worden weergegeven.

Het volgende voorbeeld plaatst afgekorte notities onder de dia en opmerkingen rechts ervan:

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
Voor dia‑naar‑afbeelding‑conversie stelt u de [NotesCommentsLayoutingOptions::set_NotesPosition](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) methode niet in op [BottomFull]. Notities kunnen meer tekst bevatten dan de vaste afbeeldingsgrootte aankan. Gebruik in plaats daarvan [BottomTruncated].
{{% /alert %}}

## **Dia's naar afbeeldingen converteren met TIFF‑opties**

De klasse [TiffOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/tiffoptions/) stelt u in staat de grootte, resolutie en andere eigenschappen van de gerenderde TIFF‑afbeelding te regelen.

Het volgende voorbeeld rendert de eerste dia als een TIFF‑afbeelding van 2160 × 2880 bij 300 DPI:

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

## **Alle dia's naar afbeeldingen converteren**

Itereer door de dia‑collectie om de volledige presentatie om te zetten in een reeks afbeeldingen. Verborgen dia's worden meegenomen, tenzij u ze expliciet overslaat.

Het volgende voorbeeld rendert elke dia als een JPEG‑afbeelding met horizontale en verticale schaalfactoren van 2:

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

## **Enhanced Metafile‑output maken**

Enhanced Metafile (EMF) is nuttig wanneer vectorgebaseerde grafische afbeeldingen moeten worden uitgewisseld met Microsoft Office of andere Windows‑toepassingen die Windows‑metabestanden ondersteunen. In tegenstelling tot een pixelgebaseerde afbeelding kan een EMF vector‑tekenbewerkingen behouden die schalen zonder hetzelfde verlies aan scherpte. EMF is echter voornamelijk een compatibiliteitsformaat voor toepassingen met Windows‑metabestandondersteuning, geen universeel uitwisselingsformaat. Bovendien kan complexe dia‑inhoud, zoals bitmap‑afbeeldingen en sommige effecten, worden opgeslagen als gerasterde elementen binnen de vector‑metabestandscontainer.

### **Een dia exporteren naar EMF**

De methode [ISlide::WriteAsEmf](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islide/writeasemf/) schrijft een [ISlide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islide/) naar een doel‑stroom in EMF‑formaat. Het volgende voorbeeld laadt een presentatie, selecteert de eerste dia en schrijft deze naar een EMF‑bestandstroom:

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

De aanroeper bezit de stroom die aan [ISlide::WriteAsEmf](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islide/writeasemf/) wordt doorgegeven en moet deze sluiten of vrijgeven. Aspose.Slides schrijft op de huidige positie van de stroom en laat de stroom open.

### **Een SVG‑afbeelding naar EMF converteren en toevoegen aan een presentatie**

Gebruik [ISvgImage::WriteAsEmf](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isvgimage/writeasemf/) om SVG‑inhoud te converteren naar EMF. De resulterende bytes kunnen aan de presentatie worden toegevoegd via [IImageCollection::AddImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iimagecollection/addimage/) en op een dia worden geplaatst met [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides.ishapecollection/addpictureframe/).

Het volgende voorbeeld maakt een [SvgImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/svgimage/) van SVG‑opmaak, converteert deze naar een EMF in het geheugen, voegt het metafile toe aan de eerste dia en slaat de presentatie op:

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

[ISvgImage::WriteAsEmf](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isvgimage/writeasemf/) neemt geen eigendom van de bestemmingsstroom. Na het schrijven staat de stroompositie aan het einde van de gegenereerde gegevens. Het voorbeeld roept [MemoryStream::ToArray](https://reference.aspose.com/slides/nl/cpp/system.io/memorystream/toarray/) aan om de volledige buffer te verkrijgen, ongeacht de huidige stroompositie, en geeft die byte‑array door aan [IImageCollection::AddImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iimagecollection/addimage/). Houd de stroom open totdat de consument klaar is met lezen en sluit hem daarna.

EMF‑generatie is beschikbaar op de besturingssystemen die door Aspose.Slides voor C++ worden ondersteund, maar rendering kan per platform verschillen wanneer lettertypen of native grafische afhankelijkheden niet beschikbaar zijn. Installeer de lettertypen die in de broninhoud worden gebruikt of configureer geschikte vervangingen, volg de [platform requirements](/slides/nl/cpp/system-requirements/) voor Aspose.Slides voor C++ en valideer het resultaat in de doel‑EMF‑consumentapplicatie. Linux‑ en macOS‑toepassingen hebben vaak beperkte of inconsistente ondersteuning voor het weergeven en bewerken van Windows‑metabestanden.

## **Kleur‑emoji rendering**

{{% alert title="Note" color="info" %}}
Om kleur‑emoji’s correct te renderen bij het converteren van presentatiedia’s naar afbeeldingen, moeten de emoji‑lettertypen die in de presentatie worden gebruikt geïnstalleerd en beschikbaar zijn op het systeem dat de conversie uitvoert. Bijvoorbeeld, als de presentatie **Segoe UI Emoji** gebruikt en dit lettertype ontbreekt, kunnen emoji’s in monochroom verschijnen in de uitvoerafbeeldingen.
{{% /alert %}}

## **FAQ**

**Ondersteunt Aspose.Slides het renderen van dia's met animaties?**

Nee. De methode [ISlide::GetImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islide/getimage/) rendert een statische afbeelding van de dia en exporteert geen animaties.

**Kunnen verborgen dia's worden geëxporteerd als afbeeldingen?**

Ja. Verborgen dia's kunnen worden gerenderd zoals gewone dia's. Neem ze op in de verwerkingslus, zoals getoond in het voorbeeld hierboven.

**Worden schaduwen en andere effecten behouden in dia‑afbeeldingen?**

Ja. Aspose.Slides rendert schaduwen, transparantie en andere ondersteunde grafische effecten in dia‑afbeeldingen.