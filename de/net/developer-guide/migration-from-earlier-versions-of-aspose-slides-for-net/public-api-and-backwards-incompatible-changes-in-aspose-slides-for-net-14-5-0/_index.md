---
title: Öffentliche API und abwärts inkompatible Änderungen in Aspose.Slides für .NET 14.5.0
linktitle: Aspose.Slides für .NET 14.5.0
type: docs
weight: 70
url: /de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/
keywords:
- Migration
- Legacy-Code
- Moderner Code
- Legacy-Ansatz
- Moderner Ansatz
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Überprüfen Sie die Aktualisierungen der öffentlichen API und die Breaking Changes in Aspose.Slides für .NET, um Ihre PowerPoint-PPT, PPTX und ODP-Präsentationslösungen reibungslos zu migrieren."
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügt](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) Klassen, Methoden, Eigenschaften und so weiter, alle neuen [Einschränkungen](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) und andere [Änderungen](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) ein, die mit der Aspose.Slides for .NET 14.5.0 API eingeführt wurden.

{{% /alert %}} 
## **Öffentliche API und abwärts inkompatible Änderungen**
### **Hinzugefügte Schnittstellen, Klassen, Eigenschaften und Methoden**
#### **Hinzugefügt das Aspose.Slides.IPresentationInfo Interface und die PresentationInfo Klasse**
Stellt Informationen über die Präsentation dar.

- Die boolesche Eigenschaft IsEncrypted liefert True, wenn eine Präsentation verschlüsselt ist, andernfalls False.
- Die Eigenschaft LoadFormat liefert den Typ einer Präsentation.
#### **Hinzugefügt die Aspose.Slides.IShape.IsGrouped Eigenschaft**
Die Eigenschaft Aspose.Slides.IShape.IsGrouped bestimmt, ob eine Form gruppiert ist.
#### **Hinzugefügt die Aspose.Slides.IShape.ParentGroup Eigenschaft**
Die Eigenschaft Aspose.Slides.IShape.ParentGroup gibt das übergeordnete GroupShape-Objekt zurück, wenn eine Form gruppiert ist. Andernfalls wird null zurückgegeben.
#### **Hinzugefügt die Aspose.Slides.IShapeCollection.AddGroupShape() Methode**
Die Methode Aspose.Slides.IShapeCollection.AddGroupShape() erstellt ein neues GroupShape und fügt es am Ende der Sammlung hinzu.
Die Rahmengröße und Position des GroupShape wird an den Inhalt angepasst, wenn eine neue Form hinzugefügt wird.
#### **Hinzugefügt die Aspose.Slides.IShapeCollection.Clear() Methode**
Die Methode Aspose.Slides.IShapeCollection.Clear() entfernt alle Formen aus der Sammlung.
#### **Hinzugefügt die Aspose.Slides.IShapeCollection.InsertGroupShape(int) Methode**
Die Methode Aspose.Slides.IShapeCollection.InsertGroupShape(int) erstellt ein neues GroupShape und fügt es an der angegebenen Indexposition in die Sammlung ein.
Die Rahmengröße und Position des GroupShape wird an den Inhalt angepasst, wenn eine neue Form hinzugefügt wird.
#### **Hinzugefügt die IPresentationFactory.GetPresentationInfo(string file), IPresentatoinFactory.GetPresentationInfo(Stream stream) Methoden**
Diese Methoden ermöglichen, Informationen über eine Präsentationsdatei oder einen Stream zu erhalten, ohne die gesamte Präsentation zu laden.
#### **Hinzugefügt die IPresentationFactory PresentationFactory.Instance Eigenschaft**
Diese Eigenschaft ermöglicht Entwicklern die Nutzung der Fabrikfunktionalität ohne Instanziierung.
### **Einschränkungen**
#### **Einschränkungen für IShape.Frame**
Restrictions wurden für die Verwendung undefinierter Werte für IShape.Frame hinzugefügt. Code, der versucht, einen undefinierten Rahmen IShape.Frame zuzuweisen, ist in den meisten Fällen unsinnig (insbesondere wenn das übergeordnete GroupShape mehrfach in andere {{GroupShape}}s verschachtelt ist). Zum Beispiel:

``` csharp

 IShape shape = ...;

shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);


``` 

oder

``` csharp

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);

``` 

Ein solcher Code kann zu unklaren Situationen führen. Daher wurden Einschränkungen für die Verwendung undefinierter Werte für IShape.Frame hinzugefügt. Werte für x, y, width, height, flipH, flipV und rotationAngle müssen definiert sein (und dürfen nicht auf float.NaN oder NullableBool.NotDefined gesetzt werden). Der obige Beispielcode wirft jetzt eine ArgumentException.

Dies gilt für die folgenden Anwendungsfälle:

``` csharp

 IShape shape = ...;

shape.Frame = ...; // Cannot be undefined

IShapeCollection shapes = ...;

// x, y, width, height parameters cannot be float.NaN:

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

Doch die Frame-Eigenschaften von IShape.RawFrame können undefiniert sein. Das ist sinnvoll, wenn eine Form mit einem Platzhalter verknüpft ist. Dann werden die undefinierten Frame-Werte der Form vom übergeordneten Platzhalter übernommen. Gibt es keinen übergeordneten Platzhalter, verwendet die Form Standardwerte, wenn sie den effektiven Frame basierend auf IShape.RawFrame auswertet. Die Standardwerte sind 0 und NullableBool.False für x, y, width, height, flipH, flipV und rotationAngle. Zum Beispiel:

``` csharp

 IShape shape = ...; // shape is linked to placeholder

shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);

// now shape inherits x, y, height, flipH, flipV values form placeholder and overrides width=100 and rotationAngle=0.

``` 
### **Geänderte Eigenschaften**
#### **Geändert der Aspose.Slides.IShapeCollection.Parent Eigenschaftsname und -typ**
- Der Typ der Aspose.Slides.IShapeCollection.Parent‑Eigenschaft wurde von ISlideComponent zu der neuen IGroupShape‑Schnittstelle geändert. Die IGroupShape‑Schnittstelle ist ein Nachfolger von ISlideComponent, sodass bestehender Code keine Anpassungen erfordert.
- Der Name der Aspose.Slides.IShapeCollection.Parent‑Eigenschaft wurde von Parent zu ParentGroup geändert.
#### **Geändert die Typen der Aspose.Slides.IShapeFrame.FlipH- und .FlipV‑Eigenschaften**
- Der Typ der Aspose.Slides.IShapeFrame.FlipH‑Eigenschaft wurde von bool zu NullableBool geändert.
- Die IShape.Frame‑Eigenschaft liefert eine effektive Instanz von IShapeFrame (bei der alle Eigenschaften definierte effektive Werte besitzen).
- Die IShape.RawFrame‑Eigenschaft liefert eine Instanz von IShapeFrame, bei der jede Eigenschaft undefiniert sein kann (insbesondere können FlipH oder FlipV den Wert NullableBool.NotDefined haben).