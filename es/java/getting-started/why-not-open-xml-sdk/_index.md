---
title: Por qué no Open XML SDK
type: docs
weight: 180
url: /es/java/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- comparando
- modelo de objeto de presentación
- conversión de alta calidad
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Descubra por qué Aspose.Slides es una mejor opción que el Open XML SDK gratuito: compare funciones, conversión sin automatización y amplio soporte para PPT, PPTX y ODP."
---
## **Visión general**

Este artículo explica cuándo los desarrolladores pueden elegir Open XML SDK o Aspose.Slides para trabajar con documentos de presentaciones. Describe Open XML SDK como una biblioteca para manipular paquetes OOXML y sus elementos XML subyacentes, mientras que Aspose.Slides se presenta como una biblioteca de procesamiento de presentaciones con un modelo de objetos de alto nivel y soporte para muchas tareas relacionadas con PowerPoint.

El artículo compara ambas opciones por formatos compatibles, modelo de programación, renderizado, soporte de plataformas y casos de uso comunes. También aclara que Open XML SDK puede ser adecuado para operaciones básicas de PPTX o acceso directo a los elementos OOXML, mientras que Aspose.Slides es más apropiado para tareas complejas de presentación como trabajar con múltiples formatos de PowerPoint, copiar o clonar formas, reemplazar texto, aplicar animaciones y convertir presentaciones a PDF, TIFF o XPS.

## **¿Qué es Open XML SDK?**
Según la [MSDN Library](https://learn.microsoft.com/en-us/office/open-xml/open-xml-sdk), Open XML SDK se define como:

El Open XML SDK 2.0 simplifica la tarea de manipular paquetes Open XML y los elementos del esquema Open XML subyacentes dentro de un paquete. El Open XML SDK 2.0 encapsula muchas tareas comunes que los desarrolladores realizan en paquetes Open XML, de modo que puede ejecutar operaciones complejas con solo unas pocas líneas de código.

Los documentos OOXML son esencialmente archivos XML comprimidos y Open XML SDK es una colección de clases que le permite trabajar con el contenido de los documentos OOXML de forma fuertemente tipada. En lugar de descomprimir un archivo para extraer XML, cargar ese XML en un árbol DOM y trabajar directamente con los elementos y atributos XML, Open XML SDK proporciona clases para hacerlo.

## **¿Qué es Aspose.Slides?**
Aspose.Slides es una biblioteca de clases que permite a su aplicación realizar las siguientes tareas de procesamiento de presentaciones:

- Programar con un modelo de objetos **Presentation**.
- Conversión de alta calidad entre todos los formatos populares de presentaciones PowerPoint admitidos, incluida la conversión a PDF, XPS y TIFF.
- Capacidad para generar miniaturas de diapositivas en formatos bien conocidos como PNG, JPEG y BMP, junto con la exportación de diapositivas a SVG.
- Capacidad para crear presentaciones desde cero o combinando uno o varios documentos.
- Soporte para agregar animaciones, marcos Ole, tablas, crear y administrar gráficos.
- Disponibilidad de un control extenso para gestionar el formato de texto en niveles de TextFrames, Paragraphs y Portions.

Para más detalles sobre las características admitidas, visite la [Funciones de Aspose.Slides](/slides/es/java/product-overview/).

## **Compare Open XML SDK con Aspose.Slides**
{{% alert color="info" title="Note" %}}

La tabla siguiente compara las características de Open XML SDK y Aspose.Slides.

{{% /alert %}}

|**Función o categoría de función**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Formatos de presentaciones compatibles|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Conversión de PPT a PPTX|No|Sí|
|<p>Programación de alto nivel con un modelo de objetos de documento de presentación (DOM):</p><p>- Buscar y reemplazar texto.</p><p>- ensamblar diapositivas en presentaciones.</p>|No|Sí|
|Programación detallada con un modelo de objetos de documento, acceso a elementos individuales y formato como TextHolders, TextFrames, Paragraphs y Portions.|Sí|Sí|
|Acceso directo y completo de bajo nivel a los elementos y atributos XML subyacentes, como identificadores de relaciones, identificadores de lista de un documento OOXML.|Sí|No|
|<p>Renderizado:</p><p>- Renderizar presentaciones a PDF, PDF Notes, XPS, imágenes TIFF.</p><p>- Renderizar miniaturas de diapositivas a PNG, JPEG, BMP, SVG y TIFF.</p><p>- Especificar resolución de imagen, calidad, compresión y otras opciones.</p>|No|Sí |
|Plataformas compatibles|Windows, .NET|Windows, Linux,UNIX, MAC, Java, PHP, Mono|

## **Conclusión**
{{% alert color="info" title="Note" %}}

Open XML SDK y Aspose.Slides no compiten directamente porque abordan necesidades y públicos bastante diferentes. Open XML SDK es una biblioteca de clases que proporciona una forma fuertemente tipada de trabajar con documentos OOXML. Aspose.Slides es una biblioteca de procesamiento de presentaciones muy útil que brinda un gran soporte para casi todos los formatos de archivo de Microsoft PowerPoint.

Si lo único que necesita es una operación de programación bastante básica en un documento PPTX, entonces Open XML SDK podría ser una elección adecuada. Con Open XML SDK podrá realizar tareas simples como generar un documento PPTX sencillo o eliminar comentarios, encabezados/pies de página, extraer imágenes, entre otras. Algunas tareas pueden lograrse con Open XML SDK, pero no pueden alcanzarse con Aspose.Slides. Por ejemplo, si necesita acceder directamente a los elementos y atributos XML de un documento OOXML, entonces debe usar Open XML SDK. Sin embargo, si necesita ejecutar operaciones complejas en documentos, como algunas de las siguientes tareas, entonces usar Aspose.Slides es su mejor opción:

- Soporte para formatos antiguos de PowerPoint además de PPTX.
- Copiar o clonar formas dentro de diapositivas de manera que combine objetos, estilos y otros formatos de forma apropiada.
- Reemplazar texto con formato o sin formato.
- Aplicar animaciones y usar conectores con formas.
- Convertir un documento a PDF, TIFF o XPS para que aparezca exactamente como lo haría Microsoft PowerPoint al convertirlo.
- Desarrollar una aplicación .NET o Java tanto en entornos de escritorio como web.

{{% /alert %}}