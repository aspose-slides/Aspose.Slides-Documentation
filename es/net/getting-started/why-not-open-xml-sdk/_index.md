---
title: "¿Por qué no Open XML SDK?"
type: docs
weight: 50
url: /es/net/why-not-open-xml-sdk/
aliases:
  - /net/slides-on-cloud-platforms/extracting-text/open-xml-sdk/
keywords:
- Open XML SDK
- comparación
- modelo de objetos de presentación
- conversión de alta calidad
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Descubra por qué Aspose.Slides es una mejor opción que el gratuito Open XML SDK: compare características, conversión sin automatización y amplio soporte para PPT, PPTX y ODP."
---
## **Descripción general**

Este artículo explica cuándo los desarrolladores pueden elegir Open XML SDK o Aspose.Slides para trabajar con documentos de presentación. Describe Open XML SDK como una biblioteca para manipular paquetes OOXML y sus elementos XML subyacentes, mientras que Aspose.Slides se presenta como una biblioteca de procesamiento de presentaciones con un modelo de objetos de alto nivel y soporte para muchas tareas relacionadas con PowerPoint.

El artículo compara ambas opciones por formatos compatibles, modelo de programación, capacidades de renderizado e impresión, soporte de plataformas y casos de uso comunes. También aclara que Open XML SDK puede ser adecuado para operaciones básicas con PPTX o acceso directo a elementos OOXML, mientras que Aspose.Slides es más apropiado para tareas de presentación complejas como trabajar con múltiples formatos de PowerPoint, copiar o clonar formas, sustituir texto, aplicar animaciones y convertir presentaciones a PDF, TIFF o XPS.

## **¿Qué es Open XML SDK?**
A veces recibimos esta pregunta: *¿Por qué deberíamos usar productos Aspose en lugar del Open XML SDK gratuito?* 

Nos resulta fácil responder a esta pregunta en términos de características y funcionalidades. 

Según la [Biblioteca MSDN](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk), Open XML SDK se define así: 

> "El Open XML SDK 2.0 simplifica la tarea de manipular paquetes Open XML y los elementos del esquema Open XML subyacentes dentro de un paquete. El Open XML SDK 2.0 encapsula muchas tareas comunes que los desarrolladores realizan en paquetes Open XML, de modo que puede efectuar operaciones complejas con solo unas pocas líneas de código. Los documentos OOXML son esencialmente archivos XML comprimidos y el Open XML SDK es una colección de clases que le permite trabajar con el contenido de documentos OOXML de forma fuertemente tipada. En lugar de descomprimir un archivo para extraer XML, cargar ese XML en un árbol DOM y trabajar directamente con elementos y atributos XML, Open XML SDK proporciona clases para hacerlo."

## **¿Qué es Aspose.Slides?**
Aspose.Slides es una biblioteca de clases que permite a las aplicaciones realizar estas tareas de procesamiento de presentaciones: 

- Programación con un modelo de objetos de presentación.  
- Conversiones de alta calidad que abarcan todos los formatos de presentación PowerPoint compatibles, incluida la conversión a PDF, XPS, TIFF e impresión.  
- Generación de miniaturas de diapositivas en formatos conocidos como PNG, JPEG y BMP, junto con la exportación de diapositivas a SVG.  
- Creación de presentaciones desde cero o combinando elementos de uno o varios documentos.  
- Añadir animaciones, marcos OLE, tablas, crear y gestionar gráficos.  
- Control (control exhaustivo) y gestión del formato de texto en niveles de TextFrames, Paragraphs y Portions.  

Para más detalles sobre las características disponibles, consulte la página de [Características de Aspose.Slides](/slides/es/net/product-overview/).

## **Compare Open XML SDK with Aspose.Slides**
Esta tabla compara las capacidades y características de Open XML SDK con Aspose.Slides.

|**Características o categoría de características**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Formatos de presentación compatibles|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Conversión de PPT a PPTX |No|Sí|
|<p>Programación de alto nivel con un modelo de objetos de documento de presentación (DOM): </p><p>- Buscar y reemplazar textos.</p><p>- Ensamblar diapositivas en presentaciones.</p>|No|Sí|
|Programación detallada con un modelo de objetos de documento; acceso a elementos individuales y formato como TextHolders, TextFrames, Paragraphs y Portions.|Sí|Sí|
|Acceso directo y completo de bajo nivel a los elementos y atributos XML subyacentes, como identificadores de relaciones y de listas de un documento OOXML.|Sí|No|
|<p>Renderizado e impresión:</p><p>- Renderizar presentaciones a PDF, PDF Notes, XPS, imágenes TIFF.</p><p>- Renderizar miniaturas de diapositivas a PNG, JPEG, BMP, SVG y TIFF.</p><p>- Especificar resolución de imagen, calidad, compresión y otras opciones.</p><p>- Imprimir presentaciones usando la infraestructura de impresión .NET. El componente incluye un método de impresión integrado para imprimir las presentaciones tal como se muestra en la vista previa de impresión de MS PowerPoint.</p>|No|Sí|
|Plataformas compatibles|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **Conclusión**
Open XML SDK y Aspose.Slides no compiten directamente porque abordan necesidades considerablemente diferentes y están dirigidos a audiencias distintas. 

{{% alert color="primary" %}} 

Open XML SDK es una biblioteca de clases que proporciona una forma fuertemente tipada de trabajar con documentos OOXML, mientras que Aspose.Slides es una biblioteca de procesamiento de presentaciones increíblemente útil que ofrece gran soporte para casi todos los formatos de archivo de Microsoft PowerPoint. 

{{% /alert %}} 

Si su flujo de trabajo consiste en una operación de programación básica sobre un documento PPTX, entonces Open XML SDK podría ser una buena opción. Con Open XML SDK, debería sentirse cómodo realizando tareas simples como generar un documento PPTX sencillo o eliminar comentarios, encabezados/pies de página, extraer imágenes u otros. Algunas tareas pueden llevarse a cabo con Open XML SDK pero no con Aspose.Slides. Por ejemplo, si necesita acceder directamente a los elementos y atributos XML de un documento OOXML, debe usar Open XML SDK. 

Si necesita realizar tareas complejas sobre documentos —como las enumeradas a continuación— entonces Aspose.Slides es su mejor opción. 

- Operaciones que implican formatos antiguos de PowerPoint (y PPTX también).  
- Copiar o clonar formas dentro de diapositivas de forma que combine objetos, estilos y otros elementos de formato de manera apropiada.  
- Reemplazar texto con formato o sin formato.  
- Aplicar animaciones y usar conectores con formas.  
- Convertir un documento a PDF, TIFF o XPS para que aparezca como si Microsoft PowerPoint hubiera realizado la conversión.  
- Desarrollar una aplicación .NET o Java tanto en entornos de escritorio como basados en web.