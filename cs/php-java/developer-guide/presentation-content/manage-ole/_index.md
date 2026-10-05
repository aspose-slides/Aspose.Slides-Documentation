---
title: Správa OLE v prezentacích pomocí PHP
linktitle: Správa OLE
type: docs
weight: 40
url: /cs/php-java/manage-ole/
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
- OLE ikona
- OLE název
- extrahovat OLE
- extrahovat objekt
- extrahovat soubor
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Optimalizujte správu OLE objektů v souborech PowerPoint a OpenDocument pomocí Aspose.Slides pro PHP přes Java. Vkládejte, aktualizujte a exportujte OLE obsah hladce."
---
## **Úvod**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) je technologie společnosti Microsoft, která umožňuje umístit data a objekty vytvořené v jedné aplikaci do jiné aplikace pomocí propojení nebo vložení. 

{{% /alert %}} 

Uvažujme graf vytvořený v MS Excel. Tento graf je následně umístěn na snímek PowerPointu. Tento Excel graf je považován za OLE objekt. 

- OLE objekt se může zobrazit jako ikona. V takovém případě, když na ikonu dvojkliknete, graf se otevře v příslušné aplikaci (Excel) nebo budete vyzváni k výběru aplikace pro otevření nebo úpravu objektu.
- OLE objekt může zobrazovat svůj skutečný obsah, například obsah grafu. V tomto případě se graf aktivuje v PowerPointu, načte se rozhraní grafu a můžete v PowerPointu upravovat data grafu.

[Aspose.Slides pro PHP přes Java](https://products.aspose.com/slides/php-java/) umožňuje vkládat OLE objekty do snímků jako OLE objektové rámy ([OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/)).

## **Přidání OLE objektových rámců do snímků**

Předpokládejme, že jste již vytvořili graf v Microsoft Excel a chcete jej vložit do snímku jako OLE objektový rámec pomocí Aspose.Slides pro PHP přes Java, můžete postupovat takto:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
1. Získejte odkaz na snímek podle jeho indexu.
1. Přečtěte soubor Excel jako pole bajtů.
1. Přidejte [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) na snímek obsahující pole bajtů a další informace o OLE objektu.
1. Uložte upravenou prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme přidali graf ze souboru Excel na snímek jako OLE objektový rámec pomocí Aspose.Slides pro PHP přes Java.  
**Poznámka**: konstruktor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/) přijímá jako druhý parametr rozšíření vkládaného objektu. Toto rozšíření umožňuje PowerPointu správně interpretovat typ souboru a vybrat správnou aplikaci pro otevření tohoto OLE objektu.

```php
$presentation = new Presentation();
$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item(0);

// Připravte data pro OLE objekt.
$fileData = file_get_contents("book.xlsx");
$dataInfo = new OleEmbeddedDataInfo($fileData, "xlsx");

// Přidejte OLE objektový rámec na snímek.
$slide->getShapes()->addOleObjectFrame(0, 0, $slideSize->getWidth(), $slideSize->getHeight(), $dataInfo);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

### **Přidání propojených OLE objektových rámců**

Aspose.Slides pro PHP přes Java umožňuje přidat [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) bez vložení dat, jen s odkazem na soubor.

Tento PHP kód vám ukáže, jak přidat [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) s propojeným souborem Excel na snímek:

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

// Přidejte OLE objektový rámec s propojeným souborem Excel.
$slide->getShapes()->addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Přístup k OLE objektovým rámcům**

Pokud je OLE objekt již vložený do snímku, můžete jej snadno najít nebo získat takto:

1. Načtěte prezentaci s vloženým OLE objektem vytvořením instance třídy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Získejte tvar [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/). V našem příkladu jsme použili dříve vytvořený PPTX, který má na prvním snímku pouze jeden tvar.
4. Jakmile je OLE objektový rámec získán, můžete s ním provádět libovolné operace.

V níže uvedeném příkladu jsou přístupovány OLE objektový rámec (objekt grafu Excel vložený do snímku) a jeho souborová data.

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;
    
    // Získejte data vloženého souboru.
    // Získejte příponu vloženého souboru.
    // ...
}
```

### **Přístup k vlastnostem propojeného OLE objektového rámce**

Aspose.Slides umožňuje přístup k vlastnostem propojeného OLE objektového rámce.

Tento PHP kód vám ukáže, jak zkontrolovat, zda je OLE objekt propojen, a poté získat cestu k propojenému souboru:

```php
$presentation = new Presentation("sample.ppt");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    // Zkontrolujte, zda je OLE objekt propojen.
    if (java_values($oleFrame->isObjectLink()) != 0) {
        // Vytiskněte úplnou cestu k propojenému souboru.
        echo "OLE object frame is linked to: " . $oleFrame->getLinkPathLong() . PHP_EOL;

        // Vytiskněte relativní cestu k propojenému souboru, pokud existuje.
        // Pouze prezentace PPT mohou obsahovat relativní cestu.
        $relativePath = java_values($oleFrame->getLinkPathRelative());
        if (!is_null($relativePath) && $relativePath !== "") {
            echo "OLE object frame relative path: " . $oleFrame->getLinkPathRelative() . PHP_EOL;
        }
    }
}

$presentation->dispose();
```

## **Změna OLE objektových dat**

{{% alert color="info" title="Note" %}}

V této sekci níže uvedený kód používá [Aspose.Cells pro PHP přes Java](https://docs.aspose.com/cells/php-java/).

{{% /alert %}}

Pokud je OLE objekt již vložený do snímku, můžete k objektu snadno přistupovat a upravit jeho data tímto způsobem:

1. Načtěte prezentaci s vloženým OLE objektem vytvořením instance třídy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Získejte odkaz na snímek podle jeho indexu. 
3. Získejte tvar [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/). V našem příkladu jsme použili dříve vytvořený PPTX, který má na prvním snímku jeden tvar.
4. Jakmile je OLE objektový rámec získán, můžete s ním provádět libovolné operace.
5. Vytvořte objekt `Workbook` a získejte OLE data.
6. Získejte požadovaný `Worksheet` a upravte data.
7. Uložte aktualizovaný `Workbook` do proudu.
8. Nahraďte data OLE objektu z proudu.

V níže uvedeném příkladu je OLE objektový rámec (objekt grafu Excel vložený do snímku) přístupný a jeho souborová data jsou upravena tak, aby aktualizovala data grafu.

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    $oleStream = new Java("java.io.ByteArrayInputStream", $oleFrame->getEmbeddedData()->getEmbeddedFileData());

    // Načtěte data OLE objektu jako objekt Workbook.
    $workbook = new Workbook($oleStream);

    $newOleStream = new Java("java.io.ByteArrayOutputStream");

    // Upravte data sešitu.
    $workbook->getWorksheets()->get(0)->getCells()->get(0, 4)->putValue("E");
    $workbook->getWorksheets()->get(0)->getCells()->get(1, 4)->putValue(12);
    $workbook->getWorksheets()->get(0)->getCells()->get(2, 4)->putValue(14);
    $workbook->getWorksheets()->get(0)->getCells()->get(3, 4)->putValue(15);

    $fileOptions = new OoxmlSaveOptions(SaveFormat::XLSX);
    $workbook->save($newOleStream, $fileOptions);

    // Změňte data objektu OLE rámce.
    $newData = new OleEmbeddedDataInfo($newOleStream->toByteArray(), $oleFrame->getEmbeddedData()->getEmbeddedFileExtension());
    $oleFrame->setEmbeddedData($newData);

    $newOleStream->close();
    $oleStream->close();
}

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Vkládání dalších typů souborů do snímků**

Kromě grafů Excel umožňuje Aspose.Slides pro PHP přes Java vložit do snímků i jiné typy souborů. Například můžete vložit HTML, PDF a ZIP soubory jako objekty. Když uživatel dvojklikne vložený objekt, automaticky se otevře v příslušném programu, nebo je vyzván k výběru vhodného programu pro otevření.

Tento PHP kód vám ukáže, jak vložit HTML a ZIP do snímku:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);

$htmlData = file_get_contents("sample.html");
$htmlDataInfo = new OleEmbeddedDataInfo($htmlData, "html");
$htmlOleFrame = $slide->getShapes()->addOleObjectFrame(150, 120, 50, 50, $htmlDataInfo);
$htmlOleFrame->setObjectIcon(true);

$zipData = file_get_contents("sample.zip");
$zipDataInfo = new OleEmbeddedDataInfo($zipData, "zip");
$zipOleFrame = $slide->getShapes()->addOleObjectFrame(150, 220, 50, 50, $zipDataInfo);
$zipOleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Nastavení typů souborů pro vložené objekty**

Při práci s prezentacemi může být potřeba nahradit staré OLE objekty novými nebo nahradit nepodporovaný OLE objekt podporovaným. Aspose.Slides pro PHP přes Java umožňuje nastavit typ souboru pro vložený objekt, čímž můžete aktualizovat data OLE rámce nebo jeho rozšíření.

Tento PHP kód vám ukáže, jak nastavit typ souboru pro vložený OLE objekt na `zip`:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();
$fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

echo "Current embedded file extension is: " . $fileExtension . PHP_EOL;

// Změňte typ souboru na ZIP.
$oleFrame->setEmbeddedData(new OleEmbeddedDataInfo($fileData, "zip"));

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Nastavení ikon a názvů pro vložené objekty**

Po vložení OLE objektu se automaticky přidá náhled sestávající z ikony. Tento náhled vidí uživatelé před přístupem nebo otevřením OLE objektu. Pokud chcete použít konkrétní obrázek a text jako součásti náhledu, můžete nastavit ikonu a název pomocí Aspose.Slides pro PHP přes Java.

Tento PHP kód vám ukáže, jak nastavit ikonu a název pro vložený objekt:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

// Přidejte obrázek do zdrojů prezentace.
$imageData = file_get_contents("image.png");
$oleImage = $presentation->getImages()->addImage($imageData);

// Set a title and the image for the OLE preview.
$oleFrame->setSubstitutePictureTitle("My title");
$oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
$oleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Zabránění změně velikosti a přesunu OLE objektového rámce**

Po přidání propojeného OLE objektu do snímku prezentace se při otevření prezentace v PowerPointu může objevit zpráva s výzvou k aktualizaci odkazů. Kliknutí na tlačítko „Update Links“ může změnit velikost a umístění OLE objektového rámce, protože PowerPoint aktualizuje data z propojeného OLE objektu a obnoví náhled. Aby PowerPoint nevyzýval k aktualizaci dat objektu, zavolejte metodu [setUpdateAutomatic](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) třídy [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) s hodnotou `false`:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$oleFrame->setUpdateAutomatic(false);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Extrahování vložených souborů**

Aspose.Slides pro PHP přes Java umožňuje extrahovat soubory vložené do snímků jako OLE objekty tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) obsahující OLE objekty, které chcete extrahovat.
2. Projděte všechny tvary v prezentaci a získejte tvary [OLEObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/).
3. Získejte data vložených souborů z OLE objektových rámců a zapište je na disk.

Tento PHP kód vám ukáže, jak extrahovat soubory vložené do snímku jako OLE objekty:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);

$shapeCount = java_values($slide->getShapes()->size());
for ($index = 0; $index < $shapeCount; $index++) {
    $shape = $slide->getShapes()->get_Item($index);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
        $oleFrame = $shape;

        $fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();
        $fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();

        $filePath = "OLE_object_" . $index . $fileExtension;
        file_put_contents($filePath, $fileData);
    }
}

$presentation->dispose();
```

## **Často kladené otázky**

**Bude OLE obsah vykreslen při exportu snímků do PDF/obrázků?**

Na snímku se vykreslí to, co je viditelné – ikona/náhradní obrázek (náhled). „Živý“ OLE obsah není během vykreslování proveden. V případě potřeby nastavte vlastní obrázek náhledu, aby se v exportovaném PDF zobrazoval očekávaný vzhled.

Pro zachování vloženého souboru jako přílohy PDF zavolejte [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setIncludeOleData) s hodnotou `true`. Tato volba je ve výchozím stavu vypnutá. Příklad a instrukce pro kontrolu přílohy jsou uvedeny v [Preserve Embedded OLE Files as PDF Attachments](/slides/cs/php-java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Jak mohu uzamknout OLE objekt na snímku, aby jej uživatelé nemohli přesouvat/upravovat v PowerPointu?**

Uzamkněte tvar: Aspose.Slides poskytuje zámky na úrovni tvaru. Není to šifrování, ale účinně zabraňuje nechtěným úpravám a přesunu.

**Zůstanou relativní cesty pro propojené OLE objekty zachovány ve formátu PPTX?**

V PPTX není informace o „relativní cestě“ dostupná – jen úplná cesta. Relativní cesty jsou k dispozici pouze ve starším formátu PPT. Pro přenositelnost upřednostněte spolehlivé absolutní cesty/přístupné URI nebo vložení.