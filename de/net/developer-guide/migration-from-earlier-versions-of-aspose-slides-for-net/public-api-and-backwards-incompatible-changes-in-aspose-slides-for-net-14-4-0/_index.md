---
title: Öffentliche API und nicht abwärtskompatible Änderungen in Aspose.Slides für .NET 14.4.0
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
description: "Überprüfen Sie die öffentlichen API-Updates und inkompatiblen Änderungen in Aspose.Slides für .NET, um Ihre PowerPoint PPT, PPTX und ODP Präsentationslösungen reibungslos zu migrieren."
---

## **Öffentliche API und nicht abwärtskompatible Änderungen**
### **Hinzugefügte Schnittstellen, Klassen, Methoden und Eigenschaften**
#### **Die Eigenschaft Aspose.Slides.ILayoutSlide.HasDependingSlides wurde hinzugefügt**
Die Eigenschaft Aspose.Slides.ILayoutSlide.HasDependingSlides gibt true zurück, wenn mindestens eine Folie von dieser Layout‑Folie abhängt. Beispielweise:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Methode Aspose.Slides.ILayoutSlide.Remove()**
Die Methode Aspose.Slides.ILayoutSlide.Remove() ermöglicht das Entfernen eines Layouts aus einer Präsentation mit minimalem Code. Beispielweise:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Methode Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide)**
Die Methode Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide) ermöglicht das Entfernen eines Layouts aus der Sammlung. Codebeispiele:

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
Die Methode Aspose.Slides.ILayoutSlideCollection.RemoveUnused() ermöglicht das Entfernen unbenutzter Layout‑Folien (Layout‑Folien, deren HasDependingSlides false ist). Codebeispiele:

``` csharp

 presentation.LayoutSlides.RemoveUnused();

``` 

oder

``` csharp

 IMasterSlide masterSlide = ...;

masterSlide.LayoutSlides.RemoveUnused();

``` 
#### **Die Eigenschaft Aspose.Slides.IMasterSlide.HasDependingSlides**
Die Eigenschaft Aspose.Slides.IMasterSlide.HasDependingSlides gibt true zurück, wenn mindestens eine Folie von dieser Master‑Folie abhängt. Beispielweise:

``` csharp

 IMasterSlide masterSlide = ...;

if (!masterSlide.HasDependingSlides)

    presentation.Masters.Remove(masterSlide);

``` 
#### **Methode Aspose.Slides.ISlide.Remove()**
Die Methode Aspose.Slides.ISlide.Remove() ermöglicht das Entfernen einer Folie aus einer Präsentation mit minimalem Code. Beispielweise:

``` csharp

 ISlide slide = ...;

slide.Remove();

``` 
#### **Die Eigenschaft Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat**
Die Eigenschaft Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat gibt IFillFormat für einen SmartArt‑Knoten‑Aufzählungspunkt zurück, wenn das Layout Aufzählungszeichen bereitstellt. Sie kann verwendet werden, um das Aufzählungs‑Bild festzulegen.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-SmartArts-BulletFillFormat-BulletFillFormat.cs" >}}
#### **Die Eigenschaft Aspose.Slides.SmartArt.ISmartArtNode.Level**
Die Eigenschaft Aspose.Slides.SmartArt.ISmartArtNode.Level gibt die verschachtelte Ebene für SmartArt‑Knoten zurück.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if(node.Level == 1)

    node.TextFrame.Text = "First level";

``` 
#### **Die Eigenschaft Aspose.Slides.SmartArt.ISmartArtNode.Position**
Die Eigenschaft Aspose.Slides.SmartArt.ISmartArtNode.Position gibt die Position eines Knotens unter seinen Geschwistern zurück.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if (node.ChildNodes.Count > 3)

    node.ChildNodes[0].Position++;

``` 
#### **Methode Aspose.Slides.SmartArt.ISmartArtNode.Remove()**
Die Methode Aspose.Slides.SmartArt.ISmartArtNode.Remove() ermöglicht das Entfernen eines Knotens aus einem Diagramm.

``` csharp

 ISmartArt node = diagram.AllNodes[0];

node.Remove();

``` 
#### **IGlobalLayoutSlideCollection Schnittstelle und GlobalLayoutSlideCollection Klasse**
Die Schnittstelle IGlobalLayoutSlideCollection und die Klasse GlobalLayoutSlideCollection wurden dem Namespace Aspose.Slides hinzugefügt.

Die Klasse GlobalLayoutSlideCollection implementiert die Schnittstelle IGlobalLayoutSlideCollection.

Die Schnittstelle IGlobalLayoutSlideCollection stellt eine Sammlung aller Layout‑Folien in einer Präsentation dar. Die Eigenschaft IPresentation.LayoutSlides ist vom Typ IGlobalLayoutSlideCollection. IGlobalLayoutSlideCollection erweitert die Schnittstelle ILayoutSlideCollection um Methoden zum Hinzufügen und Klonen von Layout‑Folien im Kontext der Zusammenführung der einzelnen Sammlungen der Master‑Layout‑Folien:
- ILayoutSlide AddClone(ILayoutSlide sourceLayout); – Kann verwendet werden, um eine Kopie eines angegebenen Layout‑Slides zur Präsentation hinzuzufügen. Diese Methode bewahrt die Quellformatierung (bei Klonen eines Layouts zwischen verschiedenen Präsentationen kann auch der Master des Layouts geklont werden. Das interne Register wird verwendet, um automatisch geklonte Master zu verfolgen und die Erstellung mehrerer Klone desselben Master‑Slides zu verhindern.)
- ILayoutSlide AddClone(ILayoutSlide sourceLayout, IMasterSlide destMaster); – Wird verwendet, um eine Kopie eines angegebenen Layout‑Slides zu einer Präsentation hinzuzufügen. Das neue Layout wird mit dem definierten Master in der Zielpräsentation verknüpft. Diese Option entspricht dem Kopieren oder Einfügen mit der Option **Use Destination Theme** in Microsoft PowerPoint.
- ILayoutSlide Add(IMasterSlide master, SlideLayoutType layoutType, string layoutName); – Wird verwendet, um ein neues Layout‑Slide zu einer Präsentation hinzuzufügen. Unterstützte Layout‑Typen: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom. Der Layout‑Name kann automatisch generiert werden. Ein hinzugefügtes Layout des Typs SlideLayoutType.Custom enthält keine Platzhalter und keine Formen. Ein Gegenstück dieser Methode ist die Methode IMasterLayoutSlideCollection.Add(SlideLayoutType, string), die über die Eigenschaft IMasterSlide.LayoutSlides aufgerufen wird.
#### **Interface IMasterLayoutSlideCollection und Klasse MasterLayoutSlideCollection**
Die Schnittstelle IMasterLayoutSlideCollection und die Klasse MasterLayoutSlideCollection wurden dem Namespace Aspose.Slides hinzugefügt. Die Klasse MasterLayoutSlideCollection implementiert die Schnittstelle IMasterLayoutSlideCollection.

Die Schnittstelle IMasterLayoutSlideCollection stellt eine Sammlung aller Layout‑Folien eines definierten Master‑Slides dar. Sie erweitert die Schnittstelle ILayoutSlideCollection um Methoden zum Hinzufügen, Einfügen, Entfernen oder Klonen von Layout‑Folien im Kontext der einzelnen Sammlungen der Master‑Layout‑Folien:

``` csharp

 // Method signature:

ILayoutSlide AddClone(ILayoutSlide sourceLayout);

// Code example that attaches copy of the sourceLayout to the destMasterSlide:

IMasterSlide destMasterSlide = ...;

destMasterSlide.LayoutSlides.AddClone(sourceLayout);

``` 

Die Methode kann verwendet werden, um eine Kopie eines angegebenen Layout‑Slides am Ende der Sammlung hinzuzufügen. Das neue Layout wird mit dem übergeordneten Master‑Slide dieser Layout‑Slide‑Sammlung verknüpft. Dies entspricht dem Kopieren oder Einfügen mit der Option **Use Destination Theme** in PowerPoint. Das Gegenstück dieser Methode ist die Methode IGlobalLayoutSlideCollection.AddClone(ILayoutSlide, IMasterSlide), die über die Eigenschaft IPresentation.LayoutSlides aufgerufen wird.
- ILayoutSlide InsertClone(int index, ILayoutSlide sourceLayout); – Wird verwendet, um eine Kopie eines angegebenen Layout‑Slides an einer bestimmten Position der Sammlung einzufügen. Das neue Layout wird mit dem übergeordneten Master‑Slide dieser Layout‑Slide‑Sammlung verknüpft. Dies entspricht dem Kopieren und Einfügen mit der Option **Use Destination Theme** in PowerPoint.
- ILayoutSlide Add(SlideLayoutType layoutType, string layoutName);
- ILayoutSlide Insert(int index, SlideLayoutType layoutType, string layoutName); – Wird verwendet, um ein neues Layout‑Slide hinzuzufügen oder einzufügen. Unterstützte Layout‑Typen: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom. Der Layout‑Name kann automatisch generiert werden. Hinzugefügtes Layout des Typs SlideLayoutType.Custom enthält keine Platzhalter und keine Formen. Das Gegenstück dieser Methode ist die Methode IGlobalLayoutSlideCollection.Add(IMasterSlide, SlideLayoutType, string), die über die Eigenschaft IPresentation.LayoutSlides aufgerufen wird.
- void RemoveAt(int index); – Wird verwendet, um das Layout am angegebenen Index aus der Sammlung zu entfernen.
- void Reorder(int index, ILayoutSlide layoutSlide); – Wird verwendet, um ein Layout‑Slide innerhalb der Sammlung an die angegebene Position zu verschieben.
### **Geänderte Methoden und Eigenschaften**
#### **Signatur der Aspose.Slides.ISlideCollection.AddClone(ISlide, IMasterSlide) Methode**
Die Signatur der ISlideCollection‑Methode:
ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster);

ist nun veraltet und wurde ersetzt durch die Signatur

ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout)

Der Parameter allowCloneMissingLayout gibt an, was zu tun ist, wenn im destMaster kein passendes Layout für die neue (geklonte) Folie vorhanden ist. Das passende Layout ist das Layout mit demselben Typ oder Namen wie das Layout der Quellfolie. Gibt es im angegebenen Master kein passendes Layout, wird das Layout der Quellfolie geklont (wenn allowCloneMissingLayout true ist) oder es wird eine PptxEditException ausgelöst (wenn allowCloneMissingLayout false ist).

Ein Aufruf der veralteten Methode wie

AddClone(sourceSlide, destMaster);

setzt allowCloneMissingLayout implizit auf false (d. h., eine PptxEditException wird ausgelöst, wenn kein passendes Layout vorhanden ist). Ein funktional identischer Aufruf mit der neuen Signatur sieht so aus:
AddClone(sourceSlide, destMaster, false);

Wenn fehlende Layouts automatisch geklont werden sollen, anstatt eine PptxEditException auszulösen, übergeben Sie den Parameter allowCloneMissingLayout mit dem Wert true.

Das Gleiche gilt für die ISlideCollection‑Methode:

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster);

ist ebenfalls veraltet und wurde ersetzt durch die Signatur

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout);
#### **Typ der Aspose.Slides.IMasterSlide.LayoutSlides Eigenschaft**
Der Typ der Eigenschaft Aspose.Slides.IMasterSlide.LayoutSlides wurde von ILayoutSlideCollection zu der neuen Schnittstelle IMasterLayoutSlideCollection geändert. Die Schnittstelle IMasterLayoutSlideCollection ist ein Nachfolger von ILayoutSlideCollection, sodass vorhandener Code keine Anpassungen benötigt.
#### **Typ der Aspose.Slides.IPresentation.LayoutSlides Eigenschaft wurde geändert**
Der Typ der Eigenschaft Aspose.Slides.IPresentation.LayoutSlides wurde von ILayoutSlideCollection zu der neuen Schnittstelle IGlobalLayoutSlideCollection geändert. Die Schnittstelle IGlobalLayoutSlideCollection ist ein Nachfolger von ILayoutSlideCollection, sodass vorhandener Code keine Anpassungen benötigt.