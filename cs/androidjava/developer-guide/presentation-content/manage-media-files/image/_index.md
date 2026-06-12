---
title: Optimalizace správy obrázků v prezentacích na Androidu
linktitle: Správa obrázků
type: docs
weight: 10
url: /cs/androidjava/image/
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
- Android
- Java
- Aspose.Slides
description: "Zjednodušte správu obrázků v PowerPoint a OpenDocument pomocí Aspose.Slides pro Android via Java, optimalizujte výkon a automatizujte svůj workflow."
---
## **Úvod**

Obrázky činí prezentace poutavějšími a zajímavějšími. V Microsoft PowerPoint můžete do snímků vkládat obrázky ze souboru, z internetu nebo jiných míst. Podobně Aspose.Slides umožňuje přidávat obrázky do snímků vašich prezentací různými postupy. 

{{% alert  title="Tip" color="primary" %}} 

Aspose poskytuje bezplatné konvertory — [JPEG do PowerPoint](https://products.aspose.app/slides/cs/import/jpg-to-ppt) a [PNG do PowerPoint](https://products.aspose.app/slides/cs/import/png-to-ppt) — které lidem umožňují rychle vytvořit prezentace z obrázků. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Pokud chcete přidat obrázek jako objekt rámce — zejména pokud plánujete použít standardní možnosti formátování k změně velikosti, přidání efektů a podobně — viz [Rámec obrázku](https://docs.aspose.com/slides/cs/androidjava/picture-frame/).

{{% /alert %}} 

Aspose.Slides podporuje operace s obrázky v těchto populárních formátech: JPEG, PNG, GIF a další. 

## **Přidání lokálně uložených obrázků do snímků**

Můžete přidat jeden nebo více obrázků z vašeho počítače na snímek v prezentaci. Tento ukázkový kód v Java ukazuje, jak přidat obrázek na snímek:

```java
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
	if (pres != null) pres.dispose();
}
```

## **Přidání obrázků z webu do snímků**

Pokud obrázek, který chcete přidat na snímek, není k dispozici ve vašem počítači, můžete jej přidat přímo z webu. 

Tento ukázkový kód ukazuje, jak přidat obrázek z webu na snímek v Java:

```java
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

		while ((read = inputStream.read(buffer, 0, buffer.length)) != -1)
			outputStream.write(buffer, 0, read);

		outputStream.flush();

		IPPImage image = pres.getImages().addImage(outputStream.toByteArray());
		slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
	} finally {
		if (inputStream != null) inputStream.close();
		outputStream.close();
	}

	pres.save("pres.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

## **Přidání obrázků do hlavních snímků (Slide Masters)**

Hlavní snímek (slide master) je nejvyšší snímek, který ukládá a řídí informace (téma, rozložení atd.) o všech snímcích pod ním. Když tedy přidáte obrázek do hlavního snímku, tento obrázek se zobrazí na každém snímku pod tímto hlavním snímkem. 

Tento ukázkový kód v Java ukazuje, jak přidat obrázek do hlavního snímku:

```java
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
	if (pres != null) pres.dispose();
}
```

## **Přidání obrázků jako pozadí snímků**

Můžete se rozhodnout použít obrázek jako pozadí konkrétního snímku nebo několika snímků. V takovém případě se podívejte na *[Nastavení obrázků jako pozadí snímků](https://docs.aspose.com/slides/cs/androidjava/presentation-background/#setting-images-as-background-for-slides)*.

## **Přidání SVG do prezentací**
Můžete přidat nebo vložit jakýkoli obrázek do prezentace pomocí metody [addPictureFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) patřící do rozhraní [IShapeCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IShapeCollection).

Pro vytvoření objektu obrázku založeného na SVG můžete postupovat takto:

1. Vytvořte objekt SvgImage, který vložíte do ImageShapeCollection
2. Vytvořte objekt PPImage z ISvgImage
3. Vytvořte objekt PictureFrame pomocí rozhraní IPPImage

Tento ukázkový kód ukazuje, jak implementovat výše uvedené kroky pro přidání SVG obrázku do prezentace:
```java 
// Vytvořte instanci třídy Presentation, která představuje soubor PPTX
Presentation pres = new Presentation();
try {
    String svgContent = new String(Files.readAllBytes(Paths.get("image.svg")));
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage ppImage = pres.getImages().addImage(svgImage);
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 
			ppImage.getWidth(), ppImage.getHeight(), ppImage);
    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Převod SVG na sadu tvarů**
Převod SVG na sadu tvarů v Aspose.Slides je podobný funkci PowerPointu používané pro práci s SVG obrázky:

![Vyskakovací nabídka PowerPoint](img_01_01.png)

Funkčnost je poskytována jedním z přetížených metod [addGroupShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) rozhraní [IShapeCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IShapeCollection), která přijímá objekt [ISvgImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISvgImage) jako první argument.

Tento ukázkový kód ukazuje, jak použít popsanou metodu k převodu SVG souboru na sadu tvarů:

```java 
    // Vytvořte novou prezentaci
    IPresentation presentation = new Presentation();
    try {
        // Načtěte obsah SVG souboru
        byte[] svgContent = Files.readAllBytes(Paths.get("image.svg"));

        // Vytvořte objekt SvgImage
        ISvgImage svgImage = new SvgImage(svgContent);

        // Získejte velikost snímku
        Dimension2D slideSize = presentation.getSlideSize().getSize();

        // Převod SVG obrázku na skupinu tvarů a jeho škálování na velikost snímku
        presentation.getSlides().get_Item(0).getShapes().
                addGroupShape(svgImage, 0f, 0f, (float)slideSize.getWidth(), (float)slideSize.getHeight());

        // Uložte prezentaci ve formátu PPTX
        presentation.save("output.pptx", SaveFormat.Pptx);
    } catch (IOException e) {
    } finally {
        if (presentation != null) presentation.dispose();
    }
```

## **Přidání obrázků jako EMF do snímků**
Aspose.Slides for Android via Java vám umožňuje generovat EMF obrázky z listů Excelu a přidávat je jako EMF do snímků pomocí Aspose.Cells.  

Tento ukázkový kód ukazuje, jak provést popsaný úkol:

```java 
Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);
ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

//Uložte sešit do streamu
SheetRender sr = new SheetRender(sheet, options);
Presentation pres = new Presentation();
try {
    pres.getSlides().removeAt(0);
    
    String EmfSheetName = "";
    for (int j = 0; j < sr.getPageCount(); j++)
    {
    
        EmfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, EmfSheetName);

        IPPImage picture;
        IImage image = Images.fromFile(EmfSheetName);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
        ISlide slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().getByType(SlideLayoutType.Blank));
        IShape m = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0,
					(float)pres.getSlideSize().getSize().getWidth(), 
					(float)pres.getSlideSize().getSize().getHeight(), 
					picture);
    }
    
    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Nahrazení obrázků v kolekci obrázků**

Aspose.Slides vám umožňuje nahradit obrázky uložené v kolekci obrázků prezentace (včetně těch, které používají tvary snímků). Tato sekce ukazuje několik přístupů k aktualizaci obrázků v kolekci. API poskytuje přímé metody pro nahrazení obrázku pomocí surových bajtových dat, instance [IImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimage/) nebo jiného obrázku, který již v kolekci existuje.

Postupujte podle následujících kroků:

1. Načtěte soubor prezentace obsahující obrázky pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/).
1. Načtěte nový obrázek ze souboru do pole bajtů.
1. Nahraďte cílový obrázek novým obrázkem pomocí pole bajtů.
1. Ve druhém přístupu načtěte obrázek do objektu [IImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimage/) a nahraďte cílový obrázek tímto objektem.
1. Ve třetím přístupu nahraďte cílový obrázek obrázkem, který již v kolekci prezentace existuje.
1. Uložte upravenou prezentaci jako soubor PPTX.

```java
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
Presentation presentation = new Presentation("sample.pptx");
try {
    // První způsob.
    IImage imageData = Images.fromStream(new FileInputStream("image0.jpeg"));
    IPPImage oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);
    
    // Druhý způsob.
    IImage newImage = Images.fromFile("image1.png");
    oldImage = presentation.getImages().get_Item(1);
    oldImage.replaceImage(newImage);
    newImage.dispose();
    
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

Pomocí Aspose FREE [Text to GIF](https://products.aspose.app/slides/cs/text-to-gif) konvertoru můžete snadno animovat texty, vytvářet GIFy z textů atd. 

{{% /alert %}}

## **Často kladené otázky**

**Zůstane původní rozlišení obrázku po vložení zachováno?**

Ano. Původní pixely jsou zachovány, ale konečný vzhled závisí na tom, jak je [obrázek](/slides/cs/androidjava/picture-frame/) na snímku měněn a jaká komprese je použita při uložení.

**Jaký je nejlepší způsob, jak najednou nahradit stejné logo na desítky snímků?**

Umístěte logo na hlavní snímek nebo rozložení a nahraďte jej v kolekci obrázků prezentace — aktualizace se projeví ve všech prvcích, které tento zdroj používají.

**Lze vložený SVG převést na editovatelné tvary?**

Ano. SVG můžete převést na skupinu tvarů, po čemž se jednotlivé části stanou editovatelnými pomocí standardních vlastností tvarů.

**Jak nastavit obrázek jako pozadí pro více snímků najednou?**

[ přiřaďte obrázek jako pozadí](/slides/cs/androidjava/presentation-background/) na hlavní snímek nebo odpovídající rozložení — všechny snímky používající tento hlavní snímek/rozložení pozadí zdědí.

**Jak zabránit „nafouknutí“ velikosti prezentace kvůli mnoha obrázkům?**

Znovu použijte jeden zdroj obrázku místo duplicit, zvolte rozumné rozlišení, aplikujte kompresi při uložení a opakující se grafiku umístěte na hlavní snímek, kde je to vhodné.