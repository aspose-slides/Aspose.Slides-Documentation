---
title: Reemplazo de Fuentes - API de PowerPoint C#
linktitle: Reemplazo de Fuentes
type: docs
weight: 60
url: /net/font-replacement/
keywords: "Fuente, reemplazar fuente, presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: Con la API de PowerPoint en C#, puede reemplazar una fuente explícitamente por otra fuente en la Presentación.
---

Si cambias de opinión sobre el uso de una fuente, puedes reemplazar esa fuente por otra fuente. Todas las instancias de la fuente antigua serán reemplazadas por la nueva fuente.

Aspose.Slides te permite reemplazar una fuente de esta manera:

1. Carga la presentación relevante.
2. Carga la fuente que será reemplazada.
3. Carga la nueva fuente.
4. Reemplaza la fuente.
5. Escribe la presentación modificada como un archivo PPTX.

Este código C# demuestra el reemplazo de fuentes:

```c#
// Carga una presentación
Presentation presentation = new Presentation("Fonts.pptx");

// Carga la fuente fuente que será reemplazada
IFontData sourceFont = new FontData("Arial");

// Carga la nueva fuente
IFontData destFont = new FontData("Times New Roman");

// Reemplaza las fuentes
presentation.FontsManager.ReplaceFont(sourceFont, destFont);

// Guarda la presentación
presentation.Save("UpdatedFont_out.pptx", SaveFormat.Pptx);
```

{{% alert title="Nota" color="warning" %}} 

Para establecer reglas que determinen qué sucede en ciertas condiciones (si no se puede acceder a una fuente, por ejemplo), consulta [**Sustitución de Fuentes**](/slides/net/font-substitution/). 

{{% /alert %}}