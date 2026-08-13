---
title: Správa OLE v prezentacích pomocí Java
linktitle: Správa OLE
type: docs
weight: 40
url: /cs/java/manage-ole/
keywords:
- OLE objekt
- Propojení a vkládání objektů
- přidat OLE
- vložit OLE
- přidat objekt
- vložit objekt
- přidat soubor
- vložit soubor
- propojený objekt
- propojený soubor
- změnit OLE
- ikona OLE
- název OLE
- extrahovat OLE
- extrahovat objekt
- extrahovat soubor
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Optimalizujte správu OLE objektů v souborech PowerPoint a OpenDocument pomocí Aspose.Slides pro Javu. Vkládejte, aktualizujte a exportujte OLE obsah bez problémů."
---
## **Úvod**

{{% alert color="info" %}} 

OLE (Object Linking & Embedding) je technologie Microsoftu, která umožňuje umisťovat data a objekty vytvořené v jedné aplikaci do jiné aplikace pomocí linkování nebo vložení. 

{{% /alert %}} 

Uvažujme o grafu vytvořeném v MS Excel. Graf je poté umístěn do snímku PowerPointu. Tento Excel graf se považuje za OLE objekt. 

- OLE objekt se může zobrazit jako ikona. V takovém případě se po dvojitém kliknutí na ikonu graf otevře v přidružené aplikaci (Excel) nebo budete vyzváni k výběru aplikace pro otevření či úpravu objektu. 
- OLE objekt může zobrazit svůj skutečný obsah, například obsah grafu. V tomto případě se graf aktivuje v PowerPointu, načte se rozhraní grafu a můžete upravovat data grafu přímo v PowerPointu.

[Aspose.Slides for Java](https://products.aspose.com/slides/cs/java/) umožňuje vkládat OLE objekty do snímků jako OLE objektové rámy ([OleObjectFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/OleObjectFrame)).

## **Přidání OLE objektových rámců do snímků**

Předpokládejme, že jste již vytvořili graf v Microsoft Excel a chcete jej vložit do snímku jako OLE objektový rámec pomocí Aspose.Slides for Java, můžete tak učinit tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
1. Získejte referenci na snímek pomocí jeho indexu.
1. Načtěte soubor Excel jako pole bajtů.
1. Přidejte [OleObjectFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/OleObjectFrame) do snímku, který obsahuje pole bajtů a další informace o OLE objektu.
1. Zapište upravenou prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme přidali graf ze souboru Excel do snímku jako OLE objektový rámec pomocí Aspose.Slides for Java.  
**Poznámka**: konstruktor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/cs/java/com.aspose.slides/OleEmbeddedDataInfo) přijímá jako druhý parametr rozšíření vkládaného objektu. Toto rozšíření umožňuje PowerPointu správně interpretovat typ souboru a vybrat správnou aplikaci pro otevření tohoto OLE objektu.

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

### **Přidání propojených OLE objektových rámců**

Aspose.Slides for Java umožňuje přidat [OleObjectFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/OleObjectFrame) bez vkládání dat, ale pouze s odkazem na soubor.

Tento Java kód vám ukazuje, jak přidat [OleObjectFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/OleObjectFrame) s propojeným souborem Excel do snímku:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Přidejte OLE objektový rámec s propojeným souborem Excel.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Přístup k OLE objektovým rámcům**

Pokud je OLE objekt již vložen do snímku, můžete jej snadno najít nebo získat tímto způsobem:

1. Načtěte prezentaci s vloženým OLE objektem vytvořením instance třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
2. Získejte referenci na snímek pomocí jeho indexu.
3. Získejte přístup k tvaru [OleObjectFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/OleObjectFrame).
   V našem příkladu jsme použili dříve vytvořený soubor PPTX, který má na první snímku pouze jeden tvar. Poté jsme tento objekt *cast* na [IOleObjectFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IOleObjectFrame). To byl požadovaný OLE objektový rámec, který bylo potřeba získat.
4. Jakmile získáte OLE objektový rámec, můžete na něm provádět libovolné operace.

V níže uvedeném příkladu je získán OLE objektový rámec (objekt Excel grafu vložený do snímku) a jeho souborová data.

``` java 
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // Získejte vložená data souboru.
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // Získejte příponu vloženého souboru.
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **Přístup k vlastnostem propojeného OLE objektového rámce**

Aspose.Slides umožňuje přístup k vlastnostem propojeného OLE objektového rámce.

Tento Java kód vám ukazuje, jak zjistit, zda je OLE objekt propojen, a poté získat cestu k propojenému souboru:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // Zkontrolujte, zda je OLE objekt propojen.
    if (oleFrame.isObjectLink()) {
        // Vytiskněte úplnou cestu k propojenému souboru.
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // Vytiskněte relativní cestu k propojenému souboru, pokud existuje.
        // Pouze prezentace PPT mohou obsahovat relativní cestu.
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **Změna dat OLE objektu**

{{% alert color="info" %}} 

V této sekci příklad kódu níže používá [Aspose.Cells for Java](/cells/java/).

{{% /alert %}}

Pokud je OLE objekt již vložen do snímku, můžete jej snadno získat a upravit jeho data tímto způsobem:

1. Načtěte prezentaci s vloženým OLE objektem vytvořením instance třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
2. Získejte referenci na snímek pomocí jeho indexu.
3. Získejte přístup k tvaru OLE objektového rámce.
   V našem příkladu jsme použili dříve vytvořený soubor PPTX, který má na první snímku jeden tvar. Poté jsme tento objekt *cast* na [IOleObjectFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IOleObjectFrame). To byl požadovaný OLE objektový rámec, který bylo potřeba získat.
4. Jakmile získáte OLE objektový rámec, můžete na něm provádět libovolné operace.
5. Vytvořte objekt `Workbook` a získejte přístup k OLE datům.
6. Získejte požadovaný `Worksheet` a upravte data.
7. Uložte aktualizovaný `Workbook` do proudu.
8. Změňte data OLE objektu ze proudu.

V níže uvedeném příkladu je získán OLE objektový rámec (objekt Excel grafu vložený do snímku) a jeho souborová data jsou upravena pro aktualizaci dat grafu.

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

    // Načtěte data OLE objektu jako objekt Workbook.
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // Upravte data workbooku.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
    workbook.save(newOleStream, fileOptions);

    // Změňte data objektu OLE rámce.
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Vkládání dalších typů souborů do snímků**

Kromě Excel grafů umožňuje Aspose.Slides for Java vkládat do snímků i další typy souborů. Například můžete vložit soubory HTML, PDF a ZIP jako objekty. Když uživatel dvojitě klikne na vložený objekt, automaticky se otevře v příslušném programu, nebo je uživatel vyzván k výběru vhodného programu pro jeho otevření.

Tento Java kód vám ukazuje, jak vložit HTML a ZIP do snímku:

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

## **Nastavení typů souborů pro vložené objekty**

Při práci s prezentacemi může být potřeba nahradit staré OLE objekty novými nebo nahradit nepodporovaný OLE objekt podporovaným. Aspose.Slides for Java umožňuje nastavit typ souboru pro vložený objekt, což vám umožní aktualizovat data OLE rámce nebo jeho rozšíření.

Tento Java kód vám ukazuje, jak nastavit typ souboru pro vložený OLE objekt na `zip`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

System.out.println("Current embedded file extension is: " + fileExtension);

// Změňte typ souboru na ZIP.
oleFrame.setEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Nastavení obrázků ikon a názvů pro vložené objekty**

Po vložení OLE objektu se automaticky přidá náhled sestávající z obrázku ikony. Tento náhled je to, co uživatelé vidí před přístupem k OLE objektu nebo jeho otevřením. Pokud chcete použít konkrétní obrázek a text jako součásti náhledu, můžete nastavit obrázek ikony a název pomocí Aspose.Slides for Java.

Tento Java kód vám ukazuje, jak nastavit obrázek ikony a název pro vložený objekt:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// Přidejte obrázek do zdrojů prezentace.
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage oleImage = presentation.getImages().addImage(imageData);

// Set a title and the image for the OLE preview.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Zabránění změně velikosti a pozice OLE objektového rámce**

Po přidání propojeného OLE objektu do snímku prezentace se při otevření prezentace v PowerPointu může objevit zpráva s výzvou k aktualizaci odkazů. Kliknutím na tlačítko „Update Links“ se může změnit velikost a pozice OLE objektového rámce, protože PowerPoint aktualizuje data z propojeného OLE objektu a obnovuje náhled objektu. Aby se zabránilo výzvě PowerPointu k aktualizaci dat objektu, nastavte metodu `setUpdateAutomatic` rozhraní [IOleObjectFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ioleobjectframe/) na `false`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

oleFrame.setUpdateAutomatic(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Extrahování vložených souborů**

Aspose.Slides for Java umožňuje extrahovat soubory vložené do snímků jako OLE objekty tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation), která obsahuje OLE objekty, které chcete extrahovat.
2. Procházejte všechny tvary v prezentaci a získejte přístup k tvarům [OLEObjectFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/oleobjectframe).
3. Získejte data vložených souborů z OLE objektových rámců a zapište je na disk.

Tento Java kód vám ukazuje, jak extrahovat soubory vložené do snímku jako OLE objekty:

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

## **Často kladené otázky**

### Bude OLE obsah vykreslen při exportu snímků do PDF/obrázků?

To, co je na snímku viditelné, se vykreslí – ikona/náhradní obrázek (náhled). „Živý“ OLE obsah není při vykreslování prováděn. V případě potřeby nastavte vlastní obrázek náhledu, aby výstupní PDF měl očekávaný vzhled.

### Jak mohu uzamknout OLE objekt na snímku, aby jej uživatelé nemohli v PowerPointu přesouvat/editovat?

Uzamkněte tvar: Aspose.Slides poskytuje [zámky na úrovni tvaru](/slides/cs/java/applying-protection-to-presentation/). Nejedná se o šifrování, ale účinně zabraňuje neúmyslným úpravám a přesunu.

### Proč se propojený Excel objekt „přeskočí“ nebo změní velikost, když otevřu prezentaci?

PowerPoint může obnovit náhled propojeného OLE. Pro stabilní vzhled postupujte podle praktických rad v [Working Solution for Worksheet Resizing](/slides/cs/java/working-solution-for-worksheet-resizing/) – buď přizpůsobte rámec rozsahu, nebo škálujte rozsah do pevného rámce a nastavte vhodný náhradní obrázek.

### Budou relativní cesty pro propojené OLE objekty zachovány ve formátu PPTX?

V PPTX nejsou informace o „relativní cestě“ k dispozici – pouze úplná cesta. Relativní cesty jsou k dispozici jen ve starším formátu PPT. Pro přenositelnost upřednostněte spolehlivé absolutní cesty/přístupné URI nebo vkládání.