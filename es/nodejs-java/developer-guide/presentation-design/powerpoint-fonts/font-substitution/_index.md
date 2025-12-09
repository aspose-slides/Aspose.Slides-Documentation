---
title: Sustitución de fuentes - API de JavaScript para PowerPoint
linktitle: Sustitución de fuentes
type: docs
weight: 70
url: /es/nodejs-java/font-substitution/
keywords: "Fuente, fuente sustituta, presentación de PowerPoint, Java, Aspose.Slides para Node.js mediante Java"
description: "Sustituir fuente en PowerPoint con JavaScript"
---

## **Establecer reglas de sustitución de fuentes**

Aspose.Slides le permite establecer reglas para fuentes que determinan qué debe hacerse en ciertas condiciones (por ejemplo, cuando una fuente no se puede acceder) de esta manera:

1. Cargue la presentación correspondiente.
2. Cargue la fuente que será reemplazada.
3. Cargue la nueva fuente.
4. Añada una regla para el reemplazo.
5. Añada la regla a la colección de reglas de reemplazo de fuentes de la presentación.
6. Genere la imagen de la diapositiva para observar el efecto.

Este código JavaScript muestra el proceso de sustitución de fuentes:
```javascript
// Carga una presentación
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    // Carga la fuente origen que será reemplazada
    var sourceFont = new aspose.slides.FontData("SomeRareFont");
    // Carga la nueva fuente
    var destFont = new aspose.slides.FontData("Arial");
    // Añade una regla de fuente para el reemplazo de fuente
    var fontSubstRule = new aspose.slides.FontSubstRule(sourceFont, destFont, aspose.slides.FontSubstCondition.WhenInaccessible);
    // Añade la regla a la colección de reglas de sustitución de fuentes
    var fontSubstRuleCollection = new aspose.slides.FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    // Añade una colección de reglas de fuente a la lista de reglas
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    // La fuente Arial se usará en lugar de SomeRareFont cuando ésta no sea accesible
    var slideImage = pres.getSlides().get_Item(0).getImage(1.0, 1.0);
    // Guarda la imagen en disco en formato JPEG
    try {
        slideImage.save("Thumbnail_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert title="NOTA" color="warning" %}} 

Puede que desee ver [**Reemplazo de fuentes**](/slides/es/nodejs-java/font-replacement/).

{{% /alert %}}

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre el reemplazo de fuentes y la sustitución de fuentes?**

[Replacement](/slides/es/nodejs-java/font-replacement/) es una sobrescritura forzada de una fuente por otra en toda la presentación. La sustitución es una regla que se activa bajo una condición específica, por ejemplo cuando la fuente original no está disponible, y entonces se utiliza una fuente de respaldo designada.

**¿Cuándo se aplican exactamente las reglas de sustitución?**

Las reglas participan en la secuencia estándar de [selección de fuentes](/slides/es/nodejs-java/font-selection-sequence/) que se evalúa durante la carga, el renderizado y la conversión; si la fuente elegida no está disponible, se aplica el reemplazo o la sustitución.

**¿Cuál es el comportamiento predeterminado si no se configura ni reemplazo ni sustitución y la fuente falta en el sistema?**

La biblioteca intentará elegir la fuente del sistema más cercana disponible, similar a cómo se comportaría PowerPoint.

**¿Puedo adjuntar fuentes externas personalizadas en tiempo de ejecución para evitar la sustitución?**

Sí. Puede [añadir fuentes externas](/slides/es/nodejs-java/custom-font/) en tiempo de ejecución para que la biblioteca las tenga en cuenta para la selección y el renderizado, incluidas conversiones posteriores.

**¿Aspose distribuye alguna fuente con la biblioteca?**

No. Aspose no distribuye fuentes de pago ni gratuitas; usted añade y usa fuentes bajo su propia discreción y responsabilidad.

**¿Existen diferencias en el comportamiento de sustitución en Windows, Linux y macOS?**

Sí. La detección de fuentes comienza en los directorios de fuentes del sistema operativo. El conjunto de fuentes predeterminadas disponibles y las rutas de búsqueda difieren entre plataformas, lo que afecta la disponibilidad y la necesidad de sustitución.

**¿Cómo debo preparar el entorno para minimizar sustituciones inesperadas durante conversiones por lotes?**

Sincronice el conjunto de fuentes entre máquinas o contenedores, [añada las fuentes externas](/slides/es/nodejs-java/custom-font/) necesarias para los documentos de salida, y [incorpore fuentes](/slides/es/nodejs-java/embedded-font/) en las presentaciones cuando sea posible para que las fuentes elegidas estén disponibles durante el renderizado.