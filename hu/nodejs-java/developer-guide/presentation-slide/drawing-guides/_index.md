---
title: Rajzolósegédek kezelése prezentációkban JavaScript nyelven
linktitle: Rajzolósegédek
type: docs
weight: 85
url: /hu/nodejs-java/drawing-guides/
keywords:
- rajzolósegéd
- vízszintes segéd
- függőleges segéd
- igazítási segéd
- dia nézet
- mester dia
- elrendezés dia
- jegyzet mester
- szórólap mester
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Hozzáadhat, elérhet és törölhet vízszintes és függőleges rajzolósegédeket PowerPoint prezentációkban az Aspose.Slides for Node.js via Java segítségével."
---
## **Áttekintés**

A rajzolósegédek állítható vízszintes és függőleges vonalak, amelyek segítik a felhasználókat a formák következetes igazításában a PowerPoint prezentáció szerkesztése közben. Különösen hasznosak, amikor egy alkalmazás generál egy prezentációt, amelyet később manuálisan finomítanak: az alkalmazás elmentheti ugyanazokat az igazítási segédeszközöket, amelyeket a szerzőknek követniük kell a tartalom hozzáadásakor vagy áthelyezésekor.

A rajzolósegédek szerkesztési segédeszközök, nem dia tartalom. Nem jelennek meg diavetítésben vagy renderelt kimenetben. Az Aspose.Slides for Node.js via Java a [DrawingGuidesCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/drawingguidescollection/) osztályon keresztül teszi elérhetővé őket. Egy segédrúgó a [DrawingGuide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/drawingguide/) által van reprezentálva, és rendelkezik orientációval, pozícióval és színnel.

A pozíció pontban van mérve a megfelelő dia vagy mester bal felső sarkától. A függőleges segédrúgó vízszintes koordinátát használ, általában nulla és a dia szélessége között. A vízszintes segédrúgó függőleges koordinátát használ, általában nulla és a dia magassága között.

## **Segédrúgók hozzáadása a dia nézethez**

Használja a [CommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) metódust a normál diák szerkesztése közben megjelenő segédrúgók kezeléséhez. Hívja meg a [DrawingGuidesCollection.add](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/drawingguidescollection/#add) metódust egy [Orientation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/orientation/) értékkel és egy pontban megadott pozícióval.

Az alábbi példa egy függőleges segédrúgót ad a dia középpontjának jobb oldalához, és egy vízszintes segédrúgót alatta:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideSize = presentation.getSlideSize().getSize();
    const guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(slides.Orientation.Vertical, slideSize.getWidth() / 2 + 12.5);
    guides.add(slides.Orientation.Horizontal, slideSize.getHeight() / 2 + 12.5);

    presentation.save("drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Segédrúgók elérése**

A [DrawingGuidesCollection.getCount](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/drawingguidescollection/#getCount) és a [DrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/drawingguidescollection/#get_Item) metódusok hozzáférést biztosítanak a meglévő segédrúgókhoz. A [DrawingGuide.getOrientation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/drawingguide/#getOrientation), a [DrawingGuide.getPosition](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/drawingguide/#getPosition) és a [DrawingGuide.getColor](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/drawingguide/#getColor) metódusok értékeket adnak vissza, amelyeket a megfelelő setter metódusokkal is módosíthat.

Az alábbi példa beolvassa a fent létrehozott prezentáció dia-nézet segédrúgóit:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("drawing-guides.pptx");
try {
    const guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    for (let index = 0; index < guides.getCount(); index++) {
        const guide = guides.get_Item(index);
        console.log("Guide " + index + ": orientation = " + guide.getOrientation() + ", position = " + guide.getPosition() + ", color = " + guide.getColor());
    }
} finally {
    presentation.dispose();
}
```

## **Segédrúgók hozzáadása a mester és elrendezés diákhoz**

A diák mester és minden egyes elrendezés diája saját rajzolósegédekkel rendelkezhet. Használja a [MasterSlide.getDrawingGuides](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masterslide/#getDrawingGuides) metódust a mesterdiához és a [LayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutslide/#getDrawingGuides) metódust az elrendezés diához.

Az alábbi példa egy függőleges segédrúgót ad az első mesterdiához és egy vízszintes segédrúgót az első elrendezés diához:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideSize = presentation.getSlideSize().getSize();
    const masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    const layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(slides.Orientation.Vertical, slideSize.getWidth() / 2 - 20);
    layoutGuides.add(slides.Orientation.Horizontal, slideSize.getHeight() / 2 + 20);

    presentation.save("master-layout-drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Segédrúgók hozzáadása jegyzet- és szórólapmesterekhez**

A jegyzetmesterek és a szórólapmesterek szintén támogatják a rajzolósegédeket. Használja a [MasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masternotesslide/#getDrawingGuides) és a [MasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masterhandoutslide/#getDrawingGuides) metódusokat a gyűjteményeik eléréséhez. Ha egy prezentáció nem tartalmaz ilyen mestert, a `MasterNotesSlideManager.setDefaultMasterNotesSlide` vagy a `MasterHandoutSlideManager.setDefaultMasterHandoutSlide` létrehozza az alapértelmezett mestert és visszaadja azt.

Az alábbi példa egy vízszintes segédrúgót ad egy jegyzetmesterhez és egy függőleges segédrúgót egy szórólapmesterhez:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const notesSize = presentation.getNotesSize().getSize();
    const notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    const handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(slides.Orientation.Horizontal, notesSize.getHeight() / 2 + 50);
    handoutMaster.getDrawingGuides().add(slides.Orientation.Vertical, notesSize.getWidth() / 2 - 50);

    presentation.save("notes-handout-drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Rajzolósegédek törlése**

Hívja meg a [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/drawingguidescollection/#clear) metódust, hogy eltávolítsa az összes segédrúgót egy adott gyűjteményből. Egy gyűjtemény törlése nem érinti a másik környezetben tárolt segédrúgókat.

Az alábbi példa törli a dia-nézet segédrúgókat és az összes segédrúgót a dia mesterekről, az elrendezés diákról, a jegyzetmesterről és a szórólapmesterről anélkül, hogy hiányzó mestereket hozna létre:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation-with-guides.pptx");
try {
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear();

    for (let index = 0; index < presentation.getMasters().size(); index++) {
        presentation.getMasters().get_Item(index).getDrawingGuides().clear();
    }

    for (let index = 0; index < presentation.getLayoutSlides().size(); index++) {
        presentation.getLayoutSlides().get_Item(index).getDrawingGuides().clear();
    }

    const notesMaster = presentation.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster !== null) {
        notesMaster.getDrawingGuides().clear();
    }

    const handoutMaster = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();
    if (handoutMaster !== null) {
        handoutMaster.getDrawingGuides().clear();
    }

    presentation.save("presentation-without-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **GYIK**

**Megjelennek a rajzolósegédek a diavetítésben vagy az exportált képeken?**

Nem. A rajzolósegédek szerkesztési igazítási segédeszközök, és nem jelennek meg a prezentáció tartalmaként.

**Lehet közvetlenül egy egyedi normál diára rajzolósegédet hozzáadni?**

A normál diák szerkesztési segédrúgói a prezentáció dia-nézet tulajdonságaiban vannak tárolva. Különálló segédrúgó-gyűjtemények állnak rendelkezésre a dia mesterekhez, az elrendezés diákhoz, a jegyzetmesterekhez és a szórólapmesterekhez.

**Milyen mértékegységet használnak a segédrúgó pozíciókhoz?**

A pozíciók pontban vannak megadva, ahol 72 pont egy hüvelyknek felel meg. A függőleges pozíciók a bal szegélytől, a vízszintes pozíciók a felső szegélytől mérnek.

**A rajzolósegédek törlése eltávolítja a formákat vagy megváltoztatja a dia tartalmát?**

Nem. A [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/drawingguidescollection/#clear) metódus csak a kiválasztott gyűjteményben lévő segédrúgókat távolítja el. A formák és egyéb dia tartalom változatlan marad.