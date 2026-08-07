---
title: "Optimalizace správy obrázků v prezentacích pomocí JavaScriptu"
linktitle: "Správa obrázků"
type: docs
weight: 10
url: /cs/nodejs-java/image/
keywords:
- "přidat obrázek"
- "přidat obrázek"
- "přidat bitmapu"
- "nahradit obrázek"
- "nahradit obrázek"
- "z webu"
- "pozadí"
- "přidat PNG"
- "přidat JPG"
- "přidat SVG"
- "externí SVG zdroje"
- "SVG řešič"
- "propojené SVG obrázky"
- "SVG písma"
- "přidat EMF"
- "přidat WMF"
- "přidat TIFF"
- "PowerPoint"
- "OpenDocument"
- "prezentace"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Zjednodušte správu obrázků v PowerPointu a OpenDocumentu pomocí Aspose.Slides pro Node.js přes Java, optimalizujte výkon a automatizujte svůj pracovní postup."
---
## **Úvod**

Obrázky činí prezentace poutavějšími a vizuálně atraktivnějšími. V Microsoft PowerPoint můžete vkládat obrázky na snímky ze souborů, z internetu nebo z jiných zdrojů. Podobně Aspose.Slides umožňuje přidávat obrázky do snímků prezentace několika způsoby.

{{% alert  title="Tip" color="primary" %}} 
Aspose poskytuje bezplatné převodníky — [JPEG to PowerPoint](https://products.aspose.app/slides/cs/import/jpg-to-ppt) a [PNG to PowerPoint](https://products.aspose.app/slides/cs/import/png-to-ppt) — které vám umožní rychle vytvářet prezentace z obrázků. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
Pokud chcete přidat obrázek jako rámeček obrázku — zejména pokud jej chcete měnit velikost, aplikovat efekty nebo použít jiné standardní možnosti formátování — podívejte se na [Picture Frame](/slides/cs/nodejs-java/picture-frame/). 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
Můžete převádět obrázky z jednoho formátu do druhého. Viz následující stránky: převod [image to JPG](https://products.aspose.com/slides/cs/nodejs-java/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/cs/nodejs-java/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/cs/nodejs-java/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/cs/nodejs-java/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/cs/nodejs-java/conversion/png-to-svg/), a [SVG to PNG](https://products.aspose.com/slides/cs/nodejs-java/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides podporuje obrázky v populárních formátech, jako jsou JPEG, PNG, BMP, GIF a další. 

## **Přidání obrázků uložených lokálně do snímků**

Můžete přidat jeden nebo více obrázků uložených ve vašem počítači do snímku prezentace. Následující ukázkový kód v JavaScriptu ukazuje, jak přidat obrázek do snímku:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);

    let picture;
    const image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }

    slide.getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Přidání obrázků z webu do snímků**

Pokud obrázek, který chcete přidat do snímku, není uložen ve vašem počítači, můžete jej přidat přímo z webu. 

Následující ukázkový kód v JavaScriptu ukazuje, jak přidat obrázek z webu do snímku:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);

    const imageUrl = java.newInstanceSync("java.net.URL", "[REPLACE WITH URL]");
    const inputStream = imageUrl.openStream();
    try {
        let picture;
        const image = aspose.slides.Images.fromStream(inputStream);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) {
                image.dispose();
            }
        }

        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    } finally {
        if (inputStream != null) {
            inputStream.close();
        }
    }

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Přidání obrázků do hlavních snímků (Slide Masters)**

Hlavní snímek (slide master) ukládá a řídí informace, jako je motiv a rozvržení pro snímky, které jej používají. Když přidáte obrázek do hlavního snímku, obrázek se zobrazí na každém snímku založeném na tomto masteru. 

Následující ukázkový kód v JavaScriptu ukazuje, jak přidat obrázek do hlavního snímku:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);
    const masterSlide = slide.getLayoutSlide().getMasterSlide();

    let picture;
    const image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }

    masterSlide.getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Přidání obrázků jako pozadí snímků**

Můžete použít obrázek jako pozadí pro jeden nebo více snímků. Podrobnosti najdete v *[Setting Images as Backgrounds for Slides](/slides/cs/nodejs-java/presentation-background/#setting-images-as-background-for-slides)*.

## **Přidání SVG do prezentací**

Obsah SVG lze přidat do prezentace pomocí třídy [SvgImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/svgimage/). Výsledný objekt SVG obrázku může být následně přidán do kolekce obrázků prezentace a použit k vytvoření rámečku obrázku. 

Následující příklad v JavaScriptu importuje samostatný řetězec SVG. Všechny obrázky, styly a další zdroje použité tímto SVG jsou vloženy přímo do obsahu SVG.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const svgContent =
    "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" +
    "    <rect width='320' height='180' fill='#4F81BD'/>" +
    "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" +
    "</svg>";

const presentation = new aspose.slides.Presentation();
try {
    const svgImage = new aspose.slides.SvgImage(svgContent);
    const image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle,
        20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("self-contained-svg.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Importování SVG obsahu s externími zdroji**

SVG soubory exportované z nástrojů pro design, diagramových editorů, ikonosystémů a webových pipeline mohou odkazovat na zdroje, které jsou uloženy mimo SVG dokument. Například SVG může obsahovat odkaz na obrázek jako `images/photo.png`, CSS hodnotu `url(...)` nebo URL písma. 

Pro import takového SVG obsahu poskytněte externí řešič zdrojů a předávejte jej spolu se základní URI do vhodného konstruktoru [SvgImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/svgimage/). Základní URI určuje umístění SVG dokumentu a používá se k řešení relativních odkazů. 

Třída `SvgImage` poskytuje přístup k informacím o importovaném SVG:

- `getSvgContent()` vrací SVG značkování jako řetězec. 
- `getSvgData()` vrací obsah SVG jako pole bytů. 
- `getBaseUri()` vrací základní URI používané pro relativní odkazy. 
- `getExternalResourceResolver()` vrací řešič přiřazený k SVG obrázku. 

### **Implementace externího řešiče zdrojů**

Řešič má dvě metody:

- `resolveUri` kombinuje základní URI a relativní odkaz na zdroj a vrací absolutní URI. Vrátí `null`, pokud odkaz nelze vyřešit nebo není povolen. 
- `getEntity` vrací čitelný Java stream pro absolutní URI zdroje. Vrátí `null`, pokud je zdroj chybějící, zablokovaný nebo nedostupný. Vhodně může být také vrácen náhradní stream. 

Následující pomocná funkce vytváří řešič, který načítá propojené zdroje pouze z povoleného lokálního adresáře. Síťové zdroje a cesty mimo povolený adresář jsou blokovány. Volitelný náhradní obrázek je vrácen pro nevyřešené odkazy na obrázky.

```javascript
const fs = require("fs");
const path = require("path");
const java = require("java");
const { fileURLToPath, pathToFileURL } = require("url");

function isInsideAllowedRoot(resourcePath, allowedRoot) {
    const relativePath = path.relative(allowedRoot, resourcePath);

    return relativePath === "" ||
        (relativePath !== ".." &&
         !relativePath.startsWith(".." + path.sep) &&
         !path.isAbsolute(relativePath));
}

function isImageFile(filePath) {
    const extension = path.extname(filePath).toLowerCase();
    return [".png", ".jpg", ".jpeg", ".gif", ".bmp"].includes(extension);
}

function createLocalSvgResourceResolver(allowedRoot, fallbackImageData) {
    const normalizedRoot = path.resolve(allowedRoot);

    return java.newProxy("com.aspose.slides.IExternalResourceResolver", {
        resolveUri: function(baseUri, relativeUri) {
            if (baseUri == null || baseUri.trim() === "" ||
                    relativeUri == null || relativeUri.trim() === "") {
                return null;
            }

            try {
                const absoluteAddress = new URL(relativeUri, baseUri);

                // Tento řešič úmyslně povoluje pouze místní soubory.
                if (absoluteAddress.protocol !== "file:") {
                    return null;
                }

                const resourcePath = path.resolve(fileURLToPath(absoluteAddress));
                if (!isInsideAllowedRoot(resourcePath, normalizedRoot)) {
                    return null;
                }

                return pathToFileURL(resourcePath).href;
            } catch (e) {
                return null;
            }
        },

        getEntity: function(absoluteUri) {
            try {
                const resourceUrl = new URL(absoluteUri);
                if (resourceUrl.protocol !== "file:") {
                    return null;
                }

                const resourcePath = path.resolve(fileURLToPath(resourceUrl));
                if (!isInsideAllowedRoot(resourcePath, normalizedRoot)) {
                    return null;
                }

                if (fs.existsSync(resourcePath)) {
                    return java.newInstanceSync("java.io.FileInputStream", resourcePath);
                }

                // Použít náhradní řešení pouze pro obrazové zdroje. Vrácení proudu obrázku
                // pro chybějící písmo nebo stylopis by nebylo platné.
                if (fallbackImageData != null && isImageFile(resourcePath)) {
                    const javaBytes = java.newArray("byte", Array.from(fallbackImageData));
                    return java.newInstanceSync("java.io.ByteArrayInputStream", javaBytes);
                }
            } catch (e) {
                return null;
            }

            return null;
        }
    });
}
```

### **Řešení propojených zdrojů během importu SVG**

Předpokládejme, že `assets/diagram.svg` obsahuje relativní odkaz, například:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Následující příklad v JavaScriptu předává URI souboru SVG jako základní URI a poskytuje vlastní řešič. Řešič převádí relativní odkaz na obrázek na absolutní URI a vrací stream obsahující propojený zdroj, zatímco Aspose.Slides zpracovává SVG.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");
const { pathToFileURL } = require("url");

const svgFilePath = path.resolve("assets", "diagram.svg");
const assetDirectory = path.dirname(svgFilePath);
const svgContent = fs.readFileSync(svgFilePath, "utf8");

// Základní URI představuje umístění SVG dokumentu.
const baseUri = pathToFileURL(svgFilePath).href;

let fallbackImageData = null;
const fallbackImagePath = path.join(assetDirectory, "fallback.png");
if (fs.existsSync(fallbackImagePath)) {
    fallbackImageData = fs.readFileSync(fallbackImagePath);
}

const resolver = createLocalSvgResourceResolver(assetDirectory, fallbackImageData);
const svgImage = new aspose.slides.SvgImage(svgContent, resolver, baseUri);

// SvgImage poskytuje zdrojový obsah, binární data, základní URI a řešič.
const importedContent = svgImage.getSvgContent();
const importedData = svgImage.getSvgData();
const importedBaseUri = svgImage.getBaseUri();
const importedResolver = svgImage.getExternalResourceResolver();

const presentation = new aspose.slides.Presentation();
try {
    const image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle,
        20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("svg-with-linked-resources.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Třída `SvgImage` také poskytuje přetícení, která přijímají data SVG jako pole bytů, stejně jako tovární metody založené na streamech, spolu s externím řešičem zdrojů a základním URI.

{{% alert title="Important" color="warning" %}}
Řešič zdrojů zpřístupňuje externí zdroje během toho, kdy Aspose.Slides zpracovává a vykresluje SVG. Nemění původní SVG značkování ani automaticky nevkládá vyřešené zdroje do něj. 

Když je SVG obrázek přidán do kolekce obrázků prezentace, soubor PPTX může obsahovat jak původní SVG reprezentaci, tak rasterovou náhradní obrázek. Propojený zdroj se může objevit v generovaném náhradním obrázku, zatímco relativní odkaz, jako `images/photo.png`, zůstane v uloženém SVG nezměněn. Aplikace, která vykresluje nativní SVG reprezentaci, může taktéž vynechat propojený obsah, pokud není k dispozici původní externí zdroj. 
{{% /alert %}}

### **Vytvoření přenosného SVG obrázku**

Pro vytvoření SVG obrázku, který nezávisí na externích souborech, udělejte SVG samostatným před vytvořením `SvgImage`. Například nahraďte odkazy na obrázky URL typu `data:` URI, které obsahují data obrázku:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Po vložení všech potřebných zdrojů do obsahu SVG vytvořte `SvgImage`, přidejte jej do kolekce obrázků prezentace a vložte jej do rámečku obrázku, jak je ukázáno v předchozím příkladu. 

### **Zpracování chybějících nebo blokovaných zdrojů**

Vrátí `null` z `resolveUri`, když je URI zdroje neplatné, zakázané nebo jej nelze vyřešit. Vrátí `null` z `getEntity`, když zdroj nelze přečíst. Aspose.Slides pokračuje ve zpracování SVG bez tohoto zdroje, pokud je to možné. 

Pro chybějící zdroj může být vrácen náhradní stream, ale jeho obsah musí být kompatibilní s požadovaným typem zdroje. Například vracejte stream obrázku jen pro chybějící obrázek, ne pro písmo nebo stylopis. 

{{% alert title="Security" color="warning" %}}
Nevyřešujte libovolné souborové cesty ani neomezené síťové URL z nedůvěryhodných SVG souborů. Omezte povolené schémata, adresáře a hosty. Pro síťové zdroje také použijte časová omezení připojení, limity velikosti odpovědi a validaci obsahu. 
{{% /alert %}}

## **Převod SVG na sadu tvarů**

Aspose.Slides může převést SVG na sadu tvarů, podobně jako odpovídající funkce v PowerPointu:

![PowerPoint Popup Menu](img_01_01.png)

Tato funkce je poskytována přetíčením metody [addGroupShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ShapeCollection#addGroupShape-aspose.slides.ISvgImage-float-float-float-float-) třídy [ShapeCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ShapeCollection), která přijímá objekt SVG obrázku jako svůj první argument. 

Následující ukázkový kód v JavaScriptu ukazuje, jak použít tuto metodu k převodu SVG souboru na sadu tvarů:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

// Název zdrojového SVG souboru.
const svgFileName = "sample.svg";

// Název výstupního souboru prezentace.
const outPptxPath = "presentation.pptx";

// Vytvořit novou prezentaci.
const presentation = new aspose.slides.Presentation();
try {
    // Načíst obsah SVG souboru.
    const svgContent = java.newArray("byte", Array.from(fs.readFileSync(svgFileName)));

    // Vytvořit objekt SvgImage.
    const svgImage = new aspose.slides.SvgImage(svgContent);

    // Získat velikost snímku.
    const slideSize = presentation.getSlideSize().getSize();

    // Převést SVG obrázek na skupinu tvarů a přizpůsobit jej velikosti snímku.
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(
        svgImage, 0.0, 0.0, slideSize.getWidth(), slideSize.getHeight());

    // Uložit prezentaci ve formátu PPTX.
    presentation.save(outPptxPath, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Přidání obrázků jako EMF do snímků**

Aspose.Slides pro Node.js přes Java vám umožňuje generovat EMF obrázky z listů Excelu pomocí Aspose.Cells a přidávat je do snímků prezentace. 

Následující ukázkový kód v JavaScriptu ukazuje, jak to provést:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const book = java.newInstanceSync("aspose.cells.Workbook", "chart.xlsx");
const sheet = book.getWorksheets().get(0);

const options = java.newInstanceSync("aspose.cells.ImageOrPrintOptions");
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(java.getStaticFieldValue("ImageType", "EMF"));

// Uložit sešit do proudu.
const sr = java.newInstanceSync("SheetRender", sheet, options);
const pres = new aspose.slides.Presentation();
try {
    pres.getSlides().removeAt(0);

    for (let j = 0; j < sr.getPageCount(); j++) {
        const emfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, emfSheetName);

        // Přidat soubor tak, jak je, aby obrázek zůstal vektorovým EMF místo rasterizace.
        let picture;
        const imageStream = java.newInstanceSync("java.io.FileInputStream", emfSheetName);
        try {
            picture = pres.getImages().addImage(imageStream);
        } finally {
            imageStream.close();
        }

        const slide = pres.getSlides().addEmptySlide(
            pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank));
        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle,
            0,
            0,
            pres.getSlideSize().getSize().getWidth(),
            pres.getSlideSize().getSize().getHeight(),
            picture);
    }

    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Nahrazení obrázků v kolekci obrázků**

Aspose.Slides vám umožňuje nahradit obrázky uložené v kolekci obrázků prezentace, včetně obrázků používaných tvary snímků. Tato sekce popisuje několik způsobů, jak aktualizovat obrázky v kolekci. Můžete nahradit obrázek pomocí surových bajtových dat, instance [IImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/iimage/) nebo jiného obrázku, který již v kolekci existuje. 

Postupujte podle následujících kroků:

1. Načtěte soubor prezentace, který obsahuje obrázky, pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/).  
2. Načtěte nový obrázek ze souboru do pole bajtů.  
3. Nahraďte cílový obrázek novým obrázkem pomocí pole bajtů.  
4. Ve druhém přístupu načtěte obrázek do objektu [IImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/iimage/) a nahraďte cílový obrázek tímto objektem.  
5. Ve třetím přístupu nahraďte cílový obrázek obrázkem, který již v kolekci obrázků prezentace existuje.  
6. Zapište upravenou prezentaci jako soubor PPTX.  

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // První způsob.
    const imageData = java.newArray("byte", Array.from(fs.readFileSync("image0.jpeg")));
    let oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);

    // Druhý způsob.
    const newImage = aspose.slides.Images.fromFile("image1.png");
    try {
        oldImage = presentation.getImages().get_Item(1);
        oldImage.replaceImage(newImage);
    } finally {
        if (newImage != null) {
            newImage.dispose();
        }
    }

    // Třetí způsob.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));

    // Uložit prezentaci do souboru.
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
S bezplatným převodníkem [Text to GIF](https://products.aspose.app/slides/cs/text-to-gif) od Aspose můžete snadno animovat text a vytvářet GIFy z textu. 
{{% /alert %}}

## **Často kladené otázky**

**Zůstane po vložení zachováno původní rozlišení obrázku?**

Ano. Původní pixely jsou zachovány, ale konečný vzhled závisí na tom, jak je [picture](/slides/cs/nodejs-java/picture-frame/) na snímku škálováno a na případné kompresi při uložení.

**Jaký je nejlepší způsob, jak najednou nahradit stejné logo na desítkách snímků?**

Umístěte logo na hlavní snímek (master) nebo rozvržení a nahraďte ho v kolekci obrázků prezentace — aktualizace se rozšíří na všechny prvky, které tento zdroj používají.

**Lze vložený SVG převést na editovatelné tvary?**

Ano. Můžete převést SVG na skupinu tvarů, po čemž se jednotlivé části stanou editovatelnými pomocí standardních vlastností tvarů.

**Jak mohu nastavit obrázek jako pozadí pro více snímků najednou?**

[Přiřaďte obrázek jako pozadí](/slides/cs/nodejs-java/presentation-background/) na hlavní snímek nebo příslušné rozvržení — všechny snímky používající tento master/rozvržení zdědí pozadí.

**Jak zabránit, aby se prezentace kvůli mnoha obrázkům stala příliš velkou?**

Znovu použijte jeden obrázkový zdroj místo duplicit, zvolte rozumná rozlišení, aplikujte kompresi při ukládání a opakovanou grafiku umístěte na hlavní snímek, kde je to vhodné.