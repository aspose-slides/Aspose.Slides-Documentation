---
title: Präsentation in Java öffnen
linktitle: Präsentation öffnen
type: docs
weight: 20
url: /de/java/open-presentation/
keywords: "PowerPoint öffnen, PPTX, PPT, Präsentation öffnen, Präsentation laden, Java"
description: "Präsentation PPT, PPTX, ODP in Java öffnen oder laden"
---

Neben der Erstellung von PowerPoint-Präsentationen von Grund auf ermöglicht Aspose.Slides das Öffnen vorhandener Präsentationen. Nachdem Sie eine Präsentation geladen haben, können Sie Informationen über die Präsentation abrufen, die Präsentation bearbeiten (Inhalte auf ihren Folien), neue Folien hinzufügen oder vorhandene entfernen usw.

## Präsentation öffnen

Um eine vorhandene Präsentation zu öffnen, müssen Sie einfach die [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) Klasse instanziieren und den Dateipfad (der Präsentation, die Sie öffnen möchten) an den Konstruktor übergeben.

Dieser Java-Code zeigt Ihnen, wie Sie eine Präsentation öffnen und auch die Anzahl der Folien, die sie enthält, herausfinden können:

```java
// Instanziiert die Presentation-Klasse und übergibt den Dateipfad an den Konstruktor
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Gibt die Gesamtzahl der Folien in der Präsentation aus
    System.out.println(pres.getSlides().size());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Passwortgeschützte Präsentation öffnen**

Wenn Sie eine passwortgeschützte Präsentation öffnen müssen, können Sie das Passwort über die [Password](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#getPassword--) Eigenschaft (der [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/) Klasse) übergeben, um die Präsentation zu entschlüsseln und zu laden. Dieser Java-Code demonstriert die Operation:

```java
 LoadOptions loadOptions = new LoadOptions();
 loadOptions.setPassword("DEIN_PASSWORT");
 Presentation pres = new Presentation("pres.pptx", loadOptions);
 try {
 // Führen Sie einige Arbeiten mit der entschlüsselten Präsentation durch
 } finally {
     if (pres != null) pres.dispose();
 }
```

## Große Präsentation öffnen

Aspose.Slides bietet Optionen (insbesondere die [BlobManagementOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setBlobManagementOptions-com.aspose.slides.IBlobManagementOptions-) Eigenschaft) unter der [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/LoadOptions) Klasse, um das Laden großer Präsentationen zu ermöglichen.

Dieser Java-Code demonstriert eine Operation, in der eine große Präsentation (sagen wir 2 GB groß) geladen wird:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(0L);

Presentation pres = new Presentation("veryLargePresentation.pptx", loadOptions);
try {
    // Die große Präsentation wurde geladen und kann verwendet werden, aber der Speicherverbrauch bleibt niedrig.
    // Änderungen an der Präsentation vornehmen.
    pres.getSlides().get_Item(0).setName("Sehr große Präsentation");

    // Die Präsentation wird in die andere Datei gespeichert. Der Speicherverbrauch bleibt während der Operation niedrig
    pres.save("veryLargePresentation-copy.pptx", SaveFormat.Pptx);
} finally {
    if(pres != null) pres.dispose();
}
```

{{% alert color="info" title="Info" %}}

Um bestimmte Einschränkungen beim Arbeiten mit einem Stream zu umgehen, kann Aspose.Slides den Inhalt des Streams kopieren. Das Laden einer großen Präsentation über ihren Stream führt zu einer Kopie der Inhalte der Präsentation und verursacht ein langsames Laden. Daher empfehlen wir dringend, beim Laden einer großen Präsentation den Dateipfad der Präsentation und nicht ihren Stream zu verwenden.

Wenn Sie eine Präsentation erstellen möchten, die große Objekte (Video, Audio, große Bilder usw.) enthält, können Sie die [Blob-Funktion](https://docs.aspose.com/slides/java/manage-blob/) verwenden, um den Speicherverbrauch zu reduzieren.

{{%/alert %}} 

## Präsentation laden

Aspose.Slides bietet [IResourceLoadingCallback](https://reference.aspose.com/slides/java/com.aspose.slides/iresourceloadingcallback/) mit einer einzelnen Methode, um externe Ressourcen zu verwalten. Dieser Java-Code zeigt Ihnen, wie Sie das `IResourceLoadingCallback`-Interface verwenden:

```java
LoadOptions opts = new LoadOptions();
opts.setResourceLoadingCallback(new ImageLoadingHandler());

Presentation pres = new Presentation("presentation.pptx", opts);
```

```java
class ImageLoadingHandler implements IResourceLoadingCallback 
{
    public int resourceLoading(IResourceLoadingArgs args) 
    {
        if (args.getOriginalUri().endsWith(".jpg")) 
        {
            try // lädt das Ersatzbild
            {
                byte[] imageBytes = Files.readAllBytes(new File("aspose-logo.jpg").toPath());
                args.setData(imageBytes);
                return ResourceLoadingAction.UserProvided;
            } catch (RuntimeException ex) {
                return ResourceLoadingAction.Skip;
            }  catch (IOException ex) {
                ex.printStackTrace();
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // setzt die Ersatz-URL
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction.Default;
        }
        // überspringt alle anderen Bilder
        return ResourceLoadingAction.Skip;
    }
}
```

## Präsentation ohne eingebettete Binärobjekte laden

Die PowerPoint-Präsentation kann die folgenden Typen von eingebetteten Binärobjekten enthalten:

- VBA-Projekt ([IPresentation.VbaProject](https://reference.aspose.com/slides/java/com.aspose.slides/vbaproject/));
- OLE-Objekt eingebettete Daten ([IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--));
- ActiveX-Steuerelemente Binärdaten ([IControl.ActiveXControlBinary](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getActiveXControlBinary--));

Mit der [ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) Eigenschaft können Sie die Präsentation ohne eingebettete Binärobjekte laden.

Diese Eigenschaft kann nützlich sein, um potenziell schädliche Binärinhalte zu entfernen.

Der Code demonstriert, wie man eine Präsentation ohne Malware-Inhalte lädt und speichert:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation pres = new Presentation("malware.ppt", loadOptions);
try {
    pres.save("clean.ppt", SaveFormat.Ppt);
} finally {
    if (pres != null) pres.dispose();
}
```

## Präsentation öffnen und speichern

Schritte zum Öffnen und Speichern einer Präsentation:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse und übergeben Sie die Datei, die Sie öffnen möchten. 
2. Speichern Sie die Präsentation.

```java
// Instanziiert ein Presentation-Objekt, das eine PPT-Datei repräsentiert
Presentation pres = new Presentation();
try {
    // ...hier einige Arbeiten ausführen...
    
    // Speichert Ihre Präsentation in einer Datei
    pres.save("demoPass.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    if(pres != null) pres.dispose();
}
```