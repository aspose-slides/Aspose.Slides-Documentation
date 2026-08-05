---
title: "Sichere Präsentationen mit Passwörtern in PHP"
linktitle: "Passwortschutz"
type: docs
weight: 20
url: /de/php-java/password-protected-presentation/
keywords:
  - "PowerPoint sperren"
  - "Präsentation sperren"
  - "PowerPoint entsperren"
  - "Präsentation entsperren"
  - "PowerPoint schützen"
  - "Präsentation schützen"
  - "Passwort festlegen"
  - "Passwort hinzufügen"
  - "PowerPoint verschlüsseln"
  - "Präsentation verschlüsseln"
  - "PowerPoint entschlüsseln"
  - "Präsentation entschlüsseln"
  - "Schreibschutz"
  - "PowerPoint‑Sicherheit"
  - "Präsentations‑Sicherheit"
  - "Passwort entfernen"
  - "Schutz entfernen"
  - "Verschlüsselung entfernen"
  - "Passwort deaktivieren"
  - "Schutz deaktivieren"
  - "Schreibschutz entfernen"
  - "PowerPoint"
  - "OpenDocument"
  - "Präsentation"
  - "PHP"
  - "Aspose.Slides"
description: "Erfahren Sie, wie Sie PowerPoint‑ und OpenDocument‑Präsentationen mühelos mit Aspose.Slides für PHP sperren und entsperren können. Schützen Sie Ihre Präsentationen."
---
## **Einleitung**

Wenn Sie eine Präsentation mit einem Passwort schützen, legen Sie ein Passwort fest, das bestimmte Einschränkungen für die Präsentation durchsetzt. Um die Einschränkungen zu entfernen, muss das Passwort eingegeben werden. Eine passwortgeschützte Präsentation gilt als gesperrte Präsentation.

Typischerweise können Sie ein Passwort festlegen, um diese Einschränkungen für eine Präsentation durchzusetzen:

- **Bearbeitung**

  Wenn Sie möchten, dass nur bestimmte Benutzer Ihre Präsentation bearbeiten können, können Sie eine Bearbeitungseinschränkung festlegen. Diese Einschränkung verhindert, dass Personen Ihre Präsentation ändern, modifizieren oder Inhalte kopieren (es sei denn, sie geben das Passwort ein).

  In diesem Fall kann ein Benutzer jedoch ohne Passwort Ihr Dokument öffnen und darauf zugreifen. Im Nur‑Lese‑Modus kann der Benutzer den Inhalt – Hyperlinks, Animationen, Effekte und andere Elemente – Ihrer Präsentation ansehen, aber keine Elemente kopieren oder die Präsentation speichern.

- **Öffnen**

  Wenn Sie möchten, dass nur bestimmte Benutzer Ihre Präsentation öffnen können, können Sie eine Öffnungseinschränkung festlegen. Diese Einschränkung verhindert, dass Personen den Inhalt Ihrer Präsentation sehen (es sei denn, sie geben das Passwort ein).

  Technisch verhindert die Öffnungseinschränkung auch, dass Benutzer Ihre Präsentation ändern: Wenn Personen eine Präsentation nicht öffnen können, können sie sie nicht modifizieren oder Änderungen daran vornehmen.  

  **Hinweis**: Wenn Sie eine Präsentation mit einem Passwort schützen, um das Öffnen zu verhindern, wird die Präsentationsdatei verschlüsselt.

## **Wie man eine Präsentation online mit einem Passwort schützt**

1. Gehen Sie zu unserer [**Aspose.Slides Sperren**](https://products.aspose.app/slides/de/lock)‑Seite. 

   ![todo:image_alt_text](slides-lock.png)

2. Klicken Sie auf **Dateien ziehen oder hochladen**.

3. Wählen Sie die Datei aus, die Sie auf Ihrem Computer mit einem Passwort schützen möchten. 

4. Geben Sie Ihr bevorzugtes Passwort für den Bearbeitungsschutz ein; geben Sie Ihr bevorzugtes Passwort für den Ansichtsschutz ein. 

5. Wenn Sie möchten, dass die Benutzer Ihre Präsentation als endgültige Kopie sehen, aktivieren Sie das Kontrollkästchen **Mark as final**.

6. Klicken Sie auf **JETZT SCHÜTZEN.** 

7. Klicken Sie auf **JETZT HERUNTERLADEN.**

## **Passwortschutz für Präsentationen in Aspose.Slides**
**Unterstützte Formate**

Aspose.Slides unterstützt Passwortschutz, Verschlüsselung und ähnliche Vorgänge für Präsentationen in diesen Formaten: 

- PPTX und PPT – Microsoft PowerPoint‑Präsentation 
- ODP – OpenDocument‑Präsentation 
- OTP – OpenDocument‑Präsentationsvorlage 

**Unterstützte Vorgänge**

Aspose.Slides ermöglicht die Verwendung von Passwortschutz für Präsentationen, um Änderungen wie folgt zu verhindern:

- Verschlüsseln einer Präsentation
- Festlegen eines Schreibschutzes für eine Präsentation

**Weitere Vorgänge**

Aspose.Slides ermöglicht weitere Aufgaben im Zusammenhang mit Passwortschutz und Verschlüsselung auf folgende Weise:

- Entschlüsseln einer Präsentation; Öffnen einer verschlüsselten Präsentation
- Entfernen der Verschlüsselung; Deaktivieren des Passwortschutzes
- Entfernen des Schreibschutzes von einer Präsentation
- Abrufen der Eigenschaften einer verschlüsselten Präsentation
- Prüfen, ob eine Präsentation verschlüsselt ist
- Prüfen, ob eine Präsentation passwortgeschützt ist.

## **Eine Präsentation verschlüsseln**

Sie können eine Präsentation verschlüsseln, indem Sie ein Passwort festlegen. Dann muss ein Benutzer das Passwort angeben, um die gesperrte Präsentation zu ändern. 

Um eine Präsentation zu verschlüsseln oder passwortzuschützen, müssen Sie die `encrypt`‑Methode (aus [ProtectionManager](https://reference.aspose.com/slides/de/php-java/aspose.slides/protectionmanager/)) verwenden, um ein Passwort für die Präsentation zu setzen. Sie übergeben das Passwort an die `encrypt`‑Methode und verwenden die `save`‑Methode, um die nun verschlüsselte Präsentation zu speichern.

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

Sie können einer Präsentation einen Hinweis „Nicht bearbeiten“ hinzufügen. Auf diese Weise teilen Sie den Benutzern mit, dass Sie nicht wünschen, dass Änderungen an der Präsentation vorgenommen werden.  

**Hinweis**: Der Schreibschutzvorgang verschlüsselt die Präsentation nicht. Daher können Benutzer – falls sie es wollen – die Präsentation ändern, aber um die Änderungen zu speichern, müssen sie die Präsentation unter einem anderen Namen speichern. 

Um einen Schreibschutz zu setzen, verwenden Sie die [setWriteProtection](https://reference.aspose.com/slides/de/php-java/aspose.slides/protectionmanager/#setWriteProtection)‑Methode. Dieser Beispielcode zeigt, wie Sie einen Schreibschutz für eine Präsentation festlegen:

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

Aspose.Slides ermöglicht das Laden einer verschlüsselten Datei, indem ihr Passwort übergeben wird. Um eine Präsentation zu entschlüsseln, rufen Sie die [removeEncryption](https://reference.aspose.com/slides/de/php-java/aspose.slides/protectionmanager/#removeEncryption)‑Methode ohne Parameter auf. Anschließend müssen Sie das korrekte Passwort eingeben, um die Präsentation zu laden.

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

Sie können die Verschlüsselung oder den Passwortschutz einer Präsentation entfernen. Auf diese Weise können Benutzer die Präsentation ohne Einschränkungen zugreifen oder ändern. 

Um die Verschlüsselung oder den Passwortschutz zu entfernen, rufen Sie die [removeEncryption](https://reference.aspose.com/slides/de/php-java/aspose.slides/protectionmanager/#removeEncryption)‑Methode auf. Dieser Beispielcode zeigt, wie Sie die Verschlüsselung einer Präsentation entfernen:

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

## **Schreibschutz von einer Präsentation entfernen**

Sie können mit Aspose.Slides den Schreibschutz einer Präsentationsdatei entfernen. Auf diese Weise können Benutzer frei bearbeiten und erhalten keine Warnungen, wenn sie solche Aktionen ausführen.

Sie können den Schreibschutz von einer Präsentation entfernen, indem Sie die [removeWriteProtection](https://reference.aspose.com/slides/de/php-java/aspose.slides/protectionmanager/#removeWriteProtection)‑Methode verwenden. Dieser Beispielcode zeigt, wie Sie den Schreibschutz von einer Präsentation entfernen:

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

Typischerweise haben Benutzer Schwierigkeiten, die Dokumenteigenschaften einer verschlüsselten oder passwortgeschützten Präsentation abzurufen. Aspose.Slides bietet jedoch einen Mechanismus, der es ermöglicht, eine Präsentation zu schützen und gleichzeitig Benutzern den Zugriff auf ihre Eigenschaften zu gestatten.

**Hinweis:** Standardmäßig werden beim Verschlüsseln einer Präsentation durch Aspose.Slides auch die Dokumenteigenschaften passwortgeschützt. Wenn Sie möchten, dass die Dokumenteigenschaften auch nach der Verschlüsselung zugänglich bleiben, erlaubt Aspose.Slides genau das.

Wenn Sie Benutzern erlauben möchten, die Eigenschaften einer verschlüsselten Präsentation weiterhin zu sehen, übergeben Sie `false` an [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/de/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties). Dieser Beispielcode zeigt, wie Sie eine Präsentation verschlüsseln und gleichzeitig den Benutzern Zugriff auf die Dokumenteigenschaften gewähren:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->setEncryptDocumentProperties(false);
    $presentation->getProtectionManager()->encrypt("123123");
    $presentation->save("encrypted-pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Nur Dokumenteigenschaften einer verschlüsselten Präsentation laden**

Um die Metadaten einer verschlüsselten Präsentation zu prüfen, ohne deren Folien oder andere Inhalte zu laden, erstellen Sie ein [LoadOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/loadoptions/)‑Objekt und übergeben `true` an [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/de/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties). In diesem Modus ignoriert Aspose.Slides das Passwort und lädt nur die öffentlich zugänglichen Dokumenteigenschaften.

Der folgende Code liest integrierte und benutzerdefinierte Dokumenteigenschaften über [Presentation::getDocumentProperties](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#getDocumentProperties):

```php
$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $documentProperties = $presentation->getDocumentProperties();

    # Eingebaute Dokumenteigenschaften lesen.
    echo("Title: " . $documentProperties->getTitle() . "\n");
    echo("Author: " . $documentProperties->getAuthor() . "\n");

    # Benutzerdefinierte Dokumenteigenschaften lesen.
    $customPropertyCount = java_values($documentProperties->getCountOfCustomProperties());

    for ($propertyIndex = 0; $propertyIndex < $customPropertyCount; $propertyIndex++) {
        $propertyName = $documentProperties->getCustomPropertyName($propertyIndex);
        $propertyValue = java_values($documentProperties->get_Item($propertyName));

        echo($propertyName . ": " . $propertyValue . "\n");
    }
} finally {
    $presentation->dispose();
}
```

Dieser Arbeitsablauf funktioniert nur, wenn die Dokumenteigenschaften beim Verschlüsseln der Präsentation unverschlüsselt (öffentlich) gelassen wurden. Sind die Dokumenteigenschaften verschlüsselt, führt das Übergeben von `true` an [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/de/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) zu einer Ausnahme, weil das Passwort in diesem Modus ignoriert wird. Um verschlüsselte Dokumenteigenschaften zuzugreifen oder die komplette Präsentation einschließlich Folien und anderer Inhalte zu laden, geben Sie das korrekte Passwort über [LoadOptions::setPassword](https://reference.aspose.com/slides/de/php-java/aspose.slides/loadoptions/#setPassword) an.

## **Prüfen, ob eine Präsentation passwortgeschützt ist**

Bevor Sie eine Präsentation laden, möchten Sie möglicherweise prüfen, ob die Präsentation nicht durch ein Passwort geschützt ist. So vermeiden Sie Fehler und ähnliche Probleme, die auftreten, wenn eine passwortgeschützte Präsentation ohne Passwort geladen wird.

Dieser PHP‑Code zeigt, wie Sie eine Präsentation prüfen, ob sie passwortgeschützt ist (ohne die Präsentation selbst zu laden):

```php
  $presentationInfo = PresentationFactory->getInstance()->getPresentationInfo("example.pptx");
  echo("The presentation is password protected: " . $presentationInfo->isPasswordProtected());

```

## **Prüfen, ob eine Präsentation verschlüsselt ist**

Aspose.Slides ermöglicht es, zu prüfen, ob eine Präsentation verschlüsselt ist. Dafür können Sie die [isEncrypted](https://reference.aspose.com/slides/de/php-java/aspose.slides/protectionmanager/#isEncrypted)‑Methode verwenden, die `true` zurückgibt, wenn die Präsentation verschlüsselt ist, oder `false`, wenn sie nicht verschlüsselt ist.

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

## **Prüfen, ob eine Präsentation schreibgeschützt ist**

Aspose.Slides ermöglicht es, zu prüfen, ob eine Präsentation schreibgeschützt ist. Dafür können Sie die [isWriteProtected](https://reference.aspose.com/slides/de/php-java/aspose.slides/protectionmanager/#isWriteProtected)‑Methode verwenden, die `true` zurückgibt, wenn die Präsentation schreibgeschützt ist, oder `false`, wenn sie nicht schreibgeschützt ist.

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

## **Validieren oder bestätigen, dass ein bestimmtes Passwort verwendet wurde**

Möglicherweise möchten Sie prüfen und bestätigen, dass ein bestimmtes Passwort zum Schutz eines Präsentationsdokuments verwendet wurde. Aspose.Slides bietet die Möglichkeit, ein Passwort zu validieren. 

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

Aspose.Slides unterstützt moderne Verschlüsselungsmethoden, einschließlich AES‑basierter Algorithmen, und sorgt so für ein hohes Maß an Datensicherheit Ihrer Präsentationen.

**Was passiert, wenn ein falsches Passwort eingegeben wird, während versucht wird, eine Präsentation zu öffnen?**

Eine Ausnahme wird ausgelöst, wenn ein falsches Passwort verwendet wird, und weist darauf hin, dass der Zugriff auf die Präsentation verweigert wird. Dies hilft, unbefugten Zugriff zu verhindern und schützt den Inhalt der Präsentation.

**Gibt es Performance‑Auswirkungen bei der Arbeit mit passwortgeschützten Präsentationen?**

Der Verschlüsselungs‑ und Entschlüsselungsprozess kann beim Öffnen und Speichern eine leichte Verzögerung verursachen. In den meisten Fällen ist diese Auswirkung gering und beeinträchtigt die Gesamtverarbeitungszeit Ihrer Präsentationsaufgaben kaum.