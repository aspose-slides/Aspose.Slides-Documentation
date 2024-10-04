---
title: Guardar Presentación
type: docs
weight: 80
url: /es/java/save-presentation/
---

## **Descripción General**
{{% alert color="primary" %}} 

[Abriendo Presentación](/slides/es/java/open-presentation/) describió cómo utilizar la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) para abrir una presentación. Este artículo explica cómo crear y guardar presentaciones.

{{% /alert %}} 

La clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) contiene el contenido de una presentación. Ya sea que estés creando una presentación desde cero o modificando una existente, al finalizar, querrás guardar la presentación. Con Aspose.Slides para Java, se puede guardar como un **archivo** o **flujo**. Este artículo explica cómo guardar una presentación de diferentes maneras:

## **Guardar Presentación en Archivo**
Guarda una presentación en un archivo llamando al método [**Save**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-) de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation). Simplemente pasa el nombre del archivo y [**SaveFormat**](https://reference.aspose.com/slides/java/com.aspose.slides/SaveFormat) al método [**Save**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-).

Los ejemplos que siguen muestran cómo guardar una presentación con Aspose.Slides para Java.

```java
// Instanciar un objeto Presentation que representa un archivo PPT
Presentation pres = new Presentation();
try {
    // ...hacer algo aquí...
    
    // Guardar tu presentación en un archivo
    pres.save("demoPass.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    if(pres != null) pres.dispose();
}
```

## **Guardar Presentación en Flujo**
Es posible guardar una presentación en un flujo pasando un flujo de salida al método [**Save**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.io.OutputStream-int-) de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation). Hay muchos tipos de flujos a los que se puede guardar una presentación. En el siguiente ejemplo hemos creado un nuevo archivo de Presentación, añadido texto en una forma y guardado la presentación en el flujo.

```java
// Instanciar un objeto Presentation que representa un archivo PPT
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 200, 200);

    // Añadir texto a la forma
    shape.getTextFrame().setText("Esta demo muestra cómo crear un archivo PowerPoint y guardarlo en un flujo.");

    OutputStream os = new FileOutputStream("Save_As_Stream_out.pptx");

    pres.save(os, com.aspose.slides.SaveFormat.Pptx);

    os.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Guardar Presentación con Tipo de Vista Predefinido**
Aspose.Slides para Java proporciona una facilidad para establecer el tipo de vista para la presentación generada cuando se abre en PowerPoint a través de la clase [ViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties). La propiedad [**setLastView**](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties#setLastView-int-) se utiliza para establecer el tipo de vista mediante el enumerador [**ViewType**](https://reference.aspose.com/slides/java/com.aspose.slides/ViewType).

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

## **Guardar Presentaciones en Formato Strict Office Open XML**
Aspose.Slides te permite guardar la presentación en formato Strict Office Open XML. Para ello, proporciona la clase [**PptxOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/pptxoptions) donde puedes establecer la propiedad de Conformance al guardar el archivo de presentación. Si estableces su valor como [**Conformance.Iso29500_2008_Strict**](https://reference.aspose.com/slides/java/com.aspose.slides/Conformance#Iso29500_2008_Strict), entonces el archivo de presentación de salida se guardará en formato Strict Open XML.

El siguiente código de ejemplo crea una presentación y la guarda en el formato Strict Office Open XML. Al llamar al método [**Save**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) para la presentación, el objeto [**PptxOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/pptxoptions) se pasa a él con la propiedad de Conformance establecida como [**Conformance.Iso29500_2008_Strict**](https://reference.aspose.com/slides/java/com.aspose.slides/Conformance#Iso29500_2008_Strict).

```java
// Instanciar un objeto Presentation que representa un archivo PPT
Presentation pres = new Presentation();
try {
    // Obtener la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Añadir una forma automática de tipo línea
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // Establecer opciones de guardado en formato Strict Office Open XML
    PptxOptions options = new PptxOptions();
    options.setConformance(Conformance.Iso29500_2008_Strict);
    
    // Guardar tu presentación en un archivo
    pres.save("demoPass.pptx", SaveFormat.Pptx, options);
} finally {
    if (pres != null) pres.dispose();
}

```

## **Guardar Presentaciones en formato Office Open XML en modo Zip64**
Un archivo Office Open XML es un archivo ZIP que tiene un límite de 4 GB (2^32 bytes) en el tamaño no comprimido de un archivo, el tamaño comprimido de un archivo y el tamaño total del archivo, así como un límite de 65,535 (2^16-1) archivos en el archivo. Las extensiones del formato ZIP64 aumentan los límites a 2^64.

La nueva propiedad [**IPptxOptions.Zip64Mode**](https://reference.aspose.com/slides/java/com.aspose.slides/zip64mode/) te permite elegir cuándo utilizar extensiones de formato ZIP64 para el archivo Office Open XML guardado.

Esta propiedad proporciona los siguientes modos:

- [Zip64Mode.IfNecessary](https://reference.aspose.com/slides/java/com.aspose.slides/zip64mode/#IfNecessary) significa que las extensiones del formato ZIP64 solo se utilizarán si la presentación se sale de las limitaciones anteriores. Este es el modo predeterminado.
- [Zip64Mode.Never](https://reference.aspose.com/slides/java/com.aspose.slides/zip64mode/#Never) significa que no se utilizarán las extensiones del formato ZIP64. 
- [Zip64Mode.Always](https://reference.aspose.com/slides/java/com.aspose.slides/zip64mode/#Always) significa que siempre se utilizarán las extensiones del formato ZIP64.

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

Guardar en el modo Zip64Mode.Never generará una [PptxException](https://reference.aspose.com/slides/java/com.aspose.slides/pptxexception/) si la presentación no puede guardarse en formato ZIP32.

{{% /alert %}}

## **Guardar Actualizaciones de Progreso en Porcentaje**
Se ha añadido una nueva interfaz [**IProgressCallback**](https://reference.aspose.com/slides/java/com.aspose.slides/IProgressCallback) a la interfaz [**ISaveOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/ISaveOptions) y a la clase abstracta [**SaveOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/SaveOptions). La interfaz [**IProgressCallback**](https://reference.aspose.com/slides/java/com.aspose.slides/IProgressCallback) representa un objeto de callback para guardar actualizaciones de progreso en porcentaje.  

Los siguientes fragmentos de código muestran cómo utilizar la interfaz [IProgressCallback](https://reference.aspose.com/slides/java/com.aspose.slides/IProgressCallback):

```java
// Abriendo el archivo de presentación
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
        // Utilizar el valor del porcentaje de progreso aquí
        int progress = Double.valueOf(progressValue).intValue();
        System.out.println(progress + "% archivo convertido");
    }
}
```

{{% alert title="Info" color="info" %}}

Utilizando su propia API, Aspose desarrolló una [aplicación gratuita para dividir PowerPoint](https://products.aspose.app/slides/splitter) que permite a los usuarios dividir sus presentaciones en varios archivos. Esencialmente, la aplicación guarda las diapositivas seleccionadas de una presentación dada como nuevos archivos de PowerPoint (PPTX o PPT). 

{{% /alert %}}