---
title: Administrar OLE
type: docs
weight: 40
url: /es/cpp/manage-ole/
keywords:
- agregar OLE
- incrustar OLE
- agregar un objeto
- incrustar un objeto
- incrustar un archivo
- objeto vinculado
- Vínculo y Embebido de Objetos
- objeto OLE
- PowerPoint 
- presentación
- C++
- Aspose.Slides para C++
description: Agregar objetos OLE a presentaciones de PowerPoint en C++
---

{{% alert title="Info" color="info" %}}

OLE (Vínculo y Embebido de Objetos) es una tecnología de Microsoft que permite que los datos y objetos creados en una aplicación se coloquen en otra aplicación a través de vínculos o incrustaciones.

{{% /alert %}} 

Considera un gráfico creado en MS Excel. El gráfico se coloca dentro de una diapositiva de PowerPoint. Ese gráfico de Excel se considera un objeto OLE.

- Un objeto OLE puede aparecer como un icono. En este caso, cuando haces doble clic en el icono, el gráfico se abre en su aplicación asociada (Excel), o se te pide que selecciones una aplicación para abrir o editar el objeto.
- Un objeto OLE puede mostrar contenidos reales, por ejemplo, los contenidos de un gráfico. En este caso, el gráfico se activa en PowerPoint, se carga la interfaz del gráfico y puedes modificar los datos del gráfico dentro de la aplicación de PowerPoint.

[Aspose.Slides para C++](https://products.aspose.com/slides/cpp/) te permite insertar objetos OLE en diapositivas como Marcos de Objetos OLE ([OleObjectFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame)).

## **Agregar Marcos de Objetos OLE a Diapositivas**

Suponiendo que ya has creado un gráfico en Microsoft Excel y deseas incrustar ese gráfico en una diapositiva como un Marco de Objeto OLE utilizando Aspose.Slides para C++, puedes hacerlo de la siguiente manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtén la referencia de la diapositiva a través de su índice.
3. Abre el archivo de Excel que contiene el objeto gráfico de Excel y guárdalo en `MemoryStream`.
4. Agrega el [OleObjectFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame) a la diapositiva que contenga el array de bytes y otra información sobre el objeto OLE.
5. Escribe la presentación modificada como un archivo PPTX.

En el siguiente ejemplo, agregamos un gráfico de un archivo de Excel a una diapositiva como un [OleObjectFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame) utilizando Aspose.Slides para C++.  
**Nota** que el constructor de [IOleEmbeddedDataInfo](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_ole_embedded_data_info) toma una extensión de objeto embebible como segundo parámetro. Esta extensión permite que PowerPoint interprete correctamente el tipo de archivo y elija la aplicación correcta para abrir este objeto OLE.

``` cpp
// La ruta al directorio de documentos.
String dataDir = u"";
// Instancia la clase Presentation que representa el PPTX
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Accede a la primera diapositiva
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);
// Carga un archivo de Excel en un stream
SharedPtr<MemoryStream> mstream = System::MakeObject<MemoryStream>();

SharedPtr<FileStream> fs = System::MakeObject<FileStream>(dataDir + u"book1.xlsx", FileMode::Open, FileAccess::Read);

ArrayPtr<uint8_t> buf = System::MakeArray<uint8_t>(4096, 0);
while (true)
{
    int32_t bytesRead = fs->Read(buf, 0, buf->get_Length());
    if (bytesRead <= 0)
    {
        break;
    }
    mstream->Write(buf, 0, bytesRead);
}

// Crea un objeto de datos para incrustar
SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(mstream->ToArray(), u"xlsx");
// Agrega un marco de objeto Ole
SharedPtr<IOleObjectFrame> oleObjectFrame = sld->get_Shapes()->AddOleObjectFrame(0.0f, 0.0f, pres->get_SlideSize()->get_Size().get_Width(), pres->get_SlideSize()->get_Size().get_Height(), dataInfo);
// Escribe el archivo PPTX en disco
pres->Save(dataDir + u"OleEmbed_out.pptx", SaveFormat::Pptx);
```

## **Accediendo a Marcos de Objetos OLE**
Si un objeto OLE ya está incrustado en una diapositiva, puedes encontrar o acceder a ese objeto fácilmente de esta manera:

1. Crea una instancia de la [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) clase.

2. Obtén la referencia de la diapositiva utilizando su índice.

3. Accede al objeto [OleObjectFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame).

   En nuestro ejemplo, utilizamos el PPTX creado previamente que tiene solo una forma en la primera diapositiva. Luego *convertimos* ese objeto como un [OleObjectFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame). Este fue el Marco de Objeto OLE deseado que se debía acceder.

4. Una vez que se accede al Marco de Objeto OLE, puedes realizar cualquier operación en él.

En el ejemplo a continuación, se accede a un Marco de Objeto OLE (un objeto gráfico de Excel incrustado en una diapositiva) y luego se escribe su dato de archivo en un archivo de Excel:

``` cpp
// La ruta al directorio de documentos.
const String templatePath = u"../templates/AccessingOLEObjectFrame.pptx";

// Carga la presentación deseada
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// Accede a la primera diapositiva
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Convierte la forma a OleObjectFrame
SharedPtr<OleObjectFrame> oleObjectFrame = System::AsCast<OleObjectFrame>(sld->get_Shapes()->idx_get(0));

// Lee el objeto OLE y lo escribe en disco
if (oleObjectFrame != nullptr)
{
    // Obtiene los datos del archivo incrustado
    ArrayPtr<uint8_t> data = oleObjectFrame->get_EmbeddedFileData();

    // Obtiene la extensión del archivo incrustado
    String fileExtention = oleObjectFrame->get_EmbeddedFileExtension();

    // Crea la ruta para guardar el archivo extraído
    String extractedPath = Path::Combine(GetOutPath(), u"excelFromOLE_out" + fileExtention);

    // Guarda los datos extraídos
    SharedPtr<FileStream> fstr = System::MakeObject<FileStream>(extractedPath, FileMode::Create, FileAccess::Write);
    fstr->Write(data, 0, data->get_Length());
}
```

## **Cambiando los Datos del Objeto OLE**
Si un objeto OLE ya está incrustado en una diapositiva, puedes acceder fácilmente a ese objeto y modificar sus datos de esta manera:

1. Abre la presentación deseada con el Objeto OLE incrustado creando una instancia de la [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) clase.

2. Obtén la referencia de la diapositiva a través de su índice.

3. Accede a la forma [OLEObjectFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame).

   En nuestro ejemplo, utilizamos el PPTX creado anteriormente que tiene una forma en la primera diapositiva. Luego *convertimos* ese objeto como un [OLEObjectFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame). Este fue el Marco de Objeto OLE deseado que se debía acceder.

4. Una vez que se accede al Marco de Objeto OLE, puedes realizar cualquier operación en él.

5. Crea el objeto Workbook y accede a los datos OLE.

6. Accede a la Hoja de Cálculo deseada y modifica los datos.

7. Guarda el Workbook actualizado en streams.

8. Cambia los datos del objeto OLE a partir de los datos de stream.

En el siguiente ejemplo, se accede a un Marco de Objeto OLE (un gráfico de Excel incrustado en una diapositiva) y luego se modifica su dato de archivo para cambiar los datos del gráfico:

``` cpp
intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> ToCellsMemoryStream(System::ArrayPtr<uint8_t> buffer)
{
    intrusive_ptr<BString> array = new BString(buffer->data_ptr(), buffer->Count());
    auto stream = new Aspose::Cells::Systems::IO::MemoryStream(array);

    return stream;
}

System::SharedPtr<System::IO::MemoryStream> ToSlidesMemoryStream(intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> inputStream)
{
    System::ArrayPtr<uint8_t> outputBuffer = System::MakeArray<uint8_t>(inputStream->GetLength(), inputStream->GetBuffer()->ArrayPoint());
    auto outputStream = System::MakeObject<System::IO::MemoryStream>(outputBuffer);

    return outputStream;
}

void ChangeOLEObjectData()
{
    System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(GetDataPath() + u"ChangeOLEObjectData.pptx");
    System::SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

    System::SharedPtr<OleObjectFrame> ole;

    // Recorre todas las formas en busca del marco Ole
    for (auto shape : IterateOver(slide->get_Shapes()))
    {
        if (System::ObjectExt::Is<OleObjectFrame>(shape))
        {
            ole = System::ExplicitCast<OleObjectFrame>(shape);
        }
    }
    
    if (ole != nullptr)
    {
        // Lee los datos del objeto en el Workbook
        intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> cellsInputStream = ToCellsMemoryStream(ole->get_ObjectData());
        intrusive_ptr<Aspose::Cells::IWorkbook> Wb = Aspose::Cells::Factory::CreateIWorkbook(cellsInputStream);

        // Modifica los datos del workbook
        Wb->GetIWorksheets()->GetObjectByIndex(0)->GetICells()->GetObjectByIndex(0,4)->PutValue(u"E");
        Wb->GetIWorksheets()->GetObjectByIndex(0)->GetICells()->GetObjectByIndex(1, 4)->PutValue(12);
        Wb->GetIWorksheets()->GetObjectByIndex(0)->GetICells()->GetObjectByIndex(2, 4)->PutValue(14);
        Wb->GetIWorksheets()->GetObjectByIndex(0)->GetICells()->GetObjectByIndex(3, 4)->PutValue(15);

        intrusive_ptr<MemoryStream> cellsOutputStream = new Aspose::Cells::Systems::IO::MemoryStream();
        Wb->Save(cellsOutputStream, Aspose::Cells::SaveFormat_Xlsx);
        
        // Cambia los datos del objeto del marco Ole
        cellsOutputStream->SetPosition(0);
        System::SharedPtr<System::IO::MemoryStream> msout = ToSlidesMemoryStream(cellsOutputStream);
        ole->set_ObjectData(msout->ToArray());
        
        pres->Save(GetOutPath() + u"OleEdit_out.pptx", Export::SaveFormat::Pptx);
    }
}
```

## Incrustando Otros Tipos de Archivos en Diapositivas

Además de gráficos de Excel, Aspose.Slides para C++ permite incrustar otros tipos de archivos en diapositivas. Por ejemplo, puedes insertar archivos HTML, PDF y ZIP como objetos en una diapositiva. Cuando un usuario hace doble clic en el objeto insertado, el objeto se lanza automáticamente en el programa relevante, o se le redirige al usuario para seleccionar un programa apropiado para abrir el objeto. 

Este código C++ te muestra cómo incrustar HTML y ZIP en una diapositiva:

``` cpp

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;
    
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);

auto htmlBytes = System::IO::File::ReadAllBytes(u"embedOle.html");

auto dataInfoHtml = System::MakeObject<OleEmbeddedDataInfo>(htmlBytes, u"html");
auto oleFrameHtml = slide->get_Shapes()->AddOleObjectFrame(150.0f, 120.0f, 50.0f, 50.0f, dataInfoHtml);
oleFrameHtml->set_IsObjectIcon(true);
        
auto zipBytes = System::IO::File::ReadAllBytes(u"embedOle.zip");
auto dataInfoZip = System::MakeObject<OleEmbeddedDataInfo>(zipBytes, u"zip");
auto oleFrameZip = slide->get_Shapes()->AddOleObjectFrame(150.0f, 220.0f, 50.0f, 50.0f, dataInfoZip);
oleFrameZip->set_IsObjectIcon(true);
        
pres->Save(u"embeddedOle.pptx", SaveFormat::Pptx);

```

## Estableciendo Tipos de Archivos para Objetos Incrustados

Al trabajar en presentaciones, puede que necesites reemplazar objetos OLE antiguos por nuevos. O puede que necesites reemplazar un objeto OLE no compatible por uno compatible.

Aspose.Slides para C++ te permite establecer el tipo de archivo para un objeto incrustado. De esta manera, puedes cambiar los datos del marco OLE o su extensión.

Este código C++ te muestra cómo establecer el tipo de archivo para un objeto OLE incrustado:

``` cpp
auto pres = System::MakeObject<Presentation>(u"embeddedOle.pptx");
auto slide = pres->get_Slides()->idx_get(0);
auto oleObjectFrame = System::ExplicitCast<IOleObjectFrame>(slide->get_Shapes()->idx_get(0));
Console::WriteLine(u"La extensión de datos incrustados actuales es: {0}", oleObjectFrame->get_EmbeddedData()->get_EmbeddedFileExtension());

oleObjectFrame->SetEmbeddedData(System::MakeObject<OleEmbeddedDataInfo>(File::ReadAllBytes(u"embedOle.zip"), u"zip"));

pres->Save(u"embeddedChanged.pptx", SaveFormat::Pptx);
```

## Estableciendo Imágenes e Títulos de Icono para Objetos Incrustados

Después de incrustar un objeto OLE, se agrega automáticamente una vista previa que consiste en una imagen de icono y un título. La vista previa es lo que los usuarios ven antes de acceder o abrir el objeto OLE.

Si deseas utilizar una imagen específica y texto como elementos en la vista previa, puedes establecer la imagen de icono y el título utilizando Aspose.Slides para C++.

Este código C++ te muestra cómo establecer la imagen de icono y el título para un objeto incrustado:

``` cpp
auto pres = System::MakeObject<Presentation>(u"embeddedOle.pptx");
auto slide = pres->get_Slide(0);
auto oleObjectFrame = System::ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

auto oleImage = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
oleObjectFrame->set_SubstitutePictureTitle(u"Mi título");
oleObjectFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleObjectFrame->set_IsObjectIcon(false);

pres->Save(u"embeddedOle-newImage.pptx", SaveFormat::Pptx);
```

## **Prevenir que un Marco de Objeto OLE sea Redimensionado y Reposicionado**

Después de agregar un objeto OLE vinculado a una diapositiva de presentación, cuando abres la presentación en PowerPoint, es posible que veas un mensaje pidiéndote que actualices los vínculos. Hacer clic en el botón "Actualizar Vínculos" puede cambiar el tamaño y la posición del marco del objeto OLE porque PowerPoint actualiza los datos del objeto OLE vinculado y refresca la vista previa del objeto. Para evitar que PowerPoint te pida actualizar los datos del objeto, establece el método `set_UpdateAutomatic` de la interfaz [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/) en `false`:

```cpp
oleObjectFrame->set_UpdateAutomatic(false);
```

## Extrayendo Archivos Incrustados

Aspose.Slides para C++ te permite extraer los archivos incrustados en las diapositivas como objetos OLE de la siguiente manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) que contenga el objeto OLE que deseas extraer.
2. Recorre todas las formas en la presentación y accede a la forma [OLEObjectFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame).
3. Accede a los datos del archivo incrustado desde el Marco de Objeto OLE y escríbelo en disco.

Este código C++ te muestra cómo extraer un archivo incrustado en una diapositiva como un objeto OLE:

``` cpp
auto pres = System::MakeObject<Presentation>(u"embeddedOle.pptx");
auto slide = pres->get_Slides()->idx_get(0);

for (int32_t index = 0; index < slide->get_Shapes()->get_Count(); index++)
{
    auto shape = slide->get_Shapes()->idx_get(index);

    auto oleFrame = System::AsCast<IOleObjectFrame>(shape);

    if (oleFrame != nullptr)
    {
        auto data = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();
        String extension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

        File::WriteAllBytes(String::Format(u"oleFrame{0}{1}", index, extension), data);
    }
}
```