---
title: Prezentációs hiperhivatkozások kezelése JavaScriptben
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
- alakzati hiperhivatkozás
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

A hiperhivatkozás a prezentáció tartalmát összekapcsolja egy weboldallal vagy a prezentáción belüli helyszínnel. A PowerPointban a hiperhivatkozások általában két célt szolgálnak:

* Weboldal megnyitása szövegből, alakzatból vagy média keretből.
* Navigálás egy másik diára, például egy tartalomjegyzékből.

Az Aspose.Slides for Node.js via Java lehetővé teszi ezen hivatkozások hozzáadását, megjelenésük és hangjuk vezérlését, tulajdonságaik frissítését és eltávolításukat. Az alábbi példák bemutatják, hogyan dolgozhatunk hiperhivatkozásokkal egyedi elemeken, valamint hogyan érhetjük el a hiperhivatkozásokat a prezentáció, dia vagy szövegkeret szintjén.

{{% alert color="info" title="Note" %}}

A prezentációkat a [free online Aspose PowerPoint editor](https://products.aspose.app/slides/hu/editor) segítségével is szerkesztheti.

{{% /alert %}} 

## **URL hiperhivatkozások hozzáadása**

Weboldal URL-t rendelhet szöveghez, alakzathoz vagy média kerethez. Az a elem, amelyhez a hiperhivatkozást rendeli, meghatározza a kattintható területet: egy szövegrész a kijelölt szöveghez kapcsolódik, míg egy alakzat vagy keret a dia objektumához.

### **URL hiperhivatkozások hozzáadása szöveghez**

A szöveg weboldalra való hivatkozásához adjon át egy [Hyperlink](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Hyperlink) objektumot a szövegrész [setHyperlinkClick](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/PortionFormat#setHyperlinkClick) metódusának, ahogy az alább látható. Csak ez a szövegrész válik kattinthatóvá.

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

Ahhoz, hogy egy alakzat vagy keret kattintható legyen, hívja meg a [setHyperlinkClick](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Shape#setHyperlinkClick) metódusát. A hiperhivatkozás az objektumhoz tartozik, nem a benne lévő szövegrészhez.

Ugyanez a megközelítés alkalmazható kép-, hang- és videó keretekre: a hiperhivatkozást a kerethez rendeli, és szükség esetén meghívja a [setTooltip](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Hyperlink#setTooltip) metódust.

Az alábbi példa egy téglalapot tesz kattinthatóvá:

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

## **Hiperhivatkozások használata Tartalomjegyzék létrehozásához**

Belső hiperhivatkozások lehetővé teszik az olvasók számára, hogy a tartalomjegyzékből egy adott diára ugorjanak. Az alábbi példa a [setInternalHyperlinkClick](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/HyperlinkManager#setInternalHyperlinkClick) metódust használja, hogy az első dia „2. oldal” szövegét a második diára linkelje.

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

### **Szín**

A [Hyperlink](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Hyperlink) [setColorSource](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Hyperlink#setColorSource) metódusa határozza meg, hogy a hiperhivatkozás a prezentáció hiperhivatkozás-színét vagy a szövegrész formázását használja-e. Egy egyedi szövegszín alkalmazásához válassza a [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/HyperlinkColorSource) értéket, és állítsa be a rész kitöltőszínét. Ez a funkció a PowerPoint 2019-ben került bevezetésre; a régebbi verziók nem alkalmazzák ezt a beállítást.

Az alábbi példa két szöveges hiperhivatkozást ad ugyanarra a diára. Az első piros szövegkitöltést használ, míg a második az alapértelmezett hiperhivatkozás-színt tartja meg.

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

Egy hiperhivatkozás lejátszhat egy hangot aktiváláskor, vagy leállíthat egy már játszó hangot. A következő metódusokkal konfigurálhatja ezeket a viselkedéseket:

- [Hyperlink.setSound](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Hyperlink#setSound) határozza meg a hiperhivatkozáshoz társított hangot.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick) szabályozza, hogy a hiperhivatkozás aktiválása leállítsa-e az előző hangot.

#### **Hiperhivatkozás hangjának hozzáadása**

Az alábbi példa betölti a `sampleaudio.wav` fájlt, és egy gombhoz rendeli az első dián. A gomb kattintásakor a hang lejátszódik és a következő diára navigál. Egy másik alakzat ugyanazon a dián leállítja a korábbi hangot kattintáskor, anélkül, hogy navigációt végezne.

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

Az alábbi példa megnyitja a fent létrehozott prezentációt, és a [getSound](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Hyperlink#getSound) és [getBinaryData](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Audio#getBinaryData) metódusok segítségével beolvassa az első alakzat hiperhivatkozás‑átlag hangot a memóriába.

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

A hiperhivatkozás szöveghez vagy alakzathoz való hozzárendelése után meghívhatja a következő [Hyperlink](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Hyperlink) metódusokat:

- [setTooltip](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Hyperlink#setTooltip) beállítja a szöveget, amelyet a néző a hivatkozás tippjeként jeleníthet meg.
- [setTargetFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Hyperlink#setTargetFrame) megadja a célt keretet egy szülő HTML frameseten belül, ha alkalmazható.
- [setHistory](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Hyperlink#setHistory) szabályozza, hogy a hivatkozás aktiválása felvegye-e a célját a megtekintett hiperhivatkozások listájába.
- [setHighlightClick](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Hyperlink#setHighlightClick) szabályozza, hogy a hiperhivatkozás ki legyen-e emelve kattintáskor.

## **Hiperhivatkozások eltávolítása a prezentációkból**

Használja a [getAnyHyperlinks](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) metódust a hiperhivatkozás‑konténerek (beleértve a szövegrész hivatkozásokat) összegyűjtéséhez, mielőtt módosítaná őket. Az alábbi példa eltávolítja mindkét aktiválási típust az első diához. Ha csak egy típusát akarja eltávolítani, hívja csak a [removeHyperlinkClick](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) vagy a [removeHyperlinkMouseOver](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver) metódust; a kattintás eltávolítása nem távolítja el a fölött‑húzás megfelelőjét.

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

Feltétlen eltávolításhoz a [removeAllHyperlinks](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) mindkét aktiválási típust eltávolítja a kiválasztott hatókörben egy hívással. Szelektív takarításhoz és a mesterek, elrendezések és jegyzetek lefedéséhez lásd a [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) részt.

## **Teljes hiperhivatkozás‑nyilvántartás kiépítése**

A prezentáció terjesztése előtt ellenőrizze az interaktív műveleteket és a webes hivatkozásokat. A [getAnyHyperlinks](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) hiperhivatkozás‑konténereket ad vissza, nem egyszerű URL‑karakterláncok listáját. Vizsgálja meg mind a [getHyperlinkClick](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Shape#getHyperlinkClick), mind a [getHyperlinkMouseOver](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Shape#getHyperlinkMouseOver) metódusokat minden konténeren. Függetlenek: ugyanaz a konténer mindkét műveletet tartalmazhatja, így egy teljes jelentés akár két sort is igényel konténerenként.

Csak alakzatszintű hiperhivatkozások keresése kihagyhatja a szövegrészekhez csatolt linkeket. Kérdezze le a megfelelő hatókört, és tartsa meg a visszakapott konténereket, hogy később frissíthesse vagy eltávolíthassa azok műveleteit.

### **Prezentáció, dia és szövegkeret hatókörök lekérdezése**

A [HyperlinkQueries](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/HyperlinkQueries) osztály a [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation#getHyperlinkQueries), a [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/BaseSlide#getHyperlinkQueries) és a [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries) segítségével érhető el. Minden hatókör ugyanazokat a lekérdezéseket támogatja:

- [getHyperlinkClicks](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkClicks) visszaadja a kattintási művelettel rendelkező konténereket.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkMouseOvers) visszaadja a fölött‑húzási művelettel rendelkező konténereket.
- [getAnyHyperlinks](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) visszaadja a bármely, vagy mindkét művelettel rendelkező konténereket.

Az alábbi példa létrehozza a `hyperlink-audit-input.pptx` fájlt egy külső kattintási linkkel, egy fájl fölött‑húzási linkkel, belső dia navigációval, egy szöveges fölött‑húzási linkkel és egy makró művelettel. Nem hajt végre egyetlen műveletet sem. A három lekérdezés minden hatókörben működik; a számlálók konténerek számát mutatják, nem a műveletek összegét. A szövegkeret hatókörből kizáródnak a körülvevő alakzat saját linkjei.

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

Ebben a példában a prezentáció és a dia lekérdezések mindegyike három kattintási konténert, két fölött‑húzási konténert és három konténert jelent, amelyek bármelyik művelettel rendelkeznek. A szövegkeret lekérdezés egy konténert ad minden kategóriában.

### **Műveletek és célpontok osztályozása**

Használja a [Hyperlink.getActionType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Hyperlink#getActionType) metódust, hogy a célpont értelmezése előtt meghatározza a művelet típusát. A [HyperlinkActionType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/HyperlinkActionType) értékek a webes navigáción túl is terjednek:

| Values | Meaning for an audit |
| --- | --- |
| `Hyperlink` | Külső hiperhivatkozás; vizsgálja meg az URL-t és annak sémáját. |
| `JumpSpecificSlide` | Belső navigáció egy adott diára. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Beépített diavetítés‑navigáció, a diavetítés kontextusában értelmezve. |
| `JumpEndShow`, `StartCustomSlideShow` | Az aktuális előadás befejezése vagy egy egyedi előadás indítása. |
| `StartMacro` | Makró végrehajtása. |
| `StartProgram` | Program indítása. |
| `OpenFile`, `OpenPresentation` | Fájl vagy másik prezentáció megnyitása; külön vizsgálja meg a webes URL‑ekkel. |
| `StartStopMedia` | Média lejátszásának indítása vagy leállítása. |
| `NoAction`, `Unknown` | Nincs navigációs művelet, vagy ismeretlen művelet, amely felülvizsgálatot igényel. |

Olvassa ki a külső célpontokat a [getExternalUrl](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Hyperlink#getExternalUrl) metódussal, és a konkrét belső célpontokat a [getTargetSlide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Hyperlink#getTargetSlide) metódussal. Belső műveletek és beépített parancsok esetén lehet, hogy nincs külső URL; az üres URL nem jelenti azt, hogy a konténernek nincs művelete. Őrizze meg a [getExternalUrlOriginal](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Hyperlink#getExternalUrlOriginal) által visszaadott értéket, ha az eltér a normalizált URL‑től, és adja hozzá a [getTooltip](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Hyperlink#getTooltip) által visszaadott tooltip‑et, ha elérhető.

### **Hiperhivatkozások jelentése, tisztítása és ellenőrzése**

Az alábbi JavaScript példa beolvas egy meglévő prezentációt (a fent létrehozott fájlt használja), kiírja a `hyperlink-audit.json` fájlt, alkalmaz egy szabályzatot, elmenti a `hyperlink-sanitized.pptx` fájlt, majd újból megnyitja, hogy újra ellenőrizze mindkét aktiválási típust. A konténereket a módosítás előtt gyűjti össze, és referenciájuk egyenlőségét használja, hogy elkerülje ugyanazon konténer kétszeri feldolgozását. A prezentáció lekérdezések a szokásos diákra vonatkoznak; egy csomagszintű nyilvántartáshoz kifejezetten lekérdezi a mestereket, elrendezéseket, jegyzeteket, valamint a jegyzet‑ és anyagmestereket, ha jelen vannak.

A jelentés egy egységileg numerált diaindexet és ahol elérhető, a [getSlideId](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/BaseSlide#getSlideId) értéket rögzíti. A [getSlide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Shape#getSlide) biztosítja a tulajdonos diát a támogatott konténerekhez. A mesterek, elrendezések és jegyzetek nem rendelkeznek szokásos diaindexszel, és a hatókörük alapján azonosíthatók. Az alakzat konténereket és a szövegrész formázási konténereket külön címkézi; egyéb konténer típusok megtartják futásidejű típusnevüket. Minden konténer kap egy jelentésbeli helyi azonosítót, hogy a két művelet összerendelhető legyen. A jelentés a művelettípusokat a HyperlinkActionType felsorolás egész számú konstansaiént tárolja.

Ez a szándékosan szigorú alkalmazási szabályzat csak abszolút HTTPS URL‑eket és érvényes belső dia célpontokat engedélyez. Elutasítja a makrókat, programokat, fájlműveleteket, egyéb diavetítési műveleteket, ismeretlen műveleteket és egyéb URL sémákat. Ezek az elutasítások szabályzati döntések, nem az Aspose.Slides biztonsági megítélése. Az HTTPS önmagában nem garantál bizalmat: adjon hozzá host‑fehérlistákat és egyéb ellenőrzéseket az alkalmazásához. Mind az eredeti, mind a normalizált külső URL‑ek ellenőrzésre kerülnek. A példa a metaadatokat auditálja hivatkozások követése vagy műveletek futtatása nélkül.

Javítás esetén a konténer [getHyperlinkManager](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Shape#getHyperlinkManager) támogatja a [setExternalHyperlinkClick](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/HyperlinkManager#setExternalHyperlinkClick), a [removeHyperlinkClick](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) és a [removeHyperlinkMouseOver](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver) metódusokat. Itt a tiltott külső kattintási linkek egy rögzített HTTPS céloldalra cserélődnek; egyéb tiltott kattintások és tiltott fölött‑húzás műveletek önállóan eltávolításra kerülnek. Állítsa a `replaceExternalClicks` értékét `false`‑ra, hogy minden szabályszegést eltávolítson. Válasszon egy alkalmazás‑tulajdonú csereoldalt a telepítés előtt.

A jelentés exportálási flag‑je konzervatív PDF‑ellenőrzési szabályzatot használ: jelöli a fölött‑húzás műveleteket és mindent, ami nem külső link vagy konkrét dia ugrás, potenciálisan nem támogatottként. Ez egy ellenőrzési útmutató, nem képesség‑teszt vagy garancia arra, hogy a jelöletlen linkek exportáláskor megmaradnak. A támogatott [PDF](/slides/hu/nodejs-java/convert-powerpoint-to-pdf/) és [HTML](/slides/hu/nodejs-java/convert-powerpoint-to-html/) exportok megőrizhetik a hiperhivatkozásokat, a művelettől, az export beállításoktól és a nézőtől függően. A raster [images](/slides/hu/nodejs-java/convert-powerpoint-to-png/) és [video](/slides/hu/nodejs-java/convert-powerpoint-to-video/) nem őrizhetik meg az interaktív hiperhivatkozásokat; ezért auditáláskor minden műveletet jelöljön meg.

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

A fenti bemenettel a jelentés öt műveleti sort tartalmaz. A fájl fölött‑húzás linket és a makró kattintást eltávolítják, míg a HTTPS linkek és a belső dia navigáció megmaradnak. Az ellenőrzés nulla tiltott műveletet jelez. Egy tiltott külső kattintási URL‑t tartalmazó bemenet a csereágra is kiterjed. Egy engedélyezett kattintással és tiltott fölött‑húzással rendelkező konténer megtartja kattintási műveletét.

Ez a szelektív takarítás eltér a [removeAllHyperlinks](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) módszertől, amely mindkét aktiválási típust eltávolítja a kiválasztott hatókörön belül a szabályzat figyelembevétele nélkül. Itt a hitelesítés csak a hiperhivatkozás műveleteket ellenőrzi; nem távolítja el a beágyazott VBA projekteket, OLE objektumokat vagy egyéb aktív tartalmakat, és nem ellenőrzi a PDF vagy HTML exportált fájlt.

## **GYIK**

**Hogyan linkelhetek egy szekcióra vagy annak első diájára?**

A PowerPoint szekciók diák csoportját jelentik, de egy belső hiperhivatkozás egyedi diára mutat. Ahhoz, hogy navigációt hozzon létre egy szekcióhoz, linkelje az első diát abban a szekcióban.

**Csatolhatok hiperhivatkozást a mesterdia elemeihez, hogy minden dián működjön?**

Igen. A mesterdia és az elrendezés elemei támogatják a hiperhivatkozásokat. Ezek a linkek elérhetők a diavetítés során azon diákon, amelyek a megfelelő mestert vagy elrendezést használják.

**Megőrzik‑e a hiperhivatkozások PDF, HTML, képek vagy videó exportálásakor?**

A támogatott PDF és HTML exportok megőrizhetik a hiperhivatkozásokat; a raszteres képek és videó nem. Lásd az exportálási megfontolásokat a [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) részben.