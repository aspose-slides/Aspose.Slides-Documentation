---
title: "PowerPoint zu PNG in C# konvertieren"
linktitle: "PowerPoint zu PNG konvertieren"
type: docs
weight: 30
url: /de/net/convert-powerpoint-to-png/
keywords:
- "PowerPoint zu PNG"
- "ppt zu PNG"
- "pptx zu PNG"
- "odp zu PNG"
- "PowerPoint zu PNG"
- "PPT zu PNG"
- "PPTX zu PNG"
- "ODP zu PNG"
- "C#"
- "Csharp"
- "Aspose.Slides for .NET"
description: "PowerPoint-Präsentation in PNG konvertieren in C#. PPT in PNG konvertieren in C#. PPTX in PNG konvertieren in C#. ODP in PNG konvertieren in C#"
---

## **Übersicht**

Dieser Artikel erklärt, wie man PowerPoint‑Präsentationen mit C# in das PNG‑Format konvertiert. Er behandelt die folgenden Themen.

- [PowerPoint in PNG konvertieren in C#](#convert-powerpoint-to-png)
- [PPT in PNG konvertieren in C#](#convert-powerpoint-to-png)
- [PPTX in PNG konvertieren in C#](#convert-powerpoint-to-png)
- [ODP in PNG konvertieren in C#](#convert-powerpoint-to-png)
- [PowerPoint‑Folien in Bild konvertieren in C#](#convert-powerpoint-to-png)

## **C# PowerPoint zu PNG**

Für C#‑Beispielcode zum Konvertieren von PowerPoint in PNG siehe bitte den untenstehenden Abschnitt, d. h. [PowerPoint in PNG konvertieren](#convert-powerpoint-to-png). Der Code kann verschiedene Formate wie PPT, PPTX und ODP im Presentation‑Objekt laden und anschließend das Folien‑Thumbnail im PNG‑Format speichern. Die anderen PowerPoint‑zu‑Bild‑Konvertierungen, die ähnlich sind, wie JPG, BMP, TIFF und SVG, werden in diesen Artikeln behandelt.

- [C# PowerPoint zu JPG](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [C# PowerPoint zu BMP](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [C# PowerPoint zu TIFF](https://docs.aspose.com/slides/net/convert-powerpoint-to-tiff/)
- [C# PowerPoint zu SVG](https://docs.aspose.com/slides/net/render-a-slide-as-an-svg-image/)

## **Über die PowerPoint‑zu‑PNG‑Konvertierung**

Das PNG‑Format (Portable Network Graphics) ist nicht so populär wie JPEG (Joint Photographic Experts Group), aber immer noch sehr verbreitet.

**Anwendungsfall:** Wenn Sie ein komplexes Bild haben und die Größe kein Problem darstellt, ist PNG ein besseres Bildformat als JPEG.

{{% alert title="Tip" color="primary" %}} Vielleicht möchten Sie die kostenlosen Aspose **PowerPoint zu PNG‑Konverter** ausprobieren: [PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) und [PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Sie sind eine Live‑Implementierung des auf dieser Seite beschriebenen Prozesses. {{% /alert %}}

## **PowerPoint in PNG konvertieren**

Führen Sie die folgenden Schritte aus:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
2. Rufen Sie das Folienobjekt aus der [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides)-Sammlung über die [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide)-Schnittstelle ab.
3. Verwenden Sie die Methode [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/), um das Thumbnail für jede Folie zu erhalten.
4. Verwenden Sie die Methode [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/net/aspose.slides.ipresentation/save/methods/5), um das Folien‑Thumbnail im PNG‑Format zu speichern.

Dieser C#‑Code zeigt, wie man eine PowerPoint‑Präsentation in PNG konvertiert. Das Presentation‑Objekt kann PPT, PPTX, ODP usw. laden, und dann wird jede Folie im Presentation‑Objekt in das PNG‑Format oder ein anderes Bildformat konvertiert.
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

Wenn Sie PNG‑Dateien in einem bestimmten Maßstab erhalten möchten, können Sie die Werte für `desiredX` und `desiredY` festlegen, die die Abmessungen des resultierenden Thumbnails bestimmen.

Dieser C#‑Code demonstriert den beschriebenen Vorgang:
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

Wenn Sie PNG‑Dateien in einer bestimmten Größe erhalten möchten, können Sie Ihre bevorzugten `width`‑ und `height`‑Argumente für `imageSize` übergeben.

Dieser Code zeigt, wie man ein PowerPoint‑Dokument in PNG konvertiert, wobei die Größe der Bilder angegeben wird:
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


## **FAQ**

**Wie kann ich nur eine bestimmte Form (z. B. Diagramm oder Bild) exportieren, anstatt die gesamte Folie?**  
Aspose.Slides unterstützt das [Erstellen von Thumbnails für einzelne Formen](/slides/de/net/create-shape-thumbnails/); Sie können eine Form als PNG‑Bild rendern.

**Wird die parallele Konvertierung auf einem Server unterstützt?**  
Ja, jedoch sollten Sie eine einzelne Presentation‑Instanz nicht über mehrere Threads hinweg [teilen](/slides/de/net/multithreading/). Verwenden Sie pro Thread oder Prozess eine separate Instanz.

**Was sind die Einschränkungen der Testversion beim Exportieren nach PNG?**  
Der Evaluierungsmodus fügt den Ausgabebildern ein Wasserzeichen hinzu und erzwingt [weitere Einschränkungen](/slides/de/net/licensing/), bis eine Lizenz angewendet wird.