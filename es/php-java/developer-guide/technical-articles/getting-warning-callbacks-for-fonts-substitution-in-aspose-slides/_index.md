---
title: Obtener callbacks de advertencia para la sustitución de fuentes en Aspose.Slides
type: docs
weight: 90
url: /php-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
---

{{% alert color="primary" %}} 

Aspose.Slides para PHP vía Java hace posible obtener callbacks de advertencia para la sustitución de fuentes en caso de que la fuente utilizada no esté disponible en la máquina durante el proceso de renderización. Los callbacks de advertencia son útiles para depurar los problemas de fuentes faltantes o inaccesibles durante el proceso de renderización.



{{% /alert %}} 

Aspose.Slides para PHP vía Java proporciona métodos de API simples para recibir callbacks de advertencia durante el proceso de renderización. Sigue los pasos a continuación para configurar los callbacks de advertencia:

1. Crea una clase de callback personalizada para recibir los callbacks.
1. Establece los callbacks de advertencia usando la clase LoadOptions.
1. Carga el archivo de presentación que utiliza una fuente para el texto que no está disponible en tu máquina de destino.
1. Genera la miniatura de la diapositiva para ver el efecto.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FontSubstitution-FontSubstitution.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FontSubstitution-IWarningCallback.java" >}}