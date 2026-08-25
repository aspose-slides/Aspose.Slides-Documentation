---
title: Hantera bildramar i presentationer i .NET
linktitle: Bildram
type: docs
weight: 10
url: /sv/net/picture-frame/
keywords:
- bildram
- lägga till bildram
- skapa bildram
- inbäddad bild
- länkad bild
- extrahera bild
- rasterbild
- SVG-bild
- beskära bild
- ta bort beskurna områden
- komprimera bild
- StretchOffset
- formatering av bildram
- relativ skalning
- billeffekt
- bildförhållande
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Skapa, formatera, länka, beskära, extrahera och komprimera bildramar i presentationer med Aspose.Slides för .NET."
---
## **Översikt**

En bildram är en bildform på en bildspelssida som visar en bild. I Aspose.Slides är bildresursen och formen som visar den separata objekt: en [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) äger inbäddade bildresurser via sin [Images](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/images/)-samling, medan en [IPictureFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/ipictureframe/) styr bildens position, storlek, linjeformatering, rotation, beskärning, bild‑effekter och andra ram‑nivåinställningar.

Denna separation är användbar när samma bild visas mer än en gång. Lägg till bilden i presentationen en gång, behåll den returnerade [IPPImage](https://reference.aspose.com/slides/sv/net/aspose.slides/ippimage/), och använd den bildresursen när du skapar bildramar.

Bildramar kan innehålla rasterbilder såsom PNG eller JPEG och vektor‑SVG‑bilder. De kan också referera till länkade bilder istället för att lagra bildbytarna i presentationen. Valet påverkar portabilitet, filstorlek, extrahering och exportbeteende, så det är bra att bestämma hur bilden ska lagras innan formatering eller optimering tillämpas.

## **Lägg till och formatera en inbäddad bild**

För en inbäddad bild, lägg till bilddata i presentationen och skapa en bildram med [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/ishapecollection/addpictureframe/). Bilden blir en del av presentationspaketet, så presentationen förblir självständig när den flyttas till en annan dator.

Följande exempel lägger till en JPEG‑bild, skapar en ram med bildens egna dimensioner och applicerar linjeformatering samt rotation:

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 100, image.Width, image.Height, image);
pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
pictureFrame.LineFormat.Width = 3;
pictureFrame.Rotation = 15;

presentation.Save("picture-frame.pptx", SaveFormat.Pptx);
```

Bildramen styr den visade geometrin; att ändra ramens storlek ändrar inte de ursprungliga pixelmåtten som lagras i den inbäddade bildresursen. Denna skillnad blir viktig när man beskär eller komprimerar en bild senare.

## **Använd relativ skalning**

[IPictureFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/ipictureframe/) visar relativ bredd‑ och höjds skalning för ramen. Ett värde på `1.0` motsvarar 100 % av den ursprungliga bildens storlek. Relativ skalning är användbar när ett arbetsflöde behöver bevara förhållandet till källbildens storlek istället för att beräkna slutdimensioner manuellt.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image);
pictureFrame.RelativeScaleWidth = 1.35f;
pictureFrame.RelativeScaleHeight = 0.8f;

presentation.Save("relative-scale.pptx", SaveFormat.Pptx);
```

Relativ skalning ändrar ramens skalningsinställningar; den återprovar eller komprimerar inte den inbäddade bilden.

## **Inbäddade och länkade bilder**

En inbäddad bild lagrar bilddata i presentationen och är därför det säkraste valet för portabilitet och förutsägbar rendering. En länkad bild lagrar en extern plats via [ISlidesPicture](https://reference.aspose.com/slides/sv/net/aspose.slides/islidespicture/)-länksökvägen istället för att på samma sätt bädda in bilddata.

Länkade bilder kan minska mängden bilddata som lagras i PPTX, men de introducerar ett externt beroende. Den länkade filen måste förbli tillgänglig för programmet som öppnar eller renderar presentationen. Om sökvägen ändras, filen flyttas eller resursen är otillgänglig, kanske den länkade bilden inte visas som förväntat. För presentationer som måste e‑postas, arkiveras eller renderas i isolerade miljöer är inbäddade bilder vanligtvis mer pålitliga.

### **Lägg till en länkad bild**

Följande exempel skapar en bildram och pekar den på en lokal bildfil. Det hanterar endast bildlänkning; videolänkning är ett separat mediaprocessflöde och är avsiktligt inte blandat i detta exempel.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, null);
pictureFrame.PictureFormat.Picture.LinkPathLong = Path.GetFullPath("linked-image.jpg");

presentation.Save("linked-image.pptx", SaveFormat.Pptx);
```

Använd länkar när extern filhantering är avsiktlig. Använd dem inte bara som ett ersättningsalternativ för komprimering: en liten PPTX med brutna bildberoenden är vanligtvis mindre användbar än en större självständig presentation.

## **Extrahera bilder från bildramar**

Innan du extraherar en bild från en befintlig presentation, kontrollera att en form faktiskt är en [IPictureFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/ipictureframe/) och att den innehåller en inbäddad bild. Länkade bildramar kanske inte innehåller bildbytar som kan extraheras på samma sätt.

### **Extrahera en rasterbild**

Det moderna bild‑API‑et använder [IImage](https://reference.aspose.com/slides/sv/net/aspose.slides/iimage/) direkt och kräver inte den äldre system‑bild‑omslutaren. Följande exempel hittar den första inbäddade raster‑bilden på en bild och sparar den som PNG:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IPictureFrame pictureFrame)
    {
        continue;
    }

    var embeddedImage = pictureFrame.PictureFormat.Picture.Image;
    if (embeddedImage == null || embeddedImage.SvgImage != null)
    {
        continue;
    }

    using var rasterImage = embeddedImage.Image;
    rasterImage.Save("extracted-image.png", Aspose.Slides.ImageFormat.Png);
    break;
}
```

Att spara via [IImage](https://reference.aspose.com/slides/sv/net/aspose.slides/iimage/) konverterar den extraherade bilden till det begärda utdataformatet. Om du behöver de kodade bytarna som lagras i presentationen istället för en konverterad rasterfil, använd bildresursens binära data istället.

### **Extrahera en SVG‑bild**

För en SVG‑bild exponeras ett [ISvgImage](https://reference.aspose.com/slides/sv/net/aspose.slides/isvgimage/)-objekt via [IPPImage](https://reference.aspose.com/slides/sv/net/aspose.slides/ippimage/). Detta låter dig hämta SVG‑data direkt istället för att rasterisera bilden först.

```csharp
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IPictureFrame pictureFrame)
    {
        continue;
    }

    var embeddedImage = pictureFrame.PictureFormat.Picture.Image;
    var svgImage = embeddedImage?.SvgImage;
    if (svgImage == null)
    {
        continue;
    }

    File.WriteAllBytes("extracted-image.svg", svgImage.SvgData);
    break;
}
```

Att behålla SVG‑innehållet som SVG bevarar vektorkällan i presentationen. Raster‑exporter såsom PNG eller JPEG renderar nödvändigtvis vektorinnehållet till pixlar. PDF‑ eller SVG‑slide‑export är också en renderingsoperation, så de exporterade grafikerna bör inte betraktas som en byte‑för‑byte‑kopiering av den ursprungliga inbäddade SVG:n; använd den inbäddade [ISvgImage](https://reference.aspose.com/slides/sv/net/aspose.slides/isvgimage/)‑datan när den ursprungliga vektorresursen själv krävs.

## **Beskär en bild**

Beskärning ändrar vilken del av en bild som är synlig i ramen. Beskärningsvärdena på [IPictureFillFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/ipicturefillformat/) är procentandelar av källbildens dimensioner. Beskärning tar initialt inte bort de dolda pixlarna från den inbäddade bilden; den ändrar bara den synliga regionen.

Följande exempel hittar en bildram på ett säkert sätt och applicerar beskärningsvärden:

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    pictureFrame.PictureFormat.CropLeft = 23.6f;
    pictureFrame.PictureFormat.CropRight = 21.5f;
    pictureFrame.PictureFormat.CropTop = 3f;
    pictureFrame.PictureFormat.CropBottom = 31f;
    presentation.Save("cropped-image.pptx", SaveFormat.Pptx);
}
```

Eftersom den dolda bilddatan fortfarande finns kvar kan beskärningen ändras senare utan att förlora de ursprungliga pixlarna. Om filstorlek är viktigare än återställbarhet kan de beskurna områdena tas bort fysiskt enligt beskrivningen i nästa avsnitt.

## **Ta bort beskärd bilddata**

[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/sv/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) tar bort bilddata utanför den aktuella beskärningsrektangeln och returnerar den resulterande bildresursen. Detta kan minska filstorleken, men det är en destruktiv optimering: efter att presentationen sparats är de borttagna pixlarna inte längre tillgängliga för en senare avbeskärning.

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("cropped-image.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var croppedImage = pictureFrame.PictureFormat.DeletePictureCroppedAreas();
    if (croppedImage != null)
    {
        presentation.Save("cropped-data-removed.pptx", SaveFormat.Pptx);
    }
}
```

Metoden kan lägga till en ny bildresurs i presentationen. Om den ursprungliga bilden även används av andra bildramar, behöver de ramarna fortfarande sin befintliga resurs, så att ta bort beskärda områden minskar inte nödvändigtvis det totala antalet bilder. Beskärning av WMF‑ eller EMF‑innehåll med denna metod rasteriserar det beskurna resultatet till PNG.

## **Komprimera rasterbilder**

[IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/sv/net/aspose.slides/ipicturefillformat/compressimage/) minskar rasterbildens upplösning i förhållande till den storlek som bilden visas i. Den kan också ta bort beskärda regioner i samma operation. Metoden returnerar `true` när bilden har ändrats i storlek eller beskärts och `false` när ingen förändring var nödvändig.

Använd ett fördefinierat [PicturesCompression](https://reference.aspose.com/slides/sv/net/aspose.slides.export/picturescompression/)‑värde när en standardmålupplösning är tillräcklig:

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var compressed = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);
    Console.WriteLine(compressed ? "The image was compressed." : "No compression was necessary.");
    presentation.Save("compressed-image.pptx", SaveFormat.Pptx);
}
```

Ett anpassat positivt DPI‑värde kan skickas istället för ett enum‑värde när ett specifikt mål krävs.

Komprimering är avsedd för rasterbilder. SVG‑ och metafil‑innehåll minskas inte av detta rasterkomprimeringsflöde. Kom också ihåg att lägre upplösning och borttagna beskärda regioner inte kan återställas från den optimerade presentationen. Välj en målupplösning baserat på den största storlek som bilden faktiskt kommer att visas eller exporteras i, snarare än att tillämpa den lägsta DPI:n globalt.

## **Hantera bildtransformeringseffekter**

För ett komplett arbetsflöde som täcker ljusstyrka, kontrast, färgtransformeringar, oskärpa, alfa‑effekter, ordnade kedjor, inspektion, borttagning och dubbelriktad verifiering, se [Image Transform Effects](/slides/sv/net/image-transform-effects/).

## **Låsa bildramens geometri**

[IPictureFrameLock](https://reference.aspose.com/slides/sv/net/aspose.slides/ipictureframelock/)‑inställningarna styr vilka redigeringsåtgärder som är inaktiverade för en bildram. Till exempel bevarar låsning av bildförhållandet formens proportioner när den skalas.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 100, image.Width, image.Height, image);
pictureFrame.PictureFrameLock.AspectRatioLocked = true;

presentation.Save("locked-picture-frame.pptx", SaveFormat.Pptx);
```

Låset gäller bildramformen. Det tvingar inte källbilden att återprovas eller permanent förändras till samma bildförhållande.

## **Justera StretchOffset‑värdena**

När bildfyllnadsläget är stretch definierar stretch‑offset‑värdena på [IPictureFillFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/ipicturefillformat/) fyllningsrektangeln relativt bildramens omgivningslåda. Positiva procent skapar en infogning från en kant, medan negativa procent skapar en utbuktning.

Detta skiljer sig från beskärning. Beskärningsvärden väljer vilken del av källbilden som är synlig; stretch‑offsets förändrar den rektangel som den synliga bildfyllnaden sträcks in i.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image);
pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
pictureFrame.PictureFormat.StretchOffsetLeft = 12f;
pictureFrame.PictureFormat.StretchOffsetRight = 12f;
pictureFrame.PictureFormat.StretchOffsetTop = 8f;
pictureFrame.PictureFormat.StretchOffsetBottom = 8f;

presentation.Save("stretch-offsets.pptx", SaveFormat.Pptx);
```

Använd stretch‑offsets för placering av fyllning. Använd beskärningsegenskaper när målet är att dölja kanter på källbilden.

## **Lagring, filstorlek och exportaspekter**

De viktigaste avvägningarna är enklare att hantera när bildlagring och bildramformatering behandlas separat:

- **Inbäddade bilder** gör presentationen självständig och är de mest pålitliga för delning och server‑sidig rendering, men stora rasterbilder ökar PPTX‑storlek och minnesanvändning.
- **Länkade bilder** kan hålla paketet mindre, men presentationen är beroende av att externa filer förblir tillgängliga på de lagrade sökvägarna eller platserna.
- **Beskärning** är initialt icke‑destruktiv. De dolda pixlarna förblir inbäddade tills beskärda områden explicit tas bort eller tas bort under komprimering.
- **Komprimering** kan minska filstorleken avsevärt för överdimensionerade rasterbilder, men den offrar källupplösning. Den bör tillämpas efter att den avsedda storleken på bilden på bilden är känd.
- **SVG‑bilder** bör förbli SVG när vektorbevarande är viktigt. Extrahera den inbäddade SVG:n direkt när du behöver vektorresursen själv. Raster‑slide‑exporter konverterar alltid den renderade sliden till pixlar.
- **Upprepade bilder** bör återanvända en befintlig [IPPImage](https://reference.aspose.com/slides/sv/net/aspose.slides/ippimage/)‑resurs när det är möjligt istället för att upprepade gånger ladda samma fil i presentationsarbetsflödet.

För stora presentationer är bildoptimering vanligtvis mest effektiv när den utförs selektivt: behåll logotyper och diagram som vektor­innehåll, komprimera fotografier enligt deras faktiska visningsstorlek, ta bort beskurna pixlar endast när senare redigering inte krävs, och undvik externa länkar om inte beroendehantering är en del av driftsdesignen.

## **FAQ**

**Vad är skillnaden mellan en bildram och en bildresurs?**

En [IPPImage](https://reference.aspose.com/slides/sv/net/aspose.slides/ippimage/) representerar en bildresurs som är kopplad till presentationen. En [IPictureFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/ipictureframe/) är en form på en bild som visar en bild och lagrar ram‑nivåens geometri och formatering såsom storlek, rotation, beskärningsvärden, effekter och lås.

**Bör jag bädda in eller länka bilder?**

Bädda in bilder när presentationen måste vara portabel, arkiverad eller renderad utan åtkomst till externa resurser. Länka bilder endast när det är avsiktligt att hålla bildfiler utanför PPTX och de externa platserna kan underhållas pålitligt.

**Minskar beskärning PPTX‑filstorleken?**

Inte i sig. Normala beskärningsinställningar döljer delar av källbilden men behåller de underliggande pixlarna. Använd [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/sv/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) eller bildkomprimering med borttagning av beskärda områden när dessa pixlar kan slängas permanent.

**Kan jag återställa bildkvaliteten efter komprimering?**

Nej. Komprimering kan minska den lagrade rasterupplösningen, och att ta bort beskärda regioner kastar bilddata. Behåll originalkällbilden utanför presentationen om senare redigering med hög upplösning kan behövas.

**Hur bör SVG‑bilder hanteras?**

Behåll SVG‑innehållet som SVG när vektorfidelitet är viktig. Den inbäddade [ISvgImage](https://reference.aspose.com/slides/sv/net/aspose.slides/isvgimage/) kan extraheras direkt. Att rendera en slide till ett rasterformat såsom PNG eller JPEG rasteriserar SVG:n som en del av slide‑bilden.

**Hur kan jag undvika osäkra kast när jag läser befintliga slides?**

Kontrollera formtypen innan du använder bildram‑specifika medlemmar. Mönstermatchning med [IPictureFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/ipictureframe/) eller filtrering av formkollektionen efter det gränssnittet undviker ogiltiga kast och låter koden hantera slides som inte innehåller bildramar.