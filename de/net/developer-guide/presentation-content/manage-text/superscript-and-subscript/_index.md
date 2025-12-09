---
title: "Verwalten von Hoch- und Tiefgestelltem Text in Präsentationen in .NET"
linktitle: "Hoch- und Tiefgestellt"
type: docs
weight: 80
url: /de/net/superscript-and-subscript/
keywords:
- Hochgestellt
- Tiefgestellt
- Hochgestellt hinzufügen
- Tiefgestellt hinzufügen
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Meistern Sie Hoch- und Tiefgestellt in Aspose.Slides für .NET und verbessern Sie Ihre Präsentationen mit professioneller Textformatierung für maximale Wirkung."
---

## **Übersicht**

Aspose.Slides für .NET bietet Funktionen zum Einfügen von Hoch‑ und Tiefgestellt‑Text in Ihre PowerPoint‑ (PPT, PPTX) und OpenDocument‑ (ODP) Präsentationen. Egal, ob Sie chemische Formeln, mathematische Gleichungen hervorheben oder Inhalte mit Fußnoten versehen möchten, diese speziellen Formatierungsoptionen tragen zu Klarheit und Präzision bei. In diesem Artikel erfahren Sie, wie Sie Hoch‑ und Tiefgestellt‑Stile nahtlos anwenden und in jeder Folie professionelle Ergebnisse erzielen.

## **Superscript‑ und Subscript‑Text hinzufügen**

Sie können Hoch‑ und Tiefgestellt‑Text in beliebigen Absatz einer Präsentation einfügen. Um dies mit Aspose.Slides zu erreichen, müssen Sie die `Escapement`‑Eigenschaft der [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/)-Klasse verwenden.

Diese Eigenschaft ermöglicht das Festlegen von Hoch‑ oder Tiefgestellt‑Text mit Werten von -100 % (Tiefgestellt) bis 100 % (Hochgestellt).

Implementation steps:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)-Klasse.  
2. Holen Sie sich eine Referenz zu einer Folie anhand ihres Index.  
3. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) vom Typ `Rectangle` hinzu.  
4. Greifen Sie auf den mit dem [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) verknüpften [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) zu.  
5. Löschen Sie vorhandene Absätze.  
6. Erstellen Sie einen neuen [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) für Hochgestellt‑Text und fügen Sie ihn zur Absatzsammlung des [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) hinzu.  
7. Erstellen Sie ein neues Text‑Portion‑Objekt.  
8. Setzen Sie die `Escapement`‑Eigenschaft für die Text‑Portion auf einen Wert zwischen 0 und 100, um Hochgestellt anzuwenden (0 bedeutet kein Hochgestellt).  
9. Legen Sie etwas Text für die [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/) fest und fügen Sie ihn zur Portion‑Sammlung des Absatzes hinzu.  
10. Erstellen Sie einen weiteren [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) für Tiefgestellt‑Text und fügen Sie ihn zur Absatzsammlung hinzu.  
11. Erstellen Sie ein neues Text‑Portion‑Objekt.  
12. Setzen Sie die `Escapement`‑Eigenschaft für die Text‑Portion auf einen Wert zwischen 0 und -100, um Tiefgestellt anzuwenden (0 bedeutet kein Tiefgestellt).  
13. Legen Sie etwas Text für die [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/) fest und fügen Sie ihn zur Portion‑Sammlung des Absatzes hinzu.  
14. Speichern Sie die Präsentation als PPTX‑Datei.

```c#
using (Presentation presentation = new Presentation())
{
    // Hole die erste Folie.
    ISlide slide = presentation.Slides[0];

    // Erstelle ein Textfeld.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.TextFrame;

    textFrame.Paragraphs.Clear();

    // Erstelle einen Absatz für Hochgestellt-Text.
    IParagraph superPar = new Paragraph();

    // Erstelle einen Textabschnitt mit Normaltext.
    IPortion portion1 = new Portion();
    portion1.Text = "MyProduct";
    superPar.Portions.Add(portion1);

    // Erstelle einen Textabschnitt mit Hochgestellt-Text.
    IPortion superPortion = new Portion();
    superPortion.PortionFormat.Escapement = 30;
    superPortion.Text = "TM";
    superPar.Portions.Add(superPortion);

    // Erstelle einen Absatz für Tiefgestellt-Text.
    IParagraph paragraph2 = new Paragraph();

    // Erstelle einen Textabschnitt mit Normaltext.
    IPortion portion2 = new Portion();
    portion2.Text = "a";
    paragraph2.Portions.Add(portion2);

    // Erstelle einen Textabschnitt mit Tiefgestellt-Text.
    IPortion subPortion = new Portion();
    subPortion.PortionFormat.Escapement = -25;
    subPortion.Text = "i";
    paragraph2.Portions.Add(subPortion);

    // Füge die Absätze zum Textfeld hinzu.
    textFrame.Paragraphs.Add(superPar);
    textFrame.Paragraphs.Add(paragraph2);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


Das Ergebnis:

![Hoch- und Tiefgestellt](superscript_and_subscript.png)

## **FAQ**

**Bleiben Hoch‑ und Tiefgestellt beim Export in PDF oder andere Formate erhalten?**

Ja, Aspose.Slides für .NET bewahrt die Hoch‑ und Tiefgestellt‑Formatierung beim Export von Präsentationen in PDF, PPT/PPTX, Bilder und andere unterstützte Formate korrekt. Die spezialisierte Formatierung bleibt in allen Ausgabedateien erhalten.

**Können Hoch‑ und Tiefgestellt mit anderen Formatierungsstilen wie Fett oder Kursiv kombiniert werden?**

Ja, Aspose.Slides ermöglicht das Mischen verschiedener Textstile innerhalb einer einzelnen Text‑Portion. Sie können Fett, Kursiv, Unterstreichen aktivieren und gleichzeitig Hoch‑ oder Tiefgestellt anwenden, indem Sie die entsprechenden Eigenschaften in [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) konfigurieren.

**Funktionieren Hoch‑ und Tiefgestellt‑Formatierungen für Text in Tabellen, Diagrammen oder SmartArt?**

Ja, Aspose.Slides für .NET unterstützt die Formatierung in den meisten Objekten, einschließlich Tabellen und Diagrammelementen. Beim Arbeiten mit SmartArt müssen Sie die entsprechenden Elemente (wie [SmartArtNode](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartnode/)) und deren Textcontainer zugreifen und anschließend die [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/)-Eigenschaften in ähnlicher Weise konfigurieren.