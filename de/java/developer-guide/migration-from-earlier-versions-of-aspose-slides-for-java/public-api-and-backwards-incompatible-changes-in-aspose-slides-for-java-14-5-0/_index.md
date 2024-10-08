---
title: Öffentliches API und nicht abwärtskompatible Änderungen in Aspose.Slides für Java 14.5.0
type: docs
weight: 40
url: /de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügten](/slides/de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) Klassen, Methoden, Eigenschaften usw., alle neuen [Einschränkungen](/slides/de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) und andere [Änderungen](/slides/de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) auf, die mit der Aspose.Slides für Java 14.5.0 API eingeführt wurden.

{{% /alert %}} 
## **Öffentliches API und nicht abwärtskompatible Änderungen**
### **Hinzugefügte Klassen und Methoden**
#### **Hinzugefügt das Aspose.Slides.IPresentationInfo-Interface und die PresentationInfo-Klasse**
Repräsentiert Informationen über Präsentationen.

Die Methode Boolean isEncrypted() gibt True zurück, wenn eine Präsentation verschlüsselt ist, andernfalls False.

Die Methode LoadFormat getLoadFormat() gibt den Präsentationstyp zurück.
#### **Hinzugefügt die Aspose.Slides.IShape.isGrouped() Methode**
Die Methode Aspose.Slides.IShape.isGrouped() bestimmt, ob die Form gruppiert ist.
#### **Hinzugefügt die Aspose.Slides.IShape.getParentGroup() Methode**
Die Methode Aspose.Slides.IShape.getParentGroup() gibt das übergeordnete GroupShape-Objekt zurück, wenn die Form gruppiert ist. Andernfalls wird null zurückgegeben.
#### **Hinzugefügt die Aspose.Slides.IShapeCollection.addGroupShape() Methode**
Die Methode Aspose.Slides.IShapeCollection.addGroupShape() erstellt ein neues GroupShape und fügt es ans Ende der Sammlung hinzu.

Die Größe und Position des GroupShape-Rahmens wird an den Inhalt angepasst, wenn eine neue Form in das GroupShape hinzugefügt wird.
#### **Hinzugefügt die Aspose.Slides.IShapeCollection.clear() Methode**
Die Methode Aspose.Slides.IShapeCollection.clear() entfernt alle Formen aus der Sammlung.
#### **Hinzugefügt die Aspose.Slides.IShapeCollection.insertGroupShape(int) Methode**
Die Methode Aspose.Slides.IShapeCollection.insertGroupShape(int) erstellt ein neues GroupShape und fügt es an dem angegebenen Index in die Sammlung ein.
Die Größe und Position des GroupShape-Rahmens wird an den Inhalt angepasst, wenn eine neue Form in das GroupShape hinzugefügt wird.
#### **Hinzugefügt die IPresentationFactory.getPresentationInfo(string file), IPresentationFactory.getPresentationInfo(InputStream stream) Methoden**
Diese Methoden ermöglichen es Entwicklern, Informationen über eine Präsentationsdatei/-stream zu erhalten, ohne die vollständige Präsentation zu laden.
#### **Hinzugefügt die IPresentationFactory PresentationFactory.getInstance() Methode**
Ermöglicht die Nutzung der Fabrikfunktionalität ohne Instanziierung.
### **Einschränkungen**
#### **Einschränkungen wurden hinzugefügt zur Verwendung undefinierter Werte für IShape.getFrame()**
Code, der versucht, einen undefinierten Rahmen an IShape.setFrame(IShapeFrame) zuweisen, macht in allgemeinen Fällen wenig Sinn (insbesondere wenn das übergeordnete GroupShape mehrfach in andere {{GroupShape}}s verschachtelt ist). Zum Beispiel:

``` java

 IShape shape = ...;

shape.setFrame(new ShapeFrame(Float.NaN, Float.NaN, Float.NaN, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, Float.NaN));

```

oder

``` java

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, Float.NaN, Float.NaN, Float.NaN, Float.NaN);

```

Ein solcher Code kann zu unklaren Situationen führen. Daher wurden Einschränkungen für die Verwendung undefinierter Werte für IShape.Frame hinzugefügt. Die Werte von x, y, Breite, Höhe, flipH, flipV und rotationAngle müssen definiert sein (nicht Float.NaN oder NullableBool.NotDefined). Der obige Beispielcode wirft jetzt eine ArgumentException-Ausnahme.
Dies gilt für diese Anwendungsfälle:

``` java

 IShape shape = ...;

shape.setFrame(...); // kann nicht undefiniert sein

IShapeCollection shapes = ...;

// x, y, Breite, Höhe-Parameter können nicht Float.NaN sein:

{

    shapes.addAudioFrameCD(...);

    shapes.addAudioFrameEmbedded(...);

    shapes.addAudioFrameLinked(...);

    shapes.addAutoShape(...);

    shapes.addChart(...);

    shapes.addConnector(...);

    shapes.addOleObjectFrame(...);

    shapes.addPictureFrame(...);

    shapes.addSmartArt(...);

    shapes.addTable(...);

    shapes.addVideoFrame(...);

    shapes.insertAudioFrameEmbedded(...);

    shapes.insertAudioFrameLinked(...);

    shapes.insertAutoShape(...);

    shapes.insertChart(...);

    shapes.insertConnector(...);

    shapes.insertOleObjectFrame(...);

    shapes.insertPictureFrame(...);

    shapes.insertTable(...);

    shapes.insertVideoFrame(...);

}

```

Aber der IShape.getRawFrame()-Rahmen kann undefiniert sein. Das macht Sinn, wenn eine Form mit einem Platzhalter verknüpft ist. Dann werden undefinierte Rahmenwerte von der übergeordneten Platzhalterform überschrieben. Wenn es keine übergeordnete Platzhalterform für diese Form gibt, verwendet sie Standardwerte, wenn sie den effektiven Rahmen basierend auf ihrem IShape.getRawFrame() evaluiert. Standardwerte sind 0 und NullableBool.False für x, y, Breite, Höhe, flipH, flipV und rotationAngle. Zum Beispiel:

``` java

 IShape shape = ...; // Form ist mit Platzhalter verknüpft

shape.setRawFrame(new ShapeFrame(Float.NaN, Float.NaN, 100, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0));

// jetzt erbt die Form x, y, Höhe, flipH, flipV-Werte vom Platzhalter und überschreibt Breite=100 und rotationAngle=0.

```
### **Geänderte Eigenschaften**
#### **Geändert den Typ und Namen der Aspose.Slides.IShapeCollection.getParent() Methode**
Der Typ der Aspose.Slides.IShapeCollection.Parent-Eigenschaft wurde von ISlideComponent in das neue IGroupShape-Interface geändert. Das IGroupShape-Interface ist ein Nachfahre des ISlideComponent, sodass bestehender Code keine Anpassung benötigt.

Der Name der Aspose.Slides.IShapeCollection.getParent()-Methode wurde von getParent in getParentGroup() geändert.
#### **Ändern den Typ der Aspose.Slides.IShapeFrame.getFlipH() und .getFlipV() Methoden**
Der Typ der Aspose.Slides.IShapeFrame.getFlipH() Methode wurde von bool in NullableBool geändert.

Die IShape.getFrame() Methode gibt die effektive Instanz von IShapeFrame zurück (alle Eigenschaften davon haben definierte effektive Werte).

Die IShape.getRawFrame() Methode gibt eine IShapeFrame-Instanz zurück, deren jede Eigenschaft undefinierte Werte haben kann (insbesondere FlipH oder FlipV kann den Wert NullableBool.NotDefined haben).