---
title: "¿Por qué no Open XML SDK?"
type: docs
weight: 120
url: /es/php-java/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- comparación
- modelo de objeto de presentación
- conversión de alta calidad
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Descubre por qué Aspose.Slides es una mejor opción que el SDK gratuito Open XML: compara características, conversión sin automatización y amplio soporte para PPT, PPTX y ODP."
---

{{% alert color="primary" %}} 

A veces escuchamos esta pregunta:

**¿Por qué deberíamos usar los productos Aspose en lugar del SDK gratuito Open XML?**

Esta pregunta es fácil de responder: **características y funcionalidad**.

{{% /alert %}} 
## **¿Qué es Open XML SDK?**
Según la [Biblioteca MSDN](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk), Open XML SDK se define como: 

El Open XML SDK 2.0 simplifica la tarea de manipular paquetes Open XML y los elementos del esquema Open XML subyacentes dentro de un paquete. El Open XML SDK 2.0 encapsula muchas tareas comunes que los desarrolladores realizan en paquetes Open 

XML, de modo que puedes ejecutar operaciones complejas con solo unas pocas líneas de código.

Los documentos OOXML son esencialmente archivos XML comprimidos y Open XML SDK es una colección de clases que permite trabajar con el contenido de los documentos OOXML de forma tipada. Es decir, en lugar de descomprimir un archivo para 

extraer XML, cargar ese XML en un árbol DOM y trabajar directamente con los elementos y atributos XML, Open XML SDK proporciona clases para hacerlo.
## **¿Qué es Aspose.Slides?**
Aspose.Slides es una biblioteca de clases que permite a tu aplicación realizar las siguientes tareas de procesamiento de presentaciones:

- Programar con un modelo de objetos **Presentation**.
- Conversiones de alta calidad entre todos los formatos de presentación de PowerPoint compatibles, incluida la conversión a PDF, XPS y TIFF.
- Capacidad para generar miniaturas de diapositivas en formatos conocidos como PNG, JPEG y BMP, junto con la exportación de diapositivas a SVG.
- Capacidad para crear presentaciones desde cero o combinando uno o varios documentos.
- Soporte para añadir animaciones, Ole Frames, tablas, crear y gestionar gráficos.
- Disponibilidad de un control exhaustivo para gestionar el formato de texto en niveles de TextFrames, Paragraphs y Portions.

Para obtener más detalles sobre las características admitidas, visita [Características de Aspose.Slides](/slides/es/php-java/product-overview/).
## **Comparar Open XML SDK con Aspose.Slides**
{{% alert color="primary" %}} 

La tabla siguiente compara las características de Open XML SDK y Aspose.Slides.

{{% /alert %}} 

|**Característica o categoría de característica**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Formatos de presentación admitidos|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Conversión de PPT a PPTX|No|Sí|
|<p>Programación de alto nivel con un modelo de objetos Document Object Model (DOM) de presentación:</p><p>- Buscar y reemplazar texto.</p><p>- Ensamblar diapositivas en presentaciones.</p>|No|Sí|
|Programación detallada con un modelo de objetos de documento, acceso a elementos individuales y formato como TextHolders, TextFrames, Paragraphs y Portions.|Sí|Sí|
|Acceso directo y completo de bajo nivel a los elementos y atributos XML subyacentes, como identificadores de relaciones, identificadores de lista de un documento OOXML.|Sí|No|
|<p>Renderizado:</p><p>- Renderizar presentaciones a PDF, PDF Notes, XPS, imágenes TIFF.</p><p>- Renderizar miniaturas de diapositivas a PNG, JPEG, BMP, SVG y TIFF.</p><p>- Especificar resolución de imagen, calidad, compresión y otras opciones. </p>|No|Sí |
|Plataformas admitidas|Windows, .NET|Windows, Linux,UNIX, MAC, Java, PHP, Mono|
## **Conclusión**
{{% alert color="primary" %}} 

Open XML SDK y Aspose.Slides no compiten directamente porque cubren necesidades y audiencias bastante diferentes. Open XML SDK es una biblioteca de clases que proporciona una forma tipada de trabajar con documentos OOXML. Aspose.Slides es una biblioteca de procesamiento de presentaciones muy útil que ofrece un gran soporte para casi todos los formatos de archivo de Microsoft PowerPoint.

Si todo lo que necesitas es una operación de programación bastante básica sobre un documento PPTX, entonces Open XML SDK podría ser una opción adecuada. Con Open XML SDK te resultará cómodo realizar tareas simples como generar un documento PPTX sencillo o eliminar comentarios, encabezados/pies de página, extraer imágenes u otras. Algunas tareas pueden lograrse con Open XML SDK, pero no pueden lograrse con Aspose.Slides. Por ejemplo, si necesitas acceder directamente a los elementos y atributos XML de un documento OOXML, deberías usar Open XML SDK. Sin embargo, si necesitas ejecutar operaciones complejas sobre documentos, como algunas de las siguientes tareas, entonces usar Aspose.Slides es la mejor opción:

- Soportar formatos antiguos de PowerPoint además de PPTX.
- Copiar o clonar formas dentro de diapositivas de manera que combine objetos, estilos y otro formato de forma adecuada.
- Reemplazar texto con formato o sin formato.
- Aplicar animaciones y usar conectores con las formas utilizadas.
- Convertir un documento a PDF, TIFF o XPS para que aparezca exactamente como lo haría Microsoft PowerPoint.
- Desarrollar una aplicación .NET o Java tanto en entornos de escritorio como basados en web.

{{% /alert %}}