---
title: Szakasz
type: docs
weight: 90
url: /hu/nodejs-java/examples/elements/section/
keywords:
- kód példa
- szakasz
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Kezelje a diák szakaszait az Aspose.Slides for Node.js via Java segítségével: létrehozza, átnevezi, újrarendezi és csoportosítja a diákat JavaScript példákkal a PPT, PPTX és ODP formátumokhoz."
---
Példák a prezentáció szakaszok kezelésére — szakaszok hozzáadása, elérése, eltávolítása és átnevezése programozott módon, az **Aspose.Slides for Node.js via Java** használatával.

## **Szakasz hozzáadása**

Hozzon létre egy szakaszt, amely egy adott dián kezdődik.

```js
function addSection() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Adja meg a diát, amely a szakasz kezdetét jelöli.
        presentation.getSections().addSection("New Section", slide);

        presentation.save("section.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Szakasz elérése**

Olvassa el a szakasz információit a prezentációból.

```js
function accessSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // A szakasz elérése index alapján.
        let section = presentation.getSections().get_Item(0);
        let sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **Szakasz eltávolítása**

Törölje a korábban hozzáadott szakaszt.

```js
function removeSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Az első szakasz eltávolítása.
        let section = presentation.getSections().get_Item(0);
        presentation.getSections().removeSection(section);

        presentation.save("section_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Szakasz átnevezése**

Módosítsa egy meglévő szakasz nevét.

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