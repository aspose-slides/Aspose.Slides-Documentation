---
title: Gestionar Marcador de Posición
type: docs
weight: 10
url: /cpp/manage-placeholder/
keywords: "Marcador de posición, Texto del marcador de posición, Texto del aviso, Presentación de PowerPoint, C++, CPP, Aspose.Slides para C++"
description: "Cambiar el texto del marcador de posición y el texto del aviso en presentaciones de PowerPoint en C++"
---

## **Cambiar el Texto en el Marcador de Posición**
Usando [Aspose.Slides para C++](/slides/cpp/), puedes encontrar y modificar marcadores de posición en diapositivas de presentaciones. Aspose.Slides te permite realizar cambios en el texto de un marcador de posición.

**Prerequisito**: Necesitas una presentación que contenga un marcador de posición. Puedes crear una presentación así en la aplicación estándar de Microsoft PowerPoint.

Así es como utilizas Aspose.Slides para reemplazar el texto en el marcador de posición en esa presentación:

1. Instancia la clase [`Presentation`](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) y pasa la presentación como argumento.
2. Obtén una referencia a una diapositiva a través de su índice.
3. Itera a través de las formas para encontrar el marcador de posición.
4. Realiza un typecast de la forma del marcador de posición a un [`AutoShape`](https://reference.aspose.com/slides/cpp/class/aspose.slides.auto_shape/) y cambia el texto usando el [`TextFrame`](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame/) asociado con el [`AutoShape`](https://reference.aspose.com/slides/cpp/class/aspose.slides.auto_shape/).
5. Guarda la presentación modificada.

Este código C++ muestra cómo cambiar el texto en un marcador de posición:

```c++
// La ruta al directorio de documentos.
const String outPath = u"../out/ReemplazandoTexto_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// Carga la presentación deseada
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// Accede a la primera diapositiva
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Accede al primer y segundo marcador de posición en la diapositiva y realiza un typecast como AutoShape
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);
SharedPtr<AutoShape> ashp = ExplicitCast<Aspose::Slides::AutoShape>(shape);

SharedPtr<ITextFrame> textframe = ashp->get_TextFrame();

textframe->set_Text(u"Este es el Marcador de Posición");
	
// Guarda la presentación en el disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Establecer Texto del Aviso en el Marcador de Posición**
Las maquetas estándar y predefinidas contienen textos de aviso de marcador de posición como ***Haz clic para agregar un título*** o ***Haz clic para agregar un subtitulo***. Usando Aspose.Slides, puedes insertar tus textos de aviso preferidos en las maquetas de marcador de posición.

Este código C++ te muestra cómo establecer el texto del aviso en un marcador de posición:

```c++
const System::String templatePath = u"../templates/Presentation2.pptx";
    
auto pres = System::MakeObject<Presentation>(templatePath);
auto slide = pres->get_Slides()->idx_get(0);

for (auto& shape : slide->get_Shapes())
{
    if (shape->get_Placeholder() != NULL)
    {
        System::String text = u"";
        if (shape->get_Placeholder()->get_Type() == PlaceholderType::CenteredTitle) // Cuando no hay texto en él, PowerPoint muestra "Haz clic para agregar título". 
        {
            text = u"Haz clic para agregar título";
        }
        else if (shape->get_Placeholder()->get_Type() == PlaceholderType::Subtitle) // Hace lo mismo para el subtitulo.
        {
            text = u"Haz clic para agregar subtítulo";
        }
        System::Console::WriteLine(u"Marcador de Posición : {0}", text);
    }
}

pres->Save(u"../out/TextoAviso_MarcadoresDePosición.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Establecer Transparencia de Imagen del Marcador de Posición**

Aspose.Slides te permite establecer la transparencia de la imagen de fondo en un marcador de posición de texto. Al ajustar la transparencia de la imagen en dicho marco, puedes hacer que el texto o la imagen resalten (dependiendo de los colores del texto y de la imagen).

Este código C++ te muestra cómo establecer la transparencia para un fondo de imagen (dentro de una forma):

```c++
auto presentation = System::MakeObject<Presentation>();
    
auto autoShape = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);
    
auto fillFormat = autoShape->get_FillFormat();
fillFormat->set_FillType(Aspose::Slides::FillType::Picture);
fillFormat->get_PictureFillFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(System::IO::File::ReadAllBytes(u"image.png")));

auto pictureFillFormat = fillFormat->get_PictureFillFormat();
pictureFillFormat->set_PictureFillMode(Aspose::Slides::PictureFillMode::Stretch);
pictureFillFormat->get_Picture()->get_ImageTransform()->AddAlphaModulateFixedEffect(75.0f);
```