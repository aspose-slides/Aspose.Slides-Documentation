---
title: Optimera bildhantering i presentationer på Android
linktitle: Hantera bilder
type: docs
weight: 10
url: /sv/androidjava/image/
keywords:
- lägg till bild
- lägg till bild
- lägg till bitmap
- ersätt bild
- ersätt bild
- från webben
- bakgrund
- lägg till PNG
- lägg till JPG
- lägg till SVG
- lägg till EMF
- lägg till WMF
- lägg till TIFF
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Effektivisera bildhantering i PowerPoint och OpenDocument med Aspose.Slides för Android via Java, optimera prestanda och automatisera ditt arbetsflöde."
---
## **Introduktion**

Bilder gör presentationer mer engagerande och intressanta. I Microsoft PowerPoint kan du infoga bilder från en fil, internet eller andra platser på bilder. På samma sätt låter Aspose.Slides dig lägga till bilder på bilder i dina presentationer genom olika metoder. 

{{% alert  title="Tip" color="primary" %}} 

Aspose erbjuder gratis konverterare—[JPEG till PowerPoint](https://products.aspose.app/slides/sv/import/jpg-to-ppt) och [PNG till PowerPoint](https://products.aspose.app/slides/sv/import/png-to-ppt)—som låter användare skapa presentationer snabbt från bilder. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Om du vill lägga till en bild som ett ramobjekt—särskilt om du planerar att använda standardformateringsalternativ för att ändra dess storlek, lägga till effekter osv.—se [Bildram](https://docs.aspose.com/slides/sv/androidjava/picture-frame/).

{{% /alert %}} 

Aspose.Slides stödjer operationer med bilder i dessa populära format: JPEG, PNG, GIF och andra. 

## **Lägg till bilder lagrade lokalt på bildspel**

Du kan lägga till en eller flera bilder på din dator till en bild i en presentation. Detta exempel i Java visar hur du lägger till en bild på en bild:

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

## **Lägg till bilder från webben på bildspel**

Om bilden du vill lägga till på en bild inte finns på din dator kan du lägga till bilden direkt från webben. 

Detta exempel visar hur du lägger till en bild från webben på en bild i Java:

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

## **Lägg till bilder på bildmaster**

En bildmaster är den översta bilden som lagrar och styr information (tema, layout etc.) om alla bilder under den. Så när du lägger till en bild på en bildmaster visas den bilden på varje bild under den bildmastern. 

Detta Java‑exempel visar hur du lägger till en bild på en bildmaster:

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

## **Lägg till bilder som bildbakgrunder**

Du kan bestämma dig för att använda en bild som bakgrund för en specifik bild eller flera bilder. I så fall bör du se *[Ställa in bilder som bakgrunder för bilder](https://docs.aspose.com/slides/sv/androidjava/presentation-background/#setting-images-as-background-for-slides)*.

## **Lägg till SVG i presentationer**
Du kan lägga till eller infoga valfri bild i en presentation genom att använda metoden [addPictureFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) som tillhör gränssnittet [IShapeCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IShapeCollection).

För att skapa ett bildobjekt baserat på en SVG‑bild kan du göra så här:

1. Skapa SvgImage‑objekt för att infoga det i ImageShapeCollection
2. Skapa PPImage‑objekt från ISvgImage
3. Skapa PictureFrame‑objekt med IPPImage‑gränssnittet

Detta exempel visar hur du implementerar stegen ovan för att lägga till en SVG‑bild i en presentation:
```java 
// Instansiera Presentation-klassen som representerar PPTX-fil
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

## **Konvertera SVG till en uppsättning former**
Aspose.Slides konvertering av SVG till en uppsättning former är liknande PowerPoint-funktionen som används för att arbeta med SVG‑bilder:

![PowerPoint Popup Menu](img_01_01.png)

Funktionen tillhandahålls av en av överlagringarna av metoden [addGroupShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) i gränssnittet [IShapeCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IShapeCollection) som tar ett [ISvgImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISvgImage)-objekt som första argument.

Detta exempel visar hur du använder den beskrivna metoden för att konvertera en SVG‑fil till en uppsättning former:

```java 
// Skapa ny presentation
IPresentation presentation = new Presentation();
try {
    // Läs SVG-filens innehåll
    byte[] svgContent = Files.readAllBytes(Paths.get("image.svg"));

    // Skapa SvgImage-objekt
    ISvgImage svgImage = new SvgImage(svgContent);

    // Hämta bildstorlek
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // Konvertera SVG-bilden till en grupp av former och skala den till bildens storlek
    presentation.getSlides().get_Item(0).getShapes().
            addGroupShape(svgImage, 0f, 0f, (float)slideSize.getWidth(), (float)slideSize.getHeight());

    // Spara presentationen i PPTX-format
    presentation.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Lägg till bilder som EMF på bilder**
Aspose.Slides för Android via Java låter dig generera EMF‑bilder från Excel‑ark och lägga till bilderna som EMF i bilder med Aspose.Cells. 

Detta exempel visar hur du utför den beskrivna uppgiften:

```java 
Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);
ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

//Spara arbetsboken till ström
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

## **Byt ut bilder i bildsamlingen**

Aspose.Slides låter dig ersätta bilder lagrade i en presentations bildsamling (inklusive de som används av bildformer). Denna sektion visar flera tillvägagångssätt för att uppdatera bilder i samlingen. API:et erbjuder enkla metoder för att ersätta en bild med rå byte‑data, en [IImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iimage/)-instans, eller en annan bild som redan finns i samlingen.

Följ stegen nedan:

1. Läs in presentationsfilen som innehåller bilder med klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/).
2. Läs in en ny bild från en fil till en byte‑array.
3. Ersätt målbilden med den nya bilden med hjälp av byte‑arrayen.
4. I det andra tillvägagångssättet laddar du bilden i ett [IImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iimage/)-objekt och ersätter målbilden med det objektet.
5. I det tredje tillvägagångssättet ersätter du målbilden med en bild som redan finns i presentationens bildsamling.
6. Skriv den modifierade presentationen som en PPTX‑fil.

```java
// Instansiera Presentation-klassen som representerar en presentationsfil.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Det första sättet.
    IImage imageData = Images.fromStream(new FileInputStream("image0.jpeg"));
    IPPImage oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);
    
    // Det andra sättet.
    IImage newImage = Images.fromFile("image1.png");
    oldImage = presentation.getImages().get_Item(1);
    oldImage.replaceImage(newImage);
    newImage.dispose();
    
    // Det tredje sättet.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));
    
    // Spara presentationen till en fil.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}

Med Aspose GRATIS‑konverteraren [Text till GIF](https://products.aspose.app/slides/sv/text-to-gif) kan du enkelt animera texter, skapa GIF‑filer från texter osv. 

{{% /alert %}}

## **Vanliga frågor**

**Behåller den ursprungliga bildupplösningen sin kvalitet efter infogning?**

Ja. Källpixlarna bevaras, men det slutgiltiga utseendet beror på hur [bilden](/slides/sv/androidjava/picture-frame/) skalas på bilden och eventuell kompression som tillämpas vid sparande.

**Vad är det bästa sättet att ersätta samma logotyp på dussintals bilder på en gång?**

Placera logotypen på bildmastern eller en layout och ersätt den i presentationens bildsamling – uppdateringarna sprids till alla element som använder den resursen.

**Kan en infogad SVG konverteras till redigerbara former?**

Ja. Du kan konvertera en SVG till en grupp av former, varpå enskilda delar blir redigerbara med standardegenskaper för former.

**Hur kan jag sätta en bild som bakgrund för flera bilder på en gång?**

[Tilldela bilden som bakgrund](/slides/sv/androidjava/presentation-background/) på bildmastern eller den relevanta layouten – alla bilder som använder den master/layouten kommer att ärva bakgrunden.

**Hur hindrar jag att presentationen blir för stor på grund av många bilder?**

Återanvänd en enskild bildresurs istället för dubbletter, välj rimliga upplösningar, tillämpa kompression vid sparande, och håll återkommande grafik på mastern där det är lämpligt.