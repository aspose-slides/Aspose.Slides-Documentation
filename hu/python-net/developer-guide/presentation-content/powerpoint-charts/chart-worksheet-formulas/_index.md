---
title: Diagram munkalap képletek alkalmazása prezentációkban Python segítségével
linktitle: Munkalap képletek
type: docs
weight: 70
url: /hu/python-net/chart-worksheet-formulas/
keywords:
- diagram táblázat
- diagram munkalap
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
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Excel‑stílusú képletek alkalmazása az Aspose.Slides for Python .NET diagram munkalapokon, és jelentések automatizálása PPT, PPTX és ODP fájlokban."
---
## **Áttekintés**

A diagram munkalap a diagram mögötti adatforrás egy prezentációban. Ez tárolja a kategória- és sorneveket a diagram által megjelenített numerikus értékekkel együtt. Az Aspose.Slides‑ben ez a munkalap a diagram adatkönyvtáron (chart data workbook) keresztül érhető el, amely lehetővé teszi a diagramadatok programozott kezelését.

Ez a cikk bemutatja, hogyan használhatók munkalap képletek a diagramadatokban, hogy a cellaértékek automatikusan kiszámítódjanak és frissüljenek a manuális bevitel helyett. Megmutatja, hogyan kell képleteket hozzárendelni, hogyan használhatók az A1‑stílusú és R1C1‑stílusú hivatkozások, hogyan kell újraszámolni a munkafüzet képleteit, valamint a diagram munkalapokban a prezentációkban támogatott állandók, operátorok, cellahivatkozások és előre definiált függvények használatát.

## **A diagram táblázat képletéről a prezentációban**
**Diagram táblázat** (vagy diagram munkalap) a prezentációban a diagram adatforrása. A diagram táblázat adatokat tartalmaz, amelyeket a diagram grafikus formában jelenít meg. Amikor PowerPoint‑ban létrehoz egy diagramot, a diagramhoz tartozó munkalap automatikusan létrejön. A diagram munkalap minden diagramtípushoz létrejön: vonaldiagram, oszlopdiagram, napfény diagram, kördiagram stb. A diagram táblázat PowerPoint‑ban való megtekintéséhez kattintson duplán a diagramra:

![todo:image_alt_text](chart-worksheet-formulas_1.png)

A diagram táblázat a diagram elemeinek neveit (Kategória neve: *Category1*, Sor neve) és egy numerikus adatot tartalmazó táblázatot foglal magában, amely ezekhez a kategóriákhoz és sorokhoz illeszkedik. Alapértelmezés szerint egy új diagram létrehozásakor a diagram táblázat adatai az alapértelmezett adatokkal vannak beállítva. Ezután manuálisan módosíthatja a táblázat adatait a munkalapon.

Általában a diagram bonyolult adatokat ábrázol (pl. pénzügyi elemzők, tudományos elemzők), ahol a cellák értékei más cellák értékeiből vagy dinamikus adatokból számítódnak. A cella értékének manuális kiszámítása és “hard‑code”‑olása megnehezíti a későbbi módosítást. Ha megváltoztatja egy adott cella értékét, az attól függő összes cellának is frissülnie kell. Továbbá a táblázat adatai más táblázatok adataitól is függhetnek, ami összetett adatstruktúrát hoz létre a prezentációban, amelynek könnyen és rugalmasan kell frissülni.

**Diagram táblázat képlete** a prezentációban egy kifejezés, amely automatikusan kiszámítja és frissíti a diagram táblázat adatait. A táblázat képlete egy adott cella vagy cellacsoport számítási logikáját definiálja. A táblázat képlete egy matematikai vagy logikai képlet, amely cellahivatkozásokat, matematikai függvényeket, logikai és aritmetikai operátorokat, konverziós függvényeket, szövegállandókat stb. használ. A képlet definícióját egy cellába írja, és ez a cella nem egyszerű értéket tartalmaz. A táblázat képlet kiszámítja az értéket, visszaadja, majd ez az érték kerül a cellába. A diagram táblázat képletek a prezentációkban lényegében ugyanazok, mint az Excel képletek, és ugyanazokat az alapértelmezett függvényeket, operátorokat és állandókat támogatják.

Az [**Aspose.Slides**](https://products.aspose.com/slides/hu/python-net/) diagram táblázat a [**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/ichartdata/) tulajdonságon keresztül reprezentálható, amely a [**IChartDataWorkbook**](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/ichartdataworkbook/) típushoz tartozik. A táblázat képletet a [**formula**](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/ichartdatacell/) tulajdonsággal lehet hozzárendelni és módosítani. Az Aspose.Slides a következő funkcionalitást támogatja a képletekhez:

- Logikai állandók
- Numerikus állandók
- Szöveges állandók
- Hibaállandók
- Aritmetikai operátorok
- Összehasonlító operátorok
- A1‑stílusú cellahivatkozások
- R1C1‑stílusú cellahivatkozások
- Előre definiált függvények

Általában a táblázatok az utolsó számított képletértékeket tárolják. Ha a prezentáció betöltése után a diagram adatokat nem módosították, a **IChartDataCell.Value** tulajdonság ezeket az értékeket adja vissza olvasáskor. Ha a táblázat adatait módosították, az **ChartDataCell.Value** olvasásakor **CellUnsupportedDataException** kivételt dob a nem támogatott képletek miatt. Ez azért van, mert ha a képletek sikeresen értelmezésre kerülnek, a cellafüggőségek meghatározásra és az utolsó értékek helyessége ellenőrzésre kerül. Ha a képletet nem lehet értelmezni, a cellaérték helyessége nem garantálható.

## **Diagram táblázat képlet hozzáadása a prezentációhoz**
Először adjunk hozzá egy diagramot néhány mintaadattal az új prezentáció első diájához a [add_chart](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ishapecollection/) metódussal. A diagram munkalapja automatikusan létrejön, és a [**chart_data_workbook**](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/ichartdata/) tulajdonsággal érhető el:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 150, 150, 500, 300)
    workbook = chart.chart_data.chart_data_workbook
    # ...
```

Írjunk néhány értéket a cellákba a [**value**](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/ichartdatacell/) tulajdonsággal, amely **Object** típusú, vagyis bármilyen érték beállítható:

```py
    workbook.get_cell(0, "F2").value = -2.5
    workbook.get_cell(0, "G3").value = 6.3
    workbook.get_cell(0, "H4").value = 3
```

Most, hogy képletet írjunk a cellába, használjuk a [**formula**](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/ichartdatacell/) tulajdonságot:

```py
    workbook.get_cell(0, "B2").formula = "F2+G3+H4+1"
```

*Note*: [**IChartDataCell.Formula**](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/ichartdatacell/) tulajdonság A1‑stílusú cellahivatkozások beállítására szolgál.

Az [**r1c1_formula**](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/ichartdatacell/) cellahivatkozás beállításához használja az [**r1c1_formula**](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/ichartdatacell/) tulajdonságot:

```py
    workbook.get_cell(0, "C2").r1c1_formula = "R[1]C[4]/R[2]C[5]"
```

Ezután hívja meg a [**calculate_formulas**](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdataworkbook/) metódust, amely kiszámítja az összes képletet a munkafüzetben, és frissíti a megfelelő cellaértékeket:

```py
    workbook.calculate_formulas()
    print(workbook.get_cell(0, "B2").value) # 7.8
    print(workbook.get_cell(0, "C2").value) # 2.1
```

## **Logikai állandók**
Logikai állandókat, például a *FALSE* és a *TRUE* értékeket használhatja a cellaképletekben:

## **Numerikus állandók**
Számokat használhat közös vagy tudományos jelölésben a diagram táblázat képlet létrehozásához:

## **Szöveges állandók**
A szöveges (vagy literális) állandó egy konkrét érték, amelyet úgy használnak, ahogy van, és nem változik. Szöveges állandók lehetnek: dátumok, szövegek, számok stb.:

## **Hibaállandók**
Néha a képlet nem tudja kiszámítani az eredményt. Ilyenkor a hiba kód jelenik meg a cellában az érték helyett. Minden hibatípusnak saját kódja van:

- #DIV/0! – a képlet nullával osztani próbál.
- #GETTING_DATA – megjelenhet egy cellában, míg az értéke még számítás alatt áll.
- #N/A – hiányzó vagy nem elérhető információ. Okok lehetnek: a képletben használt cellák üresek, extra szóköz, elgépelt karakter stb.
- #NAME? – egy adott cella vagy más képlettárgy nem található a neve alapján.
- #NULL! – akkor fordulhat elő, ha a képletben hibás szintaxis van, például „(,)” vagy szóköz karakter kettőspont helyett.
- #NUM! – a képletben lévő szám érvénytelen, túl nagy vagy túl kicsi stb.
- #REF! – érvénytelen cellahivatkozás.
- #VALUE! – nem várt értéktípus. Például szöveges érték egy numerikus cellában.

## **Aritmetikai operátorok**
Az alábbi aritmetikai operátorok használhatók a diagram munkalap képleteiben:

|**Operátor**|**Jelentés**|**Példa**|
| :- | :- | :- |
|+ (plusz jel)|Összeadás vagy egyelőjű plusz|2 + 3|
|- (mínusz jel)|Kivonás vagy negáció|2 - 3<br>-3|
|* (csillag)|Szorzás|2 * 3|
|/ (perjel)|Osztás|2 / 3|
|% (százalék jel)|Százalék|30%|
|^ (karet)|Hatványozás|2 ^ 3|

*Note*: A kiértékelés sorrendjének módosításához zárójelezze a képlet elsőként számítandó részét.

## **Összehasonlító operátorok**
Az összehasonlító operátorokkal cellaértékeket hasonlíthat össze. Ha két értéket ezekkel az operátorokkal hasonlít össze, az eredmény logikai érték, enten *TRUE* vagy *FALSE*:

|**Operátor**|**Jelentés**|**Jelentés**|
| :- | :- | :- |
|= (egyenlőség jel)|Egyenlő|A2 = 3|
|<> (nem egyenlőség jel)|Nem egyenlő|A2 <> 3|
|> (nagyobb jel)|Nagyobb|A2 > 3|
|>= (nagyobb vagy egyenlő jel)|Nagyobb vagy egyenlő|A2 >= 3|
|< (kisebb jel)|Kisebb|A2 < 3|
|<= (kisebb vagy egyenlő jel)|Kisebb vagy egyenlő|A2 <= 3|

## **A1‑stílusú cellahivatkozások**
**A1‑stílusú cellahivatkozások** a munkalapokon használatosak, ahol az oszlop betűvel, a sor számmal van jelölve (pl. *A*, *1*). Az A1‑stílusú cellahivatkozások a következő módon használhatók:

|**Cellahivatkozás**|**Példa**|||
| :- | :- | :- | :- |
||Abszolút|Relatív|Vegyes|
|Cell|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Sor|$2:$2|2:2|-|
|Oszlop|$A:$A|A:A|-|
|Tartomány|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

Az alábbi példa bemutatja, hogyan használjon A1‑stílusú cellahivatkozást képletben:

## **R1C1‑stílusú cellahivatkozások**
**R1C1‑stílusú cellahivatkozások** a munkalapokon használatosak, ahol a sor és az oszlop is számmal van jelölve. Az R1C1‑stílusú cellahivatkozások a következő módon használhatók:

|**Cellahivatkozás**|**Példa**|||
| :- | :- | :- | :- |
||Abszolút|Relatív|Vegyes|
|Cell|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Sor|R2|R[2]|-|
|Oszlop|C3|C[3]|-|
|Tartomány|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

Az alábbi példa bemutatja, hogyan használjon A1‑stílusú cellahivatkozást képletben:

## **Előre definiált függvények**
Vannak előre definiált függvények, amelyek a képletekben használhatók a megvalósításuk egyszerűsítése érdekében. Ezek a függvények a leggyakrabban használt műveleteket vonják össze, például:

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (1900 dátumrendszer)
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

**Támogatottak-e külső Excel‑fájlok adatforrásként egy képletekkel rendelkező diagramhoz?**

Igen. Az Aspose.Slides támogatja a külső munkafüzeteket, mint [diagram adatforrása](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdatasourcetype/), amely lehetővé teszi, hogy egy XLSX‑ből származó képleteket használjon a prezentáción kívül.

**A diagram képletei hivatkozhatnak-e ugyanabban a munkafüzetben lévő lapokra lapnév szerint?**

Igen. A képletek a standard Excel hivatkozási modellnek megfelelően működnek, így más lapokra is hivatkozhat ugyanabban a munkafüzetben vagy egy külső munkafüzetben. Külső hivatkozások esetén adja meg az elérési utat és a munkafüzet nevét az Excel szintaxis szerint.