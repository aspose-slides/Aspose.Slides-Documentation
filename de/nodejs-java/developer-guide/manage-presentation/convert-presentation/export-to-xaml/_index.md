---
title: Präsentationen nach XAML in JavaScript exportieren
linktitle: Präsentation nach XAML
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
description: "Konvertieren Sie PowerPoint- und OpenDocument-Folien in XAML mit JavaScript unter Verwendung von Aspose.Slides - eine schnelle, Office-freie Lösung, die Ihr Layout unverändert beibehält."
---
## **Übersicht**

Dieser Artikel erklärt, wie PowerPoint-Präsentationen mit Aspose.Slides nach XAML exportiert werden. Er enthält eine kurze Einführung in XAML, zeigt, wie eine Präsentation mit den Standardeinstellungen nach XAML gespeichert wird, und demonstriert, wie der Export über [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) angepasst werden kann, einschließlich des Exports versteckter Folien. Der Artikel beantwortet außerdem einige häufige Fragen zu Ersatzschriften, zur XAML‑Stack‑Kompatibilität und zum Verhalten beim Export versteckter Folien.

## **Über XAML**

XAML ist eine XML-basierte Auszeichnungssprache, die zur Beschreibung von Benutzeroberflächen in Frameworks wie WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) und Xamarin.Forms verwendet wird.

Sie können mit XAML-Dateien in einem visuellen Designer arbeiten oder die Markup direkt schreiben und bearbeiten.

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

Standardmäßig werden die exportierten Folien in einem Unterordner `input` des aktuellen Arbeitsverzeichnisses des Prozesses gespeichert. Der Ordner wird automatisch erstellt, und alle erforderlichen Bilder werden dort ebenfalls gespeichert.

Der Name des Ausgabeverzeichnisses wird aus dem Namen der Quelldatei ohne deren Erweiterung übernommen. In Aspose.Slides für Node.js über Java 26.8 erzeugt der Export von `input.pptx` einen verschachtelten Pfad wie `input/input/Slide_1.xaml`. Bewahren Sie die vollständig erzeugten Pfade bei der Verarbeitung der Ausgabe auf. Die Standardausgabe ist relativ zum aktuellen Arbeitsverzeichnis, nicht zwingend neben der Eingabedatei.

## **Präsentationen mit benutzerdefinierten Optionen nach XAML exportieren**

Verwenden Sie die Schnittstelle [IXamlOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloptions/), um zu steuern, wie Aspose.Slides eine Präsentation nach XAML exportiert.

Um die Ausgabe an einem benutzerdefinierten Ort zu speichern, implementieren Sie [IXamlOutputSaver](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/) und übergeben Sie eine Instanz Ihrer Implementierung an die Methode [setOutputSaver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) von [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/).

Um versteckte Folien in die XAML‑Ausgabe einzubeziehen, rufen Sie [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) mit `true` auf, wie im folgenden JavaScript‑Beispiel gezeigt:

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

Ein XAML‑Export kann für jede exportierte Folie ein XAML‑Dokument sowie separate Bilder und unterstützende Ressourcen erzeugen. Weisen Sie einen benutzerdefinierten [IXamlOutputSaver](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/) der Methode [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) zu, um diese Artefakte zu erhalten, anstatt den standardmäßigen Dateisystem‑Saver zu verwenden. Starten Sie den Export mit der XAML‑spezifischen Überladung [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save), die XAML‑Optionen akzeptiert.

In Node.js implementieren Sie die Java‑Schnittstelle mit `java.newProxy` aus dem `java`‑Paket, das von Aspose.Slides verwendet wird. Halten Sie den Proxy erreichbar, bis der Export abgeschlossen ist.

### **Verstehen des Callback‑Lebenszyklus**

Der Exporter ruft [IXamlOutputSaver.save](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) für jedes erzeugte Artefakt separat auf:

- `path` identifiziert das Artefakt und kann relative Verzeichnisse enthalten. Bewahren Sie diese Information auf, da XAML Ressourcen mit relativen Pfaden referenzieren kann.
- `data` enthält die Bytes des Artefakts. Bilder und andere Binärressourcen dürfen nicht als Text dekodiert werden.
- Der Saver ist dafür verantwortlich, die Daten vor der Rückkehr zu behalten oder zu persistieren. Die Beispiele kopieren jedes Java‑Byte‑Array in einen von der Anwendung besessenen Node.js‑Puffer.
- Betrachten Sie den Export nur dann als erfolgreich, wenn der Vorgang zum Speichern der Präsentation zurückkehrt und jeder Callback erfolgreich abgeschlossen wurde. Unterdrücken Sie keine Speicherfehler und starten Sie keine unbeobachteten Hintergrundschreibvorgänge. Wenn die Persistenz danach erfolgt, melden Sie den Gesamterfolg erst, wenn dieser Schritt ebenfalls erfolgreich war.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) gilt ebenfalls für einen benutzerdefinierten Saver. Die Standardeinstellung `false` schließt XAML‑Dokumente versteckter Folien aus. Wenn `true` übergeben wird, werden sie sowie alle für ihren Export erforderlichen Ressourcen einbezogen. Die Anzahl der Ressourcen hängt von der Präsentation ab; gehen Sie nicht von einem Callback pro Folie oder einer festen Callback‑Reihenfolge aus.

### **Export in den Speicher und die Artefakte inspizieren**

Dieses vollständige Beispiel lädt `input.pptx`, sammelt jedes Artefakt in einer JavaScript‑Map von Namen zu Puffern und gibt dessen Namen, Typ und Byte‑Anzahl aus. Es bewahrt die übergebenen Namen exakt. Doppelte Namen markieren die Sammlung als ungültig, anstatt ein Artefakt stillschweigend zu überschreiben. Das Beispiel prüft dies, bevor die Ergebnisse verwendet werden.

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

Erweiterungsprüfungen sind für die Inspektion nützlich; bewahren Sie alle Artefakte auf, einschließlich unbekannter Ressourcentypen. Lassen Sie die Bytes beim Speichern oder Übertragen unverändert. Verwenden Sie UTF‑8‑Dekodierung nur für XAML, das eine Textverarbeitung erfordert.

### **Gesammelte Artefakte in einem ZIP‑Archiv verpacken**

Dieses unabhängige Beispiel sammelt den Export, validiert die Namen und schreibt die Originalbytes mithilfe der Java‑Brücke in ein ZIP‑Archiv. Das ZIP‑Archiv wird im Speicher zusammengebaut, bevor es auf die Festplatte geschrieben wird. Ein eindeutiger Archivname trennt gleichzeitige Exportaufträge. ZIP‑Einträge verwenden Vorwärtsschrägstriche und bewahren relative Verzeichnisse. Unsichere Namen oder Namen, die nach Normalisierung kollidieren, führen zur Ablehnung des gesamten Pakets, bevor es geschrieben wird.

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
            const bytes = java.newArray("byte", Array.from(data));
            archive.write(bytes);
            archive.closeEntry();
        }
    } finally {
        archive.close();
    }

    // Schließen finalisiert das ZIP-Verzeichnis, bevor das Archiv gespeichert wird.
    const archiveData = Buffer.from(output.toByteArray());
    try {
        fs.writeFileSync(archivePath, archiveData, { flag: "wx" });
        console.log("Saved " + entries.size + " artifacts to " + archivePath);
    } catch (error) {
        console.error("Archive persistence failed: " + error.message);
    }
}
```

Das Beispiel verwendet [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html), um ein lokales Archiv zu schreiben; der Exporter selbst schreibt keine losen XAML‑ oder Bilddateien. Für die Remote‑Speicherung ersetzen Sie die Phase des Schreibens des Archivs durch das Hochladen der gesammelten Byte‑Arrays. Verwenden Sie einen Export‑Job‑Bezeichner plus den vollständigen relativen Artefaktnamen als Blob‑Schlüssel oder speichern Sie den Job‑Bezeichner, den relativen Namen und die Binärdaten in einer Datenbankzeile. Veröffentlichen Sie den Job erst, nachdem alle Uploads abgeschlossen sind oder die Datenbanktransaktion committet wurde. Räumen Sie teilweise Ausgaben auf, wenn die Persistenz fehlschlägt.

Für große Präsentationen kann ein benutzerdefinierter Saver jedes Artefakt direkt im Anwendungsspeicher persistieren, um zu vermeiden, dass eine zusätzliche Kopie des gesamten Exports im Anwendungsspeicher gehalten wird. Halten Sie jeden Callback aus Sicht des Exporters synchron: geben Sie erst zurück, nachdem das Ziel die Bytes akzeptiert hat, und lassen Sie Fehler zum Aufrufer durchdringen.

### **Ressourcennamen bewahren und Referenzen überprüfen**

- Normalisieren Sie Pfadtrennzeichen, wenn das Ziel dies erfordert, bewahren Sie jedoch relative Verzeichnisse. Verwenden Sie nicht nur den Basisnamen, es sei denn, jeder erzeugte Name ist eindeutig und Ressourcereferenzen bleiben gültig.
- Wenden Sie zielgerichtete Namensvalidierung an. Beim Schreiben loser Dateien lehnen Sie Pfade mit Root und Traversal‑Segmenten ab, lösen das Ziel in einen absoluten Pfad auf und prüfen, dass es unterhalb des vorgesehenen Exportverzeichnisses bleibt, wobei der Verzeichnistrenner in der Einschlussprüfung berücksichtigt wird. Verwenden Sie ein von der Anwendung gesteuertes Verzeichnis ohne symbolische Links, die Schreibvorgänge umleiten könnten.
- Verwenden Sie für jeden Exportauftrag einen separaten Saver und ein separates Speicher‑Namespace. Erkennen Sie Kollisionen nach Normalisierung der Trenner und gemäß den Groß‑/Kleinschreibungsregeln des Ziels.
- Bevor Sie veröffentlichen, parsen Sie jedes XAML‑Dokument als XML und prüfen Sie dessen dateibasierte Ressourcenreferenzen, wie Bild‑`Source`‑ oder `ImageSource`‑Attribute. Lösen Sie jede relative URI relativ zum Verzeichnis des enthaltenden XAML‑Artefakts auf, normalisieren Sie den resultierenden Speicher­namen und bestätigen Sie, dass der entsprechende Map‑Schlüssel, ZIP‑Eintrag oder gespeicherte Objekt existiert. Behandeln Sie externe URIs und XAML‑Markup‑Ausdrücke getrennt von relativen Dateinamen.

Zum Beispiel, wenn `input/Slide_1.xaml` die Datei `images/image1.png` referenziert, muss die gespeicherte Ressource als `input/images/image1.png` verfügbar sein. Nur `image1.png` zu behalten, würde diese Beziehung brechen. Für die Objektspeicherung bewahren Sie dieselbe Struktur unterhalb des Job‑Präfixes und machen diese Ressourcen‑URLs für den XAML‑Konsumenten zugänglich. Öffnen Sie das fertige ZIP erneut, um Eintragsnamen und Ressourcebytes zu überprüfen, und laden Sie repräsentative Folien in der Ziel‑XAML‑Umgebung, um zu bestätigen, dass Bilder korrekt aufgelöst werden.

## **FAQ**

**Wie kann ich vorhersehbare Schriftarten sicherstellen, wenn die Originalschriftart nicht auf dem Computer verfügbar ist?**

Rufen Sie [setDefaultRegularFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) in [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) auf – sie wird während des Exports als Ersatzschriftart verwendet, wenn die Originalschriftart fehlt. Dies garantiert nicht, dass das erzeugte XAML die Ersatzschriftart referenziert oder dass die Schriftart auf dem Zielcomputer verfügbar ist. Stellen Sie sicher, dass die im XAML referenzierten Schriftarten in der Umgebung, in der es angezeigt wird, vorhanden sind.

**Ist das exportierte XAML ausschließlich für WPF vorgesehen, oder kann es auch in anderen XAML‑Stacks verwendet werden?**

Aspose.Slides exportiert WPF‑XAML über seine öffentliche API. Die Kompatibilität mit anderen XAML‑Stacks, wie UWP und Xamarin.Forms, ist nicht garantiert. Testen Sie das erzeugte Markup in Ihrer Zielumgebung.

**Werden versteckte Folien unterstützt und wie kann ich verhindern, dass sie standardmäßig exportiert werden?**

Standardmäßig werden versteckte Folien nicht einbezogen. Sie können dieses Verhalten über [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) in [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) steuern – deaktivieren Sie es, wenn Sie sie nicht exportieren müssen.