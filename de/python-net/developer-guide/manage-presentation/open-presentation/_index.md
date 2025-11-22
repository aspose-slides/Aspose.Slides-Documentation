---
title: Präsentation in Python öffnen
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
- Binärobjekt
- Python
- Aspose.Slides
description: "Öffnen Sie PowerPoint (.pptx, .ppt) und OpenDocument (.odp) Präsentationen mühelos mit Aspose.Slides für Python über .NET—schnell, zuverlässig, vollumfänglich."
---

## **Übersicht**

Neben dem Erstellen von PowerPoint‑Präsentationen von Grund auf ermöglicht Aspose.Slides auch das Öffnen vorhandener Präsentationen. Nach dem Laden einer Präsentation können Sie Informationen darüber abrufen, Folieninhalte bearbeiten, neue Folien hinzufügen, vorhandene entfernen und vieles mehr.

## **Präsentationen öffnen**

Um eine vorhandene Präsentation zu öffnen, instanziieren Sie die [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse und übergeben den Dateipfad an ihren Konstruktor.

Das folgende Python‑Beispiel zeigt, wie man eine Präsentation öffnet und die Folienzahl ermittelt:
```python
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse und übergeben Sie einen Dateipfad an ihren Konstruktor.
with slides.Presentation("sample.pptx") as presentation:
    # Geben Sie die Gesamtzahl der Folien in der Präsentation aus.
    print(presentation.slides.length)
```


## **Passwortgeschützte Präsentationen öffnen**

Wenn Sie eine passwortgeschützte Präsentation öffnen müssen, übergeben Sie das Passwort über die [password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/) Eigenschaft der [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) Klasse, um sie zu entschlüsseln und zu laden. Der folgende Python‑Code demonstriert diese Vorgehensweise:
```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("sample.pptx", load_options) as presentation:
    # Vorgänge an der entschlüsselten Präsentation ausführen.
```


## **Große Präsentationen öffnen**

Aspose.Slides stellt Optionen bereit – insbesondere die [blob_management_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/blob_management_options/) Eigenschaft in der [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) Klasse –, um das Laden großer Präsentationen zu unterstützen.

Dieser Python‑Code demonstriert das Laden einer großen Präsentation (z.B. 2 GB):
```python
import aspose.slides as slides
import os

file_path = "LargePresentation.pptx"

load_options = slides.LoadOptions()
# Wählen Sie das KeepLocked-Verhalten — die Präsentationsdatei bleibt für die gesamte Lebensdauer von 
# der Presentation-Instanz gesperrt, muss jedoch nicht in den Speicher geladen oder in eine temporäre Datei kopiert werden.
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024  # 10 MB

with slides.Presentation(file_path, load_options) as presentation:
    # Die große Präsentation wurde geladen und kann verwendet werden, während der Speicherverbrauch gering bleibt.

    # Änderungen an der Präsentation vornehmen.
    presentation.slides[0].name = "Large presentation"

    # Die Präsentation in eine andere Datei speichern. Der Speicherverbrauch bleibt während dieses Vorgangs gering.
    presentation.save("LargePresentation-copy.pptx", slides.export.SaveFormat.PPTX)

    # Nicht tun! Eine I/O-Ausnahme wird ausgelöst, weil die Datei gesperrt ist, bis das Präsentationsobjekt freigegeben wird.
    os.remove(file_path)

# Es ist hier in Ordnung. Die Quelldatei ist nicht mehr durch das Präsentationsobjekt gesperrt.
os.remove(file_path)
```


{{% alert color="info" title="Info" %}}
Um bestimmte Einschränkungen beim Arbeiten mit Streams zu umgehen, kann Aspose.Slides den Inhalt eines Streams kopieren. Das Laden einer großen Präsentation aus einem Stream führt dazu, dass die Präsentation kopiert wird und das Laden verlangsamen kann. Daher empfehlen wir dringend, beim Laden einer großen Präsentation den Dateipfad der Präsentation statt eines Streams zu verwenden.

Wenn Sie eine Präsentation erstellen, die große Objekte (Video, Audio, hochauflösende Bilder usw.) enthält, können Sie [BLOB management](/slides/de/python-net/manage-blob/) verwenden, um den Speicherverbrauch zu reduzieren.
{{%/alert %}}

## **Externe Ressourcen steuern**

Aspose.Slides stellt das [IResourceLoadingCallback](https://reference.aspose.com/slides/python-net/aspose.slides/iresourceloadingcallback/) Interface bereit, mit dem Sie externe Ressourcen verwalten können. Der folgende Python‑Code zeigt, wie das `IResourceLoadingCallback` Interface verwendet wird:
```python
# [TODO[not_supported_yet]: Python-Implementierung von .NET-Schnittstellen]
```


## **Präsentationen ohne eingebettete Binärobjekte laden**

Eine PowerPoint‑Präsentation kann die folgenden Arten von eingebetteten Binärobjekten enthalten:

- VBA‑Projekt (zugänglich über [Presentation.vba_project](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/vba_project/));
- OLE‑Objekt eingebettete Daten (zugänglich über [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/));
- ActiveX‑Steuerungs‑Binärdaten (zugänglich über [Control.active_x_control_binary](https://reference.aspose.com/slides/python-net/aspose.slides/control/active_x_control_binary/)).

Mit der [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) Eigenschaft können Sie eine Präsentation ohne eingebettete Binärobjekte laden.

Diese Eigenschaft ist nützlich, um potenziell schädlichen Binärinhalt zu entfernen. Der folgende Python‑Code demonstriert, wie man eine Präsentation ohne eingebettete Binärinhalte lädt:
```py
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("malware.ppt", load_options) as presentation:
    # Vorgänge an der Präsentation ausführen.
```


## **FAQ**

**Wie erkenne ich, dass eine Datei beschädigt ist und nicht geöffnet werden kann?**

Beim Laden erhalten Sie eine Parsing‑/Formatvalidierungs‑Ausnahme. Solche Fehler erwähnen häufig eine ungültige ZIP‑Struktur oder beschädigte PowerPoint‑Datensätze.

**Was passiert, wenn beim Öffnen erforderliche Schriftarten fehlen?**

Die Datei wird geöffnet, aber später beim [rendering/export](/slides/de/python-net/convert-presentation/) können Schriftarten ersetzt werden. [Configure font substitutions](/slides/de/python-net/font-substitution/) oder [add the required fonts](/slides/de/python-net/custom-font/) in die Laufzeitumgebung einbinden.

**Was passiert mit eingebetteten Medien (Video/Audio) beim Öffnen?**

Sie stehen als Präsentations‑Ressourcen zur Verfügung. Wenn Medien über externe Pfade referenziert werden, stellen Sie sicher, dass diese Pfade in Ihrer Umgebung zugänglich sind; andernfalls kann das [rendering/export](/slides/de/python-net/convert-presentation/) die Medien weglassen.