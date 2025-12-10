---
title: Administrar marcadores de posición en C++
linktitle: Administrar marcadores de posición
type: docs
weight: 10
url: /es/cpp/manage-placeholder/
keywords:
- marcador de posición
- marcador de posición de texto
- marcador de posición de imagen
- marcador de posición de gráfico
- texto de indicación
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Gestiona sin esfuerzo los marcadores de posición en Aspose.Slides para C++: reemplaza texto, personaliza indicaciones y establece la transparencia de imágenes en PowerPoint y OpenDocument."
---

## **Cambiar texto en un marcador de posición**
Usando [Aspose.Slides for C++](/slides/es/cpp/), puedes encontrar y modificar marcadores de posición en diapositivas de presentaciones. Aspose.Slides te permite realizar cambios en el texto de un marcador de posición.

**Requisito previo**: Necesitas una presentación que contenga un marcador de posición. Puedes crear dicha presentación en la aplicación estándar de Microsoft PowerPoint.

Así es como utilizas Aspose.Slides para reemplazar el texto en el marcador de posición de esa presentación:

1. Instancia la clase [`Presentation`](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) y pasa la presentación como argumento.
2. Obtén una referencia a la diapositiva mediante su índice.
3. Itera a través de las formas para encontrar el marcador de posición.
4. Convierte el tipo de la forma del marcador de posición a un [`AutoShape`](https://reference.aspose.com/slides/cpp/class/aspose.slides.auto_shape/) y cambia el texto usando el [`TextFrame`](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame/) asociado al [`AutoShape`](https://reference.aspose.com/slides/cpp/class/aspose.slides.auto_shape/).
5. Guarda la presentación modificada.

Este código C++ muestra cómo cambiar el texto en un marcador de posición:
```c++
// La ruta al directorio de documentos.
const String outPath = u"../out/ReplacingText_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// Carga la presentación deseada
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// Accede a la primera diapositiva
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Accede al primer y segundo marcador de posición en la diapositiva y lo convierte mediante casting a AutoShape
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);
SharedPtr<AutoShape> ashp = ExplicitCast<Aspose::Slides::AutoShape>(shape);

SharedPtr<ITextFrame> textframe = ashp->get_TextFrame();

textframe->set_Text(u"This is Placeholder");
	
// Guarda la presentación en disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Establecer texto de indicación en un marcador de posición**
Los diseños estándar y predefinidos contienen textos de indicación de marcador de posición como ***Click to add a title*** o ***Click to add a subtitle***. Usando Aspose.Slides, puedes insertar tus textos de indicación preferidos en los diseños de marcadores de posición.

Este código C++ te muestra cómo establecer el texto de indicación en un marcador de posición:
```c++
const System::String templatePath = u"../templates/Presentation2.pptx";
    
auto pres = System::MakeObject<Presentation>(templatePath);
auto slide = pres->get_Slides()->idx_get(0);

for (auto& shape : slide->get_Shapes())
{
    if (shape->get_Placeholder() != NULL)
    {
        System::String text = u"";
        if (shape->get_Placeholder()->get_Type() == PlaceholderType::CenteredTitle) // Cuando no hay texto, PowerPoint muestra "Click to add title". 
        {
            text = u"Click to add title";
        }
        else if (shape->get_Placeholder()->get_Type() == PlaceholderType::Subtitle) // Hace lo mismo para el subtítulo.
        {
            text = u"Click to add subtitle";
        }
        System::Console::WriteLine(u"Placeholder : {0}", text);
    }
}

pres->Save(u"../out/Placeholders_PromptText.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Establecer transparencia de imagen de marcador de posición**
Aspose.Slides permite establecer la transparencia de la imagen de fondo en un marcador de posición de texto. Al ajustar la transparencia de la imagen en dicho marco, puedes hacer que el texto o la imagen resalten (según los colores del texto y la imagen).

Este código C++ muestra cómo establecer la transparencia para el fondo de una imagen (dentro de una forma):
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


## **Preguntas frecuentes**

**¿Qué es un marcador de posición base y en qué se diferencia de una forma local en una diapositiva?**

Un marcador de posición base es la forma original en un diseño o patrón del que hereda la forma de la diapositiva: tipo, posición y parte del formato provienen de él. Una forma local es independiente; si no hay un marcador de posición base, la herencia no se aplica.

**¿Cómo puedo actualizar todos los títulos o subtítulos en una presentación sin iterar sobre cada diapositiva?**

Edita el marcador de posición correspondiente en el diseño o en el patrón. Las diapositivas basadas en esos diseños/patrón heredarán automáticamente el cambio.

**¿Cómo controlo los marcadores de posición estándar de encabezado/pie de página—fecha y hora, número de diapositiva y texto del pie de página?**

Utiliza los administradores HeaderFooter en el ámbito apropiado (diapositivas normales, diseños, patrón, notas/folletos) para activar o desactivar esos marcadores de posición y establecer su contenido.