---
title: Použití vzorců pracovního listu grafu v prezentacích pomocí Javy
linktitle: Vzorce pracovního listu
type: docs
weight: 70
url: /cs/java/chart-worksheet-formulas/
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
- Java
- Aspose.Slides
description: "Použijte vzorce ve stylu Excel v Aspose.Slides pro Java na pracovních listech grafů a automatizujte sestavy v souborech PPT a PPTX."
---
## **Přehled**

Pracovní list grafu je zdrojem dat za grafem v prezentaci. Uchovává názvy kategorií a sérií spolu s číselnými hodnotami zobrazenými v grafu. V Aspose.Slides je tento pracovní list k dispozici prostřednictvím sešitu dat grafu, který umožňuje programově pracovat s daty grafu.

Tento článek vysvětluje, jak používat vzorce pracovního listu v datech grafu, aby hodnoty buněk mohly být vypočítány a aktualizovány automaticky místo ručního zadání. Ukazuje, jak přiřadit vzorce, používat reference stylu A1 i R1C1, přepočítat vzorce v sešitu a pracovat s podporovanými konstantami, operátory, odkazy na buňky a předdefinovanými funkcemi dostupnými pro pracovní listy grafů v prezentacích.

## **O vzorcích tabulky grafu v prezentacích**
Tabulka grafu (nebo pracovní list grafu) v prezentaci je zdrojem dat grafu. Tabulka grafu obsahuje data, která jsou v grafu zobrazena graficky. Když vytvoříte graf v PowerPointu, pracovní list spojený s tímto grafem se také automaticky vytvoří. Pracovní list se vytváří pro všechny typy grafů: čárový graf, sloupcový graf, sluneční diagram, koláčový graf, atd. Chcete‑li v PowerPointu zobrazit tabulku grafu, dvojklikněte na graf:

![todo:image_alt_text](chart-worksheet-formulas_1.png)


Tabulka grafu obsahuje názvy prvků grafu (Název kategorie: *Category1*, Název řady) a tabulku s číselnými daty odpovídajícími těmto kategoriím a řadám. Ve výchozím nastavení, když vytvoříte nový graf, data tabulky grafu jsou nastavena na výchozí data. Poté můžete data v tabulce ručně změnit.

Obvykle graf představuje složitá data (např. finanční analytici, vědecké analytiky), přičemž buňky jsou vypočítány z hodnot v jiných buňkách nebo z jiných dynamických dat. Manuální výpočet hodnoty buňky a její pevné zakódování do buňky ztěžuje budoucí změny. Pokud změníte hodnotu určité buňky, všechny buňky na ní závislé také vyžadují aktualizaci. Navíc data v tabulce mohou záviset na datech z jiných tabulek, což vytváří složitý schéma dat v prezentaci, které je potřeba snadno a flexibilně aktualizovat.

**Vzorec tabulky grafu** v prezentaci je výraz pro automatický výpočet a aktualizaci dat tabulky grafu. Vzorec tabulky definuje logiku výpočtu dat pro konkrétní buňku nebo sadu buněk. Vzorec tabulky je matematický nebo logický vzorec, který používá: odkazy na buňky, matematické funkce, logické operátory, aritmetické operátory, konverzní funkce, řetězcové konstanty atd. Definice vzorce je zapsána do buňky a tato buňka neobsahuje jednoduchou hodnotu. Vzorec vypočítá hodnotu a vrátí ji zpět, poté je tato hodnota přiřazena buňce. Vzorce tabulky grafu v prezentacích jsou ve skutečnosti stejné jako Excelové vzorce a jsou podporovány stejné výchozí funkce, operátory a konstanty pro jejich implementaci.

V [**Aspose.Slides**](https://products.aspose.com/slides/cs/java/) je tabulka grafu reprezentována metodou 
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IChartData#getChartDataWorkbook--) typu 
[**IChartDataWorkbook**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IChartDataWorkbook). 
Vzorec tabulky může být přiřazen a změněn pomocí 
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) metody. 
Následující funkčnost je pro vzorce v Aspose.Slides podporována:

- Logické konstanty
- Číselné konstanty
- Řetězcové konstanty
- Chybové konstanty
- Aritmetické operátory
- Porovnávací operátory
- Reference buněk stylu A1
- Reference buněk stylu R1C1
- Předdefinované funkce


Typicky se v sešitech ukládají poslední vypočítané hodnoty vzorců. Pokud po načtení prezentace nebyla data grafu změněna, metoda [**IChartDataCell.getValue**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IChartDataCell#getValue--) vrací tyto hodnoty při čtení. Pokud však byla data sešitu změněna, při čtení vlastnosti **ChartDataCell.Value** je vyhozena výjimka [**CellUnsupportedDataException**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/CellUnsupportedDataException) pro nepodporované vzorce. K tomu dochází, protože po úspěšném parsování vzorců jsou určeny závislosti buněk a správnost posledních hodnot je ověřena. Pokud vzorec nelze parsovat, správnost hodnoty buňky nelze zaručit.

## **Přidání vzorce tabulky grafu do prezentace**
Nejprve přidejte graf na první snímek nové prezentace pomocí 
[IShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IShapeCollection#addChart-int-float-float-float-float-). 
Pracovní list grafu je automaticky vytvořen a lze jej získat pomocí 
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IChartData#getChartDataWorkbook--) metody:

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

Zapište některé hodnoty do buněk pomocí 
[**IChartDataCell.setValue**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IChartDataCell#setValue-java.lang.Object-) vlastnosti 
typu **Object**, což znamená, že můžete nastavit libovolnou hodnotu:

```java
workbook.getCell(0, "F2").setValue(-2.5);

workbook.getCell(0, "G3").setValue(6.3);

workbook.getCell(0, "H4").setValue(3);
```

Nyní pro zápis vzorce do buňky můžete použít 
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) metodu:

*Poznámka*: [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) metoda se používá k nastavení odkazů buněk stylu A1.  

Pro nastavení odkazu buňky [R1C1Formula](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IChartDataCell#getR1C1Formula--) můžete použít metodu [**IChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IChartDataCell#setR1C1Formula-java.lang.String-):

Pak, pokud se pokusíte přečíst hodnoty z buněk B2 a C2, budou vypočítány:

```java
Object value1 = cell1.getValue(); // 7.8

Object value2 = cell2.getValue(); // 2.1
```

## **Logické konstanty**
Můžete ve vzorcích buněk použít logické konstanty jako *FALSE* a *TRUE*:

```java
workbook.getCell(0, "A2").setValue(false);
IChartDataCell cell = workbook.getCell(0, "B2");
cell.setFormula("A2 = TRUE");
Object value = cell.getValue(); // hodnota obsahuje logickou hodnotu "false"
```

## **Číselné konstanty**
Čísla lze používat v obvyklých nebo vědeckých zápisech k vytvoření vzorce tabulky grafu:

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
Někdy není možné vypočítat výsledek pomocí vzorce. V takovém případě se v buňce místo hodnoty zobrazí kód chyby. Každý typ chyby má specifický kód:

- #DIV/0! – vzorec se snaží dělit nulou.
- #GETTING_DATA – může být zobrazeno v buňce, zatímco její hodnota se ještě počítá.
- #N/A – informace chybí nebo není dostupná. Příčiny mohou být: buňky použité ve vzorci jsou prázdné, nadbytečný mezerník, překlep atd.
- #NAME? – určitá buňka nebo jiný objekt ve vzorci nelze najít podle názvu. 
- #NULL! – může se objevit, když je ve vzorci chyba, např. (,) nebo místo dvojtečky (:) použit mezerník.
- #NUM! – číslicová hodnota ve vzorci může být neplatná, příliš dlouhá nebo příliš malá.
- #REF! – neplatný odkaz na buňku.
- #VALUE! – neočekávaný typ hodnoty. Například řetězcová hodnota přiřazená číselné buňce.

```java
IChartDataCell cell = workbook.getCell(0, "A2");
cell.setFormula("2 / 0");
Object value = cell.getValue(); // hodnota obsahuje řetězec "#DIV/0!"
```

## **Aritmetické operátory**
Můžete použít všechny aritmetické operátory ve vzorcích pracovního listu grafu:

|**Operátor**|**Význam**|**Příklad**|
| :- | :- | :- |
|+ (plus sign) |Sčítání nebo unární plus|2 + 3|
|- (minus sign) |Odečtení nebo negace |2 - 3<br>-3|
|* (asterisk)|Násobení|2 * 3|
|/ (forward slash)|Dělení|2 / 3|
|% (percent sign) |Procento|30%|
|^ (caret) |Mocnina|2 ^ 3|

*Poznámka*: Chcete‑li změnit pořadí vyhodnocování, uzavřete část vzorce, která má být vypočítána jako první, do závorek.

## **Porovnávací operátory**
Můžete porovnávat hodnoty buněk pomocí porovnávacích operátorů. Když jsou dvě hodnoty porovnány těmito operátory, výsledek je logická hodnota buď *TRUE* nebo FALSE:

|**Operátor**|**Význam**|**Význam**|
| :- | :- | :- |
|= (equal sign) |Rovná se |A2 = 3|
|<> (not equal sign) |Nerovná se|A2 <> 3|
|> (greater than sign) |Větší než|A2 > 3|
|>= (greater than or equal to sign)|Větší nebo rovno|A2 >= 3|
|< (less than sign)|Menší než|A2 < 3|
|<= (less than or equal to sign)|Menší nebo rovno|A2 <= 3|

## **Reference buněk stylu A1**
**Reference buněk stylu A1** se používají pro pracovní listy, kde sloupec má písmenový identifikátor (např. "*A*") a řádek má číselný identifikátor (např. "*1*"). Reference stylu A1 lze použít následovně:

|**Reference buňky**|**Příklad**|||
| :- | :- | :- | :- |
||Absolutní|Relativní|Smíšený|
|Cell |$A$2 |A2|<p>A$2</p><p>$A2</p>|
|Row |$2:$2 |2:2 |-|
|Column |$A:$A |A:A |-|
|Range |$A$2:$C$4 |A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

Zde je příklad, jak použít odkaz buňky stylu A1 ve vzorci:

```java
workbook.getCell(0, "A2").setFormula("C3 + SUM(F2:H5)");
```

## **Reference buněk stylu R1C1**
**Reference buněk stylu R1C1** se používají pro pracovní listy, kde řádek i sloupec mají číselný identifikátor. Reference stylu R1C1 lze použít následovně:

|**Reference buňky**|**Příklad**|||
| :- | :- | :- | :- |
||Absolutní|Relativní|Smíšený|
|Cell |R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Row |R2|R[2]|-|
|Column |C3|C[3]|-|
|Range |R2C3:R5C7|R[2]C[3]:R[5]C[7] |R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

Zde je příklad, jak použít odkaz buňky stylu R1C1 ve vzorci:

```java
workbook.getCell(0, "A2").setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```

## **Předdefinované funkce**
Existují předdefinované funkce, které lze ve vzorcích použít pro zjednodušení jejich implementace. Tyto funkce zapouzdřují nejčastěji používané operace, jako:

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

Ano. Aspose.Slides podporuje externí sešity jako [zdroj dat grafu](https://reference.aspose.com/slides/cs/java/com.aspose.slides/chartdatasourcetype/), což vám umožní použít vzorce z XLSX mimo prezentaci.

**Mohou vzorce grafu odkazovat na listy ve stejném sešitě podle názvu listu?**

Ano. Vzorce používají standardní model odkazování Excelu, takže můžete odkazovat na jiné listy ve stejném sešitu nebo v externím sešitu. Pro externí odkazy zahrňte cestu a název sešitu pomocí syntaxe Excel.