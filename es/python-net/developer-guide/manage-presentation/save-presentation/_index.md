---
title: Guardar Presentación
type: docs
weight: 80
url: /es/python-net/save-presentation/
keywords: "Guardar PowerPoint, PPT, PPTX, Guardar Presentación, archivo, flujo, Python"
description: "Guardar presentación de PowerPoint como archivo o flujo en Python"
---

## **Guardar Presentación**
Abrir una Presentación describió cómo usar la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) para abrir una presentación. Este artículo explica cómo crear y guardar presentaciones. La clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) contiene el contenido de una presentación. Ya sea creando una presentación desde cero o modificando una existente, cuando termines, querrás guardar la presentación. Con Aspose.Slides para Python a través de .NET, se puede guardar como un **archivo** o **flujo**. Este artículo explica cómo guardar una presentación de diferentes maneras:

### **Guardar Presentaciones en Archivos**
Guarda una presentación en archivos llamando al método [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). Simplemente pasa el nombre del archivo y el formato de guardado al método [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). Los ejemplos que siguen muestran cómo guardar una presentación con Aspose.Slides para Python a través de .NET usando Python.

```py
import aspose.slides as slides

# Instanciar un objeto Presentation que representa un archivo PPT
with slides.Presentation() as presentation:
    
    #...haz algún trabajo aquí...

    # Guarda tu presentación en un archivo
    presentation.save("Saved_out.pptx", slides.export.SaveFormat.PPTX)
```


### **Guardar Presentaciones en Flujos**
Es posible guardar una presentación en un flujo pasando un flujo de salida al método Save de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). Hay muchos tipos de flujos en los que se puede guardar una presentación. En el ejemplo a continuación hemos creado un nuevo archivo de Presentación, agregamos texto en una forma y guardamos la presentación en el flujo.

```py
import aspose.slides as slides

# Instanciar un objeto Presentation que representa un archivo PPT
with slides.Presentation() as presentation:
    
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 200, 200)

    # Guarda tu presentación en un flujo
    with open("Save_As_Stream_out.pptx", "bw") as stream:
        presentation.save(stream, slides.export.SaveFormat.PPTX)
```


### **Guardar Presentaciones con Tipo de Vista Predefinido**
Aspose.Slides para Python a través de .NET proporciona una facilidad para establecer el tipo de vista para la presentación generada cuando se abre en PowerPoint a través de la clase [view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/). La propiedad [last_view](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) se utiliza para establecer el tipo de vista utilizando el enumerador [ViewType](https://reference.aspose.com/slides/python-net/aspose.slides/viewtype/).

```py
import aspose.slides as slides

# Instanciar un objeto Presentation que representa un archivo PPT
with slides.Presentation() as presentation:
    
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("pres-will-open-SlideMasterView.pptx", slides.export.SaveFormat.PPTX)

```

### **Guardar Presentaciones en Formato Estricto de Office Open XML**
Aspose.Slides permite guardar la presentación en formato Estricto de Office Open XML. Para tal fin, proporciona la clase [**PptxOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/) donde puedes establecer la propiedad Conformance al guardar el archivo de presentación. Si estableces su valor en Conformance.Iso29500_2008_Strict, el archivo de presentación de salida se guardará en formato Estricto de Office Open XML.

El siguiente código de ejemplo crea una presentación y la guarda en el formato Estricto de Office Open XML. Al llamar al método Save para la presentación, se pasa el objeto **[PptxOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/)** con la propiedad **[Conformance](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/)** establecida como **[Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/python-net/aspose.slides.export/conformance/)**.

```py
import aspose.slides as slides

# Instanciar un objeto Presentation que representa un archivo de presentación
with slides.Presentation() as presentation:
    # Obtener la primera diapositiva
    slide = presentation.slides[0]

    #Agregar una forma automática de tipo línea
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    options = slides.export.PptxOptions()
    options.conformance = slides.export.Conformance.ISO29500_2008_STRICT

    # Guardar la presentación en formato Estricto de Office Open XML
    presentation.save("NewPresentation_out.pptx", slides.export.SaveFormat.PPTX, options)

```


### **Guardar Actualizaciones de Progreso en Porcentaje**
Se ha añadido una nueva interfaz [**IProgressCallback**](https://reference.aspose.com/slides/python-net/aspose.slides/iprogresscallback/) a la interfaz [**ISaveOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/isaveoptions/) y a la clase abstracta [**SaveOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveoptions/). La interfaz **IProgressCallback** representa un objeto de devolución de llamada para guardar actualizaciones de progreso en porcentaje.

Los siguientes fragmentos de código a continuación muestran cómo usar la interfaz IProgressCallback:

```py
# [TODO[not_supported_yet]: implementación en python de interfaces .net]
```

{{% alert title="Info" color="info" %}}

Utilizando su propia API, Aspose desarrolló una [aplicación gratuita de Divisor de PowerPoint](https://products.aspose.app/slides/splitter) que permite a los usuarios dividir sus presentaciones en múltiples archivos. Esencialmente, la aplicación guarda las diapositivas seleccionadas de una presentación dada como nuevos archivos de PowerPoint (PPTX o PPT).

{{% /alert %}}