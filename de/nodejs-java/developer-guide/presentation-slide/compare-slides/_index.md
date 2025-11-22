---
title: Folien vergleichen
type: docs
weight: 50
url: /de/nodejs-java/compare-slides/
---

## **Zwei Folien vergleichen**
Die Equals-Methode wurde zur Klasse [BaseSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide) und zur Klasse [BaseSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide) hinzugefügt. Sie gibt true zurück für Folien/Layout‑ und Folien‑Master‑Folien, die in ihrer Struktur und ihrem statischen Inhalt identisch sind.  

Zwei Folien sind gleich, wenn alle Formen, Stile, Texte, Animationen und sonstigen Einstellungen usw. gleich sind. Der Vergleich berücksichtigt nicht die eindeutigen Bezeichnerwerte, z.B. SlideId, und dynamische Inhalte, z.B. den aktuellen Datumswert im Datums‑Platzhalter.  
```javascript
var presentation1 = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    var presentation2 = new aspose.slides.Presentation("HelloWorld.pptx");
    try {
        for (var i = 0; i < presentation1.getMasters().size(); i++) {
            for (var j = 0; j < presentation2.getMasters().size(); j++) {
                if (presentation1.getMasters().get_Item(i).equals(presentation2.getMasters().get_Item(j))) {
                    console.log(java.callStaticMethodSync("java.lang.String", "format", "SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", i, j));
                }
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

**Hat die Tatsache, dass eine Folie ausgeblendet ist, Einfluss auf den Vergleich der Folien selbst?**

[Hidden status](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/gethidden/) ist eine Eigenschaft auf Präsentations-/Wiedergabe‑Ebene, nicht visueller Inhalt. Die Gleichheit zweier bestimmter Folien wird durch ihre Struktur und ihren statischen Inhalt bestimmt; die bloße Tatsache, dass eine Folie ausgeblendet ist, macht die Folien nicht unterschiedlich.

**Werden Hyperlinks und deren Parameter berücksichtigt?**

Ja. Links sind Teil des statischen Inhalts einer Folie. Wenn sich die URL oder die Hyperlink‑Aktion unterscheidet, wird dies in der Regel als Unterschied im statischen Inhalt angesehen.

**Wenn ein Diagramm auf eine externe Excel‑Datei verweist, werden die Inhalte dieser Datei berücksichtigt?**

Nein. Der Vergleich erfolgt anhand der Folien selbst. Externe Datenquellen werden beim Vergleich in der Regel nicht gelesen; es wird nur das berücksichtigt, was in der Struktur und im statischen Zustand der Folie vorhanden ist.