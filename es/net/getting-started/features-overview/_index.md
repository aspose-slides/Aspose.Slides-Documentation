---
title: Resumen de características
type: docs
weight: 94
url: /es/net/features-overview/
keywords:
- funcionalidades
- plataformas soportadas
- formatos de archivo
- conversión
- renderizado
- contenido de la presentación
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Revise lo que cubre Aspose.Slides for .NET antes de evaluarlo: plataformas compatibles, formatos de archivo, renderizado de diapositivas y el contenido que puede crear y editar."
---
## **Descripción general**

Aspose.Slides for .NET es una biblioteca de clases para crear, leer, editar, convertir y renderizar presentaciones de PowerPoint y OpenDocument. No tiene interfaz de usuario propia y no requiere Microsoft PowerPoint ni Office, por lo que puede usarse en aplicaciones de consola, aplicaciones de escritorio como Windows Forms, aplicaciones web y servicios web. Este artículo resume lo que cubre la biblioteca y enlaza a los artículos que describen cada área.

## **Plataformas compatibles**

Aspose.Slides for .NET se distribuye como dos paquetes NuGet con la misma API:

|**Paquete**|**Compilaciones en el paquete**|**Sistemas operativos**|
| :- | :- | :- |
|[Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/)|.NET Framework 4.6.2, .NET Standard 2.0 y .NET 6. Úselo con .NET Framework 4.6.2 o posterior, o con .NET 6 o posterior.|Windows. Linux y macOS con la biblioteca `libgdiplus` y el interruptor `System.Drawing.EnableUnixSupport`.|
|[Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/)|.NET 6. Úselo con .NET 6 o posterior.|Windows (x86, x64), Linux (x64 con glibc 2.23 o posterior, ARM64 con glibc 2.39 o posterior) y macOS (x64, ARM64).|

[Instalación](/slides/es/net/installation/) explica qué paquete elegir y qué necesita cada uno en Linux. [Requisitos del sistema](/slides/es/net/system-requirements/) enumera las plataformas compatibles con detalle.

## **Formatos de archivo y conversiones**

Aspose.Slides abre y guarda presentaciones PPT, PPTX, PPS, POT, PPSX, POTX, PPTM, PPSM, POTM, ODP, OTP, FODP y XML de PowerPoint. Importa contenido PDF y HTML a diapositivas, y guarda presentaciones como PDF, XPS, HTML, HTML5, TIFF, GIF animado, SWF, Markdown y XAML. [Formatos de archivo compatibles](/slides/es/net/supported-file-formats/) enumera cada formato con la API que lo lee o escribe.

|**Funcionalidad**|**Descripción**|
| :- | :- |
|[PPT y PPTX](/slides/es/net/ppt-vs-pptx/)|Leer y escribir tanto el formato binario PowerPoint 97-2003 como el formato Office Open XML.|
|[Conversión de PPT a PPTX](/slides/es/net/convert-ppt-to-pptx/)|Convertir presentaciones PPT heredadas a PPTX.|
|[Especificación de papel XML (XPS)](/slides/es/net/convert-powerpoint-to-xps/)|Exportar presentaciones a documentos XPS.|
|[Formato de archivo de imagen etiquetado (TIFF)](/slides/es/net/convert-powerpoint-to-tiff/)|Exportar presentaciones a imágenes TIFF.|
|[HTML](/slides/es/net/convert-powerpoint-to-html/)|Exportar presentaciones a HTML y HTML5.|
|[Importación de PDF y HTML](/slides/es/net/import-presentation/)|Crear diapositivas a partir de páginas PDF y contenido HTML.|

## **Renderizado de presentaciones**

Aspose.Slides renderiza diapositivas y formas individuales como imágenes PNG, JPEG, BMP, GIF, TIFF y SVG, y diapositivas como metafiles EMF. Vea [Convertir diapositivas de presentación a imágenes](/slides/es/net/convert-slide/), [Renderizar una diapositiva como imagen SVG](/slides/es/net/render-a-slide-as-an-svg-image/), y [Crear miniaturas de formas](/slides/es/net/create-shape-thumbnails/).

## **Funciones de contenido**

Aspose.Slides le permite crear, leer y modificar casi todo el contenido de una presentación:

|**Área**|**Qué puede hacer**|
| :- | :- |
|[Diapositivas](/slides/es/net/presentation-slide/)|Añadir, clonar, reordenar y eliminar diapositivas; aplicar diseños y patrones; organizar diapositivas en secciones; cambiar el tamaño de la diapositiva.|
|[Diseño](/slides/es/net/presentation-design/)|Establecer fondos, colores de tema, encabezados y pies de página, y fuentes.|
|[Texto](/slides/es/net/manage-text/)|Crear y editar marcos de texto, párrafos y porciones; establecer fuentes, colores, viñetas y alineación; buscar y reemplazar texto.|
|[Formas](/slides/es/net/powerpoint-shapes/)|Crear AutoShapes, líneas, conectores, formas agrupadas y marcos de imagen; establecer posición, tamaño, contorno y relleno sólido, degradado o con patrón; buscar una forma por su texto alternativo.|
|[Tablas](/slides/es/net/powerpoint-table/), [gráficas](/slides/es/net/powerpoint-charts/), y [SmartArt](/slides/es/net/powerpoint-smartart/)|Crear y editar tablas, gráficas de Microsoft Office y diagramas SmartArt.|
|[Medios](/slides/es/net/manage-media-files/), [objetos OLE](/slides/es/net/manage-ole/), y [controles ActiveX](/slides/es/net/activex/)|Añadir marcos de audio y vídeo incrustados o vinculados, incrustar objetos OLE y añadir, modificar o eliminar controles ActiveX.|
|[Notas](/slides/es/net/presentation-notes/) y [comentarios](/slides/es/net/presentation-comments/)|Añadir, leer y editar notas del presentador y comentarios de revisión.|
|[Animación](/slides/es/net/powerpoint-animation/) y [transiciones](/slides/es/net/slide-transition/)|Aplicar efectos de animación a formas, establecer transiciones de diapositiva y configurar ajustes de presentación.|
|[Seguridad](/slides/es/net/presentation-security/)|Cifrar presentaciones con una contraseña, establecer protección de escritura y trabajar con firmas digitales.|
|[Macros VBA](/slides/es/net/presentation-via-vba/)|Añadir, extraer y eliminar módulos VBA en presentaciones con macros.|
|[Propiedades](/slides/es/net/presentation-properties/)|Leer y editar propiedades del documento.|

## **Preguntas frecuentes**

**¿Necesito instalar Microsoft PowerPoint en el servidor o PC para que la biblioteca funcione?**

No. PowerPoint no es necesario; Aspose.Slides es un motor independiente para crear, editar, convertir y renderizar presentaciones.

**¿Cómo funciona el multihilo? ¿Se puede paralelizar el procesamiento?**

Es seguro procesar documentos diferentes en hilos distintos; el mismo objeto [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/) no debe ser usado por [varios hilos](/slides/es/net/multithreading/) al mismo tiempo.

**¿Se admiten contraseñas de archivo y cifrado?**

Sí. [Puede](/slides/es/net/password-protected-presentation/) abrir presentaciones cifradas, establecer o eliminar una contraseña de apertura y escritura, y comprobar el estado de protección.

**¿Debo preocuparme por las fuentes en contenedores Linux?**

Sí. Las fuentes utilizadas en sus presentaciones, o sustitutos adecuados, deben estar instaladas en el sistema para que el texto se renderice correctamente. También puede [especificar directorios de fuentes](/slides/es/net/custom-font/) en su aplicación. [Instalación](/slides/es/net/installation/) enumera los requisitos previos de Linux de cada paquete.

**¿Existen limitaciones en la versión de evaluación?**

Sí. Sin una [licencia](/slides/es/net/licensing/), Aspose.Slides añade una marca de agua de evaluación a cada diapositiva que guarda y trunca el texto leído de las presentaciones. Una [licencia temporal de 30 días](https://purchase.aspose.com/temporary-license/) está disponible para pruebas con todas las funciones.

**¿Se admite la importación de formatos externos a una presentación (PDF o HTML a PPTX)?**

Sí. Puede añadir [páginas PDF y contenido HTML](/slides/es/net/import-presentation/) a una presentación, convirtiéndolos en diapositivas.