---
title: Sekcja
type: docs
weight: 90
url: /pl/nodejs-java/examples/elements/section/
keywords:
- przykład kodu
- sekcja
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Zarządzaj sekcjami slajdów w Aspose.Slides for Node.js via Java: twórz, zmieniaj nazwy, zmieniaj kolejność i grupuj slajdy za pomocą przykładów JavaScript dla formatów PPT, PPTX i ODP."
---
Przykłady zarządzania sekcjami prezentacji — dodawanie, dostęp, usuwanie i zmienianie ich nazw programowo przy użyciu **Aspose.Slides for Node.js via Java**.

## **Dodaj sekcję**

Utwórz sekcję, która zaczyna się od określonego slajdu.

```js
function addSection() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Określ slajd, który oznacza początek sekcji.
        presentation.getSections().addSection("New Section", slide);

        presentation.save("section.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Dostęp do sekcji**

Odczytaj informacje o sekcji z prezentacji.

```js
function accessSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Uzyskaj dostęp do sekcji według indeksu.
        let section = presentation.getSections().get_Item(0);
        let sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **Usuń sekcję**

Usuń wcześniej dodaną sekcję.

```js
function removeSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Usuń pierwszą sekcję.
        let section = presentation.getSections().get_Item(0);
        presentation.getSections().removeSection(section);

        presentation.save("section_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Zmień nazwę sekcji**

Zmień nazwę istniejącej sekcji.

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