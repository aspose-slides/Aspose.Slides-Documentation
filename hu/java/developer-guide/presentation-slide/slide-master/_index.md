---
title: Prezentáció dia mesterek kezelése Java-ban
linktitle: Dia mester
type: docs
weight: 70
url: /hu/java/slide-master/
keywords:
- dia mester
- mester dia
- PPT mester dia
- több mester dia
- mester diák összehasonlítása
- háttér
- helyőrző
- mester dia klónozása
- mester dia másolása
- mester dia duplikálása
- használaton kívüli mester dia
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Dia mesterek kezelése az Aspose.Slides for Java-ban: hozzáférés, szerkesztés, klónozás, összehasonlítás és mester diák eltávolítása PowerPoint és OpenDocument prezentációkban."
---
## **Áttekintés**

A **slide master** meghatározza a közös tervezési beállításokat egy diacsoport számára. Tartalmazhat közös alakzatokat, logókat, háttereket, szövegstílusokat, téma beállításokat és lábléc beállításokat. A PowerPointban a slide master szerkesztése a szokásos módja annak, hogy a bemutató konzisztens maradjon anélkül, hogy minden dián megismételné a formázást.

Az Aspose.Slides for Java támogatja ugyanazt a modellt. Egy bemutató egy vagy több mester diát tartalmazhat, és minden mester dia több elrendezési diát tartalmazhat. A normál diák általában nem hivatkoznak közvetlenül egy mester diára. Ehelyett egy normál dia egy elrendezési diát használ, és az az elrendezési dia egy mester diához tartozik.

A hierarchia a következő:

1. **Dia mester** - meghatározza a közös tervezést és a témát.  
1. **Elrendezési dia** - meghatároz egy konkrét elrendezést helyőrzőkkel és az elrendezés szintjén lévő formázással.  
1. **Normál dia** - tartalmazza a tényleges bemutató tartalmat, és egy elrendezési diát használ.

![A mester diákok, elrendezési diák és normál diákok hierarchiája](slide-master_2.jpg)

Az Aspose.Slides‑ban a slide master a [IMasterSlide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imasterslide/) interfész által van ábrázolva. A bemutató összes mester diája a [Presentation.getMasters](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getMasters--) gyűjteményen keresztül érhető el, amely a [IMasterSlideCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imasterslidecollection/) interface‑t valósítja meg.

{{% alert color="info" title="Inheritance" %}}
Ha ugyanaz a tulajdonság több szinten is definiálva van, a specifikusabb szint nyer. Például, ha egy mester dia és egy elrendezési dia is definiál egy háttérszínt, akkor az az elrendezésen alapuló diák az elrendezési hátteret használják. További információért az elrendezési diákról lásd a [Apply or Change Slide Layouts](/slides/hu/java/slide-layout/) oldalt.
{{% /alert %}}

## **Mester diákok elérése**

A PowerPointban a Slide Master nézetet a **View** > **Slide Master** menüből nyithatod meg.

![A Slide Master parancs a PowerPoint Nézet lapján](slide-master_3.jpg)

Az Aspose.Slides‑ban használd a `getMasters()` gyűjteményt a mester diák eléréséhez:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
    int masterSlideCount = presentation.getMasters().size();
    int firstMasterLayoutSlideCount = firstMasterSlide.getLayoutSlides().size();

    System.out.println("Master slides: " + masterSlideCount);
    System.out.println("Layouts in the first master: " + firstMasterLayoutSlideCount);
} finally {
    presentation.dispose();
}
```

A normál dia által használt mester diát is lekérheted a layoutja alapján:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = slide.getLayoutSlide();
    IMasterSlide masterSlide = layoutSlide.getMasterSlide();
    String masterSlideName = masterSlide.getName();

    System.out.println(masterSlideName);
} finally {
    presentation.dispose();
}
```

## **Mi található egy slide masterben**

A mester dia egy diához hasonló objektum. Implementálja az [IBaseSlide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibaseslide/) interfészt, ezért ugyanazokat a dia tulajdonságokat teszi elérhetővé, amiket a normál és elrendezési diák használnak. A mester‑specifikus tagok a [IMasterSlide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imasterslide/) API oldalon vannak felsorolva.

A leggyakrabban használt mester diaszemek a következők:

| Tag | Cél |
| --- | --- |
| `getBackground()` | Beállítja a mester szintű dia háttérét. |
| `getShapes()` | Elhelyezett alakzatokat tárol a mesteren, például logókat, kép kereteket és közös szöveget. |
| `getLayoutSlides()` | Tárolja a mesterhez tartozó elrendezési diákat. |
| `getThemeManager()` | Hozzáférést biztosít a mester téma API‑khoz. |
| `getHeaderFooterManager()` | Kezeli a fejlécet, láblécet, dátumokat és dia számokat a mester és a gyermek elrendezések számára. |
| `getDependingSlides()` | Visszaadja a normál diát, amelyek a mesterre épülnek a layoutjaikon keresztül. |

## **Kép hozzáadása egy slide masterhez**

Amikor képet adsz hozzá egy mester diához, az megjelenik azokon a diákon, amelyek azt az elrendezést használják. Ez hasznos logók, vízjelek, dísz sávok és egyéb ismétlődő vizuális elemek esetén.

A következő példa logót ad az első mester diához:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    IImage logo = Images.fromFile("logo.png");

    try {
        IPPImage logoImage = presentation.getImages().addImage(logo);

        masterSlide.getShapes().addPictureFrame(
                ShapeType.Rectangle,
                20,
                20,
                80,
                80,
                logoImage);
    } finally {
        logo.dispose();
    }

    presentation.save("presentation-with-logo.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

További információk a kép keretekről a [Picture Frame](/slides/hu/java/picture-frame/) oldalon.

## **A mester grafikai elemek láthatóságának vezérlése**

Használd a [IBaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibaseslide/#setShowMasterShapes-boolean-) metódust, hogy elrejtsd a örökölt mester grafikai elemeket, például logókat vagy dísz alakzatokat, anélkül hogy törölnéd őket a mesterből. A `false` értéket add át a [Slide.setShowMasterShapes](https://reference.aspose.com/slides/hu/java/com.aspose.slides/slide/#setShowMasterShapes-boolean-) metódusnak azon a dián, amelyiknek el kell rejtenie ezeket a grafikai elemeket, és `true`‑t hagyj más diákon, amelyeknek meg kell jeleníteniük őket.

A következő önálló példa kék dísz sávot hoz létre egy mesteren, és két diát, amelyek ugyanazt az üres elrendezést használják. A sáv látható az első dián, a másodikon rejtve van. Nem szükséges bemeneti bemutató vagy kép.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide layoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    layoutSlide.setShowMasterShapes(true);

    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();
    IAutoShape band = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
    Color bandColor = new Color(70, 130, 180);
    band.getFillFormat().setFillType(FillType.Solid);
    band.getFillFormat().getSolidFillColor().setColor(bandColor);
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    ISlide visibleSlide = presentation.getSlides().get_Item(0);
    visibleSlide.setLayoutSlide(layoutSlide);
    visibleSlide.getShapes().clear();

    ISlide hiddenSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    visibleSlide.setShowMasterShapes(true);
    hiddenSlide.setShowMasterShapes(false);

    presentation.save("master-graphics.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A példa a **Blank** elrendezést használja, amely egy új bemutatóval együtt kerül szállításra, és eltávolítja az első dia saját helyőrzőit.

### **A beállítás hatókörének kiválasztása**

A normál dia a mesterét a [ISlide.getLayoutSlide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islide/#getLayoutSlide--) és [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilayoutslide/#getMasterSlide--) segítségével használja. A tulajdonság egyedi dián való beállítása csak arra a diára van hatással. A `false` átadása a [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/hu/java/com.aspose.slides/layoutslide/#setShowMasterShapes-boolean-) metódusnak elrejti a mester grafikai elemeket azoknak a diáknak, amelyek azt a megosztott elrendezést használják, még akkor is, ha saját beállításuk `true`. Egyetlen dia grafikai elemeinek elrejtéséhez módosítsd a dia tulajdonságát, és hagyd a megosztott elrendezést változatlanul.

A beállítás nem támogatott a mester dia láthatóságának vezérlésére. Egy mesteren a [getShowMasterShapes](https://reference.aspose.com/slides/hu/java/com.aspose.slides/masterslide/#getShowMasterShapes--) mindig `false` értéket ad vissza, és a [setShowMasterShapes](https://reference.aspose.com/slides/hu/java/com.aspose.slides/masterslide/#setShowMasterShapes-boolean-) `true` értékének átadása kivételt eredményez. Alkalmazd inkább egy normál vagy egy elrendezési diára.

### **Grafikai elemek megkülönböztetése a háttértől**

| Művelet | Hatás |
| --- | --- |
| Mester grafikai elemek elrejtése | Szabályozza az örökölt mester alakzatok láthatóságát anélkül, hogy törölné őket vagy megváltoztatná a dia saját alakzatait. |
| Dia háttér kitöltésének módosítása | Megváltoztatja a háttér színét, színátmenetét vagy képét. A mester grafikai elemek külön alakzatok, és láthatóak maradhatnak a háttér fölött. Lásd a [Presentation Background](/slides/hu/java/presentation-background/). |
| Alakzat törlése a mesterből | Eltávolítja a közös forrás alakzatot, így már nem lesz elérhető semelyik diához, amelyik azt a mestert használja. |

## **Helyőrzőkkel való munka**

A helyőrzőket általában az elrendezési diák definiálják. A mester dia biztosítja a közös stílust és témát, amelyet ezek az elrendezések örökölnek, míg minden elrendezés meghatározza, hogy mely helyőrzők állnak rendelkezésre és hol helyezkednek el.

PowerPointban a helyőrző parancsok a Slide Master nézetben érhetők el.

![A Insert Placeholder parancs a PowerPoint Slide Master nézetben](slide-master_5.png)

Új helyőrzők hozzáadásához az Aspose.Slides segítségével, dolgozz a mesterhez tartozó elrendezési diával:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide blankLayoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);

    if (blankLayoutSlide == null) {
        blankLayoutSlide = masterSlide.getLayoutSlides().add(SlideLayoutType.Blank, "Blank");
    }

    blankLayoutSlide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80);

    presentation.getSlides().addEmptySlide(blankLayoutSlide);
    presentation.save("presentation-with-placeholder.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Formázhatod a már létező helyőrző alakzatokat a mester dián. A következő példa megtalálja a cím helyőrzőt és lineáris színátmenetes kitöltést alkalmaz:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    IAutoShape titlePlaceholder = null;

    for (IShape shape : masterSlide.getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;

            if (autoShape.getPlaceholder() != null &&
                    autoShape.getPlaceholder().getType() == PlaceholderType.Title) {
                titlePlaceholder = autoShape;
                break;
            }
        }
    }

    if (titlePlaceholder != null) {
        Color redGradientColor = new Color(255, 0, 0);
        Color purpleGradientColor = new Color(128, 0, 128);

        titlePlaceholder.getFillFormat().setFillType(FillType.Gradient);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0f, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(1.0f, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Formázott cím helyőrző, amelyet a normál diák örökölnek](slide-master_8.png)

További helyőrző és szövegformázási lehetőségekért lásd a [Set Prompt Text in Placeholder](/slides/hu/java/manage-placeholder/) és a [Text Formatting](/slides/hu/java/text-formatting/) oldalakat.

## **Slide master háttér módosítása**

A mester háttér az elrendezések és diák számára öröklődik, ha nem írják felül. A következő példa egy egyszínes háttérszínt állít be az első mester diának:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    Color masterBackgroundColor = Color.GREEN;

    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kapcsolódó témák: [Presentation Background](/slides/hu/java/presentation-background/) és [Presentation Theme](/slides/hu/java/presentation-theme/).

## **Slide master klónozása egy másik bemutatóba**

Használd az [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) metódust, hogy egy mester diát átmásolj egy másik bemutatóba. A másolt mester aztán használható lesz az elrendezések és diák számára a célbemutatóban.

```java
import com.aspose.slides.*;

Presentation sourcePresentation = new Presentation("source.pptx");
Presentation destinationPresentation = new Presentation("destination.pptx");
try {
    IMasterSlide sourceMasterSlide = sourcePresentation.getMasters().get_Item(0);
    IMasterSlide clonedMasterSlide = destinationPresentation.getMasters().addClone(sourceMasterSlide);

    destinationPresentation.save("destination-with-master.pptx", SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
    destinationPresentation.dispose();
}
```

Ha normál diát szeretnél a mesterrel együtt klónozni, lásd a [Clone Slides](/slides/hu/java/clone-slides/) oldalt.

## **Több slide master hozzáadása**

Egy bemutató több mester diát is tartalmazhat. Ez hasznos, ha a különböző szakaszok eltérő márkázást, oldalstruktúrát vagy téma beállításokat igényelnek.

![PowerPoint parancsok mester diák beszúrásához és kezeléséhez](slide-master_9.jpg)

A következő példa klónozza az alapértelmezett mestert, külön háttérrel látja el a klónt, egy elrendezést hoz létre a klónozott mester alatt, és egy új diát ad hozzá az elrendezés alapján:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    Color sectionMasterBackgroundColor = Color.LIGHT_GRAY;

    sectionMasterSlide.getBackground().setType(BackgroundType.OwnBackground);
    sectionMasterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    sectionMasterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(sectionMasterBackgroundColor);

    ILayoutSlide sourceBlankLayout = defaultMasterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    if (sourceBlankLayout == null) {
        sourceBlankLayout = defaultMasterSlide.getLayoutSlides().get_Item(0);
    }

    ILayoutSlide sectionBlankLayout = sectionMasterSlide.getLayoutSlides().addClone(sourceBlankLayout);

    presentation.getSlides().addEmptySlide(sectionBlankLayout);
    presentation.save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Slide master összehasonlítása**

A mester diák összehasonlíthatók az [IBaseSlide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibaseslide/) által örökölt `equals` metódussal. Az összehasonlítás a struktúrát és a statikus tartalmat vizsgálja, például alakzatokat, szöveget, formázást, animációkat és egyéb dia beállításokat. Nem hasonlítja össze az egyedi azonosítókat, mint a dia ID‑k, vagy a dinamikus helyőrző értékeket, mint a jelenlegi dátum.

```java
import com.aspose.slides.*;

Presentation firstPresentation = new Presentation("first.pptx");
Presentation secondPresentation = new Presentation("second.pptx");
try {
    int firstPresentationMasterCount = firstPresentation.getMasters().size();
    int secondPresentationMasterCount = secondPresentation.getMasters().size();

    for (int firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++) {
        for (int secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++) {
            IMasterSlide firstMasterSlide = firstPresentation.getMasters().get_Item(firstMasterIndex);
            IMasterSlide secondMasterSlide = secondPresentation.getMasters().get_Item(secondMasterIndex);
            boolean areMasterSlidesEqual = firstMasterSlide.equals(secondMasterSlide);

            if (areMasterSlidesEqual) {
                System.out.printf(
                        "first.pptx master #%d equals second.pptx master #%d%n",
                        firstMasterIndex,
                        secondMasterIndex);
            }
        }
    }
} finally {
    firstPresentation.dispose();
    secondPresentation.dispose();
}
```

További információkért lásd a [Compare Presentation Slides](/slides/hu/java/compare-slides/) oldalt.

## **A Slide Master nézet beállítása alapértelmezett nézetként**

Használd a `setLastView` metódust a [ViewProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/viewproperties/) objektumon, hogy szabályozd a PowerPoint által először megnyitott nézetet. A következő példa Slide Master nézetben nyitja meg a bemutatót:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

További nézetbeállításokért lásd a [Save Presentation](/slides/hu/java/save-presentation/) oldalt.

## **Használaton kívüli mester diákok eltávolítása**

A bemutatók néha tartalmaznak olyan mester diákat, amelyeket már nem használ egyetlen normál dia sem. A használaton kívüli mester diák eltávolítása csökkentheti a fájlméretet és egyszerűsítheti a sablon karbantartását.

Használd a `removeUnused` metódust, hogy eltávolítsd a használaton kívüli mestereket a `getMasters()` gyűjteményből:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Alkalmazhatod továbbá az alacsony kódú [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/hu/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) metódust is:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Mi a különbség a slide master és az layout slide között?**

A slide master a közös tervezési beállításokat definiálja, mint például a téma, háttér, közös alakzatok és szövegstílusok. Egy layout slide a master slide‑hez tartozik, és egy konkrét helyőrző elrendezést határoz meg. Egy normál dia egy layout slide‑ot használ, így mind a layouttól, mind a mastertől örököl.

**Tartalmazhat egy bemutató több slide mastert?**

Igen. Egy bemutató több slide mastert is tartalmazhat. Használj több mestert, ha a különböző szakaszoknak eltérő vizuális rendszerekre vagy márkázásra van szükségük.

**Hol kell helyőrzőket hozzáadni, a master slide‑hez vagy a layout slide‑hez?**

A legtöbb esetben a layout slide‑okra kell helyőrzőket adni. A közös vizuális elemeket és a közös formázást a master slide‑re helyezd, majd a tartalom helyőrzőket azokra az elrendezésekre, amelyeket a normál diák használnak.

**Törölhetek egy még használatban lévő master slide‑ot?**

Nem. Egy olyan master slide, amelynek függő diái vannak, nem távolítható el biztonságosan közvetlenül. Először helyezd át ezeket a diákat egy másik master alatti layoutokra, vagy használd a nem használt mester takarítási módszert, amely csak a nem használt master slide‑okat távolítja el.