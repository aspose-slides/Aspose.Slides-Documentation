---
title: Speichern von Präsentationen im Nur-Lese-Modus mit Python
linktitle: Nur-Lese-Präsentation
type: docs
weight: 30
url: /de/python-net/read-only-presentation/
keywords:
- nur lesend
- Präsentation schützen
- Bearbeitung verhindern
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Laden und speichern Sie PowerPoint-Dateien (PPT, PPTX) im Nur-Lese-Modus mit Aspose.Slides für Python via .NET, um präzise Folienvorschauen zu erhalten, ohne Ihre Präsentationen zu verändern."
---

## **Nur-Lese-Modus aktivieren**

Im PowerPoint 2019 hat Microsoft die Einstellung **Immer im Nur-Lese-Modus öffnen** eingeführt, die zu den Optionen gehört, mit denen Benutzer ihre Präsentationen schützen können. Sie möchten diese Nur-Lese-Einstellung verwenden, um eine Präsentation zu schützen, wenn

- Sie versehentliche Bearbeitungen verhindern und den Inhalt Ihrer Präsentation sicher halten möchten.  
- Sie die Personen darauf hinweisen möchten, dass die von Ihnen bereitgestellte Präsentation die endgültige Version ist.  

Nachdem Sie die Option **Immer im Nur-Lese-Modus öffnen** für eine Präsentation ausgewählt haben, sehen Benutzer beim Öffnen der Präsentation die **Nur-Lese**-Empfehlung und möglicherweise die folgende Meldung: *Um versehentliche Änderungen zu verhindern, hat der Autor diese Datei im Nur-Lese-Modus geöffnet.*

Die Nur-Lese-Empfehlung ist ein einfacher, aber wirksamer Abschreckungsmechanismus, der das Bearbeiten verhindert, weil Benutzer zuerst eine Aktion ausführen müssen, um sie zu entfernen, bevor sie die Präsentation bearbeiten dürfen. Wenn Sie nicht möchten, dass Benutzer Änderungen an einer Präsentation vornehmen, und dies höflich mitteilen wollen, kann die Nur-Lese-Empfehlung eine gute Option für Sie sein.

> Wird eine Präsentation mit dem **Nur-Lese**-Schutz in einer älteren Microsoft PowerPoint‑Anwendung geöffnet, die die kürzlich eingeführte Funktion nicht unterstützt, wird die **Nur-Lese**-Empfehlung ignoriert (die Präsentation wird normal geöffnet).

Aspose.Slides für Python via .NET ermöglicht es Ihnen, eine Präsentation auf **Nur-Lese** zu setzen, sodass Benutzer (nach dem Öffnen der Präsentation) die **Nur-Lese**-Empfehlung sehen. Der folgende Beispielcode zeigt, wie Sie eine Präsentation in Python mit Aspose.Slides auf **Nur-Lese** setzen:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.read_only_recommended = True
    pres.save("ReadOnlyPresentation.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 

**Hinweis**: Die **Nur-Lese**-Empfehlung soll lediglich das Bearbeiten oder versehentliche Änderungen an einer PowerPoint‑Präsentation abschrecken. Wenn eine motivierte Person – die weiß, was sie tut – Ihre Präsentation bearbeitet, kann sie die Nur-Lese‑Einstellung leicht entfernen. Wenn Sie wirklich unbefugte Bearbeitungen verhindern müssen, sollten Sie [strengere Schutzmaßnahmen, die Verschlüsselungen und Passwörter beinhalten](https://docs.aspose.com/slides/python-net/password-protected-presentation/) verwenden. 

{{% /alert %}} 

## **FAQ**

**Wie unterscheidet sich „Nur-Lese empfohlen“ von einem vollständigen Passwortschutz?**

„Nur-Lese empfohlen“ zeigt lediglich einen Vorschlag an, die Datei im Nur-Lese‑Modus zu öffnen und lässt sich leicht umgehen. [Passwortschutz](/slides/de/python-net/password-protected-presentation/) beschränkt tatsächlich das Öffnen oder Bearbeiten und ist geeignet, wenn Sie echte Sicherheitskontrollen benötigen.

**Kann „Nur-Lese empfohlen“ mit Wasserzeichen kombiniert werden, um Bearbeitungen weiter abzuschrecken?**

Ja. Die Empfehlung kann mit [Wasserzeichen](/slides/de/python-net/watermark/) als visueller Abschreckung kombiniert werden; sie sind separate Mechanismen und funktionieren gut zusammen.

**Kann ein Makro oder ein externes Tool die Datei dennoch ändern, wenn die Empfehlung aktiviert ist?**

Ja. Die Empfehlung blockiert keine programmgesteuerten Änderungen. Um automatisierte Bearbeitungen zu verhindern, verwenden Sie [Passwörter und Verschlüsselungen](/slides/de/python-net/password-protected-presentation/).

**Wie steht „Nur-Lese empfohlen“ im Zusammenhang mit den Flags „is_encrypted“ und „is_write_protected“?**

Sie sind unterschiedliche Signale. „Nur-Lese empfohlen“ ist ein weicher, optionaler Hinweis; [is_write_protected](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_write_protected/) und [is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_encrypted/) zeigen tatsächliche Schreib- bzw. Leseeinschränkungen, die von Passwörtern oder Verschlüsselungen abhängen.