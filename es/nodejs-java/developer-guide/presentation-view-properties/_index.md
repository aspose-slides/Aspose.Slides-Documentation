---
title: Recuperar y actualizar propiedades de vista de la presentación en JavaScript
linktitle: Propiedades de vista
type: docs
weight: 80
url: /es/nodejs-java/presentation-view-properties/
keywords:
- propiedades de vista
- vista normal
- contenido del esquema
- iconos de esquema
- ajustar divisor vertical
- vista única
- estado de la barra
- tamaño de dimensión
- ajuste automático
- zoom predeterminado
- PowerPoint
- OpenDocument
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Descubra las propiedades de vista de Aspose.Slides para Node.js via Java para personalizar los formatos de diapositivas PPT, PPTX y ODP, ajustando diseños, niveles de zoom y configuraciones de visualización."
---
## **Introducción**

La vista normal consiste en tres regiones de contenido: la diapositiva propia, una región de contenido lateral y una región de contenido inferior. Propiedades relacionadas con la posición de las diferentes regiones de contenido. Esta información permite a la aplicación guardar su estado de vista en el archivo, de modo que al volver a abrirse la vista esté en el mismo estado que cuando se guardó por última vez la presentación.

El método [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) ha sido añadido para proporcionar acceso a las propiedades de vista normal de la presentación.  

Se han añadido las clases [NormalViewProperties](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/NormalViewRestoredProperties) y sus descendientes, y el enumerado [SplitterBarStateType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/SplitterBarStateType) .

## **Acerca de NormalViewProperties**

Representa las propiedades de la vista normal.

Los métodos [getShowOutlineIcons](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) y [setShowOutlineIcons](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) especifican si la aplicación debe mostrar iconos al mostrar contenido de esquema en cualquiera de las regiones de contenido del modo de vista normal.

Los métodos [getSnapVerticalSplitter](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) y [setSnapVerticalSplitter](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) especifican si la barra divisoria vertical debe ajustarse a un estado minimizado cuando la región lateral es lo suficientemente pequeña.

La propiedad [getPreferSingleView](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) y [setPreferSingleView](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean-) especifican si el usuario prefiere ver una única región de contenido a ventana completa en lugar de la vista normal estándar con tres regiones de contenido. Si está activada, la aplicación puede elegir mostrar una de las regiones de contenido en toda la ventana.

Los métodos [getVerticalBarState](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) y [getHorizontalBarState](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) especifican el estado en el que debe mostrarse la barra divisoria horizontal o vertical. Una barra divisoria horizontal separa la diapositiva de la región de contenido situada bajo la diapositiva, una barra divisoria vertical separa la diapositiva de la región de contenido lateral. Los valores posibles son: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) y [SplitterBarStateType.Restored](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/SplitterBarStateType#Restored).

Los métodos [getRestoredLeft](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) y [getRestoredTop](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) especifican el dimensionado de la región superior o lateral de la diapositiva en la vista normal, cuando se aplica el valor [SplitterBarStateType.Restored](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/SplitterBarStateType#Restored) a [getVerticalBarState](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) y [getHorizontalBarState](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) respectivamente.

## **Acerca de Restaurar NormalViewProperties**

Especifica el dimensionado de la región de la diapositiva (anchura cuando es hijo de [getRestoredTop](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--), altura cuando es hijo de [getRestoredLeft](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--)) de la vista normal, cuando la región tiene un tamaño restaurado variable (ni minimizado ni maximizado).  

El método [getDimensionSize](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) especifica el tamaño de la región de la diapositiva (anchura cuando es hijo de restoredTop, altura cuando es hijo de restoredLeft).  

El método [getAutoAdjust](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) especifica si el tamaño de la región de contenido lateral debe compensar el nuevo tamaño al redimensionar la ventana que contiene la vista dentro de la aplicación.  

A continuación se muestra un ejemplo que indica cómo acceder a las propiedades [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) de una presentación.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(aspose.slides.SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(aspose.slides.SplitterBarStateType.Maximized);

    // Restaurar las propiedades de vista de la presentación
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);
    pres.save("presentation_normal_view_state.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Establecer el valor de zoom predeterminado**

{{% alert color="info" %}} 

Aspose.Slides for Node.js via Java ahora admite establecer el valor de zoom predeterminado para una presentación de modo que, cuando la presentación se abra, el zoom ya esté configurado. Esto puede hacerse configurando las [ViewProperties](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ViewProperties) de una presentación. Los métodos [getSlideViewProperties](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) y [getNotesViewProperties](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) pueden establecerse mediante código. En este artículo, veremos con un ejemplo cómo establecer las [View Properties](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ViewProperties) de [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation) en Aspose.Slides.

{{% /alert %}} 

Para establecer las propiedades de vista, siga los pasos a continuación:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation).  
1. Establecer las [View Properties](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ViewProperties) de la [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation).  
1. Guardar la presentación como un archivo [PPTX](https://docs.fileformat.com/presentation/pptx/).  
   En el ejemplo siguiente, hemos establecido el valor de zoom tanto para la vista de diapositiva como para la vista de notas.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    // Establecer las propiedades de vista de la presentación
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Valor de zoom en porcentajes para la vista de diapositiva
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Valor de zoom en porcentajes para la vista de notas
    presentation.save("Zoom_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Establecer el espaciado de la cuadrícula**

Utilice [Presentation.getViewProperties](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/#getViewProperties--) para acceder a la configuración de vista a nivel de presentación. Los métodos [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/viewproperties/#getGridSpacing--) y [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/viewproperties/#setGridSpacing-float-) leen o modifican el intervalo de la cuadrícula de edición subyacente. Esta configuración se aplica a toda la presentación, no a una diapositiva individual. El espaciado de la cuadrícula se especifica en puntos, donde 72 puntos equivalen a una pulgada. Utilice un valor positivo, según lo requiera la documentación de la API.

El siguiente ejemplo abre un `demo.pptx` existente, muestra su espaciado de cuadrícula actual, establece un intervalo de un cuarto de pulgada y guarda el resultado.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("demo.pptx");
try {
    var gridSpacing = presentation.getViewProperties().getGridSpacing();
    console.log("Current grid spacing: " + gridSpacing + " points");

    presentation.getViewProperties().setGridSpacing(18);
    presentation.save("grid-spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La cuadrícula es diferente de las [drawing guides](/slides/es/nodejs-java/drawing-guides/). El espaciado de la cuadrícula controla un intervalo regular, mientras que las guías de dibujo son líneas de alineación horizontales o verticales posicionadas individualmente. Añadir, mover o eliminar guías de dibujo no cambia el espaciado de la cuadrícula.

Tanto la cuadrícula como las guías de dibujo son ayudas de edición. No se renderizan como contenido de diapositiva en PDF, imágenes, SVG o una presentación. Guardar el espaciado de la cuadrícula no garantiza que un editor la muestre: su visibilidad también depende de las preferencias del visor o editor.

## **Mostrar u ocultar comentarios al abrir una presentación**

Utilice [Presentation.getViewProperties](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/#getViewProperties--) para acceder a la configuración de vista a nivel de presentación. Utilice [ViewProperties.getShowComments](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/viewproperties/#getShowComments--) y [ViewProperties.setShowComments](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/viewproperties/#setShowComments-byte--) para leer o cambiar la preferencia almacenada sobre si los comentarios deben mostrarse cuando la presentación se abre en PowerPoint u otro editor compatible.

Esta configuración solo controla la preferencia de vista almacenada. No añade, elimina, edita o resuelve comentarios. Ocultar comentarios conserva su contenido, autores, posiciones, respuestas y estados. Consulte [Presentation Comments](/slides/es/nodejs-java/presentation-comments/) para operaciones que modifican los propios comentarios.

El siguiente ejemplo requiere un `comments.pptx` existente que contenga comentarios. Muestra la configuración actual de visibilidad, solicita que los comentarios se oculten y guarda un nuevo PPTX sin eliminar ningún comentario. También utiliza [ViewProperties.setLastView](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/viewproperties/#setLastView-int-) con [ViewType.SlideView](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/viewtype/#SlideView) para configurar la vista de edición inicial junto con la visibilidad de los comentarios.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation("comments.pptx");
try {
    var showComments = presentation.getViewProperties().getShowComments();
    console.log("Current comment visibility: " + showComments);

    var hideComments = java.newByte(aspose.slides.NullableBool.False);
    presentation.getViewProperties().setShowComments(hideComments);
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideView);
    presentation.save("comments-hidden.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Esta configuración no determina si los comentarios se incluyen en las exportaciones a PDF, HTML, imagen, notas o folletos. Configure las opciones específicas de exportación correspondientes por separado.

## **Preguntas frecuentes**

**¿Por qué la cuadrícula no es visible después de volver a abrir la presentación?**

El archivo guarda el espaciado de la cuadrícula, pero el editor controla si la cuadrícula se muestra. Verifique la configuración de visibilidad de la cuadrícula del editor.

**¿Eliminar las guías de dibujo cambia el espaciado de la cuadrícula?**

No. Las guías de dibujo y el espaciado de la cuadrícula son configuraciones independientes. Eliminar las guías deja el intervalo de cuadrícula almacenado sin cambios.

**¿Puedo establecer diferentes configuraciones de vista para distintas secciones de una presentación?**

Las [view settings](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/getviewproperties/) se definen a nivel de presentación ([Normal View](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/)), no por sección, por lo que un único conjunto de parámetros se aplica a todo el documento al abrirse.

**¿Puedo predefinir diferentes estados de vista para distintos usuarios?**

No. Los ajustes se almacenan en el archivo y son compartidos. Las aplicaciones de visualización pueden respetar las preferencias del usuario, pero el archivo en sí contiene un único conjunto de propiedades de vista.

**¿Puedo preparar una plantilla con View Properties predefinidas para que las nuevas presentaciones se abran de la misma manera?**

Sí. Dado que las [view properties](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/getviewproperties/) se almacenan a nivel de presentación, puede incorporarlas en una plantilla y crear nuevos documentos a partir de ella con la misma configuración de vista inicial.