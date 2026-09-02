---
title: Präsentationen auf Android mit Kennwörtern sichern
linktitle: Kennwortschutz
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
- Kennwort festlegen
- Kennwort hinzufügen
- PowerPoint verschlüsseln
- Präsentation verschlüsseln
- PowerPoint entschlüsseln
- Präsentation entschlüsseln
- Schreibschutz
- PowerPoint Sicherheit
- Präsentationssicherheit
- Kennwort entfernen
- Schutz entfernen
- Verschlüsselung entfernen
- Kennwort deaktivieren
- Schutz deaktivieren
- Schreibschutz entfernen
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Sperren und entsperren Sie mühelos kennwortgeschützte PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Android über Java. Schützen Sie Ihre Präsentationen."
---
## **Einführung**

Wenn Sie eine Präsentation mit einem Kennwort schützen, legen Sie ein Kennwort fest, das bestimmte Einschränkungen für die Präsentation durchsetzt. Um die Einschränkungen zu entfernen, muss das Kennwort eingegeben werden. Eine kennwortgeschützte Präsentation gilt als gesperrte Präsentation.

Typischerweise können Sie ein Kennwort setzen, um diese Einschränkungen für eine Präsentation durchzusetzen:

- **Änderungen**

  Wenn Sie nur bestimmten Benutzern das Ändern Ihrer Präsentation erlauben möchten, können Sie eine Änderungsbeschränkung festlegen. Diese Beschränkung verhindert, dass Personen Ihre Präsentation ändern, verändern oder Inhalte kopieren (es sei denn, sie geben das Kennwort ein).

  In diesem Fall kann ein Benutzer jedoch ohne Kennwort auf das Dokument zugreifen und es öffnen. Im Nur-Lese‑Modus kann der Benutzer die Inhalte – Hyperlinks, Animationen, Effekte usw. – Ihrer Präsentation ansehen, aber keine Elemente kopieren oder die Präsentation speichern.

- **Öffnen**

  Wenn Sie nur bestimmten Benutzern das Öffnen Ihrer Präsentation erlauben möchten, können Sie eine Öffnungsbeschränkung festlegen. Diese Beschränkung verhindert, dass Personen überhaupt den Inhalt Ihrer Präsentation sehen (es sei denn, sie geben das Kennwort ein).

  Technisch verhindert die Öffnungsbeschränkung auch Änderungen: Wenn Personen eine Präsentation nicht öffnen können, können sie sie nicht ändern.

  **Hinweis**: Wenn Sie eine Präsentation mit Kennwort schützen, um das Öffnen zu verhindern, wird die Präsentationsdatei verschlüsselt.

## **Kennwortschutz für Präsentationen in Aspose.Slides**
**Unterstützte Formate**

Aspose.Slides unterstützt Kennwortschutz, Verschlüsselung und ähnliche Vorgänge für Präsentationen in folgenden Formaten:

- PPTX und PPT – Microsoft PowerPoint‑Präsentation
- ODP – OpenDocument‑Präsentation
- OTP – OpenDocument‑Präsentationsvorlage

**Unterstützte Vorgänge**

Aspose.Slides ermöglicht den Kennwortschutz von Präsentationen, um Änderungen auf folgende Weise zu verhindern:

- Verschlüsseln einer Präsentation
- Festlegen eines Schreibschutzes für eine Präsentation

**Weitere Vorgänge**

Aspose.Slides ermöglicht weitere Aufgaben im Zusammenhang mit Kennwortschutz und Verschlüsselung:

- Entschlüsseln einer Präsentation; Öffnen einer verschlüsselten Präsentation
- Entfernen der Verschlüsselung; Deaktivieren des Kennwortschutzes
- Entfernen des Schreibschutzes von einer Präsentation
- Abrufen der Eigenschaften einer verschlüsselten Präsentation
- Prüfen, ob eine Präsentation verschlüsselt ist
- Prüfen, ob eine Präsentation kennwortgeschützt ist.

## **Verschlüsseln einer Präsentation**

Sie können eine Präsentation verschlüsseln, indem Sie ein Kennwort festlegen. Um die gesperrte Präsentation zu ändern, muss ein Benutzer das Kennwort eingeben.

Um eine Präsentation zu verschlüsseln oder mit Kennwort zu schützen, verwenden Sie die **encrypt**‑Methode (aus [IProtectionManager](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IProtectionManager)), um ein Kennwort für die Präsentation zu setzen. Sie übergeben das Kennwort an die **encrypt**‑Methode und verwenden die **save**‑Methode, um die nun verschlüsselte Präsentation zu speichern.

Der folgende Beispielcode zeigt, wie man eine Präsentation verschlüsselt:

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

Sie können einer Präsentation einen Hinweis „Nicht ändern“ hinzufügen. Auf diese Weise teilen Sie den Benutzern mit, dass Sie nicht möchten, dass sie Änderungen vornehmen.

**Hinweis**: Der Schreibschutzvorgang verschlüsselt die Präsentation nicht. Daher können Benutzer – falls sie es wirklich wollen – die Präsentation ändern, aber zum Speichern der Änderungen müssen sie die Präsentation unter einem anderen Namen speichern.

Um einen Schreibschutz festzulegen, verwenden Sie die Methode [setWriteProtection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-). Der folgende Beispielcode zeigt, wie man einen Schreibschutz für eine Präsentation setzt:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Laden einer verschlüsselten Präsentation**

Aspose.Slides ermöglicht das Laden einer verschlüsselten Datei, indem das Kennwort übergeben wird. Um eine Präsentation zu entschlüsseln, rufen Sie die Methode [removeEncryption](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) ohne Parameter auf. Anschließend müssen Sie das korrekte Kennwort eingeben, um die Präsentation zu laden.

Der folgende Beispielcode zeigt, wie man eine Präsentation entschlüsselt:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // mit entschlüsselter Präsentation arbeiten
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Verschlüsselung einer Präsentation entfernen**

Sie können die Verschlüsselung bzw. den Kennwortschutz einer Präsentation entfernen. Dadurch können Benutzer die Präsentation ohne Einschränkungen öffnen oder ändern.

Um die Verschlüsselung bzw. den Kennwortschutz zu entfernen, rufen Sie die Methode [removeEncryption](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) auf. Der folgende Beispielcode zeigt, wie man die Verschlüsselung einer Präsentation entfernt:

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

## **Schreibschutz einer Präsentation entfernen**

Sie können mit Aspose.Slides den Schreibschutz einer Präsentationsdatei entfernen. Damit können Benutzer die Datei nach Belieben ändern, ohne dass Warnungen angezeigt werden.

Entfernen Sie den Schreibschutz, indem Sie die Methode [removeWriteProtection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IProtectionManager#removeWriteProtection--) verwenden. Der folgende Beispielcode zeigt, wie man den Schreibschutz einer Präsentation entfernt:

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

Benutzer haben häufig Schwierigkeiten, die Dokumenteigenschaften einer verschlüsselten oder kennwortgeschützten Präsentation abzurufen. Aspose.Slides bietet jedoch einen Mechanismus, mit dem Sie eine Präsentation kennwortschützen können, während die Eigenschaften weiterhin zugänglich bleiben.

**Hinweis:** Standardmäßig werden bei der Verschlüsselung einer Präsentation durch Aspose.Slides auch die Dokumenteigenschaften kennwortgeschützt. Wenn Sie die Dokumenteigenschaften nach der Verschlüsselung zugänglich machen möchten, ermöglicht Aspose.Slides genau das.

Wenn Sie möchten, dass Benutzer die Eigenschaften einer verschlüsselten Präsentation weiterhin einsehen können, übergeben Sie `false` an [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-). Der folgende Beispielcode zeigt, wie man eine Präsentation verschlüsselt und gleichzeitig die Dokumenteigenschaften zugänglich macht:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Nur Dokumenteigenschaften einer verschlüsselten Präsentation laden**

Um die Metadaten einer verschlüsselten Präsentation zu prüfen, ohne deren Folien oder anderen Inhalt zu laden, erstellen Sie ein [LoadOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/loadoptions/)-Objekt und setzen `true` für [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iloadoptions/#setOnlyLoadDocumentProperties-boolean-). In diesem Modus ignoriert Aspose.Slides das Kennwort und lädt ausschließlich die öffentlich zugänglichen Dokumenteigenschaften.

Der folgende Code liest eingebaute und benutzerdefinierte Dokumenteigenschaften über [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--):

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    // Eingebaute Dokumenteigenschaften lesen.
    System.out.println("Title: " + documentProperties.getTitle());
    System.out.println("Author: " + documentProperties.getAuthor());

    // Benutzerdefinierte Dokumenteigenschaften lesen.
    int customPropertyCount = documentProperties.getCountOfCustomProperties();

    for (int propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++) {
        String propertyName = documentProperties.getCustomPropertyName(propertyIndex);
        Object propertyValue = documentProperties.get_Item(propertyName);

        System.out.println(propertyName + ": " + propertyValue);
    }
} finally {
    presentation.dispose();
}
```

Dieser Workflow funktioniert nur, wenn die Dokumenteigenschaften beim Verschlüsseln der Präsentation nicht verschlüsselt (öffentlich) waren. Sind die Dokumenteigenschaften verschlüsselt, führt das Setzen von `true` bei `loadOptions.setOnlyLoadDocumentProperties` zu einer Ausnahme, da das Kennwort in diesem Modus ignoriert wird. Um verschlüsselte Dokumenteigenschaften zu lesen oder die komplette Präsentation zu laden, übergeben Sie das korrekte Kennwort über [ILoadOptions.setPassword](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-).

## **Prüfen, ob eine Präsentation kennwortgeschützt ist**

Bevor Sie eine Präsentation laden, möchten Sie vielleicht prüfen, ob sie bereits mit einem Kennwort geschützt ist. So können Sie Fehler vermeiden, die beim Laden einer kennwortgeschützten Präsentation ohne Kennwort auftreten.

Der folgende Java‑Code zeigt, wie man prüft, ob eine Präsentation kennwortgeschützt ist (ohne die Präsentation selbst zu laden):

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Prüfen, ob eine Präsentation verschlüsselt ist**

Aspose.Slides ermöglicht das Prüfen, ob eine Präsentation verschlüsselt ist. Verwenden Sie dazu die Eigenschaft [isEncrypted](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IProtectionManager#isEncrypted--), die `true` zurückgibt, wenn die Präsentation verschlüsselt ist, andernfalls `false`.

Der folgende Beispielcode zeigt, wie man prüft, ob eine Präsentation verschlüsselt ist:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Prüfen, ob eine Präsentation schreibgeschützt ist**

Aspose.Slides ermöglicht das Prüfen, ob eine Präsentation schreibgeschützt ist. Verwenden Sie dazu die Eigenschaft [isWriteProtected](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IProtectionManager#isWriteProtected--), die `true` zurückgibt, wenn die Präsentation schreibgeschützt ist, andernfalls `false`.

Der folgende Beispielcode zeigt, wie man prüft, ob eine Präsentation schreibgeschützt ist:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Validieren oder Bestätigen, dass ein bestimmtes Kennwort verwendet wurde**

Möglicherweise wollen Sie prüfen und bestätigen, dass ein bestimmtes Kennwort zum Schutz einer Präsentationsdatei verwendet wurde. Aspose.Slides stellt Mittel bereit, ein Kennwort zu validieren.

Der folgende Beispielcode zeigt, wie man ein Kennwort validiert:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // prüfen, ob "pass" übereinstimmt
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

Er gibt `true` zurück, wenn die Präsentation mit dem angegebenen Kennwort verschlüsselt wurde, andernfalls `false`.

{{% alert color="primary" title="Siehe auch" %}} 
- [Digital Signature in PowerPoint](/slides/de/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Welche Verschlüsselungsmethoden unterstützt Aspose.Slides?**

Aspose.Slides unterstützt moderne Verschlüsselungsverfahren, einschließlich AES‑basierter Algorithmen, und stellt damit ein hohes Maß an Datensicherheit für Ihre Präsentationen sicher.

**Was passiert, wenn beim Öffnen einer Präsentation ein falsches Kennwort eingegeben wird?**

Es wird eine Ausnahme ausgelöst, die anzeigt, dass der Zugriff auf die Präsentation verweigert wurde. Dies verhindert unbefugten Zugriff und schützt den Inhalt der Präsentation.

**Gibt es Leistungseinbußen bei der Arbeit mit kennwortgeschützten Präsentationen?**

Der Verschlüsselungs‑ und Entschlüsselungsprozess kann beim Öffnen und Speichern einen leichten Overhead verursachen. In den meisten Fällen ist dieser Einfluss jedoch gering und beeinträchtigt die Gesamtablaufzeit Ihrer Präsentationsaufgaben kaum.