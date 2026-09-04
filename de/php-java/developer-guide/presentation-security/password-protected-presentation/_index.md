---
title: Passwortgeschützte Präsentationen in PHP
linktitle: Passwortschutz
type: docs
weight: 20
url: /de/php-java/password-protected-presentation/
keywords:
- Passwortgeschützte Präsentation
- Öffnungspasswort
- PowerPoint verschlüsseln
- PowerPoint entschlüsseln
- Präsentationspasswort validieren
- Präsentationspasswort prüfen
- Verschlüsselte Präsentation öffnen
- Verschlüsselung entfernen
- PowerPoint
- PPT
- PPTX
- Präsentation
- PHP
- Aspose.Slides
description: "Verschlüsseln, erkennen, validieren, öffnen und entschlüsseln von passwortgeschützten PowerPoint PPT- und PPTX-Präsentationen in PHP mit Aspose.Slides."
---
## **Übersicht**

Ein Öffnungspasswort verschlüsselt eine Präsentation. Das korrekte Passwort ist erforderlich, um den Präsentationsinhalt zu laden und anzuzeigen, sodass dieser Schutz Vertraulichkeit gewährleistet.

Ein Öffnungspasswort unterscheidet sich von einem Schreibschutz-Passwort. Der Schreibschutz beschränkt Änderungen, verschlüsselt jedoch nicht den Inhalt und verhindert nicht das Laden der Präsentation. Um Passwörter für das Ändern von Präsentationen zu verwalten, siehe [Präsentationen schreibschützen](/slides/de/php-java/write-protected-presentation/).

Die unten stehenden Workflows gelten sowohl für PPT- als auch für PPTX-Präsentationen. Die Beispiele verwenden beide Formate, wenn ihr dateibasiertes bzw. streambasiertes Verhalten wichtig ist.

## **Verschlüsseln einer Präsentation mit einem Öffnungspasswort**

Verwenden Sie [ProtectionManager::encrypt](https://reference.aspose.com/slides/de/php-java/aspose.slides/protectionmanager/#encrypt), um ein Öffnungspasswort zuzuweisen. Anschließend verwenden Sie [Presentation::save](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#save), um die verschlüsselte Präsentation zu speichern.

Das folgende Beispiel verschlüsselt eine PPTX‑Präsentation:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->getProtectionManager()->encrypt("open_password");
    $presentation->save("encrypted-pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Dokumenteigenschaften öffentlich halten**

Standardmäßig schließt Aspose.Slides Dokumenteigenschaften in die Präsentationsverschlüsselung ein. Die Methode [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/de/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) steuert dieses Verhalten unabhängig von der Verschlüsselung des Folieninhalts. Übergeben Sie `false` vor dem Aufruf von [ProtectionManager::encrypt](https://reference.aspose.com/slides/de/php-java/aspose.slides/protectionmanager/#encrypt), wenn ein Indexierungs-, Klassifizierungs-, Such- oder Dokumenten‑Management‑System Metadaten ohne das Öffnungspasswort lesen muss.

Das folgende Beispiel erstellt eine verschlüsselte PPTX‑Präsentation, lässt jedoch deren integrierte Dokumenteigenschaften öffentlich:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $properties = $presentation->getDocumentProperties();
    $properties->setAuthor("Contoso Knowledge Management");
    $properties->setTitle("Quarterly Product Roadmap");
    $properties->setKeywords("roadmap, planning, internal");

    $presentation->getSlides()->get_Item(0)->setName("Encrypted presentation content");
    $presentation->getProtectionManager()->setEncryptDocumentProperties(false);
    $presentation->getProtectionManager()->encrypt("open_password");
    $presentation->save("public-properties-encrypted.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`false` an [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/de/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) zu übergeben, macht Folien, Masterfolien, Layouts, Formen, Medien oder andere Präsentationsinhalte nicht öffentlich. Es betrifft ausschließlich Dokumenteigenschaften. Um diese Eigenschaften ohne Laden des verschlüsselten Inhalts zu lesen, siehe [Manage Presentation Properties](/slides/de/php-java/presentation-properties/).

## **Laden einer verschlüsselten Präsentation**

Setzen Sie [LoadOptions::setPassword](https://reference.aspose.com/slides/de/php-java/aspose.slides/loadoptions/#setPassword) auf das Öffnungspasswort und übergeben Sie die Optionen beim Laden der Datei an [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/). Das Laden schlägt fehl, wenn ein Öffnungspasswort erforderlich ist, das bereitgestellte Passwort jedoch fehlt oder falsch ist.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    # Arbeiten mit der entschlüsselten Präsentation.
} finally {
    $presentation->dispose();
}
```

## **Verschlüsselung einer Präsentation entfernen**

Laden Sie die Präsentation mit ihrem Öffnungspasswort, rufen Sie [ProtectionManager::removeEncryption](https://reference.aspose.com/slides/de/php-java/aspose.slides/protectionmanager/#removeEncryption) auf und speichern Sie das Ergebnis. Die gespeicherte Präsentation kann anschließend ohne Passwort geladen werden.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $presentation->getProtectionManager()->removeEncryption();
    $presentation->save("encryption-removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Öffnungspasswort vor dem Laden validieren**

Verwenden Sie [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentationfactory/#getPresentationInfo), um [PresentationInfo](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentationinfo/) zu erhalten, ohne eine vollständige Präsentationsinstanz zu erstellen. Prüfen Sie [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentationinfo/#isPasswordProtected), bevor Sie ein Passwort anfordern oder validieren. Ist ein Schutz vorhanden, validieren Sie den angegebenen Wert mit [PresentationInfo::checkPassword](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentationinfo/#checkPassword).

### **Dateipfad-Workflow**

Das folgende Beispiel validiert ein Öffnungspasswort für eine PPTX‑Datei, übergibt den validierten Wert an [LoadOptions::setPassword](https://reference.aspose.com/slides/de/php-java/aspose.slides/loadoptions/#setPassword) und lädt anschließend die vollständige Präsentation:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$filePath = "protected-presentation.pptx";
$password = "open_password";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($filePath);

if (!$presentationInfo->isPasswordProtected()) {
    echo("The presentation does not have an opening password.\n");
} elseif (!$presentationInfo->checkPassword($password)) {
    echo("The opening password is incorrect.\n");
} else {
    $loadOptions = new LoadOptions();
    $loadOptions->setPassword($password);

    $presentation = new Presentation($filePath, $loadOptions);
    try {
        echo("The presentation was validated and loaded successfully.\n");
    } finally {
        $presentation->dispose();
    }
}
```

### **Stream-Workflow**

Die Stream-Überladung von [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentationfactory/#getPresentationInfo) bietet denselben Workflow. Setzen Sie die Position eines seekfähigen Streams zurück, bevor Sie die vollständige Präsentation aus diesem Stream laden.

Das folgende Beispiel verwendet eine PPT‑Datei:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$password = "open_password";

$presentationStream = new Java("java.io.FileInputStream", "protected-presentation.ppt");
try {
    $presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($presentationStream);

    if (!$presentationInfo->isPasswordProtected()) {
        echo("The presentation does not have an opening password.\n");
    } elseif (!$presentationInfo->checkPassword($password)) {
        echo("The opening password is incorrect.\n");
    } else {
        $presentationStream->getChannel()->position(0);

        $loadOptions = new LoadOptions();
        $loadOptions->setPassword($password);

        $presentation = new Presentation($presentationStream, $loadOptions);
        try {
            echo("The presentation was validated and loaded successfully.\n");
        } finally {
            $presentation->dispose();
        }
    }
} finally {
    $presentationStream->close();
}
```

### **Rückgabewerte von checkPassword**

[PresentationInfo::checkPassword](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentationinfo/#checkPassword) gibt nur dann `true` zurück, wenn die Präsentation ein Öffnungspasswort hat und das übergebene Passwort korrekt ist. Es gibt `false` in den folgenden Fällen zurück:

- Das Passwort ist falsch.
- Die Präsentation hat kein Öffnungspasswort.
- Das übergebene Passwort ist `null` oder leer.

Das Verhalten ist für PPT‑ und PPTX‑Präsentationen identisch.

## **Prüfen, ob eine geladene Präsentation verschlüsselt ist**

Nachdem Sie eine Präsentation mit dem korrekten Passwort geladen haben, prüfen Sie [ProtectionManager::isEncrypted](https://reference.aspose.com/slides/de/php-java/aspose.slides/protectionmanager/#isEncrypted), um zu bestätigen, dass die Quellpräsentation verschlüsselt war. Um den Schutz durch Öffnungspasswort vor dem Laden zu erkennen, verwenden Sie [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentationinfo/#isPasswordProtected), wie oben gezeigt.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $isEncrypted = $presentation->getProtectionManager()->isEncrypted();
    echo("The presentation is encrypted: " . ($isEncrypted ? "true" : "false") . "\n");
} finally {
    $presentation->dispose();
}
```

## **Sicherheits‑Empfehlungen**

{{% alert color="warning" title="Security" %}}
Protokollieren Sie Öffnungspasswörter nicht und fügen Sie sie nicht in Diagnosemeldungen ein. Vermeiden Sie unnötige wiederholte Validierungsversuche, halten Sie Passwörter nur so lange wie nötig im Speicher und verwenden Sie ein erfolgreiches Validierungsergebnis erneut, wenn Sie die Präsentation sofort laden.

Öffentliche Dokumenteigenschaften können Autorennamen, Titel, Betreff, Schlüsselwörter, Firmeninformationen, Kommentare und benutzerdefinierte Werte preisgeben, obwohl der Präsentationsinhalt verschlüsselt ist. Verschlüsseln Sie sensible Metadaten zusammen mit der Präsentation. Das Offenlassen von Eigenschaften sollte nur dann bewusst entschieden werden, wenn Systeme die Datei ohne Öffnungspasswort indexieren, klassifizieren, durchsuchen oder verwalten müssen.
{{% /alert %}}

## **Präsentation online passwortschützen**

1. Öffnen Sie die Anwendung [Aspose.Slides Lock](https://products.aspose.app/slides/de/lock).
1. Wählen Sie die Präsentation aus oder laden Sie sie hoch.
1. Geben Sie ein Passwort für den Sichtschutz ein.
1. Optional können Sie ein separates Passwort für den Bearbeitungsschutz eingeben.
1. Wenden Sie den Schutz an und laden Sie die resultierende Datei herunter.

{{% alert color="info" title="See also" %}}
- [Präsentationen schreibschützen](/slides/de/php-java/write-protected-presentation/)
- [Digitale Signatur in PowerPoint](/slides/de/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Was ist der Unterschied zwischen einem Öffnungspasswort und einem Schreibschutz-Passwort?**

Ein Öffnungspasswort verschlüsselt die Präsentation und ist zum Laden des Inhalts erforderlich. Ein Schreibschutz-Passwort beschränkt Änderungen, ohne den Inhalt zu verschlüsseln.

**Kann ich ein Öffnungspasswort validieren, ohne alle Folien zu laden?**

Ja. Holen Sie Präsentationsinformationen ab, prüfen Sie, ob ein Öffnungspasswortschutz vorhanden ist, und validieren Sie das Passwort, bevor Sie eine vollständige Präsentationsinstanz erstellen.

**Kann eine Anwendung Metadaten ohne das Öffnungspasswort lesen?**

Ja, jedoch nur, wenn die Präsentation mit deaktivierter Dokumenteneigenschaftsverschlüsselung verschlüsselt wurde. Die Anwendung muss dann den ausschließlich für Dokumenteigenschaften vorgesehenen Lademodus verwenden, wie in [Manage Presentation Properties](/slides/de/php-java/presentation-properties/) beschrieben.

**Unterstützen die Passwort‑Prüf‑Workflows sowohl PPT als auch PPTX?**

Ja. Die dateipfad- und streambasierten Passwort‑Erkennungs‑ und Validierungs‑Workflows verhalten sich bei PPT‑ und PPTX‑Präsentationen identisch.