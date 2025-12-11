---
title: Präsentationen auf Android öffnen
linktitle: Präsentation öffnen
type: docs
weight: 20
url: /de/androidjava/open-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Öffnen Sie PowerPoint (.pptx, .ppt) und OpenDocument (.odp) Präsentationen mühelos mit Aspose.Slides für Android via Java – schnell, zuverlässig, voll funktionsfähig."
---

## **Übersicht**

Neben dem Erstellen von PowerPoint-Präsentationen von Grund auf ermöglicht Aspose.Slides auch das Öffnen vorhandener Präsentationen. Nachdem Sie eine Präsentation geladen haben, können Sie Informationen darüber abrufen, Folieninhalte bearbeiten, neue Folien hinzufügen, bestehende entfernen und vieles mehr.

## **Präsentationen öffnen**

Um eine vorhandene Präsentation zu öffnen, instanziieren Sie die [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)‑Klasse und übergeben den Dateipfad an deren Konstruktor.

Das folgende Java‑Beispiel zeigt, wie Sie eine Präsentation öffnen und die Folienanzahl ermitteln:
```java
// Instanziieren Sie die Presentation-Klasse und übergeben Sie einen Dateipfad an deren Konstruktor.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // Geben Sie die Gesamtzahl der Folien in der Präsentation aus.
    System.out.println(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```


## **Passwortgeschützte Präsentationen öffnen**

Wenn Sie eine passwortgeschützte Präsentation öffnen müssen, übergeben Sie das Passwort über die [setPassword](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-)‑Methode der [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/)‑Klasse, um sie zu entschlüsseln und zu laden. Der folgende Java‑Code demonstriert diesen Vorgang:
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
try {
    // Vorgänge an der entschlüsselten Präsentation ausführen.
} finally {
    presentation.dispose();
}
```


## **Große Präsentationen öffnen**

Aspose.Slides bietet Optionen – insbesondere die [getBlobManagementOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--)‑Methode in der [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/)‑Klasse – um das Laden großer Präsentationen zu unterstützen.

Der folgende Java‑Code demonstriert das Laden einer großen Präsentation (z. B. 2 GB):
```java
final String filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions();
// Wählen Sie das KeepLocked-Verhalten – die Präsentationsdatei bleibt für die Lebensdauer der
// Presentation-Instanz gesperrt, muss jedoch nicht in den Speicher geladen oder in eine temporäre Datei kopiert werden.
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    // Die große Präsentation wurde geladen und kann verwendet werden, während der Speicherverbrauch niedrig bleibt.

    // Änderungen an der Präsentation vornehmen.
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // Die Präsentation in einer anderen Datei speichern. Der Speicherverbrauch bleibt während dieses Vorgangs niedrig.
    presentation.save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // Nicht tun! Eine I/O-Ausnahme wird ausgelöst, weil die Datei gesperrt ist, bis das Präsentationsobjekt freigegeben wird.
    //Files.delete(Paths.get(filePath));
} finally {
    presentation.dispose();
}

// Es ist hier in Ordnung. Die Quelldatei ist nicht mehr durch das Präsentationsobjekt gesperrt.
Files.delete(Paths.get(filePath));
```


{{% alert color="info" title="Info" %}}
Um bestimmte Einschränkungen beim Arbeiten mit Streams zu umgehen, kann Aspose.Slides den Inhalt eines Streams kopieren. Das Laden einer großen Präsentation aus einem Stream führt dazu, dass die Präsentation kopiert wird, was das Laden verlangsamen kann. Deshalb empfehlen wir, beim Laden großer Präsentationen unbedingt den Dateipfad der Präsentation statt eines Streams zu verwenden.

Wenn Sie eine Präsentation erstellen, die große Objekte (Video, Audio, hochauflösende Bilder usw.) enthält, können Sie das [BLOB‑Management](/slides/de/androidjava/manage-blob/) nutzen, um den Speicherverbrauch zu reduzieren.
{{%/alert %}}

## **Externe Ressourcen steuern**

Aspose.Slides stellt die Schnittstelle [IResourceLoadingCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iresourceloadingcallback/) bereit, mit der Sie externe Ressourcen verwalten können. Der folgende Java‑Code zeigt, wie Sie das `IResourceLoadingCallback`‑Interface verwenden:
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
                // Lade ein Ersatzbild.
                byte[] imageData = getImageBytes("aspose-logo.jpg"); // Verwenden Sie eine beliebige Methode, um die Bytes zu erhalten
                args.setData(imageData);
                return ResourceLoadingAction.UserProvided;
            } catch (RuntimeException ex) {
                return ResourceLoadingAction.Skip;
            }  catch (IOException ex) {
                ex.printStackTrace();
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // Setze eine Ersatz-URL.
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction.Default;
        }
        // Alle anderen Bilder überspringen.
        return ResourceLoadingAction.Skip;
    }
}
```


## **Präsentationen ohne eingebettete Binärobjekte laden**

Eine PowerPoint‑Präsentation kann folgende Arten eingebetteter Binärobjekte enthalten:

- VBA‑Projekt (zugänglich über [IPresentation.getVbaProject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getVbaProject--));
- OLE‑Objekt‑eingebettete Daten (zugänglich über [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--));
- ActiveX‑Steuerungs‑Binärdaten (zugänglich über [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getActiveXControlBinary--)).

Durch die Methode [ILoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) können Sie eine Präsentation ohne eingebettete Binärobjekte laden.

Diese Methode ist nützlich, um potenziell schädliche Binärinhalte zu entfernen. Der folgende Java‑Code demonstriert das Laden einer Präsentation ohne eingebettete Binärinhalte:
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

Während des Ladens erhalten Sie eine Parsing‑/Format‑Validierungs‑Ausnahme. Solche Fehler erwähnen häufig eine ungültige ZIP‑Struktur oder beschädigte PowerPoint‑Einträge.

**Was passiert, wenn beim Öffnen erforderliche Schriftarten fehlen?**

Die Datei wird geöffnet, aber beim späteren [Rendern/Exportieren](/slides/de/androidjava/convert-presentation/) können Schriftarten substituiert werden. [Schriftart‑Substitutionen konfigurieren](/slides/de/androidjava/font-substitution/) oder [die benötigten Schriftarten hinzufügen](/slides/de/androidjava/custom-font/) in der Laufzeitumgebung.

**Wie wird mit eingebetteten Medien (Video/Audio) beim Öffnen umgegangen?**

Sie werden als Präsentations‑Ressourcen verfügbar. Wenn Medien über externe Pfade referenziert werden, stellen Sie sicher, dass diese Pfade in Ihrer Umgebung zugänglich sind; andernfalls kann das [Rendern/Exportieren](/slides/de/androidjava/convert-presentation/) die Medien weglassen.