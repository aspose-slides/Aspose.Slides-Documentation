---
title: "OLE kezelése prezentációkban Java-val"
linktitle: "OLE kezelése"
type: docs
weight: 40
url: /hu/java/manage-ole/
keywords:
- "OLE objektum"
- "Objektum hivatkozás és beágyazás"
- "OLE hozzáadása"
- "OLE beágyazása"
- "objektum hozzáadása"
- "objektum beágyazása"
- "fájl hozzáadása"
- "fájl beágyazása"
- "kapcsolt objektum"
- "kapcsolt fájl"
- "OLE módosítása"
- "OLE ikon"
- "OLE cím"
- "OLE kinyerése"
- "objektum kinyerése"
- "fájl kinyerése"
- "PowerPoint"
- "prezentáció"
- "Java"
- "Aspose.Slides"
description: "Optimalizálja az OLE objektumkezelést PowerPoint és OpenDocument fájlokban az Aspose.Slides for Java segítségével. Beágyazza, frissíti és exportálja az OLE tartalmat zökkenőmentesen."
---
## **Bevezetés**

{{% alert color="primary" %}} 

Az OLE (Object Linking & Embedding) egy Microsoft technológia, amely lehetővé teszi, hogy egy alkalmazásban létrehozott adatokat és objektumokat egy másik alkalmazásban helyezzük el hivatkozás vagy beágyazás útján. 

{{% /alert %}} 

Tekintsd meg az MS Excelben létrehozott diagramot. A diagramot ezután egy PowerPoint diára helyezik. Ez az Excel-diagram OLE objektumnak számít. 

- Egy OLE objektum megjelenhet ikonként. Ebben az esetben, ha duplán kattintasz az ikonra, a diagram a kapcsolódó alkalmazásban (Excel) nyílik meg, vagy felkérnek egy alkalmazás kiválasztására az objektum megnyitásához vagy szerkesztéséhez. 
- Egy OLE objektum megjelenítheti a tényleges tartalmát, például egy diagram tartalmát. Ebben az esetben a diagram a PowerPointban aktiválódik, a diagram felület betöltődik, és a diagram adatainak módosítását a PowerPointon belül végezheted. 

[Aspose.Slides for Java](https://products.aspose.com/slides/hu/java/) lehetővé teszi OLE objektumok beillesztését a diákba OLE objektumkeretként ([OleObjectFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/OleObjectFrame)).

## **OLE objektumkeretek hozzáadása a diákhoz**

Tegyük fel, hogy már létrehoztál egy diagramot a Microsoft Excelben, és szeretnéd beágyazni azt a diára OLE objektumkeretként az Aspose.Slides for Java használatával, ezt a módot követheted:

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.  
1. Szerezd meg egy dia referenciaját az indexe alapján.  
1. Olvasd be az Excel-fájlt bájt tömbként.  
1. Adj hozzá egy [OleObjectFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/OleObjectFrame) objektumot a diához, amely tartalmazza a bájt tömböt és az OLE objektummal kapcsolatos egyéb információkat.  
1. Írd ki a módosított prezentációt PPTX fájlként.  

Az alábbi példában egy Excel-fájlból származó diagramot adtunk hozzá egy diához OLE objektumkeretként az Aspose.Slides for Java használatával. **Megjegyzés** hogy a [OleEmbeddedDataInfo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/OleEmbeddedDataInfo) konstruktor második paraméterként egy beágyazható objektumkiterjesztést vár. Ez a kiterjesztés lehetővé teszi a PowerPoint számára, hogy helyesen értelmezze a fájltípust és a megfelelő alkalmazást válassza az OLE objektum megnyitásához.

``` java 
Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Az OLE objektum adatainak előkészítése.
byte[] fileData = Files.readAllBytes(Paths.get("book.xlsx"));
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// OLE objektumkeret hozzáadása a diához.
slide.getShapes().addOleObjectFrame(0, 0, (float)slideSize.getWidth(), (float)slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Kapcsolt OLE objektumkeretek hozzáadása**

Az Aspose.Slides for Java lehetővé teszi, hogy egy [OleObjectFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/OleObjectFrame) objektumot adjunk hozzá adatbeágyazás nélkül, csak a fájlra mutató hivatkozással.

Ez a Java kód megmutatja, hogyan adhatunk egy [OleObjectFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/OleObjectFrame) objektumot kapcsolt Excel fájllal egy diára:

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// OLE objektumkeret hozzáadása egy kapcsolt Excel fájllal.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **OLE objektumkeretek elérése**

Ha egy OLE objektum már be van ágyazva egy diára, egyszerűen megtalálhatod vagy elérheted a következő módon:

1. Tölts be egy prezentációt, amely az beágyazott OLE objektumot tartalmaz, a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztály példányosításával.  
2. Szerezd meg a dia referenciáját az indexének használatával.  
3. Érd el az [OleObjectFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/OleObjectFrame) alakzatot. A példánkban a korábban létrehozott PPTX-et használtuk, amelynek az első dián csak egy alakzata van. Ezután *cast*-oltuk azt az objektumot egy [IOleObjectFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IOleObjectFrame) típusra. Ez lett a kívánt OLE objektumkeret, amelyet el kell érni.  
4. Miután az OLE objektumkeretet elérted, bármilyen műveletet végrehajthatsz rajta.  

Az alábbi példában egy OLE objektumkeretet (egy Excel-diagram objektumot, amely egy diára van beágyazva) és az annak a fájladatait érjük el.

``` java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // A beágyazott fájl adatait kapja meg.
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // A beágyazott fájl kiterjesztését kapja meg.
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **Kapcsolt OLE objektumkeret tulajdonságainak elérése**

Az Aspose.Slides lehetővé teszi a kapcsolt OLE objektumkeret tulajdonságainak elérését.

Ez a Java kód megmutatja, hogyan ellenőrizheted, hogy egy OLE objektum kapcsolt-e, és hogyan szerezheted meg a kapcsolt fájl elérési útját:

```java
Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // Ellenőrizze, hogy az OLE objektum kapcsolt-e.
    if (oleFrame.isObjectLink()) {
        // Kiírja a kapcsolt fájl teljes útvonalát.
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // Kiírja a kapcsolt fájl relatív útvonalát, ha van.
        // Csak a PPT prezentációk tartalmazhatják a relatív útvonalat.
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **OLE objektum adatának módosítása**

{{% alert color="primary" %}} 

Ebben a szakaszban az alábbi kódrészlet a [Aspose.Cells for Java](/cells/java/) használatát mutatja be.

{{% /alert %}}

Ha egy OLE objektum már be van ágyazva egy diára, egyszerűen elérheted azt az objektumot és módosíthatod az adatait a következő módon:

1. Tölts be egy prezentációt, amely beágyazott OLE objektumot tartalmaz, a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztály példányosításával.  
2. Szerezd meg a dia referenciáját az indexével.  
3. Érd el az OLE objektumkeret alakzatot. A példánkban a korábban létrehozott PPTX-et használtuk, amelynek az első dián egy alakzata van. Ezután *cast*-oltuk azt az objektumot egy [IOleObjectFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IOleObjectFrame) típusra. Ez lett a kívánt OLE objektumkeret, amelyet el kell érni.  
4. Miután az OLE objektumkeretet elérted, bármilyen műveletet végrehajthatsz rajta.  
5. Hozz létre egy `Workbook` objektumot és érj hozzá az OLE adatokhoz.  
6. Érd el a kívánt `Worksheet`-et és módosítsd az adatokat.  
7. Mentsd a frissített `Workbook`-ot egy stream-be.  
8. Változtasd meg az OLE objektum adatait a stream alapján.  

Az alábbi példában egy OLE objektumkeretet (egy Excel-diagram objektumot, amely egy diára van beágyazva) érünk el, és a fájladatait módosítjuk a diagram adatok frissítéséhez.

``` java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    ByteArrayInputStream oleStream = new ByteArrayInputStream(oleFrame.getEmbeddedData().getEmbeddedFileData());

    // Olvassa be az OLE objektum adatát Workbook objektumként.
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // Módosítsa a workbook adatokat.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
    workbook.save(newOleStream, fileOptions);

    // Módosítsa az OLE keret objektum adatait.
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Más fájltípusok beágyazása a diákba**

Az Excel-diagramok mellett az Aspose.Slides for Java lehetővé teszi más típusú fájlok beágyazását a diákba. Például HTML, PDF és ZIP fájlokat is beilleszthetsz objektumként. Amikor a felhasználó duplán kattint a beillesztett objektumra, az automatikusan megnyílik a megfelelő programban, vagy a felhasználót felszólítja a megfelelő program kiválasztására.

Ez a Java kód megmutatja, hogyan ágyazz be HTML-t és ZIP-et egy diára:

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

byte[] htmlData = Files.readAllBytes(Paths.get("sample.html"));
IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
IOleObjectFrame htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

byte[] zipData = Files.readAllBytes(Paths.get("sample.zip"));
IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
IOleObjectFrame zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Beágyazott objektumok fájltípusának beállítása**

Prezentációk kezelése során előfordulhat, hogy el kell cserélni a régi OLE objektumokat újakra, vagy egy nem támogatott OLE objektumot egy támogatottra. Az Aspose.Slides for Java lehetővé teszi, hogy beállítsd a beágyazott objektum fájltípusát, így frissítheted az OLE keret adatát vagy annak kiterjesztését.

Ez a Java kód megmutatja, hogyan állítható be a beágyazott OLE objektum fájltípusa `zip`-re:

```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

System.out.println("Current embedded file extension is: " + fileExtension);

// A fájltípus módosítása ZIP-re.
oleFrame.setEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Ikon képek és címek beállítása beágyazott objektumokhoz**

Az OLE objektum beágyazása után automatikusan hozzáadódik egy előnézet, amely egy ikon képből áll. Ez az előnézet az, amit a felhasználók látnak, mielőtt elérnék vagy megnyitnák az OLE objektumot. Ha egy adott képet és szöveget szeretnél használni az előnézet elemeiként, az ikon képet és a címet az Aspose.Slides for Java segítségével állíthatod be.

Ez a Java kód megmutatja, hogyan állítható be az ikon kép és a cím egy beágyazott objektumhoz:

```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// Kép hozzáadása a prezentáció erőforrásaihoz.
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage oleImage = presentation.getImages().addImage(imageData);

// Set a title and the image for the OLE preview.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Az OLE objektumkeret átméretezésének és áthelyezésének megakadályozása**

Miután egy kapcsolt OLE objektumot hozzáadtál egy prezentációs diához, a PowerPointban való megnyitáskor megjelenhet egy üzenet, amely a linkek frissítésére kér. Az "Update Links" gomb megnyomása módosíthatja az OLE objektumkeret méretét és pozícióját, mivel a PowerPoint frissíti a kapcsolt OLE objektum adatait és frissíti az objektum előnézetét. Ahhoz, hogy a PowerPoint ne kérje az objektum adatainak frissítését, állítsd a `setUpdateAutomatic` metódust a [IOleObjectFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ioleobjectframe/) interfészen `false` értékre:

```java
oleFrame.setUpdateAutomatic(false);
```

## **Beágyazott fájlok kinyerése**

Az Aspose.Slides for Java lehetővé teszi a diákba beágyazott fájlok OLE objektumokként történő kinyerését a következő módon:

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból, amely a kinyerni kívánt OLE objektumokat tartalmazza.  
2. Iterálj végig a prezentáció összes alakzatán és érj hozzá a [OLEObjectFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/oleobjectframe) alakzatokhoz.  
3. Érd el a beágyazott fájlok adatait az OLE objektumkeretekből és írd őket lemezre.  

Ez a Java kód megmutatja, hogyan nyerhetők ki a diára beágyazott fájlok OLE objektumként:

```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);

for (int index = 0; index < slide.getShapes().size(); index++) {
    IShape shape = slide.getShapes().get_Item(index);

    if (shape instanceof IOleObjectFrame) {
        IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

        byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        Path filePath = Paths.get("OLE_object_" + index + fileExtension);
        Files.write(filePath, fileData);
    }
}

presentation.dispose();
```

## **FAQ**

**Megjelenik-e az OLE tartalom a diák PDF/reprezentációkba történő exportálásakor?**

A dián látható elem kerül renderelésre – az ikon/helyettesítő kép (előnézet). Az „élő” OLE tartalom nem kerül végrehajtásra a renderelés során. Szükség esetén állíts be saját előnézeti képet, hogy a várt megjelenés biztosítva legyen az exportált PDF-ben.

**Hogyan zárolhatom egy OLE objektumot a dián, hogy a felhasználók ne mozgathassák/szerkeszthessék azt PowerPointban?**

Zárold le az alakzatot: az Aspose.Slides [alakzatszintű zárakat](/slides/hu/java/applying-protection-to-presentation/) kínál. Ez nem titkosítás, de hatékonyan megakadályozza a véletlen szerkesztéseket és áthelyezéseket.

**Miért „ugrik” vagy változik mérete a kapcsolt Excel objektum, amikor megnyitom a prezentációt?**

A PowerPoint frissítheti a kapcsolt OLE előnézetét. A stabil megjelenés érdekében kövesd a [Működő megoldást a munkalap átméretezéséhez](/slides/hu/java/working-solution-for-worksheet-resizing/) gyakorlatait – vagy illeszd a keretet a tartományhoz, vagy méretezd a tartományt egy rögzített keretre, és állíts be megfelelő helyettesítő képet.

**Megmaradnak-e a kapcsolt OLE objektumok relatív útvonalai a PPTX formátumban?**

A PPTX-ben a „relatív útvonal” információ nem érhető el – csak a teljes útvonal. A relatív útvonalak a régebbi PPT formátumban találhatók. A hordozhatóság érdekében részesítsd előnyben a megbízható abszolút útvonalakat/hozzáférhető URI‑kat vagy a beágyazást.