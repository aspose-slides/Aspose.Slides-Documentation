---
title: Administrar secciones de diapositivas en presentaciones en .NET
linktitle: Sección de diapositiva
type: docs
weight: 100
url: /es/net/slide-section/
keywords:
- crear sección
- agregar sección
- editar sección
- cambiar sección
- nombre de sección
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Optimiza las secciones de diapositivas en PowerPoint y OpenDocument con Aspose.Slides para .NET: divide, renombra y reordena para mejorar los flujos de trabajo de PPTX y ODP."
---

Con Aspose.Slides para .NET, puedes organizar una presentación de PowerPoint en secciones. Puedes crear secciones que contengan diapositivas específicas. 

Es posible que desees crear secciones y usarlas para organizar o dividir las diapositivas de una presentación en partes lógicas en las siguientes situaciones:

- Cuando trabajas en una presentación grande con otras personas o un equipo, y necesitas asignar ciertas diapositivas a un colega o a algunos miembros del equipo. 
- Cuando estás tratando con una presentación que contiene muchas diapositivas y te resulta difícil gestionar o editar su contenido de una sola vez.

Idealmente, deberías crear una sección que agrupe diapositivas similares —las diapositivas tienen algo en común o pueden existir en un grupo basado en una regla— y darle a la sección un nombre que describa las diapositivas que contiene. 

## **Crear secciones en presentaciones**

Para agregar una sección que agrupe diapositivas en una presentación, Aspose.Slides para .NET proporciona el método AddSection que permite especificar el nombre de la sección que deseas crear y la diapositiva desde la cual comienza la sección. 

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

Después de crear una sección en una presentación de PowerPoint, puedes decidir cambiar su nombre. 

Este fragmento de código muestra cómo cambiar el nombre de una sección en una presentación en C# usando Aspose.Slides:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ISection section = pres.Sections[0];
   section.Name = "My section";
}
```


## **Preguntas frecuentes**

**¿Se conservan las secciones al guardar en el formato PPT (PowerPoint 97–2003)?**

No. El formato PPT no admite metadatos de secciones, por lo que la agrupación de secciones se pierde al guardar en .ppt.

**¿Puede una sección completa estar "oculta"?**

No. Sólo se pueden ocultar diapositivas individuales. Una sección como entidad no tiene estado "oculto".

**¿Puedo encontrar rápidamente una sección a partir de una diapositiva y, a la inversa, la primera diapositiva de una sección?**

Sí. Una sección se define de forma única por su diapositiva inicial; dada una diapositiva puedes determinar a qué sección pertenece, y para una sección puedes acceder a su primera diapositiva.