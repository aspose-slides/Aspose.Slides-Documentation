---
title: Gestionar listas con viñetas y numeradas en presentaciones en .NET
linktitle: Gestionar listas
type: docs
weight: 70
url: /es/net/manage-bullet-and-numbered-lists
keywords:
- viñeta
- lista con viñetas
- lista numerada
- viñeta de símbolo
- viñeta de imagen
- viñeta personalizada
- lista multinivel
- crear viñeta
- agregar viñeta
- agregar lista
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Aprenda a gestionar listas con viñetas y numeradas en presentaciones de PowerPoint y OpenDocument usando Aspose.Slides para .NET. Guía paso a paso."
---

En **Microsoft PowerPoint**, puedes crear listas con viñetas y numeradas de la misma manera que lo haces en Word y otros editores de texto. **Aspose.Slides for .NET** también te permite usar viñetas y números en diapositivas de tus presentaciones. 

## **¿Por qué usar listas con viñetas?**

Las listas con viñetas te ayudan a organizar y presentar la información de forma rápida y eficiente. 

**Ejemplo de lista con viñetas**

En la mayoría de los casos, una lista con viñetas cumple estas tres funciones principales:

- atrae la atención de tus lectores o espectadores a información importante
- permite a tus lectores o espectadores escanear fácilmente los puntos clave
- comunica y entrega los detalles importantes de manera eficiente.

## **¿Por qué usar listas numeradas?**

Las listas numeradas también ayudan a organizar y presentar la información. Idealmente, debes usar números (en lugar de viñetas) cuando el orden de los elementos (por ejemplo, *paso 1, paso 2*, etc.) es importante o cuando un elemento debe ser referenciado (por ejemplo, *ver paso 3*).

**Ejemplo de lista numerada**

Este es un resumen de los pasos (del paso 1 al paso 15) en el procedimiento **Creating Bullets** que se muestra a continuación:

1. Crea una instancia de la clase Presentation. 
2. Realiza varias tareas (del paso 3 al paso 14).
3. Guarda la presentación. 

## **Crear viñetas**

Para crear una lista con viñetas, sigue estos pasos:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Accede a la diapositiva (en la que deseas agregar una lista con viñetas) en la colección de diapositivas mediante el objeto [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index).
3. Añade un [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape) en la diapositiva seleccionada.
4. Accede al [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) de la forma añadida.
5. Elimina el párrafo predeterminado en el [TextFrame]().
6. Crea la primera instancia de párrafo usando la clase [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph).
8. Establece el tipo de viñeta a Symbol y luego define el carácter de viñeta.
9. Establece el texto del párrafo.
10. Establece la sangría del párrafo para colocar la viñeta.
11. Establece el color de la viñeta.
12. Establece la altura de la viñeta.
13. Añade el párrafo creado en la colección de párrafos del [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe).
14. Añade el segundo párrafo y repite los pasos 7-12.
15. Guarda la presentación.

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
    paragraph.Text = "My text";

    textFrame.Paragraphs.Add(paragraph);
    
    // ...
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **Crear viñetas con imágenes**

Aspose.Slides for .NET permite cambiar las viñetas en las listas con viñetas. Puedes sustituir las viñetas por símbolos o imágenes personalizados. Si deseas añadir un interés visual a una lista o atraer aún más la atención a los elementos de una lista, puedes usar tu propia imagen como viñeta. 

{{% alert color="primary" %}} 

Idealmente, si pretendes sustituir el símbolo de viñeta estándar por una imagen, deberías seleccionar una gráfica sencilla con fondo transparente. Ese tipo de imágenes funciona mejor como símbolos de viñeta personalizados. 

En cualquier caso, la imagen que elijas se reducirá a un tamaño muy pequeño, por lo que recomendamos encarecidamente seleccionar una imagen que se vea bien (como sustituto del símbolo de viñeta) en una lista. 

{{% /alert %}} 

Para crear una viñeta con imagen, sigue estos pasos:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Accede a la diapositiva deseada en la colección de diapositivas mediante el objeto [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index).
3. Añade un [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape) en la diapositiva seleccionada.
4. Accede al [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) de la forma añadida.
5. Elimina el párrafo predeterminado en el [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe).
6. Crea la primera instancia de párrafo usando la clase [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph).
7. Carga la imagen desde el disco y añádela a [Presentation.Images](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/images) y luego usa la instancia [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) que devuelve el método [AddImage](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/methods/addimage/index).
8. Establece el tipo de viñeta a Picture y luego asigna la imagen.
9. Establece el texto del párrafo.
10. Establece la sangría del párrafo para colocar la viñeta.
11. Establece el color de la viñeta.
12. Establece la altura de las viñetas.
13. Añade el párrafo creado en la colección de párrafos del [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe).
14. Añade el segundo párrafo y repite los pasos 7-13.
15. Guarda la presentación.

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
    paragraph.Text = "My text";

    textFrame.Paragraphs.Add(paragraph);
    
    // ...

    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **Crear viñetas multinivel**

Para crear una lista con viñetas que contenga elementos en diferentes niveles —listas adicionales bajo la lista principal— sigue estos pasos:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Accede a la diapositiva deseada en la colección de diapositivas mediante el objeto [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index).
3. Añade un [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape) en la diapositiva seleccionada.
4. Accede al [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) de la forma añadida.
5. Elimina el párrafo predeterminado en el [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe).
6. Crea la primera instancia de párrafo usando la clase [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph) y con la profundidad establecida en 0.
7. Crea la segunda instancia de párrafo usando la clase Paragraph y con la profundidad establecida en 1.
8. Crea la tercera instancia de párrafo usando la clase Paragraph y con la profundidad establecida en 2.
9. Crea la cuarta instancia de párrafo usando la clase Paragraph y con la profundidad establecida en 3.
10. Añade los párrafos creados en la colección de párrafos del [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe).
11. Guarda la presentación.

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 300, 300);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Paragraphs.Clear();
    
    Paragraph paragraph = new Paragraph();
    paragraph.ParagraphFormat.Depth = 0;
    paragraph.Text = "My text Depth 0";
    textFrame.Paragraphs.Add(paragraph);
    
    Paragraph paragraph2 = new Paragraph();
    paragraph2.ParagraphFormat.Depth = 0;
    paragraph2.Text = "My text Depth 1";
    textFrame.Paragraphs.Add(paragraph2);
    
    Paragraph paragraph3 = new Paragraph();
    paragraph3.ParagraphFormat.Depth = 2;
    paragraph3.Text = "My text Depth 2";
    textFrame.Paragraphs.Add(paragraph3);
    
    Paragraph paragraph4 = new Paragraph();
    paragraph4.ParagraphFormat.Depth = 3;
    paragraph4.Text = "My text Depth 3";
    textFrame.Paragraphs.Add(paragraph4);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **Crear números**

Este código C# muestra cómo crear una lista numerada en una diapositiva:
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Paragraphs.Clear();
    
    Paragraph paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    paragraph.Text = "My text 1";
    textFrame.Paragraphs.Add(paragraph);
    
    Paragraph paragraph2 = new Paragraph();
    paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    paragraph2.Text = "My text 2";
    textFrame.Paragraphs.Add(paragraph2);
    
    // ...
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **Preguntas frecuentes**

**¿Se pueden exportar las listas con viñetas y numeradas creadas con Aspose.Slides a otros formatos como PDF o imágenes?**

Sí, Aspose.Slides preserva completamente el formato y la estructura de las listas con viñetas y numeradas cuando las presentaciones se exportan a formatos como PDF, imágenes y otros, garantizando resultados consistentes.

**¿Es posible importar listas con viñetas o numeradas de presentaciones existentes?**

Sí, Aspose.Slides permite importar y editar listas con viñetas o numeradas de presentaciones existentes mientras se mantiene su formato y apariencia original.

**¿Aspose.Slides admite listas con viñetas y numeradas en presentaciones creadas en varios idiomas?**

Sí, Aspose.Slides admite plenamente presentaciones multilingües, lo que permite crear listas con viñetas y numeradas en cualquier idioma, incluidos caracteres especiales o no latinos.