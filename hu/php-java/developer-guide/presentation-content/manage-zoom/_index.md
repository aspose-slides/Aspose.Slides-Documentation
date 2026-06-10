---
title: Prezentáció zoom kezelése PHP-ben
linktitle: Zoom kezelése
type: docs
weight: 60
url: /hu/php-java/manage-zoom/
keywords:
- nagyítás
- zoom keret
- dia zoom
- szekció zoom
- összefoglaló zoom
- zoom hozzáadása
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Készítsen és testreszabjon Zoom-ot az Aspose.Slides for PHP via Java segítségével — ugorjon a szekciók között, adjon hozzá bélyegképeket és átmeneteket PPT, PPTX és ODP prezentációkban."
---
## **Bevezetés**

A PowerPoint-zoomok lehetővé teszik, hogy egy adott diára, szekcióra vagy a bemutató egy részére ugorjon, és onnan visszatérjen. Ha bemutatót tart, ez a gyors navigálási képesség rendkívül hasznos lehet.

![overview_image](overview.png)

* Az egész bemutató egy dián való összefoglalásához használja az [Összefoglaló Zoom](#Summary-Zoom).
* Csak a kiválasztott diák megjelenítéséhez használja a [Dia Zoom](#Slide-Zoom).
* Egyetlen szekció megjelenítéséhez használja a [Szekció Zoom](#Section-Zoom).

## **Dia Zoom**
A dia zoom dinamikusabbá teheti a bemutatót, lehetővé téve, hogy szabadon navigáljon a diák között bármilyen általad választott sorrendben anélkül, hogy megszakítaná a bemutató folytonosságát. A dia zoomok nagyszerűek rövid, kevés szekciót tartalmazó bemutatókhoz, de más bemutatási forgatókönyvekben is használhatók.

A dia zoomok segítenek több információs darabot is egyetlen vásznon belül felfedezni.

![overview_image](slidezoomsel.png)

Dia zoom objektumokhoz az Aspose.Slides biztosítja a [ZoomImageType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/zoomimagetype/) felsorolást, a [ZoomFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/zoomframe/) osztályt, valamint néhány metódust a [ShapeCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/) osztályon belül.

### **Zoom keretek létrehozása**

Zoom keretet a következő módon adhat egy diára:

1.	Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
2.	Hozzon létre új diákot, amelyhez a zoom kereteket kívánja kapcsolni. 
3.	Adjon az elkészített diákhoz azonosító szöveget és háttérképet.
4.	Hozzáadja a zoom kereteket (a létrehozott diákra mutató hivatkozásokkal) az első diához.
5.	Mentse a módosított bemutatót PPTX fájlként.

Ez a PHP‑kód bemutatja, hogyan hozhat létre zoom keretet egy dián:

```php
  $pres = new Presentation();
  try {
    # Új diák hozzáadása a prezentációhoz
    $slide2 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide3 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # Háttér létrehozása a második diára
    $slide2->getBackground()->setType(BackgroundType::OwnBackground);
    $slide2->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide2->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # Szövegdoboz létrehozása a második diára
    $autoshape = $slide2->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # Háttér létrehozása a harmadik diára
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # Szövegdoboz létrehozása a harmadik diára
    $autoshape = $slide3->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Trird Slide");
    # ZoomFrame objektumok hozzáadása
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 250, 200, $slide2);
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(200, 250, 250, 200, $slide3);
    # A prezentáció mentése
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **Zoom keretek létrehozása egyedi képekkel**
Az Aspose.Slides for PHP via Java használatával a következő módon hozhat létre egy zoom keretet más dia előnézeti képpel:
1.	Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
2.	Hozzon létre egy új diát, amelyhez a zoom keretet kívánja kapcsolni. 
3.	Adjon azonosító szöveget és háttérképet a diára.
4.	Hozzon létre egy [PPImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ppimage/) objektumot úgy, hogy egy képet ad hozzá a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) objektumhoz kapcsolt Images gyűjteményhez, amely a keret kitöltésére szolgál.
5.	Hozzáadja a zoom kereteket (a létrehozott diára mutató hivatkozással) az első diához.
6.	Mentse a módosított bemutatót PPTX fájlként.

Ez a PHP‑kód bemutatja, hogyan hozhat létre egy zoom keretet más képpel:

```php
  $pres = new Presentation();
  try {
    # Új dia hozzáadása a prezentációhoz
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # Háttér létrehozása a második diára
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # Szövegdoboz létrehozása a harmadik diára
    $autoshape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # Új kép létrehozása a zoom objektumhoz
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # ZoomFrame objektum hozzáadása
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 300, 200, $slide, $picture);
    # A prezentáció mentése
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **Zoom keretek formázása**
Az előző szakaszokban bemutattuk, hogyan kell egyszerű zoom kereteket létrehozni. Összetettebb zoom keretek létrehozásához módosítania kell egy egyszerű keret formázását. Számos formázási lehetőség áll rendelkezésre egy zoom kerethez. 

A zoom keret formázását a dián a következő módon vezérelheti:

1.	Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
2.	Hozzon létre új diákot, amelyekhez a zoom keretet kívánja kapcsolni. 
3.	Adjon azonosító szöveget és háttérképet a létrehozott diákhoz.
4.	Hozzáadja a zoom kereteket (a létrehozott diákra mutató hivatkozásokkal) az első diához.
5.	Hozzon létre egy [PPImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ppimage/) objektumot úgy, hogy egy képet ad hozzá a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) objektumhoz kapcsolt Images gyűjteményhez, amely a keret kitöltésére szolgál.
6.	Állítson be egy egyedi képet az első zoom keret objektumhoz.
7.	Módosítsa a vonalformátumot a második zoom keret objektumnál.
8.	Távolítsa el a háttérképet a második zoom keret objektum képből.
5.	Mentse a módosított bemutatót PPTX fájlként.

Ez a PHP‑kód bemutatja, hogyan változtathatja meg egy zoom keret formázását a dián:

```php
  $pres = new Presentation();
  try {
    # Új diákok hozzáadása a prezentációhoz
    $slide2 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide3 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # Háttér létrehozása a második diára
    $slide2->getBackground()->setType(BackgroundType::OwnBackground);
    $slide2->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide2->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # Szövegdoboz létrehozása a második diára
    $autoshape = $slide2->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # Háttér létrehozása a harmadik diára
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # Szövegdoboz létrehozása a harmadik diára
    $autoshape = $slide3->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Trird Slide");
    # ZoomFrame objektumok hozzáadása
    $zoomFrame1 = $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 250, 200, $slide2);
    $zoomFrame2 = $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(200, 250, 250, 200, $slide3);
    # Új kép létrehozása a zoom objektumhoz
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Egyedi kép beállítása a zoomFrame1 objektumhoz
    $zoomFrame1->setImage($picture);
    # ZoomFrame2 objektum formátumának beállítása
    $zoomFrame2->getLineFormat()->setWidth(5);
    $zoomFrame2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $zoomFrame2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->pink);
    $zoomFrame2->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    # Beállítás: ne mutassa a háttérképet a zoomFrame2 objektumnál
    $zoomFrame2->setShowBackground(false);
    # A prezentáció mentése
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Szekció Zoom**

A szekció zoom egy hivatkozás a bemutató egy szekciójára. Szekció zoomokkal visszatérhet azokhoz a szekciókhoz, amelyeket különösen szeretne hangsúlyozni. Vagy használhatja őket arra, hogy kiemelje, miként kapcsolódnak a bemutató egyes részei egymáshoz. 

![overview_image](seczoomsel.png)

Szekció zoom objektumokhoz az Aspose.Slides biztosítja a [SectionZoomFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sectionzoomframe/) osztályt, valamint néhány metódust a [ShapeCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/) osztályon belül.

### **Szekció zoom keretek létrehozása**

Szekció zoom keretet a következő módon adhat egy diára:

1.	Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
2.	Hozzon létre egy új diát. 
3.	Adjon azonosító háttérképet a létrehozott diára.
4.	Hozzon létre egy új szekciót, amelyhez a zoom keretet kívánja kapcsolni. 
5.	Adjon egy szekció zoom keretet (a létrehozott szekcióra mutató hivatkozással) az első diához.
6.	Mentse a módosított bemutatót PPTX fájlként.

Ez a PHP‑kód bemutatja, hogyan hozhat létre egy zoom keretet egy dián:

```php
  $pres = new Presentation();
  try {
    # Új dia hozzáadása a prezentációhoz
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Új szekció hozzáadása a prezentációhoz
    $pres->getSections()->addSection("Section 1", $slide);
    # SectionZoomFrame objektum hozzáadása
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1));
    # A prezentáció mentése
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **Szekció zoom keretek létrehozása egyedi képekkel**

Az Aspose.Slides for PHP via Java használatával a következő módon hozhat létre egy szekció zoom keretet más dia előnézeti képpel:

1.	Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
2.	Hozzon létre egy új diát.
3.	Adjon azonosító háttérképet a létrehozott diára.
4.	Hozzon létre egy új szekciót, amelyhez a zoom keretet kívánja kapcsolni. 
5.	Hozzon létre egy [PPImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ppimage/) objektumot úgy, hogy egy képet ad hozzá a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) objektumhoz kapcsolt Images gyűjteményhez, amely a keret kitöltésére szolgál.
5.	Adjon egy szekció zoom keretet (a létrehozott szekcióra mutató hivatkozással) az első diához.
6.	Mentse a módosított bemutatót PPTX fájlként.

Ez a PHP‑kód bemutatja, hogyan hozhat létre egy zoom keretet más képpel:

```php
  $pres = new Presentation();
  try {
    # Új dia hozzáadása a prezentációhoz
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Új szekció hozzáadása a prezentációhoz
    $pres->getSections()->addSection("Section 1", $slide);
    # Új kép létrehozása a zoom objektumhoz
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # SectionZoomFrame objektum hozzáadása
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1), $picture);
    # A prezentáció mentése
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **Szekció zoom keretek formázása**

Összetettebb szekció zoom keretek létrehozásához módosítania kell egy egyszerű keret formázását. Számos formázási lehetőség áll rendelkezésre egy szekció zoom kerethez. 

A szekció zoom keret formázását a dián a következő módon vezérelheti:

1.	Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
2.	Hozzon létre egy új diát.
3.	Adjon azonosító háttérképet a létrehozott diára.
4.	Hozzon létre egy új szekciót, amelyhez a zoom keretet kívánja kapcsolni. 
5.	Adjon egy szekció zoom keretet (a létrehozott szekcióra mutató hivatkozással) az első diához.
6.	Módosítsa a létrehozott szekció zoom objektum méretét és pozícióját.
7.	Hozzon létre egy [PPImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ppimage/) objektumot úgy, hogy egy képet ad hozzá a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) objektumhoz kapcsolt Images gyűjteményhez, amely a keret kitöltésére szolgál.
8.	Állítson be egy egyedi képet a létrehozott szekció zoom keret objektumhoz.
9.	Állítsa be a *visszatérés az eredeti diára a kapcsolt szekcióból* képességet. 
10.	Távolítsa el a háttérképet a szekció zoom keret objektum képből.
11.	Módosítsa a vonalformátumot a második zoom keret objektumnál.
12.	Módosítsa az átmenet időtartamát.
13.	Mentse a módosított bemutatót PPTX fájlként.

Ez a PHP‑kód bemutatja, hogyan változtathatja meg egy szekció zoom keret formázását:

```php
  $pres = new Presentation();
  try {
    # Új dia hozzáadása a prezentációhoz
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Új szekció hozzáadása a prezentációhoz
    $pres->getSections()->addSection("Section 1", $slide);
    # SectionZoomFrame objektum hozzáadása
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1));
    # SectionZoomFrame formázása
    $sectionZoomFrame->setX(100);
    $sectionZoomFrame->setY(300);
    $sectionZoomFrame->setWidth(100);
    $sectionZoomFrame->setHeight(75);
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $sectionZoomFrame->setImage($picture);
    $sectionZoomFrame->setReturnToParent(true);
    $sectionZoomFrame->setShowBackground(false);
    $sectionZoomFrame->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $sectionZoomFrame->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $sectionZoomFrame->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $sectionZoomFrame->getLineFormat()->setWidth(2.5);
    $sectionZoomFrame->setTransitionDuration(1.5);
    # A prezentáció mentése
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Összefoglaló Zoom**

Az összefoglaló zoom olyan, mint egy landing oldal, ahol a bemutató minden része egyszerre jelenik meg. Amikor bemutatót tart, a zoom segítségével bármilyen sorrendben ugorhat egyik helyről a másikra. Kreatív lehet, előre ugrálhat, vagy visszatérhet a diavetítés egyes részeihez anélkül, hogy megszakítaná a bemutató folytonosságát.

![overview_image](sumzoomsel.png)

Összefoglaló zoom objektumokhoz az Aspose.Slides biztosítja a [SummaryZoomFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/summaryzoomframe/), a [SummaryZoomSection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/summaryzoomsection/), és a [SummaryZoomSectionCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/summaryzoomsectioncollection/) osztályokat, valamint néhány metódust a [ShapeCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/) osztályon belül.

### **Összefoglaló Zoom létrehozása**

Összefoglaló zoom keretet a következő módon adhat egy diára:

1.	Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
2.	Hozzon létre új diákot azonosító háttérrel és új szekciókkal a létrehozott diákhoz.
3.	Adjon egy összefoglaló zoom keretet az első diához.
4.	Mentse a módosított bemutatót PPTX fájlként.

Ez a PHP‑kód bemutatja, hogyan hozhat létre egy összefoglaló zoom keretet egy dián:

```php
  $pres = new Presentation();
  try {
    # Új dia hozzáadása a prezentációhoz
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Új szekció hozzáadása a prezentációhoz
    $pres->getSections()->addSection("Section 1", $slide);
    # Új dia hozzáadása a prezentációhoz
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Új szekció hozzáadása a prezentációhoz
    $pres->getSections()->addSection("Section 2", $slide);
    # Új dia hozzáadása a prezentációhoz
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->magenta);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Új szekció hozzáadása a prezentációhoz
    $pres->getSections()->addSection("Section 3", $slide);
    # Új dia hozzáadása a prezentációhoz
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->green);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Új szekció hozzáadása a prezentációhoz
    $pres->getSections()->addSection("Section 4", $slide);
    # SummaryZoomFrame objektum hozzáadása
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # A prezentáció mentése
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Összefoglaló Zoom szekció hozzáadása és eltávolítása**

Az összefoglaló zoom keretben minden szekciót a [SummaryZoomSection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/summaryzoomsection/) objektumok képviselnek, amelyek a [SummaryZoomSectionCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/summaryzoomsectioncollection/) objektumban tárolódnak. Egy összefoglaló zoom szekció objektumot a [SummaryZoomSectionCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/summaryzoomsectioncollection/) osztályon keresztül a következő módon adhat hozzá vagy távolíthat el:

1.	Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
2.	Hozzon létre új diákot azonosító háttérrel és új szekciókkal a létrehozott diákhoz.
3.	Adjon egy összefoglaló zoom keretet az első diához.
4.	Adjon egy új diát és szekciót a bemutatóhoz.
5.	Adja hozzá a létrehozott szekciót az összefoglaló zoom kerethez.
6.	Távolítsa el az első szekciót az összefoglaló zoom keretből.
7.	Mentse a módosított bemutatót PPTX fájlként.

Ez a PHP‑kód bemutatja, hogyan adhat hozzá és távolíthat el szekciókat egy összefoglaló zoom keretben:

```php
  $pres = new Presentation();
  try {
    # Új dia hozzáadása a prezentációhoz
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Új szekció hozzáadása a prezentációhoz
    $pres->getSections()->addSection("Section 1", $slide);
    # Új dia hozzáadása a prezentációhoz
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Új szekció hozzáadása a prezentációhoz
    $pres->getSections()->addSection("Section 2", $slide);
    # SummaryZoomFrame objektum hozzáadása
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # Új dia hozzáadása a prezentációhoz
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->magenta);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Új szekció hozzáadása a prezentációhoz
    $section3 = $pres->getSections()->addSection("Section 3", $slide);
    # Szekció hozzáadása a Summary Zoom-hoz
    $summaryZoomFrame->getSummaryZoomCollection()->addSummaryZoomSection($section3);
    # Szekció eltávolítása a Summary Zoom-ból
    $summaryZoomFrame->getSummaryZoomCollection()->removeSummaryZoomSection($pres->getSections()->get_Item(1));
    # A prezentáció mentése
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Összefoglaló Zoom szekciók formázása**

Összetettebb összefoglaló zoom szekció objektumok létrehozásához módosítania kell egy egyszerű keret formázását. Számos formázási lehetőség áll rendelkezésre egy összefoglaló zoom szekció objektumhoz. 

Egy összefoglaló zoom szekció objektum formázását egy összefoglaló zoom keretben a következő módon vezérelheti:

1.	Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
2.	Hozzon létre új diákot azonosító háttérrel és új szekciókkal a létrehozott diákhoz.
3.	Adjon egy összefoglaló zoom keretet az első diához.
4.	Szerezzen be egy összefoglaló zoom szekció objektumot az első elemhez a `SummaryZoomSectionCollection`-ből.
7.	Hozzon létre egy [PPImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ppimage/) objektumot úgy, hogy egy képet ad hozzá a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) objektumhoz kapcsolt images gyűjteményhez, amely a keret kitöltésére szolgál.
8.	Állítson be egy egyedi képet a létrehozott szekció zoom keret objektumhoz.
9.	Állítsa be a *visszatérés az eredeti diára a kapcsolt szekcióból* képességet. 
11.	Módosítsa a vonalformátumot a második zoom keret objektumnál.
12.	Módosítsa az átmenet időtartamát.
13.	Mentse a módosított bemutatót PPTX fájlként.

Ez a PHP‑kód bemutatja, hogyan változtathatja meg egy összefoglaló zoom szekció objektum formázását:

```php
  $pres = new Presentation();
  try {
    # Új dia hozzáadása a prezentációhoz
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Új szekció hozzáadása a prezentációhoz
    $pres->getSections()->addSection("Section 1", $slide);
    # Új dia hozzáadása a prezentációhoz
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Új szekció hozzáadása a prezentációhoz
    $pres->getSections()->addSection("Section 2", $slide);
    # SummaryZoomFrame objektum hozzáadása
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # Az első SummaryZoomSection objektum lekérése
    $summarySection = $summaryZoomFrame->getSummaryZoomCollection()->get_Item(0);
    # SummaryZoomSection objektum formázása
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($picture);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $summarySection->setImage($picture);
    $summarySection->setReturnToParent(false);
    $summarySection->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $summarySection->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->black);
    $summarySection->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $summarySection->getLineFormat()->setWidth(1.5);
    $summarySection->setTransitionDuration(1.5);
    # A prezentáció mentése
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **GYIK**

**Lehetséges-e vezérelni a visszatérést a „szülő” diára a cél megjelenítése után?**

Igen. A [Zoom frame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/zoomframe/) vagy a [section](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sectionzoomframe/) rendelkezik egy `ReturnToParent` viselkedéssel, amely engedélyezve visszaküldi a nézőket a kiinduló diára, miután meglátogatták a céltartalmat.

**Módosítható a Zoom átmenet „sebessége” vagy időtartama?**

Igen. A Zoom támogatja a `TransitionDuration` beállítását, így szabályozhatja, milyen hosszú legyen az ugrásanimáció.

**Van korlátozás arra, hogy hány Zoom objektumot tartalmazhat egy bemutató?**

Nincs dokumentált szigorú API‑korlát. A gyakorlati korlátok a bemutató összetettségétől és a nézők teljesítményétől függenek. Sok Zoom keretet hozzáadhat, de vegye figyelembe a fájlméretet és a renderelési időt.