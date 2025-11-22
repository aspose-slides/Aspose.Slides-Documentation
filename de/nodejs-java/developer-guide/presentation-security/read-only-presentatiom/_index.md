---
title: Nur-Lese-Präsentation
type: docs
weight: 30
url: /de/nodejs-java/read-only-presentation/
---

## **Read-Only-Modus anwenden**

In PowerPoint 2019 hat Microsoft die Einstellung **Always Open Read-Only** als eine der Optionen eingeführt, mit denen Benutzer ihre Präsentationen schützen können. Sie möchten diese Read-Only‑Einstellung eventuell verwenden, um eine Präsentation zu schützen, wenn

- Sie zufällige Änderungen verhindern und den Inhalt Ihrer Präsentation sicher aufbewahren wollen.  
- Sie die Empfänger darauf hinweisen möchten, dass die von Ihnen bereitgestellte Präsentation die endgültige Version ist.  

Nachdem Sie die Option **Always Open Read-Only** für eine Präsentation ausgewählt haben, sehen die Benutzer beim Öffnen der Präsentation die **Read-Only**‑Empfehlung und möglicherweise eine Meldung dieser Form: *Um versehentliche Änderungen zu verhindern, hat der Autor diese Datei so eingestellt, dass sie im Nur‑Lese‑Modus geöffnet wird.*

Die Read-Only‑Empfehlung ist ein einfacher, aber effektiver Hinweis, der das Bearbeiten entmutigt, weil die Benutzer eine Aufgabe ausführen müssen, um sie zu entfernen, bevor ihnen das Bearbeiten der Präsentation erlaubt wird. Wenn Sie nicht möchten, dass Benutzer Änderungen an einer Präsentation vornehmen, und sie darüber höflich informieren wollen, kann die Read-Only‑Empfehlung eine gute Option für Sie sein.

> Wird eine Präsentation mit dem **Read-Only**‑Schutz in einer älteren Microsoft‑PowerPoint‑Anwendung geöffnet – die die neu eingeführte Funktion nicht unterstützt – wird die **Read-Only**‑Empfehlung ignoriert (die Präsentation wird normal geöffnet).

Aspose.Slides for Node.js via Java ermöglicht es Ihnen, eine Präsentation **Read-Only** zu setzen, d. h. die Benutzer sehen (nach dem Öffnen) die **Read-Only**‑Empfehlung. Dieser Beispielcode zeigt, wie Sie eine Präsentation **Read-Only** in JavaScript mit Aspose.Slides festlegen:
```javascript
var pres = new aspose.slides.Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" %}} 

**Hinweis**: Die **Read-Only**‑Empfehlung soll lediglich das Bearbeiten oder versehentliche Änderungen einer PowerPoint‑Präsentation entmutigen. Wenn eine motivierte Person – die genau weiß, was sie tut – beschließt, Ihre Präsentation zu bearbeiten, kann sie die Read-Only‑Einstellung leicht entfernen. Wenn Sie wirklich unbefugtes Bearbeiten verhindern müssen, sollten Sie [strengere Schutzmaßnahmen, die Verschlüsselungen und Passwörter umfassen](https://docs.aspose.com/slides/nodejs-java/password-protected-presentation/) verwenden.

{{% /alert %}} 

## **FAQ**

**Worin unterscheidet sich „Read-Only empfohlen“ von einem vollständigen Passwortschutz?**

„Read-Only empfohlen“ zeigt nur einen Hinweis an, die Datei im Nur‑Lese‑Modus zu öffnen, und lässt sich leicht umgehen. [Passwortschutz](/slides/de/nodejs-java/password-protected-presentation/) hingegen beschränkt das Öffnen oder Bearbeiten und ist geeignet, wenn Sie echte Sicherheitskontrollen benötigen.

**Kann „Read-Only empfohlen“ mit Wasserzeichen kombiniert werden, um Bearbeitungen weiter zu entmutigen?**

Ja. Die Empfehlung kann mit [Wasserzeichen](/slides/de/nodejs-java/watermark/) als visuellen Abschreckungsmechanismus kombiniert werden; beide Verfahren arbeiten getrennt, ergänzen sich jedoch gut.

**Kann ein Makro oder ein externes Tool die Datei weiterhin ändern, wenn die Empfehlung aktiviert ist?**

Ja. Die Empfehlung blockiert keine programmgesteuerten Änderungen. Um automatisierte Bearbeitungen zu verhindern, verwenden Sie [Passwörter und Verschlüsselung](/slides/de/nodejs-java/password-protected-presentation/).

**Wie steht „Read-Only empfohlen“ im Zusammenhang mit den Flags „IsEncrypted“ und „IsWriteProtected“?**

Sie sind unterschiedliche Signale. „Read-Only empfohlen“ ist ein weicher, optionaler Hinweis; [isWriteProtected](https://reference.aspose.com/slides/nodejs-java/aspose.slides/protectionmanager/iswriteprotected/) und [isEncrypted](https://reference.aspose.com/slides/nodejs-java/aspose.slides/protectionmanager/isencrypted/) zeigen tatsächliche Schreib‑ bzw. Leseeinschränkungen an, die von Passwörtern oder Verschlüsselung abhängen.