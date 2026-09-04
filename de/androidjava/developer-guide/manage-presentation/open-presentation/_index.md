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
- Binärobjekt
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint- und OpenDocument‑Präsentationen auf Android öffnen, Öffnungspasswörter angeben, das Laden von Ressourcen steuern und den Speicherverbrauch mit Aspose.Slides für Android via Java reduzieren."
---
## **Einleitung**

Aspose.Slides for Android via Java kann PowerPoint- und OpenDocument-Präsentationen aus Dateien und Streams laden. Nachdem eine Präsentation geladen wurde, können Sie ihre Struktur untersuchen, Folien bearbeiten, Ressourcen verwalten und sie im Originalformat oder in einem anderen unterstützten Format speichern.

Das Ladeverhalten kann über die Klasse LoadOptions angepasst werden. Beispielsweise können Sie ein Öffnungspasswort angeben, große Binärobjekte außerhalb des Java-Heap-Speichers halten, externe Ressourcen steuern oder eingebettete Binärdaten weglassen.

## **Präsentationen öffnen**

Um eine vorhandene Präsentation zu öffnen, übergeben Sie ihren Dateipfad dem Konstruktor Presentation. Entsorgen Sie die Präsentation nach der Verwendung, damit Dateihandles, temporäre Daten und andere Ressourcen sofort freigegeben werden.

Das folgende Java-Beispiel zeigt, wie man eine Präsentation öffnet und die Folienanzahl ermittelt:

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

Ein Öffnungspasswort verschlüsselt den Inhalt der Präsentation. Um die gesamte Präsentation zu laden, übergeben Sie das korrekte Passwort an LoadOptions.setPassword und geben die Optionen dem Konstruktor Presentation. Das Laden schlägt fehl, wenn das Passwort fehlt oder falsch ist.

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

Für Passwort-Erkennung, Validierung und Verschlüsselungs-Workflows siehe Passwort-Protect Presentations. Wenn eine verschlüsselte Präsentation bewusst mit öffentlichen Dokumenteigenschaften gespeichert wurde, können diese Eigenschaften ohne Passwort ausgelesen werden; siehe Manage Presentation Properties.

## **Große Präsentationen öffnen**

LoadOptions.getBlobManagementOptions liefert Optionen, die steuern, wie Aspose.Slides große Binärobjekte (BLOBs) wie Bilder, Audio und Video verarbeitet. Sie können die Quelldatei gesperrt halten, temporäre Dateien zulassen und die Menge an BLOB-Daten, die im Speicher gehalten werden, begrenzen.

Der folgende Java-Code demonstriert das Laden einer großen Präsentation (zum Beispiel 2 GB):

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
Mit PresentationLockingBehavior.KeepLocked bleibt die Quelldatei gesperrt, bis die Präsentationsinstanz entsorgt wird. Verschieben, überschreiben oder löschen Sie die Quelldatei nicht, solange diese Instanz aktiv ist.

Aspose.Slides kann beim Laden den Inhalt eines Eingabestreams kopieren. Für große Präsentationen ist ein Dateipfad daher in der Regel effizienter als ein Stream. Siehe Manage BLOBs für zusätzliche Speicher- und Speicherverwaltungsoptionen.
{{% /alert %}}

## **Externe Ressourcen steuern**

LoadOptions.setResourceLoadingCallback akzeptiert eine Implementierung von IResourceLoadingCallback. Der Callback kann Ersatzdaten bereitstellen, eine Ressource umleiten, den Standard-Loader verwenden oder die Ressource überspringen. Dies ist nützlich, wenn Präsentationen externe Bilder enthalten, die gemäß anwendungsspezifischen Sicherheits- oder Speicherregeln aufgelöst werden müssen.

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

- VBA-Projekte, verfügbar über IPresentation.getVbaProject;
- eingebettete OLE-Daten, verfügbar über IOleEmbeddedDataInfo.getEmbeddedFileData;
- ActiveX-Steuerungsdaten, verfügbar über IControl.getActiveXControlBinary.

Setzen Sie LoadOptions.setDeleteEmbeddedBinaryObjects auf `true`, um diese Binärdaten beim Laden zu entfernen. Speichern Sie die geladene Präsentation, um das bereinigte Ergebnis zu erhalten.

Diese Option verringert das Risiko unerwünschter eingebetteter Payloads, stellt jedoch kein vollständiges Malware-Erkennungs- oder Inhalts-Sanitärsystem dar.

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

Aspose.Slides wirft beim Laden eine Parsing- oder Format-Ausnahme. Behandeln Sie diesen Fehler separat von einem falschen-Passwort-Fehler, damit die Anwendung die Ursache genau melden kann.

**Was passiert, wenn erforderliche Schriftarten fehlen?**

Die Präsentation kann weiterhin geladen werden, aber beim Rendern und Exportieren können Schriftarten substituiert werden. Sie können die Schriftart-Substitution konfigurieren oder benutzerdefinierte Schriftarten bereitstellen, um die Ausgabe vorhersehbarer zu machen.

**Lädt das Laden einer Präsentation auch deren eingebettete Medien?**

Eingebettetes Audio und Video stehen über das Präsentations-Objektmodell zur Verfügung. Externe Ressourcen werden gemäß dem konfigurierten Ressourcen-Ladeverhalten aufgelöst und können nicht verfügbar sein, wenn ihre Speicherorte nicht erreichbar sind.