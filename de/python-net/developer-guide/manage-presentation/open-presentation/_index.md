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

[Aspose.Slides for Python via .NET](https://products.aspose.com/slides/de/python-net/) kann PowerPoint- und OpenDocument‑Präsentationen aus Dateien und Streams laden. Nachdem eine Präsentation geladen wurde, können Sie ihre Struktur untersuchen, Folien bearbeiten, Ressourcen verwalten und sie im ursprünglichen oder einem anderen unterstützten Format speichern.

Das Ladeverhalten kann über die [LoadOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides/loadoptions/)‑Klasse angepasst werden. Sie können beispielsweise ein Öffnungspasswort angeben, große Binärobjekte außerhalb des Speichers halten oder eingebettete Binärdaten weglassen.

## **Präsentationen öffnen**

Nachdem Sie eine Datei oder einen Stream geladen haben, können Sie [das ursprüngliche Präsentationsformat ermitteln](/slides/de/python-net/detect-presentation-source-format/) um zu wählen, wie Ihre Anwendung es verarbeitet.

Um eine vorhandene Präsentation zu öffnen, übergeben Sie ihren Dateipfad dem [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Konstruktor. Verwenden Sie eine `with`‑Anweisung, damit Datei‑Handles, temporäre Daten und andere Ressourcen sofort freigegeben werden.

Das folgende Python‑Beispiel zeigt, wie man eine Präsentation öffnet und die Folienanzahl ermittelt:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

## **Passwortgeschützte Präsentationen öffnen**

Ein Öffnungspasswort verschlüsselt den Präsentationsinhalt. Um die komplette Präsentation zu laden, weisen Sie das korrekte Passwort [LoadOptions.password](https://reference.aspose.com/slides/de/python-net/aspose.slides/loadoptions/password/) zu und übergeben Sie die Optionen dem [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Konstruktor. Das Laden schlägt fehl, wenn das Passwort fehlt oder falsch ist.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-presentation.pptx", load_options) as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

Für Passwort‑Erkennung, -Validierung und Verschlüsselungs‑Workflows siehe [Passwortgeschützte Präsentationen](/slides/de/python-net/password-protected-presentation/). Wenn eine verschlüsselte Präsentation bewusst mit öffentlichen Dokumenteigenschaften gespeichert wurde, können diese Eigenschaften ohne Passwort ausgelesen werden; siehe [Präsentationseigenschaften verwalten](/slides/de/python-net/presentation-properties/).

## **Große Präsentationen öffnen**

[LoadOptions.blob_management_options](https://reference.aspose.com/slides/de/python-net/aspose.slides/loadoptions/blob_management_options/) steuert, wie Aspose.Slides binäre Großobjekte wie Bilder, Audio und Video verarbeitet. Sie können die Quelldatei gesperrt lassen, temporäre Dateien zulassen und die Menge der im Speicher gehaltenen BLOB‑Daten begrenzen.

Dieser Python‑Code demonstriert das Laden einer großen Präsentation (zum Beispiel 2 GB):

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
Mit `PresentationLockingBehavior.KEEP_LOCKED` bleibt die Quelldatei gesperrt, bis das `Presentation`‑Objekt freigegeben wird. Verschieben, überschreiben oder löschen Sie die Quelldatei nicht, solange dieses Objekt lebt.

Aspose.Slides kann beim Laden den Inhalt eines Eingabestreams kopieren. Bei großen Präsentationen ist ein Dateipfad daher im Allgemeinen effizienter als ein Stream. Siehe [BLOBs verwalten](/slides/de/python-net/manage-blob/) für zusätzliche Speicher‑ und Speicher‑verwaltungs‑Optionen.
{{% /alert %}}

## **Präsentationen ohne eingebettete Binärobjekte laden**

Eine Präsentation kann eingebettete Binärdaten enthalten, die eine Anwendung nicht benötigt oder nicht behalten möchte. Beispiele sind:

- VBA‑Projekte, verfügbar über [Presentation.vba_project](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/vba_project/);
- eingebettete OLE‑Daten, verfügbar über [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/de/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/);
- ActiveX‑Steuerungsdaten, verfügbar über [Control.active_x_control_binary](https://reference.aspose.com/slides/de/python-net/aspose.slides/control/active_x_control_binary/).

Setzen Sie [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/de/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) auf `True`, um diese Binärdaten beim Laden zu entfernen. Speichern Sie die geladene Präsentation, um das bereinigte Ergebnis beizubehalten.

Diese Option verringert die Gefahr durch unerwünschte eingebettete Payloads, ist jedoch kein vollständiges Malware‑Erkennungs‑ oder Inhalts‑Sanitärsystem.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("presentation-with-embedded-data.pptx", load_options) as presentation:
    presentation.save("presentation-without-embedded-data.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Wie kann ich feststellen, dass eine Datei beschädigt ist und nicht geöffnet werden kann?**

Aspose.Slides wirft beim Laden eine Parser‑ oder Format‑Ausnahme. Behandeln Sie diesen Fehler getrennt von einem falschen‑Passwort‑Fehler, damit die Anwendung die Ursache genau melden kann.

**Was passiert, wenn erforderliche Schriftarten fehlen?**

Die Präsentation kann dennoch geladen werden, aber die Darstellung und der Export können Schriftarten ersetzen. Sie können [Schriftart‑Substitution konfigurieren](/slides/de/python-net/font-substitution/) oder [benutzerdefinierte Schriftarten bereitstellen](/slides/de/python-net/custom-font/), um die Ausgabe vorhersehbarer zu machen.

**Lädt das Laden einer Präsentation auch ihre eingebetteten Medien?**

Eingebettete Audio‑ und Videodateien stehen über das Präsentations‑Objektmodell zur Verfügung. Externe Ressourcen werden gemäß dem Standard‑Ladeverhalten aufgelöst und können ggf. nicht verfügbar sein, wenn ihre Speicherorte nicht erreichbar sind.