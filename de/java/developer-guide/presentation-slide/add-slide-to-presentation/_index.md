---
title: Folien zu Präsentationen in Java hinzufügen
linktitle: Folie hinzufügen
type: docs
weight: 10
url: /de/java/add-slide-to-presentation/
keywords:
- Folie hinzufügen
- Folie erstellen
- leere Folie
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Fügen Sie Ihren PowerPoint- und OpenDocument‑Präsentationen mit Aspose.Slides für Java ganz einfach Folien hinzu – nahtlose, effiziente Folieneinfügung in Sekunden."
---

## **Folie zu einer Präsentation hinzufügen**
{{% alert color="primary" %}} 

Bevor wir darüber sprechen, Folien zu den Präsentationsdateien hinzuzufügen, lassen Sie uns einige Fakten zu den Folien besprechen. Jede PowerPoint‑Präsentationsdatei enthält eine **Master / Layout**‑Folie und weitere **Normal**‑Folien. Das bedeutet, dass eine Präsentationsdatei mindestens eine oder mehrere Folien enthält. Es ist wichtig zu wissen, dass Präsentationsdateien ohne Folien von Aspose.Slides for Java nicht unterstützt werden. Jede Folie hat eine eindeutige Id und alle Normal‑Folien sind in einer Reihenfolge angeordnet, die durch den nullbasierten Index angegeben ist.

{{% /alert %}} 

Aspose.Slides for Java ermöglicht Entwicklern das Hinzufügen leerer Folien zu ihrer Präsentation. Um eine leere Folie in die Präsentation einzufügen, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
- Instanziieren Sie die Klasse [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection), indem Sie eine Referenz auf die Eigenschaft [Slides](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) (Sammlung von Inhalts‑Slide‑Objekten) setzen, die vom [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)-Objekt bereitgestellt wird.
- Fügen Sie am Ende der Sammlung von Inhalts‑Slides eine leere Folie hinzu, indem Sie die Methode [**addEmptySlide**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) auf dem [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection)-Objekt aufrufen.
- Arbeiten Sie mit der neu hinzugefügten leeren Folie.
- Schreiben Sie schließlich die Präsentationsdatei mithilfe des [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)-Objekts.
```java
// Instanziieren der Präsentationsklasse, die die Präsentationsdatei darstellt
Presentation pres = new Presentation();
try {
    // Instanziieren der SlideCollection-Klasse
    ISlideCollection slds = pres.getSlides();

    for (int i = 0; i < pres.getLayoutSlides().size(); i++) {
        // Eine leere Folie zur Slides-Sammlung hinzufügen
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // Arbeiten Sie mit der neu hinzugefügten Folie

    // Speichern Sie die PPTX-Datei auf dem Datenträger
    pres.save("EmptySlide.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **FAQ**

**Kann ich eine neue Folie an einer bestimmten Position einfügen, nicht nur am Ende?**

Ja. Die Bibliothek unterstützt Foliensammlungen und die [insert](https://reference.aspose.com/slides/java/com.aspose.slides/slidecollection/#insertEmptySlide-int-com.aspose.slides.ILayoutSlide-)/[clone](https://reference.aspose.com/slides/java/com.aspose.slides/slidecollection/#insertClone-int-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-)‑Operationen, sodass Sie eine Folie am gewünschten Index einfügen können, anstatt nur am Ende.

**Werden die Themen/Styles beibehalten, wenn man eine Folie basierend auf einem Layout hinzufügt?**

Ja. Ein Layout übernimmt die Formatierung von seinem Master, und die neue Folie übernimmt die des ausgewählten Layouts und dessen zugehörigem Master.

**Welche Folie ist in einer neuen "leeren" Präsentation vorhanden, bevor Folien hinzugefügt werden?**

Eine neu erstellte Präsentation enthält bereits eine leere Folie mit Index null. Dies ist bei der Berechnung von Einfügeindizes zu berücksichtigen.

**Wie wähle ich das "richtige" Layout für eine neue Folie, wenn der Master viele Optionen hat?**

Wählen Sie im Allgemeinen das [LayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/layoutslide/), das der gewünschten Struktur entspricht (z. B. Titel und Inhalt, Zwei Inhalte usw.). Wenn ein solches Layout fehlt, können Sie es dem Master [add it to the master](/slides/de/java/slide-layout/) hinzufügen und dann verwenden.