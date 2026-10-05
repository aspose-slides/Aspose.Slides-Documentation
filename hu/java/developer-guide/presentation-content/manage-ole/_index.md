---
title: OLE kezelése prezentációkban Java használatával
linktitle: OLE kezelése
type: docs
weight: 40
url: /hu/java/manage-ole/
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
- Java
- Aspose.Slides
description: "Optimalizáld az OLE objektumok kezelését PowerPoint és OpenDocument fájlokban az Aspose.Slides for Java segítségével. Ágyazd be, frissítsd és exportáld zökkenőmentesen az OLE tartalmat."
---
## **Bevezetés**

{{% alert color="info" title="Megjegyzés" %}}

Az OLE (Object Linking & Embedding) egy Microsoft technológia, amely lehetővé teszi, hogy egy alkalmazásban létrehozott adatokat és objektumokat egy másik alkalmazásba helyezzük be hivatkozás vagy beágyazás révén. 

{{% /alert %}} 

Gondoljunk egy MS Excelben létrehozott diagramra. A diagramot ezután egy PowerPoint diára helyezzük. Az Excel-diagram OLE objektumnak tekinthető. 

- Egy OLE objektum ikonként jelenhet meg. Ebben az esetben, ha duplán kattintasz az ikonra, a diagram megnyílik a hozzá tartozó alkalmazásban (Excel), vagy felkér, hogy válassz egy alkalmazást az objektum megnyitásához vagy szerkesztéséhez.
- Egy OLE objektum megjelenítheti a tényleges tartalmát, például a diagram tartalmát. Ebben az esetben a diagram aktiválódik a PowerPointban, betöltődik a diagram felülete, és a PowerPointon belül módosíthatod a diagram adatait.

Az [Aspose.Slides for Java](https://products.aspose.com/slides/java/) lehetővé teszi, hogy OLE objektumokat szúrj be a diákba OLE objektumkeretként ([OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame)).

## **OLE objektumkeretek hozzáadása a diákhoz**

Tegyük fel, hogy már létrehoztál egy diagramot a Microsoft Excelben, és azt OLE objektumkeretként szeretnéd beágyazni egy diára az Aspose.Slides for Java segítségével, ezt a módot követheted:

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) osztályból.
1. Szerezd meg egy dia hivatkozását az indexén keresztül.
1. Olvasd be az Excel fájlt bájt tömbként.
1. Add hozzá a [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) keretet a diához, amely tartalmazza a bájt tömböt és az OLE objektummal kapcsolatos egyéb információkat.
1. Írd ki a módosított prezentációt PPTX fájlként.

Az alábbi példában egy Excel fájlból származó diagramot adtunk hozzá egy diához OLE objektumkeretként az Aspose.Slides for Java használatával.
**Megjegyzés** hogy a [OleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/OleEmbeddedDataInfo) konstruktor második paraméterként egy beágyazható objektum kiterjesztést vár. Ez a kiterjesztés lehetővé teszi a PowerPoint számára, hogy helyesen értelmezze a fájltípust és kiválassza a megfelelő alkalmazást az OLE objektum megnyitásához.

``` java 
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Az OLE objektum adatainak előkészítése.
byte[] fileData = Files.readAllBytes(Paths.get("book.xlsx"));
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Az OLE objektumkeret hozzáadása a diára.
slide.getShapes().addOleObjectFrame(0, 0, (float)slideSize.getWidth(), (float)slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Linkelt OLE objektumkeretek hozzáadása**

Az Aspose.Slides for Java lehetővé teszi egy [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) hozzáadását beágyazott adat nélkül, csak a fájlra mutató hivatkozással.

Ez a Java kód megmutatja, hogyan adhatsz hozzá egy [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) hivatkozott Excel fájllal a diához:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// OLE objektumkeret hozzáadása egy hivatkozott Excel fájllal.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **OLE objektumkeretek elérése**

Ha egy OLE objektum már be van ágyazva egy diára, egyszerűen megtalálhatod vagy elérheted a következő módon:

1. Tölts be egy prezentációt, amely tartalmaz beágyazott OLE objektumot, a [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) osztály példányosításával.
2. Szerezd meg a dia hivatkozását az indexének használatával.
3. Érj el a [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) alakzatot.

   A példánkban a korábban létrehozott PPTX-et használtuk, amelyen az első dián csak egy alakzat van. Ezután *cast*-oltuk azt az objektumot egy [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IOleObjectFrame) típusra. Ez volt a kívánt OLE objektumkeret, amelyet el akartunk érni.
4. Miután elérted az OLE objektumkeretet, bármilyen műveletet végezhetsz rajta.

Az alábbi példában egy OLE objektumkeretet (egy diába beágyazott Excel diagram objektumot) és annak fájladatait érjük el.

``` java 
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // A beágyazott fájl adatainak lekérése.
    // A beágyazott fájl kiterjesztésének lekérése.
    // ...
}
```

### **Linkelt OLE objektumkeret tulajdonságainak elérése**

Az Aspose.Slides lehetővé teszi a linkelt OLE objektumkeret tulajdonságainak elérését.

Ez a Java kód megmutatja, hogyan ellenőrizheted, hogy egy OLE objektum linkelt-e, majd hogyan nyerheted ki a linkelt fájl elérési útját:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // Ellenőrizze, hogy az OLE objektum hivatkozott-e.
    if (oleFrame.isObjectLink()) {
        // Írja ki a hivatkozott fájl teljes elérési útját.
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // Írja ki a hivatkozott fájl relatív útvonalát, ha létezik.
        // Csak a PPT prezentációk tartalmazhatják a relatív útvonalat.
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **OLE objektum adatának módosítása**

{{% alert color="info" title="Megjegyzés" %}}

Ebben a szakaszban az alábbi kódpélda a [Aspose.Cells for Java](https://docs.aspose.com/cells/java/) könyvtárat használja.

{{% /alert %}}

Ha egy OLE objektum már be van ágyazva egy diára, egyszerűen elérheted azt az objektumot és módosíthatod az adatát a következőképpen:

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) osztályból, amely tartalmaz beágyazott OLE objektumot.
2. Szerezd meg a dia hivatkozását az indexén keresztül. 
3. Érj el az OLE objektumkeret alakzatot.

   A példánkban a korábban létrehozott PPTX-et használtuk, amelyen az első dián egy alakzat van. Ezután *cast*-oltuk azt az objektumot egy [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IOleObjectFrame) típusra. Ez volt a kívánt OLE objektumkeret, amelyet el akartunk érni.
4. Miután elérted az OLE objektumkeretet, bármilyen műveletet végezhetsz rajta.
5. `Workbook` objektumot hoz létre, és eléri az OLE adatot.
6. Eléri a kívánt `Worksheet`-et és módosítja az adatot.
7. Elmenti a frissített `Workbook`-ot egy áramlásba.
8. Megváltoztatja az OLE objektum adatát az áramlásból.

Az alábbi példában egy OLE objektumkeret (egy diába beágyazott Excel diagram) kerül elérésre, és a fájladatai módosulnak a diagram adatainak frissítéséhez.

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

Az Excel diagramok mellett az Aspose.Slides for Java lehetővé teszi más fájltípusok beágyazását a diákba. Például HTML, PDF és ZIP fájlokat szúrhatsz be objektumként. Amikor a felhasználó duplán kattint a beszúrt objektumra, az automatikusan megnyílik a megfelelő programban, vagy a felhasználót felszólítják, hogy válasszon egy megfelelő programot a megnyitáshoz.

Ez a Java kód megmutatja, hogyan ágyazz be HTML-t és ZIP-et egy diára:

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

## **Beágyazott objektumok fájltípusának beállítása**

Prezentációk kezelése közben előfordulhat, hogy régi OLE objektumokat újakkal kell helyettesíteni, vagy egy nem támogatott OLE objektumot támogatottal. Az Aspose.Slides for Java lehetővé teszi, hogy beállítsd a beágyazott objektum fájltípusát, így frissítheted az OLE keret adatát vagy annak kiterjesztését.

Ez a Java kód megmutatja, hogyan állítsd be egy beágyazott OLE objektum fájltípusát `zip`-re:

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

## **Ikon képek és címek beállítása beágyazott objektumokhoz**

Egy OLE objektum beágyazása után automatikusan hozzáadódik egy előnézet, amely egy ikon képből áll. Ez az előnézet azt mutatja a felhasználóknak, mielőtt hozzáférnének vagy megnyitnák az OLE objektumot. Ha egy konkrét képet és szöveget szeretnél használni az előnézet elemeiként, az Aspose.Slides for Java segítségével beállíthatod az ikon képet és a címet.

Ez a Java kód megmutatja, hogyan állítsd be az ikon képet és a címet egy beágyazott objektumhoz:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

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

## **Megakadályozni egy OLE objektumkeret átméretezését és áthelyezését**

Miután egy linkelt OLE objektumot hozzáadtál egy prezentációs diára, a PowerPointban történő megnyitáskor megjelenhet egy üzenet, amely a linkek frissítését kéri. Az „Update Links” gombra kattintás módosíthatja az OLE objektumkeret méretét és pozícióját, mivel a PowerPoint frissíti a linkelt OLE objektum adatait és újratölti az objektum előnézetét. Ahhoz, hogy a PowerPoint ne kérje az objektum adatainak frissítését, hívja meg a [setUpdateAutomatic](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#setUpdateAutomatic-boolean-) metódust a [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/) interfészben `false` értékkel:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

oleFrame.setUpdateAutomatic(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Beágyazott fájlok kicsomagolása**

Aspose.Slides for Java lehetővé teszi a diákba beágyazott fájlok OLE objektumként történő kicsomagolását a következő módon:

1. Hozz létre egy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) osztály példányt, amely tartalmazza a kicsomagolni kívánt OLE objektumokat.
2. Iterálj végig a prezentáció összes alakzatain, és érj hozzá az [OLEObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/oleobjectframe) alakzatokhoz.
3. Érj hozzá a beágyazott fájlok adataihoz az OLE objektumkeretekből, és írd őket lemezre.

Ez a Java kód megmutatja, hogyan csomagolj ki fájlokat, amelyeket egy diára OLE objektumként ágyaztak be:

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

**Az OLE tartalom renderelődik a diák PDF/képek formátumba exportálásakor?**

A dián látható jelenik meg – az ikon/helyettesítő kép (előnézet). A „valódi” OLE tartalom nem kerül végrehajtásra a renderelés során. Szükség esetén állíts be saját előnézeti képet, hogy az exportált PDF a várt megjelenést kapja.

A beágyazott fájl PDF mellékletként való megőrzéséhez hívd meg a [setIncludeOleData](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) metódust `true` értékkel. Ez az opció alapértelmezés szerint le van tiltva. Példáért és a melléklet ellenőrzésének leírásáért lásd a [Preserve Embedded OLE Files as PDF Attachments](/slides/hu/java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments) oldalt.

**Hogyan zárhatok le egy OLE objektumot egy dián, hogy a felhasználók ne mozgathassák/szerkeszthessék a PowerPointban?**

Zárold le az alakzatot: az Aspose.Slides [alakzatszintű zárakat](/slides/hu/java/applying-protection-to-presentation/) kínál. Ez nem titkosítás, de hatékonyan meggátolja a véletlen szerkesztéseket és áthelyezéseket.

**Miért „ugrik” vagy változtat méretet egy linkelt Excel objektum a prezentáció megnyitásakor?**

A PowerPoint frissítheti a linkelt OLE előnézetét. Stabil megjelenéshez kövesd a [Working Solution for Worksheet Resizing](/slides/hu/java/working-solution-for-worksheet-resizing/) ajánlásait – vagy igazítsd a keretet a tartományhoz, vagy méretezd a tartományt egy rögzített keretre, és állíts be megfelelő helyettesítő képet.

**Megmaradnak a linkelt OLE objektumok relatív útvonalai a PPTX formátumban?**

A PPTX-ben a „relatív útvonal” információ nem érhető el – csak a teljes útvonal. A relatív útvonalak a régebbi PPT formátumban találhatók. A hordozhatóság érdekében inkább megbízható abszolút útvonalakat/hozzáférhető URI-kat vagy beágyazást használj.