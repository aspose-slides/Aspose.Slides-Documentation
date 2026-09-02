---
title: Optimalizace správy obrázků v prezentacích pomocí Javy
linktitle: Správa obrázků
type: docs
weight: 10
url: /cs/java/image/
keywords:
- přidat obrázek
- přidat fotografii
- přidat bitmapu
- nahradit obrázek
- nahradit fotografii
- z webu
- pozadí
- přidat PNG
- přidat JPG
- přidat SVG
- externí SVG zdroje
- SVG řešitel
- propojené SVG obrázky
- SVG písma
- přidat EMF
- přidat WMF
- přidat TIFF
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: Zjednodušte správu obrázků v PowerPointu a OpenDocumentu pomocí Aspose.Slides pro Javu, optimalizujte výkon a automatizujte svůj pracovní postup.
---
## **Úvod**

Obrázky činí prezentace poutavějšími a vizuálně atraktivnějšími. V Microsoft PowerPoint můžete vkládat obrázky do snímků ze souborů, internetu nebo jiných zdrojů. Podobně Aspose.Slides umožňuje přidávat obrázky do snímků několika způsoby.

{{% alert  title="Tip" color="primary" %}} 

Aspose poskytuje bezplatné konvertory—[JPEG to PowerPoint](https://products.aspose.app/slides/cs/import/jpg-to-ppt) a [PNG to PowerPoint](https://products.aspose.app/slides/cs/import/png-to-ppt)—které vám umožní rychle vytvořit prezentace z obrázků. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Pokud chcete přidat obrázek jako rámeček obrázku—zejména pokud ho plánujete měnit velikost, aplikovat efekty nebo použít další standardní možnosti formátování—viz [Picture Frame](/slides/cs/java/picture-frame/). 

{{% /alert %}} 

{{% alert title="Poznámka" color="warning" %}}

Můžete konvertovat obrázky z jednoho formátu do druhého. Viz následující stránky: convert [image to JPG](https://products.aspose.com/slides/cs/java/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/cs/java/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/cs/java/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/cs/java/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/cs/java/conversion/png-to-svg/), and [SVG to PNG](https://products.aspose.com/slides/cs/java/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides podporuje obrázky v populárních formátech, jako jsou JPEG, PNG, BMP, GIF a další. 

## **Přidání obrázků uložených lokálně do snímků**

Můžete přidat jeden nebo více obrázků uložených ve vašem počítači do snímku prezentace. Následující ukázkový kód Java ukazuje, jak přidat obrázek do snímku:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Přidání obrázků z webu do snímků**

Pokud obrázek, který chcete přidat do snímku, není uložen ve vašem počítači, můžete ho přidat přímo z webu. 

Následující ukázkový kód Java ukazuje, jak přidat obrázek z webu do snímku:

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.URL;
import java.net.URLConnection;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    URL imageUrl = new URL("[REPLACE WITH URL]");
    URLConnection connection = imageUrl.openConnection();
    InputStream inputStream = connection.getInputStream();

    ByteArrayOutputStream outputStream = new ByteArrayOutputStream();
    try {
        byte[] buffer = new byte[1024];
        int read;

        while ((read = inputStream.read(buffer, 0, buffer.length)) != -1) {
            outputStream.write(buffer, 0, read);
        }

        outputStream.flush();

        IPPImage image = pres.getImages().addImage(outputStream.toByteArray());
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    } finally {
        if (inputStream != null) inputStream.close();
        outputStream.close();
    }

    pres.save("pres.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

## **Přidání obrázků do hlavních snímků (Slide Masters)**

Hlavní snímek (slide master) ukládá a řídí informace, jako je motiv a rozvržení snímků, které jej používají. Když přidáte obrázek do hlavního snímku, obrázek se objeví na každém snímku založeném na tomto masteru. 

Následující ukázkový kód Java ukazuje, jak přidat obrázek do hlavního snímku:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IMasterSlide masterSlide = slide.getLayoutSlide().getMasterSlide();

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    masterSlide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Přidání obrázků jako pozadí snímků**

Můžete použít obrázek jako pozadí jednoho nebo více snímků. Podrobnosti najdete v *[Setting Images as Backgrounds for Slides](/slides/cs/java/presentation-background/#setting-images-as-background-for-slides)*.

## **Přidání SVG do prezentací**

Obsah SVG lze přidat do prezentace pomocí třídy [SvgImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/svgimage/). Výsledný objekt [ISvgImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isvgimage/) může být poté přidán do kolekce obrázků prezentace a použit k vytvoření rámečku obrázku.

Následující příklad Java importuje samostatný řetězec SVG. Všechny obrázky, styly a další zdroje použité tímto SVG jsou vloženy přímo do obsahu SVG.

```java
import com.aspose.slides.*;

String svgContent =
        "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" +
        "    <rect width='320' height='180' fill='#4F81BD'/>" +
        "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" +
        "</svg>";

Presentation presentation = new Presentation();
try {
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("self-contained-svg.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Import SVG obsahu s externími zdroji**

SVG soubory exportované z nástrojů pro návrh, editorů diagramů, systémů ikon a webových pipeline mohou odkazovat na zdroje, které jsou uloženy mimo dokument SVG. Například SVG může obsahovat odkaz na obrázek jako `images/photo.png`, hodnotu CSS `url(...)` nebo URL písma.

Chcete‑li importovat takový SVG obsah, vytvořte implementaci [IExternalResourceResolver](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iexternalresourceresolver/) a předávejte ji spolu se základní URI do vhodného konstruktoru [SvgImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/svgimage/). Základní URI identifikuje umístění dokumentu SVG a slouží k řešení relativních odkazů.

Rozhraní [ISvgImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isvgimage/) poskytuje přístup k informacím o importovaném SVG:

- `getSvgContent()` vrací SVG značkování jako řetězec.
- `getSvgData()` vrací obsah SVG jako pole bajtů.
- `getBaseUri()` vrací základní URI použité pro relativní odkazy.
- `getExternalResourceResolver()` vrací řešitel přiřazený k obrázku SVG.

### **Implementace externího řešitele zdrojů**

Řešitel má dvě metody:

- `resolveUri` kombinuje základní URI a relativní odkaz na zdroj a vrací absolutní URI. Vrátí `null`, pokud odkaz nelze vyřešit nebo není povolen.
- `getEntity` vrací čitelný stream pro absolutní URI zdroje. Vrátí `null`, pokud zdroj chybí, je blokován nebo není dostupný. Vhodně lze také vrátit náhradní stream.

Následující řešitel načítá propojené zdroje pouze z povoleného místního adresáře. Síťové zdroje a cesty mimo povolený adresář jsou blokovány. Volitelný náhradní obrázek je vrácen pro nevyřešené odkazy na obrázky.

```java
import com.aspose.slides.ExternalResourceResolver;

import java.io.ByteArrayInputStream;
import java.io.InputStream;
import java.net.URI;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Locale;

class LocalSvgResourceResolver extends ExternalResourceResolver {
    private final Path allowedRoot;
    private final byte[] fallbackImageData;

    public LocalSvgResourceResolver(String allowedRoot, byte[] fallbackImageData) {
        this.allowedRoot = Paths.get(allowedRoot).toAbsolutePath().normalize();
        this.fallbackImageData = fallbackImageData;
    }

    @Override
    public String resolveUri(String baseUri, String relativeUri) {
        if (baseUri == null || baseUri.trim().isEmpty() ||
                relativeUri == null || relativeUri.trim().isEmpty()) {
            return null;
        }

        try {
            URI baseAddress = URI.create(baseUri);
            URI absoluteAddress = baseAddress.resolve(relativeUri);

            // Tento řešitel úmyslně povoluje pouze lokální soubory.
            if (!"file".equalsIgnoreCase(absoluteAddress.getScheme())) {
                return null;
            }

            Path resourcePath = Paths.get(absoluteAddress).toAbsolutePath().normalize();
            if (!isInsideAllowedRoot(resourcePath)) {
                return null;
            }

            return resourcePath.toUri().toString();
        } catch (Exception e) {
            return null;
        }
    }

    @Override
    public InputStream getEntity(String absoluteUri) {
        try {
            URI resourceUri = URI.create(absoluteUri);
            if (!"file".equalsIgnoreCase(resourceUri.getScheme())) {
                return null;
            }

            Path resourcePath = Paths.get(resourceUri).toAbsolutePath().normalize();
            if (!isInsideAllowedRoot(resourcePath)) {
                return null;
            }

            if (Files.exists(resourcePath)) {
                return Files.newInputStream(resourcePath);
            }

            // Používejte náhradní soubor pouze pro obrazové zdroje. Vrácení proudu obrázku
            // pro chybějící písmo nebo stylopis by nebylo platné.
            if (fallbackImageData != null && isImageFile(resourcePath)) {
                return new ByteArrayInputStream(fallbackImageData);
            }
        } catch (Exception e) {
            return null;
        }

        return null;
    }

    private boolean isInsideAllowedRoot(Path resourcePath) {
        return resourcePath.normalize().startsWith(allowedRoot);
    }

    private static boolean isImageFile(Path path) {
        String fileName = path.getFileName().toString().toLowerCase(Locale.ROOT);

        return fileName.endsWith(".png") ||
                fileName.endsWith(".jpg") ||
                fileName.endsWith(".jpeg") ||
                fileName.endsWith(".gif") ||
                fileName.endsWith(".bmp");
    }
}
```

### **Řešení odkazovaných zdrojů během importu SVG**

Předpokládejme, že `assets/diagram.svg` obsahuje relativní odkaz, například:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Následující příklad Java předává URI souboru SVG jako základní URI a poskytuje vlastní řešitel. Řešitel převede relativní odkaz na obrázek na absolutní URI a vrátí stream obsahující propojený zdroj, zatímco Aspose.Slides zpracovává SVG.

```java
import com.aspose.slides.*;

import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path svgFilePath = Paths.get("assets", "diagram.svg").toAbsolutePath().normalize();
Path assetDirectory = svgFilePath.getParent();
String svgContent = new String(Files.readAllBytes(svgFilePath), StandardCharsets.UTF_8);

// Základní URI představuje umístění SVG dokumentu.
String baseUri = svgFilePath.toUri().toString();

byte[] fallbackImageData = null;
Path fallbackImagePath = assetDirectory.resolve("fallback.png");
if (Files.exists(fallbackImagePath)) {
    fallbackImageData = Files.readAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory.toString(), fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// ISvgImage poskytuje přístup ke zdrojovému obsahu, binárním datům, základnímu URI a řešiteli.
String importedContent = svgImage.getSvgContent();
byte[] importedData = svgImage.getSvgData();
String importedBaseUri = svgImage.getBaseUri();
IExternalResourceResolver importedResolver = svgImage.getExternalResourceResolver();

Presentation presentation = new Presentation();
try {
    IPPImage image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("svg-with-linked-resources.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Třída `SvgImage` také poskytuje přetížení, která přijímají data SVG jako pole bajtů nebo vstupní stream, spolu s externím řešitelem zdrojů a základním URI.

{{% alert title="Důležité" color="warning" %}}

Řešitel zdrojů zpřístupňuje externí zdroje během zpracování a vykreslování SVG v Aspose.Slides. Nemění původní SVG značkování ani automaticky nevestavuje vyřešené zdroje do něj.

Když je `ISvgImage` přidán do kolekce obrázků prezentace, soubor PPTX může obsahovat jak původní SVG reprezentaci, tak rastrový náhradní obrázek. Propojený zdroj se může objevit v generovaném náhradním obrázku, zatímco relativní odkaz jako `images/photo.png` zůstane nezměněn v uloženém SVG. Aplikace, která vykresluje nativní SVG reprezentaci, může tedy vynechat propojený obsah, pokud není původní externí zdroj dostupný.

{{% /alert %}}

### **Vytvoření přenosného SVG obrázku**

Chcete‑li vytvořit SVG obrázek, který nezávisí na externích souborech, udělejte SVG samostatně před vytvořením `SvgImage`. Například nahraďte propojené URL obrázků `data:` URI, které obsahují data obrázku:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Po vložení všech potřebných zdrojů do obsahu SVG vytvořte `SvgImage`, přidejte jej do kolekce obrázků prezentace a vložte jej do rámečku obrázku, jak je ukázáno v předchozím příkladu.

### **Zpracování chybějících nebo blokovaných zdrojů**

Vrátí `null` z `resolveUri`, pokud je URI zdroje neplatné, zakázané nebo jej nelze vyřešit. Vrátí `null` z `getEntity`, pokud zdroj nelze přečíst. Aspose.Slides pokračuje ve zpracování SVG bez tohoto zdroje, pokud je to možné.

Náhradní stream lze vrátit pro chybějící zdroj, ale jeho obsah musí být kompatibilní s požadovaným typem zdroje. Například vrátíte stream obrázku jen pro chybějící obrázek, ne pro písmo nebo stylopis.

{{% alert title="Bezpečnost" color="warning" %}}

Nevyřešujte libovolné cesty k souborům ani neomezené síťové URL z nedůvěryhodných SVG souborů. Omezte povolená schémata, adresáře a hostitele. Pro síťové zdroje také použijte časová omezení připojení, limity velikosti odpovědi a validaci obsahu.

{{% /alert %}}

## **Konverze SVG na sadu tvarů**

Aspose.Slides může konvertovat SVG na sadu tvarů, podobně jako odpovídající funkčnost v PowerPointu:

![PowerPoint Popup Menu](img_01_01.png)

Tato funkčnost je poskytována přetížením metody [addGroupShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) rozhraní [IShapeCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IShapeCollection), která přijímá objekt [ISvgImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISvgImage) jako první argument.

Následující ukázkový kód Java ukazuje, jak použít tuto metodu k převodu SVG souboru na sadu tvarů:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

// Název zdrojového SVG souboru.
String svgFileName = "sample.svg";

// Název výstupního souboru prezentace.
String outPptxPath = "presentation.pptx";

// Vytvořte novou prezentaci.
IPresentation presentation = new Presentation();
try {
    // Načtěte obsah SVG souboru.
    byte[] svgContent = Files.readAllBytes(Paths.get(svgFileName));

    // Vytvořte objekt SvgImage.
    ISvgImage svgImage = new SvgImage(svgContent);

    // Získejte velikost snímku.
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // Převěďte SVG obrázek na skupinu tvarů a přizpůsobte jej velikosti snímku.
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(
            svgImage, 0f, 0f,
            (float) slideSize.getWidth(), (float) slideSize.getHeight());

    // Uložte prezentaci ve formátu PPTX.
    presentation.save(outPptxPath, SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    presentation.dispose();
}
```

## **Přidání obrázků jako EMF do snímků**

Aspose.Slides pro Java umožňuje generovat EMF obrázky z listů Excelu pomocí Aspose.Cells a přidávat je do snímků prezentace.

Následující ukázkový kód Java ukazuje, jak to provést:

```java
import com.aspose.slides.*;
import com.aspose.cells.ImageOrPrintOptions;
import com.aspose.cells.ImageType;
import com.aspose.cells.SheetRender;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;

Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);

ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

// Uložte sešit do proudu.
SheetRender sr = new SheetRender(sheet, options);
Presentation pres = new Presentation();
try {
    pres.getSlides().removeAt(0);

    String emfSheetName;
    for (int j = 0; j < sr.getPageCount(); j++) {
        emfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, emfSheetName);

        // Přidejte soubor tak, jak je, aby obrázek zůstal vektorovým EMF místo rasterizace.
        IPPImage picture;
        InputStream imageStream = new FileInputStream(emfSheetName);
        try {
            picture = pres.getImages().addImage(imageStream);
        } finally {
            imageStream.close();
        }

        ISlide slide = pres.getSlides().addEmptySlide(
                pres.getLayoutSlides().getByType(SlideLayoutType.Blank));
        slide.getShapes().addPictureFrame(
                ShapeType.Rectangle,
                0,
                0,
                (float) pres.getSlideSize().getSize().getWidth(),
                (float) pres.getSlideSize().getSize().getHeight(),
                picture);
    }

    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

## **Nahrazení obrázků v kolekci obrázků**

Aspose.Slides umožňuje nahradit obrázky uložené v kolekci obrázků prezentace, včetně obrázků používaných tvary snímků. Tato sekce popisuje několik způsobů, jak aktualizovat obrázky v kolekci. Obrázek můžete nahradit pomocí surových bajtových dat, instance [IImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimage/) nebo jiného obrázku, který již v kolekci existuje.

Postupujte podle následujících kroků:

1. Načtěte soubor prezentace, který obsahuje obrázky, pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
1. Načtěte nový obrázek ze souboru do pole bajtů.
1. Nahraďte cílový obrázek novým obrázkem pomocí pole bajtů.
1. Ve druhém přístupu načtěte obrázek do objektu [IImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimage/) a nahraďte cílový obrázek tímto objektem.
1. Ve třetím přístupu nahraďte cílový obrázek obrázkem, který již v kolekci prezentace existuje.
1. Zapište upravenou prezentaci jako soubor PPTX.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
Presentation presentation = new Presentation("sample.pptx");
try {
    // První způsob.
    byte[] imageData = Files.readAllBytes(Paths.get("image0.jpeg"));
    IPPImage oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);

    // Druhý způsob.
    IImage newImage = Images.fromFile("image1.png");
    try {
        oldImage = presentation.getImages().get_Item(1);
        oldImage.replaceImage(newImage);
    } finally {
        if (newImage != null) newImage.dispose();
    }

    // Třetí způsob.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));

    // Uložte prezentaci do souboru.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}

S bezplatným konvertorem Aspose [Text to GIF](https://products.aspose.app/slides/cs/text-to-gif) můžete snadno animovat text a vytvářet GIFy z textu. 

{{% /alert %}}

## **Často kladené otázky**

**Zůstane po vložení zachována původní rozlišení obrázku?**

Ano. Zdrojové pixely jsou zachovány, ale konečný vzhled závisí na tom, jak je [picture](/slides/cs/java/picture-frame/) na snímku škálována a na případné kompresi při ukládání.

**Jak nejlépe nahradit stejné logo na desítkách snímků najednou?**

Umístěte logo na hlavní snímek nebo rozložení a nahraďte ho v kolekci obrázků prezentace — aktualizace se projeví ve všech prvcích, které tento zdroj používají.

**Lze vložený SVG převést na editovatelné tvary?**

Ano. SVG můžete převést na skupinu tvarů, po čemž se jednotlivé části dají upravovat pomocí standardních vlastností tvarů.

**Jak nastavit obrázek jako pozadí pro více snímků najednou?**

[Přiřaďte obrázek jako pozadí](/slides/cs/java/presentation-background/) na hlavním snímku nebo příslušném rozložení — všechny snímky používající tento master/layout zdědí pozadí.

**Jak zabránit tomu, aby se prezentace zvětšila kvůli velkému množství obrázků?**

Znovu použijte jeden zdroj obrázku místo duplikátů, zvolte rozumná rozlišení, aplikujte kompresi při ukládání a udržujte opakovanou grafiku na masteru, pokud je to vhodné.