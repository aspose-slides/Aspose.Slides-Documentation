---
title: Verwalten von Hoch- und Tiefstellung in C#
linktitle: Hoch- und Tiefstellung
type: docs
weight: 80
url: /de/net/superscript-and-subscript/
keywords:
- hochgestellt
- tiefgestellt
- hochgestellt hinzufügen
- tiefgestellt hinzufügen
- PowerPoint
- OpenDocument
- Präsentation
- C#
- Csharp
- Aspose.Slides
description: "Meistern Sie Hoch- und Tiefstellung in Aspose.Slides für .NET und verbessern Sie Ihre Präsentationen mit professioneller Textformatierung für maximale Wirkung."
---

## **Übersicht**

Aspose.Slides für .NET bietet Funktionen zum Einfügen von hoch- und tiefgestelltem Text in Ihre PowerPoint‑ (PPT, PPTX) und OpenDocument‑ (ODP) Präsentationen. Egal, ob Sie chemische Formeln, mathematische Gleichungen hervorheben oder Inhalte mit Fußnoten kommentieren müssen, diese speziellen Formatierungsoptionen unterstützen Klarheit und Präzision. In diesem Artikel erfahren Sie, wie Sie hoch‑ und tiefgestellte Stile nahtlos anwenden und in jeder Folie professionelle Ergebnisse erzielen.

## **Hoch- und Tiefgestellten Text hinzufügen**

Sie können hoch- und tiefgestellten Text in jedem Absatz einer Präsentation hinzufügen. Um dies mit Aspose.Slides zu erreichen, müssen Sie die Eigenschaft `Escapement` der Klasse [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) verwenden.

Diese Eigenschaft ermöglicht das Festlegen von hoch- oder tiefgestelltem Text, wobei die Werte von -100 % (tiefgestellt) bis 100 % (hochgestellt) reichen.

Implementierungsschritte:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Holen Sie eine Referenz auf eine Folie über ihren Index.
3. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) vom Typ `Rectangle` hinzu.
4. Greifen Sie auf das [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) zu, das mit dem [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) verknüpft ist.
5. Löschen Sie vorhandene Absätze.
6. Erstellen Sie einen neuen [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) für hochgestellten Text und fügen Sie ihn der Absatzsammlung des [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) hinzu.
7. Erstellen Sie ein neues Text‑Portion‑Objekt.
8. Setzen Sie die Eigenschaft `Escapement` für die Text‑Portion zwischen 0 und 100, um Hochstellung anzuwenden (0 bedeutet keine Hochstellung).
9. Legen Sie Text für die [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/) fest und fügen Sie ihn der Portion‑Sammlung des Absatzes hinzu.
10. Erstellen Sie einen weiteren [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) für tiefgestellten Text und fügen Sie ihn der Absatzsammlung hinzu.
11. Erstellen Sie ein neues Text‑Portion‑Objekt.
12. Setzen Sie die Eigenschaft `Escapement` für die Text‑Portion zwischen 0 und -100, um Tiefstellung anzuwenden (0 bedeutet keine Tiefstellung).
13. Legen Sie Text für die [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/) fest und fügen Sie ihn der Portion‑Sammlung des Absatzes hinzu.
14. Speichern Sie die Präsentation als PPTX‑Datei.

Der folgende C#‑Code implementiert diese Schritte:
```c#
using (Presentation presentation = new Presentation())
{
    // Hole die erste Folie.
    ISlide slide = presentation.Slides[0];

    // Erstelle ein Textfeld.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.TextFrame;

    textFrame.Paragraphs.Clear();

    // Erstelle einen Absatz für hochgestellten Text.
    IParagraph superPar = new Paragraph();

    // Erstelle einen Textabschnitt mit normalem Text.
    IPortion portion1 = new Portion();
    portion1.Text = "MyProduct";
    superPar.Portions.Add(portion1);

    // Erstelle einen Textabschnitt mit hochgestelltem Text.
    IPortion superPortion = new Portion();
    superPortion.PortionFormat.Escapement = 30;
    superPortion.Text = "TM";
    superPar.Portions.Add(superPortion);

    // Erstelle einen Absatz für tiefgestellten Text.
    IParagraph paragraph2 = new Paragraph();

    // Erstelle einen Textabschnitt mit normalem Text.
    IPortion portion2 = new Portion();
    portion2.Text = "a";
    paragraph2.Portions.Add(portion2);

    // Erstelle einen Textabschnitt mit tiefgestelltem Text.
    IPortion subPortion = new Portion();
    subPortion.PortionFormat.Escapement = -25;
    subPortion.Text = "i";
    paragraph2.Portions.Add(subPortion);

    // Füge die Absätze dem Textfeld hinzu.
    textFrame.Paragraphs.Add(superPar);
    textFrame.Paragraphs.Add(paragraph2);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


Das Ergebnis:

![Hoch- und Tiefgestellt](superscript_and_subscript.png)

## **FAQ**

**Werden Hoch- und Tiefstellung beim Exportieren in PDF oder andere Formate beibehalten?**

Ja, Aspose.Slides für .NET bewahrt die Hoch‑ und Tiefstellung korrekt, wenn Präsentationen in PDF, PPT/PPTX, Bilder und andere unterstützte Formate exportiert werden. Die spezielle Formatierung bleibt in allen Ausgabedateien erhalten.

**Kann Hoch‑ und Tiefstellung mit anderen Formatierungsstilen wie Fett oder Kursiv kombiniert werden?**

Ja, Aspose.Slides ermöglicht das Mischen verschiedener Textstile innerhalb einer einzelnen Textportion. Sie können Fett, Kursiv, Unterstreichen aktivieren und gleichzeitig Hoch‑ oder Tiefstellung anwenden, indem Sie die entsprechenden Eigenschaften in [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) konfigurieren.

**Funktioniert die Hoch‑ und Tiefstellung für Text in Tabellen, Diagrammen oder SmartArt?**

Ja, Aspose.Slides für .NET unterstützt die Formatierung in den meisten Objekten, einschließlich Tabellen‑ und Diagrammelementen. Beim Arbeiten mit SmartArt müssen Sie auf die entsprechenden Elemente (wie [SmartArtNode](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartnode/)) und deren Textcontainer zugreifen und anschließend die [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/)‑Eigenschaften analog konfigurieren.