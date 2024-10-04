---
title: Aplicando Protección a la Presentación
type: docs
weight: 10
url: /cpp/applying-protection-to-presentation/
---

{{% alert color="primary" %}} 

Un uso común de Aspose.Slides es crear, actualizar y guardar presentaciones de Microsoft PowerPoint 2007 (PPTX) como parte de un flujo de trabajo automatizado. Los usuarios de la aplicación que utiliza Aspose.Slides de esta manera tienen acceso a las presentaciones de salida. Protegerlas de la edición es una preocupación común. Es importante que las presentaciones generadas automáticamente mantengan su formato y contenido originales.

Este artículo explica cómo [se construyen las presentaciones y diapositivas](/slides/cpp/applying-protection-to-presentation/) y cómo Aspose.Slides para C++ puede [aplicar protección a](/slides/cpp/applying-protection-to-presentation/), y luego [eliminarla de](/slides/cpp/applying-protection-to-presentation/) una presentación. Esta característica es exclusiva de Aspose.Slides y, en el momento de escribir, no está disponible en Microsoft PowerPoint. Proporciona a los desarrolladores una forma de controlar cómo se utilizan las presentaciones que crean sus aplicaciones.

{{% /alert %}} 
## **Composición de una Diapositiva**
Una diapositiva PPTX está compuesta por varios componentes como formas automáticas, tablas, objetos OLE, formas agrupadas, marcos de imágenes, marcos de video, conectores y otros elementos diversos disponibles para construir una presentación.

En Aspose.Slides para C++, cada elemento en una diapositiva se convierte en un objeto Shape. En otras palabras, cada elemento en la diapositiva es un objeto Shape o un objeto derivado del objeto Shape.

La estructura de PPTX es compleja, así que a diferencia de PPT, donde se puede utilizar un bloqueo genérico para todos los tipos de formas, hay diferentes tipos de bloqueos para diferentes tipos de forma. La clase BaseShapeLock es la clase de bloqueo genérico para PPTX. Los siguientes tipos de bloqueos son compatibles en Aspose.Slides para C++ para PPTX.

- AutoShapeLock bloquea formas automáticas.
- ConnectorLock bloquea formas conectores.
- GraphicalObjectLock bloquea objetos gráficos.
- GroupshapeLock bloquea formas de grupo.
- PictureFrameLock bloquea marcos de imagen.

Cualquier acción realizada en todos los objetos Shape en un objeto Presentation se aplica a toda la presentación.
## **Aplicando y Eliminando Protección**
Aplicar protección asegura que una presentación no pueda ser editada. Es una técnica útil para proteger el contenido de una presentación.
### **Aplicando Protección a Formas PPTX**
Aspose.Slides para C++ proporciona la clase Shape para manejar una forma en la diapositiva.

Como se mencionó anteriormente, cada clase de forma tiene una clase de bloqueo de forma asociada para protección. Este artículo se centra en los bloqueos NoSelect, NoMove y NoResize. Estos bloqueos aseguran que las formas no puedan ser seleccionadas (a través de clics de ratón u otros métodos de selección), y no pueden ser movidas o redimensionadas.

Los ejemplos de código que siguen aplican protección a todos los tipos de formas en una presentación.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-ApplyProtection-ApplyProtection.cpp" >}}

### **Eliminando Protección**
La protección aplicada usando Aspose.Slides para C++ solo puede ser eliminada con Aspose.Slides para C++. Para desbloquear una forma, establece el valor del bloqueo aplicado en falso. El ejemplo de código que sigue muestra cómo desbloquear formas en una presentación bloqueada.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-RemoveProtection-RemoveProtection.cpp" >}}
## **Resumen**
{{% alert color="primary" %}} 

Aspose.Slides proporciona varias opciones para aplicar protección a formas en una presentación. Es posible bloquear una forma particular, o recorrer todas las formas en una presentación y bloquear todas ellas para bloquear efectivamente la presentación.

Solo Aspose.Slides para C++ puede eliminar la protección de una presentación que ha protegido previamente. Elimina la protección estableciendo el valor de un bloqueo en falso.

{{% /alert %}} 
### **Artículos Relacionados**
- La clase [ShapeEx](http://docs.aspose.com/display/slidesnet/ShapeEx+Class).
- La clase [BaseShapeLockEx](http://docs.aspose.com/display/slidesnet/BaseShapeLockEx+Class).