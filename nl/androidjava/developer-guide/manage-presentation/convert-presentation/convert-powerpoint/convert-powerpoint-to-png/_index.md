---
title: PowerPoint-dia's converteren naar PNG op Android
linktitle: PowerPoint naar PNG
type: docs
weight: 30
url: /nl/androidjava/convert-powerpoint-to-png/
keywords:
- PowerPoint converteren
- presentatie converteren
- dia converteren
- PPT converteren
- PPTX converteren
- PowerPoint naar PNG
- presentatie naar PNG
- dia naar PNG
- PPT naar PNG
- PPTX naar PNG
- PPT opslaan als PNG
- PPTX opslaan als PNG
- PPT exporteren naar PNG
- PPTX exporteren naar PNG
- Android
- Java
- Aspose.Slides
description: "Converteer PowerPoint-presentaties snel naar PNG-afbeeldingen van hoge kwaliteit met Aspose.Slides voor Android via Java, en zorg voor nauwkeurige, geautomatiseerde resultaten."
---
## **Overzicht**

Dit artikel legt uit hoe u presentatieslides kunt converteren naar PNG‑afbeeldingen met Aspose.Slides voor Android via Java. U kunt presentaties laden in formaten zoals PPT, PPTX en ODP, elke slide renderen en deze opslaan als een afzonderlijke PNG‑afbeelding.

De onderstaande voorbeelden tonen het renderen op de standaard schaal, het verhogen van de schaal, het specificeren van de uitvoerafmetingen in pixels en het kiezen van een verlooprenderingsstijl.

## **PowerPoint naar PNG converteren**

Laad een presentatie met de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)‑klasse en krijg toegang tot de slides via de [Presentation.getSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) collectie. Het voorbeeld rendert elke slide met [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage--) zonder parameters om een miniatuur te maken. Vervolgens wordt [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) aangeroepen met [ImageFormat.Png](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imageformat/#Png) om elke gerenderde slide op te slaan als een PNG‑afbeelding.

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
De overload van [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage--) zonder parameters rendert op een schaal van 0,2. Een slide van 720 × 540 punten levert bijvoorbeeld een miniatuur van 144 × 108 pixels op. Om de uitvoerafmetingen te beheersen, gebruik de overloads met schaalfactoren of een expliciete afbeeldingsgrootte zoals hieronder weergegeven.
{{% /alert %}}

## **PowerPoint naar PNG converteren met aangepaste afmetingen**

Geef horizontale en verticale schaalfactoren door aan [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-float-float-) om de gerenderde afmetingen te regelen. In dit voorbeeld zijn beide factoren 2, waardoor een slide van 720 × 540 punten een afbeelding van 1440 × 1080 pixels oplevert. Gelijke schaalfactoren behouden de beeldverhouding van de slide. Elke afbeelding wordt opgeslagen in PNG‑formaat met [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-).

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

## **PowerPoint naar PNG converteren met aangepaste grootte**

Om de uitvoerafmetingen in pixels op te geven, geef een grootte door aan [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) in plaats van schaalfactoren. Dit voorbeeld rendert elke slide op 960 × 720 pixels en slaat het resultaat op met [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-). Kies afmetingen die overeenkomen met de beeldverhouding van de slide om uitrekken van de afbeelding te voorkomen.

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

## **Kies een verlooprenderingsstijl**

Stel dat een slide verloopvullingen bevat, maar de overgangen in de geëxporteerde PNG lichter of anders lijken dan wat u in PowerPoint ziet. U kunt de [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setGradientStyle-int-)‑methode, geërfd van [RenderingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/renderingoptions/), gebruiken om te bepalen hoe de verlopen worden gerenderd.

Download [gradient-styles.pptx](gradient-styles.pptx) en plaats het in de werkmap van de applicatie. De eerste slide bevat twee lineaire verlopen: cyaan naar oranje bovenaan en blauw naar geel onderaan. Elke verloop heeft twee stops, op 0 % en 100 %.

Het volgende voorbeeld laadt deze presentatie en rendert dezelfde eerste slide in beide modi met [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-float-float-).

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

De afbeeldingen hieronder tonen de output van dezelfde slide, met beide verlopen in elke afbeelding:

| Default | PowerPointUI |
| --- | --- |
| ![Cyaan‑naar‑oranje en blauw‑naar‑geel verlopen gerenderd met Default](gradient-Default.png) | ![Dezelfde verlopen gerenderd met PowerPointUI](gradient-PowerPointUI.png) |

In dit voorbeeld levert `Default` lichtere tussentoonkleuren op, terwijl `PowerPointUI` donkerdere tussentoonkleuren oplevert. Het verschil hangt af van de kleuren en stops in het verloop.

Kies `Default` wanneer de standaard output van Aspose.Slides aan uw behoeften voldoet. Probeer `PowerPointUI` wanneer uw prioriteit is om de weergave in PowerPoint te evenaren. Vergelijk beide outputs met het beoogde resultaat; geen van beide modi is universeel beter.

## **Veelgestelde vragen**

**Hoe kan ik een specifiek object, zoals een grafiek of afbeelding, exporteren in plaats van de hele slide?**

Aspose.Slides ondersteunt [het genereren van miniaturen voor individuele objecten](/slides/nl/androidjava/create-shape-thumbnails/), waardoor u een object kunt renderen als een PNG‑afbeelding.

**Wordt parallelle conversie ondersteund op een server?**

Ja. Gebruik een aparte presentatie‑instance voor elke thread of elk proces; [deel geen enkele instance over threads](/slides/nl/androidjava/multithreading/).

**Wat zijn de evaluatiebeperkingen bij het exporteren naar PNG?**

De evaluatiemodus voegt een watermerk toe aan de uitvoer‑afbeeldingen en past [andere beperkingen](/slides/nl/androidjava/licensing/) toe totdat een licentie is geïnstalleerd.