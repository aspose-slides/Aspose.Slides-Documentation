---
title: Präsentationen mit Passwörtern in Java sichern
linktitle: Passwortschutz
type: docs
weight: 20
url: /de/java/password-protected-presentation/
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
- presentation
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie mit Aspose.Slides für Java PowerPoint- und OpenDocument-Präsentationen mühelos sperren und entsperren können. Sichern Sie Ihre Präsentationen."
---
## **Einleitung**

Wenn Sie eine Präsentation mit einem Kennwort schützen, legen Sie ein Kennwort fest, das bestimmte Einschränkungen für die Präsentation erzwingt. Um diese Einschränkungen zu entfernen, muss das Kennwort eingegeben werden. Eine kennwortgeschützte Präsentation gilt als gesperrte Präsentation.

Typischerweise können Sie ein Kennwort festlegen, um diese Einschränkungen für eine Präsentation zu erzwingen:

- **Änderungen**

Wenn Sie nur bestimmten Benutzern das Ändern Ihrer Präsentation erlauben möchten, können Sie eine Änderungsbeschränkung festlegen. Diese Beschränkung verhindert, dass Personen Elemente in Ihrer Präsentation ändern, anpassen oder kopieren, sofern sie nicht das Kennwort angeben.

Auch ohne das Kennwort kann ein Benutzer Ihr Dokument weiterhin öffnen und darauf zugreifen. In diesem Nur-Lese‑Modus kann der Benutzer den Inhalt – einschließlich Hyperlinks, Animationen, Effekte und anderer Elemente – in Ihrer Präsentation ansehen, jedoch keine Elemente kopieren oder die Präsentation speichern.

- **Öffnen**

Wenn Sie nur bestimmten Benutzern das Öffnen Ihrer Präsentation erlauben möchten, können Sie eine Öffnungsbeschränkung festlegen. Diese Beschränkung verhindert, dass Personen überhaupt den Inhalt Ihrer Präsentation ansehen, solange sie nicht das Kennwort angeben.

Technisch verhindert die Öffnungsbeschränkung zudem, dass Benutzer Ihre Präsentationen ändern – wenn jemand eine Präsentation nicht öffnen kann, kann er sie auch nicht ändern.

**Hinweis:** Wenn Sie eine Präsentation mit Kennwort schützen, um das Öffnen zu verhindern, wird die Präsentationsdatei verschlüsselt.

## **Kennwortschutz in Aspose.Slides**
**Unterstützte Formate**

Aspose.Slides unterstützt Kennwortschutz, Verschlüsselung und ähnliche Vorgänge für Präsentationen in diesen Formaten:

- PPTX und PPT – Microsoft PowerPoint‑Präsentation
- ODP – OpenDocument‑Präsentation
- OTP – OpenDocument‑Präsentationsvorlage

**Unterstützte Vorgänge**

Aspose.Slides ermöglicht es Ihnen, Kennwortschutz auf Präsentationen anzuwenden, um Änderungen wie folgt zu verhindern:

- Verschlüsseln einer Präsentation
- Festlegen eines Schreibschutzes für eine Präsentation

**Weitere Vorgänge**

Aspose.Slides erlaubt Ihnen, weitere Aufgaben im Zusammenhang mit Kennwortschutz und Verschlüsselung wie folgt auszuführen:

- Entschlüsseln einer Präsentation; Öffnen einer verschlüsselten Präsentation
- Entfernen der Verschlüsselung; Deaktivieren des Kennwortschutzes
- Entfernen des Schreibschutzes von einer Präsentation
- Abrufen der Eigenschaften einer verschlüsselten Präsentation
- Prüfen, ob eine Präsentation verschlüsselt ist
- Prüfen, ob eine Präsentation kennwortgeschützt ist.

## **Eine Präsentation mit einem Kennwort schützen**

Sie können eine Präsentation verschlüsseln, indem Sie ein Kennwort festlegen. Um die gesperrte Präsentation zu ändern, muss ein Benutzer das Kennwort angeben.

Um eine Präsentation zu verschlüsseln oder kennwortzuschützen, verwenden Sie die `encrypt`‑Methode (aus [IProtectionManager](https://reference.aspose.com/slides/de/java/com.aspose.slides/IProtectionManager)) zum Festlegen eines Kennworts für die Präsentation. Sie übergeben das Kennwort an die `encrypt`‑Methode und verwenden die `save`‑Methode, um die nun verschlüsselte Präsentation zu speichern.

Der folgende Beispielcode zeigt, wie Sie eine Präsentation verschlüsseln:

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

Sie können einer Präsentation einen Hinweis „Nicht ändern“ hinzufügen. Auf diese Weise teilen Sie den Benutzern mit, dass Sie nicht möchten, dass Änderungen an der Präsentation vorgenommen werden.

**Hinweis** Der Schreibschutzvorgang verschlüsselt die Präsentation nicht. Daher können Benutzer – falls sie es möchten – die Präsentation ändern, müssen jedoch zum Speichern der Änderungen eine Datei unter einem anderen Namen erstellen.

Zum Festlegen eines Schreibschutzes verwenden Sie die Methode [setWriteProtection](https://reference.aspose.com/slides/de/java/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-). Der folgende Beispielcode zeigt, wie Sie einen Schreibschutz für eine Präsentation festlegen:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Verschlüsselte Präsentation laden**

Aspose.Slides ermöglicht das Laden einer verschlüsselten Datei durch Angabe des Kennworts. Um eine Präsentation zu entschlüsseln, rufen Sie die Methode [removeEncryption](https://reference.aspose.com/slides/de/java/com.aspose.slides/IProtectionManager#removeEncryption--) ohne Parameter auf. Anschließend müssen Sie das korrekte Kennwort eingeben, um die Präsentation zu laden.

Der folgende Beispielcode zeigt, wie Sie eine Präsentation entschlüsseln:

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

Sie können die Verschlüsselung oder den Kennwortschutz einer Präsentation entfernen. Auf diese Weise können Benutzer die Präsentation ohne Einschränkungen öffnen oder ändern.

Um die Verschlüsselung oder den Kennwortschutz zu entfernen, rufen Sie die Methode [removeEncryption](https://reference.aspose.com/slides/de/java/com.aspose.slides/IProtectionManager#removeEncryption--) auf. Der folgende Beispielcode zeigt, wie Sie die Verschlüsselung einer Präsentation entfernen:

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

Sie können mit Aspose.Slides den Schreibschutz einer Präsentationsdatei entfernen. Damit können Benutzer die Datei nach Belieben ändern – ohne Warnungen bei solchen Vorgängen.

Den Schreibschutz einer Präsentation entfernen Sie mit der Methode [removeWriteProtection](https://reference.aspose.com/slides/de/java/com.aspose.slides/IProtectionManager#removeWriteProtection--) . Der folgende Beispielcode zeigt, wie Sie den Schreibschutz einer Präsentation entfernen:

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

Benutzer haben häufig Schwierigkeiten, die Dokumenteigenschaften einer verschlüsselten oder kennwortgeschützten Präsentation abzurufen. Aspose.Slides bietet jedoch einen Mechanismus, der es Ihnen ermöglicht, eine Präsentation zu schützen und gleichzeitig den Zugriff auf ihre Eigenschaften zuzulassen.

**Hinweis:** Standardmäßig werden beim Verschlüsseln einer Präsentation durch Aspose.Slides die Dokumenteigenschaften ebenfalls kennwortgeschützt. Wenn Sie die Dokumenteigenschaften auch nach der Verschlüsselung zugänglich machen möchten, bietet Aspose.Slides die entsprechende Option.

Wenn Sie Benutzern erlauben wollen, die Eigenschaften einer verschlüsselten Präsentation weiterhin zu sehen, übergeben Sie `false` an [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-). Der folgende Beispielcode zeigt, wie Sie eine Präsentation verschlüsseln und gleichzeitig den Zugriff auf die Dokumenteigenschaften ermöglichen:

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

Um die Metadaten einer verschlüsselten Präsentation zu prüfen, ohne deren Folien oder anderen Inhalt zu laden, erstellen Sie ein [LoadOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/loadoptions/)‑Objekt und setzen `true` bei [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/iloadoptions/#setOnlyLoadDocumentProperties-boolean-). In diesem Modus ignoriert Aspose.Slides das Kennwort und lädt ausschließlich die öffentlich zugänglichen Dokumenteigenschaften.

Der folgende Code liest integrierte und benutzerdefinierte Dokumenteigenschaften über [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentation/#getDocumentProperties--):

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    // Eingebaute Dokumenteigenschaften auslesen.
    System.out.println("Title: " + documentProperties.getTitle());
    System.out.println("Author: " + documentProperties.getAuthor());

    // Benutzerdefinierte Dokumenteigenschaften auslesen.
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

Dieser Workflow funktioniert nur, wenn die Dokumenteigenschaften beim Verschlüsseln der Präsentation nicht geschützt (öffentlich) gelassen wurden. Sind die Dokumenteigenschaften verschlüsselt, führt das Setzen von `true` bei `loadOptions.setOnlyLoadDocumentProperties` zu einer Ausnahme, weil das Kennwort in diesem Modus ignoriert wird. Um verschlüsselte Dokumenteigenschaften zuzugreifen oder die komplette Präsentation einschließlich Folien und Inhalte zu laden, geben Sie das korrekte Kennwort über [ILoadOptions.setPassword](https://reference.aspose.com/slides/de/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) an.

## **Prüfen, ob eine Präsentation kennwortgeschützt ist**

Bevor Sie eine Präsentation laden, möchten Sie möglicherweise prüfen, ob die Präsentation nicht mit einem Kennwort geschützt ist. Auf diese Weise vermeiden Sie Fehler und ähnliche Probleme, die auftreten, wenn eine kennwortgeschützte Präsentation ohne Kennwort geladen wird.

Der folgende Java‑Code zeigt, wie Sie prüfen können, ob eine Präsentation kennwortgeschützt ist (ohne die Präsentation selbst zu laden):

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Prüfen, ob eine Präsentation verschlüsselt ist**

Aspose.Slides ermöglicht das Prüfen, ob eine Präsentation verschlüsselt ist. Verwenden Sie dafür die Eigenschaft [isEncrypted](https://reference.aspose.com/slides/de/java/com.aspose.slides/IProtectionManager#isEncrypted--), die `true` zurückgibt, wenn die Präsentation verschlüsselt ist, und `false`, wenn sie nicht verschlüsselt ist.

Der folgende Beispielcode zeigt, wie Sie prüfen, ob eine Präsentation verschlüsselt ist:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Prüfen, ob eine Präsentation schreibgeschützt ist**

Aspose.Slides ermöglicht das Prüfen, ob eine Präsentation schreibgeschützt ist. Verwenden Sie dafür die Eigenschaft [isWriteProtected](https://reference.aspose.com/slides/de/java/com.aspose.slides/IProtectionManager#isWriteProtected--) , die `true` zurückgibt, wenn die Präsentation schreibgeschützt ist, und `false`, wenn sie nicht schreibgeschützt ist.

Der folgende Beispielcode zeigt, wie Sie prüfen, ob eine Präsentation schreibgeschützt ist:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Validieren oder bestätigen, dass ein bestimmtes Kennwort verwendet wurde**

Möglicherweise möchten Sie prüfen und bestätigen, dass ein bestimmtes Kennwort zum Schutz eines Präsentationsdokuments verwendet wurde. Aspose.Slides stellt die Möglichkeit bereit, ein Kennwort zu validieren.

Der folgende Beispielcode zeigt, wie Sie ein Kennwort validieren:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // prüfen, ob "pass" übereinstimmt mit
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

Er gibt `true` zurück, wenn die Präsentation mit dem angegebenen Kennwort verschlüsselt wurde; andernfalls `false`.

{{% alert color="primary" title="Siehe auch" %}} 
- [Digitale Signatur in PowerPoint](/slides/de/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Welche Verschlüsselungsmethoden werden von Aspose.Slides unterstützt?**

Aspose.Slides unterstützt moderne Verschlüsselungsmethoden, einschließlich AES‑basierter Algorithmen, und gewährleistet ein hohes Maß an Datensicherheit für Ihre Präsentationen.

**Was geschieht, wenn ein falsches Kennwort beim Öffnen einer Präsentation eingegeben wird?**

Es wird eine Ausnahme ausgelöst, wenn ein falsches Kennwort verwendet wird, wodurch Sie darüber informiert werden, dass der Zugriff auf die Präsentation verweigert wird. Dies trägt zur Verhinderung unbefugten Zugriffs und zum Schutz des Präsentationsinhalts bei.

**Gibt es Leistungseinbußen bei der Arbeit mit kennwortgeschützten Präsentationen?**

Der Verschlüsselungs‑ und Entschlüsselungsprozess kann beim Öffnen und Speichern einen geringen Mehraufwand verursachen. In den meisten Fällen ist die Auswirkung auf die Gesamtverarbeitungszeit Ihrer Präsentationsaufgaben minimal.