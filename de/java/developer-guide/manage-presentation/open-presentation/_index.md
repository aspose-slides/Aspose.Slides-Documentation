---
title: Präsentationen in Java öffnen
linktitle: Präsentation öffnen
type: docs
weight: 20
url: /de/java/open-presentation/
keywords:
- PowerPoint öffnen
- OpenDocument öffnen
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
- Java
- Aspose.Slides
description: "Öffnen Sie PowerPoint (.pptx, .ppt) und OpenDocument (.odp) Präsentationen mühelos mit Aspose.Slides für Java – schnell, zuverlässig, voll funktionsfähig."
---

## **Übersicht**

Neben dem Erstellen von PowerPoint‑Präsentationen von Grund auf ermöglicht Aspose.Slides auch das Öffnen vorhandener Präsentationen. Nachdem Sie eine Präsentation geladen haben, können Sie Informationen darüber abrufen, Folieninhalte bearbeiten, neue Folien hinzufügen, vorhandene entfernen und vieles mehr.

## **Präsentationen öffnen**

Um eine vorhandene Präsentation zu öffnen, instanziieren Sie die [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)-Klasse und übergeben Sie ihr den Dateipfad im Konstruktor.

Das folgende Java‑Beispiel zeigt, wie eine Präsentation geöffnet und die Folienanzahl ermittelt wird:
```java
// Instanziieren Sie die Presentation-Klasse und übergeben Sie ihr einen Dateipfad im Konstruktor.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // Geben Sie die Gesamtzahl der Folien in der Präsentation aus.
    System.out.println(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```


## **Kennwortgeschützte Präsentationen öffnen**

Wenn Sie eine kennwortgeschützte Präsentation öffnen müssen, übergeben Sie das Kennwort über die [setPassword](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-)-Methode der [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/)-Klasse, um sie zu entschlüsseln und zu laden. Der folgende Java‑Code demonstriert diesen Vorgang:
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
try {
    // Führen Sie Operationen an der entschlüsselten Präsentation aus.
} finally {
    presentation.dispose();
}
```


## **Große Präsentationen öffnen**

Aspose.Slides stellt Optionen bereit – insbesondere die [getBlobManagementOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--)‑Methode in der [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/)-Klasse – um Ihnen beim Laden großer Präsentationen zu helfen.

Der folgende Java‑Code zeigt das Laden einer großen Präsentation (zum Beispiel 2 GB):
```java
final String filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions();
// Wählen Sie das KeepLocked-Verhalten – die Präsentationsdatei bleibt für die gesamte Lebensdauer von
// der Presentation-Instanz gesperrt, muss jedoch nicht in den Speicher geladen oder in eine temporäre Datei kopiert werden.
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    // Die große Präsentation wurde geladen und kann verwendet werden, während der Speicherverbrauch gering bleibt.

    // Änderungen an der Präsentation vornehmen.
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // Speichern Sie die Präsentation in eine andere Datei. Der Speicherverbrauch bleibt während dieses Vorgangs gering.
    presentation.save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // Machen Sie das nicht! Es wird eine I/O-Ausnahme ausgelöst, weil die Datei gesperrt ist, bis das Präsentationsobjekt freigegeben wird.
    //Files.delete(Paths.get(filePath));
} finally {
    presentation.dispose();
}

// Hier ist es in Ordnung, dies zu tun. Die Quelldatei ist nicht mehr durch das Präsentationsobjekt gesperrt.
Files.delete(Paths.get(filePath));
```


{{% alert color="info" title="Info" %}}
Um bestimmte Einschränkungen beim Arbeiten mit Streams zu umgehen, kann Aspose.Slides den Inhalt eines Streams kopieren. Das Laden einer großen Präsentation aus einem Stream führt dazu, dass die Präsentation kopiert wird und das Laden verlangsamen kann. Daher empfehlen wir dringend, beim Laden einer großen Präsentation den Dateipfad anstelle eines Streams zu verwenden.

Wenn Sie eine Präsentation erstellen, die große Objekte (Video, Audio, hochauflösende Bilder usw.) enthält, können Sie das [BLOB‑Management](/slides/de/java/manage-blob/) nutzen, um den Speicherverbrauch zu reduzieren.
{{%/alert %}}

## **Externe Ressourcen steuern**

Aspose.Slides bietet das [IResourceLoadingCallback](https://reference.aspose.com/slides/java/com.aspose.slides/iresourceloadingcallback/)-Interface, mit dem Sie externe Ressourcen verwalten können. Der folgende Java‑Code zeigt, wie das `IResourceLoadingCallback`‑Interface verwendet wird:
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setResourceLoadingCallback(new ImageLoadingHandler());

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
```

```java
class ImageLoadingHandler implements IResourceLoadingCallback {
    public int resourceLoading(IResourceLoadingArgs args) {
        if (args.getOriginalUri().endsWith(".jpg")) {
            try {
                // Ein Ersatzbild laden.
                byte[] imageData = Files.readAllBytes(new File("aspose-logo.jpg").toPath());
                args.setData(imageData);
                return ResourceLoadingAction.UserProvided;
            } catch (RuntimeException ex) {
                return ResourceLoadingAction.Skip;
            }  catch (IOException ex) {
                ex.printStackTrace();
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // Eine Ersatz-URL setzen.
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction.Default;
        }
        // Alle anderen Bilder überspringen.
        return ResourceLoadingAction.Skip;
    }
}
```


## **Präsentationen ohne eingebettete Binärobjekte laden**

Eine PowerPoint‑Präsentation kann folgende Arten von eingebetteten Binärobjekten enthalten:

- VBA‑Projekt (zugänglich über [IPresentation.getVbaProject](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getVbaProject--));
- OLE‑Objekt‑eingebettete Daten (zugänglich über [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--));
- ActiveX‑Steuerungs‑Binärdaten (zugänglich über [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getActiveXControlBinary--)).

Mit der [ILoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-)‑Methode können Sie eine Präsentation laden, ohne eingebettete Binärobjekte zu übernehmen.

Diese Methode ist nützlich, um potenziell schädliche Binärinhalte zu entfernen. Der folgende Java‑Code demonstriert, wie Sie eine Präsentation ohne eingebettete Binärinhalte laden:
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation presentation = new Presentation("malware.ppt", loadOptions);
try {
    // Vorgänge an der Präsentation ausführen.
} finally {
    presentation.dispose();
}
```


## **FAQ**

**Wie kann ich erkennen, dass eine Datei beschädigt ist und nicht geöffnet werden kann?**

Beim Laden erhalten Sie eine Parsing‑/Format‑Validierungs‑Exception. Solche Fehler erwähnen häufig eine ungültige ZIP‑Struktur oder beschädigte PowerPoint‑Datensätze.

**Was passiert, wenn beim Öffnen erforderliche Schriftarten fehlen?**

Die Datei wird geöffnet, aber beim anschließenden [Rendern/Exportieren](/slides/de/java/convert-presentation/) können Schriftarten substituiert werden. [Schriftart‑Substitutionen konfigurieren](/slides/de/java/font-substitution/) oder [die erforderlichen Schriftarten hinzufügen](/slides/de/java/custom-font/) in der Laufzeitumgebung.

**Wie werden beim Öffnen eingebettete Medien (Video/Audio) behandelt?**

Sie werden als Präsentations‑Ressourcen verfügbar. Wenn Medien über externe Pfade referenziert werden, stellen Sie sicher, dass diese Pfade in Ihrer Umgebung erreichbar sind; andernfalls kann das [Rendern/Exportieren](/slides/de/java/convert-presentation/) die Medien weglassen.