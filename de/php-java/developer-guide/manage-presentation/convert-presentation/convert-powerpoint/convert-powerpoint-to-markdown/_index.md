---
title: PowerPoint-Präsentationen in Markdown konvertieren in PHP
linktitle: PowerPoint zu Markdown
type: docs
weight: 140
url: /de/php-java/convert-powerpoint-to-markdown/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPT konvertieren
- PPTX konvertieren
- PowerPoint zu MD
- Präsentation zu MD
- Folie zu MD
- PPT zu MD
- PPTX zu MD
- PowerPoint als Markdown speichern
- Präsentation als Markdown speichern
- Folie als Markdown speichern
- PPT als MD speichern
- PPTX als MD speichern
- PPT nach MD exportieren
- PPTX nach MD exportieren
- Markdown-Bildexport
- CDN-Bildlinks
- PowerPoint
- Präsentation
- Markdown
- PHP
- Aspose.Slides
description: "PPT- und PPTX-Präsentationen in Markdown in PHP konvertieren und steuern, wo exportierte Bitmap-, Metafile- und SVG-Bilder gespeichert und referenziert werden."
---
## **Übersicht**

Aspose.Slides für PHP via Java kann PPT- und PPTX-Präsentationen in Markdown für Dokumentation, statische Websites, Content‑Migration und Versionskontroll‑Workflows konvertieren. Sie können einen Markdown‑Flavor auswählen, steuern, wie Folieninhalt gerendert wird, und entscheiden, wo exportierte Bilder gespeichert werden und wie das erzeugte Markdown auf sie verweist.

Standardmäßig verwendet der Markdown‑Export nur Textausgabe. Um visuelle Inhalte zu exportieren, setzen Sie den Exporttyp mit der [MarkdownSaveOptions::setExportType](https://reference.aspose.com/slides/de/php-java/aspose.slides/markdownsaveoptions/)‑Methode auf den Wert `Sequential` oder `Visual` aus der Aufzählung [MarkdownExportType](https://reference.aspose.com/slides/de/php-java/aspose.slides/markdownexporttype/). `Sequential` rendert Folienelemente einzeln und in Reihenfolge, während `Visual` gruppierte Elemente zusammenbehält, um deren visuelle Beziehung zu bewahren. Der Wert `TextOnly` erzeugt keine Bildressourcen, sodass die Bild‑Speicher‑Callbacks in diesem Modus nicht aufgerufen werden.

## **Präsentation in Markdown konvertieren**

Laden Sie die Quelldatei mit der Klasse [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/) und rufen Sie anschließend die Methode [Presentation::save](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/) mit dem Wert `Md` aus der Aufzählung [SaveFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/saveformat/) auf.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.md";
$presentation = new Presentation($inputPath);
try {
    $presentation->save($outputPath, SaveFormat::Md);
} finally {
    $presentation->dispose();
}
```

## **Markdown‑Flavor auswählen**

Die Methode [MarkdownSaveOptions::setFlavor](https://reference.aspose.com/slides/de/php-java/aspose.slides/markdownsaveoptions/) steuert die für die Ausgabe verwendete Markdown‑Spezifikation. Die Aufzählung [Flavor](https://reference.aspose.com/slides/de/php-java/aspose.slides/flavor/) enthält CommonMark, GitHub Flavored Markdown und weitere unterstützte Varianten.

Das folgende Beispiel exportiert eine Präsentation als CommonMark:

```php
use aspose\slides\Flavor;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.md";
$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setFlavor(Flavor::CommonMark);

    $presentation->save($outputPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

## **Bilder mit dem standardmäßigen lokalen Speicherverhalten exportieren**

Die Klasse [MarkdownSaveOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/markdownsaveoptions/) stellt zwei Methoden zur Konfiguration lokal gespeicherter Bilder bereit:

- [setBasePath](https://reference.aspose.com/slides/de/php-java/aspose.slides/markdownsaveoptions/) legt das Basisverzeichnis für das Markdown‑Dokument und seine Ressourcen fest.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/de/php-java/aspose.slides/markdownsaveoptions/) legt das Bildunterverzeichnis fest. Der Standardwert ist `Images`.

Das folgende Beispiel rendert visuelle Inhalte, schreibt Bilder nach `output/assets` und erzeugt relative Bildreferenzen im Markdown‑Dokument:

```php
use aspose\slides\MarkdownExportType;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "output";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setExportType(MarkdownExportType::Visual);
    $options->setBasePath($outputDirectory);
    $options->setImagesSaveFolderName("assets");

    $markdownPath = $outputDirectory . DIRECTORY_SEPARATOR . "presentation.md";
    $presentation->save($markdownPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

Dieses Verhalten dient auch als Rückfall, wenn ein benutzerdefinierter Bild‑Speicher‑Handler `false` zurückgibt.

## **Bildspeicherung und Markdown‑Links anpassen**

Verwenden Sie die Methode [MarkdownSaveOptions::setImageSaving](https://reference.aspose.com/slides/de/php-java/aspose.slides/markdownsaveoptions/) , um einen Callback für nicht‑SVG‑Bitmap‑ und Metafile‑Ressourcen zu registrieren, die beim Markdown‑Export erzeugt werden. Sein Callback `MarkdownImageSavingHandler` erhält das [IImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/iimage/)‑Objekt, dessen [ImageFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/imageformat/)‑Wert und den erzeugten Markdown‑Link als ein‑elementiges Java‑String‑Array. Speichern oder laden Sie das Bild im angegebenen Format hoch und ersetzen Sie `$link[0]` durch die Referenz, die im Markdown‑Ausgabe erscheinen muss.

Ressourcen, die im SVG‑Format erzeugt werden, werden separat behandelt. Registrieren Sie einen Callback mit der [MarkdownSaveOptions::setSvgImageSaving](https://reference.aspose.com/slides/de/php-java/aspose.slides/markdownsaveoptions/)‑Methode. Sein Callback `MarkdownSvgImageSavingHandler` erhält ein [ISvgImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/isvgimage/)‑Objekt und das ein‑elementige Java‑String‑Array `$link`. Ein SVG verfügt über kein `ImageFormat`‑Argument; schreiben oder laden Sie stattdessen dessen XML‑Daten über die Methode [ISvgImage::getSvgData](https://reference.aspose.com/slides/de/php-java/aspose.slides/isvgimage/) hoch. Je nach Exportmodus und visueller Gruppierung kann ein SVG in der Quellpräsentation gerastert oder mit anderem Inhalt kombiniert werden; die resultierende Nicht‑SVG‑Ressource wird dann an den Bild‑Speicher‑Callback übergeben. Registrieren Sie beide Callbacks, wenn jede exportierte visuelle Ressource eine benutzerdefinierte Verarbeitung erfordert.

In PHP via Java implementieren Sie jeden Callback in einer PHP‑Klasse und verwenden `java_closure`, um dieses Objekt als das entsprechende Java‑Interface sichtbar zu machen.

{{% alert color="info" title="Note" %}}
Initialisieren Sie die PHP/Java‑Bridge mit aktiviertem `JAVA_PREFER_VALUES`, bevor Sie `Java.inc` laden. Die Methode [Presentation::save](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/) gibt `void` zurück, und der Standard‑Stream‑Modus der Bridge kann während dieses aufgerufenen Aufrufs keinen PHP‑Callback ausführen. Das vollständige Beispiel unten enthält die erforderliche Initialisierung.
{{% /alert %}}

Der Rückgabewert des Handlers bestimmt, wer das Bild verarbeitet:

- Rückgabe von `true` nach dem Speichern, Hochladen, Transformieren oder anderweitigen Verarbeiten des Bildes und nachdem `$link[0]` ein gültiger Wert zugewiesen wurde. Aspose.Slides schreibt diesen Wert in das Markdown‑Dokument und führt nicht das standardmäßige lokale Speichern aus.
- Rückgabe von `false`, damit Aspose.Slides das Bild lokal speichert und den Link gemäß den mit [MarkdownSaveOptions::setBasePath](https://reference.aspose.com/slides/de/php-java/aspose.slides/markdownsaveoptions/) und [MarkdownSaveOptions::setImagesSaveFolderName](https://reference.aspose.com/slides/de/php-java/aspose.slides/markdownsaveoptions/) gesetzten Werten erzeugt.

{{% alert color="warning" title="Important" %}}
Ein Handler, der `true` zurückgibt, übernimmt die Verantwortung für das Bild. Gibt er `true` zurück, ohne einen gültigen, nicht leeren Link zuzuweisen, schlägt der Export mit einer `InvalidOperationException` fehl.
{{% /alert %}}

### **Bilder in ein CDN‑Ursprungsverzeichnis speichern und externe URLs verwenden**

Das folgende Beispiel behandelt `cdn-origin/presentations/quarterly-report` als ein gemountetes oder synchronisiertes CDN‑Ursprungsverzeichnis. Jeder Handler extrahiert den erzeugten Dateinamen, speichert das Bild in diesem benutzerdefinierten Verzeichnis und ersetzt die erzeugte lokale Referenz durch eine öffentliche CDN‑URL. Das Beispiel selbst führt keinen Netzwerk‑Upload durch: Die URL wird erst gültig, wenn das Verzeichnis als CDN‑Ursprung gemountet oder seine Dateien im CDN veröffentlicht sind. Für Object‑Storage ersetzen Sie den Dateisystem‑Write‑Vorgang durch den Upload‑Aufruf des Storage‑SDKs und setzen `$link[0]` erst nach erfolgreichem Upload.

```php
use aspose\slides\MarkdownExportType;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

define("JAVA_PREFER_VALUES", 1);
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

function getFileNameFromLink($generatedLink)
{
    $urlCompatibleLink = str_replace("\\", "/", java_values($generatedLink));
    return basename($urlCompatibleLink);
}

function buildPublicUrl($publicBaseUrl, $fileName)
{
    return rtrim($publicBaseUrl, "/") . "/" . rawurlencode($fileName);
}

class CustomImageSavingHandler
{
    private $storageDirectory;
    private $publicBaseUrl;

    function __construct($storageDirectory, $publicBaseUrl)
    {
        $this->storageDirectory = $storageDirectory;
        $this->publicBaseUrl = $publicBaseUrl;
    }

    function invoke($image, $format, $link)
    {
        if (java_values($image->getWidth()) < 128 || java_values($image->getHeight()) < 128) {
            return false;
        }

        $fileName = getFileNameFromLink($link[0]);
        $storagePath = $this->storageDirectory . DIRECTORY_SEPARATOR . $fileName;
        $image->save($storagePath, $format);
        $link[0] = buildPublicUrl($this->publicBaseUrl, $fileName);
        return true;
    }
}

class CustomSvgImageSavingHandler
{
    private $storageDirectory;
    private $publicBaseUrl;

    function __construct($storageDirectory, $publicBaseUrl)
    {
        $this->storageDirectory = $storageDirectory;
        $this->publicBaseUrl = $publicBaseUrl;
    }

    function invoke($svgImage, $link)
    {
        $fileName = getFileNameFromLink($link[0]);
        $storagePath = $this->storageDirectory . DIRECTORY_SEPARATOR . $fileName;
        $outputStream = null;
        try {
            $outputStream = new Java("java.io.FileOutputStream", $storagePath);
            $outputStream->write($svgImage->getSvgData());
        } catch (Throwable $exception) {
            fwrite(STDERR, "Could not save the SVG image: " . $exception->getMessage() . PHP_EOL);
            return false;
        } finally {
            if ($outputStream !== null) {
                $outputStream->close();
            }
        }

        $link[0] = buildPublicUrl($this->publicBaseUrl, $fileName);
        return true;
    }
}

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "output";
$publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
$storageDirectory = __DIR__ . DIRECTORY_SEPARATOR . "cdn-origin" . DIRECTORY_SEPARATOR . "presentations" . DIRECTORY_SEPARATOR . "quarterly-report";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}
if (!is_dir($storageDirectory)) {
    mkdir($storageDirectory, 0777, true);
}

$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setExportType(MarkdownExportType::Visual);
    $options->setBasePath($outputDirectory);
    $options->setImagesSaveFolderName("fallback-images");

    $imageSavingHandler = java_closure(new CustomImageSavingHandler($storageDirectory, $publicBaseUrl), null, java('com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler'));
    $svgImageSavingHandler = java_closure(new CustomSvgImageSavingHandler($storageDirectory, $publicBaseUrl), null, java('com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler'));
    $options->setImageSaving($imageSavingHandler);
    $options->setSvgImageSaving($svgImageSavingHandler);

    $markdownPath = $outputDirectory . DIRECTORY_SEPARATOR . "presentation.md";
    $presentation->save($markdownPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

Der Bitmap‑Handler gibt bewusst `false` für Bilder kleiner als 128 × 128 Pixel zurück, sodass Aspose.Slides diese Bilder nach `output/fallback-images` speichert und das Standardverhalten nutzt. Größere Bitmap‑ und Metafile‑Ressourcen sowie SVG‑Ressourcen werden vom benutzerdefinierten Code verarbeitet. Beispiel: Eine erzeugte lokale Referenz wie `fallback-images/image1.png` wird zu `https://cdn.example.com/presentations/quarterly-report/image1.png`. Die Handler verwenden Betriebssystem‑Pfade nur beim Schreiben von Dateien; in Markdown geschriebene Links nutzen Vorwärtsschläge und URL‑kodierte Dateinamen. Verwenden Sie dieselbe Regel beim Erstellen relativer Links: `/` statt des plattformspezifischen Verzeichnis‑Separators.

## **FAQ**

**Kann ein Handler sowohl Rasterbilder als auch SVG‑Bilder verarbeiten?**

Nein. Verwenden Sie [MarkdownSaveOptions::setImageSaving](https://reference.aspose.com/slides/de/php-java/aspose.slides/markdownsaveoptions/) für erzeugte Bitmap‑ und Metafile‑Ressourcen und [MarkdownSaveOptions::setSvgImageSaving](https://reference.aspose.com/slides/de/php-java/aspose.slides/markdownsaveoptions/) für als SVG erzeugte Ressourcen. Der erstere liefert ein [IImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/iimage/)‑Objekt und einen [ImageFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/imageformat/)‑Wert; der letztere liefert ein [ISvgImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/isvgimage/)‑Objekt, dessen SVG‑Daten mit [ISvgImage::getSvgData](https://reference.aspose.com/slides/de/php-java/aspose.slides/isvgimage/) gelesen werden können. Ein Quell‑SVG, das während des Exports gerastert wird, wird stattdessen vom Bild‑Speicher‑Callback verarbeitet.

**Was passiert, wenn ein Bild‑Speicher‑Handler `false` zurückgibt?**

Aspose.Slides verwendet sein standardmäßiges lokales Speicherverhalten. Ort und erzeugte Referenz des Bildes werden durch die mit [MarkdownSaveOptions::setBasePath](https://reference.aspose.com/slides/de/php-java/aspose.slides/markdownsaveoptions/) und [MarkdownSaveOptions::setImagesSaveFolderName](https://reference.aspose.com/slides/de/php-java/aspose.slides/markdownsaveoptions/) gesetzten Werte gesteuert.

**Kann ein Handler eine URL bereitstellen, ohne das Bild lokal zu speichern?**

Ja. Der Handler kann das Bild in einen Object‑Storage hochladen oder an einen anderen Dienst übergeben, die resultierende URL in `$link[0]` setzen und `true` zurückgeben. Der Handler muss die Verarbeitung selbst abschließen; die Rückgabe von `true` verhindert das standardmäßige lokale Speichern.

**Warum wirft der Markdown‑Export eine `InvalidOperationException` von einem Handler?**

Diese Ausnahme tritt auf, wenn der Handler `true` zurückgibt, aber keinen gültigen Link bereitstellt. Setzen Sie den relativen Pfad oder die externe URL, die in Markdown geschrieben werden soll, bevor Sie `true` zurückgeben.

**Welches Pfadtrennzeichen sollten Bildlinks verwenden?**

Verwenden Sie Vorwärtsschläge (`/`) in Markdown‑Links und URLs. `DIRECTORY_SEPARATOR` nur für Dateisystem‑Pfade, dann erzeugen oder normalisieren Sie die Markdown‑Referenz separat.

**Werden Hyperlinks beim Markdown‑Export erhalten?**

Ja. Text [hyperlinks](/slides/de/php-java/manage-hyperlinks/) werden als Standard‑Markdown‑Links erhalten. Folien‑[transitions](/slides/de/php-java/slide-transition/) und [animations](/slides/de/php-java/powerpoint-animation/) werden nicht konvertiert.

**Können Präsentationen parallel in Markdown konvertiert werden?**

Sie können verschiedene Präsentationsdateien parallel verarbeiten, sollten jedoch dieselbe [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/)‑Instanz nicht zwischen Threads teilen. Befolgen Sie die [multithreading guidelines](/slides/de/php-java/multithreading/) und verwenden Sie für jede Datei eine separate Instanz.