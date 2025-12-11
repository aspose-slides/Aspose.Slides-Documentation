---
title: Recuperar y actualizar propiedades de vista de la presentación en C++
linktitle: Propiedades de vista
type: docs
weight: 80
url: /es/cpp/presentation-view-properties/
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
- C++
- Aspose.Slides
description: "Descubra las propiedades de vista de Aspose.Slides para C++ para personalizar formatos PPT, PPTX y ODP de diapositivas—ajuste diseños, niveles de zoom y configuraciones de visualización."
---

{{% alert color="primary" %}} 

La vista normal consta de tres regiones de contenido: la diapositiva en sí, una región de contenido lateral y una región de contenido inferior. Propiedades relacionadas con la posición de las distintas regiones de contenido. Esta información permite que la aplicación guarde su estado de vista en el archivo, de modo que al volver a abrirlo la vista se encuentre en el mismo estado que cuando la presentación se guardó por última vez.

Se ha añadido el método [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_view_properties#aa8add44edf3e3ac578e0bf8f32617b06) para proporcionar acceso a las propiedades de vista normal de la presentación.  

[INormalViewProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_normal_view_properties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_normal_view_restored_properties) interfaces y sus descendientes, el enum [SplitterBarStateType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#ac12b36e68eb35cfd6ae026915e071950) han sido añadidos.

{{% /alert %}} 

## **Acerca de INormalViewProperties**

Representa las propiedades de vista normal.

Property **ShowOutlineIcons** especifica si la aplicación debe mostrar iconos al mostrar contenido de esquema en cualquiera de las regiones de contenido del modo de vista normal.

Property **SnapVerticalSplitter** especifica si el divisor vertical debe ajustarse a un estado minimizado cuando la región lateral es suficientemente pequeña.

Property **PreferSingleView** especifica si el usuario prefiere ver una única región de contenido a pantalla completa en lugar de la vista normal estándar con tres regiones de contenido. Si está habilitado, la aplicación puede optar por mostrar una de las regiones de contenido en toda la ventana.

Las propiedades **VerticalBarState** y **HorizontalBarState** especifican el estado en el que debe mostrarse la barra del divisor horizontal o vertical. Una barra del divisor horizontal separa la diapositiva de la región de contenido situada debajo de la diapositiva, mientras que una barra del divisor vertical separa la diapositiva de la región de contenido lateral. Los valores posibles son: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** y **SplitterBarStateType.Restored**.

Las propiedades **RestoredLeft** y **RestoredTop** especifican el tamaño de la región superior o lateral de la diapositiva en la vista normal, cuando se aplica el valor **SplitterBarStateType.Restored** a **VerticalBarState** y **HorizontalBarState** respectivamente.

## **Acerca de restaurar INormalViewProperties**

Especifica el tamaño de la región de la diapositiva (ancho cuando es hijo de RestoredTop, altura cuando es hijo de RestoredLeft) de la vista normal, cuando la región tiene un tamaño restaurado variable (ni minimizado ni maximizado).

La propiedad **DimensionSize** especifica el tamaño de la región de la diapositiva (ancho cuando es hijo de restoredTop, altura cuando es hijo de restoredLeft).

La propiedad **AutoAdjust** especifica si el tamaño de la región de contenido lateral debe compensar el nuevo tamaño al cambiar el tamaño de la ventana que contiene la vista dentro de la aplicación.

A continuación se muestra un ejemplo que indica cómo puede acceder a las propiedades **ViewProperties.NormalViewProperties** de una presentación.
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


## **Establecer el valor de zoom predeterminado**

Aspose.Slides for C++ ahora admite establecer el valor de zoom predeterminado para una presentación de modo que, cuando la presentación se abre, el zoom ya está configurado. Esto se puede hacer estableciendo las [ViewProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.view_properties) de una presentación. Las propiedades de vista de diapositiva, así como [get_NotesViewProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.view_properties#a86ad6559c9c0768d8210fdb86c86cf98), pueden configurarse mediante código. En este tema, veremos con un ejemplo cómo establecer las propiedades de vista de una presentación en Aspose.Slides.

Para establecer las propiedades de vista, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)
1. Establezca las [Properties](https://reference.aspose.com/slides/cpp/class/aspose.slides.view_properties) de vista de la presentación
1. Guarde la presentación como un archivo PPTX

En el ejemplo que se muestra a continuación, hemos establecido el valor de zoom tanto para la vista de diapositiva como para la vista de notas.
``` cpp
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// Estableciendo las propiedades de vista de la presentación
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // Valor de zoom en porcentajes para la vista de diapositiva
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // Valor de zoom en porcentajes para la vista de notas 

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```


## **Preguntas frecuentes**

**¿Puedo establecer diferentes configuraciones de vista para distintas secciones de una presentación?**

Las [configuraciones de vista](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/) se definen a nivel de presentación ([Normal View](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/get_slideviewproperties/)), no por sección, por lo que un único conjunto de parámetros se aplica a todo el documento al abrirse.

**¿Puedo predefinir diferentes estados de vista para distintos usuarios?**

No. Las configuraciones se almacenan en el archivo y se comparten. Las aplicaciones de visualización pueden respetar las preferencias del usuario, pero el archivo en sí contiene un único conjunto de propiedades de vista.

**¿Puedo crear una plantilla con propiedades de vista predefinidas para que las nuevas presentaciones se abran de la misma forma?**

Sí. Como las [propiedades de vista](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/) se almacenan a nivel de presentación, puede incrustarlas en una plantilla y crear nuevos documentos a partir de ella con la misma configuración de vista inicial.