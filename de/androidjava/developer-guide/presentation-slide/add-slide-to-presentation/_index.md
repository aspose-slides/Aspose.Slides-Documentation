---
title: Folien zu Präsentationen auf Android hinzufügen
linktitle: Folie hinzufügen
type: docs
weight: 10
url: /de/androidjava/add-slide-to-presentation/
keywords:
- Folie hinzufügen
- Folie erstellen
- leere Folie
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Fügen Sie ganz einfach Folien zu Ihren PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Android via Java hinzu – nahtlose, effiziente Folieneinfügung in Sekundenschnelle."
---

## **Eine Folie zu einer Präsentation hinzufügen**
{{% alert color="primary" %}} 

Bevor wir über das Hinzufügen von Folien zu den Präsentationsdateien sprechen, lassen Sie uns einige Fakten zu den Folien erläutern. Jede PowerPoint‑Präsentationsdatei enthält eine **Master‑/Layout**‑Folie und weitere **Normale** Folien. Das bedeutet, dass eine Präsentationsdatei mindestens eine oder mehrere Folien enthält. Es ist wichtig zu wissen, dass Präsentationsdateien ohne Folien von Aspose.Slides for Android via Java nicht unterstützt werden. Jede Folie hat eine eindeutige Id und alle Normalen Folien sind in einer Reihenfolge angeordnet, die durch den nullbasierten Index festgelegt ist.

{{% /alert %}} 

Aspose.Slides for Android via Java ermöglicht Entwicklern das Hinzufügen leerer Folien zu ihrer Präsentation. Um eine leere Folie in die Präsentation einzufügen, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
- Instanziieren Sie die Klasse [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection), indem Sie eine Referenz auf die Eigenschaft [Slides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) (Sammlung von Inhalts‑Slide‑Objekten) setzen, die vom [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)-Objekt bereitgestellt wird.
- Fügen Sie eine leere Folie am Ende der Inhaltsfoliensammlung hinzu, indem Sie die Methode [**addEmptySlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) des [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection)-Objekts aufrufen.
- Arbeiten Sie mit der neu hinzugefügten leeren Folie.
- Schreiben Sie schließlich die Präsentationsdatei mithilfe des [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)-Objekts.
```java
// Instanziiert die Presentation-Klasse, die die Präsentationsdatei repräsentiert
Presentation pres = new Presentation();
try {
    // Instanziiert die SlideCollection-Klasse
    ISlideCollection slds = pres.getSlides();

    for (int i = 0; i < pres.getLayoutSlides().size(); i++) {
        // Fügt der Slides-Sammlung eine leere Folie hinzu
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // Führt einige Operationen mit der neu hinzugefügten Folie aus

    // Speichert die PPTX-Datei auf dem Datenträger
    pres.save("EmptySlide.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **FAQ**

**Kann ich eine neue Folie an einer konkreten Position einfügen und nicht nur am Ende?**

Ja. Die Bibliothek unterstützt Slide‑Sammlungen und die Operationen [insert](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/#insertEmptySlide-int-com.aspose.slides.ILayoutSlide-)/[clone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/#insertClone-int-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-), sodass Sie eine Folie am gewünschten Index einfügen können, nicht nur am Ende.

**Werden Theme/Styles beim Hinzufügen einer Folie anhand eines Layouts beibehalten?**

Ja. Ein Layout erbt die Formatierung von seinem Master, und die neue Folie erbt vom ausgewählten Layout und dessen zugehörigem Master.

**Welche Folie ist in einer neuen „leeren“ Präsentation vorhanden, bevor Folien hinzugefügt werden?**

Eine neu erstellte Präsentation enthält bereits eine leere Folie mit dem Index null. Das ist wichtig zu berücksichtigen, wenn Einfüge‑Indizes berechnet werden.

**Wie wähle ich das „richtige“ Layout für eine neue Folie, wenn der Master viele Optionen hat?**

Wählen Sie im Allgemeinen das [LayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/layoutslide/), das der erforderlichen Struktur entspricht ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidelayouttype/)). Wenn ein solches Layout fehlt, können Sie es dem Master [add it to the master](/slides/de/androidjava/slide-layout/) hinzufügen.