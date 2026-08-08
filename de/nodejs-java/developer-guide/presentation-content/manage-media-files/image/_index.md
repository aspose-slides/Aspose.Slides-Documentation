---
title: Optimieren Sie die Bildverwaltung in Präsentationen mit JavaScript
linktitle: Bilder verwalten
type: docs
weight: 10
url: /de/nodejs-java/image/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Optimieren Sie die Bildverwaltung in PowerPoint und OpenDocument mit Aspose.Slides für Node.js via Java, verbessern Sie die Leistung und automatisieren Sie Ihren Arbeitsablauf."
---
## **Einführung**

Bilder machen Präsentationen ansprechender und visuell ansprechender. In Microsoft PowerPoint können Sie Bilder aus Dateien, dem Internet oder anderen Quellen auf Folien einfügen. Ebenso ermöglicht Aspose.Slides das Hinzufügen von Bildern zu Präsentationsfolien auf verschiedene Weise.

{{% alert  title="Tipp" color="primary" %}} 

Aspose bietet kostenlose Konverter—[JPEG zu PowerPoint](https://products.aspose.app/slides/de/import/jpg-to-ppt) und [PNG zu PowerPoint](https://products.aspose.app/slides/de/import/png-to-ppt)—die es Ihnen ermöglichen, schnell Präsentationen aus Bildern zu erstellen. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Wenn Sie ein Bild als Bildrahmen hinzufügen möchten – insbesondere wenn Sie es skalieren, Effekte anwenden oder andere Standardformatierungsoptionen nutzen wollen – siehe [Bildrahmen](/slides/de/nodejs-java/picture-frame/). 

{{% /alert %}} 

{{% alert title="Hinweis" color="warning" %}}

Sie können Bilder von einem Format in ein anderes konvertieren. Siehe die folgenden Seiten: konvertieren [Bild zu JPG](https://products.aspose.com/slides/de/nodejs-java/conversion/image-to-jpg/), [JPG zu Bild](https://products.aspose.com/slides/de/nodejs-java/conversion/jpg-to-image/), [JPG zu PNG](https://products.aspose.com/slides/de/nodejs-java/conversion/jpg-to-png/), [PNG zu JPG](https://products.aspose.com/slides/de/nodejs-java/conversion/png-to-jpg/), [PNG zu SVG](https://products.aspose.com/slides/de/nodejs-java/conversion/png-to-svg/), und [SVG zu PNG](https://products.aspose.com/slides/de/nodejs-java/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides unterstützt Bilder in gängigen Formaten wie JPEG, PNG, BMP, GIF und anderen. 

## **Lokale Bilder zu Folien hinzufügen**

Sie können ein oder mehrere auf Ihrem Computer gespeicherte Bilder zu einer Präsentationsfolie hinzufügen. Der folgende JavaScript-Beispielcode zeigt, wie ein Bild zu einer Folie hinzugefügt wird:

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

## **Bilder aus dem Web zu Folien hinzufügen**

Wenn das Bild, das Sie zu einer Folie hinzufügen möchten, nicht auf Ihrem Computer gespeichert ist, können Sie es direkt aus dem Web hinzufügen. 

Der folgende JavaScript-Beispielcode zeigt, wie ein Bild aus dem Web zu einer Folie hinzugefügt wird:

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

## **Bilder zu Folienmaster hinzufügen**

Ein Folienmaster speichert und steuert Informationen wie das Design und das Layout für die Folien, die ihn verwenden. Wenn Sie ein Bild zu einem Folienmaster hinzufügen, erscheint das Bild auf jeder Folie, die auf diesem Master basiert. 

Der folgende JavaScript-Beispielcode zeigt, wie ein Bild zu einem Folienmaster hinzugefügt wird:

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

## **Bilder als Folienhintergrund hinzufügen**

Sie können ein Bild als Hintergrund für eine oder mehrere Folien verwenden. Weitere Details finden Sie unter *[Bilder als Hintergrund für Folien festlegen](/slides/de/nodejs-java/presentation-background/#setting-images-as-background-for-slides)*.

## **SVG zu Präsentationen hinzufügen**

SVG‑Inhalte können mittels der Klasse [SvgImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/svgimage/) zu einer Präsentation hinzugefügt werden. Das resultierende SVG‑Bildobjekt kann anschließend zur Bildsammlung der Präsentation hinzugefügt und verwendet werden, um einen Bildrahmen zu erstellen.

Der folgende JavaScript‑Beispielcode importiert einen eigenständigen SVG‑String. Alle Bilder, Stile und anderen Ressourcen, die von diesem SVG verwendet werden, sind direkt im SVG‑Inhalt eingebettet.

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

## **SVG-Inhalt mit externen Ressourcen importieren**

Aus Design‑Tools, Diagramm‑Editoren, Icon‑Systemen und Web‑Pipelines exportierte SVG‑Dateien können Ressourcen referenzieren, die außerhalb des SVG‑Dokuments gespeichert sind. Beispielsweise kann ein SVG einen Bildlink wie `images/photo.png`, einen CSS‑`url(...)`‑Wert oder eine Schrift‑URL enthalten.

Um solche SVG‑Inhalte zu importieren, stellen Sie einen externen Ressourcen‑Resolver bereit und übergeben ihn zusammen mit einem Basis‑URI an einen passenden [SvgImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/svgimage/)-Konstruktor. Der Basis‑URI identifiziert den Speicherort des SVG‑Dokuments und wird zur Auflösung relativer Links verwendet.

Die Klasse `SvgImage` bietet Zugriff auf Informationen über das importierte SVG:

- `getSvgContent()` gibt den SVG‑Markup‑String zurück.
- `getSvgData()` gibt den SVG‑Inhalt als Byte‑Array zurück.
- `getBaseUri()` gibt den für relative Links verwendeten Basis‑URI zurück.
- `getExternalResourceResolver()` gibt den dem SVG‑Bild zugeordneten Resolver zurück.

### **Implementierung eines externen Ressourcenauflösers**

Der Resolver verfügt über zwei Methoden:

- `resolveUri` kombiniert den Basis‑URI mit einem relativen Ressourcen‑Link und gibt einen absoluten URI zurück. Gibt `null` zurück, wenn der Link nicht aufgelöst werden kann oder nicht erlaubt ist.
- `getEntity` gibt einen lesbaren Java‑Stream für einen absoluten Ressourcen‑URI zurück. Gibt `null` zurück, wenn die Ressource fehlt, blockiert oder nicht verfügbar ist. Bei Bedarf kann auch ein Fallback‑Stream zurückgegeben werden.

Der folgende Helfer erstellt einen Resolver, der verknüpfte Ressourcen nur aus einem zulässigen lokalen Verzeichnis lädt. Netzwerkressourcen und Pfade außerhalb des erlaubten Verzeichnisses werden blockiert. Für nicht aufgelöste Bildlinks wird ein optionales Fallback‑Bild zurückgegeben.

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

                // Dieser Resolver erlaubt absichtlich nur lokale Dateien.
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

                // Verwenden Sie ein Fallback nur für Bildressourcen. Das Zurückgeben eines Bild-Streams
                // für eine fehlende Schriftart oder ein Stylesheet wäre nicht gültig.
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

### **Verknüpfte Ressourcen während des SVG-Imports auflösen**

Angenommen, `assets/diagram.svg` enthält einen relativen Verweis wie:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Der folgende JavaScript‑Beispielcode übergibt den SVG‑Datei‑URI als Basis‑URI und stellt einen benutzerdefinierten Resolver bereit. Der Resolver wandelt den relativen Bildlink in einen absoluten URI um und gibt einen Stream zurück, der die verknüpfte Ressource enthält, während Aspose.Slides das SVG verarbeitet.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");
const { pathToFileURL } = require("url");

const svgFilePath = path.resolve("assets", "diagram.svg");
const assetDirectory = path.dirname(svgFilePath);
const svgContent = fs.readFileSync(svgFilePath, "utf8");

// Der Basis-URI gibt den Speicherort des SVG-Dokuments an.
const baseUri = pathToFileURL(svgFilePath).href;

let fallbackImageData = null;
const fallbackImagePath = path.join(assetDirectory, "fallback.png");
if (fs.existsSync(fallbackImagePath)) {
    fallbackImageData = fs.readFileSync(fallbackImagePath);
}

const resolver = createLocalSvgResourceResolver(assetDirectory, fallbackImageData);
const svgImage = new aspose.slides.SvgImage(svgContent, resolver, baseUri);

// SvgImage stellt den Quellinhalt, die Binärdaten, den Basis-URI und den Resolver bereit.
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

Die Klasse `SvgImage` bietet zudem Überladungen, die SVG‑Daten als Byte‑Array akzeptieren, sowie stream‑basierte Fabrikmethoden zusammen mit einem externen Ressourcen‑Resolver und einem Basis‑URI.

{{% alert title="Wichtig" color="warning" %}}

Der Ressourcen‑Resolver stellt externe Ressourcen während der Verarbeitung und Darstellung des SVG durch Aspose.Slides zur Verfügung. Er verändert das ursprüngliche SVG‑Markup nicht und bettet die aufgelösten Ressourcen nicht automatisch darin ein.

Wenn ein SVG‑Bild zur Bildsammlung der Präsentation hinzugefügt wird, kann die PPTX‑Datei sowohl die originale SVG‑Darstellung als auch ein Raster‑Fallback‑Bild enthalten. Eine verknüpfte Ressource kann im erzeugten Fallback‑Bild erscheinen, während ein relativer Link wie `images/photo.png` im gespeicherten SVG unverändert bleibt. Eine Anwendung, die die native SVG‑Darstellung rendert, könnte daher den verknüpften Inhalt weglassen, wenn die ursprüngliche externe Ressource nicht verfügbar ist.

{{% /alert %}}

### **Ein tragbares SVG-Bild erstellen**

Um ein SVG‑Bild zu erzeugen, das nicht von externen Dateien abhängt, machen Sie das SVG vor der Erstellung des `SvgImage` eigenständig. Ersetzen Sie beispielsweise verknüpfte Bild‑URLs durch `data:`‑URIs, die die Bilddaten enthalten:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Nachdem alle erforderlichen Ressourcen im SVG‑Inhalt eingebettet wurden, erstellen Sie das `SvgImage`, fügen es der Bildsammlung der Präsentation hinzu und setzen es wie im vorherigen Beispiel in einen Bildrahmen ein.

### **Fehlende oder blockierte Ressourcen behandeln**

Geben Sie `null` von `resolveUri` zurück, wenn ein Ressourcen‑URI ungültig, verboten oder nicht auflösbar ist. Geben Sie `null` von `getEntity` zurück, wenn die Ressource nicht gelesen werden kann. Aspose.Slides setzt die Verarbeitung des SVG ohne diese Ressource fort, sofern möglich.

Ein Fallback‑Stream kann für eine fehlende Ressource zurückgegeben werden, jedoch muss dessen Inhalt zum gewünschten Ressourcentyp passen. Beispiel: Ein Bild‑Stream darf nur für ein fehlendes Bild zurückgegeben werden, nicht für eine Schriftart oder ein Stylesheet.

{{% alert title="Sicherheit" color="warning" %}}

Lösen Sie keine beliebigen Dateipfade oder unbeschränkten Netzwerk‑URLs aus nicht vertrauenswürdigen SVG‑Dateien auf. Beschränken Sie zulässige Schemata, Verzeichnisse und Hosts. Für Netzwerkressourcen gelten außerdem Verbindungs‑Timeouts, Begrenzungen der Antwortgröße und Inhaltsvalidierung.

{{% /alert %}}

## **SVG in ein Satz von Formen konvertieren**

Aspose.Slides kann ein SVG in ein Satz von Formen umwandeln, ähnlich der entsprechenden Funktionalität in PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

Diese Funktion wird bereitgestellt durch eine Überladung der Methode [addGroupShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ShapeCollection#addGroupShape-aspose.slides.ISvgImage-float-float-float-float-) der Klasse [ShapeCollection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ShapeCollection), die ein SVG‑Bildobjekt als erstes Argument erwartet.

Der folgende JavaScript‑Beispielcode zeigt, wie diese Methode verwendet wird, um eine SVG‑Datei in ein Satz von Formen zu konvertieren:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

// Quell-SVG-Dateiname.
const svgFileName = "sample.svg";

// Ausgabedateiname der Präsentation.
const outPptxPath = "presentation.pptx";

// Neue Präsentation erstellen.
const presentation = new aspose.slides.Presentation();
try {
    // SVG-Dateiinhalt lesen.
    const svgContent = java.newArray("byte", Array.from(fs.readFileSync(svgFileName)));

    // Ein SvgImage-Objekt erstellen.
    const svgImage = new aspose.slides.SvgImage(svgContent);

    // Die Foliengröße ermitteln.
    const slideSize = presentation.getSlideSize().getSize();

    // SVG-Bild in eine Gruppe von Formen konvertieren und auf die Foliengröße skalieren.
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(
        svgImage, 0.0, 0.0, slideSize.getWidth(), slideSize.getHeight());

    // Präsentation im PPTX-Format speichern.
    presentation.save(outPptxPath, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Bilder als EMF zu Folien hinzufügen**

Aspose.Slides für Node.js via Java ermöglicht das Erzeugen von EMF‑Bildern aus Excel‑Arbeitsblättern mit Aspose.Cells und das Hinzufügen dieser zu Präsentationsfolien.

Der folgende JavaScript‑Beispielcode zeigt, wie das funktioniert:

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

// Arbeitsmappe in einen Stream speichern.
const sr = java.newInstanceSync("SheetRender", sheet, options);
const pres = new aspose.slides.Presentation();
try {
    pres.getSlides().removeAt(0);

    for (let j = 0; j < sr.getPageCount(); j++) {
        const emfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, emfSheetName);

        // Die Datei unverändert hinzufügen, damit das Bild ein Vektor‑EMF bleibt und nicht gerastert wird.
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

## **Bilder in der Bildsammlung ersetzen**

Aspose.Slides lässt Sie Bilder, die in der Bildsammlung einer Präsentation gespeichert sind, ersetzen, einschließlich der Bilder, die von Folienformen verwendet werden. Dieser Abschnitt beschreibt mehrere Möglichkeiten, Bilder in der Sammlung zu aktualisieren. Sie können ein Bild mithilfe roher Byte‑Daten, einer [IImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/iimage/)-Instanz oder einem bereits in der Sammlung vorhandenen Bild ersetzen.

Folgen Sie den nachstehenden Schritten:

1. Laden Sie die Präsentationsdatei, die Bilder enthält, mit der Klasse [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/).
2. Laden Sie ein neues Bild aus einer Datei in ein Byte‑Array.
3. Ersetzen Sie das Zielbild durch das neue Bild mithilfe des Byte‑Arrays.
4. Im zweiten Ansatz laden Sie das Bild in ein [IImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/iimage/)-Objekt und ersetzen das Zielbild durch dieses Objekt.
5. Im dritten Ansatz ersetzen Sie das Zielbild durch ein Bild, das bereits in der Bildsammlung der Präsentation vorhanden ist.
6. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // Erster Ansatz.
    const imageData = java.newArray("byte", Array.from(fs.readFileSync("image0.jpeg")));
    let oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);

    // Zweiter Ansatz.
    const newImage = aspose.slides.Images.fromFile("image1.png");
    try {
        oldImage = presentation.getImages().get_Item(1);
        oldImage.replaceImage(newImage);
    } finally {
        if (newImage != null) {
            newImage.dispose();
        }
    }

    // Dritter Ansatz.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));

    // Speichern Sie die Präsentation in einer Datei.
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}

Mit Asposes kostenlosem [Text zu GIF](https://products.aspose.app/slides/de/text-to-gif)‑Konverter können Sie Texte einfach animieren und GIFs aus Text erstellen. 

{{% /alert %}}

## **FAQ**

**Bleibt die ursprüngliche Bildauflösung nach dem Einfügen unverändert?**

Ja. Die Quellpixel werden beibehalten, aber das endgültige Erscheinungsbild hängt davon ab, wie das [Bild](/slides/de/nodejs-java/picture-frame/) auf der Folie skaliert wird und welche Kompression beim Speichern angewendet wird.

**Was ist der beste Weg, dasselbe Logo gleichzeitig auf Dutzenden von Folien zu ersetzen?**

Platzieren Sie das Logo auf dem Master‑Slide oder einem Layout und ersetzen Sie es in der Bildsammlung der Präsentation – die Änderungen werden auf alle Elemente, die diese Ressource verwenden, übertragen.

**Kann ein eingefügtes SVG in editierbare Formen umgewandelt werden?**

Ja. Sie können ein SVG in eine Gruppe von Formen konvertieren, woraufhin einzelne Teile mit den üblichen Form‑Eigenschaften bearbeitbar werden.

**Wie kann ich ein Bild gleichzeitig als Hintergrund für mehrere Folien festlegen?**

[Weisen Sie das Bild als Hintergrund](/slides/de/nodejs-java/presentation-background/) dem Master‑Slide oder dem entsprechenden Layout zu – alle Folien, die diesen Master/Layout verwenden, erben den Hintergrund.

**Wie verhindere ich, dass eine Präsentation aufgrund vieler Bilder zu groß wird?**

Verwenden Sie eine einzelne Bildressource statt Duplikaten, wählen Sie vernünftige Auflösungen, komprimieren Sie beim Speichern und halten Sie wiederholte Grafiken nach Möglichkeit im Master.