---
title: Hantera bildramar i presentationer på Android
linktitle: Bildram
type: docs
weight: 10
url: /sv/androidjava/picture-frame/
keywords:
- bildram
- lägg till bildram
- skapa bildram
- inbäddad bild
- länkad bild
- extrahera bild
- rasterbild
- SVG-bild
- beskär bild
- ta bort beskurna områden
- komprimera bild
- StretchOffset
- formatering av bildram
- relativ skala
- billeffekt
- bildförhållande
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Skapa, formatera, länka, beskära, extrahera och komprimera bildramar i presentationer med Aspose.Slides för Android via Java."
---
## **Översikt**

En bildram är en bildform som visar en bild. I Aspose.Slides är bildresursen och formen som visar den separata objekt: en [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/) äger inbäddade bildresurser via sin [IImageCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iimagecollection/), medan en [IPictureFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipictureframe/) styr bildens position, storlek, linjeformatering, rotation, beskärning, bild‑effekter och andra ram‑nivåinställningar.

Denna separation är användbar när samma bild visas mer än en gång. Lägg till bilden i presentationen en gång, behåll den returnerade [IPPImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ippimage/), och använd den bildresursen när du skapar bildramar.

Bildramar kan innehålla rasterbilder såsom PNG eller JPEG samt vektor‑SVG‑bilder. De kan också referera till länkade bilder i stället för att lagra bild‑bytarna i presentationen. Valet påverkar portabilitet, filstorlek, extrahering och exportbeteende, så det är bra att bestämma hur bilden ska lagras innan formatering eller optimering appliceras.

## **Lägg till och formatera en inbäddad bild**

För en inbäddad bild, lägg till bilddata i presentationen och skapa en bildram med [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-). Bilden blir en del av presentationspaketet, så presentationen förblir självständig när den flyttas till en annan dator.

Följande exempel lägger till en JPEG‑bild, skapar en ram med bildens ursprungliga dimensioner och applicerar linjeformatering och rotation:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pictureFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pictureFrame.getLineFormat().setWidth(3);
    pictureFrame.setRotation(15);

    presentation.save("picture-frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bildramen styr den visade geometrin; att ändra ramens storlek ändrar inte de ursprungliga pixeldimensionerna som lagras i den inbäddade bildresursen. Detta blir viktigt när man beskär eller komprimerar en bild senare.

## **Använd relativ skalning**

[IPictureFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipictureframe/) exponerar relativ bredd‑ och höjds skalning för ramen via [setRelativeScaleWidth](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) och [setRelativeScaleHeight](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-). Ett värde på `1.0` motsvarar 100 % av den ursprungliga bildstorleken. Relativ skalning är användbar när ett arbetsflöde behöver bevara ett förhållande till källbildens storlek i stället för att manuellt beräkna slutdimensioner.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image);
    pictureFrame.setRelativeScaleWidth(1.35f);
    pictureFrame.setRelativeScaleHeight(0.8f);

    presentation.save("relative-scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Relativ skalning ändrar ramens skalegenskaper; den återprovningsar eller komprimerar inte den inbäddade bilden.

## **Inbäddade och länkade bilder**

En inbäddad bild lagrar bilddata i presentationen och är därför det säkraste valet för portabilitet och förutsägbar rendering. En länkad bild lagrar en extern plats via metoden [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) i stället för att bädda in bilddata på samma sätt.

Länkade bilder kan minska mängden bilddata som lagras i PPTX‑filen, men de introducerar ett externt beroende. Den länkade filen måste förbli åtkomlig för programmet som öppnar eller återger presentationen. Om sökvägen ändras, filen flyttas eller resursen är otillgänglig, visas den länkade bilden kanske inte som förväntat. För presentationer som måste skickas via e‑post, arkiveras eller återges i isolerade miljöer, är inbäddade bilder vanligtvis mer tillförlitliga.

### **Lägg till en länkad bild**

Följande exempel skapar en bildram och pekar den på en lokal bildfil. Det hanterar endast bildlänkning; videolänkning är ett separat mediaprocessflöde och blandas medvetet inte in i detta exempel.

```java
import com.aspose.slides.*;
import java.io.File;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, null);
    File linkedImageFile = new File("linked-image.jpg");
    String linkPath = linkedImageFile.getAbsolutePath();
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong(linkPath);

    presentation.save("linked-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Använd länkar när extern filhantering är avsiktlig. Använd dem inte enbart som ett substitut för komprimering: en liten PPTX med brutna bildberoenden är vanligtvis mindre användbar än en större självständig presentation.

## **Extrahera bilder från bildramar**

Innan du extraherar en bild från en befintlig presentation, kontrollera att en form faktiskt är en [IPictureFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipictureframe/) och att den innehåller en inbäddad bild. Länkade bildramar kan sakna bild‑bytar som kan extraheras på samma sätt.

### **Extrahera en raster‑bild**

Den moderna bild‑API:n använder [IImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iimage/) direkt och kräver inte den äldre Java‑bild‑wrappern. Följande exempel hittar den första inbäddade raster‑bilden på en bild och sparar den som PNG:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0;

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IPictureFrame)) {
            continue;
        }

        IPictureFrame pictureFrame = (IPictureFrame) shape;
        IPPImage embeddedImage = pictureFrame.getPictureFormat().getPicture().getImage();
        if (embeddedImage == null || embeddedImage.getSvgImage() != null) {
            continue;
        }

        IImage rasterImage = embeddedImage.getImage();
        try {
            rasterImage.save("extracted-image.png", ImageFormat.Png);
        } finally {
            rasterImage.dispose();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

Att spara via [IImage.save](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) konverterar den extraherade bilden till det begärda utdataformatet. Om du behöver de kodade bytarna som lagras i presentationen i stället för en konverterad rasterfil, använd bildresursens binära data i stället.

### **Extrahera en SVG‑bild**

För en SVG‑bild exponeras [IPPImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ippimage/) ett [ISvgImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isvgimage/)‑objekt. Detta låter dig hämta SVG‑data direkt i stället för att rasterisera bilden först.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IPictureFrame)) {
            continue;
        }

        IPictureFrame pictureFrame = (IPictureFrame) shape;
        IPPImage embeddedImage = pictureFrame.getPictureFormat().getPicture().getImage();
        ISvgImage svgImage = embeddedImage != null ? embeddedImage.getSvgImage() : null;
        if (svgImage == null) {
            continue;
        }

        byte[] svgData = svgImage.getSvgData();
        FileOutputStream outputStream = new FileOutputStream("extracted-image.svg");
        try {
            outputStream.write(svgData);
        } finally {
            outputStream.close();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

Att behålla SVG‑innehållet som SVG bevarar vektor­källan i presentationen. Raster‑exporter som PNG eller JPEG renderar nödvändigtvis det vektorinnehållet till pixlar. PDF‑ eller SVG‑bildexport är också en renderingsoperation, så de exporterade grafikerna bör inte betraktas som en exakt byte‑för‑byte‑kopiering av den inbäddade SVG:n; använd den inbäddade [ISvgImage.getSvgData](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isvgimage/#getSvgData--)‑datan när den ursprungliga vektorresursen själv krävs.

## **Beskär en bild**

Beskärning ändrar vilken del av en bild som är synlig i ramen. Beskärningsvärdena på [IPictureFillFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipicturefillformat/) är procentandelar av källbildens dimensioner. Beskärning tar inte initialt bort de dolda pixlarna från den inbäddade bilden; den ändrar bara den synliga regionen.

Följande exempel hittar en bildram på ett säkert sätt och applicerar beskärningsvärden:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        pictureFrame.getPictureFormat().setCropLeft(23.6f);
        pictureFrame.getPictureFormat().setCropRight(21.5f);
        pictureFrame.getPictureFormat().setCropTop(3f);
        pictureFrame.getPictureFormat().setCropBottom(31f);
        presentation.save("cropped-image.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Eftersom den dolda bilddatan fortfarande är närvarande kan beskärningen ändras senare utan att förlora de ursprungliga pixlarna. Om filstorlek är viktigare än återställbarhet kan de beskurna områdena fysiskt tas bort enligt nästa avsnitt.

## **Ta bort beskärd bilddata**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) tar bort bilddata utanför den aktuella beskärningsrektangeln och returnerar den resulterande bildresursen. Detta kan minska filstorleken, men det är en destruktiv optimering: efter att presentationen sparats är de borttagna pixlarna inte längre tillgängliga för en senare avbeskärningsoperation.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("cropped-image.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IPPImage croppedImage = pictureFrame.getPictureFormat().deletePictureCroppedAreas();
        if (croppedImage != null) {
            presentation.save("cropped-data-removed.pptx", SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

Metoden kan lägga till en ny bildresurs i presentationen. Om den ursprungliga bilden också används av andra bildramar, behöver dessa ram­er fortfarande sin befintliga resurs, så att radera beskurna områden inte nödvändigtvis minskar det totala antalet bilder. Beskärning av WMF‑ eller EMF‑innehåll med denna metod rasteriserar det beskurna resultatet till PNG.

## **Komprimera raster‑bilder**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) minskar raster‑bildens upplösning i förhållande till den storlek som bilden visas med. Den kan också ta bort beskärda områden i samma operation. Metoden returnerar `true` när bilden har ändrats i storlek eller beskärts och `false` när ingen förändring var nödvändig.

Använd ett fördefinierat [PicturesCompression](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/picturescompression/)‑värde när en standardmålupplösning är tillräcklig:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        boolean compressed = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);
        System.out.println(compressed ? "The image was compressed." : "No compression was necessary.");
        presentation.save("compressed-image.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Ett eget positivt DPI‑värde kan anges i stället för ett fördefinierat värde när ett specifikt mål krävs.

Kompression är avsedd för raster‑bilder. SVG‑ och metafil‑innehåll reduceras inte av detta raster‑komprimeringsflöde. Kom också ihåg att lägre upplösning och borttagna beskärda områden inte kan återställas från den optimerade presentationen. Välj en målupplösning baserad på den största storlek som bilden faktiskt kommer att visas eller exporteras i, snarare än att globalt tillämpa den lägsta DPI‑nivån.

## **Inspektera bild‑effekter**

Bildeffekter lagras på bilden som används av ramen. Bild‑transform‑samlingen kan innehålla effekter såsom fast alfa‑modulering för transparens och luminans för ljusstyrka och kontrast. Exemplet nedan läser säkert båda typerna av effekter från den första bildramen på en bild:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        for (IImageTransformOperation effect : imageTransform) {
            if (effect instanceof IAlphaModulateFixed) {
                IAlphaModulateFixed alphaModulateFixed = (IAlphaModulateFixed) effect;
                float transparency = 100 - alphaModulateFixed.getAmount();
                System.out.println("Transparency: " + transparency);
            }

            if (effect instanceof ILuminance) {
                ILuminance luminanceEffect = (ILuminance) effect;
                ILuminanceEffectiveData luminance = luminanceEffect.getEffective();
                System.out.println("Brightness: " + luminance.getBrightness());
                System.out.println("Contrast: " + luminance.getContrast());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Dessa effekter förändrar hur bilden återges i ramen; de skriver inte om de ursprungliga inbäddade bild‑bytarna.

## **Lås bildramens geometri**

[IPictureFrameLock](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipictureframelock/)‑inställningarna styr vilka redigeringsoperationer som inaktiveras för en bildram. Till exempel bevarar [setAspectRatioLocked](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) formens proportioner medan den ändras i storlek.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    presentation.save("locked-picture-frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Låset gäller bildramens form. Det tvingar inte källbilden att återprovas eller permanent ändras till samma bildförhållande.

## **Justera StretchOffset‑värdena**

När bildfyllnadsläget är stretch definierar stretch‑offset‑värdena på [IPictureFillFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipicturefillformat/) fyllningsrektangeln relativt bildramens omslutande ruta. Positiva procentsatser skapar ett inskjut från en kant, medan negativa procentsatser skapar ett utskjut.

Detta skiljer sig från beskärning. Beskärningsvärden väljer vilken del av källbilden som är synlig; stretch‑offset förändrar den rektangel som den synliga bildfyllnaden sträcks till.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image);
    pictureFrame.getPictureFormat().setPictureFillMode(PictureFillMode.Stretch);
    pictureFrame.getPictureFormat().setStretchOffsetLeft(12f);
    pictureFrame.getPictureFormat().setStretchOffsetRight(12f);
    pictureFrame.getPictureFormat().setStretchOffsetTop(8f);
    pictureFrame.getPictureFormat().setStretchOffsetBottom(8f);

    presentation.save("stretch-offsets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Använd stretch‑offset för placering av fyllning. Använd beskärnings‑egenskaper när målet är att dölja kanterna på källbilden.

## **Lagring, filstorlek och exportaspekter**

De viktigaste avvägningarna blir enklare att hantera när bildlagring och bildram‑formatering behandlas separat:

- **Inbäddade bilder** gör presentationen självständig och är det mest pålitliga alternativet för delning och server‑sid återgivning, men stora raster‑bilder ökar PPTX‑storlek och minnesanvändning.
- **Länkade bilder** kan hålla paketet mindre, men presentationen beror på att externa filer förblir tillgängliga på de lagrade sökvägarna eller platserna.
- **Beskärning** är initialt icke‑destruktiv. Dolda pixlar förblir inbäddade tills beskurna områden tas bort explicit eller tas bort under komprimering.
- **Komprimering** kan minska filstorleken avsevärt för överdimensionerade raster‑bilder, men den offrar källupplösning. Den bör appliceras efter att den avsedda storleken på sliden är känd.
- **SVG‑bilder** bör behållas som SVG när vektor‑bevarande är viktigt. Extrahera den inbäddade SVG:n direkt när du behöver själva vektorresursen. Raster‑slide‑exporter konverterar alltid den återgivna sliden till pixlar.
- **Upprepade bilder** bör återanvända en befintlig [IPPImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ippimage/)‑resurs när det är möjligt i stället för att upprepade gånger ladda samma fil i presentations‑arbetsflödet.

För stora presentationer är bildoptimering vanligtvis mest effektiv när den utförs selektivt: behåll logotyper och diagram som vektor‑innehåll, komprimera fotografier enligt deras faktiska visningsstorlek, ta bort beskurna pixlar endast när senare redigering inte krävs, och undvik externa länkar om inte beroendehantering är en del av distributionsdesignen.

## **FAQ**

**Vad är skillnaden mellan en bildram och en bildresurs?**

En [IPPImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ippimage/) representerar en bildresurs som är associerad med presentationen. En [IPictureFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipictureframe/) är en form på en slide som visar en bild och lagrar ram‑nivå‑geometri och formatering såsom storlek, rotation, beskärningsvärden, effekter och lås.

**Ska jag bädda in eller länka bilder?**

Bädda in bilder när presentationen måste vara portabel, arkiverad eller återges utan åtkomst till externa resurser. Länka bilder endast när det är avsiktligt att hålla bildfilerna utanför PPTX och de externa platserna kan underhållas pålitligt.

**Minskar beskärning PPTX‑filstorleken?**

Inte i sig. Normala beskärningsinställningar döljer delar av källbilden men behåller underliggande pixlar. Använd [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) eller bildkomprimering med borttagning av beskurna områden när dessa pixlar kan släppas permanent.

**Kan jag återställa bildkvaliteten efter komprimering?**

Nej. Komprimering kan reducera lagrad raster‑upplösning, och borttagning av beskurna områden släpper bilddata. Behåll originalkällbilden utanför presentationen om högupplöst redigering senare kan bli nödvändig.

**Hur bör SVG‑bilder hanteras?**

Behåll SVG‑innehållet som SVG när vektorfidelitet är viktig. Den inbäddade [ISvgImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isvgimage/) kan extraheras direkt. Att återge en slide till ett rasterformat som PNG eller JPEG rasteriserar SVG:n som en del av slide‑bilden.

**Hur undviker jag osäkra kast när jag läser befintliga slides?**

Kontrollera formtypen innan du använder bildram‑specifika medlemmar. En `instanceof`‑kontroll mot [IPictureFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipictureframe/) undviker ogiltiga kast och låter koden hantera slides som inte innehåller bildramar.