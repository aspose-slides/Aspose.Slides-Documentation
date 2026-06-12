---
title: Správa OLE v prezentacích pomocí Javy
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
description: "Optimalizujte správu OLE objektů v PowerPointu a souborech OpenDocument pomocí Aspose.Slides pro Javu. Vkládejte, aktualizujte a exportujte OLE obsah bez problémů."
---
## **Úvod**

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) je technologie Microsoftu, která umožňuje data a objekty vytvořené v jedné aplikaci umístit do jiné aplikace pomocí odkazování nebo vložení. 

{{% /alert %}} 

Uvažujme o grafu vytvořeném v MS Excel. Tento graf je poté umístěn do snímku PowerPointu. Tento graf z Excelu se považuje za OLE objekt. 

- OLE objekt se může zobrazit jako ikona. V takovém případě, když na ikonu dvakrát kliknete, graf se otevře v přidružené aplikaci (Excel), nebo budete vyzváni k výběru aplikace pro otevření nebo úpravu objektu. 
- OLE objekt může zobrazit svůj skutečný obsah, například obsah grafu. V takovém případě je graf aktivován v PowerPointu, načte se rozhraní grafu a můžete upravovat data grafu přímo v PowerPointu.

[Aspose.Slides for Java](https://products.aspose.com/slides/cs/java/) vám umožňuje vkládat OLE objekty do snímků jako OLE rámy objektů ([OleObjectFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/OleObjectFrame)).

## **Přidání OLE rámců objektů do snímků**

Pokud jste již vytvořili graf v Microsoft Excel a chcete jej vložit do snímku jako OLE rámec objektu pomocí Aspose.Slides for Java, můžete tak učinit tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation) .
1. Získejte odkaz na snímek pomocí jeho indexu.
1. Načtěte soubor Excel jako pole bajtů.
1. Přidejte [OleObjectFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/OleObjectFrame) do snímku, který obsahuje pole bajtů a další informace o OLE objektu.
1. Zapište upravenou prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme přidali graf ze souboru Excel do snímku jako OLE rámec objektu pomocí Aspose.Slides for Java. **Poznámka** že konstruktor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/cs/java/com.aspose.slides/OleEmbeddedDataInfo) přijímá rozšíření vkládatelného objektu jako druhý parametr. Toto rozšíření umožňuje PowerPointu správně interpretovat typ souboru a vybrat správnou aplikaci pro otevření tohoto OLE objektu.

``` java 
Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Připravte data pro OLE objekt.
byte[] fileData = Files.readAllBytes(Paths.get("book.xlsx"));
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Přidejte OLE rámec objektu do snímku.
slide.getShapes().addOleObjectFrame(0, 0, (float)slideSize.getWidth(), (float)slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Přidání propojených OLE rámců objektů**

Aspose.Slides for Java vám umožňuje přidat [OleObjectFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/OleObjectFrame), aniž byste vkládali data, pouze s odkazem na soubor.

Tento Java kód ukazuje, jak přidat [OleObjectFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/OleObjectFrame) s propojeným souborem Excel do snímku:

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Přidejte OLE rámec objektu s propojeným souborem Excel.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Přístup k OLE rámcům objektů**

Pokud je OLE objekt již vložen do snímku, můžete jej snadno najít nebo získat přístup tímto způsobem:

1. Načtěte prezentaci s vloženým OLE objektem vytvořením instance třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation) .
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Získejte přístup k tvaru [OleObjectFrame]. V našem příkladu jsme použili dříve vytvořený PPTX, který má na prvním snímku pouze jeden tvar. Poté jsme tento objekt *přetypovali* na [IOleObjectFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IOleObjectFrame). Toto byl požadovaný OLE rámec objektu, ke kterému jsme chtěli přistupovat.
4. Jakmile získáte přístup k OLE rámci objektu, můžete na něm provádět libovolné operace.

V níže uvedeném příkladu je přístup k OLE rámci objektu (objektu Excel grafu vloženému do snímku) a jeho datům souboru.

``` java 
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

### **Přístup k vlastnostem propojeného OLE rámce objektu**

Aspose.Slides vám umožňuje přistupovat k vlastnostem propojených OLE rámců objektů.

Tento Java kód ukazuje, jak zjistit, zda je OLE objekt propojen, a následně získat cestu k propojenému souboru:

```java
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

{{% alert color="primary" %}} 

V této sekci níže uvedený příklad kódu používá [Aspose.Cells for Java](/cells/java/).

{{% /alert %}}

Pokud je OLE objekt již vložen do snímku, můžete k němu snadno přistoupit a jeho data upravit tímto způsobem:

1. Načtěte prezentaci s vloženým OLE objektem vytvořením instance třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation) .
2. Získejte odkaz na snímek pomocí jeho indexu. 
3. Získejte přístup k tvaru OLE objektu. V našem příkladu jsme použili dříve vytvořený PPTX, který má na prvním snímku jeden tvar. Poté jsme tento objekt *přetypovali* na [IOleObjectFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IOleObjectFrame). Toto byl požadovaný OLE rámec objektu, ke kterému jsme chtěli přistupovat.
4. Jakmile získáte přístup k OLE rámci objektu, můžete na něm provádět libovolné operace.
5. Vytvořte objekt `Workbook` a přistupujte k OLE datům.
6. Získejte požadovaný `Worksheet` a upravte data.
7. Uložte aktualizovaný `Workbook` do proudu.
8. Změňte data OLE objektu z proudu.

V níže uvedeném příkladu je přístup k OLE rámci objektu (objektu Excel grafu vloženému do snímku) a data jeho souboru jsou upravena pro aktualizaci dat grafu.

``` java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    ByteArrayInputStream oleStream = new ByteArrayInputStream(oleFrame.getEmbeddedData().getEmbeddedFileData());

    // Načtěte data OLE objektu jako objekt Workbook.
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // Upravte data sešitu.
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

## **Vkládání jiných typů souborů do snímků**

Kromě grafů Excel vám Aspose.Slides for Java umožňuje vkládat do snímků i jiné typy souborů. Například můžete vložit soubory HTML, PDF a ZIP jako objekty. Když uživatel dvakrát klikne na vložený objekt, automaticky se otevře v příslušném programu, nebo je uživatel vyzván k výběru vhodného programu pro jeho otevření.

Tento Java kód ukazuje, jak vložit HTML a ZIP do snímku:

```java
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

Při práci s prezentacemi může být potřeba nahradit staré OLE objekty novými nebo nahradit nepodporovaný OLE objekt podporovaným. Aspose.Slides for Java vám umožňuje nastavit typ souboru pro vložený objekt, což umožňuje aktualizovat data OLE rámce nebo jeho příponu.

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

Po vložení OLE objektu je automaticky přidáno náhledové zobrazení skládající se z obrázku ikony. Tento náhled vidí uživatelé před přístupem nebo otevřením OLE objektu. Pokud chcete použít konkrétní obrázek a text jako prvky v náhledu, můžete nastavit obrázek ikony a titulek pomocí Aspose.Slides for Java.

Tento Java kód ukazuje, jak nastavit obrázek ikony a titulek pro vložený objekt:

```java
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

## **Zabránit změně velikosti a přesunutí OLE rámce objektu**

Po přidání propojeného OLE objektu do snímku prezentace, když otevřete prezentaci v PowerPointu, můžete vidět zprávu s dotazem na aktualizaci odkazů. Kliknutí na tlačítko „Update Links“ může změnit velikost a pozici OLE rámce objektu, protože PowerPoint aktualizuje data z propojeného OLE objektu a obnoví náhled objektu. Pro zabránění výzvě PowerPointu k aktualizaci dat objektu nastavte metodu `setUpdateAutomatic` rozhraní [IOleObjectFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ioleobjectframe/) na `false`:

```java
oleFrame.setUpdateAutomatic(false);
```

## **Extrahování vložených souborů**

Aspose.Slides for Java vám umožňuje extrahovat soubory vložené do snímků jako OLE objekty tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation) obsahující OLE objekty, které chcete extrahovat.
2. Projděte všechny tvary v prezentaci a přistupujte k tvarům [OLEObjectFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/oleobjectframe).
3. Získávejte data vložených souborů z OLE rámců objektů a zapište je na disk.

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

        Path filePath = Paths.get("OLE_object_" + index + fileExtension);
        Files.write(filePath, fileData);
    }
}

presentation.dispose();
```

## **FAQ**

**Bude OLE obsah vykreslen při exportu snímků do PDF/obrázků?**

Co je viditelné na snímku, se vykreslí – ikona/náhradní obrázek (náhled). „Živý“ OLE obsah není během vykreslování spouštěn. V případě potřeby nastavte vlastní náhledový obrázek, aby byl v exportovaném PDF očekávaný vzhled.

**Jak mohu uzamknout OLE objekt na snímku, aby jej uživatelé nemohli v PowerPointu přesouvat/upravovat?**

Uzamkněte tvar: Aspose.Slides poskytuje [zámky na úrovni tvaru](/slides/cs/java/applying-protection-to-presentation/). Není to šifrování, ale účinně zabraňuje neúmyslným úpravám a přesunutí.

**Proč se propojený Excel objekt „přeskočí“ nebo změní velikost, když otevřu prezentaci?**

PowerPoint může aktualizovat náhled propojeného OLE. Pro stabilní vzhled postupujte podle doporučení [Working Solution for Worksheet Resizing](/slides/cs/java/working-solution-for-worksheet-resizing/) – buď přizpůsobte rámec rozsahu, nebo škálujte rozsah na pevný rámec a nastavte vhodný náhradní obrázek.

**Zůstanou relativní cesty pro propojené OLE objekty zachovány ve formátu PPTX?**

V PPTX není informace o „relativní cestě“ k dispozici – pouze úplná cesta. Relativní cesty jsou součástí staršího formátu PPT. Pro přenositelnost upřednostněte spolehlivé absolutní cesty/přístupné URI nebo vkládání.