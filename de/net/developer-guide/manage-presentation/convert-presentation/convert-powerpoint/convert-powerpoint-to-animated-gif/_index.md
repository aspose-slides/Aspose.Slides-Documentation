---
title: PowerPoint in animiertes GIF umwandeln
type: docs
weight: 65
url: /de/net/convert-powerpoint-to-animated-gif/
keywords: "PowerPoint umwandeln, PPT, PPTX, animiertes GIF, PPT in animiertes GIF, PPTX in animiertes GIF C#, Csharp, .NET, Standardparameter, benutzerdefinierte Parameter"
description: "PowerPoint-Präsentation in animiertes GIF umwandeln: PPT in GIF, PPTX in GIF in C# oder .NET"
---

## Konvertieren von Präsentationen in animiertes GIF mit Standardparametern ##

Dieser Beispielcode in C# zeigt Ihnen, wie Sie eine Präsentation mit Standardparametern in ein animiertes GIF umwandeln:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif);
}
```

Das animierte GIF wird mit den Standardparametern erstellt.

{{%  alert  title="TIPP"  color="primary"  %}} 

Wenn Sie die Parameter für das GIF anpassen möchten, können Sie die [GifOptions](https://reference.aspose.com/slides/net/aspose.slides.export/gifoptions) Klasse verwenden. Siehe den Beispielcode unten.

{{% /alert %}} 

## Konvertieren von Präsentationen in animiertes GIF mit benutzerdefinierten Einstellungen ##
Dieser Beispielcode zeigt Ihnen, wie Sie eine Präsentation mit benutzerdefinierten Einstellungen in C# in ein animiertes GIF umwandeln:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif, new GifOptions
    {
        FrameSize = new Size(960, 720), // die Größe des resultierenden GIF  
        DefaultDelay = 2000, // wie lange jede Folie angezeigt wird, bis sie zur nächsten gewechselt wird
        TransitionFps = 35 // FPS erhöhen, um die Qualität der Übergangsanimation zu verbessern
    });
}
```

{{% alert title="Info" color="info" %}}

Sie möchten vielleicht einen kostenlosen [Text zu GIF](https://products.aspose.app/slides/text-to-gif) Konverter, der von Aspose entwickelt wurde, ausprobieren.

{{% /alert %}}