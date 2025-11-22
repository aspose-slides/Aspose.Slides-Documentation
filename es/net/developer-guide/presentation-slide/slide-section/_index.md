---
title: Sección de diapositiva
type: docs
weight: 100
url: /es/net/slide-section/
keywords: "Crear sección, Agregar sección, Editar nombre de sección, Presentación de PowerPoint, C#, Csharp, .NET, Aspose.Slides"
description: "Agregar y editar secciones en una presentación de PowerPoint en C# o .NET"
---

Con Aspose.Slides para .NET, puede organizar una presentación de PowerPoint en secciones. Puede crear secciones que contengan diapositivas específicas. 

Es posible que desee crear secciones y usarlas para organizar o dividir diapositivas en una presentación en partes lógicas en las siguientes situaciones:

- Cuando trabaja en una presentación grande con otras personas o un equipo, y necesita asignar ciertas diapositivas a un colega o a algunos miembros del equipo. 
- Cuando se enfrenta a una presentación que contiene muchas diapositivas y le cuesta administrar o editar su contenido de una sola vez.

Idealmente, debe crear una sección que agrupe diapositivas similares: las diapositivas comparten algo en común o pueden existir en un grupo basado en una regla, y darle a la sección un nombre que describa las diapositivas que contiene. 

## **Crear secciones en presentaciones**

Para agregar una sección que agrupe diapositivas en una presentación, Aspose.Slides para .NET ofrece el método AddSection que le permite especificar el nombre de la sección que desea crear y la diapositiva a partir de la cual comienza la sección. 

Este fragmento de código muestra cómo crear una sección en una presentación en C#:
```c#
using (Presentation pres = new Presentation())
{
    ISlide defaultSlide = pres.Slides[0];
    ISlide newSlide1 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide2 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide3 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide4 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

    ISection section1 = pres.Sections.AddSection("Section 1", newSlide1);
    ISection section2 = pres.Sections.AddSection("Section 2", newSlide3); // section1 terminará en newSlide2 y después de él comenzará section2   
    
    pres.Save("pres-sections.pptx", SaveFormat.Pptx);
    
    pres.Sections.ReorderSectionWithSlides(section2, 0);
    pres.Save("pres-sections-moved.pptx", SaveFormat.Pptx);
    
    pres.Sections.RemoveSectionWithSlides(section2);
    
    pres.Sections.AppendEmptySection("Last empty section");
    
    pres.Save("pres-section-with-empty.pptx",SaveFormat.Pptx);
}
```


## **Cambiar los nombres de las secciones**

Después de crear una sección en una presentación de PowerPoint, puede decidir cambiar su nombre. 

Este fragmento de código muestra cómo cambiar el nombre de una sección en una presentación en C# usando Aspose.Slides:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ISection section = pres.Sections[0];
   section.Name = "My section";
}
```


## **Preguntas frecuentes**

**¿Se conservan las secciones al guardar en formato PPT (PowerPoint 97–2003)?**

No. El formato PPT no admite metadatos de sección, por lo que el agrupamiento de secciones se pierde al guardar en .ppt.

**¿Se puede "ocultar" una sección completa?**

No. Sólo se pueden ocultar diapositivas individuales. Una sección como entidad no tiene estado "oculto".

**¿Puedo encontrar rápidamente una sección a partir de una diapositiva y, a la inversa, la primera diapositiva de una sección?**

Sí. Una sección se define de forma única por su diapositiva inicial; dada una diapositiva puede determinar a qué sección pertenece, y para una sección puede acceder a su primera diapositiva.