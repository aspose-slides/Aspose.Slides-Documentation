---
title: "Folie aus Präsentation entfernen"
type: docs
weight: 30
url: /de/nodejs-java/remove-slide-from-presentation/
keywords: "Folie entfernen, Folie löschen, PowerPoint, Präsentation, Java, Aspose.Slides"
description: "Folie aus PowerPoint per Referenz oder Index in JavaScript entfernen"
---

Wenn eine Folie (oder ihr Inhalt) überflüssig wird, können Sie sie löschen. Aspose.Slides stellt die [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) Klasse bereit, die die [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/) kapselt, die ein Repository für alle Folien in einer Präsentation ist. Mit Zeigern (Referenz oder Index) für ein bekanntes [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/) Objekt können Sie die Folie angeben, die Sie entfernen möchten.

## **Folie per Referenz entfernen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) Klasse.  
1. Holen Sie sich eine Referenz der Folie, die Sie entfernen möchten, über deren ID oder Index.  
1. Entfernen Sie die referenzierte Folie aus der Präsentation.  
1. Speichern Sie die geänderte Präsentation.  

Dieser JavaScript-Code zeigt, wie Sie eine Folie über ihre Referenz entfernen:
```javascript
// Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // Greift über den Index in der Folien-Sammlung auf eine Folie zu
    var slide = pres.getSlides().get_Item(0);
    // Entfernt eine Folie über deren Referenz
    pres.getSlides().remove(slide);
    // Speichert die geänderte Präsentation
    pres.save("modified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Folie nach Index entfernen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) Klasse.  
1. Entfernen Sie die Folie aus der Präsentation über ihre Indexposition.  
1. Speichern Sie die geänderte Präsentation.  

Dieser JavaScript-Code zeigt, wie Sie eine Folie über ihren Index entfernen:
```javascript
// Instanziert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // Entfernt eine Folie über ihren Folienindex
    pres.getSlides().removeAt(0);
    // Speichert die geänderte Präsentation
    pres.save("modified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Unbenutzte Layout‑Folien entfernen**

Aspose.Slides stellt die Methode [removeUnusedLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides-aspose.slides.Presentation-) (aus der Klasse [Compress](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/) ) bereit, mit der Sie unerwünschte und unbenutzte Layout‑Folien löschen können. Dieser JavaScript-Code zeigt, wie Sie eine Layout‑Folie aus einer PowerPoint‑Präsentation entfernen:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(pres);
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Unbenutzte Master‑Folien entfernen**

Aspose.Slides stellt die Methode [removeUnusedMasterSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides-aspose.slides.Presentation-) (aus der Klasse [Compress](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/) ) bereit, mit der Sie unerwünschte und unbenutzte Master‑Folien löschen können. Dieser JavaScript-Code zeigt, wie Sie eine Master‑Folie aus einer PowerPoint‑Präsentation entfernen:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(pres);
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Was passiert mit den Folien‑Indizes, nachdem ich eine Folie gelöscht habe?**  
Nach dem Löschen wird die [collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/) neu indiziert: jede nachfolgende Folie rückt um eine Position nach links, sodass die vorherigen Indexzahlen veraltet sind. Wenn Sie eine stabile Referenz benötigen, verwenden Sie die persistente ID jeder Folie anstelle ihres Index.

**Unterscheidet sich die ID einer Folie von ihrem Index und ändert sie sich, wenn benachbarte Folien gelöscht werden?**  
Ja. Der Index ist die Position der Folie und ändert sich, wenn Folien hinzugefügt oder entfernt werden. Die Folien‑ID ist ein permanenter Bezeichner und bleibt unverändert, wenn andere Folien gelöscht werden.

**Wie wirkt sich das Löschen einer Folie auf Folienabschnitte aus?**  
Wenn die Folie zu einem Abschnitt gehörte, enthält dieser Abschnitt einfach eine Folie weniger. Die Abschnittsstruktur bleibt erhalten; wird ein Abschnitt leer, können Sie [Abschnitte entfernen oder neu organisieren](/slides/de/nodejs-java/slide-section/) nach Bedarf.

**Was passiert mit Notizen und Kommentaren, die an einer Folie hängen, wenn sie gelöscht wird?**  
[Notes](/slides/de/nodejs-java/presentation-notes/) und [comments](/slides/de/nodejs-java/presentation-comments/) sind an diese spezielle Folie gebunden und werden zusammen mit ihr entfernt. Inhalte anderer Folien bleiben unverändert.

**Wie unterscheidet sich das Löschen von Folien vom Aufräumen unbenutzter Layout‑/Master‑Folien?**  
Beim Löschen werden bestimmte normale Folien aus der Präsentation entfernt. Das Aufräumen unbenutzter Layout‑/Master‑Folien entfernt Layout‑ oder Master‑Folien, auf die nichts verweist, was die Dateigröße reduziert, ohne den übrigen Folieninhalt zu verändern. Diese Aktionen ergänzen sich: In der Regel zuerst löschen, dann aufräumen.