---
title: Konvertera PowerPoint-bilder till PNG på Android
linktitle: PowerPoint till PNG
type: docs
weight: 30
url: /sv/androidjava/convert-powerpoint-to-png/
keywords:
- konvertera PowerPoint
- konvertera presentation
- konvertera bild
- konvertera PPT
- konvertera PPTX
- PowerPoint till PNG
- presentation till PNG
- bild till PNG
- PPT till PNG
- PPTX till PNG
- spara PPT som PNG
- spara PPTX som PNG
- exportera PPT till PNG
- exportera PPTX till PNG
- Android
- Java
- Aspose.Slides
description: "Konvertera PowerPoint-presentationer till högkvalitativa PNG-bilder snabbt med Aspose.Slides för Android via Java, vilket garanterar exakta, automatiserade resultat."
---
## **Översikt**

Den här artikeln förklarar hur du konverterar presentationsbilder till PNG‑bilder med Aspose.Slides för Android via Java. Du kan läsa in presentationer i format som PPT, PPTX och ODP, rendera varje bild och spara den som en separat PNG‑fil.

Exemplen nedan visar rendering med standardskala, ökad skala, angivna utgångsdimensioner i pixlar samt val av en gradientrenderingsstil.

## **Konvertera PowerPoint till PNG**

Läs in en presentation med klassen [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) och få åtkomst till dess bilder via samlingen [Presentation.getSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) . Exemplet renderar varje bild med [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage--) utan parametrar för att skapa en miniatyr. Det anropar sedan [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) med [ImageFormat.Png](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imageformat/#Png) för att spara varje renderad bild som en PNG‑fil.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage();
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Den parameterlösa överlagringen av [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage--) renderar med en skala på 0,2. Till exempel ger en bild som mäter 720 × 540 punkter en miniatyr på 144 × 108 pixlar. För att styra utgångsdimensionerna, använd överlagringarna med skalafaktorer eller en explicit bildstorlek som visas nedan.
{{% /alert %}}

## **Konvertera PowerPoint till PNG med anpassade dimensioner**

Skicka horisontella och vertikala skalafaktorer till [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-float-float-) för att kontrollera de renderade dimensionerna. I det här exemplet är båda faktorerna 2, så en bild som mäter 720 × 540 punkter ger en bild på 1440 × 1080 pixlar. Lika skalafaktorer bevarar bildens bildförhållande. Varje bild sparas i PNG‑format med [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) .

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    float scaleX = 2f;
    float scaleY = scaleX;

    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(scaleX, scaleY);
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Konvertera PowerPoint till PNG med anpassad storlek**

För att ange utgångsdimensionerna i pixlar, skicka en storlek till [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) istället för skalafaktorer. Detta exempel renderar varje bild i 960 × 720 pixlar och sparar resultatet med [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) . Välj dimensioner som matchar bildens bildförhållande för att undvika att bilden sträcks.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.Size;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Size imageSize = new Size(960, 720);

    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(imageSize);
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Välj en gradientrenderingsstil**

Anta att en bild innehåller gradientfyllningar, men övergångarna i den exporterade PNG‑filen ser ljusare eller på annat sätt annorlunda ut än i PowerPoint. Du kan använda metoden [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setGradientStyle-int-) som ärvs av [RenderingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/renderingoptions/) för att välja hur gradienterna renderas.

Ladda ner [gradient-styles.pptx](gradient-styles.pptx) och placera den i applikationens arbetskatalog. Dess första bild innehåller två linjära gradienter: cyan till orange högst upp och blå till gul längst ner. Varje gradient har två stopp, vid 0 % och 100 %.

Följande exempel läser in den här presentationen och renderar samma första bild i båda lägena med [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) .

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("gradient-styles.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int[] gradientStyles = { GradientStyle.Default, GradientStyle.PowerPointUI };
    for (int style : gradientStyles) {
        RenderingOptions options = new RenderingOptions();
        options.setGradientStyle(style);

        String styleName = style == GradientStyle.Default ? "Default" : "PowerPointUI";
        IImage image = slide.getImage(options, 1f, 1f);
        try {
            image.save("gradient-" + styleName + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

Bilderna nedan visar resultatet från samma bild, med båda gradienterna i varje bild:

| Default | PowerPointUI |
| --- | --- |
| ![Cyan‑till‑orange och blå‑till‑gul gradienter renderade med Default](gradient-Default.png) | ![Samma gradienter renderade med PowerPointUI](gradient-PowerPointUI.png) |

I detta exempel ger `Default` ljusare mellanfärger, medan `PowerPointUI` ger mörkare mellanfärger. Skillnaden beror på färgerna och stopparna i gradienten.

Välj `Default` när den standardmässiga Aspose.Slides‑utgången passar dina behov. Använd `PowerPointUI` när din prioritet är att matcha utseendet i PowerPoint. Jämför båda resultaten med ditt avsedda resultat; ingen av lägena är generellt överlägsna.

## **FAQ**

**Hur kan jag exportera en specifik form, till exempel ett diagram eller en bild, i stället för hela bilden?**

Aspose.Slides stöder [generating thumbnails for individual shapes](/slides/sv/androidjava/create-shape-thumbnails/), vilket låter dig rendera en form som en PNG‑bild.

**Stöds parallell konvertering på en server?**

Ja. Använd en separat presentationsinstans för varje tråd eller process; [do not share a single instance across threads](/slides/sv/androidjava/multithreading/) .

**Vilka begränsningar finns i utvärderingsläget vid export till PNG?**

Utvärderingsläge lägger till ett vattenstämpel på utdatabilder och tillämpar [other restrictions](/slides/sv/androidjava/licensing/) tills en licens har aktiverats.