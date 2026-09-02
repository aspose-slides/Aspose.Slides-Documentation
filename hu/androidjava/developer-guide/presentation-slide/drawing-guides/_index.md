---
title: Rajzoló segédvonalak kezelése prezentációkban Androidon
linktitle: Rajzoló segédvonalak
type: docs
weight: 85
url: /hu/androidjava/drawing-guides/
keywords:
- rajzoló segédvonal
- vízszintes segédvonal
- függőleges segédvonal
- igazítási segédvonal
- dia nézet
- mester dia
- elrendezés dia
- jegyzet mester
- anyag mester
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Hozzáadja, eléri és törli a vízszintes és függőleges rajzoló segédvonalakat PowerPoint prezentációkban az Aspose.Slides for Android via Java használatával."
---
## **Áttekintés**

A rajzoló segédvonalak állítható vízszintes és függőleges vonalak, amelyek segítik a felhasználókat a formák következetes igazításában a PowerPoint prezentáció szerkesztése közben. Különösen hasznosak, ha egy alkalmazás generál egy prezentációt, amelyet később kézzel finomítanak: az alkalmazás elmentheti ugyanazokat az igazítási segédeszközöket, amelyeket a szerzőknek követniük kell a tartalom hozzáadása vagy mozgatása során.

A rajzoló segédvonalak szerkesztési segédeszközök, nem a diáktartalom részei. Nem jelennek meg diavetítésben vagy a leképzett kimenetben. Az Aspose.Slides for Android via Java ezeket a [IDrawingGuidesCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idrawingguidescollection/) interfészen keresztül teszi elérhetővé. Egy segédvonalat a [IDrawingGuide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idrawingguide/) képviseli, és rendelkezik tájolással, pozícióval és színnel.

A pozíció a pontokban van megadva a megfelelő dia vagy mester bal felső sarkától. Egy függőleges segédvonal vízszintes koordinátát használ, általában 0 és a dia szélessége között. Egy vízszintes segédvonal függőleges koordinátát használ, általában 0 és a dia magassága között.

## **Segédvonalak hozzáadása a dia nézethez**

Használja a [ICommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icommonslideviewproperties/#getDrawingGuides--) metódust a normál diák szerkesztése közben megjelenő segédvonalak kezeléséhez. Hívja a [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idrawingguidescollection/#add-byte-float-) metódust egy [Orientation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/orientation/) értékkel és egy pontokban megadott pozícióval.

Az alábbi példa egy függőleges segédvonalat ad a dia középpontja jobb oldalához, és egy vízszintes segédvonalat alá:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(Orientation.Vertical, slideSize.getWidth() / 2 + 12.5f);
    guides.add(Orientation.Horizontal, slideSize.getHeight() / 2 + 12.5f);

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **A rajzoló segédvonalak elérése**

A [IDrawingGuidesCollection.getCount](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idrawingguidescollection/#getCount--) és a [IDrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idrawingguidescollection/#get_Item-int-) metódusok hozzáférést biztosítanak a meglévő segédvonalakhoz. A [IDrawingGuide.getOrientation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idrawingguide/#getOrientation--), a [IDrawingGuide.getPosition](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idrawingguide/#getPosition--) és a [IDrawingGuide.getColor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idrawingguide/#getColor--) metódusok értékeket adnak vissza, amelyeket a megfelelő beállító metódusokkal is módosíthat.

Az alábbi példa beolvassa a fenti prezentációban létrehozott dia-nézet segédvonalakat:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("drawing-guides.pptx");
try {
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    for (int index = 0; index < guides.getCount(); index++) {
        IDrawingGuide guide = guides.get_Item(index);
        System.out.println("Guide " + index + ": orientation = " + guide.getOrientation() + ", position = " + guide.getPosition() + ", color = " + guide.getColor());
    }
} finally {
    presentation.dispose();
}
```

## **Segédvonalak hozzáadása a mester és elrendezés diákhoz**

Egy dia mester és az egyes elrendezés diái saját rajzoló segédvonal-gyűjteménnyel rendelkezhetnek. Használja a [IMasterSlide.getDrawingGuides](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imasterslide/#getDrawingGuides--) metódust egy mester dián és a [ILayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilayoutslide/#getDrawingGuides--) metódust egy elrendezés dián.

Az alábbi példa egy függőleges segédvonalat ad az első mester diához és egy vízszintes segédvonalat az első elrendezés diához:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    IDrawingGuidesCollection layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(Orientation.Vertical, slideSize.getWidth() / 2 - 20);
    layoutGuides.add(Orientation.Horizontal, slideSize.getHeight() / 2 + 20);

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Segédvonalak hozzáadása a jegyzet- és anyagmesterekhez**

A jegyzet mesterek és az anyagmesterek is támogatják a rajzoló segédvonalakat. Használja a [IMasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imasternotesslide/#getDrawingGuides--) és a [IMasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imasterhandoutslide/#getDrawingGuides--) metódusokat a gyűjtemények eléréséhez. Ha a prezentáció nem tartalmaz ilyen mestert, a [IMasterNotesSlideManager.setDefaultMasterNotesSlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imasternotesslidemanager/#setDefaultMasterNotesSlide--) vagy a [IMasterHandoutSlideManager.setDefaultMasterHandoutSlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) létrehozza az alapértelmezett mestert és visszaadja azt.

Az alábbi példa egy vízszintes segédvonalat ad egy jegyzet mesterhez és egy függőleges segédvonalat egy anyag mesterhez:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF notesSize = presentation.getNotesSize().getSize();
    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(Orientation.Horizontal, notesSize.getHeight() / 2 + 50);
    handoutMaster.getDrawingGuides().add(Orientation.Vertical, notesSize.getWidth() / 2 - 50);

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Rajzoló segédvonalak törlése**

Hívja a [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idrawingguidescollection/#clear--) metódust, hogy eltávolítsa az összes segédvonalat egy adott gyűjteményből. Egy gyűjtemény törlése nem befolyásolja a másik területen tárolt segédvonalakat.

Az alábbi példa törli a dia-nézet segédvonalakat valamint az összes segédvonalat a dia mestereken, az elrendezés diákon, a jegyzet mesteren és az anyag mesteren, anélkül hogy hiányzó mestereket hozna létre:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation-with-guides.pptx");
try {
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear();

    for (IMasterSlide masterSlide : presentation.getMasters()) {
        masterSlide.getDrawingGuides().clear();
    }

    for (ILayoutSlide layoutSlide : presentation.getLayoutSlides()) {
        layoutSlide.getDrawingGuides().clear();
    }

    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        notesMaster.getDrawingGuides().clear();
    }

    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();
    if (handoutMaster != null) {
        handoutMaster.getDrawingGuides().clear();
    }

    presentation.save("presentation-without-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **GYIK**

**Megjelennek a rajzoló segédvonalak diavetítésben vagy exportált képeken?**

Nem. A rajzoló segédvonalak szerkesztési igazítási segédeszközök, és nem jelennek meg a prezentáció tartalmaként.

**Hozzáadható a rajzoló segédvonal közvetlenül egy egyedi normál diához?**

A normál diák szerkesztési segédvonalai a prezentáció dia-nézet tulajdonságaiban vannak tárolva. Külön segédvonal-gyűjtemények érhetők el a dia mesterek, elrendezés diák, jegyzet mesterek és anyag mesterek számára.

**Milyen mértékegységeket használnak a segédvonalak pozícióihoz?**

A pozíciók pontokban vannak megadva, ahol 72 pont egy hüvelyknek felel meg. A függőleges pozíciók a bal szélől, a vízszintes pozíciók a felső szélől vannak mérve.

**A rajzoló segédvonalak törlése eltávolítja a alakzatokat vagy megváltoztatja a dia tartalmát?**

Nem. A [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idrawingguidescollection/#clear--) metódus csak a kiválasztott gyűjteményben lévő segédvonalakat távolítja el. Az alakzatok és a többi dia tartalom változatlan marad.