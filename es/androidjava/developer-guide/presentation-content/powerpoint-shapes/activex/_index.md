---
title: ActiveX
type: docs
weight: 80
url: /androidjava/activex/
---


{{% alert color="primary" %}} 

Los controles ActiveX se utilizan en presentaciones. Aspose.Slides para Android a través de Java te permite agregar y gestionar controles ActiveX, pero son un poco más complicados de manejar en comparación con las formas normales de presentación. Hemos implementado soporte para agregar el control ActiveX de Media Player en Aspose.Slides. Ten en cuenta que los controles ActiveX no son formas; no son parte de la [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IShapeCollection) de la presentación. Son parte de la [IControlCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IControlCollection) en su lugar. En este tema, te mostraremos cómo trabajar con ellos.

{{% /alert %}} 

## **Agregar control ActiveX de Media Player a la diapositiva**
Para agregar un control ActiveX de Media Player, haz lo siguiente:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) y genera una instancia de presentación vacía.
1. Accede a la diapositiva objetivo en [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Agrega el control ActiveX de Media Player usando el método [addControl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) expuesto por [IControlCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IControlCollection).
1. Accede al control ActiveX de Media Player y establece la ruta del video utilizando sus propiedades.
1. Guarda la presentación como un archivo PPTX.

Este código de muestra, basado en los pasos anteriores, muestra cómo agregar un control ActiveX de Media Player a una diapositiva:

```java
// Crear instancia de presentación vacía
Presentation pres = new Presentation();
try {
    // Agregar el control ActiveX de Media Player
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // Acceder al control ActiveX de Media Player y establecer la ruta del video
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // Guardar la presentación
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Modificar control ActiveX**
{{% alert color="primary" %}} 

Aspose.Slides para Android a través de Java 7.1.0 y versiones más recientes vienen equipadas con componentes para gestionar controles ActiveX. Puedes acceder al control ActiveX ya añadido en tu presentación y modificar o eliminarlo a través de sus propiedades.

{{% /alert %}} 

Para gestionar un control ActiveX simple como un cuadro de texto y un botón de comando simple en una diapositiva, haz lo siguiente:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) y carga la presentación con controles ActiveX en ella.
1. Obtén una referencia a la diapositiva por su índice.
1. Accede a los controles ActiveX en la diapositiva accediendo a la [IControlCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IControlCollection).
1. Accede al control ActiveX TextBox1 utilizando el objeto [IControl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IControl).
1. Cambia las propiedades del control ActiveX TextBox1 que incluyen texto, fuente, altura de fuente y posición del marco.
1. Accede al segundo control de acceso llamado CommandButton1.
1. Cambia el título del botón, la fuente y la posición.
1. Cambia la posición de los marcos de los controles ActiveX.
1. Escribe la presentación modificada en un archivo PPTX.

Este código de muestra, basado en los pasos anteriores, muestra cómo gestionar un control ActiveX simple: 

```java
// Accediendo a la presentación con controles ActiveX
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // Accediendo a la primera diapositiva en la presentación
    ISlide slide = pres.getSlides().get_Item(0);

    // cambiando el texto del TextBox
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "Texto cambiado";
        control.getProperties().set_Item("Value", newText);

        // Cambiando la imagen sustituta. PowerPoint reemplazará esta imagen durante la activación de ActiveX,
        // así que a veces está bien dejar la imagen sin cambios.
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

    // Cambiando el título del botón
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);

    if (control.getName().equalsIgnoreCase("CommandButton1") && control.getProperties() != null) {
        String newCaption = "Mostrar MessageBox";
        control.getProperties().set_Item("Caption", newCaption);
        // Cambiando sustituto
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