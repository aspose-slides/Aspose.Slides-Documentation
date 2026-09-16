---
title: Präsentationen nach XAML in JavaScript exportieren
linktitle: Präsentation zu XAML
type: docs
weight: 30
url: /de/nodejs-java/export-to-xaml/
keywords:
- PowerPoint exportieren
- OpenDocument exportieren
- Präsentation exportieren
- PowerPoint konvertieren
- OpenDocument konvertieren
- Präsentation konvertieren
- PowerPoint zu XAML
- OpenDocument zu XAML
- Präsentation zu XAML
- PPT zu XAML
- PPTX zu XAML
- ODP zu XAML
- PPT als XAML speichern
- PPTX als XAML speichern
- ODP als XAML speichern
- PPT nach XAML exportieren
- PPTX nach XAML exportieren
- ODP nach XAML exportieren
- Node.js
- JavaScript
- Aspose.Slides
description: "Konvertieren Sie PowerPoint- und OpenDocument-Folien zu XAML in JavaScript mit Aspose.Slides - eine schnelle, Office-freie Lösung, die Ihr Layout unverändert lässt."
---
## **Übersicht**

Dieser Artikel erklärt, wie PowerPoint‑Präsentationen mit Aspose.Slides nach XAML exportiert werden. Er enthält eine kurze Einführung in XAML, zeigt, wie eine Präsentation mit den Standardeinstellungen nach XAML gespeichert wird, und demonstriert, wie der Export über [XamlOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/xamloptions/) angepasst werden kann, einschließlich des Exports versteckter Folien. Der Artikel beantwortet außerdem einige häufige Fragen zu Ersatz‑Schriftarten, Kompatibilität des XAML‑Stacks und dem Verhalten beim Export versteckter Folien.

## **Über XAML**

XAML ist eine XML‑basierte Auszeichnungssprache, die zur Beschreibung von Benutzeroberflächen in Frameworks wie WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) und Xamarin.Forms verwendet wird.

Sie können mit XAML‑Dateien in einem visuellen Designer arbeiten oder das Markup direkt schreiben und bearbeiten.

## **Präsentationen mit Standardoptionen nach XAML exportieren**

Das folgende JavaScript‑Beispiel zeigt, wie eine Präsentation mit den Standardeinstellungen nach XAML exportiert wird:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xamlOptions = new aspose.slides.XamlOptions();
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

Standardmäßig werden die exportierten Folien in einem Unterordner `input` des aktuellen Arbeitsverzeichnisses des Prozesses gespeichert. Der Ordner wird automatisch erstellt, und alle erforderlichen Bilder werden dort ebenfalls abgelegt.

Der Name des Ausgabeverzeichnisses wird aus dem Namen der Quelldatei ohne deren Erweiterung genommen. In Aspose.Slides für Node.js via Java 26.8 erzeugt das Exportieren von `input.pptx` einen verschachtelten Pfad wie `input/input/Slide_1.xaml`. Bewahren Sie die vollständig generierten Pfade beim Umgang mit der Ausgabe auf. Die Standardausgabe ist relativ zum aktuellen Arbeitsverzeichnis und nicht zwingend neben der Eingabedatei.

## **Präsentationen mit benutzerdefinierten Optionen nach XAML exportieren**

Verwenden Sie das Interface [IXamlOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/ixamloptions/), um zu steuern, wie Aspose.Slides eine Präsentation nach XAML exportiert.

Um die Ausgabe an einem benutzerdefinierten Ort zu speichern, implementieren Sie [IXamlOutputSaver](https://reference.aspose.com/slides/de/java/com.aspose.slides/ixamloutputsaver/) und übergeben Sie eine Instanz Ihrer Implementierung an die Methode [setOutputSaver](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) von [XamlOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/xamloptions/).

Um versteckte Folien in die XAML‑Ausgabe aufzunehmen, rufen Sie [setExportHiddenSlides](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) mit `true` auf, wie im folgenden JavaScript‑Beispiel gezeigt:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xamlOptions = new aspose.slides.XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

## **Alle erzeugten XAML‑Artefakte erfassen**

Ein XAML‑Export kann für jede exportierte Folie ein XAML‑Dokument sowie separate Bilder und unterstützende Ressourcen erzeugen. Weisen Sie [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) einen benutzerdefinierten [IXamlOutputSaver](https://reference.aspose.com/slides/de/java/com.aspose.slides/ixamloutputsaver/) zu, um diese Artefakte zu erhalten, anstatt den standardmäßigen Dateisystem‑Saver zu nutzen. Starten Sie den Export mit der XAML‑spezifischen Überladung von [Presentation.save](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#save), die XAML‑Optionen akzeptiert.

In Node.js implementieren Sie das Java‑Interface mit `java.newProxy` aus dem `java`‑Paket, das von Aspose.Slides verwendet wird. Halten Sie den Proxy erreichbar, bis der Export abgeschlossen ist.

### **Verstehen des Callback‑Lebenszyklus**

Der Exportierer ruft [IXamlOutputSaver.save](https://reference.aspose.com/slides/de/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) für jedes erzeugte Artefakt separat auf:

- `path` identifiziert das Artefakt und kann relative Verzeichnisse enthalten. Bewahren Sie diese Information auf, da XAML Ressourcen über relative Pfade referenzieren kann.
- `data` enthält die Bytes des Artefakts. Bilder und andere Binärressourcen dürfen nicht als Text dekodiert werden.
- Der Saver ist dafür verantwortlich, die Daten zu behalten oder zu persistieren, bevor er zurückkehrt. Die Beispiele kopieren jedes Java‑Byte‑Array in einen von der Anwendung verwalteten Node.js‑Buffer.
- Behandeln Sie den Export als erfolgreich nur, wenn der Speichervorgang der Präsentation zurückkehrt und jeder Callback erfolgreich abgeschlossen wurde. Unterdrücken Sie keine Speicher‑Fehler und starten Sie keine unbeobachteten Hintergrund‑Writes. Erfolgt die Persistierung danach, melden Sie den Gesamterfolg erst nach erfolgreichem Abschluss dieses Schrittes.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) gilt ebenfalls für einen benutzerdefinierten Saver. Die Standard‑Einstellung `false` schließt XAML‑Dokumente versteckter Folien aus. Wird `true` übergeben, werden sie sowie alle für ihren Export erforderlichen Ressourcen eingeschlossen. Die Anzahl der Ressourcen hängt von der Präsentation ab; gehen Sie nicht von einem Callback pro Folie oder einer festen Callback‑Reihenfolge aus.

### **Export in den Speicher und Artefakte untersuchen**

Dieses vollständige Beispiel lädt `input.pptx`, sammelt jedes Artefakt in einer JavaScript‑Map von Namen zu Buffern und gibt dessen Namen, Typ und Byte‑Anzahl aus. Es bewahrt die bereitgestellten Namen exakt. Doppelte Namen markieren die Sammlung als ungültig, anstatt ein Artefakt stillschweigend zu überschreiben. Das Beispiel prüft dies, bevor die Ergebnisse verwendet werden.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const artifacts = new Map();
let valid = true;
const saver = java.newProxy("com.aspose.slides.IXamlOutputSaver", {
    save: function(path, data) {
        const name = String(path);
        if (artifacts.has(name)) {
            valid = false;
            console.error("Export rejected: duplicate artifact name: " + name);
            return;
        }
        const retainedData = Buffer.from(data);
        artifacts.set(name, retainedData);
    }
});

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(true);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!valid) {
    console.error("Export rejected: the artifact collection is invalid.");
} else {
    const inspectXamlText = false;
    for (const [name, data] of artifacts) {
        const isXaml = /\.xaml$/i.test(name);
        const isImage = /\.(png|jpg|jpeg|gif|bmp|tif|tiff|svg)$/i.test(name);
        const kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
        console.log(name + ": " + data.length + " bytes (" + kind + ")");

        // Nur XAML dekodieren und nur, wenn eine textuelle Inspektion nötig ist.
        if (isXaml && inspectXamlText) {
            console.log(data.toString("utf8"));
        }
    }
}
```

Erweiterungs‑Checks sind für die Inspektion nützlich; behalten Sie alle Artefakte, einschließlich unbekannter Ressourcentypen. Lassen Sie die Bytes beim Speichern oder Übertragen unverändert. Verwenden Sie UTF‑8‑Dekodierung nur für XAML, das eine Textverarbeitung erfordert.

### **Gesammelte Artefakte in einem ZIP‑Archiv verpacken**

Dieses unabhängige Beispiel sammelt den Export, validiert die Namen und schreibt die Original‑Bytes in ein ZIP‑Archiv über die Java‑Brücke. Das ZIP wird im Speicher zusammengestellt, bevor es auf die Festplatte geschrieben wird. Ein eindeutiger Archiv‑Name trennt gleichzeitige Export‑Jobs. ZIP‑Einträge verwenden Vorwärtsschrägstriche und bewahren relative Verzeichnisse. Unsichere Namen oder Kollisionen nach Normalisierung verhindern das Schreiben des gesamten Pakets.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const artifacts = new Map();
let valid = true;
const saver = java.newProxy("com.aspose.slides.IXamlOutputSaver", {
    save: function(path, data) {
        const name = String(path);
        if (artifacts.has(name)) {
            valid = false;
            console.error("Export rejected: duplicate artifact name: " + name);
            return;
        }
        const retainedData = Buffer.from(data);
        artifacts.set(name, retainedData);
    }
});

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(false);
    presentation.save(options);
} finally {
    presentation.dispose();
}

const entries = new Map();
const entryNames = new Set();
for (const [name, data] of artifacts) {
    const entryName = name.replace(/\\/g, "/");
    const segments = entryName.split("/");
    const unsafeName = entryName.startsWith("/") || entryName.includes(":") || segments.some(segment => segment.trim() === "" || segment === "." || segment === "..");
    const comparisonName = entryName.toLowerCase();
    if (unsafeName || entryNames.has(comparisonName)) {
        valid = false;
        console.error("Export rejected: unsafe or duplicate artifact name: " + name);
        break;
    }
    entryNames.add(comparisonName);
    entries.set(entryName, data);
}

if (!valid) {
    console.error("Export rejected: the artifact collection is invalid.");
} else {
    const fs = require("node:fs");
    const crypto = require("node:crypto");
    const archivePath = "xaml-" + crypto.randomUUID() + ".zip";
    const output = java.newInstanceSync("java.io.ByteArrayOutputStream");
    const archive = java.newInstanceSync("java.util.zip.ZipOutputStream", output);
    try {
        for (const [name, data] of entries) {
            const entry = java.newInstanceSync("java.util.zip.ZipEntry", name);
            archive.putNextEntry(entry);
            const signedBytes = Array.from(data, value => value > 127 ? value - 256 : value);
            const bytes = java.newArray("byte", signedBytes);
            archive.write(bytes);
            archive.closeEntry();
        }
    } finally {
        archive.close();
    }

    // Das Schließen finalisiert das ZIP-Verzeichnis, bevor das Archiv gespeichert wird.
    const archiveData = Buffer.from(output.toByteArray());
    try {
        fs.writeFileSync(archivePath, archiveData, { flag: "wx" });
        console.log("Saved " + entries.size + " artifacts to " + archivePath);
    } catch (error) {
        console.error("Archive persistence failed: " + error.message);
    }
}
```

Das Beispiel verwendet [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html), um ein lokales Archiv zu schreiben; der Exportierer selbst schreibt keine losen XAML‑ oder Bilddateien. Für Remote‑Speicherung ersetzen Sie die Archiv‑Schreibphase durch Uploads der gesammelten Byte‑Arrays. Verwenden Sie einen Export‑Job‑Identifier plus den vollständigen relativen Artefaktnamen als Blob‑Schlüssel oder speichern Sie den Job‑Identifier, den relativen Namen und die Binärdaten in einer Datenbank‑Zeile. Veröffentlichen Sie den Job erst, nachdem alle Uploads abgeschlossen bzw. die Datenbank‑Transaktion committet ist. Bereinigen Sie Teil‑Ausgaben, wenn die Persistierung fehlschlägt.

Bei großen Präsentationen kann ein benutzerdefinierter Saver jedes Artefakt direkt in den Anwendungsspeicher persistieren, um das Halten einer zusätzlichen Kopie des gesamten Exports im Arbeitsspeicher zu vermeiden. Halten Sie jeden Callback aus Sicht des Exportierers synchron: Rückgabe erst, nachdem das Ziel die Bytes akzeptiert hat, und lassen Sie Fehler zum Aufrufer durchdringen.

### **Ressourcennamen beibehalten und Referenzen überprüfen**

- Normalisieren Sie Pfad‑Separatoren, wenn das Ziel dies erfordert, bewahren Sie jedoch relative Verzeichnisse. Verwenden Sie nicht nur den Basisnamen, es sei denn, jeder erzeugte Name ist eindeutig und Ressourcen‑Referenzen bleiben gültig.
- Wenden Sie ziel­spezifische Namens‑Validierung an. Beim Schreiben loser Dateien lehnen Sie verankernde Pfade und Traversal‑Segmente ab, lösen das Ziel zu einem absoluten Pfad auf und prüfen, dass es innerhalb des vorgesehenen Export‑Verzeichnisses bleibt, inklusive des Verzeichnis‑Separators in der Einschluss‑Prüfung. Nutzen Sie ein von der Anwendung kontrolliertes Verzeichnis ohne symbolische Links, die Schreibvorgänge umleiten könnten.
- Verwenden Sie für jeden Export‑Job einen separaten Saver und Namensraum. Erkennen Sie Kollisionen nach Separator‑Normalisierung und nach den Groß‑/Kleinschreib‑Regeln des Ziels.
- Vor der Veröffentlichung parsen Sie jedes XAML‑Dokument als XML und prüfen dessen dateibezogene Ressourcenreferenzen, etwa `Source`‑ oder `ImageSource`‑Attribute. Lösen Sie jede relative URI relativ zum Verzeichnis des enthaltenden XAML‑Artefakts auf, normalisieren Sie den resultierenden Speicher‑Namen und bestätigen Sie, dass der entsprechende Map‑Key, ZIP‑Eintrag oder gespeicherte Objekt existiert. Behandeln Sie externe URIs und XAML‑Markup‑Ausdrücke getrennt von relativen Dateinamen.

Beispiel: Verweist `input/Slide_1.xaml` auf `images/image1.png`, muss die gespeicherte Ressource als `input/images/image1.png` verfügbar sein. Nur `image1.png` zu behalten, würde die Beziehung brechen. Bei Objektspeicherung bewahren Sie dieselbe Struktur unter dem Job‑Präfix und stellen diese Ressourcen‑URLs dem XAML‑Verbraucher bereit. Öffnen Sie das fertige ZIP, um Eintragsnamen und Ressourcen‑Bytes zu prüfen, und laden Sie repräsentative Folien in der Ziel‑XAML‑Umgebung, um zu bestätigen, dass Bilder korrekt aufgelöst werden.

## **FAQ**

**Wie kann ich vorhersehbare Schriftarten sicherstellen, wenn die Originalschriftart auf dem Rechner nicht verfügbar ist?**

Rufen Sie [setDefaultRegularFont](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) in [XamlOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/xamloptions/) auf – diese wird während des Exports als Ersatzschriftart verwendet, wenn die Originalschriftart fehlt. Damit ist nicht garantiert, dass das erzeugte XAML die Ersatzschriftart referenziert oder dass die Schriftart auf dem Zielrechner verfügbar ist. Stellen Sie sicher, dass die im XAML referenzierten Schriftarten in der Umgebung, in der es angezeigt wird, vorhanden sind.

**Ist das exportierte XAML ausschließlich für WPF gedacht oder kann es auch in anderen XAML‑Stacks verwendet werden?**

Aspose.Slides exportiert WPF‑XAML über seine öffentliche API. Die Kompatibilität mit anderen XAML‑Stacks wie UWP und Xamarin.Forms ist nicht garantiert. Testen Sie das erzeugte Markup in Ihrer Zielumgebung.

**Werden versteckte Folien unterstützt und wie kann ich verhindern, dass sie standardmäßig exportiert werden?**

Standardmäßig werden versteckte Folien nicht eingeschlossen. Sie können dieses Verhalten über [setExportHiddenSlides](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) in [XamlOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/xamloptions/) steuern – lassen Sie es deaktiviert, wenn Sie sie nicht exportieren möchten.