---
title: Aspose.Slides para .NET
second_title: Aspose.Slides para .NET
type: docs
weight: 10
url: /es/net/
keywords:
- documentación
- procesamiento de presentaciones
- conversión de presentaciones
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Empieza aquí: instala Aspose.Slides para .NET, crea una primera presentación y encuentra las guías para tareas comunes, la referencia de la API y el soporte."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for .NET es una biblioteca de clases para crear, leer, editar y convertir presentaciones PowerPoint y OpenDocument en aplicaciones .NET, sin Microsoft PowerPoint ni Automatización de Office.

Carga y guarda archivos PPT, PPTX, PPS, POT y ODP, incluidas las variantes con macros y plantillas, y exporta a PDF, XPS, HTML, SVG, TIFF, Markdown e imágenes.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Primeros pasos</b></p>
<hr>
<p>COMENZANDO</p>
<ul>
<li><a href="/slides/es/net/installation/">Instalación</a></li>
<li><a href="/slides/es/net/create-presentation/">Crear tu primera presentación</a></li>
<li><a href="/slides/es/net/getting-started/">Guía de inicio</a></li>
</ul>
<p>EVALUAR</p>
<ul>
<li><a href="/slides/es/net/supported-file-formats/">Formatos de archivo compatibles</a></li>
<li><a href="/slides/es/net/evaluate-aspose-slides/">Limitaciones de la prueba</a></li>
<li><a href="/slides/es/net/licensing/">Licencias</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Desarrollar con Slides</b></p>
<hr>
<p>TAREAS COMUNES</p>
<ul>
<li><a href="/slides/es/net/open-presentation/">Abrir una presentación</a></li>
<li><a href="/slides/es/net/save-presentation/">Guardar una presentación</a></li>
<li><a href="/slides/es/net/convert-powerpoint-to-pdf/">Convertir a PDF</a></li>
<li><a href="/slides/es/net/convert-slide/">Renderizar diapositivas como imágenes</a></li>
<li><a href="/slides/es/net/manage-text/">Editar texto y formas</a></li>
</ul>
<p>FLUJOS DE TRABAJO DE SLIDES</p>
<ul>
<li><a href="/slides/es/net/powerpoint-charts/">Gráficos</a></li>
<li><a href="/slides/es/net/powerpoint-animation/">Animaciones</a></li>
<li><a href="/slides/es/net/manage-media-files/">Audio y vídeo</a></li>
<li><a href="/slides/es/net/presentation-design/">Diseño de diapositivas</a></li>
<li><a href="/slides/es/net/merge-presentation/">Combinar presentaciones</a></li>
</ul>
<p>EJEMPLOS</p>
<ul>
<li><a href="/slides/es/net/examples/">Ejemplos por elemento de diapositiva</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-.NET">Ejemplos en GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referencia &amp; Soporte</b></p>
<hr>
<p>REFERENCIA</p>
<ul>
<li><a href="https://reference.aspose.com/slides/es/net/">Referencia de API</a></li>
<li><a href="https://releases.aspose.com/slides/es/net/release-notes/">Notas de la versión</a></li>
<li><a href="/slides/es/net/known-issues/">Problemas conocidos</a></li>
<li><a href="https://releases.aspose.com/slides/es/net/">Descargar</a></li>
</ul>
<p>SOPORTE</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/es/11">Foro de soporte gratuito</a></li>
<li><a href="https://helpdesk.aspose.com/">Mesa de ayuda de soporte de pago</a></li>
</ul>
</div>
</div>

------

## **Tu primera presentación**

Crea una aplicación de consola con el .NET SDK 6 o posterior:

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

A continuación, añade un paquete para tu plataforma:

- En Windows: `dotnet add package Aspose.Slides.NET`
- En Linux y macOS: `dotnet add package Aspose.Slides.NET6.CrossPlatform` — consulta [Instalación](/slides/es/net/installation/) para el requisito previo de Linux y para los sistemas que necesiten Aspose.Slides.NET en su lugar.

Reemplaza el contenido de *Program.cs* con este código y ejecuta `dotnet run`:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);
```

El programa guarda *hello.pptx* con una diapositiva que contiene un cuadro de texto. Sin una licencia, el archivo guardado lleva una marca de agua de evaluación — consulta [Licencias](/slides/es/net/licensing/). Para más formas de crear y completar una presentación, consulta [Crear Presentaciones](/slides/es/net/create-presentation/).