---
title: Verwaltung von Tags und benutzerdefinierten Daten
type: docs
weight: 300
url: /net/managing-tags-and-custom-data
keywords: "Tags, Benutzerdefinierte Daten, Wert für Tags, Tags hinzufügen, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Tags und benutzerdefinierte Daten zu PowerPoint-Präsentationen in C# oder .NET hinzufügen"
---

## Datenspeicherung in Präsentationsdateien

PPTX-Dateien – Elemente mit der .pptx-Erweiterung – werden im PresentationML-Format gespeichert, das Teil der Office Open XML-Spezifikation ist. Das Office Open XML-Format definiert die Struktur für Daten, die in Präsentationen enthalten sind. 

Mit einer *Folie*, die eines der Elemente in Präsentationen ist, enthält ein *Folienabschnitt* den Inhalt einer einzelnen Folie. Ein Folienabschnitt darf explizite Beziehungen zu vielen Teilen haben – wie z. B. benutzerdefinierte Tags – die durch ISO/IEC 29500 definiert sind. 

Benutzerdefinierte Daten (spezifisch für eine Präsentation) oder Benutzer können als Tags ([ITagCollection](https://reference.aspose.com/slides/net/aspose.slides/itagcollection)) und CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/net/aspose.slides/icustomxmlpartcollection)) existieren. 

{{% alert color="primary" %}} 

Tags sind im Wesentlichen Schlüssel-Wert-Paarwerte von Typ String. 

{{% /alert %}} 

## Abrufen der Werte für Tags

In Folien entspricht ein Tag der IDocumentProperties.Keywords-Eigenschaft. Dieser Beispielcode zeigt Ihnen, wie Sie den Wert eines Tags mit Aspose.Slides für .NET für [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) abrufen können:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   string keywords = pres.DocumentProperties.Keywords;
}
```

## Hinzufügen von Tags zu Präsentationen

Aspose.Slides ermöglicht es Ihnen, Tags zu Präsentationen hinzuzufügen. Ein Tag besteht typischerweise aus zwei Elementen: 

- dem Namen eines benutzerdefinierten Attributs - `MyTag` 
- dem Wert des benutzerdefinierten Attributs - `My Tag Value`

Wenn Sie einige Präsentationen basierend auf einer bestimmten Regel oder Eigenschaft klassifizieren müssen, profitieren Sie möglicherweise davon, Tags zu diesen Präsentationen hinzuzufügen. Wenn Sie beispielsweise alle Präsentationen aus nordamerikanischen Ländern kategorisieren oder zusammenfassen möchten, können Sie ein nordamerikanisches Tag erstellen und die entsprechenden Länder (die USA, Mexiko und Kanada) als Werte zuweisen. 

Dieser Beispielcode zeigt Ihnen, wie Sie ein Tag zu einer [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) mit Aspose.Slides für .NET hinzufügen können:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ITagCollection tags = pres.CustomData.Tags;
   pres.CustomData.Tags["MyTag"] = "My Tag Value";
}
```

Tags können auch für [Slide](https://reference.aspose.com/slides/net/aspose.slides/slide) gesetzt werden:

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    slide.CustomData.Tags["tag"] = "value";
}
```

Oder für jede einzelne [Shape](https://reference.aspose.com/slides/net/aspose.slides/shape):

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.TextFrame.Text = "Mein Text";
    shape.CustomData.Tags["tag"] = "value";
}
```