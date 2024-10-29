---
title: Öffentliche API und nicht rückwärtskompatible Änderungen in Aspose.Slides für .NET 14.5.0
type: docs
weight: 70
url: /de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügten](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) Klassen, Methoden, Eigenschaften usw., alle neuen [Einschränkungen](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) und andere [Änderungen](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) auf, die mit der Aspose.Slides für .NET 14.5.0 API eingeführt wurden.

{{% /alert %}} 
## **Öffentliche API und nicht rückwärtskompatible Änderungen**
### **Hinzugefügte Schnittstellen, Klassen, Eigenschaften und Methoden**
#### **Hinzufügung der Aspose.Slides.IPresentationInfo Schnittstelle und der PresentationInfo Klasse**
Stellt Informationen über die Präsentation bereit.

- Die boolesche Eigenschaft IsEncrypted gibt True zurück, wenn eine Präsentation verschlüsselt ist, andernfalls False.
- Die Eigenschaft LoadFormat gibt den Typ einer Präsentation zurück.
#### **Hinzufügung der Aspose.Slides.IShape.IsGrouped Eigenschaft**
Die Eigenschaft Aspose.Slides.IShape.IsGrouped bestimmt, ob eine Form gruppiert ist.
#### **Hinzufügung der Aspose.Slides.IShape.ParentGroup Eigenschaft**
Die Eigenschaft Aspose.Slides.IShape.ParentGroup gibt das übergeordnete GroupShape-Objekt zurück, wenn eine Form gruppiert ist. Andernfalls gibt sie null zurück.
#### **Hinzufügung der Aspose.Slides.IShapeCollection.AddGroupShape() Methode**
Die Methode Aspose.Slides.IShapeCollection.AddGroupShape() erstellt ein neues GroupShape und fügt es ans Ende der Sammlung hinzu.
Die Rahmenhöhe und -position des GroupShape werden an den Inhalt angepasst, wenn eine neue Form hinzugefügt wird.
#### **Hinzufügung der Aspose.Slides.IShapeCollection.Clear() Methode**
Die Methode Aspose.Slides.IShapeCollection.Clear() entfernt alle Formen aus der Sammlung.
#### **Hinzufügung der Aspose.Slides.IShapeCollection.InsertGroupShape(int) Methode**
Die Methode Aspose.Slides.IShapeCollection.InsertGroupShape(int) erstellt ein neues GroupShape und fügt es an der angegebenen Indexposition in die Sammlung ein.
Die Rahmenhöhe und -position des GroupShape werden an den Inhalt angepasst, wenn eine neue Form hinzugefügt wird.
#### **Hinzufügung der IPresentationFactory.GetPresentationInfo(string file), IPresentationFactory.GetPresentationInfo(Stream stream) Methoden**
Diese Methoden ermöglichen es, Informationen über eine Präsentationsdatei oder einen Stream zu erhalten, ohne die Präsentation vollständig zu laden.
#### **Hinzufügung der IPresentationFactory PresentationFactory.Instance Eigenschaft**
Diese Eigenschaft ermöglicht es Entwicklern, die Factory-Funktionalität ohne Instanziierung zu nutzen.
### **Einschränkungen**
#### **Einschränkungen für IShape.Frame**
Einschränkungen wurden für die Verwendung undefinierter Werte für IShape.Frame hinzugefügt. Code, der versucht, einen undefinierten Rahmen an IShape.Frame zuzuweisen, macht in den meisten Fällen keinen Sinn (insbesondere wenn das übergeordnete GroupShape mehrfach in anderen {{GroupShape}}s geschachtelt ist). Zum Beispiel:

``` csharp

 IShape shape = ...;

shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);

``` 

oder

``` csharp

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);

``` 

Solcher Code kann zu unklaren Situationen führen. Daher wurden Einschränkungen für die Verwendung undefinierter Werte für IShape.Frame hinzugefügt. Die Werte für x, y, width, height, flipH, flipV und rotationAngle müssen definiert (und dürfen nicht auf float.NaN oder NullableBool.NotDefined gesetzt werden). Der obige Beispielcode wirft jetzt eine ArgumentException Ausnahme.
Dies gilt für diese Anwendungsfälle:

``` csharp

 IShape shape = ...;

shape.Frame = ...; // Kann nicht undefiniert sein

IShapeCollection shapes = ...;

// x, y, width, height Parameter dürfen nicht float.NaN sein:

{

    shapes.AddAudioFrameCD(...);

    shapes.AddAudioFrameEmbedded(...);

    shapes.AddAudioFrameLinked(...);

    shapes.AddAutoShape(...);

    shapes.AddChart(...);

    shapes.AddConnector(...);

    shapes.AddOleObjectFrame(...);

    shapes.AddPictureFrame(...);

    shapes.AddSmartArt(...);

    shapes.AddTable(...);

    shapes.AddVideoFrame(...);

    shapes.InsertAudioFrameEmbedded(...);

    shapes.InsertAudioFrameLinked(...);

    shapes.InsertAutoShape(...);

    shapes.InsertChart(...);

    shapes.InsertConnector(...);

    shapes.InsertOleObjectFrame(...);

    shapes.InsertPictureFrame(...);

    shapes.InsertTable(...);

    shapes.InsertVideoFrame(...);

}

``` 

Aber die IShape.RawFrame Rahmen Eigenschaften können undefiniert sein. Dies macht Sinn, wenn eine Form mit einem Platzhalter verknüpft ist. Dann werden die undefinierten Formrahmenwerte vom übergeordneten Platzhalterrahmen überschrieben. Wenn es keinen übergeordneten Platzhalterrahmen gibt, verwendet diese Form Standardwerte, wenn sie den effektiven Rahmen basierend auf ihrem IShape.RawFrame bewertet. Die Standardwerte sind 0 und NullableBool.False für x, y, width, height, flipH, flipV und rotationAngle. Zum Beispiel:

``` csharp

 IShape shape = ...; // Form ist mit Platzhalter verknüpft

shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);

// jetzt erbt die Form x, y, height, flipH, flipV Werte vom Platzhalter und überschreibt width=100 und rotationAngle=0.

``` 
### **Geänderte Eigenschaften**
#### **Änderung des Eigenschaftsnamen und Typs von Aspose.Slides.IShapeCollection.Parent**
- Der Typ der Aspose.Slides.IShapeCollection.Parent Eigenschaft wurde von ISlideComponent auf die neue IGroupShape Schnittstelle geändert. Die IGroupShape Schnittstelle ist ein Nachkomme von ISlideComponent, sodass bestehender Code keine Anpassungen benötigt.
- Der Name der Aspose.Slides.IShapeCollection.Parent Eigenschaft wurde von Parent in ParentGroup geändert.
#### **Änderung der Eigenschaftstypen von Aspose.Slides.IShapeFrame.FlipH, .FlipV**
- Der Typ der Aspose.Slides.IShapeFrame.FlipH Eigenschaft wurde von bool auf NullableBool geändert.
- Die IShape.Frame Eigenschaft gibt eine effektive Instanz von IShapeFrame zurück (von denen alle Eigenschaften definierte effektive Werte haben).
- Die IShape.RawFrame Eigenschaft gibt eine Instanz von IShapeFrame zurück, bei der jede Eigenschaft undefinierte Werte haben kann (insbesondere können FlipH oder FlipV den Wert NullableBool.NotDefined haben).