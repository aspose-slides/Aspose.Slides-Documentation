---
title: Por qué no Open XML SDK
type: docs
weight: 100
url: /cpp/why-not-open-xml-sdk/
---

## **¿Qué es Open XML SDK?**
A veces escuchamos esta pregunta: ¿Por qué deberíamos usar los productos de Aspose en lugar del gratuito Open XML SDK? Esta pregunta es fácil de responder: características y funcionalidad. Según la [MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk), Open XML SDK se define como: El Open XML SDK 2.0 simplifica la tarea de manipular paquetes Open XML y los elementos de esquema Open XML subyacentes dentro de un paquete. El Open XML SDK 2.0 encapsula muchas tareas comunes que los desarrolladores realizan en paquetes Open XML, para que puedas realizar operaciones complejas con solo unas pocas líneas de código. Los documentos OOXML son esencialmente archivos XML comprimidos y Open XML SDK es una colección de clases que te permite trabajar con el contenido de los documentos OOXML de una manera fuertemente tipada. Es decir, en lugar de descomprimir un archivo para extraer XML, cargar ese XML en un árbol DOM y trabajar directamente con elementos y atributos XML, Open XML SDK proporciona clases para hacerlo.

## **¿Qué es Aspose.Slides?**
Aspose.Slides es una biblioteca de clases que permite a tu aplicación realizar las siguientes tareas de procesamiento de presentaciones:

- Programación con un modelo de objeto de **Presentación**.
- Conversiones de alta calidad entre todos los formatos de presentación de PowerPoint compatibles y populares, incluyendo la conversión a PDF y XPS.
- Capacidad para generar miniaturas de diapositivas en formatos bien conocidos como PNG, JPEG y BMP junto con la exportación de diapositivas a SVG.
- Capacidad para construir presentaciones desde cero o combinando de uno o múltiples documentos.
- Soporte para agregar animaciones, marcos Ole, tablas, crear y gestionar gráficos.
- Disponibilidad de un control extenso para gestionar el formato de texto en niveles de TextFrames, Párrafos y Porciones.
  Para más detalles sobre las características soportadas, por favor visita [Características de Aspose.Slides](/slides/net/product-overview/).

## **Comparar Open XML SDK y Aspose.Slides**
La siguiente tabla compara las características de Open XML SDK y Aspose.Slides.

|**Característica o Categoría de Característica**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Formatos de presentaciones soportados|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Conversión de PPT a PPTX|No|Sí|
|<p>Programación de alto nivel con un modelo de objeto de documento de presentación (DOM):</p><p>- Buscar y reemplazar texto.</p><p>- Ensamblar diapositivas en presentaciones.</p>|No|Sí|
|Programación detallada con un modelo de objeto de documento, acceso a elementos individuales y formato como TextHolders, TextFrames, Párrafos y Porciones.|Sí|Sí|
|Acceso directo y completo de bajo nivel a los elementos y atributos XML subyacentes, como identificadores de relaciones, identificadores de listas de un documento OOXML.|Sí|No|
|<p>Renderizado:</p><p>- Renderizar presentaciones a PDF, notas PDF, XPS, imágenes TIFF.</p><p>- Renderizar miniaturas de diapositivas a PNG, JPEG, BMP, SVG y TIFF.</p><p>- Especificar resolución de imagen, calidad, compresión y otras opciones.</p>|No|Sí|

## **Conclusión**
Open XML SDK y Aspose.Slides no compiten directamente porque abordan necesidades y audiencias bastante diferentes. Open XML SDK es una biblioteca de clases que proporciona una manera fuertemente tipada de trabajar con documentos OOXML. Aspose.Slides es una biblioteca de procesamiento de presentaciones muy útil que proporciona un gran soporte para casi todos los formatos de archivos de Microsoft PowerPoint. Si todo lo que necesitas hacer es una operación de programación bastante básica en un documento PPTX, entonces Open XML SDK podría ser una opción adecuada. Con Open XML SDK, te sentirás bastante cómodo realizando tareas simples como generar un documento PPTX simple o eliminar comentarios, encabezados/pies de página, extraer imágenes u otros. Algunas tareas se pueden lograr con Open XML SDK, pero no se pueden lograr con Aspose.Slides. Por ejemplo, si necesitas acceder directamente a los elementos y atributos XML de un documento OOXML, entonces debes usar Open XML SDK. Sin embargo, si necesitas realizar operaciones complejas en documentos, como algunas de las siguientes tareas, entonces usar Aspose.Slides es tu mejor opción:

- Soportar formatos de PowerPoint más antiguos además de PPTX.
- Copiar o clonar formas dentro de diapositivas de una manera que combine objetos, estilos y otros formatos de manera apropiada.
- Reemplazar texto formateado o no formateado.
- Aplicar animaciones y usar conectores con las formas utilizadas.
- Convertir un documento a PDF o XPS para que aparezca exactamente como lo habría convertido Microsoft PowerPoint.
- Desarrollar una aplicación C++ en entornos de escritorio y basados en consola.