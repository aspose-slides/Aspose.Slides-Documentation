---
title: PowerPoint-Präsentationen in Markdown konvertieren in JavaScript
linktitle: PowerPoint zu Markdown
type: docs
weight: 140
url: /de/nodejs-java/convert-powerpoint-to-markdown/
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
- Markdown-Bildexport
- CDN Bildlinks
- PowerPoint
- Präsentation
- Markdown
- Node.js
- JavaScript
- Aspose.Slides
description: "Konvertieren Sie PPT- und PPTX‑Präsentationen in Markdown in JavaScript und steuern Sie, wo exportierte Bitmap‑, Metadatei‑ und SVG‑Bilder gespeichert und referenziert werden."
---
## **Übersicht**

Aspose.Slides für Node.js über Java kann PPT- und PPTX‑Präsentationen in Markdown für Dokumentation, statische Websites, Inhaltsmigration und Versionskontroll‑Workflows konvertieren. Sie können einen Markdown‑Flavor wählen, steuern, wie Folieninhalt gerendert wird, und entscheiden, wo exportierte Bilder gespeichert werden und wie das erzeugte Markdown auf sie verweist.

Standardmäßig verwendet der Markdown‑Export eine rein textbasierte Ausgabe. Um visuelle Inhalte zu exportieren, setzen Sie den Exporttyp mit der [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/markdownsaveoptions/)‑Methode auf den `Sequential`‑ oder `Visual`‑Wert aus der Aufzählung [MarkdownExportType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/markdownexporttype/). `Sequential` rendert Folienelemente einzeln und in Reihenfolge, während `Visual` gruppierte Elemente zusammenhält, um deren visuelle Beziehung zu bewahren. Der Wert `TextOnly` gibt keine Bildressourcen aus, sodass die Bild‑Speicher‑Callbacks in diesem Modus nicht aufgerufen werden.

## **Präsentation in Markdown konvertieren**

Laden Sie die Quelldatei mit der [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)‑Klasse und rufen Sie dann die [Presentation.save](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)‑Methode mit dem `Md`‑Wert aus der Aufzählung [SaveFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/saveformat/) auf.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.md", aspose.slides.SaveFormat.Md);
} finally {
    presentation.dispose();
}
```

## **Markdown‑Flavor auswählen**

Die Methode [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/markdownsaveoptions/) steuert die für die Ausgabe verwendete Markdown‑Spezifikation. Die Aufzählung [Flavor](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/flavor/) enthält CommonMark, GitHub Flavored Markdown und weitere unterstützte Varianten.

Das folgende Beispiel exportiert eine Präsentation als CommonMark:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setFlavor(aspose.slides.Flavor.CommonMark);

    presentation.save("presentation.md", aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

## **Bilder mit dem Standard‑Verhalten für lokales Speichern exportieren**

Die Klasse [MarkdownSaveOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/markdownsaveoptions/) bietet zwei Methoden zur Konfiguration lokal gespeicherter Bilder:

- [setBasePath](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/markdownsaveoptions/) legt das Basisverzeichnis für das Markdown‑Dokument und dessen Ressourcen fest.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/markdownsaveoptions/) legt das Unterverzeichnis für Bilder fest. Der Standardwert ist `Images`.

Das folgende Beispiel rendert visuelle Inhalte, schreibt Bilder nach `output/assets` und erzeugt relative Bildreferenzen im Markdown‑Dokument:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");

const outputDirectory = "output";
fs.mkdirSync(outputDirectory, { recursive: true });

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setExportType(aspose.slides.MarkdownExportType.Visual);
    options.setBasePath(outputDirectory);
    options.setImagesSaveFolderName("assets");

    const markdownPath = path.join(outputDirectory, "presentation.md");
    presentation.save(markdownPath, aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

Dieses Verhalten dient ebenfalls als Rückfallback, wenn ein benutzerdefinierter Bild‑Speicher‑Handler `false` zurückgibt.

## **Bildspeicherung und Markdown‑Links anpassen**

Verwenden Sie die Methode [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/markdownsaveoptions/), um einen Callback für nicht‑SVG‑Bitmap‑ und Metadatei‑Ressourcen zu registrieren, die beim Markdown‑Export erzeugt werden. Sein `MarkdownImageSavingHandler`‑Callback erhält das [IImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/iimage/)‑Objekt, dessen [ImageFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/imageformat/)-Wert und den erzeugten Markdown‑Link als ein‑elementiges String‑Array. Speichern oder laden Sie das Bild mit dem angegebenen Format hoch und ersetzen Sie `link[0]` durch die Referenz, die im Markdown‑Ausgabe erscheinen soll.

Ressourcen, die im SVG‑Format erzeugt werden, werden separat behandelt. Registrieren Sie einen Callback mit der Methode [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/markdownsaveoptions/). Sein `MarkdownSvgImageSavingHandler`‑Callback erhält ein `ISvgImage`‑Objekt und das ein‑elementige `link`‑Array. Ein SVG hat kein `ImageFormat`‑Argument; schreiben oder laden Sie stattdessen die XML‑Daten über die Methode `ISvgImage.getSvgData` hoch. Je nach Exportmodus und visueller Gruppierung kann ein SVG in der Quell‑Präsentation rasterisiert oder mit anderem Inhalt kombiniert werden; die resultierende Nicht‑SVG‑Ressource wird dann an den Bild‑Speicher‑Callback übergeben. Registrieren Sie beide Callbacks, wenn jede exportierte visuelle Ressource eine individuelle Verarbeitung erfordert.

In Node.js erstellen Sie Implementierungen dieser Callback‑Schnittstellen mit `java.newProxy`.

Der Rückgabewert des Handlers bestimmt, wer das Bild verarbeitet:

- Geben Sie `true` zurück, nachdem der Handler das Bild gespeichert, hochgeladen, transformiert oder anderweitig verarbeitet und einen gültigen Wert für `link[0]` zugewiesen hat. Aspose.Slides schreibt diesen Wert in das Markdown‑Dokument und führt nicht den standardmäßigen lokalen Speicher durch.
- Geben Sie `false` zurück, damit Aspose.Slides das Bild lokal speichert und den Link anhand der mit [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/markdownsaveoptions/) und [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/markdownsaveoptions/) festgelegten Werte erzeugt.

{{% alert color="warning" title="Important" %}}
Ein Handler, der `true` zurückgibt, übernimmt die Verantwortung für das Bild. Gibt er `true` zurück, ohne einen gültigen, nicht leeren Link zuzuweisen, schlägt der Export mit einer `InvalidOperationException` fehl.
{{% /alert %}}

### **Bilder in ein CDN‑Ursprungsverzeichnis speichern und externe URLs verwenden**

Das folgende Beispiel behandelt `cdn-origin/presentations/quarterly-report` als ein gemountetes oder synchronisiertes CDN‑Ursprungsverzeichnis. Jeder Handler extrahiert den erzeugten Dateinamen, speichert das Bild in diesem benutzerdefinierten Verzeichnis und ersetzt die erzeugte lokale Referenz durch eine öffentliche CDN‑URL. Das Beispiel führt keinen Netzwerk‑Upload durch: Die URL wird erst nach dem Mounten des Verzeichnisses als CDN‑Ursprung oder nach der Veröffentlichung der Dateien im CDN gültig. Für Objektspeicher ersetzen Sie das Schreiben auf das Dateisystem durch den Upload‑Vorgang des Storage‑SDKs und weisen `link[0]` erst nach erfolgreichem Upload zu.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");
const path = require("path");

const outputDirectory = "output";
const publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
const storageDirectory = path.join("cdn-origin", "presentations", "quarterly-report");
fs.mkdirSync(outputDirectory, { recursive: true });
fs.mkdirSync(storageDirectory, { recursive: true });

const getFileNameFromLink = generatedLink => {
    const urlCompatibleLink = String(generatedLink).replace(/\\/g, "/");
    return path.posix.basename(urlCompatibleLink);
};
const buildPublicUrl = fileName => publicBaseUrl + "/" + encodeURIComponent(fileName);

const imageSavingHandler = java.newProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler", {
    invoke: function(image, format, link) {
        if (image.getWidth() < 128 || image.getHeight() < 128) {
            return false;
        }

        const fileName = getFileNameFromLink(link[0]);
        const storagePath = path.join(storageDirectory, fileName);
        image.save(storagePath, format);
        link[0] = buildPublicUrl(fileName);
        return true;
    }
});

const svgImageSavingHandler = java.newProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler", {
    invoke: function(svgImage, link) {
        const fileName = getFileNameFromLink(link[0]);
        const storagePath = path.join(storageDirectory, fileName);
        fs.writeFileSync(storagePath, svgImage.getSvgData());
        link[0] = buildPublicUrl(fileName);
        return true;
    }
});

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setExportType(aspose.slides.MarkdownExportType.Visual);
    options.setBasePath(outputDirectory);
    options.setImagesSaveFolderName("fallback-images");
    options.setImageSaving(imageSavingHandler);
    options.setSvgImageSaving(svgImageSavingHandler);

    const markdownPath = path.join(outputDirectory, "presentation.md");
    presentation.save(markdownPath, aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

Der Bitmap‑Handler gibt bewusst `false` für Bilder zurück, die kleiner als 128 × 128 Pixel sind, sodass Aspose.Slides diese Bilder nach `output/fallback-images` gemäß dem Standardverhalten speichert. Größere Bitmap‑ und Metadatei‑Ressourcen sowie SVG‑Ressourcen werden vom benutzerdefinierten Code verarbeitet. Zum Beispiel wird eine erzeugte lokale Referenz wie `fallback-images/image1.png` zu `https://cdn.example.com/presentations/quarterly-report/image1.png`. Die Handler verwenden Betriebssystem‑Pfadnamen nur beim Schreiben von Dateien; Links im Markdown nutzen Vorwärtsschrägstriche und URL‑kodierte Dateinamen. Wenden Sie dieselbe Regel beim Erstellen relativer Links an: Verwenden Sie `/` und nicht den plattformspezifischen Verzeichnistrenner.

## **FAQ**

**Kann ein Handler sowohl Raster‑ als auch SVG‑Bilder verarbeiten?**

Nein. Verwenden Sie [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/markdownsaveoptions/) für erzeugte Bitmap‑ und Metadatei‑Ressourcen und [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/markdownsaveoptions/) für als SVG ausgegebene Ressourcen. Ersterer liefert ein [IImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/iimage/)‑Objekt und einen [ImageFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/imageformat/)-Wert; letzterer liefert ein `ISvgImage`‑Objekt, dessen SVG‑Daten mit `ISvgImage.getSvgData` gelesen werden können. Ein Quell‑SVG, das während des Exports rasterisiert wird, wird stattdessen vom Bild‑Speicher‑Callback verarbeitet.

**Was passiert, wenn ein Bild‑Speicher‑Handler `false` zurückgibt?**

Aspose.Slides verwendet sein standardmäßiges lokales Speicherverhalten. Der Bildort und die erzeugte Referenz werden durch die mit [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/markdownsaveoptions/) und [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/markdownsaveoptions/) festgelegten Werte gesteuert.

**Kann ein Handler eine URL bereitstellen, ohne das Bild lokal zu speichern?**

Ja. Der Handler kann das Bild in den Objektspeicher hochladen oder an einen anderen Dienst weitergeben, die resultierende URL `link[0]` zuweisen und `true` zurückgeben. Der Handler muss die Verarbeitung selbst abschließen; das Zurückgeben von `true` verhindert das standardmäßige lokale Speichern.

**Warum wirft der Markdown‑Export eine `InvalidOperationException` von einem Handler?**

Diese Ausnahme tritt auf, wenn der Handler `true` zurückgibt, aber keinen gültigen Link bereitstellt. Weisen Sie den relativen Pfad oder die externe URL, die in das Markdown geschrieben werden soll, zu, bevor Sie `true` zurückgeben.

**Welches Pfadtrennzeichen sollten Bild‑Links verwenden?**

Verwenden Sie Vorwärtsschrägstriche in Markdown‑Links und URLs. Nutzen Sie `path.join` nur für Dateisystem‑Pfade und erstellen bzw. normalisieren Sie die Markdown‑Referenz separat.

**Werden Hyperlinks beim Markdown‑Export beibehalten?**

Ja. Text-[Hyperlinks](/slides/de/nodejs-java/manage-hyperlinks/) werden als Standard‑Markdown‑Links beibehalten. Folien-[Übergänge](/slides/de/nodejs-java/slide-transition/) und -[Animationen](/slides/de/nodejs-java/powerpoint-animation/) werden nicht konvertiert.

**Können Präsentationen parallel in Markdown konvertiert werden?**

Sie können verschiedene Präsentationsdateien parallel verarbeiten, dürfen jedoch dieselbe [Presentation]‑Instanz nicht zwischen Threads teilen. Befolgen Sie die [Multithreading‑Richtlinien](/slides/de/nodejs-java/multithreading/) und verwenden Sie für jede Datei eine separate Instanz.