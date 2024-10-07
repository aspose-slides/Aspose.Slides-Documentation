---
title: Öffentliche API und nicht rückwärtskompatible Änderungen in Aspose.Slides für .NET 14.4.0
type: docs
weight: 60
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-4-0/
---

## **Öffentliche API und nicht rückwärtskompatible Änderungen**
### **Hinzugefügte Schnittstellen, Klassen, Methoden und Eigenschaften**
#### **Die Eigenschaft Aspose.Slides.ILayoutSlide.HasDependingSlides wurde hinzugefügt**
Die Eigenschaft Aspose.Slides.ILayoutSlide.HasDependingSlides gibt true zurück, wenn es mindestens eine Folie gibt, die von dieser Layoutfolie abhängt. Zum Beispiel:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Die Methode Aspose.Slides.ILayoutSlide.Remove()**
Die Methode Aspose.Slides.ILayoutSlide.Remove() ermöglicht es Ihnen, ein Layout mit minimalem Code aus einer Präsentation zu entfernen. Zum Beispiel:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Die Methode Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide)**
Die Methode Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide) ermöglicht es Ihnen, ein Layout aus der Sammlung zu entfernen. Codebeispiele:

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
Die Methode Aspose.Slides.ILayoutSlideCollection.RemoveUnused() ermöglicht es Ihnen, ungenutzte Layoutfolien (Layoutfolien, deren HasDependingSlides false ist) zu entfernen. Codebeispiele:

``` csharp

 presentation.LayoutSlides.RemoveUnused();

``` 

oder

``` csharp

 IMasterSlide masterSlide = ...;

masterSlide.LayoutSlides.RemoveUnused();

``` 
#### **Die Eigenschaft Aspose.Slides.IMasterSlide.HasDependingSlides**
Die Eigenschaft Aspose.Slides.IMasterSlide.HasDependingSlides gibt true zurück, wenn es mindestens eine Folie gibt, die von dieser Masterfolie abhängt. Zum Beispiel:

``` csharp

 IMasterSlide masterSlide = ...;

if (!masterSlide.HasDependingSlides)

    presentation.Masters.Remove(masterSlide);

``` 
#### **Die Methode Aspose.Slides.ISlide.Remove()**
Die Methode Aspose.Slides.ISlide.Remove() ermöglicht es Ihnen, eine Folie mit minimalem Code aus einer Präsentation zu entfernen. Zum Beispiel:

``` csharp

 ISlide slide = ...;

slide.Remove();

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat**
Die Eigenschaft Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat gibt IFillFormat für eine SmartArt-Knotenbullet zurück, wenn das Layout Bullets bereitstellt. Es kann verwendet werden, um das Bulletbild festzulegen.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-SmartArts-BulletFillFormat-BulletFillFormat.cs" >}}
#### **Die Eigenschaft Aspose.Slides.SmartArt.ISmartArtNode.Level**
Die Eigenschaft Aspose.Slides.SmartArt.ISmartArtNode.Level gibt die geschachtelte Ebene für SmartArt-Knoten zurück.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if(node.Level == 1)

    node.TextFrame.Text = "Erste Ebene";

``` 
#### **Die Eigenschaft Aspose.Slides.SmartArt.ISmartArtNode.Position**
Die Eigenschaft Aspose.Slides.SmartArt.ISmartArtNode.Position gibt die Position eines Knotens unter seinen Geschwistern zurück.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if (node.ChildNodes.Count > 3)

    node.ChildNodes[0].Position++;

``` 
#### **Die Methode Aspose.Slides.SmartArt.ISmartArtNode.Remove() wurde hinzugefügt**
Die Methode Aspose.Slides.SmartArt.ISmartArtNode.Remove() ermöglicht das Entfernen eines Knotens aus einem Diagramm.

``` csharp

 ISmartArt node = diagram.AllNodes[0];

node.Remove();

``` 
#### **Schnittstelle IGlobalLayoutSlideCollection und Klasse GlobalLayoutSlideCollection**
Die Schnittstelle IGlobalLayoutSlideCollection und die Klasse GlobalLayoutSlideCollection wurden in den Aspose.Slides-Namespace hinzugefügt.

Die Klasse GlobalLayoutSlideCollection implementiert die Schnittstelle IGlobalLayoutSlideCollection.

Die Schnittstelle IGlobalLayoutSlideCollection repräsentiert eine Sammlung aller Layoutfolien in einer Präsentation. Die IPresentation.LayoutSlides-Eigenschaft ist vom Typ IGlobalLayoutSlideCollection. IGlobalLayoutSlideCollection erweitert die ILayoutSlideCollection-Schnittstelle um Methoden zum Hinzufügen und Klonen von Layoutfolien im Kontext der Vereinigung der einzelnen Sammlungen der Master-Layoutfolien:

- ILayoutSlide AddClone(ILayoutSlide sourceLayout); – Kann verwendet werden, um eine Kopie einer angegebenen Layoutfolie zur Präsentation hinzuzufügen. Diese Methode behält das Quellformat bei (beim Klonen eines Layouts zwischen verschiedenen Präsentationen kann das Master des Layouts ebenfalls geklont werden. Das interne Register wird verwendet, um automatisch geklonte Master zu verfolgen, um die Erstellung mehrerer Klone der gleichen Masterfolie zu verhindern.)
- ILayoutSlide AddClone(ILayoutSlide sourceLayout, IMasterSlide destMaster); – Wird verwendet, um eine Kopie einer angegebenen Layoutfolie zur Präsentation hinzuzufügen. Das neue Layout wird mit dem definierten Master in der Zielpräsentation verknüpft. Diese Option ist analog zum Kopieren oder Einfügen mit der **Zielthema verwenden**-Option in Microsoft PowerPoint.
- ILayoutSlide Add(IMasterSlide master, SlideLayoutType layoutType, string layoutName); – Wird verwendet, um eine neue Layoutfolie zu einer Präsentation hinzuzufügen. Unterstützte Layouttypen: Titel, TitelNur, Leer, TitelUndObjekt, VertikalerText, VertikalerTitelUndText, ZweiObjekte, Abschnittsüberschrift, ZweiTextUndZweiObjekte, TitelObjektUndBeschriftung, BildUndBeschriftung, Benutzerdefiniert. Der Layoutname kann automatisch generiert werden. Ein hinzugefügtes Layout des Typs SlideLayoutType.Custom enthält keine Platzhalter und keine Formen. Ein analoges dieser Methode ist die IMasterLayoutSlideCollection.Add(SlideLayoutType, string)-Methode, die über die IMasterSlide.LayoutSlides-Eigenschaft aufgerufen werden kann.
#### **Schnittstelle IMasterLayoutSlideCollection und Klasse MasterLayoutSlideCollection**
Die Schnittstelle IMasterLayoutSlideCollection und die Klasse MasterLayoutSlideCollection wurden zum Aspose.Slides-Namespace hinzugefügt. Die MasterLayoutSlideCollection-Klasse implementiert die IMasterLayoutSlideCollection-Schnittstelle.

Die IMasterLayoutSlideCollection-Schnittstelle repräsentiert eine Sammlung aller Layoutfolien einer definierten Masterfolie. Sie erweitert die ILayoutSlideCollection-Schnittstelle um Methoden zum Hinzufügen, Einfügen, Entfernen oder Klonen von Layoutfolien im Kontext der einzelnen Sammlungen von Masterlayoutfolien:

``` csharp

 // Methodensignatur:

ILayoutSlide AddClone(ILayoutSlide sourceLayout);

// Codebeispiel, das eine Kopie von sourceLayout an destMasterSlide anfügt:

IMasterSlide destMasterSlide = ...;

destMasterSlide.LayoutSlides.AddClone(sourceLayout);

``` 

Die Methode kann verwendet werden, um eine Kopie einer angegebenen Layoutfolie am Ende der Sammlung hinzuzufügen. Das neue Layout wird mit der übergeordneten Masterfolie für diese Layoutfoliensammlung verknüpft. Dies ist also analog zum Kopieren oder Einfügen mit der **Zielthema verwenden**-Option in PowerPoint. Ein Analogon dieser Methode ist die Methode IGlobalLayoutSlideCollection.AddClone(ILayoutSlide, IMasterSlide), die über die IPresentation.LayoutSlides-Eigenschaft aufgerufen werden kann.

- ILayoutSlide InsertClone(int index, ILayoutSlide sourceLayout); – Wird verwendet, um eine Kopie einer angegebenen Layoutfolie an einen bestimmten Ort der Sammlung einzufügen. Das neue Layout wird mit der übergeordneten Masterfolie für diese Layoutfoliensammlung verknüpft. Dies ist also analog zum Kopieren und Einfügen mit der **Zielthema verwenden**-Option in PowerPoint.
- ILayoutSlide Add(SlideLayoutType layoutType, string layoutName);
- ILayoutSlide Insert(int index, SlideLayoutType layoutType, string layoutName); – Wird verwendet, um eine neue Layoutfolie hinzuzufügen oder einzufügen. Unterstützte Layouttypen: Titel, TitelNur, Leer, TitelUndObjekt, VertikalerText, VertikalerTitelUndText, ZweiObjekte, Abschnittsüberschrift, ZweiTextUndZweiObjekte, TitelObjektUndBeschriftung, BildUndBeschriftung, Benutzerdefiniert. Der Layoutname kann automatisch generiert werden. Ein hinzugefügtes Layout des Typs SlideLayoutType.Custom enthält keine Platzhalter und keine Formen. Ein Analogon dieser Methode ist die IGlobalLayoutSlideCollection.Add(IMasterSlide, SlideLayoutType, string)-Methode, die über die IPresentation.LayoutSlides-Eigenschaft aufgerufen werden kann.
- void RemoveAt(int index); – Wird verwendet, um das Layout an dem angegebenen Index der Sammlung zu entfernen.
- void Reorder(int index, ILayoutSlide layoutSlide); – Wird verwendet, um eine Layoutfolie aus der Sammlung an die angegebene Position zu verschieben.
### **Geänderte Methoden und Eigenschaften**
#### **Signatur der Methode Aspose.Slides.ISlideCollection.AddClone(ISlide, IMasterSlide)**
Die Signatur der ISlideCollection-Methode:
ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster);

ist jetzt veraltet und wird durch die Signatur

ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout)

ersetzt. Der Parameter allowCloneMissingLayout gibt an, was zu tun ist, wenn im destMaster für die neue (geklonte) Folie kein entsprechendes Layout vorhanden ist. Das entsprechende Layout ist das Layout mit dem gleichen Typ oder Namen wie das Layout der Quellfolie. Wenn im angegebenen Master kein entsprechendes Layout vorhanden ist, wird das Layout der Quellfolie geklont (wenn allowCloneMissingLayout true ist) oder es wird eine PptxEditException ausgelöst (wenn allowCloneMissingLayout false ist).

Der Aufruf der veralteten Methode wie

AddClone(sourceSlide, destMaster);

geht davon aus, dass allowCloneMissingLayout gleich false ist (das heißt, PptxEditException wird ausgelöst, wenn kein entsprechendes Layout vorhanden ist). Ein funktional identischer Aufruf, der die neue Signatur verwendet, sieht folgendermaßen aus:
AddClone(sourceSlide, destMaster, false);

Wenn Sie möchten, dass fehlende Layouts automatisch anstelle der Auslösung von PptxEditException geklont werden, übergeben Sie den Parameter allowCloneMissingLayout als true.

Das Gleiche gilt für die ISlideCollection-Methode:

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster);

ist ebenfalls veraltet und wird durch die Signatur

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout) ersetzt.
#### **Typ der Eigenschaft Aspose.Slides.IMasterSlide.LayoutSlides**
Der Typ der Eigenschaft Aspose.Slides.IMasterSlide.LayoutSlides wurde von ILayoutSlideCollection auf die neue IMasterLayoutSlideCollection-Schnittstelle geändert. Die IMasterLayoutSlideCollection-Schnittstelle ist eine Unterklasse von ILayoutSlideCollection, sodass bestehender Code keine Anpassungen benötigt.
#### **Typ der Eigenschaft Aspose.Slides.IPresentation.LayoutSlides wurde geändert**
Der Typ der Eigenschaft Aspose.Slides.IPresentation.LayoutSlides wurde von ILayoutSlideCollection auf die neue IGlobalLayoutSlideCollection-Schnittstelle geändert. Die IGlobalLayoutSlideCollection-Schnittstelle ist eine Unterklasse von ILayoutSlideCollection, sodass bestehender Code keine Anpassungen benötigt.