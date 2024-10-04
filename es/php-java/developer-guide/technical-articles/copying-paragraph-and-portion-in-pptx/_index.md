---
title: Copiar párrafo y porción en PPTX
type: docs
weight: 70
url: /php-java/copying-paragraph-and-portion-in-pptx/
---

{{% alert color="primary" %}} 

Para formatear el texto de la presentación, necesitamos formatearlo a nivel de **Párrafo** y **Porción**. Hay algunas propiedades de texto que se pueden establecer a nivel de Párrafo y otras que se establecen a nivel de Porción. Si hay un párrafo o porción en el texto que necesitamos copiar a los nuevos párrafos o porciones añadidos, necesitamos copiar todas las propiedades del respectivo párrafo o porción al nuevo párrafo o porción añadido.

{{% /alert %}} 
## **Copiando un Párrafo**
Las propiedades del **Párrafo** pueden ser accedidas en la instancia **ParagraphFormat** de la clase **Pargraph**. Necesitamos copiar todas las propiedades del párrafo fuente al párrafo objetivo. En el siguiente ejemplo, se comparte el método **CopyParagraph** que toma el párrafo a ser copiado como argumento. Copia todas las propiedades del párrafo fuente a un párrafo temporal y devuelve el mismo. El párrafo objetivo recibe los valores copiados.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-CopyParagraph-CopyParagraph.java" >}}

## **Copiando una Porción**
Las propiedades de la **Porción** pueden ser accedidas en la instancia **PortionFormat** de la clase **Porción**. Necesitamos copiar todas las propiedades de la porción fuente a la porción objetivo. En el siguiente ejemplo, se comparte el método **CopyPortion** que toma la porción a ser copiada como argumento. Copia todas las propiedades de la porción fuente a una porción temporal y devuelve la misma. La porción objetivo recibe los valores copiados.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-CopyPortion-CopyPortion.java" >}}