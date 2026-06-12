---
title: Použití vzorců v pracovním listu grafu v prezentacích v .NET
linktitle: Vzorce pracovního listu
type: docs
weight: 70
url: /cs/net/chart-worksheet-formulas/
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
- konstanta chyby
- aritmetická konstanta
- porovnávací operátor
- styl A1
- styl R1C1
- předdefinovaná funkce
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Použijte vzorce ve stylu Excel v Aspose.Slides pro .NET pracovní listy grafů a automatizujte reporty v souborech PPT a PPTX."
---
## **Přehled**

Pracovní list grafu je zdroj dat za grafem v prezentaci. Ukládá názvy kategorií a sérií spolu s číselnými hodnotami zobrazenými v grafu. V Aspose.Slides je tento pracovní list dostupný prostřednictvím sešitu dat grafu, který umožňuje pracovat s daty grafu programově.

Tento článek vysvětluje, jak použít vzorce v pracovním listu grafu tak, aby hodnoty buněk byly vypočítány a aktualizovány automaticky místo ručního zadávání. Ukazuje, jak přiřadit vzorce, používat reference ve stylu A1 i R1C1, přepočítat vzorce v sešitu a pracovat s podporovanými konstantami, operátory, odkazy na buňky a předdefinovanými funkcemi dostupnými pro pracovní listy grafů v prezentacích.

## **O vzorcích v tabulce grafu v prezentacích**
**Tabulka grafu** (nebo pracovní list grafu) v prezentaci je zdroj dat grafu. Tabulka grafu obsahuje data, která jsou v grafu graficky znázorněna. Když vytvoříte graf v PowerPointu, automaticky se vytvoří i pracovní list k tomuto grafu. Pracovní list grafu se vytváří pro všechny typy grafů: čárový graf, sloupcový graf, sunburst graf, koláčový graf atd. Chcete‑li zobrazit tabulku grafu v PowerPointu, dvakrát klikněte na graf:

![todo:image_alt_text](chart-worksheet-formulas_1.png)



Tabulka grafu obsahuje názvy prvků grafu (Název kategorie: *Category1*, Název série) a tabulku s číselnými daty odpovídajícími těmto kategoriím a sériím. Ve výchozím nastavení, když vytvoříte nový graf, jsou data tabulky grafu nastavena na výchozí data. Poté můžete data v tabulce upravit ručně.

Obvykle graf představuje složitá data (např. finanční analytici, vědecké analytiky), kde buňky jsou vypočítány z hodnot v jiných buňkách nebo z jiných dynamických dat. Ruční výpočet hodnot buňky a pevné zakódování do buňky ztěžuje budoucí změny. Pokud změníte hodnotu určité buňky, všechny buňky na ní závislé budou také vyžadovat aktualizaci. Navíc data v tabulce mohou záviset na datech z jiných tabulek, což vytváří složitý schéma dat prezentace vyžadující snadnou a flexibilní aktualizaci.

**Vzorec v tabulce grafu** v prezentaci je výraz pro automatický výpočet a aktualizaci dat tabulky grafu. Vzorec v tabulce definuje logiku výpočtu dat pro určitou buňku nebo sadu buněk. Vzorec je matematický nebo logický a používá: odkazy na buňky, matematické funkce, logické operátory, aritmetické operátory, konverzní funkce, řetězcové konstanty atd. Definice vzorce je zapsána do buňky, která neobsahuje jednoduchou hodnotu. Vzorec vypočítá hodnotu a vrátí ji, přičemž tato hodnota je přiřazena buňce. Vzorce v tabulkách grafů v prezentacích jsou v podstatě stejné jako excelové vzorce a podporují stejné výchozí funkce, operátory a konstanty pro jejich implementaci.

V [**Aspose.Slides**](https://products.aspose.com/slides/cs/net/) je tabulka grafu reprezentována vlastností 
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdata/properties/chartdataworkbook) typu 
[**IChartDataWorkbook**](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdataworkbook). 
Vzorec v tabulce může být přiřazen a změněn pomocí 
[**IChartDataCell.Formula**](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdatacell/properties/formula) vlastnosti. 
Následující funkčnosti jsou v Aspose.Slides pro vzorce podporovány:

- Logické konstanty
- Číselné konstanty
- Řetězcové konstanty
- Chybové konstanty
- Aritmetické operátory
- Porovnávací operátory
- Reference na buňky ve stylu A1
- Reference na buňky ve stylu R1C1
- Předdefinované funkce



Typicky se v tabulkách ukládají poslední vypočítané hodnoty vzorců. Po načtení prezentace, pokud data grafu nebyla změněna, vlastnost **IChartDataCell.Value** vrací tyto hodnoty při čtení. Pokud však byla data v tabulce změněna, při čtení vlastnosti **ChartDataCell.Value** je vyhozena výjimka **CellUnsupportedDataException** kvůli nepodporovaným vzorcům. Důvodem je, že když jsou vzorce úspěšně analyzovány, jsou určeny závislosti buněk a správnost posledních hodnot. Pokud vzorec nelze analyzovat, správnost hodnoty buňky nelze zaručit.

## **Přidání vzorce v tabulce grafu do prezentace**
Nejprve přidejte graf s nějakými ukázkovými daty na první snímek nové prezentace pomocí 
[IShapeCollection.Shapes.AddChart](https://reference.aspose.com/slides/cs/net/aspose.slides.ishapecollection/addchart/methods/1). 
Pracovní list grafu je vytvořen automaticky a lze ho získat pomocí 
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdata/properties/chartdataworkbook) vlastnosti:



``` csharp

using (var presentation = new Presentation())

{

    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 150, 150, 500, 300);

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // ...

}

```



Zapište nějaké hodnoty do buněk pomocí 
[**IChartDataCell.Value**](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdatacell/properties/value) vlastnosti 
typu **Object**, což znamená, že můžete nastavit libovolnou hodnotu do vlastnosti:



``` csharp

workbook.GetCell(0, "F2").Value = -2.5;

workbook.GetCell(0, "G3").Value = 6.3;

workbook.GetCell(0, "H4").Value = 3;

```



Nyní pro zápis vzorce do buňky můžete použít 
[**IChartDataCell.Formula**](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdatacell/properties/formula) vlastnost:

``` csharp
workbook.GetCell(0, "B2").Formula = "F2+G3+H4+1";
```

*Poznámka*: [**IChartDataCell.Formula**](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdatacell/properties/formula) se používá k nastavení odkazů na buňky ve stylu A1. 



Pro nastavení odkazu na buňku ve stylu [R1C1Formula](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdatacell/properties/r1c1formula) můžete použít vlastnost [**IChartDataCell.R1C1Formula**](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdatacell/properties/r1c1formula):

``` csharp
workbook.GetCell(0, "C2").R1C1Formula = "R[1]C[4]/R[2]C[5]";
```

Poté použijte metodu [**IChartDataWorkbook.CalculateFormulas**](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/chartdataworkbook/methods/calculateformulas) k výpočtu všech vzorců v sešitu a aktualizaci odpovídajících hodnot buněk:



``` csharp
workbook.CalculateFormulas();

object value1 = workbook.GetCell(0, "B2"); // 7.8

object value2 = workbook.GetCell(0, "C2"); // 2.1

```


## **Logické konstanty**
Můžete ve vzorcích buněk použít logické konstanty jako *FALSE* a *TRUE*:



## **Číselné konstanty**
Čísla mohou být použita v běžné nebo vědecké notaci pro vytvoření vzorce v tabulce grafu:



## **Řetězcové konstanty**
Řetězcová (nebo literálová) konstanta je konkrétní hodnota, která se používá tak, jak je, a nemění se. Řetězcové konstanty mohou být: data, texty, čísla atd.:

## **Chybové konstanty**
Někdy není možné výsledek pomocí vzorce vypočítat. V takovém případě se v buňce místo hodnoty zobrazí kód chyby. Každý typ chyby má specifický kód:

- #DIV/0! – vzorec se pokouší dělit nulou.
- #GETTING_DATA – může se zobrazit v buňce, zatímco její hodnota se stále počítá.
- #N/A – informace chybí nebo nejsou k dispozici. Důvody mohou být: buňky použité ve vzorci jsou prázdné, přebytečný mezerník, překlep atd.
- #NAME? – nelze najít určitou buňku nebo jiný objekt vzorce podle jejího názvu.
- #NULL! – může se objevit při chybě ve vzorci, např. (,) nebo mezerník místo dvojtečky (:).
- #NUM! – číselná hodnota ve vzorci může být neplatná, příliš dlouhá nebo příliš malá.
- #REF! – neplatný odkaz na buňku.
- #VALUE! – neočekávaný typ hodnoty. Například řetězcová hodnota přiřazená číselné buňce.

## **Aritmetické operátory**
Můžete použít všechny aritmetické operátory ve vzorcích pracovního listu grafu:



|**Operátor**|**Význam**|**Příklad**|
| :- | :- | :- |
|+ (plus)|Sčítání nebo unární plus|2 + 3|
|- (mínus)|Odčítání nebo negace|2 - 3<br>-3|
|* (hvězdička)|Násobení|2 * 3|
|/ (lomítko)|Dělení|2 / 3|
|% (procento)|Procento|30%|
|^ (stříška)|Umocňování|2 ^ 3|

*Poznámka*: Pro změnu pořadí vyhodnocování uzavřete část vzorce, která má být vypočítána jako první, do závorek.

## **Porovnávací operátory**
Můžete porovnávat hodnoty buněk pomocí porovnávacích operátorů. Když jsou dvě hodnoty porovnány, výsledek je logická hodnota *TRUE* nebo FALSE:



|**Operátor**|**Význam**|**Příklad**|
| :- | :- | :- |
|= (rovná se)|Rovná se|A2 = 3|
|<> (nerovná se)|Nerovná se|A2 <> 3|
|> (větší než)|Větší než|A2 > 3|
|>= (větší nebo rovno)|Větší nebo rovno|A2 >= 3|
|< (menší než)|Menší než|A2 < 3|
|<= (menší nebo rovno)|Menší nebo rovno|A2 <= 3|

## **Reference na buňky ve stylu A1**
**Reference na buňky ve stylu A1** se používají pro pracovní listy, kde sloupec má písmenový identifikátor (např. "*A*") a řádek má číselný identifikátor (např. "*1*"). Reference ve stylu A1 lze použít následujícím způsobem:



|**Odkaz na buňku**|**Příklad**| | |
| :- | :- | :- | :- |
||Absolutní|Relativní|Smíšený|
|Buňka|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Řádek|$2:$2|2:2|-|
|Sloupec|$A:$A|A:A|-|
|Rozsah|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


Zde je příklad, jak použít referenci na buňku ve stylu A1 ve vzorci:

## **Reference na buňky ve stylu R1C1**
**Reference na buňky ve stylu R1C1** se používají pro pracovní listy, kde řádek i sloupec mají číselný identifikátor. Reference ve stylu R1C1 lze použít následujícím způsobem:



|**Odkaz na buňku**|**Příklad**| | |
| :- | :- | :- | :- |
||Absolutní|Relativní|Smíšený|
|Buňka|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Řádek|R2|R[2]|-|
|Sloupec|C3|C[3]|-|
|Rozsah|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


Zde je příklad, jak použít referenci na buňku ve stylu R1C1 ve vzorci:

## **Předdefinované funkce**
Existují předdefinované funkce, které lze ve vzorcích použít ke zjednodušení jejich implementace. Tyto funkce zapouzdřují nejčastěji používané operace, například:

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (systém data 1900)
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

## **Často kladené otázky**

**Jsou externí soubory Excel podporovány jako zdroj dat pro graf s vzorci?**

Ano. Aspose.Slides podporuje externí sešity jako [zdroj dat grafu](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/chartdatasourcetype/), což vám umožní použít vzorce z XLSX mimo prezentaci.

**Mohou vzorce v grafu odkazovat na listy ve stejném sešitu podle názvu listu?**

Ano. Vzorce následují standardní model odkazování Excelu, takže můžete odkazovat na jiné listy ve stejném sešitu nebo v externím sešitu. Pro externí odkazy zahrňte cestu a název sešitu pomocí syntaxe Excelu.