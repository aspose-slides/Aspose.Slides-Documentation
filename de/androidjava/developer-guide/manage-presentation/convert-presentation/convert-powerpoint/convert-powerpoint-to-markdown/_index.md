---
title: PowerPoint-Präsentationen auf Android in Markdown konvertieren
linktitle: PowerPoint zu Markdown
type: docs
weight: 140
url: /de/androidjava/convert-powerpoint-to-markdown/
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
- Android
- Java
- Aspose.Slides
description: "Konvertieren Sie PPT- und PPTX‑Präsentationen auf Android mittels Java in Markdown und steuern Sie, wo exportierte Bitmap‑, Metafile‑ und SVG‑Bilder gespeichert und referenziert werden."
---
## **Übersicht**

Aspose.Slides für Android via Java kann PPT- und PPTX‑Präsentationen in Markdown für Dokumentation, statische Websites, Content‑Migration und Versionskontroll‑Workflows konvertieren. Sie können einen Markdown‑Flavor auswählen, steuern, wie Folieninhalt gerendert wird, und festlegen, wo exportierte Bilder gespeichert werden und wie das erzeugte Markdown darauf verweist.

Standardmäßig verwendet der Markdown‑Export eine reine Textausgabe. Um visuelle Inhalte zu exportieren, setzen Sie den Exporttyp mit der [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/markdownsaveoptions/)‑Methode auf den Wert `Sequential` oder `Visual` aus der Aufzählung [MarkdownExportType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/markdownexporttype/). `Sequential` rendert Folienelemente einzeln und in Reihenfolge, während `Visual` gruppierte Elemente zusammenhält, um deren visuelle Beziehung zu bewahren. Der Wert `TextOnly` erzeugt keine Bildressourcen, sodass die Bild‑Speicher‑Callbacks in diesem Modus nicht aufgerufen werden.

## **Präsentation in Markdown konvertieren**

Laden Sie die Quelldatei mit der Klasse [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/) und rufen Sie anschließend die Methode [Presentation.save](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/) mit dem Wert `Md` aus der Aufzählung [SaveFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/saveformat/) auf.

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

Die Methode [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/markdownsaveoptions/) steuert die für die Ausgabe verwendete Markdown‑Spezifikation. Die Aufzählung [Flavor](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/flavor/) enthält CommonMark, GitHub Flavored Markdown und andere unterstützte Varianten.

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

Die Klasse [MarkdownSaveOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/markdownsaveoptions/) stellt zwei Methoden zur Konfiguration lokal gespeicherter Bilder bereit:

- [setBasePath](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/markdownsaveoptions/) gibt das Basisverzeichnis für das Markdown‑Dokument und dessen Ressourcen an.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/markdownsaveoptions/) gibt das Bildunterverzeichnis an. Der Standardwert ist `Images`.

Das folgende Beispiel rendert visuelle Inhalte, schreibt Bilder nach `output/assets` und erzeugt relative Bildreferenzen im Markdown‑Dokument:

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

Dieses Verhalten dient außerdem als Rückfallback, wenn ein benutzerdefineter Bild‑Speicher‑Handler `false` zurückgibt.

## **Bildspeicherung und Markdown‑Links anpassen**

Verwenden Sie die Methode [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/markdownsaveoptions/), um einen Callback für nicht‑SVG‑Bitmap‑ und Metafiledaten zu registrieren, die beim Markdown‑Export erzeugt werden. Sein `MarkdownImageSavingHandler`‑Callback erhält das [IImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iimage/)‑Objekt, dessen [ImageFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imageformat/)‑Wert und den erzeugten Markdown‑Link als ein‑elementiges `String[]`‑Parameter. Speichern oder laden Sie das Bild mit dem angegebenen Format hoch und ersetzen Sie `link[0]` durch die Referenz, die im Markdown‑Ausgabe erscheinen muss.

Ressourcen im SVG‑Format werden separat behandelt. Registrieren Sie einen Callback mit der Methode [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/markdownsaveoptions/). Sein `MarkdownSvgImageSavingHandler`‑Callback erhält ein [ISvgImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isvgimage/)‑Objekt und den ein‑elementigen `String[] link`‑Parameter. Ein SVG hat kein `ImageFormat`‑Argument; schreiben oder laden Sie stattdessen seine XML‑Daten über die Methode [ISvgImage.getSvgData](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isvgimage/). Abhängig vom Exportmodus und der visuellen Gruppierung kann ein SVG in der Quellpräsentation gerastert oder mit anderem Inhalt kombiniert werden; die resultierende Nicht‑SVG‑Ressource wird dann an den Bild‑Speicher‑Callback übergeben. Registrieren Sie beide Callbacks, wenn jede exportierte visuelle Ressource eine benutzerdefinierte Verarbeitung erfordert.

Der Rückgabewert des Handlers bestimmt, wer das Bild verarbeitet:

- Geben Sie `true` zurück, nachdem der Handler das Bild gespeichert, hochgeladen, transformiert oder anderweitig verarbeitet hat und einen gültigen Wert an `link[0]` zugewiesen wurde. Aspose.Slides schreibt diesen Wert in das Markdown‑Dokument und führt nicht das Standard‑lokale Speichern aus.
- Geben Sie `false` zurück, um Aspose.Slides das Bild lokal speichern zu lassen und den Link gemäß den Werten zu erzeugen, die mit [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/markdownsaveoptions/) und [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/markdownsaveoptions/) festgelegt wurden.

{{% alert color="warning" title="Wichtig" %}}
Ein Handler, der `true` zurückgibt, übernimmt die Verantwortung für das Bild. Gibt er `true` zurück, ohne einen gültigen, nicht leeren Link zuzuweisen, schlägt der Export mit einer `InvalidOperationException` fehl.
{{% /alert %}}

### **Bilder in ein CDN‑Ursprungsverzeichnis speichern und externe URLs verwenden**

Das folgende Beispiel behandelt `cdn-origin/presentations/quarterly-report` als ein eingehängtes oder synchronisiertes CDN‑Ursprungsverzeichnis. Jeder Handler extrahiert den generierten Dateinamen, speichert das Bild in diesem benutzerdefinierten Verzeichnis und ersetzt die erzeugte lokale Referenz durch eine öffentliche CDN‑URL. Das Beispiel führt selbst keinen Netzwerk‑Upload aus: Die URL wird erst gültig, nachdem das Verzeichnis als CDN‑Ursprung eingehängt oder seine Dateien im CDN veröffentlicht wurden. Für Object Storage ersetzen Sie das Schreiben ins Dateisystem durch den Upload‑Vorgang des Storage‑SDKs und setzen `link[0]` erst nach erfolgreichem Upload.

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

Der Bitmap‑Handler gibt bewusst `false` für Bilder kleiner als 128 × 128 Pixel zurück, sodass Aspose.Slides diese Bilder nach `output/fallback-images` gemäß dem Standardverhalten speichert. Größere Bitmap‑ und Metafile‑Ressourcen sowie SVG‑Ressourcen werden vom benutzerdefinierten Code verarbeitet. Beispiel: Eine erzeugte lokale Referenz wie `fallback-images/image1.png` wird zu `https://cdn.example.com/presentations/quarterly-report/image1.png`. Die Handler verwenden Betriebssystem‑Pfadangaben nur beim Schreiben von Dateien; Links, die in Markdown geschrieben werden, nutzen Vorwärtsschrägstriche und URL‑kodierte Dateinamen. Wenden Sie dieselbe Regel beim Erstellen relativer Links an: Verwenden Sie `/`, nicht den plattformspezifischen Verzeichnistrenner.

## **FAQ**

**Kann ein Handler sowohl Raster‑ als auch SVG‑Bilder verarbeiten?**

Nein. Verwenden Sie [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/markdownsaveoptions/) für erzeugte Bitmap‑ und Metafile‑Ressourcen und [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/markdownsaveoptions/) für als SVG erzeugte Ressourcen. Der erstere liefert ein [IImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iimage/)‑Objekt und einen [ImageFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imageformat/)‑Wert; der letztere liefert ein [ISvgImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isvgimage/)‑Objekt, dessen SVG‑Daten mit [ISvgImage.getSvgData](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isvgimage/) gelesen werden können. Ein Quell‑SVG, das während des Exports gerastert wird, wird stattdessen vom Bild‑Speicher‑Callback verarbeitet.

**Was passiert, wenn ein Bild‑Speicher‑Handler `false` zurückgibt?**

Aspose.Slides verwendet sein Standard‑lokales Speicherverhalten. Der Bildort und die erzeugte Referenz werden durch die Werte gesteuert, die mit [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/markdownsaveoptions/) und [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/markdownsaveoptions/) festgelegt wurden.

**Kann ein Handler eine URL bereitstellen, ohne das Bild lokal zu speichern?**

Ja. Der Handler kann das Bild in den Objektspeicher hochladen oder an einen anderen Dienst weitergeben, die resultierende URL `link[0]` zuweisen und `true` zurückgeben. Der Handler muss die Verarbeitung selbst abschließen; die Rückgabe von `true` verhindert das Standard‑lokale Speichern.

**Warum wirft der Markdown‑Export eine `InvalidOperationException` von einem Handler?**

Diese Ausnahme tritt auf, wenn der Handler `true` zurückgibt, aber keinen gültigen Link bereitstellt. Weisen Sie den relativen Pfad oder die externe URL, die in das Markdown geschrieben werden soll, zu, bevor Sie `true` zurückgeben.

**Welcher Pfadseparator sollte für Bild‑Links verwendet werden?**

Verwenden Sie Vorwärtsschrägstriche in Markdown‑Links und URLs. Verwenden Sie `Path.resolve` nur für Dateisystem‑Pfade und erzeugen bzw. normalisieren Sie die Markdown‑Referenz separat.

**Werden Hyperlinks beim Markdown‑Export beibehalten?**

Ja. Text[hyperlinks](/slides/de/androidjava/manage-hyperlinks/) werden als reguläre Markdown‑Links erhalten. Folien[transitions](/slides/de/androidjava/slide-transition/) und [animations](/slides/de/androidjava/powerpoint-animation/) werden nicht konvertiert.

**Kann man Präsentationen parallel in Markdown konvertieren?**

Sie können verschiedene Präsentationsdateien parallel verarbeiten, sollten jedoch nicht dieselbe [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/)‑Instanz zwischen Threads teilen. Befolgen Sie die [multithreading guidelines](/slides/de/androidjava/multithreading/) und verwenden Sie für jede Datei eine separate Instanz.