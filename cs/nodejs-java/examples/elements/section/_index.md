---
title: Sekce
type: docs
weight: 90
url: /cs/nodejs-java/examples/elements/section/
keywords:
- ukázka kódu
- sekce
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Spravujte sekce snímků v Aspose.Slides pro Node.js via Java: vytvářejte, přejmenovávejte, měňte pořadí a seskupujte snímky s příklady JavaScriptu pro PPT, PPTX a ODP."
---
Příklady pro správu sekcí prezentace — přidávat, přistupovat, odstraňovat a přejmenovávat je programově pomocí **Aspose.Slides for Node.js via Java**.

## **Přidat sekci**

Vytvořte sekci, která začíná na konkrétním snímku.

```js
function addSection() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Určete snímek, který označuje začátek sekce.
        presentation.getSections().addSection("New Section", slide);

        presentation.save("section.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Přístup k sekci**

Přečtěte informace o sekci z prezentace.

```js
function accessSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Přístup k sekci podle indexu.
        let section = presentation.getSections().get_Item(0);
        let sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **Odstranit sekci**

Odstraňte dříve přidanou sekci.

```js
function removeSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Odstraňte první sekci.
        let section = presentation.getSections().get_Item(0);
        presentation.getSections().removeSection(section);

        presentation.save("section_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Přejmenovat sekci**

Změňte název existující sekce.

```js
function renameSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let section = presentation.getSections().get_Item(0);
        section.setName("New Name");

        presentation.save("section_renamed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```