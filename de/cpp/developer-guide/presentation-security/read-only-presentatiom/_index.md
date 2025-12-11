---
title: Präsentationen im Nur-Lese-Modus mit C++ speichern
linktitle: Nur-Lese-Präsentation
type: docs
weight: 30
url: /de/cpp/read-only-presentation/
keywords:
- nur lesbar
- Präsentation schützen
- Bearbeitung verhindern
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Laden und speichern Sie PowerPoint-Dateien (PPT, PPTX) im Nur-Lese-Modus mit Aspose.Slides für C++, um präzise Folienvorschauen zu erhalten, ohne Ihre Präsentationen zu verändern."
---

## **Read-Only‑Modus anwenden**

In PowerPoint 2019 hat Microsoft die Einstellung **Always Open Read-Only** als eine der Optionen eingeführt, mit denen Benutzer ihre Präsentationen schützen können. Sie möchten diese Read‑Only‑Einstellung vielleicht verwenden, um eine Präsentation zu schützen, wenn

- Sie versehentliche Änderungen verhindern und den Inhalt Ihrer Präsentation sicher halten wollen.  
- Sie die Empfänger darauf hinweisen möchten, dass die von Ihnen bereitgestellte Präsentation die endgültige Version ist.

Nachdem Sie die Option **Always Open Read-Only** für eine Präsentation ausgewählt haben, sehen die Benutzer beim Öffnen der Präsentation die **Read‑Only**‑Empfehlung und möglicherweise eine Meldung in etwa dieser Form: *Um versehentliche Änderungen zu verhindern, hat der Autor diese Datei als read‑only festgelegt.*

Die Read‑Only‑Empfehlung ist ein einfacher, aber wirksamer Abschreckungsmechanismus, der das Bearbeiten verhindert, weil die Benutzer einen Vorgang ausführen müssen, um sie zu entfernen, bevor sie die Präsentation bearbeiten dürfen. Wenn Sie nicht möchten, dass Benutzer Änderungen an einer Präsentation vornehmen, und dies auf höfliche Weise kommunizieren wollen, ist die Read‑Only‑Empfehlung eine gute Option für Sie.

> Wird eine Präsentation mit dem **Read‑Only**‑Schutz in einer älteren Microsoft‑PowerPoint‑Anwendung geöffnet – die die kürzlich eingeführte Funktion nicht unterstützt – wird die **Read‑Only**‑Empfehlung ignoriert (die Präsentation wird normal geöffnet).

Aspose.Slides für C++ ermöglicht es Ihnen, eine Präsentation auf **Read‑Only** zu setzen, sodass die Benutzer (nach dem Öffnen der Präsentation) die **Read‑Only**‑Empfehlung sehen. Dieser Beispielcode zeigt, wie Sie in C++ mit Aspose.Slides eine Präsentation auf **Read‑Only** setzen:
``` cpp
auto pres = System::MakeObject<Presentation>();
pres->get_ProtectionManager()->set_ReadOnlyRecommended(true);
pres->Save(u"ReadOnlyPresentation.pptx", SaveFormat::Pptx);
```


{{% alert color="primary" %}} 

**Hinweis**: Die **Read‑Only**‑Empfehlung soll lediglich dazu dienen, das Bearbeiten zu entmutigen oder Benutzer davon abzuhalten, versehentliche Änderungen an einer PowerPoint‑Präsentation vorzunehmen. Wenn eine motivierte Person – die weiß, was sie tut – beschließt, Ihre Präsentation zu bearbeiten, kann sie die Read‑Only‑Einstellung leicht entfernen. Wenn Sie wirklich verhindern müssen, dass unbefugte Änderungen vorgenommen werden, sollten Sie **strengere Schutzmaßnahmen, die Verschlüsselungen und Passwörter beinhalten** verwenden: [more stringent protections that involve encryptions and passwords](https://docs.aspose.com/slides/cpp/password-protected-presentation/). 

{{% /alert %}} 

## **FAQ**

**Wie unterscheidet sich „Read‑Only empfohlen“ von einem vollständigen Passwortschutz?**

„Read‑Only empfohlen“ zeigt nur einen Hinweis an, die Datei im Nur‑Lese‑Modus zu öffnen, und ist leicht zu umgehen. **Password protection** (**Passwortschutz**) ([Password protection](/slides/de/cpp/password-protected-presentation/)) schränkt das Öffnen oder Bearbeiten tatsächlich ein und ist geeignet, wenn Sie echte Sicherheitskontrollen benötigen.

**Kann „Read‑Only empfohlen“ mit Wasserzeichen kombiniert werden, um Bearbeitungen weiter zu erschweren?**

Ja. Die Empfehlung kann zusammen mit **watermarks** (**Wasserzeichen**) ([watermarks](/slides/de/cpp/watermark/)) als visueller Abschreckungsmechanismus verwendet werden; sie sind separate Mechanismen und funktionieren gut zusammen.

**Kann ein Makro oder ein externes Tool die Datei weiterhin ändern, wenn die Empfehlung aktiviert ist?**

Ja. Die Empfehlung blockiert keine programmatischen Änderungen. Um automatisierte Bearbeitungen zu verhindern, verwenden Sie **passwords and encryption** (**Passwörter und Verschlüsselung**) ([passwords and encryption](/slides/de/cpp/password-protected-presentation/)).

**Wie steht „Read‑Only empfohlen“ im Zusammenhang mit den Flags „is encrypted“ und „is write protected“?**

Sie sind unterschiedliche Signale. „Read‑Only empfohlen“ ist ein weicher, optionaler Hinweis; **get_IsWriteProtected** ([get_IsWriteProtected](https://reference.aspose.com/slides/cpp/aspose.slides/protectionmanager/get_iswriteprotected/)) und **get_IsEncrypted** ([get_IsEncrypted](https://reference.aspose.com/slides/cpp/aspose.slides/protectionmanager/get_isencrypted/)) zeigen tatsächliche Schreib‑ bzw. Lese‑Einschränkungen an, die von Passwörtern oder Verschlüsselungen abhängen.