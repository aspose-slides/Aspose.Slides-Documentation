---
title: Použití vzorců listu grafu v prezentacích pomocí PHP
linktitle: Vzorce listu
type: docs
weight: 70
url: /cs/php-java/chart-worksheet-formulas/
keywords:
- grafový list
- list grafu
- vzorec grafu
- vzorec listu
- vzorec tabulky
- zdroj dat
- logická konstanta
- číselná konstanta
- řetězcová konstanta
- konstanta chyby
- aritmetická konstanta
- operátor porovnání
- styl A1
- styl R1C1
- předdefinovaná funkce
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: Použijte Excelové vzorce v Aspose.Slides pro PHP pomocí Java listů grafů a automatizujte zprávy v souborech PPT a PPTX.
---
## **Přehled**

Listový list je zdroj dat za grafem v prezentaci. Uchovává názvy kategorií a sérií spolu s číselnými hodnotami zobrazovanými v grafu. V Aspose.Slides je tento list k dispozici prostřednictvím sešitu dat grafu, který umožňuje pracovat s daty grafu programově.

Tento článek vysvětluje, jak používat vzorce listu v datech grafu, aby mohly být hodnoty buněk vypočítány a aktualizovány automaticky místo ručního zadávání. Ukazuje, jak přiřadit vzorce, používat odkazy ve stylu A1 i R1C1, přepočítat vzorce v sešitu a pracovat s podporovanými konstantami, operátory, odkazy na buňky a předdefinovanými funkcemi dostupnými pro listy grafů v prezentacích.

## **O vzorcích listu grafu v prezentacích**
**List grafu** (nebo list grafu) v prezentaci je zdroj dat grafu. List grafu obsahuje data, která jsou v grafu graficky znázorněna. Když vytvoříte graf v PowerPointu, automaticky se vytvoří i list přidružený k tomuto grafu. List grafu se vytváří pro všechny typy grafů: čárový graf, sloupcový graf, sunburst graf, koláčový graf atd. Chcete‑li v PowerPointu zobrazit list grafu, dvojklikněte na graf:

![todo:image_alt_text](chart-worksheet-formulas_1.png)


List grafu obsahuje názvy elementů grafu (Název kategorie: *Category1*, Název série) a tabulku s číselnými daty odpovídajícími těmto kategoriím a sériím. Ve výchozím nastavení, když vytvoříte nový graf, jsou data listu grafu nastavena na výchozí data. Poté můžete data v listu měnit ručně.

Obvykle graf představuje složitá data (např. finanční analytici, vědecké analýzy), kde buňky jsou vypočítány z hodnot v jiných buňkách nebo z jiných dynamických údajů. Ruční výpočet hodnoty buňky a její pevné zakódování ztěžuje budoucí změny. Pokud změníte hodnotu určité buňky, všechny buňky na ní závislé budou také vyžadovat aktualizaci. Navíc data v tabulce mohou záviset na datech z jiných tabulek, což vytváří složitý schéma dat v prezentaci, které je třeba snadno a flexibilně aktualizovat.

**Vzorec listu grafu** v prezentaci je výraz, který automaticky vypočítá a aktualizuje data listu grafu. Vzorec listu definuje logiku výpočtu dat pro určitou buňku nebo sadu buněk. Vzorec je matematický nebo logický vzorec, který používá: odkazy na buňky, matematické funkce, logické operátory, aritmetické operátory, konverzní funkce, řetězcové konstanty atd. Definice vzorce se zapisuje do buňky, která pak neobsahuje jednoduchou hodnotu. Vzorec vypočítá hodnotu a vrátí ji, následně se tato hodnota přiřadí buňce. Vzorce listu v prezentacích jsou ve skutečnosti stejné jako excelové vzorce a podporují stejné výchozí funkce, operátory a konstanty pro jejich implementaci.

V [**Aspose.Slides**](https://products.aspose.com/slides/cs/php-java/) je list grafu reprezentován metodou
[**ChartData::getChartDataWorkbook**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdata/#getChartDataWorkbook) typu
[**ChartDataWorkbook**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdataworkbook/).
Vzorec listu může být přiřazen a změněn pomocí metody
[**ChartDataCell::setFormula**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdatacell/#setFormula).
Následující funkčnost je v Aspose.Slides pro vzorce podporována:

- Logické konstanty
- Numerické konstanty
- Řetězcové konstanty
- Chybové konstanty
- Aritmetické operátory
- Porovnávací operátory
- Odkazy na buňky ve stylu A1
- Odkazy na buňky ve stylu R1C1
- Předdefinované funkce


Typicky se v sešitech ukládají poslední vypočtené hodnoty vzorců. Pokud po načtení prezentace data grafu nebyla změněna, metoda [**ChartDataCell::getValue**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdatacell/#getValue) vrátí tyto hodnoty při čtení. Pokud však byla data v sešitu změněna, při čtení hodnoty vyvolá [**CellUnsupportedDataException**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/CellUnsupportedDataException) kvůli nepodporovaným vzorcům. Děje se tak, protože když jsou vzorce úspěšně parsovány, jsou určeny závislosti buněk a správnost posledních hodnot. Pokud vzorec nelze parsovat, nelze zaručit správnost hodnoty buňky.

## **Přidání vzorce listu grafu do prezentace**
Nejprve přidejte graf na první snímek nové prezentace pomocí
[ShapeCollection::addChart](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/#addChart).
List grafu je vytvořen automaticky a lze k němu přistupovat metodou
[**ChartData::getChartDataWorkbook**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdata/#getChartDataWorkbook):

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 150, 150, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    # ...
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Napišme nějaké hodnoty do buněk metodou [**ChartDataCell::setValue**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdatacell/#setValue) typu **Object**, což znamená, že můžete nastavit libovolnou hodnotu:

```php
  $workbook->getCell(0, "F2")->setValue(-2.5);
  $workbook->getCell(0, "G3")->setValue(6.3);
  $workbook->getCell(0, "H4")->setValue(3);

```

Nyní k zápisu vzorce do buňky můžete použít metodu
[**ChartDataCell::setFormula**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdatacell/#setFormula).

*Poznámka*: Metoda [**ChartDataCell::setFormula**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdatacell/#setFormula) se používá pro nastavení odkazů na buňky ve stylu A1.

Pro nastavení vzorce ve stylu R1C1 můžete použít metodu [**ChartDataCell::setR1C1Formula**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdatacell/#setR1C1Formula).

Pak, pokud se pokusíte přečíst hodnoty z buněk B2 a C2, budou vypočítány:

```php
  $value1 = $cell1->getValue();// 7.8

  $value2 = $cell2->getValue();// 2.1


```

## **Logické konstanty**
Můžete použít logické konstanty jako *FALSE* a *TRUE* ve vzorcích buněk:

```php
  $workbook->getCell(0, "A2")->setValue(false);
  $cell = $workbook->getCell(0, "B2");
  $cell->setFormula("A2 = TRUE");
  $value = $cell->getValue();// hodnota obsahuje logickou hodnotu "false"


```

## **Numerické konstanty**
Čísla mohou být použita v běžné nebo vědecké notaci k vytvoření vzorce listu grafu:

```php
  $workbook->getCell(0, "A2")->setFormula("1 + 0.5");
  $workbook->getCell(0, "B2")->setFormula(".3 * 1E-2");

```

## **Řetězcové konstanty**
Řetězcová (nebo doslovná) konstanta je konkrétní hodnota, která se používá tak, jak je, a nemění se. Řetězcové konstanty mohou být: data, texty, čísla atd.:

```php
  $workbook->getCell(0, "A2")->setFormula("\"abc\"");
  $workbook->getCell(0, "B2")->setFormula("\"2/3/2020 12:00\"");

```

## **Chybové konstanty**
Někdy nelze výsledek vypočítat vzorcem. V takovém případě se v buňce namísto hodnoty zobrazí chybový kód. Každý typ chyby má specifický kód:

- #DIV/0! – vzorec se pokouší dělit nulou.
- #GETTING_DATA – může být zobrazena v buňce, zatímco její hodnota se stále počítá.
- #N/A – informace chybí nebo není k dispozici. Důvody mohou být: buňky použité ve vzorci jsou prázdné, nadbytečný mezerník, překlep atd.
- #NAME? – určitá buňka nebo jiný objekt vzorce nebyl nalezen podle názvu.
- #NULL! – může se objevit, když je ve vzorci chyba, např. (,) nebo mezerník místo dvojtečky (:).
- #NUM! – číselná hodnota ve vzorci může být neplatná, příliš dlouhá nebo příliš malá.
- #REF! – neplatný odkaz na buňku.
- #VALUE! – neočekávaný typ hodnoty. Například řetězec nastavený do číselné buňky.

```php
  $cell = $workbook->getCell(0, "A2");
  $cell->setFormula("2 / 0");
  $value = $cell->getValue();// hodnota obsahuje řetězec "#DIV/0!"


```

## **Aritmetické operátory**
Můžete použít všechny aritmetické operátory ve vzorcích listu grafu:

|**Operátor**|**Význam**|**Příklad**|
| :- | :- | :- |
|+ (plus) |Sčítání nebo unární plus|2 + 3|
|- (mínus) |Odčítání nebo negace|2 - 3<br>-3|
|* (hvězdička)|Násobení|2 * 3|
|/ (lomítko)|Dělení|2 / 3|
|% (procento) |Procenta|30%|
|^ (stříška) |Umocnění|2 ^ 3|

*Poznámka*: Pro změnu pořadí vyhodnocení uzavřete část vzorce, která má být vypočítána jako první, do závorek.

## **Porovnávací operátory**
Můžete porovnávat hodnoty buněk pomocí porovnávacích operátorů. Když jsou dvě hodnoty porovnány těmito operátory, výsledek je logická hodnota *TRUE* nebo FALSE:

|**Operátor**|**Význam**|**Příklad**|
| :- | :- | :- |
|= (rovná se) |Rovná se|A2 = 3|
|<> (nerovná se) |Nerovná se|A2 <> 3|
|> (větší než) |Větší než|A2 > 3|
|>= (větší než nebo rovno) |Větší než nebo rovno|A2 >= 3|
|< (menší než) |Menší než|A2 < 3|
|<= (menší než nebo rovno) |Menší než nebo rovno|A2 <= 3|

## **Odkazy na buňky ve stylu A1**
**Odkazy na buňky ve stylu A1** se používají pro listy, kde sloupec má písmenový identifikátor (např. "*A*") a řádek má číselný identifikátor (např. "*1*"). Odkazy ve stylu A1 lze použít následovně:

|**Odkaz na buňku**|**Příklad**|||
| :- | :- | :- | :- |
||Absolutní|Relativní|Smíšený|
|Buňka|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Řádek|$2:$2|2:2|-|
|Sloupec|$A:$A|A:A|-|
|Rozsah|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


Zde je příklad, jak použít odkaz na buňku ve stylu A1 ve vzorci:

```php
  $workbook->getCell(0, "A2")->setFormula("C3 + SUM(F2:H5)");

```

## **Odkazy na buňky ve stylu R1C1**
**Odkazy na buňky ve stylu R1C1** se používají pro listy, kde jak řádek, tak sloupec mají číselný identifikátor. Odkazy ve stylu R1C1 lze použít následovně:

|**Odkaz na buňku**|**Příklad**|||
| :- | :- | :- | :- |
||Absolutní|Relativní|Smíšený|
|Buňka|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Řádek|R2|R[2]|-|
|Sloupec|C3|C[3]|-|
|Rozsah|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


Zde je příklad, jak použít odkaz na buňku ve stylu R1C1 ve vzorci:

```php
  $workbook->getCell(0, "A2")->setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");

```

## **Předdefinované funkce**
Existují předdefinované funkce, které lze ve vzorcích použít ke zjednodušení jejich implementace. Tyto funkce zapouzdřují nejčastěji používané operace, jako jsou: 

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (systém dat 1900)
- DAYS
- FIND
- FINDB
- IF
- INDEX (referenční forma)
- LOOKUP (vektorová forma)
- MATCH (vektorová forma)
- MAX
- SUM
- VLOOKUP

## **Často kladené otázky**

**Podporují se externí soubory Excel jako zdroj dat pro graf s vzorci?**

Ano. Aspose.Slides podporuje externí sešity jako [zdroj dat grafu](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdatasourcetype/), což vám umožní použít vzorce z XLSX mimo prezentaci.

**Mohou vzorce grafu odkazovat na listy ve stejném sešitu podle názvu listu?**

Ano. Vzorce se řídí standardním modelem odkazů v Excelu, takže můžete odkazovat na jiné listy ve stejném sešitu nebo v externím sešitu. Pro externí odkazy zahrňte cestu a název sešitu pomocí syntaxe Excelu.