---
title: Präsentationen nach XAML in Java exportieren
linktitle: Präsentation nach XAML
type: docs
weight: 30
url: /de/java/export-to-xaml/
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
- Java
- Aspose.Slides
description: "Konvertieren Sie PowerPoint- und OpenDocument-Folien in XAML mit Java und Aspose.Slides - eine schnelle, Office-freie Lösung, die Ihr Layout unverändert beibehält."
---
## **Übersicht**

Dieser Artikel erklärt, wie PowerPoint‑Präsentationen mit Aspose.Slides nach XAML exportiert werden. Er enthält eine kurze Einführung in XAML, zeigt, wie eine Präsentation mit den Standardeinstellungen nach XAML gespeichert wird, und demonstriert, wie der Export über [XamlOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/xamloptions/) angepasst werden kann, einschließlich des Exports versteckter Folien. Der Artikel beantwortet außerdem einige häufige Fragen zu Ersatzschriften, zur Kompatibilität von XAML‑Stacks und zum Verhalten beim Export versteckter Folien.

## **Über XAML**

XAML ist eine XML‑basierte Auszeichnungssprache, die zur Beschreibung von Benutzeroberflächen in Frameworks wie WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) und Xamarin.Forms verwendet wird.

Sie können mit XAML‑Dateien in einem visuellen Designer arbeiten oder die Markup‑Datei direkt schreiben und bearbeiten.

## **Exportieren von Präsentationen nach XAML mit Standardoptionen**

Das folgende Java‑Beispiel zeigt, wie eine Präsentation mit den Standardeinstellungen nach XAML exportiert wird:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions xamlOptions = new XamlOptions();
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

Standardmäßig werden die exportierten Folien in einem Unterordner `pres` des aktuellen Arbeitsverzeichnisses des Prozesses gespeichert, wobei der Pfad aus einem leeren Pfad mit [Paths.get](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Paths.html#get-java.lang.String-java.lang.String...-) aufgelöst wird. Der Ordner wird automatisch erstellt, und alle erforderlichen Bilder werden dort ebenfalls gespeichert.

Der Name des Ausgabeverzeichnisses wird aus dem Namen der Quelldatei ohne deren Erweiterung abgeleitet. Für `pres.pptx` heißen die Ausgabedateien `pres/Slide_1.xaml`, `pres/Slide_2.xaml` usw. Selbst wenn Sie einen absoluten Pfad zur Eingabedatei übergeben, wird das Ausgabeverzeichnis relativ zum aktuellen Arbeitsverzeichnis erstellt und nicht neben der Eingabedatei.

## **Exportieren von Präsentationen nach XAML mit benutzerdefinierten Optionen**

Verwenden Sie die Schnittstelle [IXamlOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/ixamloptions/), um zu steuern, wie Aspose.Slides eine Präsentation nach XAML exportiert.

Um die Ausgabe an einem benutzerdefinierten Ort zu speichern, implementieren Sie [IXamlOutputSaver](https://reference.aspose.com/slides/de/java/com.aspose.slides/ixamloutputsaver/) und übergeben Sie eine Instanz Ihrer Implementierung an die Methode [setOutputSaver](https://reference.aspose.com/slides/de/java/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) von [XamlOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/xamloptions/).

Um versteckte Folien in die XAML‑Ausgabe aufzunehmen, rufen Sie [setExportHiddenSlides](https://reference.aspose.com/slides/de/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) mit dem Wert `true` auf, wie im folgenden Java‑Beispiel gezeigt:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions xamlOptions = new XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

## **Alle generierten XAML‑Artefakte erfassen**

Ein XAML‑Export kann für jede exportierte Folie ein XAML‑Dokument sowie separate Bilder und unterstützende Ressourcen erzeugen. Weisen Sie [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/de/java/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) einen benutzerdefinierten [IXamlOutputSaver](https://reference.aspose.com/slides/de/java/com.aspose.slides/ixamloutputsaver/) zu, um diese Artefakte zu erhalten, anstatt den standardmäßigen Dateisystem‑Saver zu verwenden. Starten Sie den Export mit der XAML‑spezifischen Überladung von [Presentation.save](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-), die XAML‑Optionen akzeptiert.

### **Verstehen des Callback‑Lebenszyklus**

Der Exporteur ruft [IXamlOutputSaver.save](https://reference.aspose.com/slides/de/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) separat für jedes erzeugte Artefakt auf:

- `path` identifiziert das Artefakt und kann relative Verzeichnisse enthalten. Bewahren Sie diese Information, da XAML Ressourcen über relative Pfade referenzieren kann.
- `data` enthält die Bytes des Artefakts. Bilder und andere Binärressourcen dürfen nicht als Text dekodiert werden.
- Der Saver ist dafür verantwortlich, die Daten vor der Rückkehr zu behalten oder zu persistieren. Die Beispiele kopieren jedes Byte‑Array in applikationsinternen Speicher.
- Behandeln Sie den Export nur als erfolgreich, wenn der Speichervorgang der Präsentation zurückkehrt und jeder Callback erfolgreich abgeschlossen wurde. Unterdrücken Sie keine Speicherfehler und starten Sie keine unbeobachteten Hintergrundschreibvorgänge. Erfolgt die Persistierung anschließend, melden Sie den Gesamterfolg erst, wenn dieser Schritt ebenfalls erfolgreich war.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/de/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) gilt auch für einen benutzerdefinierten Saver. Die Standardeinstellung `false` schließt XAML‑Dokumente versteckter Folien aus. Wird `true` übergeben, werden diese sowie alle für deren Export erforderlichen Ressourcen einbezogen. Die Anzahl der Ressourcen hängt von der Präsentation ab; gehen Sie nicht von einem Callback pro Folie oder einer festen Reihenfolge aus.

### **Export in den Speicher und Artefakte prüfen**

Dieses vollständige Beispiel lädt `pres.pptx`, sammelt jedes Artefakt in einem [Map<String, byte[]>](https://docs.oracle.com/javase/8/docs/api/java/util/Map.html) und gibt dessen Namen, Typ und Byte‑Anzahl aus. Es bewahrt die übergebenen Namen exakt. Doppelte Namen markieren die Sammlung als ungültig, anstatt ein Artefakt stillschweigend zu überschreiben. Das Beispiel prüft dies, bevor die Ergebnisse verwendet werden.

```java
import com.aspose.slides.*;
import java.util.LinkedHashMap;
import java.util.Map;
import java.nio.charset.StandardCharsets;
import java.util.Locale;

class MemoryXamlSaver implements IXamlOutputSaver {
    final Map<String, byte[]> artifacts = new LinkedHashMap<>();
    boolean valid = true;

    @Override
    public void save(String path, byte[] data) {
        if (artifacts.containsKey(path)) {
            valid = false;
            System.err.println("Export rejected: duplicate artifact name: " + path);
            return;
        }
        byte[] retainedData = data.clone();
        artifacts.put(path, retainedData);
    }
}

MemoryXamlSaver saver = new MemoryXamlSaver();
Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions options = new XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(true);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!saver.valid) {
    System.err.println("Export rejected: the artifact collection is invalid.");
    return;
}

boolean inspectXamlText = false;
for (Map.Entry<String, byte[]> artifact : saver.artifacts.entrySet()) {
    String name = artifact.getKey().toLowerCase(Locale.ROOT);
    boolean isXaml = name.endsWith(".xaml");
    boolean isImage = name.matches(".*\\.(png|jpg|jpeg|gif|bmp|tif|tiff|svg)$");
    String kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
    System.out.println(artifact.getKey() + ": " + artifact.getValue().length + " bytes (" + kind + ")");

    // Nur XAML dekodieren und nur, wenn eine textuelle Inspektion erforderlich ist.
    if (isXaml && inspectXamlText) {
        String markup = new String(artifact.getValue(), StandardCharsets.UTF_8);
        System.out.println(markup);
    }
}
```

Erweiterungsprüfungen sind für die Inspektion nützlich; behalten Sie alle Artefakte, einschließlich unbekannter Ressourcentypen, bei. Lassen Sie die Bytes unverändert, wenn Sie sie speichern oder übertragen. Verwenden Sie den [String‑Konstruktor](https://docs.oracle.com/javase/8/docs/api/java/lang/String.html#String-byte:A-java.nio.charset.Charset-) mit UTF‑8 nur für XAML, das eine textuelle Verarbeitung erfordert.

### **Sammeln der Artefakte in einem ZIP‑Archiv verpacken**

Dieses unabhängige Beispiel sammelt den Export, validiert die Namen und schreibt die ursprünglichen Bytes in ein ZIP‑Archiv. Ein eindeutiger Archivname trennt gleichzeitige Export‑Jobs. ZIP‑Einträge verwenden Vorwärtsschrägstriche und bewahren relative Verzeichnisse. Unsichere Namen oder Namen, die nach Normalisierung kollidieren, führen dazu, dass das gesamte Paket vor dem Schreiben verworfen wird.

```java
import com.aspose.slides.*;
import java.util.LinkedHashMap;
import java.util.Map;
import java.io.IOException;
import java.io.OutputStream;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.nio.file.StandardOpenOption;
import java.util.Set;
import java.util.TreeSet;
import java.util.UUID;
import java.util.zip.ZipEntry;
import java.util.zip.ZipOutputStream;

class MemoryXamlSaver implements IXamlOutputSaver {
    final Map<String, byte[]> artifacts = new LinkedHashMap<>();
    boolean valid = true;

    @Override
    public void save(String path, byte[] data) {
        if (artifacts.containsKey(path)) {
            valid = false;
            System.err.println("Export rejected: duplicate artifact name: " + path);
            return;
        }
        byte[] retainedData = data.clone();
        artifacts.put(path, retainedData);
    }
}

MemoryXamlSaver saver = new MemoryXamlSaver();
Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions options = new XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(false);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!saver.valid) {
    System.err.println("Export rejected: the artifact collection is invalid.");
    return;
}

Map<String, byte[]> entries = new LinkedHashMap<>();
Set<String> entryNames = new TreeSet<>(String.CASE_INSENSITIVE_ORDER);
for (Map.Entry<String, byte[]> artifact : saver.artifacts.entrySet()) {
    String entryName = artifact.getKey().replace('\\', '/');
    String[] segments = entryName.split("/", -1);
    boolean unsafeName = entryName.startsWith("/") || entryName.contains(":");
    for (String segment : segments) {
        unsafeName |= segment.trim().isEmpty() || segment.equals(".") || segment.equals("..");
    }

    if (unsafeName || !entryNames.add(entryName)) {
        System.err.println("Export rejected: unsafe or duplicate artifact name: " + artifact.getKey());
        return;
    }
    entries.put(entryName, artifact.getValue());
}

Path archivePath = Paths.get("xaml-" + UUID.randomUUID() + ".zip");
try {
    OutputStream output = Files.newOutputStream(archivePath, StandardOpenOption.CREATE_NEW, StandardOpenOption.WRITE);
    try (OutputStream archiveOutput = output; ZipOutputStream archive = new ZipOutputStream(archiveOutput)) {
        for (Map.Entry<String, byte[]> artifact : entries.entrySet()) {
            ZipEntry entry = new ZipEntry(artifact.getKey());
            archive.putNextEntry(entry);
            archive.write(artifact.getValue());
            archive.closeEntry();
        }
    }

    // Das ZIP-Verzeichnis wurde durch Schließen finalisiert, bevor der Erfolg gemeldet wird.
    System.out.println("Saved " + entries.size() + " artifacts to " + archivePath);
} catch (IOException exception) {
    System.err.println("Archive persistence failed: " + exception.getMessage());
}
```

Das Beispiel verwendet [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html), um ein lokales Archiv zu schreiben; der Exporteur selbst schreibt keine losen XAML‑ oder Bilddateien. Für Remote‑Speicher ersetzen Sie die Archiv‑Schreibphase durch das Hochladen der gesammelten Byte‑Arrays. Verwenden Sie einen Export‑Job‑Bezeichner plus den vollständigen relativen Artefakt‑Namen als Blob‑Schlüssel oder speichern Sie den Job‑Bezeichner, den relativen Namen und die Binärdaten in einer Datenbankzeile. Veröffentlichen Sie den Job erst, nachdem alle Uploads abgeschlossen sind oder die Datenbank‑Transaktion festgeschrieben wurde. Bereinigen Sie Teil‑Ausgaben, falls die Persistierung fehlschlägt.

Für große Präsentationen kann ein benutzerdefinierter Saver jedes Artefakt direkt im Anwendungsspeicher persistieren, um zu vermeiden, dass eine zusätzliche Kopie des gesamten Exports im Arbeitsspeicher gehalten wird. Halten Sie jeden Callback aus Sicht des Exporteurs synchron: Rückgabe erst, nachdem das Ziel die Bytes akzeptiert hat, und erlauben Sie Fehlermeldungen, den Aufrufer zu erreichen.

### **Ressourcennamen beibehalten und Referenzen überprüfen**

- Normalisieren Sie Pfadtrennzeichen, wenn das Ziel dies verlangt, bewahren Sie jedoch relative Verzeichnisse. Verwenden Sie nicht ausschließlich [Path.getFileName](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Path.html#getFileName--) – nur wenn jeder erzeugte Name eindeutig ist und Ressourcereferenzen gültig bleiben.
- Wenden Sie zielspezifische Namensvalidierung an. Beim Schreiben loser Dateien lehnen Sie Pfade ab, die am Wurzelverzeichnis beginnen oder Traversal‑Segmente enthalten, lösen das Ziel mit [Path.toAbsolutePath](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Path.html#toAbsolutePath--) auf und prüfen, dass es innerhalb des vorgesehenen Export‑Verzeichnisses bleibt, inklusive des Verzeichnistrennzeichens in der Enthaltungsprüfung. Nutzen Sie ein von der Anwendung kontrolliertes Verzeichnis ohne symbolische Links, die Schreibvorgänge umleiten könnten.
- Verwenden Sie für jeden Export‑Job einen separaten Saver und Namensraum. Erkennen Sie Kollisionen nach Normalisierung der Trennzeichen und nach den Groß‑/Kleinschreibregeln des Ziels.
- Vor der Veröffentlichung parsen Sie jedes XAML‑Dokument als XML und prüfen die dateibasierten Ressourcenreferenzen, etwa Bild‑`Source`‑ oder `ImageSource`‑Attribute. Lösen Sie jede relative URI relativ zum Verzeichnis des jeweiligen XAML‑Artefakts auf, normalisieren Sie den resultierenden Speicher‑Namen und bestätigen Sie, dass der entsprechende Schlüssel in der Map, der ZIP‑Eintrag oder das gespeicherte Objekt existiert. Behandeln Sie externe URIs und XAML‑Markup‑Ausdrücke separat von relativen Dateinamen.

Beispiel: Verweist `pres/Slide_1.xaml` auf `images/image1.png`, muss die gespeicherte Ressource unter `pres/images/image1.png` verfügbar sein. Nur `image1.png` zu behalten, würde die Beziehung brechen. Für Objekt‑Speicher bewahren Sie dieselbe Struktur unter dem Job‑Präfix und stellen diese Ressourc‑URLs dem XAML‑Verbraucher zur Verfügung. Öffnen Sie das fertige ZIP erneut, um Eintragsnamen und Ressourcen‑Bytes zu prüfen, und laden Sie repräsentative Folien in der Ziel‑XAML‑Umgebung, um zu bestätigen, dass Bilder korrekt aufgelöst werden.

## **FAQ**

**Wie kann ich vorhersehbare Schriftarten sicherstellen, wenn die Originalschriftart nicht auf dem Rechner verfügbar ist?**

Rufen Sie [setDefaultRegularFont](https://reference.aspose.com/slides/de/java/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) in [XamlOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/xamloptions/) auf – sie wird als Ersatzschriftart während des Exports verwendet, wenn die Originalschriftart fehlt. Dies garantiert nicht, dass das erzeugte XAML die Ersatzschriftart referenziert oder dass die Schriftart auf dem Zielsystem verfügbar ist. Stellen Sie sicher, dass die vom XAML referenzierten Schriftarten in der Umgebung, in der es angezeigt wird, vorhanden sind.

**Ist das exportierte XAML nur für WPF vorgesehen, oder kann es auch in anderen XAML‑Stacks verwendet werden?**

Aspose.Slides exportiert WPF‑XAML über seine öffentliche API. Die Kompatibilität mit anderen XAML‑Stacks wie UWP und Xamarin.Forms ist nicht garantiert. Testen Sie das erzeugte Markup in Ihrer Zielumgebung.

**Werden versteckte Folien unterstützt und wie kann ich verhindern, dass sie standardmäßig exportiert werden?**

Standardmäßig werden versteckte Folien nicht einbezogen. Dieses Verhalten können Sie über [setExportHiddenSlides](https://reference.aspose.com/slides/de/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) in [XamlOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/xamloptions/) steuern – deaktivieren Sie die Option, wenn Sie sie nicht exportieren möchten.