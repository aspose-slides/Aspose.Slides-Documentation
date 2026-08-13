---
title: Optimieren der Bildverwaltung in Präsentationen mit Java
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
- aus dem Web
- Hintergrund
- PNG hinzufügen
- JPG hinzufügen
- SVG hinzufügen
- externe SVG-Ressourcen
- SVG-Resolver
- verknüpfte SVG-Bilder
- SVG-Schriften
- EMF hinzufügen
- WMF hinzufügen
- TIFF hinzufügen
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Optimieren Sie die Bildverwaltung in PowerPoint und OpenDocument mit Aspose.Slides für Java, verbessern Sie die Leistung und automatisieren Sie Ihren Arbeitsablauf."
---
## **Einleitung**

Bilder machen Präsentationen ansprechender und visuell attraktiver. In Microsoft PowerPoint können Sie Bilder aus Dateien, dem Internet oder anderen Quellen in Folien einfügen. Ebenso ermöglicht Aspose.Slides das Hinzufügen von Bildern zu Präsentationsfolien auf verschiedene Weise.

{{% alert title="Tipp" color="info" %}} 

Aspose bietet kostenlose Konverter—[JPEG nach PowerPoint](https://products.aspose.app/slides/de/import/jpg-to-ppt) und [PNG nach PowerPoint](https://products.aspose.app/slides/de/import/png-to-ppt)—mit denen Sie schnell Präsentationen aus Bildern erstellen können. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Wenn Sie ein Bild als Bildrahmen hinzufügen möchten—insbesondere wenn Sie es skalieren, Effekte anwenden oder andere Standardformatierungsoptionen nutzen wollen—sehen Sie sich [Bildrahmen](/slides/de/java/picture-frame/) an. 

{{% /alert %}} 

{{% alert title="Hinweis" color="warning" %}}

Sie können Bilder von einem Format in ein anderes konvertieren. Siehe die folgenden Seiten: Konvertieren Sie [Bild zu JPG](https://products.aspose.com/slides/de/java/conversion/image-to-jpg/), [JPG zu Bild](https://products.aspose.com/slides/de/java/conversion/jpg-to-image/), [JPG zu PNG](https://products.aspose.com/slides/de/java/conversion/jpg-to-png/), [PNG zu JPG](https://products.aspose.com/slides/de/java/conversion/png-to-jpg/), [PNG zu SVG](https://products.aspose.com/slides/de/java/conversion/png-to-svg/), und [SVG zu PNG](https://products.aspose.com/slides/de/java/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides unterstützt Bilder in gängigen Formaten wie JPEG, PNG, BMP, GIF und anderen. 

## **Lokale Bilder zu Folien hinzufügen**

Sie können ein oder mehrere Bilder, die auf Ihrem Computer gespeichert sind, zu einer Präsentationsfolie hinzufügen. Der folgende Java‑Beispielcode zeigt, wie ein Bild zu einer Folie hinzugefügt wird:

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

## **Bilder aus dem Web zu Folien hinzufügen**

Wenn das Bild, das Sie zu einer Folie hinzufügen möchten, nicht auf Ihrem Computer gespeichert ist, können Sie es direkt aus dem Web hinzufügen. 

Der folgende Java‑Beispielcode zeigt, wie ein Bild aus dem Web zu einer Folie hinzugefügt wird:

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

## **Bilder zu Folienmaster hinzufügen**

Ein Folienmaster speichert und steuert Informationen wie das Design und das Layout für die Folien, die ihn verwenden. Wenn Sie ein Bild zu einem Folienmaster hinzufügen, erscheint das Bild auf jeder Folie, die auf diesem Master basiert. 

Der folgende Java‑Beispielcode zeigt, wie ein Bild zu einem Folienmaster hinzugefügt wird:

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

## **Bilder als Folienhintergründe hinzufügen**

Sie können ein Bild als Hintergrund für eine oder mehrere Folien verwenden. Weitere Details finden Sie unter *[Bilder als Hintergründe für Folien festlegen](/slides/de/java/presentation-background/#setting-images-as-background-for-slides)*.

## **SVG zu Präsentationen hinzufügen**

SVG‑Inhalte können einer Präsentation mithilfe der Klasse [SvgImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/svgimage/) hinzugefügt werden. Das resultierende [ISvgImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/isvgimage/)‑Objekt kann dann zur Bildsammlung der Präsentation hinzugefügt und verwendet werden, um einen Bildrahmen zu erstellen.

Der folgende Java‑Beispiel importiert einen eigenständigen SVG‑String. Alle von diesem SVG verwendeten Bilder, Styles und weitere Ressourcen sind direkt im SVG‑Inhalt eingebettet.

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

## **SVG‑Inhalt mit externen Ressourcen importieren**

Aus Design‑Tools, Diagramm‑Editoren, Icon‑Systemen und Web‑Pipelines exportierte SVG‑Dateien können Ressourcen referenzieren, die außerhalb des SVG‑Dokuments gespeichert sind. Beispielsweise kann ein SVG einen Bild‑Link wie `images/photo.png`, einen CSS‑`url(...)`‑Wert oder eine Schrift‑URL enthalten.

Um solche SVG‑Inhalte zu importieren, erstellen Sie eine Implementierung von [IExternalResourceResolver](https://reference.aspose.com/slides/de/java/com.aspose.slides/iexternalresourceresolver/) und übergeben Sie sie zusammen mit einer Basis‑URI an einen geeigneten [SvgImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/svgimage/)‑Konstruktor. Die Basis‑URI identifiziert den Speicherort des SVG‑Dokuments und wird zum Auflösen relativer Links verwendet.

Die [ISvgImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/isvgimage/)‑Schnittstelle bietet Zugriff auf Informationen über das importierte SVG:

- `getSvgContent()` gibt den SVG‑Markup‑String zurück.
- `getSvgData()` gibt den SVG‑Inhalt als Byte‑Array zurück.
- `getBaseUri()` gibt die für relative Links verwendete Basis‑URI zurück.
- `getExternalResourceResolver()` gibt den dem SVG‑Bild zugeordneten Resolver zurück.

### **Implementieren eines externen Ressourcen‑Resolvers**

Der Resolver hat zwei Methoden:

- `resolveUri` kombiniert die Basis‑URI und einen relativen Ressourcen‑Link und gibt eine absolute URI zurück. Gibt `null` zurück, wenn der Link nicht aufgelöst werden kann oder nicht erlaubt ist.
- `getEntity` gibt einen lesbaren Stream für eine absolute Ressourcen‑URI zurück. Gibt `null` zurück, wenn die Ressource fehlt, blockiert oder nicht verfügbar ist. Ein Fallback‑Stream kann ebenfalls zurückgegeben werden, wenn dies angemessen ist.

Der folgende Resolver lädt verknüpfte Ressourcen nur aus einem zulässigen lokalen Verzeichnis. Netzwerkressourcen und Pfade außerhalb des zulässigen Verzeichnisses werden blockiert. Für nicht aufgelöste Bild‑Links wird optional ein Fallback‑Bild zurückgegeben.

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

            // Dieser Resolver erlaubt absichtlich nur lokale Dateien.
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

            // Verwenden Sie einen Fallback nur für Bildressourcen. Das Zurückgeben eines Bild-Streams
            // für eine fehlende Schriftart oder ein Stylesheet wäre nicht gültig.
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

### **Verknüpfte Ressourcen während des SVG‑Imports auflösen**

Angenommen, `assets/diagram.svg` enthält einen relativen Verweis wie:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Der folgende Java‑Beispielcode übergibt die SVG‑Datei‑URI als Basis‑URI und liefert einen benutzerdefinierten Resolver. Der Resolver wandelt den relativen Bild‑Link in eine absolute URI um und gibt einen Stream zurück, der die verknüpfte Ressource enthält, während Aspose.Slides das SVG verarbeitet.

```java
import com.aspose.slides.*;

import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path svgFilePath = Paths.get("assets", "diagram.svg").toAbsolutePath().normalize();
Path assetDirectory = svgFilePath.getParent();
String svgContent = new String(Files.readAllBytes(svgFilePath), StandardCharsets.UTF_8);

// Die Basis-URI stellt den Speicherort des SVG-Dokuments dar.
String baseUri = svgFilePath.toUri().toString();

byte[] fallbackImageData = null;
Path fallbackImagePath = assetDirectory.resolve("fallback.png");
if (Files.exists(fallbackImagePath)) {
    fallbackImageData = Files.readAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory.toString(), fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// ISvgImage stellt den Quellinhalt, Binärdaten, Basis-URI und Resolver bereit.
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

Die Klasse `SvgImage` bietet außerdem Überladungen, die SVG‑Daten als Byte‑Array oder Input‑Stream zusammen mit einem externen Ressourcen‑Resolver und einer Basis‑URI akzeptieren.

{{% alert title="Wichtig" color="warning" %}}

Der Ressourcen‑Resolver stellt externe Ressourcen während der Verarbeitung und Renderung des SVGs durch Aspose.Slides bereit. Er ändert das ursprüngliche SVG‑Markup nicht und bettet die aufgelösten Ressourcen nicht automatisch darin ein.

Wenn ein `ISvgImage` zur Bildsammlung der Präsentation hinzugefügt wird, kann die PPTX‑Datei sowohl die originale SVG‑Darstellung als auch ein Raster‑Fallback‑Bild enthalten. Eine verknüpfte Ressource kann im erzeugten Fallback‑Bild erscheinen, während ein relativer Link wie `images/photo.png` unverändert im gespeicherten SVG bleibt. Eine Anwendung, die die native SVG‑Darstellung rendert, kann daher den verknüpften Inhalt weglassen, wenn die ursprüngliche externe Ressource nicht verfügbar ist.

{{% /alert %}}

### **Erstellen eines portablen SVG‑Bildes**

Um ein SVG‑Bild zu erzeugen, das nicht von externen Dateien abhängt, machen Sie das SVG vor der Erstellung des `SvgImage` eigenständig. Ersetzen Sie beispielsweise verknüpfte Bild‑URLs durch `data:`‑URIs, die die Bilddaten enthalten:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Nachdem alle erforderlichen Ressourcen im SVG‑Inhalt eingebettet wurden, erstellen Sie das `SvgImage`, fügen es der Bildsammlung der Präsentation hinzu und setzen es in einen Bildrahmen ein, wie im vorherigen Beispiel gezeigt.

### **Umgang mit fehlenden oder blockierten Ressourcen**

Geben Sie `null` von `resolveUri` zurück, wenn eine Ressourcen‑URI ungültig, verboten oder nicht auflösbar ist. Geben Sie `null` von `getEntity` zurück, wenn die Ressource nicht gelesen werden kann. Aspose.Slides verarbeitet das SVG nach Möglichkeit weiter, ohne diese Ressource.

Ein Fallback‑Stream kann für eine fehlende Ressource zurückgegeben werden, muss jedoch mit dem angeforderten Ressourcentyp kompatibel sein. Zum Beispiel sollte ein Bild‑Stream nur für ein fehlendes Bild zurückgegeben werden, nicht für eine Schriftart oder ein Stylesheet.

{{% alert title="Sicherheit" color="warning" %}}

Lösen Sie keine beliebigen Dateipfade oder uneingeschränkten Netzwerk‑URLs aus nicht vertrauenswürdigen SVG‑Dateien auf. Beschränken Sie erlaubte Schemes, Verzeichnisse und Hosts. Für Netzwerkressourcen gelten außerdem Verbindungs‑Timeouts, Begrenzungen der Antwortgröße und Inhaltsvalidierung.

{{% /alert %}}

## **SVG in eine Menge von Formen konvertieren**

Aspose.Slides kann ein SVG in eine Menge von Formen konvertieren, ähnlich der entsprechenden Funktionalität in PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

Diese Funktionalität wird durch eine Überladung der Methode [addGroupShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) des [IShapeCollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/IShapeCollection)‑Interface bereitgestellt, die ein [ISvgImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISvgImage)‑Objekt als erstes Argument entgegennimmt.

Der folgende Java‑Beispielcode zeigt, wie diese Methode verwendet wird, um eine SVG‑Datei in eine Menge von Formen zu konvertieren:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

// Quelldateiname der SVG-Datei.
String svgFileName = "sample.svg";

// Ausgabedateiname der Präsentation.
String outPptxPath = "presentation.pptx";

// Neue Präsentation erstellen.
IPresentation presentation = new Presentation();
try {
    // SVG-Dateiinhalt lesen.
    byte[] svgContent = Files.readAllBytes(Paths.get(svgFileName));

    // Ein SvgImage-Objekt erstellen.
    ISvgImage svgImage = new SvgImage(svgContent);

    // Foliengröße ermitteln.
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // Das SVG-Bild in eine Gruppe von Formen konvertieren und an die Foliengröße anpassen.
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(
            svgImage, 0f, 0f,
            (float) slideSize.getWidth(), (float) slideSize.getHeight());

    // Präsentation im PPTX-Format speichern.
    presentation.save(outPptxPath, SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    presentation.dispose();
}
```

## **Bilder als EMF zu Folien hinzufügen**

Aspose.Slides für Java ermöglicht es, EMF‑Bilder aus Excel‑Arbeitsblättern mit Aspose.Cells zu erzeugen und sie zu Präsentationsfolien hinzuzufügen.

Der folgende Java‑Beispielcode zeigt, wie das funktioniert:

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

// Speichern Sie das Arbeitsbuch in einen Stream.
SheetRender sr = new SheetRender(sheet, options);
Presentation pres = new Presentation();
try {
    pres.getSlides().removeAt(0);

    String emfSheetName;
    for (int j = 0; j < sr.getPageCount(); j++) {
        emfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, emfSheetName);

        // Datei unverändert hinzufügen, damit das Bild ein Vektor-EMF bleibt und nicht gerastert wird.
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

## **Bilder in der Bildsammlung ersetzen**

Aspose.Slides ermöglicht das Ersetzen von Bildern, die in der Bildsammlung einer Präsentation gespeichert sind, einschließlich der von Folienformen verwendeten Bilder. Dieser Abschnitt beschreibt mehrere Möglichkeiten, Bilder in der Sammlung zu aktualisieren. Sie können ein Bild mithilfe von rohen Byte‑Daten, einer [IImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/iimage/)‑Instanz oder einem anderen bereits in der Sammlung vorhandenen Bild ersetzen.

Folgen Sie den unten stehenden Schritten:

1. Laden Sie die Präsentationsdatei, die Bilder enthält, mit der Klasse [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/) .
2. Laden Sie ein neues Bild aus einer Datei in ein Byte‑Array.
3. Ersetzen Sie das Zielbild durch das neue Bild mithilfe des Byte‑Arrays.
4. Im zweiten Ansatz laden Sie das Bild in ein [IImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/iimage/)‑Objekt und ersetzen das Zielbild durch dieses Objekt.
5. Im dritten Ansatz ersetzen Sie das Zielbild durch ein Bild, das bereits in der Bildsammlung der Präsentation existiert.
6. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Erster Weg.
    byte[] imageData = Files.readAllBytes(Paths.get("image0.jpeg"));
    IPPImage oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);

    // Zweiter Weg.
    IImage newImage = Images.fromFile("image1.png");
    try {
        oldImage = presentation.getImages().get_Item(1);
        oldImage.replaceImage(newImage);
    } finally {
        if (newImage != null) newImage.dispose();
    }

    // Dritter Weg.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));

    // Speichern Sie die Präsentation in einer Datei.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}

Mit Asposes kostenlosem [Text zu GIF](https://products.aspose.app/slides/de/text-to-gif)‑Konverter können Sie Text leicht animieren und GIFs aus Text erstellen. 

{{% /alert %}}

## **FAQ**

**Bleibt die ursprüngliche Bildauflösung nach dem Einfügen erhalten?**

Ja. Die Quellpixel werden beibehalten, aber das endgültige Erscheinungsbild hängt davon ab, wie das [Bild](/slides/de/java/picture-frame/) auf der Folie skaliert wird und welche Kompression beim Speichern angewendet wird.

**Wie ersetzt man am besten dasselbe Logo gleichzeitig auf Dutzenden von Folien?**

Platzieren Sie das Logo auf dem Master‑Slide oder einem Layout und ersetzen Sie es in der Bildsammlung der Präsentation – die Änderungen werden auf alle Elemente übertragen, die diese Ressource verwenden.

**Kann ein eingefügtes SVG in editierbare Formen konvertiert werden?**

Ja. Sie können ein SVG in eine Gruppe von Formen konvertieren, woraufhin einzelne Teile mit den Standard‑Formeigenschaften bearbeitet werden können.

**Wie kann ich ein Bild als Hintergrund für mehrere Folien gleichzeitig festlegen?**

[Weisen Sie das Bild als Hintergrund](/slides/de/java/presentation-background/) dem Master‑Slide oder dem entsprechenden Layout zu – alle Folien, die diesen Master/Layout verwenden, erben den Hintergrund.

**Wie verhindere ich, dass eine Präsentation durch zu viele Bilder zu groß wird?**

Verwenden Sie dieselbe Bildressource mehrfach statt Duplikaten, wählen Sie angemessene Auflösungen, komprimieren Sie beim Speichern und halten Sie wiederholte Grafiken nach Möglichkeit im Master.