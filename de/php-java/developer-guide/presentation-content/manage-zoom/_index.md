---
title: Zoom verwalten
type: docs
weight: 60
url: /de/php-java/manage-zoom/
keywords: "Zoom, Zoom-Frame, Zoom hinzufügen, Zoom-Frame formatieren, Zusammenfassungszoom, PowerPoint-Präsentation, Java, Aspose.Slides für PHP über Java"
description: "Fügen Sie Zoom oder Zoom-Frames zu PowerPoint-Präsentationen hinzu"
---

## **Übersicht**
Zooms in PowerPoint ermöglichen es Ihnen, zu bestimmten Folien, Abschnitten und Teilen einer Präsentation zu springen und zurück. Wenn Sie präsentieren, kann diese Möglichkeit, schnell durch Inhalte zu navigieren, sehr nützlich sein.

![übersicht_image](overview.png)

* Um eine gesamte Präsentation auf einer einzigen Folie zusammenzufassen, verwenden Sie einen [Zusammenfassungszoom](#Zusammenfassungszoom).
* Um nur ausgewählte Folien anzuzeigen, verwenden Sie einen [Folienzoom](#Folienzoom).
* Um nur einen einzigen Abschnitt anzuzeigen, verwenden Sie einen [Abschnittszoom](#Abschnittszoom).

## **Folienzoom**
Ein Folienzoom kann Ihre Präsentation dynamischer gestalten, da Sie frei zwischen Folien in beliebiger Reihenfolge navigieren können, ohne den Fluss Ihrer Präsentation zu unterbrechen. Folienzooms sind ideal für kurze Präsentationen ohne viele Abschnitte, können jedoch auch in verschiedenen Präsentationsszenarien verwendet werden.

Folienzooms helfen Ihnen, in mehrere Informationen einzutauchen, während Sie das Gefühl haben, auf einer einzigen Leinwand zu sein.

![übersicht_image](slidezoomsel.png)

Für Folienzoom-Objekte bietet Aspose.Slides die [ZoomImageType](https://reference.aspose.com/slides/php-java/aspose.slides/ZoomImageType)-Enumeration, das [IZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IZoomFrame)-Interface und einige Methoden im [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection)-Interface an.

### **Erstellen von Zoom-Frames**

Sie können einen Zoom-Frame auf einer Folie folgendermaßen hinzufügen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.
2. Erstellen Sie neue Folien, zu denen Sie die Zoom-Frames verlinken möchten. 
3. Fügen Sie den erstellten Folien einen Identifikationstext und einen Hintergrund hinzu.
4. Fügen Sie Zoom-Frames (die Verweise auf die erstellten Folien enthalten) zur ersten Folie hinzu.
5. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser PHP-Code zeigt Ihnen, wie Sie einen Zoom-Frame auf einer Folie erstellen:

```php
  $pres = new Presentation();
  try {
    # Fügt der Präsentation neue Folien hinzu
    $slide2 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide3 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # Erstellt einen Hintergrund für die zweite Folie
    $slide2->getBackground()->setType(BackgroundType::OwnBackground);
    $slide2->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide2->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # Erstellt ein Textfeld für die zweite Folie
    $autoshape = $slide2->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Zweite Folie");
    # Erstellt einen Hintergrund für die dritte Folie
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # Erstellt ein Textfeld für die dritte Folie
    $autoshape = $slide3->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Dritte Folie");
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
### **Erstellen von Zoom-Frames mit benutzerdefinierten Bildern**
Mit Aspose.Slides für PHP über Java können Sie einen Zoom-Frame mit einem anderen Folienvorschau-Bild folgendermaßen erstellen:
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.
2. Erstellen Sie eine neue Folie, zu der Sie den Zoom-Frame verlinken möchten. 
3. Fügen Sie der Folie einen Identifikationstext und einen Hintergrund hinzu.
4. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage)-Objekt, indem Sie ein Bild zur Bildersammlung hinzufügen, die mit dem [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Objekt verknüpft ist, das verwendet wird, um den Frame zu füllen.
5. Fügen Sie Zoom-Frames (die einen Verweis auf die erstellte Folie enthalten) zur ersten Folie hinzu.
6. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser PHP-Code zeigt Ihnen, wie Sie einen Zoom-Frame mit einem anderen Bild erstellen:

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
    $autoshape->getTextFrame()->setText("Zweite Folie");
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
### **Formatierung von Zoom-Frames**
In den vorherigen Abschnitten haben wir Ihnen gezeigt, wie Sie einfache Zoom-Frames erstellen. Um kompliziertere Zoom-Frames zu erstellen, müssen Sie das Format eines einfachen Frames ändern. Es gibt mehrere Formatierungsoptionen, die Sie auf einen Zoom-Frame anwenden können.

Sie können das Format eines Zoom-Frames auf einer Folie folgendermaßen steuern:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.
2. Erstellen Sie neue Folien, zu denen Sie den Zoom-Frame verlinken möchten. 
3. Fügen Sie den erstellten Folien einige Identifikationstexte und Hintergründe hinzu.
4. Fügen Sie Zoom-Frames (die die Verweise auf die erstellten Folien enthalten) zur ersten Folie hinzu.
5. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage)-Objekt, indem Sie ein Bild zur Bildersammlung hinzufügen, die mit dem [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Objekt verknüpft ist, das verwendet wird, um den Frame zu füllen.
6. Setzen Sie ein benutzerdefiniertes Bild für das erste Zoom-Frame-Objekt.
7. Ändern Sie das Linienformat für das zweite Zoom-Frame-Objekt.
8. Entfernen Sie den Hintergrund von einem Bild des zweiten Zoom-Frame-Objekts.
5. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser PHP-Code zeigt Ihnen, wie Sie das Format eines Zoom-Frames auf einer Folie ändern können:

```php
  $pres = new Presentation();
  try {
    # Fügt der Präsentation neue Folien hinzu
    $slide2 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide3 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # Erstellt einen Hintergrund für die zweite Folie
    $slide2->getBackground()->setType(BackgroundType::OwnBackground);
    $slide2->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide2->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # Erstellt ein Textfeld für die zweite Folie
    $autoshape = $slide2->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Zweite Folie");
    # Erstellt einen Hintergrund für die dritte Folie
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # Erstellt ein Textfeld für die dritte Folie
    $autoshape = $slide3->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Dritte Folie");
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
    # Einstellung, um den Hintergrund für das zoomFrame2-Objekt nicht anzuzeigen
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

Ein Abschnittszoom ist ein Link zu einem Abschnitt in Ihrer Präsentation. Sie können Abschnittszooms verwenden, um zu Abschnitten zurückzukehren, die Sie wirklich betonen möchten. Oder Sie können sie verwenden, um zu zeigen, wie bestimmte Teile Ihrer Präsentation miteinander verknüpft sind.

![übersicht_image](seczoomsel.png)

Für Abschnittszoom-Objekte bietet Aspose.Slides das [ISectionZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ISectionZoomFrame)-Interface und einige Methoden im [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection)-Interface.

### **Erstellen von Abschnittszoom-Frames**

Sie können einen Abschnittszoom-Frame folgendermaßen zu einer Folie hinzufügen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.
2. Erstellen Sie eine neue Folie. 
3. Fügen Sie der erstellten Folie einen Identifikationshintergrund hinzu.
4. Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoom-Frame verlinken möchten. 
5. Fügen Sie einen Abschnittszoom-Frame (der Verweise auf den erstellten Abschnitt enthält) zur ersten Folie hinzu.
6. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser PHP-Code zeigt Ihnen, wie Sie einen Zoom-Frame auf einer Folie erstellen:

```php
  $pres = new Presentation();
  try {
    # Fügt eine neue Folie zur Präsentation hinzu
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Fügt einen neuen Abschnitt zur Präsentation hinzu
    $pres->getSections()->addSection("Abschnitt 1", $slide);
    # Fügt ein AbschnittsZoomFrame-Objekt hinzu
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1));
    # Speichert die Präsentation
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **Erstellen von Abschnittszoom-Frames mit benutzerdefinierten Bildern**

Mit Aspose.Slides für PHP über Java können Sie einen Abschnittszoom-Frame mit einem anderen Folienvorschau-Bild folgendermaßen erstellen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.
2. Erstellen Sie eine neue Folie.
3. Fügen Sie der erstellten Folie einen Identifikationshintergrund hinzu.
4. Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoom-Frame verlinken möchten. 
5. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage)-Objekt, indem Sie ein Bild zur Bildersammlung hinzufügen, die mit dem [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Objekt verknüpft ist, das verwendet wird, um den Frame zu füllen.
5. Fügen Sie einen Abschnittszoom-Frame (der einen Verweis auf den erstellten Abschnitt enthält) zur ersten Folie hinzu.
6. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser PHP-Code zeigt Ihnen, wie Sie einen Zoom-Frame mit einem anderen Bild erstellen:

```php
  $pres = new Presentation();
  try {
    # Fügt eine neue Folie zur Präsentation hinzu
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Fügt einen neuen Abschnitt zur Präsentation hinzu
    $pres->getSections()->addSection("Abschnitt 1", $slide);
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
    # Fügt ein AbschnittsZoomFrame-Objekt hinzu
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
### **Formatierung von Abschnittszoom-Frames**

Um kompliziertere Abschnittszoom-Frames zu erstellen, müssen Sie das Format eines einfachen Frames ändern. Es gibt mehrere Formatierungsoptionen, die Sie auf einen Abschnittszoom-Frame anwenden können.

Sie können das Format eines Abschnittszoom-Frames auf einer Folie folgendermaßen steuern:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.
2. Erstellen Sie eine neue Folie.
3. Fügen Sie der erstellten Folie einen Identifikationshintergrund hinzu.
4. Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoom-Frame verlinken möchten. 
5. Fügen Sie einen Abschnittszoom-Frame (der Verweise auf den erstellten Abschnitt enthält) zur ersten Folie hinzu.
6. Ändern Sie die Größe und die Position des erstellten Abschnittszoom-Objekts.
7. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage)-Objekt, indem Sie ein Bild zur Bildersammlung hinzufügen, die mit dem [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Objekt verknüpft ist, das verwendet wird, um den Frame zu füllen.
8. Setzen Sie ein benutzerdefiniertes Bild für das erstellte Abschnittszoom-Frame-Objekt.
9. Setzen Sie die Fähigkeit, *zum ursprünglichen Slide von dem verlinkten Abschnitt zurückzukehren*. 
10. Entfernen Sie den Hintergrund von einem Bild des Abschnittszoom-Frame-Objekts.
11. Ändern Sie das Linienformat des zweiten Zoom-Frame-Objekts.
12. Ändern Sie die Übergangszeit.
13. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser PHP-Code zeigt Ihnen, wie Sie das Format eines Abschnittszoom-Frames ändern können:

```php
  $pres = new Presentation();
  try {
    # Fügt eine neue Folie zur Präsentation hinzu
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Fügt einen neuen Abschnitt zur Präsentation hinzu
    $pres->getSections()->addSection("Abschnitt 1", $slide);
    # Fügt ein AbschnittsZoomFrame-Objekt hinzu
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1));
    # Formatierung für AbschnittsZoomFrame
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

Ein Zusammenfassungszoom ist wie eine Landingpage, auf der alle Teile Ihrer Präsentation gleichzeitig angezeigt werden. Wenn Sie präsentieren, können Sie mit dem Zoom von einem Ort in Ihrer Präsentation zu einem anderen in beliebiger Reihenfolge wechseln. Sie können kreativ werden, vorspulen oder Teile Ihrer Diashow wieder besuchen, ohne den Fluss Ihrer Präsentation zu unterbrechen.

![übersicht_image](sumzoomsel.png)

Für Zusammenfassungszoom-Objekte bietet Aspose.Slides die [ISummaryZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomFrame), [ISummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSection) und [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSectionCollection)-Interfaces sowie einige Methoden im [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection)-Interface.

### **Erstellen von Zusammenfassungszooms**

Sie können einen Zusammenfassungszoom-Frame folgendermaßen zu einer Folie hinzufügen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.
2. Erstellen Sie neue Folien mit Identifikationshintergrund und neuen Abschnitten für die erstellten Folien.
3. Fügen Sie den Zusammenfassungszoom-Frame zur ersten Folie hinzu.
4. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser PHP-Code zeigt Ihnen, wie Sie einen Zusammenfassungszoom-Frame auf einer Folie erstellen:

```php
  $pres = new Presentation();
  try {
    # Fügt eine neue Folie zur Präsentation hinzu
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Fügt einen neuen Abschnitt zur Präsentation hinzu
    $pres->getSections()->addSection("Abschnitt 1", $slide);
    # Fügt eine neue Folie zur Präsentation hinzu
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Fügt einen neuen Abschnitt zur Präsentation hinzu
    $pres->getSections()->addSection("Abschnitt 2", $slide);
    # Fügt eine neue Folie zur Präsentation hinzu
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->magenta);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Fügt einen neuen Abschnitt zur Präsentation hinzu
    $pres->getSections()->addSection("Abschnitt 3", $slide);
    # Fügt eine neue Folie zur Präsentation hinzu
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->green);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Fügt einen neuen Abschnitt zur Präsentation hinzu
    $pres->getSections()->addSection("Abschnitt 4", $slide);
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

### **Hinzufügen und Entfernen von Zusammenfassungszoom-Abschnitten**

Alle Abschnitte in einem Zusammenfassungszoom-Frame werden durch [ISummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSection)-Objekte dargestellt, die im [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSectionCollection)-Objekt gespeichert sind. Sie können ein Zusammenfassungszoom-Abschnittsobjekt über das [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSectionCollection)-Interface folgendermaßen hinzufügen oder entfernen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.
2. Erstellen Sie neue Folien mit Identifikationshintergrund und neuen Abschnitten für die erstellten Folien.
3. Fügen Sie einen Zusammenfassungszoom-Frame zur ersten Folie hinzu.
4. Fügen Sie eine neue Folie und einen Abschnitt zur Präsentation hinzu.
5. Fügen Sie den erstellten Abschnitt zum Zusammenfassungszoom-Frame hinzu.
6. Entfernen Sie den ersten Abschnitt aus dem Zusammenfassungszoom-Frame.
7. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser PHP-Code zeigt Ihnen, wie Sie Abschnitte in einem Zusammenfassungszoom-Frame hinzufügen und entfernen:

```php
  $pres = new Presentation();
  try {
    # Fügt eine neue Folie zur Präsentation hinzu
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Fügt einen neuen Abschnitt zur Präsentation hinzu
    $pres->getSections()->addSection("Abschnitt 1", $slide);
    # Fügt eine neue Folie zur Präsentation hinzu
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Fügt einen neuen Abschnitt zur Präsentation hinzu
    $pres->getSections()->addSection("Abschnitt 2", $slide);
    # Fügt ein SummaryZoomFrame-Objekt hinzu
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # Fügt eine neue Folie zur Präsentation hinzu
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->magenta);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Fügt einen neuen Abschnitt zur Präsentation hinzu
    $section3 = $pres->getSections()->addSection("Abschnitt 3", $slide);
    # Fügt einen Abschnitt zum Zusammenfassungszoom hinzu
    $summaryZoomFrame->getSummaryZoomCollection()->addSummaryZoomSection($section3);
    # Entfernt den Abschnitt vom Zusammenfassungszoom
    $summaryZoomFrame->getSummaryZoomCollection()->removeSummaryZoomSection($pres->getSections()->get_Item(1));
    # Speichert die Präsentation
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Formatierung von Zusammenfassungszoom-Abschnitten**

Um kompliziertere Zusammenfassungszoom-Abschnittsobjekte zu erstellen, müssen Sie das Format eines einfachen Frames ändern. Es gibt mehrere Formatierungsoptionen, die Sie auf ein Zusammenfassungszoom-Abschnittsobjekt anwenden können.

Sie können das Format für ein Zusammenfassungszoom-Abschnittsobjekt in einem Zusammenfassungszoom-Frame folgendermaßen steuern:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.
2. Erstellen Sie neue Folien mit Identifikationshintergrund und neuen Abschnitten für die erstellten Folien.
3. Fügen Sie einen Zusammenfassungszoom-Frame zur ersten Folie hinzu.
4. Holen Sie sich ein Zusammenfassungszoom-Abschnittsobjekt für das erste Objekt aus der `ISummaryZoomSectionCollection`.
5. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage)-Objekt, indem Sie ein Bild zur Bildersammlung hinzufügen, die mit dem [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Objekt verknüpft ist, das verwendet wird, um den Frame zu füllen.
6. Setzen Sie ein benutzerdefiniertes Bild für das erstellte Abschnittszoom-Frame-Objekt.
7. Setzen Sie die Fähigkeit, *zum ursprünglichen Slide von dem verlinkten Abschnitt zurückzukehren*. 
8. Ändern Sie das Linienformat des zweiten Zoom-Frame-Objekts.
9. Ändern Sie die Übergangszeit.
10. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser PHP-Code zeigt Ihnen, wie Sie die Formatierung für ein Zusammenfassungszoom-Abschnittsobjekt ändern können:

```php
  $pres = new Presentation();
  try {
    # Fügt eine neue Folie zur Präsentation hinzu
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Fügt einen neuen Abschnitt zur Präsentation hinzu
    $pres->getSections()->addSection("Abschnitt 1", $slide);
    # Fügt eine neue Folie zur Präsentation hinzu
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Fügt einen neuen Abschnitt zur Präsentation hinzu
    $pres->getSections()->addSection("Abschnitt 2", $slide);
    # Fügt ein SummaryZoomFrame-Objekt hinzu
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # Holt sich das erste SummaryZoomSection-Objekt
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