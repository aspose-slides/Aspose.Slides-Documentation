---
title: Kennwortgeschützte Präsentation
type: docs
weight: 20
url: /de/nodejs-java/password-protected-presentation/
keywords: "PowerPoint-Präsentation sperren in JavaScript"
description: "PowerPoint-Präsentation sperren. Kennwortgeschützte PowerPoint in JavaScript"
---

## **Über den Kennwortschutz**
### **Wie funktioniert der Kennwortschutz für Präsentationen?**
Wenn Sie eine Präsentation mit einem Kennwort schützen, legen Sie ein Kennwort fest, das bestimmte Einschränkungen für die Präsentation durchsetzt. Um die Einschränkungen zu entfernen, muss das Kennwort eingegeben werden. Eine kennwortgeschützte Präsentation gilt als gesperrte Präsentation.

Typischerweise können Sie ein Kennwort festlegen, um diese Einschränkungen für eine Präsentation durchzusetzen:

- **Änderung**

  Wenn Sie nur bestimmten Benutzern erlauben möchten, Ihre Präsentation zu ändern, können Sie eine Änderungsbeschränkung festlegen. Diese Beschränkung verhindert, dass Personen Ihre Präsentation ändern, anpassen oder Inhalte kopieren (es sei denn, sie geben das Kennwort ein).

  Allerdings kann in diesem Fall ein Benutzer, selbst ohne das Kennwort, auf Ihr Dokument zugreifen und es öffnen. Im Nur‑Lese‑Modus kann der Benutzer die Inhalte oder Elemente—Hyperlinks, Animationen, Effekte und andere—innerhalb Ihrer Präsentation ansehen, jedoch keine Elemente kopieren oder die Präsentation speichern.

- **Öffnen**

  Wenn Sie nur bestimmten Benutzern das Öffnen Ihrer Präsentation erlauben möchten, können Sie eine Öffnungsbeschränkung festlegen. Diese Beschränkung verhindert, dass Personen überhaupt den Inhalt Ihrer Präsentation sehen können (es sei denn, sie geben das Kennwort ein).

  Technisch verhindert die Öffnungsbeschränkung außerdem das Ändern Ihrer Präsentationen: Wenn Personen eine Präsentation nicht öffnen können, können sie auch keine Änderungen daran vornehmen.

  **Hinweis**: Wenn Sie eine Präsentation mit einem Kennwort schützen, um das Öffnen zu verhindern, wird die Präsentationsdatei verschlüsselt.

## **Wie man eine Präsentation online kennwortschützt**
1. Gehen Sie zu unserer [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock)-Seite.  

   ![todo:image_alt_text](slides-lock.png)

2. Klicken Sie auf **Dateien ablegen oder hochladen**.

3. Wählen Sie die Datei aus, die Sie auf Ihrem Computer kennwortschützen möchten.

4. Geben Sie Ihr gewünschtes Kennwort für den Bearbeitungsschutz ein; geben Sie Ihr gewünschtes Kennwort für den Ansichtsschutz ein.

5. Wenn Sie möchten, dass Benutzer Ihre Präsentation als Endversion sehen, aktivieren Sie das Kontrollkästchen **Mark as final**.

6. Klicken Sie auf **PROTECT NOW.** 

7. Klicken Sie auf **DOWNLOAD NOW.**

## **Kennwortschutz für Präsentationen in Aspose.Slides**
**Unterstützte Formate**

Aspose.Slides unterstützt Kennwortschutz, Verschlüsselung und ähnliche Vorgänge für Präsentationen in folgenden Formaten:

- PPTX und PPT – Microsoft PowerPoint‑Präsentation
- ODP – OpenDocument‑Präsentation
- OTP – OpenDocument‑Präsentationsvorlage

**Unterstützte Vorgänge**

Aspose.Slides ermöglicht den Kennwortschutz von Präsentationen, um Änderungen wie folgt zu verhindern:

- Verschlüsseln einer Präsentation
- Festlegen eines Schreibschutzes für eine Präsentation

**Weitere Vorgänge**

Aspose.Slides ermöglicht weitere Aufgaben rund um Kennwortschutz und Verschlüsselung:

- Entschlüsseln einer Präsentation; Öffnen einer verschlüsselten Präsentation
- Entfernen der Verschlüsselung; Deaktivieren des Kennwortschutzes
- Entfernen des Schreibschutzes von einer Präsentation
- Abrufen der Eigenschaften einer verschlüsselten Präsentation
- Prüfen, ob eine Präsentation verschlüsselt ist
- Prüfen, ob eine Präsentation kennwortgeschützt ist.

## **Verschlüsseln einer Präsentation**
Sie können eine Präsentation durch Festlegen eines Kennworts verschlüsseln. Um die gesperrte Präsentation zu ändern, muss ein Benutzer das Kennwort angeben.

Um eine Präsentation zu verschlüsseln oder kennwortzuschützen, müssen Sie die encrypt‑Methode (aus [ProtectionManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager)) verwenden, um ein Kennwort für die Präsentation festzulegen. Sie übergeben das Kennwort an die encrypt‑Methode und verwenden die save‑Methode, um die nun verschlüsselte Präsentation zu speichern.

Dieses Beispiel zeigt, wie man eine Präsentation verschlüsselt:
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
Sie können einer Präsentation eine Markierung mit dem Hinweis „Nicht ändern“ hinzufügen. So teilen Sie den Benutzern mit, dass Sie nicht möchten, dass sie Änderungen an der Präsentation vornehmen.

**Hinweis**: Der Schreibschutzvorgang verschlüsselt die Präsentation nicht. Daher können Benutzer—wenn sie wollen—die Präsentation ändern, müssen jedoch zum Speichern der Änderungen die Präsentation unter einem anderen Namen speichern.

Um einen Schreibschutz festzulegen, müssen Sie die Methode [setWriteProtection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setWriteProtection-java.lang.String-) verwenden. Dieses Beispiel zeigt, wie man einer Präsentation einen Schreibschutz hinzufügt:
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
Aspose.Slides ermöglicht das Laden einer verschlüsselten Datei, indem das Kennwort übergeben wird. Um eine Präsentation zu entschlüsseln, müssen Sie die Methode [removeEncryption](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--) ohne Parameter aufrufen. Anschließend müssen Sie das korrekte Kennwort eingeben, um die Präsentation zu laden.

Dieses Beispiel zeigt, wie man eine Präsentation entschlüsselt: 
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


## **Entfernen der Verschlüsselung; Deaktivieren des Kennwortschutzes**
Sie können die Verschlüsselung oder den Kennwortschutz einer Präsentation entfernen. Dadurch können Benutzer die Präsentation ohne Einschränkungen öffnen oder ändern.

Um die Verschlüsselung oder den Kennwortschutz zu entfernen, müssen Sie die Methode [removeEncryption](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--) aufrufen. Dieses Beispiel zeigt, wie man die Verschlüsselung einer Präsentation entfernt:
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
Sie können mit Aspose.Slides den Schreibschutz einer Präsentationsdatei entfernen. Dadurch können Benutzer nach Belieben Änderungen vornehmen – ohne dass Warnungen angezeigt werden.

Sie können den Schreibschutz einer Präsentation entfernen, indem Sie die Methode [removeWriteProtection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#removeWriteProtection--) verwenden. Dieses Beispiel zeigt, wie man den Schreibschutz einer Präsentation entfernt:
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
In der Regel haben Benutzer Schwierigkeiten, die Dokumenteigenschaften einer verschlüsselten oder kennwortgeschützten Präsentation zu erhalten. Aspose.Slides bietet jedoch einen Mechanismus, mit dem Sie eine Präsentation kennwortschützen können, während die Möglichkeit erhalten bleibt, dass Benutzer auf die Eigenschaften der Präsentation zugreifen.

**Hinweis**: Wenn Aspose.Slides eine Präsentation verschlüsselt, werden die Dokumenteigenschaften der Präsentation standardmäßig ebenfalls kennwortgeschützt. Wenn Sie jedoch die Eigenschaften der Präsentation zugänglich machen müssen (auch nachdem die Präsentation verschlüsselt wurde), ermöglicht Aspose.Slides genau das.

Wenn Sie möchten, dass Benutzer die Möglichkeit behalten, auf die Eigenschaften einer verschlüsselten Präsentation zuzugreifen, können Sie die Eigenschaft [encryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#getEncryptDocumentProperties--) auf `true` setzen. Dieses Beispiel zeigt, wie man eine Präsentation verschlüsselt und gleichzeitig den Benutzern den Zugriff auf ihre Dokumenteigenschaften ermöglicht:
```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(true);
    presentation.getProtectionManager().encrypt("123123");
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **Prüfen, ob eine Präsentation kennwortgeschützt ist, bevor sie geladen wird**
Bevor Sie eine Präsentation laden, möchten Sie vielleicht überprüfen und bestätigen, dass die Präsentation nicht mit einem Kennwort geschützt ist. Auf diese Weise können Sie Fehler und ähnliche Probleme vermeiden, die auftreten, wenn eine kennwortgeschützte Präsentation ohne Kennwort geladen wird.

Dieser JavaScript‑Code zeigt, wie man eine Präsentation untersucht, um festzustellen, ob sie kennwortgeschützt ist (ohne die Präsentation selbst zu laden):
```javascript
var presentationInfo = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("example.pptx");
console.log("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```


## **Prüfen, ob eine Präsentation verschlüsselt ist**
Aspose.Slides ermöglicht es, zu prüfen, ob eine Präsentation verschlüsselt ist. Dazu können Sie die Eigenschaft [isEncrypted](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isEncrypted--) verwenden, die `true` zurückgibt, wenn die Präsentation verschlüsselt ist, bzw. `false`, wenn sie nicht verschlüsselt ist.

Dieses Beispiel zeigt, wie man prüft, ob eine Präsentation verschlüsselt ist:
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


## **Prüfen, ob eine Präsentation schreibgeschützt ist**
Aspose.Slides ermöglicht es, zu prüfen, ob eine Präsentation schreibgeschützt ist. Dazu können Sie die Eigenschaft [isWriteProtected](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isWriteProtected--) verwenden, die `true` zurückgibt, wenn die Präsentation schreibgeschützt ist, bzw. `false`, wenn sie nicht schreibgeschützt ist.

Dieses Beispiel zeigt, wie man prüft, ob eine Präsentation schreibgeschützt ist:
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


## **Validieren oder Bestätigen, dass ein bestimmtes Kennwort zum Schutz einer Präsentation verwendet wurde**
Möglicherweise möchten Sie überprüfen und bestätigen, dass ein bestimmtes Kennwort zum Schutz eines Präsentationsdokuments verwendet wurde. Aspose.Slides bietet die Möglichkeit, ein Kennwort zu validieren.

Dieses Beispiel zeigt, wie man ein Kennwort validiert:
```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    // prüfen, ob "pass" übereinstimmt
    var isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


Sie gibt `true` zurück, wenn die Präsentation mit dem angegebenen Kennwort verschlüsselt wurde. Andernfalls gibt sie `false` zurück.

{{% alert color="primary" title="Siehe auch" %}} 
- [Digital Signature in PowerPoint](/slides/de/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**
**Welche Verschlüsselungsmethoden werden von Aspose.Slides unterstützt?**

Aspose.Slides unterstützt moderne Verschlüsselungsmethoden, einschließlich AES‑basierter Algorithmen, und gewährleistet ein hohes Maß an Datensicherheit für Ihre Präsentationen.

**Was passiert, wenn beim Versuch, eine Präsentation zu öffnen, ein falsches Kennwort eingegeben wird?**

Wird ein falsches Kennwort verwendet, wird eine Ausnahme ausgelöst, die anzeigt, dass der Zugriff auf die Präsentation verweigert wird. Dies verhindert unbefugten Zugriff und schützt den Inhalt der Präsentation.

**Gibt es Leistungsauswirkungen bei der Arbeit mit kennwortgeschützten Präsentationen?**

Der Verschlüsselungs‑ und Entschlüsselungsprozess kann beim Öffnen und Speichern zu einem leichten Mehraufwand führen. In den meisten Fällen ist diese Auswirkung minimal und beeinträchtigt die Gesamtverarbeitungszeit Ihrer Präsentationsaufgaben nicht wesentlich.