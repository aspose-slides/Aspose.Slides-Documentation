---
title: Sicheres Präsentieren mit Passwörtern unter Android
linktitle: Passwortschutz
type: docs
weight: 20
url: /de/androidjava/password-protected-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Mühelos PowerPoint- und OpenDocument-Präsentationen mit Passwortschutz mit Aspose.Slides für Android via Java sperren und entsperren. Sichern Sie Ihre Präsentationen."
---

## **Über den Kennwortschutz**
### **Wie funktioniert der Kennwortschutz für eine Präsentation?**
Wenn Sie eine Präsentation mit einem Kennwort schützen, legen Sie ein Kennwort fest, das bestimmte Einschränkungen für die Präsentation durchsetzt. Um die Einschränkungen zu entfernen, muss das Kennwort eingegeben werden. Eine kennwortgeschützte Präsentation wird als gesperrte Präsentation betrachtet.

In der Regel können Sie ein Kennwort festlegen, um diese Einschränkungen für eine Präsentation durchzusetzen:

- **Modifikation**

  Wenn Sie nur bestimmten Benutzern erlauben möchten, Ihre Präsentation zu ändern, können Sie eine Änderungsbeschränkung festlegen. Diese Beschränkung verhindert, dass Personen Ihre Präsentation ändern, verändern oder Inhalte kopieren (es sei denn, sie geben das Kennwort ein). 

  Allerdings kann ein Benutzer in diesem Fall das Dokument auch ohne Kennwort öffnen und darauf zugreifen. Im Nur‑Lese‑Modus kann der Benutzer den Inhalt Ihrer Präsentation – Hyperlinks, Animationen, Effekte und andere Elemente – anzeigen, jedoch keine Elemente kopieren oder die Präsentation speichern. 

- **Öffnen**

  Wenn Sie nur bestimmten Benutzern das Öffnen Ihrer Präsentation erlauben möchten, können Sie eine Öffnungsbeschränkung festlegen. Diese Beschränkung verhindert, dass Personen überhaupt den Inhalt Ihrer Präsentation sehen (es sei denn, sie geben das Kennwort ein).

  Technisch verhindert die Öffnungsbeschränkung ebenfalls, dass Benutzer Ihre Präsentationen ändern: Wenn Personen eine Präsentation nicht öffnen können, können sie sie nicht bearbeiten oder Änderungen daran vornehmen. 

**Hinweis**: Wenn Sie eine Präsentation mit einem Kennwort schützen, um das Öffnen zu verhindern, wird die Präsentationsdatei verschlüsselt.

## **Wie Sie eine Präsentation online kennwortschützen**
1. Gehen Sie zu unserer [**Aspose.Slides Sperren**](https://products.aspose.app/slides/lock) Seite. 

   ![todo:image_alt_text](slides-lock.png)

2. Klicken Sie auf **Dateien ziehen oder hochladen**.

3. Wählen Sie die Datei aus, die Sie auf Ihrem Computer kennwortschützen möchten. 

4. Geben Sie Ihr gewünschtes Kennwort für den Bearbeitungsschutz ein; geben Sie Ihr gewünschtes Kennwort für den Ansichtsschutz ein. 

5. Wenn Sie möchten, dass Benutzer Ihre Präsentation als endgültige Kopie sehen, aktivieren Sie das Kontrollkästchen **Als endgültig markieren**.

6. Klicken Sie auf **JETZT SCHÜTZEN**. 

7. Klicken Sie auf **JETZT HERUNTERLADEN**.

## **Kennwortschutz für Präsentationen in Aspose.Slides**
**Unterstützte Formate**

Aspose.Slides unterstützt Kennwortschutz, Verschlüsselung und ähnliche Vorgänge für Präsentationen in den folgenden Formaten: 

- PPTX und PPT – Microsoft PowerPoint‑Präsentation 
- ODP – OpenDocument‑Präsentation 
- OTP – OpenDocument‑Präsentationsvorlage 

**Unterstützte Vorgänge**

Aspose.Slides ermöglicht es Ihnen, Kennwortschutz für Präsentationen zu verwenden, um Änderungen auf folgende Weise zu verhindern:

- Verschlüsselung einer Präsentation
- Festlegen eines Schreibschutzes für eine Präsentation

**Weitere Vorgänge**

Aspose.Slides ermöglicht es Ihnen, weitere Aufgaben im Zusammenhang mit Kennwortschutz und Verschlüsselung wie folgt durchzuführen:

- Entschlüsseln einer Präsentation; Öffnen einer verschlüsselten Präsentation
- Entfernen der Verschlüsselung; Deaktivieren des Kennwortschutzes
- Entfernen des Schreibschutzes einer Präsentation
- Abrufen der Eigenschaften einer verschlüsselten Präsentation
- Prüfen, ob eine Präsentation verschlüsselt ist
- Prüfen, ob eine Präsentation kennwortgeschützt ist.

## **Eine Präsentation verschlüsseln**

Sie können eine Präsentation verschlüsseln, indem Sie ein Kennwort festlegen. Um die gesperrte Präsentation zu ändern, muss ein Benutzer das Kennwort angeben. 

Um eine Präsentation zu verschlüsseln oder mit einem Kennwort zu schützen, müssen Sie die encrypt‑Methode (aus [IProtectionManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager)) verwenden, um ein Kennwort für die Präsentation festzulegen. Sie übergeben das Kennwort an die encrypt‑Methode und verwenden die save‑Methode, um die nun verschlüsselte Präsentation zu speichern.

Dieser Beispielcode zeigt, wie man eine Präsentation verschlüsselt:
```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **Schreibschutz für eine Präsentation festlegen**

Sie können einer Präsentation einen Hinweis „Nicht ändern“ hinzufügen. Auf diese Weise signalisieren Sie den Benutzern, dass Sie nicht möchten, dass sie Änderungen an der Präsentation vornehmen.  

**Hinweis**: Der Schreibschutzvorgang verschlüsselt die Präsentation nicht. Daher können Benutzer – falls sie es wünschen – die Präsentation ändern, müssen jedoch zum Speichern der Änderungen eine Präsentation unter einem anderen Namen erstellen. 

Um einen Schreibschutz festzulegen, müssen Sie die [setWriteProtection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-)‑Methode verwenden. Dieser Beispielcode zeigt, wie man einen Schreibschutz für eine Präsentation festlegt:
```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **Eine verschlüsselte Präsentation laden**

Aspose.Slides ermöglicht das Laden einer verschlüsselten Datei, indem Sie das Kennwort übergeben. Um eine Präsentation zu entschlüsseln, müssen Sie die [removeEncryption](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--)‑Methode ohne Parameter aufrufen. Anschließend müssen Sie das korrekte Kennwort eingeben, um die Präsentation zu laden.

Dieser Beispielcode zeigt, wie man eine Präsentation entschlüsselt:
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // mit entschlüsselter Präsentation arbeiten
} finally {
    if (presentation != null) presentation.dispose();
}
}
```


## **Verschlüsselung einer Präsentation entfernen**

Sie können die Verschlüsselung oder den Kennwortschutz einer Präsentation entfernen. Auf diese Weise können Benutzer die Präsentation ohne Einschränkungen öffnen oder ändern.

Um die Verschlüsselung oder den Kennwortschutz zu entfernen, müssen Sie die [removeEncryption](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--)‑Methode aufrufen. Dieser Beispielcode zeigt, wie man die Verschlüsselung einer Präsentation entfernt:
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **Schreibschutz von einer Präsentation entfernen**

Sie können Aspose.Slides verwenden, um den Schreibschutz einer Präsentationsdatei zu entfernen. Auf diese Weise können Benutzer nach Belieben ändern – und erhalten keine Warnungen, wenn sie solche Vorgänge durchführen.

Sie können den Schreibschutz einer Präsentation entfernen, indem Sie die [removeWriteProtection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#removeWriteProtection--)‑Methode verwenden. Dieser Beispielcode zeigt, wie man den Schreibschutz einer Präsentation entfernt:
```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **Eigenschaften einer verschlüsselten Präsentation abrufen**

In der Regel haben Benutzer Schwierigkeiten, die Dokumenteigenschaften einer verschlüsselten oder kennwortgeschützten Präsentation abzurufen. Aspose.Slides bietet jedoch einen Mechanismus, der es ermöglicht, eine Präsentation mit einem Kennwort zu schützen und gleichzeitig den Benutzern den Zugriff auf die Eigenschaften dieser Präsentation zu ermöglichen.

**Hinweis**: Wenn Aspose.Slides eine Präsentation verschlüsselt, werden die Dokumenteigenschaften der Präsentation ebenfalls standardmäßig kennwortgeschützt. Wenn Sie jedoch die Eigenschaften der Präsentation zugänglich machen müssen (auch nach der Verschlüsselung), ermöglicht Aspose.Slides genau dies.

Wenn Sie möchten, dass Benutzer weiterhin die Möglichkeit haben, die Eigenschaften einer von Ihnen verschlüsselten Präsentation abzurufen, können Sie die Eigenschaft [encryptDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#getEncryptDocumentProperties--) auf `true` setzen. Dieser Beispielcode zeigt, wie man eine Präsentation verschlüsselt und gleichzeitig den Benutzern den Zugriff auf deren Dokumenteigenschaften ermöglicht:
```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(true);
    presentation.getProtectionManager().encrypt("123123");
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **Prüfen, ob eine Präsentation kennwortgeschützt ist**

Bevor Sie eine Präsentation laden, möchten Sie möglicherweise prüfen und bestätigen, dass die Präsentation nicht mit einem Kennwort geschützt ist. Auf diese Weise vermeiden Sie Fehler und ähnliche Probleme, die auftreten, wenn eine kennwortgeschützte Präsentation ohne Kennwort geladen wird.

Dieser Java‑Code zeigt, wie Sie eine Präsentation untersuchen, um festzustellen, ob sie kennwortgeschützt ist (ohne die Präsentation selbst zu laden):
```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```


## **Prüfen, ob eine Präsentation verschlüsselt ist**

Aspose.Slides ermöglicht es, zu prüfen, ob eine Präsentation verschlüsselt ist. Um diese Aufgabe auszuführen, können Sie die Eigenschaft [isEncrypted](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#isEncrypted--) verwenden, die `true` zurückgibt, wenn die Präsentation verschlüsselt ist, bzw. `false`, wenn sie nicht verschlüsselt ist.

Dieser Beispielcode zeigt, wie man prüft, ob eine Präsentation verschlüsselt ist:
```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **Prüfen, ob eine Präsentation schreibgeschützt ist**

Aspose.Slides ermöglicht es, zu prüfen, ob eine Präsentation schreibgeschützt ist. Um diese Aufgabe auszuführen, können Sie die Eigenschaft [isWriteProtected](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#isWriteProtected--) verwenden, die `true` zurückgibt, wenn die Präsentation schreibgeschützt ist, bzw. `false`, wenn sie nicht schreibgeschützt ist.

Dieser Beispielcode zeigt, wie man prüft, ob eine Präsentation schreibgeschützt ist:
```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **Validieren oder Bestätigen, dass ein bestimmtes Kennwort verwendet wurde**

Möglicherweise möchten Sie prüfen und bestätigen, dass ein bestimmtes Kennwort zum Schutz eines Präsentationsdokuments verwendet wurde. Aspose.Slides bietet die Möglichkeit, ein Kennwort zu validieren. 

Dieser Beispielcode zeigt, wie man ein Kennwort validiert:
```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // prüfen, ob "pass" übereinstimmt
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```


Er gibt `true` zurück, wenn die Präsentation mit dem angegebenen Kennwort verschlüsselt wurde. Andernfalls gibt er `false` zurück.

{{% alert color="primary" title="Siehe auch" %}} 
- [Digitale Signatur in PowerPoint](/slides/de/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Welche Verschlüsselungsmethoden unterstützt Aspose.Slides?**

Aspose.Slides unterstützt moderne Verschlüsselungsmethoden, einschließlich AES-basierter Algorithmen, und gewährleistet so ein hohes Maß an Datensicherheit für Ihre Präsentationen.

**Was passiert, wenn beim Versuch, eine Präsentation zu öffnen, ein falsches Kennwort eingegeben wird?**

Bei Verwendung eines falschen Kennworts wird eine Ausnahme ausgelöst, die Sie darüber informiert, dass der Zugriff auf die Präsentation verweigert wird. Dies hilft, unbefugten Zugriff zu verhindern und den Präsentationsinhalt zu schützen.

**Gibt es Leistungs Auswirkungen bei der Arbeit mit kennwortgeschützten Präsentationen?**

Der Verschlüsselungs‑ und Entschlüsselungsprozess kann beim Öffnen und Speichern einen leichten Mehraufwand verursachen. In den meisten Fällen ist diese Auswirkung minimal und beeinträchtigt die Gesamtverarbeitungszeit Ihrer Präsentationsaufgaben nicht wesentlich.