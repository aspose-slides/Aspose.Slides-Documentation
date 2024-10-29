---
title: Formatear texto usando VSTO y Aspose.Slides para Android a través de Java
type: docs
weight: 30
url: /es/androidjava/format-text-using-vsto-and-aspose-slides-for-java/
---

{{% alert color="primary" %}} 

A veces, necesitas formatear el texto en las diapositivas programáticamente. Este artículo muestra cómo leer una presentación de muestra con algo de texto en la primera diapositiva utilizando [VSTO](/slides/es/androidjava/format-text-using-vsto-and-aspose-slides-for-java/) y [Aspose.Slides para Android a través de Java](/slides/es/androidjava/format-text-using-vsto-and-aspose-slides-for-java/). El código formatea el texto en el tercer cuadro de texto en la diapositiva para que se asemeje al texto en el último cuadro de texto.

{{% /alert %}} 
## **Formateo de Texto**
Tanto los métodos VSTO como Aspose.Slides siguen los siguientes pasos:

1. Abrir la presentación de origen.
1. Acceder a la primera diapositiva.
1. Acceder al tercer cuadro de texto.
1. Cambiar el formato del texto en el tercer cuadro de texto.
1. Guardar la presentación en disco.

Las capturas de pantalla a continuación muestran la diapositiva de muestra antes y después de la ejecución del código de VSTO y Aspose.Slides para Android a través de Java.

**La presentación de entrada** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_1.png)
### **Ejemplo de Código de VSTO**
El código a continuación muestra cómo reformatear texto en una diapositiva usando VSTO.

**El texto reformateado con VSTO** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_2.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-FormatTextUsingVSTO-FormatTextUsingVSTO.cs" >}}


### **Ejemplo de Aspose.Slides para Android a través de Java**
Para formatear texto con Aspose.Slides, agrega la fuente antes de formatear el texto.

**La presentación de salida creada con Aspose.Slides** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_3.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FormatText-FormatText.java" >}}