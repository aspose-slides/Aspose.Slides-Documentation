---
title: OLE kezelése a prezentációkban Androidon
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
- Android
- Java
- Aspose.Slides
description: "Optimalizálja az OLE objektum kezelését PowerPoint és OpenDocument fájlokban az Aspose.Slides for Android via Java segítségével. Beágyazza, frissíti és zökkenőmentesen exportálja az OLE tartalmat."
---
## **Bevezetés**

{{% alert color="info" title="Note" %}}

Az OLE (Object Linking & Embedding) egy Microsoft technológia, amely lehetővé teszi, hogy egy alkalmazásban létrehozott adatokat és objektumokat egy másik alkalmazásba helyezzünk el hivatkozással vagy beágyazással. 

{{% /alert %}} 

Vegyük például egy MS Excelben létrehozott diagramot. A diagramot ezután egy PowerPoint‑dia belsejébe helyezzük. Ez az Excel‑diagram OLE objektumnak tekinthető. 

- Egy OLE objektum megjelenhet ikonként. Ebben az esetben, ha duplán kattintunk az ikonra, a diagram a kapcsolódó alkalmazásban (Excel) nyílik meg, vagy felkérik, hogy válasszon egy alkalmazást az objektum megnyitásához vagy szerkesztéséhez.
- Egy OLE objektum megjelenítheti tényleges tartalmát, például egy diagram adatait. Ebben az esetben a diagram a PowerPoint‑ban aktiválódik, betöltődik a diagramfelület, és a diagram adatait a PowerPoint‑on belül módosíthatja.

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/androidjava/) lehetővé teszi OLE objektumok beszúrását a diákba OLE objektumkeretekként ([OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame)).

## **OLE objektumkeretek hozzáadása a diákhoz**

Tegyük fel, hogy már létrehozott egy diagramot a Microsoft Excelben, és azt OLE objektumkeretként szeretné beágyazni egy diára az Aspose.Slides for Android via Java használatával, ezt a következőképpen teheti meg:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) osztályból.
1. Szerezze meg a dia referencia‑pontját az indexe alapján.
1. Olvassa be az Excel‑fájlt bájt‑tömbként.
1. Adja hozzá a [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) keretet a diához, amely tartalmazza a bájt‑tömböt és az OLE objektum egyéb adatait.
1. Írja ki a módosított prezentációt PPTX‑fájlként.

Az alábbi példában egy Excel‑fájlból származó diagramot adtunk hozzá egy diához OLE objektumkeretként az Aspose.Slides for Android via Java használatával.  
**Megjegyzés** hogy a [OleEmbeddedDataInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleEmbeddedDataInfo) konstruktor második paraméterként egy beágyazható objektum‑kiterjesztést vár. Ez a kiterjesztés lehetővé teszi a PowerPoint számára, hogy helyesen értelmezze a fájltípust, és a megfelelő alkalmazást válassza az OLE objektum megnyitásához.

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

// Az OLE objektum adatait előkészíti.
File file = new File("book.xlsx");
byte fileData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(fileData);

IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Adja hozzá az OLE objektumkeretet a diához.
slide.getShapes().addOleObjectFrame(0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Kapcsolt OLE objektumkeretek hozzáadása**

Az Aspose.Slides for Android via Java lehetővé teszi egy [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) hozzáadását anélkül, hogy adatot ágyazna be, csak egy hivatkozást a fájlra.

Ez a Java‑kód bemutatja, hogyan adhatunk hozzá egy [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame)‑et egy kapcsolt Excel‑fájllal a diához:

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

Ha egy OLE objektum már be van ágyazva egy diára, ezt a módot követve könnyen megtalálhatja vagy elérheti:

1. Töltsön be egy prezentációt, amely tartalmazza a beágyazott OLE objektumot, úgy, hogy létrehoz egy példányt a [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) osztályból.
2. Szerezze meg a dia referencia‑pontját az indexével.
3. Érje el az [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) alakzatot.  
   A példánkban a korábban létrehozott PPTX‑et használtuk, amelyen az első dián csak egy alakzat van. Ezután *cast*-oltuk azt az objektumot egy [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/)‑ként. Ez volt a kívánt OLE objektumkeret, amelyet el kell érni.
4. Miután az OLE objektumkeret el lett érve, bármilyen műveletet végrehajthat rajta.

Az alábbi példában egy OLE objektumkeretet (egy Excel‑diagramot beágyazva egy diára) és annak fájladatait érjük el.

```java 
import com.aspose.slides.*;

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

Ez a Java‑kód bemutatja, hogyan ellenőrizhetjük, hogy egy OLE objektum kapcsolt-e, majd hogyan szerezzük meg a kapcsolt fájl elérési útját:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // Ellenőrizze, hogy az OLE objektum kapcsolt-e.
    if (oleFrame.isObjectLink()) {
        // Kiírja a kapcsolt fájl teljes útvonalát.
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // Kiírja a kapcsolt fájl relatív útvonalát, ha létezik.
        // Csak a PPT prezentációk tartalmazhatják a relatív útvonalat.
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **OLE objektum adatának módosítása**

{{% alert color="info" title="Note" %}}

Ebben a szakaszban az alábbi kódrészlet a [Aspose.Cells for Android via Java](https://docs.aspose.com/cells/androidjava/)‑t használja.

{{% /alert %}}

Ha egy OLE objektum már be van ágyazva egy diára, ezt a módot követve könnyen hozzáférhet és módosíthatja az adatokat:

1. Töltsön be egy prezentációt, amely tartalmazza a beágyazott OLE objektumot, úgy, hogy létrehoz egy példányt a [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) osztályból.
2. Szerezze meg a dia referencia‑pontját az indexével. 
3. Érje el az OLE objektumkeret alakzatot.  
   A példánkban a korábban létrehozott PPTX‑et használtuk, amelyen az első dián egy alakzat van. Ezután *cast*-oltuk azt az objektumot egy [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/)‑ként. Ez volt a kívánt OLE objektumkeret, amelyet el kell érni.
4. Miután az OLE objektumkeret el lett érve, bármilyen műveletet végrehajthat rajta.
5. Hozzon létre egy `Workbook` objektumot, és érje el az OLE adatot.
6. Érje el a kívánt `Worksheet`‑et, és módosítsa az adatokat.
7. Mentse az frissített `Workbook`‑ot egy stream‑be.
8. Módosítsa az OLE objektum adatát a stream‑ből.

Az alábbi példában egy OLE objektumkeretet (egy Excel‑diagramot beágyazva egy diára) érünk el, és a fájladatait módosítjuk a diagram adatainak frissítéséhez.

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

    // OLE objektum adatát beolvassa Workbook objektumként.
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // Módosítja a Workbook adatait.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
    workbook.save(newOleStream, fileOptions);

    // Megváltoztatja az OLE keret objektum adatát.
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Más fájltípusok beágyazása a diákba**

Az Excel‑diagramok mellett az Aspose.Slides for Android via Java lehetővé teszi más fájltípusok beágyazását a diákba. Például beilleszthet HTML, PDF és ZIP fájlokat objektumként. Amikor a felhasználó duplán kattint a beszúrt objektumra, az automatikusan megnyílik a megfelelő programban, vagy a felhasználót felkéri, hogy válasszon egy megfelelő programot a megnyitáshoz.

Ez a Java‑kód bemutatja, hogyan lehet HTML‑t és ZIP‑et beágyazni egy diára:

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

Prezentációk kezelése során előfordulhat, hogy régi OLE objektumokat újakkal kell helyettesíteni, vagy egy nem támogatott OLE objektumot egy támogatottal. Az Aspose.Slides for Android via Java lehetővé teszi, hogy beállítsa a beágyazott objektum fájltípusát, ezáltal frissítheti az OLE keret adatait vagy annak kiterjesztését.

Ez a Java‑kód bemutatja, hogyan lehet a beágyazott OLE objektum fájltípusát `zip`‑re állítani:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

System.out.println("Current embedded file extension is: " + fileExtension);

// A fájltípust ZIP-re változtatja.
oleFrame.setEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Ikonképek és címek beállítása beágyazott objektumokhoz**

Az OLE objektum beágyazása után automatikusan hozzáadódik egy előnézeti ikonkép. Ez az előnézet az, amit a felhasználók látnak, mielőtt hozzáférnének vagy megnyitnák az OLE objektumot. Ha egy adott képet és szöveget szeretne használni az előnézet elemeiként, beállíthatja az ikonképet és a címet az Aspose.Slides for Android via Java segítségével.

Ez a Java‑kód mutatja be, hogyan állítható be az ikonkép és a cím egy beágyazott objektumhoz:

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

## **Az OLE objektumkeret átméretezésének és áthelyezésének megakadályozása**

Miután egy kapcsolt OLE objektumot hozzáadott egy prezentációs diához, a prezentáció megnyitásakor a PowerPoint üzenetet jeleníthet meg a hivatkozások frissítéséről. Az „Update Links” gombra kattintva a OLE objektumkeret mérete és pozíciója megváltozhat, mivel a PowerPoint frissíti a kapcsolt OLE objektum adatait és újratölti az előnézetet. A PowerPoint‑nak a objektum adatainak frissítésére vonatkozó kérdés elkerüléséhez hívja meg az [setUpdateAutomatic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#setUpdateAutomatic-boolean-) metódust az [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/) interfészen `false` értékkel:

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

Az Aspose.Slides for Android via Java lehetővé teszi a diáknál OLE objektumként beágyazott fájlok kinyerését a következő módon:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) osztályból, amely tartalmazza azokat az OLE objektumokat, amelyeket ki szeretne nyerni.
2. Járja be a prezentáció összes alakzatát, és érje el a [OLEObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/oleobjectframe) alakzatokat.
3. Érje el a beágyazott fájlok adatait az OLE objektumkeretekből, és írja őket lemezre.

Ez a Java‑kód bemutatja, hogyan lehet a dián beágyazott fájlokat OLE objektumként kinyerni:

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

**Will the OLE content be rendered when exporting slides to PDF/images?**  
Mi jelenik meg a dián, az lesz renderelve – az ikon / helyettesítő kép (előnézet). Az „élő” OLE tartalom nem kerül végrehajtásra a renderelés során. Szükség esetén állítson be saját előnézeti képet, hogy a várt megjelenés biztosítva legyen az exportált PDF‑ben.

A beágyazott fájl PDF‑mellékletként való megőrzéséhez hívja meg a [setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) metódust `true` értékkel. Ez a beállítás alapértelmezés szerint le van tiltva. Példa és útmutató a melléklet ellenőrzéséhez: [Beágyazott OLE fájlok megőrzése PDF mellékletként](/slides/hu/androidjava/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**How can I lock an OLE object on a slide so users cannot move/edit it in PowerPoint?**  
Zárolja az alakzatot: az Aspose.Slides alakzatszintű lezárásokat biztosít. Ez nem titkosítás, de hatékonyan megakadályozza a véletlen szerkesztéseket és áthelyezéseket.

**Why does a linked Excel object "jump" or change size when I open the presentation?**  
A PowerPoint frissítheti a kapcsolt OLE előnézetét. A stabil megjelenés érdekében kövesse a [Működő megoldás a munkalap átméretezésére](/slides/hu/androidjava/working-solution-for-worksheet-resizing/) ajánlásait – vagy illessze a keretet a tartományra, vagy méretezze a tartományt egy rögzített keretre, és állítson be megfelelő helyettesítő képet.

**Will relative paths for linked OLE objects be preserved in the PPTX format?**  
A PPTX‑ben a „relatív útvonal” információ nem érhető el – csak a teljes útvonal tárolható. Relatív útvonalak a régebbi PPT formátumban szerepelnek. A hordozhatóság érdekében javasolt megbízható abszolút útvonalakat/hozzáférhető URI‑kat vagy beágyazást használni.