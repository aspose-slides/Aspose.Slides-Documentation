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

Egy hiperhivatkozás a prezentáció tartalmát egy weboldalhoz vagy a prezentáción belüli helyhez köti. A PowerPointban a hiperhivatkozások általában két célra szolgálnak:

* Weboldal megnyitása szövegből, alakzatból vagy média keretből.
* Egy másik diára navigálás, például egy tartalomjegyzékből.

Az Aspose.Slides for Node.js via Java lehetővé teszi ezen linkek hozzáadását, megjelenésük és hangjuk szabályozását, tulajdonságaik frissítését és eltávolítását. Az alábbi példák bemutatják, hogyan dolgozhatunk hiperhivatkozásokkal egyedi elemeknél, valamint hogyan érhetjük el azokat a prezentáció, dia vagy szövegkeret szinten.

{{% alert color="info" title="Note" %}}

A [ingyenes online Aspose PowerPoint szerkesztő](https://products.aspose.app/slides/editor) segítségével is szerkesztheti a prezentációkat.

{{% /alert %}} 

## **URL hiperhivatkozások hozzáadása**

Weboldal URL-t rendelhet szöveghez, alakzathoz vagy média kerethez. Az a elem, amelyhez a hiperhivatkozást rendeli, határozza meg a kattintható területet: egy szövegrész a kiválasztott szöveget kapcsolja, míg egy alakzat vagy keret a dia objektumát.

A relatív hiperhivatkozásokat tartalmazó prezentációk esetén tekintse meg a [A hiperhivatkozás alapjának kezelése](/slides/hu/nodejs-java/presentation-properties/#manage-the-hyperlink-base) cikket a dokumentumszintű alap beolvasásához, módosításához vagy törléséhez.

### **URL hiperhivatkozások hozzáadása szöveghez**

A szöveget egy weboldalra hivatkozáshoz adja át egy [Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink) objektumnak a szövegrész [setHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PortionFormat#setHyperlinkClick) metódusán keresztül, ahogyan az alább látható. Csak az adott szövegrész válik kattinthatóvá.

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

Ahhoz, hogy egy alakzat vagy keret kattintható legyen, hívja meg annak [setHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setHyperlinkClick) metódusát. A hiperhivatkozás az objektumhoz tartozik, nem az azon belüli szövegrészhez.

Ugyanez a megközelítés vonatkozik kép-, hang- és videókeretekre is: rendelje hozzá a hiperhivatkozást a kerethez, és ha szükséges, hívja meg a [setTooltip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTooltip) metódust.

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

## **Hiperhivatkozások használata tartalomjegyzék létrehozásához**

Belső hiperhivatkozások lehetővé teszik az olvasók számára, hogy a tartalomjegyzékből egy adott diára ugorjanak. Az alábbi példa a [setInternalHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#setInternalHyperlinkClick) metódust használja, hogy az első dián lévő „2. oldal” szöveget a második diára linkelje.

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

A [Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink) [setColorSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setColorSource) metódusa meghatározza, hogy a hiperhivatkozás a prezentáció hiperhivatkozás színét vagy a szövegrész formázását használja-e. Egy egyedi szövegszín alkalmazásához válassza a [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkColorSource) lehetőséget, és állítsa be a rész kitöltőszínét. Ez a funkció a PowerPoint 2019‑ben került bevezetésre; a korábbi verziók nem alkalmazzák ezt a beállítást.

Az alábbi példa két szöveges hiperhivatkozást ad ugyanarra a diára. Az első vörös szövegszínnel jelenik meg, míg a másik az alapértelmezett hiperhivatkozás színét használja.

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

Egy hiperhivatkozás lejátszhat egy hangot aktiváláskor, vagy leállíthat egy már futó hangot. A következő metódusokkal állíthatja be ezeket a viselkedéseket:

- [Hyperlink.setSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setSound) adja meg a hiperhivatkozáshoz tartozó audiót.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick) szabályozza, hogy a hiperhivatkozás aktiválása megállítsa‑e az előző hangot.

#### **Hiperhivatkozás hangjának hozzáadása**

Az alábbi példa betölti a `sampleaudio.wav` fájlt, és egy gombhoz rendeli az első dián. A gomb megnyomása lejátszik a hangot és a következő diára navigál. Egy másik alakzat ugyanazon a dián leállítja az előző hangot kattintáskor, anélkül hogy navigációt végezne.

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

Az alábbi példa megnyitja a fent létrehozott prezentációt, és a [getSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getSound) és a [getBinaryData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Audio#getBinaryData) metódusok segítségével beolvassa az első alakzat hiperhivatkozás hangját a memóriába.

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

Miután egy hiperhivatkozást szöveghez vagy alakzathoz rendelt, a következő [Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink) metódusok hívhatók:

- [setTooltip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTooltip) beállítja a szöveget, amelyet a felhasználó tippetként láthat a hivatkozásra.
- [setTargetFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTargetFrame) meghatározza a céltáblát egy szülő HTML keretcsoportban, ha alkalmazható.
- [setHistory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setHistory) szabályozza, hogy a hivatkozás aktiválása felvegye‑e a célját a megtekintett hiperhivatkozások listájába.
- [setHighlightClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setHighlightClick) szabályozza, hogy a hiperhivatkozás kattintáskor ki legyen‑e emelve.

## **Hiperhivatkozások eltávolítása a prezentációkból**

Használja a [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) metódust a hiperhivatkozás‑konténerek gyűjtéséhez, beleértve a szövegrész‑linkeket is, mielőtt módosítaná őket. Az alábbi példa eltávolítja mindkét aktiválási típust az első diáról. Egyetlen típus eltávolításához hívja csak a [removeHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) vagy a [removeHyperlinkMouseOver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver) metódust; a kattintás eltávolítása nem távolítja el az egér‑overhez tartozó akciót.

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

Feltétlen eltávolítás esetén a [removeAllHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) egy hívásban mindkét aktiválási típust törli a kiválasztott hatókörben. A mester, elrendezés és megjegyzések szelektív tisztításához és lefedettségéhez tekintse meg a [Hiperhivatkozások jelentése, szanitizálása és ellenőrzése](#report-sanitize-and-verify-hyperlinks) részt.

## **Teljes hiperhivatkozás‑leltár felépítése**

A prezentáció terjesztése előtt vegye fel egyes interaktív műveleteit és webes linkjeit. A [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) konténereket ad vissza, nem egy lapos URL‑lista. Vizsgálja meg mind a [getHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkClick), mind a [getHyperlinkMouseOver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkMouseOver) metódust minden konténeren. Ezek függetlenek: ugyanaz a konténer mindkét akciót kifejezheti, ezért egy teljes jelentés akár két sorra is szükség lehet konténerenként.

A csak alakzatszintű hiperhivatkozások vizsgálata kihagyhat szövegrészhez rendelt linkeket. A megfelelő hatókört kell lekérdezni, majd a visszakapott konténereket megőrizni a későbbi frissítéshez vagy eltávolításhoz.

### **Prezentáció, dia és szövegkeret hatókörök lekérdezése**

A [HyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries) osztály elérhető a [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getHyperlinkQueries), [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getHyperlinkQueries) és a [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries) metódusokon keresztül. Minden hatókör ugyanazokat a lekérdezéseket támogatja:

- [getHyperlinkClicks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkClicks) konténereket ad vissza kattintási akcióval.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkMouseOvers) konténereket ad vissza egér‑over akcióval.
- [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) konténereket ad vissza bármelyik vagy mindkét akcióval.

Az alábbi példa egy `hyperlink-audit-input.pptx` fájlt hoz létre, amely külső kattintási linket, fájl egér‑over linket, belső dia‑navigációt, szöveg egér‑over linket és makró‑akciót tartalmaz. A példában egyik akció sem kerül végrehajtásra. Ugyanaz a három lekérdezés minden hatókörben működik; a számlálók konténerek számát mutatják, nem az akciók összegét. A szövegkeret hatókör kizárja az azt körülvevő alakzat saját linkjeit.

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

Ebben a példában a prezentáció‑ és dia‑lekérdezések három kattintási, két egér‑over és három vegyes konténert adnak vissza. A szövegkeret lekérdezés egy‑egy konténert jelez minden kategóriában.

### **Akciók és célpontok osztályozása**

Használja a [Hyperlink.getActionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getActionType) metódust az akció értelmezéséhez, mielőtt a célpontot vizsgálná. A [HyperlinkActionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkActionType) értékek a web‑navigáción túl is kiterjednek:

| Értékek | Jelentés felülvizsgálat során |
| --- | --- |
| `Hyperlink` | Külső hiperhivatkozás; vizsgálja meg az URL‑t és annak sémáját. |
| `JumpSpecificSlide` | Belső navigáció egy adott diára. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Beépített diavetítés‑navigáció, a diavetítés kontextusában értelmezve. |
| `JumpEndShow`, `StartCustomSlideShow` | Az aktuális bemutató befejezése vagy egy egyéni bemutató indítása. |
| `StartMacro` | Makró végrehajtása. |
| `StartProgram` | Program indítása. |
| `OpenFile`, `OpenPresentation` | Fájl vagy másik prezentáció megnyitása; külön ellenőrizze a web‑URL‑ektől. |
| `StartStopMedia` | Média lejátszás indítása vagy leállítása. |
| `NoAction`, `Unknown` | Nincs navigációs akció, vagy ismeretlen akció, amely felülvizsgálatot igényel. |

A külső célpontokat a [getExternalUrl](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrl) metódussal olvassa ki, a specifikus belső célokat pedig a [getTargetSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getTargetSlide) segítségével. Belső akciók és beépített parancsok esetén előfordulhat, hogy nincs külső URL; egy üres URL nem jelenti azt, hogy a konténernek nincs akciója. Ha a [getExternalUrlOriginal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrlOriginal) más értéket ad vissza a normalizált URL‑hez képest, őrizze meg azt, és ha elérhető, a [getTooltip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getTooltip) által visszaadott tooltipet is vegye figyelembe.

### **Hiperhivatkozások jelentése, szanitizálása és ellenőrzése**

Az alábbi JavaScript‑példa beolvassa a meglévő prezentációt (a fent létrehozott fájlt használja), a `hyperlink-audit.json`‑t írja, alkalmaz egy szabályt, elmenti a `hyperlink-sanitized.pptx`‑t, majd újra megnyitja, hogy újból ellenőrizze mindkét aktiválási típust. A módosítás előtt konténereket gyűjt, és referencia‑egyenlőséget használ, hogy ne dolgozza fel ugyanazt a konténert kétszer. A prezentáció‑lekérdezések a szokásos diákat fedik le; egy csomagszintű leltárhoz kifejezetten a master‑eket, elrendezéseket, megjegyzéseket és a megjegyzés‑ illetve kézbeadás‑mastereket is lekérdezi, ha léteznek.

A jelentés egy‑alapú dia‑indexet és a [getSlideId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getSlideId) értéket tartalmaz, ha elérhető. A [getSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getSlide) megadja a tulajdonó diát a támogatott konténerekhez. A master‑ek, elrendezések és megjegyzések nem rendelkeznek szokásos dia‑indexszel, ezeket hatókörük alapján azonosítja. Az alakzat‑konténereket és a szövegrész‑formázási konténereket külön címkézi; a többi konténer típusa megtartja a futásidejű típusnevét. Minden konténer kap egy jelentés‑helyi azonosítót, hogy a két akció összekapcsolható legyen. A jelentés az akciótípusokat a HyperlinkActionType felsorolásban definiált egész‑konstansokként tárolja.

Ez a szándékosan szigorú alkalmazási szabály csak abszolút HTTPS URL‑eket és érvényes belső diacélokat engedélyez. Elutasítja a makrókat, programokat, fájl‑akciókat, egyéb diavetítés‑akciókat, ismeretlen akciókat és más URL‑sémákat. Ezek az elutasítások szabályozási döntések, nem az Aspose.Slides biztonsági megítélése. Az HTTPS önmagában nem garantálja a megbízhatóságot: adjon hozzá host‑engedélylistákat és egyéb ellenőrzéseket alkalmazásához. Az eredeti és a normalizált külső URL‑eket egyaránt ellenőrzi. A példa metaadatokat auditál linkek követése vagy akciók futtatása nélkül.

Javításkor a konténer [getHyperlinkManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkManager) támogatja a [setExternalHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#setExternalHyperlinkClick), a [removeHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) és a [removeHyperlinkMouseOver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver) metódusokat. Itt a tiltott külső kattintási linkeket egy rögzített HTTPS céloldallal helyettesítik; a többi tiltott kattintás és egér‑over akció önállóan eltávolításra kerül. Állítsa `replaceExternalClicks` értékét `false`‑ra, ha az összes szabálysértést eltávolítaná. Válasszon egy alkalmazás‑tulajdonú helyettesítő oldalt a kiadás előtt.

A jelentés exportálási jelzője egy konzervatív PDF‑ellenőrzési szabályt használ: egér‑over akciókat és minden, az externális link vagy konkrét dia‑ugrás kivételével, potenciálisan nem támogatottként jelöli. Ez egy felülvizsgálati tipp, nem teljesítményteszt vagy garancia arra, hogy a jelzés nélküli linkek megmaradnak az exportálás során. A támogatott [PDF](/slides/hu/nodejs-java/convert-powerpoint-to-pdf/) és [HTML](/slides/hu/nodejs-java/convert-powerpoint-to-html/) exportok megőrizhetik a hiperhivatkozásokat, az akciótól, az export‑beállításoktól és a megjelenítőtől függően. A raszteres [képek](/slides/hu/nodejs-java/convert-powerpoint-to-png/) és [videók](/slides/hu/nodejs-java/convert-powerpoint-to-video/) nem képesek megőrizni interaktív hiperhivatkozásokat; ezért auditáláskor minden ilyen kimenet esetén jelölje meg az összes akciót.

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

A fenti bemenettel a jelentés öt akciósort tartalmaz. A fájl‑egér‑over link és a makró‑kattintás eltávolításra kerül, míg a HTTPS linkek és a belső dia‑navigáció megmarad. Az ellenőrzés nulla tiltott akciót jelez. Egy tiltott külső kattintási URL‑t tartalmazó bemenet a helyettesítési ágat is teszteli. Egy engedélyezett kattintással és tiltott egér‑overrel rendelkező konténer megtartja a kattintási akciót.

Ez a szelektív tisztítás eltér a [removeAllHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) működésétől, amely a kiválasztott hatókörben mindkét aktiválási típust eltávolítja a szabályok figyelembevétele nélkül. Az ellenőrzés itt csak a hiperhivatkozás‑akciókat vizsgálja; nem távolítja el a beágyazott VBA‑projektek, OLE‑objektumok vagy egyéb aktív tartalmakat, és nem validálja a kiexportált PDF vagy HTML fájlt.

## **GYIK**

**Hogyan linkelhetek egy szakaszra vagy annak első diájára?**

A PowerPointban a szakaszok diákat csoportosítanak, de egy belső hiperhivatkozás egy adott diára mutat. A szakaszra történő navigáció létrehozásához linkelje a szakasz első diájára.

**Hozzáadhatok-e hiperhivatkozást a mesterdia elemeihez, hogy minden dián működjön?**

Igen. A mesterdia és az elrendezés elemei támogatják a hiperhivatkozásokat. Ezek a linkek a diavetítés során elérhetők azon diáken, amelyek a megfelelő master‑t vagy elrendezést használják.

**Megmaradnak-e a hiperhivatkozások PDF, HTML, képek vagy videó exportálásakor?**

A támogatott PDF és HTML exportok megőrizhetik a hiperhivatkozásokat; a raszteres képek és videók nem képesek erre. Lásd a [Hiperhivatkozások jelentése, szanitizálása és ellenőrzése](#report-sanitize-and-verify-hyperlinks) részt az exportálási szempontokról.