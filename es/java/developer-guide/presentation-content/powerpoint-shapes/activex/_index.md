---
title: Gestionar controles ActiveX en presentaciones en Java
linktitle: ActiveX
type: docs
weight: 80
url: /es/java/activex/
keywords:
- ActiveX
- control ActiveX
- gestionar ActiveX
- añadir ActiveX
- modificar ActiveX
- reproductor multimedia
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Edite cuadros de texto y botones ActiveX, actualice las vistas previas de los controles y reutilice un control de Windows Media Player en presentaciones de PowerPoint con Aspose.Slides para Java."
---
## **Introducción**

Los controles ActiveX proporcionan a una diapositiva de PowerPoint elementos interactivos como cuadros de texto, botones de comando y reproductores multimedia. Aspose.Slides for Java expone los controles de una diapositiva a través de [IBaseSlide.getControls](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getControls--). Utilice esta colección para editar un control, moverlo en la diapositiva o eliminarlo.

## **Enumerar controles ActiveX y sus propiedades almacenadas**

Para inspeccionar una plantilla desconocida, ábrala para lectura e itere sobre los controles de cada diapositiva. El ejemplo informa el número de diapositiva, el nombre del control, [getClassId](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getClassId--), y cada par clave‑valor en [getProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getProperties--). Lee la presentación sin activar los controles, sin invocar eventos o macros, sin cambiar valores y sin guardar el archivo.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ActiveX.pptm");
try {
    for (int i = 0; i < presentation.getSlides().size(); i++) {
        for (IControl control : presentation.getSlides().get_Item(i).getControls()) {
            System.out.printf("Slide %d | %s | %s%n", i + 1, control.getName(), control.getClassId());
            IControlPropertiesCollection properties = control.getProperties();
            if (properties == null) {
                System.out.println("  Properties unavailable");
                continue;
            }
            if (properties.getCount() == 0) {
                System.out.println("  []");
            }
            for (String name : properties.getNamesOfProperties()) {
                System.out.printf("  %s = %s%n", name, properties.get_Item(name));
            }
        }
    }
} finally {
    presentation.dispose();
}
```

La salida seleccionada de `ActiveX.pptm` muestra un cuadro de texto y un botón de comando.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Una colección de propiedades vacía aparece como `[]`. Para los controles que usan almacenamiento binario, [getProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getProperties--) puede devolver `null`, que se muestra como `Properties unavailable`. Si sólo necesita los nombres, use [getNamesOfProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/#getNamesOfProperties--) después de comprobar el `null`. El informe enumera las propiedades disponibles en la presentación. Un control puede admitir propiedades adicionales en tiempo de ejecución.

## **Modificar controles ActiveX**

El ejemplo necesita una presentación con macros que contenga un cuadro de texto llamado `TextBox1` y un botón de comando llamado `CommandButton1` en la primera diapositiva. Utiliza la [control properties collection](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/) para cambiar el valor del cuadro de texto y el texto del botón. Cada control también tiene una vista previa estática que PowerPoint puede mostrar antes de la activación. Proporcione un PNG para cada control que muestre su texto y apariencia actualizados. El ejemplo asigna estas imágenes a través de [IControl.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getSubstitutePictureFormat--).

El ejemplo mueve cada control de la primera diapositiva 100 puntos hacia abajo estableciendo su marco con [IControl.setFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#setFrame-com.aspose.slides.IShapeFrame-). Guarda la presentación editada en formato PPTM y, a continuación, usa [IControlCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolcollection/#clear--) para guardar una segunda copia sin los controles ActiveX de esa diapositiva.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("ActiveX.pptm");
try {
    IControlCollection controls = presentation.getSlides().get_Item(0).getControls();
    IControl textBox = null;
    IControl button = null;
    for (IControl control : controls) {
        if ("TextBox1".equals(control.getName())) {
            textBox = control;
        } else if ("CommandButton1".equals(control.getName())) {
            button = control;
        }
    }
    if (textBox == null || button == null || textBox.getProperties() == null || button.getProperties() == null) {
        System.out.println("The first slide must contain both named controls with editable properties.");
        return;
    }

    Path textBoxPath = Paths.get("text-box-preview.png");
    Path buttonPath = Paths.get("button-preview.png");
    byte[] textBoxBytes = Files.readAllBytes(textBoxPath);
    byte[] buttonBytes = Files.readAllBytes(buttonPath);
    IPPImage textBoxPreview = presentation.getImages().addImage(textBoxBytes);
    IPPImage buttonPreview = presentation.getImages().addImage(buttonBytes);
    textBox.getProperties().set_Item("Value", "Changed text");
    button.getProperties().set_Item("Caption", "Show message");
    textBox.getSubstitutePictureFormat().getPicture().setImage(textBoxPreview);
    button.getSubstitutePictureFormat().getPicture().setImage(buttonPreview);

    for (IControl control : controls) {
        IShapeFrame frame = control.getFrame();
        ShapeFrame moved = new ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation());
        control.setFrame(moved);
    }
    presentation.save("edited-controls.pptm", SaveFormat.Pptm);

    controls.clear();
    presentation.save("removed-controls.pptm", SaveFormat.Pptm);
} catch (IOException e) {
    System.out.println("Could not read a control preview: " + e.getMessage());
} finally {
    presentation.dispose();
}
```

## **Agregar un control de reproductor multimedia ActiveX**

Para reutilizar un control de Windows Media Player configurado, comience con una plantilla cuya primera diapositiva contenga un reproductor llamado `WindowsMediaPlayer1`. [ISlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) copia la diapositiva completa a una nueva presentación. El ejemplo establece la `URL` del reproductor en su [properties collection](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/) y guarda la diapositiva clonada como la única diapositiva de salida. El vídeo permanece externo, por lo que debe elegir una ruta a la que el reproductor pueda acceder durante la reproducción.

```java
import com.aspose.slides.*;

Presentation template = new Presentation("template.pptx");
try {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().addClone(template.getSlides().get_Item(0));
        IControl player = null;
        for (IControl control : slide.getControls()) {
            if ("WindowsMediaPlayer1".equals(control.getName())) {
                player = control;
                break;
            }
        }
        if (player == null || player.getProperties() == null) {
            System.out.println("The template slide must contain a named media player with editable properties.");
            return;
        }
        player.getProperties().set_Item("URL", "Wildlife.mp4");
        
        presentation.getSlides().removeAt(0);
        presentation.save("linked-video.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    template.dispose();
}
```

## **Preguntas frecuentes**

**¿Puede Aspose.Slides conservar los controles ActiveX sin ejecutarlos?**

Sí. Aspose.Slides puede leer y guardar los controles, incluidas sus propiedades y posiciones, sin activarlos.

**¿En qué se diferencian los controles ActiveX de los objetos OLE?**

Los controles ActiveX permiten a los usuarios interactuar con una diapositiva, por ejemplo ingresando texto o pulsando un botón. Un [objeto OLE](/slides/es/java/manage-ole/) permite que una diapositiva contenga o vincule contenido gestionado por otra aplicación, como una hoja de cálculo de Excel.

**¿Seguirán los eventos ActiveX disparar macros VBA después de guardar una presentación con Aspose.Slides?**

Guarde la presentación en un formato habilitado para macros, como PPTM, para conservar su proyecto VBA. PowerPoint para Windows puede ejecutar los controladores de eventos existentes cuando su configuración de seguridad permite tanto controles ActiveX como macros.