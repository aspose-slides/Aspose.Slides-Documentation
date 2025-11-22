---
title: Tamaño de diapositiva
type: docs
weight: 70
url: /es/nodejs-java/slide-size/
---

## **Tamaños de diapositivas en presentaciones de PowerPoint**

Aspose.Slides para Node.js a través de Java le permite cambiar el tamaño o la relación de aspecto de las diapositivas en presentaciones de PowerPoint. Si planea imprimir su presentación o mostrar sus diapositivas en una pantalla, debe prestar atención al tamaño o la relación de aspecto de las diapositivas.

Estos son los tamaños de diapositivas y relaciones de aspecto más comunes:

- **Estándar (relación de aspecto 4:3)**

  Si su presentación se mostrará o visualizará en dispositivos o pantallas relativamente antiguos, es posible que desee usar esta configuración. 

- **Panorámica (relación de aspecto 16:9)** 

  Si su presentación se verá en proyectores o pantallas modernos, es posible que desee usar esta configuración. 

No puede usar varias configuraciones de tamaño de diapositiva en una sola presentación. Cuando selecciona un tamaño de diapositiva para una presentación, esa configuración se aplica a todas las diapositivas de la presentación. 

Si prefiere usar un tamaño de diapositiva especial para sus presentaciones, le recomendamos encarecidamente hacerlo temprano. Idealmente, debe especificar su diapositiva preferida al principio, es decir, al configurar la presentación, antes de agregar cualquier contenido. De esta manera, evita complicaciones derivadas de cambios (futuros) en el tamaño de las diapositivas. 

{{% alert color="primary" %}} 

 Cuando usa Aspose.Slides para crear una presentación, todas las diapositivas de la presentación obtienen automáticamente el tamaño estándar o la relación de aspecto 4:3.

{{% /alert %}} 

## **Cambiar el tamaño de la diapositiva en presentaciones**

 Este fragmento de código muestra cómo cambiar el tamaño de la diapositiva en una presentación en JavaScript usando Aspose.Slides:
```javascript
var pres = new aspose.slides.Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(aspose.slides.SlideSizeType.OnScreen16x9, aspose.slides.SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Especificar tamaños de diapositiva personalizados en presentaciones**

Si los tamaños de diapositiva comunes (4:3 y 16:9) no son adecuados para su trabajo, puede decidir usar un tamaño de diapositiva específico o único. Por ejemplo, si planea imprimir diapositivas de tamaño completo de su presentación en un diseño de página personalizado o si desea mostrar su presentación en ciertos tipos de pantalla, probablemente se beneficiará al usar una configuración de tamaño personalizada para su presentación. 

Este fragmento de código muestra cómo usar Aspose.Slides para Node.js a través de Java para especificar un tamaño de diapositiva personalizado para una presentación en JavaScript:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, aspose.slides.SlideSizeScaleType.DoNotScale);// tamaño de papel A4
    pres.save("pres-a4-slide-size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Resolver problemas al cambiar el tamaño de las diapositivas en presentaciones**

Después de cambiar el tamaño de la diapositiva de una presentación, el contenido de las diapositivas (imágenes o objetos, por ejemplo) puede distorsionarse. Por defecto, los objetos se redimensionan automáticamente para ajustarse al nuevo tamaño de la diapositiva. Sin embargo, al cambiar el tamaño de la diapositiva de una presentación, puede especificar una configuración que determina cómo Aspose.Slides maneja el contenido de las diapositivas.

Dependiendo de lo que pretenda hacer o lograr, puede usar cualquiera de estas configuraciones:

- `DoNotScale`

  Si NO desea que los objetos de las diapositivas se redimensionen, use esta configuración.

- `EnsureFit`

  Si desea escalar a un tamaño de diapositiva más pequeño y necesita que Aspose.Slides reduzca los objetos de las diapositivas para asegurarse de que todos quepan (de este modo, evita la pérdida de contenido), use esta configuración. 

- `Maximize`

  Si desea escalar a un tamaño de diapositiva más grande y necesita que Aspose.Slides aumente los objetos de las diapositivas para que sean proporcionales al nuevo tamaño, use esta configuración. 

Este fragmento de código muestra cómo usar la configuración `Maximize` al cambiar el tamaño de la diapositiva de una presentación:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(aspose.slides.SlideSizeType.Ledger, aspose.slides.SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Preguntas frecuentes**

**¿Puedo establecer un tamaño de diapositiva personalizado usando unidades distintas a pulgadas (por ejemplo, puntos o milímetros)?**

Sí. Aspose.Slides usa puntos internamente, donde 1 punto equivale a 1/72 de pulgada. Puede convertir cualquier unidad (como milímetros o centímetros) a puntos y usar los valores convertidos para definir el ancho y la altura de la diapositiva.

**¿Un tamaño de diapositiva personalizado muy grande afectará el rendimiento y el uso de memoria durante el renderizado?**

Sí. Dimensiones de diapositiva más grandes (en puntos) combinadas con una escala de renderizado mayor generan un mayor consumo de memoria y tiempos de procesamiento más largos. Apunte a un tamaño de diapositiva práctico y ajuste la escala de renderizado solo cuando sea necesario para lograr la calidad de salida deseada.

**¿Puedo definir un tamaño de diapositiva no estándar y luego fusionar diapositivas de presentaciones que tienen diferentes tamaños?**

No puede [fusionar presentaciones](/slides/es/nodejs-java/merge-presentation/) mientras tengan diferentes tamaños de diapositiva; primero, cambie el tamaño de una presentación para que coincida con la otra. Al cambiar el tamaño de la diapositiva, puede elegir cómo se maneja el contenido existente mediante la opción [SlideSizeScaleType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesizescaletype/). Después de alinear los tamaños, puede fusionar diapositivas conservando el formato.

**¿Puedo generar miniaturas para formas individuales o regiones específicas de una diapositiva, y respetarán el nuevo tamaño de diapositiva?**

Sí. Aspose.Slides puede renderizar miniaturas para [diapositivas completas](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) así como para [formas seleccionadas](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage). Las imágenes resultantes reflejan el tamaño y la relación de aspecto actuales de la diapositiva, garantizando un encuadre y geometría consistentes.