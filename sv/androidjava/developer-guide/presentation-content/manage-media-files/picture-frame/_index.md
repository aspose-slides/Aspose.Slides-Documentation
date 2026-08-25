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
- SVG‑bild
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
- Android
- Java
- Aspose.Slides
description: "Skapa, formatera, länka, beskära, extrahera och komprimera bildramar i presentationer med Aspose.Slides för Android via Java."
---
## **Översikt**

En bildram är en bildform som visar en bild. I Aspose.Slides är bildresursen och formen som visar den separata objekt: en [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/) äger inbäddade bildresurser via dess [IImageCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iimagecollection/), medan en [IPictureFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipictureframe/) styr bildens position, storlek, linjeformat, rotation, beskärning, bildeffekter och andra ram‑nivåinställningar.

Denna separation är användbar när samma bild visas mer än en gång. Lägg till bilden i presentationen en gång, behåll den returnerade [IPPImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ippimage/), och använd den bildresursen när du skapar bildramar.

Bildramar kan innehålla rasterbilder såsom PNG eller JPEG och vektor‑SVG‑bilder. De kan också hänvisa till länkade bilder istället för att lagra bild‑bytarna i presentationen. Valet påverkar portabilitet, filstorlek, extrahering och exportbeteende, så det är bra att bestämma hur bilden ska lagras innan formatering eller optimering tillämpas.

## **Lägg till och formatera en inbäddad bild**

För en inbäddad bild, lägg till bilddata i presentationen och skapa en bildram med [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-). Bilden blir en del av presentationspaketet, så presentationen förblir självständig när den flyttas till en annan dator.

Följande exempel lägger till en JPEG‑bild, skapar en ram enligt bildens ursprungliga dimensioner och tillämpar linjeformat och rotation:

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

Bildramen styr den visade geometrin; att ändra ramens storlek ändrar inte de ursprungliga pixel‑dimensionerna som lagras i den inbäddade bildresursen. Denna distinktion blir viktig när man beskär eller komprimerar en bild senare.

## **Använd relativ skalning**

[IPictureFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipictureframe/) exponerar relativ bredd‑ och höjds­skalning för ramen via [setRelativeScaleWidth](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) och [setRelativeScaleHeight](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-). Ett värde på `1.0` motsvarar 100 % av den ursprungliga bildstorleken. Relativ skalning är användbar när ett arbetsflöde måste bevara förhållandet till källbildens storlek istället för att manuellt beräkna slutlig dimension.

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

Relativ skalning ändrar ramens skalningsinställningar; den återprovar eller komprimerar inte den inbäddade bilden.

## **Inbäddade och länkade bilder**

En inbäddad bild lagrar bilddata i presentationen och är därför det säkraste valet för portabilitet och förutsägbar rendering. En länkad bild lagrar en extern plats via metoden [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) i stället för att bädda in bilddata på samma sätt.

Länkade bilder kan minska mängden bilddata som lagras i PPTX‑filen, men de introducerar ett externt beroende. Den länkade filen måste vara tillgänglig för programmet som öppnar eller renderar presentationen. Om sökvägen ändras, filen flyttas eller resursen är otillgänglig, kanske den länkade bilden inte visas som förväntat. För presentationer som måste skickas via e‑post, arkiveras eller renderas i isolerade miljöer är inbäddade bilder vanligtvis mer pålitliga.

### **Lägg till en länkad bild**

Följande exempel skapar en bildram och pekar den på en lokal bildfil. Det behandlar endast bildlänkning; videolänkning är ett separat mediaproduktionsflöde och är avsiktligt inte blandat i detta exempel.

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

Använd länkar när extern filhantering är avsiktlig. Använd dem inte bara som ett substitut för komprimering: en liten PPTX med brutna bildberoenden är vanligtvis mindre användbar än en större självständig presentation.

## **Extrahera bilder från bildramar**

Innan du extraherar en bild från en befintlig presentation, kontrollera att en form faktiskt är en [IPictureFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipictureframe/) och att den innehåller en inbäddad bild. Länkade bildramar kanske inte innehåller bild‑bytar som kan extraheras på samma sätt.

### **Extrahera en rasterbild**

Det moderna bild‑API‑et använder [IImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iimage/) direkt och kräver inte den äldre Java‑bild‑omslutaren. Följande exempel hittar den första inbäddade rasterbilden på en bild och sparar den som PNG:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

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

Att spara via [IImage.save](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) konverterar den extraherade bilden till det begärda utdataformatet. Om du behöver de kodade bytarna som lagras i presentationen snarare än en konverterad rasterfil, använd bildresursens binärdata i stället.

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

Att behålla SVG‑innehåll som SVG bevarar vektor‑källan i presentationen. Raster‑exporter såsom PNG eller JPEG renderar nödvändigtvis den vektorinnehållet till pixlar. PDF‑ eller SVG‑bildexport är också en renderingsoperation, så de exporterade grafikerna bör inte betraktas som en bit‑för‑bit‑kopia av den ursprungliga inbäddade SVG:n; använd den inbäddade [ISvgImage.getSvgData](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isvgimage/#getSvgData--)‑datan när den ursprungliga vektorresursen själv krävs.

## **Beskära en bild**

Beskärning ändrar vilken del av en bild som är synlig i ramen. Beskärningsvärdena på [IPictureFillFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipicturefillformat/) är procentandelar av källbildens dimensioner. Beskärning tar initialt inte bort de dolda pixlarna från den inbäddade bilden; den ändrar bara den synliga regionen.

Följande exempel hittar en bildram på ett säkert sätt och tillämpar beskärningsvärden:

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

Eftersom de dolda bildbytarna fortfarande finns kvar kan beskärningen ändras senare utan att förlora originalpixlarna. Om filstorlek är viktigare än reverserbarhet kan de beskurna regionerna fysiskt tas bort enligt nästa avsnitt.

## **Ta bort beskurna bilddata**

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

Metoden kan lägga till en ny bildresurs i presentationen. Om den ursprungliga bilden även används av andra bildramar behöver dessa ramar fortfarande sin befintliga resurs, så att ta bort beskurna områden inte nödvändigtvis minskar det totala antalet bilder. Beskärning av WMF‑ eller EMF‑innehåll med denna metod rasteriserar det beskärda resultatet till PNG.

## **Komprimera rasterbilder**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) minskar rasterbildens upplösning i förhållande till den storlek som bilden visas i. Den kan också ta bort beskurna regioner i samma operation. Metoden returnerar `true` när bilden har ändrats storlek eller beskärts och `false` när ingen förändring var nödvändig.

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

Ett eget positivt DPI‑värde kan skickas istället för ett fördefinierat värde när ett specifikt mål krävs.

Kompression är avsedd för rasterbilder. SVG‑ och metafil‑innehåll reduceras inte av detta rasterkomprimeringsflöde. Kom också ihåg att lägre upplösning och borttagna beskurna regioner inte kan återställas från den optimerade presentationen. Välj en målupplösning baserad på den största storleken som bilden faktiskt kommer att visas eller exporteras i, snarare än att globalt tillämpa den lägsta DPI:n.

## **Hantera bildtransformeringseffekter**

För ett komplett arbetsflöde som omfattar ljusstyrka, kontrast, färgtransformeringar, oskärpa, alfa‑effekter, ordnade kedjor, inspektion, borttagning och round‑trip‑verifiering, se [Image Transform Effects](/androidjava/image-transform-effects/).

## **Lås bildramens geometri**

[IPictureFrameLock](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipictureframelock/)‑inställningarna styr vilka redigeringsåtgärder som är inaktiverade för en bildram. Till exempel bevarar [setAspectRatioLocked](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) formens proportioner när den skalas.

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

Låset gäller bildramformen. Det tvingar inte källbilden att återprovas eller permanent förändras till samma bildförhållande.

## **Justera StretchOffset‑värdena**

När bildfyllnadsläget är stretch definierar stretch‑offset‑värdena på [IPictureFillFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipicturefillformat/) fyllningsrektangeln relativt bildramens avgränsningsruta. Positiva procentandelar skapar ett indrag från en kant, medan negativa procentandelar skapar ett utstick.

Detta skiljer sig från beskärning. Beskärningsvärden väljer vilken del av källbilden som är synlig; stretch‑offsets ändrar den rektangel som den synliga bildfyllnaden sträcks in i.

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

Använd stretch‑offsets för fyllningsplacering. Använd beskärningsattribut när målet är att dölja kanterna på källbilden.

## **Lagring, filstorlek och exportaspekter**

De viktigaste avvägningarna blir enklare att hantera när bildlagring och bildram‑formatering behandlas separat:

- **Inbäddade bilder** gör presentationen självständig och är det mest pålitliga för delning och server‑side‑rendering, men stora rasterbilder ökar PPTX‑storlek och minnesanvändning.
- **Länkade bilder** kan hålla paketet mindre, men presentationen är beroende av att externa filer förblir tillgängliga på de lagrade sökvägarna eller platserna.
- **Beskärning** är initialt icke‑destruktiv. De dolda pixlarna förblir inbäddade tills beskurna områden explicit tas bort eller tas bort under komprimering.
- **Komprimering** kan minska filstorleken avsevärt för överdimensionerade rasterbilder, men den offrar källupplösning. Den bör appliceras efter att den avsedda bildstorleken på sliden är känd.
- **SVG‑bilder** bör behållas som SVG när vektorbevarande är viktigt. Extrahera den inbäddade SVG:n direkt när du behöver själva vektorresursen. Raster‑slide‑exporter konverterar alltid den renderade sliden till pixlar.
- **Upprepade bilder** bör återanvända en befintlig [IPPImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ippimage/)‑resurs när det är möjligt i stället för att upprepade gånger ladda samma fil i presentations‑arbetsflödet.

För stora presentationer är bildoptimering oftast mest effektiv när den utförs selektivt: behåll logotyper och diagram som vektor­innehåll, komprimera foton enligt deras faktiska displaystorlek, ta bort beskurna pixlar endast när senare redigering inte krävs, och undvik externa länkar såvida inte beroendehantering är en del av distributionsdesignen.

## **FAQ**

**Vad är skillnaden mellan en bildram och en bildresurs?**

En [IPPImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ippimage/) representerar en bildresurs som är associerad med presentationen. En [IPictureFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipictureframe/) är en form på en slide som visar en bild och lagrar ram‑nivå geometri och formatering såsom storlek, rotation, beskärningsvärden, effekter och lås.

**Ska jag bädda in eller länka bilder?**

Bädda in bilder när presentationen måste vara portabel, arkiverad eller renderas utan åtkomst till externa resurser. Länka bilder endast när det är avsiktligt att hålla bildfilerna utanför PPTX och de externa platserna kan underhållas pålitligt.

**Minskar beskärning PPTX‑filstorleken?**

Inte i sig. Vanliga beskärningsinställningar döljer delar av källbilden men behåller de underliggande pixlarna. Använd [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) eller bildkomprimering med borttagning av beskurna områden när dessa pixlar kan tas bort permanent.

**Kan jag återställa bildkvaliteten efter komprimering?**

Nej. Komprimering kan minska den lagrade rasterupplösningen, och borttagning av beskurna regioner kastar bilddata. Behåll den ursprungliga källbilden utanför presentationen om högupplöst redigering senare kan behövas.

**Hur bör SVG‑bilder hanteras?**

Behåll SVG‑innehållet som SVG när vektorfidelity är viktigt. Den inbäddade [ISvgImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isvgimage/) kan extraheras direkt. Rendering av en slide till ett rasterformat såsom PNG eller JPEG rasteriserar SVG:n som en del av slide‑bilden.

**Hur undviker jag osäkra typ‑castar när jag läser befintliga slides?**

Kontrollera formtypen innan du använder bildram‑specifika medlemmar. En `instanceof`‑kontroll mot [IPictureFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipictureframe/) undviker ogiltiga castar och låter koden hantera slides som inte innehåller bildramar.