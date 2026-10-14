---
title: PowerPoint‑slides omzetten naar PNG in Java
linktitle: PowerPoint naar PNG
type: docs
weight: 30
url: /nl/java/convert-powerpoint-to-png/
keywords:
- PowerPoint converteren
- presentatie converteren
- slide converteren
- PPT converteren
- PPTX converteren
- PowerPoint naar PNG
- presentatie naar PNG
- slide naar PNG
- PPT naar PNG
- PPTX naar PNG
- PPT opslaan als PNG
- PPTX opslaan als PNG
- PPT exporteren naar PNG
- PPTX exporteren naar PNG
- Java
- Aspose.Slides
description: "Converteer PowerPoint‑presentaties snel naar hoogwaardige PNG‑afbeeldingen met Aspose.Slides voor Java, waardoor nauwkeurige, geautomatiseerde resultaten worden gegarandeerd."
---
## **Overzicht**

Dit artikel legt uit hoe u presentatieslides kunt converteren naar PNG‑afbeeldingen met Aspose.Slides voor Java. U kunt presentaties laden in formaten zoals PPT, PPTX en ODP, elke slide renderen en opslaan als een afzonderlijke PNG‑afbeelding.

De onderstaande voorbeelden tonen het renderen op de standaard schaal, het verhogen van de schaal, het specificeren van de uitvoerafmetingen in pixels, en het kiezen van een gradientrenderingsstijl.

## **PowerPoint converteren naar PNG**

Laad een presentatie met de [Presentatie](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) class en krijg toegang tot de slides via de [Presentation.getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) collectie. Het voorbeeld rendert elke slide met [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage--) zonder parameters om een thumbnail te maken. Vervolgens wordt [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) aangeroepen met [ImageFormat.Png](https://reference.aspose.com/slides/java/com.aspose.slides/imageformat/#Png) om elke gerenderde slide op te slaan als een PNG‑afbeelding.

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
De parameterloze [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage--) overload rendert op een schaal van 0.2. Bijvoorbeeld, een slide van 720 × 540 punten levert een thumbnail van 144 × 108 pixels op. Om de uitvoerafmetingen te beheersen, gebruik de overloads met schaalfactoren of een expliciete afbeeldingsgrootte zoals hieronder weergegeven.
{{% /alert %}}

## **PowerPoint converteren naar PNG met aangepaste afmetingen**

Geef horizontale en verticale schaalfactoren door aan [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage-float-float-) om de gerenderde afmetingen te regelen. In dit voorbeeld zijn beide factoren 2, waardoor een slide van 720 × 540 punten een afbeelding van 1440 × 1080 pixels oplevert. Gelijke schaalfactoren behouden de beeldverhouding van de slide. Elke afbeelding wordt opgeslagen in PNG‑formaat met [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-).

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

## **PowerPoint converteren naar PNG met aangepaste grootte**

Om de uitvoerafmetingen in pixels te specificeren, geef een grootte door aan [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) in plaats van schaalfactoren. Dit voorbeeld rendert elke slide op 960 × 720 pixels en slaat het resultaat op met [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-). Kies afmetingen die overeenkomen met de beeldverhouding van de slide om uitrekken van de afbeelding te voorkomen.

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Dimension imageSize = new Dimension(960, 720);

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

## **Kies een gradientrenderingsstijl**

Stel dat een slide verlopenvullingen bevat, maar de overgangen in de geëxporteerde PNG lichter of anders lijken dan in PowerPoint. U kunt de [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setGradientStyle-int-) methode, geërfd door [RenderingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/renderingoptions/), gebruiken om te kiezen hoe de verlopen worden gerenderd.

Download [gradient-styles.pptx](gradient-styles.pptx) en plaats het in de werkmap van de applicatie. De eerste slide bevat twee lineaire verlopen: cyaan naar oranje bovenaan en blauw naar geel onderaan. Elk verloop heeft twee stops, op 0 % en 100 %.

Het volgende voorbeeld laadt deze presentatie en rendert dezelfde eerste slide in beide modi met [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-float-float-).

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

De onderstaande afbeeldingen tonen de output van dezelfde slide, met beide verlopen in elke afbeelding:

| Standaard | PowerPointUI |
| --- | --- |
| ![Cyaan-naar-oranje en blauw-naar-geel verlopen gerenderd met Standaard](gradient-Default.png) | ![Dezelfde verlopen gerenderd met PowerPointUI](gradient-PowerPointUI.png) |

In dit voorbeeld produceert `Standaard` lichtere tussentoonkleuren, terwijl `PowerPointUI` donkerdere tussentoonkleuren produceert. Het verschil hangt af van de kleuren en stops in het verloop.

Kies `Standaard` wanneer de standaard Aspose.Slides output aan uw wensen voldoet. Probeer `PowerPointUI` wanneer uw prioriteit is om de weergave in PowerPoint te evenaren. Vergelijk beide outputs met uw beoogde resultaat; geen van beide modi is universeel beter.

## **FAQ**

**Hoe kan ik een specifieke vorm, zoals een diagram of afbeelding, exporteren in plaats van de hele slide?**

Aspose.Slides ondersteunt [het genereren van miniaturen voor individuele vormen](/slides/nl/java/create-shape-thumbnails/), waardoor u een vorm als PNG‑afbeelding kunt renderen.

**Wordt parallelle conversie ondersteund op een server?**

Ja. Gebruik een afzonderlijke presentatie‑instantie voor elke thread of elk proces; [deel geen enkele instantie over threads](/slides/nl/java/multithreading/).

**Wat zijn de evaluatiebeperkingen bij het exporteren naar PNG?**

De evaluatiemodus voegt een watermerk toe aan de uitvoerafbeeldingen en past [andere beperkingen](/slides/nl/java/licensing/) toe totdat een licentie is geïnstalleerd.