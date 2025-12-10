---
title: Optimieren Sie das Bildmanagement in Präsentationen mit Java
linktitle: Bilder verwalten
type: docs
weight: 10
url: /de/java/image/
keywords:
- Bild hinzufügen
- Grafik hinzufügen
- Bitmap hinzufügen
- Bild ersetzen
- Grafik ersetzen
- aus dem Internet
- Hintergrund
- PNG hinzufügen
- JPG hinzufügen
- SVG hinzufügen
- EMF hinzufügen
- WMF hinzufügen
- TIFF hinzufügen
- PowerPoint
- OpenDocument
- Präsentation
- EMF
- SVG
- Java
- Aspose.Slides
description: "Optimieren Sie das Bildmanagement in PowerPoint und OpenDocument mit Aspose.Slides für Java, verbessern Sie die Leistung und automatisieren Sie Ihren Arbeitsablauf."
---

## **Bilder in Präsentationsfolien**

Bilder machen Präsentationen ansprechender und interessanter. In Microsoft PowerPoint können Sie Bilder aus einer Datei, dem Internet oder anderen Orten in Folien einfügen. Ebenso ermöglicht Aspose.Slides das Hinzufügen von Bildern zu Folien in Ihren Präsentationen über verschiedene Verfahren.

{{% alert  title="Tipp" color="primary" %}} 
Aspose bietet kostenlose Konverter—[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) und [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—die es ermöglichen, Präsentationen schnell aus Bildern zu erstellen. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
Wenn Sie ein Bild als Rahmenobjekt hinzufügen möchten – insbesondere, wenn Sie planen, Standard‑Formatierungsoptionen zu verwenden, um die Größe zu ändern, Effekte hinzuzufügen usw. – siehe [Picture Frame](https://docs.aspose.com/slides/java/picture-frame/). 
{{% /alert %}} 

{{% alert title="Hinweis" color="warning" %}}
Sie können Ein‑ und Ausgabevorgänge mit Bildern und PowerPoint‑Präsentationen manipulieren, um ein Bild von einem Format in ein anderes zu konvertieren. Siehe diese Seiten: konvertieren [image to JPG](https://products.aspose.com/slides/java/conversion/image-to-jpg/); konvertieren [JPG to image](https://products.aspose.com/slides/java/conversion/jpg-to-image/); konvertieren [JPG to PNG](https://products.aspose.com/slides/java/conversion/jpg-to-png/), konvertieren [PNG to JPG](https://products.aspose.com/slides/java/conversion/png-to-jpg/); konvertieren [PNG to SVG](https://products.aspose.com/slides/java/conversion/png-to-svg/), konvertieren [SVG to PNG](https://products.aspose.com/slides/java/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides unterstützt Vorgänge mit Bildern in diesen gängigen Formaten: JPEG, PNG, GIF und andere. 

## **Bilder, die lokal gespeichert sind, zu Folien hinzufügen**

Sie können ein oder mehrere Bilder von Ihrem Computer zu einer Folie in einer Präsentation hinzufügen. Dieser Beispielcode in Java zeigt, wie man ein Bild zu einer Folie hinzufügt:
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


## **Bilder aus dem Web zu Folien hinzufügen**

Wenn das Bild, das Sie zu einer Folie hinzufügen möchten, nicht auf Ihrem Computer verfügbar ist, können Sie das Bild direkt aus dem Web hinzufügen. 

Dieser Beispielcode zeigt, wie man ein Bild aus dem Web zu einer Folie in Java hinzufügt:
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


## **Bilder zu Folienmaster hinzufügen**

Ein Folienmaster ist die übergeordnete Folie, die Informationen (Design, Layout usw.) für alle darunter liegenden Folien speichert und steuert. Wenn Sie also ein Bild zu einem Folienmaster hinzufügen, erscheint dieses Bild auf jeder Folie, die diesen Master verwendet. 

Dieser Java‑Beispielcode zeigt, wie man ein Bild zu einem Folienmaster hinzufügt:
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


## **Bilder als Folienhintergründe hinzufügen**

Sie können entscheiden, ein Bild als Hintergrund für eine bestimmte Folie oder mehrere Folien zu verwenden. In diesem Fall sollten Sie *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/java/presentation-background/#setting-images-as-background-for-slides)* ansehen.

## **SVG zu Präsentationen hinzufügen**

Sie können jedes Bild in eine Präsentation einfügen, indem Sie die Methode [addPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) verwenden, die zum Interface [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) gehört.

Um ein Bildobjekt auf Basis einer SVG‑Datei zu erstellen, gehen Sie wie folgt vor:

1. Erstellen Sie ein SvgImage‑Objekt, um es in ImageShapeCollection einzufügen
2. Erstellen Sie ein PPImage‑Objekt aus ISvgImage
3. Erstellen Sie ein PictureFrame‑Objekt mithilfe der IPPImage‑Schnittstelle

Dieser Beispielcode zeigt, wie die oben genannten Schritte umgesetzt werden, um ein SVG‑Bild in eine Präsentation einzufügen:
```java
// Instanziiere die Presentation-Klasse, die eine PPTX-Datei darstellt
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


## **SVG in eine Gruppe von Formen konvertieren**

Die SVG‑zu‑Formen‑Konvertierung von Aspose.Slides ist ähnlich der PowerPoint‑Funktionalität zur Arbeit mit SVG‑Bildern:

![PowerPoint Popup Menu](img_01_01.png)

Die Funktion wird von einer der Überladungen der Methode [addGroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) des Interfaces [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) bereitgestellt, das ein [ISvgImage](https://reference.aspose.com/slides/java/com.aspose.slides/ISvgImage)‑Objekt als erstes Argument erwartet.

Dieser Beispielcode zeigt, wie die beschriebene Methode verwendet wird, um eine SVG‑Datei in eine Gruppe von Formen zu konvertieren:
```java 
// Neue Präsentation erstellen
IPresentation presentation = new Presentation();
try {
    // SVG-Dateiinhalt lesen
    byte[] svgContent = Files.readAllBytes(Paths.get("image.svg"));

    // SvgImage-Objekt erstellen
    ISvgImage svgImage = new SvgImage(svgContent);

    // Foliengröße abrufen
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // SVG-Bild in Gruppe von Formen konvertieren und an Foliengröße anpassen
    presentation.getSlides().get_Item(0).getShapes().
            addGroupShape(svgImage, 0f, 0f, (float)slideSize.getWidth(), (float)slideSize.getHeight());

    // Präsentation im PPTX-Format speichern
    presentation.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **Bilder als EMF zu Folien hinzufügen**

Aspose.Slides for Java ermöglicht es, EMF‑Bilder aus Excel‑Tabellen zu erzeugen und die Bilder mit Aspose.Cells als EMF in Folien einzufügen.  

Dieser Beispielcode zeigt, wie die beschriebene Aufgabe durchgeführt wird:
```java
Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);
ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

//Arbeitsmappe in Stream speichern
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


## **Bilder in der Bildersammlung ersetzen**

Aspose.Slides erlaubt das Ersetzen von Bildern, die in der Bildersammlung einer Präsentation gespeichert sind (einschließlich der von Folienformen genutzten). Dieser Abschnitt zeigt mehrere Vorgehensweisen zum Aktualisieren von Bildern in der Sammlung. Die API bietet einfache Methoden zum Ersetzen eines Bildes über rohe Byte‑Daten, eine [IImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/)-Instanz oder ein anderes bereits in der Sammlung vorhandenes Bild.

Führen Sie die folgenden Schritte aus:

1. Laden Sie die Präsentationsdatei, die Bilder enthält, mit der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
2. Laden Sie ein neues Bild aus einer Datei in ein Byte‑Array.
3. Ersetzen Sie das Zielbild durch das neue Bild mithilfe des Byte‑Arrays.
4. Laden Sie im zweiten Ansatz das Bild in ein [IImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/)-Objekt und ersetzen Sie das Zielbild durch dieses Objekt.
5. Im dritten Ansatz ersetzen Sie das Zielbild durch ein Bild, das bereits in der Bildersammlung der Präsentation existiert.
6. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.
```java
// Instanziiere die Presentation-Klasse, die eine Präsentationsdatei repräsentiert.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Die erste Methode.
    byte[] imageData = Files.readAllBytes(Paths.get("image0.jpeg"));
    IPPImage oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);
    
    // Die zweite Methode.
    IImage newImage = Images.fromFile("image1.png");
    oldImage = presentation.getImages().get_Item(1);
    oldImage.replaceImage(newImage);
    newImage.dispose();
    
    // Die dritte Methode.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));
    
    // Speichere die Präsentation in einer Datei.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


{{% alert title="Info" color="info" %}}
Mit dem kostenlosen Aspose [Text to GIF](https://products.aspose.app/slides/text-to-gif)‑Konverter können Sie Texte leicht animieren, GIFs aus Texten erstellen usw. 
{{% /alert %}}

## **FAQ**

**Bleibt die ursprüngliche Bildauflösung nach dem Einfügen erhalten?**  
Ja. Die Quellpixel werden beibehalten, aber das endgültige Erscheinungsbild hängt davon ab, wie das [picture](/slides/de/java/picture-frame/) auf der Folie skaliert wird und welche Kompression beim Speichern angewendet wird.

**Was ist der beste Weg, dasselbe Logo gleichzeitig in Dutzenden Folien zu ersetzen?**  
Platzieren Sie das Logo auf der Master‑Folien oder einem Layout und ersetzen Sie es in der Bildersammlung der Präsentation – die Änderungen werden automatisch auf alle Elemente übertragen, die diese Ressource verwenden.

**Kann ein eingefügtes SVG in bearbeitbare Formen konvertiert werden?**  
Ja. Sie können ein SVG in eine Gruppe von Formen konvertieren; danach lassen sich die einzelnen Teile mit den üblichen Formeigenschaften bearbeiten.

**Wie kann ich ein Bild gleichzeitig als Hintergrund für mehrere Folien festlegen?**  
[Assign the image as the background](/slides/de/java/presentation-background/) auf der Master‑Folien oder dem entsprechenden Layout – alle Folien, die diesen Master/Layout verwenden, übernehmen den Hintergrund.

**Wie verhindere ich, dass die Präsentation durch viele Bilder stark anwächst?**  
Verwenden Sie ein einzelnes Bild mehrfach statt Duplikaten, wählen Sie angemessene Auflösungen, wenden Sie Kompression beim Speichern an und behalten Sie wiederholte Grafiken nach Möglichkeit im Master.