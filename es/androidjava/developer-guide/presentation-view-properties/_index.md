---
title: Recuperar y actualizar las propiedades de vista de la presentación en Android
linktitle: Propiedades de vista
type: docs
weight: 80
url: /es/androidjava/presentation-view-properties/
keywords:
- propiedades de vista
- vista normal
- contenido del esquema
- iconos del esquema
- ajustar divisor vertical
- vista única
- estado de la barra
- tamaño de dimensión
- ajuste automático
- zoom predeterminado
- PowerPoint
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "Descubra las propiedades de vista de Aspose.Slides for Android via Java para personalizar formatos de diapositivas PPT, PPTX y ODP: ajuste diseños, niveles de zoom y configuraciones de visualización."
---
## **Introducción**

La vista normal consta de tres regiones de contenido: la diapositiva en sí, una región de contenido lateral y una región de contenido inferior. Propiedades relacionadas con la ubicación de las distintas regiones de contenido. Esta información permite a la aplicación guardar su estado de vista en el archivo, de modo que al volver a abrirse la vista esté en el mismo estado que cuando la presentación se guardó por última vez.

Se ha añadido el método [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) para proporcionar acceso a las propiedades de vista normal de la presentación.  

Se han añadido las interfaces [INormalViewProperties](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/INormalViewRestoredProperties) y sus descendientes, así como el enumerado [SplitterBarStateType](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/SplitterBarStateType).

## **Acerca de INormalViewProperties**

Representa las propiedades de vista normal.

Los métodos [getShowOutlineIcons](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) y [setShowOutlineIcons](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) especifican si la aplicación debe mostrar iconos al visualizar el contenido del esquema en cualquiera de las regiones de contenido del modo de vista normal.

Los métodos [getSnapVerticalSplitter](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) y [setSnapVerticalSplitter](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) especifican si la barra separadora vertical debe ajustarse a un estado minimizado cuando la región lateral es lo suficientemente pequeña.

La propiedad [getPreferSingleView](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) y [setPreferSingleView](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) especifican si el usuario prefiere ver una única región de contenido a pantalla completa en lugar de la vista normal estándar con tres regiones de contenido. Si está activada, la aplicación puede optar por mostrar una de las regiones de contenido en toda la ventana.

Los métodos [getVerticalBarState](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) y [getHorizontalBarState](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) especifican el estado en el que debe mostrarse la barra separadora horizontal o vertical. Una barra separadora horizontal separa la diapositiva de la región de contenido situada debajo de ella; una barra separadora vertical separa la diapositiva de la región de contenido lateral. Los valores posibles son: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) y [SplitterBarStateType.Restored](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

Los métodos [getRestoredLeft](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) y [getRestoredTop](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) especifican el dimensionado de la región superior o lateral de la diapositiva en la vista normal, cuando se aplica el valor [SplitterBarStateType.Restored](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/SplitterBarStateType#Restored) a [getVerticalBarState](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) y [getHorizontalBarState](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) respectivamente.

## **Acerca de la restauración de INormalViewProperties**

Especifica el dimensionado de la región de la diapositiva (ancho cuando es hijo de [getRestoredTop](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--), altura cuando es hijo de [getRestoredLeft](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) de la vista normal, cuando la región tiene un tamaño restaurado variable (ni minimizado ni maximizado).  

El método [getDimensionSize](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) especifica el tamaño de la región de la diapositiva (ancho cuando es hijo de restoredTop, altura cuando es hijo de restoredLeft).  

El método [getAutoAdjust](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) especifica si el tamaño de la región de contenido lateral debe compensar el nuevo tamaño al redimensionar la ventana que contiene la vista dentro de la aplicación.  

A continuación se muestra un ejemplo que indica cómo acceder a las propiedades [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) de una presentación.

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

Aspose.Slides for Android via Java ahora admite la configuración del valor de zoom predeterminado para la presentación de modo que, cuando la presentación se abra, el zoom ya esté establecido. Esto se puede hacer configurando el [ViewProperties](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ViewProperties) de una presentación. [getSlideViewProperties](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) así como [getNotesViewProperties](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) pueden establecerse programáticamente. En este tema, veremos con un ejemplo cómo establecer las [Propiedades de vista](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ViewProperties) de [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation) en Aspose.Slides. 

{{% /alert %}} 

Para establecer las propiedades de vista, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation).  
1. Establezca las [Propiedades de vista](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ViewProperties) de [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation).  
1. Guarde la presentación como un archivo [PPTX](https://docs.fileformat.com/presentation/pptx/). En el ejemplo que se muestra a continuación, hemos establecido el valor de zoom para la vista de diapositiva y para la vista de notas.  

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Estableciendo las propiedades de vista de la presentación
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Valor de zoom en porcentaje para la vista de diapositiva
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Valor de zoom en porcentaje para la vista de notas 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Establecer el espaciado de la cuadrícula**

Utilice [Presentation.getViewProperties](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/#getViewProperties--) para acceder a la configuración de vista a nivel de presentación. Los métodos [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iviewproperties/#getGridSpacing--) y [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) leen o modifican el intervalo de la cuadrícula de edición subyacente. Esta configuración se aplica a toda la presentación, no a una diapositiva individual. El espaciado de la cuadrícula se especifica en puntos, donde 72 puntos equivalen a una pulgada. Utilice un valor positivo, tal como lo exige la documentación de la API.  

El siguiente ejemplo abre un archivo `demo.pptx` existente, muestra su espaciado de cuadrícula actual, establece un intervalo de un cuarto de pulgada y guarda el resultado.  

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("demo.pptx");
try {
    float gridSpacing = presentation.getViewProperties().getGridSpacing();
    System.out.println("Current grid spacing: " + gridSpacing + " points");

    presentation.getViewProperties().setGridSpacing(18f);
    presentation.save("grid-spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La cuadrícula es distinta de las [guías de dibujo](/slides/es/androidjava/drawing-guides/). El espaciado de la cuadrícula controla un intervalo regular, mientras que las guías de dibujo son líneas de alineación horizontales o verticales posicionadas individualmente. Añadir, mover o eliminar guías de dibujo no modifica el espaciado de la cuadrícula.  

Tanto la cuadrícula como las guías de dibujo son ayudas de edición. No se renderizan como contenido de diapositiva en PDF, imágenes, SVG o una presentación. Almacenar el espaciado de la cuadrícula no garantiza que un editor lo muestre: su visibilidad también depende de las preferencias del visor o editor.

## **Preguntas frecuentes**

**¿Por qué la cuadrícula no se muestra después de volver a abrir la presentación?**  

El archivo almacena el espaciado de la cuadrícula, pero el editor controla si la cuadrícula se muestra. Verifique la configuración de visibilidad de la cuadrícula en el editor.  

**¿Eliminar las guías de dibujo cambia el espaciado de la cuadrícula?**  

No. Las guías de dibujo y el espaciado de la cuadrícula son configuraciones independientes. Eliminar las guías deja el intervalo de la cuadrícula almacenado sin cambios.  

**¿Puedo establecer diferentes configuraciones de vista para distintas secciones de una presentación?**  

Las [configuraciones de vista](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/#getViewProperties--) se definen a nivel de presentación ([Vista normal](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Vista de diapositiva](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)), no por sección, por lo que un único conjunto de parámetros se aplica a todo el documento al abrirse.  

**¿Puedo predefinir distintos estados de vista para diferentes usuarios?**  

No. Los ajustes se almacenan en el archivo y se comparten. Las aplicaciones de visualización pueden respetar las preferencias del usuario, pero el archivo en sí contiene un único conjunto de propiedades de vista.  

**¿Puedo preparar una plantilla con Propiedades de vista predefinidas para que las nuevas presentaciones se abran de la misma manera?**  

Sí. Como las [propiedades de vista](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/#getViewProperties--) se almacenan a nivel de presentación, puede incorporarlas en una plantilla y crear nuevos documentos a partir de ella con la misma configuración inicial de vista.