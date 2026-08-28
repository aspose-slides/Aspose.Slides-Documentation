---
title: Převod snímků prezentace na obrázky v PHP
linktitle: Snímek na obrázek
type: docs
weight: 35
url: /cs/php-java/convert-slide/
keywords:
- převést snímek
- exportovat snímek
- snímek na obrázek
- uložit snímek jako obrázek
- snímek na EMF
- snímek na PNG
- snímek na JPEG
- snímek na bitmapu
- snímek na TIFF
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Převod snímků z prezentací PPT, PPTX a ODP na PNG, JPEG, GIF, TIFF, EMF a další formáty obrázků v PHP pomocí Aspose.Slides."
---
## **Úvod**

Aspose.Slides for PHP via Java dokáže vykreslovat jednotlivé snímky z prezentací PowerPoint a OpenDocument jako PNG, JPEG, GIF, TIFF a další formáty obrázků.

Pro převod snímku na obrázek postupujte podle těchto kroků:

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
2. Vyberte snímek, který chcete vykreslit.
3. V případě potřeby nakonfigurujte vykreslování pomocí třídy [RenderingOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/renderingoptions/) nebo [TiffOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/tiffoptions/).
4. Zavolejte metodu [Slide::getImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slide/#getImage). Vrací objekt [IImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/iimage/).
5. Zavolejte metodu [IImage::save](https://reference.aspose.com/slides/cs/php-java/aspose.slides/iimage/#save) a specifikujte výstupní formát pomocí hodnoty [ImageFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/imageformat/).

## **Převod snímku na PNG obrázek**

Nejjednodušší převod používá výchozí nastavení vykreslování. Výsledný objekt [IImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/iimage/) lze zpracovat v paměti nebo uložit do souboru.

Následující PHP příklad vykreslí první snímek a uloží jej jako PNG obrázek:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage();
    try {
        $image->save("Slide_0.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Převod snímků na obrázky s vlastními rozměry**

Použijte přetížení [Slide::getImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slide/#getImage), které přijímá hodnotu [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) pro vykreslení snímku s přesnými rozměry v pixelech.

Následující příklad vytvoří JPEG obrázek 1820 × 1040:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$imageSize = new Java("java.awt.Dimension", 1820, 1040);

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($imageSize);
    try {
        $image->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Převod snímků s poznámkami a komentáři na obrázky**

Ve výchozím nastavení obrázky snímků neobsahují poznámky ani komentáře. Předávejte objekt [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/notescommentslayoutingoptions/) metodě [RenderingOptions::setSlidesLayoutOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions), abyste určili, kde se poznámky a komentáře zobrazí.

Následující příklad umístí zkrácené poznámky pod snímek a komentáře vpravo od něj:

```php
use aspose\slides\CommentsPositions;
use aspose\slides\ImageFormat;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;

$scaleX = 2;
$scaleY = $scaleX;

$commentsAreaColor = new Java("java.awt.Color", 250, 235, 215);

$layoutOptions = new NotesCommentsLayoutingOptions();
$layoutOptions->setNotesPosition(NotesPositions::BottomTruncated);
$layoutOptions->setCommentsPosition(CommentsPositions::Right);
$layoutOptions->setCommentsAreaWidth(500);
$layoutOptions->setCommentsAreaColor($commentsAreaColor);

$renderingOptions = new RenderingOptions();
$renderingOptions->setSlidesLayoutOptions($layoutOptions);

$presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($renderingOptions, $scaleX, $scaleY);
    try {
        $image->save("Image_with_notes_and_comments_0.gif", ImageFormat::Gif);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Warning" color="warning" %}}
Pro převod snímku na obrázek nepřepínejte [BottomFull](https://reference.aspose.com/slides/cs/php-java/aspose.slides/notespositions/) metodě [NotesCommentsLayoutingOptions::setNotesPosition](https://reference.aspose.com/slides/cs/php-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Poznámky mohou obsahovat více textu, než je velikost pevného obrázku schopna pojmout. Použijte místo toho [BottomTruncated](https://reference.aspose.com/slides/cs/php-java/aspose.slides/notespositions/).
{{% /alert %}}

## **Převod snímků na obrázky pomocí TIFF možností**

Třída [TiffOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/tiffoptions/) vám umožňuje řídit velikost, rozlišení a další vlastnosti vykresleného TIFF obrázku.

Následující příklad vykreslí první snímek jako TIFF obrázek 2160 × 2880 při 300 DPI:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;
use aspose\slides\TiffOptions;

$imageSize = new Java("java.awt.Dimension", 2160, 2880);

$tiffOptions = new TiffOptions();
$tiffOptions->setImageSize($imageSize);
$tiffOptions->setDpiX(300);
$tiffOptions->setDpiY(300);

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($tiffOptions);
    try {
        $image->save("output.tiff", ImageFormat::Tiff);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Warning" color="warning" %}}
Podpora TIFF není zaručena v Java verzích před JDK 9.
{{% /alert %}}

## **Převod všech snímků na obrázky**

Projděte kolekci snímků a převěďte celou prezentaci na sérii obrázků. Skryté snímky jsou zahrnuty, pokud je explicitně nepřeskočíte.

Následující příklad vykreslí každý snímek jako JPEG obrázek se horizontálním a vertikálním měřítkem 2:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($scaleX, $scaleY);
        try {
            $image->save("Slide_" . $index . ".jpg", ImageFormat::Jpeg);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Vytvoření výstupu Enhanced Metafile**

Enhanced Metafile (EMF) je užitečný, když je nutné vyměňovat vektorovou grafiku s Microsoft Office nebo jinými Windows aplikacemi, které podporují Windows metafily. Na rozdíl od rastrového obrázku může EMF zachovat vektorové kreslící operace, které se škálují bez ztráty ostrosti. Přesto je EMF převážně formát kompatibility pro aplikace s podporou Windows metafilů, nikoli univerzální výměnný formát. Navíc může být složitý obsah snímku, jako bitmapové obrázky a některé efekty, uložen jako rasterizované prvky uvnitř kontejneru vektorového metafile.

### **Export snímku do EMF**

Metoda [Slide::writeAsEmf](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slide/#writeAsEmf) zapíše snímek do cílového proudu ve formátu EMF. Následující příklad načte prezentaci, vybere první snímek a zapíše jej do EMF souborového proudu:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $emfStream = new Java("java.io.FileOutputStream", "Slide_0.emf");
    try {
        $slide->writeAsEmf($emfStream);
    } finally {
        $emfStream->close();
    }
} finally {
    $presentation->dispose();
}
```

Volající vlastní proud předaný metodě [Slide::writeAsEmf](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slide/#writeAsEmf) a je zodpovědný za jeho uzavření, jak je ukázáno výše.

### **Převod SVG obrázku na EMF a přidání do prezentace**

Použijte [SvgImage::writeAsEmf](https://reference.aspose.com/slides/cs/php-java/aspose.slides/svgimage/#writeAsEmf) k převodu SVG obsahu na EMF. Výsledná bajtová data lze přidat do prezentace pomocí [ImageCollection::addImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/imagecollection/#addImage) a umístit na snímek pomocí [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/#addPictureFrame).

Následující příklad vytvoří [SvgImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/svgimage/) ze SVG značkování, převede jej na EMF v paměti, vloží metafil na první snímek a uloží prezentaci:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SvgImage;

$svgContent = '<svg xmlns="http://www.w3.org/2000/svg" width="200" height="100"><rect width="200" height="100" fill="#4472C4"/></svg>';
$svgImage = new SvgImage($svgContent);

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $emfStream = new Java("java.io.ByteArrayOutputStream");
    try {
        $svgImage->writeAsEmf($emfStream);

        $emfData = $emfStream->toByteArray();
        $image = $presentation->getImages()->addImage($emfData);
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 100, $image);
    } finally {
        $emfStream->close();
    }

    $presentation->save("Presentation_with_emf.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[SvgImage::writeAsEmf](https://reference.aspose.com/slides/cs/php-java/aspose.slides/svgimage/#writeAsEmf) nepřebírá vlastnictví cílového proudu. [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) ukládá všechna generovaná data v paměti, takže před voláním `toByteArray` není nutné resetovat pozici. Vrácené pole bytů zůstává platné i po uzavření proudu.

Generování EMF je dostupné na operačních systémech podporovaných vybranou konfigurací Aspose.Slides for PHP via Java a JDK, avšak vykreslování se může lišit napříč platformami, pokud nejsou k dispozici písma nebo grafické závislosti. Nainstalujte písma použité ve zdrojovém obsahu nebo nastavte vhodné náhrady, řiďte se [požadavky na platformu](/slides/cs/php-java/system-requirements/) pro Aspose.Slides for PHP via Java a ověřte výsledek v cílové aplikaci spotřebovávající EMF. Aplikace na Linuxu a macOS často mají omezenou či nejednotnou podporu pro zobrazování a editaci Windows metafilů.

## **Vykreslování barevných emoji**

{{% alert title="Note" color="info" %}}
Aby bylo možné při převodu snímků prezentace na obrázky správně vykreslovat barevné emoji, musí být písma emoji použité v prezentaci nainstalována a dostupná v systému provádějícím převod. Například pokud prezentace používá **Segoe UI Emoji** a toto písmo chybí, mohou se emoji v výstupních obrázcích zobrazovat v monochromu.
{{% /alert %}}

## **FAQ**

**Podporuje Aspose.Slides vykreslování snímků s animacemi?**

Ne. Metoda [Slide::getImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slide/#getImage) vykresluje statický obrázek snímku a neexportuje animace.

**Lze skryté snímky exportovat jako obrázky?**

Ano. Skryté snímky lze vykreslit jako běžné snímky. Zahrňte je do zpracovatelského cyklu, jak je ukázáno v předchozím příkladu.

**Zůstávají stíny a další efekty zachovány v obrázcích snímků?**

Ano. Aspose.Slides vykresluje stíny, průhlednost a další podporované grafické efekty v obrázcích snímků.