---
title: Layout-Slide
type: docs
weight: 20
url: /de/nodejs-java/examples/elements/layout-slide/
keywords:
- Codebeispiel
- Layout-Slide
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Master-Layout-Slides in Aspose.Slides für Node.js: Layout-Slides auswählen, anwenden und anpassen, Platzhalter und Master mit Beispielen für PPT-, PPTX- und ODP-Präsentationen."
---
Dieser Artikel zeigt, wie man mit **Layout Slides** in Aspose.Slides für Node.js über Java arbeitet. Ein Layout‑Slide definiert das Design und die Formatierung, die von normalen Folien geerbt werden. Sie können Layout‑Slides hinzufügen, darauf zugreifen, kopieren und entfernen sowie nicht verwendete Slides bereinigen, um die Präsentationsgröße zu reduzieren.

## **Ein Layout‑Slide hinzufügen**

Sie können ein benutzerdefiniertes Layout‑Slide erstellen, um wiederverwendbare Formatierung zu definieren.

```js
function addLayoutSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let masterSlide = presentation.getMasters().get_Item(0);

        // Erstelle ein Layout‑Slide mit einem leeren Layout‑Typ und einem benutzerdefinierten Namen.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().add(masterSlide, layoutType, "Main layout");

        presentation.save("layout_slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Note 1:** Layout‑Slides fungieren als Vorlagen für einzelne Folien. Sie können gemeinsame Elemente einmal definieren und sie in vielen Folien wiederverwenden.

> 💡 **Note 2:** Wenn Sie Formen oder Text zu einem Layout‑Slide hinzufügen, zeigen alle darauf basierenden Folien diesen gemeinsamen Inhalt automatisch an.  
> Der folgende Screenshot zeigt zwei Folien, die jeweils ein Textfeld vom selben Layout‑Slide erben.

![Folien, die Layout‑Inhalte erben](layout-slide-result.png)

## **Auf ein Layout‑Slide zugreifen**

Layout‑Slides können über den Index oder über den Layout‑Typ (z. B. `Blank`, `Title`, `SectionHeader` usw.) zugegriffen werden.

```js
function accessLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // Greife auf ein Layout‑Slide über den Index zu.
        let firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // Greife auf ein Layout‑Slide über den Typ zu.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
    } finally {
        presentation.dispose();
    }
}
```

## **Ein Layout‑Slide entfernen**

Sie können ein bestimmtes Layout‑Slide entfernen, wenn es nicht mehr benötigt wird.

```js
function removeLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // Hole ein Layout‑Slide nach Typ und entferne es.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Custom);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
        presentation.getLayoutSlides().remove(layoutSlide);

        presentation.save("layout_slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Unbenutzte Layout‑Slides entfernen**

Um die Präsentationsgröße zu reduzieren, können Sie Layout‑Slides entfernen, die von keinen normalen Folien verwendet werden.

```js
function removeUnusedLayoutSlides() {
    let presentation = new aspose.slides.Presentation();
    try {
        // Entfernt automatisch alle Layout‑Slides, die von keiner Folie referenziert werden.
        presentation.getLayoutSlides().removeUnused();

        presentation.save("unused_layout_slides_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Ein Layout‑Slide duplizieren**

Sie können ein Layout‑Slide mit der Methode `addClone` duplizieren.

```js
function cloneLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // Hole ein vorhandenes Layout‑Slide nach Typ.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Title);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);

        // Klone das Layout‑Slide an das Ende der Layout‑Slide‑Sammlung.
        let clonedLayoutSlide = presentation.getLayoutSlides().addClone(layoutSlide);

        presentation.save("layout_slide_cloned.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **Summary:** Layout‑Slides sind leistungsstarke Werkzeuge, um konsistente Formatierung über Folien hinweg zu verwalten. Aspose.Slides bietet vollständige Kontrolle über das Erstellen, Verwalten und Optimieren von Layout‑Slides.