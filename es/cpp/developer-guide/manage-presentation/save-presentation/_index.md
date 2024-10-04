---
title: Guardar Presentación - Biblioteca C++ PowerPoint
linktitle: Guardar Presentación
type: docs
weight: 80
url: /es/cpp/save-presentation/
description: La API o Biblioteca C++ PowerPoint te permite guardar presentaciones en un archivo o flujo. Puedes crear una presentación desde cero o modificar una existente.
---

{{% alert title="Info" color="info" %}}

Para aprender cómo abrir o cargar presentaciones, consulta el artículo [*Abrir Presentación*](https://docs.aspose.com/slides/cpp/open-presentation/). 

{{% /alert %}}

El artículo aquí explica cómo guardar presentaciones.

La clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) contiene el contenido de una presentación. Ya sea creando una presentación desde cero o modificando una existente, cuando termines, querrás guardar la presentación. Con Aspose.Slides para C++, puede ser guardada como un **archivo** o **flujo**. Este artículo explica cómo guardar una presentación de diferentes maneras:

## **Guardar Presentación en Archivo**
Guarda una presentación en archivos llamando al método [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) de la clase **Presentation**. Simplemente pasa el nombre del archivo y el formato de guardado al método [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index). Los ejemplos que siguen muestran cómo guardar una presentación con Aspose.Slides para C++.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SaveToFile-SaveToFile.cpp" >}}
## **Guardar Presentación en Flujo**
Es posible guardar una presentación en un flujo pasando un flujo de salida al método Save de la clase [Presentation]() . Hay muchos tipos de flujos a los que se puede guardar una presentación. En el siguiente ejemplo hemos creado un nuevo archivo de Presentación, añadimos texto en una forma y guardamos la presentación en el flujo.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SaveToStream-SaveToStream.cpp" >}}


## **Guardar Presentación con Tipo de Vista Predefinido**
Aspose.Slides para C++ proporciona una función para establecer el tipo de vista para la presentación generada cuando se abre en PowerPoint a través de la clase [ViewProperties](http://www.aspose.com/api/net/slides/aspose.slides/viewproperties). La propiedad [LastView](http://www.aspose.com/api/net/slides/aspose.slides/viewproperties/properties/index) se utiliza para establecer el tipo de vista utilizando el enumerador [ViewType](http://www.aspose.com/api/net/slides/aspose.slides/viewtype).

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SaveAsPredefinedViewType-SaveAsPredefinedViewType.cpp" >}}

## **Guardar Presentación en Formato XML Abierto de Oficina Estricto**
Aspose.Slides te permite guardar la presentación en formato XML Abierto de Oficina Estricto. Para ello, proporciona la clase **PptxOptions** donde puedes establecer la propiedad de Conformidad mientras guardas el archivo de presentación. Si estableces su valor como **Conformance.Iso29500_2008_Strict**, entonces el archivo de presentación de salida se guardará en formato XML Abierto de Oficina Estricto.

El siguiente código de muestra crea una presentación y la guarda en el Formato XML Abierto de Oficina Estricto. Al llamar al método Save para la presentación, se pasa el objeto **PptxOptions** con la propiedad de Conformidad establecida como **Conformance.Iso29500_2008_Strict**.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SaveToStrictOpenXML-SaveToStrictOpenXML.cpp" >}}


## **Guardar Actualizaciones de Progreso en Porcentaje**
 Se ha añadido una nueva interfaz **IProgressCallback** a la interfaz **ISaveOptions** y a la clase abstracta **SaveOptions**. La interfaz **IProgressCallback** representa un objeto de callback para guardar actualizaciones de progreso en porcentaje.  

Los siguientes fragmentos de código muestran cómo usar la interfaz IProgressCallback:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CovertToPDFWithProgressUpdate-CovertToPDFWithProgressUpdate.cpp" >}}

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CovertToPDFWithProgressUpdate-ExportProgressHandler.cpp" >}}

{{% alert title="Info" color="info" %}}

Usando su propia API, Aspose desarrolló una [aplicación gratuita para dividir PowerPoint](https://products.aspose.app/slides/splitter) que permite a los usuarios dividir sus presentaciones en múltiples archivos. Esencialmente, la aplicación guarda las diapositivas seleccionadas de una presentación dada como nuevos archivos de PowerPoint (PPTX o PPT). 

{{% /alert %}}