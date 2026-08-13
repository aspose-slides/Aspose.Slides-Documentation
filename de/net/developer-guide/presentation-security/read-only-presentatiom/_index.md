---
title: Präsentationen im Nur-Lese-Modus in .NET speichern
linktitle: Nur-Lese-Präsentation
type: docs
weight: 30
url: /de/net/read-only-presentation/
keywords:
- Nur-Lesen
- Präsentation schützen
- Bearbeitung verhindern
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Laden und speichern Sie PowerPoint-Dateien (PPT, PPTX) im Nur-Lese-Modus mit Aspose.Slides für .NET, wobei präzise Folienvorschauen bereitgestellt werden, ohne Ihre Präsentationen zu ändern."
---
## **Einleitung**

In PowerPoint 2019 hat Microsoft die Einstellung **Always Open Read-Only** eingeführt, die eine der Optionen ist, die Benutzer zum Schutz ihrer Präsentationen verwenden können. Sie möchten diese Read-Only‑Einstellung zum Schutz einer Präsentation verwenden, wenn

- Sie möchten versehentliche Änderungen verhindern und den Inhalt Ihrer Präsentation sicher aufbewahren. 
- Sie möchten die Personen darauf hinweisen, dass die von Ihnen bereitgestellte Präsentation die endgültige Version ist. 

Nachdem Sie die Option **Always Open Read-Only** für eine Präsentation ausgewählt haben, sehen die Benutzer beim Öffnen der Präsentation die **Read-Only**‑Empfehlung und möglicherweise eine Meldung in dieser Form: *Um versehentliche Änderungen zu verhindern, hat der Autor diese Datei so eingestellt, dass sie schreibgeschützt geöffnet wird.*

Die **Read-Only**‑Empfehlung ist ein einfacher, aber wirkungsvoller Abschreckungsmechanismus, der das Bearbeiten verhindert, weil Benutzer eine Aufgabe ausführen müssen, um sie zu entfernen, bevor sie die Präsentation bearbeiten dürfen. Wenn Sie nicht möchten, dass Benutzer Änderungen an einer Präsentation vornehmen und dies höflich mitteilen wollen, kann die **Read-Only**‑Empfehlung eine gute Option für Sie sein. 

> Wenn eine Präsentation mit dem **Read-Only**‑Schutz in einer älteren Microsoft‑PowerPoint‑Anwendung geöffnet wird – die die kürzlich eingeführte Funktion nicht unterstützt – wird die **Read-Only**‑Empfehlung ignoriert (die Präsentation wird normal geöffnet).

## **Read-Only‑Modus anwenden**

Aspose.Slides für .NET ermöglicht es Ihnen, eine Präsentation auf **Read-Only** zu setzen, sodass Benutzer (nachdem sie die Präsentation geöffnet haben) die **Read-Only**‑Empfehlung sehen. Dieser Beispielcode zeigt, wie Sie eine Präsentation in C# mit Aspose.Slides auf **Read-Only** setzen:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    pres.ProtectionManager.ReadOnlyRecommended = true;
    pres.Save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}} 

**Hinweis**: Die **Read-Only**‑Empfehlung soll lediglich das Bearbeiten verhindern bzw. Benutzer davon abhalten, versehentliche Änderungen an einer PowerPoint‑Präsentation vorzunehmen. Wenn eine motivierte Person – die weiß, was sie tut – beschließt, Ihre Präsentation zu bearbeiten, kann sie die Read‑Only‑Einstellung leicht entfernen. Wenn Sie wirklich verhindern müssen, dass Unbefugte Änderungen vornehmen, sollten Sie besser [strengere Schutzmaßnahmen verwenden, die Verschlüsselungen und Passwörter beinhalten](https://docs.aspose.com/slides/de/net/password-protected-presentation/). 

{{% /alert %}} 

## **FAQ**

### Wie unterscheidet sich 'Read-Only recommended' von einem vollständigen Passwortschutz?

'Read-Only recommended' zeigt lediglich einen Hinweis, die Datei im schreibgeschützten Modus zu öffnen, und ist leicht zu umgehen. [Passwortschutz](/slides/de/net/password-protected-presentation/) beschränkt tatsächlich das Öffnen oder Bearbeiten und ist geeignet, wenn Sie echte Sicherheitskontrollen benötigen.

### Kann 'Read-Only recommended' mit Wasserzeichen kombiniert werden, um das Bearbeiten weiter zu entmutigen?

Ja. Die Empfehlung kann zusammen mit [Wasserzeichen](/slides/de/net/watermark/) als visueller Abschreckungsmechanismus verwendet werden; sie sind separate Mechanismen und funktionieren gut zusammen.

### Kann ein Makro oder ein externes Tool die Datei trotzdem ändern, wenn die Empfehlung aktiviert ist?

Ja. Die Empfehlung blockiert keine programmatischen Änderungen. Um automatisierte Änderungen zu verhindern, verwenden Sie [Passwörter und Verschlüsselung](/slides/de/net/password-protected-presentation/).

### Wie steht 'Read-Only recommended' im Zusammenhang mit den Flags 'IsEncrypted' und 'IsWriteProtected'?

Sie sind unterschiedliche Signale. 'Read-Only recommended' ist ein weicher, optionaler Hinweis; [IsWriteProtected](https://reference.aspose.com/slides/de/net/aspose.slides/protectionmanager/iswriteprotected/) und [IsEncrypted](https://reference.aspose.com/slides/de/net/aspose.slides/protectionmanager/isencrypted/) zeigen tatsächliche Schreib‑ bzw. Lese‑Einschränkungen an, die von Passwörtern oder Verschlüsselung abhängen.