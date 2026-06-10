---
title: OLE kezelése prezentációkban PHP használatával
linktitle: OLE kezelése
type: docs
weight: 40
url: /hu/php-java/manage-ole/
keywords:
- OLE objektum
- Objektum hivatkozás és beágyazás
- OLE hozzáadása
- OLE beágyazása
- objektum hozzáadása
- objektum beágyazása
- fájl hozzáadása
- fájl beágyazása
- linkelt objektum
- linkelt fájl
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
description: "Optimalizálja az OLE objektumok kezelését PowerPoint és OpenDocument fájlokban az Aspose.Slides for PHP via Java segítségével. Ágyazzon be, frissítsen és exportáljon OLE tartalmat zökkenőmentesen."
---
## **Bevezetés**

{{% alert color="primary" %}} 

Az OLE (Object Linking & Embedding) egy Microsoft technológia, amely lehetővé teszi, hogy egy alkalmazásban létrehozott adatokat és objektumokat egy másik alkalmazásba helyezzék át hivatkozás vagy beágyazás révén. 

{{% /alert %}} 

Tekintsünk egy MS Excelben létrehozott diagramot. A diagramot ezután egy PowerPoint-diára helyezzük. Ez az Excel-diagram OLE objektumnak tekinthető. 

- Egy OLE objektum ikonként jelenhet meg. Ebben az esetben, ha duplán kattintunk az ikonra, a diagram a hozzá kapcsolódó alkalmazásban (Excel) nyílik meg, vagy felkérik a felhasználót, hogy válasszon alkalmazást az objektum megnyitásához vagy szerkesztéséhez. 
- Egy OLE objektum megjelenítheti a tényleges tartalmát, például egy diagram tartalmát. Ebben az esetben a diagram aktiválódik a PowerPointban, betöltődik a diagram felület, és a PowerPointon belül módosíthatja a diagram adatait. 

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/hu/php-java/) lehetővé teszi OLE objektumok beszúrását a diákba OLE objektumkeretként ([OleObjectFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/oleobjectframe/)).

## **OLE Objektumkeretek hozzáadása a diákhoz**

Tegyük fel, hogy már elkészítette a diagramot a Microsoft Excelben, és azt be szeretné ágyazni egy diára OLE objektumkeretként az Aspose.Slides for PHP via Java segítségével; ezt a következőképpen teheti meg:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.  
1. Kapjon referenciát a diára a megfelelő indexével.  
1. Olvassa be az Excel‑fájlt byte‑tömbként.  
1. Adja hozzá a [OleObjectFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/oleobjectframe/) keretet a diára, amely tartalmazza a byte‑tömböt és az OLE objektum egyéb információit.  
1. Írja ki a módosított prezentációt PPTX fájlként.  

Az alábbi példában egy Excel‑fájlból származó diagramot adtunk hozzá egy diára OLE objektumkeretként az Aspose.Slides for PHP via Java használatával.  
**Megjegyzés** hogy a [OleEmbeddedDataInfo](https://reference.aspose.com/slides/hu/php-java/aspose.slides/oleembeddeddatainfo/) konstruktor második paraméterként egy beágyazható objektum kiterjesztését várja. Ez a kiterjesztés lehetővé teszi a PowerPoint számára, hogy megfelelően értelmezze a fájltípust, és a megfelelő alkalmazást válassza az OLE objektum megnyitásához.  

```php
$presentation = new Presentation();
$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item(0);

// Prepare data for the OLE object.
$fileData = file_get_contents("book.xlsx");
$dataInfo = new OleEmbeddedDataInfo($fileData, "xlsx");

// Add the OLE object frame to the slide.
$slide->getShapes()->addOleObjectFrame(0, 0, $slideSize->getWidth(), $slideSize->getHeight(), $dataInfo);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

### **Linkelt OLE Objektumkeretek hozzáadása**

Az Aspose.Slides for PHP via Java lehetővé teszi egy [OleObjectFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/oleobjectframe/) hozzáadását adatbeágyazás nélkül, csak egy fájlra mutató hivatkozással.

Ez a PHP‑kód megmutatja, hogyan adjon egy [OleObjectFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/oleobjectframe/) keretet egy hivatkozott Excel‑fájllal a diára:  

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

// OLE objektumkeret hozzáadása linkelt Excel fájllal.
$slide->getShapes()->addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **OLE Objektumkeretek elérése**

Ha egy OLE objektum már be van ágyazva egy diára, ezt a módot követve könnyedén megtalálhatja vagy elérheti:  

1. Töltse be a prezentációt, amely tartalmazza a beágyazott OLE objektumot, egy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) példány létrehozásával.  
2. Szerezze meg a dia referenciáját az indexének használatával.  
3. Hozzáférés a [OleObjectFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/oleobjectframe/) alakzathoz. Példánkban a korábban létrehozott PPTX‑et használtuk, amelynek az első diáján csak egy alakzat van.  
4. Miután hozzáfért az OLE objektumkerethez, tetszőleges műveletet végrehajthat rajta.  

Az alábbi példában egy OLE objektumkeretet (egy Excel‑diagramot beágyazott objektumként) és annak fájladatát érjük el.  

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;
    
    // A beágyazott fájl adatainak lekérése.
    $fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

    // A beágyazott fájl kiterjesztésének lekérése.
    $fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();

    // ...
}
```

### **Linkelt OLE Objektumkeret tulajdonságainak elérése**

Az Aspose.Slides lehetővé teszi a linkelt OLE objektumkeret tulajdonságainak elérését.

Ez a PHP‑kód megmutatja, hogyan ellenőrizze, hogy egy OLE objektum linkelt‑e, majd hogyan szerezze meg a linked fájl elérési útját:  

```php
$presentation = new Presentation("sample.ppt");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    // Ellenőrizze, hogy az OLE objektum linkelt-e.
    if (java_values($oleFrame->isObjectLink()) != 0) {
        // Kiírja a linkelt fájl teljes útvonalát.
        echo "OLE object frame is linked to: " . $oleFrame->getLinkPathLong() . PHP_EOL;

        // Kiírja a linkelt fájl relatív útvonalát, ha létezik.
        // Csak a PPT prezentációk tartalmazhatják a relatív útvonalat.
        $relativePath = java_values($oleFrame->getLinkPathRelative());
        if (!is_null($relativePath) && $relativePath !== "") {
            echo "OLE object frame relative path: " . $oleFrame->getLinkPathRelative() . PHP_EOL;
        }
    }
}

$presentation->dispose();
```

## **OLE Objektum adatainak módosítása**

{{% alert color="primary" %}} 

Ebben a szakaszban az alábbi kódrészlet a [Aspose.Cells for PHP via Java](/cells/php-java/) használatát mutatja be. 

{{% /alert %}} 

Ha egy OLE objektum már be van ágyazva egy diára, ezt a módot követve könnyedén elérheti és módosíthatja az adatokat:  

1. Töltse be a prezentációt, amely tartalmazza a beágyazott OLE objektumot, egy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) példány létrehozásával.  
2. Szerezze meg a dia referenciáját az indexével.  
3. Hozzáférés a [OleObjectFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/oleobjectframe/) alakzathoz. Példánkban a korábban létrehozott PPTX‑et használtuk, amelynek az első diáján egy alakzat van.  
4. Miután hozzáfért az OLE objektumkerethez, tetszőleges műveletet végrehajthat rajta.  
5. Hozzon létre egy `Workbook` objektumot, és férjen hozzá az OLE‑adatokhoz.  
6. Nyissa meg a kívánt `Worksheet`‑et, és módosítsa az adatokat.  
7. Mentse el a frissített `Workbook`‑ot egy stream‑be.  
8. Cserélje ki az OLE objektum adatát a stream‑ből.  

Az alábbi példában egy OLE objektumkeretet (egy Excel‑diagramot beágyazott objektumként) érünk el, és módosítjuk a fájladatát a diagram adatainak frissítése érdekében.  

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    $oleStream = new ByteArrayInputStream($oleFrame->getEmbeddedData()->getEmbeddedFileData());

    // Az OLE objektum adatainak beolvasása Workbook objektumként.
    $workbook = new Workbook($oleStream);

    $newOleStream = new Java("java.io.ByteArrayOutputStream");

    // A munkafüzet adatok módosítása.
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

## **Más fájltípusok beágyazása a diákba**

Az Excel‑diagramok mellett az Aspose.Slides for PHP via Java lehetővé teszi más fájltípusok beágyazását is a diákba. Például HTML, PDF, illetve ZIP fájlokat is beszúrhat objektumként. Amikor a felhasználó duplán kattint a beszúrt objektumra, az automatikusan megnyílik a megfelelő programban, vagy felkérik, hogy válasszon egy megfelelő programot a megnyitáshoz.  

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

## **Beágyazott objektumok fájltípusának beállítása**

Prezentációk kezelése közben előfordulhat, hogy régi OLE objektumokat újakkal kell helyettesíteni, vagy egy nem támogatott OLE objektumot egy támogatottra cserélni. Az Aspose.Slides for PHP via Java lehetővé teszi a beágyazott objektum fájltípusának megadását, így frissítheti az OLE keret adatait vagy annak kiterjesztését.  

Ez a PHP‑kód megmutatja, hogyan állítsa be egy beágyazott OLE objektum fájltípusát `zip`‑re:  

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();
$fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

echo "Current embedded file extension is: " . $fileExtension . PHP_EOL;

// Change the file type to ZIP.
$oleFrame->setEmbeddedData(new OleEmbeddedDataInfo($fileData, "zip"));

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Ikon képek és címek beállítása a beágyazott objektumokhoz**

Az OLE objektum beágyazása után automatikusan hozzáadódik egy előnézet, amely egy ikon képből áll. Ez az előnézet jelenik meg a felhasználók számára, mielőtt hozzáférnének vagy megnyitnák az OLE objektumot. Ha konkrét képet és szöveget szeretne használni az előnézetben, akkor az Aspose.Slides for PHP via Java segítségével beállíthatja az ikon képet és a címet.  

Ez a PHP‑kód megmutatja, hogyan állítsa be az ikon képet és a címet egy beágyazott objektumhoz:  

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

// Kép hozzáadása a prezentáció erőforrásaihoz.
$imageData = file_get_contents("image.png");
$oleImage = $presentation->getImages()->addImage($imageData);

// Set a title and the image for the OLE preview.
$oleFrame->setSubstitutePictureTitle("My title");
$oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
$oleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Az OLE Objektumkeret átméretezésének és áthelyezésének megakadályozása**

Miután egy linkelt OLE objektumot hozzáadott a prezentáció egy diájához, a PowerPoint megnyitásakor megjelenhet egy üzenet, amely a hivatkozások frissítését kéri. Az „Update Links” (Hivatkozások frissítése) gombra kattintva a OLE objektumkeret mérete és pozíciója megváltozhat, mivel a PowerPoint a linked OLE objektumból származó adatokat frissíti, és az objektum előnézetét újrahajszolja. Ahhoz, hogy a PowerPoint ne kérje az objektum adatainak frissítését, állítsa a [OleObjectFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/oleobjectframe/) osztály `setUpdateAutomatic` metódusát `false`‑ra:  

```php
$oleFrame->setUpdateAutomatic(false);
```

## **Beágyazott fájlok kinyerése**

Az Aspose.Slides for PHP via Java lehetővé teszi a diákba beágyazott, OLE objektumként tárolt fájlok kinyerését a következő módon:  

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) példányt, amely tartalmazza a kinyerni kívánt OLE objektumokat.  
2. Járja be a prezentáció összes alakzatát, és férjen hozzá az [OLEObjectFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/oleobjectframe/) alakzatokhoz.  
3. Olvassa ki a beágyazott fájlok adatát az OLE objektumkeretekből, és írja ki a lemezre.  

Ez a PHP‑kód megmutatja, hogyan nyerjen ki fájlokat, amelyek OLE objektumként vannak beágyazva egy diára:  

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

**Megjelenik-e az OLE tartalom, amikor a diákat PDF‑re vagy képekre exportálják?**

A diáron látható elem (az ikon/helyettesítő kép, azaz az előnézet) kerül renderelésre. Az „élő” OLE tartalom nem kerül végrehajtásra a renderelés során. Szükség esetén állítson be saját előnézeti képet, hogy a várt megjelenés a PDF‑ben is biztosított legyen.  

**Hogyan zárhatok le egy OLE objektumot a dián, hogy a felhasználók ne mozgathassák vagy szerkeszthessék a PowerPointban?**

Zárja le az alakzatot: az Aspose.Slides alakzatszintű zárolási lehetőségeket biztosít. Ez nem titkosítás, de hatékonyan megakadályozza a véletlen szerkesztéseket és áthelyezéseket.  

**A linkelt OLE objektumok relatív útvonalai megmaradnak-e a PPTX formátumban?**

A PPTX formátumban a „relatív útvonal” információ nem érhető el – csak a teljes útvonal tárolódik. Relatív útvonalak a régebbi PPT formátumban találhatók. A hordozhatóság érdekében javasolt megbízható abszolút útvonalakat, elérhető URI‑kat vagy beágyazást használni.