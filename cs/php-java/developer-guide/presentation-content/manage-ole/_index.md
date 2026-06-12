---
title: Spravovat OLE v prezentacích pomocí PHP
linktitle: Spravovat OLE
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
- OLE titulek
- extrahovat OLE
- extrahovat objekt
- extrahovat soubor
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Optimalizujte správu OLE objektů v souborech PowerPoint a OpenDocument pomocí Aspose.Slides for PHP via Java. Vkládejte, aktualizujte a exportujte OLE obsah bez problémů."
---
## **Úvod**

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) je technologie společnosti Microsoft, která umožňuje umisťovat data a objekty vytvořené v jedné aplikaci do jiné aplikace pomocí propojení nebo vložení. 

{{% /alert %}} 

Zvažte graf vytvořený v MS Excel. Tento graf je poté umístěn do snímku PowerPointu. Tento excelový graf se považuje za OLE objekt. 

- OLE objekt se může zobrazovat jako ikona. V takovém případě, když dvojitě kliknete na ikonu, otevře se graf v příslušné aplikaci (Excel) nebo budete vyzváni k výběru aplikace pro otevření či úpravu objektu. 
- OLE objekt může zobrazovat svůj skutečný obsah, například obsah grafu. V tomto případě se graf aktivuje v PowerPointu, načte se rozhraní grafu a můžete upravovat data grafu přímo v PowerPointu.

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/cs/php-java/) vám umožňuje vložit OLE objekty do snímků jako OLE objektové rámečky ([OleObjectFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/oleobjectframe/)).

## **Přidání OLE objektových rámců do snímků**

Předpokládejme, že jste již vytvořili graf v Microsoft Excel a chcete jej vložit do snímku jako OLE objektový rámec pomocí Aspose.Slides for PHP via Java, můžete to provést takto:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
1. Získejte odkaz na snímek pomocí jeho indexu.
1. Přečtěte Excel soubor jako pole bajtů.
1. Přidejte [OleObjectFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/oleobjectframe/) do snímku s polem bajtů a dalšími informacemi o OLE objektu.
1. Uložte upravenou prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme přidali graf ze souboru Excel do snímku jako OLE objektový rámec pomocí Aspose.Slides for PHP via Java.  
**Poznámka**: konstruktor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/cs/php-java/aspose.slides/oleembeddeddatainfo/) přijímá jako druhý parametr příponu vkládaného objektu. Tato přípona umožňuje PowerPointu správně rozpoznat typ souboru a zvolit správnou aplikaci pro otevření tohoto OLE objektu.

```php
$presentation = new Presentation();
$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item(0);

// Prepare data for the OLE object.
$fileData = file_get_contents("book.xlsx");
$dataInfo = new OleEmbeddedDataInfo($fileData, "xlsx");

// Add the OLE object frame to the slide.
$slide->getShapes()->addOleObjectFrame(0, 0, $slideSize->getWidth(), $slideSize->getHeight(), $dataInfo);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

### **Přidání propojených OLE objektových rámců**

Aspose.Slides for PHP via Java vám umožňuje přidat [OleObjectFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/oleobjectframe/) bez vkládání dat, pouze s odkazem na soubor.

Tento PHP kód ukazuje, jak přidat [OleObjectFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/oleobjectframe/) s propojeným Excel souborem do snímku:

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

// Přidat OLE objektový rámec s propojeným souborem Excel.
$slide->getShapes()->addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Přístup k OLE objektovým rámcům**

Pokud je OLE objekt již vložen do snímku, můžete jej snadno najít nebo získat přístup tímto způsobem:

1. Načtěte prezentaci s vloženým OLE objektem vytvořením instance třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Získejte tvar [OleObjectFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/oleobjectframe/). V našem příkladu jsme použili dříve vytvořený PPTX, který má na prvním snímku pouze jeden tvar.
4. Jakmile je OLE objektový rámec získán, můžete s ním provádět libovolné operace.

V níže uvedeném příkladu je přistoupeno k OLE objektovému rámci (excelovému grafu vloženému do snímku) a k jeho souborovým datům.

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;
    
    // Získat data vloženého souboru.
    $fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

    // Získat příponu vloženého souboru.
    $fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();

    // ...
}
```

### **Přístup k vlastnostem propojeného OLE objektového rámce**

Aspose.Slides vám umožňuje přistupovat k vlastnostem propojených OLE objektových rámců.

Tento PHP kód ukazuje, jak zkontrolovat, zda je OLE objekt propojen, a poté získat cestu k propojenému souboru:

```php
$presentation = new Presentation("sample.ppt");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    // Zkontrolovat, zda je OLE objekt propojen.
    if (java_values($oleFrame->isObjectLink()) != 0) {
        // Vytisknout úplnou cestu k propojenému souboru.
        echo "OLE object frame is linked to: " . $oleFrame->getLinkPathLong() . PHP_EOL;

        // Vytisknout relativní cestu k propojenému souboru, pokud existuje.
        // Pouze prezentace PPT mohou obsahovat relativní cestu.
        $relativePath = java_values($oleFrame->getLinkPathRelative());
        if (!is_null($relativePath) && $relativePath !== "") {
            echo "OLE object frame relative path: " . $oleFrame->getLinkPathRelative() . PHP_EOL;
        }
    }
}

$presentation->dispose();
```

## **Změna dat OLE objektu**

{{% alert color="primary" %}} 

V této sekci níže uvedený příklad kódu používá [Aspose.Cells for PHP via Java](/cells/php-java/).

{{% /alert %}}

Pokud je OLE objekt již vložen do snímku, můžete jej snadno získat a upravit jeho data tímto způsobem:

1. Načtěte prezentaci s vloženým OLE objektem vytvořením instance třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
2. Získejte odkaz na snímek pomocí jeho indexu. 
3. Získejte tvar [OleObjectFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/oleobjectframe/). V našem příkladu jsme použili dříve vytvořený PPTX, který má na prvním snímku jeden tvar.
4. Jakmile je OLE objektový rámec získán, můžete s ním provádět libovolné operace.
5. Vytvořte objekt `Workbook` a získejte přístup k OLE datům.
6. Získejte požadovaný `Worksheet` a upravte data.
7. Uložte aktualizovaný `Workbook` do proudu.
8. Změňte data OLE objektu z proudu.

V níže uvedeném příkladu je přistoupeno k OLE objektovému rámci (excelovému grafu vloženému do snímku) a jeho souborová data jsou upravena tak, aby aktualizovala data grafu.

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    $oleStream = new ByteArrayInputStream($oleFrame->getEmbeddedData()->getEmbeddedFileData());

    // Načíst data OLE objektu jako objekt Workbook.
    $workbook = new Workbook($oleStream);

    $newOleStream = new Java("java.io.ByteArrayOutputStream");

    // Upravit data sešitu.
    $workbook->getWorksheets()->get(0)->getCells()->get(0, 4)->putValue("E");
    $workbook->getWorksheets()->get(0)->getCells()->get(1, 4)->putValue(12);
    $workbook->getWorksheets()->get(0)->getCells()->get(2, 4)->putValue(14);
    $workbook->getWorksheets()->get(0)->getCells()->get(3, 4)->putValue(15);

    $fileOptions = new OoxmlSaveOptions(SaveFormat::XLSX);
    $workbook->save($newOleStream, $fileOptions);

    // Změnit data objektu OLE rámce.
    $newData = new OleEmbeddedDataInfo($newOleStream->toByteArray(), $oleFrame->getEmbeddedData()->getEmbeddedFileExtension());
    $oleFrame->setEmbeddedData($newData);

    $newOleStream->close();
    $oleStream->close();
}

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Vkládání dalších typů souborů do snímků**

Kromě excelových grafů vám Aspose.Slides for PHP via Java umožňuje vložit do snímků i další typy souborů. Například můžete vložit HTML, PDF a ZIP soubory jako objekty. Když uživatel dvojitě klikne na vložený objekt, otevře se automaticky v příslušném programu nebo je uživatel vyzván k výběru vhodného programu pro jeho otevření.

Tento PHP kód ukazuje, jak vložit HTML a ZIP do snímku:

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

Při práci s prezentacemi může nastat potřeba nahradit staré OLE objekty novými nebo nahradit nepodporovaný OLE objekt podporovaným. Aspose.Slides for PHP via Java vám umožňuje nastavit typ souboru pro vložený objekt, což vám umožní aktualizovat data OLE rámce nebo jeho příponu.

Tento PHP kód ukazuje, jak nastavit typ souboru pro vložený OLE objekt na `zip`:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();
$fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

echo "Current embedded file extension is: " . $fileExtension . PHP_EOL;

// Změnit typ souboru na ZIP.
$oleFrame->setEmbeddedData(new OleEmbeddedDataInfo($fileData, "zip"));

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Nastavení ikonových obrázků a titulků pro vložené objekty**

Po vložení OLE objektu se automaticky přidá náhled sestávající z ikony. Tento náhled vidí uživatelé, než otevřou nebo získají přístup k OLE objektu. Pokud chcete použít konkrétní obrázek a text jako součásti náhledu, můžete nastavit ikonu a titulek pomocí Aspose.Slides for PHP via Java.

Tento PHP kód ukazuje, jak nastavit ikonu a titulek pro vložený objekt:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

// Přidat obrázek do zdrojů prezentace.
$imageData = file_get_contents("image.png");
$oleImage = $presentation->getImages()->addImage($imageData);

$oleFrame->setSubstitutePictureTitle("My title");
$oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
$oleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Zabránit změně velikosti a pozice OLE objektového rámce**

Po přidání propojeného OLE objektu do snímku prezentace se při otevření v PowerPointu může zobrazit zpráva s výzvou k aktualizaci odkazů. Kliknutí na tlačítko „Update Links“ může změnit velikost a pozici OLE objektového rámce, protože PowerPoint aktualizuje data z propojeného OLE objektu a obnovuje náhled. Aby PowerPoint nevyzýval k aktualizaci dat objektu, nastavte metodu `setUpdateAutomatic` třídy [OleObjectFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/oleobjectframe/) na `false`:

```php
$oleFrame->setUpdateAutomatic(false);
```

## **Extrahování vložených souborů**

Aspose.Slides for PHP via Java vám umožňuje extrahovat soubory vložené do snímků jako OLE objekty tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) obsahující OLE objekty, které chcete extrahovat.
2. Projděte všechny tvary v prezentaci a získejte tvary typu [OLEObjectFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/oleobjectframe/).
3. Získejte data vložených souborů z OLE objektových rámců a zapište je na disk.

Tento PHP kód ukazuje, jak extrahovat soubory vložené do snímku jako OLE objekty:

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

## **FAQ**

**Bude OLE obsah renderován při exportu snímků do PDF/obrázků?**

Co je na snímku viditelné, je renderováno — ikona/náhradní obrázek (náhled). „Živý“ OLE obsah se během renderování nespouští. V případě potřeby nastavte vlastní obrázek náhledu, aby se v exportovaném PDF zobrazoval očekávaný vzhled.

**Jak mohu uzamknout OLE objekt na snímku, aby jej uživatelé nemohli v PowerPointu přesouvat/upravovat?**

Uzamkněte tvar: Aspose.Slides poskytuje zamykání na úrovni tvaru. Není to šifrování, ale efektivně zabraňuje neúmyslným úpravám a přesunům.

**Zůstanou relativní cesty pro propojené OLE objekty zachovány ve formátu PPTX?**

V PPTX nejsou informace o „relativní cestě“ k dispozici — existuje jen úplná cesta. Relativní cesty jsou k dispozici jen ve starším formátu PPT. Pro přenositelnost upřednostňujte spolehlivé absolutní cesty/přístupné URI nebo vložení.