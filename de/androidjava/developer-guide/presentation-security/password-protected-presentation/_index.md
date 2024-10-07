---
title: Passwortgeschützte Präsentation
type: docs
weight: 20
url: /androidjava/password-protected-presentation/
keywords: "PowerPoint-Präsentation in Java sperren"
description: "PowerPoint-Präsentation sperren. Passwortgeschützte PowerPoint in Java"
---

## **Über Passwortschutz**
### **Wie funktioniert der Passwortschutz für Präsentationen?**
Wenn Sie eine Präsentation mit einem Passwort schützen, bedeutet dies, dass Sie ein Passwort festlegen, das bestimmte Einschränkungen für die Präsentation durchsetzt. Um die Einschränkungen zu entfernen, muss das Passwort eingegeben werden. Eine passwortgeschützte Präsentation wird als gesperrte Präsentation betrachtet.

Typischerweise können Sie ein Passwort festlegen, um diese Einschränkungen für eine Präsentation durchzusetzen:

- **Modifikation**

  Wenn Sie möchten, dass nur bestimmte Benutzer Ihre Präsentation ändern können, können Sie eine Einschränkung für die Modifikation festlegen. Die Einschränkung hier verhindert, dass Personen Dinge in Ihrer Präsentation ändern, ändern oder kopieren (es sei denn, sie geben das Passwort ein).

  In diesem Fall kann ein Benutzer jedoch auch ohne das Passwort auf Ihr Dokument zugreifen und es öffnen. In diesem Nur-Lese-Modus kann der Benutzer den Inhalt oder die Dinge—Hyperlinks, Animationen, Effekte und andere—innerhalb Ihrer Präsentation anzeigen, aber er kann keine Elemente kopieren oder die Präsentation speichern.

- **Öffnen**

  Wenn Sie möchten, dass nur bestimmte Benutzer Ihre Präsentation öffnen können, können Sie eine Einschränkung für das Öffnen festlegen. Die Einschränkung hier verhindert, dass Personen den Inhalt Ihrer Präsentation überhaupt sehen (es sei denn, sie geben das Passwort ein).

  Technisch gesehen verhindert die Einschränkung für das Öffnen auch, dass Benutzer Ihre Präsentationen modifizieren: Wenn Personen eine Präsentation nicht öffnen können, können sie sie nicht ändern oder modifizieren.

  **Hinweis:** Wenn Sie eine Präsentation zum Schutz vor dem Öffnen mit einem Passwort schützen, wird die Präsentationsdatei verschlüsselt.

## **So schützen Sie eine Präsentation online mit einem Passwort**

1. Gehen Sie zu unserer [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock) Seite.

   ![todo:image_alt_text](slides-lock.png)

2. Klicken Sie auf **Dateien ablegen oder hochladen**.

3. Wählen Sie die Datei auf Ihrem Computer aus, die Sie mit einem Passwort schützen möchten.

4. Geben Sie Ihr bevorzugtes Passwort zum Schutz vor Änderungen ein; Geben Sie Ihr bevorzugtes Passwort für den Ansichtsschutz ein.

5. Wenn Sie möchten, dass Benutzer Ihre Präsentation als endgültige Kopie sehen, aktivieren Sie das Kontrollkästchen **Als endgültig markieren**.

6. Klicken Sie auf **JETZT SCHÜTZEN.**

7. Klicken Sie auf **JETZT HERUNTERLADEN.**

## **Passwortschutz für Präsentationen in Aspose.Slides**
**Unterstützte Formate**

Aspose.Slides unterstützt Passwortschutz, Verschlüsselung und ähnliche Vorgänge für Präsentationen in diesen Formaten:

- PPTX und PPT - Microsoft PowerPoint-Präsentation
- ODP - OpenDocument-Präsentation
- OTP - OpenDocument-Präsentationsvorlage

**Unterstützte Vorgänge**

Aspose.Slides ermöglicht es Ihnen, Passwortschutz auf Präsentationen anzuwenden, um Modifikationen auf diese Weise zu verhindern:

- Verschlüsselung einer Präsentation
- Festlegen eines Schreibschutzes für eine Präsentation

**Andere Vorgänge**

Aspose.Slides ermöglicht es Ihnen, andere Aufgaben in Bezug auf Passwortschutz und Verschlüsselung auf diese Weise durchzuführen:

- Entschlüsseln einer Präsentation; Öffnen einer verschlüsselten Präsentation
- Entfernen der Verschlüsselung; Deaktivieren des Passwortschutzes
- Entfernen des Schreibschutzes von einer Präsentation
- Abrufen der Eigenschaften einer verschlüsselten Präsentation
- Überprüfen, ob eine Präsentation verschlüsselt ist
- Überprüfen, ob eine Präsentation passwortgeschützt ist.

## **Verschlüsseln einer Präsentation**

Sie können eine Präsentation durch Festlegen eines Passworts verschlüsseln. Um die gesperrte Präsentation zu ändern, muss der Benutzer das Passwort angeben.

Um eine Präsentation zu verschlüsseln oder mit einem Passwort zu schützen, müssen Sie die Methode encrypt (aus [IProtectionManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager)) verwenden, um ein Passwort für die Präsentation festzulegen. Sie übergeben das Passwort an die Methode encrypt und verwenden die Methode save, um die nun verschlüsselte Präsentation zu speichern.

Dieser Beispielcode zeigt Ihnen, wie Sie eine Präsentation verschlüsseln:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Festlegen eines Schreibschutzes für eine Präsentation**

Sie können eine Notiz hinzufügen, die besagt "Nicht ändern" zu einer Präsentation. Auf diese Weise teilen Sie den Benutzern mit, dass Sie nicht möchten, dass sie Änderungen an der Präsentation vornehmen.

**Hinweis:** Der Prozess des Schreibschutzes verschlüsselt die Präsentation nicht. Daher können Benutzer—wenn sie tatsächlich wollen—die Präsentation ändern, müssen jedoch eine Präsentation mit einem anderen Namen erstellen, um die Änderungen zu speichern.

Um einen Schreibschutz festzulegen, müssen Sie die Methode [setWriteProtection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) verwenden. Dieser Beispielcode zeigt Ihnen, wie Sie einen Schreibschutz für eine Präsentation festlegen:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Entschlüsseln einer Präsentation; Öffnen einer verschlüsselten Präsentation**

Aspose.Slides ermöglicht es Ihnen, eine verschlüsselte Datei zu laden, indem Sie ihr Passwort übergeben. Um eine Präsentation zu entschlüsseln, müssen Sie die Methode [removeEncryption](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) ohne Parameter aufrufen. Sie müssen dann das richtige Passwort eingeben, um die Präsentation zu laden.

Dieser Beispielcode zeigt Ihnen, wie Sie eine Präsentation entschlüsseln:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // Arbeiten Sie mit der entschlüsselten Präsentation
} finally {
    if (presentation != null) presentation.dispose();
}
}
```

## **Entfernen der Verschlüsselung; Deaktivieren des Passwortschutzes**

Sie können die Verschlüsselung oder den Passwortschutz für eine Präsentation entfernen. Auf diese Weise können Benutzer auf die Präsentation zugreifen oder sie ohne Einschränkungen ändern.

Um die Verschlüsselung oder den Passwortschutz zu entfernen, müssen Sie die Methode [removeEncryption](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) aufrufen. Dieser Beispielcode zeigt Ihnen, wie Sie die Verschlüsselung von einer Präsentation entfernen:

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

## **Entfernen des Schreibschutzes von einer Präsentation**

Sie können Aspose.Slides verwenden, um den Schreibschutz von einer Präsentationsdatei zu entfernen. Auf diese Weise können Benutzer nach Belieben Änderungen vornehmen—und sie erhalten keine Warnungen, wenn sie solche Aufgaben durchführen.

Sie können den Schreibschutz von einer Präsentation entfernen, indem Sie die Methode [removeWriteProtection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#removeWriteProtection--) verwenden. Dieser Beispielcode zeigt Ihnen, wie Sie den Schreibschutz von einer Präsentation entfernen:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Abrufen der Eigenschaften einer verschlüsselten Präsentation**

Typischerweise haben Benutzer Schwierigkeiten, die Dokument Eigenschaften einer verschlüsselten oder passwortgeschützten Präsentation abzurufen. Aspose.Slides bietet jedoch einen Mechanismus, der es Ihnen ermöglicht, eine Präsentation passwortzuschützen und gleichzeitig den Benutzern den Zugriff auf die Eigenschaften dieser Präsentation zu ermöglichen.

**Hinweis:** Wenn Aspose.Slides eine Präsentation verschlüsselt, werden standardmäßig auch die Dokumenteigenschaften der Präsentation passwortgeschützt. Wenn Sie jedoch möchten, dass die Eigenschaften der Präsentation zugänglich sind (auch nachdem die Präsentation verschlüsselt wurde), ermöglicht Ihnen Aspose.Slides genau das.

Wenn Sie möchten, dass die Benutzer die Möglichkeit behalten, auf die Eigenschaften einer verschlüsselten Präsentation zuzugreifen, können Sie die Eigenschaft [encryptDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#getEncryptDocumentProperties--) auf `true` setzen. Dieser Beispielcode zeigt Ihnen, wie Sie eine Präsentation verschlüsseln, während Sie den Benutzern den Zugriff auf die Dokumenteigenschaften ermöglichen:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(true);
    presentation.getProtectionManager().encrypt("123123");
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Überprüfen, ob eine Präsentation vor dem Laden passwortgeschützt ist**

Bevor Sie eine Präsentation laden, möchten Sie möglicherweise überprüfen und bestätigen, dass die Präsentation nicht mit einem Passwort geschützt ist. Auf diese Weise können Sie Fehler und ähnliche Probleme vermeiden, die auftreten, wenn eine passwortgeschützte Präsentation ohne ihr Passwort geladen wird.

Dieser Java-Code zeigt Ihnen, wie Sie eine Präsentation untersuchen, um zu sehen, ob sie passwortgeschützt ist (ohne die Präsentation selbst zu laden):

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("Die Präsentation ist passwortgeschützt: " + presentationInfo.isPasswordProtected());
```

## **Überprüfen, ob eine Präsentation verschlüsselt ist**

Aspose.Slides ermöglicht es Ihnen, zu überprüfen, ob eine Präsentation verschlüsselt ist. Um diese Aufgabe auszuführen, können Sie die Eigenschaft [isEncrypted](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#isEncrypted--) verwenden, die `true` zurückgibt, wenn die Präsentation verschlüsselt ist, oder `false`, wenn die Präsentation nicht verschlüsselt ist.

Dieser Beispielcode zeigt Ihnen, wie Sie überprüfen, ob eine Präsentation verschlüsselt ist:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Überprüfen, ob eine Präsentation schreibgeschützt ist**

Aspose.Slides ermöglicht es Ihnen, zu überprüfen, ob eine Präsentation schreibgeschützt ist. Um diese Aufgabe auszuführen, können Sie die Eigenschaft [isWriteProtected](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#isWriteProtected--) verwenden, die `true` zurückgibt, wenn die Präsentation schreibgeschützt ist, oder `false`, wenn die Präsentation nicht schreibgeschützt ist.

Dieser Beispielcode zeigt Ihnen, wie Sie überprüfen, ob eine Präsentation schreibgeschützt ist:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isWriteProtected = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Validieren oder Bestätigen, dass ein bestimmtes Passwort verwendet wurde, um eine Präsentation zu schützen**

Sie möchten möglicherweise überprüfen und bestätigen, dass ein bestimmtes Passwort verwendet wurde, um ein Präsentationsdokument zu schützen. Aspose.Slides bietet die Mittel, um ein Passwort zu validieren.

Dieser Beispielcode zeigt Ihnen, wie Sie ein Passwort validieren:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // Überprüfen, ob "pass" übereinstimmt
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

Es gibt `true` zurück, wenn die Präsentation mit dem angegebenen Passwort verschlüsselt wurde. Andernfalls gibt es `false` zurück.

{{% alert color="primary" title="Siehe auch" %}} 
- [Digitale Signatur in PowerPoint](/slides/net/digital-signature-in-powerpoint/)
{{% /alert %}}