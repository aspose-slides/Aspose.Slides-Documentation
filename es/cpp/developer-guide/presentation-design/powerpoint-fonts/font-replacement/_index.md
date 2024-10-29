---
title: Reemplazo de Fuentes
type: docs
weight: 60
url: /es/cpp/font-replacement/
keywords: "Fuente, reemplazar fuente, presentación de PowerPoint, C++, CPP, Aspose.Slides para C++"
description: "Reemplaza fuentes explícitamente en PowerPoint en C++"
---

Si cambias de opinión sobre el uso de una fuente, puedes reemplazar esa fuente por otra. Todas las instancias de la fuente antigua serán reemplazadas por la nueva fuente.

Aspose.Slides te permite reemplazar una fuente de esta manera:

1. Carga la presentación relevante.
2. Carga la fuente que será reemplazada.
3. Carga la nueva fuente.
4. Reemplaza la fuente.
5. Escribe la presentación modificada como un archivo PPTX.

Este código en C++ demuestra el reemplazo de fuentes:

``` cpp
// Carga una presentación
auto presentation = System::MakeObject<Presentation>(u"Fonts.pptx");

// Carga la fuente fuente que será reemplazada
auto sourceFont = System::MakeObject<FontData>(u"Arial");

// Carga la nueva fuente
auto destFont = System::MakeObject<FontData>(u"Times New Roman");

// Reemplaza las fuentes
presentation->get_FontsManager()->ReplaceFont(sourceFont, destFont);

// Guarda la presentación
presentation->Save(u"UpdatedFont_out.pptx", SaveFormat::Pptx);
```

{{% alert title="Nota" color="warning" %}} 

Para establecer reglas que determinen qué sucede en ciertas condiciones (si una fuente no puede ser accedida, por ejemplo), consulta [**Sustitución de Fuentes**](/slides/es/cpp/font-substitution/). 

{{% /alert %}}