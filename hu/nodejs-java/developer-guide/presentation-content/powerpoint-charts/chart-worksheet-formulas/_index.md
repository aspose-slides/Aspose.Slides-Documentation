---
title: Diagram munkalap képletek alkalmazása prezentációkban JavaScript használatával
linktitle: Munkalap képletek
type: docs
weight: 70
url: /hu/nodejs-java/chart-worksheet-formulas/
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
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Alkalmazz Excel-stílusú képleteket az Aspose.Slides for Node.js-ben Java diagram munkalapokon, és automatizáld a jelentéseket PPT és PPTX fájlokban JavaScript segítségével."
---
## **Áttekintés**

A diagram munkalap a diagram mögötti adatforrás a prezentációban. Tárolja a kategória- és sorozatneveket a diagram által megjelenített numerikus értékekkel együtt. Az Aspose.Slides esetében ez a munkalap a diagram adatkönyvtárán keresztül érhető el, amely lehetővé teszi a diagram adatok programozott kezelését.

Ez a cikk bemutatja, hogyan használhatók munkalap képletek a diagram adatokban, hogy a cellaértékek automatikusan kiszámításra és frissítésre kerüljenek a kézi bevitel helyett. Megmutatja a képletek hozzárendelését, az A1‑stílusú és R1C1‑stílusú hivatkozások használatát, a munkafüzet képletek újraszámítását, valamint a diagram munkalapokban támogatott állandókat, operátorokat, cellahivatkozásokat és előre definiált függvényeket.

## **A diagram táblázatkép képlete a prezentációban**
A prezentáció **diagram táblázata** (vagy diagram munkalap) a diagram adatforrása. A diagram táblázata tartalmazza az adatokat, amelyeket a diagram grafikus formában jelenít meg. Amikor diagramot hozol létre a PowerPointban, a diagramhoz tartozó munkalap automatikusan létrejön. Minden diagramtípushoz (vonaldiagram, oszlopdiagram, napfény diagram, kördiagram stb.) készül diagram munkalap. A diagram táblázatát a PowerPointban a diagram duplakattintásával tekintheted meg:

![todo:image_alt_text](chart-worksheet-formulas_1.png)


A diagram táblázata a diagram elemeinek neveit tartalmazza (Kategória neve: *Category1*, Sorozat neve) és egy táblázatot numerikus adatokkal, amelyek a kategóriáknak és sorozatoknak megfelelőek. Alapértelmezésként, amikor új diagramot hozol létre, a diagram táblázat adatai alapértelmezett értékekkel vannak beállítva. Ezután a táblázat adatait manuálisan módosíthatod a munkalapon.

Általában a diagram összetett adatokat ábrázol (pl. pénzügyi elemzők, tudományos elemzők), olyan cellákkal, amelyek más cellák értékeiből vagy dinamikus adatforrásokból számolódnak. Ha a cella értékét kézzel számolod ki és kemény kódba írod, nehéz később módosítani. Ha megváltoztatod egy adott cella értékét, az attól függő összes cellát is frissíteni kell. Ezen felül a táblázat adatai más táblázatok adataitól is függhetnek, így egy komplex prezentációs adatstruktúra alakul ki, amelyet könnyen és rugalmasan kell frissíteni.

A **diagram táblázatkép képlete** a prezentációban egy kifejezés, amely automatikusan kiszámítja és frissíti a diagram táblázat adatait. A képlet meghatározza egy adott cella vagy cellacsoport adatkihasználási logikáját. A képlet lehet matematikai vagy logikai, és a következőket használja: cellahivatkozások, matematikai függvények, logikai operátorok, aritmetikai operátorok, konverziós függvények, karakterlánc állandók stb. A képlet definíciója egy cellába íródik, és ez a cella nem egyszerű értéket tartalmaz. A képlet kiszámítja az értéket, visszaadja, majd ez az érték kerül a cellába. A diagram táblázat képletek a prezentációkban valójában ugyanazok, mint az Excel képletek, és ugyanazok a támogatott alapértelmezett függvények, operátorok és állandók állnak rendelkezésre a megvalósításukhoz.

Az [**Aspose.Slides**](https://products.aspose.com/slides/hu/nodejs-java/) diagram táblázata a
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartData#getChartDataWorkbook--) metódussal
képviselt [**ChartDataWorkbook**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartDataWorkbook) típuson keresztül.
A táblázatkép képletet a
[**ChartDataCell.setFormula**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartDataCell#setFormula-java.lang.String-) metódussal lehet hozzárendelni és módosítani.
Az alábbi funkciók támogatottak a képleteknél az Aspose.Slides‑ben:

- Logikai állandók
- Numerikus állandók
- Karakterlánc állandók
- Hiba állandók
- Aritmetikai operátorok
- Összehasonlító operátorok
- A1‑stílusú cellahivatkozások
- R1C1‑stílusú cellahivatkozások
- Előre definiált függvények


Általában a táblázatok tárolják a legutóbb kiszámított képletértékeket. Ha a prezentáció betöltése után a diagram adatai nem változtak, a [**ChartDataCell.getValue**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartDataCell#getValue--) metódus ezeket az értékeket adja vissza olvasáskor. Ha azonban a táblázat adatait módosították, a **ChartDataCell.Value** tulajdonság olvasásakor a [**CellUnsupportedDataException**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/CellUnsupportedDataException) kivételt dobja a nem támogatott képletek miatt. Ennek oka, hogy a képletek sikeres elemzésekor meghatározódnak a cellafüggőségek és ellenőrzésre kerül a legutóbbi érték helyessége. Ha a képletet nem lehet elemezni, a cellaérték helyessége nem garantálható.

## **Diagram táblázat képlet hozzáadása a prezentációhoz**
Először adj egy diagramot az új prezentáció első diájához a
[ShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ShapeCollection#addChart-int-float-float-float-float-) metódussal.
A diagram munkalapja automatikusan létrejön, és a következővel érhető el:
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartData#getChartDataWorkbook--) metódus:

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

Írjunk néhány értéket a cellákba a
[**ChartDataCell.setValue**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartDataCell#setValue-java.lang.Object-) tulajdonsággal,
amely a **Object** típusú, tehát bármilyen értéket beállíthatsz:

```javascript
workbook.getCell(0, "F2").setValue(-2.5);
workbook.getCell(0, "G3").setValue(6.3);
workbook.getCell(0, "H4").setValue(3);
```

Most a képletet a cellába a
[**ChartDataCell.setFormula**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartDataCell#setFormula-java.lang.String-) metódussal írhatod:

*Megjegyzés*: a [**ChartDataCell.setFormula**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartDataCell#setFormula-java.lang.String-) metódus A1‑stílusú cellahivatkozások beállítására szolgál.

Az [R1C1Formula](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartDataCell#getR1C1Formula--) cellahivatkozás beállításához a
[**ChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartDataCell#setR1C1Formula-java.lang.String-) metódust használhatod:

Ezután, ha a B2 és C2 cellák értékeit olvasod, azok kiszámításra kerülnek:

```javascript
var value1 = cell1.getValue();// 7.8
var value2 = cell2.getValue();// 2.1
```

## **Logikai állandók**
Logikai állandókat, például a *FALSE* és *TRUE* értékeket használhatod a cellaképletekben:

```javascript
workbook.getCell(0, "A2").setValue(false);
var cell = workbook.getCell(0, "B2");
cell.setFormula("A2 = TRUE");
var value = cell.getValue();// az érték logikai "false"-t tartalmaz
```

## **Numerikus állandók**
Számok használhatók közönséges vagy tudományos jelölésben a diagram táblázatkép képletek létrehozásához:

```javascript
workbook.getCell(0, "A2").setFormula("1 + 0.5");
workbook.getCell(0, "B2").setFormula(".3 * 1E-2");
```

## **Karakterlánc állandók**
A karakterlánc (vagy literál) állandó egy olyan specifikus érték, amelyet változtatás nélkül használnak. Karakterlánc állandók lehetnek: dátumok, szövegek, számok stb.:

```javascript
workbook.getCell(0, "A2").setFormula("\"abc\"");
workbook.getCell(0, "B2").setFormula("\"2/3/2020 12:00\"");
```

## **Hiba állandók**
Néha a képlet nem tudja kiszámítani az eredményt. Ebben az esetben a hibakód jelenik meg a cellában az érték helyett. Minden hibatípusnak saját kódja van:

- #DIV/0! – a képlet nullával oszt.
- #GETTING_DATA – a cellán megjelenhet, amíg az értéke még számítás alatt áll.
- #N/A – információ hiányzik vagy nem elérhető. Oka lehet: üres cella a képletben, felesleges szóköz, elütés stb.
- #NAME? – egy adott cella vagy más képlethez tartozó objektum nem található a nevén.
- #NULL! – a képletben szintaktikai hiba, például (,) vagy egy szóköz helyett kettőspont (:).
- #NUM! – a képletben szereplő szám érvénytelen, túl nagy vagy túl kicsi stb.
- #REF! – érvénytelen cellahivatkozás.
- #VALUE! – váratlan típusú érték. Például karakterlánc érték numerikus cellába.

```javascript
var cell = workbook.getCell(0, "A2");
cell.setFormula("2 / 0");
var value = cell.getValue();// az érték tartalmazza a "#DIV/0!" karakterláncot
```

## **Aritmetikai operátorok**
A diagram munkalap képleteiben az összes aritmetikai operátort használhatod:

|**Operátor**|**Jelentés**|**Példa**|
| :- | :- | :- |
|+ (plusz jel)|Összeadás vagy egyjegyű plusz|2 + 3|
|- (mínusz jel)|Kivonás vagy negáció|2 - 3<br>-3|
|* (csillag)|Szorzás|2 * 3|
|/ (perjel)|Osztás|2 / 3|
|% (százalék)|Százalék|30%|
|^ (caret)|Hatványozás|2 ^ 3|

*Megjegyzés*: A kiértékelés sorrendjének módosításához zárójelezd a képlet azon részét, amelyet előbb kell számolni.

## **Összehasonlító operátorok**
Az összehasonlító operátorokkal a cellák értékét hasonlíthatod össze. Két érték összehasonlítása ezekkel az operátorokkal logikai eredményt ad: *TRUE* vagy *FALSE*:

|**Operátor**|**Jelentés**|**Jelentés**|
| :- | :- | :- |
|= (egyenlő jel)|Egyenlő|A2 = 3|
|<> (nem egyenlő jel)|Nem egyenlő|A2 <> 3|
|> (nagyobb jel)|Nagyobb|A2 > 3|
|>= (nagyobb vagy egyenlő jel)|Nagyobb vagy egyenlő|A2 >= 3|
|< (kisebb jel)|Kisebb|A2 < 3|
|<= (kisebb vagy egyenlő jel)|Kisebb vagy egyenlő|A2 <= 3|

## **A1‑stílusú cellahivatkozások**
Az **A1‑stílusú cellahivatkozások** a munkalapoknál használatosak, ahol az oszlop betűvel (pl. "*A*"), a sor pedig számmal (pl. "*1*") azonosítható. Az A1‑stílusú hivatkozások a következőképpen alkalmazhatók:

|**Cellahivatkozás**|**Példa**|||
| :- | :- | :- | :- |
||Abszolút|Relatív|Vegyes|
|Cella|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Sor|$2:$2|2:2|-|
|Oszlop|$A:$A|A:A|-|
|Tartomány|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

Példa az A1‑stílusú cellahivatkozás használatára képletben:

```javascript
workbook.getCell(0, "A2").setFormula("C3 + SUM(F2:H5)");
```

## **R1C1‑stílusú cellahivatkozások**
Az **R1C1‑stílusú cellahivatkozások** a munkalapoknál használatosak, ahol mind a sor, mind az oszlop numerikus azonosítóval rendelkezik. Az R1C1‑stílusú hivatkozások a következőképpen alkalmazhatók:

|**Cellahivatkozás**|**Példa**|||
| :- | :- | :- | :- |
||Abszolút|Relatív|Vegyes|
|Cella|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Sor|R2|R[2]|-|
|Oszlop|C3|C[3]|-|
|Tartomány|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


Példa az R1C1‑stílusú cellahivatkozás használatára képletben:

```javascript
workbook.getCell(0, "A2").setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```

## **Előre definiált függvények**
Vannak előre definiált függvények, amelyeket a képletekben használhatsz a megvalósításuk egyszerűsítésére. Ezek a függvények a leggyakrabban használt műveleteket foglalják magukba, például:

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (1900-as dátumrendszer)
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

## **Gyakran ismételt kérdések**

**Támogatottak-e külső Excel fájlok adatforrásként a képletekkel ellátott diagramhoz?**

Igen. Az Aspose.Slides támogatja a külső munkafüzeteket [diagram adatforrásaként](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdatasourcetype/), lehetővé téve, hogy az XLSX‑ben lévő képleteket a prezentáción kívül is használhasd.

**A diagram képletei hivatkozhatnak-e ugyanabban a munkafüzetben lévő munkalapokra név alapján?**

Igen. A képletek a standard Excel hivatkozási modellnek felelnek meg, így hivatkozhatsz más munkalapokra ugyanabban a munkafüzetben vagy egy külső munkafüzetben. Külső hivatkozások esetén a fájlútvonalat és a munkafüzet nevét kell megadni az Excel szintaxis szerint.