---
title: Optimalizace správy obrázků v prezentacích pomocí Javy
linktitle: Správa obrázků
type: docs
weight: 10
url: /cs/java/image/
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
- Java
- Aspose.Slides
description: "Zjednodušte správu obrázků v PowerPointu a OpenDocumentu pomocí Aspose.Slides pro Javu, optimalizujte výkon a automatizujte své pracovní postupy."
---
## **Úvod**

Obrázky činí prezentace poutavějšími a zajímavějšími. V Microsoft PowerPoint můžete do snímků vložit obrázky ze souboru, z internetu nebo z jiných míst. Podobně Aspose.Slides umožňuje přidávat obrázky do snímků ve vašich prezentacích různými postupy. 

{{% alert title="Tip" color="primary" %}} 

Aspose poskytuje bezplatné konvertory — [JPEG to PowerPoint](https://products.aspose.app/slides/cs/import/jpg-to-ppt) a [PNG to PowerPoint](https://products.aspose.app/slides/cs/import/png-to-ppt) — které umožňují rychle vytvářet prezentace z obrázků. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Pokud chcete přidat obrázek jako objekt rámečku — zejména pokud plánujete použít standardní možnosti formátování k změně jeho velikosti, přidání efektů atd. — viz [Picture Frame](https://docs.aspose.com/slides/cs/java/picture-frame/). 

{{% /alert %}} 

{{% alert title="Poznámka" color="warning" %}}

Můžete manipulovat s operacemi vstupu/výstupu zahrnujícími obrázky a prezentace PowerPoint a převádět obrázek z jednoho formátu do druhého. Viz následující stránky: převod [image to JPG](https://products.aspose.com/slides/cs/java/conversion/image-to-jpg/); převod [JPG to image](https://products.aspose.com/slides/cs/java/conversion/jpg-to-image/); převod [JPG to PNG](https://products.aspose.com/slides/cs/java/conversion/jpg-to-png/), převod [PNG to JPG](https://products.aspose.com/slides/cs/java/conversion/png-to-jpg/); převod [PNG to SVG](https://products.aspose.com/slides/cs/java/conversion/png-to-svg/), převod [SVG to PNG](https://products.aspose.com/slides/cs/java/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides podporuje operace s obrázky v těchto populárních formátech: JPEG, PNG, GIF a další. 

## **Přidání obrázků uložených lokálně do snímků**

Můžete přidat jeden nebo několik obrázků z vašeho počítače na snímek v prezentaci. Tento vzorový kód v Javě ukazuje, jak přidat obrázek na snímek:

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

Tento vzorový kód ukazuje, jak přidat obrázek z webu na snímek v Javě:

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

## **Přidání obrázků do Slide Masterů**

Slide master je hlavní snímek, který ukládá a řídí informace (téma, rozvržení atd.) o všech snímcích pod ním. Když tedy přidáte obrázek do slide masteru, tento obrázek se objeví na každém snímku pod tímto masterem. 

Tento vzorový kód v Javě ukazuje, jak přidat obrázek do slide masteru:

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

Můžete se rozhodnout použít obrázek jako pozadí pro konkrétní snímek nebo několik snímků. V takovém případě si prohlédněte *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/cs/java/presentation-background/#setting-images-as-background-for-slides)*.

## **Přidání SVG do prezentací**
Můžete přidat nebo vložit libovolný obrázek do prezentace pomocí metody [addPictureFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) patřící do rozhraní [IShapeCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IShapeCollection).

Pro vytvoření objektu obrázku založeného na SVG můžete postupovat takto:

1. Vytvořte objekt SvgImage pro vložení do ImageShapeCollection
2. Vytvořte objekt PPImage z ISvgImage
3. Vytvořte objekt PictureFrame pomocí rozhraní IPPImage

Tento vzorový kód ukazuje, jak implementovat výše uvedené kroky a přidat SVG obrázek do prezentace:
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
Převod SVG na sadu tvarů v Aspose.Slides je podobný funkčnosti PowerPointu používané k práci s SVG obrázky:

![Vyskakovací nabídka PowerPoint](img_01_01.png)

Funkčnost je poskytována jedním z přetížených metod [addGroupShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) rozhraní [IShapeCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IShapeCollection), která jako první argument přijímá objekt [ISvgImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISvgImage).

Tento vzorový kód ukazuje, jak použít popsanou metodu k převodu SVG souboru na sadu tvarů:

```java 
// Vytvořte novou prezentaci
IPresentation presentation = new Presentation();
try {
    // Načtěte obsah souboru SVG
    byte[] svgContent = Files.readAllBytes(Paths.get("image.svg"));

    // Vytvořte objekt SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // Získat velikost snímku
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // Převést SVG obrázek na skupinu tvarů a přizpůsobit jej velikosti snímku
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
Aspose.Slides for Java umožňuje generovat EMF obrázky z listů Excelu a přidávat tyto obrázky jako EMF do snímků pomocí Aspose.Cells. 

Tento vzorový kód ukazuje, jak provést popsaný úkol:

```java 
Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);
ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

//Uložte sešit do proudu
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

## **Nahrazení obrázků ve sbírce obrázků**

Aspose.Slides umožňuje nahradit obrázky uložené v kolekci obrázků prezentace (včetně těch, které používají tvary snímků). Tato sekce ukazuje několik přístupů k aktualizaci obrázků v kolekci. API poskytuje přímé metody pro nahrazení obrázku pomocí raw bajtových dat, instance [IImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimage/) nebo jiného obrázku, který už v kolekci existuje.

Postupujte podle následujících kroků:

1. Načtěte soubor prezentace, který obsahuje obrázky, pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
2. Načtěte nový obrázek ze souboru do pole bajtů.
3. Nahraďte cílový obrázek novým obrázkem pomocí pole bajtů.
4. V druhém přístupu načtěte obrázek do objektu [IImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimage/) a nahraďte cílový obrázek tímto objektem.
5. Ve třetím přístupu nahraďte cílový obrázek obrázkem, který již v kolekci obrázků prezentace existuje.
6. Uložte upravenou prezentaci jako soubor PPTX.

```java
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
Presentation presentation = new Presentation("sample.pptx");
try {
    // První způsob.
    byte[] imageData = Files.readAllBytes(Paths.get("image0.jpeg"));
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

**Zůstane původní rozlišení obrázku po vložení neporušené?**

Ano. Původní pixely jsou zachovány, ale finální vzhled závisí na tom, jak je [obrázek](/slides/cs/java/picture-frame/) na snímku škálován a jaká komprese je použita při ukládání.

**Jaký je nejlepší způsob, jak nahradit stejné logo na desítkách snímků najednou?**

Umístěte logo do master snímku nebo rozvržení a nahraďte jej ve sbírce obrázků prezentace — aktualizace se projeví ve všech prvcích, které tento zdroj používají.

**Lze vložené SVG převést na editovatelné tvary?**

Ano. SVG můžete převést na skupinu tvarů, po čemž jednotlivé části budou editovatelné pomocí standardních vlastností tvaru.

**Jak nastavit obrázek jako pozadí pro více snímků najednou?**

[Assign the image as the background](/slides/cs/java/presentation-background/) na master snímku nebo příslušném rozvržení — každý snímek používající tento master/rozvržení zdědí pozadí.

**Jak zabránit nabrání velikosti prezentace kvůli mnoha obrázkům?**

Znovu použijte jediný zdroj obrázku místo duplicit, zvolte rozumná rozlišení, aplikujte kompresi při ukládání a opakující se grafiku umístěte na master, kde je to vhodné.