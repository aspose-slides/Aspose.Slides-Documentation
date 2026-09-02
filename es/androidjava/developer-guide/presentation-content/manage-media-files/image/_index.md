---
title: Optimizar la gestión de imágenes en presentaciones en Android
linktitle: Gestionar imágenes
type: docs
weight: 10
url: /es/androidjava/image/
keywords:
- añadir imagen
- añadir foto
- reemplazar imagen
- colección de imágenes
- marco de imagen
- imagen vinculada
- fondo
- añadir PNG
- añadir JPG
- añadir SVG
- SVG a formas
- recursos SVG externos
- PowerPoint
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "Aprenda cómo añadir, reutilizar, vincular, reemplazar y gestionar imágenes raster y SVG en presentaciones de PowerPoint y OpenDocument con Aspose.Slides para Android mediante Java."
---
## **Introducción**

Aspose.Slides for Android via Java ofrece varias formas de trabajar con imágenes, y cada una sirve a un propósito diferente. Puedes almacenar una imagen en una presentación, mostrarla en un marco de imagen, usarla como fondo de diapositiva, enlazar a una imagen externa, sustituir un recurso de imagen compartido o convertir contenido SVG en formas editables.

Este artículo se centra en los recursos de imagen y en cómo se utilizan en toda una presentación. Para recortar, transparencia, efectos, estiramiento y otro formato aplicado a un marco de imagen individual, consulta [Marco de Imagen](/slides/es/androidjava/picture-frame/).

## **Comprender el Modelo de Imagen**

Los siguientes conceptos de la API están estrechamente relacionados pero no son intercambiables:

- La [colección de imágenes de presentación](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iimagecollection/) almacena recursos de imagen utilizados por la presentación. Usa [ImageCollection.addImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/imagecollection/) para añadir datos de imagen y obtener un recurso [IPPImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ippimage/).
- Un [marco de imagen](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipictureframe/) es una forma que muestra una imagen en una diapositiva, diseño o maestro. Usa [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ishapecollection/) para colocar un recurso de imagen en una diapositiva.
- Un fondo de diapositiva usa una imagen como parte del relleno de la diapositiva en lugar de como una forma. Por lo tanto, no se comporta como un marco de imagen.
- [IPPImage.replaceImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ippimage/) sustituye un recurso de imagen. Si varios elementos de la presentación usan ese recurso, todos utilizan la sustitución.
- Convertir un SVG a formas crea formas de diapositiva editables. Tras la conversión, el contenido ya no se gestiona como un único recurso de imagen.

Un flujo de trabajo típico es, por tanto: añadir datos de imagen a la colección de imágenes, recibir un [IPPImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ippimage/), y luego usar ese recurso en uno o más marcos de imagen o rellenos.

## **Agregar una Imagen Incrustada**

Para insertar una imagen local, carga el archivo, añádelo a la colección de imágenes y crea un marco de imagen que use el `IPPImage` devuelto.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) sourceImage.dispose();
    }

    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

    presentation.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La imagen añadida de esta forma queda incrustada en la presentación, por lo que el archivo resultante no depende de que el archivo de imagen original siga disponible.

### **Agregar una Imagen desde la Web**

Cuando una imagen está disponible a través de HTTP o HTTPS, descarga sus bytes, añádelos a la colección de imágenes de la presentación y usa el recurso de imagen devuelto de la misma forma que una imagen local.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.URI;
import java.net.URL;

Presentation presentation = new Presentation();
try {
    URL imageUrl = URI.create("https://example.com/image.png").toURL();
    HttpURLConnection connection = (HttpURLConnection) imageUrl.openConnection();
    connection.setConnectTimeout(10000);
    connection.setReadTimeout(10000);

    try (InputStream inputStream = connection.getInputStream(); 
         ByteArrayOutputStream outputStream = new ByteArrayOutputStream()) {
        byte[] buffer = new byte[8192];
        int bytesRead;
        while ((bytesRead = inputStream.read(buffer)) != -1) outputStream.write(buffer, 0, bytesRead);

        IPPImage image = presentation.getImages().addImage(outputStream.toByteArray());
        ISlide slide = presentation.getSlides().get_Item(0);
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);
    }

    presentation.save("presentation-from-web.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

En aplicaciones de larga duración, reutiliza un cliente HTTP o una estrategia de gestión de conexiones adecuada a la aplicación en lugar de crear repetidamente infraestructura de red innecesaria. También valida las URL remotas, los tamaños de respuesta y los tipos de contenido cuando la fuente no es de confianza.

## **Reutilizar Imágenes en Varias Diapositivas**

Si la misma imagen se necesita más de una vez, añádela a la presentación una sola vez y reutiliza el [IPPImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ippimage/) devuelto al crear marcos de imagen adicionales. Esto evita cargar repetidamente los mismos datos de origen y hace explícita la relación entre el recurso de imagen compartido y sus usos.

Para gráficos que deben aparecer automáticamente en muchas diapositivas, como el logotipo de la empresa, considera colocar el marco de imagen en una [maestra de diapositiva](/slides/es/androidjava/slide-master/) o diseño en lugar de añadir una forma equivalente a cada diapositiva.

## **Usar una Imagen como Fondo de Diapositiva**

Una imagen de fondo se asigna al relleno de la diapositiva; no se añade como una forma de marco de imagen. Esto es útil cuando la imagen debe cubrir el fondo de la diapositiva y no debe manipularse como un objeto normal de la diapositiva.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("background.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) sourceImage.dispose();
    }

    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Picture);
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image);

    presentation.save("background-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para opciones de fondo adicionales, incluidas las de maestros y diseños, consulta [Fondo de Presentación](/slides/es/androidjava/presentation-background/).

## **Imágenes Incrustadas e Imágenes Enlazadas**

Las imágenes incrustadas y enlazadas tienen diferentes compromisos de portabilidad y tamaño de archivo:

- **Imagen incrustada:** los datos de la imagen se almacenan dentro de la presentación. La presentación es autónoma, pero el tamaño del archivo incluye los datos de la imagen.
- **Imagen enlazada:** la presentación almacena una ruta o URL a una imagen externa. Esto puede reducir el tamaño de la presentación, pero el recurso externo debe seguir accesible cuando se abre o renderiza la presentación.

Se puede crear una imagen enlazada asignando la ruta o URL externa a través de [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/islidespicture/) en lugar de incrustar los datos de la imagen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, null);
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png");

    presentation.save("linked-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Usa imágenes enlazadas solo cuando el entorno de despliegue pueda acceder de forma fiable al recurso externo. Para presentaciones que deben funcionar sin conexión o trasladarse entre sistemas, las imágenes incrustadas suelen ser más seguras.

## **Trabajar con Imágenes SVG**

SVG es un formato vectorial, por lo que puede ser útil para iconos, diagramas y otros gráficos que deben escalar sin perder tanto detalle como las imágenes raster. Aspose.Slides admite SVG tanto como recurso de imagen como fuente de formas editables de diapositiva.

### **Agregar un SVG como Imagen**

Crea un [SvgImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/svgimage/), añádelo a la colección de imágenes y coloca el recurso de imagen resultante en un marco de imagen.

```java
import com.aspose.slides.*;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("icon.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    IPPImage image = presentation.getImages().addImage(svgImage);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image);

    presentation.save("svg-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Archivos SVG con Recursos Externos**

Un SVG puede referenciar imágenes, hojas de estilo o fuentes externas. Para estos casos, [SvgImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/svgimage/) proporciona constructores que aceptan un [IExternalResourceResolver](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iexternalresourceresolver/) y una URI base. El resolvedor puede mapear una URI relativa a una URI absoluta permitida y devolver un flujo para el recurso solicitado.

El resolvedor pone los recursos externos a disposición mientras Aspose.Slides procesa el SVG, pero no reescribe el SVG en un documento autónomo. Si el SVG debe permanecer portable, incrusta sus recursos requeridos dentro del propio SVG, por ejemplo usando URIs `data:` para imágenes enlazadas.

Cuando los archivos SVG provienen de fuentes no confiables, restringe los esquemas, ubicaciones de archivo y hosts a los que el resolvedor pueda acceder. Los resolvedores de red también deben aplicar tiempos de espera, límites de tamaño de respuesta y validación de contenido.

### **Convertir SVG a Formas Editables**

Aspose.Slides puede convertir un SVG en un grupo de formas editables de diapositiva, similar al comando correspondiente de PowerPoint.

![PowerPoint Popup Menu](img_01_01.png)

Usa la sobrecarga [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ishapecollection/) que acepta un [ISvgImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isvgimage/) para realizar la conversión.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("diagram.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    SizeF slideSize = presentation.getSlideSize().getSize();
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Utiliza la conversión SVG‑a‑formas cuando los elementos vectoriales individuales necesiten editarse como formas de PowerPoint. Si el SVG solo necesita mostrarse, mantenerlo como imagen es más sencillo y evita crear muchas formas separadas.

## **Reemplazar un Recurso de Imagen Existente**

Usa [IPPImage.replaceImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ippimage/) cuando quieras sustituir un recurso de imagen existente. Esto es especialmente útil para gráficos compartidos como logotipos.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IPPImage imageToReplace = presentation.getImages().get_Item(0);

    IImage replacementImage = Images.fromFile("new-logo.png");
    try {
        imageToReplace.replaceImage(replacementImage);
    } finally {
        if (replacementImage != null) replacementImage.dispose();
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Si varios marcos de imagen, fondos, maestros o diseños usan el mismo recurso de imagen, reemplazar ese recurso actualiza todos esos usos. Si solo debe cambiar un marco de imagen, asigna una imagen diferente a ese marco en lugar de reemplazar el recurso compartido.

`replaceImage` también ofrece sobrecargas que aceptan una matriz de bytes u otro [IPPImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ippimage/).

## **Guía Práctica de Gestión de Imágenes**

### **Controlar el Tamaño de la Presentación**

Las imágenes raster grandes pueden hacer que una presentación sea innecesariamente grande. Usa imágenes de origen con dimensiones adecuadas al tamaño de visualización previsto, reutiliza recursos de imagen compartidos cuando sea posible y evita incrustar copias repetidas del mismo gráfico de alta resolución.

Para imágenes raster que ya se han colocado en marcos de imagen, [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipicturefillformat/) puede reducir los datos de la imagen según la resolución seleccionada y la configuración de recorte. Esto es procesamiento de marco de imagen, no gestión de colección de imágenes, por lo que consulta [Marco de Imagen](/slides/es/androidjava/picture-frame/) para operaciones de formato relacionadas.

### **Elegir Entre Contenido Incrustado y Enlazado**

Incrustar hace que la presentación sea portátil porque todos los datos de imagen necesarios viajan con el archivo. Enlazar puede reducir el tamaño del archivo, pero introduce una dependencia externa. Usa enlaces solo cuando esa dependencia sea aceptable y estable.

### **Reutilizar la Identidad Visual Compartida**

Para logotipos, marcas de agua o gráficos decorativos repetidos, utiliza un único recurso de imagen y reutilízalo. Si el gráfico pertenece al diseño de la presentación más que al contenido de las diapositivas, colócalo en un maestro o diseño para que sea heredado por las diapositivas correspondientes.

### **Mantener los Recursos SVG Portables**

Un SVG autónomo es más fácil de mover y renderizar de forma consistente que un SVG que depende de archivos externos o recursos de red. Cuando sea posible, incrusta los recursos requeridos antes de importar el SVG. Convierte SVG a formas solo cuando los elementos vectoriales individuales necesiten editarse.

### **Usar la API de Imagen Multiplataforma Moderna**

Para código nuevo de Android via Java, usa las API [IImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iimage/) y [Images](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/images/) de Aspose.Slides en lugar de la API pública heredada basada en `android.graphics.Bitmap`. Consulta [API Moderna](/slides/es/androidjava/modern-api/) para obtener orientación de migración.

Los formatos WMF y EMF requieren consideraciones especiales. Cuando estos formatos se pasan a través de un [IImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iimage/), [ImageCollection.addImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/imagecollection/) convierte el metarchivo a una representación PNG raster antes de insertarlo. Si es importante preservar los datos del metarchivo, usa la sobrecarga basada en flujo de [ImageCollection.addImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/imagecollection/). Generar contenido EMF a partir de hojas de cálculo u otros productos es un flujo de integración separado y está fuera del alcance de este artículo.

## **FAQ**

**¿Cuál es la diferencia entre la colección de imágenes y un marco de imagen?**

La colección de imágenes almacena recursos de imagen reutilizables. Un marco de imagen es una forma de diapositiva que muestra uno de esos recursos y proporciona formato específico de imagen como recorte y efectos.

**¿Cuál es la mejor forma de sustituir el mismo logotipo en todas partes?**

Si el logotipo ya está compartido como un recurso de imagen, sustituye ese recurso con [IPPImage.replaceImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ippimage/). Para una identidad visual en toda la presentación, colocar el logotipo en un maestro o diseño también puede reducir el contenido duplicado de las diapositivas.

**¿Por qué una imagen enlazada desaparece en otro equipo?**

Una imagen enlazada depende de su archivo o URL externo. Si ese recurso no puede alcanzarse desde el otro equipo, la imagen enlazada puede quedar indisponible. Incrusta la imagen cuando la presentación deba ser autónoma.

**¿Se puede editar un SVG insertado como formas de PowerPoint?**

Sí. Convierte el SVG con [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ishapecollection/); el grupo resultante contiene formas de diapositiva editables en lugar de una única imagen SVG.

**¿Cómo puedo mantener presentaciones con muchas imágenes más pequeñas?**

Reutiliza recursos de imagen compartidos, evita fuentes raster innecesariamente grandes, comprime las imágenes raster adecuadas cuando sea pertinente, conserva la identidad visual repetida en maestros o diseños y usa imágenes enlazadas solo cuando una dependencia externa sea aceptable.