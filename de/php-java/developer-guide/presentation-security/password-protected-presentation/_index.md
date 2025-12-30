---
title: Sicher Präsentationen mit Passwörtern in PHP
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
description: "Erfahren Sie, wie Sie PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für PHP mühelos sperren und entsperren können. Sichern Sie Ihre Präsentationen."
---

## **Über den Passwortschutz**
### **Wie funktioniert der Passwortschutz für eine Präsentation?**
Wenn Sie eine Präsentation mit einem Passwort schützen, legen Sie ein Passwort fest, das bestimmte Einschränkungen für die Präsentation durchsetzt. Um die Einschränkungen zu entfernen, muss das Passwort eingegeben werden. Eine passwortgeschützte Präsentation gilt als gesperrte Präsentation.

Typischerweise können Sie ein Passwort festlegen, um diese Einschränkungen für eine Präsentation durchzusetzen:

- **Änderung**

  Wenn Sie nur bestimmten Benutzern das Ändern Ihrer Präsentation erlauben möchten, können Sie eine Änderungsbeschränkung festlegen. Diese Beschränkung verhindert, dass Personen die Präsentation ändern, anpassen oder Inhalte kopieren (sofern sie nicht das Passwort angeben).

  Ohne das Passwort kann ein Benutzer jedoch weiterhin auf das Dokument zugreifen und es öffnen. Im Nur-Lese‑Modus kann der Benutzer den Inhalt – Hyperlinks, Animationen, Effekte und weitere Elemente – ansehen, aber keine Elemente kopieren oder die Präsentation speichern.

- **Öffnen**

  Wenn Sie nur bestimmten Benutzern das Öffnen Ihrer Präsentation erlauben möchten, können Sie eine Öffnungsbeschränkung festlegen. Diese Beschränkung verhindert, dass Personen überhaupt den Inhalt Ihrer Präsentation sehen (sofern sie nicht das Passwort angeben).

  Technisch verhindert die Öffnungsbeschränkung auch das Ändern der Präsentation: Wenn Personen eine Präsentation nicht öffnen können, können sie sie auch nicht ändern.

  **Hinweis**: Wenn Sie eine Präsentation mit Passwortschutz versehen, um das Öffnen zu verhindern, wird die Präsentationsdatei verschlüsselt.

## **Wie Sie eine Präsentation online passwortschützen**
1. Öffnen Sie unsere [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock)‑Seite.  

   ![todo:image_alt_text](slides-lock.png)

2. Klicken Sie **Dateien per Drag‑&‑Drop hochladen**.

3. Wählen Sie die Datei aus, die Sie auf Ihrem Computer mit einem Passwort schützen möchten.

4. Geben Sie Ihr gewünschtes Passwort für den Bearbeitungsschutz ein; geben Sie Ihr gewünschtes Passwort für den Ansichtsschutz ein.

5. Wenn Sie möchten, dass Benutzer Ihre Präsentation als Endversion sehen, aktivieren Sie das Kontrollkästchen **Als endgültig markieren**.

6. Klicken Sie **JETZT SCHÜTZEN**.

7. Klicken Sie **JETZT HERUNTERLADEN**.

## **Passwortschutz für Präsentationen in Aspose.Slides**
**Unterstützte Formate**

Aspose.Slides unterstützt Passwortschutz, Verschlüsselung und ähnliche Vorgänge für Präsentationen in folgenden Formaten:

- PPTX und PPT – Microsoft PowerPoint‑Präsentation
- ODP – OpenDocument‑Präsentation
- OTP – OpenDocument‑Präsentationsvorlage

**Unterstützte Vorgänge**

Aspose.Slides ermöglicht es Ihnen, Passwortschutz für Präsentationen auf folgende Weise anzuwenden, um Änderungen zu verhindern:

- Verschlüsseln einer Präsentation
- Festlegen eines Schreibschutzes für eine Präsentation

**Weitere Vorgänge**

Aspose.Slides erlaubt Ihnen, weitere Aufgaben im Zusammenhang mit Passwortschutz und Verschlüsselung wie folgt durchzuführen:

- Entschlüsseln einer Präsentation; Öffnen einer verschlüsselten Präsentation
- Entfernen der Verschlüsselung; Deaktivieren des Passwortschutzes
- Entfernen des Schreibschutzes von einer Präsentation
- Abrufen der Eigenschaften einer verschlüsselten Präsentation
- Überprüfen, ob eine Präsentation verschlüsselt ist
- Überprüfen, ob eine Präsentation passwortgeschützt ist.

## **Eine Präsentation verschlüsseln**
Sie können eine Präsentation verschlüsseln, indem Sie ein Passwort festlegen. Um die gesperrte Präsentation zu ändern, muss ein Benutzer das Passwort angeben.

Um eine Präsentation zu verschlüsseln oder mit einem Passwort zu schützen, verwenden Sie die `encrypt`‑Methode (aus [IProtectionManager](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager)) und übergeben das Passwort an diese Methode. Anschließend speichern Sie die nun verschlüsselte Präsentation mit der `save`‑Methode.

Dieser Beispielcode zeigt, wie Sie eine Präsentation verschlüsseln:
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
Sie können einer Präsentation einen Hinweis „Nicht ändern“ hinzufügen. Auf diese Weise können Sie Benutzern mitteilen, dass Sie nicht wünschen, dass Änderungen an der Präsentation vorgenommen werden.

**Hinweis**: Der Schreibschutzvorgang verschlüsselt die Präsentation nicht. Daher können Benutzer – falls sie es wünschen – die Präsentation ändern, aber zum Speichern der Änderungen müssen sie die Datei unter einem anderen Namen speichern.

Um einen Schreibschutz festzulegen, verwenden Sie die Methode [setWriteProtection](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-). Dieser Beispielcode zeigt, wie Sie einen Schreibschutz für eine Präsentation festlegen:
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


## **Eine verschlüsselte Präsentation laden**
Aspose.Slides ermöglicht es Ihnen, eine verschlüsselte Datei zu laden, indem Sie das zugehörige Passwort übergeben. Um eine Präsentation zu entschlüsseln, rufen Sie die Methode [removeEncryption](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#removeEncryption--) ohne Parameter auf. Anschließend geben Sie das korrekte Passwort ein, um die Präsentation zu laden.

Dieser Beispielcode zeigt, wie Sie eine Präsentation entschlüsseln:
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


## **Verschlüsselung einer Präsentation entfernen**
Sie können die Verschlüsselung oder den Passwortschutz einer Präsentation entfernen. Damit können Benutzer die Präsentation ohne Einschränkungen öffnen oder bearbeiten.

Um die Verschlüsselung oder den Passwortschutz zu entfernen, rufen Sie die Methode [removeEncryption](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#removeEncryption--) auf. Dieser Beispielcode zeigt, wie Sie die Verschlüsselung einer Präsentation entfernen:
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


## **Schreibschutz einer Präsentation entfernen**
Sie können mit Aspose.Slides den Schreibschutz einer Präsentationsdatei entfernen. Damit können Benutzer die Datei nach Belieben ändern, ohne Warnungen zu erhalten.

Entfernen Sie den Schreibschutz einer Präsentation mit der Methode [removeWriteProtection](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#removeWriteProtection--). Dieser Beispielcode zeigt, wie Sie den Schreibschutz einer Präsentation entfernen:
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


## **Eigenschaften einer verschlüsselten Präsentation abrufen**
Benutzer haben häufig Schwierigkeiten, die Dokumenteigenschaften einer verschlüsselten oder passwortgeschützten Präsentation zu erhalten. Aspose.Slides bietet jedoch einen Mechanismus, mit dem Sie eine Präsentation mit Passwort schützen können, während die Benutzer weiterhin Zugriff auf deren Eigenschaften haben.

**Hinweis**: Wenn Aspose.Slides eine Präsentation verschlüsselt, werden die Dokumenteigenschaften der Präsentation standardmäßig ebenfalls passwortgeschützt. Wenn Sie jedoch möchten, dass die Eigenschaften auch nach der Verschlüsselung zugänglich bleiben, ermöglicht Ihnen Aspose.Slides dies.

Setzen Sie die Eigenschaft [encryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#getEncryptDocumentProperties--) auf `true`, um dies zu erreichen. Dieser Beispielcode zeigt, wie Sie eine Präsentation verschlüsseln und gleichzeitig den Zugriff auf die Dokumenteigenschaften ermöglichen:
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
Bevor Sie eine Präsentation laden, möchten Sie möglicherweise prüfen, ob sie mit einem Passwort geschützt ist. So vermeiden Sie Fehler, die beim Laden einer passwortgeschützten Präsentation ohne das richtige Passwort auftreten können.

Dieser PHP‑Code zeigt, wie Sie eine Präsentation prüfen können, ob sie passwortgeschützt ist (ohne die Präsentation selbst zu laden):
```php
  $presentationInfo = PresentationFactory->getInstance()->getPresentationInfo("example.pptx");
  echo("The presentation is password protected: " . $presentationInfo->isPasswordProtected());

```


## **Überprüfen, ob eine Präsentation verschlüsselt ist**
Aspose.Slides ermöglicht es Ihnen, zu prüfen, ob eine Präsentation verschlüsselt ist. Verwenden Sie dafür die Eigenschaft [isEncrypted](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#isEncrypted--), die `true` zurückgibt, wenn die Präsentation verschlüsselt ist, und `false`, wenn sie nicht verschlüsselt ist.

Dieser Beispielcode zeigt, wie Sie prüfen, ob eine Präsentation verschlüsselt ist:
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
Aspose.Slides ermöglicht es Ihnen, zu prüfen, ob eine Präsentation schreibgeschützt ist. Verwenden Sie dafür die Eigenschaft [isWriteProtected](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#isWriteProtected--), die `true` zurückgibt, wenn die Präsentation schreibgeschützt ist, und `false`, wenn sie nicht schreibgeschützt ist.

Dieser Beispielcode zeigt, wie Sie prüfen, ob eine Präsentation schreibgeschützt ist:
```php
  $presentation = new Presentation("pres.pptx");
  try {
    $isEncrypted = $presentation->getProtectionManager()->isWriteProtected();
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **Validieren, ob ein bestimmtes Passwort verwendet wurde**
Möglicherweise möchten Sie prüfen und bestätigen, dass ein bestimmtes Passwort zum Schutz eines Präsentationsdokuments verwendet wurde. Aspose.Slides stellt Ihnen die Mittel zur Verfügung, ein Passwort zu validieren.

Dieser Beispielcode zeigt, wie Sie ein Passwort validieren:
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


Er gibt `true` zurück, wenn die Präsentation mit dem angegebenen Passwort verschlüsselt wurde. Andernfalls gibt er `false` zurück.

{{% alert color="primary" title="Siehe auch" %}} 
- [Digitale Signatur in PowerPoint](/slides/de/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Welche Verschlüsselungsmethoden unterstützt Aspose.Slides?**

Aspose.Slides unterstützt moderne Verschlüsselungsmethoden, einschließlich AES‑basierter Algorithmen, und stellt damit ein hohes Maß an Datensicherheit für Ihre Präsentationen sicher.

**Was passiert, wenn ein falsches Passwort beim Öffnen einer Präsentation eingegeben wird?**

Es wird eine Ausnahme ausgelöst, die anzeigt, dass der Zugriff auf die Präsentation verweigert wurde. Dies verhindert unbefugten Zugriff und schützt den Inhalt der Präsentation.

**Gibt es Leistungseinbußen bei der Arbeit mit passwortgeschützten Präsentationen?**

Der Vorgang des Verschlüsselns und Entschlüsselns kann beim Öffnen und Speichern einen geringen Mehraufwand verursachen. In den meisten Fällen ist dieser Einfluss minimal und wirkt sich nicht wesentlich auf die Gesamtverarbeitungszeit Ihrer Präsentationsaufgaben aus.