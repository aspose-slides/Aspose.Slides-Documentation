---
title: Referencia de API
type: docs
weight: 50
url: /es/nodejs-net/api-reference/
description: "Aspose.Slides for Node.js via .NET está documentado por la referencia de API de Aspose.Slides para .NET. Vea cómo los nombres de clases y miembros de .NET se asignan a JavaScript."
---
## **Resumen**

Aspose.Slides for Node.js via .NET no tiene una referencia de API propia. El paquete expone las clases de Aspose.Slides for .NET a JavaScript con los mismos nombres, con nombres de miembros camelCase, por lo que la [referencia de API de Aspose.Slides para .NET](https://reference.aspose.com/slides/net/) documenta sus clases, miembros y enumeraciones.

## **Mapear nombres .NET a JavaScript**

Para usar un miembro que encuentre en la referencia de API .NET, aplique estas reglas:

- **Las clases y enumeraciones conservan sus nombres .NET**, y también los valores de enumeración: `Presentation`, `ShapeType.Rectangle`, `SaveFormat.Pdf`. Impórtelos desde el paquete: `const { Presentation, SaveFormat } = require("aspose.slides.via.net");`.
- **Las propiedades y los métodos comienzan con una letra minúscula.** `Presentation.Slides` pasa a ser `presentation.slides`, y `ShapeCollection.AddAutoShape` pasa a ser `shapes.addAutoShape`. Las propiedades siguen siendo propiedades: se leen y se asignan sin paréntesis.
- **Los elementos de la colección se leen con `get(index)`,** y el número de elementos con `count`: `presentation.slides.get(0)` en lugar de `presentation.Slides[0]`.
- **Algunas sobrecargas reciben nombres diferentes.** Por ejemplo, la sobrecarga `Slide.GetImage(Size)` es `slide.getImageWithImageSize({ width, height })`. Otras comparten un método con argumentos opcionales al final: `presentation.save(path, format, options, slides)` cubre varias sobrecargas de `Presentation.Save`, y `new Presentation(null, buffer)` abre una presentación desde un `Buffer`. Cada clase es un archivo bajo la carpeta `lib` del paquete (por ejemplo, `node_modules/aspose.slides.via.net/lib/Slide.js`), donde puede consultar los nombres exactos.
- **Libere las presentaciones con `dispose`** cuando haya terminado con ellas; JavaScript no tiene la sentencia `using`.

El paquete no envuelve todos los miembros .NET. Si un miembro de la referencia de API .NET falta en el archivo de clase, no está disponible en JavaScript.

## **Ejemplo**

El siguiente script utiliza las reglas anteriores. Cada comentario muestra la llamada .NET a la que corresponde la siguiente línea. Añade un rectángulo con texto a la primera diapositiva, genera la diapositiva como una imagen PNG de 960 × 540 píxeles y guarda la presentación como PDF. Ejecútelo desde una carpeta de proyecto donde el paquete esté instalado como se describe en [Instalación](/slides/es/nodejs-net/installation/).

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat, ImageFormat } = asposeSlides;

const presentation = new Presentation();
try {
    // .NET: presentation.Slides[0]
    const slide = presentation.slides.get(0);

    // .NET: slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100)
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);

    // .NET: rectangle.TextFrame.Text = "..."
    rectangle.textFrame.text = "Names follow the .NET API in camelCase.";

    // .NET: slide.GetImage(new Size(960, 540))
    const slideImage = slide.getImageWithImageSize({ width: 960, height: 540 });
    slideImage.save("slide.png", ImageFormat.Png);
    slideImage.dispose();

    // .NET: presentation.Save("slide.pdf", SaveFormat.Pdf)
    presentation.save("slide.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

El script escribe `slide.png` y `slide.pdf` en la carpeta actual. Ambos muestran el rectángulo con su texto. Sin una licencia, también muestran una marca de agua de evaluación; vea [Licencias](/slides/es/nodejs-net/licensing/).

Para obtener detalles sobre los miembros usados aquí, consulte [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), [ShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addautoshape/), [TextFrame.Text](https://reference.aspose.com/slides/net/aspose.slides/textframe/text/) y [Slide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/) en la referencia de API de Aspose.Slides para .NET.