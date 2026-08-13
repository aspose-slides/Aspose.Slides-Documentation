---
title: Recuperar y actualizar las propiedades de vista de la presentación en Java
linktitle: Propiedades de vista
type: docs
weight: 80
url: /es/java/presentation-view-properties/
keywords:
- propiedades de vista
- vista normal
- contenido del esquema
- iconos del esquema
- ajusta divisor vertical
- vista única
- estado de la barra
- tamaño de la dimensión
- ajuste automático
- zoom predeterminado
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Descubra las propiedades de vista de Aspose.Slides para Java para personalizar formatos PPT, PPTX y ODP de diapositivas: ajuste diseños, niveles de zoom y configuraciones de visualización."
---
## **Introducción**

La vista normal consta de tres regiones de contenido: la propia diapositiva, una región de contenido lateral y una región de contenido inferior. Propiedades relacionadas con la posición de las distintas regiones de contenido. Esta información permite a la aplicación guardar su estado de vista en el archivo, de modo que, al volver a abrirlo, la vista se encuentre en el mismo estado que cuando se guardó por última vez la presentación.

Se ha añadido el método [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/es/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) para proporcionar acceso a las propiedades de vista normal de la presentación.  

Se han añadido las interfaces [INormalViewProperties](https://reference.aspose.com/slides/es/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/es/java/com.aspose.slides/INormalViewRestoredProperties) así como sus descendientes, y el enumerado [SplitterBarStateType](https://reference.aspose.com/slides/es/java/com.aspose.slides/SplitterBarStateType) enum han sido añadidos.

## **Acerca de INormalViewProperties**

Representa propiedades de vista normal.

Los métodos [getShowOutlineIcons](https://reference.aspose.com/slides/es/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) y [setShowOutlineIcons](https://reference.aspose.com/slides/es/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) especifican si la aplicación debe mostrar íconos al visualizar contenido del esquema en cualquiera de las regiones de contenido del modo de vista normal.

Los métodos [getSnapVerticalSplitter](https://reference.aspose.com/slides/es/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) y [setSnapVerticalSplitter](https://reference.aspose.com/slides/es/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) especifican si el divisor vertical debe ajustarse a un estado minimizado cuando la región lateral es lo suficientemente pequeña.

La propiedad [getPreferSingleView](https://reference.aspose.com/slides/es/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) y [setPreferSingleView](https://reference.aspose.com/slides/es/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean--) especifica si el usuario prefiere ver una única región de contenido a pantalla completa en lugar de la vista normal estándar con tres regiones de contenido. Si está activada, la aplicación puede optar por mostrar una de las regiones de contenido en toda la ventana.

Los métodos [getVerticalBarState](https://reference.aspose.com/slides/es/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) y [getHorizontalBarState](https://reference.aspose.com/slides/es/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) especifican el estado en el que debe mostrarse la barra divisor horizontal o vertical. Una barra divisor horizontal separa la diapositiva de la región de contenido situada debajo de la diapositiva, mientras que una barra divisor vertical separa la diapositiva de la región de contenido lateral. Los valores posibles son: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/es/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/es/java/com.aspose.slides/SplitterBarStateType#Maximized) y [SplitterBarStateType.Restored](https://reference.aspose.com/slides/es/java/com.aspose.slides/SplitterBarStateType#Restored).

Los métodos [getRestoredLeft](https://reference.aspose.com/slides/es/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) y [getRestoredTop](https://reference.aspose.com/slides/es/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) especifican el dimensionado de la región superior o lateral de la diapositiva en la vista normal, cuando se aplica el valor [SplitterBarStateType.Restored](https://reference.aspose.com/slides/es/java/com.aspose.slides/SplitterBarStateType#Restored) a [getVerticalBarState](https://reference.aspose.com/slides/es/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) y [getHorizontalBarState](https://reference.aspose.com/slides/es/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) respectivamente.

## **Acerca de restaurar INormalViewProperties**

Especifica el dimensionado de la región de la diapositiva (anchura cuando es hija de [getRestoredTop](https://reference.aspose.com/slides/es/java/com.aspose.slides/INormalViewProperties#getRestoredTop--), altura cuando es hija de [getRestoredLeft](https://reference.aspose.com/slides/es/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) en la vista normal, cuando la región tiene un tamaño restaurado variable (ni minimizado ni maximizado).  

El método [getDimensionSize](https://reference.aspose.com/slides/es/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) especifica el tamaño de la región de la diapositiva (anchura cuando es hija de restoredTop, altura cuando es hija de restoredLeft).  

El método [getAutoAdjust](https://reference.aspose.com/slides/es/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) especifica si el tamaño de la región de contenido lateral debe compensar el nuevo tamaño al redimensionar la ventana que contiene la vista dentro de la aplicación.  

A continuación se muestra un ejemplo que indica cómo acceder a las propiedades [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/es/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) de una presentación.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // Restaurar las propiedades de vista de la presentación
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);

    pres.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```
## **Establecer el valor de zoom predeterminado**

{{% alert color="info" %}} 

Aspose.Slides para Java ahora admite establecer el valor de zoom predeterminado de una presentación de modo que, al abrirla, el zoom ya esté configurado. Esto puede hacerse estableciendo el [ViewProperties](https://reference.aspose.com/slides/es/java/com.aspose.slides/ViewProperties) de una presentación. Tanto [getSlideViewProperties](https://reference.aspose.com/slides/es/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) como [getNotesViewProperties](https://reference.aspose.com/slides/es/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) pueden configurarse programáticamente. En este tema, veremos con un ejemplo cómo establecer las [View Properties](https://reference.aspose.com/slides/es/java/com.aspose.slides/ViewProperties) de [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation) en [Aspose.Slides](/slides/es/).

{{% /alert %}} 

Para establecer las propiedades de vista, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation).  
1. Establezca las [View Properties](https://reference.aspose.com/slides/es/java/com.aspose.slides/ViewProperties) de la [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation).  
1. Guarde la presentación como un archivo [PPTX](https://docs.fileformat.com/presentation/pptx/) .  
   En el ejemplo que se muestra a continuación, hemos establecido el valor de zoom tanto para la vista de diapositiva como para la vista de notas.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Establecer las propiedades de vista de la presentación
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Valor de zoom en porcentaje para la vista de diapositiva
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Valor de zoom en porcentaje para la vista de notas 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
## **Preguntas frecuentes**

### ¿Puedo establecer diferentes configuraciones de vista para distintas secciones de una presentación?

Las [configuraciones de vista](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#getViewProperties--) se definen a nivel de presentación ([Normal View](https://reference.aspose.com/slides/es/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/es/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)), no por sección, por lo que un único conjunto de parámetros se aplica a todo el documento al abrirse.

### ¿Puedo predefinir diferentes estados de vista para distintos usuarios?

No. Las configuraciones se almacenan en el archivo y se comparten. Las aplicaciones de visualización pueden respetar las preferencias del usuario, pero el archivo en sí contiene un único conjunto de propiedades de vista.

### ¿Puedo preparar una plantilla con propiedades de vista predefinidas para que las nuevas presentaciones se abran de la misma manera?

Sí. Dado que las [propiedades de vista](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#getViewProperties--) se almacenan a nivel de presentación, puede incorporarlas en una plantilla y crear nuevos documentos a partir de ella con la misma configuración de vista inicial.