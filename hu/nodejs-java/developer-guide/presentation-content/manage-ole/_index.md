---
title: OLE kezelése prezentációkban JavaScript segítségével
linktitle: OLE kezelése
type: docs
weight: 40
url: /hu/nodejs-java/manage-ole/
keywords:
- OLE objektum
- Objektum összekapcsolás és beágyazás
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
description: "Optimalizálja az OLE objektumok kezelését PowerPoint és OpenDocument fájlokban az Aspose.Slides for Node.js via Java segítségével. Az OLE tartalmak beágyazása, frissítése és exportálása zökkenőmentesen."
---
## **Bevezetés**

{{% alert color="primary" %}} 

Az OLE (Object Linking & Embedding) egy Microsoft technológia, amely lehetővé teszi, hogy egy alkalmazásban létrehozott adatokat és objektumokat egy másik alkalmazásban linkeléssel vagy beágyazással helyezzünk el. 

{{% /alert %}} 

Tekintsünk egy az MS Excelben létrehozott diagramot. A diagramot ezután egy PowerPoint‑diára helyezzük. Ez az Excel‑diagram OLE objektumnak tekinthető. 

- Egy OLE objektum ikonként jelenhet meg. Ebben az esetben, ha duplán kattintunk az ikonra, a diagram a kapcsolódó alkalmazásban (Excel) nyílik meg, vagy a felhasználó felkeresi a megnyitáshoz vagy szerkesztéshez megfelelő alkalmazást. 
- Egy OLE objektum megjelenítheti tényleges tartalmát, például egy diagram adatait. Ebben az esetben a diagram aktiválódik a PowerPointben, a diagram felülete betöltődik, és a diagram adatait közvetlenül a PowerPointen belül módosíthatjuk.

[Aspose.Slides Node.js-hez Java-n keresztül](https://products.aspose.com/slides/hu/nodejs-java/) lehetővé teszi OLE objektumok beillesztését a diákba OLE objektumkeretként ([OleObjectFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/OleObjectFrame)).

## **OLE objektumkeretek hozzáadása a diákhoz**

Tegyük fel, hogy már létrehozott egy diagramot a Microsoft Excelben, és azt OLE objektumkeretként szeretné beágyazni egy diára az Aspose.Slides Node.js-hez Java-n keresztül, ezt a módot követve:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.  
1. Szerezze meg a dia hivatkozását az indexe alapján.  
1. Olvassa be az Excel‑fájlt bájt‑tömbként.  
1. Adja hozzá az [OleObjectFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/OleObjectFrame) keretet a diához, amely a bájt‑tömböt és az OLE objektum egyéb adatait tartalmazza.  
1. Írja ki a módosított prezentációt PPTX fájlként.  

Az alábbi példában egy Excel‑fájlból származó diagramot adtunk hozzá a diához OLE objektumkeretként az Aspose.Slides Node.js-hez Java-n keresztül.  
**Megjegyzés** hogy az [OleEmbeddedDataInfo](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/OleEmbeddedDataInfo) konstruktor második paraméterként egy beágyazható objektum kiterjesztést vár. Ez a kiterjesztés lehetővé teszi a PowerPoint számára, hogy helyesen értelmezze a fájltípust, és a megfelelő alkalmazást válassza az OLE objektum megnyitásához.

```javascript
var presentation = new asposeSlides.Presentation();
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(0);

// Készítse elő az OLE objektum adatait.
var oleStream = fs.readFileSync("book.xlsx");
var fileData = Array.from(oleStream);
var dataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", fileData), "xlsx");

// Adja hozzá az OLE objektumkeretet a diához.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

### **Linkelt OLE objektumkeretek hozzáadása**

Az Aspose.Slides Node.js-hez Java-n keresztül lehetővé teszi egy [OleObjectFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/OleObjectFrame) hozzáadását anélkül, hogy az adatot beágyazná, csak a fájlra mutató hivatkozással.

Az alábbi JavaScript‑kód bemutatja, hogyan adhat hozzá egy [OleObjectFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/OleObjectFrame) keretet egy linkelt Excel‑fájllal a diára:

```javascript
var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

// OLE objektumkeret hozzáadása egy linkelt Excel-fájllal.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **OLE objektumkeretek elérése**

Ha egy OLE objektum már be van ágyazva egy diára, egyszerűen megtalálhatja vagy elérheti a következő módon:

1. Töltsön be egy prezentációt, amely tartalmazza a beágyazott OLE objektumot, a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztály példányosításával.  
2. Szerezze meg a dia hivatkozását az indexe alapján.  
3. Érje el az [OleObjectFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/OleObjectFrame) alakzatot. Példánkban az előzőleg létrehozott PPTX‑et használtuk, amelyen az első dián csak egy alakzat van.  
4. Miután elérte az OLE objektumkeretet, tetszőleges műveletet végrehajthat rajta.  

Az alábbi példában egy OLE objektumkeretet (egy diára beágyazott Excel‑diagramot) és annak fájladatait érjük el.

```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;
    
    // Szerezze meg a beágyazott fájl adatait.
    // Szerezze meg a beágyazott fájl kiterjesztését.
    // ...
}
```

### **Linkelt OLE objektumkeret tulajdonságainak elérése**

Az Aspose.Slides lehetővé teszi a linkelt OLE objektumkeret tulajdonságainak elérését.

Az alábbi JavaScript‑kód megmutatja, hogyan ellenőrizhető, hogy egy OLE objektum linkelt-e, és hogyan kérhető le a linkelt fájl elérési útja:

```javascript
var presentation = new asposeSlides.Presentation("sample.ppt");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    // Ellenőrizze, hogy az OLE objektum linkelt-e.
    if (oleFrame.isObjectLink()) {
        // Írja ki a linkelt fájl teljes útvonalát.
        console.log("OLE object frame is linked to:", oleFrame.getLinkPathLong());

        // Írja ki a linkelt fájl relatív útvonalát, ha létezik.
        // Csak a PPT prezentációk tartalmazhatják a relatív útvonalat.
        if (oleFrame.getLinkPathRelative() != null && oleFrame.getLinkPathRelative() != "") {
            console.log("OLE object frame relative path:", oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **OLE objektum adatainak módosítása**

{{% alert color="primary" %}} 

Ebben a részben az alábbi kódpélda a [Aspose.Cells for Java](/cells/java/) használatát mutatja be. 

{{% /alert %}}

Ha egy OLE objektum már be van ágyazva egy diára, egyszerűen elérheti azt, és a következő lépésekkel módosíthatja az adatokat:

1. Töltsön be egy prezentációt, amely tartalmazza a beágyazott OLE objektumot, a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztály példányosításával.  
2. Szerezze meg a dia hivatkozását az indexe alapján.  
3. Érje el az OLE objektumkeret alakzatot. Példánkban az előzőleg létrehozott PPTX‑et használtuk, amelyen az első dián egy alakzat van.  
4. Miután elérte az OLE objektumkeretet, tetszőleges műveletet végrehajthat rajta.  
5. Hozzon létre egy `Workbook` példányt, és érje el az OLE adatokat.  
6. Nyissa meg a kívánt `Worksheet`‑et, és módosítsa az adatokat.  
7. Mentse a frissített `Workbook`‑ot egy áramlatba.  
8. Cserélje ki az OLE objektum adatait az áramlatból.  

Az alábbi példában egy OLE objektumkeretet (egy diára beágyazott Excel‑diagramot) érünk el, és módosítjuk a fájladatait, hogy a diagram adatai frissüljenek.

```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    var oleStream = java.newInstanceSync("java.io.ByteArrayInputStream", oleFrame.getEmbeddedData().getEmbeddedFileData());

    // Olvassa be az OLE objektum adatát Workbook objektumként.
    var workbook = java.newInstanceSync("Workbook", oleStream);

    var newOleStream = java.newInstanceSync("java.io.ByteArrayOutputStream");

    // Módosítsa a munkafüzet adatait.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    var fileOptions = java.newInstanceSync("OoxmlSaveOptions", java.getStaticFieldValue("com.aspose.cells.SaveFormat", "XLSX"));
    workbook.save(newOleStream, fileOptions);

    // Módosítsa az OLE keret objektum adatait.
    var newData = new asposeSlides.OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);

    newOleStream.close();
    oleStream.close();
}

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Más fájltípusok beágyazása a diákba**

Az Excel‑diagramokon túl az Aspose.Slides Node.js-hez Java-n keresztül lehetővé teszi más fájltípusok beágyazását is. Például HTML, PDF és ZIP fájlokat szúrhat be objektumként. Amikor a felhasználó duplán kattint a beillesztett objektumra, az automatikusan megnyílik a megfelelő programban, vagy a felhasználó felkeresi a megfelelő programot a megnyitáshoz.

Az alábbi JavaScript‑kód bemutatja, hogyan ágyazhat be HTML‑t és ZIP‑et egy diára:

```javascript
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

Prezentációk kezelésekor előfordulhat, hogy régi OLE objektumokat újakkal kell helyettesíteni, vagy egy nem támogatott OLE objektumot támogatottal kell cserélni. Az Aspose.Slides Node.js-hez Java-n keresztül beállíthatja a beágyazott objektum fájltípusát, így frissítheti az OLE keret adatait vagy annak kiterjesztését.

Az alábbi JavaScript‑kód megmutatja, hogyan állítható be a beágyazott OLE objektum fájltípusa `zip`‑re:

```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
var oleFileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

console.log("Current embedded file extension is:", fileExtension);

// Change the file type to ZIP.
var fileData = java.newArray("byte", Array.from(oleFileData));
oleFrame.setEmbeddedData(new asposeSlides.OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Ikonképek és címek beállítása beágyazott objektumokhoz**

Egy OLE objektum beágyazása után automatikusan hozzáadódik egy előnézet, amely egy ikonképet tartalmaz. Ez az előnézet jelenik meg a felhasználók számára, mielőtt elérnék vagy megnyitnák az OLE objektumot. Ha egy konkrét képet és szöveget szeretne használni az előnézetben, akkor beállíthatja az ikonképet és a címet az Aspose.Slides Node.js-hez Java-n keresztül.

Az alábbi JavaScript‑kód megmutatja, hogyan állítható be az ikonkép és a cím egy beágyazott objektumhoz:

```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

// Kép hozzáadása a prezentáció erőforrásaihoz.
var image = asposeSlides.Images.fromFile("image.png");
var oleImage = presentation.getImages().addImage(image);
image.dispose();

// Állítson be címet és képet az OLE előnézethez.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Az OLE objektumkeret átméretezésének és áthelyezésének megakadályozása**

Miután egy linkelt OLE objektumot hozzáadott egy prezentációs diahoz, a PowerPoint megnyitásakor megjelenhet egy üzenet, amely a hivatkozások frissítését kéri. Az „Update Links” gombra kattintva a PowerPoint frissíti a linkelt OLE objektum adatait, ami a keret méretének és pozíciójának változását eredményezheti. Annak érdekében, hogy a PowerPoint ne kérje az objektum adatainak frissítését, használja az [OleObjectFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/oleobjectframe/) osztály `setUpdateAutomatic` metódusát `false` értékkel:

```javascript
oleFrame.setUpdateAutomatic(false);
```

## **Beágyazott fájlok kinyerése**

Az Aspose.Slides Node.js-hez Java-n keresztül a következő módon nyerheti ki a diákba beágyazott OLE objektumként tárolt fájlokat:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból, amely a kinyerni kívánt OLE objektumokat tartalmazza.  
2. Iteráljon végig a prezentáció összes alakzatán, és érje el az [OleObjectFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/oleobjectframe) alakzatokat.  
3. Olvassa ki a beágyazott fájlok adatait az OLE objektumkeretekből, és írja őket lemezre.  

Az alábbi JavaScript‑kód megmutatja, hogyan nyerhet ki fájlokat, amelyeket egy dia OLE objektumként tartalmaz:

```javascript
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

## **GYIK**

**Megjelenik-e az OLE tartalom, ha a diákat PDF‑re/képre exportáljuk?**

A dián látható elemek (az ikon vagy helyettesítő kép) kerülnek renderelésre. A „valódi” OLE tartalom nem fut le a renderelés során. Szükség esetén állítson be saját előnézeti képet, hogy a várt megjelenés megjelenjen az exportált PDF‑ben.

**Hogyan lehet zárolni egy OLE objektumot a dián, hogy a felhasználók ne mozgassák vagy szerkesszék PowerPointban?**

Zárolja az alakzatot: az Aspose.Slides alakzatszintű zárolásokat biztosít. Ez nem titkosítás, de hatékonyan megakadályozza a véletlen szerkesztéseket és áthelyezéseket.

**Megmaradnak-e a relatív elérési utak a linkelt OLE objektumoknál a PPTX formátumban?**

A PPTX‑ben nincs „relatív útvonal” információ – csak a teljes útvonal tárolódik. A relatív utak a régebbi PPT formátumban találhatók. Az áthelyezhetőség érdekében részesítsen előnyben megbízható abszolút útvonalakat vagy elérhető URI‑kat, vagy használja a beágyazást.