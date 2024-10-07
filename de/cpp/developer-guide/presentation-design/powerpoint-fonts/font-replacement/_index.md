---
title: Schriftarten ersetzen
type: docs
weight: 60
url: /cpp/font-replacement/
keywords: "Schriftart, Schriftart ersetzen, PowerPoint-Präsentation, C++, CPP, Aspose.Slides für C++"
description: "Schriftarten explizit in PowerPoint in C++ ersetzen"
---

Wenn Sie Ihre Meinung über die Verwendung einer Schriftart ändern, können Sie diese Schriftart durch eine andere ersetzen. Alle Instanzen der alten Schriftart werden durch die neue Schriftart ersetzt.

Aspose.Slides ermöglicht es Ihnen, eine Schriftart auf folgende Weise zu ersetzen:

1. Laden Sie die relevante Präsentation.
2. Laden Sie die Schriftart, die ersetzt werden soll.
3. Laden Sie die neue Schriftart.
4. Ersetzen Sie die Schriftart.
5. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser C++-Code demonstriert das Ersetzen von Schriftarten:

``` cpp
// Lädt eine Präsentation
auto presentation = System::MakeObject<Presentation>(u"Fonts.pptx");

// Lädt die Quellschriftart, die ersetzt werden soll
auto sourceFont = System::MakeObject<FontData>(u"Arial");

// Lädt die neue Schriftart
auto destFont = System::MakeObject<FontData>(u"Times New Roman");

// Ersetzt die Schriftarten
presentation->get_FontsManager()->ReplaceFont(sourceFont, destFont);

// Speichert die Präsentation
presentation->Save(u"UpdatedFont_out.pptx", SaveFormat::Pptx);
```

{{% alert title="Hinweis" color="warning" %}} 

Um Regeln festzulegen, die bestimmen, was unter bestimmten Bedingungen passiert (z. B. wenn auf eine Schriftart nicht zugegriffen werden kann), siehe [**Schriftartsubstitution**](/slides/cpp/font-substitution/). 

{{% /alert %}}