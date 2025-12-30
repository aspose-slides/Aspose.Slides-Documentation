---
title: Управление элементами управления ActiveX в презентациях с использованием PHP
linktitle: ActiveX
type: docs
weight: 80
url: /ru/php-java/activex/
keywords:
- ActiveX
- Элемент управления ActiveX
- управление ActiveX
- добавление ActiveX
- изменение ActiveX
- медиаплеер
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как Aspose.Slides for PHP via Java использует ActiveX для автоматизации и улучшения презентаций PowerPoint, предоставляя разработчикам мощный контроль над слайдами."
---

{{% alert color="primary" %}} 

Элементы управления ActiveX используются в презентациях. Aspose.Slides for PHP via Java позволяет добавлять и управлять элементами управления ActiveX, но они несколько сложнее в управлении по сравнению с обычными фигурами презентации. Мы реализовали поддержку добавления активного элемента Media Player в Aspose.Slides. Обратите внимание, что элементы управления ActiveX не являются фигурами; они не являются частью [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IShapeCollection) презентации. Они принадлежат отдельному [IControlCollection](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IControlCollection). В этой теме мы покажем, как с ними работать.

{{% /alert %}} 

## **Добавление элемента управления Media Player ActiveX на слайд**
Чтобы добавить элемент управления Media Player ActiveX, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) и получите пустой экземпляр презентации.
1. Получите доступ к целевому слайду в [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Добавьте элемент управления Media Player ActiveX с помощью метода [addControl](https://reference.aspose.com/slides/php-java/aspose.slides/IControlCollection#addControl-int-float-float-float-float-) , предоставляемого интерфейсом [IControlCollection](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IControlCollection).
1. Получите доступ к элементу управления Media Player ActiveX и задайте путь к видео, используя его свойства.
1. Сохраните презентацию в файл PPTX.

Этот пример кода, основанный на приведённых выше шагах, показывает, как добавить элемент управления Media Player ActiveX на слайд:
```php
  # Создать пустой экземпляр презентации
  $pres = new Presentation();
  try {
    # Добавление элемента управления Media Player ActiveX
    $pres->getSlides()->get_Item(0)->getControls()->addControl(ControlType::WindowsMediaPlayer, 100, 100, 400, 400);
    # Доступ к элементу управления Media Player ActiveX и установка пути к видео
    $pres->getSlides()->get_Item(0)->getControls()->get_Item(0)->getProperties()->set_Item("URL", "Wildlife.wmv");
    # Сохранить презентацию
    $pres->save("Output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Модификация элемента управления ActiveX**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java 7.1.0 и более новые версии оснащены компонентами для управления элементами управления ActiveX. Вы можете получить доступ к уже добавленному элементу управления ActiveX в презентации и изменить или удалить его через его свойства.

{{% /alert %}} 

Чтобы управлять простым элементом управления ActiveX, таким как текстовое поле и простая кнопка команды на слайде, выполните следующее:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) и загрузите презентацию, содержащую элементы управления ActiveX.
1. Получите ссылку на слайд по его индексу.
1. Получите доступ к элементам управления ActiveX на слайде, обратившись к [IControlCollection](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IControlCollection).
1. Получите доступ к элементу управления ActiveX TextBox1 с помощью объекта [IControl](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IControl).
1. Измените свойства элемента управления ActiveX TextBox1, включая текст, шрифт, высоту шрифта и позицию рамки.
1. Получите доступ ко второму элементу управления под именем CommandButton1.
1. Измените подпись кнопки, шрифт и положение.
1. Смещение позиции рамок элементов управления ActiveX.
1. Запишите изменённую презентацию в файл PPTX.

Этот пример кода, основанный на приведённых выше шагах, показывает, как управлять простым элементом управления ActiveX: 
```php
  # Доступ к презентации с элементами управления ActiveX
  $pres = new Presentation("ActiveX.pptm");
  try {
    # Доступ к первому слайду в презентации
    $slide = $pres->getSlides()->get_Item(0);
    # Изменение текста TextBox
    $control = $slide->getControls()->get_Item(0);
    if (!java_is_null($control->getName()->equalsIgnoreCase("TextBox1") && $control->getProperties())) {
      $newText = "Changed text";
      $control->getProperties()->set_Item("Value", $newText);
      # Изменение заменяющего изображения. PowerPoint заменит это изображение при активации ActiveX,
      # поэтому иногда допускается оставить изображение без изменений.
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
      $newCaption = "Show MessageBox";
      $control->getProperties()->set_Item("Caption", $newCaption);
      # Изменение заменяющего изображения
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
    # Перемещение вниз на 100 пунктов
    foreach($pres->getSlides()->get_Item(0)->getControls() as $ctl) {
      $frame = $ctl->getFrame();
      $ctl->setFrame(new ShapeFrame($frame->getX(), $frame->getY() + 100, $frame->getWidth(), $frame->getHeight(), $frame->getFlipH(), $frame->getFlipV(), $frame->getRotation()));
    }
    $pres->save("withActiveX-edited_java.pptm", SaveFormat::Pptm);
    # Удаление элементов управления
    $pres->getSlides()->get_Item(0)->getControls()->clear();
    $pres->save("withActiveX-cleared_java.pptm", SaveFormat::Pptm);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Сохраняет ли Aspose.Slides элементы управления ActiveX при чтении и повторном сохранении, если они не могут быть выполнены в среде Java?**

Да. Aspose.Slides рассматривает их как часть презентации и может читать/изменять их свойства и рамки; для их сохранения не требуется выполнять сами элементы управления.

**Чем элементы управления ActiveX отличаются от объектов OLE в презентации?**

Элементы управления ActiveX – это интерактивные управляемые элементы (кнопки, текстовые поля, медиаплеер), тогда как [OLE](/slides/ru/php-java/manage-ole/) относится к встроенным объектам приложений (например, лист Excel). Они хранятся и обрабатываются по‑разному и имеют разные модели свойств.

**Работают ли события ActiveX и макросы VBA, если файл был изменён Aspose.Slides?**

Aspose.Slides сохраняет существующую разметку и метаданные; однако события и макросы выполняются только внутри PowerPoint на Windows при разрешённой безопасности. Библиотека не исполняет VBA.