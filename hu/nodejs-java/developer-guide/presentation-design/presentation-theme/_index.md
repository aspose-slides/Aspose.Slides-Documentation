---
title: "Prezentációs témák kezelése JavaScriptben"
linktitle: "Prezentációs téma"
type: docs
weight: 10
url: /hu/nodejs-java/presentation-theme/
keywords:
- "PowerPoint téma"
- "prezentációs téma"
- "dia téma"
- "téma beállítása"
- "téma módosítása"
- "téma kezelése"
- "külső téma"
- THMX
- "téma szín"
- "kiegészítő paletta"
- "téma betűtípus"
- "téma stílus"
- "téma effekt"
- PowerPoint
- OpenDocument
- "prezentáció"
- Node.js
- JavaScript
- Aspose.Slides
description: "Mester prezentációs témák JavaScriptben az Aspose.Slides for Node.js segítségével PowerPoint fájlok létrehozásához, testreszabásához és konvertálásához egységes márkázással."
---
## **Bevezetés**

Egy prezentációs téma meghatároz egy összehangolt színek, betűtípusok, háttérstílusok, kitöltések, vonalak és effektek halmazát. A témaérzékeny objektumok ezekre a megosztott definíciókra hivatkoznak ahelyett, hogy minden vizuális tulajdonságot rögzített értékként tárolnának, így egy téma változtatása egyszerre frissítheti a sok objektumot.

Az Aspose.Slides-ben a prezentáció szintű téma a [Presentation.getMasterTheme](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/getmastertheme/) segítségével érhető el. A prezentáció alacsonyabb szinteken is tartalmazhat téma‑felülírásokat. Egy mester felülírhatja a prezentáció témát a [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masterthememanager/) segítségével, míg egy elrendezés vagy egy egyedi dia felülírhatja az örökölt témát a [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseoverridethememanager/) segítségével. Gyakorlatban egy dia hatékony témája ezen öröklődési lánc szerint kerül feloldásra: prezentációs téma, mester‑felülírás, elrendezés‑felülírás és dia‑felülírás.

![Témaelemek: színek, betűtípusok, háttérstílusok és effektek](theme-constituents.png)

Az alábbi szakaszok bemutatják a leggyakoribb téma‑munkafolyamatokat: téma vizsgálata, színek és betűtípusok módosítása, téma másolása vagy alkalmazása, háttér‑ és effektstílusok frissítése, valamint a hatékony értékek kiolvasása az öröklődés és felülírások feloldása után.

## **Téma vizsgálata**

A [MasterTheme](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/mastertheme/) objektum a téma színsémáját, betűtípus‑sémáját és formátum‑sémáját teszi elérhetővé a [MasterTheme.getColorScheme](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/mastertheme/), a [MasterTheme.getFontScheme](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/mastertheme/) és a [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/mastertheme/) módszereken keresztül. Ezeknek a gyűjteményeknek a vizsgálata különösen hasznos, ha egy prezentáció külső forrásból származik, mivel a stílusbejegyzések száma és tartalma változhat.

Az alábbi példa beolvassa a fő téma‑tulajdonságokat, és jelentést készít arról, hogy hány háttér-, kitöltés‑, vonal‑ és effektstílus van tárolva a témában:

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

Ha egy fájl több mestert használ, ne feltételezze, hogy minden dia ugyanazzal a hatékony témával rendelkezik. Vizsgálja meg a diával kapcsolatos mestert, és használja a későbbiekben bemutatott hatékony‑téma munkafolyamatot, amikor elrendezés‑ vagy dia‑felülírások jelenhetnek meg.

## **Téma színeinek módosítása**

A témaérzékeny kitöltések, vonalak és szövegek a [SchemeColor](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/schemecolor/) felsorolás logikai színére hivatkozhatnak. Amikor módosítja a megfelelő bejegyzést a [ColorScheme](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/colorscheme/) gyűjteményben, minden még mindig a téma‑színre hivatkozó objektum az új értékkel lesz feloldva. A közvetlen RGB‑színt használó objektumok nem változnak meg a téma‑szín frissítésekor.

Az alábbi vég‑végi példa egy `Accent4` színt használó alakzatot hoz létre, megváltoztatja a téma `Accent4` színét pirosra, elmenti a prezentációt, újra megnyitja, és kiírja a hatékony kitöltőszínt:

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

Mivel a téglalap továbbra is a `Accent4`-hez van kapcsolva, látható színe piros lesz a téma módosítása után. Ha a sémaszínt közvetlen színre cseréli az alakzaton, a későbbi `Accent4` változások már nem befolyásolják azt a kitöltést.

### **A kiegészítő palettáról származó színek használata**

A PowerPoint egy téma‑színből világosabb és sötétebb variánsokat hoz létre színtranszformációk alkalmazásával. Az Aspose.Slides ezeket a transzformációkat a [ColorTransformOperation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/colortransformoperation/) felsoroláson keresztül teszi elérhetővé.

![Fő téma színek és a kiegészítő palettából generált világosabb és sötétebb színek](additional-palette-colors.png)

**1** – Fő téma színek.  
**2** – A fő téma színekből előállított világosabb és sötétebb variánsok.

Az alábbi példa hat téglalapot hoz létre `Accent4` alapján, ötödiket luminancia‑transzformációval módosítja, majd elmenti az eredményt:

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

Ezek a variánsok továbbra is a téma‑színen alapulnak. Ha a `Accent4` később változik, a transzformált színek újra lesznek számítva az új `Accent4` értékből.

### **A `SchemeColor` értékek leképezése a `ColorScheme` helyekre**

A [SchemeColor](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/schemecolor/) felsorolás a `Text1`, `Background1`, `Text2` és `Background2` értékeket használja, míg a [ColorScheme](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/colorscheme/) ugyanazokat a téma‑helyeket `Dark1`, `Light1`, `Dark2` és `Light2` néven teszi közzé. A leképezés rögzített:

* `Text1` = `Dark1`  
* `Background1` = `Light1`  
* `Text2` = `Dark2`  
* `Background2` = `Light2`

Ezek ugyanazon téma‑helyek alternatív nevei; nem dinamikusan konvertált értékek egymásból.

## **Téma betűtípusainak módosítása**

A téma betűtípus‑sémája egy fő betűkészletet tartalmaz a címsorokhoz és egy mellék betűkészletet a törzsszöveghez. A [FontScheme.getMajor](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontscheme/) és a [FontScheme.getMinor](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontscheme/) metódusok teszik elérhetővé ezeket a készleteket.

PowerPoint‑kompatibilis téma‑betűtípus azonosítók használhatók a szövegformázásban:

* `+mn-lt` – Body Font Latin (Minor Latin Font)  
* `+mj-lt` – Heading Font Latin (Major Latin Font)  
* `+mn-ea` – Body Font East Asian (Minor East Asian Font)  
* `+mj-ea` – Heading Font East Asian (Major East Asian Font)

Az alábbi példa egy címsort hoz létre, amely a fő Latin téma‑betűtípust használ, és egy törzssort, amely a mellék Latin téma‑betűtípust használ. Ezután megváltoztatja a téma betűtípusait és elmenti az eredményt:

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

A címsor a fő betűtípust, a törzsszöveg a mellék betűtípust követi. Az explicit betűtípust megnevező szöveg nem vált automatikusan át, ha a téma betűtípus‑sémája változik.

A fő és mellék betűkészletek tartalmazhatnak betűtérképeket egyedi írásrendszerekhez, például cirill, arab, japán, grúz és thaana. Ezek vizsgálatához, hozzáadásához, cseréjéhez vagy eltávolításához lásd a [Script‑Specific Theme Fonts](/slides/hu/nodejs-java/script-specific-font-mappings/) oldalt.

{{% alert color="info" title="Tip" %}}
További információk a prezentáció betűtípusaival kapcsolatban a [PowerPoint Fonts](/slides/hu/nodejs-java/powerpoint-fonts/) oldalon találhatók.
{{% /alert %}}

## **Téma másolása vagy alkalmazása**

Az alábbi munkafolyamatok különböző téma‑problémákat oldanak meg.

### **Külső téma alkalmazása egy mesterhez kapcsolódó diákra**

Használja a [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masterslide/) metódust, ha van egy PowerPoint téma fájlja (`.thmx`), és minden, egy adott mesterhez kapcsolódó diát újra szeretne formázni. Válassza ki a mestert a [Presentation.getMasters](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) gyűjteményből, amelyet a [MasterSlideCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masterslidecollection/) képvisel, majd adja át a témafájl útvonalát a metódusnak.

A metódus a következő műveleteket hajtja végre:

1. Létrehoz egy új mesterdiát a kiválasztott mester alapján.  
1. Alkalmazza a külső témát az új mesterre.  
1. A kiválasztott mesterre korábban támaszkodó összes diára átadja az új mestert.  
1. Visszaadja a frissen létrehozott [MasterSlide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masterslide/)-t.

Az alábbi példa egy külső témát alkalmaz az első mesterhez tartozó diákra, és elmenti a prezentációt:

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

Érvénytelen, sérült vagy nem támogatott téma [PptxReadException](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pptxreadexception/)-t okozhat. Ellenőrizze a felhasználók által megadott útvonalakat, kezelje a fájlrendszer‑hozzáférési hibákat, és csak a téma sikeres alkalmazása után mentse a prezentációt.

Csak a kiválasztott mesterre támaszkodó diákok kerülnek átrendelésre. Más mesterekhez tartozó diák megtartják meglévő mestereiket és témáikat. A témaérzékeny színek, betűtípusok, kitöltések, vonalak, háttérstílusok és effektek a külső téma alapján kerülnek feloldásra. A közvetlenül hozzárendelt színek, betűtípusok, kitöltések és egyéb explicit formázások változatlanul maradhatnak. Az elrendezés‑szintű és dia‑szintű felülírások szintén felülírhatják az új mesterből örökölt értékeket.

A téma olyan betűtípusokra is hivatkozhat, amelyek nincsenek a futási környezetben. A konzisztens megjelenítés és export érdekében telepítse a szükséges betűtípusokat, biztosítsa őket a [custom font sources](/slides/hu/nodejs-java/custom-font/) segítségével, vagy konfigurálja a [font substitution](/slides/hu/nodejs-java/font-substitution/) beállítást.

Ez egy közvetlen mester‑szintű munkafolyamat: a metódus egy `.thmx` fájl elérési útját várja, és nem igényel manuális dia‑ vagy elrendezés‑szintű téma‑felülírások létrehozását.

### **Különböző külső témák alkalmazása többlevelő prezentációban**

Ha a megfelelő mester nincs előre tudva, szerezze be egy reprezentatív dia segítségével a [Slide.getLayoutSlide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slide/) és a [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutslide/) hívásokkal. Tárolja el az eredeti mesterhivatkozásokat, mielőtt bármilyen témát alkalmazna, mivel minden hívás egy új mestert hoz létre a prezentációban.

Az alábbi példa két szakaszból származó diák mestereit keresi meg, és mindegyik csoporthoz egy külön külső témát alkalmaz:

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

Az első hívás csak az `firstGroupMaster`‑re támaszkodó diákra hat, a második csak a `secondGroupMaster`‑re. Más mesterekhez tartozó diákok nem kapnak új formázást.

### **Forrástéma megőrzése diák áthelyezésekor**

Ha egy diát egy másik prezentációba szeretne áthelyezni, és meg akarja őrizni az eredeti megjelenését, klónozza a forrás‑mestert a célprezentációba a [MasterSlideCollection.addClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masterslidecollection/) segítségével, majd klónozza a diát a [SlideCollection.addClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slidecollection/) és a klónozott mesterrel. Így a mester, az elrendezései és a hozzá tartozó téma együtt kerülnek át.

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

Ez a preferált munkafolyamat, ha a forrásdia meg kell, hogy maradjon ugyanúgy a célban. Egy nem kapcsolódó cél‑mesterre történő egyszerű klónozás megváltoztathatja a téma‑vezérelt színeket, betűtípusokat, háttérstílusokat és effekteket.

### **Témaértékek alkalmazása egy meglévő diára**

Ha a cél‑dia a saját mesterén és elrendezésén kell maradjon, inicializáljon egy dia‑szintű felülírást a forrástémából. Az [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/overridetheme/), az [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/overridetheme/) és az [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/overridetheme/) metódusok lemásolják a három fő téma‑komponenst a felülírásba.

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

Ez a dia témáját módosítja anélkül, hogy a többi dia örökölt témája megváltozna. A helyi felülírás eltávolításához és az örökölt értékek visszaállításához hívja meg az [OverrideTheme.clear](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/overridetheme/) metódust.

### **Téma felülírásának alkalmazása egy elrendezésre**

Az elrendezés‑szintű felülírás az arra épülő diákra vonatkozik, hacsak egy adott dia nem rendelkezik saját felülírással. Ugyanezeket az inicializáló metódusokat a [LayoutSlideThemeManager](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutslidethememanager/) segítségével is használhatja:

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

Használjon mester‑ vagy prezentáció‑szintű témát, ha sok elrendezésnek és diáknak ugyanazt az alap‑designt kell megosztania, elrendezés‑felülírást, ha egy elrendezés‑családnak különböző stílusra van szüksége, és dia‑felülírást csak valódi kivételekhez. A túlzott dia‑szintű felülírások megnehezítik a későbbi globális téma‑változások előrejelzését.

## **Téma háttérstílusok frissítése**

A téma háttér‑kitöltései a [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/formatscheme/)‑ben vannak tárolva. A PowerPoint a felhasználói felületén több háttér‑választási lehetőséget jeleníthet meg, mint amennyi kitöltés‑definíció fizikailag tárolva van ebben a gyűjteményben, mivel a UI a téma‑kitöltéseket kombinálhatja a téma‑színekkel és egyéb stílus‑hivatkozásokkal.

![PowerPoint háttérstílus galéria egy prezentációtémához](presentation-design_8.png)

A háttérstílus használata előtt vizsgálja meg a tárolt gyűjteményt és az aktuális [Background.getStyleIndex](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/background/) értéket. A `0`‑s index azt jelenti, hogy nincs téma‑kitöltés; a pozitív értékek téma háttér‑stílus‑hivatkozások. Ez eltér a JavaScript‑gyűjtemény közvetlen indexelésétől, ahol a `0` az első tárolt elemet jelenti. Ne feltételezze, hogy minden prezentáció ugyanannyi háttér‑kitöltés‑stílussal rendelkezik.

Az alábbi példa jelenti a rendelkezésre álló háttér‑kitöltések számát, egy téma‑háttér‑hivatkozást rendeli az első mesterhez, majd elmenti a prezentációt:

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

A látható eredmény a mester által hivatkozott téma‑bejegyzéstől, valamint az elrendezés‑ vagy dia‑szintű háttér‑felülírásoktól függ. Ha egy dia saját hátteret használ, a csak a mesterháttér módosítása nem feltétlenül változtatja meg azt a diát. Használja a [Background.getEffective](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/background/)‑t, ha a teljes örökölt háttér ismeretére van szüksége.

{{% alert color="warning" title="Warning" %}}
Ne kezelje a stílus‑indexet null‑alapú gyűjtemény‑indexként. Kerülje a fájlok közötti állandó stílusszámok használatát, mivel a téma‑stílus definíciók prezentációnként eltérnek.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
A közvetlen háttér‑formázáshoz és a háttér‑öröklődéshez lásd a [Presentation Background](/slides/hu/nodejs-java/presentation-background/) oldalt.
{{% /alert %}}

## **Téma effektek frissítése**

A téma formátum‑sémája külön kitöltés, vonal és effekt stílusgyűjteményeket tartalmaz, amelyeket a [FormatScheme.getFillStyles](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/formatscheme/), a [FormatScheme.getLineStyles](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/formatscheme/) és a [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/formatscheme/) metódusok exponálnak. A tipikus Office‑témák gyakran három fő stílus‑bejegyzést tartalmaznak, amelyek vizuálisan a finom, közepes és intenzív formázásnak felelnek meg, de a kódnak minden gyűjteményt ellenőriznie kell a fix szám feltételezése helyett.

![Finom, közepes és intenzív téma‑effektek ugyanazon alakzatra alkalmazva](presentation-design_10.png)

JavaScript‑ben ezekhez a gyűjteményekhez való hozzáféréskor a gyűjtemény‑index null‑alapú: a `0`‑s index az első tárolt stílus, a `2`‑s index a harmadik. A forma‑stílus‑referencia indexek egy külön koncepciót képeznek, amelyet a [ShapeStyle](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shapestyle/) tesz elérhetővé. Egy téma‑stílus módosítása az arra hivatkozó formákat érinti; a közvetlen formázást használó formák változatlanok maradhatnak.

Az alábbi példa ellenőrzi, hogy a szükséges stílus‑bejegyzések léteznek, módosítja az első vonal‑stílust, a harmadik kitöltés‑stílust, engedélyezi a külső árnyékot a harmadik effekt‑stílusban, majd elmenti az eredményt:

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

A releváns slotokra hivatkozó formák esetén az első téma‑vonal‑stílus piros lesz, a harmadik téma‑kitöltés‑stílus szilárd erdőzöld, a harmadik effekt‑stílus pedig külső árnyékot kap 10 pont távolsággal. A pontos vizuális eredmény még mindig attól függ, hogy melyik slotot hivatkozza az adott forma, és hogy a közvetlen formázás felülírja‑e a témát.

![Téma‑effekt‑stílusok módosítás után: vonal, kitöltés és árnyék beállítások](presentation-design_11.png)

## **Hatékony témaértékek kiolvasása**

A nyers témaobjektumok azt mutatják, hogy mi van definiálva egy adott szinten. A hatékony értékek azt mutatják, hogy egy dia vagy alakzat valójában mit használ az öröklődés és a helyi felülírások feloldása után. Egy diára a [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseoverridethememanager/) hívást kell alkalmazni. Egy háttérre a [Background.getEffective](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/background/), egy kitöltésre pedig a [FillFormat.getEffective](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fillformat/) metódusokat.

Az alábbi példa kiolvassa a hatékony témát, a háttért és az első forma kitöltését egy diához:

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

Használja a hatékony adatokat a megjelenítési diagnosztikához, validációhoz és összehasonlításokhoz. Ha csak a [Presentation.getMasterTheme](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/getmastertheme/)‑t vizsgálja, könnyen kihagyhat egy mester‑, elrendezés‑, dia‑ vagy forma‑felülírást, amely megváltoztatja a végső megjelenést.

## **GYIK**

**Befolyásolja egy külső téma alkalmazása a prezentáció minden diáját?**

Nem. A [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masterslide/) csak a kiválasztott mesterre támaszkodó diákra alkalmaz új témát. A más mesterekhez tartozó diákok megtartják meglévő témáikat.

**Alkalmazhatok-e egy témát egyetlen diára a mester módosítása nélkül?**

Igen. Használja a dia [SlideThemeManager](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slidethememanager/)‑jét, és inicializálja annak felülírás témáját. A változtatás csak arra a diára lesz lokális; a többi dia a meglévő témáit örökli továbbra is.

**Mi a legbiztonságosabb módja egy téma átvitelének egy prezentációból a másikba?**

Diák áthelyezésekor és az eredeti megjelenés megőrzése érdekében klónozza a forrás‑mestert a célba, majd klónozza a diát azzal a mesterrel a [MasterSlideCollection.addClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masterslidecollection/) és a [SlideCollection.addClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slidecollection/) segítségével. Így a mester, az elrendezések és a téma együtt marad.

**Hogyan tekinthetem meg a hatékony értékeket az öröklődés és a felülírások után?**

Használja a [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseoverridethememanager/)‑t egy dia vagy elrendezés témájához, valamint a megfelelő hatékony‑adat metódusokat a formátumobjektumokhoz, például a [Background.getEffective](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/background/) és a [FillFormat.getEffective](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fillformat/) metódusokat. Ezek az API‑k a öröklődés és felülírások alkalmazása után feloldott értékeket adják vissza.