---
title: PowerPoint in PNG konvertieren in C#
linktitle: PowerPoint in PNG konvertieren
type: docs
weight: 30
url: /net/convert-powerpoint-to-png/
keywords:
- PowerPoint in png
- ppt in png
- pptx in png
- odp in png
- PowerPoint in PNG
- PPT in PNG
- PPTX in PNG
- ODP in PNG
- C#
- Csharp
- Aspose.Slides für .NET
description: Konvertieren Sie eine PowerPoint-Präsentation in PNG in C#. Konvertieren Sie PPT in PNG in C#. Konvertieren Sie PPTX in PNG in C#. Konvertieren Sie ODP in PNG in C#
---

## **Überblick**

Dieser Artikel erklärt, wie man eine PowerPoint-Präsentation im PNG-Format mit C# konvertiert. Die folgenden Themen werden behandelt.

- [PowerPoint in PNG in C# konvertieren](#convert-powerpoint-to-png)
- [PPT in PNG in C# konvertieren](#convert-powerpoint-to-png)
- [PPTX in PNG in C# konvertieren](#convert-powerpoint-to-png)
- [ODP in PNG in C# konvertieren](#convert-powerpoint-to-png)
- [PowerPoint-Folie in Bild in C# konvertieren](#convert-powerpoint-to-png)

## **C# PowerPoint in PNG**

Für C#-Beispielcode zur Konvertierung von PowerPoint in PNG siehe den Abschnitt unten, dh. [PowerPoint in PNG konvertieren](#convert-powerpoint-to-png). Der Code kann zahlreiche Formate wie PPT, PPTX und ODP im Presentation-Objekt laden und dann das Miniaturbild seiner Folie im PNG-Format speichern. Die anderen PowerPoint-zu-Bild-Konvertierungen, die ähnlich sind wie JPG, BMP, TIFF und SVG, werden in diesen Artikeln behandelt.

- [C# PowerPoint in JPG](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [C# PowerPoint in BMP](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [C# PowerPoint in TIFF](https://docs.aspose.com/slides/net/convert-powerpoint-to-tiff/)
- [C# PowerPoint in SVG](https://docs.aspose.com/slides/net/render-a-slide-as-an-svg-image/)

## **Über die PowerPoint-zu-PNG-Konvertierung**

Das PNG (Portable Network Graphics) Format ist nicht so beliebt wie JPEG (Joint Photographic Experts Group), aber es ist immer noch sehr beliebt.

**Anwendungsfall:** Wenn Sie ein komplexes Bild haben und die Größe kein Problem darstellt, ist PNG ein besseres Bildformat als JPEG.

{{% alert title="Tipp" color="primary" %}} Sie sollten die kostenlosen **PowerPoint zu PNG-Konverter** von Aspose ausprobieren: [PPTX zu PNG](https://products.aspose.app/slides/conversion/pptx-to-png) und [PPT zu PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Sie sind eine Live-Implementierung des auf dieser Seite beschriebenen Prozesses. {{% /alert %}}

## **PowerPoint in PNG konvertieren**

Gehen Sie diese Schritte durch:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
2. Holen Sie sich das Foliendarstellung-Objekt aus der [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides) Sammlung unter dem [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) Interface.
3. Verwenden Sie eine [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) Methode, um das Miniaturbild für jede Folie zu erhalten.
4. Verwenden Sie die [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/net/aspose.slides.ipresentation/save/methods/5) Methode, um das Foliensminiaturbild im PNG-Format zu speichern.

Dieser C#-Code zeigt Ihnen, wie Sie eine PowerPoint-Präsentation in PNG konvertieren können. Das Präsentationsobjekt kann PPT, PPTX, ODP usw. laden, dann wird jede Folie im Präsentationsobjekt in das PNG-Format oder andere Bildformate konvertiert.

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage())
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **PowerPoint in PNG mit benutzerdefinierten Abmessungen konvertieren**

Wenn Sie PNG-Dateien in einem bestimmten Maßstab erstellen möchten, können Sie die Werte für `desiredX` und `desiredY` festlegen, die die Abmessungen des resultierenden Miniaturbilds bestimmen.

Dieser C#-Code demonstriert die beschriebene Operation:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    float scaleX = 2f;
    float scaleY = 2f;
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(scaleX, scaleY))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **PowerPoint in PNG mit benutzerdefinierter Größe konvertieren**

Wenn Sie PNG-Dateien in einer bestimmten Größe erstellen möchten, können Sie Ihre bevorzugten `width` und `height` Argumente für `imageSize` übergeben.

Dieser Code zeigt Ihnen, wie Sie eine PowerPoint in PNG konvertieren, während Sie die Größe für die Bilder angeben:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Size size = new Size(960, 720);
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(size))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```