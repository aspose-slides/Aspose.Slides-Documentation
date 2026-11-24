---
title: Prezentációs témák kezelése JavaScript-ben
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
description: "Kezelje a prezentációs témákat JavaScript-ben az Aspose.Slides for Node.js segítségével, hogy konzisztens márkázással hozzon létre, testreszabjon és konvertáljon PowerPoint fájlokat."
---
## **Bevezetés**

Az előadás téma egy koordinált szín-, betűtípus-, háttérstílus-, kitöltés-, vonal- és effektkészletet határoz meg. A témaérzékeny objektumok ezekre a megosztott definíciókra hivatkoznak ahelyett, hogy minden vizuális tulajdonságot fix értékként tárolnának, így egy téma módosítása egyszerre frissítheti a számos objektumot.

Az Aspose.Slides-ban a prezentáció szintű téma a [Presentation.getMasterTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getmastertheme/) segítségével érhető el. Egy prezentáció alacsonyabb szinteken is tartalmazhat téma felülírásokat. A master felülírhatja a prezentáció témáját a [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterthememanager/) segítségével, míg egy elrendezés vagy egy egyedi dia felülírhatja a örökölt témát a [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseoverridethememanager/) segítségével. Gyakorlatban a dia hatékony témáját ez az öröklődési lánc határozza meg: prezentáció téma, master felülírás, elrendezés felülírás és dia felülírás.

![Téma összetevők: színek, betűtípusok, háttérstílusok és effektek](theme-constituents.png)

Az alábbi szakaszok bemutatják a leggyakoribb téma munkafolyamatokat: téma vizsgálata, színek és betűtípusok módosítása, téma másolása vagy alkalmazása, háttér- és effektstílusok frissítése, valamint a hatékony értékek kiolvasása az öröklődés és a felülírások feloldása után.

## **Téma vizsgálata**

A [MasterTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mastertheme/) objektum a téma színsémáját, betűtípus-sémáját és formátumsémáját teszi elérhetővé a [MasterTheme.getColorScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mastertheme/), a [MasterTheme.getFontScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mastertheme/) és a [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mastertheme/) segítségével. Ezeknek a gyűjteményeknek a vizsgálata a módosítások előtt különösen hasznos, ha egy prezentáció külső forrásból származik, mivel a stílusbejegyzések száma és tartalma változhat.

A következő példa beolvassa a fő téma tulajdonságait, és jelentést készít arról, hogy hány háttér-, kitöltés-, vonal- és effektstílus van eltárolva a témában:

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

Ha egy fájl több masterrel dolgozik, ne feltételezd, hogy minden dia ugyanazzal a hatékony témával rendelkezik. Vizsgáld meg a diához tartozó mastert, és használd a később ebben a cikkben bemutatott hatékony téma munkafolyamatot, amikor elrendezés vagy dia felülírások lehetnek jelen.

## **Téma színeinek módosítása**

A témaérzékeny kitöltések, vonalak és szöveg hivatkozhat egy logikai színre a [SchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/schemecolor/) felsorolásból. Amikor módosítod a megfelelő bejegyzést a [ColorScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorscheme/)ban, az összes, még mindig az adott téma színre hivatkozó objektum az új értékhez lesz feloldva. Azok az objektumok, amelyek közvetlen RGB színt használnak, nem változnak meg egy témaszín-frissítéskor.

A következő végponttól végpontig tartó példa egy olyan alakzatot hoz létre, amely a `Accent4` színt használja, megváltoztatja a téma `Accent4` színét pirosra, elmenti a prezentációt, újra megnyitja, és kiírja a hatékony kitöltő színt:

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

Mivel a téglalap továbbra is a `Accent4`-hez van kapcsolva, látható színe pirossá válik a téma módosítása után. Ha a szerkesztett színt közvetlen színre cseréled az alakzaton, a későbbi `Accent4` változások már nem befolyásolják azt a kitöltést.

### **Színek használata a kiegészítő palettáról**

A PowerPoint a témaszínből világosabb és sötétebb variánsokat származtat színtranszformációk alkalmazásával. Az Aspose.Slides ezeket a transzformációkat a [ColorTransformOperation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colortransformoperation/) felsorolásban teszi elérhetővé.

![A fő téma színek és a kiegészítő palettáról generált világosabb és sötétebb színek](additional-palette-colors.png)

**1** - A fő téma színek.

**2** - A fő téma színekből előállított világosabb és sötétebb variánsok.

A következő példa hat téglalapot hoz létre a `Accent4` alapján, ötödikre luminancia transzformációkat alkalmaz, és elmenti az eredményt:

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

Ezek a variánsok a témaszín alapján maradnak. Ha a `Accent4` később megváltozik, a transzformált színek újraszámítódnak az új `Accent4` értékkel.

### **`SchemeColor` értékek leképezése a `ColorScheme` helyekre**

A [SchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/schemecolor/) felsorolás a `Text1`, `Background1`, `Text2` és `Background2` értékeket használja, míg a [ColorScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorscheme/) ugyanazokat a témahelyeket `Dark1`, `Light1`, `Dark2` és `Light2` néven teszi közzé. A leképezés rögzített:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Ezek a ugyanazon témahelyek alternatív nevei; nem olyan értékek, amelyeket dinamikusan konvertálnak az egyik formából a másikba.

## **Téma betűtípusainak módosítása**

A téma betűtípus-séma egy fő betűkészletet tartalmaz a címsorokhoz és egy kisebb betűkészletet a törzsszöveghez. A [FontScheme.getMajor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontscheme/) és a [FontScheme.getMinor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontscheme/) metódusok teszik ezeket a készleteket elérhetővé.

A PowerPoint-kompatibilis téma betűtípus-azonosítók használhatók a szövegformázásban:

* `+mn-lt` - Törzsszöveg betűtípus Latin (Kisebb Latin betűtípus)
* `+mj-lt` - Címsor betűtípus Latin (Fő Latin betűtípus)
* `+mn-ea` - Törzsszöveg betűtípus Kelet-Ázsiai (Kisebb Kelet-Ázsiai betűtípus)
* `+mj-ea` - Címsor betűtípus Kelet-Ázsiai (Fő Kelet-Ázsiai betűtípus)
* `+mn-cs` - Törzsszöveg betűtípus Bonyolult írásrendszer (Kisebb Bonyolult írásrendszer betűtípus)
* `+mj-cs` - Címsor betűtípus Bonyolult írásrendszer (Fő Bonyolult írásrendszer betűtípus)

A következő példa létrehoz egy címsort, amely a fő Latin téma betűtípust használja, és egy törzsszövegsort, amely a kisebb Latin téma betűtípust használja. Ezután módosítja a téma betűtípusait, és elmenti az eredményt:

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

A címsor a fő betűtípust, a törzsszöveg a kisebb betűtípust követi. Azok a szövegek, amelyek explicit betűtárgy nevet használnak a témaazonosító helyett, nem váltanak automatikusan, amikor a téma betűtípus-séma megváltozik.

A fő és kisebb betűtípus-gyűjtemények egyéni írásrendszerekhez is tartalmazhatnak betűtípus-leképezéseket, például cirill, arab, japán, grúz és thaana. Ezeknek a leképezéseknek a vizsgálatához, hozzáadásához, cseréjéhez vagy eltávolításához lásd a [Script-Specific Theme Fonts](/slides/hu/nodejs-java/script-specific-font-mappings/) oldalt.

{{% alert color="info" title="Tip" %}}
További információért a prezentáció betűtípusokról, lásd a [PowerPoint Fonts](/slides/hu/nodejs-java/powerpoint-fonts/) oldalt.
{{% /alert %}}

### **Téma betűtípus hivatkozások feloldása**

Szöveg vizsgálatakor a [FontData.getFontName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontdata/) visszaadhat egy téma hivatkozást, például `+mn-lt`-et a betűcsalád neve helyett. Hívd meg a [FontData.getFontName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontdata/) megfelelő hatékony témával, hogy feloldja ezt a hivatkozást. A `+mj` és `+mn` előtagok a fő és kisebb betűkészleteket választják; a `-lt`, `-ea` és `-cs` utótagok a Latin, Kelet-Ázsiai és Bonyolult írásrendszer betűtípusokat választják.

Szerezd meg a hatékony témát a [Slide.createThemeEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/) metódussal azon objektumon, amelynek a témája a vizsgált szövegre vonatkozik. Egy dia szokásos szövegénél hívd meg ezt a metódust a dián, hogy a kontextus tartalmazza a dia örökölt témáját és a helyi felülírásokat. Elrendezés vagy master vizsgálatakor használd a saját hatékony témáját. Ne feltételezd, hogy az első master témája minden diára alkalmazandó.

A következő példa egy szövegrészt hoz létre, amely kifejezetten a kisebb Latin betűtípust hivatkozza. Egy dia betűtípus-sémát inicializál a [OverrideTheme.initFontSchemeFromInherited](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/) segítségével, és beállítja a fő és kisebb Latin családokat `Arial`-ra és `Calibri`-ra, így az eredmény reprodukálható bemeneti fájl nélkül.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const theme = slide.getThemeManager().getOverrideTheme();
    theme.initFontSchemeFromInherited();
    theme.getFontScheme().getMajor().setLatinFont(new aspose.slides.FontData("Arial"));
    theme.getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Calibri"));

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Text using the minor theme font");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));

    const font = portion.getPortionFormat().getLatinFont();
    const effectiveTheme = slide.createThemeEffective();
    console.log(font.getFontName() + " -> " + font.getFontName(effectiveTheme));

    const explicitFont = new aspose.slides.FontData("Verdana");
    console.log(explicitFont.getFontName() + " -> " + explicitFont.getFontName(effectiveTheme));
} finally {
    presentation.dispose();
}
```

A kimenet `+mn-lt -> Calibri`, majd `Verdana -> Verdana`. A tárolt hivatkozás változatlan marad, míg egy explicit családnév változatlanul visszatér. Ha a rész `+mj-lt`-t használna, akkor ebben a témában `Arial`-ra lenne feloldva.

Egy témahivatkozás feloldása azonosítja a téma által megadott betűcsaládot. Nem ellenőrzi a betűtípus elérhetőségét, vagy nem határozza meg a végül használt betűtípusfájlt a helyettesítés vagy a glif visszatérés után a renderelés során. Lásd a [Font Selection Sequence](/slides/hu/nodejs-java/font-selection-sequence/) és a [Font Substitution](/slides/hu/nodejs-java/font-substitution/) oldalakat ezekhez a különálló lépésekhez.

## **Téma másolása vagy alkalmazása**

Az alábbi munkafolyamatok különböző témához kapcsolódó problémákat oldanak meg.

### **Külső téma alkalmazása a masterhez tartozó diákra**

Használd a [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/) metódust, ha rendelkezel egy PowerPoint témafájllal (`.thmx`), és minden, egy adott masterhez tartozó diát újra szeretnél stílusozni. Válaszd ki a mastert a [Presentation.getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) gyűjteményből, amelyet a [MasterSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/) képvisel, majd add át a témafájl útvonalát a metódusnak.

A metódus a következő műveleteket hajtja végre:

1. Létrehozza az új master diát a kiválasztott master alapján.
1. Alkalmazza a külső témát az új masterra.
1. Hozzárendeli az új mastert minden olyan diához, amely korábban a kiválasztott masterhez tartozott.
1. Visszaadja az újonnan létrehozott [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/) objektumot.

A következő példa egy külső témát alkalmaz a első masterhez tartozó diákra, és elmenti a prezentációt:

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

Egy érvénytelen, sérült vagy nem támogatott téma [PptxReadException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxreadexception/) hibát okozhat. Ellenőrizd a felhasználók által megadott útvonalakat, kezeld a fájlrendszer hozzáférési hibákat, és csak akkor mentsd el a prezentációt, amikor a téma sikeresen alkalmazásra került.

Csak a kiválasztott masterhez tartozó diák kerülnek újra hozzárendelésre. Más masterhez tartozó diák megtartják meglévő masterjeiket és témáikat. A témaérzékeny színek, betűtípusok, kitöltések, vonalak, háttérstílusok és effektek a külső témához vannak feloldva. A közvetlenül hozzárendelt színek, betűtípusok, kitöltések és egyéb explicit formázások változatlanok maradhatnak. Az elrendezés- és dia-szintű felülírások is felülbírálhatják az új mastertől örökölt értékeket.

A téma olyan betűtípusokra hivatkozhat, amelyek a futtatási környezetben nincsenek elérhetők. Az egységes renderelés és export érdekében telepítsd a szükséges betűtípusokat, biztosítsd őket [custom font sources](/slides/hu/nodejs-java/custom-font/) használatával, vagy konfiguráld a [font substitution](/slides/hu/nodejs-java/font-substitution/) beállítást.

Ez egy közvetlen master-szintű munkafolyamat: a metódus egy `.thmx` fájl útvonalát fogadja, és nem igényel manuális slide-szintű vagy layout-szintű téma felülírások létrehozását.

### **Különböző külső témák alkalmazása több masterrel rendelkező prezentációban**

Ha a megfelelő master előre nem ismert, szerezd meg egy reprezentatív diáról a [Slide.getLayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/) és a [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslide/) segítségével. Tedd el az eredeti master hivatkozásokat a témák alkalmazása előtt, mivel minden hívás egy új mastert hoz létre a prezentációban.

A következő példa két szakaszból származó diák segítségével megtalálja a mastereket, és különböző külső témát alkalmaz minden csoporton:

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

Az első hívás csak a `firstGroupMaster`-hez tartozó diákat érinti, a második hívás csak a `secondGroupMaster`-hez tartozó diákat. Más masterhez tartozó diák nincsenek újra stílusozva.

### **Forrás téma megőrzése diák áthelyezésekor**

Ha egy diát egy másik prezentációba szeretnél áthelyezni és megőrizni az eredeti kialakítását, klónozd a forrás mastert a cél prezentációba a [MasterSlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/) segítségével, majd klónozd a diát a [SlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/) és a klónozott masterrel. Ez együtt viszi a mastert, annak elrendezéseit és a hozzá tartozó témát.

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

Ez a preferált munkafolyamat, amikor a forrás dia ugyanúgy kell, hogy kinézzen a célnál. Egyszerűen a tartalom klónozása egy nem kapcsolódó céllmasterre megváltoztathatja a téma által vezérelt színeket, betűtípusokat, háttérstílusokat és effektusokat.

### **Téma értékek alkalmazása egy meglévő diára**

Ha a cél dia a jelenlegi masterén és elrendezésén marad, inicializálj egy dia-szintű felülírást a forrás témából. A [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/), a [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/) és a [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/) metódusok átmásolják a három fő téma komponenset a felülírásba.

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

Ez megváltoztatja a diához használt témát anélkül, hogy megváltoztatná a többi dia által örökölt témát. A helyi felülírás eltávolításához és az örökölt értékek visszaállításához hívd meg a [OverrideTheme.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/) metódust.

### **Téma felülírás alkalmazása egy elrendezésre**

Az elrendezés-szintű felülírás azokat a diákra vonatkozik, amelyek azt az elrendezést használják, hacsak egy adott dia nem rendelkezik saját felülírással. Ugyanazokat az inicializálási metódusokat lehet használni a [LayoutSlideThemeManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslidethememanager/) segítségével:

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

Használj master vagy prezentáció-szintű témát, amikor sok elrendezésnek és diáknak ugyanazt az alaptervet kell megosztania, elrendezés felülírást, ha egy elrendezéscsaládnak különböző stílusra van szüksége, és dia felülírást csak valós kivételek esetén. A túlzott dia-szintű felülírások nehezebben jósolják meg a későbbi globális téma változásokat.

<!-- visual-explanation:presentation-theme:start -->
[![Egy master téma két elrendezést táplál; egy elrendezés felülírás a diákra hat, kivéve egy lokálisan felülírt diát.](visual-presentation-theme-20ad12f2193b.svg)](visual-presentation-theme-20ad12f2193b.svg)

*A elrendezés felülírás a használt elrendezést alkalmazó diákra vonatkozik, kivéve ha egy dia saját felülírást biztosít. A témához kötött értékek a feloldott séma szerint követik őket; az explicit módon formázott objektumok megtarthatják helyi megjelenésüket. A felülírásokat olyan szűken tartsd, amilyen szűken szükséges a tervezett kivétel.*
<!-- visual-explanation:presentation-theme:end -->

## **Téma háttérstílusok frissítése**

A téma háttérkitöltései a [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/formatscheme/) segítségével vannak tárolva. A PowerPoint az UI-jában több háttérválasztást jeleníthet meg, mint amennyi kitöltés-definíció fizikailag tárolva van ebben a gyűjteményben, mivel az UI kombinálhatja a téma kitöltéseket a téma színekkel és egyéb stílus hivatkozásokkal.

![PowerPoint háttérstílus galéria egy prezentációs témához](presentation-design_8.png)

A háttérstílus használata előtt vizsgáld meg a tárolt gyűjteményt és az aktuális [Background.getStyleIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/background/) értéket. A `0` stílusindex azt jelenti, hogy nincs téma kitöltés; a pozitív értékek téma háttérstílus hivatkozások. Ez különbözik attól, amikor a JavaScript gyűjteményt közvetlenül indexelezzük, ahol a `0` az első tárolt elemet jelenti. Ne feltételezd, hogy minden prezentáció ugyanannyi háttérkitöltés stílussal rendelkezik.

A következő példa bejelenti a rendelkezésre álló háttérkitöltés számát, egy téma háttérhivatkozást rendelesz az első masterhez, és elmenti a prezentációt:

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

A látható eredmény a master által hivatkozott téma bejegyzéstől és az elrendezés vagy dia szintjén lévő háttér felülírásoktól függ. Ha egy dia saját háttérrel rendelkezik, csak a master háttér megváltoztatása nem biztos, hogy a diát módosítja. Használd a [Background.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/background/) metódust, ha a végső háttér megismerésére van szükség az öröklődés alkalmazása után.

{{% alert color="warning" title="Warning" %}}
Ne kezeld a stílusindexet nullára alapozott gyűjteményindexként. Kerüld a stílusszámok hardkódolását egy fájlból, és ne feltételezd, hogy ugyanazt a megjelenést nyújtja egy másik fájlban; a téma stílusdefiníciók prezentációnként specifikusak.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
A közvetlen háttérformázáshoz és háttéröröklődéshez lásd a [Presentation Background](/slides/hu/nodejs-java/presentation-background/) oldalt.
{{% /alert %}}

## **Téma effektusok frissítése**

A téma formátumséma különálló kitöltés, vonal és effekt stílusgyűjteményeket tartalmaz, amelyeket a [FormatScheme.getFillStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/formatscheme/), a [FormatScheme.getLineStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/formatscheme/) és a [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/formatscheme/) tesz elérhetővé. A tipikus Office témák gyakran három fő stílusbejegyzést tartalmaznak, amelyek vizuálisan a finom, mérsékelt és intenzív formázásnak felelnek meg, de a kódnak minden gyűjteményt ellenőriznie kell ahelyett, hogy fix számot feltételezne.

![Finom, mérsékelt és intenzív témaeffektusok ugyanarra az alakzatra alkalmazva](presentation-design_10.png)

Amikor ezeket a gyűjteményeket JavaScript-ben elérted, a gyűjtemény indexelése nullára alapozott: a `0` az első tárolt stílus, a `2` a harmadik. Egy alakzat stílus‑hivatkozási indexei egy külön fogalom, amely a [ShapeStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapestyle/) segítségével érhető el. Egy téma stílus módosítása befolyásolja a hivatkozó alakzatokat; a közvetlen formázású alakzatok változatlanok maradhatnak.

A következő példa ellenőrzi, hogy a szükséges stílusbejegyzések léteznek, módosítja az első vonalstílust, a harmadik kitöltési stílust, engedélyezi a külső árnyékot a harmadik effektusstílusban, és elmenti az eredményt:

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

Azoknál az alakzatoknál, amelyek ezeket a helyeket hivatkozzák, az első téma vonalstílus piros lesz, a harmadik téma kitöltési stílus szilárd erdőzöld, és a harmadik effektusstílus egy 10 pont távolságú külső árnyékot kap. A pontos vizuális eredmény továbbra is attól függ, mely stílushelyeket hivatkozza az egyes alakzat, és a közvetlen formázás felülírja-e a témát.

![Téma effektus stílusok a vonal-, kitöltés- és árnyék beállítások módosítása után](presentation-design_11.png)

## **Téma kitöltés és vonalstílusok kiválasztása egy alakzatra**

Egy alakzat a [ShapeStyle.setFillStyleIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapestyle/setfillstyleindex/) és a [ShapeStyle.setLineStyleIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapestyle/setlinestyleindex/) segítségével függetlenül kiválaszthatja a kitöltést és a körvonalat. Mindkét metódusnál a `1` index a megfelelő téma gyűjtemény első elemét választja (`get_Item(0)`), a `2` index a másodikat (`get_Item(1)`).

A következő példa két kitöltésstílust (arany és égkék) és két vonalstílust (sötétkék 6 pt-nél és sötétvörös 12 pt-nél) állít be az új prezentáció alapértelmezett témájában. A diát három szakaszban menti el, hogy összehasonlíthasd az eredményeket a PowerPointban.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const styles = presentation.getMasterTheme().getFormatScheme();

    const goldFill = styles.getFillStyles().get_Item(0);
    goldFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
    goldFill.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 215, 0));
    const blueFill = styles.getFillStyles().get_Item(1);
    blueFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
    blueFill.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 135, 206, 235));

    const thinLine = styles.getLineStyles().get_Item(0);
    thinLine.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thinLine.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 139));
    thinLine.setWidth(6);
    const thickLine = styles.getLineStyles().get_Item(1);
    thickLine.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thickLine.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 139, 0, 0));
    thickLine.setWidth(12);

    const shapes = presentation.getSlides().get_Item(0).getShapes();
    const left = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 205, 200, 130);
    const right = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 420, 205, 200, 130);
    left.getShapeStyle().setFillStyleIndex(java.newShort(1));
    right.getShapeStyle().setFillStyleIndex(java.newShort(2));
    left.getShapeStyle().setLineStyleIndex(1);
    right.getShapeStyle().setLineStyleIndex(1);
    presentation.save("01-initial.pptx", aspose.slides.SaveFormat.Pptx);

    right.getShapeStyle().setLineStyleIndex(2);
    presentation.save("02-line-changed.pptx", aspose.slides.SaveFormat.Pptx);

    goldFill.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 46, 139, 87));
    presentation.save("03-theme-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Kezdeti stílusok | A jobb körvonal módosítása | Az első téma kitöltés szerkesztése |
|:---:|:---:|:---:|
| ![Arany és égkék téglalapok, illeszkedő vékony sötétkék körvonalakkal](theme-style-initial.png) | ![Az égkék téglalap most vastag sötétvörös körvonallal](theme-style-line-changed.png) | ![A bal téglalap most zöld, és mindkét körvonal változatlan](theme-style-fill-changed.png) |

Egy másik vonalstílus kiválasztása csak a jobb téglalap körvonalát változtatja. Az első téma kitöltés szerkesztése minden alakzatra hat, amely azt használja. Itt csak a bal téglalap válik zöldé.

Egy meglévő alakzatnál egy helyi kitöltő szín, vonal szín vagy vonalvastagság felülírhatja a téma stílus azon részét. Ha egy stílusindex módosítása nincs látható hatása, ellenőrizd az alakzat [direct formatting](/slides/hu/nodejs-java/shape-formatting/) beállításait.

## **Annak meghatározása, hogy a hatékony szilárd kitöltés téma színt használ-e**

Egy kitöltés tárolható közvetlenül egy objektumon vagy örökölhető egy bekezdéstől, elrendezéstől, mastertől, téma stílustól vagy egy másik formázási szintről. Hívd meg a [FillFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/) metódust, hogy ezt a hierarchiát egy változtathatatlan hatékony kitöltés pillanatfelvétellé alakítsa. Először ellenőrizd a `getFillType` értékét. Csak akkor, ha `FillType.Solid`, olvasd a szilárd kitöltés tulajdonságait.

Egy szilárd kitöltésnél a `getSolidFillColor` visszaadja a végső megjelenített RGB értéket az öröklődés, a téma keresés és a színtranszformációk alkalmazása után. A `getSolidFillSchemeColor` metódus visszaadja a megfelelő logikai [SchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/schemecolor/) helyet, például `Text1` vagy `Accent6`. A `SchemeColor.NotDefined` érték azt jelenti, hogy a hatékony szilárd kitöltés nem egy séma színen alapul. Egy olyan munkafolyamatban, ahol a kitöltések vagy témaszínek vagy közvetlen RGB színek, ez az érték egy közvetlen RGB kitöltést jelöl.

Ne használd a helyi [ColorFormat.getSchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/) értéket önmagában a kitöltés osztályozásához. Például egy szövegrésznek nincs helyi definiált séma színe, így a helyi értéke `NotDefined`, miközben a hatékony kitöltése téma színt örököl és `Text1` vagy `Accent6`-ra oldódik. Ezzel szemben a `getSolidFillSchemeColor` megmondja, mely logikai témahely állította elő a hatékony színt, de nem jelzi, hogy az a hely az objektumból, bekezdésből, elrendezésből, masterből vagy a formázási hierarchia egy másik szintjéről származik.

A következő példa betölt egy prezentációt, ellenőrzi mind az alakzat kitöltéseket, mind a szövegrész kitöltéseket, kiírja minden végső RGB értéket és a kapcsolódó séma színt, valamint megjelöli azokat a szilárd kitöltéseket, amelyek nem követik a téma színváltozásokat:

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

A `NotDefined` ág egy ellenőrzési listát ad a szilárd kitöltésekről, amelyek nem reagálnak a téma színhelyek változásaira. Vizsgáld át ezeket az objektumokat, amikor a prezentációnak egy új márka palettát kell követnie. A jelentett RGB érték továbbra is a jelenlegi megjelenést mutatja, míg a sémaérték magyarázza, hogy ez a megjelenés kapcsolódik-e a témához.

A hatékony formátum objektok pillanatfelvételek. A prezentáció téma, egy téma felülírás vagy bármely örökölt formázás módosítása után hívd meg a `getEffective`-et újra, és olvasd el az új hatékony kitöltő objektumot, mielőtt összehasonlítod vagy jelentést készítesz a színekről.

## **Hatékony téma értékek olvasása**

A nyers téma objektumok megmutatják, mi van definiálva egy adott szinten. A hatékony értékek azt mutatják, hogy egy dia vagy alakzat ténylegesen mit használ az öröklődés és a helyi felülírások feloldása után. Egy dia esetén hívd meg a [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseoverridethememanager/) metódust. Egy háttér esetén használd a [Background.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/background/) metódust, és egy kitöltésnél a [FillFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/) metódust.

A következő példa beolvassa a hatékony témát, a háttért és az első alakzat kitöltését egy diáról:

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

Használd a hatékony adatokat a renderelés diagnosztikához, validáláshoz és összehasonlításokhoz. Ha csak a [Presentation.getMasterTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getmastertheme/) metódust vizsgálod, akkor kihagyhatsz egy master, elrendezés, dia vagy alakzat felülírást, amely megváltoztatja a végső megjelenést.

## **GYIK**

**Az külső téma alkalmazása befolyásolja-e a prezentáció minden diáját?**

Nem. A [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/) csak azokat a diákat rendeli újra, amelyek a kiválasztott masterhez tartoznak. A más mastereket használó diák megtartják meglévő témáikat.

**Alkalmazhatok egy témát egyetlen diára anélkül, hogy megváltoztatnám a mastert?**

Igen. Használd a dia [SlideThemeManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidethememanager/) objektumát, és inicializáld annak felülírási témáját. A változás csak az adott diára vonatkozik; a többi dia továbbra is örökli meglévő témáit.

**Mi a legbiztonságosabb módja egy téma átvitelének az egyik prezentációból a másikba?**

Ha egy diát áthelyezünk és megőrizzük a forrás megjelenését, klónozd a forrás mastert a célba, majd a diát azzal a masterrel a [MasterSlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/) és a [SlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/) segítségével. Ez együtt tartja a mastert, az elrendezéseket és a témát.

**Hogyan tekinthetem meg a hatékony értékeket az öröklődés és felülírások után?**

Használd a [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseoverridethememanager/) metódust egy dia vagy elrendezés téma esetén, valamint a megfelelő hatékony-adat metódusokat a formátum objektumokhoz, mint a [Background.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/background/) és a [FillFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/). Ezek az API-k visszaadják az öröklődés és felülírások alkalmazása után feloldott értékeket.