---
title: Cómo agregar encabezado y pie de página en una presentación
type: docs
weight: 20
url: /net/how-to-add-header-footer-in-a-presentation/
---

{{% alert color="primary" %}} 

Se ha lanzado una nueva [Aspose.Slides for .NET API](/slides/net/) y ahora este único producto admite la capacidad de generar documentos de PowerPoint desde cero y editar los existentes.

{{% /alert %}} 
## **Soporte para código legado**
Para usar el código legado desarrollado con Aspose.Slides for .NET versiones anteriores a 13.x, necesitas hacer algunos cambios menores en tu código y funcionará como antes. Todas las clases que estaban presentes en la antigua Aspose.Slides for .NET bajo los espacios de nombres Aspose.Slide y Aspose.Slides.Pptx ahora están fusionadas en un solo espacio de nombres Aspose.Slides. Por favor, echa un vistazo al siguiente fragmento de código simple para agregar encabezado y pie de página en la presentación en la API antigua de Aspose.Slides y sigue los pasos que describen cómo migrar a la nueva API fusionada.
## **Enfoque antiguo de Aspose.Slides for .NET**
```c#
PresentationEx sourcePres = new PresentationEx();

//Configurando las propiedades de visibilidad del encabezado y pie de página
sourcePres.UpdateSlideNumberFields = true;

//Actualizar los campos de fecha y hora
sourcePres.UpdateDateTimeFields = true;

//Mostrar el marcador de posición de fecha y hora
sourcePres.HeaderFooterManager.IsDateTimeVisible = true;

//Mostrar el marcador de posición del pie de página
sourcePres.HeaderFooterManager.IsFooterVisible = true;

//Mostrar el número de la diapositiva
sourcePres.HeaderFooterManager.IsSlideNumberVisible = true;

//Establecer la visibilidad del encabezado y pie de página en la diapositiva de título
sourcePres.HeaderFooterManager.SetVisibilityOnTitleSlide(true);

//Escribir la presentación en el disco
sourcePres.Write("NewSource.pptx");
```

```c#
//Crear la presentación
Presentation pres = new Presentation();

//Obtener la primera diapositiva
Slide sld = pres.GetSlideByPosition(1);

//Acceder al encabezado / pie de página de la diapositiva
HeaderFooter hf = sld.HeaderFooter;

//Establecer la visibilidad del número de página
hf.PageNumberVisible = true;

//Establecer la visibilidad del pie de página
hf.FooterVisible = true;

//Establecer la visibilidad del encabezado
hf.HeaderVisible = true;

//Establecer la visibilidad de la fecha y hora
hf.DateTimeVisible = true;

//Establecer el formato de fecha y hora
hf.DateTimeFormat = DateTimeFormat.DateTime_dMMMMyyyy;

//Establecer el texto del encabezado
hf.HeaderText = "Texto del Encabezado";

//Establecer el texto del pie de página
hf.FooterText = "Texto del Pie de Página";

//Escribir la presentación en el disco
pres.Write("HeadFoot.ppt");
```



## **Nuevo enfoque de Aspose.Slides for .NET 13.x**
``` csharp
using (Presentation sourcePres = new Presentation())
{
    //Configurando las propiedades de visibilidad del encabezado y pie de página
    sourcePres.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    //Actualizar los campos de fecha y hora
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Mostrar el marcador de posición de fecha y hora
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Mostrar el marcador de posición del pie de página
    sourcePres.HeaderFooterManager.SetAllFootersVisibility(true);
    
    //Establecer la visibilidad del encabezado y pie de página en todas las diapositivas de título
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //Escribir la presentación en el disco
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```