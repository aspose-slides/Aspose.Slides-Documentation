---
title: Convertir Diapositiva
type: docs
weight: 41
url: /cpp/convert-slide/
keywords: 
- convertir diapositiva a imagen
- exportar diapositiva como imagen
- guardar diapositiva como imagen
- diapositiva a imagen
- diapositiva a PNG
- diapositiva a JPEG
- diapositiva a bitmap
- C++
- Aspose.Slides para C++
description: "Convertir diapositiva de PowerPoint a imagen (Bitmap, PNG o JPG) en C++"
---

Aspose.Slides para C++ te permite convertir diapositivas (en presentaciones) a imágenes. Estos son los formatos de imagen admitidos: BMP, PNG, JPG (JPEG), GIF, y otros.

Para convertir una diapositiva a una imagen, haz lo siguiente:

1. Primero, establece los parámetros de conversión y los objetos de la diapositiva a convertir usando:
   * la interfaz [ITiffOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_tiff_options) o
   * la interfaz [IRenderingOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_rendering_options).

2. Segundo, convierte la diapositiva a una imagen utilizando el método [GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/).

## **Acerca del Bitmap y Otros Formatos de Imagen**

Un [Bitmap](https://reference.aspose.com/slides/cpp/class/system.drawing.bitmap) es un objeto que te permite trabajar con imágenes definidas por datos de píxeles. Puedes usar una instancia de esta clase para guardar imágenes en una amplia gama de formatos (BMP, JPG, PNG, etc.).

{{% alert title="Info" color="info" %}}

Aspose desarrolló recientemente un convertidor en línea [Texto a GIF](https://products.aspose.app/slides/text-to-gif).

{{% /alert %}}

## **Convirtiendo Diapositivas a Bitmap y Guardando las Imágenes en PNG**

Este código C++ te muestra cómo convertir la primera diapositiva de una presentación a un objeto bitmap y luego cómo guardar la imagen en formato PNG:

``` cpp
auto pres = System::MakeObject<Presentation>(u"Presentation.pptx");

// Convierte la primera diapositiva de la presentación a un objeto Bitmap
System::SharedPtr<IImage> image = pres->get_Slide(0)->GetImage();
                 
// Guarda la imagen en formato PNG
image->Save(u"Slide_0.png", ImageFormat::Png);
```

{{% alert title="Consejo" color="primary" %}}

Puedes convertir una diapositiva a un objeto bitmap y luego usar el objeto directamente en algún lugar. O puedes convertir una diapositiva a un bitmap y luego guardar la imagen en JPEG o en cualquier otro formato que prefieras.

{{% /alert %}}  

## **Convirtiendo Diapositivas a Imágenes con Tamaños Personalizados**

Puede que necesites obtener una imagen de un tamaño específico. Usando una sobrecarga del método [GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/), puedes convertir una diapositiva a una imagen con dimensiones específicas (largo y ancho).

Este código de muestra demuestra la conversión propuesta utilizando el método [GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) en C++:

``` cpp
auto pres = System::MakeObject<Presentation>(u"Presentation.pptx");
// Convierte la primera diapositiva en la presentación a un Bitmap con el tamaño especificado
auto image = pres->get_Slide(0)->GetImage(Size(1820, 1040));
// Guarda la imagen en formato JPEG
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);
```

## **Convirtiendo Diapositivas Con Notas y Comentarios a Imágenes**

Algunas diapositivas contienen notas y comentarios.

Aspose.Slides proporciona dos interfaces—[ITiffOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_tiff_options) y [IRenderingOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_rendering_options)—que te permiten controlar el renderizado de las diapositivas de la presentación a imágenes. Ambas interfaces albergan la interfaz [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_notes_comments_layouting_options) que te permite agregar notas y comentarios en una diapositiva cuando estás convirtiendo esa diapositiva a una imagen.

{{% alert title="Info" color="info" %}}

Con la interfaz [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_notes_comments_layouting_options), puedes especificar tu posición preferida para las notas y comentarios en la imagen resultante.

{{% /alert %}} 

Este código C++ demuestra el proceso de conversión para una diapositiva con notas y comentarios:

``` cpp
auto pres = System::MakeObject<Presentation>(u"PresentationNotesComments.pptx");
// Crea las opciones de renderizado
auto options = System::MakeObject<RenderingOptions>();
auto notesCommentsLayouting = options->get_NotesCommentsLayouting();
// Establece la posición de las notas en la página
notesCommentsLayouting->set_NotesPosition(NotesPositions::BottomTruncated);
// Establece la posición de los comentarios en la página 
notesCommentsLayouting->set_CommentsPosition(CommentsPositions::Right);
// Establece el ancho del área de salida de comentarios
notesCommentsLayouting->set_CommentsAreaWidth(500);
// Establece el color para el área de comentarios
notesCommentsLayouting->set_CommentsAreaColor(Color::get_AntiqueWhite());

// Convierte la primera diapositiva de la presentación a un objeto Bitmap
auto image = pres->get_Slide(0)->GetImage(options, 2.f, 2.f);

// Guarda la imagen en formato GIF
image->Save(u"Slide_Notes_Comments_0.gif", ImageFormat::Gif);
```

{{% alert title="Nota" color="warning" %}}

En cualquier proceso de conversión de diapositivas a imagen, no puedes pasar el valor BottomFull (para especificar la posición para notas) al método [set_NotesPositions()](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_notes_comments_layouting_options) porque el texto de una nota puede ser grande, lo que significa que puede no caber en el tamaño de imagen especificado.

{{% /alert %}} 

## **Convirtiendo Diapositivas a Imágenes Usando ITiffOptions**

La interfaz [ITiffOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_tiff_options) te ofrece más control (en términos de parámetros) sobre la imagen resultante. Usando esta interfaz, puedes especificar el tamaño, la resolución, la paleta de colores y otros parámetros para la imagen resultante.

Este código C++ demuestra un proceso de conversión donde se usa ITiffOptions para generar una imagen en blanco y negro con una resolución de 300dpi y tamaño 2160 × 2800:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"PresentationNotesComments.pptx");

// Obtiene una diapositiva por su índice
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Crea un objeto TiffOptions
System::SharedPtr<TiffOptions> options = System::MakeObject<TiffOptions>();
options->set_ImageSize(Size(2160, 2880));

// Establece la fuente utilizada en caso de que no se encuentre la fuente de origen
options->set_DefaultRegularFont(u"Arial Black");

// Establece la posición de las notas en la página 
options->get_NotesCommentsLayouting()->set_NotesPosition(NotesPositions::BottomTruncated);

// Establece el formato de píxel (blanco y negro)
options->set_PixelFormat(ImagePixelFormat::Format1bppIndexed);

// Establece la resolución
options->set_DpiX(300);
options->set_DpiY(300);

// Convierte la diapositiva a un objeto Bitmap
System::SharedPtr<Bitmap> image = slide->GetImage(options);

// Guarda la imagen en formato BMP
image->Save(u"PresentationNotesComments.bmp", ImageFormat::Tiff);
```

## **Convirtiendo Todas las Diapositivas a Imágenes**

Aspose.Slides te permite convertir todas las diapositivas de una única presentación a imágenes. Esencialmente, puedes convertir la presentación (en su totalidad) a imágenes.

Este código de muestra te muestra cómo convertir todas las diapositivas en una presentación a imágenes en C++:

``` cpp
// Ruta al directorio de salida
System::String outputDir = u"D:\\PresentationImages";

auto pres = System::MakeObject<Presentation>(u"Presentation.pptx");

// Renderiza la presentación en un array de imágenes diapositiva por diapositiva
for (int32_t i = 0; i < pres->get_Slides()->get_Count(); i++)
{
    // Controla las diapositivas ocultas (no renderiza las diapositivas ocultas)
    if (pres->get_Slide(i)->get_Hidden())
    {
        continue;
    }

    // Convierte la diapositiva a un objeto Bitmap
    auto image = pres->get_Slide(i)->GetImage(2.f, 2.f);

    // Crea un nombre de archivo para una imagen
    auto outputFilePath = Path::Combine(outputDir, String(u"Slide_") + i + u".jpg");

    // Guarda la imagen en formato PNG
    image->Save(outputFilePath, ImageFormat::Png);
}
```