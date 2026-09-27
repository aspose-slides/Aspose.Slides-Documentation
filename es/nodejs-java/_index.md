---
title: Aspose.Slides para Node.js a través de Java
second_title: Aspose.Slides para Node.js
type: docs
weight: 47
url: /es/nodejs-java/
keywords:
- documentación
- procesamiento de presentaciones
- conversión de presentaciones
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Empieza aquí: instala Aspose.Slides para Node.js a través de Java, crea una primera presentación y encuentra las guías para tareas comunes, la referencia de API y el soporte."
is_root: true
---
<img src="aspose_slides-for-nodejs-via-java.png" alt="Aspose.Slides para Node.js a través de Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Node.js via Java es una biblioteca para crear, leer, editar y convertir presentaciones de PowerPoint y OpenDocument en aplicaciones Node.js, sin Microsoft PowerPoint.

Carga y guarda archivos PPT, PPTX, PPS, POT y ODP, incluidas variantes con macros y plantillas, y exporta a PDF, XPS, HTML, SVG, TIFF, Markdown e imágenes.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Comenzar</b></p>
<hr>
<p>COMENZANDO</p>
<ul>
<li><a href="/slides/es/nodejs-java/installation/">Instalación</a></li>
<li><a href="/slides/es/nodejs-java/create-presentation/">Crea tu primera presentación</a></li>
<li><a href="/slides/es/nodejs-java/getting-started/">Guía de inicio</a></li>
</ul>
<p>EVALUAR</p>
<ul>
<li><a href="/slides/es/nodejs-java/supported-file-formats/">Formatos de archivo compatibles</a></li>
<li><a href="/slides/es/nodejs-java/evaluate-aspose-slides/">Limitaciones de la prueba</a></li>
<li><a href="/slides/es/nodejs-java/licensing/">Licencias</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Crear con Slides</b></p>
<hr>
<p>TAREAS COMUNES</p>
<ul>
<li><a href="/slides/es/nodejs-java/open-presentation/">Abrir una presentación</a></li>
<li><a href="/slides/es/nodejs-java/save-presentation/">Guardar una presentación</a></li>
<li><a href="/slides/es/nodejs-java/convert-powerpoint-to-pdf/">Convertir a PDF</a></li>
<li><a href="/slides/es/nodejs-java/convert-slide/">Renderizar diapositivas como imágenes</a></li>
<li><a href="/slides/es/nodejs-java/manage-text/">Editar texto y formas</a></li>
</ul>
<p>FLUJOS DE TRABAJO DE SLIDES</p>
<ul>
<li><a href="/slides/es/nodejs-java/powerpoint-charts/">Gráficos</a></li>
<li><a href="/slides/es/nodejs-java/powerpoint-animation/">Animaciones</a></li>
<li><a href="/slides/es/nodejs-java/manage-media-files/">Audio y vídeo</a></li>
<li><a href="/slides/es/nodejs-java/presentation-design/">Diseño de diapositivas</a></li>
<li><a href="/slides/es/nodejs-java/merge-presentation/">Combinar presentaciones</a></li>
</ul>
<p>EJEMPLOS</p>
<ul>
<li><a href="/slides/es/nodejs-java/examples/">Ejemplos por elemento de diapositiva</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referencia &amp; Soporte</b></p>
<hr>
<p>REFERENCIA</p>
<ul>
<li><a href="https://reference.aspose.com/slides/nodejs-java/">Referencia de API</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-java/release-notes/">Notas de la versión</a></li>
<li><a href="/slides/es/nodejs-java/known-issues/">Problemas conocidos</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-java/">Descarga</a></li>
</ul>
<p>SOPORTE</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Foro de soporte gratuito</a></li>
<li><a href="https://helpdesk.aspose.com/">Mesa de ayuda de soporte pago</a></li>
</ul>
</div>
</div>

------

## **Tu primera presentación**

Además de Node.js 20 o superior, el paquete necesita un Java Development Kit (JDK), Python y una cadena de herramientas de compilación C++, porque npm compila su puente `java` durante la instalación. Consulte [Instalación](/slides/es/nodejs-java/installation/) para los pasos en cada sistema operativo. Luego cree un proyecto e instale el paquete desde npm:

```bash
mkdir hello-slides
cd hello-slides
npm init -y
npm install aspose.slides.via.java
```

Guarde este código como *hello.js* en la carpeta del proyecto:

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Aspose.Slides se ejecuta en una máquina virtual Java que mantiene Node.js en ejecución, por lo que se debe finalizar el proceso explícitamente.
process.exit(0);
```

Ejecutelo con `node hello.js`. El script guarda *hello.pptx* con una diapositiva que contiene un cuadro de texto. Sin una licencia, el archivo guardado lleva una marca de agua de evaluación — vea [Licencias](/slides/es/nodejs-java/licensing/). Para más formas de crear y rellenar una presentación, vea [Crear presentaciones](/slides/es/nodejs-java/create-presentation/).