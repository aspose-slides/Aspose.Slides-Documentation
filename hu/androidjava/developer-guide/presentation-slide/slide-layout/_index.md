---
title: Diaelrendezések alkalmazása vagy módosítása Androidon
linktitle: Diaelrendezés
type: docs
weight: 60
url: /hu/androidjava/slide-layout/
keywords:
- diaelrendezés
- tartalomelrendezés
- helyettesítőelem
- prezentáció tervezés
- dia tervezés
- nem használt elrendezés
- lábléc láthatóság
- címdia
- cím és tartalom
- szekciófejléc
- két tartalom
- összehasonlítás
- csak cím
- üres elrendezés
- tartalom felirattal
- kép felirattal
- cím és függőleges szöveg
- függőleges cím és szöveg
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Diaelrendezések alkalmazása, létrehozása és módosítása az Aspose.Slides for Android-ban Java segítségével, helyettesítőelemek hozzáadása, nem használt elrendezések eltávolítása, valamint a lábléc láthatóságának szabályozása."
---
## **Áttekintés**

A diaelrendezés meghatározza a helyettesítőelemek, például a címek, szöveg, képek, diagramok és táblázatok pozícióját és formázását. Egy elrendezés alkalmazása egységes struktúrát biztosít a diák számára, miközben minden dia a saját tartalmát tartalmazhatja.

A leggyakoribb elrendezések a következők:

- **Title Slide**: Címdiát tartalmaz cím és alcím helyettesítőelemekkel.
- **Title and Content**: Címhelyettesítőelemet és általános tartalomhelyettesítőelemet tartalmaz.
- **Blank**: Nem tartalmaz tartalomhelyettesítőelemeket, és akkor hasznos, ha minden alakzatot kézzel helyezünk el.

## **Ismerje meg az elrendezés öröklődését**

Egy prezentációnak három kapcsolódó szintje van:

1. A [master slide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imasterslide/) meghatározza a témát, a megosztott formázást, a hátteret és a közös objektumokat.
1. A [layout slide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilayoutslide/) egy masterhez tartozik és egy meghatározott helyettesítőelemek elrendezését definiálja.
1. A [normal slide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islide/) egy elrendezést használ, és tárolja a diapozithoz megadott tartalmat.

Egy normál dia örökli a témát és a formázást az elrendezéséből, az elrendezés pedig a masterből. A normál dián közvetlenül beállított érték felülírja az örökölt értéket azon a szinten. Amikor egy normál diát létrehoznak, a helyettesítőelemek alakzata a kiválasztott elrendezésből generálódik, míg a helyettesítőelemekbe bevitt tartalom a normál diához tartozik.

Adjunk hozzá szükséges helyettesítőelemeket egy elrendezéshez, mielőtt diák létrehozására használnánk. Később egy további helyettesítőelem hozzáadása az elrendezéshez nem hozza létre automatikusan a megfelelő helyettesítőelemet a már meglévő normál diákon.

Ennek a kapcsolatnak két fontos következménye van:

- Az örökölt formázás vagy a meglévő helyettesítőelem geometria módosítása az elrendezésen frissítheti az összes tőle függő diát. Mielőtt olyan elrendezést szerkesztenénk, amely már használatban van, ellenőrizzük a függő diákat, és tekintsük át a keletkezett prezentációt.
- Egy elrendezés, amelyet még egy dia használ, nem távolítható el. Először rendeljük át a függő diákat egy másik elrendezésre, vagy csak a nem használt elrendezéseket távolítsuk el.

További információkért a hierarchia legfelső szintjéről lásd a [Slide Master](/slides/hu/androidjava/slide-master/) oldalt.

Az örökölt logók vagy dekoratív master alakzatok egy dián vagy megosztott elrendezésen keresztül történő elrejtéséhez lásd a [Control the Visibility of Master Graphics](/slides/hu/androidjava/slide-master/) cikket. A példa két, ugyanazt a mastert használó diát hasonlít össze.

## **Diaelrendezés kiválasztása és alkalmazása**

Használjon elrendezést, ha a prezentáció a szabványos PowerPoint elrendezésdefiníciókat követi. Az elrendezésneveket a felhasználó módosíthatja és lokalizálhatja, ezért a név alapú kiválasztás kevésbé megbízható, kivéve ha a forrás sablont kontrollálja.

A következő példa a **Title and Content** elrendezést keres az első masteren. Ha ez az elrendezés nem érhető el, szándékosan a **Blank** elrendezésre tér vissza. A második null ellenőrzés szükséges, mivel egy prezentáció csak egyéni elrendezéseket tartalmazhat. A kiválasztott elrendezést ezután a [ISlide.setLayoutSlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-) metódussal alkalmazzák az első normál diára.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide targetLayout = layoutSlides.getByType(SlideLayoutType.TitleAndObject);

    if (targetLayout == null) {
        targetLayout = layoutSlides.getByType(SlideLayoutType.Blank);
    }

    if (targetLayout == null) {
        throw new IllegalStateException("The first master does not contain a suitable layout slide.");
    }

    presentation.getSlides().get_Item(0).setLayoutSlide(targetLayout);
    presentation.save("output-with-new-layout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Egy dia elrendezésének módosítása nem távolítja el a diára közvetlenül hozzáadott szabályos alakzatokat. Azonban a helyettesítőelemek pozíciói, az örökölt formázás és a meglévő helyettesítőelemek és az új elrendezés közti megfelelés megváltozhat, ezért vizsgálja meg a kimenetet, amikor lényegesen eltérő elrendezések között vált.

## **Elrendezésdia hozzáadása**

A kiválasztás és a létrehozás külön műveletek. Az előző példa egy meglévő elrendezést választ ki; nem hoz létre újat. Egy elrendezés létrehozásához hívja meg a [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) metódust a cél master elrendezésgyűjteményén.

A következő példa mindig hozzáad egy új **Title and Content** elrendezést `Report Title and Content` néven, majd ennek alapján hozzáad egy normál diát. Az elrendezésneveknek egyedieknek kell lenniük a gyűjteményben.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide reportLayout = masterSlide.getLayoutSlides().add(SlideLayoutType.TitleAndObject, "Report Title and Content");
    presentation.getSlides().addEmptySlide(reportLayout);

    presentation.save("output-with-report-layout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Csak akkor adjon hozzá elrendezést, ha a sablon valóban egy további újrahasználható struktúrát igényel. Ha már létezik megfelelő elrendezés, válassza ki és használja újra a duplikálás helyett.

## **Helyettesítőelemek hozzáadása egy elrendezésdiához**

Az [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) metódus egy [ILayoutPlaceholderManager](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilayoutplaceholdermanager/) objektumot biztosít, amellyel helyettesítőelem-alakzatok adhatók hozzá egy elrendezéshez.

| PowerPoint helyettesítőelem | `ILayoutPlaceholderManager` Method |
| --------------------------- | ---------------------------------- |
| ![Tartalom](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![Tartalom (Függőleges)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![Szöveg](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![Szöveg (Függőleges)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![Kép](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![Diagram](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![Táblázat](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![Média](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![Online kép](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

A következő példa ellenőrzi, hogy a **Blank** elrendezés létezik-e, négy helyettesítőelemet ad hozzá, majd létrehoz egy normál diát, amely a módosított elrendezést használja. A sorrend szándékos: a helyettesítőelemeket a normál dia létrehozása előtt adják hozzá, így az Aspose.Slides a megfelelő helyettesítőelem-alakzatokat generálja azon a dián.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    if (blankLayout == null) {
        throw new IllegalStateException("The presentation does not contain a Blank layout slide.");
    }

    ILayoutPlaceholderManager placeholderManager = blankLayout.getPlaceholderManager();
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    presentation.getSlides().addEmptySlide(blankLayout);
    presentation.save("output-with-placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A helyettesítőelemek az elrendezésdián](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Az örökölt formázás vagy a meglévő elrendezési helyettesítőelemek geometriai módosítása befolyásolhatja a függő diát. Egy újonnan hozzáadott elrendezési helyettesítőelem nem kerül visszatöltésre a már létező normál diákba. Tesztelje az elrendezésváltoztatásokat a prezentáció egy másolatán, és ellenőrizze minden függő diát.
{{% /alert %}}

## **Nem használt elrendezésdiák eltávolítása**

Használja a [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) metódust a olyan elrendezések eltávolításához, amelyeket egyetlen normál dia sem hivatkozik. A metódus érintetlenül hagyja a még használatban lévő elrendezéseket.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Egy adott elrendezés eltávolításához először használja annak a [hasDependingSlides](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilayoutslide/#hasDependingSlides--) vagy a [getDependingSlides](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--) metódusát. A [ILayoutSlide.remove](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilayoutslide/#remove--) hívása előtt rendelje át a függő diákat. Egy használt elrendezés eltávolításának kísérlete [PptxEditException](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pptxeditexception/) kivételt eredményez.

## **Lábléc láthatóságának szabályozása egy elrendezésdián**

Egy elrendezésnek saját lábléc, dia-szám és dátum-idő helyettesítőelemei vannak. Használja az [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) metódust ezeknek a helyettesítőelemeknek a szabályozásához egy elrendezésen belül. Ez akkor hasznos, ha például a tartalom elrendezéseknek láblécet kell mutatniuk, míg a cím elrendezéseknek nem.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject);

    if (layoutSlide == null) {
        layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    }

    if (layoutSlide == null) {
        throw new IllegalStateException("The presentation does not contain a suitable layout slide.");
    }

    ILayoutSlideHeaderFooterManager headerFooterManager = layoutSlide.getHeaderFooterManager();
    headerFooterManager.setFooterVisibility(true);
    headerFooterManager.setSlideNumberVisibility(true);
    headerFooterManager.setDateTimeVisibility(true);
    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("output-with-layout-footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lábléc láthatóságának szabályozása egy masteren és annak alárendelt elrendezésein**

Az egységes láblécbeállítások egy master hierarchia mentén történő alkalmazásához használja az [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imasterslide/#getHeaderFooterManager--) metódust. A [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imasterslideheaderfootermanager/) terjesztési módszerei a masteren, annak függő elrendezésdiáin és normál diáin működnek; nem egyetlen normál diát céloznak meg.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);
    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("output-with-master-footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **GYIK**

**Mi a különbség egy master diának és egy elrendezésdiának?**

A master slide meghatározza a prezentáció témáját és a megosztott formázást. Egy elr-layout slide egy masterhez tartozik és egy újrahasználható helyettesítőelem-elrendezést definiál. A normál diák ezeket az elrendezéseket használják, és dia-specifikus tartalmat tárolnak.

**Másolhatok elrendezésdiát egyik prezentációból a másikba?**

Igen. Egy másolatot adjon a célgyűjteményhez az [addClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) metódussal. Prezentációk közötti másolás esetén ellenőrizze a forrás elrendezés által használt betűtípusokat, témákat, képeket és egyéb erőforrásokat.

**Mi történik, ha módosítok egy már használt elrendezést?**

A függő diák öröklik az elrendezés változásait, hacsak nem írják felül a helyi formázást vagy objektumokat. Így a helyettesítőelemek geometriája és az örökölt stílus számos dián egy időben megváltozhat. Az elrendezés szerkesztése előtt használja a [getDependingSlides](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--) metódust a érintett diák azonosításához.

**Mi történik, ha eltávolítok egy még használt elrendezést?**

Az Aspose.Slides egy [PptxEditException](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pptxeditexception/) kivételt dob. Először rendelje át a függő diákat, vagy használja a [removeUnusedLayoutSlides](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) metódust, hogy csak a nem hivatkozott elrendezéseket távolítsa el.