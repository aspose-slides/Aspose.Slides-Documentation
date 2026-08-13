---
title: Sichere Präsentationen mit Passwörtern in Java
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
- PowerPoint-Sicherheit
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
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Java mühelos sperren und entsperren können. Sichern Sie Ihre Präsentationen."
---
## **Einführung**

Wenn Sie eine Präsentation mit einem Kennwort schützen, legen Sie ein Kennwort fest, das bestimmte Einschränkungen für die Präsentation durchsetzt. Um diese Einschränkungen zu entfernen, muss das Kennwort eingegeben werden. Eine kennwortgeschützte Präsentation gilt als gesperrte Präsentation.

Typischerweise können Sie ein Kennwort festlegen, um diese Einschränkungen für eine Präsentation durchzusetzen:

- **Änderung**

Wenn Sie nur bestimmten Benutzern erlauben möchten, Ihre Präsentation zu ändern, können Sie eine Änderungsbeschränkung festlegen. Diese Beschränkung verhindert, dass Personen Elemente Ihrer Präsentation ändern, anpassen oder kopieren, sofern sie nicht das Kennwort angeben.

Auch ohne das Kennwort kann ein Benutzer Ihr Dokument weiterhin öffnen und darauf zugreifen. In diesem Nur-Lese‑Modus kann der Benutzer den Inhalt – einschließlich Hyperlinks, Animationen, Effekten und anderen Elementen – Ihrer Präsentation ansehen, jedoch keine Elemente kopieren oder die Präsentation speichern.

- **Öffnen**

Wenn Sie nur bestimmten Benutzern das Öffnen Ihrer Präsentation erlauben möchten, können Sie eine Öffnungsbeschränkung festlegen. Diese Beschränkung verhindert, dass Personen den Inhalt Ihrer Präsentation einsehen, sofern sie nicht das Kennwort angeben.

Technisch verhindert die Öffnungsbeschränkung ebenfalls Änderungen an der Präsentation – wenn Personen eine Präsentation nicht öffnen können, können sie sie nicht ändern oder bearbeiten.

**Hinweis:** Wenn Sie eine Präsentation kennwortschützen, um das Öffnen zu verhindern, wird die Präsentationsdatei verschlüsselt.

## **Kennwortschutz in Aspose.Slides**
**Unterstützte Formate**

Aspose.Slides unterstützt Kennwortschutz, Verschlüsselung und ähnliche Vorgänge für Präsentationen in diesen Formaten:

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

## **Eine Präsentation mit einem Kennwort schützen**

Sie können eine Präsentation verschlüsseln, indem Sie ein Kennwort festlegen. Um die gesperrte Präsentation zu ändern, muss der Benutzer das Kennwort angeben.

Zum Verschlüsseln oder Kennwortschützen einer Präsentation verwenden Sie die `encrypt`‑Methode (aus [IProtectionManager](https://reference.aspose.com/slides/de/java/com.aspose.slides/IProtectionManager)), um ein Kennwort für die Präsentation festzulegen. Sie übergeben das Kennwort an die `encrypt`‑Methode und verwenden die `save`‑Methode, um die nun verschlüsselte Präsentation zu speichern.

Der folgende Beispielcode zeigt, wie Sie eine Präsentation verschlüsseln:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Schreibschutz für eine Präsentation festlegen**

Sie können einer Präsentation ein Schild mit dem Hinweis „Do not modify“ hinzufügen. Auf diese Weise teilen Sie den Benutzern mit, dass Sie nicht möchten, dass Änderungen an der Präsentation vorgenommen werden.

**Hinweis**: Der Schreibschutzvorgang verschlüsselt die Präsentation nicht. Deshalb können Benutzer – falls sie möchten – die Präsentation ändern, müssen jedoch zum Speichern die Datei unter einem anderen Namen speichern.

Um einen Schreibschutz festzulegen, verwenden Sie die [setWriteProtection](https://reference.aspose.com/slides/de/java/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-)‑Methode. Der folgende Beispielcode zeigt, wie Sie einen Schreibschutz für eine Präsentation festlegen:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Eine verschlüsselte Präsentation laden**

Aspose.Slides ermöglicht das Laden einer verschlüsselten Präsentation, indem Sie das korrekte Kennwort über [LoadOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/loadoptions/) übergeben.

Der folgende Beispielcode zeigt, wie Sie eine verschlüsselte Präsentation laden:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // Arbeiten mit entschlüsselter Präsentation
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Verschlüsselung einer Präsentation entfernen**

Sie können die Verschlüsselung oder den Kennwortschutz einer Präsentation entfernen. Damit können Benutzer die Präsentation ohne Einschränkungen öffnen oder ändern.

Zum Entfernen der Verschlüsselung oder des Kennwortschutzes rufen Sie die [removeEncryption](https://reference.aspose.com/slides/de/java/com.aspose.slides/IProtectionManager#removeEncryption--)‑Methode auf. Der folgende Beispielcode zeigt, wie Sie die Verschlüsselung einer Präsentation entfernen:

```java
import com.aspose.slides.*;

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

Sie können mit Aspose.Slides den Schreibschutz einer Präsentationsdatei entfernen. Damit können Benutzer nach Belieben Änderungen vornehmen, ohne dass Warnungen erscheinen.

Sie entfernen den Schreibschutz von einer Präsentation mit der [removeWriteProtection](https://reference.aspose.com/slides/de/java/com.aspose.slides/IProtectionManager#removeWriteProtection--)‑Methode. Der folgende Beispielcode zeigt, wie Sie den Schreibschutz von einer Präsentation entfernen:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Eigenschaften einer verschlüsselten Präsentation abrufen**

Benutzer haben häufig Schwierigkeiten, die Dokumenteigenschaften einer verschlüsselten oder kennwortgeschützten Präsentation abzurufen. Aspose.Slides bietet jedoch einen Mechanismus, der es ermöglicht, eine Präsentation zu kennwortschützen und gleichzeitig den Zugriff auf ihre Eigenschaften zu erhalten.

**Hinweis:** Standardmäßig werden beim Verschlüsseln einer Präsentation durch Aspose.Slides die Dokumenteigenschaften ebenfalls kennwortgeschützt. Wenn Sie die Dokumenteigenschaften nach der Verschlüsselung zugänglich machen möchten, erlaubt Aspose.Slides genau das.

Wenn Sie den Benutzern die Möglichkeit erhalten möchten, die Eigenschaften einer verschlüsselten Präsentation abzurufen, übergeben Sie `false` an [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-). Der folgende Beispielcode zeigt, wie Sie eine Präsentation verschlüsseln und gleichzeitig den Benutzern den Zugriff auf die Dokumenteigenschaften ermöglichen:

```java
import com.aspose.slides.*;

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

Um die Metadaten einer verschlüsselten Präsentation zu inspizieren, ohne deren Folien oder anderen Inhalt zu laden, erstellen Sie ein [LoadOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/loadoptions/)-Objekt und übergeben Sie `true` an [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/iloadoptions/#setOnlyLoadDocumentProperties-boolean-). In diesem Modus ignoriert Aspose.Slides das Kennwort und lädt ausschließlich die öffentlich zugänglichen Dokumenteigenschaften.

Der folgende Code liest eingebaute und benutzerdefinierte Dokumenteigenschaften über [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentation/#getDocumentProperties--):

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

Dieser Workflow funktioniert nur, wenn die Dokumenteigenschaften beim Verschlüsseln der Präsentation nicht verschlüsselt wurden (öffentlich waren). Sind die Dokumenteigenschaften verschlüsselt, führt das Übergeben von `true` an `loadOptions.setOnlyLoadDocumentProperties` zu einer Ausnahme, weil das Kennwort in diesem Modus ignoriert wird. Um verschlüsselte Dokumenteigenschaften zuzugreifen oder die gesamte Präsentation einschließlich Folien und sonstigem Inhalt zu laden, geben Sie das korrekte Kennwort über [ILoadOptions.setPassword](https://reference.aspose.com/slides/de/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) an.

## **Prüfen, ob eine Präsentation kennwortgeschützt ist**

Bevor Sie eine Präsentation laden, möchten Sie möglicherweise prüfen, ob die Präsentation nicht mit einem Kennwort geschützt ist. So vermeiden Sie Fehler, die auftreten, wenn eine kennwortgeschützte Präsentation ohne Kennwort geladen wird.

Der folgende Java‑Code zeigt, wie Sie prüfen können, ob eine Präsentation kennwortgeschützt ist (ohne die Präsentation selbst zu laden):

```java
import com.aspose.slides.*;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Prüfen, ob eine Präsentation verschlüsselt ist**

Aspose.Slides ermöglicht das Prüfen, ob eine Präsentation verschlüsselt ist. Verwenden Sie dafür die [isEncrypted](https://reference.aspose.com/slides/de/java/com.aspose.slides/IProtectionManager#isEncrypted--)‑Eigenschaft, die `true` zurückgibt, wenn die Präsentation verschlüsselt ist, bzw. `false`, wenn sie nicht verschlüsselt ist.

Der folgende Beispielcode zeigt, wie Sie prüfen, ob eine Präsentation verschlüsselt ist:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Prüfen, ob eine Präsentation schreibgeschützt ist**

Aspose.Slides ermöglicht das Prüfen, ob eine Präsentation schreibgeschützt ist. Verwenden Sie dafür die [isWriteProtected](https://reference.aspose.com/slides/de/java/com.aspose.slides/IProtectionManager#isWriteProtected--)‑Eigenschaft, die `true` zurückgibt, wenn die Präsentation schreibgeschützt ist, bzw. `false`, wenn nicht.

Der folgende Beispielcode zeigt, wie Sie prüfen, ob eine Präsentation schreibgeschützt ist:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Validieren oder Bestätigen, dass ein bestimmtes Kennwort verwendet wurde**

Möglicherweise möchten Sie prüfen und bestätigen, dass ein bestimmtes Kennwort zum Schutz einer Präsentationsdatei verwendet wurde. Aspose.Slides bietet die Möglichkeit, ein Kennwort zu validieren.

Der folgende Beispielcode zeigt, wie Sie ein Kennwort validieren:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    // prüfen, ob "pass" übereinstimmt
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

Er gibt `true` zurück, wenn die Präsentation mit dem angegebenen Kennwort schreibgeschützt ist. Andernfalls wird `false` zurückgegeben.

{{% alert color="info" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/de/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Welche Verschlüsselungsmethoden werden von Aspose.Slides unterstützt?**

Aspose.Slides unterstützt moderne Verschlüsselungsmethoden, einschließlich AES‑basierter Algorithmen, und sorgt so für ein hohes Maß an Datensicherheit Ihrer Präsentationen.

**Was passiert, wenn beim Öffnen einer Präsentation ein falsches Kennwort eingegeben wird?**

Es wird eine Ausnahme ausgelöst, wenn ein falsches Kennwort verwendet wird, wodurch Sie darüber informiert werden, dass der Zugriff auf die Präsentation verweigert wurde. Dies hilft, unbefugten Zugriff zu verhindern und den Inhalt der Präsentation zu schützen.

**Gibt es Leistungseinbußen bei der Arbeit mit kennwortgeschützten Präsentationen?**

Der Verschlüsselungs‑ und Entschlüsselungsprozess kann beim Öffnen und Speichern leichte Overheads verursachen. In den meisten Fällen ist die Auswirkung auf die Gesamtverarbeitungszeit Ihrer Präsentationsaufgaben jedoch minimal.