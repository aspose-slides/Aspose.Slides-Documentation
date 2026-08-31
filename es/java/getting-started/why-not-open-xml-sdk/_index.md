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
description: "Descubre por qué Aspose.Slides es una mejor opción que el Open XML SDK gratuito: compara características, conversión sin automatización y amplio soporte para PPT, PPTX y ODP."
---
## **Visión general**

Este artículo explica cuándo los desarrolladores pueden elegir Open XML SDK o Aspose.Slides para trabajar con documentos de presentaciones. Describe Open XML SDK como una biblioteca para manipular paquetes OOXML y sus elementos XML subyacentes, mientras que Aspose.Slides se presenta como una biblioteca de procesamiento de presentaciones con un modelo de objetos de alto nivel y soporte para muchas tareas relacionadas con PowerPoint.

El artículo compara ambas opciones por formatos compatibles, modelo de programación, renderizado, soporte multiplataforma y casos de uso comunes. También aclara que Open XML SDK puede ser adecuado para operaciones básicas con PPTX o acceso directo a elementos OOXML, mientras que Aspose.Slides es más apropiado para tareas complejas de presentación, como trabajar con varios formatos de PowerPoint, copiar o clonar formas, reemplazar texto, aplicar animaciones y convertir presentaciones a PDF, TIFF o XPS.

## **¿Qué es Open XML SDK?**
Según la [Biblioteca MSDN](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk), Open XML SDK se define como:

El Open XML SDK 2.0 simplifica la tarea de manipular paquetes Open XML y los elementos del esquema Open XML subyacentes dentro de un paquete. El Open XML SDK 2.0 encapsula muchas tareas comunes que los desarrolladores realizan en paquetes Open XML, de modo que puedes realizar operaciones complejas con solo unas pocas líneas de código.

Los documentos OOXML son esencialmente archivos XML comprimidos y Open XML SDK es una colección de clases que permite trabajar con el contenido de los documentos OOXML de forma tipada. En lugar de descomprimir un archivo para extraer XML, cargar ese XML en un árbol DOM y trabajar directamente con los elementos y atributos XML, Open XML SDK proporciona clases para hacerlo.

## **¿Qué es Aspose.Slides?**
Aspose.Slides es una biblioteca de clases que permite a tu aplicación realizar las siguientes tareas de procesamiento de presentaciones:

- Programación con un modelo de objetos **Presentation**.
- Conversiones de alta calidad entre todos los formatos de presentación de PowerPoint compatibles, incluida la conversión a PDF, XPS y TIFF.
- Capacidad para generar miniaturas de diapositivas en formatos conocidos como PNG, JPEG y BMP, junto con la exportación de diapositivas a SVG.
- Capacidad para crear presentaciones desde cero o combinando uno o varios documentos.
- Soporte para añadir animaciones, marcos Ole, tablas, crear y gestionar gráficos.
- Disponibilidad de un control extenso para gestionar el formato del texto en niveles de TextFrames, Paragraphs y Portions.

Para más detalles sobre las características admitidas, visita [Funciones de Aspose.Slides](/slides/es/java/product-overview/).

## **Comparar Open XML SDK con Aspose.Slides**
{{% alert color="info" %}} 

La siguiente tabla compara las características de Open XML SDK y Aspose.Slides.

{{% /alert %}} 

|**Funcionalidad o Categoría**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Formatos de presentaciones compatibles|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Conversión de PPT a PPTX|No|Yes|
|<p>Programación de alto nivel con un Modelo de Objeto de Documento de Presentación (DOM):</p><p>- Buscar y reemplazar texto.</p><p>- Ensamblar diapositivas en presentaciones.</p>|No|Yes|
|Programación detallada con un modelo de objeto de documento, acceso a elementos individuales y formato como TextHolders, TextFrames, Paragraphs y Portions.|Yes|Yes|
|Acceso directo y completo a bajo nivel a los elementos XML subyacentes y atributos, como identificadores de relaciones, identificadores de lista de un documento OOXML.|Yes|No|
|<p>Renderizado:</p><p>- Renderizar presentaciones a PDF, notas PDF, XPS, imágenes TIFF.</p><p>- Renderizar miniaturas de diapositivas a PNG, JPEG, BMP, SVG y TIFF.</p><p>- Especificar resolución, calidad, compresión y otras opciones.</p>|No|Yes |
|Plataformas compatibles|Windows, .NET|Windows, Linux,UNIX, MAC, Java, PHP, Mono|

## **Conclusión**
{{% alert color="info" %}} 

Open XML SDK y Aspose.Slides no compiten directamente porque atienden necesidades y audiencias bastante diferentes. Open XML SDK es una biblioteca de clases que proporciona una forma tipada de trabajar con documentos OOXML. Aspose.Slides es una biblioteca de procesamiento de presentaciones muy útil que brinda un gran soporte para casi todos los formatos de archivo de Microsoft PowerPoint.

Si lo único que necesitas es una operación de programación bastante básica sobre un documento PPTX, entonces Open XML SDK podría ser una opción adecuada. Con Open XML SDK estarás bastante cómodo realizando tareas sencillas como generar un documento PPTX simple o eliminar comentarios, encabezados/pies de página, extraer imágenes u otros. Algunas tareas pueden lograrse con Open XML SDK, pero no pueden lograrse con Aspose.Slides. Por ejemplo, si necesitas acceder directamente a los elementos y atributos XML de un documento OOXML, entonces deberías usar Open XML SDK. Sin embargo, si necesitas realizar operaciones complejas sobre documentos, como algunas de las siguientes tareas, entonces usar Aspose.Slides es tu mejor opción:

- Soportar formatos de PowerPoint más antiguos además de PPTX.
- Copiar o clonar formas dentro de diapositivas de manera que combine objetos, estilos y otros formatos de forma adecuada.
- Reemplazar texto con o sin formato.
- Aplicar animaciones y usar conectores con las formas utilizadas.
- Convertir un documento a PDF, TIFF o XPS para que aparezca exactamente como lo convertiría Microsoft PowerPoint.
- Desarrollar una aplicación .NET o Java tanto en entornos de escritorio como basados en web.

{{% /alert %}}