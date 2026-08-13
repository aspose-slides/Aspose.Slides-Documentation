---
title: "Veřejné API a zpětně nekompatibilní změny v Aspose.Slides pro Java 14.5.0"
linktitle: "Aspose.Slides pro Java 14.5.0"
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
description: "Prohlédněte si aktualizace veřejného API a breaking změny v Aspose.Slides pro Java, abyste hladce migrovali své řešení pro prezentace PowerPoint PPT, PPTX a ODP."
---
{{% alert color="info" %}} 

Tato stránka uvádí všechny [přidáno](/slides/cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) třídy, metody, vlastnosti a podobně, všechna nová [omezení](/slides/cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) a další [změny](/slides/cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) zavedené v API Aspose.Slides for Java 14.5.0.

{{% /alert %}} 
## **Veřejné API a zpětně nekompatibilní změny**
### **Přidané třídy a metody**
#### **Přidáno rozhraní Aspose.Slides.IPresentationInfo a třídy PresentationInfo**
Reprezentuje informace o prezentaci.

Metoda Boolean isEncrypted() vrací True, pokud je prezentace šifrovaná, jinak vrací False.

Metoda LoadFormat getLoadFormat() vrací typ prezentace.
#### **Přidána metoda Aspose.Slides.IShape.isGrouped()**
Metoda Aspose.Slides.IShape.isGrouped() určuje, zda je objekt seskupen.
#### **Přidána metoda Aspose.Slides.IShape.getParentGroup()**
Metoda Aspose.Slides.IShape.getParentGroup() vrací nadřazený objekt GroupShape, pokud je objekt seskupen. V opačném případě vrací null.
#### **Přidána metoda Aspose.Slides.IShapeCollection.addGroupShape()**
Metoda Aspose.Slides.IShapeCollection.addGroupShape() vytvoří nový GroupShape a přidá jej na konec kolekce.

Velikost a pozice rámce GroupShape bude přizpůsobena obsahu, když bude do GroupShape přidán nový objekt.
#### **Přidána metoda Aspose.Slides.IShapeCollection.clear()**
Metoda Aspose.Slides.IShapeCollection.clear() odstraní všechny objekty z kolekce.
#### **Přidána metoda Aspose.Slides.IShapeCollection.insertGroupShape(int)**
Metoda Aspose.Slides.IShapeCollection.insertGroupShape(int) vytvoří nový GroupShape a vloží jej do kolekce na zadaném indexu.
Velikost a pozice rámce GroupShape bude přizpůsobena obsahu, když bude do GroupShape přidán nový objekt.
#### **Přidány metody IPresentationFactory.getPresentationInfo(string file), IPresentationFactory.getPresentationInfo(InputStream stream)**
Tyto metody umožňují vývojářům získat informace o souboru/streamu prezentace bez úplného načtení prezentace.
#### **Přidána metoda IPresentationFactory PresentationFactory.getInstance()**
Umožňuje používat funkčnost továrny bez vytvoření instance.
### **Omezení**
#### **Byla zavedena omezení pro používání nedefinovaných hodnot pro IShape.getFrame()**
Kód, který se pokouší přiřadit nedefinovaný rámec pomocí IShape.setFrame(IShapeFrame), nedává v obecných případech smysl (zejména když je nadřazený GroupShape vícenásobně vnořen do dalších {{GroupShape}}). Například:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    // Vyvolá ArgumentException: hodnoty rámce musí být definovány.
    shape.setFrame(new ShapeFrame(Float.NaN, Float.NaN, Float.NaN, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, Float.NaN));
} finally {
    if (pres != null) pres.dispose();
}
```

nebo

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // Vyvolá ArgumentException: hodnoty x, y, šířka a výška musí být definovány.
    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, Float.NaN, Float.NaN, Float.NaN, Float.NaN);
} finally {
    if (pres != null) pres.dispose();
}
```

Takový kód může vést k nejasným situacím. Proto byla zavedena omezení pro používání nedefinovaných hodnot pro IShape.Frame. Hodnoty x, y, šířka, výška, flipH, flipV a rotationAngle musí být definovány (ne Float.NaN ani NullableBool.NotDefined). Výše uvedený ukázkový kód nyní vyvolá výjimku ArgumentException.
Toto se vztahuje na následující scénáře:

``` java
// Rámec předaný metodě IShape.setFrame(IShapeFrame) nemůže obsahovat nedefinované hodnoty.

// Parametry x, y, šířka a výška následujících metod IShapeCollection
// také nesmí být Float.NaN:
//
//     addAudioFrameCD
//     addAudioFrameEmbedded
//     addAudioFrameLinked
//     addAutoShape
//     addChart
//     addConnector
//     addOleObjectFrame
//     addPictureFrame
//     addSmartArt
//     addTable
//     addVideoFrame
//     insertAudioFrameEmbedded
//     insertAudioFrameLinked
//     insertAutoShape
//     insertChart
//     insertConnector
//     insertOleObjectFrame
//     insertPictureFrame
//     insertTable
//     insertVideoFrame
```

Ale rámec IShape.getRawFrame() může být nedefinovaný. To dává smysl, když je objekt propojen s placeholderem. Pak jsou nedefinované hodnoty rámce objektu přepsány z nadřazeného placeholderu. Pokud neexistuje nadřazený placeholder, použijí se výchozí hodnoty při výpočtu efektivního rámce na základě IShape.getRawFrame(). Výchozí hodnoty jsou 0 a NullableBool.False pro x, y, šířku, výšku, flipH, flipV a rotationAngle. Například:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    // Tvar je propojen s placeholderem.
    IShape shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);

    shape.setRawFrame(new ShapeFrame(Float.NaN, Float.NaN, 100, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0));

    // Nyní tvar dědí hodnoty x, y, výška, flipH a flipV z placeholderu
    // a přepisuje šířku = 100 a rotationAngle = 0.
} finally {
    if (pres != null) pres.dispose();
}
```
### **Změněné vlastnosti**
#### **Změněn typ a název metody Aspose.Slides.IShapeCollection.getParent()**
Typ vlastnosti Aspose.Slides.IShapeCollection.Parent byl změněn z ISlideComponent na rozhraní IGroupShape. Rozhraní IGroupShape je potomkem ISlideComponent, takže stávající kód nevyžaduje úpravy.

Název metody Aspose.Slides.IShapeCollection.getParent() byl změněn z getParent na getParentGroup().
#### **Změněn typ metod Aspose.Slides.IShapeFrame.getFlipH() a .getFlipV()**
Typ metody Aspose.Slides.IShapeFrame.getFlipH() byl změněn z bool na NullableBool.

Metoda IShape.getFrame() vrací efektivní instanci IShapeFrame (všechna jeho vlastnosti mají definované efektivní hodnoty).

Metoda IShape.getRawFrame() vrací instanci IShapeFrame, jejíž jednotlivé vlastnosti mohou mít nedefinovanou hodnotu (zejména FlipH nebo FlipV mohou mít hodnotu NullableBool.NotDefined).