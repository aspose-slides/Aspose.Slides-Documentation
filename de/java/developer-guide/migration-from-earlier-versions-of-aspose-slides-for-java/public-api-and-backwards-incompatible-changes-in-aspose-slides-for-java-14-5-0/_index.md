---
title: Öffentliche API und rückwärtsinkompatible Änderungen in Aspose.Slides für Java 14.5.0
linktitle: Aspose.Slides für Java 14.5.0
type: docs
weight: 40
url: /de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/
keywords:
- Migration
- Legacy-Code
- Moderner Code
- Legacy-Ansatz
- Moderner Ansatz
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Überblick über Aktualisierungen der öffentlichen API und Breaking Changes in Aspose.Slides für Java, um Ihre PowerPoint PPT, PPTX und ODP Präsentationslösungen reibungslos zu migrieren."
---
{{% alert color="info" %}} 

Diese Seite listet alle [hinzugefügten](/slides/de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) Klassen, Methoden, Eigenschaften usw. sowie neue [Einschränkungen](/slides/de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) und andere [Änderungen](/slides/de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) auf, die mit der Aspose.Slides for Java 14.5.0 API eingeführt wurden.

{{% /alert %}} 
## **Öffentliche API und rückwärtsinkompatible Änderungen**
### **Hinzugefügte Klassen und Methoden**
#### **Hinzugefügt das Aspose.Slides.IPresentationInfo-Interface und die PresentationInfo-Klassen**
Stellt Informationen über die Präsentation dar.

Methode Boolean isEncrypted() liefert True, wenn eine Präsentation verschlüsselt ist, andernfalls liefert sie False.

Methode LoadFormat getLoadFormat() liefert den Präsentationstyp.
#### **Hinzugefügt die Aspose.Slides.IShape.isGrouped()-Methode**
Die Methode Aspose.Slides.IShape.isGrouped() bestimmt, ob das Shape gruppiert ist.
#### **Hinzugefügt die Aspose.Slides.IShape.getParentGroup()-Methode**
Die Methode Aspose.Slides.IShape.getParentGroup() gibt das übergeordnete GroupShape-Objekt zurück, wenn das Shape gruppiert ist. Andernfalls gibt sie null zurück.
#### **Hinzugefügt die Aspose.Slides.IShapeCollection.addGroupShape()-Methode**
Die Methode Aspose.Slides.IShapeCollection.addGroupShape() erstellt ein neues GroupShape und fügt es am Ende der Sammlung hinzu.

Die Rahmengröße und -position des GroupShape wird an den Inhalt angepasst, wenn ein neues Shape zum GroupShape hinzugefügt wird.
#### **Hinzugefügt die Aspose.Slides.IShapeCollection.clear()-Methode**
Die Methode Aspose.Slides.IShapeCollection.clear() entfernt alle Shapes aus der Sammlung.
#### **Hinzugefügt die Aspose.Slides.IShapeCollection.insertGroupShape(int)-Methode**
Die Methode Aspose.Slides.IShapeCollection.insertGroupShape(int) erstellt ein neues GroupShape und fügt es an der angegebenen Position in die Sammlung ein.

Die Rahmengröße und -position des GroupShape wird an den Inhalt angepasst, wenn ein neues Shape zum GroupShape hinzugefügt wird.
#### **Hinzugefügt die IPresentationFactory.getPresentationInfo(string file), IPresentatoinFactory.getPresentationInfo(InputStream stream)-Methoden**
Diese Methoden ermöglichen es Entwicklern, Informationen zu einer Präsentationsdatei bzw. einem Stream zu erhalten, ohne die gesamte Präsentation zu laden.
#### **Hinzugefügt die IPresentationFactory PresentationFactory.getInstance()-Methode**
Ermöglicht die Nutzung der Fabrikfunktionalität ohne Instanziierung.
### **Einschränkungen**
#### **Einschränkungen wurden für die Verwendung undefinierter Werte bei IShape.getFrame() hinzugefügt**
Code, der versucht, einem IShape.setFrame(IShapeFrame) einen undefinierten Frame zuzuweisen, ergibt in allgemeinen Fällen keinen Sinn (insbesondere wenn das übergeordnete GroupShape mehrfach in andere {{GroupShape}}s verschachtelt ist). Zum Beispiel:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    // Wirft eine ArgumentException: Die Frame-Werte müssen definiert sein.
    shape.setFrame(new ShapeFrame(Float.NaN, Float.NaN, Float.NaN, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, Float.NaN));
} finally {
    if (pres != null) pres.dispose();
}
```

oder

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // Wirft eine ArgumentException: die x-, y-, Breite- und Höhenwerte müssen definiert sein.
    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, Float.NaN, Float.NaN, Float.NaN, Float.NaN);
} finally {
    if (pres != null) pres.dispose();
}
```

Solcher Code kann zu unklaren Situationen führen. Daher wurden Einschränkungen für die Verwendung undefinierter Werte bei IShape.Frame hinzugefügt. Die Werte von x, y, width, height, flipH, flipV und rotationAngle müssen definiert sein (nicht Float.NaN oder NullableBool.NotDefined). Der obige Beispielcode wirft jetzt eine ArgumentException-Ausnahme.

Dies gilt für die folgenden Anwendungsfälle:

``` java
// Der an IShape.setFrame(IShapeFrame) übergebene Frame darf keine undefinierten Werte enthalten.

// Die x-, y-, Breite- und Höhenparameter der folgenden IShapeCollection-Methoden
// dürfen ebenfalls nicht Float.NaN sein:
//
//     addAudioFrameCD
//     addAudioFrameEmbedded
//     addAudioFrameLinked
//     addAutoShape
//     addChart
//     addConnector
//     addOleObjectFrame
//     addPictureFrame
//     addSmartArt
//     addTable
//     addVideoFrame
//     insertAudioFrameEmbedded
//     insertAudioFrameLinked
//     insertAutoShape
//     insertChart
//     insertConnector
//     insertOleObjectFrame
//     insertPictureFrame
//     insertTable
//     insertVideoFrame
```

Aber der IShape.getRawFrame()-Frame kann undefiniert sein. Das ist sinnvoll, wenn ein Shape mit einem Platzhalter verknüpft ist. Dann werden undefinierte Frame‑Werte des Shapes vom übergeordneten Platzhalter‑Shape überschrieben. Gibt es keinen übergeordneten Platzhalter‑Shape für dieses Shape, werden Standardwerte verwendet, wenn das effektive Frame basierend auf seinem IShape.getRawFrame() ausgewertet wird. Standardwerte sind 0 und NullableBool.False für x, y, width, height, flipH, flipV und rotationAngle. Zum Beispiel:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    // Das Shape ist mit einem Platzhalter verknüpft.
    IShape shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);

    shape.setRawFrame(new ShapeFrame(Float.NaN, Float.NaN, 100, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0));

    // Jetzt erbt das Shape die x-, y-, Höhe-, flipH- und flipV-Werte vom Platzhalter
    // und überschreibt width = 100 und rotationAngle = 0.
} finally {
    if (pres != null) pres.dispose();
}
```
### **Geänderte Eigenschaften**
#### **Typ und Name der Aspose.Slides.IShapeCollection.getParent()-Methode geändert**
Der Typ der Aspose.Slides.IShapeCollection.Parent-Eigenschaft wurde von ISlideComponent auf die neue IGroupShape-Schnittstelle geändert. Die IGroupShape-Schnittstelle ist ein Nachfolger von ISlideComponent, sodass bestehender Code keine Anpassung benötigt.

Der Name der Aspose.Slides.IShapeCollection.getParent()-Methode wurde von getParent zu getParentGroup() geändert.
#### **Typ der Aspose.Slides.IShapeFrame.getFlipH()- und .getFlipV()-Methoden geändert**
Der Typ der Aspose.Slides.IShapeFrame.getFlipH()-Methode wurde von bool zu NullableBool geändert.

Die IShape.getFrame()-Methode gibt die effektive Instanz von IShapeFrame zurück (bei der alle Eigenschaften definierte effektive Werte besitzen).

Die IShape.getRawFrame()-Methode gibt eine IShapeFrame-Instanz zurück, bei der jede Eigenschaft einen undefinierten Wert haben kann (insbesondere FlipH oder FlipV können den Wert NullableBool.NotDefined haben).