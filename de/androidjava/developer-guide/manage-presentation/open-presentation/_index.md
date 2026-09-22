---
title: Präsentationen auf Android öffnen
linktitle: Präsentation öffnen
type: docs
weight: 20
url: /de/androidjava/open-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint- und OpenDocument-Präsentationen auf Android öffnen, Öffnungspasswörter bereitstellen, das Laden von Ressourcen steuern und den Speicherverbrauch mit Aspose.Slides für Android via Java reduzieren."
---
## **Einführung**

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/de/androidjava/) kann PowerPoint- und OpenDocument-Präsentationen aus Dateien und Streams laden. Nachdem eine Präsentation geladen wurde, können Sie deren Struktur untersuchen, Folien bearbeiten, Ressourcen verwalten und sie im ursprünglichen oder einem anderen unterstützten Format speichern.

Das Ladeverhalten kann über die Klasse [LoadOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/loadoptions/) angepasst werden. Beispielsweise können Sie ein Öffnungspasswort angeben, große Binärobjekte außerhalb des Java-Heap-Speichers behalten, externe Ressourcen steuern oder eingebettete Binärdaten weglassen.

## **Präsentationen öffnen**

Nachdem Sie eine Datei oder einen Stream geladen haben, können Sie das [ursprüngliche Präsentationsformat bestimmen](/slides/de/androidjava/detect-presentation-source-format/), um zu entscheiden, wie Ihre Anwendung sie verarbeitet.

Um eine vorhandene Präsentation zu öffnen, übergeben Sie deren Dateipfad dem Konstruktor der [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/) . Entsorgen Sie die Präsentation nach der Verwendung, damit Dateihandles, temporäre Daten und andere Ressourcen umgehend freigegeben werden.

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

Ein Öffnungspasswort verschlüsselt den Präsentationsinhalt. Um die komplette Präsentation zu laden, übergeben Sie das korrekte Passwort an [LoadOptions.setPassword](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) und stellen Sie die Optionen dem [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/)‑Konstruktor zur Verfügung. Das Laden schlägt fehl, wenn das Passwort fehlt oder falsch ist.

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

Für Passworterkennung, -validierung und Verschlüsselungs‑Workflows siehe [Password‑Protect Presentations](/slides/de/androidjava/password-protected-presentation/). Wenn eine verschlüsselte Präsentation absichtlich mit öffentlichen Dokumenteneigenschaften gespeichert wurde, können diese Eigenschaften ohne Passwort gelesen werden; siehe [Manage Presentation Properties](/slides/de/androidjava/presentation-properties/).

## **Große Präsentationen öffnen**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) gibt Optionen zurück, die steuern, wie Aspose.Slides große binäre Objekte wie Bilder, Audio und Video verarbeitet. Sie können die Quelldatei gesperrt lassen, temporäre Dateien erlauben und die Menge an BLOB‑Daten, die im Speicher behalten wird, begrenzen.

Das folgende Java‑Code‑Beispiel demonstriert das Laden einer großen Präsentation (z. B. 2 GB):

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

{{% alert color="info" title="Note" %}}
Mit [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentationlockingbehavior/#KeepLocked) bleibt die Quelldatei gesperrt, bis die Präsentationsinstanz entsorgt wird. Verschieben, überschreiben oder löschen Sie die Quelldatei nicht, solange diese Instanz lebt.

Aspose.Slides kann beim Laden den Inhalt eines Eingabestreams kopieren. Für große Präsentationen ist daher ein Dateipfad im Allgemeinen effizienter als ein Stream. Siehe [Manage BLOBs](/slides/de/androidjava/manage-blob/) für weitere Speicher‑ und Speicherverwaltungsoptionen.
{{% /alert %}}

## **Externe Ressourcen steuern**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/loadoptions/#setResourceLoadingCallback-com.aspose.slides.IResourceLoadingCallback-) akzeptiert eine Implementierung von [IResourceLoadingCallback](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iresourceloadingcallback/). Der Callback kann Ersatzdaten bereitstellen, eine Ressource umleiten, den Standard‑Lader verwenden oder die Ressource überspringen. Das ist nützlich, wenn Präsentationen externe Bilder enthalten, die gemäß anwendungsspezifischen Sicherheits‑ oder Speicherregeln aufgelöst werden müssen.

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

- VBA‑Projekte, verfügbar über [IPresentation.getVbaProject](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentation/#getVbaProject--);
- eingebettete OLE‑Daten, verfügbar über [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--);
- ActiveX‑Steuerdaten, verfügbar über [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icontrol/#getActiveXControlBinary--).

Setzen Sie [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) auf `true`, um diese Binärdaten beim Laden zu entfernen. Speichern Sie die geladene Präsentation, um das bereinigte Ergebnis zu persistieren.

Diese Option reduziert die Gefahr unerwünschter eingebetteter Payloads, ist jedoch kein vollständiges Malware‑Erkennungs‑ oder Inhalts‑Sanitärsystem.

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

Aspose.Slides wirft beim Laden eine Parsing‑ oder Format‑Ausnahme. Behandeln Sie diesen Fehler getrennt von einem falschen Passwort‑Fehler, damit die Anwendung die Ursache genau melden kann.

**Was passiert, wenn erforderliche Schriften fehlen?**

Die Präsentation kann trotzdem geladen werden, aber Rendering und Export können Schriften substituieren. Sie können die [Schriftart‑Substitution konfigurieren](/slides/de/androidjava/font-substitution/) oder [benutzerdefinierte Schriften bereitstellen](/slides/de/androidjava/custom-font/), um die Ausgabe vorhersehbarer zu machen.

**Lädt das Laden einer Präsentation auch ihre eingebetteten Medien?**

Eingebettete Audio‑ und Video‑Dateien werden über das Präsentations‑Objektmodell verfügbar. Externe Ressourcen werden gemäß dem konfigurierten Ressourcen‑Ladeverhalten aufgelöst und können unavailable sein, wenn ihre Speicherorte nicht erreichbar sind.