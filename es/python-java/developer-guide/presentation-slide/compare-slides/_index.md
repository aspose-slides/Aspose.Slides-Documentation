---
title: Comparar diapositivas de presentación en Python
linktitle: Comparar diapositivas
type: docs
weight: 50
url: /es/python-java/compare-slides/
keywords:
- comparar diapositivas
- comparación de diapositivas
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Compare presentaciones de PowerPoint y OpenDocument programáticamente con Aspose.Slides para Python mediante Java. Identifique rápidamente las diferencias de diapositivas en el código."
---
## **Visión general**

Aspose.Slides le permite comparar diapositivas, diapositivas de diseño y diapositivas maestras utilizando el método [equals](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseslide/#equals) proporcionado por la clase [BaseSlide](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseslide/). Este método devuelve `True` cuando las diapositivas comparadas son idénticas en su estructura y contenido estático.

## **Comparar dos diapositivas**

El método [equals](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseslide/#equals) de la clase [BaseSlide](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseslide/) devuelve `True` para diapositivas, diapositivas de diseño y diapositivas maestras que son idénticas en estructura y contenido estático.

Dos diapositivas son iguales si todas sus formas, estilos, texto, animaciones y demás configuraciones son iguales. La comparación no tiene en cuenta valores de identificadores únicos, como los ID de diapositiva, ni contenido dinámico, como la fecha actual en un marcador de posición de fecha.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

source_presentation = Presentation("AccessSlides.pptx")
try:
    target_presentation = Presentation("HelloWorld.pptx")
    try:
        for i in range(source_presentation.getMasters().size()):
            for j in range(target_presentation.getMasters().size()):
                if source_presentation.getMasters().get_Item(i).equals(target_presentation.getMasters().get_Item(j)):
                    print(f"AccessSlides MasterSlide#{i} is equal to HelloWorld MasterSlide#{j}")
    finally:
        target_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **Preguntas frecuentes**

**¿El hecho de que una diapositiva esté oculta afecta la comparación de las propias diapositivas?**

El [Estado oculto](https://reference.aspose.com/slides/es/python-java/aspose.slides/slide/#getHidden) es una propiedad a nivel de presentación/reproducción, no contenido visual. La igualdad de dos diapositivas específicas se determina por su estructura y contenido estático; el simple hecho de que una diapositiva esté oculta no hace que las diapositivas sean diferentes.

**¿Se tienen en cuenta los hipervínculos y sus parámetros?**

Sí. Los enlaces forman parte del contenido estático de una diapositiva. Si la URL o la acción del hipervínculo difieren, normalmente se considera una diferencia en el contenido estático.

**Si un gráfico hace referencia a un archivo Excel externo, ¿se tendrán en cuenta los contenidos de ese archivo?**

No. La comparación se realiza basándose únicamente en las propias diapositivas. Las fuentes de datos externas generalmente no se leen en el momento de la comparación; solo se considera lo que está presente en la estructura y el estado estático de la diapositiva.