---
title: Propiedades de la Vista de Presentación
type: docs
url: /es/androidjava/presentation-view-properties/
---

{{% alert color="primary" %}} 

La vista normal consiste en tres regiones de contenido: la diapositiva en sí, una región de contenido lateral y una región de contenido en la parte inferior. Propiedades referentes a la posición de las diferentes regiones de contenido. Esta información permite que la aplicación guarde su estado de vista en el archivo, de manera que al reabrirse, la vista esté en el mismo estado que cuando se guardó por última vez la presentación.

El método [**IViewProperties.*getNormalViewProperties***](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) se ha agregado para proporcionar acceso a las propiedades de vista normal de la presentación. 

Se han agregado las interfaces [**INormalViewProperties**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties), [**INormalViewRestoredProperties**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewRestoredProperties) y sus descendientes, el enum [**SplitterBarStateType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType).

{{% /alert %}} 

## **Acerca de INormalViewProperties** #
Representa las propiedades de la vista normal.

Los métodos [**getShowOutlineIcons**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) y [**setShowOutlineIcons**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) especifican si la aplicación debe mostrar íconos al mostrar contenido de esquema en cualquiera de las regiones de contenido del modo de vista normal.

Los métodos [**getSnapVerticalSplitter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) y [**setSnapVerticalSplitter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) especifican si el divisor vertical debe ajustarse a un estado minimizado cuando la región lateral es lo suficientemente pequeña.

La propiedad [**getPreferSingleView**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) y [**setPreferSingleView**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) especifica si el usuario prefiere ver una región de contenido a pantalla completa en lugar de la vista normal estándar con tres regiones de contenido. Si está habilitado, la aplicación puede optar por mostrar una de las regiones de contenido en toda la ventana.

Los métodos [**getVerticalBarState**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) y [**getHorizontalBarState**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) especifican el estado que se debe mostrar para la barra divisoria horizontal o vertical. Una barra divisoria horizontal separa la diapositiva de la región de contenido debajo de la diapositiva, y la barra divisoria vertical separa la diapositiva de la región de contenido lateral. Los valores posibles son: [**SplitterBarStateType.Minimized**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [**SplitterBarStateType.Maximized**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) y [**SplitterBarStateType.Restored**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

Los métodos [**getRestoredLeft**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) y [**getRestoredTop**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) especifican el tamaño de la región superior o lateral de la diapositiva de la vista normal, cuando se aplica el valor [**SplitterBarStateType.Restored**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType#Restored) para [**getVerticalBarState**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) y [**getHorizontalBarState**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) respectivamente.

## **Acerca de la Restauración de INormalViewProperties** 
Especifica el tamaño de la región de la diapositiva (ancho cuando es hijo de [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--), altura cuando es hijo de [getRestoredLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) de la vista normal, cuando la región tiene un tamaño restaurado variable (ni minimizado ni maximizado). 

El método [**getDimensionSize**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) especifica el tamaño de la región de la diapositiva (ancho cuando es hijo de restoredTop, altura cuando es hijo de restoredLeft).

El método [**getAutoAdjust**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) especifica si el tamaño de la región de contenido lateral debe compensar el nuevo tamaño al ajustar el tamaño de la ventana que contiene la vista dentro de la aplicación.

A continuación se muestra un ejemplo de cómo se pueden acceder a las propiedades de [**ViewProperties.getNormalViewProperties**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) para una presentación.

```java
// Instanciar un objeto Presentation que representa un archivo de presentación
Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // Restaurar las Propiedades de Vista de la Presentación
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);

    pres.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Establecer Valor de Zoom Predeterminado**
{{% alert color="primary" %}} 

Aspose.Slides para Android a través de Java ahora admite establecer el valor de zoom predeterminado para la presentación de modo que, cuando se abra la presentación, el zoom ya esté configurado. Esto se puede hacer estableciendo las [ViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties) de una presentación. [getSlideViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) así como [getNotesViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) se pueden establecer programáticamente. En este tema, veremos con un ejemplo cómo establecer las [Propiedades de Vista](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties) de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) en [Aspose.Slides](/slides/es/).

{{% /alert %}} 

Para establecer las propiedades de vista, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Establezca las [Propiedades de Vista](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties) de la [Presentación](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Escriba la presentación como un archivo [PPTX ](https://docs.fileformat.com/presentation/pptx/).
   En el ejemplo dado a continuación, hemos establecido el valor de zoom para la vista de diapositivas así como para la vista de notas.

```java
// Instanciar un objeto Presentation que representa un archivo de presentación
Presentation presentation = new Presentation();
try {
    // Configurando las Propiedades de Vista de la Presentación
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Valor de zoom en porcentajes para la vista de diapositivas
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Valor de zoom en porcentajes para la vista de notas 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```