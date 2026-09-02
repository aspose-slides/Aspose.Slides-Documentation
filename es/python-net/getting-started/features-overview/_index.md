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
- formateo
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Descubra Aspose.Slides for Python vía .NET: una API potente para crear, editar, automatizar y convertir presentaciones PowerPoint y OpenDocument de manera eficiente."
---
## **Plataformas compatibles**
Las plataformas en las que se puede usar Aspose.Slides for Python vía .NET son Windows x64 o x86 y una amplia gama de distribuciones Linux con Python 3.5 o posterior instalado. Hay requerimientos adicionales para la plataforma Linux de destino:
- Bibliotecas de tiempo de ejecución GCC‑6 (o posteriores)
- Dependencias del .NET Core Runtime. No es necesario instalar el .NET Core Runtime en sí
- Para Python 3.5‑3.7: se necesita la compilación `pymalloc` de Python. La opción de compilación `--with-pymalloc` está activada por defecto. Normalmente, la compilación `pymalloc` de Python lleva el sufijo `m` en el nombre del archivo.
- Biblioteca compartida `libpython`. La opción de compilación `--enable-shared` está desactivada por defecto; algunas distribuciones de Python no contienen la biblioteca compartida `libpython`. En algunas plataformas Linux, la biblioteca compartida `libpython` puede instalarse mediante el gestor de paquetes, por ejemplo: `sudo apt-get install libpython3.7`. El problema habitual es que la biblioteca `libpython` se instala en una ubicación diferente a la estándar del sistema para bibliotecas compartidas. Puede solucionarse usando las opciones de compilación de Python para establecer rutas de biblioteca alternativas al compilar Python, o creando un enlace simbólico al archivo de la biblioteca `libpython` en la ubicación estándar del sistema. Normalmente, el nombre del archivo de la biblioteca compartida `libpython` es `libpythonX.Ym.so.1.0` para Python 3.5‑3.7, o `libpythonX.Y.so.1.0` para Python 3.8 o posterior (por ejemplo: `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

Si necesita compatibilidad con más plataformas, busque los productos “hermanos gemelos” Aspose.Slides for .NET o Aspose.Slides for Java.

## **Formatos de archivo y conversiones**
Aspose.Slides for Python vía .NET admite la mayoría de los formatos de documentos PowerPoint. También permite exportarlos a los formatos populares que las organizaciones usan y comparten ampliamente. Consulte estos detalles:

|**Funcionalidad**|**Descripción**|
| :- | :- |
|[Microsoft PowerPoint (PPT)](/slides/es/python-net/ppt-vs-pptx/)|Aspose.Slides for Python vía .NET proporciona el procesamiento más rápido para este formato de documento de presentación.|
|[Conversión de PPT a PPTX](/slides/es/python-net/convert-ppt-to-pptx/)|Aspose.Slides for Python vía .NET admite la conversión de PPT a PPTX.|
|[Portable Document Format (PDF)](/slides/es/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)|Puede exportar todos los formatos de archivo compatibles a documentos Adobe Portable Document Format (PDF) con un solo método.|
|[XML Paper Specification (XPS)](https://docs.aspose.com/slides/es/python-net/convert-powerpoint-to-xps/)|Puede exportar todos los formatos de archivo compatibles a documentos XML Paper Specification (XPS) con un solo método.|
|[Tagged Image File Format (TIFF)](/slides/es/python-net/convert-powerpoint-to-tiff/)|Puede exportar todos los formatos de archivo de presentación compatibles a Tagged Image File Format (TIFF).|
|[Conversión de PPTX a HTML](https://docs.aspose.com/slides/es/python-net/convert-powerpoint-to-html/)|Aspose.Slides for Python vía .NET admite la conversión de PresentationEx a formato HTML.|

## **Renderizado de presentaciones**
Aspose.Slides for Python vía .NET admite el renderizado de alta fidelidad de diapositivas en los documentos de presentación a varios formatos gráficos. Consulte estos detalles:

|**Funcionalidad**|**Descripción**|
| :- | :- |
|Formatos de imagen compatibles con .NET|Con Aspose.Slides for Python vía .NET, puede renderizar diapositivas y imágenes de diapositivas en todos los formatos gráficos compatibles con .NET, como TIFF, PNG, BMP, JPEG, GIF y metarchivos.|
|Formato SVG|Aspose.Slides for Python vía .NET también proporciona métodos integrados que le permiten exportar diapositivas de presentación a formatos Scalable Vector Graphics (SVG).|

## **Características del contenido**
Aspose.Slides for Python vía .NET le permite acceder, modificar o crear casi todos los elementos o contenidos de los documentos de presentación. Consulte estos detalles:

|**Funcionalidad**|**Descripción**|
| :- | :- |
|Diapositivas maestras|Las diapositivas maestras definen el diseño de las diapositivas normales. Aspose.Slides for Python vía .NET le permite acceder y modificar las diapositivas maestras de los documentos de presentación.|
|Diapositivas normales|Con Aspose.Slides for Python vía .NET, puede crear nuevas diapositivas de diferentes tipos; también puede acceder y modificar diapositivas existentes en las presentaciones.|
|Clonado / Copia de diapositivas|Existen métodos integrados provistos por Aspose.Slides for Python vía .NET que le permiten clonar o copiar diapositivas existentes dentro de una presentación. También puede usar diapositivas copiadas y clonadas de una presentación a otra. Dado que una diapositiva hereda su diseño de la diapositiva maestra, los métodos de clonación incorporados copian automáticamente la maestra al clonar.|
|Gestión de secciones de diapositivas|Métodos para organizar diapositivas en diferentes secciones dentro de una presentación.|
|Marcadores de posición y marcadores de texto|Puede acceder a los marcadores de posición y a los marcadores de texto en una diapositiva. Además, puede crear una diapositiva con marcadores de texto desde cero usando el método correspondiente.|
|Encabezados y pies de página|Aspose.Slides for Python vía .NET facilita el manejo de encabezados/pies de página en las diapositivas.|
|Notas en diapositivas|Con Aspose.Slides for Python vía .NET, puede acceder y modificar notas asociadas a una diapositiva y también añadir nuevas notas.|
|Búsqueda de una forma|También puede encontrar una forma concreta en una diapositiva usando el texto alternativo asociado a la forma.|
|Fondos|Aspose.Slides for Python vía .NET le permite trabajar con fondos asociados a una diapositiva maestra o normal en una presentación.|
|Cuadros de texto|Los cuadros de texto pueden crearse desde cero. Puede acceder a cuadros de texto existentes. También puede modificar sus textos sin perder el formato original del texto.|
|Formas rectangulares|Puede crear o modificar formas rectangulares con Aspose.Slides for Python vía .NET.|
|Formas de polilínea|Puede crear o modificar formas de polilínea con Aspose.Slides for Python vía .NET.|
|Formas elípticas|Puede crear o modificar formas elípticas con Aspose.Slides for Python vía .NET.|
|Formas agrupadas|Aspose.Slides for Python vía .NET admite formas agrupadas|
|Formas automáticas|Aspose.Slides for Python vía .NET admite formas automáticas|
|SmartArt|Aspose.Slides for Python vía .NET proporciona soporte para formas SmartArt en MS PowerPoint|
|Gráficos|Aspose.Slides for Python vía .NET proporciona soporte para gráficos MSO en PowerPoint|
|Serialización de formas|Aspose.Slides for Python vía .NET admite una gran cantidad de formas. Cuando Aspose.Slides for Python vía .NET no soporta una forma, puede usar un método de serialización mediante el cual puede serializar esa forma a partir de una diapositiva existente. De este modo, puede reutilizar la forma según sus requerimientos.|
|Marcos de imagen|Puede gestionar imágenes en marcos de imagen con Aspose.Slides for Python vía .NET.|
|Marcos de audio|Puede enlazar o incrustar archivos de audio en marcos de audio en las diapositivas con Aspose.Slides for Python vía .NET.|
|Marcos de vídeo|Puede gestionar archivos de vídeo en marcos de vídeo. Aspose.Slides for Python vía .NET también proporciona soporte para vídeos enlazados e incrustados.|
|Marco OLE|Puede gestionar objetos OLE en marcos OLE con Aspose.Slides for Python vía .NET.|
|Tablas|Aspose.Slides for Python vía .NET admite tablas en diapositivas.|
|Controles ActiveX|Soporte para controles ActiveX|
|Macros VBA|Soporte para gestionar macros VBA dentro de presentaciones.|
|Marco de texto|Puede acceder al texto de cualquier forma a través del marco de texto asociado a esa forma.|
|Escaneo de texto|Puede escanear texto en una presentación a nivel de presentación o de diapositiva mediante métodos de escaneo integrados.|
|Animaciones|Puede aplicar animaciones a las formas.|
|Presentaciones de diapositivas|Aspose.Slides for Python vía .NET admite presentaciones de diapositivas y transiciones entre diapositivas.|

## **Características de formato**
Con Aspose.Slides for Python vía .NET, puede dar formato a textos y formas en las diapositivas de las presentaciones. Consulte estos detalles:

|**Funcionalidad**|**Descripción**|
| :- | :- |
|Formato de texto|<p>En Aspose.Slides for Python vía .NET, puede gestionar textos a través de los marcos de texto asociados a las formas. Por lo tanto, puede dar formato a los textos usando los párrafos y fragmentos asociados a los marcos de texto. Estos elementos de texto pueden formatearse mediante Aspose.Slides for Python vía .NET.</p><p>- Tipo de fuente</p><p>- Tamaño de fuente</p><p>- Color de fuente</p><p>- Sombras de fuente</p><p>- Alineación de párrafo</p><p>- Viñetas de párrafo</p><p>- Orientación de párrafo</p>|
|Formato de forma|<p>En Aspose.Slides for Python vía .NET, el elemento básico de una diapositiva es una forma. Puede dar formato a estos elementos de forma con Aspose.Slides for Python vía .NET:</p><p>- Posición</p><p>- Tamaño</p><p>- Línea</p><p>- Relleno (incluyendo Patrón, Degradado, Sólido)</p><p>- Texto</p><p>- Imagen</p>|

## **FAQ**

### ¿Necesito instalar Microsoft PowerPoint en el servidor/PC para que la biblioteca funcione?

No. PowerPoint no es necesario; Aspose.Slides es un motor independiente para crear, editar, convertir y renderizar presentaciones.

### ¿Cómo funciona la multihilación? ¿Se puede paralelizar el procesamiento?

Es seguro procesar documentos diferentes en hilos distintos; el mismo [presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) no debe ser usado por [multiple threads](/slides/es/python-net/multithreading/) al mismo tiempo.

### ¿Se admiten contraseñas y cifrado de archivos?

Sí. [You can](/slides/es/python-net/password-protected-presentation/) abrir presentaciones cifradas, establecer o eliminar una contraseña de apertura y escritura, y comprobar el estado de protección.

### ¿Debo preocuparme por los paquetes de fuentes en contenedores Linux?

Sí. Se recomienda instalar paquetes de fuentes comunes y/o especificar explícitamente [font directories](/slides/es/python-net/custom-font/) en su aplicación para evitar sustituciones inesperadas.

### ¿Hay limitaciones en la versión de evaluación?

En el [evaluation mode](/slides/es/python-net/licensing/), se añade una marca de agua a la salida y se aplican ciertas limitaciones; una [licencia temporal de 30 días](https://purchase.aspose.com/temporary-license/) está disponible para pruebas con todas las funciones.

### ¿Se admite la importación de formatos externos a una presentación (PDF/HTML → PPTX)?

Sí. Puede añadir [PDF pages and HTML content](/slides/es/python-net/import-presentation/) a una presentación, convirtiéndolos en diapositivas.