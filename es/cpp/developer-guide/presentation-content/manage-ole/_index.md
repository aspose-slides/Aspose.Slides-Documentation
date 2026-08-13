---
title: Gestionar OLE en presentaciones con C++
linktitle: Gestionar OLE
type: docs
weight: 40
url: /es/cpp/manage-ole/
keywords:
- Objeto OLE
- Vinculación e Inserción de Objetos
- añadir OLE
- incorporar OLE
- añadir objeto
- incorporar objeto
- añadir archivo
- incorporar archivo
- objeto vinculado
- archivo vinculado
- cambiar OLE
- icono OLE
- título OLE
- extraer OLE
- extraer objeto
- extraer archivo
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Optimice la gestión de objetos OLE en archivos PowerPoint y OpenDocument con Aspose.Slides para C++. Incorpore, actualice y exporte contenido OLE sin problemas."
---
## **Introducción**

{{% alert title="Info" color="info" %}}

OLE (Object Linking & Embedding) es una tecnología de Microsoft que permite que los datos y objetos creados en una aplicación se coloquen en otra aplicación mediante enlaces o incrustaciones. 

{{% /alert %}} 

Considere un gráfico creado en MS Excel. El gráfico se coloca luego dentro de una diapositiva de PowerPoint. Ese gráfico de Excel se considera un objeto OLE. 

- Un objeto OLE puede aparecer como un icono. En este caso, al hacer doble clic en el icono, el gráfico se abre en su aplicación asociada (Excel), o se le solicita seleccionar una aplicación para abrir o editar el objeto. 
- Un objeto OLE puede mostrar su contenido real, como el contenido de un gráfico. En este caso, el gráfico se activa en PowerPoint, se carga la interfaz del gráfico y puede modificar los datos del gráfico dentro de PowerPoint.

[Aspose.Slides for C++](https://products.aspose.com/slides/es/cpp/) permite insertar objetos OLE en diapositivas como marcos de objetos OLE ([OleObjectFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/oleobjectframe/)).

## **Añadir marcos de objetos OLE a diapositivas**

Suponiendo que ya haya creado un gráfico en Microsoft Excel y desee incrustarlo en una diapositiva como un marco de objeto OLE usando Aspose.Slides for C++, puede hacerlo de esta manera:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.presentation).  
2. Obtenga una referencia a la diapositiva mediante su índice.  
3. Lea el archivo de Excel como una matriz de bytes.  
4. Añada el [OleObjectFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/oleobjectframe/) a la diapositiva que contenga la matriz de bytes y otra información sobre el objeto OLE.  
5. Guarde la presentación modificada como un archivo PPTX.  

En el ejemplo a continuación, añadimos un gráfico de un archivo de Excel a una diapositiva como un [OleObjectFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/oleobjectframe/) utilizando Aspose.Slides for C++.  
**Nota** que el constructor de [OleEmbeddedDataInfo](https://reference.aspose.com/slides/es/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) acepta una extensión de objeto incrustable como segundo parámetro. Esta extensión permite que PowerPoint interprete correctamente el tipo de archivo y elija la aplicación adecuada para abrir este objeto OLE.

``` cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <drawing/size_f.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slide(0);

// Prepare data for the OLE object.
auto fileData = File::ReadAllBytes(u"book.xlsx");
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(fileData, u"xlsx");

// Add the OLE object frame to the slide.
slide->get_Shapes()->AddOleObjectFrame(0, 0, slideSize.get_Width(), slideSize.get_Height(), dataInfo);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Agregar marcos de objetos OLE vinculados**

Aspose.Slides for C++ le permite añadir un [OleObjectFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/oleobjectframe/) sin incrustar datos, sino solo con un enlace al archivo.

Este código C++ le muestra cómo añadir un [OleObjectFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/oleobjectframe/) con un archivo de Excel vinculado a una diapositiva:

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Añadir un marco de objeto OLE con un archivo Excel vinculado.
slide->get_Shapes()->AddOleObjectFrame(20, 20, 200, 150, u"Excel.Sheet.12", u"book.xlsx");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Acceder a marcos de objetos OLE**

Si un objeto OLE ya está incrustado en una diapositiva, puede encontrarlo o acceder a él fácilmente de esta manera:

1. Cargue una presentación con el objeto OLE incrustado creando una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.presentation).  
2. Obtenga la referencia de la diapositiva utilizando su índice.  
3. Acceda a la forma [OleObjectFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/oleobjectframe/). En nuestro ejemplo, utilizamos el PPTX creado previamente que tiene solo una forma en la primera diapositiva. Luego *cast* ese objeto como un [IOleObjectFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/ioleobjectframe/). Este era el marco de objeto OLE deseado para acceder.  
4. Una vez accedido al marco del objeto OLE, puede realizar cualquier operación sobre él.

``` cpp
#include <DOM/IOleEmbeddedDataInfo.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{ 
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // Obtener los datos del archivo incrustado.
    auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

    // Obtener la extensión del archivo incrustado.
    auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

    // ...
}
```

### **Acceder a propiedades del marco de objeto OLE vinculado**

Aspose.Slides permite acceder a propiedades del marco de objeto OLE vinculado.

Este código C++ le muestra cómo comprobar si un objeto OLE está vinculado y luego obtener la ruta del archivo vinculado:

```cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.ppt");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // Comprobar si el objeto OLE está vinculado.
    if (oleFrame->get_IsObjectLink())
    {
        // Mostrar la ruta completa al archivo vinculado.
        std::wcout << L"OLE object frame is linked to: " << oleFrame->get_LinkPathLong() << std::endl;

        // Mostrar la ruta relativa al archivo vinculado si está presente.
        // Sólo las presentaciones PPT pueden contener la ruta relativa.
        if (!String::IsNullOrEmpty(oleFrame->get_LinkPathRelative()))
        {
            std::wcout << L"OLE object frame relative path: " << oleFrame->get_LinkPathRelative() << std::endl;
        }
    }
}
```

## **Cambiar datos del objeto OLE**

{{% alert color="info" %}} 

En esta sección, el ejemplo de código a continuación utiliza [Aspose.Cells for C++](/cells/cpp/).

{{% /alert %}}

Si un objeto OLE ya está incrustado en una diapositiva, puede acceder fácilmente a ese objeto y modificar sus datos de esta manera:

1. Cargue una presentación con el objeto OLE incrustado creando una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.presentation).  
2. Obtenga la referencia de la diapositiva mediante su índice.  
3. Acceda a la forma [OLEObjectFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/oleobjectframe/). En nuestro ejemplo, utilizamos el PPTX creado previamente que tiene una forma en la primera diapositiva. Luego *cast* ese objeto como un [IOleObjectFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/ioleobjectframe/). Este era el marco de objeto OLE deseado para acceder.  
4. Una vez accedido al marco del objeto OLE, puede realizar cualquier operación sobre él.  
5. Cree un objeto `Workbook` y acceda a los datos OLE.  
6. Acceda a la `Worksheet` deseada y modifique los datos.  
7. Guarde el `Workbook` actualizado en un flujo.  
8. Cambie los datos del objeto OLE a partir del flujo.

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/OoxmlSaveOptions.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/U16String.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

// Aspose.Cells para C++ debe iniciarse antes de usar cualquiera de sus tipos.
Aspose::Cells::Startup();

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

// Get the first shape as an OLE object frame.
auto oleFrame = AsCast<IOleObjectFrame>(slide->get_Shape(0));

if (oleFrame != nullptr)
{
    auto oleStream = MakeObject<MemoryStream>(oleFrame->get_EmbeddedData()->get_EmbeddedFileData());

    // Leer los datos del objeto OLE como un objeto Workbook.
    auto oleArray = oleStream->ToArray();
    std::vector<uint8_t> workbookData(oleArray->data().begin(), oleArray->data().end());
    Aspose::Cells::Workbook workbook(Aspose::Cells::Vector<uint8_t>(workbookData.data(), workbookData.size()));

    // Modificar los datos del workbook.
    auto worksheet = workbook.GetWorksheets().Get(0);
    worksheet.GetCells().Get(0, 4).PutValue(Aspose::Cells::U16String("E"));
    worksheet.GetCells().Get(1, 4).PutValue(12);
    worksheet.GetCells().Get(2, 4).PutValue(14);
    worksheet.GetCells().Get(3, 4).PutValue(15);

    Aspose::Cells::OoxmlSaveOptions fileOptions(Aspose::Cells::SaveFormat::Xlsx);
    auto newWorkbookData = workbook.Save(fileOptions);

    auto newOleStream = MakeObject<MemoryStream>();
    newOleStream->Write(
        MakeArray<uint8_t>(std::vector<uint8_t>(newWorkbookData.GetData(), newWorkbookData.GetData() + newWorkbookData.GetLength())),
        0, newWorkbookData.GetLength());

    // Cambiar los datos del objeto del marco OLE.
    auto newData = MakeObject<OleEmbeddedDataInfo>(newOleStream->ToArray(), oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension());
    oleFrame->SetEmbeddedData(newData);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);

Aspose::Cells::Cleanup();
```

## **Incrustar otros tipos de archivos en diapositivas**

Además de los gráficos de Excel, Aspose.Slides for C++ permite incrustar otros tipos de archivos en diapositivas. Por ejemplo, puede insertar archivos HTML, PDF y ZIP como objetos. Cuando el usuario hace doble clic en el objeto insertado, se abre automáticamente en el programa correspondiente, o se le solicita seleccionar un programa adecuado para abrirlo.

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto htmlData = File::ReadAllBytes(u"sample.html");
auto htmlDataInfo = MakeObject<OleEmbeddedDataInfo>(htmlData, u"html");
auto htmlOleFrame = slide->get_Shapes()->AddOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame->set_IsObjectIcon(true);

auto zipData = File::ReadAllBytes(u"sample.zip");
auto zipDataInfo = MakeObject<OleEmbeddedDataInfo>(zipData, u"zip");
auto zipOleFrame = slide->get_Shapes()->AddOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Establecer tipos de archivo para objetos incrustados**

Al trabajar con presentaciones, puede que necesite sustituir objetos OLE antiguos por nuevos o reemplazar un objeto OLE no compatible por uno compatible. Aspose.Slides for C++ permite establecer el tipo de archivo para un objeto incrustado, lo que le permite actualizar los datos del marco OLE o su extensión.

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();
auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

std::wcout << L"Current embedded file extension is: " << fileExtension << std::endl;

// Cambiar el tipo de archivo a ZIP.
oleFrame->SetEmbeddedData(MakeObject<OleEmbeddedDataInfo>(fileData, u"zip"));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Establecer imágenes de icono y títulos para objetos incrustados**

Después de incrustar un objeto OLE, se añade automáticamente una vista previa que consiste en una imagen de icono. Esta vista previa es lo que los usuarios ven antes de acceder o abrir el objeto OLE. Si desea usar una imagen y un texto específicos como elementos de la vista previa, puede establecer la imagen de icono y el título mediante Aspose.Slides for C++.

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

// Añadir una imagen a los recursos de la presentación.
auto imageData = File::ReadAllBytes(u"image.png");
auto oleImage = presentation->get_Images()->AddImage(imageData);

// Establecer un título y la imagen para la vista previa del OLE.
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Impedir que un marco de objeto OLE sea redimensionado y reposicionado**

Después de añadir un objeto OLE vinculado a una diapositiva de la presentación, al abrir la presentación en PowerPoint puede aparecer un mensaje que le pide actualizar los enlaces. Al hacer clic en el botón “Update Links” el tamaño y la posición del marco del objeto OLE pueden cambiar porque PowerPoint actualiza los datos del objeto OLE vinculado y refresca la vista previa del objeto. Para impedir que PowerPoint solicite actualizar los datos del objeto, establezca el método `set_UpdateAutomatic` de la interfaz [IOleObjectFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/ioleobjectframe/) a `false`:

```cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

oleFrame->set_UpdateAutomatic(false);
```

## **Extraer archivos incrustados**

Aspose.Slides for C++ permite extraer los archivos incrustados en diapositivas como objetos OLE de la siguiente forma:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.presentation) que contenga los objetos OLE que desea extraer.  
2. Recorra todas las formas en la presentación y acceda a las formas de [OLEObjectFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/oleobjectframe/).  
3. Acceda a los datos de los archivos incrustados desde los marcos de objetos OLE y escríbalos en disco.

``` cpp
#include <DOM/IOleEmbeddedDataInfo.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (int index = 0; index < slide->get_Shapes()->get_Count(); index++)
{
    auto shape = slide->get_Shape(index);

    if (ObjectExt::Is<IOleObjectFrame>(shape))
    { 
        auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

        auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();
        auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

        auto fileName = String::Format(u"OLE_object_{0}{1}", index, fileExtension);
        File::WriteAllBytes(fileName, fileData);
    }
}

presentation->Dispose();
```

## **Preguntas frecuentes**

### ¿Se renderizará el contenido OLE al exportar diapositivas a PDF/imagenes?

Lo que es visible en la diapositiva se renderiza: el icono/imagen sustituta (vista previa). El contenido OLE “en vivo” no se ejecuta durante el renderizado. Si es necesario, establezca su propia imagen de vista previa para asegurar la apariencia esperada en el PDF exportado.

### ¿Cómo puedo bloquear un objeto OLE en una diapositiva para que los usuarios no puedan moverlo/editarlo en PowerPoint?

Bloquee la forma: Aspose.Slides ofrece [bloqueos a nivel de forma](/slides/es/cpp/applying-protection-to-presentation/). No es encriptación, pero impide eficazmente ediciones y movimientos accidentales.

### ¿Por qué un objeto Excel vinculado “salta” o cambia de tamaño al abrir la presentación?

PowerPoint puede actualizar la vista previa del OLE vinculado. Para una apariencia estable, siga las prácticas de la [Solución funcional para el redimensionado de hojas de cálculo](/slides/es/cpp/working-solution-for-worksheet-resizing/): ajuste el marco al rango o escale el rango a un marco fijo y establezca una imagen sustituta adecuada.

### ¿Se conservarán las rutas relativas para objetos OLE vinculados en el formato PPTX?

En PPTX, la información de “ruta relativa” no está disponible, solo la ruta completa. Las rutas relativas se encuentran en el formato PPT más antiguo. Para portabilidad, prefiera rutas absolutas fiables/URIs accesibles o incrustar los objetos.