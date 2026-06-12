---
title: Optimaliseer het beheer van afbeeldingen in presentaties met Java
linktitle: Afbeeldingen beheren
type: docs
weight: 10
url: /nl/java/image/
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
- EMF
- SVG
- Java
- Aspose.Slides
description: "Versnel het beheer van afbeeldingen in PowerPoint en OpenDocument met Aspose.Slides voor Java, optimaliseer de prestaties en automatiseer uw workflow."
---
## **Inleiding**

Afbeeldingen maken presentaties boeiender en interessanter. In Microsoft PowerPoint kun je afbeeldingen vanuit een bestand, het internet of andere locaties op dia's invoegen. Op dezelfde manier stelt Aspose.Slides je in staat om afbeeldingen toe te voegen aan dia's in je presentaties via verschillende werkwijzen. 

{{% alert  title="Tip" color="primary" %}} 

Aspose biedt gratis converters—[JPEG to PowerPoint](https://products.aspose.app/slides/nl/import/jpg-to-ppt) en [PNG to PowerPoint](https://products.aspose.app/slides/nl/import/png-to-ppt)—die mensen in staat stellen snel presentaties vanuit afbeeldingen te maken. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Wil je een afbeelding toevoegen als kaderobject—vooral als je van plan bent standaard opmaakopties te gebruiken om de grootte aan te passen, effecten toe te voegen, enzovoort—zie dan [Picture Frame](https://docs.aspose.com/slides/nl/java/picture-frame/). 

{{% /alert %}} 

{{% alert title="Opmerking" color="warning" %}}

Je kunt bewerkingen met invoer/uitvoer met betrekking tot afbeeldingen en PowerPoint‑presentaties manipuleren om een afbeelding van het ene formaat naar het andere te converteren. Zie deze pagina's: converteer [image to JPG](https://products.aspose.com/slides/nl/java/conversion/image-to-jpg/); converteer [JPG to image](https://products.aspose.com/slides/nl/java/conversion/jpg-to-image/); converteer [JPG to PNG](https://products.aspose.com/slides/nl/java/conversion/jpg-to-png/), converteer [PNG to JPG](https://products.aspose.com/slides/nl/java/conversion/png-to-jpg/); converteer [PNG to SVG](https://products.aspose.com/slides/nl/java/conversion/png-to-svg/), converteer [SVG to PNG](https://products.aspose.com/slides/nl/java/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides ondersteunt bewerkingen met afbeeldingen in deze populaire formaten: JPEG, PNG, GIF en andere. 

## **Afbeeldingen lokaal opslaan en toevoegen aan dia's**

Je kunt één of meerdere afbeeldingen van je computer toevoegen aan een dia in een presentatie. Deze voorbeeldcode in Java laat zien hoe je een afbeelding aan een dia toevoegt:

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

## **Afbeeldingen vanaf het internet toevoegen aan dia's**

Als de afbeelding die je wilt toevoegen aan een dia niet beschikbaar is op je computer, kun je de afbeelding direct van het internet toevoegen. 

Deze voorbeeldcode laat zien hoe je een afbeelding van het internet toevoegt aan een dia in Java:

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

Een dia‑master is de bovenliggende dia die informatie (thema, lay‑out, enz.) over alle dia's eronder opslaat en beheert. Dus wanneer je een afbeelding toevoegt aan een dia‑master, verschijnt die afbeelding op elke dia onder die master. 

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

Je kunt besluiten een afbeelding te gebruiken als achtergrond voor een specifieke dia of meerdere dia's. In dat geval moet je *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/nl/java/presentation-background/#setting-images-as-background-for-slides)* raadplegen.

## **SVG toevoegen aan presentaties**
Je kunt elke afbeelding aan een presentatie toevoegen of invoegen met de [addPictureFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) methode die behoort tot de [IShapeCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IShapeCollection) interface.

Om een afbeeldingsobject te maken op basis van een SVG‑afbeelding, kun je dit op de volgende manier doen:

1. Maak een SvgImage‑object om het in ImageShapeCollection in te voegen
2. Maak een PPImage‑object van ISvgImage
3. Maak een PictureFrame‑object met behulp van de IPPImage‑interface

Deze voorbeeldcode laat zien hoe je de bovenstaande stappen implementeert om een SVG‑afbeelding toe te voegen aan een presentatie:
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
De SVG‑conversie van Aspose.Slides naar een set vormen is vergelijkbaar met de functionaliteit in PowerPoint om met SVG‑afbeeldingen te werken:

![PowerPoint Popup Menu](img_01_01.png)

De functionaliteit wordt geleverd door een van de overloads van de [addGroupShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) methode van de [IShapeCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IShapeCollection) interface die een [ISvgImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISvgImage) object als eerste argument neemt.

Deze voorbeeldcode laat zien hoe je de beschreven methode gebruikt om een SVG‑bestand te converteren naar een set vormen:

```java 
// Maak een nieuwe presentatie
IPresentation presentation = new Presentation();
try {
    // Lees de inhoud van het SVG-bestand
    byte[] svgContent = Files.readAllBytes(Paths.get("image.svg"));

    // Maak een SvgImage-object
    ISvgImage svgImage = new SvgImage(svgContent);

    // Haal de dia-afmeting op
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // Converteer de SVG-afbeelding naar een groep vormen en schaal deze naar de dia-afmeting
    presentation.getSlides().get_Item(0).getShapes().
            addGroupShape(svgImage, 0f, 0f, (float)slideSize.getWidth(), (float)slideSize.getHeight());

    // Sla de presentatie op in PPTX-formaat
    presentation.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Afbeeldingen als EMF toevoegen aan dia's**
Aspose.Slides for Java stelt je in staat EMF‑afbeeldingen te genereren uit Excel‑bladen en de afbeeldingen als EMF toe te voegen aan dia's met Aspose.Cells. 

Deze voorbeeldcode laat zien hoe je de beschreven taak uitvoert:

```java 
Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);
ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

//Sla het werkboek op naar een stream
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

## **Afbeeldingen vervangen in de beeldverzameling**

Aspose.Slides stelt je in staat afbeeldingen die in de beeldverzameling van een presentatie zijn opgeslagen (inclusief die gebruikt door dia‑vormen) te vervangen. Deze sectie toont verschillende benaderingen om afbeeldingen in de verzameling bij te werken. De API biedt eenvoudige methoden om een afbeelding te vervangen met ruwe byte‑data, een [IImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iimage/) instantie, of een andere afbeelding die al in de verzameling bestaat.

Volg de onderstaande stappen:

1. Laad het presentatie‑bestand dat afbeeldingen bevat met de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) klasse.
1. Laad een nieuwe afbeelding uit een bestand in een byte‑array.
1. Vervang de doelafbeelding door de nieuwe afbeelding met de byte‑array.
1. In de tweede benadering laad je de afbeelding in een [IImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iimage/) object en vervang je de doelafbeelding door dat object.
1. In de derde benadering vervang je de doelafbeelding door een afbeelding die al bestaat in de beeldverzameling van de presentatie.
1. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

```java
// Instantieer de Presentation-klasse die een presentatiedossier vertegenwoordigt.
Presentation presentation = new Presentation("sample.pptx");
try {
    // De eerste manier.
    byte[] imageData = Files.readAllBytes(Paths.get("image0.jpeg"));
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
    
    // Sla de presentatie op naar een bestand.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}

Met de gratis Aspose [Text to GIF](https://products.aspose.app/slides/nl/text-to-gif) converter kun je eenvoudig teksten animeren, GIF‑s maken van teksten, enzovoort. 

{{% /alert %}}

## **FAQ**

**Blijft de oorspronkelijke resolutie van de afbeelding behouden na invoegen?**

Ja. De bronpixels worden behouden, maar het uiteindelijke uiterlijk hangt af van hoe de [picture](/slides/nl/java/picture-frame/) op de dia wordt geschaald en van eventuele compressie bij het opslaan.

**Wat is de beste manier om hetzelfde logo in tientallen dia's tegelijk te vervangen?**

Plaats het logo op de master‑dia of een lay‑out en vervang het in de beeldverzameling van de presentatie—wijzigingen worden doorgevoerd naar alle elementen die die bron gebruiken.

**Kan een ingevoegde SVG worden omgezet naar bewerkbare vormen?**

Ja. Je kunt een SVG omzetten naar een groep vormen; daarna worden individuele onderdelen bewerkbaar met standaard vormeigenschappen.

**Hoe stel ik een afbeelding in als achtergrond voor meerdere dia's tegelijk?**

[Assign the image as the background](/slides/nl/java/presentation-background/) op de master‑dia of de betreffende lay‑out—alle dia's die die master/lay‑out gebruiken, nemen de achtergrond over.

**Hoe voorkom ik dat de presentatie "uitzet" in grootte door veel afbeeldingen?**

Hergebruik één afbeeldingsbron in plaats van duplicaten, kies redelijke resoluties, pas compressie toe bij het opslaan, en houd herhaalde grafieken op de master waar passend.