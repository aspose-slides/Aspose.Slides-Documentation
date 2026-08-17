---
title: Prezentáció placeholder-ek kezelése Androidon
linktitle: Placeholder-ek kezelése
type: docs
weight: 10
url: /hu/androidjava/manage-placeholder/
keywords:
- helykitöltő
- szöveghelykitöltő
- képhelykitöltő
- diagramhelykitöltő
- tartalomhelykitöltő
- utasító szöveg
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan ellenőrizheti és szerkesztheti a szöveg, kép, diagram és tartalom helykitöltőket, valamint hogyan értheti meg a placeholder öröklődést az Aspose.Slides for Android Java segítségével."
---
## **Áttekintés**

A placeholder egy alakzat, amely helyet foglal egy adott típusú tartalom számára egy prezentációs sablonban. Gyakori példák a cím, a törzs, a kép, a diagram és az általános célú tartalomplaceholder-ek. A szokásos alakzattal ellentétben a placeholder örökölheti a pozícióját, méretét, formázását és egyéb beállításait egy elrendezés vagy mesterdia alapján.

Az Aspose.Slides a placeholder információkat a [IShape.getPlaceholder](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/) metóduson keresztül teszi elérhetővé. A metódus egy [IPlaceholder](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/placeholder/) objektumot vagy `null`-t ad vissza egy normál alakzat esetén. Használd a [IPlaceholder.getType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/placeholder/) metódust annak meghatározására, hogy a placeholder milyen tartalmat kell tartalmazzon.

Az alakzat interfész még mindig fontos, miután ismered a placeholder típusát:

- Egy üres szöveg, kép, diagram vagy tartalom placeholder általában egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) által van reprezentálva.
- Egy feltöltött képpel rendelkező placeholder reprezentálható egy [IPictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipictureframe/).
- Egy feltöltött diagram placeholder reprezentálható egy [IChart](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichart/).
- Egy tartalom placeholder többféle tartalmat is tartalmazhat. Ellenőrizd mind a [IPlaceholder.getType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/placeholder/) mind a futási időben lévő alakzat interfészt, ahelyett, hogy azt feltételeznéd, hogy minden placeholder egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/placeholder/) leírja a placeholder szerepét; nem garantálja az alakzat futási időbeli típusát. Mindig végezz típusellenőrzést, mielőtt szöveghez, képhez, diagramhoz, táblához vagy média‑specifikus tagokhoz férnél hozzá.
{{% /alert %}}

## **A placeholder öröklődés megértése**

A placeholder-ek hierarchiát alkotnak:

1. A mesterdia meghatározza az újrahasználható stílusokat, és bizonyos esetekben a mester szintű placeholder-eket.
2. Az elrendezésdia meghatározza az elrendezést, amelyet egy vagy több normál dia használ, és örökölhet a mestertől.
3. A normál dia tartalmazza az adott dia placeholder-eit, és örökölhet az elrendezéséből.

Hívd meg az [IShape.getBasePlaceholder](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/) metódust, hogy egy szinttel feljebb lépj ebben a hierarchiában. Egy dia placeholder általában visszaadja az elrendezés placeholder‑ét; egy elrendezés placeholder visszaadhatja a mester placeholder‑ét. A metódus `null`‑t ad vissza, ha az alakzatnak nincs alapplaceholder‑je.

A következő példában felsorolja az első dián lévő placeholder-eket, és jelentést készít azok alapplaceholder‑eiről:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        String typeName = shape.getClass().getSimpleName();
        String slidePlaceholderMessage = "Slide placeholder: " + placeholderType + "; shape interface: " + typeName;
        System.out.println(slidePlaceholderMessage);

        IShape layoutPlaceholder = shape.getBasePlaceholder();
        if (layoutPlaceholder != null) {
            IPlaceholder layoutPlaceholderInfo = layoutPlaceholder.getPlaceholder();
            Byte layoutPlaceholderType = layoutPlaceholderInfo == null ? null : layoutPlaceholderInfo.getType();
            String layoutPlaceholderMessage = "  Layout placeholder: " + layoutPlaceholderType;
            System.out.println(layoutPlaceholderMessage);

            IShape masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
            if (masterPlaceholder != null) {
                IPlaceholder masterPlaceholderInfo = masterPlaceholder.getPlaceholder();
                Byte masterPlaceholderType = masterPlaceholderInfo == null ? null : masterPlaceholderInfo.getType();
                String masterPlaceholderMessage = "  Master placeholder: " + masterPlaceholderType;
                System.out.println(masterPlaceholderMessage);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Egy placeholder szerkesztése egy normál dián helyi felülírást hoz létre vagy módosít azon a dián. A kapcsolódó elrendezés vagy mester szerkesztése minden olyan diát befolyásolhat, amely még örökli ezt a beállítást. Egy helyi szokásos alakzatnak nincs alapplaceholder‑je, és nem kezd öröklődni csak azért, mert ugyanazokat a koordinátákat foglalja el.

## **Szöveg módosítása placeholder-ben**

A cím, középre igazított cím, alcím, törzs és szöveg placeholder-ek általában támogatják a szöveget. Ellenőrizd, hogy az alakzat [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/), mielőtt a [getTextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) metódusát használnád.

Ez a példa frissíti az első cím placeholder‑t az első dián, és elmenti az eredményt:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape titleShape = null;

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IAutoShape)) {
            continue;
        }

        IAutoShape autoShape = (IAutoShape) shape;
        IPlaceholder placeholder = autoShape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) {
            titleShape = autoShape;
            break;
        }
    }

    if (titleShape == null) {
        throw new IllegalStateException("The first slide does not contain a title placeholder.");
    }

    titleShape.getTextFrame().setText("Quarterly Business Review");
    presentation.save("title-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ez a minta elkerüli a kép, diagram, tábla vagy média placeholder-ek [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/)-re való átkonvertálását. Emellett a placeholder‑t a célja szerint azonosítja, ahelyett, hogy egy törékeny alakzat indexre hagyatkozna.

## **Prompt szöveg beállítása elrendezésben**

A prompt szöveg egy tervezési időbeli utasítás, amely egy üres placeholder‑ben jelenik meg, például *Kattintson a cím hozzáadásához*. Egyedi prompt szöveget állíts be az elrendezés placeholder‑én, ahelyett, hogy a normál dia alakzatgyűjteményén keresztül próbálnád elérni. Az elrendezéshez férj hozzá az [ISlide.getLayoutSlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islide/) metódussal, és iterálj a [ILayoutSlide.getShapes](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibaseslide/) által visszaadott gyűjteményen.

A következő példa megváltoztatja a cím és az alcím prompt szövegeit az első dián használt elrendezésen:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ILayoutSlide layoutSlide = presentation.getSlides().get_Item(0).getLayoutSlide();

    for (IShape shape : layoutSlide.getShapes()) {
        if (!(shape instanceof IAutoShape)) {
            continue;
        }

        IAutoShape autoShape = (IAutoShape) shape;
        IPlaceholder placeholder = autoShape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();

        if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) {
            autoShape.getTextFrame().setText("Enter a concise slide title");
        } else if (placeholderType == PlaceholderType.Subtitle) {
            autoShape.getTextFrame().setText("Enter a subtitle or reporting period");
        }
    }

    presentation.save("custom-placeholder-prompts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A prompt szöveg nem normál dia tartalom. Üres placeholder-ekben szerkesztőalkalmazások, például a PowerPoint számára szolgál utasításként. Amint a felhasználó vagy program valódi tartalmat ad meg, a prompt már nem jelenik meg. A prompt módosítása nem ír felül meglévő szöveget azokat a diákon, amelyek az elrendezést használják.

## **Kép placeholder frissítése**

Két esetet kell kezelni:

- Ha a kép placeholder már fel van töltve és egy [IPictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipictureframe/) reprezentálja, cseréld le a képet a [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipicturefillformat/) és az [ISlidesPicture.setImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islidespicture/) metódusokkal.
- Ha még üres placeholder‑ről van szó, adj hozzá egy képkeretet a placeholder koordinátáihoz a [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishapecollection/) segítségével, majd távolítsd el az üres placeholder‑t.

A következő példa mindkét esetet támogatja, és elmenti a prezentációt:

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation("picture-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape picturePlaceholder = null;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() == PlaceholderType.Picture) {
            picturePlaceholder = shape;
            break;
        }
    }

    if (picturePlaceholder == null) {
        throw new IllegalStateException("The first slide does not contain a picture placeholder.");
    }

    IPPImage image;
    try (FileInputStream imageStream = new FileInputStream("replacement.png")) {
        image = presentation.getImages().addImage(imageStream);
    }

    if (picturePlaceholder instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) picturePlaceholder;
        pictureFrame.getPictureFormat().getPicture().setImage(image);
    } else {
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, picturePlaceholder.getX(), picturePlaceholder.getY(), picturePlaceholder.getWidth(), picturePlaceholder.getHeight(), image);
        slide.getShapes().remove(picturePlaceholder);
    }

    presentation.save("picture-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az üres placeholder számára létrehozott helyettesítés egy helyi képkeret, nem új placeholder, mivel az [IShape.getPlaceholder](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/) nem biztosít beállítót. Megtartja a lefoglalt pozíciót, de már nem örököl placeholder‑specifikus viselkedést. Ha a placeholder‑kapcsolat megtartása lényeges, előbb készítsd el és töltsd fel a placeholder‑t PowerPointban, majd frissítsd a kapott [IPictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipictureframe/) objektumot az Aspose.Slides‑kel.

Képarányosság, vágás és egyéb kép‑specifikus hatások tekintetében lásd a [Manage Picture Frames](/slides/hu/androidjava/picture-frame/) cikket. Ezek a műveletek a képkerethez vagy a képkitöltéshez tartoznak, nem a placeholder metaadatokhoz.

## **Diagram és tartalom placeholder-ek kezelése**

Egy feltöltött diagram placeholder reprezentálható egy [IChart](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichart/) segítségével. Ez a példa megtalálja az ilyen diagramot a placeholder típusa és a futási időbeli interfész alapján, módosítja a címét, majd elmenti a fájlt:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart placeholderChart = null;

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) {
            continue;
        }

        IChart chart = (IChart) shape;
        IPlaceholder placeholder = chart.getPlaceholder();
        if (placeholder != null && placeholder.getType() == PlaceholderType.Chart) {
            placeholderChart = chart;
            break;
        }
    }

    if (placeholderChart == null) {
        throw new IllegalStateException("The first slide does not contain a populated chart placeholder.");
    }

    placeholderChart.setTitle(true);
    placeholderChart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    presentation.save("chart-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Egy általános tartalom placeholder általában a [PlaceholderType.Object](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/placeholdertype/) értékkel rendelkezik. A PowerPointban ez többféle tartalomtípus—diagramok, táblák, diagramok, képek és média—elindítására szolgál. Miután fel lett töltve, vizsgáld meg a tényleges alakzat interfészt, hogy megtudd, mit tartalmaz. Specializált elrendezések a [PlaceholderType.Chart](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/placeholdertype/), vagy [PlaceholderType.Diagram](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/placeholdertype/) értékeket is fel tudnak mutatni.

Az Aspose.Slides nem konvertál egy üres [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) placeholder‑t egy [IChart](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichart/) objektummá csupán a [IPlaceholder.getType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/placeholder/) módosításával; a típust a felület nem engedi megváltoztatni. Egy üres diagram vagy tartalomterület programból való kitöltéséhez add hozzá a szükséges objektumot a placeholder koordinátáihoz, majd távolítsd el az üres placeholder‑t. A következő példa ezt teszi egy diagram esetén:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("content-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape targetPlaceholder = null;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        if (placeholderType == PlaceholderType.Chart || placeholderType == PlaceholderType.Object) {
            targetPlaceholder = shape;
            break;
        }
    }

    if (targetPlaceholder == null) {
        throw new IllegalStateException("The first slide does not contain a chart or content placeholder.");
    }

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, targetPlaceholder.getX(), targetPlaceholder.getY(), targetPlaceholder.getWidth(), targetPlaceholder.getHeight());
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    slide.getShapes().remove(targetPlaceholder);
    presentation.save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A hozzáadott diagram egy egyszerű helyi diagram. Kitölti a placeholder területét, de nem örököl az elrendezés placeholder‑éből. Használd a dedikált [chart management articles](/slides/hu/androidjava/powerpoint-charts/) anyagot, ha cserélni kell a kategóriákat, sorozatokat vagy a munkafüzet adatokat.

## **Teljes példa: Szöveg vagy kép tartalom frissítése**

A következő end‑to‑end példa megnyit egy sablont, keres az első dián cím vagy kép placeholder‑t, ellenőrzi a placeholder és az alakzat típusát, frissíti a megfelelő tartalmat, majd elmenti a kimenetet. A példa szándékosan kerüli a alakzat index feltételezését vagy minden placeholder közös interfészre való átkonvertálását.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    boolean updated = false;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();

        if ((placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) && shape instanceof IAutoShape) {
            IAutoShape titleShape = (IAutoShape) shape;
            titleShape.getTextFrame().setText("Quarterly Business Review");
            updated = true;
            break;
        }

        if (placeholderType == PlaceholderType.Picture) {
            IPPImage image;
            try (FileInputStream imageStream = new FileInputStream("replacement.png")) {
                image = presentation.getImages().addImage(imageStream);
            }

            if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                pictureFrame.getPictureFormat().getPicture().setImage(image);
            } else {
                slide.getShapes().addPictureFrame(ShapeType.Rectangle, shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), image);
                slide.getShapes().remove(shape);
            }

            updated = true;
            break;
        }
    }

    if (!updated) {
        throw new IllegalStateException("No supported title or picture placeholder was found on the first slide.");
    }

    presentation.save("placeholder-content-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **GYIK**

**Mi az alap placeholder?**

Az alap placeholder az elrendezésen vagy mesterdión található megfelelő alakzat, amelyből egy másik placeholder örököl. Használd az [IShape.getBasePlaceholder](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/) metódust a lekéréséhez. Egy helyi szokásos alakzat `null`‑t ad vissza, mert nem része a placeholder hierarchiának.

**Meg tudom változtatni az összes dia címét egy elrendezés placeholder szerkesztésével?**

Az örökölt formázást vagy a prompt szöveget egy elrendezésen keresztül módosíthatod, de a meglévő cím tartalom a normál diákon van tárolva. A tényleges cím szövegének cseréjéhez iterálj a diákon, és frissítsd minden cím placeholder‑t.

**Hogyan kezelem a dátum, dia‑szám, fejléc és lábléc placeholder‑eket?**

Használd a fejléc és lábléc kezelőket a megfelelő dián, elrendezésen, masteren, jegyzet vagy szórólap szintjén. Tekintsd meg a [Manage Presentation Header and Footer](/slides/hu/androidjava/presentation-header-and-footer/) cikket a teljes példákért.