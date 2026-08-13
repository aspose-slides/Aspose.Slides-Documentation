---
title: Por qué no Open XML SDK
type: docs
weight: 120
url: /es/java/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- comparación
- modelo de objeto de presentación
- conversión de alta calidad
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Vea por qué Aspose.Slides es una mejor opción que el gratuito Open XML SDK: compare características, conversión sin automatización y amplio soporte para PPT, PPTX y ODP."
---
## **Descripción general**

Este artículo explica cuándo los desarrolladores pueden elegir Open XML SDK o Aspose.Slides para trabajar con documentos de presentación. Describe Open XML SDK como una biblioteca para manipular paquetes OOXML y sus elementos XML subyacentes, mientras que Aspose.Slides se presenta como una biblioteca de procesamiento de presentaciones con un modelo de objetos de alto nivel y soporte para muchas tareas relacionadas con PowerPoint.

El artículo compara ambas opciones por formatos compatibles, modelo de programación, capacidades de renderizado e impresión, soporte de plataformas y casos de uso comunes. También aclara que Open XML SDK puede ser adecuado para operaciones básicas con PPTX o acceso directo a los elementos OOXML, mientras que Aspose.Slides es más apropiado para tareas complejas de presentación, como trabajar con múltiples formatos de PowerPoint, copiar o clonar formas, reemplazar texto, aplicar animaciones y convertir presentaciones a PDF, TIFF o XPS.

## **¿Qué es Open XML SDK?**
Según la [Biblioteca MSDN](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk), Open XML SDK se define como: 

The Open XML SDK 2.0 simplifies the task of manipulating Open XML packages and the underlying Open XML schema elements within a package. The Open XML SDK 2.0 encapsulates many common tasks that developers perform on Open 

XML packages, so that you can perform complex operations with just a few lines of code.

OOXML documents are essentially zipped XML files and Open XML SDK is a collection of classes that allows you to work with the content of OOXML documents in a strongly-typed way. That is instead of unzipping a file to 

extract XML, loading that XML into a DOM tree and working with XML elements and attributes directly, Open XML SDK provides classes to do that.

## **¿Qué es Aspose.Slides?**
Aspose.Slides es una biblioteca de clases que permite a su aplicación realizar las siguientes tareas de procesamiento de presentaciones:

- Programación con un modelo de objetos **Presentation**.
- Conversiones de alta calidad entre todos los formatos de presentación PowerPoint compatibles, incluida la conversión a PDF, XPS y TIFF.
- Capacidad para generar miniaturas de diapositivas en formatos conocidos como PNG, JPEG y BMP, junto con la exportación de diapositivas a SVG.
- Capacidad para crear presentaciones desde cero o combinando uno o varios documentos.
- Compatibilidad para agregar animaciones, Marcos Ole, tablas, crear y gestionar gráficos.
- Disponibilidad de un control extenso para gestionar el formato de texto en niveles de TextFrames, Paragraphs y Portions.

Para obtener más detalles sobre las características admitidas, visite [Características de Aspose.Slides](/slides/es/java/product-overview/).

## **Comparar Open XML SDK con Aspose.Slides**
{{% alert color="info" %}} 

La tabla siguiente compara las características de Open XML SDK y Aspose.Slides.

{{% /alert %}} 

|**Característica o categoría de característica**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Formatos de presentación compatibles|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Conversión de PPT a PPTX|No|Sí|
|<p>Programación de alto nivel con un Modelo de objeto de documento de presentación (DOM):</p><p>- Buscar y reemplazar texto.</p><p>- Ensamblar diapositivas en presentaciones.</p>|No|Sí|
|Programación detallada con un modelo de objetos de documento, acceso a elementos individuales y formatos como TextHolders, TextFrames, Paragraphs y Portions.|Sí|Sí|
|Acceso directo y completo de bajo nivel a los elementos y atributos XML subyacentes, como identificadores de relaciones, identificadores de lista de un documento OOXML.|Sí|No|
|<p>Renderizado:</p><p>- Renderizar presentaciones a PDF, notas PDF, XPS, imágenes TIFF.</p><p>- Renderizar miniaturas de diapositivas a PNG, JPEG, BMP, SVG y TIFF.</p><p>- Especificar resolución, calidad, compresión y otras opciones.</p>|No|Sí|
|Plataformas compatibles|Windows, .NET|Windows, Linux,UNIX, MAC, Java, PHP, Mono|

## **Conclusión**
{{% alert color="info" %}} 

Open XML SDK y Aspose.Slides no compiten directamente porque atienden necesidades y audiencias bastante diferentes. Open XML SDK es una biblioteca de clases que proporciona una forma tipada para trabajar con documentos OOXML. Aspose.Slides es una biblioteca de procesamiento de presentaciones muy útil que ofrece un gran soporte para casi todos los formatos de archivo de Microsoft PowerPoint.

Si todo lo que necesita es una operación de programación bastante básica sobre un documento PPTX, entonces Open XML SDK podría ser una opción adecuada. Con Open XML SDK podrá realizar tareas simples como generar un documento PPTX sencillo o eliminar comentarios, encabezados/pies de página, extraer imágenes, entre otras. Algunas tareas pueden lograrse con Open XML SDK, pero no pueden lograrse con Aspose.Slides. Por ejemplo, si necesita acceder directamente a los elementos y atributos XML de un documento OOXML, entonces debe usar Open XML SDK. Sin embargo, si necesita realizar operaciones complejas sobre documentos, como algunas de las siguientes tareas, entonces usar Aspose.Slides es su mejor opción:

- Soportar formatos antiguos de PowerPoint además de PPTX.
- Copiar o clonar formas dentro de diapositivas de manera que combine objetos, estilos y otros formatos de forma adecuada.
- Reemplazar texto con o sin formato.
- Aplicar animaciones y usar conectores con las formas.
- Convertir un documento a PDF, TIFF o XPS para que aparezca exactamente como lo haría Microsoft PowerPoint.
- Desarrollar una aplicación .NET o Java tanto en entornos de escritorio como basados en web.

{{% /alert %}}