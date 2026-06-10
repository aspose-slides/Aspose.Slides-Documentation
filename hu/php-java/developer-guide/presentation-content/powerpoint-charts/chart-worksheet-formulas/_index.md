---
title: Diagram munkalap képletek alkalmazása prezentációkban PHP használatával
linktitle: Munkalap képletek
type: docs
weight: 70
url: /hu/php-java/chart-worksheet-formulas/
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
- PHP
- Aspose.Slides
description: "Alkalmazzon Excel‑stílusú képleteket az Aspose.Slides for PHP‑ban Java diagram munkalapokon, és automatizálja a jelentéseket PPT és PPTX fájlokban."
---
## **Áttekintés**

A diagram munkalap a diagram mögötti adatforrás egy prezentációban. A kategória- és sorozatneveket tárolja a diagram által megjelenített numerikus értékekkel együtt. Az Aspose.Slides‑ben ez a munkalap a diagram adatkönyvtárán keresztül érhető el, amely lehetővé teszi a diagram adatok programozott kezelését.

Ez a cikk bemutatja, hogyan használhatók a munkalap képletek a diagram adataiban, így a cellaértékek automatikusan kiszámíthatók és frissíthetők a kézi bevitel helyett. Megmutatja, hogyan kell képleteket hozzárendelni, A1‑ és R1C1‑stílusú hivatkozásokat használni, újraszámolni a munkafüzet képleteit, valamint a diagram munkalapokban támogatott állandókat, operátorokat, cellahivatkozásokat és előre definiált függvényeket alkalmazni.

## **A diagram táblázat képleteiről a prezentációkban**
**Diagram táblázat** (vagy diagram munkalap) a diagram adatforrása. A diagram táblázat adatokat tartalmaz, amelyeket a diagram grafikus formában jelenít meg. Amikor diagramot hoz létre a PowerPointban, a diagramhoz tartozó munkalap automatikusan létrejön. Munkalap jön létre minden diagramtípushoz: vonaldiagram, oszlopdiagram, napfény diagram, kördiagram stb. A diagram táblázat megtekintéséhez a PowerPointban dupla‑kattintással nyissa meg a diagramot:

![todo:image_alt_text](chart-worksheet-formulas_1.png)


A diagram táblázat a diagram elemeinek neveit (Kategória neve: *Category1*, Sorozat neve) és egy táblázatot tartalmaz numerikus adatokkal, amelyek ezekhez a kategóriákhoz és sorozatokhoz tartoznak. Alapértelmezés szerint új diagram létrehozásakor a diagram táblázat adatai az alapértelmezett adatokkal kerülnek beállításra. Ezután a táblázat adatokat kézzel módosíthatja.

Általában a diagram bonyolult adatokat ábrázol (pl. pénzügyi elemzők, tudományos elemzők), ahol a cellák más cellák értékei vagy más dinamikus adatok alapján számítódnak. A cella értékének kézi kiszámítása és kódolása nehézzé teszi a jövőbeni módosítást. Ha egy adott cella értékét megváltoztatja, az onnan függő összes cellának is frissítve kell lennie. Emellett a táblázat adatai más táblázatok adataitól is függhetnek, egy összetett prezentációs adatstruktúrát hozva létre, amelyet könnyen és rugalmasan kell frissíteni.

**Diagram táblázat képlete** a prezentációban egy kifejezés, amely automatikusan kiszámítja és frissíti a diagram táblázat adatait. A képlet egy cella vagy cellacsoport számítási logikáját határozza meg. A képlet lehet matematikai vagy logikai, és használ: cellahivatkozásokat, matematikai függvényeket, logikai operátorokat, aritmetikai operátorokat, konverziós függvényeket, karakterlánc‑állandókat stb. A képlet definíciója egy cellába íródik, és ez a cella nem egyszerű értéket tartalmaz. A képlet kiszámítja az értéket, visszaadja, majd ez az érték kerül a cellába. A diagram táblázat képletek a prezentációkban valójában ugyanazok, mint az Excel‑képletek, és ugyanazok az alapértelmezett függvények, operátorok és állandók támogatottak.

Az [**Aspose.Slides**](https://products.aspose.com/slides/hu/php-java/) diagram táblázata a
[**ChartData::getChartDataWorkbook**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdata/#getChartDataWorkbook) metódussal van reprezentálva a
[**ChartDataWorkbook**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdataworkbook/) típuson.
A táblázat képletek hozzárendelhetők és módosíthatók a
[**ChartDataCell::setFormula**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatacell/#setFormula) metódussal.
Az Aspose.Slides a következő funkciókat támogatja a képletekhez:

- Logikai állandók
- Numerikus állandók
- Karakterlánc‑állandók
- Hiba‑állandók
- Aritmetikai operátorok
- Összehasonlító operátorok
- A1‑stílusú cellahivatkozások
- R1C1‑stílusú cellahivatkozások
- Előre definiált függvények


Általában a táblázatok a legutóbb kiszámított képletértékeket tárolják. Ha a prezentáció betöltése után a diagram adatai nem változtak, a [**ChartDataCell::getValue**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatacell/#getValue) metódus ezeket az értékeket adja vissza olvasáskor. Ha a táblázat adatait módosították, az olvasáskor a [**CellUnsupportedDataException**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/CellUnsupportedDataException) kivételt dobja a nem támogatott képletek miatt. Ennek oka, hogy a képletek sikeres elemzésekor a cellafüggőségek meghatározásra kerülnek, és a legutóbbi értékek helyessége ellenőrzésre kerül. Ha a képletet nem lehet elemezni, a cellaérték helyessége nem garantálható.

## **Diagram táblázat képlet hozzáadása a prezentációhoz**
Először adjon hozzá egy diagramot az új prezentáció első diájához a
[ShapeCollection::addChart](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/#addChart) metódussal.
A diagram munkalapja automatikusan létrejön, és a következővel érhető el:
[**ChartData::getChartDataWorkbook**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdata/#getChartDataWorkbook) metódussal:



```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 150, 150, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    # ...
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Írjunk néhány értéket cellákba a
[**ChartDataCell::setValue**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatacell/#setValue) metódussal a **Object** típusú objektumon, ami azt jelenti, hogy bármilyen értéket beállíthat:

```php
  $workbook->getCell(0, "F2")->setValue(-2.5);
  $workbook->getCell(0, "G3")->setValue(6.3);
  $workbook->getCell(0, "H4")->setValue(3);

```

Most, hogy képletet írjunk a cellába, használhatja a
[**ChartDataCell::setFormula**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatacell/#setFormula) metódust.

*Megjegyzés*: [**ChartDataCell::setFormula**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatacell/#setFormula) metódus A1‑stílusú cellahivatkozások beállítására szolgál. 

R1C1‑stílusú képlet beállításához használja a
[**ChartDataCell::setR1C1Formula**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatacell/#setR1C1Formula) metódust.

Ezután, ha a B2 és C2 cellák értékeit olvassa, azok számításra kerülnek:

```php
  $value1 = $cell1->getValue();// 7.8

  $value2 = $cell2->getValue();// 2.1


```

## **Logikai állandók**
Logikai állandókat, például a *FALSE* és *TRUE* értékeket használhatja a cellaképletekben:

```php
  $workbook->getCell(0, "A2")->setValue(false);
  $cell = $workbook->getCell(0, "B2");
  $cell->setFormula("A2 = TRUE");
  $value = $cell->getValue();// az érték bool típusú "false"-t tartalmaz
```

## **Numerikus állandók**
Számok használhatók közös vagy tudományos jelölésben a diagram táblázat képletének létrehozásához:

```php
  $workbook->getCell(0, "A2")->setFormula("1 + 0.5");
  $workbook->getCell(0, "B2")->setFormula(".3 * 1E-2");

```

## **Karakterlánc‑állandók**
A karakterlánc (vagy literál) állandó egy adott érték, amelyet változtatás nélkül használunk. Karakterlánc‑állandók lehetnek: dátumok, szövegek, számok stb.:

```php
  $workbook->getCell(0, "A2")->setFormula("\"abc\"");
  $workbook->getCell(0, "B2")->setFormula("\"2/3/2020 12:00\"");

```

## **Hiba‑állandók**
Előfordulhat, hogy a képlet nem tudja kiszámítani az eredményt. Ilyenkor a hibakód jelenik meg a cellában az érték helyett. Minden hibatípusnak saját kódja van:

- #DIV/0! – a képlet nullával próbál osztani.
- #GETTING_DATA – megjelenhet egy cellában, amíg az értéke még számítás alatt áll.
- #N/A – információ hiányzik vagy nem elérhető. Okok lehetnek: a képletben használt cellák üresek, extra szóköz karakter, elírás stb.
- #NAME? – egy adott cella vagy más képlettárgy nem található a neve alapján. 
- #NULL! – akkor jelenik meg, ha a képletben hiba van, például:  (,) vagy egy szóköz karakter a kettőspont helyett (:).
- #NUM! – a képletben szereplő szám érvénytelen, túl nagy vagy túl kicsi stb.
- #REF! – érvénytelen cellahivatkozás.
- #VALUE! – váratlan értéktípus. Például karakterlánc érték egy numerikus cellában.

```php
  $cell = $workbook->getCell(0, "A2");
  $cell->setFormula("2 / 0");
  $value = $cell->getValue();// az érték tartalmazza a "#DIV/0!" sztringet


```

## **Aritmetikai operátorok**
Az alábbi aritmetikai operátorok használhatók diagram munkalap képletekben:

|**Operátor**|**Jelentés**|**Példa**|
| :- | :- | :- |
|+ (pluszjel)|Összeadás vagy egyértelmű plusz|2 + 3|
|- (mínuszjel)|Kivonás vagy negáció|2 - 3<br>-3|
|* (csillag)|Szorzás|2 * 3|
|/ (perjel)|Osztás|2 / 3|
|% (százalékjel)|Százalék|30%|
|^ (karet)|Hatványozás|2 ^ 3|

*Megjegyzés*: Az értékelési sorrend módosításához zárójelek közé kell tenni a korábban számítandó részt.

## **Összehasonlító operátorok**
Összehasonlíthatja a cellák értékeit összehasonlító operátorokkal. Amikor két értéket összehasonlítanak ezekkel, az eredmény logikai érték, akár *TRUE* vagy FALSE:

|**Operátor**|**Jelentés**|**Jelentés**|
| :- | :- | :- |
|= (egyenlőjel)|Egyenlő|A2 = 3|
|<> (nem egyenlő jel)|Nem egyenlő|A2 <> 3|
|> (nagyobb mint jel)|Nagyobb mint|A2 > 3|
|>= (nagyobb vagy egyenlő jel)|Nagyobb vagy egyenlő|A2 >= 3|
|< (kisebb mint jel)|Kisebb mint|A2 < 3|
|<= (kisebb vagy egyenlő jel)|Kisebb vagy egyenlő|A2 <= 3|

## **A1‑stílusú cellahivatkozások**
**A1‑stílusú cellahivatkozásokat** a munkalapokon használják, ahol az oszlop betűazonosítóval (pl. "*A*") és a sor számmal (pl. "*1*") rendelkezik. Az A1‑stílusú cellahivatkozások a következő módon használhatók:

|**Cellahivatkozás**|**Példa**|||
| :- | :- | :- | :- |
||Abszolút|Relatív|Vegyes|
|Cell|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Sor|$2:$2|2:2|-|
|Oszlop|$A:$A|A:A|-|
|Tartomány|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


Példa az A1‑stílusú cellahivatkozás használatára képletben:

```php
  $workbook->getCell(0, "A2")->setFormula("C3 + SUM(F2:H5)");
```

## **R1C1‑stílusú cellahivatkozások**
**R1C1‑stílusú cellahivatkozásokat** a munkalapokon használják, ahol a sor és az oszlop egyaránt numerikus azonosítóval rendelkezik. Az R1C1‑stílusú cellahivatkozások a következő módon használhatók:

|**Cellahivatkozás**|**Példa**|||
| :- | :- | :- | :- |
||Abszolút|Relatív|Vegyes|
|Cell|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Sor|R2|R[2]|-|
|Oszlop|C3|C[3]|-|
|Tartomány|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


Példa az R1C1‑stílusú cellahivatkozás használatára képletben:

```php
  $workbook->getCell(0, "A2")->setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");

```

## **Előre definiált függvények**
Vannak előre definiált függvények, amelyeket a képletekben a megvalósítás egyszerűsítésére használhat. Ezek a függvények a leggyakrabban használt műveleteket foglalják magukba, például:

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

**Támogatottak-e külső Excel‑fájlok adatforrásként a képletekkel ellátott diagramokhoz?**

Igen. Az Aspose.Slides támogatja a külső munkafüzeteket **diagram adatforrásaként**(https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatasourcetype/), amely lehetővé teszi, hogy az XLSX‑ben lévő képleteket a prezentáción kívül használja.

**Hivatkozhatnak-e a diagram képletei ugyanabban a munkafüzetben lévő lapokra lapnév alapján?**

Igen. A képletek a szabványos Excel‑referencia modellnek megfelelően működnek, így hivatkozhat más lapokra ugyanabban a munkafüzetben vagy egy külső munkafüzetben. Külső hivatkozások esetén a útvonalat és a munkafüzet nevét kell megadni az Excel szintaxisával.