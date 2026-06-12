---
title: Použít vzorce listu grafu v prezentacích pomocí JavaScriptu
linktitle: Vzorce listu
type: docs
weight: 70
url: /cs/nodejs-java/chart-worksheet-formulas/
keywords:
- grafický list
- list grafu
- vzorec grafu
- vzorec listu
- vzorec listu
- zdroj dat
- logická konstanta
- numerická konstanta
- řetězcová konstanta
- chybová konstanta
- aritmetická konstanta
- porovnávací operátor
- styl A1
- styl R1C1
- předdefinovaná funkce
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Použijte vzorce ve stylu Excel v Aspose.Slides pro Node.js pomocí listů grafu v Java a automatizujte sestavy v souborech PPT a PPTX v JavaScriptu."
---
## **Přehled**

Listový list v prezentaci je zdroj dat za grafem. Ukládá názvy kategorií a sérií spolu s numerickými hodnotami zobrazenými v grafu. V Aspose.Slides je tento list dostupný prostřednictvím sešitu dat grafu, který umožňuje programově pracovat s daty grafu.

Tento článek vysvětluje, jak používat vzorce v listu dat grafu tak, aby hodnoty buněk byly vypočítány a aktualizovány automaticky místo ručního zadávání. Ukazuje, jak přiřadit vzorce, používat odkazy ve stylu A1 i R1C1, přepočítat vzorce v sešitu a pracovat s podporovanými konstantami, operátory, odkazy na buňky a předdefinovanými funkcemi dostupnými pro listy grafů v prezentacích.

## **O vzorci listu grafu v prezentaci**
**List grafu** (nebo list grafu) v prezentaci je zdroj dat pro graf. List grafu obsahuje data, která jsou v grafu graficky reprezentována. Když vytvoříte graf v PowerPointu, list spojený s tímto grafem se také automaticky vytvoří. List grafu je vytvářen pro všechny typy grafů: čárový, sloupcový, sunburst, výsečový atd. Chcete‑li zobrazit list grafu v PowerPointu, dvakrát klikněte na graf:

![todo:image_alt_text](chart-worksheet-formulas_1.png)


List grafu obsahuje názvy prvků grafu (Název kategorie: *Category1*, Název série) a tabulku s číselnými údaji odpovídajícími těmto kategoriím a sériím. Ve výchozím nastavení, když vytvoříte nový graf – data listu grafu jsou nastavena na výchozí hodnoty. Poté můžete data listu v listu měnit ručně.

Obvykle graf představuje složitá data (např. finanční analytika, vědecká analytika), kde buňky jsou vypočítány z hodnot v jiných buňkách nebo z jiných dynamických dat. Manuální výpočet hodnoty buňky a její pevné zakódování do buňky ztěžuje budoucí změny. Pokud změníte hodnotu určité buňky, všechny buňky na ní závislé budou také vyžadovat aktualizaci. Navíc data v tabulce mohou záviset na datech z jiných tabulek, což vytváří složitý datový schéma prezentace, které je potřeba snadno a flexibilně aktualizovat.

**Vzorec listu grafu** v prezentaci je výraz pro automatické výpočty a aktualizaci dat listu grafu. Vzorec listu definuje logiku výpočtu dat pro určitou buňku nebo sadu buněk. Vzorec listu je matematický nebo logický vzorec, který používá: odkazy na buňky, matematické funkce, logické operátory, aritmetické operátory, převodní funkce, řetězcové konstanty atd. Definice vzorce je zapsána do buňky, a tato buňka neobsahuje jednoduchou hodnotu. Vzorec listu vypočítá hodnotu a vrátí ji zpět, pak je tato hodnota přiřazena buňce. Vzorce listu grafu v prezentacích jsou ve skutečnosti stejné jako vzorce v Excelu a podporují stejné výchozí funkce, operátory a konstanty pro jejich implementaci.

V [**Aspose.Slides**](https://products.aspose.com/slides/cs/nodejs-java/) je list grafu reprezentován metodou
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartData#getChartDataWorkbook--) typu
[**ChartDataWorkbook**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartDataWorkbook).
Vzorec listu může být přiřazen a změněn pomocí
[**ChartDataCell.setFormula**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartDataCell#setFormula-java.lang.String-) metody.
Následující funkčnost je pro vzorce v Aspose.Slides podporována:

- Logické konstanty
- Numerické konstanty
- Řetězcové konstanty
- Chybové konstanty
- Aritmetické operátory
- Porovnávací operátory
- Odkazy na buňky ve stylu A1
- Odkazy na buňky ve stylu R1C1
- Předdefinované funkce


Typicky se v listu ukládají naposledy vypočítané hodnoty vzorců. Pokud po načtení prezentace nebyla data grafu změněna – metoda [**ChartDataCell.getValue**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartDataCell#getValue--) vrátí tyto hodnoty při čtení. Pokud však byla data listu změněna, při čtení vlastnosti **ChartDataCell.Value** je vyvolána výjimka [**CellUnsupportedDataException**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/CellUnsupportedDataException) pro nepodporované vzorce. Důvodem je, že když jsou vzorce úspěšně parsovány, jsou určeny závislosti buněk a správnost posledních hodnot. Pokud však nelze vzorec parsovat, nelze zaručit správnost hodnoty buňky.

## **Přidání vzorce listu grafu do prezentace**
Nejprve přidejte graf na první snímek nové prezentace pomocí
[ShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ShapeCollection#addChart-int-float-float-float-float-).
List grafu je automaticky vytvořen a lze ho získat pomocí
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartData#getChartDataWorkbook--) metody:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 150, 150, 500, 300);
    var workbook = chart.getChartData().getChartDataWorkbook();
    // ...
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Zapište některé hodnoty do buněk pomocí
[**ChartDataCell.setValue**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartDataCell#setValue-java.lang.Object-) vlastnosti
typu **Object**, což znamená, že můžete nastavit libovolnou hodnotu:

```javascript
workbook.getCell(0, "F2").setValue(-2.5);
workbook.getCell(0, "G3").setValue(6.3);
workbook.getCell(0, "H4").setValue(3);
```

Nyní pro zápis vzorce do buňky můžete použít
[**ChartDataCell.setFormula**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartDataCell#setFormula-java.lang.String-) metodu:

*Poznámka*: [**ChartDataCell.setFormula**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartDataCell#setFormula-java.lang.String-) metoda se používá k nastavení odkazů na buňky ve stylu A1.

Pro nastavení odkazu na buňku ve stylu [R1C1Formula](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartDataCell#getR1C1Formula--) můžete použít metodu [**ChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartDataCell#setR1C1Formula-java.lang.String-):

Pak, pokud se pokusíte přečíst hodnoty z buněk B2 a C2, budou vypočteny:

```javascript
var value1 = cell1.getValue();// 7.8
var value2 = cell2.getValue();// 2.1
```

## **Logické konstanty**
Můžete použít logické konstanty jako *FALSE* a *TRUE* ve vzorcích buněk:

```javascript
workbook.getCell(0, "A2").setValue(false);
var cell = workbook.getCell(0, "B2");
cell.setFormula("A2 = TRUE");
var value = cell.getValue();// hodnota obsahuje logickou hodnotu "false"
```

## **Numerické konstanty**
Čísla mohou být používána v běžném nebo vědeckém zápisu pro tvorbu vzorce listu grafu:

```javascript
workbook.getCell(0, "A2").setFormula("1 + 0.5");
workbook.getCell(0, "B2").setFormula(".3 * 1E-2");
```

## **Řetězcové konstanty**
Řetězcová (neboli doslovná) konstanta je specifická hodnota, která se používá tak, jak je, a nemění se. Řetězcové konstanty mohou být: data, texty, čísla atd.:

```javascript
workbook.getCell(0, "A2").setFormula("\"abc\"");
workbook.getCell(0, "B2").setFormula("\"2/3/2020 12:00\"");
```

## **Chybové konstanty**
Někdy není možné vypočítat výsledek pomocí vzorce. V takovém případě se místo hodnoty v buňce zobrazí kód chyby. Každý typ chyby má specifický kód:

- #DIV/0! – vzorec se snaží dělit nulou.
- #GETTING_DATA – může se zobrazit v buňce, když její hodnota stále probíhá výpočet.
- #N/A – informace chybí nebo není dostupná. Důvody mohou být: buňky použité ve vzorci jsou prázdné, přebytečný mezerník, překlep atd.
- #NAME? – určitá buňka nebo jiný objekt vzorce nelze najít podle jména.
- #NULL! – může se objevit při chybě ve vzorci, např.  (,) nebo mezerník místo dvojtečky (:).
- #NUM! – číselná hodnota ve vzorci může být neplatná, příliš velká nebo příliš malá.
- #REF! – neplatný odkaz na buňku.
- #VALUE! – neočekávaný typ hodnoty. Například řetězec nastavený do číselné buňky.

```javascript
var cell = workbook.getCell(0, "A2");
cell.setFormula("2 / 0");
var value = cell.getValue();// hodnota obsahuje řetězec "#DIV/0!"
```

## **Aritmetické operátory**
Můžete použít všechny aritmetické operátory ve vzorcích listu grafu:

|**Operátor**|**Význam**|**Příklad**|
| :- | :- | :- |
|+ (plus)|Sčítání nebo unární plus|2 + 3|
|- (mínus)|Odčítání nebo negace|2 - 3<br>-3|
|* (hvězdička)|Násobení|2 * 3|
|/ (lomítko)|Dělení|2 / 3|
|% (procento)|Procento|30%|
|^ (stříška)|Mocnina|2 ^ 3|

*Poznámka*: Pro změnu pořadí vyhodnocování uzavřete část vzorce, která má být vypočtena jako první, do závorek.

## **Porovnávací operátory**
Můžete porovnávat hodnoty buněk pomocí porovnávacích operátorů. Když jsou dvě hodnoty porovnány těmito operátory, výsledek je logická hodnota *TRUE* nebo *FALSE*:

|**Operátor**|**Význam**|**Příklad**|
| :- | :- | :- |
|= (rovná se)|Rovná se|A2 = 3|
|<> (nerovná se)|Nerovná se|A2 <> 3|
|> (větší než)|Větší než|A2 > 3|
|>= (větší nebo rovno)|Větší nebo rovno|A2 >= 3|
|< (menší než)|Menší než|A2 < 3|
|<= (menší nebo rovno)|Menší nebo rovno|A2 <= 3|

## **Odkazy na buňky ve stylu A1**
**Odkazy na buňky ve stylu A1** se používají pro listy, kde sloupec má písmenový identifikátor (např. "*A*") a řádek má číselný identifikátor (např. "*1*"). Odkazy ve stylu A1 lze použít takto:

|**Odkaz na buňku**|**Příklad**|||
| :- | :- | :- | :- |
||Absolutní|Relativní|Smíšený|
|Buňka|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Řádek|$2:$2|2:2|-|
|Sloupec|$A:$A|A:A|-|
|Rozsah|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

Zde je příklad, jak použít odkaz ve stylu A1 ve vzorci:

```javascript
workbook.getCell(0, "A2").setFormula("C3 + SUM(F2:H5)");
```

## **Odkazy na buňky ve stylu R1C1**
**Odkazy na buňky ve stylu R1C1** se používají pro listy, kde řádek i sloupec mají číselný identifikátor. Odkazy ve stylu R1C1 lze použít takto:

|**Odkaz na buňku**|**Příklad**|||
| :- | :- | :- | :- |
||Absolutní|Relativní|Smíšený|
|Buňka|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Řádek|R2|R[2]|-|
|Sloupec|C3|C[3]|-|
|Rozsah|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

Zde je příklad, jak použít odkaz ve stylu A1 ve vzorci:

```javascript
workbook.getCell(0, "A2").setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```

## **Předdefinované funkce**
Existují předdefinované funkce, které lze ve vzorcích použít k usnadnění jejich implementace. Tyto funkce zapouzdřují nejčastěji používané operace, jako jsou:

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

**Jsou externí soubory Excel podporovány jako zdroj dat pro graf s vzorci?**

Ano. Aspose.Slides podporuje externí sešity jako [zdroj dat grafu](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdatasourcetype/), což vám umožní používat vzorce z XLSX mimo prezentaci.

**Mohou vzorce grafu odkazovat na listy ve stejném sešitu podle názvu listu?**

Ano. Vzorce používají standardní model odkazování Excelu, takže můžete odkazovat na jiné listy ve stejném sešitu nebo v externím sešitu. Pro externí odkazy zahrňte cestu a název sešitu pomocí syntaxe Excelu.