---
title: Folie zur Präsentation hinzufügen
type: docs
weight: 10
url: /de/java/add-slide-to-presentation/
---

## **Folie zur Präsentation hinzufügen**
{{% alert color="primary" %}} 

Bevor wir über das Hinzufügen von Folien zu den Präsentationsdateien sprechen, lassen Sie uns einige Fakten über die Folien diskutieren. Jede PowerPoint-Präsentationsdatei enthält **Master / Layout**-Folie und andere **Normale** Folien. Das bedeutet, dass eine Präsentationsdatei mindestens eine oder mehrere Folien enthält. Es ist wichtig zu wissen, dass Präsentationsdateien ohne Folien von Aspose.Slides für Java nicht unterstützt werden. Jede Folie hat eine eindeutige ID und alle normal Folien sind in einer Reihenfolge angeordnet, die durch den nullbasierten Index angegeben wird.

{{% /alert %}} 

Aspose.Slides für Java ermöglicht Entwicklern, leere Folien zu ihrer Präsentation hinzuzufügen. Um eine leere Folie in die Präsentation einzufügen, folgen Sie bitte den folgenden Schritten:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) Klasse.
- Instanziieren Sie die [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection) Klasse, indem Sie eine Referenz auf die [Slides](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) (Sammlung von Inhaltsfolienobjekten) Eigenschaft festlegen, die vom [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) Objekt bereitgestellt wird.
- Fügen Sie eine leere Folie am Ende der Sammlung von Inhaltsfolien hinzu, indem Sie die durch das [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection) Objekt bereitgestellten [**addEmptySlide**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) Methoden aufrufen.
- Führen Sie einige Arbeiten mit der neu hinzugefügten leeren Folie aus.
- Schließlich speichern Sie die Präsentationsdatei mit dem [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) Objekt.

```java
// Instanziieren Sie die Presentation-Klasse, die die Präsentationsdatei darstellt
Presentation pres = new Presentation();
try {
    // Instanziieren Sie die SlideCollection-Klasse
    ISlideCollection slds = pres.getSlides();

    for (int i = 0; i < pres.getLayoutSlides().size(); i++) {
        // Fügen Sie eine leere Folie zur Folienkollektion hinzu
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // Führen Sie einige Arbeiten an der neu hinzugefügten Folie aus

    // Speichern Sie die PPTX-Datei auf der Festplatte
    pres.save("EmptySlide.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```