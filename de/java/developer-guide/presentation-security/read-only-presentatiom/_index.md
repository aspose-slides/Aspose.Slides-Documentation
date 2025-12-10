---
title: Präsentationen im Nur-Lese-Modus mit Java speichern
linktitle: Nur-Lese-Präsentation
type: docs
weight: 30
url: /de/java/read-only-presentation/
keywords:
- nur lesen
- Präsentation schützen
- Bearbeitung verhindern
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "PowerPoint-Dateien (PPT, PPTX) im Nur-Lese-Modus mit Aspose.Slides für Java laden und speichern, um präzise Folienvorschauen zu erhalten, ohne Ihre Präsentationen zu verändern."
---

## **Read-Only-Modus anwenden**

In PowerPoint 2019 hat Microsoft die Einstellung **Always Open Read-Only** als eine der Optionen eingeführt, mit denen Benutzer ihre Präsentationen schützen können. Sie möchten diese Read-Only‑Einstellung möglicherweise verwenden, um eine Präsentation zu schützen, wenn

- Sie versehentliche Bearbeitungen verhindern und den Inhalt Ihrer Präsentation sicher halten wollen. 
- Sie den Empfängern signalisieren möchten, dass die von Ihnen bereitgestellte Präsentation die endgültige Version ist. 

Nachdem Sie die Option **Always Open Read-Only** für eine Präsentation ausgewählt haben, sehen Benutzer beim Öffnen der Präsentation die **Read-Only**‑Empfehlung und erhalten möglicherweise eine Meldung in etwa dieser Form: *Um versehentliche Änderungen zu verhindern, hat der Autor diese Datei zum Öffnen im Nur‑Lese‑Modus festgelegt.*

Die Read-Only‑Empfehlung ist ein einfacher, aber wirksamer Hinweis, der das Bearbeiten erschwert, weil Benutzer einen Vorgang ausführen müssen, um sie zu entfernen, bevor sie die Präsentation bearbeiten dürfen. Wenn Sie nicht möchten, dass Benutzer Änderungen an einer Präsentation vornehmen, und sie dies auf höfliche Weise kommunizieren wollen, kann die Read-Only‑Empfehlung eine gute Option für Sie sein. 

> Wird eine Präsentation mit **Read-Only**‑Schutz in einer älteren Microsoft‑PowerPoint‑Anwendung geöffnet – die die neu eingeführte Funktion nicht unterstützt – wird die **Read-Only**‑Empfehlung ignoriert (die Präsentation wird normal geöffnet).

Aspose.Slides for Java ermöglicht es Ihnen, eine Präsentation **Read-Only** zu setzen, sodass Benutzer (nachdem sie die Präsentation geöffnet haben) die **Read-Only**‑Empfehlung sehen. Dieser Beispielcode zeigt, wie Sie in Java mit Aspose.Slides eine Präsentation **Read-Only** setzen:
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

**Hinweis**: Die **Read-Only**‑Empfehlung soll lediglich das Bearbeiten erschweren oder Benutzer davon abhalten, versehentliche Änderungen an einer PowerPoint‑Präsentation vorzunehmen. Wenn eine motivierte Person — die genau weiß, was sie tut — beschließt, Ihre Präsentation zu bearbeiten, kann sie die Read‑Only‑Einstellung leicht entfernen. Wenn Sie wirklich verhindern müssen, dass unbefugte Änderungen vorgenommen werden, sollten Sie besser [striktere Schutzmaßnahmen, die Verschlüsselungen und Passwörter umfassen](https://docs.aspose.com/slides/java/password-protected-presentation/) verwenden. 

{{% /alert %}} 

## **FAQ**

**Worin unterscheidet sich „Read‑Only empfohlen“ von einem vollständigen Passwortschutz?**

„Read‑Only empfohlen“ zeigt lediglich einen Hinweis zum Öffnen der Datei im Nur‑Lese‑Modus an und ist leicht zu umgehen. [Passwortschutz](/slides/de/java/password-protected-presentation/) schränkt das Öffnen oder Bearbeiten tatsächlich ein und ist geeignet, wenn Sie echte Sicherheitskontrollen benötigen.

**Kann „Read‑Only empfohlen“ mit Wasserzeichen kombiniert werden, um Bearbeitungen weiter zu verhindern?**

Ja. Die Empfehlung kann mit [Wasserzeichen](/slides/de/java/watermark/) als visueller Hinweis kombiniert werden; beide Mechanismen sind getrennt und funktionieren gut zusammen.

**Kann ein Makro oder ein externes Tool die Datei trotzdem ändern, wenn die Empfehlung aktiviert ist?**

Ja. Die Empfehlung blockiert keine programmatischen Änderungen. Um automatisierte Bearbeitungen zu verhindern, verwenden Sie [Passwörter und Verschlüsselung](/slides/de/java/password-protected-presentation/).

**Wie verhält sich „Read‑Only empfohlen“ im Vergleich zu den Methoden „isEncrypted“ und „isWriteProtected“?**

Sie sind unterschiedliche Signale. „Read‑Only empfohlen“ ist ein weicher, optionaler Hinweis; [isWriteProtected](https://reference.aspose.com/slides/java/com.aspose.slides/protectionmanager/#isWriteProtected--) und [isEncrypted](https://reference.aspose.com/slides/java/com.aspose.slides/protectionmanager/#isEncrypted--) zeigen tatsächliche Schreib‑ bzw. Leseeinschränkungen an, die von Passwörtern oder Verschlüsselung abhängen.