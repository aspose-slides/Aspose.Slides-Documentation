---
title: Problema de Objeto Cambiado Al Agregar OleObjectFrame
type: docs
weight: 10
url: /es/java/object-changed-issue-when-adding-oleobjectframe/
---

## **Declaración del Problema**
Cuando los desarrolladores añaden un **OleObjectFrame** a sus diapositivas utilizando Aspose.Slides para Java, se muestra un mensaje de **Objeto Cambiado** en la diapositiva de salida en lugar del **OLE Object**. La mayoría de los clientes de Aspose.Slides para Java piensan que es un error o fallo en Aspose.Slides para Java.
## **Análisis Crítico y Explicación**
En primer lugar, es importante saber que el mensaje de **Objeto Cambiado** mostrado por Aspose.Slides para Java después de agregar **OleObjectFrame** en la diapositiva, **NO** es un error o fallo en Aspose.Slides para Java. Es solo una información o mensaje para notificar a los usuarios que el objeto ha cambiado y la imagen debe actualizarse.

Por ejemplo, si agregas un **Gráfico de Microsoft Excel** como un **OleObjectFrame** a tu diapositiva (para más detalles y un fragmento de código sobre cómo agregar **OleObjectFrame** a tu diapositiva, [haz clic aquí](/slides/es/java/adding-frame-to-the-slide/)) y luego abres el archivo de presentación usando MS PowerPoint, entonces la diapositiva (donde se agregó el **OLE Object**) se vería así:

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_1.png)

**Figura**: Diapositiva mostrando el mensaje de **Objeto Cambiado** después de agregar el **OLE Object**

Esto no es un error y tu OLE Object aún está agregado a la diapositiva. Si deseas probarlo, **Haz Doble Clic** en el mensaje de **Objeto Cambiado** o **Haz Clic Derecho** en él y selecciona la opción **Objeto de Hoja de Cálculo -> Editar** como se muestra a continuación en la figura:

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_2.png)

**Figura**: Seleccionando la opción **Editar** para editar el **OLE Object**

Después de seleccionar la opción **Editar** del menú emergente, verás que el **Objeto OLE Embebido** se volverá visible en forma editable como se muestra a continuación:

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_3.png)

**Figura**: **OLE Object** en forma editable

Aún puedes ver el mensaje de **Objeto Cambiado** en la diapositiva en el **Panel Izquierdo** de MS PowerPoint que muestra las vistas previas de las diapositivas. Una vez que hagas clic en el **OLE Object**, verás que la vista previa de la diapositiva también cambiará y el mensaje de **Objeto Cambiado** será reemplazado por la imagen del **OLE Object** como se muestra a continuación:

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_4.png)

**Figura**: Actualización de la imagen del **OLE Object**

Ahora, debes **Guardar** tu archivo de presentación usando MS PowerPoint para que la imagen del **OLE Object** se actualice. Una vez que guardes tu presentación y la abras nuevamente usando MS PowerPoint, verás que no habrá ningún mensaje de **Objeto Cambiado**.
## **Más Soluciones**
En el análisis crítico anterior, demostramos que la imagen del **OLE Object** puede actualizarse abriendo el archivo de presentación en MS PowerPoint y luego guardándolo. Pero, hay dos soluciones más para lidiar con el mensaje de **Objeto Cambiado**.
## **1ª Solución: Reemplazar el Mensaje de Objeto Cambiado con una Imagen**
Si no te gusta el mensaje de **Objeto Cambiado**, también puedes reemplazar ese mensaje con tu propia imagen. Puedes añadir cualquier imagen deseada a tu presentación y luego usar el Id de esa imagen añadida para reemplazar el mensaje de **Objeto Cambiado**.

Para lograr esto, puedes añadir estas pocas líneas de código en tu aplicación después de agregar **OleObjectFrame** a tu diapositiva.
## **Ejemplo**
{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Images-ReplacingObjectChangedMessageWithAnImage-ReplacingObjectChangedMessageWithAnImage.java" >}}

Después de agregar las líneas anteriores en tu aplicación, la diapositiva resultante que contiene **OleObjectFrame** se vería así:

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_5.png)

**Figura**: Mensaje de **Objeto Cambiado** reemplazado por una imagen
## **2ª Solución: Crear un Complemento para MS PowerPoint**
También puedes intentar crear un complemento para MS PowerPoint, que actualice todos los **OLE objects** cuando abras la presentación en MS PowerPoint.