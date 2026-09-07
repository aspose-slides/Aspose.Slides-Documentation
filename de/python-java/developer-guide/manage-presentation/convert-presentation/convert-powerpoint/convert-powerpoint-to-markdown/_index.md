---
title: PowerPoint-Präsentationen in Markdown in Python via Java konvertieren
linktitle: PowerPoint zu Markdown
type: docs
weight: 140
url: /de/python-java/convert-powerpoint-to-markdown/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folien konvertieren
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
- Python
- Java
- Aspose.Slides
description: "Konvertieren Sie PPT- und PPTX-Präsentationen in Markdown in Python via Java und steuern Sie, wo exportierte Bitmap-, Metafile- und SVG-Bilder gespeichert und referenziert werden."
---
## **Übersicht**

Aspose.Slides for Python via Java kann PPT- und PPTX‑Präsentationen in Markdown für Dokumentation, statische Websites, Content‑Migration und Versions‑Kontroll‑Workflows konvertieren. Sie können einen Markdown‑Flavor wählen, steuern, wie Folgeninhalt gerendert wird, und festlegen, wo exportierte Bilder gespeichert werden und wie das erzeugte Markdown darauf verweist.

Standardmäßig erzeugt der Markdown‑Export nur Text. Um visuelle Inhalte zu exportieren, setzen Sie den Exporttyp mit der [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/de/python-java/aspose.slides/markdownsaveoptions/#setExportType)‑Methode auf den Wert `Sequential` oder `Visual` aus der Aufzählung [MarkdownExportType](https://reference.aspose.com/slides/de/python-java/aspose.slides/markdownexporttype/). `Sequential` rendert Folienelemente einzeln und in Reihenfolge, während `Visual` gruppierte Elemente zusammenhält, um deren visuelle Beziehung zu bewahren. Der Wert `TextOnly` erzeugt keine Bildressourcen, sodass die Bild‑Speicher‑Callbacks in diesem Modus nicht aufgerufen werden.

## **Präsentation in Markdown konvertieren**

Laden Sie die Quelldatei mit der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse und rufen Sie anschließend die [Presentation.save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save)‑Methode mit dem Wert `Md` aus der Aufzählung [SaveFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/saveformat/) auf.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.md", SaveFormat.Md)
finally:
    presentation.dispose()
```

Jedes Beispiel liest `presentation.pptx` aus dem aktuellen Arbeitsverzeichnis. Installieren Sie Aspose.Slides for Python via Java und eine kompatible Java‑Runtime, bevor Sie die Beispiele ausführen. Starten Sie die JVM einmal pro Python‑Prozess.

## **Einen Markdown‑Flavor wählen**

Die Methode [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/de/python-java/aspose.slides/markdownsaveoptions/#setFlavor) steuert die für die Ausgabe verwendete Markdown‑Spezifikation. Die Aufzählung [Flavor](https://reference.aspose.com/slides/de/python-java/aspose.slides/flavor/) enthält CommonMark, GitHub Flavored Markdown und andere unterstützte Varianten.

Das folgende Beispiel exportiert eine Präsentation als CommonMark:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Flavor, MarkdownSaveOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setFlavor(Flavor.CommonMark)

    presentation.save("presentation.md", SaveFormat.Md, options)
finally:
    presentation.dispose()
```

## **Bilder mit dem Standard‑Lokalspeicher‑Verhalten exportieren**

Die Klasse [MarkdownSaveOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/markdownsaveoptions/) bietet zwei Methoden zur Konfiguration lokal gespeicherter Bilder:

- [setBasePath](https://reference.aspose.com/slides/de/python-java/aspose.slides/markdownsaveoptions/#setBasePath) legt das Basisverzeichnis für das Markdown‑Dokument und seine Ressourcen fest.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/de/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName) legt das Bildunterverzeichnis fest. Der Standardwert ist `Images`.

Das folgende Beispiel rendert visuelle Inhalte, schreibt Bilder nach `output/assets` und erzeugt relative Bildverweise im Markdown‑Dokument:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import MarkdownExportType, MarkdownSaveOptions, Presentation, SaveFormat

output_directory = Path("output")
output_directory.mkdir(parents=True, exist_ok=True)

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setExportType(MarkdownExportType.Visual)
    options.setBasePath(str(output_directory))
    options.setImagesSaveFolderName("assets")

    markdown_path = output_directory / "presentation.md"
    presentation.save(str(markdown_path), SaveFormat.Md, options)
finally:
    presentation.dispose()
```

Dieses Verhalten dient auch als Rückgriff, wenn ein benutzerdefinierter Bild‑Speicher‑Handler `False` zurückgibt.

## **Bildspeicherung und Markdown‑Links anpassen**

Verwenden Sie die Methode [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/de/python-java/aspose.slides/markdownsaveoptions/) , um einen Callback für nicht‑SVG‑Bitmap‑ und Metafile‑Ressourcen zu registrieren, die beim Markdown‑Export erzeugt werden. Der Callback `MarkdownImageSavingHandler` erhält das Bildobjekt, dessen [ImageFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/imageformat/)‑Wert und den erzeugten Markdown‑Link als ein‑elementiges `String[]`‑Parameter. Speichern oder laden Sie das Bild im angegebenen Format hoch und ersetzen Sie `link[0]` durch den Verweis, der im Markdown‑Ausgabe erscheinen soll.

Ressourcen, die im SVG‑Format erzeugt werden, werden separat behandelt. Registrieren Sie einen Callback mit der Methode [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/de/python-java/aspose.slides/markdownsaveoptions/). Der Callback `MarkdownSvgImageSavingHandler` erhält ein [SvgImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/svgimage/)‑Objekt und den ein‑elementigen `String[] link`‑Parameter. Ein SVG hat keinen `ImageFormat`‑Parameter; schreiben oder laden Sie stattdessen dessen XML‑Daten über die Methode [SvgImage.getSvgData](https://reference.aspose.com/slides/de/python-java/aspose.slides/svgimage/#getSvgData). Abhängig vom Exportmodus und der visuellen Gruppierung kann ein SVG in der Quellpräsentation gerastert oder mit anderem Inhalt kombiniert werden; die resultierende Nicht‑SVG‑Ressource wird dann an den Bild‑Speicher‑Callback übergeben. Registrieren Sie beide Callbacks, wenn jede exportierte visuelle Ressource eine individuelle Verarbeitung erfordert.

Der Rückgabewert des Handlers bestimmt, wer das Bild verarbeitet:

- Rückgabe `True`, nachdem der Handler das Bild gespeichert, hochgeladen, transformiert oder anderweitig verarbeitet und einen gültigen Wert in `link[0]` gesetzt hat. Aspose.Slides schreibt diesen Wert in das Markdown‑Dokument und führt nicht das standardmäßige lokale Speichern aus.
- Rückgabe `False`, um Aspose.Slides das Bild lokal speichern und den Link gemäß den Werten von [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/de/python-java/aspose.slides/markdownsaveoptions/#setBasePath) und [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/de/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName) zu erzeugen.

{{% alert color="danger" title="Wichtig" %}}

Ein Handler, der `True` zurückgibt, übernimmt die Verantwortung für das Bild. Gibt er `True` zurück, ohne einen gültigen, nicht‑leeren Link zuzuweisen, schlägt der Export mit einer `InvalidOperationException` fehl.

{{% /alert %}}

In Python registrieren Sie diese Callbacks mit `jpype.JProxy`, indem Sie das Java‑Callback‑Interface über dessen `invoke`‑Methode implementieren. Das Argument `link` ist ein veränderbares Java‑String‑Array: konvertieren Sie `link[0]` vor der Verarbeitung in einen Python‑String, ändern Sie die URL und weisen Sie das Ergebnis wieder `link[0]` zu.

### **Bilder in ein CDN‑Origin‑Verzeichnis speichern und externe URLs verwenden**

Das folgende Beispiel behandelt `cdn-origin/presentations/quarterly-report` als gemountetes oder synchronisiertes CDN‑Origin‑Verzeichnis. Jeder Handler extrahiert den erzeugten Dateinamen, speichert das Bild in diesem benutzerdefinierten Verzeichnis und ersetzt den lokalen Verweis durch eine öffentliche CDN‑URL. Das Beispiel selbst führt keinen Netzwerk‑Upload durch: Die URL wird erst gültig, wenn das Verzeichnis als CDN‑Origin gemountet oder die Dateien ins CDN veröffentlicht werden. Für Object‑Storage ersetzen Sie den Datei‑System‑Write durch den Upload‑Aufruf des Storage‑SDKs und setzen `link[0]` erst nach erfolgreichem Upload.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from urllib.parse import quote
from asposeslides.api import MarkdownExportType, MarkdownSaveOptions, Presentation, SaveFormat

output_directory = Path("output")
public_base_url = "https://cdn.example.com/presentations/quarterly-report"
storage_directory = Path("cdn-origin", "presentations", "quarterly-report")
output_directory.mkdir(parents=True, exist_ok=True)
storage_directory.mkdir(parents=True, exist_ok=True)

def get_file_name(generated_link):
    normalized_link = str(generated_link).replace("\\", "/")
    return normalized_link.rsplit("/", 1)[-1]

def save_image(image, image_format, link):
    if image.getWidth() < 128 or image.getHeight() < 128:
        return False

    file_name = get_file_name(link[0])
    storage_path = storage_directory / file_name
    image.save(str(storage_path), image_format)
    encoded_file_name = quote(file_name, safe="")
    link[0] = public_base_url + "/" + encoded_file_name
    return True

def save_svg(svg_image, link):
    file_name = get_file_name(link[0])
    storage_path = storage_directory / file_name
    svg_data = svg_image.getSvgData()
    try:
        storage_path.write_bytes(bytes(svg_data))
    except OSError as error:
        print(f"Could not save the SVG image: {error}")
        return False

    encoded_file_name = quote(file_name, safe="")
    link[0] = public_base_url + "/" + encoded_file_name
    return True

image_handler = jpype.JProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler", dict(invoke=save_image))
svg_handler = jpype.JProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler", dict(invoke=save_svg))

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setExportType(MarkdownExportType.Visual)
    options.setBasePath(str(output_directory))
    options.setImagesSaveFolderName("fallback-images")
    options.setImageSaving(image_handler)
    options.setSvgImageSaving(svg_handler)

    markdown_path = output_directory / "presentation.md"
    presentation.save(str(markdown_path), SaveFormat.Md, options)
finally:
    presentation.dispose()
```

Der Bitmap‑Handler gibt bewusst `False` für Bilder kleiner als 128 × 128 Pixel zurück, sodass Aspose.Slides diese Bilder nach `output/fallback-images` mit dem Standardverhalten speichert. Größere Bitmap‑ und Metafile‑Ressourcen sowie SVG‑Ressourcen werden vom benutzerdefinierten Code verarbeitet. Beispielsweise wird ein lokaler Verweis wie `fallback-images/image1.png` zu `https://cdn.example.com/presentations/quarterly-report/image1.png`. Die Handler verwenden Betriebssystem‑Pfade nur beim Schreiben von Dateien; Links im Markdown nutzen Vorwärtsschrägstriche und URL‑kodierte Dateinamen. Wenden Sie dieselbe Regel beim Erzeugen relativer Links an: Verwenden Sie `/`, nicht das plattformspezifische Verzeichnis‑Trennzeichen.

## **FAQ**

**Kann ein Handler sowohl Raster‑ als auch SVG‑Bilder verarbeiten?**

Nein. Verwenden Sie [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/de/python-java/aspose.slides/markdownsaveoptions/) für erzeugte Bitmap‑ und Metafile‑Ressourcen und [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/de/python-java/aspose.slides/markdownsaveoptions/) für als SVG erzeugte Ressourcen. Ersterer liefert ein Bildobjekt und einen [ImageFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/imageformat/)‑Wert; letzterer liefert ein [SvgImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/svgimage/)‑Objekt, dessen SVG‑Daten via [SvgImage.getSvgData](https://reference.aspose.com/slides/de/python-java/aspose.slides/svgimage/#getSvgData) gelesen werden können. Ein Quell‑SVG, das während des Exports gerastert wird, wird vom Bild‑Speicher‑Callback verarbeitet.

**Was passiert, wenn ein Bild‑Speicher‑Handler `False` zurückgibt?**

Aspose.Slides verwendet das standardmäßige lokale Speicherverhalten. Standort und erzeugter Verweis des Bildes werden durch die Werte gesteuert, die mit [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/de/python-java/aspose.slides/markdownsaveoptions/#setBasePath) und [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/de/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName) gesetzt wurden.

**Kann ein Handler eine URL bereitstellen, ohne das Bild lokal zu speichern?**

Ja. Der Handler kann das Bild in einen Object‑Storage hochladen oder an einen anderen Dienst weitergeben, die resultierende URL in `link[0]` setzen und `True` zurückgeben. Der Handler muss die Verarbeitung selbst abschließen; die Rückgabe von `True` verhindert das Standard‑lokale Speichern.

**Warum wirft der Markdown‑Export eine `InvalidOperationException` von einem Handler?**

Diese Ausnahme tritt auf, wenn der Handler `True` zurückgibt, aber keinen gültigen Link bereitstellt. Setzen Sie den relativen Pfad oder die externe URL, die in das Markdown geschrieben werden soll, bevor Sie `True` zurückgeben.

**Welches Pfad‑Trennzeichen sollten Bild‑Links verwenden?**

Verwenden Sie Vorwärtsschrägstriche in Markdown‑Links und URLs. Nutzen Sie `pathlib.Path` nur für Dateisystem‑Pfade und erstellen bzw. normalisieren Sie den Markdown‑Verweis separat.

**Werden Hyperlinks beim Markdown‑Export beibehalten?**

Ja. Text‑[Hyperlinks](/slides/de/python-java/manage-hyperlinks/) werden als reguläre Markdown‑Links erhalten. Folien‑[Übergänge](/slides/de/python-java/slide-transition/) und -[Animationen](/slides/de/python-java/powerpoint-animation/) werden nicht konvertiert.

**Können Präsentationen parallel in Markdown konvertiert werden?**

Sie können verschiedene Präsentationsdateien parallel verarbeiten, sollten jedoch nicht dieselbe [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Instanz zwischen Threads teilen. Befolgen Sie die [Multithreading‑Richtlinien](/slides/de/python-java/multithreading/) und verwenden Sie für jede Datei eine separate Instanz.