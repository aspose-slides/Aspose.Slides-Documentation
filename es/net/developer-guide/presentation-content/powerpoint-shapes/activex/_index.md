---
title: ActiveX
type: docs
weight: 80
url: /es/net/activex/
keywords: "ActiveX, controles ActiveX, presentación PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Gestionar controles ActiveX en presentaciones PowerPoint en C# o .NET"
---

Los controles ActiveX se utilizan en presentaciones. Aspose.Slides para .NET le permite administrar controles ActiveX, pero gestionarlos es un poco más complicado y diferente de las formas normales de la presentación. A partir de Aspose.Slides para .NET 6.9.0, el componente admite la administración de controles ActiveX. En este momento, puede acceder a los controles ActiveX ya agregados en su presentación y modificarlos o eliminarlos mediante sus diversas propiedades. Recuerde que los controles ActiveX no son formas y no forman parte de IShapeCollection de la presentación, sino de la IControlCollection independiente. Este artículo muestra cómo trabajar con ellos.
## **Modificar controles ActiveX**
1. Cree una instancia de la clase Presentation y cargue la presentación que contiene controles ActiveX.  
2. Obtenga una referencia a la diapositiva mediante su índice.  
3. Acceda a los controles ActiveX en la diapositiva mediante IControlCollection.  
4. Acceda al control ActiveX TextBox1 usando el objeto ControlEx.  
5. Modifique las distintas propiedades del control ActiveX TextBox1, incluyendo texto, fuente, altura de fuente y posición del marco.  
6. Acceda al segundo control llamado CommandButton1.  
7. Modifique el texto del botón, la fuente y la posición.  
8. Desplace la posición de los marcos de los controles ActiveX.  
9. Escriba la presentación modificada en un archivo PPTX.  

El fragmento de código a continuación actualiza los controles ActiveX en las diapositivas de la presentación como se muestra a continuación.  
```c#
// Accediendo a la presentación con controles ActiveX
Presentation presentation = new Presentation("ActiveX.pptm");

// Accediendo a la primera diapositiva en la presentación
ISlide slide = presentation.Slides[0];

// cambiando el texto del TextBox
IControl control = slide.Controls[0];

if (control.Name == "TextBox1" && control.Properties != null)
{
    string newText = "Changed text";
    control.Properties["Value"] = newText;

    // cambiando la imagen de sustituto. PowerPoint reemplazará esta imagen durante la activación de ActiveX, por lo que a veces está bien dejar la imagen sin cambios.

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
    String newCaption = "MessageBox";
    control.Properties["Caption"] = newCaption;

    // cambiando sustituto
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

// Moviendo los marcos ActiveX 100 puntos hacia abajo
foreach (Control ctl in slide.Controls)
{
    IShapeFrame frame = control.Frame;
    control.Frame = new ShapeFrame(
        frame.X, frame.Y + 100, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
}

// Guardar la presentación con controles ActiveX editados
presentation.Save("withActiveX-edited_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);


// Ahora eliminando controles
slide.Controls.Clear();

// Guardando la presentación con controles ActiveX limpiados
presentation.Save("withActiveX.cleared_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);
```


## **Agregar control ActiveX Media Player**
1. Cree una instancia de la clase Presentation y cargue la presentación de ejemplo que contiene controles ActiveX Media Player.  
2. Cree una instancia de la clase Presentation de destino y genere una instancia de presentación vacía.  
3. Clone la diapositiva con el control ActiveX Media Player de la presentación plantilla a la presentación de destino.  
4. Acceda a la diapositiva clonada en la presentación de destino.  
5. Acceda a los controles ActiveX en la diapositiva mediante IControlCollection.  
6. Acceda al control ActiveX Media Player y establezca la ruta del video mediante sus propiedades.  
7. Guarde la presentación en un archivo PPTX.  
```c#
// Instanciar la clase Presentation que representa un archivo PPTX
Presentation presentation = new Presentation("template.pptx");

// Crear una instancia de presentación vacía
Presentation newPresentation = new Presentation();

// Eliminar la diapositiva predeterminada
newPresentation.Slides.RemoveAt(0);

// Clonar la diapositiva con el control Media Player ActiveX
newPresentation.Slides.InsertClone(0, presentation.Slides[0]);

// Acceder al control Media Player ActiveX y establecer la ruta del video
newPresentation.Slides[0].Controls[0].Properties["URL"] = "Wildlife.mp4";

// Guardar la presentación
newPresentation.Save("LinkingVideoActiveXControl_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **Preguntas frecuentes**

**¿Aspose.Slides conserva los controles ActiveX al leer y volver a guardar si no pueden ejecutarse en el entorno de Python?**  
Sí. Aspose.Slides los trata como parte de la presentación y puede leer/modificar sus propiedades y marcos; no es necesario ejecutar los controles para conservarlos.

**¿En qué se diferencian los controles ActiveX de los objetos OLE en una presentación?**  
Los controles ActiveX son controles interactivos gestionados (botones, cuadros de texto, reproductor multimedia), mientras que [OLE](/slides/es/net/manage-ole/) se refiere a objetos de aplicación incrustados (por ejemplo, una hoja de cálculo de Excel). Se almacenan y manejan de forma diferente y poseen diferentes modelos de propiedades.

**¿Los eventos ActiveX y las macros VBA funcionan si el archivo ha sido modificado por Aspose.Slides?**  
Aspose.Slides conserva el marcado y los metadatos existentes; sin embargo, los eventos y macros solo se ejecutan dentro de PowerPoint en Windows cuando la seguridad lo permite. La biblioteca no ejecuta VBA.