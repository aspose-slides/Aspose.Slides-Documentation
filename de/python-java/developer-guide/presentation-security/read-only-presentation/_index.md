---
title: Präsentationen im Nur-Lese-Modus mit Python speichern
linktitle: Nur-Lese-Präsentation
type: docs
weight: 30
url: /de/python-java/read-only-presentation/
keywords:
- nur lesen
- Präsentation schützen
- Bearbeitung verhindern
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Laden und speichern Sie PowerPoint‑Dateien (PPT, PPTX) im Nur-Lese‑Modus mit Aspose.Slides für Python via Java, wodurch präzise Folienvorschauen ermöglicht werden, ohne Ihre Präsentationen zu verändern."
---
## **Einführung**

In PowerPoint 2019 hat Microsoft die Einstellung **Always Open Read-Only** eingeführt, die zu den Optionen gehört, die Benutzer zum Schutz ihrer Präsentationen verwenden können. Sie können diese Read-Only‑Einstellung zum Schutz einer Präsentation verwenden, wenn:

- Sie versehentliche Änderungen verhindern und den Inhalt Ihrer Präsentation sicher behalten möchten. 
- Sie die Empfänger darauf hinweisen möchten, dass die bereitgestellte Präsentation die endgültige Version ist. 

Nachdem Sie die Option **Always Open Read-Only** für eine Präsentation ausgewählt haben, sehen Benutzer beim Öffnen der Präsentation die **Read-Only**‑Empfehlung und möglicherweise eine Meldung in etwa folgender Form: *Um versehentliche Änderungen zu verhindern, hat der Autor diese Datei zum Öffnen im Nur-Lese‑Modus festgelegt.*

Die **Read-Only**‑Empfehlung ist ein einfacher, aber wirksamer Abschreckungsmechanismus, der das Bearbeiten verhindert, da die Benutzer eine Aufgabe ausführen müssen, um sie zu entfernen, bevor sie die Präsentation bearbeiten dürfen. Wenn Sie nicht möchten, dass Benutzer Änderungen an einer Präsentation vornehmen, und dies höflich mitteilen möchten, kann die **Read-Only**‑Empfehlung für Sie eine gute Option sein. 

> Wird eine Präsentation mit dem **Read-Only**‑Schutz in einer älteren Microsoft‑PowerPoint‑Anwendung geöffnet – die die kürzlich eingeführte Funktion nicht unterstützt – wird die **Read-Only**‑Empfehlung ignoriert (die Präsentation wird normal geöffnet).

## **Read‑Only‑Modus anwenden**

Aspose.Slides für Python via Java ermöglicht es Ihnen, eine Präsentation auf **Read-Only** zu setzen, was bedeutet, dass Benutzer (nachdem sie die Präsentation geöffnet haben) die **Read-Only**‑Empfehlung sehen. Dieser Beispielcode zeigt, wie Sie eine Präsentation in Python mit Aspose.Slides auf **Read-Only** setzen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getProtectionManager().setReadOnlyRecommended(True)
    presentation.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 

Die **Read-Only**‑Empfehlung soll einfach das Bearbeiten verhindern oder Benutzer davon abhalten, versehentliche Änderungen an einer PowerPoint‑Präsentation vorzunehmen. Wenn eine motivierte Person – die weiß, was sie tut – Ihre Präsentation bearbeitet, kann sie die **Read-Only**‑Einstellung leicht entfernen. Wenn Sie unbefugtes Bearbeiten wirklich verhindern müssen, sollten Sie besser [strengere Schutzmaßnahmen, die Verschlüsselung und Passwörter umfassen](/slides/de/python-java/password-protected-presentation/). 

{{% /alert %}} 

## **FAQ**

**Wie unterscheidet sich 'Read-Only recommended' von einem vollständigen Passwortschutz?**  
'Read-Only recommended' zeigt nur einen Vorschlag an, die Datei im Nur-Lese‑Modus zu öffnen, und lässt sich leicht umgehen. [Passwortschutz](/slides/de/python-java/password-protected-presentation/) beschränkt tatsächlich das Öffnen oder Bearbeiten und ist geeignet, wenn Sie echte Sicherheitskontrollen benötigen.

**Kann 'Read-Only recommended' mit Wasserzeichen kombiniert werden, um Änderungen weiter zu verhindern?**  
Ja. Die Empfehlung kann mit [Wasserzeichen](/slides/de/python-java/watermark/) kombiniert werden, um einen visuellen Abschreckungseffekt zu erzeugen; sie sind separate Mechanismen und funktionieren gut zusammen.

**Kann ein Makro oder ein externes Tool die Datei noch ändern, wenn die Empfehlung aktiviert ist?**  
Ja. Die Empfehlung blockiert keine programmatischen Änderungen. Um automatisierte Bearbeitungen zu verhindern, verwenden Sie [Passwörter und Verschlüsselung](/slides/de/python-java/password-protected-presentation/).

**Wie steht 'Read-Only recommended' im Zusammenhang mit den Methoden [isEncrypted](https://reference.aspose.com/slides/de/python-java/aspose.slides/protectionmanager/#isEncrypted) und [isWriteProtected](https://reference.aspose.com/slides/de/python-java/aspose.slides/protectionmanager/#isWriteProtected)?**  
Sie sind unterschiedliche Signale. 'Read-Only recommended' ist ein weicher, optionaler Hinweis; [isWriteProtected](https://reference.aspose.com/slides/de/python-java/aspose.slides/protectionmanager/#isWriteProtected) und [isEncrypted](https://reference.aspose.com/slides/de/python-java/aspose.slides/protectionmanager/#isEncrypted) zeigen tatsächliche Schreib‑ oder Lese‑Beschränkungen an, die von Passwörtern oder Verschlüsselung abhängen.