---
title: Por qué no Open XML SDK
type: docs
weight: 100
url: /es/cpp/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- comparación
- modelo de objeto de presentación
- conversión de alta calidad
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Vea por qué Aspose.Slides es una mejor opción que el Open XML SDK gratuito: compare características, conversión sin automatización y amplio soporte para PPT, PPTX y ODP."
---
## **Visión general**

Este artículo explica cuándo los desarrolladores podrían elegir Open XML SDK o Aspose.Slides para trabajar con documentos de presentación. Describe Open XML SDK como una biblioteca para manipular paquetes OOXML y sus elementos XML subyacentes, mientras que Aspose.Slides se presenta como una biblioteca de procesamiento de presentaciones con un modelo de objetos de alto nivel y soporte para muchas tareas relacionadas con PowerPoint.

El artículo compara ambas opciones según los formatos compatibles, el modelo de programación, el renderizado, el soporte de plataformas y los casos de uso comunes. También aclara que Open XML SDK puede ser adecuado para operaciones básicas de PPTX o acceso directo a los elementos OOXML, mientras que Aspose.Slides es más apropiado para tareas de presentación complejas, como trabajar con múltiples formatos de PowerPoint, copiar o clonar formas, reemplazar texto, aplicar animaciones y convertir presentaciones a PDF, TIFF o XPS.

## **¿Qué es Open XML SDK?**
A veces escuchamos esta pregunta: ¿Por qué deberíamos usar productos Aspose en lugar del Open XML SDK gratuito? Esta pregunta es fácil de responder: características y funcionalidad. Según la [Biblioteca MSDN](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk), Open XML SDK se define como: *El Open XML SDK 2.0 simplifica la tarea de manipular paquetes Open XML y los elementos del esquema Open XML subyacentes dentro de un paquete.* El Open XML SDK 2.0 encapsula muchas tareas comunes que los desarrolladores realizan en paquetes Open XML, de modo que puede ejecutar operaciones complejas con solo unas pocas líneas de código. Los documentos OOXML son esencialmente archivos XML comprimidos y Open XML SDK es una colección de clases que le permite trabajar con el contenido de los documentos OOXML de forma tipada. Es decir, en lugar de descomprimir un archivo para extraer XML, cargar ese XML en un árbol DOM y trabajar directamente con los elementos y atributos XML, Open XML SDK proporciona clases para hacerlo.

## **¿Qué es Aspose.Slides?**
Aspose.Slides es una biblioteca de clases que permite a su aplicación realizar las siguientes tareas de procesamiento de presentaciones:

- Programación con un modelo de objetos **Presentation**.
- Conversiones de alta calidad entre todos los formatos de presentación de PowerPoint admitidos, incluida la conversión a PDF y XPS.
- Capacidad para generar miniaturas de diapositivas en formatos conocidos como PNG, JPEG y BMP, además de la exportación de diapositivas a SVG.
- Capacidad para crear presentaciones desde cero o combinando uno o varios documentos.
- Soporte para añadir animaciones, Ole Frames, tablas, crear y gestionar gráficos.
- Disponibilidad de un control amplio para gestionar el formato de texto en niveles de TextFrames, Paragraphs y Portions.

Para obtener más detalles sobre las funciones admitidas, visite [Características de Aspose.Slides](/slides/es/cpp/product-overview/).

## **Comparar Open XML SDK y Aspose.Slides**
La tabla siguiente compara las características de Open XML SDK y Aspose.Slides.

|**Función o categoría de función**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Formatos de presentaciones compatibles|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Conversión de PPT a PPTX|No|Sí|
|<p>Programación de alto nivel con un Modelo de Objeto de Documento de Presentación (DOM):</p><p>- Buscar y reemplazar texto.</p><p>- Ensamblar diapositivas en presentaciones.</p>|No|<p>Programación de alto nivel con un Modelo de Objeto de Documento de Presentación (DOM):</p><p>- Buscar y reemplazar texto.</p><p>- Ensamblar diapositivas en presentaciones.</p>|
|Programación detallada con un modelo de objeto de documento, acceso a elementos individuales y formato como TextHolders, TextFrames, Paragraphs y Portions.|Sí|Sí|
|Acceso directo y completo de bajo nivel a los elementos y atributos XML subyacentes, como identificadores de relaciones, identificadores de lista de un documento OOXML.|Sí|No|
|<p>Renderizado:</p><p>- Renderizar presentaciones a PDF, PDF Notes, XPS, imágenes TIFF.</p><p>- Renderizar miniaturas de diapositivas a PNG, JPEG, BMP, SVG y TIFF.</p><p>- Especificar resolución de imagen, calidad, compresión y otras opciones.</p>|No|Sí|

## **Conclusión**
Open XML SDK y Aspose.Slides no compiten cara a cara porque abordan necesidades y audiencias bastante diferentes. Open XML SDK es una biblioteca de clases que proporciona una forma tipada de trabajar con documentos OOXML. Aspose.Slides es una biblioteca de procesamiento de presentaciones muy útil que ofrece un gran soporte para casi todos los formatos de archivo de Microsoft PowerPoint. Si lo único que necesita es una operación de programación bastante básica en un documento PPTX, entonces Open XML SDK podría ser una opción adecuada. Con Open XML SDK, se sentirá bastante cómodo realizando tareas simples como generar un documento PPTX sencillo o eliminar comentarios, encabezados/pies de página, extraer imágenes u otras. Algunas tareas pueden lograrse con Open XML SDK, pero no pueden lograrse con Aspose.Slides. Por ejemplo, si necesita acceder directamente a los elementos y atributos XML de un documento OOXML, entonces debería usar Open XML SDK. Sin embargo, si necesita realizar operaciones complejas en documentos, como algunas de las siguientes tareas, entonces usar Aspose.Slides es su mejor opción:

- Compatibilidad con formatos PowerPoint antiguos además de PPTX.
- Copiar o clonar formas dentro de diapositivas de manera que combine objetos, estilos y otros formatos de forma adecuada.
- Reemplazar texto con formato o sin formato.
- Aplicar animaciones y usar conectores con las formas.
- Convertir un documento a PDF o XPS para que aparezca exactamente como lo habría convertido Microsoft PowerPoint.
- Desarrollar una aplicación C++ tanto en entornos de escritorio como de consola.