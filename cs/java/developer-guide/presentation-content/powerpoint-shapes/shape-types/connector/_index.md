---
title: Správa konektorů v prezentacích pomocí Java
linktitle: Konektor
type: docs
weight: 10
url: /cs/java/connector/
keywords:
- konektor
- typ konektoru
- bod konektoru
- čára konektoru
- úhel konektoru
- propojit tvary
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Umožněte aplikacím Java kreslit, propojit a automaticky vést čáry v snímcích PowerPoint—získejte plnou kontrolu nad přímými, loketními a zakřivenými konektory."
---
## **Úvod**

Konektor PowerPoint je speciální čára, která propojuje nebo spojuje dva tvary a zůstává připojen k tvarům i při jejich přesunu nebo přemístění na daném snímku. 

Konektory jsou obvykle připojeny k *připojovacím bodům* (zelené tečky), které jsou ve výchozím nastavení k dispozici na všech tvarech. Připojovací body se zobrazí, když se k nim kurzor přiblíží.

*Úpravové body* (oranžové tečky), které existují jen u některých konektorů, slouží k úpravě polohy a tvaru konektorů.

## **Typy konektorů**

V PowerPointu můžete použít přímé, loketní (úhlové) a zakřivené konektory. 

Aspose.Slides poskytuje tyto konektory:

| Konektor | Obrázek | Počet úpravových bodů |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                           |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                           |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                           |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                           |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                           |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                           |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                           |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                           |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                           |

## **Propojení tvarů pomocí konektorů**

1. Vytvořte instanci třídy [Presentation](https://apireference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
2. Získejte referenci na snímek pomocí jeho indexu.
3. Přidejte do snímku dva [AutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/AutoShape) pomocí metody `addAutoShape`, která je součástí objektu `Shapes`.
4. Přidejte konektor pomocí metody `addConnector`, která je součástí objektu `Shapes`, a definujte typ konektoru.
5. Propojte tvary pomocí konektoru. 
6. Zavolejte metodu `reroute` pro použití nejkratší cesty propojení.
7. Uložte prezentaci. 

Tento Java kód ukazuje, jak přidat konektor (ohnutý konektor) mezi dva tvary (elipsu a obdélník):

```Java
// Vytvoří instanci třídy Presentation, která představuje soubor PPTX
Presentation pres = new Presentation();
try {
    // Přistupuje ke kolekci tvarů konkrétního snímku
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();
    
    // Přidá eliptický autoshape
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);
    
    // Přidá obdélníkový autoshape
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

{{%  alert title="POZNÁMKA"  color="warning"   %}} 

Metoda `Connector.reroute` přesměruje konektor a vynutí, aby zvolil nejkratší možnou cestu mezi tvary. K dosažení tohoto cíle může metoda změnit body `setStartShapeConnectionSiteIndex` a `setEndShapeConnectionSiteIndex`. 

{{% /alert %}} 

## **Určení připojovacího bodu**

Pokud chcete, aby konektor propojil dva tvary pomocí konkrétních bodů na tvarech, musíte určit požadované připojovací body tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
2. Získejte referenci na snímek pomocí jeho indexu.
3. Přidejte do snímku dva [AutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/AutoShape) pomocí metody `addAutoShape`, která je součástí objektu `Shapes`.
4. Přidejte konektor pomocí metody `addConnector`, která je součástí objektu `Shapes`, a definujte typ konektoru.
5. Propojte tvary pomocí konektoru. 
6. Nastavte požadované připojovací body na tvarech. 
7. Uložte prezentaci.

Tento Java kód demonstruje operaci, kde je určen preferovaný připojovací bod:

```java
// Vytvoří instanci třídy Presentation, která představuje soubor PPTX
Presentation pres = new Presentation();
try {
    // Přistupuje ke kolekci tvarů konkrétního snímku
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();

    // Přidá eliptický autoshape
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Přidá obdélníkový autoshape
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // Přidá tvar konektoru do kolekce tvarů snímku
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // Propojí tvary pomocí konektoru
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    // Nastaví preferovaný index připojovacího bodu na tvaru Elipsy
    int wantedIndex = 6;

    // Kontroluje, zda je preferovaný index menší než maximální počet připojovacích míst
    if (ellipse.getConnectionSiteCount() > wantedIndex) 
    {
        // Nastaví preferovaný připojovací bod na eliptickém autoshape
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }

    // Uloží prezentaci
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Úprava bodu konektoru**

Můžete upravit existující konektor pomocí jeho úpravových bodů. Pouze konektory s úpravovými body lze tímto způsobem měnit. Viz tabulka pod **[Typy konektorů.](/slides/cs/java/connector/#types-of-connectors)** 

### **Jednoduchý případ**

Uvažujte případ, kdy konektor mezi dvěma tvary (A a B) prochází třetím tvarem (C):

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

Abychom třetí tvar obešli nebo se mu vyhnuli, můžeme upravit konektor přesunutím jeho svislé čáry doleva tímto způsobem:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```java
IAdjustValue adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```

### **Komplexní případy** 

Pro provedení složitějších úprav musíte vzít v úvahu následující:

* Bod, který lze upravit u konektoru, je úzce spjat s formulí, která vypočítává a určuje jeho polohu. Změny polohy bodu tak mohou změnit tvar konektoru.
* Úpravové body konektoru jsou definovány v pevně daném pořadí v poli. Úpravové body jsou očíslovány od počátečního bodu konektoru po koncový bod.
* Hodnoty úpravových bodů odrážejí procentuální podíl šířky/výšky tvaru konektoru. 
  * Tvar je omezen počátečním a koncovým bodem konektoru vynásobeným 1000. 
  * První bod, druhý bod a třetí bod definují procenta ze šířky, procenta ze výšky a opět procenta ze šířky. 
* Pro výpočty, které určují souřadnice úpravových bodů konektoru, musíte brát v úvahu jeho rotaci a odraz. **Poznámka**: úhel rotace všech konektorů zobrazených pod **[Typy konektorů](/slides/cs/java/connector/#types-of-connectors)** je 0.

#### **Případ 1**

Uvažujte případ, kdy jsou dva objekty textového rámce propojeny pomocí konektoru:

![connector-shape-complex](connector-shape-complex.png)

```java
// Vytvoří instanci třídy Presentation, která představuje soubor PPTX
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
    
    // Získá úpravové body konektoru
    IAdjustValue adjValue_0 = connector.getAdjustments().get_Item(0);
    IAdjustValue adjValue_1 = connector.getAdjustments().get_Item(1);

} finally {
    if (pres != null) pres.dispose();
}
```

**Úprava**

Můžeme změnit hodnoty úpravových bodů konektoru zvýšením odpovídajících procent šířky a výšky o 20 % a 200 %:

```java
// Změní hodnoty úpravových bodů
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

Výsledek:

![connector-adjusted-1](connector-adjusted-1.png)

Abychom definovali model, který nám umožní určit souřadnice a tvar jednotlivých částí konektoru, vytvořme tvar, který odpovídá horizontální komponentě konektoru v bodě connector.getAdjustments().get_Item(0):

```java
// Nakreslí svislou komponentu konektoru
float x = connector.getX() + connector.getWidth() * adjValue_0.getRawValue() / 100000;
float y = connector.getY();
float height = connector.getHeight() * adjValue_1.getRawValue() / 100000;
sld.getShapes().addAutoShape( ShapeType .Rectangle, x, y, 0, height);
```

Výsledek:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Případ 2**

V **Případě 1** jsme ukázali jednoduchou operaci úpravy konektoru pomocí základních principů. V běžných situacích musíte vzít v úvahu rotaci konektoru a jeho zobrazení (které jsou nastaveny metodami connector.getRotation(), connector.getFrame().getFlipH() a connector.getFrame().getFlipV()). Nyní proceduru demonstrujeme.

Nejprve přidáme na snímek nový objekt textového rámce (**To 1**) (pro účely propojení) a vytvoříme nový (zelený) konektor, který jej spojí s již vytvořenými objekty.

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
// Získá úpravové body konektoru
adjValue_0 = connector.getAdjustments().get_Item(0);
adjValue_1 = connector.getAdjustments().get_Item(1);
// Změní hodnoty úpravových bodů
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

Výsledek:

![connector-adjusted-3](connector-adjusted-3.png)

Druhá část: vytvoříme tvar, který bude odpovídat horizontální komponentě konektoru procházející úpravovým bodem nového konektoru connector.getAdjustments().get_Item(0). Použijeme hodnoty z dat konektoru pro connector.getRotation(), connector.getFrame().getFlipH() a connector.getFrame().getFlipV() a použijeme oblíbený vzorec pro konverzi souřadnic při rotaci okolo zadaného bodu x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

V našem případě je úhel rotace objektu 90 stupňů a konektor je zobrazen vertikálně, takže odpovídající kód je:

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
// Přijme hodnotu úpravového bodu jako souřadnici
x += connector.getWidth() * adjValue_0.getRawValue() / 100000;
//  Převádí souřadnice, protože Sin(90) = 1 a Cos(90) = 0
float xx = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
float yy = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
// Určuje šířku horizontální komponenty pomocí hodnoty druhého úpravového bodu
float width = connector.getHeight() * adjValue_1.getRawValue() / 100000;
IAutoShape shape = sld.getShapes().addAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
```

Výsledek:

![connector-adjusted-4](connector-adjusted-4.png)

Ukázali jsme výpočty zahrnující jednoduché úpravy i složité úpravy bodů (úpravy s úhly rotace). S využitím získaných znalostí můžete vyvinout vlastní model (nebo napsat kód) pro získání objektu `GraphicsPath` nebo dokonce nastavit hodnoty úpravových bodů konektoru na základě konkrétních souřadnic snímku.

## **Zjištění úhlu čar konektoru**

1. Vytvořte instanci třídy.
2. Získejte referenci na snímek pomocí jeho indexu.
3. Přistupte k tvaru čáry konektoru.
4. Použijte šířku a výšku čáry, výšku a šířku rámečku tvaru k výpočtu úhlu.

Tento Java kód demonstruje operaci, při níž jsme vypočetli úhel pro tvar čáry konektoru:

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

## **Často kladené otázky**

**Jak zjistit, zda lze konektor „přilepit“ k určitému tvaru?**

Zkontrolujte, zda tvar poskytuje [připojovací body](https://reference.aspose.com/slides/cs/java/com.aspose.slides/shape/#getConnectionSiteCount--). Pokud žádné neexistují nebo je jejich počet nula, přilepení není možné; v takovém případě použijte volné koncové body a umístěte je ručně. Je rozumné zkontrolovat počet bodů před připojením.

**Co se stane s konektorem, pokud smažu jeden z připojených tvarů?**

Jeho konce se odpojí; konektor zůstane na snímku jako běžná čára s volnými počátečními/koncovými body. Můžete jej buď smazat, nebo přenastavit připojení a v případě potřeby [přesměrovat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/connector/#reroute--).

**Zůstávají vazby konektoru zachovány při kopírování snímku do jiné prezentace?**

Obecně ano, pokud jsou kopírovány i cílové tvary. Pokud je snímek vložen do jiného souboru bez připojených tvarů, konce se stanou volnými a bude je třeba znovu připojit.