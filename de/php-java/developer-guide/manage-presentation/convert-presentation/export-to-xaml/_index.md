---
title: Präsentationen nach XAML in PHP exportieren
linktitle: Präsentation nach XAML
type: docs
weight: 30
url: /de/php-java/export-to-xaml/
keywords:
- PowerPoint exportieren
- OpenDocument exportieren
- Präsentation exportieren
- PowerPoint konvertieren
- OpenDocument konvertieren
- Präsentation konvertieren
- PowerPoint nach XAML
- OpenDocument nach XAML
- Präsentation nach XAML
- PPT nach XAML
- PPTX nach XAML
- ODP nach XAML
- PPT als XAML speichern
- PPTX als XAML speichern
- ODP als XAML speichern
- PPT nach XAML exportieren
- PPTX nach XAML exportieren
- ODP nach XAML exportieren
- PHP
- Aspose.Slides
description: "Konvertieren Sie PowerPoint- und OpenDocument-Folien nach XAML mit Aspose.Slides für PHP über Java - schnelle, Office-freie Lösung, die Ihr Layout unverändert lässt."
---
## **Übersicht**

Dieser Artikel erklärt, wie PowerPoint‑Präsentationen mit Aspose.Slides nach XAML exportiert werden. Er enthält eine kurze Einführung in XAML, zeigt, wie eine Präsentation mit den Standardeinstellungen nach XAML gespeichert wird, und demonstriert, wie der Export über [XamlOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/xamloptions/) angepasst werden kann, einschließlich des Exports versteckter Folien. Der Artikel beantwortet außerdem einige häufige Fragen zu Ersatzschriftarten, zur Kompatibilität von XAML‑Stacks und zum Verhalten beim Export versteckter Folien.

## **Über XAML**

XAML ist eine XML‑basierte Auszeichnungssprache, die zur Beschreibung von Benutzeroberflächen in Frameworks wie WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) und Xamarin.Forms verwendet wird.

Sie können mit XAML‑Dateien in einem visuellen Designer arbeiten oder die Markup‑Sprache direkt schreiben und bearbeiten.

## **Präsentationen mit Standardeinstellungen nach XAML exportieren**

Das folgende PHP‑Beispiel zeigt, wie eine Präsentation mit den Standardeinstellungen nach XAML exportiert wird. Initialisieren Sie die PHP‑Java‑Bridge und laden Sie `aspose.slides.php`, bevor Sie die Beispiele in diesem Artikel ausführen. Platzieren Sie `pres.pptx` im Arbeitsverzeichnis des Java‑Bridge‑Servers oder geben Sie einen absoluten Pfad an, der für diesen Server erreichbar ist.

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $presentation->save($options);
} finally {
    $presentation->dispose();
}
```

Standardmäßig werden die exportierten Folien in einem Unterordner `pres` des aktuellen Arbeitsverzeichnisses des Java‑Bridge‑Servers gespeichert. Der Ordner wird automatisch erstellt und alle erforderlichen Bilder werden dort ebenfalls abgelegt.

Der Name des Ausgabeverzeichnisses wird aus dem Quelldateinamen ohne Erweiterung genommen. Für `pres.pptx` heißen die Ausgabedateien `pres/Slide_1.xaml`, `pres/Slide_2.xaml` usw. Selbst wenn Sie einen absoluten Pfad zur Eingabepräsentation übergeben, wird das Ausgabeverzeichnis relativ zum aktuellen Arbeitsverzeichnis des Java‑Bridge‑Servers erstellt, nicht neben der Eingabedatei.

## **Präsentationen mit benutzerdefinierten Optionen nach XAML exportieren**

Verwenden Sie das Interface [IXamlOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/ixamloptions/), um zu steuern, wie Aspose.Slides eine Präsentation nach XAML exportiert.

Um die Ausgabe an einem benutzerdefinierten Ort zu speichern, stellen Sie einen Java‑Proxy bereit, der [IXamlOutputSaver](https://reference.aspose.com/slides/de/java/com.aspose.slides/ixamloutputsaver/) implementiert, und übergeben Sie eine Instanz Ihrer Implementierung an die Methode [setOutputSaver](https://reference.aspose.com/slides/de/php-java/aspose.slides/xamloptions/#setOutputSaver) von [XamlOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/xamloptions/).

Um versteckte Folien in die XAML‑Ausgabe einzubeziehen, rufen Sie [setExportHiddenSlides](https://reference.aspose.com/slides/de/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) mit `true` auf, wie im folgenden PHP‑Beispiel gezeigt:

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setExportHiddenSlides(true);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}
```

## **Alle generierten XAML‑Artefakte erfassen**

Ein XAML‑Export kann ein XAML‑Dokument für jede exportierte Folie sowie separate Bilder und unterstützende Ressourcen erzeugen. Ordnen Sie einem benutzerdefinierten [IXamlOutputSaver](https://reference.aspose.com/slides/de/java/com.aspose.slides/ixamloutputsaver/) die Methode [XamlOptions::setOutputSaver](https://reference.aspose.com/slides/de/php-java/aspose.slides/xamloptions/#setOutputSaver) zu, um diese Artefakte zu erhalten, anstatt den standardmäßigen Dateisystem‑Saver zu verwenden. Starten Sie den Export mit der XAML‑spezifischen Überladung von [Presentation::save](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#save), die XAML‑Optionen akzeptiert.

Die PHP‑Java‑Bridge‑Funktion `java_closure` stellt ein PHP‑Objekt als Java‑Interface bereit. Halten Sie sowohl den PHP‑Saver als auch dessen Proxy am Leben, bis der Export abgeschlossen ist. Die Interface‑Links verweisen auf die von dem Proxy implementierte Java‑API.

### **Lebenszyklus des Callbacks verstehen**

Der Exporter ruft [IXamlOutputSaver::save](https://reference.aspose.com/slides/de/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) getrennt für jedes erzeugte Artefakt auf:

- `path` identifiziert das Artefakt und kann relative Verzeichnisse enthalten. Bewahren Sie diese Information auf, da XAML Ressourcen über relative Pfade referenzieren kann.
- `data` enthält die Bytes des Artefakts. Bilder und andere Binärressourcen dürfen nicht als Text dekodiert werden.
- Der Saver ist dafür verantwortlich, die Daten zu behalten oder zu persistieren, bevor er zurückkehrt. Die Beispiele konvertieren jedes Java‑Byte‑Array in einen PHP‑Binärstring, der der Anwendung gehört.
- Behandeln Sie den Export nur als erfolgreich, wenn der Speicher‑Vorgang der Präsentation zurückkehrt und jeder Callback erfolgreich abgeschlossen ist. Unterdrücken Sie keine Speicherfehler und starten Sie keine unbeobachteten Hintergrundschreibvorgänge. Erfolgt die Persistierung danach, melden Sie den Gesamterfolg erst, wenn dieser Schritt ebenfalls erfolgreich war.

[XamlOptions::setExportHiddenSlides](https://reference.aspose.com/slides/de/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) gilt ebenfalls für einen benutzerdefinierten Saver. Die Standardeinstellung `false` schließt XAML‑Dokumente versteckter Folien aus. Wird `true` übergeben, werden sie sowie alle für den Export benötigten Ressourcen einbezogen. Die Anzahl der Ressourcen hängt von der Präsentation ab; gehen Sie nicht davon aus, dass für jede Folie genau ein Callback erfolgt oder dass die Callback‑Reihenfolge fest ist.

### **Export in den Speicher und Artefakte inspizieren**

Dieses vollständige Beispiel lädt `pres.pptx`, sammelt jedes Artefakt in einem assoziativen PHP‑Array von Binärstrings und gibt dessen Namen, Typ und Byte‑Anzahl aus. Es bewahrt die gelieferten Namen exakt. Doppelte Namen markieren die Sammlung als ungültig, anstatt ein Artefakt stillschweigend zu überschreiben. Das Beispiel prüft dies, bevor die Ergebnisse verwendet werden.

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

class MemoryXamlSaver {
    public $artifacts = [];
    public $valid = true;

    public function save($path, $data) {
        $name = (string) java_values($path);
        if (array_key_exists($name, $this->artifacts)) {
            $this->valid = false;
            echo "Export rejected: duplicate artifact name: " . $name . PHP_EOL;
            return;
        }
        $bytes = java_values($data);
        if (is_string($bytes)) {
            $binary = $bytes;
        } else {
            $binary = "";
            foreach ($bytes as $byte) {
                $binary .= chr($byte & 0xff);
            }
        }
        $this->artifacts[$name] = $binary;
    }
}

$saver = new MemoryXamlSaver();
$proxy = java_closure($saver, null, java("com.aspose.slides.IXamlOutputSaver"));
$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setOutputSaver($proxy);
    $options->setExportHiddenSlides(true);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}

if (!$saver->valid) {
    echo "Export rejected: the artifact collection is invalid." . PHP_EOL;
    return;
}

$inspectXamlText = false;
foreach ($saver->artifacts as $name => $bytes) {
    $extension = strtolower(pathinfo($name, PATHINFO_EXTENSION));
    $isXaml = $extension === "xaml";
    $isImage = in_array($extension, ["png", "jpg", "jpeg", "gif", "bmp", "tif", "tiff", "svg"], true);
    $kind = $isXaml ? "slide XAML" : ($isImage ? "image" : "supporting resource");
    echo $name . ": " . strlen($bytes) . " bytes (" . $kind . ")" . PHP_EOL;

    // Nur XAML wird als UTF-8-Text für optionale Inspektion behandelt.
    if ($isXaml && $inspectXamlText) {
        echo $bytes . PHP_EOL;
    }
}
```

Erweiterungs‑Checks sind für die Inspektion nützlich; behalten Sie alle Artefakte, einschließlich unbekannter Ressourcentypen. Lassen Sie die Bytes beim Speichern oder Übertragen unverändert. PHP‑Strings können Binärdaten, einschließlich Null‑Bytes, behalten. Betrachten Sie einen String nur dann als UTF‑8‑Text, wenn Sie XAML inspizieren; transkodieren Sie Bild‑ oder Ressourcebytes nicht.

### **Gesammelte Artefakte in ein ZIP‑Archiv verpacken**

Dieses eigenständige Beispiel sammelt den Export, validiert die Namen und schreibt die ursprünglichen Bytes in ein ZIP‑Archiv. Ein ausschließlich erstelltes Job‑Verzeichnis trennt gleichzeitige Export‑Jobs. Das Beispiel erfordert die PHP‑Phar‑Erweiterung mit ZIP‑Unterstützung. ZIP‑Einträge verwenden Vorwärtsschrägstriche und behalten relative Verzeichnisse bei. Unsichere Namen oder Namen, die nach Normalisierung kollidieren, führen dazu, dass das gesamte Paket vor dem Schreiben abgelehnt wird.

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

class MemoryXamlSaver {
    public $artifacts = [];
    public $valid = true;

    public function save($path, $data) {
        $name = (string) java_values($path);
        if (array_key_exists($name, $this->artifacts)) {
            $this->valid = false;
            echo "Export rejected: duplicate artifact name: " . $name . PHP_EOL;
            return;
        }
        $bytes = java_values($data);
        if (is_string($bytes)) {
            $binary = $bytes;
        } else {
            $binary = "";
            foreach ($bytes as $byte) {
                $binary .= chr($byte & 0xff);
            }
        }
        $this->artifacts[$name] = $binary;
    }
}

$saver = new MemoryXamlSaver();
$proxy = java_closure($saver, null, java("com.aspose.slides.IXamlOutputSaver"));
$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setOutputSaver($proxy);
    $options->setExportHiddenSlides(false);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}

if (!$saver->valid) {
    echo "Export rejected: the artifact collection is invalid." . PHP_EOL;
    return;
}

$entries = [];
$entryNames = [];
foreach ($saver->artifacts as $name => $bytes) {
    $entryName = str_replace("\\", "/", $name);
    $unsafeName = substr($entryName, 0, 1) === "/" || strpos($entryName, ":") !== false;
    foreach (explode("/", $entryName) as $segment) {
        $unsafeName = $unsafeName || trim($segment) === "" || $segment === "." || $segment === "..";
    }
    $key = strtolower($entryName);
    if ($unsafeName || isset($entryNames[$key])) {
        echo "Export rejected: unsafe or duplicate artifact name: " . $name . PHP_EOL;
        return;
    }
    $entryNames[$key] = true;
    $entries[$entryName] = $bytes;
}

$jobDirectory = "xaml-" . bin2hex(random_bytes(16));
if (!mkdir($jobDirectory, 0700)) {
    echo "Cannot create the export directory." . PHP_EOL;
    return;
}
$archivePath = $jobDirectory . "/export.zip";
try {
    $archive = new PharData($archivePath, 0, null, Phar::ZIP);
    foreach ($entries as $name => $bytes) {
        $archive->addFromString($name, $bytes);
    }
    unset($archive);
    echo "Saved " . count($entries) . " artifacts to " . $archivePath . PHP_EOL;
} catch (Throwable $exception) {
    unset($archive);
    echo "Archive persistence failed: " . $exception->getMessage() . PHP_EOL;
}
```

Das Beispiel nutzt [PharData](https://www.php.net/manual/en/class.phardata.php), um ein lokales ZIP‑Archiv im Arbeitsverzeichnis des PHP‑Prozesses zu schreiben; der Exporter selbst schreibt keine losen XAML‑ oder Bilddateien. Für die Remote‑Speicherung ersetzen Sie die Archiv‑Schreibphase durch Uploads der gesammelten Binärstrings. Verwenden Sie einen Export‑Job‑Bezeichner plus den vollständigen relativen Artefaktnamen als Blob‑Schlüssel oder speichern Sie den Job‑Bezeichner, den relativen Namen und die Binärdaten in einer Datenbankzeile. Veröffentlichen Sie den Job erst, nachdem alle Uploads abgeschlossen oder die Datenbank‑Transaktion committet ist. Bereinigen Sie Teil‑Ausgaben, falls die Persistierung fehlschlägt.

Für große Präsentationen kann ein benutzerdefinierter Saver jedes Artefakt direkt im Anwendungsspeicher persistieren, um zu vermeiden, dass eine zusätzliche Kopie des gesamten Exports im Arbeitsspeicher gehalten wird. Halten Sie jeden Callback aus Sicht des Exporters synchron: Rückgabe erst, nachdem das Ziel die Bytes akzeptiert hat, und lassen Sie Fehler zum Aufrufer durchdringen.

### **Ressourcennamen bewahren und Referenzen verifizieren**

- Normalisieren Sie Pfadtrenner, wenn das Ziel dies erfordert, bewahren Sie jedoch relative Verzeichnisse. Verwenden Sie nicht ausschließlich [basename](https://www.php.net/manual/en/function.basename.php), es sei denn, jeder erzeugte Name ist eindeutig und Ressourcereferenzen bleiben gültig.
- Wenden Sie ziel‑spezifische Namensvalidierung an. Beim Schreiben loser Dateien lehnen Sie verankerte Pfade und Traversal‑Segmente ab, lösen das Ziel zu einem absoluten Pfad auf und prüfen, dass es innerhalb des beabsichtigten Export‑Verzeichnisses bleibt, einschließlich des Verzeichnis‑Trennzeichens in der Containment‑Prüfung. Nutzen Sie ein von der Anwendung kontrolliertes Verzeichnis ohne symbolische Links, die Schreibvorgänge umleiten könnten.
- Verwenden Sie für jeden Export‑Job einen separaten Saver und Namensraum für den Speicher. Erkennen Sie Kollisionen nach Normalisierung der Trenner und gemäß den Groß‑/Kleinschreibungsregeln des Ziels.
- Vor der Veröffentlichung parsen Sie jedes XAML‑Dokument als XML und prüfen dessen dateibasierte Ressourcen‑Referenzen, etwa Bild‑`Source`‑ oder `ImageSource`‑Attribute. Lösen Sie jede relative URI relativ zum Verzeichnis des enthaltenden XAML‑Artefakts auf, normalisieren Sie den resultierenden Speicher‑Namen und bestätigen Sie, dass der entsprechende Mapping‑Schlüssel, ZIP‑Eintrag oder gespeicherte Objekt vorhanden ist. Behandeln Sie externe URIs und XAML‑Markup‑Ausdrücke gesondert von relativen Dateinamen.

Beispiel: Verweist `pres/Slide_1.xaml` auf `images/image1.png`, muss die gespeicherte Ressource als `pres/images/image1.png` verfügbar sein. Nur `image1.png` zu behalten würde die Beziehung brechen. Für Objektspeicher bewahren Sie dieselbe Ordnerstruktur unter dem Job‑Präfix und machen diese Ressource‑URLs für den XAML‑Verbraucher zugänglich. Öffnen Sie das fertige ZIP erneut, um Eintragsnamen und Ressourcebytes zu überprüfen, und laden Sie repräsentative Folien in der Ziel‑XAML‑Umgebung, um sicherzustellen, dass Bilder korrekt aufgelöst werden.

## **FAQ**

**Wie kann ich vorhersehbare Schriftarten sicherstellen, wenn die Originalschriftart nicht auf dem Rechner verfügbar ist?**

Rufen Sie [setDefaultRegularFont](https://reference.aspose.com/slides/de/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) in [XamlOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/xamloptions/) auf — sie wird als Ersatzschriftart während des Exports verwendet, wenn die Originalschriftart fehlt. Dies garantiert nicht, dass das erzeugte XAML die Ersatzschriftart referenziert oder dass die Schriftart auf dem Zielrechner verfügbar ist. Stellen Sie sicher, dass die vom XAML referenzierten Schriftarten in der Umgebung, in der es angezeigt wird, vorhanden sind.

**Ist das exportierte XAML ausschließlich für WPF gedacht oder kann es auch in anderen XAML‑Stacks verwendet werden?**

Aspose.Slides exportiert WPF‑XAML über seine öffentliche API. Die Kompatibilität mit anderen XAML‑Stacks wie UWP und Xamarin.Forms ist nicht garantiert. Testen Sie das erzeugte Markup in Ihrer Zielumgebung.

**Werden versteckte Folien unterstützt und wie kann ich verhindern, dass sie standardmäßig exportiert werden?**

Standardmäßig werden versteckte Folien nicht einbezogen. Sie können dieses Verhalten über [setExportHiddenSlides](https://reference.aspose.com/slides/de/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) in [XamlOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/xamloptions/) steuern — lassen Sie es deaktiviert, wenn Sie sie nicht exportieren möchten.