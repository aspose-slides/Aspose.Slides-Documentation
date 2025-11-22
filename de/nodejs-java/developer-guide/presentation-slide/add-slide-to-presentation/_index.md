---
title: Folie zur Präsentation hinzufügen
type: docs
weight: 10
url: /de/nodejs-java/add-slide-to-presentation/
---

## **Folie zur Präsentation hinzufügen**
{{% alert color="primary" %}} 

Bevor wir über das Hinzufügen von Folien zu den Präsentationsdateien sprechen, lassen Sie uns einige Fakten zu den Folien erläutern. Jede PowerPoint-Präsentationsdatei enthält eine **Master / Layout**-Folie und weitere **Normal**-Folien. Das bedeutet, dass eine Präsentationsdatei mindestens eine oder mehrere Folien enthält. Es ist wichtig zu wissen, dass Präsentationsdateien ohne Folien von Aspose.Slides für Node.js via Java nicht unterstützt werden. Jede Folie hat eine eindeutige Id und alle Normal-Folien sind in einer Reihenfolge angeordnet, die durch den nullbasierten Index angegeben wird.

{{% /alert %}} 

Aspose.Slides für Node.js via Java ermöglicht Entwicklern das Hinzufügen leerer Folien zu ihrer Präsentation. Um eine leere Folie in die Präsentation einzufügen, folgen Sie bitte den untenstehenden Schritten:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
- Instanziieren Sie die Klasse [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection), indem Sie eine Referenz auf die Eigenschaft [Slides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) (Sammlung von Inhalts-Slide-Objekten) setzen, die vom [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation)-Objekt bereitgestellt wird.
- Fügen Sie eine leere Folie zur Präsentation am Ende der Inhalts-Slide-Sammlung hinzu, indem Sie die Methode [**addEmptySlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addEmptySlide-aspose.slides.ILayoutSlide-) auf dem [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection)-Objekt aufrufen.
- Arbeiten Sie mit der neu hinzugefügten leeren Folie.
- Speichern Sie schließlich die Präsentationsdatei mithilfe des [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation)-Objekts.
```javascript
// Instanziieren Sie die Presentation-Klasse, die die Präsentationsdatei darstellt
var pres = new aspose.slides.Presentation();
try {
    // Instanziieren Sie die SlideCollection-Klasse
    var slds = pres.getSlides();
    for (var i = 0; i < pres.getLayoutSlides().size(); i++) {
        // Fügen Sie eine leere Folie zur Slides-Sammlung hinzu
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // Arbeiten Sie mit der neu hinzugefügten Folie
    // Speichern Sie die PPTX-Datei auf der Festplatte
    pres.save("EmptySlide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **FAQ**

**Kann ich eine neue Folie an einer bestimmten Position einfügen, nicht nur am Ende?**

Ja. Die Bibliothek unterstützt Slide-Collections und die [insert](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/insertclone/)-Operationen, sodass Sie eine Folie an dem gewünschten Index einfügen können, anstatt nur am Ende.

**Werden die Themen/Styles beim Hinzufügen einer Folie basierend auf einem Layout beibehalten?**

Ja. Ein Layout erbt die Formatierung von seinem Master, und die neue Folie erbt vom ausgewählten Layout und dessen zugehörigem Master.

**Welche Folie ist in einer neuen „leeren“ Präsentation vorhanden, bevor Folien hinzugefügt werden?**

Eine neu erstellte Präsentation enthält bereits eine leere Folie mit dem Index Null. Das ist bei der Berechnung von Einfüge-Indices zu beachten.

**Wie wähle ich das „richtige“ Layout für eine neue Folie aus, wenn der Master viele Optionen hat?**

Wählen Sie im Allgemeinen das [LayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslide/), das der erforderlichen Struktur entspricht ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidelayouttype/)). Wenn ein solches Layout fehlt, können Sie es dem Master [zum Master hinzufügen](/slides/de/nodejs-java/slide-layout/) hinzufügen und anschließend verwenden.