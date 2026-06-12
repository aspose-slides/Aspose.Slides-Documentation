---
title: Vylepšení zpracování obrázků pomocí Moderního API
linktitle: Moderní API
type: docs
weight: 237
url: /cs/php-java/modern-api/
keywords:
- moderní API
- kreslení
- miniatura snímku
- snímek na obrázek
- miniatura tvaru
- tvar na obrázek
- miniatura prezentace
- prezentace na obrázky
- přidat obrázek
- přidat fotografii
- PHP
- Aspose.Slides
description: "Modernizujte zpracování obrázků snímků nahrazením zastaralých API pro práci s obrázky Moderním PHP API pro plynulou automatizaci PowerPoint a OpenDocument."
---
## **Úvod**

Historicky má Aspose Slides závislost na java.awt a v veřejném API obsahuje následující třídy z tohoto balíčku:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

Od verze 24.4 je toto veřejné API označeno jako zastaralé.

Abychom se zbavili závislostí na těchto třídách, přidali jsme takzvané „Moderní API“ – tj. API, které by mělo být používáno místo zastaralého, jehož signatury obsahují závislosti na [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html). [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) je označeno jako zastaralé a jeho podpora je z veřejného API Slides odstraněna.

V aktuálních verzích považujte veřejné API, které závisí na typech java.awt, za legacy/zastaralé. Používejte Moderní API pro nový kód a při migraci existujících pracovních postupů zpracování obrázků.

## **Moderní API**

Přidali jsme následující třídy a výčty do veřejného API:

- [IImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/iimage/) – představuje rastrový nebo vektorový obrázek.
- [ImageFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/imageformat/) – představuje formát souboru obrázku.
- [Images](https://reference.aspose.com/slides/cs/php-java/aspose.slides/images/) – metody pro vytvoření a práci s třídou [IImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/iimage/).

Všimněte si, že [IImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/iimage/) je disposable (měla by být po použití uvolněna).

Použijte `getImage` k vykreslení jednoho snímku nebo tvaru. Použijte `getImages` k vykreslení několika snímků prezentace. Použijte metody z [Images](https://reference.aspose.com/slides/cs/php-java/aspose.slides/images/) pro načtení obrázků, `addImage` s [IImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/iimage/) pro jejich přidání do prezentace a `replaceImage` s [IImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/iimage/) pro aktualizaci existujícího obrázku v prezentaci.

Typický scénář použití nového API může vypadat takto:

``` php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\ImageFormat;
use aspose\slides\Images;


$pres = new Presentation();

# vytvořte odhazovatelnou instanci IImage ze souboru na disku.
$image = Images::fromFile("image.png");

# vytvořte PowerPoint obrázek přidáním instance IImage do obrázků prezentace.
$ppImage = $pres->getImages()->addImage($image);
$image->dispose();

# přidejte obrazový tvar na snímek č. 1
$pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $ppImage);

$dimension = new Java("java.awt.Dimension", 1920, 1080);
# získejte instanci IImage představující snímek č. 1.
$slideImage = $pres->getSlides()->get_Item(0)->getImage($dimension);

# uložte obrázek na disk.
$slideImage->save("slide1.jpeg", ImageFormat::Jpeg);
$slideImage->dispose();

$pres->dispose();
```

## **Nahrazení starého kódu Moderním API**

Obecně budete muset nahradit volání, která používají [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) a [ImageIO](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html), novými metodami, které používají [IImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/iimage/).

Legacy/zastaralé API:
``` php
$dimension = new Java("java.awt.Dimension", 1920, 1080);
$slideImage = $pres->getSlides()->get_Item(0)->getThumbnail($dimension);
$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "image.png");
$imageio->write($slideImage, "PNG", $javafile);
```
Moderní API:
``` php
$dimension = new Java("java.awt.Dimension", 1920, 1080);
$slideImage = $pres->getSlides()->get_Item(0)->getImage($dimension);
$slideImage->save("image.png", ImageFormat::Png);
$slideImage->dispose();
```

### **Získání miniatury snímku**

Legacy/zastaralé API:

``` php
use aspose\slides\Presentation;


$pres = new Presentation("pres.pptx");

$slideImage = $pres->getSlides()->get_Item(0)->getThumbnail();

$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "slide1.png");
$imageio->write($slideImage, "PNG", $javafile);

$pres->dispose();
```

Moderní API:

``` php
use aspose\slides\Presentation;
use aspose\slides\ImageFormat;


$pres = new Presentation("pres.pptx");

$slideImage = $pres->getSlides()->get_Item(0)->getImage();
$slideImage->save("slide1.png", ImageFormat::Png);
$slideImage->dispose();

$pres->dispose();
```

### **Získání miniatury tvaru**

Legacy/zastaralé API:

``` php
use aspose\slides\Presentation;


$pres = new Presentation("pres.pptx");

$shapeImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThumbnail();

$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "shape.png");
$imageio->write($shapeImage, "PNG", $javafile);

$pres->dispose();
```

Moderní API:

``` php
use aspose\slides\Presentation;
use aspose\slides\ImageFormat;


$pres = new Presentation("pres.pptx");

$shapeImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
$shapeImage->save("shape.png");
$shapeImage->dispose();

$pres->dispose();
```

### **Získání miniatury prezentace**

Legacy/zastaralé API:

``` php
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;


$pres = new Presentation("pres.pptx");

$renderingOptions = new RenderingOptions();
$dimension = new Java("java.awt.Dimension", 1920, 1080);

$bitmaps = $pres->getThumbnails($renderingOptions, $dimension);
for ($i = 0; $i < count(java_values($bitmaps)); $i++)
{
    $thumbnail = $bitmaps[$i];
    $imageio = new Java("javax.imageio.ImageIO");
    $javafile = new Java("java.io.File", "slide" . $i . ".png");
    $imageio->write($thumbnail, "PNG", $javafile);
}

$pres->dispose();
```

Moderní API:

``` php
use aspose\slides\Presentation;
use aspose\slides\ImageFormat;
use aspose\slides\RenderingOptions;


$pres = new Presentation("pres.pptx");

$renderingOptions = new RenderingOptions();
$dimension = new Java("java.awt.Dimension", 1920, 1080);

$images = $pres->getImages($renderingOptions, $dimension);
for ($i = 0; $i < count(java_values($images)); $i++)
{
    $thumbnail = $images[$i];
    $thumbnail->save("slide" . $i . ".png", ImageFormat::Png);
}

$pres->dispose();
```

### **Přidání obrázku do prezentace**

Legacy/zastaralé API:

``` php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;


$pres = new Presentation();

$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "image.png");

$bufferedImages = $imageio->read($javafile);
$ppImage = $pres->getImages()->addImage($bufferedImages);

$pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $ppImage);

$pres->dispose();
```

Moderní API:

``` php
use aspose\slides\Presentation;
use aspose\slides\Images;
use aspose\slides\ShapeType;


$pres = new Presentation();

$image = Images::fromFile("image.png");
$ppImage = $pres->getImages()->addImage($image);
$image->dispose();

$pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $ppImage);

$pres->dispose();
```

## **Zastaralé metody a jejich náhrada v Moderním API**

### **Presentation**
| Method Signature                               | Replacement Method Signature                             |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options)                   |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY)   |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Shape**
| Method Signature                                                      | Replacement Method Signature                                       |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public final BufferedImage getThumbnail()                                        | public final IImage getImage()                                                           |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| Method Signature                                                      | Replacement Method Signature                                           |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final BufferedImage getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, Dimension imageSize) | public final IImage getImage(IRenderingOptions options, Dimension imageSize) |
| public final BufferedImage getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final BufferedImage getThumbnail(Dimension imageSize) | public final IImage getImage(Dimension imageSize) |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics) | No Modern API replacement  |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY) | No Modern API replacement  |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize) | No Modern API replacement  |

### **Output**
| Method Signature                                                | Replacement Method Signature                                |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Method Signature                          | Replacement Method Signature               |
|-------------------------------------------|--------------------------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| Method Signature                     | Replacement Method Signature   |
|--------------------------------------|-----------------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Method Signature                                          | Replacement Method Signature                        |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final BufferedImage getTileImage(Color styleColor)   | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) |public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| Method Signature                                          | Replacement Method Signature                        |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |


## **Podpora API pro Graphics2D**

Metody s [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) jsou označeny jako zastaralé a nemají přímou náhradu v Moderním API.

Použijte metody pro vykreslování obrázků Moderního API místo API, které vykresluje do [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html):

[Slide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **Často kladené otázky**

**Proč byla [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) odstraněna?**

Podpora pro [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) je v veřejném API označena jako zastaralá, aby se sjednotila práce s vykreslováním a obrázky, eliminovaly se vazby na platformově specifické závislosti a přešlo se na multiplatformní přístup s [IImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/iimage/). Používejte `getImage` nebo `getImages` místo vykreslování do [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html).

**Jaký je praktický přínos [IImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/iimage/) ve srovnání s [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)?**

[IImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/iimage/) sjednocuje práci s rastrovými i vektorovými obrázky a usnadňuje ukládání do různých formátů pomocí [ImageFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/imageformat/).

**Ovlivní Moderní API výkon při generování miniatur?**

Přechod z `getThumbnail` na `getImage` nezhoršuje scénáře: nové metody poskytují stejné možnosti pro vytváření obrázků s volbami a velikostmi, přičemž zachovávají podporu pro vykreslovací možnosti. Konkrétní zisk nebo ztráta závisí na scénáři, ale funkčně jsou náhrady ekvivalentní.