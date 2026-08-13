---
title: OLE kezelése prezentációkban Java használatával
linktitle: OLE kezelése
type: docs
weight: 40
url: /hu/java/manage-ole/
keywords:
- OLE objektum
- Objektum összekapcsolás és beágyazás
- OLE hozzáadása
- OLE beágyazása
- objektum hozzáadása
- objektum beágyazása
- fájl hozzáadása
- fájl beágyazása
- kapcsolt objektum
- kapcsolt fájl
- OLE módosítása
- OLE ikon
- OLE cím
- OLE kinyerése
- objektum kinyerése
- fájl kinyerése
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Optimalizálja az OLE objektumok kezelését PowerPoint és OpenDocument fájlokban az Aspose.Slides for Java segítségével. Beágyazza, frissítse és exportálja az OLE tartalmat zökkenőmentesen."
---
## **Bevezetés**

{{% alert color="info" %}} 

OLE (Object Linking & Embedding) egy Microsoft technológia, amely lehetővé teszi, hogy egy alkalmazásban létrehozott adatokat és objektumokat egy másik alkalmazásba helyezzük át hivatkozás vagy beágyazás útján. 

{{% /alert %}} 

Tekintsünk egy MS Excel-ben létrehozott diagramra. A diagramot ezután egy PowerPoint diára helyezzük. Ez az Excel diagram OLE objektumnak tekinthető. 

- Egy OLE objektum megjelenhet ikonként. Ebben az esetben, ha duplán kattint az ikonra, a diagram a hozzárendelt alkalmazásban (Excel) nyílik meg, vagy felkérik, hogy válasszon egy alkalmazást az objektum megnyitásához vagy szerkesztéséhez. 
- Egy OLE objektum megjelenítheti tényleges tartalmát, például egy diagram tartalmát. Ebben az esetben a diagram aktiválódik a PowerPointban, a diagram felület betöltődik, és a diagram adatait a PowerPointon belül módosíthatja. 

[Aspose.Slides for Java](https://products.aspose.com/slides/hu/java/) lehetővé teszi OLE objektumok beillesztését a diákba OLE objektumkeretekként ([OleObjectFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/OleObjectFrame)).

## **OLE objektumkeretek hozzáadása a diákhoz**

Tegyük fel, hogy már létrehozott egy diagramot a Microsoft Excelben, és azt OLE objektumkeretként szeretné beágyazni egy diára az Aspose.Slides for Java segítségével, ezt a módot követheti:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.  
1. Szerezze meg egy dia referenciáját index alapján.  
1. Olvassa be az Excel fájlt bájttömbként.  
1. Adja hozzá az [OleObjectFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/OleObjectFrame) keretet a diához a bájttömbbel és az OLE objektum egyéb információival.  
1. Írja ki a módosított prezentációt PPTX fájlként.  

Az alábbi példában egy Excel fájlból származó diagramot adtunk hozzá egy diához OLE objektumkeretként az Aspose.Slides for Java használatával.  
**Megjegyzés** hogy az [OleEmbeddedDataInfo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/OleEmbeddedDataInfo) konstruktor második paraméterként egy beágyazható objektum kiterjesztést vár. Ez a kiterjesztés lehetővé teszi a PowerPoint számára, hogy helyesen értelmezze a fájltípust, és a megfelelő alkalmazást válassza az OLE objektum megnyitásához.

``` java 
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Prepare data for the OLE object.
byte[] fileData = Files.readAllBytes(Paths.get("book.xlsx"));
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, (float)slideSize.getWidth(), (float)slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Kapcsolt OLE objektumkeretek hozzáadása**

Az Aspose.Slides for Java lehetővé teszi egy [OleObjectFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/OleObjectFrame) hozzáadását adat beágyazása nélkül, csak a fájlra mutató hivatkozással.

Ez a Java kód bemutatja, hogyan adhat hozzá egy [OleObjectFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/OleObjectFrame) keretet egy kapcsolt Excel fájllal egy diára:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// OLE objektumkeret hozzáadása egy kapcsolt Excel fájllal.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **OLE objektumkeretek elérése**

Ha egy OLE objektum már be van ágyazva egy diára, egyszerűen megtalálhatja vagy elérheti a következő módon:

1. Töltsön be egy prezentációt a beágyazott OLE objektummal a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztály példányosításával.  
2. Szerezze meg a dia referenciáját annak indexe alapján.  
3. Hozzáférés az [OleObjectFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/OleObjectFrame) alakzathoz.  
   A példánkban az előzőleg létrehozott PPTX‑et használtuk, amely az első diához egyetlen alakzatot tartalmaz. Ezután *cast*‑oltuk azt az objektumot [IOleObjectFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IOleObjectFrame) típusra. Ez lett a kívánt OLE objektumkeret, amelyhez hozzáfértünk.  
4. Miután elérte az OLE objektumkeretet, tetszőleges műveletet végezhet rajta.  

Az alábbi példában egy OLE objektumkeretet (egy beágyazott Excel diagramot) és annak fájladatait érjük el.

``` java 
import com.aspose.slides.*;

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

### **Kapcsolt OLE objektumkeret tulajdonságainak elérése**

Az Aspose.Slides lehetővé teszi a kapcsolt OLE objektumkeret tulajdonságainak elérését.

Ez a Java kód bemutatja, hogyan ellenőrizheti, hogy egy OLE objektum kapcsolt‑e, és hogyan szerezheti meg a kapcsolt fájl elérési útját:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // Ellenőrizze, hogy az OLE objektum kapcsolt-e.
    if (oleFrame.isObjectLink()) {
        // Írja ki a kapcsolt fájl teljes elérési útját.
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // Írja ki a kapcsolt fájl relatív útvonalát, ha van.
        // Csak a PPT prezentációk tartalmazhatják a relatív útvonalat.
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **OLE objektum adatának módosítása**

{{% alert color="info" %}} 

Ebben a szakaszban az alábbi kódrészlet az [Aspose.Cells for Java](/cells/java/)‑t használja. 

{{% /alert %}}

Ha egy OLE objektum már be van ágyazva egy diára, egyszerűen elérheti azt, és a következő módon módosíthatja az adatait:

1. Töltsön be egy prezentációt a beágyazott OLE objektummal a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztály példányosításával.  
2. Szerezze meg a dia referenciáját index alapján.  
3. Hozzáférés az OLE objektumkeret alakzathoz.  
   Példánkban az előzőleg létrehozott PPTX‑et használtuk, amely az első diához egyetlen alakzatot tartalmaz. Ezután *cast*‑oltuk azt az objektumot [IOleObjectFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IOleObjectFrame) típusra. Ez lett a kívánt OLE objektumkeret, amelyhez hozzáfértünk.  
4. Miután elérte az OLE objektumkeretet, tetszőleges műveletet végezhet rajta.  
5. Hozzon létre egy `Workbook` objektumot, és férjen hozzá az OLE adatokhoz.  
6. Hozzáférés a kívánt `Worksheet`‑hez, és módosítsa az adatokat.  
7. Mentse a frissített `Workbook`‑ot egy adatfolyamban.  
8. Módosítsa az OLE objektum adatait az adatfolyamból.  

Az alábbi példában egy OLE objektumkeretet (egy beágyazott Excel diagramot) érünk el, és a fájladatait módosítjuk a diagram adatainak frissítése érdekében.

``` java 
import com.aspose.slides.*;
import com.aspose.cells.Workbook;
import com.aspose.cells.OoxmlSaveOptions;
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;

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

## **Más fájltípusok beágyazása a diákba**

Az Excel diagramok mellett az Aspose.Slides for Java lehetővé teszi más fájltípusok beágyazását a diákba. Például beilleszthet HTML, PDF és ZIP fájlokat objektumként. Amikor a felhasználó duplán kattint a beillesztett objektumra, az automatikusan megnyílik a megfelelő programban, vagy a felhasználót felkérik, hogy válasszon egy megfelelő programot a megnyitáshoz.

Ez a Java kód bemutatja, hogyan ágyazzunk be HTML‑t és ZIP‑et egy diára:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

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

## **Beágyazott objektumok fájltípusainak beállítása**

Prezentációk kezelése során előfordulhat, hogy régi OLE objektumokat újakkal kell helyettesíteni, vagy egy nem támogatott OLE objektumot támogatottra cserélni. Az Aspose.Slides for Java lehetővé teszi a beágyazott objektum fájltípusának beállítását, így frissítheti az OLE keret adatait vagy annak kiterjesztését.

Ez a Java kód bemutatja, hogyan állítható be egy beágyazott OLE objektum fájltípusa `zip`‑re:

```java
import com.aspose.slides.*;

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

## **Ikonkép és cím beállítása beágyazott objektumokhoz**

OLE objektum beágyazása után egy előnézeti kép, amely ikonból áll, automatikusan hozzáadódik. Ez az előnézet látható a felhasználók számára, mielőtt elérnék vagy megnyitnák az OLE objektumot. Ha egy konkrét képet és szöveget szeretne használni az előnézetben, beállíthatja az ikonképet és a címet az Aspose.Slides for Java segítségével.

Ez a Java kód bemutatja, hogyan állítható be egy beágyazott objektum ikonképe és címe:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// Képet ad a prezentáció erőforrásaihoz.
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

Miután egy kapcsolt OLE objektumot hozzáadott egy prezentációs diára, a PowerPoint megnyitásakor egy üzenetet kaphat, amely a hivatkozások frissítését kéri. Az „Update Links” gombra kattintás megváltoztathatja az OLE objektumkeret méretét és pozícióját, mivel a PowerPoint frissíti a kapcsolt OLE objektum adatait és az előnézetet. A PowerPoint úgynevezett automatikus frissítésének letiltásához állítsa a [IOleObjectFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ioleobjectframe/) interfész `setUpdateAutomatic` metódusát `false`‑ra:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

oleFrame.setUpdateAutomatic(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Beágyazott fájlok kinyerése**

Az Aspose.Slides for Java lehetővé teszi a diákba beágyazott fájlok OLE objektumként való kinyerését a következő módon:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból, amely tartalmazza a kinyerni kívánt OLE objektumokat.  
2. Ciklusban járja be a prezentáció összes alakzatát, és érje el az [OLEObjectFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/oleobjectframe) alakzatokat.  
3. Hozzáférés a beágyazott fájlok adataihoz az OLE objektumkeretekből, majd írja őket lemezre.  

Ez a Java kód bemutatja, hogyan nyerhet ki egy diára beágyazott fájlokat OLE objektumként:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

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

## **GYIK**

### Megjelenik‑e az OLE tartalom, amikor a diák PDF‑be/képekbe exportálódnak?

A dián látható tartalom kerül renderelésre – az ikon vagy helyettesítő kép (előnézet). Az „élő” OLE tartalom nem kerül végrehajtásra a renderelés során. Ha szükséges, állítson be saját előnézeti képet, hogy a várt megjelenés biztosítva legyen az exportált PDF‑ben.

### Hogyan lehet egy OLE objektumot zárolni a dián, hogy a felhasználók ne tudják mozgatni vagy szerkeszteni PowerPointban?

Zárolja az alakzatot: az Aspose.Slides [alakzatszintű zárakat](/slides/hu/java/applying-protection-to-presentation/) biztosít. Ez nem titkosítás, de hatékonyan megakadályozza a véletlen szerkesztéseket és mozgatást.

### Miért „ugrik” vagy változik mérete egy kapcsolt Excel objektumnak, amikor megnyitom a prezentációt?

A PowerPoint frissítheti a kapcsolt OLE előnézetét. A stabil megjelenés érdekében kövesse a [Worksheet Resizing megoldást](/slides/hu/java/working-solution-for-worksheet-resizing/) – vagy illessze a keretet a tartományra, vagy skálázza a tartományt egy fix kerethez, és állítson be megfelelő helyettesítő képet.

### Megmaradnak‑e a relatív útvonalak a kapcsolt OLE objektumok esetén PPTX formátumban?

PPTX‑ben a „relatív útvonal” információ nem érhető el – csak a teljes útvonal. Relatív útvonalak a régebbi PPT formátumban léteznek. A hordozhatóság érdekében használjon megbízható abszolút útvonalakat/hozzáférhető URI‑kat vagy beágyazást.