---
title: Präsentationszoom in PHP verwalten
linktitle: Zoom verwalten
type: docs
weight: 60
url: /de/php-java/manage-zoom/
keywords:
- Zoom
- Zoom-Frame
- Folienzoom
- Abschnittszoom
- Zusammenfassungszoom
- Zoom hinzufügen
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erstellen und anpassen von Zoom mit Aspose.Slides für PHP via Java — zwischen Abschnitten springen, Miniaturansichten und Übergänge in PPT-, PPTX- und ODP-Präsentationen hinzufügen."
---

## **Überblick**
Zooms in PowerPoint ermöglichen es Ihnen, zu bestimmten Folien, Abschnitten und Bereichen einer Präsentation zu springen und von dort zurückzukehren. Wenn Sie präsentieren, kann diese Möglichkeit, schnell durch Inhalte zu navigieren, sehr nützlich sein. 

![overview_image](overview.png)

* Um eine gesamte Präsentation auf einer einzigen Folie zusammenzufassen, verwenden Sie einen [Zusammenfassungszoom](#Summary-Zoom).
* Um nur ausgewählte Folien anzuzeigen, verwenden Sie einen [Folienzoom](#Slide-Zoom).
* Um nur einen einzelnen Abschnitt anzuzeigen, verwenden Sie einen [Abschnittszoom](#Section-Zoom).

## **Folienzoom**
Ein Folienzoom kann Ihre Präsentation dynamischer machen, indem er Ihnen erlaubt, frei zwischen Folien in beliebiger Reihenfolge zu navigieren, ohne den Fluss Ihrer Präsentation zu unterbrechen. Folienzooms eignen sich gut für kurze Präsentationen ohne viele Abschnitte, können aber auch in anderen Präsentationsszenarien verwendet werden.

Folienzooms helfen Ihnen, in mehrere Informationsstücke zu vertiefen, während Sie das Gefühl haben, sich auf einer einzigen Leinwand zu befinden. 

![overview_image](slidezoomsel.png)

Für Folienzoom‑Objekte stellt Aspose.Slides die Aufzählung [ZoomImageType](https://reference.aspose.com/slides/php-java/aspose.slides/zoomimagetype/), die Klasse [ZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/zoomframe/) und einige Methoden der Klasse [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/) bereit.

### **Zoom‑Frames erstellen**

Sie können einem Folien‑Zoom‑Frame wie folgt Folien hinzufügen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Klasse.
2. Erstellen Sie neue Folien, zu denen Sie die Zoom‑Frames verlinken möchten. 
3. Fügen Sie den erstellten Folien einen Identifikationstext und einen Hintergrund hinzu.
4.  Fügen Sie dem ersten Folien‑Zoom‑Frame (mit Verweisen auf die erstellten Folien) Zoom‑Frames hinzu.
5. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser PHP‑Code zeigt, wie ein Zoom‑Frame auf einer Folie erstellt wird:
```php
  $pres = new Presentation();
  try {
    # Fügt neue Folien zur Präsentation hinzu
    $slide2 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide3 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # Erstellt einen Hintergrund für die zweite Folie
    $slide2->getBackground()->setType(BackgroundType::OwnBackground);
    $slide2->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide2->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # Erstellt ein Textfeld für die zweite Folie
    $autoshape = $slide2->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # Erstellt einen Hintergrund für die dritte Folie
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # Erstellt ein Textfeld für die dritte Folie
    $autoshape = $slide3->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Trird Slide");
    # Fügt ZoomFrame-Objekte hinzu
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 250, 200, $slide2);
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(200, 250, 250, 200, $slide3);
    # Speichert die Präsentation
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Zoom‑Frames mit benutzerdefinierten Bildern erstellen**
Mit Aspose.Slides für PHP via Java können Sie einen Zoom‑Frame mit einem anderen Folien‑Vorschaubild wie folgt erstellen:
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Klasse.
2. Erstellen Sie eine neue Folie, zu der Sie den Zoom‑Frame verlinken möchten. 
3. Fügen Sie der Folie einen Identifikationstext und einen Hintergrund hinzu.
4.  Erstellen Sie ein [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/)-Objekt, indem Sie ein Bild zur Images‑Sammlung des mit der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Objekt verknüpften Präsentationsobjekts hinzufügen, das zum Befüllen des Frames verwendet wird.
5.  Fügen Sie dem ersten Folien‑Zoom‑Frame (mit Verweis auf die erstellte Folie) Zoom‑Frames hinzu.
6. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser PHP‑Code zeigt, wie ein Zoom‑Frame mit einem anderen Bild erstellt wird:
```php
  $pres = new Presentation();
  try {
    # Fügt eine neue Folie zur Präsentation hinzu
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # Erstellt einen Hintergrund für die zweite Folie
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # Erstellt ein Textfeld für die dritte Folie
    $autoshape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # Erstellt ein neues Bild für das Zoom-Objekt
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Fügt das ZoomFrame-Objekt hinzu
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 300, 200, $slide, $picture);
    # Speichert die Präsentation
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Zoom‑Frames formatieren**
In den vorherigen Abschnitten haben wir gezeigt, wie einfache Zoom‑Frames erstellt werden. Um komplexere Zoom‑Frames zu erstellen, müssen Sie die Formatierung eines einfachen Frames ändern. Es gibt mehrere Formatierungsoptionen, die Sie auf einen Zoom‑Frame anwenden können. 

Sie können die Formatierung eines Zoom‑Frames auf einer Folie wie folgt steuern:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Klasse.
2. Erstellen Sie neue Folien, zu denen Sie den Zoom‑Frame verlinken möchten. 
3. Fügen Sie den erstellten Folien etwas Identifikationstext und einen Hintergrund hinzu.
4.  Fügen Sie dem ersten Folien‑Zoom‑Frame (mit Verweisen auf die erstellten Folien) Zoom‑Frames hinzu.
5.  Erstellen Sie ein [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/)-Objekt, indem Sie ein Bild zur Images‑Sammlung des mit der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Objekt verknüpften Präsentationsobjekts hinzufügen, das zum Befüllen des Frames verwendet wird.
6.  Setzen Sie ein benutzerdefiniertes Bild für das erste Zoom‑Frame‑Objekt.
7.  Ändern Sie das Linienformat für das zweite Zoom‑Frame‑Objekt.
8.  Entfernen Sie den Hintergrund eines Bildes des zweiten Zoom‑Frame‑Objekts.
5. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser PHP‑Code zeigt, wie die Formatierung eines Zoom‑Frames auf einer Folie geändert wird:
```php
  $pres = new Presentation();
  try {
    # Fügt neue Folien zur Präsentation hinzu
    $slide2 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide3 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # Erstellt einen Hintergrund für die zweite Folie
    $slide2->getBackground()->setType(BackgroundType::OwnBackground);
    $slide2->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide2->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # Erstellt ein Textfeld für die zweite Folie
    $autoshape = $slide2->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # Erstellt einen Hintergrund für die dritte Folie
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # Erstellt ein Textfeld für die dritte Folie
    $autoshape = $slide3->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Trird Slide");
    # Fügt ZoomFrame-Objekte hinzu
    $zoomFrame1 = $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 250, 200, $slide2);
    $zoomFrame2 = $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(200, 250, 250, 200, $slide3);
    # Erstellt ein neues Bild für das Zoom-Objekt
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Setzt ein benutzerdefiniertes Bild für das zoomFrame1-Objekt
    $zoomFrame1->setImage($picture);
    # Setzt ein Zoom-Frame-Format für das zoomFrame2-Objekt
    $zoomFrame2->getLineFormat()->setWidth(5);
    $zoomFrame2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $zoomFrame2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->pink);
    $zoomFrame2->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    # Einstellung zum Ausblenden des Hintergrunds für das zoomFrame2-Objekt
    $zoomFrame2->setShowBackground(false);
    # Speichert die Präsentation
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Abschnittszoom**

Ein Abschnittszoom ist ein Link zu einem Abschnitt Ihrer Präsentation. Sie können Abschnittszooms verwenden, um zu Abschnitten zurückzukehren, die Sie besonders betonen möchten. Oder Sie nutzen sie, um zu verdeutlichen, wie bestimmte Teile Ihrer Präsentation miteinander verbunden sind. 

![overview_image](seczoomsel.png)

Für Abschnittszoom‑Objekte stellt Aspose.Slides die Klasse [SectionZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/sectionzoomframe/) und einige Methoden der Klasse [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/) bereit.

### **Abschnittszoom‑Frames erstellen**

Sie können einem Abschnittszoom‑Frame auf einer Folie wie folgt hinzufügen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Klasse.
2. Erstellen Sie eine neue Folie. 
3. Fügen Sie der erstellten Folie einen Identifikationshintergrund hinzu.
4.  Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoom‑Frame verlinken möchten. 
5.  Fügen Sie dem ersten Folien‑Zoom‑Frame (mit Verweisen auf den erstellten Abschnitt) einen Abschnittszoom‑Frame hinzu.
6. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser PHP‑Code zeigt, wie ein Zoom‑Frame auf einer Folie erstellt wird:
```php
  $pres = new Presentation();
  try {
    # Fügt eine neue Folie zur Präsentation hinzu
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Fügt einen neuen Abschnitt zur Präsentation hinzu
    $pres->getSections()->addSection("Section 1", $slide);
    # Fügt ein SectionZoomFrame-Objekt hinzu
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1));
    # Speichert die Präsentation
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Abschnittszoom‑Frames mit benutzerdefinierten Bildern erstellen**

Mit Aspose.Slides für PHP via Java können Sie einen Abschnittszoom‑Frame mit einem anderen Folien‑Vorschaubild wie folgt erstellen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Klasse.
2. Erstellen Sie eine neue Folie.
3. Fügen Sie der erstellten Folie einen Identifikationshintergrund hinzu.
4. Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoom‑Frame verlinken möchten. 
5.  Erstellen Sie ein [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/)-Objekt, indem Sie ein Bild zur Images‑Sammlung des mit der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Objekt verknüpften Präsentationsobjekts hinzufügen, das zum Befüllen des Frames verwendet wird.
5.  Fügen Sie dem ersten Folien‑Zoom‑Frame (mit Verweis auf den erstellten Abschnitt) einen Abschnittszoom‑Frame hinzu.
6. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser PHP‑Code zeigt, wie ein Zoom‑Frame mit einem anderen Bild erstellt wird:
```php
  $pres = new Presentation();
  try {
    # Fügt eine neue Folie zur Präsentation hinzu
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Fügt einen neuen Abschnitt zur Präsentation hinzu
    $pres->getSections()->addSection("Section 1", $slide);
    # Erstellt ein neues Bild für das Zoom-Objekt
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Fügt ein SectionZoomFrame-Objekt hinzu
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1), $picture);
    # Speichert die Präsentation
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Abschnittszoom‑Frames formatieren**

Um komplexere Abschnittszoom‑Frames zu erstellen, müssen Sie die Formatierung eines einfachen Frames ändern. Es gibt mehrere Formatierungsoptionen, die Sie auf einen Abschnittszoom‑Frame anwenden können. 

Sie können die Formatierung eines Abschnittszoom‑Frames auf einer Folie wie folgt steuern:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Klasse.
2. Erstellen Sie eine neue Folie.
3. Fügen Sie der erstellten Folie einen Identifikationshintergrund hinzu.
4. Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoom‑Frame verlinken möchten. 
5. Fügen Sie dem ersten Folien‑Zoom‑Frame (mit Verweisen auf den erstellten Abschnitt) einen Abschnittszoom‑Frame hinzu.
6. Ändern Sie Größe und Position des erstellten Abschnittszoom‑Objekts.
7. Erstellen Sie ein [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/)-Objekt, indem Sie ein Bild zur Images‑Sammlung des mit der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Objekt verknüpften Präsentationsobjekts hinzufügen, das zum Befüllen des Frames verwendet wird.
8. Setzen Sie ein benutzerdefiniertes Bild für das erstellte Abschnittszoom‑Frame‑Objekt.
9. Aktivieren Sie die *Rückkehr zur Ausgangs‑Folie aus dem verlinkten Abschnitt*‑Funktion. 
10. Entfernen Sie den Hintergrund eines Bildes des Abschnittszoom‑Frame‑Objekts.
11. Ändern Sie das Linienformat für das zweite Zoom‑Frame‑Objekt.
12. Ändern Sie die Übergangsdauer.
13. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser PHP‑Code zeigt, wie die Formatierung eines Abschnittszoom‑Frames geändert wird:
```php
  $pres = new Presentation();
  try {
    # Fügt eine neue Folie zur Präsentation hinzu
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Fügt einen neuen Abschnitt zur Präsentation hinzu
    $pres->getSections()->addSection("Section 1", $slide);
    # Fügt ein SectionZoomFrame-Objekt hinzu
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1));
    # Formatierung für SectionZoomFrame
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
    # Speichert die Präsentation
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```



## **Zusammenfassungszoom**

Ein Zusammenfassungszoom ist wie eine Landing‑Page, auf der alle Teile Ihrer Präsentation gleichzeitig angezeigt werden. Beim Präsentieren können Sie den Zoom verwenden, um von einer Stelle Ihrer Präsentation zu einer anderen in beliebiger Reihenfolge zu springen. Sie können kreativ sein, voraus springen oder Teile Ihrer Bilderschau erneut besuchen, ohne den Fluss Ihrer Präsentation zu unterbrechen.

![overview_image](sumzoomsel.png)

Für Zusammenfassungszoom‑Objekte stellt Aspose.Slides die Klassen [SummaryZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomframe/), [SummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomsection/) und [SummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomsectioncollection/) sowie einige Methoden der Klasse [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/) bereit.

### **Einen Zusammenfassungszoom erstellen**

Sie können einen Zusammenfassungszoom‑Frame auf einer Folie wie folgt hinzufügen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Klasse.
2. Erstellen Sie neue Folien mit Identifikationshintergrund und neuen Abschnitten für die erstellten Folien.
3.  Fügen Sie dem ersten Folien‑Zoom‑Frame den Zusammenfassungszoom‑Frame hinzu.
4. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser PHP‑Code zeigt, wie ein Zusammenfassungszoom‑Frame auf einer Folie erstellt wird:
```php
  $pres = new Presentation();
  try {
    # Fügt eine neue Folie zur Präsentation hinzu
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Fügt einen neuen Abschnitt zur Präsentation hinzu
    $pres->getSections()->addSection("Section 1", $slide);
    # Fügt eine neue Folie zur Präsentation hinzu
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Fügt einen neuen Abschnitt zur Präsentation hinzu
    $pres->getSections()->addSection("Section 2", $slide);
    # Fügt eine neue Folie zur Präsentation hinzu
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->magenta);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Fügt einen neuen Abschnitt zur Präsentation hinzu
    $pres->getSections()->addSection("Section 3", $slide);
    # Fügt eine neue Folie zur Präsentation hinzu
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->green);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Fügt einen neuen Abschnitt zur Präsentation hinzu
    $pres->getSections()->addSection("Section 4", $slide);
    # Fügt ein SummaryZoomFrame-Objekt hinzu
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # Speichert die Präsentation
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **Eine Zusammenfassungszoom‑Section hinzufügen und entfernen**

Alle Sections in einem Zusammenfassungszoom‑Frame werden durch [SummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomsection/)-Objekte repräsentiert, die im [SummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomsectioncollection/)-Objekt gespeichert sind. Sie können über die Klasse [SummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomsectioncollection/) ein SummaryZoomSection‑Objekt hinzufügen oder entfernen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Klasse.
2. Erstellen Sie neue Folien mit Identifikationshintergrund und neuen Abschnitten für die erstellten Folien.
3.  Fügen Sie dem ersten Folien‑Zoom‑Frame den Zusammenfassungszoom‑Frame hinzu.
4.  Fügen Sie der Präsentation eine neue Folie und einen neuen Abschnitt hinzu.
5.  Fügen Sie den erstellten Abschnitt zum Zusammenfassungszoom‑Frame hinzu.
6.  Entfernen Sie die erste Section aus dem Zusammenfassungszoom‑Frame.
7. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser PHP‑Code zeigt, wie Sections in einem Zusammenfassungszoom‑Frame hinzugefügt und entfernt werden:
```php
  $pres = new Presentation();
  try {
    # Fügt eine neue Folie zur Präsentation hinzu
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Fügt einen neuen Abschnitt zur Präsentation hinzu
    $pres->getSections()->addSection("Section 1", $slide);
    # Fügt eine neue Folie zur Präsentation hinzu
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Fügt einen neuen Abschnitt zur Präsentation hinzu
    $pres->getSections()->addSection("Section 2", $slide);
    # Fügt ein SummaryZoomFrame-Objekt hinzu
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # Fügt eine neue Folie zur Präsentation hinzu
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->magenta);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Fügt einen neuen Abschnitt zur Präsentation hinzu
    $section3 = $pres->getSections()->addSection("Section 3", $slide);
    # Fügt einen Abschnitt zum Summary Zoom hinzu
    $summaryZoomFrame->getSummaryZoomCollection()->addSummaryZoomSection($section3);
    # Entfernt einen Abschnitt aus dem Summary Zoom
    $summaryZoomFrame->getSummaryZoomCollection()->removeSummaryZoomSection($pres->getSections()->get_Item(1));
    # Speichert die Präsentation
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **Zusammenfassungszoom‑Sections formatieren**

Um komplexere Zusammenfassungszoom‑Section‑Objekte zu erstellen, müssen Sie die Formatierung eines einfachen Frames ändern. Es gibt mehrere Formatierungsoptionen, die Sie auf ein Zusammenfassungszoom‑Section‑Objekt anwenden können. 

Sie können die Formatierung eines Zusammenfassungszoom‑Section‑Objekts in einem Zusammenfassungszoom‑Frame wie folgt steuern:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Klasse.
2. Erstellen Sie neue Folien mit Identifikationshintergrund und neuen Abschnitten für die erstellten Folien.
3.  Fügen Sie dem ersten Folien‑Zoom‑Frame den Zusammenfassungszoom‑Frame hinzu.
4.  Rufen Sie ein SummaryZoomSection‑Objekt für das erste Objekt aus der `SummaryZoomSectionCollection` ab.
7.  Erstellen Sie ein [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/)-Objekt, indem Sie ein Bild zur Images‑Sammlung des mit der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Objekt verknüpften Präsentationsobjekts hinzufügen, das zum Befüllen des Frames verwendet wird.
8.  Setzen Sie ein benutzerdefiniertes Bild für das erstellte Section‑Zoom‑Frame‑Objekt.
9.  Aktivieren Sie die *Rückkehr zur Ausgangs‑Folie aus dem verlinkten Abschnitt*‑Funktion. 
11. Ändern Sie das Linienformat für das zweite Zoom‑Frame‑Objekt.
12. Ändern Sie die Übergangsdauer.
13. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser PHP‑Code zeigt, wie die Formatierung eines SummaryZoomSection‑Objekts geändert wird:
```php
  $pres = new Presentation();
  try {
    # Fügt eine neue Folie zur Präsentation hinzu
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Fügt einen neuen Abschnitt zur Präsentation hinzu
    $pres->getSections()->addSection("Section 1", $slide);
    # Fügt eine neue Folie zur Präsentation hinzu
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Fügt einen neuen Abschnitt zur Präsentation hinzu
    $pres->getSections()->addSection("Section 2", $slide);
    # Fügt ein SummaryZoomFrame-Objekt hinzu
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # Holt das erste SummaryZoomSection-Objekt
    $summarySection = $summaryZoomFrame->getSummaryZoomCollection()->get_Item(0);
    # Formatierung für SummaryZoomSection-Objekt
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
    # Speichert die Präsentation
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Kann ich die Rückkehr zur „Eltern‑“Folie nach Anzeige des Ziels steuern?**

Ja. Der [Zoom frame](https://reference.aspose.com/slides/php-java/aspose.slides/zoomframe/) bzw. das [section](https://reference.aspose.com/slides/php-java/aspose.slides/sectionzoomframe/) verfügt über das Verhalten `ReturnToParent`, das, wenn aktiviert, die Betrachter nach dem Besuch des Zielinhalts zurück zur Ausgangsfolie sendet.

**Kann ich die „Geschwindigkeit“ bzw. Dauer der Zoom‑Übergänge anpassen?**

Ja. Zoom unterstützt das Festlegen einer `TransitionDuration`, sodass Sie die Dauer der Sprunganimation steuern können.

**Gibt es Begrenzungen, wie viele Zoom‑Objekte eine Präsentation enthalten kann?**

Es gibt keine hartcodierte API‑Grenze laut Dokumentation. Praktische Beschränkungen hängen von der Gesamtkomplexität der Präsentation und der Leistung des Viewers ab. Sie können viele Zoom‑Frames hinzufügen, sollten jedoch Dateigröße und Renderzeit berücksichtigen.