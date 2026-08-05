---
title: Cambiar el tamaño de la diapositiva de la presentación en JavaScript
linktitle: Tamaño de diapositiva
type: docs
weight: 70
url: /es/nodejs-java/slide-size/
keywords:
- tamaño de diapositiva
- relación de aspecto
- estándar
- panorámico
- 4:3
- 16:9
- establecer tamaño de diapositiva
- cambiar tamaño de diapositiva
- tamaño de diapositiva personalizado
- tamaño de diapositiva especial
- tamaño de diapositiva único
- diapositiva de tamaño completo
- tipo de pantalla
- no escalar
- asegurar ajuste
- maximizar
- PowerPoint
- OpenDocument
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda a redimensionar rápidamente diapositivas en archivos PPT, PPTX y ODP con Node.js y Aspose.Slides, optimice presentaciones para cualquier pantalla sin perder calidad."
---
## **Introducción**

Aspose.Slides proporciona herramientas completas para ajustar el tamaño de la diapositiva y la relación de aspecto en presentaciones de PowerPoint, algo crítico tanto para la impresión como para la visualización en pantalla. 

Tamaños y relaciones de diapositivas más populares:

- **Estándar (relación de aspecto 4:3)**: Ideal para pantallas y dispositivos antiguos.
- **Panorámico (relación de aspecto 16:9)**: Recomendado para proyectores y pantallas modernas.

Asegúrese de mantener la coherencia en toda la presentación, ya que un único tamaño y relación de aspecto se aplican a todas las diapositivas. Para obtener resultados óptimos, establezca las dimensiones de las diapositivas al inicio del proceso de creación de la presentación para evitar complicaciones.

{{% alert color="primary" %}} 
Por defecto, las presentaciones creadas con Aspose.Slides utilizan la relación de aspecto estándar 4:3.
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

## **Especificar tamaños personalizados de diapositivas en presentaciones**

Si considera que los tamaños de diapositiva comunes (4:3 y 16:9) no se adaptan a su trabajo, puede decidir usar un tamaño de diapositiva específico o único. Por ejemplo, si planea imprimir diapositivas a tamaño completo de su presentación en un diseño de página personalizado o si desea mostrar su presentación en ciertos tipos de pantalla, probablemente se beneficie de utilizar una configuración de tamaño personalizada para su presentación. 

Este fragmento de código muestra cómo usar Aspose.Slides para Node.js mediante Java para especificar un tamaño de diapositiva personalizado para una presentación en JavaScript:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, aspose.slides.SlideSizeScaleType.DoNotScale);// Tamaño de papel A4
    pres.save("pres-a4-slide-size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Gestionar problemas al cambiar el tamaño de las diapositivas en presentaciones**

Después de cambiar el tamaño de la diapositiva de una presentación, el contenido de las diapositivas (imágenes u objetos, por ejemplo) puede distorsionarse. Por defecto, los objetos se redimensionan automáticamente para adaptarse al nuevo tamaño de diapositiva. Sin embargo, al cambiar el tamaño de la diapositiva de una presentación, puede especificar una configuración que determina cómo Aspose.Slides gestiona el contenido de las diapositivas.

Dependiendo de lo que pretenda hacer o lograr, puede usar cualquiera de estas configuraciones:

- `DoNotScale`

  Si NO desea que los objetos en las diapositivas se redimensionen, utilice esta configuración.

- `EnsureFit`

  Si desea reducir a un tamaño de diapositiva más pequeño y necesita que Aspose.Slides reduzca los objetos de las diapositivas para garantizar que todos quepan (de este modo, evita perder contenido), utilice esta configuración. 

- `Maximize`

  Si desea ampliar a un tamaño de diapositiva mayor y necesita que Aspose.Slides aumente los objetos de las diapositivas para que sean proporcionales al nuevo tamaño, utilice esta configuración. 

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

## **FAQ**

**¿Puedo establecer un tamaño de diapositiva personalizado usando unidades diferentes a pulgadas (por ejemplo, puntos o milímetros)?**

Sí. Aspose.Slides utiliza puntos internamente, donde 1 punto equivale a 1/72 de pulgada. Puede convertir cualquier unidad (como milímetros o centímetros) a puntos y usar los valores convertidos para definir el ancho y la altura de la diapositiva.

**¿Un tamaño de diapositiva personalizado muy grande afectará el rendimiento y el uso de memoria durante la renderización?**

Sí. Dimensiones de diapositiva mayores (en puntos) combinadas con una escala de renderizado más alta provocan un mayor consumo de memoria y tiempos de procesamiento más largos. Apunte a un tamaño de diapositiva práctico y ajuste la escala de renderizado solo cuando sea necesario para obtener la calidad de salida deseada.

**¿Puedo definir un tamaño de diapositiva no estándar y luego combinar diapositivas de presentaciones que tengan tamaños diferentes?**

No puede [merge presentations](/slides/es/nodejs-java/merge-presentation/) mientras tengan diferentes tamaños de diapositiva — primero, cambie el tamaño de una presentación para que coincida con la otra. Al cambiar el tamaño de la diapositiva, puede elegir cómo se maneja el contenido existente mediante la opción [SlideSizeScaleType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slidesizescaletype/). Después de alinear los tamaños, puede combinar diapositivas conservando el formato.

**¿Puedo generar miniaturas para formas individuales o regiones específicas de una diapositiva, y respetarán el nuevo tamaño de diapositiva?**

Sí. Aspose.Slides puede generar miniaturas para [diapositivas completas](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slide/#getImage) así como para [formas seleccionadas](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shape/#getImage). Las imágenes resultantes reflejan el tamaño y la relación de aspecto actuales de la diapositiva, garantizando un encuadre y una geometría consistentes.