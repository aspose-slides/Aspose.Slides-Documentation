---
title: Präsentation in .NET speichern
linktitle: Präsentation speichern
type: docs
weight: 80
url: /net/save-presentation/
keywords: "PowerPoint speichern, PPT, PPTX, Präsentation speichern, Datei, Stream, C#, Csharp, .NET"
description: "PowerPoint-Präsentation als Datei oder Stream in C# oder .NET speichern"
---

## **Präsentation speichern**
Öffnen einer Präsentation beschreibt, wie die [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse verwendet wird, um eine Präsentation zu öffnen. Dieser Artikel erklärt, wie man Präsentationen erstellt und speichert. 
Die [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse enthält den Inhalt einer Präsentation. Egal, ob Sie eine Präsentation von Grund auf neu erstellen oder eine vorhandene ändern, am Ende möchten Sie die Präsentation speichern. Mit Aspose.Slides für .NET kann sie als **Datei** oder **Stream** gespeichert werden. Dieser Artikel erklärt, wie man eine Präsentation auf verschiedene Weise speichert:

### **Präsentation in Dateien speichern**
Speichern Sie eine Präsentation in Dateien, indem Sie die [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) Methode der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse aufrufen. Übergeben Sie einfach den Dateinamen und das Speicherformat an die [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) Methode. Die folgenden Beispiele zeigen, wie Sie eine Präsentation mit Aspose.Slides für .NET mit C# speichern können.

```c#
// Erstellen Sie ein Presentation-Objekt, das eine PPT-Datei darstellt
Presentation presentation= new Presentation();

//...hier arbeiten...

// Speichern Sie Ihre Präsentation in einer Datei
presentation.Save("Saved_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

### **Präsentation in Streams speichern**
Es ist möglich, eine Präsentation in einen Stream zu speichern, indem man einen Ausgabestream an die Save-Methode der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse übergibt. Es gibt viele Arten von Streams, in die eine Präsentation gespeichert werden kann. Im folgenden Beispiel haben wir eine neue Präsentationsdatei erstellt, Text in eine Form eingefügt und die Präsentation in den Stream gespeichert.

```c#
// Erstellen Sie ein Presentation-Objekt, das eine PPT-Datei darstellt
using (Presentation presentation = new Presentation())
{

    IAutoShape shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 200, 200);

    // Text zur Form hinzufügen
    shape.TextFrame.Text = "Dieses Beispiel zeigt, wie man eine PowerPoint-Datei erstellt und in einen Stream speichert.";

    FileStream toStream = new FileStream("Save_As_Stream_out.pptx", FileMode.Create);
    presentation.Save(toStream, Aspose.Slides.Export.SaveFormat.Pptx);
    toStream.Close();
}
```

### **Präsentationen mit vordefiniertem Ansichtstyp speichern**
Aspose.Slides für .NET bietet die Möglichkeit, den Ansichtstyp für die generierte Präsentation festzulegen, wenn sie in PowerPoint geöffnet wird, über die [ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties) Klasse. Die [LastView](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/properties/lastview) Eigenschaft wird verwendet, um den Ansichtstyp mit dem [ViewType](https://reference.aspose.com/slides/net/aspose.slides/viewtype) Enumerator festzulegen.

```csharp
using (Presentation pres = new Presentation())
{
    pres.ViewProperties.LastView = ViewType.SlideMasterView;
    pres.Save("pres-will-open-SlideMasterView.pptx", SaveFormat.Pptx);
}
```

### **Präsentationen im strengen Office Open XML-Format speichern**
Aspose.Slides ermöglicht es Ihnen, die Präsentation im strengen Office Open XML-Format zu speichern. Zu diesem Zweck bietet es die [**Aspose.Slides.Export.PptxOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/pptxoptions) Klasse, wo Sie die Eigenschaft Conformance festlegen können, während Sie die Präsentationsdatei speichern. Wenn Sie ihren Wert auf Conformance.Iso29500_2008_Strict setzen, wird die Ausgabedatei der Präsentation im strengen Office Open XML-Format gespeichert.

Der folgende Beispielcode erstellt eine Präsentation und speichert sie im strengen Office Open XML-Format. Während der Aufruf der Save-Methode für die Präsentation wird das **[Aspose.Slides.Export.PptxOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pptxoptions)** Objekt mit der [**Conformance**](https://reference.aspose.com/slides/net/aspose.slides.export/pptxoptions/properties/conformance) Eigenschaft, die auf **[Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/net/aspose.slides.export/conformance)** gesetzt ist, übergeben.

```csharp
   // Erstellen Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
   using (Presentation presentation = new Presentation())
   {
       // Holen Sie sich die erste Folie
       ISlide slide = presentation.Slides[0];

       // Fügen Sie eine Autoform vom Typ Linie hinzu
       slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

       // Speichern Sie die Präsentation im strengen Office Open XML-Format
       presentation.Save(dataDir + "NewPresentation_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx,
           new PptxOptions() { Conformance = Conformance.Iso29500_2008_Strict });

   }
```

### **Präsentationen im Office Open XML-Format im Zip64-Modus speichern**
Eine Office Open XML-Datei ist ein ZIP-Archiv, das eine Grenze von 4 GB (2^32 Bytes) für die unkomprimierte Größe einer Datei, die komprimierte Größe einer Datei und die Gesamtgröße des Archivs hat, sowie eine Grenze von 65.535 (2^16-1) Dateien im Archiv. Die ZIP64-Format-Erweiterungen erhöhen die Grenzen auf 2^64.

Die neue [**IPptxOptions.Zip64Mode**](https://reference.aspose.com/slides/net/aspose.slides.export/ipptxoptions/zip64mode/) Eigenschaft ermöglicht es Ihnen zu wählen, wann die ZIP64-Format-Erweiterungen für die gespeicherte Office Open XML-Datei verwendet werden sollen.

Diese Eigenschaft bietet die folgenden Modi:

- [Zip64Mode.IfNecessary](https://reference.aspose.com/slides/net/aspose.slides.export/zip64mode/) bedeutet, dass die ZIP64-Format-Erweiterungen nur verwendet werden, wenn die Präsentation außerhalb der oben genannten Einschränkungen fällt. Dies ist der Standardmodus.
- [Zip64Mode.Never](https://reference.aspose.com/slides/net/aspose.slides.export/zip64mode/) bedeutet, dass ZIP64-Format-Erweiterungen nicht verwendet werden.
- [Zip64Mode.Always](https://reference.aspose.com/slides/net/aspose.slides.export/zip64mode/) bedeutet, dass ZIP64-Format-Erweiterungen immer verwendet werden.

Der folgende C#-Code zeigt, wie man die Präsentation im PPTX-Format mit ZIP64-Format-Erweiterungen speichert:

```c#
using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-zip64.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        Zip64Mode = Zip64Mode.Always
    });
}
```

{{% alert title="HINWEIS" color="warning" %}}

Das Speichern im Zip64Mode.Never-Modus wirft eine [PptxException](https://reference.aspose.com/slides/net/aspose.slides/pptxexception/), wenn die Präsentation nicht im ZIP32-Format gespeichert werden kann.

{{% /alert %}}

### **Speichern von Fortschrittsaktualisierungen in Prozent**
Das neue [**IProgressCallback**](https://reference.aspose.com/slides/net/aspose.slides/iprogresscallback) Interface wurde dem [**ISaveOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/isaveoptions) Interface und der [**SaveOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions) abstrakten Klasse hinzugefügt. Das **IProgressCallback** Interface stellt ein Callback-Objekt für das Speichern von Fortschrittsaktualisierungen in Prozent dar.

Die folgenden Codebeispiele zeigen, wie das IProgressCallback-Interface verwendet wird:

```c#
using (Presentation presentation = new Presentation("ConvertToPDF.pptx"))
{
    ISaveOptions saveOptions = new PdfOptions();
    saveOptions.ProgressCallback = new ExportProgressHandler();
    presentation.Save("ConvertToPDF.pdf", SaveFormat.Pdf, saveOptions);
}
```

```c#
class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        // Verwenden Sie den Fortschrittsprozentsatz hier
        int progress = Convert.ToInt32(progressValue);
        Console.WriteLine(progress + "% Datei konvertiert");
    }
}
```

{{% alert title="Info" color="info" %}}

Mit seiner eigenen API hat Aspose eine [kostenlose PowerPoint-Splitter-App](https://products.aspose.app/slides/splitter) entwickelt, die es Benutzern ermöglicht, ihre Präsentationen in mehrere Dateien zu splitten. Im Wesentlichen speichert die App ausgewählte Folien aus einer bestimmten Präsentation als neue PowerPoint (PPTX oder PPT) Dateien. 

{{% /alert %}}

<h2>Öffnen und Speichern von Präsentationen</h2>

<a name="csharp-open-save-presentation"><strong>Schritte: Präsentation in C# öffnen und speichern</strong></a>

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) Klasse mit einem beliebigen Format, d.h. PPT, PPTX, ODP usw.
2. Speichern Sie _Präsentation_ in einem Format, das von [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/) unterstützt wird.

```c#
// Laden Sie eine unterstützte Datei in Presentation, z.B. ppt, pptx, odp usw.
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```