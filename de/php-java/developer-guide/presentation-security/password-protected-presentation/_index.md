---
title: Passwortgeschützte Präsentation
type: docs
weight: 20
url: /de/php-java/password-protected-presentation/
keywords: "PowerPoint-Präsentation sperren"
description: "PowerPoint-Präsentation sperren. Passwortgeschützte PowerPoint"
---

## **Über Passwortschutz**
### **Wie funktioniert der Passwortschutz für Präsentationen?**
Wenn Sie eine Präsentation passwortschützen, bedeutet dies, dass Sie ein Passwort festlegen, das bestimmte Einschränkungen für die Präsentation durchsetzt. Um die Einschränkungen zu entfernen, muss das Passwort eingegeben werden. Eine passwortgeschützte Präsentation wird als gesperrte Präsentation betrachtet.

Typischerweise können Sie ein Passwort festlegen, um diese Einschränkungen für eine Präsentation durchzusetzen:

- **Änderung**

  Wenn Sie nur bestimmten Benutzern erlauben möchten, Ihre Präsentation zu bearbeiten, können Sie eine Änderungsbeschränkung festlegen. Die Einschränkung verhindert hier, dass Personen die Dinge in Ihrer Präsentation bearbeiten, ändern oder kopieren (es sei denn, sie geben das Passwort an).

  In diesem Fall kann ein Benutzer jedoch auch ohne das Passwort auf Ihr Dokument zugreifen und es öffnen. Im schreibgeschützten Modus kann der Benutzer den Inhalt oder die Dinge—Hyperlinks, Animationen, Effekte usw.—in Ihrer Präsentation ansehen, kann jedoch keine Elemente kopieren oder die Präsentation speichern.

- **Öffnen**

  Wenn Sie nur bestimmten Benutzern das Öffnen Ihrer Präsentation erlauben möchten, können Sie eine Öffnungsbeschränkung festlegen. Die Einschränkung verhindert hier, dass Personen sogar die Inhalte Ihrer Präsentation einsehen (es sei denn, sie geben das Passwort an).

  Technisch gesehen verhindert die Öffnungsbeschränkung auch, dass Benutzer Ihre Präsentationen ändern: Wenn Personen eine Präsentation nicht öffnen können, können sie sie nicht ändern oder darauf zugreifen.

  **Hinweis**, wenn Sie eine Präsentation passwortschützen, um das Öffnen zu verhindern, wird die Präsentationsdatei verschlüsselt.

## **So schützen Sie eine Präsentation online mit einem Passwort**

1. Gehen Sie zu unserer [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock) Seite.

   ![todo:image_alt_text](slides-lock.png)

2. Klicken Sie auf **Dateien ablegen oder hochladen**.

3. Wählen Sie die Datei aus, die Sie auf Ihrem Computer passwortschützen möchten.

4. Geben Sie Ihr bevorzugtes Passwort für den Bearbeitungsschutz ein; Geben Sie Ihr bevorzugtes Passwort für den Ansichtsschutz ein.

5. Wenn Sie möchten, dass Benutzer Ihre Präsentation als endgültige Kopie sehen, aktivieren Sie das Kästchen **Als endgültig kennzeichnen**.

6. Klicken Sie auf **JETZT SCHÜTZEN.**

7. Klicken Sie auf **JETZT HERUNTERLADEN.**

## **Passwortschutz für Präsentationen in Aspose.Slides**
**Unterstützte Formate**

Aspose.Slides unterstützt Passwortschutz, Verschlüsselung und ähnliche Vorgänge für Präsentationen in diesen Formaten:

- PPTX und PPT - Microsoft PowerPoint-Präsentation
- ODP - OpenDocument-Präsentation
- OTP - OpenDocument-Präsentationsvorlage

**Unterstützte Vorgänge**

Aspose.Slides ermöglicht es Ihnen, Passwortschutz für Präsentationen zu verwenden, um Änderungen auf diese Weise zu verhindern:

- Verschlüsselung einer Präsentation
- Festlegen eines Schreibschutzes für eine Präsentation

**Weitere Vorgänge**

Aspose.Slides ermöglicht es Ihnen, andere Aufgaben im Zusammenhang mit Passwortschutz und Verschlüsselung auf diese Weise durchzuführen:

- Entschlüsseln einer Präsentation; Öffnen einer verschlüsselten Präsentation
- Entfernen der Verschlüsselung; Deaktivieren des Passwortschutzes
- Entfernen des Schreibschutzes von einer Präsentation
- Abrufen der Eigenschaften einer verschlüsselten Präsentation
- Überprüfen, ob eine Präsentation verschlüsselt ist
- Überprüfen, ob eine Präsentation passwortgeschützt ist.

## **Verschlüsseln einer Präsentation**

Sie können eine Präsentation verschlüsseln, indem Sie ein Passwort festlegen. Um die gesperrte Präsentation zu ändern, muss ein Benutzer das Passwort angeben.

Um eine Präsentation zu verschlüsseln oder passwortgeschützt zu machen, müssen Sie die Methode encrypt (aus [IProtectionManager](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager)) verwenden, um ein Passwort für die Präsentation festzulegen. Sie übergeben das Passwort an die Methode encrypt und verwenden die Methode save, um die nun verschlüsselte Präsentation zu speichern.

Dieser Beispielcode zeigt Ihnen, wie Sie eine Präsentation verschlüsseln:

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

## **Festlegen des Schreibschutzes für eine Präsentation**

Sie können einer Präsentation ein Zeichen hinzufügen, das „Nicht ändern“ besagt. Auf diese Weise teilen Sie den Benutzern mit, dass Sie nicht möchten, dass sie Änderungen an der Präsentation vornehmen.

**Hinweis**, dass der Schreibschutzprozess die Präsentation nicht verschlüsselt. Daher können Benutzer—wenn sie wirklich wollen—die Präsentation bearbeiten, aber um die Änderungen zu speichern, müssen sie eine Präsentation mit einem anderen Namen erstellen.

Um einen Schreibschutz festzulegen, müssen Sie die [setWriteProtection](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) Methode verwenden. Dieser Beispielcode zeigt Ihnen, wie Sie einen Schreibschutz in einer Präsentation festlegen:

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

## **Entschlüsseln einer Präsentation; Öffnen einer verschlüsselten Präsentation**

Aspose.Slides ermöglicht es Ihnen, eine verschlüsselte Datei zu laden, indem Sie ihr Passwort übergeben. Um eine Präsentation zu entschlüsseln, müssen Sie die [removeEncryption](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#removeEncryption--) Methode ohne Parameter aufrufen. Sie müssen dann das richtige Passwort eingeben, um die Präsentation zu laden.

Dieser Beispielcode zeigt Ihnen, wie Sie eine Präsentation entschlüsseln:

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

## **Entfernen der Verschlüsselung; Deaktivieren des Passwortschutzes**

Sie können die Verschlüsselung oder den Passwortschutz für eine Präsentation entfernen. Auf diese Weise können Benutzer auf die Präsentation zugreifen oder sie ändern, ohne Einschränkungen.

Um die Verschlüsselung oder den Passwortschutz zu entfernen, müssen Sie die [removeEncryption](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#removeEncryption--) Methode aufrufen. Dieser Beispielcode zeigt Ihnen, wie Sie die Verschlüsselung von einer Präsentation entfernen:

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

Sie können Aspose.Slides verwenden, um den Schreibschutz zu entfernen, der für eine Präsentationsdatei verwendet wurde. Auf diese Weise können Benutzer nach Belieben Änderungen vornehmen, ohne Warnungen zu erhalten, wenn sie solche Aufgaben ausführen.

Sie können den Schreibschutz von einer Präsentation entfernen, indem Sie die [removeWriteProtection](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#removeWriteProtection--) Methode verwenden. Dieser Beispielcode zeigt Ihnen, wie Sie den Schreibschutz von einer Präsentation entfernen:

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

Typischerweise haben Benutzer Schwierigkeiten, die Dokumenteigenschaften einer verschlüsselten oder passwortgeschützten Präsentation zu erhalten. Aspose.Slides bietet jedoch einen Mechanismus, der es Ihnen ermöglicht, eine Präsentation passwortgeschützt zu machen und gleichzeitig den Benutzern den Zugriff auf die Eigenschaften dieser Präsentation zu ermöglichen.

**Hinweis**, dass die Dokumenteigenschaften einer Präsentation standardmäßig auch passwortgeschützt werden, wenn Aspose.Slides eine Präsentation verschlüsselt. Aber wenn Sie die Eigenschaften der Präsentation zugänglich machen möchten (auch nachdem die Präsentation verschlüsselt wurde), erlaubt es Aspose.Slides Ihnen, genau das zu tun.

Wenn Sie möchten, dass Benutzer die Möglichkeit behalten, auf die Eigenschaften einer von Ihnen verschlüsselten Präsentation zuzugreifen, können Sie die [encryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#getEncryptDocumentProperties--) Eigenschaft auf `true` setzen. Dieser Beispielcode zeigt Ihnen, wie Sie eine Präsentation verschlüsseln, während Sie den Benutzern die Möglichkeit bieten, auf deren Dokumenteigenschaften zuzugreifen:

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

## **Überprüfen, ob eine Präsentation vor dem Laden passwortgeschützt ist**

Bevor Sie eine Präsentation laden, möchten Sie möglicherweise überprüfen und bestätigen, dass die Präsentation nicht mit einem Passwort geschützt wurde. Auf diese Weise können Sie Fehler und ähnliche Probleme vermeiden, die auftreten, wenn eine passwortgeschützte Präsentation ohne deren Passwort geladen wird.

Dieser PHP-Code zeigt Ihnen, wie Sie eine Präsentation überprüfen, um zu sehen, ob sie passwortgeschützt ist (ohne die Präsentation selbst zu laden):

```php
  $presentationInfo = PresentationFactory->getInstance()->getPresentationInfo("example.pptx");
  echo("Die Präsentation ist passwortgeschützt: " . $presentationInfo->isPasswordProtected());
```

## **Überprüfen, ob eine Präsentation verschlüsselt ist**

Aspose.Slides ermöglicht es Ihnen, zu überprüfen, ob eine Präsentation verschlüsselt ist. Um diese Aufgabe auszuführen, können Sie die [isEncrypted](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#isEncrypted--) Eigenschaft verwenden, die `true` zurückgibt, wenn die Präsentation verschlüsselt ist, oder `false`, wenn die Präsentation nicht verschlüsselt ist.

Dieser Beispielcode zeigt Ihnen, wie Sie überprüfen, ob eine Präsentation verschlüsselt ist:

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

Aspose.Slides ermöglicht es Ihnen, zu überprüfen, ob eine Präsentation schreibgeschützt ist. Um diese Aufgabe auszuführen, können Sie die [isWriteProtected](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#isWriteProtected--) Eigenschaft verwenden, die `true` zurückgibt, wenn die Präsentation schreibgeschützt ist, oder `false`, wenn die Präsentation nicht schreibgeschützt ist.

Dieser Beispielcode zeigt Ihnen, wie Sie überprüfen, ob eine Präsentation schreibgeschützt ist:

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

## **Validieren oder Bestätigen, dass ein bestimmtes Passwort verwendet wurde, um eine Präsentation zu schützen**

Möglicherweise möchten Sie überprüfen und bestätigen, dass ein bestimmtes Passwort verwendet wurde, um ein Präsentationsdokument zu schützen. Aspose.Slides bietet die Mittel, um ein Passwort zu validieren.

Dieser Beispielcode zeigt Ihnen, wie Sie ein Passwort validieren:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    # überprüfen, ob "pass" mit übereinstimmt
    $isWriteProtected = $presentation->getProtectionManager()->checkWriteProtection("mein_passwort");
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

Es gibt `true` zurück, wenn die Präsentation mit dem angegebenen Passwort verschlüsselt wurde. Andernfalls gibt es `false` zurück.

{{% alert color="primary" title="Siehe auch" %}} 
- [Digitale Signatur in PowerPoint](/slides/de/net/digital-signature-in-powerpoint/)
{{% /alert %}}