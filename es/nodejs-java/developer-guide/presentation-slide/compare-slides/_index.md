---
title: Comparar diapositivas
type: docs
weight: 50
url: /es/nodejs-java/compare-slides/
---

## **Comparar dos diapositivas**
Se ha añadido el método Equals a la clase [BaseSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide) y a la clase [BaseSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide). Devuelve true para las diapositivas/disposición y diapositivas maestro que son idénticas por su estructura y contenido estático.  

Dos diapositivas son iguales si todas las formas, estilos, textos, animaciones y otras configuraciones, etc., son iguales. La comparación no tiene en cuenta los valores de identificadores únicos, p. ej., SlideId, ni el contenido dinámico, p. ej., el valor de fecha actual en el marcador de posición de fecha.  
```javascript
var presentation1 = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    var presentation2 = new aspose.slides.Presentation("HelloWorld.pptx");
    try {
        for (var i = 0; i < presentation1.getMasters().size(); i++) {
            for (var j = 0; j < presentation2.getMasters().size(); j++) {
                if (presentation1.getMasters().get_Item(i).equals(presentation2.getMasters().get_Item(j))) {
                    console.log(java.callStaticMethodSync("java.lang.String", "format", "SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", i, j));
                }
            }
        }
    } finally {
        presentation2.dispose();
    }
} finally {
    presentation1.dispose();
}
```


## **FAQ**

**¿El hecho de que una diapositiva esté oculta afecta la comparación de las propias diapositivas?**

[Hidden status](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/gethidden/) es una propiedad a nivel de presentación/reproducción, no de contenido visual. La igualdad de dos diapositivas específicas se determina por su estructura y contenido estático; el simple hecho de que una diapositiva esté oculta no hace que las diapositivas sean diferentes.

**¿Se tienen en cuenta los hipervínculos y sus parámetros?**

Sí. Los enlaces forman parte del contenido estático de una diapositiva. Si la URL o la acción del hipervínculo difiere, normalmente se considera una diferencia en el contenido estático.

**Si un gráfico hace referencia a un archivo Excel externo, ¿se tendrá en cuenta el contenido de ese archivo?**

No. La comparación se realiza en base a las propias diapositivas. Las fuentes de datos externas generalmente no se leen al comparar; solo se considera lo que está presente en la estructura y el estado estático de la diapositiva.