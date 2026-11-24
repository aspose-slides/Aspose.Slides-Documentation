---
title: Prezentációs témák kezelése Java-ban
linktitle: Prezentációs téma
type: docs
weight: 10
url: /hu/java/presentation-theme/
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
- Java
- Aspose.Slides
description: "Mester prezentációs témák az Aspose.Slides for Java-ban a PowerPoint fájlok létrehozásához, testreszabásához és konvertálásához egységes márkaazonossággal."
---
## **Bevezetés**

A prezentációs téma egy koordinált színek, betűtípusok, háttérstílusok, kitöltések, vonalak és hatások halmazát határozza meg. A téma‑tudatos objektumok ezekre a megosztott definíciókra hivatkoznak ahelyett, hogy minden vizuális tulajdonságot rögzített értékként tárolnának, így egy téma‑csere egyszerre sok objektumot frissíthet.

Az Aspose.Slides esetében a prezentáció‑szintű téma a [Presentation.getMasterTheme](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) segítségével érhető el. A prezentáció alacsonyabb szinteken is tartalmazhat téma‑felülírásokat. Egy mester a [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/java/com.aspose.slides/masterthememanager/) segítségével felülírhatja a prezentáció témáját, míg egy elrendezés vagy egy adott dia a [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/java/com.aspose.slides/baseoverridethememanager/) segítségével felülírhatja az örökölt témát. Gyakorlatilag egy dia hatékony témája az alábbi öröklődési lánc mentén kerül feloldásra: prezentáció‑téma, mester‑felülírás, elrendezés‑felülírás és dia‑felülírás.

![Témaelemek: színek, betűtípusok, háttérstílusok és effektusok](theme-constituents.png)

Az alábbi szakaszok a leggyakoribb téma‑munkafolyamatokat mutatják be: téma vizsgálata, színek és betűtípusok módosítása, téma másolása vagy alkalmazása, háttér‑ és effektus‑stílusok frissítése, valamint a hatékony értékek olvasása az öröklődés és felülírások feloldása után.

## **Téma vizsgálata**

A [MasterTheme](https://reference.aspose.com/slides/java/com.aspose.slides/mastertheme/) objektum a téma színsémáját, betűtípus‑sémáját és formátum‑sémáját teszi elérhetővé a [MasterTheme.getColorScheme](https://reference.aspose.com/slides/java/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/java/com.aspose.slides/mastertheme/) és [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/java/com.aspose.slides/mastertheme/) metódusokon keresztül. Ezeknek a gyűjteményeknek a vizsgálata különösen hasznos, ha a prezentáció külső forrásból származik, mert a stíluselemek száma és tartalma változhat.

Az alábbi példa kiolvassa a fő téma‑attribútumokat, és jelzi, hogy hány háttér‑, kitöltés‑, vonal‑ és effektus‑stílus van tárolva a témában:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterTheme theme = presentation.getMasterTheme();
    System.out.println("Theme name: " + theme.getName());
    System.out.println("Accent 1: " + theme.getColorScheme().getAccent1().getColor());
    System.out.println("Major Latin font: " + theme.getFontScheme().getMajor().getLatinFont().getFontName());
    System.out.println("Minor Latin font: " + theme.getFontScheme().getMinor().getLatinFont().getFontName());
    System.out.println("Background fill styles: " + theme.getFormatScheme().getBackgroundFillStyles().size());
    System.out.println("Fill styles: " + theme.getFormatScheme().getFillStyles().size());
    System.out.println("Line styles: " + theme.getFormatScheme().getLineStyles().size());
    System.out.println("Effect styles: " + theme.getFormatScheme().getEffectStyles().size());
} finally {
    presentation.dispose();
}
```

Ha egy fájl több mestert használ, ne tételezzük fel, hogy minden dia ugyanazzal a hatékony témával rendelkezik. Vizsgálja meg a diára vonatkozó mestert, és használja a később ebben a cikkben bemutatott hatékony‑téma munkafolyamatot, ha elrendezés‑ vagy dia‑felülírások léteznek.

## **Téma színeinek módosítása**

A téma‑tudatos kitöltések, vonalak és szöveg logikai színre hivatkozhat a [SchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/schemecolor/) felsorolásban. Amikor módosítja a megfelelő bejegyzést az [IColorScheme](https://reference.aspose.com/slides/java/com.aspose.slides/icolorscheme/)‑ben, minden olyan objektum, amely még mindig hivatkozik arra a téma‑színre, az új értéknek megfelelően kerül feloldásra. Azok az objektumok, amelyek közvetlen RGB‑színt használnak, nem változnak a téma‑szín frissítésekor.

Az alábbi végpont‑tól‑végpont példakód egy `Accent4`‑et használó alakzatot hoz létre, a téma `Accent4` színét pirosra állítja, elmenti a prezentációt, újra megnyitja, és kiírja a hatékony kitöltési színt:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);

    presentation.save("theme-color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation savedPresentation = new Presentation("theme-color.pptx");
try {
    ISlide savedSlide = savedPresentation.getSlides().get_Item(0);

    IShape savedShape = savedSlide.getShapes().get_Item(0);
    IFillFormatEffectiveData effectiveFill = savedShape.getFillFormat().getEffective();
    System.out.println("Effective fill color: " + effectiveFill.getSolidFillColor());
} finally {
    savedPresentation.dispose();
}
```

Mivel a téglalap továbbra is az `Accent4`‑hez kapcsolódik, a látható színe piros lesz a téma módosítása után. Ha a téma‑színt közvetlen színre cseréli az alakzaton, a későbbi `Accent4`‑változások már nem befolyásolják azt a kitöltést.

### **Színek használata a kiegészítő palettáról**

A PowerPoint a téma‑színből könnyebb és sötétebb változatokat színátmenetekkel állít elő. Az Aspose.Slides a [ColorTransformOperation](https://reference.aspose.com/slides/java/com.aspose.slides/colortransformoperation/) felsorolásban teszi elérhetővé ezeket a transzformációkat.

![Fő téma színek és a kiegészítő palettáról előállított világosabb és sötétebb színek](additional-palette-colors.png)

**1** – Fő téma színek.

**2** – A fő téma színekből előállított világosabb és sötétebb változatok.

Az alábbi példa hat téglalapot hoz létre `Accent4`‑ből, ötön luminancia‑transzformációkat alkalmaz, és elmenti az eredményt:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save("theme-color-palette.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ezek a változatok továbbra is a téma‑színen alapulnak. Ha később az `Accent4` megváltozik, a transzformált színek az új `Accent4` értékből kerülnek újraszámításra.

### **A `SchemeColor` értékek leképezése az `IColorScheme` helyekre**

A [SchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/schemecolor/) felsorolás a `Text1`, `Background1`, `Text2` és `Background2` értékeket használja, míg az [IColorScheme](https://reference.aspose.com/slides/java/com.aspose.slides/icolorscheme/) ugyanazokat a téma‑helyeket `Dark1`, `Light1`, `Dark2` és `Light2` néven teszi elérhetővé. A leképezés rögzített:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Ezek ugyanazon téma‑helyek alternatív megnevezései; nem dinamikusan konvertált értékek.

## **Téma betűtípusainak módosítása**

A téma betűtípus‑sémája egy fő betűkészletet biztosít a címsorokhoz és egy mellékbetűkészletet a törzsszöveghez. A [IFontScheme.getMajor](https://reference.aspose.com/slides/java/com.aspose.slides/ifontscheme/) és a [IFontScheme.getMinor](https://reference.aspose.com/slides/java/com.aspose.slides/ifontscheme/) metódusok ezeket a készleteket exponálják.

A PowerPoint‑kompatibilis téma betűtípus‑azonosítókat a szövegformázásban is használhatja:

* `+mn-lt` – Törzs betű Latin (Minor Latin Font)
* `+mj-lt` – Címsor betű Latin (Major Latin Font)
* `+mn-ea` – Törzs betű Kelet‑Ázsiai (Minor East Asian Font)
* `+mj-ea` – Címsor betű Kelet‑Ázsiai (Major East Asian Font)
* `+mn-cs` – Törzs betű Komplex írásrendszer (Minor Complex Script Font)
* `+mj-cs` – Címsor betű Komplex írásrendszer (Major Complex Script Font)

Az alábbi példa egy címsort hoz létre, amely a fő Latin téma‑betűtípust használja, és egy törzssort, amely a mellék Latin betűtípust használja. Ezután a téma betűtípusait módosítja és elmenti az eredményt:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 500, 60);
    heading.getTextFrame().setText("Theme heading");
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData("+mj-lt"));

    IAutoShape body = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 120, 500, 60);
    body.getTextFrame().setText("Theme body text");
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData("+mn-lt"));

    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(new FontData("Aptos Display"));
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));

    presentation.save("theme-fonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A címsor a fő betűtípust, a törzsszöveg pedig a mellék betűtípust követi. Azok a szövegek, amelyek kifejezett betűtípus‑nevet tartalmaznak a téma‑azonosító helyett, nem váltanak automatikusan, ha a téma betűtípus‑sémája megváltozik.

A fő és mellék betűkészletek tartalmazhatnak betűtípus‑leképezéseket egyedi írásrendszerekhez, például cirill, arab, japán, grúz vagy thaana. Ezek vizsgálatához, hozzáadásához, cseréjéhez vagy eltávolításához lásd a [Script‑Specific Theme Fonts](/slides/hu/java/script-specific-font-mappings/) oldalt.

{{% alert color="info" title="Tip" %}}
További információk a prezentációs betűtípusokról: [PowerPoint Fonts](/slides/hu/java/powerpoint-fonts/).
{{% /alert %}}

### **Téma betűtípus hivatkozásainak feloldása**

Szöveg vizsgálatakor a [IFontData.getFontName](https://reference.aspose.com/slides/java/com.aspose.slides/ifontdata/#getFontName--) visszaadhat téma‑hivatkozást, például `+mn-lt`, a betűcsaládnév helyett. A megfelelő [IThemeEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ithemeeffectivedata/) átadásával hívja a [IFontData.getFontName](https://reference.aspose.com/slides/java/com.aspose.slides/ifontdata/#getFontName-com.aspose.slides.IThemeEffectiveData-) metódust, hogy feloldja a hivatkozást. A `+mj` és `+mn` előtagok a fő és mellék betűkészletet választják; a `-lt`, `-ea` és `-cs` utótagok a Latin, Kelet‑Ázsiai és Komplex írásrendszer betűket jelölik.

Szerezze be a hatékony témát az [IThemeable.createThemeEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ithemeable/#createThemeEffective--) metódussal azon objektumon, amelynek a témája a vizsgált szövegre vonatkozik. Általános szöveg egy diáron a metódust a dián hívja, így a kontextus tartalmazza a dia örökölt témáját és helyi felülírásait. Elrendezés vagy mester vizsgálatakor használja annak a saját hatékony témáját. Ne tételezze fel, hogy az első mester témája minden diára érvényes.

Az alábbi példa egy szövegrészt hoz létre, amely kifejezetten a mellék Latin betűtípust hivatkozza. Egy [IOverrideTheme.initFontSchemeFromInherited](https://reference.aspose.com/slides/java/com.aspose.slides/ioverridetheme/#initFontSchemeFromInherited--) hívással inicializálja a dia betűtípus‑sémáját, és a fő és mellék Latin családokat `Arial`‑ra és `Calibri`‑ra állítja, így a bemeneti fájl nélkül reprodukálható az eredmény.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IOverrideTheme theme = slide.getThemeManager().getOverrideTheme();
    theme.initFontSchemeFromInherited();
    theme.getFontScheme().getMajor().setLatinFont(new FontData("Arial"));
    theme.getFontScheme().getMinor().setLatinFont(new FontData("Calibri"));

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Text using the minor theme font");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));

    IFontData font = portion.getPortionFormat().getLatinFont();
    IThemeEffectiveData effectiveTheme = slide.createThemeEffective();
    System.out.println(font.getFontName() + " -> " + font.getFontName(effectiveTheme));

    FontData explicitFont = new FontData("Verdana");
    System.out.println(explicitFont.getFontName() + " -> " + explicitFont.getFontName(effectiveTheme));
} finally {
    presentation.dispose();
}
```

A kimenet `+mn-lt -> Calibri`, majd `Verdana -> Verdana`. A tárolt hivatkozás változatlan marad, míg a kifejezett családnevet változatlanul visszaadja. Ha a rész `+mj-lt`‑t használt volna, ebben a témában `Arial`‑ra oldódna fel.

A téma‑hivatkozás feloldása meghatározza a tema által megadott betűcsaládot, de nem ellenőrzi a betűtípus elérhetőségét vagy a végső betűtípus‑fájlt, amely a helyettesítés vagy glyph fallback során kerül felhasználásra. Lásd a [Font Selection Sequence](/slides/hu/java/font-selection-sequence/) és a [Font Substitution](/slides/hu/java/font-substitution/) oldalakat a különálló lépésekhez.

## **Téma másolása vagy alkalmazása**

Az alábbi munkafolyamatok különböző téma‑kapcsolatos problémákat oldanak meg.

### **Külső téma alkalmazása egy mesterhez tartozó diákra**

Használja a [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/) metódust, ha egy PowerPoint témafájlt (`.thmx`) szeretne alkalmazni, és a kiválasztott mesterhez tartozó minden diát újratervezni kívánja. Válassza ki a mestert a [Presentation.getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) gyűjteményből, amely a [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/)‑t valósítja meg, majd adja át a témafájl útvonalát a metódusnak.

A metódus a következő lépéseket hajtja végre:

1. Létrehoz egy új mesterdiat a kiválasztott mester alapján.
1. Alkalmazza a külső témát az új mestern.
1. Hozzárendeli az új mestert minden diához, amely korábban a kiválasztott mesterhez tartozott.
1. Visszaadja az újonnan létrehozott [IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/)-t.

Az alábbi példa külső témát alkalmaz az első mesterhez tartozó diákra, és elmenti a prezentációt:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide selectedMaster = presentation.getMasters().get_Item(0);

    IMasterSlide themedMaster = selectedMaster.applyExternalThemeToDependingSlides("corporate-theme.thmx");
    System.out.println("Created master: " + themedMaster.getName());

    presentation.save("presentation-with-external-theme.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Érvénytelen, sérült vagy nem támogatott téma esetén a [PptxReadException](https://reference.aspose.com/slides/java/com.aspose.slides/pptxreadexception/) keletkezhet. Ellenőrizze a felhasználók által megadott útvonalakat, kezelje a fájlrendszer‑hozzáférési hibákat, és csak a téma sikeres alkalmazása után mentse a prezentációt.

Csak a kiválasztott mesterhez tartozó diák kerülnek újrahozzárendelésre. Más mesterekhez tartozó diák megőrzik meglévő mestereiket és témáikat. A téma‑tudatos színek, betűtípusok, kitöltések, vonalak, háttér‑ és effektus‑állapotok a külső téma szerint kerülnek feloldásra. A közvetlenül hozzárendelt színek, betűtípusok, kitöltések és egyéb explicit formázás változatlan maradhat. Elrendezés‑ és dia‑szintű felülírások is felülbírálhatják az új mesterből örökölt értékeket.

A téma hivatkozhat olyan betűtípusokra, amelyek nincsenek jelen a futási környezetben. A következetes megjelenítés és export érdekében telepítse a szükséges betűtípusokat, biztosítsa azokat a [custom font sources](/slides/hu/java/custom-font/) segítségével, vagy állítsa be a [font substitution](/slides/hu/java/font-substitution/)‑t.

Ez egy közvetlen mester‑szintű munkafolyamat: a metódus egy `.thmx` fájl elérési útját várja, és nem igényli a dia‑ vagy elrendezés‑szintű téma‑felülírások kézi létrehozását.

### **Különböző külső témák alkalmazása több‑mesteres prezentációban**

Ha a megfelelő mestert előre nem ismeri, szerezze be egy reprezentatív dia segítségével a [ISlide.getLayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/) és a [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutslide/) metódusokkal. A téma‑alkalmazás előtt tárolja el az eredeti mester‑referenciákat, mivel minden hívás egy új mestert hoz létre a prezentációban.

Az alábbi példa két szekció diáit használja a mesterek megtalálásához, és mindegyik csoporthoz külön külső témát alkalmaz:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("multi-master-presentation.pptx");
try {
    if (presentation.getSlides().size() < 5) {
        System.out.println("The presentation does not contain the expected representative slides.");
    } else {
        IMasterSlide firstGroupMaster = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide();
        IMasterSlide secondGroupMaster = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide();

        if (firstGroupMaster.getSlideId() == secondGroupMaster.getSlideId()) {
            System.out.println("The representative slides use the same master.");
        } else {
            IMasterSlide firstThemedMaster = firstGroupMaster.applyExternalThemeToDependingSlides("blue-theme.thmx");
            IMasterSlide secondThemedMaster = secondGroupMaster.applyExternalThemeToDependingSlides("green-theme.thmx");

            System.out.println("First themed master: " + firstThemedMaster.getName());
            System.out.println("Second themed master: " + secondThemedMaster.getName());

            presentation.save("multi-master-with-external-themes.pptx", SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

Az első hívás csak a `firstGroupMaster`‑hez tartozó diákra hat, a második csak a `secondGroupMaster`‑hez tartozó diákra. Más mesterekhez tartozó diákok nem kapnak új stílust.

### **Forrástéma megőrzése diák áthelyezésekor**

Ha egy diát egy másik prezentációba szeretne áthelyezni, miközben megőrzi annak eredeti megjelenését, klónozza a forrás‑mestert a célnak a [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/) segítségével, majd a diát a [ISlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/) és a klónozott master használatával klónozza. Ezzel a mester, az elrendezései és a hozzá tartozó téma együtt kerülnek átvitelre.

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide sourceSlide = source.getSlides().get_Item(0);

        IMasterSlide sourceMaster = sourceSlide.getLayoutSlide().getMasterSlide();
        IMasterSlide clonedMaster = target.getMasters().addClone(sourceMaster);

        target.getSlides().addClone(sourceSlide, clonedMaster, true);

        target.save("theme-preserved.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Ez a preferált munkafolyamat, ha a forrásdia megjelenése pontosan ugyanúgy kell, hogy legyen a célban. A tartalom egyszerű klónozása egy nem kapcsolódó cél‑mesterhez színek, betűtípusok, háttér‑ és effektus‑változásokhoz vezethet.

### **Témaértékek alkalmazása egy meglévő diára**

Ha a céldia a jelenlegi mesterén és elrendezésén marad, inicializáljon egy dia‑szintű felülírást a forrástémából. A [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/java/com.aspose.slides/overridetheme/), a [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/java/com.aspose.slides/overridetheme/) és a [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/java/com.aspose.slides/overridetheme/) metódusok a három fő téma‑komponenst másolják a felülírásba.

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = presentation.getSlides().get_Item(0);

        IOverrideTheme overrideTheme = targetSlide.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(source.getMasterTheme().getColorScheme());
        overrideTheme.initFontSchemeFrom(source.getMasterTheme().getFontScheme());
        overrideTheme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme());

        target.save("theme-applied-to-slide.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Ez a dia által használt témát módosítja anélkül, hogy a többi dia örökölt témáját megváltoztatná. A helyi felülírás eltávolításához és az örökölt értékek visszaállításához hívja a [OverrideTheme.clear](https://reference.aspose.com/slides/java/com.aspose.slides/overridetheme/) metódust.

### **Téma felülírása egy elrendezésre**

Az elrendezés‑szintű felülírás az adott elrendezést használó diákra érvényes, hacsak egy adott dia nem rendelkezik saját felülírással. Ugyanezek a inicializációs metódusok a [LayoutSlideThemeManager](https://reference.aspose.com/slides/java/com.aspose.slides/layoutslidethememanager/) segítségével használhatók:

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = presentation.getSlides().get_Item(0);

        ILayoutSlide targetLayout = targetSlide.getLayoutSlide();
        IOverrideTheme overrideTheme = targetLayout.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(source.getMasterTheme().getColorScheme());
        overrideTheme.initFontSchemeFrom(source.getMasterTheme().getFontScheme());
        overrideTheme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme());

        target.save("theme-applied-to-layout.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Használjon mester‑ vagy prezentáció‑szintű témát, ha sok elrendezésnek és diáknak kell ugyanazt az alap‑design‑t megosztania, egy elrendezés‑felülírást, ha egy elrendezéscsaládnak más stílusra van szüksége, és csak dia‑felülírást, ha valódi kivételt kell kezelni. A túlzott dia‑szintű felülírások megnehezítik a későbbi globális téma‑változások előrejelzését.


<!-- visual-explanation:presentation-theme:start -->
[![Egy mester‑téma két elrendezést táplál; egy elrendezés‑felülírás az általa használt diákokat érinti, kivéve egy helyi felülírással rendelkező diát.](visual-presentation-theme-20ad12f2193b.svg)](visual-presentation-theme-20ad12f2193b.svg)

*Egy elrendezés‑felülírás a megfelelő elrendezést használó diákokra vonatkozik, hacsak egy dia saját felülírást nem ad meg. A téma‑alapú értékek a feloldott sémájukat követik; a kifejezetten formázott objektumok megtartják helyi megjelenésüket. A felülírásokat tartsuk olyan szűk körben, amilyen a tervezett kivétel.*
<!-- visual-explanation:presentation-theme:end -->

## **Téma háttér‑stílusainak frissítése**

A téma háttér‑kitöltései az [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/java/com.aspose.slides/iformatscheme/)‑ben vannak tárolva. A PowerPoint a felhasználói felületen több háttér‑választást jeleníthet meg, mint amennyi kitöltés‑definíció fizikailag tárolva van ebben a gyűjteményben, mert a UI kombinálhatja a téma‑kitöltéseket téma‑színekkel és egyéb stílushivatkozásokkal.

![PowerPoint háttér‑stílus galéria egy prezentációs témához](presentation-design_8.png)

Mielőtt háttér‑stílust használna, vizsgálja meg a tárolt gyűjteményt és az aktuális [Background.getStyleIndex](https://reference.aspose.com/slides/java/com.aspose.slides/background/)-t. A `0`‑ás index azt jelenti, hogy nincs témához rendelt kitöltés; a pozitív értékek téma‑háttér‑stílus‑referenciák. Ez eltér attól, ha a Java gyűjteményt közvetlenül indexeli, ahol a `get_Item(0)` az első tárolt elemet jelenti. Ne tételezze fel, hogy minden prezentáció ugyanannyi háttér‑kitöltési stílussal rendelkezik.

Az alábbi példa kiírja a rendelkezésre álló háttér‑kitöltések számát, a témához rendelt első mesterhez egy téma‑háttér‑referenciát rendel, majd elmenti a prezentációt:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IFillFormatCollection backgroundStyles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles();
    System.out.println("Background fill styles: " + backgroundStyles.size());
    if (backgroundStyles.size() == 0) {
        throw new IllegalStateException("The presentation theme does not contain background fill styles.");
    }

    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    masterSlide.getBackground().setType(BackgroundType.Themed);
    masterSlide.getBackground().setStyleIndex(1);

    presentation.save("theme-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A látható eredmény a mester által hivatkozott téma‑bejegyzéstől, valamint az elrendezés‑ vagy dia‑szintű háttér‑felülírásoktól függ. Ha egy dia saját hátteret használ, a mester hátterének módosítása nem feltétlenül változtatja meg azt a diát. Használja a [Background.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/background/)‑t, ha a végső háttérre van szükség az öröklődés után.

{{% alert color="warning" title="Warning" %}}
Ne kezelje a stílus‑indexet nulla‑alapú gyűjtemény‑indexként. Kerülje a fájlból egy szám kódolását, és annak egy másik fájlban való ugyanúgy történő megjelenítését; a téma‑stílusdefiníciók prezentációnként eltérnek.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Közvetlen háttér‑formázáshoz és háttér‑öröklődéshez lásd a [Presentation Background](/slides/hu/java/presentation-background/) oldalt.
{{% /alert %}}

## **Téma effektusainak frissítése**

A téma formátum‑séma külön kitöltés‑, vonal‑ és effektus‑stílus‑gyűjteményeket tartalmaz, amelyeket a [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/java/com.aspose.slides/iformatscheme/), a [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/java/com.aspose.slides/iformatscheme/) és a [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/java/com.aspose.slides/iformatscheme/) metódusok fednek le. A tipikus Office‑témák gyakran három fő stílus‑bejegyzést tartalmaznak, amelyek vizuálisan a finom, közepes és intenzív formázásnak felelnek meg, de a kódnak a gyűjteményeket minden esetben ellenőrizni kell, ahelyett, hogy rögzített számra támaszkodna.

![Finom, közepes és intenzív téma‑effektusok ugyanarra az alakzatra alkalmazva](presentation-design_10.png)

Java‑ban a gyűjtemény indexelése nullával kezdődik: a `get_Item(0)` az első tárolt stílust, a `get_Item(2)` a harmadikat jelenti. Az alakzatok stílus‑referencia‑indexei egy külön koncepció, amelyet az [IShapeStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ishapestyle/) exponál. Egy téma‑stílus módosítása azoknak az alakzatoknak a megjelenését változtatja, amelyek arra a téma‑stílusra hivatkoznak; a közvetlen formázású alakzatok változatlanok maradhatnak.

Az alábbi példa ellenőrzi, hogy a szükséges stílus‑bejegyzések léteznek, módosítja az első vonal‑stílust, a harmadik kitöltés‑stílust, egy külső árnyékot kapcsol be a harmadik effektus‑stílusban, majd elmenti az eredményt:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    IFormatScheme formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new IllegalStateException("The theme does not contain the style entries required by this example.");
    }
    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid);
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);
    formatScheme.getFillStyles().get_Item(2).setFillType(FillType.Solid);
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(new Color(34, 139, 34));
    IEffectFormat effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10f);

    presentation.save("theme-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A stílus‑helyekre hivatkozó alakzatok esetén az első téma‑vonal‑stílus pirosra változik, a harmadik téma‑kitöltés‑stílus szilárd erdőzöld lesz, a harmadik effektus‑stílus pedig egy 10 pont távolságú külső árnyékot kap. A pontos vizuális eredmény továbbra is attól függ, hogy melyik stílus‑helyet hivatkozza az egyes alakzat és hogy a közvetlen formázás felülírja-e a témát.

![Téma‑effektus‑stílusok vonal-, kitöltés‑ és árnyék‑beállítások módosítása után](presentation-design_11.png)

## **Kitöltés‑ és vonal‑stílusok kiválasztása egy alakzatra**

Egy alakzat a [IShapeStyle.setFillStyleIndex](https://reference.aspose.com/slides/java/com.aspose.slides/ishapestyle/#setFillStyleIndex-short-) és a [IShapeStyle.setLineStyleIndex](https://reference.aspose.com/slides/java/com.aspose.slides/ishapestyle/#setLineStyleIndex-int-) metódusok segítségével függetlenül választhat kitöltést és körvonalat. Mindkét metódus esetén az `1` index a megfelelő téma‑gyűjtemény első bejegyzését (`get_Item(0)`) jelöli, a `2` index a másodikat (`get_Item(1)`).

Az alábbi példa két kitöltési stílust (arany és égkék) és két vonal‑stílust (sötétkék 6 pt, sötétvörös 12 pt) hoz létre egy új prezentáció alap‑témájában. A diát három állapotban menti, hogy összehasonlítható legyen PowerPoint‑ban.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    IFormatScheme styles = presentation.getMasterTheme().getFormatScheme();

    IFillFormat goldFill = styles.getFillStyles().get_Item(0);
    goldFill.setFillType(FillType.Solid);
    goldFill.getSolidFillColor().setColor(new Color(255, 215, 0));
    IFillFormat blueFill = styles.getFillStyles().get_Item(1);
    blueFill.setFillType(FillType.Solid);
    blueFill.getSolidFillColor().setColor(new Color(135, 206, 235));

    ILineFormat thinLine = styles.getLineStyles().get_Item(0);
    thinLine.getFillFormat().setFillType(FillType.Solid);
    thinLine.getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
    thinLine.setWidth(6);
    ILineFormat thickLine = styles.getLineStyles().get_Item(1);
    thickLine.getFillFormat().setFillType(FillType.Solid);
    thickLine.getFillFormat().getSolidFillColor().setColor(new Color(139, 0, 0));
    thickLine.setWidth(12);

    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();
    IAutoShape left = shapes.addAutoShape(ShapeType.Rectangle, 100, 205, 200, 130);
    IAutoShape right = shapes.addAutoShape(ShapeType.Rectangle, 420, 205, 200, 130);
    left.getShapeStyle().setFillStyleIndex((short) 1);
    right.getShapeStyle().setFillStyleIndex((short) 2);
    left.getShapeStyle().setLineStyleIndex(1);
    right.getShapeStyle().setLineStyleIndex(1);
    presentation.save("01-initial.pptx", SaveFormat.Pptx);

    right.getShapeStyle().setLineStyleIndex(2);
    presentation.save("02-line-changed.pptx", SaveFormat.Pptx);

    goldFill.getSolidFillColor().setColor(new Color(46, 139, 87));
    presentation.save("03-theme-changed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Kezdeti stílusok | Jobb körvonal módosítása | Első téma‑kitöltés szerkesztése |
|:---:|:---:|:---:|
| ![Arany és égkék téglalapok egyező vékony sötétkék körvonallal](theme-style-initial.png) | ![Az égkék téglalap most vastag sötétvörös körvonallal rendelkezik](theme-style-line-changed.png) | ![A bal téglalap most zöld, a körvonalak változatlanok](theme-style-fill-changed.png) |

Különböző vonal‑stílus kiválasztása csak a jobb téglalap körvonalát változtatja. Az első téma‑kitöltés szerkesztése minden, azt használó alakzatot frissít. Itt csak a bal téglalap válik zöldre.

Egy meglévő alakzaton a helyi kitöltési szín, vonalszín vagy vonalvastagság felülírhatja a téma‑stílus azon részét. Ha a stílus‑index módosítása nem hoz változást, ellenőrizze az alakzat [direct formatting](/slides/hu/java/shape-formatting/) beállításait.

## **A hatékony szilárd kitöltés téma‑szín használatának meghatározása**

A kitöltés tárolhatja közvetlenül az objektumon, vagy örökölheti egy bekezdéstől, elrendezéstől, mestertől, téma‑stílustól vagy egyéb formázási szinttől. Hívja a [IFillFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/)‑t, hogy ezt a hierarchiát egy változhatatlan [IFillFormatEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformateffectivedata/) objektummá alakítsa. Először ellenőrizze a [IFillFormatEffectiveData.getFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformateffectivedata/) értékét. Csak ha az `FillType.Solid`, olvassa a szilárd‑kitöltés tulajdonságait.

Szilárd kitöltés esetén a [IFillFormatEffectiveData.getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformateffectivedata/) visszaadja a végső renderelt RGB‑értéket az öröklődés, téma‑keresés és szín‑transzformációk után. A [IFillFormatEffectiveData.getSolidFillSchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformateffectivedata/) visszaadja a megfelelő logikai [SchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/schemecolor/) slotot, például `Text1` vagy `Accent6`. A `SchemeColor.NotDefined` érték azt jelenti, hogy a hatékony szilárd kitöltés nem alapul séma‑színen. Egy olyan munkafolyamatban, ahol a kitöltések csak téma‑színek vagy közvetlen RGB‑színek, ez az érték egy közvetlen RGB‑kitöltést jelez.

Ne csak a helyi [IColorFormat.getSchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/) értéket használja a kitöltés osztályozásához. Például egy szövegrésznek nincs helyi séma‑színe (`NotDefined`), ugyanakkor a hatékony kitöltése egy téma‑színet örökölheti, és `Text1` vagy `Accent6`‑ra feloldódik. Ezzel szemben a `getSolidFillSchemeColor` megmondja, mely logikai téma‑slot hozta létre a hatékony színt, de nem jelzi, hogy ez a slot az objektumból, bekezdésből, elrendezésből, mesterből vagy más szintből származik.

Az alábbi példa betölti egy prezentációt, auditálja mind az alakzat‑kitöltéseket, mind a szövegrész‑kitöltéseket, kiír minden végső RGB‑értéket és a hozzá tartozó séma‑színt, valamint megjelöli azokat a szilárd kitöltéseket, amelyek nem követik a téma‑szín változásait:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.util.function.BiConsumer;

BiConsumer<String, IFillFormat> auditFill = (objectName, localFill) -> {
    IFillFormatEffectiveData effectiveFill = localFill.getEffective();

    if (effectiveFill.getFillType() != FillType.Solid) {
        System.out.println(objectName + ": fill type = " + effectiveFill.getFillType() + "; not a solid fill.");
        return;
    }

    Color rgb = effectiveFill.getSolidFillColor();
    int effectiveSchemeColor = effectiveFill.getSolidFillSchemeColor();
    int localSchemeColor = localFill.getSolidFillColor().getSchemeColor();

    System.out.printf("%s: RGB = #%02X%02X%02X%n", objectName, rgb.getRed(), rgb.getGreen(), rgb.getBlue());
    System.out.println(objectName + ": local scheme = " + localSchemeColor + ", effective scheme = " + effectiveSchemeColor);

    if (effectiveSchemeColor == SchemeColor.NotDefined) {
        System.out.println(objectName + ": direct RGB or another non-scheme fill; audit as theme-independent.");
    } else {
        System.out.println(objectName + ": theme-dependent through " + effectiveSchemeColor + ".");
    }
};

Presentation presentation = new Presentation("input.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);

        int shapeCount = slide.getShapes().size();
        for (int shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
            IShape shape = slide.getShapes().get_Item(shapeIndex);
            String shapeName = "Slide " + (slideIndex + 1) + ", shape " + (shapeIndex + 1);
            auditFill.accept(shapeName, shape.getFillFormat());

            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                int paragraphCount = autoShape.getTextFrame().getParagraphs().getCount();
                for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(paragraphIndex);

                    int portionCount = paragraph.getPortions().getCount();
                    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                        IPortion portion = paragraph.getPortions().get_Item(portionIndex);
                        String portionName = shapeName + ", paragraph " + (paragraphIndex + 1) + ", portion " + (portionIndex + 1);
                        auditFill.accept(portionName, portion.getPortionFormat().getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

A `NotDefined` ág egy audit‑listát ad a szilárd kitöltésekről, amelyek nem reagálnak a téma‑szín slotok változására. Tekintse át ezeket az objektumokat, ha a prezentációnak új márkára kell váltania. A jelentett RGB‑érték továbbra is a jelenlegi megjelenést mutatja, míg a séma‑érték magyarázza, hogy ez a megjelenés kapcsolódik-e a témához.

A hatékony‑formatum objektumok pillanatfelvételek. A prezentáció témájának, egy téma‑felülírásnak vagy bármely örökölt formázás módosítása után hívja újra a `getEffective`‑et, és olvassa a friss [IFillFormatEffectiveData] objektumot az összehasonlítás vagy jelentés előtt.

## **Hatékony témaértékek olvasása**

A nyers témaobjektumok azt mutatják, hogy mi van definiálva egy adott szinten. A hatékony értékek azt mutatják, hogy egy dia vagy alakzat valójában mit használ az öröklődés és a helyi felülírások feloldása után. Diához a [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/java/com.aspose.slides/baseoverridethememanager/) hívható. Háttérhez a [Background.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/background/), kitöltéshez pedig a [FillFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/).

Az alábbi példa beolvassa a hatékony témát, a háttér‑stílust és az első alakzat kitöltését egy diáról:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IThemeEffectiveData effectiveTheme = slide.getThemeManager().createThemeEffective();
    IBackgroundEffectiveData effectiveBackground = slide.getBackground().getEffective();

    System.out.println("Effective major Latin font: " + effectiveTheme.getFontScheme().getMajor().getLatinFont().getFontName());
    System.out.println("Effective minor Latin font: " + effectiveTheme.getFontScheme().getMinor().getLatinFont().getFontName());
    System.out.println("Effective background fill type: " + effectiveBackground.getFillFormat().getFillType());

    if (slide.getShapes().size() > 0) {
        IFillFormatEffectiveData effectiveFill = slide.getShapes().get_Item(0).getFillFormat().getEffective();
        System.out.println("First shape effective fill type: " + effectiveFill.getFillType());
        if (effectiveFill.getFillType() == FillType.Solid) {
            System.out.println("First shape effective fill color: " + effectiveFill.getSolidFillColor());
        }
    }
} finally {
    presentation.dispose();
}
```

Használja a hatékony adatokat render‑diagnosztikához, validációhoz és összehasonlításokhoz. Ha csak a [Presentation.getMasterTheme](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)‑t vizsgálja, kihagyhat egy mester‑, elrendezés‑, dia‑ vagy alakzat‑felülírást, amely megváltoztatja a végső megjelenést.

## **GYIK**

**Az externe téma alkalmazása minden diára hat a prezentációban?**

Nem. Az [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/) csak azoknak a diáknak a mesterét rendeli újra, amelyek a kiválasztott mesterhez tartoznak. Más mestereket használó diák megtartják meglévő témáikat.

**Alkalmazhatok egy témát egyetlen diára anélkül, hogy a mestert módosítanám?**

Igen. Használja a dia [SlideThemeManager](https://reference.aspose.com/slides/java/com.aspose.slides/slidethememanager/)‑ét, és inicializálja a felülírási témát. A változás csak arra a diara vonatkozik; a többi dia továbbra is a meglévő témáit örökli.

**Mi a legbiztonságosabb módja egy téma átvitelének egy prezentációból a másikba?**

Diák áthelyezésekor és a forrás‑megjelenés megőrzésekor klónozza a forrás‑mestert a célba, majd a diát a mesterrel együtt klónozza a [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/) és a [ISlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/) segítségével. Így a mester, az elrendezések és a téma együtt marad.

**Hogyan tekinthetem meg a hatékony értékeket az öröklődés és felülírások után?**

Használja a [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/java/com.aspose.slides/baseoverridethememanager/)‑t egy dia vagy elrendezés téma esetén, valamint a megfelelő hatékony‑adat metódusokat a formátumobjektumokhoz, mint a [Background.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/background/) és a [FillFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/). Ezek az API‑k az öröklődés és felülírások után feloldott értékeket adják vissza.