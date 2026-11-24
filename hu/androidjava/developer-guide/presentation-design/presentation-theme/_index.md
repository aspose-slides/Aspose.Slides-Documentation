---
title: Prezentációs témák kezelése Androidon
linktitle: Prezentációs téma
type: docs
weight: 10
url: /hu/androidjava/presentation-theme/
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
- Android
- Java
- Aspose.Slides
description: "Az Aspose.Slides for Android Java-on keresztül a fő prezentációs témák kezelése a PowerPoint fájlok egységes márkázással történő létrehozásához, testreszabásához és konvertálásához."
---
## **Bevezetés**

A prezentációs téma egy összehangolt szín-, betűtípus-, háttérstílus-, kitöltés-, vonal- és effektus-készletet határoz meg. A témával kompatibilis objektumok ezeket a megosztott definíciókat hivatkozzák ahelyett, hogy minden vizuális tulajdonságot rögzített értékként tárolnának, így egy téma módosítása egyszerre sok objektumot frissíthet.

Az Aspose.Slides-ben a prezentáció szintű téma elérhető a [Presentation.getMasterTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) segítségével. A prezentáció alacsonyabb szinteken is tartalmazhat téma felülbírálókat. A master felülbírálhatja a prezentáció témát a [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/masterthememanager/) segítségével, míg egy elrendezés vagy egy egyedi dia felülbírálhatja az örökölt témát a [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseoverridethememanager/) segítségével. Gyakorlatban a dia hatékony témája ezen öröklődési láncon keresztül határozható meg: prezentációs téma, master felülbírálás, elrendezés felülbírálás és dia felülbírálás.

![Téma összetevők: színek, betűtípusok, háttérstílusok és effektusok](theme-constituents.png)

Az alábbi szakaszok a leggyakoribb téma munkafolyamatokat mutatják be: egy téma ellenőrzése, színek és betűkészletek módosítása, téma másolása vagy alkalmazása, háttér- és effektusstílusok frissítése, valamint az öröklődés és felülbírálások után kapott hatékony értékek kiolvasása.

## **Egy Téma Ellenőrzése**

A [MasterTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/) objektum a téma színsémáját, betűkészletét és formátumsémáját teszi elérhetővé a [MasterTheme.getColorScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/), a [MasterTheme.getFontScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/) és a [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/) segítségével. Ezeknek a gyűjteményeknek az ellenőrzése a módosítások előtt különösen hasznos, ha a prezentáció külső forrásból származik, mivel a stílustelemek száma és tartalma változhat.

Az alábbi példa beolvassa a fő téma tulajdonságait, és jelentést készít arról, hogy hány háttér-, kitöltés-, vonal- és effektus-stílus van tárolva a témában:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterTheme theme = presentation.getMasterTheme();
    int accent1 = theme.getColorScheme().getAccent1().getColor();
    
    System.out.println("Theme name: " + theme.getName());
    System.out.println(String.format("Accent 1: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(accent1), Color.red(accent1), Color.green(accent1), Color.blue(accent1)));
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

Ha egy fájl több masterrel rendelkezik, ne feltételezze, hogy minden dia ugyanazzal a hatékony témával rendelkezik. Ellenőrizze a diához tartozó mastert, és használja az alább bemutatott hatékony téma munkafolyamatot, ha elrendezési vagy dia felülbírálások lehetnek jelen.

## **Téma Színeinek Módosítása**

A témával kompatibilis kitöltések, vonalak és szöveg hivatkozhat logikai színre a [SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/schemecolor/) felsorolásból. Ha módosítja a megfelelő bejegyzést az [IColorScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorscheme/) gyűjteményben, minden objektum, amely még mindig a témaszínre hivatkozik, az új értékre lesz feloldva. Azok az objektumok, amelyek közvetlen RGB színt használnak, nem változnak meg a téma‑szín frissítésekor.

Az alábbi vég‑vég példában egy alakzatot hozunk létre, amely az `Accent4` színt használja, megváltoztatjuk a téma `Accent4` színét pirosra, elmentjük a prezentációt, újra megnyitjuk, és kiírjuk a hatékony kitöltési színt:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int effectiveColor = effectiveFill.getSolidFillColor();
    System.out.println(String.format("Effective fill color: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(effectiveColor), Color.red(effectiveColor), Color.green(effectiveColor), Color.blue(effectiveColor)));
} finally {
    savedPresentation.dispose();
}
```

Mivel a téglalap továbbra is az `Accent4` színhez van kötve, látható színe pirosra változik a téma módosítása után. Ha a képlet színét közvetlen színnel helyettesíti, a későbbi `Accent4` változtatások már nem befolyásolják azt a kitöltést.

### **Színek Használata a Kiegészítő Palettából**

A PowerPoint könnyebb és sötétebb változatokat származtat a téma színéből színtranszformációk alkalmazásával. Az Aspose.Slides ezeket a transzformációkat a [ColorTransformOperation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/colortransformoperation/) felsorolásban teszi elérhetővé.

![Fő téma színek és a kiegészítő palettából generált könnyebb és sötétebb színek](additional-palette-colors.png)

**1** – Fő téma színek.

**2** – A fő téma színekből előállított könnyebb és sötétebb változatok.

Az alábbi példa hat téglalapot hoz létre az `Accent4` alapjan, ötötön színtranszformációt alkalmaz, és elmenti az eredményt:

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

Ezek a változatok a téma színre épülnek. Ha később az `Accent4` megváltozik, a transzformált színek az új `Accent4` értékből újraszámításra kerülnek.

### **A `SchemeColor` Értékek Leképezése az `IColorScheme` Foglalatokra**

A [SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/schemecolor/) felsorolás a `Text1`, `Background1`, `Text2` és `Background2` mezőket használja, míg az [IColorScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorscheme/) ugyanazokat a témahelyeket `Dark1`, `Light1`, `Dark2` és `Light2` néven teszi elérhetővé. A leképezés rögzített:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Ezek ugyanazon témahelyek alternatív nevei; nem dinamikusan konvertált értékek.

## **Téma Betűkészletek Módosítása**

A téma betűkészlet tartalmaz egy fő betűkészletet a címsorokhoz és egy kisebb betűkészletet a törzsszöveghez. Az [IFontScheme.getMajor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontscheme/) és az [IFontScheme.getMinor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontscheme/) metódusok teszik ezeket elérhetővé.

A PowerPoint‑kompatibilis téma betűazonosítók a szövegformázásban használhatók:

* `+mn-lt` – Body Font Latin (Minor Latin Font)
* `+mj-lt` – Heading Font Latin (Major Latin Font)
* `+mn-ea` – Body Font East Asian (Minor East Asian Font)
* `+mj-ea` – Heading Font East Asian (Major East Asian Font)
* `+mn-cs` – Body Font Complex Script (Minor Complex Script Font)
* `+mj-cs` – Heading Font Complex Script (Major Complex Script Font)

Az alábbi példa egy címsort hoz létre, amely a fő Latin téma betűt használ, és egy törzssort, amely a kisebb Latin téma betűt használja. Ezután módosítja a téma betűkészleteket és elmenti az eredményt:

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

A címsor a fő betűt, a törzsszöveg a kisebb betűt követi. A kifejezett betűnévvel ellátott szöveg nem vált automatikusan, ha a téma betűkészlete megváltozik.

A fő és kisebb betűgyűjtemények tartalmazhatnak betűtérképezéseket egyedi írásrendszerekhez, például cirill, arab, japán, grúz és thaana. Ezek ellenőrzéséhez, hozzáadásához, cseréjéhez vagy eltávolításához lásd a [Script‑Specific Theme Fonts](/slides/hu/androidjava/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
További információért a prezentáció betűtípusairól, lásd [PowerPoint Fonts](/slides/hu/androidjava/powerpoint-fonts/).
{{% /alert %}}

### **Téma Betűhivatkozások Feloldása**

Szöveg ellenőrzésekor az [IFontData.getFontName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontdata/#getFontName--) visszaadhat egy témahivatkozást, például `+mn-lt`, a betűcsalád neve helyett. Hívja az [IFontData.getFontName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontdata/#getFontName-com.aspose.slides.IThemeEffectiveData-) metódust a megfelelő [IThemeEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithemeeffectivedata/) objektummal a hivatkozás feloldásához. A `+mj` és `+mn` előtagok a fő és kisebb betűkészleteket választják; a `-lt`, `-ea` és `-cs` utótagok a latin, kelet‑ázsiai és komplex szkript betűket jelölik.

Szerezze be a hatékony témát a [IThemeable.createThemeEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithemeable/#createThemeEffective--) metódussal azon objektumon, amelynek témája az ellenőrzött szövegre vonatkozik. Általános szövegnél egy dián hívja ezt a metódust, hogy a kontextus tartalmazza a dia örökölt témáját és helyi felülbírálásait. Elrendezés vagy master ellenőrzésekor használja annak saját hatékony témáját. Ne feltételezze, hogy az első master témája minden diára vonatkozik.

Az alábbi példa egy szövegrészt hoz létre, amely kifejezetten a kisebb Latin betűre hivatkozik. A [IOverrideTheme.initFontSchemeFromInherited](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioverridetheme/#initFontSchemeFromInherited--) segítségével inicializál egy dia betűkészletet, és beállítja a fő és kisebb Latin családokat `Arial`‑ra és `Calibri`‑ra, így az eredmény bemeneti fájl nélkül reprodukálható.

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

A kimenet `+mn-lt -> Calibri` lesz, majd `Verdana -> Verdana`. A tárolt hivatkozás változatlan marad, míg a kifejezett családnevet változatlanul visszaadja. Ha a rész `+mj-lt`-t használna, akkor ebben a témában `Arial`-ra oldódna fel.

A téma hivatkozás feloldása meghatározza a téma által megadott betűcsaládot. Nem ellenőrzi a betű elérhetőségét vagy a helyettesítési / glyph fallback folyamatot. Lásd a [Font Selection Sequence](/slides/hu/androidjava/font-selection-sequence/) és a [Font Substitution](/slides/hu/androidjava/font-substitution/) oldalakat a külön lépésekhez.

## **Téma Másolása vagy Alkalmazása**

Az alábbi munkafolyamatok különböző téma‑kapcsolódó problémákat oldanak meg.

### **Külső Téma Alkalmazása Egy Master Függő Diákra**

Használja a [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/) metódust, ha egy PowerPoint témafájlt (`.thmx`) szeretne alkalmazni, és minden, a megadott mastertől függő diát újraformázni. Válassza ki a mastert a [Presentation.getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) gyűjteményből, amely a [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/) interfészt valósítja, és adja át a témafájlt az úthoz.

A metódus a következő műveleteket hajtja végre:

1. Létrehoz egy új master diát a kiválasztott master alapján.
1. Alkalmazza a külső témát az új masterre.
1. A korábban a kiválasztott masterhez tartozó diákra rendeli az új mastert.
1. Visszaadja az újonnan létrehozott [IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/) objektumot.

Az alábbi példa egy külső témát alkalmaz a első masterhez tartozó diákra, majd elmenti a prezentációt:

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

Érvénytelen, sérült vagy nem támogatott téma [PptxReadException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxreadexception/)-t okozhat. Ellenőrizze a felhasználók által megadott útvonalakat, kezelje a fájlrendszer‑hozzáférési hibákat, és csak a téma sikeres alkalmazása után mentse a prezentációt.

Csak a kiválasztott masterhez tartozó diák kerülnek újraosztásra. Más masterekhez tartozó diák megtartják meglévő masterüket és témájukat. A témalapú színek, betűk, kitöltések, vonalak, háttér és effektusok a külső témához igazodnak. A közvetlenül hozzárendelt színek, betűk, kitöltések és egyéb explicit formázás változatlan maradhat. Az elrendezés‑ és dia‑szintű felülbírálások szintén felülírhatják az új mastertől örökölt értékeket.

A téma olyan betűket hivatkozhat, amelyek nincsenek telepítve a futtatási környezetben. A következetes renderelés és export érdekében telepítse a szükséges betűket, biztosítsa őket a [custom font sources](/slides/hu/androidjava/custom-font/) segítségével, vagy konfigurálja a [font substitution](/slides/hu/androidjava/font-substitution/) beállításokat.

Ez egy közvetlen master‑szintű munkafolyamat: a metódus egy `.thmx` fájl elérési útját várja, és nem igényel manuális dia‑ vagy elrendezés‑szintű téma felülbírálás létrehozását.

### **Különböző Külső Témák Alkalmazása Több‑Masteres Prezentációban**

Ha a releváns master előre nem ismert, szerezze be egy reprezentatív dia segítségével a [ISlide.getLayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/) és a [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutslide/) metódusokkal. Tárolja az eredeti master hivatkozásokat a témák alkalmazása előtt, mivel minden hívás egy új mastert hoz létre a prezentációban.

Az alábbi példa két szekció diáit használja a masterek megtalálásához, és minden csoporthoz külön külső témát alkalmaz:

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

Az első hívás csak a `firstGroupMaster`‑hez tartozó diákra hat, a második csak a `secondGroupMaster`‑hez tartozó diákra. A többi masterhez tartozó diákok nincsenek újraformázva.

### **Forrástéma Megőrzése Diákok Mozgatása Közben**

Ha egy diát másik prezentációba szeretne mozgatni, miközben megőrizné az eredeti megjelenést, klónozza a forrás mastert a célprezentációba a [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/) segítségével, majd klónozza a diát a [ISlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/) és a klónozott master segítségével. Így a master, az elrendezései és a kapcsolódó téma együtt kerül átvitelre.

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

Ez a preferált munkafolyamat, ha a forrás dia megjelenésének változatlanságát szeretné a célban. A tartalom egyszerű klónozása egy nem kapcsolódó cél‑masterre megváltoztathatja a téma‑alapú színeket, betűket, háttereket és effektusokat.

### **Téma Értékek Alkalmazása Egy Létező Diára**

Ha a cél dia a saját masterén és elrendezésén marad, inicializáljon egy dia‑szintű felülbírálást a forrástémából. A [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/), a [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/) és a [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/) metódusok a három fő témaösszetevőt másolják a felülbírálásba.

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = target.getSlides().get_Item(0);

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

Ez megváltoztatja a dia által használt témát anélkül, hogy a többi dia örökölt témáját módosítaná. A helyi felülbírálás eltávolításához és az örökölt értékek visszaállításához hívja a [OverrideTheme.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/) metódust.

### **Téma Felülbírálás Alkalmazása Egy Elrendezésre**

Egy elrendezés‑szintű felülbírálás az arra épülő diákra vonatkozik, kivéve ha egy adott dia saját felülbírálással rendelkezik. Ugyanezeket az inicializáló metódusokat használhatja a [LayoutSlideThemeManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/layoutslidethememanager/) segítségével:

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = target.getSlides().get_Item(0);

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

Használjon master vagy prezentáció‑szintű témát, ha sok elrendezésnek és diának közös alapdizájnra van szüksége, elrendezés‑felülbírálást, ha egy elrendezéscsaládnak más stílusra van szüksége, és dia‑felülbírálást csak valódi kivételekhez. A túlzott dia‑szintű felülbírálások nehezebbé teszik a későbbi globális téma‑változtatások előrejelzését.


<!-- visual-explanation:presentation-theme:start -->
[![A master theme feeds two layouts; a layout override affects its slides except a slide with a more local override.](visual-presentation-theme-20ad12f2193b.svg)](visual-presentation-theme-20ad12f2193b.svg)

*A layout override applies to slides using that layout unless a slide supplies its own override. Theme-based values follow their resolved scheme; explicitly formatted objects can retain their local appearance. Keep overrides as narrow as the intended design exception.*
<!-- visual-explanation:presentation-theme:end -->

## **Téma Háttérstílusainak Frissítése**

A téma háttérkitöltései az [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/) gyűjteményben tárolódnak. A PowerPoint a felhasználói felületén több háttérválasztékot jeleníthet meg, mint ahány kitöltés‑definíció fizikailag tárolva van ebben a gyűjteményben, mivel a UI kombinálhat téma‑kitöltéseket téma‑színekkel és más stílushivatkozásokkal.

![PowerPoint háttérstílus galéria egy prezentációs témához](presentation-design_8.png)

Mielőtt háttérstílust használna, ellenőrizze a tárolt gyűjteményt és az aktuális [Background.getStyleIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/) értéket. A `0` stílusindex azt jelenti, hogy nincs téma‑kitöltés; a pozitív értékek a téma háttér‑stílus‑hivatkozások. Ez eltér a Java gyűjtemény közvetlen indexelésétől, ahol a `get_Item(0)` az első tárolt elemet jelenti. Ne feltételezze, hogy minden prezentáció ugyanannyi háttér‑kitöltési stílussal rendelkezik.

Az alábbi példa jelenti, hogy hány háttér‑kitöltés áll rendelkezésre, egy témához rendeli a tematizált háttér‑hivatkozást az első masterhez, és elmenti a prezentációt:

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

A látható eredmény a master által hivatkozott téma bejegyzéstől és az elrendezés‑ vagy dia‑szintű háttér‑felülbírálásoktól függ. Ha egy dia saját háttérrel rendelkezik, csak a master háttér módosítása nem feltétlenül változtatja meg azt a diát. Használja a [Background.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/) metódust, ha a végső háttérre van szüksége az öröklődés után.

{{% alert color="warning" title="Warning" %}}
Ne kezelje a stílusindexet null‑alapú gyűjtemény‑indexként. Kerülje a egy fájlból származó számból származó index hard‑kódolását és annak más fájlban való használatát; a téma‑stílusdefiníciók prezentáció‑specifikusak.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Közvetlen háttér‑formázáshoz és háttér‑öröklődéshez lásd a [Presentation Background](/slides/hu/androidjava/presentation-background/).
{{% /alert %}}

## **Téma Efektusainak Frissítése**

A téma formátumsémája külön kitöltés‑, vonal‑ és effektus‑stílus‑gyűjteményeket tartalmaz, amelyeket a [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/), a [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/) és a [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/) metódusok tesznek elérhetővé. A tipikus Office‑témák gyakran három fő stílusbejegyzést tartalmaznak, amelyek vizuálisan a finom, közepes és intenzív formázásnak felelnek meg, de a kódnak minden gyűjteményt ellenőriznie kell, és nem szabad rögzített számra feltételezni.

![Finom, közepes és intenzív témaeffektusok ugyanazon alakzaton](presentation-design_10.png)

Java‑ban a gyűjtemény‑index nulla‑alapú: a `get_Item(0)` az első tárolt stílus, a `get_Item(2)` a harmadik. Egy alakzat stílushivatkozási indexei egy külön koncepció, amelyet az [IShapeStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapestyle/) tesz elérhetővé. Egy téma‑stílus módosítása azokra az alakzatokra hat, amelyek hivatkoznak arra a téma‑stílusra; a közvetlen formázású alakzatok változatlanok maradhatnak.

Az alábbi példa ellenőrzi, hogy a szükséges stílusbejegyzések léteznek, módosítja az első vonal‑stílust, a harmadik kitöltés‑stílust, aktivál egy külső árnyékot a harmadik effektus‑stílusban, majd elmenti az eredményt:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    IFormatScheme formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new IllegalStateException("The theme does not contain the style entries required by this example.");
    }
    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid);
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);
    formatScheme.getFillStyles().get_Item(2).setFillType(FillType.Solid);
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(Color.rgb(34, 139, 34));
    IEffectFormat effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10f);

    presentation.save("theme-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az ezekre a helyekre hivatkozó alakzatok esetén az első téma‑vonal‑stílus pirosra változik, a harmadik téma‑kitöltés‑stílus szilárd erdegbarnára, és a harmadik effektus‑stílus egy 10 pont távolságú külső árnyékot kap. A pontos vizuális eredmény továbbra is függ attól, hogy melyik stílushelyet hivatkozza az egyes alakzat, és hogy a közvetlen formázás felülbírálja-e a témát.

![Téma effektus‑stílusok a vonal, kitöltés és árnyék beállítások módosítása után](presentation-design_11.png)

## **Alakzat Kitöltés‑ és Vonal‑Stílusainak Kiválasztása a Témában**

Egy alakzat függetlenül választhat kitöltést és körvonalat a [IShapeStyle.setFillStyleIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapestyle/#setFillStyleIndex-short-) és a [IShapeStyle.setLineStyleIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapestyle/#setLineStyleIndex-int-) metódusokkal. Mindkét esetben az `1` index a megfelelő téma‑gyűjtemény első bejegyzését (`get_Item(0)`) jelenti, a `2` index a másodikat (`get_Item(1)`).

Az alábbi példa két kitöltés‑stílust (arany és égkék) és két vonal‑stílust (sötétkék 6 pt‑ben és sötétvörös 12 pt‑ben) hoz létre egy új prezentáció alap‑témájában. A diát három állapotban menti, hogy a PowerPoint‑ben összehasonlíthassa az eredményeket.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IFormatScheme styles = presentation.getMasterTheme().getFormatScheme();

    IFillFormat goldFill = styles.getFillStyles().get_Item(0);
    goldFill.setFillType(FillType.Solid);
    goldFill.getSolidFillColor().setColor(Color.rgb(255, 215, 0));
    IFillFormat blueFill = styles.getFillStyles().get_Item(1);
    blueFill.setFillType(FillType.Solid);
    blueFill.getSolidFillColor().setColor(Color.rgb(135, 206, 235));

    ILineFormat thinLine = styles.getLineStyles().get_Item(0);
    thinLine.getFillFormat().setFillType(FillType.Solid);
    thinLine.getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
    thinLine.setWidth(6);
    ILineFormat thickLine = styles.getLineStyles().get_Item(1);
    thickLine.getFillFormat().setFillType(FillType.Solid);
    thickLine.getFillFormat().getSolidFillColor().setColor(Color.rgb(139, 0, 0));
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

    goldFill.getSolidFillColor().setColor(Color.rgb(46, 139, 87));
    presentation.save("03-theme-changed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Kezdeti stílusok | A jobb körvonal módosítása | Az első téma kitöltés szerkesztése |
|:---:|:---:|:---:|
| ![Arany és égkék téglalapok illeszkedő vékony sötétkék körvonallal](theme-style-initial.png) | ![Az égkék téglalap most vastag sötétvörös körvonallal rendelkezik](theme-style-line-changed.png) | ![A bal téglalap most zöld, a körvonalak változatlanok](theme-style-fill-changed.png) |

Egy másik vonal‑stílus kiválasztása csak a jobb téglalap körvonalát módosítja. Az első téma‑kitöltés szerkesztése minden olyan alakzatra hat, amely azt használja; itt csak a bal téglalap lesz zöld.

Egy meglévő alakzaton a helyi kitöltő‑szín, vonal‑szín vagy vonal‑vastagság felülbírálhatja a téma‑stílus ezen részét. Ha egy stílus‑index módosítása nem hoz látható változást, ellenőrizze az alakzat [direct formatting](/slides/hu/androidjava/shape-formatting/) beállításait.

## **Megállapítás, Hogy a Hatékony Szilárd Kitöltés Téma‑Színt Használ-e**

Egy kitöltés tárolható közvetlenül egy objektumon vagy örökölhető bekezdésből, elrendezésből, masterből, téma‑stílusból vagy más formázási szintről. Hívja a [IFillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/) metódust, hogy a hierarchiát egy változtathatatlan [IFillFormatEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/) objektumba feloldja. Először ellenőrizze az [IFillFormatEffectiveData.getFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/) értékét. Csak akkor olvassa a szilárd‑kitöltés tulajdonságait, ha az `FillType.Solid`.

Szilárd kitöltés esetén a [IFillFormatEffectiveData.getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/) visszaadja a végső renderelt RGB értéket az öröklődés, téma‑keresés és színtranszformációk alkalmazása után. A [IFillFormatEffectiveData.getSolidFillSchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/) a megfelelő logikai [SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/schemecolor/) helyet adja vissza, például `Text1` vagy `Accent6`. A `SchemeColor.NotDefined` érték azt jelenti, hogy a hatékony szilárd kitöltés nem egy sémaszín alapján van.

Ne csak a helyi [IColorFormat.getSchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/) értéket használja egy kitöltés osztályozásához. Például egy szövegrésznek lehet nincs helyi sémaszíne (`NotDefined`), miközben a hatékony kitöltése egy téma‑színt örököl és `Text1`‑re vagy `Accent6`‑ra oldódik fel. Ezzel szemben a `getSolidFillSchemeColor` megmondja, melyik logikai témahely állította elő a hatékony színt, de nem jelzi, hogy a hely a objektumból, bekezdésből, elrendezésből, masterből vagy más szintről származik.

Az alábbi példa betölti egy prezentációt, auditálja a forma‑ és szövegrész‑kitöltéseket, kiírja minden végső RGB értéket és a kapcsolódó sémaszínt, valamint jelzi azokat a szilárd kitöltéseket, amelyek nem követik a téma‑szín változásait:

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.util.function.BiConsumer;

BiConsumer<String, IFillFormat> auditFill = (objectName, localFill) -> {
    IFillFormatEffectiveData effectiveFill = localFill.getEffective();

    if (effectiveFill.getFillType() != FillType.Solid) {
        System.out.println(objectName + ": fill type = " + effectiveFill.getFillType() + "; not a solid fill.");
        return;
    }

    int rgb = effectiveFill.getSolidFillColor();
    int effectiveSchemeColor = effectiveFill.getSolidFillSchemeColor();
    int localSchemeColor = localFill.getSolidFillColor().getSchemeColor();

    System.out.printf("%s: RGB = #%02X%02X%02X%n", objectName, Color.red(rgb), Color.green(rgb), Color.blue(rgb));
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

A `NotDefined` ágba a szilárd kitöltések audit listája kerül, amelyek nem fognak reagálni a téma‑színhelyek változásaira. Tekintse át ezeket az objektumokat, ha egy prezentációnak új márkaszínpalettát kell követnie. A jelentett RGB érték továbbra is a jelenlegi megjelenést mutatja, míg a sémakód megmagyarázza, hogy ez a megjelenés kapcsolódik‑e a témához.

A hatékony‑formátum objektumok pillanatfelvételek. A prezentáció témájának, egy téma‑felülbírálásnak vagy bármely örökölt formázás módosítása után hívja újra a `getEffective`‑et, és olvassa be az új `IFillFormatEffectiveData` objektumot a színek összehasonlítása vagy jelentése előtt.

## **Hatékony Témaértékek Kiolvasása**

A nyers témaobjektumok megmutatják, mi van meghatározva egy adott szinten. A hatékony értékek azt mutatják, amit egy dia vagy alakzat valójában használ az öröklődés és helyi felülbírálások feloldása után. Egy dia esetén hívja a [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseoverridethememanager/). Háttérhez használja a [Background.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/), kitöltéshez a [FillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/).

Az alábbi példa kiolvassa a hatékony témát, a háttért és az első alakzat kitöltését egy diáról:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
            int effectiveColor = effectiveFill.getSolidFillColor();
            System.out.println(String.format("First shape effective fill color: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(effectiveColor), Color.red(effectiveColor), Color.green(effectiveColor), Color.blue(effectiveColor)));
        }
    }
} finally {
    presentation.dispose();
}
```

Használja a hatékony adatokat diagnosztikához, validáláshoz és összehasonlításhoz. Ha csak a [Presentation.getMasterTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) metódust ellenőrzi, kihagyhat egy master, elrendezés, dia vagy alakzat felülbírálást, amely megváltoztatja a végső megjelenést.

## **GYIK**

**Érint-e egy külső téma minden diát a prezentációban?**

Nem. Az [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/) csak a kiválasztott masterhez tartozó diákat rendeli újra. A más mastereket használó diák megtartják meglévő témájukat.

**Alkalmazhatok-e témát egyetlen diára a master megváltoztatása nélkül?**

Igen. Használja a dia [SlideThemeManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidethememanager/)‑t, és inicializálja annak felülbíráló témáját. A változás csak az adott diára hat, a többi dia továbbra is a meglévő témáját örökli.

**Mi a legbiztonságosabb módja egy téma átvitelének egy prezentációból a másikba?**

Diák áthelyezésekor és a forrásmegjelenés megőrzésekor klónozza a forrás mastert a célba, és klónozza a diát azzal a masterrel a [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/) és a [ISlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/) segítségével. Így a master, elrendezések és téma együtt marad.

**Hogyan tekinthetem meg a hatékony értékeket az öröklődés és felülbírálások után?**

Használja a [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseoverridethememanager/) egy dia vagy elrendezés témához, és a megfelelő hatékony‑adat metódusokat a formátumobjektumokhoz, például a [Background.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/) és a [FillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/). Ezek az API‑k az öröklődés és felülbírálások után feloldott értékeket adják vissza.