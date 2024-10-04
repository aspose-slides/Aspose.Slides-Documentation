---
title: Copiando Párrafos y Porciones en PPTX
type: docs
weight: 70
url: /es/java/copying-paragraph-and-portion-in-pptx/
---

{{% alert color="primary" %}} 

Para formatear el texto de la presentación, necesitamos formatearlo a nivel de **Párrafo** y **Porción**. Hay algunas propiedades de texto que se pueden establecer a nivel de Párrafo y otras que se establecen a nivel de Porción. Si hay un párrafo o porción en el texto que necesitamos copiar a los nuevos párrafos o porciones añadidos, debemos copiar todas las propiedades del párrafo o porción respectiva al nuevo párrafo o porción añadido.

{{% /alert %}} 
## **Copiando un Párrafo**
Las propiedades del **Párrafo** se pueden acceder en la instancia **ParagraphFormat** de la clase **Paragraph**. Necesitamos copiar todas las propiedades del párrafo de origen al párrafo de destino. En el siguiente ejemplo, se comparte el método **CopyParagraph** que toma como argumento el párrafo a copiar. Copia todas las propiedades del párrafo de origen a un párrafo temporal y devuelve el mismo. El párrafo de destino obtiene los valores copiados.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-CopyParagraph-CopyParagraph.java" >}}


## **Copiando una Porción**
Las propiedades de la **Porción** se pueden acceder en la instancia **PortionFormat** de la clase **Portion**. Necesitamos copiar todas las propiedades de la porción de origen a la porción de destino. En el siguiente ejemplo, se comparte el método **CopyPortion** que toma como argumento la porción a copiar. Copia todas las propiedades de la porción de origen a una porción temporal y devuelve la misma. La porción de destino obtiene los valores copiados.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-CopyPortion-CopyPortion.java" >}}