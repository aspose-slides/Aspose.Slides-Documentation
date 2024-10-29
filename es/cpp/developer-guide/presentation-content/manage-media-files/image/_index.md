---
title: Imagen
type: docs
weight: 10
url: /es/cpp/image/
---


## **Imágenes en Diapositivas en Presentaciones**

Las imágenes hacen que las presentaciones sean más atractivas e interesantes. En Microsoft PowerPoint, puedes insertar imágenes de un archivo, de internet o de otros lugares en las diapositivas. De manera similar, Aspose.Slides te permite agregar imágenes a las diapositivas en tus presentaciones a través de diferentes procedimientos.

{{% alert title="Consejo" color="primary" %}} 

Aspose proporciona convertidores gratuitos—[JPEG a PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) y [PNG a PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—que permiten a las personas crear presentaciones rápidamente a partir de imágenes. 

{{% /alert %}} 

{{% alert title="Información" color="info" %}}

Si deseas agregar una imagen como un objeto de marco—especialmente si planeas usar opciones de formato estándar para cambiar su tamaño, agregar efectos, etc.—consulta [Marco de Imagen](/slides/es/cpp/picture-frame/). 

{{% /alert %}} 

{{% alert title="Nota" color="warning" %}}

Puedes manipular operaciones de entrada/salida que involucran imágenes y presentaciones de PowerPoint para convertir una imagen de un formato a otro. Consulta estas páginas: convertir [imagen a JPG](https://products.aspose.com/slides/cpp/conversion/image-to-jpg/); convertir [JPG a imagen](https://products.aspose.com/slides/cpp/conversion/jpg-to-image/); convertir [JPG a PNG](https://products.aspose.com/slides/cpp/conversion/jpg-to-png/), convertir [PNG a JPG](https://products.aspose.com/slides/cpp/conversion/png-to-jpg/); convertir [PNG a SVG](https://products.aspose.com/slides/cpp/conversion/png-to-svg/), convertir [SVG a PNG](https://products.aspose.com/slides/cpp/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides admite operaciones con imágenes en estos formatos populares: JPEG, PNG, GIF y otros. 

## **Agregando Imágenes Almacenadas Localmente a Diapositivas**

Puedes agregar una o varias imágenes en tu computadora a una diapositiva en una presentación. Este código de ejemplo en C++ te muestra cómo agregar una imagen a una diapositiva:

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"imagen.png"));
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```



## **Agregando Imágenes de la Web a Diapositivas**

Si la imagen que deseas agregar a una diapositiva no está disponible en tu computadora, puedes agregar la imagen directamente desde la web. 

Este código de ejemplo te muestra cómo agregar una imagen de la web a una diapositiva en C++:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
    
auto webClient = System::MakeObject<WebClient>();
auto imageData = webClient->DownloadData(System::MakeObject<Uri>(u"[REPLACE WITH URL]"));

auto image = pres->get_Images()->AddImage(imageData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Agregando Imágenes a Master de Diapositivas**

Un master de diapositivas es la diapositiva superior que almacena y controla información (tema, diseño, etc.) sobre todas las diapositivas debajo de ella. Entonces, cuando agregas una imagen a un master de diapositivas, esa imagen aparece en cada diapositiva bajo ese master de diapositivas. 

Este código de ejemplo en C++ te muestra cómo agregar una imagen a un master de diapositivas:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto masterSlide = slide->get_LayoutSlide()->get_MasterSlide();

auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"imagen.png"));
masterSlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Agregando Imágenes como Fondo de Diapositiva**

Puedes decidir usar una imagen como fondo para una diapositiva específica o varias diapositivas. En ese caso, debes consultar *[Configurando Imágenes como Fondos para Diapositivas](https://docs.aspose.com/slides/cpp/presentation-background/#setting-images-as-background-for-slides)*.

## **Insertando/Agregando SVG en Presentaciones**
Puedes agregar o insertar cualquier imagen en una presentación utilizando el método [AddPictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) que pertenece a la interfaz [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection).

Para crear un objeto de imagen basado en una imagen SVG, puedes hacerlo de esta manera:

1. Crear un objeto SvgImage para insertarlo en ImageShapeCollection
2. Crear un objeto PPImage a partir de ISvgImage
3. Crear un objeto PictureFrame utilizando la interfaz IPPImage

Este código de ejemplo te muestra cómo implementar los pasos anteriores para agregar una imagen SVG a una presentación:
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

// Crear un nuevo PictureFrame 
p->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 200.0f, 100.0f, static_cast<float>(ppImage->get_Width()), static_cast<float>(ppImage->get_Height()), ppImage);

// Guardar la presentación en formato PPTX
p->Save(outPptxPath, SaveFormat::Pptx);
```

## **Convirtiendo SVG a un Conjunto de Figuras**
La conversión de SVG a un conjunto de figuras de Aspose.Slides es similar a la funcionalidad de PowerPoint utilizada para trabajar con imágenes SVG:


![Menú Emergente de PowerPoint](img_01_01.png)

La funcionalidad es proporcionada por una de las sobrecargas del método [AddGroupShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection#a07def8851fe87a8f73a1621d2375d13b) de la interfaz [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection) que toma un objeto [ISvgImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_svg_image) como el primer argumento.

Este código de ejemplo te muestra cómo usar el método descrito para convertir un archivo SVG a un conjunto de figuras:

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

// Convertir la imagen SVG a un grupo de figuras escalándola al tamaño de la diapositiva
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// Guardar la presentación en formato PPTX
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **Agregando Imágenes como EMF en Diapositivas**
Aspose.Slides para C++ te permite generar imágenes EMF a partir de hojas de Excel y agregar las imágenes como EMF en diapositivas con Aspose.Cells. 

Este código de ejemplo te muestra cómo realizar la tarea descrita:

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

// Guardar el libro de trabajo en un stream
intrusive_ptr<Aspose::Cells::Rendering::ISheetRender> sr = Aspose::Cells::Factory::CreateISheetRender(sheet, options);

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

pres->get_Slides()->RemoveAt(0);

System::String EmfSheetName;
for (int32_t j = 0; j < sr->GetPageCount(); j++)
{
    EmfSheetName = dataDir + u"test" + System::String::FromWCS(sheet->GetName()->value()) + u" Página" + (j + 1) + u".out.emf";
    sr->ToImage(j, new String(EmfSheetName.ToWCS().c_str()));

    auto bytes = System::IO::File::ReadAllBytes(EmfSheetName);
    auto emfImage = pres->get_Images()->AddImage(bytes);

    System::SharedPtr<ISlide> slide = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->GetByType(SlideLayoutType::Blank));
    auto slideSize = pres->get_SlideSize()->get_Size();
    slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, slideSize.get_Width(), slideSize.get_Height(), emfImage);
}

pres->Save(dataDir + u"Saved.pptx", SaveFormat::Pptx);
```

{{% alert title="Información" color="info" %}}

Usando el convertidor gratuito de Aspose [Texto a GIF](https://products.aspose.app/slides/text-to-gif), puedes animar fácilmente textos, crear GIFs a partir de textos, etc. 

{{% /alert %}}