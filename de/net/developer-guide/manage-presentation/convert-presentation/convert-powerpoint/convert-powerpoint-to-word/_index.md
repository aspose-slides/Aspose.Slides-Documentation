---
title: PowerPoint-Präsentationen in Word-Dokumente mit C# konvertieren
linktitle: PowerPoint in Word konvertieren
type: docs
weight: 110
url: /de/net/convert-powerpoint-to-word/
keywords:
- PowerPoint zu DOCX
- OpenDocument zu DOCX
- Präsentation zu DOCX
- Folie zu DOCX
- PPT zu DOCX
- PPTX zu DOCX
- ODP zu DOCX
- PowerPoint zu DOC
- OpenDocument zu DOC
- Präsentation zu DOC
- Folie zu DOC
- PPT zu DOC
- PPTX zu DOC
- ODP zu DOC
- PowerPoint zu Word
- OpenDocument zu Word
- Präsentation zu Word
- Folie zu Word
- PPT zu Word
- PPTX zu Word
- ODP zu Word
- PowerPoint konvertieren
- OpenDocument konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPT konvertieren
- PPTX konvertieren
- ODP konvertieren
- C#
- .NET
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint- und OpenDocument-Präsentationen mühelos in Word-Dokumente mit Aspose.Slides für .NET konvertieren können. Unser schritt-für-Schritt-Leitfaden mit Beispiel-C#-Code bietet Entwicklern die Lösung, um ihre Dokumenten-Workflows zu optimieren."
---

## **Übersicht**

Dieser Artikel bietet Entwicklern eine Lösung zum Konvertieren von PowerPoint‑ und OpenDocument‑Präsentationen in Word‑Dokumente mit Aspose.Slides für .NET und Aspose.Words für .NET. Die schrittweise Anleitung führt Sie durch jeden Schritt des Konvertierungsprozesses.

## **Präsentation in ein Word‑Dokument konvertieren**

Befolgen Sie die nachstehenden Anweisungen, um eine PowerPoint‑ oder OpenDocument‑Präsentation in ein Word‑Dokument zu konvertieren:

1. Instanziieren Sie die Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) und laden Sie eine Präsentationsdatei.
2. Instanziieren Sie die Klassen [Document](https://reference.aspose.com/words/net/aspose.words/document/) und [DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/), um ein Word‑Dokument zu erzeugen.
3. Setzen Sie die Seitengröße des Word‑Dokuments so, dass sie der Präsentation entspricht, indem Sie die Eigenschaft [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/) verwenden.
4. Legen Sie die Ränder im Word‑Dokument über die Eigenschaft [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/) fest.
5. Durchlaufen Sie alle Folien der Präsentation über die Eigenschaft [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/).
   - Erzeugen Sie ein Folien‑Bild mit der Methode `GetImage` aus der Schnittstelle [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/) und speichern Sie es in einen Speicherstrom.
   - Fügen Sie das Folien‑Bild dem Word‑Dokument mit der Methode `InsertImage` aus der Klasse [DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/) hinzu.
6. Speichern Sie das Word‑Dokument in einer Datei.

Angenommen, wir haben eine Präsentation "sample.pptx", die wie folgt aussieht:

![PowerPoint presentation](PowerPoint.png)

Das folgende C#‑Code‑Beispiel zeigt, wie die PowerPoint‑Präsentation in ein Word‑Dokument konvertiert wird:
```cs
// Laden einer Präsentationsdatei.
using var presentation = new Presentation("sample.pptx");

// Document- und DocumentBuilder-Objekte erstellen.
var document = new Document();
var builder = new DocumentBuilder(document);

// Seitengröße im Word-Dokument festlegen.
var slideSize = presentation.SlideSize.Size;
builder.PageSetup.PageWidth = slideSize.Width;
builder.PageSetup.PageHeight = slideSize.Height;

// Ränder im Word-Dokument festlegen.
builder.PageSetup.LeftMargin = 0;
builder.PageSetup.RightMargin = 0;
builder.PageSetup.TopMargin = 0;
builder.PageSetup.BottomMargin = 0;

const float scaleX = 2, scaleY = 2;

// Alle Folien der Präsentation durchlaufen.
foreach (var slide in presentation.Slides)
{
    // Folienbild erzeugen und in einen Speicherstream speichern.
    using var image = slide.GetImage(scaleX, scaleY);
    using var imageStream = new MemoryStream();
    image.Save(imageStream, ImageFormat.Png);

    // Folienbild zum Word-Dokument hinzufügen.
    imageStream.Seek(0, SeekOrigin.Begin);
    builder.InsertImage(imageStream.ToArray(), builder.PageSetup.PageWidth, builder.PageSetup.PageHeight);

    builder.InsertBreak(BreakType.PageBreak);
}

// Word-Dokument in einer Datei speichern.
document.Save("output.docx");
```


Das Ergebnis:

![Word document](Word.png)

{{% alert color="primary" %}} 

Probieren Sie unseren **Online‑PPT‑zu‑Word‑Konverter** aus, um zu sehen, welchen Nutzen Sie aus der Konvertierung von PowerPoint‑ und OpenDocument‑Präsentationen in Word‑Dokumente ziehen können. 

{{% /alert %}}

## **FAQ**

**Welche Komponenten müssen installiert sein, um PowerPoint‑ und OpenDocument‑Präsentationen in Word‑Dokumente zu konvertieren?**

Sie müssen lediglich die entsprechenden NuGet‑Pakete für [Aspose.Slides für .NET](https://www.nuget.org/packages/Aspose.Slides.NET) und [Aspose.Words für .NET](https://www.nuget.org/packages/Aspose.Words/) zu Ihrem C#‑Projekt hinzufügen. Beide Bibliotheken funktionieren als eigenständige APIs, und es ist keine Installation von Microsoft Office erforderlich.

**Werden alle PowerPoint‑ und OpenDocument‑Präsentationsformate unterstützt?**

Aspose.Slides für .NET [unterstützt alle Präsentationsformate](/slides/de/net/supported-file-formats/), einschließlich PPT, PPTX, ODP und anderer gängiger Dateitypen. Damit können Sie mit Präsentationen arbeiten, die in verschiedenen Versionen von Microsoft PowerPoint erstellt wurden.