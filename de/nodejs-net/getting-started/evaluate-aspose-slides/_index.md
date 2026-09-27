---
title: Evaluieren von Aspose.Slides
type: docs
weight: 120
url: /de/nodejs-net/evaluate-aspose-slides/
keywords:
- Aspose.Slides evaluieren
- Evaluierungsversion
- Evaluierungswasserzeichen
- Einschränkungen der Testversion
- Temporäre Lizenz
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Was die Evaluierungsversion von Aspose.Slides für Node.js via .NET einschränkt, mit einem Skript, das beide Einschränkungen zeigt und erklärt, wie man sie mit einer Lizenz entfernt."
---
## **Übersicht**

Die Evaluierungs‑Version von Aspose.Slides für Node.js via .NET ist dasselbe npm‑Paket wie die lizenzierte Version. Ohne Lizenz läuft sie im Evaluierungsmodus: alle Funktionen funktionieren, aber gespeicherte Präsentationen und die meisten Exporte erhalten ein Wasserzeichen, und der Text, den Ihr Code zurückliest, wird abgeschnitten. Dieser Artikel beschreibt beide Einschränkungen und zeigt, wie man sie entfernt.

## **Evaluierungs‑Einschränkungen**

**Ein Evaluierungswasserzeichen auf jeder Folie.**  
Wenn Sie eine Präsentation ohne Lizenz speichern, fügt Aspose.Slides jedem Folienbild der gespeicherten Datei ein Textfeld in der Mitte hinzu. Das Textfeld ist gesperrt und enthält den Text „Evaluation only.“ gefolgt von einer Produktzeile und einer Copyright‑Zeile. Das Wasserzeichen wird in die gespeicherte Datei geschrieben, nicht in die Präsentation im Speicher, und das Öffnen einer Präsentation fügt keines hinzu. Eine Datei, die im Evaluierungsmodus gespeichert wurde, enthält das Textfeld jedoch bereits, sodass ein erneutes Öffnen und Speichern ein zweites Wasserzeichen zu jeder Folie hinzufügt.

Das gleiche Wasserzeichen wird in der Ausgabe gezeichnet, wenn Sie in PDF, XPS oder HTML exportieren oder Folien als Bilder rendern. Wenn Sie eine Präsentation rendern, die bereits im Evaluierungsmodus gespeichert wurde, zeigt das Bild sowohl das gespeicherte Wasserzeichen als auch das gerenderte.

**Abgeschnittener Text, wenn Ihr Code ihn liest.**  
Text, den Ihr Code über die `text`‑Eigenschaft eines Text‑Frames, Absatzes oder Abschnitts ausliest, wird auf die ersten fünf Zeichen gekürzt, gefolgt von dem Hinweis "... text has been truncated due to evaluation version limitation." Texte von fünf Zeichen oder weniger werden vollständig zurückgegeben. Dies gilt für jede Folie und selbst für Text, den Ihr Code gerade zugewiesen hat. Markdown‑ und HTML5‑Exporte werden auf dieselbe Weise gekürzt.

Der von Ihrem Code geschriebene Text wird vollständig gespeichert: PPTX‑Dateien, PDF‑Seiten und Folienbilder enthalten den kompletten Text.

## **Siehe die Einschränkungen in einem Skript**

Das folgende Skript zeigt beide Einschränkungen. Es wird davon ausgegangen, dass Sie das Paket wie in [Installation](/slides/de/nodejs-net/installation/) beschrieben installiert haben und dass Sie es aus dem Projektordner ausführen. Es fügt der ersten Folie ein Rechteck mit einem Satz hinzu, liest den Satz zurück, speichert die Präsentation als `evaluation.pptx` und öffnet die Datei anschließend erneut, um die Formen auf der Folie zu zählen.

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 500, 100);
    rectangle.textFrame.text = "Quarterly results are ready for review.";

    // Ohne Lizenz werden nur die ersten fünf Zeichen zurückgegeben.
    console.log("Text read back:", rectangle.textFrame.text);

    // Beim Speichern wird jeder Folie der Datei das Evaluierungswasserzeichen hinzugefügt.
    presentation.save("evaluation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const savedPresentation = new Presentation("evaluation.pptx");
try {
    // Die Folie enthält jetzt das Rechteck und das Wasserzeichen‑Textfeld.
    console.log("Shapes on the saved slide:", savedPresentation.slides.get(0).shapes.count);
} finally {
    savedPresentation.dispose();
}
```

Ohne Lizenz gibt das Skript aus:

```text
Text read back: Quart... text has been truncated due to evaluation version limitation.
Shapes on the saved slide: 2
```

Das zweite Shape ist das Wasserzeichen‑Textfeld. Öffnen Sie `evaluation.pptx`, um den vollständigen Satz im Rechteck und das Wasserzeichen in der Mitte der Folie zu sehen.

## **Entfernen der Einschränkungen**

Um beide Einschränkungen zu entfernen, wenden Sie eine Lizenz an, bevor Sie ein `Presentation`‑Objekt erstellen. [Licensing](/slides/de/nodejs-net/licensing/) zeigt, wie man eine Lizenzdatei anwendet.

{{% alert color="success" title="Tip" %}}
Um Aspose.Slides ohne die Evaluierungsbeschränkungen zu testen, bevor Sie kaufen, fordern Sie eine kostenlose **30‑tägige temporäre Lizenz** an. Siehe [How to get a Temporary License?](https://purchase.aspose.com/temporary-license) für Details.
{{% /alert %}}

## **FAQ**

**Begrenzt der Evaluierungsmodus die Anzahl der Folien?**

Nein. Präsentationen werden erstellt, geöffnet und gespeichert mit allen ihren Folien. Das Wasserzeichen und die Textkürzung gelten für jede Folie gleichermaßen.

**Warum zeigen meine exportierten Folienbilder das Wasserzeichen zweimal?**

Die Präsentation wurde im Evaluierungsmodus gespeichert, bevor Sie sie gerendert haben, sodass sie bereits ein Wasserzeichen‑Textfeld enthält, und das Rendern ohne Lizenz fügt ein weiteres darüber hinaus hinzu.

**Kann ich überprüfen, ob mein Code den richtigen Text im Evaluierungsmodus erzeugt?**

Ja. Öffnen Sie die gespeicherte Datei oder das exportierte PDF: Sie enthalten den vollständigen Text. Nur der Text, den Ihr Code zurückliest, sowie Markdown‑ oder HTML5‑Ausgabe, wird gekürzt.