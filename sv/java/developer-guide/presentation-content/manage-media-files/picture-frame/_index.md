---
title: Hantera bildramar i presentationer med Java
linktitle: Bildram
type: docs
weight: 10
url: /sv/java/picture-frame/
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
  - formatering av bildram
  - relativ skalning
  - bildeffekt
  - bildförhållande
  - PowerPoint
  - OpenDocument
  - presentation
  - Java
  - Aspose.Slides
description: "Skapa, formatera, länka, beskära, extrahera och komprimera bildramar i presentationer med Aspose.Slides för Java."
---
## **Översikt**

En bildram är en bildform på en bild som visar en bild. I Aspose.Slides är bildresursen och formen som visar den separata objekt: en [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/) äger inbäddade bildresurser via sin [IImageCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iimagecollection/), medan en [IPictureFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipictureframe/) styr bildens position, storlek, linjeformatering, rotation, beskärning, bild effekter och andra ram‑nivå inställningar.

Denna separation är användbar när samma bild visas mer än en gång. Lägg till bilden i presentationen en gång, behåll den returnerade [IPPImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ippimage/), och använd den bildresursen när du skapar bildramar.

Bildramar kan innehålla rasterbilder som PNG eller JPEG samt vektor‑SVG‑bilder. De kan också referera till länkade bilder istället för att lagra bild‑bytes i presentationen. Valet påverkar portabilitet, filstorlek, extrahering och exportbeteende, så det är bra att bestämma hur bilden ska lagras innan formatering eller optimering appliceras.

## **Lägg till och formatera en inbäddad bild**

För en inbäddad bild, lägg till bilddata i presentationen och skapa en bildram med [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-). Bilden blir en del av presentationspaketet, så presentationen förblir självförsörjande när den flyttas till en annan dator.

Följande exempel lägger till en JPEG‑bild, skapar en ram med bildens ursprungliga dimensioner och applicerar linjeformatering och rotation:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Bildramen styr den visade geometrin; att ändra ramens storlek ändrar inte de ursprungliga pixel‑dimensionerna som lagras i den inbäddade bildresursen. Detta blir viktigt när man beskär eller komprimerar en bild senare.

## **Använd relativ skalning**

[IPictureFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipictureframe/) exponerar relativ bredd‑ och höjds‑skalning för ramen via [setRelativeScaleWidth](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) och [setRelativeScaleHeight](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-). Ett värde på `1.0` motsvarar 100 % av den ursprungliga bildstorleken. Relativ skalning är användbar när ett arbetsflöde måste bevara förhållandet till källbildens storlek istället för att manuellt beräkna slutdimensionerna.

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

Relativ skalning ändrar ramens skalningsinställningar; den resamplar eller komprimerar inte den inbäddade bilden.

## **Inbäddade och länkade bilder**

En inbäddad bild lagrar bilddata i presentationen och är därför det säkraste valet för portabilitet och förutsägbar rendering. En länkad bild lagrar en extern plats via [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-)‑metoden i stället för att bädda in bilddata på samma sätt.

Länkade bilder kan minska mängden bilddata som lagras i PPTX, men de introducerar ett externt beroende. Den länkade filen måste förbli åtkomlig för programmet som öppnar eller renderar presentationen. Om sökvägen ändras, filen flyttas eller resursen är otillgänglig, visas den länkade bilden kanske inte som förväntat. För presentationer som måste e‑postas, arkiveras eller renderas i isolerade miljöer är inbäddade bilder vanligtvis mer pålitliga.

### **Lägg till en länkad bild**

Följande exempel skapar en bildram och pekar den på en lokal bildfil. Det hanterar endast bildlänkning; videolänkning är ett separat mediaprocess och är medvetet inte blandat i detta exempel.

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

Använd länkar när extern filhantering är avsiktlig. Använd dem inte bara som ett ersättningsmedel för kompression: en liten PPTX med brutna bildberoenden är vanligtvis mindre användbar än en större självförsörjande presentation.

## **Extrahera bilder från bildramar**

Innan en bild extraheras från en befintlig presentation, kontrollera att en form faktiskt är en [IPictureFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipictureframe/) och att den innehåller en inbäddad bild. Länkade bildramar kanske inte innehåller bildbytes som kan extraheras på samma sätt.

### **Extrahera en raster‑bild**

Det moderna bild‑API:et använder [IImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iimage/) direkt och kräver inte den äldre Java‑bild‑wrappern. Följande exempel hittar den första inbäddade raster‑bilden på en bild och sparar den som PNG:

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

Att spara via [IImage.save](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iimage/#save-java.lang.String-int-) konverterar den extraherade bilden till det begärda utdataformatet. Om du behöver de kodade bytes som lagras i presentationen snarare än en konverterad rasterfil, använd bildresursens binära data i stället.

### **Extrahera en SVG‑bild**

För en SVG‑bild exponerar [IPPImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ippimage/) ett [ISvgImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isvgimage/)‑objekt. Detta låter dig hämta SVG‑data direkt i stället för att rasterisera bilden först.

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

Att behålla SVG‑innehållet som SVG bevarar vektor‑källan i presentationen. Raster‑exporter som PNG eller JPEG renderar nödvändigtvis den vektorinnehållet till pixlar. PDF‑ eller SVG‑bildexport är också en renderingsoperation, så de exporterade grafikerna bör inte betraktas som en byte‑för‑byte kopia av den ursprungliga inbäddade SVG:n; använd den inbäddade [ISvgImage.getSvgData](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isvgimage/#getSvgData--)‑datan när den ursprungliga vektorresursen själv krävs.

## **Beskär en bild**

Beskärning ändrar vilken del av en bild som är synlig i ramen. Beskära‑värdena på [IPictureFillFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipicturefillformat/) är procentandelar av källbildens dimensioner. Beskära tar inte bort de dolda pixlarna från den inbäddade bilden initialt; den ändrar bara den synliga regionen.

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

Eftersom den dolda bilddatan fortfarande finns kvar kan beskärningen ändras senare utan att original‑pixlarna går förlorade. Om filstorlek är viktigare än återgörbarhet kan de beskurna regionerna fysiskt tas bort enligt nästa avsnitt.

## **Ta bort beskärda bilddata**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) tar bort bilddata utanför den aktuella beskärningsrektangeln och returnerar den resulterande bildresursen. Detta kan minska filstorleken, men det är en destruktiv optimering: efter att presentationen sparats är de borttagna pixlarna inte längre tillgängliga för en senare avbeskärning.

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

Metoden kan lägga till en ny bildresurs i presentationen. Om den ursprungliga bilden också används av andra bildramar, behöver dessa ramar fortfarande sin befintliga resurs, så att ta bort beskurna områden inte nödvändigtvis minskar det totala antalet bilder. Beskärning av WMF‑ eller EMF‑innehåll med denna metod rasteriserar det beskurna resultatet till PNG.

## **Komprimera raster‑bilder**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) minskar raster‑bildens upplösning i förhållande till storleken som bilden visas i. Den kan också ta bort beskurna regioner i samma operation. Metoden returnerar `true` när bilden har storleksändrats eller beskärts och `false` när ingen förändring var nödvändig.

Använd ett fördefinierat [PicturesCompression](https://reference.aspose.com/slides/sv/java/com.aspose.slides/picturescompression/)‑värde när en standard målupplösning är tillräcklig:

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

Ett eget positivt DPI‑värde kan skickas istället för ett fördefinierat värde när en specifik målupplösning krävs.

Kompression är avsedd för raster‑bilder. SVG‑ och metafil‑innehåll reduceras inte av detta raster‑komprimerings‑arbetsflöde. Kom också ihåg att lägre upplösning och borttagna beskurna regioner inte kan återställas från den optimerade presentationen. Välj en målupplösning baserat på den största storlek som bilden faktiskt kommer att visas eller exporteras i, snarare än att applicera den lägsta DPI:n globalt.

## **Hantera bildtransform‑effekter**

För ett komplett arbetsflöde som täcker ljusstyrka, kontrast, färgtransformeringar, oskärpa, alfa‑effekter, ordnade kedjor, inspektion, borttagning och round‑trip‑verifiering, se [Image Transform Effects](/java/image-transform-effects/).

## **Lås bildramens geometri**

[IPictureFrameLock](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipictureframelock/)‑inställningarna styr vilka redigeringsåtgärder som är inaktiverade för en bildram. Till exempel bevarar [setAspectRatioLocked](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) formens proportioner medan den storleksändras.

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

Låset gäller bildramens form. Det tvingar inte källbilden att resamplas eller permanent ändras till samma bildförhållande.

## **Justera StretchOffset‑värdena**

När bildfyllnadsläget är stretch definierar stretch‑offset‑värdena på [IPictureFillFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipicturefillformat/) fyllningsrektangeln relativt bildramens bindningsruta. Positiva procentandelar skapar ett inskjut från en kant, medan negativa procentandelar skapar ett utskjut.

Detta skiljer sig från beskärning. Beskärningsvärden väljer vilken del av källbilden som är synlig; stretch‑offset förändrar rektangeln som den synliga bildfyllnaden sträcks in i.

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

Använd stretch‑offset för placering av fyllning. Använd beskärnings‑egenskaper när målet är att dölja källbildens kanter.

## **Lagring, filstorlek och exportaspekter**

De huvudsakliga avvägningarna blir enklare att hantera när bildlagring och bildram‑formatering behandlas separat:

- **Inbäddade bilder** gör presentationen självförsörjande och är det mest pålitliga alternativet för delning och server‑side rendering, men stora raster‑bilder ökar PPTX‑storleken och minnesanvändningen.
- **Länkade bilder** kan hålla paketet mindre, men presentationen beror på att externa filer förblir tillgängliga på de lagrade sökvägarna eller platserna.
- **Beskärning** är initialt icke‑destruktiv. De dolda pixlarna förblir inbäddade tills beskurna områden explicit tas bort eller avlägsnas under komprimering.
- **Kompression** kan minska filstorleken avsevärt för överdimensionerade raster‑bilder, men den offrar käll‑upplösning. Den bör appliceras efter att den avsedda bildstorleken på bilden är känd.
- **SVG‑bilder** bör förbli SVG när vektor‑bevarande är viktigt. Extrahera den inbäddade SVG‑filen direkt när du behöver själva vektorresursen. Raster‑slide‑exporter konverterar alltid den renderade sliden till pixlar.
- **Upprepade bilder** bör återanvända en befintlig [IPPImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ippimage/)‑resurs när det är möjligt i stället för att upprepade gånger ladda samma fil i presentations‑arbetsflödet.

För stora presentationer är bildoptimering vanligtvis mest effektiv när den utförs selektivt: behåll logotyper och diagram som vektor‑innehåll, komprimera fotografier enligt deras faktiska visningsstorlek, ta bort beskurna pixlar endast när senare redigering inte krävs, och undvik externa länkar såvida inte beroende‑hantering är en del av driftsdesignen.

## **FAQ**

**Vad är skillnaden mellan en bildram och en bildresurs?**

En [IPPImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ippimage/) representerar en bildresurs som är associerad med presentationen. En [IPictureFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipictureframe/) är en form på en bild som visar en bild och lagrar ram‑nivå geometri och formatering såsom storlek, rotation, beskärningsvärden, effekter och lås.

**Ska jag bädda in eller länka bilder?**

Bädda in bilder när presentationen måste vara portabel, arkiverad eller renderas utan åtkomst till externa resurser. Länka bilder endast när det är avsiktligt att hålla bildfiler utanför PPTX och de externa platserna kan underhållas på ett tillförlitligt sätt.

**Minskar beskärning filstorleken på PPTX?**

Inte av sig självt. Normala beskärningsinställningar döljer delar av källbilden men behåller underliggande pixlar. Använd [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) eller bildkompression med borttagning av beskurna områden när dessa pixlar kan tas bort permanent.

**Kan jag återställa bildkvaliteten efter kompression?**

Nej. Kompression kan reducera lagrad raster‑upplösning, och borttagning av beskurna regioner raderar bilddata. Behåll originalkällbilden utanför presentationen om högupplöst redigering kan behövas senare.

**Hur ska SVG‑bilder hanteras?**

Behåll SVG‑innehållet som SVG när vektor‑fidelity är viktigt. Den inbäddade [ISvgImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isvgimage/) kan extraheras direkt. Att rendera en slide till ett rasterformat som PNG eller JPEG rasteriserar SVG:n som en del av slide‑bilden.

**Hur kan jag undvika osäkra castar när jag läser befintliga slides?**

Kontrollera formtypen innan du använder bildram‑specifika medlemmar. En `instanceof`‑kontroll mot [IPictureFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipictureframe/) undviker ogiltiga castar och låter koden hantera slides som inte innehåller bildramar.