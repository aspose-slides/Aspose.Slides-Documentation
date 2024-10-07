---
title: Nur-Lese-Präsentation
type: docs
weight: 30
url: /cpp/nur-lese-praesentation/

---

In PowerPoint 2019 führte Microsoft die Einstellung **Immer als Nur-Lese öffnen** ein, die eine der Optionen ist, die Benutzer verwenden können, um ihre Präsentationen zu schützen. Sie möchten möglicherweise diese Nur-Lese-Einstellung verwenden, um eine Präsentation zu schützen, wenn

- Sie versehentliche Bearbeitungen verhindern und den Inhalt Ihrer Präsentation sicher halten möchten. 
- Sie die Menschen darauf hinweisen möchten, dass die von Ihnen bereitgestellte Präsentation die endgültige Version ist. 

Nachdem Sie die Option **Immer als Nur-Lese öffnen** für eine Präsentation ausgewählt haben, sehen die Benutzer beim Öffnen der Präsentation die Empfehlung **Nur-Lese** und möglicherweise eine Nachricht in dieser Form: *Um versehentliche Änderungen zu verhindern, hat der Autor diese Datei so eingestellt, dass sie als Nur-Lese geöffnet wird.*

Die Empfehlung **Nur-Lese** ist ein einfacher, aber effektiver Abschreckungsfaktor, der das Bearbeiten entmutigt, da die Benutzer eine Aufgabe ausführen müssen, um sie zu entfernen, bevor sie eine Präsentation bearbeiten dürfen. Wenn Sie nicht möchten, dass Benutzer Änderungen an einer Präsentation vornehmen, und sie höflich darüber informieren möchten, ist die Empfehlung **Nur-Lese** möglicherweise eine gute Option für Sie.

> Wenn eine Präsentation mit dem **Nur-Lese**-Schutz in einer älteren Microsoft PowerPoint-Anwendung geöffnet wird—die die kürzlich eingeführte Funktion nicht unterstützt—wird die Empfehlung **Nur-Lese** ignoriert (die Präsentation wird normal geöffnet).

Aspose.Slides für C++ ermöglicht es Ihnen, eine Präsentation auf **Nur-Lese** einzustellen, was bedeutet, dass Benutzer (nachdem sie die Präsentation geöffnet haben) die Empfehlung **Nur-Lese** sehen. Dieser Beispielcode zeigt Ihnen, wie Sie eine Präsentation in C++ mit Aspose.Slides auf **Nur-Lese** setzen:

``` cpp
auto pres = System::MakeObject<Presentation>();
pres->get_ProtectionManager()->set_ReadOnlyRecommended(true);
pres->Save(u"ReadOnlyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert color="primary" %}} 

**Hinweis**: Die Empfehlung **Nur-Lese** soll einfach dazu dienen, das Bearbeiten abzuschrecken oder zu verhindern, dass Benutzer versehentliche Änderungen an einer PowerPoint-Präsentation vornehmen. Wenn eine motivierte Person—die weiß, was sie tut—beschließt, Ihre Präsentation zu bearbeiten, kann sie die Nur-Lese-Einstellung leicht entfernen. Wenn Sie ernsthaft unbefugte Bearbeitungen verhindern müssen, sind Sie besser beraten, [strengere Schutzmaßnahmen zu verwenden, die Verschlüsselungen und Passwörter beinhalten](https://docs.aspose.com/slides/cpp/password-protected-presentation/). 

{{% /alert %}}