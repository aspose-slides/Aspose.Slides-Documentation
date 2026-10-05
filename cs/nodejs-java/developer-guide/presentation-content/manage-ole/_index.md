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
- titulek OLE
- extrahovat OLE
- extrahovat objekt
- extrahovat soubor
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Optimalizujte správu OLE objektů v souborech PowerPoint a OpenDocument pomocí Aspose.Slides pro Node.js přes Java. Vkládejte, aktualizujte a exportujte OLE obsah bez problémů."
---
## **Úvod**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) je technologie společnosti Microsoft, která umožňuje umístit data a objekty vytvořené v jedné aplikaci do jiné aplikace pomocí propojení nebo vložení. 

{{% /alert %}} 

Zvažte graf vytvořený v MS Excel. Tento graf je následně umístěn na snímek PowerPointu. Tento Excel graf je považován za OLE objekt. 

- OLE objekt se může zobrazovat jako ikona. V tomto případě, když poklepete na ikonu, graf se otevře v přidružené aplikaci (Excel), nebo budete vyzváni k výběru aplikace pro otevření či úpravu objektu.
- OLE objekt může zobrazovat svůj skutečný obsah, například obsah grafu. V tomto případě je graf aktivován v PowerPointu, načte se rozhraní grafu a můžete upravovat data grafu přímo v PowerPointu.

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/nodejs-java/) umožňuje vkládat OLE objekty do snímků jako OLE rámy objektů ([OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame)).

## **Přidání OLE rámců objektů do snímků**

Předpokládejme, že jste již vytvořili graf v Microsoft Excel a chcete jej vložit do snímku jako OLE rámec objektu pomocí Aspose.Slides for Node.js via Java, můžete to provést následovně:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) .
1. Získejte odkaz na snímek pomocí jeho indexu.
1. Přečtěte soubor Excel jako pole bajtů.
1. Přidejte [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) do snímku s polem bajtů a dalšími informacemi o OLE objektu.
1. Uložte upravenou prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme do snímku přidali graf ze souboru Excel jako OLE rámec objektu pomocí Aspose.Slides for Node.js via Java.
**Poznámka**: konstruktor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleEmbeddedDataInfo) přijímá jako druhý parametr příponu vkládaného objektu. Tato přípona umožňuje PowerPointu správně interpretovat typ souboru a vybrat správnou aplikaci pro otevření tohoto OLE objektu.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

var presentation = new asposeSlides.Presentation();
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(0);

// Prepare data for the OLE object.
var oleStream = fs.readFileSync("book.xlsx");
var fileData = Array.from(oleStream);
var dataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", fileData), "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

### **Přidání propojených OLE rámců objektů**

Aspose.Slides for Node.js via Java umožňuje přidat [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) bez vložení dat, pouze s odkazem na soubor.

Tento JavaScriptový kód ukazuje, jak přidat [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) s propojeným souborem Excel do snímku:

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

// Přidejte OLE objektový rámec s propojeným souborem Excel.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Přístup k OLE rámcům objektů**

Pokud je OLE objekt již vložený do snímku, můžete jej snadno najít nebo získat přístup následujícím způsobem:

1. Načtěte prezentaci s vloženým OLE objektem vytvořením instance třídy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) .
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přistupte k tvaru [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame). V našem příkladu jsme použili dříve vytvořený PPTX, který má na prvním snímku pouze jeden tvar.
4. Jakmile je OLE rámec objektu přístupný, můžete s ním provádět libovolné operace.

V níže uvedeném příkladu jsou přístupny OLE rámec objektu (graf Excel vložený do snímku) a data souboru.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;
    
    // Získejte data vloženého souboru.
    var fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // Získejte příponu vloženého souboru.
    var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **Přístup k vlastnostem propojeného OLE rámce objektu**

Aspose.Slides umožňuje přistupovat k vlastnostem propojených OLE rámců objektů.

Tento JavaScriptový kód ukazuje, jak zjistit, zda je OLE objekt propojen, a následně získat cestu k propojenému souboru:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.ppt");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    // Zkontrolujte, zda je OLE objekt propojen.
    if (oleFrame.isObjectLink()) {
        // Vytiskněte úplnou cestu k propojenému souboru.
        console.log("OLE object frame is linked to:", oleFrame.getLinkPathLong());

        // Vytiskněte relativní cestu k propojenému souboru, pokud existuje.
        // Pouze prezentace PPT mohou obsahovat relativní cestu.
        if (oleFrame.getLinkPathRelative() != null && oleFrame.getLinkPathRelative() != "") {
            console.log("OLE object frame relative path:", oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **Změna dat OLE objektu**

{{% alert color="info" title="Note" %}}

V této sekci níže uvedený ukázkový kód používá [Aspose.Cells for Java](https://docs.aspose.com/cells/java/).

{{% /alert %}}

Pokud je OLE objekt již vložený do snímku, můžete k tomuto objektu snadno přistoupit a upravit jeho data následujícím způsobem:

1. Načtěte prezentaci s vloženým OLE objektem vytvořením instance třídy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) .
2. Získejte odkaz na snímek pomocí jeho indexu. 
3. Přistupte k tvaru OLE rámce objektu. V našem příkladu jsme použili dříve vytvořený PPTX, který má na prvním snímku jeden tvar.
4. Jakmile je OLE rámec objektu přístupný, můžete s ním provádět libovolné operace.
5. Vytvořte objekt `Workbook` a přistupte k OLE datům.
6. Přistupte k požadovanému `Worksheet` a upravte data.
7. Uložte aktualizovaný `Workbook` do proudu.
8. Změňte data OLE objektu z proudu.

V níže uvedeném příkladu je přístup k OLE rámci objektu (graf Excel vložený do snímku) a jeho souborová data jsou upravena tak, aby aktualizovala data grafu.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    var embeddedData = Array.from(oleFrame.getEmbeddedData().getEmbeddedFileData());
    var oleStream = java.newInstanceSync("java.io.ByteArrayInputStream", java.newArray("byte", embeddedData));

    // Načtěte data OLE objektu jako objekt Workbook.
    var workbook = java.newInstanceSync("com.aspose.cells.Workbook", oleStream);

    var newOleStream = java.newInstanceSync("java.io.ByteArrayOutputStream");

    // Modifikujte data sešitu.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    var fileOptions = java.newInstanceSync("com.aspose.cells.OoxmlSaveOptions", java.getStaticFieldValue("com.aspose.cells.SaveFormat", "XLSX"));
    workbook.save(newOleStream, fileOptions);

    // Změňte data objektu OLE rámce.
    var newFileData = java.newArray("byte", Array.from(newOleStream.toByteArray()));
    var newData = new asposeSlides.OleEmbeddedDataInfo(newFileData, oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);

    newOleStream.close();
    oleStream.close();
}

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Vkládání dalších typů souborů do snímků**

Kromě grafů Excel umožňuje Aspose.Slides for Node.js via Java vkládat do snímků i jiné typy souborů. Například můžete vložit HTML, PDF a ZIP soubory jako objekty. Když uživatel poklepne na vložený objekt, tento se automaticky otevře v příslušném programu nebo je uživatel vyzván k výběru vhodného programu pro jeho otevření.

Tento JavaScriptový kód ukazuje, jak vložit HTML a ZIP do snímku:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

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

Při práci s prezentacemi můžete potřebovat nahradit staré OLE objekty novými nebo nahradit nepodporovaný OLE objekt podporovaným. Aspose.Slides for Node.js via Java umožňuje nastavit typ souboru pro vložený objekt, což vám umožní aktualizovat data OLE rámce nebo jeho příponu.

Tento JavaScriptový kód ukazuje, jak nastavit typ souboru pro vložený OLE objekt na `zip`:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

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

## **Nastavení ikonových obrázků a titulků pro vložené objekty**

Po vložení OLE objektu je automaticky přidán náhled sestávající z ikony. Tento náhled je to, co uživatelé vidí před přístupem nebo otevřením OLE objektu. Pokud chcete použít konkrétní obrázek a text jako součásti náhledu, můžete nastavit ikonu a titul pomocí Aspose.Slides for Node.js via Java.

Tento JavaScriptový kód ukazuje, jak nastavit ikonu a titulek pro vložený objekt:

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

// Přidejte obrázek do zdrojů prezentace.
var image = asposeSlides.Images.fromFile("image.png");
var oleImage = presentation.getImages().addImage(image);
image.dispose();

// Set a title and the image for the OLE preview.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Zabránění změny velikosti a pozice OLE rámce objektu**

Po přidání propojeného OLE objektu do snímku prezentace, když otevřete prezentaci v PowerPointu, můžete vidět zprávu s výzvou k aktualizaci odkazů. Kliknutí na tlačítko „Update Links“ může změnit velikost a polohu OLE rámce objektu, protože PowerPoint aktualizuje data z propojeného OLE objektu a obnoví náhled objektu. Chcete‑li zabránit výzvě PowerPointu k aktualizaci dat objektu, zavolejte metodu [setUpdateAutomatic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) třídy [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/) s hodnotou `false`:

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

oleFrame.setUpdateAutomatic(false);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Extrahování vložených souborů**

Aspose.Slides for Node.js via Java umožňuje extrahovat soubory vložené do snímků jako OLE objekty následujícím způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) obsahující OLE objekty, které chcete extrahovat.
2. Procházejte všechny tvary v prezentaci a přistupujte k tvarům [OLEObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe).
3. Přistupujte k datům vložených souborů z OLE rámců objektů a zapíšete je na disk.

Tento JavaScriptový kód ukazuje, jak extrahovat soubory vložené do snímku jako OLE objekty:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

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

To, co je viditelné na snímku, je vykresleno – ikona/náhradní obrázek (náhled). „Živý“ OLE obsah během vykreslování neprobíhá. V případě potřeby nastavte vlastní obrázek náhledu, aby se zajistil očekávaný vzhled v exportovaném PDF.

Pro zachování vloženého souboru jako PDF přílohy zavolejte [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/#setIncludeOleData) s hodnotou `true`. Tato volba je ve výchozím nastavení vypnutá. Příklad a instrukce pro kontrolu přílohy najdete v [Preserve Embedded OLE Files as PDF Attachments](/slides/cs/nodejs-java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Jak mohu uzamknout OLE objekt na snímku, aby jej uživatelé nemohli v PowerPointu přesouvat/upravovat?**

Uzamkněte tvar: Aspose.Slides poskytuje zamykání na úrovni tvaru. Není to šifrování, ale účinně zabraňuje neúmyslným úpravám a přesunům.

**Zůstanou relativní cesty k propojeným OLE objektům zachovány v formátu PPTX?**

V PPTX není informace o „relativní cestě“ dostupná – pouze úplná cesta. Relativní cesty jsou k dispozici ve starším formátu PPT. Pro přenositelnost upřednostňujte spolehlivé absolutní cesty/přístupné URI nebo vložení.