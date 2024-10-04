---
title: ActiveX
type: docs
weight: 80
url: /php-java/activex/
---


{{% alert color="primary" %}} 

Los controles ActiveX se utilizan en presentaciones. Aspose.Slides para PHP a través de Java te permite agregar y gestionar controles ActiveX, pero son un poco más complicados de manejar en comparación con las formas normales de presentación. Hemos implementado soporte para agregar el control ActiveX de Media Player en Aspose.Slides. Ten en cuenta que los controles ActiveX no son formas; no son parte de la [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IShapeCollection) de la presentación. En cambio, son parte de la [IControlCollection](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IControlCollection). En este tema, te mostraremos cómo trabajar con ellos.

{{% /alert %}} 

## **Agregar Control ActiveX de Media Player a la Diapositiva**
Para agregar un control ActiveX de Media Player, haz lo siguiente:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) y genera una instancia de presentación vacía.
1. Accede a la diapositiva objetivo en [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Agrega el control ActiveX de Media Player utilizando el método [addControl](https://reference.aspose.com/slides/php-java/aspose.slides/IControlCollection#addControl-int-float-float-float-float-) expuesto por [IControlCollection](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IControlCollection).
1. Accede al control ActiveX de Media Player y establece la ruta del video utilizando sus propiedades.
1. Guarda la presentación como un archivo PPTX.

Este código de ejemplo, basado en los pasos anteriores, muestra cómo agregar el Control ActiveX de Media Player a una diapositiva:

```php
  # Crear instancia de presentación vacía
  $pres = new Presentation();
  try {
    # Agregar el control ActiveX de Media Player
    $pres->getSlides()->get_Item(0)->getControls()->addControl(ControlType::WindowsMediaPlayer, 100, 100, 400, 400);
    # Acceder al control ActiveX de Media Player y establecer la ruta del video
    $pres->getSlides()->get_Item(0)->getControls()->get_Item(0)->getProperties()->set_Item("URL", "Wildlife.wmv");
    # Guardar la Presentación
    $pres->save("Output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Modificar Control ActiveX**
{{% alert color="primary" %}} 

Aspose.Slides para PHP a través de Java 7.1.0 y versiones más nuevas están equipadas con componentes para gestionar controles ActiveX. Puedes acceder al control ActiveX ya agregado en tu presentación y modificarlo o eliminarlo a través de sus propiedades.

{{% /alert %}} 

Para gestionar un control ActiveX simple como un cuadro de texto y un botón de comando simple en una diapositiva, haz lo siguiente:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) y carga la presentación con controles ActiveX en ella.
1. Obtén una referencia de la diapositiva por su índice.
1. Accede a los controles ActiveX en la diapositiva accediendo a la [IControlCollection](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IControlCollection).
1. Accede al control ActiveX TextBox1 utilizando el objeto [IControl](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IControl).
1. Cambia las propiedades del control ActiveX TextBox1 que incluyen texto, fuente, altura de la fuente y posición del marco.
1. Accede al segundo control de acceso llamado CommandButton1.
1. Cambia la leyenda del botón, fuente y posición.
1. Desplaza la posición de los marcos de los controles ActiveX.
1. Escribe la presentación modificada en un archivo PPTX.

Este código de ejemplo, basado en los pasos anteriores, muestra cómo gestionar un control ActiveX simple: 

```php
  # Accediendo a la presentación con controles ActiveX
  $pres = new Presentation("ActiveX.pptm");
  try {
    # Accediendo a la primera diapositiva en la presentación
    $slide = $pres->getSlides()->get_Item(0);
    # cambiando el texto del TextBox
    $control = $slide->getControls()->get_Item(0);
    if (!java_is_null($control->getName()->equalsIgnoreCase("TextBox1") && $control->getProperties())) {
      $newText = "Texto cambiado";
      $control->getProperties()->set_Item("Value", $newText);
      # Cambiando la imagen de sustitución. PowerPoint reemplazará esta imagen durante la activación de ActiveX,
      # así que a veces está bien dejar la imagen sin cambios.
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
    # Cambiando la leyenda del botón
    $control = $pres->getSlides()->get_Item(0)->getControls()->get_Item(1);
    if (!java_is_null($control->getName()->equalsIgnoreCase("CommandButton1") && $control->getProperties())) {
      $newCaption = "Mostrar MessageBox";
      $control->getProperties()->set_Item("Caption", $newCaption);
      # Cambiando la sustituta
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
    # moviendo 100 puntos hacia abajo
    foreach($pres->getSlides()->get_Item(0)->getControls() as $ctl) {
      $frame = $ctl->getFrame();
      $ctl->setFrame(new ShapeFrame($frame->getX(), $frame->getY() + 100, $frame->getWidth(), $frame->getHeight(), $frame->getFlipH(), $frame->getFlipV(), $frame->getRotation()));
    }
    $pres->save("withActiveX-edited_java.pptm", SaveFormat::Pptm);
    # eliminando controles
    $pres->getSlides()->get_Item(0)->getControls()->clear();
    $pres->save("withActiveX-cleared_java.pptm", SaveFormat::Pptm);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```