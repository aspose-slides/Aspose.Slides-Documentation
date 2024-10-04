---
title: Propiedades Efectivas de Forma
type: docs
weight: 50
url: /es/cpp/shape-effective-properties/
---

En este tema, discutiremos **propiedades** **efectivas** y **locales**. Cuando establecemos valores directamente en estos niveles

1. En propiedades de porción en la diapositiva de la porción.
1. En estilo de texto de forma prototipo en la diapositiva de diseño o de maestra (si la forma del marco de texto de la porción tiene uno).
1. En la configuración global de texto de la presentación.

entonces esos valores se llaman **valores locales**. En cualquier nivel, los **valores locales** pueden ser definidos u omitidos. Pero finalmente, cuando llega el momento en que la aplicación necesita saber cómo debe verse la porción, utiliza los **valores efectivos**. Puedes obtener valores efectivos utilizando el método **GetEffective()** del formato local.

El siguiente ejemplo muestra cómo obtener valores efectivos.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetEffectiveValues-GetEffectiveValues.cpp" >}}

## **Obtener Propiedades Efectivas de la Cámara**
Aspose.Slides para C++ permite a los desarrolladores obtener las propiedades efectivas de la cámara. Para este propósito, se ha añadido la clase **CameraEffectiveData** en Aspose.Slides. La clase CameraEffectiveData representa un objeto inmutable que contiene las propiedades efectivas de la cámara. Una instancia de la clase **CameraEffectiveData** se utiliza como parte de la clase **ThreeDFormatEffectiveData**, que es un par de valores efectivos para la clase ThreeDFormat.

El siguiente fragmento de código muestra cómo obtener propiedades efectivas para la cámara.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetCameraEffectiveData-GetCameraEffectiveData.cpp" >}}

## **Obtener Propiedades Efectivas del Ligero Rig**
Aspose.Slides para C++ permite a los desarrolladores obtener las propiedades efectivas del Ligero Rig. Para este propósito, se ha añadido la clase **LightRigEffectiveData** en Aspose.Slides. La clase LightRigEffectiveData representa un objeto inmutable que contiene las propiedades efectivas del ligero rig. Una instancia de la clase **LightRigEffectiveData** se utiliza como parte de la clase **ThreeDFormatEffectiveData**, que es un par de valores efectivos para la clase ThreeDFormat.

El siguiente fragmento de código muestra cómo obtener propiedades efectivas para el Ligero Rig.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetLightRigEffectiveData-GetLightRigEffectiveData.cpp" >}}

## **Obtener Propiedades Efectivas de la Forma Bevel**
Aspose.Slides para C++ permite a los desarrolladores obtener las propiedades efectivas de la Forma Bevel. Para este propósito, se ha añadido la clase **ShapeBevelEffectiveData** en Aspose.Slides. La clase ShapeBevelEffectiveData representa un objeto inmutable que contiene las propiedades de relieve de la cara de la forma efectiva. Una instancia de la clase **ShapeBevelEffectiveData** se utiliza como parte de la clase **ThreeDFormatEffectiveData**, que es un par de valores efectivos para la clase ThreeDFormat.

El siguiente fragmento de código muestra cómo obtener propiedades efectivas para la Forma Bevel.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetShapeBevelEffectiveData-GetShapeBevelEffectiveData.cpp" >}}

## **Obtener Propiedades Efectivas del Marco de Texto**
Usando Aspose.Slides para C++, puedes obtener propiedades efectivas del Marco de Texto. Para este propósito, se ha añadido la clase **TextFrameFormatEffectiveData** en Aspose.Slides, que contiene propiedades efectivas de formato del marco de texto.

El siguiente fragmento de código muestra cómo obtener propiedades efectivas de formato del marco de texto.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetTextFrameFormatEffectiveData-GetTextFrameFormatEffectiveData.cpp" >}}

## **Obtener Propiedades Efectivas del Estilo de Texto**
Usando Aspose.Slides para C++, puedes obtener propiedades efectivas del Estilo de Texto. Para este propósito, se ha añadido la clase **TextStyleEffectiveData** en Aspose.Slides, que contiene propiedades efectivas del estilo de texto.

El siguiente fragmento de código muestra cómo obtener propiedades efectivas del estilo de texto.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetTextStyleEffectiveData-GetTextStyleEffectiveData.cpp" >}}

## **Obtener Valor Efectivo de Altura de Fuente**
Usando Aspose.Slides para C++, puedes obtener propiedades efectivas de la Altura de Fuente. Aquí está el código que demuestra el cambio del valor efectivo de altura de fuente de la porción después de establecer valores locales de altura de fuente en diferentes niveles de estructura de presentación.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetLocalFontHeightValues-SetLocalFontHeightValues.cpp" >}}

## **Obtener Formato de Relleno Efectivo para Tabla**
Usando Aspose.Slides para C++, puedes obtener formateo de relleno efectivo para diferentes partes lógicas de la tabla. Para este propósito, se ha añadido la interfaz **IFillFormatEffectiveData** en Aspose.Slides, que contiene propiedades de formateo de relleno efectivo. Ten en cuenta que el formato de celda siempre tiene mayor prioridad que el formato de fila, una fila tiene mayor prioridad que la columna y la columna tiene mayor prioridad que toda la tabla.

Así que, finalmente, las propiedades de **CellFormatEffectiveData** se utilizan siempre para dibujar la tabla. El siguiente fragmento de código muestra cómo obtener formateo de relleno efectivo para diferentes partes lógicas de la tabla.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetEffectiveValuesOfTable-GetEffectiveValuesOfTable.cpp" >}}