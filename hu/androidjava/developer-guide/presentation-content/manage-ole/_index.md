---
title: OLE kezelése prezentációkban Androidon
linktitle: OLE kezelése
type: docs
weight: 40
url: /hu/androidjava/manage-ole/
keywords:
- OLE objektum
- Objektum hivatkozás és beágyazás
- OLE hozzáadása
- OLE beágyazása
- objektum hozzáadása
- objektum beágyazása
- fájl hozzáadása
- fájl beágyazása
- csatolt objektum
- csatolt fájl
- OLE módosítása
- OLE ikon
- OLE címe
- OLE kinyerése
- objektum kinyerése
- fájl kinyerése
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Optimalizálja az OLE objektumkezelést PowerPoint és OpenDocument fájlokban az Aspose.Slides for Android via Java segítségével. Ágyazza be, frissítse és exportálja az OLE tartalmat zökkenőmentesen."
---
## **Bevezetés**

{{% alert color="primary" %}} 
OLE (Object Linking & Embedding) egy Microsoft technológia, amely lehetővé teszi, hogy egy alkalmazásban létrehozott adatokat és objektumokat egy másik alkalmazásba helyezzük hivatkozás vagy beágyazás révén. 
{{% /alert %}} 

Tekintsünk egy MS Excelben létrehozott diagramra. A diagramot ezután egy PowerPoint diaba helyezzük. Ez az Excel-diagram OLE objektumnak tekinthető. 

- Egy OLE objektum megjelenhet ikonként. Ebben az esetben, ha duplán kattint a ikonra, a diagram megnyílik a hozzá tartozó alkalmazásban (Excel), vagy felkérik egy alkalmazás kiválasztására az objektum megnyitásához vagy szerkesztéséhez. 
- Egy OLE objektum megjelenítheti a tényleges tartalmát, például egy diagram tartalmát. Ebben az esetben a diagram Aktiválódik a PowerPointban, a diagram felülete betöltődik, és módosíthatja a diagram adatait a PowerPointon belül. 

[**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/hu/androidjava/) lehetővé teszi OLE objektumok beszúrását a diákba OLE objektumkeretekként ([OleObjectFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/OleObjectFrame)).

## **OLE objektumkeretek hozzáadása a diákhoz**

Feltételezve, hogy már létrehozott egy diagramot a Microsoft Excelben, és azt OLE objektumkeretként szeretné beágyazni egy diára az Aspose.Slides for Android via Java használatával, ezt a következőképpen teheti:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.  
2. A diát az indexe alapján szerezze meg.  
3. Olvassa be az Excel-fájlt bájttömbként.  
4. Adja hozzá a [OleObjectFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/OleObjectFrame) elemet a diához, amely tartalmazza a bájttömböt és az OLE objektum egyéb adatait.  
5. Írja ki a módosított prezentációt PPTX fájlként.  

Az alábbi példában egy Excel-fájlból származó diagramot OLE objektumkeretként adtunk hozzá egy diához az Aspose.Slides for Android via Java használatával.  
**Megjegyzés**: a [OleEmbeddedDataInfo](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/OleEmbeddedDataInfo) konstruktor második paraméterként egy beágyazható objektum kiterjesztést fogad. Ez a kiterjesztés lehetővé teszi a PowerPoint számára, hogy helyesen értelmezze a fájltípust és a megfelelő alkalmazást választja az OLE objektum megnyitásához.  

```java 
Presentation presentation = new Presentation();
SizeF slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Az OLE objektum adatai előkészítése.
File file = new File("book.xlsx");
byte fileData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(fileData);

IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// OLE objektumkeret hozzáadása a diára.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Csatolt OLE objektumkeretek hozzáadása**

Az Aspose.Slides for Android via Java lehetővé teszi, hogy egy [OleObjectFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/OleObjectFrame) elemet csak a fájlra mutató hivatkozással adjon hozzá, anélkül hogy beágyazná az adatokat.  

Ez a Java-kód bemutatja, hogyan adhat hozzá egy [OleObjectFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/OleObjectFrame) elemet egy csatolt Excel fájllal egy diához:

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Olyan OLE objektumkeret hozzáadása, amely egy csatolt Excel fájlra mutat.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **OLE objektumkeretek elérése**

Ha egy OLE objektum már be van ágyazva egy diára, egyszerűen megtalálhatja vagy elérheti a következő módon:

1. Töltsön be egy prezentációt, amely tartalmazza a beágyazott OLE objektumot, a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztály példányosításával.  
2. Szerezze meg a dia referenciáját az indexe használatával.  
3. Hozza elérhet az [OleObjectFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/OleObjectFrame) alakzatot.  
   Példánkban a korábban létrehozott PPTX-et használtuk, amelynek az első dián csak egy alakzata van. Ezután *cast*-oltuk azt az objektumot egy [IOleObjectFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ioleobjectframe/) típusra. Ez volt a kívánt OLE objektumkeret, amelyet el kell érni.  
4. Miután hozzáfért az OLE objektumkerethez, bármilyen műveletet végrehajthat rajta.  

Az alábbi példában egy OLE objektumkeret (egy diára beágyazott Excel-diagram objektum) és annak fájladatai elérhetők.  

```java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // Szerezze meg a beágyazott fájl adatait.
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // Szerezze meg a beágyazott fájl kiterjesztését.
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **Csatolt OLE objektumkeret tulajdonságainak elérése**

Az Aspose.Slides lehetővé teszi a csatolt OLE objektumkeret tulajdonságainak elérését.  

Ez a Java-kód bemutatja, hogyan ellenőrizhető, hogy egy OLE objektum csatolt-e, majd hogyan szerezhető meg a csatolt fájl elérési útja:  

```java
Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // Ellenőrizze, hogy az OLE objektum linkelt-e.
    if (oleFrame.isObjectLink()) {
        // Kiírja a csatolt fájl teljes útvonalát.
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // Kiírja a csatolt fájl relatív útvonalát, ha létezik.
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
Ebben a részben az alábbi kódpélda a [Aspose.Cells for Android via Java](/cells/androidjava/) használatát mutatja be.  
{{% /alert %}} 

Ha egy OLE objektum már be van ágyazva egy diára, egyszerűen elérheti azt és módosíthatja az adatait a következőképpen:

1. Töltsön be egy prezentációt, amely tartalmazza a beágyazott OLE objektumot, a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztály példányosításával.  
2. A diát az indexe alapján szerezze meg.  
3. Hozza elérhet az OLE objektumkeret alakzatot.  
   Példánkban a korábban létrehozott PPTX-et használtuk, amelynek az első dián egy alakzata van. Ezután *cast*-oltuk azt az objektumot egy [IOleObjectFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ioleobjectframe/) típusra. Ez volt a kívánt OLE objektumkeret, amelyet el kell érni.  
4. Miután hozzáfért az OLE objektumkerethez, bármilyen műveletet végrehajthat rajta.  
5. Hozzon létre egy `Workbook` objektumot és érje el az OLE adatokat.  
6. Érje el a kívánt `Worksheet`-et és módosítsa az adatokat.  
7. Mentse a frissített `Workbook`-ot egy streambe.  
8. Módosítsa az OLE objektum adatait a streamből.  

Az alábbi példában egy OLE objektumkeret (egy diára beágyazott Excel-diagram objektum) elérhető, és a fájladatai módosítva lesznek a diagram adatainak frissítéséhez.  

```java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    ByteArrayInputStream oleStream = new ByteArrayInputStream(oleFrame.getEmbeddedData().getEmbeddedFileData());

    // Olvassa be az OLE objektum adatait Workbook objektumként.
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // Módosítsa a munkafüzet adatait.
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

## **Más fájltípusok beágyazása diákba**

Az Excel-diagramok mellett az Aspose.Slides for Android via Java lehetővé teszi más típusú fájlok diákba történő beágyazását is. Például beszúrhat HTML, PDF és ZIP fájlokat objektumként. Amikor a felhasználó duplán kattint a beszúrt objektumra, az automatikusan megnyílik a megfelelő programban, vagy a felhasználót arra kérik, hogy válasszon egy megfelelő programot a megnyitáshoz.  

Ez a Java-kód bemutatja, hogyan ágyazhat be HTML-t és ZIP-et egy diára:  

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

File fileHtml = new File("sample.html");
byte htmlData[] = new byte[(int) fileHtml.length()];
BufferedInputStream bisHtml = new BufferedInputStream(new FileInputStream(fileHtml));
DataInputStream disHtml = new DataInputStream(bisHtml);
disHtml.readFully(htmlData);
IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
IOleObjectFrame htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

File fileZip = new File("sample.zip");
byte zipData[] = new byte[(int) fileZip.length()];
BufferedInputStream bisZip = new BufferedInputStream(new FileInputStream(fileZip));
DataInputStream disZip = new DataInputStream(bisZip);
disZip.readFully(zipData);
IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
IOleObjectFrame zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Beágyazott objektumok fájltípusának beállítása**

Prezentációk kezelése során szükség lehet a régi OLE objektumok újakra történő cseréjére vagy egy nem támogatott OLE objektum helyettesítésére egy támogatottal. Az Aspose.Slides for Android via Java lehetővé teszi egy beágyazott objektum fájltípusának beállítását, így frissítheti az OLE keret adatait vagy kiterjesztését.  

Ez a Java-kód bemutatja, hogyan állítható be egy beágyazott OLE objektum fájltípusa `zip`-re:  

```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

System.out.println("Current embedded file extension is: " + fileExtension);

// A fájltípus megváltoztatása ZIP-re.
oleFrame.setEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Beágyazott objektumok ikonképének és címének beállítása**

Egy OLE objektum beágyazása után automatikusan egy előnézet, amely ikonképből áll, hozzáadódik. Ez az előnézet azt mutatja, amit a felhasználók látnak, mielőtt hozzáférnének vagy megnyitnák az OLE objektumot. Ha egy konkrét képet és szöveget szeretne használni az előnézet elemeiként, az ikonképet és a címet az Aspose.Slides for Android via Java segítségével állíthatja be.  

Ez a Java-kód bemutatja, hogyan állítható be az ikonkép és a cím egy beágyazott objektumhoz:  

```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// Kép hozzáadása a prezentáció erőforrásaihoz.
File file = new File("image.png");
byte imageData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(imageData);
IPPImage oleImage = presentation.getImages().addImage(imageData);

// Cím és kép beállítása az OLE előnézethez.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Az OLE objektumkeret átméretezésének és áthelyezésének megakadályozása**

Miután egy csatolt OLE objektumot ad hozzá egy prezentációs diára, a PowerPointban történő megnyitáskor megjelenhet egy üzenet, amely a hivatkozások frissítését kéri. Az „Update Links” (Hivatkozások frissítése) gomb megnyomása módosíthatja az OLE objektumkeret méretét és pozícióját, mert a PowerPoint frissíti a csatolt OLE objektum adatait és újratölti az objektum előnézetét. A PowerPoint arra való figyelmeztetésének elkerüléséhez, hogy frissítse az objektum adatait, állítsa a [IOleObjectFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ioleobjectframe/) interfész `setUpdateAutomatic` metódusát `false`-ra:  

```java
oleFrame.setUpdateAutomatic(false);
```

## **Beágyazott fájlok kinyerése**

Az Aspose.Slides for Android via Java lehetővé teszi a diákba beágyazott fájlok OLE objektumokként történő kinyerését a következő módon:

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályú példányt, amely tartalmazza a kinyerni kívánt OLE objektumokat.  
2. Iteráljon végig a prezentáció összes alakzatán, és érje el a [OLEObjectFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/oleobjectframe) alakzatokat.  
3. Érje el a beágyazott fájlok adatait az OLE objektumkeretekből, és írja őket lemezre.  

Ez a Java-kód bemutatja, hogyan nyerhetők ki a diára beágyazott fájlok OLE objektumokként:  

```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);

for (int index = 0; index < slide.getShapes().size(); index++) {
    IShape shape = slide.getShapes().get_Item(index);

    if (shape instanceof IOleObjectFrame) {
        IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

        byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        FileOutputStream fos = new FileOutputStream(new File("OLE_object_" + index + fileExtension));
        fos.write(fileData);
        fos.close();
    }
}

presentation.dispose();
```

## **GYIK**

**Megjelenik-e az OLE tartalom a diák PDF/képek exportálásakor?**  
A diákon látható elem kerül renderelésre – az ikon/helyettesítő kép (előnézet). Az „élő” OLE tartalom nem kerül végrehajtásra a renderelés során. Szükség esetén állítsa be a saját előnézeti képet, hogy a várt megjelenés biztosítva legyen az exportált PDF-ben.  

**Hogyan lehet egy OLE objektumot lezárni a dián, hogy a felhasználók ne mozgathassák vagy szerkeszthessék PowerPointban?**  
Zárja le az alakzatot: az Aspose.Slides alakzatszintű zárakat biztosít. Ez nem titkosítás, de hatékonyan megakadályozza a véletlen szerkesztéseket és áthelyezéseket.  

**Miért „ugrik” vagy változik mérete egy csatolt Excel objektumnak, amikor megnyitom a prezentációt?**  
A PowerPoint frissítheti a csatolt OLE előnézetét. Stabil megjelenés érdekében kövesse a [Worksheet Resizing működő megoldás](/slides/hu/androidjava/working-solution-for-worksheet-resizing/) gyakorlatokat – vagy igazítsa a keretet a tartományhoz, vagy méretezze a tartományt egy fix keretre, és állítson be megfelelő helyettesítő képet.  

**Megmaradnak-e a relatív útvonalak a csatolt OLE objektumok esetében a PPTX formátumban?**  
A PPTX-ben a „relatív útvonal” információ nem érhető el – csak a teljes útvonal. A relatív útvonalak a régebbi PPT formátumban szerepelnek. A hordozhatóság érdekében ajánlott megbízható abszolút útvonalakat / hozzáférhető URI-kat vagy beágyazást használni.