---
title: Bläck
type: docs
weight: 180
url: /sv/php-java/examples/elements/ink/
keywords:
- bläck
- åtkomst till bläck
- ta bort bläck
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Hantera digitalt bläck på bilder i PHP med Aspose.Slides: lägg till penndrag, redigera banor, ange färg och bredd, och exportera resultat för PowerPoint och OpenDocument."
---
Ger exempel på hur man får åtkomst till befintliga bläckformer och tar bort dem med **Aspose.Slides for PHP via Java**.

> ❗ **Obs:** Bläckformer representerar användarinmatning från specialiserade enheter. Aspose.Slides kan inte skapa nya bläckstreck programmässigt, men du kan läsa och ändra befintligt bläck.

## **Åtkomst till bläck**

Hämta den första bläckformen på en bild.

```php
function accessInk() {
    $presentation = new Presentation("ink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Åtkomst till den första bläckformen på bilden.
        $firstInk = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Ink"))) {
                $firstInk = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Ta bort bläck**

Ta bort en bläckform från bilden.

```php
function removeInk() {
    $presentation = new Presentation("ink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Antar att den första formen på bilden är en bläckform.
        $ink = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($ink);

        $presentation->save("ink_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```