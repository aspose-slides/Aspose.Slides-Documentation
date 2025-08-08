---
title: Resumen de características
type: docs
weight: 20
url: /es/python-net/features-overview/
keywords:
- características
- plataformas compatibles
- formato de archivo
- conversión
- renderizado
- impresión
- formato
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Descubre Aspose.Slides for Python via .NET: una potente API para crear, editar, automatizar y convertir presentaciones de PowerPoint y OpenDocument de forma eficiente."
---

## **Plataformas soportadas**
Las plataformas Aspose.Slides para Python a través de .NET se pueden utilizar en Windows x64 o x86 y una amplia variedad de distribuciones de Linux con Python 3.5 o posterior instalado. Hay requisitos adicionales para la plataforma Linux de destino:
- Bibliotecas de tiempo de ejecución GCC-6 (o posterior)
- Dependencias de .NET Core Runtime. No es necesario instalar .NET Core Runtime en sí
- Para Python 3.5-3.7: Se necesita la construcción `pymalloc` de Python. La opción de construcción de Python `--with-pymalloc` está habilitada por defecto. Típicamente, la construcción `pymalloc` de Python está marcada con el sufijo `m` en el nombre del archivo.
- Biblioteca compartida de Python `libpython`. La opción de construcción de Python `--enable-shared` está deshabilitada por defecto, algunas distribuciones de Python no contienen la biblioteca compartida `libpython`. Para algunas plataformas de Linux, la biblioteca compartida `libpython` se puede instalar utilizando el gestor de paquetes, por ejemplo: `sudo apt-get install libpython3.7`. El problema común es que la biblioteca `libpython` está instalada en una ubicación diferente de la ubicación estándar del sistema para bibliotecas compartidas. El problema se puede solucionar utilizando las opciones de construcción de Python para establecer rutas de biblioteca alternativas al compilar Python, o solucionándose creando un enlace simbólico al archivo de la biblioteca `libpython` en la ubicación estándar del sistema para bibliotecas compartidas. Típicamente, el nombre del archivo de la biblioteca compartida `libpython` es `libpythonX.Ym.so.1.0` para Python 3.5-3.7, o `libpythonX.Y.so.1.0` para Python 3.8 o posterior (por ejemplo: `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

Si necesitas soporte para más plataformas, busca los productos "hermanos gemelos" Aspose.Slides para .NET o Aspose.Slides para Java.

## **Formatos de archivo y conversiones**
Aspose.Slides para Python a través de .NET soporta la mayoría de los formatos de documentos de PowerPoint. También te permite exportarlos a los formatos populares que las organizaciones utilizan e intercambian entre sí. Consulta estos detalles:

|**Característica**|**Descripción**|
| :- | :- |
|[Microsoft PowerPoint (PPT)](/slides/es/python-net/ppt-vs-pptx/)|Aspose.Slides para Python a través de .NET proporciona el procesamiento más rápido para este formato de documento de presentación.|
|[Conversión de PPT a PPTX](/slides/es/python-net/convert-ppt-to-pptx/)|Aspose.Slides para Python a través de .NET soporta la conversión de PPT a PPTX.|
|[Formato de documento portátil (PDF)](/slides/es/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)|Puedes exportar todos los formatos de archivo soportados a documentos en Formato de Documento Portátil de Adobe (PDF) con un solo método.|
|[Especificación del Analizador XML (XPS)](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-xps/)|Puedes exportar todos los formatos de archivo soportados a documentos en Especificación del Analizador XML (XPS) con un solo método.|
|[Formato de archivo de imagen etiquetada (TIFF)](/slides/es/python-net/convert-powerpoint-to-tiff/)|Puedes exportar todos los formatos de archivo de presentación soportados a Formato de Archivo de Imagen Etiquetada (TIFF).|
|[Conversión de PPTX a HTML](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-html/)|Aspose.Slides para Python a través de .NET soporta la conversión de PresentationEx a formato HTML.|

## **Renderización e impresión**
Aspose.Slides para Python a través de .NET soporta la renderización de alta fidelidad de diapositivas en los documentos de presentación a varios formatos gráficos. Consulta estos detalles:

|**Característica**|**Descripción**|
| :- | :- |
|Formatos de imagen soportados por .NET|Con Aspose.Slides para Python a través de .NET, puedes renderizar diapositivas de presentación e imágenes en las diapositivas a todos los formatos gráficos soportados por .NET, como TIFF, PNG, BMP, JPEG, GIF y metafiles.|
|Formato SVG|Aspose.Slides para Python a través de .NET también proporciona métodos integrados que te permiten exportar diapositivas de presentación a formatos de Gráficos Vectoriales Escalables (SVG).|
|Impresión de Presentaciones|Las versiones más recientes de Aspose.Slides para Python a través de .NET proporcionan métodos de impresión integrados con diferentes opciones.|

## **Características del contenido**
Aspose.Slides para Python a través de .NET te permite acceder, modificar o crear casi todos los elementos o contenidos de los documentos de presentación. Consulta estos detalles:

|**Característica**|**Descripción**|
| :- | :- |
|Diapositivas maestras|Las diapositivas maestras definen el diseño de las diapositivas normales. Aspose.Slides para Python a través de .NET te permite acceder y modificar las Diapositivas Maestras de los documentos de presentación.|
|Diapositivas normales|Con Aspose.Slides para Python a través de .NET, puedes crear nuevas diapositivas de diferentes tipos; también puedes acceder y modificar diapositivas existentes en las presentaciones.|
|Clonación / Copiado de Diapositivas|Hay métodos integrados proporcionados por Aspose.Slides para Python a través de .NET que te permiten clonar o copiar diapositivas existentes dentro de una presentación. También puedes usar diapositivas copiadas y clonadas de una presentación a otra. Dado que una diapositiva hereda su diseño de la diapositiva maestra, los métodos integrados de clonación copian automáticamente la maestra al clonar.|
|Gestión de secciones de Diapositivas|Métodos para organizar diapositivas en diferentes secciones dentro de una presentación.|
|Marcadores de posición y Contenedores de texto|Puedes acceder a los marcadores de posición y los contenedores de texto en una diapositiva. Además, puedes crear una diapositiva con contenedores de texto desde cero utilizando el método apropiado.|
|Encabezados y pies de página|Aspose.Slides para Python a través de .NET facilita el manejo de encabezados/pies de página en las diapositivas.|
|Notas en Diapositivas|Con Aspose.Slides para Python a través de .NET, puedes acceder y modificar notas asociadas con una diapositiva y también agregar nuevas notas.|
|Encontrar una Forma|También puedes encontrar una forma particular de una diapositiva usando el texto alternativo asociado con la forma.|
|Fondos|Aspose.Slides para Python a través de .NET te permite trabajar con fondos asociados con una diapositiva maestra o normal en una presentación.|
|Cuadros de texto|Los cuadros de texto pueden ser creados desde cero. Puedes acceder a cuadros de texto existentes. También puedes modificar sus textos sin perder el formato de texto original.|
|Formas Rectangulares|Puedes crear o modificar formas rectangulares con Aspose.Slides para Python a través de .NET.|
|Formas de Polilinea|Puedes crear o modificar formas de polilinea con Aspose.Slides para Python a través de .NET.|
|Formas Elípticas|Puedes crear o modificar formas elípticas con Aspose.Slides para Python a través de .NET.|
|Formas Agrupadas|Aspose.Slides para Python a través de .NET soporta formas agrupadas.|
|Formas Automáticas|Aspose.Slides para Python a través de .NET soporta formas automáticas.|
|SmartArt|Aspose.Slides para Python a través de .NET proporciona soporte para formas SmartArt en MS PowerPoint.|
|Gráficos|Aspose.Slides para Python a través de .NET proporciona soporte para gráficos MSO en PowerPoint.|
|Serialización de Formas|Aspose.Slides para Python a través de .NET soporta un gran número de formas. Cuando Aspose.Slides para Python a través de .NET no tenga soporte para una forma, puedes usar un método de serialización a través del cual puedes serializar esa forma desde una diapositiva existente. De esta manera, puedes usar la forma posteriormente según tus requisitos.|
|Marcos de Imagen|Puedes gestionar imágenes en marcos de imagen con Aspose.Slides para Python a través de .NET.|
|Marcos de Audio|Puedes vincular o incrustar archivos de audio en marcos de audio en las diapositivas con Aspose.Slides para Python a través de .NET.|
|Marcos de Video|Puedes manejar archivos de video en marcos de video. Aspose.Slides para Python a través de .NET también proporciona soporte para videos vinculados e incrustados.|
|Marco OLE|Puedes gestionar objetos OLE en marcos OLE con Aspose.Slides para Python a través de .NET.|
|Tablas|Aspose.Slides para Python a través de .NET soporta tablas en las diapositivas.|
|Controles ActiveX|Soporte para controles ActiveX.|
|Macros VBA|Soporte para gestionar macros VBA dentro de las presentaciones.|
|Cuadro de Texto|Puedes acceder al texto con cualquier forma a través del cuadro de texto asociado a esa forma.|
|Escaneo de Texto|Puedes escanear texto en una presentación a nivel de presentación o de diapositiva a través de métodos de escaneo integrados.|
|Animaciones|Puedes aplicar animaciones a las formas.|
|Presentaciones Diapositivas|Aspose.Slides para Python a través de .NET soporta presentaciones de diapositivas y transiciones de diapositivas.|

## **Características de formateo**
Con Aspose.Slides para Python a través de .NET, puedes formatear textos y formas en las diapositivas de presentaciones. Consulta estos detalles:

|**Característica**|**Descripción**|
| :- | :- |
|Formateo de Texto|<p>En Aspose.Slides para Python a través de .NET, puedes gestionar textos a través de los cuadros de texto asociados con las formas. Por lo tanto, puedes formatear textos usando los párrafos y porciones asociadas con los cuadros de texto. Estos elementos de texto se pueden formatear a través de Aspose.Slides para Python a través de .NET.</p><p>- Tipo de Fuente</p><p>- Tamaño de Fuente</p><p>- Color de Fuente</p><p>- Sombras de Fuente</p><p>- Alineación de Párrafo</p><p>- Viñetas de Párrafo</p><p>- Orientación de Párrafo</p>|
|Formateo de Forma|<p>En Aspose.Slides para Python a través de .NET, el elemento básico de una diapositiva es una forma. Puedes formatear estos elementos de forma con Aspose.Slides para Python a través de .NET:</p><p>- Posición</p><p>- Tamaño</p><p>- Línea</p><p>- Relleno (incluyendo Patrón, Gradiente, Sólido)</p><p>- Texto</p><p>- Imagen</p>|