---
title: Szövegdoboz
type: docs
weight: 40
url: /hu/php-java/examples/elements/text-box/
keywords:
- szövegdoboz
- szövegdoboz hozzáadása
- szövegdoboz elérése
- szövegdoboz eltávolítása
- kódpéldák
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Hozzon létre és formázzon szövegdobozokat PHP-ban az Aspose.Slides segítségével: állítson be betűtípusokat, igazítást, sortörést, automatikus méretezést, és hivatkozásokat a PowerPoint és OpenDocument diák finomhangolásához."
---
Az Aspose.Slides-ban a **szövegdoboz** egy `AutoShape`‑ként jelenik meg. Gyakorlatilag bármely alakzat tartalmazhat szöveget, de egy tipikus szövegdoboz nem rendelkezik kitöltéssel vagy kerettel, és csak a szöveget jeleníti meg.

Ez az útmutató bemutatja, hogyan lehet programozottan szövegdobozokat hozzáadni, elérni és eltávolítani.

## **Szövegdoboz hozzáadása**

A szövegdoboz egyszerűen egy `AutoShape`, amelynek nincs kitöltése vagy kerete, és formázott szöveget tartalmaz. Íme, hogyan hozható létre:

```php
function addTextBox() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Hozzon létre egy négyzet alakzatot (alapértelmezés szerint töltött szegéllyel és szöveg nélkül).
        $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 75, 150, 100);

        // Távolítsa el a kitöltést és a keretet, hogy egy tipikus szövegdoboznak tűnjön.
        $textBox->getFillFormat()->setFillType(FillType::NoFill);
        $textBox->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        // Állítsa be a szövegformázást.
        $paragraph = $textBox->getTextFrame()->getParagraphs()->get_Item(0);
        $portionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
        $portionFormat->getFillFormat()->setFillType(FillType::Solid);
        $portionFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

        // Rendelje hozzá a tényleges szövegtartalmat.
        $textBox->getTextFrame()->setText("Some text...");

        $presentation->save("text_box.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Megjegyzés:** Bármely `AutoShape`, amely nem üres `TextFrame`‑et tartalmaz, funkcionálhat szövegdobozként.

## **Szövegdobozok elérése tartalom alapján**

Az összes olyan szövegdoboz megtalálásához, amely egy adott kulcsszót (pl. "Slide") tartalmaz, iteráljunk végig az alakzatokon, és ellenőrizzük a szövegüket:

```php
function accessTextBox() {
    $presentation = new Presentation("text_box.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Elérni az első szövegdobozt a dián.
        $firstTextBox = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $firstTextBox = $shape;
                if (strpos($firstTextBox->getTextFrame()->getText(), "Slide") !== false) {
                    // Valamit tenni a megfelelő szövegdobozzal.
                }
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Szövegdobozok eltávolítása tartalom alapján**

Ez a példa megtalálja és törli az első dián az összes olyan szövegdobozt, amely egy adott kulcsszót tartalmaz:

```php
function removeTextBoxes() {
    $presentation = new Presentation("text_box.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $shapesToRemove = [];

        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $autoShape = $shape;
                if (strpos($autoShape->getTextFrame()->getText(), "Slide") !== false) {
                    $shapesToRemove[] = $shape;
                }
            }
        }

        foreach ($shapesToRemove as $shape) {
            $slide->getShapes()->remove($shape);
        }

        $presentation->save("text_boxes_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Tanács:** Mindig készítsünk másolatot az alakzatelérési gyűjteményről a módosítás előtt az iterálás során, hogy elkerüljük a gyűjtemény módosítási hibákat.