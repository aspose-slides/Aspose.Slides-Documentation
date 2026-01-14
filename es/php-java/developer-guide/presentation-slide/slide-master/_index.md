---
title: Gestionar maestros de diapositivas de presentación en PHP
linktitle: Maestro de diapositiva
type: docs
weight: 70
url: /es/php-java/slide-master/
keywords:
- maestro de diapositiva
- diapositiva maestra
- diapositiva maestra PPT
- varias diapositivas maestras
- comparar diapositivas maestras
- fondo
- marcador de posición
- clonar diapositiva maestra
- copiar diapositiva maestra
- duplicar diapositiva maestra
- diapositiva maestra sin usar
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Gestionar maestros de diapositivas en Aspose.Slides para PHP mediante Java: crear, editar y aplicar diseños, temas y marcadores de posición a PPT, PPTX y ODP con ejemplos concisos."
---

## **Qué es una Slide Master en PowerPoint**

Una **Slide Master** es una plantilla de diapositiva que define el diseño, estilos, tema, fuentes, fondo y otras propiedades de las diapositivas de una presentación. Si deseas crear una presentación (o una serie de presentaciones) con el mismo estilo y plantilla para tu empresa, puedes usar una Slide Master. 

Una Slide Master es útil porque permite establecer y cambiar el aspecto de todas las diapositivas de la presentación a la vez. Aspose.Slides admite el mecanismo de Slide Master de PowerPoint. 

VBA también permite manipular una Slide Master y ejecutar las mismas operaciones que PowerPoint admite: cambiar fondos, añadir formas, personalizar el diseño, etc. Aspose.Slides ofrece mecanismos flexibles para que puedas usar Slide Masters y realizar tareas básicas con ellos. 

Estas son operaciones básicas con Slide Master:

- Crear o Slide Master.
- Aplicar Slides Master a las diapositivas de la presentación.
- Cambiar el fondo de la Slide Master. 
- Añadir una imagen, marcador de posición, Smart Art, etc. a la Slide Master.

Estas son operaciones más avanzadas que implican Slide Master: 

- Comparar Slide Masters.
- Fusionar Slide Masters.
- Aplicar varias Slide Masters.
- Copiar una diapositiva con Slide Master a otra presentación.
- Encontrar Slide Masters duplicados en presentaciones.
- Establecer la Slide Master como la vista predeterminada de la presentación.

{{% alert color="primary" %}} 

Puede que quieras probar Aspose [**Online PowerPoint Viewer**](https://products.aspose.app/slides/viewer) porque es una implementación en vivo de algunos de los procesos centrales descritos aquí.

{{% /alert %}} 


## **Cómo se aplica una Slide Master**

Antes de trabajar con una Slide Master, puede que quieras entender cómo se usan en las presentaciones y se aplican a las diapositivas. 

* Cada presentación tiene, por defecto, al menos una Slide Master. 
* Una presentación puede contener varias Slide Masters. Puedes añadir varias Slide Masters y usarlas para dar estilo a diferentes partes de la presentación de distintas maneras. 

En **Aspose.Slides**, una Slide Master está representada por el tipo [**MasterSlide**](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/). 

El objeto [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) de Aspose.Slides contiene la lista de [**getMasters**](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getMasters) de tipo [**MasterSlideCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/), que contiene una lista de todas las diapositivas maestras definidas en una presentación.

Además de las operaciones CRUD, la clase [MasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/) incluye estos métodos útiles: [**addClone(LayoutSlide sourceLayout)**](https://reference.aspose.com/slides/php-java/aspose.slides/masterlayoutslidecollection/#addClone) y [**insertClone(int index, MasterSlide sourceMaster)**](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/#insertClone). Esos métodos se heredan de la función básica de clonación de diapositivas. Pero al trabajar con Slide Masters, esos métodos permiten implementar configuraciones complicadas.

Cuando se añade una nueva diapositiva a una presentación, se le aplica automáticamente una Slide Master. Por defecto, se selecciona la Slide Master de la diapositiva anterior. 

**Nota**: Las diapositivas de la presentación se guardan en la lista [getSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides), y cada nueva diapositiva se añade al final de la colección por defecto. Si una presentación contiene una única Slide Master, esa Slide Master se selecciona para todas las diapositivas nuevas. Esta es la razón por la que no tienes que definir la Slide Master para cada diapositiva nueva que crees.

El principio es el mismo en PowerPoint y Aspose.Slides. Por ejemplo, en PowerPoint, cuando añades una nueva diapositiva, puedes pulsar en la línea inferior bajo la última diapositiva y se creará una nueva diapositiva (con la Slide Master de la última presentación):

![todo:image_alt_text](slide-master_1.jpg)

En Aspose.Slides, puedes realizar la tarea equivalente con el método [addClone(Slide sourceSlide)](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/#addClone) de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).


## **Slide Master en la jerarquía de Slides**

Usar Slide Layouts con Slide Master permite la máxima flexibilidad. Un Slide Layout te permite establecer los mismos estilos que la Slide Master (fondo, fuentes, formas, etc.). Sin embargo, cuando varios Slide Layouts se combinan en una Slide Master, se crea un nuevo estilo. Cuando aplicas un Slide Layout a una única diapositiva, puedes cambiar su estilo respecto al aplicado por la Slide Master.

La Slide Master prevalece sobre todos los elementos de configuración: Slide Master → Slide Layout → Slide:

![todo:image_alt_text](slide-master_2)



Cada objeto [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlide) tiene una propiedad [**getLayoutSlides**](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlide/#getLayoutSlides) con una lista de Slide Layouts. Un tipo [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/Slide) tiene una propiedad [**getLayoutSlide**](https://reference.aspose.com/slides/php-java/aspose.slides/Slide/#getLayoutSlide) que enlaza con el Slide Layout aplicado a la diapositiva. La interacción entre una diapositiva y la Slide Master se produce a través de un Slide Layout.

{{% alert color="info" title="Nota" %}}

* En Aspose.Slides, todas las configuraciones de la diapositiva (Slide Master, Slide Layout y la propia diapositiva) son en realidad objetos de diapositiva que heredan de la clase [**BaseSlide**](https://reference.aspose.com/slides/php-java/aspose.slides/BaseSlide).
* Por lo tanto, Slide Master y Slide Layout pueden implementar las mismas propiedades y necesitas saber cómo se aplicarán sus valores a un objeto [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/Slide). La Slide Master se aplica primero a una diapositiva y luego se aplica el Slide Layout. Por ejemplo, si la Slide Master y el Slide Layout tienen ambos un valor de fondo, la diapositiva terminará con el fondo del Slide Layout.

{{% /alert %}}


## **Qué contiene una Slide Master**

Para entender cómo se puede modificar una Slide Master, necesitas conocer sus componentes. Estos son los atributos principales de [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/).

- [getBackground](https://reference.aspose.com/slides/php-java/aspose.slides/BaseSlide/#getBackground) obtener/establecer el fondo de la diapositiva.
- [getBodyStyle](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlide/#getBodyStyle) obtener/establecer los estilos de texto del cuerpo de la diapositiva.
- [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/BaseSlide/#getShapes) obtener/establecer todas las formas de la Slide Master (marcadores de posición, marcos de imágenes, etc.).
- [getControls](https://reference.aspose.com/slides/php-java/aspose.slides/BaseSlide/#getControls) obtener/establecer controles ActiveX.
- [getThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/#getThemeManager) obtener el gestor de temas.
- [getHeaderFooterManager](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlide/#getHeaderFooterManager) obtener el gestor de encabezados y pies de página.

Métodos de Slide Master:

- [getDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlide/#getDependingSlides) obtener todas las diapositivas que dependen de la Slide Master.
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlide/#applyExternalThemeToDependingSlides) permite crear una nueva Slide Master basada en la Slide Master actual y un tema nuevo. La nueva Slide Master se aplicará entonces a todas las diapositivas dependientes.


## **Obtener una Slide Master**

En PowerPoint, la Slide Master se puede acceder desde el menú Ver → Slide Master:

![todo:image_alt_text](slide-master_3.jpg)



Con Aspose.Slides, puedes acceder a una Slide Master de esta manera: 
```php
  $pres = new Presentation();
  try {
    # Da acceso a la diapositiva maestra de la Presentación
    $masterSlide = $pres->getMasters()->get_Item(0);
  } finally {
    $pres->dispose();
  }
```


La clase [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlide) representa una Slide Master. El método [getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getMasters) (relacionado con el tipo [MasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlideCollection)) devuelve una lista de todas las Slide Masters definidas en la presentación. 


## **Añadir una imagen a una Slide Master**

Cuando añades una imagen a una Slide Master, esa imagen aparecerá en todas las diapositivas que dependan de esa Slide Master. 

Por ejemplo, puedes colocar el logotipo de tu empresa y algunas imágenes en la Slide Master y luego volver al modo de edición de diapositivas. Deberías ver la imagen en cada diapositiva. 

![todo:image_alt_text](slide-master_4.png)

Puedes añadir imágenes a una Slide Master con Aspose.Slides:
```php
  $pres = new Presentation();
  try {
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $pres->getMasters()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="primary" title="Ver también" %}} 

Para más información sobre cómo añadir imágenes a una diapositiva, consulta el artículo [Picture Frame](/slides/es/php-java/picture-frame/#create-picture-frame).
{{% /alert %}}


## **Añadir un marcador de posición a una Slide Master**

Estos campos de texto son marcadores de posición estándar en una Slide Master: 

* Haga clic para editar el estilo del título Maestro
* Editar estilos de texto del Maestro
* Nivel secundario
* Nivel terciario 

  También aparecen en las diapositivas basadas en la Slide Master. Puedes editar esos marcadores de posición en una Slide Master y los cambios se aplicarán automáticamente a las diapositivas. 

En PowerPoint, puedes añadir un marcador de posición mediante la ruta Slide Master → Insertar marcador de posición:

![todo:image_alt_text](slide-master_5.png)

Veamos un ejemplo más complicado de marcadores de posición con Aspose.Slides. Considera una diapositiva con marcadores de posición basados en la Slide Master:

![todo:image_alt_text](slide-master_6.png)

Queremos cambiar el formato del Título y Subtítulo en la Slide Master de esta forma:

![todo:image_alt_text](slide-master_7.png)

Primero, recuperamos el contenido del marcador de posición del título del objeto Slide Master y luego usamos el campo `PlaceHolder.FillFormat`:
```php

```


El estilo y formato del título cambiará para todas las diapositivas basadas en la Slide Master:

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="Ver también" %}} 

* [Definir texto de indicación en Placeholder](https://docs.aspose.com/slides/php-java/manage-placeholder/)
* [Formato de texto](https://docs.aspose.com/slides/php-java/text-formatting/)

{{% /alert %}}


## **Cambiar el fondo en una Slide Master**

Cuando cambias el color de fondo de una diapositiva maestra, todas las diapositivas normales de la presentación obtendrán el nuevo color. Este código PHP demuestra la operación:
```php
  $pres = new Presentation();
  try {
    $master = $pres->getMasters()->get_Item(0);
    $master->getBackground()->setType(BackgroundType::OwnBackground);
    $master->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $master->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="primary" title="Ver también" %}} 

- [Fondo de la presentación](https://docs.aspose.com/slides/php-java/presentation-background/)
- [Tema de la presentación](https://docs.aspose.com/slides/php-java/presentation-theme/)

{{% /alert %}}

## **Clonar una Slide Master a otra presentación**

Para clonar una Slide Master a otra presentación, llama al método [**addClone**](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone) de la presentación de destino pasando una Slide Master. Este código PHP muestra cómo clonar una Slide Master a otra presentación:
```php
  $presSource = new Presentation();
  $presTarget = new Presentation();
  try {
    $master = $presTarget->getMasters()->addClone($presSource->getMasters()->get_Item(0));
  } finally {
    if (!java_is_null($presSource)) {
      $presSource->dispose();
    }
  }
```



## **Añadir varias Slide Masters a una presentación**

Aspose.Slides permite añadir varias Slide Masters y Slide Layouts a cualquier presentación. Esto permite configurar estilos, diseños y opciones de formato de las diapositivas de la presentación de muchas formas. 

En PowerPoint, puedes añadir nuevas Slide Masters y Layouts (desde el menú "Slide Master") de esta manera:

![todo:image_alt_text](slide-master_9.jpg)

Con Aspose.Slides, puedes añadir una nueva Slide Master llamando al método [**addClone**](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone):
```php
  # Añade una nueva diapositiva maestra
  $secondMasterSlide = $pres->getMasters()->addClone($masterSlide);
```



## **Comparar Slide Masters**

Una Master Slide implementa la clase [BaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/BaseSlide) que contiene el método [**equals**](https://reference.aspose.com/slides/php-java/aspose.slides/BaseSlide/#equals), el cual puede usarse para comparar diapositivas. Devuelve `true` para Master Slides idénticos en estructura y contenido estático.

Dos Master Slides son iguales si sus formas, estilos, textos, animaciones y demás configuraciones son iguales. La comparación no tiene en cuenta los valores de identificadores únicos (p. ej., SlideId) ni el contenido dinámico (p. ej., valor de fecha actual en un marcador de posición de fecha). 


## **Establecer una Slide Master como vista predeterminada de la presentación**

Aspose.Slides permite establecer una Slide Master como vista predeterminada para una presentación. La vista predeterminada es lo que ves primero al abrir una presentación. 

Este código muestra cómo establecer una Slide Master como vista predeterminada de una presentación:
```php
  # Instancia una clase Presentation que representa el archivo de presentación
  $presentation = new Presentation();
  try {
    # Establece la vista predeterminada como SlideMasterView
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    # Guarda la presentación
    $presentation->save("PresView.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```


## **Eliminar Master Slides no utilizados**

Aspose.Slides proporciona el método [removeUnusedMasterSlides](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#removeUnusedMasterSlides) (de la clase [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/)) para eliminar master slides no deseados y sin uso. Este código PHP muestra cómo eliminar una master slide de una presentación PowerPoint:
```php
  $pres = new Presentation("pres.pptx");
  try {
    Compress->removeUnusedMasterSlides($pres);
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**¿Qué es una Slide Master en PowerPoint?**

Una Slide Master es una plantilla de diapositiva que define el diseño, estilos, temas, fuentes, fondo y otras propiedades de las diapositivas de una presentación. Permite establecer y cambiar el aspecto de todas las diapositivas de la presentación a la vez.  

**¿Cómo se aplica una Slide Master en una presentación?**

Cada presentación tiene, por defecto, al menos una Slide Master. Cuando se añade una nueva diapositiva, se le aplica automáticamente una Slide Master, normalmente heredando la maestra de la diapositiva anterior. Una presentación puede contener múltiples Slide Masters para dar estilo a diferentes partes de forma única.  

**¿Qué elementos pueden personalizarse en una Slide Master?**

Una Slide Master comprende varios atributos principales que pueden personalizarse:

- **Background**: establecer el fondo de la diapositiva.
- **BodyStyle**: definir los estilos de texto del cuerpo de la diapositiva.
- **Shapes**: gestionar todas las formas de la Slide Master, incluidos marcadores de posición y marcos de imágenes.
- **Controls**: manejar controles ActiveX.
- **ThemeManager**: acceder al gestor de temas.
- **HeaderFooterManager**: gestionar encabezados y pies de página.  

**¿Cómo puedo añadir una imagen a una Slide Master?**

Añadir una imagen a una Slide Master garantiza que aparezca en todas las diapositivas que dependen de esa maestra. Por ejemplo, colocar el logotipo de la empresa en la Slide Master lo mostrará en cada diapositiva de la presentación.  

**¿Cómo se relacionan las Slide Masters con los Slide Layouts?**

Los Slide Layouts funcionan en conjunto con las Slide Masters para proporcionar flexibilidad en el diseño de diapositivas. Mientras que una Slide Master define estilos y temas globales, los Slide Layouts permiten variaciones en la organización del contenido. La jerarquía es la siguiente:

- **Slide Master** → Define estilos globales.
- **Slide Layout** → Proporciona diferentes disposiciones de contenido.
- **Slide** → Hereda el diseño de su Slide Layout.

**¿Puedo tener varias Slide Masters en una sola presentación?**

Sí, una presentación puede contener varias Slide Masters. Esto permite dar estilo a distintas secciones de la presentación de diversas maneras, ofreciendo flexibilidad en el diseño.  

**¿Cómo accedo y modifico una Slide Master usando Aspose.Slides?**

En Aspose.Slides, una Slide Master está representada por la clase [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/). Puedes acceder a una Slide Master mediante el método [getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getmasters/) del objeto [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).