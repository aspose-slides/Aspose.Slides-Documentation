---
title: Sección de Diapositivas
type: docs
weight: 90
url: /androidjava/slide-section/
---

Con Aspose.Slides para Android a través de Java, puedes organizar una Presentación de PowerPoint en secciones. Puedes crear secciones que contengan diapositivas específicas.

Es posible que desees crear secciones y usarlas para organizar o dividir las diapositivas de una presentación en partes lógicas en estas situaciones:

- Cuando trabajas en una gran presentación con otras personas o un equipo, y necesitas asignar ciertas diapositivas a un colega o a algunos miembros del equipo.
- Cuando estás tratando con una presentación que contiene muchas diapositivas y te cuesta gestionar o editar su contenido a la vez.

Idealmente, deberías crear una sección que aloje diapositivas similares; las diapositivas tienen algo en común o pueden existir en un grupo basado en una regla, y darle a la sección un nombre que describa las diapositivas dentro de ella. 

## Creando Secciones en Presentaciones

Para agregar una sección que albergue diapositivas en una presentación, Aspose.Slides para Android a través de Java proporciona el método [addSection()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISectionCollection#addSection-java.lang.String-com.aspose.slides.ISlide-) que te permite especificar el nombre de la sección que intentas crear y la diapositiva desde la cual comienza la sección.

Este código de ejemplo te muestra cómo crear una sección en una presentación en Java:

```java
Presentation pres = new Presentation();
try {
    ISlide defaultSlide = pres.getSlides().get_Item(0);
    ISlide newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    ISection section1 = pres.getSections().addSection("Sección 1", newSlide1);
    ISection section2 = pres.getSections().addSection("Sección 2", newSlide3); // section1 finalizará en newSlide2 y después comenzará section2   

    pres.save("pres-sections.pptx", SaveFormat.Pptx);

    pres.getSections().reorderSectionWithSlides(section2, 0);
    pres.save("pres-sections-moved.pptx", SaveFormat.Pptx);

    pres.getSections().removeSectionWithSlides(section2);

    pres.getSections().appendEmptySection("Última sección vacía");

    pres.save("pres-section-with-empty.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## Cambiando los Nombres de las Secciones

Después de crear una sección en una presentación de PowerPoint, puedes decidir cambiar su nombre. 

Este código de ejemplo te muestra cómo cambiar el nombre de una sección en una presentación en Java usando Aspose.Slides:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ISection section = pres.getSections().get_Item(0);
    section.setName("Mi sección");
} finally {
    if (pres != null) pres.dispose();
}
```