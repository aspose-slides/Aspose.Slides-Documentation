---
title: PowerPoint-Folien in PNG konvertieren in .NET
linktitle: PowerPoint zu PNG
type: docs
weight: 30
url: /de/net/convert-powerpoint-to-png/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPT konvertieren
- PPTX konvertieren
- PowerPoint zu PNG
- Präsentation zu PNG
- Folie zu PNG
- PPT zu PNG
- PPTX zu PNG
- PPT als PNG speichern
- PPTX als PNG speichern
- PPT nach PNG exportieren
- PPTX nach PNG exportieren
- .NET
- C#
- Aspose.Slides
description: "PowerPoint-Präsentationen schnell in hochwertige PNG-Bilder konvertieren mit Aspose.Slides für .NET und dabei präzise, automatisierte Ergebnisse gewährleisten."
---

## **Übersicht**

Dieser Artikel erklärt, wie man PowerPoint‑Präsentationen mit C# in das PNG‑Format konvertiert. Er behandelt die folgenden Themen.

- [PowerPoint in PNG konvertieren in C#](#convert-powerpoint-to-png)
- [PPT in PNG konvertieren in C#](#convert-powerpoint-to-png)
- [PPTX in PNG konvertieren in C#](#convert-powerpoint-to-png)
- [ODP in PNG konvertieren in C#](#convert-powerpoint-to-png)
- [PowerPoint‑Folie in Bild konvertieren in C#](#convert-powerpoint-to-png)

## **C# PowerPoint zu PNG**

Für C#‑Beispielcode zum Konvertieren von PowerPoint in PNG siehe bitte den nachfolgenden Abschnitt, d. h. [PowerPoint in PNG konvertieren](#convert-powerpoint-to-png). Der Code kann verschiedene Formate wie PPT, PPTX und ODP im Presentation‑Objekt laden und anschließend die Folien‑Miniatur im PNG‑Format speichern. Die anderen PowerPoint‑zu‑Bild‑Konvertierungen, die ähnlich sind, wie JPG, BMP, TIFF und SVG, werden in diesen Artikeln behandelt.

- [C# PowerPoint zu JPG](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [C# PowerPoint zu BMP](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [C# PowerPoint zu TIFF](https://docs.aspose.com/slides/net/convert-powerpoint-to-tiff/)
- [C# PowerPoint zu SVG](https://docs.aspose.com/slides/net/render-a-slide-as-an-svg-image/)

## **Über die PowerPoint‑zu‑PNG-Konvertierung**

Das PNG‑Format (Portable Network Graphics) ist nicht so verbreitet wie JPEG (Joint Photographic Experts Group), ist aber weiterhin sehr beliebt.

**Anwendungsfall:** Wenn Sie ein komplexes Bild haben und die Größe kein Thema ist, ist PNG ein besseres Bildformat als JPEG.

{{% alert title="Tip" color="primary" %}} Vielleicht möchten Sie sich die kostenlosen Aspose **PowerPoint‑zu‑PNG‑Konverter** ansehen: [PPTX zu PNG](https://products.aspose.app/slides/conversion/pptx-to-png) und [PPT zu PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Sie sind eine Live‑Implementierung des auf dieser Seite beschriebenen Prozesses. {{% /alert %}}

## **PowerPoint zu PNG konvertieren**

Führen Sie die folgenden Schritte aus:

1. Instanziieren Sie die Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Rufen Sie das Folien‑Objekt aus der Sammlung [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides) über die Schnittstelle [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) ab.
3. Verwenden Sie die Methode [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/), um die Miniatur für jede Folie zu erhalten.
4. Verwenden Sie die Methode [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/net/aspose.slides.ipresentation/save/methods/5), um die Folien‑Miniatur im PNG-Format zu speichern.

Dieser C#‑Code zeigt, wie man eine PowerPoint‑Präsentation in PNG konvertiert. Das Presentation‑Objekt kann PPT, PPTX, ODP usw. laden, und jede Folie im Presentation‑Objekt wird dann in das PNG-Format oder ein anderes Bildformat konvertiert.
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


## **PowerPoint zu PNG mit benutzerdefinierten Abmessungen konvertieren**

Wenn Sie PNG‑Dateien in einer bestimmten Größe erhalten möchten, können Sie die Werte für `desiredX` und `desiredY` festlegen, die die Abmessungen der resultierenden Miniatur bestimmen.

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


## **PowerPoint zu PNG mit benutzerdefinierter Größe konvertieren**

Wenn Sie PNG‑Dateien in einer bestimmten Größe erhalten möchten, können Sie die gewünschten `width`‑ und `height`‑Argumente für `imageSize` übergeben.

Dieser Code zeigt, wie man ein PowerPoint in PNG konvertiert, während man die Größe der Bilder angibt:
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

**Wie kann ich nur eine bestimmte Form (z. B. Diagramm oder Bild) statt der gesamten Folie exportieren?**  
Aspose.Slides unterstützt das [Erzeugen von Miniaturbildern für einzelne Formen](/slides/de/net/create-shape-thumbnails/); Sie können eine Form als PNG‑Bild rendern.

**Wird parallele Konvertierung auf einem Server unterstützt?**  
Ja, aber [nicht teilen](/slides/de/net/multithreading/) Sie keine einzelne Präsentationsinstanz über Threads hinweg. Verwenden Sie pro Thread oder Prozess eine separate Instanz.

**Was sind die Einschränkungen der Testversion beim Exportieren nach PNG?**  
Der Evaluierungsmodus fügt den Ausgabebildern ein Wasserzeichen hinzu und erzwingt [weitere Einschränkungen](/slides/de/net/licensing/), bis eine Lizenz angewendet wird.