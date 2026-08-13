---
title: OLE kezelése prezentációkban Androidon
linktitle: OLE kezelése
type: docs
weight: 40
url: /hu/androidjava/manage-ole/
keywords:
- OLE objektum
- Objektum összekapcsolás és beágyazás
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
- Android
- Java
- Aspose.Slides
description: "Optimalizálja az OLE objektumok kezelését PowerPoint és OpenDocument fájlokban az Aspose.Slides for Android via Java segítségével. Ágyazzon be, frissítsen és exportáljon OLE tartalmat zökkenőmentesen."
---
## **Bevezetés**

{{% alert color="info" %}} 

Az OLE (Object Linking & Embedding) egy Microsoft technológia, amely lehetővé teszi, hogy egy alkalmazásban létrehozott adatok és objektumok egy másik alkalmazásba kerüljenek hivatkozás vagy beágyazás útján. 

{{% /alert %}} 

Vegyünk egy az MS Excelben létrehozott diagramot. A diagramot ezután egy PowerPoint diára helyezik. Ez az Excel-diagram OLE-objektumnak tekintendő. 

- OLE-objektum ikonként is megjelenhet. Ebben az esetben, ha duplán kattint az ikonra, a diagram a kapcsolódó alkalmazásban (Excel) nyílik meg, vagy felkérik egy alkalmazás kiválasztására az objektum megnyitásához vagy szerkesztéséhez. 
- OLE-objektum megjelenítheti tényleges tartalmát, például egy diagram tartalmát. Ebben az esetben a diagram aktiválódik a PowerPointben, a diagram felület betöltődik, és módosíthatja a diagram adatait a PowerPointen belül. 

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/hu/androidjava/) lehetővé teszi, hogy OLE-objektumokat szúrjon be a diákba OLE-objektum keretként ([OleObjectFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/OleObjectFrame)). 

## **OLE-objektum keretek hozzáadása a diákhoz**

Hagyjuk, hogy már elkészített egy diagramot a Microsoft Excelben, és OLE-objektum keretként szeretné beágyazni a diára az Aspose.Slides for Android via Java segítségével, ezt így teheti:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.  
1. Szerezze meg egy dia hivatkozását az indexe alapján.  
1. Olvassa be az Excel-fájlt bájt tömbként.  
1. Adja hozzá a [OleObjectFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/OleObjectFrame) elemet a diához, amely tartalmazza a bájt tömböt és egyéb OLE-objektumra vonatkozó információkat.  
1. Írja ki a módosított prezentációt PPTX fájlként.  

Az alábbi példában egy Excel-fájlból származó diagramot adtunk hozzá egy diához OLE-objektum keretként az Aspose.Slides for Android via Java segítségével. **Megjegyzés** , hogy a [OleEmbeddedDataInfo](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/OleEmbeddedDataInfo) konstruktor a beágyazható objektum kiterjesztését második paraméterként veszi. Ez a kiterjesztés lehetővé teszi, hogy a PowerPoint helyesen értelmezze a fájltípust és a megfelelő alkalmazást válassza az OLE-objektum megnyitásához.  

```java 
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Készítse elő az OLE objektum adatait.
File file = new File("book.xlsx");
byte fileData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(fileData);

IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Adja hozzá az OLE objektum keretet a diához.
slide.getShapes().addOleObjectFrame(0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Csatolt OLE-objektum keretek hozzáadása**

Az Aspose.Slides for Android via Java lehetővé teszi, hogy egy [OleObjectFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/OleObjectFrame) elemet hozzáadjon adat beágyazása nélkül, csak a fájlra mutató hivatkozással.  

Ez a Java kód bemutatja, hogyan adhat hozzá egy [OleObjectFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/OleObjectFrame) elemet egy csatolt Excel-fájllal egy diára:  

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// OLE objektumkeret hozzáadása csatolt Excel fájllal.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **OLE-objektum keretek elérése**

Ha egy OLE-objektum már be van ágyazva egy diára, egyszerűen megtalálhatja vagy elérheti a következő módon:  

1. Töltsön be egy prezentációt a beágyazott OLE-objektummal, egy [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztály példányosításával.  
2. Szerezze meg a dia hivatkozását az indexének használatával.  
3. Érje el a [OleObjectFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/OleObjectFrame) alakzatot.  
   A példánkban a korábban létrehozott PPTX-et használtuk, amelyen az első dián csak egy alakzat van. Ezután *átcastoltuk* az objektumot egy [IOleObjectFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ioleobjectframe/) típusra. Ez volt a kívánt OLE-objektum keret, amelyet el akartunk érni.  
4. Miután elérte az OLE-objektum keretet, bármilyen műveletet végrehajthat rajta.  

Az alábbi példában egy OLE-objektum keret (egy Excel-diagram objektum beágyazva egy diára) és annak fájladatai elérhetők.  

```java 
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // Szerezze be a beágyazott fájl adatát.
    // Szerezze be a beágyazott fájl kiterjesztését.
    // ...
}
```

### **Csatolt OLE-objektum keret tulajdonságainak elérése**

Az Aspose.Slides lehetővé teszi a csatolt OLE-objektum keret tulajdonságainak elérését.  

Ez a Java kód bemutatja, hogyan ellenőrizheti, hogy egy OLE-objektum csatolt-e, majd hogyan szerezheti meg a csatolt fájl elérési útját:  

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // Ellenőrizze, hogy az OLE objektum csatolt-e.
    if (oleFrame.isObjectLink()) {
        // Kiírja a csatolt fájl teljes elérési útját.
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // Kiírja a csatolt fájl relatív útvonalát, ha van.
        // Csak a PPT prezentációk tartalmazhatják a relatív útvonalat.
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **OLE-objektum adatainak módosítása**

{{% alert color="info" %}} 

Ebben a szakaszban az alábbi kódrészlet a [Aspose.Cells for Android via Java](/cells/androidjava/) használatát mutatja be.  

{{% /alert %}}  

Ha egy OLE-objektum már be van ágyazva egy diára, a következő módon érheti el és módosíthatja annak adatait:  

1. Töltsön be egy prezentációt a beágyazott OLE-objektummal, egy [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztály példányosításával.  
2. Szerezze meg a dia hivatkozását az indexén keresztül.  
3. Érje el az OLE-objektum keret alakzatot.  
   A példánkban a korábban létrehozott PPTX-et használtuk, amelyen az első dián csak egy alakzat van. Ezután *átcastoltuk* az objektumot egy [IOleObjectFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ioleobjectframe/) típusra. Ez volt a kívánt OLE-objektum keret, amelyet el akartunk érni.  
4. Miután elérte az OLE-objektum keretet, bármilyen műveletet végrehajthat rajta.  
5. Hozzon létre egy `Workbook` objektumot, és érje el az OLE adatokat.  
6. Érje el a kívánt `Worksheet`-et és módosítsa az adatokat.  
7. Mentse a frissített `Workbook`-ot egy adatfolyamba.  
8. Változtassa meg az OLE-objektum adatát az adatfolyamból.  

Az alábbi példában egy OLE-objektum keret (egy Excel-diagram beágyazva egy diára) elérhető, és a fájladatai módosítva vannak a diagram adatainak frissítéséhez.  

```java 
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

    // Olvassa be az OLE objektum adatát Workbook objektumként.
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // Módosítsa a munkafüzet adatait.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
    workbook.save(newOleStream, fileOptions);

    // Módosítsa az OLE keret objektum adatát.
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Egyéb fájltípusok beágyazása a diákba**

Az Excel-diagramok mellett, az Aspose.Slides for Android via Java lehetővé teszi más fájltípusok beágyazását a diákba. Például HTML, PDF és ZIP fájlokat szúrhat be objektumként. Ha a felhasználó duplán kattint a beszúrt objektumra, az automatikusan megnyílik a megfelelő programban, vagy a felhasználót felkérik a megfelelő program kiválasztására a megnyitáshoz.  

Ez a Java kód bemutatja, hogyan ágyazzon be HTML-t és ZIP-et egy diára:  

```java
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;

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

Prezentációk kezelésekor előfordulhat, hogy régi OLE-objektumokat újakkal kell helyettesíteni, vagy egy nem támogatott OLE-objektumot támogatottal. Az Aspose.Slides for Android via Java lehetővé teszi a beágyazott objektum fájltípusának beállítását, ami lehetővé teszi az OLE-keret adatainak vagy kiterjesztésének frissítését.  

Ez a Java kód bemutatja, hogyan állítható be egy beágyazott OLE-objektum fájltípusa `zip`-re:  

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

System.out.println("Current embedded file extension is: " + fileExtension);

// A fájl típusa ZIP-re módosítva.
oleFrame.setEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Ikon képek és címek beállítása beágyazott objektumokhoz**

Az OLE-objektum beágyazása után egy ikonképből álló előnézet kerül automatikusan hozzáadásra. Ez az előnézet az, amit a felhasználók látnak az OLE-objektum elérése vagy megnyitása előtt. Ha egy konkrét képet és szöveget szeretne használni az előnézet elemeiként, beállíthatja az ikonképet és a címet az Aspose.Slides for Android via Java segítségével.  

Ez a Java kód bemutatja, hogyan állítható be az ikonkép és a cím egy beágyazott objektumhoz:  

```java
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;

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

## **Az OLE-objektum keret átméretezésének és áthelyezésének megakadályozása**

Miután egy csatolt OLE-objektumot ad egy prezentáció diájához, a PowerPointban megnyitva megjelenhet egy üzenet, amely a hivatkozások frissítését kéri. Az „Update Links” gomb megnyomása megváltoztathatja az OLE-objektum keret méretét és pozícióját, mivel a PowerPoint frissíti az adatokat a csatolt OLE-objektumból és frissíti az előnézetet. A PowerPoint arra vonatkozó felkérdezésének megelőzéséhez, hogy frissítse az objektum adatait, állítsa a `setUpdateAutomatic` metódust a [IOleObjectFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ioleobjectframe/) interfészen `false`-ra:  

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    oleFrame.setUpdateAutomatic(false);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Beágyazott fájlok kinyerése**

Az Aspose.Slides for Android via Java lehetővé teszi a diákba beágyazott fájlok OLE-objektumként való kinyerését a következő módon:  

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztály példányt, amely a kinyerni kívánt OLE-objektumokat tartalmazza.  
2. Iteráljon végig a prezentáció összes alakzataján, és érje el a [OleObjectFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/oleobjectframe) alakzatokat.  
3. Érje el a beágyazott fájlok adatait az OLE-objektum keretekből, és írja ki őket a lemezre.  

Ez a Java kód bemutatja, hogyan nyerhetők ki a diára beágyazott fájlok OLE-objektumként:  

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileOutputStream;

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

### Renderelődik-e az OLE tartalom a diák PDF/képre exportálásakor?

A dián látható dolog kerül renderelésre – az ikon/pótló kép (előnézet). Az „élő” OLE-tartalom nem kerül végrehajtásra a renderelés során. Szükség esetén állítson be saját előnézeti képet, hogy a várt megjelenés legyen az exportált PDF-ben.

### Hogyan zárhatok le egy OLE-objektumot a dián, hogy a felhasználók ne mozgathassák/szerkeszthessék a PowerPointban?

Zárolja az alakzatot: az Aspose.Slides alakzatszintű zárolásokat biztosít. Ez nem titkosítás, de hatékonyan megakadályozza a véletlen szerkesztéseket és mozgatást.

### Miért „ugrik” vagy változik a mérete egy csatolt Excel-objektumnak a prezentáció megnyitásakor?

A PowerPoint frissítheti a csatolt OLE előnézetét. A stabil megjelenés érdekében kövesse a [Working Solution for Worksheet Resizing](/slides/hu/androidjava/working-solution-for-worksheet-resizing/) útmutatót – vagy illessze a keretet a tartományhoz, vagy méretezze a tartományt egy fix kerethez, és állítson be megfelelő pótló képet.

### Megmaradnak-e a relatív útvonalak a csatolt OLE-objektumok esetén a PPTX formátumban?

A PPTX-ben a „relatív útvonal” információ nem áll rendelkezésre – csak a teljes útvonal. Relatív útvonalak csak a régebbi PPT formátumban találhatók. A hordozhatóság érdekében inkább megbízható abszolút útvonalakat/hozzáférhető URI‑kat vagy beágyazást használjon.