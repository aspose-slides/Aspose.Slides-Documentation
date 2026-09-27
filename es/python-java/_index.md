---
title: Aspose.Slides para Python a través de Java
second_title: Aspose.Slides para Python
type: docs
weight: 47
url: /es/python-java/
is_root: true
keywords:
- Aspose.Slides para Python a través de Java
- Biblioteca PowerPoint para Python
- gestionar presentaciones PowerPoint en Python
- leer y escribir PowerPoint en Python
- editar diapositivas PowerPoint en Python
- exportar PowerPoint a PDF en Python
- exportar PowerPoint a SVG en Python
- previsualizar diapositivas en Python
- añadir audio y vídeo a las diapositivas en Python
- PowerPoint sin Microsoft Office
- Python
- Java
- Aspose.Slides
description: "Comienza aquí: instala Aspose.Slides para Python a través de Java, crea una primera presentación y encuentra las guías para tareas comunes, la referencia de API y soporte."
---
<img src="aspose_slides-for-python-via-java.png" alt="Aspose.Slides para Python a través de Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides para Python a través de Java es una biblioteca para crear, leer, editar y convertir presentaciones PowerPoint y OpenDocument en aplicaciones Python, sin Microsoft PowerPoint; ejecuta el motor Java de Aspose.Slides en su proceso Python a través de JPype.

Carga y guarda PPT, PPTX, PPS, POT y ODP, incluidas las variantes con macros y plantillas, y exporta a PDF, XPS, HTML, SVG, TIFF, Markdown e imágenes.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Primeros pasos</b></p>
<hr>
<p>EMPEZANDO</p>
<ul>
<li><a href="/slides/es/python-java/installation/">Instalación</a></li>
<li><a href="/slides/es/python-java/create-presentation/">Crea tu primera presentación</a></li>
<li><a href="/slides/es/python-java/getting-started/">Guía de inicio</a></li>
</ul>
<p>EVALUAR</p>
<ul>
<li><a href="/slides/es/python-java/supported-file-formats/">Formatos de archivo compatibles</a></li>
<li><a href="/slides/es/python-java/evaluate-aspose-slides/">Limitaciones de la prueba</a></li>
<li><a href="/slides/es/python-java/licensing/">Licenciamiento</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Crear con Slides</b></p>
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
<li><a href="https://reference.aspose.com/slides/es/python-java/">Referencia de API</a></li>
<li><a href="https://releases.aspose.com/slides/es/python-java/release-notes/">Notas de la versión</a></li>
<li><a href="/slides/es/python-java/known-issues/">Problemas conocidos</a></li>
<li><a href="https://releases.aspose.com/slides/es/python-java/">Descargar</a></li>
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

Instala Python y un JDK, configura `JAVA_HOME` y crea y activa un entorno virtual como se describe en [Instalación](/slides/es/python-java/installation/). Luego instala JPype y Aspose.Slides desde PyPI:

```sh
python -m pip install JPype1 aspose-slides-java
```

Guarda este código como *hello.py*. Inicia la Máquina Virtual Java, agrega una forma de nube con texto a la primera diapositiva de una nueva presentación y guarda la presentación:

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

    # Agregar una forma de nube y establecer su texto.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # Guardar la presentación como un archivo PPTX.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ejecútalo en el mismo entorno virtual:

```sh
python hello.py
```

El script guarda *new_presentation.pptx* con una diapositiva que contiene una forma de nube con el texto "Hello, Aspose!". Sin una licencia, el archivo guardado también incluye una marca de agua de evaluación — vea [Licenciamiento](/slides/es/python-java/licensing/). Para más formas de crear y rellenar una presentación, vea [Crear presentaciones](/slides/es/python-java/create-presentation/).