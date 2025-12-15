---
title: Administrar controles ActiveX en presentaciones en Android
linktitle: ActiveX
type: docs
weight: 80
url: /es/androidjava/activex/
keywords:
- ActiveX
- control ActiveX
- administrar ActiveX
- agregar ActiveX
- modificar ActiveX
- reproductor multimedia
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Aprenda cómo Aspose.Slides para Android mediante Java aprovecha ActiveX para automatizar y mejorar presentaciones de PowerPoint, brindando a los desarrolladores un control potente sobre las diapositivas."
---

{{% alert color="primary" %}} 

Los controles ActiveX se utilizan en presentaciones. Aspose.Slides for Android via Java le permite agregar y administrar controles ActiveX, pero son un poco más complicados de manejar en comparación con las formas normales de la presentación. Implementamos soporte para agregar el control Active Media Player en Aspose.Slides. Tenga en cuenta que los controles ActiveX no son formas; no forman parte de la [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IShapeCollection) de la presentación. Forman parte de la [IControlCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IControlCollection) separada. En este tema, le mostraremos cómo trabajar con ellos.

{{% /alert %}} 

## **Agregar un control ActiveX Media Player a una diapositiva**
Para agregar un control ActiveX Media Player, haga lo siguiente:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) y genere una presentación vacía.
1. Acceda a la diapositiva de destino en [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Agregue el control ActiveX Media Player usando el método [addControl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) expuesto por [IControlCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IControlCollection).
1. Acceda al control ActiveX Media Player y establezca la ruta del video mediante sus propiedades.
1. Guarde la presentación como un archivo PPTX.

Este fragmento de código, basado en los pasos anteriores, muestra cómo agregar un control ActiveX Media Player a una diapositiva:
```java
// Crear instancia vacía de presentación
Presentation pres = new Presentation();
try {
    // Añadir el control ActiveX Media Player
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // Acceder al control ActiveX Media Player y establecer la ruta del video
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // Guardar la presentación
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Modificar un control ActiveX**
{{% alert color="primary" %}} 

Aspose.Slides for Android via Java 7.1.0 y versiones posteriores están equipados con componentes para administrar controles ActiveX. Puede acceder al control ActiveX ya agregado en su presentación y modificarlo o eliminarlo a través de sus propiedades.

{{% /alert %}} 

Para administrar un control ActiveX simple como un cuadro de texto y un botón de comando en una diapositiva, haga lo siguiente:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) y cargue la presentación con controles ActiveX.
1. Obtenga una referencia a la diapositiva por su índice.
1. Acceda a los controles ActiveX en la diapositiva mediante la [IControlCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IControlCollection).
1. Acceda al control ActiveX TextBox1 utilizando el objeto [IControl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IControl).
1. Cambie las propiedades del control ActiveX TextBox1, incluidas el texto, la fuente, la altura de la fuente y la posición del marco.
1. Acceda al segundo control llamado CommandButton1.
1. Cambie el texto del botón, la fuente y la posición.
1. Desplace la posición de los marcos de los controles ActiveX.
1. Escriba la presentación modificada en un archivo PPTX.

Este fragmento de código, basado en los pasos anteriores, muestra cómo administrar un control ActiveX simple: 
```java
// Accediendo a la presentación con controles ActiveX
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // Accediendo a la primera diapositiva de la presentación
    ISlide slide = pres.getSlides().get_Item(0);

    // cambiando el texto del TextBox
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "Changed text";
        control.getProperties().set_Item("Value", newText);

        // Cambiar la imagen sustituta. PowerPoint reemplazará esta imagen durante la activación de ActiveX,
        // por lo que a veces está bien dejar la imagen sin cambios.
        BufferedImage image = new BufferedImage((int) control.getFrame().getWidth(), (int) control.getFrame().getHeight(),
                BufferedImage.TYPE_INT_ARGB);

        java.awt.Graphics graphics = image.getGraphics();
        graphics.setColor(SystemColor.window);
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());

        java.awt.Font font = new java.awt.Font(control.getProperties().get_Item("FontName"), java.awt.Font.PLAIN, 16);
        graphics.setColor(SystemColor.windowText);
        graphics.setFont(font);
        graphics.drawString(newText, 10, 20);

        graphics.setColor(SystemColor.controlShadow);
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);

        graphics.setColor(SystemColor.controlDkShadow);
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);

        graphics.setColor(SystemColor.controlHighlight);
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);

        graphics.setColor(SystemColor.controlLtHighlight);
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);

        graphics.dispose();

        ByteArrayOutputStream baos = new ByteArrayOutputStream();
        ImageIO.write(image, "PNG", baos);

        control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(baos.toByteArray()));
    }

    // Cambiando el texto del botón
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);

    if (control.getName().equalsIgnoreCase("CommandButton1") && control.getProperties() != null) {
        String newCaption = "Show MessageBox";
        control.getProperties().set_Item("Caption", newCaption);
        // Cambiando la sustituta
        BufferedImage image = new BufferedImage((int) control.getFrame().getWidth(), (int) control.getFrame().getHeight(),
                BufferedImage.TYPE_INT_ARGB);
        java.awt.Graphics graphics = image.getGraphics();
        graphics.setColor(SystemColor.control);
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());

        java.awt.Font font = new java.awt.Font(control.getProperties().get_Item("FontName"), java.awt.Font.PLAIN, 16);
        graphics.setColor(SystemColor.windowText);
        graphics.setFont(font);
        FontMetrics metrics = graphics.getFontMetrics(font);
        graphics.drawString(newCaption, (image.getWidth() - metrics.stringWidth(newCaption)) / 2, 20);

        graphics.setColor(SystemColor.controlLtHighlight);
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);

        graphics.setColor(SystemColor.controlHighlight);
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);

        graphics.setColor(SystemColor.controlShadow);
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);

        graphics.setColor(SystemColor.controlDkShadow);
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);

        graphics.dispose();

        ByteArrayOutputStream baos = new ByteArrayOutputStream();
        ImageIO.write(image, "PNG", baos);

        control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(baos.toByteArray()));
    }

    // moviendo 100 puntos hacia abajo
    for (IControl ctl : pres.getSlides().get_Item(0).getControls()) {
        IShapeFrame frame = ctl.getFrame();
        ctl.setFrame(new ShapeFrame(frame.getX(), frame.getY() + 100,
                frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation()));
    }
    pres.save("withActiveX-edited_java.pptm", SaveFormat.Pptm);

    // eliminando controles
    pres.getSlides().get_Item(0).getControls().clear();
    pres.save("withActiveX-cleared_java.pptm", SaveFormat.Pptm);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Preguntas frecuentes**

**¿Aspose.Slides conserva los controles ActiveX al leer y volver a guardar si no pueden ejecutarse en el tiempo de ejecución de Java?**

Sí. Aspose.Slides los trata como parte de la presentación y puede leer/modificar sus propiedades y marcos; no es necesario ejecutar los controles para conservarlos.

**¿En qué se diferencian los controles ActiveX de los objetos OLE en una presentación?**

Los controles ActiveX son controles interactivos gestionados (botones, cuadros de texto, reproductor multimedia), mientras que [OLE](/slides/es/androidjava/manage-ole/) se refiere a objetos de aplicación incrustados (por ejemplo, una hoja de cálculo de Excel). Se almacenan y manejan de forma diferente y tienen modelos de propiedades distintos.

**¿Funcionan los eventos ActiveX y las macros VBA si el archivo ha sido modificado por Aspose.Slides?**

Aspose.Slides conserva el marcado y los metadatos existentes; sin embargo, los eventos y macros solo se ejecutan dentro de PowerPoint en Windows cuando la seguridad lo permite. La biblioteca no ejecuta VBA.