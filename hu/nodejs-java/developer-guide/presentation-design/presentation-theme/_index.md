---
title: Prezentációs témák kezelése JavaScriptben
linktitle: Prezentációs téma
type: docs
weight: 10
url: /hu/nodejs-java/presentation-theme/
keywords:
- PowerPoint téma
- prezentációs téma
- dia téma
- téma beállítása
- téma módosítása
- téma kezelése
- téma szín
- kiegészítő paletta
- téma betűtípusa
- téma stílusa
- téma effektusa
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Kezelje a prezentációs témákat JavaScriptben az Aspose.Slides for Node.js segítségével, hogy egységes arculattal hozza létre, testre szabja és konvertálja a PowerPoint fájlokat."
---
## **Bevezetés**

Egy prezentációs téma egy koordinált szín-, betűtípus-, háttérstílus-, kitöltés-, vonal- és effektuskészletet definiál. A témát figyelembe vevő objektumok ezekre a közös definíciókra hivatkoznak ahelyett, hogy minden vizuális tulajdonságot rögzített értékként tárolnának, így egy téma módosítása egyszerre több objektumot frissíthet.

Az Aspose.Slides-ben a prezentációszintű téma a [Presentation.getMasterTheme](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/getmastertheme/) segítségével érhető el. A prezentáció alacsonyabb szinteken is tartalmazhat téma‑felülírásokat. Egy master a prezentáció témáját a [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masterthememanager/) segítségével felülírhatja, míg egy elrendezés vagy egy önálló dia az örökölt témáját a [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseoverridethememanager/) használatával módosíthatja. Gyakorlatban egy dia hatékony témáját ez a öröklődési lánc határozza meg: prezentációs téma, master felülírás, elrendezés felülírás és dia felülírás.

![A téma összetevői: színek, betűtípusok, háttérstílusok és effektek](theme-constituents.png)

Az alábbi szakaszok a leggyakoribb téma‑munkafolyamatokat mutatják be: egy téma ellenőrzése, színek és betűtípusok módosítása, téma másolása vagy alkalmazása, háttér‑ és effektusstílusok frissítése, valamint a hatékony értékek kiolvasása öröklődés és felülírások feloldása után.

## **Téma ellenőrzése**

A [MasterTheme](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/mastertheme/) objektum a téma színsémáját, betűtípus‑sémáját és formátumsémáját a [MasterTheme.getColorScheme](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/mastertheme/) és [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/mastertheme/) segítségével teszi elérhetővé. Ezeknek a gyűjteményeknek az ellenőrzése a módosítás előtt különösen hasznos, ha a prezentáció külső forrásból származik, mivel a stílusbejegyzések száma és tartalma változhat.

Az alábbi példa beolvassa a fő téma‑tulajdonságokat, és jelentést készít arról, hány háttér, kitöltés, vonal és effektus stílus van a témában tárolva:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const theme = presentation.getMasterTheme();
    console.log("Theme name: " + theme.getName());
    console.log("Accent 1: " + theme.getColorScheme().getAccent1().getColor());
    console.log("Major Latin font: " + theme.getFontScheme().getMajor().getLatinFont().getFontName());
    console.log("Minor Latin font: " + theme.getFontScheme().getMinor().getLatinFont().getFontName());
    console.log("Background fill styles: " + theme.getFormatScheme().getBackgroundFillStyles().size());
    console.log("Fill styles: " + theme.getFormatScheme().getFillStyles().size());
    console.log("Line styles: " + theme.getFormatScheme().getLineStyles().size());
    console.log("Effect styles: " + theme.getFormatScheme().getEffectStyles().size());
} finally {
    presentation.dispose();
}
```

Ha egy fájl több master‑t használ, ne tegyük fel, hogy minden dia ugyanazzal a hatékony témával rendelkezik. Ellenőrizzük a diával társított master‑t, és használjuk az későbbiekben bemutatott hatékony‑téma munkafolyamatot, ha elrendezés‑ vagy dia‑felülírások léteznek.

## **Téma színeinek módosítása**

A témát figyelembe vevő kitöltések, vonalak és szövegek hivatkozhatnak egy logikai színre a [SchemeColor](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/schemecolor/) felsorolásból. Amikor a megfelelő bejegyzést módosítjuk a [ColorScheme](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/colorscheme/)-ben, minden olyan objektum, amely még mindig erre a téma‑színre hivatkozik, az új értékre kerül feloldásra. Azok az objektumok, amelyek közvetlen RGB‑színt használnak, nem változnak meg egy téma‑szín frissítésekor.

Az alábbi teljes körű példa létrehoz egy alakzatot, amely az `Accent4` színt használja, megváltoztatja a téma `Accent4` színét pirosra, elmenti a prezentációt, újra megnyitja, és kiírja a hatékony kitöltőszínt:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    presentation.save("theme-color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const savedPresentation = new aspose.slides.Presentation("theme-color.pptx");
try {
    const savedSlide = savedPresentation.getSlides().get_Item(0);
    const savedShape = savedSlide.getShapes().get_Item(0);
    const effectiveFill = savedShape.getFillFormat().getEffective();
    console.log("Effective fill color: " + effectiveFill.getSolidFillColor());
} finally {
    savedPresentation.dispose();
}
```

Mivel a téglalap továbbra is az `Accent4`-re hivatkozik, látható színe pirosra változik a téma módosítása után. Ha a téma‑színt közvetlen színre cseréljük az alakzaton, a későbbi `Accent4` változások már nem befolyásolják azt a kitöltést.

### **Színek használata a kiegészítő palettából**

A PowerPoint a téma‑színből világosabb és sötétebb változatokat hoz létre színátalakítások alkalmazásával. Az Aspose.Slides ezeket az átalakításokat a [ColorTransformOperation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/colortransformoperation/) felsorolás segítségével teszi elérhetővé.

![A fő téma színei és a kiegészítő palettából generált világosabb és sötétebb színek](additional-palette-colors.png)

**1** – A fő téma színei.

**2** – A fő téma színeiből előállított világosabb és sötétebb változatok.

Az alábbi példa hat téglalapot hoz létre az `Accent4` alapján, ötön luminancia‑átalakítást végez, és elmenti az eredményt:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);

    const shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.2));
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.8));

    const shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.4));
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.6));

    const shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.6));
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.4));

    const shape5 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.75));

    const shape6 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.5));

    presentation.save("theme-color-palette.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ezek a változatok a téma‑színen alapulnak. Ha az `Accent4` később megváltozik, a transzformált színek újra lesznek számítva az új `Accent4` értékből.

### **A `SchemeColor` értékek leképezése a `ColorScheme` helyekre**

A [SchemeColor](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/schemecolor/) felsorolás a `Text1`, `Background1`, `Text2` és `Background2` értékeket használja, míg a [ColorScheme](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/colorscheme/) ugyanazokat a témahelyeket `Dark1`, `Light1`, `Dark2` és `Light2` néven jeleníti meg. A leképezés rögzített:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Ezek ugyanazon témahelyek alternatív nevei; nem dinamikusan konvertált értékek.

## **Téma betűtípusainak módosítása**

Egy téma betűtípussémája egy fő betűkészletet tartalmaz a címsorokhoz és egy kisebb betűkészletet a törzsszöveghez. A [FontScheme.getMajor](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontscheme/) és a [FontScheme.getMinor](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontscheme/) módszerek ezeket a készleteket teszik elérhetővé.

PowerPoint‑kompatibilis téma‑betűtípus azonosítók használhatók a szövegformázásban:

* `+mn-lt` – Body Font Latin (Minor Latin Font)
* `+mj-lt` – Heading Font Latin (Major Latin Font)
* `+mn-ea` – Body Font East Asian (Minor East Asian Font)
* `+mj-ea` – Heading Font East Asian (Major East Asian Font)

Az alábbi példa létrehoz egy címsort, amely a fő latin téma‑betűtípust használja, és egy törzssort, amely a kisebb latin téma‑betűtípust használja. Ezután megváltoztatja a téma betűtípusait, és elmenti az eredményt:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const heading = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 500, 60);
    heading.getTextFrame().setText("Theme heading");
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new aspose.slides.FontData("+mj-lt"));

    const body = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 120, 500, 60);
    body.getTextFrame().setText("Theme body text");
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));

    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(new aspose.slides.FontData("Aptos Display"));
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Arial"));
    presentation.save("theme-fonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A címsor a fő betűtípust, a törzsszöveg pedig a kisebb betűtípust követi. Azok a szövegek, amelyek explicit betűtárgat nevet tartalmaznak a téma‑azonosító helyett, nem váltanak automatikusan, ha a téma betűtípus sémája megváltozik.

{{% alert color="info" title="Tipp" %}}
További információk a prezentáció‑betűtípusokról: [PowerPoint Fonts](/slides/hu/nodejs-java/powerpoint-fonts/).
{{% /alert %}}

## **Téma másolása vagy alkalmazása**

Két gyakori munkafolyamat létezik, és más‑más problémát oldanak meg.

### **Forrástéma megőrzése diák áthelyezésekor**

Ha egy diát egy másik prezentációba szeretnénk áthelyezni, miközben megőriznénk az eredeti megjelenést, klónozzuk a forrás‑master‑t a cél‑prezentációba a [MasterSlideCollection.addClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masterslidecollection/) segítségével, majd a diát a [SlideCollection.addClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slidecollection/) és a klónozott master használatával klónozzuk. Ez a master‑t, az elrendezéseket és a hozzá tartozó témát együtt szállítja.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceSlide = source.getSlides().get_Item(0);
        const clonedMaster = target.getMasters().addClone(sourceSlide.getLayoutSlide().getMasterSlide());
        target.getSlides().addClone(sourceSlide, clonedMaster, true);
        target.save("theme-preserved.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Ez a preferált munkafolyamat, ha a forrás‑dia megjelenésének pontos egyezése a célnál fontos. A tartalom egyszerű klónozása egy nem kapcsolódó cél‑master‑re megváltoztathatja a téma‑vezérelt színeket, betűtípusokat, háttér‑ és effektus‑beállításokat.

### **Témaértékek alkalmazása meglévő diára**

Ha a cél‑dia a jelenlegi master‑en és elrendezésen marad, inicializáljunk egy dia‑szintű felülírást a forrás‑téma alapján. Az [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/overridetheme/) és [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/overridetheme/) metódusok másolják a három fő téma‑komponenst a felülírásba.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceTheme = source.getMasterTheme();
        const targetSlide = target.getSlides().get_Item(0);
        const overrideTheme = targetSlide.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(sourceTheme.getColorScheme());
        overrideTheme.initFontSchemeFrom(sourceTheme.getFontScheme());
        overrideTheme.initFormatSchemeFrom(sourceTheme.getFormatScheme());
        target.save("theme-applied-to-slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Ez megváltoztatja a dián használt témát anélkül, hogy a többi dia örökölt témáját módosítaná. A helyi felülírás eltávolításához és az örökölt értékek visszaállításához hívd meg a [OverrideTheme.clear](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/overridetheme/) metódust.

### **Téma felülírás alkalmazása elrendezésre**

Az elrendezés‑szintű felülírás az azon elrendezést használó diákra érvényes, kivéve ha egy adott dia saját felülírással rendelkezik. Ugyanezeket az inicializálási metódusokat a [LayoutSlideThemeManager](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutslidethememanager/) segítségével lehet használni:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceTheme = source.getMasterTheme();
        const targetSlide = target.getSlides().get_Item(0);
        const overrideTheme = targetSlide.getLayoutSlide().getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(sourceTheme.getColorScheme());
        overrideTheme.initFontSchemeFrom(sourceTheme.getFontScheme());
        overrideTheme.initFormatSchemeFrom(sourceTheme.getFormatScheme());
        target.save("theme-applied-to-layout.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Használj master‑ vagy prezentáció‑szintű témát, ha sok elrendezésnek és diáknak közös alaptervet kell megosztania; elrendezés‑felülírást, ha egy elrendezéscsoportnak eltérő stílusra van szüksége; és dia‑felülírást csak valódi kivételekhez. A túlzott dia‑szintű felülírások nehezebbé teszik a későbbi globális téma‑változtatások előrejelzését.

## **Téma háttérstílusok frissítése**

A téma háttér‑kitöltései a [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/formatscheme/) gyűjteményben vannak tárolva. A PowerPoint a felhasználói felületen több háttérválasztási lehetőséget mutathat, mint amennyi kitöltésdefiníció fizikailag tárolva van ebben a gyűjteményben, mivel a UI kombinálhat téma‑kitöltéseket téma‑színekkel és más stílus‑hivatkozásokkal.

![PowerPoint háttérstílus galéria egy prezentációs téma számára](presentation-design_8.png)

Mielőtt háttérstílust használnál, ellenőrizd a tárolt gyűjteményt és a jelenlegi [Background.getStyleIndex](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/background/) értéket. A `0`‑ás index azt jelenti, hogy nincs témakövetett kitöltés; a pozitív értékek téma‑háttér‑stílus hivatkozások. Ez különbözik a JavaScript‑gyűjtemény közvetlen indexelésétől, ahol a `0` az első tárolt elem. Ne feltételezd, hogy minden prezentáció ugyanannyi háttér‑kitöltés‑stílussal rendelkezik.

Az alábbi példa bejelenti a rendelkezésre álló háttér‑kitöltés számát, egy témakövetett háttérhivatkozást rendel az első master‑hez, és elmenti a prezentációt:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const backgroundStyles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles();
    console.log("Background fill styles: " + backgroundStyles.size());
    if (backgroundStyles.size() === 0) {
        throw new Error("The presentation theme does not contain background fill styles.");
    }

    const masterSlide = presentation.getMasters().get_Item(0);
    masterSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.Themed));
    masterSlide.getBackground().setStyleIndex(1);
    presentation.save("theme-background.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A látható eredmény a master által hivatkozott téma‑bejegyzéstől, valamint az elrendezés‑ vagy dia‑szintű háttér‑felülírásoktól függ. Ha egy dia saját háttérrel rendelkezik, a master háttér módosítása nem feltétlenül változtatja meg azt a diát. Használd a [Background.getEffective](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/background/) metódust, ha a végső, öröklődés után alkalmazott háttérre van szükséged.

{{% alert color="warning" title="Figyelmeztetés" %}}
Ne kezeld a stílusindexet nulla‑alapú gyűjteményindexként. Kerüld el a stílusszámok kódból való kitömörítését egy fájlból, és annak feltételezését, hogy egy másik fájlban ugyanúgy néz ki; a téma‑stílusdefiníciók prezentációnként eltérőek.
{{% /alert %}}

{{% alert color="info" title="Tipp" %}}
A közvetlen háttérformázással és háttér‑öröklődéssel kapcsolatos információkért lásd a [Presentation Background](/slides/hu/nodejs-java/presentation-background/) oldalt.
{{% /alert %}}

## **Téma effektusok frissítése**

A téma formátumsémája különálló kitöltés‑, vonal‑ és effektus‑stílus gyűjteményeket tartalmaz, amelyeket a [FormatScheme.getFillStyles](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/formatscheme/) és [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/formatscheme/) metódusok tesznek elérhetővé. A tipikus Office‑témák gyakran három fő stílusbejegyzést tartalmaznak, amelyek vizuálisan a finom, közepes és intenzív formázást képviselik, de a kódnak mindig a gyűjteményeket kell ellenőriznie, ahelyett, hogy rögzített számot feltételezne.

![Finom, közepes és intenzív téma‑effektek ugyanazon alakzatra alkalmazva](presentation-design_10.png)

JavaScript‑ben a gyűjtemény indexelése nullától indul: az `0`‑ás index az első tárolt stílus, a `2`‑es a harmadik. Az alakzat‑stílus‑referenciák indexei egy külön koncepciót jelentenek, amely a [ShapeStyle](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shapestyle/) segítségével érhető el. Egy téma‑stílus módosítása azokra az alakzatokra hat, amelyek hivatkoznak arra a téma‑stílusra; a közvetlen formázással rendelkező alakzatok változatlanok maradhatnak.

Az alábbi példa ellenőrzi, hogy a szükséges stílusbejegyzések léteznek, megváltoztatja az első vonal‑stílust, a harmadik kitöltés‑stílust, engedélyezi a külső árnyékot a harmadik effektus‑stílusban, majd elmenti az eredményt:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("Subtle_Moderate_Intense.pptx");
try {
    const formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new Error("The theme does not contain the style entries required by this example.");
    }

    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    formatScheme.getFillStyles().get_Item(2).setFillType(java.newByte(aspose.slides.FillType.Solid));
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 34, 139, 34));
    const effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10);
    presentation.save("theme-effects.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A slotokat hivatkozó alakzatok esetén az első téma‑vonal‑stílus pirosra, a harmadik téma‑kitöltés‑stílus szilárd erdei zöldre, a harmadik effektus‑stílus pedig külső árnyékra 10 pont távolsággal változik. A pontos vizuális eredmény továbbra is attól függ, hogy melyik stílus‑slotra hivatkozik az adott alakzat, és hogy a közvetlen formázás felülírja-e a téma‑beállításokat.

![Téma‑effektus‑stílusok módosítás után: vonal, kitöltés és árnyék beállítások](presentation-design_11.png)

## **Hatékony témaértékek kiolvasása**

A nyers témaobjektumok megmutatják, mi van definiálva egy adott szinten. A hatékony értékek azt mutatják, mit használ egy dia vagy alakzat az öröklődés és a helyi felülírások feloldása után. Diára a [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseoverridethememanager/) hívható. Háttérre a [Background.getEffective](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/background/) használható, kitöltésre pedig a [FillFormat.getEffective](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fillformat/) hívható.

Az alábbi példa beolvassa a hatékony témát, a háttért és az első alakzat kitöltését egy diához:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const effectiveTheme = slide.getThemeManager().createThemeEffective();
    const effectiveBackground = slide.getBackground().getEffective();
    console.log("Effective major Latin font: " + effectiveTheme.getFontScheme().getMajor().getLatinFont().getFontName());
    console.log("Effective minor Latin font: " + effectiveTheme.getFontScheme().getMinor().getLatinFont().getFontName());
    console.log("Effective background fill type: " + effectiveBackground.getFillFormat().getFillType());
    if (slide.getShapes().size() > 0) {
        const effectiveFill = slide.getShapes().get_Item(0).getFillFormat().getEffective();
        console.log("First shape effective fill type: " + effectiveFill.getFillType());
        if (effectiveFill.getFillType() === aspose.slides.FillType.Solid) {
            console.log("First shape effective fill color: " + effectiveFill.getSolidFillColor());
        }
    }
} finally {
    presentation.dispose();
}
```

Használd a hatékony adatokat diagnosztikához, validáláshoz és összehasonlításokhoz. Ha csak a [Presentation.getMasterTheme](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/getmastertheme/) ellenőrzésével foglalkozol, könnyen kihagyhatsz egy master, elrendezés, dia vagy alakzat felülírást, amely megváltoztatja a végső megjelenést.

## **GYIK**

**Alkalmazhatok egy témát egyetlen diára anélkül, hogy a master‑t módosítanám?**

Igen. Használd a dia [SlideThemeManager](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slidethememanager/) objektumát, és inicializáld a felülírási témáját. A változtatás csak arra a diára lesz lokális; a többi dia a meglévő témáit örökli.

**Mi a legbiztonságosabb módja egy téma átvitelének egy prezentációból a másikba?**

Amikor egy diát áthelyezünk és meg akarjuk őrizni a forrás‑megjelenést, klónozzuk a forrás‑master‑t a cél‑prezentációba, majd a diát a [MasterSlideCollection.addClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masterslidecollection/) és a [SlideCollection.addClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slidecollection/) segítségével klónozzuk. Ez együtt tartja a master‑t, az elrendezéseket és a témát.

**Hogyan tekinthetem meg a hatékony értékeket az öröklődés és a felülírások után?**

Használd a [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseoverridethememanager/) metódust egy dia vagy elrendezés téma esetén, valamint a megfelelő hatékony‑adat metódusokat formátumobjektumokhoz, például a [Background.getEffective](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/background/) és a [FillFormat.getEffective](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fillformat/) hívásokat. Ezek az API‑k a feloldott értékeket adják vissza az öröklődés és a felülírások alkalmazása után.