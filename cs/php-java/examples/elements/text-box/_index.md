---
title: Textové pole
type: docs
weight: 40
url: /cs/php-java/examples/elements/text-box/
keywords:
- textové pole
- přidat textové pole
- přístup k textovému poli
- odstranit textové pole
- ukázky kódu
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Vytvářejte a formátujte textová pole v PHP pomocí Aspose.Slides: nastavte písma, zarovnání, zalamování, automatické přizpůsobení a odkazy k vylepšení snímků pro PowerPoint a OpenDocument."
---
V Aspose.Slides je **textové pole** reprezentováno pomocí `AutoShape`. Téměř jakýkoli tvar může obsahovat text, ale typické textové pole nemá výplň ani okraj a zobrazuje jen text.

Tento průvodce vysvětluje, jak programově přidávat, získávat a odstraňovat textová pole.

## **Přidání textového pole**

Textové pole je jednoduše `AutoShape` bez výplně a okraje a s nějakým formátovaným textem. Zde je návod, jak takové vytvořit:

```php
function addTextBox() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Vytvořte obdélníkový tvar (ve výchozím nastavení je vyplněný okrajem a bez textu).
        $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 75, 150, 100);

        // Odstraňte výplň a okraj, aby vypadal jako typické textové pole.
        $textBox->getFillFormat()->setFillType(FillType::NoFill);
        $textBox->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        // Nastavte formátování textu.
        $paragraph = $textBox->getTextFrame()->getParagraphs()->get_Item(0);
        $portionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
        $portionFormat->getFillFormat()->setFillType(FillType::Solid);
        $portionFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

        // Přiřaďte skutečný obsah textu.
        $textBox->getTextFrame()->setText("Some text...");

        $presentation->save("text_box.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Poznámka:** Libovolný `AutoShape`, který obsahuje neprázdný `TextFrame`, může fungovat jako textové pole.

## **Přístup k textovým polím podle obsahu**

Chcete-li najít všechna textová pole obsahující konkrétní klíčové slovo (např. „Slide“), projděte tvary a zkontrolujte jejich text:

```php
function accessTextBox() {
    $presentation = new Presentation("text_box.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Přístup k prvnímu textovému poli na snímku.
        $firstTextBox = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $firstTextBox = $shape;
                if (strpos($firstTextBox->getTextFrame()->getText(), "Slide") !== false) {
                    // Proveďte něco s odpovídajícím textovým polem.
                }
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Odstranění textových polí podle obsahu**

Tento příklad najde a smaže všechna textová pole na první snímku, která obsahují konkrétní klíčové slovo:

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

> 💡 **Tip:** Vždy vytvořte kopii kolekce tvarů před jejím upravováním během iterace, abyste se vyhnuli chybám při modifikaci kolekce.