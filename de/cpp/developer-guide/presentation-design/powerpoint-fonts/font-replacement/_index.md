---
title: Optimieren der Schriftart‑Ersetzung in Präsentationen mit C++
linktitle: Schriftart‑Ersetzung
type: docs
weight: 60
url: /de/cpp/font-replacement/
keywords:
- Schriftart
- Schriftart ersetzen
- Schriftart‑Ersetzung
- Schriftart ändern
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Schriftarten in Aspose.Slides für C++ nahtlos ersetzen, um eine konsistente Typografie in PowerPoint- und OpenDocument-Präsentationen zu gewährleisten."
---
## **Übersicht**

Aspose.Slides ermöglicht es Ihnen, eine Schriftart im gesamten Dokument durch eine andere zu ersetzen. Wenn eine Schriftart ersetzt wird, werden alle Vorkommen der ursprünglichen Schriftart in die neue Schriftart geändert.

Um die Schriftart zu ersetzen, laden Sie die Präsentation, definieren die Quellschriftart und die Ersatzschriftart, rufen die Methode zum Ersetzen der Schriftart auf und speichern die geänderte Präsentation als PPTX‑Datei. Dieser Ansatz ist nützlich, wenn Sie bewusst von einer Schriftfamilie zu einer anderen über die gesamte Präsentation wechseln möchten.

## **Schriftarten ersetzen**

Wenn Sie Ihre Meinung bezüglich der Verwendung einer Schriftart ändern, können Sie diese Schriftart durch eine andere ersetzen. Alle Vorkommen der alten Schriftart werden durch die neue Schriftart ersetzt.

Aspose.Slides ermöglicht das Ersetzen einer Schriftart wie folgt:

1. Laden Sie die betreffende Präsentation.  
2. Laden Sie die zu ersetzende Schriftart.  
3. Laden Sie die neue Schriftart.  
4. Ersetzen Sie die Schriftart.  
5. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser C++‑Code demonstriert das Ersetzen von Schriftarten:

``` cpp
// Lädt eine Präsentation
auto presentation = System::MakeObject<Presentation>(u"Fonts.pptx");

// Lädt die Quellschriftart, die ersetzt wird
auto sourceFont = System::MakeObject<FontData>(u"Arial");

// Lädt die neue Schriftart
auto destFont = System::MakeObject<FontData>(u"Times New Roman");

// Ersetzt die Schriftarten
presentation->get_FontsManager()->ReplaceFont(sourceFont, destFont);

// Speichert die Präsentation
presentation->Save(u"UpdatedFont_out.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}}  
Um Regeln festzulegen, die bestimmen, was unter bestimmten Bedingungen geschieht (z. B. wenn auf eine Schriftart nicht zugegriffen werden kann), siehe [**Schriftart‑Substitution**](/slides/de/cpp/font-substitution/).  
{{% /alert %}}

## **FAQ**

**Was ist der Unterschied zwischen „Schriftart Ersetzung“, „Schriftart Substitution“ und „Fallback‑Schriftarten“?**

Ersetzung ist ein beabsichtigter Wechsel von einer Familie zu einer anderen im gesamten Dokument. [Substitution](/slides/de/cpp/font-substitution/) ist eine Regel wie „wenn die Schriftart nicht verfügbar ist, verwende X.“ [Fallback](/slides/de/cpp/fallback-font/) wird gezielt für einzelne fehlende Glyphen angewendet, wenn die Basis‑Schriftart installiert ist, aber die erforderlichen Zeichen nicht enthält.

**Wird die Ersetzung auf Masterfolien, Layouts, Notizen und Kommentare angewendet?**

Ja. Ersetzung betrifft alle Präsentationsobjekte, die die ursprüngliche Schriftart verwenden, einschließlich Masterfolien und Notizen; Kommentare sind ebenfalls Teil des Dokuments und werden von der Schrift‑Engine berücksichtigt.

**Wird die Schriftart in eingebetteten OLE‑Objekten (z. B. Excel) geändert?**

Nein. [OLE‑Inhalte](/slides/de/cpp/manage-ole/) werden von ihrer eigenen Anwendung gesteuert. Eine Ersetzung in der Präsentation formatiert die internen OLE‑Daten nicht neu; sie können als Bild oder als extern editierbarer Inhalt angezeigt werden.

**Kann ich eine Schriftart nur in einem Teil der Präsentation (nach Folien oder Bereichen) ersetzen?**

Ein gezielter Ersatz ist möglich, wenn Sie die Schriftart auf Ebene der erforderlichen Objekte/Bereiche ändern, anstatt eine globale Ersetzung für das gesamte Dokument anzuwenden. Die Gesamtlogik zur Schriftartauswahl beim Rendern bleibt unverändert.

**Wie kann ich im Voraus bestimmen, welche Schriftarten die Präsentation überhaupt verwendet?**

Verwenden Sie den [Schriftarten‑Manager] der Präsentation (https://reference.aspose.com/slides/de/cpp/aspose.slides/fontsmanager/): er liefert eine Liste der [verwendeten Familien](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontsmanager/getfonts/) und Informationen zu [Substitutionen/„unbekannten“ Schriftarten](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontsmanager/getsubstitutions/), was bei der Planung der Ersetzung hilft.

**Funktioniert die Schriftart Ersetzung beim Konvertieren zu PDF/Bildern?**

Ja. Beim Export wendet Aspose.Slides die gleiche [Schriftartauswahl‑Substitutions‑Sequenz](/slides/de/cpp/font-selection-sequence/) an, sodass eine vorher durchgeführte Ersetzung während der Konvertierung berücksichtigt wird.

**Muss ich die Zielschriftart im System installieren, oder kann ich einen Schriftarten‑Ordner anhängen?**

Eine Installation ist nicht erforderlich: Die Bibliothek ermöglicht das [Laden externer Schriftarten](/slides/de/cpp/custom-font/) aus Benutzerordnern für die Verwendung während [Rendering und Export](/slides/de/cpp/convert-powerpoint/).

**Wird die Ersetzung das „Tofu“ (Quadrate) anstelle von Zeichen beheben?**

Nur wenn die Zielschriftart die erforderlichen Glyphen tatsächlich enthält. Wenn nicht, [konfigurieren Sie den Fallback](/slides/de/cpp/fallback-font/), um die fehlenden Zeichen abzudecken.