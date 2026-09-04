---
title: Präsentationen mit Passwortschutz in Java
linktitle: Passwortschutz
type: docs
weight: 20
url: /de/java/password-protected-presentation/
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
- Java
- Aspose.Slides
description: "Verschlüsseln, erkennen, validieren, öffnen und entschlüsseln Sie passwortgeschützte PowerPoint PPT- und PPTX-Präsentationen in Java mit Aspose.Slides."
---
## **Übersicht**

Ein Öffnungskennwort verschlüsselt eine Präsentation. Das korrekte Kennwort ist erforderlich, um den Präsentationsinhalt zu laden und anzuzeigen, sodass dieser Schutz Vertraulichkeit gewährleistet.

Ein Öffnungskennwort unterscheidet sich von einem Schreibschutzkennwort. Schreibschutz beschränkt die Änderung, verschlüsselt jedoch nicht den Inhalt und verhindert nicht das Laden der Präsentation. Um Kennwörter für die Modifikation von Präsentationen zu verwalten, siehe [Präsentationen schreibschützen](/slides/de/java/write-protected-presentation/).

Die nachstehenden Workflows gelten sowohl für PPT‑ als auch für PPTX‑Präsentationen. Die Beispiele verwenden beide Formate, wo ihr verhaltensabhängiges Datei‑ und Stream‑Verhalten wichtig ist.

## **Verschlüsseln einer Präsentation mit einem Öffnungskennwort**

Verwenden Sie [IProtectionManager.encrypt](https://reference.aspose.com/slides/de/java/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-), um ein Öffnungskennwort zuzuweisen. Anschließend speichern Sie die verschlüsselte Präsentation mit [IPresentation.save](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-).

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

## **Dokumenteigenschaften öffentlich lassen**

Standardmäßig beinhaltet Aspose.Slides Dokumenteigenschaften in die Präsentationsverschlüsselung. Die Methode [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) steuert dieses Verhalten unabhängig von der Folien‑Inhaltsverschlüsselung. Setzen Sie `false`, bevor Sie [IProtectionManager.encrypt](https://reference.aspose.com/slides/de/java/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) aufrufen, wenn ein Indexierungs‑, Klassifikations‑, Such‑ oder Dokument‑Management‑System Metadaten ohne das Öffnungskennwort lesen muss.

Das folgende Beispiel erstellt eine verschlüsselte PPTX‑Präsentation, lässt dabei jedoch ihre eingebauten Dokumenteigenschaften öffentlich:

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

Das Setzen von `false` bei [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) macht Folien, Vorlagen, Layouts, Formen, Medien oder andere Präsentationsinhalte nicht öffentlich. Es betrifft ausschließlich die Dokumenteigenschaften. Um diese Eigenschaften ohne Laden des verschlüsselten Inhalts zu lesen, siehe [Präsentations‑eigenschaften verwalten](/slides/de/java/presentation-properties/).

## **Verschlüsselte Präsentation laden**

Setzen Sie [ILoadOptions.setPassword](https://reference.aspose.com/slides/de/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) auf das Öffnungskennwort und übergeben Sie die Optionen beim Laden der Datei an [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/). Das Laden schlägt fehl, wenn ein Öffnungskennwort erforderlich ist, das angegebene Kennwort jedoch fehlt oder falsch ist.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    // Arbeiten Sie mit der entschlüsselten Präsentation.
} finally {
    presentation.dispose();
}
```

## **Verschlüsselung einer Präsentation entfernen**

Laden Sie die Präsentation mit ihrem Öffnungskennwort, rufen Sie [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/de/java/com.aspose.slides/iprotectionmanager/#removeEncryption--) auf und speichern Sie das Ergebnis. Die gespeicherte Präsentation kann danach ohne Kennwort geladen werden.

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

## **Öffnungskennwort vor dem Laden prüfen**

Verwenden Sie [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-), um [IPresentationInfo](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentationinfo/) zu erhalten, ohne eine vollständige Präsentationsinstanz zu erzeugen. Prüfen Sie [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) bevor Sie ein Kennwort anfordern oder prüfen. Ist ein Schutz vorhanden, validieren Sie den angegebenen Wert mit [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-).

### **Dateipfad-Workflow**

Das folgende Beispiel prüft ein Öffnungskennwort für eine PPTX‑Datei, übergibt den validierten Wert an [ILoadOptions.setPassword](https://reference.aspose.com/slides/de/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-), und lädt anschließend die vollständige Präsentation:

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

### **Stream-Workflow**

Die Stream‑Überladung von [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) bietet denselben Workflow. Setzen Sie die Position eines seek‑fähigen Streams zurück, bevor Sie die vollständige Präsentation aus diesem Stream laden.

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

[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) gibt `true` zurück, nur wenn die Präsentation ein Öffnungskennwort besitzt und das angegebene Kennwort korrekt ist. Es gibt `false` in den folgenden Fällen zurück:

- Das Kennwort ist falsch.
- Die Präsentation besitzt kein Öffnungskennwort.
- Das angegebene Kennwort ist `null` oder leer.

Das Verhalten ist für PPT‑ und PPTX‑Präsentationen identisch.

## **Überprüfen, ob eine geladene Präsentation verschlüsselt ist**

Nach dem Laden einer Präsentation mit dem korrekten Kennwort prüfen Sie [IProtectionManager.isEncrypted](https://reference.aspose.com/slides/de/java/com.aspose.slides/iprotectionmanager/#isEncrypted--), um zu bestätigen, dass die Quellpräsentation verschlüsselt war. Um den Schutz durch ein Öffnungskennwort vor dem Laden zu erkennen, verwenden Sie `IPresentationInfo.isPasswordProtected` wie oben gezeigt.

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
Loggen Sie Öffnungskennwörter nicht und fügen Sie sie nicht in Diagnosenachrichten ein. Vermeiden Sie unnötige wiederholte Prüfungsversuche, halten Sie Kennwörter nur so lange im Speicher, wie sie benötigt werden, und verwenden Sie ein erfolgreiches Prüfungsergebnis erneut, wenn Sie die Präsentation sofort laden.

Öffentliche Dokumenteigenschaften können Autorennamen, Titel, Themen, Schlüsselwörter, Firmendaten, Kommentare und benutzerdefinierte Werte offenbaren, obwohl der Präsentationsinhalt verschlüsselt ist. Verschlüsseln Sie sensible Metadaten zusammen mit der Präsentation. Das Offenlassen von Eigenschaften sollte eine explizite Entscheidung sein, die nur getroffen wird, wenn Systeme die Datei ohne Öffnungskennwort indexieren, klassifizieren, durchsuchen oder verwalten müssen.
{{% /alert %}}

## **Präsentation online mit Kennwort schützen**

1. Öffnen Sie die Anwendung [Aspose.Slides Lock](https://products.aspose.app/slides/de/lock).
2. Wählen Sie die Präsentation aus oder laden Sie sie hoch.
3. Geben Sie ein Kennwort für den Ansichtsschutz ein.
4. Geben Sie optional ein separates Kennwort für den Bearbeitungsschutz ein.
5. Wenden Sie den Schutz an und laden Sie die resultierende Datei herunter.

{{% alert color="info" title="Siehe auch" %}}
- [Präsentationen schreibschützen](/slides/de/java/write-protected-presentation/)
- [Digitale Signatur in PowerPoint](/slides/de/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Was ist der Unterschied zwischen einem Öffnungskennwort und einem Schreibschutzkennwort?**

Ein Öffnungskennwort verschlüsselt die Präsentation und ist zum Laden ihres Inhalts erforderlich. Ein Schreibschutzkennwort beschränkt die Änderung, ohne den Inhalt zu verschlüsseln.

**Kann ich ein Öffnungskennwort prüfen, ohne alle Folien zu laden?**

Ja. Erhalten Sie Präsentationsinformationen, prüfen Sie, ob ein Öffnungskennwortschutz vorhanden ist, und validieren Sie das Kennwort, bevor Sie eine vollständige Präsentationsinstanz erzeugen.

**Kann eine Anwendung Metadaten ohne das Öffnungskennwort lesen?**

Ja, jedoch nur, wenn die Präsentation mit deaktivierter Dokument‑Eigenschafts‑Verschlüsselung verschlüsselt wurde. Die Anwendung muss dann den ausschließlich‑für‑Dokument‑Eigenschaften‑Lademodus verwenden, der in [Präsentations‑eigenschaften verwalten](/slides/de/java/presentation-properties/) beschrieben ist.

**Unterstützen die Kennwort‑Prüf‑Workflows sowohl PPT als auch PPTX?**

Ja. Dateipfad‑ und Stream‑basierte Kennwort‑Erkennung und -Validierung verhalten sich für PPT‑ und PPTX‑Präsentationen identisch.