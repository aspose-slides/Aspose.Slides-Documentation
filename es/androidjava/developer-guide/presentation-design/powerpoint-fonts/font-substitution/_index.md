---
title: Configurar sustitución de fuentes en presentaciones en Android
linktitle: Sustitución de fuentes
type: docs
weight: 70
url: /es/androidjava/font-substitution/
keywords:
- fuente
- sustituir fuente
- sustitución de fuentes
- reemplazar fuente
- reemplazo de fuentes
- regla de sustitución
- regla de reemplazo
- PowerPoint
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "Permite una sustitución óptima de fuentes en Aspose.Slides para Android mediante Java al convertir presentaciones de PowerPoint y OpenDocument a otros formatos de archivo."
---

## **Establecer reglas de sustitución de fuentes**

Aspose.Slides le permite establecer reglas para fuentes que determinan qué debe hacerse en determinadas condiciones (por ejemplo, cuando una fuente no está disponible) de la siguiente manera:

1. Cargar la presentación correspondiente.
2. Cargar la fuente que será reemplazada.
3. Cargar la nueva fuente.
4. Agregar una regla para el reemplazo.
5. Agregar la regla a la colección de reglas de reemplazo de fuentes de la presentación.
6. Generar la imagen de la diapositiva para observar el efecto.

Este código Java demuestra el proceso de sustitución de fuentes:
```java
// Carga una presentación
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Carga la fuente origen que será reemplazada
    IFontData sourceFont = new FontData("SomeRareFont");
    
    // Carga la nueva fuente
    IFontData destFont = new FontData("Arial");
    
    // Añade una regla de fuente para el reemplazo de fuentes
    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);
    
    // Añade la regla a la colección de reglas de sustitución de fuentes
    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    
    // Añade una colección de reglas de fuentes a la lista de reglas
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    
    // La fuente Arial se usará en lugar de SomeRareFont cuando esta última sea inaccesible
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);
    
    // Guarda la imagen en disco en formato JPEG
    try {
          slideImage.save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```


{{%  alert title="NOTE"  color="warning"   %}} 
Es posible que desee ver [**Font Replacement**](/slides/es/androidjava/font-replacement/).
{{% /alert %}}

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre reemplazo de fuentes y sustitución de fuentes?**

[Reemplazo](/slides/es/androidjava/font-replacement/) es una sustitución forzada de una fuente por otra en toda la presentación. La sustitución es una regla que se activa bajo una condición específica, por ejemplo cuando la fuente original no está disponible, y entonces se utiliza una fuente de respaldo designada.

**¿Cuándo se aplican exactamente las reglas de sustitución?**

Las reglas participan en la secuencia estándar de [selección de fuentes](/slides/es/androidjava/font-selection-sequence/) que se evalúa durante la carga, renderizado y conversión; si la fuente elegida no está disponible, se aplica el reemplazo o la sustitución.

**¿Cuál es el comportamiento predeterminado si no se configura ni reemplazo ni sustitución y la fuente falta en el sistema?**

La biblioteca intentará seleccionar la fuente del sistema más cercana disponible, similar a como lo haría PowerPoint.

**¿Puedo adjuntar fuentes externas personalizadas en tiempo de ejecución para evitar la sustitución?**

Sí. Puede [agregar fuentes externas](/slides/es/androidjava/custom-font/) en tiempo de ejecución para que la biblioteca las tenga en cuenta para la selección y renderizado, incluidas las conversiones posteriores.

**¿Aspose distribuye fuentes con la biblioteca?**

No. Aspose no distribuye fuentes pagas o gratuitas; usted agrega y usa fuentes bajo su propia discreción y responsabilidad.

**¿Existen diferencias en el comportamiento de sustitución en Windows, Linux y macOS?**

Sí. La detección de fuentes comienza en los directorios de fuentes del sistema operativo. El conjunto de fuentes predeterminadas disponibles y las rutas de búsqueda difieren entre plataformas, lo que afecta la disponibilidad y la necesidad de sustitución.

**¿Cómo debo preparar el entorno para minimizar la sustitución inesperada durante conversiones por lotes?**

Sincronice el conjunto de fuentes entre máquinas o contenedores, [agregue las fuentes externas](/slides/es/androidjava/custom-font/) requeridas para los documentos de salida, y [incorpore fuentes](/slides/es/androidjava/embedded-font/) en las presentaciones cuando sea posible, de modo que las fuentes elegidas estén disponibles durante el renderizado.