---
title: Folien vergleichen
type: docs
weight: 50
url: /java/compare-slides/
---

## **Zwei Folien vergleichen**
Die Equals-Methode wurde dem [IBaseSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide) Interface und der [BaseSlide](https://reference.aspose.com/slides/java/com.aspose.slides/BaseSlide) Klasse hinzugefügt. Sie gibt true zurück für Folien/Layout und Folien/Master-Folien, die strukturell und in ihrem statischen Inhalt identisch sind.

Zwei Folien sind gleich, wenn alle Formen, Stile, Texte, Animationen und andere Einstellungen usw. gleich sind. Der Vergleich berücksichtigt keine einzigartigen Identifikatorwerte, z.B. SlideId und dynamische Inhalte, z.B. den aktuellen Datumswert im Datums-Platzhalter.

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
                    System.out.println(String.format("SomePresentation1 MasterSlide#%d ist gleich zu SomePresentation2 MasterSlide#%d", i, j));
            }
        }
    } finally {
        presentation2.dispose();
    }
} finally {
    presentation1.dispose();
}
```