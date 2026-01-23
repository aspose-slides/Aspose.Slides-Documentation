---
title: Präsentationen mit Passwörtern in PHP sichern
linktitle: Passwortschutz
type: docs
weight: 20
url: /de/php-java/password-protected-presentation/
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
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint- und OpenDocument-Präsentationen mühelos mit Passwortschutz sperren und entsperren können, mit Aspose.Slides für PHP. Sichern Sie Ihre Präsentationen."
---

## **Über den Passwortschutz**
### **Wie funktioniert der Passwortschutz für eine Präsentation?**
Wenn Sie eine Präsentation mit einem Passwort schützen, legen Sie ein Passwort fest, das bestimmte Einschränkungen für die Präsentation erzwingt. Um die Einschränkungen zu entfernen, muss das Passwort eingegeben werden. Eine passwortgeschützte Präsentation gilt als gesperrte Präsentation.

Typischerweise können Sie ein Passwort festlegen, um diese Einschränkungen für eine Präsentation zu erzwingen:

- **Änderung**

  Wenn Sie nur bestimmten Benutzern das Ändern Ihrer Präsentation erlauben wollen, können Sie eine Änderungsbeschränkung festlegen. Diese Beschränkung verhindert, dass Personen die Präsentation ändern, modifizieren oder Inhalte daraus kopieren (es sei denn, sie geben das Passwort ein). 

  In diesem Fall kann ein Benutzer jedoch auch ohne Passwort Ihr Dokument öffnen und darauf zugreifen. Im Nur-Lese‑Modus kann der Benutzer den Inhalt – Hyperlinks, Animationen, Effekte usw. – ansehen, aber keine Elemente kopieren oder die Präsentation speichern. 

- **Öffnen**

  Wenn Sie nur bestimmten Benutzern das Öffnen Ihrer Präsentation erlauben wollen, können Sie eine Öffnungsbeschränkung festlegen. Diese Beschränkung verhindert, dass Personen überhaupt den Inhalt Ihrer Präsentation sehen (es sei denn, sie geben das Passwort ein).

  Technisch verhindert die Öffnungsbeschränkung zugleich auch das Ändern der Präsentation: Wenn Personen eine Präsentation nicht öffnen können, können sie sie nicht ändern. 
  
  **Hinweis**: Wenn Sie eine Präsentation mit Passwort schützen, um das Öffnen zu verhindern, wird die Präsentationsdatei verschlüsselt.

## **Wie Sie eine Präsentation online mit Passwort schützen**

1. Rufen Sie unsere Seite [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock) auf. 

   ![todo:image_alt_text](slides-lock.png)

2. Klicken Sie **Drop or upload your files**.

3. Wählen Sie die Datei aus, die Sie auf Ihrem Computer mit einem Passwort schützen möchten. 

4. Geben Sie Ihr gewünschtes Passwort für den Bearbeitungsschutz ein; geben Sie Ihr gewünschtes Passwort für den Ansichtsschutz ein. 

5. Wenn Sie möchten, dass Benutzer Ihre Präsentation als Endkopie sehen, aktivieren Sie das Kontrollkästchen **Mark as final**.

6. Klicken Sie **PROTECT NOW.** 

7. Klicken Sie **DOWNLOAD NOW.**

## **Passwortschutz für Präsentationen in Aspose.Slides**
**Unterstützte Formate**

Aspose.Slides unterstützt Passwortschutz, Verschlüsselung und ähnliche Vorgänge für Präsentationen in den folgenden Formaten: 

- PPTX und PPT – Microsoft PowerPoint Presentation 
- ODP – OpenDocument Presentation 
- OTP – OpenDocument Presentation Template 

**Unterstützte Vorgänge**

Aspose.Slides ermöglicht es Ihnen, Passwortschutz für Präsentationen einzusetzen, um Änderungen auf folgende Weise zu verhindern:

- Verschlüsseln einer Präsentation
- Festlegen eines Schreibschutzes für eine Präsentation

**Weitere Vorgänge**

Aspose.Slides ermöglicht es Ihnen, weitere Aufgaben im Zusammenhang mit Passwortschutz und Verschlüsselung auf folgende Weise auszuführen:

- Entschlüsseln einer Präsentation; Öffnen einer verschlüsselten Präsentation
- Entfernen der Verschlüsselung; Deaktivieren des Passwortschutzes
- Entfernen des Schreibschutzes von einer Präsentation
- Abrufen der Eigenschaften einer verschlüsselten Präsentation
- Überprüfen, ob eine Präsentation verschlüsselt ist
- Überprüfen, ob eine Präsentation passwortgeschützt ist.

## **Verschlüsseln einer Präsentation**

Sie können eine Präsentation verschlüsseln, indem Sie ein Passwort festlegen. Um die gesperrte Präsentation zu ändern, muss ein Benutzer das Passwort angeben. 

Um eine Präsentation zu verschlüsseln oder mit einem Passwort zu schützen, verwenden Sie die **encrypt**‑Methode (aus [ProtectionManager](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/)) und geben das Passwort an die Methode weiter. Anschließend speichern Sie die nun verschlüsselte Präsentation mit der **save**‑Methode.

Dieses Beispiel zeigt, wie Sie eine Präsentation verschlüsseln:
```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->encrypt("123123");
    $presentation->save("encrypted-pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **Schreibschutz für eine Präsentation festlegen**

Sie können einer Präsentation einen Hinweis „Do not modify“ hinzufügen. Auf diese Weise teilen Sie den Benutzern mit, dass Sie nicht wünschen, dass Änderungen an der Präsentation vorgenommen werden.  

**Hinweis**: Der Schreibschutzvorgang verschlüsselt die Präsentation nicht. Daher können Benutzer – falls sie es tatsächlich wollen – die Präsentation ändern, aber zum Speichern der Änderungen müssen sie die Datei unter einem anderen Namen speichern. 

Um einen Schreibschutz festzulegen, verwenden Sie die Methode [setWriteProtection](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#setWriteProtection). Dieses Beispiel zeigt, wie Sie einen Schreibschutz für eine Präsentation festlegen:
```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->setWriteProtection("123123");
    $presentation->save("write-protected-pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **Laden einer verschlüsselten Präsentation**

Aspose.Slides ermöglicht es Ihnen, eine verschlüsselte Datei zu laden, indem Sie ihr Passwort übergeben. Um eine Präsentation zu entschlüsseln, rufen Sie die Methode [removeEncryption](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#removeEncryption) ohne Parameter auf. Anschließend geben Sie das korrekte Passwort ein, um die Präsentation zu laden.

Dieses Beispiel zeigt, wie Sie eine Präsentation entschlüsseln: 
```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("123123");
  $presentation = new Presentation("pres.pptx", $loadOptions);
  try {
    # mit entschlüsselter Präsentation arbeiten
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **Entfernen der Verschlüsselung aus einer Präsentation**

Sie können die Verschlüsselung oder den Passwortschutz einer Präsentation entfernen. Dadurch können Benutzer die Präsentation ohne Einschränkungen öffnen oder ändern. 

Um die Verschlüsselung oder den Passwortschutz zu entfernen, rufen Sie die Methode [removeEncryption](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#removeEncryption) auf. Dieses Beispiel zeigt, wie Sie die Verschlüsselung aus einer Präsentation entfernen:
```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("123123");
  $presentation = new Presentation("pres.pptx", $loadOptions);
  try {
    $presentation->getProtectionManager()->removeEncryption();
    $presentation->save("encryption-removed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **Entfernen des Schreibschutzes von einer Präsentation**

Sie können mit Aspose.Slides den Schreibschutz einer Präsentationsdatei entfernen. Damit können Benutzer nach Belieben ändern, ohne dass Warnungen angezeigt werden.

Den Schreibschutz entfernen Sie, indem Sie die Methode [removeWriteProtection](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#removeWriteProtection) verwenden. Dieses Beispiel zeigt, wie Sie den Schreibschutz von einer Präsentation entfernen:
```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->removeWriteProtection();
    $presentation->save("write-protection-removed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **Abrufen der Eigenschaften einer verschlüsselten Präsentation**

Typischerweise haben Benutzer Schwierigkeiten, die Dokumenteigenschaften einer verschlüsselten oder passwortgeschützten Präsentation zu erhalten. Aspose.Slides bietet jedoch einen Mechanismus, mit dem Sie eine Präsentation passwortschützen können, während Benutzer weiterhin Zugriff auf deren Eigenschaften haben.

**Hinweis**: Wenn Aspose.Slides eine Präsentation verschlüsselt, werden die Dokumenteigenschaften der Präsentation standardmäßig ebenfalls passwortgeschützt. Wenn Sie jedoch möchten, dass die Eigenschaften auch nach der Verschlüsselung zugänglich bleiben, ermöglicht Aspose.Slides genau das. 

Wenn Sie Benutzern ermöglichen wollen, die Eigenschaften einer von Ihnen verschlüsselten Präsentation zu sehen, verwenden Sie die Methode [encryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#getEncryptDocumentProperties) mit dem Wert `true`. Dieses Beispiel zeigt, wie Sie eine Präsentation verschlüsseln und gleichzeitig den Zugriff auf deren Dokumenteigenschaften ermöglichen:
```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->setEncryptDocumentProperties(true);
    $presentation->getProtectionManager()->encrypt("123123");
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **Überprüfen, ob eine Präsentation passwortgeschützt ist**

Bevor Sie eine Präsentation laden, möchten Sie möglicherweise prüfen, ob die Präsentation nicht mit einem Passwort geschützt ist. So vermeiden Sie Fehler und ähnliche Probleme, die auftreten, wenn eine passwortgeschützte Präsentation ohne Passwort geladen wird.

Dieser PHP‑Code zeigt, wie Sie eine Präsentation prüfen können, ob sie passwortgeschützt ist (ohne die Präsentation selbst zu laden):
```php
  $presentationInfo = PresentationFactory->getInstance()->getPresentationInfo("example.pptx");
  echo("The presentation is password protected: " . $presentationInfo->isPasswordProtected());

```


## **Überprüfen, ob eine Präsentation verschlüsselt ist**

Aspose.Slides ermöglicht es Ihnen, zu prüfen, ob eine Präsentation verschlüsselt ist. Verwenden Sie hierfür die Methode [isEncrypted](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#isEncrypted), die `true` zurückgibt, wenn die Präsentation verschlüsselt ist, bzw. `false`, wenn sie nicht verschlüsselt ist.

Dieses Beispiel zeigt, wie Sie prüfen, ob eine Präsentation verschlüsselt ist:
```php
  $presentation = new Presentation("pres.pptx");
  try {
    $isEncrypted = $presentation->getProtectionManager()->isEncrypted();
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **Überprüfen, ob eine Präsentation schreibgeschützt ist**

Aspose.Slides ermöglicht es Ihnen, zu prüfen, ob eine Präsentation schreibgeschützt ist. Verwenden Sie hierfür die Methode [isWriteProtected](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#isWriteProtected), die `true` zurückgibt, wenn die Präsentation schreibgeschützt ist, bzw. `false`, wenn sie nicht schreibgeschützt ist.

Dieses Beispiel zeigt, wie Sie prüfen, ob eine Präsentation schreibgeschützt ist:
```php
  $presentation = new Presentation("pres.pptx");
  try {
    $isEncrypted = $presentation->getProtectionManager()->isWriteProtected();
  finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **Validieren oder Bestätigen, dass ein bestimmtes Passwort verwendet wurde**

Sie möchten möglicherweise prüfen und bestätigen, dass ein bestimmtes Passwort zum Schutz eines Präsentationsdokuments verwendet wurde. Aspose.Slides bietet die Möglichkeit, ein Passwort zu validieren. 

Dieses Beispiel zeigt, wie Sie ein Passwort validieren:
```php
  $presentation = new Presentation("pres.pptx");
  try {
    # prüfen, ob "pass" übereinstimmt
    $isWriteProtected = $presentation->getProtectionManager()->checkWriteProtection("my_password");
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


Es gibt `true` zurück, wenn die Präsentation mit dem angegebenen Passwort verschlüsselt wurde. Andernfalls gibt es `false` zurück. 

{{% alert color="primary" title="Siehe auch" %}} 
- [Digital Signature in PowerPoint](/slides/de/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Welche Verschlüsselungsmethoden werden von Aspose.Slides unterstützt?**

Aspose.Slides unterstützt moderne Verschlüsselungsmethoden, einschließlich AES‑basierter Algorithmen, und sorgt so für ein hohes Maß an Datensicherheit Ihrer Präsentationen.

**Was passiert, wenn ein falsches Passwort beim Öffnen einer Präsentation eingegeben wird?**

Es wird eine Ausnahme ausgelöst, wenn ein falsches Passwort verwendet wird, wodurch Sie darüber informiert werden, dass der Zugriff auf die Präsentation verweigert wird. Dies verhindert unbefugten Zugriff und schützt den Inhalt der Präsentation.

**Gibt es Leistungseinbußen bei der Arbeit mit passwortgeschützten Präsentationen?**

Der Verschlüsselungs‑ und Entschlüsselungsprozess kann beim Öffnen und Speichern leichte Verzögerungen verursachen. In den meisten Fällen ist dieser Performance‑Einfluss minimal und beeinträchtigt die Gesamtdauer Ihrer Präsentationsverarbeitung kaum.