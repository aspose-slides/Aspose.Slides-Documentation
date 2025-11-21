---
title: Schriftarten ersetzen - PowerPoint C# API
linktitle: Schriftarten ersetzen
type: docs
weight: 60
url: /de/net/font-replacement/
keywords: "Schriftart, Schriftart ersetzen, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: Mit der C# PowerPoint API können Sie Schriftarten explizit durch eine andere Schriftart in der Präsentation ersetzen.
---

## **Schriftarten ersetzen**

Wenn Sie es sich anders überlegen, eine Schriftart zu verwenden, können Sie diese Schriftart durch eine andere ersetzen. Alle Vorkommen der alten Schriftart werden durch die neue Schriftart ersetzt. 

Aspose.Slides ermöglicht das Ersetzen einer Schriftart auf folgende Weise:

1. Laden Sie die entsprechende Präsentation. 
2. Laden Sie die Schriftart, die ersetzt werden soll.
3. Laden Sie die neue Schriftart. 
4. Ersetzen Sie die Schriftart. 
5. Speichern Sie die modifizierte Präsentation als PPTX‑Datei.

Dieser C#‑Code demonstriert das Ersetzen von Schriftarten:
```c#
// Lädt eine Präsentation
Presentation presentation = new Presentation("Fonts.pptx");

// Lädt die Quellschriftart, die ersetzt werden soll
IFontData sourceFont = new FontData("Arial");

// Lädt die neue Schriftart
IFontData destFont = new FontData("Times New Roman");

// Ersetzt die Schriftarten
presentation.FontsManager.ReplaceFont(sourceFont, destFont);

// Speichert die Präsentation
presentation.Save("UpdatedFont_out.pptx", SaveFormat.Pptx);
```


{{% alert title="Note" color="warning" %}} 
Um Regeln festzulegen, die bestimmen, was unter bestimmten Bedingungen geschieht (z. B. wenn auf eine Schriftart nicht zugegriffen werden kann), siehe [**Font Substitution**](/slides/de/net/font-substitution/). 
{{% /alert %}}

## **FAQ**

**Was ist der Unterschied zwischen „font replacement“, „font substitution“ und „fallback fonts“?**

Ersetzen ist ein gezielter Wechsel von einer Familie zu einer anderen im gesamten Dokument. [Substitution](/slides/de/net/font-substitution/) ist eine Regel wie „wenn die Schriftart nicht verfügbar ist, verwende X.“ [Fallback](/slides/de/net/fallback-font/) wird chirurgisch für einzelne fehlende Glyphen angewendet, wenn die Basisschriftart installiert ist, aber die erforderlichen Zeichen nicht enthält.

**Wird das Ersetzen auf Masterfolien, Layouts, Notizen und Kommentare angewendet?**

Ja. Das Ersetzen wirkt sich auf alle Präsentationsobjekte aus, die die ursprüngliche Schriftart verwenden, einschließlich Masterfolien und Notizen; Kommentare sind ebenfalls Teil des Dokuments und werden von der Schriftart‑Engine berücksichtigt.

**Wird die Schriftart in eingebetteten OLE‑Objekten (z. B. Excel) geändert?**

Nein. [OLE content](/slides/de/net/manage-ole/) wird von seiner eigenen Anwendung gesteuert. Das Ersetzen in der Präsentation formatiert die internen OLE‑Daten nicht neu; sie können als Bild oder als extern editierbarer Inhalt angezeigt werden.

**Kann ich eine Schriftart nur in einem Teil der Präsentation (nach Folien oder Regionen) ersetzen?**

Gezieltes Ersetzen ist möglich, wenn Sie die Schriftart auf der Ebene der erforderlichen Objekte/Bereiche ändern, anstatt ein globales Ersetzen für das gesamte Dokument anzuwenden. Die gesamte Logik zur Schriftartauswahl während des Renderings bleibt unverändert.

**Wie kann ich im Voraus bestimmen, welche Schriftarten die Präsentation überhaupt verwendet?**

Verwenden Sie den [font manager] der Präsentation (https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/): Er liefert eine Liste der [verwendeten Familien](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getfonts/) und Informationen zu [Substitutions/„unknown“-Schriftarten](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getsubstitutions/), was bei der Planung des Ersetzens hilft.

**Funktioniert das Ersetzen von Schriftarten beim Konvertieren zu PDF/Bildern?**

Ja. Beim Export wendet Aspose.Slides dieselbe [font selection/substitution sequence](/slides/de/net/font-selection-sequence/) an, sodass ein vorher durchgeführtes Ersetzen während der Konvertierung berücksichtigt wird.

**Muss ich die Zielschriftart im System installieren oder kann ich einen Schriftarten‑Ordner anhängen?**

Eine Installation ist nicht erforderlich: Die Bibliothek ermöglicht das [loading external fonts](/slides/de/net/custom-font/) aus Benutzerordnern für die Verwendung während des [rendering and export](/slides/de/net/convert-powerpoint/).

**Wird das Ersetzen „Tofu“ (Quadrate) anstelle von Zeichen beheben?**

Nur wenn die Zielschriftart die erforderlichen Glyphen tatsächlich enthält. Andernfalls [configure fallback](/slides/de/net/fallback-font/) zur Abdeckung der fehlenden Zeichen.