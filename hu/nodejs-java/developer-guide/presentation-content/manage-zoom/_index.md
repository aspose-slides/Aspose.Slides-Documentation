---
title: "Prezentáció Zoom kezelése JavaScriptben"
linktitle: "Zoom kezelése"
type: docs
weight: 60
url: /hu/nodejs-java/manage-zoom/
keywords:
- zoom
- zoom keret
- dia zoom
- szakasz zoom
- összefoglaló zoom
- zoom hozzáadása
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Hozzon létre és testreszabjon Zoom-ot az Aspose.Slides for Node.js segítségével – ugorjon szakaszok között, adjon hozzá bélyegképeket és átmeneteket PPT, PPTX és ODP prezentációkban."
---
## **Bevezetés**

A PowerPoint zoomok lehetővé teszik, hogy egy adott diára, szakaszra vagy a bemutató egy részére ugorjon, és visszatérjen onnan. Előadás közben ez a gyors navigálási képesség nagyon hasznos lehet. 

![overview_image](overview.png)

* Egy teljes bemutató összefoglalásához egyetlen dián, használja az [Összefoglaló Zoom](#Summary-Zoom) lehetőséget.
* Csak kiválasztott diák megjelenítéséhez használja a [Dia Zoom](#Slide-Zoom) lehetőséget.
* Egyetlen szakasz megjelenítéséhez használja a [Szakasz Zoom](#Section-Zoom) lehetőséget.

## **Dia Zoom**

A dia zoom dinamikusabbá teheti a bemutatót, mivel lehetővé teszi, hogy szabadon navigáljon a diák között tetszőleges sorrendben, a bemutató folyamatát megzavarva. A dia zoomok ideálisak rövid, kevés szakaszos bemutatókhoz, de más bemutatási szituációkban is használhatók.

A dia zoomok segítenek több információs darabot mélyebben megvizsgálni, mintha egyetlen vásznon dolgozna. 

![overview_image](slidezoomsel.png)

A dia zoom objektumokhoz az Aspose.Slides a [ZoomImageType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ZoomImageType) felsorolást, a [ZoomFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ZoomFrame) osztályt, valamint néhány metódust a [ShapeCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ShapeCollection) osztályban biztosítja.

### **Zoomkeretek létrehozása**

Zoomkeretet az alábbi módon adhat hozzá egy diához:

1.	Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.
2.	Hozzon új diákat, amelyekhez a zoomkereteket kapcsolja. 
3.	Adjon az új diákhoz azonosító szöveget és hátteret.
4.	Adjon hozzá zoomkereteket (amelyek a létrehozott diákra mutató hivatkozásokat tartalmazzák) az első diához.
5.	Irja a módosított bemutatót PPTX fájlként.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Új diák hozzáadása a prezentációhoz
    var slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    var slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // Háttér létrehozása a második dia számára
    slide2.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // Szövegdoboz létrehozása a második dia számára
    var autoshape = slide2.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // Háttér létrehozása a harmadik dia számára
    slide3.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "darkGray"));
    // Szövegdoboz létrehozása a harmadik dia számára
    autoshape = slide3.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");
    // ZoomFrame objektumok hozzáadása
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);
    // Prezentáció mentése
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Egyéni képekkel rendelkező zoomkeretek létrehozása**

Az Aspose.Slides for Node.js via Java segítségével egy eltérő diakép előnézettel rendelkező zoomkeretet az alábbi módon hozhat létre:
1.	Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.
2.	Hozzon egy új diát, amelyhez a zoomkeretet kapcsolni kívánja. 
3.	Adjon azonosító szöveget és hátteret a diának.
4.	Hozzon létre egy [PPImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/PPImage) objektumot úgy, hogy képet ad a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) objektumhoz tartozó Images gyűjteményhez, amely a keret kitöltésére szolgál.
5.	Adjon hozzá zoomkereteket (amelyek a létrehozott diára mutató hivatkozást tartalmaznak) az első diához.
6.	Irja a módosított bemutatót PPTX fájlként.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Új dia hozzáadása a prezentációhoz
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // Háttér létrehozása a második dia számára
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // Szövegdoboz létrehozása a harmadik dia számára
    var autoshape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // Új kép létrehozása a zoom objektumhoz
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // ZoomFrame objektum hozzáadása
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);
    // Prezentáció mentése
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Zoomkeretek formázása**

Az előző szakaszokban megmutattuk, hogyan kell egyszerű zoomkereteket létrehozni. Bonyolultabb zoomkeretek létrehozásához módosítani kell egy egyszerű keret formázását. Számos formázási lehetőség áll rendelkezésre egy zoomkerethez. 

A zoomkeret formázását a dián az alábbi módon szabályozhatja:

1.	Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.
2.	Hozzon új diákat, amelyekhez a zoomkeretet kapcsolni kívánja. 
3.	Adjon némi azonosító szöveget és hátteret a létrehozott diákhoz.
4.	Adjon hozzá zoomkereteket (amelyek a létrehozott diákra mutató hivatkozásokat tartalmaznak) az első diához.
5.	Hozzon létre egy [PPImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/PPImage) objektumot úgy, hogy képet ad a Images gyűjteményhez, amely a keret kitöltésére szolgál.
6.	Állítson be egy egyéni képet az első zoomkeret objektumhoz.
7.	Módosítsa a vonalformátumot a második zoomkeret objektumnál.
8.	Távolítsa el a hátteret a második zoomkeret objektum képéről.
9.	Irja a módosított bemutatót PPTX fájlként.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Új diák hozzáadása a prezentációhoz
    var slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    var slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // Háttér létrehozása a második dia számára
    slide2.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // Szövegdoboz létrehozása a második dia számára
    var autoshape = slide2.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // Háttér létrehozása a harmadik dia számára
    slide3.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "darkGray"));
    // Szövegdoboz létrehozása a harmadik dia számára
    autoshape = slide3.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");
    // ZoomFrame objektumok hozzáadása
    var zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    var zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);
    // Új kép létrehozása a zoom objektumhoz
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Egyéni kép beállítása a zoomFrame1 objektumhoz
    zoomFrame1.setImage(picture);
    // Zoom keret formátumának beállítása a zoomFrame2 objektumnál
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "pink"));
    zoomFrame2.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    // Beállítás: háttér ne jelenjen meg a zoomFrame2 objektumnál
    zoomFrame2.setShowBackground(false);
    // Prezentáció mentése
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Szakasz Zoom**

A szakasz zoom egy hivatkozás a bemutató egy szakaszára. Szakasz zoomokkal visszaléphet azokba a szakaszokba, amelyeket különösen hangsúlyozni szeretne. Vagy használhatja őket annak kiemelésére, hogy a bemutató egyes részei hogyan kapcsolódnak egymáshoz. 

![overview_image](seczoomsel.png)

A szakasz zoom objektumokhoz az Aspose.Slides biztosítja a [SectionZoomFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SectionZoomFrame) osztályt, valamint néhány metódust a [ShapeCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ShapeCollection) osztályban.

### **Szakasz Zoomkeretek létrehozása**

Szakasz zoomkeretet az alábbi módon adhat hozzá egy diához:

1.	Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.
2.	Hozzon egy új diát. 
3.	Adjon azonosító hátteret a létrehozott diának.
4.	Hozzon egy új szakaszt, amelyhez a zoomkeretet kapcsolni kívánja. 
5.	Adjon hozzá egy szakasz zoomkeretet (amely a létrehozott szakaszra mutató hivatkozásokat tartalmaz) az első diához.
6.	Irja a módosított bemutatót PPTX fájlként.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Új dia hozzáadása a prezentációhoz
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Új szakasz hozzáadása a prezentációhoz
    pres.getSections().addSection("Section 1", slide);
    // SectionZoomFrame objektum hozzáadása
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));
    // Prezentáció mentése
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Egyéni képekkel rendelkező szakasz zoomkeretek létrehozása**

Az Aspose.Slides for Node.js via Java segítségével egy eltérő diakép előnézettel rendelkező szakasz zoomkeretet az alábbi módon hozhat létre:

1.	Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.
2.	Hozzon egy új diát.
3.	Adjon azonosító hátteret a létrehozott diának.
4.	Hozzon egy új szakaszt, amelyhez a zoomkeretet kapcsolni kívánja. 
5.	Hozzon létre egy [PPImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/PPImage) objektumot úgy, hogy képet ad a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) objektumhoz tartozó Images gyűjteményhez, amely a keret kitöltésére szolgál.
6.	Adjon hozzá egy szakasz zoomkeretet (amely a létrehozott szakaszra mutató hivatkozást tartalmaz) az első diához.
7.	Irja a módosított bemutatót PPTX fájlként.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Új dia hozzáadása a prezentációhoz
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Új szakasz hozzáadása a prezentációhoz
    pres.getSections().addSection("Section 1", slide);
    // Új kép létrehozása a zoom objektumhoz
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // SectionZoomFrame objektum hozzáadása
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1), picture);
    // Prezentáció mentése
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Szakasz Zoomkeretek formázása**

Bonyolultabb szakasz zoomkeretek létrehozásához módosítani kell egy egyszerű keret formázását. Számos formázási lehetőség áll rendelkezésre egy szakasz zoomkerethez. 

A szakasz zoomkeret formázását a dián az alábbi módon szabályozhatja:

1.	Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.
2.	Hozzon egy új diát.
3.	Adjon azonosító hátteret a létrehozott diának.
4.	Hozzon egy új szakaszt, amelyhez a zoomkeretet kapcsolni kívánja. 
5.	Adjon hozzá egy szakasz zoomkeretet (amely a létrehozott szakaszra mutató hivatkozásokat tartalmaz) az első diához.
6.	Módosítsa a létrehozott szakasz zoom objektum méretét és pozícióját.
7.	Hozzon létre egy [PPImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/PPImage) objektumot úgy, hogy képet ad a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) objektumhoz tartozó Images gyűjteményhez, amely a keret kitöltésére szolgál.
8.	Állítson be egy egyéni képet a létrehozott szakasz zoomkeret objektumhoz.
9.	Állítsa be a *visszatérés a kapcsolt szakaszból az eredeti diára* lehetőséget. 
10.	Távolítsa el a háttérképet a szakasz zoomkeret objektum képéről.
11.	Módosítsa a vonalformátumot a második zoomkeret objektumnál.
12.	Módosítsa a transzíciós időtartamot.
13.	Irja a módosított bemutatót PPTX fájlként.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Új dia hozzáadása a prezentációhoz
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Új szakasz hozzáadása a prezentációhoz
    pres.getSections().addSection("Section 1", slide);
    // SectionZoomFrame objektum hozzáadása
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));
    // Formázás a SectionZoomFrame számára
    sectionZoomFrame.setX(100);
    sectionZoomFrame.setY(300);
    sectionZoomFrame.setWidth(100);
    sectionZoomFrame.setHeight(75);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    sectionZoomFrame.setImage(picture);
    sectionZoomFrame.setReturnToParent(true);
    sectionZoomFrame.setShowBackground(false);
    sectionZoomFrame.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    sectionZoomFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    sectionZoomFrame.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    sectionZoomFrame.getLineFormat().setWidth(2.5);
    sectionZoomFrame.setTransitionDuration(1.5);
    // Prezentáció mentése
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Összefoglaló Zoom**

Az összefoglaló zoom olyan, mint egy kezdőlap, ahol a bemutató összes része egyszerre jelenik meg. Előadás közben a zoom segítségével bármilyen sorrendben ugorhat egyik részről a másikra. Kreatív lehet, előre ugorhat, vagy visszatérhet a diavetítés egyes részeihez anélkül, hogy megszakítaná a bemutató folyamatát.

![overview_image](sumzoomsel.png)

Az összefoglaló zoom objektumokhoz az Aspose.Slides biztosítja a [SummaryZoomFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SummaryZoomFrame), a [SummaryZoomSection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SummaryZoomSection) és a [SummaryZoomSectionCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SummaryZoomSectionCollection) osztályokat, valamint néhány metódust a [ShapeCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ShapeCollection) osztályban.

### **Összefoglaló Zoom létrehozása**

Összefoglaló zoomkeretet az alábbi módon adhat hozzá egy diához:

1.	Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.
2.	Hozzon új diákat azonosító háttérrel és új szakaszokkal a létrehozott diákhoz.
3.	Adja hozzá az összefoglaló zoomkeretet az első diához.
4.	Irja a módosított bemutatót PPTX fájlként.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Új dia hozzáadása a prezentációhoz
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Új szakasz hozzáadása a prezentációhoz
    pres.getSections().addSection("Section 1", slide);
    // Új dia hozzáadása a prezentációhoz
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Új szakasz hozzáadása a prezentációhoz
    pres.getSections().addSection("Section 2", slide);
    // Új dia hozzáadása a prezentációhoz
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "magenta"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Új szakasz hozzáadása a prezentációhoz
    pres.getSections().addSection("Section 3", slide);
    // Új dia hozzáadása a prezentációhoz
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "green"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Új szakasz hozzáadása a prezentációhoz
    pres.getSections().addSection("Section 4", slide);
    // SummaryZoomFrame objektum hozzáadása
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // Prezentáció mentése
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Összefoglaló Zoom Szakaszok hozzáadása és eltávolítása**

Az összefoglaló zoomkeret összes szakaszát a [SummaryZoomSection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SummaryZoomSection) objektumok képviselik, amelyeket a [SummaryZoomSectionCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SummaryZoomSectionCollection) tárol. Egy összefoglaló zoom szakasz objektumot a [SummaryZoomSectionCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SummaryZoomSectionCollection) osztályon keresztül az alábbi módon adhat hozzá vagy távolíthat el:

1.	Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.
2.	Hozzon új diákat azonosító háttérrel és új szakaszokkal a létrehozott diákhoz.
3.	Adjon egy összefoglaló zoomkeretet az első diához.
4.	Adjon egy új diát és szakaszt a bemutatóhoz.
5.	Adja hozzá a létrehozott szakaszt az összefoglaló zoomkerethez.
6.	Távolítsa el az első szakaszt az összefoglaló zoomkeretből.
7.	Irja a módosított bemutatót PPTX fájlként.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Új dia hozzáadása a prezentációhoz
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Új szakasz hozzáadása a prezentációhoz
    pres.getSections().addSection("Section 1", slide);
    // Új dia hozzáadása a prezentációhoz
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Új szakasz hozzáadása a prezentációhoz
    pres.getSections().addSection("Section 2", slide);
    // SummaryZoomFrame objektum hozzáadása
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // Új dia hozzáadása a prezentációhoz
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "magenta"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Új szakasz hozzáadása a prezentációhoz
    var section3 = pres.getSections().addSection("Section 3", slide);
    // Szakasz hozzáadása a Summary Zoom-hoz
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);
    // Szakasz eltávolítása a Summary Zoom-ból
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));
    // Prezentáció mentése
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Összefoglaló Zoom Szakaszok formázása**

Bonyolultabb összefoglaló zoom szakasz objektumok létrehozásához módosítani kell egy egyszerű keret formázását. Számos formázási lehetőség áll rendelkezésre egy összefoglaló zoom szakasz objektumhoz. 

Az összefoglaló zoomszakasz objektum formázását egy összefoglaló zoomkereten az alábbi módon szabályozhatja:

1.	Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.
2.	Hozzon új diákat azonosító háttérrel és új szakaszokkal a létrehozott diákhoz.
3.	Adjon egy összefoglaló zoomkeretet az első diához.
4.	Gyűjtse be az első objektumot a `ISummaryZoomSectionCollection`‑ból egy összefoglaló zoomszakasz objektumként.
5.	Hozzon létre egy [PPImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/PPImage) objektumot úgy, hogy képet ad a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) objektumhoz tartozó images gyűjteményhez, amely a keret kitöltésére szolgál.
6.	Állítson be egy egyéni képet a létrehozott szakasz zoomkeret objektumhoz.
7.	Állítsa be a *visszatérés a kapcsolt szakaszból az eredeti diára* lehetőséget. 
8.	Módosítsa a vonalformátumot a második zoomkeret objektumnál.
9.	Módosítsa a transzíciós időtartamot.
10.	Irja a módosított bemutatót PPTX fájlként.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Új dia hozzáadása a prezentációhoz
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Új szakasz hozzáadása a prezentációhoz
    pres.getSections().addSection("Section 1", slide);
    // Új dia hozzáadása a prezentációhoz
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Új szakasz hozzáadása a prezentációhoz
    pres.getSections().addSection("Section 2", slide);
    // SummaryZoomFrame objektum hozzáadása
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // Az első SummaryZoomSection objektum lekérése
    var summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);
    // Formázás a SummaryZoomSection objektumhoz
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(picture);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    summarySection.setImage(picture);
    summarySection.setReturnToParent(false);
    summarySection.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    summarySection.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "black"));
    summarySection.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    summarySection.getLineFormat().setWidth(1.5);
    summarySection.setTransitionDuration(1.5);
    // Prezentáció mentése
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **GYIK**

**Vissza tudok irányítani a 'szülő' diára a cél megjelenítése után?**

Igen. A [Zoom frame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/zoomframe/) vagy a [section](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sectionzoomframe/) rendelkezik egy `setReturnToParent` metódussal, amely bekapcsolt állapotban visszaküldi a nézőket a kiindulási diára a cél tartalom megtekintése után.

**Módosíthatom a Zoom átmenet 'sebességét' vagy időtartamát?**

Igen. A Zoom egy `setTransitionDuration` metódust biztosít, amellyel szabályozható, mennyi ideig tart az ugrás animációja.

**Vannak korlátok arra vonatkozóan, hány Zoom objektumot tartalmazhat egy bemutató?**

A dokumentációban nincs rögzített API korlát. A gyakorlati korlátok a bemutató összetettségétől és a megjelenítő teljesítményétől függenek. Sok Zoom keretet hozzáadhat, de vegye figyelembe a fájlméretet és a renderelési időt.