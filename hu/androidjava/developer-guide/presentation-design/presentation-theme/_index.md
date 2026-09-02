---
title: Androidon a prezentációs sablonok kezelése
linktitle: Prezentációs téma
type: docs
weight: 10
url: /hu/androidjava/presentation-theme/
keywords:
- PowerPoint sablon
- prezentációs sablon
- dia sablon
- sablon beállítása
- sablon módosítása
- sablon kezelése
- külső sablon
- THMX
- sablon szín
- kiegészítő paletta
- sablon betűtípus
- sablon stílus
- sablon effektus
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Az Aspose.Slides for Android (Java) segítségével mester prezentációs sablonok kezelése, testreszabása és PowerPoint fájlok konvertálása egységes márkaarculattal."
---
## **Bevezetés**

A prezentációs sablon meghatározza a színek, betűtípusok, háttérstílusok, kitöltések, vonalak és effektusok koordinált készletét. A sablont használó objektumok ezekre a megosztott definíciókra hivatkoznak, ahelyett, hogy minden vizuális tulajdonságot rögzített értékként tárolnának, így egy sablonmódosítás egyszerre sok objektumot frissíthet.

Az Aspose.Slides-ban a prezentációszintű sablon a [Presentation.getMasterTheme](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) segítségével érhető el. A prezentáció alacsonyabb szinteken is tartalmazhat sablonfelülírásokat. Egy mester a prezentációs sablont felülírhatja a [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/masterthememanager/) segítségével, míg egy elrendezés vagy egy egyedi dia a saját örökölt sablonját felülírhatja a [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/baseoverridethememanager/) segítségével. Gyakorlatban egy dia hatékony sablonja ezt az öröklődési láncot követi: prezentációs sablon, mester felülírás, elrendezés felülírás és dia felülírás.

![Témaelemek: színek, betűtípusok, háttérstílusok és effektusok](theme-constituents.png)

Az alábbi szakaszok a leggyakoribb sablonmunkafolyamatokat mutatják be: sablon vizsgálata, színek és betűtípusok módosítása, sablon másolása vagy alkalmazása, háttér- és effektusstílusok frissítése, valamint az öröklődés és felülírások feloldása után kapott hatékony értékek olvasása.

## **Téma ellenőrzése**

A [MasterTheme](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/mastertheme/) objektum a sablon színsémáját, betűtípus sémáját és formátum sémáját teszi elérhetővé a [MasterTheme.getColorScheme](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/mastertheme/), a [MasterTheme.getFontScheme](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/mastertheme/) és a [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/mastertheme/) segítségével. Ezeknek a gyűjteményeknek a vizsgálata a módosításuk előtt különösen hasznos, ha a prezentáció külső forrásból származik, mivel a stíuselemenyek száma és tartalma változhat.

Az alábbi példa beolvassa a fő sablon tulajdonságait, és jelenti, hogy hány háttér-, kitöltés-, vonal- és effektusstílus van tárolva a sablonban:

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

Ha egy fájl több mestert használ, ne feltételezze, hogy minden dia ugyanazzal a hatékony sablonnal rendelkezik. Ellenőrizze a diára vonatkozó mestert, és használja a később ebben a cikkben bemutatott hatékony-sablon munkafolyamatot, ha elrendezés- vagy diaszintű felülírások lehetnek jelen.

## **Sablon színeinek módosítása**

A sablont használó kitöltések, vonalak és szöveg logikai színre hivatkozhat a [SchemeColor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/schemecolor/) felsorolásból. Amikor a megfelelő bejegyzést a [IColorScheme](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icolorscheme/) gyűjteményben módosítja, minden objektum, amely még mindig erre a sablonszínre hivatkozik, az új értékhez kerül. A közvetlen RGB-színt használó objektumok nem változnak meg egy sablonszín frissítésekor.

Az alábbi végponttól végpontig tartó példa egy `Accent4` színt használó alakzatot hoz létre, megváltoztatja a sablon `Accent4` színét pirosra, elmenti a prezentációt, újra megnyitja, és kiírja a hatékony kitöltőszínt:

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

Mivel a téglalap továbbra is a `Accent4`-hez van kapcsolva, látható színe piros lesz a sablon módosítása után. Ha a séma színt közvetlen színre cseréli az alakzaton, a későbbi `Accent4` módosítások már nem befolyásolják azt a kitöltést.

### **Színek használata a kiegészítő palettáról**

A PowerPoint a téma színéből világosabb és sötétebb variánsokat hoz létre színtranszformációk alkalmazásával. Az Aspose.Slides ezeket a transzformációkat a [ColorTransformOperation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/colortransformoperation/) felsoroláson keresztül teszi elérhetővé.

![Fő témaszínek és a kiegészítő palettából generált világosabb és sötétebb színek](additional-palette-colors.png)

**1** – Fő témaszínek.

**2** – A fő témaszínekből előállított világosabb és sötétebb változatok.

Az alábbi példa hat téglalapot hoz létre a `Accent4` alapján, ötötön luminancia-transzformációt alkalmaz, és elmenti az eredményt:

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

Ezek a variánsok a sablon színén alapulnak. Ha a `Accent4` később változik, a transzformált színek az új `Accent4` értékéből kerülnek újraszámításra.

### **A `SchemeColor` értékek leképezése az `IColorScheme` helyekre**

A [SchemeColor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/schemecolor/) felsorolás a `Text1`, `Background1`, `Text2` és `Background2` értékeket használja, míg az [IColorScheme](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icolorscheme/) a sablonhelyeket `Dark1`, `Light1`, `Dark2` és `Light2` néven teszi elérhetővé. A leképezés rögzített:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Ezek ugyanazon sablonhelyek alternatív elnevezései; nem dinamikusan konvertált értékek egyik formából a másikba.

## **Sablon betűtípusainak módosítása**

A sablon betűtípus sémája egy fő betűkészletet tartalmaz a címsorokhoz és egy kisebb betűkészletet a törzsszöveghez. Az [IFontScheme.getMajor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifontscheme/) és az [IFontScheme.getMinor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifontscheme/) metódusok ezeket a készleteket teszik elérhetővé.

A PowerPoint-kompatibilis sablon betűtípus azonosítók a szövegformázásban használhatók:

* `+mn-lt` – Body Font Latin (Kisebb latin betűkészlet)
* `+mj-lt` – Heading Font Latin (Nagy latin betűkészlet)
* `+mn-ea` – Body Font East Asian (Kisebb kelet-ázsiai betűkészlet)
* `+mj-ea` – Heading Font East Asian (Nagy kelet-ázsiai betűkészlet)

Az alábbi példa egy címsort hoz létre, amely a nagy latin sablonbetűt használja, és egy törzssort, amely a kis latin sablonbetűt használja. Ezután módosítja a sablon betűtípusait, és elmenti az eredményt:

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

A címsor a nagy betűtípust, a törzsszöveg a kis betűtípust követi. Az explicit betűtípusnévvel rendelkező szöveg nem vált automatikusan át, ha a sablon betűtípus sémája megváltozik.

A nagy- és kisbetűkészletek tartalmazhatnak betűtérképeket egyedi írásrendszerekhez, például cirill, arab, japán, grúz és thaana. Ezeknek a lekérdezéséhez, hozzáadásához, cseréjéhez vagy eltávolításához lásd a [Script-Specific Theme Fonts](/slides/hu/androidjava/script-specific-font-mappings/) oldalt.

{{% alert color="info" title="Tip" %}}
További információk a prezentáció betűtípusaival kapcsolatban a [PowerPoint Fonts](/slides/hu/androidjava/powerpoint-fonts/) szakaszban találhatók.
{{% /alert %}}

## **Sablon másolása vagy alkalmazása**

Az alábbi munkafolyamatok különböző sablonnal kapcsolatos problémákat oldanak meg.

### **Külső sablon alkalmazása egy mesterhez tartozó diákra**

Használja az [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imasterslide/) metódust, ha egy PowerPoint sablonfájlt (`.thmx`) szeretne alkalmazni, és minden, egy adott mesterhez kapcsolódó dia új stílusát szeretné módosítani. Válassza ki a mestert a [Presentation.getMasters](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) gyűjteményből, amely az [IMasterSlideCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imasterslidecollection/) interfészt valósítja meg, majd adja meg a sablonfájl útvonalát a metódusnak.

A metódus a következő műveleteket hajtja végre:

1. Létrehoz egy új mesterdia‑t a kiválasztott mester alapján.
1. Alkalmazza a külső sablont az új mesterre.
1. A korábban a kiválasztott mesterre támaszkodó összes diára hozzárendeli az új mestert.
1. Visszaadja az újonnan létrehozott [IMasterSlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imasterslide/) objektumot.

Az alábbi példa egy külső sablont alkalmaz az első mesterhez tartozó diákra, majd elmenti a prezentációt:

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

Érvénytelen, sérült vagy nem támogatott sablon esetén [PptxReadException](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pptxreadexception/) léphet fel. Érvényesítse a felhasználók által megadott útvonalakat, kezelje a fájlrendszer‑hozzáférési hibákat, és csak a sablon sikeres alkalmazása után mentse el a prezentációt.

Csak a kiválasztott mesterhez tartozó diák kerülnek átállításra. Más mesterekhez tartozó diák megtartják meglévő mestereiket és sablonjaikat. A sablont használó színek, betűtípusok, kitöltések, vonalak, háttér és effektusok a külső sablonhoz igazodnak. A közvetlenül hozzárendelt színek, betűtípusok, kitöltések és egyéb explicit formázások változatlanok maradhatnak. Az elrendezés‑ és diaszintű felülírások szintén felülbírálhatják az új mesterből örökölt értékeket.

A sablon hivatkozhat olyan betűtípusokra, amelyek nincsenek jelen a futási környezetben. A konzisztens megjelenítés és exportálás érdekében telepítse a szükséges betűtípusokat, biztosítsa őket a [custom font sources](/slides/hu/androidjava/custom-font/) segítségével, vagy konfigurálja a [font substitution](/slides/hu/androidjava/font-substitution/) beállítását.

Ez egy közvetlen mester‑szintű munkafolyamat: a metódus egy `.thmx` fájl elérési útját várja, és nem igényel manuális diaszintű vagy elrendezés‑szintű sablonfelülírások létrehozását.

### **Különböző külső sablonok alkalmazása egy több‑mesteres prezentációban**

Ha a megfelelő mestert előre nem ismeri, szerezze be azt egy reprezentatív diából a [ISlide.getLayoutSlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islide/) és a [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilayoutslide/) segítségével. Tárolja az eredeti mesterek hivatkozásait a sablonok alkalmazása előtt, mert minden hívás egy új mestert hoz létre a prezentációban.

Az alábbi példa két szakaszból származó diákat használ a mesterek felkutatásához, és minden csoporthoz egy külön külső sablont alkalmaz:

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

Az első hívás csak a `firstGroupMaster`‑hez tartozó diákra van hatással, a második hívás csak a `secondGroupMaster`‑hez tartozó diákra. A többi mesterhez tartozó diákok nem kapnak új stílust.

### **Forrás sablon megőrzése diák áthelyezésekor**

Ha egy diát egy másik prezentációba szeretne áthelyezni, és meg szeretné őrizni az eredeti dizájnt, klónozza a forrás mestert a célprezentációba az [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imasterslidecollection/) segítségével, majd klónozza a diát az [ISlideCollection.addClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islidecollection/) és a klónozott mesterrel. Ez a mester, az elrendezései és a hozzá tartozó sablon együtt kerül átvitelre.

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

Ez a preferált munkafolyamat, ha a forrás dia megjelenése a célhelyen is azonos kell legyen. A tartalom egyszerű klónozása egy nem kapcsolódó cél‑mesterre megváltoztathatja a sablon‑alapú színeket, betűtípusokat, háttérstílusokat és effektusokat.

### **Sablon értékek alkalmazása egy meglévő diára**

Ha a cél‑dia a jelenlegi mesterén és elrendezésén marad, inicializáljon egy diaszintű felülírást a forrás sablonból. A [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/overridetheme/), a [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/overridetheme/) és a [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/overridetheme/) metódusok a három fő sablonkomponenst másolják a felülírásba.

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

Ez megváltoztatja a diára vonatkozó sablont anélkül, hogy a többi dia örökölt sablonját módosítaná. A helyi felülírás eltávolításához és az örökölt értékek visszaállításához hívja a [OverrideTheme.clear](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/overridetheme/) metódust.

### **Sablon felülírás alkalmazása egy elrendezésre**

Az elrendezés‑szintű felülírás azokra a diákra vonatkozik, amelyek az adott elrendezést használják, kivéve ha egy konkrét dia saját felülírással rendelkezik. Ugyanezeket az inicializáló metódusokat használhatja a [LayoutSlideThemeManager](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/layoutslidethememanager/) segítségével:

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

Használjon mester‑ vagy prezentáció‑szintű sablont, ha sok elrendezésnek és diáknak közös alapdizájnt kell megosztania; elrendezés‑felülírást alkalmazzon, ha egy elrendezéscsaládnak eltérő stílusra van szüksége; és csak diaszintű felülírást használjon valódi kivételeknél. A túlzott diaszintű felülírások megnehezítik a későbbi globális sablonváltozások előrejelzését.

## **Téma háttérstílusok frissítése**

A sablon háttérkitöltései a [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iformatscheme/) gyűjteményben vannak tárolva. A PowerPoint a felhasználói felületén több háttérválasztékot mutathat, mint amennyi kitöltésdefiníció ténylegesen szerepel ebben a gyűjteményben, mivel a felhasználói felület a sablonkitöltéseket a sablonszínekkel és egyéb stílusreferenciákkal kombinálhatja.

![PowerPoint háttérstílus galéria egy prezentációs sablonhoz](presentation-design_8.png)

A háttérstílus használata előtt vizsgálja meg a tárolt gyűjteményt és az aktuális [Background.getStyleIndex](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/background/) értéket. A `0` index azt jelenti, hogy nincs sablon‑kitöltés; a pozitív értékek sablon‑háttér‑stílusre mutatnak. Ez eltér a Java‑gyűjtemény közvetlen indexelésétől, ahol a `get_Item(0)` az első tárolt elemet jelenti. Ne feltételezze, hogy minden prezentáció ugyanannyi háttérkitöltés‑stílussal rendelkezik.

Az alábbi példa jelenti a rendelkezésre álló háttérkitöltések számát, egy sablon‑háttér‑referenciát rendel az első mesterhez, és elmenti a prezentációt:

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

A látható eredmény a mester által referenciázott sablonbejegyzéstől, valamint az elrendezés‑ vagy diaszintű háttér‑felülírásoktól függ. Ha egy dia saját háttérrel rendelkezik, a mester háttérének módosítása nem feltétlenül változtatja meg azt a diát. Használja a [Background.getEffective](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/background/) metódust, ha a teljes öröklődés után keletkező háttérre van szüksége.

{{% alert color="warning" title="Warning" %}}
Ne kezelje a stílus‑indexet nullával alapuló gyűjtemény‑indexként. Emellett kerülje a stílusszám egy fájlból való keménykódolását és annak egy másik fájlban való felhasználását; a sablonstílus‑definíciók prezentációnként eltérnek.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
A közvetlen háttér‑formázáshoz és a háttér‑öröklődéshez lásd a [Presentation Background](/slides/hu/androidjava/presentation-background/) szakaszt.
{{% /alert %}}

## **Téma effektusok frissítése**

A sablon formátumsémája különálló kitöltés‑, vonal‑ és effektus‑stílus‑gyűjteményeket tartalmaz, amelyeket a [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iformatscheme/), a [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iformatscheme/) és a [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iformatscheme/) metódusok tesznek elérhetővé. A tipikus Office‑sablonok gyakran három fő stílusbejegyzést tartalmaznak, amelyek vizuálisan a finom, közepes és intenzív formázásnak felelnek meg, de a kódnak minden gyűjteményt ellenőriznie kell, ahelyett, hogy egy rögzített számot feltételezne.

![Finom, közepes és intenzív sablon‑effektusok egyetlen alakzatra alkalmazva](presentation-design_10.png)

Java‑ban a gyűjtemény indexelése nullával kezdődik: a `get_Item(0)` az első tárolt stílust, a `get_Item(2)` a harmadikat adja vissza. Egy alakzat stílus‑referenciáit külön koncepcióként kezeli az [IShapeStyle](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishapestyle/). Egy sablon‑stílus módosítása az arra hivatkozó alakzatokra hat, míg a közvetlen formázást alkalmazó alakzatok változatlanok maradhatnak.

Az alábbi példa ellenőrzi, hogy a szükséges stílusbejegyzések léteznek-e, megváltoztatja az első vonal‑stílust, a harmadik kitöltés‑stílust, a harmadik effektus‑stílusban engedélyezi a külső árnyékot, és elmenti az eredményt:

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

Az ezekre a helyekre hivatkozó alakzatok esetében az első téma‑vonal‑stílus pirosra, a harmadik téma‑kitöltés‑stílus szilárd erdőzöldre, a harmadik effektus‑stílus pedig 10 pont távolságú külső árnyékra változik. A pontos vizuális eredmény továbbra is attól függ, hogy melyik stílus‑helyre hivatkozik az adott alakzat, és hogy a közvetlen formázás felülírja-e a sablont.

![Téma‑effektus‑stílusok a vonal, kitöltés és árnyék beállításainak módosítása után](presentation-design_11.png)

## **Annak meghatározása, hogy egy hatékony szilárd kitöltés sablonszínt használ-e**

A kitöltés lehet közvetlenül egy objektumon tárolva, vagy egy bekezdésből, elrendezésből, mesterből, sablon‑stílusból vagy egy másik formázási szintből örökölve. Hívja a [IFillFormat.getEffective](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifillformat/) metódust, hogy a hierarchiát egy változtathatatlan [IFillFormatEffectiveData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifillformateffectivedata/) objektummá alakítsa. Először ellenőrizze a [IFillFormatEffectiveData.getFillType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifillformateffectivedata/) értékét. Csak akkor olvassa a szilárd‑kitöltés‑tulajdonságokat, ha az `FillType.Solid`.

Szilárd kitöltés esetén a [IFillFormatEffectiveData.getSolidFillColor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifillformateffectivedata/) visszaadja a végső, öröklődés, sablonkeresés és színtranszformációk után kiszámított RGB‑értéket. A [IFillFormatEffectiveData.getSolidFillSchemeColor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifillformateffectivedata/) visszaadja a megfelelő logikai [SchemeColor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/schemecolor/) helyet, például `Text1` vagy `Accent6`. A `SchemeColor.NotDefined` érték azt jelenti, hogy a hatékony szilárd kitöltés nem séma‑színen alapul. Egy olyan munkafolyamatban, ahol a kitöltések csak sablon‑színek vagy közvetlen RGB‑színek, ez az érték egy közvetlen RGB‑kitöltést jelöl.

Ne csak a helyi [IColorFormat.getSchemeColor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icolorformat/) értéket használja a kitöltés osztályozására. Például egy szövegrésznek lehet, hogy nincs helyileg definiált séma‑színe, így a helyi értéke `NotDefined`, míg a hatékony kitöltése örököl egy sablon‑színt, és `Text1`‑re vagy `Accent6`‑ra oldódik. Ezzel szemben a `getSolidFillSchemeColor` megmondja, mely logikai sablon‑hely állította elő a hatékony színt, de nem közli, hogy ez a hely az objektumból, bekezdésből, elrendezésből, mesterből vagy egy másik formázási szintből származik.

Az alábbi példa betölti egy prezentációt, auditálja az alakzat‑ és szövegrész‑kitöltéseket, kiírja minden végső RGB‑értéket és a hozzá tartozó séma‑színt, illetve megjelöli azokat a szilárd kitöltéseket, amelyek nem követik a sablon‑színváltozásokat:

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

A `NotDefined` ágazat olyan szilárd kitöltéseket listáz, amelyek nem reagálnak a sablon‑színslotok változására. Ezeket az objektumokat ellenőrizze, amikor a prezentációnak új márka‑palettát kell követnie. A jelentett RGB‑érték továbbra is a jelenlegi megjelenést mutatja, míg a séma‑érték azt magyarázza, hogy ez a megjelenés kapcsolódik‑e a sablonhoz.

A hatékony‑formátum objektumok pillanatképek. A prezentációs sablon, egy sablon‑felülírás vagy bármely örökölt formázás módosítása után hívja újra a `getEffective`‑et, és olvassa ki az új `IFillFormatEffectiveData` objektumot, mielőtt összehasonlítana vagy riportálna színeket.

## **Hatékony sablon értékek olvasása**

A nyers sablonobjektumok megmutatják, mi van definiálva egy adott szinten. A hatékony értékek azt mutatják, amit egy dia vagy alakzat valójában használ az öröklődés és a helyi felülírások feloldása után. Egy diához hívja a [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/baseoverridethememanager/) metódust. Háttérhez használja a [Background.getEffective](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/background/), kitöltéshez pedig a [FillFormat.getEffective](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fillformat/) metódust.

Az alábbi példa beolvassa a hatékony sablont, a háttér‑stílust és az első alakzat‑kitöltést egy diáról:

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

Használja a hatékony adatokat renderelési diagnosztikához, validáláshoz és összehasonlításokhoz. Ha csak a [Presentation.getMasterTheme](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/)‑t vizsgálja, előfordulhat, hogy egy mester, elrendezés, dia vagy alakzat felülírásait elmulasztja, amelyek megváltoztatják a végső megjelenést.

## **GYIK**

**Vannak-e hatása az egyes diákra is, ha külső sablont alkalmazunk?**

Nem. Az [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imasterslide/) csak azokat a diákot rendeli át, amelyek a kiválasztott mesterhez tartoznak. A más mestereket használó diák megtartják meglévő sablonjaikat.

**Alkalmazhatok‑e sablont egyetlen diára a mester módosítása nélkül?**

Igen. Használja a dia [SlideThemeManager](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slidethememanager/)‑ét, és inicializálja a felülírás‑sablont. A változtatás csak arra a diára vonatkozik; a többi dia továbbra is a meglévő sablonjaikat örökli.

**Mi a legbiztonságosabb módja egy sablon átvitelének egy prezentációból a másikba?**

Dia áthelyezésekor és a forrás‑dizájn megőrzésekor klónozza a forrás mestert a célba, majd a diát a klónozott mesterrel együtt a [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imasterslidecollection/) és a [ISlideCollection.addClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islidecollection/) segítségével. Így a mester, az elrendezések és a sablon együtt marad.

**Hogyan tekinthetem meg a hatékony értékeket az öröklődés és felülírások után?**

Használja a [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/baseoverridethememanager/) metódust egy dia vagy elrendezés sablonjához, valamint a megfelelő hatékony‑adat metódusokat formátumobjektumokhoz, például a [Background.getEffective](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/background/) és a [FillFormat.getEffective](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fillformat/) metódusokat. Ezek az API‑k az öröklődés és felülírások alkalmazása után visszaadják a feloldott értékeket.