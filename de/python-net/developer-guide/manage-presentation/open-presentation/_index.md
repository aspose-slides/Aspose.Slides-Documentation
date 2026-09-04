---
title: Präsentationen in Python öffnen
linktitle: Präsentationen öffnen
type: docs
weight: 20
url: /de/python-net/open-presentation/
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
- binäres Objekt
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint- und OpenDocument-Präsentationen in Python öffnen, Öffnungspasswörter angeben und den Speicherverbrauch mit Aspose.Slides für Python via .NET reduzieren."
---
## **Einleitung**

[Aspose.Slides für Python via .NET](https://products.aspose.com/slides/de/python-net/) kann PowerPoint- und OpenDocument-Präsentationen aus Dateien und Streams laden. Nachdem eine Präsentation geladen wurde, können Sie ihre Struktur untersuchen, Folien bearbeiten, Ressourcen verwalten und sie im Originalformat oder in einem anderen unterstützten Format speichern.

Das Ladeverhalten kann über die Klasse [LoadOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides/loadoptions/) angepasst werden. Beispielsweise können Sie ein Öffnungspasswort angeben, große Binärobjekte außerhalb des Speichers behalten oder eingebettete Binärdaten weglassen.

## **Präsentationen öffnen**

Um eine vorhandene Präsentation zu öffnen, übergeben Sie ihren Dateipfad dem Konstruktor [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/). Verwenden Sie eine `with`-Anweisung, damit Dateihandles, temporäre Daten und andere Ressourcen umgehend freigegeben werden.

Das folgende Python-Beispiel zeigt, wie man eine Präsentation öffnet und ihre Folienanzahl ermittelt:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

## **Passwortgeschützte Präsentationen öffnen**

Ein Öffnungspasswort verschlüsselt den Inhalt der Präsentation. Um die gesamte Präsentation zu laden, weisen Sie das korrekte Passwort [LoadOptions.password](https://reference.aspose.com/slides/de/python-net/aspose.slides/loadoptions/password/) zu und übergeben Sie die Optionen dem Konstruktor [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/). Das Laden schlägt fehl, wenn das Passwort fehlt oder falsch ist.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-presentation.pptx", load_options) as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

Für Informationen zur Passworterkennung, -validierung und zu Verschlüsselungsabläufen siehe [Password-Protect Presentations](/slides/de/python-net/password-protected-presentation/). Wenn eine verschlüsselte Präsentation bewusst mit öffentlichen Dokumenteigenschaften gespeichert wurde, können diese Eigenschaften ohne Passwort gelesen werden; siehe [Manage Presentation Properties](/slides/de/python-net/presentation-properties/).

## **Große Präsentationen öffnen**

[LoadOptions.blob_management_options](https://reference.aspose.com/slides/de/python-net/aspose.slides/loadoptions/blob_management_options/) steuert, wie Aspose.Slides binäre große Objekte wie Bilder, Audio und Video verarbeitet. Sie können die Quelldatei gesperrt lassen, temporäre Dateien zulassen und die Menge an BLOB-Daten, die im Speicher behalten wird, begrenzen.

Dieser Python-Code demonstriert das Laden einer großen Präsentation (z. B. 2 GB):

```python
import aspose.slides as slides
file_path = "large-presentation.pptx"

load_options = slides.LoadOptions()
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024

with slides.Presentation(file_path, load_options) as presentation:
    presentation.slides[0].name = "Large presentation"
    presentation.save("large-presentation-copy.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="info" title="Note" %}}
Mit `PresentationLockingBehavior.KEEP_LOCKED` bleibt die Quelldatei gesperrt, bis das `Presentation`-Objekt freigegeben wird. Verschieben, überschreiben oder löschen Sie die Quelldatei nicht, solange dieses Objekt aktiv ist.

Aspose.Slides kann beim Laden den Inhalt eines Eingabestreams kopieren. Für große Präsentationen ist ein Dateipfad daher im Allgemeinen effizienter als ein Stream. Siehe [Manage BLOBs](/slides/de/python-net/manage-blob/) für zusätzliche Speicher- und Speicherverwaltungsoptionen.
{{% /alert %}}

## **Präsentationen ohne eingebettete Binärobjekte laden**

Eine Präsentation kann eingebettete Binärdaten enthalten, die eine Anwendung nicht benötigt oder behalten möchte. Beispiele sind:

- VBA-Projekte, verfügbar über [Presentation.vba_project](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/vba_project/);
- eingebettete OLE-Daten, verfügbar über [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/de/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/);
- ActiveX-Steuerungsdaten, verfügbar über [Control.active_x_control_binary](https://reference.aspose.com/slides/de/python-net/aspose.slides/control/active_x_control_binary/).

Setzen Sie [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/de/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) auf `True`, um diese Binärdaten beim Laden zu entfernen. Speichern Sie die geladene Präsentation, um das bereinigte Ergebnis beizubehalten.

Diese Option reduziert die Exposition gegenüber unerwünschten eingebetteten Nutzdaten, stellt jedoch kein vollständiges Malware-Erkennungs- oder Inhalts-Sanitisierungssystem dar.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("presentation-with-embedded-data.pptx", load_options) as presentation:
    presentation.save("presentation-without-embedded-data.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Wie kann ich erkennen, dass eine Datei beschädigt ist und nicht geöffnet werden kann?**

Aspose.Slides wirft beim Laden eine Parsing- oder Format-Ausnahme. Behandeln Sie diesen Fehler separat von einem falschen-Passwort-Fehler, damit die Anwendung die Ursache genau melden kann.

**Was passiert, wenn erforderliche Schriftarten fehlen?**

Die Präsentation kann trotzdem geladen werden, aber beim Rendern und Export können Schriftarten ersetzt werden. Sie können [configure font substitution](/slides/de/python-net/font-substitution/) oder [provide custom fonts](/slides/de/python-net/custom-font/) nutzen, um die Ausgabe vorhersehbarer zu machen.

**Lädt das Laden einer Präsentation auch deren eingebettete Medien?**

Eingebettete Audio- und Videodateien werden über das Präsentations-Objektmodell verfügbar. Externe Ressourcen werden nach dem standardmäßigen Ladeverhalten aufgelöst und können nicht verfügbar sein, wenn ihre Speicherorte nicht zugänglich sind.