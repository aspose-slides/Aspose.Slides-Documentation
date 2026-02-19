---
title: Folie
type: docs
weight: 10
url: /de/nodejs-java/examples/elements/slide/
keywords:
- Codebeispiel
- Folie
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Steuern Sie Folien in Aspose.Slides für Node.js: Erstellen, duplizieren, neu anordnen, Größe ändern, Hintergründe festlegen und Übergänge für PPT-, PPTX- und ODP-Präsentationen anwenden."
---
Dieser Artikel enthält eine Reihe von Beispielen, die zeigen, wie man mit Folien mithilfe von **Aspose.Slides für Node.js via Java** arbeitet. Sie lernen, wie man Folien hinzufügt, darauf zugreift, sie dupliziert, neu anordnet und entfernt, indem man die Klasse `Presentation` verwendet.

Jedes nachfolgende Beispiel enthält eine kurze Erklärung, gefolgt von einem Code‑Snippet in JavaScript.

## **Folie hinzufügen**

Um eine neue Folie hinzuzufügen, müssen Sie zunächst ein Layout auswählen. In diesem Beispiel verwenden wir das Layout `Blank` und fügen der Präsentation eine leere Folie hinzu.

```js
function addSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
        presentation.getSlides().addEmptySlide(layoutSlide);

        presentation.save("slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Hinweis:** Jedes Folienlayout leitet sich von einer Master‑Folie ab, die das Gesamtdesign und die Platzhalterstruktur definiert. Das untenstehende Bild zeigt, wie Master‑Folien und ihre zugehörigen Layouts in PowerPoint organisiert sind.

![Beziehung zwischen Master und Layout](master-layout-slide.png)

## **Zugriff auf Folien nach Index**

Sie können auf Folien über ihren Index zugreifen. Dies ist nützlich, um durch Folien zu iterieren oder bestimmte Folien zu ändern.

```js
function accessSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        // Zugriff auf eine Folie nach Index.
        let firstSlide = presentation.getSlides().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **Folie duplizieren**

Dieses Beispiel zeigt, wie man eine vorhandene Folie dupliziert. Die duplizierte Folie wird automatisch am Ende der Foliensammlung hinzugefügt.

```js
function cloneSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let firstSlide = presentation.getSlides().get_Item(0);
        let clonedSlide = presentation.getSlides().addClone(firstSlide);

        presentation.save("slide_cloned.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Folien neu anordnen**

Sie können die Reihenfolge der Folien ändern, indem Sie eine Folie an einen neuen Index verschieben. In diesem Fall verschieben wir eine Folie in die erste Position.

```js
function reorderSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        // Folien neu ordnen, indem die zweite Folie an die erste Position verschoben wird.
        let secondSlide = presentation.getSlides().get_Item(1);
        presentation.getSlides().reorder(0, secondSlide);

        presentation.save("slide_reordered.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Folie entfernen**

Um eine Folie zu entfernen, referenzieren Sie sie einfach und rufen `remove` auf. Dieses Beispiel fügt eine zweite Folie hinzu und entfernt anschließend die ursprüngliche, sodass nur noch die neue übrig bleibt.

```js
function removeSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        let firstSlide = presentation.getSlides().get_Item(0);
        presentation.getSlides().remove(firstSlide);

        presentation.save("slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```