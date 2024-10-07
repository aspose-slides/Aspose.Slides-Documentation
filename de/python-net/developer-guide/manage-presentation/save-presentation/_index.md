---
title: Präsentation speichern
type: docs
weight: 80
url: /python-net/save-presentation/
keywords: "PowerPoint speichern, PPT, PPTX, Präsentation speichern, Datei, Stream, Python"
description: "PowerPoint-Präsentation als Datei oder Stream in Python speichern"
---

## **Präsentation speichern**
In "Eine Präsentation öffnen" wurde beschrieben, wie man die [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse verwendet, um eine Präsentation zu öffnen. Dieser Artikel erklärt, wie man Präsentationen erstellt und speichert. 
Die [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse enthält den Inhalt einer Präsentation. Ob man eine Präsentation von Grund auf neu erstellt oder eine vorhandene bearbeitet, will man sie am Ende speichern. Mit Aspose.Slides für Python via .NET kann sie als **Datei** oder **Stream** gespeichert werden. In diesem Artikel wird erklärt, wie man eine Präsentation auf verschiedene Arten speichert:

### **Präsentation in Dateien speichern**
Speichern Sie eine Präsentation in Dateien, indem Sie die [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse und die [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Methode aufrufen. Übergeben Sie einfach den Dateinamen und das Speicherformat an die [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Methode. Die folgenden Beispiele zeigen, wie man eine Präsentation mit Aspose.Slides für Python via .NET mit Python speichert.

```py
import aspose.slides as slides

# Instanziieren Sie ein Presentation-Objekt, das eine PPT-Datei darstellt
with slides.Presentation() as presentation:
    
    #...hier etwas Arbeit leisten...

    # Speichern Sie Ihre Präsentation in einer Datei
    presentation.save("Saved_out.pptx", slides.export.SaveFormat.PPTX)
```


### **Präsentation in Streams speichern**
Es ist möglich, eine Präsentation in einem Stream zu speichern, indem man einen Ausgabe-Stream an die [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse Save-Methode übergibt. Es gibt viele Arten von Streams, in die eine Präsentation gespeichert werden kann. Im folgenden Beispiel haben wir eine neue Präsentationsdatei erstellt, Text in eine Form eingefügt und die Präsentation im Stream gespeichert.

```py
import aspose.slides as slides

# Instanziieren Sie ein Presentation-Objekt, das eine PPT-Datei darstellt
with slides.Presentation() as presentation:
    
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 200, 200)

    # Speichern Sie Ihre Präsentation in einem Stream
    with open("Save_As_Stream_out.pptx", "bw") as stream:
        presentation.save(stream, slides.export.SaveFormat.PPTX)
```


### **Präsentationen mit vordefiniertem Ansichtstyp speichern**
Aspose.Slides für Python via .NET bietet die Möglichkeit, den Ansichtstyp für die generierte Präsentation festzulegen, wenn sie in PowerPoint über die [view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) Klasse geöffnet wird. Die [last_view](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) Eigenschaft wird verwendet, um den Ansichtstyp mit dem [ViewType](https://reference.aspose.com/slides/python-net/aspose.slides/viewtype/) Enumerator festzulegen.

```py
import aspose.slides as slides

# Instanziieren Sie ein Presentation-Objekt, das eine PPT-Datei darstellt
with slides.Presentation() as presentation:
    
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("pres-will-open-SlideMasterView.pptx", slides.export.SaveFormat.PPTX)

```

### **Präsentationen im strengen Office Open XML-Format speichern**
Aspose.Slides ermöglicht es Ihnen, die Präsentation im strengen Office Open XML-Format zu speichern. Zu diesem Zweck stellt es die [**PptxOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/) Klasse bereit, in der Sie die Konformitätseigenschaft beim Speichern der Präsentationsdatei festlegen können. Wenn Sie ihren Wert auf Conformance.Iso29500_2008_Strict setzen, wird die Ausgabedatei der Präsentation im strengen Office Open XML-Format gespeichert.

Der folgende Beispielcode erstellt eine Präsentation und speichert sie im strengen Office Open XML-Format. Beim Aufruf der Save-Methode für die Präsentation wird das **[PptxOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/)** Objekt mit der [**Conformance** ](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/) Eigenschaft übergeben, die auf [**Conformance.Iso29500_2008_Strict**](https://reference.aspose.com/slides/python-net/aspose.slides.export/conformance/) gesetzt ist.

```py
import aspose.slides as slides

# Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
with slides.Presentation() as presentation:
    # Holen Sie sich die erste Folie
    slide = presentation.slides[0]

    #Fügen Sie eine Autoshape vom Typ Linie hinzu
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    options = slides.export.PptxOptions()
    options.conformance = slides.export.Conformance.ISO29500_2008_STRICT

    # Speichern Sie die Präsentation im strengen Office Open XML-Format
    presentation.save("NewPresentation_out.pptx", slides.export.SaveFormat.PPTX, options)

```


### **Speichern von Fortschrittsaktualisierungen in Prozent**
Das neue [**IProgressCallback** ](https://reference.aspose.com/slides/python-net/aspose.slides/iprogresscallback/) Interface wurde hinzugefügt zum [**ISaveOptions** ](https://reference.aspose.com/slides/python-net/aspose.slides.export/isaveoptions/) Interface und zur [**SaveOptions** ](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveoptions/) abstrakten Klasse. Die **IProgressCallback** Schnittstelle stellt ein Rückruffobjekt für das Speichern von Fortschrittsaktualisierungen in Prozent dar.

Die folgenden Codebeispiele zeigen, wie man die IProgressCallback-Schnittstelle verwendet:

```py
# [TODO[not_supported_yet]: python implementierung von .net-schnittstellen]
```

{{% alert title="Info" color="info" %}}

Mit seiner eigenen API entwickelte Aspose eine [kostenlose PowerPoint-Splitter-App](https://products.aspose.app/slides/splitter), die es Benutzern ermöglicht, ihre Präsentationen in mehrere Dateien zu splitten. Im Wesentlichen speichert die App ausgewählte Folien aus einer gegebenen Präsentation als neue PowerPoint (PPTX oder PPT) Dateien. 

{{% /alert %}}