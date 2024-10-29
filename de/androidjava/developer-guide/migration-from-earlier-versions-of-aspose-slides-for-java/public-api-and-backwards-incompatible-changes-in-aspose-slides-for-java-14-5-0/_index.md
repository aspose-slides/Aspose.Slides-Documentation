---
title: Öffentliches API und rückwärts inkompatible Änderungen in Aspose.Slides für Java 14.5.0
type: docs
weight: 40
url: /de/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügten](/slides/de/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) Klassen, Methoden, Eigenschaften usw., alle neuen [Einschränkungen](/slides/de/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) und andere [Änderungen](/slides/de/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) auf, die mit der Aspose.Slides für Java 14.5.0 API eingeführt wurden.

{{% /alert %}} 
## **Öffentliches API und rückwärts inkompatible Änderungen**
### **Hinzugefügte Klassen und Methoden**
#### **Das Aspose.Slides.IPresentationInfo-Interface und die PresentationInfo-Klasse wurden hinzugefügt**
Repräsentiert Informationen über die Präsentation.

Die Methode Boolean isEncrypted() gibt True zurück, wenn eine Präsentation verschlüsselt ist, andernfalls gibt sie False zurück.

Die Methode LoadFormat getLoadFormat() gibt den Präsentationstyp zurück.
#### **Die Methode Aspose.Slides.IShape.isGrouped() wurde hinzugefügt**
Die Methode Aspose.Slides.IShape.isGrouped() bestimmt, ob die Form gruppiert ist.
#### **Die Methode Aspose.Slides.IShape.getParentGroup() wurde hinzugefügt**
Die Methode Aspose.Slides.IShape.getParentGroup() gibt das übergeordnete GroupShape-Objekt zurück, wenn die Form gruppiert ist. Andernfalls gibt sie null zurück.
#### **Die Methode Aspose.Slides.IShapeCollection.addGroupShape() wurde hinzugefügt**
Die Methode Aspose.Slides.IShapeCollection.addGroupShape() erstellt ein neues GroupShape und fügt es am Ende der Sammlung hinzu.

Die Größe und Position des GroupShape-Rahmens wird an den Inhalt angepasst, wenn eine neue Form zum GroupShape hinzugefügt wird.
#### **Die Methode Aspose.Slides.IShapeCollection.clear() wurde hinzugefügt**
Die Methode Aspose.Slides.IShapeCollection.clear() entfernt alle Formen aus der Sammlung.
#### **Die Methode Aspose.Slides.IShapeCollection.insertGroupShape(int) wurde hinzugefügt**
Die Methode Aspose.Slides.IShapeCollection.insertGroupShape(int) erstellt ein neues GroupShape und fügt es an der angegebenen Stelle in die Sammlung ein.
Die Größe und Position des GroupShape-Rahmens wird an den Inhalt angepasst, wenn eine neue Form zum GroupShape hinzugefügt wird.
#### **Die Methoden IPresentationFactory.getPresentationInfo(string file), IPresentationFactory.getPresentationInfo(InputStream stream) wurden hinzugefügt**
Diese Methoden ermöglichen es Entwicklern, Informationen über eine Präsentationsdatei/-stream zu erhalten, ohne die gesamte Präsentation zu laden.
#### **Die Methode IPresentationFactory PresentationFactory.getInstance() wurde hinzugefügt**
Ermöglicht die Nutzung der Fabrikfunktionalität ohne Instanziierung.
### **Einschränkungen**
#### **Einschränkungen wurden für die Verwendung undefinierter Werte für IShape.getFrame() hinzugefügt**
Code, der versucht, einen undefinierten Rahmen an IShape.setFrame(IShapeFrame) zuzuweisen, macht in allgemeinen Fällen keinen Sinn (insbesondere wenn das übergeordnete GroupShape mehrfach in andere {{GroupShape}}s eingebettet ist). Zum Beispiel:

``` java

 IShape shape = ...;

shape.setFrame(new ShapeFrame(Float.NaN, Float.NaN, Float.NaN, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, Float.NaN));

```

oder

``` java

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, Float.NaN, Float.NaN, Float.NaN, Float.NaN);

```

Solcher Code kann zu unklaren Situationen führen. Daher wurden Einschränkungen für die Verwendung undefinierter Werte für IShape.Frame eingeführt. Die Werte für x, y, width, height, flipH, flipV und rotationAngle müssen definiert sein (nicht Float.NaN oder NullableBool.NotDefined). Der Beispielcode oben wirft jetzt eine ArgumentException-Ausnahme.
Dies gilt für diese Anwendungsfälle:

``` java

 IShape shape = ...;

shape.setFrame(...); // kann nicht undefiniert sein

IShapeCollection shapes = ...;

// x, y, width, height Parameter dürfen nicht Float.NaN sein:

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

Aber das IShape.getRawFrame()-Frame kann undefiniert sein. Dies macht Sinn, wenn eine Form mit einem Platzhalter verknüpft ist. Dann werden undefinierte Rahmenwerte von der übergeordneten Platzhalterform überschrieben. Wenn es keine übergeordnete Platzhalterform für diese Form gibt, werden Standardwerte verwendet, wenn der effektive Rahmen basierend auf seinem IShape.getRawFrame() bewertet wird. Die Standardwerte sind 0 und NullableBool.False für x, y, width, height, flipH, flipV und rotationAngle. Zum Beispiel:

``` java

 IShape shape = ...; // Form ist mit Platzhalter verknüpft

shape.setRawFrame(new ShapeFrame(Float.NaN, Float.NaN, 100, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0));

// jetzt erbt die Form x, y, height, flipH, flipV-Werte vom Platzhalter und überschreibt width=100 und rotationAngle=0.

```
### **Geänderte Eigenschaften**
#### **Der Typ und Name der Methode Aspose.Slides.IShapeCollection.getParent() wurden geändert**
Der Typ der Eigenschaft Aspose.Slides.IShapeCollection.Parent wurde von ISlideComponent in das neue IGroupShape-Interface geändert. Das IGroupShape-Interface ist ein Nachkomme des ISlideComponent, sodass bestehender Code keine Anpassung benötigt.

Der Name der Methode Aspose.Slides.IShapeCollection.getParent() wurde von getParent in getParentGroup() geändert.
#### **Der Typ der Methoden Aspose.Slides.IShapeFrame.getFlipH() und .getFlipV() wurde geändert**
Der Typ der Methode Aspose.Slides.IShapeFrame.getFlipH() wurde von bool in NullableBool geändert.

Die Methode IShape.getFrame() gibt die effektive Instanz von IShapeFrame zurück (alle Eigenschaften davon haben definierte effektive Werte).

Die Methode IShape.getRawFrame() gibt eine IShapeFrame-Instanz zurück, deren jede Eigenschaft einen undefinierten Wert haben kann (insbesondere FlipH oder FlipV kann den Wert NullableBool.NotDefined haben).