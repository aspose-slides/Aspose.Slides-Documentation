---
title: Bild
type: docs
weight: 10
url: /androidjava/image/
description: Arbeiten Sie mit Bildern in Folien in PowerPoint-Präsentationen mit Java. Fügen Sie Bilder von der Festplatte oder aus dem Web in PowerPoint-Folien mit Java hinzu. Fügen Sie Bilder zu Folienmaster oder als Folienhintergrund mit Java hinzu. Fügen Sie SVG zu PowerPoint-Präsentationen mit Java hinzu. Konvertieren Sie SVG in Formen in PowerPoint mit Java. Fügen Sie Bilder als EMF in Folien mit Java hinzu.
---

## **Bilder in Folien In Präsentationen**

Bilder machen Präsentationen ansprechender und interessanter. In Microsoft PowerPoint können Sie Bilder aus einer Datei, dem Internet oder anderen Orten auf Folien einfügen. Ebenso ermöglicht Aspose.Slides Ihnen, Bilder über verschiedene Verfahren zu Folien in Ihren Präsentationen hinzuzufügen.

{{% alert title="Tipp" color="primary" %}} 

Aspose bietet kostenlose Konverter—[JPEG nach PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) und [PNG nach PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—die es den Menschen ermöglichen, schnell Präsentationen aus Bildern zu erstellen.

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Wenn Sie ein Bild als Rahmenobjekt hinzufügen möchten—insbesondere wenn Sie planen, Standardformatierungsoptionen darauf anzuwenden, um seine Größe zu ändern, Effekte hinzuzufügen usw.—sehen Sie sich [Bilderrahmen](https://docs.aspose.com/slides/androidjava/picture-frame/) an.

{{% /alert %}} 

{{% alert title="Hinweis" color="warning" %}}

Sie können Ein-/Ausgabeoperationen, die Bilder und PowerPoint-Präsentationen betreffen, manipulieren, um ein Bild von einem Format in ein anderes zu konvertieren. Sehen Sie sich diese Seiten an: konvertieren Sie [Bild zu JPG](https://products.aspose.com/slides/androidjava/conversion/image-to-jpg/); konvertieren Sie [JPG zu Bild](https://products.aspose.com/slides/androidjava/conversion/jpg-to-image/); konvertieren Sie [JPG zu PNG](https://products.aspose.com/slides/androidjava/conversion/jpg-to-png/), konvertieren Sie [PNG zu JPG](https://products.aspose.com/slides/androidjava/conversion/png-to-jpg/); konvertieren Sie [PNG zu SVG](https://products.aspose.com/slides/androidjava/conversion/png-to-svg/), konvertieren Sie [SVG zu PNG](https://products.aspose.com/slides/androidjava/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides unterstützt Operationen mit Bildern in diesen gängigen Formaten: JPEG, PNG, GIF und anderen.

## **Hinzufügen von Bildern, die lokal gespeichert sind, zu Folien**

Sie können eines oder mehrere Bilder von Ihrem Computer auf eine Folie in einer Präsentation hinzufügen. Dieser Beispielcode in Java zeigt Ihnen, wie Sie ein Bild auf eine Folie hinzufügen:

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

## **Hinzufügen von Bildern aus dem Web zu Folien**

Wenn das Bild, das Sie zu einer Folie hinzufügen möchten, auf Ihrem Computer nicht verfügbar ist, können Sie das Bild direkt aus dem Web hinzufügen.

Dieser Beispielcode zeigt Ihnen, wie Sie ein Bild aus dem Web zu einer Folie in Java hinzufügen:

```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);

	URL imageUrl = new URL("[ERSETZEN MIT URL]");
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

## **Hinzufügen von Bildern zu Folienmaster**

Ein Folienmaster ist die oberste Folie, die Informationen (Thema, Layout usw.) über alle Unterfolien speichert und steuert. Wenn Sie also ein Bild zu einem Folienmaster hinzufügen, erscheint dieses Bild auf jeder Folie unter diesem Folienmaster.

Dieser Java-Beispielcode zeigt Ihnen, wie Sie ein Bild zu einem Folienmaster hinzufügen:

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

## **Hinzufügen von Bildern als Folienhintergrund**

Sie können entscheiden, ein Bild als Hintergrund für eine bestimmte Folie oder mehrere Folien zu verwenden. In diesem Fall müssen Sie sich *[Bilder als Hintergründe für Folien einstellen](https://docs.aspose.com/slides/androidjava/presentation-background/#setting-images-as-background-for-slides)* ansehen.

## **Hinzufügen von SVG zu Präsentationen**
Sie können jedes Bild in eine Präsentation einfügen, indem Sie die Methode [addPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) verwenden, die zur [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) Schnittstelle gehört.

Um ein Bildobjekt basierend auf einem SVG-Bild zu erstellen, können Sie dies folgendermaßen tun:

1. Erstellen Sie ein SvgImage-Objekt, um es in ImageShapeCollection einzufügen
2. Erstellen Sie ein PPImage-Objekt aus ISvgImage
3. Erstellen Sie ein PictureFrame-Objekt mithilfe der IPPImage-Schnittstelle

Dieser Beispielcode zeigt Ihnen, wie Sie die Schritte oben implementieren, um ein SVG-Bild in eine Präsentation hinzuzufügen:
```java 
// Instanziieren Sie die Presentation-Klasse, die die PPTX-Datei darstellt
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

## **Konvertieren von SVG in eine Reihe von Formen**
Die Konvertierung von SVG in eine Reihe von Formen durch Aspose.Slides ist ähnlich der PowerPoint-Funktionalität, die zur Arbeit mit SVG-Bildern verwendet wird:

![PowerPoint Popup-Menü](img_01_01.png)

Die Funktionalität wird durch eine der Überladungen der [addGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) Methode der [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) Schnittstelle bereitgestellt, die ein [ISvgImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISvgImage) Objekt als erstes Argument akzeptiert.

Dieser Beispielcode zeigt Ihnen, wie Sie die beschriebene Methode verwenden, um eine SVG-Datei in eine Reihe von Formen zu konvertieren:

```java 
// Erstellen Sie eine neue Präsentation
IPresentation presentation = new Presentation();
try {
    // SVG-Dateiinhalt lesen
    byte[] svgContent = Files.readAllBytes(Paths.get("image.svg"));

    // Erstellen Sie ein SvgImage-Objekt
    ISvgImage svgImage = new SvgImage(svgContent);

    // Holen Sie sich die Foliengröße
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // Konvertieren Sie das SVG-Bild in eine Gruppe von Formen und skalieren Sie es auf die Foliengröße
    presentation.getSlides().get_Item(0).getShapes().
            addGroupShape(svgImage, 0f, 0f, (float)slideSize.getWidth(), (float)slideSize.getHeight());

    // Speichern Sie die Präsentation im PPTX-Format
    presentation.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Hinzufügen von Bildern als EMF in Folien**
Aspose.Slides für Android über Java ermöglicht es Ihnen, EMF-Bilder aus Excel-Blättern zu generieren und die Bilder als EMF in Folien mit Aspose.Cells hinzuzufügen.

Dieser Beispielcode zeigt Ihnen, wie Sie die beschriebene Aufgabe ausführen:

```java 
Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);
ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

//Speichern Sie das Arbeitsbuch im Stream
SheetRender sr = new SheetRender(sheet, options);
Presentation pres = new Presentation();
try {
    pres.getSlides().removeAt(0);
    
    String EmfSheetName = "";
    for (int j = 0; j < sr.getPageCount(); j++)
    {
    
        EmfSheetName = "test" + sheet.getName() + " Seite" + (j + 1) + ".out.emf";
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

{{% alert title="Info" color="info" %}}

Mit dem kostenlosen [Text zu GIF](https://products.aspose.app/slides/text-to-gif) Konverter von Aspose können Sie Texte leicht animieren, GIFs aus Texten erstellen usw.

{{% /alert %}}