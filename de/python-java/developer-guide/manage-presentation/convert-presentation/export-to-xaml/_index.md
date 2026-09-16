---
title: Präsentationen nach XAML in Python via Java exportieren
linktitle: Präsentation nach XAML
type: docs
weight: 30
url: /de/python-java/export-to-xaml/
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
- Java
- Aspose.Slides
description: "Exportieren Sie PowerPoint- und OpenDocument‑Präsentationen nach XAML mit Aspose.Slides für Python via Java. Verwenden Sie die Standardoptionen oder schließen Sie versteckte Folien ein."
---
## **Übersicht**

Dieser Artikel erklärt, wie PowerPoint‑Präsentationen mit Aspose.Slides für Python via Java nach XAML exportiert werden. Er enthält eine kurze Einführung in XAML, zeigt, wie eine Präsentation mit den Standardeinstellungen nach XAML gespeichert wird, und demonstriert, wie der Export über [XamlOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/xamloptions/) angepasst werden kann, einschließlich des Exports versteckter Folien. Der Artikel beantwortet zudem einige häufige Fragen zu Ersatzschriften, XAML‑Stack‑Kompatibilität und dem Verhalten beim Export versteckter Folien.

Die Beispiele benötigen Aspose.Slides für Python via Java sowie eine kompatible Java‑Runtime. Platzieren Sie `pres.pptx` im aktuellen Arbeitsverzeichnis. Jedes Beispiel startet die JVM nur, wenn sie noch nicht läuft.

## **Über XAML**

XAML ist eine XML‑basierte Auszeichnungssprache, die zum Beschreiben von Benutzeroberflächen in Frameworks wie WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) und Xamarin.Forms verwendet wird.

Sie können mit XAML‑Dateien in einem visuellen Designer arbeiten oder die Markup‑Datei direkt schreiben und bearbeiten.

## **Präsentationen mit XAML mit Standardoptionen exportieren**

Das folgende Python‑Beispiel zeigt, wie eine Präsentation mit den Standardeinstellungen nach XAML exportiert wird:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

Standardmäßig werden die exportierten Folien in einem Unterordner `pres` des aktuellen Arbeitsverzeichnisses des Prozesses gespeichert. Der Ordner wird automatisch erzeugt, und alle erforderlichen Bilder werden dort ebenfalls abgelegt.

Der Name des Ausgabeverzeichnisses wird aus dem Quelldateinamen ohne Dateierweiterung abgeleitet. Für `pres.pptx` lauten die Ausgabedateien `pres/Slide_1.xaml`, `pres/Slide_2.xaml` usw. Selbst wenn Sie einen absoluten Pfad zur Eingabedatei übergeben, wird das Ausgabeverzeichnis relativ zum aktuellen Arbeitsverzeichnis erstellt und nicht neben der Eingabedatei.

## **Präsentationen mit XAML mit benutzerdefinierten Optionen exportieren**

Verwenden Sie die Klasse [XamlOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/xamloptions/), um zu steuern, wie Aspose.Slides eine Präsentation nach XAML exportiert.

Um die Ausgabe an einem benutzerdefinierten Ort zu speichern, implementieren Sie `IXamlOutputSaver` und übergeben eine Instanz Ihrer Implementierung an die Methode [setOutputSaver](https://reference.aspose.com/slides/de/python-java/aspose.slides/xamloptions/#setOutputSaver) von [XamlOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/xamloptions/).

Um versteckte Folien in die XAML‑Ausgabe aufzunehmen, rufen Sie [setExportHiddenSlides](https://reference.aspose.com/slides/de/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) mit `True` auf, wie im folgenden Python‑Beispiel gezeigt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    xaml_options.setExportHiddenSlides(True)
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **Alle generierten XAML‑Artefakte erfassen**

Ein XAML‑Export kann ein XAML‑Dokument für jede exportierte Folie sowie separate Bilder und unterstützende Ressourcen erzeugen. Weisen Sie ein benutzerdefiniertes `IXamlOutputSaver` der Methode [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/de/python-java/aspose.slides/xamloptions/#setOutputSaver) zu, um diese Artefakte zu erhalten, anstatt den standardmäßigen Dateisystem‑Saver zu verwenden. Starten Sie den Export mit der XAML‑spezifischen Überladung von [Presentation.save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save), die XAML‑Optionen akzeptiert.

In Python verwenden Sie `jpype.JProxy`, um das Java‑Interface `IXamlOutputSaver` zu implementieren. Konvertieren Sie den Callback‑Pfad in `str` und kopieren Sie das Java‑Byte‑Array vor der Rückgabe in Python‑`bytes`, wie unten demonstriert.

### **Verstehen des Callback‑Lebenszyklus**

Der Exporter ruft `IXamlOutputSaver.save` für jedes erzeugte Artefakt separat auf:

- `path` identifiziert das Artefakt und kann relative Verzeichnisse enthalten. Behalten Sie diese Information, da XAML Ressourcen über relative Pfade referenzieren kann.
- `data` enthält die Bytes des Artefakts. Bilder und andere binäre Ressourcen dürfen nicht als Text decodiert werden.
- Der Saver ist dafür verantwortlich, die Daten zu behalten oder zu persistieren, bevor er zurückkehrt. Die Beispiele kopieren jedes Byte‑Array in vom Anwendungscode verwalteten Speicher.
- Export wird nur dann als erfolgreich angesehen, wenn der Präsentations‑Speichervorgang zurückkehrt und jeder Callback erfolgreich abgeschlossen wurde. Ignorieren Sie keine Speicher‑Fehler und starten Sie keine unbeobachteten Hintergrund‑Writes. Erfolgt die Persistierung nachträglich, melden Sie den Gesamterfolg erst, wenn dieser Schritt ebenfalls erfolgreich war.

[ XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/de/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) gilt ebenfalls für einen benutzerdefinierten Saver. Die Standardeinstellung `False` schließt XAML‑Dokumente versteckter Folien aus. Wird `True` übergeben, werden sie sowie alle für ihren Export erforderlichen Ressourcen einbezogen. Die Anzahl der Ressourcen hängt von der Präsentation ab; gehen Sie nicht von einem Callback pro Folie oder einer festen Callback‑Reihenfolge aus.

### **Exportieren in den Speicher und Artefakte inspizieren**

Dieses vollständige Beispiel lädt `pres.pptx`, sammelt jedes Artefakt in einem Python‑Dictionary aus Namen und unveränderlichen `bytes`‑Werten und gibt dessen Namen, Typ und Byte‑Anzahl aus. Die übergebenen Namen werden exakt beibehalten. Doppelte Namen markieren die Sammlung als ungültig, anstatt ein Artefakt stillschweigend zu überschreiben. Das Beispiel prüft dies, bevor die Ergebnisse verwendet werden.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

class MemoryXamlSaver:
    def __init__(self):
        self.artifacts = {}
        self.valid = True

    def save(self, path, data):
        name = str(path)
        if name in self.artifacts:
            self.valid = False
            print(f"Export rejected: duplicate artifact name: {name}")
            return
        self.artifacts[name] = bytes(data)

def main():

    saver = MemoryXamlSaver()
    output_saver = jpype.JProxy("com.aspose.slides.IXamlOutputSaver", inst=saver)
    presentation = Presentation("pres.pptx")
    try:
        options = XamlOptions()
        options.setOutputSaver(output_saver)
        options.setExportHiddenSlides(True)
        presentation.save(options)
    finally:
        presentation.dispose()

    if not saver.valid:
        print("Export rejected: the artifact collection is invalid.")
        return

    inspect_xaml_text = False
    image_extensions = (".png", ".jpg", ".jpeg", ".gif", ".bmp", ".tif", ".tiff", ".svg")
    for name, data in saver.artifacts.items():
        lower_name = name.lower()
        is_xaml = lower_name.endswith(".xaml")
        is_image = lower_name.endswith(image_extensions)
        kind = "slide XAML" if is_xaml else "image" if is_image else "supporting resource"
        print(f"{name}: {len(data)} bytes ({kind})")

        # Nur XAML dekodieren und nur, wenn eine textuelle Inspektion erforderlich ist.
        if is_xaml and inspect_xaml_text:
            markup = data.decode("utf-8")
            print(markup)


main()
```

Erweiterungsprüfungen sind für die Inspektion nützlich; behalten Sie alle Artefakte, einschließlich unbekannter Ressourcentypen. Lassen Sie die Bytes beim Speichern oder Übertragen unverändert. Verwenden Sie `bytes.decode` mit UTF‑8 ausschließlich für XAML, das eine Textverarbeitung erfordert.

### **Gesammelte Artefakte in einem ZIP‑Archiv verpacken**

Dieses eigenständige Beispiel sammelt den Export, validiert die Namen und schreibt die ursprünglichen Bytes in ein ZIP‑Archiv. Ein eindeutiger Archivname trennt parallele Export‑Jobs. ZIP‑Einträge verwenden Vorwärtsschrägstriche und behalten relative Verzeichnisse bei. Unsichere Namen oder Namen, die nach Normalisierung kollidieren, führen dazu, dass das gesamte Paket vor dem Schreiben verworfen wird.

```python
from uuid import uuid4
from zipfile import ZipFile

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

class MemoryXamlSaver:
    def __init__(self):
        self.artifacts = {}
        self.valid = True

    def save(self, path, data):
        name = str(path)
        if name in self.artifacts:
            self.valid = False
            print(f"Export rejected: duplicate artifact name: {name}")
            return
        self.artifacts[name] = bytes(data)

def main():

    saver = MemoryXamlSaver()
    output_saver = jpype.JProxy("com.aspose.slides.IXamlOutputSaver", inst=saver)
    presentation = Presentation("pres.pptx")
    try:
        options = XamlOptions()
        options.setOutputSaver(output_saver)
        options.setExportHiddenSlides(False)
        presentation.save(options)
    finally:
        presentation.dispose()

    if not saver.valid:
        print("Export rejected: the artifact collection is invalid.")
        return

    entries = {}
    entry_names = set()
    for name, data in saver.artifacts.items():
        entry_name = name.replace("\\", "/")
        segments = entry_name.split("/")
        unsafe_name = entry_name.startswith("/") or ":" in entry_name or "\x00" in entry_name
        unsafe_name |= any(not segment.strip() or segment in (".", "..") for segment in segments)
        normalized_name = entry_name.casefold()
        if unsafe_name or normalized_name in entry_names:
            print(f"Export rejected: unsafe or duplicate artifact name: {name}")
            return
        entry_names.add(normalized_name)
        entries[entry_name] = data

    job_id = uuid4()
    archive_path = f"xaml-{job_id}.zip"
    try:
        with ZipFile(archive_path, mode="x") as archive:
            for name, data in entries.items():
                archive.writestr(name, data)

        # Closing finalizes the ZIP directory before success is reported.
        print(f"Saved {len(entries)} artifacts to {archive_path}")
    except OSError as exception:
        print(f"Archive persistence failed: {exception}")


main()
```

Das Beispiel nutzt Python‑`zipfile.ZipFile`, um ein lokales Archiv zu schreiben; der Exporter selbst schreibt keine losen XAML‑ oder Bilddateien. Für Remote‑Speicher ersetzen Sie die Archiv‑Schreibphase durch das Hochladen der gesammelten Byte‑Arrays. Verwenden Sie einen Export‑Job‑Bezeichner plus den vollständigen relativen Artefaktnamen als Blob‑Schlüssel oder speichern Sie den Job‑Bezeichner, den relativen Namen und die Binärdaten in einer Datenbankzeile. Veröffentlichen Sie den Job erst, nachdem alle Uploads abgeschlossen oder die Datenbank‑Transaktion bestätigt ist. Bereinigen Sie teilweise Ausgaben, falls die Persistierung fehlschlägt.

Für große Präsentationen kann ein benutzerdefinierter Saver jedes Artefakt direkt im Anwendungsspeicher persistieren, um zu vermeiden, dass eine zusätzliche Kopie des gesamten Exports im Arbeitsspeicher gehalten wird. Halten Sie jeden Callback aus Sicht des Exporters synchron: geben Sie erst zurück, wenn das Ziel die Bytes akzeptiert hat, und lassen Sie Fehler an den Aufrufer weitergeben.

### **Ressourcennamen beibehalten und Referenzen überprüfen**

- Normalisieren Sie Pfad‑Trennzeichen, wenn das Ziel dies erfordert, behalten Sie aber relative Verzeichnisse bei. Verwenden Sie nicht ausschließlich `pathlib.Path.name`, es sei denn, jeder erzeugte Name ist eindeutig und Ressourcen‑Referenzen bleiben gültig.
- Wenden Sie ziel­spezifische Namensvalidierung an. Beim Schreiben loser Dateien lehnen Sie verankerte Pfade und Traversal‑Segmente ab, lösen das Ziel mit `pathlib.Path.resolve` auf und prüfen, dass es innerhalb des vorgesehenen Export‑Verzeichnisses bleibt, inklusive des Verzeichnis‑Trennzeichens in der Enthaltungs‑Prüfung. Nutzen Sie ein von der Anwendung gesteuertes Verzeichnis ohne symbolische Links, die Schreibvorgänge umleiten könnten.
- Verwenden Sie für jeden Export‑Job einen separaten Saver und Namensraum für den Speicher. Erkennen Sie Kollisionen nach Normalisierung der Trennzeichen und gemäß den Groß‑/Kleinschreibungs‑Regeln des Ziels.
- Vor der Veröffentlichung sollten Sie jedes XAML‑Dokument als XML parsen und dessen dateibasierte Ressourcen‑Referenzen prüfen, z. B. Bild‑`Source`‑ oder `ImageSource`‑Attribute. Lösen Sie jede relative URI relativ zum Verzeichnis des betreffenden XAML‑Artefakts auf, normalisieren Sie den resultierenden Speicher‑Namen und bestätigen Sie, dass der entsprechende Schlüssel im Map, ZIP‑Eintrag oder gespeicherten Objekt existiert. Behandeln Sie externe URIs und XAML‑Markup‑Ausdrücke getrennt von relativen Dateinamen.

Beispielsweise muss bei `pres/Slide_1.xaml`, das `images/image1.png` referenziert, die gespeicherte Ressource als `pres/images/image1.png` verfügbar sein. Nur `image1.png` zu speichern, würde diese Beziehung brechen. Bei Objektspeichern sollten Sie dieselbe Ordnerstruktur unter dem Job‑Präfix beibehalten und die Ressourcen‑URLs für den XAML‑Verbraucher zugänglich machen. Öffnen Sie das fertige ZIP erneut, um Eintragsnamen und Ressourcebytes zu prüfen, und laden Sie repräsentative Folien in der Ziel‑XAML‑Umgebung, um sicherzustellen, dass Bilder korrekt aufgelöst werden.

## **FAQ**

**Wie kann ich vorhersehbare Schriften sicherstellen, wenn die Originalschrift auf dem Rechner nicht vorhanden ist?**

Rufen Sie [setDefaultRegularFont](https://reference.aspose.com/slides/de/python-java/aspose.slides/saveoptions/#setDefaultRegularFont) in [XamlOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/xamloptions/) auf – sie wird während des Exports als Ersatzschrift verwendet, wenn die Originalschrift fehlt. Dies garantiert nicht, dass das erzeugte XAML die Ersatzschrift referenziert oder dass die Schrift auf dem Zielrechner verfügbar ist. Stellen Sie sicher, dass die im XAML referenzierten Schriften in der Zielumgebung vorhanden sind.

**Ist das exportierte XAML nur für WPF vorgesehen oder kann es auch in anderen XAML‑Stacks verwendet werden?**

Aspose.Slides exportiert WPF‑XAML über seine öffentliche API. Die Kompatibilität mit anderen XAML‑Stacks wie UWP und Xamarin.Forms ist nicht garantiert. Testen Sie das erzeugte Markup in Ihrer Zielumgebung.

**Werden versteckte Folien unterstützt und wie kann ich verhindern, dass sie standardmäßig exportiert werden?**

Standardmäßig werden versteckte Folien nicht einbezogen. Sie können dieses Verhalten über [setExportHiddenSlides](https://reference.aspose.com/slides/de/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) in [XamlOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/xamloptions/) steuern – lassen Sie die Einstellung deaktiviert, wenn Sie sie nicht exportieren möchten.