---
title: Aspose.Slides para Python mediante .NET
second_title: Aspose.Slides para Python
type: docs
weight: 35
url: /es/python-net/
is_root: true
keywords:
- Aspose.Slides para Python
- Automatización de PowerPoint con Python
- Biblioteca PPT de Python
- Exportar PowerPoint a PDF con Python
- Exportar PowerPoint a SVG con Python
- Editar PowerPoint con Python
- PowerPoint en Python sin Microsoft Office
- Gestionar PPTX con Python
- Vista previa de diapositivas con Python
- Añadir audio a diapositivas con Python
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Comience aquí: instale Aspose.Slides para Python mediante .NET, cree una primera presentación y encuentre las guías para tareas comunes, la referencia de la API y el soporte."
---
<img src="aspose_slides-for-python.png" alt="Aspose.Slides para Python via .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Python via .NET es una biblioteca de Python para crear, leer, editar y convertir presentaciones PowerPoint y OpenDocument, sin Microsoft PowerPoint ni Microsoft Office.

Puede cargar y guardar PPT, PPTX, PPS, POT y ODP, incluidas las variantes con macros y plantillas, y exporta a PDF, XPS, HTML, SVG, TIFF, Markdown e imágenes.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Comenzar</b></p>
<hr>
<p>COMENZANDO</p>
<ul>
<li><a href="/slides/es/python-net/installation/">Instalación</a></li>
<li><a href="/slides/es/python-net/create-presentation/">Crear tu primera presentación</a></li>
<li><a href="/slides/es/python-net/getting-started/">Guía de inicio</a></li>
</ul>
<p>EVALUAR</p>
<ul>
<li><a href="/slides/es/python-net/supported-file-formats/">Formatos de archivo compatibles</a></li>
<li><a href="/slides/es/python-net/evaluate-aspose-slides/">Limitaciones de la prueba</a></li>
<li><a href="/slides/es/python-net/licensing/">Licenciamiento</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Crear con Slides</b></p>
<hr>
<p>TAREAS COMUNES</p>
<ul>
<li><a href="/slides/es/python-net/open-presentation/">Abrir una presentación</a></li>
<li><a href="/slides/es/python-net/save-presentation/">Guardar una presentación</a></li>
<li><a href="/slides/es/python-net/convert-powerpoint-to-pdf/">Convertir a PDF</a></li>
<li><a href="/slides/es/python-net/convert-slide/">Renderizar diapositivas como imágenes</a></li>
<li><a href="/slides/es/python-net/manage-text/">Editar texto y formas</a></li>
</ul>
<p>FLUJOS DE TRABAJO DE SLIDES</p>
<ul>
<li><a href="/slides/es/python-net/powerpoint-charts/">Gráficos</a></li>
<li><a href="/slides/es/python-net/powerpoint-animation/">Animaciones</a></li>
<li><a href="/slides/es/python-net/manage-media-files/">Audio y vídeo</a></li>
<li><a href="/slides/es/python-net/presentation-design/">Diseño de diapositivas</a></li>
<li><a href="/slides/es/python-net/merge-presentation/">Combinar presentaciones</a></li>
</ul>
<p>EJEMPLOS</p>
<ul>
<li><a href="/slides/es/python-net/examples/">Ejemplos por elemento de diapositiva</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Python-via-.NET">Ejemplos en GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referencia &amp; Soporte</b></p>
<hr>
<p>REFERENCIA</p>
<ul>
<li><a href="https://reference.aspose.com/slides/python-net/">Referencia de API</a></li>
<li><a href="https://releases.aspose.com/slides/python-net/release-notes/">Notas de la versión</a></li>
<li><a href="https://products.aspose.com/slides/python-net/">Página del producto</a></li>
<li><a href="https://releases.aspose.com/slides/python-net/">Descargar</a></li>
</ul>
<p>SOPORTE</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Foro de soporte gratuito</a></li>
<li><a href="https://helpdesk.aspose.com/">Helpdesk de soporte de pago</a></li>
</ul>
</div>
</div>

------

## **Tu primera presentación**

Instala el paquete desde PyPI:

```bash
pip install aspose.slides
```

El paquete incluye el tiempo de ejecución .NET que utiliza, por lo que no es necesario instalar .NET. En Linux, también instale las librerías libgdiplus e ICU, y con el Python del sistema de Debian o Ubuntu, ejecute el comando en un entorno virtual. macOS tiene requisitos previos adicionales, y no hemos verificado la instalación allí. Consulte [Instalación](/slides/es/python-net/installation/) para los comandos, los requisitos previos de macOS y las versiones de Python compatibles.

Guarda este código como *hello.py*:

```py
import aspose.slides as slides

# Instanciar la clase Presentation que representa un archivo de presentación.
with slides.Presentation() as presentation:
    # Obtener la primera diapositiva.
    slide = presentation.slides[0]

    # Añadir una autoforma de tipo CLOUD.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # Guardar la presentación como un archivo PPTX.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

Ejecutelo con `python hello.py`. El script guarda *new_presentation.pptx* en la carpeta actual, con una diapositiva que contiene una forma de nube que muestra "Hello, Aspose!". Sin una licencia, el archivo guardado lleva una marca de agua de evaluación — vea [Licenciamiento](/slides/es/python-net/licensing/). Para más formas de crear y rellenar una presentación, vea [Crear presentaciones](/slides/es/python-net/create-presentation/).