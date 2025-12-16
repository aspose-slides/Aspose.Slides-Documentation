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
description: "Speichern Sie PowerPoint-Dateien (PPT, PPTX) im Nur-Lese-Modus mit Aspose.Slides für Android via Java und erhalten Sie präzise Folienvorschauen, ohne Ihre Präsentationen zu verändern."
---

## **Read-Only-Modus anwenden**

In PowerPoint 2019 hat Microsoft die Einstellung **Always Open Read-Only** eingeführt, die zu den Optionen gehört, die Benutzer zum Schutz ihrer Präsentationen verwenden können.  
Möglicherweise möchten Sie diese Read-Only‑Einstellung zum Schutz einer Präsentation verwenden, wenn

- Sie verhindern versehentliche Änderungen und halten den Inhalt Ihrer Präsentation sicher.  
- Sie die Personen darauf hinweisen möchten, dass die von Ihnen bereitgestellte Präsentation die finale Version ist.  

Nachdem Sie die Option **Always Open Read-Only** für eine Präsentation ausgewählt haben, sehen die Benutzer beim Öffnen der Präsentation die **Read-Only**‑Empfehlung und möglicherweise eine Meldung in folgender Form: *Um versehentliche Änderungen zu verhindern, hat der Autor diese Datei als schreibgeschützt festgelegt.*

Die **Read-Only**‑Empfehlung ist ein einfacher, aber effektiver Abschreckungsmechanismus, der das Bearbeiten entmutigt, weil Benutzer eine Aufgabe ausführen müssen, um sie zu entfernen, bevor sie die Präsentation bearbeiten dürfen. Wenn Sie nicht möchten, dass Benutzer Änderungen an einer Präsentation vornehmen, und dies höflich mitteilen wollen, dann kann die **Read-Only**‑Empfehlung eine gute Option für Sie sein.

> Wenn eine Präsentation mit dem **Read-Only**‑Schutz in einer älteren Microsoft‑PowerPoint‑Anwendung geöffnet wird, die die kürzlich eingeführte Funktion nicht unterstützt, wird die **Read-Only**‑Empfehlung ignoriert (die Präsentation wird normal geöffnet).

Aspose.Slides for Android via Java ermöglicht es Ihnen, eine Präsentation auf **Read-Only** zu setzen, wodurch Benutzer (nach dem Öffnen der Präsentation) die **Read-Only**‑Empfehlung sehen. Dieser Beispielcode zeigt, wie Sie eine Präsentation in Java mit Aspose.Slides auf **Read-Only** setzen können:
```java
Presentation pres = new Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" %}} 
**Hinweis**: Die **Read-Only**‑Empfehlung dient lediglich dazu, das Bearbeiten zu erschweren oder Benutzer davon abzuhalten, versehentliche Änderungen an einer PowerPoint‑Präsentation vorzunehmen. Wenn eine motivierte Person – die genau weiß, was sie tut – sich entscheidet, Ihre Präsentation zu bearbeiten, kann sie die Read‑Only‑Einstellung leicht entfernen. Wenn Sie den unbefugten Zugriff ernsthaft verhindern müssen, ist es besser, [striktere Schutzmaßnahmen zu verwenden, die Verschlüsselungen und Passwörter beinhalten](https://docs.aspose.com/slides/androidjava/password-protected-presentation/).
{{% /alert %}} 

## **FAQ**

**Wie unterscheidet sich 'Read-Only recommended' von einem vollständigen Passwortschutz?**

'Read-Only recommended' zeigt lediglich einen Vorschlag an, die Datei im Nur‑Lese‑Modus zu öffnen, und ist leicht zu umgehen. [Passwortschutz](/slides/de/androidjava/password-protected-presentation/) beschränkt das Öffnen oder Bearbeiten tatsächlich und ist geeignet, wenn Sie echte Sicherheitskontrollen benötigen.

**Kann 'Read-Only recommended' mit Wasserzeichen kombiniert werden, um das Bearbeiten weiter zu erschweren?**

Ja. Die Empfehlung kann mit [Wasserzeichen](/slides/de/androidjava/watermark/) als visuellen Abschreckungsmechanismus kombiniert werden; sie sind separate Mechanismen und funktionieren gut zusammen.

**Kann ein Makro oder externes Tool die Datei dennoch ändern, wenn die Empfehlung aktiviert ist?**

Ja. Die Empfehlung blockiert keine programmatischen Änderungen. Um automatisierte Bearbeitungen zu verhindern, verwenden Sie [Passwörter und Verschlüsselung](/slides/de/androidjava/password-protected-presentation/).

**Wie steht 'Read-Only recommended' im Zusammenhang mit den Methoden 'isEncrypted' und 'isWriteProtected'?**

Sie sind unterschiedliche Signale. 'Read-Only recommended' ist eine weiche, optionale Hinweis; [isWriteProtected](https://reference.aspose.com/slides/androidjava/com.aspose.slides/protectionmanager/#isWriteProtected--) und [isEncrypted](https://reference.aspose.com/slides/androidjava/com.aspose.slides/protectionmanager/#isEncrypted--) zeigen tatsächliche Schreib‑ bzw. Lese‑Beschränkungen an, die von Passwörtern oder Verschlüsselung abhängen.