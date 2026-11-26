---
title: Gestionar controles ActiveX en presentaciones en .NET
linktitle: ActiveX
type: docs
weight: 80
url: /es/net/activex/
keywords:
- ActiveX
- control ActiveX
- gestionar ActiveX
- añadir ActiveX
- modificar ActiveX
- reproductor multimedia
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Edite cuadros de texto y botones ActiveX, actualice vistas previas de los controles y reutilice un control Windows Media Player en presentaciones de PowerPoint con Aspose.Slides para .NET."
---
## **Introducción**

Los controles ActiveX proporcionan a una diapositiva de PowerPoint elementos interactivos como cuadros de texto, botones de comando y reproductores multimedia. Aspose.Slides para .NET expone los controles de una diapositiva a través de [IBaseSlide.Controls](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/controls/). Utilice esta colección para editar un control, moverlo en la diapositiva o eliminarlo.

## **Listado de controles ActiveX y sus propiedades almacenadas**

Para inspeccionar una plantilla desconocida, ábrala en modo lectura e itere a través de los controles de cada diapositiva. El ejemplo indica el número de diapositiva, el nombre del control, [ClassId](https://reference.aspose.com/slides/net/aspose.slides/icontrol/classid/) y cada par clave‑valor en [Properties](https://reference.aspose.com/slides/net/aspose.slides/icontrol/#properties). Lee la presentación sin activar los controles, sin invocar eventos o macros, sin modificar valores ni guardar el archivo.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("ActiveX.pptm");

for (var i = 0; i < presentation.Slides.Count; i++)
{
    foreach (var control in presentation.Slides[i].Controls)
    {
        Console.WriteLine($"Slide {i + 1} | {control.Name} | {control.ClassId}");
        var properties = control.Properties;

        if (properties == null)
        {
            Console.WriteLine("  Properties unavailable");
            continue;
        }

        if (properties.Count == 0)
            Console.WriteLine("  []");

        foreach (var property in properties)
            Console.WriteLine($"  {property.Key} = {property.Value}");
    }
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

Una colección de propiedades vacía aparece como `[]`. Para los controles que utilizan almacenamiento binario, `Properties` puede devolver `null`, mostrado como `Properties unavailable`. Si solo necesita los nombres, use [NamesOfProperties](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/namesofproperties/) después de la comprobación de null. El informe enumera las propiedades disponibles en la presentación. Un control puede admitir propiedades adicionales en tiempo de ejecución.

## **Modificar controles ActiveX**

El ejemplo supone una presentación con macros habilitadas que contiene un cuadro de texto llamado `TextBox1` y un botón de comando llamado `CommandButton1` en la primera diapositiva. Utiliza la [colección de propiedades del control](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/) para cambiar el valor del cuadro de texto y el título del botón. Cada control también tiene una vista previa estática que PowerPoint puede mostrar antes de la activación. Proporcione un PNG para cada control que muestre su texto y apariencia actualizados. El ejemplo asigna estas imágenes mediante [IControl.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/icontrol/substitutepictureformat/).

El ejemplo desplaza todos los controles de la primera diapositiva 100 puntos hacia abajo cambiando su [Frame](https://reference.aspose.com/slides/net/aspose.slides/icontrol/frame/). Guarda la presentación editada en formato PPTM y luego usa [IControlCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icontrolcollection/clear/) para guardar una segunda copia con todos los controles ActiveX eliminados de esa diapositiva.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ActiveX.pptm");

var controls = presentation.Slides[0].Controls;
var textBox = controls.FirstOrDefault(control => control.Name == "TextBox1");
var button = controls.FirstOrDefault(control => control.Name == "CommandButton1");

if (textBox?.Properties == null || button?.Properties == null)
{
    Console.WriteLine("The first slide must contain both named controls with editable properties.");
    return;
}

if (!File.Exists("text-box-preview.png") || !File.Exists("button-preview.png"))
{
    Console.WriteLine("Supply both preview images before updating the controls.");
    return;
}

textBox.Properties["Value"] = "Changed text";
button.Properties["Caption"] = "Show message";

using var textBoxPreview = File.OpenRead("text-box-preview.png");
using var buttonPreview = File.OpenRead("button-preview.png");
textBox.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(textBoxPreview);
button.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(buttonPreview);

foreach (var control in controls)
{
    var frame = control.Frame;
    control.Frame = new ShapeFrame(frame.X, frame.Y + 100, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
}

presentation.Save("edited-controls.pptm", SaveFormat.Pptm);

controls.Clear();
presentation.Save("removed-controls.pptm", SaveFormat.Pptm);
```

## **Añadir un control ActiveX Media Player**

Para reutilizar un control Windows Media Player configurado, comience con una plantilla cuya primera diapositiva contiene un reproductor llamado `WindowsMediaPlayer1`. [ISlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/addclone/) copia toda la diapositiva en una nueva presentación. El ejemplo establece la `URL` del reproductor en su [colección de propiedades](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/) y guarda la diapositiva clonada como la única diapositiva en la salida. El vídeo permanece externo, por lo que debe elegir una ruta a la que el reproductor pueda acceder durante la reproducción.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var template = new Presentation("template.pptx");
using var presentation = new Presentation();

var slide = presentation.Slides.AddClone(template.Slides[0]);
var player = slide.Controls.FirstOrDefault(control => control.Name == "WindowsMediaPlayer1");

if (player?.Properties == null)
{
    Console.WriteLine("The template slide must contain a named media player with editable properties.");
    return;
}

player.Properties["URL"] = "Wildlife.mp4";

presentation.Slides.RemoveAt(0);
presentation.Save("linked-video.pptx", SaveFormat.Pptx);
```

## **Preguntas frecuentes**

**¿Puede Aspose.Slides conservar los controles ActiveX sin ejecutarlos?**

Sí. Aspose.Slides puede leer y guardar controles, incluidas sus propiedades y posiciones, sin activarlos.

**¿En qué se diferencian los controles ActiveX de los objetos OLE?**

Los controles ActiveX permiten a los usuarios interactuar con una diapositiva, por ejemplo introduciendo texto o haciendo clic en un botón. Un [objeto OLE](/slides/es/net/manage-ole/) permite que una diapositiva contenga o enlace a contenido gestionado por otra aplicación, como una hoja de cálculo de Excel.

**¿Continuarán los eventos ActiveX activando macros VBA después de guardar una presentación con Aspose.Slides?**

Guarde la presentación en un formato con macros habilitadas, como PPTM, para conservar su proyecto VBA. PowerPoint para Windows puede ejecutar los controladores de eventos existentes cuando su configuración de seguridad permite tanto los controles ActiveX como las macros.