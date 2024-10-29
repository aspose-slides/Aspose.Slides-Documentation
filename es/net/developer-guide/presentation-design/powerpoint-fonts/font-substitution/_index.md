---
title: Sustitución de Fuentes - API de PowerPoint C#
linktitle: Sustitución de Fuentes
type: docs
weight: 70
url: /es/net/font-substitution/
keywords: 
- fuente
- fuente de sustitución
- PowerPoint
- presentación
- C#
- Csharp
- Aspose.Slides para .NET
description: La API de PowerPoint C# te permite sustituir fuentes dentro de presentaciones
---

## **Obteniendo la Sustitución de Fuentes**

Para permitirte descubrir las fuentes de presentación que son sustituidas durante un proceso de renderización de presentación, Aspose.Slides proporciona el método [GetSubstitution](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getsubstitutions/) de la interfaz [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/).

El código C# te muestra cómo obtener todas las sustituciones de fuente que se realizan cuando se renderiza una presentación:
```c#
using (Presentation pres = new Presentation(@"Presentation.pptx"))
{
    foreach (var fontSubstitution in pres.FontsManager.GetSubstitutions())
    {
        Console.WriteLine("{0} -> {1}", fontSubstitution.OriginalFontName, fontSubstitution.SubstitutedFontName);
    }
}
```


## **Estableciendo Reglas de Sustitución de Fuentes**

Aspose.Slides te permite establecer reglas para fuentes que determinan qué se debe hacer en ciertas condiciones (por ejemplo, cuando no se puede acceder a una fuente) de la siguiente manera:

1. Carga la presentación relevante.
2. Carga la fuente que será reemplazada.
3. Carga la nueva fuente.
4. Agrega una regla para el reemplazo.
5. Agrega la regla a la colección de reglas de reemplazo de fuentes de la presentación.
6. Genera la imagen de la diapositiva para observar el efecto.

Este código C# demuestra el proceso de sustitución de fuentes:

```c#
// Carga una presentación
Presentation presentation = new Presentation("Fonts.pptx");

// Carga la fuente de origen que será reemplazada
IFontData sourceFont = new FontData("SomeRareFont");

// Carga la nueva fuente
IFontData destFont = new FontData("Arial");

// Agrega una regla de fuente para el reemplazo
IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);

// Agrega la regla a la colección de reglas de sustitución de fuentes
IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
fontSubstRuleCollection.Add(fontSubstRule);

// Agrega la colección de reglas de fuentes a la lista de reglas
presentation.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

using (IImage image = presentation.Slides[0].GetImage(1f, 1f))
{
    // Guarda la imagen en el disco en formato JPEG
    image.Save("Thumbnail_out.jpg", ImageFormat.Jpeg);
}
```

{{%  alert title="NOTA"  color="warning"   %}} 

Puede que quieras ver [**Reemplazo de Fuentes**](/slides/es/net/font-replacement/). 

{{% /alert %}}