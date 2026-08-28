---
title: Prezentációs témák kezelése JavaScript-ben
linktitle: Prezentáció témája
type: docs
weight: 10
url: /hu/nodejs-java/presentation-theme/
keywords:
- PowerPoint téma
- prezentáció téma
- dia téma
- téma beállítása
- téma módosítása
- téma kezelése
- külső téma
- THMX
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
description: "Mestertémák kezelése JavaScript-ben az Aspose.Slides for Node.js segítségével PowerPoint fájlok létrehozásához, testreszabásához és konvertálásához következetes márkaépítéssel."
---
## **Bevezetés**

A prezentáció témája egy koordinált színek, betűtípusok, háttérstílusok, kitöltések, vonalak és effektusok halmazát határozza meg. A témaérzékeny objektumok ezekre a megosztott definíciókra hivatkoznak ahelyett, hogy minden vizuális tulajdonságot rögzített értékként tárolnának, így egy téma módosítása egyszerre sok objektumot frissíthet.

Az Aspose.Slides-ben a prezentációszintű téma elérhető a [Presentation.getMasterTheme](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/getmastertheme/) segítségével. A prezentáció alacsonyabb szinteken is tartalmazhat téma-átbírálásokat. Egy master a [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masterthememanager/) segítségével felülbírálhatja a prezentáció témáját, míg egy elrendezés vagy egy egyedi dia a [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseoverridethememanager/) segítségével felülbírálhatja a örökölt témát. Gyakorlatban egy dia hatékony témája ezen öröklési láncon keresztül kerül feloldásra: prezentációs téma, master felülbírálás, elrendezés felülbírálás és dia felülbírálás.

![Téma összetevői: színek, betűtípusok, háttérstílusok és effektusok](theme-constituents.png)

Az alábbi szakaszok a leggyakoribb téma-munkafolyamatokat mutatják be: téma ellenőrzése, színek és betűtípusok módosítása, téma másolása vagy alkalmazása, háttér- és effektusstílusok frissítése, valamint az öröklődés és felülbírálások után feloldott hatékony értékek olvasása.

## **Téma ellenőrzése**

A [MasterTheme](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/mastertheme/) objektum a téma színsémáját, betűtípus-sémáját és formátumsémáját a [MasterTheme.getColorScheme](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/mastertheme/) és [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/mastertheme/) segítségével teszi elérhetővé. Ezeknek a gyűjteményeknek a megtekintése a módosítás előtt különösen hasznos, ha a prezentáció külső forrásból származik, mivel a stílusbejegyzések száma és tartalma eltérő lehet.

Az alábbi példa beolvassa a fő téma tulajdonságait, és jelentést készít arról, hogy hány háttér-, kitöltés-, vonal- és effektusstílus van tárolva a témában:

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

Ha egy fájl több masterrel rendelkezik, ne feltételezze, hogy minden diának azonos hatékony témája van. Ellenőrizze a diával kapcsolatos mastert, és használja a később ebben a cikkben bemutatott hatékony téma-munkafolyamatot, ha elrendezési vagy diaszintű felülbírálások lehetnek jelen.

## **Téma színeinek módosítása**

A témaérzékeny kitöltések, vonalak és szöveg hivatkozhat egy logikai színre a [SchemeColor](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/schemecolor/) felsorolásból. Amikor a megfelelő bejegyzést módosítja a [ColorScheme](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/colorscheme/)-ben, minden továbbra is arra a téma színre hivatkozó objektum az új érték szerint kerül feloldásra. Azok az objektumok, amelyek közvetlen RGB-színt használnak, nem változnak meg a témaszín frissítésekor.

Az alábbi végponttól‑végpontig tartó példa létrehoz egy alakzatot, amely a `Accent4`‑et használja, a téma `Accent4` színét pirosra változtatja, menti a prezentációt, újra megnyitja, és kiírja a hatékony kitöltőszínt:

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

Mivel a téglalap továbbra is a `Accent4`‑hez van kapcsolva, a látható színe a téma módosítása után piros lesz. Ha a séma színt közvetlen színre cseréli az alakzaton, a későbbi `Accent4` módosítások már nem befolyásolják azt a kitöltést.

### **Színek használata a kiegészítő palettáról**

A PowerPoint a téma színéből alkalmazott színtranszformációk segítségével hoz létre világosabb és sötétebb változatokat. Az Aspose.Slides ezeket a transzformációkat a [ColorTransformOperation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/colortransformoperation/) felsorolással teszi elérhetővé.

![Fő téma színek és a kiegészítő palettából generált világosabb és sötétebb színek](additional-palette-colors.png)

**1** – Fő téma színek.  
**2** – A fő téma színekből előállított világosabb és sötétebb változatok.

Az alábbi példa hat téglalapot hoz létre a `Accent4` alapjául, ötön luminancia‑transzformációkat alkalmaz, és elmenti az eredményt:

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

### **`SchemeColor` értékek leképezése a `ColorScheme` helyekre**

A [SchemeColor](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/schemecolor/) felsorolás a `Text1`, `Background1`, `Text2` és `Background2` értékeket használja, míg a [ColorScheme](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/colorscheme/) ugyanazokat a témahelyeket `Dark1`, `Light1`, `Dark2` és `Light2` néven teszi közzé. A leképezés fix:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Ezek ugyanazon témahelyek alternatív nevei; nem dinamikusan átalakított értékek.

## **Téma betűtípusainak módosítása**

A téma betűtípus‑sémája egy fő betűtípus‑készletet tartalmaz a címsorokhoz és egy mellék betűtípus‑készletet a törzsszöveghez. A [FontScheme.getMajor](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontscheme/) és a [FontScheme.getMinor](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontscheme/) metódusok ezeket a készleteket teszik elérhetővé.

A PowerPoint‑kompatibilis téma betűtípus‑azonosítók a szövegformázásban használhatók:

* `+mn-lt` – Body Font Latin (Minor Latin Font)
* `+mj-lt` – Heading Font Latin (Major Latin Font)
* `+mn-ea` – Body Font East Asian (Minor East Asian Font)
* `+mj-ea` – Heading Font East Asian (Major East Asian Font)

Az alábbi példa létrehoz egy címsort, amely a fő latin téma betűtípust használja, és egy törzssort, amely a mellék latin téma betűtípust használja. Ezután megváltoztatja a téma betűtípusait, és elmenti az eredményt:

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

A címsor a fő betűtípust, a törzsszöveg a mellék betűtípust követi. Azok a szövegek, amelyek kifejezett betűtárgy nevet tartalmaznak a témaazonosító helyett, nem váltanak automatikusan, ha a téma betűtípus‑sémája megváltozik.

A fő és mellék betűtípus‑gyűjtemények tartalmazhatnak betűtárgy‑leképezéseket is egyedi írásrendszerekhez, például cirill, arab, japán, grúz és thaana. Ezeknek a leképezéseknek a megtekintéséhez, hozzáadásához, cseréjéhez vagy eltávolításához lásd a [Script‑Specific Theme Fonts](/slides/hu/nodejs-java/script-specific-font-mappings/) oldalt.

{{% alert color="info" title="Tip" %}}
További információk a prezentáció betűtípusaival kapcsolatban megtalálhatók a [PowerPoint Fonts](/slides/hu/nodejs-java/powerpoint-fonts/) oldalon.
{{% /alert %}}

## **Téma másolása vagy alkalmazása**

Az alábbi munkafolyamatok különböző téma‑kapcsolódó problémákat oldanak meg.

### **Külső téma alkalmazása egy mesterhez tartozó diákra**

Használja a [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masterslide/) metódust, ha egy PowerPoint témafájl (`.thmx`) áll rendelkezésre, és minden, az adott masterhez tartozó diát újra kíván stilizálni. Válassza ki a mastert a [Presentation.getMasters](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) gyűjteményből, amely a [MasterSlideCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masterslidecollection/) által képviselt, és adja át a témafájl útvonalát a metódusnak.

A metódus a következő műveleteket hajtja végre:

1. Létrehoz egy új masterdiát a kiválasztott master alapján.  
1. Alkalmazza a külső témát az új masterre.  
1. Hozzárendeli az új mastert minden diához, amely korábban a kiválasztott masterhez tartozott.  
1. Visszaadja a frissen létrehozott [MasterSlide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masterslide/)-t.

Az alábbi példa egy külső témát alkalmaz az első masterhez tartozó diákra, majd elmenti a prezentációt:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const selectedMaster = presentation.getMasters().get_Item(0);
    const themedMaster = selectedMaster.applyExternalThemeToDependingSlides("corporate-theme.thmx");

    console.log("Created master: " + themedMaster.getName());
    presentation.save("presentation-with-external-theme.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Érvénytelen, sérült vagy nem támogatott téma [PptxReadException](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pptxreadexception/)-et okozhat. Ellenőrizze a felhasználók által megadott útvonalakat, kezelje a fájlrendszer‑hozzáférési hibákat, és csak akkor mentse a prezentációt, ha a téma sikeresen alkalmazva lett.

Csak azok a diák, amelyek a kiválasztott masterhez tartoztak, kerülnek átrendelésre. A másik masterhez tartozó diákok megtartják meglévő masterüket és témájukat. A téma‑érzékeny színek, betűtípusok, kitöltések, vonalak, háttérstílusok és effektusok a külső témához lesznek feloldva. A közvetlenül hozzárendelt színek, betűtípusok, kitöltések és egyéb explicit formázások változatlanok maradhatnak. Az elrendezési és diaszintű felülbírálások szintén előnyben részesülhetnek az új mastertől örökölt értékekkel szemben.

A téma hivatkozhat olyan betűtípusokra, amelyek nincsenek jelen a futáskörnyezetben. A konzisztens megjelenítés és export érdekében telepítse a szükséges betűtípusokat, biztosítsa őket [egyedi betűforrások](/slides/hu/nodejs-java/custom-font/) segítségével, vagy konfigurálja a [betűtípus‑helyettesítést](/slides/hu/nodejs-java/font-substitution/).

Ez egy közvetlen master‑szintű munkafolyamat: a metódus egy `.thmx` fájl elérési útját fogadja, és nem igényel manuális létrehozást a diaszintű vagy elrendezési szintű téma‑átbírálásokhoz.

### **Különböző külső témák alkalmazása több‑masteres prezentációban**

Ha a releváns master előre nem ismert, szerezze be egy reprezentatív dia segítségével a [Slide.getLayoutSlide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slide/) és a [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutslide/) metódusokkal. Tárolja el az eredeti master‑referenciákat a témák alkalmazása előtt, mert minden hívás egy új mastert hoz létre a prezentációban.

Az alábbi példa két szekció diáit használja mastereik megtalálásához, és minden csoporthoz külön külső témát alkalmaz:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("multi-master-presentation.pptx");
try {
    if (presentation.getSlides().size() < 5) {
        console.log("The presentation does not contain the expected representative slides.");
    } else {
        const firstGroupMaster = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide();
        const secondGroupMaster = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide();

        if (firstGroupMaster.getSlideId() === secondGroupMaster.getSlideId()) {
            console.log("The representative slides use the same master.");
        } else {
            const firstThemedMaster = firstGroupMaster.applyExternalThemeToDependingSlides("blue-theme.thmx");
            const secondThemedMaster = secondGroupMaster.applyExternalThemeToDependingSlides("green-theme.thmx");

            console.log("First themed master: " + firstThemedMaster.getName());
            console.log("Second themed master: " + secondThemedMaster.getName());
            presentation.save("multi-master-with-external-themes.pptx", aspose.slides.SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

Az első hívás csak az `firstGroupMaster`‑hez tartozó diákra hat, a második hívás csak a `secondGroupMaster`‑hez tartozó diákra. A másik masterhez tartozó diákok nem kapnak új stílust.

### **Forrástéma megőrzése diák áthelyezésekor**

Ha egy diát egy másik prezentációba szeretne áthelyezni, miközben az eredeti megjelenését meg kívánja őrizni, klónozza a forrás‑mastert a célprezentációba a [MasterSlideCollection.addClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masterslidecollection/) segítségével, majd klónozza a diát a [SlideCollection.addClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slidecollection/) és a klónozott masterrel. Ez együtt viszi a mastert, annak elrendezéseit és a hozzá tartozó témát.

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

Ez a preferált munkafolyamat, amikor a forrásdia megjelenése pontosan ugyanolyannak kell maradjon a célhelyen. A tartalom egyszerű klónozása egy nem kapcsolódó cél‑masterre megváltoztathatja a téma‑vezérelt színeket, betűtípusokat, hátterelemeket és effektusokat.

### **Témaértékek alkalmazása meglévő diára**

Ha a cél‑dia a jelenlegi masteren és elrendezésen marad, inicializáljon egy diaszintű felülbírálást a forrástémából. A [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/overridetheme/) és [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/overridetheme/) metódusok másolják a három fő téma‑komponenst a felülbírálásba.

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

Ez megváltoztatja a dia által használt témát anélkül, hogy a többi dia örökölt témáját módosítaná. A helyi felülbírálás eltávolításához és az örökölt értékek visszaállításához hívja meg a [OverrideTheme.clear](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/overridetheme/)‑t.

### **Témafelülbírálás alkalmazása egy elrendezésre**

Az elrendezési szintű felülbírálás azokat a diákra vonatkozik, amelyek az adott elrendezést használják, kivéve ha egy konkrét dia saját felülbírálással rendelkezik. Ugyanezeket az inicializációs metódusokat használhatja a [LayoutSlideThemeManager](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutslidethememanager/) segítségével:

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

Használjon master‑ vagy prezentáció‑szintű témát, amikor sok elrendezésnek és diáknak közös alaptervet kell megosztania, elrendezési felülbírálást, amikor egy elrendezéscsaládnak eltérő stílusra van szüksége, és csak diákszintű felülbírálást a valódi kivételekhez. A túlzott diaszintű felülbírálások megnehezítik a későbbi globális téma‑változtatások előrejelzését.

## **Téma háttérstílusok frissítése**

A téma háttérkitöltései a [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/formatscheme/)‑ben vannak tárolva. A PowerPoint a felhasználói felületen több háttérválasztási lehetőséget jeleníthet meg, mint amennyi kitöltés‑definíció fizikailag tárolva van ebben a gyűjteményben, mert a felhasználói felület kombinálhat téma‑kitöltéseket témaszínek és egyéb stílus‑referenciákkal.

![PowerPoint háttérstílus galéria egy prezentáció témához](presentation-design_8.png)

Mielőtt háttérstílust használna, ellenőrizze a tárolt gyűjteményt és az aktuális [Background.getStyleIndex](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/background/)-et. A `0`‑ás stílusindex azt jelenti, hogy nincs témakötésű kitöltés; a pozitív értékek témaháttér‑stílus‑referenciák. Ez eltér attól, amikor a JavaScript‑gyűjteményt közvetlenül indexeli, ahol az `0` az első tárolt tételt jelöli. Ne feltételezze, hogy minden prezentáció ugyanannyi háttérkitöltés‑stílussal rendelkezik.

Az alábbi példa jelentést készít a rendelkezésre álló háttérkitöltések számáról, témakötésű háttér‑referenciát rendel az első masterhez, és elmenti a prezentációt:

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

A látható eredmény a master által hivatkozott téma‑bejegyzéstől és az elrendezési vagy diaszintű háttér‑felülbírálásoktól függ. Ha egy dia saját háttért használ, a csak a master háttér módosítása nem feltétlenül változtatja meg azt a diát. Használja a [Background.getEffective](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/background/)‑t, ha a végső háttérre van szüksége az öröklődés után.

{{% alert color="warning" title="Warning" %}}
Ne kezelje a stílusindexet nullától induló gyűjtemény‑indexként. Kerülje el egy fájlból származó stílus‑szám hard‑kódolását és annak feltételezését, hogy egy másik fájlban ugyanazt a megjelenést eredményezi; a téma‑stílusdefiníciók prezentációnként eltérőek.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
A közvetlen háttérformázáshoz és a háttér‑öröklődéshez lásd a [Presentation Background](/slides/hu/nodejs-java/presentation-background/) oldalt.
{{% /alert %}}

## **Téma effektusok frissítése**

A téma formátum‑sémája külön kitöltés‑, vonal‑ és effektus‑stílus‑gyűjteményeket tartalmaz, amelyeket a [FormatScheme.getFillStyles](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/formatscheme/) és [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/formatscheme/) tesznek elérhetővé. A tipikus Office‑témák gyakran három fő stílus‑bejegyzést tartalmaznak, amelyek vizuálisan a finom, közepes és intenzív formázásnak felelnek meg, de a kódnak minden gyűjteményt ellenőriznie kell ahelyett, hogy fix számot feltételezne.

![Finom, közepes és intenzív téma‑effektusok ugyanazon alakzaton alkalmazva](presentation-design_10.png)

JavaScript‑ben a gyűjtemény indexe nulla‑alapú: az `0` az első tárolt stílust jelöli, a `2` a harmadikat. Egy alakzat stílus‑referencia‑indexei egy külön koncepció, amelyet a [ShapeStyle](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shapestyle/) tesz elérhetővé. Egy téma‑stílus módosítása azokra az alakzatokra hat, amelyek arra a téma‑stílusra hivatkoznak; a közvetlen formázással ellátott alakzatok változatlanok maradhatnak.

Az alábbi példa ellenőrzi, hogy a szükséges stílus‑bejegyzések léteznek, megváltoztatja az első vonal‑stílust, a harmadik kitöltés‑stílust, engedélyezi a külső árnyékot a harmadik effektus‑stílusban, majd elmenti az eredményt:

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

Az ezekre a helyekre hivatkozó alakzatok esetén az első téma‑vonal‑stílus piros, a harmadik téma‑kitöltés‑stílus szilárd erdőzöld, és a harmadik effektus‑stílus egy `10` pont távolságú külső árnyékot kap. A pontos vizuális eredmény továbbra is attól függ, hogy melyik stílus‑helyre hivatkozik az egyes alakzat, és hogy a közvetlen formázás felülbírálja-e a témát.

![Téma‑effektus‑stílusok módosítás után: vonal, kitöltés és árnyék beállítások](presentation-design_11.png)

## **Megállapítás, hogy egy hatékony szilárd kitöltés témaszínt használ-e**

Egy kitöltés tárolható közvetlenül egy objektumon vagy örökölhető bekezdésből, elrendezésből, masterből, téma‑stílusból vagy egyéb formázási szintről. Hívja meg a [FillFormat.getEffective](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fillformat/)‑t, hogy a hierarchiát egy változhatatlan hatékony‑kitöltés pillanatképpé alakítsa. Először ellenőrizze a `getFillType` értékét. Csak akkor olvassa a szilárd‑kitöltés tulajdonságait, ha az `FillType.Solid`.

Szilárd kitöltés esetén a `getSolidFillColor` a végleges megjelenített RGB‑értéket adja vissza, miután az öröklődés, a téma‑keresés és a színtranszformációk alkalmazásra kerültek. A `getSolidFillSchemeColor` metódus a megfelelő logikai [SchemeColor](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/schemecolor/) helyet adja vissza, például `Text1` vagy `Accent6`. A `SchemeColor.NotDefined` érték azt jelenti, hogy a hatékony szilárd kitöltés nem egy séma‑színen alapul. Egy olyan munkafolyamatban, ahol a kitöltések csak téma‑színek vagy közvetlen RGB‑színek lehetnek, ez az érték egy közvetlen RGB‑kitöltést azonosít.

Ne csak a helyi [ColorFormat.getSchemeColor](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/colorformat/) értéket használja a kitöltés osztályozásához. Például egy szövegrésznek lehet, hogy nincs helyi séma‑színe (`NotDefined`), miközben a hatékony kitöltés örököl egy téma‑színt, és `Text1` vagy `Accent6`‑ra oldódik. Ezzel ellentétben a `getSolidFillSchemeColor` megmondja, mely logikai téma‑hely hozta létre a hatékony színt, de nem közli, hogy az a hely az objektumból, bekezdésből, elrendezésből, masterből vagy egy másik szintből származik.

Az alábbi példa betölti a prezentációt, auditálja az alakzat‑ és szövegrész‑kitöltéseket, kiírja minden végleges RGB‑értéket és a hozzá rendelt séma‑színt, valamint jelzi azokat a szilárd kitöltéseket, amelyek nem követik a téma‑szín változásait:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function toHexColor(color) {
    const red = color.getRed().toString(16).padStart(2, "0");
    const green = color.getGreen().toString(16).padStart(2, "0");
    const blue = color.getBlue().toString(16).padStart(2, "0");
    return `#${red}${green}${blue}`.toUpperCase();
}

function auditFill(objectName, localFill) {
    const effectiveFill = localFill.getEffective();

    if (effectiveFill.getFillType() !== aspose.slides.FillType.Solid) {
        console.log(objectName + ": fill type = " + effectiveFill.getFillType() + "; not a solid fill.");
        return;
    }

    const rgb = effectiveFill.getSolidFillColor();
    const effectiveSchemeColor = effectiveFill.getSolidFillSchemeColor();
    const localSchemeColor = localFill.getSolidFillColor().getSchemeColor();

    console.log(objectName + ": RGB = " + toHexColor(rgb));
    console.log(objectName + ": local scheme = " + localSchemeColor + ", effective scheme = " + effectiveSchemeColor);

    if (effectiveSchemeColor === aspose.slides.SchemeColor.NotDefined) {
        console.log(objectName + ": direct RGB or another non-scheme fill; audit as theme-independent.");
    } else {
        console.log(objectName + ": theme-dependent through " + effectiveSchemeColor + ".");
    }
}

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);

        const shapeCount = slide.getShapes().size();
        for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            const shapeName = "Slide " + (slideIndex + 1) + ", shape " + (shapeIndex + 1);
            auditFill(shapeName, shape.getFillFormat());

            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const paragraphCount = shape.getTextFrame().getParagraphs().getCount();
                for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                    const paragraph = shape.getTextFrame().getParagraphs().get_Item(paragraphIndex);

                    const portionCount = paragraph.getPortions().getCount();
                    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                        const portion = paragraph.getPortions().get_Item(portionIndex);
                        const portionName = shapeName + ", paragraph " + (paragraphIndex + 1) + ", portion " + (portionIndex + 1);
                        auditFill(portionName, portion.getPortionFormat().getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

A `NotDefined` ág egy auditlistát ad a szilárd kitöltésekről, amelyek nem reagálnak a téma‑szín slotok változására. Ezeket az objektumokat ellenőrizze, amikor egy prezentációnak egy új márka‑palettát kell követnie. A jelentett RGB‑érték továbbra is a jelenlegi megjelenést mutatja, míg a séma‑érték magyarázza, hogy ez a megjelenés kapcsolódik‑e a témához.

A hatékony‑formátum objektumok pillanatképek. Miután a prezentáció témáját, egy téma‑átbírálást vagy bármely örökölt formázást módosította, hívja meg újra a `getEffective`‑et, és olvassa ki az új hatékony‑kitöltés objektumot, mielőtt összehasonlítaná vagy jelentést készítene a színekről.

## **Hatékony témaértékek olvasása**

A nyers témaobjektumok megmutatják, mi van definiálva egy adott szinten. A hatékony értékek megmutatják, mit használ valójában egy dia vagy alakzat az öröklődés és a helyi felülbírálások feloldása után. Egy dia esetén hívja meg a [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseoverridethememanager/)-t. Háttér esetén használja a [Background.getEffective](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/background/)-t, kitöltés esetén a [FillFormat.getEffective](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fillformat/)-t.

Az alábbi példa beolvassa a hatékony témát, háttér‑stílust és az első alakzat kitöltését egy diáról:

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

Használja a hatékony adatokat megjelenítési diagnosztikához, validáláshoz és összehasonlításokhoz. Ha csak a [Presentation.getMasterTheme](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/getmastertheme/)‑t ellenőrzi, előfordulhat, hogy egy master, elrendezés, dia vagy alakzat felülbírálásait kihagyja, amelyek megváltoztatják a végső megjelenést.

## **GYIK**

**A külső téma alkalmazása minden diára hat a prezentációban?**

Nem. A [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masterslide/) csak azokat a diákat rendeli újra, amelyek a kiválasztott masterhez tartoztak. A másik masterrel rendelkező diák megőrzik meglévő témájukat.

**Alkalmazhatok témát egyetlen diára a master módosítása nélkül?**

Igen. Használja a dia [SlideThemeManager](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slidethememanager/)‑ét, és inicializálja a felülbírálási témáját. A változás csak arra a diára vonatkozik; a többi dia továbbra is a meglévő témáiból örököl.

**Mi a legbiztonságosabb módja egy téma átvitelének egyik prezentációból a másikba?**

Amikor egy diát áthelyez és meg akarja őrizni a forrás megjelenését, klónozza a forrás‑mastert a célba, majd a diát a [MasterSlideCollection.addClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masterslidecollection/) és a [SlideCollection.addClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slidecollection/) segítségével. Ez a mastert, az elrendezéseket és a témát együtt tartja.

**Hogyan tekinthetem meg a hatékony értékeket az öröklődés és felülbírálások után?**

Használja a [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseoverridethememanager/)‑t egy dia vagy elrendezés téma esetén, valamint a megfelelő hatékony‑adat metódusokat formátumobjektumokhoz, mint a [Background.getEffective](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/background/) és a [FillFormat.getEffective](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fillformat/). Ezek az API‑k a hierarchiák feloldása után visszaadják a feloldott értékeket.