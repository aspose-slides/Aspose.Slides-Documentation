---
title: Spravování konektorů v prezentacích na Androidu
linktitle: Konektor
type: docs
weight: 10
url: /cs/androidjava/connector/
keywords:
- konektor
- typ konektoru
- bod konektoru
- čára konektoru
- úhel konektoru
- propojit tvary
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Umožněte aplikacím v Javě kreslit, propojovat a automaticky směrovat čáry v PowerPoint slidech na Androidu — získejte plnou kontrolu nad přímými, loketními a zakřivenými konektory."
---
## **Úvod**

Konektor PowerPoint je speciální čára, která spojuje dva tvary a zůstává k tvarům připojená i při jejich přesunu nebo přemístění na konkrétním snímku.  

Konektory jsou obvykle připojeny k *bodům připojení* (zelené tečky), které jsou ve výchozím nastavení na všech tvarech. Body připojení se zobrazí, když se k nim kurzor přiblíží.  

*Úpravné body* (oranžové tečky), které existují jen u některých konektorů, slouží k úpravě polohy a tvaru konektorů.  

## **Typy konektorů**

V PowerPointu můžete použít přímé, loketní (úhlové) a zakřivené konektory.  

Aspose.Slides poskytuje následující konektory:

| Konektor                      | Obrázek                                                        | Počet úpravných bodů |
| ------------------------------ | ------------------------------------------------------------ | -------------------- |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                    |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                    |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                    |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                    |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                    |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                    |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                    |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                    |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                    |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                    |

## **Propojte tvary pomocí konektorů**

1. Vytvořte instanci třídy [Presentation](https://apireference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
1. Získejte referenci na snímek pomocí jeho indexu.
1. Přidejte na snímek dva [AutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/AutoShape) pomocí metody `addAutoShape`, kterou poskytuje objekt `Shapes`.
1. Přidejte konektor pomocí metody `addConnector`, kterou poskytuje objekt `Shapes`, a tím definujte typ konektoru.
1. Propojte tvary pomocí konektoru. 
1. Zavolejte metodu `reroute` pro použití nejkratší cesty připojení.
1. Uložte prezentaci. 

Tento Java kód ukazuje, jak přidat konektor (zakřivený konektor) mezi dva tvary (elipsu a obdélník):

```Java
// Vytvoří instanci třídy prezentace, která představuje soubor PPTX
Presentation pres = new Presentation();
try {
    // Přistupuje ke kolekci tvarů pro konkrétní snímek
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();
    
    // Přidá autoshape elipsu
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);
    
    // Přidá autoshape obdélník
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);
    
    // Přidá tvar konektoru do kolekce tvarů snímku
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
    
    // Propojí tvary pomocí konektoru
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    
    // Zavolá reroute, který nastaví automatickou nejkratší cestu mezi tvary
    connector.reroute();
    
    // Uloží prezentaci
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert title="NOTE"  color="warning"   %}} 
Metoda `Connector.reroute` přesměruje konektor a donutí jej zvolit nejkratší možnou cestu mezi tvary. Pro dosažení tohoto cíle může metoda změnit body `setStartShapeConnectionSiteIndex` a `setEndShapeConnectionSiteIndex`. 
{{% /alert %}} 

## **Určení bodu připojení**

Pokud chcete, aby konektor spojil dva tvary pomocí konkrétních bodů na tvarech, musíte zadat preferované body připojení tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
1. Získejte referenci na snímek pomocí jeho indexu.
1. Přidejte na snímek dva [AutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/AutoShape) pomocí metody `addAutoShape`, kterou poskytuje objekt `Shapes`.
1. Přidejte konektor pomocí metody `addConnector`, kterou poskytuje objekt `Shapes`, a tím definujte typ konektoru.
1. Propojte tvary pomocí konektoru. 
1. Nastavte své preferované body připojení na tvarech. 
1. Uložte prezentaci.

Tento Java kód demonstruje operaci, kde je specifikován preferovaný bod připojení:

```java
// Vytvoří instanci třídy prezentace, která představuje soubor PPTX
Presentation pres = new Presentation();
try {
    // Přistupuje ke kolekci tvarů pro konkrétní snímek
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();

    // Přidá autoshape elipsu
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Přidá autoshape obdélník
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // Přidá tvar konektoru do kolekce tvarů snímku
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // Propojí tvary pomocí konektoru
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    // Nastaví preferovaný index bodu připojení na tvaru elipsy
    int wantedIndex = 6;

    // Zkontroluje, zda je preferovaný index menší než maximální počet míst připojení
    if (ellipse.getConnectionSiteCount() > wantedIndex) 
    {
        // Nastaví preferovaný bod připojení na autoshape elipsy
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }

    // Uloží prezentaci
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Úprava bodu konektoru**

Můžete upravit existující konektor pomocí jeho úpravných bodů. Pouze konektory s úpravným body lze tímto způsobem měnit. Viz tabulka pod **[Typy konektorů.](/slides/cs/androidjava/connector/#types-of-connectors)**

### **Jednoduchý případ**

Zvažte případ, kdy konektor mezi dvěma tvary (A a B) prochází třetím tvarem (C):

![connector-obstruction](connector-obstruction.png)

```java
Presentation pres = new Presentation();
try {

    ISlide sld = pres.getSlides().get_Item(0);
    IShape shape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
    IShape shapeFrom = sld.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
    IShape shapeTo = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);

    IConnector connector = sld.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setStartShapeConnectionSiteIndex(2);
} finally {
    if (pres != null) pres.dispose();
}
```

Abychom třetí tvar obešli nebo obcházeli, můžeme konektor upravit tak, že posuneme jeho vertikální čáru doleva:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```java
IAdjustValue adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```

### **Složitější případy** 

Pro provedení složitějších úprav musíte brát v úvahu následující:

* Nastavitelný bod konektoru je úzce spojen s formulí, která vypočítává a určuje jeho polohu. Změna umístění bodu může změnit tvar konektoru.
* Úpravné body konektoru jsou v poli definovány v přísném pořadí. Úpravné body jsou číslovány od počátečního bodu konektoru po koncový.
* Hodnoty úpravných bodů vyjadřují procenta šířky/výšky tvaru konektoru. 
  * Tvar je omezený startovním a koncovým bodem konektoru vynásobeným 1000. 
  * První bod, druhý bod a třetí bod definují procento ze šířky, procento z výšky a opět procento ze šířky.
* Pro výpočty, které určují souřadnice úpravných bodů konektoru, musíte vzít v úvahu rotaci konektoru a jeho odražení. **Poznámka**, že úhel rotace všech konektorů uvedených pod **[Typy konektorů](/slides/cs/androidjava/connector/#types-of-connectors)** je 0.

#### **Případ 1**

Zvažte případ, kdy jsou dva objekty textového rámce propojeny konektorem:

![connector-shape-complex](connector-shape-complex.png)

```java
// Vytvoří instanci třídy prezentace, která představuje soubor PPTX
Presentation pres = new Presentation();
try {
    // Získá první snímek v prezentaci
    ISlide sld = pres.getSlides().get_Item(0);
    // Přidá tvary, které budou propojeny pomocí konektoru
    IAutoShape shapeFrom = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    shapeFrom.getTextFrame().setText("From");
    IAutoShape shapeTo = sld.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    shapeTo.getTextFrame().setText("To");
    // Přidá konektor
    IConnector connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    // Určuje směr konektoru
    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    // Určuje barvu konektoru
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
    // Určuje tloušťku čáry konektoru
    connector.getLineFormat().setWidth(3);
    
    // Propojí tvary pomocí konektoru
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setEndShapeConnectionSiteIndex(2);
    
    // Získá úpravné body konektoru
    IAdjustValue adjValue_0 = connector.getAdjustments().get_Item(0);
    IAdjustValue adjValue_1 = connector.getAdjustments().get_Item(1);

} finally {
    if (pres != null) pres.dispose();
}
```

**Úprava**

Můžeme změnit hodnoty úpravných bodů konektoru zvýšením odpovídajících procent ze šířky a výšky o 20 % a 200 % respektive:

```java
// Změní hodnoty úpravných bodů
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

Výsledek:

![connector-adjusted-1](connector-adjusted-1.png)

Abychom definovali model, který nám umožní určit souřadnice a tvar jednotlivých částí konektoru, vytvořme tvar, který odpovídá horizontální složce konektoru v bodě connector.getAdjustments().get_Item(0):

```java
// Vykreslí svislou komponentu konektoru
float x = connector.getX() + connector.getWidth() * adjValue_0.getRawValue() / 100000;
float y = connector.getY();
float height = connector.getHeight() * adjValue_1.getRawValue() / 100000;
sld.getShapes().addAutoShape( ShapeType .Rectangle, x, y, 0, height);
```

Výsledek:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Případ 2**

V **případě 1** jsme demonstrovali jednoduchou operaci úpravy konektoru pomocí základních principů. V běžných situacích musíte vzít v úvahu rotaci konektoru a jeho zobrazení (které jsou nastaveny pomocí connector.getRotation(), connector.getFrame().getFlipH() a connector.getFrame().getFlipV()). Nyní ukážeme celý postup.

Nejprve přidejme nový objekt textového rámce (**To 1**) na snímek (pro účely připojení) a vytvořme nový (zelený) konektor, který ho spojí s již vytvořenými objekty.

```java
// Vytvoří nový objekt vazby
IAutoShape shapeTo_1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.getTextFrame().setText("To 1");
// Vytvoří nový konektor
connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.CYAN);
connector.getLineFormat().setWidth(3);
// Propojí objekty pomocí nově vytvořeného konektoru
connector.setStartShapeConnectedTo(shapeFrom);
connector.setStartShapeConnectionSiteIndex(2);
connector.setEndShapeConnectedTo(shapeTo_1);
connector.setEndShapeConnectionSiteIndex(3);
// Získá úpravné body konektoru
adjValue_0 = connector.getAdjustments().get_Item(0);
adjValue_1 = connector.getAdjustments().get_Item(1);
// Změní hodnoty úpravných bodů
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

Výsledek:

![connector-adjusted-3](connector-adjusted-3.png)

Druhá část: vytvořme tvar, který bude odpovídat horizontální složce konektoru procházející úpravným bodem nového konektoru connector.getAdjustments().get_Item(0). Použijeme hodnoty z dat konektoru pro connector.getRotation(), connector.getFrame().getFlipH() a connector.getFrame().getFlipV() a aplikujeme běžný převodový vzorec pro rotaci kolem daného bodu x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

V našem případě je úhel rotace objektu 90 stupňů a konektor je zobrazen vertikálně, takže zde je odpovídající kód:

```java
// Uloží souřadnice konektoru
x = connector.getX();
y = connector.getY();
// Opraví souřadnice konektoru v případě, že se objeví
if (connector.getFrame().getFlipH() == NullableBool.True)
{
    x += connector.getWidth();
}
if (connector.getFrame().getFlipV() == NullableBool.True)
{
    y += connector.getHeight();
}
// Přijme hodnotu úpravného bodu jako souřadnici
x += connector.getWidth() * adjValue_0.getRawValue() / 100000;
//  Převádí souřadnice, protože Sin(90) = 1 a Cos(90) = 0
float xx = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
float yy = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
// Určuje šířku horizontální komponenty pomocí hodnoty druhého úpravného bodu
float width = connector.getHeight() * adjValue_1.getRawValue() / 100000;
IAutoShape shape = sld.getShapes().addAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
```

Výsledek:

![connector-adjusted-4](connector-adjusted-4.png)

Ukázali jsme výpočty zahrnující jednoduché úpravy i složité úpravy (úpravy s úhly rotace). S využitím získaných znalostí můžete vytvořit vlastní model (nebo napsat kód) pro získání objektu `GraphicsPath` nebo dokonce nastavit hodnoty úpravných bodů konektoru na základě konkrétních souřadnic snímku.

## **Zjištění úhlu čar konektoru**

1. Vytvořte instanci třídy.
1. Získejte referenci na snímek pomocí jeho indexu.
1. Získejte přístup k tvaru čáry konektoru.
1. Použijte šířku a výšku čáry, výšku a šířku rámce tvaru k výpočtu úhlu.

Tento Java kód demonstruje operaci, při které jsme vypočítali úhel pro tvar čáry konektoru:

```java
Presentation pres = new Presentation("ConnectorLineAngle.pptx");
try {
    Slide slide = (Slide)pres.getSlides().get_Item(0);
    
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        double dir = 0.0;
        Shape shape = (Shape)slide.getShapes().get_Item(i);
        if (shape instanceof AutoShape)
        {
            AutoShape ashp = (AutoShape)shape;
            if (ashp.getShapeType() == ShapeType.Line)
            {
                dir = getDirection(ashp.getWidth(), ashp.getHeight(),
                        ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
            }
        }
        else if (shape instanceof Connector)
        {
            Connector ashp = (Connector)shape;
            dir = getDirection(ashp.getWidth(), ashp.getHeight(),
                    ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
        }

        System.out.println(dir);
    }
} finally {
    if (pres != null) pres.dispose();
}
```

```java
public static double getDirection(float w, float h, boolean flipH, boolean flipV)
{
    float endLineX = w * (flipH ? -1 : 1);
    float endLineY = h * (flipV ? -1 : 1);
    float endYAxisX = 0;
    float endYAxisY = h;
    double angle = (Math.atan2(endYAxisY, endYAxisX) - Math.atan2(endLineY, endLineX));
    if (angle < 0) angle += 2 * Math.PI;
    return angle * 180.0 / Math.PI;
}
```

## **FAQ**

**Jak zjistit, zda lze konektor „přilepit“ k určitému tvaru?**

Zkontrolujte, že tvar poskytuje [connection sites](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/shape/#getConnectionSiteCount--). Pokud žádné nejsou nebo je jejich počet nula, přilepení není k dispozici; v tom případě použijte volné koncové body a umístěte je ručně. Je rozumné před připojením zkontrolovat počet míst.

**Co se stane s konektorem, pokud smažu jeden z propojených tvarů?**

Jeho konce se odpojí; konektor zůstane na snímku jako běžná čára s volnými začátkem/koncem. Můžete jej buď smazat, nebo znovu přiřadit spojení a případně [reroute](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/connector/#reroute--).

**Zůstávají vazby konektoru zachovány při kopírování snímku do jiné prezentace?**

Obecně ano, pokud jsou také zkopírovány cílové tvary. Pokud je snímek vložen do jiného souboru bez propojených tvarů, konce se stanou volnými a budete je muset znovu připojit.