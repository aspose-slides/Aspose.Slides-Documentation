---
title: Optimaliseer beheer van afbeeldingen in presentaties met C++
linktitle: Afbeeldingen beheren
type: docs
weight: 10
url: /nl/cpp/image/
keywords:
- afbeelding toevoegen
- foto toevoegen
- afbeelding vervangen
- afbeeldingscollectie
- afbeeldingskader
- gelinkte afbeelding
- achtergrond
- PNG toevoegen
- JPG toevoegen
- SVG toevoegen
- SVG naar vormen
- externe SVG‑bronnen
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe u raster‑ en SVG‑afbeeldingen kunt toevoegen, hergebruiken, linken, vervangen en beheren in PowerPoint‑ en OpenDocument‑presentaties met Aspose.Slides voor C++."
---
## **Introductie**

Aspose.Slides for C++ biedt verschillende manieren om met afbeeldingen te werken, en elke manier heeft een ander doel. U kunt een afbeelding opslaan in een presentatie, weergeven in een afbeeldingskader, gebruiken als dia‑achtergrond, linken naar een externe afbeelding, een gedeelde afbeeldingsbron vervangen, of SVG‑inhoud omzetten naar bewerkbare vormen.

Dit artikel richt zich op afbeeldingsbronnen en hoe ze door een presentatie heen worden gebruikt. Voor bijsnijden, transparantie, effecten, uitrekken en andere opmaak die op een individueel afbeeldingskader wordt toegepast, zie [Afbeeldingskader](/slides/nl/cpp/picture-frame/).

## **Begrijp het afbeeldingsmodel**

De volgende API‑concepten zijn nauw verwant maar niet uitwisselbaar:

- De [presentatie‑afbeeldingscollectie](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iimagecollection/) slaat afbeeldingsbronnen op die door de presentatie worden gebruikt. Gebruik [IImageCollection::AddImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iimagecollection/addimage/) om afbeeldingsgegevens toe te voegen en een [IPPImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ippimage/)‑resource te verkrijgen.
- Een [afbeeldingskader](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipictureframe/) is een vorm die een afbeelding op een dia, lay‑out of master weergeeft. Gebruik [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishapecollection/addpictureframe/) om een afbeeldingsresource op een dia te plaatsen.
- Een dia‑achtergrond gebruikt een afbeelding als deel van de dia‑vulling in plaats van als een vorm. Het gedraagt zich daarom niet als een afbeeldingskader.
- [IPPImage::ReplaceImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ippimage/replaceimage/) vervangt een afbeeldingsresource. Als verschillende presentatie‑elementen die resource gebruiken, gebruiken ze allemaal de vervanging.
- Het converteren van een SVG naar vormen creëert bewerkbare dia‑vormen. Na conversie wordt de inhoud niet langer beheerd als één afbeeldingsresource.

Een typische werkwijze is daarom: afbeeldingsgegevens toevoegen aan de collectie, een [IPPImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ippimage/) ontvangen, en die resource vervolgens gebruiken in één of meerdere afbeeldingskaders of vullingen.

## **Een ingebedde afbeelding toevoegen**

Om een lokale afbeelding in te voegen, leest u het bestand, voegt u de gegevens toe aan de afbeeldingscollectie en maakt u een afbeeldingskader dat de geretourneerde [IPPImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ippimage/)‑resource gebruikt.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 320.0f, 180.0f, image);

presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

De op deze manier toegevoegde afbeelding is ingebed in de presentatie, zodat het resulterende bestand niet afhankelijk is van de oorspronkelijke afbeeldings­bestand die nog beschikbaar moet zijn.

### **Een afbeelding van internet toevoegen**

Wanneer een afbeelding beschikbaar is via HTTP of HTTPS, downloadt u de bytes, voegt u ze toe aan de presentatie‑afbeeldingscollectie en gebruikt u de geretourneerde afbeeldingsresource op dezelfde manier als een lokale afbeelding.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <net/web_client.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Net;

auto imageUri = MakeObject<Uri>(u"https://example.com/image.png");
auto webClient = MakeObject<WebClient>();
auto imageData = webClient->DownloadData(imageUri);

auto presentation = MakeObject<Presentation>();

auto image = presentation->get_Images()->AddImage(imageData);
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 320.0f, 180.0f, image);

presentation->Save(u"presentation-from-web.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Valideer externe URL’s, responsgroottes en content‑types wanneer de bron niet vertrouwd is. In applicaties die al een andere HTTP‑client gebruiken, kunt u de afbeelding met die client downloaden en de resulterende bytes of stream doorgeven aan [IImageCollection::AddImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iimagecollection/addimage/).

## **Afbeeldingen hergebruiken tussen dia’s**

Als dezelfde afbeelding meer dan één keer nodig is, voegt u deze één keer toe aan de presentatie en hergebruikt u de verkregen [IPPImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ippimage/) bij het maken van extra afbeeldingskaders. Dit voorkomt herhaaldelijk laden van dezelfde brongegevens en maakt de relatie tussen de gedeelde afbeeldingsresource en het gebruik ervan expliciet.

Voor grafische elementen die automatisch op veel dia’s moeten verschijnen, zoals een bedrijfslogo, overweeg om het afbeeldingskader op een [dia‑master](/slides/nl/cpp/slide-master/) of lay‑out te plaatsen in plaats van een gelijkwaardige vorm op elke dia toe te voegen.

## **Een afbeelding als dia‑achtergrond gebruiken**

Een achtergrondafbeelding wordt toegewezen aan de dia‑vulling; hij wordt niet toegevoegd als een afbeeldingskader‑vorm. Dit is nuttig wanneer de afbeelding de hele dia‑achtergrond moet bedekken en niet moet worden gemanipuleerd als een normaal dia‑object.

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"background.jpg");
auto image = presentation->get_Images()->AddImage(imageData);

slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);

presentation->Save(u"background-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Voor extra achtergrondopties, inclusief master‑ en lay‑out‑achtergronden, zie [Presentatie‑achtergrond](/slides/nl/cpp/presentation-background/).

## **Ingebedde en gelinkte afbeeldingen**

Ingebedde en gelinkte afbeeldingen hebben verschillende draagbaarheid‑ en bestandsgrootte‑afwegingen:

- **Ingebedde afbeelding:** de afbeeldingsgegevens worden opgeslagen in de presentatie. De presentatie is zelf‑containend, maar de bestandsgrootte omvat de afbeeldingsgegevens.
- **Gelinkte afbeelding:** de presentatie slaat een pad of URL op naar een externe afbeelding. Dit kan de presentatiegrootte verkleinen, maar de externe bron moet toegankelijk blijven wanneer de presentatie wordt geopend of gerenderd.

Een gelinkte afbeelding kan worden aangemaakt door het externe pad of de URL toe te wijzen via [ISlidesPicture::set_LinkPathLong](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidespicture/set_linkpathlong/) in plaats van de afbeeldingsgegevens in te bedden.

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 320.0f, 180.0f, nullptr);
pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://example.com/image.png");

presentation->Save(u"linked-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Gebruik gelinkte afbeeldingen alleen wanneer de implementatie‑omgeving de externe bron betrouwbaar kan benaderen. Voor presentaties die offline moeten werken of tussen systemen verplaatst worden, zijn ingebedde afbeeldingen doorgaans veiliger.

## **Werken met SVG‑afbeeldingen**

SVG is een vectorformaat, waardoor het nuttig kan zijn voor iconen, diagrammen en andere graphics die moeten schalen zonder hetzelfde detailverlies als rasterafbeeldingen. Aspose.Slides ondersteunt SVG zowel als afbeeldingsresource als bron voor bewerkbare dia‑vormen.

### **Een SVG als afbeelding toevoegen**

Maak een [SvgImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/svgimage/), voeg deze toe aan de afbeeldingscollectie en plaats de resulterende afbeeldingsresource in een afbeeldingskader.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto svgContent = File::ReadAllText(u"icon.svg");
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();

auto image = presentation->get_Images()->AddImage(svgImage);
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 200.0f, 200.0f, image);

presentation->Save(u"svg-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **SVG‑bestanden met externe bronnen**

Een SVG kan externe afbeeldingen, stylesheets of lettertypen refereren. Voor deze gevallen biedt [SvgImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/svgimage/) constructors die een [IExternalResourceResolver](https://reference.aspose.com/slides/nl/cpp/aspose.slides.import/iexternalresourceresolver/) en een basis‑URI accepteren. De resolver kan een relatieve URI omzetten naar een toegestane absolute URI en een stream retourneren voor de gevraagde bron.

De resolver maakt externe bronnen beschikbaar terwijl Aspose.Slides de SVG verwerkt, maar herschrijft de SVG niet naar een zelf‑containend document. Als de SVG draagbaar moet blijven, embed dan de vereiste bronnen in de SVG zelf, bijvoorbeeld door `data:`‑URI’s te gebruiken voor gelinkte afbeeldingen.

Wanneer SVG‑bestanden afkomstig zijn van onbetrouwbare bronnen, beperk dan de schema’s, bestandslocaties en hosts die de resolver mag benaderen. Netwerk‑resolvers moeten tevens time‑outs, limieten voor respons‑grootte en content‑validatie toepassen.

### **SVG naar bewerkbare vormen converteren**

Aspose.Slides kan een SVG omzetten naar een groep bewerkbare dia‑vormen, vergelijkbaar met de overeenkomstige PowerPoint‑opdracht.

![PowerPoint‑pop‑upmenu](img_01_01.png)

Gebruik de [IShapeCollection::AddGroupShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishapecollection/addgroupshape/) overload die een [ISvgImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isvgimage/) accepteert om de conversie uit te voeren.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto svgContent = File::ReadAllText(u"diagram.svg");
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();

auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddGroupShape(svgImage, 0.0f, 0.0f, slideSize.get_Width(), slideSize.get_Height());

presentation->Save(u"editable-svg-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Gebruik SVG‑naar‑vormen‑conversie wanneer individuele vector‑elementen moeten worden bewerkt als PowerPoint‑vormen. Als de SVG alleen moet worden weergegeven, is het eenvoudiger deze als afbeelding te laten staan en vermijdt u het aanmaken van veel losse vormen.

## **Een bestaande afbeeldingsresource vervangen**

Gebruik [IPPImage::ReplaceImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ippimage/replaceimage/) wanneer u een bestaande afbeeldingsresource wilt vervangen. Dit is vooral nuttig voor gedeelde graphics zoals logo’s.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto imageToReplace = presentation->get_Image(0);
auto imageData = File::ReadAllBytes(u"new-logo.png");
imageToReplace->ReplaceImage(imageData);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Als meerdere afbeeldingskaders, achtergronden, masters of lay‑outs dezelfde afbeeldingsresource gebruiken, werkt het vervangen van die resource al hun gebruik bij. Als slechts één afbeeldingskader moet wijzigen, ken dan een andere afbeelding toe aan dat kader in plaats van de gedeelde resource te vervangen.

[IPPImage::ReplaceImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ippimage/replaceimage/) biedt ook overloads die een [IImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iimage/) of een andere [IPPImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ippimage/) accepteren.

## **Praktisch advies voor afbeeldingsbeheer**

### **Presentatiegrootte beheersen**

Grote rasterafbeeldingen kunnen een presentatie onnodig groot maken. Gebruik bronafbeeldingen met afmetingen die passen bij de beoogde weergavegrootte, hergebruik gedeelde afbeeldingsbronnen waar mogelijk, en vermijd het inbedden van herhaalde kopieën van dezelfde hoge‑resolutie‑grafiek.

Voor raster‑afbeeldingen die al in afbeeldingskaders staan, kan [IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipicturefillformat/compressimage/) de afbeeldingsdata reduceren volgens de geselecteerde resolutie en bijsnijd‑instellingen. Dit is verwerking van een afbeeldingskader en geen beheer van de afbeeldingscollectie, dus zie [Afbeeldingskader](/slides/nl/cpp/picture-frame/) voor gerelateerde opmaakbewerkingen.

### **Kiezen tussen ingebedde en gelinkte inhoud**

Inbedden maakt de presentatie draagbaar omdat alle benodigde afbeeldingsgegevens met het bestand meereizen. Linken kan de bestandsgrootte verkleinen, maar introduceert een externe afhankelijkheid. Gebruik links alleen wanneer die afhankelijkheid acceptabel en stabiel is.

### **Gedeelde branding hergebruiken**

Voor herhaalde logo’s, watermerken of decoratieve graphics, gebruik één afbeeldingsresource en hergebruik deze. Als de graphic tot het presentatiedesign behoort in plaats van tot de dia‑inhoud, plaats deze dan op een master of lay‑out zodat ze wordt geërfd door de betreffende dia’s.

### **SVG‑bronnen draagbaar houden**

Een zelf‑containende SVG is makkelijker te verplaatsen en consequent te renderen dan een SVG die afhankelijk is van externe bestanden of netwerkbronnen. Wanneer mogelijk, embed de vereiste bronnen voordat u de SVG importeert. Converteer SVG naar vormen alleen wanneer de individuele vector‑elementen bewerkt moeten worden.

### **De Aspose.Slides‑afbeeldings‑API gebruiken**

Voor C++‑afbeeldingsworkflows, gebruik de Aspose.Slides [IImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iimage/)‑ en [Images](https://reference.aspose.com/slides/nl/cpp/aspose.slides/images/)‑APIs wanneer u een afbeeldingsobject nodig hebt, en gebruik [IImageCollection::AddImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iimagecollection/addimage/) wanneer u afbeeldingsdata wilt registreren als presentatie‑resource. De collectie‑overloads ondersteunen ook byte‑arrays en streams, wat nuttig is wanneer afbeeldingsdata afkomstig is van bestanden, netwerk‑clients, databases of andere bibliotheken.

Het genereren van EMF‑inhoud uit spreadsheets of een ander product is een apart integratie‑scenario en valt buiten de scope van dit artikel. Als een bestaand WMF‑ of EMF‑bestand alleen in een presentatie moet worden ingevoegd, geef de data dan door aan een geschikte [IImageCollection::AddImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iimagecollection/addimage/) overload zonder een tweede product‑afhankelijkheid toe te voegen aan de workflow voor afbeeldingsbeheer.

## **FAQ**

**Wat is het verschil tussen de afbeeldingscollectie en een afbeeldingskader?**

De afbeeldingscollectie slaat herbruikbare afbeeldingsbronnen op. Een afbeeldingskader is een dia‑vorm die één van die bronnen weergeeft en beeld‑specifieke opmaak biedt zoals bijsnijden en effecten.

**Wat is de beste manier om hetzelfde logo overal te vervangen?**

Als het logo al gedeeld wordt als één afbeeldingsresource, vervang die resource met [IPPImage::ReplaceImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ippimage/replaceimage/). Voor presentatie‑brede branding kan het plaatsen van het logo op een master of lay‑out ook dubbele dia‑inhoud verminderen.

**Waarom verdwijnt een gelinkte afbeelding op een andere computer?**

Een gelinkte afbeelding hangt af van zijn externe bestand of URL. Als die bron vanaf de andere computer niet bereikbaar is, is de afbeelding niet beschikbaar. Embed de afbeelding wanneer de presentatie zelf‑containend moet zijn.

**Kan een ingevoegde SVG worden bewerkt als PowerPoint‑vormen?**

Ja. Converteer de SVG met [IShapeCollection::AddGroupShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishapecollection/addgroupshape/); de resulterende groep bevat bewerkbare dia‑vormen in plaats van één SVG‑afbeelding.

**Hoe kan ik presentaties met veel afbeeldingen kleiner houden?**

Herbruik gedeelde afbeeldingsbronnen, vermijd onnodig grote rasterbronnen, comprimeer raster‑afbeeldingen wanneer gepast, plaats herhaalde branding op masters of lay‑outs, en gebruik gelinkte afbeeldingen alleen wanneer een externe afhankelijkheid acceptabel is.