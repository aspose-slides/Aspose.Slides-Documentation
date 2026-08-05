---
title: "Diagrammunkalap képletek alkalmazása a bemutatókban C++-ban"
linktitle: "Munkalap képletek"
type: docs
weight: 70
url: /hu/cpp/chart-worksheet-formulas/
keywords:
- diagramtáblázat
- diagrammunkalap
- diagram képlet
- munkalap képlet
- táblázat képlet
- adatforrás
- logikai állandó
- numerikus állandó
- szöveges állandó
- hibaállandó
- aritmetikai állandó
- összehasonlító operátor
- A1 stílus
- R1C1 stílus
- előre definiált függvény
- PowerPoint
- bemutató
- C++
- Aspose.Slides
description: "Alkalmazzon Excel‑stílusú képleteket az Aspose.Slides for C++ diagrammunkalapokon, és automatizálja a jelentéseket PPT és PPTX fájlokban."
---
## **Áttekintés**

A diagrammunkalap a diagram adatforrása a bemutatóban. Kategória- és sorozatneveket tárol a diagram által megjelenített numerikus értékekkel együtt. Az Aspose.Slides esetében ez a munkalap a diagramadat munkafüzeten keresztül érhető el, amely lehetővé teszi a diagramadatok programozott kezelését.

Ez a cikk bemutatja, hogyan használhatók munkalap‑képletek a diagramadatokban, hogy a cellaértékek automatikusan számításra és frissítésre kerüljenek a kézi beírás helyett. Megmutatja, hogyan kell képleteket hozzárendelni, A1‑ és R1C1‑stílusú hivatkozásokat használni, a munkafüzet képleteit újraszámolni, valamint a diagrammunkalapokban a bemutatókhoz elérhető támogatott állandók, operátorok, cellahivatkozások és előre definiált függvények kezelését.

## **A diagram táblázat képleteiről a bemutatókban**
**Diagramtáblázat** (vagy diagrammunkalap) a bemutatóban a diagram adatforrása. A diagramtáblázat adatokat tartalmaz, amelyek grafikus módon jelennek meg a diagramon. Amikor PowerPointban diagramot hoz létre, a diagramhoz társított munkalap automatikusan létrejön. Diagrammunkalap minden diagramtípushoz létrejön: vonaldiagram, oszlopdiagram, napfény diagram, kördiagram stb. A diagramtáblázat megtekintéséhez a PowerPointban dupla‑kattintson a diagramra:

![todo:image_alt_text](chart-worksheet-formulas_1.png)

A diagramtáblázat a diagram elemeinek neveit tartalmazza (Kategória neve: *Category1*, Sorozat neve) és egy táblázatot numerikus adatokkal, amelyek a kategóriákhoz és sorozatokhoz tartoznak. Alapértelmezés szerint új diagram létrehozásakor a diagramtáblázat adatai az alapértelmezett adatokkal vannak beállítva. Ezután a táblázat adatait kézzel módosíthatja a munkalapon.

Általában a diagram összetett adatokat ábrázol (pl. pénzügyi elemzők, tudományos elemzők), olyan cellákkal, amelyek más cellák értékeiből vagy más dinamikus adatokból számítódnak ki. A cella értékének kézi számítása és kemény kódolása megnehezíti a későbbi módosítást. Ha egy adott cella értékét megváltoztatja, az attól függő összes cellát szintén frissíteni kell. Továbbá a táblázat adatai más táblák adataira is támaszkodhatnak, ami egy összetett bemutatóadat‑sémát hoz létre, amely könnyű és rugalmas frissítést igényel.

**Diagramtáblázat képlet** a bemutatóban egy kifejezés, amely automatikusan kiszámítja és frissíti a diagramtáblázat adatait. A táblázatképlet meghatározza egy adott cella vagy cellacsoport adat‑számítási logikáját. A táblázatképlet egy matematikai vagy logikai képlet, amely a következőket használja: cellahivatkozások, matematika függvények, logikai operátorok, aritmetikai operátorok, konverziós függvények, karakterlánc állandók stb. A képlet definíciója egy cellába íródik, és ez a cella nem egyszerű értéket tartalmaz. A táblázatképlet kiszámítja az értéket és visszaadja, majd ez az érték hozzárendelődik a cellához. A diagramtáblázat képletek a bemutatókban valójában megegyeznek az Excel képletekkel, és ugyanazok a támogatott alapértelmezett függvények, operátorok és állandók állnak rendelkezésre a megvalósításukhoz.

Az [**Aspose.Slides**](https://products.aspose.com/slides/hu/cpp/) diagramtáblázat a [**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea) metódussal van reprezentálva a [**IChartDataWorkbook**](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.charts.i_chart_data_workbook) típusban. A táblázatképletet a [**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) metódussal lehet hozzárendelni és módosítani. Az alábbi funkciók támogatottak a képletekhez az Aspose.Slides-ben:

- Logikai állandók
- Numerikus állandók
- Szöveges állandók
- Hibaállandók
- Aritmetikai operátorok
- Összehasonlító operátorok
- A1‑stílusú cellahivatkozások
- R1C1‑stílusú cellahivatkozások
- Előre definiált függvények

Általában a táblázatok az utoljára kiszámított képletértékeket tárolják. Ha a bemutató betöltése után a diagramadatok nem változtak, a **IChartDataCell.get_Value()** metódus ezekeket az értékeket adja vissza olvasáskor. Ha azonban a táblázat adatokat módosították, a **ChartDataCell.get_Value()** metódus **CellUnsupportedDataException**‑t dob a nem támogatott képletek esetén. Ennek oka, hogy a képletek sikeres elemzésekor meghatározásra kerülnek a cellafüggőségek és az értékek helyessége. Ha a képlet nem elemezhető, a cella értékének helyessége nem garantálható.

## **Diagramtáblázat képlet hozzáadása a bemutatóhoz**
Először adjon egy diagramot az új bemutató első diájához a [IShapeCollection::AddChart()](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_shape_collection#a2cd4d47fc5c536012ee15b3a69486374) metódussal. A diagram munkalapja automatikusan létrejön, és a [**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea) metódussal érhető el:

``` cpp
auto presentation = System::MakeObject<Presentation>();
    
auto chart = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 150.0f, 150.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// ...
```

Írjunk néhány értéket a cellákba a **Object** típusú [**IChartDataCell.set_Value()**](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.charts.i_chart_data_cell#ad85809f520195e09225abae9002635ec) metódussal, ami azt jelenti, hogy bármilyen értéket átadhat a metódusnak:

``` cpp
workbook->GetCell(0, u"F2")->set_Value(System::ObjectExt::Box<double>(-2.5));
workbook->GetCell(0, u"G3")->set_Value(System::ObjectExt::Box<double>(6.3));
workbook->GetCell(0, u"H4")->set_Value(System::ObjectExt::Box<int32_t>(3));
```

Most a képlet írásához a cellába használhatja a [**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) metódust:

*Megjegyzés*: a [**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) metódus A1‑stílusú cellahivatkozások beállítására szolgál.

Az R1C1Formula cellahivatkozás beállításához használhatja a [**IChartDataCell::set_R1C1Formula()**](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.charts.i_chart_data_cell#a47f5825dd38d0dddb11ecc3a43d388c7) metódust:

``` cpp
auto value1 = cell1->get_Value(); // 7.8
auto value2 = cell2->get_Value(); // 2.1
```

## **Logikai állandók**
A cellaképletekben használhat logikai állandókat, például *FALSE* és *TRUE* értékeket:

## **Numerikus állandók**
Számokat közönséges vagy tudományos jelölésben is használhat a diagramtáblázat képletek létrehozásához:

## **Szöveges állandók**
A karakterlánc (vagy literál) állandó egy olyan konkrét érték, amelyet úgy használnak, ahogy van, és nem változik. Szöveges állandók lehetnek: dátumok, szövegek, számok stb.:

## **Hibaállandók**
Néha a képlettel nem lehetséges az eredmény kiszámítása. Ebben az esetben a hiba kód jelenik meg a cellában az érték helyett. Minden hibatípusnak saját kódja van:

- #DIV/0! – a képlet nulla osztásra próbál.
- #GETTING_DATA – megjelenhet egy cellán, amíg az értéke még számítás alatt van.
- #N/A – információ hiányzik vagy nem elérhető. Okok lehetnek: a képletben használt cellák üresek, extra szóköz karakter, elütés stb.
- #NAME? – a megadott névhez tartozó cella vagy egyéb képlettárgy nem található.
- #NULL! – akkor jelenik meg, ha a képletben hiba van, pl. (,) vagy szóköz karakter a kettőspont (:) helyett.
- #NUM! – a képletben szereplő szám érvénytelen, túl nagy vagy túl kicsi stb.
- #REF! – érvénytelen cellahivatkozás.
- #VALUE! – váratlan értéktípus. Például karakterlánc érték beállítása numerikus cellára.

## **Aritmetikai operátorok**
A diagrammunkalap képletekben az összes aritmetikai operátor használható:

|**Operátor**|**Jelentés**|**Példa**|
| :- | :- | :- |
|+ (plusz jel)|Összeadás vagy egyelőjű plusz|2 + 3|
|- (mínusz jel)|Kivonás vagy negáció|2 - 3<br>-3|
|* (csillag)|Szorzás|2 * 3|
|/ (osztójel)|Osztás|2 / 3|
|% (százalék jel)|Százalék|30%|
|^ (hatványjel)|Hatványozás|2 ^ 3|

*Megjegyzés*: A kiértékelés sorrendjének módosításához tegye a számítás első részét zárójelek közé.

## **Összehasonlító operátorok**
A cellaértékeket összehasonlító operátorokkal hasonlíthatja össze. Ha két értéket ezekkel az operátorokkal hasonlítunk össze, az eredmény logikai érték, vagy *TRUE* vagy FALSE lesz:

|**Operátor**|**Jelentés**|**Példa**|
| :- | :- | :- |
|= (egyenlőség jel)|Egyenlő|A2 = 3|
|<> (nem egyenlő jel)|Nem egyenlő|A2 <> 3|
|> (nagyobb jel)|Nagyobb|A2 > 3|
|>= (nagyobb vagy egyenlő jel)|Nagyobb vagy egyenlő|A2 >= 3|
|< (kisebb jel)|Kisebb|A2 < 3|
|<= (kisebb vagy egyenlő jel)|Kisebb vagy egyenlő|A2 <= 3|

## **A1‑stílusú cellahivatkozások**
**A1‑stílusú cellahivatkozások** a munkalapokon használatosak, ahol az oszlop betűvel (pl. "*A*") és a sor számmal (pl. "*1*") van azonosítva. Az A1‑stílusú cellahivatkozásokat a következő módon lehet használni:

|**Cell reference**|**Example**|**Absolute**|**Relative**|**Mixed**|
| :- | :- | :- | :- | :- |
|Cell|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Row|$2:$2|2:2|-|
|Column|$A:$A|A:A|-|
|Range|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

Itt egy példa, hogyan használja az A1‑stílusú cellahivatkozást képletben:

## **R1C1‑stílusú cellahivatkozások**
**R1C1‑stílusú cellahivatkozások** a munkalapokon használatosak, ahol a sor és az oszlop is numerikus azonosítóval rendelkezik. A R1C1‑stílusú cellahivatkozásokat a következő módon lehet használni:

|**Cell reference**|**Example**|**Absolute**|**Relative**|**Mixed**|
| :- | :- | :- | :- | :- |
|Cell|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Row|R2|R[2]|-|
|Column|C3|C[3]|-|
|Range|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

Itt egy példa, hogyan használja a R1C1‑stílusú cellahivatkozást képletben:

## **Előre definiált függvények**
Vannak előre definiált függvények, amelyeket a képletekben a megvalósítás egyszerűsítésére lehet használni. Ezek a függvények a leggyakrabban használt műveleteket foglalják össze, például:

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

**Támogatottak-e külső Excel fájlok adatforrásként a képletekkel rendelkező diagramhoz?**

Igen. Az Aspose.Slides támogatja a külső munkafüzeteket a [diagram adatforrásaként](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/chartdatasourcetype/), ami lehetővé teszi, hogy a bemutatón kívül lévő XLSX fájlból származó képleteket használja.

**A diagram képletek hivatkozhatnak a munkafüzeten belüli lapokra a lap nevén?**

Igen. A képletek a szabványos Excel hivatkozási modellnek megfelelően működnek, így hivatkozhat más lapokra ugyanabban a munkafüzetben vagy egy külső munkafüzetre. A külső hivatkozásokhoz adja meg az elérési utat és a munkafüzet nevét az Excel szintaxis szerint.