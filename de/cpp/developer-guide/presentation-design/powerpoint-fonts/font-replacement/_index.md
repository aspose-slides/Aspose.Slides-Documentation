---
title: "Vereinfachen Sie die Schriftart-Ersetzung in Präsentationen mit С++"
linktitle: "Schriftart ersetzen"
type: docs
weight: 60
url: /de/cpp/font-replacement/
keywords:
- "Schriftart"
- "Schriftart ersetzen"
- "Schriftart-Ersetzung"
- "Schriftart ändern"
- "PowerPoint"
- "OpenDocument"
- "Präsentation"
- "С++"
- "Aspose.Slides"
description: "Nahtlos Schriftarten in Aspose.Slides für С++ ersetzen, um eine konsistente Typografie in PowerPoint- und OpenDocument-Präsentationen zu gewährleisten."
---

## **Schriftarten ersetzen**

Wenn Sie Ihre Meinung bezüglich der Verwendung einer Schriftart ändern, können Sie diese Schriftart durch eine andere ersetzen. Alle Vorkommen der alten Schriftart werden durch die neue Schriftart ersetzt.

Aspose.Slides ermöglicht das Ersetzen einer Schriftart auf folgende Weise:

1. Laden Sie die entsprechende Präsentation.  
2. Laden Sie die zu ersetzende Schriftart.  
3. Laden Sie die neue Schriftart.  
4. Ersetzen Sie die Schriftart.  
5. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

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


{{% alert title="Hinweis" color="warning" %}} 
Um Regeln festzulegen, die bestimmen, was unter bestimmten Bedingungen geschieht (z. B. wenn auf eine Schriftart nicht zugegriffen werden kann), siehe [**Font Substitution**](/slides/de/cpp/font-substitution/). 
{{% /alert %}}

## **FAQ**

**Was ist der Unterschied zwischen „Schriftart‑Ersetzung“, „Schriftart‑Substitution“ und „Fallback‑Schriftarten“?**

Ersetzung ist ein gezielter Wechsel von einer Familie zu einer anderen im gesamten Dokument. [Substitution](/slides/de/cpp/font-substitution/) ist eine Regel wie „wenn die Schriftart nicht verfügbar ist, verwende X.“ [Fallback](/slides/de/cpp/fallback-font/) wird punktuell für einzelne fehlende Glyphen angewendet, wenn die Basisschriftart installiert ist, aber die benötigten Zeichen nicht enthält.

**Gilt die Ersetzung für Master‑Folien, Layouts, Notizen und Kommentare?**

Ja. Die Ersetzung betrifft alle Präsentationsobjekte, die die ursprüngliche Schriftart verwenden, einschließlich Master‑Folien und Notizen; Kommentare sind ebenfalls Teil des Dokuments und werden vom Schriftart‑Engine berücksichtigt.

**Ändert sich die Schriftart in eingebetteten OLE‑Objekten (z. B. Excel)?**

Nein. [OLE‑Inhalt](/slides/de/cpp/manage-ole/) wird von seiner eigenen Anwendung gesteuert. Eine Ersetzung in der Präsentation formatiert die internen OLE‑Daten nicht neu; sie können als Bild oder als extern editierbarer Inhalt angezeigt werden.

**Kann ich eine Schriftart nur in einem Teil der Präsentation (nach Folien oder Bereichen) ersetzen?**

Gezielte Ersetzung ist möglich, wenn Sie die Schriftart auf Ebene der erforderlichen Objekte/Bereiche ändern, anstatt eine globale Ersetzung für das gesamte Dokument anzuwenden. Die gesamte Logik zur Schriftartauswahl während des Renderings bleibt unverändert.

**Wie kann ich im Voraus bestimmen, welche Schriftarten die Präsentation verwendet?**

Verwenden Sie den [Font Manager] der Präsentation (https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/): Er liefert eine Liste der [verwendeten Familien]https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/getfonts/ und Informationen zu [Substitutionen/„unbekannten“ Schriftarten]https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/getsubstitutions/, was die Planung der Ersetzung erleichtert.

**Funktioniert die Schriftart‑Ersetzung beim Konvertieren in PDF/Bilder?**

Ja. Beim Export wendet Aspose.Slides die gleiche [Schriftart‑Auswahl/‑Substitutionssequenz](/slides/de/cpp/font-selection-sequence/) an, sodass eine im Voraus durchgeführte Ersetzung während der Konvertierung berücksichtigt wird.

**Muss ich die Ziel­schriftart im System installieren oder kann ich einen Schriftarten‑Ordner anhängen?**

Eine Installation ist nicht erforderlich: Die Bibliothek ermöglicht das [Laden externer Schriftarten](/slides/de/cpp/custom-font/) aus Benutzerordnern für die Verwendung während des [Renderings und Exports](/slides/de/cpp/convert-powerpoint/).

**Korrigiert die Ersetzung „Tofu“ (Quadrate) anstelle von Zeichen?**

Nur wenn die Zielschriftart die erforderlichen Glyphen tatsächlich enthält. Andernfalls [Fallback konfigurieren](/slides/de/cpp/fallback-font/), um die fehlenden Zeichen abzudecken.