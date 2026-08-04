---
title: Präsentationen mit Passwörtern in JavaScript sichern
linktitle: Passwortschutz
type: docs
weight: 20
url: /de/nodejs-java/password-protected-presentation/
keywords:
- PowerPoint sperren
- Präsentation sperren
- PowerPoint entsperren
- Präsentation entsperren
- PowerPoint schützen
- Präsentation schützen
- Passwort festlegen
- Passwort hinzufügen
- PowerPoint verschlüsseln
- Präsentation verschlüsseln
- PowerPoint entschlüsseln
- Präsentation entschlüsseln
- Schreibschutz
- PowerPoint Sicherheit
- Präsentationssicherheit
- Passwort entfernen
- Schutz entfernen
- Verschlüsselung entfernen
- Passwort deaktivieren
- Schutz deaktivieren
- Schreibschutz entfernen
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Mühelos PowerPoint- und OpenDocument-Präsentationen, die mit einem Passwort geschützt sind, mit Aspose.Slides für Node.js über Java sperren und entsperren. Sichern Sie Ihre Präsentationen."
---
## **Einführung**

Wenn Sie eine Präsentation mit einem Passwort schützen, legen Sie ein Passwort fest, das bestimmte Einschränkungen für die Präsentation erzwingt. Um die Einschränkungen zu entfernen, muss das Passwort eingegeben werden. Eine passwortgeschützte Präsentation gilt als gesperrte Präsentation.

In der Regel können Sie ein Passwort festlegen, um diese Einschränkungen für eine Präsentation zu erzwingen:

- **Änderung**

  Wenn Sie möchten, dass nur bestimmte Benutzer Ihre Präsentation ändern dürfen, können Sie eine Änderungsbeschränkung festlegen. Diese Beschränkung verhindert, dass Personen Ihre Präsentation ändern, verändern oder Inhalte daraus kopieren (es sei denn, sie geben das Passwort ein).

  In diesem Fall kann ein Benutzer das Dokument jedoch trotzdem öffnen. Im Nur-Lese‑Modus kann der Benutzer die Inhalte – Hyperlinks, Animationen, Effekte usw. – ansehen, aber keine Elemente kopieren oder die Präsentation speichern.

- **Öffnen**

  Wenn Sie möchten, dass nur bestimmte Benutzer Ihre Präsentation öffnen können, können Sie eine Öffnungsbeschränkung festlegen. Diese Beschränkung verhindert, dass Personen überhaupt den Inhalt Ihrer Präsentation sehen (es sei denn, sie geben das Passwort ein).

  Technisch verhindert die Öffnungsbeschränkung auch das Ändern Ihrer Präsentationen: Wenn Personen eine Präsentation nicht öffnen können, können sie sie nicht ändern.

  **Hinweis**: Wenn Sie eine Präsentation mit einem Passwort schützen, um das Öffnen zu verhindern, wird die Präsentationsdatei verschlüsselt.

## **Wie Sie eine Präsentation online mit einem Passwort schützen**

1. Rufen Sie unsere [**Aspose.Slides Lock**](https://products.aspose.app/slides/de/lock)‑Seite auf.

   ![todo:image_alt_text](slides-lock.png)

2. Klicken Sie **Drop or upload your files**.

3. Wählen Sie die Datei aus, die Sie auf Ihrem Computer mit einem Passwort schützen möchten.

4. Geben Sie Ihr gewünschtes Passwort für den Bearbeitungsschutz ein; geben Sie Ihr gewünschtes Passwort für den Ansichtsschutz ein.

5. Wenn Sie möchten, dass Benutzer Ihre Präsentation als endgültige Kopie sehen, aktivieren Sie das Kontrollkästchen **Mark as final**.

6. Klicken Sie **PROTECT NOW.**

7. Klicken Sie **DOWNLOAD NOW.**

## **Passwortschutz für Präsentationen in Aspose.Slides**
**Unterstützte Formate**

Aspose.Slides unterstützt Passwortschutz, Verschlüsselung und ähnliche Vorgänge für Präsentationen in folgenden Formaten:

- PPTX und PPT – Microsoft PowerPoint Presentation  
- ODP – OpenDocument Presentation  
- OTP – OpenDocument Presentation Template  

**Unterstützte Vorgänge**

Aspose.Slides ermöglicht es Ihnen, Passwortschutz auf Präsentationen anzuwenden, um Änderungen auf folgende Weise zu verhindern:

- Verschlüsseln einer Präsentation  
- Festlegen eines Schreibschutzes für eine Präsentation  

**Weitere Vorgänge**

Aspose.Slides ermöglicht Ihnen weitere Aufgaben im Zusammenhang mit Passwortschutz und Verschlüsselung:

- Entschlüsseln einer Präsentation; Öffnen einer verschlüsselten Präsentation  
- Entfernen der Verschlüsselung; Deaktivieren des Passwortschutzes  
- Entfernen des Schreibschutzes von einer Präsentation  
- Abrufen der Eigenschaften einer verschlüsselten Präsentation  
- Prüfen, ob eine Präsentation verschlüsselt ist  
- Prüfen, ob eine Präsentation passwortgeschützt ist.

## **Verschlüsseln einer Präsentation**

Sie können eine Präsentation verschlüsseln, indem Sie ein Passwort festlegen. Dann muss ein Benutzer das Passwort angeben, um die gesperrte Präsentation zu ändern.

Um eine Präsentation zu verschlüsseln oder mit einem Passwort zu schützen, verwenden Sie die **encrypt**‑Methode (aus [ProtectionManager](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ProtectionManager)), um ein Passwort für die Präsentation zu setzen. Sie übergeben das Passwort an die **encrypt**‑Methode und verwenden die **save**‑Methode, um die nun verschlüsselte Präsentation zu speichern.

Der folgende Beispielcode zeigt, wie Sie eine Präsentation verschlüsseln:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Festlegen eines Schreibschutzes für eine Präsentation**

Sie können einer Präsentation einen Hinweis „Do not modify“ hinzufügen. Auf diese Weise teilen Sie den Benutzern mit, dass Sie nicht möchten, dass sie Änderungen an der Präsentation vornehmen.

**Hinweis**: Der Schreibschutzvorgang verschlüsselt die Präsentation nicht. Daher können Benutzer – falls sie es wirklich wollen – die Präsentation ändern, müssen aber zum Speichern der Änderungen eine Datei mit einem anderen Namen erstellen.

Um einen Schreibschutz zu setzen, verwenden Sie die [setWriteProtection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ProtectionManager#setWriteProtection-java.lang.String-)‑Methode. Der folgende Beispielcode zeigt, wie Sie einen Schreibschutz für eine Präsentation festlegen:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Entschlüsseln einer Präsentation; Öffnen einer verschlüsselten Präsentation**

Aspose.Slides ermöglicht das Laden einer verschlüsselten Datei, indem das Passwort übergeben wird. Um eine Präsentation zu entschlüsseln, rufen Sie die [removeEncryption](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--)‑Methode ohne Parameter auf. Anschließend müssen Sie das korrekte Passwort eingeben, um die Präsentation zu laden.

Der folgende Beispielcode zeigt, wie Sie eine Präsentation entschlüsseln:

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("123123");
var presentation = new aspose.slides.Presentation("pres.pptx", loadOptions);
try {
    // mit entschlüsselter Präsentation arbeiten
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Entfernen der Verschlüsselung; Deaktivieren des Passwortschutzes**

Sie können die Verschlüsselung oder den Passwortschutz einer Präsentation entfernen. Damit können Benutzer die Präsentation ohne Einschränkungen öffnen oder ändern.

Um die Verschlüsselung oder den Passwortschutz zu entfernen, rufen Sie die [removeEncryption](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--)‑Methode auf. Der folgende Beispielcode zeigt, wie Sie die Verschlüsselung einer Präsentation entfernen:

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("123123");
var presentation = new aspose.slides.Presentation("pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Entfernen des Schreibschutzes von einer Präsentation**

Sie können mit Aspose.Slides den Schreibschutz einer Präsentationsdatei entfernen. Dadurch können Benutzer nach Belieben Änderungen vornehmen, ohne Warnungen zu erhalten.

Sie entfernen den Schreibschutz von einer Präsentation, indem Sie die [removeWriteProtection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ProtectionManager#removeWriteProtection--)‑Methode verwenden. Der folgende Beispielcode zeigt, wie Sie den Schreibschutz entfernen:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Abrufen der Eigenschaften einer verschlüsselten Präsentation**

In der Regel haben Benutzer Schwierigkeiten, die Dokumenteneigenschaften einer verschlüsselten oder passwortgeschützten Präsentation abzurufen. Aspose.Slides bietet jedoch einen Mechanismus, der es ermöglicht, eine Präsentation zu schützen und gleichzeitig den Zugriff auf ihre Eigenschaften zu erlauben.

**Hinweis:** Standardmäßig werden bei der Verschlüsselung einer Präsentation durch Aspose.Slides die Dokumenteneigenschaften ebenfalls passwortgeschützt. Wenn Sie die Eigenschaften auch nach der Verschlüsselung zugänglich machen möchten, können Sie das mit Aspose.Slides erreichen.

Wenn Sie möchten, dass Benutzer nach der Verschlüsselung weiterhin auf die Eigenschaften einer Präsentation zugreifen können, übergeben Sie `false` an `setEncryptDocumentProperties` auf [ProtectionManager](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/protectionmanager/). Der folgende Beispielcode zeigt, wie Sie eine Präsentation verschlüsseln und gleichzeitig den Zugriff auf ihre Dokumenteneigenschaften erlauben:

```javascript
const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Nur Dokumenteneigenschaften einer verschlüsselten Präsentation laden**

Um die Metadaten einer verschlüsselten Präsentation zu prüfen, ohne deren Folien oder anderen Inhalt zu laden, erstellen Sie ein [LoadOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/loadoptions/)-Objekt und übergeben `true` an `setOnlyLoadDocumentProperties`. In diesem Modus ignoriert Aspose.Slides das Passwort und lädt ausschließlich die öffentlich zugänglichen Dokumenteneigenschaften.

Der folgende Code liest integrierte und benutzerdefinierte Dokumenteneigenschaften über `getDocumentProperties` auf [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/):

```javascript
const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new aspose.slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    const documentProperties = presentation.getDocumentProperties();

    // Eingebaute Dokumenteigenschaften lesen.
    console.log("Title: " + documentProperties.getTitle());
    console.log("Author: " + documentProperties.getAuthor());

    // Benutzerdefinierte Dokumenteigenschaften lesen.
    const customPropertyCount = documentProperties.getCountOfCustomProperties();

    for (let propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++) {
        const propertyName = documentProperties.getCustomPropertyName(propertyIndex);
        const propertyValue = documentProperties.get_Item(propertyName);

        console.log(propertyName + ": " + propertyValue);
    }
} finally {
    presentation.dispose();
}
```

Dieser Workflow funktioniert nur, wenn die Dokumenteneigenschaften beim Verschlüsseln der Präsentation unverändert (öffentlich) gelassen wurden. Sind die Eigenschaften verschlüsselt, führt das Übergeben von `true` an `LoadOptions.setOnlyLoadDocumentProperties` zu einer Ausnahme, weil das Passwort in diesem Modus ignoriert wird. Um verschlüsselte Dokumenteneigenschaften zu prüfen oder die komplette Präsentation inklusive Folien und Inhalt zu laden, geben Sie das korrekte Passwort über `LoadOptions.setPassword` auf [LoadOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/loadoptions/) an.

## **Überprüfen, ob eine Präsentation passwortgeschützt ist, bevor sie geladen wird**

Bevor Sie eine Präsentation laden, möchten Sie vielleicht prüfen, ob die Präsentation nicht mit einem Passwort geschützt ist. Auf diese Weise vermeiden Sie Fehler und ähnliche Probleme, die auftreten, wenn eine passwortgeschützte Präsentation ohne Passwort geladen wird.

Der folgende JavaScript‑Code zeigt, wie Sie eine Präsentation prüfen können, ob sie passwortgeschützt ist (ohne die Präsentation selbst zu laden):

```javascript
var presentationInfo = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("example.pptx");
console.log("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Überprüfen, ob eine Präsentation verschlüsselt ist**

Aspose.Slides ermöglicht das Prüfen, ob eine Präsentation verschlüsselt ist. Verwenden Sie hierfür die [isEncrypted](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ProtectionManager#isEncrypted--)‑Eigenschaft, die `true` zurückgibt, wenn die Präsentation verschlüsselt ist, andernfalls `false`.

Der folgende Beispielcode zeigt, wie Sie prüfen, ob eine Präsentation verschlüsselt ist:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    var isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Überprüfen, ob eine Präsentation schreibgeschützt ist**

Aspose.Slides ermöglicht das Prüfen, ob eine Präsentation schreibgeschützt ist. Verwenden Sie hierfür die [isWriteProtected](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ProtectionManager#isWriteProtected--)‑Eigenschaft, die `true` zurückgibt, wenn die Präsentation schreibgeschützt ist, andernfalls `false`.

Der folgende Beispielcode zeigt, wie Sie prüfen, ob eine Präsentation schreibgeschützt ist:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    var isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Validieren, ob ein bestimmtes Passwort zum Schutz einer Präsentation verwendet wurde**

Möglicherweise möchten Sie prüfen, ob ein bestimmtes Passwort zum Schützen eines Präsentationsdokuments verwendet wurde. Aspose.Slides bietet die Möglichkeit, ein Passwort zu validieren.

Der folgende Beispielcode zeigt, wie Sie ein Passwort validieren:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    // prüfen, ob das Passwort übereinstimmt
    var isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

Er gibt `true` zurück, wenn die Präsentation mit dem angegebenen Passwort verschlüsselt wurde, andernfalls `false`.

{{% alert color="primary" title="Siehe auch" %}} 
- [Digital Signature in PowerPoint](/slides/de/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Welche Verschlüsselungsmethoden unterstützt Aspose.Slides?**

Aspose.Slides unterstützt moderne Verschlüsselungsmethoden, einschließlich AES‑basierter Algorithmen, und sorgt so für ein hohes Maß an Datensicherheit für Ihre Präsentationen.

**Was passiert, wenn ein falsches Passwort beim Versuch, eine Präsentation zu öffnen, eingegeben wird?**

Es wird eine Ausnahme ausgelöst, die anzeigt, dass der Zugriff auf die Präsentation verweigert wird. Dies verhindert unbefugten Zugriff und schützt den Inhalt der Präsentation.

**Gibt es Leistungsauswirkungen beim Arbeiten mit passwortgeschützten Präsentationen?**

Der Verschlüsselungs‑ und Entschlüsselungsprozess kann beim Öffnen und Speichern zu einem leichten Mehraufwand führen. In den meisten Fällen ist dieser Einfluss minimal und beeinträchtigt die Gesamtverarbeitungszeit Ihrer Präsentationsaufgaben kaum.