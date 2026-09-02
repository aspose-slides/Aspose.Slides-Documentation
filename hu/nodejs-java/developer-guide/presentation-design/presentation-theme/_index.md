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
- téma betűtípus
- téma stílus
- téma effektus
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Az Aspose.Slides for Node.js segítségével JavaScriptben fő prezentációs témák kezelése, amelyekkel PowerPoint fájlokat hozhat létre, testreszabhat és konvertálhat egységes márkázással."
---
## **Bevezetés**

A prezentációs téma meghatároz egy összehangolt szín-, betűtípus-, háttérstílus-, kitöltés-, vonal- és effektkészletet. A témára érzékeny objektumok ezekre a megosztott definíciókra hivatkoznak, ahelyett, hogy minden vizuális tulajdonságot rögzített értékként tárolnának, így egy téma módosítása egyszerre sok objektumot frissíthet.

In Aspose.Slides, the presentation-level theme is available through [Presentation.getMasterTheme](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/getmastertheme/). A presentation can also contain theme overrides at lower levels. A master can override the presentation theme through [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masterthememanager/), while a layout or an individual slide can override its inherited theme through [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseoverridethememanager/). In practice, the effective theme for a slide is resolved through this inheritance chain: presentation theme, master override, layout override, and slide override.

![A téma összetevői: színek, betűtípusok, háttérstílusok és effektek](theme-constituents.png)

Az alábbi szakaszok a leggyakoribb téma munkafolyamatokat mutatják be: téma ellenőrzése, színek és betűtípusok módosítása, téma másolása vagy alkalmazása, háttér- és effektstílusok frissítése, valamint a öröklődés és felülbírálás után feloldott tényleges értékek olvasása.

## **Téma vizsgálata**

A [MasterTheme](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/mastertheme/) objektum a téma színsémáját, betűtípus-sémáját és formátumsémáját teszi elérhetővé a [MasterTheme.getColorScheme](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/mastertheme/) és [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/mastertheme/) segítségével. Ezeknek a gyűjteményeknek a vizsgálata a módosítás előtt különösen hasznos, ha a prezentáció külső forrásból származik, mivel a stílusbejegyzések száma és tartalma változhat.

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

Ha egy fájl több masterrel dolgozik, ne tételezzük fel, hogy minden dia ugyanazzal a tényleges téma­val rendelkezik. Vizsgálja meg a diával kapcsolatos mastert, és használja a később ebben a cikkben bemutatott tényleges‑téma munkafolyamatot, ha elrendezés‑ vagy dia‑felülbírálás jelen lehet.

## **Téma színeinek módosítása**

A témára érzékeny kitöltések, vonalak és szöveg hivatkozhat logikai színre a [SchemeColor](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/schemecolor/) felsorolásból. Amikor módosítja a megfelelő bejegyzést a [ColorScheme](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/colorscheme/)‑ben, az összes, továbbra is a téma színére hivatkozó objektum az új értékhez lesz leképezve. Az RGB közvetlen színt használó objektumok nem változnak a téma‑szín frissítésekor.

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

Mivel a téglalap továbbra is a `Accent4`‑hez van kapcsolva, látható színe pirosra változik a téma módosítása után. Ha a séma színt közvetlen színre cseréli az alakzaton, a későbbi `Accent4` változások már nem befolyásolják azt a kitöltést.

### **A kiegészítő palettáról színek használata**

A PowerPoint könnyebb és sötétebb változatokat származtat a téma színéből színátmenetek alkalmazásával. Az Aspose.Slides ezeket az átalakításokat a [ColorTransformOperation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/colortransformoperation/) felsorolás segítségével teszi elérhetővé.

![A fő téma színek és a kiegészítő palettából generált világosabb és sötétebb színek](additional-palette-colors.png)

**1** - A fő téma színek.

**2** - A fő téma színeiből előállított világosabb és sötétebb változatok.

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

Ezek a változatok a téma színén alapulnak. Ha a `Accent4` később megváltozik, a transzformált színek újra lesznek számítva az új `Accent4` értékből.

### **`SchemeColor` értékek leképezése `ColorScheme` helyekre**

A [SchemeColor](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/schemecolor/) felsorolás a `Text1`, `Background1`, `Text2` és `Background2` értékeket használja, míg a [ColorScheme](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/colorscheme/) ugyanazokat a témahelyeket `Dark1`, `Light1`, `Dark2` és `Light2` néven teszi elérhetővé. A leképezés rögzített:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Ezek ugyanazon témahelyek alternatív nevei; nem dinamikusan átalakított értékek.

## **Téma betűtípusainak módosítása**

A téma betűtípus‑sémája egy fő betűkészletet tartalmaz a címsorokhoz és egy mellék betűkészletet a törzsszöveghez. A [FontScheme.getMajor](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontscheme/) és a [FontScheme.getMinor](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontscheme/) metódusok teszik elérhetővé ezeket a készleteket.

PowerPoint‑kompatibilis téma‑betűtípus azonosítók használhatók a szöveg formázásában:

* `+mn-lt` – Test betű Latin (Minor Latin Font)
* `+mj-lt` – Címsor betű Latin (Major Latin Font)
* `+mn-ea` – Test betű Kelet‑ázsiai (Minor East Asian Font)
* `+mj-ea` – Címsor betű Kelet‑ázsiai (Major East Asian Font)

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

A címsor a fő betűtípust, a törzsszöveg pedig a mellék betűtípust használja. Az expliciten megadott betűtípussal rendelkező szöveg nem vált automatikusan, ha a téma betűtípus‑sémája megváltozik.

A fő‑ és mellék‑betűtípus‑gyűjtemények tartalmazhatnak betűtérképeket egyes írásrendszerekhez, például cirill, arab, japán, grúz és thaana. Ezeknek a leképezéseknek a vizsgálatához, hozzáadásához, cseréjéhez vagy eltávolításához lásd a [Script‑Specific Theme Fonts](/slides/hu/nodejs-java/script-specific-font-mappings/) oldalt.

{{% alert color="info" title="Tip" %}}
További információ a prezentáció betűtípusaival kapcsolatban megtalálható a [PowerPoint Fonts](/slides/hu/nodejs-java/powerpoint-fonts/) oldalon.
{{% /alert %}}

## **Téma másolása vagy alkalmazása**

Két gyakori munkafolyamat van, és különböző problémákat oldanak meg.

### **Forrás téma megőrzése diák mozgatásakor**

Ha egy diát egy másik prezentációba szeretne áthelyezni és megőrizni eredeti megjelenését, klónozza a forrás master‑t a cél‑prezentációba a [MasterSlideCollection.addClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masterslidecollection/)‑vel, majd klónozza a diát a [SlideCollection.addClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slidecollection/)‑val és a klónozott masterrel. Így a master, az elrendezései és a kapcsolódó téma együtt kerülnek át.

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

Ez a preferált módszer, ha a forrás dia megjelenésének azonosnak kell lennie a célban. Egy nem kapcsolódó cél‑masterre történő egyszerű tartalomklónozás módosíthatja a téma‑alapú színeket, betűtípusokat, háttereket és effekteket.

### **Témaértékek alkalmazása meglévő diára**

Ha a cél dia a jelenlegi masterén és elrendezésén marad, inicializáljon diaszintű felülbírálást a forrás témából. Az [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/overridetheme/) és [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/overridetheme/) metódusok másolják a három fő témaelemet a felülbírálásba.

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

Ez megváltoztatja a dián használt témát anélkül, hogy a többi dia öröklött témáját módosítaná. A helyi felülbírálás eltávolításához és az örökölt értékek visszaállításához hívja az [OverrideTheme.clear](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/overridetheme/)‑t.

### **Téma felülbírálás alkalmazása elrendezésre**

Az elrendezés‑szintű felülbírálás az arra épülő diákra vonatkozik, hacsak egy adott dia nem rendelkezik saját felülbírálással. Ugyanazok a inicializáló metódusok használhatók a [LayoutSlideThemeManager](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutslidethememanager/)‑n keresztül:

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

Használjon master‑ vagy prezentáció‑szintű témát, ha sok elrendezésnek és diáknak közös alaptervet kell megosztania, elrendezés‑felülbírálást, ha egy elrendezéscsaládnak más stílusra van szüksége, és csak diaszintű felülbírálást igazán kivételes esetekben. A túlzott diaszintű felülbírálások nehezebbé teszik a későbbi globális téma változtatásának előrejelzését.

## **Téma háttérstílusok frissítése**

A téma háttérkitöltései a [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/formatscheme/)‑ben tárolódnak. A PowerPoint a felhasználói felületen több háttérválasztási lehetőséget mutathat, mint a gyűjteményben fizikailag tárolt kitöltésdefiníciók száma, mivel a UI a téma‑kitöltéseket témaszínekkel és egyéb stílusreferenciákkal kombinálhatja.

![PowerPoint háttérstílus galéria egy prezentációs téma számára](presentation-design_8.png)

Mielőtt háttérstílust használna, vizsgálja meg a tárolt gyűjteményt és a jelenlegi [Background.getStyleIndex](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/background/)-et. A `0`‑s index azt jelenti, hogy nincs témához tartozó kitöltés; a pozitív értékek téma‑háttér‑stílus‑referenciák. Ez eltér a JavaScript‑gyűjtemény közvetlen indexelésétől, ahol a `0` az első tárolt elemet jelöli. Ne tételezze fel, hogy minden prezentáció ugyanannyi háttér‑kitöltés‑stílussal rendelkezik.

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

A látható eredmény a master által hivatkozott téma‑bejegyzéstől és a layout‑ vagy dia‑szintű háttér‑felülbírálásoktól függ. Ha egy dia saját hátteret használ, a csak a master hátterének módosítása nem feltétlenül változtatja meg azt a diát. Használja a [Background.getEffective](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/background/)‑t, ha a teljes háttérre van szüksége az öröklődés alkalmazása után.

{{% alert color="warning" title="Warning" %}}
Ne kezelje a stílus‑indexet nullával kezdődő gyűjtemény‑indexként. Emellett kerülje egy fájlból származó stílusszám hard‑kódolását és annak másik fájlban való azonos megjelenésével való feltételezését; a téma‑stílusdefiníciók prezentációnként eltérnek.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Közvetlen háttér‑formázáshoz és háttér‑öröklődéshez lásd a [Presentation Background](/slides/hu/nodejs-java/presentation-background/) oldalt.
{{% /alert %}}

## **Téma effektusok frissítése**

A téma formátumsémája különálló kitöltés‑, vonal‑ és effekt‑stílus‑gyűjteményeket tartalmaz, amelyeket a [FormatScheme.getFillStyles](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/formatscheme/) és [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/formatscheme/) tesz elérhetővé. A tipikus Office‑témák gyakran három fő stílusbejegyzést tartalmaznak, amelyek vizuálisan a finom, közepes és intenzív formázásnak felelnek meg, de a kódnak minden gyűjteményt ellenőriznie kell a rögzített szám feltételezése helyett.

![Finom, közepes és intenzív témaeffektusok egyforma alakzatra alkalmazva](presentation-design_10.png)

JavaScript‑ben a gyűjtemény indexelése nullával kezdődik: a `0`‑s index az első tárolt stílus, a `2`‑s index a harmadik. Egy alakzat stílus‑referencia indexei egy külön koncepció, amely a [ShapeStyle](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shapestyle/)‑ben érhető el. Egy téma‑stílus módosítása azokra az alakzatokra hat, amelyek arra a téma‑stílusra hivatkoznak; a közvetlen formázással rendelkező alakzatok változatlanul maradhatnak.

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

A példában ellenőrzi, hogy a szükséges stílusbejegyzések léteznek, módosítja az első vonal‑stílust, a harmadik kitöltés‑stílust, engedélyezi a külső árnyékot a harmadik effekt‑stílusban, és elmenti az eredményt.

Az ezekre a helyekre hivatkozó alakzatoknál az első téma‑vonal‑stílus piros lesz, a harmadik téma‑kitöltés‑stílus szilárd erdei zöld, a harmadik effekt‑stílus pedig egy 10 pont távolságú külső árnyékot kap. A pontos vizuális eredmény továbbra is attól függ, hogy az egyes alakzatok melyik stílushelyet hivatkozzák, és hogy a közvetlen formázás felülbírálja-e a témát.

![Téma effektus‑stílusok a vonal, kitöltés és árnyék beállítások módosítása után](presentation-design_11.png)

## **A tényleges témaértékek olvasása**

A nyers témaobjektumok azt mutatják, hogy mi van definiálva egy adott szinten. A tényleges értékek azt mutatják, hogy egy dia vagy alakzat valójában mit használ az öröklődés és a helyi felülbírálások feloldása után. Diára a [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseoverridethememanager/)-t hívja. Háttérhez a [Background.getEffective](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/background/)-t, kitöltéshez pedig a [FillFormat.getEffective](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fillformat/)-t használja.

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

A tényleges adatokat használja megjelenítési diagnosztikához, érvényesítéshez és összehasonlításokhoz. Ha csak a [Presentation.getMasterTheme](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/getmastertheme/)-t vizsgálja, kihagyhat egy master, layout, dia vagy alakzat felülbírálását, amely megváltoztatja a végső megjelenést.

## **GYIK**

**Alkalmazhatok egy témát egyetlen diára a master módosítása nélkül?**

Igen. Használja a dia [SlideThemeManager](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slidethememanager/)-ét, és inicializálja annak felülbíráló témáját. A változtatás csak arra a diára marad lokális; a többi dia a meglévő témáit örökli.

**Mi a legbiztonságosabb módja egy téma átvitelének egyik prezentációból a másikba?**

Diák áthelyezésekor és a forrás megjelenésének megőrzésekor klónozza a forrás master‑t a célba, majd a diát a klónozott masterrel a [MasterSlideCollection.addClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masterslidecollection/) és a [SlideCollection.addClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slidecollection/) segítségével. Ezzel a master, az elrendezések és a téma együtt kerülnek át.

**Hogyan tekinthetem meg a tényleges értékeket az öröklődés és felülbírálások után?**

Használja a [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseoverridethememanager/)-t egy dia vagy layout téma esetén, valamint a formátumobjektumok megfelelő tényleges‑adat‑metódusait, például a [Background.getEffective](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/background/) és a [FillFormat.getEffective](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fillformat/) hívásait. Ezek az API‑k a öröklődés és felülbírálások alkalmazása után feloldott értékeket adják vissza.