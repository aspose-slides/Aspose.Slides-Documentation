---
title: Öffentliche API und rückwärtsinkompatible Änderungen in Aspose.Slides für .NET 14.4.0
linktitle: Aspose.Slides für .NET 14.4.0
type: docs
weight: 60
url: /de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-4-0/
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
description: "Überprüfen Sie die Aktualisierungen der öffentlichen API und die breaking changes in Aspose.Slides für .NET, um Ihre PowerPoint‑PPT, PPTX‑ und ODP‑Präsentationslösungen reibungslos zu migrieren."
---

## **Public API and Backwards Incompatible Changes**
### **Added Interfaces, Classes, Methods and Properties**
#### **Aspose.Slides.ILayoutSlide.HasDependingSlides Property Has Been Added**
Die Eigenschaft `Aspose.Slides.ILayoutSlide.HasDependingSlides` gibt **true** zurück, wenn mindestens eine Folie existiert, die von dieser Layout‑Folie abhängt. Beispiel:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Aspose.Slides.ILayoutSlide.Remove() Method**
Die Methode `Aspose.Slides.ILayoutSlide.Remove()` ermöglicht das Entfernen eines Layouts aus einer Präsentation mit minimalem Code. Beispiel:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide) Method**
Die Methode `Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide)` ermöglicht das Entfernen eines Layouts aus der Sammlung. Codebeispiele:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    presentation.LayoutSlides.Remove(layout);

``` 

oder

``` csharp

 IMasterSlide masterSlide = ...;

ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    masterSlide.LayoutSlides.Remove(layout);

``` 
#### **Aspose.Slides.ILayoutSlideCollection.RemoveUnused()**
Die Methode `Aspose.Slides.ILayoutSlideCollection.RemoveUnused()` ermöglicht das Entfernen nicht verwendeter Layout‑Folien (Layout‑Folien, bei denen **HasDependingSlides** **false** ist). Codebeispiele:

``` csharp

 presentation.LayoutSlides.RemoveUnused();

``` 

oder

``` csharp

 IMasterSlide masterSlide = ...;

masterSlide.LayoutSlides.RemoveUnused();

``` 
#### **Aspose.Slides.IMasterSlide.HasDependingSlides Property**
Die Eigenschaft `Aspose.Slides.IMasterSlide.HasDependingSlides` gibt **true** zurück, wenn mindestens eine Folie existiert, die von dieser Master‑Folie abhängt. Beispiel:

``` csharp

 IMasterSlide masterSlide = ...;

if (!masterSlide.HasDependingSlides)

    presentation.Masters.Remove(masterSlide);

``` 
#### **Aspose.Slides.ISlide.Remove() Method**
Die Methode `Aspose.Slides.ISlide.Remove()` ermöglicht das Entfernen einer Folie aus einer Präsentation mit minimalem Code. Beispiel:

``` csharp

 ISlide slide = ...;

slide.Remove();

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat**
Die Eigenschaft `Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat` liefert ein `IFillFormat` für einen SmartArt‑Knoten‑Bullet, wenn das Layout Bullets bereitstellt. Sie kann verwendet werden, um das Bullet‑Bild zu setzen.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-SmartArts-BulletFillFormat-BulletFillFormat.cs" >}}
#### **Aspose.Slides.SmartArt.ISmartArtNode.Level Property**
Die Eigenschaft `Aspose.Slides.SmartArt.ISmartArtNode.Level` gibt die Verschachtelungsebene für SmartArt‑Knoten zurück.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if(node.Level == 1)

    node.TextFrame.Text = "First level";

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.Position Property**
Die Eigenschaft `Aspose.Slides.SmartArt.ISmartArtNode.Position` gibt die Position eines Knotens unter seinen Geschwistern zurück.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if (node.ChildNodes.Count > 3)

    node.ChildNodes[0].Position++;

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.Remove() Method Has Been Added**
Die Methode `Aspose.Slides.SmartArt.ISmartArtNode.Remove()` ermöglicht das Entfernen eines Knotens aus einem Diagramm.

``` csharp

 ISmartArt node = diagram.AllNodes[0];

node.Remove();

``` 
#### **IGlobalLayoutSlideCollection Interface and GlobalLayoutSlideCollection Class**
Das Interface `IGlobalLayoutSlideCollection` und die Klasse `GlobalLayoutSlideCollection` wurden dem Namespace `Aspose.Slides` hinzugefügt.

Die Klasse `GlobalLayoutSlideCollection` implementiert das Interface `IGlobalLayoutSlideCollection`.

Das Interface `IGlobalLayoutSlideCollection` stellt eine Sammlung aller Layout‑Folien in einer Präsentation dar. Die Eigenschaft `IPresentation.LayoutSlides` hat den Typ `IGlobalLayoutSlideCollection`. `IGlobalLayoutSlideCollection` erweitert das Interface `ILayoutSlideCollection` um Methoden zum Hinzufügen und Klonen von Layout‑Folien im Kontext der Zusammenführung einzelner Sammlungen von Master‑Layout‑Folien:

- `ILayoutSlide AddClone(ILayoutSlide sourceLayout);` – Kann verwendet werden, um eine Kopie einer angegebenen Layout‑Folie zur Präsentation hinzuzufügen. Diese Methode behält die Quellformatierung bei (wenn ein Layout zwischen verschiedenen Präsentationen geklont wird, kann auch der Master des Layouts geklont werden. Das interne Register wird verwendet, um automatisch geklonte Master zu verfolgen und die Erstellung mehrerer Klone desselben Master‑Slides zu verhindern).
- `ILayoutSlide AddClone(ILayoutSlide sourceLayout, IMasterSlide destMaster);` – Wird verwendet, um eine Kopie einer angegebenen Layout‑Folie zu einer Präsentation hinzuzufügen. Das neue Layout wird mit dem definierten Master in der Zielpräsentation verknüpft. Diese Option entspricht dem Kopieren oder Einfügen mit der **Use Destination Theme**‑Option in Microsoft PowerPoint.
- `ILayoutSlide Add(IMasterSlide master, SlideLayoutType layoutType, string layoutName);` – Wird verwendet, um ein neues Layout‑Slide zu einer Präsentation hinzuzufügen. Unterstützte Layout‑Typen: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom. Der Layout‑Name kann automatisch generiert werden. Ein hinzugefügtes Layout des Typs `SlideLayoutType.Custom` enthält keine Platzhalter und keine Formen. Ein analoges Verfahren ist die Methode `IMasterLayoutSlideCollection.Add(SlideLayoutType, string)`, die über die Eigenschaft `IMasterSlide.LayoutSlides` erreichbar ist.
#### **Interface IMasterLayoutSlideCollection and Class MasterLayoutSlideCollection**
Das Interface `IMasterLayoutSlideCollection` und die Klasse `MasterLayoutSlideCollection` wurden dem Namespace `Aspose.Slides` hinzugefügt. Die Klasse `MasterLayoutSlideCollection` implementiert das Interface `IMasterLayoutSlideCollection`.

Das Interface `IMasterLayoutSlideCollection` stellt eine Sammlung aller Layout‑Folien eines definierten Masters dar. Es erweitert das Interface `ILayoutSlideCollection` um Methoden zum Hinzufügen, Einfügen, Entfernen oder Klonen von Layout‑Folien im Kontext der einzelnen Sammlungen der Layout‑Folien eines Masters:

``` csharp

 // Method signature:

ILayoutSlide AddClone(ILayoutSlide sourceLayout);

// Code example that attaches copy of the sourceLayout to the destMasterSlide:

IMasterSlide destMasterSlide = ...;

destMasterSlide.LayoutSlides.AddClone(sourceLayout);

``` 

Die Methode kann verwendet werden, um eine Kopie einer angegebenen Layout‑Folie am Ende der Sammlung hinzuzufügen. Das neue Layout wird mit dem übergeordneten Master‑Slide für diese Layout‑Folien‑Sammlung verknüpft. Dies entspricht dem Kopieren oder Einfügen mit der **Use Destination Theme**‑Option in PowerPoint. Ein analoges Verfahren ist die Methode `IGlobalLayoutSlideCollection.AddClone(ILayoutSlide, IMasterSlide)`, die über die Eigenschaft `IPresentation.LayoutSlides` aufgerufen wird.

- `ILayoutSlide InsertClone(int index, ILayoutSlide sourceLayout);` – Wird verwendet, um eine Kopie einer angegebenen Layout‑Folie an einer bestimmten Position in die Sammlung einzufügen. Das neue Layout wird mit dem übergeordneten Master‑Slide verknüpft. Dies entspricht dem Kopieren und Einfügen mit der **Use Destination Theme**‑Option in PowerPoint.
- `ILayoutSlide Add(SlideLayoutType layoutType, string layoutName);`
- `ILayoutSlide Insert(int index, SlideLayoutType layoutType, string layoutName);` – Wird verwendet, um ein neues Layout‑Slide hinzuzufügen oder einzufügen. Unterstützte Layout‑Typen: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom. Der Layout‑Name kann automatisch generiert werden. Ein hinzugefügtes Layout des Typs `SlideLayoutType.Custom` enthält keine Platzhalter und keine Formen. Ein analoges Verfahren ist die Methode `IGlobalLayoutSlideCollection.Add(IMasterSlide, SlideLayoutType, string)`, die über die Eigenschaft `IPresentation.LayoutSlides` aufgerufen wird.
- `void RemoveAt(int index);` – Wird verwendet, um das Layout an dem angegebenen Index aus der Sammlung zu entfernen.
- `void Reorder(int index, ILayoutSlide layoutSlide);` – Wird verwendet, um ein Layout‑Slide innerhalb der Sammlung an die angegebene Position zu verschieben.
### **Changed Methods and Properties**
#### **Signature of the Aspose.Slides.ISlideCollection.AddClone(ISlide, IMasterSlide) Method**
Die Signatur der Methode `ISlideCollection.AddClone(ISlide, IMasterSlide)`:

```csharp
ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster);
```

ist jetzt veraltet und wurde ersetzt durch:

```csharp
ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout)
```

Der Parameter `allowCloneMissingLayout` gibt an, was zu tun ist, wenn im `destMaster` kein passendes Layout für die neue (geklonte) Folie vorhanden ist. Das passende Layout ist das Layout mit demselben Typ oder Namen wie das Layout der Quellfolie. Wenn kein passendes Layout im angegebenen Master existiert, wird das Layout der Quellfolie geklont (wenn `allowCloneMissingLayout` **true** ist) oder es wird eine `PptxEditException` ausgelöst (wenn **false**).

Ein Aufruf der veralteten Methode wie

```csharp
AddClone(sourceSlide, destMaster);
```

impliziert `allowCloneMissingLayout` = **false** (d.h. eine `PptxEditException` wird ausgelöst, wenn kein passendes Layout existiert). Ein funktional identischer Aufruf mit neuer Signatur sieht so aus:

```csharp
AddClone(sourceSlide, destMaster, false);
```

Wenn fehlende Layouts automatisch geklont werden sollen, anstatt eine `PptxEditException` zu werfen, übergeben Sie `allowCloneMissingLayout` als **true**.

Dies gilt ebenfalls für die Methode `ISlideCollection`:

```csharp
ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster);
```

die ebenfalls veraltet ist und ersetzt wurde durch:

```csharp
ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout);
```
#### **Type of the Aspose.Slides.IMasterSlide.LayoutSlides Property**
Der Typ der Eigenschaft `Aspose.Slides.IMasterSlide.LayoutSlides` wurde von `ILayoutSlideCollection` zu dem neuen Interface `IMasterLayoutSlideCollection` geändert. Das Interface `IMasterLayoutSlideCollection` ist ein Nachfolger von `ILayoutSlideCollection`, sodass vorhandener Code keine Anpassungen erfordert.
#### **Type of the Aspose.Slides.IPresentation.LayoutSlides Property Has Been Changed**
Der Typ der Eigenschaft `Aspose.Slides.IPresentation.LayoutSlides` wurde von `ILayoutSlideCollection` zu dem neuen Interface `IGlobalLayoutSlideCollection` geändert. Das Interface `IGlobalLayoutSlideCollection` ist ein Nachfolger von `ILayoutSlideCollection`, sodass vorhandener Code keine Anpassungen erfordert.