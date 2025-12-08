---
title: Folien vergleichen
type: docs
weight: 50
url: /de/net/compare-slides/
keywords: "Folien in PowerPoint vergleichen, Zwei Folien vergleichen, Präsentation, C#, Csharp, .NET, Aspose.Slides"
description: "PowerPoint-Präsentationsfolien in C# oder .NET vergleichen"
---

## **Zwei Folien vergleichen**
Die Equals‑Methode wurde zum [IBaseSlide](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide)-Interface und zur [BaseSlide](https://reference.aspose.com/slides/net/aspose.slides/baseslide)-Klasse hinzugefügt. Sie gibt true zurück für Folien/Layout‑ und Folien/Master‑Folien, die in Struktur und statischem Inhalt identisch sind.

Zwei Folien sind gleich, wenn alle Shapes, Styles, Texte, Animationen und andere Einstellungen übereinstimmen usw. Der Vergleich berücksichtigt keine eindeutigen Kennzeichenwerte, z. B. SlideId, und keinen dynamischen Inhalt, z. B. den aktuellen Datumswert in einem Datums‑Platzhalter.
```c#
using (Presentation presentation1 = new Presentation("AccessSlides.pptx"))
using (Presentation presentation2 = new Presentation("HelloWorld.pptx"))
{
    for (int i = 0; i < presentation1.Masters.Count; i++)
    {
        for (int j = 0; j < presentation2.Masters.Count; j++)
        {
            if (presentation1.Masters[i].Equals(presentation2.Masters[j]))
                Console.WriteLine(string.Format("SomePresentation1 MasterSlide#{0} is equal to SomePresentation2 MasterSlide#{1}", i, j));
        }
    }
}
```


## **FAQ**

**Beeinflusst die Tatsache, dass eine Folie ausgeblendet ist, den Vergleich der Folien selbst?**

[Hidden status](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/) ist eine Eigenschaft auf Präsentations‑/Wiedergabebene, kein visueller Inhalt. Die Gleichheit zweier bestimmter Folien wird durch ihre Struktur und ihren statischen Inhalt bestimmt; die bloße Ausblendung macht die Folien nicht unterschiedlich.

**Werden Hyperlinks und deren Parameter berücksichtigt?**

Ja. Links sind Teil des statischen Inhalts einer Folie. Wenn die URL oder die Hyperlink‑Aktion abweicht, wird dies in der Regel als Unterschied im statischen Inhalt behandelt.

**Wenn ein Diagramm auf eine externe Excel‑Datei verweist, werden die Inhalte dieser Datei berücksichtigt?**

Nein. Der Vergleich wird anhand der Folien selbst durchgeführt. Externe Datenquellen werden zum Vergleichzeitpunkt in der Regel nicht gelesen; es wird nur das berücksichtigt, was in der Struktur und im statischen Zustand der Folie vorhanden ist.