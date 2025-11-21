---
title: "Öffentliche API und rückwärtsinkompatible Änderungen in Aspose.Slides für .NET 14.4.0"
linktitle: "Aspose.Slides für .NET 14.4.0"
type: docs
weight: 60
url: /de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-4-0/
keywords:
  - Migration
  - Altkodes
  - Moderner Code
  - Alte Vorgehensweise
  - Moderne Vorgehensweise
  - PowerPoint
  - OpenDocument
  - Präsentation
  - .NET
  - C#
  - Aspose.Slides
description: "Überprüfen Sie die Aktualisierungen der öffentlichen API und die Breaking Changes in Aspose.Slides für .NET, um Ihre PowerPoint‑PPT, PPTX‑ und ODP‑Präsentationslösungen reibungslos zu migrieren."
---

## **Public API und rückwärtsinkompatible Änderungen**
### **Hinzugefügte Schnittstellen, Klassen, Methoden und Eigenschaften**
#### **Aspose.Slides.ILayoutSlide.HasDependingSlides property wurde hinzugefügt**
Die Eigenschaft Aspose.Slides.ILayoutSlide.HasDependingSlides gibt true zurück, wenn mindestens eine Folie von dieser Layoutfolie abhängt. Zum Beispiel:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Aspose.Slides.ILayoutSlide.Remove() Methode**
Die Methode Aspose.Slides.ILayoutSlide.Remove() ermöglicht das Entfernen eines Layouts aus einer Präsentation mit minimalem Code. Zum Beispiel:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide) Methode**
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
#### **Aspose.Slides.ILayoutSlideCollection.RemoveUnused() Methode**
Die Methode Aspose.Slides.ILayoutSlideCollection.RemoveUnused() ermöglicht das Entfernen nicht verwendeter Layoutfolien (Layoutfolien, deren HasDependingSlides false ist). Codebeispiele:

``` csharp

 presentation.LayoutSlides.RemoveUnused();

``` 

oder

``` csharp

 IMasterSlide masterSlide = ...;

masterSlide.LayoutSlides.RemoveUnused();

``` 
#### **Aspose.Slides.IMasterSlide.HasDependingSlides-Eigenschaft**
Die Eigenschaft Aspose.Slides.IMasterSlide.HasDependingSlides gibt true zurück, wenn mindestens eine Folie von dieser Masterfolie abhängt. Zum Beispiel:

``` csharp

 IMasterSlide masterSlide = ...;

if (!masterSlide.HasDependingSlides)

    presentation.Masters.Remove(masterSlide);

``` 
#### **Aspose.Slides.ISlide.Remove() Methode**
Die Methode Aspose.Slides.ISlide.Remove() ermöglicht das Entfernen einer Folie aus einer Präsentation mit minimalem Code. Zum Beispiel:

``` csharp

 ISlide slide = ...;

slide.Remove();

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat**
Die Eigenschaft Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat gibt IFillFormat für ein SmartArt‑Knoten‑Aufzählungszeichen zurück, wenn das Layout Aufzählungszeichen bereitstellt. Sie kann verwendet werden, um das Aufzählungszeichen‑Bild festzulegen.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-SmartArts-BulletFillFormat-BulletFillFormat.cs" >}}
#### **Aspose.Slides.SmartArt.ISmartArtNode.Level-Eigenschaft**
Die Eigenschaft Aspose.Slides.SmartArt.ISmartArtNode.Level gibt die verschachtelte Ebene für SmartArt‑Knoten zurück.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if(node.Level == 1)

    node.TextFrame.Text = "First level";

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.Position-Eigenschaft**
Die Eigenschaft Aspose.Slides.SmartArt.ISmartArtNode.Position gibt die Position eines Knotens unter seinen Geschwistern zurück.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if (node.ChildNodes.Count > 3)

    node.ChildNodes[0].Position++;

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.Remove() Methode wurde hinzugefügt**
Die Methode Aspose.Slides.SmartArt.ISmartArtNode.Remove() ermöglicht das Entfernen eines Knotens aus einem Diagramm.

``` csharp

 ISmartArt node = diagram.AllNodes[0];

node.Remove();

``` 
#### **IGlobalLayoutSlideCollection‑Schnittstelle und GlobalLayoutSlideCollection‑Klasse**
Die IGlobalLayoutSlideCollection‑Schnittstelle und die GlobalLayoutSlideCollection‑Klasse wurden dem Namespace Aspose.Slides hinzugefügt.

Die GlobalLayoutSlideCollection‑Klasse implementiert die IGlobalLayoutSlideCollection‑Schnittstelle.

Die IGlobalLayoutSlideCollection‑Schnittstelle stellt eine Sammlung aller Layoutfolien in einer Präsentation dar. Die IPresentation.LayoutSlides‑Eigenschaft ist vom Typ IGlobalLayoutSlideCollection. IGlobalLayoutSlideCollection erweitert die ILayoutSlideCollection‑Schnittstelle um Methoden zum Hinzufügen und Klonen von Layoutfolien im Kontext der Vereinigung einzelner Sammlungen von Master‑Layoutfolien:

- ILayoutSlide AddClone(ILayoutSlide sourceLayout); – Kann verwendet werden, um eine Kopie einer angegebenen Layoutfolie zur Präsentation hinzuzufügen. Diese Methode behält die Quellformatierung bei (wenn ein Layout zwischen verschiedenen Präsentationen geklont wird, kann auch der Master des Layouts geklont werden. Das interne Register wird verwendet, um automatisch geklonte Master zu verfolgen und die Erstellung mehrerer Klone desselben Master‑Slides zu verhindern).
- ILayoutSlide AddClone(ILayoutSlide sourceLayout, IMasterSlide destMaster); – Wird verwendet, um eine Kopie einer angegebenen Layoutfolie zu einer Präsentation hinzuzufügen. Das neue Layout wird mit dem definierten Master in der Zielpräsentation verknüpft. Diese Option entspricht dem Kopieren oder Einfügen mit der **Use Destination Theme**‑Option in Microsoft PowerPoint.
- ILayoutSlide Add(IMasterSlide master, SlideLayoutType layoutType, string layoutName); – Wird verwendet, um ein neues Layout zur Präsentation hinzuzufügen. Unterstützte Layout‑Typen: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom. Der Layout‑Name kann automatisch erzeugt werden. Ein hinzugefügtes Layout vom Typ SlideLayoutType.Custom enthält keine Platzhalter und keine Formen. Ein Äquivalent zu dieser Methode ist die IMasterLayoutSlideCollection.Add(SlideLayoutType, string)‑Methode, die über die IMasterSlide.LayoutSlides‑Eigenschaft aufgerufen wird.
#### **IMasterLayoutSlideCollection‑Schnittstelle und MasterLayoutSlideCollection‑Klasse**
Die IMasterLayoutSlideCollection‑Schnittstelle und die MasterLayoutSlideCollection‑Klasse wurden dem Namespace Aspose.Slides hinzugefügt. Die MasterLayoutSlideCollection‑Klasse implementiert die IMasterLayoutSlideCollection‑Schnittstelle.

Die IMasterLayoutSlideCollection‑Schnittstelle stellt eine Sammlung aller Layoutfolien eines definierten Masters dar. Sie erweitert die ILayoutSlideCollection‑Schnittstelle um Methoden zum Hinzufügen, Einfügen, Entfernen oder Klonen von Layoutfolien im Kontext der einzelnen Sammlungen von Master‑Layoutfolien:

``` csharp

 // Method signature:

ILayoutSlide AddClone(ILayoutSlide sourceLayout);

// Code example that attaches copy of the sourceLayout to the destMasterSlide:

IMasterSlide destMasterSlide = ...;

destMasterSlide.LayoutSlides.AddClone(sourceLayout);

``` 

Die Methode kann verwendet werden, um eine Kopie einer angegebenen Layoutfolie am Ende der Sammlung hinzuzufügen. Das neue Layout wird mit dem übergeordneten Master‑Slide für diese Layout‑Sammlung verknüpft. Dies entspricht dem Kopieren oder Einfügen mit der **Use Destination Theme**‑Option in PowerPoint. Ein Äquivalent zu dieser Methode ist die IGlobalLayoutSlideCollection.AddClone(ILayoutSlide, IMasterSlide)‑Methode, die über die IPresentation.LayoutSlides‑Eigenschaft aufgerufen wird.

- ILayoutSlide InsertClone(int index, ILayoutSlide sourceLayout); – Wird verwendet, um eine Kopie einer angegebenen Layoutfolie an einer bestimmten Position in die Sammlung einzufügen. Das neue Layout wird mit dem übergeordneten Master‑Slide für diese Layout‑Sammlung verknüpft. Dies entspricht dem Kopieren und Einfügen mit der **Use Destination Theme**‑Option in PowerPoint.
- ILayoutSlide Add(SlideLayoutType layoutType, string layoutName);
- ILayoutSlide Insert(int index, SlideLayoutType layoutType, string layoutName); – Wird verwendet, um ein neues Layout hinzuzufügen oder einzufügen. Unterstützte Layout‑Typen: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom. Der Layout‑Name kann automatisch erzeugt werden. Ein hinzugefügtes Layout vom Typ SlideLayoutType.Custom enthält keine Platzhalter und keine Formen. Ein Äquivalent zu dieser Methode ist die IGlobalLayoutSlideCollection.Add(IMasterSlide, SlideLayoutType, string)‑Methode, die über die IPresentation.LayoutSlides‑Eigenschaft aufgerufen wird.
- void RemoveAt(int index); – Wird verwendet, um das Layout am angegebenen Index aus der Sammlung zu entfernen.
- void Reorder(int index, ILayoutSlide layoutSlide); – Wird verwendet, um ein Layout in der Sammlung an die angegebene Position zu verschieben.
### **Geänderte Methoden und Eigenschaften**
#### **Signatur der Aspose.Slides.ISlideCollection.AddClone(ISlide, IMasterSlide) Methode**
Die Signatur der ISlideCollection‑Methode:
ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster);

ist jetzt veraltet und wurde ersetzt durch die Signatur

ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout)

Der Parameter allowCloneMissingLayout gibt an, was zu tun ist, wenn im destMaster kein passendes Layout für die neue (geklonte) Folie vorhanden ist. Das passende Layout ist das Layout mit demselben Typ oder Namen wie das Layout der Quellfolie. Existiert kein passendes Layout im angegebenen Master, wird das Layout der Quellfolie geklont (wenn allowCloneMissingLayout true ist) oder es wird eine PptxEditException ausgelöst (wenn allowCloneMissingLayout false ist).

Ein Aufruf der veralteten Methode wie

AddClone(sourceSlide, destMaster);

setzt allowCloneMissingLayout implizit auf false (d. h. eine PptxEditException wird ausgelöst, wenn kein passendes Layout existiert). Ein funktional identischer Aufruf mit neuer Signatur sieht so aus:
AddClone(sourceSlide, destMaster, false);

Möchten Sie fehlende Layouts automatisch klonen, anstatt eine PptxEditException zu werfen, übergeben Sie den Parameter allowCloneMissingLayout als true.

Dasselbe gilt für die ISlideCollection‑Methode:

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster);

ist ebenfalls veraltet und wurde ersetzt durch die Signatur

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout);
#### **Typ der Aspose.Slides.IMasterSlide.LayoutSlides‑Eigenschaft**
Der Typ der Aspose.Slides.IMasterSlide.LayoutSlides‑Eigenschaft wurde von ILayoutSlideCollection zu der neuen IMasterLayoutSlideCollection‑Schnittstelle geändert. Die IMasterLayoutSlideCollection‑Schnittstelle ist ein Nachfolger der ILayoutSlideCollection, sodass vorhandener Code keine Anpassungen benötigt.
#### **Typ der Aspose.Slides.IPresentation.LayoutSlides‑Eigenschaft wurde geändert**
Der Typ der Aspose.Slides.IPresentation.LayoutSlides‑Eigenschaft wurde von ILayoutSlideCollection zu der neuen IGlobalLayoutSlideCollection‑Schnittstelle geändert. Die IGlobalLayoutSlideCollection‑Schnittstelle ist ein Nachfolger der ILayoutSlideCollection, sodass vorhandener Code keine Anpassungen benötigt.