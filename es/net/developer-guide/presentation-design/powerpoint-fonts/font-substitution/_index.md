---
title: Configurar la sustitución de fuentes en presentaciones en .NET
linktitle: Sustitución de fuentes
type: docs
weight: 70
url: /es/net/font-substitution/
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
- .NET
- C#
- Aspose.Slides
description: "Habilite la sustitución óptima de fuentes en Aspose.Slides para .NET al convertir presentaciones de PowerPoint y OpenDocument a otros formatos de archivo."
---

## **Obtener sustituciones de fuentes**

Para que pueda descubrir las fuentes de la presentación que se sustituyen durante el proceso de renderizado de una presentación, Aspose.Slides proporciona el método [GetSubstitution](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getsubstitutions/) de la interfaz [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/).

El código C# muestra cómo obtener todas las sustituciones de fuentes que se realizan cuando se renderiza una presentación:
```c#
using (Presentation pres = new Presentation(@"Presentation.pptx"))
{
    foreach (var fontSubstitution in pres.FontsManager.GetSubstitutions())
    {
        Console.WriteLine("{0} -> {1}", fontSubstitution.OriginalFontName, fontSubstitution.SubstitutedFontName);
    }
}
```


## **Establecer reglas de sustitución de fuentes**

Aspose.Slides le permite establecer reglas para fuentes que determinan qué se debe hacer en ciertas condiciones (por ejemplo, cuando una fuente no se puede acceder) de la siguiente manera:

1. Cargue la presentación correspondiente.
2. Cargue la fuente que será reemplazada.
3. Cargue la nueva fuente.
4. Añada una regla para el reemplazo.
5. Añada la regla a la colección de reglas de sustitución de fuentes de la presentación.
6. Genere la imagen de la diapositiva para observar el efecto.

Este código C# demuestra el proceso de sustitución de fuentes:
```c#
 // Carga una presentación
Presentation presentation = new Presentation("Fonts.pptx");

// Carga la fuente origen que será reemplazada
IFontData sourceFont = new FontData("SomeRareFont");

// Carga la nueva fuente
IFontData destFont = new FontData("Arial");

// Añade una regla de fuente para el reemplazo de fuentes
IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);

// Añade la regla a la colección de reglas de sustitución de fuentes
IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
fontSubstRuleCollection.Add(fontSubstRule);

// Añade la colección de reglas de fuentes a la lista de reglas
presentation.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

using (IImage image = presentation.Slides[0].GetImage(1f, 1f))
{
    // Guarda la imagen en disco en formato JPEG
    image.Save("Thumbnail_out.jpg", ImageFormat.Jpeg);
}
```


{{%  alert title="NOTE"  color="warning"   %}} 
Es posible que desee consultar [**Reemplazo de fuentes**](/slides/es/net/font-replacement/). 
{{% /alert %}}

## **FAQ**

**¿Cuál es la diferencia entre reemplazo de fuentes y sustitución de fuentes?**

[Replacement](/slides/es/net/font-replacement/) es una sobrescritura forzada de una fuente por otra en toda la presentación. La sustitución es una regla que se activa bajo una condición específica, por ejemplo cuando la fuente original no está disponible, y entonces se utiliza una fuente de respaldo designada.

**¿Cuándo se aplican exactamente las reglas de sustitución?**

Las reglas participan en la secuencia estándar de [font selection](/slides/es/net/font-selection-sequence/) que se evalúa durante la carga, el renderizado y la conversión; si la fuente elegida no está disponible, se aplica el reemplazo o la sustitución.

**¿Cuál es el comportamiento predeterminado si no se configura ni reemplazo ni sustitución y la fuente falta en el sistema?**

La biblioteca intentará seleccionar la fuente del sistema disponible más cercana, de manera similar a como lo haría PowerPoint.

**¿Puedo adjuntar fuentes externas personalizadas en tiempo de ejecución para evitar la sustitución?**

Sí. Puede [add external fonts](/slides/es/net/custom-font/) en tiempo de ejecución para que la biblioteca las tenga en cuenta al seleccionar y renderizar, incluyendo conversiones posteriores.

**¿Aspose distribuye alguna fuente con la biblioteca?**

No. Aspose no distribuye fuentes pagas ni gratuitas; usted agrega y usa fuentes bajo su propia discreción y responsabilidad.

**¿Existen diferencias en el comportamiento de sustitución en Windows, Linux y macOS?**

Sí. La detección de fuentes comienza en los directorios de fuentes del sistema operativo. El conjunto de fuentes predeterminadas disponibles y las rutas de búsqueda difieren entre plataformas, lo que afecta la disponibilidad y la necesidad de sustitución.

**¿Cómo debería preparar el entorno para minimizar sustituciones inesperadas durante conversiones por lotes?**

Sincronice el conjunto de fuentes entre máquinas o contenedores, [add the external fonts](/slides/es/net/custom-font/) necesarias para los documentos de salida, y [embed fonts](/slides/es/net/embedded-font/) en las presentaciones cuando sea posible para que las fuentes seleccionadas estén disponibles durante el renderizado.