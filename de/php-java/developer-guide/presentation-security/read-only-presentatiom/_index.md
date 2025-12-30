---
title: Präsentationen im Nur-Lese-Modus mit PHP speichern
linktitle: Nur-Lese-Präsentation
type: docs
weight: 30
url: /de/php-java/read-only-presentation/
keywords:
- Nur-Lesen
- Präsentation schützen
- Bearbeitung verhindern
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Laden und Speichern von PowerPoint-Dateien (PPT, PPTX) im Nur-Lese-Modus mit Aspose.Slides für PHP, wobei präzise Folienvorschauen ermöglicht werden, ohne Ihre Präsentationen zu verändern."
---

## **Read-Only-Modus anwenden**

In PowerPoint 2019 hat Microsoft die Einstellung **Always Open Read-Only** eingeführt, die zu den Optionen gehört, die Benutzer zum Schutz ihrer Präsentationen verwenden können. Möglicherweise möchten Sie diese Read-Only-Einstellung zum Schutz einer Präsentation verwenden, wenn

- Sie verhindern versehentliche Änderungen und halten den Inhalt Ihrer Präsentation sicher. 
- Sie möchten Personen darauf hinweisen, dass die von Ihnen bereitgestellte Präsentation die endgültige Version ist. 

Nachdem Sie die Option **Always Open Read-Only** für eine Präsentation ausgewählt haben, sehen die Benutzer beim Öffnen der Präsentation die **Read-Only**-Empfehlung und können eine Meldung in folgender Form sehen: *To prevent accidental changes, the author has set this file to open as read-only.*

Die **Read-Only**-Empfehlung ist ein einfacher, aber wirksamer Abschreckungsmechanismus, der das Bearbeiten entmutigt, da Benutzer eine Aufgabe ausführen müssen, um sie zu entfernen, bevor sie eine Präsentation bearbeiten dürfen. Wenn Sie nicht möchten, dass Benutzer Änderungen an einer Präsentation vornehmen, und sie höflich darüber informieren möchten, kann die **Read-Only**-Empfehlung eine gute Option für Sie sein. 

> Wenn eine Präsentation mit dem **Read-Only**-Schutz in einer älteren Microsoft PowerPoint-Anwendung geöffnet wird – die die kürzlich eingeführte Funktion nicht unterstützt – wird die **Read-Only**-Empfehlung ignoriert (die Präsentation wird normal geöffnet).

Aspose.Slides für PHP via Java ermöglicht es Ihnen, eine Präsentation auf **Read-Only** zu setzen, sodass Benutzer (nachdem sie die Präsentation geöffnet haben) die **Read-Only**-Empfehlung sehen. Dieser Beispielcode zeigt, wie Sie eine Präsentation mit **Read-Only** über Aspose.Slides setzen:
```php
  $pres = new Presentation();
  try {
    $pres->getProtectionManager()->setReadOnlyRecommended(true);
    $pres->save("ReadOnlyPresentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="primary" %}} 

**Hinweis**: Die **Read-Only**-Empfehlung soll lediglich das Bearbeiten entmutigen oder Benutzer davon abhalten, versehentliche Änderungen an einer PowerPoint-Präsentation vorzunehmen. Wenn eine motivierte Person – die weiß, was sie tut – beschließt, Ihre Präsentation zu bearbeiten, kann sie die Read-Only-Einstellung leicht entfernen. Wenn Sie wirklich verhindern müssen, dass unbefugte Änderungen vorgenommen werden, sollten Sie besser [more stringent protections that involve encryptions and passwords](https://docs.aspose.com/slides/php-java/password-protected-presentation/) verwenden.

{{% /alert %}} 

## **FAQ**

**Wie unterscheidet sich 'Read-Only recommended' von einem vollständigen Passwortschutz?**

'Read-Only recommended' zeigt nur einen Hinweis an, die Datei im schreibgeschützten Modus zu öffnen, und lässt sich leicht umgehen. [Password protection](/slides/de/php-java/password-protected-presentation/) beschränkt tatsächlich das Öffnen oder Bearbeiten und eignet sich, wenn Sie echte Sicherheitskontrollen benötigen.

**Kann 'Read-Only recommended' mit Wasserzeichen kombiniert werden, um das Bearbeiten weiter zu entmutigen?**

Ja. Die Empfehlung kann mit [watermarks](/slides/de/php-java/watermark/) als visueller Abschreckungsmechanismus kombiniert werden; sie sind separate Mechanismen und arbeiten gut zusammen.

**Kann ein Makro oder ein externes Tool die Datei trotzdem ändern, wenn die Empfehlung aktiviert ist?**

Ja. Die Empfehlung blockiert keine programmgesteuerten Änderungen. Um automatisierte Bearbeitungen zu verhindern, verwenden Sie [passwords and encryption](/slides/de/php-java/password-protected-presentation/).

**Wie steht 'Read-Only recommended' im Verhältnis zu den Methoden 'isEncrypted' und 'isWriteProtected'?**

Sie sind unterschiedliche Signale. 'Read-Only recommended' ist ein weicher, optionaler Hinweis; [isWriteProtected](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/iswriteprotected/) und [isEncrypted](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/isencrypted/) zeigen tatsächliche Schreib- bzw. Lesebeschränkungen an, die von Passwörtern oder Verschlüsselung abhängen.