---
title: Prezentáció helyőrzők kezelése Androidon
linktitle: Helyőrzők kezelése
type: docs
weight: 10
url: /hu/androidjava/manage-placeholder/
keywords:
- helyőrző
- szöveghelyőrző
- képhelyőrző
- diagramhelyőrző
- tartalomhelyőrző
- prompt szöveg
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan vizsgálja és szerkessze a szöveg-, kép-, diagram- és tartalomhelyőrzőket, valamint értsen meg a helyőrző öröklődést az Aspose.Slides for Android Java segítségével."
---
## **Áttekintés**

Az helyőrző egy alakzat, amely helyet tart fennt egy adott típusú tartalom számára egy prezentációs sablonban. Gyakori példák a cím, törzs, kép, diagram és általános célú tartalomhelyőrzők. Egy szokásos alakzattól eltérően a helyőrző örökölheti pozícióját, méretét, formázását és egyéb beállításait egy elrendezési diáról vagy mesterdiáról.

Az Aspose.Slides a helyőrző információkat a [IShape.getPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) metóduson keresztül teszi elérhetővé. A metódus egy [IPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) objektumot ad vissza, vagy `null`-t egy normál alakzat esetén. Használja a [IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) metódust annak meghatározásához, hogy milyen tartalomra szánták a helyőrzőt.

Az alakzati interfész továbbra is fontos, miután ismeri a helyőrző típusát:

- Egy üres szöveg, kép, diagram vagy tartalomhelyőrző általában egy [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) által van ábrázolva.
- Egy kitöltött képhelyőrző egy [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/) által ábrázolható.
- Egy kitöltött diagramhelyőrző egy [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/) által ábrázolható.
- Egy tartalomhelyőrző többféle tartalmat is tartalmazhat. Ellenőrizze mind az [IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) , mind a futásidejű alakzati interfészt, ahelyett, hogy feltételezné, hogy minden helyőrző egy [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) .

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) leírja a helyőrző szerepét; nem garantálja az alakzat futásidejű típusát. Mindig végezzen típusellenőrzést, mielőtt szöveggel, képpel, diagrammal, táblával vagy médiára vonatkozó tagokhoz férne hozzá.
{{% /alert %}}

## **A helyőrző öröklődés megértése**

A helyőrzők hierarchiát alkotnak:

1. A mesterdia meghatározza az újra felhasználható stílusokat, és bizonyos esetekben a mester szintű helyőrzőket.
2. Az elrendezési dia meghatározza az elrendezést, amelyet egy vagy több normál dia használ, és örökölhet a mestertől.
3. Egy normál dia tartalmazza az adott dia helyőrzőit, és örökölhet az elrendezéséből.

Hívja meg a [IShape.getBasePlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) metódust, hogy egy szinttel feljebb lépjen ebben a hierarchiában. Egy diahelyőrző általában visszaadja az elrendezési helyőrzőjét; egy elrendezési helyőrző visszaadhatja a mesterhelyőrzőjét. A metódus `null`-t ad vissza, ha az alakzatnak nincs alaphelyőrzője.

A következő példa felsorolja az első dián lévő helyőrzőket és jelentést készít azok alaphelyőrzőiről:
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

Egy helyőrző szerkesztése egy normál dián helyi felülírást hoz létre vagy módosít az adott dián. A kapcsolódó elrendezés vagy mester szerkesztése hatással lehet minden olyan diára, amely még örökli ezt a beállítást. Egy helyi szokásos alakzatnak nincs alaphelyőrzője, és nem kezd öröklődni csak azért, mert ugyanazokat a koordinátákat foglalja el.

## **Helyőrző állapotának eltávolítása**

Sablon módosításakor használja a [IShape.removePlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#removePlaceholder--) metódust, hogy egy meglévő objektumot szokásos alakzatként tartson meg. Az [getPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getPlaceholder--) metódusa `null`-t ad vissza, de az alakzat a dia gyűjteményében marad. Ezzel szemben a [IShapeCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) törli az alakzatot a gyűjteményből.

A következő példához szükség van egy `template.pptx` fájlra, amely legalább egy diával és egy nem üres szöveghelyőrzővel rendelkezik az első dián. Használjon egy olyan helyőrzőt, amelynek formázása az elrendezésből vagy a mestertől öröklődik, hogy lássa a kapcsolat eltávolításának hatását. A példa ellenőrzi, hogy ugyanaz az alakzat megmarad, újra meghívja a metódust a most már szokásos alakzaton, és elmenti az eredményt.

{{% alert color="warning" title="Warning" %}}
A helyőrző állapotának eltávolítása nem őrzi meg automatikusan az örökölt megjelenési beállításokat. Az alábbi példa szándékosan változatlanul hagyja ezeket a beállításokat, ezért a kimenet másként nézhet ki. Egy olyan alakzat, amelynek pozíciója és mérete teljesen öröklődik, a hívás után nulla koordinátákkal és méretekkel rendelkezhet, és láthatatlanná válhat, még ha a gyűjteményben marad is.
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

        // A metódus hívása egy szokásos alakzatra nincs hatással.
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

Egy egyező helyőrző esetén mindhárom ellenőrzés `true` értéket ad. A szöveg megmarad, de az örökölt pozíció, méret, forgatás, betűtípus, bekezdésigazítás, szövegkeret margók, vertikális rögzítés, kitöltés és vonal beállítások megváltozhatnak, amikor a helyőrző kapcsolatot eltávolítják. Például az örökölt címsor formázása visszatérhet a szokásos szövegformázáshoz. További információért az elrendezésekről lásd a [Slide Layout](/slides/hu/androidjava/slide-layout/) oldalt.

Az eredeti megjelenés megőrzéséhez rögzítse a feloldott pozíciót, méretet és forgatást a hívás előtt, és másolja a szükséges tényleges formázási értékeket külön változókba. Szerezze be ezeket az értékeket a [IPortionFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/#getEffective--), [IParagraphFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getEffective--), [ITextFrameFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getEffective--), [IFillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getEffective--), és [ILineFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getEffective--) metódusokon keresztül. Ne támaszkodjon kizárólag a tényleges formátum objektumok megtartására, mivel a szövegformázási értékeik megváltozhatnak a kapcsolat eltávolítása után. Alkalmazza kifeexplicit módon a rögzített értékeket a szokásos alakzatra később, beleértve a betűcsaládot, méretet, stílust, színt, bekezdésbeállításokat, szövegkeret beállításokat, kitöltést és vonalat, amelyet a sablonja használ.

Az örökölt alakzatgeometria is explicit módon hozzárendelhető a [IGeometryShape.setShapeType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setShapeType-int-) metóduson keresztül. Egy téglalap alakú szöveghelyőrző esetén ez azt jelenti, hogy a [ShapeType.Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapetype/#Rectangle) értéket kell beállítani; csak a kitöltés és a vonal visszaállítása nem biztos, hogy helyreállítja a látható téglalapot. A további hatásokat vagy összetettebb formázást tartalmazó sablonok esetén ezeket a beállításokat is kezelni kell.

## **Szöveg módosítása egy helyőrzőben**

A cím, középre igazított cím, al-cím, törzs és szöveghelyőrzők általában támogatják a szöveget. Ellenőrizze, hogy [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) van-e jelen, mielőtt a [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) metódusát használja.

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

Ez a minta elkerüli a kép, diagram, táblázat vagy média helyőrzők [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) típusra való átkonvertálását. Emellett a helyőrzőt a célja alapján azonosítja, ahelyett, hogy egy törékeny alakzatindexre támaszkodna.

## **Prompt szöveg beállítása egy elrendezésen**

A prompt szöveg a tervezési időben megjelenő utasítás egy üres helyőrzőben, például *Kattintson a cím hozzáadásához*. Állítson be egyéni prompt szöveget az elrendezés helyőrzőjén, ahelyett, hogy a normál dia alakzategyűjteményén keresztül próbálna elérni. Az elrendezést a [ISlide.getLayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/) metódussal érheti el, és iteráljon a [ILayoutSlide.getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/) által visszaadott gyűjteményen.

A következő példa megváltoztatja a cím és al-cím promptjait az első dián használt elrendezésen:
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

A prompt szöveg nem normál dia tartalom. Üres helyőrzők számára van szánva szerkesztő alkalmazásokban, mint a PowerPoint. Amint egy felhasználó vagy program valós tartalmat ad meg, a prompt már nem jelenik meg. A prompt megváltoztatása nem helyettesíti a már létező szöveget az elrendezést használó diákon.

## **Képhelyőrző frissítése**

Két esetet kell kezelni:

- Ha a képhelyőrző már ki van töltve és egy [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/) által van ábrázolva, cserélje ki a képet a [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) és a [ISlidesPicture.setImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/) segítségével.
- Ha még mindig egy üres helyőrző, adjon hozzá egy képkeretet a helyőrző koordinátáiban a [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/) segítségével, és távolítsa el az üres helyőrzőt.

A következő példa támogatja mindkét esetet, és elmenti a prezentációt:
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

Az üres helyőrzőhöz létrehozott helyettesítés egy helyi képkeret, nem új helyőrző, mivel a [IShape.getPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) nem biztosít beállítót. Megőrzi a lefoglalt pozíciót, de már nem örökli a helyőrző-specifikus viselkedést. Ha a helyőrző kapcsolat megtartása lényeges, először készítse el és töltse fel a helyőrzőt a PowerPointban, majd frissítse a keletkezett [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/) objektumot az Aspose.Slides segítségével.

A kép átlátszóságával, vágásával és egyéb kép-specifikus effektusokkal kapcsolatban lásd a [Manage Picture Frames](/slides/hu/androidjava/picture-frame/) oldalt. Ezek a műveletek a képkerethez vagy a kép kitöltéséhez tartoznak, nem a helyőrző metaadataihoz.

## **Diagram és tartalomhelyőrzőkkel való munka**

Egy kitöltött diagramhelyőrző egy [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/) segítségével ábrázolható. Ez a példa megtalálja az ilyen diagramot a helyőrző típusa és a futásidejű interfésze alapján, megváltoztatja a címét, és elmenti a fájlt:
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

Egy általános tartalomhelyőrző általában a [PlaceholderType.Object](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/) típussal rendelkezik. A PowerPointban ez többféle tartalomtípus indítójaként működik, többek között diagramok, táblázatok, diagramok, képek és média. Miután fel van töltve, ellenőrizze a tényleges alakzati interfészt, hogy megtudja, mit tartalmaz. Specializált elrendezések is kitethetik a [PlaceholderType.Chart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/), vagy [PlaceholderType.Diagram](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/) típusokat.

Aspose.Slides nem alakítja át egy üres [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) helyőrzőt egy [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/) helyőrzővé csak az [IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) módosításával; a típust nem lehet megváltoztatni az interfészen keresztül. Egy üres diagram vagy tartalmi terület programozott feltöltéséhez adja hozzá a szükséges objektumot a helyőrző koordinátáihoz, majd távolítsa el az üres helyőrzőt. A következő példa ezt egy diagramra alkalmazza:
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

A hozzáadott diagram egy szokásos helyi diagram. Elfoglalja a helyőrző területét, de nem örököl az elrendezési helyőrzőből. Használja a dedikált [chart management articles](/slides/hu/androidjava/powerpoint-charts/) cikkeket, amikor cserélni kell a kategóriákat, sorozatokat vagy a munkafüzet adatokat.

## **Teljes példa: Szöveg vagy kép tartalom frissítése**

Az alábbi végponttól végpontig tartó példa megnyit egy sablont, keres az első dián egy cím vagy kép helyőrzőt, ellenőrzi a helyőrző és az alakzat típusát, frissíti a megfelelő tartalmat, és elmenti a kimenetet. A példa szándékosan kerüli a formaindex feltételezését vagy minden helyőrző ugyanarra az interfészre való átkonvertálását.
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

**Mi a bázis helyőrző?**

A bázis helyőrző az elrendezésen vagy a mesteren lévő megfelelő alakzat, amelyből egy másik helyőrző örököl. Használja a [IShape.getBasePlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) metódust a lekéréséhez. Egy szokásos helyi alakzat `null`-t ad vissza, mivel nem része a helyőrző hierarchiának.

**Módosíthatom-e az összes dia címét egy elrendezés helyőrzőjének szerkesztésével?**

Az elrendezésen keresztül módosíthatja az örökölt formázást vagy a prompt szöveget, de a meglévő cím tartalom a normál diákon van tárolva. A tényleges cím szövegének cseréjéhez egy prezentációban, iteráljon a diákon és frissítse minden címhelyőrzőt.

**Hogyan kezelem a dátum, dia-szám, fejléc és lábléc helyőrzőket?**

Használja a fejléc és lábléc kezelőket a megfelelő dia, elrendezés, mester, jegyzet vagy beszámoló tartományban. Lásd a [Manage Presentation Header and Footer](/slides/hu/androidjava/presentation-header-and-footer/) oldalt a teljes példákért.