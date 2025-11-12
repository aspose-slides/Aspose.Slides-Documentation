---
title: Visión general de características
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
description: "Descubra Aspose.Slides para Python a través de .NET: una API potente para crear, editar, automatizar y convertir presentaciones PowerPoint y OpenDocument de manera eficiente."
---

## **Plataformas compatibles**
Las plataformas en las que Aspose.Slides para Python a través de .NET se puede usar son Windows x64 o x86 y una amplia gama de distribuciones Linux con Python 3.5 o posterior instalado. Existen requisitos adicionales para la plataforma Linux objetivo:

- Bibliotecas en tiempo de ejecución GCC-6 (o posteriores)
- Dependencias del Runtime de .NET Core. Instalar el Runtime de .NET Core en sí NO es necesario
- Para Python 3.5‑3.7: se necesita la compilación `pymalloc` de Python. La opción de compilación `--with-pymalloc` de Python está habilitada por defecto. Normalmente, la compilación `pymalloc` de Python lleva el sufijo `m` en el nombre del archivo.
- `libpython` biblioteca compartida de Python. La opción de compilación `--enable-shared` de Python está deshabilitada por defecto; algunas distribuciones de Python no incluyen la biblioteca compartida `libpython`. En algunas plataformas Linux, la biblioteca compartida `libpython` puede instalarse mediante el gestor de paquetes, por ejemplo: `sudo apt-get install libpython3.7`. El problema habitual es que la biblioteca `libpython` se instala en una ubicación diferente a la ubicación estándar del sistema para bibliotecas compartidas. El problema puede solucionarse usando las opciones de compilación de Python para establecer rutas de biblioteca alternativas al compilar Python, o creando un enlace simbólico al archivo de la biblioteca `libpython` en la ubicación estándar del sistema para bibliotecas compartidas. Normalmente, el nombre del archivo de la biblioteca compartida `libpython` es `libpythonX.Ym.so.1.0` para Python 3.5‑3.7, o `libpythonX.Y.so.1.0` para Python 3.8 o posterior (por ejemplo: `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

Si necesita soporte para más plataformas, busque los productos "hermanos gemelos" Aspose.Slides para .NET o Aspose.Slides para Java.

## **Formatos de archivo y conversiones**
Aspose.Slides para Python a través de .NET admite la mayoría de los formatos de documentos PowerPoint. También le permite exportarlos a los formatos populares que las organizaciones usan y comparten ampliamente. Repase estos detalles:

|**Característica**|**Descripción**|
| :- | :- |
|[Microsoft PowerPoint (PPT)](/slides/es/python-net/ppt-vs-pptx/)|Aspose.Slides para Python a través de .NET ofrece el procesamiento más rápido para este formato de documento de presentación.|
|[Conversión de PPT a PPTX](/slides/es/python-net/convert-ppt-to-pptx/)|Aspose.Slides para Python a través de .NET admite la conversión de PPT a PPTX.|
|[Formato de documento portátil (PDF)](/slides/es/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)|Puede exportar todos los formatos de archivo compatibles a documentos Adobe Portable Document Format (PDF) con un único método.|
|[Especificación de analizador XML (XPS)](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-xps/)|Puede exportar todos los formatos de archivo compatibles a documentos XML Parser Specification (XPS) con un único método.|
|[Formato de archivo de imagen etiquetado (TIFF)](/slides/es/python-net/convert-powerpoint-to-tiff/)|Puede exportar todos los formatos de archivo de presentación compatibles a Tagged Image File Format (TIFF).|
|[Conversión de PPTX a HTML](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-html/)|Aspose.Slides para Python a través de .NET admite la conversión de PresentationEx al formato HTML.|

## **Renderizado e impresión**
Aspose.Slides para Python a través de .NET admite el renderizado de alta fidelidad de las diapositivas en los documentos de presentación a varios formatos gráficos. Repase estos detalles:

|**Característica**|**Descripción**|
| :- | :- |
|Formatos de imagen compatibles con .NET|Con Aspose.Slides para Python a través de .NET, puede renderizar diapositivas de presentación e imágenes en diapositivas a todos los formatos gráficos compatibles con .NET, como TIFF, PNG, BMP, JPEG, GIF y metarchivos.|
|Formato SVG|Aspose.Slides para Python a través de .NET también proporciona métodos incorporados que le permiten exportar diapositivas de presentación a formatos Scalable Vector Graphics (SVG).|
|Impresión de presentaciones|Las versiones más recientes de Aspose.Slides para Python a través de .NET proporcionan métodos de impresión incorporados con diferentes opciones.|

## **Características de contenido**
Aspose.Slides para Python a través de .NET le permite acceder, modificar o crear casi todos los elementos o contenidos de los documentos de presentación. Repase estos detalles:

|**Característica**|**Descripción**|
| :- | :- |
|Diapositivas maestras|Las diapositivas maestras definen el diseño de las diapositivas normales. Aspose.Slides para Python a través de .NET le permite acceder y modificar las diapositivas maestras de los documentos de presentación.|
|Diapositivas normales|Con Aspose.Slides para Python a través de .NET, puede crear nuevas diapositivas de diferentes tipos; también puede acceder y modificar diapositivas existentes en las presentaciones.|
|Clonar / Copiar diapositivas|Hay métodos incorporados proporcionados por Aspose.Slides para Python a través de .NET que le permiten clonar o copiar diapositivas existentes dentro de una presentación. También puede usar diapositivas copiadas y clonadas de una presentación a otra. Dado que una diapositiva hereda su diseño de la diapositiva maestra, los métodos de clonación incorporados copian automáticamente la maestra al clonar.|
|Gestión de secciones de diapositivas|Métodos para organizar diapositivas en diferentes secciones dentro de una presentación.|
|Marcadores de posición y marcadores de texto|Puede acceder a los marcadores de posición y marcadores de texto en una diapositiva. Además, puede crear una diapositiva con marcadores de texto desde cero usando el método apropiado.|
|Encabezados y pies de página|Aspose.Slides para Python a través de .NET facilita el manejo de encabezados/pies de página en las diapositivas.|
|Notas en diapositivas|Con Aspose.Slides para Python a través de .NET, puede acceder y modificar notas asociadas a una diapositiva y también agregar nuevas notas.|
|Buscar una forma|También puede buscar una forma concreta en una diapositiva usando el texto alternativo asociado a la forma.|
|Fondos|Aspose.Slides para Python a través de .NET le permite trabajar con fondos asociados a una diapositiva maestra o normal en una presentación.|
|Cuadros de texto|Los cuadros de texto pueden crearse desde cero. Puede acceder a cuadros de texto existentes. También puede modificar sus textos sin perder el formato original del texto.|
|Formas rectangulares|Puede crear o modificar formas rectangulares con Aspose.Slides para Python a través de .NET.|
|Formas de polilínea|Puede crear o modificar formas de polilínea con Aspose.Slides para Python a través de .NET.|
|Formas de elipse|Puede crear o modificar formas de elipse con Aspose.Slides para Python a través de .NET.|
|Formas agrupadas|Aspose.Slides para Python a través de .NET soporta formas agrupadas.|
|Formas automáticas|Aspose.Slides para Python a través de .NET soporta formas automáticas.|
|SmartArt|Aspose.Slides para Python a través de .NET proporciona soporte para formas SmartArt en MS PowerPoint.|
|Gráficos|Aspose.Slides para Python a través de .NET proporciona soporte para Gráficos MSO en PowerPoint.|
|Serialización de formas|Aspose.Slides para Python a través de .NET soporta una gran cantidad de formas. Cuando Aspose.Slides para Python a través de .NET no soporta una forma, puede usar un método de serialización mediante el cual puede serializar esa forma desde una diapositiva existente. De esta manera, puede reutilizar la forma según sus requisitos.|
|Marcos de imagen|Puede gestionar imágenes en marcos de imagen con Aspose.Slides para Python a través de .NET.|
|Marcos de audio|Puede vincular o incrustar archivos de audio en marcos de audio en las diapositivas con Aspose.Slides para Python a través de .NET.|
|Marcos de video|Puede manejar archivos de video en marcos de video. Aspose.Slides para Python a través de .NET también proporciona soporte para videos vinculados e incrustados.|
|Marco OLE|Puede gestionar objetos OLE en marcos OLE con Aspose.Slides para Python a través de .NET.|
|Tablas|Aspose.Slides para Python a través de .NET soporta tablas en diapositivas.|
|Controles ActiveX|Soporte para controles ActiveX.|
|Macros VBA|Soporte para la gestión de macros VBA dentro de presentaciones.|
|Marco de texto|Puede acceder al texto de cualquier forma a través del marco de texto asociado a esa forma.|
|Escaneo de texto|Puede escanear texto en una presentación a nivel de presentación o diapositiva mediante métodos de escaneo incorporados.|
|Animaciones|Puede aplicar animaciones a formas.|
|Presentaciones de diapositivas|Aspose.Slides para Python a través de .NET soporta presentaciones de diapositivas y transiciones de diapositivas.|

## **Características de formato**
Con Aspose.Slides para Python a través de .NET, puede dar formato a textos y formas en diapositivas de presentaciones. Repase estos detalles:

|**Característica**|**Descripción**|
| :- | :- |
|Formato de texto|<p>En Aspose.Slides para Python a través de .NET, puede gestionar textos a través de los marcos de texto asociados a las formas. Por lo tanto, puede formatear textos usando los párrafos y porciones asociados a los marcos de texto. Estos elementos de texto pueden formatearse mediante Aspose.Slides para Python a través de .NET.</p><p>- Tipo de fuente</p><p>- Tamaño de fuente</p><p>- Color de fuente</p><p>- Sombras de fuente</p><p>- Alineación de párrafo</p><p>- Viñetas de párrafo</p><p>- Orientación de párrafo</p>|
|Formato de forma|<p>En Aspose.Slides para Python a través de .NET, el elemento básico de una diapositiva es una forma. Puede formatear estos elementos de forma con Aspose.Slides para Python a través de .NET:</p><p>- Posición</p><p>- Tamaño</p><p>- Línea</p><p>- Relleno (incluyendo Patrón, Degradado, Sólido)</p><p>- Texto</p><p>- Imagen</p>|

## **Preguntas frecuentes**

**¿Necesito instalar Microsoft PowerPoint en el servidor/PC para que la biblioteca funcione?**

No. PowerPoint no es necesario; Aspose.Slides es un motor independiente para crear, editar, convertir y renderizar presentaciones.

**¿Cómo funciona la multihilos? ¿Se puede paralelizar el procesamiento?**

Es seguro procesar diferentes documentos en diferentes hilos; el mismo objeto [presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) no debe ser utilizado por [múltiples hilos](/slides/es/python-net/multithreading/) al mismo tiempo.

**¿Se admiten contraseñas de archivo y cifrado?**

Sí. [Puede](/slides/es/python-net/password-protected-presentation/) abrir presentaciones cifradas, establecer o eliminar una contraseña de apertura y escritura, y comprobar el estado de protección.

**¿Debo preocuparme por los paquetes de fuentes en contenedores Linux?**

Sí. Se recomienda instalar paquetes de fuentes comunes y/o especificar explícitamente [los directorios de fuentes](/slides/es/python-net/custom-font/) en su aplicación para evitar sustituciones inesperadas.

**¿Hay limitaciones en la versión de evaluación?**

En el [modo de evaluación](/slides/es/python-net/licensing/), se agrega una marca de agua a la salida y se aplican ciertas limitaciones; una [licencia temporal de 30 días](https://purchase.aspose.com/temporary-license/) está disponible para pruebas con todas las funciones.

**¿Se admite la importación de formatos externos a una presentación (PDF/HTML → PPTX)?**

Sí. Puede agregar [páginas PDF y contenido HTML](/slides/es/python-net/import-presentation/) a una presentación, convirtiéndolos en diapositivas.