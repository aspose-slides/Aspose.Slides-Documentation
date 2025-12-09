---
title: PowerPoint‑Präsentationen in .NET in Word‑Dokumente konvertieren
linktitle: PowerPoint zu Word
type: docs
weight: 110
url: /de/net/convert-powerpoint-to-word/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPT konvertieren
- PPTX konvertieren
- PowerPoint zu Word
- Präsentation zu Word
- Folie zu Word
- PPT zu Word
- PPTX zu Word
- PowerPoint zu DOCX
- Präsentation zu DOCX
- Folie zu DOCX
- PPT zu DOCX
- PPTX zu DOCX
- PowerPoint zu DOC
- Präsentation zu DOC
- Folie zu DOC
- PPT zu DOC
- PPTX zu DOC
- PPT als DOCX speichern
- PPTX als DOCX speichern
- PPT nach DOCX exportieren
- PPTX nach DOCX exportieren
- .NET
- C#
- Aspose.Slides
description: "PowerPoint PPT‑ und PPTX‑Folien in editierbare Word‑Dokumente in C# konvertieren, wobei Aspose.Slides für .NET verwendet wird und das genaue Layout, Bilder und Formatierung erhalten bleiben."
---

## **Übersicht**

Dieser Artikel bietet Entwicklern eine Lösung zum Konvertieren von PowerPoint- und OpenDocument‑Präsentationen in Word‑Dokumente mithilfe von Aspose.Slides für .NET und Aspose.Words für .NET. Die Schritt‑für‑Schritt‑Anleitung führt Sie durch jede Phase des Konvertierungsprozesses.

## **Eine Präsentation in ein Word‑Dokument konvertieren**

Befolgen Sie die nachstehenden Anweisungen, um eine PowerPoint‑ oder OpenDocument‑Präsentation in ein Word‑Dokument zu konvertieren:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Klasse und laden Sie eine Präsentationsdatei.
2. Instanziieren Sie die Klassen [Document](https://reference.aspose.com/words/net/aspose.words/document/) und [DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/), um ein Word‑Dokument zu erzeugen.
3. Legen Sie die Seitengröße des Word‑Dokuments mithilfe der Eigenschaft [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/) fest, damit sie der der Präsentation entspricht.
4. Setzen Sie die Ränder im Word‑Dokument mithilfe der Eigenschaft [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/).
5. Durchlaufen Sie alle Folien der Präsentation über die Eigenschaft [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/).
    - Generieren Sie ein Folien‑Bild mit der Methode `GetImage` aus der Schnittstelle [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/) und speichern Sie es in einen Memory‑Stream.
    - Fügen Sie das Folien‑Bild zum Word‑Dokument hinzu, indem Sie die Methode `InsertImage` der Klasse [DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/) verwenden.
6. Speichern Sie das Word‑Dokument in einer Datei.

Angenommen, wir haben eine Präsentation "sample.pptx", die folgendermaßen aussieht:

![PowerPoint‑Präsentation](PowerPoint.png)

Das folgende C#‑Code‑Beispiel zeigt, wie die PowerPoint‑Präsentation in ein Word‑Dokument konvertiert wird:
```cs
// Lade eine Präsentationsdatei.
using var presentation = new Presentation("sample.pptx");

// Erstelle Document- und DocumentBuilder-Objekte.
var document = new Document();
var builder = new DocumentBuilder(document);

// Setze die Seitengröße im Word-Dokument.
var slideSize = presentation.SlideSize.Size;
builder.PageSetup.PageWidth = slideSize.Width;
builder.PageSetup.PageHeight = slideSize.Height;

// Setze die Ränder im Word-Dokument.
builder.PageSetup.LeftMargin = 0;
builder.PageSetup.RightMargin = 0;
builder.PageSetup.TopMargin = 0;
builder.PageSetup.BottomMargin = 0;

const float scaleX = 2, scaleY = 2;

// Durchlaufe alle Folien der Präsentation.
foreach (var slide in presentation.Slides)
{
    // Erstelle ein Folienbild und speichere es in einen Memory-Stream.
    using var image = slide.GetImage(scaleX, scaleY);
    using var imageStream = new MemoryStream();
    image.Save(imageStream, ImageFormat.Png);

    // Füge das Folienbild dem Word-Dokument hinzu.
    imageStream.Seek(0, SeekOrigin.Begin);
    builder.InsertImage(imageStream.ToArray(), builder.PageSetup.PageWidth, builder.PageSetup.PageHeight);

    builder.InsertBreak(BreakType.PageBreak);
}

// Speichere das Word-Dokument in einer Datei.
document.Save("output.docx");
```


Das Ergebnis:

![Word‑Dokument](Word.png)

{{% alert color="primary" %}} 
Probieren Sie unseren [**Online PPT‑zu‑Word‑Converter**](https://products.aspose.app/slides/conversion/ppt-to-word) aus, um zu sehen, welchen Nutzen Sie aus der Konvertierung von PowerPoint‑ und OpenDocument‑Präsentationen in Word‑Dokumente ziehen können. 
{{% /alert %}}

## **FAQ**

**Welche Komponenten müssen installiert sein, um PowerPoint‑ und OpenDocument‑Präsentationen in Word‑Dokumente zu konvertieren?**

Sie müssen lediglich die entsprechenden NuGet‑Pakete für [Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET) und [Aspose.Words for .NET](https://www.nuget.org/packages/Aspose.Words/) zu Ihrem C#‑Projekt hinzufügen. Beide Bibliotheken funktionieren als eigenständige APIs, und es ist nicht erforderlich, Microsoft Office zu installieren.

**Werden alle PowerPoint‑ und OpenDocument‑Präsentationsformate unterstützt?**

Aspose.Slides für .NET [unterstützt alle Präsentationsformate](/slides/de/net/supported-file-formats/), einschließlich PPT, PPTX, ODP und anderer gängiger Dateitypen. Dadurch können Sie mit Präsentationen arbeiten, die in verschiedenen Versionen von Microsoft PowerPoint erstellt wurden.