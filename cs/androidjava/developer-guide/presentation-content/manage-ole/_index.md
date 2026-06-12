---
title: Správa OLE v prezentacích na Androidu
linktitle: Spravovat OLE
type: docs
weight: 40
url: /cs/androidjava/manage-ole/
keywords:
- OLE objekt
- Propojení a vložení objektu
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
description: "Optimalizujte správu OLE objektů v souborech PowerPoint a OpenDocument pomocí Aspose.Slides pro Android pomocí Javy. Vkládejte, aktualizujte a exportujte OLE obsah bez problémů."
---
## **Úvod**

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) je technologie společnosti Microsoft, která umožňuje umístit data a objekty vytvořené v jedné aplikaci do jiné aplikace pomocí odkazu nebo vložení. 

{{% /alert %}} 

Představte si graf vytvořený v MS Excel. Ten je poté umístěn na snímek PowerPointu. Tento excelový graf se považuje za OLE objekt. 

- OLE objekt se může zobrazovat jako ikona. V tomto případě při dvojitém kliknutí na ikonu otevře graf v přidružené aplikaci (Excel) nebo se zobrazí výzva k výběru aplikace pro otevření či úpravu objektu. 
- OLE objekt může zobrazovat svůj skutečný obsah, například obsah grafu. V tomto případě se graf aktivuje v PowerPointu, načte se rozhraní grafu a můžete upravovat data grafu přímo v PowerPointu.

[Aspose.Slides pro Android pomocí Java](https://products.aspose.com/slides/cs/androidjava/) umožňuje vkládat OLE objekty do snímků jako OLE objektové rámy ([OleObjectFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/OleObjectFrame)).

## **Přidání OLE objektových rámců do snímků**

Předpokládejme, že jste již vytvořili graf v Microsoft Excel a chcete jej vložit do snímku jako OLE objektový rámec pomocí Aspose.Slides pro Android pomocí Java. Můžete to udělat takto:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation). 
2. Získejte odkaz na snímek podle jeho indexu. 
3. Načtěte soubor Excel jako pole bajtů. 
4. Přidejte [OleObjectFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/OleObjectFrame) na snímek s polem bajtů a dalšími informacemi o OLE objektu. 
5. Uložte upravenou prezentaci jako soubor PPTX. 

V níže uvedeném příkladu jsme přidali graf ze souboru Excel na snímek jako OLE objektový rámec pomocí Aspose.Slides pro Android pomocí Java.  
**Poznámka** že konstruktor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/OleEmbeddedDataInfo) přijímá rozšíření vkládaného objektu jako druhý parametr. Toto rozšíření umožňuje PowerPointu správně interpretovat typ souboru a zvolit správnou aplikaci pro otevření tohoto OLE objektu.

```java 
Presentation presentation = new Presentation();
SizeF slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Připravit data pro OLE objekt.
File file = new File("book.xlsx");
byte fileData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(fileData);

IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Přidat OLE objektový rámec do snímku.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Přidání propojených OLE objektových rámců**

Aspose.Slides pro Android pomocí Java umožňuje přidat [OleObjectFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/OleObjectFrame) bez vkládání dat, pouze s odkazem na soubor.

Tento Java kód ukazuje, jak přidat [OleObjectFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/OleObjectFrame) s propojeným souborem Excel na snímek:

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Přidat OLE objektový rámec s propojeným souborem Excel.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Přístup k OLE objektovým rámcům**

Pokud je OLE objekt již vložený do snímku, můžete jej snadno najít nebo získat přístup takto:

1. Načtěte prezentaci s vloženým OLE objektem vytvořením instance třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation). 
2. Získejte odkaz na snímek pomocí jeho indexu. 
3. Získejte tvar [OleObjectFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/OleObjectFrame).  
   V našem příkladu jsme použili dříve vytvořený PPTX, který má na prvním snímku pouze jeden tvar. Tento objekt jsme pak *přetypovali* na [IOleObjectFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ioleobjectframe/). To byl požadovaný OLE objektový rámec, ke kterému jsme chtěli přistoupit. 
4. Jakmile je OLE objektový rámec získán, můžete nad ním provádět libovolnou operaci. 

V níže uvedeném příkladu jsou přístup k OLE objektovému rámci (objekt grafu Excel vložený do snímku) a k jeho souborovým datům.

```java 
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

### **Přístup k vlastnostem propojeného OLE objektového rámce**

Aspose.Slides umožňuje přístup k vlastnostem propojeného OLE objektového rámce.

Tento Java kód ukazuje, jak zjistit, zda je OLE objekt propojený, a potom získat cestu k propojenému souboru:

```java
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

{{% alert color="primary" %}} 

V této sekci ukázkový kód níže používá [Aspose.Cells pro Android pomocí Java](/cells/androidjava/). 

{{% /alert %}}

Pokud je OLE objekt již vložený do snímku, můžete k němu snadno přistoupit a upravit jeho data takto:

1. Načtěte prezentaci s vloženým OLE objektem vytvořením instance třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation). 
2. Získejte odkaz na snímek podle jeho indexu. 
3. Získejte tvar OLE objektového rámce.  
   V našem příkladu jsme použili dříve vytvořený PPTX, který má na prvním snímku jeden tvar. Tento objekt jsme pak *přetypovali* na [IOleObjectFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ioleobjectframe/). To byl požadovaný OLE objektový rámec, ke kterému jsme chtěli přistoupit. 
4. Jakmile je OLE objektový rámec získán, můžete nad ním provádět libovolnou operaci. 
5. Vytvořte objekt `Workbook` a získejte přístup k OLE datům. 
6. Získejte požadovaný `Worksheet` a upravte data. 
7. Uložte aktualizovaný `Workbook` do proudu. 
8. Změňte data OLE objektu z proudu. 

V níže uvedeném příkladu je přístup k OLE objektovému rámci (objekt grafu Excel vložený do snímku) a souborová data jsou upravena tak, aby aktualizovala data grafu.

```java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    ByteArrayInputStream oleStream = new ByteArrayInputStream(oleFrame.getEmbeddedData().getEmbeddedFileData());

    // Přečíst data OLE objektu jako objekt Workbook.
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // Upravit data sešitu.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
    workbook.save(newOleStream, fileOptions);

    // Změnit data objektu OLE rámce.
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Vložení dalších typů souborů do snímků**

Kromě excelových grafů Aspose.Slides pro Android pomocí Java umožňuje vložit do snímků i další typy souborů. Například můžete vložit HTML, PDF a ZIP soubory jako objekty. Když uživatel dvojklikne na vložený objekt, automaticky se otevře v příslušném programu nebo je uživateli nabídnuta možnost vybrat vhodný program pro otevření.

Tento Java kód ukazuje, jak vložit HTML a ZIP do snímku:

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

## **Nastavení typů souborů pro vložené objekty**

Při práci s prezentacemi můžete potřebovat nahradit staré OLE objekty novými nebo nahradit nepodporovaný OLE objekt podporovaným. Aspose.Slides pro Android pomocí Java umožňuje nastavit typ souboru pro vložený objekt, což vám umožní aktualizovat data rámce OLE nebo jeho rozšíření.

Tento Java kód ukazuje, jak nastavit typ souboru pro vložený OLE objekt na `zip`:

```java
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

Po vložení OLE objektu je automaticky přidáno náhledové zobrazení sestávající z ikony. Tento náhled vidí uživatelé před tím, než objekt otevřou. Pokud chcete v náhledu použít konkrétní obrázek a text, můžete pomocí Aspose.Slides pro Android pomocí Java nastavit obrázek ikony a titulek.

Tento Java kód ukazuje, jak nastavit obrázek ikony a titulek pro vložený objekt:

```java
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

// Nastavit titulek a obrázek pro náhled OLE.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Zabránit změně velikosti a pozice OLE objektového rámce**

Po přidání propojeného OLE objektu do snímku prezentace se při otevření v PowerPointu může zobrazit výzva k aktualizaci odkazů. Kliknutí na tlačítko „Aktualizovat odkazy“ může změnit velikost a umístění OLE objektového rámce, protože PowerPoint aktualizuje data z propojeného OLE objektu a obnoví náhled. Chcete‑li zabránit výzvě k aktualizaci dat objektu, nastavte metodě `setUpdateAutomatic` rozhraní [IOleObjectFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ioleobjectframe/) hodnotu `false`:

```java
oleFrame.setUpdateAutomatic(false);
```

## **Extrahování vložených souborů**

Aspose.Slides pro Android pomocí Java umožňuje extrahovat soubory vložené do snímků jako OLE objekty takto:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) obsahující OLE objekty, které chcete extrahovat. 
2. Projděte všechny tvary v prezentaci a získejte tvary typu [OLEObjectFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/oleobjectframe). 
3. Získejte data vložených souborů z OLE objektových rámců a zapište je na disk. 

Tento Java kód ukazuje, jak extrahovat soubory vložené do snímku jako OLE objekty:

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

## **FAQ**

**Bude OLE obsah vykreslen při exportu snímků do PDF/obrázků?**

To, co je viditelné na snímku, se vykreslí – ikona/náhradní obrázek (náhled). „Živý“ OLE obsah není při vykreslování prováděn. V případě potřeby nastavte vlastní náhledový obrázek, aby exportovaný PDF vypadal podle očekávání.

**Jak mohu zamknout OLE objekt na snímku, aby jej uživatelé nemohli v PowerPointu přesouvat nebo upravovat?**

Uzamkněte tvar: Aspose.Slides poskytuje zamykání na úrovni tvaru. Nejde o šifrování, ale efektivně zabraňuje neúmyslným úpravám a přesunu.

**Proč se propojený Excel objekt „přeskočí“ nebo změní velikost, když otevřu prezentaci?**

PowerPoint může obnovit náhled propojeného OLE. Pro stabilní vzhled použijte osvědčená řešení popsaná v [Working Solution for Worksheet Resizing](/slides/cs/androidjava/working-solution-for-worksheet-resizing/) – buď přizpůsobte rámec rozsahu, nebo škálujte rozsah na pevný rámec a nastavte vhodný náhradní obrázek.

**Budou relativní cesty pro propojené OLE objekty zachovány ve formátu PPTX?**

V PPTX není informace o „relativní cestě“ k dispozici – uložená je pouze úplná cesta. Relativní cesty se vyskytují ve starším formátu PPT. Pro přenositelnost upřednostněte spolehlivé absolutní cesty/nebo přístupné URI nebo vložení.