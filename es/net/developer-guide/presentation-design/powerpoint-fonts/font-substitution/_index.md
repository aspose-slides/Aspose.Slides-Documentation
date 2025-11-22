---
title: Sustitución de fuentes - API C# de PowerPoint
linktitle: Sustitución de fuentes
type: docs
weight: 70
url: /es/net/font-substitution/
keywords:
- fuente
- sustituir fuente
- PowerPoint
- presentación
- C#
- Csharp
- Aspose.Slides for .NET
description: La API de PowerPoint en C# le permite sustituir fuentes dentro de las presentaciones
---

## **Obteniendo sustitución de fuentes**

Para permitirle averiguar las fuentes de la presentación que se sustituyen durante el proceso de renderizado de una presentación, Aspose.Slides proporciona el método [GetSubstitution](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getsubstitutions/) de la interfaz [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/).

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


## **Estableciendo reglas de sustitución de fuentes**

Aspose.Slides le permite establecer reglas para fuentes que determinan qué debe hacerse en determinadas condiciones (por ejemplo, cuando no se puede acceder a una fuente) de la siguiente manera:

1. Cargue la presentación correspondiente.
2. Cargue la fuente que será reemplazada.
3. Cargue la nueva fuente.
4. Añada una regla para el reemplazo.
5. Agregue la regla a la colección de reglas de reemplazo de fuentes de la presentación.
6. Genere la imagen de la diapositiva para observar el efecto.

Este código C# demuestra el proceso de sustitución de fuentes:
```c#
 // Carga una presentación
 Presentation presentation = new Presentation("Fonts.pptx");
 
 // Carga la fuente origen que será reemplazada
 IFontData sourceFont = new FontData("SomeRareFont");
 
 // Carga la fuente nueva
 IFontData destFont = new FontData("Arial");
 
 // Añade una regla de fuente para el reemplazo de fuentes
 IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);
 
 // Añade la regla a la colección de reglas de sustitución de fuentes
 IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
 fontSubstRuleCollection.Add(fontSubstRule);
 
 // Añade la colección de reglas de fuente a la lista de reglas
 presentation.FontsManager.FontSubstRuleList = fontSubstRuleCollection;
 
 using (IImage image = presentation.Slides[0].GetImage(1f, 1f))
 {
     // Guarda la imagen en disco en formato JPEG
     image.Save("Thumbnail_out.jpg", ImageFormat.Jpeg);
 }
```


{{%  alert title="NOTE"  color="warning"   %}} 
Tal vez desee ver [**Reemplazo de fuentes**](/slides/es/net/font-replacement/). 
{{% /alert %}}

## **FAQ**

**¿Cuál es la diferencia entre reemplazo de fuentes y sustitución de fuentes?**

[Reemplazo](/slides/es/net/font-replacement/) es una sobrescritura forzada de una fuente por otra en toda la presentación. La sustitución es una regla que se activa bajo una condición específica, por ejemplo cuando la fuente original no está disponible, y entonces se utiliza una fuente alternativa designada.

**¿Cuándo se aplican exactamente las reglas de sustitución?**

Las reglas participan en la secuencia estándar de [selección de fuentes](/slides/es/net/font-selection-sequence/) que se evalúa durante la carga, el renderizado y la conversión; si la fuente elegida no está disponible, se aplica el reemplazo o la sustitución.

**¿Cuál es el comportamiento predeterminado si no se configura ni reemplazo ni sustitución y la fuente falta en el sistema?**

La biblioteca intentará elegir la fuente del sistema más cercana disponible, similar a como lo haría PowerPoint.

**¿Puedo adjuntar fuentes externas personalizadas en tiempo de ejecución para evitar la sustitución?**

Sí. Puede [agregar fuentes externas](/slides/es/net/custom-font/) en tiempo de ejecución para que la biblioteca las considere al seleccionar y renderizar, incluidas las conversiones posteriores.

**¿Aspose distribuye alguna fuente con la biblioteca?**

No. Aspose no distribuye fuentes pagas ni gratuitas; usted agrega y usa las fuentes bajo su propia discreción y responsabilidad.

**¿Existen diferencias en el comportamiento de sustitución en Windows, Linux y macOS?**

Sí. El descubrimiento de fuentes comienza en los directorios de fuentes del sistema operativo. El conjunto de fuentes disponibles por defecto y las rutas de búsqueda difieren entre plataformas, lo que afecta la disponibilidad y la necesidad de sustitución.

**¿Cómo debo preparar el entorno para minimizar sustituciones inesperadas durante conversiones por lotes?**

Sincronice el conjunto de fuentes entre máquinas o contenedores, [agregue las fuentes externas](/slides/es/net/custom-font/) requeridas para los documentos de salida y [incorpore fuentes](/slides/es/net/embedded-font/) en las presentaciones cuando sea posible, de modo que las fuentes elegidas estén disponibles durante el renderizado.