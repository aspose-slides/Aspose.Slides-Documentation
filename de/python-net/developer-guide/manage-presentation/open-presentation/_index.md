---
title: Präsentation öffnen
type: docs
weight: 20
url: /python-net/open-presentation/
keywords: "PowerPoint öffnen, PPTX, PPT, Präsentation öffnen, Präsentation laden, Python"
description: "Öffnen oder Laden von Präsentationen PPT, PPTX, ODP in Python"
---

Neben der Erstellung von PowerPoint-Präsentationen von Grund auf ermöglicht es Aspose.Slides, vorhandene Präsentationen zu öffnen. Nachdem Sie eine Präsentation geladen haben, können Sie Informationen über die Präsentation abrufen, die Präsentation bearbeiten (Inhalte auf den Folien), neue Folien hinzufügen oder vorhandene entfernen usw.

## Präsentation öffnen

Um eine vorhandene Präsentation zu öffnen, müssen Sie einfach die [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse instanziieren und den Datei-Pfad (der Präsentation, die Sie öffnen möchten) an ihren Konstruktor übergeben.

Dieser Python-Code zeigt Ihnen, wie Sie eine Präsentation öffnen und auch die Anzahl der enthaltenen Folien herausfinden können:

```python
import aspose.slides as slides

# Instanziiert die Presentation-Klasse und übergibt den Datei-Pfad an ihren Konstruktor
with slides.Presentation("pres.pptx") as pres:
    # Gibt die Gesamtzahl der Folien in der Präsentation aus
    print(pres.slides.length)
```

## **Passwortgeschützte Präsentation öffnen**

Wenn Sie eine passwortgeschützte Präsentation öffnen müssen, können Sie das Passwort über die `password`-Eigenschaft (aus der [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) Klasse) übergeben, um die Präsentation zu entschlüsseln und zu laden. Dieser Python-Code demonstriert die Operation:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "PASSWORD"
with slides.Presentation("pres.pptx", load_options) as pres:
    ...
```

## Große Präsentation öffnen

Aspose.Slides bietet Optionen (insbesondere die `blob_management_options`-Eigenschaft) unter der [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) Klasse, um Ihnen das Laden großer Präsentationen zu ermöglichen.

Dieser Python-Code demonstriert eine Operation, bei der eine große Präsentation (zum Beispiel 2 GB groß) geladen wird:

```python
import aspose.slides as slides
import os

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED

with slides.Presentation("pres.pptx", loadOptions) as pres:
    # Die große Präsentation wurde geladen und kann verwendet werden, aber der Speicherverbrauch bleibt niedrig.

    # Änderungen an der Präsentation vornehmen.
    pres.slides[0].name = "Sehr große Präsentation"

    # Die Präsentation wird in die andere Datei gespeichert. Der Speicherverbrauch bleibt während der Operation niedrig.
    pres.save("veryLargePresentation-copy.pptx", slides.export.SaveFormat.PPTX)

    # Das kann man nicht tun! Eine IO-Ausnahme wird ausgelöst, da die Datei gesperrt ist, während die pres-Objekte
    # nicht freigegeben werden.
    os.remove("pres.pptx")

# Es ist hier in Ordnung, dies zu tun. Die Quelldatei ist nicht durch das pres-Objekt gesperrt.
os.remove("pres.pptx")
```

{{% alert color="info" title="Info" %}}

Um bestimmte Einschränkungen beim Umgang mit Streams zu umgehen, kann Aspose.Slides den Inhalt des Streams kopieren. Das Laden einer großen Präsentation über ihren Stream führt dazu, dass der Inhalt der Präsentation kopiert wird und das Laden langsam wird. Daher empfehlen wir dringend, dass Sie beim Laden einer großen Präsentation den Datei-Pfad der Präsentation und nicht ihren Stream verwenden.

Wenn Sie eine Präsentation erstellen möchten, die große Objekte (Video, Audio, große Bilder usw.) enthält, können Sie die [Blob-Funktionalität](https://docs.aspose.com/slides/python-net/manage-blob/) verwenden, um den Speicherverbrauch zu reduzieren.

{{%/alert %}} 


## Präsentation laden

Aspose.Slides stellt [IResourceLoadingCallback](https://reference.aspose.com/slides/python-net/aspose.slides/iresourceloadingcallback/) mit einer einzigen Methode zur Verfügung, die es Ihnen ermöglicht, externe Ressourcen zu verwalten. Dieser Python-Code zeigt Ihnen, wie Sie die `IResourceLoadingCallback`-Schnittstelle verwenden:

```python
# [TODO[not_supported_yet]: python-Implementierung der .net-Schnittstellen]
```

<h2>Präsentation öffnen und speichern</h2>

<a name="python-net-open-save-presentation"><strong>Schritte: Präsentation in Python öffnen und speichern</strong></a>

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse und übergeben Sie die Datei, die Sie öffnen möchten. 
2. Speichern Sie die Präsentation. 

```python
import aspose.slides as slides

# Instanziiert ein Presentation-Objekt, das eine PPT-Datei darstellt
with slides.Presentation() as presentation:
    
    #...hier einige Arbeiten durchführen...

    # Speichern Sie Ihre Präsentation in einer Datei
    presentation.save("Saved_out.pptx", slides.export.SaveFormat.PPTX)
```