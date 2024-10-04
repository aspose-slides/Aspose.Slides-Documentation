---
title: Guardar Presentación en .NET
linktitle: Guardar Presentación
type: docs
weight: 80
url: /net/save-presentation/
keywords: "Guardar PowerPoint, PPT, PPTX, Guardar Presentación, archivo, flujo, C#, Csharp, .NET"
description: "Guardar Presentación de PowerPoint como archivo o flujo en C# o .NET"
---

## **Guardar Presentación**
Abrir una Presentación describió cómo usar la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) para abrir una presentación. Este artículo explica cómo crear y guardar presentaciones.  
La clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) contiene el contenido de una presentación. Ya sea que estés creando una presentación desde cero o modificando una existente, al finalizar, querrás guardar la presentación. Con Aspose.Slides para .NET, se puede guardar como un **archivo** o **flujo**. Este artículo explica cómo guardar una presentación de diferentes maneras:

### **Guardando Presentaciones en Archivos**
Guarda una presentación en archivos llamando al método [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation). Simplemente pasa el nombre del archivo y el formato de guardado al método [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index). Los ejemplos que siguen muestran cómo guardar una presentación con Aspose.Slides para .NET usando C#.

```c#
// Instanciar un objeto Presentation que representa un archivo PPT
Presentation presentation= new Presentation();

//...realiza algún trabajo aquí...

// Guarda tu presentación en un archivo
presentation.Save("Saved_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

### **Guardando Presentaciones en Flujos**
Es posible guardar una presentación en un flujo pasando un flujo de salida al método Save de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation). Hay muchos tipos de flujos a los que se puede guardar una presentación. En el ejemplo a continuación hemos creado un nuevo archivo de Presentación, agregamos texto en una forma y guardamos la presentación en el flujo.

```c#
// Instanciar un objeto Presentation que representa un archivo PPT
using (Presentation presentation = new Presentation())
{

    IAutoShape shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 200, 200);

    // Agregar texto a la forma
    shape.TextFrame.Text = "Esta demostración muestra cómo crear un archivo de PowerPoint y guardarlo en un flujo.";

    FileStream toStream = new FileStream("Save_As_Stream_out.pptx", FileMode.Create);
    presentation.Save(toStream, Aspose.Slides.Export.SaveFormat.Pptx);
    toStream.Close();
}
```

### **Guardando Presentaciones con Tipo de Vista Predefinido**
Aspose.Slides para .NET proporciona una facilidad para establecer el tipo de vista para la presentación generada cuando se abre en PowerPoint a través de la clase [ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties). La propiedad [LastView](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/properties/lastview) se utiliza para establecer el tipo de vista utilizando el enumerador [ViewType](https://reference.aspose.com/slides/net/aspose.slides/viewtype).

```csharp
using (Presentation pres = new Presentation())
{
    pres.ViewProperties.LastView = ViewType.SlideMasterView;
    pres.Save("pres-will-open-SlideMasterView.pptx", SaveFormat.Pptx);
}
```

### **Guardando Presentaciones en Formato Estricto de Office Open XML**
Aspose.Slides te permite guardar la presentación en formato Estricto de Office Open XML. Para ello, proporciona la clase **[Aspose.Slides.Export.PptxOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pptxoptions)** donde puedes establecer la propiedad Conformance al guardar el archivo de presentación. Si estableces su valor como Conformance.Iso29500_2008_Strict, entonces el archivo de presentación de salida se guardará en formato Estricto de Office Open XML.

El siguiente código de muestra crea una presentación y la guarda en el formato Estricto de Office Open XML. Al llamar al método Save para la presentación, se pasa el objeto **[Aspose.Slides.Export.PptxOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pptxoptions)** junto con la propiedad **[Conformance](https://reference.aspose.com/slides/net/aspose.slides.export/pptxoptions/properties/conformance)** establecida como **[Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/net/aspose.slides.export/conformance)**.

```csharp
   // Instanciar un objeto Presentation que representa un archivo de presentación
   using (Presentation presentation = new Presentation())
   {
       // Obtener la primera diapositiva
       ISlide slide = presentation.Slides[0];

       // Agregar una forma automática de tipo línea
       slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

       // Guardar la presentación en formato Estricto de Office Open XML
       presentation.Save(dataDir + "NewPresentation_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx,
           new PptxOptions() { Conformance = Conformance.Iso29500_2008_Strict });

   }
```

### **Guardando Presentaciones en formato Office Open XML en modo Zip64**
Un archivo de Office Open XML es un archivo ZIP que tiene un límite de 4 GB (2^32 bytes) en el tamaño no comprimido de un archivo, el tamaño comprimido de un archivo y el tamaño total del archivo, así como un límite de 65,535 (2^16-1) archivos en el archivo. Las extensiones de formato ZIP64 incrementan los límites a 2^64.

La nueva propiedad **[IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/net/aspose.slides.export/ipptxoptions/zip64mode/)** te permite elegir cuándo usar extensiones de formato ZIP64 para el archivo de Office Open XML guardado.

Esta propiedad proporciona los siguientes modos:

- [Zip64Mode.IfNecessary](https://reference.aspose.com/slides/net/aspose.slides.export/zip64mode/) significa que las extensiones de formato ZIP64 solo se usarán si la presentación excede las limitaciones anteriores. Este es el modo por defecto.  
- [Zip64Mode.Never](https://reference.aspose.com/slides/net/aspose.slides.export/zip64mode/) significa que no se usarán extensiones de formato ZIP64.
- [Zip64Mode.Always](https://reference.aspose.com/slides/net/aspose.slides.export/zip64mode/) significa que siempre se usarán extensiones de formato ZIP64.

El siguiente código C# demuestra cómo guardar la presentación en formato PPTX con extensiones de formato ZIP64:

```c#
using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-zip64.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        Zip64Mode = Zip64Mode.Always
    });
}
```

{{% alert title="NOTA" color="warning" %}}

Guardar en modo Zip64Mode.Never lanzará una [PptxException](https://reference.aspose.com/slides/net/aspose.slides/pptxexception/) si la presentación no se puede guardar en formato ZIP32.

{{% /alert %}}

### **Guardando Actualizaciones de Progreso en Porcentaje**
Se ha añadido una nueva interfaz **[IProgressCallback](https://reference.aspose.com/slides/net/aspose.slides/iprogresscallback)** a la interfaz **[ISaveOptions](https://reference.aspose.com/slides/net/aspose.slides.export/isaveoptions)** y a la clase abstracta **[SaveOptions](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions)**. La interfaz **IProgressCallback** representa un objeto de callback para guardar actualizaciones de progreso en porcentaje.

Los siguientes fragmentos de código muestran cómo usar la interfaz IProgressCallback:

```c#
using (Presentation presentation = new Presentation("ConvertToPDF.pptx"))
{
    ISaveOptions saveOptions = new PdfOptions();
    saveOptions.ProgressCallback = new ExportProgressHandler();
    presentation.Save("ConvertToPDF.pdf", SaveFormat.Pdf, saveOptions);
}
```

```c#
class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        // Usa el valor del porcentaje de progreso aquí
        int progress = Convert.ToInt32(progressValue);
        Console.WriteLine(progress + "% archivo convertido");
    }
}
```

{{% alert title="Info" color="info" %}}

Usando su propia API, Aspose desarrolló una [aplicación gratuita para dividir PowerPoint](https://products.aspose.app/slides/splitter) que permite a los usuarios dividir sus presentaciones en múltiples archivos. Esencialmente, la aplicación guarda las diapositivas seleccionadas de una presentación dada como nuevos archivos de PowerPoint (PPTX o PPT).

{{% /alert %}}

<h2>Abrir y Guardar Presentación</h2>

<a name="csharp-open-save-presentation"><strong>Pasos: Abrir y Guardar Presentación en C#</strong></a>

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) con cualquier formato, es decir, PPT, PPTX, ODP, etc.  
2. Guarda _Presentación_ en cualquier formato soportado por [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/)

```c#
// Cargar cualquier archivo soportado en Presentation, por ejemplo ppt, pptx, odp, etc.
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```