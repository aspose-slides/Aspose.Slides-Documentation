---
title: Öffentliches API und nicht rückwärtskompatible Änderungen in Aspose.Slides für PHP über Java 14.5.0
type: docs
weight: 40
url: /de/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügten](/slides/de/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) Klassen, Methoden, Eigenschaften usw., alle neuen [Einschränkungen](/slides/de/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) und andere [Änderungen](/slides/de/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) auf, die mit dem Aspose.Slides für PHP über Java 14.5.0 API eingeführt wurden.

{{% /alert %}} 
## **Öffentliches API und nicht rückwärtskompatible Änderungen**
### **Hinzugefügte Klassen und Methoden**
#### **Die Aspose.Slides.IPresentationInfo-Schnittstelle und die PresentationInfo-Klassen hinzugefügt**
Repräsentiert Informationen über die Präsentation.

Die Methode Boolean isEncrypted() gibt True zurück, wenn eine Präsentation verschlüsselt ist, andernfalls False.

Die Methode LoadFormat getLoadFormat() gibt den Präsentationstyp zurück.
#### **Die Methode Aspose.Slides.IShape.isGrouped() hinzugefügt**
Die Methode Aspose.Slides.IShape.isGrouped() bestimmt, ob die Form gruppiert ist.
#### **Die Methode Aspose.Slides.IShape.getParentGroup() hinzugefügt**
Die Methode Aspose.Slides.IShape.getParentGroup() gibt das übergeordnete GroupShape-Objekt zurück, wenn die Form gruppiert ist. Andernfalls gibt sie null zurück.
#### **Die Methode Aspose.Slides.IShapeCollection.addGroupShape() hinzugefügt**
Die Methode Aspose.Slides.IShapeCollection.addGroupShape() erstellt ein neues GroupShape und fügt es am Ende der Sammlung hinzu.

Die Größe und Position des GroupShape-Rahmens wird an den Inhalt angepasst, wenn eine neue Form zum GroupShape hinzugefügt wird.
#### **Die Methode Aspose.Slides.IShapeCollection.clear() hinzugefügt**
Die Methode Aspose.Slides.IShapeCollection.clear() entfernt alle Formen aus der Sammlung.
#### **Die Methode Aspose.Slides.IShapeCollection.insertGroupShape(int) hinzugefügt**
Die Methode Aspose.Slides.IShapeCollection.insertGroupShape(int) erstellt ein neues GroupShape und fügt es an der angegebenen Stelle in die Sammlung ein.
Die Größe und Position des GroupShape-Rahmens wird an den Inhalt angepasst, wenn eine neue Form zum GroupShape hinzugefügt wird.
#### **Die Methoden IPresentationFactory.getPresentationInfo(string file), IPresentationFactory.getPresentationInfo(InputStream stream) hinzugefügt**
Diese Methoden erlauben es Entwicklern, Informationen über eine Präsentationsdatei/-stream zu erhalten, ohne die vollständige Präsentation zu laden.
#### **Die Methode IPresentationFactory PresentationFactory.getInstance() hinzugefügt**
Ermöglicht die Nutzung der Fabrikfunktionalität ohne Instanziierung.
### **Einschränkungen**
#### **Einschränkungen wurden für die Verwendung undefinierter Werte für IShape.getFrame() hinzugefügt**
Code, der versucht, einen undefinierten Rahmen an IShape.setFrame(IShapeFrame) zuzuweisen, macht in allgemeinen Fällen (insbesondere wenn das übergeordnete GroupShape mehrstufig in andere {{GroupShape}}s verschachtelt ist) keinen Sinn. Zum Beispiel:

```php
  $shape = $$missing$;
  $shape->setFrame(new ShapeFrame(Float::NaN, Float::NaN, Float::NaN, Float::NaN, NullableBool::NotDefined, NullableBool::NotDefined, Float::NaN));

```

oder

```php
  slide.Shapes->AddAutoShape(ShapeType::RoundCornerRectangle, Float::NaN, Float::NaN, Float::NaN, Float::NaN);

```

Solcher Code kann zu unklaren Situationen führen. Daher wurden Einschränkungen für die Verwendung undefinierter Werte für IShape.Frame hinzugefügt. Die Werte von x, y, width, height, flipH, flipV und rotationAngle müssen definiert sein (nicht Float.NaN oder NullableBool.NotDefined). Der obige Beispielcode wirft jetzt eine ArgumentException.

Dies gilt für diese Anwendungsfälle:

```php
  $shape = $$missing$;
  $shape->setFrame();// kann nicht undefiniert sein

  $shapes = $$missing$;
  # x, y, width, height Parameter können nicht Float.NaN sein:
  {
    $shapes->addAudioFrameCD();
    $shapes->addAudioFrameEmbedded();
    $shapes->addAudioFrameLinked();
    $shapes->addAutoShape();
    $shapes->addChart();
    $shapes->addConnector();
    $shapes->addOleObjectFrame();
    $shapes->addPictureFrame();
    $shapes->addSmartArt();
    $shapes->addTable();
    $shapes->addVideoFrame();
    $shapes->insertAudioFrameEmbedded();
    $shapes->insertAudioFrameLinked();
    $shapes->insertAutoShape();
    $shapes->insertChart();
    $shapes->insertConnector();
    $shapes->insertOleObjectFrame();
    $shapes->insertPictureFrame();
    $shapes->insertTable();
    $shapes->insertVideoFrame();
  }
```

Aber der IShape.getRawFrame() Rahmen kann undefiniert sein. Dies macht Sinn, wenn eine Form mit einem Platzhalter verknüpft ist. Dann werden undefinierte Rahmenwerte von der übergeordneten Platzhalterschnittstelle überschrieben. Wenn es keinen übergeordneten Platzhalter für diese Form gibt, verwendet sie Standardwerte, wenn sie den effektiven Rahmen basierend auf ihrem IShape.getRawFrame() bestimmt. Standardwerte sind 0 und NullableBool.False für x, y, width, height, flipH, flipV und rotationAngle. Zum Beispiel:

```php
  $shape = $$missing$;// Form ist mit Platzhalter verknüpft

  $shape->setRawFrame(new ShapeFrame(Float::NaN, Float::NaN, 100, Float::NaN, NullableBool::NotDefined, NullableBool::NotDefined, 0));
  # Jetzt erbt die Form x, y, höhe, flipH, flipV Werte vom Platzhalter und überschreibt width=100 und rotationAngle=0.

```
### **Geänderte Eigenschaften**
#### **Typ und Name der Methode Aspose.Slides.IShapeCollection.getParent() geändert**
Der Typ der Eigenschaft Aspose.Slides.IShapeCollection.Parent wurde von ISlideComponent auf die neue IGroupShape-Schnittstelle geändert. Die IGroupShape-Schnittstelle ist ein Nachkomme von ISlideComponent, sodass vorhandener Code keine Anpassung benötigt.

Der Name der Methode Aspose.Slides.IShapeCollection.getParent() wurde von getParent in getParentGroup() geändert.
#### **Typ der Methoden Aspose.Slides.IShapeFrame.getFlipH() und .getFlipV() geändert**
Der Typ der Methode Aspose.Slides.IShapeFrame.getFlipH() wurde von bool auf NullableBool geändert.

Die Methode IShape.getFrame() gibt die effektive Instanz von IShapeFrame zurück (alle dessen Eigenschaften haben definierte effektive Werte).

Die Methode IShape.getRawFrame() gibt eine IShapeFrame-Instanz zurück, deren jede Eigenschaft einen undefinierten Wert haben kann (insbesondere FlipH oder FlipV kann den Wert NullableBool.NotDefined haben).