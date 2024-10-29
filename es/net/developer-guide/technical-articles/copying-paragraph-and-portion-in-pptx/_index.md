---
title: Copiar Párrafo y Porción en PPTX
type: docs
weight: 80
url: /es/net/copying-paragraph-and-portion-in-pptx/
---

{{% alert color="primary" %}} 

Para formatear el texto de la presentación, necesitamos formatearlo a nivel de **Párrafo** y **Porción**. Hay algunas propiedades de texto que se pueden establecer a nivel de Párrafo y otras que se establecen a nivel de Porción. Si hay un párrafo o porción en el texto que necesitamos copiar a los párrafos o porciones recién añadidos, necesitamos copiar todas las propiedades del párrafo o porción respectiva al párrafo o porción recién añadida.

{{% /alert %}} 
## **Copiar un Párrafo**
Las propiedades del **Párrafo** se pueden acceder en la instancia **ParagraphFormat** de la clase **Pargraph**. Necesitamos copiar todas las propiedades del párrafo fuente al párrafo objetivo. En el siguiente ejemplo, se comparte el método **CopyParagraph** que toma como argumento el párrafo a copiar. Copia todas las propiedades del párrafo fuente a un párrafo temporal y devuelve el mismo. El párrafo objetivo recibe los valores copiados.

## **Copiar una Porción**
Las propiedades de la **Porción** se pueden acceder en la instancia **PortionFormat** de la clase **Portion**. Necesitamos copiar todas las propiedades de la porción fuente a la porción objetivo. En el siguiente ejemplo, se comparte el método **CopyPortion** que toma como argumento la porción a copiar. Copia todas las propiedades de la porción fuente a una porción temporal y devuelve la misma. La porción objetivo recibe los valores copiados.