---
title: Použití vzorců listu grafu v prezentacích pomocí Pythonu
linktitle: Vzorce listu
type: docs
weight: 70
url: /cs/python-net/chart-worksheet-formulas/
keywords:
- tabulka grafu
- list grafu
- vzorec grafu
- vzorec listu
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
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Použijte vzorce ve stylu Excel v Aspose.Slides pro Python pomocí .NET listů grafu a automatizujte zprávy v souborech PPT, PPTX a ODP."
---
## **Přehled**

List pracovního listu grafu je zdroj dat za grafem v prezentaci. Uchovává názvy kategorií a řad spolu s číselnými hodnotami zobrazenými v grafu. V Aspose.Slides je tento list dostupný prostřednictvím sešitu dat grafu, což umožňuje programově pracovat s daty grafu.

Tento článek vysvětluje, jak používat vzorce v listu grafu, aby hodnoty buněk mohly být vypočítány a aktualizovány automaticky místo ručního zadání. Ukazuje, jak přiřadit vzorce, používat reference ve stylu A1 i R1C1, přepočítat vzorce v sešitu a pracovat s podporovanými konstantami, operátory, odkazy na buňky a předdefinovanými funkcemi dostupnými pro listy grafů v prezentacích.

## **O vzorci tabulky grafu v prezentaci**
**Tabulka grafu** (nebo list grafu) v prezentaci je zdrojem dat pro graf. Tabulka grafu obsahuje data, která jsou v grafu graficky znázorněna. Když vytvoříte graf v PowerPointu, automaticky se vytvoří i list spojený s tímto grafem. List grafu se vytváří pro všechny typy grafů: čárový graf, sloupcový graf, souhvězdí (sunburst) graf, koláčový graf atd. Chcete-li v PowerPointu zobrazit tabulku grafu, poklepejte na graf:

![todo:image_alt_text](chart-worksheet-formulas_1.png)

Tabulka grafu obsahuje názvy prvků grafu (Název kategorie: *Category1*, Název řady) a tabulku s číselnými údaji odpovídajícími těmto kategoriím a řadám. Ve výchozím nastavení, když vytvoříte nový graf, jsou data tabulky grafu nastavena na výchozí hodnoty. Poté můžete data v listu upravit ručně.

Obvykle graf představuje složitá data (např. finanční analytici, vědecké analýzy), kde buňky jsou vypočítány z hodnot v jiných buňkách nebo z dalších dynamických dat. Ruční výpočet hodnoty buňky a její pevné zadání ztěžuje budoucí změny. Pokud změníte hodnotu určité buňky, všechny buňky na ní závislé budou také muset být aktualizovány. Navíc data v tabulce mohou záviset na datech z jiných tabulek, což vytváří složitý datový schéma prezentace, které je potřeba aktualizovat snadno a flexibilně.

**Vzorec tabulky grafu** v prezentaci je výraz, který automaticky vypočítá a aktualizuje data tabulky grafu. Vzorec v tabulce definuje logiku výpočtu dat pro určitou buňku nebo sadu buněk. Vzorec v tabulce je matematický nebo logický vzorec, který používá: odkazy na buňky, matematické funkce, logické operátory, aritmetické operátory, konverzní funkce, řetězcové konstanty atd. Definice vzorce je zapsána do buňky, která neobsahuje jednoduchou hodnotu. Vzorec vypočítá hodnotu a vrátí ji, pak je tato hodnota přiřazena buňce. Vzorce tabulky grafu v prezentacích jsou ve skutečnosti stejné jako Excelové vzorce a podporují stejné výchozí funkce, operátory a konstanty pro jejich implementaci.

V [**Aspose.Slides**](https://products.aspose.com/slides/cs/python-net/) je tabulka grafu reprezentována vlastností [**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/ichartdata/) typu [**IChartDataWorkbook**](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/ichartdataworkbook/). Vzorec v tabulce lze přiřadit a změnit pomocí vlastnosti [**formula**](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/ichartdatacell/). Pro vzorce v Aspose.Slides je podporována následující funkcionalita:
- Logické konstanty
- Číselné konstanty
- Řetězcové konstanty
- Chybové konstanty
- Aritmetické operátory
- Porovnávací operátory
- Odkazy na buňky ve stylu A1
- Odkazy na buňky ve stylu R1C1
- Předdefinované funkce

Typicky tabulky ukládají poslední vypočítané hodnoty vzorců. Pokud po načtení prezentace nebyla data grafu změněna, vlastnost **IChartDataCell.Value** vrací tyto hodnoty při čtení. Pokud však byla data v tabulce změněna, při čtení vlastnosti **ChartDataCell.Value** vyvolá **CellUnsupportedDataException** kvůli nepodporovaným vzorcům. Důvodem je, že když jsou vzorce úspěšně parsovány, jsou určeny závislosti buněk a správnost posledních hodnot. Pokud vzorec nelze parsovat, nelze zaručit správnost hodnoty buňky.

## **Přidání vzorce tabulky grafu do prezentace**
Nejprve přidejte graf s některými ukázkovými daty na první snímek nové prezentace pomocí [add_chart](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ishapecollection/). List grafu je automaticky vytvořen a lze k němu přistupovat pomocí vlastnosti [**chart_data_workbook**](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/ichartdata/):

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 150, 150, 500, 300)
    workbook = chart.chart_data.chart_data_workbook
    # ...
```

Napišme některé hodnoty do buněk pomocí vlastnosti [**value**](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/ichartdatacell/) typu **Object**, což znamená, že můžete nastavit libovolnou hodnotu:

```py
    workbook.get_cell(0, "F2").value = -2.5
    workbook.get_cell(0, "G3").value = 6.3
    workbook.get_cell(0, "H4").value = 3
```

Nyní pro zápis vzorce do buňky můžete použít vlastnost [**formula**](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/ichartdatacell/):

```py
    workbook.get_cell(0, "B2").formula = "F2+G3+H4+1"
```

*Poznámka*: [**IChartDataCell.Formula**](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/ichartdatacell/) vlastnost se používá k nastavení odkazů na buňky ve stylu A1.

Pro nastavení odkazu na buňku [r1c1_formula](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/ichartdatacell/) můžete použít vlastnost [**r1c1_formula**](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/ichartdatacell/):

```py
    workbook.get_cell(0, "C2").r1c1_formula = "R[1]C[4]/R[2]C[5]"
```

Poté použijte metodu [**calculate_formulas**](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdataworkbook/) k vypočítání všech vzorců v sešitu a aktualizaci odpovídajících hodnot buněk:

```py
    workbook.calculate_formulas()
    print(workbook.get_cell(0, "B2").value) # 7.8
    print(workbook.get_cell(0, "C2").value) # 2.1
```

## **Logické konstanty**
Můžete v buňkových vzorcích použít logické konstanty jako *FALSE* a *TRUE*:

## **Číselné konstanty**
Čísla lze použít ve běžné nebo vědecké notaci k vytvoření vzorce tabulky grafu:

## **Řetězcové konstanty**
Řetězcová (nebo literálová) konstanta je konkrétní hodnota, která se používá tak, jak je, a nemění se. Řetězcové konstanty mohou být: data, texty, čísla atd.:

## **Chybové konstanty**
Někdy není možné vypočítat výsledek pomocí vzorce. V takovém případě se v buňce místo hodnoty zobrazí chybový kód. Každý typ chyby má specifický kód:
- #DIV/0! - vzorec se pokouší dělit nulou.
- #GETTING_DATA - může se zobrazit v buňce, zatímco její hodnota se ještě počítá.
- #N/A - informace chybí nebo není k dispozici. Důvody mohou být: buňky použité ve vzorci jsou prázdné, nadbytečný mezerník, překlep atd.
- #NAME? - určitou buňku nebo jiný objekt vzorce nelze najít podle jména. 
- #NULL! - může se objevit při chybě ve vzorci, jako je:  (,) nebo mezerník místo dvojtečky (:).
- #NUM! - číselná hodnota ve vzorci může být neplatná, příliš dlouhá nebo příliš malá atd.
- #REF! - neplatný odkaz na buňku.
- #VALUE! - neočekávaný typ hodnoty. Například řetězcová hodnota v buňce určené pro číslo.

## **Aritmetické operátory**
Můžete ve vzorcích listu grafu použít všechny aritmetické operátory:

|**Operátor**|**Význam**|**Příklad**|
| :- | :- | :- |
|+ (plus sign)|Sčítání nebo unární plus|2 + 3|
|- (minus sign)|Odčítání nebo negace|2 - 3<br>-3|
|* (asterisk)|Násobení|2 * 3|
|/ (forward slash)|Dělení|2 / 3|
|% (percent sign)|Procento|30%|
|^ (caret)|Umocnění|2 ^ 3|

*Poznámka*: Pro změnu pořadí vyhodnocení uzavřete část vzorce, která má být vypočítána první, do závorek.

## **Porovnávací operátory**
Můžete porovnávat hodnoty buněk pomocí porovnávacích operátorů. Když jsou dvě hodnoty porovnány pomocí těchto operátorů, výsledek je logická hodnota *TRUE* nebo FALSE:

|**Operátor**|**Význam**|**Příklad**|
| :- | :- | :- |
|= (equal sign)|Rovná se|A2 = 3|
|<> (not equal sign)|Nerovná se|A2 <> 3|
|> (greater than sign)|Větší než|A2 > 3|
|>= (greater than or equal to sign)|Větší nebo rovno|A2 >= 3|
|< (less than sign)|Menší než|A2 < 3|
|<= (less than or equal to sign)|Menší nebo rovno|A2 <= 3|

## **Odkazy na buňky ve stylu A1**
**Odkazy na buňky ve stylu A1** se používají v listách, kde sloupec má písmenový identifikátor (např. "*A*") a řádek má číselný identifikátor (např. "*1*"). Odkazy ve stylu A1 lze použít následujícím způsobem:

|**Reference buňky**|**Příklad**|**Absolutní**|**Relativní**|**Smíšený**|
| :- | :- | :- | :- | :- |
|**Cell**|$A$2|A2|<p>A$2</p><p>$A2</p>|
|**Row**|$2:$2|2:2|-|
|**Column**|$A:$A|A:A|-|
|**Range**|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

Zde je příklad, jak použít odkaz na buňku ve stylu A1 ve vzorci:

## **Odkazy na buňky ve stylu R1C1**
**Odkazy na buňky ve stylu R1C1** se používají v listech, kde jak řádek, tak sloupec mají číselný identifikátor. Odkazy ve stylu R1C1 lze použít následujícím způsobem:

|**Reference buňky**|**Příklad**|**Absolutní**|**Relativní**|**Smíšený**|
| :- | :- | :- | :- | :- |
|**Cell**|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|**Row**|R2|R[2]|-|
|**Column**|C3|C[3]|-|
|**Range**|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

Zde je příklad, jak použít odkaz na buňku ve stylu R1C1 ve vzorci:

## **Předdefinované funkce**
Existují předdefinované funkce, které lze ve vzorcích použít pro zjednodušení jejich implementace. Tyto funkce zapouzdřují nejčastěji používané operace, například:
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

## **Často kladené otázky**
**Jsou externí soubory Excel podporovány jako zdroj dat pro graf s vzorci?**

Ano. Aspose.Slides podporuje externí sešity jako [zdroj dat grafu](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdatasourcetype/), což umožňuje používat vzorce z XLSX mimo prezentaci.

**Mohou vzorce grafu odkazovat na listy ve stejném sešitu podle názvu listu?**

Ano. Vzorce používají standardní model odkazování v Excelu, takže můžete odkazovat na jiné listy ve stejném sešitu nebo v externím sešitu. Pro externí odkazy uveďte cestu a název sešitu pomocí syntaxe Excelu.