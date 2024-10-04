---
title: Propiedades de la Vista de Presentación
type: docs
url: /cpp/presentation-view-properties/
---

{{% alert color="primary" %}} 

La vista normal consiste en tres regiones de contenido: la diapositiva misma, una región de contenido lateral y una región de contenido en la parte inferior. Propiedades relacionadas con el posicionamiento de las diferentes regiones de contenido. Esta información permite que la aplicación guarde su estado de vista en el archivo, de modo que, al volver a abrirlo, la vista esté en el mismo estado en que se guardó por última vez la presentación.

Se ha añadido el método [**IViewProperties::get_NormalViewProperties()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_view_properties#aa8add44edf3e3ac578e0bf8f32617b06) para proporcionar acceso a las propiedades de vista normal de la presentación. 

Se han añadido las interfaces [**INormalViewProperties**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_normal_view_properties), [**INormalViewRestoredProperties**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_normal_view_restored_properties) y sus descendientes, así como el enum [**SplitterBarStateType**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#ac12b36e68eb35cfd6ae026915e071950).

{{% /alert %}} 



## **Acerca de INormalViewProperties** #

Representa propiedades de vista normal.

La propiedad **ShowOutlineIcons** especifica si la aplicación debe mostrar íconos al mostrar contenido de esquema en cualquiera de las regiones de contenido del modo de vista normal.

La propiedad **SnapVerticalSplitter** especifica si el separador vertical debe ajustarse a un estado minimizado cuando la región lateral es lo suficientemente pequeña.

La propiedad **PreferSingleView** especifica si el usuario prefiere ver una región de contenido de ventana completa en lugar de la vista normal estándar con tres regiones de contenido. Si está habilitada, la aplicación puede elegir mostrar una de las regiones de contenido en toda la ventana.

Las propiedades **VerticalBarState** y **HorizontalBarState** especifican el estado en que se debe mostrar la barra separadora horizontal o vertical. Una barra separadora horizontal separa la diapositiva de la región de contenido debajo de la diapositiva; la barra separadora vertical separa la diapositiva de la región de contenido lateral. Los valores posibles son: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** y **SplitterBarStateType.Restored.**

Las propiedades **RestoredLeft** y **RestoredTop** especifican el tamaño de la región de diapositiva superior o lateral de la vista normal, cuando se aplica el valor **SplitterBarStateType.Restored** para **VerticalBarState** y **HorizontalBarState** respectivamente.



## **Acerca de INormalViewRestoredProperties** #

Especifica el tamaño de la región de diapositiva ((ancho cuando es un hijo de RestoredTop, altura cuando es un hijo de RestoredLeft) de la vista normal, cuando la región tiene un tamaño restaurado variable (ni minimizado ni maximizado).

La propiedad **DimensionSize** especifica el tamaño de la región de diapositiva (ancho cuando es un hijo de restoredTop, altura cuando es un hijo de restoredLeft).

La propiedad **AutoAdjust** especifica si el tamaño de la región de contenido lateral debe compensar el nuevo tamaño al cambiar el tamaño de la ventana que contiene la vista dentro de la aplicación.

A continuación, se muestra un ejemplo de cómo puede acceder a las propiedades **ViewProperties.NormalViewProperties** para una presentación.

``` cpp
//Instanciar un objeto de presentación que representa un archivo de presentación
auto pres = System::MakeObject<Presentation>(u"demo.pptx");
pres->get_ViewProperties()->get_NormalViewProperties()->set_HorizontalBarState(SplitterBarStateType::Restored);
pres->get_ViewProperties()->get_NormalViewProperties()->set_VerticalBarState(SplitterBarStateType::Maximized);

pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```


## **Establecer el Valor de Zoom Predeterminado**
Aspose.Slides para C++ ahora admite establecer el valor de zoom predeterminado para la presentación de modo que, cuando se abra la presentación, el zoom ya esté configurado. Esto se puede hacer configurando las [**ViewProperties**](https://reference.aspose.com/slides/cpp/class/aspose.slides.view_properties) de una presentación. Las propiedades de vista de diapositiva, así como [get_NotesViewProperties()](https://reference.aspose.com/slides/cpp/class/aspose.slides.view_properties#a86ad6559c9c0768d8210fdb86c86cf98) pueden configurarse programáticamente. En este tema, veremos con un ejemplo cómo establecer las propiedades de vista de la presentación en Aspose.Slides.

Para establecer las propiedades de vista. Siga los pasos a continuación:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Establecer las propiedades de vista [View Properties](https://reference.aspose.com/slides/cpp/class/aspose.slides.view_properties) de la presentación.
1. Escribir la presentación como un archivo PPTX.

En el ejemplo dado a continuación, hemos ajustado el valor de zoom para la vista de diapositivas, así como para la vista de notas.

``` cpp
// Instanciar un objeto de Presentación que representa un archivo de presentación
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
// Configurando las propiedades de vista de la presentación

presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100);
// Valor de zoom en porcentaje para la vista de diapositivas
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100);
// Valor de zoom en porcentaje para la vista de notas 

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```



## **Establecer Propiedades de Vista**
Para establecer las propiedades de vista. Siga los pasos a continuación:

1. Crear una instancia de la clase Presentation.
1. Establecer las propiedades de vista de la presentación.
1. Escribir la presentación como un archivo PPTX.

En el ejemplo dado a continuación, hemos ajustado el valor de zoom para la vista de diapositivas, así como para la vista de notas.

``` cpp
// Instanciar un objeto de Presentación que representa un archivo de presentación
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// Configurando las propiedades de vista de la presentación
// Valor de zoom en porcentaje para la vista de diapositivas
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100);
// Valor de zoom en porcentaje para la vista de notas
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100);

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```