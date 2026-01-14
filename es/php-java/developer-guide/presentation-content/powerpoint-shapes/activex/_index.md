---
title: Gestionar controles ActiveX en presentaciones usando PHP
linktitle: ActiveX
type: docs
weight: 80
url: /es/php-java/activex/
keywords:
- ActiveX
- control ActiveX
- gestionar ActiveX
- añadir ActiveX
- modificar ActiveX
- reproductor multimedia
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Aprenda cómo Aspose.Slides para PHP mediante Java aprovecha ActiveX para automatizar y mejorar presentaciones de PowerPoint, ofreciendo a los desarrolladores un control potente sobre las diapositivas."
---

{{% alert color="primary" %}} 

Los controles ActiveX se usan en presentaciones. Aspose.Slides para PHP mediante Java le permite añadir y gestionar controles ActiveX, pero son un poco más difíciles de manejar en comparación con las formas normales de la presentación. Hemos implementado soporte para añadir el control Active Media Player en Aspose.Slides. Tenga en cuenta que los controles ActiveX no son formas; no forman parte de la [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/). En su lugar forman parte de la [ControlCollection](https://reference.aspose.com/slides/php-java/aspose.slides/controlcollection/) separada. En este tema, le mostraremos cómo trabajar con ellos.

{{% /alert %}} 

## **Agregar un control ActiveX Media Player a una diapositiva**
Para añadir un control ActiveX Media Player, haga lo siguiente:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) y genere una instancia de presentación vacía.
1. Acceda a la diapositiva objetivo en [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Añada el control ActiveX Media Player utilizando el método [addControl](https://reference.aspose.com/slides/php-java/aspose.slides/controlcollection/addcontrol/) que expone [ControlCollection](https://reference.aspose.com/slides/php-java/aspose.slides/controlcollection/).
1. Acceda al control ActiveX Media Player y establezca la ruta del video mediante sus propiedades.
1. Guarde la presentación como un archivo PPTX.

Este código de ejemplo, basado en los pasos anteriores, muestra cómo añadir el control ActiveX Media Player a una diapositiva:
```php
  # Crear una instancia de presentación vacía
  $pres = new Presentation();
  try {
    # Añadiendo el control ActiveX Media Player
    $pres->getSlides()->get_Item(0)->getControls()->addControl(ControlType::WindowsMediaPlayer, 100, 100, 400, 400);
    # Acceder al control ActiveX Media Player y establecer la ruta del vídeo
    $pres->getSlides()->get_Item(0)->getControls()->get_Item(0)->getProperties()->set_Item("URL", "Wildlife.wmv");
    # Guardar la presentación
    $pres->save("Output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Modificar un control ActiveX**
{{% alert color="primary" %}} 

Aspose.Slides para PHP mediante Java 7.1.0 y versiones posteriores están equipados con componentes para gestionar controles ActiveX. Puede acceder al control ActiveX ya añadido en su presentación y modificarlo o eliminarlo a través de sus propiedades.

{{% /alert %}} 

Para gestionar un control ActiveX simple, como un cuadro de texto y un botón de comando sencillo en una diapositiva, siga estos pasos:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) y cargue la presentación que contiene controles ActiveX.
1. Obtenga una referencia a la diapositiva mediante su índice.
1. Acceda a los controles ActiveX en la diapositiva accediendo a la [ControlCollection](https://reference.aspose.com/slides/php-java/aspose.slides/controlcollection/).
1. Acceda al control ActiveX TextBox1 utilizando el objeto [Control](https://reference.aspose.com/slides/php-java/aspose.slides/control/).
1. Modifique las propiedades del control ActiveX TextBox1 que incluyen el texto, la fuente, la altura de la fuente y la posición del marco.
1. Acceda al segundo control llamado CommandButton1.
1. Cambie el texto del botón, la fuente y la posición.
1. Desplace la posición de los marcos de los controles ActiveX.
1. Escriba la presentación modificada en un archivo PPTX.

Este código de ejemplo, basado en los pasos anteriores, muestra cómo gestionar un control ActiveX sencillo: 
```php
  # Accediendo a la presentación con controles ActiveX
  $pres = new Presentation("ActiveX.pptm");
  try {
    # Accediendo a la primera diapositiva de la presentación
    $slide = $pres->getSlides()->get_Item(0);
    # cambiando el texto del TextBox
    $control = $slide->getControls()->get_Item(0);
    if (!java_is_null($control->getName()->equalsIgnoreCase("TextBox1") && $control->getProperties())) {
      $newText = "Changed text";
      $control->getProperties()->set_Item("Value", $newText);
      # Cambiando la imagen de sustitución. PowerPoint reemplazará esta imagen durante la activación del ActiveX,
      # por lo que a veces está bien dejar la imagen sin cambios.
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
    # Cambiando el texto del botón
    $control = $pres->getSlides()->get_Item(0)->getControls()->get_Item(1);
    if (!java_is_null($control->getName()->equalsIgnoreCase("CommandButton1") && $control->getProperties())) {
      $newCaption = "Show MessageBox";
      $control->getProperties()->set_Item("Caption", $newCaption);
      # Cambiando la sustitución
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


## **Preguntas frecuentes**

**¿Aspose.Slides conserva los controles ActiveX al leer y volver a guardar si no pueden ejecutarse en el tiempo de ejecución de Java?**

Sí. Aspose.Slides los trata como parte de la presentación y puede leer/modificar sus propiedades y marcos; no es necesario ejecutar los propios controles para preservarlos.

**¿En qué se diferencian los controles ActiveX de los objetos OLE en una presentación?**

Los controles ActiveX son controles interactivos gestionados (botones, cuadros de texto, reproductor multimedia), mientras que [OLE](/slides/es/php-java/manage-ole/) se refiere a objetos de aplicación incrustados (por ejemplo, una hoja de cálculo de Excel). Se almacenan y manejan de forma distinta y poseen modelos de propiedades diferentes.

**¿Los eventos ActiveX y las macros VBA funcionan si el archivo ha sido modificado por Aspose.Slides?**

Aspose.Slides conserva el marcado y los metadatos existentes; sin embargo, los eventos y macros solo se ejecutan dentro de PowerPoint en Windows cuando la seguridad lo permite. La biblioteca no ejecuta VBA.