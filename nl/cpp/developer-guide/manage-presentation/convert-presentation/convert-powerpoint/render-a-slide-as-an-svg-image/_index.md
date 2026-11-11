---
title: Render presentatieslides als SVG-afbeeldingen in C++
linktitle: Dia naar SVG
type: docs
weight: 50
url: /nl/cpp/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint naar SVG
- presentatie naar SVG
- dia naar SVG
- PPT naar SVG
- PPTX naar SVG
- SVG-exportopties
- interactieve SVG
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Exporteer PowerPoint-dia's als SVG-afbeeldingen in C++ en beheer lettertypen, tekst, afbeeldingen, ID's en gebeurtenissen met Aspose.Slides."
---
## **Overzicht**

SVG is een schaalbaar XML‑gebaseerd afbeeldingsformaat dat goed werkt voor webpublicatie, slide‑viewers, toegankelijkheidsworkflows en geautomatiseerde nabewerking. Aspose.Slides for C++ exporteert elke dia naar een apart SVG‑bestand en stelt je in staat te bepalen hoe tekst, lettertypen, afbeeldingen en SVG‑elementen worden weggeschreven.

Gebruik [SVGOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/) wanneer het geëxporteerde SVG compact moet zijn, voorspelbaar over browsers, of klaar voor interactief gebruik.

## **Export een dia als SVG**

Maak een [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/), selecteer een dia en schrijf deze naar een stream. Het volgende voorbeeld exporteert elke dia in een presentatie naar een apart SVG‑bestand.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slideCount = presentation->get_Slides()->get_Count();

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    auto svgFileName = String::Format(u"slide-{0}.svg", slide->get_SlideNumber());
    auto svgStream = File::Create(svgFileName);

    slide->WriteAsSvg(svgStream);
    svgStream->Dispose();
}

presentation->Dispose();
```

De bestandsnaam gebruikt [ISlide::get_SlideNumber](https://reference.aspose.com/slides/cpp/aspose.slides/islide/get_slidenumber/) in plaats van de lusindex. Je kunt ook een afzonderlijke vorm exporteren met [IShape::WriteAsSvg](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/writeassvg/) wanneer een slide‑viewer of webpagina alleen die vorm nodig heeft.

## **Configureer SVG‑output**

[SVGOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/) regelt de SVG‑rendering. Voor tekstkaders omvat [SVGOptions::set_UseFrameSize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_useframesize/) het tekstkader in het rendergebied, en [SVGOptions::set_UseFrameRotation](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_useframerotation/) bepaalt of de rotatie van het kader wordt toegepast. Stel [SVGOptions::set_DisableFontLigatures](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_disablefontligatures/) in op `true` wanneer tekst zonder ligaturen moet worden gerenderd.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_DisableFontLigatures(true);
svgOptions->set_UseFrameSize(true);
svgOptions->set_UseFrameRotation(false);

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"slide-with-custom-options.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

## **Regel het afknippen van het lijneinde bij pijlpuntjes**

SVG 1.1 heeft geen marker‑inset‑instelling om te bepalen waar een lijn moet stoppen onder een pijlpunt. Standaard verkort Aspose.Slides de geëxporteerde lijn zodat de streep niet door de marker heen steekt. Stel [SVGOptions::set_DisableLineEndCropping](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_disablelineendcropping/) in op `true` om de streep helemaal tot het oorspronkelijke eindpunt van de lijn te tekenen. Deze instelling heeft alleen invloed op de SVG‑output. De lijn behoudt zijn positie en lengte op de dia.

Het voorbeeld tekent driehoek‑ en diamanten‑pijlpuntjes op lijnen van respectievelijk 2 en 10 punten breed. Het exporteert dezelfde dia twee keer, waarbij alleen de afknippingsoptie wordt gewijzigd.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/FillType.h>
#include <DOM/LineArrowheadStyle.h>
#include <DOM/ShapeType.h>
#include <Export/SVGOptions.h>
#include <drawing/color.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto y = 40;
const LineArrowheadStyle styles[] = { LineArrowheadStyle::Triangle, LineArrowheadStyle::Diamond };
const int widths[] = { 2, 10 };

for (auto style : styles)
{
    for (auto width : widths)
    {
        auto line = slide->get_Shapes()->AddAutoShape(ShapeType::Line, 40, y, 200, 0);
        auto format = line->get_LineFormat();
        format->get_FillFormat()->set_FillType(FillType::Solid);
        format->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
        format->set_Width(width);
        format->set_EndArrowheadStyle(style);
        y += 50;
    }
}

auto options = MakeObject<SVGOptions>();
options->set_DisableLineEndCropping(false);
auto cropped = File::Create(u"cropped.svg");
slide->WriteAsSvg(cropped, options);
cropped->Dispose();

options->set_DisableLineEndCropping(true);
auto uncropped = File::Create(u"uncropped.svg");
slide->WriteAsSvg(uncropped, options);
uncropped->Dispose();

presentation->Dispose();
```

De vergelijking toont de driehoekige pijlpunt op de 10‑punten lijn. Met afknipping ingeschakeld is de punt scherp. Met afknipping uitgeschakeld steekt de streep door de schuine zijden van de marker en ontstaat een vlak einde.

![Vergrootte 10‑punt driehoek met een scherpe punt wanneer afknipping is ingeschakeld en een vlak einde wanneer afknipping is uitgeschakeld](line-end-cropping.png)

In de andere lijnen uit het voorbeeld is de uitstekende streep minder zichtbaar op de 2‑punt driehoek. Het gevulde diamant bedekt het einde van de streep bij beide breedtes.

## **Regel tekst en lettertypen**

Bij het exporteren van dia’s naar SVG kun je bepalen of tekst behouden blijft als tekst of wordt omgezet naar vectorafbeeldingen, en hoe externe lettertypen worden opgenomen of gerefereerd. De onderstaande opties helpen je een balans te vinden tussen visuele consistentie, tekstselectie en afhankelijkheden van lettertypen in de geëxporteerde SVG.

### **Vectoriseer alle tekst**

Stel [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) in op `true` om alle diatekst als vectorafbeeldingen weg te schrijven. Dit verwijdert afhankelijkheden van lettertypen en maakt het visuele resultaat consistenter over browsers, maar de tekst is niet langer selecteerbaar of doorzoekbaar als SVG‑tekst.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_VectorizeText(true);

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"slide-with-vectorized-text.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

### **Kies hoe externe lettertypen worden behandeld**

[SVGOptions::set_ExternalFontsHandling](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_externalfontshandling/) gebruikt een [SvgExternalFontsHandling](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/)‑waarde voor lettertypen die extern worden geladen. Kies `AddLinksToFontFiles` om naar aparte lettertypebestanden te verwijzen, `Embed` om lettertype‑data in de SVG op te nemen, of `Vectorize` om alleen tekst die externe lettertypen gebruikt als graphics weer te geven. Controleer de licentie van het lettertype voordat je lettertypen insluit.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SVGOptions.h>
#include <Export/SvgExternalFontsHandling.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);

auto linkedFontsOptions = MakeObject<SVGOptions>();
linkedFontsOptions->set_ExternalFontsHandling(SvgExternalFontsHandling::AddLinksToFontFiles);
auto linkedFontsStream = File::Create(u"slide-with-font-links.svg");
slide->WriteAsSvg(linkedFontsStream, linkedFontsOptions);
linkedFontsStream->Dispose();

auto embeddedFontsOptions = MakeObject<SVGOptions>();
embeddedFontsOptions->set_ExternalFontsHandling(SvgExternalFontsHandling::Embed);
auto embeddedFontsStream = File::Create(u"slide-with-embedded-fonts.svg");
slide->WriteAsSvg(embeddedFontsStream, embeddedFontsOptions);
embeddedFontsStream->Dispose();

auto vectorizedExternalFontsOptions = MakeObject<SVGOptions>();
vectorizedExternalFontsOptions->set_ExternalFontsHandling(SvgExternalFontsHandling::Vectorize);
auto vectorizedExternalFontsStream = File::Create(u"slide-with-vectorized-external-fonts.svg");
slide->WriteAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
vectorizedExternalFontsStream->Dispose();

presentation->Dispose();
```

## **Verminder de grootte van ingesloten afbeeldingen**

Gebruik [SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_picturescompression/) om de resolutie van ingesloten afbeeldingen te verlagen, [SVGOptions::set_DeletePicturesCroppedAreas](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_deletepicturescroppedareas/) om bijgesneden brongebieden weg te laten, en [SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_jpegquality/) om de JPEG‑coderingkwaliteit te regelen. Deze instellingen verkleinen het bestand ten koste van afbeeldingskwaliteit of behouden beelddata.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_PicturesCompression(PicturesCompression::Dpi150);
svgOptions->set_DeletePicturesCroppedAreas(true);
svgOptions->set_JpegQuality(80);

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"compressed-slide.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

## **Regel de resolutie van metafile‑rasterisatie**

[SVGOptions::set_MetafileRasterizationDpi](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_metafilerasterizationdpi/) stelt de ondergrens voor de resolutie in bij het rasteren van metafiles tijdens SVG‑export. Gebruik het om detail en bestandsgrootte in balans te brengen wanneer een EMF‑ of WMF‑afbeelding wordt gerasterd. Het definieert geen globale DPI voor de SVG en dwingt niet elk object op de dia om een rasterafbeelding te worden.

Download [metafile-rasterization.pptx](metafile-rasterization.pptx), die een EMF‑afbeelding bevat met nauw op elkaar geplaatste diagonale lijnen. Het volgende voorbeeld exporteert de eerste dia op drie rasterisatie‑resoluties via [ISlide::WriteAsSvg](https://reference.aspose.com/slides/cpp/aspose.slides/islide/writeassvg/). Alle andere exportinstellingen blijven identiek zodat de resultaten kunnen worden vergeleken.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"metafile-rasterization.pptx");
auto slide = presentation->get_Slide(0);
const int resolutions[] = { 72, 150, 300 };

for (auto dpi : resolutions)
{
    auto svgOptions = MakeObject<SVGOptions>();
    svgOptions->set_MetafileRasterizationDpi(dpi);
    svgOptions->set_PicturesCompression(PicturesCompression::Dpi330);
    svgOptions->set_JpegQuality(90);

    auto svgFileName = String::Format(u"slide-{0}.svg", dpi);
    auto svgStream = File::Create(svgFileName);
    slide->WriteAsSvg(svgStream, svgOptions);
    svgStream->Dispose();
}

presentation->Dispose();
```

In de output is de EMF één ingesloten PNG geworden in elk SVG. De volgende metingen gelden voor de meegeleverde presentatie; ze vormen geen algemene formule voor het omrekenen van DPI naar pixelafmetingen.

| Metafile rasterisatie DPI | Ingesloten PNG‑afmetingen | SVG‑bestandsgrootte (bytes) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

De vergelijking hieronder toont hetzelfde gebied van de ingesloten raster op dezelfde vergrote weergavegrootte. De diagonale lijnen vertonen duidelijk pixelatie bij 72 DPI en soepelere randen bij hogere resoluties, terwijl het SVG‑bestand groeit. Het verhogen van de waarde verbetert niet per definitie elk detail of verandert elke geëxporteerde afbeelding.

![Vergrote diagonale‑lijndetail bij 72, 150 en 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_picturescompression/) regelt de vermindering van afbeeldingsresolutie en kan het effect van het wijzigen van de metafile‑rasterisatie‑DPI maskeren. [SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_jpegquality/) regelt de JPEG‑coderingkwaliteit, niet de metafile‑rasterisatie‑DPI.

## **Ken stabiele ID’s toe aan vormen en tekst**

Gebruik [ISvgShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeformattingcontroller/) om [ISvgShape::set_Id](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshape/set_id/) voor elke SVG‑vorm in te stellen. Om [ISvgTSpan::set_Id](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgtspan/set_id/) waarden ook op tekst‑`tspan`‑elementen te zetten, implementeer [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeandtextformattingcontroller/). Ken één van beide controllers toe met [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/).

De onderstaande controller gebruikt [IShape::get_OfficeInteropShapeId](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_officeinteropshapeid/), dat gedurende de levensduur van de vorm stabiel is, en een herhaalbare teller voor de tekst‑spans. Dit maakt de gegenereerde ID’s geschikt voor nabewerking van een onveranderde presentatie.

```cpp
#include <DOM/IPortion.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/ISvgShape.h>
#include <Export/ISvgShapeAndTextFormattingController.h>
#include <Export/ISvgTSpan.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

class StableSvgIdController : public ISvgShapeAndTextFormattingController
{
private:
    String m_currentShapeId;
    int m_textSpanIndex = 0;

public:
    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape) override
    {
        m_currentShapeId = String::Format(u"shape-{0}", shape->get_OfficeInteropShapeId());
        m_textSpanIndex = 0;
        svgShape->set_Id(m_currentShapeId);
    }

    void FormatText(SharedPtr<ISvgTSpan> svgTSpan, SharedPtr<IPortion> portion,
                    SharedPtr<ITextFrame> textFrame) override
    {
        auto currentTextSpanIndex = m_textSpanIndex;
        m_textSpanIndex++;
        svgTSpan->set_Id(String::Format(u"{0}-text-{1}", m_currentShapeId, currentTextSpanIndex));
    }
};

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<StableSvgIdController>());

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"slide-with-stable-ids.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

## **Voeg SVG‑eventhandlers toe**

In een [ISvgShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeformattingcontroller/) roep je [ISvgShape::SetEventHandler](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshape/seteventhandler/) aan met een [SvgEvent](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgevent/)‑waarde om een JavaScript‑eventhandler toe te voegen aan een geëxporteerde vorm. Ken de controller toe met [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/) en definieer de JavaScript‑functie in de pagina of het SVG‑document dat het resultaat host.

```cpp
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/ISvgShape.h>
#include <Export/ISvgShapeFormattingController.h>
#include <Export/SVGOptions.h>
#include <Export/SvgEvent.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

class SvgEventController : public ISvgShapeFormattingController
{
public:
    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape) override
    {
        if (shape->get_Name() == u"ActionButton")
        {
            svgShape->set_Id(u"action-button");
            svgShape->SetEventHandler(SvgEvent::OnClick, u"handleShapeClick(event)");
        }
    }
};

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<SvgEventController>());

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"interactive-slide.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

De host‑pagina kan de JavaScript‑functie definiëren die door de handler wordt aangeroepen. Het toekennen van ID’s en eventhandlers maakt slide‑viewers, toegankelijkheidsverbeteringen en andere interactieve SVG‑workflows mogelijk.

## **FAQ**

**Wanneer moet ik [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) gebruiken in plaats van [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/)?**

Gebruik [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) wanneer alle tekst onafhankelijk van lettertypen moet zijn. Gebruik [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/) wanneer alleen tekst die externe lettertypen gebruikt moet worden omgezet naar graphics.

**Wat is de beste manier om een SVG kleiner te maken?**

Begin met het comprimeren van ingesloten afbeeldingen, het verwijderen van bijgesneden afbeeldingsgebieden, en het kiezen van gelinkte lettertypebestanden wanneer de doelomgeving ze kan leveren. Test het resultaat omdat lagere afbeeldingsresolutie, lagere JPEG‑kwaliteit en gevectoriseerde tekst elk een andere kwaliteit‑en‑grootte‑afweging hebben.

**Kan ik geëxporteerde SVG‑elementen na de export aanpassen?**

Ja. Ken ID’s toe via een formatteringscontroller, selecteer vervolgens de overeenkomende SVG‑elementen in je nabewerkings‑tool of browserscript.