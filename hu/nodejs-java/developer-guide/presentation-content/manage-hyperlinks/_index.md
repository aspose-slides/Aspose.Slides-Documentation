---
title: Prezentáció hiperhivatkozások kezelése JavaScriptben
linktitle: Hiperhivatkozások kezelése
type: docs
weight: 20
url: /hu/nodejs-java/manage-hyperlinks/
keywords:
- URL hozzáadása
- hiperhivatkozás hozzáadása
- hiperhivatkozás létrehozása
- hiperhivatkozás formázása
- hiperhivatkozás eltávolítása
- hiperhivatkozás frissítése
- szöveges hiperhivatkozás
- dia hiperhivatkozás
- alakzat hiperhivatkozás
- kép hiperhivatkozás
- videó hiperhivatkozás
- módosítható hiperhivatkozás
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Hiperhivatkozások hozzáadása, formázása, frissítése és eltávolítása PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Node.js via Java segítségével, JavaScript példákkal."
---
## **Bevezetés**

A hiperhivatkozás összeköti a prezentáció tartalmát egy weboldallal vagy a prezentáción belüli helyszínnel. A PowerPointban a hiperhivatkozások általában két célra szolgálnak:

* Weboldal megnyitása szövegből, alakzatból vagy média keretből.
* Navigálás egy másik dia felé, például a tartalomjegyzékből.

Az Aspose.Slides for Node.js via Java lehetővé teszi ezen hivatkozások hozzáadását, megjelenésük és hangzásuk vezérlését, tulajdonságaik frissítését, valamint eltávolítását. Az alábbi példák bemutatják, hogyan dolgozhatunk hiperhivatkozásokkal egyedi elemeknél, valamint hogyan érhetjük el a hiperhivatkozásokat a prezentáció, dia vagy szövegkeret szintjén.

{{% alert color="info" title="Note" %}}
Szerkeszthet prezentációkat is a [ingyenes online Aspose PowerPoint szerkesztő](https://products.aspose.app/slides/editor) segítségével.
{{% /alert %}}

## **URL hiperhivatkozások hozzáadása**

Webcím (URL) hozzárendelhető szöveghez, alakzathoz vagy média kerethez. Az a elem, amelyhez a hiperhivatkozást rendeljük, határozza meg a kattintható területet: egy szövegrész a kijelölt szöveget teszi kattinthatóvá, míg egy alakzat vagy keret a dia objektumát kapcsolja.

A relatív hiperhivatkozásokat tartalmazó prezentációk esetén tekintse meg a [Hiperhivatkozás-alap kezelése](/slides/hu/nodejs-java/presentation-properties/#manage-the-hyperlink-base) című oldalt a dokumentumszintű alap beolvasásához, módosításához vagy törléséhez.

### **URL hiperhivatkozások hozzáadása szöveghez**

A szöveg weboldalra való linkeléséhez adjon át egy [Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink) objektumot a szövegrész [setHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PortionFormat#setHyperlinkClick) metódusának, ahogy az alább látható. Csak ez a szövegrész lesz kattintható.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const textShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50, false);
    textShape.addTextFrame("Aspose: File Format APIs");
    const portionFormat = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");
    portionFormat.setFontHeight(32);

    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **URL hiperhivatkozások hozzáadása alakzatokhoz és média keretekhez**

Hívja meg a [setHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setHyperlinkClick) metódust a téglalapon, hogy annak teljes területe kattintható legyen. Használja a [setTooltip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTooltip) metódust a célhelyről szóló tipp megjelenítéséhez, amikor a felhasználó a téglalap fölé viszi az egérmutatót. Mindkét metódus alkalmazható képekre, hang- és videókeretekre is.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50);

    shape.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");

    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Hiperhivatkozások használata tartalomjegyzék létrehozásához**

Belső hiperhivatkozások lehetővé teszik, hogy az olvasó a tartalomjegyzékből egy adott diára ugorjon. Az alábbi példa a [setInternalHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#setInternalHyperlinkClick) metódust használja, hogy az első dia „2. oldal” szövegét a második diára linkelje.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    const tableOfContents = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 100);
    tableOfContents.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    tableOfContents.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    tableOfContents.getTextFrame().getParagraphs().clear();

    const paragraph = new aspose.slides.Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    paragraph.setText("Title of slide 2 .......... ");

    const linkPortion = new aspose.slides.Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

    paragraph.getPortions().add(linkPortion);
    tableOfContents.getTextFrame().getParagraphs().add(paragraph);

    presentation.save("link_to_slide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Hiperhivatkozások formázása**

Megváltoztathatja a linkelt szöveg színét, lejátszhat vagy leállíthat egy hangot, amikor a felhasználó aktiválja a hivatkozást, valamint beállíthatja a lebegőablak (tooltip) szövegét.

### **Szín**

A [Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink) [setColorSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setColorSource) metódusa határozza meg, hogy a hiperhivatkozás a prezentáció általános hiperhivatkozás‑színét vagy a szövegrész formázását használja‑e. Egyedi szövegszín alkalmazásához válassza a [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkColorSource) értéket, és állítsa be a rész kitöltőszínét. Ez a funkció a PowerPoint 2019‑ben került be, a régebbi verziók nem alkalmazzák ezt a beállítást.

Ebben a példában a [setColorSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setColorSource) az első hivatkozást a szövegrész piros kitöltésére állítja. A második hivatkozás a prezentáció hiperhivatkozás‑színét használja.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const coloredShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 450, 50, false);
    coloredShape.addTextFrame("This hyperlink uses a custom color.");
    const coloredPortionFormat = coloredShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    coloredPortionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    coloredPortionFormat.getHyperlinkClick().setColorSource(aspose.slides.HyperlinkColorSource.PortionFormat);
    coloredPortionFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    coloredPortionFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    const defaultShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 450, 50, false);
    defaultShape.addTextFrame("This hyperlink uses the default color.");
    defaultShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));

    presentation.save("presentation-out-hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Hang**

Egy hiperhivatkozás lejátszhat egy hangot aktiváláskor, vagy leállíthat egy már futó hangot. Az alábbi metódusokkal konfigurálhatja ezeket a viselkedéseket:

- [Hyperlink.setSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setSound) megadja a hiperhivatkozáshoz tartozó audio‑fájlt.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick) szabályozza, hogy a hiperhivatkozás aktiválásakor leálljon‑e az előző hang.

#### **Hiperhivatkozás hangjának hozzáadása**

Az első dián lévő gomb a [Hyperlink.setSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setSound) segítségével a `sampleaudio.wav` fájlt játssza le, amikor a felhasználó a továbbhaladáshoz kattint. A második dián egy másik gomb a [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick) metódussal állítja le a lejátszást, és a felhasználót a dia maradék részén tartja.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sampleaudio.wav");
    let hyperlinkSound;
    try {
        hyperlinkSound = presentation.getAudios().addAudio(audioStream);
    } finally {
        audioStream.close();
    }

    const firstSlide = presentation.getSlides().get_Item(0);

    const playButton = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.SoundButton, 100, 100, 100, 50);
    playButton.setHyperlinkClick(aspose.slides.Hyperlink.getNextSlide());

    if (!playButton.getHyperlinkClick().getStopSoundOnClick() && playButton.getHyperlinkClick().getSound() == null)
    {
        playButton.getHyperlinkClick().setSound(hyperlinkSound);
    }

    const secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    const stopButton = secondSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 100, 50);
    stopButton.setHyperlinkClick(aspose.slides.Hyperlink.getNoAction());

    stopButton.getHyperlinkClick().setStopSoundOnClick(true);

    presentation.save("hyperlink-sound.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

#### **Hiperhivatkozás hangjának kinyerése**

Az alábbi példa megnyitja a fent létrehozott prezentációt, és a [getSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getSound) és a [getBinaryData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Audio#getBinaryData) metódusokkal beolvassa az első alakzat hiperhivatkozás‑audio‑adatát a memóriába.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("hyperlink-sound.pptx");
try {
    if (presentation.getSlides().size() > 0 && presentation.getSlides().get_Item(0).getShapes().size() > 0) {
        const hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick();
        const sound = hyperlink == null ? null : hyperlink.getSound();
        if (sound != null) {
            const audioData = sound.getBinaryData();
            console.log("Extracted " + audioData.length + " bytes of hyperlink audio.");
        } else {
            console.log("The first shape has no hyperlink sound.");
        }
    } else {
        console.log("The presentation has no first slide or shape to inspect.");
    }
} finally {
    presentation.dispose();
}
```

### **Tooltip és interakciós beállítások**

A hiperhivatkozás szöveghez vagy alakzathoz való hozzárendelése után az alábbi [Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink) metódusok hívhatók:

- [setTooltip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTooltip) beállítja a megjelenő tippet a hivatkozásra mutató olvasó számára.
- [setTargetFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTargetFrame) megadja a célt keretet egy szülő HTML keretcsoporton belül, ha alkalmazható.
- [setHistory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setHistory) szabályozza, hogy a hivatkozás aktiválása felkerüljön‑e a megtekintett hiperhivatkozások listájára.
- [setHighlightClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setHighlightClick) szabályozza, hogy a hiperhivatkozás kattintáskor ki legyen‑e emelve.

## **Hiperhivatkozások eltávolítása a prezentációkból**

Használja a [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) metódust a hiperhivatkozás‑konténerek (beleértve a szövegrész‑linkeket is) összegyűjtéséhez, mielőtt módosítaná őket. Az alábbi példa mindkét aktiválási típust eltávolítja az első diáról. Ha csak egy típust szeretne eltávolítani, hívja csak a [removeHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) vagy a [removeHyperlinkMouseOver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver) metódust; egy kattintási művelet eltávolítása nem távolítja el az egér‑over megfelelőjét.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    if (presentation.getSlides().size() > 0) {
        const found = presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks();
        const containers = [];
        for (let index = 0; index < found.size(); index++) {
            containers.push(found.get_Item(index));
        }
        for (const container of containers) {
            container.getHyperlinkManager().removeHyperlinkClick();
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
        presentation.save("pres-removed-hyperlinks.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("The presentation has no slides to process.");
    }
} finally {
    presentation.dispose();
}
```

Feltétlen eltávolításhoz a [removeAllHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) eltávolítja mindkét aktiválási típust a kiválasztott környezetben egy hívásban. A mester‑, elrendezés‑ és jegyzet‑szintű szelektív tisztításhoz lásd a [Hiperhivatkozások jelentése, tisztítása és ellenőrzése](#report-sanitize-and-verify-hyperlinks) részt.

### **SmartArt szöveg eltávolítása előtt a hiperhivatkozások törlése**

Amikor egy meglévő SmartArt csomópontban lévő bekezdést cserél, a szövegrészek törlése régi hiperhivatkozást hagyhat működésben. A bekezdést a [SmartArtNode.getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#getTextFrame) metódussal érheti el. A részek törlése előtt hívja a [getHyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries) metódust a csomópont alakzatának szövegkeretén, majd a visszakapott objektumon a [removeAllHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) metódust. Ez eltávolít minden hiperhivatkozást az adott keretben, beleértve a többi bekezdésben szereplő linkeket is.

A példa feltételezi, hogy a `SmartArtHyperlink.pptx` első diájának harmadik alakzata egy SmartArt grafika, és a negyedik csomópont első bekezdését cseréli. Ebben a prezentációban a csomópont első alakzata jeleníti meg azt a bekezdést.

A két részlet hozzáadása után a példa a [getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PortionFormat#getEffective) metódussal olvassa ki a hatékony formázást. Ezen formázás alapján a `getHyperlinkClick` visszaadja az új hiperhivatkozást az első részhez, a másodikhoz pedig `null` értéket.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("SmartArtHyperlink.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const smartArt = slide.getShapes().get_Item(2);
    const node = smartArt.getAllNodes().get_Item(3);
    const paragraph = node.getTextFrame().getParagraphs().get_Item(0);

    node.getShapes().get_Item(0).getTextFrame().getHyperlinkQueries().removeAllHyperlinks();
    paragraph.getPortions().clear();

    const link = new aspose.slides.Portion("New reference");
    link.getPortionFormat().setHyperlinkClick(new aspose.slides.Hyperlink("https://example.com/new"));
    paragraph.getPortions().add(link);
    const text = new aspose.slides.Portion(" (updated)");
    paragraph.getPortions().add(text);

    console.log(link.getPortionFormat().getEffective().getHyperlinkClick().getExternalUrl()); // https://example.com/new
    console.log(text.getPortionFormat().getEffective().getHyperlinkClick()); // null
} finally {
    presentation.dispose();
}
```

## **Teljes hiperhivatkozás‑készlet felállítása**

A prezentáció terjesztése előtt készítsen leltárt az interaktív műveletekről és a webes linkekről. A [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) hiperhivatkozás‑konténereket ad vissza, nem pedig egy lapos URL‑lista. Ellenőrizze mind a [getHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkClick), mind a [getHyperlinkMouseOver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkMouseOver) metódusok eredményét minden konténeren. Ezek függetlenek: ugyanaz a konténer mindkét műveletet kifejtheti, így egy teljes jelentés akár két sort is igényelhet konténerenként.

Csak alakzat‑szintű hiperhivatkozások lekérdezése kimaradhat a szövegrész‑linkektől. Használja a megfelelő környezetet, és őrizze meg a visszakapott konténereket, hogy később frissíthesse vagy eltávolíthassa a műveleteket.

### **Prezentáció, dia és szövegkeret környezetek lekérdezése**

A [HyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries) osztály a következőkkel érhető el: [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getHyperlinkQueries), [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getHyperlinkQueries) és [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries). Minden környezet ugyanazokat a lekérdezéseket támogatja:

- [getHyperlinkClicks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkClicks) kattintásos konténereket ad vissza.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkMouseOvers) egér‑over konténereket ad vissza.
- [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) bármelyik vagy mindkét műveletet tartalmazó konténereket ad vissza.

Ez a példa kattintási és egér‑over műveleteket rendel egy alakzathoz és a szövegéhez, valamint egy makró‑műveletet egy külön gombhoz. Összehasonlítja a [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) által visszaadott konténerek számát az egyes aktiválási típusok számaival. A szövegkeret‑lekérdezés csak a szövegben lévő linkeket számolja. A körülvevő alakzat saját műveletei a dia‑ és prezentáció‑lekérdezésekben is megjelennek.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

function printQueryCounts(scope, queries) {
const clickCount = queries.getHyperlinkClicks().size();
const mouseOverCount = queries.getHyperlinkMouseOvers().size();
const anyCount = queries.getAnyHyperlinks().size();
console.log(scope + ": click=" + clickCount + ", mouse-over=" + mouseOverCount + ", any=" + anyCount);
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide());
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Click the text to go to slide 2");
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/");
    shape.getHyperlinkClick().setTooltip("Public website");
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    const portionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.getHyperlinkManager().setInternalHyperlinkClick(destination);
    portionFormat.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help");
    const macroButton = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 120, 200, 60);
    macroButton.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation");

    printQueryCounts("Presentation", presentation.getHyperlinkQueries());
    printQueryCounts("Slide 1", slide.getHyperlinkQueries());
    printQueryCounts("Text frame", shape.getTextFrame().getHyperlinkQueries());
    presentation.save("hyperlink-audit-input.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ebben a példában a prezentáció‑ és dia‑lekérdezések három kattintási, két egér‑over és három „bármelyik” konténert jelentenek. A szövegkeret‑lekérdezés egy konténert ad minden kategóriában.

### **Műveletek és célpontok osztályozása**

Használja a [Hyperlink.getActionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getActionType) metódust a művelet értelmezéséhez, mielőtt a célpontot vizsgálná. A [HyperlinkActionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkActionType) értékek többek között a következőket tartalmazzák:

| Értékek | Jelentés auditáláskor |
| --- | --- |
| `Hyperlink` | Külső hiperhivatkozás; ellenőrizze az URL‑t és a protokollt. |
| `JumpSpecificSlide` | Belső navigáció egy adott diára. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Beépített diavetítés‑navigáció, a diavetítés kontextusában értelmezve. |
| `JumpEndShow`, `StartCustomSlideShow` | A jelenlegi előadás befejezése vagy egy egyéni előadás indítása. |
| `StartMacro` | Makró futtatása. |
| `StartProgram` | Program indítása. |
| `OpenFile`, `OpenPresentation` | Fájl vagy másik prezentáció megnyitása; külön vizsgálja a web‑URL‑ektől. |
| `StartStopMedia` | Média lejátszás indítása vagy leállítása. |
| `NoAction`, `Unknown` | Nincs navigációs művelet, vagy nem felismert művelet, ami felülvizsgálatot igényel. |

Olvassa ki a külső célpontokat a [getExternalUrl](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrl) metódussal, a belső célpontokat a [getTargetSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getTargetSlide) segítségével. Belső és beépített parancsok esetén előfordulhat, hogy nincs külső URL; egy üres URL nem jelenti, hogy a konténernek nincs művelete. Tárolja a [getExternalUrlOriginal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrlOriginal) által visszaadott értéket, ha az eltér a normalizált URL‑től, és ha elérhető, vegye bele a [getTooltip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getTooltip) által visszaadott tooltip‑et is.

### **Hiperhivatkozások jelentése, tisztítása és ellenőrzése**

Ez a példa megnyitja az előző példában létrehozott prezentációt, és minden művelethez egy JSON‑rekordot ír. A [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) segítségével gyűjti a konténereket normál diák, mesterek, elrendezések és jegyzetek esetén, beleértve a jegyzet‑ és szórólap‑mestereket is, ha jelen vannak. Az egyenlő referenciát használja a konténerek egyedi számlálásához, alkalmazza az alább leírt szabályt, majd újra megnyitja a mentett prezentációt a kattintási és egér‑over műveletek ellenőrzéséhez.

A jelentés egy‑alapú dia‑indexet és a [getSlideId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getSlideId) értékét tartalmazza, ahol elérhető. A [getSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getSlide) biztosítja a tulajdonos diát a támogatott konténerekhez. Mesterek, elrendezések és jegyzetek nem rendelkeznek hagyományos dia‑indexszel, ezért a környezetük alapján azonosítják őket. Az alakzat‑konténereket és a szövegrész‑formázási konténereket külön címkézi; egyéb konténer‑típusok megtartják futás‑idejű típusnevüket. Minden konténer kap egy jelentés‑helyi azonosítót, hogy a két művelet összekapcsolható legyen. A jelentés a művelettípusokat a HyperlinkActionType felsorlat egész‑konstansaként tárolja.

Ez a tudatosan szigorú alkalmazási szabály csak abszolút HTTPS‑URL‑eket és érvényes belső dia‑célpontokat engedélyezi. Elutasítja a makrókat, programokat, fájl‑műveleteket, egyéb diavetítés‑műveleteket, ismeretlen műveleteket és az egyéb URL‑sémákat. Ezek az elutasítások szabályozási döntések, nem az Aspose.Slides biztonsági ítéletei. Az HTTPS önmagában nem garantálja a megbízhatóságot: adjon hozzá host‑engedélylistákat és egyéb ellenőrzéseket a saját alkalmazásához. Az eredeti és a normalizált külső URL‑eket egyaránt ellenőrzi. A példa a metaadatokat auditálja anélkül, hogy a linkeket követné vagy a műveleteket végrehajtaná.

Javításként a konténer [getHyperlinkManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkManager) támogatja a [setExternalHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#setExternalHyperlinkClick), a [removeHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) és a [removeHyperlinkMouseOver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver) metódusokat. Itt a tiltott külső kattintási linkek egy rögzített HTTPS‑céloldallal vannak helyettesítve; a többi tiltott kattintás és egér‑over művelet önállóan eltávolításra kerül. Állítsa a `replaceExternalClicks` értékét `false`‑ra, ha minden szabálysértést el szeretne távolítani. Válasszon egy alkalmazás‑tulajdonú helyettesítő oldalt a telepítés előtt.

A jelentés export‑jelzője konzervatív PDF‑ellenőrzési szabályt használ: jelölje meg az egér‑over műveleteket és minden olyan elemet, amely nem egy külső link vagy konkrét dia‑ugrás, potenciálisan nem támogatottként. Ez egy ellenőrzési tipp, nem egy képesség‑teszt vagy garancia arra, hogy a jelöletlen linkek exportáláskor megmaradnak. A támogatott [PDF](/slides/hu/nodejs-java/convert-powerpoint-to-pdf/) és [HTML](/slides/hu/nodejs-java/convert-powerpoint-to-html/) exportok megőrizhetik a hiperhivatkozásokat, a művelettől, az export‑beállításoktól és a megjelenítőtől függően. A raszter [képek](/slides/hu/nodejs-java/convert-powerpoint-to-png/) és [videók](/slides/hu/nodejs-java/convert-powerpoint-to-video/) nem tudják megőrizni az interaktív hiperhivatkozásokat; ezért ezeknél a kimeneteknél minden műveletet jelöljön meg auditáláskor.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

function slideIndex(presentation, slide) {
    if (slide == null) return null;
    for (let index = 0; index < presentation.getSlides().size(); index++) {
        if (presentation.getSlides().get_Item(index).equals(slide)) return index + 1;
    }
    return null;
}

function isHttps(value) {
    if (value == null || value.length === 0) return false;
    try {
        const uri = java.newInstanceSync("java.net.URI", value);
        const scheme = uri.getScheme();
        return uri.isAbsolute() && scheme != null && scheme.toLowerCase() === "https" && uri.getHost() != null;
    } catch (exception) {
        return false;
    }
}

function policyViolation(link) {
    if (link == null) return null;
    if (link.getActionType() === aspose.slides.HyperlinkActionType.JumpSpecificSlide) {
        return link.getTargetSlide() == null ? "Missing target slide" : null;
    }
    if (link.getActionType() !== aspose.slides.HyperlinkActionType.Hyperlink) return "Action is not allowed";
    if (!isHttps(link.getExternalUrl())) return "Normalized URL is not absolute HTTPS";
    const original = link.getExternalUrlOriginal();
    if (original != null && original.length > 0 && !isHttps(original)) return "Original URL is not absolute HTTPS";
    return null;
}

function collectContainers(presentation) {
    const found = [];
    function addQueries(queries) {
        const containers = queries.getAnyHyperlinks();
        for (let index = 0; index < containers.size(); index++) {
            found.push(containers.get_Item(index));
        }
    }
    function addScope(slide) {
        if (slide != null) addQueries(slide.getHyperlinkQueries());
    }
    addQueries(presentation.getHyperlinkQueries());
    for (let index = 0; index < presentation.getMasters().size(); index++) {
        addScope(presentation.getMasters().get_Item(index));
    }
    for (let index = 0; index < presentation.getLayoutSlides().size(); index++) {
        addScope(presentation.getLayoutSlides().get_Item(index));
    }
    for (let index = 0; index < presentation.getSlides().size(); index++) {
        addScope(presentation.getSlides().get_Item(index).getNotesSlideManager().getNotesSlide());
    }
    addScope(presentation.getMasterNotesSlideManager().getMasterNotesSlide());
    addScope(presentation.getMasterHandoutSlideManager().getMasterHandoutSlide());
    const seen = java.newInstanceSync("java.util.IdentityHashMap");
    const unique = [];
    for (const container of found) {
        if (!seen.containsKey(container)) {
            seen.put(container, true);
            unique.push(container);
        }
    }
    return unique;
}

function addRow(rows, presentation, link, activation, container, containerId) {
    if (link == null) return;
    const ownerSlide = java.instanceOf(container, "com.aspose.slides.ISlideComponent") ? container.getSlide() : null;
    const targetSlide = link.getTargetSlide();
    const violation = policyViolation(link);
    const ownerType = java.instanceOf(container, "com.aspose.slides.IShape") ? "Shape" : java.instanceOf(container, "com.aspose.slides.IPortionFormat") ? "Text portion" : container.getClass().getSimpleName();
    const ordinaryAction = link.getActionType() === aspose.slides.HyperlinkActionType.Hyperlink || link.getActionType() === aspose.slides.HyperlinkActionType.JumpSpecificSlide;
    rows.push({
        ContainerId: containerId,
        SlideIndex: slideIndex(presentation, ownerSlide),
        SlideId: ownerSlide == null ? null : ownerSlide.getSlideId(),
        Scope: ownerSlide == null ? null : ownerSlide.getClass().getSimpleName(),
        OwnerType: ownerType,
        Activation: activation,
        ActionType: link.getActionType(),
        ExternalUrl: link.getExternalUrl(),
        TargetSlideIndex: slideIndex(presentation, targetSlide),
        TargetSlideId: targetSlide == null ? null : targetSlide.getSlideId(),
        Tooltip: link.getTooltip(),
        OriginalExternalUrl: link.getExternalUrlOriginal() === link.getExternalUrl() ? null : link.getExternalUrlOriginal(),
        PotentiallyUnsafe: violation != null,
        PolicyViolation: violation,
        TargetExport: "PDF",
        PotentiallyUnsupportedByExport: activation === "mouse-over" || !ordinaryAction
    });
}

const replaceExternalClicks = true;
const replacementUrl = "https://example.com/blocked-link";
const presentation = new aspose.slides.Presentation("hyperlink-audit-input.pptx");
try {
    const containers = collectContainers(presentation);
    const rows = [];
    for (let index = 0; index < containers.length; index++) {
        const container = containers[index];
        addRow(rows, presentation, container.getHyperlinkClick(), "click", container, index + 1);
        addRow(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, index + 1);
    }
    const json = JSON.stringify(rows, null, 2);
    fs.writeFileSync("hyperlink-audit.json", json, "utf8");

    for (const container of containers) {
        const click = container.getHyperlinkClick();
        if (policyViolation(click) != null) {
            if (replaceExternalClicks && click.getActionType() === aspose.slides.HyperlinkActionType.Hyperlink) {
                container.getHyperlinkManager().setExternalHyperlinkClick(replacementUrl);
            } else {
                container.getHyperlinkManager().removeHyperlinkClick();
            }
        }
        if (policyViolation(container.getHyperlinkMouseOver()) != null) {
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
    }
    presentation.save("hyperlink-sanitized.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("hyperlink-sanitized.pptx");
    try {
        const remainingContainers = collectContainers(reopened);
        let violations = 0;
        for (const container of remainingContainers) {
            if (policyViolation(container.getHyperlinkClick()) != null) violations++;
            if (policyViolation(container.getHyperlinkMouseOver()) != null) violations++;
        }
        console.log("Audit rows: " + rows.length + "; prohibited actions after reopening: " + violations);
        if (violations !== 0) {
            console.log("Verification failed: do not distribute the saved presentation.");
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

A fenti bemenet alapján a jelentés öt műveleti sort tartalmaz. A fájl egér‑over link és a makró‑kattintás eltávolításra kerül, míg a HTTPS‑linkek és a belső dia‑navigáció megmarad. Az ellenőrzés nulla tiltott műveletet jelez. Egy tiltott külső kattintási URL‑t tartalmazó bemenet a helyettesítési ágat is teszteli. Egy engedélyezett kattintással és tiltott egér‑overrel rendelkező konténer megtartja a kattintási műveletet.

Ez a szelektív tisztítás különbözik a [removeAllHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) metódustól, amely a kiválasztott környezetben mindkét aktiválási típust eltávolítja a szabályoktól függetlenül. Az itt végzett ellenőrzés csak a hiperhivatkozás‑műveleteket vizsgálja; nem távolítja el a beágyazott VBA‑projekteket, OLE‑objektumokat vagy egyéb aktív tartalmakat, és nem ellenőrzi a PDF‑ vagy HTML‑exportált fájlokat.

## **GYIK**

**Hogyan linkelhetek egy szekcióra vagy annak első diájára?**

A PowerPointban a szekciók a diákat csoportosítják, de egy belső hiperhivatkozás egyetlen diát céloz. A szekcióhoz való navigáció létrehozásához linkelje az adott szekció első diáját.

**Hozzá tudok-e adni hiperhivatkozást a mesterdia elemeihez, hogy minden dián működjön?**

Igen. A mesterdia és elrendezés elemei támogatják a hiperhivatkozásokat. Ezek a linkek a diavetítés során elérhetők azon diákon, amelyek a megfelelő mestert vagy elrendezést használják.

**Megmaradnak a hiperhivatkozások PDF, HTML, képek vagy videó exportálásakor?**

A támogatott PDF és HTML exportok megőrizhetik a hiperhivatkozásokat; a raszter képek és videó nem képesek interaktív hivatkozásokat megőrizni. Lásd a [Hiperhivatkozások jelentése, tisztítása és ellenőrzése](#report-sanitize-and-verify-hyperlinks) alábbi export‑szempontokat.