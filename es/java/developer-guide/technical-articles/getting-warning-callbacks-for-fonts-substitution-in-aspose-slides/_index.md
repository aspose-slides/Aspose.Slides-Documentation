---
title: Obtener Callbacks de Advertencia para la Sustitución de Fuentes en Aspose.Slides
type: docs
weight: 90
url: /es/java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
---

{{% alert color="primary" %}} 

Aspose.Slides para Java hace posible obtener callbacks de advertencia para la sustitución de fuentes en caso de que la fuente utilizada no esté disponible en la máquina durante el proceso de renderizado. Los callbacks de advertencia son útiles para depurar problemas de fuentes faltantes o inaccesibles durante el proceso de renderizado.

{{% /alert %}} 

Aspose.Slides para Java proporciona un método API simple para recibir callbacks de advertencia durante el proceso de renderizado. Siga los pasos a continuación para configurar los callbacks de advertencia:

1. Cree una clase de callback personalizada para recibir los callbacks.
2. Establezca los callbacks de advertencia utilizando la clase LoadOptions.
3. Cargue el archivo de presentación que utiliza una fuente para el texto dentro de él que no está disponible en su máquina objetivo.
4. Genere la miniatura de la diapositiva para ver el efecto.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FontSubstitution-FontSubstitution.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FontSubstitution-IWarningCallback.java" >}}