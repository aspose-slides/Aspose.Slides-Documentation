---
title: Administrar párrafos de texto de PowerPoint en .NET
linktitle: Administrar párrafo
type: docs
weight: 40
url: /es/net/manage-paragraph/
keywords:
- agregar texto
- agregar párrafo
- gestionar texto
- gestionar párrafo
- gestionar viñeta
- sangría de párrafo
- sangría colgante
- viñeta de párrafo
- lista numerada
- lista con viñetas
- propiedades de párrafo
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
description: "Domina el formato de párrafos con Aspose.Slides para .NET—optimiza alineación, espaciado y estilo en presentaciones PPT, PPTX y ODP en C#."
---

Aspose.Slides proporciona todas las interfaces y clases que necesita para trabajar con textos, párrafos y porciones de PowerPoint en C#.

* Aspose.Slides proporciona la interfaz [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) para permitirle agregar objetos que representan un párrafo. Un objeto `ITextFame` puede tener uno o varios párrafos (cada párrafo se crea mediante un retorno de carro).
* Aspose.Slides proporciona la interfaz [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) para permitirle agregar objetos que representan porciones. Un objeto `IParagraph` puede tener una o varias porciones (colección de objetos iPortions).
* Aspose.Slides proporciona la interfaz [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) para permitirle agregar objetos que representan textos y sus propiedades de formato. 

Un objeto `IParagraph` es capaz de manejar textos con diferentes propiedades de formato a través de sus objetos subyacentes `IPortion`.

## **Agregar varios párrafos que contienen varias porciones**

Estos pasos le muestran cómo agregar un marco de texto que contiene 3 párrafos y cada párrafo contiene 3 porciones:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Acceder a la referencia de la diapositiva correspondiente mediante su índice.
3. Agregar un rectángulo [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) a la diapositiva.
4. Obtener el ITextFrame asociado con el [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).
5. Crear dos objetos [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) y agregarlos a la colección `IParagraphs` del [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).
6. Crear tres objetos [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) para cada nuevo `IParagraph` (dos objetos Portion para el párrafo predeterminado) y agregar cada objeto `IPortion` a la colección IPortion de cada `IParagraph`.
7. Establecer algún texto para cada porción.
8. Aplicar sus características de formato preferidas a cada porción usando las propiedades de formato expuestas por el objeto `IPortion`.
9. Guardar la presentación modificada.

Este código C# es una implementación de los pasos para agregar párrafos que contienen porciones:
```c#
 // Instancia una clase Presentation que representa un archivo PPTX
using (Presentation pres = new Presentation())
{
    // Accede a la primera diapositiva
    ISlide slide = pres.Slides[0];

    // Añade un IAutoShape tipo rectángulo
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


## **Administrar viñetas de párrafo**
Las listas con viñetas le ayudan a organizar y presentar información de forma rápida y eficiente. Los párrafos con viñetas siempre son más fáciles de leer y comprender.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Acceder a la referencia de la diapositiva correspondiente mediante su índice.
3. Agregar una [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) a la diapositiva seleccionada.
4. Acceder al [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) de la autoshape. 
5. Eliminar el párrafo predeterminado en el `TextFrame`.
6. Crear la primera instancia de párrafo usando la clase [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/).
8. Establecer el `Type` de la viñeta para el párrafo a `Symbol` y definir el carácter de la viñeta.
9. Establecer el `Text` del párrafo.
10. Establecer la `Indent` del párrafo para la viñeta.
11. Definir un color para la viñeta.
12. Definir una altura para la viñeta.
13. Agregar el nuevo párrafo a la colección de párrafos del `TextFrame`.
14. Agregar el segundo párrafo y repetir el proceso descrito en los pasos 7 a 13.
15. Guardar la presentación.

Este código C# le muestra cómo agregar una viñeta de párrafo:
```c#
// Instancia una clase Presentation que representa un archivo PPTX
using (Presentation pres = new Presentation())
{

    // Accede a la primera diapositiva
    ISlide slide = pres.Slides[0];


    // Añade y accede al Autoshape
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accede al marco de texto del autoshape
    ITextFrame txtFrm = aShp.TextFrame;

    // Elimina el párrafo predeterminado
    txtFrm.Paragraphs.RemoveAt(0);

    // Crea un párrafo
    Paragraph para = new Paragraph();

    // Establece el estilo de viñeta del párrafo y el símbolo
    para.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);

    // Establece el texto del párrafo
    para.Text = "Welcome to Aspose.Slides";

    // Establece la sangría de la viñeta
    para.ParagraphFormat.Indent = 25;

    // Establece el color de la viñeta
    para.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // establecer IsBulletHardColor a true para usar color propio de la viñeta

    // Establece la altura de la viñeta
    para.ParagraphFormat.Bullet.Height = 100;

    // Añade el párrafo al marco de texto
    txtFrm.Paragraphs.Add(para);

    // Crea un segundo párrafo
    Paragraph para2 = new Paragraph();

    // Establece el tipo y estilo de viñeta del párrafo
    para2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    para2.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;

    // Añade el texto del párrafo
    para2.Text = "This is numbered bullet";

    // Establece la sangría de la viñeta
    para2.ParagraphFormat.Indent = 25;

    para2.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para2.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para2.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // establecer IsBulletHardColor a true para usar color propio de la viñeta

    // Establece la altura de la viñeta
    para2.ParagraphFormat.Bullet.Height = 100;

    // Añade el párrafo al marco de texto
    txtFrm.Paragraphs.Add(para2);


    // Guarda la presentación modificada
    pres.Save("Bullet_out.pptx", SaveFormat.Pptx);

}
```


## **Administrar viñetas con imágenes**
Las listas con viñetas le ayudan a organizar y presentar información de forma rápida y eficiente. Los párrafos con imágenes son fáciles de leer y comprender.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Acceder a la referencia de la diapositiva correspondiente mediante su índice.
3. Agregar una [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) a la diapositiva.
4. Acceder al [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) de la autoshape.
5. Eliminar el párrafo predeterminado en el `TextFrame`.
6. Crear la primera instancia de párrafo usando la clase [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/).
7. Cargar la imagen en [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/).
8. Establecer el tipo de viñeta a [Picture](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) y definir la imagen.
9. Establecer el `Text` del párrafo.
10. Establecer la `Indent` del párrafo para la viñeta.
11. Definir un color para la viñeta.
12. Definir una altura para la viñeta.
13. Agregar el nuevo párrafo a la colección de párrafos del `TextFrame`.
14. Agregar el segundo párrafo y repetir el proceso basado en los pasos anteriores.
15. Guardar la presentación modificada.

Este código C# le muestra cómo agregar y administrar viñetas con imágenes:
```c#
// Instancia una clase Presentation que representa un archivo PPTX
Presentation presentation = new Presentation();

// Accede a la primera diapositiva
ISlide slide = presentation.Slides[0];

// Instancia la imagen para viñetas
IImage image = Images.FromFile("bullets.png");
IPPImage ippxImage = presentation.Images.AddImage(image);
image.Dispose();

// Añade y accede al Autoshape
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


## **Administrar viñetas multinivel**
Las listas con viñetas le ayudan a organizar y presentar información de forma rápida y eficiente. Las viñetas multinivel son fáciles de leer y comprender.

1. Crear una instancia de la [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class.
2. Acceder a la referencia de la diapositiva correspondiente mediante su índice.
3. Agregar una [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) en la nueva diapositiva.
4. Acceder al [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) de la autoshape.
5. Eliminar el párrafo predeterminado en el `TextFrame`.
6. Crear la primera instancia de párrafo mediante la clase [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) y establecer la profundidad en 0.
7. Crear la segunda instancia de párrafo mediante la clase `Paragraph` y establecer la profundidad en 1.
8. Crear la tercera instancia de párrafo mediante la clase `Paragraph` y establecer la profundidad en 2.
9. Crear la cuarta instancia de párrafo mediante la clase `Paragraph` y establecer la profundidad en 3.
10. Agregar los nuevos párrafos a la colección de párrafos del `TextFrame`.
11. Guardar la presentación modificada.

Este código C# le muestra cómo agregar y administrar viñetas multinivel:
```c#
// Instancia una clase Presentation que representa un archivo PPTX
using (Presentation pres = new Presentation())
{

    // Accede a la primera diapositiva
    ISlide slide = pres.Slides[0];
    
    // Añade y accede al Autoshape
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accede al marco de texto del autoshape creado
    ITextFrame text = aShp.AddTextFrame("");
    
    // Elimina el párrafo predeterminado
    text.Paragraphs.Clear();

    // Agrega el primer párrafo
    IParagraph para1 = new Paragraph();
    para1.Text = "Content";
    para1.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para1.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Establece el nivel de viñeta
    para1.ParagraphFormat.Depth = 0;

    // Agrega el segundo párrafo
    IParagraph para2 = new Paragraph();
    para2.Text = "Second Level";
    para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para2.ParagraphFormat.Bullet.Char = '-';
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Establece el nivel de viñeta
    para2.ParagraphFormat.Depth = 1;

    // Agrega el tercer párrafo
    IParagraph para3 = new Paragraph();
    para3.Text = "Third Level";
    para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Establece el nivel de viñeta
    para3.ParagraphFormat.Depth = 2;

    // Agrega el cuarto párrafo
    IParagraph para4 = new Paragraph();
    para4.Text = "Fourth Level";
    para4.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para4.ParagraphFormat.Bullet.Char = '-';
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Establece el nivel de viñeta
    para4.ParagraphFormat.Depth = 3;

    // Agrega los párrafos a la colección
    text.Paragraphs.Add(para1);
    text.Paragraphs.Add(para2);
    text.Paragraphs.Add(para3);
    text.Paragraphs.Add(para4);

    // Guarda la presentación como archivo PPTX
    pres.Save("MultilevelBullet.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Administrar un párrafo con una lista numerada personalizada**
La interfaz [IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/) proporciona la propiedad [NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith) y otras que le permiten administrar párrafos con numeración o formato personalizado. 

1. Crear una instancia de la [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class.
2. Acceder a la diapositiva que contiene el párrafo.
3. Agregar una [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) a la diapositiva.
4. Acceder al [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) de la autoshape.
5. Eliminar el párrafo predeterminado en el `TextFrame`.
6. Crear la primera instancia de párrafo mediante la clase [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) y establecer [NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith) en 2.
7. Crear la segunda instancia de párrafo mediante la clase `Paragraph` y establecer `NumberedBulletStartWith` en 3.
8. Crear la tercera instancia de párrafo mediante la clase `Paragraph` y establecer `NumberedBulletStartWith` en 7.
9. Agregar los nuevos párrafos a la colección de párrafos del `TextFrame`.
10. Guardar la presentación modificada.

Este código C# le muestra cómo agregar y administrar párrafos con numeración o formato personalizado:
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


## **Establecer sangría de párrafo**
1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Acceder a la referencia de la diapositiva correspondiente mediante su índice.
1. Agregar un rectángulo [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) a la diapositiva.
1. Agregar un [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) con tres párrafos al rectángulo autoshape.
1. Ocultar las líneas del rectángulo.
1. Establecer la sangría para cada [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) mediante su propiedad BulletOffset.
1. Guardar la presentación modificada como archivo PPT.

Este código C# le muestra cómo establecer una sangría de párrafo:
```c#
// Instancia la clase Presentation
Presentation pres = new Presentation();

// Obtiene la primera diapositiva
ISlide sld = pres.Slides[0];

// Agrega una forma rectangular
IAutoShape rect = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 500, 150);

// Agrega un TextFrame al rectángulo
ITextFrame tf = rect.AddTextFrame("This is first line \rThis is second line \rThis is third line");

// Ajusta el texto para que encaje en la forma
tf.TextFrameFormat.AutofitType = TextAutofitType.Shape;

// Oculta las líneas del rectángulo
rect.LineFormat.FillFormat.FillType = FillType.Solid;

// Obtiene el primer párrafo en el TextFrame y establece su sangría
IParagraph para1 = tf.Paragraphs[0];

// Establece el estilo de viñeta del párrafo y el símbolo
para1.ParagraphFormat.Bullet.Type = BulletType.Symbol;
para1.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
para1.ParagraphFormat.Alignment = TextAlignment.Left;

para1.ParagraphFormat.Depth = 2;
para1.ParagraphFormat.Indent = 30;

// Obtiene el segundo párrafo en el TextFrame y establece su sangría
IParagraph para2 = tf.Paragraphs[1];
para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
para2.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
para2.ParagraphFormat.Alignment = TextAlignment.Left;
para2.ParagraphFormat.Depth = 2;
para2.ParagraphFormat.Indent = 40;

// Obtiene el tercer párrafo en el TextFrame y establece su sangría
IParagraph para3 = tf.Paragraphs[2];
para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
para3.ParagraphFormat.Alignment = TextAlignment.Left;
para3.ParagraphFormat.Depth = 2;
para3.ParagraphFormat.Indent = 50;

// Guarda la presentación en disco
pres.Save("InOutDent_out.pptx", SaveFormat.Pptx);
```


## **Establecer sangría colgante para un párrafo**

Este código C# le muestra cómo establecer la sangría colgante para un párrafo:  
```c#
using (Presentation pres = new Presentation())
{
    var autoShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 250, 550, 150);

    Paragraph para1 = new Paragraph
    {
        Text = "Example"
    };
    Paragraph para2 = new Paragraph
    {
        Text = "Set Hanging Indent for Paragraph"
    };
    Paragraph para3 = new Paragraph
    {
        Text = "This C# code shows you how to set the hanging indent for a paragraph: "
    };

    para2.ParagraphFormat.MarginLeft = 10f;
    para3.ParagraphFormat.MarginLeft = 20f;
    
    autoShape.TextFrame.Paragraphs.Add(para1);
    autoShape.TextFrame.Paragraphs.Add(para2);
    autoShape.TextFrame.Paragraphs.Add(para3);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **Administrar propiedades de ejecución de fin de párrafo**

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtener la referencia de la diapositiva que contiene el párrafo mediante su posición.
1. Agregar un rectángulo [autoshape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) a la diapositiva.
1. Agregar un [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) con dos párrafos al rectángulo.
1. Establecer el `FontHeight` y el tipo de fuente para los párrafos.
1. Establecer las propiedades End para los párrafos.
1. Guardar la presentación modificada como archivo PPTX.

Este código C# le muestra cómo establecer las propiedades End para los párrafos en PowerPoint:
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


## **Importar texto HTML en párrafos**
Aspose.Slides proporciona soporte mejorado para importar texto HTML en párrafos.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Acceder a la referencia de la diapositiva correspondiente mediante su índice.
3. Agregar una [autoshape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) a la diapositiva.
4. Agregar y acceder al [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) de la autoshape.
5. Eliminar el párrafo predeterminado en el `ITextFrame`.
6. Leer el archivo HTML fuente en un TextReader.
7. Crear la primera instancia de párrafo mediante la clase [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/).
8. Agregar el contenido del archivo HTML leído por el TextReader a la [ParagraphCollection](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/) del TextFrame.
9. Guardar la presentación modificada.

Este código C# es una implementación de los pasos para importar textos HTML en párrafos:
```c#
// Crea una instancia vacía de presentación
using (Presentation pres = new Presentation())
{
    // Accede a la diapositiva predeterminada número uno de la presentación
    ISlide slide = pres.Slides[0];

    // Agrega el AutoShape para contener el contenido HTML
    IAutoShape ashape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, pres.SlideSize.Size.Width - 20, pres.SlideSize.Size.Height - 10);

    ashape.FillFormat.FillType = FillType.NoFill;

    // Agrega un marco de texto a la forma
    ashape.AddTextFrame("");

    // Borra todos los párrafos del marco de texto agregado
    ashape.TextFrame.Paragraphs.Clear();

    // Carga el archivo HTML usando StreamReader
    TextReader tr = new StreamReader("file.html");

    // Agrega el texto del lector de flujo HTML al marco de texto
    ashape.TextFrame.Paragraphs.AddFromHtml(tr.ReadToEnd());

    // Guarda la presentación
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Exportar texto de párrafo a HTML**
Aspose.Slides proporciona soporte mejorado para exportar textos (contenidos en párrafos) a HTML.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) y cargar la presentación deseada.
2. Acceder a la referencia de la diapositiva correspondiente mediante su índice.
3. Acceder a la forma que contiene el texto que se exportará a HTML.
4. Acceder al [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) de la forma.
5. Crear una instancia de `StreamWriter` y agregar el nuevo archivo HTML.
6. Proporcionar un índice inicial a StreamWriter y exportar los párrafos preferidos.

Este código C# le muestra cómo exportar textos de párrafo de PowerPoint a HTML:
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


## **Guardar un párrafo como imagen**

En esta sección, exploraremos dos ejemplos que demuestran cómo guardar un párrafo de texto, representado por la interfaz [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/), como una imagen. Ambos ejemplos incluyen la obtención de la imagen de una forma que contiene el párrafo usando los métodos `GetImage` de la interfaz [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/), el cálculo de los límites del párrafo dentro de la forma y su exportación como una imagen bitmap. Estos enfoques le permiten extraer partes específicas del texto de presentaciones de PowerPoint y guardarlas como imágenes separadas, lo que puede ser útil para diversos escenarios.

Supongamos que tenemos un archivo de presentación llamado sample.pptx con una diapositiva, donde la primera forma es un cuadro de texto que contiene tres párrafos.

![El cuadro de texto con tres párrafos](paragraph_to_image_input.png)

**Ejemplo 1**

En este ejemplo, obtenemos el segundo párrafo como una imagen. Para ello, extraemos la imagen de la forma de la primera diapositiva de la presentación y luego calculamos los límites del segundo párrafo en el marco de texto de la forma. El párrafo se vuelve a dibujar en una nueva imagen bitmap, que se guarda en formato PNG. Este método es especialmente útil cuando necesita guardar un párrafo específico como una imagen separada manteniendo las dimensiones y el formato exactos del texto.
```csharp
using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// Guarda la forma en memoria como un mapa de bits.
using var shapeImage = firstShape.GetImage();
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// Crea un mapa de bits de la forma a partir de la memoria.
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// Calcula los límites del segundo párrafo.
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();

// Calcula el tamaño para la imagen de salida (tamaño mínimo - 1x1 píxel).
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// Prepara un mapa de bits para el párrafo.
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// Redibuja el párrafo del mapa de bits de la forma al mapa de bits del párrafo.
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```


El resultado:

![La imagen del párrafo](paragraph_to_image_output.png)

**Ejemplo 2**

En este ejemplo, ampliamos el enfoque anterior añadiendo factores de escala a la imagen del párrafo. La forma se extrae de la presentación y se guarda como una imagen con un factor de escala de `2`. Esto permite una salida de mayor resolución al exportar el párrafo. Los límites del párrafo se calculan considerando la escala. La escala puede ser particularmente útil cuando se necesita una imagen más detallada, por ejemplo, para materiales impresos de alta calidad.
```csharp
var imageScaleX = 2f;
var imageScaleY = imageScaleX;

using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// Save the shape in memory as a bitmap with scaling.
using var shapeImage = firstShape.GetImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// Create a shape bitmap from memory.
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// Calculate the boundaries of the second paragraph.
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();
paragraphRectangle.X *= imageScaleX;
paragraphRectangle.Y *= imageScaleY;
paragraphRectangle.Width *= imageScaleX;
paragraphRectangle.Height *= imageScaleY;

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


## **FAQ**

**¿Puedo desactivar completamente el ajuste de línea dentro de un marco de texto?**

Sí. Use la configuración de ajuste del marco de texto ([WrapText](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/wraptext/)) para desactivar el ajuste y que las líneas no se quiebren en los bordes del marco.

**¿Cómo puedo obtener los límites exactos en la diapositiva de un párrafo específico?**

Puede obtener el rectángulo delimitador del párrafo (e incluso de una sola porción) para conocer su posición y tamaño precisos en la diapositiva.

**¿Dónde se controla la alineación del párrafo (izquierda/derecha/centro/justificado)?**

[Alignment](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/alignment/) es una configuración a nivel de párrafo en [ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/); se aplica a todo el párrafo independientemente del formato de las porciones individuales.

**¿Puedo establecer un idioma de corrección ortográfica solo para una parte del párrafo (por ejemplo, una palabra)?**

Sí. El idioma se establece a nivel de porción ([PortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/)), por lo que pueden coexistir varios idiomas dentro de un mismo párrafo.