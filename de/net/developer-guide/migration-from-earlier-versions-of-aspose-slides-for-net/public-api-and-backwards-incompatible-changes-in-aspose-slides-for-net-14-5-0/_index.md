---
title: Öffentliche API und rückwärtsinkompatible Änderungen in Aspose.Slides für .NET 14.5.0
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
description: "Überprüfen Sie die Aktualisierungen der öffentlichen API und die Breaking Changes in Aspose.Slides für .NET, um Ihre PowerPoint PPT-, PPTX- und ODP-Präsentationslösungen reibungslos zu migrieren."
---
{{% alert color="info" %}} 

Diese Seite listet alle [hinzugefügten](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) Klassen, Methoden, Eigenschaften usw. sowie neue [Einschränkungen](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) und andere [Änderungen](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) auf, die mit der Aspose.Slides for .NET 14.5.0 API eingeführt wurden.

{{% /alert %}} 
## **Öffentliche API und rückwärtsinkompatible Änderungen**
### **Hinzugefügte Schnittstellen, Klassen, Eigenschaften und Methoden**
#### **Hinzugefügt das Interface Aspose.Slides.IPresentationInfo und die Klasse PresentationInfo**
Stellt Informationen über die Präsentation dar.

- Die boolesche Eigenschaft IsEncrypted liefert True, wenn eine Präsentation verschlüsselt ist, andernfalls False.
- Die Eigenschaft LoadFormat liefert den Typ einer Präsentation.
#### **Hinzugefügt die Eigenschaft Aspose.Slides.IShape.IsGrouped**
Die Eigenschaft Aspose.Slides.IShape.IsGrouped bestimmt, ob ein Shape gruppiert ist.
#### **Hinzugefügt die Eigenschaft Aspose.Slides.IShape.ParentGroup**
Die Eigenschaft Aspose.Slides.IShape.ParentGroup gibt das übergeordnete GroupShape-Objekt zurück, wenn ein Shape gruppiert ist. Andernfalls wird null zurückgegeben.
#### **Hinzugefügt die Methode Aspose.Slides.IShapeCollection.AddGroupShape()**
Die Methode Aspose.Slides.IShapeCollection.AddGroupShape() erstellt ein neues GroupShape und fügt es am Ende der Sammlung hinzu.
Die Frame-Größe und Position des GroupShape wird an den Inhalt angepasst, wenn ein neues Shape hinzugefügt wird.
#### **Hinzugefügt die Methode Aspose.Slides.IShapeCollection.Clear()**
Die Methode Aspose.Slides.IShapeCollection.Clear() entfernt alle Shapes aus der Sammlung.
#### **Hinzugefügt die Methode Aspose.Slides.IShapeCollection.InsertGroupShape(int)**
Die Methode Aspose.Slides.IShapeCollection.InsertGroupShape(int) erstellt ein neues GroupShape und fügt es an der angegebenen Indexposition in die Sammlung ein.
Die Frame-Größe und Position des GroupShape wird an den Inhalt angepasst, wenn ein neues Shape hinzugefügt wird.
#### **Hinzugefügt die Methoden IPresentationFactory.GetPresentationInfo(string file), IPresentatoinFactory.GetPresentationInfo(Stream stream)**
Diese Methoden ermöglichen das Abrufen von Informationen über eine Präsentationsdatei oder einen Stream, ohne die gesamte Präsentation zu laden.
#### **Hinzugefügt die Eigenschaft IPresentationFactory PresentationFactory.Instance**
Diese Eigenschaft ermöglicht es Entwicklern, die Fabrikfunktionalität ohne Instanziierung zu nutzen.
### **Einschränkungen**
#### **Einschränkungen für IShape.Frame**
Es wurden Einschränkungen für die Verwendung undefinierter Werte für IShape.Frame hinzugefügt. Code, der versucht, einen undefinierten Frame an IShape.Frame zuzuweisen, ergibt in den meisten Fällen keinen Sinn (insbesondere wenn das übergeordnete GroupShape mehrfach in andere {{GroupShape}}s verschachtelt ist). Zum Beispiel:

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
IShape shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

// Wirft ArgumentException: Die Frame-Werte müssen definiert sein.
shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);
``` 

or

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// Wirft ArgumentException: x, y, width und height müssen definiert sein.
slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);
``` 

Solcher Code kann zu unklaren Situationen führen. Daher wurden Einschränkungen für die Verwendung undefinierter Werte für IShape.Frame hinzugefügt. Die Werte von x, y, width, height, flipH, flipV und rotationAngle müssen definiert sein (und dürfen nicht auf float.NaN oder NullableBool.NotDefined gesetzt werden). Der obige Beispielcode wirft nun eine ArgumentException.

Dies gilt für folgende Anwendungsfälle:

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Die Parameter x, y, width und height dürfen nicht float.NaN sein, und flipH, flipV
// dürfen nicht NullableBool.NotDefined sein:
IShape shape = shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
shape.Frame = new ShapeFrame(100, 100, 200, 100, NullableBool.False, NullableBool.False, 0);

// Dieselbe Einschränkung gilt für jede Methode, die ein Shape erstellt:
// AddAudioFrameCD, AddAudioFrameEmbedded, AddAudioFrameLinked, AddAutoShape, AddChart,
// AddConnector, AddOleObjectFrame, AddPictureFrame, AddSmartArt, AddTable, AddVideoFrame,
// InsertAudioFrameEmbedded, InsertAudioFrameLinked, InsertAutoShape, InsertChart,
// InsertConnector, InsertOleObjectFrame, InsertPictureFrame, InsertTable, InsertVideoFrame.
``` 

Allerdings können die Frame-Eigenschaften von IShape.RawFrame undefiniert sein. Das ist sinnvoll, wenn ein Shape mit einem Platzhalter verknüpft ist. Dann werden die undefinierten Shape-Frame-Werte vom übergeordneten Platzhalter-Shape überschrieben. Gibt es keinen übergeordneten Platzhalter-Shape, verwendet das Shape Standardwerte, wenn es den effektiven Frame basierend auf seinem IShape.RawFrame auswertet. Die Standardwerte sind 0 und NullableBool.False für x, y, width, height, flipH, flipV und rotationAngle. Zum Beispiel:

``` csharp
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Das Shape ist mit einem Platzhalter verknüpft
    IShape shape = presentation.Slides[0].Shapes[0];

    shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);

    // Jetzt erbt das Shape die Werte x, y, Höhe, flipH, flipV vom Platzhalter und überschreibt width=100 und rotationAngle=0.
}
``` 
### **Geänderte Eigenschaften**
#### **Geändert der Name und Typ der Eigenschaft Aspose.Slides.IShapeCollection.Parent**
- Der Typ der Eigenschaft Aspose.Slides.IShapeCollection.Parent wurde von ISlideComponent auf die neue IGroupShape-Schnittstelle geändert. Die IGroupShape-Schnittstelle ist ein Nachfolger von ISlideComponent, sodass bestehender Code keine Anpassungen benötigt.
- Der Name der Eigenschaft Aspose.Slides.IShapeCollection.Parent wurde von Parent zu ParentGroup geändert.
#### **Geändert die Typen der Eigenschaften Aspose.Slides.IShapeFrame.FlipH, .FlipV**
- Der Typ der Eigenschaft Aspose.Slides.IShapeFrame.FlipH wurde von bool zu NullableBool geändert.
- Die Eigenschaft IShape.Frame liefert eine effektive Instanz von IShapeFrame (bei der alle Eigenschaften definierte effektive Werte haben).
- Die Eigenschaft IShape.RawFrame liefert eine Instanz von IShapeFrame, bei der jede Eigenschaft einen undefinierten Wert haben kann (insbesondere können FlipH oder FlipV den Wert NullableBool.NotDefined haben).