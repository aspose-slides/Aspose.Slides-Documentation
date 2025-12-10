---
title: Präsentationsfolien in Java vergleichen
linktitle: Folien vergleichen
type: docs
weight: 50
url: /de/java/compare-slides/
keywords:
- Folien vergleichen
- Folienvergleich
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Vergleichen Sie PowerPoint- und OpenDocument-Präsentationen programmgesteuert mit Aspose.Slides für Java. Identifizieren Sie Folienunterschiede im Code schnell."
---

## **Zwei Folien vergleichen**
Equals‑Methode wurde dem [IBaseSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide) Interface und der [BaseSlide](https://reference.aspose.com/slides/java/com.aspose.slides/BaseSlide) Klasse hinzugefügt. Sie gibt true zurück für die Folien/Layouts und Folien/Master‑Folien, die hinsichtlich ihrer Struktur und statischen Inhalte identisch sind.

Zwei Folien sind gleich, wenn alle Formen, Stile, Texte, Animationen und andere Einstellungen usw. gleich sind. Der Vergleich berücksichtigt nicht die eindeutigen Bezeichnerwerte, z. B. SlideId, und dynamische Inhalte, z. B. den aktuellen Datumswert im Date‑Platzhalter.
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

**Wirkt sich der Umstand, dass eine Folie ausgeblendet ist, auf den Vergleich der Folien selbst aus?**

[Hidden status](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#getHidden--) ist eine Präsentations‑/Wiedergabe‑Ebene‑Eigenschaft und kein visueller Inhalt. Die Gleichheit zweier bestimmter Folien wird durch ihre Struktur und statischen Inhalte bestimmt; die bloße Tatsache, dass eine Folie ausgeblendet ist, macht die Folien nicht verschieden.

**Werden Hyperlinks und deren Parameter berücksichtigt?**

Ja. Links sind Teil des statischen Inhalts einer Folie. Wenn die URL oder die Hyperlink‑Aktion unterschiedlich ist, wird dies in der Regel als Unterschied im statischen Inhalt behandelt.

**Wenn ein Diagramm auf eine externe Excel‑Datei verweist, werden die Inhalte dieser Datei berücksichtigt?**

Nein. Der Vergleich wird anhand der Folien selbst durchgeführt. Externe Datenquellen werden im Allgemeinen zum Vergleich nicht gelesen; es werden nur die in der Struktur und dem statischen Zustand der Folie vorhandenen Inhalte berücksichtigt.