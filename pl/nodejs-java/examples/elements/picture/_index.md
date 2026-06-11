---
title: Obraz
type: docs
weight: 50
url: /pl/nodejs-java/examples/elements/picture/
keywords:
- przykład kodu
- obraz
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Praca z obrazami w Aspose.Slides for Node.js: wstawianie, przycinanie, kompresowanie, zmiana kolorów i eksportowanie obrazów z przykładami dla prezentacji PPT, PPTX i ODP."
---
Ten artykuł demonstruje, jak wstawiać i uzyskiwać dostęp do obrazów przy użyciu **Aspose.Slides for Node.js via Java**. Poniższe przykłady odczytują obraz z pliku, umieszczają go na slajdzie i następnie go pobierają.

## **Dodaj obraz**

Ten kod odczytuje obraz z pliku i wstawia go jako ramkę obrazu na pierwszym slajdzie.

```js
function addPicture() {
    const FileInputStream = java.import("java.io.FileInputStream");

    let presentation = new aspose.slides.Presentation();

    try {
        let slide = presentation.getSlides().get_Item(0);

        let imageStream = new FileInputStream("image.jpg");
        let image = presentation.getImages().addImage(imageStream);

        // Wstaw ramkę obrazu wyświetlającą obraz na pierwszym slajdzie.
        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle, 50, 50, image.getWidth(), image.getHeight(), image);

        presentation.save("picture.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Uzyskaj dostęp do obrazu**

Ten przykład zapewnia, że slajd zawiera ramkę obrazu, a następnie uzyskuje dostęp do pierwszej znalezionej.

```js
function accessPicture() {
    let presentation = new aspose.slides.Presentation("picture.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let pictureFrame = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                pictureFrame = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```