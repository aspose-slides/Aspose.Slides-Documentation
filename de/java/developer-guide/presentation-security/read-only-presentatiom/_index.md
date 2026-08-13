---
title: Präsentationen im Nur-Lese-Modus mit Java speichern
linktitle: Nur-Lese-Präsentation
type: docs
weight: 30
url: /de/java/read-only-presentation/
keywords:
- nur lesen
- Präsentation schützen
- Bearbeitung verhindern
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "PowerPoint-Dateien (PPT, PPTX) im Nur-Lese-Modus mit Aspose.Slides für Java laden und speichern, wodurch präzise Folienvorschauen ohne Änderung Ihrer Präsentationen ermöglicht werden."
---
## **Einleitung**

In PowerPoint 2019 hat Microsoft die Einstellung **Always Open Read-Only** als eine der Optionen eingeführt, die Benutzer zum Schutz ihrer Präsentationen verwenden können. Sie können diese Read-Only‑Einstellung zum Schutz einer Präsentation einsetzen, wenn

- Sie versehentliche Änderungen verhindern und den Inhalt Ihrer Präsentation sicher halten möchten.  
- Sie die Nutzer darauf hinweisen möchten, dass die von Ihnen bereitgestellte Präsentation die endgültige Version ist.  

Nachdem Sie die Option **Always Open Read-Only** für eine Präsentation ausgewählt haben, sehen die Benutzer beim Öffnen der Präsentation die **Read-Only**‑Empfehlung und möglicherweise eine Meldung in dieser Form: *Um versehentliche Änderungen zu verhindern, hat der Autor diese Datei zum Öffnen im Nur-Lese-Modus festgelegt.*

Die **Read-Only**‑Empfehlung ist ein einfacher, aber wirksamer Abschreckungsmechanismus, der das Bearbeiten entmutigt, da die Benutzer eine Aufgabe erledigen müssen, um sie zu entfernen, bevor sie die Präsentation bearbeiten dürfen. Wenn Sie nicht möchten, dass Benutzer Änderungen an einer Präsentation vornehmen, und dies höflich mitteilen wollen, kann die **Read-Only**‑Empfehlung eine gute Option für Sie sein.

> Wenn eine Präsentation mit dem **Read-Only**‑Schutz in einer älteren Microsoft PowerPoint‑Anwendung geöffnet wird, die die kürzlich eingeführte Funktion nicht unterstützt, wird die **Read-Only**‑Empfehlung ignoriert (die Präsentation wird normal geöffnet).

## **Read-Only‑Modus anwenden**

Aspose.Slides for Java ermöglicht es Ihnen, eine Präsentation auf **Read-Only** zu setzen, sodass Benutzer (nachdem sie die Präsentation geöffnet haben) die **Read-Only**‑Empfehlung sehen. Dieser Beispielcode zeigt, wie Sie eine Präsentation in Java mit Aspose.Slides auf **Read-Only** setzen:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 

**Hinweis**: Die **Read-Only**‑Empfehlung soll lediglich das Bearbeiten entmutigen oder verhindern, dass Benutzer versehentliche Änderungen an einer PowerPoint‑Präsentation vornehmen. Wenn eine motivierte Person—die weiß, was sie tut—sich entscheidet, Ihre Präsentation zu bearbeiten, kann sie die Read‑Only‑Einstellung leicht entfernen. Wenn Sie wirklich unbefugtes Bearbeiten verhindern müssen, sollten Sie besser [more stringent protections that involve encryptions and passwords](https://docs.aspose.com/slides/de/java/password-protected-presentation/) verwenden. 

{{% /alert %}} 

## **FAQ**

### Wie unterscheidet sich 'Read-Only recommended' von vollem Passwortschutz?

'Read-Only recommended' zeigt lediglich einen Vorschlag an, die Datei im Nur-Lese‑Modus zu öffnen, und lässt sich leicht umgehen. [Password protection](/slides/de/java/password-protected-presentation/) beschränkt das Öffnen oder Bearbeiten tatsächlich und ist geeignet, wenn Sie echte Sicherheitskontrollen benötigen.

### Kann 'Read-Only recommended' mit Wasserzeichen kombiniert werden, um Änderungen weiter zu entmutigen?

Ja. Die Empfehlung kann zusammen mit [watermarks](/slides/de/java/watermark/) als visueller Abschreckungsmechanismus verwendet werden; sie sind separate Mechanismen und funktionieren gut zusammen.

### Kann ein Makro oder externes Tool die Datei trotzdem ändern, wenn die Empfehlung aktiviert ist?

Ja. Die Empfehlung blockiert keine programmatischen Änderungen. Um automatisierte Bearbeitungen zu verhindern, verwenden Sie [passwords and encryption](/slides/de/java/password-protected-presentation/).

### Wie steht 'Read-Only recommended' im Verhältnis zu den Methoden 'isEncrypted' und 'isWriteProtected'?

Sie sind unterschiedliche Signale. 'Read-Only recommended' ist ein weicher, optionaler Hinweis; [isWriteProtected](https://reference.aspose.com/slides/de/java/com.aspose.slides/protectionmanager/#isWriteProtected--) und [isEncrypted](https://reference.aspose.com/slides/de/java/com.aspose.slides/protectionmanager/#isEncrypted--) zeigen tatsächliche Schreib‑ bzw. Leseeinschränkungen an, die von Passwörtern oder Verschlüsselungen abhängen.