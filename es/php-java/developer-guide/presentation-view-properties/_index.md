---
title: Recuperar y actualizar propiedades de vista de la presentación en PHP
linktitle: Propiedades de vista
type: docs
weight: 80
url: /es/php-java/presentation-view-properties/
keywords:
- propiedades de vista
- vista normal
- contenido del esquema
- iconos de esquema
- ajustar divisor vertical
- vista única
- estado de barra
- tamaño de dimensión
- ajuste automático
- zoom predeterminado
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Descubra las propiedades de vista de Aspose.Slides para PHP a través de Java para personalizar formatos PPT, PPTX y ODP — ajuste diseños, niveles de zoom y configuraciones de visualización."
---

{{% alert color="primary" %}} 

La vista normal consta de tres regiones de contenido: la propia diapositiva, una región de contenido lateral y una región de contenido inferior. Propiedades relacionadas con la posición de las diferentes regiones de contenido. Esta información permite a la aplicación guardar su estado de vista en el archivo, de modo que, al volver a abrirlo, la vista esté en el mismo estado que cuando la presentación se guardó por última vez.

Se ha añadido el método [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) para proporcionar acceso a las propiedades de vista normal de la presentación. 

Se han añadido las clases [NormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewRestoredProperties), sus descendientes y el enum [SplitterBarStateType](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType).  

{{% /alert %}} 

## **Acerca de INormalViewProperties**

Representa las propiedades de vista normal.

Los métodos [getShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) y [setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) especifican si la aplicación debe mostrar iconos al mostrar contenido de esquema en cualquiera de las regiones de contenido del modo de vista normal.

Los métodos [getSnapVerticalSplitter](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) y [setSnapVerticalSplitter](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) especifican si el divisor vertical debe ajustarse a un estado minimizado cuando la región lateral es lo suficientemente pequeña.

La propiedad [getPreferSingleView](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) y [setPreferSingleView](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) especifican si el usuario prefiere ver una región de contenido única a pantalla completa en lugar de la vista normal estándar con tres regiones de contenido. Si está activada, la aplicación puede elegir mostrar una de las regiones de contenido en toda la ventana.

Los métodos [getVerticalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) y [getHorizontalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) especifican el estado en el que debe mostrarse la barra divisor horizontal o vertical. Una barra divisor horizontal separa la diapositiva de la región de contenido situada bajo la diapositiva; una barra divisor vertical separa la diapositiva de la región de contenido lateral. Los valores posibles son: [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType/#Minimized), [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType/#Maximized) y [SplitterBarStateType::Restored](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType/#Restored).

Los métodos [getRestoredLeft](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) y [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties#getRestoredTop) especifican el dimensionado de la región superior o lateral de la diapositiva de la vista normal, cuando se aplica el valor [SplitterBarStateType::Restored](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType/#Restored) a [getVerticalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) y a [getHorizontalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) respectivamente.

## **Acerca de restaurar INormalViewProperties**

Especifica el dimensionado de la región de la diapositiva (anchura cuando es hijo de [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getRestoredTop), altura cuando es hijo de [getRestoredLeft](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft)) de la vista normal, cuando la región tiene un tamaño restaurado variable (ni minimizado ni maximizado). 

El método [getDimensionSize](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) especifica el tamaño de la región de la diapositiva (anchura cuando es hijo de restoredTop, altura cuando es hijo de restoredLeft).

El método [getAutoAdjust](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) especifica si el tamaño de la región de contenido lateral debe compensar el nuevo tamaño al redimensionar la ventana que contiene la vista dentro de la aplicación.

A continuación se muestra un ejemplo que indica cómo acceder a las propiedades [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) de una presentación.

```php
  $pres = new Presentation();
  try {
    $pres->getViewProperties()->getNormalViewProperties()->setHorizontalBarState(SplitterBarStateType::Restored);
    $pres->getViewProperties()->getNormalViewProperties()->setVerticalBarState(SplitterBarStateType::Maximized);

    # Restaurar las propiedades de vista de la presentación
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setAutoAdjust(true);
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setDimensionSize(80);
    $pres->getViewProperties()->getNormalViewProperties()->setShowOutlineIcons(true);
    $pres->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **Establecer el valor de zoom predeterminado**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java ahora admite la configuración del valor de zoom predeterminado para una presentación, de modo que, al abrirla, el zoom ya esté establecido. Esto puede lograrse configurando el [ViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties) de una presentación. Tanto [getSlideViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) como [getNotesViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) pueden establecerse mediante código. En este tema veremos, con un ejemplo, cómo establecer las [View Properties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties) de [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) en [Aspose.Slides](/slides/es/).

{{% /alert %}} 

Para establecer las propiedades de vista, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Configure las [View Properties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties) de [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Guarde la presentación como un archivo [PPTX](https://docs.fileformat.com/presentation/pptx/). En el ejemplo que se muestra a continuación, hemos establecido el valor de zoom tanto para la vista de diapositiva como para la vista de notas.

```php
  $presentation = new Presentation();
  try {
    # Configurar las propiedades de vista de la presentación
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100); // Valor de zoom en porcentaje para la vista de diapositiva
    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100); // Valor de zoom en porcentaje para la vista de notas

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```


## **Preguntas frecuentes**

**¿Puedo establecer diferentes configuraciones de vista para distintas secciones de una presentación?**

Los [view settings](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/) se definen a nivel de presentación ([Normal View](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getslideviewproperties/)), no por sección, por lo que un único conjunto de parámetros se aplica a todo el documento cuando se abre.

**¿Puedo predefinir diferentes estados de vista para distintos usuarios?**

No. Los ajustes se almacenan en el archivo y se comparten. Las aplicaciones de visualización pueden respetar las preferencias del usuario, pero el propio archivo contiene un único conjunto de propiedades de vista.

**¿Puedo preparar una plantilla con View Properties predefinidas para que las nuevas presentaciones se abran de la misma forma?**

Sí. Como los [view properties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/) se guardan a nivel de presentación, puede incrustarlos en una plantilla y crear nuevos documentos a partir de ella con la misma configuración de vista inicial.