---
title: Sección de diapositiva
type: docs
weight: 90
url: /es/nodejs-java/slide-section/
---

Con Aspose.Slides para Node.js a través de Java, puedes organizar una presentación de PowerPoint en secciones. Puedes crear secciones que contengan diapositivas específicas.

Puedes querer crear secciones y usarlas para organizar o dividir las diapositivas en una presentación en partes lógicas en estas situaciones:

- Cuando trabajas en una presentación grande con otras personas o un equipo — y necesitas asignar determinadas diapositivas a un colega o a algunos miembros del equipo. 
- Cuando manejas una presentación que contiene muchas diapositivas — y tienes dificultades para gestionar o editar su contenido de una vez.

Idealmente, deberías crear una sección que agrupe diapositivas similares — las diapositivas comparten algo en común o pueden existir en un grupo basado en una regla — y darle a la sección un nombre que describa las diapositivas que contiene. 

## **Creando secciones en presentaciones**

Para agregar una sección que agrupe diapositivas en una presentación, Aspose.Slides para Node.js a través de Java proporciona el método [addSection()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SectionCollection#addSection-java.lang.String-aspose.slides.ISlide-) que permite especificar el nombre de la sección que deseas crear y la diapositiva desde la cual comienza la sección.

Este fragmento de código muestra cómo crear una sección en una presentación en JavaScript:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var defaultSlide = pres.getSlides().get_Item(0);
    var newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var section1 = pres.getSections().addSection("Section 1", newSlide1);
    var section2 = pres.getSections().addSection("Section 2", newSlide3);// section1 se terminará en newSlide2 y después de eso comenzará section2
    pres.save("pres-sections.pptx", aspose.slides.SaveFormat.Pptx);
    pres.getSections().reorderSectionWithSlides(section2, 0);
    pres.save("pres-sections-moved.pptx", aspose.slides.SaveFormat.Pptx);
    pres.getSections().removeSectionWithSlides(section2);
    pres.getSections().appendEmptySection("Last empty section");
    pres.save("pres-section-with-empty.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Cambiar los nombres de las secciones**

Después de crear una sección en una presentación de PowerPoint, puedes decidir cambiar su nombre. 

Este fragmento de código muestra cómo cambiar el nombre de una sección en una presentación en JavaScript usando Aspose.Slides:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var section = pres.getSections().get_Item(0);
    section.setName("My section");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Preguntas frecuentes**

**¿Se conservan las secciones al guardar en formato PPT (PowerPoint 97–2003)?**

No. El formato PPT no admite metadatos de secciones, por lo que la agrupación de secciones se pierde al guardar en .ppt.

**¿Se puede "ocultar" una sección completa?**

No. Sólo se pueden ocultar diapositivas individuales. Una sección como entidad no tiene un estado "oculto".

**¿Puedo encontrar rápidamente una sección mediante una diapositiva y, a la inversa, la primera diapositiva de una sección?**

Sí. Una sección se define de forma única por su diapositiva inicial; dada una diapositiva puedes determinar a qué sección pertenece, y para una sección puedes acceder a su primera diapositiva.