---
title: Verwalten von Präsentationszoom in PHP
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
description: "Erstellen und anpassen von Zoom mit Aspose.Slides für PHP via Java — springen Sie zwischen Abschnitten, fügen Sie Miniaturbilder und Übergänge in PPT-, PPTX- und ODP-Präsentationen hinzu."
---

## **Übersicht**
Zooms in PowerPoint ermöglichen es Ihnen, zu bestimmten Folien, Abschnitten und Teilen einer Präsentation zu springen und von diesen zurückzukehren. Beim Vorführen kann diese Fähigkeit, schnell durch Inhalte zu navigieren, sehr nützlich sein. 

![overview_image](overview.png)

* Um eine gesamte Präsentation auf einer einzigen Folie zusammenzufassen, verwenden Sie einen [Zusammenfassungszoom](#Summary-Zoom).
* Um nur ausgewählte Folien anzuzeigen, verwenden Sie einen [Folienzoom](#Slide-Zoom).
* Um nur einen einzelnen Abschnitt anzuzeigen, verwenden Sie einen [Abschnittszoom](#Section-Zoom).

## **Folienzoom**
Ein Folienzoom kann Ihre Präsentation dynamischer machen, indem Sie frei zwischen Folien in beliebiger Reihenfolge navigieren können, ohne den Fluss Ihrer Präsentation zu unterbrechen. Folienzooms eignen sich gut für kurze Präsentationen ohne viele Abschnitte, können jedoch auch in anderen Präsentationsszenarien eingesetzt werden.

Folienzooms helfen Ihnen, mehrere Informationen zu vertiefen, während Sie das Gefühl haben, sich auf einer einzigen Leinwand zu befinden. 

![overview_image](slidezoomsel.png)

Für Folienzoom‑Objekte stellt Aspose.Slides die Aufzählung [ZoomImageType](https://reference.aspose.com/slides/php-java/aspose.slides/ZoomImageType), das Interface [IZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IZoomFrame) und einige Methoden des Interfaces [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) bereit.

### **Zoom‑Frames erstellen**

Sie können einem Folienzoom‑Frame wie folgt einen Zoom‑Frame hinzufügen:

1.	Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.
2.	Erstellen Sie neue Folien, zu denen Sie die Zoom‑Frames verlinken möchten. 
3.	Fügen Sie den erstellten Folien einen Identifikationstext und einen Hintergrund hinzu.
4.	Fügen Sie dem ersten Blatt Zoom‑Frames (die Verweise auf die erstellten Folien enthalten) hinzu.
5.	Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser PHP‑Code zeigt, wie Sie einen Zoom‑Frame auf einer Folie erstellen:
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
1.	Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.
2.	Erstellen Sie eine neue Folie, zu der Sie den Zoom‑Frame verlinken möchten. 
3.	Fügen Sie der Folie einen Identifikationstext und einen Hintergrund hinzu.
4.	Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage)-Objekt, indem Sie ein Bild zur Images‑Sammlung des zugehörigen [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Objekts hinzufügen, das den Rahmen füllen soll.
5.	Fügen Sie dem ersten Blatt Zoom‑Frames (die den Verweis auf die erstellte Folie enthalten) hinzu.
6.	Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser PHP‑Code zeigt, wie Sie einen Zoom‑Frame mit einem anderen Bild erstellen:
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
In den vorherigen Abschnitten haben wir gezeigt, wie einfache Zoom‑Frames erstellt werden. Für komplexere Zoom‑Frames müssen Sie die Formatierung eines einfachen Frames ändern. Es gibt mehrere Formatierungsoptionen, die Sie auf einen Zoom‑Frame anwenden können. 

Sie können die Formatierung eines Zoom‑Frames auf einer Folie wie folgt steuern:

1.	Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.
2.	Erstellen Sie neue Folien, zu denen Sie den Zoom‑Frame verlinken möchten. 
3.	Fügen Sie den erstellten Folien einen Identifikationstext und einen Hintergrund hinzu.
4.	Fügen Sie dem ersten Blatt Zoom‑Frames (die Verweise auf die erstellten Folien enthalten) hinzu.
5.	Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage)-Objekt, indem Sie ein Bild zur Images‑Sammlung des zugehörigen [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Objekts hinzufügen, das den Rahmen füllen soll.
6.	Setzen Sie ein benutzerdefiniertes Bild für das erste Zoom‑Frame‑Objekt.
7.	Ändern Sie das Linienformat für das zweite Zoom‑Frame‑Objekt.
8.	Entfernen Sie den Hintergrund eines Bildes des zweiten Zoom‑Frame‑Objekts.
5.	Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser PHP‑Code zeigt, wie Sie die Formatierung eines Zoom‑Frames auf einer Folie ändern:
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
    # Einstellung zum Nicht-Anzeigen des Hintergrunds für das zoomFrame2-Objekt
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

Ein Abschnittszoom ist ein Link zu einem Abschnitt Ihrer Präsentation. Sie können Abschnittszooms verwenden, um zu Abschnitten zurückzukehren, die Sie besonders betonen möchten. Oder Sie nutzen sie, um hervorzuheben, wie verschiedene Teile Ihrer Präsentation miteinander verknüpft sind. 

![overview_image](seczoomsel.png)

Für Abschnittszoom‑Objekte stellt Aspose.Slides das Interface [ISectionZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ISectionZoomFrame) und einige Methoden des Interfaces [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) bereit.

### **Abschnittszoom‑Frames erstellen**

Sie können einem Folienblatt einen Abschnittszoom‑Frame wie folgt hinzufügen:

1.	Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.
2.	Erstellen Sie ein neues Blatt. 
3.	Fügen Sie dem erstellten Blatt einen Identifikations‑Hintergrund hinzu.
4.	Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoom‑Frame verlinken möchten. 
5.	Fügen Sie dem ersten Blatt einen Abschnittszoom‑Frame (der Verweise auf den erstellten Abschnitt enthält) hinzu.
6.	Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser PHP‑Code zeigt, wie Sie einen Zoom‑Frame auf einer Folie erstellen:
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

1.	Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.
2.	Erstellen Sie ein neues Blatt.
3.	Fügen Sie dem erstellten Blatt einen Identifikations‑Hintergrund hinzu.
4.	Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoom‑Frame verlinken möchten. 
5.	Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage)-Objekt, indem Sie ein Bild zur Images‑Sammlung des zugehörigen [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Objekts hinzufügen, das den Rahmen füllen soll.
5.	Fügen Sie dem ersten Blatt einen Abschnittszoom‑Frame (der den Verweis auf den erstellten Abschnitt enthält) hinzu.
6.	Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser PHP‑Code zeigt, wie Sie einen Zoom‑Frame mit einem anderen Bild erstellen:
```php
  $pres = new Presentation();
  try {
    # Fügt neue Folie zur Präsentation hinzu
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
    # Fügt SectionZoomFrame-Objekt hinzu
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

1.	Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.
2.	Erstellen Sie ein neues Blatt.
3.	Fügen Sie dem Blatt einen Identifikations‑Hintergrund hinzu.
4.	Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoom‑Frame verlinken möchten. 
5.	Fügen Sie dem ersten Blatt einen Abschnittszoom‑Frame (der Verweise auf den erstellten Abschnitt enthält) hinzu.
6.	Ändern Sie Größe und Position des erstellten Abschnittszoom‑Objekts.
7.	Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage)-Objekt, indem Sie ein Bild zur Images‑Sammlung des zugehörigen [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Objekts hinzufügen, das den Rahmen füllen soll.
8.	Setzen Sie ein benutzerdefiniertes Bild für das erstellte Abschnittszoom‑Frame‑Objekt.
9.	Aktivieren Sie die *Rückkehr zur Originalfolie aus dem verlinkten Abschnitt*-Funktion. 
10.	Entfernen Sie den Hintergrund eines Bildes des Abschnittszoom‑Frames.
11.	Ändern Sie das Linienformat für das zweite Zoom‑Frame‑Objekt.
12.	Ändern Sie die Übergangsdauer.
13.	Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser PHP‑Code zeigt, wie Sie die Formatierung eines Abschnittszoom‑Frames ändern:
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
    # Fügt SectionZoomFrame-Objekt hinzu
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

Ein Zusammenfassungszoom ist wie eine Landing‑Page, auf der alle Teile Ihrer Präsentation gleichzeitig angezeigt werden. Beim Vorführen können Sie den Zoom nutzen, um von einer Stelle der Präsentation zu einer anderen in beliebiger Reihenfolge zu springen. Sie können kreativ sein, vorspringen oder Teile Ihrer Vorführung erneut ansehen, ohne den Fluss Ihrer Präsentation zu unterbrechen.

![overview_image](sumzoomsel.png)

Für Zusammenfassungszoom‑Objekte stellt Aspose.Slides die Interfaces [ISummaryZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomFrame), [ISummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSection) und [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSectionCollection) sowie einige Methoden des Interfaces [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) bereit.

### **Ein Zusammenfassungszoom erstellen**

Sie können einem Folienblatt einen Zusammenfassungszoom‑Frame wie folgt hinzufügen:

1.	Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.
2.	Erstellen Sie neue Folien mit Identifikations‑Hintergrund und neuen Abschnitten für die erstellten Folien.
3.	Fügen Sie dem ersten Blatt den Zusammenfassungszoom‑Frame hinzu.
4.	Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser PHP‑Code zeigt, wie Sie einen Zusammenfassungszoom‑Frame auf einer Folie erstellen:
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


### **Ein Zusammenfassungszoom‑Abschnitt hinzufügen und entfernen**

Alle Abschnitte in einem Zusammenfassungszoom‑Frame werden durch [ISummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSection)-Objekte repräsentiert, die im [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSectionCollection)-Objekt gespeichert sind. Sie können über das Interface [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSectionCollection) Abschnitte hinzufügen oder entfernen:

1.	Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.
2.	Erstellen Sie neue Folien mit Identifikations‑Hintergrund und neuen Abschnitten für die erstellten Folien.
3.	Fügen Sie dem ersten Blatt einen Zusammenfassungszoom‑Frame hinzu.
4.	Fügen Sie der Präsentation eine neue Folie und einen neuen Abschnitt hinzu.
5.	Fügen Sie den erstellten Abschnitt dem Zusammenfassungszoom‑Frame hinzu.
6.	Entfernen Sie den ersten Abschnitt aus dem Zusammenfassungszoom‑Frame.
7.	Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser PHP‑Code zeigt, wie Sie Abschnitte in einem Zusammenfassungszoom‑Frame hinzufügen und entfernen:
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
        # Entfernt Abschnitt aus dem Summary Zoom
        $summaryZoomFrame->getSummaryZoomCollection()->removeSummaryZoomSection($pres->getSections()->get_Item(1));
        # Speichert die Präsentation
        $pres->save("presentation.pptx", SaveFormat::Pptx);
    } finally {
        if (!java_is_null($pres)) {
            $pres->dispose();
        }
    }
```


### **Zusammenfassungszoom‑Abschnitte formatieren**

Um komplexere Zusammenfassungszoom‑Abschnittsobjekte zu erstellen, müssen Sie die Formatierung eines einfachen Frames ändern. Es gibt mehrere Formatierungsoptionen, die Sie auf ein Zusammenfassungszoom‑Abschnittsobjekt anwenden können. 

Sie können die Formatierung eines Zusammenfassungszoom‑Abschnittsobjekts in einem Zusammenfassungszoom‑Frame wie folgt steuern:

1.	Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.
2.	Erstellen Sie neue Folien mit Identifikations‑Hintergrund und neuen Abschnitten für die erstellten Folien.
3.	Fügen Sie dem ersten Blatt einen Zusammenfassungszoom‑Frame hinzu.
4.	Holen Sie ein Zusammenfassungszoom‑Abschnittsobjekt für das erste Objekt aus der `ISummaryZoomSectionCollection`.
7.	Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage)-Objekt, indem Sie ein Bild zur Images‑Sammlung des zugehörigen [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Objekts hinzufügen, das den Rahmen füllen soll.
8.	Setzen Sie ein benutzerdefiniertes Bild für das erstellte Abschnittszoom‑Frame‑Objekt.
9.	Aktivieren Sie die *Rückkehr zur Originalfolie aus dem verlinkten Abschnitt*-Funktion. 
11.	Ändern Sie das Linienformat für das zweite Zoom‑Frame‑Objekt.
12.	Ändern Sie die Übergangsdauer.
13.	Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser PHP‑Code zeigt, wie Sie die Formatierung eines Zusammenfassungszoom‑Abschnittsobjekts ändern:
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
    # Formatierung für das SummaryZoomSection-Objekt
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

**Kann ich die Rückkehr zur „Eltern‑“Folie nach der Anzeige des Ziels steuern?**

Ja. Der [Zoom frame](https://reference.aspose.com/slides/php-java/aspose.slides/zoomframe/) oder das [section](https://reference.aspose.com/slides/php-java/aspose.slides/sectionzoomframe/) hat ein `ReturnToParent`‑Verhalten, das bei Aktivierung die Betrachter nach dem Besuch des Zielinhalts zur Ausgangs‑Fol ie zurückschickt.

**Kann ich die „Geschwindigkeit“ bzw. Dauer des Zoom‑Übergangs anpassen?**

Ja. Zoom unterstützt das Festlegen einer `TransitionDuration`, sodass Sie die Dauer der Sprunganimation steuern können.

**Gibt es Beschränkungen, wie viele Zoom‑Objekte eine Präsentation enthalten kann?**

Es gibt kein fest kodiertes API‑Limit. Praktische Grenzen hängen von der Gesamtkomplexität der Präsentation und der Leistungsfähigkeit des Viewers ab. Sie können viele Zoom‑Frames hinzufügen, sollten jedoch Dateigröße und Render‑zeit berücksichtigen.