---
title: Por qué no Open XML SDK
type: docs
weight: 120
url: /java/why-not-open-xml-sdk/
---

{{% alert color="primary" %}} 

A veces escuchamos esta pregunta:

**¿Por qué deberíamos usar los productos de Aspose en lugar del gratuito Open XML SDK?**

Esta pregunta es fácil de responder: **características y funcionalidad**.

{{% /alert %}} 
## **¿Qué es Open XML SDK?**
Según la [Biblioteca MSDN](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk), Open XML SDK se define como: 

El Open XML SDK 2.0 simplifica la tarea de manipular paquetes Open XML y los elementos del esquema Open XML subyacentes dentro de un paquete. El Open XML SDK 2.0 encapsula muchas tareas comunes que los desarrolladores realizan en paquetes Open XML, para que puedas realizar operaciones complejas con solo unas pocas líneas de código.

Los documentos OOXML son esencialmente archivos XML comprimidos y Open XML SDK es una colección de clases que te permite trabajar con el contenido de los documentos OOXML de una manera fuertemente tipada. Es decir, en lugar de descomprimir un archivo para extraer XML, cargar ese XML en un árbol DOM y trabajar directamente con elementos y atributos XML, Open XML SDK proporciona clases para hacer eso.
## **¿Qué es Aspose.Slides?**
Aspose.Slides es una biblioteca de clases que permite a tu aplicación realizar las siguientes tareas de procesamiento de presentaciones:

- Programación con un modelo de objeto de **Presentación**.
- Conversiones de alta calidad entre todos los formatos de presentación de PowerPoint populares compatibles, incluyendo conversión a PDF, XPS y TIFF.
- Capacidad para generar miniaturas de diapositivas en formatos bien conocidos como PNG, JPEG y BMP junto con exportación de diapositivas a SVG.
- Capacidad para crear presentaciones desde cero o combinando de uno o múltiples documentos.
- Soporte para agregar animaciones, Marcos Ole, Tablas, crear y administrar gráficos.
- Disponibilidad de un control extenso para gestionar el formato de texto en los niveles de TextFrames, Párrafos y Porciones.

Para más detalles sobre las características compatibles, visita [Características de Aspose.Slides](/slides/java/product-overview/).
## **Comparar Open XML SDK y Aspose.Slides**
{{% alert color="primary" %}} 

La siguiente tabla compara las características de Open XML SDK y Aspose.Slides.

{{% /alert %}} 

|**Características o categoría de características**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Formatos de presentaciones compatibles|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Conversión de PPT a PPTX |No|Sí|
|<p>Programación de alto nivel con un modelo de documento objeto (DOM) de presentación:</p><p>- Buscar y reemplazar texto.</p><p>- Montar diapositivas en presentaciones.</p>|No|Sí|
|Programación detallada con un modelo de objeto de documento, acceso a elementos individuales y formato como TextHolders, TextFrames, Párrafos y Porciones.|Sí|Sí|
|Acceso directo y completo de bajo nivel a los elementos y atributos XML subyacentes, como identificadores de relación, identificadores de lista de un documento OOXML.|Sí|No|
|<p>Renderización:</p><p>- Renderizar presentaciones a PDF, notas PDF, imágenes XPS, TIFF.</p><p>- Renderizar miniaturas de diapositivas a PNG, JPEG, BMP, SVG y TIFF.</p><p>- Especificar resolución de imagen, calidad, compresión y otras opciones. </p>|No|Sí |
|Plataformas compatibles|Windows, .NET|Windows, Linux, UNIX, MAC, Java, PHP, Mono|
## **Conclusión**
{{% alert color="primary" %}} 

Open XML SDK y Aspose.Slides no compiten cara a cara porque abordan necesidades y audiencias bastante diferentes. Open XML SDK es una biblioteca de clases para proporcionar una forma fuertemente tipada de trabajar con documentos OOXML. Aspose.Slides es una biblioteca de procesamiento de presentaciones muy útil que proporciona un gran soporte para casi todos los formatos de archivo de Microsoft PowerPoint.

Si todo lo que necesitas hacer es una operación de programación bastante básica en un documento PPTX, entonces Open XML SDK podría ser una opción adecuada. Con Open XML SDK te sentirás bastante cómodo realizando tareas simples como generar un documento PPTX simple o eliminar comentarios, encabezados/pies de página, extraer imágenes u otros. Algunas tareas se pueden lograr con Open XML SDK, pero no se pueden lograr con Aspose.Slides. Por ejemplo, si necesitas acceder directamente a los elementos y atributos XML de un documento OOXML, entonces deberías usar Open XML SDK. Sin embargo, si necesitas realizar operaciones complejas en documentos, como algunas de las siguientes tareas, entonces usar Aspose.Slides es tu mejor opción:

- Soporte para formatos de PowerPoint más antiguos además de PPTX.
- Copiar o clonar formas dentro de las diapositivas de una manera que combine objetos, estilos y otro formato de manera apropiada.
- Reemplazar texto formateado o no formateado.
- Aplicar animaciones y uso de conectores con formas utilizadas.
- Convertir un documento a PDF, TIFF o XPS para que aparezca exactamente como Microsoft PowerPoint lo habría convertido.
- Desarrollar una aplicación .NET o Java tanto en entornos de escritorio como web.

{{% /alert %}}