---
title: OLE kezelése prezentációkban JavaScript segítségével
linktitle: OLE kezelése
type: docs
weight: 40
url: /hu/nodejs-java/manage-ole/
keywords:
- OLE objektum
- Objektumok összekapcsolása és beágyazása
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Optimalizálja az OLE objektumkezelést PowerPoint és OpenDocument fájlokban az Aspose.Slides for Node.js via Java segítségével. Beágyazza, frissítse és exportálja az OLE tartalmat zökkenőmentesen."
---
## **Bevezetés**

{{% alert color="info" title="Note" %}}

Az OLE (Object Linking & Embedding) egy Microsoft technológia, amely lehetővé teszi, hogy egy alkalmazásban létrehozott adatokat és objektumokat egy másik alkalmazásba helyezzük hivatkozás vagy beágyazás segítségével. 

{{% /alert %}} 

Tekintsünk egy MS Excel-ben létrehozott diagramra. A diagramot ezután egy PowerPoint diára helyezzük. Ez az Excel-diagram OLE objektumnak tekinthető. 

- Egy OLE objektum megjelenhet ikonként. Ebben az esetben, ha duplán kattint az ikonra, a diagram megnyílik a kapcsolódó alkalmazásban (Excel), vagy felkérik, hogy válasszon egy alkalmazást az objektum megnyitásához vagy szerkesztéséhez.
- Egy OLE objektum megjelenítheti a tényleges tartalmát, például egy diagram tartalmát. Ebben az esetben a diagram aktiválódik a PowerPointban, a diagram felülete betöltődik, és módosíthatja a diagram adatait a PowerPointon belül.

Az [Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/nodejs-java/) lehetővé teszi, hogy OLE objektumokat szúrjon be diákba OLE objektumkeretként ([OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame)).

## **OLE objektumkeretek hozzáadása a diákhoz**

Feltételezve, hogy már létrehozott egy diagramot a Microsoft Excelben, és be szeretné ágyazni azt egy diára OLE objektumkeretként az Aspose.Slides for Node.js via Java használatával, ezt a módot követheti:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) osztályból.
1. Szerezze meg a diára hivatkozást az indexe alapján.
1. Olvassa be az Excel-fájlt bájt tömbként.
1. Adja hozzá az [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) elemet a diára, amely tartalmazza a bájt tömböt és egyéb információkat az OLE objektumról.
1. Írja a módosított prezentációt PPTX fájlként.

Az alábbi példában egy Excel-fájlból származó diagramot adtunk hozzá a diához OLE objektumkeretként az Aspose.Slides for Node.js via Java használatával. **Megjegyzés**, hogy az [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleEmbeddedDataInfo) konstruktor második paraméterként egy beágyazható objektum kiterjesztést vár. Ez a kiterjesztés lehetővé teszi, hogy a PowerPoint helyesen értelmezze a fájltípust és a megfelelő alkalmazást válassza az OLE objektum megnyitásához.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

var presentation = new asposeSlides.Presentation();
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(0);

// Prepare data for the OLE object.
var oleStream = fs.readFileSync("book.xlsx");
var fileData = Array.from(oleStream);
var dataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", fileData), "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

### **Linkelt OLE objektumkeretek hozzáadása**

Az Aspose.Slides for Node.js via Java lehetővé teszi, hogy egy [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) elemet adjon hozzá adat beágyazása nélkül, csak a fájlra mutató hivatkozással.

Ez a JavaScript kód megmutatja, hogyan adjon egy [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) elemet egy linkelt Excel fájllal a diához:

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

// OLE objektumkeret hozzáadása egy linkelt Excel fájlhoz.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **OLE objektumkeretek elérése**

Ha egy OLE objektum már be van ágyazva egy diára, egyszerűen megtalálhatja vagy elérheti a következő módon:

1. Töltsön be egy prezentációt a beágyazott OLE objektummal, úgy, hogy létrehoz egy példányt a [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) osztályból.
2. Szerezze meg a dia hivatkozását az indexének használatával.
3. Érje el az [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) alakzatot. A példánkban a korábban létrehozott PPTX-et használtuk, amelynek az első dián csak egy alakzata van.
4. Miután az OLE objektumkeret elérhető, bármilyen műveletet végrehajthat rajta.

Az alábbi példában egy OLE objektumkeret (egy diára beágyazott Excel diagram) és a hozzá tartozó fájladatok elérhetők.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;
    
    // A beágyazott fájl adatainak lekérése.
    var fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // A beágyazott fájl kiterjesztésének lekérése.
    var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **Linkelt OLE objektumkeret tulajdonságainak elérése**

Az Aspose.Slides lehetővé teszi a linkelt OLE objektumkeret tulajdonságainak elérését.

Ez a JavaScript kód megmutatja, hogyan ellenőrizze, hogy egy OLE objektum linkelt-e, és hogyan szerezze meg a linkelt fájl útvonalát:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.ppt");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    // Ellenőrizze, hogy az OLE objektum linkelt-e.
    if (oleFrame.isObjectLink()) {
        // Kiírja a linkelt fájl teljes útvonalát.
        console.log("OLE object frame is linked to:", oleFrame.getLinkPathLong());

        // Kiírja a linkelt fájl relatív útvonalát, ha létezik.
        // Csak a PPT prezentációk tartalmazhatják a relatív útvonalat.
        if (oleFrame.getLinkPathRelative() != null && oleFrame.getLinkPathRelative() != "") {
            console.log("OLE object frame relative path:", oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **OLE objektum adatainak módosítása**

{{% alert color="info" title="Note" %}}

Ebben a szakaszban az alábbi kódrészlet a [Aspose.Cells for Java](https://docs.aspose.com/cells/java/) használatát mutatja be.

{{% /alert %}}

Ha egy OLE objektum már be van ágyazva egy diára, egyszerűen elérheti az objektumot és módosíthatja az adatait a következő módon:

1. Töltsön be egy prezentációt a beágyazott OLE objektummal, úgy, hogy létrehoz egy példányt a [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) osztályból.
2. Szerezze meg a dia hivatkozását az indexe alapján. 
3. Érje el az OLE objektumkeret alakzatát. A példánkban a korábban létrehozott PPTX-et használtuk, amelynek az első dián egy alakzata van.
4. Miután az OLE objektumkeret elérhető, bármilyen műveletet végrehajthat rajta.
5. Hozzon létre egy `Workbook` objektumot és érje el az OLE adatot.
6. Érje el a kívánt `Worksheet`-et és módosítsa az adatot.
7. Mentse a frissített `Workbook`-ot egy adatfolyamba.
8. Módosítsa az OLE objektum adatát az adatfolyamból.

Az alábbi példában egy OLE objektumkeret (egy diára beágyazott Excel diagram) érhető el, és a fájladatai módosulnak a diagram adatainak frissítése érdekében.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    var embeddedData = Array.from(oleFrame.getEmbeddedData().getEmbeddedFileData());
    var oleStream = java.newInstanceSync("java.io.ByteArrayInputStream", java.newArray("byte", embeddedData));

    // Olvassa be az OLE objektum adatát Workbook objektumként.
    var workbook = java.newInstanceSync("com.aspose.cells.Workbook", oleStream);

    var newOleStream = java.newInstanceSync("java.io.ByteArrayOutputStream");

    // Módosítsa a workbook adatokat.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    var fileOptions = java.newInstanceSync("com.aspose.cells.OoxmlSaveOptions", java.getStaticFieldValue("com.aspose.cells.SaveFormat", "XLSX"));
    workbook.save(newOleStream, fileOptions);

    // Az OLE keret objektum adatainak módosítása.
    var newFileData = java.newArray("byte", Array.from(newOleStream.toByteArray()));
    var newData = new asposeSlides.OleEmbeddedDataInfo(newFileData, oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);

    newOleStream.close();
    oleStream.close();
}

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Más fájltípusok beágyazása diákba**

Az Excel diagramokon kívül az Aspose.Slides for Node.js via Java lehetővé teszi más típusú fájlok diákba ágyazását is. Például HTML, PDF és ZIP fájlokat szúrhat be objektumként. Amikor egy felhasználó duplán kattint a beszúrt objektumra, az automatikusan megnyílik a megfelelő programban, vagy a felhasználót felkérik, hogy válasszon egy megfelelő programot a megnyitáshoz.

Ez a JavaScript kód megmutatja, hogyan ágyazzon be HTML-t és ZIP-et egy diára:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

var htmlBuffer = fs.readFileSync("sample.html");
var htmlData = Array.from(htmlBuffer);
var htmlDataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", htmlData), "html");
var htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

var zipBuffer = fs.readFileSync("sample.zip");
var zipData = Array.from(zipBuffer);
var zipDataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", zipData), "zip");
var zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Beágyazott objektumok fájltípusának beállítása**

Prezentációk szerkesztésekor előfordulhat, hogy régi OLE objektumokat újakkal kell helyettesíteni, vagy egy nem támogatott OLE objektumot egy támogatottal. Az Aspose.Slides for Node.js via Java lehetővé teszi egy beágyazott objektum fájltípusának beállítását, így frissítheti az OLE keret adatát vagy kiterjesztését.

Ez a JavaScript kód megmutatja, hogyan állíthatja be egy beágyazott OLE objektum fájltípusát `zip`-re:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
var oleFileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

console.log("Current embedded file extension is:", fileExtension);

// A fájltípus módosítása ZIP-re.
var fileData = java.newArray("byte", Array.from(oleFileData));
oleFrame.setEmbeddedData(new asposeSlides.OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Ikonképek és címek beállítása beágyazott objektumokhoz**

Egy OLE objektum beágyazása után egy előnézet jelenik meg automatikusan, amely egy ikonképből áll. Ez az előnézet az, amit a felhasználók látnak az OLE objektum elérése vagy megnyitása előtt. Ha egy adott képet és szöveget szeretne használni az előnézet elemeként, beállíthatja az ikonképet és a címet az Aspose.Slides for Node.js via Java segítségével.

Ez a JavaScript kód megmutatja, hogyan állíthatja be az ikonképet és a címet egy beágyazott objektumhoz:

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

// Kép hozzáadása a prezentáció erőforrásaihoz.
var image = asposeSlides.Images.fromFile("image.png");
var oleImage = presentation.getImages().addImage(image);
image.dispose();

// Set a title and the image for the OLE preview.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Megakadályozza, hogy egy OLE objektumkeret méreteződjön vagy áthelyeződjön**

Miután egy linkelt OLE objektumot hozzáad egy prezentációs diához, a PowerPointban történő megnyitáskor megjelenhet egy üzenet, amely arra kéri, hogy frissítse a hivatkozásokat. Az „Update Links” (Hivatkozások frissítése) gombra kattintás módosíthatja az OLE objektumkeret méretét és pozícióját, mivel a PowerPoint frissíti az adatokat a linkelt OLE objektumból, és frissíti az objektum előnézetét. Annak elkerülése érdekében, hogy a PowerPoint felkérje a objektum adatainak frissítésére, hívja meg a [setUpdateAutomatic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) metódust az [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/) osztályon `false` argumentummal:

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

oleFrame.setUpdateAutomatic(false);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Beágyazott fájlok kinyerése**

Az Aspose.Slides for Node.js via Java lehetővé teszi, hogy a diákba beágyazott fájlokat OLE objektumokként a következő módon nyerje ki:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) osztályból, amely tartalmazza azokat az OLE objektumokat, amelyeket ki szeretne nyerni.
2. Iteráljon végig a prezentáció összes alakzataján, és érje el a [OLEObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe) alakzatokat.
3. Érje el a beágyazott fájlok adatait az OLE objektumkeretekből, és írja őket lemezre.

Ez a JavaScript kód megmutatja, hogyan nyerjen ki egy dián beágyazott fájlokat OLE objektumként:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);

for (var index = 0; index < slide.getShapes().size(); index++) {
    var shape = slide.getShapes().get_Item(index);

    if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
        var oleFrame = shape;

        var fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        var filePath = "OLE_object_" + index + fileExtension;
        fs.writeFileSync(filePath, Buffer.from(fileData));
    }
}

presentation.dispose();
```

## **FAQ**

**A OLE tartalom renderelődik a diák PDF/képek formátumba exportálásakor?**

A dián látható tartalom kerül renderelésre – az ikon/helyettesítő kép (előnézet). Az „élő” OLE tartalmat nem hajtja végre a renderelés során. Szükség esetén állítson be saját előnézeti képet, hogy a várt megjelenést biztosítsa az exportált PDF-ben.  
A beágyazott fájl PDF mellékletként való megőrzéséhez hívja meg a [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/#setIncludeOleData) metódust `true` értékkel. Ez az opció alapértelmezésben le van tiltva. Példáért és az ellenőrzés módjáért lásd a [Preserve Embedded OLE Files as PDF Attachments](/slides/hu/nodejs-java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments) oldalt.

**Hogyan zárhatok le egy OLE objektumot a dián, hogy a felhasználók ne mozgathassák/szerkeszthessék PowerPointban?**

Zárja le az alakzatot: az Aspose.Slides alakzatszintű zárolásokat biztosít. Ez nem titkosítás, de hatékonyan megakadályozza a véletlen szerkesztéseket és mozgatást.

**Megmaradnak a linkelt OLE objektumok relatív útvonalai a PPTX formátumban?**

A PPTX-ben a „relatív útvonal” információ nem érhető el – csak a teljes útvonal. A relatív útvonalak a régebbi PPT formátumban találhatók. A hordozhatóság érdekében részesítse előnyben a megbízható abszolút útvonalakat/elérhető URI-kat vagy a beágyazást.