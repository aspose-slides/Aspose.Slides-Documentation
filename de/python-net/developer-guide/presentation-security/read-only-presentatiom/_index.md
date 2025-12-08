---
title: Präsentationen im Nur-Lese-Modus mit Python speichern
linktitle: Nur-Lese-Präsentation
type: docs
weight: 30
url: /de/python-net/read-only-presentation/
keywords:
- nur lesen
- Präsentation schützen
- Bearbeitung verhindern
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Laden und Speichern von PowerPoint-Dateien (PPT, PPTX) im Nur-Lese-Modus mit Aspose.Slides für Python über .NET, das präzise Folienvorschauen ermöglicht, ohne Ihre Präsentationen zu verändern."
---

## **Lese-Only-Modus anwenden**

In PowerPoint 2019 hat Microsoft die Einstellung **Always Open Read-Only** eingeführt, die zu den Optionen gehört, mit denen Benutzer ihre Präsentationen schützen können. Sie möchten diese Lese-Only‑Einstellung verwenden, um eine Präsentation zu schützen, wenn

- Sie verhindern versehentliche Änderungen und halten den Inhalt Ihrer Präsentation sicher. 
- Sie möchten die Personen darauf hinweisen, dass die von Ihnen bereitgestellte Präsentation die endgültige Version ist. 

Nachdem Sie die Option **Always Open Read-Only** für eine Präsentation ausgewählt haben, sehen die Benutzer beim Öffnen der Präsentation die **Read-Only**‑Empfehlung und möglicherweise eine Meldung in folgender Form: *Um versehentliche Änderungen zu verhindern, hat der Autor diese Datei zum Öffnen im Nur-Lese-Modus festgelegt.*

Die **Read-Only**‑Empfehlung ist ein einfacher, aber wirksamer Abschreckungsmechanismus, der das Bearbeiten entmutigt, weil Benutzer eine Aufgabe ausführen müssen, um sie zu entfernen, bevor sie die Präsentation bearbeiten dürfen. Wenn Sie nicht möchten, dass Benutzer Änderungen an einer Präsentation vornehmen, und ihnen dies höflich mitteilen wollen, kann die **Read-Only**‑Empfehlung eine gute Option für Sie sein. 

> Wird eine Präsentation mit **Read-Only**‑Schutz in einer älteren Microsoft PowerPoint-Anwendung geöffnet, die die kürzlich eingeführte Funktion nicht unterstützt, wird die **Read-Only**‑Empfehlung ignoriert (die Präsentation wird normal geöffnet).

Aspose.Slides für Python über .NET ermöglicht es Ihnen, eine Präsentation auf **Read-Only** zu setzen, wodurch Benutzer (nach dem Öffnen der Präsentation) die **Read-Only**‑Empfehlung sehen. Dieser Beispielcode zeigt, wie Sie eine Präsentation in Python mit Aspose.Slides auf **Read-Only** setzen:
```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.read_only_recommended = True
    pres.save("ReadOnlyPresentation.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert color="primary" %}} 

**Hinweis**: Die **Read-Only**‑Empfehlung soll lediglich das Bearbeiten abschrecken oder Benutzer daran hindern, versehentliche Änderungen an einer PowerPoint-Präsentation vorzunehmen. Wenn eine motivierte Person – die weiß, was sie tut – entscheidet, Ihre Präsentation zu bearbeiten, kann sie die Read-Only‑Einstellung leicht entfernen. Wenn Sie tatsächlich unbefugtes Bearbeiten verhindern müssen, ist es besser, [striktere Schutzmaßnahmen zu verwenden, die Verschlüsselungen und Passwörter umfassen](https://docs.aspose.com/slides/python-net/password-protected-presentation/). 

{{% /alert %}} 

## **FAQ**

**Wie unterscheidet sich 'Read-Only empfohlen' von vollständigem Passwortschutz?**

'Read-Only recommended' zeigt lediglich einen Vorschlag an, die Datei im Nur-Lese-Modus zu öffnen, und lässt sich leicht umgehen. [Passwortschutz](/slides/de/python-net/password-protected-presentation/) beschränkt tatsächlich das Öffnen oder Bearbeiten und ist geeignet, wenn Sie echte Sicherheitskontrollen benötigen.

**Kann 'Read-Only empfohlen' mit Wasserzeichen kombiniert werden, um Bearbeitungen weiter abzuschrecken?**

Ja. Die Empfehlung kann mit [Wasserzeichen](/slides/de/python-net/watermark/) als visuellen Abschreckungsmechanismus kombiniert werden; sie sind separate Verfahren und funktionieren gut zusammen.

**Kann ein Makro oder externes Tool die Datei noch ändern, wenn die Empfehlung aktiviert ist?**

Ja. Die Empfehlung blockiert keine programmatischen Änderungen. Um automatisierte Bearbeitungen zu verhindern, verwenden Sie [Passwörter und Verschlüsselung](/slides/de/python-net/password-protected-presentation/).

**Wie steht 'Read-Only empfohlen' im Zusammenhang mit den Flags 'is_encrypted' und 'is_write_protected'?**

Sie sind unterschiedliche Signale. 'Read-Only empfohlen' ist ein weicher, optionaler Hinweis; [is_write_protected](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_write_protected/) und [is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_encrypted/) zeigen tatsächliche Schreib‑ bzw. Lese‑Beschränkungen an, die von Passwörtern oder Verschlüsselung abhängen.