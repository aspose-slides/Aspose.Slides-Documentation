---
title: Obtener propiedades efectivas de forma desde presentaciones en C++
linktitle: Propiedades efectivas
type: docs
weight: 50
url: /es/cpp/shape-effective-properties/
keywords:
- propiedades de forma
- propiedades de cámara
- rig de luz
- forma biselada
- marco de texto
- estilo de texto
- altura de fuente
- formato de relleno
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Descubra cómo Aspose.Slides para C++ calcula y aplica las propiedades efectivas de forma para una renderización precisa de PowerPoint."
---

En este tema, discutiremos las propiedades **efectivas** y **locales**. Cuando establecemos valores directamente en estos niveles

1. En las propiedades de porción en la diapositiva de la porción.
1. En el estilo de texto de la forma prototipo en la diapositiva de diseño o maestra (si la forma del marco de texto de la porción tiene uno).
1. En la configuración global de texto de la presentación.

entonces esos valores se denominan valores **locales**. En cualquier nivel, los valores **locales** pueden estar definidos o omitidos. Pero al final, cuando llega el momento en que la aplicación necesita saber cómo debe verse la porción, utiliza valores **efectivos**. Puede obtener valores efectivos mediante el método **GetEffective()** del formato local.

El siguiente ejemplo muestra cómo obtener valores efectivos.



{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetEffectiveValues-GetEffectiveValues.cpp" >}}


## **Obtener propiedades efectivas de una cámara**
Aspose.Slides para C++ permite a los desarrolladores obtener propiedades efectivas de la cámara. Para este fin, se ha añadido la clase **CameraEffectiveData** en Aspose.Slides. La clase CameraEffectiveData representa un objeto inmutable que contiene las propiedades efectivas de la cámara. Una instancia de la clase **CameraEffectiveData** se usa como parte de la clase **ThreeDFormatEffectiveData**, que es un par de valores efectivos para la clase ThreeDFormat.

El siguiente ejemplo de código muestra cómo obtener propiedades efectivas para la cámara.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetCameraEffectiveData-GetCameraEffectiveData.cpp" >}}

## **Obtener propiedades efectivas de Light Rig**
Aspose.Slides para C++ permite a los desarrolladores obtener propiedades efectivas de Light Rig. Para este fin, se ha añadido la clase **LightRigEffectiveData** en Aspose.Slides. LightRigEffectiveData representa un objeto inmutable que contiene propiedades efectivas de Light Rig. Una instancia de la clase **LightRigEffectiveData** se usa como parte de la clase **ThreeDFormatEffectiveData**, que es un par de valores efectivos para la clase ThreeDFormat.

El siguiente ejemplo de código muestra cómo obtener propiedades efectivas para Light Rig.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetLightRigEffectiveData-GetLightRigEffectiveData.cpp" >}}

## **Obtener propiedades efectivas de una forma biselada**
Aspose.Slides para C++ permite a los desarrolladores obtener propiedades efectivas de Shape Bevel. Para este fin, se ha añadido la clase **ShapeBevelEffectiveData** en Aspose.Slides. ShapeBevelEffectiveData representa un objeto inmutable que contiene las propiedades efectivas del relieve de la cara de la forma. Una instancia de la clase **ShapeBevelEffectiveData** se usa como parte de la clase **ThreeDFormatEffectiveData**, que es un par de valores efectivos para la clase ThreeDFormat.

El siguiente ejemplo de código muestra cómo obtener propiedades efectivas para la forma biselada.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetShapeBevelEffectiveData-GetShapeBevelEffectiveData.cpp" >}}

## **Obtener propiedades efectivas de un marco de texto**
Usando Aspose.Slides para C++, puede obtener propiedades efectivas de un Text Frame. Para este fin, se ha añadido la clase **TextFrameFormatEffectiveData** en Aspose.Slides, que contiene propiedades efectivas de formato de marco de texto.

El siguiente ejemplo de código muestra cómo obtener propiedades efectivas de formato de marco de texto.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetTextFrameFormatEffectiveData-GetTextFrameFormatEffectiveData.cpp" >}}

## **Obtener propiedades efectivas de un estilo de texto**
Usando Aspose.Slides para C++, puede obtener propiedades efectivas de Text Style. Para este fin, se ha añadido la clase **TextStyleEffectiveData** en Aspose.Slides, que contiene propiedades efectivas de estilo de texto.

El siguiente ejemplo de código muestra cómo obtener propiedades efectivas de estilo de texto.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetTextStyleEffectiveData-GetTextStyleEffectiveData.cpp" >}}

## **Obtener el valor efectivo de altura de fuente**
Usando Aspose.Slides para C++, puede obtener propiedades efectivas de Font Height. Aquí se muestra el código que demuestra el cambio del valor efectivo de altura de fuente de la porción después de establecer valores locales de altura de fuente en diferentes niveles de la estructura de la presentación.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetLocalFontHeightValues-SetLocalFontHeightValues.cpp" >}}

## **Obtener el formato de relleno efectivo para una tabla**
Usando Aspose.Slides para C++, puede obtener el formato de relleno efectivo para distintas partes lógicas de una tabla. Para este fin, se ha añadido la interfaz **IFillFormatEffectiveData** en Aspose.Slides, que contiene propiedades efectivas de formato de relleno. Tenga en cuenta que el formato de celda siempre tiene mayor prioridad que el formato de fila, una fila tiene mayor prioridad que la columna y la columna mayor que toda la tabla.

Así que, finalmente, siempre se usan las propiedades **CellFormatEffectiveData** para dibujar la tabla. El siguiente ejemplo de código muestra cómo obtener el formato de relleno efectivo para distintas partes lógicas de la tabla.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetEffectiveValuesOfTable-GetEffectiveValuesOfTable.cpp" >}}

## **Preguntas frecuentes**

**¿Cómo puedo saber si obtuve una "instantánea" en lugar de un "objeto en vivo", y cuándo debería volver a leer las propiedades efectivas?**  
Los objetos EffectiveData son instantáneas inmutables de los valores calculados en el momento de la llamada. Si cambia la configuración local o heredada de la forma, recupere los datos efectivos nuevamente para obtener los valores actualizados.

**¿Cambiar la diapositiva de diseño o maestra afecta a las propiedades efectivas que ya se han recuperado?**  
Sí, pero solo después de volver a leerlas. Un objeto EffectiveData ya obtenido no se actualiza por sí mismo; solicítelo nuevamente después de cambiar el diseño o la maestra.

**¿Puedo modificar valores a través de EffectiveData?**  
No. EffectiveData es de solo lectura. Realice cambios en los objetos de formato local (forma/texto/3D, etc.) y luego obtenga los valores efectivos nuevamente.

**¿Qué ocurre si una propiedad no está establecida a nivel de forma, ni en el diseño/maestra, ni en la configuración global?**  
El valor efectivo se determina mediante el mecanismo predeterminado (valores predeterminados de PowerPoint/Aspose.Slides). Ese valor resuelto pasa a formar parte de la instantánea EffectiveData.

**Desde un valor de fuente efectivo, ¿puedo saber qué nivel proporcionó el tamaño o la tipografía?**  
No directamente. EffectiveData devuelve el valor final. Para encontrar la fuente, verifique los valores locales en la porción/párrafo/marco de texto y los estilos de texto en el diseño/maestra/presentación para ver dónde aparece la primera definición explícita.

**¿Por qué los valores de EffectiveData a veces se ven idénticos a los locales?**  
Porque el valor local resultó ser el final (no se necesitó herencia de niveles superiores). En esos casos, el valor efectivo coincide con el local.

**¿Cuándo debo usar propiedades efectivas y cuándo debo trabajar solo con las locales?**  
Utilice EffectiveData cuando necesite el resultado "tal como se renderiza" después de que se aplique toda la herencia (p. ej., para alinear colores, sangrías o tamaños). Si necesita cambiar el formato en un nivel específico, modifique las propiedades locales y, si es necesario, vuelva a leer EffectiveData para verificar el resultado.