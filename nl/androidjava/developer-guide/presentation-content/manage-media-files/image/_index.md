---
title: Optimaliseer het beheer van afbeeldingen in presentaties op Android
linktitle: Afbeeldingen beheren
type: docs
weight: 10
url: /nl/androidjava/image/
keywords:
- afbeelding toevoegen
- foto toevoegen
- bitmap toevoegen
- afbeelding vervangen
- foto vervangen
- van internet
- achtergrond
- PNG toevoegen
- JPG toevoegen
- SVG toevoegen
- EMF toevoegen
- WMF toevoegen
- TIFF toevoegen
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Stroomlijn het beheer van afbeeldingen in PowerPoint en OpenDocument met Aspose.Slides voor Android via Java, optimaliseer de prestaties en automatiseer je workflow."
---
## **Inleiding**

Afbeeldingen maken presentaties boeiender en interessanter. In Microsoft PowerPoint kun je afbeeldingen invoegen vanuit een bestand, het internet of andere locaties op dia's. Op dezelfde manier stelt Aspose.Slides je in staat om afbeeldingen aan dia's in je presentaties toe te voegen via verschillende procedures. 

{{% alert  title="Tip" color="primary" %}} 

Aspose biedt gratis converters—[JPEG naar PowerPoint](https://products.aspose.app/slides/nl/import/jpg-to-ppt) en [PNG naar PowerPoint](https://products.aspose.app/slides/nl/import/png-to-ppt)—die mensen in staat stellen snel presentaties te maken van afbeeldingen. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Als je een afbeelding wilt toevoegen als een frame‑object—vooral wanneer je de standaard opmaakopties wilt gebruiken om de grootte te wijzigen, effecten toe te voegen, enzovoort—zie [Afbeeldingsframe](https://docs.aspose.com/slides/nl/androidjava/picture-frame/).

{{% /alert %}} 

Aspose.Slides ondersteunt bewerkingen met afbeeldingen in deze populaire formaten: JPEG, PNG, GIF en andere. 

## **Afbeeldingen die lokaal zijn opgeslagen toevoegen aan dia's**

Je kunt één of meerdere afbeeldingen op je computer aan een dia in een presentatie toevoegen. Deze voorbeeldcode in Java laat zien hoe je een afbeelding aan een dia toevoegt:

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

## **Afbeeldingen van het web toevoegen aan dia's**

Als de afbeelding die je aan een dia wilt toevoegen niet beschikbaar is op je computer, kun je de afbeelding rechtstreeks van het internet toevoegen. 

Deze voorbeeldcode laat zien hoe je een afbeelding van het internet aan een dia toevoegt in Java:

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

## **Afbeeldingen toevoegen aan dia‑masters**

Een dia‑master is de bovenste dia die informatie (thema, lay‑out, enz.) over alle dia's eronder opslaat en beheert. Dus wanneer je een afbeelding aan een dia‑master toevoegt, verschijnt die afbeelding op elke dia onder die master. 

Deze Java‑voorbeeldcode laat zien hoe je een afbeelding aan een dia‑master toevoegt:

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

## **Afbeeldingen toevoegen als dia‑achtergronden**

Je kunt ervoor kiezen een afbeelding als achtergrond te gebruiken voor een specifieke dia of meerdere dia's. In dat geval moet je *[Afbeeldingen instellen als achtergronden voor dia's](https://docs.aspose.com/slides/nl/androidjava/presentation-background/#setting-images-as-background-for-slides)* bekijken.

## **SVG toevoegen aan presentaties**
Je kunt elke afbeelding aan een presentatie toevoegen of invoegen met behulp van de [addPictureFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-)‑methode die behoort tot de [IShapeCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShapeCollection) interface.

Om een afbeeldingobject op basis van een SVG‑afbeelding te maken, kun je dit op deze manier doen:

1. Maak een SvgImage‑object aan om het in ImageShapeCollection in te voegen
2. Maak een PPImage‑object aan vanuit ISvgImage
3. Maak een PictureFrame‑object aan met behulp van de IPPImage‑interface

Deze voorbeeldcode laat zien hoe je de bovenstaande stappen implementeert om een SVG‑afbeelding aan een presentatie toe te voegen:
```java
// Instantieer de Presentation-klasse die een PPTX-bestand vertegenwoordigt
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

## **SVG converteren naar een set vormen**
De conversie van SVG naar een set vormen in Aspose.Slides is vergelijkbaar met de PowerPoint‑functionaliteit voor het werken met SVG‑afbeeldingen:

![PowerPoint Popup Menu](img_01_01.png)

De functionaliteit wordt geleverd door een van de overloads van de [addGroupShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-)‑methode van de [IShapeCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShapeCollection) interface die een [ISvgImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISvgImage)‑object als eerste argument accepteert.

Deze voorbeeldcode laat zien hoe je de beschreven methode gebruikt om een SVG‑bestand te converteren naar een set vormen:

```java 
// Nieuwe presentatie maken
IPresentation presentation = new Presentation();
try {
    // Inhoud van SVG-bestand lezen
    byte[] svgContent = Files.readAllBytes(Paths.get("image.svg"));

    // SvgImage-object maken
    ISvgImage svgImage = new SvgImage(svgContent);

    // Diaformaat ophalen
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // SVG-afbeelding omzetten naar een groep vormen en schalen naar diaformaat
    presentation.getSlides().get_Item(0).getShapes().
            addGroupShape(svgImage, 0f, 0f, (float)slideSize.getWidth(), (float)slideSize.getHeight());

    // Presentatie opslaan in PPTX-formaat
    presentation.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Afbeeldingen als EMF toevoegen aan dia's**
Aspose.Slides voor Android via Java stelt je in staat EMF‑afbeeldingen te genereren uit Excel‑bladen en de afbeeldingen als EMF toe te voegen aan dia's met Aspose.Cells. 

Deze voorbeeldcode laat zien hoe je de beschreven taak uitvoert:

```java 
Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);
ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

//Sla het werkboek op in een stream
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

## **Afbeeldingen vervangen in de afbeeldingscollectie**

Aspose.Slides stelt je in staat afbeeldingen die opgeslagen zijn in de afbeeldingscollectie van een presentatie (inclusief die welke door dia‑vormen worden gebruikt) te vervangen. Deze sectie toont verschillende benaderingen om afbeeldingen in de collectie bij te werken. De API biedt eenvoudige methoden om een afbeelding te vervangen met behulp van ruwe byte‑data, een [IImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimage/)‑instantie, of een andere afbeelding die al in de collectie bestaat.

Volg de onderstaande stappen:

1. Laad het presentatie‑bestand dat afbeeldingen bevat met behulp van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) klasse.
2. Laad een nieuwe afbeelding vanuit een bestand in een byte‑array.
3. Vervang de doelafbeelding door de nieuwe afbeelding met behulp van de byte‑array.
4. In de tweede benadering, laad de afbeelding in een [IImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimage/) object en vervang de doelafbeelding door dat object.
5. In de derde benadering, vervang de doelafbeelding door een afbeelding die al bestaat in de afbeeldingscollectie van de presentatie.
6. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

```java
// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
Presentation presentation = new Presentation("sample.pptx");
try {
    // De eerste manier.
    IImage imageData = Images.fromStream(new FileInputStream("image0.jpeg"));
    IPPImage oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);
    
    // De tweede manier.
    IImage newImage = Images.fromFile("image1.png");
    oldImage = presentation.getImages().get_Item(1);
    oldImage.replaceImage(newImage);
    newImage.dispose();
    
    // De derde manier.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));
    
    // De presentatie opslaan in een bestand.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}

Met de gratis Aspose [Text to GIF](https://products.aspose.app/slides/nl/text-to-gif) converter kun je eenvoudig teksten animeren, GIF's maken van teksten, enzovoort. 

{{% /alert %}}

## **FAQ**

**Blijft de oorspronkelijke resolutie van de afbeelding behouden na invoegen?**

Ja. De oorspronkelijke pixels blijven behouden, maar het uiteindelijke uiterlijk hangt af van hoe de [afbeelding](/slides/nl/androidjava/picture-frame/) op de dia wordt geschaald en van eventuele compressie bij het opslaan.

**Wat is de beste manier om hetzelfde logo in tientallen dia's tegelijk te vervangen?**

Plaats het logo op de master‑dia of een lay‑out en vervang het in de afbeeldingscollectie van de presentatie—updates worden doorgevoerd naar alle elementen die die bron gebruiken.

**Kan een ingevoegde SVG worden geconverteerd naar bewerkbare vormen?**

Ja. Je kunt een SVG omzetten naar een groep vormen, waarna individuele onderdelen bewerkbaar worden met de standaard vormeigenschappen.

**Hoe kan ik een afbeelding als achtergrond instellen voor meerdere dia's tegelijk?**

[Stel de afbeelding in als achtergrond](/slides/nl/androidjava/presentation-background/) op de master‑dia of de betreffende lay‑out—alle dia's die die master/lay‑out gebruiken, erven de achtergrond.

**Hoe voorkom ik dat de presentatie in omvang "uitloopt" door veel afbeeldingen?**

Herbruik één afbeelding in plaats van duplicaten, kies redelijke resoluties, pas compressie toe bij het opslaan en houd herhaalde grafieken op de master waar passend.