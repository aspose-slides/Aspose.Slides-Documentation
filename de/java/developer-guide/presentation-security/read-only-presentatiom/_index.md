---
title: Nur-Lese-Präsentation
type: docs
weight: 30
url: /de/java/read-only-presentation/

---

In PowerPoint 2019 führte Microsoft die Einstellung **Immer als Nur-Lese** ein, die eine der Optionen ist, die Benutzer zum Schutz ihrer Präsentationen verwenden können. Sie möchten diese Nur-Lese-Einstellung möglicherweise verwenden, um eine Präsentation zu schützen, wenn

- Sie versehentliche Bearbeitungen verhindern und den Inhalt Ihrer Präsentation sicher halten möchten.
- Sie die Personen darüber informieren möchten, dass die von Ihnen bereitgestellte Präsentation die endgültige Version ist.

Nachdem Sie die Option **Immer als Nur-Lese** für eine Präsentation ausgewählt haben, sehen Benutzer beim Öffnen der Präsentation die Empfehlung **Nur-Lese** und möglicherweise eine Nachricht in folgender Form: *Um versehentliche Änderungen zu verhindern, hat der Autor diese Datei so eingestellt, dass sie als nur lesbar geöffnet wird.*

Die Empfehlung **Nur-Lese** ist ein einfaches, aber effektives Abschreckungsmittel, das Bearbeitungen entmutigt, da Benutzer eine Aufgabe ausführen müssen, um sie zu entfernen, bevor sie berechtigt sind, eine Präsentation zu bearbeiten. Wenn Sie nicht möchten, dass Benutzer Änderungen an einer Präsentation vornehmen und ihnen dies auf höfliche Weise mitteilen möchten, könnte die Empfehlung **Nur-Lese** eine gute Option für Sie sein.

> Wenn eine Präsentation mit dem Schutz **Nur-Lese** in einer älteren Microsoft PowerPoint-Anwendung geöffnet wird—die die kürzlich eingeführte Funktion nicht unterstützt—wird die Empfehlung **Nur-Lese** ignoriert (die Präsentation wird normal geöffnet).

Aspose.Slides für Java ermöglicht es Ihnen, eine Präsentation auf **Nur-Lese** zu setzen, was bedeutet, dass Benutzer (nachdem sie die Präsentation geöffnet haben) die Empfehlung **Nur-Lese** sehen. Dieser Beispielcode zeigt Ihnen, wie Sie eine Präsentation in Java mit Aspose.Slides auf **Nur-Lese** setzen:

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

**Hinweis**: Die Empfehlung **Nur-Lese** soll lediglich dazu dienen, Bearbeitungen abzuraten oder Benutzer daran zu hindern, versehentliche Änderungen an einer PowerPoint-Präsentation vorzunehmen. Wenn eine motivierte Person—die weiß, was sie tut—beschließt, Ihre Präsentation zu bearbeiten, kann sie die Nur-Lese-Einstellung leicht entfernen. Wenn Sie ernsthaft unbefugte Bearbeitungen verhindern müssen, sind Sie besser beraten, [strengere Schutzmaßnahmen zu verwenden, die Verschlüsselung und Passwörter beinhalten](https://docs.aspose.com/slides/java/password-protected-presentation/). 

{{% /alert %}}