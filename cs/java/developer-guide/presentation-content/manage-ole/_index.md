---
title: Správa OLE v prezentacích pomocí Javy
linktitle: Správa OLE
type: docs
weight: 40
url: /cs/java/manage-ole/
keywords:
- OLE objekt
- Propojování a vkládání objektů
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
description: "Optimalizujte správu OLE objektů v PowerPoint a souborech OpenDocument pomocí Aspose.Slides pro Javu. Vkládejte, aktualizujte a exportujte OLE obsah bez obtíží."
---
## **Úvod**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) je technologie společnosti Microsoft, která umožňuje umístit data a objekty vytvořené v jedné aplikaci do jiné aplikace prostřednictvím propojení nebo vložení. 

{{% /alert %}} 

Zvažte graf vytvořený v MS Excel. Tento graf je následně umístěn do snímku PowerPointu. Tento Excel graf je považován za OLE objekt. 

- OLE objekt se může zobrazovat jako ikona. V tomto případě při dvojkliku na ikonu se graf otevře v jeho přiřazené aplikaci (Excel) nebo budete vyzváni vybrat aplikaci pro otevření či úpravu objektu.
- OLE objekt může zobrazovat svůj skutečný obsah, například obsah grafu. V tomto případě se graf aktivuje v PowerPointu, načte se rozhraní grafu a můžete upravovat data grafu přímo v PowerPointu.

[Aspose.Slides for Java](https://products.aspose.com/slides/java/) vám umožňuje vkládat OLE objekty do snímků jako rámy OLE objektů ([OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame)).

## **Přidání rámců OLE objektů do snímků**

Předpokládejme, že jste již vytvořili graf v Microsoft Excel a chcete jej vložit do snímku jako rám OLE objektu pomocí Aspose.Slides for Java, můžete to provést takto:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
1. Získejte odkaz na snímek pomocí jeho indexu.
1. Přečtěte soubor Excel jako pole bajtů.
1. Přidejte [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) do snímku s polem bajtů a dalšími informacemi o OLE objektu.
1. Uložte upravenou prezentaci jako soubor PPTX.

V následujícím příkladu jsme přidali graf ze souboru Excel do snímku jako rám OLE objektu pomocí Aspose.Slides for Java.
**Poznámka** že konstruktor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/OleEmbeddedDataInfo) přijímá rozšíření vložitelného objektu jako druhý parametr. Toto rozšíření umožňuje PowerPointu správně interpretovat typ souboru a vybrat správnou aplikaci pro otevření tohoto OLE objektu.

``` java 
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Připravte data pro OLE objekt.
byte[] fileData = Files.readAllBytes(Paths.get("book.xlsx"));
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Přidejte rám OLE objektu do snímku.
slide.getShapes().addOleObjectFrame(0, 0, (float)slideSize.getWidth(), (float)slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Přidání propojených rámců OLE objektů**

Aspose.Slides for Java vám umožňuje přidat [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) bez vložení dat, ale pouze s odkazem na soubor.

Tento Java kód ukazuje, jak přidat [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) s propojeným souborem Excel do snímku:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Přidejte rám OLE objektu s propojeným souborem Excel.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Přístup k rámcům OLE objektů**

Pokud je OLE objekt již vložený do snímku, můžete jej snadno najít nebo k nímu získat přístup tímto způsobem:

1. Načtěte prezentaci s vloženým OLE objektem vytvořením instance třídy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Získejte tvar [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame).
   V našem příkladu jsme použili dříve vytvořený PPTX, který má na prvním snímku pouze jeden tvar. Poté jsme tento objekt *přetypovali* na [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IOleObjectFrame). To byl požadovaný rám OLE objektu, ke kterému jsme chtěli získat přístup.
4. Jakmile získáte přístup k rámu OLE objektu, můžete na něm provádět libovolné operace.

V níže uvedeném příkladu jsou přístupny rám OLE objektu (Excel graf vložený do snímku) a data jeho souboru.

``` java 
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

### **Přístup k vlastnostem propojeného rámu OLE objektu**

Aspose.Slides vám umožňuje přistupovat k vlastnostem propojených rámů OLE objektů.

Tento Java kód ukazuje, jak zkontrolovat, zda je OLE objekt propojený, a poté získat cestu k propojenému souboru:

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

{{% alert color="info" title="Note" %}}

V této sekci níže uvedený ukázkový kód používá [Aspose.Cells for Java](https://docs.aspose.com/cells/java/).

{{% /alert %}}

Pokud je OLE objekt již vložený do snímku, můžete k tomuto objektu snadno přistoupit a upravit jeho data tímto způsobem:

1. Načtěte prezentaci s vloženým OLE objektem vytvořením instance třídy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
2. Získejte odkaz na snímek pomocí jeho indexu. 
3. Získejte tvar rámu OLE objektu.
   V našem příkladu jsme použili dříve vytvořený PPTX, který má na prvním snímku jeden tvar. Poté jsme tento objekt *přetypovali* na [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IOleObjectFrame). To byl požadovaný rám OLE objektu, ke kterému jsme chtěli získat přístup.
4. Jakmile získáte přístup k rámu OLE objektu, můžete na něm provádět libovolné operace.
5. Vytvořte objekt `Workbook` a přistupte k OLE datům.
6. Přístupte k požadovanému `Worksheet` a upravte data.
7. Uložte aktualizovaný `Workbook` do proudu.
8. Změňte data OLE objektu z proudu.

V níže uvedeném příkladu je přístup k rámu OLE objektu (Excel graf vložený do snímku) a jsou upravena data jeho souboru.

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

    // Změnit data objektu rámu OLE.
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Vkládání jiných typů souborů do snímků**

Kromě Excel grafů vám Aspose.Slides for Java umožňuje vložit do snímků i jiné typy souborů. Například můžete vkládat HTML, PDF a ZIP soubory jako objekty. Když uživatel dvojklikne na vložený objekt, automaticky se otevře ve příslušném programu nebo je uživatel vyzván vybrat vhodný program pro jeho otevření.

Tento Java kód ukazuje, jak vložit HTML a ZIP do snímku:

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

Při práci s prezentacemi můžete potřebovat nahradit staré OLE objekty novými nebo nahradit nepodporovaný OLE objekt podporovaným. Aspose.Slides for Java vám umožňuje nastavit typ souboru pro vložený objekt, což vám umožní aktualizovat data rámu OLE nebo jeho rozšíření.

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

## **Nastavení ikonových obrázků a titulků pro vložené objekty**

Po vložení OLE objektu je automaticky přidáno náhledové zobrazení sestávající z ikonového obrázku. Tento náhled vidí uživatelé před přístupem nebo otevřením OLE objektu. Pokud chcete použít konkrétní obrázek a text jako součást náhledu, můžete pomocí Aspose.Slides for Java nastavit ikonový obrázek a titulek.

Tento Java kód ukazuje, jak nastavit ikonový obrázek a titulek pro vložený objekt:

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

// Nastavte název a obrázek pro náhled OLE.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Zabránění změny velikosti a pozice rámu OLE objektu**

Po přidání propojeného OLE objektu do snímku prezentace se při otevření prezentace v PowerPointu může zobrazit zpráva s výzvou k aktualizaci odkazů. Kliknutím na tlačítko „Update Links“ se může změnit velikost a pozice rámu OLE objektu, protože PowerPoint aktualizuje data z propojeného OLE objektu a obnovuje náhled objektu. Chcete‑li zabránit výzvě PowerPointu k aktualizaci dat objektu, zavolejte metodu [setUpdateAutomatic](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#setUpdateAutomatic-boolean-) rozhraní [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/) s hodnotou `false`:

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

Aspose.Slides for Java vám umožňuje extrahovat soubory vložené do snímků jako OLE objekty tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) obsahující OLE objekty, které chcete extrahovat.
2. Projděte všechny tvary v prezentaci a přistupte k tvarům [OLEObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/oleobjectframe).
3. Získejte data vložených souborů z rámů OLE objektů a zapište je na disk.

Tento Java kód ukazuje, jak extrahovat soubory vložené do snímku jako OLE objekty:

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

## **FAQ**

**Bude OLE obsah vykreslen při exportu snímků do PDF/obrázků?**

To, co je viditelné na snímku, se vykreslí – ikona/náhradní obrázek (náhled). „Živý“ OLE obsah se během vykreslování nespouští. V případě potřeby si nastavte vlastní náhledový obrázek, aby se zajistil očekávaný vzhled v exportovaném PDF.

Chcete‑li také zachovat vložený soubor jako přílohu PDF, zavolejte [setIncludeOleData](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) s hodnotou `true`. Tato volba je ve výchozím nastavení zakázána. Pro příklad a instrukce k ověření přílohy viz [Preserve Embedded OLE Files as PDF Attachments](/slides/cs/java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Jak mohu uzamknout OLE objekt na snímku, aby jej uživatelé nemohli v PowerPointu přesouvat/upravovat?**

Uzamkněte tvar: Aspose.Slides poskytuje [shape-level locks](/slides/cs/java/applying-protection-to-presentation/). Nejde o šifrování, ale účinně zabraňuje neúmyslným úpravám a pohybu.

**Proč se propojený Excel objekt „přeskakuje“ nebo mění velikost, když otevřu prezentaci?**

PowerPoint může obnovit náhled propojeného OLE. Pro stabilní vzhled postupujte podle [Working Solution for Worksheet Resizing](/slides/cs/java/working-solution-for-worksheet-resizing/) – buď přizpůsobte rám rozsahu, nebo škálujte rozsah do pevného rámu a nastavte vhodný náhradní obrázek.

**Budou v formátu PPTX zachovány relativní cesty k propojeným OLE objektům?**

V PPTX není informace o „relativní cestě“ dostupná – pouze úplná cesta. Relativní cesty se vyskytují ve starším formátu PPT. Pro přenositelnost upřednostněte spolehlivé absolutní cesty/přístupné URI nebo vložení.