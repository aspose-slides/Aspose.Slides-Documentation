---
title: Rajzolási segédvonalak kezelése prezentációkban Java nyelven
linktitle: Rajzolási segédvonalak
type: docs
weight: 85
url: /hu/java/drawing-guides/
keywords:
- rajzolási segédvonal
- vízszintes segédvonal
- függőleges segédvonal
- igazítási segédvonal
- dia nézet
- minta dia
- elrendezési dia
- jegyzet minta
- szórólap minta
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "vízszintes és függőleges rajzolási segédvonalak hozzáadása, elérése és törlése PowerPoint prezentációkban az Aspose.Slides for Java használatával."
---
## **Áttekintés**

A rajzolási segédvonalak állítható vízszintes és függőleges vonalak, amelyek segítik a felhasználókat a formák következetes igazításában a PowerPoint‑prezentáció szerkesztése közben. Különösen hasznosak, ha egy alkalmazás generál egy prezentációt, amelyet később kézzel finomítanak: az alkalmazás elmentheti ugyanazokat az igazítási segédeszközöket, amelyeket a szerzőknek követniük kell a tartalom hozzáadásakor vagy mozgatásakor.

A rajzolási segédvonalak szerkesztési segédeszközök, nem dia tartalom. Nem jelennek meg diavetítésben vagy renderelt kimenetben. Az Aspose.Slides for Java ezeket a [IDrawingGuidesCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idrawingguidescollection/) interfészen keresztül teszi elérhetővé. Egy segédvonalat a [IDrawingGuide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idrawingguide/) képviseli, amelynek van orientációja, pozíciója és színe.

A pozíciót pontokban mérik a megfelelő dia vagy minta bal felső sarkától. Egy függőleges segédvonal vízszintes koordinátát használ, általában 0 és a dia szélessége között. Egy vízszintes segédvonal függőleges koordinátát használ, általában 0 és a dia magassága között.

## **Vonalak hozzáadása a dia nézethez**

A normál diák szerkesztése közben megjelenő segédvonalak kezeléséhez használja az [ICommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icommonslideviewproperties/#getDrawingGuides--) metódust. Hívja meg a [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idrawingguidescollection/#add-byte-float-) metódust egy [Orientation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/orientation/) értékkel és egy pontban megadott pozícióval.

A következő példa egy függőleges segédvonalat ad hozzá a dia középpontjának jobb oldalához, és egy vízszintes segédvonalat alá:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(Orientation.Vertical, (float) (slideSize.getWidth() / 2 + 12.5));
    guides.add(Orientation.Horizontal, (float) (slideSize.getHeight() / 2 + 12.5));

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Segédvonalak elérése**

Az [IDrawingGuidesCollection.getCount](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idrawingguidescollection/#getCount--) és az [IDrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idrawingguidescollection/#get_Item-int-) metódusok hozzáférést biztosítanak a meglévő segédvonalakhoz. Az [IDrawingGuide.getOrientation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idrawingguide/#getOrientation--) , az [IDrawingGuide.getPosition](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idrawingguide/#getPosition--) és az [IDrawingGuide.getColor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idrawingguide/#getColor--) metódusok értékeket adnak vissza, amelyeket a megfelelő setter metódusokkal is módosíthat.

A következő példa beolvassa a fent létrehozott prezentáció dia‑nézetének segédvonalait:

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

## **Vonalak hozzáadása a minta- és elrendezési diákhoz**

Egy dia minta és minden elrendezési diája saját rajzolási segédvonal‑gyűjteménnyel rendelkezhet. Használja az [IMasterSlide.getDrawingGuides](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imasterslide/#getDrawingGuides--) metódust a minta diához, és az [ILayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilayoutslide/#getDrawingGuides--) metódust az elrendezési diához.

A következő példa egy függőleges segédvonalat ad az első minta diához és egy vízszintes segédvonalat az első elrendezési diához:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    IDrawingGuidesCollection layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(Orientation.Vertical, (float) (slideSize.getWidth() / 2 - 20));
    layoutGuides.add(Orientation.Horizontal, (float) (slideSize.getHeight() / 2 + 20));

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Vonalak hozzáadása a jegyzet- és a szórólap‑mintákhoz**

A jegyzet‑minta és a szórólap‑minta is támogatja a rajzolási segédvonalakat. Használja az [IMasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imasternotesslide/#getDrawingGuides--) és az [IMasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imasterhandoutslide/#getDrawingGuides--) metódusokat a gyűjteményeik eléréséhez. Ha a prezentáció nem tartalmaz egyet sem ezek közül, a [IMasterNotesSlideManager.setDefaultMasterNotesSlide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imasternotesslidemanager/#setDefaultMasterNotesSlide--) vagy a [IMasterHandoutSlideManager.setDefaultMasterHandoutSlide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) létrehozza az alapértelmezett mintát és visszaadja azt.

A következő példa egy vízszintes segédvonalat ad egy jegyzet‑mintához és egy függőleges segédvonalat egy szórólap‑mintához:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D notesSize = presentation.getNotesSize().getSize();
    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(Orientation.Horizontal, (float) (notesSize.getHeight() / 2 + 50));
    handoutMaster.getDrawingGuides().add(Orientation.Vertical, (float) (notesSize.getWidth() / 2 - 50));

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Segédvonalak törlése**

A [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idrawingguidescollection/#clear--) hívásával eltávolíthat minden segédvonalat egy adott gyűjteményből. Egy gyűjtemény törlése nem befolyásolja a másik környezetben tárolt segédvonalakat.

A következő példa törli a dia‑nézet segédvonalait, valamint az összes segédvonalat a dia‑mintákon, az elrendezési diákon, a jegyzet‑mintán és a szórólap‑mintán, anélkül hogy hiányzó mintákat hozna létre:

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

**Megjelennek a rajzolási segédvonalak diavetítésben vagy exportált képeken?**

Nem. A rajzolási segédvonalak szerkesztési igazítási segédeszközök, és nem kerülnek renderelésre a prezentáció tartalmaként.

**Hozzáadható-e egy rajzolási segédvonal közvetlenül egy egyedi normál diára?**

A normál diák szerkesztési segédvonalai a prezentáció dia‑nézet tulajdonságaiban tárolódnak. Külön segédvonal‑gyűjtemények érhetők el a dia‑mintákhoz, az elrendezési diákhoz, a jegyzet‑mintákhoz és a szórólap‑mintákhoz.

**Milyen mértékegységet használnak a segédvonalak pozíciói?**

A pozíciókat pontban adják meg, ahol 72 pont egy hüvelyknek felel meg. A függőleges pozíciókat a bal szélől, a vízszintes pozíciókat a felső szélől mérik.

**A segédvonalak törlése eltávolítja a formákat vagy módosítja a dia tartalmát?**

Nem. Az [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idrawingguidescollection/#clear--) metódus csak a kiválasztott gyűjteményben lévő segédvonalakat távolítja el. A formák és a többi dia tartalom változatlan marad.