---
title: Präsentationen im Nur-Lese-Modus mit C++ speichern
linktitle: Nur-Lese-Präsentation
type: docs
weight: 30
url: /de/cpp/read-only-presentation/
keywords:
- Nur lesen
- Präsentation schützen
- Bearbeitung verhindern
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Laden und Speichern von PowerPoint-Dateien (PPT, PPTX) im Nur-Lese-Modus mit Aspose.Slides für C++, das präzise Folienvorschauen ermöglicht, ohne Ihre Präsentationen zu ändern."
---
## **Einleitung**

In PowerPoint 2019 hat Microsoft die Einstellung **Always Open Read-Only** eingeführt, die zu den Optionen gehört, mit denen Benutzer ihre Präsentationen schützen können. Sie möchten diese Read‑Only‑Einstellung möglicherweise verwenden, um eine Präsentation zu schützen, wenn

- Sie versehentliche Änderungen verhindern und den Inhalt Ihrer Präsentation sicher aufbewahren wollen. 
- Sie die Empfänger darauf hinweisen möchten, dass die von Ihnen bereitgestellte Präsentation die Endversion ist. 

Nachdem Sie die Option **Always Open Read-Only** für eine Präsentation ausgewählt haben, sehen die Benutzer beim Öffnen der Präsentation die **Read‑Only**‑Empfehlung und erhalten möglicherweise eine Meldung in folgender Form: *To prevent accidental changes, the author has set this file to open as read-only.*

Die Read‑Only‑Empfehlung ist ein einfacher, aber wirksamer Hinweis, der das Bearbeiten erschwert, weil Benutzer erst einen Vorgang ausführen müssen, um die Empfehlung zu entfernen, bevor sie die Präsentation bearbeiten dürfen. Wenn Sie nicht möchten, dass Benutzer Änderungen an einer Präsentation vornehmen, und dies auf höfliche Weise mitteilen wollen, kann die Read‑Only‑Empfehlung eine gute Option für Sie sein. 

> Wenn eine Präsentation mit dem **Read‑Only**‑Schutz in einer älteren Microsoft PowerPoint‑Anwendung geöffnet wird – die die kürzlich eingeführte Funktion nicht unterstützt – wird die **Read‑Only**‑Empfehlung ignoriert (die Präsentation wird normal geöffnet).

## **Read‑Only‑Modus anwenden**

Aspose.Slides für C++ ermöglicht es Ihnen, eine Präsentation **Read‑Only** zu setzen, sodass die Benutzer (nachdem sie die Präsentation geöffnet haben) die **Read‑Only**‑Empfehlung sehen. Dieser Beispielcode zeigt, wie Sie eine Präsentation in C++ mit Aspose.Slides **Read‑Only** setzen:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
pres->get_ProtectionManager()->set_ReadOnlyRecommended(true);
pres->Save(u"ReadOnlyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert color="info" %}} 

**Hinweis**: Die **Read‑Only**‑Empfehlung soll lediglich das Bearbeiten entmutigen oder verhindern, dass Benutzer versehentliche Änderungen an einer PowerPoint‑Präsentation vornehmen. Wenn eine motivierte Person – die weiß, was sie tut – Ihre Präsentation bearbeitet, kann sie die Read‑Only‑Einstellung leicht entfernen. Wenn Sie wirklich unbefugtes Bearbeiten verhindern müssen, sollten Sie [more stringent protections that involve encryptions and passwords](https://docs.aspose.com/slides/de/cpp/password-protected-presentation/). 

{{% /alert %}} 

## **FAQ**

### Wie unterscheidet sich „Read‑Only empfohlen“ von einem vollständigen Passwortschutz?

„Read‑Only empfohlen“ zeigt nur einen Hinweis an, die Datei im Nur‑Lese‑Modus zu öffnen, und lässt sich leicht umgehen. [Password protection](/slides/de/cpp/password-protected-presentation/) schränkt das Öffnen oder Bearbeiten tatsächlich ein und ist geeignet, wenn Sie echte Sicherheitskontrollen benötigen.

### Kann „Read‑Only empfohlen“ mit Wasserzeichen kombiniert werden, um Bearbeitungen weiter zu entmutigen?

Ja. Die Empfehlung kann mit [watermarks](/slides/de/cpp/watermark/) als visueller Abschreckungsmechanismus kombiniert werden; beide Verfahren arbeiten unabhängig voneinander und ergänzen sich gut.

### Kann ein Makro oder ein externes Tool die Datei trotzdem ändern, wenn die Empfehlung aktiviert ist?

Ja. Die Empfehlung blockiert keine programmatischen Änderungen. Um automatisierte Bearbeitungen zu verhindern, verwenden Sie [passwords and encryption](/slides/de/cpp/password-protected-presentation/).

### Wie steht „Read‑Only empfohlen“ im Zusammenhang mit den Flags „is encrypted“ und „is write protected“?

Sie sind unterschiedliche Signale. „Read‑Only empfohlen“ ist ein weicher, optionaler Hinweis; [get_IsWriteProtected](https://reference.aspose.com/slides/de/cpp/aspose.slides/protectionmanager/get_iswriteprotected/) und [get_IsEncrypted](https://reference.aspose.com/slides/de/cpp/aspose.slides/protectionmanager/get_isencrypted/) zeigen tatsächliche Schreib‑ bzw. Lesebeschränkungen, die von Passwörtern oder Verschlüsselungen abhängen.