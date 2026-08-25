---
title: Hantera bildramar i presentationer med C++
linktitle: Bildram
type: docs
weight: 10
url: /sv/cpp/picture-frame/
keywords:
- bildram
- lägg till bildram
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
- relativ skalning
- bildeffekt
- bildförhållande
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Skapa, formatera, länka, beskära, extrahera och komprimera bildramar i presentationer med Aspose.Slides för C++."
---
## **Översikt**

En bildram är en bildform på en bildspel som visar en bild. I Aspose.Slides är bildresursen och formen som visar den separata objekt: en [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) äger inbäddade bildresurser via sin [bildsamling](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_images/), medan en [IPictureFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipictureframe/) styr bildens position, storlek, linjeformatering, rotation, beskärning, bild‑effekter och andra ram‑nivåinställningar.

Denna separation är användbar när samma bild visas mer än en gång. Lägg till bilden i presentationen en gång, behåll den returnerade [IPPImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ippimage/), och använd den bildresursen när du skapar bildramar.

Bildramar kan innehålla rasterbilder såsom PNG eller JPEG samt vektor‑SVG‑bilder. De kan också referera till länkade bilder istället för att lagra bild‑bytes i presentationen. Valet påverkar portabilitet, filstorlek, extrahering och exportbeteende, så det är bra att bestämma hur bilden ska lagras innan formatering eller optimering tillämpas.

## **Lägg till och formatera en inbäddad bild**

För en inbäddad bild lägger du till bilddata i presentationen och skapar en bildram med [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/shapecollection/addpictureframe/). Bilden blir en del av presentationspaketet, så presentationen förblir självständig när den flyttas till en annan dator.

Följande exempel lägger till en JPEG‑bild, skapar en ram med bildens ursprungliga dimensioner och tillämpar linjeformatering och rotation:

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 100, image->get_Width(), image->get_Height(), image);
pictureFrame->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pictureFrame->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pictureFrame->get_LineFormat()->set_Width(3.0);
pictureFrame->set_Rotation(15.0f);

presentation->Save(u"picture-frame.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Bildramen styr den visade geometrin; att ändra ramens storlek ändrar inte de ursprungliga pixelmåtten som lagras i den inbäddade bildresursen. Denna skillnad blir viktig när man beskär eller komprimerar en bild senare.

## **Använd relativ skalning**

[IPictureFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipictureframe/) exponerar relativ bredd‑ och höjds‑skalning för ramen. Ett värde på `1.0` motsvarar 100 % av den ursprungliga bildstorleken. Relativ skalning är användbart när ett arbetsflöde behöver bevara förhållandet till källbildens storlek istället för att manuellt beräkna slutdimensioner.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, image);
pictureFrame->set_RelativeScaleWidth(1.35f);
pictureFrame->set_RelativeScaleHeight(0.8f);

presentation->Save(u"relative-scale.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Relativ skalning ändrar ramens skalningsinställningar; den samplar inte om eller komprimerar den inbäddade bilden.

## **Inbäddade och länkade bilder**

En inbäddad bild lagrar bilddata i presentationen och är därför det säkraste valet för portabilitet och förutsägbar rendering. En länkad bild lagrar en extern plats via [ISlidesPicture](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidespicture/)‑länksökvägen istället för att på samma sätt bädda in bilddata.

Länkade bilder kan minska mängden bilddata som lagras i PPTX, men de inför ett externt beroende. Den länkade filen måste förbli tillgänglig för programmet som öppnar eller renderar presentationen. Om sökvägen ändras, filen flyttas eller resursen är otillgänglig kan den länkade bilden kanske inte visas som förväntat. För presentationer som måste e‑postas, arkiveras eller renderas i isolerade miljöer är inbäddade bilder vanligtvis mer tillförlitliga.

### **Lägg till en länkad bild**

Följande exempel skapar en bildram och pekar den på en lokal bildfil. Det hanterar endast bildlänkning; videolänkning är ett separat medie‑arbetsflöde och har medvetet inte blandats in i detta exempel.

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 320, 180, nullptr);
auto linkPath = Path::GetFullPath(u"linked-image.jpg");
pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(linkPath);

presentation->Save(u"linked-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Använd länkar när hantering av externa filer är avsiktlig. Använd dem inte bara som ett ersättningsmedel för komprimering: en liten PPTX med brutna bildberoenden är oftast mindre användbar än en större självständig presentation.

## **Extrahera bilder från bildramar**

Innan du extraherar en bild från en befintlig presentation, kontrollera att en form faktiskt är en [IPictureFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipictureframe/) och att den innehåller en inbäddad bild. Länkade bildramar kanske inte innehåller bild‑bytes som kan extraheras på samma sätt.

### **Extrahera en rasterbild**

Den moderna bild‑API:n använder [IImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iimage/) direkt. Följande exempel hittar den första inbäddade rasterbilden på en bild och sparar den som PNG:

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IPictureFrame>(shape))
    {
        continue;
    }

    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto embeddedImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image();
    if (embeddedImage == nullptr || embeddedImage->get_SvgImage() != nullptr)
    {
        continue;
    }

    auto rasterImage = embeddedImage->get_Image();
    rasterImage->Save(u"extracted-image.png", ImageFormat::Png);
    break;
}

presentation->Dispose();
```

Att spara via [IImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iimage/) konverterar den extraherade bilden till det begärda utskriftsformatet. Om du behöver de kodade bytes som lagras i presentationen snarare än en konverterad rasterfil, använd bildresursens binära data istället.

### **Extrahera en SVG‑bild**

För en SVG‑bild exponerar [IPPImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ippimage/) ett [ISvgImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isvgimage/)‑objekt. Detta låter dig hämta SVG‑data direkt istället för att rasterisera bilden först.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IPictureFrame>(shape))
    {
        continue;
    }

    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto embeddedImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image();
    if (embeddedImage == nullptr)
    {
        continue;
    }

    auto svgImage = embeddedImage->get_SvgImage();
    if (svgImage == nullptr)
    {
        continue;
    }

    File::WriteAllBytes(u"extracted-image.svg", svgImage->get_SvgData());
    break;
}

presentation->Dispose();
```

Att behålla SVG‑innehållet som SVG bevarar vektorkällan i presentationen. Rasterexporter såsom PNG eller JPEG renderar nödvändigtvis den vektorgrafiken till pixlar. PDF‑ eller SVG‑bildexport är också en renderingsoperation, så de exporterade grafikerna bör inte betraktas som en exakt byte‑för‑byte‑kopia av den ursprungliga inbäddade SVG‑filen; använd den inbäddade [ISvgImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isvgimage/)‑datan när den ursprungliga vektorresursen själv krävs.

## **Beskär en bild**

Beskärning ändrar vilken del av en bild som är synlig i ramen. Beskärningsvärdena på [IPictureFillFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipicturefillformat/) är procentandelar av källbildens dimensioner. Beskärning tar initialt inte bort de gömda pixlarna från den inbäddade bilden; den ändrar bara den synliga regionen.

Följande exempel hittar en bildram på ett säkert sätt och tillämpar beskära värden:

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    pictureFrame->get_PictureFormat()->set_CropLeft(23.6f);
    pictureFrame->get_PictureFormat()->set_CropRight(21.5f);
    pictureFrame->get_PictureFormat()->set_CropTop(3.0f);
    pictureFrame->get_PictureFormat()->set_CropBottom(31.0f);
    presentation->Save(u"cropped-image.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

Eftersom den gömda bilddatan fortfarande finns kvar kan beskärningen ändras senare utan att förlora de ursprungliga pixlarna. Om filstorlek är viktigare än återställningsmöjlighet kan de beskurna områdena fysiskt tas bort som beskrivs i nästa avsnitt.

## **Ta bort beskärda bilddata**

[IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) tar bort bilddata utanför den aktuella beskärningsrektangeln och returnerar den resulterande bildresursen. Detta kan minska filstorleken, men det är en destruktiv optimering: efter att presentationen sparats är de borttagna pixlarna inte längre tillgängliga för en senare avbeskära‑operation.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"cropped-image.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto croppedImage = pictureFrame->get_PictureFormat()->DeletePictureCroppedAreas();
    if (croppedImage != nullptr)
    {
        presentation->Save(u"cropped-data-removed.pptx", SaveFormat::Pptx);
    }
}

presentation->Dispose();
```

Metoden kan lägga till en ny bildresurs i presentationen. Om den ursprungliga bilden också används av andra bildramar behåller dessa sina befintliga resurser, så att ta bort beskärda områden inte nödvändigtvis minskar det totala antalet bilder. Beskärning av WMF‑ eller EMF‑innehåll med denna metod rasteriserar det beskurna resultatet till PNG.

## **Komprimera rasterbilder**

[IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipicturefillformat/compressimage/) minskar rasterbildens upplösning i förhållande till den storlek vid vilken bilden visas. Den kan också ta bort beskärda regioner i samma operation. Metoden returnerar `true` när bilden har storleksändrats eller beskärts och `false` när ingen förändring var nödvändig.

Använd ett fördefinierat [PicturesCompression](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/picturescompression/)‑värde när en standardmålupplösning är tillräcklig:

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto compressed = pictureFrame->get_PictureFormat()->CompressImage(true, PicturesCompression::Dpi150);
    Console::WriteLine(compressed ? String(u"The image was compressed.") : String(u"No compression was necessary."));
    presentation->Save(u"compressed-image.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

Ett eget positivt DPI‑värde kan skickas istället för ett enum‑värde när ett specifikt mål krävs.

Komprimering är avsedd för rasterbilder. SVG‑ och metafil‑innehåll reduceras inte av detta rasterkomprimerings‑arbetsflöde. Kom också ihåg att lägre upplösning och borttagna beskärda regioner inte kan återställas från den optimerade presentationen. Välj en målupplösning baserat på den största storlek som bilden faktiskt kommer att visas eller exporteras i, snarare än att tillämpa den lägsta DPI:n globalt.

## **Hantera bildtransformeringseffekter**

För ett komplett arbetsflöde som täcker ljusstyrka, kontrast, färgtransformeringar, oskärpa, alfa‑effekter, ordnade kedjor, inspektion, borttagning och round‑trip‑verifiering, se [Image Transform Effects](/slides/sv/cpp/image-transform-effects/).

## **Lås bildramens geometri**

[IPictureFrameLock](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipictureframelock/)‑inställningarna styr vilka redigeringsåtgärder som inaktiveras för en bildram. Till exempel bevarar [aspect‑ratio lock](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) ramens proportioner medan den skalas.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 100, image->get_Width(), image->get_Height(), image);
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);

presentation->Save(u"locked-picture-frame.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Låset gäller bildramens form. Det tvingar inte källbilden att samplas om eller ändras permanent till samma bildförhållande.

## **Justera StretchOffset‑värdena**

När bildfyllnadsläget är stretch definierar stretch‑offset‑värdena på [IPictureFillFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipicturefillformat/) fyllningsrektangeln relativt bildramens begränsningsruta. Positiva procenttal skapar ett innerspalt från en kant, medan negativa procenttal skapar ett utsprång.

Detta skiljer sig från beskärning. Beskärningsvärden väljer vilken del av källbilden som är synlig; stretch‑offset förändrar den rektangel som den synliga bildfyllnaden sträcks in i.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.png");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10, 10, 400, 300, image);
pictureFrame->get_PictureFormat()->set_PictureFillMode(PictureFillMode::Stretch);
pictureFrame->get_PictureFormat()->set_StretchOffsetLeft(12.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetRight(12.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetTop(8.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetBottom(8.0f);

presentation->Save(u"stretch-offsets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Använd stretch‑offset för placering av fyllning. Använd beskärnings‑egenskaper när målet är att dölja kanter i källbilden.

## **Lagring, filstorlek och exportaspekter**

De viktigaste avvägningarna blir enklare att hantera när bildlagring och bildram‑formatering behandlas separat:

- **Inbäddade bilder** gör presentationen självintegrerad och är den mest pålitliga för delning och server‑sida rendering, men stora rasterbilder ökar PPTX‑storlek och minnesanvändning.
- **Länkade bilder** kan hålla paketet mindre, men presentationen är beroende av att externa filer förblir tillgängliga på de lagrade sökvägarna eller platserna.
- **Beskärning** är initialt icke‑destruktiv. De dolda pixlarna förblir inbäddade tills beskärda områden explicit tas bort eller tas bort under komprimering.
- **Komprimering** kan reducera filstorleken avsevärt för överdimensionerade rasterbilder, men den offrar källupplösning. Den bör tillämpas efter att den avsedda storleken på bilden i sliden är känd.
- **SVG‑bilder** bör behållas som SVG när vektorbevarande är viktigt. Extrahera den inbäddade SVG:n direkt när du behöver själva vektorresursen. Raster‑slide‑exporter konverterar alltid den renderade sliden till pixlar.
- **Upprepade bilder** bör återanvända en befintlig [IPPImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ippimage/)‑resurs när det är möjligt istället för att upprepade gånger ladda samma fil i presentationsarbetsflödet.

För stora presentationer är bildoptimering vanligtvis mest effektiv när den utförs selektivt: behåll logotyper och diagram som vektor‑innehåll, komprimera fotografier enligt deras faktiska visningsstorlek, ta bort beskurna pixlar endast när senare redigering inte krävs, och undvik externa länkar om inte beroendehantering är en del av distributionsdesignen.

## **FAQ**

**Vad är skillnaden mellan en bildram och en bildresurs?**

En [IPPImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ippimage/) representerar en bildresurs som är associerad med presentationen. En [IPictureFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipictureframe/) är en form på en slide som visar en bild och lagrar ram‑nivågeometri och formatering såsom storlek, rotation, beskärningsvärden, effekter och lås.

**Ska jag bädda in eller länka bilder?**

Bädda in bilder när presentationen måste vara portabel, arkiverad eller renderas utan åtkomst till externa resurser. Länka bilder endast när det är avsiktligt att hålla bildfilerna utanför PPTX och de externa platserna kan underhållas på ett tillförlitligt sätt.

**Minskar beskärning PPTX‑filstorleken?**

Inte i sig. Vanliga beskärningsinställningar döljer delar av källbilden men behåller de underliggande pixlarna. Använd [IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) eller bildkomprimering med borttagning av beskärda områden när dessa pixlar kan tas bort permanent.

**Kan jag återställa bildkvaliteten efter komprimering?**

Nej. Komprimering kan reducera den lagrade rasterupplösningen, och borttagning av beskärda regioner kastar bilddata. Behåll den ursprungliga källbilden utanför presentationen om högupplöst redigering senare kan behövas.

**Hur bör SVG‑bilder hanteras?**

Behåll SVG‑innehållet som SVG när vektorfidelity är viktig. Den inbäddade [ISvgImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isvgimage/) kan extraheras direkt. Rendering av en slide till ett rasterformat såsom PNG eller JPEG rasteriserar SVG:n som en del av slide‑bilden.

**Hur undviker jag osäkra cast‑operationer när jag läser befintliga slides?**

Kontrollera formtypen innan du använder bildram‑specifika medlemmar. Testa formen med [IPictureFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipictureframe/) innan du utför en runtime‑cast, och tilldela cast‑resultatet till en lokal variabel innan du får åtkomst till bildram‑specifika medlemmar.