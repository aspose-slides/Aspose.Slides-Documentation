---
title: Folien Vergleichen
type: docs
weight: 50
url: /de/net/compare-slides/
keywords: "Vergleiche PowerPoint-Folien, Vergleiche zwei Folien, Präsentation, C#, Csharp, .NET, Aspose.Slides"
description: "Vergleiche PowerPoint-Präsentationsfolien in C# oder .NET"
---

## **Zwei Folien Vergleichen**
Die Equals-Methode wurde zum [IBaseSlide](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide) Interface und zur [BaseSlide](https://reference.aspose.com/slides/net/aspose.slides/baseslide) Klasse hinzugefügt. Sie gibt true zurück, wenn die Folien/Layout und Folien/Hauptfolien strukturell und im statischen Inhalt identisch sind.

Zwei Folien sind gleich, wenn alle Formen, Stile, Texte, Animationen und andere Einstellungen usw. übereinstimmen. Der Vergleich berücksichtigt keine eindeutigen Identifikatorwerte, z.B. SlideId und dynamische Inhalte, z.B. den aktuellen Datumswert im Datums-Platzhalter.

```c#
using (Presentation presentation1 = new Presentation("AccessSlides.pptx"))
using (Presentation presentation2 = new Presentation("HelloWorld.pptx"))
{
    for (int i = 0; i < presentation1.Masters.Count; i++)
    {
        for (int j = 0; j < presentation2.Masters.Count; j++)
        {
            if (presentation1.Masters[i].Equals(presentation2.Masters[j]))
                Console.WriteLine(string.Format("SomePresentation1 MasterSlide#{0} ist gleich zu SomePresentation2 MasterSlide#{1}", i, j));
        }
    }
}
```