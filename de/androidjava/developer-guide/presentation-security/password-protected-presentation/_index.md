---
title: Passwortschutz für Präsentationen auf Android
linktitle: Passwortschutz
type: docs
weight: 20
url: /de/androidjava/password-protected-presentation/
keywords:
- Passwortgeschützte Präsentation
- Öffnungspasswort
- PowerPoint verschlüsseln
- PowerPoint entschlüsseln
- Präsentationspasswort validieren
- Präsentationspasswort prüfen
- Verschlüsselte Präsentation öffnen
- Verschlüsselung entfernen
- PowerPoint
- PPT
- PPTX
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Verschlüsseln, erkennen, validieren, öffnen und entschlüsseln von passwortgeschützten PowerPoint‑PPT‑ und PPTX‑Präsentationen mit Aspose.Slides für Android über Java."
---
## **Übersicht**

Ein Öffnungspasswort verschlüsselt eine Präsentation. Das korrekte Passwort ist erforderlich, um die Präsentationsinhalte zu laden und anzuzeigen, sodass dieser Schutz Vertraulichkeit gewährleistet.

Ein Öffnungspasswort unterscheidet sich von einem Schreibschutzpasswort. Der Schreibschutz schränkt Änderungen ein, verschlüsselt jedoch nicht den Inhalt und verhindert nicht das Laden der Präsentation. Zur Verwaltung von Passwörtern zum Ändern von Präsentationen siehe [Write-Protect Presentations](/slides/de/androidjava/write-protected-presentation/).

Die nachstehenden Workflows gelten für PPT- und PPTX‑Präsentationen. Die Beispiele verwenden beide Formate, wenn deren datei‑basiertes und strom‑basiertes Verhalten wichtig ist.

## **Verschlüsseln einer Präsentation mit einem Öffnungspasswort**

Verwenden Sie [IProtectionManager.encrypt](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-), um ein Öffnungspasswort zuzuweisen. Anschließend verwenden Sie [IPresentation.save](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-), um die verschlüsselte Präsentation zu speichern.

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

## **Dokumenteigenschaften öffentlich halten**

Standardmäßig schließt Aspose.Slides Dokumenteigenschaften in die Präsentationsverschlüsselung ein. Die Methode [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) steuert dieses Verhalten unabhängig von der Folien‑Inhaltsverschlüsselung. Übergeben Sie `false` bevor Sie [IProtectionManager.encrypt](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) aufrufen, wenn ein Indexierungs-, Klassifizierungs-, Such- oder Dokument‑Management‑System Metadaten ohne das Öffnungspasswort lesen muss.

Das folgende Beispiel erstellt eine verschlüsselte PPTX‑Präsentation, wobei die integrierten Dokumenteigenschaften öffentlich bleiben:

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    IDocumentProperties properties = presentation.getDocumentProperties();
    properties.setAuthor("Contoso Knowledge Management");
    properties.setTitle("Quarterly Product Roadmap");
    properties.setKeywords("roadmap, planning, internal");

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content");
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("public-properties-encrypted.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Übergeben von `false` an [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) macht nicht Folien, Master, Layouts, Formen, Medien oder andere Präsentationsinhalte öffentlich. Es betrifft nur die Dokumenteigenschaften. Um diese Eigenschaften zu lesen, ohne den verschlüsselten Inhalt zu laden, siehe [Manage Presentation Properties](/slides/de/androidjava/presentation-properties/).

## **Verschlüsselte Präsentation laden**

Setzen Sie [ILoadOptions.setPassword](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) auf das Öffnungspasswort und übergeben Sie die Optionen an [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/), wenn die Datei geladen wird. Der Ladevorgang schlägt fehl, wenn ein Öffnungspasswort erforderlich ist, das bereitgestellte Passwort jedoch fehlt oder falsch ist.

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

## **Verschlüsselung aus einer Präsentation entfernen**

Laden Sie die Präsentation mit ihrem Öffnungspasswort, rufen Sie [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iprotectionmanager/#removeEncryption--) auf und speichern Sie das Ergebnis. Die gespeicherte Präsentation kann anschließend ohne Passwort geladen werden.

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

## **Öffnungspasswort vor dem Laden validieren**

Verwenden Sie [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-), um [IPresentationInfo](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentationinfo/) zu erhalten, ohne eine vollständige Präsentationsinstanz zu erstellen. Prüfen Sie [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentationinfo/#isPasswordProtected--), bevor Sie ein Passwort anfordern oder validieren. Ist ein Schutz vorhanden, validieren Sie den bereitgestellten Wert mit [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-).

### **Dateipfad-Workflow**

Das folgende Beispiel validiert ein Öffnungspasswort für eine PPTX‑Datei, übergibt den validierten Wert an [ILoadOptions.setPassword](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-), und lädt anschließend die vollständige Präsentation:

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

### **Strom‑Workflow**

Die Stream‑Überladung von [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) bietet den gleichen Workflow. Setzen Sie die Position eines durchsuchbaren Streams zurück, bevor Sie die vollständige Präsentation aus diesem Stream laden.

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

[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) gibt `true` nur zurück, wenn die Präsentation ein Öffnungspasswort hat und das bereitgestellte Passwort korrekt ist. Es gibt `false` in jedem der folgenden Fälle zurück:

- Das Passwort ist falsch.
- Die Präsentation hat kein Öffnungspasswort.
- Das bereitgestellte Passwort ist `null` oder leer.

Das Verhalten ist für PPT‑ und PPTX‑Präsentationen identisch.

## **Prüfen, ob eine geladene Präsentation verschlüsselt ist**

Nachdem Sie eine Präsentation mit dem korrekten Passwort geladen haben, prüfen Sie [IProtectionManager.isEncrypted](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iprotectionmanager/#isEncrypted--), um zu bestätigen, dass die Quellpräsentation verschlüsselt war. Um den Öffnungspasswort‑Schutz vor dem Laden zu erkennen, verwenden Sie `IPresentationInfo.isPasswordProtected` wie oben gezeigt.

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

## **Sicherheits‑Empfehlungen**

{{% alert color="warning" title="Sicherheit" %}}
Protokollieren Sie Öffnungspasswörter nicht und fügen Sie sie nicht in Diagnosemeldungen ein. Vermeiden Sie unnötige wiederholte Validierungsversuche, halten Sie Passwörter im Speicher nur so lange wie nötig und verwenden Sie ein erfolgreiches Validierungsergebnis erneut, wenn Sie die Präsentation sofort laden.

Öffentliche Dokumenteigenschaften können Autorennamen, Titel, Betreff, Schlüsselwörter, Unternehmensinformationen, Kommentare und benutzerdefinierte Werte preisgeben, obwohl der Präsentationsinhalt verschlüsselt ist. Verschlüsseln Sie sensible Metadaten zusammen mit der Präsentation. Das öffentliche Belassen von Eigenschaften sollte eine bewusste Entscheidung sein, die nur getroffen wird, wenn Systeme die Datei ohne Öffnungspasswort indexieren, klassifizieren, durchsuchen oder verwalten müssen.
{{% /alert %}}

## **Präsentation online passwortschützen**

1. Öffnen Sie die Anwendung [Aspose.Slides Lock](https://products.aspose.app/slides/de/lock).
1. Wählen Sie die Präsentation aus oder laden Sie sie hoch.
1. Geben Sie ein Passwort für den Ansichtsschutz ein.
1. Geben Sie optional ein separates Passwort für den Bearbeitungsschutz ein.
1. Wenden Sie den Schutz an und laden Sie die resultierende Datei herunter.

{{% alert color="info" title="Siehe auch" %}}
- [Write-Protect Presentations](/slides/de/androidjava/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/de/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Was ist der Unterschied zwischen einem Öffnungspasswort und einem Schreibschutzpasswort?**

Ein Öffnungspasswort verschlüsselt die Präsentation und ist erforderlich, um ihren Inhalt zu laden. Ein Schreibschutzpasswort schränkt Änderungen ein, ohne den Inhalt zu verschlüsseln.

**Kann ich ein Öffnungspasswort validieren, ohne alle Folien zu laden?**

Ja. Erhalten Sie Präsentationsinformationen, prüfen Sie, ob ein Öffnungspasswortschutz vorhanden ist, und validieren Sie das Passwort, bevor Sie eine vollständige Präsentationsinstanz erstellen.

**Kann eine Anwendung Metadaten ohne das Öffnungspasswort lesen?**

Ja, aber nur, wenn die Präsentation mit deaktivierter Dokument‑Eigenschafts‑Verschlüsselung verschlüsselt wurde. Die Anwendung muss dann den ausschließlich Dokument‑Eigenschaften‑Lademodus verwenden, der in [Manage Presentation Properties](/slides/de/androidjava/presentation-properties/) beschrieben ist.

**Unterstützen die Passwort‑Prüf‑Workflows sowohl PPT als auch PPTX?**

Ja. Datei‑Pfad‑ und strom‑basierte Passwort‑Erkennung und -Validierung verhalten sich für PPT‑ und PPTX‑Präsentationen gleich.