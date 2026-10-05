---
title: Správa OLE v prezentacích na Androidu
linktitle: Spravovat OLE
type: docs
weight: 40
url: /cs/androidjava/manage-ole/
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
- Android
- Java
- Aspose.Slides
description: "Optimalizujte správu OLE objektů v PowerPointu a souborech OpenDocument pomocí Aspose.Slides pro Android via Java. Vkládejte, aktualizujte a exportujte OLE obsah bez problémů."
---
## **Úvod**

{{% alert color="info" title="Note" %}}
OLE (Object Linking & Embedding) je technologie společnosti Microsoft, která umožňuje umístit data a objekty vytvořené v jedné aplikaci do jiné aplikace pomocí odkazování nebo vkládání. 
{{% /alert %}} 

Uvažujme o grafu vytvořeném v MS Excel. Tento graf je následně umístěn do snímku PowerPointu. Tento graf z Excelu je považován za OLE objekt. 

- OLE objekt se může zobrazit jako ikona. V takovém případě, když na ikonu dvakrát kliknete, otevře se graf v přidružené aplikaci (Excel) nebo budete vyzváni k výběru aplikace pro otevření či úpravu objektu.
- OLE objekt může zobrazit svůj skutečný obsah, například obsah grafu. V tomto případě se graf aktivuje v PowerPointu, načte se rozhraní grafu a můžete v PowerPointu upravovat data grafu.

[Aspose.Slides pro Android via Java](https://products.aspose.com/slides/androidjava/) vám umožňuje vkládat OLE objekty do snímků jako OLE rámy objektů ([OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame)).

## **Přidat OLE rámy objektů do snímků**

Předpokládejme, že jste již vytvořili graf v Microsoft Excel a chcete jej vložit do snímku jako OLE rám objektu pomocí Aspose.Slides pro Android via Java, můžete tak učinit následujícím způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) class.
1. Získejte odkaz na snímek pomocí jeho indexu.
1. Přečtěte soubor Excel jako pole bajtů.
1. Přidejte [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) do snímku, který obsahuje pole bajtů a další informace o OLE objektu.
1. Zapište upravenou prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme přidali graf ze souboru Excel do snímku jako OLE rám objektu pomocí Aspose.Slides pro Android via Java.
**Poznámka** že konstruktor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleEmbeddedDataInfo) přijímá jako druhý parametr rozšíření vkládaného objektu. Toto rozšíření umožňuje PowerPointu správně rozpoznat typ souboru a vybrat správnou aplikaci pro otevření tohoto OLE objektu.

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

// Připravit data pro OLE objekt.
File file = new File("book.xlsx");
byte fileData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(fileData);

IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Přidat propojené OLE rámy objektů**

Aspose.Slides pro Android via Java vám umožňuje přidat [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) bez vkládání dat, ale pouze s odkazem na soubor.

Tento Java kód vám ukazuje, jak přidat [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) s propojeným souborem Excel do snímku:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Přidat OLE rám objektu s propojeným souborem Excel.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Přístup k OLE rámům objektů**

Pokud je OLE objekt již vložen do snímku, můžete jej snadno najít nebo získat tímto způsobem:

1. Načtěte prezentaci s vloženým OLE objektem vytvořením instance třídy [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) class.
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Získejte přístup k tvaru [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) shape. V našem příkladu jsme použili dříve vytvořený PPTX, který má na prvním snímku pouze jeden tvar. Pak jsme tento objekt *přetypovali* na [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/). Toto byl požadovaný OLE rám objektu, ke kterému jsme chtěli získat přístup.
4. Jakmile získáte přístup k OLE rámu objektu, můžete na něm provádět libovolné operace.

V níže uvedeném příkladu je přístup k OLE rámu objektu (objekt grafu Excel vložený do snímku) a k jeho souborovým datům.

```java 
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // Získat data vloženého souboru.
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // Získat příponu vloženého souboru.
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **Přístup k vlastnostem propojeného OLE rámu objektu**

Aspose.Slides vám umožňuje přístup k vlastnostem propojeného OLE rámu objektu.

Tento Java kód ukazuje, jak zkontrolovat, zda je OLE objekt propojen, a následně získat cestu k propojenému souboru:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // Zkontrolovat, zda je OLE objekt propojen.
    if (oleFrame.isObjectLink()) {
        // Vytisknout úplnou cestu k propojenému souboru.
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // Vytisknout relativní cestu k propojenému souboru, pokud existuje.
        // Pouze prezentace PPT mohou obsahovat relativní cestu.
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **Změna dat OLE objektu**

{{% alert color="info" title="Note" %}}
V této sekci níže uvedený příklad kódu používá [Aspose.Cells for Android via Java](https://docs.aspose.com/cells/androidjava/).
{{% /alert %}}

Pokud je OLE objekt již vložen do snímku, můžete k němu snadno přistoupit a modifikovat jeho data tímto způsobem:

1. Načtěte prezentaci s vloženým OLE objektem vytvořením instance třídy [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) class.
2. Získejte odkaz na snímek pomocí jeho indexu. 
3. Získejte přístup k tvaru OLE objektu. V našem příkladu jsme použili dříve vytvořený PPTX, který má na prvním snímku jeden tvar. Pak jsme tento objekt *přetypovali* na [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/). Toto byl požadovaný OLE rám objektu, ke kterému jsme chtěli získat přístup.
4. Jakmile získáte přístup k OLE rámu objektu, můžete na něm provádět libovolné operace.
5. Vytvořte objekt `Workbook` a získejte přístup k OLE datům.
6. Získejte požadovaný `Worksheet` a upravte data.
7. Uložte aktualizovaný `Workbook` do proudu.
8. Změňte data OLE objektu z proudu.

V níže uvedeném příkladu je přístup k OLE rámu objektu (objekt grafu Excel vložený do snímku) a jsou upravena data souboru pro aktualizaci dat grafu.

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

    // Načíst data OLE objektu jako objekt Workbook.
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // Upravit data sešitu.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
    workbook.save(newOleStream, fileOptions);

    // Změnit data objektu OLE rámu.
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Vkládání dalších typů souborů do snímků**

Kromě grafů Excel umožňuje Aspose.Slides pro Android via Java vkládat do snímků i další typy souborů. Například můžete vložit soubory HTML, PDF a ZIP jako objekty. Když uživatel dvakrát klikne na vložený objekt, automaticky se otevře v příslušném programu, nebo je uživatel vyzván k výběru vhodného programu pro jeho otevření.

Tento Java kód ukazuje, jak vložit HTML a ZIP do snímku:

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

## **Nastavení typů souborů pro vložené objekty**

Při práci s prezentacemi může být potřeba nahradit staré OLE objekty novými nebo nahradit nepodporovaný OLE objekt podporovaným. Aspose.Slides pro Android via Java vám umožňuje nastavit typ souboru pro vložený objekt, což vám umožní aktualizovat data OLE rámu nebo jeho příponu.

Tento Java kód ukazuje, jak nastavit typ souboru pro vložený OLE objekt na `zip`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

System.out.println("Current embedded file extension is: " + fileExtension);

// Změnit typ souboru na ZIP.
oleFrame.setEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Nastavení obrázků ikon a titulků pro vložené objekty**

Po vložení OLE objektu se automaticky přidá náhled sestávající z obrázku ikony. Tento náhled je to, co uživatelé vidí před přístupem nebo otevřením OLE objektu. Pokud chcete použít konkrétní obrázek a text jako prvky v náhledu, můžete nastavit obrázek ikony a titulek pomocí Aspose.Slides pro Android via Java.

Tento Java kód ukazuje, jak nastavit obrázek ikony a titulek pro vložený objekt:

```java
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// Přidat obrázek do zdrojů prezentace.
File file = new File("image.png");
byte imageData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(imageData);
IPPImage oleImage = presentation.getImages().addImage(imageData);

// Set a title and the image for the OLE preview.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Zabránit změně velikosti a přemístění OLE rámu objektu**

Po přidání propojeného OLE objektu do snímku prezentace se při otevření prezentace v PowerPointu může zobrazit zpráva s výzvou k aktualizaci odkazů. Kliknutí na tlačítko „Update Links“ může změnit velikost a umístění OLE rámu objektu, protože PowerPoint aktualizuje data z propojeného OLE objektu a obnoví náhled objektu. Chcete‑li zabránit výzvě PowerPointu k aktualizaci dat objektu, zavolejte metodu [setUpdateAutomatic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#setUpdateAutomatic-boolean-) rozhraní [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/) s hodnotou `false`:

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

## **Extrahování vložených souborů**

Aspose.Slides pro Android via Java vám umožňuje extrahovat soubory vložené do snímků jako OLE objekty tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) class containing the OLE objects you intend to extract.
2. Procházejte všechny tvary v prezentaci a získávejte přístup k tvarům [OLEObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/oleobjectframe) shapes.
3. Získejte data vložených souborů z OLE rámů objektů a zapište je na disk.

Tento Java kód ukazuje, jak extrahovat soubory vložené do snímku jako OLE objekty:

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

## **FAQ**

**Bude OLE obsah vykreslen při exportu snímků do PDF/obrázků?**

To, co je viditelné na snímku, se vykreslí – ikona/náhradní obrázek (náhled). „Živý“ OLE obsah během vykreslování není prováděn. V případě potřeby nastavte vlastní obrázek náhledu, aby byl očekávaný vzhled v exportovaném PDF zajištěn.

Chcete‑li také zachovat vložený soubor jako PDF přílohu, zavolejte [setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) s hodnotou `true`. Tato volba je ve výchozím nastavení zakázána. Pro příklad a instrukce jak zkontrolovat přílohu viz [Zachovat vložené OLE soubory jako PDF přílohy](/slides/cs/androidjava/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Jak mohu uzamknout OLE objekt na snímku, aby jej uživatelé nemohli v PowerPointu přesouvat/upravovat?**

Uzamkněte tvar: Aspose.Slides poskytuje zamykání na úrovni tvaru. Není to šifrování, ale účinně zabraňuje neúmyslným úpravám a přesouvání.

**Proč se propojený Excel objekt „přesouvá“ nebo mění velikost, když otevřu prezentaci?**

PowerPoint může obnovit náhled propojeného OLE. Pro stabilní vzhled postupujte podle praktik [Řešení pro změnu velikosti listu](/slides/cs/androidjava/working-solution-for-worksheet-resizing/) – buď přizpůsobte rám rozsahu, nebo škálujte rozsah na pevný rám a nastavte vhodný náhradní obrázek.

**Zůstanou relativní cesty pro propojené OLE objekty zachovány ve formátu PPTX?**

V PPTX nejsou informace o „relativní cestě“ k dispozici – pouze úplná cesta. Relativní cesty jsou k dispozici ve starším formátu PPT. Pro přenositelnost upřednostněte spolehlivé absolutní cesty/přístupné URI nebo vkládání.