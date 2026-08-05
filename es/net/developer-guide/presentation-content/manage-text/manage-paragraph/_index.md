---
title: Gestionar párrafos de texto de PowerPoint en .NET
linktitle: Gestionar párrafo
type: docs
weight: 40
url: /es/net/manage-paragraph/
aliases:
  - /net/parrafo/
  - /net/porcion/
keywords:
- añadir texto
- añadir párrafo
- gestionar texto
- gestionar párrafo
- gestionar viñeta
- sangría de párrafo
- sangría colgante
- viñeta de párrafo
- lista numerada
- lista con viñetas
- propiedades del párrafo
- importar HTML
- texto a HTML
- párrafo a HTML
- párrafo a imagen
- texto a imagen
- exportar párrafo
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Domina el formato de párrafos con Aspose.Slides para .NET: optimiza la alineación, el espaciado y el estilo en presentaciones PPT, PPTX y ODP en C#."
---
## **Introducción**

Aspose.Slides proporciona todas las interfaces y clases que necesita para trabajar con textos, párrafos y porciones de PowerPoint en C#.

* Aspose.Slides proporciona la interfaz [ITextFrame](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/) para permitirle añadir objetos que representan un párrafo. Un objeto `ITextFame` puede tener uno o varios párrafos (cada párrafo se crea mediante un retorno de carro).
* Aspose.Slides proporciona la interfaz [IParagraph](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraph/) para permitirle añadir objetos que representan porciones. Un objeto `IParagraph` puede tener una o varias porciones (colección de objetos iPortions).
* Aspose.Slides proporciona la interfaz [IPortion](https://reference.aspose.com/slides/es/net/aspose.slides/iportion/) para permitirle añadir objetos que representan textos y sus propiedades de formato.

Un objeto `IParagraph` es capaz de manejar textos con diferentes propiedades de formato mediante sus objetos subyacentes `IPortion`.

## **Agregar Varios Párrafos que Contienen Múltiples Porciones**

Estos pasos le muestran cómo agregar un marco de texto que contiene 3 párrafos y cada párrafo contiene 3 porciones:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation).
2. Acceda a la referencia de la diapositiva correspondiente mediante su índice.
3. Añada un [IAutoShape](https://reference.aspose.com/slides/es/net/aspose.slides/iautoshape/) rectangular a la diapositiva.
4. Obtenga el ITextFrame asociado al [IAutoShape](https://reference.aspose.com/slides/es/net/aspose.slides/iautoshape/).
5. Cree dos objetos [IParagraph](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraph/) y agréguelos a la colección `IParagraphs` del [ITextFrame](https://reference.aspose.com/slides/es/net/aspose.slides/iautoshape/).
6. Cree tres objetos [IPortion](https://reference.aspose.com/slides/es/net/aspose.slides/iportion/) para cada nuevo `IParagraph` (dos objetos Portion para el párrafo predeterminado) y añada cada objeto `IPortion` a la colección IPortion de cada `IParagraph`.
7. Establezca texto para cada porción.
8. Aplique las características de formato que prefiera a cada porción usando las propiedades de formato expuestas por el objeto `IPortion`.
9. Guarde la presentación modificada.

```c#
 // Instancia una clase Presentation que representa un archivo PPTX
using (Presentation pres = new Presentation())
{
    // Accede a la primera diapositiva
    ISlide slide = pres.Slides[0];

    // Añade un IAutoShape rectangular
    IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // Accede al TextFrame del AutoShape
    ITextFrame tf = ashp.TextFrame;

    // Crea párrafos y porciones con diferentes formatos de texto
    IParagraph para0 = tf.Paragraphs[0];
    IPortion port01 = new Portion();
    IPortion port02 = new Portion();
    para0.Portions.Add(port01);
    para0.Portions.Add(port02);

    IParagraph para1 = new Paragraph();
    tf.Paragraphs.Add(para1);
    IPortion port10 = new Portion();
    IPortion port11 = new Portion();
    IPortion port12 = new Portion();
    para1.Portions.Add(port10);
    para1.Portions.Add(port11);
    para1.Portions.Add(port12);

    IParagraph para2 = new Paragraph();
    tf.Paragraphs.Add(para2);
    IPortion port20 = new Portion();
    IPortion port21 = new Portion();
    IPortion port22 = new Portion();
    para2.Portions.Add(port20);
    para2.Portions.Add(port21);
    para2.Portions.Add(port22);

    for (int i = 0; i < 3; i++)
        for (int j = 0; j < 3; j++)
        {
            tf.Paragraphs[i].Portions[j].Text = "Portion0" + j.ToString();
            if (j == 0)
            {
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.FillType = FillType.Solid;
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontBold = NullableBool.True;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontHeight = 15;
            }
            else if (j == 1)
            {
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.FillType = FillType.Solid;
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontItalic = NullableBool.True;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontHeight = 18;
            }
        }
    // Guarda la presentación modificada
    pres.Save("multiParaPort_out.pptx", SaveFormat.Pptx);
}
```

## **Gestionar Viñetas de Párrafo**

Las listas con viñetas le ayudan a organizar y presentar información de forma rápida y eficiente. Los párrafos con viñetas siempre son más fáciles de leer y comprender.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation).
2. Acceda a la referencia de la diapositiva relevante mediante su índice.
3. Añada una [autoshape](https://reference.aspose.com/slides/es/net/aspose.slides/iautoshape/) a la diapositiva seleccionada.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/) de la autoshape.
5. Elimine el párrafo predeterminado en el `TextFrame`.
6. Cree la primera instancia de párrafo usando la clase [Paragraph](https://reference.aspose.com/slides/es/net/aspose.slides/paragraph/).
8. Establezca el `Type` de la viñeta del párrafo a `Symbol` y defina el carácter de la viñeta.
9. Establezca el `Text` del párrafo.
10. Establezca la `Indent` del párrafo para la viñeta.
11. Defina un color para la viñeta.
12. Defina una altura para la viñeta.
13. Añada el nuevo párrafo a la colección de párrafos del `TextFrame`.
14. Añada el segundo párrafo y repita el proceso descrito en los pasos 7 a 13.
15. Guarde la presentación.

```c#
// Instancia una clase Presentation que representa un archivo PPTX
using (Presentation pres = new Presentation())
{

    // Accede a la primera diapositiva
    ISlide slide = pres.Slides[0];


    // Añade y accede a Autoshape
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accede al marco de texto del autoshape
    ITextFrame txtFrm = aShp.TextFrame;

    // Elimina el párrafo predeterminado
    txtFrm.Paragraphs.RemoveAt(0);

    // Crea un párrafo
    Paragraph para = new Paragraph();

    // Establece el estilo y el símbolo de la viñeta del párrafo
    para.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);

    // Establece el texto del párrafo
    para.Text = "Welcome to Aspose.Slides";

    // Establece la sangría de la viñeta
    para.ParagraphFormat.Indent = 25;

    // Establece el color de la viñeta
    para.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // establecer IsBulletHardColor a true para usar su propio color de viñeta

    // Establece la altura de la viñeta
    para.ParagraphFormat.Bullet.Height = 100;

    // Añade el párrafo al marco de texto
    txtFrm.Paragraphs.Add(para);

    // Crea el segundo párrafo
    Paragraph para2 = new Paragraph();

    // Establece el tipo y estilo de la viñeta del párrafo
    para2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    para2.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;

    // Añade el texto del párrafo
    para2.Text = "This is numbered bullet";

    // Establece la sangría de la viñeta
    para2.ParagraphFormat.Indent = 25;

    para2.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para2.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para2.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // establecer IsBulletHardColor a true para usar su propio color de viñeta

    // Establece la altura de la viñeta
    para2.ParagraphFormat.Bullet.Height = 100;

    // Añade el párrafo al marco de texto
    txtFrm.Paragraphs.Add(para2);


    // Guarda la presentación modificada
    pres.Save("Bullet_out.pptx", SaveFormat.Pptx);

}
```

## **Gestionar Viñetas con Imagen**

Las listas con viñetas le ayudan a organizar y presentar información de forma rápida y eficiente. Los párrafos con imágenes son fáciles de leer y comprender.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation).
2. Acceda a la referencia de la diapositiva correspondiente mediante su índice.
3. Añada una [autoshape](https://reference.aspose.com/slides/es/net/aspose.slides/iautoshape/) a la diapositiva.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/es/net/aspose.slides/textframe/) de la autoshape.
5. Elimine el párrafo predeterminado en el `TextFrame`.
6. Cree la primera instancia de párrafo usando la clase [Paragraph](https://reference.aspose.com/slides/es/net/aspose.slides/paragraph/).
7. Cargue la imagen en [IPPImage](https://reference.aspose.com/slides/es/net/aspose.slides/ippimage/).
8. Establezca el tipo de viñeta a [Picture](https://reference.aspose.com/slides/es/net/aspose.slides/ippimage/) y defina la imagen.
9. Establezca el `Text` del Paragraph.
10. Establezca la `Indent` del Paragraph para la viñeta.
11. Defina un color para la viñeta.
12. Defina una altura para la viñeta.
13. Añada el nuevo párrafo a la colección de párrafos del `TextFrame`.
14. Añada el segundo párrafo y repita el proceso basado en los pasos anteriores.
15. Guarde la presentación modificada.

```c#
// Instancia una clase Presentation que representa un archivo PPTX
Presentation presentation = new Presentation();

// Accede a la primera diapositiva
ISlide slide = presentation.Slides[0];

// Instancia la imagen para viñetas
IImage image = Images.FromFile("bullets.png");
IPPImage ippxImage = presentation.Images.AddImage(image);
image.Dispose();

// Añade y accede a Autoshape
IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

// Accede al marco de texto del autoshape
ITextFrame textFrame = autoShape.TextFrame;

// Elimina el párrafo predeterminado
textFrame.Paragraphs.RemoveAt(0);

// Crea un nuevo párrafo
Paragraph paragraph = new Paragraph();
paragraph.Text = "Welcome to Aspose.Slides";

// Establece el estilo de viñeta del párrafo y la imagen
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = ippxImage;

// Establece la altura de la viñeta
paragraph.ParagraphFormat.Bullet.Height = 100;

// Añade el párrafo al marco de texto
textFrame.Paragraphs.Add(paragraph);

// Guarda la presentación como archivo PPTX
presentation.Save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

// Guarda la presentación como archivo PPT
presentation.Save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
```

## **Gestionar Viñetas Multinivel**

Las listas con viñetas le ayudan a organizar y presentar información de forma rápida y eficiente. Las viñetas multinivel son fáciles de leer y comprender.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation).
2. Acceda a la referencia de la diapositiva relevante mediante su índice.
3. Añada una [autoshape](https://reference.aspose.com/slides/es/net/aspose.slides/iautoshape/) en la nueva diapositiva.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/es/net/aspose.slides/textframe/) de la autoshape.
5. Elimine el párrafo predeterminado en el `TextFrame`.
6. Cree la primera instancia de párrafo mediante la clase [Paragraph](https://reference.aspose.com/slides/es/net/aspose.slides/paragraph/) y establezca la profundidad a 0.
7. Cree la segunda instancia de párrafo mediante la clase `Paragraph` y establezca la profundidad a 1.
8. Cree la tercera instancia de párrafo mediante la clase `Paragraph` y establezca la profundidad a 2.
9. Cree la cuarta instancia de párrafo mediante la clase `Paragraph` y establezca la profundidad a 3.
10. Añada los nuevos párrafos a la colección de párrafos del `TextFrame`.
11. Guarde la presentación modificada.

```c#
// Instancia una clase Presentation que representa un archivo PPTX
using (Presentation pres = new Presentation())
{

    // Accede a la primera diapositiva
    ISlide slide = pres.Slides[0];
    
    // Añade y accede a Autoshape
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accede al marco de texto del autoshape creado
    ITextFrame text = aShp.AddTextFrame("");
    
    // Elimina el párrafo predeterminado
    text.Paragraphs.Clear();

    // Añade el primer párrafo
    IParagraph para1 = new Paragraph();
    para1.Text = "Content";
    para1.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para1.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Establece el nivel de viñeta
    para1.ParagraphFormat.Depth = 0;

    // Añade el segundo párrafo
    IParagraph para2 = new Paragraph();
    para2.Text = "Second Level";
    para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para2.ParagraphFormat.Bullet.Char = '-';
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Establece el nivel de viñeta
    para2.ParagraphFormat.Depth = 1;

    // Añade el tercer párrafo
    IParagraph para3 = new Paragraph();
    para3.Text = "Third Level";
    para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Establece el nivel de viñeta
    para3.ParagraphFormat.Depth = 2;

    // Añade el cuarto párrafo
    IParagraph para4 = new Paragraph();
    para4.Text = "Fourth Level";
    para4.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para4.ParagraphFormat.Bullet.Char = '-';
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Establece el nivel de viñeta
    para4.ParagraphFormat.Depth = 3;

    // Añade los párrafos a la colección
    text.Paragraphs.Add(para1);
    text.Paragraphs.Add(para2);
    text.Paragraphs.Add(para3);
    text.Paragraphs.Add(para4);

    // Guarda la presentación como archivo PPTX
    pres.Save("MultilevelBullet.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Gestionar un Párrafo con una Lista Numerada Personalizada**

La interfaz [IBulletFormat](https://reference.aspose.com/slides/es/net/aspose.slides/ibulletformat/) proporciona la propiedad [NumberedBulletStartWith](https://reference.aspose.com/slides/es/net/aspose.slides/ibulletformat/numberedbulletstartwith) y otras que le permiten gestionar párrafos con numeración o formato personalizados.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation).
2. Acceda a la diapositiva que contiene el párrafo.
3. Añada una [autoshape](https://reference.aspose.com/slides/es/net/aspose.slides/iautoshape/) a la diapositiva.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/es/net/aspose.slides/textframe/) de la autoshape.
5. Elimine el párrafo predeterminado en el `TextFrame`.
6. Cree la primera instancia de párrafo mediante la clase [Paragraph](https://reference.aspose.com/slides/es/net/aspose.slides/paragraph/) y establezca [NumberedBulletStartWith](https://reference.aspose.com/slides/es/net/aspose.slides/ibulletformat/numberedbulletstartwith) a 2.
7. Cree la segunda instancia de párrafo mediante la clase `Paragraph` y establezca `NumberedBulletStartWith` a 3.
8. Cree la tercera instancia de párrafo mediante la clase `Paragraph` y establezca `NumberedBulletStartWith` a 7.
9. Añada los nuevos párrafos a la colección de párrafos del `TextFrame`.
10. Guarde la presentación modificada.

```c#
using (var presentation = new Presentation())
{
	var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

	// Accede al marco de texto del autoshape creado
	ITextFrame textFrame = shape.TextFrame;

	// Elimina el párrafo predeterminado existente
	textFrame.Paragraphs.RemoveAt(0);

	// Primera lista
	var paragraph1 = new Paragraph { Text = "bullet 2" };
	paragraph1.ParagraphFormat.Depth = 4; 
	paragraph1.ParagraphFormat.Bullet.NumberedBulletStartWith = 2;
	paragraph1.ParagraphFormat.Bullet.Type = BulletType.Numbered;
	textFrame.Paragraphs.Add(paragraph1);

	var paragraph2 = new Paragraph { Text = "bullet 3" };
	paragraph2.ParagraphFormat.Depth = 4;
	paragraph2.ParagraphFormat.Bullet.NumberedBulletStartWith = 3; 
	paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;  
	textFrame.Paragraphs.Add(paragraph2);

	
	var paragraph5 = new Paragraph { Text = "bullet 7" };
	paragraph5.ParagraphFormat.Depth = 4;
	paragraph5.ParagraphFormat.Bullet.NumberedBulletStartWith = 7;
	paragraph5.ParagraphFormat.Bullet.Type = BulletType.Numbered;
	textFrame.Paragraphs.Add(paragraph5);

	presentation.Save("SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
}
```

## **Establecer sangría de primera línea para un párrafo**

Utilice la propiedad [IParagraphFormat.Indent](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraphformat/indent/) para controlar la sangría de primera línea de un párrafo. Esta propiedad desplaza solo la primera línea respecto al margen izquierdo del párrafo. Un valor positivo desplaza la primera línea a la derecha, mientras que el resto de las líneas permanecen alineadas con el cuerpo del párrafo.

Utilice [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraphformat/marginleft/) cuando necesite mover todo el párrafo. Utilice [IParagraphFormat.Indent](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraphformat/indent/) cuando necesite mover solo la primera línea.

El ejemplo a continuación crea varios párrafos y aplica diferentes valores de `Indent` para demostrar cómo la sangría de primera línea afecta al diseño del párrafo.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/).
2. Acceda a la diapositiva objetivo.
3. Añada una [AutoShape](https://reference.aspose.com/slides/es/net/aspose.slides/autoshape/) rectangular a la diapositiva.
4. Añada un [TextFrame](https://reference.aspose.com/slides/es/net/aspose.slides/textframe/) vacío a la forma y elimine el párrafo predeterminado.
5. Cree varios párrafos y establezca diferentes valores de [Indent](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraphformat/indent/) para ellos.
6. Añada los párrafos al marco de texto.
7. Guarde la presentación modificada.

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape rectangleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.FillFormat.FillType = FillType.NoFill;
    rectangleShape.LineFormat.FillFormat.FillType = FillType.Solid;
    rectangleShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

    ITextFrame textFrame = rectangleShape.AddTextFrame(string.Empty);
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
    textFrame.Paragraphs.RemoveAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    firstParagraph.Text = "No first-line indent. Wrapped lines start at the same position as the first line.";
    firstParagraph.ParagraphFormat.MarginLeft = 20f;
    firstParagraph.ParagraphFormat.Indent = 0f;

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    secondParagraph.Text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.";
    secondParagraph.ParagraphFormat.MarginLeft = 20f;
    secondParagraph.ParagraphFormat.Indent = 20f;

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    thirdParagraph.Text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.";
    thirdParagraph.ParagraphFormat.MarginLeft = 20f;
    thirdParagraph.ParagraphFormat.Indent = 40f;

    textFrame.Paragraphs.Add(firstParagraph);
    textFrame.Paragraphs.Add(secondParagraph);
    textFrame.Paragraphs.Add(thirdParagraph);

    presentation.Save("paragraph_indent.pptx", SaveFormat.Pptx);
}
```

El resultado:

![La sangría de primera línea de los párrafos](first_line_indent.png)

## **Establecer sangría colgante para un párrafo**

Una sangría colgante es un diseño de párrafo en el que la primera línea comienza a la izquierda del resto de las líneas. En Aspose.Slides, crea este efecto con la propiedad [IParagraphFormat.Indent](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraphformat/indent/). Establezca `Indent` a un valor negativo para mover la primera línea a la izquierda respecto al cuerpo del párrafo.

En la práctica, [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraphformat/marginleft/) define la posición izquierda del cuerpo del párrafo, y [IParagraphFormat.Indent](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraphformat/indent/) define la posición de la primera línea respecto a ese margen. Para crear una sangría colgante, establezca un valor positivo de `MarginLeft` y un valor negativo de `Indent`.

Este formato es útil para bibliografías, referencias, entradas de glosario y otros párrafos donde las líneas continuas deben alinearse bajo el cuerpo del párrafo en lugar de bajo el primer carácter de la primera línea.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/).
2. Acceda a la diapositiva objetivo.
3. Añada una [AutoShape](https://reference.aspose.com/slides/es/net/aspose.slides/autoshape/) rectangular a la diapositiva.
4. Añada un [TextFrame](https://reference.aspose.com/slides/es/net/aspose.slides/textframe/) vacío a la forma y elimine el párrafo predeterminado.
5. Cree párrafos y establezca un valor positivo de [MarginLeft](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraphformat/marginleft/) para cada párrafo.
6. Establezca un valor negativo de [Indent](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraphformat/indent/) para crear el efecto de sangría colgante.
7. Añada los párrafos al marco de texto.
8. Guarde la presentación modificada.

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape rectangleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.FillFormat.FillType = FillType.NoFill;
    rectangleShape.LineFormat.FillFormat.FillType = FillType.Solid;
    rectangleShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

    ITextFrame textFrame = rectangleShape.AddTextFrame(string.Empty);
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
    textFrame.Paragraphs.RemoveAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    firstParagraph.Text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.";
    firstParagraph.ParagraphFormat.MarginLeft = 40f;
    firstParagraph.ParagraphFormat.Indent = -20f;

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    secondParagraph.Text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.";
    secondParagraph.ParagraphFormat.MarginLeft = 60f;
    secondParagraph.ParagraphFormat.Indent = -30f;

    textFrame.Paragraphs.Add(firstParagraph);
    textFrame.Paragraphs.Add(secondParagraph);

    presentation.Save("hanging_indent.pptx", SaveFormat.Pptx);
}
```

El resultado:

![La sangría colgante de los párrafos](hanging_indent.png)

## **Gestionar Propiedades de Corrida al Final del Párrafo**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation).
2. Obtenga la referencia de la diapositiva que contiene el párrafo mediante su posición.
3. Añada una [autoshape](https://reference.aspose.com/slides/es/net/aspose.slides/autoshape/) rectangular a la diapositiva.
4. Añada un [TextFrame](https://reference.aspose.com/slides/es/net/aspose.slides/textframe/) con dos párrafos al rectángulo.
5. Establezca la `FontHeight` y el tipo de fuente para los párrafos.
6. Establezca las propiedades End para los párrafos.
7. Guarde la presentación modificada como un archivo PPTX.

```c#
using (Presentation pres = new Presentation("Test.pptx"))
{
	IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

	Paragraph para1 = new Paragraph();
	para1.Portions.Add(new Portion("Sample text"));

	Paragraph para2 = new Paragraph();
	para2.Portions.Add(new Portion("Sample text 2"));
	PortionFormat endParagraphPortionFormat = new PortionFormat();
	endParagraphPortionFormat.FontHeight = 48;
	endParagraphPortionFormat.LatinFont = new FontData("Times New Roman");
	para2.EndParagraphPortionFormat = endParagraphPortionFormat;

	shape.TextFrame.Paragraphs.Add(para1);
	shape.TextFrame.Paragraphs.Add(para2);

	pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Importar Texto HTML en Párrafos**

Aspose.Slides ofrece soporte mejorado para importar texto HTML en párrafos.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation).
2. Acceda a la referencia de la diapositiva correspondiente mediante su índice.
3. Añada una [autoshape](https://reference.aspose.com/slides/es/net/aspose.slides/autoshape/) a la diapositiva.
4. Añada y acceda al [ITextFrame](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/) de la `autoshape`.
5. Elimine el párrafo predeterminado en el `ITextFrame`.
6. Lea el archivo HTML fuente con un TextReader.
7. Cree la primera instancia de párrafo mediante la clase [Paragraph](https://reference.aspose.com/slides/es/net/aspose.slides/paragraph/).
8. Añada el contenido del archivo HTML leído con el TextReader a la [ParagraphCollection](https://reference.aspose.com/slides/es/net/aspose.slides/paragraphcollection/) del TextFrame.
9. Guarde la presentación modificada.

```c#
// Crea una instancia de presentación vacía
using (Presentation pres = new Presentation())
{
    // Accede a la primera diapositiva predeterminada de la presentación
    ISlide slide = pres.Slides[0];

    // Añade el AutoShape para alojar el contenido HTML
    IAutoShape ashape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, pres.SlideSize.Size.Width - 20, pres.SlideSize.Size.Height - 10);

    ashape.FillFormat.FillType = FillType.NoFill;

    // Añade un marco de texto a la forma
    ashape.AddTextFrame("");

    // Elimina todos los párrafos del marco de texto añadido
    ashape.TextFrame.Paragraphs.Clear();

    // Carga el archivo HTML usando un StreamReader
    TextReader tr = new StreamReader("file.html");

    // Añade el texto del StreamReader HTML al marco de texto
    ashape.TextFrame.Paragraphs.AddFromHtml(tr.ReadToEnd());

    // Guarda la presentación
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Exportar Texto de Párrafo a HTML**

Aspose.Slides ofrece soporte mejorado para exportar textos (contenidos en párrafos) a HTML.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation) y cargue la presentación deseada.
2. Acceda a la referencia de la diapositiva correspondiente mediante su índice.
3. Acceda a la forma que contiene el texto que se exportará a HTML.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/es/net/aspose.slides/textframe/) de la forma.
5. Cree una instancia de `StreamWriter` y añada el nuevo archivo HTML.
6. Proporcione un índice inicial a StreamWriter y exporte los párrafos que desee.

```c#
// Carga el archivo de presentación
using (Presentation pres = new Presentation("ExportingHTMLText.pptx"))
{

    // Accede a la primera diapositiva predeterminada de la presentación
    ISlide slide = pres.Slides[0];

    // Accede al índice requerido
    int index = 0;

    // Accede a la forma añadida
    IAutoShape ashape = (IAutoShape)slide.Shapes[index];

    StreamWriter sw = new StreamWriter("output_out.html", false, Encoding.UTF8);

    // Escribe los datos de los párrafos a HTML especificando el índice de inicio del párrafo y el número de párrafos a copiar
    sw.Write(ashape.TextFrame.Paragraphs.ExportToHtml(0, ashape.TextFrame.Paragraphs.Count, null));

    sw.Close();
}
```

## **Guardar un Párrafo como Imagen**

En esta sección, exploraremos dos ejemplos que demuestran cómo guardar un párrafo de texto, representado por la interfaz [IParagraph](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraph/), como una imagen. Ambos ejemplos incluyen obtener la imagen de una forma que contiene el párrafo mediante los métodos `GetImage` de la interfaz [IShape](https://reference.aspose.com/slides/es/net/aspose.slides/ishape/), calcular los límites del párrafo dentro de la forma y exportarlo como una imagen bitmap. Estos enfoques le permiten extraer partes específicas del texto de presentaciones PowerPoint y guardarlas como imágenes independientes, lo que puede ser útil para su uso posterior en varios escenarios.

Supongamos que tenemos un archivo de presentación llamado sample.pptx con una diapositiva, donde la primera forma es un cuadro de texto que contiene tres párrafos.

![El cuadro de texto con tres párrafos](paragraph_to_image_input.png)

**Example 1**

En este ejemplo, obtenemos el segundo párrafo como una imagen. Para ello, extraemos la imagen de la forma de la primera diapositiva de la presentación y luego calculamos los límites del segundo párrafo en el marco de texto de la forma. El párrafo se vuelve a dibujar en una nueva imagen bitmap, que se guarda en formato PNG. Este método es especialmente útil cuando necesita guardar un párrafo específico como una imagen independiente conservando las dimensiones exactas y el formato del texto.

```csharp
using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// Save the shape in memory as a bitmap.
using var shapeImage = firstShape.GetImage();
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// Create a shape bitmap from memory.
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// Calculate the boundaries of the second paragraph.
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();

// Calculate the size for the output image (minimum size - 1x1 pixel).
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// Prepare a bitmap for the paragraph.
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// Redraw the paragraph from the shape bitmap to the paragraph bitmap.
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```

El resultado:

![La imagen del párrafo](paragraph_to_image_output.png)

**Example 2**

En este ejemplo, ampliamos el enfoque anterior añadiendo factores de escala a la imagen del párrafo. La forma se extrae de la presentación y se guarda como una imagen con un factor de escala de `2`. Esto permite una salida de mayor resolución al exportar el párrafo. Los límites del párrafo se calculan teniendo en cuenta la escala. La escala puede ser particularmente útil cuando se necesita una imagen más detallada, por ejemplo, para su uso en materiales impresos de alta calidad.

```csharp
var imageScaleX = 2f;
var imageScaleY = imageScaleX;

using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// Guarda la forma en memoria como un bitmap con escalado.
using var shapeImage = firstShape.GetImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// Crea un bitmap de forma a partir de la memoria.
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// Calcula los límites del segundo párrafo.
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();
paragraphRectangle.X *= imageScaleX;
paragraphRectangle.Y *= imageScaleY;
paragraphRectangle.Width *= imageScaleX;
paragraphRectangle.Height *= imageScaleY;

// Calcula el tamaño de la imagen de salida (tamaño mínimo - 1x1 píxel).
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// Prepara un bitmap para el párrafo.
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// Redibuja el párrafo del bitmap de la forma al bitmap del párrafo.
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```

## **FAQ**

**¿Puedo desactivar completamente el ajuste de línea dentro de un marco de texto?**

Sí. Utilice la configuración de ajuste del marco de texto ([WrapText](https://reference.aspose.com/slides/es/net/aspose.slides/textframeformat/wraptext/)) para desactivar el ajuste, de modo que las líneas no se rompan en los bordes del marco.

**¿Cómo puedo obtener los límites exactos en la diapositiva de un párrafo específico?**

Puede recuperar el rectángulo delimitador del párrafo (e incluso de una sola porción) para conocer su posición y tamaño precisos en la diapositiva.

**¿Dónde se controla la alineación del párrafo (izquierda/derecha/centrado/justificado)?**

[Alignment](https://reference.aspose.com/slides/es/net/aspose.slides/paragraphformat/alignment/) es una configuración a nivel de párrafo en [ParagraphFormat](https://reference.aspose.com/slides/es/net/aspose.slides/paragraphformat/); se aplica a todo el párrafo independientemente del formato de cada porción.

**¿Puedo establecer un idioma de corrector ortográfico solo para una parte del párrafo (p.ej., una palabra)?**

Sí. El idioma se establece a nivel de porción ([PortionFormat.LanguageId](https://reference.aspose.com/slides/es/net/aspose.slides/baseportionformat/languageid/)), por lo que pueden coexistir varios idiomas dentro de un mismo párrafo.