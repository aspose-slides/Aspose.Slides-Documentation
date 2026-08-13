---
title: Präsentationen im Nur-Lese-Modus auf Android speichern
linktitle: Nur-Lese-Präsentation
type: docs
weight: 30
url: /de/androidjava/read-only-presentation/
keywords:
- nur lesen
- Präsentation schützen
- Bearbeitung verhindern
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Speichern Sie PowerPoint-Dateien (PPT, PPTX) im Nur-Lese-Modus mit Aspose.Slides für Android via Java und erhalten präzise Folienvorschauen, ohne Ihre Präsentationen zu verändern."
---
## **Einleitung**

In PowerPoint 2019 hat Microsoft die Einstellung **Always Open Read-Only** als eine der Optionen eingeführt, die Benutzer zum Schutz ihrer Präsentationen nutzen können. Sie möchten diese Nur-Lese‑Einstellung verwenden, um eine Präsentation zu schützen, wenn

- Sie unbeabsichtigte Änderungen verhindern und den Inhalt Ihrer Präsentation sicher behalten möchten. 
- Sie die Menschen darauf hinweisen möchten, dass die von Ihnen bereitgestellte Präsentation die endgültige Version ist. 

Nachdem Sie die Option **Always Open Read-Only** für eine Präsentation ausgewählt haben, sehen Benutzer beim Öffnen der Präsentation die **Read-Only**‑Empfehlung und möglicherweise eine Meldung in folgender Form: *Um unbeabsichtigte Änderungen zu verhindern, hat der Autor diese Datei als schreibgeschützt festgelegt.*

Die Read-Only‑Empfehlung ist ein einfacher, aber wirksamer Abschreckungsmechanismus, der das Bearbeiten entmutigt, weil Benutzer eine Aufgabe ausführen müssen, um sie zu entfernen, bevor sie die Präsentation bearbeiten dürfen. Wenn Sie nicht möchten, dass Benutzer Änderungen an einer Präsentation vornehmen und dies höflich mitteilen wollen, dann kann die Read-Only‑Empfehlung eine gute Option für Sie sein. 

> Wird eine Präsentation mit dem **Read-Only**‑Schutz in einer älteren Microsoft PowerPoint‑Anwendung geöffnet – die die kürzlich eingeführte Funktion nicht unterstützt – wird die **Read-Only**‑Empfehlung ignoriert (die Präsentation wird normal geöffnet).

## **Read‑Only‑Modus anwenden**

Aspose.Slides for Android via Java ermöglicht es Ihnen, eine Präsentation auf **Read-Only** zu setzen, wodurch Benutzer (nach dem Öffnen der Präsentation) die **Read-Only**‑Empfehlung sehen. Dieser Beispielcode zeigt Ihnen, wie Sie eine Präsentation in Java mit Aspose.Slides auf **Read-Only** setzen:

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

**Hinweis**: Die **Read-Only**‑Empfehlung soll lediglich das Bearbeiten entmutigen bzw. Nutzer davon abhalten, unbeabsichtigte Änderungen an einer PowerPoint‑Präsentation vorzunehmen. Wenn eine motivierte Person – die weiß, was sie tut – sich entscheidet, Ihre Präsentation zu bearbeiten, kann sie die Read-Only‑Einstellung leicht entfernen. Wenn Sie wirklich unbefugtes Bearbeiten verhindern müssen, sollten Sie besser [strengere Schutzmaßnahmen, die Verschlüsselungen und Passwörter umfassen](https://docs.aspose.com/slides/de/androidjava/password-protected-presentation/) verwenden.

{{% /alert %}} 

## **FAQ**

### Wie unterscheidet sich 'Read-Only recommended' vom vollständigen Passwortschutz?

'Read-Only recommended' zeigt lediglich einen Vorschlag an, die Datei im schreibgeschützten Modus zu öffnen, und lässt sich leicht umgehen. [Passwortschutz](/slides/de/androidjava/password-protected-presentation/) schränkt das Öffnen oder Bearbeiten tatsächlich ein und ist geeignet, wenn Sie echte Sicherheitskontrollen benötigen.

### Kann 'Read-Only recommended' mit Wasserzeichen kombiniert werden, um Bearbeitungen weiter zu entmutigen?

Ja. Die Empfehlung kann zusammen mit [watermarks](/slides/de/androidjava/watermark/) als visueller Abschreckungsmechanismus verwendet werden; sie sind getrennte Mechanismen und arbeiten gut zusammen.

### Kann ein Makro oder externes Tool die Datei noch ändern, wenn die Empfehlung aktiviert ist?

Ja. Die Empfehlung blockiert keine programmatischen Änderungen. Um automatisierte Bearbeitungen zu verhindern, verwenden Sie [Passwörter und Verschlüsselung](/slides/de/androidjava/password-protected-presentation/).

### Wie steht 'Read-Only recommended' im Zusammenhang mit den Methoden 'isEncrypted' und 'isWriteProtected'?

Sie sind unterschiedliche Signale. 'Read-Only recommended' ist ein weicher, optionaler Hinweis; [isWriteProtected](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/protectionmanager/#isWriteProtected--) und [isEncrypted](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/protectionmanager/#isEncrypted--) zeigen tatsächliche Schreib‑ bzw. Leseeinschränkungen an, die von Passwörtern oder Verschlüsselung abhängen.