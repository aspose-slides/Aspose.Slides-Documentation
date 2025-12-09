---
title: PowerPoint‑Folien in PNG konvertieren in .NET
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
- .NET
- C#
- Aspose.Slides
description: "Konvertieren Sie PowerPoint‑Präsentationen schnell in hochwertige PNG‑Bilder mit Aspose.Slides für .NET und erhalten Sie präzise, automatisierte Ergebnisse."
---

## **Übersicht**

Dieser Artikel erklärt, wie man PowerPoint‑Präsentationen mit C# in das PNG‑Format konvertiert. Er behandelt die folgenden Themen.

- [PowerPoint in PNG konvertieren in C#](#convert-powerpoint-to-png)
- [PPT in PNG konvertieren in C#](#convert-powerpoint-to-png)
- [PPTX in PNG konvertieren in C#](#convert-powerpoint-to-png)
- [ODP in PNG konvertieren in C#](#convert-powerpoint-to-png)
- [PowerPoint‑Folie in Bild konvertieren in C#](#convert-powerpoint-to-png)

## **C# PowerPoint zu PNG**

Für C#‑Beispielcode zum Konvertieren von PowerPoint in PNG siehe bitte den Abschnitt weiter unten, d.h. [PowerPoint in PNG konvertieren](#convert-powerpoint-to-png). Der Code kann verschiedene Formate wie PPT, PPTX und ODP im Presentation‑Objekt laden und anschließend die Folien‑Miniatur im PNG‑Format speichern. Die anderen PowerPoint‑zu‑Bild‑Konvertierungen, die ähnlich sind, wie JPG, BMP, TIFF und SVG, werden in diesen Artikeln behandelt.

- [C# PowerPoint zu JPG](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [C# PowerPoint zu BMP](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [C# PowerPoint zu TIFF](https://docs.aspose.com/slides/net/convert-powerpoint-to-tiff/)
- [C# Powerpoint zu SVG](https://docs.aspose.com/slides/net/render-a-slide-as-an-svg-image/)

## **Über die PowerPoint‑zu‑PNG‑Konvertierung**

Das PNG‑Format (Portable Network Graphics) ist nicht so verbreitet wie JPEG (Joint Photographic Experts Group), bleibt aber dennoch sehr populär.

**Anwendungsfall:** Wenn Sie ein komplexes Bild haben und die Größe kein Problem darstellt, ist PNG ein besseres Bildformat als JPEG.

{{% alert title="Tip" color="primary" %}} Vielleicht möchten Sie sich Aspose kostenlose **PowerPoint‑zu‑PNG‑Konverter** ansehen: [PPTX zu PNG](https://products.aspose.app/slides/conversion/pptx-to-png) und [PPT zu PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Sie sind eine Live‑Implementierung des auf dieser Seite beschriebenen Prozesses. {{% /alert %}}

## **PowerPoint in PNG konvertieren**

Führen Sie die folgenden Schritte aus:

1. Instanziieren Sie die Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Rufen Sie das Folienobjekt aus der Sammlung [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides) unter dem Interface [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) ab.
3. Verwenden Sie die Methode [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/), um die Miniatur für jede Folie zu erhalten.
4. Verwenden Sie die Methode [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/net/aspose.slides.ipresentation/save/methods/5), um die Folien‑Miniatur im PNG‑Format zu speichern.

Dieser C#‑Code zeigt, wie man eine PowerPoint‑Präsentation in PNG konvertiert. Das Presentation‑Objekt kann PPT, PPTX, ODP usw. laden, und dann wird jede Folie im Presentation‑Objekt in das PNG‑Format oder andere Bildformate konvertiert.
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

Wenn Sie PNG‑Dateien in einem bestimmten Maßstab erhalten möchten, können Sie die Werte für `desiredX` und `desiredY` festlegen, die die Abmessungen der resultierenden Miniatur bestimmen.

Der folgende C#‑Code demonstriert den beschriebenen Vorgang:
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

Wenn Sie PNG‑Dateien in einer bestimmten Größe erhalten möchten, können Sie die gewünschten Argumente `width` und `height` für `imageSize` übergeben.

Der folgende Code zeigt, wie man eine PowerPoint‑Präsentation in PNG konvertiert und dabei die Bildgröße festlegt:
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

**Wie kann ich nur eine bestimmte Form (z. B. ein Diagramm oder ein Bild) statt der gesamten Folie exportieren?**  
Aspose.Slides unterstützt das [Erzeugen von Miniaturbildern für einzelne Formen](/slides/de/net/create-shape-thumbnails/); Sie können eine Form als PNG‑Bild rendern.

**Wird parallele Konvertierung auf einem Server unterstützt?**  
Ja, aber [teilen Sie](/slides/de/net/multithreading/) eine einzelne Presentation‑Instanz nicht über Threads hinweg. Verwenden Sie für jeden Thread oder Prozess eine separate Instanz.

**Welche Einschränkungen hat die Testversion beim Exportieren nach PNG?**  
Der Evaluierungsmodus fügt den Ausgabebildern ein Wasserzeichen hinzu und erzwingt [weitere Einschränkungen](/slides/de/net/licensing/), bis eine Lizenz angewendet wird.