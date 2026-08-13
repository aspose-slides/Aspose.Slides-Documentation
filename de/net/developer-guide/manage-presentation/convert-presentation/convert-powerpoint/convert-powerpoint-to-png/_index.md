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
description: "PowerPoint-Präsentationen schnell in hochwertige PNG-Bilder konvertieren mit Aspose.Slides für .NET, um präzise, automatisierte Ergebnisse zu gewährleisten."
---
## **Übersicht**

Dieser Artikel erklärt, wie PowerPoint‑Präsentationen mit Aspose.Slides in PNG‑Bilder konvertiert werden. Er zeigt, wie Präsentationsdateien in Formaten wie PPT, PPTX und ODP geladen, Folien als Bilder gerendert und die Ergebnisse im PNG‑Format gespeichert werden.

Der Artikel demonstriert zudem, wie die erzeugten PNG‑Bilder durch Festlegen von Skalierungswerten oder durch Angabe der gewünschten Breite und Höhe angepasst werden können.

## **PowerPoint in PNG konvertieren**

Befolgen Sie diese Schritte:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation) Klasse.
2. Holen Sie das Folienobjekt aus der [Presentation.Slides](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/properties/slides) Sammlung über die [ISlide](https://reference.aspose.com/slides/de/net/aspose.slides/islide) Schnittstelle.
3. Verwenden Sie die [ISlide.GetImage(float, float)](https://reference.aspose.com/slides/de/net/aspose.slides/islide/getimage/) Methode, um jede Folie in dem von Ihnen benötigten Maßstab zu rendern.
4. Verwenden Sie die [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/de/net/aspose.slides.ipresentation/save/methods/5) Methode, um das Folien‑Thumbnail im PNG‑Format zu speichern.

Dieser C#‑Code zeigt, wie eine PowerPoint‑Präsentation in PNG konvertiert wird. Das Presentation‑Objekt kann PPT, PPTX, ODP usw. laden, und jede Folie im Presentation‑Objekt wird in das PNG‑Format oder ein anderes Bildformat konvertiert.

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(1f, 1f))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

{{% alert color="info" %}} 
**Hinweis:** Die Skalierungsargumente `1f, 1f` rendern jede Folie in voller Größe, sodass eine 720×540 pt Folie ein 720×540 px Bild erzeugt. Die parameterlose [GetImage()](https://reference.aspose.com/slides/de/net/aspose.slides/islide/getimage/) Überladung liefert stattdessen ein viel kleineres Vorschau‑Thumbnail. 
{{% /alert %}} 

## **PowerPoint in PNG mit benutzerdefinierten Abmessungen konvertieren**

Wenn Sie PNG‑Dateien in einem bestimmten Maßstab erhalten möchten, können Sie die Werte für `desiredX` und `desiredY` festlegen, die die Abmessungen des resultierenden Thumbnails bestimmen.

Dieser C#‑Code demonstriert den beschriebenen Vorgang:

```c#
using Aspose.Slides;

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

Dieser Code zeigt, wie Sie ein PowerPoint in PNG konvertieren und dabei die Größe der Bilder angeben:

```c#
using System.Drawing;
using Aspose.Slides;

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

### Wie kann ich nur eine bestimmte Form (z. B. Diagramm oder Bild) anstelle der gesamten Folie exportieren?

Aspose.Slides unterstützt das [Erzeugen von Thumbnails für einzelne Formen](/slides/de/net/create-shape-thumbnails/); Sie können eine Form in ein PNG‑Bild rendern.

### Wird die parallele Konvertierung auf einem Server unterstützt?

Ja, aber [teilen Sie](/slides/de/net/multithreading/) eine einzelne Präsentationsinstanz nicht über Threads hinweg. Verwenden Sie pro Thread oder Prozess eine separate Instanz.

### Welche Einschränkungen hat die Testversion beim Export nach PNG?

Der Evaluierungsmodus fügt den Ausgabebildern ein Wasserzeichen hinzu und erzwingt [weitere Einschränkungen](/slides/de/net/licensing/), bis eine Lizenz angewendet wird.