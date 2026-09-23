---
title: Recuperar y actualizar las propiedades de vista de la presentación en PHP
linktitle: Propiedades de vista
type: docs
weight: 80
url: /es/php-java/presentation-view-properties/
keywords:
- propiedades de vista
- vista normal
- contenido de esquema
- iconos de esquema
- ajuste del divisor vertical
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
description: "Descubra las propiedades de vista de Aspose.Slides for PHP via Java para personalizar los formatos de diapositivas PPT, PPTX y ODP — ajuste diseños, niveles de zoom y configuraciones de visualización."
---
## **Introducción**

La vista normal consta de tres regiones de contenido: la diapositiva en sí, una región de contenido lateral y una región de contenido inferior. Propiedades relacionadas con la posición de las diferentes regiones de contenido. Esta información permite a la aplicación guardar su estado de vista en el archivo, de modo que al volver a abrirlo la vista se encuentre en el mismo estado que cuando la presentación se guardó por última vez.

Se ha añadido el método [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/es/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) para proporcionar acceso a las propiedades de vista normal de la presentación. 

Se han añadido las clases [NormalViewProperties](https://reference.aspose.com/slides/es/php-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/es/php-java/aspose.slides/NormalViewRestoredProperties) y sus descendientes, el enum [SplitterBarStateType](https://reference.aspose.com/slides/es/php-java/aspose.slides/SplitterBarStateType) han sido añadidos.

## **Acerca de INormalViewProperties**

Representa las propiedades de vista normal.

Los métodos [getShowOutlineIcons](https://reference.aspose.com/slides/es/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) y [setShowOutlineIcons](https://reference.aspose.com/slides/es/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) especifican si la aplicación debe mostrar iconos al mostrar contenido de esquema en cualquiera de las regiones de contenido del modo de vista normal.

Los métodos [getSnapVerticalSplitter](https://reference.aspose.com/slides/es/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) y [setSnapVerticalSplitter](https://reference.aspose.com/slides/es/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) especifican si la divisoria vertical debe ajustarse a un estado minimizado cuando la región lateral es lo suficientemente pequeña.

Las propiedades [getPreferSingleView](https://reference.aspose.com/slides/es/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) y [setPreferSingleView](https://reference.aspose.com/slides/es/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) especifican si el usuario prefiere ver una única región de contenido a pantalla completa en lugar de la vista normal estándar con tres regiones de contenido. Si está habilitado, la aplicación puede elegir mostrar una de las regiones de contenido en toda la ventana.

Los métodos [getVerticalBarState](https://reference.aspose.com/slides/es/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) y [getHorizontalBarState](https://reference.aspose.com/slides/es/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) especifican el estado en el que debe mostrarse la barra divisoria horizontal o vertical. Una barra divisoria horizontal separa la diapositiva de la región de contenido situada debajo de la diapositiva, la barra divisoria vertical separa la diapositiva de la región de contenido lateral. Los valores posibles son: [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/es/php-java/aspose.slides/SplitterBarStateType/#Minimized), [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/es/php-java/aspose.slides/SplitterBarStateType/#Maximized) y [SplitterBarStateType::Restored](https://reference.aspose.com/slides/es/php-java/aspose.slides/SplitterBarStateType/#Restored).

Los métodos [getRestoredLeft](https://reference.aspose.com/slides/es/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) y [getRestoredTop](https://reference.aspose.com/slides/es/php-java/aspose.slides/NormalViewProperties#getRestoredTop) especifican el dimensionado de la región superior o lateral de la diapositiva en la vista normal, cuando se aplica el valor [SplitterBarStateType::Restored](https://reference.aspose.com/slides/es/php-java/aspose.slides/SplitterBarStateType/#Restored) a [getVerticalBarState](https://reference.aspose.com/slides/es/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) y [getHorizontalBarState](https://reference.aspose.com/slides/es/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) respectivamente.

## **Acerca de la restauración de INormalViewProperties**

Especifica el dimensionado de la región de la diapositiva (anchura cuando es hija de [getRestoredTop](https://reference.aspose.com/slides/es/php-java/aspose.slides/NormalViewProperties/#getRestoredTop), altura cuando es hija de [getRestoredLeft](https://reference.aspose.com/slides/es/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft)) de la vista normal, cuando la región tiene un tamaño restaurado variable (ni minimizado ni maximizado). 

El método [getDimensionSize](https://reference.aspose.com/slides/es/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) especifica el tamaño de la región de la diapositiva (anchura cuando es hija de restoredTop, altura cuando es hija de restoredLeft).

El método [getAutoAdjust](https://reference.aspose.com/slides/es/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) especifica si el tamaño de la región de contenido lateral debe compensar el nuevo tamaño al cambiar el tamaño de la ventana que contiene la vista dentro de la aplicación.

A continuación se muestra un ejemplo que indica cómo acceder a las propiedades [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/es/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) de una presentación.

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
{{% alert color="info" %}} 

Aspose.Slides for PHP via Java ahora admite establecer el valor de zoom predeterminado para una presentación de modo que, al abrirla, el zoom ya esté configurado. Esto puede hacerse estableciendo las [ViewProperties](https://reference.aspose.com/slides/es/php-java/aspose.slides/ViewProperties) de una presentación. Tanto [getSlideViewProperties](https://reference.aspose.com/slides/es/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) como [getNotesViewProperties](https://reference.aspose.com/slides/es/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) pueden establecerse programáticamente. En este tema, veremos con un ejemplo cómo establecer las [View Properties](https://reference.aspose.com/slides/es/php-java/aspose.slides/ViewProperties) de [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation) en Aspose.Slides.

{{% /alert %}} 

Para establecer las propiedades de vista, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation).
1. Establezca las [View Properties](https://reference.aspose.com/slides/es/php-java/aspose.slides/ViewProperties) de [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation).
1. Guarde la presentación como un archivo [PPTX ](https://docs.fileformat.com/presentation/pptx/)file.
   En el ejemplo que se muestra a continuación, hemos establecido el valor de zoom tanto para la vista de diapositiva como para la vista de notas.

```php
  $presentation = new Presentation();
  try {
    # Establecer las propiedades de vista de la presentación
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100); // Valor de zoom en porcentaje para la vista de diapositiva
    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100); // Valor de zoom en porcentaje para la vista de notas

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Establecer el espaciado de la cuadrícula**

Utilice [Presentation::getViewProperties](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#getViewProperties) para acceder a la configuración de vista a nivel de presentación. Los métodos [ViewProperties::getGridSpacing](https://reference.aspose.com/slides/es/php-java/aspose.slides/viewproperties/#getGridSpacing) y [ViewProperties::setGridSpacing](https://reference.aspose.com/slides/es/php-java/aspose.slides/viewproperties/#setGridSpacing) leen o modifican el intervalo de la cuadrícula de edición subyacente. Esta configuración se aplica a toda la presentación, no a una diapositiva individual. El espaciado de la cuadrícula se especifica en puntos, donde 72 puntos equivalen a una pulgada. Utilice un valor positivo, según lo requiera la documentación de la API.

El siguiente ejemplo abre un archivo `demo.pptx` existente, muestra su espaciado de cuadrícula actual, establece un intervalo de un cuarto de pulgada y guarda el resultado.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $gridSpacing = $presentation->getViewProperties()->getGridSpacing();
    echo "Current grid spacing: " . $gridSpacing . " points\n";

    $presentation->getViewProperties()->setGridSpacing(18.0);
    $presentation->save("grid-spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La cuadrícula es diferente de las [drawing guides](/slides/es/php-java/drawing-guides/). El espaciado de la cuadrícula controla un intervalo regular, mientras que las guías de dibujo son líneas de alineación horizontales o verticales posicionadas individualmente. Añadir, mover o eliminar guías de dibujo no cambia el espaciado de la cuadrícula.

Tanto la cuadrícula como las guías de dibujo son ayudas de edición. No se renderizan como contenido de diapositiva en PDF, imágenes, SVG o una presentación. Guardar el espaciado de la cuadrícula no garantiza que un editor muestre la cuadrícula: su visibilidad también depende de las preferencias del visor o del editor.

## **Mostrar u Ocultar Comentarios al Abrir una Presentación**

Utilice [Presentation::getViewProperties](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/getviewproperties/) para acceder a la configuración de vista a nivel de presentación. Use [ViewProperties::getShowComments](https://reference.aspose.com/slides/es/php-java/aspose.slides/viewproperties/getshowcomments/) y [ViewProperties::setShowComments](https://reference.aspose.com/slides/es/php-java/aspose.slides/viewproperties/setshowcomments/) para leer o modificar la preferencia almacenada sobre si los comentarios deben mostrarse cuando la presentación se abre en PowerPoint u otro editor compatible.

Esta configuración solo controla la preferencia de vista almacenada. No añade, elimina, edita o resuelve comentarios. Ocultar los comentarios preserva su contenido, autores, posiciones, respuestas y estados. Consulte [Presentation Comments](/slides/es/php-java/presentation-comments/) para operaciones que modifican los propios comentarios.

El siguiente ejemplo requiere un archivo `comments.pptx` existente que contenga comentarios. Muestra la configuración de visibilidad actual, solicita que los comentarios se oculten y guarda un nuevo PPTX sin eliminar ningún comentario. También utiliza [ViewProperties::setLastView](https://reference.aspose.com/slides/es/php-java/aspose.slides/viewproperties/setlastview/) con [ViewType::SlideView](https://reference.aspose.com/slides/es/php-java/aspose.slides/viewtype/#SlideView) para configurar la vista de edición inicial junto con la visibilidad de los comentarios.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation("comments.pptx");
try {
    $showComments = $presentation->getViewProperties()->getShowComments();
    echo "Current comment visibility: " . java_values($showComments) . PHP_EOL;

    $presentation->getViewProperties()->setShowComments(NullableBool::False);
    $presentation->getViewProperties()->setLastView(ViewType::SlideView);
    $presentation->save("comments-hidden.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Esta configuración no determina si los comentarios se incluyen en las exportaciones a PDF, HTML, imagen, notas o folletos. Configure por separado las opciones específicas de exportación correspondientes.

## **Preguntas frecuentes**

**¿Por qué la cuadrícula no es visible después de volver a abrir la presentación?**

El archivo almacena el espaciado de la cuadrícula, pero el editor controla si la cuadrícula se muestra. Verifique la configuración de visibilidad de la cuadrícula del editor.

**¿Eliminar las guías de dibujo cambia el espaciado de la cuadrícula?**

No. Las guías de dibujo y el espaciado de la cuadrícula son configuraciones independientes. Eliminar las guías deja el intervalo de la cuadrícula almacenado sin cambios.

**¿Puedo establecer diferentes configuraciones de vista para distintas secciones de una presentación?**

Las [view settings](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/getviewproperties/) se definen a nivel de presentación ([Normal View](https://reference.aspose.com/slides/es/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/es/php-java/aspose.slides/viewproperties/getslideviewproperties/)), no por sección, por lo que un único conjunto de parámetros se aplica a todo el documento al abrirse.

**¿Puedo predefinir diferentes estados de vista para distintos usuarios?**

No. Las configuraciones se almacenan en el archivo y se comparten. Las aplicaciones visor pueden respetar las preferencias del usuario, pero el archivo en sí contiene un único conjunto de propiedades de vista.

**¿Puedo preparar una plantilla con View Properties predefinidas para que las nuevas presentaciones se abran de la misma manera?**

Sí. Dado que las [view properties](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/getviewproperties/) se almacenan a nivel de presentación, puede incrustarlas en una plantilla y crear nuevos documentos a partir de ella con la misma configuración de vista inicial.