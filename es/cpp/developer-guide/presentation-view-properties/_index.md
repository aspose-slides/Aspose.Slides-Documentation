---
title: Recuperar y actualizar las propiedades de vista de la presentación en C++
linktitle: Propiedades de vista
type: docs
weight: 80
url: /es/cpp/presentation-view-properties/
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
- C++
- Aspose.Slides
description: "Descubra las propiedades de vista de Aspose.Slides para C++ para personalizar formatos PPT, PPTX y ODP—ajuste diseños, niveles de zoom y configuraciones de visualización."
---

{{% alert color="primary" %}} 

La vista normal consta de tres regiones de contenido: la diapositiva propiamente dicha, una región de contenido lateral y una región de contenido inferior. Propiedades relativas a la posición de las diferentes regiones de contenido. Esta información permite a la aplicación guardar su estado de vista en el archivo, de modo que al reabrirlo la vista esté en el mismo estado que cuando la presentación se guardó por última vez.

Se ha añadido el método [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) para proporcionar acceso a las propiedades de vista normal de la presentación.  

Se han añadido las interfaces [INormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/), [INormalViewRestoredProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/) y sus descendientes, así como el enumerado [SplitterBarStateType](https://reference.aspose.com/slides/cpp/aspose.slides/splitterbarstatetype/).  

{{% /alert %}} 

## **About INormalViewProperties**

Representa las propiedades de vista normal.

La propiedad **ShowOutlineIcons** especifica si la aplicación debe mostrar iconos al presentar el contenido del esquema en cualquiera de las regiones de contenido del modo de vista normal.

La propiedad **SnapVerticalSplitter** especifica si la barra separadora vertical debe ajustarse a un estado minimizado cuando la región lateral es suficientemente pequeña.

La propiedad **PreferSingleView** especifica si el usuario prefiere ver una única región de contenido en ventana completa en lugar de la vista normal estándar con tres regiones de contenido. Si está habilitado, la aplicación puede optar por mostrar una de las regiones de contenido en toda la ventana.

Las propiedades **VerticalBarState** y **HorizontalBarState** especifican el estado en el que se debe mostrar la barra separadora horizontal o vertical. Una barra separadora horizontal separa la diapositiva de la región de contenido situada bajo la diapositiva; una barra separadora vertical separa la diapositiva de la región de contenido lateral. Los valores posibles son: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** y **SplitterBarStateType.Restored**.

Las propiedades **RestoredLeft** y **RestoredTop** especifican el dimensionado de la región superior o lateral de la diapositiva en la vista normal, cuando se aplica el valor **SplitterBarStateType.Restored** a **VerticalBarState** y **HorizontalBarState**, respectivamente.

## **About Restoring INormalViewProperties**

Especifica el dimensionado de la región de diapositiva (ancho cuando es hijo de RestoredTop, altura cuando es hijo de RestoredLeft) de la vista normal, cuando la región tiene un tamaño restaurado variable (ni minimizado ni maximizado).  

La propiedad **DimensionSize** especifica el tamaño de la región de diapositiva (ancho cuando es hijo de restoredTop, altura cuando es hijo de restoredLeft).  

La propiedad **AutoAdjust** especifica si el tamaño de la región de contenido lateral debe compensar el nuevo tamaño al redimensionar la ventana que contiene la vista dentro de la aplicación.  

A continuación se muestra un ejemplo de cómo puede acceder a las propiedades **ViewProperties.NormalViewProperties** de una presentación.  
``` cpp
auto pres = System::MakeObject<Presentation>(u"demo.pptx");
pres->get_ViewProperties()->get_NormalViewProperties()->set_HorizontalBarState(SplitterBarStateType::Restored);
pres->get_ViewProperties()->get_NormalViewProperties()->set_VerticalBarState(SplitterBarStateType::Maximized);

// Restaurar las propiedades de vista de la presentación
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```


## **Set the Default Zoom Value**

Aspose.Slides para C++ ahora admite establecer el valor de zoom predeterminado para la presentación de modo que, cuando se abre la presentación, el zoom ya esté configurado. Esto puede hacerse configurando [ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/) de una presentación. Las Propiedades de vista de diapositiva así como [get_NotesViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/get_notesviewproperties/) pueden establecerse programáticamente. En este tema, veremos con un ejemplo cómo establecer las Propiedades de vista de una presentación en Aspose.Slides.

Para establecer las propiedades de vista, siga los pasos a continuación:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).  
1. Establecer las [Propiedades de vista](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/) de la presentación.  
1. Guardar la presentación como archivo PPTX.  

En el ejemplo que se muestra a continuación, hemos establecido el valor de zoom tanto para la vista de diapositiva como para la vista de notas.  
``` cpp
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// Configuración de las propiedades de vista de la presentación
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // Valor de zoom en porcentaje para la vista de diapositiva
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // Valor de zoom en porcentaje para la vista de notas 

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```


## **FAQ**

**¿Puedo establecer diferentes configuraciones de vista para distintas secciones de una presentación?**

[La configuración de vista](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/) se define a nivel de presentación ([Vista normal](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Vista de diapositiva](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/get_slideviewproperties/)), no por sección, por lo que un único conjunto de parámetros se aplica a todo el documento cuando se abre.

**¿Puedo predefinir diferentes estados de vista para diferentes usuarios?**

No. Las configuraciones se almacenan en el archivo y se comparten. Las aplicaciones de visualización pueden respetar las preferencias del usuario, pero el archivo en sí contiene un único conjunto de propiedades de vista.

**¿Puedo preparar una plantilla con Propiedades de vista predefinidas para que las nuevas presentaciones se abran de la misma manera?**

Sí. Dado que [las propiedades de vista](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/) se almacenan a nivel de presentación, puede incrustarlas en una plantilla y crear nuevos documentos a partir de ella con la misma configuración de vista inicial.