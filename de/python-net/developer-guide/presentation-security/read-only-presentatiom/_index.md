---
title: Nur-Lesen-Präsentation
type: docs
weight: 30
url: /python-net/read-only-presentation/
keywords: "Nur-Lesen-Einstellung, PowerPoint-Präsentation, Python, Aspose.Slides für Python über .NET"
description: "Nur-Lesen PowerPoint-Präsentation in Python"
---

In PowerPoint 2019 führte Microsoft die **Immer als Nur-Lesen öffnen**-Einstellung als eine der Optionen ein, die Benutzer verwenden können, um ihre Präsentationen zu schützen. Sie möchten diese Nur-Lesen-Einstellung verwenden, um eine Präsentation zu schützen, wenn

- Sie versehentliche Bearbeitungen verhindern und den Inhalt Ihrer Präsentation sicher aufbewahren möchten. 
- Sie die Personen darauf aufmerksam machen möchten, dass die von Ihnen bereitgestellte Präsentation die endgültige Version ist.

Nachdem Sie die **Immer als Nur-Lesen öffnen**-Option für eine Präsentation ausgewählt haben, sehen die Benutzer beim Öffnen der Präsentation die **Nur-Lesen**-Empfehlung und möglicherweise eine Nachricht in dieser Form: *Um versehentliche Änderungen zu verhindern, hat der Autor diese Datei als schreibgeschützt eingerichtet.*

Die Nur-Lesen-Empfehlung ist ein einfacher, aber effektiver Abschreckungsmechanismus, der das Bearbeiten verhindert, da die Benutzer eine Aufgabe ausführen müssen, um sie zu entfernen, bevor sie die Präsentation bearbeiten dürfen. Wenn Sie nicht möchten, dass Benutzer Änderungen an einer Präsentation vornehmen, und sie auf höfliche Weise darüber informieren möchten, könnte die Nur-Lesen-Empfehlung eine gute Option für Sie sein.

> Wenn eine Präsentation mit dem **Nur-Lesen**-Schutz in einer älteren Microsoft PowerPoint-Anwendung geöffnet wird—die die kürzlich eingeführte Funktion nicht unterstützt—wird die **Nur-Lesen**-Empfehlung ignoriert (die Präsentation wird normal geöffnet).

Aspose.Slides für Python über .NET ermöglicht es Ihnen, eine Präsentation als **Nur-Lesen** einzustellen, was bedeutet, dass die Benutzer (nachdem sie die Präsentation geöffnet haben) die **Nur-Lesen**-Empfehlung sehen. Dieser Beispielcode zeigt Ihnen, wie Sie eine Präsentation in Python mit Aspose.Slides als **Nur-Lesen** festlegen:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.read_only_recommended = True
    pres.save("ReadOnlyPresentation.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 

**Hinweis**: Die **Nur-Lesen**-Empfehlung soll einfach das Bearbeiten entmutigen oder Benutzer daran hindern, versehentliche Änderungen an einer PowerPoint-Präsentation vorzunehmen. Wenn eine motivierte Person—die weiß, was sie tut—beschließt, Ihre Präsentation zu bearbeiten, kann sie das Nur-Lesen-Attribut leicht entfernen. Wenn Sie ernsthaft unbefugtes Bearbeiten verhindern müssen, sind Sie besser beraten, [striktere Schutzmaßnahmen zu verwenden, die Verschlüsselungen und Passwörter umfassen](https://docs.aspose.com/slides/python-net/password-protected-presentation/). 

{{% /alert %}}