---
title: Nur-Lese-Präsentation
type: docs
weight: 30
url: /androidjava/nur-lesen-praesentation/

---

In PowerPoint 2019 hat Microsoft die Einstellung **Immer als Nur-Lese** eingeführt, die eine der Optionen ist, die Benutzer nutzen können, um ihre Präsentationen zu schützen. Sie möchten diese Nur-Lese-Einstellung verwenden, um eine Präsentation zu schützen, wenn

- Sie versehentliche Bearbeitungen verhindern und den Inhalt Ihrer Präsentation sicher halten möchten. 
- Sie die Personen darauf hinweisen möchten, dass die von Ihnen bereitgestellte Präsentation die endgültige Version ist. 

Nachdem Sie die Option **Immer als Nur-Lese** für eine Präsentation ausgewählt haben, sehen die Benutzer, wenn sie die Präsentation öffnen, die Empfehlung **Nur-Lese** und möglicherweise eine Nachricht in dieser Form: *Um versehentliche Änderungen zu verhindern, hat der Autor diese Datei auf Nur-Lese gesetzt.*

Die Empfehlung Nur-Lese ist eine einfache, aber effektive Abschreckung, die das Bearbeiten entmutigt, da die Benutzer eine Aufgabe ausführen müssen, um sie zu entfernen, bevor sie eine Präsentation bearbeiten dürfen. Wenn Sie nicht möchten, dass Benutzer Änderungen an einer Präsentation vornehmen, und sie freundlich darauf hinweisen möchten, dann könnte die Empfehlung Nur-Lese eine gute Option für Sie sein. 

> Wenn eine Präsentation mit dem Schutz **Nur-Lese** in einer älteren Microsoft PowerPoint-Anwendung geöffnet wird – die die kürzlich eingeführte Funktion nicht unterstützt – wird die Empfehlung **Nur-Lese** ignoriert (die Präsentation wird normal geöffnet).

Aspose.Slides für Android über Java ermöglicht es Ihnen, eine Präsentation auf **Nur-Lese** zu setzen, was bedeutet, dass die Benutzer (nachdem sie die Präsentation geöffnet haben) die Empfehlung **Nur-Lese** sehen. Dieser Beispielcode zeigt Ihnen, wie Sie eine Präsentation in Java mithilfe von Aspose.Slides auf **Nur-Lese** setzen:

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

**Hinweis**: Die Empfehlung **Nur-Lese** soll lediglich dazu dienen, das Bearbeiten abzuschrecken oder zu verhindern, dass Benutzer versehentliche Änderungen an einer PowerPoint-Präsentation vornehmen. Wenn eine motivierte Person – die weiß, was sie tut – beschließt, Ihre Präsentation zu bearbeiten, kann sie die Nur-Lese-Einstellung problemlos entfernen. Wenn Sie ernsthaft unbefugte Bearbeitungen verhindern müssen, sind Sie besser beraten, [strengere Schutzmaßnahmen zu verwenden, die Verschlüsselungen und Passwörter umfassen](https://docs.aspose.com/slides/androidjava/password-protected-presentation/).

{{% /alert %}} 