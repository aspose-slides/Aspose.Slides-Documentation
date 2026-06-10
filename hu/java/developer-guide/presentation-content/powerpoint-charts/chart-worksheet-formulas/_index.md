---
title: Diagram munkalap képletek alkalmazása prezentációkban Java használatával
linktitle: Munkalap képletek
type: docs
weight: 70
url: /hu/java/chart-worksheet-formulas/
keywords:
- diagram táblázat
- diagram munkalap
- diagram képlet
- munkalap képlet
- táblázati képlet
- adatforrás
- logikai állandó
- numerikus állandó
- karakterlánc állandó
- hibaállandó
- aritmetikai állandó
- összehasonlító operátor
- A1 stílus
- R1C1 stílus
- előre definiált függvény
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Alkalmazzon Excel-stílusú képleteket az Aspose.Slides for Java diagram munkalapokon, és automatizálja a jelentéseket PPT és PPTX fájlokban."
---
## **Áttekintés**

A diagram munkalapja a diagram mögötti adatforrás egy prezentációban. Tartalmazza a kategória- és sorneveket valamint a diagram által megjelenített numerikus értékeket. Az Aspose.Slides‑ben ez a munkalap a diagram adatkönyvtárán keresztül érhető el, amely lehetővé teszi a diagram adatainak programozott kezelését.

Ez a cikk bemutatja, hogyan lehet munkalap képleteket használni a diagram adataiban, hogy a cellaértékek automatikusan kiszámításra és frissítésre kerüljenek a kézi bevitel helyett. Megmutatja, hogyan kell képleteket hozzárendelni, A1‑ és R1C1‑stílusú hivatkozásokat használni, újraszámolni a munkafüzet képleteit, valamint a diagram munkalapokban a támogatott állandókat, operátorokat, cellahivatkozásokat és előre definiált függvényeket.

## **A diagram táblázat képleteiről a prezentációkban**
**Diagram táblázat** (vagy diagram munkalap) egy prezentációban a diagram adatforrása. A diagram táblázat adatokat tartalmaz, amelyek grafikus formában jelennek meg a diagramon. Amikor egy diagramot hoz létre a PowerPointban, a diagramhoz tartozó munkalap automatikusan létrejön. Diagram munkalap minden diagramtípushoz létrejön: vonaldiagram, oszlopdiagram, sunburst diagram, kördiagram stb. A diagram táblázat megtekintéséhez a PowerPointban kattintson duplán a diagramra:

![todo:image_alt_text](chart-worksheet-formulas_1.png)

A diagram táblázat tartalmazza a diagramelemek neveit (Kategória neve: *Category1*, Sor neve) és egy táblázatot numerikus adatokkal, amelyek ezekhez a kategóriákhoz és sorokhoz tartoznak. Alapértelmezés szerint, amikor új diagramot hoz létre – a diagram táblázat adatai az alapértelmezett adatokkal kerülnek beállításra. Ezután a táblázat adatait kézzel módosíthatja a munkalapon.

Általában a diagram összetett adatokat ábrázol (pl. pénzügyi vagy tudományos elemzések), ahol a cellák más cellák értékeiből vagy más dinamikus adatokból számítódnak ki. A cella értékének manuális kiszámítása és kódba írása nehezíti a jövőbeli módosítást. Ha egy adott cella értékét megváltoztatja, az attól függő összes cellát szintén frissíteni kell. Továbbá a táblázat adatai más táblázatok adataitól is függhetnek, ami egy összetett prezentációs adatstruktúrát eredményez, amelyet könnyen és rugalmasan kell frissíteni.

**Diagram táblázat képlete** egy kifejezés, amely automatikusan kiszámítja és frissíti a diagram táblázat adatait. A képlet meghatározza egy adott cella vagy cellacsoport adatkiszámítási logikáját. A képlet lehet matematikai vagy logikai, és a következőket használja: cellahivatkozások, matematikai függvények, logikai operátorok, aritmetikai operátorok, konverziós függvények, karakterlánc‑állandók stb. A képlet definíciója egy cellába íródik, így a cella nem egyszerű értéket tartalmaz. A képlet kiszámítja az értéket, visszaadja, majd ez az érték kerül a cellába. A diagram táblázat képletek a prezentációkban valójában az Excel képletek, és ugyanazok a beépített függvények, operátorok és állandók támogatottak.

Az [**Aspose.Slides**](https://products.aspose.com/slides/hu/java/) diagram táblázata a  
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IChartData#getChartDataWorkbook--) metódussal van reprezentálva az  
[**IChartDataWorkbook**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IChartDataWorkbook) típuson keresztül.  
A táblázati képletet a  
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) metódussal lehet hozzárendelni és módosítani.  
Az Aspose.Slides a következő funkcionalitást támogatja a képletekhez:

- Logikai állandók
- Numerikus állandók
- Karakterlánc‑állandók
- Hibák‑állandók
- Aritmetikai operátorok
- Összehasonlító operátorok
- A1‑stílusú cellahivatkozások
- R1C1‑stílusú cellahivatkozások
- Előre definiált függvények

Általában a táblázatok tárolják az utoljára kiszámított képletértékeket. Ha a prezentáció betöltése után a diagram adatai nem változtak – a [**IChartDataCell.getValue**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IChartDataCell#getValue--) metódus ezeket az értékeket adja vissza olvasáskor. Ha azonban a táblázati adatokat megváltoztatták, a **ChartDataCell.Value** tulajdonság olvasásakor a [**CellUnsupportedDataException**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/CellUnsupportedDataException) kivétel keletkezik a nem támogatott képletek miatt. Ennek oka, hogy ha egy képlet sikeresen kiértékelhető, a cellafüggőségek meghatározásra kerülnek, és az utolsó értékek helyessége ellenőrzésre kerül. Ha a képlet nem értelmezhető, a cella értékének helyessége nem garantálható.

## **Diagram táblázat képlet hozzáadása a prezentációhoz**
Először adjon egy diagramot egy új prezentáció első diájához a  
[IShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShapeCollection#addChart-int-float-float-float-float-) metódussal.  
A diagram munkalapa automatikusan létrejön, és a következővel érhető el:  
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IChartData#getChartDataWorkbook--) metódus:

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

Írjunk néhány értéket a cellákba a  
[**IChartDataCell.setValue**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IChartDataCell#setValue-java.lang.Object-) tulajdonsággal, amely az **Object** típusú, tehát bármilyen értéket beállíthat:

```java
workbook.getCell(0, "F2").setValue(-2.5);

workbook.getCell(0, "G3").setValue(6.3);

workbook.getCell(0, "H4").setValue(3);
```

Most a képletet a cellába a  
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) metódussal írhatja:

*Megjegyzés*: [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) metódus A1‑stílusú cellahivatkozások beállítására szolgál.

Az [R1C1Formula](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IChartDataCell#getR1C1Formula--) cellahivatkozáshoz a [**IChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IChartDataCell#setR1C1Formula-java.lang.String-) metódust kell használni:

Ezután ha a B2 és C2 cellák értékeit olvassa, azok kiszámításra kerülnek:

```java
Object value1 = cell1.getValue(); // 7.8

Object value2 = cell2.getValue(); // 2.1
```

## **Logikai állandók**
Logikai állandókat, például a *FALSE* és *TRUE* értékeket használhatja a cellaképletekben:

```java
workbook.getCell(0, "A2").setValue(false);
IChartDataCell cell = workbook.getCell(0, "B2");
cell.setFormula("A2 = TRUE");
Object value = cell.getValue(); // az érték boolean "false" értéket tartalmaz
```

## **Numerikus állandók**
Számok használhatók közös vagy tudományos jelölésben diagram táblázat képletek létrehozásához:

```java
workbook.getCell(0, "A2").setFormula("1 + 0.5");
workbook.getCell(0, "B2").setFormula(".3 * 1E-2");
```

## **Karakterlánc‑állandók**
A karakterlánc (vagy literál) állandó egy olyan konkrét érték, amelyet változtatás nélkül használunk. Karakterlánc‑állandók lehetnek dátumok, szövegek, számok stb.:

```java
workbook.getCell(0, "A2").setFormula("\"abc\"");
workbook.getCell(0, "B2").setFormula("\"2/3/2020 12:00\"");
```

## **Hibaállandók**
Néha a képlet nem tudja kiszámítani az eredményt. Ebben az esetben a hiba kód jelenik meg a cellában az érték helyett. Minden hibatípusnak saját kódja van:

- #DIV/0! – a képlet nullával próbál osztani.
- #GETTING_DATA – megjelenhet egy cellában, amíg értéke még számítás alatt áll.
- #N/A – hiányzó vagy nem elérhető információ. Oka lehet üres cella, felesleges szóköz, helyesírási hiba stb.
- #NAME? – egy adott cella vagy más képlettárgy nem található a nevén.
- #NULL! – hibás képlet, például (,) vagy egy szóköz karakter a kettőspont (: ) helyett.
- #NUM! – a képletben szereplő szám érvénytelen, túl nagy vagy túl kicsi stb.
- #REF! – érvénytelen cellahivatkozás.
- #VALUE! – váratlan értéktípus. Például karakterlánc érték numerikus cellába írása.

```java
IChartDataCell cell = workbook.getCell(0, "A2");
cell.setFormula("2 / 0");
Object value = cell.getValue(); // az érték a "#DIV/0!" karakterláncot tartalmazza
```

## **Aritmetikai operátorok**
Minden aritmetikai operátort használhat a diagram munkalap képleteiben:

|**Operátor**|**Jelentés**|**Példa**|
| :- | :- | :- |
|+ (plusz jel)|Összeadás vagy egyelőre pozitív előjel|2 + 3|
|- (mínusz jel)|Kivonás vagy negáció|2 - 3<br>-3|
|* (csillag)|Szorzás|2 * 3|
|/ (perjel)|Osztás|2 / 3|
|% (százalék)|Százalék|30%|
|^ (karon)|Hatványozás|2 ^ 3|

*Megjegyzés*: Az értékelés sorrendjének módosításához zárójelezze a képlet azon részét, amelyet előbb kell kiszámítani.

## **Összehasonlító operátorok**
A cellák értékeit összehasonlíthatja összehasonlító operátorokkal. Amikor két értéket ezzel a művelettel hasonlít össze, a végeredmény logikai érték, vagy *TRUE* vagy FALSE:

|**Operátor**|**Jelentés**|**Példa**|
| :- | :- | :- |
|= (egyenlőség)|Egyenlő|A2 = 3|
|<> (nem egyenlőség)|Nem egyenlő|A2 <> 3|
|> (nagyobb)|Nagyobb|A2 > 3|
|>= (nagyobb vagy egyenlő)|Nagyobb vagy egyenlő|A2 >= 3|
|< (kisebb)|Kisebb|A2 < 3|
|<= (kisebb vagy egyenlő)|Kisebb vagy egyenlő|A2 <= 3|

## **A1‑stílusú cellahivatkozások**
**A1‑stílusú cellahivatkozások** a munkalapokon használatosak, ahol az oszlop betűazonosítóval (pl. "*A*") és a sor számmal (pl. "*1*") rendelkezik. Az A1‑stílusú hivatkozások a következőképpen használhatók:

|**Cella hivatkozás**|**Példa**|**Abszolút**|**Relatív**|**Vegyes**|
| :- | :- | :- | :- | :- |
|Cella|$A$2|A2|A$2|$A2|
|Sor|$2:$2|2:2|-|
|Oszlop|$A:$A|A:A|-|
|Tartomány|$A$2:$C$4|A2:C4|$A$2:C4|A$2:$C4|

Az alábbi példa bemutatja, hogyan használjon A1‑stílusú cellahivatkozást képletben:

```java
workbook.getCell(0, "A2").setFormula("C3 + SUM(F2:H5)");
```

## **R1C1‑stílusú cellahivatkozások**
**R1C1‑stílusú cellahivatkozások** a munkalapokon használatosak, ahol a sor és az oszlop is számazonosítóval rendelkezik. Az R1C1‑stílusú hivatkozások a következőképpen használhatók:

|**Cella hivatkozás**|**Példa**|**Abszolút**|**Relatív**|**Vegyes**|
| :- | :- | :- | :- | :- |
|Cella|R2C3|R[2]C[3]|R2C[3]|R[2]C3|
|Sor|R2|R[2]|-|
|Oszlop|C3|C[3]|-|
|Tartomány|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]|R[2]C3:R5C[7]|

Az alábbi példa bemutatja, hogyan használjon R1C1‑stílusú cellahivatkozást képletben:

```java
workbook.getCell(0, "A2").setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```

## **Előre definiált függvények**
Vannak előre definiált függvények, amelyeket a képletekben lehet használni a megvalósítás egyszerűsítése érdekében. Ezek a függvények a leggyakrabban használt műveletek közvetítésére szolgálnak, például:

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (1900‑es dátumrendszer)
- DAYS
- FIND
- FINDB
- IF
- INDEX (referencia forma)
- LOOKUP (vektor forma)
- MATCH (vektor forma)
- MAX
- SUM
- VLOOKUP

## **GYIK**

**Támogatja-e az Aspose.Slides a képletekkel ellátott diagram adatforrásaként külső Excel fájlok használatát?**

Igen. Az Aspose.Slides támogatja a külső munkafüzeteket diagram adatforrásként ([chart's data source](https://reference.aspose.com/slides/hu/java/com.aspose.slides/chartdatasourcetype/)), amely lehetővé teszi, hogy egy XLSX‑ből származó képleteket használjon a prezentációban.

**A diagram képletei hivatkozhatnak-e a munkafüzeten belül lévő lapokra lapnév szerint?**

Igen. A képletek az Excel szabványos hivatkozási modelljét követik, így hivatkozhat más lapokra ugyanabban a munkafüzetben vagy egy külső munkafüzetben. Külső hivatkozások esetén adja meg az elérési utat és a munkafüzet nevét az Excel szintaxis szerint.