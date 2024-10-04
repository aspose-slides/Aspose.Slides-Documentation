---
title: Gestionando Etiquetas y Datos Personalizados
type: docs
weight: 300
url: /java/managing-tags-and-custom-data

---

## Almacenamiento de Datos en Archivos de Presentación

Los archivos PPTX—elementos con la extensión .pptx—se almacenan en el formato PresentationML, que es parte de la especificación Office Open XML. El formato Office Open XML define la estructura de los datos contenidos en las presentaciones. 

Con una *diapositiva* siendo uno de los elementos en las presentaciones, una *parte de diapositiva* contiene el contenido de una única diapositiva. Se permite que una parte de diapositiva tenga relaciones explícitas con muchas partes—como Etiquetas Definidas por el Usuario—definidas por la ISO/IEC 29500. 

Los datos personalizados (específicos de una presentación) o del usuario pueden existir como etiquetas ([ITagCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ITagCollection)) y CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ICustomXmlPartCollection)). 

{{% alert color="primary" %}} 

Las etiquetas son esencialmente valores de pares clave-valor de tipo cadena. 

{{% /alert %}} 

## Obteniendo los Valores de las Etiquetas

En diapositivas, una etiqueta corresponde a los métodos [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/java/com.aspose.slides/IDocumentProperties#getKeywords--) y [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/java/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-). Este código de muestra te muestra cómo obtener el valor de una etiqueta con Aspose.Slides para Java para [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation):

```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```

## Agregando Etiquetas a las Presentaciones

Aspose.Slides te permite agregar etiquetas a las presentaciones. Una etiqueta típicamente consiste en dos elementos: 

- el nombre de una propiedad personalizada - `MyTag` 
- el valor de la propiedad personalizada - `My Tag Value`

Si necesitas clasificar algunas presentaciones basadas en una regla o propiedad específica, entonces puedes beneficiarte de agregar etiquetas a esas presentaciones. Por ejemplo, si deseas categorizar o poner todas las presentaciones de países de América del Norte juntas, puedes crear una etiqueta de América del Norte y luego asignar los países relevantes (EE.UU., México y Canadá) como los valores. 

Este código de muestra te muestra cómo agregar una etiqueta a una [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) usando Aspose.Slides para Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```

Las etiquetas también pueden establecerse para [Slide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide):

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

O para cualquier [Shape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) individual:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```