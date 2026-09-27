---
title: Evaluar Aspose.Slides
type: docs
weight: 120
url: /es/nodejs-net/evaluate-aspose-slides/
keywords:
- evaluar Aspose.Slides
- versión de evaluación
- marca de agua de evaluación
- limitaciones de la versión de prueba
- licencia temporal
- PowerPoint
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Qué limitaciones tiene la versión de evaluación de Aspose.Slides para Node.js a través de .NET, con un script que muestra ambas limitaciones y cómo eliminarlas con una licencia."
---
## **Resumen**

La versión de evaluación de Aspose.Slides for Node.js a través de .NET es el mismo paquete npm que la versión con licencia. Sin una licencia, se ejecuta en modo de evaluación: todas las funciones funcionan, pero las presentaciones guardadas y la mayoría de las exportaciones llevan una marca de agua, y el texto que su código lee está truncado. Este artículo describe ambas limitaciones y muestra cómo eliminarlas.

## **Limitaciones de la Evaluación**

**Una marca de agua de evaluación en cada diapositiva.** Cuando guarda una presentación sin licencia, Aspose.Slides añade un cuadro de texto en el centro de cada diapositiva del archivo guardado. El cuadro de texto está bloqueado y muestra “Evaluation only.” seguido de una línea de producto y una línea de derechos de autor. La marca de agua se inserta en el archivo guardado, no en la presentación en memoria, y abrir una presentación no la añade. Un archivo que se guardó en modo de evaluación ya contiene el cuadro de texto, por lo que al abrirlo y guardarlo de nuevo se añade una segunda marca de agua a cada diapositiva.

La misma marca de agua se dibuja en la salida cuando exporta a PDF, XPS o HTML, o renderiza diapositivas como imágenes. Si renderiza una presentación que ya se guardó en modo de evaluación, la imagen muestra tanto la marca de agua guardada como la renderizada.

**Texto truncado cuando su código lo lee.** El texto que su código lee a través de la propiedad `text` de un marco de texto, párrafo o porción se corta a sus primeros cinco caracteres, seguidos del aviso “… text has been truncated due to evaluation version limitation.” El texto de cinco caracteres o menos se devuelve completo. Esto se aplica en cada diapositiva, e incluso al texto que su código acaba de asignar. Las exportaciones a Markdown y HTML5 se truncan de la misma manera.

El texto que su código escribe se guarda completo: los archivos PPTX, las páginas PDF y las imágenes de diapositivas contienen el texto íntegro.

## **Ver las Limitaciones en un Script**

El siguiente script muestra ambas limitaciones. Asume que ha instalado el paquete como se describe en [Installation](/slides/es/nodejs-net/installation/) y que lo ejecuta desde la carpeta del proyecto. Añade un rectángulo con una frase a la primera diapositiva, lee la frase de nuevo, guarda la presentación como `evaluation.pptx` y luego vuelve a abrir el archivo para contar las formas en la diapositiva.

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 500, 100);
    rectangle.textFrame.text = "Quarterly results are ready for review.";

    // Sin una licencia, solo se devuelven los primeros cinco caracteres.
    console.log("Text read back:", rectangle.textFrame.text);

    // Guardar añade la marca de agua de evaluación a cada diapositiva del archivo.
    presentation.save("evaluation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const savedPresentation = new Presentation("evaluation.pptx");
try {
    // La diapositiva ahora contiene el rectángulo y el cuadro de texto de la marca de agua.
    console.log("Shapes on the saved slide:", savedPresentation.slides.get(0).shapes.count);
} finally {
    savedPresentation.dispose();
}
```

Sin una licencia, el script imprime:

```text
Text read back: Quart... text has been truncated due to evaluation version limitation.
Shapes on the saved slide: 2
```

La segunda forma es el cuadro de texto de la marca de agua. Abra `evaluation.pptx` para ver la frase completa en el rectángulo y la marca de agua en el centro de la diapositiva.

## **Eliminar las Limitaciones**

Para eliminar ambas limitaciones, aplique una licencia antes de crear cualquier objeto `Presentation`. [Licensing](/slides/es/nodejs-net/licensing/) muestra cómo aplicar un archivo de licencia.

{{% alert color="success" title="Tip" %}}

Para probar Aspose.Slides sin las limitaciones de evaluación antes de comprar, solicite una **licencia temporal de 30 días** gratuita. Consulte [How to get a Temporary License?](https://purchase.aspose.com/temporary-license) para más detalles.

{{% /alert %}}

## **FAQ**

**¿El modo de evaluación limita el número de diapositivas?**

No. Las presentaciones se crean, abren y guardan con todas sus diapositivas. La marca de agua y el truncamiento del texto se aplican a cada diapositiva por igual.

**¿Por qué mis imágenes de diapositivas exportadas muestran la marca de agua dos veces?**

La presentación se guardó en modo de evaluación antes de renderizarla, por lo que ya contiene un cuadro de texto de marca de agua, y al renderizar sin licencia se dibuja otra sobre ella.

**¿Puedo comprobar que mi código produce el texto correcto mientras estoy en modo de evaluación?**

Sí. Abra el archivo guardado o el PDF exportado: contienen el texto completo. Sólo el texto que su código lee de nuevo, y la salida a Markdown o HTML5, se truncan.