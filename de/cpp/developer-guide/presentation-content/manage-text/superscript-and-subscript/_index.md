---
title: Verwalten von Superscript- und Subscript-Text in Präsentationen mit C++
linktitle: Hoch- und Tiefgestellt
type: docs
weight: 80
url: /de/cpp/superscript-and-subscript/
keywords:
- Hochgestellt
- Tiefgestellt
- Hochgestellt hinzufügen
- Tiefgestellt hinzufügen
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Meistern Sie Hoch- und Tiefstellung in Aspose.Slides für C++ und verbessern Sie Ihre Präsentationen mit professioneller Textformatierung für maximale Wirkung."
---

## **Superscript- und Subscript-Text verwalten**
Sie können hoch- und tiefgestellten Text in jedem Absatzanteil hinzufügen. Um Superscript- oder Subscript-Text in einem Aspose.Slides-Textfeld hinzuzufügen, muss die **Escapement**‑Eigenschaft der Klasse PortionFormat verwendet werden.

Diese Eigenschaft gibt den hoch- bzw. tiefgestellten Text zurück oder legt ihn fest (Wert von -100 % (tiefgestellt) bis 100 % (hochgestellt)). Zum Beispiel :

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
- Holen Sie die Referenz einer Folie, indem Sie deren Index verwenden.
- Fügen Sie der Folie ein IAutoShape vom Typ Rectangle hinzu.
- Greifen Sie auf das ITextFrame zu, das dem IAutoShape zugeordnet ist.
- Löschen Sie vorhandene Paragraphen.
- Erstellen Sie ein neues Paragraph‑Objekt zum Halten von hochgestelltem Text und fügen Sie es der IParagraphs‑Sammlung des ITextFrames hinzu.
- Erstellen Sie ein neues Portion‑Objekt.
- Setzen Sie die Escapement‑Eigenschaft für die Portion auf einen Wert zwischen 0 und 100, um hochgestellten Text hinzuzufügen. (0 bedeutet kein Hochstellen)
- Legen Sie etwas Text für die Portion fest und fügen Sie diese dann der Portion‑Sammlung des Paragraphen hinzu.
- Erstellen Sie ein neues Paragraph‑Objekt zum Halten von tiefgestelltem Text und fügen Sie es der IParagraphs‑Sammlung des ITextFrames hinzu.
- Erstellen Sie ein neues Portion‑Objekt.
- Setzen Sie die Escapement‑Eigenschaft für die Portion auf einen Wert zwischen 0 und -100, um tiefgestellten Text hinzuzufügen. (0 bedeutet kein Tiefstellen)
- Legen Sie etwas Text für die Portion fest und fügen Sie diese dann der Portion‑Sammlung des Paragraphen hinzu.
- Speichern Sie die Präsentation als PPTX‑Datei.

Die Implementierung der obigen Schritte wird unten gezeigt.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingSuperscriptAndSubscriptTextInTextFrame-AddingSuperscriptAndSubscriptTextInTextFrame.cpp" >}}

## **FAQ**

**Wird hoch- und tiefgestellter Text beim Exportieren in PDF oder andere Formate beibehalten?**

Ja, Aspose.Slides behält die Hoch‑ und Tiefstellen‑Formatierung beim Exportieren von Präsentationen nach PDF, PPT/PPTX, Bildern und anderen unterstützten Formaten korrekt bei. Die spezielle Formatierung bleibt in allen Ausgabedateien erhalten.

**Kann Hoch- und Tiefstellen mit anderen Formatierungsstilen wie Fett oder Kursiv kombiniert werden?**

Ja, Aspose.Slides ermöglicht das Mischen verschiedener Textstile innerhalb eines einzelnen Portion‑Texts. Sie können Fett, Kursiv, Unterstreichen aktivieren und gleichzeitig Hoch‑ oder Tiefstellen anwenden, indem Sie die entsprechenden Eigenschaften in [PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/) konfigurieren.

**Funktioniert die Hoch- und Tiefstellen-Formatierung für Text in Tabellen, Diagrammen oder SmartArt?**

Ja, Aspose.Slides unterstützt die Formatierung in den meisten Objekten, einschließlich Tabellen und Diagrammelementen. Beim Arbeiten mit SmartArt müssen Sie die entsprechenden Elemente (wie [SmartArtNode](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartnode/)) und deren Textbehälter zugreifen und dann die Eigenschaften von [PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/) in ähnlicher Weise konfigurieren.