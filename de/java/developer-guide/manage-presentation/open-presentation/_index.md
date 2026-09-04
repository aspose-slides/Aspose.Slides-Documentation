---
title: Präsentationen in Java öffnen
linktitle: Präsentation öffnen
type: docs
weight: 20
url: /de/java/open-presentation/
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
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint- und OpenDocument-Präsentationen in Java öffnen, Öffnungspasswörter angeben, das Laden von Ressourcen steuern und den Speicherverbrauch mit Aspose.Slides für Java reduzieren."
---
## **Einleitung**

[Aspose.Slides für Java](https://products.aspose.com/slides/de/java/) kann PowerPoint‑ und OpenDocument‑Präsentationen aus Dateien und Streams laden. Nachdem eine Präsentation geladen wurde, können Sie ihre Struktur untersuchen, Folien bearbeiten, Ressourcen verwalten und sie im ursprünglichen oder einem anderen unterstützten Format speichern.

Das Ladeverhalten kann über die Klasse [LoadOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/loadoptions/) angepasst werden. Sie können zum Beispiel ein Öffnungspasswort angeben, große Binärobjekte außerhalb des Java‑Heap‑Speichers halten, externe Ressourcen steuern oder eingebettete Binärdaten weglassen.

## **Präsentationen öffnen**

Um eine vorhandene Präsentation zu öffnen, übergeben Sie ihr Dateipfad an den [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Konstruktor. Entsorgen Sie die Präsentation nach der Verwendung, damit Dateihandles, temporäre Daten und andere Ressourcen sofort freigegeben werden.

Das folgende Java‑Beispiel zeigt, wie eine Präsentation geöffnet und die Folienanzahl ermittelt wird:

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Passwortgeschützte Präsentationen öffnen**

Ein Öffnungspasswort verschlüsselt den Inhalt einer Präsentation. Um die gesamte Präsentation zu laden, übergeben Sie das korrekte Passwort an [LoadOptions.setPassword](https://reference.aspose.com/slides/de/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) und geben Sie die Optionen dem [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Konstruktor. Das Laden schlägt fehl, wenn das Passwort fehlt oder falsch ist.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-presentation.pptx", loadOptions);
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Für Passwort‑Erkennung, Validierung und Verschlüsselungs‑Workflows siehe [Password-Protect Presentations](/slides/de/java/password-protected-presentation/). Wenn eine verschlüsselte Präsentation bewusst mit öffentlichen Dokumenteneigenschaften gespeichert wurde, können diese Eigenschaften ohne Passwort gelesen werden; siehe [Manage Presentation Properties](/slides/de/java/presentation-properties/).

## **Große Präsentationen öffnen**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) gibt Optionen zurück, die steuern, wie Aspose.Slides große binäre Objekte wie Bilder, Audio und Video behandelt. Sie können die Quelldatei gesperrt halten, temporäre Dateien zulassen und die Menge der im Speicher behaltenen BLOB‑Daten begrenzen.

Der folgende Java‑Code demonstriert das Laden einer großen Präsentation (z. B. 2 GB):

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationLockingBehavior;
import com.aspose.slides.SaveFormat;

final String filePath = "large-presentation.pptx";

LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024);

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    presentation.getSlides().get_Item(0).setName("Large presentation");
    presentation.save("large-presentation-copy.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Hinweis" %}}
Mit [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentationlockingbehavior/#KeepLocked) bleibt die Quelldatei gesperrt, bis die Präsentationsinstanz entsorgt wird. Verschieben, überschreiben oder löschen Sie die Quelldatei nicht, solange diese Instanz aktiv ist.

Aspose.Slides kann beim Laden den Inhalt eines Input‑Streams kopieren. Für große Präsentationen ist daher ein Dateipfad im Allgemeinen effizienter als ein Stream. Siehe [Manage BLOBs](/slides/de/java/manage-blob/) für weitere Speicher‑ und Speicherverwaltungsoptionen.
{{% /alert %}}

## **Externe Ressourcen steuern**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/de/java/com.aspose.slides/loadoptions/#setResourceLoadingCallback-com.aspose.slides.IResourceLoadingCallback-) akzeptiert eine Implementierung von [IResourceLoadingCallback](https://reference.aspose.com/slides/de/java/com.aspose.slides/iresourceloadingcallback/). Der Callback kann Ersatzdaten liefern, eine Ressource umleiten, den Standard‑Lader verwenden oder die Ressource überspringen. Dies ist nützlich, wenn Präsentationen externe Bilder enthalten, die gemäß anwendungsspezifischer Sicherheits‑ oder Speicherregeln aufgelöst werden müssen.

```java
import com.aspose.slides.IResourceLoadingArgs;
import com.aspose.slides.IResourceLoadingCallback;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.ResourceLoadingAction;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Locale;

class ImageLoadingHandler implements IResourceLoadingCallback {
    public int resourceLoading(IResourceLoadingArgs args) {
        boolean isJpeg = args.getOriginalUri().toLowerCase(Locale.ROOT).endsWith(".jpg");
        Path approvedImagePath = Paths.get("approved-image.jpg");
        if (!isJpeg || !Files.exists(approvedImagePath)) {
            return ResourceLoadingAction.Skip;
        }

        try {
            byte[] imageData = Files.readAllBytes(approvedImagePath);
            args.setData(imageData);
            return ResourceLoadingAction.UserProvided;
        } catch (IOException exception) {
            System.err.println("The approved replacement image could not be read.");
            return ResourceLoadingAction.Skip;
        }
    }
}

LoadOptions loadOptions = new LoadOptions();
loadOptions.setResourceLoadingCallback(new ImageLoadingHandler());

Presentation presentation = new Presentation("presentation-with-external-images.pptx", loadOptions);
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Präsentationen ohne eingebettete Binärobjekte laden**

Eine Präsentation kann eingebettete Binärdaten enthalten, die eine Anwendung nicht benötigt oder nicht behalten möchte. Beispiele sind:

- VBA‑Projekte, verfügbar über [IPresentation.getVbaProject](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentation/#getVbaProject--);
- eingebettete OLE‑Daten, verfügbar über [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/de/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--);
- ActiveX‑Steuerungsdaten, verfügbar über [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/de/java/com.aspose.slides/icontrol/#getActiveXControlBinary--).

Setzen Sie [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/de/java/com.aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) auf `true`, um diese Binärdaten beim Laden zu entfernen. Speichern Sie die geladene Präsentation, um das bereinigte Ergebnis zu persistieren.

Diese Option reduziert die Gefahr unerwünschter eingebetteter Nutzlasten, ist jedoch kein vollständiges Malware‑Erkennungs‑ oder Inhalts‑Sanitärsystem.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation presentation = new Presentation("presentation-with-embedded-data.pptx", loadOptions);
try {
    presentation.save("presentation-without-embedded-data.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Wie kann ich erkennen, dass eine Datei beschädigt ist und nicht geöffnet werden kann?**

Aspose.Slides wirft beim Laden eine Parsing‑ oder Format‑Ausnahme. Behandeln Sie diesen Fehler separat von einem falschen Passwort‑Fehler, damit die Anwendung die Ursache korrekt melden kann.

**Was passiert, wenn erforderliche Schriftarten fehlen?**

Die Präsentation kann trotzdem geladen werden, aber beim Rendern und Export können Schriftarten ersetzt werden. Sie können die [Schriftarten‑Substitution konfigurieren](/slides/de/java/font-substitution/) oder [benutzerdefinierte Schriftarten bereitstellen](/slides/de/java/custom-font/), um die Ausgabe vorhersehbarer zu machen.

**Lädt das Laden einer Präsentation auch deren eingebettete Medien?**

Eingebettete Audio‑ und Videodateien werden über das Präsentationsobjektmodell verfügbar. Externe Ressourcen werden gemäß dem konfigurierten Ressourcen‑Ladeverhalten aufgelöst und können nicht verfügbar sein, wenn ihre Speicherorte nicht zugänglich sind.