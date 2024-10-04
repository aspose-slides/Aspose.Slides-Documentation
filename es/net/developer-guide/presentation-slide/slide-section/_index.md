---
title: Sección de Diapositivas
type: docs
weight: 100
url: /net/slide-section/
keywords: "Crear sección, Añadir sección, Editar nombre de sección, Presentación PowerPoint, C#, Csharp, .NET, Aspose.Slides"
description: "Añadir y editar sección en presentación de PowerPoint en C# o .NET"
---

Con Aspose.Slides para .NET, puedes organizar una presentación de PowerPoint en secciones. Puedes crear secciones que contengan diapositivas específicas.

Es posible que desees crear secciones y usarlas para organizar o dividir las diapositivas en una presentación en partes lógicas en estas situaciones:

- Cuando estás trabajando en una gran presentación con otras personas o un equipo, y necesitas asignar ciertas diapositivas a un colega o a algunos miembros del equipo.
- Cuando estás tratando con una presentación que contiene muchas diapositivas y te resulta difícil gestionar o editar su contenido a la vez.

Idealmente, deberías crear una sección que albergue diapositivas similares; las diapositivas tienen algo en común o pueden existir en un grupo basado en una regla, y darle a la sección un nombre que describa las diapositivas dentro de ella.

## Creando Secciones en Presentaciones

Para añadir una sección que albergue diapositivas en una presentación, Aspose.Slides para .NET proporciona el método AddSection que te permite especificar el nombre de la sección que pretendes crear y la diapositiva desde la cual comienza la sección.

Este código de ejemplo muestra cómo crear una sección en una presentación en C#:

```c#
using (Presentation pres = new Presentation())
{
    ISlide defaultSlide = pres.Slides[0];
    ISlide newSlide1 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide2 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide3 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide4 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

    ISection section1 = pres.Sections.AddSection("Sección 1", newSlide1);
    ISection section2 = pres.Sections.AddSection("Sección 2", newSlide3); // section1 terminará en newSlide2 y después comenzará section2   
    
    pres.Save("pres-sections.pptx", SaveFormat.Pptx);
    
    pres.Sections.ReorderSectionWithSlides(section2, 0);
    pres.Save("pres-sections-moved.pptx", SaveFormat.Pptx);
    
    pres.Sections.RemoveSectionWithSlides(section2);
    
    pres.Sections.AppendEmptySection("Última sección vacía");
    
    pres.Save("pres-section-with-empty.pptx",SaveFormat.Pptx);
}
```

## Cambio de Nombres de Secciones

Después de crear una sección en una presentación de PowerPoint, puedes decidir cambiar su nombre.

Este código de ejemplo muestra cómo cambiar el nombre de una sección en una presentación en C# utilizando Aspose.Slides:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ISection section = pres.Sections[0];
   section.Name = "Mi sección";
}
```