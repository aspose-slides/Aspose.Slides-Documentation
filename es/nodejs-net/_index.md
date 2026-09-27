---
title: Aspose.Slides para Node.js a través de .NET
second_title: Aspose.Slides para Node.js
type: docs
weight: 47
url: /es/nodejs-net/
keywords:
- documentación
- procesamiento de presentaciones
- conversión de presentaciones
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Comienza aquí: instala Aspose.Slides para Node.js a través de .NET, crea una primera presentación y consulta las guías para tareas habituales, licencias, la referencia de la API y el soporte."
is_root: true
---
<img src="aspose_slides-for-nodejs-via-net.png" alt="Aspose.Slides para Node.js a través de .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Node.js via .NET es una biblioteca para crear, leer, editar y convertir presentaciones PowerPoint y OpenDocument en aplicaciones Node.js, sin Microsoft PowerPoint ni Automatización de Office. Ejecuta Aspose.Slides for .NET a través del puente edge-js, por lo que su API JavaScript refleja la API .NET, con nombres de miembros en camelCase.

Carga y guarda archivos PPT, PPTX, PPS, POT y ODP, incluidas las variantes con macros y plantillas, y exporta a PDF, XPS, HTML, TIFF, Markdown e imágenes.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Comenzar</b></p>
<hr>
<p>COMENZANDO</p>
<ul>
<li><a href="/slides/es/nodejs-net/installation/">Instalación</a></li>
<li><a href="/slides/es/nodejs-net/create-presentation/">Crea tu primera presentación</a></li>
<li><a href="/slides/es/nodejs-net/developer-guide/">Guía del desarrollador</a></li>
</ul>
<p>EVALUAR</p>
<ul>
<li><a href="/slides/es/nodejs-net/evaluate-aspose-slides/">Limitaciones de la prueba</a></li>
<li><a href="/slides/es/nodejs-net/licensing/">Licencias</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Crear con Slides</b></p>
<hr>
<p>TAREAS COMUNES</p>
<ul>
<li><a href="/slides/es/nodejs-net/open-presentation/">Abrir y guardar una presentación</a></li>
<li><a href="/slides/es/nodejs-net/convert-powerpoint-to-pdf/">Convertir a PDF</a></li>
<li><a href="/slides/es/nodejs-net/convert-slide/">Renderizar diapositivas como imágenes</a></li>
<li><a href="/slides/es/nodejs-net/manage-text/">Editar texto</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referencia y Soporte</b></p>
<hr>
<p>REFERENCIA</p>
<ul>
<li><a href="https://reference.aspose.com/slides/net/">Referencia de la API .NET</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-net/release-notes/">Notas de la versión</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-net/">Descargar</a></li>
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

Necesitas Node.js 22 o 24 y el .NET SDK 8 o posterior; Linux también necesita algunos paquetes del sistema. [Instalación](/slides/es/nodejs-net/installation/) los enumera junto con las plataformas probadas. Crea un proyecto, añade una sobrescritura que indique a npm qué versión de edge-js instalar, y instala el paquete:

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
npm install aspose.slides.via.net
```

Una vez por máquina, restaura los paquetes .NET de los que depende la biblioteca. Guarda el archivo `deps.csproj` de [Restaurar las dependencias .NET](/slides/es/nodejs-net/installation/#restore-the-net-dependencies) en una carpeta `deps` dentro de la carpeta del proyecto, luego ejecuta:

```sh
dotnet restore deps/deps.csproj
```

Guarda este código como *hello.js* en la carpeta del proyecto:

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

// Una nueva presentación contiene una diapositiva vacía.
const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // La posición y el tamaño están en puntos (1/72 pulgada): x, y, ancho, alto.
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    rectangle.addTextFrame("Hello, World!");

    presentation.save("hello.pptx", SaveFormat.Pptx);
    console.log("Saved hello.pptx");
} finally {
    // Libera el objeto .NET que respalda la presentación.
    presentation.dispose();
}
```

Ejecútalo desde la carpeta del proyecto:

```sh
node hello.js
```

El script muestra `Saved hello.pptx` y guarda *hello.pptx* con una diapositiva que contiene un rectángulo con el texto. Sin una licencia, el archivo guardado lleva una marca de agua de evaluación — consulta [Licencias](/slides/es/nodejs-net/licensing/). Para más formas de crear y rellenar una presentación, consulta [Crear una presentación](/slides/es/nodejs-net/create-presentation/).