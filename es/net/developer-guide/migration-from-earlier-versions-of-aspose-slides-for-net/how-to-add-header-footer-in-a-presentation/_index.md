---
title: Cómo agregar encabezados y pies de página a presentaciones en .NET
linktitle: Agregar encabezado y pie de página
type: docs
weight: 20
url: /es/net/how-to-add-header-footer-in-a-presentation/
keywords:
- migración
- agregar encabezado
- agregar pie de página
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
description: "Aprenda cómo agregar encabezados y pies de página en presentaciones PowerPoint PPT, PPTX y ODP en .NET usando tanto las API heredadas como las modernas de Aspose.Slides."
---

{{% alert color="primary" %}} 
Se ha lanzado una nueva [Aspose.Slides for .NET API](/slides/es/net/) y ahora este único producto admite la capacidad de generar documentos PowerPoint desde cero y editar los existentes.
{{% /alert %}} 
## **Compatibilidad con código heredado**
Para utilizar el código heredado desarrollado con Aspose.Slides for .NET versiones anteriores a la 13.x, necesita realizar algunos cambios menores en su código y el código funcionará como antes. Todas las clases que estaban presentes en la versión anterior de Aspose.Slides for .NET bajo los espacios de nombres Aspose.Slide y Aspose.Slides.Pptx ahora se han fusionado en un único espacio de nombres Aspose.Slides. Por favor, revise el siguiente fragmento de código simple para agregar encabezado y pie de página en una presentación con la API heredada de Aspose.Slides y siga los pasos que describen cómo migrar a la nueva API fusionada.
## **Enfoque heredado de Aspose.Slides for .NET**
```c#
PresentationEx sourcePres = new PresentationEx();

//Setting Header Footer visibility properties
sourcePres.UpdateSlideNumberFields = true;

//Update the Date Time Fields
sourcePres.UpdateDateTimeFields = true;

//Show date time placeholder
sourcePres.HeaderFooterManager.IsDateTimeVisible = true;

//Show the footer place holder
sourcePres.HeaderFooterManager.IsFooterVisible = true;

//Show Slide Number
sourcePres.HeaderFooterManager.IsSlideNumberVisible = true;

//Set the  header footer visibility on Title Slide
sourcePres.HeaderFooterManager.SetVisibilityOnTitleSlide(true);

//Write the presentation to the disk
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
hf.HeaderText = "Header Text";

//Establecer el texto del pie de página
hf.FooterText = "Footer Text";

//Escribir la presentación en el disco
pres.Write("HeadFoot.ppt");
```




## **Nuevo enfoque de Aspose.Slides for .NET 13.x**
``` csharp
using (Presentation sourcePres = new Presentation())
{
    //Establecer propiedades de visibilidad del encabezado y pie de página
    sourcePres.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    //Actualizar los campos de fecha y hora
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Mostrar el marcador de posición de fecha y hora
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Mostrar el marcador de posición del pie de página
    sourcePres.HeaderFooterManager.SetAllFootersVisibility(true);
    
    //Establecer la visibilidad del encabezado y pie de página en la diapositiva de título
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //Guardar la presentación en el disco
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```
