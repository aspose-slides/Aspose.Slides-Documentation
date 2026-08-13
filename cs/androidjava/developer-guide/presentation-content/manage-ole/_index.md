---
title: Správa OLE v prezentacích na Androidu
linktitle: Správa OLE
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
- odkazovaný objekt
- odkazovaný soubor
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
description: "Optimalizujte správu OLE objektů v PowerPointu a souborech OpenDocument pomocí Aspose.Slides pro Android přes Java. Vkládejte, aktualizujte a exportujte OLE obsah snadno."
---
## **Úvod**

{{% alert color="info" %}} 

OLE (Object Linking & Embedding) je technologie společnosti Microsoft, která umožňuje umístit data a objekty vytvořené v jedné aplikaci do jiné aplikace pomocí propojení nebo vložení. 

{{% /alert %}} 

Představte si graf vytvořený v MS Excel. Tento graf je následně umístěn do snímku PowerPointu. Tento Excel graf se považuje za OLE objekt. 

- OLE objekt se může zobrazit jako ikona. V takovém případě, když ikonu dvakrát kliknete, otevře se graf v příslušné aplikaci (Excel), nebo budete vyzváni k výběru aplikace pro otevření či úpravu objektu. 
- OLE objekt může zobrazit svůj skutečný obsah, například obsah grafu. V takovém případě se graf aktivuje v PowerPointu, načte se rozhraní grafu a můžete v PowerPointu upravovat data grafu. 

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/cs/androidjava/) umožňuje vložit OLE objekty do snímků jako OLE rámce objektů ([OleObjectFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/OleObjectFrame)).

## **Přidání OLE rámců objektů do snímků**

Předpokládejme, že jste již vytvořili graf v Microsoft Excel a chcete jej vložit do snímku jako OLE rámec objektu pomocí Aspose.Slides for Android via Java, můžete to provést takto:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) .
1. Získejte odkaz na snímek pomocí jeho indexu.
1. Načtěte soubor Excel jako pole bytů.
1. Přidejte [OleObjectFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/OleObjectFrame) do snímku a zahrňte pole bytů a další informace o OLE objektu.
1. Uložte upravenou prezentaci jako soubor PPTX.

V následujícím příkladu jsme přidali graf ze souboru Excel do snímku jako OLE rámec objektu pomocí Aspose.Slides for Android via Java.  
**Note** that the [OleEmbeddedDataInfo](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/OleEmbeddedDataInfo) constructor takes an embeddable object extension as a second parameter. This extension allows PowerPoint to correctly interpret the file type and choose the right application to open this OLE object.

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

// Přidat OLE rámec objektu do snímku.
slide.getShapes().addOleObjectFrame(0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Přidání odkazovaných OLE rámců objektů**

Aspose.Slides for Android via Java umožňuje přidat [OleObjectFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/OleObjectFrame) bez vložení dat, ale pouze s odkazem na soubor.

Tento Java kód ukazuje, jak přidat [OleObjectFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/OleObjectFrame) s odkazovaným souborem Excel do snímku:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Přidat OLE rámec objektu s odkazovaným souborem Excel.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Přístup k OLE rámcům objektů**

Pokud je OLE objekt již vložen do snímku, můžete jej snadno najít nebo získat tímto způsobem:

1. Načtěte prezentaci s vloženým OLE objektem vytvořením instance třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) .
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přistupte k tvaru [OleObjectFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/OleObjectFrame). V našem příkladu jsme použili dříve vytvořený PPTX, který má na prvním snímku pouze jeden tvar. Poté jsme tento objekt *přetypovali* na [IOleObjectFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ioleobjectframe/). To byl požadovaný OLE rámec objektu, ke kterému jsme chtěli přistoupit.
4. Jakmile je OLE rámec objektu přístupný, můžete na něm provádět libovolné operace.

V následujícím příkladu je přístup k OLE rámci objektu (Excel graf vložený do snímku) a k jeho souborovým datům.

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

### **Přístup k vlastnostem odkazovaného OLE rámce objektu**

Aspose.Slides umožňuje přístup k vlastnostem odkazovaného OLE rámce objektu.

Tento Java kód ukazuje, jak zkontrolovat, zda je OLE objekt odkazovaný, a poté získat cestu k odkazovanému souboru:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // Zkontrolovat, zda je OLE objekt odkazovaný.
    if (oleFrame.isObjectLink()) {
        // Vytisknout úplnou cestu k odkazovanému souboru.
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // Vytisknout relativní cestu k odkazovanému souboru, pokud existuje.
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

V této sekci níže uvedený ukázkový kód používá [Aspose.Cells for Android via Java](/cells/androidjava/).

{{% /alert %}}

Pokud je OLE objekt již vložen do snímku, můžete jej snadno získat a upravit jeho data tímto způsobem:

1. Načtěte prezentaci s vloženým OLE objektem vytvořením instance třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) .
2. Získejte odkaz na snímek pomocí jeho indexu. 
3. Přistupte k tvaru OLE rámce objektu. V našem příkladu jsme použili dříve vytvořený PPTX, který má na prvním snímku jeden tvar. Poté jsme tento objekt *přetypovali* na [IOleObjectFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ioleobjectframe/). To byl požadovaný OLE rámec objektu, ke kterému jsme chtěli přistoupit.
4. Jakmile je OLE rámec objektu přístupný, můžete na něm provádět libovolné operace.
5. Vytvořte objekt `Workbook` a přistupte k OLE datům.
6. Přistupte k požadovanému `Worksheet` a upravte data.
7. Uložte aktualizovaný `Workbook` do proudu.
8. Změňte data OLE objektu ze streamu.

V následujícím příkladu je přístup k OLE rámci objektu (Excel graf vložený do snímku) a modifikace jeho souborových dat k aktualizaci dat grafu.

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

    // Upravit data workbooku.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
    workbook.save(newOleStream, fileOptions);

    // Změnit data OLE rámce objektu.
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Vložení dalších typů souborů do snímků**

Kromě Excel grafů umožňuje Aspose.Slides for Android via Java vložit do snímků i jiné typy souborů. Například můžete vložit HTML, PDF a ZIP soubory jako objekty. Když uživatel dvakrát klikne na vložený objekt, automaticky se otevře v příslušném programu, nebo je uživatel vyzván k výběru vhodného programu pro jeho otevření.

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

Při práci s prezentacemi může být nutné nahradit staré OLE objekty novými nebo nahradit nepodporovaný OLE objekt podporovaným. Aspose.Slides for Android via Java umožňuje nastavit typ souboru pro vložený objekt, což vám umožní aktualizovat data OLE rámce nebo jeho příponu.

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

## **Nastavení obrázků ikon a titulů pro vložené objekty**

Po vložení OLE objektu se automaticky přidá náhled sestávající z obrázku ikony. Tento náhled je to, co uživatelé vidí před přístupem nebo otevřením OLE objektu. Pokud chcete v náhledu použít konkrétní obrázek a text, můžete nastavit obrázek ikony a titul pomocí Aspose.Slides for Android via Java.

Tento Java kód ukazuje, jak nastavit obrázek ikony a titul pro vložený objekt:

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

## **Zabránění změny velikosti a přesunu OLE rámce objektu**

Po přidání odkazovaného OLE objektu do snímku prezentace, když prezentaci otevřete v PowerPointu, může se zobrazit zpráva s výzvou k aktualizaci odkazů. Kliknutí na tlačítko "Update Links" může změnit velikost a polohu OLE rámce objektu, protože PowerPoint aktualizuje data z odkazovaného OLE objektu a obnoví náhled objektu. Aby se PowerPoint neptal na aktualizaci dat objektu, nastavte metodu `setUpdateAutomatic` rozhraní [IOleObjectFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ioleobjectframe/) na `false`:

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

Aspose.Slides for Android via Java umožňuje extrahovat soubory vložené do snímků jako OLE objekty tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) obsahující OLE objekty, které chcete extrahovat.
2. Projděte všechny tvary v prezentaci a přistupte k tvarům [OLEObjectFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/oleobjectframe).
3. Přistupte k datům vložených souborů z OLE rámců objektů a zapište je na disk.

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

### Bude OLE obsah vykreslen při exportu snímků do PDF/obrázků?

Co je na snímku viditelné, je vykresleno – ikona/náhradní obrázek (náhled). „Živý“ OLE obsah není při vykreslování prováděn. V případě potřeby nastavte vlastní náhledový obrázek, aby se v exportovaném PDF objevil očekávaný vzhled.

### Jak mohu zamknout OLE objekt na snímku, aby ho uživatelé nemohli přesouvat/editovat v PowerPointu?

Uzamkněte tvar: Aspose.Slides poskytuje zamykání na úrovni tvaru. Nejedná se o šifrování, ale efektivně zabraňuje nechtěným úpravám a přesunu.

### Proč se odkazovaný Excel objekt „přeskočí“ nebo změní velikost, když otevřu prezentaci?

PowerPoint může obnovit náhled odkazovaného OLE. Pro stabilní vzhled postupujte podle praktik [Working Solution for Worksheet Resizing](/slides/cs/androidjava/working-solution-for-worksheet-resizing/) – buď přizpůsobte rámec rozsahu, nebo škálujte rozsah na pevný rámec a nastavte vhodný náhradní obrázek.

### Zůstanou relativní cesty pro odkazované OLE objekty zachovány v formátu PPTX?

V PPTX není informace o „relativní cestě“ dostupná – pouze plná cesta. Relativní cesty jsou k dispozici ve starším formátu PPT. Pro přenositelnost upřednostněte spolehlivé absolutní cesty/přístupné URI nebo vkládání.