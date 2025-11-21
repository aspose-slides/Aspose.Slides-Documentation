---
title: PowerPoint-Präsentationen zu animierten GIFs konvertieren in .NET
linktitle: PowerPoint zu GIF
type: docs
weight: 65
url: /de/net/convert-powerpoint-to-animated-gif/
keywords:
- animiertes GIF
- PowerPoint konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPT konvertieren
- PPTX konvertieren
- PowerPoint zu GIF
- Präsentation zu GIF
- Folie zu GIF
- PPT zu GIF
- PPTX zu GIF
- PPT als GIF speichern
- PPTX als GIF speichern
- PPT als GIF exportieren
- PPTX als GIF exportieren
- Standardeinstellungen
- Benutzerdefinierte Einstellungen
- .NET
- C#
- Aspose.Slides
description: "Einfach PowerPoint-Präsentationen (PPT, PPTX) mit Aspose.Slides für .NET in animierte GIFs konvertieren. Schnell, hochwertige Ergebnisse."
---

## **Präsentationen mit Standardeinstellungen in animiertes GIF konvertieren**

Dieser Beispielcode in C# zeigt, wie Sie eine Präsentation mit den Standard­einstellungen in ein animiertes GIF konvertieren:
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif);
}
```


Das animierte GIF wird mit den Standardparametern erstellt. 

{{%  alert  title="TIP"  color="primary"  %}} 
Wenn Sie die Parameter für das GIF anpassen möchten, können Sie die Klasse [GifOptions](https://reference.aspose.com/slides/net/aspose.slides.export/gifoptions) verwenden. Der Beispielcode befindet sich unten. 
{{% /alert %}} 

## **Präsentationen mit benutzerdefinierten Einstellungen in animiertes GIF konvertieren**

Dieser Beispielcode zeigt, wie Sie eine Präsentation mit benutzerdefinierten Einstellungen in C# in ein animiertes GIF konvertieren:
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif, new GifOptions
    {
        FrameSize = new Size(960, 720), // die Größe des resultierenden GIF
        DefaultDelay = 2000, // wie lange jede Folie angezeigt wird, bis sie zur nächsten wechselt
        TransitionFps = 35 // erhöhen Sie die FPS für bessere Übergangsanimationsqualität
    });
}
```


{{% alert title="Info" color="info" %}}
Vielleicht möchten Sie den KOSTENLOSEN [Text to GIF](https://products.aspose.app/slides/text-to-gif)-Konverter von Aspose ausprobieren. 
{{% /alert %}}

## **FAQ**

**Was ist, wenn die in der Präsentation verwendeten Schriftarten nicht auf dem System installiert sind?**

Installieren Sie die fehlenden Schriftarten oder [konfigurieren Sie Ersatzschriftarten](/slides/de/net/powerpoint-fonts/). Aspose.Slides wird sie ersetzen, aber das Erscheinungsbild kann abweichen. Für das Branding sollten die erforderlichen Schriftarten immer explizit verfügbar sein.

**Kann ich ein Wasserzeichen auf die GIF‑Frames legen?**

Ja. [Fügen Sie ein halbtransparentes Objekt/Logo](/slides/de/net/watermark/) zur Master‑Folien oder zu einzelnen Folien vor dem Export hinzu — das Wasserzeichen erscheint auf jedem Frame.