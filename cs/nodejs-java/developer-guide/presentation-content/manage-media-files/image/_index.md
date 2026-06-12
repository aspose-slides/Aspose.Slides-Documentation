---
title: Optimalizace správy obrázků v prezentacích pomocí JavaScriptu
linktitle: Správa obrázků
type: docs
weight: 10
url: /cs/nodejs-java/image/
keywords:
- přidat obrázek
- přidat obrázek
- přidat bitmapu
- nahradit obrázek
- nahradit obrázek
- z webu
- pozadí
- přidat PNG
- přidat JPG
- přidat SVG
- přidat EMF
- přidat WMF
- přidat TIFF
- PowerPoint
- OpenDocument
- prezentace
- EMF
- SVG
- Node.js
- JavaScript
- Aspose.Slides
description: "Zefektivněte správu obrázků v PowerPointu a OpenDocument pomocí JavaScriptu a Aspose.Slides pro Node.js, optimalizujte výkon a automatizujte svůj pracovní postup."
---
## **Úvod**

Obrázky činí prezentace poutavějšími a zajímavějšími. V Microsoft PowerPoint můžete do snímků vložit obrázky ze souboru, internetu nebo jiných umístění. Podobně Aspose.Slides umožňuje přidávat obrázky do snímků vašich prezentací různými způsoby. 

{{% alert  title="Tip" color="primary" %}} 

Aspose poskytuje bezplatné převodníky — [JPEG do PowerPointu](https://products.aspose.app/slides/cs/import/jpg-to-ppt) a [PNG do PowerPointu](https://products.aspose.app/slides/cs/import/png-to-ppt) — které umožňují rychle vytvářet prezentace z obrázků. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Pokud chcete obrázek přidat jako objekt rámce — zejména pokud plánujete použít standardní možnosti formátování k změně jeho velikosti, přidání efektů atd. — viz [Rámec obrázku](https://docs.aspose.com/slides/cs/nodejs-java/picture-frame/).

{{% /alert %}} 

Aspose.Slides podporuje operace s obrázky v těchto běžných formátech: JPEG, PNG, GIF a dalších. 

## **Přidávání obrázků uložených lokálně do snímků**

Můžete přidat jeden nebo více obrázků z vašeho počítače na snímek v prezentaci. Tento ukázkový kód v JavaScriptu vám ukazuje, jak přidat obrázek na snímek:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Přidávání obrázků ze streamu do snímků**

Pokud obrázek, který chcete přidat na snímek, není dostupný na vašem počítači, můžete jej přidat přímo z webu. 

Tento ukázkový kód vám ukazuje, jak v JavaScriptu přidat obrázek z webu na snímek:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Přistupuje k prvnímu snímku
    var sld = pres.getSlides().get_Item(0);
    // Načte soubor Excel do streamu
    var readStream = fs.readFileSync("book1.xlsx");
    var byteArray = Array.from(readStream);
    // Vytvoří datový objekt pro vložení
    var dataInfo = new aspose.slides.OleEmbeddedDataInfo(java.newArray("byte", byteArray), "xlsx");
    // Přidá tvar Ole Object Frame
    var oleObjectFrame = sld.getShapes().addOleObjectFrame(0, 0, pres.getSlideSize().getSize().getWidth(), pres.getSlideSize().getSize().getHeight(), dataInfo);
    // Zapíše soubor PPTX na disk
    pres.save("OleEmbed_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Přidávání obrázků do hlavních snímků (Slide Masters)**

Hlavní snímek je vrchní snímek, který ukládá a řídí informace (téma, rozložení atd.) o všech snímcích pod ním. Když tedy přidáte obrázek do hlavního snímku, tento obrázek se zobrazí na každém snímku pod tímto hlavním snímkem. 

Tento ukázkový kód v JavaScriptu vám ukazuje, jak přidat obrázek do hlavního snímku:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var masterSlide = slide.getLayoutSlide().getMasterSlide();
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    masterSlide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Přidávání obrázků jako pozadí snímku**

Můžete se rozhodnout použít obrázek jako pozadí pro konkrétní snímek nebo několik snímků. V takovém případě se podívejte na *[Nastavení obrázků jako pozadí snímků](https://docs.aspose.com/slides/cs/nodejs-java/presentation-background/#setting-images-as-background-for-slides)*.

## **Přidávání SVG do prezentací**
Můžete přidat nebo vložit libovolný obrázek do prezentace pomocí metody [addPictureFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) patřící do třídy [ShapeCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ShapeCollection).

Pro vytvoření objektu obrázku na základě SVG můžete postupovat takto:

1. Vytvořte objekt SvgImage, který vložíte do ImageShapeCollection  
2. Vytvořte objekt PPImage z ISvgImage  
3. Vytvořte objekt PictureFrame pomocí třídy PPImage  

Tento ukázkový kód vám ukazuje, jak implementovat výše uvedené kroky a přidat SVG obrázek do prezentace:
```javascript
// Vytvořte instanci třídy Presentation, která představuje soubor PPTX
var pres = new aspose.slides.Presentation();
try {
    var svgContent = java.newInstanceSync("java.lang.String", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "image.svg")));
    var svgImage = new aspose.slides.SvgImage(svgContent);
    var ppImage = pres.getImages().addImage(svgImage);
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, ppImage.getWidth(), ppImage.getHeight(), ppImage);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Převod SVG na sadu tvarů**
Převod SVG na sadu tvarů v Aspose.Slides je podobný funkci PowerPointu používané pro práci s SVG obrázky:

![PowerPoint Popup Menu](img_01_01.png)

Funkčnost je poskytována jedním z přetížení metody [addGroupShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ShapeCollection#addGroupShape-aspose.slides.ISvgImage-float-float-float-float-) třídy [ShapeCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ShapeCollection), která jako první argument přijímá objekt [SvgImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SvgImage).

Tento ukázkový kód vám ukazuje, jak použít popsanou metodu k převodu SVG souboru na sadu tvarů:

```javascript
// Vytvořte novou prezentaci
var presentation = new aspose.slides.Presentation();
try {
    // Načtěte obsah souboru SVG
    var svgContent = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "image.svg"));
    // Vytvořte objekt SvgImage
    var svgImage = new aspose.slides.SvgImage(svgContent);
    // Získejte velikost snímku
    var slideSize = presentation.getSlideSize().getSize();
    // Převést SVG obrázek na skupinu tvarů a přizpůsobit jej velikosti snímku
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(svgImage, 0.0, 0.0, slideSize.getWidth(), slideSize.getHeight());
    // Uložte prezentaci ve formátu PPTX
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Přidávání obrázků jako EMF do snímků**
Aspose.Slides pro Node.js přes Java umožňuje generovat EMF obrázky z listů Excelu a přidávat je jako EMF do snímků pomocí Aspose.Cells.  

Tento ukázkový kód vám ukazuje, jak provést popsaný úkol:

```javascript
var book = java.newInstanceSync("aspose.cells.Workbook", "chart.xlsx");
var sheet = book.getWorksheets().get(0);
var options = java.newInstanceSync("aspose.cells.ImageOrPrintOptions");
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(java.getStaticFieldValue("ImageType", "EMF"));
// Save the workbook to stream
var sr = java.newInstanceSync("SheetRender", sheet, options);
var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().removeAt(0);
    var EmfSheetName = "";
    for (var j = 0; j < sr.getPageCount(); j++) {
        EmfSheetName = ((("test" + sheet.getName()) + " Page") + (j + 1)) + ".out.emf";
        sr.toImage(j, EmfSheetName);
        var picture;
        var image = aspose.slides.Images.fromFile(EmfSheetName);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) {
                image.dispose();
            }
        }
        var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank));
        var m = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, pres.getSlideSize().getSize().getWidth(), pres.getSlideSize().getSize().getHeight(), picture);
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Nahrazování obrázků v kolekci obrázků**

Aspose.Slides umožňuje nahradit obrázky uložené v kolekci obrázků prezentace (včetně těch používaných tvary snímků). Tato část ukazuje několik přístupů k aktualizaci obrázků v kolekci. API poskytuje jednoduché metody pro nahrazení obrázku pomocí surových bajtových dat, instance [IImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/iimage/) nebo jiného obrázku, který již v kolekci existuje.

Postupujte podle následujících kroků:

1. Načtěte soubor prezentace obsahující obrázky pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/).  
2. Načtěte nový obrázek ze souboru do pole bajtů.  
3. Nahraďte cílový obrázek novým obrázkem pomocí pole bajtů.  
4. Ve druhém přístupu načtěte obrázek do objektu [IImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/iimage/) a nahraďte cílový obrázek tímto objektem.  
5. Ve třetím přístupu nahraďte cílový obrázek obrázkem, který již v kolekci prezentace existuje.  
6. Uložte upravenou prezentaci jako soubor PPTX.

```js
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // První způsob.
    const imageData = java.newArray("byte", Array.from(fs.readFileSync("image0.jpeg")));
    let oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);
    
    // Druhý způsob.
    const newImage = aspose.slides.Images.fromFile("image1.png");
    oldImage = presentation.getImages().get_Item(1);
    oldImage.replaceImage(newImage);
    newImage.dispose();
    
    // Třetí způsob.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));
    
    // Uložte prezentaci do souboru.
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}

Pomocí bezplatného konvertoru Aspose FREE [Text to GIF](https://products.aspose.app/slides/cs/text-to-gif) můžete snadno animovat texty, vytvářet GIFy z textu atd. 

{{% /alert %}}

## **Často kladené otázky**

**Zůstane po vložení zachována původní rozlišení obrázku?**

Ano. Původní pixely jsou zachovány, ale konečný vzhled závisí na tom, jak je [obrázek](/slides/cs/nodejs-java/picture-frame/) na snímku škálován a na případné kompresi při uložení.

**Jak nejlépe nahradit stejné logo na desítkách snímků najednou?**

Umístěte logo na hlavní snímek nebo rozložení a nahraďte jej v kolekci obrázků prezentace — aktualizace se projeví ve všech prvcích, které používají tento zdroj.

**Lze vložený SVG převést na editovatelné tvary?**

Ano. SVG lze převést na skupinu tvarů, po čemž se jednotlivé části stanou editovatelnými pomocí standardních vlastností tvarů.

**Jak nastavit obrázek jako pozadí pro více snímků najednou?**

[Zvolte obrázek jako pozadí](/slides/cs/nodejs-java/presentation-background/) na hlavním snímku nebo příslušném rozložení — všechny snímky používající tento hlavní snímek/rozložení pozadí zdědí.

**Jak zabránit „nafouknutí“ velikosti prezentace kvůli mnoha obrázkům?**

Znovu použijte jeden zdroj obrázku místo duplicit, zvolte rozumná rozlišení, aplikujte kompresi při uložení a opakovanou grafiku umístěte na hlavní snímek, kde je to vhodné.