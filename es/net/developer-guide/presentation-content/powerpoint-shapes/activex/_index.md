---
title: ActiveX
type: docs
weight: 80
url: /es/net/activex/
keywords: "ActiveX, controles de ActiveX, presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Gestionar controles de ActiveX en la presentación de PowerPoint en C# o .NET"
---

Los controles de ActiveX se utilizan en presentaciones. Aspose.Slides para .NET permite gestionar controles de ActiveX, pero gestionarlos es un poco más complicado y diferente de las formas normales de la presentación. A partir de Aspose.Slides para .NET 6.9.0, el componente admite la gestión de controles de ActiveX. En este momento, puedes acceder a los controles de ActiveX ya agregados en tu presentación y modificarlos o eliminarlos utilizando sus diversas propiedades. Recuerda que los controles de ActiveX no son formas y no forman parte de la IShapeCollection de la presentación, sino de la IControlCollection separada. Este artículo muestra cómo trabajar con ellos.
## **Modificar Controles de ActiveX**
Para gestionar un control de ActiveX simple como un cuadro de texto y un botón de comando simple en una diapositiva:

1. Crea una instancia de la clase Presentation y carga la presentación con controles de ActiveX en ella.
1. Obtén una referencia a la diapositiva por su índice.
1. Accede a los controles de ActiveX en la diapositiva accediendo a la IControlCollection.
1. Accede al control de ActiveX TextBox1 utilizando el objeto ControlEx.
1. Cambia las diferentes propiedades del control de ActiveX TextBox1, incluyendo texto, fuente, altura de la fuente y posición del marco.
1. Accede al segundo control de acceso llamado CommandButton1.
1. Cambia el texto del botón, la fuente y la posición.
1. Desplaza la posición de los marcos de los controles de ActiveX.
1. Escribe la presentación modificada en un archivo PPTX.

El fragmento de código a continuación actualiza los controles de ActiveX en las diapositivas de la presentación como se muestra a continuación.

```c#
// Accediendo a la presentación con controles de ActiveX
Presentation presentation = new Presentation("ActiveX.pptm");

// Accediendo a la primera diapositiva en la presentación
ISlide slide = presentation.Slides[0];

// cambiando el texto del TextBox
IControl control = slide.Controls[0];

if (control.Name == "TextBox1" && control.Properties != null)
{
    string newText = "Texto cambiado";
    control.Properties["Value"] = newText;

    // cambiando la imagen de sustitución. PowerPoint reemplazará esta imagen durante la activación de ActiveX, por lo que a veces está bien dejar la imagen sin cambios.

    Bitmap image = new Bitmap((int)control.Frame.Width, (int)control.Frame.Height);
    Graphics graphics = Graphics.FromImage(image);
    Brush brush = new SolidBrush(Color.FromKnownColor(KnownColor.Window));
    graphics.FillRectangle(brush, 0, 0, image.Width, image.Height);
    brush.Dispose();
    System.Drawing.Font font = new System.Drawing.Font(control.Properties["FontName"], 14);
    brush = new SolidBrush(Color.FromKnownColor(KnownColor.WindowText));
    graphics.DrawString(newText, font, brush, 10, 4);
    brush.Dispose();
    Pen pen = new Pen(Color.FromKnownColor(KnownColor.ControlDark), 1);
    graphics.DrawLines(
        pen, new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height - 1), new System.Drawing.Point(0, 0), new System.Drawing.Point(image.Width - 1, 0) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDarkDark), 1);

    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(1, image.Height - 2), new System.Drawing.Point(1, 1), new System.Drawing.Point(image.Width - 2, 1) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[]
    {
            new System.Drawing.Point(1, image.Height - 1), new System.Drawing.Point(image.Width - 1, image.Height - 1),
            new System.Drawing.Point(image.Width - 1, 1)
    });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLightLight), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height), new System.Drawing.Point(image.Width, image.Height), new System.Drawing.Point(image.Width, 0) });
    pen.Dispose();
    graphics.Dispose();
    control.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(image);
}

// cambiando el texto del botón
control = slide.Controls[1];

if (control.Name == "CommandButton1" && control.Properties != null)
{
    String newCaption = "MensajeBox";
    control.Properties["Caption"] = newCaption;

    // cambiando la imagen de sustitución
    Bitmap image = new Bitmap((int)control.Frame.Width, (int)control.Frame.Height);
    Graphics graphics = Graphics.FromImage(image);
    Brush brush = new SolidBrush(Color.FromKnownColor(KnownColor.Control));
    graphics.FillRectangle(brush, 0, 0, image.Width, image.Height);
    brush.Dispose();
    System.Drawing.Font font = new System.Drawing.Font(control.Properties["FontName"], 14);
    brush = new SolidBrush(Color.FromKnownColor(KnownColor.WindowText));
    SizeF textSize = graphics.MeasureString(newCaption, font, int.MaxValue);
    graphics.DrawString(newCaption, font, brush, (image.Width - textSize.Width) / 2, (image.Height - textSize.Height) / 2);
    brush.Dispose();
    Pen pen = new Pen(Color.FromKnownColor(KnownColor.ControlLightLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height - 1), new System.Drawing.Point(0, 0), new System.Drawing.Point(image.Width - 1, 0) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(1, image.Height - 2), new System.Drawing.Point(1, 1), new System.Drawing.Point(image.Width - 2, 1) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDark), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[]
    {
        new System.Drawing.Point(1, image.Height - 1),
        new System.Drawing.Point(image.Width - 1, image.Height - 1),
        new System.Drawing.Point(image.Width - 1, 1)
    });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDarkDark), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height), new System.Drawing.Point(image.Width, image.Height), new System.Drawing.Point(image.Width, 0) });
    pen.Dispose();
    graphics.Dispose();
    control.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(image);
}

// Desplazando los marcos de ActiveX 100 puntos hacia abajo
foreach (Control ctl in slide.Controls)
{
    IShapeFrame frame = control.Frame;
    control.Frame = new ShapeFrame(
        frame.X, frame.Y + 100, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
}

// Guardar la presentación con los controles de ActiveX editados
presentation.Save("withActiveX-edited_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);


// Ahora eliminando los controles
slide.Controls.Clear();

// Guardando la presentación con los controles de ActiveX limpiados
presentation.Save("withActiveX.cleared_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);
```


## **Agregar Control de Reproductor de Medios ActiveX**
Para agregar el control de Reproductor de Medios ActiveX, por favor realiza los siguientes pasos:

1. Crea una instancia de la clase Presentation y carga la presentación de muestra con controles de Reproductor de Medios ActiveX en ella.
1. Crea una instancia de la clase Presentation de destino y genera una instancia de presentación vacía.
1. Clona la diapositiva con el control de Reproductor de Medios ActiveX en la presentación de plantilla a la presentación de destino.
1. Accede a la diapositiva clonada en la presentación de destino.
1. Accede a los controles de ActiveX en la diapositiva accediendo a la IControlCollection.
1. Accede al control de Reproductor de Medios ActiveX y establece la ruta del video utilizando sus propiedades.
1. Guarda la presentación en un archivo PPTX.

```c#
// Instanciar la clase Presentation que representa el archivo PPTX
Presentation presentation = new Presentation("template.pptx");

// Crear instancia de presentación vacía
Presentation newPresentation = new Presentation();

// Eliminar la diapositiva predeterminada
newPresentation.Slides.RemoveAt(0);

// Clonar la diapositiva con el Control de Reproductor de Medios ActiveX
newPresentation.Slides.InsertClone(0, presentation.Slides[0]);

// Acceder al control de Reproductor de Medios ActiveX y establecer la ruta del video
newPresentation.Slides[0].Controls[0].Properties["URL"] = "Wildlife.mp4";

// Guardar la presentación
newPresentation.Save("LinkingVideoActiveXControl_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```