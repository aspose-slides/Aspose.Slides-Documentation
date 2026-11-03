---
title: Prezentáció helyőrzők kezelése Java-ban
linktitle: Helyőrzők kezelése
type: docs
weight: 10
url: /hu/java/manage-placeholder/
keywords:
- helyőrző
- szöveghelyőrző
- képhelyőrző
- diagramhelyőrző
- tartalomhelyőrző
- utasító szöveg
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan vizsgálhatja és szerkesztheti a szöveg-, kép-, diagram- és tartalomhelyőrzőket, valamint értheti meg a helyőrző öröklődést az Aspose.Slides for Java segítségével."
---
## **Áttekintés**

A helyőrző egy alakzat, amely helyet tart fenn egy adott típusú tartalom számára egy prezentációs sablonban. Gyakori példák a cím, törzs, kép, diagram és általános célú tartalomhelyőrzők. Egy szokásos alakzattól eltérően a helyőrző örökölheti pozícióját, méretét, formázását és egyéb beállításait egy elrendezési diától vagy mester diától.

Az Aspose.Slides a helyőrző információkat a [IShape.getPlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) metóduson keresztül teszi elérhetővé. A metódus egy [IPlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/) objektumot ad vissza, vagy `null`‑t egy normál alakzatra. Használja az [IPlaceholder.getType](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/) metódust annak meghatározására, hogy a helyőrző milyen típusú tartalmat vár.

Az alakzat‑interfész továbbra is fontos, miután ismeri a helyőrző típusát:

- Egy üres szöveg‑, kép‑, diagram‑ vagy tartalomhelyőrző általában egy [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) segítségével jelenik meg.
- Egy kitöltött képhelyőrző reprezentálható egy [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/) által.
- Egy kitöltött diagramhelyőrző reprezentálható egy [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/) által.
- Egy tartalomhelyőrző többféle tartalmat is tartalmazhat. Ellenőrizze mind az [IPlaceholder.getType](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/), mind a futás‑idő alakzat‑interfészt, ahelyett, hogy feltételezné, hogy minden helyőrző egy [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/) leírja a helyőrző szerepét; nem garantálja az alakzat futás‑idő típusát. Mindig végezzen típusellenőrzést, mielőtt szöveget, képet, diagramot, táblázatot vagy média‑specifikus tagot érne el.
{{% /alert %}}

## **A helyőrző öröklődésének megértése**

A helyőrzők hierarchiát alkotnak:

1. Egy mesterdia definiál újrahasználható stílusokat és bizonyos esetekben mester‑szintű helyőrzőket.
2. Egy elrendezési dia határozza meg az elrendezést, amelyet egy vagy több normál dia használ, és örökölhet a mestertől.
3. Egy normál dia tartalmazza a saját helyőrzőit, és örökölhet az elrendezésétől.

Hívja meg az [IShape.getBasePlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) metódust a hierarchiában egy szinttel feljebb lépéshez. Egy diahelyőrző általában visszaadja az elrendezési helyőrzőt; egy elrendezési helyőrző visszaadhatja a mester helyőrzőt. A metódus `null`‑t ad vissza, ha az alakzatnak nincs alap‑helyőrzője.

Az alábbi példa felsorolja az első dián található helyőrzőket, és megjeleníti azok alap‑helyőrzőit:

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

Egy helyőrző szerkesztése egy normál dián helyi felülírást hoz létre vagy módosít ahhoz a diához. A kapcsolódó elrendezés vagy mester szerkesztése minden olyan diára hat, amely még örökli ezt a beállítást. Egy helyi szokásos alakzatnak nincs alap‑helyőrzője, és nem kezd el örökölni csak azért, mert ugyanazokat a koordinátákat foglalja el.

## **Helyőrző állapot eltávolítása**

Sablon módosításakor használja az [IShape.removePlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#removePlaceholder--) metódust, hogy a meglévő objektumot egyszerű alakzattá konvertálja. A [getPlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getPlaceholder--) metódusa `null`‑t ad vissza, de az alakzat a dia gyűjteményében marad. Ezzel szemben az [IShapeCollection.remove](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) eltávolítja az alakzatot a gyűjteményből.

Az alábbi példa egy `template.pptx` fájlt igényel, amely legalább egy diát és egy nem üres szöveg‑helyőrzőt tartalmaz az első dián. Használjon egy olyan helyőrzőt, amelynek formázása öröklődik az elrendezésből vagy a mestertől, hogy lássa a kapcsolat eltávolításának hatását. A példa ellenőrzi, hogy ugyanaz az alakzat megmarad‑e, újból meghívja a metódust a most már szokásos alakzaton, és elmenti az eredményt.

{{% alert color="warning" title="Warning" %}}
A helyőrző állapot eltávolítása nem őrzi meg automatikusan az örökölt megjelenési beállításokat. Az alábbi példa szándékosan változatlanul hagyja ezeket a beállításokat, ezért a kimenet másként nézhet ki. Egy olyan alakzat, amelynek pozíciója és mérete teljesen öröklődött, a hívás után nulla koordinátákat és méreteket kaphat, és láthatatlanná válhat, bár továbbra is a gyűjteményben marad.
{{% /alert %}}

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    boolean found = false;

    for (int index = 0; index < slide.getShapes().size(); index++) {
        IShape candidate = slide.getShapes().get_Item(index);
        if (!(candidate instanceof IAutoShape)) {
            continue;
        }

        IAutoShape shape = (IAutoShape) candidate;
        ITextFrame textFrame = shape.getTextFrame();
        if (shape.getPlaceholder() == null || 
            textFrame == null || 
            textFrame.getText() == null || 
            textFrame.getText().isEmpty()) {
            continue;
        }

        int shapeCount = slide.getShapes().size();
        shape.removePlaceholder();

        System.out.println("Placeholder removed: " + (shape.getPlaceholder() == null));
        System.out.println("Same shape retained: " + (slide.getShapes().get_Item(index) == shape));
        System.out.println("Shape count unchanged: " + (slide.getShapes().size() == shapeCount));

        // A metódus hívása egy szokásos alakzatra nem jár semmilyen hatással.
        shape.removePlaceholder();
        found = true;
        break;
    }

    if (found) {
        presentation.save("placeholder-status-removed.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("No nonempty text placeholder was found on the first slide.");
    }
} finally {
    presentation.dispose();
}
```

Egy megfelelő helyőrző esetén mindhárom ellenőrzés `true`‑t ad ki. A szöveg megmarad, de az örökölt pozíció, méret, forgatás, betűtípus, bekezdés‑igazítás, szövegkeret‑margók, függőleges rögzítés, kitöltés és vonal beállítások változhatnak, amikor a helyőrző kapcsolatot eltávolítják. Például az örökölt címformázás visszatérhet a szokásos szövegformázáshoz. További információért tekintse meg a [Slide Layout](/slides/hu/java/slide-layout/) oldalt.

A kívánt megjelenés megőrzéséhez a hívás előtt rögzítse a feloldott pozíciót, méretet és forgatást, és másolja a szükséges hatékony formázási értékeket külön változókba. Szerezze be ezeket az értékeket az [IPortionFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/#getEffective--) , [IParagraphFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getEffective--) , [ITextFrameFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getEffective--) , [IFillFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getEffective--) és [ILineFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getEffective--) metódusokkal. Ne csak a hatékony‑formátum objektumokra támaszkodjon, mivel azok szöveg‑formázási értékei a kapcsolat eltávolítása után megváltozhatnak. Alkalmazza a rögzített értékeket a szokásos alakzatra a betűcsalád, méret, stílus, szín, bekezdés‑beállítások, szövegkeret‑beállítások, kitöltés és vonal explicit alkalmazásával.

Az örökölt alakzat‑geometria is lehet, hogy explicit módon kell, hogy hozzárendelje az [IGeometryShape.setShapeType](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setShapeType-int-) segítségével. Egy négyzetes szöveg‑helyőrző esetén ez a [ShapeType.Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/shapetype/#Rectangle) hozzárendelését jelenti; csak a kitöltés és vonal visszaállítása nem biztos, hogy helyreállítja a látható négyszöget. További hatásokkal vagy összetettebb formázással rendelkező sablonok esetén ezeket a beállításokat is kezelni kell.

## **Szöveg módosítása egy helyőrzőben**

A cím, középre igazított cím, alcím, törzs és szöveg‑helyőrzők általában támogatják a szöveget. Ellenőrizze, hogy az alakzat egy [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/), mielőtt a [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) metódust hívná.

Ez a példa frissíti az első címhelyőrzőt az első dián, és elmenti az eredményt:

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

Ez a minta elkerüli a kép, diagram, táblázat vagy média‑helyőrzők [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) típusra való castelését. Emellett a helyőrzőt a célja szerint azonosítja, a törékeny alakzat‑indexre való támaszkodás helyett.

## **Prompt szöveg beállítása egy elrendezésen**

A prompt szöveg egy tervezési időben megjelenő utasítás, amely egy üres helyőrzőben látható, például *Click to add title*. Állítson be egyedi prompt szöveget az elrendezési helyőrzőn, ahelyett, hogy a normál dia alakzatgyűjteményén keresztül próbálna elérni. Az elrendezést az [ISlide.getLayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/) metódussal érheti el, és iteráljon a [ILayoutSlide.getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/) által visszaadott gyűjteményen.

Az alábbi példa módosítja a cím‑ és alcím‑promptokat az első dián használt elrendezésen:

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

A prompt szöveg nem normál dia‑tartalom. Üres helyőrzők szerkesztői alkalmazásokban (például PowerPoint) való használatra szánt. Amint a felhasználó vagy egy program valódi tartalmat ad meg, a prompt már nem jelenik meg. A prompt megváltoztatása nem felülírja a már létező szöveget azokra a diákra, amelyek az elrendezést használják.

## **Képhelyőrző frissítése**

Két esetet kell kezelni:

- Ha a képhelyőrző már ki van töltve, és egy [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/) reprezentálja, cserélje ki a képet az [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) és az [ISlidesPicture.setImage](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/) segítségével.
- Ha még egy üres helyőrző, adjon hozzá egy képkeretet a helyőrző koordinátáihoz az [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/) segítségével, és távolítsa el az üres helyőrzőt.

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

Az üres helyőrzőhöz létrehozott csere egy helyi képkeret, nem egy új helyőrző, mivel az [IShape.getPlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) nem biztosít beállítót. Megtartja a fenntartott pozíciót, de már nem örököl helyőrző‑specifikus viselkedést. Ha a helyőrző kapcsolat megőrzése létfontosságú, először készítse elő és töltse fel a helyőrzőt PowerPoint‑ban, majd frissítse a keletkezett [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/) objektumot az Aspose.Slides‑kel.

A kép átlátszósága, körülvágása és egyéb kép‑specifikus hatások tekintetében lásd a [Manage Picture Frames](/slides/hu/java/picture-frame/) cikket. Ezek a műveletek a képkeretre vagy a képtöltésre vonatkoznak, nem a helyőrző metaadatokra.

## **Diagram‑ és tartalomhelyőrzők kezelése**

Egy kitöltött diagramhelyőrző egy [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/) segítségével jeleníthető meg. Ez a példa a diagramot a helyőrző típusa és a futás‑idő interfész alapján találja meg, módosítja a címét, és elmenti a fájlt:

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

Egy általános tartalomhelyőrző általában a [PlaceholderType.Object](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/) típusú. PowerPointban ez több tartalomtípus indítását teszi lehetővé, beleértve diagramokat, táblázatokat, diagramokat, képeket és médiát. Miután kitöltötték, vizsgálja meg a tényleges alakzat‑interfészt, hogy megtudja, mit tartalmaz. Speciális elrendezések is kiterjeszthetik a [PlaceholderType.Chart](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/), vagy [PlaceholderType.Diagram](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/) típusokra.

Az Aspose.Slides nem konvertál egy üres [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) helyőrzőt [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/) objektummá csak az [IPlaceholder.getType](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/) módosításával; a típust az interfészen keresztül nem lehet megváltoztatni. Egy üres diagram vagy tartalomterület programozott kitöltéséhez adja hozzá a szükséges objektumot a helyőrző koordinátáihoz, majd távolítsa el az üres helyőrzőt. A következő példa ezt végzi egy diagram esetén:

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

A hozzáadott diagram egy szokásos helyi diagram. Elfoglalja a helyőrző területét, de nem örököl az elrendezési helyőrzőtől. Használja a dedikált [chart management articles](/slides/hu/java/powerpoint-charts/) oldalt, ha cserélni kell a kategóriákat, sorozatokat vagy munkafüzet‑adatokat.

## **Teljes példa: Szöveg vagy kép tartalom frissítése**

Az alábbi vég‑végi példa megnyit egy sablont, az első dián keres egy cím‑ vagy képhelyőrzőt, ellenőrzi a helyőrző és alakzat típusát, frissíti a megfelelő tartalmat, és elmenti a kimenetet. A példa szándékosan kerüli el a formaindex vagy minden helyőrző ugyanazon interfészre való castelésének feltételezését.

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

**Mi az a base placeholder?**

A base placeholder az elrendezésen vagy a mesteron lévő megfelelő alakzat, amelyről egy másik helyőrző örököl. Használja az [IShape.getBasePlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) metódust a lekéréséhez. Egy szokásos helyi alakzat `null`‑t ad vissza, mert nem része a helyőrző‑hierarchiának.

**Módosíthatom az összes dia címét egy elrendezés‑helyőrző szerkesztésével?**

Az örökölt formázást vagy prompt szöveget módosíthatja egy elrendezésen, de a meglévő cím tartalom a normál diákon tárolódik. A tényleges cím szöveg cseréjéhez egy prezentációban iteráljon a diákon, és frissítse minden cím‑helyőrzőt.

**Hogyan kezelem a dátum, dia‑szám, fejléc és lábléc helyőrzőket?**

Használja a fej‑ és lábléc kezelőket az adott dia, elrendezés, mester, jegyzet vagy segédlet szintjén. Lásd a [Manage Presentation Header and Footer](/slides/hu/java/presentation-header-and-footer/) oldalt a teljes példákért.