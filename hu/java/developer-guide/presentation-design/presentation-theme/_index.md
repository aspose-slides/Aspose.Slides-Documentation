---
title: Prezentációs témák kezelése Java-ban
linktitle: Prezentációs téma
type: docs
weight: 10
url: /hu/java/presentation-theme/
keywords:
- PowerPoint-téma
- prezentációtéma
- diatéma
- téma beállítása
- téma módosítása
- téma kezelése
- külső téma
- THMX
- téma szín
- kiegészítő paletta
- téma betűtípus
- téma stílus
- téma effekt
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Az Aspose.Slides for Java fő prezentációs témái a PowerPoint-fájlok létrehozásához, testreszabásához és konvertálásához egységes márkaidentitással."
---
## **Bevezetés**

A prezentáció témája egy egységes szín-, betűtípus-, háttérstílus-, kitöltés-, vonal- és effektkészletet definiál. A témaérzékeny objektumok ezekre a megosztott definíciókra hivatkoznak, ahelyett, hogy minden vizuális tulajdonságot rögzített értékként tárolnának, így egy téma módosítása egyszerre sok objektumot frissíthet.

Az Aspose.Slides‑ben a prezentációszintű téma a [Presentation.getMasterTheme](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) segítségével érhető el. Egy prezentáció alacsonyabb szinteken is felülírhatja a témát. A master a [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hu/java/com.aspose.slides/masterthememanager/) segítségével felülírhatja a prezentáció témáját, míg egy elrendezés vagy egy egyedi dia a [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hu/java/com.aspose.slides/baseoverridethememanager/) segítségével felülírhatja az örökölt témát. Gyakorlatban egy dia hatásos témája az alábbi öröklési láncon keresztül kerül feloldásra: prezentációs téma, master felülírás, elrendezés felülírás és dia felülírás.

![Téma összetevői: színek, betűtípusok, háttérstílusok és effektek](theme-constituents.png)

Az alábbiakban a leggyakoribb téma‑munkafolyamatok láthatók: téma ellenőrzése, színek és betűtípusok módosítása, téma másolása vagy alkalmazása, háttér‑ és effektstílusok frissítése, valamint hatásos értékek olvasása az öröklés és felülírások feloldása után.

## **Téma ellenőrzése**

A [MasterTheme](https://reference.aspose.com/slides/hu/java/com.aspose.slides/mastertheme/) objektum a téma színskémáját, betűtípus‑skémáját és formátum‑skémáját teszi elérhetővé a [MasterTheme.getColorScheme](https://reference.aspose.com/slides/hu/java/com.aspose.slides/mastertheme/), a [MasterTheme.getFontScheme](https://reference.aspose.com/slides/hu/java/com.aspose.slides/mastertheme/) és a [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/hu/java/com.aspose.slides/mastertheme/) segítségével. Ezeknek a gyűjteményeknek az ellenőrzése a módosítás előtt különösen hasznos, ha a prezentáció külső forrásból származik, mivel a stíluselemek száma és tartalma változhat.

Az alábbi példa beolvassa a fő téma tulajdonságait, és jelentést készít arról, hány háttér-, kitöltés-, vonal‑ és effektstílus van a témában tárolva:

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

Ha egy fájl több master‑t használ, ne tételezzük fel, hogy minden dia ugyanazt a hatásos témát használja. Ellenőrizzük a diahoz tartozó master‑t, és a későbbiekben a cikkben bemutatott hatásos‑téma‑munkafolyamatot alkalmazzuk, amikor elrendezési vagy diafelülírások is jelen lehetnek.

## **Téma színeinek módosítása**

A témaérzékeny kitöltések, vonalak és szöveg egy logikai színre hivatkozhat a [SchemeColor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/schemecolor/) felsorolásból. Amikor módosítja a megfelelő bejegyzést az [IColorScheme](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icolorscheme/)‑ben, minden olyan objektum, amely még mindig erre a téma‑színre hivatkozik, az új értékre lesz feloldva. Az RGB‑színt közvetlenül használó objektumok nem változnak meg a téma‑szín frissítésekor.

Az alábbi végponttól‑végpontig tartó példa létrehoz egy alakzatot, amely az `Accent4`‑et használja, módosítja a téma `Accent4` színét vörösre, elmenti a prezentációt, újra megnyitja, majd kiírja a hatásos kitöltési színt:

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

Mivel a téglalap továbbra is az `Accent4`‑hez van kötve, látható színe a téma módosítása után vörös lesz. Ha a séma‑színt közvetlen színre cseréli az alakzaton, a későbbi `Accent4` változások már nem befolyásolják azt a kitöltést.

### **Színek használata a kiegészítő palettából**

A PowerPoint egy téma‑színből világosabb és sötétebb változatokat származtat színtranszformációk alkalmazásával. Az Aspose.Slides ezeket a transzformációkat a [ColorTransformOperation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/colortransformoperation/) felsorolásban teszi elérhetővé.

![Fő téma színek és a kiegészítő palettából generált világosabb és sötétebb színek](additional-palette-colors.png)

**1** – Fő téma színek.  
**2** – A fő téma színekből előállított világosabb és sötétebb változatok.

Az alábbi példa hat téglalapot hoz létre az `Accent4`‑ből, ötön luminancia‑transzformációt alkalmaz, majd elmenti az eredményt:

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

Ezek a változatok továbbra is a téma‑színen alapulnak. Ha később megváltozik az `Accent4`, a transzformált színek újraszámolódnak az új `Accent4` értékből.

### **A `SchemeColor` értékek leképezése az `IColorScheme` helyekre**

A [SchemeColor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/schemecolor/) felsorolás a `Text1`, `Background1`, `Text2` és `Background2` értékeket használja, míg az [IColorScheme](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icolorscheme/) ugyanazokat a témahelyeket a `Dark1`, `Light1`, `Dark2` és `Light2` néven teszi elérhetővé. A leképezés rögzített:

* `Text1` = `Dark1`  
* `Background1` = `Light1`  
* `Text2` = `Dark2`  
* `Background2` = `Light2`

Ezek ugyanazon témahelyek alternatív nevei; nem dinamikus átalakításról van szó.

## **Téma betűtípusainak módosítása**

A téma betűtípus‑skémája egy fő betűkészletet tartalmaz a címsorokhoz és egy mellékbetűkészletet a törzsszöveghez. A [IFontScheme.getMajor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifontscheme/) és a [IFontScheme.getMinor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifontscheme/) metódusok ezeket a készleteket exponálják.

PowerPoint‑kompatibilis téma‑betűtípus azonosítók használhatók szövegformázáskor:

* `+mn-lt` – Törzsszöveg Latin (Minor Latin Font)  
* `+mj-lt` – Címsor Latin (Major Latin Font)  
* `+mn-ea` – Törzsszöveg Kelet‑Ázsiai (Minor East Asian Font)  
* `+mj-ea` – Címsor Kelet‑Ázsiai (Major East Asian Font)

Az alábbi példa létrehoz egy címsort, amely a fő Latin téma‑betűtípust használja, és egy törzssort, amely a mellék Latin téma‑betűtípust használja. Ezután módosítja a téma betűtípusait, és elmenti az eredményt:

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

A címsor a fő betűtípust, a törzsszöveg a mellék betűtípust követi. Az explicit betűtípus‑névvel ellátott szöveg nem vált automatikusan a téma‑betűtípus‑skéma módosításakor.

A fő és mellék betűkészletek tartalmazhatnak betűtípus‑leképezéseket egyedi írásrendszerekhez, például cirill, arab, japán, grúz és thaana. Ellenőrzés, hozzáadás, csere vagy eltávolítás ezekhez a leképezésekhez, lásd a [Script‑Specific Theme Fonts](/slides/hu/java/script-specific-font-mappings/) oldalát.

{{% alert color="info" title="Tipp" %}}
További információk a prezentációs betűtípusokról: lásd a [PowerPoint Fonts](/slides/hu/java/powerpoint-fonts/) oldalt.
{{% /alert %}}

## **Téma másolása vagy alkalmazása**

Az alábbi munkafolyamatok különböző téma‑kapcsolódó problémákat oldanak meg.

### **Külső téma alkalmazása a master‑függő diákra**

Használja az [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imasterslide/) módszert, ha egy PowerPoint témafájlt (`.thmx`) szeretne alkalmazni, és minden olyan diát újrastílusozni kíván, amely egy adott master‑hez tartozik. Válassza ki a master‑t a [Presentation.getMasters](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) gyűjteményből, amely a [IMasterSlideCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imasterslidecollection/)‑t valósítja meg, majd adja át a témafájl elérési útját a metódusnak.

A metódus a következő lépéseket hajtja végre:

1. Létrehoz egy új master‑diát a kiválasztott master alapján.  
1. Alkalmazza a külső témát az új master‑re.  
1. Hozzárendeli az új master‑t minden diához, amely korábban a kiválasztott master‑hez tartozott.  
1. Visszaadja az újonnan létrehozott [IMasterSlide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imasterslide/) objektumot.

Az alábbi példa külső témát alkalmaz az első master‑hez tartozó diákra, majd elmenti a prezentációt:

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

Érvénytelen, sérült vagy nem támogatott téma [PptxReadException](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pptxreadexception/)-t okozhat. Ellenőrizze a felhasználók által megadott útvonalakat, kezelje a fájlrendszer‑hozzáférési hibákat, és csak a téma sikeres alkalmazása után mentse a prezentációt.

Csak a kiválasztott master‑hez tartozó diákok kerülnek újra hozzárendelésre. Más master‑hez kapcsolódó diákok megtartják meglévő master‑eiket és témáikat. A téma‑érzékeny színek, betűtípusok, kitöltések, vonalak, háttér‑ és effekt‑elemek a külső téma szerint kerülnek feloldásra. A közvetlenül hozzárendelt színek, betűtípusok, kitöltések és egyéb explicite formázások változatlanok maradhatnak. Az elrendezés‑szintű és dia‑szintű felülírások szintén felülbírálhatják az új master‑ből örökölt értékeket.

A téma olyan betűtípusokra hivatkozhat, amelyek nincsenek jelen a futási környezetben. Az egységes megjelenítés és export érdekében telepítse a szükséges betűtípusokat, biztosítsa őket a [custom font sources](/slides/hu/java/custom-font/) segítségével, vagy konfigurálja a [font substitution](/slides/hu/java/font-substitution/) beállítást.

Ez egy közvetlen master‑szintű munkafolyamat: a metódus egy `.thmx` fájl elérési útját várja, és nem igényel manuális dia‑ vagy elrendezés‑szintű téma‑felülírások létrehozását.

### **Különböző külső témák alkalmazása több‑masteres prezentációban**

Ha a releváns master előre nem ismert, szerezze be azt egy reprezentatív diáról a [ISlide.getLayoutSlide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islide/) és a [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilayoutslide/) segítségével. Mielőtt bármilyen témát alkalmazna, tárolja el az eredeti master‑referenciákat, mivel minden hívás egy új master‑t hoz létre a prezentációban.

Az alábbi példa két szekcióból származó diák master‑jeit keresi meg, és mindegyik csoporthoz külön külső témát alkalmaz:

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

Az első hívás csak a `firstGroupMaster`‑hez tartozó diákra hat, a második csak a `secondGroupMaster`‑hez tartozókra. Más master‑hez tartozó diákok nem változnak.

### **Forrástéma megőrzése diák áthelyezésekor**

Ha egy diát másik prezentációba szeretne áthelyezni, és meg akarja őrizni az eredeti megjelenését, klónozza a forrás‑master‑t a cél‑prezentációba az [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imasterslidecollection/) segítségével, majd klónozza a diát az [ISlideCollection.addClone](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islidecollection/) és a klónozott master segítségével. Ezzel a master, annak elrendezései és a hozzá kapcsolódó téma együtt kerül átvitelre.

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

Ez a preferált munkafolyamat, amikor a forrás‑dia pontosan úgy kell, hogy megjelenjen a cél‑prezentációban. A tartalom egyszerű klónozása egy nem kapcsolódó cél‑master‑re megváltoztathatja a téma‑vezérelt színeket, betűtípusokat, háttereket és effekteket.

### **Témaértékek alkalmazása meglévő diára**

Ha a cél‑dia a jelenlegi master‑en és elrendezésen kell maradjon, inicializáljon egy dia‑szintű felülírást a forrástémából. Az [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/hu/java/com.aspose.slides/overridetheme/), az [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/hu/java/com.aspose.slides/overridetheme/) és az [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/hu/java/com.aspose.slides/overridetheme/) metódusok a három fő téma‑komponenst másolják a felülírásba.

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

Ez megváltoztatja a dia által használt témát anélkül, hogy más diák által örökölt témát módosítaná. A helyi felülírás eltávolításához és az örökölt értékek visszaállításához hívja meg az [OverrideTheme.clear](https://reference.aspose.com/slides/hu/java/com.aspose.slides/overridetheme/) metódust.

### **Téma felülírás alkalmazása elrendezésre**

Az elrendezés‑szintű felülírás az az elrendezést használó diákra vonatkozik, kivéve, ha egy adott dianak saját felülírása van. Ugyanazokat az inicializáló metódusokat a [LayoutSlideThemeManager](https://reference.aspose.com/slides/hu/java/com.aspose.slides/layoutslidethememanager/) segítségével használhatja:

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

Használjon master‑ vagy prezentáció‑szintű témát, ha sok elrendezésnek és diáknak közös alap‑designra van szüksége; egy elrendezés‑felülírást, ha egy elrendezés‑családnak eltérő stílusra van szüksége; és egy dia‑felülírást csak valódi kivételekhez. A túlzott dia‑szintű felülírások megnehezítik a későbbi globális téma‑változások előrejelzését.

## **Téma háttérstílusok frissítése**

A téma háttérkitöltései az [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iformatscheme/)‑ben tárolódnak. A PowerPoint a felhasználói felületen több háttérválasztási lehetőséget jeleníthet meg, mint amennyi kitöltés‑definíció fizikailag tárolva van ebben a gyűjteményben, mivel a UI a téma‑kitöltéseket a téma‑színekkel és egyéb stílus‑referenciákkal kombinálhatja.

![PowerPoint háttérstílus galéria egy prezentációtémához](presentation-design_8.png)

Mielőtt háttérstílust használna, ellenőrizze a tárolt gyűjteményt és a jelenlegi [Background.getStyleIndex](https://reference.aspose.com/slides/hu/java/com.aspose.slides/background/)-et. A `0` index azt jelenti, hogy nincs téma‑kitöltés; a pozitív értékek téma‑háttér‑stílus‑referenciák. Ez eltér a Java gyűjtemény közvetlen indexelésétől, ahol a `get_Item(0)` az első tárolt elemet jelenti. Ne feltételezze, hogy minden prezentáció ugyanannyi háttér‑kitöltés‑stílussal rendelkezik.

Az alábbi példa jelentést készít a rendelkezésre álló háttér‑kitöltések számáról, egy téma‑háttér‑referenciát rendel az első master‑hez, majd elmenti a prezentációt:

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

A látható eredmény a master‑által hivatkozott téma‑bejegyzéstől, valamint az elrendezés‑ vagy dia‑szintű háttér‑felülírásoktól függ. Ha egy dia saját háttérrel rendelkezik, csak a master háttér módosítása nem biztos, hogy megváltoztatja azt a diát. Használja a [Background.getEffective](https://reference.aspose.com/slides/hu/java/com.aspose.slides/background/)‑t, ha a végleges háttérre van szüksége az öröklés után.

{{% alert color="warning" title="Figyelmeztetés" %}}
Ne kezelje a stílus‑indexet nullával kezdődő gyűjtemény‑indexként. Kerülje a stílus‑szám hard‑kódolását egy fájlból, és annak feltételezését, hogy ugyanúgy jelenik meg egy másik fájlban; a téma‑stílusdefiníciók prezentációnként eltérőek.
{{% /alert %}}

{{% alert color="info" title="Tipp" %}}
Közvetlen háttérformázáshoz és háttér‑öröklődéshez lásd a [Presentation Background](/slides/hu/java/presentation-background/) oldalt.
{{% /alert %}}

## **Téma effektek frissítése**

A téma formátum‑skémája különálló kitöltés‑, vonal‑ és effekt‑stílus‑gyűjteményeket tartalmaz, amelyeket a [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iformatscheme/), a [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iformatscheme/) és a [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iformatscheme/) exponál. A tipikus Office‑témák gyakran három fő stílus‑bejegyzést tartalmaznak, amelyek vizuálisan a finom, közepes és intenzív formázásnak felelnek meg, de a kódnak minden gyűjteményt ellenőriznie kell, ahelyett, hogy rögzített számot feltételezne.

![Finom, közepes és intenzív téma‑effektek ugyanazon alakzaton alkalmazva](presentation-design_10.png)

Java‑ban ezeknek a gyűjteményeknek az indexelése nullával kezdődik: `get_Item(0)` az első tárolt stílus, `get_Item(2)` a harmadik. Egy alakzat stílus‑referencia‑indexei egy külön koncepciót képeznek, amelyet az [IShapeStyle](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishapestyle/) exponál. Egy téma‑stílus módosítása a arra hivatkozó alakzatokra hat, míg a közvetlen formázással rendelkező alakzatok változatlanok maradhatnak.

Az alábbi példa ellenőrzi, hogy a szükséges stílus‑bejegyzések léteznek, megváltoztatja az első vonal‑stílust, a harmadik kitöltés‑stílust, engedélyezi egy külső árnyékot a harmadik effekt‑stílusban, majd elmenti az eredményt:

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

A megfelelő slotokra hivatkozó alakzatok esetén az első téma‑vonal‑stílus piros lesz, a harmadik téma‑kitöltés‑stílus szilárd erdőzöld, a harmadik effekt‑stílus pedig egy 10 pont távolságú külső árnyékot kap. A pontos vizuális eredmény továbbra is attól függ, hogy melyik stílus‑slotra hivatkozik az adott alakzat, és hogy a közvetlen formázás felülírja-e a témát.

![Téma‑effektus‑stílusok változtatás után](presentation-design_11.png)

## **Hatásos témaértékek olvasása**

A nyers témaobjektumok megmutatják, hogy mi van definiálva egy adott szinten. A hatásos értékek azt mutatják, hogy egy dia vagy alakzat ténylegesen mit használ az öröklés és a helyi felülírások feloldása után. Egy diára a [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hu/java/com.aspose.slides/baseoverridethememanager/) hívható. Háttérre a [Background.getEffective](https://reference.aspose.com/slides/hu/java/com.aspose.slides/background/), kitöltésre pedig a [FillFormat.getEffective](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fillformat/) használható.

Az alábbi példa beolvassa a hatásos témát, hátteret és az első alakzat kitöltését egy diához:

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

Használja a hatásos adatot renderelési diagnosztikához, validációhoz és összehasonlításhoz. Ha csak a [Presentation.getMasterTheme](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/)‑t ellenőrzi, könnyen kihagyhat egy master‑, elrendezés‑, dia‑ vagy alakzat‑felülírást, amely megváltoztatja a végső megjelenést.

## **GYIK**

**Az külső téma alkalmazása minden diára hat a prezentációban?**

Nem. Az [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imasterslide/) csak azokat a diákot rendeli újra, amelyek a kiválasztott master‑hez tartoznak. A másik master‑t használó diák megtartják meglévő témájukat.

**Alkalmazhatok témát egyetlen diára a master módosítása nélkül?**

Igen. Használja a dia [SlideThemeManager](https://reference.aspose.com/slides/hu/java/com.aspose.slides/slidethememanager/)‑ét, és inicializálja annak felülírás‑témáját. A változás csak arra a diára érvényes; a többi dia a meglévő témáját örökli.

**Mi a legbiztonságosabb módja a téma átvitelének az egyik prezentációból a másikba?**

Dia áthelyezésekor és eredeti megjelenésének megőrzésekor klónozza a forrás‑master‑t a cél‑prezentációba, majd a diát a [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imasterslidecollection/) és a [ISlideCollection.addClone](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islidecollection/) használatával. Így a master, elrendezései és a téma együtt maradnak.

**Hogyan tekinthetem meg a hatásos értékeket az öröklés és felülírások után?**

Használja a [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hu/java/com.aspose.slides/baseoverridethememanager/)‑t dia‑ vagy elrendezés‑téma esetén, valamint a megfelelő hatásos‑adat metódusokat formátumobjektumokhoz, például a [Background.getEffective](https://reference.aspose.com/slides/hu/java/com.aspose.slides/background/) és a [FillFormat.getEffective](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fillformat/). Ezek az API‑k a feloldott értékeket adják vissza az öröklés és felülírások alkalmazása után.