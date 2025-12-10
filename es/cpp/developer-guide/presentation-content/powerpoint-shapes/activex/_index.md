---
title: Administrar controles ActiveX en presentaciones usando C++
linktitle: ActiveX
type: docs
weight: 80
url: /es/cpp/activex/
keywords:
- ActiveX
- Control ActiveX
- Gestionar ActiveX
- Añadir ActiveX
- Modificar ActiveX
- Reproductor multimedia
- PowerPoint
- Presentación
- C++
- Aspose.Slides
description: "Aprenda cómo Aspose.Slides para C++ aprovecha ActiveX para automatizar y mejorar presentaciones de PowerPoint, proporcionando a los desarrolladores un control potente sobre las diapositivas."
---

Los controles ActiveX se usan en presentaciones. Aspose.Slides for C++ le permite administrar controles ActiveX, pero su gestión es un poco más complicada y diferente de las formas normales de la presentación. A partir de Aspose.Slides for C++ 18.1, el componente admite la gestión de controles ActiveX. En este momento, puede acceder a los controles ActiveX ya añadidos en su presentación y modificarlos o eliminarlos mediante sus diversas propiedades. Recuerde, los controles ActiveX no son formas y no forman parte de IShapeCollection de la presentación sino de la IControlCollection separada. Este artículo muestra cómo trabajar con ellos.

## **Modificar un control ActiveX**
1. Crear una instancia de la clase Presentation y cargar la presentación que contiene controles ActiveX.
1. Obtener una referencia a la diapositiva por su índice.
1. Acceder a los controles ActiveX en la diapositiva mediante IControlCollection.
1. Acceder al control ActiveX TextBox1 usando el objeto ControlEx.
1. Cambiar las diferentes propiedades del control ActiveX TextBox1, incluyendo texto, fuente, altura de fuente y posición del marco.
1. Acceder al segundo control llamado CommandButton1.
1. Cambiar el texto del botón, la fuente y la posición.
1. Desplazar la posición de los marcos de los controles ActiveX.
1. Guardar la presentación modificada en un archivo PPTX.

El fragmento de código a continuación actualiza los controles ActiveX en las diapositivas de la presentación como se muestra a continuación.
```cpp
// Accediendo a la presentación con  controles ActiveX
auto presentation = System::MakeObject<Presentation>(u"ActiveX.pptm");

// Accediendo a la primera diapositiva de la presentación
auto slide = presentation->get_Slides()->idx_get(0);

// cambiando el texto del TextBox
auto control = slide->get_Controls()->idx_get(0);

if (control->get_Name() == u"TextBox1" && control->get_Properties() != nullptr)
{
    String newText = u"Changed text";
    control->get_Properties()->idx_set(u"Value", newText);

    // cambiando la imagen de sustitución. PowerPoint reemplazará esta imagen durante la activación de ActiveX, así que a veces está bien dejar la imagen sin cambios.
    auto image = System::MakeObject<Bitmap>((int32_t)control->get_Frame()->get_Width(), (int32_t)control->get_Frame()->get_Height());
    auto graphics = Graphics::FromImage(image);
    auto brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::Window));
    graphics->FillRectangle(brush, 0, 0, image->get_Width(), image->get_Height());

    auto font = System::MakeObject<Font>(control->get_Properties()->idx_get(u"FontName"), 14.0f);
    brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::WindowText));
    graphics->DrawString(newText, font, brush, 10.0f, 4.0f);

    auto pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height() - 1), Point(0, 0), System::Drawing::Point(image->get_Width() - 1, 0) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDarkDark), 1.0f);

    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 2), Point(1, 1), System::Drawing::Point(image->get_Width() - 2, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLightLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height()), System::Drawing::Point(image->get_Width(), image->get_Height()), System::Drawing::Point(image->get_Width(), 0) }));

    System::SharedPtr<System::IO::MemoryStream> ms = System::MakeObject<System::IO::MemoryStream>();
    image->Save(ms, System::Drawing::Imaging::ImageFormat::get_Png());
    ms->Seek(0, System::IO::SeekOrigin::Begin);
    control->get_SubstitutePictureFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(ms));
}

// cambiando el texto del botón
control = slide->get_Controls()->idx_get(1);

if (control->get_Name() == u"CommandButton1" && control->get_Properties() != nullptr)
{
    String newCaption = u"MessageBox";
    control->get_Properties()->idx_set(u"Caption", newCaption);

    // cambiando la imagen sustituta
    auto image = System::MakeObject<Bitmap>((int32_t)control->get_Frame()->get_Width(), (int32_t)control->get_Frame()->get_Height());
    auto graphics = Graphics::FromImage(image);
    auto brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::Control));
    graphics->FillRectangle(brush, 0, 0, image->get_Width(), image->get_Height());

    auto font = System::MakeObject<Font>(control->get_Properties()->idx_get(u"FontName"), 14.0f);
    brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::WindowText));
    SizeF textSize = graphics->MeasureString(newCaption, font, std::numeric_limits<int32_t>::max());
    graphics->DrawString(newCaption, font, brush, (image->get_Width() - textSize.get_Width()) / 2, (image->get_Height() - textSize.get_Height()) / 2);

    auto pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLightLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height() - 1), Point(0, 0), System::Drawing::Point(image->get_Width() - 1, 0) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 2), Point(1, 1), System::Drawing::Point(image->get_Width() - 2, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDarkDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height()), System::Drawing::Point(image->get_Width(), image->get_Height()), System::Drawing::Point(image->get_Width(), 0) }));

    System::SharedPtr<System::IO::MemoryStream> ms = System::MakeObject<System::IO::MemoryStream>();
    image->Save(ms, System::Drawing::Imaging::ImageFormat::get_Png());
    ms->Seek(0, System::IO::SeekOrigin::Begin);
    control->get_SubstitutePictureFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(ms));
}

// Moviendo los marcos ActiveX 100 puntos hacia abajo
for (const auto& ctl : System::IterateOver<Control>(slide->get_Controls()))
{
    SharedPtr<IShapeFrame> frame = control->get_Frame();
    control->set_Frame(System::MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y() + 100, frame->get_Width(), frame->get_Height(), frame->get_FlipH(), frame->get_FlipV(), frame->get_Rotation()));
}

// Guardando la presentación con controles ActiveX editados
presentation->Save(u"withActiveX-edited_out.pptm", SaveFormat::Pptm);

// Ahora eliminando los controles
slide->get_Controls()->Clear();

// Guardando la presentación con controles ActiveX eliminados
presentation->Save(u"withActiveX.cleared_out.pptm", SaveFormat::Pptm);
```


## **Agregar un control ActiveX Media Player**
Los controles ActiveX se usan en presentaciones. Aspose.Slides for C++ le permite agregar y administrar controles ActiveX, pero su gestión es un poco más complicada y diferente de las formas normales de la presentación. A partir de Aspose.Slides for C++ 18.1, se ha añadido soporte para agregar controles ActiveX Media Player en Aspose.Slides. Recuerde, los controles ActiveX no son formas y no forman parte de IShapeCollection de la presentación sino de la IControlExCollection separada. Este artículo muestra cómo trabajar con ellos. Para administrar un control ActiveX Media Player, siga los siguientes pasos:

1. Crear una instancia de la clase Presentation y cargar la presentación de ejemplo que contiene controles ActiveX Media Player.
1. Crear una instancia de la clase Presentation de destino y generar una instancia de presentación vacía.
1. Clonar la diapositiva con el control ActiveX Media Player de la presentación plantilla a la presentación de destino.
1. Acceder a la diapositiva clonada en la presentación de destino.
1. Acceder a los controles ActiveX en la diapositiva mediante IControlCollection.
1. Acceder al control ActiveX Media Player y establecer la ruta del video usando sus propiedades.
1. Guardar la presentación en un archivo PPTX.
```cpp
// Instanciar la clase Presentation que representa un archivo PPTX
auto presentation = System::MakeObject<Presentation>(u"template.pptx");

// Crear una instancia de presentación vacía
auto newPresentation = System::MakeObject<Presentation>();

// Eliminar la diapositiva predeterminada
newPresentation->get_Slides()->RemoveAt(0);

// Clonar la diapositiva con el control ActiveX Media Player
newPresentation->get_Slides()->InsertClone(0, presentation->get_Slides()->idx_get(0));

// Acceder al control ActiveX Media Player y establecer la ruta del video
newPresentation->get_Slides()->idx_get(0)->get_Controls()->idx_get(0)->get_Properties()->idx_set(u"URL", u"Wildlife.mp4");

// Guardar la presentación
newPresentation->Save(u"LinkingVideoActiveXControl_out.pptx", SaveFormat::Pptx);
```


## **Preguntas frecuentes**

**¿Aspose.Slides conserva los controles ActiveX al leer y volver a guardar si no pueden ejecutarse en tiempo de ejecución de C++?**

Sí. Aspose.Slides los trata como parte de la presentación y puede leer/modificar sus propiedades y marcos; no es necesario ejecutar los controles para conservarlos.

**¿En qué se diferencian los controles ActiveX de los objetos OLE en una presentación?**

Los controles ActiveX son controles interactivos gestionados (botones, cuadros de texto, reproductor multimedia), mientras que [OLE](/slides/es/cpp/manage-ole/) se refiere a objetos de aplicación incrustados (por ejemplo, una hoja de cálculo de Excel). Se almacenan y manejan de forma diferente y poseen modelos de propiedades diferentes.

**¿Los eventos ActiveX y las macros VBA funcionan si el archivo ha sido modificado por Aspose.Slides?**

Aspose.Slides conserva el marcado y los metadatos existentes; sin embargo, los eventos y macros solo se ejecutan dentro de PowerPoint en Windows cuando la seguridad lo permite. La biblioteca no ejecuta VBA.