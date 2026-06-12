---
title: Veřejné API a zpětně nekompatibilní změny v Aspose.Slides pro Java 14.5.0
linktitle: Aspose.Slides pro Java 14.5.0
type: docs
weight: 40
url: /cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/
keywords:
- migrace
- starý kód
- moderní kód
- starý přístup
- moderní přístup
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Recenze veřejných aktualizací API a breaking changes v Aspose.Slides pro Java pro plynulou migraci vašich řešení prezentací PowerPoint PPT, PPTX a ODP."
---
{{% alert color="primary" %}} 
Tato stránka uvádí všechny [přidané](/slides/cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) třídy, metody, vlastnosti a podobně, všechny nové [omezení](/slides/cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) a další [změny](/slides/cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) zavedené v API Aspose.Slides pro Java 14.5.0.
{{% /alert %}} 
## **Veřejné API a zpětně nekompatibilní změny**
### **Přidané třídy a metody**
#### **Přidáno rozhraní Aspose.Slides.IPresentationInfo a třídy PresentationInfo**
Zastupuje informace o prezentaci.

Metoda Boolean isEncrypted() vrací True, pokud je prezentace šifrovaná, jinak vrací False.

Metoda LoadFormat getLoadFormat() vrací typ prezentace.
#### **Přidána metoda Aspose.Slides.IShape.isGrouped()**
Metoda Aspose.Slides.IShape.isGrouped() určuje, zda je tvar seskupen.
#### **Přidána metoda Aspose.Slides.IShape.getParentGroup()**
Metoda Aspose.Slides.IShape.getParentGroup() vrací objekt nadřazeného GroupShape, pokud je tvar seskupen. V opačném případě vrací null.
#### **Přidána metoda Aspose.Slides.IShapeCollection.addGroupShape()**
Metoda Aspose.Slides.IShapeCollection.addGroupShape() vytvoří nový GroupShape a přidá jej na konec kolekce.

Velikost a pozice rámce GroupShape bude přizpůsobena obsahu, když bude do GroupShape přidán nový tvar.
#### **Přidána metoda Aspose.Slides.IShapeCollection.clear()**
Metoda Aspose.Slides.IShapeCollection.clear() odstraní všechny tvary z kolekce.
#### **Přidána metoda Aspose.Slides.IShapeCollection.insertGroupShape(int)**
Metoda Aspose.Slides.IShapeCollection.insertGroupShape(int) vytvoří nový GroupShape a vloží jej do kolekce na zadaný index.

Velikost a pozice rámce GroupShape bude přizpůsobena obsahu, když bude do GroupShape přidán nový tvar.
#### **Přidány metody IPresentationFactory.getPresentationInfo(string file), IPresentatoinFactory.getPresentationInfo(InputStream stream)**
Tyto metody umožňují vývojářům získat informace o souboru/streamu prezentace bez úplného načtení prezentace.
#### **Přidána metoda IPresentationFactory PresentationFactory.getInstance()**
Umožňuje použít funkci továrny bez vytvoření instance.
### **Omezení**
#### **Byla přidána omezení pro používání nedefinovaných hodnot v IShape.getFrame()**
Kód, který se pokouší přiřadit nedefinovaný rámec metodě IShape.setFrame(IShapeFrame), nedává smysl v obecných případech (zejména když je nadřazený GroupShape víceúrovňově vnořen do dalších {{GroupShape}}). Například:

``` java

 IShape shape = ...;

shape.setFrame(new ShapeFrame(Float.NaN, Float.NaN, Float.NaN, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, Float.NaN));

```

or

``` java

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, Float.NaN, Float.NaN, Float.NaN, Float.NaN);

```

Takový kód může vést k nejasným situacím. Proto byla přidána omezení pro používání nedefinovaných hodnot v IShape.Frame. Hodnoty x, y, šířka, výška, flipH, flipV a rotationAngle musí být definovány (nesmí být Float.NaN ani NullableBool.NotDefined). Výše uvedený ukázkový kód nyní vyvolává výjimku ArgumentException.
Toto se vztahuje na následující případy použití:

``` java

 IShape shape = ...;

shape.setFrame(...); // nemůže být nedefinováno

IShapeCollection shapes = ...;

// parametry x, y, šířka, výška nemohou být Float.NaN:

{

    shapes.addAudioFrameCD(...);

    shapes.addAudioFrameEmbedded(...);

    shapes.addAudioFrameLinked(...);

    shapes.addAutoShape(...);

    shapes.addChart(...);

    shapes.addConnector(...);

    shapes.addOleObjectFrame(...);

    shapes.addPictureFrame(...);

    shapes.addSmartArt(...);

    shapes.addTable(...);

    shapes.addVideoFrame(...);

    shapes.insertAudioFrameEmbedded(...);

    shapes.insertAudioFrameLinked(...);

    shapes.insertAutoShape(...);

    shapes.insertChart(...);

    shapes.insertConnector(...);

    shapes.insertOleObjectFrame(...);

    shapes.insertPictureFrame(...);

    shapes.insertTable(...);

    shapes.insertVideoFrame(...);

}
```

Avšak rámec IShape.getRawFrame() může být nedefinovaný. To má smysl, když je tvar propojen s placeholderem. Pak jsou nedefinované hodnoty rámce tvaru přepsány hodnotami z nadřazeného placeholderu. Pokud pro daný tvar neexistuje nadřazený placeholder, použijí se výchozí hodnoty při výpočtu efektivního rámce na základě IShape.getRawFrame(). Výchozí hodnoty jsou 0 a NullableBool.False pro x, y, šířku, výšku, flipH, flipV a rotationAngle. Například:

``` java

 IShape shape = ...; // tvar je propojen s placeholderem

shape.setRawFrame(new ShapeFrame(Float.NaN, Float.NaN, 100, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0));

// nyní tvar dědí hodnoty x, y, výška, flipH, flipV z placeholderu a přepisuje šířku=100 a rotationAngle=0.

```
### **Změněné vlastnosti**
#### **Změněn typ a název metody Aspose.Slides.IShapeCollection.getParent()**
Typ vlastnosti Aspose.Slides.IShapeCollection.Parent byl změněn z ISlideComponent na nové rozhraní IGroupShape. Rozhraní IGroupShape je potomkem ISlideComponent, takže stávající kód nevyžaduje úpravy.

Název metody Aspose.Slides.IShapeCollection.getParent() byl změněn z getParent na getParentGroup().
#### **Změna typu metod Aspose.Slides.IShapeFrame.getFlipH() a .getFlipV()**
Typ metody Aspose.Slides.IShapeFrame.getFlipH() byl změněn z bool na NullableBool.

Metoda IShape.getFrame() vrací efektivní instanci IShapeFrame (všechny její vlastnosti mají definované efektivní hodnoty).

Metoda IShape.getRawFrame() vrací instanci IShapeFrame, jejíž jednotlivé vlastnosti mohou mít nedefinovanou hodnotu (zejména FlipH nebo FlipV mohou mít hodnotu NullableBool.NotDefined).