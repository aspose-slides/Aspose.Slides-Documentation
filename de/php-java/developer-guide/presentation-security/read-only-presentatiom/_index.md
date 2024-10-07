---
title: Nur-Lese-Präsentation
type: docs
weight: 30
url: /php-java/nur-lese-praesentation/

---

In PowerPoint 2019 führte Microsoft die Einstellung **Immer als Nur-Lese öffnen** als eine der Optionen ein, die Benutzer zum Schutz ihrer Präsentationen verwenden können. Sie möchten diese Nur-Lese-Einstellung verwenden, um eine Präsentation zu schützen, wenn

- Sie versehentliche Bearbeitungen verhindern und den Inhalt Ihrer Präsentation sicher aufbewahren möchten. 
- Sie die Leute darauf aufmerksam machen möchten, dass die von Ihnen bereitgestellte Präsentation die endgültige Version ist. 

Nachdem Sie die Option **Immer als Nur-Lese öffnen** für eine Präsentation ausgewählt haben, sehen die Benutzer beim Öffnen der Präsentation die Empfehlung **Nur-Lese** und möglicherweise eine Nachricht in folgender Form: *Um versehentliche Änderungen zu verhindern, hat der Autor diese Datei so eingestellt, dass sie als nur lesbar geöffnet wird.*

Die Empfehlung Nur-Lese ist ein einfaches, aber effektives Mittel, um das Bearbeiten abzuschrecken, da die Benutzer eine Aufgabe ausführen müssen, um sie zu entfernen, bevor sie eine Präsentation bearbeiten dürfen. Wenn Sie nicht möchten, dass Benutzer Änderungen an einer Präsentation vornehmen, und sie höflich darauf hinweisen möchten, könnte die Empfehlung Nur-Lese eine gute Option für Sie sein. 

> Wenn eine Präsentation mit dem Schutz **Nur-Lese** in einer älteren Microsoft PowerPoint-Anwendung geöffnet wird, die die kürzlich eingeführte Funktion nicht unterstützt, wird die Empfehlung **Nur-Lese** ignoriert (die Präsentation wird normal geöffnet).

Aspose.Slides für PHP über Java ermöglicht es Ihnen, eine Präsentation als **Nur-Lese** festzulegen, was bedeutet, dass die Benutzer (nachdem sie die Präsentation geöffnet haben) die Empfehlung **Nur-Lese** sehen. Dieser Beispielcode zeigt Ihnen, wie Sie eine Präsentation mit Aspose.Slides als **Nur-Lese** festlegen:

```php
  $pres = new Presentation();
  try {
    $pres->getProtectionManager()->setReadOnlyRecommended(true);
    $pres->save("ReadOnlyPresentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 

**Hinweis**: Die Empfehlung **Nur-Lese** soll einfach dazu dienen, das Bearbeiten abzuschrecken oder Benutzer daran zu hindern, versehentliche Änderungen an einer PowerPoint-Präsentation vorzunehmen. Wenn sich eine motivierte Person – die weiß, was sie tut – entscheidet, Ihre Präsentation zu bearbeiten, kann sie die Nur-Lese-Einstellung leicht entfernen. Wenn Sie dringend unbefugtes Bearbeiten verhindern müssen, sind Sie besser beraten, [strengerer Schutzmaßnahmen mit Verschlüsselungen und Passwörtern](https://docs.aspose.com/slides/php-java/password-protected-presentation/) zu verwenden.

{{% /alert %}} 