---
title: Passwortgeschützte Präsentationen auf Android
linktitle: Passwortschutz
type: docs
weight: 20
url: /de/androidjava/password-protected-presentation/
keywords:
- passwortgeschützte Präsentation
- Öffnungskennwort
- PowerPoint verschlüsseln
- PowerPoint entschlüsseln
- Präsentationskennwort validieren
- Präsentationskennwort prüfen
- verschlüsselte Präsentation öffnen
- Verschlüsselung entfernen
- PowerPoint
- PPT
- PPTX
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Verschlüsseln, erkennen, validieren, öffnen und entschlüsseln von passwortgeschützten PowerPoint PPT- und PPTX‑Präsentationen mit Aspose.Slides für Android über Java."
---
## **Übersicht**

Ein Öffnungskennwort verschlüsselt eine Präsentation. Das korrekte Kennwort ist erforderlich, um den Präsentationsinhalt zu laden und anzuzeigen, daher bietet dieser Schutz Vertraulichkeit.

Ein Öffnungskennwort unterscheidet sich von einem Schreibschutzkennwort. Schreibschutz schränkt Änderungen ein, verschlüsselt jedoch nicht den Inhalt und verhindert nicht das Laden der Präsentation. Um Kennwörter zum Ändern von Präsentationen zu verwalten, siehe [Schreibgeschützte Präsentationen](/slides/de/androidjava/write-protected-presentation/).

Die nachstehenden Workflows gelten für PPT- und PPTX-Präsentationen. Die Beispiele verwenden beide Formate, wenn ihr datei- und streambasiertes Verhalten wichtig ist.

## **Verschlüsseln einer Präsentation mit einem Öffnungskennwort**

Verwenden Sie [IProtectionManager.encrypt](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-), um ein Öffnungskennwort zuzuweisen. Anschließend verwenden Sie [IPresentation.save](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-), um die verschlüsselte Präsentation zu speichern.

Das folgende Beispiel verschlüsselt eine PPTX‑Präsentation:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Laden einer verschlüsselten Präsentation**

Setzen Sie [ILoadOptions.setPassword](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) auf das Öffnungskennwort und übergeben Sie die Optionen beim Laden der Datei an [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/). Das Laden schlägt fehl, wenn ein Öffnungskennwort erforderlich ist, das bereitgestellte Kennwort jedoch fehlt oder falsch ist.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    // Arbeiten mit der entschlüsselten Präsentation.
} finally {
    presentation.dispose();
}
```

## **Entfernen der Verschlüsselung aus einer Präsentation**

Laden Sie die Präsentation mit ihrem Öffnungskennwort, rufen Sie [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iprotectionmanager/#removeEncryption--) auf und speichern Sie das Ergebnis. Die gespeicherte Präsentation kann anschließend ohne Kennwort geladen werden.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Validieren eines Öffnungskennworts vor dem Laden**

Verwenden Sie [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-), um [IPresentationInfo](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentationinfo/) zu erhalten, ohne eine vollständige Präsentationsinstanz zu erstellen. Prüfen Sie [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentationinfo/#isPasswordProtected--), bevor Sie ein Kennwort anfordern oder validieren. Wenn ein Schutz vorhanden ist, validieren Sie den bereitgestellten Wert mit [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-).

### **Dateipfad‑Workflow**

Das folgende Beispiel validiert ein Öffnungskennwort für eine PPTX‑Datei, übergibt den validierten Wert an [ILoadOptions.setPassword](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) und lädt anschließend die vollständige Präsentation:

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;

String filePath = "protected-presentation.pptx";
String password = "open_password";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(filePath);

if (!presentationInfo.isPasswordProtected()) {
    System.out.println("The presentation does not have an opening password.");
} else if (!presentationInfo.checkPassword(password)) {
    System.out.println("The opening password is incorrect.");
} else {
    LoadOptions loadOptions = new LoadOptions();
    loadOptions.setPassword(password);

    Presentation presentation = new Presentation(filePath, loadOptions);
    try {
        System.out.println("The presentation was validated and loaded successfully.");
    } finally {
        presentation.dispose();
    }
}
```

### **Stream‑Workflow**

Die Stream‑Überladung von [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) bietet denselben Workflow. Setzen Sie die Position eines durchsuchbaren Streams zurück, bevor Sie die vollständige Präsentation aus diesem Stream laden.

Das folgende Beispiel verwendet eine PPT‑Datei:

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;
import java.io.FileInputStream;

String password = "open_password";

FileInputStream presentationStream = new FileInputStream("protected-presentation.ppt");
try {
    IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(presentationStream);

    if (!presentationInfo.isPasswordProtected()) {
        System.out.println("The presentation does not have an opening password.");
    } else if (!presentationInfo.checkPassword(password)) {
        System.out.println("The opening password is incorrect.");
    } else {
        presentationStream.getChannel().position(0);

        LoadOptions loadOptions = new LoadOptions();
        loadOptions.setPassword(password);

        Presentation presentation = new Presentation(presentationStream, loadOptions);
        try {
            System.out.println("The presentation was validated and loaded successfully.");
        } finally {
            presentation.dispose();
        }
    }
} finally {
    presentationStream.close();
}
```

### **Rückgabewerte von checkPassword**

[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) gibt `true` nur zurück, wenn die Präsentation ein Öffnungskennwort hat und das bereitgestellte Kennwort korrekt ist. Es gibt `false` in jedem der folgenden Fälle zurück:

- Das Kennwort ist falsch.
- Die Präsentation hat kein Öffnungskennwort.
- Das bereitgestellte Kennwort ist `null` oder leer.

Das Verhalten ist für PPT- und PPTX‑Präsentationen identisch.

## **Überprüfen, ob eine geladene Präsentation verschlüsselt ist**

Nachdem Sie eine Präsentation mit dem korrekten Kennwort geladen haben, prüfen Sie [IProtectionManager.isEncrypted](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iprotectionmanager/#isEncrypted--), um zu bestätigen, dass die Quellpräsentation verschlüsselt war. Um den Öffnungskennwort‑Schutz vor dem Laden zu erkennen, verwenden Sie `IPresentationInfo.isPasswordProtected` wie oben gezeigt.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
    System.out.println("The presentation is encrypted: " + isEncrypted);
} finally {
    presentation.dispose();
}
```

## **Sicherheitsempfehlungen**

{{% alert color="warning" title="Sicherheit" %}}
Protokollieren Sie keine Öffnungskennwörter und geben Sie sie nicht in Diagnosemeldungen an. Vermeiden Sie unnötige wiederholte Validierungsversuche, halten Sie Kennwörter nur so lange im Speicher, wie sie benötigt werden, und verwenden Sie ein erfolgreiches Validierungsergebnis erneut, wenn Sie die Präsentation sofort laden.
{{% /alert %}}

## **Präsentation online passwortschützen**

1. Öffnen Sie die Anwendung [Aspose.Slides Lock](https://products.aspose.app/slides/de/lock).
1. Wählen Sie die Präsentation aus oder laden Sie sie hoch.
1. Geben Sie ein Kennwort für den Ansichtsschutz ein.
1. Optional geben Sie ein separates Kennwort für den Bearbeitungsschutz ein.
1. Wenden Sie den Schutz an und laden Sie die resultierende Datei herunter.

{{% alert color="info" title="Siehe auch" %}}
- [Schreibgeschützte Präsentationen](/slides/de/androidjava/write-protected-presentation/)
- [Digitale Signatur in PowerPoint](/slides/de/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Was ist der Unterschied zwischen einem Öffnungskennwort und einem Schreibschutzkennwort?**

Ein Öffnungskennwort verschlüsselt die Präsentation und ist zum Laden des Inhalts erforderlich. Ein Schreibschutzkennwort schränkt Änderungen ein, ohne den Inhalt zu verschlüsseln.

**Kann ich ein Öffnungskennwort validieren, ohne alle Folien zu laden?**

Ja. Holen Sie die Präsentationsinformationen, prüfen Sie, ob ein Öffnungskennwortschutz vorhanden ist, und validieren Sie das Kennwort, bevor Sie eine vollständige Präsentationsinstanz erstellen.

**Unterstützen die Kennwort‑Überprüfungs‑Workflows sowohl PPT als auch PPTX?**

Ja. Dateipfad- und streambasierte Kennworterkennung und -validierung verhalten sich bei PPT‑ und PPTX‑Präsentationen gleich.