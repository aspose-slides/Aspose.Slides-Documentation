---
title: Optimera bildhantering i presentationer på Android
linktitle: Hantera bilder
type: docs
weight: 10
url: /sv/androidjava/image/
keywords:
- lägga till bild
- lägga till foto
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
- Android
- Java
- Aspose.Slides
description: "Lär dig hur du lägger till, återanvänder, länkar, ersätter och hanterar raster- och SVG-bilder i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Android via Java."
---
## **Introduktion**

Aspose.Slides för Android via Java erbjuder flera sätt att arbeta med bilder, och varje sätt har ett annat syfte. Du kan lagra en bild i en presentation, visa den i en picture frame, använda den som bakgrund på en bild, länka till en extern bild, ersätta en delad bildresurs eller konvertera SVG‑innehåll till redigerbara former.

Denna artikel fokuserar på bildresurser och hur de används i en presentation. För beskärning, transparens, effekter, stretching och annan formatering som tillämpas på en enskild picture frame, se [Picture Frame](/slides/sv/androidjava/picture-frame/).

## **Förstå bildmodellen**

Följande API‑koncept är nära besläktade men inte utbytbara:

- Den [presentation image collection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iimagecollection/) lagrar bildresurser som används av presentationen. Använd [ImageCollection.addImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imagecollection/) för att lägga till bilddata och få en [IPPImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ippimage/)‑resurs.
- En [picture frame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipictureframe/) är en form som visar en bild på en bild, layout eller master. Använd [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishapecollection/) för att placera en bildresurs på en bild.
- En bildbakgrund använder en bild som en del av bildens fyllning snarare än som en form. Den beter sig därför inte som en picture frame.
- [IPPImage.replaceImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ippimage/) ersätter en bildresurs. Om flera presentationselement använder den resursen, använder de alla ersättningen.
- Konvertering av en SVG till former skapar redigerbara bildformer. Efter konverteringen hanteras innehållet inte längre som en enda bildresurs.

Ett typiskt arbetsflöde är därför: lägg till bilddata i bildsamlingen, få ett [IPPImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ippimage/), och använd sedan den resursen i en eller flera picture frames eller fyllningar.

## **Lägg till en inbäddad bild**

För att infoga en lokal bild, läs in filen, lägg till den i bildsamlingen och skapa en picture frame som använder den returnerade `IPPImage`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) sourceImage.dispose();
    }

    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

    presentation.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bilden som läggs till på detta sätt är inbäddad i presentationen, så den resulterande filen är inte beroende av att originalbildfilen fortfarande är tillgänglig.

### **Lägg till en bild från webben**

När en bild är tillgänglig via HTTP eller HTTPS, ladda ner dess bytes, lägg till dem i presentationens bildsamling och använd den returnerade bildresursen på samma sätt som en lokal bild.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.URI;
import java.net.URL;

Presentation presentation = new Presentation();
try {
    URL imageUrl = URI.create("https://example.com/image.png").toURL();
    HttpURLConnection connection = (HttpURLConnection) imageUrl.openConnection();
    connection.setConnectTimeout(10000);
    connection.setReadTimeout(10000);

    try (InputStream inputStream = connection.getInputStream(); 
         ByteArrayOutputStream outputStream = new ByteArrayOutputStream()) {
        byte[] buffer = new byte[8192];
        int bytesRead;
        while ((bytesRead = inputStream.read(buffer)) != -1) outputStream.write(buffer, 0, bytesRead);

        IPPImage image = presentation.getImages().addImage(outputStream.toByteArray());
        ISlide slide = presentation.getSlides().get_Item(0);
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);
    }

    presentation.save("presentation-from-web.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

I långlivade applikationer, återanvänd en HTTP‑klient eller en anslutningshanteringsstrategi som passar applikationen i stället för att upprepade gånger skapa onödig nätverksinfrastruktur. Validera också fjärr‑URL:er, svarsstorlekar och innehållstyper när källan inte är betrodd.

## **Återanvänd bilder på flera bilder**

Om samma bild behövs mer än en gång, lägg till den i presentationen en gång och återanvänd den returnerade [IPPImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ippimage/) när du skapar ytterligare picture frames. Detta undviker att upprepade gånger ladda samma källdata och gör förhållandet mellan den delade bildresursen och dess användningar tydligt.

För grafik som ska visas automatiskt på många bilder, till exempel en företagslogotyp, överväg att placera picture frame på en [slide master](/slides/sv/androidjava/slide-master/) eller layout istället för att lägga till en motsvarande form på varje bild.

## **Använd en bild som bildbakgrund**

En bakgrundsbild tilldelas bildens fyllning; den läggs inte till som en picture‑frame‑form. Detta är användbart när bilden ska täcka bildbakgrunden och inte ska manipuleras som ett normalt bildobjekt.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("background.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) sourceImage.dispose();
    }

    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Picture);
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image);

    presentation.save("background-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

För ytterligare bakgrundsalternativ, inklusive master‑ och layoutbakgrunder, se [Presentation Background](/slides/sv/androidjava/presentation-background/).

## **Inbäddade bilder och länkade bilder**

Inbäddade och länkade bilder har olika portabilitets- och filstorlekskompromisser:

- **Embedded image:** bilddata lagras i presentationen. Presentationen är självständig, men filstorleken inkluderar bilddata.
- **Linked image:** presentationen lagrar en sökväg eller URL till en extern bild. Detta kan minska presentationens storlek, men den externa resursen måste vara tillgänglig när presentationen öppnas eller renderas.

En länkad bild kan skapas genom att tilldela den externa sökvägen eller URL:n via [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/islidespicture/) i stället för att bädda in bilddata.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, null);
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png");

    presentation.save("linked-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Använd länkade bilder endast när miljön för distribution på ett tillförlitligt sätt kan komma åt den externa resursen. För presentationer som måste fungera offline eller flyttas mellan system är inbäddade bilder vanligtvis säkrare.

## **Arbeta med SVG‑bilder**

SVG är ett vektorformat, så det kan vara användbart för ikoner, diagram och annan grafik som ska skalas utan samma detaljförlust som rasterbilder. Aspose.Slides stödjer SVG både som bildresurs och som källa för redigerbara bildformer.

### **Lägg till en SVG som bild**

Skapa en [SvgImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/svgimage/), lägg till den i bildsamlingen och placera den resulterande bildresursen i en picture frame.

```java
import com.aspose.slides.*;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("icon.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    IPPImage image = presentation.getImages().addImage(svgImage);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image);

    presentation.save("svg-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **SVG‑filer med externa resurser**

En SVG kan referera till externa bilder, stilmallar eller typsnitt. För dessa fall tillhandahåller [SvgImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/svgimage/) konstruktorer som accepterar en [IExternalResourceResolver](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iexternalresourceresolver/) och en bas‑URI. Upplösaren kan mappa en relativ URI till en tillåten absolut URI och returnera en ström för den begärda resursen.

Upplösaren gör externa resurser tillgängliga medan Aspose.Slides bearbetar SVG‑filen, men den omskriver inte SVG:n till ett självständigt dokument. Om SVG:n måste förbli portabel, bädda in dess nödvändiga resurser i själva SVG‑filen, exempelvis genom att använda `data:`‑URI:er för länkade bilder.

När SVG‑filer kommer från opålitliga källor, begränsa de scheman, filplatser och värdar som upplösaren kan komma åt. Nätverksupplösare bör också tillämpa tidsgränser, begränsningar för svarsstorlek och innehållsvalidering.

### **Konvertera SVG till redigerbara former**

Aspose.Slides kan konvertera en SVG till en grupp av redigerbara bildformer, liknande motsvarande PowerPoint‑kommando.

![PowerPoint Popup Menu](img_01_01.png)

Använd [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishapecollection/)‑överladdningen som accepterar en [ISvgImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isvgimage/) för att utföra konverteringen.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("diagram.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    SizeF slideSize = presentation.getSlideSize().getSize();
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Använd SVG‑till‑former‑konvertering när enskilda vektorelement behöver redigeras som PowerPoint‑former. Om SVG:n bara ska visas är det enklare att behålla den som en bild och undviker att skapa många separata former.

## **Ersätt en befintlig bildresurs**

Använd [IPPImage.replaceImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ippimage/) när du vill ersätta en befintlig bildresurs. Detta är särskilt användbart för delad grafik som logotyper.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IPPImage imageToReplace = presentation.getImages().get_Item(0);

    IImage replacementImage = Images.fromFile("new-logo.png");
    try {
        imageToReplace.replaceImage(replacementImage);
    } finally {
        if (replacementImage != null) replacementImage.dispose();
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Om flera picture frames, bakgrunder, masters eller layouter använder samma bildresurs, uppdaterar ersättningen av resursen alla dessa användningar. Om endast en picture frame ska ändras, tilldela en annan bild till den ramen i stället för att ersätta den delade resursen.

`replaceImage` erbjuder också överladdningar som accepterar en byte‑array eller en annan [IPPImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ippimage/).

## **Praktisk vägledning för bildhantering**

### **Styr presentationens storlek**

Stora rasterbilder kan göra en presentation onödigt stor. Använd källbilder med dimensioner som passar deras avsedda visningsstorlek, återanvänd delade bildresurser där det är möjligt, och undvik att bädda in upprepade kopior av samma högupplösta grafik.

För rasterbilder som redan placerats i picture frames kan [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipicturefillformat/) minska bilddata enligt den valda upplösningen och beskärningsinställningarna. Detta är picture‑frame‑behandling snarare än bildsamling‑hantering, så se [Picture Frame](/slides/sv/androidjava/picture-frame/) för relaterade formateringsåtgärder.

### **Välj mellan inbäddat och länkat innehåll**

Inbäddning gör presentationen portabel eftersom all nödvändig bilddata följer med filen. Länkning kan minska filstorleken, men det introducerar ett externt beroende. Använd länkar endast när detta beroende är acceptabelt och stabilt.

### **Återanvänd delad varumärkesgrafik**

För upprepade logotyper, vattenstämplar eller dekorativa grafik, använd en bildresurs och återanvänd den. Om grafiken tillhör presentationens design snarare än bildinnehåll, placera den på en master eller layout så att den ärvs av de relevanta bilderna.

### **Behåll SVG‑resurser portabla**

En självständig SVG är enklare att flytta och rendera konsekvent än en SVG som beror på externa filer eller nätverksresurser. När det är möjligt, bädda in nödvändiga resurser innan SVG importeras. Konvertera SVG till former endast när enskilda vektorelement behöver redigeras.

### **Använd det moderna plattformsoberoende bild‑API:t**

För ny Android‑via‑Java‑kod, använd Aspose.Slides [IImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iimage/) och [Images](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/images/) API:er i stället för det äldre publika API:et baserat på `android.graphics.Bitmap`. Se [Modern API](/slides/sv/androidjava/modern-api/) för migrationsvägledning.

WMF och EMF kräver särskild hänsyn. När dessa format passerar genom en [IImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iimage/), konverterar [ImageCollection.addImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imagecollection/) metafil till en raster‑PNG‑representation innan infogning. Om bevarande av metafil‑data är viktigt, använd en strömbaserad [ImageCollection.addImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imagecollection/)‑överladdning i stället. Generering av EMF‑innehåll från kalkylblad eller andra produkter är ett separat integrationsarbetsflöde och ligger utanför artikelns omfattning.

## **FAQ**

**Vad är skillnaden mellan bildsamlingen och en picture frame?**

Bildsamlingen lagrar återanvändbara bildresurser. En picture frame är en bildform som visar en av dessa resurser och erbjuder bildspecifik formatering som beskärning och effekter.

**Vad är det bästa sättet att ersätta samma logotyp överallt?**

Om logotypen redan delas som en bildresurs, ersätt den resursen med [IPPImage.replaceImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ippimage/). För varumärkesprofil på hela presentationen kan placering av logotypen på en master eller layout också minska duplicerat bildinnehåll.

**Varför försvinner en länkad bild på en annan dator?**

En länkad bild är beroende av sin externa fil eller URL. Om den resursen inte kan nås från den andra datorn kan den länkade bilden vara otillgänglig. Bädda in bilden när presentationen måste vara självständig.

**Kan en infogad SVG redigeras som PowerPoint‑former?**

Ja. Konvertera SVG:n med [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishapecollection/); den resulterande gruppen innehåller redigerbara bildformer snarare än en enda SVG‑bild.

**Hur kan jag hålla presentationer med många bilder mindre?**

Återanvänd delade bildresurser, undvik onödigt stora rasterkällor, komprimera lämpliga rasterbilder när det är lämpligt, håll upprepad varumärkesgrafik på masters eller layouter, och använd länkade bilder endast när ett externt beroende är acceptabelt.