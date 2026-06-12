---
title: Správa OLE v prezentacích pomocí JavaScriptu
linktitle: Správa OLE
type: docs
weight: 40
url: /cs/nodejs-java/manage-ole/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Optimalizujte správu OLE objektů v PowerPoint a souborech OpenDocument pomocí Aspose.Slides pro Node.js via Java. Vkládejte, aktualizujte a exportujte OLE obsah hladce."
---
## **Úvod**

{{% alert color="primary" %}} 
OLE (Object Linking & Embedding) je technologie Microsoftu, která umožňuje data a objekty vytvořené v jedné aplikaci umístit do jiné aplikace pomocí propojení nebo vložení. 
{{% /alert %}} 

Uvažujme o grafu vytvořeném v MS Excel. Tento graf je následně umístěn do snímku PowerPointu. Tento graf z Excelu je považován za OLE objekt. 

- OLE objekt se může zobrazit jako ikona. V tom případě, když na ikonu dvojkliknete, graf se otevře v příslušné aplikaci (Excel), nebo budete vyzváni k výběru aplikace pro otevření či úpravu objektu. 
- OLE objekt může zobrazit svůj skutečný obsah, například obsah grafu. V tom případě je graf aktivován v PowerPointu, načte se rozhraní grafu a můžete upravovat data grafu přímo v PowerPointu.

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/cs/nodejs-java/) vám umožňuje vkládat OLE objekty do snímků jako OLE rámce objektů ([OleObjectFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/OleObjectFrame)).

## **Přidání OLE rámců objektů do snímků**

Předpokládejme, že jste již vytvořili graf v Microsoft Excel a chcete jej vložit do snímku jako OLE rámec objektu pomocí Aspose.Slides for Node.js via Java, můžete tak učinit následovně:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).  
2. Získejte referenci na snímek pomocí jeho indexu.  
3. Načtěte soubor Excel jako pole bytů.  
4. Přidejte [OleObjectFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/OleObjectFrame) do snímku s polem bytů a dalšími informacemi o OLE objektu.  
5. Uložte upravenou prezentaci jako soubor PPTX.  

V níže uvedeném příkladu jsme přidali graf ze souboru Excel do snímku jako OLE rámec objektu pomocí Aspose.Slides for Node.js via Java.  
**Poznámka** že konstruktor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/OleEmbeddedDataInfo) přijímá jako druhý parametr rozšíření vkladaného objektu. Toto rozšíření umožňuje PowerPointu správně rozpoznat typ souboru a vybrat správnou aplikaci pro otevření tohoto OLE objektu.

```javascript
var presentation = new asposeSlides.Presentation();
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(0);

// Připravte data pro OLE objekt.
var oleStream = fs.readFileSync("book.xlsx");
var fileData = Array.from(oleStream);
var dataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", fileData), "xlsx");

// Přidejte OLE rámec objektu do snímku.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

### **Přidání propojených OLE rámců objektů**

Aspose.Slides for Node.js via Java vám umožňuje přidat [OleObjectFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/OleObjectFrame) bez vkládání dat, pouze s odkazem na soubor.  

Tento JavaScriptový kód vám ukazuje, jak přidat [OleObjectFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/OleObjectFrame) s propojeným souborem Excel do snímku:

```javascript
var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

// Přidejte OLE rámec objektu s propojeným souborem Excel.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Přístup k OLE rámcům objektů**

Pokud je OLE objekt již vložen do snímku, můžete jej snadno najít nebo získat tímto způsobem:

1. Načtěte prezentaci s vloženým OLE objektem vytvořením instance třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).  
2. Získejte referenci na snímek pomocí jeho indexu.  
3. Získejte tvar [OleObjectFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/OleObjectFrame). V našem příkladu jsme použili dříve vytvořený PPTX, který má na prvním snímku pouze jeden tvar.  
4. Jakmile je OLE rámec objektu získán, můžete s ním provádět jakékoli operace.  

V níže uvedeném příkladu jsou získány OLE rámec objektu (graf Excel vložený do snímku) a jeho data souboru.

```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;
    
    // Získejte data vloženého souboru.
    // Získejte příponu vloženého souboru.
    // ...
}
```

### **Přístup k vlastnostem propojeného OLE rámce objektu**

Aspose.Slides vám umožňuje přistupovat k vlastnostem propojených OLE rámců objektů.  

Tento JavaScriptový kód vám ukazuje, jak zjistit, zda je OLE objekt propojen, a poté získat cestu k propojenému souboru:

```javascript
var presentation = new asposeSlides.Presentation("sample.ppt");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    // Zkontrolujte, zda je OLE objekt propojen.
    if (oleFrame.isObjectLink()) {
        // Vytiskněte úplnou cestu k propojenému souboru.
        console.log("OLE object frame is linked to:", oleFrame.getLinkPathLong());

        // Vytiskněte relativní cestu k propojenému souboru, pokud je k dispozici.
        // Pouze prezentace PPT mohou obsahovat relativní cestu.
        if (oleFrame.getLinkPathRelative() != null && oleFrame.getLinkPathRelative() != "") {
            console.log("OLE object frame relative path:", oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **Změna dat OLE objektu**

{{% alert color="primary" %}} 
V této sekci níže uvedený ukázkový kód používá [Aspose.Cells for Java](/cells/java/). 
{{% /alert %}} 

Pokud je OLE objekt již vložen do snímku, můžete jej snadno získat a modifikovat jeho data tímto způsobem:

1. Načtěte prezentaci s vloženým OLE objektem vytvořením instance třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).  
2. Získejte referenci na snímek pomocí jeho indexu.  
3. Získejte tvar OLE rámce objektu. V našem příkladu jsme použili dříve vytvořený PPTX, který má na prvním snímku jeden tvar.  
4. Jakmile je OLE rámec objektu získán, můžete s ním provádět jakékoli operace.  
5. Vytvořte objekt `Workbook` a získejte OLE data.  
6. Získejte požadovaný `Worksheet` a upravte data.  
7. Uložte aktualizovaný `Workbook` do proudu.  
8. Změňte data OLE objektu z proudu.  

V níže uvedeném příkladu je získán OLE rámec objektu (graf Excel vložený do snímku) a jeho data souboru jsou upravena tak, aby aktualizovala data grafu.

```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    var oleStream = java.newInstanceSync("java.io.ByteArrayInputStream", oleFrame.getEmbeddedData().getEmbeddedFileData());

    // Přečtěte data OLE objektu jako objekt Workbook.
    var workbook = java.newInstanceSync("Workbook", oleStream);

    var newOleStream = java.newInstanceSync("java.io.ByteArrayOutputStream");

    // Upravte data sešitu.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    var fileOptions = java.newInstanceSync("OoxmlSaveOptions", java.getStaticFieldValue("com.aspose.cells.SaveFormat", "XLSX"));
    workbook.save(newOleStream, fileOptions);

    // Změňte data objektu OLE rámce.
    var newData = new asposeSlides.OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);

    newOleStream.close();
    oleStream.close();
}

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Vkládání dalších typů souborů do snímků**

Kromě grafů Excel vám Aspose.Slides for Node.js via Java umožňuje vložit do snímků i další typy souborů. Například můžete vložit soubory HTML, PDF a ZIP jako objekty. Když uživatel dvojklikne na vložený objekt, automaticky se otevře v příslušném programu nebo je uživatel vyzván k výběru vhodného programu pro jeho otevření.  

Tento JavaScriptový kód vám ukazuje, jak vložit HTML a ZIP do snímku:

```javascript
var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

var htmlBuffer = fs.readFileSync("sample.html");
var htmlData = Array.from(htmlBuffer);
var htmlDataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", htmlData), "html");
var htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

var zipBuffer = fs.readFileSync("sample.zip");
var zipData = Array.from(zipBuffer);
var zipDataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", zipData), "zip");
var zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Nastavení typů souborů pro vložené objekty**

Při práci s prezentacemi může být potřeba nahradit staré OLE objekty novými nebo nahradit nepodporovaný OLE objekt podporovaným. Aspose.Slides for Node.js via Java vám umožňuje nastavit typ souboru pro vložený objekt, což umožňuje aktualizovat data OLE rámce nebo jeho příponu.  

Tento JavaScriptový kód vám ukazuje, jak nastavit typ souboru pro vložený OLE objekt na `zip`:

```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
var oleFileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

console.log("Current embedded file extension is:", fileExtension);

// Změňte typ souboru na ZIP.
var fileData = java.newArray("byte", Array.from(oleFileData));
oleFrame.setEmbeddedData(new asposeSlides.OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Nastavení ikonových obrázků a názvů pro vložené objekty**

Po vložení OLE objektu se automaticky přidá náhled sestávající z ikony. Tento náhled vidí uživatelé před přístupem nebo otevřením OLE objektu. Pokud chcete použít konkrétní obrázek a text jako prvky náhledu, můžete nastavit ikonu a název pomocí Aspose.Slides for Node.js via Java.  

Tento JavaScriptový kód vám ukazuje, jak nastavit ikonu a název pro vložený objekt:

```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

// Přidejte obrázek do zdrojů prezentace.
var image = asposeSlides.Images.fromFile("image.png");
var oleImage = presentation.getImages().addImage(image);
image.dispose();

// Nastavte název a obrázek pro náhled OLE.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Zabránění změně velikosti a pozice OLE rámce objektu**

Po přidání propojeného OLE objektu do snímku prezentace, když otevřete prezentaci v PowerPointu, můžete obdržet zprávu s výzvou k aktualizaci odkazů. Kliknutí na tlačítko „Update Links“ může změnit velikost a pozici OLE rámce objektu, protože PowerPoint aktualizuje data z propojeného OLE objektu a obnoví náhled objektu. Chcete‑li zabránit výzvě PowerPointu k aktualizaci dat objektu, použijte metodu `setUpdateAutomatic` třídy [OleObjectFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/oleobjectframe/) s hodnotou `false`:

```javascript
oleFrame.setUpdateAutomatic(false);
```

## **Extrahování vložených souborů**

Aspose.Slides for Node.js via Java vám umožňuje extrahovat soubory vložené do snímků jako OLE objekty tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation) obsahující OLE objekty, které chcete extrahovat.  
2. Procházejte všechny tvary v prezentaci a přistupujte k tvarům [OLEObjectFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/oleobjectframe).  
3. Získejte data vložených souborů z OLE rámců objektů a zapište je na disk.  

Tento JavaScriptový kód vám ukazuje, jak extrahovat soubory vložené do snímku jako OLE objekty:

```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);

for (var index = 0; index < slide.getShapes().size(); index++) {
    var shape = slide.getShapes().get_Item(index);

    if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
        var oleFrame = shape;

        var fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        var filePath = "OLE_object_" + index + fileExtension;
        fs.writeFileSync(filePath, Buffer.from(fileData));
    }
}

presentation.dispose();
```

## **Často kladené otázky**

**Bude OLE obsah vykreslen při exportu snímků do PDF/obrázků?**  
To, co je na snímku viditelné, je vykresleno – ikona/náhradní obrázek (náhled). „Živý“ OLE obsah není při vykreslování spuštěn. V případě potřeby nastavte vlastní obrázek náhledu, aby se v exportovaném PDF zobrazoval očekávaný vzhled.

**Jak mohu zamknout OLE objekt na snímku, aby jej uživatelé nemohli v PowerPointu přesouvat/upravovat?**  
Zamkněte tvar: Aspose.Slides poskytuje zamykání na úrovni tvaru. Nejde o šifrování, ale účinně zabraňuje nechtěným úpravám a přesunu.

**Zůstanou relativní cesty pro propojené OLE objekty zachovány ve formátu PPTX?**  
Ve formátu PPTX informace o „relativní cestě“ nejsou k dispozici – pouze úplná cesta. Relativní cesty se vyskytují ve starším formátu PPT. Pro přenositelnost upřednostněte spolehlivé absolutní cesty/přístupné URI nebo vkládání.