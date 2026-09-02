---
title: Optimera bildhantering i presentationer med C++
linktitle: Hantera bilder
type: docs
weight: 10
url: /sv/cpp/image/
keywords:
- lägg till bild
- lägg till foto
- ersätt bild
- bildsamling
- bildram
- länkad bild
- bakgrund
- lägg till PNG
- lägg till JPG
- lägg till SVG
- SVG till former
- externa SVG‑resurser
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Lär dig hur du lägger till, återanvänder, länkar, ersätter och hanterar raster- och SVG-bilder i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för C++."
---
## **Introduktion**

Aspose.Slides för C++ erbjuder flera sätt att arbeta med bilder, och varje sätt har ett annat syfte. Du kan lagra en bild i en presentation, visa den i en bildram, använda den som bildbakgrund, länka till en extern bild, ersätta en delad bildresurs eller konvertera SVG-innehåll till redigerbara former.

Den här artikeln fokuserar på bildresurser och hur de används i en presentation. För beskärning, transparens, effekter, sträckning och annan formatering som tillämpas på en enskild bildram, se [Bildram](/slides/sv/cpp/picture-frame/).

## **Förstå bildmodellen**

Följande API‑koncept är nära besläktade men inte utbytbara:

- Den [presentationens bildsamling](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iimagecollection/) lagrar bildresurser som används av presentationen. Använd [IImageCollection::AddImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iimagecollection/addimage/) för att lägga till bilddata och få en [IPPImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ippimage/)‑resurs.
- En [bildram](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipictureframe/) är en form som visar en bild på en bild, layout eller master. Använd [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishapecollection/addpictureframe/) för att placera en bildresurs på en bild.
- En bildbakgrund använder en bild som en del av bildens fyllning snarare än som en form. Den beter sig därför inte som en bildram.
- [IPPImage::ReplaceImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ippimage/replaceimage/) ersätter en bildresurs. Om flera presentations‑element använder den resursen, använder de alla ersättningen.
- Att konvertera en SVG till former skapar redigerbara bildformer. Efter konverteringen hanteras innehållet inte längre som en enda bildresurs.

Ett typiskt arbetsflöde är därför: lägg till bilddata i bildsamlingen, erhåll en [IPPImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ippimage/), och använd sedan den resursen i en eller flera bildramar eller fyllningar.

## **Lägg till en inbäddad bild**

För att infoga en lokal bild, läs filen, lägg till dess data i bildsamlingen och skapa en bildram som använder den returnerade [IPPImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ippimage/)‑resursen.

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

Bilden som läggs till på detta sätt är inbäddad i presentationen, så den resulterande filen är inte beroende av att den ursprungliga bildfilen finns tillgänglig.

### **Lägg till en bild från webben**

När en bild är tillgänglig via HTTP eller HTTPS, hämta dess bytes, lägg till dem i presentationens bildsamling och använd den returnerade bildresursen på samma sätt som en lokal bild.

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

Validera fjärr‑URL:er, svarsstorlekar och innehållstyper när källan inte är betrodd. I applikationer som redan använder en annan HTTP‑klient kan du hämta bilden med den klienten och skicka de resulterande bytes eller strömmen till [IImageCollection::AddImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iimagecollection/addimage/).

## **Återanvänd bilder i flera bilder**

Om samma bild behövs mer än en gång, lägg till den i presentationen en gång och återanvänd den returnerade [IPPImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ippimage/) när du skapar ytterligare bildramar. Detta undviker att ladda samma källdata flera gånger och gör förhållandet mellan den delade bildresursen och dess användningar explicit.

För grafik som ska visas automatiskt på många bilder, till exempel en företagslogotyp, överväg att placera bildramen på en [bildmaster](/slides/sv/cpp/slide-master/) eller layout istället för att lägga till en motsvarande form på varje bild.

## **Använd en bild som bildbakgrund**

En bakgrundsbild tilldelas bildens fyllning; den läggs inte till som en bildramform. Detta är användbart när bilden ska täcka bildbakgrunden och inte ska manipuleras som ett vanligt bildobjekt.

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

För ytterligare bakgrundsalternativ, inklusive master‑ och layoutbakgrunder, se [Presentationens bakgrund](/slides/sv/cpp/presentation-background/).

## **Inbäddade bilder och länkade bilder**

Inbäddade och länkade bilder har olika avvägningar när det gäller portabilitet och filstorlek:

- **Inbäddad bild:** bilddata lagras i presentationen. Presentationen är självständig, men filstorleken inkluderar bilddata.
- **Länkad bild:** presentationen lagrar en sökväg eller URL till en extern bild. Detta kan minska presentationens storlek, men den externa resursen måste vara tillgänglig när presentationen öppnas eller renderas.

En länkad bild kan skapas genom att tilldela den externa sökvägen eller URL:en via [ISlidesPicture::set_LinkPathLong](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidespicture/set_linkpathlong/) istället för att bädda in bilddata.

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

Använd länkade bilder endast när distributionsmiljön på ett pålitligt sätt kan nå den externa resursen. För presentationer som måste fungera offline eller flyttas mellan system är inbäddade bilder vanligtvis säkrare.

## **Arbeta med SVG‑bilder**

SVG är ett vektorformat, så det kan vara användbart för ikoner, diagram och annan grafik som ska skalas utan samma detaljförlust som rasterbilder. Aspose.Slides stödjer SVG både som en bildresurs och som källa för redigerbara bildformer.

### **Lägg till en SVG som bild**

Skapa en [SvgImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/svgimage/), lägg till den i bildsamlingen och placera den resulterande bildresursen i en bildram.

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

### **SVG‑filer med externa resurser**

En SVG kan referera till externa bilder, stilark eller teckensnitt. För dessa fall tillhandahåller [SvgImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/svgimage/) konstruktorer som accepterar en [IExternalResourceResolver](https://reference.aspose.com/slides/sv/cpp/aspose.slides.import/iexternalresourceresolver/) och en bas‑URI. Resolvern kan mappa en relativ URI till en tillåten absolut URI och returnera en ström för den begärda resursen.

Resolvren gör externa resurser tillgängliga medan Aspose.Slides behandlar SVG‑filen, men den skriver inte om SVG‑filen till ett självständigt dokument. Om SVG‑filen måste förbli portabel, bädda in dess nödvändiga resurser i själva SVG‑filen, till exempel genom att använda `data:`‑URI:er för länkade bilder.

När SVG‑filer kommer från opålitliga källor, begränsa de scheman, filplatser och värdar som resolvern får åtkomst till. Nätverksresolvers bör också tillämpa tidsgränser, begränsningar för svarsstorlek och innehållsvalidering.

### **Konvertera SVG till redigerbara former**

Aspose.Slides kan konvertera en SVG till en grupp redigerbara bildformer, liknande motsvarande PowerPoint‑kommando.

![PowerPoint Popup Menu](img_01_01.png)

Använd [IShapeCollection::AddGroupShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishapecollection/addgroupshape/)‑overloaden som accepterar en [ISvgImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isvgimage/) för att utföra konverteringen.

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

Använd SVG‑till‑former‑konvertering när enskilda vektorelement behöver redigeras som PowerPoint‑former. Om SVG‑filen bara ska visas är det enklare att behålla den som en bild och undvika att skapa många separata former.

## **Ersätt en befintlig bildresurs**

Använd [IPPImage::ReplaceImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ippimage/replaceimage/) när du vill ersätta en befintlig bildresurs. Detta är särskilt användbart för delad grafik som logotyper.

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

Om flera bildramar, bakgrunder, masters eller layouter använder samma bildresurs, uppdaterar ersättningen av den resursen alla dessa användningar. Om bara en bildram ska ändras, tilldela en annan bild till den ramen istället för att ersätta den delade resursen.

[IPPImage::ReplaceImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ippimage/replaceimage/) erbjuder också overloads som accepterar en [IImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iimage/) eller en annan [IPPImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ippimage/).

## **Praktisk vägledning för bildhantering**

### **Kontrollera presentationens storlek**

Stora rasterbilder kan göra en presentation onödigt stor. Använd källbilder med dimensioner som är lämpliga för deras avsedda visningsstorlek, återanvänd delade bildresurser där det är möjligt och undvik att bädda in upprepade kopior av samma högupplösta grafik.

För rasterbilder som redan har placerats i bildramar kan [IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipicturefillformat/compressimage/) reducera bilddata enligt den valda upplösningen och beskärningsinställningarna. Detta är bildram‑behandling snarare än hantering av bildsamling, så se [Bildram](/slides/sv/cpp/picture-frame/) för relaterade formateringsåtgärder.

### **Välj mellan inbäddat och länkat innehåll**

Inbäddning gör presentationen portabel eftersom all nödvändig bilddata följer med filen. Länkning kan minska filstorleken, men den introducerar ett externt beroende. Använd länkar endast när det beroendet är acceptabelt och stabilt.

### **Återanvänd delad varumärkesgrafik**

För återkommande logotyper, vattenmärken eller dekorativ grafik, använd en bildresurs och återanvänd den. Om grafiken tillhör presentationsdesignen snarare än bildinnehållet, placera den på en master eller layout så den ärvs av de relevanta bilderna.

### **Behåll SVG‑resurser portabla**

En självständig SVG är lättare att flytta och rendera konsekvent än en SVG som är beroende av externa filer eller nätverksresurser. När det är möjligt, bädda in nödvändiga resurser innan SVG‑filen importeras. Konvertera SVG till former endast när de enskilda vektorelementen behöver redigeras.

### **Använd Aspose.Slides bild‑API**

För bildarbetsflöden i C++ använder du Aspose.Slides [IImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iimage/) och [Images](https://reference.aspose.com/slides/sv/cpp/aspose.slides/images/)‑API:erna när du behöver ett bildobjekt, och använder [IImageCollection::AddImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iimagecollection/addimage/) när du behöver registrera bilddata som en presentationsresurs. Samlings‑overloadarna stödjer även byte‑arrayer och strömmar, vilket är användbart när bilddata kommer från filer, nätverksklienter, databaser eller andra bibliotek.

Att generera EMF‑innehåll från kalkylblad eller en annan produkt är ett separat integrationsarbetsflöde och ligger utanför räckvidden för den här artikeln. Om en befintlig WMF‑ eller EMF‑fil bara behöver infogas i en presentation, skicka dess data till en lämplig [IImageCollection::AddImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iimagecollection/addimage/)‑overload utan att lägga till ett andra produktberoende i bildhanteringsarbetsflödet.

## **FAQ**

**Vad är skillnaden mellan bildsamlingen och en bildram?**

Bildsamlingen lagrar återanvändbara bildresurser. En bildram är en bildform som visar en av dessa resurser och erbjuder bildspecifik formatering som beskärning och effekter.

**Vad är det bästa sättet att ersätta samma logotyp överallt?**

Om logotypen redan delas som en bildresurs, ersätt den resursen med [IPPImage::ReplaceImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ippimage/replaceimage/). För varumärkesgrafik i hela presentationen kan placering av logotypen på en master eller layout också minska duplicerat bildinnehåll.

**Varför försvinner en länkad bild på en annan dator?**

En länkad bild beror på sin externa fil eller URL. Om den resursen inte kan nås från den andra datorn kan den länkade bilden vara otillgänglig. Bädda in bilden när presentationen måste vara självständig.

**Kan en infogad SVG redigeras som PowerPoint‑former?**

Ja. Konvertera SVG‑filen med [IShapeCollection::AddGroupShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishapecollection/addgroupshape/); den resulterande gruppen innehåller redigerbara bildformer i stället för en enda SVG‑bild.

**Hur kan jag hålla presentationer med många bilder mindre?**

Återanvänd delade bildresurser, undvik onödigt stora rasterkällor, komprimera lämpliga rasterbilder när det är lämpligt, håll återkommande varumärkesgrafik på masters eller layouter, och använd länkade bilder endast när ett externt beroende är acceptabelt.