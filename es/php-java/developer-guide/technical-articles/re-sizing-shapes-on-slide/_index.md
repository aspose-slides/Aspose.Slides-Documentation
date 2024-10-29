---
title: Cambiar el tamaño de las formas en la diapositiva
type: docs
weight: 110
url: /es/php-java/cambiar-el-tamano-de-las-formas-en-la-diapositiva/
---

## **Cambiar el tamaño de las formas en la diapositiva**
Una de las preguntas más frecuentes que hacen los clientes de Aspose.Slides para PHP a través de Java es cómo cambiar el tamaño de las formas para que, al cambiar el tamaño de la diapositiva, los datos no se corten. Este breve consejo técnico muestra cómo lograrlo.

Para evitar la desorientación de las formas, cada forma en la diapositiva necesita ser actualizada de acuerdo con el nuevo tamaño de la diapositiva.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeShape-ResizeShape.java" >}}

{{% alert color="primary" %}} 

Si hay alguna tabla en la diapositiva, el código anterior no funcionará perfectamente. En ese caso, cada celda de la tabla necesita ser redimensionada.

{{% /alert %}} 

Necesita usar el siguiente código en su parte si necesita cambiar el tamaño de las diapositivas con tablas. Establecer el ancho o la altura de la tabla es un caso especial en las formas donde necesita alterar la altura de cada fila y el ancho de cada columna para alterar la altura y el ancho de la tabla.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeSlideWithTable-ResizeSlideWithTable.java" >}}