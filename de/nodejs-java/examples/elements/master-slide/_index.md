---
title: Masterfolie
type: docs
weight: 30
url: /de/nodejs-java/examples/elements/master-slide/
keywords:
- Codebeispiel
- Masterfolie
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Entdecken Sie Beispiele für Masterfolien von Aspose.Slides für Node.js: Erstellen, Bearbeiten und Gestalten von Masterfolien, Platzhaltern und Designs in PPT, PPTX und ODP mit klar verständlichem Code."
---
Masterfolien bilden die oberste Ebene der Folienvererbungs‑Hierarchie in PowerPoint. Eine **Masterfolie** definiert gemeinsame Designelemente wie Hintergründe, Logos und Textformatierung. **Layoutfolien** erben von Masterfolien, und **Normale Folien** erben von Layoutfolien.

Dieser Artikel zeigt, wie man Masterfolien mit Aspose.Slides für Node.js über Java erstellt, ändert und verwaltet.

## **Masterfolie hinzufügen**

Dieses Beispiel zeigt, wie man eine neue Masterfolie erstellt, indem man die Standardfolie klont. Anschließend wird ein Firmenname‑Banner zu allen Folien über die Layout‑Vererbung hinzugefügt.

```js
function addMasterSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        // Kopiere die standardmäßige Masterfolie.
        let defaultMasterSlide = presentation.getMasters().get_Item(0);
        let newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        let textBoxFillType = java.newByte(aspose.slides.FillType.NoFill);

        // Füge ein Banner mit Firmennamen oben auf der Masterfolie hinzu.
        let textBox = newMasterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        textBox.getFillFormat().setFillType(textBoxFillType);

        let paragraphFillType = java.newByte(aspose.slides.FillType.Solid);
        let paragraphFillColor = java.getStaticFieldValue("java.awt.Color", "BLACK");

        let paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(paragraphFillType);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(paragraphFillColor);

        // Weise die neue Masterfolie einer Layoutfolie zu.
        let layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // Weise die Layoutfolie der ersten Folie in der Präsentation zu.
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);

        presentation.save("master_slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Hinweis 1:** Masterfolien ermöglichen es, einheitliches Branding oder gemeinsam genutzte Designelemente über alle Folien hinweg anzuwenden. Änderungen an der Masterfolie werden automatisch auf abhängige Layout‑ und Normale Folien übertragen.
> 
> 💡 **Hinweis 2:** Alle zu einer Masterfolie hinzugefügten Formen oder Formatierungen werden von Layoutfolien und wiederum von allen normalen Folien, die diese Layouts verwenden, geerbt.
> 
> Das Bild unten veranschaulicht, wie ein auf einer Masterfolie hinzugefügtes Textfeld automatisch auf der endgültigen Folie gerendert wird.

![Beispiel für Master‑Vererbung](master-slide-banner.png)

## **Zugriff auf eine Masterfolie**

Sie können Masterfolien über die Präsentations‑Master‑Sammlung zugreifen. So rufen Sie sie ab und arbeiten mit ihnen:

```js
function accessMasterSlide() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        let firstMasterSlide = presentation.getMasters().get_Item(0);

        // Ändern Sie den Hintergrundtyp.
        let backgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
        firstMasterSlide.getBackground().setType(backgroundType);
    } finally {
        presentation.dispose();
    }
}
```

## **Masterfolie entfernen**

Masterfolien können entweder nach Index oder per Referenz entfernt werden.

```js
function removeMasterSlide() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        // Entfernen Sie eine Masterfolie nach Index.
        presentation.getMasters().removeAt(0);

        // Entfernen Sie eine Masterfolie nach Referenz.
        let firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);

        presentation.save("master_slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Unbenutzte Masterfolien entfernen**

Einige Präsentationen enthalten Masterfolien, die nicht verwendet werden. Das Entfernen dieser Folien kann helfen, die Dateigröße zu reduzieren.

```js
function removeUnusedMasterSlides() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        // Entfernen Sie alle nicht verwendeten Masterfolien (auch solche, die als Preserve markiert sind).
        presentation.getMasters().removeUnused(true);

        presentation.save("unused_master_slides_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```