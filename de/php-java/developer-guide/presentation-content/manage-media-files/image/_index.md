---
title: Optimieren Sie die Bildverwaltung in Präsentationen mit PHP
linktitle: Bilder verwalten
type: docs
weight: 10
url: /de/php-java/image/
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
- verlinkte SVG-Bilder
- SVG-Schriften
- EMF hinzufügen
- WMF hinzufügen
- TIFF hinzufügen
- PowerPoint
- OpenDocument
- Präsentation
- EMF
- SVG
- PHP
- Aspose.Slides
description: "Vereinfachen Sie die Bildverwaltung in PowerPoint und OpenDocument mit Aspose.Slides für PHP via Java, optimieren Sie die Leistung und automatisieren Sie Ihren Arbeitsablauf."
---
## **Einleitung**

Bilder machen Präsentationen ansprechender und visuell ansprechender. In Microsoft PowerPoint können Sie Bilder aus Dateien, dem Internet oder anderen Quellen in Folien einfügen. Ähnlich ermöglicht Aspose.Slides das Hinzufügen von Bildern zu Präsentationsfolien auf verschiedene Arten.

{{% alert  title="Tip" color="primary" %}} 

Aspose stellt kostenlose Konverter—[JPEG zu PowerPoint](https://products.aspose.app/slides/de/import/jpg-to-ppt) und [PNG zu PowerPoint](https://products.aspose.app/slides/de/import/png-to-ppt)—zur Verfügung, mit denen Sie schnell Präsentationen aus Bildern erstellen können. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Wenn Sie ein Bild als Bildrahmen hinzufügen möchten – insbesondere wenn Sie es skalieren, Effekte anwenden oder andere Standardformatierungsoptionen verwenden wollen – sehen Sie sich [Picture Frame](/slides/de/php-java/picture-frame/) an. 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Sie können Bilder von einem Format in ein anderes konvertieren. Siehe die folgenden Seiten: konvertieren Sie [image to JPG](https://products.aspose.com/slides/de/php-java/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/de/php-java/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/de/php-java/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/de/php-java/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/de/php-java/conversion/png-to-svg/) und [SVG to PNG](https://products.aspose.com/slides/de/php-java/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides unterstützt Bilder in gängigen Formaten wie JPEG, PNG, BMP, GIF und anderen. 

## **Bilder, die lokal gespeichert sind, zu Folien hinzufügen**

Sie können ein oder mehrere auf Ihrem Computer gespeicherte Bilder zu einer Präsentationsfolie hinzufügen. Der folgende PHP‑Beispielcode zeigt, wie ein Bild zu einer Folie hinzugefügt wird:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $picture = null;
    $image = Images::fromFile("image.png");
    try {
        $picture = $pres->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);

    $pres->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```

## **Bilder aus dem Web zu Folien hinzufügen**

Wenn das Bild, das Sie zu einer Folie hinzufügen möchten, nicht auf Ihrem Computer gespeichert ist, können Sie es direkt aus dem Web hinzufügen. 

Der folgende PHP‑Beispielcode zeigt, wie ein Bild aus dem Web zu einer Folie hinzugefügt wird:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $imageUrl = new Java("java.net.URL", "[REPLACE WITH URL]");
    $connection = $imageUrl->openConnection();
    $inputStream = $connection->getInputStream();

    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    try {
        $buffer = $Array->newInstance($Byte, 1024);

        while (($read = java_values($inputStream->read($buffer, 0, $Array->getLength($buffer)))) != -1) {
            $outputStream->write($buffer, 0, $read);
        }

        $outputStream->flush();

        $image = $pres->getImages()->addImage($outputStream->toByteArray());
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $image);
    } finally {
        if (!java_is_null($inputStream)) {
            $inputStream->close();
        }
        $outputStream->close();
    }

    $pres->save("pres.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $pres->dispose();
}
```

## **Bilder zu Folienmaster hinzufügen**

Ein Folienmaster speichert und steuert Informationen wie das Design und Layout für die Folien, die ihn verwenden. Wenn Sie ein Bild zu einem Folienmaster hinzufügen, erscheint das Bild auf jeder Folie, die auf diesem Master basiert. 

Der folgende PHP‑Beispielcode zeigt, wie ein Bild zu einem Folienmaster hinzugefügt wird:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);
    $masterSlide = $slide->getLayoutSlide()->getMasterSlide();

    $picture = null;
    $image = Images::fromFile("image.png");
    try {
        $picture = $pres->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $masterSlide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);

    $pres->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```

## **Bilder als Folienhintergrund hinzufügen**

Sie können ein Bild als Hintergrund für eine oder mehrere Folien verwenden. Einzelheiten finden Sie unter *[Setting Images as Backgrounds for Slides](/slides/de/php-java/presentation-background/#setting-images-as-background-for-slides)*.

## **SVG zu Präsentationen hinzufügen**

SVG-Inhalte können mithilfe der Klasse [SvgImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/svgimage/) zu einer Präsentation hinzugefügt werden. Das resultierende SVG‑Bildobjekt kann dann zur Bildsammlung der Präsentation hinzugefügt und zur Erstellung eines Bildrahmens verwendet werden.

Das folgende PHP‑Beispiel importiert einen eigenständigen SVG‑String. Alle von diesem SVG verwendeten Bilder, Stile und andere Ressourcen sind direkt im SVG‑Inhalt eingebettet.

```php
$svgContent =
    "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" .
    "    <rect width='320' height='180' fill='#4F81BD'/>" .
    "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" .
    "</svg>";

$presentation = new Presentation();
try {
    $svgImage = new SvgImage($svgContent);
    $image = $presentation->getImages()->addImage($svgImage);

    $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        $image->getWidth(),
        $image->getHeight(),
        $image
    );

    $presentation->save("self-contained-svg.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **SVG-Inhalt mit externen Ressourcen importieren**

Aus Design‑Tools, Diagrammeditoren, Icon‑Systemen und Web‑Pipelines exportierte SVG‑Dateien können Ressourcen referenzieren, die außerhalb des SVG‑Dokuments gespeichert sind. Beispielsweise kann ein SVG einen Bild‑Link wie `images/photo.png`, einen CSS‑`url(...)`‑Wert oder eine Schrift‑URL enthalten.

Um einen solchen SVG‑Inhalt zu importieren, erstellen Sie eine Implementierung von [ExternalResourceResolver](https://reference.aspose.com/slides/de/php-java/aspose.slides/externalresourceresolver/) und übergeben Sie diese zusammen mit einer Basis‑URI an einen passenden [SvgImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/svgimage/)‑Konstruktor. Die Basis‑URI gibt den Speicherort des SVG‑Dokuments an und wird zum Auflösen relativer Links verwendet.

Das SVG‑Bildobjekt ermöglicht den Zugriff auf Informationen über das importierte SVG:

- `getSvgContent()` gibt den SVG‑Markup‑String zurück.
- `getSvgData()` gibt den SVG‑Inhalt als Byte‑Array zurück.
- `getBaseUri()` gibt die für relative Links verwendete Basis‑URI zurück.
- `getExternalResourceResolver()` gibt den dem SVG‑Bild zugewiesenen Resolver zurück.

### **Implementieren eines externen Ressourcen‑Resolvers**

Der Resolver hat zwei Methoden:

- `resolveUri` kombiniert die Basis‑URI und einen relativen Ressourcen‑Link und gibt eine absolute URI zurück. Gibt `null` zurück, wenn der Link nicht aufgelöst werden kann oder nicht erlaubt ist.
- `getEntity` gibt einen lesbaren Stream für eine absolute Ressourcen‑URI zurück. Gibt `null` zurück, wenn die Ressource fehlt, blockiert oder nicht verfügbar ist. Ein Fallback‑Stream kann bei Bedarf ebenfalls zurückgegeben werden.

Der folgende Resolver lädt verknüpfte Ressourcen nur aus einem erlaubten lokalen Verzeichnis. Netzwerkressourcen und Pfade außerhalb des erlaubten Verzeichnisses werden blockiert. Für nicht aufgelöste Bild‑Links wird ein optionales Ersatzbild zurückgegeben.

```php
class LocalSvgResourceResolver extends ExternalResourceResolver
{
    private $allowedRoot;
    private $fallbackImageData;

    public function __construct($allowedRoot, $fallbackImageData)
    {
        parent::__construct();

        $Paths = new JavaClass("java.nio.file.Paths");
        $this->allowedRoot = $Paths->get($allowedRoot)->toAbsolutePath()->normalize();
        $this->fallbackImageData = $fallbackImageData;
    }

    public function resolveUri($baseUri, $relativeUri)
    {
        if ($baseUri === null || trim(java_values($baseUri)) === "" ||
            $relativeUri === null || trim(java_values($relativeUri)) === "") {
            return null;
        }

        try {
            $URI = new JavaClass("java.net.URI");
            $baseAddress = $URI->create($baseUri);
            $absoluteAddress = $baseAddress->resolve($relativeUri);

            // Dieser Resolver erlaubt absichtlich nur lokale Dateien.
            if (strcasecmp(java_values($absoluteAddress->getScheme()), "file") !== 0) {
                return null;
            }

            $Paths = new JavaClass("java.nio.file.Paths");
            $resourcePath = $Paths->get($absoluteAddress)->toAbsolutePath()->normalize();

            if (!$this->isInsideAllowedRoot($resourcePath)) {
                return null;
            }

            return $resourcePath->toUri()->toString();
        } catch (JavaException $e) {
            return null;
        }
    }

    public function getEntity($absoluteUri)
    {
        try {
            $URI = new JavaClass("java.net.URI");
            $resourceUri = $URI->create($absoluteUri);

            if (strcasecmp(java_values($resourceUri->getScheme()), "file") !== 0) {
                return null;
            }

            $Paths = new JavaClass("java.nio.file.Paths");
            $resourcePath = $Paths->get($resourceUri)->toAbsolutePath()->normalize();

            if (!$this->isInsideAllowedRoot($resourcePath)) {
                return null;
            }

            $Files = new JavaClass("java.nio.file.Files");
            if (java_values($Files->exists($resourcePath))) {
                return $Files->newInputStream($resourcePath);
            }

            // Verwenden Sie nur für Bildressourcen einen Fallback. Das Zurückgeben eines Bild-Streams
            // für eine fehlende Schriftart oder ein Stylesheet wäre nicht gültig.
            if ($this->fallbackImageData !== null && $this->isImageFile($resourcePath)) {
                return new Java("java.io.ByteArrayInputStream", $this->fallbackImageData);
            }
        } catch (JavaException $e) {
            return null;
        }

        return null;
    }

    private function isInsideAllowedRoot($resourcePath)
    {
        return java_values($resourcePath->normalize()->startsWith($this->allowedRoot));
    }

    private function isImageFile($path)
    {
        $fileName = strtolower(java_values($path->getFileName()->toString()));

        return str_ends_with($fileName, ".png") ||
            str_ends_with($fileName, ".jpg") ||
            str_ends_with($fileName, ".jpeg") ||
            str_ends_with($fileName, ".gif") ||
            str_ends_with($fileName, ".bmp");
    }
}
```

### **Verknüpfte Ressourcen beim SVG‑Import auflösen**

Angenommen, `assets/diagram.svg` enthält einen relativen Verweis wie:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Das folgende PHP‑Beispiel übergibt die SVG‑Datei‑URI als Basis‑URI und stellt einen benutzerdefinierten Resolver bereit. Der Resolver wandelt den relativen Bild‑Link in eine absolute URI um und gibt einen Stream zurück, der die verknüpfte Ressource enthält, während Aspose.Slides das SVG verarbeitet.

```php
$Paths = new JavaClass("java.nio.file.Paths");
$Files = new JavaClass("java.nio.file.Files");
$StandardCharsets = new JavaClass("java.nio.charset.StandardCharsets");

$svgFilePath = $Paths->get("assets", "diagram.svg")->toAbsolutePath()->normalize();
$assetDirectory = $svgFilePath->getParent();

$svgData = $Files->readAllBytes($svgFilePath);
$svgContent = new Java("java.lang.String", $svgData, $StandardCharsets->UTF_8);

// Die Basis-URI gibt den Speicherort des SVG-Dokuments an.
$baseUri = $svgFilePath->toUri()->toString();

$fallbackImageData = null;
$fallbackImagePath = $assetDirectory->resolve("fallback.png");
if (java_values($Files->exists($fallbackImagePath))) {
    $fallbackImageData = $Files->readAllBytes($fallbackImagePath);
}

$resolver = new LocalSvgResourceResolver(java_values($assetDirectory->toString()), $fallbackImageData);
$svgImage = new SvgImage($svgContent, $resolver, $baseUri);

// Das SVG-Bildobjekt stellt den Quellinhalt, die Binärdaten, die Basis-URI und den Resolver bereit.
$importedContent = $svgImage->getSvgContent();
$importedData = $svgImage->getSvgData();
$importedBaseUri = $svgImage->getBaseUri();
$importedResolver = $svgImage->getExternalResourceResolver();

$presentation = new Presentation();
try {
    $image = $presentation->getImages()->addImage($svgImage);

    $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        $image->getWidth(),
        $image->getHeight(),
        $image
    );

    $presentation->save("svg-with-linked-resources.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Die Klasse `SvgImage` bietet außerdem Überladungen, die SVG‑Daten als Byte‑Array oder Eingabestream zusammen mit einem externen Ressourcen‑Resolver und einer Basis‑URI akzeptieren.

{{% alert title="Important" color="warning" %}}

Der Ressourcen‑Resolver stellt externe Ressourcen während der Verarbeitung und Renderung des SVG durch Aspose.Slides zur Verfügung. Er modifiziert das ursprüngliche SVG‑Markup nicht und bettet die aufgelösten Ressourcen nicht automatisch darin ein.

Wenn ein SVG‑Bild zur Bildsammlung der Präsentation hinzugefügt wird, kann die PPTX‑Datei sowohl die ursprüngliche SVG‑Darstellung als auch ein Raster‑Fallback‑Bild enthalten. Eine verknüpfte Ressource kann im erzeugten Fallback‑Bild erscheinen, während ein relativer Link wie `images/photo.png` im gespeicherten SVG unverändert bleibt. Eine Anwendung, die die native SVG‑Darstellung rendert, kann daher den verknüpften Inhalt weglassen, wenn die ursprüngliche externe Ressource nicht verfügbar ist.

{{% /alert %}}

### **Erstellen eines portablen SVG‑Bildes**

Um ein SVG‑Bild zu erstellen, das nicht von externen Dateien abhängt, machen Sie das SVG eigenständig, bevor Sie das `SvgImage` erzeugen. Ersetzen Sie beispielsweise verknüpfte Bild‑URLs durch `data:`‑URIs, die die Bilddaten enthalten:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Nachdem alle erforderlichen Ressourcen im SVG‑Inhalt eingebettet sind, erstellen Sie das `SvgImage`, fügen es der Bildsammlung der Präsentation hinzu und setzen es in einen Bildrahmen ein, wie im vorherigen Beispiel gezeigt.

### **Umgang mit fehlenden oder blockierten Ressourcen**

Geben Sie `null` von `resolveUri` zurück, wenn eine Ressourcen‑URI ungültig, verboten oder nicht auflösbar ist. Geben Sie `null` von `getEntity` zurück, wenn die Ressource nicht gelesen werden kann. Aspose.Slides verarbeitet das SVG nach Möglichkeit weiter ohne diese Ressource.

Ein Fallback‑Stream kann für eine fehlende Ressource zurückgegeben werden, aber sein Inhalt muss mit dem angeforderten Ressourcentyp kompatibel sein. Beispielsweise geben Sie einen Bild‑Stream nur für ein fehlendes Bild zurück, nicht für eine Schriftart oder ein Stylesheet.

{{% alert title="Security" color="warning" %}}

Lösen Sie keine beliebigen Dateipfade oder uneingeschränkten Netzwerk‑URLs aus nicht vertrauenswürdigen SVG‑Dateien auf. Beschränken Sie erlaubte Schemen, Verzeichnisse und Hosts. Für Netzwerkressourcen sollten außerdem Verbindungs‑Timeouts, Begrenzungen der Antwortgröße und Inhalt­validierungen angewendet werden.

{{% /alert %}}

## **SVG in eine Menge von Formen konvertieren**

Aspose.Slides kann ein SVG in eine Menge von Formen konvertieren, ähnlich der entsprechenden Funktionalität in PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

Diese Funktionalität wird durch eine Überladung der Methode [addGroupShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/shapecollection/addgroupshape/) der Klasse [ShapeCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/shapecollection/) bereitgestellt, die ein [SvgImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/svgimage/)‑Objekt als erstes Argument annimmt.

Der folgende PHP‑Beispielcode zeigt, wie diese Methode verwendet wird, um eine SVG‑Datei in eine Menge von Formen zu konvertieren:

```php
// Quell-SVG-Dateiname.
$svgFileName = "sample.svg";

// Ausgabe-Präsentationsdateiname.
$outPptxPath = "presentation.pptx";

// Neue Präsentation erstellen.
$presentation = new Presentation();
try {
    // Den SVG-Dateiinhalt lesen.
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", $svgFileName));
    try {
        $svgContent = $Array->newInstance($Byte, $dis->available());
        $dis->readFully($svgContent);
    } finally {
        if (!java_is_null($dis)) {
            $dis->close();
        }
    }

    // Ein SvgImage-Objekt erstellen.
    $svgImage = new SvgImage($svgContent);

    // Foliengröße abrufen.
    $slideSize = $presentation->getSlideSize()->getSize();

    // Das SVG-Bild in eine Gruppe von Formen konvertieren und auf die Foliengröße skalieren.
    $presentation->getSlides()->get_Item(0)->getShapes()->addGroupShape(
        $svgImage,
        0.0,
        0.0,
        $slideSize->getWidth(),
        $slideSize->getHeight()
    );

    // Die Präsentation im PPTX-Format speichern.
    $presentation->save($outPptxPath, SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $presentation->dispose();
}
```

## **Bilder als EMF zu Folien hinzufügen**

Aspose.Slides für PHP via Java ermöglicht das Erzeugen von EMF‑Bildern aus Excel‑Arbeitsblättern mit Aspose.Cells und deren Hinzufügen zu Präsentationsfolien.

Der folgende PHP‑Beispielcode zeigt, wie das geht:

```php
$book = new Workbook("chart.xlsx");
$sheet = $book->getWorksheets()->get(0);

$options = new ImageOrPrintOptions();
$options->setHorizontalResolution(200);
$options->setVerticalResolution(200);
$options->setImageType(ImageType::EMF);

// Das Arbeitsbuch in einen Stream speichern.
$sr = new SheetRender($sheet, $options);
$pres = new Presentation();
try {
    $pres->getSlides()->removeAt(0);

    for ($j = 0; $j < java_values($sr->getPageCount()); $j++) {
        $emfSheetName = "test" . $sheet->getName() . " Page" . ($j + 1) . ".out.emf";
        $sr->toImage($j, $emfSheetName);

        //        Die Datei unverändert hinzufügen, damit das Bild ein Vektor‑EMF bleibt und nicht gerastert wird.
        $picture = null;
        $imageStream = new Java("java.io.FileInputStream", $emfSheetName);
        try {
            $picture = $pres->getImages()->addImage($imageStream);
        } finally {
            $imageStream->close();
        }

        $slide = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->getByType(SlideLayoutType::Blank));
        $slide->getShapes()->addPictureFrame(
            ShapeType::Rectangle,
            0,
            0,
            $pres->getSlideSize()->getSize()->getWidth(),
            $pres->getSlideSize()->getSize()->getHeight(),
            $picture
        );
    }

    $pres->save("output.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $pres->dispose();
}
```

## **Bilder in der Bildsammlung ersetzen**

Aspose.Slides ermöglicht das Ersetzen von Bildern, die in der Bildsammlung einer Präsentation gespeichert sind, einschließlich der von Folienformen verwendeten Bilder. Dieser Abschnitt beschreibt mehrere Möglichkeiten, Bilder in der Sammlung zu aktualisieren. Sie können ein Bild mit rohen Byte‑Daten, einer [IImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/iimage/)‑Instanz oder einem anderen bereits in der Sammlung vorhandenen Bild ersetzen.

Führen Sie die folgenden Schritte aus:

1. Laden Sie die Präsentationsdatei, die Bilder enthält, mit der Klasse [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/) .
2. Laden Sie ein neues Bild aus einer Datei in ein Byte‑Array.
3. Ersetzen Sie das Zielbild mithilfe des Byte‑Arrays durch das neue Bild.
4. Im zweiten Ansatz laden Sie das Bild in ein [IImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/iimage/)‑Objekt und ersetzen das Zielbild durch dieses Objekt.
5. Im dritten Ansatz ersetzen Sie das Zielbild durch ein Bild, das bereits in der Bildsammlung der Präsentation vorhanden ist.
6. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

```php
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei repräsentiert.
$presentation = new Presentation("sample.pptx");
try {
    // Der erste Weg.
    $imagePath = (new Java("java.io.File", "image0.jpeg"))->toPath();
    $imageData = (new JavaClass("java.nio.file.Files"))->readAllBytes($imagePath);
    $oldImage = $presentation->getImages()->get_Item(0);
    $oldImage->replaceImage($imageData);

    // Der zweite Weg.
    $newImage = Images::fromFile("image1.png");
    try {
        $oldImage = $presentation->getImages()->get_Item(1);
        $oldImage->replaceImage($newImage);
    } finally {
        if (!java_is_null($newImage)) {
            $newImage->dispose();
        }
    }

    // Der dritte Weg.
    $oldImage = $presentation->getImages()->get_Item(2);
    $oldImage->replaceImage($presentation->getImages()->get_Item(3));

    // Speichern Sie die Präsentation in eine Datei.
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}

Mit Asposes kostenlosem [Text to GIF](https://products.aspose.app/slides/de/text-to-gif)‑Konverter können Sie Text einfach animieren und GIFs aus Text erstellen. 

{{% /alert %}}

## **FAQ**

**Bleibt die ursprüngliche Bildauflösung nach dem Einfügen erhalten?**

Ja. Die Quellpixel bleiben erhalten, aber das endgültige Erscheinungsbild hängt davon ab, wie das [picture](/slides/de/php-java/picture-frame/) auf der Folie skaliert wird und welche Kompression beim Speichern angewendet wird.

**Wie ersetzt man am besten dasselbe Logo gleichzeitig auf Dutzenden von Folien?**

Platzieren Sie das Logo auf dem Master‑Slide oder einem Layout und ersetzen Sie es in der Bildsammlung der Präsentation – die Änderungen werden an alle Elemente, die diese Ressource verwenden, übernommen.

**Kann ein eingefügtes SVG in editierbare Formen konvertiert werden?**

Ja. Sie können ein SVG in eine Gruppe von Formen konvertieren, danach werden einzelne Teile mit den üblichen Form‑Eigenschaften editierbar.

**Wie kann ich ein Bild gleichzeitig als Hintergrund für mehrere Folien festlegen?**

[Weisen Sie das Bild als Hintergrund](/slides/de/php-java/presentation-background/) dem Master‑Slide oder dem entsprechenden Layout zu – alle Folien, die diesen Master/Layout verwenden, erben den Hintergrund.

**Wie verhindere ich, dass eine Präsentation durch viele Bilder zu groß wird?**

Verwenden Sie dieselbe Bildressource mehrfach anstelle von Duplikaten, wählen Sie angemessene Auflösungen, wenden Sie beim Speichern Kompression an und behalten Sie wiederholte Grafiken nach Möglichkeit im Master.