---
title: Präsentation speichern
type: docs
weight: 80
url: /androidjava/save-presentation/
---

## **Übersicht**
{{% alert color="primary" %}} 

[Öffnen der Präsentation](/slides/androidjava/open-presentation/) beschreibt, wie man die [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse verwendet, um eine Präsentation zu öffnen. Dieser Artikel erklärt, wie man Präsentationen erstellt und speichert.

{{% /alert %}} 

Die [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse enthält den Inhalt einer Präsentation. Ob man eine Präsentation von Grund auf neu erstellt oder eine vorhandene bearbeitet, am Ende möchte man die Präsentation speichern. Mit Aspose.Slides für Android über Java kann sie als **Datei** oder **Stream** gespeichert werden. Dieser Artikel erklärt, wie man eine Präsentation auf verschiedene Arten speichert:

## **Präsentation in Datei speichern**
Speichern Sie eine Präsentation in einer Datei, indem Sie die [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse Methode [**Save**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) aufrufen. Übergeben Sie einfach den Dateinamen und das [**SaveFormat**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SaveFormat) an die [**Save**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) Methode.

Die folgenden Beispiele zeigen, wie man eine Präsentation mit Aspose.Slides für Android über Java speichert.

```java
// Instanziiere ein Präsentationsobjekt, das eine PPT-Datei repräsentiert
Presentation pres = new Presentation();
try {
    // ...mache hier etwas Arbeit...
    
    // Speichern Sie Ihre Präsentation in einer Datei
    pres.save("demoPass.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    if(pres != null) pres.dispose();
}
```

## **Präsentation in Stream speichern**
Es ist möglich, eine Präsentation in einem Stream zu speichern, indem man einen Ausgabestream an die [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse Methode [**Save**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.io.OutputStream-int-) übergibt. Es gibt viele Arten von Streams, in die eine Präsentation gespeichert werden kann. Im folgenden Beispiel haben wir eine neue Präsentationsdatei erstellt, Text in eine Form hinzugefügt und die Präsentation im Stream gespeichert.

```java
// Instanziiere ein Präsentationsobjekt, das eine PPT-Datei repräsentiert
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 200, 200);

    // Fügen Sie Text zur Form hinzu
    shape.getTextFrame().setText("Diese Demo zeigt, wie man eine PowerPoint-Datei erstellt und sie in einen Stream speichert.");

    OutputStream os = new FileOutputStream("Save_As_Stream_out.pptx");

    pres.save(os, com.aspose.slides.SaveFormat.Pptx);

    os.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Präsentation mit vordefiniertem Ansichts-Typ speichern**
Aspose.Slides für Android über Java bietet die Möglichkeit, den Ansichts-Typ für die generierte Präsentation festzulegen, wenn sie in PowerPoint geöffnet wird, über die [ViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties) Klasse. Die [**setLastView**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties#setLastView-int-) Eigenschaft wird verwendet, um den Ansichts-Typ mithilfe des [**ViewType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewType) Enumerators festzulegen.

```java
// Öffnen der Präsentationsdatei
Presentation pres = new Presentation();
try {
    // Festlegen des Ansichts-Typs
    pres.getViewProperties().setLastView((byte) ViewType.SlideMasterView);
    
    // Speichern der Präsentation
    pres.save("newDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Speichern von Präsentationen im strengen Office Open XML-Format**
Aspose.Slides ermöglicht es Ihnen, die Präsentation im strengen Office Open XML-Format zu speichern. Zu diesem Zweck bietet es die [**PptxOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxoptions) Klasse, in der Sie die Conformance-Eigenschaft beim Speichern der Präsentationsdatei festlegen können. Wenn Sie ihren Wert auf [**Conformance.Iso29500_2008_Strict**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Conformance#Iso29500_2008_Strict) setzen, wird die Ausgabedatei der Präsentation im strengen Open XML-Format gespeichert.

Der folgende Beispielcode erstellt eine Präsentation und speichert sie im strengen Office Open XML-Format. Beim Aufruf der [**Save**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) Methode für die Präsentation wird das [**PptxOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxoptions) Objekt mit der Conformance-Eigenschaft gesetzt auf [**Conformance.Iso29500_2008_Strict**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Conformance#Iso29500_2008_Strict).

```java
// Instanziiere ein Präsentationsobjekt, das eine PPT-Datei repräsentiert
Presentation pres = new Presentation();
try {
    // Hole die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Füge eine Auto-Form vom Typ Linie hinzu
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    //Festlegen der Speicheroptionen im strengen Office Open XML-Format
    PptxOptions options = new PptxOptions();
    options.setConformance(Conformance.Iso29500_2008_Strict);
    
    // Speichern Sie Ihre Präsentation in einer Datei
    pres.save("demoPass.pptx", SaveFormat.Pptx, options);
} finally {
    if (pres != null) pres.dispose();
}

```

## **Speichern von Präsentationen im Office Open XML-Format im Zip64-Modus**

Eine Office Open XML-Datei ist ein ZIP-Archiv, das eine Grenze von 4 GB (2^32 Bytes) für die unkomprimierte Größe einer Datei, die komprimierte Größe einer Datei und die Gesamgröße des Archivs hat, sowie eine Grenze von 65.535 (2^16-1) Dateien im Archiv. ZIP64-Format-Erweiterungen erhöhen die Grenzen auf 2^64.

Die neue [**IPptxOptions.Zip64Mode**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zip64mode/) Eigenschaft ermöglicht es Ihnen, zu wählen, wann ZIP64-Format-Erweiterungen für die gespeicherte Office Open XML-Datei verwendet werden sollen.

Diese Eigenschaft bietet die folgenden Modi:

- [Zip64Mode.IfNecessary](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zip64mode/#IfNecessary) bedeutet, dass ZIP64-Format-Erweiterungen nur verwendet werden, wenn die Präsentation außerhalb der oben genannten Einschränkungen fällt. Dies ist der Standardmodus.
- [Zip64Mode.Never](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zip64mode/#Never) bedeutet, dass ZIP64-Format-Erweiterungen nicht verwendet werden.
- [Zip64Mode.Always](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zip64mode/#Always) bedeutet, dass ZIP64-Format-Erweiterungen immer verwendet werden.

Der folgende Code demonstriert, wie man die Präsentation im PPTX-Format mit ZIP64-Format-Erweiterungen speichert:

```java
Presentation pres = new Presentation("Sample.pptx");
try {
    PptxOptions pptxOptions = new PptxOptions();
    pptxOptions.setZip64Mode(Zip64Mode.Always);
    
    pres.save("Sample-zip64.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="HINWEIS" color="warning" %}}

Das Speichern im Zip64Mode.Never Modus wirft eine [PptxException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxexception/), wenn die Präsentation nicht im ZIP32-Format gespeichert werden kann.

{{% /alert %}}

## **Speichern von Fortschrittsaktualisierungen in Prozent**
Das neue [**IProgressCallback**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProgressCallback) Interface wurde dem [**ISaveOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISaveOptions) Interface und der [**SaveOptions** ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SaveOptions) abstrakten Klasse hinzugefügt. Das [**IProgressCallback**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProgressCallback) Interface repräsentiert ein Callback-Objekt für das Speichern von Fortschrittsaktualisierungen in Prozent.  

Die folgenden Code-Beispiele zeigen, wie man das [IProgressCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProgressCallback) Interface verwendet:

```java
// Öffnen der Präsentationsdatei
Presentation pres = new Presentation("ConvertToPDF.pptx");
try {
    ISaveOptions saveOptions = new PdfOptions();
    saveOptions.setProgressCallback((IProgressCallback) new ExportProgressHandler());
    pres.save("ConvertToPDF.pdf", SaveFormat.Pdf, saveOptions);
} finally {
    pres.dispose();
}
```
```java
class ExportProgressHandler implements IProgressCallback 
{
    public void reporting(double progressValue) 
	{
        // Verwenden Sie hier den Fortschrittsprozentsatz
        int progress = Double.valueOf(progressValue).intValue();
        System.out.println(progress + "% Datei konvertiert");
    }
}
```

{{% alert title="Info" color="info" %}}

Mithilfe seiner eigenen API entwickelte Aspose eine [kostenlose PowerPoint-Splitter-App](https://products.aspose.app/slides/splitter), die es Nutzern ermöglicht, ihre Präsentationen in mehrere Dateien zu teilen. Im Wesentlichen speichert die App ausgewählte Folien aus einer bestimmten Präsentation als neue PowerPoint (PPTX oder PPT) Dateien. 

{{% /alert %}}