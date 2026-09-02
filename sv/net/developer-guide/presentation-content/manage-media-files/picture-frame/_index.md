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
- bildramformatering
- relativ skala
- bildeffekt
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

En bildram är en bildform på en bild som visar en bild. I Aspose.Slides är bildresursen och formen som visar den separata objekt: en [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) äger inbäddade bildresurser via sin [Images](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/images/)‑samling, medan en [IPictureFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/ipictureframe/) styr bildens position, storlek, linjeformatering, rotation, beskärning, bildeffekter och andra ram‑nivåinställningar.

Denna separation är användbar när samma bild visas mer än en gång. Lägg till bilden i presentationen en gång, behåll den returnerade [IPPImage](https://reference.aspose.com/slides/sv/net/aspose.slides/ippimage/), och använd den bildresursen när du skapar bildramar.

Bildramar kan innehålla rasterbilder såsom PNG eller JPEG och vektorbilder i SVG-format. De kan också referera till länkade bilder istället för att lagra bildens byte‑data i presentationen. valet påverkar portabilitet, filstorlek, extrahering och exportbeteende, så det är bra att bestämma hur bilden ska lagras innan formatering eller optimering appliceras.

## **Lägg till och formatera en inbäddad bild**

För en inbäddad bild, lägg till bilddata i presentationen och skapa en bildram med [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/ishapecollection/addpictureframe/). Bilden blir en del av presentationspaketet, så presentationen förblir självständig när den flyttas till en annan dator.

Följande exempel lägger till en JPEG‑bild, skapar en ram i bildens ursprungliga dimensioner och tillämpar linjeformatering samt rotation:
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

Bildramen styr den visade geometrin; att ändra ramens storlek förändrar inte de ursprungliga pixeldimensionerna som lagras i den inbäddade bildresursen. Detta är viktigt när bilden beskärs eller komprimeras senare.

## **Använd relativ skala**

[IPictureFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/ipictureframe/) visar relativ bredd‑ och höjdskalning för ramen. Värdet `1.0` motsvarar 100 % av den ursprungliga bildstorleken. Relativ skala är användbar när ett arbetsflöde måste bevara förhållandet till källbildens storlek istället för att manuellt beräkna slutdimensioner.

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

Relativ skala förändrar ramens skaleinställningar; den återprovar eller komprimerar inte den inbäddade bilden.

## **Inbäddade och länkade bilder**

En inbäddad bild lagrar bilddata i presentationen och är därför det säkraste valet för portabilitet och förutsägbar rendering. En länkad bild lagrar en extern plats via [ISlidesPicture](https://reference.aspose.com/slides/sv/net/aspose.slides/islidespicture/)‑länkvägen istället för att bädda in bilddata på samma sätt.

Länkade bilder kan minska mängden bilddata som lagras i PPTX, men de introducerar ett externt beroende. Den länkade filen måste förbli tillgänglig för den applikation som öppnar eller renderar presentationen. Om sökvägen ändras, filen flyttas eller resursen är otillgänglig kan den länkade bilden visas felaktigt. För presentationer som måste e‑postas, arkiveras eller renderas i isolerade miljöer är inbäddade bilder vanligtvis mer pålitliga.

### **Lägg till en länkad bild**

Följande exempel skapar en bildram och pekar den på en lokal bildfil. Det hanterar bara bildlänkning; videolänkning är ett separat mediaprocessflöde och har avsiktligt inte blandats i detta exempel.
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

Använd länkar när extern filhantering är avsiktlig. Använd dem inte enbart som ett ersättningsalternativ för komprimering: en liten PPTX med trasiga bildberoenden är vanligtvis mindre användbar än en större självständig presentation.

## **Extrahera bilder från bildramar**

Innan du extraherar en bild från en befintlig presentation, kontrollera att en form faktiskt är en [IPictureFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/ipictureframe/) och att den innehåller en inbäddad bild. Länkade bildramar kanske inte innehåller bildbyte som kan extraheras på samma sätt.

### **Extrahera en rasterbild**

Det moderna bild‑API‑et använder [IImage](https://reference.aspose.com/slides/sv/net/aspose.slides/iimage/) direkt och kräver inte den äldre system‑bild‑omslutaren. Följande exempel hittar den första inbäddade rasterbilden på en bild och sparar den som PNG:
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

Att spara via [IImage](https://reference.aspose.com/slides/sv/net/aspose.slides/iimage/) konverterar den extraherade bilden till det begärda utskriftsformatet. Om du behöver de kodade byte‑data som lagras i presentationen snarare än en konverterad rasterfil, använd bildresursens binära data istället.

### **Extrahera en SVG‑bild**

För en SVG‑bild exponeras ett [ISvgImage](https://reference.aspose.com/slides/sv/net/aspose.slides/isvgimage/)‑objekt via [IPPImage](https://reference.aspose.com/slides/sv/net/aspose.slides/ippimage/). Detta låter dig hämta SVG‑data direkt istället för att rasterisera bilden först.
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

Att behålla SVG‑innehåll som SVG bevarar vektor‑källan i presentationen. Rasterexport som PNG eller JPEG renderar nödvändigtvis vektor­innehållet till pixlar. PDF‑ eller SVG‑bildexport är också en renderingsoperation, så de exporterade grafikerna bör inte behandlas som en exakt byte‑för‑byte‑kopi av den ursprungliga inbäddade SVG‑filen; använd den inbäddade [ISvgImage](https://reference.aspose.com/slides/sv/net/aspose.slides/isvgimage/)‑datat när den ursprungliga vektorresursen själv krävs.

## **Beskär en bild**

Beskärning ändrar vilken del av en bild som är synlig i ramen. Beskärningsvärdena på [IPictureFillFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/ipicturefillformat/) är procent av källbildens dimensioner. Beskärning tar initialt inte bort de dolda pixlarna från den inbäddade bilden; den ändrar bara det synliga området.

Följande exempel hittar en bildram på ett säkert sätt och tillämpar beskärningsvärden:
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

## **Ta bort beskurna bilddata**

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

Metoden kan lägga till en ny bildresurs i presentationen. Om den ursprungliga bilden också används av andra bildramar behöver dessa ramverk fortfarande sin befintliga resurs, så att ta bort beskärda områden minskar inte nödvändigtvis det totala antalet bilder. Att beskära WMF‑ eller EMF‑innehåll med denna metod rasteriserar det beskärda resultatet till PNG.

## **Komprimera rasterbilder**

[IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/sv/net/aspose.slides/ipicturefillformat/compressimage/) minskar rasterbildens upplösning i förhållande till den storlek som bilden visas i. Det kan också ta bort beskärda områden i samma operation. Metoden returnerar `true` när bilden har storleksändrats eller beskärts och `false` när ingen förändring var nödvändig.

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

Ett eget positivt DPI‑värde kan anges istället för ett enum‑värde när ett specifikt mål krävs.

Komprimering är avsedd för rasterbilder. SVG‑ och metafilinnehåll reduceras inte av detta rasterkomprimeringsflöde. Kom också ihåg att lägre upplösning och borttagna beskärda områden inte kan återställas från den optimerade presentationen. Välj en målupplösning baserat på den största storlek som bilden faktiskt kommer att visas eller exporteras i, snarare än att tillämpa den lägsta DPI:n globalt.

## **Inspektera bildeffekter**

Bildeffekter lagras på bilden som används av ramen. Bildtransformationssamlingen kan innehålla effekter såsom fast alfa‑modulering för transparens och luminans för ljusstyrka och kontrast. Exemplet nedan läser säkert båda typerna av effekter från den första bildramen på en bild:
```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    foreach (var effect in pictureFrame.PictureFormat.Picture.ImageTransform)
    {
        if (effect is IAlphaModulateFixed alphaModulateFixed)
        {
            var transparency = 100 - alphaModulateFixed.Amount;
            Console.WriteLine("Transparency: " + transparency);
        }

        if (effect is ILuminance luminanceEffect)
        {
            var luminance = luminanceEffect.GetEffective();
            Console.WriteLine("Brightness: " + luminance.Brightness);
            Console.WriteLine("Contrast: " + luminance.Contrast);
        }
    }
}
```

Dessa effekter förändrar hur bilden renderas i ramen; de skriver inte om de ursprungliga inbäddade bild‑byten.

## **Lås bildramens geometri**

[IPictureFrameLock](https://reference.aspose.com/slides/sv/net/aspose.slides/ipictureframelock/)‑inställningarna styr vilka redigeringsåtgärder som är inaktiverade för en bildram. Till exempel bevarar låset för bildförhållandet figurens proportioner under en storleksändring.
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

Låset gäller bildramens form. Det tvingar inte källbilden att återprovas eller permanent ändras till samma bildförhållande.

## **Justera StretchOffset‑värdena**

När bildfyllningsläget är stretch definierar stretch‑offset‑värdena på [IPictureFillFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/ipicturefillformat/) fyllningsrektangeln relativt bildramens omgivande ruta. Positiva procentandelar skapar ett infog från en kant, medan negativa procentandelar skapar ett utsprång.

Detta skiljer sig från beskärning. Beskärningsvärden väljer vilken del av källbilden som är synlig; stretch‑offset förändrar rektangeln som den synliga bildfyllningen sträcks in i.
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

Använd stretch‑offset för placering av fyllning. Använd beskärningsegenskaper när målet är att dölja kanterna på källbilden.

## **Lagring, filstorlek och exportaspekter**

De viktigaste avvägningarna blir enklare att hantera när bildlagring och bildramformatering behandlas separat:

- **Inbäddade bilder** gör presentationen självständig och är de mest pålitliga för delning och server‑sidig rendering, men stora rasterbilder ökar PPTX‑storlek och minnesanvändning.
- **Länkade bilder** kan hålla paketet mindre, men presentationen är beroende av att externa filer förblir tillgängliga på de lagrade sökvägarna eller platserna.
- **Beskärning** är initialt icke‑destruktiv. De dolda pixlarna förblir inbäddade tills beskärda områden explicit tas bort eller tas bort under komprimering.
- **Komprimering** kan minska filstorleken avsevärt för överdimensionerade rasterbilder, men den offrar källupplösning. Den bör appliceras efter att den avsedda storleken på bilden är känd.
- **SVG‑bilder** bör förbli som SVG när vektorbevarande är viktigt. Extrahera den inbäddade SVG‑filen direkt när du behöver vektorresursen själv. Raster‑slide‑exporter konverterar alltid den renderade sliden till pixlar.
- **Upprepade bilder** bör återanvända en befintlig [IPPImage](https://reference.aspose.com/slides/sv/net/aspose.slides/ippimage/)‑resurs när det är möjligt i stället för att upprepade gånger ladda samma fil i presentationsflödet.

För stora presentationer är bildoptimering vanligtvis mest effektiv när den utförs selektivt: behåll logotyper och diagram som vektor‑innehåll, komprimera fotografier enligt deras faktiska visningsstorlek, ta bort beskurna pixlar endast när senare redigering inte krävs, och undvik externa länkar såvida inte beroendehantering är en del av distributionsdesignen.

## **FAQ**

**Vad är skillnaden mellan en bildram och en bildresurs?**

En [IPPImage](https://reference.aspose.com/slides/sv/net/aspose.slides/ippimage/) representerar en bildresurs som är kopplad till presentationen. En [IPictureFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/ipictureframe/) är en form på en bild som visar en bild och lagrar ram‑nivå geometri och formatering såsom storlek, rotation, beskärningsvärden, effekter och lås.

**Ska jag bädda in eller länka bilder?**

Bädda in bilder när presentationen måste vara portabel, arkiverad eller renderas utan åtkomst till externa resurser. Länka bilder endast när det är avsiktligt att hålla bildfiler utanför PPTX och de externa platserna kan upprätthållas på ett tillförlitligt sätt.

**Minskar beskärning PPTX‑filens storlek?**

Inte i sig. Normala beskärningsinställningar döljer delar av källbilden men behåller de underliggande pixlarna. Använd [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/sv/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) eller bildkomprimering med borttagning av beskärda områden när dessa pixlar kan tas bort permanent.

**Kan jag återställa bildkvaliteten efter komprimering?**

Nej. Komprimering kan reducera den lagrade rasterupplösningen, och att ta bort beskärda områden kastar bilddata. Behåll den ursprungliga källbilden utanför presentationen om högupplöst redigering kan behövas senare.

**Hur bör SVG‑bilder hanteras?**

Behåll SVG‑innehåll som SVG när vektorprecision är viktig. Den inbäddade [ISvgImage](https://reference.aspose.com/slides/sv/net/aspose.slides/isvgimage/) kan extraheras direkt. Att rendera en bild till ett rasterformat som PNG eller JPEG rasteriserar SVG som en del av bildens bild.

**Hur kan jag undvika osäkra castar när jag läser befintliga bilder?**

Kontrollera formtypen innan du använder bildram‑specifika medlemmar. Mönstermatchning med [IPictureFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/ipictureframe/) eller filtrering av form‑samlingen efter det gränssnittet undviker ogiltiga castar och låter koden hantera bilder som inte innehåller bildramar.