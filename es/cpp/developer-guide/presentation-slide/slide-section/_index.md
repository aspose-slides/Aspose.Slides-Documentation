---
title: Sección de Diapositivas
type: docs
weight: 100
url: /cpp/slide-section/
---

Con Aspose.Slides para C++, puedes organizar una Presentación de PowerPoint en secciones. Puedes crear secciones que contengan diapositivas específicas.

Es posible que desees crear secciones y usarlas para organizar o dividir las diapositivas en una presentación en partes lógicas en estas situaciones:

- Cuando estás trabajando en una gran presentación con otras personas o un equipo, y necesitas asignar ciertas diapositivas a un colega o algunos miembros del equipo.
- Cuando estás lidiando con una presentación que contiene muchas diapositivas y estás luchando por gestionar o editar su contenido de una vez.

Idealmente, deberías crear una sección que albergue diapositivas similares; las diapositivas tienen algo en común o pueden existir en un grupo basado en una regla, y darle a la sección un nombre que describa las diapositivas dentro de ella.

## Creando Secciones en Presentaciones

Para añadir una sección que albergará diapositivas en una presentación, Aspose.Slides para C++ proporciona el método AddSection que te permite especificar el nombre de la sección que deseas crear y la diapositiva a partir de la cual comienza la sección.

Este código de muestra te muestra cómo crear una sección en una presentación en C++:

``` cpp
auto pres = System::MakeObject<Presentation>();

auto defaultSlide = pres->get_Slides()->idx_get(0);
auto newSlide1 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide2 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide3 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide4 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));

auto section1 = pres->get_Sections()->AddSection(u"Sección 1", newSlide1);
auto section2 = pres->get_Sections()->AddSection(u"Sección 2", newSlide3);
// section1 terminará en newSlide2 y después de eso comenzará section2   

pres->Save(u"pres-sections.pptx", SaveFormat::Pptx);

pres->get_Sections()->ReorderSectionWithSlides(section2, 0);
pres->Save(u"pres-sections-moved.pptx", SaveFormat::Pptx);

pres->get_Sections()->RemoveSectionWithSlides(section2);

pres->get_Sections()->AppendEmptySection(u"Última sección vacía");

pres->Save(u"pres-section-with-empty.pptx", SaveFormat::Pptx);
```

## Cambiando los Nombres de las Secciones

Después de crear una sección en una presentación de PowerPoint, puedes decidir cambiar su nombre.

Este código de muestra te muestra cómo cambiar el nombre de una sección en una presentación en C++ usando Aspose.Slides:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto section = pres->get_Sections()->idx_get(0);
section->set_Name(u"Mi sección");
```