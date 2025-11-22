---
title: Nur-Lesen-Präsentation
type: docs
weight: 30
url: /de/net/read-only-presentation/
keywords: "Nur-Lesen-Einstellung, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides for .NET"
description: "Nur-Lesen-PowerPoint-Präsentation in C# oder .NET"
---

## **Read-Only-Modus aktivieren**

In PowerPoint 2019 hat Microsoft die Einstellung **Always Open Read-Only** als eine der Optionen eingeführt, die Benutzer verwenden können, um ihre Präsentationen zu schützen. Sie möchten diese Read-Only-Einstellung zum Schutz einer Präsentation verwenden, wenn

- Sie möchten versehentliche Änderungen verhindern und den Inhalt Ihrer Präsentation sicher halten. 
- Sie möchten Personen darauf hinweisen, dass die von Ihnen bereitgestellte Präsentation die Endversion ist. 

Nachdem Sie die Option **Always Open Read-Only** für eine Präsentation ausgewählt haben, sehen Benutzer beim Öffnen der Präsentation die **Read-Only**-Empfehlung und möglicherweise eine Meldung in dieser Form: *Um versehentliche Änderungen zu verhindern, hat der Autor diese Datei so eingestellt, dass sie im Read-Only‑Modus geöffnet wird.*

Die **Read-Only**-Empfehlung ist ein einfacher, aber wirksamer Abschreckungsmechanismus, der das Bearbeiten entmutigt, weil Benutzer eine Aufgabe ausführen müssen, um sie zu entfernen, bevor sie eine Präsentation bearbeiten dürfen. Wenn Sie nicht möchten, dass Benutzer Änderungen an einer Präsentation vornehmen, und dies auf höfliche Weise mitteilen möchten, kann die **Read-Only**-Empfehlung eine gute Option für Sie sein. 

> Wenn eine Präsentation mit dem **Read-Only**‑Schutz in einer älteren Microsoft PowerPoint‑Anwendung geöffnet wird – die die kürzlich eingeführte Funktion nicht unterstützt – wird die **Read-Only**‑Empfehlung ignoriert (die Präsentation wird normal geöffnet).

Aspose.Slides für .NET ermöglicht es Ihnen, eine Präsentation auf **Read-Only** zu setzen, was bedeutet, dass Benutzer (nachdem sie die Präsentation geöffnet haben) die **Read-Only**-Empfehlung sehen. Dieser Beispielcode zeigt, wie Sie eine Präsentation in C# mit Aspose.Slides auf **Read-Only** setzen:
```c#
using (Presentation pres = new Presentation())
{
    pres.ProtectionManager.ReadOnlyRecommended = true;
    pres.Save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
}
```


{{% alert color="primary" %}} 

**Hinweis**: Die **Read-Only**-Empfehlung soll lediglich das Bearbeiten entmutigen oder Benutzer davon abhalten, versehentliche Änderungen an einer PowerPoint‑Präsentation vorzunehmen. Wenn eine motivierte Person – die weiß, was sie tut – entscheidet, Ihre Präsentation zu bearbeiten, kann sie die Read-Only‑Einstellung leicht entfernen. Wenn Sie das unerlaubte Bearbeiten ernsthaft verhindern müssen, ist es besser, [strengere Schutzmaßnahmen zu verwenden, die Verschlüsselungen und Passwörter beinhalten](https://docs.aspose.com/slides/net/password-protected-presentation/). 

{{% /alert %}} 

## **FAQ**

**Wie unterscheidet sich „Read-Only recommended“ von einem vollständigen Passwortschutz?**

„Read-Only recommended“ zeigt nur einen Vorschlag an, die Datei im Read‑Only‑Modus zu öffnen, und lässt sich leicht umgehen. [Passwortschutz](/slides/de/net/password-protected-presentation/) schränkt das Öffnen oder Bearbeiten tatsächlich ein und ist geeignet, wenn Sie echte Sicherheitskontrollen benötigen.

**Kann „Read-Only recommended“ mit Wasserzeichen kombiniert werden, um Änderungen weiter zu entmutigen?**

Ja. Die Empfehlung kann mit [Wasserzeichen](/slides/de/net/watermark/) als visueller Abschreckungsmechanismus kombiniert werden; sie sind separate Mechanismen und funktionieren gut zusammen.

**Kann ein Makro oder ein externes Tool die Datei trotzdem ändern, wenn die Empfehlung aktiviert ist?**

Ja. Die Empfehlung blockiert keine programmgesteuerten Änderungen. Um automatisierte Änderungen zu verhindern, verwenden Sie [Passwörter und Verschlüsselung](/slides/de/net/password-protected-presentation/).

**Wie steht „Read-Only recommended“ im Zusammenhang mit den Flags „IsEncrypted“ und „IsWriteProtected“?**

Sie sind unterschiedliche Signale. „Read-Only recommended“ ist ein weicher, optionaler Hinweis; [IsWriteProtected](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/iswriteprotected/) und [IsEncrypted](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/isencrypted/) zeigen tatsächliche Schreib‑ bzw. Lesebeschränkungen an, die von Passwörtern oder Verschlüsselung abhängen.