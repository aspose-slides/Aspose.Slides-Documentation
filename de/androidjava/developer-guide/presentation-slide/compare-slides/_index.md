---
title: Präsentationsfolien auf Android vergleichen
linktitle: Folien vergleichen
type: docs
weight: 50
url: /de/androidjava/compare-slides/
keywords:
- Folien vergleichen
- Folienvergleich
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Vergleichen Sie PowerPoint- und OpenDocument-Präsentationen programmgesteuert mit Aspose.Slides für Android. Erkennen Sie Folienunterschiede im Java-Code schnell."
---

## **Zwei Folien vergleichen**
Die Equals-Methode wurde dem Interface [IBaseSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide) und der Klasse [BaseSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BaseSlide) hinzugefügt. Sie gibt true zurück für Folien/Layouts und Masterfolien, die in ihrer Struktur und ihrem statischen Inhalt identisch sind.  

Zwei Folien sind gleich, wenn alle Formen, Stile, Texte, Animationen und andere Einstellungen usw. gleich sind. Der Vergleich berücksichtigt keine eindeutigen Bezeichnerwerte, z.B. SlideId, und keinen dynamischen Inhalt, z.B. den aktuellen Datumswert im Datums-Platzhalter.  
```java
Presentation presentation1 = new Presentation("AccessSlides.pptx");
try {
    Presentation presentation2 = new Presentation("HelloWorld.pptx");
    try {
        for (int i = 0; i < presentation1.getMasters().size(); i++)
        {
            for (int j = 0; j < presentation2.getMasters().size(); j++)
            {
                if (presentation1.getMasters().get_Item(i).equals(presentation2.getMasters().get_Item(j)))
                    System.out.println(String.format("SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", i, j));
            }
        }
    } finally {
        presentation2.dispose();
    }
} finally {
    presentation1.dispose();
}
```


## **FAQ**

**Hat die Tatsache, dass eine Folie ausgeblendet ist, Auswirkungen auf den Vergleich der Folien selbst?**

[Hidden status](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slide/#getHidden--) ist eine Präsentations-/Wiedergabe-Ebene-Eigenschaft, kein visueller Inhalt. Die Gleichheit zweier bestimmter Folien wird durch ihre Struktur und ihren statischen Inhalt bestimmt; die bloße Tatsache, dass eine Folie ausgeblendet ist, macht die Folien nicht unterschiedlich.

**Werden Hyperlinks und deren Parameter berücksichtigt?**

Ja. Links sind Teil des statischen Inhalts einer Folie. Wenn die URL oder die Hyperlink-Aktion abweicht, wird dies in der Regel als Unterschied im statischen Inhalt betrachtet.

**Wenn ein Diagramm auf eine externe Excel-Datei verweist, werden die Inhalte dieser Datei berücksichtigt?**

Nein. Der Vergleich erfolgt anhand der Folien selbst. Externe Datenquellen werden in der Regel zum Vergleich nicht eingelesen; es werden nur die in der Folienstruktur und im statischen Zustand vorhandenen Daten berücksichtigt.