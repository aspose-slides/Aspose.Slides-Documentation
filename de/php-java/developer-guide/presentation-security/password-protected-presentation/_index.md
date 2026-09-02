---
title: Passwortgeschützte Präsentationen in PHP
linktitle: Passwortschutz
type: docs
weight: 20
url: /de/php-java/password-protected-presentation/
keywords:
- passwortgeschützte Präsentation
- Öffnungskennwort
- PowerPoint verschlüsseln
- PowerPoint entschlüsseln
- Präsentationskennwort validieren
- Präsentationskennwort prüfen
- verschlüsselte Präsentation öffnen
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

Ein Öffnungskennwort verschlüsselt eine Präsentation. Das korrekte Kennwort ist erforderlich, um den Präsentationsinhalt zu laden und anzuzeigen, sodass dieser Schutz Vertraulichkeit gewährleistet.

Ein Öffnungskennwort unterscheidet sich von einem Schreibschutzkennwort. Der Schreibschutz schränkt Änderungen ein, verschlüsselt jedoch den Inhalt nicht und verhindert nicht das Laden der Präsentation. Um Kennwörter für die Änderung von Präsentationen zu verwalten, siehe [Präsentationen schreibschützen](/slides/de/php-java/write-protected-presentation/).

Die nachstehenden Workflows gelten für sowohl PPT- als auch PPTX-Präsentationen. Die Beispiele verwenden beide Formate, wenn deren Datei- bzw. Stream-basierte Verhalten wichtig ist.

## **Verschlüsseln einer Präsentation mit einem Öffnungskennwort**

Verwenden Sie [ProtectionManager::encrypt](https://reference.aspose.com/slides/de/php-java/aspose.slides/protectionmanager/#encrypt), um ein Öffnungskennwort zuzuweisen. Verwenden Sie anschließend [Presentation::save](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#save), um die verschlüsselte Präsentation zu speichern.

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

## **Laden einer verschlüsselten Präsentation**

Setzen Sie [LoadOptions::setPassword](https://reference.aspose.com/slides/de/php-java/aspose.slides/loadoptions/#setPassword) auf das Öffnungskennwort und übergeben Sie die Optionen an [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/), wenn Sie die Datei laden. Das Laden schlägt fehl, wenn ein Öffnungskennwort erforderlich ist, das übermittelte Kennwort jedoch fehlt oder falsch ist.

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

## **Entfernen der Verschlüsselung aus einer Präsentation**

Laden Sie die Präsentation mit ihrem Öffnungskennwort, rufen Sie [ProtectionManager::removeEncryption](https://reference.aspose.com/slides/de/php-java/aspose.slides/protectionmanager/#removeEncryption) auf und speichern Sie das Ergebnis. Die gespeicherte Präsentation kann anschließend ohne Kennwort geladen werden.

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

## **Validieren eines Öffnungskennworts vor dem Laden**

Verwenden Sie [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentationfactory/#getPresentationInfo), um [PresentationInfo](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentationinfo/) zu erhalten, ohne eine vollständige Präsentationsinstanz zu erstellen. Prüfen Sie [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentationinfo/#isPasswordProtected), bevor Sie ein Kennwort anfordern oder validieren. Ist ein Schutz vorhanden, validieren Sie den übermittelten Wert mit [PresentationInfo::checkPassword](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentationinfo/#checkPassword).

### **Dateipfad-Workflow**

Das folgende Beispiel validiert ein Öffnungskennwort für eine PPTX-Datei, übergibt den validierten Wert an [LoadOptions::setPassword](https://reference.aspose.com/slides/de/php-java/aspose.slides/loadoptions/#setPassword) und lädt anschließend die vollständige Präsentation:

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

Die Stream-Überladung von [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentationfactory/#getPresentationInfo) bietet denselben Workflow. Setzen Sie die Position eines durchsuchbaren Streams zurück, bevor Sie die vollständige Präsentation aus diesem Stream laden.

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

[PresentationInfo::checkPassword](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentationinfo/#checkPassword) gibt `true` nur zurück, wenn die Präsentation ein Öffnungskennwort hat und das übermittelte Kennwort korrekt ist. Es gibt `false` in jedem dieser Fälle zurück:

- Das Kennwort ist falsch.
- Die Präsentation hat kein Öffnungskennwort.
- Das übermittelte Kennwort ist `null` oder leer.

Das Verhalten ist für PPT‑ und PPTX‑Präsentationen gleich.

## **Überprüfen, ob eine geladene Präsentation verschlüsselt ist**

Nachdem Sie eine Präsentation mit dem richtigen Kennwort geladen haben, prüfen Sie [ProtectionManager::isEncrypted](https://reference.aspose.com/slides/de/php-java/aspose.slides/protectionmanager/#isEncrypted), um zu bestätigen, dass die Quellpräsentation verschlüsselt war. Um den Öffnungskennwortschutz vor dem Laden zu erkennen, verwenden Sie [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentationinfo/#isPasswordProtected) wie oben gezeigt.

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

## **Sicherheits-Empfehlungen**
{{% alert color="warning" title="Security" %}}
Protokollieren Sie keine Öffnungskennwörter und geben Sie sie nicht in Diagnosemeldungen aus. Vermeiden Sie unnötige wiederholte Validierungsversuche, halten Sie Kennwörter nur so lange im Speicher, wie sie benötigt werden, und verwenden Sie ein erfolgreiches Validierungsergebnis erneut, wenn die Präsentation sofort geladen wird.
{{% /alert %}}

## **Präsentation online passwortschützen**

1. Öffnen Sie die Anwendung [Aspose.Slides Lock](https://products.aspose.app/slides/de/lock).
1. Wählen Sie die Präsentation aus oder laden Sie sie hoch.
1. Geben Sie ein Kennwort für den Ansichtsschutz ein.
1. Optional geben Sie ein separates Kennwort für den Bearbeitungsschutz ein.
1. Wenden Sie den Schutz an und laden Sie die resultierende Datei herunter.

{{% alert color="info" title="See also" %}}
- [Präsentationen schreibschützen](/slides/de/php-java/write-protected-presentation/)
- [Digitale Signatur in PowerPoint](/slides/de/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Was ist der Unterschied zwischen einem Öffnungskennwort und einem Schreibschutzkennwort?**

Ein Öffnungskennwort verschlüsselt die Präsentation und ist zum Laden ihres Inhalts erforderlich. Ein Schreibschutzkennwort schränkt die Bearbeitung ein, ohne den Inhalt zu verschlüsseln.

**Kann ich ein Öffnungskennwort validieren, ohne alle Folien zu laden?**

Ja. Holen Sie die Präsentationsinformationen, prüfen Sie, ob ein Öffnungskennwortschutz vorhanden ist, und validieren Sie das Kennwort, bevor Sie eine vollständige Präsentationsinstanz erstellen.

**Unterstützen die Kennwort‑Prüf‑Workflows sowohl PPT als auch PPTX?**

Ja. Die kennwortbasierte Erkennung und Validierung über Dateipfad und Stream verhalten sich bei PPT‑ und PPTX‑Präsentationen gleich.