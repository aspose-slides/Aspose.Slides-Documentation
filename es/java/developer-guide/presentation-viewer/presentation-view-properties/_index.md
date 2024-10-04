---
title: Propiedades de Vista de Presentación
type: docs
url: /java/presentation-view-properties/
---

{{% alert color="primary" %}} 

La vista normal consiste en tres regiones de contenido: la diapositiva en sí, una región de contenido lateral y una región de contenido inferior. Propiedades relacionadas con la posición de las diferentes regiones de contenido. Esta información permite a la aplicación guardar el estado de su vista en el archivo, de modo que cuando se vuelva a abrir, la vista esté en el mismo estado que cuando se guardó por última vez la presentación.

El método [**IViewProperties.*getNormalViewProperties***](https://reference.aspose.com/slides/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) se ha añadido para proporcionar acceso a las propiedades de vista normal de la presentación.

Se han añadido las interfaces [**INormalViewProperties**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties), [**INormalViewRestoredProperties**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewRestoredProperties) y sus descendientes, así como el enum [**SplitterBarStateType**](https://reference.aspose.com/slides/java/com.aspose.slides/SplitterBarStateType).

{{% /alert %}} 


## **Acerca de INormalViewProperties** #
Representa las propiedades de vista normal.

Los métodos [**getShowOutlineIcons**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) y [**setShowOutlineIcons**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) especifican si la aplicación debería mostrar íconos al mostrar contenido de esquema en cualquiera de las regiones de contenido del modo de vista normal.

Los métodos [**getSnapVerticalSplitter**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) y [**setSnapVerticalSplitter**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) especifican si el divisor vertical debería ajustarse a un estado minimizado cuando la región lateral sea lo suficientemente pequeña.

La propiedad [**getPreferSingleView**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) y [**setPreferSingleView**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) especifica si al usuario le gusta ver una región de contenido de ventana completa sobre la vista normal estándar con tres regiones de contenido. Si está habilitado, la aplicación puede optar por mostrar una de las regiones de contenido en toda la ventana.

Los métodos [**getVerticalBarState**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) y [**getHorizontalBarState**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) especifican el estado en el que debería mostrarse la barra de divisor horizontal o vertical. Una barra de divisor horizontal separa la diapositiva de la región de contenido debajo de la diapositiva, la barra de divisor vertical separa la diapositiva de la región de contenido lateral. Los valores posibles son: [**SplitterBarStateType.Minimized**](https://reference.aspose.com/slides/java/com.aspose.slides/SplitterBarStateType#Minimized), [**SplitterBarStateType.Maximized**](https://reference.aspose.com/slides/java/com.aspose.slides/SplitterBarStateType#Maximized) y [**SplitterBarStateType.Restored**](https://reference.aspose.com/slides/java/com.aspose.slides/SplitterBarStateType#Restored).

Los métodos [**getRestoredLeft**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) y [**getRestoredTop**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) especifican el tamaño de la región de diapositivas superior o lateral de la vista normal, cuando se aplica el valor [**SplitterBarStateType.Restored**](https://reference.aspose.com/slides/java/com.aspose.slides/SplitterBarStateType#Restored) para [**getVerticalBarState**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) y [**getHorizontalBarState**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) respectivamente.


## **Acerca de la Restauración de INormalViewProperties** 
Especifica el tamaño de la región de la diapositiva (ancho cuando es un hijo de [getRestoredTop](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getRestoredTop--), alto cuando es un hijo de [getRestoredLeft](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) de la vista normal, cuando la región tiene un tamaño restaurado variable (ni minimizado ni maximizado). 

El método [**getDimensionSize**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) especifica el tamaño de la región de la diapositiva (ancho cuando sea un hijo de restoredTop, alto cuando sea un hijo de restoredLeft).

El método [**getAutoAdjust**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) especifica si el tamaño de la región de contenido lateral debe compensar el nuevo tamaño al cambiar el tamaño de la ventana que contiene la vista dentro de la aplicación.

A continuación se muestra un ejemplo de cómo puede acceder a las propiedades [**ViewProperties.getNormalViewProperties**](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) para una presentación.

```java
// Instancia un objeto Presentation que representa un archivo de presentación
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

## **Establecer el Valor de Zoom Predeterminado**
{{% alert color="primary" %}} 

Aspose.Slides para Java ahora admite establecer el valor de zoom predeterminado para la presentación, de modo que cuando se abra la presentación, el zoom ya esté configurado. Esto se puede hacer estableciendo las [Propiedades de Vista](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties) de una presentación. Las [getSlideViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) así como [getNotesViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) se pueden establecer programáticamente. En este tema, veremos con un ejemplo cómo establecer las [Propiedades de Vista](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties) de [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) en [Aspose.Slides](/slides/).

{{% /alert %}} 

Para establecer las propiedades de vista, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Establezca las [Propiedades de Vista](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties) de la [Presentación](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Escriba la presentación como un archivo [PPTX](https://docs.fileformat.com/presentation/pptx/).
   En el ejemplo dado a continuación, hemos establecido el valor de zoom para la vista de diapositivas así como para la vista de notas.

```java
// Instancia un objeto Presentation que representa un archivo de presentación
Presentation presentation = new Presentation();
try {
    // Estableciendo las Propiedades de Vista de la Presentación
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Valor de zoom en porcentajes para la vista de diapositivas
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Valor de zoom en porcentajes para la vista de notas 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```