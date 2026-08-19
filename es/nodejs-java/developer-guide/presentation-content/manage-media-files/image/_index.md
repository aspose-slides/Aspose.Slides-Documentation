---
title: Optimizar la gestión de imágenes en presentaciones usando JavaScript
linktitle: Gestionar imágenes
type: docs
weight: 10
url: /es/nodejs-java/image/
keywords:
- agregar imagen
- agregar foto
- reemplazar imagen
- colección de imágenes
- marco de imagen
- imagen vinculada
- fondo
- agregar PNG
- agregar JPG
- agregar SVG
- SVG a formas
- recursos SVG externos
- PowerPoint
- OpenDocument
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda cómo agregar, reutilizar, enlazar, reemplazar y gestionar imágenes raster y SVG en presentaciones PowerPoint y OpenDocument con Aspose.Slides para Node.js a través de Java."
---
## **Introducción**

Aspose.Slides para Node.js a través de Java ofrece varias formas de trabajar con imágenes, y cada una sirve a un propósito diferente. Puedes almacenar una imagen en una presentación, mostrarla en un marco de imagen, usarla como fondo de diapositiva, enlazar a una imagen externa, reemplazar un recurso de imagen compartido, o convertir contenido SVG en formas editables.

Este artículo se centra en los recursos de imagen y cómo se utilizan a lo largo de una presentación. Para recorte, transparencia, efectos, estiramiento y otros formatos aplicados a un marco de imagen individual, consulta [Picture Frame](/slides/es/nodejs-java/picture-frame/).

## **Entender el modelo de imagen**

Los siguientes conceptos de API están estrechamente relacionados pero no son intercambiables:

- La [colección de imágenes de la presentación](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/imagecollection/) almacena los recursos de imagen utilizados por la presentación. Utiliza [ImageCollection.addImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/imagecollection/) para agregar datos de imagen y obtener un recurso [PPImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ppimage/).
- Un [marco de imagen](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pictureframe/) es una forma que muestra una imagen en una diapositiva, diseño o maestro. Utiliza [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shapecollection/) para colocar un recurso de imagen en una diapositiva.
- Un fondo de diapositiva usa una imagen como parte del relleno de la diapositiva en lugar de como una forma. Por lo tanto, no se comporta como un marco de imagen.
- [PPImage.replaceImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ppimage/) reemplaza un recurso de imagen. Si varios elementos de la presentación usan ese recurso, todos utilizan el reemplazo.
- Convertir un SVG a formas crea formas de diapositiva editables. Después de la conversión, el contenido ya no se gestiona como un único recurso de imagen.

Un flujo de trabajo típico es, por tanto: añadir datos de imagen a la colección de imágenes, obtener un [PPImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ppimage/), y luego usar ese recurso en uno o más marcos de imagen o rellenos.

## **Agregar una imagen incrustada**

Para insertar una imagen local, carga el archivo, añádelo a la colección de imágenes y crea un marco de imagen que utilice el recurso [PPImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ppimage/) devuelto.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) {
            sourceImage.dispose();
        }
    }

    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, image);

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La imagen añadida de esta manera se incrusta en la presentación, por lo que el archivo resultante no depende de que el archivo de imagen original siga disponible.

### **Agregar una imagen desde la Web**

Cuando una imagen está disponible mediante HTTP o HTTPS, descarga sus bytes, añádelos a la colección de imágenes de la presentación y usa el recurso de imagen devuelto de la misma manera que una imagen local.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const http = require("http");
const https = require("https");
const java = require("java");

function downloadBytes(url) {
    return new Promise((resolve, reject) => {
        const client = url.startsWith("https:") ? https : http;
        client.get(url, (response) => {
            if (response.statusCode < 200 || response.statusCode >= 300) {
                response.resume();
                reject(new Error(`HTTP ${response.statusCode}`));
                return;
            }

            const chunks = [];
            response.on("data", (chunk) => chunks.push(chunk));
            response.on("end", () => resolve(Buffer.concat(chunks)));
        }).on("error", reject);
    });
}

(async () => {
    const imageData = await downloadBytes("https://example.com/image.png");
    const javaBytes = java.newArray("byte", Array.from(imageData));

    const presentation = new aspose.slides.Presentation();
    try {
        const image = presentation.getImages().addImage(javaBytes);
        const slide = presentation.getSlides().get_Item(0);
        slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, image);

        presentation.save("presentation-from-web.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
})();
```

En aplicaciones de larga duración, reutiliza un cliente HTTP o una estrategia de gestión de conexiones apropiada para la aplicación en lugar de crear repetidamente infraestructura de red innecesaria. También valida las URL remotas, los tamaños de respuesta y los tipos de contenido cuando la fuente no es de confianza.

## **Reutilizar imágenes entre diapositivas**

Si la misma imagen se necesita más de una vez, añádela a la presentación una sola vez y reutiliza el [PPImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ppimage/) devuelto al crear marcos de imagen adicionales. Esto evita cargar repetidamente los mismos datos de origen y hace explícita la relación entre el recurso de imagen compartido y sus usos.

Para gráficos que deben aparecer automáticamente en muchas diapositivas, como el logotipo de una empresa, considera colocar el marco de imagen en un [slide master](/slides/es/nodejs-java/slide-master/) o diseño en lugar de añadir una forma equivalente a cada diapositiva.

## **Usar una imagen como fondo de diapositiva**

Una imagen de fondo se asigna al relleno de la diapositiva; no se añade como una forma de marco de imagen. Esto es útil cuando la imagen debe cubrir el fondo de la diapositiva y no debe manipularse como un objeto de diapositiva normal.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("background.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) {
            sourceImage.dispose();
        }
    }

    const backgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    slide.getBackground().setType(backgroundType);

    const fillType = java.newByte(aspose.slides.FillType.Picture);
    slide.getBackground().getFillFormat().setFillType(fillType);

    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image);

    presentation.save("background-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para opciones adicionales de fondo, incluidos fondos de maestro y diseño, consulta [Presentation Background](/slides/es/nodejs-java/presentation-background/).

## **Imágenes incrustadas e imágenes vinculadas**

Imágenes incrustadas e imágenes vinculadas tienen diferentes compensaciones en portabilidad y tamaño de archivo:

- **Imagen incrustada:** los datos de la imagen se almacenan dentro de la presentación. La presentación es autónoma, pero el tamaño del archivo incluye los datos de la imagen.
- **Imagen vinculada:** la presentación almacena una ruta o URL a una imagen externa. Esto puede reducir el tamaño de la presentación, pero el recurso externo debe permanecer accesible cuando la presentación se abra o se renderice.

Una imagen vinculada puede crearse asignando la ruta o URL externas mediante [Picture.setLinkPathLong](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/picture/) en lugar de incrustar los datos de la imagen.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, null);
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png");

    presentation.save("linked-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Utiliza imágenes vinculadas solo cuando el entorno de despliegue pueda acceder de forma fiable al recurso externo. Para presentaciones que deben funcionar sin conexión o trasladarse entre sistemas, las imágenes incrustadas suelen ser más seguras.

## **Trabajar con imágenes SVG**

SVG es un formato vectorial, por lo que puede ser útil para iconos, diagramas y otros gráficos que deben escalar sin la misma pérdida de detalle que las imágenes rasterizadas. Aspose.Slides admite SVG tanto como recurso de imagen como fuente para formas editables de diapositiva.

### **Agregar un SVG como imagen**

Crea un [SvgImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/svgimage/), añádelo a la colección de imágenes y coloca el recurso de imagen resultante en un marco de imagen.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const svgContent = fs.readFileSync("icon.svg", "utf8");
    const svgImage = new aspose.slides.SvgImage(svgContent);

    const image = presentation.getImages().addImage(svgImage);
    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 200, image);

    presentation.save("svg-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Archivos SVG con recursos externos**

Un SVG puede referenciar imágenes, hojas de estilo o fuentes externas. Para estos casos, [SvgImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/svgimage/) proporciona constructores que aceptan un [ExternalResourceResolver](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/externalresourceresolver/) y un URI base. El resolvedor puede mapear un URI relativo a un URI absoluto permitido y devolver un flujo para el recurso solicitado.

El resolvedor hace que los recursos externos estén disponibles mientras Aspose.Slides procesa el SVG, pero no reescribe el SVG en un documento autónomo. Si el SVG debe permanecer portátil, incrusta sus recursos necesarios dentro del propio SVG, por ejemplo utilizando URIs `data:` para imágenes vinculadas.

Cuando los archivos SVG provienen de fuentes no confiables, restringe los esquemas, ubicaciones de archivos y hosts a los que el resolvedor puede acceder. Los resolvedores de red también deben aplicar tiempos de espera, límites de tamaño de respuesta y validación de contenido.

### **Convertir SVG a formas editables**

Aspose.Slides puede convertir un SVG en un grupo de formas de diapositiva editables, similar al comando correspondiente de PowerPoint.

![PowerPoint Popup Menu](img_01_01.png)

Utiliza la sobrecarga [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shapecollection/) que acepta una imagen SVG para realizar la conversión.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const svgContent = fs.readFileSync("diagram.svg", "utf8");
    const svgImage = new aspose.slides.SvgImage(svgContent);

    const slideSize = presentation.getSlideSize().getSize();
    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, slideSize.getWidth(), slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Utiliza la conversión de SVG a formas cuando se necesite editar elementos vectoriales individuales como formas de PowerPoint. Si el SVG solo necesita mostrarse, mantenerlo como imagen es más sencillo y evita crear muchas formas separadas.

## **Reemplazar un recurso de imagen existente**

Utiliza [PPImage.replaceImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ppimage/) cuando quieras reemplazar un recurso de imagen existente. Esto es especialmente útil para gráficos compartidos como logotipos.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const imageToReplace = presentation.getImages().get_Item(0);

    const replacementImage = aspose.slides.Images.fromFile("new-logo.png");
    try {
        imageToReplace.replaceImage(replacementImage);
    } finally {
        if (replacementImage != null) {
            replacementImage.dispose();
        }
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Si varios marcos de imagen, fondos, maestros o diseños utilizan el mismo recurso de imagen, reemplazar ese recurso actualiza todos esos usos. Si solo debe cambiar un marco de imagen, asigna una imagen diferente a ese marco en lugar de reemplazar el recurso compartido.

[PPImage.replaceImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ppimage/) también ofrece sobrecargas que aceptan una matriz de bytes u otro [PPImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ppimage/).

## **Guía práctica de gestión de imágenes**

### **Controlar el tamaño de la presentación**

Las imágenes raster grandes pueden hacer que una presentación sea innecesariamente grande. Usa imágenes fuente con dimensiones adecuadas para el tamaño de visualización previsto, reutiliza recursos de imagen compartidos cuando sea posible y evita incrustar copias repetidas del mismo gráfico de alta resolución.

Para imágenes raster que ya se han colocado en marcos de imagen, [PictureFillFormat.compressImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/picturefillformat/) puede reducir los datos de la imagen según la resolución seleccionada y la configuración de recorte. Esto es procesamiento de marcos de imagen, no gestión de la colección de imágenes, así que consulta [Picture Frame](/slides/es/nodejs-java/picture-frame/) para operaciones de formato relacionadas.

### **Elegir entre contenido incrustado y vinculado**

Incrustar hace que la presentación sea portátil porque todos los datos de imagen necesarios viajan con el archivo. Vincular puede reducir el tamaño del archivo, pero introduce una dependencia externa. Usa enlaces solo cuando esa dependencia sea aceptable y estable.

### **Reutilizar la marca compartida**

Para logotipos, marcas de agua o gráficos decorativos repetidos, usa un recurso de imagen y reutilízalo. Si el gráfico pertenece al diseño de la presentación más que al contenido de la diapositiva, colócalo en un maestro o diseño para que sea heredado por las diapositivas correspondientes.

### **Mantener los recursos SVG portátiles**

Un SVG autónomo es más fácil de mover y renderizar de forma consistente que un SVG que depende de archivos externos o recursos de red. Cuando sea posible, incrusta los recursos necesarios antes de importar el SVG. Convierte SVG a formas solo cuando los elementos vectoriales individuales necesiten ser editados.

### **Utilizar la API moderna de imagen multiplataforma**

Para el nuevo código Node.js a través de Java, utiliza las APIs [IImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/iimage/) y [Images](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/images/) de Aspose.Slides en lugar de la API pública heredada basada en `java.awt.image.BufferedImage`. Consulta [Modern API](/slides/es/nodejs-java/modern-api/) para obtener orientación sobre la migración.

WMF y EMF requieren consideraciones especiales. Cuando estos formatos se pasan a través de un [IImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/iimage/), [ImageCollection.addImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/imagecollection/) convierte el metarchivo a una representación raster PNG antes de la inserción. Si es importante preservar los datos del metarchivo, utiliza una sobrecarga basada en stream de [ImageCollection.addImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/imagecollection/) en su lugar. Generar contenido EMF a partir de hojas de cálculo u otros productos es un flujo de integración separado y está fuera del alcance de este artículo.

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre la colección de imágenes y un marco de imagen?**

La colección de imágenes almacena recursos de imagen reutilizables. Un marco de imagen es una forma de diapositiva que muestra uno de esos recursos y proporciona formato específico de imagen, como recorte y efectos.

**¿Cuál es la mejor manera de reemplazar el mismo logotipo en todas partes?**

Si el logotipo ya está compartido como un recurso de imagen, reemplaza ese recurso con [PPImage.replaceImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ppimage/). Para la marca en toda la presentación, colocar el logotipo en un maestro o diseño también puede reducir el contenido duplicado de las diapositivas.

**¿Por qué desaparece una imagen vinculada en otro ordenador?**

Una imagen vinculada depende de su archivo o URL externa. Si ese recurso no se puede alcanzar desde el otro ordenador, la imagen vinculada puede no estar disponible. Incrusta la imagen cuando la presentación deba ser autónoma.

**¿Se puede editar un SVG insertado como formas de PowerPoint?**

Sí. Convierte el SVG con [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shapecollection/); el grupo resultante contiene formas de diapositiva editables en lugar de una única imagen SVG.

**¿Cómo puedo mantener más pequeñas las presentaciones con muchas imágenes?**

Reutiliza recursos de imagen compartidos, evita fuentes raster innecesariamente grandes, comprime imágenes raster adecuadas cuando corresponda, mantiene la marca repetida en maestros o diseños, y utiliza imágenes vinculadas solo cuando una dependencia externa sea aceptable.