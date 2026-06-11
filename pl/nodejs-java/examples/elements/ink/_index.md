---
title: Atrament
type: docs
weight: 180
url: /pl/nodejs-java/examples/elements/ink/
keywords:
- przykład kodu
- atrament
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Pracuj z atramentem w Aspose.Slides dla Node.js: rysuj, importuj i edytuj pociągnięcia, dostosowuj kolor i szerokość oraz eksportuj do PPT, PPTX i ODP przy użyciu przykładów."
---
Ten artykuł zawiera przykłady dostępu do istniejących kształtów atramentu i ich usuwania przy użyciu **Aspose.Slides for Node.js via Java**.

> ❗ **Uwaga:** Kształty atramentu reprezentują dane wejściowe użytkownika pochodzące ze specjalistycznych urządzeń. Aspose.Slides nie może programowo tworzyć nowych pociągnięć atramentu, ale możesz odczytywać i modyfikować istniejący atrament.

## **Dostęp do atramentu**

Pobierz pierwszy kształt atramentu na slajdzie.

```js
function accessInk() {
    let presentation = new aspose.slides.Presentation("ink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let inkShape = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IInk")) {
                inkShape = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Usuwanie atramentu**

Usuń kształt atramentu ze slajdu.

```js
function removeInk() {
    let presentation = new aspose.slides.Presentation("ink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Zakładając, że kształt atramentu jest pierwszym kształtem na slajdzie.
        slide.getShapes().removeAt(0);

        presentation.save("ink_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```