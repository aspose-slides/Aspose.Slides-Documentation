---
title: Folie zur Präsentation hinzufügen
type: docs
weight: 10
url: /de/androidjava/add-slide-to-presentation/
---

## **Folie zur Präsentation hinzufügen**
{{% alert color="primary" %}} 

Bevor wir über das Hinzufügen von Folien zu den Präsentationsdateien sprechen, lassen Sie uns einige Fakten über die Folien besprechen. Jede PowerPoint-Präsentationsdatei enthält eine **Master / Layout**-Folie und andere **Normale** Folien. Das bedeutet, dass eine Präsentationsdatei mindestens eine oder mehrere Folien enthält. Es ist wichtig zu wissen, dass Präsentationsdateien ohne Folien von Aspose.Slides für Android über Java nicht unterstützt werden. Jede Folie hat eine einzigartige ID und alle normalen Folien sind in einer Reihenfolge angeordnet, die durch den nullbasierten Index angegeben wird.

{{% /alert %}} 

Aspose.Slides für Android über Java ermöglicht Entwicklern das Hinzufügen leerer Folien zu ihrer Präsentation. Um eine leere Folie in die Präsentation einzufügen, folgen Sie bitte den folgenden Schritten:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) Klasse.
- Instanziieren Sie die [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection) Klasse, indem Sie eine Referenz zur [Slides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) (Sammlung von Inhaltsfolien) Eigenschaft, die vom [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) Objekt bereitgestellt wird, setzen.
- Fügen Sie eine leere Folie am Ende der Inhaltsfoliensammlung hinzu, indem Sie die von dem [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection) Objekt bereitgestellten [**addEmptySlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) Methode aufrufen.
- Führen Sie einige Arbeiten mit der neu hinzugefügten leeren Folie durch.
- Speichern Sie schließlich die Präsentationsdatei mit dem [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) Objekt.

```java
// Instanziieren Sie die Presentation-Klasse, die die Präsentationsdatei repräsentiert
Presentation pres = new Presentation();
try {
    // Instanziieren Sie die SlideCollection-Klasse
    ISlideCollection slds = pres.getSlides();

    for (int i = 0; i < pres.getLayoutSlides().size(); i++) {
        // Fügen Sie eine leere Folie zur Slides-Sammlung hinzu
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // Führen Sie einige Arbeiten an der neu hinzugefügten Folie durch

    // Speichern Sie die PPTX-Datei auf der Festplatte
    pres.save("EmptySlide.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```