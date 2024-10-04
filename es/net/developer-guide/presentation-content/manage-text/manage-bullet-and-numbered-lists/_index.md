---
title: Administrar Listas con Viñetas y Numeradas
type: docs
weight: 70
url: /net/manage-bullet-and-numbered-lists
keywords: "Viñetas, Listas con viñetas, Números, Listas numeradas, Viñetas de imagen, viñetas multinivel, Presentación de PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Crea listas con viñetas y numeradas en una presentación de PowerPoint en C# o .NET"
---

En **Microsoft PowerPoint**, puedes crear listas con viñetas y numeradas de la misma manera que lo haces en Word y otros editores de texto. **Aspose.Slides for .NET** también te permite usar viñetas y números en las diapositivas de tus presentaciones. 

### ¿Por qué usar listas con viñetas?

Las listas con viñetas te ayudan a organizar y presentar información de manera rápida y eficiente. 

**Ejemplo de Lista con Viñetas**

En la mayoría de los casos, una lista con viñetas cumple estas tres funciones principales:

- llama la atención de tus lectores o espectadores sobre información importante
- permite a tus lectores o espectadores escanear fácilmente los puntos clave
- comunica y entrega detalles importantes de manera eficiente.

### ¿Por qué usar listas numeradas?

Las listas numeradas también ayudan a organizar y presentar información. Idealmente, deberías usar números (en lugar de viñetas) cuando el orden de las entradas (por ejemplo, *paso 1, paso 2*, etc.) es importante o cuando se debe hacer referencia a una entrada (por ejemplo, *ver paso 3*).

**Ejemplo de Lista Numerada**

Este es un resumen de los pasos (paso 1 a paso 15) en el procedimiento de **Creación de Viñetas** a continuación:

1. Crea una instancia de la clase de presentación. 
2. Realiza varias tareas (paso 3 a paso 14).
3. Guarda la presentación. 

## Creando Viñetas 

Para crear una lista con viñetas, sigue estos pasos:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Accede a la diapositiva (en la que deseas agregar una lista con viñetas) en la colección de diapositivas a través del objeto [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index).
3. Agrega una [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape) en la diapositiva seleccionada.
4. Accede al [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) de la forma agregada.
5. Elimina el párrafo predeterminado en el [TextFrame]().
6. Crea la primera instancia de párrafo utilizando la clase [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph).
8. Establece el tipo de viñeta como Símbolo y luego establece el carácter de la viñeta.
9. Establece el texto del párrafo.
10. Establece la sangría del párrafo para configurar la viñeta.
11. Establece el color de la viñeta.
12. Establece la altura de la viñeta.
13. Agrega el párrafo creado a la colección de párrafos del [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe).
14. Agrega el segundo párrafo y repite los pasos 7-12.
15. Guarda la presentación.

Este código de ejemplo en C#—una implementación de los pasos anteriores—te muestra cómo crear una lista con viñetas en una diapositiva:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Paragraphs.Clear();
    
    Paragraph paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    paragraph.ParagraphFormat.Bullet.Char = '*';
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
    paragraph.ParagraphFormat.Bullet.Color.Color = Color.Red;
    paragraph.ParagraphFormat.Bullet.Height = 100;
    paragraph.Text = "Mi texto";

    textFrame.Paragraphs.Add(paragraph);
    
    // ...
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## Creando Viñetas de Imagen

Aspose.Slides for .NET te permite cambiar las viñetas en listas con viñetas. Puedes reemplazar las viñetas con símbolos o imágenes personalizadas. Si deseas agregar interés visual a una lista o llamar aún más la atención a las entradas de una lista, puedes usar tu propia imagen como viñeta. 

 {{% alert color="primary" %}} 

Idealmente, si tienes intención de reemplazar el símbolo de viñeta regular por una imagen, querrás seleccionar una imagen gráfica simple con un fondo transparente. Tales imágenes funcionan mejor como símbolos de viñeta personalizados. 

En cualquier caso, la imagen que elijas se reducirá a un tamaño muy pequeño, por lo que te recomendamos encarecidamente seleccionar una imagen que se vea bien (como reemplazo del símbolo de viñeta) en una lista. 

{{% /alert %}} 

Para crear una viñeta de imagen, sigue estos pasos:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Accede a la diapositiva deseada en la colección de diapositivas utilizando el objeto [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index).
3. Agrega una [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape) en la diapositiva seleccionada.
4. Accede al [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) de la forma agregada.
5. Elimina el párrafo predeterminado en el [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe).
6. Crea la primera instancia de párrafo utilizando la clase [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph).
7. Carga la imagen desde el disco y agrégala a [Presentation.Images](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/images) y luego utiliza la instancia [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) que se devolvió desde el método [AddImage](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/methods/addimage/index).
8. Establece el tipo de viñeta como Imagen y luego establece la imagen.
9. Establece el texto del párrafo.
10. Establece la sangría del párrafo para configurar la viñeta.
11. Establece el color de la viñeta.
12. Establece la altura de las viñetas.
13. Agrega el párrafo creado a la colección de párrafos del [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe).
14. Agrega el segundo párrafo y repite los pasos 7-13.
15. Guarda la presentación.

Este código C# te muestra cómo crear una viñeta de imagen en una diapositiva:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Paragraphs.Clear();
    
    
    Paragraph paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    paragraph.ParagraphFormat.Bullet.Picture.Image = image;
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.Bullet.Height = 100;
    paragraph.Text = "Mi texto";

    textFrame.Paragraphs.Add(paragraph);
    
    // ...
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## Creando Viñetas Multinivel

Para crear una lista con viñetas que contenga elementos en diferentes niveles—listas adicionales bajo la lista principal con viñetas—sigue estos pasos:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Accede a la diapositiva deseada en la colección de diapositivas utilizando el objeto [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index).
3. Agrega una [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape) en la diapositiva seleccionada.
4. Accede al [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) de la forma agregada.
5. Elimina el párrafo predeterminado en el [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe).
6. Crea la primera instancia de párrafo utilizando la clase [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph) y con la profundidad establecida en 0.
7. Crea la segunda instancia de párrafo utilizando la clase Paragraph y la profundidad establecida en 1.
8. Crea la tercera instancia de párrafo utilizando la clase Paragraph y la profundidad establecida en 2.
9. Crea la cuarta instancia de párrafo utilizando la clase Paragraph y la profundidad establecida en 3.
10. Agrega los párrafos creados a la colección de párrafos del [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe).
11. Guarda la presentación.

Este código, que es una implementación de los pasos anteriores, te muestra cómo crear una lista con viñetas multinivel en C#:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 300, 300);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Paragraphs.Clear();
    
    Paragraph paragraph = new Paragraph();
    paragraph.ParagraphFormat.Depth = 0;
    paragraph.Text = "Mi texto Profundidad 0";
    textFrame.Paragraphs.Add(paragraph);
    
    Paragraph paragraph2 = new Paragraph();
    paragraph2.ParagraphFormat.Depth = 0;
    paragraph2.Text = "Mi texto Profundidad 1";
    textFrame.Paragraphs.Add(paragraph2);
    
    Paragraph paragraph3 = new Paragraph();
    paragraph3.ParagraphFormat.Depth = 2;
    paragraph3.Text = "Mi texto Profundidad 2";
    textFrame.Paragraphs.Add(paragraph3);
    
    Paragraph paragraph4 = new Paragraph();
    paragraph4.ParagraphFormat.Depth = 3;
    paragraph4.Text = "Mi texto Profundidad 3";
    textFrame.Paragraphs.Add(paragraph4);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## Creando Números

Este código C# te muestra cómo crear una lista numerada en una diapositiva:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Paragraphs.Clear();
    
    Paragraph paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    paragraph.Text = "Mi texto 1";
    textFrame.Paragraphs.Add(paragraph);
    
    Paragraph paragraph2 = new Paragraph();
    paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    paragraph2.Text = "Mi texto 2";
    textFrame.Paragraphs.Add(paragraph2);
    
    // ...
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```