---
title: ActiveX
type: docs
weight: 80
url: /php-java/activex/
---


{{% alert color="primary" %}} 

Элементы управления ActiveX используются в презентациях. Aspose.Slides для PHP через Java позволяет добавлять и управлять элементами управления ActiveX, но они немного сложнее в управлении по сравнению с обычными фигурами презентации. Мы реализовали поддержку добавления элемента управления Media Player Active в Aspose.Slides. Обратите внимание, что элементы управления ActiveX не являются фигурами; они не являются частью [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IShapeCollection) презентации. Вместо этого они являются частью отдельной [IControlCollection](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IControlCollection). В этой теме мы покажем вам, как с ними работать.

{{% /alert %}} 

## **Добавление элемента управления Media Player ActiveX на слайд**
Чтобы добавить элемент управления ActiveX Media Player, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) и создайте пустую презентацию.
1. Получите доступ к целевому слайду в [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Добавьте элемент управления ActiveX Media Player с помощью метода [addControl](https://reference.aspose.com/slides/php-java/aspose.slides/IControlCollection#addControl-int-float-float-float-float-) класса [IControlCollection](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IControlCollection).
1. Получите доступ к элементу управления ActiveX Media Player и задайте путь к видео, используя его свойства.
1. Сохраните презентацию в формате PPTX.

Этот пример кода, основанный на приведенных выше шагах, демонстрирует, как добавить элемент управления Media Player ActiveX на слайд:

```php
  # Создание пустого экземпляра презентации
  $pres = new Presentation();
  try {
    # Добавление элемента управления Media Player ActiveX
    $pres->getSlides()->get_Item(0)->getControls()->addControl(ControlType::WindowsMediaPlayer, 100, 100, 400, 400);
    # Получение доступа к элементу управления ActiveX Media Player и установка пути к видео
    $pres->getSlides()->get_Item(0)->getControls()->get_Item(0)->getProperties()->set_Item("URL", "Wildlife.wmv");
    # Сохранение презентации
    $pres->save("Output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Модификация элемента управления ActiveX**
{{% alert color="primary" %}} 

Aspose.Slides для PHP через Java версии 7.1.0 и более новые версии оснащены компонентами для управления элементами управления ActiveX. Вы можете получить доступ к уже добавленному элементу управления ActiveX в вашей презентации и изменить или удалить его через его свойства.

{{% /alert %}} 

Чтобы управлять простым элементом управления ActiveX, таким как текстовое поле и простая кнопка команд на слайде, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) и загрузите презентацию с элементами управления ActiveX.
1. Получите ссылку на слайд по его индексу.
1. Получите доступ к элементам управления ActiveX на слайде, обратившись к [IControlCollection](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IControlCollection).
1. Получите доступ к элементу управления TextBox1 ActiveX с помощью объекта [IControl](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IControl).
1. Измените свойства элемента управления TextBox1 ActiveX, включая текст, шрифт, высоту шрифта и положение рамки.
1. Получите доступ ко второму элементу управления под названием CommandButton1.
1. Измените подпись кнопки, шрифт и положение.
1. Сместите положение рамок элементов управления ActiveX.
1. Запишите измененную презентацию в файл PPTX.

Этот пример кода, основанный на приведенных выше шагах, показывает, как управлять простым элементом управления ActiveX: 

```php
  # Получение доступа к презентации с элементами управления ActiveX
  $pres = new Presentation("ActiveX.pptm");
  try {
    # Получение доступа к первому слайду в презентации
    $slide = $pres->getSlides()->get_Item(0);
    # изменение текста TextBox
    $control = $slide->getControls()->get_Item(0);
    if (!java_is_null($control->getName()->equalsIgnoreCase("TextBox1") && $control->getProperties())) {
      $newText = "Измененный текст";
      $control->getProperties()->set_Item("Value", $newText);
      # Изменение заменяющего изображения. PowerPoint заменит это изображение во время активации ActiveX,
      # поэтому иногда нормально оставить изображение без изменений.
      $image = new BufferedImage($control->getFrame()->getWidth(), $control->getFrame()->getHeight(), BufferedImage->TYPE_INT_ARGB);
      $graphics = $image->getGraphics();
      $graphics->setColor(SystemColor->window);
      $graphics->fillRect(0, 0, $image->getWidth(), $image->getHeight());
      $font = new Font($control->getProperties()->get_Item("FontName"), Font->PLAIN, 16);
      $graphics->setColor(SystemColor->windowText);
      $graphics->setFont($font);
      $graphics->drawString($newText, 10, 20);
      $graphics->setColor(SystemColor->controlShadow);
      $graphics->drawLine(0, $image->getHeight() - 1, 0, 0);
      $graphics->drawLine(0, 0, $image->getWidth() - 1, 0);
      $graphics->setColor(SystemColor->controlDkShadow);
      $graphics->drawLine(1, $image->getHeight() - 2, 1, 1);
      $graphics->drawLine(1, 1, $image->getWidth() - 2, 1);
      $graphics->setColor(SystemColor->controlHighlight);
      $graphics->drawLine(1, $image->getHeight() - 1, $image->getWidth() - 1, $image->getHeight() - 1);
      $graphics->drawLine($image->getWidth() - 1, $image->getHeight() - 1, $image->getWidth() - 1, 1);
      $graphics->setColor(SystemColor->controlLtHighlight);
      $graphics->drawLine(0, $image->getHeight(), $image->getWidth(), $image->getHeight());
      $graphics->drawLine($image->getWidth(), $image->getHeight(), $image->getWidth(), 0);
      $graphics->dispose();
      $baos = new Java("java.io.ByteArrayOutputStream");
      Java("javax.imageio.ImageIO")->write($image, "PNG", $baos);
      $control->getSubstitutePictureFormat()->getPicture()->setImage($pres->getImages()->addImage($baos->toByteArray()));
    }
    # Изменение подписи кнопки
    $control = $pres->getSlides()->get_Item(0)->getControls()->get_Item(1);
    if (!java_is_null($control->getName()->equalsIgnoreCase("CommandButton1") && $control->getProperties())) {
      $newCaption = "Показать MessageBox";
      $control->getProperties()->set_Item("Caption", $newCaption);
      # Изменение заменяющего
      $image = new BufferedImage($control->getFrame()->getWidth(), $control->getFrame()->getHeight(), BufferedImage->TYPE_INT_ARGB);
      $graphics = $image->getGraphics();
      $graphics->setColor(SystemColor->control);
      $graphics->fillRect(0, 0, $image->getWidth(), $image->getHeight());
      $font = new Font($control->getProperties()->get_Item("FontName"), Font->PLAIN, 16);
      $graphics->setColor(SystemColor->windowText);
      $graphics->setFont($font);
      $metrics = $graphics->getFontMetrics($font);
      $graphics->drawString($newCaption, $image->getWidth() - $metrics->stringWidth($newCaption) / 2, 20);
      $graphics->setColor(SystemColor->controlLtHighlight);
      $graphics->drawLine(0, $image->getHeight() - 1, 0, 0);
      $graphics->drawLine(0, 0, $image->getWidth() - 1, 0);
      $graphics->setColor(SystemColor->controlHighlight);
      $graphics->drawLine(1, $image->getHeight() - 2, 1, 1);
      $graphics->drawLine(1, 1, $image->getWidth() - 2, 1);
      $graphics->setColor(SystemColor->controlShadow);
      $graphics->drawLine(1, $image->getHeight() - 1, $image->getWidth() - 1, $image->getHeight() - 1);
      $graphics->drawLine($image->getWidth() - 1, $image->getHeight() - 1, $image->getWidth() - 1, 1);
      $graphics->setColor(SystemColor->controlDkShadow);
      $graphics->drawLine(0, $image->getHeight(), $image->getWidth(), $image->getHeight());
      $graphics->drawLine($image->getWidth(), $image->getHeight(), $image->getWidth(), 0);
      $graphics->dispose();
      $baos = new Java("java.io.ByteArrayOutputStream");
      Java("javax.imageio.ImageIO")->write($image, "PNG", $baos);
      $control->getSubstitutePictureFormat()->getPicture()->setImage($pres->getImages()->addImage($baos->toByteArray()));
    }
    # перемещение на 100 пунктов вниз
    foreach($pres->getSlides()->get_Item(0)->getControls() as $ctl) {
      $frame = $ctl->getFrame();
      $ctl->setFrame(new ShapeFrame($frame->getX(), $frame->getY() + 100, $frame->getWidth(), $frame->getHeight(), $frame->getFlipH(), $frame->getFlipV(), $frame->getRotation()));
    }
    $pres->save("withActiveX-edited_java.pptm", SaveFormat::Pptm);
    # удаление элементов управления
    $pres->getSlides()->get_Item(0)->getControls()->clear();
    $pres->save("withActiveX-cleared_java.pptm", SaveFormat::Pptm);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```