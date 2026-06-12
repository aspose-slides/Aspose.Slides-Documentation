---
title: Spravovat konektory v prezentacích pomocí PHP
linktitle: Konektor
type: docs
weight: 10
url: /cs/php-java/connector/
keywords:
- konektor
- typ konektoru
- bod konektoru
- čára konektoru
- úhel konektoru
- propojit tvary
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Umožněte PHP aplikacím kreslit, spojovat a automaticky trasovat čáry v PowerPoint snímcích — získejte plnou kontrolu nad přímými, loketními a zakřivenými konektory."
---
## **Úvod**

Konektor PowerPointu je speciální čára, která spojuje nebo propojuje dva tvary a zůstává k tvarům připojena i po jejich přesunutí nebo pře‑umístění na snímku.

Konektory jsou typicky připojeny k *připojovacím bodům* (zelené tečky), které jsou ve výchozím stavu k dispozici u všech tvarů. Připojovací body se zobrazí, když se kurzor přiblíží k nim.

*Adjustment points* (oranžové tečky), které existují jen u některých konektorů, slouží k úpravě polohy a tvaru konektorů.

## **Typy konektorů**

V PowerPointu můžete použít přímé, loketní (úhlové) a zakřivené konektory.

Aspose.Slides poskytuje následující konektory:

| Konektor                      | Obrázek                                                       | Počet bodů přizpůsobení |
| ------------------------------ | ------------------------------------------------------------ | ------------------------ |
| `ShapeType::Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                        |
| `ShapeType::StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                        |
| `ShapeType::BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                        |
| `ShapeType::BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                        |
| `ShapeType::BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                        |
| `ShapeType::BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                        |
| `ShapeType::CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                        |
| `ShapeType::CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                        |
| `ShapeType::CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                        |
| `ShapeType::CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                        |

## **Propojení tvarů pomocí konektorů**

1. Vytvořte instanci třídy [Presentation](https://apireference.aspose.com/slides/cs/php-java/aspose.slides/Presentation).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek dva [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/AutoShape) pomocí metody `addAutoShape` objektu `Shapes`.
1. Přidejte konektor pomocí metody `addConnector` objektu `Shapes` a určete typ konektoru.
1. Propojte tvary pomocí konektoru. 
1. Zavolejte metodu `reroute`, aby se použila nejkratší cesta propojení.
1. Uložte prezentaci. 

Tento PHP kód ukazuje, jak přidat konektor (ohnutý konektor) mezi dva tvary (elipsu a obdélník):

```php
// Vytvoří instanci třídy prezentace, která představuje soubor PPTX
  $pres = new Presentation();
  try {
    # Přistupuje ke kolekci tvarů pro konkrétní snímek
    $shapes = $pres->getSlides()->get_Item(0)->getShapes();
    # Přidá eliptický autoshape
    $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
    # Přidá obdélníkový autoshape
    $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
    # Přidá tvar konektoru do kolekce tvarů snímku
    $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
    # Propojí tvary pomocí konektoru
    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    # Zavolá reroute, který nastavení automatické nejkratší cesty mezi tvary
    $connector->reroute();
    # Uloží prezentaci
    $pres->save("output.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```

{{%  alert title="NOTE"  color="warning"   %}} 

Metoda `Connector.reroute` přepočítá cestu konektoru a vynutí, aby zvolila co nejkratší možnou trajektorii mezi tvary. K dosažení tohoto cíle může metoda změnit body `setStartShapeConnectionSiteIndex` a `setEndShapeConnectionSiteIndex`. 

{{% /alert %}} 

## **Určení připojovacího bodu**

Pokud chcete, aby konektor spojoval dva tvary pomocí konkrétních bodů na tvarech, musíte specifikovat požadované připojovací body následovně:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek dva [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/AutoShape) pomocí metody `addAutoShape` objektu `Shapes`.
1. Přidejte konektor pomocí metody `addConnector` objektu `Shapes` a určete typ konektoru.
1. Propojte tvary pomocí konektoru. 
1. Nastavte požadované připojovací body na tvarech. 
1. Uložte prezentaci.

Tento PHP kód demonstruje operaci, při které je specifikován preferovaný připojovací bod:

```php
  # Vytvoří instanci třídy prezentace, která představuje soubor PPTX
  $pres = new Presentation();
  try {
    # Přistupuje ke kolekci tvarů pro konkrétní snímek
    $shapes = $pres->getSlides()->get_Item(0)->getShapes();
    # Přidá eliptický autoshape
    $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
    # Přidá obdélníkový autoshape
    $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
    # Přidá tvar konektoru do kolekce tvarů snímku
    $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
    # Propojí tvary pomocí konektoru
    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    # Nastaví preferovaný index připojovacího bodu na tvaru Elipsa
    $wantedIndex = 6;
    # Ověří, zda je preferovaný index menší než maximální počet míst připojení
    if ($ellipse->getConnectionSiteCount() > $wantedIndex) {
      # Nastaví preferovaný připojovací bod na eliptickém autoshapu
      $connector->setStartShapeConnectionSiteIndex($wantedIndex);
    }
    # Uloží prezentaci
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Úprava bodu konektoru**

Existující konektor můžete upravit pomocí jeho bodů úpravy. Pouze konektory s body úpravy lze tímto způsobem měnit. Viz tabulka pod **[Types of connectors.](/slides/cs/php-java/connector/#types-of-connectors)**

### **Jednoduchý případ**

Uvažujme případ, kdy konektor mezi dvěma tvary (A a B) prochází třetím tvarem (C):

![connector-obstruction](connector-obstruction.png)

```php
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    $shape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 150, 150, 75);
    $shapeFrom = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 400, 100, 50);
    $shapeTo = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 70, 30);
    $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector5, 20, 20, 400, 300);
    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $connector->setStartShapeConnectedTo($shapeFrom);
    $connector->setEndShapeConnectedTo($shapeTo);
    $connector->setStartShapeConnectionSiteIndex(2);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Abychom třetí tvar obešli nebo přeskočili, můžeme konektor upravit tak, že jeho svislou čáru posuneme doleva:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```php
  $adj2 = $connector->getAdjustments()->get_Item(1);
  $adj2->setRawValue($adj2->getRawValue() + 10000);

```

### **Komplexní případy** 

Pro složitější úpravy je třeba zohlednit následující aspekty:

* Bod úpravy konektoru je úzce spjatý s formulí, která vypočítává a určuje jeho polohu. Změna polohy bodu tak může změnit tvar konektoru.
* Body úpravy konektoru jsou definovány v přísném pořadí v poli. Číslování začíná od počátečního bodu konektoru až po koncový.
* Hodnoty bodů úpravy vyjadřují procenta šířky/výšky tvaru konektoru.  
  * Tvar je omezen počátečním a koncovým bodem konektoru vynásobeným 1000.  
  * První bod, druhý bod a třetí bod definují procento ze šířky, procento ze výšky a opět procento ze šířky.
* Pro výpočty souřadnic bodů úpravy konektoru je nutné zohlednit rotaci konektoru a jeho zrcadlení. **Poznámka**: úhel rotace všech konektorů uvedených pod **[Types of connectors](/slides/cs/php-java/connector/#types-of-connectors)** je 0.

#### **Případ 1**

Uvažujme případ, kdy jsou dva objektu textového rámce propojeny pomocí konektoru:

![connector-shape-complex](connector-shape-complex.png)

```php
  # Vytvoří instanci třídy prezentace, která představuje soubor PPTX
  $pres = new Presentation();
  try {
    # Získá první snímek v prezentaci
    $sld = $pres->getSlides()->get_Item(0);
    # Přidá tvary, které budou spojeny pomocí konektoru
    $shapeFrom = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $shapeFrom->getTextFrame()->setText("From");
    $shapeTo = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
    $shapeTo->getTextFrame()->setText("To");
    # Přidá konektor
    $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
    # Určuje směr konektoru
    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    # Určuje barvu konektoru
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Určuje tloušťku čáry konektoru
    $connector->getLineFormat()->setWidth(3);
    # Propojí tvary pomocí konektoru
    $connector->setStartShapeConnectedTo($shapeFrom);
    $connector->setStartShapeConnectionSiteIndex(3);
    $connector->setEndShapeConnectedTo($shapeTo);
    $connector->setEndShapeConnectionSiteIndex(2);
    # Získá body úpravy pro konektor
    $adjValue_0 = $connector->getAdjustments()->get_Item(0);
    $adjValue_1 = $connector->getAdjustments()->get_Item(1);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

**Úprava**

Můžeme změnit hodnoty bodů úpravy konektoru zvýšením odpovídajících procent šířky a výšky o 20 % a 200 %:

```php
  # Změní hodnoty bodů úpravy
  $adjValue_0->setRawValue($adjValue_0->getRawValue() + 20000);
  $adjValue_1->setRawValue($adjValue_1->getRawValue() + 200000);
```

Výsledek:

![connector-adjusted-1](connector-adjusted-1.png)

Pro definici modelu, který nám umožní určit souřadnice a tvar jednotlivých částí konektoru, vytvoříme tvar, který odpovídá horizontální složce konektoru v bodě `connector.getAdjustments().get_Item(0)`:

```php
  # Nakreslí vertikální komponentu konektoru
  $x = $connector->getX() . $connector->getWidth() * $adjValue_0->getRawValue() / 100000;
  $y = $connector->getY();
  $height = $connector->getHeight() * $adjValue_1->getRawValue() / 100000;
  $sld->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 0, $height);
```

Výsledek:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Případ 2**

V **Případě 1** jsme ukázali jednoduchou operaci úpravy konektoru za použití základních principů. V běžných situacích musíte zohlednit rotaci konektoru a jeho zobrazení (nastavené metodami `connector.getRotation()`, `connector.getFrame().getFlipH()` a `connector.getFrame().getFlipV()`). Nyní tento proces demonstrujeme.

Nejprve přidáme na snímek nový objekt textového rámce (**To 1**) pro účely připojení a vytvoříme nový (zelený) konektor, který jej spojuje s již vytvořenými objekty.

```php
  # Vytvoří nový objekt vazby
  $shapeTo_1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
  $shapeTo_1->getTextFrame()->setText("To 1");
  # Vytvoří nový konektor
  $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
  $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
  $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
  $connector->getLineFormat()->setWidth(3);
  # Propojí objekty pomocí nově vytvořeného konektoru
  $connector->setStartShapeConnectedTo($shapeFrom);
  $connector->setStartShapeConnectionSiteIndex(2);
  $connector->setEndShapeConnectedTo($shapeTo_1);
  $connector->setEndShapeConnectionSiteIndex(3);
  # Získá body úpravy konektoru
  $adjValue_0 = $connector->getAdjustments()->get_Item(0);
  $adjValue_1 = $connector->getAdjustments()->get_Item(1);
  # Změní hodnoty bodů úpravy
  $adjValue_0->setRawValue($adjValue_0->getRawValue() + 20000);
  $adjValue_1->setRawValue($adjValue_1->getRawValue() + 200000);
```

Výsledek:

![connector-adjusted-3](connector-adjusted-3.png)

Druhé, vytvoříme tvar, který bude odpovídat horizontální složce konektoru procházejícího novým bodem úpravy `connector.getAdjustments().get_Item(0)`. Použijeme hodnoty z dat konektoru pro `connector.getRotation()`, `connector.getFrame().getFlipH()` a `connector.getFrame().getFlipV()` a aplikujeme běžný vzorec převodu souřadnic pro rotaci kolem bodu x₀:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

V našem případě je úhel rotace objektu 90 ° a konektor je zobrazen vertikálně, takže odpovídající kód je:

```php
  # Uloží souřadnice konektoru
  $x = $connector->getX();
  $y = $connector->getY();
  # Opraví souřadnice konektoru v případě, že se objeví
  if ($connector->getFrame()->getFlipH() == NullableBool::True) {
    $x += $connector->getWidth();
  }
  if ($connector->getFrame()->getFlipV() == NullableBool::True) {
    $y += $connector->getHeight();
  }
  # Použije hodnotu bodu úpravy jako souřadnici
  $x += $connector->getWidth() * $adjValue_0->getRawValue() / 100000;
  # Převede souřadnice, protože Sin(90) = 1 a Cos(90) = 0
  $xx = $connector->getFrame()->getCenterX() - $y . $connector->getFrame()->getCenterY();
  $yy = $x - $connector->getFrame()->getCenterX() . $connector->getFrame()->getCenterY();
  # Určí šířku horizontální komponenty pomocí druhé hodnoty bodu úpravy
  $width = $connector->getHeight() * $adjValue_1->getRawValue() / 100000;
  $shape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, $xx, $yy, $width, 0);
  $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
```

Výsledek:

![connector-adjusted-4](connector-adjusted-4.png)

Ukázali jsme výpočty zahrnující jednoduché úpravy i složité body úpravy (body úpravy s úhly rotace). S tímto vědomím můžete vytvořit vlastní model (nebo napsat kód), který získá objekt `GraphicsPath` nebo dokonce nastaví hodnoty bodů úpravy konektoru na základě konkrétních souřadnic snímku.

## **Zjištění úhlu linií konektoru**

1. Vytvořte instanci třídy.
1. Získejte odkaz na snímek podle jeho indexu.
1. Přistupte k tvaru linií konektoru.
1. Pomocí šířky, výšky, výšky rámce tvaru a šířky rámce tvaru vypočítejte úhel.

Tento PHP kód demonstruje operaci, při které jsme vypočítali úhel pro tvar linie konektoru:

```php
  $pres = new Presentation("ConnectorLineAngle.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    for($i = 0; $i < java_values($slide->getShapes()->size()) ; $i++) {
      $dir = 0.0;
      $shape = $slide->getShapes()->get_Item($i);
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $ashp = $shape;
        if ($ashp->getShapeType() == ShapeType::Line) {
          $dir = getDirection($ashp->getWidth(), $ashp->getHeight(), java_values($ashp->getFrame()->getFlipH()) > 0, $ashp->getFrame()->getFlipV() > 0);
        }
      } else if (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
        $ashp = $shape;
        $dir = getDirection($ashp->getWidth(), $ashp->getHeight(), java_values($ashp->getFrame()->getFlipH()) > 0, java_values($ashp->getFrame()->getFlipV()) > 0);
      }
      echo($dir);
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Často kladené otázky**

**Jak zjistit, zda lze konektor „přilepit“ k určitému tvaru?**

Zkontrolujte, zda tvar poskytuje [connection sites](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/getconnectionsitecount/). Pokud žádné neexistují nebo je jejich počet nula, lepení není dostupné; v takovém případě použijte volné koncové body a umístěte je ručně. Doporučuje se před připojením zkontrolovat počet míst.

**Co se stane s konektorem, když smažu jeden ze spojených tvarů?**

Jeho konce se odpojí; konektor zůstane na snímku jako obyčejná čára s volným začátkem/konce. Můžete jej smazat nebo připojit znovu a případně [reroute](https://reference.aspose.com/slides/cs/php-java/aspose.slides/connector/reroute/).

**Zůstávají vazby konektoru zachovány při kopírování snímku do jiné prezentace?**

Obecně ano, pokud jsou zároveň zkopírovány i cílové tvary. Pokud je snímek vložen do jiného souboru bez připojených tvarů, konce se uvolní a budete je muset znovu připojit.