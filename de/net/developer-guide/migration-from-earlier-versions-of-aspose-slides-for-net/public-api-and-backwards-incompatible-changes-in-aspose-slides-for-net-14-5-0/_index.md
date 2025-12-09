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
description: "Überprüfen Sie die öffentlichen API-Updates und kritischen Änderungen in Aspose.Slides für .NET, um Ihre PowerPoint‑PPT, PPTX‑ und ODP‑Präsentationslösungen reibungslos zu migrieren."
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügt](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) Klassen, Methoden, Eigenschaften usw. sowie alle neuen [Einschränkungen](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) und anderen [Änderungen](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) auf, die mit der Aspose.Slides for .NET 14.5.0 API eingeführt wurden.

{{% /alert %}} 
## **Öffentliche API und rückwärtsinkompatible Änderungen**
### **Hinzugefügte Schnittstellen, Klassen, Eigenschaften und Methoden**
#### **Hinzugefügt: Das Interface Aspose.Slides.IPresentationInfo und die Klasse PresentationInfo**
Stellt Informationen über die Präsentation dar.

- Die boolesche Eigenschaft IsEncrypted gibt True zurück, wenn eine Präsentation verschlüsselt ist, andernfalls False.
- Die Eigenschaft LoadFormat gibt den Typ einer Präsentation zurück.
#### **Die Eigenschaft Aspose.Slides.IShape.IsGrouped wurde hinzugefügt**
Die Eigenschaft Aspose.Slides.IShape.IsGrouped bestimmt, ob eine Form gruppiert ist.
#### **Die Eigenschaft Aspose.Slides.IShape.ParentGroup wurde hinzugefügt**
Die Eigenschaft Aspose.Slides.IShape.ParentGroup gibt das übergeordnete GroupShape-Objekt zurück, wenn eine Form gruppiert ist. Andernfalls wird null zurückgegeben.
#### **Die Methode Aspose.Slides.IShapeCollection.AddGroupShape() wurde hinzugefügt**
Die Methode Aspose.Slides.IShapeCollection.AddGroupShape() erstellt ein neues GroupShape und fügt es am Ende der Sammlung hinzu.
Die Rahmengröße und -position des GroupShape werden an den Inhalt angepasst, wenn eine neue Form hinzugefügt wird.
#### **Die Methode Aspose.Slides.IShapeCollection.Clear() wurde hinzugefügt**
Die Methode Aspose.Slides.IShapeCollection.Clear() entfernt alle Formen aus der Sammlung.
#### **Die Methode Aspose.Slides.IShapeCollection.InsertGroupShape(int) wurde hinzugefügt**
Die Methode Aspose.Slides.IShapeCollection.InsertGroupShape(int) erstellt ein neues GroupShape und fügt es an der angegebenen Indexposition in die Sammlung ein.
Die Rahmengröße und -position des GroupShape werden an den Inhalt angepasst, wenn eine neue Form hinzugefügt wird.
#### **Die Methoden IPresentationFactory.GetPresentationInfo(string file) und IPresentatoinFactory.GetPresentationInfo(Stream stream) wurden hinzugefügt**
Diese Methoden ermöglichen das Abrufen von Informationen über eine Präsentationsdatei oder einen Stream, ohne die Präsentation vollständig zu laden.
#### **Die Eigenschaft IPresentationFactory PresentationFactory.Instance wurde hinzugefügt**
Diese Eigenschaft ermöglicht Entwicklern die Nutzung der Fabrikfunktionalität ohne Instanziierung.
### **Einschränkungen**
#### **Einschränkungen für IShape.Frame**
Es wurden Einschränkungen für die Verwendung undefinierter Werte für IShape.Frame hinzugefügt. Code, der versucht, einen undefinierten Rahmen an IShape.Frame zuzuweisen, ergibt in den meisten Fällen keinen Sinn (insbesondere wenn das übergeordnete GroupShape mehrfach in andere {{GroupShape}}s verschachtelt ist). Zum Beispiel:

``` csharp

 IShape shape = ...;

shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);


``` 

oder

``` csharp

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);

``` 

Solcher Code kann zu unklaren Situationen führen. Daher wurden Einschränkungen für die Verwendung undefinierter Werte für IShape.Frame hinzugefügt. Die Werte von x, y, width, height, flipH, flipV und rotationAngle müssen definiert sein (und dürfen nicht auf float.NaN oder NullableBool.NotDefined gesetzt werden). Der obige Beispielcode wirft jetzt eine ArgumentException.

Dies gilt für folgende Anwendungsfälle:

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

Aber die Frame‑Eigenschaften von IShape.RawFrame können undefiniert sein. Dies ist sinnvoll, wenn eine Form mit einem Platzhalter verknüpft ist. Dann werden die undefinierten Frame‑Werte der Form vom übergeordneten Platzhalter überschrieben. Gibt es keinen übergeordneten Platzhalter, verwendet die Form Standardwerte, wenn sie den effektiven Frame basierend auf ihrem IShape.RawFrame auswertet. Die Standardwerte sind 0 und NullableBool.False für x, y, width, height, flipH, flipV und rotationAngle. Zum Beispiel:

``` csharp

 IShape shape = ...; // shape is linked to placeholder

shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);

// now shape inherits x, y, height, flipH, flipV values form placeholder and overrides width=100 and rotationAngle=0.

``` 
### **Geänderte Eigenschaften**
#### **Der Name und Typ der Eigenschaft Aspose.Slides.IShapeCollection.Parent wurde geändert**
- Der Typ der Eigenschaft Aspose.Slides.IShapeCollection.Parent wurde von ISlideComponent auf das neue IGroupShape-Interface geändert. Das IGroupShape-Interface ist ein Nachfolger von ISlideComponent, sodass bestehender Code keine Anpassungen benötigt.
- Der Name der Eigenschaft Aspose.Slides.IShapeCollection.Parent wurde von Parent zu ParentGroup geändert.
#### **Die Typen der Eigenschaften Aspose.Slides.IShapeFrame.FlipH und .FlipV wurden geändert**
- Der Typ der Eigenschaft Aspose.Slides.IShapeFrame.FlipH wurde von bool zu NullableBool geändert.
- Die Eigenschaft IShape.Frame gibt eine effektive Instanz von IShapeFrame zurück (alle Eigenschaften haben definierte effektive Werte).
- Die Eigenschaft IShape.RawFrame gibt eine Instanz von IShapeFrame zurück, bei der jede Eigenschaft einen undefinierten Wert haben kann (insbesondere FlipH oder FlipV können den Wert NullableBool.NotDefined haben).