---
title: Aspose.Slides para Python mediante Java
second_title: Aspose.Slides para Python
type: docs
weight: 47
url: /es/python-java/
is_root: true
keywords:
- Aspose.Slides para Python mediante Java
- Biblioteca PowerPoint para Python
- Gestionar presentaciones PowerPoint en Python
- Leer y escribir PowerPoint en Python
- Editar diapositivas PowerPoint en Python
- Exportar PowerPoint a PDF en Python
- Exportar PowerPoint a SVG en Python
- Previsualizar diapositivas en Python
- Añadir audio y vídeo a diapositivas en Python
- PowerPoint sin Microsoft Office
- Python
- Java
- Aspose.Slides
description: "Comienza aquí: instala Aspose.Slides para Python mediante Java, crea una primera presentación y encuentra las guías para tareas comunes, la referencia de API y el soporte."
---
<img src="aspose_slides-for-python-via-java.png" alt="Aspose.Slides for Python via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Python via Java es una biblioteca para crear, leer, editar y convertir presentaciones PowerPoint y OpenDocument en aplicaciones Python, sin Microsoft PowerPoint; ejecuta el motor Java de Aspose.Slides en su proceso Python mediante JPype.

Carga y guarda archivos PPT, PPTX, PPS, POT y ODP, incluidas las variantes con macros y plantillas, y exporta a PDF, XPS, HTML, SVG, TIFF, Markdown e imágenes.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Comenzar</b></p>
<hr>
<p>COMENZANDO</p>
<ul>
<li><a href="/slides/es/python-java/installation/">Instalación</a></li>
<li><a href="/slides/es/python-java/create-presentation/">Crea tu primera presentación</a></li>
<li><a href="/slides/es/python-java/getting-started/">Guía de inicio</a></li>
</ul>
<p>EVALUAR</p>
<ul>
<li><a href="/slides/es/python-java/supported-file-formats/">Formatos de archivo admitidos</a></li>
<li><a href="/slides/es/python-java/evaluate-aspose-slides/">Limitaciones de la versión de prueba</a></li>
<li><a href="/slides/es/python-java/licensing/">Licenciamiento</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Construir con Slides</b></p>
<hr>
<p>TAREAS COMUNES</p>
<ul>
<li><a href="/slides/es/python-java/open-presentation/">Abrir una presentación</a></li>
<li><a href="/slides/es/python-java/save-presentation/">Guardar una presentación</a></li>
<li><a href="/slides/es/python-java/convert-powerpoint-to-pdf/">Convertir a PDF</a></li>
<li><a href="/slides/es/python-java/convert-slide/">Renderizar diapositivas como imágenes</a></li>
<li><a href="/slides/es/python-java/manage-text/">Editar texto y formas</a></li>
</ul>
<p>FLUJOS DE TRABAJO DE SLIDES</p>
<ul>
<li><a href="/slides/es/python-java/powerpoint-charts/">Gráficos</a></li>
<li><a href="/slides/es/python-java/powerpoint-animation/">Animaciones</a></li>
<li><a href="/slides/es/python-java/manage-media-files/">Audio y vídeo</a></li>
<li><a href="/slides/es/python-java/presentation-design/">Diseño de diapositivas</a></li>
<li><a href="/slides/es/python-java/merge-presentation/">Combinar presentaciones</a></li>
</ul>
<p>EJEMPLOS</p>
<ul>
<li><a href="/slides/es/python-java/examples/">Ejemplos por elemento de diapositiva</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referencia y Soporte</b></p>
<hr>
<p>REFERENCIA</p>
<ul>
<li><a href="https://reference.aspose.com/slides/python-java/">Referencia de API</a></li>
<li><a href="https://releases.aspose.com/slides/python-java/release-notes/">Notas de la versión</a></li>
<li><a href="/slides/es/python-java/known-issues/">Problemas conocidos</a></li>
<li><a href="https://products.aspose.com/slides/python-java/">Página del producto</a></li>
<li><a href="https://releases.aspose.com/slides/python-java/">Descargar</a></li>
</ul>
<p>SOFTWARE</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Foro de soporte gratuito</a></li>
<li><a href="https://helpdesk.aspose.com/">Helpdesk de soporte de pago</a></li>
</ul>
</div>
</div>

------

## **Tu primera presentación**

Instale Python y un JDK, establezca `JAVA_HOME` y cree y active un entorno virtual como se describe en [Instalación](/slides/es/python-java/installation/). Luego instale JPype y Aspose.Slides desde PyPI:

```sh
python -m pip install JPype1 aspose-slides-java
```

Guarde este código como *hello.py*. Inicia la Máquina Virtual Java, añade una forma de nube con texto a la primera diapositiva de una nueva presentación y guarda la presentación:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Crear una presentación con una diapositiva en blanco.
presentation = Presentation()
try:
    # Obtener la primera diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Añadir una forma de nube y establecer su texto.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # Guardar la presentación como archivo PPTX.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ejecute en el mismo entorno virtual:

```sh
python hello.py
```

El script guarda *new_presentation.pptx* con una diapositiva que contiene una forma de nube con el texto "Hello, Aspose!". Sin una licencia, el archivo guardado también lleva una marca de agua de evaluación — vea [Licenciamiento](/slides/es/python-java/licensing/). Para más formas de crear y rellenar una presentación, vea [Crear presentaciones](/slides/es/python-java/create-presentation/).