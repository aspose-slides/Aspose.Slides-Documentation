---
title: Guardar presentaciones en C++
linktitle: Guardar presentación
type: docs
weight: 80
url: /es/cpp/save-presentation/
keywords:
- guardar PowerPoint
- guardar OpenDocument
- guardar presentación
- guardar diapositiva
- guardar PPT
- guardar PPTX
- guardar ODP
- presentación a archivo
- presentación a flujo
- tipo de vista predefinido
- Formato estricto Office Open XML
- modo Zip64
- actualizar miniatura
- progreso de guardado
- C++
- Aspose.Slides
description: "Descubra cómo guardar presentaciones en C++ usando Aspose.Slides—exportar a PowerPoint u OpenDocument manteniendo diseños, fuentes y efectos."
---

## **Visión general**

[Open Presentations in C++](/slides/es/cpp/open-presentation/) describió cómo usar la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) para abrir una presentación. Este artículo explica cómo crear y guardar presentaciones. La clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) contiene el contenido de una presentación. Ya sea que esté creando una presentación desde cero o modificando una existente, querrá guardarla cuando haya terminado. Con Aspose.Slides para C++, puede guardar en un **archivo** o **flujo**. Este artículo explica las diferentes formas de guardar una presentación.

## **Guardar presentaciones en archivos**

Guarde una presentación en un archivo llamando al método `Save` de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/). Pase el nombre de archivo y el formato de guardado al método. El siguiente ejemplo muestra cómo guardar una presentación con Aspose.Slides.
```cpp
// Instanciar la clase Presentation que representa un archivo de presentación.
auto presentation = MakeObject<Presentation>();

// Realizar trabajo aquí...

// Guardar la presentación en un archivo.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);

presentation->Dispose();
```


## **Guardar presentaciones en flujos**

Puede guardar una presentación en un flujo pasando un flujo de salida al método `Save` de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/). Una presentación puede escribirse en muchos tipos de flujo. En el ejemplo a continuación, creamos una nueva presentación y la guardamos en un flujo de archivo.
```cpp
// Instanciar la clase Presentation que representa un archivo de presentación.
auto presentation = MakeObject<Presentation>();

auto fileStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

// Guardar la presentación en el flujo.
presentation->Save(fileStream, SaveFormat::Pptx);

presentation->Dispose();
fileStream->Close();
```


## **Guardar presentaciones con un tipo de vista predefinido**

Aspose.Slides le permite establecer la vista inicial que PowerPoint usa cuando se abre la presentación generada mediante la clase [ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/). Use el método [set_LastView](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/set_lastview/) con un valor de la enumeración [ViewType](https://reference.aspose.com/slides/cpp/aspose.slides/viewtype/).
```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);

presentation->Save(u"SlideMasterView.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Guardar presentaciones en el formato estricto Office Open XML**

Aspose.Slides le permite guardar una presentación en el formato estricto Office Open XML. Use la clase [PptxOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pptxoptions/) y establezca su propiedad de conformidad al guardar. Si establece `Conformance.Iso29500_2008_Strict`, el archivo de salida se guarda en el formato estricto Office Open XML.

El ejemplo a continuación crea una presentación y la guarda en el formato estricto Office Open XML.
```cpp
auto options = MakeObject<PptxOptions>();
options->set_Conformance(Conformance::Iso29500_2008_Strict);

// Instanciar la clase Presentation que representa un archivo de presentación.
auto presentation = MakeObject<Presentation>();

// Guardar la presentación en el formato estricto Office Open XML.
presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```


## **Guardar presentaciones en formato Office Open XML en modo Zip64**

Un archivo Office Open XML es un archivo ZIP que impone límites de 4 GB (2^32 bytes) al tamaño sin comprimir de cualquier archivo, al tamaño comprimido de cualquier archivo y al tamaño total del archivo, y también limita el archivo a 65 535 (2^16‑1) archivos. Las extensiones del formato ZIP64 elevan estos límites a 2^64.

El método [IPptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/cpp/aspose.slides.export/ipptxoptions/set_zip64mode/) le permite elegir cuándo usar las extensiones de formato ZIP64 al guardar un archivo Office Open XML.

Este método puede usarse con los siguientes modos:

- `IfNecessary` usa extensiones ZIP64 solo si la presentación supera las limitaciones anteriores. Este es el modo predeterminado.
- `Never` nunca usa extensiones ZIP64.
- `Always` siempre usa extensiones ZIP64.

El siguiente código demuestra cómo guardar una presentación como PPTX con las extensiones ZIP64 habilitadas:
```cpp
auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_Zip64Mode(Zip64Mode::Always);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```


{{% alert title="NOTE" color="warning" %}}
Al guardar con `Zip64Mode.Never`, se lanza una [PptxException](https://reference.aspose.com/slides/cpp/aspose.slides/pptxexception/) si la presentación no puede guardarse en formato ZIP32.
{{% /alert %}}

## **Guardar presentaciones sin refrescar la miniatura**

El método [PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) controla la generación de miniaturas al guardar una presentación en PPTX:

- Si se establece en `true`, la miniatura se actualiza durante el guardado. Este es el valor predeterminado.
- Si se establece en `false`, se conserva la miniatura actual. Si la presentación no tiene miniatura, no se genera ninguna.

En el código a continuación, la presentación se guarda en PPTX sin refrescar su miniatura.
```cpp
auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_RefreshThumbnail(false);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```


{{% alert title="Info" color="info" %}}
Esta opción ayuda a reducir el tiempo necesario para guardar una presentación en formato PPTX.
{{% /alert %}}

## **Guardar actualizaciones de progreso en porcentaje**

La interfaz [IProgressCallback](https://reference.aspose.com/slides/cpp/aspose.slides/iprogresscallback/) se utiliza a través del método `set_ProgressCallback` expuesto por la interfaz [ISaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/isaveoptions/) y la clase abstracta [SaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/). Asigne una implementación de [IProgressCallback] con `set_ProgressCallback` para recibir actualizaciones del progreso de guardado como porcentaje.

Los siguientes fragmentos de código muestran cómo usar `IProgressCallback`.
```cpp
class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue)
    {
        // Use el valor del porcentaje de progreso aquí.
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};
```

```cpp
auto saveOptions = MakeObject<PdfOptions>();
saveOptions->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, saveOptions);
presentation->Dispose();
```


{{% alert title="Info" color="info" %}}
Aspose ha desarrollado una [aplicación gratuita PowerPoint Splitter](https://products.aspose.app/slides/splitter) usando su propia API. La aplicación le permite dividir una presentación en varios archivos guardando diapositivas seleccionadas como nuevos archivos PPTX o PPT.
{{% /alert %}}

## **Preguntas frecuentes**

**¿Se admite el "guardado rápido" (guardado incremental) para que solo se escriban los cambios?**

No. Cada vez que se guarda se crea el archivo completo; el "guardado rápido" incremental no es compatible.

**¿Es seguro guardar la misma instancia de Presentation desde varios hilos?**

No. Una instancia de [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) [no es segura para subprocesos](/slides/es/cpp/multithreading/); guárdela desde un solo hilo.

**¿Qué ocurre con los hipervínculos y los archivos vinculados externamente al guardar?**

[Los hipervínculos](/slides/es/cpp/manage-hyperlinks/) se conservan. Los archivos vinculados externamente (p. ej., videos mediante rutas relativas) no se copian automáticamente; asegúrese de que las rutas referenciadas permanezcan accesibles.

**¿Puedo establecer/guardar metadatos del documento (Autor, Título, Empresa, Fecha)?**

Sí. Las [propiedades estándar del documento](/slides/es/cpp/presentation-properties/) son compatibles y se escribirán en el archivo al guardarlo.