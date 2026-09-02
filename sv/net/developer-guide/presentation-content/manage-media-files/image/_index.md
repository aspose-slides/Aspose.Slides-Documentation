---
title: Optimera bildhantering i presentationer i .NET
linktitle: Hantera bilder
type: docs
weight: 10
url: /sv/net/image/
keywords:
- lägga till bild
- lägga till bild
- ersätta bild
- bildsamling
- bildram
- länkad bild
- bakgrund
- lägga till PNG
- lägga till JPG
- lägga till SVG
- SVG till former
- externa SVG-resurser
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur du lägger till, återanvänder, länkar, ersätter och hanterar raster- och SVG-bilder i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för .NET."
---
## **Introduktion**

Aspose.Slides för .NET erbjuder flera sätt att arbeta med bilder, och varje sätt har ett annat syfte. Du kan lagra en bild i en presentation, visa den i en bildram, använda den som bildbakgrund, länka till en extern bild, ersätta en delad bildresurs eller konvertera SVG-innehåll till redigerbara former.

Denna artikel fokuserar på bildresurser och hur de används i en presentation. För beskärning, genomskinlighet, effekter, sträckning och annan formatering som tillämpas på en enskild bildram, se [Bildram](/slides/sv/net/picture-frame/).

## **Förstå bildmodellen**

Följande API‑koncept är nära relaterade men inte utbytbara:

- Den [presentation image collection](https://reference.aspose.com/slides/sv/net/aspose.slides/iimagecollection/) lagrar bildresurser som används av presentationen. Använd [ImageCollection.AddImage](https://reference.aspose.com/slides/sv/net/aspose.slides/imagecollection/addimage/) för att lägga till bilddata och erhålla en [IPPImage](https://reference.aspose.com/slides/sv/net/aspose.slides/ippimage/)‑resurs.
- En [picture frame](https://reference.aspose.com/slides/sv/net/aspose.slides/ipictureframe/) är en form som visar en bild på en bild, layout eller master. Använd [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/ishapecollection/addpictureframe/) för att placera en bildresurs på en bild.
- En bildbakgrund använder en bild som en del av bildens fyllning snarare än som en form. Den fungerar därför inte som en bildram.
- [IPPImage.ReplaceImage](https://reference.aspose.com/slides/sv/net/aspose.slides/ippimage/replaceimage/) ersätter en bildresurs. Om flera presentationselement använder den resursen, använder de alla ersättningen.
- Att konvertera en SVG till former skapar redigerbara bildformer. Efter konverteringen hanteras innehållet inte längre som en bildresurs.

Ett typiskt arbetsflöde är därför: lägg till bilddata i bildsamlingen, mottag en [IPPImage](https://reference.aspose.com/slides/sv/net/aspose.slides/ippimage/), och använd sedan den resursen i en eller flera bildramar eller fyllningar.

## **Lägg till en inbäddad bild**

För att infoga en lokal bild, läs in filen, lägg till dess data i bildsamlingen och skapa en bildram som använder den returnerade `IPPImage`.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

Bilden som läggs till på detta sätt är inbäddad i presentationen, så den resulterande filen är inte beroende av att den ursprungliga bildfilen fortsatt är tillgänglig.

### **Lägg till en bild från webben**

När en bild är tillgänglig via HTTP eller HTTPS, hämta dess byte med `HttpClient`, lägg till dem i presentationens bildsamling och använd den returnerade bildresursen på samma sätt som en lokal bild.

```csharp
using System;
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.Export;

var imageUri = new Uri("https://example.com/image.png");
using var httpClient = new HttpClient();
var imageData = await httpClient.GetByteArrayAsync(imageUri);

using var presentation = new Presentation();

var image = presentation.Images.AddImage(imageData);
var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

presentation.Save("presentation-from-web.pptx", SaveFormat.Pptx);
```

I långlivade applikationer, återanvänd `HttpClient` i stället för att skapa en ny instans för varje begäran. Validera även fjärr‑URL‑er, svarsstorlekar och innehållstyper när källan inte är betrodd.

## **Återanvänd bilder på flera bilder**

Om samma bild behövs mer än en gång, lägg till den i presentationen en gång och återanvänd den returnerade [IPPImage](https://reference.aspose.com/slides/sv/net/aspose.slides/ippimage/) när du skapar ytterligare bildramar. Detta undviker att upprepade gånger ladda samma källdata och gör förhållandet mellan den delade bildresursen och dess användningar tydligt.

För grafik som ska visas automatiskt på många bilder, exempelvis en företagslogotyp, överväg att placera bildramen på en [bildmaster](/slides/sv/net/slide-master/) eller layout i stället för att lägga till en motsvarande form på varje bild.

## **Använd en bild som bildbakgrund**

En bakgrundsbild tilldelas bildens fyllning; den läggs inte till som en bildramform. Detta är användbart när bilden ska täcka bildens bakgrund och inte ska manipuleras som ett vanligt bildobjekt.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("background.jpg");
var image = presentation.Images.AddImage(imageData);
slide.Background.Type = BackgroundType.OwnBackground;
slide.Background.FillFormat.FillType = FillType.Picture;
slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
slide.Background.FillFormat.PictureFillFormat.Picture.Image = image;

presentation.Save("background-image.pptx", SaveFormat.Pptx);
```

För ytterligare bakgrundsalternativ, inklusive master‑ och layoutbakgrunder, se [Presentationsbakgrund](/slides/sv/net/presentation-background/).

## **Inbäddade bilder och länkade bilder**

Inbäddade och länkade bilder har olika kompromisser när det gäller portabilitet och filstorlek:

- **Inbäddad bild:** bilddata lagras i presentationen. Presentationen är självständig, men filstorleken inkluderar bilddata.
- **Länkad bild:** presentationen lagrar en sökväg eller URL till en extern bild. Detta kan minska presentationens storlek, men den externa resursen måste förbli tillgänglig när presentationen öppnas eller renderas.

En länkad bild kan skapas genom att tilldela den externa sökvägen eller URL‑en via [ISlidesPicture.LinkPathLong](https://reference.aspose.com/slides/sv/net/aspose.slides/islidespicture/linkpathlong/) i stället för att bädda in bilddata.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, null);
pictureFrame.PictureFormat.Picture.LinkPathLong = "https://example.com/image.png";

presentation.Save("linked-image.pptx", SaveFormat.Pptx);
```

Använd länkade bilder endast när driftsmiljön på ett pålitligt sätt kan nå den externa resursen. För presentationer som måste fungera offline eller flyttas mellan system är inbäddade bilder vanligtvis säkrare.

## **Arbeta med SVG‑bilder**

SVG är ett vektorformat, så det kan vara användbart för ikoner, diagram och annan grafik som ska skalas utan samma detaljförlust som rasterbilder. Aspose.Slides stöder SVG både som en bildresurs och som källa för redigerbara bildformer.

### **Lägg till en SVG som bild**

Skapa en [SvgImage](https://reference.aspose.com/slides/sv/net/aspose.slides/svgimage/), lägg till den i bildsamlingen och placera den resulterande bildresursen i en bildram.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = File.ReadAllText("icon.svg");
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();

var image = presentation.Images.AddImage(svgImage);
var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image);

presentation.Save("svg-image.pptx", SaveFormat.Pptx);
```

### **SVG‑filer med externa resurser**

En SVG kan referera till externa bilder, stilmallar eller teckensnitt. För dessa fall erbjuder [SvgImage](https://reference.aspose.com/slides/sv/net/aspose.slides/svgimage/) konstruktorer som accepterar en [IExternalResourceResolver](https://reference.aspose.com/slides/sv/net/aspose.slides.import/iexternalresourceresolver/) och en baskatalog‑URI. Resolvern kan mappa en relativ URI till en tillåten absolut URI och returnera en ström för den begärda resursen.

Resolvern gör externa resurser tillgängliga medan Aspose.Slides bearbetar SVG:n, men den omskriver inte SVG:n till ett självständigt dokument. Om SVG:n måste förbli portabel, bädda in dess nödvändiga resurser i själva SVG:n, till exempel genom att använda `data:`‑URI‑er för länkade bilder.

När SVG‑filer kommer från opålitliga källor, begränsa de scheman, filplatser och värdar som resolvern kan komma åt. Nätverks‑resolvers bör också tillämpa tidsgränser, begränsningar för svarsstorlek och innehållsvalidering.

### **Konvertera SVG till redigerbara former**

Aspose.Slides kan konvertera en SVG till en grupp av redigerbara bildformer, liknande motsvarande PowerPoint‑kommando.

![PowerPoint Popup Menu](img_01_01.png)

Använd överbelastningen av [IShapeCollection.AddGroupShape](https://reference.aspose.com/slides/sv/net/aspose.slides/ishapecollection/addgroupshape/) som accepterar en [ISvgImage](https://reference.aspose.com/slides/sv/net/aspose.slides/isvgimage/) för att utföra konverteringen.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = File.ReadAllText("diagram.svg");
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var slide = presentation.Slides[0];
slide.Shapes.AddGroupShape(svgImage, 0, 0, slideSize.Width, slideSize.Height);

presentation.Save("editable-svg-shapes.pptx", SaveFormat.Pptx);
```

Använd SVG‑till‑former‑konvertering när enskilda vektorelement behöver redigeras som PowerPoint‑former. Om SVG:n bara ska visas är det enklare att behålla den som en bild och undvika att skapa många separata former.

## **Ersätt en befintlig bildresurs**

Använd [IPPImage.ReplaceImage](https://reference.aspose.com/slides/sv/net/aspose.slides/ippimage/replaceimage/) när du vill ersätta en befintlig bildresurs. Detta är särskilt användbart för delad grafik såsom logotyper.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var imageToReplace = presentation.Images[0];
imageToReplace.ReplaceImage(File.ReadAllBytes("new-logo.png"));

presentation.Save("output.pptx", SaveFormat.Pptx);
```

Om flera bildramar, bakgrunder, masters eller layouter använder samma bildresurs, uppdaterar ersättningen av den resursen alla dessa användningar. Om bara en bildram ska ändras, tilldela en annan bild till den ramen i stället för att ersätta den delade resursen.

`ReplaceImage` erbjuder också överbelastningar som accepterar en [IImage](https://reference.aspose.com/slides/sv/net/aspose.slides/iimage/) eller en annan [IPPImage](https://reference.aspose.com/slides/sv/net/aspose.slides/ippimage/).

## **Praktisk vägledning för bildhantering**

### **Kontrollera presentationens storlek**

Stora rasterbilder kan göra en presentation onödigt stor. Använd källbilder med dimensioner som är lämpliga för den avsedda visningsstorleken, återanvänd delade bildresurser där det är möjligt och undvik att bädda in upprepade kopior av samma bild med full upplösning.

För rasterbilder som redan har placerats i bildramar kan [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/sv/net/aspose.slides/ipicturefillformat/compressimage/) minska bilddata enligt den valda upplösningen och beskärningsinställningarna. Detta är bildram‑behandling snarare än bildsamling‑hantering, så se [Bildram](/slides/sv/net/picture-frame/) för relaterade formateringsåtgärder.

### **Välj mellan inbäddat och länkat innehåll**

Inbäddning gör presentationen portabel eftersom all nödvändig bilddata följer med filen. Länkning kan minska filstorleken, men det inför ett externt beroende. Använd länkar endast när detta beroende är acceptabelt och stabilt.

### **Återanvänd delad varumärkesgrafik**

För upprepade logotyper, vattenmärken eller dekorativa bilder, använd en bildresurs och återanvänd den. Om grafiken tillhör presentationens design snarare än bildinnehållet, placera den på en master eller layout så att den ärvs av de aktuella bilderna.

### **Håll SVG‑resurser portabla**

En självständig SVG är enklare att flytta och rendera konsekvent än en SVG som är beroende av externa filer eller nätverksresurser. När det är möjligt, bädda in nödvändiga resurser innan SVG:n importeras. Konvertera SVG till former endast när de enskilda vektorelementen behöver redigeras.

### **Använd det moderna plattformsoberoende bild‑API:et**

För ny .NET‑kod, använd Aspose.Slides‑[IImage](https://reference.aspose.com/slides/sv/net/aspose.slides/iimage/) och [Images](https://reference.aspose.com/slides/sv/net/aspose.slides/images/)‑API:erna i stället för att förlita dig på `System.Drawing.Image` eller `Bitmap`. Se [Modern API](/slides/sv/net/modern-api/) för migrationsvägledning.

WMF och EMF kräver särskild hänsyn. När dessa format passerar genom en [IImage](https://reference.aspose.com/slides/sv/net/aspose.slides/iimage/), konverterar [ImageCollection.AddImage](https://reference.aspose.com/slides/sv/net/aspose.slides/imagecollection/addimage/) metafilen till en raster‑PNG‑representation före infogning. Om bevarande av metafildata är viktigt, använd en ström‑baserad [ImageCollection.AddImage](https://reference.aspose.com/slides/sv/net/aspose.slides/imagecollection/addimage/)‑överbelastning i stället. Generering av EMF‑innehåll från kalkylblad eller andra produkter är ett separat integreringsarbetsflöde och ligger utanför denna artikels omfattning.

## **FAQ**

**Vad är skillnaden mellan bildsamlingen och en bildram?**

Bildsamlingen lagrar återanvändbara bildresurser. En bildram är en bildform som visar en av dessa resurser och tillhandahåller bildspecifik formatering såsom beskärning och effekter.

**Vad är det bästa sättet att ersätta samma logotyp överallt?**

Om logotypen redan delas som en bildresurs, ersätt den resursen med [IPPImage.ReplaceImage](https://reference.aspose.com/slides/sv/net/aspose.slides/ippimage/replaceimage/). För varumärkesprofilering i hela presentationen kan placering av logotypen på en master eller layout också minska duplicerat bildinnehåll.

**Varför försvinner en länkad bild på en annan dator?**

En länkad bild är beroende av sin externa fil eller URL. Om den resursen inte kan nås från den andra datorn kan den länkade bilden vara otillgänglig. Bädda in bilden när presentationen måste vara självständig.

**Kan en infogad SVG redigeras som PowerPoint‑former?**

Ja. Konvertera SVG:n med [IShapeCollection.AddGroupShape](https://reference.aspose.com/slides/sv/net/aspose.slides/ishapecollection/addgroupshape/); den resulterande gruppen innehåller redigerbara bildformer snarare än en SVG‑bild.

**Hur kan jag hålla presentationer med många bilder mindre?**

Återanvänd delade bildresurser, undvik onödigt stora rasterkällor, komprimera lämpliga rasterbilder när det är lämpligt, håll återkommande varumärkesgrafik på masters eller layouter, och använd länkade bilder endast när ett externt beroende är acceptabelt.