---
title: Präsentationen nach XAML auf Android exportieren
linktitle: Präsentation zu XAML
type: docs
weight: 30
url: /de/androidjava/export-to-xaml/
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
- PPT zu XAML exportieren
- PPTX zu XAML exportieren
- ODP zu XAML exportieren
- Android
- Java
- Aspose.Slides
description: "Konvertieren Sie PowerPoint- und OpenDocument-Folien in Java mit Aspose.Slides für Android zu XAML – eine schnelle, Office-freie Lösung, die Ihr Layout unverändert lässt."
---
## **Übersicht**

Dieser Artikel erklärt, wie PowerPoint‑Präsentationen mit Aspose.Slides für Android über Java nach XAML exportiert werden. Er enthält eine kurze Einführung in XAML, zeigt, wie eine Präsentation mit den Standardeinstellungen nach XAML gespeichert wird, und demonstriert, wie der Export über [XamlOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/xamloptions/) angepasst werden kann, einschließlich des Exports versteckter Folien. Der Artikel beantwortet außerdem einige häufige Fragen zu Ersatzschriftarten, XAML‑Stack‑Kompatibilität und dem Verhalten beim Export versteckter Folien.

## **Über XAML**

XAML ist eine XML‑basierte Auszeichnungssprache, die zur Beschreibung von Benutzeroberflächen in Frameworks wie WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) und Xamarin.Forms verwendet wird.

Sie können mit XAML‑Dateien in einem visuellen Designer arbeiten oder die Markup‑Datei direkt schreiben und bearbeiten.

## **Präsentationen mit Standardoptionen nach XAML exportieren**

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

Standardmäßig werden die exportierten Folien in einem Unterordner `pres` des aktuellen Arbeitsverzeichnisses des Prozesses gespeichert. Der Ordner wird automatisch erstellt, und alle erforderlichen Bilder werden dort ebenfalls abgelegt.

Der Name des Ausgabeverzeichnisses wird aus dem Dateinamen der Quelldatei ohne deren Erweiterung abgeleitet. Für `pres.pptx` heißen die Ausgabedateien `pres/Slide_1.xaml`, `pres/Slide_2.xaml` usw. Selbst wenn Sie einen absoluten Pfad zur Eingabedatei übergeben, wird das Ausgabeverzeichnis relativ zum aktuellen Arbeitsverzeichnis erstellt und nicht neben der Eingabedatei.

Unter Android verwenden Sie eine Eingabedatei, die für Ihre App zugänglich ist. Das aktuelle Arbeitsverzeichnis ist möglicherweise nicht beschreibbar; verwenden Sie einen benutzerdefinierten Output‑Saver, um den Export im Speicher zu behalten oder in den App‑Speicher zu schreiben, wie unten gezeigt. Das erzeugte WPF‑XAML ist für einen kompatiblen Verbraucher gedacht und kein Android‑Layout‑Ressourcendatei.

## **Präsentationen mit benutzerdefinierten Optionen nach XAML exportieren**

Verwenden Sie die Schnittstelle [IXamlOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ixamloptions/), um zu steuern, wie Aspose.Slides eine Präsentation nach XAML exportiert.

Um die Ausgabe an einem benutzerdefinierten Ort zu speichern, implementieren Sie [IXamlOutputSaver](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ixamloutputsaver/), und übergeben Sie eine Instanz Ihrer Implementierung an die Methode [setOutputSaver](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) von [XamlOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/xamloptions/).

Um versteckte Folien in die XAML‑Ausgabe aufzunehmen, rufen Sie [setExportHiddenSlides](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) mit `true` auf, wie im folgenden Java‑Beispiel gezeigt:

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

## **Alle erzeugten XAML‑Artefakte erfassen**

Ein XAML‑Export kann für jede exportierte Folie ein XAML‑Dokument sowie separate Bilder und unterstützende Ressourcen erzeugen. Weisen Sie [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) einen benutzerdefinierten [IXamlOutputSaver](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ixamloutputsaver/) zu, um diese Artefakte zu erhalten, anstatt den standardmäßigen Dateisystem‑Saver zu verwenden. Starten Sie den Export mit der XAML‑spezifischen [Presentation.save](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-)‑Überladung, die XAML‑Optionen akzeptiert.

### **Den Lebenszyklus des Callbacks verstehen**

Der Exporter ruft [IXamlOutputSaver.save](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) separat für jedes erzeugte Artefakt auf:

- `path` identifiziert das Artefakt und kann relative Verzeichnisse enthalten. Bewahren Sie diese Information auf, da XAML Ressourcen über relative Pfade referenzieren kann.
- `data` enthält die Bytes des Artefakts. Bilder und andere binäre Ressourcen dürfen nicht als Text decodiert werden.
- Der Saver ist dafür verantwortlich, die Daten vor der Rückkehr zu behalten oder zu persistieren. Die Beispiele kopieren jedes Byte‑Array in vom Anwendung verwalteten Speicher.
- Betrachten Sie den Export nur als erfolgreich, wenn der Speichervorgang der Präsentation zurückkehrt und jeder Callback erfolgreich abgeschlossen wurde. Unterdrücken Sie keine Speicherfehler und starten Sie keine unbeobachteten Hintergrundschreibvorgänge. Erfolgt die Persistenz nachträglich, melden Sie den Gesamterfolg erst, wenn auch dieser Schritt erfolgreich war.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) gilt ebenfalls für einen benutzerdefinierten Saver. Die Standardeinstellung `false` schließt XAML‑Dokumente versteckter Folien aus. Wird `true` übergeben, werden sie sowie alle für den Export benötigten Ressourcen einbezogen. Die Anzahl der Ressourcen hängt von der Präsentation ab; gehen Sie nicht davon aus, dass es pro Folie einen Callback gibt oder dass die Callback‑Reihenfolge fest ist.

### **Export in den Speicher und Artefakte untersuchen**

Dieses vollständige Beispiel lädt `pres.pptx`, sammelt jedes Artefakt in einer [Map<String, byte[]>](https://docs.oracle.com/javase/8/docs/api/java/util/Map.html) und gibt dessen Namen, Typ und Byte‑Anzahl aus. Es bewahrt die bereitgestellten Namen exakt. Doppelte Namen markieren die Sammlung als ungültig, anstatt ein Artefakt stillschweigend zu überschreiben. Das Beispiel prüft dies, bevor die Ergebnisse verwendet werden.

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

Erweiterungsprüfungen sind für die Inspektion nützlich; behalten Sie alle Artefakte, einschließlich unbekannter Ressourcentypen, bei. Lassen Sie die Bytes beim Speichern oder Übertragen unverändert. Verwenden Sie den [String constructor](https://docs.oracle.com/javase/8/docs/api/java/lang/String.html#String-byte:A-java.nio.charset.Charset-) mit UTF‑8 nur für XAML, das eine textuelle Verarbeitung erfordert.

### **Gesammelte Artefakte in einem ZIP‑Archiv verpacken**

Dieses eigenständige Beispiel sammelt den Export, validiert die Namen und schreibt die ursprünglichen Bytes in ein ZIP‑Archiv. Ersetzen Sie `/path/to/app/files` durch den Pfad, der von der [getFilesDir](https://developer.android.com/reference/android/content/Context#getFilesDir())‑Methode Ihres Android‑Contexts zurückgegeben wird. Ein eindeutiger Archivname trennt gleichzeitige Exportaufträge. ZIP‑Einträge verwenden Vorwärtsschrägstriche und behalten relative Verzeichnisse bei. Unsichere Namen oder nach Normalisierung kollidierende Namen führen zur Ablehnung des gesamten Pakets, bevor es geschrieben wird.

```java
import com.aspose.slides.*;
import java.util.LinkedHashMap;
import java.util.Map;
import java.io.IOException;
import java.io.File;
import java.io.FileOutputStream;
import java.util.Set;
import java.util.TreeSet;
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

File exportDirectory = new File("/path/to/app/files");
try {
    File archiveFile = File.createTempFile("xaml-", ".zip", exportDirectory);
    try (FileOutputStream archiveOutput = new FileOutputStream(archiveFile); ZipOutputStream archive = new ZipOutputStream(archiveOutput)) {
        for (Map.Entry<String, byte[]> artifact : entries.entrySet()) {
            ZipEntry entry = new ZipEntry(artifact.getKey());
            archive.putNextEntry(entry);
            archive.write(artifact.getValue());
            archive.closeEntry();
        }
    }

    // Das ZIP-Verzeichnis wurde beim Schließen fertiggestellt, bevor der Erfolg gemeldet wird.
    System.out.println("Saved " + entries.size() + " artifacts to " + archiveFile);
} catch (IOException exception) {
    System.err.println("Archive persistence failed: " + exception.getMessage());
}
```

Das Beispiel verwendet [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html), um ein lokales Archiv zu schreiben; der Exporter selbst schreibt keine losen XAML‑ oder Bilddateien. Für die Remote‑Speicherung ersetzen Sie die Archiv‑Schreibphase durch das Hochladen der gesammelten Byte‑Arrays. Verwenden Sie einen Export‑Job‑Bezeichner plus den vollständigen relativen Artefaktnamen als Blob‑Schlüssel, oder speichern Sie den Job‑Bezeichner, den relativen Namen und die Binärdaten in einer Datenbankzeile. Veröffentlichen Sie den Job erst, nachdem alle Uploads abgeschlossen oder die Datenbanktransaktion bestätigt ist. Bereinigen Sie Teil‑Ausgaben, falls die Persistenz fehlschlägt.

Bei großen Präsentationen kann ein benutzerdefinierter Saver jedes Artefakt direkt im Anwendungsspeicher persistieren, um zu vermeiden, dass eine zusätzliche Kopie des gesamten Exports im Anwendungsspeicher gehalten wird. Halten Sie jeden Callback aus Sicht des Exporters synchron: geben Sie erst zurück, nachdem das Ziel die Bytes akzeptiert hat, und lassen Sie Fehler an den Aufrufer weitergeben.

### **Ressourcennamen bewahren und Referenzen prüfen**

- Normalisieren Sie Pfadtrennzeichen, wenn das Ziel dies erfordert, behalten jedoch relative Verzeichnisse bei. Verwenden Sie nicht ausschließlich [File.getName](https://developer.android.com/reference/java/io/File#getName()), es sei denn, jeder erzeugte Name ist eindeutig und Ressourcenreferenzen bleiben gültig.
- Wenden Sie ziel­spezifische Namensvalidierung an. Beim Schreiben loser Dateien lehnen Sie absolute Pfade und Traversal‑Segmente ab, lösen Sie das Ziel mit [File.getCanonicalPath](https://developer.android.com/reference/java/io/File#getCanonicalPath()) auf und prüfen Sie, dass es unter dem vorgesehenen Exportverzeichnis bleibt, einschließlich des Verzeichnis­trennzeichens bei der Enthaltungsprüfung. Verwenden Sie ein von der Anwendung gesteuertes Verzeichnis ohne symbolische Links, die Schreibvorgänge umleiten könnten.
- Verwenden Sie für jeden Export‑Job einen separaten Saver und Namensraum für den Speicher. Erkennen Sie Kollisionen nach Normalisierung der Trennzeichen und entsprechend den Groß‑/Kleinschreibungsregeln des Ziels.
- Vor der Veröffentlichung parsen Sie jedes XAML‑Dokument als XML und prüfen die dateibasierten Ressourcenreferenzen, etwa Bild‑`Source`‑ oder `ImageSource`‑Attribute. Lösen Sie jede relative URI relativ zum Verzeichnis des enthaltenden XAML‑Artefakts auf, normalisieren Sie den resultierenden Speicher­namen und bestätigen Sie, dass der entsprechende Map‑Schlüssel, ZIP‑Eintrag oder das gespeicherte Objekt existiert. Behandeln Sie externe URIs und XAML‑Markup‑Ausdrücke getrennt von relativen Dateinamen.

Beispiel: Wenn `pres/Slide_1.xaml` die Datei `images/image1.png` referenziert, muss die gespeicherte Ressource als `pres/images/image1.png` verfügbar sein. Nur `image1.png` zu behalten, würde diese Beziehung brechen. Für die Objektspeicherung bewahren Sie dieselbe Struktur unter dem Job‑Präfix und machen diese Ressourcen‑URLs für den XAML‑Verbraucher zugänglich. Öffnen Sie das fertiggestellte ZIP erneut, um Eintragsnamen und Ressourcenytes zu prüfen, und laden Sie repräsentative Folien in der Ziel‑XAML‑Umgebung, um zu bestätigen, dass Bilder korrekt aufgelöst werden.

## **FAQ**

**Wie kann ich sicherstellen, dass vorhersehbare Schriftarten verwendet werden, wenn die Originalschriftart nicht auf dem Rechner verfügbar ist?**

Rufen Sie [setDefaultRegularFont](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) in [XamlOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/xamloptions/) auf – er wird beim Export als Ersatzschriftart verwendet, wenn die Originalschriftart fehlt. Dies garantiert nicht, dass das erzeugte XAML die Ersatzschriftart referenziert oder dass die Schriftart auf dem Zielrechner verfügbar ist. Stellen Sie sicher, dass die vom XAML referenzierten Schriftarten in der Umgebung, in der es angezeigt wird, verfügbar sind.

**Ist das exportierte XAML nur für WPF gedacht oder kann es auch in anderen XAML‑Stacks verwendet werden?**

Aspose.Slides exportiert WPF‑XAML über seine öffentliche API. Die Kompatibilität mit anderen XAML‑Stacks, wie UWP und Xamarin.Forms, ist nicht garantiert. Testen Sie das erzeugte Markup in Ihrer Zielumgebung.

**Werden versteckte Folien unterstützt und wie kann ich verhindern, dass sie standardmäßig exportiert werden?**

Standardmäßig werden versteckte Folien nicht einbezogen. Sie können dieses Verhalten über [setExportHiddenSlides](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) in [XamlOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/xamloptions/) steuern – lassen Sie es deaktiviert, wenn Sie sie nicht exportieren müssen.