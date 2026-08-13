---
title: Cómo añadir encabezados y pies de página a presentaciones en .NET
linktitle: Añadir encabezado y pie de página
type: docs
weight: 20
url: /es/net/how-to-add-header-footer-in-a-presentation/
keywords:
- migración
- añadir encabezado
- añadir pie de página
- código heredado
- código moderno
- enfoque heredado
- enfoque moderno
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Aprenda cómo añadir encabezados y pies de página en presentaciones PowerPoint PPT, PPTX y ODP en .NET utilizando tanto las API heredadas como las modernas de Aspose.Slides."
---
{{% alert color="info" %}} 

Se ha publicado una nueva [Aspose.Slides for .NET API](/slides/es/net/) y ahora este único producto permite generar documentos PowerPoint desde cero y editar los existentes.

{{% /alert %}} 
## **Compatibilidad con código heredado**
Para utilizar el código heredado desarrollado con versiones de Aspose.Slides para .NET anteriores a la 13.x, es necesario realizar algunos cambios menores en su código y éste seguirá funcionando como antes. Todas las clases que estaban presentes en la antigua Aspose.Slides para .NET bajo los espacios de nombres Aspose.Slide y Aspose.Slides.Pptx ahora están fusionadas en un único espacio de nombres Aspose.Slides. Por favor, revise el siguiente fragmento de código sencillo para añadir encabezado y pie de página en una presentación con la API heredada de Aspose.Slides y siga los pasos que describen cómo migrar a la nueva API fusionada.
## **Enfoque legado de Aspose.Slides para .NET**
```c#
PresentationEx sourcePres = new PresentationEx();

//Estableciendo las propiedades de visibilidad del encabezado y pie de página
sourcePres.UpdateSlideNumberFields = true;

//Actualizar los campos de fecha y hora
sourcePres.UpdateDateTimeFields = true;

//Mostrar el marcador de posición de fecha y hora
sourcePres.HeaderFooterManager.IsDateTimeVisible = true;

//Mostrar el marcador de posición del pie de página
sourcePres.HeaderFooterManager.IsFooterVisible = true;

//Mostrar el número de diapositiva
sourcePres.HeaderFooterManager.IsSlideNumberVisible = true;

//Establecer la visibilidad del encabezado y pie de página en la diapositiva de título
sourcePres.HeaderFooterManager.SetVisibilityOnTitleSlide(true);

//Escribir la presentación en el disco
sourcePres.Write("NewSource.pptx");
```

```c#
using Aspose.Slides;

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
hf.HeaderText = "Header Text";

//Establecer el texto del pie de página
hf.FooterText = "Footer Text";

//Escribir la presentación en el disco
pres.Write("HeadFoot.ppt");
```



## **Nuevo enfoque de Aspose.Slides para .NET 13.x**
``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation sourcePres = new Presentation())
{
    //Estableciendo las propiedades de visibilidad del encabezado y pie de página
    sourcePres.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    //Actualizar los campos de fecha y hora
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Mostrar el marcador de posición de fecha y hora
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Mostrar el marcador de posición del pie de página
    sourcePres.HeaderFooterManager.SetAllFootersVisibility(true);
    
    //Establecer la visibilidad del encabezado y pie de página en la diapositiva de título
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //Escribir la presentación en el disco
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```