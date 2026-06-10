---
title: Diagram munkalap képletek alkalmazása prezentációkban .NET
linktitle: Munkalap képletek
type: docs
weight: 70
url: /hu/net/chart-worksheet-formulas/
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
- .NET
- C#
- Aspose.Slides
description: "Excel-stílusú képletek alkalmazása az Aspose.Slides for .NET diagram munkalapokon, és jelentések automatizálása PPT és PPTX fájlokban."
---
## **Áttekintés**

A diagram munkalap a diagram adatforrása egy prezentációban. A kategória- és sorozatneveket a diagram által megjelenített numerikus értékekkel együtt tárolja. Az Aspose.Slides-ben ez a munkalap a diagram adatkönyvtáron keresztül érhető el, amely lehetővé teszi a diagram adatok programozott kezelését.

Ez a cikk bemutatja, hogyan használhatók munkalap képletek a diagram adataiban, hogy a cellaértékek automatikusan kiszámításra és frissítésre kerüljenek ahelyett, hogy manuálisan lennének megadva. Megmutatja, hogyan kell képleteket hozzárendelni, A1- és R1C1-stílusú hivatkozásokat használni, újraszámolni a munkafüzet képleteket, valamint a diagram munkalapokban a prezentációkban elérhető támogatott állandókat, operátorokat, cellahivatkozásokat és előre definiált függvényeket kezelni.

## **A diagram táblázatképletekről a prezentációkban**

**Diagram táblázat** (vagy diagram munkalap) a prezentációban a diagram adatforrása. A diagram táblázat adatokat tartalmaz, amelyeket a diagram grafikus formában ábrázol. Amikor diagramot hozol létre a PowerPointban, a diagramhoz tartozó munkalap is automatikusan létrejön. Diagram munkalapot minden típusú diagramhoz hoznak létre: vonaldiagram, oszlopdiagram, napfény diagram, kördiagram stb. A diagram táblázat megtekintéséhez a PowerPointban duplán kattints a diagramra:

![todo:image_alt_text](chart-worksheet-formulas_1.png)

A diagram táblázat a diagram elemeinek nevét tartalmazza (Kategória neve: *Category1*, Sorozat neve) és egy táblázatot numerikus adatokkal, amelyek megfelelnek ezeknek a kategóriáknak és sorozatoknak. Alapértelmezés szerint új diagram létrehozásakor a diagram táblázat adatai az alapértelmezett adatokkal vannak beállítva. Ezután manuálisan módosíthatod a táblázat adatait a munkalapon.

Általában a diagram összetett adatokat ábrázol (pl. pénzügyi elemzők, tudományos elemzők), amelyek cellái más cellák értékeiből vagy más dinamikus adatokból számítódnak. A cella értékének kézi kiszámítása és a cellába való beégetése megnehezíti a jövőbeli módosítást. Ha megváltoztatod egy adott cella értékét, az attól függő összes cellát is frissíteni kell. Továbbá a táblázat adatai függhetnek más táblázatok adataitól, ami egy bonyolult prezentációs adatstruktúrát hoz létre, amelyet egyszerűen és rugalmasan kell frissíteni.

**Diagram táblázat képlet** a prezentációban egy kifejezés, amely automatikusan kiszámítja és frissíti a diagram táblázat adatait. A táblázat képlet meghatározza egy adott cella vagy cellacsoport adatkis-számítási logikáját. A táblázat képlet matematikai vagy logikai képlet, amely a következőket használja: cellahivatkozásokat, matematikai függvényeket, logikai operátorokat, aritmetikai operátorokat, átalakító függvényeket, karakterlánc állandókat stb. A képlet definíciója egy cellába íródik, és ez a cella nem egyszerű értéket tartalmaz. A táblázat képlet kiszámítja az értéket és visszaadja, majd ezt az értéket a cellához rendeli. A diagram táblázat képletek a prezentációkban gyakorlatilag megegyeznek az excel képletekkel, és ugyanazokat az alapértelmezett függvényeket, operátorokat és állandókat támogatják a megvalósításukhoz.

Az [**Aspose.Slides**](https://products.aspose.com/slides/hu/net/) diagram táblázata a [**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdata/properties/chartdataworkbook) tulajdonsággal van reprezentálva a [**IChartDataWorkbook**](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdataworkbook) típusban. A táblázat képletet a [**IChartDataCell.Formula**](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatacell/properties/formula) tulajdonsággal lehet hozzárendelni és módosítani. A következő funkcionalitás támogatott a képletekben az Aspose.Slides-ben:

- Logikai állandók
- Numerikus állandók
- Szöveges állandók
- Hibával kapcsolatos állandók
- Aritmetikai operátorok
- Összehasonlító operátorok
- A1-stílusú cellahivatkozások
- R1C1-stílusú cellahivatkozások
- Előre definiált függvények

Általában a táblázatok az utoljára kiszámított képletértékeket tárolják. Ha a prezentáció betöltése után a diagram adatai nem változtak – a **IChartDataCell.Value** tulajdonság ezeket az értékeket adja vissza olvasáskor. Ha azonban a táblázat adatait megváltoztatták, a **ChartDataCell.Value** tulajdonság olvasásakor **CellUnsupportedDataException**-t dob a nem támogatott képletek esetén. Ennek oka, hogy ha a képletek sikeresen vannak elemzve, a cellafüggőségek meghatározásra kerülnek, és az utolsó értékek helyessége ellenőrizhető. Ha a képletet nem lehet elemezni, a cellaérték helyessége nem garantálható.

## **Diagram táblázat képlet hozzáadása a prezentációhoz**

Először adj hozzá egy diagramot néhány mintaadattal az új prezentáció első diájához az [IShapeCollection.Shapes.AddChart](https://reference.aspose.com/slides/hu/net/aspose.slides.ishapecollection/addchart/methods/1) metódussal. A diagram munkalapja automatikusan létrejön, és a [**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdata/properties/chartdataworkbook) tulajdonsággal érhető el:

``` csharp

using (var presentation = new Presentation())

{

    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 150, 150, 500, 300);

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // ...

}
```

Írjunk néhány értéket a cellákba az **Object** típusú [**IChartDataCell.Value**](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatacell/properties/value) tulajdonsággal, ami azt jelenti, hogy bármilyen értéket beállíthatsz a tulajdonságra:

``` csharp

workbook.GetCell(0, "F2").Value = -2.5;

workbook.GetCell(0, "G3").Value = 6.3;

workbook.GetCell(0, "H4").Value = 3;

```

Most, hogy képletet írjunk a cellába, használhatod a [**IChartDataCell.Formula**](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatacell/properties/formula) tulajdonságot:

``` csharp
workbook.GetCell(0, "B2").Formula = "F2+G3+H4+1";
```

*Megjegyzés*: a [**IChartDataCell.Formula**](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatacell/properties/formula) tulajdonságot A1-stílusú cellahivatkozások beállításához használják.

Az [R1C1Formula](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatacell/properties/r1c1formula) cellahivatkozás beállításához használhatod a [**IChartDataCell.R1C1Formula**](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatacell/properties/r1c1formula) tulajdonságot:

``` csharp
workbook.GetCell(0, "C2").R1C1Formula = "R[1]C[4]/R[2]C[5]";
```

Ezután a [**IChartDataWorkbook.CalculateFormulas**](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/chartdataworkbook/methods/calculateformulas) metódust használhatod a munkafüzet összes képletének kiszámításához és a megfelelő cellaértékek frissítéséhez:

``` csharp
workbook.CalculateFormulas();

object value1 = workbook.GetCell(0, "B2"); // 7.8

object value2 = workbook.GetCell(0, "C2"); // 2.1

```

## **Logikai állandók**

A cellaképletekben használhatsz logikai állandókat, például a *FALSE* és *TRUE* értékeket:

## **Numerikus állandók**

A számok használhatók közös vagy tudományos jelölésben a diagram táblázat képletének létrehozásához:

## **Szöveges állandók**

A karakterlánc (vagy literál) állandó egy konkrét érték, amelyet változtatás nélkül használunk. A karakterlánc állandók lehetnek: dátumok, szövegek, számok stb.:

## **Hibával kapcsolatos állandók**

Néha nem lehetséges a képlet eredményének kiszámítása. Ebben az esetben a hibakód jelenik meg a cellában az érték helyett. Minden hibatípusnak saját kódja van:

- #DIV/0! – a képlet nullával osztást próbál végezni.
- #GETTING_DATA – megjelenhet a cellán, amíg az érték még számítás alatt áll.
- #N/A – az információ hiányzik vagy nem elérhető. Okok lehetnek: a képletben használt cellák üresek, extra szóköz karakter, elütés stb.
- #NAME? – egy adott cellát vagy egyéb képlettárgyat nem talál a név alapján.
- #NULL! – megjelenhet, ha a képletben hiba van, például: (,) vagy szóköz karakter a kettőspont helyett (:).
- #NUM! – a képletben szereplő szám érvénytelen, túl nagy vagy túl kicsi, stb.
- #REF! – érvénytelen cellahivatkozás.
- #VALUE! – váratlan értéktípus. Például szöveges érték egy numerikus cellában.

## **Aritmetikai operátorok**

A diagram munkalap képletekben használhatod az összes aritmetikai operátort:

|**Operátor**|**Jelentés**|**Példa**|
| :- | :- | :- |
|+ (plusz jel)|Összeadás vagy egyöntetű plusz|2 + 3|
|- (mínusz jel)|Kivonás vagy negáció|2 - 3<br>-3|
|* (csillag)|Szorzás|2 * 3|
|/ (perjel)|Osztás|2 / 3|
|% (százalékjel)|Százalék|30%|
|^ (karon)|Hatványozás|2 ^ 3|

*Megjegyzés*: A kiértékelés sorrendjének módosításához zárd zárójelbe a képlet azon részét, amelyet először kell kiszámítani.

## **Összehasonlító operátorok**

A cellák értékeit összehasonlíthatod az összehasonlító operátorokkal. Amikor két értéket ezekkel az operátorokkal hasonlítunk össze, az eredmény logikai érték, vagy *TRUE*, vagy FALSE lesz:

|**Operátor**|**Jelentés**|**Példa**|
| :- | :- | :- |
|= (egyenlőségjel)|Egyenlő|A2 = 3|
|<> (nem egyenlő)|Nem egyenlő|A2 <> 3|
|> (nagyobb)|Nagyobb mint|A2 > 3|
|>= (nagyobb vagy egyenlő)|Nagyobb vagy egyenlő|A2 >= 3|
|< (kisebb)|Kisebb mint|A2 < 3|
|<= (kisebb vagy egyenlő)|Kisebb vagy egyenlő|A2 <= 3|

## **A1-stílusú cellahivatkozások**

**A1-stílusú cellahivatkozások** a munkalapokon használatosak, ahol az oszlop betűvel (pl. "*A*") és a sor számmal (pl. "*1*") azonosított. Az A1-stílusú cellahivatkozások a következő módon használhatók:

|**Cellahivatkozás**|**Példa**|||
| :- | :- | :- | :- |
||**Abszolút**|**Relatív**|**Vegyes**|
|Cella|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Sor|$2:$2|2:2|-|
|Oszlop|$A:$A|A:A|-|
|Tartomány|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

Itt egy példa az A1-stílusú cellahivatkozás használatára képletben:

## **R1C1-stílusú cellahivatkozások**

**R1C1-stílusú cellahivatkozások** a munkalapokon használatosak, ahol a sor és az oszlop is numerikus azonosítóval rendelkezik. Az R1C1-stílusú cellahivatkozások a következő módon használhatók:

|**Cellahivatkozás**|**Példa**|||
| :- | :- | :- | :- |
||**Abszolút**|**Relatív**|**Vegyes**|
|Cella|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Sor|R2|R[2]|-|
|Oszlop|C3|C[3]|-|
|Tartomány|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

Itt egy példa az R1C1-stílusú cellahivatkozás használatára képletben:

## **Előre definiált függvények**

Vannak előre definiált függvények, amelyek a képletekben használhatók a megvalósításuk egyszerűsítésére. Ezek a függvények a leggyakrabban használt műveleteket foglalják magukba, például:

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

**Támogatottak-e külső Excel fájlok adatforrásként egy képletekkel rendelkező diagram esetén?**

**Igen. Az Aspose.Slides támogatja a külső munkafüzeteket, mint a [diagram adatforrása](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/chartdatasourcetype/), ami lehetővé teszi, hogy a prezentáción kívüli XLSX fájlból származó képleteket használjuk.**

**Hivatkozhatnak-e a diagram képletek a munkafüzeten belüli lapokra lapnév szerint?**

**Igen. A képletek az Excel szabványos hivatkozási modelljét követik, így hivatkozhatsz ugyanebben a munkafüzetben lévő más lapokra vagy egy külső munkafüzetre. Külső hivatkozások esetén add meg az útvonalat és a munkafüzet nevét az Excel szintaxisának megfelelően.**