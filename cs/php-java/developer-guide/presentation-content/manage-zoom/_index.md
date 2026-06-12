---
title: Správa zoomu prezentace v PHP
linktitle: Spravovat zoom
type: docs
weight: 60
url: /cs/php-java/manage-zoom/
keywords:
- zoom
- zoom rámec
- zoom snímku
- zoom sekce
- souhrnný zoom
- přidat zoom
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Vytvořte a přizpůsobte Zoom pomocí Aspose.Slides pro PHP prostřednictvím Javy — přeskakujte mezi sekcemi, přidávejte náhledy a přechody v prezentacích PPT, PPTX a ODP."
---
## **Úvod**

Zoomy v PowerPointu vám umožňují přecházet na konkrétní snímky, sekce a části prezentace a zpět. Při prezentaci vám tato schopnost rychle se orientovat v obsahu může být velmi užitečná. 

![overview_image](overview.png)

* Pro shrnutí celé prezentace na jediném snímku použijte [Souhrnný zoom](#Summary-Zoom).
* Pro zobrazení vybraných snímků použijte [Zoom snímku](#Slide-Zoom).
* Pro zobrazení jedné sekce použijte [Zoom sekce](#Section-Zoom).

## **Zoom snímku**
Zoom snímku může vaši prezentaci učinit dynamičtější, umožňující volně navigovat mezi snímky v libovolném pořadí, aniž byste narušili tok prezentace. Zoomy snímků jsou skvělé pro krátké prezentace bez mnoha sekcí, ale můžete je použít i v různých scénářích prezentace.

Zoomy snímků vám pomáhají podrobně prozkoumat více informací, přičemž máte pocit, že jste na jediné ploše. 

![overview_image](slidezoomsel.png)

Pro objekty zoomu snímku Aspose.Slides poskytuje výčet [ZoomImageType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/zoomimagetype/) , třídu [ZoomFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/zoomframe/) a některé metody ve třídě [ShapeCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/) .

### **Vytvoření zoomových rámečků**

Můžete přidat zoomový rámeček na snímek následujícím způsobem:

1.	Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) .
2.	Vytvořte nové snímky, ke kterým chcete propojit zoomové rámečky. 
3.	Přidejte identifikační text a pozadí k vytvořeným snímkům.
4.	Přidejte zoomové rámečky (obsahující odkazy na vytvořené snímky) na první snímek.
5.	Uložte upravenou prezentaci jako soubor PPTX.

```php
  $pres = new Presentation();
  try {
    # Přidá nové snímky do prezentace
    $slide2 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide3 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # Vytvoří pozadí pro druhý snímek
    $slide2->getBackground()->setType(BackgroundType::OwnBackground);
    $slide2->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide2->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # Vytvoří textové pole pro druhý snímek
    $autoshape = $slide2->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # Vytvoří pozadí pro třetí snímek
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # Vytvoří textové pole pro třetí snímek
    $autoshape = $slide3->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Trird Slide");
    # Přidá objekty ZoomFrame
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 250, 200, $slide2);
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(200, 250, 250, 200, $slide3);
    # Uloží prezentaci
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **Vytvoření zoomových rámečků s vlastními obrázky**
S Aspose.Slides for PHP via Java můžete vytvořit zoomový rámeček s jiným náhledem snímku takto:
1.	Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) .
2.	Vytvořte nový snímek, ke kterému chcete propojit zoomový rámeček. 
3.	Přidejte identifikační text a pozadí k snímku.
4.	Vytvořte objekt [PPImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ppimage/) přidáním obrázku do kolekce Images přidružené k objektu [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) , který bude použit k vyplnění rámečku.
5.	Přidejte zoomové rámečky (obsahující odkaz na vytvořený snímek) na první snímek.
6.	Uložte upravenou prezentaci jako soubor PPTX.

```php
  $pres = new Presentation();
  try {
    # Přidá nový snímek do prezentace
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # Vytvoří pozadí pro druhý snímek
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # Vytvoří textové pole pro třetí snímek
    $autoshape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # Vytvoří nový obrázek pro zoom objekt
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Přidá objekt ZoomFrame
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 300, 200, $slide, $picture);
    # Uloží prezentaci
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **Formátování zoomových rámečků**
V předchozích částech jsme vám ukázali, jak vytvořit jednoduché zoomové rámečky. Pro vytvoření složitějších zoomových rámečků musíte upravit formátování jednoduchého rámečku. Existuje několik možností formátování, které můžete použít na zoomový rámeček. 

Můžete ovládat formátování zoomového rámečku na snímku tímto způsobem:

1.	Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) .
2.	Vytvořte nové snímky, ke kterým chcete propojit zoomový rámeček. 
3.	Přidejte nějaký identifikační text a pozadí k vytvořeným snímkům.
4.	Přidejte zoomové rámečky (obsahující odkazy na vytvořené snímky) na první snímek.
5.	Vytvořte objekt [PPImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ppimage/) přidáním obrázku do kolekce Images přidružené k objektu [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) , který bude použit k vyplnění rámečku.
6.	Nastavte vlastní obrázek pro první objekt zoomového rámečku.
7.	Změňte formát čáry pro druhý objekt zoomového rámečku.
8.	Odstraňte pozadí z obrázku druhého objektu zoomového rámečku.
5.	Uložte upravenou prezentaci jako soubor PPTX.

```php
  $pres = new Presentation();
  try {
    # Přidá nové snímky do prezentace
    $slide2 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide3 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # Vytvoří pozadí pro druhý snímek
    $slide2->getBackground()->setType(BackgroundType::OwnBackground);
    $slide2->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide2->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # Vytvoří textové pole pro druhý snímek
    $autoshape = $slide2->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # Vytvoří pozadí pro třetí snímek
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # Vytvoří textové pole pro třetí snímek
    $autoshape = $slide3->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Trird Slide");
    # Přidá objekty ZoomFrame
    $zoomFrame1 = $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 250, 200, $slide2);
    $zoomFrame2 = $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(200, 250, 250, 200, $slide3);
    # Vytvoří nový obrázek pro zoom objekt
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Nastaví vlastní obrázek pro objekt zoomFrame1
    $zoomFrame1->setImage($picture);
    # Nastaví formát zoom rámce pro objekt zoomFrame2
    $zoomFrame2->getLineFormat()->setWidth(5);
    $zoomFrame2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $zoomFrame2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->pink);
    $zoomFrame2->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    # Nastavení: neukazovat pozadí pro objekt zoomFrame2
    $zoomFrame2->setShowBackground(false);
    # Uloží prezentaci
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Zoom sekce**

Zoom sekce je odkaz na sekci v prezentaci. Můžete použít zoomy sekcí k návratu na sekce, které chcete opravdu zdůraznit. Nebo je můžete použít k zvýraznění toho, jak se určité části vaší prezentace propojují. 

![overview_image](seczoomsel.png)

Pro objekty zoomu sekce Aspose.Slides poskytuje třídu [SectionZoomFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sectionzoomframe/) a některé metody ve třídě [ShapeCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/) .

### **Vytvoření zoomových rámečků sekce**

Můžete přidat zoomový rámeček sekce na snímek následujícím způsobem:

1.	Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) .
2.	Vytvořte nový snímek. 
3.	Přidejte identifikační pozadí k vytvořenému snímku.
4.	Vytvořte novou sekci, ke které chcete propojit zoomový rámeček. 
5.	Přidejte zoomový rámeček sekce (obsahující odkazy na vytvořenou sekci) na první snímek.
6.	Uložte upravenou prezentaci jako soubor PPTX.

```php
  $pres = new Presentation();
  try {
    # Přidá nový snímek do prezentace
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Přidá novou sekci do prezentace
    $pres->getSections()->addSection("Section 1", $slide);
    # Přidá objekt SectionZoomFrame
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1));
    # Uloží prezentaci
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **Vytvoření zoomových rámečků sekce s vlastními obrázky**

Pomocí Aspose.Slides for PHP via Java můžete vytvořit zoomový rámeček sekce s jiným náhledem snímku takto:

1.	Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) .
2.	Vytvořte nový snímek.
3.	Přidejte identifikační pozadí k vytvořenému snímku.
4.	Vytvořte novou sekci, ke které chcete propojit zoomový rámeček. 
5.	Vytvořte objekt [PPImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ppimage/) přidáním obrázku do kolekce Images přidružené k objektu [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) , který bude použit k vyplnění rámečku.
5.	Přidejte zoomový rámeček sekce (obsahující odkaz na vytvořenou sekci) na první snímek.
6.	Uložte upravenou prezentaci jako soubor PPTX.

```php
  $pres = new Presentation();
  try {
    # Přidá nový snímek do prezentace
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Přidá novou sekci do prezentace
    $pres->getSections()->addSection("Section 1", $slide);
    # Vytvoří nový obrázek pro zoom objekt
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Přidá objekt SectionZoomFrame
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1), $picture);
    # Uloží prezentaci
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **Formátování zoomových rámečků sekce**

Pro vytvoření složitějších zoomových rámečků sekce musíte upravit formátování jednoduchého rámečku. Existuje několik možností formátování, které můžete použít na zoomový rámeček sekce. 

Můžete ovládat formátování zoomového rámečku sekce na snímku tímto způsobem:

1.	Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) .
2.	Vytvořte nový snímek.
3.	Přidejte identifikační pozadí k vytvořenému snímku.
4.	Vytvořte novou sekci, ke které chcete propojit zoomový rámeček. 
5.	Přidejte zoomový rámeček sekce (obsahující odkazy na vytvořenou sekci) na první snímek.
6.	Změňte velikost a pozici vytvořeného objektu zoomu sekce.
7.	Vytvořte objekt [PPImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ppimage/) přidáním obrázku do kolekce Images přidružené k objektu [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) , který bude použit k vyplnění rámečku.
8.	Nastavte vlastní obrázek pro vytvořený objekt zoomu sekce.
9.	Nastavte možnost *návratu na původní snímek z propojené sekce*. 
10.	Odstraňte pozadí z obrázku objektu zoomu sekce.
11.	Změňte formát čáry pro druhý objekt zoomu.
12.	Změňte dobu trvání přechodu.
13.	Uložte upravenou prezentaci jako soubor PPTX.

```php
  $pres = new Presentation();
  try {
    # Přidá nový snímek do prezentace
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Přidá novou sekci do prezentace
    $pres->getSections()->addSection("Section 1", $slide);
    # Přidá objekt SectionZoomFrame
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1));
    # Formátování pro SectionZoomFrame
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
    # Uloží prezentaci
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Souhrnný zoom**

Souhrnný zoom je jako vstupní stránka, kde jsou všechny části vaší prezentace zobrazeny najednou. Když prezentujete, můžete pomocí zoomu přecházet z jednoho místa v prezentaci na jiné v libovolném pořadí. Můžete být kreativní, přeskočit dopředu nebo se vrátit k částem vašeho prezentace bez narušení toku prezentace.

![overview_image](sumzoomsel.png)

Pro objekty souhrnného zoomu Aspose.Slides poskytuje třídy [SummaryZoomFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/summaryzoomframe/), [SummaryZoomSection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/summaryzoomsection/) a [SummaryZoomSectionCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/summaryzoomsectioncollection/) a některé metody ve třídě [ShapeCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/) .

### **Vytvoření souhrnného zoomu**

Můžete přidat souhrnný zoomový rámeček na snímek následujícím způsobem:

1.	Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) .
2.	Vytvořte nové snímky s identifikačním pozadím a nové sekce pro vytvořené snímky.
3.	Přidejte souhrnný zoomový rámeček na první snímek.
4.	Uložte upravenou prezentaci jako soubor PPTX.

```php
  $pres = new Presentation();
  try {
    # Přidá nový snímek do prezentace
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Přidá novou sekci do prezentace
    $pres->getSections()->addSection("Section 1", $slide);
    # Přidá nový snímek do prezentace
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Přidá novou sekci do prezentace
    $pres->getSections()->addSection("Section 2", $slide);
    # Přidá nový snímek do prezentace
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->magenta);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Přidá novou sekci do prezentace
    $pres->getSections()->addSection("Section 3", $slide);
    # Přidá nový snímek do prezentace
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->green);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Přidá novou sekci do prezentace
    $pres->getSections()->addSection("Section 4", $slide);
    # Přidá objekt SummaryZoomFrame
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # Uloží prezentaci
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Přidání a odebrání sekce souhrnného zoomu**

Všechny sekce v souhrnném zoomovém rámečku jsou reprezentovány objekty [SummaryZoomSection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/summaryzoomsection/) , které jsou uloženy v objektu [SummaryZoomSectionCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/summaryzoomsectioncollection/) . Můžete přidat nebo odebrat objekt sekce souhrnného zoomu přes třídu [SummaryZoomSectionCollection] tímto způsobem:

1.	Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) .
2.	Vytvořte nové snímky s identifikačním pozadím a nové sekce pro vytvořené snímky.
3.	Přidejte souhrnný zoomový rámeček do prvního snímku.
4.	Přidejte nový snímek a sekci do prezentace.
5.	Přidejte vytvořenou sekci do souhrnného zoomového rámečku.
6.	Odeberte první sekci ze souhrnného zoomového rámečku.
7.	Uložte upravenou prezentaci jako soubor PPTX.

```php
  $pres = new Presentation();
  try {
    # Přidá nový snímek do prezentace
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Přidá novou sekci do prezentace
    $pres->getSections()->addSection("Section 1", $slide);
    # Přidá nový snímek do prezentace
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Přidá novou sekci do prezentace
    $pres->getSections()->addSection("Section 2", $slide);
    # Přidá objekt SummaryZoomFrame
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # Přidá nový snímek do prezentace
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->magenta);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Přidá novou sekci do prezentace
    $section3 = $pres->getSections()->addSection("Section 3", $slide);
    # Přidá sekci do Summary Zoomu
    $summaryZoomFrame->getSummaryZoomCollection()->addSummaryZoomSection($section3);
    # Odebere sekci ze Summary Zoomu
    $summaryZoomFrame->getSummaryZoomCollection()->removeSummaryZoomSection($pres->getSections()->get_Item(1));
    # Uloží prezentaci
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Formátování sekcí souhrnného zoomu**

Pro vytvoření složitějších objektů sekcí souhrnného zoomu musíte upravit formátování jednoduchého rámečku. Existuje několik možností formátování, které můžete použít na objekt sekce souhrnného zoomu. 

Můžete ovládat formátování objektu sekce souhrnného zoomu v souhrnném zoomovém rámečku tímto způsobem:

1.	Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) .
2.	Vytvořte nové snímky s identifikačním pozadím a nové sekce pro vytvořené snímky.
3.	Přidejte souhrnný zoomový rámeček na první snímek.
4.	Získejte objekt sekce souhrnného zoomu pro první objekt z `SummaryZoomSectionCollection`.
7.	Vytvořte objekt [PPImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ppimage/) přidáním obrázku do kolekce images přidružené k objektu [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) , který bude použit k vyplnění rámečku.
8.	Nastavte vlastní obrázek pro vytvořený objekt zoomu sekce.
9.	Nastavte možnost *návratu na původní snímek z propojené sekce*. 
11.	Změňte formát čáry pro druhý objekt zoomu.
12.	Změňte dobu trvání přechodu.
13.	Uložte upravenou prezentaci jako soubor PPTX.

```php
  $pres = new Presentation();
  try {
    # Přidá nový snímek do prezentace
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Přidá novou sekci do prezentace
    $pres->getSections()->addSection("Section 1", $slide);
    # Přidá nový snímek do prezentace
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Přidá novou sekci do prezentace
    $pres->getSections()->addSection("Section 2", $slide);
    # Přidá objekt SummaryZoomFrame
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # Získá první objekt SummaryZoomSection
    $summarySection = $summaryZoomFrame->getSummaryZoomCollection()->get_Item(0);
    # Formátování pro objekt SummaryZoomSection
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
    # Uloží prezentaci
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Mohu řídit návrat na nadřazený snímek po zobrazení cíle?**

Ano. Zoomový rámeček nebo sekce mají chování `ReturnToParent`, které při povolení po návštěvě cílového obsahu vrátí diváky zpět na výchozí snímek.

**Mohu upravit „rychlost“ nebo dobu trvání přechodu Zoomu?**

Ano. Zoom podporuje nastavení `TransitionDuration`, takže můžete řídit, jak dlouho trvá animace přechodu.

**Existují omezení počtu objektů Zoom, které může prezentace obsahovat?**

Neexistuje žádný striktní limit API, který by byl dokumentován. Praktická omezení závisí na celkové složitosti prezentace a výkonu prohlížeče. Můžete přidat mnoho zoomových rámečků, ale je třeba zvážit velikost souboru a dobu renderování.