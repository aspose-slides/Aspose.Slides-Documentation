---
title: PowerPoint-Präsentationen in Java zu Markdown konvertieren
linktitle: PowerPoint zu Markdown
type: docs
weight: 140
url: /de/java/convert-powerpoint-to-markdown/
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
- PPT zu MD exportieren
- PPTX zu MD exportieren
- Markdown‑Bildexport
- CDN‑Bildlinks
- PowerPoint
- Präsentation
- Markdown
- Java
- Aspose.Slides
description: "PPT‑ und PPTX‑Präsentationen in Java zu Markdown konvertieren und steuern, wo exportierte Bitmap‑, Metafile‑ und SVG‑Bilder gespeichert und referenziert werden."
---
## **Überblick**

Aspose.Slides für Java kann PPT- und PPTX-Präsentationen in Markdown konvertieren, um sie in Dokumentations-, Static‑Site-, Content‑Migration‑ und Versions‑Control‑Workflows zu verwenden. Sie können einen Markdown‑Flavor auswählen, steuern, wie Folieninhalte gerendert werden, und festlegen, wo exportierte Bilder gespeichert werden und wie das erzeugte Markdown auf sie verweist.

Standardmäßig verwendet der Markdown‑Export eine reine Textausgabe. Um visuelle Inhalte zu exportieren, setzen Sie den Exporttyp mit der [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/de/java/com.aspose.slides/markdownsaveoptions/)‑Methode auf den `Sequential`‑ oder `Visual`‑Wert der Aufzählung [MarkdownExportType](https://reference.aspose.com/slides/de/java/com.aspose.slides/markdownexporttype/). `Sequential` rendert Folienelemente einzeln und in Reihenfolge, während `Visual` gruppierte Elemente zusammenhält, um ihre visuelle Beziehung zu bewahren. Der Wert `TextOnly` erzeugt keine Bildressourcen, sodass die Bild‑Speicher‑Callbacks in diesem Modus nicht aufgerufen werden.

## **Präsentation in Markdown konvertieren**

Laden Sie die Quelldatei mit der Klasse [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/) und rufen Sie anschließend die Methode [Presentation.save](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/) mit dem `Md`‑Wert aus der Aufzählung [SaveFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/saveformat/) auf.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.md", SaveFormat.Md);
} finally {
    presentation.dispose();
}
```

## **Markdown‑Flavor auswählen**

Die Methode [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/de/java/com.aspose.slides/markdownsaveoptions/) steuert die für die Ausgabe verwendete Markdown‑Spezifikation. Die Aufzählung [Flavor](https://reference.aspose.com/slides/de/java/com.aspose.slides/flavor/) enthält CommonMark, GitHub Flavored Markdown und weitere unterstützte Varianten.

Das folgende Beispiel exportiert eine Präsentation als CommonMark:

```java
import com.aspose.slides.Flavor;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setFlavor(Flavor.CommonMark);

    presentation.save("presentation.md", SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

## **Bilder mit dem Standard‑lokalen Speicherverhalten exportieren**

Die Klasse [MarkdownSaveOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/markdownsaveoptions/) bietet zwei Methoden zur Konfiguration lokal gespeicherter Bilder:

- [setBasePath](https://reference.aspose.com/slides/de/java/com.aspose.slides/markdownsaveoptions/) legt das Basisverzeichnis für das Markdown‑Dokument und seine Ressourcen fest.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/de/java/com.aspose.slides/markdownsaveoptions/) legt das Bildunterverzeichnis fest. Der Standardwert ist `Images`.

Das folgende Beispiel rendert visuelle Inhalte, schreibt Bilder nach `output/assets` und erzeugt relative Bildverweise im Markdown‑Dokument:

```java
import com.aspose.slides.MarkdownExportType;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path outputDirectory = Paths.get("output");
Files.createDirectories(outputDirectory);

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setExportType(MarkdownExportType.Visual);
    options.setBasePath(outputDirectory.toString());
    options.setImagesSaveFolderName("assets");

    Path markdownPath = outputDirectory.resolve("presentation.md");
    presentation.save(markdownPath.toString(), SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

Dieses Verhalten dient auch als Rückfall, wenn ein benutzerdefinierter Bild‑Speicher‑Handler `false` zurückgibt.

## **Bildspeicherung und Markdown‑Links anpassen**

Verwenden Sie die Methode [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/de/java/com.aspose.slides/markdownsaveoptions/), um einen Callback für nicht‑SVG‑Bitmap- und Metafile-Ressourcen zu registrieren, die beim Markdown‑Export erzeugt werden. Sein `MarkdownImageSavingHandler`‑Callback erhält das Objekt [IImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/iimage/), dessen [ImageFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/imageformat/)-Wert und den erzeugten Markdown‑Link als ein‑elementiges `String[]`‑Parameter. Speichern oder laden Sie das Bild im angegebenen Format hoch und ersetzen Sie `link[0]` durch die Referenz, die im Markdown‑Ausgabe erscheinen soll.

Ressourcen, die im SVG‑Format erzeugt werden, werden separat behandelt. Registrieren Sie einen Callback mit der Methode [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/de/java/com.aspose.slides/markdownsaveoptions/). Sein `MarkdownSvgImageSavingHandler`‑Callback erhält ein [ISvgImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/isvgimage/)-Objekt und den ein‑elementigen `String[] link`‑Parameter. Ein SVG besitzt kein `ImageFormat`‑Argument; schreiben oder laden Sie stattdessen die XML‑Daten über die Methode [ISvgImage.getSvgData](https://reference.aspose.com/slides/de/java/com.aspose.slides/isvgimage/) hoch. Je nach Exportmodus und visueller Gruppierung kann ein SVG in der Quellpräsentation gerastert oder mit anderem Inhalt kombiniert werden; die resultierende Nicht‑SVG‑Ressource wird dann an den Bild‑Speicher‑Callback übergeben. Registrieren Sie beide Callback‑Methoden, wenn jede exportierte visuelle Ressource eine benutzerdefinierte Verarbeitung benötigt.

Der Rückgabewert des Handlers bestimmt, wer das Bild verarbeitet:

- Gibt `true` zurück, nachdem der Handler das Bild gespeichert, hochgeladen, transformiert oder anderweitig verarbeitet und einen gültigen Wert in `link[0]` zugewiesen hat. Aspose.Slides schreibt diesen Wert in das Markdown‑Dokument und führt nicht das standardmäßige lokale Speichern aus.
- Gibt `false` zurück, damit Aspose.Slides das Bild lokal speichert und den Link gemäß den mit [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/de/java/com.aspose.slides/markdownsaveoptions/) und [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/de/java/com.aspose.slides/markdownsaveoptions/) festgelegten Werten erstellt.

{{% alert color="warning" title="Important" %}}
Ein Handler, der `true` zurückgibt, übernimmt die Verantwortung für das Bild. Gibt er `true` zurück, ohne einen gültigen, nicht leeren Link zuzuweisen, schlägt der Export mit einer `InvalidOperationException` fehl.
{{% /alert %}}

### **Bilder in ein CDN‑Origin‑Verzeichnis speichern und externe URLs verwenden**

Das folgende Beispiel behandelt `cdn-origin/presentations/quarterly-report` als ein gemountetes oder synchronisiertes CDN‑Origin‑Verzeichnis. Jeder Handler extrahiert den erzeugten Dateinamen, speichert das Bild in diesem benutzerdefinierten Verzeichnis und ersetzt den erzeugten lokalen Verweis durch eine öffentliche CDN‑URL. Das Beispiel führt selbst keinen Netzwerk‑Upload durch: Die URL wird erst gültig, nachdem das Verzeichnis als CDN‑Origin gemountet oder seine Dateien im CDN veröffentlicht wurden. Für Objektspeicher ersetzen Sie das Schreiben in das Dateisystem durch den Upload‑Vorgang des Storage‑SDKs und setzen `link[0]` erst nach erfolgreichem Upload.

```java
import com.aspose.slides.MarkdownExportType;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.IOException;
import java.io.UnsupportedEncodingException;
import java.net.URLEncoder;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.function.Function;

Path outputDirectory = Paths.get("output");
String publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
Path storageDirectory = Paths.get("cdn-origin", "presentations", "quarterly-report");
Files.createDirectories(outputDirectory);
Files.createDirectories(storageDirectory);

Function<String, String> getFileNameFromLink = generatedLink -> {
    String urlCompatibleLink = generatedLink.replace('\\', '/');
    return urlCompatibleLink.substring(urlCompatibleLink.lastIndexOf('/') + 1);
};
Function<String, String> buildPublicUrl = fileName -> {
    try {
        String encodedFileName = URLEncoder.encode(fileName, "UTF-8").replace("+", "%20");
        return publicBaseUrl + "/" + encodedFileName;
    } catch (UnsupportedEncodingException exception) {
        System.err.println("Could not encode the image file name: " + exception.getMessage());
        return null;
    }
};

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setExportType(MarkdownExportType.Visual);
    options.setBasePath(outputDirectory.toString());
    options.setImagesSaveFolderName("fallback-images");

    options.setImageSaving((image, format, link) -> {
        if (image.getWidth() < 128 || image.getHeight() < 128) {
            return false;
        }

        String fileName = getFileNameFromLink.apply(link[0]);
        String publicUrl = buildPublicUrl.apply(fileName);
        if (publicUrl == null) {
            return false;
        }
        Path storagePath = storageDirectory.resolve(fileName);
        image.save(storagePath.toString(), format);
        link[0] = publicUrl;
        return true;
    });

    options.setSvgImageSaving((svgImage, link) -> {
        String fileName = getFileNameFromLink.apply(link[0]);
        String publicUrl = buildPublicUrl.apply(fileName);
        if (publicUrl == null) {
            return false;
        }
        Path storagePath = storageDirectory.resolve(fileName);
        try {
            Files.write(storagePath, svgImage.getSvgData());
        } catch (IOException exception) {
            System.err.println("Could not save the SVG image: " + exception.getMessage());
            return false;
        }
        link[0] = publicUrl;
        return true;
    });

    Path markdownPath = outputDirectory.resolve("presentation.md");
    presentation.save(markdownPath.toString(), SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

Der Bitmap‑Handler gibt bewusst `false` für Bilder kleiner als 128 × 128 Pixel zurück, sodass Aspose.Slides diese Bilder nach `output/fallback-images` speichert und das Standardverhalten verwendet. Größere Bitmap‑ und Metafile‑Ressourcen sowie SVG‑Ressourcen werden vom benutzerdefinierten Code verarbeitet. Beispielsweise wird ein erzeugter lokaler Verweis wie `fallback-images/image1.png` zu `https://cdn.example.com/presentations/quarterly-report/image1.png`. Die Handler verwenden Betriebssystem‑Pfade nur beim Schreiben von Dateien; in Markdown geschriebene Links nutzen Vorwärtsschlitze und URL‑kodierte Dateinamen. Wenden Sie dieselbe Regel beim Erstellen relativer Links an: Verwenden Sie `/` und nicht den plattformspezifischen Verzeichnistrenner.

## **FAQ**

**Kann ein Handler sowohl Raster‑ als auch SVG‑Bilder verarbeiten?**

Nein. Verwenden Sie [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/de/java/com.aspose.slides/markdownsaveoptions/) für erzeugte Bitmap‑ und Metafile‑Ressourcen und [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/de/java/com.aspose.slides/markdownsaveoptions/) für als SVG ausgegebene Ressourcen. Ersterer liefert ein [IImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/iimage/)‑Objekt und einen [ImageFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/imageformat/)‑Wert; letzterer liefert ein [ISvgImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/isvgimage/)‑Objekt, dessen SVG‑Daten über [ISvgImage.getSvgData](https://reference.aspose.com/slides/de/java/com.aspose.slides/isvgimage/) gelesen werden können. Ein Quell‑SVG, das beim Export gerastert wird, wird stattdessen vom Bild‑Speicher‑Callback verarbeitet.

**Was passiert, wenn ein Bild‑Speicher‑Handler `false` zurückgibt?**

Aspose.Slides verwendet sein standardmäßiges lokales Speicherverhalten. Der Bildspeicherort und der erzeugte Verweis werden durch die mit [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/de/java/com.aspose.slides/markdownsaveoptions/) und [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/de/java/com.aspose.slides/markdownsaveoptions/) festgelegten Werte gesteuert.

**Kann ein Handler eine URL bereitstellen, ohne das Bild lokal zu speichern?**

Ja. Der Handler kann das Bild in einen Objektspeicher hochladen oder an einen anderen Dienst weitergeben, die resultierende URL in `link[0]` eintragen und `true` zurückgeben. Der Handler muss die Verarbeitung selbst abschließen; die Rückgabe von `true` verhindert das standardmäßige lokale Speichern.

**Warum wirft der Markdown‑Export eine `InvalidOperationException` von einem Handler?**

Diese Ausnahme wird ausgelöst, wenn der Handler `true` zurückgibt, aber keinen gültigen Link bereitstellt. Setzen Sie den relativen Pfad oder die externe URL, die in das Markdown geschrieben werden soll, bevor Sie `true` zurückgeben.

**Welchen Pfadtrennzeichen sollten Bild‑Links verwenden?**

Verwenden Sie Vorwärtsschlitze (`/`) in Markdown‑Links und URLs. `Path.resolve` nur für Dateisystem‑Pfade nutzen und anschließend den Markdown‑Verweis separat erstellen oder normalisieren.

**Werden Hyperlinks beim Markdown‑Export erhalten?**

Ja. Text‑[Hyperlinks](/slides/de/java/manage-hyperlinks/) werden als Standard‑Markdown‑Links erhalten. Folien‑[Übergänge](/slides/de/java/slide-transition/) und -[Animationen](/slides/de/java/powerpoint-animation/) werden nicht konvertiert.

**Können Präsentationen parallel in Markdown konvertiert werden?**

Sie können verschiedene Präsentationsdateien parallel verarbeiten, sollten jedoch dieselbe [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Instanz nicht zwischen Threads teilen. Befolgen Sie die [Multithreading‑Richtlinien](/slides/de/java/multithreading/) und verwenden Sie für jede Datei eine separate Instanz.