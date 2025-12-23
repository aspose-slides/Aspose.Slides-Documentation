---
title: Управление гиперссылками презентаций в PHP
linktitle: Управление гиперссылкой
type: docs
weight: 20
url: /ru/php-java/manage-hyperlinks/
keywords:
- добавить URL
- добавить гиперссылку
- создать гиперссылку
- форматировать гиперссылку
- удалить гиперссылку
- обновить гиперссылку
- гиперссылка в тексте
- гиперссылка на слайд
- гиперссылка на форму
- гиперссылка на изображение
- гиперссылка на видео
- изменяемая гиперссылка
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Легко управляйте гиперссылками в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для PHP через Java — повышайте интерактивность и эффективность работы за считанные минуты."
---

Гиперссылка — это ссылка на объект, данные или место в чем‑то. Ниже перечислены типичные гиперссылки в презентациях PowerPoint:

* Ссылки на веб‑сайты внутри текста, фигур или мультимедиа
* Ссылки на слайды

Aspose.Slides for PHP via Java позволяет выполнять множество задач, связанных с гиперссылками в презентациях.

{{% alert color="primary" %}} 

Возможно, вам стоит посмотреть простой бесплатный онлайн‑редактор PowerPoint от Aspose: [бесплатный онлайн‑редактор PowerPoint.](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **Добавить URL‑гиперссылки**

### **Добавить URL‑гиперссылки в текст**

Этот PHP‑код демонстрирует, как добавить гиперссылку на веб‑сайт в текст:
```php
  $presentation = new Presentation();
  try {
    $shape1 = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
    $shape1->addTextFrame("Aspose: File Format APIs");
    $portionFormat = $shape1->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat::setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat::getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $portionFormat::setFontHeight(32);
    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


### **Добавить URL‑гиперссылки в фигуры или кадры**

Этот пример кода показывает, как добавить гиперссылку на веб‑сайт в фигуру:
```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50);
    $shape->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $shape->getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **Добавить URL‑гиперссылки к медиа**

Aspose.Slides позволяет добавлять гиперссылки к изображениям, аудио‑ и видео‑файлам. 

Этот пример кода показывает, как добавить гиперссылку к **изображению**:
```php
  $pres = new Presentation();
  try {
    # Добавляет изображение в презентацию
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($picture);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Создаёт рамку для изображения на слайде 1 на основе ранее добавленного изображения
    $pictureFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pictureFrame->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $pictureFrame->getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


Этот пример кода показывает, как добавить гиперссылку к **аудиофайлу**:
```php
  $pres = new Presentation();
  try {
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "audio.mp3"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $audio = $pres->getAudios()->addAudio($bytes);

    $audioFrame = $pres->getSlides()->get_Item(0)->getShapes()->addAudioFrameEmbedded(10, 10, 100, 100, $audio);
    $audioFrame->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $audioFrame->getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


Этот пример кода показывает, как добавить гиперссылку к **видео**:
```php
  $pres = new Presentation();
  try {
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "video.avi"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $video = $pres->getVideos()->addVideo($bytes);

    $videoFrame = $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(10, 10, 100, 100, $video);
    $videoFrame->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $videoFrame->getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{%  alert  title="Tip"  color="primary"  %}} 

Вам может быть интересно посмотреть *[Управление OLE](/slides/ru/php-java/manage-ole/)*.

{{% /alert %}}

## **Использовать гиперссылки для создания оглавления**

Поскольку гиперссылки позволяют добавлять ссылки на объекты или места, их можно использовать для создания оглавления.

Этот пример кода показывает, как создать оглавление с гиперссылками:
```php
  $pres = new Presentation();
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    $secondSlide = $pres->getSlides()->addEmptySlide($firstSlide->getLayoutSlide());
    $contentTable = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 300, 100);
    $contentTable->getFillFormat()->setFillType(FillType::NoFill);
    $contentTable->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $contentTable->getTextFrame()->getParagraphs()->clear();
    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $paragraph->setText("Title of slide 2 .......... ");
    $linkPortion = new Portion();
    $linkPortion->setText("Page 2");
    $linkPortion->getPortionFormat()->getHyperlinkManager()->setInternalHyperlinkClick($secondSlide);
    $paragraph->getPortions()->add($linkPortion);
    $contentTable->getTextFrame()->getParagraphs()->add($paragraph);
    $pres->save("link_to_slide.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Форматировать гиперссылки**

### **Цвет**

С помощью свойства [ColorSource](https://reference.aspose.com/slides/php-java/aspose.slides/Hyperlink#setColorSource-int-) в интерфейсе [IHyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlink) вы можете задавать цвет гиперссылок и также получать информацию о цвете из гиперссылок. Эта функция была впервые представлена в PowerPoint 2019, поэтому изменения, связанные со свойством, не применяются к более старым версиям PowerPoint.

Этот пример кода демонстрирует операцию, при которой гиперссылки с разными цветами были добавлены на один слайд:
```php
  $pres = new Presentation();
  try {
    $shape1 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 450, 50, false);
    $shape1->addTextFrame("This is a sample of colored hyperlink.");
    $portionFormat = $shape1->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat::setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat::getHyperlinkClick()->setColorSource(HyperlinkColorSource->PortionFormat);
    $portionFormat::getFillFormat()->setFillType(FillType::Solid);
    $portionFormat::getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $shape2 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 450, 50, false);
    $shape2->addTextFrame("This is a sample of usual hyperlink.");
    $shape2->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $pres->save("presentation-out-hyperlink.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Удалить гиперссылки из презентаций**

### **Удалить гиперссылки из текста**

Этот PHP‑код показывает, как удалить гиперссылку из текста на слайде презентации:
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    foreach($slide->getShapes() as $shape) {
      $autoShape = $shape;
      if (!java_is_null($autoShape)) {
        foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
          foreach($paragraph->getPortions() as $portion) {
            $portion->getPortionFormat()->getHyperlinkManager()->removeHyperlinkClick();
          }
        }
      }
    }
    $pres->save("pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **Удалить гиперссылки из фигур или кадров**

Этот PHP‑код показывает, как удалить гиперссылку из фигуры на слайде презентации:
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    foreach($slide->getShapes() as $shape) {
      $shape->getHyperlinkManager()->removeHyperlinkClick();
    }
    $pres->save("pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Изменяемая гиперссылка**

Класс [Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/Hyperlink) изменяемый. С его помощью можно изменить значения следующих свойств:

- [IHyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlink#setTargetFrame-java.lang.String-)
- [IHyperlink.setTooltip(String value)](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlink#setTooltip-java.lang.String-)
- [IHyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlink#setHistory-boolean-)
- [IHyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlink#setHighlightClick-boolean-)
- [IHyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlink#setStopSoundOnClick-boolean-)

Этот фрагмент кода показывает, как добавить гиперссылку на слайд и позже изменить её всплывающую подсказку:
```php
  $pres = new Presentation();
  try {
    $shape1 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
    $shape1->addTextFrame("Aspose: File Format APIs");
    $portionFormat = $shape1->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat::setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat::getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $portionFormat::setFontHeight(32);
    $pres->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Поддерживаемые свойства в IHyperlinkQueries**

Вы можете получить доступ к [IHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlinkQueries) из презентации, слайда или текста, для которых определена гиперссылка.

- [IPresentation.getHyperlinkQueries()](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentation#getHyperlinkQueries--)
- [IBaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#getHyperlinkQueries--)
- [ITextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame#getHyperlinkQueries--)

Класс [IHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlinkQueries) поддерживает эти методы и свойства:

- [IHyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlinkQueries#getHyperlinkClicks--)
- [IHyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlinkQueries#getHyperlinkMouseOvers--)
- [IHyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlinkQueries#getAnyHyperlinks--)
- [IHyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlinkQueries#removeAllHyperlinks--)

## **FAQ**

**Как я могу создать внутреннюю навигацию не только к слайду, но и к "разделу" или к первому слайду раздела?**

Разделы в PowerPoint представляют собой группы слайдов; навигация технически ориентирована на конкретный слайд. Чтобы «перейти к разделу», обычно создают ссылку на его первый слайд.

**Можно ли привязать гиперссылку к элементам шаблона слайда, чтобы она работала на всех слайдах?**

Да. Элементы мастер‑слайда и макета поддерживают гиперссылки. Такие ссылки отображаются на дочерних слайдах и кликабельны во время показа.

**Сохранятся ли гиперссылки при экспорте в PDF, HTML, изображения или видео?**

В [PDF](/slides/ru/php-java/convert-powerpoint-to-pdf/) и [HTML](/slides/ru/php-java/convert-powerpoint-to-html/) — да, ссылки обычно сохраняются. При экспорте в [изображения](/slides/ru/php-java/convert-powerpoint-to-png/) и [видео](/slides/ru/php-java/convert-powerpoint-to-video/) кликабельность не сохраняется из‑за характера этих форматов (растровые кадры/видео не поддерживают гиперссылки).