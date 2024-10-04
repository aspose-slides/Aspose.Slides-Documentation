---
title: Formatear texto utilizando VSTO y Aspose.Slides para PHP a través de Java
type: docs
weight: 30
url: /php-java/format-text-using-vsto-and-aspose-slides-for-java/
---

{{% alert color="primary" %}} 

A veces, necesitas formatear el texto en las diapositivas programáticamente. Este artículo muestra cómo leer una presentación de ejemplo con algo de texto en la primera diapositiva utilizando [VSTO](/slides/php-java/format-text-using-vsto-and-aspose-slides-for-java/) y [Aspose.Slides para PHP a través de Java](/slides/php-java/format-text-using-vsto-and-aspose-slides-for-java/). El código formatea el texto en la tercera caja de texto de la diapositiva para que se parezca al texto en la última caja de texto.

{{% /alert %}} 
## **Formateo de Texto**
Tanto los métodos de VSTO como de Aspose.Slides siguen los siguientes pasos:

1. Abrir la presentación fuente.
1. Acceder a la primera diapositiva.
1. Acceder a la tercera caja de texto.
1. Cambiar el formato del texto en la tercera caja de texto.
1. Guardar la presentación en disco.

Las capturas de pantalla a continuación muestran la diapositiva de ejemplo antes y después de la ejecución del código de VSTO y Aspose.Slides para PHP a través de PHP.

**La presentación de entrada** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_1.png)
### **Ejemplo de Código VSTO**
El código a continuación muestra cómo reformatear texto en una diapositiva utilizando VSTO.

**El texto reformateado con VSTO** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_2.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-FormatTextUsingVSTO-FormatTextUsingVSTO.cs" >}}


### **Ejemplo de Aspose.Slides para PHP a través de Java**
Para formatear texto con Aspose.Slides, añade la fuente antes de formatear el texto.

**La presentación de salida creada con Aspose.Slides** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_3.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FormatText-FormatText.java" >}}