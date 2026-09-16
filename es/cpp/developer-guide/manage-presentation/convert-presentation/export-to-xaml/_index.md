---
title: Exportar presentaciones a XAML en C++
linktitle: Presentación a XAML
type: docs
weight: 30
url: /es/cpp/export-to-xaml/
keywords:
- exportar PowerPoint
- exportar OpenDocument
- exportar presentación
- convertir PowerPoint
- convertir OpenDocument
- convertir presentación
- PowerPoint a XAML
- OpenDocument a XAML
- presentación a XAML
- PPT a XAML
- PPTX a XAML
- ODP a XAML
- guardar PPT como XAML
- guardar PPTX como XAML
- guardar ODP como XAML
- exportar PPT a XAML
- exportar PPTX a XAML
- exportar ODP a XAML
- C++
- Aspose.Slides
description: "Convierta diapositivas de PowerPoint y OpenDocument a XAML en C++ usando Aspose.Slides—solución rápida y sin Office que mantiene intacto su diseño."
---
## **Visión general**

Este artículo explica cómo exportar presentaciones de PowerPoint a XAML usando Aspose.Slides. Incluye una breve introducción a XAML, muestra cómo guardar una presentación en XAML con la configuración predeterminada y demuestra cómo personalizar la exportación mediante [XamlOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export.xaml/xamloptions/), incluida la exportación de diapositivas ocultas. El artículo también responde a algunas preguntas frecuentes relacionadas con fuentes de respaldo, compatibilidad de pilas XAML y el comportamiento de exportación de diapositivas ocultas.

## **Acerca de XAML**

XAML es un lenguaje de marcado basado en XML utilizado para describir interfaces de usuario en frameworks como WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) y Xamarin.Forms.

Puede trabajar con archivos XAML en un diseñador visual o escribir y editar el marcado directamente.

## **Exportar presentaciones a XAML con opciones predeterminadas**

El siguiente ejemplo en C++ muestra cómo exportar una presentación a XAML con la configuración predeterminada:

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/XamlOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto xamlOptions = System::MakeObject<XamlOptions>();
presentation->Save(xamlOptions);
```

De forma predeterminada, las diapositivas exportadas se guardan en una subcarpeta `pres` del directorio de trabajo actual del proceso, devuelto por [Directory::GetCurrentDirectory](https://reference.aspose.com/slides/es/cpp/system.io/directory/getcurrentdirectory/). La carpeta se crea automáticamente y cualquier imagen requerida también se guarda allí.

El nombre de la carpeta de salida se toma del nombre del archivo fuente sin su extensión. Para `pres.pptx`, los archivos de salida se denominan `pres/Slide_1.xaml`, `pres/Slide_2.xaml`, y así sucesivamente. Incluso si pasa una ruta absoluta a la presentación de entrada, la carpeta de salida se crea de forma relativa al directorio de trabajo actual, no junto al archivo de entrada.

## **Exportar presentaciones a XAML con opciones personalizadas**

Utilice la interfaz [IXamlOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export.xaml/ixamloptions/) para controlar cómo Aspose.Slides exporta una presentación a XAML.

Para guardar la salida en una ubicación personalizada, implemente [IXamlOutputSaver](https://reference.aspose.com/slides/es/cpp/aspose.slides.export.xaml/ixamloutputsaver/) y pase una instancia de su implementación al método [set_OutputSaver](https://reference.aspose.com/slides/es/cpp/aspose.slides.export.xaml/xamloptions/set_outputsaver/) de [XamlOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export.xaml/xamloptions/).

Para incluir diapositivas ocultas en la salida XAML, pase `true` al método [set_ExportHiddenSlides](https://reference.aspose.com/slides/es/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/), como se muestra en el siguiente ejemplo en C++:

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/XamlOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto xamlOptions = System::MakeObject<XamlOptions>();
xamlOptions->set_ExportHiddenSlides(true);
presentation->Save(xamlOptions);
```

## **Capturar todos los artefactos XAML generados**

Una exportación XAML puede producir un documento XAML para cada diapositiva exportada, además de imágenes y recursos complementarios. Pase un [IXamlOutputSaver](https://reference.aspose.com/slides/es/cpp/aspose.slides.export.xaml/ixamloutputsaver/) personalizado a [XamlOptions::set_OutputSaver](https://reference.aspose.com/slides/es/cpp/aspose.slides.export.xaml/xamloptions/set_outputsaver/) para recibir estos artefactos en lugar de utilizar el guardador predeterminado del sistema de archivos. Inicie la exportación con la sobrecarga específica de XAML de [Presentation::Save](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/save/) que acepta opciones XAML.

### **Comprender el ciclo de vida de la devolución de llamada**

El exportador llama a [IXamlOutputSaver::Save](https://reference.aspose.com/slides/es/cpp/aspose.slides.export.xaml/ixamloutputsaver/save/) por separado para cada artefacto generado:

- `path` identifica el artefacto y puede incluir directorios relativos. Conserve esta información porque XAML puede referenciar recursos mediante rutas relativas.
- `data` contiene los bytes del artefacto. Las imágenes y otros recursos binarios no deben decodificarse como texto.
- El guardador es responsable de retener o persistir los datos antes de devolver. Los ejemplos copian cada matriz de bytes a memoria propia de la aplicación.
- Considere la exportación como exitosa solo cuando la operación de guardado de la presentación devuelve y todas las devoluciones de llamada se completan correctamente. No suprima errores de almacenamiento ni inicie escrituras en segundo plano sin observar. Si la persistencia ocurre después, informe el éxito total solo después de que también se haya completado ese paso.

[XamlOptions::set_ExportHiddenSlides](https://reference.aspose.com/slides/es/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) también se aplica a un guardador personalizado. La configuración predeterminada, `false`, excluye los documentos XAML de diapositivas ocultas. Establecerlo en `true` los incluye junto con los recursos necesarios para su exportación. El recuento de recursos depende de la presentación; no asuma una devolución de llamada por diapositiva ni un orden fijo de devoluciones.

### **Exportar a memoria e inspeccionar los artefactos**

Este ejemplo completo carga `pres.pptx`, recoge cada artefacto en un [Dictionary<String, ArrayPtr<uint8_t>>](https://reference.aspose.com/slides/es/cpp/system.collections.generic/dictionary/), y muestra su nombre, tipo y número de bytes. Conserva los nombres suministrados exactamente. Los nombres duplicados provocan que la colección falle en lugar de sobrescribir silenciosamente un artefacto.

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/IXamlOutputSaver.h>
#include <Export/Xaml/XamlOptions.h>
#include <system/array.h>
#include <system/collections/dictionary.h>
#include <system/console.h>
#include <system/string_comparer.h>
#include <system/io/path.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;
using namespace System::Text;

class InMemoryXamlExample
{
    class MemoryXamlSaver : public IXamlOutputSaver
    {
    public:
        using ArtifactDictionary = Dictionary<String, ArrayPtr<uint8_t>>;
        SharedPtr<ArtifactDictionary> Artifacts = MakeObject<ArtifactDictionary>(StringComparer::get_Ordinal());

        void Save(String path, ArrayPtr<uint8_t> data) override
        {
            auto retainedData = data->Clone();
            Artifacts->Add(path, retainedData);
        }
    };

public:
    static void Run()
    {
        auto saver = MakeObject<MemoryXamlSaver>();
        auto presentation = MakeObject<Presentation>(u"pres.pptx");
        auto options = MakeObject<XamlOptions>();
        options->set_OutputSaver(saver);
        options->set_ExportHiddenSlides(true);
        presentation->Save(options);

        auto inspectXamlText = false;
        for (const auto& artifact : saver->Artifacts)
        {
            auto extension = Path::GetExtension(artifact.get_Key()).ToLowerInvariant();
            auto isXaml = extension == u".xaml";
            auto isImage = extension == u".png" || extension == u".jpg" || extension == u".jpeg" || extension == u".gif" || extension == u".bmp" || extension == u".tif" || extension == u".tiff" || extension == u".svg";
            String kind = isXaml ? u"slide XAML" : isImage ? u"image" : u"supporting resource";
            Console::WriteLine(u"{0}: {1} bytes ({2})", artifact.get_Key(), artifact.get_Value()->get_Length(), kind);

            // Decodificar solo XAML, y solo cuando se necesite inspección textual.
            if (isXaml && inspectXamlText)
            {
                auto markup = Encoding::get_UTF8()->GetString(artifact.get_Value());
                Console::WriteLine(markup);
            }
        }
    }
};
```

Llame a `InMemoryXamlExample::Run` desde su aplicación. Las comprobaciones de extensión son útiles para la inspección; conserve todos los artefactos, incluidos los tipos de recurso desconocidos. Deje los bytes sin modificar al almacenarlos o transmitirlos. Use [Encoding::GetString](https://reference.aspose.com/slides/es/cpp/system.text/encoding/getstring/) con codificación UTF-8 solo para XAML que requiera procesamiento textual.

### **Empaquetar los artefactos recopilados en un archivo ZIP**

Este ejemplo independiente recopila la exportación, valida sus nombres y escribe los bytes originales en un archivo ZIP. Un nombre de archivo único separa los trabajos de exportación concurrentes. Las entradas ZIP usan barras diagonales y conservan los directorios relativos. Los nombres inseguros o que colisionan tras la normalización rechazan todo el paquete antes de escribirlo.

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/IXamlOutputSaver.h>
#include <Export/Xaml/XamlOptions.h>
#include <system/array.h>
#include <system/collections/dictionary.h>
#include <system/console.h>
#include <system/string_comparer.h>
#include <system/guid.h>
#include <system/io/file_access.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/io/path.h>
#include <zip/zip_file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;
using namespace Aspose::Zip;

class ZipXamlExample
{
    class CollectedXamlSaver : public IXamlOutputSaver
    {
    public:
        using ArtifactDictionary = Dictionary<String, ArrayPtr<uint8_t>>;
        SharedPtr<ArtifactDictionary> Artifacts = MakeObject<ArtifactDictionary>(StringComparer::get_Ordinal());

        void Save(String path, ArrayPtr<uint8_t> data) override
        {
            auto retainedData = data->Clone();
            Artifacts->Add(path, retainedData);
        }
    };

public:
    static void Run()
    {
        auto saver = MakeObject<CollectedXamlSaver>();
        auto presentation = MakeObject<Presentation>(u"pres.pptx");
        auto options = MakeObject<XamlOptions>();
        options->set_OutputSaver(saver);
        options->set_ExportHiddenSlides(false);
        presentation->Save(options);

        auto entries = MakeObject<Dictionary<String, ArrayPtr<uint8_t>>>(StringComparer::get_OrdinalIgnoreCase());
        for (const auto& artifact : saver->Artifacts)
        {
            auto entryName = artifact.get_Key().Replace(u'\\', u'/');
            auto segments = entryName.Split(u'/');
            auto unsafeName = entryName.StartsWith(u"/", StringComparison::Ordinal) || entryName.Contains(u":");
            for (const auto& segment : segments)
            {
                unsafeName |= String::IsNullOrWhiteSpace(segment) || segment == u"." || segment == u"..";
            }

            if (unsafeName || entries->ContainsKey(entryName))
            {
                Console::WriteLine(u"Export rejected: unsafe or duplicate artifact name: {0}", artifact.get_Key());
                return;
            }
            entries->Add(entryName, artifact.get_Value());
        }

        auto jobId = Guid::NewGuid();
        auto archivePath = u"xaml-" + jobId.ToString(u"N") + u".zip";
        auto archive = MakeObject<ZipFile>();
        for (const auto& artifact : entries)
        {
            auto fileName = Path::GetFileName(artifact.get_Key());
            auto directoryName = Path::GetDirectoryName(artifact.get_Key()).Replace(u'\\', u'/');
            archive->AddEntry(fileName, directoryName, artifact.get_Value());
        }

        auto output = MakeObject<FileStream>(archivePath, FileMode::CreateNew, FileAccess::Write);
        archive->Save(output);
        output->Close();
        archive->Dispose();

        // Save finaliza el directorio ZIP; cierre el archivo antes de informar del éxito.
        Console::WriteLine(u"Saved {0} artifacts to {1}", entries->get_Count(), archivePath);
    }
};
```

Llame a `ZipXamlExample::Run` desde su aplicación. El ejemplo usa `Aspose::Zip::ZipFile` del tiempo de ejecución de C++ para escribir un archivo local; el exportador no escribe archivos XAML o de imagen sueltos. Para almacenamiento remoto, reemplace la fase de escritura del archivo con cargas de los arreglos de bytes recopilados. Use un identificador de trabajo de exportación más el nombre relativo completo del artefacto como clave de blob, o almacene el identificador del trabajo, el nombre relativo y los datos binarios en una fila de base de datos. Publique el trabajo solo después de que todas las cargas hayan finalizado o la transacción de base de datos se haya comprometido. Limpie la salida parcial si la persistencia falla.

Para presentaciones grandes, un guardador personalizado puede persistir cada artefacto directamente en el almacenamiento de la aplicación para evitar mantener una copia adicional de toda la exportación en la memoria de la aplicación. El exportador sigue recopilando todos los artefactos generados en memoria antes de llamar al guardador. Mantenga cada devolución de llamada sincrónica desde la perspectiva del exportador: devuelva solo después de que el destino haya aceptado los bytes y permita que los errores lleguen al llamador.

### **Conservar los nombres de los recursos y verificar las referencias**

- Normalice los separadores de ruta cuando el destino lo requiera, pero conserve los directorios relativos. No use solo [Path::GetFileName](https://reference.aspose.com/slides/es/cpp/system.io/path/getfilename/) a menos que se sepa que cada nombre generado es único y las referencias a recursos sigan siendo válidas.
- Aplique la validación de nombres específica del destino. Al escribir archivos sueltos, rechace rutas ancladas y segmentos de traversa, resuelva el destino con [Path::GetFullPath](https://reference.aspose.com/slides/es/cpp/system.io/path/getfullpath/), y verifique que permanezca bajo el directorio de exportación previsto, incluyendo el separador de directorio en la comprobación de contención. Use un directorio controlado por la aplicación sin enlaces simbólicos que puedan redirigir escrituras.
- Use un guardador y un espacio de nombres de almacenamiento separados para cada trabajo de exportación. Detecte colisiones después de la normalización de separadores y según las reglas de sensibilidad a mayúsculas del destino.
- Antes de publicar, analice cada documento XAML como XML e inspeccione sus referencias de recursos basadas en archivos, como atributos `Source` o `ImageSource` de imágenes. Resuelva cada URI relativa contra el directorio del artefacto XAML contenedor, normalice el nombre de almacenamiento resultante y confirme que la clave correspondiente del diccionario, la entrada ZIP o el objeto almacenado existen. Trate las URIs externas y las expresiones de marcado XAML por separado de los nombres de archivo relativos.

Por ejemplo, si `pres/Slide_1.xaml` hace referencia a `images/image1.png`, el recurso almacenado debe estar disponible como `pres/images/image1.png`. Mantener solo `image1.png` rompería esa relación. Para almacenamiento de objetos, conserve la misma estructura bajo el prefijo del trabajo y haga que esas URLs de recursos sean accesibles para el consumidor de XAML. Vuelva a abrir el ZIP completado para verificar los nombres de entrada y los bytes de los recursos, y cargue diapositivas representativas en el entorno XAML de destino para confirmar que las imágenes se resuelvan correctamente.

## **Preguntas frecuentes**

**¿Cómo puedo garantizar fuentes predecibles si la fuente original no está disponible en el equipo?**

Utilice [set_DefaultRegularFont](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) en [XamlOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export.xaml/xamloptions/) — se usa como fuente de respaldo durante la exportación cuando falta la original. Esto no garantiza que el XAML generado haga referencia a la fuente de respaldo o que la fuente esté disponible en la máquina de destino. Asegúrese de que las fuentes referenciadas por el XAML estén presentes en el entorno donde se mostrará.

**¿El XAML exportado está destinado solo a WPF o puede usarse también en otras pilas XAML?**

Aspose.Slides exporta XAML de WPF a través de su API pública. La compatibilidad con otras pilas XAML, como UWP y Xamarin.Forms, no está garantizada. Pruebe el marcado generado en su entorno objetivo.

**¿Se admiten diapositivas ocultas y cómo puedo evitar que se exporten por defecto?**

De forma predeterminada, las diapositivas ocultas no se incluyen. Puede controlar este comportamiento mediante [set_ExportHiddenSlides](https://reference.aspose.com/slides/es/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) en [XamlOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export.xaml/xamloptions/) — manténgalo desactivado si no necesita exportarlas.