---
title: Použití vzorců pracovního listu grafu v prezentacích na Androidu
linktitle: Vzorce pracovního listu
type: docs
weight: 70
url: /cs/androidjava/chart-worksheet-formulas/
keywords:
- tabulka grafu
- pracovní list grafu
- vzorec grafu
- vzorec pracovního listu
- vzorec tabulky
- zdroj dat
- logická konstanta
- číselná konstanta
- řetězcová konstanta
- chybová konstanta
- aritmetická konstanta
- porovnávací operátor
- styl A1
- styl R1C1
- předdefinovaná funkce
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Použijte vzorce ve stylu Excel v Aspose.Slides pro Android pomocí Java pracovních listů grafů a automatizujte zprávy v souborech PPT a PPTX."
---
## **Přehled**

Pracovní list grafu je zdroj dat za grafem v prezentaci. Uchovává názvy kategorií a sérií spolu s číselnými hodnotami zobrazenými v grafu. V Aspose.Slides je tento pracovní list k dispozici prostřednictvím sešitu dat grafu, který umožňuje programově pracovat s daty grafu.

Tento článek vysvětluje, jak použít vzorce v pracovním listu pro data grafu, aby hodnoty buněk mohly být vypočítány a aktualizovány automaticky místo ručního zadávání. Ukazuje, jak přiřadit vzorce, používat jak odkazy ve stylu A1, tak ve stylu R1C1, přepočítávat vzorce v sešitu a pracovat s podporovanými konstantami, operátory, odkazy na buňky a předdefinovanými funkcemi dostupnými pro pracovní listy grafů v prezentacích.

## **O vzorcích tabulky grafu v prezentacích**
**Tabulka grafu** (nebo pracovní list grafu) v prezentaci je zdrojem dat grafu. Tabulka grafu obsahuje data, která jsou v grafu zobrazena graficky. Když v PowerPointu vytvoříte graf, automaticky se také vytvoří pracovní list spojený s tímto grafem. Pracovní list grafu je vytvořen pro všechny typy grafů: čárový graf, sloupcový graf, sunburst graf, koláčový graf atd. Chcete‑li v PowerPointu zobrazit tabulku grafu, dvojklikněte na graf:

![todo:image_alt_text](chart-worksheet-formulas_1.png)

Tabulka grafu obsahuje názvy prvků grafu (Název kategorie: *Category1*, Název série) a tabulku s číselnými daty odpovídajícími těmto kategoriím a sériím. Ve výchozím nastavení, když vytvoříte nový graf, jsou data tabulky grafu nastavena na výchozí data. Poté můžete data tabulky v pracovním listu ručně změnit.

Obvykle graf představuje komplikovaná data (např. finanční analytici, vědecké analytiky), přičemž buňky jsou vypočítány z hodnot v jiných buňkách nebo z jiných dynamických dat. Ruční výpočet hodnoty buňky a její pevné zakódování do buňky ztěžuje její budoucí změnu. Pokud změníte hodnotu určité buňky, všechny buňky na ní závislé budou také vyžadovat aktualizaci. Navíc data v tabulce mohou záviset na datech z jiných tabulek, což vytváří složitý datový schéma prezentace, které je potřeba snadno a flexibilně aktualizovat.

**Vzorec tabulky grafu** v prezentaci je výraz pro automatický výpočet a aktualizaci dat tabulky grafu. Vzorec tabulky definuje logiku výpočtu dat pro určitou buňku nebo sadu buněk. Vzorec tabulky je matematický nebo logický vzorec, který používá: odkazy na buňky, matematické funkce, logické operátory, aritmetické operátory, konverzní funkce, řetězcové konstanty atd. Definice vzorce je zapsána do buňky, a tato buňka neobsahuje jednoduchou hodnotu. Vzorec tabulky vypočítá hodnotu a vrátí ji zpět, poté je tato hodnota přiřazena buňce. Vzorce tabulky grafu v prezentacích jsou ve skutečnosti stejné jako Excelové vzorce a podporují stejné výchozí funkce, operátory a konstanty pro jejich implementaci.

V [**Aspose.Slides**](https://products.aspose.com/slides/cs/androidjava/) je tabulka grafu reprezentována metodou [**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IChartData#getChartDataWorkbook--) typu [**IChartDataWorkbook**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IChartDataWorkbook). Vzorec tabulky lze přiřadit a změnit metodou [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-). V Aspose.Slides jsou pro vzorce podporovány následující funkce:
- Logické konstanty
- Číselné konstanty
- Řetězcové konstanty
- Chybové konstanty
- Aritmetické operátory
- Porovnávací operátory
- Odkazy na buňky ve stylu A1
- Odkazy na buňky ve stylu R1C1
- Předdefinované funkce

Typicky sešity ukládají poslední vypočítané hodnoty vzorců. Pokud po načtení prezentace data grafu nebyla změněna, metoda [**IChartDataCell.getValue**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IChartDataCell#getValue--) vrátí při čtení tyto hodnoty. Pokud však byla data v sešitu změněna, při čtení vlastnosti **ChartDataCell.Value** vyhodí [**CellUnsupportedDataException**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/CellUnsupportedDataException) pro nepodporované vzorce. Důvodem je, že když jsou vzorce úspěšně parsovány, jsou určeny závislosti buněk a správnost posledních hodnot. Pokud vzorec nelze parsovat, správnost hodnoty buňky nelze zaručit.

## **Přidání vzorce tabulky grafu do prezentace**
Nejprve přidejte graf na první snímek nové prezentace pomocí [IShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IShapeCollection#addChart-int-float-float-float-float-). Pracovní list grafu je automaticky vytvořen a lze k němu přistupovat metodou [**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IChartData#getChartDataWorkbook--).

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 150, 150, 500, 300);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    // ...
} finally {
    if (pres != null) pres.dispose();
}
```

Zapište některé hodnoty do buněk pomocí vlastnosti [**IChartDataCell.setValue**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IChartDataCell#setValue-java.lang.Object-) typu **Object**, což znamená, že můžete nastavit libovolnou hodnotu:

```java
workbook.getCell(0, "F2").setValue(-2.5);

workbook.getCell(0, "G3").setValue(6.3);

workbook.getCell(0, "H4").setValue(3);
```

Nyní k zápisu vzorce do buňky můžete použít metodu [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-):

*Poznámka*: metoda [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) se používá k nastavení odkazů na buňky ve stylu A1.

Pro nastavení odkazu na buňku [R1C1Formula](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IChartDataCell#getR1C1Formula--) můžete použít metodu [**IChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IChartDataCell#setR1C1Formula-java.lang.String-):

Pak pokud se pokusíte přečíst hodnoty z buněk B2 a C2, budou vypočítány:

```java
Object value1 = cell1.getValue(); // 7.8

Object value2 = cell2.getValue(); // 2.1
```

## **Logické konstanty**
Můžete použít logické konstanty jako *FALSE* a *TRUE* ve vzorcích buněk:

```java
workbook.getCell(0, "A2").setValue(false);
IChartDataCell cell = workbook.getCell(0, "B2");
cell.setFormula("A2 = TRUE");
Object value = cell.getValue(); // hodnota obsahuje boolean "false"
```

## **Číselné konstanty**
Čísla lze použít v běžné nebo vědecké notaci k vytvoření vzorce tabulky grafu:

```java
workbook.getCell(0, "A2").setFormula("1 + 0.5");
workbook.getCell(0, "B2").setFormula(".3 * 1E-2");
```

## **Řetězcové konstanty**
Řetězcová (nebo literální) konstanta je konkrétní hodnota, která se používá tak, jak je, a nemění se. Řetězcové konstanty mohou být: data, texty, čísla atd.:

```java
workbook.getCell(0, "A2").setFormula("\"abc\"");
workbook.getCell(0, "B2").setFormula("\"2/3/2020 12:00\"");
```

## **Chybové konstanty**
Občas není možné vypočítat výsledek pomocí vzorce. V takovém případě se v buňce místo hodnoty zobrazí kód chyby. Každý typ chyby má specifický kód:
- #DIV/0! – vzorec se snaží dělit nulou.
- #GETTING_DATA – může být zobrazen v buňce, zatímco její hodnota se stále počítá.
- #N/A – informace chybí nebo není k dispozici. Některé důvody mohou být: buňky použité ve vzorci jsou prázdné, nadbytečný mezerník, překlep atd.
- #NAME? – určitá buňka nebo jiné objekty vzorce nelze najít podle názvu.
- #NULL! – může se objevit, když je ve vzorci chyba, např. (,) nebo místo dvojtečky (:) použit mezerník.
- #NUM! – číselná hodnota ve vzorci může být neplatná, příliš dlouhá nebo příliš malá atd.
- #REF! – neplatný odkaz na buňku.
- #VALUE! – neočekávaný typ hodnoty. Například řetězcová hodnota nastavena do číselné buňky.

```java
IChartDataCell cell = workbook.getCell(0, "A2");
cell.setFormula("2 / 0");
Object value = cell.getValue(); // hodnota obsahuje řetězec "#DIV/0!"
```

## **Aritmetické operátory**
Můžete použít všechny aritmetické operátory ve vzorcích pracovního listu grafu:

|**Operátor**|**Význam**|**Příklad**|
| :- | :- | :- |
|+ (plus)|Sčítání nebo unární plus|2 + 3|
|- (minus)|Odčítání nebo negace|2 - 3<br>-3|
|* (hvězdička)|Násobení|2 * 3|
|/ (lomítko)|Dělení|2 / 3|
|% (procento)|Procento|30%|
|^ (stříška)|Mocnina|2 ^ 3|

*Poznámka*: Pro změnu pořadí vyhodnocení uzavřete část vzorce, která má být vypočítána první, do závorek.

## **Porovnávací operátory**
Můžete porovnávat hodnoty buněk pomocí porovnávacích operátorů. Když jsou dvě hodnoty porovnány těmito operátory, výsledek je logická hodnota *TRUE* nebo FALSE:

|**Operátor**|**Význam**|**Příklad**|
| :- | :- | :- |
|= (rovná se)|Rovná se|A2 = 3|
|<> (nerovno)|Nerovná se|A2 <> 3|
|> (větší než)|Větší než|A2 > 3|
|>= (větší nebo rovno)|Větší nebo rovno|A2 >= 3|
|< (menší než)|Menší než|A2 < 3|
|<= (menší nebo rovno)|Menší nebo rovno|A2 <= 3|

## **Odkazy na buňky ve stylu A1**
**Odkazy na buňky ve stylu A1** se používají pro pracovní listy, kde sloupec má písmenový identifikátor (např. "*A*") a řádek má číselný identifikátor (např. "*1*"). Odkazy ve stylu A1 lze použít následujícím způsobem:

|**Cell reference**|**Example**|**Absolute**|**Relative**|**Mixed**|
| :- | :- | :- | :- | :- |
|Buňka|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Řádek|$2:$2|2:2|-|
|Sloupec|$A:$A|A:A|-|
|Rozsah|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

Zde je příklad, jak použít odkaz na buňku ve stylu A1 ve vzorci:

```java
workbook.getCell(0, "A2").setFormula("C3 + SUM(F2:H5)");
```

## **Odkazy na buňky ve stylu R1C1**
**Odkazy na buňky ve stylu R1C1** se používají pro pracovní listy, kde mají jak řádek, tak sloupec číselný identifikátor. Odkazy ve stylu R1C1 lze použít následujícím způsobem:

|**Cell reference**|**Example**|**Absolute**|**Relative**|**Mixed**|
| :- | :- | :- | :- | :- |
|Buňka|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Řádek|R2|R[2]|-|
|Sloupec|C3|C[3]|-|
|Rozsah|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

Zde je příklad, jak použít odkaz na buňku ve stylu R1C1 ve vzorci:

```java
workbook.getCell(0, "A2").setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```

## **Předdefinované funkce**
Existují předdefinované funkce, které lze ve vzorcích použít ke zjednodušení jejich implementace. Tyto funkce zahrnují nejčastěji používané operace, jako například:
- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (1900 date system)
- DAYS
- FIND
- FINDB
- IF
- INDEX (reference form)
- LOOKUP (vector form)
- MATCH (vector form)
- MAX
- SUM
- VLOOKUP

## **FAQ**

**Jsou externí soubory Excel podporovány jako zdroj dat pro graf s vzorci?**

Ano. Aspose.Slides podporuje externí sešity jako [zdroj dat grafu](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/chartdatasourcetype/), což vám umožní použít vzorce z XLSX mimo prezentaci.

**Mohou vzorce grafu odkazovat na listy ve stejném sešitu podle názvu listu?**

Ano. Vzorce používají standardní model odkazování v Excelu, takže můžete odkazovat na jiné listy ve stejném sešitu nebo na externí sešit. U externích odkazů uveďte cestu a název sešitu pomocí syntaxe Excel.