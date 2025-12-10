---
title: Agregar formas de línea a presentaciones en C++
linktitle: Línea
type: docs
weight: 50
url: /es/cpp/line/
keywords:
- línea
- crear línea
- agregar línea
- línea simple
- configurar línea
- personalizar línea
- estilo de guión
- punta de flecha
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Aprenda a manipular el formato de líneas en presentaciones de PowerPoint con Aspose.Slides para C++. Descubra propiedades, métodos y ejemplos."
---

## **Crear una línea simple**
Para agregar una línea simple a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

- Cree una instancia de [Presentation class](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
- Obtenga la referencia de una diapositiva mediante su índice.
- Agregue un AutoShape de tipo Línea usando el método [AddAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addautoshape/) expuesto por el objeto Shapes.
- Guarde la presentación modificada como un archivo PPTX.

En el ejemplo a continuación, hemos agregado una línea a la primera diapositiva de la presentación.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddPlainLineToSlide-AddPlainLineToSlide.cpp" >}}

## **Crear una línea con forma de flecha**
Aspose.Slides for C++ también permite a los desarrolladores configurar algunas propiedades de la línea para que tenga una apariencia más atractiva. Intentemos configurar algunas propiedades de la línea para que parezca una flecha. Siga los pasos a continuación para hacerlo:

- Cree una instancia de [Presentation class](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
- Obtenga la referencia de una diapositiva mediante su índice.
- Agregue un AutoShape de tipo Línea usando AddAutoShape método expuesto por el objeto Shapes.
- Establezca el estilo de línea a uno de los estilos ofrecidos por Aspose.Slides for C++.
- Establezca el ancho de la línea.
- Establezca el [Dash Style](https://reference.aspose.com/slides/cpp/aspose.slides/linedashstyle/) de la línea a uno de los estilos ofrecidos por Aspose.Slides for C++.
- Establezca el [Arrow Head Style](https://reference.aspose.com/slides/cpp/aspose.slides/lineformat/) y la longitud del punto de inicio de la línea.
- Establezca el estilo de punta de flecha y la longitud del punto final de la línea.
- Guarde la presentación modificada como un archivo PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddArrowShapedLineToSlide-AddArrowShapedLineToSlide.cpp" >}}

## **FAQ**

**¿Puedo convertir una línea regular en un conector para que se "ajuste" a las formas?**

No. Una línea regular (un [AutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/autoshape/) de tipo [Line](https://reference.aspose.com/slides/cpp/aspose.slides/shapetype/)) no se convierte automáticamente en un conector. Para que se ajuste a las formas, use el tipo [Connector](https://reference.aspose.com/slides/cpp/aspose.slides/connector/) dedicado y las [corresponding APIs](/slides/es/cpp/connector/) para conexiones.

**¿Qué debo hacer si las propiedades de una línea se heredan del tema y es difícil determinar los valores finales?**

Lea las propiedades efectivas [/slides/cpp/shape-effective-properties/] a través de las interfaces [ILineFormatEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides/ilinefillformateffectivedata/)—estas ya tienen en cuenta la herencia y los estilos del tema.

**¿Puedo bloquear una línea para evitar su edición (movimiento, cambio de tamaño)?**

Sí. Las formas proporcionan [lock objects](https://reference.aspose.com/slides/cpp/aspose.slides/autoshape/get_autoshapelock/) que le permiten [impedir operaciones de edición](/slides/es/cpp/applying-protection-to-presentation/).