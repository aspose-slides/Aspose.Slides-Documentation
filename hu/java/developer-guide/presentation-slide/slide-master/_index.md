---
title: "Diák masterek kezelése Java-ban"
linktitle: "Dia master"
type: docs
weight: 70
url: /hu/java/slide-master/
keywords:
- "dia master"
- "master dia"
- "PPT master dia"
- "több master dia"
- "master diák összehasonlítása"
- "háttér"
- "helyettesítő"
- "master dia klónozása"
- "master dia másolása"
- "master dia duplikálása"
- "használaton kívüli master dia"
- "PowerPoint"
- "OpenDocument"
- "bemutató"
- "Java"
- "Aspose.Slides"
description: "Diák masterek kezelése az Aspose.Slides for Java-ban: hozzáférés, szerkesztés, klónozás, összehasonlítás és a master diák eltávolítása PowerPoint és OpenDocument bemutatókban."
---
## **Áttekintés**

Egy **slide master** meghatározza a közös tervezési beállításokat egy diacsoport számára. Tartalmazhat közös alakzatokat, logókat, háttereket, szövegstílusokat, témabeállításokat és láblécke beállításokat. A PowerPointban a slide master szerkesztése a szokásos módja annak, hogy egy bemutató konzisztens legyen, anélkül hogy minden dián ismételni kellene ugyanazt a formázást.

Az Aspose.Slides for Java ugyanazt a modellt támogatja. Egy bemutató egy vagy több master diát tartalmazhat, és minden master dia több layout diát is tartalmazhat. A normál diák általában nem hivatkoznak közvetlenül egy master diára. Ehelyett egy normál dia egy layout diát használ, és ez a layout dia egy master diához tartozik.

A hierarchia:

1. **Slide master** – meghatározza a közös tervezést és témát.  
1. **Layout slide** – meghatároz egy konkrét helykitöltő elrendezést és layout‑szintű formázást.  
1. **Normal slide** – a tényleges bemutatótartalmat tartalmazza, és egy layout diát használ.

![The hierarchy of master slides, layout slides, and normal slides](slide-master_2.jpg)

Az Aspose.Slidesban egy slide master a [IMasterSlide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imasterslide/) felülettel van reprezentálva. A bemutató összes master diája a [Presentation.getMasters](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getMasters--) gyűjteményen keresztül érhető el, amely a [IMasterSlideCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imasterslidecollection/) felületet valósítja meg.

{{% alert color="info" title="Öröklődés" %}}

Amikor ugyanaz a tulajdonság több szinten is definiálva van, a specifikusabb szint nyer. Például, ha egy master dia és egy layout dia egyaránt meghatároz egy hátteret, akkor az adott layout alapján készült diák a layout hátterét használják. A layout diákról további információkért lásd az [Apply or Change Slide Layouts](/slides/hu/java/slide-layout/) oldalt.

{{% /alert %}}

## **A slide master elérése**

A PowerPointban a **View** > **Slide Master** menüpontból nyitható meg a Slide Master nézet.

![The Slide Master command on the PowerPoint View tab](slide-master_3.jpg)

Az Aspose.Slidesban a `getMasters()` gyűjteményt kell használni a master diák eléréséhez:

```java
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

A normál dia által használt master diát a layoutján keresztül is lekérdezhetjük:

```java
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

A master dia egy diához hasonló objektum. Az [IBaseSlide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibaseslide/) felületet valósítja meg, így a normál és layout diákhoz hasonló tulajdonságok érhetők el rajta. A master‑specifikus tagok a [IMasterSlide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imasterslide/) API oldalán vannak felsorolva.

A leggyakrabban használt master dia tagok:

| Tag | Leírás |
| --- | --- |
| `getBackground()` | Beállítja a master‑szintű dia hátterét. |
| `getShapes()` | Tárolja a masterre helyezett alakzatokat, például logókat, képkereteket és megosztott szöveget. |
| `getLayoutSlides()` | Tárolja a masterhez tartozó layout diákot. |
| `getThemeManager()` | Hozzáférést biztosít a master téma API‑khoz. |
| `getHeaderFooterManager()` | Kezeli a fejléceket, lábléceket, dátumokat és dia számokat a master és az alárendelt layoutok számára. |
| `getDependingSlides()` | Visszaadja azokat a normál diákat, amelyek a masterhez a layoutjaikon keresztül kapcsolódnak. |

## **Kép hozzáadása egy slide masterhez**

Amikor egy képet adunk hozzá egy master diához, az a masterhez tartozó layoutot használó diákon is megjelenik. Ez logók, vízjelek, díszítősávok és egyéb ismétlődő vizuális elemek esetén hasznos.

Az alábbi példa hozzáad egy logót az első master diához:

```java
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

A képkeretekről további információk a [Picture Frame](/slides/hu/java/picture-frame/) oldalon találhatók.

## **Munkavégzés helyettesítőkkel (Placeholder)**

A helyettesítőket általában a layout diákon definiálják. A master dia biztosítja a közös stílust és témát, amelyet a layoutok örökölnek, míg minden layout eldönti, hogy mely helyettesítők állnak rendelkezésre és hol helyezkednek el.

PowerPointban a helyettesítő parancsok a Slide Master nézetben érhetők el.

![The Insert Placeholder command in PowerPoint Slide Master view](slide-master_5.png)

Új helyettesítők hozzáadásához az Aspose.Slidesban dolgozzunk a masterhez tartozó layout diával:

```java
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

Már létező helyettesítő alakzatok formázása is lehetséges egy master dián. Az alábbi példa megtalálja a cím helyettesítőt, és lineáris színátmenetes kitöltést alkalmaz rá:

```java
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
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(255.0f, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Formatted title placeholder inherited by normal slides](slide-master_8.png)

További helyettesítő és szövegformázási lehetőségekért lásd a [Set Prompt Text in Placeholder](/slides/hu/java/manage-placeholder/) és a [Text Formatting](/slides/hu/java/text-formatting/) oldalakat.

## **Slide master háttér módosítása**

A master háttér öröklődik a layoutokra és a diákra, amelyek nem írják felül. Az alábbi példa egyszínű háttérszínt állít be az első master diához:

```java
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

A [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) metódussal másolhatunk egy master diát egy másik bemutatóba. A másolt master ezután használható a célbemutató layoutjai és diái számára.

```java
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

Ha a normál diákot is a saját masterével együtt kell klónozni, lásd a [Clone Slides](/slides/hu/java/clone-slides/) oldalt.

## **Több slide master hozzáadása**

Egy bemutató több master diát is tartalmazhat. Ez akkor hasznos, ha különböző szakaszok különböző arculatot, oldalszerkezetet vagy téma beállításokat igényelnek.

![PowerPoint commands for inserting and managing master slides](slide-master_9.jpg)

Az alábbi példa klónozza az alapértelmezett mastert, más háttérrel látja el a klónt, létrehoz egy layoutot az új master alatt, majd egy új diát ad hozzá, amely ezt a layoutot használja:

```java
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

A master diák összehasonlíthatók a [IBaseSlide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibaseslide/) által örökölt `equals` metódussal. Az összehasonlítás ellenőrzi a struktúrát és a statikus tartalmat, például alakzatokat, szöveget, formázást, animációkat és egyéb dia beállításokat. Nem hasonlítja össze az egyedi azonosítókat, például a dia ID‑ket, vagy a dinamikus helyettesítő értékeket, például az aktuális dátumot.

```java
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

## **Slide Master nézet beállítása alapértelmezett nézetnek**

A [ViewProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/viewproperties/) `setLastView` metódusával szabályozható, hogy a PowerPoint melyik nézetet nyissa meg először. Az alábbi példa a bemutatót Slide Master nézetben nyitja meg:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

További nézetbeállításokért lásd a [Save Presentation](/slides/hu/java/save-presentation/) oldalt.

## **Használaton kívüli master diák eltávolítása**

Előfordulhat, hogy egy bemutató olyan master diákat tartalmaz, amelyeket már egyetlen normál dia sem használ. A használaton kívüli masterek eltávolítása csökkentheti a fájlméretet és egyszerűsítheti a sablon karbantartását.

A `removeUnused` metódussal eltávolíthatók a nem használt masterek a `getMasters()` gyűjteményből:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Alacsony kódszintű megoldásként a [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/hu/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) metódus is használható:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **GYIK**

**Mi a különbség egy slide master és egy layout slide között?**

A slide master közös tervezési beállításokat (témát, hátteret, közös alakzatokat, szövegstílusokat) definiál. Egy layout slide egy master diához tartozik, és egy konkrét helyettesítő elrendezést határoz meg. Egy normál dia egy layout slide‑ot használ, ezért mind a layoutot, mind a mastert örökli.

**Tartalmazhat egy bemutató több slide mastert is?**

Igen. Egy bemutató több slide masterrel is rendelkezhet. Használjunk több mastert, ha a különböző szakaszok különböző vizuális rendszereket vagy arculatot igényelnek.

**Hol kell a helyettesítőket elhelyezni – a master dián vagy a layout dián?**

A legtöbb esetben a helyettesítőket a layout diákra kell tenni. A közös vizuális elemeket és formázást a master dián helyezzük el, a tartalmi helyettesítőket pedig a normál diák által használt layoutokra.

**Törölhetek egy master diát, amelyet még használnak?**

Nem. Egy master dia, amelynek függő diái vannak, nem távolítható el közvetlenül. Előbb mozgassuk át ezeket a diákat egy másik masterhez tartozó layoutba, vagy használjunk olyan takarítási módszert, amely csak a használaton kívüli mastereket távolítja el.