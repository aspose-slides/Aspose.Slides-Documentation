---
title: Управление гибкими ссылками
type: docs
weight: 20
url: /ru/php-java/manage-hyperlinks/
keywords: "Гиперссылка PowerPoint, текстовая гиперссылка, гиперссылка на слайд, гиперссылка на форму, гиперссылка на изображение, гиперссылка на видео, Java"
description: "Как добавить гиперссылку в презентацию PowerPoint"
---

Гиперссылка — это ссылка на объект, данные или место в чем-то. Вот распространенные гиперссылки в презентациях PowerPoint:

* Ссылки на веб-сайты в текстах, формах или медиа
* Ссылки на слайды

Aspose.Slides для PHP через Java позволяет выполнять множество задач, связанных с гиперссылками в презентациях.

{{% alert color="primary" %}} 

Вам может быть интересно посмотреть на простой, [бесплатный онлайн-редактор PowerPoint.](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **Добавление URL-гиперссылок**

### **Добавление URL-гиперссылок к текстам**

Этот код PHP показывает, как добавить гиперссылку на веб-сайт к тексту:

```php
  $presentation = new Presentation();
  try {
    $shape1 = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
    $shape1->addTextFrame("Aspose: API форматов файлов");
    $portionFormat = $shape1->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat::setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat::getHyperlinkClick()->setTooltip("Более 70% компаний из списка Fortune 100 доверяют API Aspose");
    $portionFormat::setFontHeight(32);
    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

### **Добавление URL-гиперссылок к формам или рамкам**

Этот пример кода показывает, как добавить гиперссылку на веб-сайт к форме:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50);
    $shape->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $shape->getHyperlinkClick()->setTooltip("Более 70% компаний из списка Fortune 100 доверяют API Aspose");
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Добавление URL-гиперссылок к медиа**

Aspose.Slides позволяет добавлять гиперссылки к изображениями, аудио и видео файлам. 

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
    # Создает рамку для изображения на слайде 1 на основе ранее добавленного изображения
    $pictureFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pictureFrame->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $pictureFrame->getHyperlinkClick()->setTooltip("Более 70% компаний из списка Fortune 100 доверяют API Aspose");
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
    $audioFrame->getHyperlinkClick()->setTooltip("Более 70% компаний из списка Fortune 100 доверяют API Aspose");
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
    $videoFrame->getHyperlinkClick()->setTooltip("Более 70% компаний из списка Fortune 100 доверяют API Aspose");
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{%  alert  title="Совет"  color="primary"  %}} 

Вам может быть интересно увидеть *[Управление OLE](/slides/ru/php-java/manage-ole/)*.

{{% /alert %}}

## **Использование гиперссылок для создания оглавления**

Поскольку гиперссылки позволяют добавлять ссылки на объекты или места, вы можете использовать их для создания оглавления. 

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
    $paragraph->setText("Название слайда 2 .......... ");
    $linkPortion = new Portion();
    $linkPortion->setText("Страница 2");
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

## **Форматирование гиперссылок**

### **Цвет**

С помощью свойства [ColorSource](https://reference.aspose.com/slides/php-java/aspose.slides/Hyperlink#setColorSource-int-) в интерфейсе [IHyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlink) вы можете установить цвет для гиперссылок, а также получить информацию о цвете из гиперссылок. Эта функция была впервые введена в PowerPoint 2019, поэтому изменения, касающиеся свойства, не применяются к более старым версиям PowerPoint.

Этот пример кода демонстрирует операцию, при которой гиперссылки с разными цветами были добавлены на один слайд:

```php
  $pres = new Presentation();
  try {
    $shape1 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 450, 50, false);
    $shape1->addTextFrame("Это пример цветной гиперссылки.");
    $portionFormat = $shape1->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat::setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat::getHyperlinkClick()->setColorSource(HyperlinkColorSource->PortionFormat);
    $portionFormat::getFillFormat()->setFillType(FillType::Solid);
    $portionFormat::getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $shape2 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 450, 50, false);
    $shape2->addTextFrame("Это пример обычной гиперссылки.");
    $shape2->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $pres->save("presentation-out-hyperlink.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Удаление гиперссылок в презентациях**

### **Удаление гиперссылок из текстов**

Этот код PHP показывает, как удалить гиперссылку из текста на слайде презентации:

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

### **Удаление гиперссылок из форм или рамок**

Этот код PHP показывает, как удалить гиперссылку из формы на слайде презентации:

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

Класс [Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/Hyperlink) является изменяемым. С помощью этого класса вы можете изменять значения для следующих свойств:

- [IHyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlink#setTargetFrame-java.lang.String-)
- [IHyperlink.setTooltip(String value)](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlink#setTooltip-java.lang.String-)
- [IHyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlink#setHistory-boolean-)
- [IHyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlink#setHighlightClick-boolean-)
- [IHyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlink#setStopSoundOnClick-boolean-)

Фрагмент кода показывает, как добавить гиперссылку на слайд и позже отредактировать ее подсказку:

```php
  $pres = new Presentation();
  try {
    $shape1 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
    $shape1->addTextFrame("Aspose: API форматов файлов");
    $portionFormat = $shape1->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat::setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat::getHyperlinkClick()->setTooltip("Более 70% компаний из списка Fortune 100 доверяют API Aspose");
    $portionFormat::setFontHeight(32);
    $pres->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Поддерживаемые свойства в IHyperlinkQueries**

Вы можете получить доступ к [IHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlinkQueries) из презентации, слайда или текста, для которого определена гиперссылка.

- [IPresentation.getHyperlinkQueries()](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentation#getHyperlinkQueries--)
- [IBaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#getHyperlinkQueries--)
- [ITextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame#getHyperlinkQueries--)

Класс [IHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlinkQueries) поддерживает следующие методы и свойства:

- [IHyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlinkQueries#getHyperlinkClicks--)
- [IHyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlinkQueries#getHyperlinkMouseOvers--)
- [IHyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlinkQueries#getAnyHyperlinks--)
- [IHyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlinkQueries#removeAllHyperlinks--)