---
title: Gestionar secciones de diapositivas en presentaciones en Android
linktitle: Sección de diapositiva
type: docs
weight: 90
url: /es/androidjava/slide-section/
keywords:
- crear sección
- agregar sección
- editar sección
- cambiar sección
- nombre de la sección
- PowerPoint
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "Optimiza las secciones de diapositivas en PowerPoint y OpenDocument con Aspose.Slides para Android mediante Java—divide, renombra y reordena para mejorar los flujos de trabajo PPTX y ODP."
---

Con Aspose.Slides para Android mediante Java, puedes organizar una presentación de PowerPoint en secciones. Puedes crear secciones que contengan diapositivas específicas.

Puedes querer crear secciones y utilizarlas para organizar o dividir las diapositivas de una presentación en partes lógicas en las siguientes situaciones:

- Cuando trabajas en una presentación grande con otras personas o un equipo—y necesitas asignar ciertas diapositivas a un colega o a algunos miembros del equipo. 
- Cuando manejas una presentación que contiene muchas diapositivas—and te cuesta gestionar o editar su contenido de una sola vez.

Idealmente, deberías crear una sección que agrupe diapositivas similares—las diapositivas tienen algo en común o pueden existir en un grupo basado en una regla—y darle a la sección un nombre que describa las diapositivas que contiene. 

## **Crear secciones en presentaciones**

Para agregar una sección que contendrá diapositivas en una presentación, Aspose.Slides para Android mediante Java proporciona el método [addSection()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISectionCollection#addSection-java.lang.String-com.aspose.slides.ISlide-) que permite especificar el nombre de la sección que deseas crear y la diapositiva desde la cual comienza la sección.

Este código de ejemplo muestra cómo crear una sección en una presentación en Java:
```java
Presentation pres = new Presentation();
try {
    ISlide defaultSlide = pres.getSlides().get_Item(0);
    ISlide newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    ISection section1 = pres.getSections().addSection("Section 1", newSlide1);
    ISection section2 = pres.getSections().addSection("Section 2", newSlide3); // la sección1 terminará en newSlide2 y después de ella comenzará la sección2   

    pres.save("pres-sections.pptx", SaveFormat.Pptx);

    pres.getSections().reorderSectionWithSlides(section2, 0);
    pres.save("pres-sections-moved.pptx", SaveFormat.Pptx);

    pres.getSections().removeSectionWithSlides(section2);

    pres.getSections().appendEmptySection("Last empty section");

    pres.save("pres-section-with-empty.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Cambiar los nombres de las secciones**

Después de crear una sección en una presentación de PowerPoint, puedes decidir cambiar su nombre. 

Este código de ejemplo muestra cómo cambiar el nombre de una sección en una presentación en Java usando Aspose.Slides:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    ISection section = pres.getSections().get_Item(0);
    section.setName("My section");
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**¿Se conservan las secciones al guardar en formato PPT (PowerPoint 97–2003)?**

No. El formato PPT no admite metadatos de sección, por lo que la agrupación de secciones se pierde al guardar en .ppt.

**¿Puede una sección completa estar "oculta"?**

No. Sólo se pueden ocultar diapositivas individuales. Una sección como entidad no tiene estado "oculto".

**¿Puedo encontrar rápidamente una sección por una diapositiva y, a la inversa, la primera diapositiva de una sección?**

Sí. Una sección se define de manera única por su diapositiva inicial; dada una diapositiva puedes determinar a qué sección pertenece, y para una sección puedes acceder a su primera diapositiva.