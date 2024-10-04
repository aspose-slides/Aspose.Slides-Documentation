---
title: Gestión de Etiquetas y Datos Personalizados
type: docs
weight: 300
url: /es/cpp/gestion-de-etiquetas-y-datos-personalizados

---

## Almacenamiento de Datos en Archivos de Presentación

Los archivos PPTX—elementos con la extensión .pptx—se almacenan en el formato PresentationML, que es parte de la especificación Office Open XML. El formato Office Open XML define la estructura de los datos contenidos en las presentaciones.

Con una *diapositiva* siendo uno de los elementos en las presentaciones, una *parte de diapositiva* contiene el contenido de una sola diapositiva. Se permite que una parte de diapositiva tenga relaciones explícitas con muchas partes—como Etiquetas Definidas por el Usuario—definidas por la ISO/IEC 29500.

Los datos personalizados (específicos de una presentación) o del usuario pueden existir como etiquetas ([ITagCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_tag_collection)) y CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_custom_xml_part_collection)).

{{% alert color="primary" %}}

Las etiquetas son esencialmente pares de valores clave de cadena.

{{% /alert %}}

## Obtención de los Valores para Etiquetas

En las diapositivas, una etiqueta corresponde a la propiedad IDocumentProperties.Keywords. Este código de ejemplo te muestra cómo obtener el valor de una etiqueta con Aspose.Slides para C++ para [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation):

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
System::String keywords = pres->get_DocumentProperties()->get_Keywords();
```

## Agregar Etiquetas a Presentaciones

Aspose.Slides te permite agregar etiquetas a presentaciones. Una etiqueta típicamente consiste en dos elementos:

- el nombre de una propiedad personalizada - `MyTag`
- el valor de la propiedad personalizada - `My Tag Value`

Si necesitas clasificar algunas presentaciones basadas en una regla o propiedad específica, entonces puedes beneficiarte de agregar etiquetas a esas presentaciones. Por ejemplo, si deseas categorizar o agrupar todas las presentaciones de países de América del Norte, puedes crear una etiqueta de América del Norte y luego asignar los países relevantes (EE. UU., México y Canadá) como los valores.

Este código de ejemplo te muestra cómo agregar una etiqueta a una [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) utilizando Aspose.Slides para C++:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ITagCollection> tags = pres->get_CustomData()->get_Tags();
pres->get_CustomData()->get_Tags()->idx_set(u"MyTag", u"My Tag Value");
```

Las etiquetas también se pueden establecer para [Slide](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide):

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

O cualquier [Shape](https://reference.aspose.com/slides/cpp/class/aspose.slides.shape) individual:

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```