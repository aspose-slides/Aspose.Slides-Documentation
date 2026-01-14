---
title: Управление ActiveX-контролями в презентациях с помощью PHP
linktitle: ActiveX
type: docs
weight: 80
url: /ru/php-java/activex/
keywords:
- ActiveX
- ActiveX-контрол
- управление ActiveX
- добавление ActiveX
- изменение ActiveX
- медиаплеер
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как Aspose.Slides для PHP через Java использует ActiveX для автоматизации и улучшения презентаций PowerPoint, предоставляя разработчикам мощный контроль над слайдами."
---

{{% alert color="primary" %}} 

ActiveX‑элементы управления используются в презентациях. Aspose.Slides для PHP через Java позволяет добавлять и управлять ActiveX‑элементами, но они несколько сложнее в управлении по сравнению с обычными фигурами презентации. Мы реализовали поддержку добавления ActiveX‑контроля Media Player в Aspose.Slides. Обратите внимание, что ActiveX‑элементы не являются фигурами; они не входят в [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/) презентации. Они находятся в отдельном [ControlCollection](https://reference.aspose.com/slides/php-java/aspose.slides/controlcollection/). В этой статье мы покажем, как работать с ними.

{{% /alert %}} 

## **Добавление ActiveX‑контроля Media Player на слайд**
Чтобы добавить контроллер Media Player ActiveX, выполните следующее:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) и получите пустой объект презентации.  
2. Получите доступ к целевому слайду в [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).  
3. Добавьте ActiveX‑контроллер Media Player с помощью метода [addControl](https://reference.aspose.com/slides/php-java/aspose.slides/controlcollection/addcontrol/), предоставляемого [ControlCollection](https://reference.aspose.com/slides/php-java/aspose.slides/controlcollection/).  
4. Получите доступ к контроллеру Media Player ActiveX и задайте путь к видео, используя его свойства.  
5. Сохраните презентацию в файл PPTX.  

Этот пример кода, основанный на описанных шагах, демонстрирует, как добавить ActiveX‑контроллер Media Player на слайд:
```php
  # Создать пустой экземпляр презентации
  $pres = new Presentation();
  try {
    # Добавление ActiveX‑контрола Media Player
    $pres->getSlides()->get_Item(0)->getControls()->addControl(ControlType::WindowsMediaPlayer, 100, 100, 400, 400);
    # Доступ к ActiveX‑контролю Media Player и установка пути к видео
    $pres->getSlides()->get_Item(0)->getControls()->get_Item(0)->getProperties()->set_Item("URL", "Wildlife.wmv");
    # Сохранить презентацию
    $pres->save("Output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Изменение ActiveX‑контроля**
{{% alert color="primary" %}} 

Aspose.Slides для PHP через Java версии 7.1.0 и новее оснащён компонентами для управления ActiveX‑элементами. Вы можете получить доступ к уже добавленному ActiveX‑контролю в презентации и изменить или удалить его через свойства.

{{% /alert %}} 

Чтобы управлять простым ActiveX‑контролем, таким как текстовое поле и простая кнопка команд на слайде, выполните следующее:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) и загрузите презентацию, содержащую ActiveX‑элементы.  
2. Получите ссылку на слайд по его индексу.  
3. Получите доступ к ActiveX‑элементам на слайде, обратившись к [ControlCollection](https://reference.aspose.com/slides/php-java/aspose.slides/controlcollection/).  
4. Доступ к контролу TextBox1 ActiveX получайте через объект [Control](https://reference.aspose.com/slides/php-java/aspose.slides/control/).  
5. Измените свойства контроля TextBox1 ActiveX, включая текст, шрифт, высоту шрифта и позицию рамки.  
6. Получите второй контрол под названием CommandButton1.  
7. Измените подпись кнопки, шрифт и позицию.  
8. Сдвиньте позиции рамок ActiveX‑контролей.  
9. Запишите изменённую презентацию в файл PPTX.  

Этот пример кода, основанный на описанных шагах, показывает, как управлять простым ActiveX‑контролем: 
```php
  # Доступ к презентации с ActiveX‑элементами
  $pres = new Presentation("ActiveX.pptm");
  try {
    # Доступ к первому слайду в презентации
    $slide = $pres->getSlides()->get_Item(0);
    # изменение текста TextBox
    $control = $slide->getControls()->get_Item(0);
    if (!java_is_null($control->getName()->equalsIgnoreCase("TextBox1") && $control->getProperties())) {
      $newText = "Changed text";
      $control->getProperties()->set_Item("Value", $newText);
      # Изменение заменяющего изображения. PowerPoint заменит это изображение при активации ActiveX,
      # поэтому иногда можно оставить изображение без изменений.
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


## **FAQ**

**Сохраняет ли Aspose.Slides ActiveX‑контролы при чтении и повторном сохранении, если они не могут быть выполнены в среде Java?**

Да. Aspose.Slides рассматривает их как часть презентации и может читать/изменять их свойства и рамки; выполнение самих контролов не требуется для их сохранения.

**Чем ActiveX‑контролы отличаются от объектов OLE в презентации?**

ActiveX‑контролы — это интерактивные управляемые элементы (кнопки, текстовые поля, медиаплеер), тогда как [OLE](/slides/ru/php-java/manage-ole/) относится к внедрённым объектам приложений (например, листу Excel). Они хранятся и обрабатываются по‑разному и имеют разные модели свойств.

**Работают ли события ActiveX и макросы VBA, если файл был изменён Aspose.Slides?**

Aspose.Slides сохраняет существующую разметку и метаданные; однако события и макросы выполняются только в PowerPoint под Windows при разрешённой безопасности. Библиотека не исполняет VBA.