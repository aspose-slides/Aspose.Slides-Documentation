---
title: Nur-Lese-Präsentation
type: docs
weight: 30
url: /net/read-only-presentation/
keywords: "Nur-Lese-Einstellung, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Nur-Lese PowerPoint-Präsentation in C# oder .NET"
---

In PowerPoint 2019 führte Microsoft die Einstellung **Immer nur lesen öffnen** als eine der Optionen ein, die Benutzer verwenden können, um ihre Präsentationen zu schützen. Möglicherweise möchten Sie diese Nur-Lese-Einstellung verwenden, um eine Präsentation zu schützen, wenn

- Sie versehentliche Änderungen verhindern und den Inhalt Ihrer Präsentation sicher halten möchten.
- Sie die Menschen darauf hinweisen möchten, dass die bereitgestellte Präsentation die endgültige Version ist.

Nachdem Sie die Option **Immer nur lesen öffnen** für eine Präsentation ausgewählt haben, sehen Benutzer beim Öffnen der Präsentation die Empfehlung **Nur-Lese** und möglicherweise eine Nachricht in dieser Form: *Um versehentliche Änderungen zu verhindern, hat der Autor diese Datei auf schreibgeschützt eingestellt.*

Die Empfehlung Nur-Lese ist ein einfaches, aber effektives Mittel, um das Bearbeiten abzuschrecken, da die Benutzer eine Aufgabe durchführen müssen, um sie zu entfernen, bevor sie die Präsentation bearbeiten dürfen. Wenn Sie nicht möchten, dass Benutzer Änderungen an einer Präsentation vornehmen, und sie höflich darüber informieren möchten, ist die Empfehlung Nur-Lese möglicherweise eine gute Option für Sie.

> Wenn eine Präsentation mit dem Schutz **Nur-Lese** in einer älteren Version der Microsoft PowerPoint-Anwendung geöffnet wird—die die kürzlich eingeführte Funktion nicht unterstützt—wird die Empfehlung **Nur-Lese** ignoriert (die Präsentation wird normal geöffnet).

Aspose.Slides für .NET ermöglicht es Ihnen, eine Präsentation auf **Nur-Lese** einzustellen, was bedeutet, dass Benutzer (nachdem sie die Präsentation geöffnet haben) die Empfehlung **Nur-Lese** sehen. Dieser Beispielcode zeigt Ihnen, wie Sie eine Präsentation in C# mit Aspose.Slides auf **Nur-Lese** einstellen:

```c#
using (Presentation pres = new Presentation())
{
    pres.ProtectionManager.ReadOnlyRecommended = true;
    pres.Save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}} 

**Hinweis**: Die Empfehlung **Nur-Lese** soll lediglich das Bearbeiten ab discouragement oder verhindern, dass Benutzer versehentliche Änderungen an einer PowerPoint-Präsentation vornehmen. Wenn eine motivierte Person—die weiß, was sie tut—beschließt, Ihre Präsentation zu bearbeiten, kann sie die Nur-Lese-Einstellung leicht entfernen. Wenn Sie ernsthaft unbefugtes Bearbeiten verhindern müssen, sollten Sie [stringentere Schutzmaßnahmen verwenden, die Verschlüsselungen und Passwörter beinhalten](https://docs.aspose.com/slides/net/password-protected-presentation/). 

{{% /alert %}} 