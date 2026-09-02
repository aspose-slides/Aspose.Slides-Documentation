---
title: Schreibschutz für Präsentationen in PHP
linktitle: Schreibschutz
type: docs
weight: 25
url: /de/php-java/write-protected-presentation/
keywords:
- Schreibschutz
- Schreibschutz für PowerPoint
- Passwort zum Ändern
- Bearbeitung der Präsentation einschränken
- Schreibschutz entfernen
- Passwort zum Ändern validieren
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Schreibschutz-Passwörter in PowerPoint PPT- und PPTX-Präsentationen setzen, erkennen, validieren und entfernen mit Aspose.Slides für PHP."
---
## **Einleitung**

Ein Schreibschutz‑Passwort schränkt die Änderung einer Präsentation ein, verschlüsselt jedoch nicht deren Inhalt. Benutzer können eine schreibgeschützte Präsentation ohne das Passwort laden und anzeigen. Je nach Anwendung können sie den Inhalt möglicherweise auch bearbeiten und unter einem anderen Namen speichern, sodass Schreibschutz nicht als Vertraulichkeits‑Mechanismus betrachtet werden sollte.

Ein Öffnungs‑passwort hat einen anderen Zweck: Es verschlüsselt die Präsentation und ist zum Laden des Inhalts erforderlich. Zum Verschlüsseln einer Präsentation oder zum Validieren eines Öffnungs‑passworts siehe [Password-Protect Presentations](/slides/de/php-java/password-protected-presentation/).

Die in diesem Artikel beschriebenen Workflows gelten sowohl für PPT‑ als auch PPTX‑Präsentationen. Die Beispiele verwenden PPTX‑Dateien; beim Speichern im PPT‑Format verwenden Sie die Erweiterung `.ppt` und das entsprechende PPT‑Speicherformat.

## **Schreibschutz für eine Präsentation festlegen**

Verwenden Sie [ProtectionManager::setWriteProtection](https://reference.aspose.com/slides/de/php-java/aspose.slides/protectionmanager/#setWriteProtection), um ein Passwort zum Ändern einer Präsentation festzulegen. Beim Speichern der Präsentation wird die Schutzeinstellung beibehalten.

Das folgende Beispiel legt einen Schreibschutz für eine PPTX‑Präsentation fest:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->getProtectionManager()->setWriteProtection("modify_password");
    $presentation->save("write-protected-pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Eine schreibgeschützte Präsentation laden**

Da Schreibschutz den Präsentationsinhalt nicht verschlüsselt, ist zum Laden der Präsentation kein Passwort erforderlich. Das Passwort ist nur relevant, wenn die Berechtigung zum Ändern der geschützten Präsentation geprüft werden soll.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("write-protected-pres.pptx");
try {
    echo("Slide count: " . $presentation->getSlides()->size() . "\n");
} finally {
    $presentation->dispose();
}
```

Übergeben Sie kein Schreibschutz‑Passwort an [LoadOptions::setPassword](https://reference.aspose.com/slides/de/php-java/aspose.slides/loadoptions/#setPassword). Diese Methode akzeptiert ein Öffnungs‑passwort für verschlüsselten Inhalt. Hat eine Präsentation beide Schutzarten, übergeben Sie das Öffnungs‑passwort zum Laden und behandeln Sie das Schreibschutz‑Passwort separat.

## **Schreibschutz von einer Präsentation entfernen**

Verwenden Sie [ProtectionManager::removeWriteProtection](https://reference.aspose.com/slides/de/php-java/aspose.slides/protectionmanager/#removeWriteProtection), um die Änderungsbeschränkung zu entfernen, und speichern Sie anschließend die Präsentation.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("write-protected-pres.pptx");
try {
    $presentation->getProtectionManager()->removeWriteProtection();
    $presentation->save("write-protection-removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Prüfen, ob eine Präsentation schreibgeschützt ist**

Um eine Datei zu untersuchen, ohne eine komplette [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/)-Instanz zu erstellen, rufen Sie [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentationfactory/#getPresentationInfo) auf und prüfen Sie [PresentationInfo::isWriteProtected](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentationinfo/#isWriteProtected). Die Methode verwendet [NullableBool](https://reference.aspose.com/slides/de/php-java/aspose.slides/nullablebool/) und gibt `NullableBool::True` zurück, wenn ein Schreibschutz erkannt wird.

```php
use aspose\slides\NullableBool;
use aspose\slides\PresentationFactory;

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo("write-protected-pres.pptx");

if ($presentationInfo->isWriteProtected() == NullableBool::True) {
    echo("The presentation is write protected.\n");
} else {
    echo("Write protection was not detected.\n");
}
```

Die Stream‑Überladung von [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentationfactory/#getPresentationInfo) liefert dieselben Informationen für eine als Stream bereitgestellte Präsentation.

## **Schreibschutz‑Passwort validieren**

Verwenden Sie [PresentationInfo::checkWriteProtection](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentationinfo/#checkWriteProtection), um ein Änderungs‑passwort zu validieren, ohne die komplette Präsentation zu laden. Prüfen Sie zuerst [PresentationInfo::isWriteProtected](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentationinfo/#isWriteProtected), damit die Anwendung nur dann ein Passwort anfordert oder validiert, wenn ein Schreibschutz vorhanden ist.

```php
use aspose\slides\NullableBool;
use aspose\slides\PresentationFactory;

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo("write-protected-pres.pptx");

if ($presentationInfo->isWriteProtected() != NullableBool::True) {
    echo("The presentation is not write protected.\n");
} elseif ($presentationInfo->checkWriteProtection("modify_password")) {
    echo("The write-protection password is correct.\n");
} else {
    echo("The write-protection password is incorrect.\n");
}
```

[PresentationInfo::checkWriteProtection](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentationinfo/#checkWriteProtection) prüft nur das Schreibschutz‑Passwort. Es validiert kein Öffnungs‑passwort und ermittelt nicht, ob verschlüsselter Inhalt geladen werden kann. Im Gegensatz dazu prüft [PresentationInfo::checkPassword](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentationinfo/#checkPassword) ausschließlich ein Öffnungs‑passwort. Wurde bereits eine komplette Präsentation geladen, liefert [ProtectionManager::checkWriteProtection](https://reference.aspose.com/slides/de/php-java/aspose.slides/protectionmanager/#checkWriteProtection) die entsprechende Schreibschutzprüfung über seinen Schutz‑Manager.

In Produktionsanwendungen sollten Passwörter nicht protokolliert oder in Diagnosemeldungen aufgenommen werden. Vermeiden Sie unnötige wiederholte Validierungsversuche und halten Sie Passwörter im Speicher nur so lange, wie sie benötigt werden.

{{% alert color="info" title="Siehe auch" %}}
- [Password-Protect Presentations](/slides/de/php-java/password-protected-presentation/)
- [Read-Only Presentations](/slides/de/php-java/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/de/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Verschlüsselt Schreibschutz eine Präsentation?**

Nein. Er beschränkt Änderungen, lässt jedoch den Präsentationsinhalt zum Laden und Anzeigen verfügbar.

**Ist das Schreibschutz‑Passwort zum Öffnen einer Präsentation erforderlich?**

Nein. Nur ein Öffnungs‑passwort ist zum Laden von verschlüsseltem Präsentationsinhalt erforderlich.

**Kann eine Präsentation sowohl ein Öffnungs‑passwort als auch ein Schreibschutz‑Passwort haben?**

Ja. Geben Sie das Öffnungs‑passwort über die Ladeoptionen an, um die verschlüsselte Präsentation zu öffnen, und prüfen Sie das Schreibschutz‑Passwort separat, wenn eine Änderungsberechtigung erforderlich ist.