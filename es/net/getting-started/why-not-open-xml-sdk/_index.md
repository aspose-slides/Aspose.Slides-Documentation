---
title: Por qué no Open XML SDK
type: docs
weight: 50
url: /net/why-not-open-xml-sdk/
---

## **¿Qué es Open XML SDK?**
A veces, recibimos esta pregunta: *¿Por qué deberíamos usar los productos de Aspose en lugar del gratuito Open XML SDK?*

Encontramos fácil responder a esta pregunta en términos de características y funcionalidades.

Según la [Biblioteca MSDN](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk), Open XML SDK se define de esta manera:

> "El Open XML SDK 2.0 simplifica la tarea de manipular paquetes Open XML y los elementos de esquema Open XML subyacentes dentro de un paquete. El Open XML SDK 2.0 encapsula muchas tareas comunes que los desarrolladores realizan en paquetes Open XML, de modo que puede realizar operaciones complejas con solo unas pocas líneas de código. Los documentos OOXML son esencialmente archivos XML comprimidos y Open XML SDK es una colección de clases que le permite trabajar con el contenido de documentos OOXML de una manera fuertemente tipada. Es decir, en lugar de descomprimir un archivo para extraer XML, cargar ese XML en un árbol DOM y trabajar directamente con elementos y atributos XML, Open XML SDK proporciona clases para hacer eso."

## **¿Qué es Aspose.Slides?**
Aspose.Slides es una biblioteca de clases que permite a las aplicaciones realizar estas tareas de procesamiento de presentaciones:

- Programación con un modelo de objeto de presentación.

- Conversiones de alta calidad que involucran todos los formatos de presentación de PowerPoint populares admitidos, incluyendo conversión a PDF, XPS, TIFF e impresión.

- Generación de miniaturas de diapositivas en formatos conocidos como PNG, JPEG y BMP junto con la exportación de diapositivas a SVG.

- Creación de presentaciones desde cero o combinando elementos de uno o varios documentos.

- Adición de animaciones, marcos OLE, tablas, creación y gestión de gráficos.

- Control (control extenso) y gestión del formato de texto en niveles de TextFrames, Párrafos y Porciones.

  Para más detalles sobre las características disponibles, consulte la página de [Características de Aspose.Slides](/slides/net/product-overview/).

## **Comparando Open XML SDK con Aspose.Slides**
Esta tabla compara las capacidades y características de Open XML SDK con Aspose.Slides.

|**Característica o categoría de características**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Formatos de presentaciones admitidos|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Conversión de PPT a PPTX |No|Sí|
|<p>Programación de alto nivel con un modelo de objeto de documento de presentación (DOM): </p><p>- Buscar y reemplazar textos.</p><p>- Ensamblar diapositivas en presentaciones.</p>|No|Sí|
|Programación detallada con un modelo de objeto de documento; acceso a elementos individuales y formato como TextHolders, TextFrames, Párrafos y Porciones.|Sí|Sí|
|Acceso directo y completo de bajo nivel a los elementos y atributos XML subyacentes, como identificadores de relación, identificadores de lista de un documento OOXML.|Sí|No|
|<p>Renderización e impresión:</p><p>- Renderizar presentaciones a PDF, PDF Notes, imágenes XPS, TIFF.</p><p>- Renderizar miniaturas de diapositivas a PNG, JPEG, BMP, SVG y TIFF.</p><p>- Especificar resolución de imagen, calidad, compresión y otras opciones.</p><p>- Imprimir presentaciones usando la infraestructura de impresión de .NET. El componente tiene un método de impresión integrado para imprimir las presentaciones como se muestra en la vista previa de impresión de MS PowerPoint.</p>|No|Sí|
|Plataformas admitidas|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **Conclusión**
Open XML SDK y Aspose.Slides no compiten directamente porque abordan necesidades considerablemente diferentes y están dirigidos a diferentes audiencias.

{{% alert color="primary" %}} 

Open XML SDK es una biblioteca de clases que proporciona una forma fuertemente tipada de trabajar con documentos OOXML, mientras que Aspose.Slides es una biblioteca de procesamiento de presentaciones increíblemente útil que proporciona un gran soporte para casi todos los formatos de archivo de Microsoft PowerPoint. 

{{% /alert %}} 

Si su flujo de trabajo es una operación de programación básica en un documento PPTX, entonces Open XML SDK puede ser una buena opción. Con Open XML SDK, debería sentirse cómodo realizando tareas simples como generar un documento PPTX simple o eliminar comentarios, encabezados/pies de página, extraer imágenes u otros. Ciertas tareas se pueden realizar con Open XML SDK pero no se pueden realizar con Aspose.Slides. Por ejemplo, si necesita acceder directamente a los elementos XML y atributos de un documento OOXML, entonces debe usar Open XML SDK.

Si necesita realizar tareas complejas en documentos—como las tareas en la lista a continuación—entonces Aspose.Slides es su mejor opción. 

- Operaciones que involucran formatos de PowerPoint más antiguos (y PPTX también).
- Copiar o clonar formas dentro de las diapositivas de manera que combine objetos, estilos y otros elementos de formato de manera apropiada.
- Reemplazar texto formateado o no formateado.
- Aplicar animaciones y usar conectores con formas.
- Convertir un documento a PDF, TIFF o XPS para que parezca que Microsoft PowerPoint realizó la conversión.
- Desarrollar una aplicación .NET o Java en entornos de escritorio y basados en la web.