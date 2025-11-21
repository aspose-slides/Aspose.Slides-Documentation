---
title: Renderizar una diapositiva como una imagen SVG
type: docs
weight: 50
url: /es/nodejs-java/render-a-slide-as-an-svg-image/
---

## **Formato SVG**

SVG—un acrónimo de Scalable Vector Graphics—es un tipo o formato gráfico estándar utilizado para renderizar imágenes bidimensionales. SVG almacena imágenes como vectores en XML con detalles que definen su comportamiento o apariencia. 

SVG es uno de los pocos formatos de imágenes que cumple con estándares muy altos en estos aspectos: escalabilidad, interactividad, rendimiento, accesibilidad, programabilidad y otros. Por estas razones, se utiliza comúnmente en el desarrollo web. 

Puede que desee usar archivos SVG cuando necesite

- **imprimir su presentación en un *formato muy grande*.** Las imágenes SVG pueden escalar a cualquier resolución o nivel. Puede redimensionar las imágenes SVG tantas veces como sea necesario sin sacrificar la calidad.
- **utilizar gráficos y diagramas de sus diapositivas en *diferentes medios o plataformas*.** La mayoría de los lectores pueden interpretar archivos SVG. 
- **usar el *tamaño más pequeño posible de imágenes***. Los archivos SVG suelen ser más pequeños que sus equivalentes de alta resolución en otros formatos, especialmente aquellos basados en mapas de bits (JPEG o PNG).

## **Renderizar diapositivas como imágenes SVG**

Aspose.Slides for Node.js a través de Java le permite exportar diapositivas de sus presentaciones como imágenes SVG. Siga estos pasos para generar imágenes SVG:

1. Cree una instancia de la clase Presentation.
2. Recorra todas las diapositivas de la presentación.
3. Escriba cada diapositiva en su propio archivo SVG mediante FileOutputStream.

{{% alert color="primary" %}} 
Puede que desee probar nuestra [aplicación web gratuita](https://products.aspose.app/slides/conversion/ppt-to-svg) en la que implementamos la función de conversión de PPT a SVG de Aspose.Slides para Node.js a través de Java.
{{% /alert %}} 

Este fragmento de código en JavaScript le muestra cómo convertir PPT a SVG usando Aspose.Slides:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var fileStream = java.newInstanceSync("java.io.FileOutputStream", ("slide-" + index) + ".svg");
        try {
            slide.writeAsSvg(fileStream);
        } finally {
            fileStream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Preguntas frecuentes**

**¿Por qué el SVG resultante puede verse diferente en distintos navegadores?**

El soporte de características específicas de SVG se implementa de manera diferente en los motores de los navegadores. Los parámetros [SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/) ayudan a suavizar las incompatibilidades.

**¿Es posible exportar no solo diapositivas sino también formas individuales a SVG?**

Sí. Cualquier [forma puede guardarse como un SVG independiente](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/), lo cual es conveniente para íconos, pictogramas y reutilizar gráficos.

**¿Se pueden combinar varias diapositivas en un solo SVG (tira/documento)?**

El escenario estándar es una diapositiva → un SVG. Combinar varias diapositivas en un único lienzo SVG es un paso de postprocesamiento que se realiza a nivel de aplicación.