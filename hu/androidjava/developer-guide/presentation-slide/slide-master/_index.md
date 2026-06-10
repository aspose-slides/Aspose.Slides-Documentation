---
title: Dia masterek kezelése Androidon
linktitle: Dia master
type: docs
weight: 70
url: /hu/androidjava/slide-master/
keywords:
- dia master
- master dia
- PPT master dia
- több master dia
- master diák összehasonlítása
- háttér
- helyőrző
- master dia klónozása
- master dia másolása
- master dia megkettőzése
- használaton kívüli master dia
- PowerPoint
- OpenDocument
- bemutató
- Android
- Java
- Aspose.Slides
description: "Dia masterek kezelése az Aspose.Slides for Android via Java-ban: master diák elérése, szerkesztése, klónozása, összehasonlítása és eltávolítása PowerPoint és OpenDocument bemutatókban."
---
## **Áttekintés**

A **slide master** közös tervezési beállításokat határoz meg egy diacsoport számára. Tartalmazhat általános alakzatokat, logókat, háttérképeket, szövegstílusokat, téma beállításokat és lábléc beállításokat. PowerPointban a slide master szerkesztése a szokásos módja annak, hogy a bemutató egységes legyen anélkül, hogy minden dián megismételnénk ugyanazt a formázást.

Aspose.Slides for Android via Java támogatja ugyanazt a modellt. Egy bemutató tartalmazhat egy vagy több master slide-ot, és minden master slide több layout slide-ot is tartalmazhat. A normál diák általában nem hivatkoznak közvetlenül egy master slide-ra. Ehelyett egy normál dia egy layout slide-ot használ, és ez a layout slide egy master slide-hoz tartozik.

A hierarchia:

1. **Slide master** – meghatározza a közös tervezést és a témát.
1. **Layout slide** – meghatároz egy konkrét elrendezést a helyőrzőkkel és az elrendezési szintű formázással.
1. **Normal slide** – tartalmazza a tényleges bemutató tartalmat és egy layout slide-ot használ.

![A master slide-ok, layout slide-ok és normál slide-ok hierarchiája](slide-master_2.jpg)

Az Aspose.Slides-ben egy slide master-t az [IMasterSlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imasterslide/) interfész képviseli. A bemutató összes master slide-ja elérhető a [Presentation.getMasters](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#getMasters--) gyűjteményen keresztül, amely megvalósítja a [IMasterSlideCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imasterslidecollection/) interfészt. A teljes Android via Java API-hoz lásd a [com.aspose.slides API referenciát](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/).

{{% alert color="info" title="Öröklődés" %}}
Amikor ugyanaz a tulajdonság több szinten is definiálva van, a specifikusabb szint nyer. Például, ha egy master slide és egy layout slide is meghatároz egy háttérszínt, akkor az az elrendezésen alapuló diák az elrendezés háttérét használják. További információért a layout slide-okról lásd a [Slide Layoutok alkalmazása vagy módosítása](/slides/hu/androidjava/slide-layout/).
{{% /alert %}}

## **Slide master-ek elérése**

PowerPointban a Slide Master nézetet a **View** > **Slide Master** menüből nyithatod meg.

![A Slide Master parancs a PowerPoint Nézet fülön](slide-master_3.jpg)

Az Aspose.Slides-ben a `getMasters()` gyűjteményt kell használni a master slide-ok eléréséhez:

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

Elérheted egy normál dia által használt master slide-ot a saját layout-ján keresztül is:

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

## **Mit tartalmaz egy Slide Master**

A master slide egy diához hasonló objektum. Implementálja az [IBaseSlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibaseslide/) interfészt, így sok olyan dia tulajdonságot tesz elérhetővé, amelyet a normál és layout diák is használnak.

Közös használatú master slide tagok közé tartozik:

| Tag | Leírás |
| --- | --- |
| `getBackground()` | Beállítja a master szintű dia háttérét. |
| `getShapes()` | Tárolja a master-re helyezett alakzatokat, például logókat, képkockákat és megosztott szöveget. |
| `getLayoutSlides()` | Tárolja a master-hez tartozó layout slide-okat. |
| `getThemeManager()` | Hozzáférést biztosít a master téma API-khoz. |
| `getHeaderFooterManager()` | Kezeli a fejléceket, lábléceket, dátumokat és dia számokat a master és annak gyermek elrendezései számára. |
| `getDependingSlides()` | Visszaadja azokat a normál diákat, amelyek a master-re támaszkodnak a layout-jaikon keresztül. |

## **Kép hozzáadása egy Slide Master-hez**

Amikor egy képet adsz hozzá egy master slide-hoz, az megjelenik azokon a diákon, amelyek az adott master layout-jait használják. Ez hasznos logók, vízjelek, díszítő szalagok és más ismétlődő vizuális elemek esetén.

A következő példa egy logót ad hozzá az első master slide-hoz:

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

További információért a képkockákról lásd a [Képkocka](/slides/hu/androidjava/picture-frame/).

## **Helyőrzőkkel való munka**

A helyőrzőket általában a layout slide-okon definiálják. A master slide biztosítja a közös stílust és témát, amelyet ezek az elrendezések örökölnek, míg minden egyes layout meghatározza, hogy mely helyőrzők állnak rendelkezésre és hol helyezkednek el.

PowerPointban a helyőrző parancsok a Slide Master nézetben érhetők el.

![A Helyőrző beszúrása parancs a PowerPoint Slide Master nézetben](slide-master_5.png)

Új helyőrzők hozzáadásához az Aspose.Slides-ben, dolgozz a master-hez tartozó layout slide-dal:

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

Formázhatod a már meglévő helyőrző alakzatokat a master slide-on is. A következő példa megkeresi a címsor helyőrzőt és lineáris gradient kitöltést alkalmaz rá:

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
        int redGradientColor = Color.valueOf(255, 0, 0).toArgb();
        int purpleGradientColor = Color.valueOf(128, 0, 128).toArgb();

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

További helyőrző és szövegformázási lehetőségekért lásd a [Helyőrzőben szöveg beállítása](/slides/hu/androidjava/manage-placeholder/) és a [Szövegformázás](/slides/hu/androidjava/text-formatting/) oldalakat.

## **Slide Master háttér módosítása**

A master háttér öröklődik az elrendezések és a diák számára, amelyek nem felülírják azt. A következő példa egy homogén háttérszínt állít be az első master slide-hoz:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    int masterBackgroundColor = Color.GREEN;

    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kapcsolódó témákért lásd a [Bemutató háttér](/slides/hu/androidjava/presentation-background/) és a [Bemutató téma](/slides/hu/androidjava/presentation-theme/) oldalakat.

## **Slide Master klónozása egy másik bemutatóba**

Használd az [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) metódust egy master slide másolásához egy másik bemutatóba. A másolt master ezután a célbemutató layoutjain és diáin is felhasználható.

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

Ha a normál diákot a masterrel együtt kell klónozni, lásd a [Diák klónozása](/slides/hu/androidjava/clone-slides/) oldalt.

## **Több Slide Master hozzáadása**

Egy bemutató több master slide-ot is tartalmazhat. Ez akkor hasznos, amikor a különböző szakaszok különböző márkaidentitást, oldalstruktúrát vagy téma beállításokat igényelnek.

![PowerPoint parancsok master slide-ok beszúrásához és kezeléséhez](slide-master_9.jpg)

A következő példa klónozza az alapértelmezett master slide-ot, különböző háttérrel látja el a klónt, létrehoz egy layoutot a klónozott master alatt, és hozzáad egy új diát, amely ezt a layoutot használja:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    int sectionMasterBackgroundColor = Color.GRAY;

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

## **Slide Master-ek összehasonlítása**

A master slide-okat összehasonlíthatod az [IBaseSlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibaseslide/) által örökölt `equals` metódussal. Az összehasonlítás a struktúrát és a statikus tartalmat ellenőrzi, például alakzatok, szöveg, formázás, animációk és egyéb dia beállítások. Nem hasonlítja össze az egyedi azonosítókat, mint a dia ID-k, vagy a dinamikus helyőrző értékeket, például a aktuális dátumot.

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

További információért lásd a [Bemutató diák összehasonlítása](/slides/hu/androidjava/compare-slides/) oldalt.

## **Slide Master nézet beállítása alapértelmezett nézetnek**

Használd a `setLastView` metódust a [ViewProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/viewproperties/) osztályon, hogy szabályozd, melyik nézetet nyissa meg a PowerPoint elsőként. A következő példa a bemutatót a Slide Master nézetben nyitja meg:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

További nézetbeállításokért lásd a [Bemutató mentése](/slides/hu/androidjava/save-presentation/) oldalt.

## **Használaton kívüli Master Slide-ok eltávolítása**

A bemutatók néha olyan master slide-okat tartalmaznak, amelyeket már egyetlen normál dia sem használ. A használaton kívüli master-ek eltávolítása csökkentheti a fájlméretet és egyszerűsítheti a sablonkarbantartást.

Használd a `removeUnused` metódust a `getMasters()` gyűjteményből a használaton kívüli master-ek eltávolításához:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Használhatod a low-code [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) metódust is:

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

**Mi a különbség a slide master és a layout slide között?**

A slide master közös tervezési beállításokat határoz meg, mint például téma, háttér, általános alakzatok és szövegstílusok. A layout slide egy master slide-hoz tartozik, és egy konkrét helyőrző elrendezést definiál. Egy normál dia egy layout slide-ot használ, így mind a layout, mind a master tulajdonságait örökli.

**Tartalmazhat egy bemutató több slide master-t?**

Igen. Egy bemutató több slide master-t is tartalmazhat. Használj több master-t, amikor a különböző szakaszok különböző vizuális rendszereket vagy márkát igényelnek.

**Helyőrzőket a master slide-hoz vagy a layout slide-hoz kellene hozzáadni?**

A legtöbb esetben a helyőrzőket a layout slide-okra kell hozzáadni. A közös vizuális elemeket és a közös formázást a master slide-on helyezd el, majd a tartalomhelyőrzőket a normál diák által használt layout-okra.

**Törölhetek egy még használt master slide-ot?**

Nem. Egy olyan master slide, amelynek vannak függő diái, nem távolítható el biztonságosan közvetlenül. Először helyezd át ezeket a diát egy másik master alá tartozó layout-okba, vagy használd a használaton kívüli master-ek tisztítására szolgáló módszert, amely csak a nem használt master-eket távolítja el.