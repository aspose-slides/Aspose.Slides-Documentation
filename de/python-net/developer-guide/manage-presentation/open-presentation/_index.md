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
description: "Öffnen Sie PowerPoint (.pptx, .ppt) und OpenDocument (.odp) Präsentationen mühelos mit Aspose.Slides für Python über .NET—schnell, zuverlässig, voll funktionsfähig."
---

## **Übersicht**

Neben dem Erstellen von PowerPoint‑Präsentationen von Grund auf ermöglicht Aspose.Slides auch das Öffnen vorhandener Präsentationen. Nach dem Laden einer Präsentation können Sie Informationen darüber abrufen, Folieninhalt bearbeiten, neue Folien hinzufügen, vorhandene entfernen und vieles mehr.

## **Präsentationen öffnen**

Um eine vorhandene Präsentation zu öffnen, instanziieren Sie die [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse und übergeben dem Konstruktor den Dateipfad.

Das folgende Python‑Beispiel zeigt, wie Sie eine Präsentation öffnen und die Folienanzahl ermitteln:
```python
import aspose.slides as slides

# Instanziieren Sie die Presentation‑Klasse und übergeben Sie einen Dateipfad an deren Konstruktor.
with slides.Presentation("sample.pptx") as presentation:
    # Geben Sie die Gesamtzahl der Folien in der Präsentation aus.
    print(presentation.slides.length)
```


## **Passwortgeschützte Präsentationen öffnen**

Wenn Sie eine passwortgeschützte Präsentation öffnen müssen, übergeben Sie das Passwort über die [password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/)‑Eigenschaft der [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/)‑Klasse, um sie zu entschlüsseln und zu laden. Der folgende Python‑Code demonstriert diesen Vorgang:
```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("sample.pptx", load_options) as presentation:
    # Vorgänge an der entschlüsselten Präsentation ausführen.
```


## **Große Präsentationen öffnen**

Aspose.Slides bietet Optionen – insbesondere die [blob_management_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/blob_management_options/)‑Eigenschaft in der [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/)‑Klasse – um das Laden großer Präsentationen zu unterstützen.

Dieser Python‑Code demonstriert das Laden einer großen Präsentation (z. B. 2 GB):
```python
import aspose.slides as slides
import os

file_path = "LargePresentation.pptx"

load_options = slides.LoadOptions()
# Choose the KeepLocked behavior—the presentation file will remain locked for the lifetime of 
# the Presentation instance, but it does not need to be loaded into memory or copied to a temporary file.
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024  # 10 MB

with slides.Presentation(file_path, load_options) as presentation:
    # The large presentation has been loaded and can be used, while memory consumption remains low.

    # Make changes to the presentation.
    presentation.slides[0].name = "Large presentation"

    # Save the presentation to another file. Memory consumption remains low during this operation.
    presentation.save("LargePresentation-copy.pptx", slides.export.SaveFormat.PPTX)

    # Don't do this! An I/O exception will be thrown because the file is locked until the presentation object is disposed.
    os.remove(file_path)

# It is OK to do it here. The source file is no longer locked by the presentation object.
os.remove(file_path)
```


{{% alert color="info" title="Info" %}}
Um bestimmte Einschränkungen beim Arbeiten mit Streams zu umgehen, kann Aspose.Slides den Inhalt eines Streams kopieren. Das Laden einer großen Präsentation aus einem Stream führt dazu, dass die Präsentation kopiert wird und das Laden verlangsamen kann. Daher empfehlen wir, beim Laden großer Präsentationen nach Möglichkeit den Dateipfad anstelle eines Streams zu verwenden.

Wenn Sie eine Präsentation erstellen, die große Objekte (Video, Audio, hochauflösende Bilder usw.) enthält, können Sie das [BLOB management](/slides/de/python-net/manage-blob/) nutzen, um den Speicherverbrauch zu reduzieren.
{{%/alert %}}

## **Externe Ressourcen steuern**

Aspose.Slides stellt das [IResourceLoadingCallback](https://reference.aspose.com/slides/python-net/aspose.slides/iresourceloadingcallback/)‑Interface bereit, mit dem Sie externe Ressourcen verwalten können. Der folgende Python‑Code zeigt, wie das `IResourceLoadingCallback`‑Interface verwendet wird:
```python
# [TODO[not_supported_yet]: Python-Implementierung von .NET-Schnittstellen]
```


## **Präsentationen ohne eingebettete Binärobjekte laden**

Eine PowerPoint‑Präsentation kann die folgenden Arten eingebetteter Binärobjekte enthalten:

- VBA‑Projekt (zugänglich über [Presentation.vba_project](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/vba_project/));
- OLE‑Objekt‑eingebettete Daten (zugänglich über [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/));
- ActiveX‑Steuerungs‑Binärdaten (zugänglich über [Control.active_x_control_binary](https://reference.aspose.com/slides/python-net/aspose.slides/control/active_x_control_binary/)).

Mit der [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/)‑Eigenschaft können Sie eine Präsentation ohne jegliche eingebettete Binärobjekte laden.

Diese Eigenschaft ist nützlich, um potenziell schädliche Binärinhalte zu entfernen. Der folgende Python‑Code demonstriert, wie Sie eine Präsentation ohne eingebettete Binärinhalte laden:
```py
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("malware.ppt", load_options) as presentation:
    # Vorgänge an der Präsentation ausführen.
```


## **FAQ**

**Wie erkenne ich, dass eine Datei beschädigt ist und nicht geöffnet werden kann?**

Beim Laden erhalten Sie eine Parsing‑/Format‑Validierungs‑Ausnahme. Solche Fehler weisen häufig auf eine ungültige ZIP‑Struktur oder beschädigte PowerPoint‑Records hin.

**Was passiert, wenn beim Öffnen erforderliche Schriftarten fehlen?**

Die Datei wird geöffnet, jedoch kann beim späteren [rendering/export](/slides/de/python-net/convert-presentation/) ein Ersatz der Schriftarten erfolgen. Konfigurieren Sie [Schriftart‑Ersetzungen](/slides/de/python-net/font-substitution/) oder fügen Sie die erforderlichen Schriftarten [der Laufzeitumgebung](/slides/de/python-net/custom-font/) hinzu.

**Wie werden eingebettete Medien (Video/Audio) beim Öffnen behandelt?**

Sie stehen als Präsentations‑Ressourcen zur Verfügung. Wenn Medien über externe Pfade referenziert werden, stellen Sie sicher, dass diese Pfade in Ihrer Umgebung erreichbar sind; andernfalls kann beim [rendering/export](/slides/de/python-net/convert-presentation/) das Medium weggelassen werden.