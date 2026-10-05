---
title: OLE kezelése prezentációkban PHP használatával
linktitle: OLE kezelése
type: docs
weight: 40
url: /hu/php-java/manage-ole/
keywords:
- OLE objektum
- Objektumkapcsolás és beágyazás
- OLE hozzáadása
- OLE beágyazása
- objektum hozzáadása
- objektum beágyazása
- fájl hozzáadása
- fájl beágyazása
- hivatkozott objektum
- hivatkozott fájl
- OLE módosítása
- OLE ikon
- OLE cím
- OLE kinyerése
- objektum kinyerése
- fájl kinyerése
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Optimalizálja az OLE objektumok kezelését PowerPoint és OpenDocument fájlokban az Aspose.Slides for PHP via Java segítségével. Beágyazás, frissítés és OLE tartalom exportálása zökkenőmentesen."
---
## **Bevezetés**

{{% alert color="info" title="Megjegyzés" %}}

Az OLE (Object Linking & Embedding) egy Microsoft technológia, amely lehetővé teszi, hogy egy alkalmazásban létrehozott adatokat és objektumokat egy másik alkalmazásba helyezzük el hivatkozás vagy beágyazás révén. 

{{% /alert %}} 

Tekintsünk egy MS Excelben létrehozott diagramot. A diagramot ezután egy PowerPoint diára helyezzük. Ez az Excel-diagram OLE objektumnak tekinthető. 

- Egy OLE objektum megjelenhet ikonként. Ebben az esetben, ha duplán kattintunk az ikonra, a diagram a hozzá kapcsolódó alkalmazásban (Excel) nyílik meg, vagy felkérik a felhasználót, hogy válasszon alkalmazást az objektum megnyitásához vagy szerkesztéséhez.
- Egy OLE objektum megjelenítheti a tényleges tartalmát, például egy diagram tartalmát. Ebben az esetben a diagram aktiválódik a PowerPointban, betöltődik a diagram felülete, és módosíthatja a diagram adatait a PowerPointon belül.

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/php-java/) lehetővé teszi OLE objektumok beszúrását a diákba OLE objektumkeretekként ([OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/)).

## **OLE Objektumkeretek Hozzáadása a Diákhoz**

Tegyük fel, hogy már létrehozott egy diagramot a Microsoft Excelben, és az Aspose.Slides for PHP via Java segítségével OLE objektumkeretként szeretné beágyazni egy diára. Ezt a következőképpen teheti meg:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) osztályból.
1. Szerezze meg a dia referencia‑ját az indexén keresztül.
1. Olvassa be az Excel‑fájlt bájt‑tömbként.
1. Adja hozzá az [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/)‑et a diához a bájt‑tömbbel és az OLE objektum egyéb adataival.
1. Írja ki a módosított prezentációt PPTX fájlként.

Az alábbi példában egy Excel‑fájlból származó diagramot adtunk hozzá a diához OLE objektumkeretként az Aspose.Slides for PHP via Java használatával.
**Megjegyzés**: az [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/) konstruktor a beágyazható objektum kiterjesztését második paraméterként fogadja. Ez a kiterjesztés lehetővé teszi a PowerPoint számára, hogy helyesen értelmezze a fájltípust, és a megfelelő alkalmazást válassza az OLE objektum megnyitásához.

```php
$presentation = new Presentation();
$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item(0);

// Az OLE objektum adatainak előkészítése.
$fileData = file_get_contents("book.xlsx");
$dataInfo = new OleEmbeddedDataInfo($fileData, "xlsx");

// OLE objektumkeret hozzáadása a diára.
$slide->getShapes()->addOleObjectFrame(0, 0, $slideSize->getWidth(), $slideSize->getHeight(), $dataInfo);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

### **Hivatkozott OLE Objektumkeretek Hozzáadása**

Az Aspose.Slides for PHP via Java lehetővé teszi, hogy egy [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/)‑et adat‑beágyazás nélkül, csak egy fájlra mutató hivatkozással adjon hozzá.

Ez a PHP‑kód megmutatja, hogyan lehet egy [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/)‑et egy hivatkozott Excel‑fájllal hozzáadni egy diához:

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

// OLE objektumkeret hozzáadása egy hivatkozott Excel fájllal.
$slide->getShapes()->addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **OLE Objektumkeretek Elérése**

Ha egy OLE objektum már be van ágyazva egy diára, egyszerűen megtalálhatja vagy elérheti a következő módon:

1. Töltsön be egy prezentációt, amely a beágyazott OLE objektumot tartalmazza, úgy, hogy létrehozza a [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) osztály egy példányát.
2. Szerezze meg a dia referencia‑ját az indexével.
3. Hozzáférés az [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) alakzatához. A példánkban a korábban létrehozott PPTX‑et használtuk, amelynek az első dián egyetlen alakzata van.
4. Miután az OLE objektumkeret elérhető, bármilyen műveletet végrehajthat rajta.

Az alábbi példában egy OLE objektumkeretet (egy beágyazott Excel‑diagramot) és annak fájladatait érjük el.

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;
    
    // A beágyazott fájl adatai lekérése.
    $fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

    // A beágyazott fájl kiterjesztésének lekérése.
    $fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();

    // ...
}
```

### **Hivatkozott OLE Objektumkeret Tulajdonságainak Elérése**

Az Aspose.Slides lehetővé teszi, hogy hivatkozott OLE objektumkeret tulajdonságait elérje.

Ez a PHP‑kód megmutatja, hogyan ellenőrizze, hogy egy OLE objektum hivatkozott‑e, majd hogyan szerezze meg a hivatkozott fájl elérési útját:

```php
$presentation = new Presentation("sample.ppt");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    // Ellenőrizze, hogy az OLE objektum hivatkozott-e.
    if (java_values($oleFrame->isObjectLink()) != 0) {
        // Írja ki a hivatkozott fájl teljes elérési útját.
        echo "OLE object frame is linked to: " . $oleFrame->getLinkPathLong() . PHP_EOL;

        // Írja ki a hivatkozott fájl relatív útvonalát, ha van.
        // Csak a PPT-prezentációk tartalmazhatják a relatív útvonalat.
        $relativePath = java_values($oleFrame->getLinkPathRelative());
        if (!is_null($relativePath) && $relativePath !== "") {
            echo "OLE object frame relative path: " . $oleFrame->getLinkPathRelative() . PHP_EOL;
        }
    }
}

$presentation->dispose();
```

## **OLE Objektum Adatainak Módosítása**

{{% alert color="info" title="Megjegyzés" %}}

Ebben a szakaszban az alábbi kódpélda a [Aspose.Cells for PHP via Java](https://docs.aspose.com/cells/php-java/)‑t használja.

{{% /alert %}}

Ha egy OLE objektum már be van ágyazva egy diára, egyszerűen elérheti azt, és módosíthatja az adatait a következő módon:

1. Töltsön be egy prezentációt, amely a beágyazott OLE objektumot tartalmazza, úgy, hogy létrehozza a [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) osztály egy példányát.
2. Szerezze meg a dia referencia‑ját az indexével. 
3. Hozzáférés az [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) alakzatához. A példánkban a korábban létrehozott PPTX‑et használtuk, amelynek az első dián egyetlen alakzata van.
4. Miután az OLE objektumkeret elérhető, bármilyen műveletet végrehajthat rajta.
5. Hozzon létre egy `Workbook` objektumot, és érje el az OLE adatokat.
6. Hozzáférés a kívánt `Worksheet`‑hez, és módosítsa az adatokat.
7. Mentse a frissített `Workbook`‑ot egy áramlamba.
8. Az OLE objektum adatait cserélje ki az áramlamból.

Az alábbi példában egy OLE objektumkeretet (egy beágyazott Excel‑diagramot) érünk el, és a fájladatait módosítjuk a diagramadatok frissítése érdekében.

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    $oleStream = new Java("java.io.ByteArrayInputStream", $oleFrame->getEmbeddedData()->getEmbeddedFileData());

    // Olvassa be az OLE objektum adatát Workbook objektumként.
    $workbook = new Workbook($oleStream);

    $newOleStream = new Java("java.io.ByteArrayOutputStream");

    // Módosítsa a munkafüzet adatait.
    $workbook->getWorksheets()->get(0)->getCells()->get(0, 4)->putValue("E");
    $workbook->getWorksheets()->get(0)->getCells()->get(1, 4)->putValue(12);
    $workbook->getWorksheets()->get(0)->getCells()->get(2, 4)->putValue(14);
    $workbook->getWorksheets()->get(0)->getCells()->get(3, 4)->putValue(15);

    $fileOptions = new OoxmlSaveOptions(SaveFormat::XLSX);
    $workbook->save($newOleStream, $fileOptions);

    // Az OLE keret objektum adatainak módosítása.
    $newData = new OleEmbeddedDataInfo($newOleStream->toByteArray(), $oleFrame->getEmbeddedData()->getEmbeddedFileExtension());
    $oleFrame->setEmbeddedData($newData);

    $newOleStream->close();
    $oleStream->close();
}

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Egyéb Fájltípusok Beágyazása a Diákba**

Az Excel‑diagramokon kívül az Aspose.Slides for PHP via Java lehetővé teszi más fájltípusok beágyazását a diákba is. Például HTML, PDF és ZIP fájlokat szúrhat be objektumként. Amikor a felhasználó duplán kattint a beszúrt objektumra, az automatikusan megnyílik a megfelelő programban, vagy a felhasználót felkéri, hogy válasszon egy alkalmas programot a megnyitáshoz.

Ez a PHP‑kód megmutatja, hogyan ágyazzon be HTML‑t és ZIP‑et egy diára:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);

$htmlData = file_get_contents("sample.html");
$htmlDataInfo = new OleEmbeddedDataInfo($htmlData, "html");
$htmlOleFrame = $slide->getShapes()->addOleObjectFrame(150, 120, 50, 50, $htmlDataInfo);
$htmlOleFrame->setObjectIcon(true);

$zipData = file_get_contents("sample.zip");
$zipDataInfo = new OleEmbeddedDataInfo($zipData, "zip");
$zipOleFrame = $slide->getShapes()->addOleObjectFrame(150, 220, 50, 50, $zipDataInfo);
$zipOleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Beágyazott Objektumok Fájltípusának Beállítása**

Prezentációk kezelésekor előfordulhat, hogy régi OLE objektumokat újakkal kell helyettesíteni, vagy egy nem támogatott OLE objektumot támogatottal. Az Aspose.Slides for PHP via Java lehetővé teszi, hogy beállítsa a beágyazott objektum fájltípusát, így frissítheti az OLE keret adatait vagy annak kiterjesztését.

Ez a PHP‑kód megmutatja, hogyan állíthatja a beágyazott OLE objektum fájltípusát `zip`‑re:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();
$fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

echo "Current embedded file extension is: " . $fileExtension . PHP_EOL;

// A fájltípus módosítása ZIP-re.
$oleFrame->setEmbeddedData(new OleEmbeddedDataInfo($fileData, "zip"));

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Ikonképek és Címek Beállítása a Beágyazott Objektumokhoz**

Miután beágyazott egy OLE objektumot, automatikusan hozzáadódik egy előnézet, amely ikonképből áll. Ez az előnézet látható a felhasználók számára, mielőtt elérnék vagy megnyitnák az OLE objektumot. Ha egy adott képet és szöveget szeretne használni az előnézet elemeiként, beállíthatja az ikonképét és a címet az Aspose.Slides for PHP via Java‑val.

Ez a PHP‑kód megmutatja, hogyan állíthatja be az ikonképét és a címét egy beágyazott objektumhoz:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

// Képet ad a prezentáció erőforrásaihoz.
$imageData = file_get_contents("image.png");
$oleImage = $presentation->getImages()->addImage($imageData);

// Címet és képet állít be az OLE előnézethez.
$oleFrame->setSubstitutePictureTitle("My title");
$oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
$oleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Az OLE Objektumkeret Átméretezésének és Áthelyezésének Megakadályozása**

Miután egy hivatkozott OLE objektumot hozzáadott egy prezentációs diához, a PowerPoint megnyitásakor előfordulhat, hogy egy üzenet jelenik meg a linkek frissítésének kérésével. A „Linkek frissítése” gombra kattintva az OLE objektumkeret mérete és pozíciója megváltozhat, mert a PowerPoint a hivatkozott OLE objektum adatait frissíti és az előnézetet újrarendereli. Az objektum adatainak frissítésére való felszólítás elkerüléséhez hívja meg az [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) osztály [setUpdateAutomatic](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) metódusát `false`‑val:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$oleFrame->setUpdateAutomatic(false);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Beágyazott Fájlok Kinyerése**

Az Aspose.Slides for PHP via Java lehetővé teszi, hogy a diákban OLE objektumként beágyazott fájlokat a következőképpen nyerje ki:

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) példányt, amely a kinyerni kívánt OLE objektumokat tartalmazza.
2. Járja be a prezentáció összes alakzatát, és érje el az [OLEObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) alakzatokat.
3. Hozzáférés a beágyazott fájlok adataihoz az OLE objektumkeretekből, és írja őket lemezre.

Ez a PHP‑kód megmutatja, hogyan nyerjen ki egy dián beágyazott fájlokat OLE objektumként:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);

$shapeCount = java_values($slide->getShapes()->size());
for ($index = 0; $index < $shapeCount; $index++) {
    $shape = $slide->getShapes()->get_Item($index);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
        $oleFrame = $shape;

        $fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();
        $fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();

        $filePath = "OLE_object_" . $index . $fileExtension;
        file_put_contents($filePath, $fileData);
    }
}

$presentation->dispose();
```

## **GYIK**

**Megjelenik‑e az OLE tartalom a diák PDF‑re/képre exportálásakor?**

A dián látható tartalom kerül renderelésre – az ikon/helyettesítő kép (előnézet). Az „élő” OLE tartalom nem kerül végrehajtásra a renderelés során. Szükség esetén állítson be saját előnézeti képet, hogy a várt megjelenés jelenjen meg az exportált PDF‑ben.

Az beágyazott fájl PDF‑csatolmányként történő megőrzéséhez hívja meg a [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setIncludeOleData) metódust `true`‑val. Ez a beállítás alapértelmezés szerint le van tiltva. Példáért és az csatolmány ellenőrzésének leírásáért lásd a [Preserve Embedded OLE Files as PDF Attachments](/slides/hu/php-java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments) cikket.

**Hogyan lehet zárolni egy OLE objektumot a dián, hogy a felhasználók ne mozgathassák/szerkeszthessék PowerPointban?**

Zárolja az alakzatot: az Aspose.Slides alakzatszintű zárolásokat biztosít. Ez nem titkosítás, de hatékonyan megakadályozza a véletlen szerkesztéseket és áthelyezéseket.

**Megmaradnak‑e a hivatkozott OLE objektumok relatív útvonalai PPTX formátumban?**

A PPTX‑ben a „relatív útvonal” információ nem áll rendelkezésre – csak a teljes útvonal. A relatív útvonalak a régebbi PPT formátumban szerepelnek. A hordozhatóság érdekében inkább megbízható abszolút útvonalakat vagy elérhető URI‑kat használjon, vagy ágyazza be a fájlokat.