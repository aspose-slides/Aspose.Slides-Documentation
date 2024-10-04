---
title: Guardar Presentación
type: docs
weight: 80
url: /es/androidjava/save-presentation/
---

## **Resumen**
{{% alert color="primary" %}} 

[Abriendo Presentación](/slides/es/androidjava/open-presentation/) describe cómo usar la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) para abrir una presentación. Este artículo explica cómo crear y guardar presentaciones.

{{% /alert %}} 

La clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) contiene el contenido de una presentación. Ya sea creando una presentación desde cero o modificando una existente, cuando termines, querrás guardar la presentación. Con Aspose.Slides para Android a través de Java, se puede guardar como un **archivo** o **stream**. Este artículo explica cómo guardar una presentación de diferentes maneras:

## **Guardar Presentación en Archivo**
Guarda una presentación en un archivo llamando al método [**Save**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation). Simplemente pasa el nombre del archivo y [**SaveFormat**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SaveFormat) al método [**Save**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-).

Los ejemplos que siguen muestran cómo guardar una presentación con Aspose.Slides para Android a través de Java.

```java
// Instanciar un objeto Presentation que representa un archivo PPT
Presentation pres = new Presentation();
try {
    // ...realiza algún trabajo aquí...
    
    // Guarda tu presentación en un archivo
    pres.save("demoPass.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    if(pres != null) pres.dispose();
}
```

## **Guardar Presentación en Stream**
Es posible guardar una presentación en un stream pasando un stream de salida al método [**Save**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.io.OutputStream-int-) de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation). Hay muchos tipos de streams a los que se puede guardar una presentación. En el siguiente ejemplo hemos creado un nuevo archivo de Presentación, agregamos texto en una forma y guardamos la presentación en el stream.

```java
// Instanciar un objeto Presentation que representa un archivo PPT
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 200, 200);

    // Agregar texto a la forma
    shape.getTextFrame().setText("Esta demostración muestra cómo crear un archivo PowerPoint y guardarlo en un Stream.");

    OutputStream os = new FileOutputStream("Save_As_Stream_out.pptx");

    pres.save(os, com.aspose.slides.SaveFormat.Pptx);

    os.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Guardar Presentación con Tipo de Vista Predefinido**
Aspose.Slides para Android a través de Java proporciona una función para establecer el tipo de vista para la presentación generada cuando se abre en PowerPoint a través de la clase [ViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties). La propiedad [**setLastView**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties#setLastView-int-) se utiliza para establecer el tipo de vista utilizando el enumerador [**ViewType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewType).

```java
// Abriendo el archivo de presentación
Presentation pres = new Presentation();
try {
    // Estableciendo el tipo de vista
    pres.getViewProperties().setLastView((byte) ViewType.SlideMasterView);
    
    // Guardando la presentación
    pres.save("newDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Guardar Presentaciones en Formato Estricto Office Open XML**
Aspose.Slides permite guardar la presentación en formato Estricto Office Open XML. Para ese propósito, proporciona la clase [**PptxOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxoptions) donde puedes establecer la propiedad de Conformidad al guardar el archivo de presentación. Si estableces su valor como [**Conformance.Iso29500_2008_Strict**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Conformance#Iso29500_2008_Strict), entonces el archivo de presentación de salida será guardado en formato Estricto Open XML.

El siguiente código de ejemplo crea una presentación y la guarda en el formato Estricto Office Open XML. Al llamar al método [**Save**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) para la presentación, el objeto [**PptxOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxoptions) es pasado con la propiedad de Conformidad establecida como [**Conformance.Iso29500_2008_Strict**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Conformance#Iso29500_2008_Strict).

```java
// Instanciar un objeto Presentation que representa un archivo PPT
Presentation pres = new Presentation();
try {
    // Obtener la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Agregar una forma automática de tipo línea
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // Establecer opciones de guardado en formato Estricto Office Open XML
    PptxOptions options = new PptxOptions();
    options.setConformance(Conformance.Iso29500_2008_Strict);
    
    // Guarda tu presentación en un archivo
    pres.save("demoPass.pptx", SaveFormat.Pptx, options);
} finally {
    if (pres != null) pres.dispose();
}

```

## **Guardar Presentaciones en formato Office Open XML en modo Zip64**

Un archivo Office Open XML es un archivo ZIP que tiene un límite de 4 GB (2^32 bytes) en el tamaño descomprimido de un archivo, tamaño comprimido de un archivo y tamaño total del archivo, así como un límite de 65,535 (2^16-1) archivos en el archivo. Las extensiones de formato ZIP64 aumentan los límites a 2^64.

La nueva propiedad [**IPptxOptions.Zip64Mode**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zip64mode/) te permite elegir cuándo usar las extensiones de formato ZIP64 para el archivo Office Open XML guardado.

Esta propiedad proporciona los siguientes modos:

- [Zip64Mode.IfNecessary](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zip64mode/#IfNecessary) significa que las extensiones de formato ZIP64 solo se usarán si la presentación supera las limitaciones anteriores. Este es el modo predeterminado.
- [Zip64Mode.Never](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zip64mode/#Never) significa que las extensiones de formato ZIP64 no se usarán.
- [Zip64Mode.Always](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zip64mode/#Always) significa que las extensiones de formato ZIP64 siempre se usarán.

El siguiente código demuestra cómo guardar la presentación en formato PPTX con extensiones de formato ZIP64:

```java
Presentation pres = new Presentation("Sample.pptx");
try {
    PptxOptions pptxOptions = new PptxOptions();
    pptxOptions.setZip64Mode(Zip64Mode.Always);
    
    pres.save("Sample-zip64.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="NOTA" color="warning" %}}

Guardar en el modo Zip64Mode.Never lanzará una [PptxException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxexception/) si la presentación no se puede guardar en formato ZIP32.

{{% /alert %}}

## **Guardar Actualizaciones de Progreso en Porcentaje**
Se ha agregado la nueva interfaz [**IProgressCallback**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProgressCallback) a la interfaz [**ISaveOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISaveOptions) y a la clase abstracta [**SaveOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SaveOptions). La interfaz [**IProgressCallback**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProgressCallback) representa un objeto de callback para guardar actualizaciones de progreso en porcentaje.  

Los siguientes fragmentos de código muestran cómo usar la interfaz [IProgressCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProgressCallback):

```java
// Abrindo el archivo de presentación
Presentation pres = new Presentation("ConvertToPDF.pptx");
try {
    ISaveOptions saveOptions = new PdfOptions();
    saveOptions.setProgressCallback((IProgressCallback) new ExportProgressHandler());
    pres.save("ConvertToPDF.pdf", SaveFormat.Pdf, saveOptions);
} finally {
    pres.dispose();
}
```
```java
class ExportProgressHandler implements IProgressCallback 
{
    public void reporting(double progressValue) 
	{
        // Usa el valor del porcentaje de progreso aquí
        int progress = Double.valueOf(progressValue).intValue();
        System.out.println(progress + "% archivo convertido");
    }
}
```

{{% alert title="Información" color="info" %}}

Usando su propia API, Aspose desarrolló una [aplicación gratuita para dividir PowerPoint](https://products.aspose.app/slides/splitter) que permite a los usuarios dividir sus presentaciones en múltiples archivos. Esencialmente, la aplicación guarda las diapositivas seleccionadas de una presentación dada como nuevos archivos PowerPoint (PPTX o PPT). 

{{% /alert %}}