---
title: Diaelrendezések alkalmazása vagy módosítása Java-ban
linktitle: Diaelrendezés
type: docs
weight: 60
url: /hu/java/slide-layout/
keywords:
- diaelrendezés
- tartalomelrendezés
- helyőrző
- bemutató tervezés
- dia tervezés
- nem használt elrendezés
- lábléc láthatóság
- címdia
- cím és tartalom
- szakaszfejléc
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
- Java
- Aspose.Slides
description: "Diaelrendezések alkalmazása, létrehozása és módosítása az Aspose.Slides for Java-ban, helyőrzők hozzáadása, nem használt elrendezések eltávolítása és a lábléc láthatóságának vezérlése."
---
## **Áttekintés**

A diaelrendezés meghatározza a helyőrzők, például címek, szöveg, képek, diagramok és táblázatok pozícióját és formázását. Az elrendezés alkalmazása konzisztens szerkezetet ad a diák számára, miközben minden dia saját tartalmát tartalmazhatja.

A leggyakoribb elrendezések:

- **Címdia**: Cím és alcím helyőrzőket tartalmaz.
- **Cím és tartalom**: Cím helyőrzőt és egy általános célú tartalom helyőrzőt tartalmaz.
- **Üres**: Nem tartalmaz tartalom helyőrzőket, és akkor hasznos, amikor minden alakzatot kézzel pozícionálnak.

## **Az elrendezés öröklődésének megértése**

Egy bemutató három kapcsolódó szinttel rendelkezik:

1. Egy [master dia](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imasterslide/) meghatározza a témát, a megosztott formázást, a háttereket és a közös objektumokat.
1. Egy [elrendezési dia](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilayoutslide/) egy masterhez tartozik, és egy adott helyőrző elrendezést definiál.
1. Egy [normál dia](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islide/) egy elrendezést használ, és tárolja a diára beírt tartalmat.

Egy normál dia az elrendezéstől örökli a témát és a formázást, az elrendezés pedig a mastertől. Egy közvetlenül a normál diára beállított érték felülírja az örökölt értéket azon a szinten. Amikor egy normál diát hozunk létre, a helyőrző alakzatok a kiválasztott elrendezésből generálódnak, míg a helyőrzőkbe beírt tartalom a normál dia része.

Adjunk hozzá szükséges helyőrzőket egy elrendezéshez, mielőtt diák létrehoznánk belőle. Egy másik helyőrző későbbi hozzáadása az elrendezéshez nem ad automatikusan hozzá megfelelő helyőrző alakzatot a már létező normál diákhoz.

Ennek a kapcsolatnak két fontos következménye van:

- A örökölt formázás vagy a meglévő helyőrző geometria módosítása egy elrendezésen frissítheti az összes rá támaszkodó diát. Mielőtt egy már használt elrendezést szerkesztenénk, ellenőrizzük a függő diákat, és tekintsük át a keletkezett bemutatót.
- Egy elrendezést, amelyet még egy dia használ, nem lehet eltávolítani. Előbb rendeljük át a függő diákat egy másik elrendezéshez, vagy csak a nem használt elrendezéseket távolítsuk el.

További információért a hierarchia felső szintjéről lásd a [Dia master](/slides/hu/java/slide-master/).

Az örökölt logók vagy díszítő master alakzatok elrejtéséhez egy dián vagy egy megosztott elrendezésen keresztül, lásd a [Mestergrafikák láthatóságának vezérlése](/slides/hu/java/slide-master/). A példában két diát hasonlítanak össze, amelyek ugyanazt a mastert használják.

## **Diaelrendezés kiválasztása és alkalmazása**

Használjunk elrendezéstípust, amikor a bemutató a PowerPoint standard elrendezésdefinícióit követi. Az elrendezésnevek szerkeszthetők és lokalizálhatók, ezért a név alapú kiválasztás kevésbé megbízható, hacsak nem ellenőrizzük a forrás sablont.

A következő példa az **Cím és tartalom** elrendezést keresi az első masteren. Ha ez az elrendezés nem érhető el, szándékosan a **Üres** elrendezésre tér vissza. A második null ellenőrzés szükséges, mert egy bemutató csak egyéni elrendezéseket tartalmazhat. A kiválasztott elrendezést ezután a [ISlide.setLayoutSlide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-) metódussal alkalmazzuk az első normál diára.

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

Egy dia elrendezésének módosítása nem távolítja el az közvetlenül a diára hozzáadott általános alakzatokat. A helyőrző pozíciók, az örökölt formázás és a meglévő helyőrzők és az új elrendezés közötti megfelelés azonban megváltozhat, ezért ellenőrizzük a kimenetet, amikor jelentősen eltérő elrendezések között váltunk.

## **Elrendezési dia hozzáadása**

A kiválasztás és a létrehozás külön műveletek. Az előző példa egy meglévő elrendezést választ ki; nem hoz létre újat. Egy elrendezés létrehozásához hívjuk meg a [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) metódust a cél master elrendezésgyűjteményén.

A következő példa mindig hozzáad egy új **Cím és tartalom** elrendezést `Report Title and Content` néven, majd ennek alapján egy normál diát hoz létre. Az elrendezésneveknek egyedieknek kell lenniük a gyűjteményen belül.

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

Csak akkor adjunk hozzá elrendezést, ha a sablon valóban szükségét érzi egy új újrahasználható struktúrának. Ha már létezik megfelelő elrendezés, válasszuk ki és használjuk újra a duplikálás helyett.

## **Helyőrzők hozzáadása egy elrendezési diához**

Az [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) metódus egy [ILayoutPlaceholderManager](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilayoutplaceholdermanager/) objektumot ad a helyőrző alakzatok elrendezéshez való hozzáadásához.

| PowerPoint helyőrző              | `ILayoutPlaceholderManager` metódus |
| --------------------------------- | ----------------------------------- |
| ![Content](content.png)           | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![Content (Vertical)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![Text](text.png)                 | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![Text (Vertical)](textV.png)     | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![Picture](picture.png)           | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![Chart](chart.png)               | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![Table](table.png)               | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png)         | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![Media](media.png)               | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![Online Image](onlineImage.png)  | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

A következő példa ellenőrzi, hogy a **Üres** elrendezés létezik-e, négy helyőrzőt ad hozzá, majd létrehoz egy normál diát, amely a módosított elrendezést használja. A sorrend szándékos: a helyőrzőket a normál dia létrehozása előtt adjuk hozzá, így az Aspose.Slides generálhatja a megfelelő helyőrző alakzatokat azon a dián.

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

![A helyőrzők az elrendezési dián](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Az örökölt formázás vagy a meglévő elrendezési helyőrzők geometriai módosítása befolyásolhatja a függő diákat. Egy újonnan hozzáadott elrendezési helyőrző nem kerül visszafelé a már létező normál diákba. Teszteljük az elrendezés változásait egy bemutató másolatán, és ellenőrizzük minden függő diát.
{{% /alert %}}

## **Nem használt elrendezési diák eltávolítása**

Használjuk a [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/hu/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) metódust a olyan elrendezések eltávolítására, amelyeket egyetlen normál dia sem hivatkozik. A metódus érintetlenül hagyja a még használt elrendezéseket.

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

Egy konkrét elrendezés eltávolításához először használjuk a [hasDependingSlides](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilayoutslide/#hasDependingSlides--) vagy a [getDependingSlides](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilayoutslide/#getDependingSlides--) metódust. Minden függő diát rendeljünk át, mielőtt meghívnánk az [ILayoutSlide.remove](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilayoutslide/#remove--) metódust. Egy használt elrendezés eltávolítása [PptxEditException](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pptxeditexception/) kivételt eredményez.

## **Lábléc láthatóságának szabályozása egy elrendezési dián**

Egy elrendezés saját lábléc, dia-szám és dátum-idő helyőrzőkkel rendelkezik. Használjuk a [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) metódust ezeknek a helyőrzőknek a szabályozására egy elrendezésen belül. Ez akkor hasznos, ha például a tartalom elrendezéseknek láblécet kell mutatniuk, de a címdia elrendezéseknek nem.

A következő példa biztonságosan kiválaszt egy elrendezést, és láthatóvá teszi a láblécelemét:

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

## **Lábléc láthatóságának szabályozása egy mesteren és annak gyermek elrendezésein**

A mesterhierarchia egységes láblécbeállításainak alkalmazásához használjuk a [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imasterslide/#getHeaderFooterManager--) metódust. Az [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imasterslideheaderfootermanager/) terjesztési metódusai a masteren és annak függő elrendezési és normál diáin működnek; nem csak egyetlen normál diát céloznak.

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

**Mi a különbség a master dia és az elrendezési dia között?**

A master dia definiálja a bemutató témáját és a megosztott formázást. Egy elrendezési dia egy masterhez tartozik, és egy újrahasználható helyőrző elrendezést definiál. A normál diák ezeket az elrendezéseket használják, és a diára specifikus tartalmat tárolják.

**Másolhatok-e egy elrendezési diát egy bemutatóból a másikba?**

Igen. Adjunk egy másolatot a célgyűjteményhez a [addClone](https://reference.aspose.com/slides/hu/java/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) metódussal. Másoláskor a forrás elrendezés által használt betűtípusokat, témákat, képeket és egyéb erőforrásokat is ellenőrizni kell.

**Mi történik, ha módosítok egy már használatban lévő elrendezést?**

A függő diák öröklik az elrendezés változásait, hacsak nem írják felül a helyi formázást vagy objektumokat. Ennek következtében a helyőrző geometria és az örökölt stílus sok dián egyszerre változhat. Használjuk a [getDependingSlides](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilayoutslide/#getDependingSlides--) metódust a érintett diák azonosításához a szerkesztés előtt.

**Mi történik, ha eltávolítok egy még használatban lévő elrendezést?**

Az Aspose.Slides [PptxEditException](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pptxeditexception/) kivételt dob. Előbb rendeljük át a függő diákat, vagy használjuk a [removeUnusedLayoutSlides](https://reference.aspose.com/slides/hu/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) metódust csak a nem hivatkozott elrendezések eltávolításához.