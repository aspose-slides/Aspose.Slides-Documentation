---
title: OLE-объект
type: docs
weight: 210
url: /ru/php-java/examples/elements/ole-object/
keywords:
- OLE-объект
- добавить OLE-объект
- доступ к OLE-объекту
- удалить OLE-объект
- обновить OLE-объект
- примеры кода
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Работа с OLE‑объектами в PHP с помощью Aspose.Slides: вставка или обновление вложенных файлов, установка значков или ссылок, извлечение содержимого, управление поведением для PPT, PPTX и ODP."
---
Продемонстрировано встраивание файла как OLE‑объекта и обновление его данных с помощью **Aspose.Slides for PHP via Java**.

## **Добавить OLE‑объект**

Вставьте PDF‑файл в презентацию.

```php
function addOleObject() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $pdfData = new OleEmbeddedDataInfo(file_get_contents("doc.pdf"), "pdf");
        $oleFrame = $slide->getShapes()->addOleObjectFrame(20, 20, 50, 50, $pdfData);

        $presentation->save("ole_object.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Получить доступ к OLE‑объекту**

Получите первый кадр OLE‑объекта на слайде.

```php
function accessOleObject() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Получить доступ к первому OLE кадру на слайде.
        $firstOleFrame = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
                $firstOleFrame = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Удалить OLE‑объект**

Удалите встроенный OLE‑объект со слайда.

```php
function removeOleObject() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Предполагая, что первая фигура на слайде является OLE-кадром.
        $oleFrame = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($oleFrame);

        $presentation->save("ole_object_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Обновить данные OLE‑объекта**

Замените данные, встроенные в существующий OLE‑объект.

```php
function updateOleObjectData() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Предполагая, что первая фигура на слайде является OLE-кадром.
        $oleFrame = $slide->getShapes()->get_Item(0);

        $newData = new OleEmbeddedDataInfo(file_get_contents("picture.png"), "png");
        $oleFrame->setEmbeddedData($newData);

        $presentation->save("ole_object_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```