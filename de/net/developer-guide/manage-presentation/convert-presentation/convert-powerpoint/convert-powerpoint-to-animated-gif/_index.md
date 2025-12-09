---
title: PowerPoint-Präsentationen in .NET in animierte GIFs konvertieren
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
- benutzerdefinierte Einstellungen
- .NET
- C#
- Aspose.Slides
description: "Konvertieren Sie PowerPoint-Präsentationen (PPT, PPTX) mühelos in animierte GIFs mit Aspose.Slides für .NET. Schnell, hochwertige Ergebnisse."
---

## **Präsentationen mit Standardeinstellungen in animiertes GIF konvertieren**

Dieser Beispielcode in C# zeigt, wie Sie eine Präsentation mithilfe der Standardeinstellungen in ein animiertes GIF konvertieren:
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif);
}
```


Das animierte GIF wird mit den Standardparametern erstellt. 

{{%  alert  title="TIP"  color="primary"  %}} 

Wenn Sie die Parameter für das GIF anpassen möchten, können Sie die Klasse [GifOptions](https://reference.aspose.com/slides/net/aspose.slides.export/gifoptions) verwenden. Siehe den Beispielcode unten. 

{{% /alert %}} 

## **Präsentationen mit benutzerdefinierten Einstellungen in animiertes GIF konvertieren**

Dieser Beispielcode zeigt, wie Sie eine Präsentation mit benutzerdefinierten Einstellungen in ein animiertes GIF in C# konvertieren:
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif, new GifOptions
    {
        FrameSize = new Size(960, 720), // die Größe des resultierenden GIFs  
        DefaultDelay = 2000, // wie lange jede Folie angezeigt wird, bis sie zur nächsten wechselt
        TransitionFps = 35 // FPS erhöhen, um die Qualität der Übergangsanimation zu verbessern
    });
}
```


{{% alert title="Info" color="info" %}}

Vielleicht möchten Sie sich den KOSTENLOSEN [Text to GIF](https://products.aspose.app/slides/text-to-gif) Konverter von Aspose ansehen. 

{{% /alert %}}

## **FAQ**

**Was passiert, wenn die in der Präsentation verwendeten Schriftarten nicht auf dem System installiert sind?**

Installieren Sie die fehlenden Schriftarten oder [konfigurieren Sie Ersatzschriftarten](/slides/de/net/powerpoint-fonts/). Aspose.Slides ersetzt sie, aber das Aussehen kann abweichen. Für das Branding sollten die benötigten Schriftarten immer explizit verfügbar sein.

**Kann ich ein Wasserzeichen über die GIF‑Frames legen?**

Ja. [Fügen Sie ein halbtransparentes Objekt/Logo](/slides/de/net/watermark/) zur Master‑Folien oder zu einzelnen Folien vor dem Export hinzu — das Wasserzeichen wird auf jedem Frame angezeigt.