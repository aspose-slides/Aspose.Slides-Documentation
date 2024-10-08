---
title: Hochgestellt und Tiefgestellt
type: docs
weight: 80
url: /de/cpp/superscript-and-subscript/
---

## **Hochgestellten und Tiefgestellten Text verwalten**
Sie können hochgestellten und tiefgestellten Text innerhalb jedes Absatzes hinzufügen. Um hochgestellten oder tiefgestellten Text im Aspose.Slides-Textrahmen hinzuzufügen, müssen die **Escapement**-Eigenschaften der PortionFormat-Klasse verwendet werden.

Diese Eigenschaft gibt den hochgestellten oder tiefgestellten Text zurück oder legt ihn fest (Wert von -100% (tiefgestellt) bis 100% (hochgestellt)). Zum Beispiel:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
- Erhalten Sie die Referenz zu einer Folie, indem Sie ihren Index verwenden.
- Fügen Sie der Folie eine IAutoShape des Rechtecktyps hinzu.
- Greifen Sie auf den ITextFrame zu, der mit dem IAutoShape verknüpft ist.
- Löschen Sie bestehende Absätze.
- Erstellen Sie ein neues Absatzobjekt zum Halten von hochgestelltem Text und fügen Sie es der IParagraphs-Sammlung des ITextFrame hinzu.
- Erstellen Sie ein neues Portionsobjekt.
- Setzen Sie die Escapement-Eigenschaft für die Portion zwischen 0 und 100, um hochgestellten Text hinzuzufügen. (0 bedeutet keinen hochgestellten Text)
- Setzen Sie etwas Text für die Portion und fügen Sie diesen dann der Portionssammlung des Absatzes hinzu.
- Erstellen Sie ein neues Absatzobjekt zum Halten von tiefgestelltem Text und fügen Sie es der IParagraphs-Sammlung des ITextFrame hinzu.
- Erstellen Sie ein neues Portionsobjekt.
- Setzen Sie die Escapement-Eigenschaft für die Portion zwischen 0 und -100, um tiefgestellten Text hinzuzufügen. (0 bedeutet keinen tiefgestellten Text)
- Setzen Sie etwas Text für die Portion und fügen Sie diesen dann der Portionssammlung des Absatzes hinzu.
- Speichern Sie die Präsentation als PPTX-Datei.

Die Implementierung der oben genannten Schritte ist unten angegeben.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingSuperscriptAndSubscriptTextInTextFrame-AddingSuperscriptAndSubscriptTextInTextFrame.cpp" >}}