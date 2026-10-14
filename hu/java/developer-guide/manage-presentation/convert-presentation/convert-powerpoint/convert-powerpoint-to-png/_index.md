---
title: PowerPoint diák konvertálása PNG-re Java-ban
linktitle: PowerPoint PNG-re
type: docs
weight: 30
url: /hu/java/convert-powerpoint-to-png/
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
- Java
- Aspose.Slides
description: "Konvertálja a PowerPoint prezentációkat gyorsan magas minőségű PNG képekké az Aspose.Slides for Java segítségével, biztosítva a pontos, automatizált eredményeket."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet a prezentációs diákra PNG képeket konvertálni az Aspose.Slides for Java segítségével. Betöltheti a prezentációkat PPT, PPTX és ODP formátumokban, renderelheti az egyes diát, és különálló PNG képként mentheti el.

Az alábbi példák az alapértelmezett méretezés szerinti renderelést, a méretezés növelését, a kimeneti méretek pixelben való megadását és a gradient renderelési stílus választását mutatják be.

## **PowerPoint konvertálása PNG-re**

Töltsön be egy prezentációt a [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) osztály segítségével, és férjen hozzá a diákhoz a [Presentation.getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) gyűjteményen keresztül. A példa minden diát a [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage--) paraméter nélküli hívásával renderel egy bélyegképet. Ezután a [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) függvényt hívja a [ImageFormat.Png](https://reference.aspose.com/slides/java/com.aspose.slides/imageformat/#Png) formátummal, hogy minden renderelt diát PNG képként mentse.

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
A paraméter nélküli [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage--) túlterhelés 0,2‑es skálán renderel. Például egy 720 × 540 pont méretű dia 144 × 108 pixel bélyegképet eredményez. A kimeneti méretek szabályozásához használja a skálafaktorokkal vagy a lenti példában látható explicit képmérettel ellátott túlterheléseket.
{{% /alert %}}

## **PowerPoint konvertálása PNG-re egyéni méretekkel**

Adjon meg vízszintes és függőleges skálafaktorokat a [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage-float-float-) metódusnak a renderelt méretek szabályozásához. Ebben a példában mindkét tényező 2, így egy 720 × 540 pont méretű dia 1440 × 1080 pixeles képet eredményez. Az egyenlő skálafaktorok megőrzik a dia képarányát. Minden képet PNG formátumban ment a [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-).

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

## **PowerPoint konvertálása PNG-re egyéni mérettel**

A kimeneti méretek pixelben való megadásához a skálafaktorok helyett adjon át egy méretet a [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) metódusnak. Ez a példa minden diát 960 × 720 pixelben renderel, és az eredményt a [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) menti. Válasszon olyan méreteket, amelyek megegyeznek a dia képarányával, hogy elkerülje a kép nyújtását.

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

## **Gradient renderelési stílus kiválasztása**

Tegyük fel, hogy egy dián gradient kitöltések vannak, de a PNG-ben exportált átmenetek világosabbak vagy másként különböznek attól, amit a PowerPointban lát. A [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setGradientStyle-int-) metódust használhatja, amelyet a [RenderingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/renderingoptions/) örököl, a gradientek renderelésének módjának kiválasztásához.

Töltse le a [gradient-styles.pptx](gradient-styles.pptx) fájlt, és helyezze az alkalmazás munkakönyvtárába. Első diája két lineáris gradientet tartalmaz: a tetején ciánból narancsba, az alján kékről sárgára. Minden gradientnek két állomása van, 0 % és 100 %.

Az alábbi példa betölti ezt a prezentációt, és a [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) segítségével mindkét módban rendereli ugyanazt az első diát.

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

Az alábbi képek ugyanazon dia kimenetét mutatják, mindkét gradient minden képen:

| Alapértelmezett | PowerPointUI |
| --- | --- |
| ![Cianról narancsra és kékről sárgára gradientek, az Alapértelmezett móddal renderelve](gradient-Default.png) | ![Ugyanazok a gradientek, a PowerPointUI-val renderelve](gradient-PowerPointUI.png) |

Ebben a példában a `Default` világosabb köztes színeket eredményez, míg a `PowerPointUI` sötétebb köztes színeket. A különbség a gradient színeitől és állomásaitól függ.

Válassza a `Default`-ot, ha a standard Aspose.Slides kimenet megfelel az igényeinek. Próbálja ki a `PowerPointUI`-t, ha az elsődleges cél a PowerPoint megjelenésének egyezése. Hasonlítsa össze mindkét kimenetet a kívánt eredménnyel; egyik mód sem tekinthető általánosan előnyösebbnek.

## **GYIK**

**Hogyan exportálhatok egy konkrét alakzatot, például diagramot vagy képet, a teljes dia helyett?**

Az Aspose.Slides támogatja az [egyedi alakzatok bélyegképeinek létrehozását](/slides/hu/java/create-shape-thumbnails/), lehetővé téve egy alakzat PNG képként való renderelését.

**Támogatott a párhuzamos konvertálás szerveren?**

Igen. Használjon külön prezentációs példányt minden szál vagy folyamat számára; [ne osszon meg egyetlen példányt a szálak között](/slides/hu/java/multithreading/).

**Mik a kiértékelési korlátozások PNG exportálásakor?**

A kiértékelési mód vízjelet helyez a kimeneti képekre, és [egyéb korlátozásokat](/slides/hu/java/licensing/) alkalmaz, amíg licencet nem adnak meg.