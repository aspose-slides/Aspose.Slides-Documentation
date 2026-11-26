---
title: Gestionar controles ActiveX en presentaciones usando JavaScript
linktitle: ActiveX
type: docs
weight: 80
url: /es/nodejs-java/activex/
keywords:
- ActiveX
- control ActiveX
- gestionar ActiveX
- agregar ActiveX
- modificar ActiveX
- reproductor multimedia
- PowerPoint
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Edite cuadros de texto y botones ActiveX, actualice las vistas previas de los controles y reutilice un control Windows Media Player en presentaciones de PowerPoint con Aspose.Slides para Node.js mediante Java."
---
## **Introducción**

Los controles ActiveX proporcionan a una diapositiva de PowerPoint elementos interactivos como cuadros de texto, botones de comando y reproductores multimedia. Aspose.Slides para Node.js mediante Java expone los controles de una diapositiva a través de [BaseSlide.getControls](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getControls). Utilice esta colección para editar un control, moverlo en la diapositiva o eliminarlo.

## **Enumerar los controles ActiveX y sus propiedades almacenadas**

Para inspeccionar una plantilla desconocida, ábrala en modo lectura e itere a través de los controles de cada diapositiva. El ejemplo informa el número de diapositiva, el nombre del control, [getClassId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getClassId), y cada par clave‑valor en [getProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getProperties). Lee la presentación sin activar los controles, sin invocar eventos o macros, sin cambiar valores ni guardar el archivo.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("ActiveX.pptm");
try {
    const slideList = presentation.getSlides();
    for (let i = 0; i < slideList.size(); i++) {
        const controls = slideList.get_Item(i).getControls();
        for (let j = 0; j < controls.size(); j++) {
            const control = controls.get_Item(j);
            console.log(`Slide ${i + 1} | ${control.getName()} | ${control.getClassId()}`);
            const properties = control.getProperties();
            if (properties == null) {
                console.log("  Properties unavailable");
                continue;
            }
            if (properties.getCount() === 0) {
                console.log("  []");
            }
            const names = properties.getNamesOfProperties().iterator();
            while (names.hasNext()) {
                const name = names.next();
                console.log(`  ${name} = ${properties.get_Item(name)}`);
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

Una colección de propiedades vacía aparece como `[]`. Para los controles que utilizan almacenamiento binario, [getProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getProperties) puede devolver `null`, que se muestra como `Properties unavailable`. Si solo necesita los nombres, use [getNamesOfProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties) después de la verificación de null. El informe enumera las propiedades disponibles en la presentación. Un control puede admitir propiedades adicionales en tiempo de ejecución.

## **Modificar los controles ActiveX**

El ejemplo espera una presentación con macros que contenga un cuadro de texto llamado `TextBox1` y un botón de comando llamado `CommandButton1` en la primera diapositiva. Utiliza la [control properties collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/) para cambiar el valor del cuadro de texto y el título del botón. Cada control también tiene una vista previa estática que PowerPoint puede mostrar antes de la activación. Proporcione un PNG para cada control que muestre su texto y aspecto actualizados. El ejemplo asigna estas imágenes mediante [Control.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getSubstitutePictureFormat).

El ejemplo desplaza todos los controles de la primera diapositiva 100 puntos hacia abajo estableciendo su marco con [Control.setFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#setFrame). Guarda la presentación editada en formato PPTM y, a continuación, utiliza [ControlCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlcollection/#clear) para guardar una segunda copia con todos los controles ActiveX eliminados de esa diapositiva.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function addPreview(presentation, path) {
    const image = slides.Images.fromFile(path);
    try {
        return presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }
}

function editControls() {
    const presentation = new slides.Presentation("ActiveX.pptm");
    try {
        const controls = presentation.getSlides().get_Item(0).getControls();
        let textBox;
        let button;
        for (let i = 0; i < controls.size(); i++) {
            const control = controls.get_Item(i);
            if (control.getName() === "TextBox1") {
                textBox = control;
            } else if (control.getName() === "CommandButton1") {
                button = control;
            }
        }
        if (!textBox || !button || textBox.getProperties() == null || button.getProperties() == null) {
            console.log("The first slide must contain both named controls with editable properties.");
            return;
        }

        const textBoxPreview = addPreview(presentation, "text-box-preview.png");
        const buttonPreview = addPreview(presentation, "button-preview.png");
        textBox.getProperties().set_Item("Value", "Changed text");
        button.getProperties().set_Item("Caption", "Show message");
        textBox.getSubstitutePictureFormat().getPicture().setImage(textBoxPreview);
        button.getSubstitutePictureFormat().getPicture().setImage(buttonPreview);

        for (let i = 0; i < controls.size(); i++) {
            const control = controls.get_Item(i);
            const frame = control.getFrame();
            const flipH = java.newByte(frame.getFlipH());
            const flipV = java.newByte(frame.getFlipV());
            const moved = new slides.ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), flipH, flipV, frame.getRotation());
            control.setFrame(moved);
        }
        presentation.save("edited-controls.pptm", slides.SaveFormat.Pptm);

        controls.clear();
        presentation.save("removed-controls.pptm", slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}

editControls();
```
## **Agregar un control ActiveX de reproductor multimedia**

Para reutilizar un control Windows Media Player configurado, comience con una plantilla cuya primera diapositiva contiene un reproductor llamado `WindowsMediaPlayer1`. [SlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/#addClone) copia toda la diapositiva en una nueva presentación. El ejemplo establece la `URL` del reproductor en su [properties collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/) y guarda la diapositiva clonada como la única diapositiva en la salida. El video permanece externo, por lo que debe elegir una ruta a la que el reproductor pueda acceder durante la reproducción.

```javascript
const slides = require("aspose.slides.via.java");

function addMediaPlayer() {
    const template = new slides.Presentation("template.pptx");
    try {
        const presentation = new slides.Presentation();
        try {
            const templateSlide = template.getSlides().get_Item(0);
            const slide = presentation.getSlides().addClone(templateSlide);
            const controls = slide.getControls();
            let player;
            for (let i = 0; i < controls.size(); i++) {
                const control = controls.get_Item(i);
                if (control.getName() === "WindowsMediaPlayer1") {
                    player = control;
                    break;
                }
            }
            if (!player || player.getProperties() == null) {
                console.log("The template slide must contain a named media player with editable properties.");
                return;
            }
            player.getProperties().set_Item("URL", "Wildlife.mp4");
            
            presentation.getSlides().removeAt(0);
            presentation.save("linked-video.pptx", slides.SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    } finally {
        template.dispose();
    }
}

addMediaPlayer();
```
## **Preguntas frecuentes**

**¿Puede Aspose.Slides conservar los controles ActiveX sin ejecutarlos?**

Sí. Aspose.Slides puede leer y guardar los controles, incluidas sus propiedades y posiciones, sin activarlos.

**¿En qué se diferencian los controles ActiveX de los objetos OLE?**

Los controles ActiveX permiten a los usuarios interactuar con una diapositiva, por ejemplo introduciendo texto o pulsando un botón. Un [OLE object](/slides/es/nodejs-java/manage-ole/) permite que una diapositiva contenga o enlace a contenido gestionado por otra aplicación, como una hoja de cálculo de Excel.

**¿Seguirán los eventos ActiveX activar macros VBA después de guardar una presentación con Aspose.Slides?**

Guarde la presentación en un formato habilitado para macros, como PPTM, para conservar su proyecto VBA. PowerPoint para Windows puede ejecutar los controladores de eventos existentes cuando su configuración de seguridad permite tanto controles ActiveX como macros.