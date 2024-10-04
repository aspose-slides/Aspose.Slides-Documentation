---
title: Aplicar Protección a Presentaciones
type: docs
weight: 60
url: /es/java/applying-protection-to-presentation/
---

{{% alert color="primary" %}} 

Un uso común de Aspose.Slides es crear, actualizar y guardar presentaciones de Microsoft PowerPoint 2007 (PPTX) como parte de un flujo de trabajo automatizado. Los usuarios de la aplicación que utiliza Aspose.Slides de esta manera tienen acceso a las presentaciones de salida. Protegerlas de la edición es una preocupación común. Es importante que las presentaciones generadas automáticamente mantengan su formato y contenido originales.

Este artículo explica cómo [se construyen presentaciones y diapositivas](/slides/es/java/applying-protection-to-presentation/) y cómo Aspose.Slides para Java puede [aplicar protección a](/slides/es/java/applying-protection-to-presentation/), y luego [eliminarla de](/slides/es/java/applying-protection-to-presentation/) una presentación. Esta característica es exclusiva de Aspose.Slides y, en el momento de escribir, no está disponible en Microsoft PowerPoint. Ofrece a los desarrolladores una forma de controlar cómo se utilizan las presentaciones que sus aplicaciones crean.

{{% /alert %}} 
## **Composición de una Diapositiva**
Una diapositiva PPTX está compuesta por varios componentes como autoadhesivos, tablas, objetos OLE, formas agrupadas, marcos de imagen, marcos de video, conectores y otros elementos disponibles para construir una presentación. En Aspose.Slides para Java, cada elemento en una diapositiva se convierte en un objeto Shape. En otras palabras, cada elemento en la diapositiva es un objeto Shape o un objeto derivado del objeto Shape. La estructura de PPTX es compleja, por lo que a diferencia de PPT, donde se puede usar un bloqueo genérico para todos los tipos de formas, hay diferentes tipos de bloqueos para diferentes tipos de formas. La clase BaseShapeLock es la clase de bloqueo genérico de PPTX. Los siguientes tipos de bloqueos son compatibles en Aspose.Slides para Java para PPTX.

- AutoShapeLock bloquea autoadhesivos.
- ConnectorLock bloquea formas conectores.
- GraphicalObjectLock bloquea objetos gráficos.
- GroupshapeLock bloquea formas agrupadas.
- PictureFrameLock bloquea marcos de imagen.
  Cualquier acción realizada en todos los objetos Shape en un objeto Presentation se aplica a toda la presentación.
## **Aplicar y Eliminar Protección**
Aplicar protección asegura que una presentación no pueda ser editada. Es una técnica útil para proteger el contenido de una presentación.
## **Aplicar Protección a Formas PPTX**
Aspose.Slides para Java proporciona la clase Shape para manejar una forma en la diapositiva.

Como se mencionó anteriormente, cada clase de forma tiene una clase de bloqueo de forma asociada para protección. Este artículo se centra en los bloqueos NoSelect, NoMove y NoResize. Estos bloqueos aseguran que las formas no puedan ser seleccionadas (a través de clics del mouse u otros métodos de selección), y que no puedan ser movidas o redimensionadas.

Los ejemplos de código que siguen aplican protección a todos los tipos de formas en una presentación.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-ApplyProtection-ApplyProtection.java" >}}
## **Eliminar Protección**
La protección aplicada usando Aspose.Slides para .NET/Java solo se puede eliminar con Aspose.Slides para .NET/Java. Para desbloquear una forma, establece el valor del bloqueo aplicado en falso. El ejemplo de código que sigue muestra cómo desbloquear formas en una presentación bloqueada.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-RemoveProtection-RemoveProtection.java" >}}




## **Resumen**
{{% alert color="primary" %}} 

Aspose.Slides ofrece una serie de opciones para aplicar protección a formas en una presentación. Es posible bloquear una forma particular, o iterar a través de todas las formas en una presentación y bloquear todas ellas para efectivamente bloquear la presentación. Solo Aspose.Slides para Java puede eliminar la protección de una presentación que ha protegido previamente. Elimina la protección estableciendo el valor de un bloqueo en falso.

{{% /alert %}}