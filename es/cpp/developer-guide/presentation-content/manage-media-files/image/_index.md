---
title: Optimizar la gestión de imágenes en presentaciones usando C++
linktitle: Administrar imágenes
type: docs
weight: 10
url: /es/cpp/image/
keywords:
- agregar imagen
- agregar foto
- agregar mapa de bits
- reemplazar imagen
- reemplazar foto
- desde la web
- fondo
- agregar PNG
- agregar JPG
- agregar SVG
- agregar EMF
- agregar WMF
- agregar TIFF
- PowerPoint
- OpenDocument
- presentación
- EMF
- SVG
- C++
- Aspose.Slides
description: "Optimiza la gestión de imágenes en PowerPoint y OpenDocument con Aspose.Slides para C++, mejorando el rendimiento y automatizando tu flujo de trabajo."
---

## **Imágenes en diapositivas de presentación**

Las imágenes hacen que las presentaciones sean más atractivas e interesantes. En Microsoft PowerPoint, puedes insertar imágenes desde un archivo, Internet u otras ubicaciones en las diapositivas. De manera similar, Aspose.Slides te permite agregar imágenes a las diapositivas de tus presentaciones mediante diferentes procedimientos.

{{% alert title="Tip" color="primary" %}} 
Aspose ofrece conversores gratuitos—[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) y [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—que permiten crear presentaciones rápidamente a partir de imágenes. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
Si deseas agregar una imagen como un objeto de marco—especialmente si planeas usar opciones de formato estándar para cambiar su tamaño, agregar efectos, etc.—consulta [Picture Frame](/slides/es/cpp/picture-frame/). 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
Puedes manipular operaciones de entrada/salida que involucren imágenes y presentaciones de PowerPoint para convertir una imagen de un formato a otro. Consulta estas páginas: convertir [image to JPG](https://products.aspose.com/slides/cpp/conversion/image-to-jpg/); convertir [JPG to image](https://products.aspose.com/slides/cpp/conversion/jpg-to-image/); convertir [JPG to PNG](https://products.aspose.com/slides/cpp/conversion/jpg-to-png/), convertir [PNG to JPG](https://products.aspose.com/slides/cpp/conversion/png-to-jpg/); convertir [PNG to SVG](https://products.aspose.com/slides/cpp/conversion/png-to-svg/), convertir [SVG to PNG](https://products.aspose.com/slides/cpp/conversion/svg-to-png/). 
{{% /alert %}}

Aspose.Slides admite operaciones con imágenes en estos formatos populares: JPEG, PNG, GIF y otros.

## **Agregar imágenes almacenadas localmente a diapositivas**

Puedes agregar una o varias imágenes de tu computadora a una diapositiva en una presentación. Este código de ejemplo en C++ muestra cómo agregar una imagen a una diapositiva:
``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```


## **Agregar imágenes de la web a diapositivas**

Si la imagen que deseas agregar a una diapositiva no está disponible en tu computadora, puedes insertarla directamente desde la web.

Este código de ejemplo muestra cómo agregar una imagen desde la web a una diapositiva en C++:
``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
    
auto webClient = System::MakeObject<WebClient>();
auto imageData = webClient->DownloadData(System::MakeObject<Uri>(u"[REPLACE WITH URL]"));

auto image = pres->get_Images()->AddImage(imageData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```


## **Agregar imágenes a los maestros de diapositivas**

Un maestro de diapositivas es la diapositiva superior que almacena y controla información (tema, diseño, etc.) de todas las diapositivas bajo él. Por lo tanto, cuando agregas una imagen a un maestro de diapositivas, esa imagen aparece en todas las diapositivas bajo ese maestro. 

Este código de ejemplo en C++ muestra cómo agregar una imagen a un maestro de diapositivas:
``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto masterSlide = slide->get_LayoutSlide()->get_MasterSlide();

auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
masterSlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```


## **Agregar imágenes como fondos de diapositivas**

Puedes decidir usar una foto como fondo para una diapositiva específica o para varias diapositivas. En ese caso, debes consultar *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/cpp/presentation-background/#setting-images-as-background-for-slides)*.

## **Agregar SVG a presentaciones**
Puedes agregar o insertar cualquier imagen en una presentación usando el método [AddPictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) que pertenece a la interfaz [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection).

Para crear un objeto de imagen basado en una imagen SVG, puedes hacerlo de la siguiente manera:

1. Crear un objeto SvgImage para insertarlo en ImageShapeCollection
2. Crear un objeto PPImage a partir de ISvgImage
3. Crear un objeto PictureFrame usando la interfaz IPPImage

Este código de ejemplo muestra cómo implementar los pasos anteriores para agregar una imagen SVG a una presentación:
``` cpp 
// La ruta al directorio de documentos
System::String dataDir = u"D:\\Documents\\";

// Nombre del archivo SVG de origen
System::String svgFileName = dataDir + u"sample.svg";

// Nombre del archivo de presentación de salida
System::String outPptxPath = dataDir + u"presentation.pptx";

// Crear nueva presentación
auto p = System::MakeObject<Presentation>();

// Leer el contenido del archivo SVG
System::String svgContent = File::ReadAllText(svgFileName);

// Crear objeto SvgImage
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// Crear objeto PPImage
System::SharedPtr<IPPImage> ppImage = p->get_Images()->AddImage(svgImage);

// Crea un nuevo PictureFrame 
p->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 200.0f, 100.0f, static_cast<float>(ppImage->get_Width()), static_cast<float>(ppImage->get_Height()), ppImage);

// Guardar la presentación en formato PPTX
p->Save(outPptxPath, SaveFormat::Pptx);
```


## **Convertir SVG a un conjunto de formas**
La conversión de SVG a un conjunto de formas en Aspose.Slides es similar a la funcionalidad de PowerPoint usada para trabajar con imágenes SVG:

![PowerPoint Popup Menu](img_01_01.png)

La funcionalidad se ofrece mediante una de las sobrecargas del método [AddGroupShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection#a07def8851fe87a8f73a1621d2375d13b) de la interfaz [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection) que acepta un objeto [ISvgImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_svg_image) como primer argumento.

Este código de ejemplo muestra cómo usar el método descrito para convertir un archivo SVG en un conjunto de formas:
``` cpp 
// La ruta al directorio de documentos
System::String dataDir = u"D:\\Documents\\";

// Nombre del archivo SVG de origen
System::String svgFileName = dataDir + u"sample.svg";

// Nombre del archivo de presentación de salida
System::String outPptxPath = dataDir + u"presentation.pptx";

// Crear nueva presentación
System::SharedPtr<IPresentation> presentation = System::MakeObject<Presentation>();

// Leer el contenido del archivo SVG
System::String svgContent = File::ReadAllText(svgFileName);

// Crear objeto SvgImage
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// Obtener tamaño de la diapositiva
System::Drawing::SizeF slideSize = presentation->get_SlideSize()->get_Size();

// Convertir la imagen SVG a un grupo de formas escalándola al tamaño de la diapositiva
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// Guardar la presentación en formato PPTX
presentation->Save(outPptxPath, SaveFormat::Pptx);
```


## **Agregar imágenes como EMF a diapositivas**
Aspose.Slides para C++ permite generar imágenes EMF a partir de hojas de Excel y agregar esas imágenes como EMF en diapositivas con Aspose.Cells.

Este código de ejemplo muestra cómo realizar la tarea descrita:
``` cpp 
System::String dataDir = u"D:\\Documents\\";

StringPtr cellsXls = new String(dataDir.ToWCS().c_str());
cellsXls->Append(L"chart.xls");
intrusive_ptr<Aspose::Cells::IWorkbook> book = Aspose::Cells::Factory::CreateIWorkbook(cellsXls);

intrusive_ptr<Aspose::Cells::IWorksheet> sheet = book->GetIWorksheets()->GetObjectByIndex(0);
intrusive_ptr<Aspose::Cells::Rendering::IImageOrPrintOptions> options = Aspose::Cells::Factory::CreateIImageOrPrintOptions();
options->SetHorizontalResolution(200);
options->SetVerticalResolution(200);
options->SetImageFormat(Aspose::Cells::Systems::Drawing::Imaging::ImageFormat::GetEmf());

// Save the workbook to stream
intrusive_ptr<Aspose::Cells::Rendering::ISheetRender> sr = Aspose::Cells::Factory::CreateISheetRender(sheet, options);

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

pres->get_Slides()->RemoveAt(0);

System::String EmfSheetName;
for (int32_t j = 0; j < sr->GetPageCount(); j++)
{
    EmfSheetName = dataDir + u"test" + System::String::FromWCS(sheet->GetName()->value()) + u" Page" + (j + 1) + u".out.emf";
    sr->ToImage(j, new String(EmfSheetName.ToWCS().c_str()));

    auto bytes = System::IO::File::ReadAllBytes(EmfSheetName);
    auto emfImage = pres->get_Images()->AddImage(bytes);

    System::SharedPtr<ISlide> slide = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->GetByType(SlideLayoutType::Blank));
    auto slideSize = pres->get_SlideSize()->get_Size();
    slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, slideSize.get_Width(), slideSize.get_Height(), emfImage);
}

pres->Save(dataDir + u"Saved.pptx", SaveFormat::Pptx);
```


## **Reemplazar imágenes en la colección de imágenes**

Aspose.Slides permite reemplazar imágenes almacenadas en la colección de imágenes de una presentación (incluidas las usadas por formas de diapositivas). Esta sección muestra varios enfoques para actualizar imágenes en la colección. La API proporciona métodos sencillos para reemplazar una imagen usando datos binarios crudos, una instancia de [IImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/), o otra imagen que ya exista en la colección.

Sigue los pasos a continuación:

1. Cargar el archivo de presentación que contiene imágenes usando la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Cargar una nueva imagen desde un archivo a un arreglo de bytes.
1. Reemplazar la imagen objetivo con la nueva imagen usando el arreglo de bytes.
1. En el segundo enfoque, cargar la imagen en un objeto [IImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/) y reemplazar la imagen objetivo con ese objeto.
1. En el tercer enfoque, reemplazar la imagen objetivo con una imagen que ya exista en la colección de imágenes de la presentación.
1. Guardar la presentación modificada como un archivo PPTX.
```cpp
// Instanciar la clase Presentation que representa un archivo de presentación.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// La primera forma.
auto imageData = File::ReadAllBytes(u"image0.jpeg");
auto oldImage = presentation->get_Image(0);
oldImage->ReplaceImage(imageData);

// La segunda forma.
auto newImage = Images::FromFile(u"image1.png");
oldImage = presentation->get_Image(1);
oldImage->ReplaceImage(newImage);
newImage->Dispose();

// La tercera forma.
oldImage = presentation->get_Image(2);
oldImage->ReplaceImage(presentation->get_Image(3));

// Guardar la presentación en un archivo.
presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


{{% alert title="Info" color="info" %}}
Usando el conversor GRATUITO de Aspose [Text to GIF](https://products.aspose.app/slides/text-to-gif), puedes animar textos fácilmente, crear GIFs a partir de textos, etc. 
{{% /alert %}}

## **FAQ**

**¿Se mantiene la resolución original de la imagen después de insertarla?**

Sí. Los píxeles originales se conservan, pero la apariencia final depende de cómo se escale la [picture](/slides/es/cpp/picture-frame/) en la diapositiva y de cualquier compresión aplicada al guardar.

**¿Cuál es la mejor manera de reemplazar el mismo logotipo en docenas de diapositivas a la vez?**

Coloca el logotipo en la diapositiva maestra o en un diseño y reemplázalo en la colección de imágenes de la presentación; las actualizaciones se propagarán a todos los elementos que usan ese recurso.

**¿Puede un SVG insertado convertirse en formas editables?**

Sí. Puedes convertir un SVG en un grupo de formas, después de lo cual las partes individuales se vuelven editables con las propiedades estándar de forma.

**¿Cómo puedo establecer una imagen como fondo para varias diapositivas a la vez?**

[Assign the image as the background](/slides/es/cpp/presentation-background/) en la diapositiva maestra o en el diseño correspondiente; cualquier diapositiva que use ese maestro/diseño heredará el fondo.

**¿Cómo evito que la presentación "infle" de tamaño por muchas imágenes?**

Reutiliza un solo recurso de imagen en lugar de duplicados, elige resoluciones razonables, aplica compresión al guardar y mantén los gráficos repetidos en la maestra cuando sea apropiado.