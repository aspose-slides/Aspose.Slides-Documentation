---
title: Redimensionar Formas en Diapositiva
type: docs
weight: 110
url: /java/re-sizing-shapes-on-slide/
---

## **Redimensionar Formas en Diapositiva**
Una de las preguntas más frecuentes que hacen los clientes de Aspose.Slides para Java es cómo redimensionar formas para que, cuando se cambie el tamaño de la diapositiva, los datos no se corten. Este breve consejo técnico muestra cómo lograrlo.

Para evitar la desorientación de las formas, cada forma en la diapositiva debe actualizarse de acuerdo con el nuevo tamaño de la diapositiva.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeShape-ResizeShape.java" >}}

{{% alert color="primary" %}} 

Si hay alguna tabla en la diapositiva, el código anterior no funcionará perfectamente. En ese caso, cada celda de la tabla necesita ser redimensionada.

{{% /alert %}} 

Necesitas usar el siguiente código en tu lado si necesitas redimensionar las diapositivas con tablas. Establecer el ancho o alto de la tabla es un caso especial en las formas donde necesitas alterar la altura de las filas individuales y el ancho de las columnas para alterar la altura y el ancho de la tabla.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeSlideWithTable-ResizeSlideWithTable.java" >}}