---
title: Resumen de Funcionalidades
type: docs
weight: 20
url: /es/python-net/features-overview/
keywords:
- funcionalidades
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
description: "Descubra Aspose.Slides para Python a través de .NET: una poderosa API para crear, editar, automatizar y convertir presentaciones PowerPoint y OpenDocument de manera eficiente."
---

## **Plataformas Compatibles**
Las plataformas en las que Aspose.Slides para Python a través de .NET puede usarse son Windows x64 o x86 y una amplia gama de distribuciones Linux con Python 3.5 o superior instalado. Existen requisitos adicionales para la plataforma Linux de destino:
- Bibliotecas de tiempo de ejecución GCC‑6 (o posteriores)
- Dependencias del .NET Core Runtime. No es necesario instalar el .NET Core Runtime en sí.
- Para Python 3.5‑3.7: se necesita la compilación `pymalloc` de Python. La opción de compilación `--with-pymalloc` está habilitada por defecto. Normalmente, la compilación `pymalloc` se indica con el sufijo `m` en el nombre del archivo.
- Biblioteca compartida `libpython`. La opción `--enable-shared` está deshabilitada por defecto; algunas distribuciones de Python no incluyen la biblioteca compartida `libpython`. En algunas plataformas Linux, la biblioteca `libpython` puede instalarse mediante el gestor de paquetes, por ejemplo: `sudo apt-get install libpython3.7`. El problema habitual es que la biblioteca `libpython` se instala en una ubicación distinta a la ubicación estándar del sistema para bibliotecas compartidas. Puede solucionarse ajustando las rutas de biblioteca en las opciones de compilación de Python o creando un enlace simbólico al archivo de la biblioteca `libpython` en la ubicación estándar del sistema. Normalmente, el nombre del archivo es `libpythonX.Ym.so.1.0` para Python 3.5‑3.7, o `libpythonX.Y.so.1.0` para Python 3.8 o superior (por ejemplo: `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

Si necesita soporte para más plataformas, busque los productos “hermanos gemelos” Aspose.Slides para .NET o Aspose.Slides para Java.

## **Formatos de Archivo y Conversiones**
Aspose.Slides para Python a través de .NET admite la mayoría de los formatos de documentos PowerPoint. También le permite exportarlos a los formatos populares que las organizaciones usan y comparten entre sí. Revise los siguientes detalles:

|**Funcionalidad**|**Descripción**|
| :- | :- |
|[Microsoft PowerPoint (PPT)](/slides/es/python-net/ppt-vs-pptx/)|Aspose.Slides para Python a través de .NET ofrece el procesamiento más rápido para este formato de documento de presentación.|
|[Conversión de PPT a PPTX](/slides/es/python-net/convert-ppt-to-pptx/)|Aspose.Slides para Python a través de .NET admite la conversión de PPT a PPTX.|
|[Formato de Documento Portable (PDF)](/slides/es/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)|Puede exportar todos los formatos de archivo compatibles a documentos Adobe Portable Document Format (PDF) con un solo método.|
|[Especificación de Analizador XML (XPS)](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-xps/)|Puede exportar todos los formatos de archivo compatibles a documentos XML Parser Specification (XPS) con un solo método.|
|[Formato de Archivo de Imagen Etiquetado (TIFF)](/slides/es/python-net/convert-powerpoint-to-tiff/)|Puede exportar todos los formatos de archivo de presentación compatibles a Tagged Image File Format (TIFF).|
|[Conversión de PPTX a HTML]((https://docs.aspose.com/slides/python-net/convert-powerpoint-to-html/))|Aspose.Slides para Python a través de .NET admite la conversión de PresentationEx a formato HTML.|

## **Renderizado e Impresión**
Aspose.Slides para Python a través de .NET admite el renderizado de alta fidelidad de diapositivas en documentos de presentación a varios formatos gráficos. Revise los siguientes detalles:

|**Funcionalidad**|**Descripción**|
| :- | :- |
|Formatos de Imagen compatibles con .NET|Con Aspose.Slides para Python a través de .NET, puede renderizar diapositivas y imágenes de diapositivas en todos los formatos gráficos compatibles con .NET, como TIFF, PNG, BMP, JPEG, GIF y metafiles.|
|Formato SVG|Aspose.Slides para Python a través de .NET también proporciona métodos incorporados que le permiten exportar diapositivas de presentación a formatos Scalable Vector Graphics (SVG).|
|Impresión de Presentaciones|Las versiones más recientes de Aspose.Slides para Python a través de .NET ofrecen métodos de impresión integrados con diferentes opciones.|

## **Funciones de Contenido**
Aspose.Slides para Python a través de .NET le permite acceder, modificar o crear casi todos los elementos o contenidos de documentos de presentación. Revise los siguientes detalles:

|**Funcionalidad**|**Descripción**|
| :- | :- |
|Diapositivas Maestras|Las Diapositivas Maestras definen el diseño de las diapositivas normales. Aspose.Slides para Python a través de .NET le permite acceder y modificar las Diapositivas Maestras de los documentos de presentación.|
|Diapositivas Normales|Con Aspose.Slides para Python a través de .NET, puede crear nuevas diapositivas de diferentes tipos; también puede acceder y modificar diapositivas existentes en las presentaciones.|
|Clonado / Copia de Diapositivas|Aspose.Slides para Python a través de .NET incluye métodos que le permiten clonar o copiar diapositivas existentes dentro de una presentación. También puede usar diapositivas copiadas o clonadas de una presentación a otra. Dado que una diapositiva hereda su diseño de la diapositiva maestra, los métodos de clonación incorporados copian automáticamente la maestra al clonar.|
|Gestión de Secciones de Diapositivas|Métodos para organizar diapositivas en diferentes secciones dentro de una presentación.|
|Marcadores de posición y Marcadores de Texto|Puede acceder a los marcadores de posición y marcadores de texto en una diapositiva. Además, puede crear una diapositiva con marcadores de texto desde cero usando el método apropiado.|
|Encabezados y pies de página|Aspose.Slides para Python a través de .NET facilita la gestión de encabezados/pies de página en diapositivas.|
|Notas en Diapositivas|Con Aspose.Slides para Python a través de .NET, puede acceder y modificar notas asociadas a una diapositiva y también añadir notas nuevas.|
|Búsqueda de una Forma|También puede encontrar una forma concreta en una diapositiva usando el texto alternativo asociado a la forma.|
|Fondos|Aspose.Slides para Python a través de .NET le permite trabajar con fondos asociados a una diapositiva maestra o normal en una presentación.|
|Cuadros de Texto|Los cuadros de texto pueden crearse desde cero. Puede acceder a cuadros de texto existentes y modificarlos sin perder el formato original.|
|Formas Rectangulares|Puede crear o modificar formas rectangulares con Aspose.Slides para Python a través de .NET.|
|Formas de Poly Line|Puede crear o modificar formas de línea poligonal con Aspose.Slides para Python a través de .NET.|
|Formas Elípticas|Puede crear o modificar formas elípticas con Aspose.Slides para Python a través de .NET.|
|Formas Agrupadas|Aspose.Slides para Python a través de .NET admite formas agrupadas.|
|Formas Automáticas|Aspose.Slides para Python a través de .NET admite formas automáticas.|
|SmartArt|Aspose.Slides para Python a través de .NET proporciona soporte para formas SmartArt en MS PowerPoint.|
|Gráficos|Aspose.Slides para Python a través de .NET ofrece soporte para gráficos MSO en PowerPoint.|
|Serialización de Formas|Aspose.Slides para Python a través de .NET admite una gran cantidad de formas. Cuando falta soporte para una forma, puede usar un método de serialización que le permite serializar esa forma desde una diapositiva existente y reutilizarla según sus necesidades.|
|Marcos de Imagen|Puede gestionar imágenes dentro de marcos de imagen con Aspose.Slides para Python a través de .NET.|
|Marcos de Audio|Puede enlazar o incrustar archivos de audio en marcos de audio en diapositivas con Aspose.Slides para Python a través de .NET.|
|Marcos de Video|Puede gestionar archivos de video en marcos de video. Aspose.Slides para Python a través de .NET también brinda soporte para videos enlazados e incrustados.|
|Marco OLE|Puede gestionar objetos OLE en marcos OLE con Aspose.Slides para Python a través de .NET.|
|Tablas|Aspose.Slides para Python a través de .NET admite tablas en diapositivas.|
|Controles ActiveX|Soporte para controles ActiveX.|
|Macros VBA|Soporte para la gestión de macros VBA dentro de presentaciones.|
|Marco de Texto|Puede acceder al texto de cualquier forma mediante el marco de texto asociado a esa forma.|
|Escaneo de Texto|Puede escanear texto en una presentación a nivel de presentación o de diapositiva mediante métodos de escaneo incorporados.|
|Animaciones|Puede aplicar animaciones a formas.|
|Presentaciones de Diapositivas|Aspose.Slides para Python a través de .NET admite presentaciones de diapositivas y transiciones entre ellas.|

## **Funciones de Formateo**
Con Aspose.Slides para Python a través de .NET, puede dar formato a textos y formas en las diapositivas de las presentaciones. Revise los siguientes detalles:

|**Funcionalidad**|**Descripción**|
| :- | :- |
|Formato de Texto|<p>En Aspose.Slides para Python a través de .NET, puede gestionar textos a través de los marcos de texto asociados a las formas. Por lo tanto, puede dar formato a los textos usando los párrafos y fragmentos asociados a los marcos de texto. Estos elementos de texto pueden formatearse mediante Aspose.Slides para Python a través de .NET.</p><p>- Tipo de Fuente</p><p>- Tamaño de Fuente</p><p>- Color de Fuente</p><p>- Sombra de Fuente</p><p>- Alineación de Párrafo</p><p>- Viñetas de Párrafo</p><p>- Orientación de Párrafo</p>|
|Formato de Forma|<p>En Aspose.Slides para Python a través de .NET, el elemento básico de una diapositiva es una forma. Puede dar formato a estos elementos de forma con Aspose.Slides para Python a través de .NET:</p><p>- Posición</p><p>- Tamaño</p><p>- Línea</p><p>- Relleno (incluyendo Patrón, Degradado, Sólido)</p><p>- Texto</p><p>- Imagen</p>|

## **Preguntas Frecuentes**

**¿Necesito instalar Microsoft PowerPoint en el servidor/PC para que la biblioteca funcione?**

No. PowerPoint no es necesario; Aspose.Slides es un motor independiente para crear, editar, convertir y renderizar presentaciones.

**¿Cómo funciona la multihilo? ¿Se puede paralelizar el procesamiento?**

Es seguro procesar diferentes documentos en hilos distintos; el mismo [presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) no debe ser usado por [multiple threads](/slides/es/python-net/multithreading/) simultáneamente.

**¿Se admiten contraseñas y cifrado de archivos?**

Sí. [Puede](/slides/es/python-net/password-protected-presentation/) abrir presentaciones cifradas, establecer o eliminar una contraseña de apertura y escritura, y comprobar el estado de protección.

**¿Debo preocuparme por los paquetes de fuentes en contenedores Linux?**

Sí. Se recomienda instalar paquetes de fuentes comunes y/o especificar explícitamente [directorios de fuentes](/slides/es/python-net/custom-font/) en su aplicación para evitar sustituciones inesperadas.

**¿Hay limitaciones en la versión de evaluación?**

En el [modo de evaluación](/slides/es/python-net/licensing/), se añade una marca de agua a la salida y se aplican ciertas limitaciones; una [licencia temporal de 30 días](https://purchase.aspose.com/temporary-license/) está disponible para pruebas con todas las funciones.

**¿Se admite la importación de formatos externos a una presentación (PDF/HTML → PPTX)?**

Sí. Puede añadir [páginas PDF y contenido HTML](/slides/es/python-net/import-presentation/) a una presentación, convirtiéndolos en diapositivas.