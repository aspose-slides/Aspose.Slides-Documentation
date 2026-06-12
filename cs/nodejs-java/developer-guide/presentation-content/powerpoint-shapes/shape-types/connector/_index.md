---
title: Správa spojek v prezentacích pomocí JavaScriptu
linktitle: Spojka
type: docs
weight: 10
url: /cs/nodejs-java/connector/
keywords:
- spojka
- typ spojky
- bod spojky
- čára spojky
- úhel spojky
- propojit tvary
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Umožněte aplikacím JavaScript kreslit, propojit a automaticky trasovat čáry v PowerPoint snímcích—získejte plnou kontrolu nad rovnými, ohnutými a zakřivenými spojkami."
---
## **Úvod**

Spojka PowerPointu je speciální čára, která spojuje nebo propojuje dva tvary a zůstává připojena k tvarům i po jejich přesunutí nebo přeúspořádání na snímku.  

Spojky jsou typicky připojeny k *připojovacím bodům* (zelené body), které jsou ve výchozím nastavení na všech tvarech. Připojovací body se zobrazí, když se kurzor přiblíží k nim.

*Úpravové body* (oranžové body), které existují jen u některých spojek, slouží k úpravě polohy a tvaru spojek.

## **Typy spojek**

V PowerPointu můžete používat rovné, ohnuté (úhlové) a zakřivené spojky.  

Aspose.Slides poskytuje následující spojky:

| Spojka                         | Obrázek                                                       | Počet úpravových bodů |
| ------------------------------ | ------------------------------------------------------------ | ---------------------- |
| `ShapeType.Line`               | ![typ-čáry-spojky](shapetype-lineconnector.png)            | 0 |
| `ShapeType.StraightConnector1` | ![typ-rovné-spojky1](shapetype-straightconnector1.png)      | 0 |
| `ShapeType.BentConnector2`     | ![typ-ohnuté-spojky2](shapetype-bent-connector2.png)        | 0 |
| `ShapeType.BentConnector3`     | ![typ-ohnuté-spojky3](shapetype-bentconnector3.png)         | 1 |
| `ShapeType.BentConnector4`     | ![typ-ohnuté-spojky4](shapetype-bentconnector4.png)         | 2 |
| `ShapeType.BentConnector5`     | ![typ-ohnuté-spojky5](shapetype-bentconnector5.png)         | 3 |
| `ShapeType.CurvedConnector2`   | ![typ-křivé-spojky2](shapetype-curvedconnector2.png)        | 0 |
| `ShapeType.CurvedConnector3`   | ![typ-křivé-spojky3](shapetype-curvedconnector3.png)        | 1 |
| `ShapeType.CurvedConnector4`   | ![typ-křivé-spojky4](shapetype-curvedconnector4.png)        | 2 |
| `ShapeType.CurvedConnector5`   | ![typ-křivé-spojky5](shapetype.curvedconnector5.png)        | 3 |

## **Propojení tvarů pomocí spojek**

1. Vytvořte instanci třídy [Prezentace](https://apireference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
2. Získejte odkaz na snímek podle jeho indexu.
3. Pomocí metody `addAutoShape` objektu `Shapes` přidejte na snímek dva [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/AutoShape).
4. Pomocí metody `addConnector` objektu `Shapes` přidejte spojku definováním typu spojky.
5. Spojte tvary pomocí spojky.
6. Zavolejte metodu `reroute`, aby se použila nejkratší cesta spojení.
7. Uložte prezentaci.

Tento JavaScriptový kód ukazuje, jak přidat spojku (ohnutou spojku) mezi dva tvary (elipsu a obdélník):

```javascript
// Vytvoří instanci třídy prezentace, která představuje soubor PPTX
var pres = new aspose.slides.Presentation();
try {
    // Přistupuje ke kolekci tvarů pro konkrétní snímek
    var shapes = pres.getSlides().get_Item(0).getShapes();
    // Přidá elipsu jako autoshape
    var ellipse = shapes.addAutoShape(aspose.slides.ShapeType.Ellipse, 0, 100, 100, 100);
    // Přidá obdélník jako autoshape
    var rectangle = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 300, 100, 100);
    // Přidá tvar spojky do kolekce tvarů snímku
    var connector = shapes.addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 10, 10);
    // Propojí tvary pomocí spojky
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    // Zavolá reroute, který nastaví automatickou nejkratší cestu mezi tvary
    connector.reroute();
    // Uloží prezentaci
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{%  alert title="NOTE"  color="warning"   %}} 

Metoda `Connector.reroute` přepočítá spojku a vynutí, aby zvolila nejkratší možnou cestu mezi tvary. K dosažení tohoto cíle může metoda změnit body `setStartShapeConnectionSiteIndex` a `setEndShapeConnectionSiteIndex`. 

{{% /alert %}} 

## **Zadání připojovacího bodu**

Pokud chcete, aby spojka propojila dva tvary pomocí konkrétních bodů na tvarech, musíte zadat preferované připojovací body následovně:

1. Vytvořte instanci třídy [Prezentace](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
2. Získejte odkaz na snímek podle jeho indexu.
3. Pomocí metody `addAutoShape` objektu `Shapes` přidejte na snímek dva [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/AutoShape).
4. Pomocí metody `addConnector` objektu `Shapes` přidejte spojku definováním typu spojky.
5. Spojte tvary pomocí spojky.
6. Nastavte své preferované připojovací body na tvarech.
7. Uložte prezentaci.

Tento JavaScriptový kód demonstruje operaci, kde je zadán preferovaný připojovací bod:

```javascript
// Vytvoří instanci třídy prezentace, která představuje soubor PPTX
var pres = new aspose.slides.Presentation();
try {
    // Přistupuje ke kolekci tvarů pro konkrétní snímek
    var shapes = pres.getSlides().get_Item(0).getShapes();
    // Přidá elipsu jako autoshape
    var ellipse = shapes.addAutoShape(aspose.slides.ShapeType.Ellipse, 0, 100, 100, 100);
    // Přidá obdélník jako autoshape
    var rectangle = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 300, 100, 100);
    // Přidá tvar spojky do kolekce tvarů snímku
    var connector = shapes.addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 10, 10);
    // Propojí tvary pomocí spojky
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    // Nastaví preferovaný index připojovacího bodu na elipsovém tvaru
    var wantedIndex = 6;
    // Kontroluje, zda je preferovaný index menší než maximální počet připojovacích míst
    if (ellipse.getConnectionSiteCount() > wantedIndex) {
        // Nastaví preferovaný připojovací bod na elipsovém autoshape
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }
    // Uloží prezentaci
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Úprava bodu spojky**

Existující spojku můžete upravit pomocí jejích úpravových bodů. Pouze spojky s úpravovými body lze takto měnit. Viz tabulka pod **[Typy spojek](/slides/cs/nodejs-java/connector/#types-of-connectors)**.

### **Jednoduchý případ**

Uvažujme případ, kdy spojka mezi dvěma tvary (A a B) prochází třetím tvarem (C):

![blokace-spojky](connector-obstruction.png)

```javascript
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    var shape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 150, 150, 75);
    var shapeFrom = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 400, 100, 50);
    var shapeTo = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 70, 30);
    var connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector5, 20, 20, 400, 300);
    connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setStartShapeConnectionSiteIndex(2);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Abychom třetí tvar obejděli, můžeme spojku upravit posunutím její vertikální linie doleva:

![blokace-spojky-opraveno](connector-obstruction-fixed.png)

```javascript
var adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```

### **Komplexní případy** 

Pro provedení složitějších úprav musíte vzít v úvahu následující:

* Úpravový bod spojky je úzce spojen s formulí, která vypočítává a určuje jeho polohu. Změna polohy bodu může změnit tvar spojky.
* Úpravové body jsou definovány v přísném pořadí v poli. Číslování probíhá od počátečního bodu spojky po koncový.
* Hodnoty úpravových bodů vyjadřují procento šířky/výšky tvaru spojky.  
  * Tvar je omezen počátečním a koncovým bodem spojky vynásobeným 1000.  
  * První bod, druhý bod a třetí bod definují procento ze šířky, procento z výšky a opět procento ze šířky.
* Pro výpočty souřadnic úpravových bodů spojky musíte zohlednit rotaci spojky a její odraz. **Poznámka**: úhel rotace všech spojek zobrazených pod **[Typy spojek](/slides/cs/nodejs-java/connector/#types-of-connectors)** je 0.

#### **Případ 1**

Uvažujme případ, kdy jsou dva textové rámečky propojeny spojkou:

![komplexní-spojka-tvar](connector-shape-complex.png)

```javascript
// Vytvoří instanci třídy prezentace, která představuje soubor PPTX
var pres = new aspose.slides.Presentation();
try {
    // Získá první snímek v prezentaci
    var sld = pres.getSlides().get_Item(0);
    // Přidá tvary, které budou propojeny pomocí spojky
    var shapeFrom = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    shapeFrom.getTextFrame().setText("From");
    var shapeTo = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 60, 25);
    shapeTo.getTextFrame().setText("To");
    // Přidá spojku
    var connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
    // Určuje směr spojky
    connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    // Určuje barvu spojky
    connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Určuje tloušťku čáry spojky
    connector.getLineFormat().setWidth(3);
    // Propojí tvary pomocí spojky
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setEndShapeConnectionSiteIndex(2);
    // Získá úpravové body spojky
    var adjValue_0 = connector.getAdjustments().get_Item(0);
    var adjValue_1 = connector.getAdjustments().get_Item(1);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

**Úprava**

Můžeme změnit hodnoty úpravových bodů spojky zvýšením odpovídajících procent šířky a výšky o 20 % a 200 %:

```javascript
// Mění hodnoty úpravových bodů
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

Výsledek:

![spojka-úprava-1](connector-adjusted-1.png)

Pro definování modelu, který nám umožní určit souřadnice a tvar jednotlivých částí spojky, vytvoříme tvar odpovídající horizontální komponentě spojky v bodě `connector.getAdjustments().get_Item(0)`:

```javascript
// Vykreslí vertikální komponentu spojky
var x = connector.getX() + ((connector.getWidth() * adjValue_0.getRawValue()) / 100000);
var y = connector.getY();
var height = (connector.getHeight() * adjValue_1.getRawValue()) / 100000;
sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, x, y, 0, height);
```

Výsledek:

![spojka-úprava-2](connector-adjusted-2.png)

#### **Případ 2**

V **případě 1** jsme ukázali jednoduchou operaci úpravy spojky pomocí základních principů. V běžných situacích musíte zohlednit rotaci spojky a její zobrazení (nastavené pomocí `connector.getRotation()`, `connector.getFrame().getFlipH()` a `connector.getFrame().getFlipV()`). Nyní tento proces demonstrujeme.

Nejprve přidejte na snímek nový objekt textového rámečku (**To 1**) (pro účely propojení) a vytvořte novou (zelenou) spojku, která jej propojí s již vytvořenými objekty.

```javascript
// Vytvoří nový objekt vazby
var shapeTo_1 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.getTextFrame().setText("To 1");
// Vytvoří novou spojku
connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
connector.getLineFormat().setWidth(3);
// Propojí objekty pomocí nově vytvořené spojky
connector.setStartShapeConnectedTo(shapeFrom);
connector.setStartShapeConnectionSiteIndex(2);
connector.setEndShapeConnectedTo(shapeTo_1);
connector.setEndShapeConnectionSiteIndex(3);
// Získá úpravové body spojky
adjValue_0 = connector.getAdjustments().get_Item(0);
adjValue_1 = connector.getAdjustments().get_Item(1);
// Mění hodnoty úpravových bodů
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

Výsledek:

![spojka-úprava-3](connector-adjusted-3.png)

Druhá část: vytvořte tvar, který bude odpovídat horizontální komponentě spojky procházející úpravovým bodem `connector.getAdjustments().get_Item(0)`. Použijte hodnoty z dat spojky pro `connector.getRotation()`, `connector.getFrame().getFlipH()` a `connector.getFrame().getFlipV()` a aplikujte obvyklý převodní vzorec pro rotaci kolem bodu x₀:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

V našem případě je úhel rotace objektu 90 ° a spojka je zobrazena vertikálně, takže odpovídající kód je:

```javascript
// Uloží souřadnice spojky
x = connector.getX();
y = connector.getY();
// Opraví souřadnice spojky v případě, že se objeví
if (connector.getFrame().getFlipH() == aspose.slides.NullableBool.True) {
    x += connector.getWidth();
}
if (connector.getFrame().getFlipV() == aspose.slides.NullableBool.True) {
    y += connector.getHeight();
}
// Použije hodnotu úpravového bodu jako souřadnici
x += (connector.getWidth() * adjValue_0.getRawValue()) / 100000;
// Převede souřadnice, protože Sin(90) = 1 a Cos(90) = 0
var xx = (connector.getFrame().getCenterX() - y) + connector.getFrame().getCenterY();
var yy = (x - connector.getFrame().getCenterX()) + connector.getFrame().getCenterY();
// Určí šířku horizontální komponenty pomocí hodnoty druhého úpravového bodu
var width = (connector.getHeight() * adjValue_1.getRawValue()) / 100000;
var shape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
```

Výsledek:

![spojka-úprava-4](connector-adjusted-4.png)

Ukázali jsme výpočty zahrnující jednoduché úpravy i komplikované úpravové body (úpravy s úhly rotace). Pomocí získaných znalostí můžete vytvořit vlastní model (nebo napsat kód), který získá objekt `GraphicsPath` nebo dokonce nastaví hodnoty úpravových bodů spojky na základě konkrétních souřadnic snímku.

## **Zjištění úhlu spojkových čar**

1. Vytvořte instanci třídy.
2. Získejte odkaz na snímek podle jeho indexu.
3. Přistupte k tvaru spojkové čáry.
4. Pomocí šířky, výšky, výšky rámce tvaru a šířky rámce tvaru vypočítejte úhel.

Tento JavaScriptový kód ukazuje operaci, při které vypočítáme úhel spojkové čáry:

```javascript
var pres = new aspose.slides.Presentation("ConnectorLineAngle.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var dir = 0.0;
        var shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            var ashp = shape;
            if (ashp.getShapeType() == aspose.slides.ShapeType.Line) {
                dir = getDirection(ashp.getWidth(), ashp.getHeight(), ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
            }
        } else if (java.instanceOf(shape, "com.aspose.slides.Connector")) {
            var ashp = shape;
            dir = getDirection(ashp.getWidth(), ashp.getHeight(), ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
        }
        console.log(dir);
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
function getDirection(w, h, flipH, flipV) {
    let endLineX = w * (flipH ? -1 : 1);
    let endLineY = h * (flipV ? -1 : 1);
    
    let endYAxisX = 0;
    let endYAxisY = h;

    let angle = Math.atan2(endYAxisY, endYAxisX) - Math.atan2(endLineY, endLineX);

    if (angle < 0) {
        angle += 2 * Math.PI;
    }

    return angle * 180.0 / Math.PI;
}
```

## **Často kladené otázky**

**Jak zjistit, zda lze spojku „přilepit“ k určitému tvaru?**

Zkontrolujte, zda tvar poskytuje [připojovací místa](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/getconnectionsitecount/). Pokud žádná nejsou nebo je jejich počet nula, lepení není k dispozici; v takovém případě použijte volné koncové body a umístěte je ručně. Je rozumné zkontrolovat počet míst před připojením.

**Co se stane se spojkou, pokud smažu jeden ze spojených tvarů?**

Její konce se odpojí; spojka zůstane na snímku jako obyčejná čára s volnými počátečním/koncovým bodem. Můžete ji buď smazat, nebo znovu přiřadit spojení a podle potřeby [přepočítat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/connector/reroute/).

**Zůstávají vazby spojek zachovány při kopírování snímku do jiné prezentace?**

Obecně ano, pokud jsou kopírovány i cílové tvary. Pokud je snímek vložen do jiného souboru bez spojených tvarů, konce se stanou volnými a budete je muset znovu připojit.