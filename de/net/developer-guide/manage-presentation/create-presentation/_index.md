---
title: Präsentation in .NET erstellen
linktitle: Präsentation erstellen
type: docs
weight: 10
url: /net/create-presentation/
keywords: "PowerPoint erstellen, PPTX, PPT, Präsentation erstellen, Präsentation initialisieren, C#, .NET"
description: "Programmatisches Erstellen von PowerPoint-Präsentationen in C#, z.B. PPT, PPTX, ODP etc."
---

## PowerPoint-Präsentation erstellen
Um eine einfache gerade Linie zu einer ausgewählten Folie der Präsentation hinzuzufügen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der Klasse Presentation.
1. Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
1. Fügen Sie eine AutoShape vom Typ Linie mit der Methode AddAutoShape hinzu, die vom Shapes-Objekt bereitgestellt wird.
1. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Im folgenden Beispiel haben wir eine Linie zur ersten Folie der Präsentation hinzugefügt.

```c#
// Instanziieren Sie ein Präsentationsobjekt, das eine Präsentationsdatei darstellt
using (Presentation presentation = new Presentation())
{
    // Holen Sie sich die erste Folie
    ISlide slide = presentation.Slides[0];

    // Fügen Sie eine AutoShape vom Typ Linie hinzu
    slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
    presentation.Save("NewPresentation_out.pptx", SaveFormat.Pptx);
}
```

## Präsentation erstellen und speichern

<a name="csharp-create-save-presentation"><strong>Schritte: Präsentation in C# erstellen und speichern</strong></a>

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) Klasse.
2. Speichern Sie _Presentation_ in ein beliebiges von [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/) unterstütztes Format.

```c#
Presentation presentation = new Presentation();

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```

## Präsentation öffnen und speichern

<a name="csharp-open-save-presentation"><strong>Schritte: Präsentation in C# öffnen und speichern</strong></a>

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) Klasse mit einem beliebigen Format, d.h. PPT, PPTX, ODP etc.
2. Speichern Sie _Presentation_ in ein beliebiges von [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/) unterstütztes Format.

```c#
// Laden Sie eine beliebige unterstützte Datei in Presentation, z.B. ppt, pptx, odp etc.
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```