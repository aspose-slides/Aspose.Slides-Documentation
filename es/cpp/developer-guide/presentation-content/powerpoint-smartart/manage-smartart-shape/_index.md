---
title: Administrar gráficos SmartArt en presentaciones usando C++
linktitle: Gráficos SmartArt
type: docs
weight: 20
url: /es/cpp/manage-smartart-shape/
keywords:
- objeto SmartArt
- gráfico SmartArt
- estilo SmartArt
- color SmartArt
- crear SmartArt
- agregar SmartArt
- editar SmartArt
- cambiar SmartArt
- acceder SmartArt
- tipo de diseño SmartArt
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Automatiza la creación, edición y estilo de SmartArt en PowerPoint con C++ usando Aspose.Slides, con ejemplos de código concisos y orientación centrada en el rendimiento."
---

## **Crear una forma SmartArt**
Aspose.Slides for C++ ahora permite agregar formas SmartArt personalizadas en sus diapositivas desde cero. Aspose.Slides for C++ ha proporcionado la API más simple para crear formas SmartArt de la manera más fácil. Para crear una forma SmartArt en una diapositiva, siga los pasos a continuación:

- Cree una instancia de [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) clase.
- Obtenga la referencia de una diapositiva usando su Índice.
- Agregue una forma SmartArt estableciendo su LayoutType.
- Guarde la presentación modificada como un archivo PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateSmartArtShape-CreateSmartArtShape.cpp" >}}


## **Acceder a una forma SmartArt en una diapositiva**
El siguiente código se usará para acceder a las formas SmartArt agregadas en la diapositiva de la presentación. En el código de ejemplo recorreremos cada forma dentro de la diapositiva y verificaremos si es una forma SmartArt. Si la forma es del tipo SmartArt, la conviertemos (typecast) a una instancia de SmartArt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtShape-AccessSmartArtShape.cpp" >}}

## **Acceder a una forma SmartArt con un tipo de diseño específico**
El siguiente código de ejemplo ayudará a acceder a la forma SmartArt con un LayoutType específico. Tenga en cuenta que no puede cambiar el LayoutType del SmartArt, ya que es de solo lectura y solo se establece cuando se agrega la forma SmartArt.

- Cree una instancia de `Presentation` clase y cargue la presentación con la forma SmartArt.
- Obtenga la referencia de la primera diapositiva usando su Índice.
- Recorra cada forma dentro de la primera diapositiva.
- Verifique si la forma es del tipo SmartArt y convierta (typecast) la forma seleccionada a SmartArt si lo es.
- Compruebe la forma SmartArt con el LayoutType específico y realice lo que sea necesario a continuación.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtParticularLayout-AccessSmartArtParticularLayout.cpp" >}}


## **Cambiar el estilo de una forma SmartArt**
El siguiente código de ejemplo ayudará a acceder a la forma SmartArt con un LayoutType específico.

- Cree una instancia de `Presentation` clase y cargue la presentación con la forma SmartArt.
- Obtenga la referencia de la primera diapositiva usando su Índice.
- Recorra cada forma dentro de la primera diapositiva.
- Verifique si la forma es del tipo SmartArt y convierta (typecast) la forma seleccionada a SmartArt si lo es.
- Encuentre la forma SmartArt con un Estilo específico.
- Establezca el nuevo Estilo para la forma SmartArt.
- Guarde la Presentación.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangSmartArtShapeStyle-ChangSmartArtShapeStyle.cpp" >}}


## **Cambiar el estilo de color de una forma SmartArt**
En este ejemplo aprenderemos a cambiar el estilo de color de cualquier forma SmartArt. En el siguiente código de ejemplo se accederá a la forma SmartArt con un estilo de color específico y se cambiará su estilo.

- Cree una instancia de `Presentation` clase y cargue la presentación con la forma SmartArt.
- Obtenga la referencia de la primera diapositiva usando su Índice.
- Recorra cada forma dentro de la primera diapositiva.
- Verifique si la forma es del tipo SmartArt y convierta (typecast) la forma seleccionada a SmartArt si lo es.
- Encuentre la forma SmartArt con un Estilo de Color específico.
- Establezca el nuevo Estilo de Color para la forma SmartArt.
- Guarde la Presentación.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtShapeColorStyle-ChangeSmartArtShapeColorStyle.cpp" >}}

## **FAQ**

**¿Puedo animar SmartArt como un solo objeto?**

Sí. SmartArt es una forma, por lo que puede aplicar [standard animations](/slides/es/cpp/powerpoint-animation/) mediante la API de animaciones (entrada, salida, énfasis, rutas de movimiento) al igual que con otras formas.

**¿Cómo puedo encontrar un SmartArt específico en una diapositiva si no conozco su ID interno?**

Establezca y use el Texto Alternativo (AltText) y busque la forma por ese valor; esta es una forma recomendada de localizar la forma objetivo.

**¿Puedo agrupar SmartArt con otras formas?**

Sí. Puede agrupar SmartArt con otras formas (imágenes, tablas, etc.) y luego [manipulate the group](/slides/es/cpp/group/).

**¿Cómo obtengo una imagen de un SmartArt específico (p. ej., para una vista previa o informe)?**

Exporte una miniatura/imagen de la forma; la biblioteca puede [render individual shapes](/slides/es/cpp/create-shape-thumbnails/) a archivos raster (PNG/JPG/TIFF).

**¿Se conservará la apariencia de SmartArt al convertir toda la presentación a PDF?**

Sí. El motor de renderizado apunta a alta fidelidad para [PDF export](/slides/es/cpp/convert-powerpoint-to-pdf/), con una variedad de opciones de calidad y compatibilidad.