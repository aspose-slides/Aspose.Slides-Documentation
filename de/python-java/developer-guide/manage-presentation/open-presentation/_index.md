---
title: Präsentationen in Python über Java öffnen
linktitle: Präsentation öffnen
type: docs
weight: 20
url: /de/python-java/open-presentation/
keywords:
- PowerPoint öffnen
- Präsentation öffnen
- PPTX öffnen
- PPT öffnen
- ODP öffnen
- Präsentation laden
- PPTX laden
- PPT laden
- ODP laden
- geschützte Präsentation
- große Präsentation
- externe Ressource
- Binärobjekt
- Python
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint- und OpenDocument-Präsentationen in Python über Java öffnen, Öffnungspasswörter bereitstellen, das Laden von Ressourcen steuern und mit Aspose.Slides für Python über Java den Speicherverbrauch reduzieren."
---
## **Einführung**

[Aspose.Slides für Python über Java](https://products.aspose.com/slides/de/python-java/) kann PowerPoint‑ und OpenDocument‑Präsentationen aus Dateien und Streams laden. Nachdem eine Präsentation geladen wurde, können Sie ihre Struktur untersuchen, Folien bearbeiten, Ressourcen verwalten und sie im Original‑ oder einem anderen unterstützten Format speichern.

Das Ladeverhalten kann über die Klasse [LoadOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/loadoptions/) angepasst werden. Beispielsweise können Sie ein Öffnungskennwort angeben, große Binärobjekte außerhalb des Java‑Heap‑Speichers behalten, externe Ressourcen steuern oder eingebettete Binärdaten weglassen.

## **Präsentationen öffnen**

Um eine vorhandene Präsentation zu öffnen, übergeben Sie ihren Dateipfad an den Konstruktor [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/). Entsorgen Sie das Presentation‑Objekt nach der Verwendung, damit Dateihandles, temporäre Daten und andere Ressourcen zeitnah freigegeben werden.

Das folgende Python‑Beispiel zeigt, wie eine Präsentation geöffnet und die Folienanzahl abgerufen wird:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

## **Passwortgeschützte Präsentationen öffnen**

Ein Öffnungspasswort verschlüsselt den Inhalt der Präsentation. Um die gesamte Präsentation zu laden, übergeben Sie das richtige Passwort an [LoadOptions.setPassword](https://reference.aspose.com/slides/de/python-java/aspose.slides/loadoptions/#setPassword) und stellen Sie die Optionen dem Konstruktor [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) zur Verfügung. Das Laden schlägt fehl, wenn das Passwort fehlt oder falsch ist.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-presentation.pptx", load_options)
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

Für Passwort‑Erkennung, Validierung und Verschlüsselungs‑Workflows siehe [Password-Protect Presentations](/slides/de/python-java/password-protected-presentation/). Wenn eine verschlüsselte Präsentation bewusst mit öffentlichen Dokumenteigenschaften gespeichert wurde, können diese Eigenschaften ohne Passwort gelesen werden; siehe [Manage Presentation Properties](/slides/de/python-java/presentation-properties/).

## **Große Präsentationen öffnen**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) liefert Optionen, die steuern, wie Aspose.Slides große Binärobjekte wie Bilder, Audio und Video handhabt. Sie können die Quelldatei gesperrt halten, temporäre Dateien zulassen und die Menge der im Speicher gehaltenen BLOB‑Daten begrenzen.

Der folgende Python‑Code demonstriert das Laden einer großen Präsentation (z. B. 2 GB):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior, SaveFormat

file_path = "large-presentation.pptx"

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)
load_options.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024)

presentation = Presentation(file_path, load_options)
try:
    presentation.getSlides().get_Item(0).setName("Large presentation")
    presentation.save("large-presentation-copy.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}

Mit [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentationlockingbehavior/#KeepLocked) bleibt die Quelldatei gesperrt, bis die Presentation‑Instanz entsorgt wird. Verschieben, überschreiben oder löschen Sie die Quelldatei nicht, solange diese Instanz existiert.

Aspose.Slides kann beim Laden den Inhalt eines Eingabestreams kopieren. Für große Präsentationen ist daher ein Dateipfad im Allgemeinen effizienter als ein Stream. Siehe [Manage BLOBs](/slides/de/python-java/manage-blob/) für weitere Speicher‑ und Speicherverwaltungsoptionen.

{{% /alert %}}

## **Externe Ressourcen steuern**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/de/python-java/aspose.slides/loadoptions/#setResourceLoadingCallback) akzeptiert einen JPype‑Proxy, der das Java‑Ressourcen‑Lade‑Callback‑Interface implementiert. Der Callback kann Ersatzdaten bereitstellen, eine Ressource weiterleiten, den Standard‑Lader verwenden oder die Ressource überspringen. Dies ist nützlich, wenn Präsentationen externe Bilder enthalten, die gemäß anwendungsspezifischen Sicherheits‑ oder Speicherregeln aufgelöst werden müssen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import LoadOptions, Presentation, ResourceLoadingAction

class ImageLoadingHandler:
    def resourceLoading(self, resource_loading_arguments):
        is_jpeg = str(resource_loading_arguments.getOriginalUri()).lower().endswith(".jpg")
        approved_image_path = Path("approved-image.jpg")
        if not is_jpeg or not approved_image_path.exists():
            return ResourceLoadingAction.Skip

        try:
            image_data = approved_image_path.read_bytes()
            java_image_data = jpype.JArray(jpype.JByte)(image_data)
            resource_loading_arguments.setData(java_image_data)
            return ResourceLoadingAction.UserProvided
        except OSError:
            print("The approved replacement image could not be read.")
            return ResourceLoadingAction.Skip

load_options = LoadOptions()
image_loading_handler = ImageLoadingHandler()
callback = jpype.JProxy("com.aspose.slides.IResourceLoadingCallback", inst=image_loading_handler)
load_options.setResourceLoadingCallback(callback)

presentation = Presentation("presentation-with-external-images.pptx", load_options)
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

## **Präsentationen ohne eingebettete Binärobjekte laden**

Eine Präsentation kann eingebettete Binärdaten enthalten, die eine Anwendung nicht benötigt oder nicht behalten möchte. Beispiele sind:

- VBA‑Projekte, verfügbar über [Presentation.getVbaProject](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getVbaProject);
- eingebettete OLE‑Daten, verfügbar über [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/de/python-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- ActiveX‑Steuerungsdaten, verfügbar über [Control.getActiveXControlBinary](https://reference.aspose.com/slides/de/python-java/aspose.slides/control/#getActiveXControlBinary).

Setzen Sie [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/de/python-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) auf `True`, um diese Binärdaten beim Laden zu entfernen. Speichern Sie die geladene Präsentation, um das bereinigte Ergebnis zu erhalten.

Diese Option reduziert die Exposition gegenüber unerwünschten eingebetteten Payloads, stellt jedoch kein vollständiges Malware‑Erkennungs‑ oder Inhalts‑Sanitärsystem dar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat

load_options = LoadOptions()
load_options.setDeleteEmbeddedBinaryObjects(True)

presentation = Presentation("presentation-with-embedded-data.pptx", load_options)
try:
    presentation.save("presentation-without-embedded-data.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Wie kann ich erkennen, dass eine Datei beschädigt ist und nicht geöffnet werden kann?**

Aspose.Slides wirft beim Laden eine Parser‑ oder Format‑Ausnahme. Behandeln Sie diesen Fehler gesondert von einem falschen‑Passwort‑Fehler, damit die Anwendung die Ursache korrekt melden kann.

**Was geschieht, wenn erforderliche Schriftarten fehlen?**

Die Präsentation kann weiterhin geladen werden, aber Rendering und Export können Schriftarten ersetzen. Sie können die [Schriftarten‑Substitution konfigurieren](/slides/de/python-java/font-substitution/) oder [benutzerdefinierte Schriftarten bereitstellen](/slides/de/python-java/custom-font/), um die Ausgabe vorhersehbarer zu machen.

**Wird beim Laden einer Präsentation auch deren eingebettete Medien geladen?**

Eingebettete Audio‑ und Videodateien werden über das Präsentations‑Objektmodell verfügbar. Externe Ressourcen werden gemäß dem konfigurierten Ressourcen‑Lade‑Verhalten aufgelöst und können nicht verfügbar sein, wenn deren Speicherorte nicht erreichbar sind.