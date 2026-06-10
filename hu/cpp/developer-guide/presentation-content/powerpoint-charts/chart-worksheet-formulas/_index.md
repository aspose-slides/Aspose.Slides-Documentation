---
title: Diagram munkalap képletek alkalmazása prezentációkban С++-val
linktitle: Munkalap képletek
type: docs
weight: 70
url: /hu/cpp/chart-worksheet-formulas/
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
- С++
- Aspose.Slides
description: "Excel-szerű képletek alkalmazása az Aspose.Slides C++ diagram munkalapokon, és jelentések automatizálása PPT és PPTX fájlok között."
---
## **Áttekintés**

A diagram munkalap a diagram mögötti adatforrás egy prezentációban. Tartalmazza a kategória‑ és sorozatneveket, valamint a diagramon megjelenített numerikus értékeket. Az Aspose.Slides‑ben ez a munkalap a diagram adatkönyvtárán keresztül érhető el, amely lehetővé teszi a diagram adatok programozott kezelését.

Ez a cikk bemutatja, hogyan lehet munkalap‑képleteket használni a diagram adataiban, hogy a cellaértékek automatikusan kiszámításra és frissítésre kerüljenek a kézi beírás helyett. Megmutatja, hogyan kell képleteket hozzárendelni, A1‑ és R1C1‑stílusú hivatkozásokat használni, újraszámolni a munkafüzet képleteit, valamint a diagram munkalapokon támogatott állandók, operátorok, cellahivatkozások és beépített függvények használatát a prezentációkban.

## **A diagram táblázatképletekről prezentációkban**
**Diagram táblázat** (vagy diagram munkalap) egy prezentációban a diagram adatforrása. A diagram táblázat tartalmazza az adatokat, melyek a diagramon grafikus formában jelennek meg. Amikor diagramot hozunk létre a PowerPointban, a diagramhoz kapcsolódó munkalap is automatikusan létrejön. A diagram munkalap minden diagramtípushoz létre van hozva: vonaldiagram, oszlopdiagram, napfény diagram, kördiagram stb. A diagram táblázat megtekintéséhez PowerPointban egyszerűen kattintson duplán a diagramra:

![todo:image_alt_text](chart-worksheet-formulas_1.png)

A diagram táblázat a diagramelemek neveit (Kategória neve: *Category1*, Sorozat neve) és egy táblázatot tartalmaz numerikus adatokkal, amelyek ezeknek a kategóriáknak és sorozatoknak megfelelőek. Alapértelmezés szerint új diagram létrehozásakor a diagram táblázat adatai alapértékekkel vannak feltöltve. Ezután a táblázat adatait manuálisan módosíthatja a munkalapon.

Általában a diagramok összetett adatokat ábrázolnak (például pénzügyi vagy tudományos elemzők), ahol a cellák más cellák értékeiből vagy dinamikus adatokból számítódnak. A cella értékének kézi kiszámítása és kódba írása megnehezíti a későbbi módosítást. Ha egy cella értékét megváltoztatja, az attól függő összes cellát szintén frissíteni kell. Továbbá a táblázat adatai más táblázatok adataitól is függhetnek, így egy komplex adatstruktúra jön létre, amelynek könnyen és rugalmasan kell frissíthetőnek lennie.

**Diagram táblázat képlet** egy kifejezés, amely automatikusan kiszámítja és frissíti a diagram táblázat adatait. A táblázatképlet meghatározza egy adott cella vagy cellacsoport adatkiszámítási logikáját. A táblázatképlet matematikai vagy logikai képlet, amely használ: cellahivatkozásokat, matematikai függvényeket, logikai operátorokat, aritmetikai operátorokat, konverziós függvényeket, karakterlánc‑állandókat stb. A képlet definíciója egy cellába kerül, és ez a cella nem egyszerű értéket tartalmaz. A táblázatképlet kiszámítja az értéket, visszaadja, majd az érték a cellához rendelve lesz. A diagram táblázat képletek a prezentációkban valójában ugyanazok, mint az Excel képletek, és ugyanazokat az alapértelmezett függvényeket, operátorokat és állandókat támogatják.

Az [**Aspose.Slides**](https://products.aspose.com/slides/hu/cpp/) esetében a diagram táblázat a  
[**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea)  
metódusával érhető el a  
[**IChartDataWorkbook**](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.charts.i_chart_data_workbook)  
típuson keresztül.  
A táblázatképletet a  
[**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692)  
metódussal lehet hozzárendelni és módosítani.  
Az Aspose.Slides a következő funkciókat támogatja a képletekhez:

- Logikai állandók
- Numerikus állandók
- Karakterlánc‑állandók
- Hiba‑állandók
- Aritmetikai operátorok
- Összehasonlító operátorok
- A1‑stílusú cellahivatkozások
- R1C1‑stílusú cellahivatkozások
- Beépített függvények

Általában a táblázatok az utoljára kiszámított képletértékeket tárolják. Ha a prezentáció betöltése után a diagram adatai nem változtak, a **IChartDataCell.get_Value()** metódus ezeket az értékeket adja vissza olvasáskor. Ha a táblázat adatainak módosítása történt, a **ChartDataCell.get_Value()** metódus **CellUnsupportedDataException**‑t dob a nem támogatott képletek esetén. Ennek oka, hogy a képletek sikeres elemzésekor meghatározásra kerülnek a cellafüggőségek, és az utolsó értékek helyessége ellenőrzésre kerül. Ha a képletet nem lehet elemezni, a cellaérték helyessége nem garantálható.

## **Diagram táblázat képlet hozzáadása egy prezentációhoz**
Először adjon egy diagramot egy új prezentáció első diájához az  
[IShapeCollection::AddChart()](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_shape_collection#a2cd4d47fc5c536012ee15b3a69486374)  
metódussal.  
A diagram munkalapja automatikusan létrejön, és a következő metódussal érhető el:  
[**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea):

``` cpp
auto presentation = System::MakeObject<Presentation>();
    
auto chart = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 150.0f, 150.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// ...
```

Írjunk néhány értéket a cellákba a  
[**IChartDataCell.set_Value()**](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.charts.i_chart_data_cell#ad85809f520195e09225abae9002635ec)  
metódus segítségével, amely az **Object** típusú, így bármilyen értéket átadhat a metódusnak:

``` cpp
workbook->GetCell(0, u"F2")->set_Value(System::ObjectExt::Box<double>(-2.5));
workbook->GetCell(0, u"G3")->set_Value(System::ObjectExt::Box<double>(6.3));
workbook->GetCell(0, u"H4")->set_Value(System::ObjectExt::Box<int32_t>(3));
```

Most a képlet írásához a cellába használja a  
[**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692)  
metódust:

*Megjegyzés*: a **IChartDataCell::set_Formula()** metódus A1‑stílusú cellahivatkozások beállítására szolgál.

Az **R1C1Formula** cellahivatkozás beállításához használja a  
[**IChartDataCell::set_R1C1Formula()**](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.charts.i_chart_data_cell#a47f5825dd38d0dddb11ecc3a43d388c7)  
metódust:

Ezután, ha a B2 és C2 cellák értékeit olvassa, azok számítva lesznek:

``` cpp
auto value1 = cell1->get_Value(); // 7.8
auto value2 = cell2->get_Value(); // 2.1
```

## **Logikai állandók**
Logikai állandókat, például *FALSE* és *TRUE* használhat cellaképletekben:

## **Numerikus állandók**
Számok használhatók közönséges vagy tudományos jelölésben diagram táblázat képlet létrehozásához:

## **Karakterlánc‑állandók**
A karakterlánc (vagy literál) állandó egy konkrét érték, amelyet változtatás nélkül használnak. Karakterlánc‑állandók lehetnek: dátumok, szövegek, számok stb.:

## **Hiba‑állandók**
Bizonyos esetekben a képlet nem tudja kiszámítani az eredményt. Ilyenkor a hiba kód jelenik meg a cellában az érték helyett. Minden hibatípusnak megvan a saját kódja:

- #DIV/0! – a képlet nullával osztani próbál.
- #GETTING_DATA – a cellán megjelenhet, amíg az értéke még számítás alatt áll.
- #N/A – információ hiányzik vagy nem elérhető. Okok lehetnek: a képletben használt cellák üresek, extra szóköz, elgépelés stb.
- #NAME? – egy bizonyos cella vagy más képlettárgy nem található a neve alapján.
- #NULL! – hibás képlet, például (,) vagy szóköz karakter használata kettőspont helyett (:).
- #NUM! – a képletben szereplő szám érvénytelen, túl nagy vagy túl kicsi stb.
- #REF! – érvénytelen cellahivatkozás.
- #VALUE! – nem várt értéktípus. Például szöveges érték egy numerikus cellában.

## **Aritmetikai operátorok**
Az alábbi aritmetikai operátorok használhatók diagram munkalap képletekben:

|**Operátor**|**Jelentés**|**Példa**|
| :- | :- | :- |
|+ (plusz jel)|Összeadás vagy egyelőre pozitív|2 + 3|
|- (mínusz jel)|Kivonás vagy negáció|2 - 3<br>-3|
|* (csillag)|Szorzás|2 * 3|
|/ (perjel)|Osztás|2 / 3|
|% (százalék jel)|Százalék|30%|
|^ (karet)|Hatványozás|2 ^ 3|

*Megjegyzés*: Az értékelés sorrendjének módosításához zárójelezze a képlet azon részét, amelyet először szeretne számolni.

## **Összehasonlító operátorok**
Az értékeket összehasonlíthatja összehasonlító operátorokkal. Amikor két értéket ezekkel az operátorokkal hasonlítanak össze, az eredmény logikai érték, azaz *TRUE* vagy *FALSE*:

|**Operátor**|**Jelentés**|**Példa**|
| :- | :- | :- |
|= (egyenlőség jel)|Egyenlő|A2 = 3|
|<> (nem egyenlő jel)|Nem egyenlő|A2 <> 3|
|> (nagyobb jel)|Nagyobb|A2 > 3|
|>= (nagyobb vagy egyenlő jel)|Nagyobb vagy egyenlő|A2 >= 3|
|< (kisebb jel)|Kisebb|A2 < 3|
|<= (kisebb vagy egyenlő jel)|Kisebb vagy egyenlő|A2 <= 3|

## **A1‑stílusú cellahivatkozások**
**A1‑stílusú cellahivatkozások** a munkalapoknál használatosak, ahol az oszlop betűvel (pl. "*A*") és a sor számmal (pl. "*1*") van azonosítva. Az A1‑stílusú hivatkozások a következőképpen használhatók:

|**Cellahivatkozás**|**Példa**| | |
| :- | :- | :- | :- |
| |Abszolút|Relatív|Vegyes|
|Cella|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Sor|$2:$2|2:2|-|
|Oszlop|$A:$A|A:A|-|
|Tartomány|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

Az alábbi példa bemutatja, hogyan használjon A1‑stílusú cellahivatkozást képletben:

## **R1C1‑stílusú cellahivatkozások**
**R1C1‑stílusú cellahivatkozások** a munkalapoknál használatosak, ahol a sor és az oszlop egyaránt numerikus azonosítóval rendelkezik. Az R1C1‑stílusú hivatkozások a következőképpen használhatók:

|**Cellahivatkozás**|**Példa**| | |
| :- | :- | :- | :- |
| |Abszolút|Relatív|Vegyes|
|Cella|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Sor|R2|R[2]|-|
|Oszlop|C3|C[3]|-|
|Tartomány|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

Az alábbi példa bemutatja, hogyan használjon R1C1‑stílusú cellahivatkozást képletben:

## **Beépített függvények**
Vannak beépített függvények, amelyeket a képletekben használhat a megvalósítás egyszerűsítésére. Ezek a függvények a leggyakrabban használt műveleteket foglalják össze, például:

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

## **GYIK**

**Támogatottak-e külső Excel fájlok adatforrásként a képletekkel ellátott diagramokhoz?**

Igen. Az Aspose.Slides támogatja a külső munkafüzeteket [diagram adatforrásaként](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/chartdatasourcetype/), amely lehetővé teszi az XLSX fájlokból származó képletek használatát a prezentáción kívül.

**A diagram képletei hivatkozhatnak-e ugyanabban a munkafüzetben lévő lapokra a lap neve alapján?**

Igen. A képletek követik az Excel standard hivatkozási modelljét, így hivatkozhat más lapokra ugyanabban a munkafüzetben vagy egy külső munkafüzetben. Külső hivatkozások esetén adja meg az elérési utat és a munkafüzet nevét az Excel szintaxisának megfelelően.