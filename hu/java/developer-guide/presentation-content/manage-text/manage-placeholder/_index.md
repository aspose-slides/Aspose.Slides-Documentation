---
title: Prezentációs helykitöltők kezelése Java-ban
linktitle: Helykitöltők kezelése
type: docs
weight: 10
url: /hu/java/manage-placeholder/
keywords:
- helykitöltő
- szöveghelykitöltő
- képhelykitöltő
- diagramhelykitöltő
- tartalomhelykitöltő
- prompt szöveg
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Tanulja meg, hogyan vizsgálhatja és szerkesztheti a szöveg-, kép-, diagram- és tartalomhelykitöltőket, valamint hogyan értheti meg a helykitöltő öröklődést az Aspose.Slides for Java segítségével."
---
## **Áttekintés**

A helykitöltő egy alakzat, amely egy adott típusú tartalom számára fenntart helyet egy prezentációs sablonban. Gyakori példák a cím, a törzs, a kép, a diagram és az általános célú tartalomhelykitöltők. Egy egyszerű alakzattól eltérően a helykitöltő örökölheti a pozícióját, méretét, formázását és egyéb beállításait egy elrendezési vagy fődia (master) diáról.

Az Aspose.Slides a helykitöltő információkat a [IShape.getPlaceholder](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/) metóduson keresztül teszi elérhetővé. A metódus egy [IPlaceholder](https://reference.aspose.com/slides/hu/java/com.aspose.slides/placeholder/) objektumot ad vissza, vagy `null`‑t egy normál alakzatra. Használja az [IPlaceholder.getType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/placeholder/) metódust annak meghatározásához, hogy a helykitöltő milyen tartalomra van szánva.

Az alakzat interfész továbbra is fontos, miután ismeri a helykitöltő típusát:

- Egy üres szöveg-, kép-, diagram- vagy tartalomhelykitöltő általában egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) által van reprezentálva.
- Egy kitöltött képhelykitöltő reprezentálható egy [IPictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipictureframe/) segítségével.
- Egy kitöltött diagramhelykitöltő reprezentálható egy [IChart](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichart/) segítségével.
- Egy tartalomhelykitöltő többféle tartalmat is tartalmazhat. Ellenőrizze mind az [IPlaceholder.getType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/placeholder/) metódust, mind a futási időbeli alakzat interfészt, ahelyett, hogy azt feltételezné, hogy minden helykitöltő egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/placeholder/) leírja a helykitöltő szerepét; ez nem garantálja az alakzat futásidejű típusát. Mindig végezzen típusellenőrzést, mielőtt szöveghez, képhez, diagramhoz, táblához vagy média‑specifikus tagokhoz férne hozzá.
{{% /alert %}}

## **A helykitöltő öröklődés megértése**

A helykitöltők hierarchiát alkotnak:

1. A mesterdia (master slide) újrahasználható stílusokat határoz meg, és bizonyos esetekben mester szintű helykitöltőket is.
2. Az elrendezési dia (layout slide) meghatározza a elrendezést, amelyet egy vagy több normál dia használ, és örökölhet a mesterdától.
3. Egy normál dia tartalmazza a helykitöltőket az adott diára, és örökölhet az elrendezéséből.

Hívja meg az [IShape.getBasePlaceholder](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/) metódust, hogy egy szinttel feljebb lépjen ebben a hierarchiában. Egy diahelykitöltő általában visszaadja az elrendezési helykitöltőt; egy elrendezési helykitöltő visszaadhatja a mesterhelykitöltőt. A metódus `null`‑t ad vissza, ha az alakzatnak nincs bázishelykitöltője.

Az alábbi példa felsorolja az első diához tartozó helykitöltőket, és jelentést készít azok bázishelykitöltőiről:

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

Egy helykitöltő szerkesztése egy normál dián lokális felülírást hoz létre vagy módosít azon a dián. A kapcsolódó elrendezés vagy mester szerkesztése hatással lehet az összes olyan diára, amely még örökli ezt a beállítást. Egy lokális egyszerű alakzatnak nincs bázishelykitöltője, és nem kezd el örökölni csak azért, mert ugyanazokat a koordinátákat foglalja el.

## **Szöveg módosítása egy helykitöltőben**

A cím, középre igazított cím, alcím, törzs és szöveghelykitöltők általában támogatják a szöveget. Ellenőrizze, hogy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) van‑e jelen, mielőtt a [getTextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) metódust használná.

Ez a példa frissíti az első címhelykitöltőt az első dián, és elmenti az eredményt:

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

Ez a minta elkerüli a kép, diagram, tábla vagy média helykitöltők [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/)-ra való átkonvertálását. Emellett a helykitöltőt a célja alapján azonosítja, ahelyett, hogy egy törékeny alakzat indexre támaszkodna.

## **Útmutató szöveg beállítása egy elrendezésen**

Az útmutató szöveg egy üres helykitöltőben megjelenő tervezési időbeli utasítás, például *Kattintson a cím hozzáadásához*. Állítson be egyedi útmutató szöveget az elrendezési helykitöltőn, ahelyett, hogy egy normál dia alakzatelémén keresztül próbálná elérni. Az elrendezéshez az [ISlide.getLayoutSlide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islide/) segítségével férhet hozzá, majd iteráljon a [ILayoutSlide.getShapes](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibaseslide/) által visszaadott gyűjteményen.

Az alábbi példa megváltoztatja a cím és az alcím útmutató szövegét az első dián használt elrendezésen:

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

Az útmutató szöveg nem normál dia tartalom. Üres helykitöltőkre szánták szerkesztőalkalmazásokban, például a PowerPointban. Miután egy felhasználó vagy program valós tartalmat ad meg, az útmutató már nem jelenik meg. Az útmutató módosítása nem cseréli le a meglévő szöveget azokra a diákra, amelyek az elrendezést használják.

## **Képhelykitöltő frissítése**

Két esetet kell kezelni:

- Ha a képhelykitöltő már kitöltött és egy [IPictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipictureframe/) reprezentálja, cserélje le a képet az [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipicturefillformat/) és az [ISlidesPicture.setImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islidespicture/) segítségével.
- Ha még üres helykitöltő, adjon hozzá egy képkeretet a helykitöltő koordinátáihoz az [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishapecollection/) segítségével, majd távolítsa el az üres helykitöltőt.

A következő példa mindkét esetet támogatja, és elmenti a prezentációt:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

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

    Path imagePath = Paths.get("replacement.png");
    byte[] imageBytes = Files.readAllBytes(imagePath);
    IPPImage image = presentation.getImages().addImage(imageBytes);

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

Az üres helykitöltőhöz létrehozott csere egy lokális képkeret, nem új helykitöltő, mivel az [IShape.getPlaceholder](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/) nem biztosít beállítót. Megőrzi a fenntartott pozíciót, de már nem örököl helykitöltő‑specifikus viselkedést. Ha a helykitöltő kapcsolat megtartása létfontosságú, először PowerPointban készítse elő és töltse fel a helykitöltőt, majd frissítse a kapott [IPictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipictureframe/) objektumot az Aspose.Slides‑el.

Kép átlátszósága, vágása és egyéb képspecifikus hatások leírását lásd a [Manage Picture Frames](/slides/hu/java/picture-frame/) cikkben. Ezek a műveletek a képkerethez vagy a kép kitöltéséhez tartoznak, nem a helykitöltő metaadataihoz.

## **Diagram és tartalomhelykitöltők kezelése**

Egy kitöltött diagramhelykitöltő egy [IChart](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichart/) által reprezentálható. Ez a példa mind a helykitöltő típus, mind a futásidejű interfész alapján megtalálja az ilyen diagramot, megváltoztatja a címét, majd elmenti a fájlt:

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

Egy általános tartalomhelykitöltő általában a [PlaceholderType.Object](https://reference.aspose.com/slides/hu/java/com.aspose.slides/placeholdertype/) értékkel rendelkezik. A PowerPointban ez többféle tartalomtípus (diagramok, táblák, diagramok, képek, média) indítására szolgál. Kitöltés után vizsgálja meg a tényleges alakzat interfészt, hogy megtudja, mit tartalmaz. Speciális elrendezések szintén kiterjeszthetik a [PlaceholderType.Chart](https://reference.aspose.com/slides/hu/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/hu/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/hu/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/hu/java/com.aspose.slides/placeholdertype/), vagy [PlaceholderType.Diagram](https://reference.aspose.com/slides/hu/java/com.aspose.slides/placeholdertype/) típusokat.

Az Aspose.Slides nem konvertál egy üres [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) helykitöltőt [IChart](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichart/)-ra pusztán az [IPlaceholder.getType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/placeholder/) megváltoztatásával; a típust a felület nem engedi módosítani. Egy üres diagram vagy tartalomterület programozott feltöltéséhez adja hozzá a szükséges objektumot a helykitöltő koordinátáihoz, majd távolítsa el az üres helykitöltőt. A következő példa ezt végzi diagram esetén:

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

A hozzáadott diagram egy egyszerű lokális diagram. Elfoglalja a helykitöltő területét, de nem örököl az elrendezési helykitöltőből. Használja a dedikált [chart management articles](/slides/hu/java/powerpoint-charts/) anyagokat, ha kategóriákat, sorozatokat vagy munkafüzet‑adatokat kell cserélnie.

## **Teljes példa: Szöveg vagy kép tartalom frissítése**

Az alábbi end‑to‑end példa megnyit egy sablont, keres az első dián cím vagy kép helykitöltőt, ellenőrzi a helykitöltő és alakzat típusokat, frissíti a megfelelő tartalmat, majd elmenti a kimenetet. A példa szándékosan elkerüli a formaindex feltételezését vagy minden helykitöltő ugyanarra az interfészre való átkonvertálását.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

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
            Path imagePath = Paths.get("replacement.png");
            byte[] imageBytes = Files.readAllBytes(imagePath);
            IPPImage image = presentation.getImages().addImage(imageBytes);

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

**Mi a bázishelykitöltő?**

A bázishelykitöltő a megfelelő alakzat az elrendezésen vagy a mesteren, amelyből egy másik helykitöltő örököl. Használja az [IShape.getBasePlaceholder](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/) metódust a lekéréséhez. Egy egyszerű lokális alakzat `null`‑t ad vissza, mert nem része a helykitöltő hierarchiának.

**Módosíthatom az összes dia címét egy elrendezéshelykitöltő szerkesztésével?**

Az örökölt formázást vagy útmutató szöveget elrendezésen keresztül módosíthatja, de a meglévő cím tartalom a normál diákon van tárolva. A valós cím szöveg cseréjéhez egy prezentációban iteráljon a diákon, és frissítse minden címhelykitöltőt.

**Hogyan kezelem a dátum, dia‑szám, fejléc és lábléc helykitöltőket?**

Használja a fejléc‑ és láblécke‑kezelőket a megfelelő dia, elrendezés, mester, jegyzet vagy kiosztás szintjén. Lásd a [Manage Presentation Header and Footer](/slides/hu/java/presentation-header-and-footer/) cikket a teljes példákért.