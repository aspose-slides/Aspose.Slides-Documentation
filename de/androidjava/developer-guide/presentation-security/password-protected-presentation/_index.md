---
title: Präsentationen auf Android mit Passwörtern sichern
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
description: "Sperren und entsperren Sie mühelos passwortgeschützte PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Android via Java. Schützen Sie Ihre Präsentationen."
---
## **Einleitung**

Wenn Sie eine Präsentation mit einem Kennwort schützen, bedeutet das, dass Sie ein Kennwort festlegen, das bestimmte Einschränkungen für die Präsentation durchsetzt. Um die Einschränkungen zu entfernen, muss das Kennwort eingegeben werden. Eine kennwortgeschützte Präsentation wird als gesperrte Präsentation betrachtet.

Typischerweise können Sie ein Kennwort festlegen, um diese Einschränkungen für eine Präsentation durchzusetzen:

- **Änderung**

  Wenn Sie möchten, dass nur bestimmte Benutzer Ihre Präsentation bearbeiten können, können Sie eine Änderungsbeschränkung festlegen. Diese Beschränkung verhindert, dass Personen Ihre Präsentation ändern, modifizieren oder Inhalte kopieren (es sei denn, sie geben das Kennwort an).

  Allerdings kann in diesem Fall ein Benutzer das Dokument auch ohne Kennwort öffnen und darauf zugreifen. Im Nur‑Lese‑Modus kann der Benutzer die Inhalte der Präsentation – Hyperlinks, Animationen, Effekte und andere Elemente – ansehen, jedoch keine Elemente kopieren oder die Präsentation speichern.

- **Öffnen**

  Wenn Sie möchten, dass nur bestimmte Benutzer Ihre Präsentation öffnen können, können Sie eine Öffnungsbeschränkung festlegen. Diese Beschränkung verhindert, dass Personen überhaupt die Inhalte Ihrer Präsentation sehen können (es sei denn, sie geben das Kennwort an).

  Technisch verhindert die Öffnungsbeschränkung außerdem, dass Benutzer Ihre Präsentationen ändern: Wenn Personen eine Präsentation nicht öffnen können, können sie sie nicht modifizieren oder ändern.  

  **Hinweis**: Wenn Sie eine Präsentation mit einem Kennwort schützen, um das Öffnen zu verhindern, wird die Präsentationsdatei verschlüsselt.

## **Passwortschutz für Präsentationen in Aspose.Slides**
**Unterstützte Formate**

Aspose.Slides unterstützt Passwortschutz, Verschlüsselung und ähnliche Vorgänge für Präsentationen in diesen Formaten: 

- PPTX und PPT – Microsoft PowerPoint-Präsentation 
- ODP – OpenDocument-Präsentation 
- OTP – OpenDocument-Präsentationsvorlage 

**Unterstützte Vorgänge**

Aspose.Slides ermöglicht es Ihnen, Passwortschutz für Präsentationen zu verwenden, um Änderungen auf folgende Weise zu verhindern:

- Verschlüsseln einer Präsentation
- Festlegen eines Schreibschutzes für eine Präsentation

**Weitere Vorgänge**

Aspose.Slides ermöglicht Ihnen, weitere Aufgaben im Zusammenhang mit Passwortschutz und Verschlüsselung wie folgt durchzuführen:

- Entschlüsseln einer Präsentation; Öffnen einer verschlüsselten Präsentation
- Entfernen der Verschlüsselung; Deaktivieren des Passwortschutzes
- Entfernen des Schreibschutzes von einer Präsentation
- Abrufen der Eigenschaften einer verschlüsselten Präsentation
- Prüfen, ob eine Präsentation verschlüsselt ist
- Prüfen, ob eine Präsentation passwortgeschützt ist.

## **Verschlüsseln einer Präsentation**

Sie können eine Präsentation verschlüsseln, indem Sie ein Kennwort festlegen. Um die gesperrte Präsentation zu ändern, muss ein Benutzer das Kennwort angeben. 

Um eine Präsentation zu verschlüsseln oder mit einem Kennwort zu schützen, müssen Sie die encrypt‑Methode (aus [IProtectionManager](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IProtectionManager)) verwenden, um ein Kennwort für die Präsentation festzulegen. Sie übergeben das Kennwort an die encrypt‑Methode und verwenden die save‑Methode, um die nun verschlüsselte Präsentation zu speichern.

Dieser Beispielcode zeigt, wie Sie eine Präsentation verschlüsseln:

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

Sie können einer Präsentation einen Hinweis „Nicht ändern“ hinzufügen. Auf diese Weise können Sie den Benutzern mitteilen, dass Sie nicht möchten, dass sie Änderungen an der Präsentation vornehmen.  

**Hinweis**: Der Schreibschutzvorgang verschlüsselt die Präsentation nicht. Daher können Benutzer—wenn sie möchten—die Präsentation ändern, müssen jedoch zum Speichern der Änderungen eine Präsentation unter einem anderen Namen erstellen. 

Um einen Schreibschutz festzulegen, müssen Sie die [setWriteProtection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-)‑Methode verwenden. Dieser Beispielcode zeigt, wie Sie einer Präsentation einen Schreibschutz hinzufügen:

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

## **Verschlüsselte Präsentation laden**

Aspose.Slides ermöglicht das Laden einer verschlüsselten Präsentation, indem das korrekte Kennwort über [LoadOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/loadoptions/) übergeben wird.

Dieser Beispielcode zeigt, wie Sie eine verschlüsselte Präsentation öffnen: 

```java
import com.aspose.slides.*;

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

Sie können die Verschlüsselung bzw. den Passwortschutz einer Präsentation entfernen. Auf diese Weise können Benutzer die Präsentation ohne Einschränkungen öffnen oder ändern.

Um die Verschlüsselung oder den Passwortschutz zu entfernen, müssen Sie die [removeEncryption](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--)‑Methode aufrufen. Dieser Beispielcode zeigt, wie Sie die Verschlüsselung einer Präsentation entfernen:

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

Sie können mit Aspose.Slides den Schreibschutz einer Präsentationsdatei entfernen. Auf diese Weise können Benutzer nach Belieben ändern – und es gibt keine Warnungen bei solchen Vorgängen.

Sie können den Schreibschutz einer Präsentation mit der [removeWriteProtection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IProtectionManager#removeWriteProtection--)‑Methode entfernen. Dieser Beispielcode zeigt, wie Sie den Schreibschutz einer Präsentation entfernen:

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

In der Regel haben Benutzer Schwierigkeiten, die Dokumenteigenschaften einer verschlüsselten oder passwortgeschützten Präsentation abzurufen. Aspose.Slides bietet jedoch einen Mechanismus, mit dem Sie eine Präsentation schützen können, wobei Benutzer weiterhin Zugriff auf deren Eigenschaften haben.  

**Hinweis:** Standardmäßig werden beim Verschlüsseln einer Präsentation mit Aspose.Slides auch die Dokumenteigenschaften der Präsentation passwortgeschützt. Wenn Sie die Dokumenteigenschaften nach der Verschlüsselung zugänglich machen müssen, ermöglicht Ihnen Aspose.Slides genau das.

Wenn Sie möchten, dass Benutzer weiterhin die Eigenschaften einer verschlüsselten Präsentation abrufen können, übergeben Sie `false` an [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-). Dieser Beispielcode zeigt, wie Sie eine Präsentation verschlüsseln und dennoch Benutzern Zugriff auf die Dokumenteigenschaften gewähren:

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

Um die Metadaten einer verschlüsselten Präsentation zu prüfen, ohne ihre Folien oder anderen Inhalte zu laden, erstellen Sie ein [LoadOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/loadoptions/)-Objekt und übergeben `true` an [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iloadoptions/#setOnlyLoadDocumentProperties-boolean-). In diesem Modus ignoriert Aspose.Slides das Kennwort und lädt nur die öffentlich zugänglichen Dokumenteigenschaften.

Das folgende Codebeispiel liest integrierte und benutzerdefinierte Dokumenteigenschaften über [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--):

```java
import com.aspose.slides.*;

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

Dieser Workflow funktioniert nur, wenn die Dokumenteigenschaften bei der Verschlüsselung der Präsentation unverschlüsselt (öffentlich) gelassen wurden. Sind die Dokumenteigenschaften verschlüsselt, führt das Übergeben von `true` an `loadOptions.setOnlyLoadDocumentProperties` zu einer Ausnahme, weil das Kennwort in diesem Modus ignoriert wird. Um verschlüsselte Dokumenteigenschaften zuzugreifen oder die komplette Präsentation einschließlich Folien und sonstigem Inhalt zu laden, geben Sie das korrekte Kennwort über [ILoadOptions.setPassword](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) an.

## **Prüfen, ob eine Präsentation passwortgeschützt ist**

Bevor Sie eine Präsentation laden, möchten Sie möglicherweise prüfen und bestätigen, dass die Präsentation nicht mit einem Kennwort geschützt ist. So vermeiden Sie Fehler und ähnliche Probleme, die auftreten, wenn eine passwortgeschützte Präsentation ohne ihr Kennwort geladen wird.

Dieser Java‑Code zeigt, wie Sie eine Präsentation prüfen können, ob sie passwortgeschützt ist (ohne die Präsentation selbst zu laden):

```java
import com.aspose.slides.*;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Prüfen, ob eine Präsentation verschlüsselt ist**

Aspose.Slides ermöglicht es Ihnen, zu prüfen, ob eine Präsentation verschlüsselt ist. Dafür können Sie die [isEncrypted](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IProtectionManager#isEncrypted--)‑Eigenschaft verwenden, die `true` zurückgibt, wenn die Präsentation verschlüsselt ist, bzw. `false`, wenn sie nicht verschlüsselt ist.

Dieser Beispielcode zeigt, wie Sie prüfen können, ob eine Präsentation verschlüsselt ist:

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

Aspose.Slides ermöglicht es Ihnen, zu prüfen, ob eine Präsentation schreibgeschützt ist. Dafür können Sie die [isWriteProtected](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IProtectionManager#isWriteProtected--)‑Eigenschaft verwenden, die `true` zurückgibt, wenn die Präsentation schreibgeschützt ist, bzw. `false`, wenn sie es nicht ist.

Dieser Beispielcode zeigt, wie Sie prüfen können, ob eine Präsentation schreibgeschützt ist:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Überprüfen oder Bestätigen, dass ein bestimmtes Kennwort verwendet wurde**

Möglicherweise möchten Sie prüfen und bestätigen, dass ein bestimmtes Kennwort zum Schutz eines Präsentationsdokuments verwendet wurde. Aspose.Slides stellt Mittel zur Verfügung, ein Kennwort zu validieren. 

Dieser Beispielcode zeigt, wie Sie ein Kennwort validieren:

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

Er liefert `true`, wenn die Präsentation mit dem angegebenen Kennwort schreibgeschützt wurde. Andernfalls liefert er `false`. 

{{% alert color="info" title="Siehe auch" %}} 
- [Digitale Signatur in PowerPoint](/slides/de/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Welche Verschlüsselungsmethoden werden von Aspose.Slides unterstützt?**

Aspose.Slides unterstützt moderne Verschlüsselungsmethoden, einschließlich AES‑basierter Algorithmen, und gewährleistet so ein hohes Maß an Datensicherheit für Ihre Präsentationen.

**Was geschieht, wenn beim Versuch, eine Präsentation zu öffnen, ein falsches Kennwort eingegeben wird?**

Wird ein falsches Kennwort verwendet, wird eine Ausnahme ausgelöst, die anzeigt, dass der Zugriff auf die Präsentation verweigert wird. Dies verhindert unbefugten Zugriff und schützt den Inhalt der Präsentation.

**Gibt es Performance‑Auswirkungen bei der Arbeit mit passwortgeschützten Präsentationen?**

Der Verschlüsselungs‑ und Entschlüsselungsprozess kann beim Öffnen und Speichern einen geringen Overhead verursachen. In den meisten Fällen ist diese Auswirkung minimal und beeinträchtigt die Gesamtdauer Ihrer Präsentationsaufgaben kaum.