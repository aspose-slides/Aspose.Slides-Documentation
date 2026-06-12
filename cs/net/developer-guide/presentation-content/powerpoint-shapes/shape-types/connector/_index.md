---
title: Správa konektorů v prezentacích v .NET
linktitle: Konektor
type: docs
weight: 10
url: /cs/net/connector/
keywords:
- konektor
- typ konektoru
- bod konektoru
- čára konektoru
- úhel konektoru
- propojit tvary
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Umožněte aplikacím .NET kreslit, propojovat a automaticky směrovat čáry v PowerPoint snímcích — získejte plnou kontrolu nad přímými, ohnutými a zakřivenými konektory."
---
## **Úvod**

Konektor PowerPointu je speciální čára, která spojuje nebo propojuje dva tvary dohromady a zůstává připojena k tvarům i při jejich přesunu nebo repositionování na daném snímku.  

Konektory jsou typicky připojeny ke *spojovacím bodům* (zelené tečky), které jsou ve výchozím nastavení přítomny na všech tvarech. Spojovací body se zobrazí, když se kurzor k nim přiblíží.  

*Úpravy bodů* (oranžové tečky), které existují jen u některých konektorů, slouží k úpravě polohy a tvaru konektorů.  

## **Typy konektorů**

V PowerPointu můžete používat přímé, ohnuté (úhlové) a zakřivené konektory.  

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

## **Propojení tvarů pomocí konektorů**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
1. Získejte odkaz na snímek prostřednictvím jeho indexu.
1. Přidejte na snímek dva [AutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/autoshape/) pomocí metody `AddAutoShape` poskytované objektem `Shapes`.
1. Přidejte konektor pomocí metody `AddConnector` poskytované objektem `Shapes` a definujte typ konektoru.
1. Propojte tvary pomocí konektoru.
1. Zavolejte metodu `Reroute`, aby se použila nejkratší cesta připojení.
1. Uložte prezentaci.  

Tento C# kód vám ukazuje, jak přidat konektor (ohnutý konektor) mezi dva tvary (elipsu a obdélník):

```c#
// Vytvoří instanci třídy prezentace, která představuje soubor PPTX
using (Presentation input = new Presentation())
{                
    // Přistupuje ke kolekci tvarů konkrétního snímku
    IShapeCollection shapes = input.Slides[0].Shapes;

    // Přidá automatický tvar Elipsa
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Přidá automatický tvar Obdélník
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // Přidá tvar konektoru do kolekce tvarů snímku
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // Propojí tvary pomocí konektoru
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // Volá metodu reroute, která nastaví automatickou nejkratší cestu mezi tvary
    connector.Reroute();

    // Uloží prezentaci
    input.Save("Shapes-connector.pptx", SaveFormat.Pptx);
}
```

{{%  alert title="NOTE"  color="warning"   %}} 
`Metoda Connector.Reroute` přesměruje konektor a vynutí, aby zvolil nejkratší možnou cestu mezi tvary. K dosažení tohoto cíle může metoda změnit body `StartShapeConnectionSiteIndex` a `EndShapeConnectionSiteIndex`. 
{{% /alert %}} 

## **Určení spojovacího bodu**

Pokud chcete, aby konektor propojil dva tvary pomocí konkrétních bodů na tvarech, musíte specifikovat své preferované spojovací body tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
1. Získejte odkaz na snímek prostřednictvím jeho indexu.
1. Přidejte na snímek dva [AutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/autoshape/) pomocí metody `AddAutoShape` poskytované objektem `Shapes`.
1. Přidejte konektor pomocí metody `AddConnector` poskytované objektem `Shapes` a definujte typ konektoru.
1. Propojte tvary pomocí konektoru.
1. Nastavte své preferované spojovací body na tvarech.
1. Uložte prezentaci.  

Tento C# kód demonstruje operaci, kde je specifikován preferovaný spojovací bod:

```c#
// Vytvoří instanci třídy prezentace, která představuje soubor PPTX
using (Presentation presentation = new Presentation())
{
    // Přistupuje ke kolekci tvarů konkrétního snímku
    IShapeCollection shapes = presentation.Slides[0].Shapes;

    // Přidá tvar konektoru do kolekce tvarů snímku
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

    // Přidá automatický tvar Elipsu
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Přidá automatický tvar Obdélníku
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

    // Propojí tvary pomocí konektoru
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // Nastaví preferovaný index spojovacího bodu na tvaru Elipsy
    uint wantedIndex = 6;

    // Kontroluje, zda je preferovaný index menší než maximální počet spojovacích míst
    if (ellipse.ConnectionSiteCount > wantedIndex)
    {
        // Nastaví preferovaný spojovací bod na automatickém tvaru Elipsy
        connector.StartShapeConnectionSiteIndex = wantedIndex;
    }

    // Uloží prezentaci
    presentation.Save("Connecting_Shape_on_desired_connection_site_out.pptx", SaveFormat.Pptx);
}
```

## **Úprava bodu konektoru**

Existující konektor můžete upravit pomocí jeho úpravných bodů. Pouze konektory s úpravnými body lze tímto způsobem měnit. Viz tabulka pod **[Typy konektorů.](/slides/cs/net/connector/#types-of-connectors)**  

### **Jednoduchý případ**

Uvažujme případ, kdy konektor mezi dvěma tvary (A a B) prochází třetím tvarem (C):

![connector-obstruction](connector-obstruction.png)

Kód:

```c#
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
IShape shape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
IShape shapeFrom = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
IShape shapeTo = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
 
IConnector connector = sld.Shapes.AddConnector(ShapeType.BentConnector5, 20, 20, 400, 300);
 
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
 
connector.StartShapeConnectedTo = shapeFrom;
connector.EndShapeConnectedTo = shapeTo;
connector.StartShapeConnectionSiteIndex = 2;
```

Abychom se vyhnuli nebo obešli třetí tvar, můžeme konektor upravit tak, že přesuneme jeho vertikální čáru doleva tímto způsobem:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```c#
IAdjustValue adj2 = connector.Adjustments[1];
adj2.RawValue += 10000;
```

### **Komplexní případy** 

Pro provedení složitějších úprav musíte vzít v úvahu následující body:

* Nástavitelný bod konektoru je úzce spojen s formulí, která vypočítává a určuje jeho polohu. Změny umístění bodu mohou tedy změnit tvar konektoru.  
* Úpravy bodů konektoru jsou v poli definovány v přísném pořadí. Úpravy bodů jsou číslovány od počátečního bodu konektoru po koncový.  
* Hodnoty úpravných bodů odrážejí procento šířky/výšky tvaru konektoru.  
  * Tvar je omezen počátečním a koncovým bodem konektoru vynásobeným 1000.  
  * První bod, druhý bod a třetí bod definují procento ze šířky, procento z výšky a opět procento ze šířky.  
* Pro výpočty, které určují souřadnice úpravných bodů konektoru, musíte vzít v úvahu rotaci konektoru a jeho odraz. **Poznámka**: úhel rotace pro všechny konektory zobrazené pod **[Typy konektorů](/slides/cs/net/connector/#types-of-connectors)** je 0.  

#### **Případ 1**

Uvažujme případ, kdy jsou dva objekty textových rámců propojeny pomocí konektoru:

![connector-shape-complex](connector-shape-complex.png)

Kód:

```c#
// Vytvoří instanci třídy prezentace, která představuje soubor PPTX
Presentation pres = new Presentation();
// Získá první snímek v prezentaci
ISlide sld = pres.Slides[0];
// Přidá tvary, které budou propojeny konektorem
IAutoShape shapeFrom = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
shapeFrom.TextFrame.Text = "From";
IAutoShape shapeTo = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
shapeTo.TextFrame.Text = "To";
// Přidá konektor
IConnector connector = sld.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
// Určuje směr konektoru
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
// Určuje barvu konektoru
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Crimson;
// Určuje tloušťku čáry konektoru
connector.LineFormat.Width = 3;

// Propojí tvary pomocí konektoru
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = shapeTo;
connector.EndShapeConnectionSiteIndex = 2;

// Získá úpravné body pro konektor
IAdjustValue adjValue_0 = connector.Adjustments[0];
IAdjustValue adjValue_1 = connector.Adjustments[1];
```

**Úprava**

Můžeme změnit hodnoty úpravných bodů konektoru zvýšením odpovídajícího procenta šířky a výšky o 20 % a 200 % respektive:

```c#
// Změní hodnoty úpravných bodů
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```

Výsledek:

![connector-adjusted-1](connector-adjusted-1.png)

Abychom definovali model, který nám umožní určit souřadnice a tvar jednotlivých částí konektoru, vytvořme tvar, který odpovídá horizontální komponentě konektoru v bodě connector.Adjustments[0]:

```c#
// Vykreslí vertikální komponentu konektoru

float x = connector.X + connector.Width * adjValue_0.RawValue / 100000;
float y = connector.Y;
float height = connector.Height * adjValue_1.RawValue / 100000;
sld.Shapes.AddAutoShape( ShapeType .Rectangle, x, y, 0, height);
```

Výsledek:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Případ 2**

V **případě 1** jsme ukázali jednoduchou operaci úpravy konektoru za použití základních principů. V běžných situacích musíte vzít v úvahu rotaci konektoru a jeho zobrazení (které jsou nastaveny pomocí connector.Rotation, connector.Frame.FlipH a connector.Frame.FlipV). Nyní proces demonstrujeme.

Nejprve přidejme na snímek nový objekt textového rámce (**To 1**) (pro účely propojení) a vytvořme nový (zelený) konektor, který jej spojí s objekty, které jsme již vytvořili.

```c#
// Vytvoří nový objekt vazby
IAutoShape shapeTo_1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.TextFrame.Text = "To 1";
// Vytvoří nový konektor
connector = sld.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.MediumAquamarine;
connector.LineFormat.Width = 3;
// Propojí objekty pomocí nově vytvořeného konektoru
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 2;
connector.EndShapeConnectedTo = shapeTo_1;
connector.EndShapeConnectionSiteIndex = 3;
// Získá úpravné body konektoru
adjValue_0 = connector.Adjustments[0];
adjValue_1 = connector.Adjustments[1];
// Změní hodnoty úpravných bodů 
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```

Výsledek:

![connector-adjusted-3](connector-adjusted-3.png)

Druhá věc: vytvořme tvar, který bude odpovídat horizontální komponentě konektoru procházející novým úpravným bodem konektoru connector.Adjustments[0]. Použijeme hodnoty z dat konektoru pro connector.Rotation, connector.Frame.FlipH a connector.Frame.FlipV a aplikujeme běžný vzorec pro převod souřadnic při rotaci kolem daného bodu x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

V našem případě je úhel rotace objektu 90 stupňů a konektor je zobrazen vertikálně, takže odpovídající kód je:

```c#
// Uloží souřadnice konektoru
x = connector.X;
y = connector.Y;
// Opraví souřadnice konektoru v případě, že se objeví
if (connector.Frame.FlipH == NullableBool.True)
{
    x += connector.Width;
}
if (connector.Frame.FlipV == NullableBool.True)
{
    y += connector.Height;
}
// Přijme hodnotu úpravného bodu jako souřadnici
x += connector.Width * adjValue_0.RawValue / 100000;
//  Převádí souřadnice, protože Sin(90) = 1 a Cos(90) = 0
float xx = connector.Frame.CenterX - y + connector.Frame.CenterY;
float yy = x - connector.Frame.CenterX + connector.Frame.CenterY;
// Určuje šířku horizontální komponenty pomocí hodnoty druhého úpravného bodu
float width = connector.Height * adjValue_1.RawValue / 100000;
IAutoShape shape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

```

Výsledek:

![connector-adjusted-4](connector-adjusted-4.png)

Ukázali jsme výpočty zahrnující jednoduché úpravy a složité úpravy bodů (úpravy bodů s úhly rotace). S využitím získaných znalostí můžete vyvinout vlastní model (nebo napsat kód), který získá objekt `GraphicsPath` nebo dokonce nastaví hodnoty úpravných bodů konektoru na základě konkrétních souřadnic snímku.

## **Zjištění úhlu čar konektoru**
1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
1. Získejte odkaz na snímek prostřednictvím jeho indexu.
1. Přistupte k tvaru čáry konektoru.
1. Použijte šířku a výšku čáry, výšku rámce tvaru a šířku rámce tvaru pro výpočet úhlu.  

Tento C# kód demonstruje operaci, při které jsme vypočítali úhel pro tvar čáry konektoru:

```c#
public static void Run()
{
    Presentation pres = new Presentation("ConnectorLineAngle.pptx");
    Slide slide = (Slide)pres.Slides[0];
    Shape shape;
    for (int i = 0; i < slide.Shapes.Count; i++)
    {
        double dir = 0.0;
        shape = (Shape)slide.Shapes[i];
        if (shape is AutoShape)
        {
            AutoShape ashp = (AutoShape)shape;
            if (ashp.ShapeType == ShapeType.Line)
            {
                dir = getDirection(ashp.Width, ashp.Height, Convert.ToBoolean(ashp.Frame.FlipH), Convert.ToBoolean(ashp.Frame.FlipV));
            }
        }
        else if (shape is Connector)
        {
            Connector ashp = (Connector)shape;
            dir = getDirection(ashp.Width, ashp.Height, Convert.ToBoolean(ashp.Frame.FlipH), Convert.ToBoolean(ashp.Frame.FlipV));
        }

        Console.WriteLine(dir);
    }

}
public static double getDirection(float w, float h, bool flipH, bool flipV)
{
    float endLineX = w * (flipH ? -1 : 1);
    float endLineY = h * (flipV ? -1 : 1);
    float endYAxisX = 0;
    float endYAxisY = h;
    double angle = (Math.Atan2(endYAxisY, endYAxisX) - Math.Atan2(endLineY, endLineX));
    if (angle < 0) angle += 2 * Math.PI;
    return angle * 180.0 / Math.PI;
}
```

## **Často kladené otázky**

**Jak zjistit, zda lze konektor „přilepit“ k určitému tvaru?**

Zkontrolujte, zda tvar poskytuje [spojovací místa](https://reference.aspose.com/slides/cs/net/aspose.slides/shape/connectionsitecount/). Pokud nejsou žádná nebo je jejich počet nula, přichycení není k dispozici; v takovém případě použijte volné koncové body a umístěte je ručně. Je rozumné před připojením zkontrolovat počet míst.

**Co se stane s konektorem, pokud smažu jeden z propojených tvarů?**

Jeho konce se odpojí; konektor zůstane na snímku jako obyčejná čára s volnými počátkem/koncem. Můžete jej buď smazat, nebo znovu přiřadit spojení a v případě potřeby [přesměrovat](https://reference.aspose.com/slides/cs/net/aspose.slides/connector/reroute/).

**Zůstávají vazby konektorů zachovány při kopírování snímku do jiné prezentace?**

Obecně ano, pokud jsou spolu s tím i cílové tvary zkopírovány. Pokud je snímek vložen do jiného souboru bez propojených tvarů, konce se stanou volnými a budete je muset znovu připojit.