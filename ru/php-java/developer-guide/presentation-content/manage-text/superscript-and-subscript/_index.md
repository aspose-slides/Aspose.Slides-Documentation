---
title: Надстрочные и подстрочные символы
type: docs
weight: 80
url: /ru/php-java/superscript-and-subscript/
---

## **Управление текстом с надстрочными и подстрочными символами**
Вы можете добавлять надстрочные и подстрочные символы внутри любого абзаца. Для добавления надстрочного или подстрочного текста в текстовом фрейме Aspose.Slides необходимо использовать метод [**setEscapement**](https://reference.aspose.com/slides/php-java/aspose.slides/IBasePortionFormat#setEscapement-float-) класса [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/PortionFormat).

Это свойство возвращает или устанавливает надстрочный или подстрочный текст (значение от -100% (подстрочный) до 100% (надстрочный). Например:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) типа [Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType#Rectangle) на слайд.
- Получите доступ к [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame), связанному с [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
- Очистите существующие абзацы.
- Создайте новый объект абзаца для размещения надстрочного текста и добавьте его в [коллекцию IParagraphs](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame#getParagraphs--) [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame).
- Создайте новый объект части текста.
- Установите свойство Escapement для части в диапазоне от 0 до 100 для добавления надстрочного текста. (0 означает отсутствие надстрочного текста)
- Установите текст для [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/Portion) и затем добавьте это в коллекцию частей абзаца.
- Создайте новый объект абзаца для размещения подстрочного текста и добавьте его в коллекцию IParagraphs [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame).
- Создайте новый объект части текста.
- Установите свойство Escapement для части в диапазоне от 0 до -100 для добавления подстрочного текста. (0 означает отсутствие подстрочного текста)
- Установите текст для [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/Portion) и затем добавьте это в коллекцию частей абзаца.
- Сохраните презентацию в формате PPTX.

Реализация вышеуказанных шагов приведена ниже.

```php
  # Создайте экземпляр класса Presentation, представляющий PPTX
  $pres = new Presentation();
  try {
    # Получите слайд
    $slide = $pres->getSlides()->get_Item(0);
    # Создайте текстовое поле
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();
    # Создайте абзац для надстрочного текста
    $superPar = new Paragraph();
    # Создайте часть с обычным текстом
    $portion1 = new Portion();
    $portion1->setText("SlideTitle");
    $superPar->getPortions()->add($portion1);
    # Создайте часть с надстрочным текстом
    $superPortion = new Portion();
    $superPortion->getPortionFormat()->setEscapement(30);
    $superPortion->setText("TM");
    $superPar->getPortions()->add($superPortion);
    # Создайте абзац для подстрочного текста
    $paragraph2 = new Paragraph();
    # Создайте часть с обычным текстом
    $portion2 = new Portion();
    $portion2->setText("a");
    $paragraph2->getPortions()->add($portion2);
    # Создайте часть с подстрочным текстом
    $subPortion = new Portion();
    $subPortion->getPortionFormat()->setEscapement(-25);
    $subPortion->setText("i");
    $paragraph2->getPortions()->add($subPortion);
    # Добавьте абзацы в текстовое поле
    $textFrame->getParagraphs()->add($superPar);
    $textFrame->getParagraphs()->add($paragraph2);
    $pres->save("formatText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```