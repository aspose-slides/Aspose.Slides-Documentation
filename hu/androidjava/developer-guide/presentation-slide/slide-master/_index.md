---
title: Prezentációs dia mesterek kezelése Androidon
linktitle: Dia mester
type: docs
weight: 70
url: /hu/androidjava/slide-master/
keywords:
- dia mester
- mester dia
- PPT mester dia
- több mester dia
- mester diák összehasonlítása
- háttér
- helyettesítőelem
- mester dia klónozása
- mester dia másolása
- mester dia duplikálása
- nem használt mester dia
- PowerPoint
- OpenDocument
- bemutató
- Android
- Java
- Aspose.Slides
description: "Dia mesterek kezelése az Aspose.Slides for Android via Java segítségével: hozzáférés, szerkesztés, klónozás, összehasonlítás és a mester diák eltávolítása PowerPoint és OpenDocument bemutatókban."
---
## **Áttekintés**

Az **dia mester** közös tervezési beállításokat határoz meg egy diacsoport számára. Tartalmazhat közös alakzatokat, logókat, háttérképeket, szövegstílusokat, téma‑beállításokat és lábléc‑beállításokat. A PowerPointban a dia mester szerkesztése a szokásos módja annak, hogy a bemutató következetes legyen anélkül, hogy minden dián megismételné ugyanazt a formázást.

Az Aspose.Slides for Android via Java támogatja ugyanazt a modellt. Egy bemutató egy vagy több mesterdiát tartalmazhat, és minden mesterdia több elrendezés diához tartozhat. A normál diák általában nem hivatkoznak közvetlenül egy mesterdiára. Ehelyett egy normál dia egy elrendezés diát használ, és ez az elrendezés dia egy mesterdiához tartozik.

A hierarchia a következő:

1. **Dia mester** – meghatározza a közös tervezést és a témát.
2. **Elrendezés dia** – meghatároz egy adott helyettesítőelemek és elrendezési szintű formázás elrendezését.
3. **Normál dia** – tartalmazza a tényleges bemutató tartalmat, és egy elrendezés diát használ.

![A mesterdiák, elrendezés dia és normál dia hierarchiája](slide-master_2.jpg)

Az Aspose.Slides-ben egy dia mester a [IMasterSlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imasterslide/) interfész által van képviselve. A bemutató összes mesterdiát a [Presentation.getMasters](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#getMasters--) gyűjteményen keresztül érhetjük el, amely a [IMasterSlideCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imasterslidecollection/) implementálja. A teljes Android via Java API felületért lásd a [com.aspose.slides API reference](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/).

{{% alert color="info" title="Inheritance" %}}
Amikor ugyanaz a tulajdonság több szinten is definiálva van, a specifikusabb szint nyer. Például, ha egy mesterdia és egy elrendezés dia is meghatároz egy háttérképet, akkor az az elrendezésen alapuló diák az elrendezés háttérképét használják. További információért az elrendezés diákról lásd a [Apply or Change Slide Layouts](/slides/hu/androidjava/slide-layout/).
{{% /alert %}}

## **Mesterdiák elérése**

A PowerPointban a dia mester nézetet a **Nézet** > **Dia mester** menüből nyithatja meg.

![A Dia mester parancs a PowerPoint Nézet lapon](slide-master_3.jpg)

Az Aspose.Slides-ben használja a `getMasters()` gyűjteményt a mesterdiák eléréséhez:

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

Azt is lekérheti, hogy egy normál dia melyik mesterdiát használja az elrendezésén keresztül:

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

## **A dia mester tartalma**

A mesterdia egy diára hasonló objektum. Implementálja a [IBaseSlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibaseslide/) interfészt, így számos, a normál és elrendezés diák által használt diatulajdonságot tesz elérhetővé.

Az általában használt mesterdia tagok a következők:

| Member | Cél |
| --- | --- |
| `getBackground()` | Beállítja a mester szintű dia háttérét. |
| `getShapes()` | A mesterre helyezett alakzatokat tárolja, például logókat, képkockákat és közös szöveget. |
| `getLayoutSlides()` | A mesterhez tartozó elrendezés diák tárolja. |
| `getThemeManager()` | Hozzáférést biztosít a mester téma API-khoz. |
| `getHeaderFooterManager()` | A fejléc, lábléc, dátumok és dia számok vezérlését biztosítja a mester és annak alárendelt elrendezései számára. |
| `getDependingSlides()` | Visszaadja azokat a normál diákat, amelyek elrendezéseiken keresztül a mesterre támaszkodnak. |

## **Kép hozzáadása egy dia mesterhez**

Amikor képet ad hozzá egy mesterdiához, az megjelenik azokon a diákon, amelyek az adott mester elrendezéseit használják. Ez hasznos logókhoz, vízjelekhez, díszítő szalagokhoz és egyéb ismétlődő vizuális elemekhez.

A következő példa egy logót ad hozzá az első mesterdiához:

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

További információért a képkockákról lásd a [Picture Frame](/slides/hu/androidjava/picture-frame/).

## **A mester grafika láthatóságának vezérlése**

Használja az [IBaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibaseslide/#setShowMasterShapes-boolean-) metódust, hogy elrejtse a örökölt mestergrafikákat, például logókat vagy díszítő alakzatokat, anélkül, hogy törölné őket a mesterből. Adjon `false` értéket a [Slide.setShowMasterShapes](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slide/#setShowMasterShapes-boolean-) hívásnak azon a dián, amelyiknek el kell hagynia ezeket a grafikákat, és `true`-t tartson rajtuk azon diákon, amelyeknek meg kell jeleníteniük őket.

A következő önálló példa egy kék díszítő szalagot hoz létre egy mesteren, és két diát, amelyek ugyanazt az üres elrendezést használják. A szalag látható az első dián, a másodikon rejtett. Nem szükséges bemeneti bemutató vagy kép.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide layoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    layoutSlide.setShowMasterShapes(true);

    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();
    IAutoShape band = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
    int bandColor = Color.rgb(70, 130, 180);
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

A példa a **Blank** (Üres) elrendezést használja egy új bemutatóban, és eltávolítja az első dia saját helyettesítőelemeit.

### **A beállítás hatókörének kiválasztása**

Egy normál dia a mesterét a [ISlide.getLayoutSlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islide/#getLayoutSlide--) és a [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilayoutslide/#getMasterSlide--) segítségével használja. Egy adott dián a tulajdonság beállítása csak arra a diára hat. `false` átadása a [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/layoutslide/#setShowMasterShapes-boolean-) metódusnak elrejti a mestergrafikákat azokat a diákon, amelyek az adott közös elrendezést használják, még akkor is, ha saját beállításuk `true`. Ahhoz, hogy csak egy dián rejtsen el grafikákat, módosítsa a diátulajdonságot, és hagyja változatlanul a közös elrendezést.

A beállítás nem támogatott láthatóságvezérlőként a mesterdián. Egy mesteren a [getShowMasterShapes](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/masterslide/#getShowMasterShapes--) mindig `false`‑t ad vissza, és `true` átadása a [setShowMasterShapes](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/masterslide/#setShowMasterShapes-boolean-) metódusnak kivételt dob. Alkalmazza normál diára vagy elrendezésre.

### **A grafika és a háttér megkülönböztetése**

| Művelet | Hatás |
| --- | --- |
| Elrejti a mestergrafikákat | Szabályozza az örökölt mesteralakzatok láthatóságát anélkül, hogy törölné őket vagy megváltoztatná a dia saját alakzatait. |
| Változtatja a dia háttér kitöltését | Módosítja a háttér színét, színátmenetét vagy képét. A mestergrafikák különálló alakzatok, és láthatóak maradhatnak a háttér felett. Lásd a [Presentation Background](/slides/hu/androidjava/presentation-background/). |
| Töröl egy alakzatot a mestertől | Eltávolítja a megosztott forrásalakzatot, így már nem áll rendelkezésre a mesterhez tartozó bármely dia számára. |

## **Helyettesítőelemek kezelése**

A helyettesítőelemeket általában az elrendezés diákon definiálják. A mesterdia biztosítja a közös stílust és témát, amelyet az elrendezések örökölnek, míg minden elrendezés eldönti, hogy mely helyettesítőelemek állnak rendelkezésre és hol helyezkednek el.

A PowerPointban a helyettesítőelemek parancsai a Dia mester nézetben érhetők el.

![A Helyettesítő elem beszúrása parancs a PowerPoint Dia mester nézetben](slide-master_5.png)

Új helyettesítőelemek hozzáadásához az Aspose.Slides-ben, dolgozzon a mesterhez tartozó elrendezés diával:

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

A már a mesterdián létező helyettesítő alakzatokat is formázhatja. A következő példa megtalálja a cím helyettesítőelemet és lineáris színátmenetes kitöltést alkalmaz rá:

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

![Formázott cím helyettesítőelem, amelyet a normál diák örökölnek](slide-master_8.png)

További helyettesítő és szövegformázási lehetőségekért lásd a [Set Prompt Text in Placeholder](/slides/hu/androidjava/manage-placeholder/) és a [Text Formatting](/slides/hu/androidjava/text-formatting/) oldalakat.

## **A dia mester háttérének módosítása**

A mester háttér öröklődik az elrendezések és diák által, amelyek nem írják felül. A következő példa egy egyszínű háttérszínt állít be az első mesterdiára:

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

Kapcsolódó témákért lásd a [Presentation Background](/slides/hu/androidjava/presentation-background/) és a [Presentation Theme](/slides/hu/androidjava/presentation-theme/) oldalakat.

## **Dia mester klónozása egy másik bemutatóba**

Használja az [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) metódust, hogy egy mesterdiát másik bemutatóba másoljon. A másolt mester ezután az elrendezések és diák által felhasználható a célbemutatóban.

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

Ha a normál diákot is klónozni kell a mesterrel együtt, lásd a [Clone Slides](/slides/hu/androidjava/clone-slides/) oldalt.

## **Több dia mester hozzáadása**

Egy bemutató több mesterdiát is tartalmazhat. Ez akkor hasznos, ha a különböző szekciók különböző márkázást, oldalstruktúrát vagy téma beállításokat igényelnek.

![PowerPoint parancsok mesterdiák beszúrásához és kezeléséhez](slide-master_9.jpg)

A következő példa klónozza az alapértelmezett mestert, másik háttérrel látja el a klónt, létrehoz egy elrendezést az adott klónozott mester alatt, és hozzáad egy új diát, amely ezt az elrendezést használja:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    Color sectionMasterBackgroundColor = Color.GRAY;

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

## **Dia mesterek összehasonlítása**

A mesterdiákat össze lehet hasonlítani az [IBaseSlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibaseslide/)-ből örökölt `equals` metódussal. Az összehasonlítás ellenőrzi a struktúrát és a statikus tartalmat, például alakzatokat, szöveget, formázást, animációkat és egyéb dia beállításokat. Nem hasonlítja össze az egyedi azonosítókat, például a dia ID‑kat, vagy a dinamikus helyettesítőelemek értékeit, például az aktuális dátumot.

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

További információért lásd a [Compare Presentation Slides](/slides/hu/androidjava/compare-slides/) oldalt.

## **Dia mester nézet beállítása alapértelmezett nézetként**

Használja a `setLastView` metódust a [ViewProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/viewproperties/)‑on, hogy szabályozza a nézetet, amelyet a PowerPoint elsőként nyit meg. A következő példa a bemutatót Dia mester nézetben nyitja meg:

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

További nézetbeállításokért lásd a [Save Presentation](/slides/hu/androidjava/save-presentation/) oldalt.

## **Használaton kívüli mesterdiák eltávolítása**

A bemutatók néha olyan mesterdiákat tartalmaznak, amelyeket már egyetlen normál dia sem használ. A nem használt mesterek eltávolítása csökkentheti a fájl méretét és egyszerűsítheti a sablon karbantartását.

Használja a `removeUnused` metódust a nem használt mesterek eltávolításához a `getMasters()` gyűjteményből:

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

Alkalmazhatja alacsony kódú [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) metódust is:

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

## **GYIK**

**Mi a különbség egy dia mester és egy elrendezés dia között?**

A dia mester a közös tervezési beállításokat definiálja, például témát, hátteret, közös alakzatokat és szövegstílusokat. Egy elrendezés dia egy mesterdiához tartozik, és egy adott helyettesítőelemek elrendezését határozza meg. Egy normál dia egy elrendezés diát használ, ezért mind az elrendezés, mind a mester tulajdonságait örökli.

**Tartalmazhat egy bemutató több dia mestert?**

Igen. Egy bemutató több dia mestert is tartalmazhat. Használjon több mestert, ha a különböző szekciók különböző vizuális rendszereket vagy márkázást igényelnek.

**Hová tegyek helyettesítőelemeket, a mesterdiára vagy az elrendezés diára?**

A legtöbb esetben az elrendezés diákra helyezze a helyettesítőelemeket. A közös vizuális elemeket és a közös formázást a mesterdiára helyezze, majd a tartalomhelyettesítőelemeket azokra az elrendezésekre, amelyeket a normál diák használni fognak.

**Törölhetek egy még használt mesterdiát?**

Nem. Egy olyan mesterdia, amelynek függő diák vannak, nem távolítható el közvetlenül. Először helyezze át ezeket a diákat egy másik mester alá tartozó elrendezésekbe, vagy használjon egy nem használt mester tisztító módszert, amely csak a nem használt mestereket távolítja el.