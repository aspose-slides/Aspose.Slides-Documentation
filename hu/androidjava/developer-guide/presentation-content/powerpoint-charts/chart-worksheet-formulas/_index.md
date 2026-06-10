---
title: Diagram munkalap képletek alkalmazása Android bemutatókban
linktitle: Munkalap képletek
type: docs
weight: 70
url: /hu/androidjava/chart-worksheet-formulas/
keywords:
- diagram táblázat
- diagram munkalap
- diagram képlet
- munkalap képlet
- táblázat képlet
- adatforrás
- logikai állandó
- numerikus állandó
- karakterlánc állandó
- hiba állandó
- aritmetikai állandó
- összehasonlító operátor
- A1 stílus
- R1C1 stílus
- előre definiált függvény
- PowerPoint
- bemutató
- Android
- Java
- Aspose.Slides
description: "Excel-szerű képletek alkalmazása az Aspose.Slides Android verziójában Java diagram munkalapokon, és jelentések automatizálása PPT és PPTX fájlokban."
---
## **Áttekintés**

A diagram munkalap a diagram mögötti adatforrás egy bemutatóban. Tárolja a kategória- és sorneveket a diagram által megjelenített numerikus értékekkel együtt. Az Aspose.Slides-ban ez a munkalap a diagram adatkönyvtáron keresztül érhető el, amely lehetővé teszi a diagram adatok programozott kezelését.

Ez a cikk bemutatja, hogyan használhatók munkalap képletek a diagram adatokban, hogy a cellaértékek automatikusan kiszámítódjanak és frissüljenek a manuális bevitel helyett. Megmutatja, hogyan kell képleteket hozzárendelni, A1‑stílusú és R1C1‑stílusú hivatkozásokat használni, újraszámolni a munkafüzet képleteket, valamint a diagram munkalapokban a támogatott állandókat, operátorokat, cellahivatkozásokat és előre definiált függvényeket.

## **A Diagram Táblázatképletekről a Bemutatókban**
**Diagram táblázat** (vagy diagram munkalap) a bemutatóban a diagram adatforrása. A diagram táblázat adatokat tartalmaz, amelyeket grafikus módon jelenít meg a diagram. Amikor diagramot hoz létre PowerPointban, a diagramhoz tartozó munkalap automatikusan létrejön. A diagram munkalap minden diagramtípushoz létrejön: vonaldiagram, oszlopdiagram, napfénydiagram, kördiagram stb. A diagram táblázat megtekintéséhez PowerPointban kattintson duplán a diagramra:

![todo:image_alt_text](chart-worksheet-formulas_1.png)

A diagram táblázat a diagram elemeinek nevét tartalmazza (Kategória neve: *Category1*, Sor neve) és egy táblázatot numerikus adatokkal, amelyek a kategóriákhoz és sorokhoz illeszkednek. Alapértelmezés szerint egy új diagram létrehozásakor a diagram táblázat adatai alapértelmezett adatokkal vannak beállítva. Ezután manuálisan módosíthatja a táblázat adatait a munkalapon.

Általában a diagram összetett adatokat ábrázol (pl. pénzügyi elemzők, tudományos elemzők), ahol a cellák más cellák értékeiből vagy más dinamikus adatokból számítódnak. A cella értékének manuális kiszámítása és a kézzel beírt érték nehezíti a jövőbeli módosítást. Ha egy adott cella értékét megváltoztatja, az attól függő összes cellát is frissíteni kell. Továbbá, a táblázat adatai más táblák adataitól is függenek, ami komplex bemutató adatstruktúrát hoz létre, amelyet könnyen és rugalmasan kell frissíteni.

**Diagram táblázat képlet** a bemutatóban egy kifejezés, amely automatikusan kiszámítja és frissíti a diagram táblázat adatait. A táblázat képlet meghatározza az adat számítási logikáját egy adott cellára vagy cellacsoportra. A táblázat képlet matematikai vagy logikai képlet, amely a következőket használja: cellahivatkozások, matematikai függvények, logikai operátorok, aritmetikai operátorok, konverziós függvények, karakterlánc állandók stb. A képlet definíciója egy cellába íródik, és ez a cella nem tartalmaz egyszerű értéket. A táblázat képlet kiszámítja az értéket és visszaadja, majd ezt az értéket a cellához rendeli. A diagram táblázat képletek a bemutatókban valójában ugyanazok, mint az Excel képletek, és ugyanazok az alapértelmezett függvények, operátorok és állandók támogatottak a megvalósításukhoz.

In [**Aspose.Slides**](https://products.aspose.com/slides/hu/androidjava/) diagram táblázat a [**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IChartData#getChartDataWorkbook--) metódussal van ábrázolva. A táblázat képletet a [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) metódussal lehet hozzárendelni és módosítani. Az alábbi funkcionalitás támogatott a képletekhez az Aspose.Slides-ban:

- Logikai állandók
- Numerikus állandók
- Szöveges állandók
- Hibás állandók
- Aritmetikai operátorok
- Összehasonlító operátorok
- A1‑stílusú cellahivatkozások
- R1C1‑stílusú cellahivatkozások
- Előre definiált függvények

Általában a táblázatok az utoljára kiszámított képletértékeket tárolják. Ha a bemutató betöltése után a diagram adatai nem változtak, a [**IChartDataCell.getValue**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IChartDataCell#getValue--) metódus ezeket az értékeket adja vissza olvasáskor. Ha azonban a táblázat adatait megváltoztatták, az **ChartDataCell.Value** tulajdonság olvasása során a [**CellUnsupportedDataException**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/CellUnsupportedDataException) kivétel keletkezik a nem támogatott képletek miatt. Ennek oka, hogy a képletek sikeres elemzésekor meghatározódik a cellák függősége és az utolsó értékek helyessége. Ha a képletet nem lehet elemezni, a cella értékének helyessége nem garantálható.

## **Diagram Táblázat Képlet Hozzáadása a Bemutatóhoz**
Először adjon diagramot az új bemutató első diájához a [IShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShapeCollection#addChart-int-float-float-float-float-) metódussal. A diagram munkalapja automatikusan létrejön, és a [**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IChartData#getChartDataWorkbook--) metódussal érhető el:

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

Írjunk néhány értéket a cellákba a **Object** típusú [**IChartDataCell.setValue**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IChartDataCell#setValue-java.lang.Object-) tulajdonsággal, amely lehetővé teszi bármilyen érték beállítását:

```java
workbook.getCell(0, "F2").setValue(-2.5);

workbook.getCell(0, "G3").setValue(6.3);

workbook.getCell(0, "H4").setValue(3);
```

Most a képlet írásához a cellába használhatja a [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) metódust:

*Megjegyzés*: [**IChartDataCell.setFormula**] metódust A1‑stílusú cellahivatkozások beállítására használják.

A [R1C1Formula] cellahivatkozás beállításához használhatja a [**IChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IChartDataCell#setR1C1Formula-java.lang.String-) metódust:

Ezután, ha megpróbálja olvasni a B2 és C2 cellák értékeit, azok kiszámításra kerülnek:

```java
Object value1 = cell1.getValue(); // 7.8

Object value2 = cell2.getValue(); // 2.1
```

## **Logikai Állandók**
Cellaképletekben használhat logikai állandókat, például a *FALSE* és a *TRUE* értékeket:

```java
workbook.getCell(0, "A2").setValue(false);
IChartDataCell cell = workbook.getCell(0, "B2");
cell.setFormula("A2 = TRUE");
Object value = cell.getValue(); // az érték logikai "false" értéket tartalmaz
```

## **Numerikus Állandók**
A számok használhatók közönséges vagy tudományos jelölésben a diagram táblázat képlet létrehozásához:

```java
workbook.getCell(0, "A2").setFormula("1 + 0.5");
workbook.getCell(0, "B2").setFormula(".3 * 1E-2");
```

## **Szöveges Állandók**
A karakterlánc (vagy literál) állandó egy meghatározott érték, amelyet úgy használunk, ahogy van, és nem változik. Szöveges állandók lehetnek: dátumok, szövegek, számok stb.:

```java
workbook.getCell(0, "A2").setFormula("\"abc\"");
workbook.getCell(0, "B2").setFormula("\"2/3/2020 12:00\"");
```

## **Hiba Állandók**
Néha nem lehetséges a képlet eredményének kiszámítása. Ilyenkor a hiba kód jelenik meg a cellában az érték helyett. Minden hibatípusnak saját kódja van:

- #DIV/0! – a képlet nullával való osztást próbál.
- #GETTING_DATA – megjelenhet egy cellán, amíg az értéke még számítás alatt van.
- #N/A – információ hiányzik vagy nem elérhető. Okok lehetnek: a képletben használt cellák üresek, extra szóköz karakter, elütés stb.
- #NAME? – egy adott cella vagy más képlettárgy nem található a neve alapján.
- #NULL! – megjelenhet, ha a képletben hiba van, például (,) vagy szóköz karakter kettőspont (: ) helyett.
- #NUM! – a képletben szereplő szám érvénytelen, túl nagy vagy túl kicsi stb.
- #REF! – érvénytelen cellahivatkozás.
- #VALUE! – váratlan értéktípus. Például karakterlánc érték lett beállítva numerikus cellába.

```java
IChartDataCell cell = workbook.getCell(0, "A2");
cell.setFormula("2 / 0");
Object value = cell.getValue(); // az érték tartalmazza a "#DIV/0!" karakterláncot
```

## **Aritmetikai Operátorok**
Használhatja az összes aritmetikai operátort a diagram munkalap képleteiben:

|**Operátor**|**Jelentés**|**Példa**|
| :- | :- | :- |
|+ (plusz jel)|Összeadás vagy unáris plusz|2 + 3|
|- (minusz jel)|Kivonás vagy negáció|2 - 3<br>-3|
|* (asterisk)|Szorzás|2 * 3|
|/ (forward slash)|Osztás|2 / 3|
|% (percent sign)|Százalék|30%|
|^ (caret)|Hatványozás|2 ^ 3|

*Megjegyzés*: Az értékelés sorrendjének módosításához zárja zárójelbe a képlet azon részét, amelyet először szeretne kiszámolni.

## **Összehasonlító Operátorok**
Cellák értékeit összehasonlíthatja az összehasonlító operátorokkal. Ha két értéket ezekkel az operátorokkal hasonlítunk össze, az eredmény logikai érték, amely vagy *TRUE* vagy *FALSE*.

|**Operátor**|**Jelentés**|**Példa**|
| :- | :- | :- |
|= (equal sign)|Egyenlő|A2 = 3|
|<> (not equal sign)|Nem egyenlő|A2 <> 3|
|> (greater than sign)|Nagyobb, mint|A2 > 3|
|>= (greater than or equal to sign)|Nagyobb vagy egyenlő|A2 >= 3|
|< (less than sign)|Kisebb, mint|A2 < 3|
|<= (less than or equal to sign)|Kisebb vagy egyenlő|A2 <= 3|

## **A1-stílusú Cellahivatkozások**
**A1-stílusú cellahivatkozásokat** a munkalapokban használják, ahol az oszlop betűazonosítóval (pl. "*A*") és a sor számmal (pl. "*1*") rendelkezik. A1-stílusú cellahivatkozásokat a következő módon lehet használni:

|**Cell reference**|**Example**|||
| :- | :- | :- | :- |
||Abszolút |Relatív |Vegyes|
|Cell |$A$2 |A2|<p>A$2</p><p>$A2</p>|
|Row |$2:$2 |2:2 |-|
|Column |$A:$A |A:A |-|
|Range |$A$2:$C$4 |A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

Itt egy példa, hogyan használjon A1-stílusú cellahivatkozást egy képletben:

```java
workbook.getCell(0, "A2").setFormula("C3 + SUM(F2:H5)");
```

## **R1C1-stílusú Cellahivatkozások**
**R1C1-stílusú cellahivatkozásokat** a munkalapokban használják, ahol a sor és az oszlop is numerikus azonosítóval rendelkezik. R1C1-stílusú cellahivatkozásokat a következő módon lehet használni:

|**Cell reference**|**Example**|||
| :- | :- | :- | :- |
||Abszolút |Relatív |Vegyes|
|Cell |R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Row |R2|R[2]|-|
|Column |C3|C[3]|-|
|Range |R2C3:R5C7|R[2]C[3]:R[5]C[7] |R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

Itt egy példa, hogyan használjon R1C1-stílusú cellahivatkozást egy képletben:

```java
workbook.getCell(0, "A2").setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```

## **Előre Definiált Függvények**
Léteznek előre definiált függvények, amelyeket a képletekben használhat a megvalósítás egyszerűsítésére. Ezek a függvények az általánosan használt műveleteket foglalják magukban, például:

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

## **GYIK**

**Támogatottak-e külső Excel fájlok adatforrásként a képletekkel rendelkező diagramokhoz?**

Igen. Az Aspose.Slides támogatja a külső munkafüzeteket [diagram adatforrásaként](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/chartdatasourcetype/), amely lehetővé teszi, hogy az XLSX fájlból származó képleteket a bemutatóban használja.

**A diagram képletek hivatkozhatnak-e a munkafüzeten belül lévő lapokra a lap nevével?**

Igen. A képletek a szabványos Excel hivatkozási modellnek megfelelően működnek, így hivatkozhat más lapokra ugyanabban a munkafüzetben vagy egy külső munkafüzetben. Külső hivatkozásoknál a fájl útvonalát és a munkafüzet nevét kell megadni az Excel szintaxis szerint.