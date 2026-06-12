---
title: Veřejné API a zpětně nekompatibilní změny v Aspose.Slides pro .NET 14.5.0
linktitle: Aspose.Slides pro .NET 14.5.0
type: docs
weight: 70
url: /cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/
keywords:
- migrace
- zastaralý kód
- moderní kód
- zastaralý přístup
- moderní přístup
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Prohlédněte si aktualizace veřejného API a zásadní změny v Aspose.Slides pro .NET, abyste hladce migrovali svá řešení prezentací PowerPoint PPT, PPTX a ODP."
---
{{% alert color="primary" %}} 

Tato stránka uvádí všechny [přidáno](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) třídy, metody, vlastnosti a podobně, všechny nové [omezení](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) a další [změny](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) zavedené v API Aspose.Slides pro .NET 14.5.0.

{{% /alert %}} 
## **Veřejné API a zpětně nekompatibilní změny**
### **Přidáno rozhraní, třídy, vlastnosti a metody**
#### **Přidáno rozhraní Aspose.Slides.IPresentationInfo a třída PresentationInfo**
Reprezentuje informace o prezentaci.

- Boolovská vlastnost IsEncrypted vrací True, pokud je prezentace šifrována, jinak vrací False.
- Vlastnost LoadFormat vrací typ prezentace.
#### **Přidána vlastnost Aspose.Slides.IShape.IsGrouped**
Vlastnost Aspose.Slides.IShape.IsGrouped určuje, zda je tvar seskupen.
#### **Přidána vlastnost Aspose.Slides.IShape.ParentGroup**
Vlastnost Aspose.Slides.IShape.ParentGroup vrací objekt GroupShape rodiče, pokud je tvar seskupen. Jinak vrací null.
#### **Přidána metoda Aspose.Slides.IShapeCollection.AddGroupShape()**
Metoda Aspose.Slides.IShapeCollection.AddGroupShape() vytvoří nový GroupShape a přidá jej na konec kolekce. Velikost a pozice rámce GroupShape se přizpůsobí obsahu při přidání nového tvaru.
#### **Přidána metoda Aspose.Slides.IShapeCollection.Clear()**
Metoda Aspose.Slides.IShapeCollection.Clear() odstraní všechny tvary z kolekce.
#### **Přidána metoda Aspose.Slides.IShapeCollection.InsertGroupShape(int)**
Metoda Aspose.Slides.IShapeCollection.InsertGroupShape(int) vytvoří nový GroupShape a vloží jej do kolekce na určenou pozici indexu. Velikost a pozice rámce GroupShape se přizpůsobí obsahu při přidání nového tvaru.
#### **Přidány metody IPresentationFactory.GetPresentationInfo(string file), IPresentationFactory.GetPresentationInfo(Stream stream)**
Tyto metody umožňují získat informace o souboru nebo streamu prezentace bez úplného načtení prezentace.
#### **Přidána vlastnost IPresentationFactory PresentationFactory.Instance**
Tato vlastnost umožňuje vývojářům používat funkci továrny bez vytvoření instance.
### **Omezení**
#### **Omezení pro IShape.Frame**
Byla přidána omezení pro používání nedefinovaných hodnot u IShape.Frame. Kód, který se pokusí přiřadit nedefinovaný rámec do IShape.Frame, nedává ve většině případů smysl (zejména když je nadřazený GroupShape více úrovní vnořen do dalších {{GroupShape}}s). Například:

``` csharp

 IShape shape = ...;

shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);


``` 

nebo

``` csharp

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);

``` 

Takový kód může vést k nejasným situacím. Proto byla přidána omezení pro používání nedefinovaných hodnot u IShape.Frame. Hodnoty x, y, width, height, flipH, flipV a rotationAngle musí být definovány (a nesmí být nastaveny na float.NaN nebo NullableBool.NotDefined). Výše uvedený ukázkový kód nyní vyvolá výjimku ArgumentException.
Toto se vztahuje na následující případy použití:

``` csharp

 IShape shape = ...;

shape.Frame = ...; // Nelze být nedefinováno

IShapeCollection shapes = ...;

// parametry x, y, šířka, výška nemohou být float.NaN:

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

Ale vlastnosti rámce IShape.RawFrame mohou být nedefinované. To dává smysl, když je tvar propojen s placeholderem. Pak jsou nedefinované hodnoty rámce tvaru přepsány z nadřazeného placeholderu. Pokud nadřazený placeholder neexistuje, tvar použije výchozí hodnoty při výpočtu efektivního rámce na základě IShape.RawFrame. Výchozí hodnoty jsou 0 a NullableBool.False pro x, y, width, height, flipH, flipV a rotationAngle. Například:

``` csharp

 IShape shape = ...; // shape je propojen s placeholderem

shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);

// nyní shape dědí hodnoty x, y, height, flipH, flipV z placeholderu a přepisuje width=100 a rotationAngle=0.
``` 
### **Změněné vlastnosti**
#### **Změněn název a typ vlastnosti Aspose.Slides.IShapeCollection.Parent**
- Typ vlastnosti Aspose.Slides.IShapeCollection.Parent byl změněn z ISlideComponent na nové rozhraní IGroupShape. Rozhraní IGroupShape je potomkem ISlideComponent, takže stávající kód nevyžaduje úpravy.
- Název vlastnosti Aspose.Slides.IShapeCollection.Parent byl změněn z Parent na ParentGroup.
#### **Změněny typy vlastností Aspose.Slides.IShapeFrame.FlipH, .FlipV**
- Typ vlastnosti Aspose.Slides.IShapeFrame.FlipH byl změněn z bool na NullableBool.
- Vlastnost IShape.Frame vrací efektivní instanci IShapeFrame (všechna její vlastnosti mají definované efektivní hodnoty).
- Vlastnost IShape.RawFrame vrací instanci IShapeFrame, u které může mít každá vlastnost nedefinovanou hodnotu (zejména FlipH nebo FlipV může mít hodnotu NullableBool.NotDefined).