---
title: Diaelrendezések alkalmazása vagy módosítása Androidon
linktitle: Diaelrendezés
type: docs
weight: 60
url: /hu/androidjava/slide-layout/
keywords:
- diaelrendezés
- tartalomelrendezés
- helyőrző
- bemutató tervezés
- dia tervezés
- használaton kívüli elrendezés
- lábléc láthatóság
- cím dia
- cím és tartalom
- szakaszcím
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
- bemutató
- Android
- Java
- Aspose.Slides
description: "Alkalmazza, hozza létre és módosítsa a diaelrendezéseket az Aspose.Slides for Androidban Java segítségével, adjon hozzá helyőrzőket, távolítsa el a használaton kívüli elrendezéseket, és szabályozza a lábléc láthatóságát."
---
## **Áttekintés**

A diárelrendezés (slide layout) meghatározza a helyőrzők, például címek, szöveg, képek, diagramok és táblázatok pozícióit és formázását. Egy elrendezés alkalmazása következetes szerkezetet ad a diáknak, miközben lehetővé teszi, hogy minden dia saját tartalmát tartalmazza.

A leggyakoribb elrendezések a következők:

- **Title Slide**: Cím- és felirathelyőrzőket tartalmaz.
- **Title and Content**: Egy címhelyőrzőt és egy általános tartalomhelyőrzőt tartalmaz.
- **Blank**: Nem tartalmaz tartalomhelyőrzőket, és akkor hasznos, ha minden alakzatot kézzel helyezünk el.

## **Ismerje meg az elrendezés öröklődését**

Egy bemutatónak három kapcsolódó szintje van:

1. A [master slide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imasterslide/) meghatározza a témát, a megosztott formázást, a hátteret és a közös objektumokat.
2. A [layout slide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilayoutslide/) egy mesterhez tartozik, és meghatároz egy adott helyőrző-eloszlást.
3. A [normal slide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islide/) egy elrendezést használ, és tárolja az adott diára bevitt tartalmat.

Egy normál dia örökli a témát és a formázást az elrendezéséből, az elrendezés pedig a mestertől örököl. Egy normál dián közvetlenül beállított érték felülírja az örökölt értéket azon a szinten. Amikor egy normál diát hozunk létre, a helyőrző alakzatok a kiválasztott elrendezésből generálódnak, míg a helyőrzőkbe bevitt tartalom a normál diához tartozik.

Adjon hozzá szükséges helyőrzőket egy elrendezéshez, mielőtt diákat hozna létre belőle. Egy helyőrző későbbi hozzáadása az elrendezéshez nem ad hozzá automatikusan megfelelő helyőrző alakzatot a meglévő normál diákhoz.

Ennek a kapcsolatnak két fontos következménye van:

- Az örökölt formázás vagy egy meglévő helyőrző geometria módosítása egy elrendezésen frissítheti az összes tőle függő diát. Mielőtt egy már használt elrendezést szerkesztené, ellenőrizze a tőle függő diákat, és tekintse át a keletkező bemutatót.
- Egy olyan elrendezés, amelyet még diáknak használnak, nem távolítható el. Először rendelje át a függő diákat egy másik elrendezéshez, vagy csak a nem használt elrendezéseket távolítsa el.

További információért a hierarchia felső szintjéről, lásd a [Slide Master](/slides/hu/androidjava/slide-master/) oldalt.

## **Válassza ki és alkalmazza a diák elrendezését**

Használjon elrendezéstípust, ha a bemutató a szabványos PowerPoint elrendezésdefiníciókat követi. Az elrendezésneveket a felhasználó szerkesztheti, és lokalizálhatók, ezért a név alapú kiválasztás kevésbé megbízható, hacsak nem irányítja a forrás sablont.

A következő példa a **Title and Content** elrendezést keresi az első masteren. Ha ez az elrendezés nem érhető el, szándékosan a **Blank** elrendezésre vált. A második null ellenőrzés szükséges, mert egy bemutató csak egyedi elrendezéseket tartalmazhat. A kiválasztott elrendezést ezután a [ISlide.setLayoutSlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-) metódussal alkalmazzák az első normál diára.

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

Egy dia elrendezésének megváltoztatása nem távolítja el a dia közvetlenül hozzáadott szokásos alakzatait. Azonban a helyőrzőpozíciók, az örökölt formázás és a meglévő helyőrzők és az új elrendezés közötti megfelelés változhat, ezért ellenőrizze a kimenetet, ha jelentősen eltérő elrendezések között vált.

## **Elrendezésdia hozzáadása**

A kiválasztás és a létrehozás külön műveletek. Az előző példa egy meglévő elrendezést választ ki; nem hoz létre újat. Egy elrendezés létrehozásához hívja meg a [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) metódust a célmester elrendezésgyűjteményén.

A következő példa mindig hozzáad egy új **Title and Content** elrendezést `Report Title and Content` néven, majd egy róla alapuló normál diát ad hozzá. Az elrendezésneveknek egyedieknek kell lenniük a gyűjteményben.

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

Csak akkor adjon hozzá elrendezést, ha a sablon valóban szükségeltet egy további újrahasználható struktúrát. Ha már létezik megfelelő elrendezés, válassza ki és használja újra, ahelyett, hogy duplikátumot hozna létre.

## **Helyőrzők hozzáadása egy elrendezésdiához**

Az [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) metódus egy [ILayoutPlaceholderManager](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilayoutplaceholdermanager/) objektumot biztosít az elrendezéshez helyőrző alakzatok hozzáadásához.

| PowerPoint helyőrző | `ILayoutPlaceholderManager` metódus |
| ------------------- | ---------------------------------- |
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

A következő példa ellenőrzi, hogy a **Blank** elrendezés létezik-e, négy helyőrzőt ad hozzá, majd egy módosított elrendezést használó normál diát hoz létre. A sorrend szándékos: a helyőrzőket a normál dia létrehozása előtt adják hozzá, így az Aspose.Slides képes létrehozni a megfelelő helyőrző alakzatokat azon a dián.

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

![A helyőrzők az elrendezés dián](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Az örökölt formázás vagy a meglévő elrendezéshelyőrzők geometriai módosítása befolyásolhatja a függő diákat. Egy újonnan hozzáadott elrendezéshelyőrző nem kerül visszatenni a meglévő normál diákba. Tesztelje az elrendezésváltozásokat a bemutató egy másolatán, és ellenőrizze minden függő diát.
{{% /alert %}}

## **Használaton kívüli elrendezésdiák eltávolítása**

Használja a [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) metódust a nem normál diák által hivatkozott elrendezések eltávolításához. A metódus érintetlenül hagyja a még használatban lévő elrendezéseket.

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

Egy konkrét elrendezés eltávolításához először használja a [hasDependingSlides](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilayoutslide/#hasDependingSlides--) vagy a [getDependingSlides](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--) metódust. A [ILayoutSlide.remove](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilayoutslide/#remove--) meghívása előtt rendelje át a függő diát. A használt elrendezés eltávolításának kísérlete [PptxEditException](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pptxeditexception/) kivételt eredményez.

## **Lábléc láthatóságának szabályozása egy elrendezésdián**

Egy elrendezésnek saját lábléc, diaszám és dátum-idő helyőrzői vannak. Használja a [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) metódust ezeknek a helyőrzőknek az egy elrendezésre való szabályozásához. Ez akkor hasznos, ha például a tartalomelrendezéseknek láblécet kell mutatniuk, a cím-elrendezéseknek pedig nem.

A következő példa biztonságosan kiválaszt egy elrendezést és láthatóvá teszi a lábléc elemeit:

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

## **Lábléc láthatóságának szabályozása egy mesteren és annak gyermekelrendezésein**

Az egységes láblécke beállítások mesterhierarchiára való alkalmazásához használja az [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imasterslide/#getHeaderFooterManager--) metódust. A [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imasterslideheaderfootermanager/) terjesztési metódusai a mesterre, annak függő elrendezésdiára és normál diákra vonatkoznak; nem csak egyetlen normál diára céloznak.

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

**Mi a különbség egy Master Slide és egy Layout Slide között?**

A master slide meghatározza a bemutató témáját és a megosztott formázást. Egy layout slide egy mesterhez tartozik, és egy újrahasználható helyőrző-eloszlást definiál. A normál diák ezeket az elrendezéseket használják, és tárolják a diához tartozó tartalmat.

**Másolhatok egy Layout Slide-ot egy bemutatóból egy másikba?**

Igen. A [addClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) metódussal adjon egy másolatot a célgyűjteményhez. Bemutatók közti másoláskor ellenőrizze a betűtípusokat, témákat, képeket és a forráselrendezés által használt egyéb erőforrásokat is.

**Mi történik, ha módosítok egy már használatban lévő elrendezést?**

A függő diák öröklik az elrendezés változásait, hacsak nem írják felül a helyi formázást vagy objektumokat. A helyőrző geometria és az örökölt stílus ezért egyszerre sok dián változhat. Használja a [getDependingSlides](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--) metódust a befolyásolt diák azonosításához az elrendezés szerkesztése előtt.

**Mi történik, ha egy még használatban lévő elrendezést eltávolítok?**

Az Aspose.Slides egy [PptxEditException](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pptxeditexception/) kivételt dob. Először rendelje át a függő diákat, vagy használja a [removeUnusedLayoutSlides](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) metódust, hogy csak a nem hivatkozott elrendezéseket távolítsa el.