---
title: Veřejné API a zpětně nekompatibilní změny v Aspose.Slides pro .NET 14.5.0
linktitle: Aspose.Slides pro .NET 14.5.0
type: docs
weight: 70
url: /cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/
keywords:
- migrace
- legacy kód
- moderní kód
- legacy přístup
- moderní přístup
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Prohlédněte si aktualizace veřejného API a nekompatibilní změny v Aspose.Slides pro .NET, abyste hladce migrovali vaše řešení prezentací PowerPoint PPT, PPTX a ODP."
---
{{% alert color="info" %}} 

Tato stránka uvádí všechny [přidané](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) třídy, metody, vlastnosti a podobně, všechny nové [omezení](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) a další [změny](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) zavedené v API Aspose.Slides pro .NET 14.5.0.

{{% /alert %}} 
## **Veřejné API a zpětně nekompatibilní změny**
### **Přidané rozhraní, třídy, vlastnosti a metody**
#### **Přidáno rozhraní Aspose.Slides.IPresentationInfo a třída PresentationInfo**
Představuje informace o prezentaci.

- Vlastnost typu Boolean IsEncrypted vrací True, pokud je prezentace šifrována, jinak vrací False.
- Vlastnost LoadFormat získává typ prezentace.
#### **Přidána vlastnost Aspose.Slides.IShape.IsGrouped**
Vlastnost Aspose.Slides.IShape.IsGrouped určuje, zda je tvar seskupen.
#### **Přidána vlastnost Aspose.Slides.IShape.ParentGroup**
Vlastnost Aspose.Slides.IShape.ParentGroup vrací objekt nadřazeného GroupShape, pokud je tvar seskupen. V opačném případě vrací null.
#### **Přidána metoda Aspose.Slides.IShapeCollection.AddGroupShape()**
Metoda Aspose.Slides.IShapeCollection.AddGroupShape() vytvoří nový GroupShape a přidá jej na konec kolekce.
Velikost a pozice rámce GroupShape budou přizpůsobeny obsahu, když je přidán nový tvar.
#### **Přidána metoda Aspose.Slides.IShapeCollection.Clear()**
Metoda Aspose.Slides.IShapeCollection.Clear() odstraní všechny tvary z kolekce.
#### **Přidána metoda Aspose.Slides.IShapeCollection.InsertGroupShape(int)**
Metoda Aspose.Slides.IShapeCollection.InsertGroupShape(int) vytvoří nový GroupShape a vloží jej do kolekce na zadanou indexovou pozici.
Velikost a pozice rámce GroupShape budou přizpůsobeny obsahu, když je přidán nový tvar.
#### **Přidány metody IPresentationFactory.GetPresentationInfo(string file), IPresentatoinFactory.GetPresentationInfo(Stream stream)**
Tyto metody umožňují získat informace o souboru nebo proudu prezentace bez kompletního načtení prezentace.
#### **Přidána vlastnost IPresentationFactory PresentationFactory.Instance**
Tato vlastnost umožňuje vývojářům používat funkčnost továrny bez vytvoření instance.
### **Omezení**
#### **Omezení pro IShape.Frame**
Byla přidána omezení pro použití nedefinovaných hodnot pro IShape.Frame. Kód, který se pokouší přiřadit nedefinovaný rámec k IShape.Frame, nedává ve většině případů smysl (zejména když je nadřazený GroupShape několikrát vnořen do dalších {{GroupShape}}s). Například:

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
IShape shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

// Vyhodí ArgumentException: hodnoty rámce musí být definovány.
shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);
``` 

or

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// Vyhodí ArgumentException: x, y, šířka a výška musí být definovány.
slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);
``` 

Takový kód může vést k nejasným situacím. Proto byla přidána omezení pro použití nedefinovaných hodnot pro IShape.Frame. Hodnoty x, y, šířka, výška, flipH, flipV a rotationAngle musí být definovány (a nesmí být nastaveny na float.NaN nebo NullableBool.NotDefined). Výše uvedený příklad kódu nyní vyvolá výjimku ArgumentException.
Toto se týká následujících případů použití:

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Parametry x, y, šířka a výška nesmí být float.NaN, a flipH, flipV
// nesmí být NullableBool.NotDefined:
IShape shape = shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
shape.Frame = new ShapeFrame(100, 100, 200, 100, NullableBool.False, NullableBool.False, 0);

// Stejné omezení platí pro každou metodu, která vytváří tvar:
// AddAudioFrameCD, AddAudioFrameEmbedded, AddAudioFrameLinked, AddAutoShape, AddChart,
// AddConnector, AddOleObjectFrame, AddPictureFrame, AddSmartArt, AddTable, AddVideoFrame,
// InsertAudioFrameEmbedded, InsertAudioFrameLinked, InsertAutoShape, InsertChart,
// InsertConnector, InsertOleObjectFrame, InsertPictureFrame, InsertTable, InsertVideoFrame.
``` 

Avšak vlastnosti rámce IShape.RawFrame mohou být nedefinované. To má smysl, když je tvar propojen s zástupcem. Pak jsou nedefinované hodnoty rámce tvaru přepsány hodnotami nadřazeného zástupce. Pokud neexistuje nadřazený zástupce, pak tvar použije výchozí hodnoty při vyhodnocování efektivního rámce na základě jeho IShape.RawFrame. Výchozí hodnoty jsou 0 a NullableBool.False pro x, y, šířku, výšku, flipH, flipV a rotationAngle. Například:

``` csharp
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Tvar je propojen se zástupcem
    IShape shape = presentation.Slides[0].Shapes[0];

    shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);

    // nyní tvar dědí hodnoty x, y, výška, flipH, flipV ze zástupce a přepíše šířku=100 a rotationAngle=0.
}
``` 
### **Změněné vlastnosti**
#### **Změněn název a typ vlastnosti Aspose.Slides.IShapeCollection.Parent**
- Typ vlastnosti Aspose.Slides.IShapeCollection.Parent byl změněn z ISlideComponent na nové rozhraní IGroupShape. Rozhraní IGroupShape je potomkem ISlideComponent, takže stávající kód nevyžaduje úpravy.
- Název vlastnosti Aspose.Slides.IShapeCollection.Parent byl změněn z Parent na ParentGroup.
#### **Změněny typy vlastností Aspose.Slides.IShapeFrame.FlipH a .FlipV**
- Typ vlastnosti Aspose.Slides.IShapeFrame.FlipH byl změněn z bool na NullableBool.
- Vlastnost IShape.Frame vrací efektivní instanci IShapeFrame (všechny její vlastnosti mají definované efektivní hodnoty).
- Vlastnost IShape.RawFrame vrací instanci IShapeFrame, jejíž jednotlivé vlastnosti mohou mít nedefinovanou hodnotu (zejména FlipH nebo FlipV mohou mít hodnotu NullableBool.NotDefined).