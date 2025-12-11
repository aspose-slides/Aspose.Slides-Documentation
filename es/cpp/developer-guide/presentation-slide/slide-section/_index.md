---
title: Administrar secciones de diapositivas en presentaciones usando C++
linktitle: Sección de diapositiva
type: docs
weight: 100
url: /es/cpp/slide-section/
keywords:
- crear sección
- agregar sección
- editar sección
- cambiar sección
- nombre de sección
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Optimiza las secciones de diapositivas en PowerPoint y OpenDocument con Aspose.Slides para C++ — divide, renombra y reorganiza para mejorar los flujos de trabajo de PPTX y ODP."
---

Con Aspose.Slides para C++, puedes organizar una presentación de PowerPoint en secciones. Puedes crear secciones que contengan diapositivas específicas. 

Puede que desees crear secciones y utilizarlas para organizar o dividir las diapositivas de una presentación en partes lógicas en las siguientes situaciones:

- Cuando trabajas en una presentación grande con otras personas o un equipo, y necesitas asignar ciertas diapositivas a un colega o a algunos miembros del equipo. 
- Cuando manejas una presentación que contiene muchas diapositivas y te cuesta gestionar o editar su contenido de una sola vez.

Idealmente, deberías crear una sección que agrupe diapositivas similares —las diapositivas comparten algo en común o pueden existir en un grupo basado en una regla— y darle a la sección un nombre que describa las diapositivas que contiene. 

## **Crear secciones en presentaciones**

Para agregar una sección que agrupe diapositivas en una presentación, Aspose.Slides para C++ proporciona el método AddSection que permite especificar el nombre de la sección que deseas crear y la diapositiva desde la cual comienza la sección. 

Este fragmento de código muestra cómo crear una sección en una presentación en C++:
``` cpp
auto pres = System::MakeObject<Presentation>();

auto defaultSlide = pres->get_Slides()->idx_get(0);
auto newSlide1 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide2 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide3 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide4 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));

auto section1 = pres->get_Sections()->AddSection(u"Section 1", newSlide1);
auto section2 = pres->get_Sections()->AddSection(u"Section 2", newSlide3);
// section1 terminará en newSlide2 y después de ella comenzará section2   

pres->Save(u"pres-sections.pptx", SaveFormat::Pptx);

pres->get_Sections()->ReorderSectionWithSlides(section2, 0);
pres->Save(u"pres-sections-moved.pptx", SaveFormat::Pptx);

pres->get_Sections()->RemoveSectionWithSlides(section2);

pres->get_Sections()->AppendEmptySection(u"Last empty section");

pres->Save(u"pres-section-with-empty.pptx", SaveFormat::Pptx);
```


## **Cambiar los nombres de las secciones**

Después de crear una sección en una presentación de PowerPoint, puedes decidir cambiar su nombre. 

Este fragmento de código muestra cómo cambiar el nombre de una sección en una presentación en C++ usando Aspose.Slides:
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto section = pres->get_Sections()->idx_get(0);
section->set_Name(u"My section");
```


## **FAQ**

**¿Se conservan las secciones al guardar en formato PPT (PowerPoint 97–2003)?**

No. El formato PPT no admite metadatos de sección, por lo que la agrupación de secciones se pierde al guardar en .ppt.

**¿Puede ocultarse una sección completa?**

No. Sólo se pueden ocultar diapositivas individuales. Una sección como entidad no tiene estado "oculto".

**¿Puedo encontrar rápidamente una sección a partir de una diapositiva y, a la inversa, la primera diapositiva de una sección?**

Sí. Una sección se define de manera única por su diapositiva inicial; dada una diapositiva puedes determinar a qué sección pertenece, y para una sección puedes acceder a su primera diapositiva.