---
title: PowerPoint diák konvertálása PNG-re Androidon
linktitle: PowerPoint PNG-re
type: docs
weight: 30
url: /hu/androidjava/convert-powerpoint-to-png/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- dia konvertálása
- PPT konvertálása
- PPTX konvertálása
- PowerPoint PNG-re
- prezentáció PNG-re
- dia PNG-re
- PPT PNG-re
- PPTX PNG-re
- PPT mentése PNG-ként
- PPTX mentése PNG-ként
- PPT exportálása PNG-be
- PPTX exportálása PNG-be
- Android
- Java
- Aspose.Slides
description: "Konvertálja a PowerPoint prezentációkat gyorsan magas minőségű PNG képekké az Aspose.Slides for Android Java segítségével, biztosítva a pontos, automatizált eredményeket."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan lehet a bemutató diákat PNG képekké konvertálni az Aspose.Slides for Android Java segítségével. Betöltheti a bemutatókat olyan formátumokban, mint a PPT, PPTX és ODP, megjelenítheti az egyes diát, és különálló PNG képként mentheti el.  
Az alábbi példák bemutatják a megjelenítést alapértelmezett méretezésben, a méretezés növelését, a kimeneti méretek pixelben való megadását, valamint a gradient megjelenítési stílus kiválasztását.

## **PowerPoint konvertálása PNG**

Betöltsön egy bemutatót a [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) osztállyal, és a diákhoz a [Presentation.getSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) gyűjteményen keresztül férjen hozzá. A példa minden diát a [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage--) paraméterek nélkül renderel, hogy előnézeti képet hozzon létre. Ezután a [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) metódust hívja meg a [ImageFormat.Png](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imageformat/#Png) segítségével, hogy az egyes renderelt diák PNG képként kerüljenek mentésre.

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
A paraméter nélküli [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage--) túlterhelés 0,2-s méretezésben renderel. Például egy 720 × 540 pont méretű dia 144 × 108 képpontos előnézeti képet eredményez. A kimeneti méretek szabályozásához használja a méretarányokkal vagy egy explicit képmérettel rendelkező túlterheléseket az alább láthatóak szerint.
{{% /alert %}}

## **PowerPoint konvertálása PNG egyéni méretekkel**

Adjon át vízszintes és függőleges méretarányokat a [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-float-float-) metódusnak a renderelt méretek szabályozásához. Ebben a példában mindkét arány 2, így egy 720 × 540 pont méretű dia 1440 × 1080 képpontos képet eredményez. Az egyenlő méretarányok megőrzik a dia képarányát. Minden képet PNG formátumban ment a [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) metódus.

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

## **PowerPoint konvertálása PNG egyéni mérettel**

A kimeneti méretek pixelben való megadásához adjon át egy méretet a [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) metódusnak a méretarányok helyett. Ez a példa minden diát 960 × 720 pixel méretben renderel, és az eredményt a [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) metódussal menti. Válasszon olyan méreteket, amelyek megegyeznek a dia képarányával, hogy elkerülje a kép nyújtását.

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

## **Gradient megjelenítési stílus kiválasztása**

Tegyük fel, hogy egy dián gradient kitöltések vannak, de az exportált PNG átalakulásai világosabbak vagy másképp különböznek attól, amit a PowerPointban lát. A [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setGradientStyle-int-) metódust, amelyet a [RenderingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/renderingoptions/) örököl, felhasználhatja a gradientek megjelenítésének módjának kiválasztásához.  
Töltse le a [gradient-styles.pptx](gradient-styles.pptx) fájlt, és helyezze az alkalmazás munkakönyvtárába. Az első dia két lineáris gradientet tartalmaz: ciántól narancssárgáig felül, és kéktől sárgáig alul. Minden gradientnek két színállása van, 0 % és 100 % pontokon.  
A következő példa betölti ezt a bemutatót, és a [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) metódussal mindkét módban rendereli az első diát.

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

Az alábbi képek az ugyanabból a diából származó kimenetet mutatják, mindkét gradient mindegyik képen:

| Default | PowerPointUI |
| --- | --- |
| ![Cian‑narancssárga és kék‑sárga gradientek, az Alapértelmezett mód](gradient-Default.png) | ![Ugyanazok a gradientek, a PowerPointUI mód használatával](gradient-PowerPointUI.png) |

Ebben a példában a `Default` világosabb köztes színeket eredményez, míg a `PowerPointUI` sötétebb köztes színeket. A különbség a gradient színeitől és színállásaitól függ.  
Válassza a `Default`‑t, ha a szabványos Aspose.Slides kimenet megfelel az igényeinek. Próbálja a `PowerPointUI`‑t, ha elsődleges célja a PowerPoint megjelenésének pontos egyezése. Hasonlítsa össze mindkét kimenetet a kívánt eredménnyel; egyik mód sem általánosan jobb.

## **GYIK**

**Hogyan exportálhatok egy meghatározott alakzatot, például diagramot vagy képet, a teljes dia helyett?**  
Az Aspose.Slides támogatja az [egyedi alakzatok előnézeti képeinek létrehozását](/slides/hu/androidjava/create-shape-thumbnails/), így egy alakzat PNG képként is renderelhető.

**Támogatott a párhuzamos konverzió egy szerveren?**  
Igen. Minden szál vagy folyamat számára használjon külön bemutató példányt; [ne osszon meg egyetlen példányt a szálak között](/slides/hu/androidjava/multithreading/).

**Mik azok az értékelési korlátozások PNG exportáláskor?**  
Az értékelő mód vízjelet helyez el a kimeneti képeken, és [további korlátozásokat](/slides/hu/androidjava/licensing/) alkalmaz, amíg licencet nem adnak meg.