---
title: Formatear texto usando VSTO y Aspose.Slides para Java
linktitle: Formatear texto
type: docs
weight: 30
url: /es/java/format-text-using-vsto-and-aspose-slides-for-java/
keywords:
- formatear texto
- migración
- VSTO
- automatización de Office
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Migra de la automatización de Microsoft Office a Aspose.Slides para Java y formatea texto en presentaciones PowerPoint (PPT, PPTX) con control preciso."
---
{{% alert color="info" %}} 

A veces, es necesario formatear el texto en diapositivas de forma programática. Este artículo muestra cómo leer una presentación de ejemplo con texto en la primera diapositiva usando [VSTO](/slides/es/java/format-text-using-vsto-and-aspose-slides-for-java/) y [Aspose.Slides for Java](/slides/es/java/format-text-using-vsto-and-aspose-slides-for-java/). El código formatea el texto del tercer cuadro de texto de la diapositiva para que tenga el mismo aspecto que el texto del último cuadro de texto.

{{% /alert %}} 
## **Formato de texto**
Ambos métodos, VSTO y Aspose.Slides, siguen los siguientes pasos:

1. Abrir la presentación de origen.  
2. Acceder a la primera diapositiva.  
3. Acceder al tercer cuadro de texto.  
4. Cambiar el formato del texto del tercer cuadro de texto.  
5. Guardar la presentación en disco.

Las capturas de pantalla a continuación muestran la diapositiva de ejemplo antes y después de la ejecución del código VSTO y Aspose.Slides para Java.

**La presentación de entrada** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_1.png)
### **Ejemplo de código VSTO**
El código siguiente muestra cómo reformatear texto en una diapositiva usando VSTO.

**El texto reformateado con VSTO** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_2.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-FormatTextUsingVSTO-FormatTextUsingVSTO.cs" >}}

### **Ejemplo de Aspose.Slides para Java**
Para formatear texto con Aspose.Slides, añada la fuente antes de formatear el texto.

**La presentación de salida creada con Aspose.Slides** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_3.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FormatText-FormatText.java" >}}