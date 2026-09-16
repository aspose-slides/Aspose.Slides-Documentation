---
title: Export von Präsentationen nach XAML mit Python
linktitle: Präsentation nach XAML
type: docs
weight: 30
url: /de/python-net/export-to-xaml/
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
- Python
- Aspose.Slides
description: "Konvertieren Sie PowerPoint- und OpenDocument‑Folien nach XAML mit Python unter Verwendung von Aspose.Slides – schnelle, office‑freie Lösung, die Ihr Layout unverändert lässt."
---
## **Übersicht**

Dieser Artikel erklärt, wie PowerPoint‑Präsentationen mit Aspose.Slides nach XAML exportiert werden. Er enthält eine kurze Einführung in XAML, zeigt, wie eine Präsentation mit den Standardeinstellungen nach XAML gespeichert wird, und demonstriert, wie der Export über [XamlOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides.export.xaml/xamloptions/) angepasst werden kann, einschließlich des Exports ausgeblendeter Folien. Der Artikel beantwortet außerdem einige häufige Fragen zu Ersatzschriftarten, XAML‑Stack‑Kompatibilität und dem Verhalten beim Export ausgeblendeter Folien.

## **Über XAML**

XAML ist eine XML‑basierte Auszeichnungssprache, die zur Beschreibung von Benutzeroberflächen in Frameworks wie WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) und Xamarin.Forms verwendet wird.

Sie können mit XAML‑Dateien in einem visuellen Designer arbeiten oder die Auszeichnung direkt schreiben und bearbeiten.

## **Präsentationen mit Standardeinstellungen nach XAML exportieren**

Das folgende Python‑Beispiel zeigt, wie eine Präsentation mit den Standardeinstellungen nach XAML exportiert wird:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    xaml_options = slides.export.xaml.XamlOptions()
    presentation.save(xaml_options)
```

Standardmäßig werden die exportierten Folien in einem Unterordner `pres` des aktuellen Arbeitsverzeichnisses des Prozesses gespeichert, wie von [os.getcwd](https://docs.python.org/3/library/os.html#os.getcwd) zurückgegeben. Der Ordner wird automatisch erstellt, und alle erforderlichen Bilder werden dort ebenfalls abgelegt.

Der Ausgabeverzeichnisname wird aus dem Namen der Quelldatei ohne Erweiterung genommen. Für `pres.pptx` heißen die Ausgabedateien `pres/Slide_1.xaml`, `pres/Slide_2.xaml` usw. Auch wenn Sie einen absoluten Pfad zur Eingabedatei übergeben, wird der Ausgabepfad relativ zum aktuellen Arbeitsverzeichnis erzeugt und nicht neben der Eingabedatei platziert.

## **Präsentationen mit benutzerdefinierten Optionen nach XAML exportieren**

Verwenden Sie die Klasse [XamlOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides.export.xaml/xamloptions/), um zu steuern, wie Aspose.Slides eine Präsentation nach XAML exportiert.

Um ausgeblendete Folien in die XAML‑Ausgabe einzuschließen, setzen Sie die Eigenschaft [export_hidden_slides](https://reference.aspose.com/slides/de/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) auf `True`, wie im folgenden Python‑Beispiel gezeigt:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    xaml_options = slides.export.xaml.XamlOptions()
    xaml_options.export_hidden_slides = True
    presentation.save(xaml_options)
```

## **Alle erzeugten XAML‑Artefakte erfassen**

Ein XAML‑Export kann ein XAML‑Dokument für jede exportierte Folie sowie separate Bilder und unterstützende Ressourcen erzeugen. Bewahren Sie alle diese Dateien beim Speichern oder Übertragen eines Exports auf.

Die nachstehenden Beispiele verwenden den Standard‑Dateisystem‑Saver in einem temporären Verzeichnis und sammeln anschließend die erzeugten Dateien.

### **Den Export‑Lebenszyklus verstehen**

- Starten Sie den Export mit der XAML‑spezifischen Überladung von [Presentation.save](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/save/), die XAML‑Optionen akzeptiert. Lesen Sie die erzeugten Dateien erst, nachdem der Aufruf erfolgreich zurückgekehrt ist.
- Bewahren Sie den relativen Pfad jedes Artefakts, da XAML Ressourcen über relative Pfade referenzieren kann.
- Lesen Sie Artefakte als Bytes. Bilder und andere binäre Ressourcen dürfen nicht als Text dekodiert werden.
- Melden Sie den Gesamterfolg erst, nachdem das Sammeln und etwaige nachfolgende Speicheroperationen abgeschlossen sind. Lassen Sie Speicherfehler an den Aufrufer weitergeben und bereinigen Sie eine teilweise Ausgabe, falls die Persistierung fehlschlägt.

[XamlOptions.export_hidden_slides](https://reference.aspose.com/slides/de/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) ist standardmäßig `False` und schließt XAML‑Dokumente ausgeblendeter Folien aus. Wird es auf `True` gesetzt, werden diese sowie alle für ihren Export erforderlichen Ressourcen einbezogen. Die Anzahl der Ressourcen hängt von der Präsentation ab; gehen Sie nicht von einer Datei pro Folie aus.

{{% alert color="warning" title="Warning" %}}
Die Beispiele ändern vorübergehend das aktuelle Arbeitsverzeichnis des Prozesses, was alle Threads beeinflusst. Führen Sie jeden Export in einem eigenen Worker‑Prozess aus oder stellen Sie sicher, dass während des Exports keine anderen Arbeiten im Prozess vom aktuellen Verzeichnis abhängen. Ein eindeutiges temporäres Verzeichnis allein macht gleichzeitige Exporte im selben Prozess nicht sicher.
{{% /alert %}}

### **Export in den Speicher und Artefakte inspizieren**

Dieses vollständige Beispiel lädt `pres.pptx`, exportiert es in ein temporäres Verzeichnis, sammelt jedes Artefakt in einem Wörterbuch mit relativen Namen und Bytes und gibt dessen Namen, Typ und Byte‑Anzahl aus. Es bewahrt die erzeugte Verzeichnisstruktur und entfernt die temporären Dateien nach dem Sammeln. Der Eingabepfad wird vor dem Wechsel des Arbeitsverzeichnisses aufgelöst.

```python
import os
from pathlib import Path
from tempfile import TemporaryDirectory

import aspose.slides as slides


def collect_xaml_artifacts(source_path, export_hidden_slides):
    source_path = Path(source_path).resolve()
    original_directory = Path.cwd()
    artifacts = {}

    with TemporaryDirectory(prefix="xaml-") as temporary_directory:
        try:
            os.chdir(temporary_directory)
            with slides.Presentation(str(source_path)) as presentation:
                options = slides.export.xaml.XamlOptions()
                options.export_hidden_slides = export_hidden_slides
                presentation.save(options)

            for artifact_path in Path(temporary_directory).rglob("*"):
                if artifact_path.is_file():
                    relative_path = artifact_path.relative_to(temporary_directory)
                    artifacts[relative_path.as_posix()] = artifact_path.read_bytes()
        finally:
            os.chdir(original_directory)

    return artifacts


artifacts = collect_xaml_artifacts("pres.pptx", True)
inspect_xaml_text = False
image_extensions = {".png", ".jpg", ".jpeg", ".gif", ".bmp", ".tif", ".tiff", ".svg"}
for name, data in artifacts.items():
    extension = Path(name).suffix.lower()
    if extension == ".xaml":
        kind = "slide XAML"
    elif extension in image_extensions:
        kind = "image"
    else:
        kind = "supporting resource"
    print(f"{name}: {len(data)} bytes ({kind})")

    # Nur XAML decodieren und nur, wenn eine textuelle Inspektion erforderlich ist.
    if extension == ".xaml" and inspect_xaml_text:
        print(data.decode("utf-8"))
```

Erweiterungsprüfungen sind für die Inspektion nützlich; bewahren Sie alle Artefakte, einschließlich unbekannter Ressourcentypen. Lassen Sie die Bytes unverändert, wenn Sie sie speichern oder übertragen. Dekodieren Sie nur XAML, das eine textuelle Verarbeitung erfordert. Dieser Ansatz nutzt sowohl temporären Festplattenspeicher als auch Arbeitsspeicher für den gesammelten Export.

### **Gesammelte Artefakte in ein ZIP‑Archiv packen**

Dieses eigenständige Beispiel sammelt den Export, prüft die Namen und schreibt die ursprünglichen Bytes in ein ZIP‑Archiv. Ein eindeutiger Archivname trennt Export‑Aufgaben. ZIP‑Einträge verwenden Vorwärtsschrägstriche und bewahren relative Verzeichnisse. Unsichere Namen oder Namen, die nach Normalisierung kollidieren, führen dazu, dass das gesamte Paket vor dem Schreiben verworfen wird.

```python
from uuid import uuid4
from zipfile import ZIP_DEFLATED, ZipFile
import os
from pathlib import Path
from tempfile import TemporaryDirectory

import aspose.slides as slides


def collect_xaml_artifacts(source_path, export_hidden_slides):
    source_path = Path(source_path).resolve()
    original_directory = Path.cwd()
    artifacts = {}

    with TemporaryDirectory(prefix="xaml-") as temporary_directory:
        try:
            os.chdir(temporary_directory)
            with slides.Presentation(str(source_path)) as presentation:
                options = slides.export.xaml.XamlOptions()
                options.export_hidden_slides = export_hidden_slides
                presentation.save(options)

            for artifact_path in Path(temporary_directory).rglob("*"):
                if artifact_path.is_file():
                    relative_path = artifact_path.relative_to(temporary_directory)
                    artifacts[relative_path.as_posix()] = artifact_path.read_bytes()
        finally:
            os.chdir(original_directory)

    return artifacts


def package_xaml():
    artifacts = collect_xaml_artifacts("pres.pptx", False)
    entries = {}
    normalized_names = set()
    for name, data in artifacts.items():
        entry_name = name.replace("\\", "/")
        segments = entry_name.split("/")
        unsafe_name = entry_name.startswith("/") or ":" in entry_name
        unsafe_name = unsafe_name or any(not segment.strip() or segment in {".", ".."} for segment in segments)
        normalized_name = entry_name.casefold()
        if unsafe_name or normalized_name in normalized_names:
            print(f"Export rejected: unsafe or duplicate artifact name: {name}")
            return
        normalized_names.add(normalized_name)
        entries[entry_name] = data

    archive_path = Path(f"xaml-{uuid4().hex}.zip")
    with ZipFile(archive_path, "x", compression=ZIP_DEFLATED) as archive:
        for name, data in entries.items():
            archive.writestr(name, data)

    # Das ZIP-Verzeichnis wurde vor der Erfolgsmeldung finalisiert.
    print(f"Saved {len(entries)} artifacts to {archive_path}")


package_xaml()
```

Das Beispiel verwendet [ZipFile](https://docs.python.org/3/library/zipfile.html#zipfile.ZipFile), um nach dem Sammeln des temporären Exports ein lokales Archiv zu schreiben. Für die Remote‑Speicherung ersetzen Sie die Archiv‑Schreibphase durch das Hochladen der gesammelten Bytes. Verwenden Sie einen Export‑Job‑Bezeichner plus den vollständigen relativen Artefaktnamen als Objektschlüssel oder speichern Sie den Job‑Bezeichner, den relativen Namen und die Binärdaten in einer Datenbankzeile. Veröffentlichen Sie den Job erst, nachdem alle Uploads abgeschlossen oder die Datenbank‑Transaktion committet ist. Bereinigen Sie eine teilweise Ausgabe, falls die Persistierung fehlschlägt.

Für große Präsentationen verarbeiten Sie die temporären Dateien einzeln nach dem Export, anstatt alle Bytes in einem Wörterbuch zu sammeln. Dadurch wird eine zusätzliche in‑Speicher‑Kopie des gesamten Exports vermieden, jedoch nicht der eigentliche Speicherbedarf des Export‑Tools.

### **Ressourcennamen bewahren und Referenzen überprüfen**

- Normalisieren Sie Pfadtrenner, wenn das Ziel dies erfordert, bewahren Sie jedoch relative Verzeichnisse. Behalten Sie nicht nur den endgültigen Dateinamen, es sei denn, jeder erzeugte Name ist eindeutig und Ressourcen‑Referenzen bleiben gültig.
- Wenden Sie zielseitige Namensvalidierung an. Beim Schreiben loser Dateien sollten absolute Pfade und Traversal‑Segmente verworfen, das Ziel aufgelöst und geprüft werden, dass es innerhalb des vorgesehenen Export‑Verzeichnisses bleibt. Verwenden Sie ein anwendungsgesteuertes Verzeichnis ohne symbolische Links, die Schreibvorgänge umleiten könnten.
- Verwenden Sie für jeden Export‑Job einen separaten Speicher‑Namensraum. Erkennen Sie Kollisionen nach Normalisierung der Trenner und gemäß den Groß‑/Kleinschreibregeln des Ziels.
- Vor dem Veröffentlichen parsen Sie jedes XAML‑Dokument als XML und inspizieren dessen dateibasierte Ressourcen‑Referenzen, wie das `Source`‑ oder `ImageSource`‑Attribut von Bildern. Lösen Sie jeden relativen URI gegen das Verzeichnis des enthaltenden XAML‑Artefakts auf, normalisieren Sie den resultierenden Speicher‑Namen und bestätigen Sie, dass der entsprechende Wörterbuch‑Schlüssel, ZIP‑Eintrag oder gespeicherte Objekt existiert. Behandeln Sie externe URIs und XAML‑Markup‑Ausdrücke separat von relativen Dateinamen.

Beispielsweise muss bei `pres/Slide_1.xaml`, das `images/image1.png` referenziert, die gespeicherte Ressource als `pres/images/image1.png` verfügbar sein. Nur `image1.png` zu behalten, würde diese Beziehung brechen. Für Objektspeicher bewahren Sie die gleiche Struktur unter dem Job‑Präfix und stellen Sie diese Ressourcen‑URLs dem XAML‑Verbraucher zur Verfügung. Öffnen Sie das fertige ZIP erneut, um Eintragsnamen und Ressourcen‑Bytes zu prüfen, und laden Sie repräsentative Folien in der Ziel‑XAML‑Umgebung, um sicherzustellen, dass Bilder korrekt aufgelöst werden.

## **FAQ**

**Wie kann ich vorhersehbare Schriftarten sicherstellen, wenn die Original‑Schriftart nicht auf dem Rechner vorhanden ist?**

Setzen Sie [default_regular_font](https://reference.aspose.com/slides/de/python-net/aspose.slides.export.xaml/xamloptions/default_regular_font/) in [XamlOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides.export.xaml/xamloptions/) – sie wird als Ersatzschriftart während des Exports verwendet, wenn die Originalschriftart fehlt. Das garantiert nicht, dass das erzeugte XAML die Ersatzschriftart referenziert oder dass die Schriftart auf dem Zielrechner verfügbar ist. Stellen Sie sicher, dass die vom XAML referenzierten Schriftarten in der Umgebung, in der es angezeigt wird, vorhanden sind.

**Ist das exportierte XAML nur für WPF gedacht oder kann es auch in anderen XAML‑Stacks verwendet werden?**

Aspose.Slides exportiert WPF‑XAML über seine öffentliche API. Die Kompatibilität mit anderen XAML‑Stacks wie UWP und Xamarin.Forms ist nicht garantiert. Testen Sie das erzeugte Markup in Ihrer Zielumgebung.

**Werden ausgeblendete Folien unterstützt und wie kann ich verhindern, dass sie standardmäßig exportiert werden?**

Standardmäßig werden ausgeblendete Folien nicht einbezogen. Sie können dieses Verhalten über [export_hidden_slides](https://reference.aspose.com/slides/de/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) in [XamlOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides.export.xaml/xamloptions/) steuern – deaktivieren Sie es, wenn Sie diese nicht exportieren möchten.