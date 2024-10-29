---
title: ActiveX
type: docs
weight: 80
url: /es/cpp/activex/
---


Los controles ActiveX se utilizan en presentaciones. Aspose.Slides para C++ te permite gestionar controles ActiveX, pero gestionarlos es un poco más complicado y diferente de las formas normales de presentación. A partir de Aspose.Slides para C++ 18.1, el componente admite la gestión de controles ActiveX. En este momento, puedes acceder a los controles ActiveX ya añadidos en tu presentación y modificarlos o eliminarlos utilizando sus diversas propiedades. Recuerda que los controles ActiveX no son formas y no son parte de la IShapeCollection de la presentación, sino de la IControlCollection separada. Este artículo muestra cómo trabajar con ellos.

## **Modificar Control ActiveX**
Para gestionar un control ActiveX simple como un cuadro de texto y un botón de comando simple en una diapositiva:

1. Crea una instancia de la clase Presentation y carga la presentación con controles ActiveX en ella.
1. Obtén una referencia a la diapositiva por su índice.
1. Accede a los controles ActiveX en la diapositiva accediendo a la IControlCollection.
1. Accede al control ActiveX TextBox1 utilizando el objeto ControlEx.
1. Cambia las diferentes propiedades del control ActiveX TextBox1, incluyendo texto, fuente, altura de fuente y posición del marco.
1. Accede al segundo control llamado CommandButton1.
1. Cambia el texto del botón, la fuente y la posición.
1. Desplaza la posición de los marcos de los controles ActiveX.
1. Escribe la presentación modificada en un archivo PPTX.

El fragmento de código a continuación actualiza los controles ActiveX en las diapositivas de la presentación como se muestra a continuación.

``` cpp
// Accediendo a la presentación con controles ActiveX
auto presentation = System::MakeObject<Presentation>(u"ActiveX.pptm");

// Accediendo a la primera diapositiva en la presentación
auto slide = presentation->get_Slides()->idx_get(0);

// cambiando el texto del TextBox
auto control = slide->get_Controls()->idx_get(0);

if (control->get_Name() == u"TextBox1" && control->get_Properties() != nullptr)
{
    String newText = u"Texto cambiado";
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
    String newCaption = u"MensajeBox";
    control->get_Properties()->idx_set(u"Caption", newCaption);

    // cambiando la imagen de sustitución
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

// Guardar la presentación con los controles ActiveX editados
presentation->Save(u"withActiveX-edited_out.pptm", SaveFormat::Pptm);

// Ahora eliminando los controles
slide->get_Controls()->Clear();

// Guardando la presentación con los controles ActiveX eliminados
presentation->Save(u"withActiveX.cleared_out.pptm", SaveFormat::Pptm);
```

## **Agregar Control ActiveX de Reproductor de Medios**
Los controles ActiveX se utilizan en presentaciones. Aspose.Slides para C++ te permite agregar y gestionar controles ActiveX, pero gestionarlos es un poco más complicado y diferente de las formas normales de presentación. A partir de Aspose.Slides para C++ 18.1, se ha añadido soporte para agregar controles ActiveX de Reproductor de Medios en Aspose.Slides. Recuerda que los controles ActiveX no son formas y no son parte de la IShapeCollection de la presentación, sino de la IControlExCollection separada. Este artículo muestra cómo trabajar con ellos. Para gestionar un control ActiveX de Reproductor de Medios, realiza los siguientes pasos:

1. Crea una instancia de la clase Presentation y carga la presentación de ejemplo con controles ActiveX de Reproductor de Medios en ella.
1. Crea una instancia de la clase Presentation de destino y genera una instancia de presentación vacía.
1. Clona la diapositiva con el control ActiveX de Reproductor de Medios en la presentación de plantilla a la presentación de destino.
1. Accede a la diapositiva clonada en la presentación de destino.
1. Accede a los controles ActiveX en la diapositiva accediendo a la IControlCollection.
1. Accede al control ActiveX de Reproductor de Medios y establece la ruta del video utilizando sus propiedades.
1. Guarda la presentación en un archivo PPTX.

``` cpp
// Instanciando la clase Presentation que representa un archivo PPTX
auto presentation = System::MakeObject<Presentation>(u"template.pptx");

// Crear una instancia de presentación vacía
auto newPresentation = System::MakeObject<Presentation>();

// Eliminar la diapositiva predeterminada
newPresentation->get_Slides()->RemoveAt(0);

// Clonar la diapositiva con Control ActiveX de Reproductor de Medios
newPresentation->get_Slides()->InsertClone(0, presentation->get_Slides()->idx_get(0));

// Acceder al control ActiveX de Reproductor de Medios y establecer la ruta del video
newPresentation->get_Slides()->idx_get(0)->get_Controls()->idx_get(0)->get_Properties()->idx_set(u"URL", u"Wildlife.mp4");

// Guardar la Presentación
newPresentation->Save(u"LinkingVideoActiveXControl_out.pptx", SaveFormat::Pptx);
```