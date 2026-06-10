---
title: "Presentation Zoom kezelése Androidon"
linktitle: "Zoom kezelése"
type: docs
weight: 60
url: /hu/androidjava/manage-zoom/
keywords:
- zoom
- zoom keret
- dia zoom
- szekció zoom
- összegző zoom
- zoom hozzáadása
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Zoom létrehozása és testreszabása az Aspose.Slides for Android via Java segítségével — ugráljon a szekciók között, adjon hozzá miniatűröket és átmeneteket PPT, PPTX és ODP prezentációkban."
---
## **Bevezetés**

A PowerPoint zoomok lehetővé teszik, hogy egy adott diára, szekcióra vagy a bemutató egy részére ugorjon oda‑vissza. Amikor előadást tart, ez a tartalomban való gyors navigálás nagyon hasznos lehet. 

![overview_image](overview.png)

* Egy teljes bemutató összegzéséhez egyetlen dián, használja az [Összegző Zoom](#Summary-Zoom).
* Csak a kiválasztott diák megjelenítéséhez használja a [Dia Zoomot](#Slide-Zoom).
* Egyetlen szekció megjelenítéséhez használja a [Szekció Zoomot](#Section-Zoom).

## **Dia Zoom**
A dia zoom dinamikusabbá teheti a bemutatót, lehetővé téve, hogy szabadon navigáljon a diák között bármilyen sorrendben, megszakítás nélkül. A dia zoomok kiválóak rövid, kevés szekciót tartalmazó előadásokhoz, de más bemutató‑szituációkban is használhatók.

A dia zoomok segítenek több információs darabot részletezni, miközben egyetlen vászonnak érzi a prezentációt. 

![overview_image](slidezoomsel.png)

Dia zoom objektumokhoz az Aspose.Slides a [ZoomImageType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ZoomImageType) felsorolást, az [IZoomFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IZoomFrame) interfészt és néhány metódust a [IShapeCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShapeCollection) interfész alatt biztosít.

### **Zoomkeretek létrehozása**

Zoomkeretet a diára a következőképpen adhat hozzá:

1.	Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.
2.	Hozzon létre új diákat, amelyekhez a zoomkereteket szeretné kapcsolni. 
3.	Adjon hozzá azonosító szöveget és háttérképet a létrehozott diákhoz.
4.	Adjon hozzá zoomkereteket (a létrehozott diákra mutató hivatkozásokkal) az első diához.
5.	Írja a módosított bemutatót PPTX fájlként.

``` java
Presentation pres = new Presentation();
try {
    //Új diák hozzáadása a prezentációhoz
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Háttér létrehozása a második dián
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Szövegdoboz létrehozása a második dián
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // Háttér létrehozása a harmadik dián
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // Szövegdoboz létrehozása a harmadik dián
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    // ZoomFrame objektumok hozzáadása
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // A prezentáció mentése
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **Zoomkeretek létrehozása egyedi képekkel**
Az Aspose.Slides for Android via Java segítségével egyedi dia előnézeti képpel hozhat létre zoomkeretet a következő módon:
1.	Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.
2.	Hozzon létre egy új diát, amelyhez a zoomkeretet szeretné kapcsolni. 
3.	Adjon hozzá azonosító szöveget és háttérképet a diához.
4.	Hozzon létre egy [IPPImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPPImage) objektumot úgy, hogy képet ad hozzá a [Presentation] objektumhoz tartozó Images gyűjthez, amely a keret kitöltésére lesz használva.
5.	Adjon hozzá zoomkereteket (a létrehozott diára mutató hivatkozással) az első diához.
6.	Írja a módosított bemutatót PPTX fájlként.

``` java
Presentation pres = new Presentation();
try {
    //Új dia hozzáadása a prezentációhoz
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Háttér létrehozása a második dián
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Szövegdoboz létrehozása a harmadik dián
    IAutoShape autoshape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // Új kép létrehozása a zoom objektumhoz
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    //ZoomFrame objektum hozzáadása
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);

    // A prezentáció mentése
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
### **Zoomkeretek formázása**
Az előző részekben bemutattuk, hogyan hozhat létre egyszerű zoomkereteket. Bonyolultabb zoomkeretek létrehozásához módosítani kell egy egyszerű keret formázását. Számos formázási lehetőség áll rendelkezésre egy zoomkerethez. 

A zoomkeret formázását a dián a következőképpen vezérelheti:

1.	Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.
2.	Hozzon létre új diákat, amelyekhez a zoomkeretet kívánja kapcsolni. 
3.	Adjon azonosító szöveget és háttérképet a létrehozott diákhoz.
4.	Adjon hozzá zoomkereteket (a létrehozott diákra mutató hivatkozásokkal) az első diához.
5.	Hozzon létre egy [IPPImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPPImage) objektumot úgy, hogy képet ad hozzá a [Presentation] objektumhoz tartozó Images gyűjthez, amely a keret kitöltésére lesz használva.
6.	Állítson be egy egyedi képet az első zoomkeret objektumhoz.
7.	Módosítsa a vonalformátumot a második zoomkeret objektumban.
8.	Távolítsa el a háttérképet a második zoomkeret objektum képéből.
9.	Írja a módosított bemutatót PPTX fájlként.

``` java 
Presentation pres = new Presentation();
try {
    //Új diák hozzáadása a prezentációhoz
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Háttér létrehozása a második dián
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Szövegdoboz létrehozása a második dián
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // Háttér létrehozása a harmadik dián
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // Szövegdoboz létrehozása a harmadik dián
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //ZoomFrame objektumok hozzáadása
    IZoomFrame zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // Új kép létrehozása a zoom objektumhoz
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    // Egyedi kép beállítása a zoomFrame1 objektumhoz
    zoomFrame1.setImage(picture);

    // Zoomkeret formátum beállítása a zoomFrame2 objektumhoz
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink);
    zoomFrame2.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    // Beállítás: ne mutassa a háttérképet a zoomFrame2 objektumban
    zoomFrame2.setShowBackground(false);

    // A prezentáció mentése
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Szekció Zoom**

A szekció zoom egy hivatkozás a bemutató egy szekciójára. A szekció zoomokkal visszatérhet a kiemelni kívánt szekciókra, vagy kiemelheti, hogyan kapcsolódnak a bemutató egyes részei. 

![overview_image](seczoomsel.png)

Szekció zoom objektumokhoz az Aspose.Slides az [ISectionZoomFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISectionZoomFrame) interfészt és néhány metódust a [IShapeCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShapeCollection) interfész alatt biztosít.

### **Szekció Zoom keretek létrehozása**

Szekció zoom keretet a diára a következőképpen adhat hozzá:

1.	Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.
2.	Hozzon létre egy új diát. 
3.	Adjon azonosító háttérképet a létrehozott diához.
4.	Hozzon létre egy új szekciót, amelyhez a zoomkeretet kívánja kapcsolni. 
5.	Adjon hozzá egy szekció zoom keretet (a létrehozott szekcióra mutató hivatkozásokkal) az első diához.
6.	Írja a módosított bemutatót PPTX fájlként.

``` java
Presentation pres = new Presentation();
try {
    //Új dia hozzáadása a prezentációhoz
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Új szekció hozzáadása a prezentációhoz
    pres.getSections().addSection("Section 1", slide);

    // Új SectionZoomFrame objektum hozzáadása
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // A prezentáció mentése
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **Szekció Zoom keretek létrehozása egyedi képekkel**

Az Aspose.Slides for Android via Java segítségével egyedi dia előnézeti képpel hozhat létre szekció zoom keretet a következő módon:

1.	Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.
2.	Hozzon létre egy új diát.
3.	Adjon azonosító háttérképet a létrehozott diához.
4.	Hozzon létre egy új szekciót, amelyhez a zoomkeretet kívánja kapcsolni. 
5.	Hozzon létre egy [IPPImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPPImage) objektumot úgy, hogy képet ad hozzá a [Presentation] objektumhoz tartozó Images gyűjthez, amely a keret kitöltésére lesz használva.
6.	Adjon hozzá egy szekció zoom keretet (a létrehozott szekcióra mutató hivatkozással) az első diához.
7.	Írja a módosított bemutatót PPTX fájlként.

``` java 
Presentation pres = new Presentation();
try {
    //Új dia hozzáadása a prezentációhoz
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Új szekció hozzáadása a prezentációhoz
    pres.getSections().addSection("Section 1", slide);

    // Új kép létrehozása a zoom objektumhoz
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // SectionZoomFrame objektum hozzáadása
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1), picture);

    // A prezentáció mentése
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
### **Szekció Zoom keretek formázása**

Bonyolultabb szekció zoom keretek létrehozásához módosítani kell egy egyszerű keret formázását. Számos formázási lehetőség áll rendelkezésre egy szekció zoom kerethez. 

A szekció zoom keret formázását a dián a következőképpen vezérelheti:

1.	Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.
2.	Hozzon létre egy új diát.
3.	Adjon azonosító háttérképet a létrehozott diához.
4.	Hozzon létre egy új szekciót, amelyhez a zoomkeretet kívánja kapcsolni. 
5.	Adjon hozzá egy szekció zoom keretet (a létrehozott szekcióra mutató hivatkozásokkal) az első diához.
6.	Módosítsa a létrehozott szekció zoom objektum méretét és pozícióját.
7.	Hozzon létre egy [IPPImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPPImage) objektumot úgy, hogy képet ad hozzá a [Presentation] objektumhoz tartozó images collection-hoz, amely a keret kitöltésére lesz használva.
8.	Állítson be egy egyedi képet a létrehozott szekció zoom keret objektumhoz.
9.	Állítsa be a *visszatérés az eredeti diára a kapcsolt szekcióból* funkciót. 
10.	Távolítsa el a háttérképet a szekció zoom keret objektum képéből.
11.	Módosítsa a vonalformátumot a második zoomkeret objektumban.
12.	Módosítsa az áttűnés időtartamát.
13.	Írja a módosított bemutatót PPTX fájlként.

``` java
Presentation pres = new Presentation();
try {
    //Új dia hozzáadása a prezentációhoz
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Új szekció hozzáadása a prezentációhoz
    pres.getSections().addSection("Section 1", slide);

    // SectionZoomFrame objektum hozzáadása
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // SectionZoomFrame formázása
    sectionZoomFrame.setX(100);
    sectionZoomFrame.setY(300);
    sectionZoomFrame.setWidth(100);
    sectionZoomFrame.setHeight(75);

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
         picture = pres.getImages().addImage(image);
     } finally {
        if (image != null) image.dispose();
     }
    sectionZoomFrame.setImage(picture);

    sectionZoomFrame.setReturnToParent(true);
    sectionZoomFrame.setShowBackground(false);

    sectionZoomFrame.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    sectionZoomFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.gray);
    sectionZoomFrame.getLineFormat().setDashStyle(LineDashStyle.DashDot);
    sectionZoomFrame.getLineFormat().setWidth(2.5f);

    sectionZoomFrame.setTransitionDuration(1.5f);

    // A prezentáció mentése
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Összegző Zoom**

Az összegző zoom olyan kiinduló oldal, ahol a bemutató összes része egyszerre látható. Előadás közben a zoom segítségével bármilyen sorrendben ugorhat egyik helyről a másikra. Kreatív lehet, előreugorhat, vagy visszatérhet a diavetítés részeihez anélkül, hogy megszakítaná a bemutató folyamatát.

![overview_image](sumzoomsel.png)

Összegző zoom objektumokhoz az Aspose.Slides az [ISummaryZoomFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISummaryZoomFrame), [ISummaryZoomSection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISummaryZoomSection) és [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISummaryZoomSectionCollection) interfészeket és néhány metódust a [IShapeCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShapeCollection) interfész alatt biztosít.

### **Összegző Zoom létrehozása**

Összegző zoom keretet a diára a következőképpen adhat hozzá:

1.	Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.
2.	Hozzon létre új diákot azonosító háttérrel és új szekciókkal a létrehozott diákhoz.
3.	Adja hozzá az összegző zoom keretet az első diához.
4.	Írja a módosított bemutatót PPTX fájlként.

``` java 
Presentation pres = new Presentation();
try {
    //Új dia hozzáadása a prezentációhoz
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Új szekció hozzáadása a prezentációhoz
    pres.getSections().addSection("Section 1", slide);

    //Új dia hozzáadása a prezentációhoz
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Új szekció hozzáadása a prezentációhoz
    pres.getSections().addSection("Section 2", slide);

    //Új dia hozzáadása a prezentációhoz
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Új szekció hozzáadása a prezentációhoz
    pres.getSections().addSection("Section 3", slide);

    //Új dia hozzáadása a prezentációhoz
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.green);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Új szekció hozzáadása a prezentációhoz
    pres.getSections().addSection("Section 4", slide);

    // SummaryZoomFrame objektum hozzáadása
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // A prezentáció mentése
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Összegző Zoom szekció hozzáadása és eltávolítása**

Az összegző zoom keretben minden szekciót az [ISummaryZoomSection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISummaryZoomSection) objektumok képviselnek, amelyek az [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISummaryZoomSectionCollection) objektumban tárolódnak. Egy összegző zoom szekció objektumot a [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISummaryZoomSectionCollection) interfészen keresztül a következő módon adhat hozzá vagy vehet el:

1.	Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.
2.	Hozzon létre új diákot azonosító háttérrel és új szekciókkal a létrehozott diákhoz.
3.	Adjon egy összegző zoom keretet az első diához.
4.	Adjon egy új diát és szekciót a bemutatóhoz.
5.	Adja hozzá a létrehozott szekciót az összegző zoom kerethez.
6.	Távolítsa el az első szekciót az összegző zoom keretből.
7.	Írja a módosított bemutatót PPTX fájlként.

``` java
Presentation pres = new Presentation();
try {
    //Adds a new slide to the presentation
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new section to the presentation
    pres.getSections().addSection("Section 1", slide);

    //Adds a new slide to the presentation
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new section to the presentation
    pres.getSections().addSection("Section 2", slide);

    // Adds SummaryZoomFrame object
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    //Adds a new slide to the presentation
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new section to the presentation
    ISection section3 = pres.getSections().addSection("Section 3", slide);

    // Adds a section to the Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);

    // Removes section from the Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));

    // Saves the presentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Összegző Zoom szekciók formázása**

Bonyolultabb összegző zoom szekció objektumok létrehozásához módosítani kell egy egyszerű keret formázását. Számos formázási lehetőség áll rendelkezésre egy összegző zoom szekció objektumhoz. 

Az összegző zoom szekció objektum formázását az összegző zoom keretben a következőképpen vezérelheti:

1.	Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.
2.	Hozzon létre új diákot azonosító háttérrel és új szekciókkal a létrehozott diákhoz.
3.	Adjon egy összegző zoom keretet az első diához.
4.	Szerezzen egy summary zoom szekció objektumot az első objektumhoz a `ISummaryZoomSectionCollection`‑ból.
7.	Hozzon létre egy [IPPImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPPImage) objektumot úgy, hogy képet ad hozzá a [Presentation] objektumhoz tartozó images collection-hoz, amely a keret kitöltésére lesz használva.
8.	Állítson be egy egyedi képet a létrehozott szekció zoom keret objektumhoz.
9.	Állítsa be a *visszatérés az eredeti diára a kapcsolt szekcióból* funkciót. 
11.	Módosítsa a vonalformátumot a második zoomkeret objektumban.
12.	Módosítsa az áttűnés időtartamát.
13.	Írja a módosított bemutatót PPTX fájlként.

``` java
Presentation pres = new Presentation();
try {
    //Új dia hozzáadása a prezentációhoz
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    //Új szekció hozzáadása a prezentációhoz
    pres.getSections().addSection("Section 1", slide);

    //Új dia hozzáadása a prezentációhoz
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    //Új szekció hozzáadása a prezentációhoz
    pres.getSections().addSection("Section 2", slide);

    //SummaryZoomFrame objektum hozzáadása
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    //Az első SummaryZoomSection objektum lekérése
    ISummaryZoomSection summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);

    //SummaryZoomSection objektum formázása
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(picture);
    } finally {
        if (image != null) image.dispose();
    }
    summarySection.setImage(picture);

    summarySection.setReturnToParent(false);

    summarySection.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    summarySection.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.black);
    summarySection.getLineFormat().setDashStyle(LineDashStyle.DashDot);
    summarySection.getLineFormat().setWidth(1.5f);

    summarySection.setTransitionDuration(1.5f);

    //A prezentáció mentése
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Visszaállíthatom a 'szülő' diára a célt megjelenítés után?**

Igen. A [Zoom frame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/zoomframe/) vagy a [section](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/sectionzoomframe/) visszatérő szülő viselkedéssel rendelkezik, amely be van kapcsolva, visszaküldi a nézőket a kiindulási diára, miután megtekintették a céltartalmat.

**Beállíthatom a Zoom átmenet 'sebességét' vagy időtartamát?**

Igen. A Zoom támogatja a transzíció időtartamának beállítását, így szabályozhatja, mennyi ideig tart a ugrás animációja.

**Vannak korlátok arra, hogy hány Zoom objektumot tartalmazhat egy prezentáció?**

Nem dokumentált szigorú API‑korlát. A gyakorlati határ a bemutató összetettségétől és a néző teljesítményétől függ. Hozzáadhat sok Zoom keretet, de vegye figyelembe a fájlméretet és a renderelési időt.