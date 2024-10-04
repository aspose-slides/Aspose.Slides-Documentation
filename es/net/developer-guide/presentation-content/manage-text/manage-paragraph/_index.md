---
title: Administrar párrafos de PowerPoint en C#
type: docs
weight: 40
url: /net/manage-paragraph/
keywords: 
- agregar párrafo
- gestionar párrafos
- sangría de párrafo
- propiedades del párrafo
- texto HTML
- exportar texto del párrafo
- presentación de PowerPoint
- C#
- Csharp
- Aspose.Slides para .NET
description: "Crear y gestionar párrafos, texto, sangrías y propiedades en presentaciones de PowerPoint en C# o .NET"
---

Aspose.Slides proporciona todas las interfaces y clases que necesita para trabajar con textos, párrafos y porciones de PowerPoint en C#.

* Aspose.Slides proporciona la interfaz [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) para permitirle agregar objetos que representan un párrafo. Un objeto `ITextFame` puede tener uno o varios párrafos (cada párrafo se crea a través de un retorno de carro).
* Aspose.Slides proporciona la interfaz [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) para permitirle agregar objetos que representan porciones. Un objeto `IParagraph` puede tener una o varias porciones (colección de objetos iPortions).
* Aspose.Slides proporciona la interfaz [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) para permitirle agregar objetos que representan textos y sus propiedades de formato.

Un objeto `IParagraph` es capaz de manejar textos con diferentes propiedades de formato a través de sus objetos `IPortion` subyacentes.

## **Agregar múltiples párrafos que contienen múltiples porciones**

Estos pasos le muestran cómo agregar un marco de texto que contenga 3 párrafos y cada párrafo contenga 3 porciones:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Acceda a la referencia de la diapositiva relevante a través de su índice.
3. Agregue un Rectángulo [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) a la diapositiva.
4. Obtenga el ITextFrame asociado con el [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).
5. Cree dos objetos [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) y agréguelo a la colección `IParagraphs` del [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).
6. Cree tres objetos [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) para cada nuevo `IParagraph` (dos objetos Portion para el párrafo predeterminado) y agregue cada objeto `IPortion` a la colección IPortion de cada `IParagraph`.
7. Establezca algún texto para cada porción.
8. Aplique sus características de formato preferidas a cada porción utilizando las propiedades de formato expuestas por el objeto `IPortion`.
9. Guarde la presentación modificada.

Este código C# es una implementación de los pasos para agregar párrafos que contienen porciones:

```c#
// Instancia una clase Presentation que representa un archivo PPTX
using (Presentation pres = new Presentation())
{
    // Accede a la primera diapositiva
    ISlide slide = pres.Slides[0];

    // Agrega un Rectángulo IAutoShape
    IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // Accede al TextFrame del AutoShape
    ITextFrame tf = ashp.TextFrame;

    // Crea Párrafos y Porciones con diferentes formatos de texto
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

```


## **Gestionar Viñetas de Párrafo**
Las listas con viñetas ayudan a organizar y presentar información de manera rápida y eficiente. Los párrafos con viñetas son siempre más fáciles de leer y entender.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Acceda a la referencia de la diapositiva relevante a través de su índice.
3. Agregue un [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) a la diapositiva seleccionada.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) del autoshape.
5. Elimine el párrafo predeterminado en el `TextFrame`.
6. Cree la instancia del primer párrafo utilizando la clase [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/).
8. Establezca el `Type` de la viñeta del párrafo en `Symbol` y establezca el carácter de la viñeta.
9. Establezca el `Text` del párrafo.
10. Establezca la `Indent` del párrafo para la viñeta.
11. Establezca un color para la viñeta.
12. Establezca una altura para la viñeta.
13. Agregue el nuevo párrafo a la colección de párrafos del `TextFrame`.
14. Agregue el segundo párrafo y repita el proceso indicado en los pasos 7 a 13.
15. Guarde la presentación.

Este código C# le muestra cómo agregar una viñeta de párrafo:

```c#
// Instancia una clase Presentation que representa un archivo PPTX
using (Presentation pres = new Presentation())
{

    // Accede a la primera diapositiva
    ISlide slide = pres.Slides[0];


    // Agrega y accede a Autoshape
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accede al marco de texto del autoshape
    ITextFrame txtFrm = aShp.TextFrame;

    // Elimina el párrafo predeterminado
    txtFrm.Paragraphs.RemoveAt(0);

    // Crea un párrafo
    Paragraph para = new Paragraph();

    // Establece un estilo y símbolo de viñeta para el párrafo
    para.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);

    // Establece un texto para el párrafo
    para.Text = "Bienvenido a Aspose.Slides";

    // Establece la sangría de la viñeta
    para.ParagraphFormat.Indent = 25;

    // Establece el color de la viñeta
    para.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // establece IsBulletHardColor en verdadero para usar el color de viñeta propio

    // Establece la altura de la viñeta
    para.ParagraphFormat.Bullet.Height = 100;

    // Agrega el párrafo al marco de texto
    txtFrm.Paragraphs.Add(para);

    // Crea un segundo párrafo
    Paragraph para2 = new Paragraph();

    // Establece el tipo y estilo de la viñeta del párrafo
    para2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    para2.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;

    // Agrega el texto del párrafo
    para2.Text = "Esta es una viñeta numerada";

    // Establece la sangría de la viñeta
    para2.ParagraphFormat.Indent = 25;

    para2.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para2.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para2.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // establece IsBulletHardColor en verdadero para usar el color de viñeta propio

    // Establece la altura de la viñeta
    para2.ParagraphFormat.Bullet.Height = 100;

    // Agrega el párrafo al marco de texto
    txtFrm.Paragraphs.Add(para2);


    // Guarda la presentación modificada
    pres.Save("Bullet_out.pptx", SaveFormat.Pptx);

}
```


## **Gestionar Viñetas con Imágenes**
Las listas con viñetas ayudan a organizar y presentar información de manera rápida y eficiente. Los párrafos con imágenes son fáciles de leer y entender.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Acceda a la referencia de la diapositiva relevante a través de su índice.
3. Agregue un [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) a la diapositiva.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) del autoshape.
5. Elimine el párrafo predeterminado en el `TextFrame`.
6. Cree la instancia del primer párrafo utilizando la clase [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/).
7. Cargue la imagen en [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/).
8. Establezca el tipo de viñeta en [Picture](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) y establezca la imagen.
9. Establezca el `Text` del párrafo.
10. Establezca la `Indent` del párrafo para la viñeta.
11. Establezca un color para la viñeta.
12. Establezca una altura para la viñeta.
13. Agregue el nuevo párrafo a la colección de párrafos del `TextFrame`.
14. Agregue el segundo párrafo y repita el proceso según los pasos anteriores.
15. Guarde la presentación modificada.

Este código C# le muestra cómo agregar y gestionar viñetas con imágenes:

```c#
// Instancia una clase Presentation que representa un archivo PPTX
Presentation presentation = new Presentation();

// Accede a la primera diapositiva
ISlide slide = presentation.Slides[0];

// Instancia la imagen para las viñetas
IImage image = Images.FromFile("bullets.png");
IPPImage ippxImage = presentation.Images.AddImage(image);
image.Dispose();

// Agrega y accede a Autoshape
IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

// Accede al marco de texto del autoshape
ITextFrame textFrame = autoShape.TextFrame;

// Elimina el párrafo predeterminado
textFrame.Paragraphs.RemoveAt(0);

// Crea un nuevo párrafo
Paragraph paragraph = new Paragraph();
paragraph.Text = "Bienvenido a Aspose.Slides";

// Establece el estilo y la imagen de la viñeta
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = ippxImage;

// Establece la altura de la viñeta
paragraph.ParagraphFormat.Bullet.Height = 100;

// Agrega el párrafo al marco de texto
textFrame.Paragraphs.Add(paragraph);

// Escribe la presentación como archivo PPTX
presentation.Save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

// Escribe la presentación como archivo PPT
presentation.Save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
```


## **Gestionar Viñetas Multinivel**
Las listas con viñetas ayudan a organizar y presentar información de manera rápida y eficiente. Las viñetas multinivel son fáciles de leer y entender.

1. Cree una instancia de la clase [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Acceda a la referencia de la diapositiva relevante a través de su índice.
3. Agregue un [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) en la nueva diapositiva.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) del autoshape.
5. Elimine el párrafo predeterminado en el `TextFrame`.
6. Cree la instancia del primer párrafo a través de la clase [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) y establezca la profundidad en 0.
7. Cree la instancia del segundo párrafo a través de la clase `Paragraph` y establezca la profundidad en 1.
8. Cree la instancia del tercer párrafo a través de la clase `Paragraph` y establezca la profundidad en 2.
9. Cree la instancia del cuarto párrafo a través de la clase `Paragraph` y establezca la profundidad en 3.
10. Agregue los nuevos párrafos a la colección de párrafos del `TextFrame`.
11. Guarde la presentación modificada.

Este código C# le muestra cómo agregar y gestionar viñetas multinivel:

```c#
// Instancia una clase Presentation que representa un archivo PPTX
using (Presentation pres = new Presentation())
{

    // Accede a la primera diapositiva
    ISlide slide = pres.Slides[0];
    
    // Agrega y accede a Autoshape
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accede al marco de texto del autoshape creado
    ITextFrame text = aShp.AddTextFrame("");
    
    // Limpia el párrafo predeterminado
    text.Paragraphs.Clear();

    // Agrega el primer párrafo
    IParagraph para1 = new Paragraph();
    para1.Text = "Contenido";
    para1.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para1.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Establece el nivel de la viñeta
    para1.ParagraphFormat.Depth = 0;

    // Agrega el segundo párrafo
    IParagraph para2 = new Paragraph();
    para2.Text = "Segundo Nivel";
    para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para2.ParagraphFormat.Bullet.Char = '-';
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Establece el nivel de la viñeta
    para2.ParagraphFormat.Depth = 1;

    // Agrega el tercer párrafo
    IParagraph para3 = new Paragraph();
    para3.Text = "Tercer Nivel";
    para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Establece el nivel de la viñeta
    para3.ParagraphFormat.Depth = 2;

    // Agrega el cuarto párrafo
    IParagraph para4 = new Paragraph();
    para4.Text = "Cuarto Nivel";
    para4.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para4.ParagraphFormat.Bullet.Char = '-';
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Establece el nivel de la viñeta
    para4.ParagraphFormat.Depth = 3;

    // Agrega párrafos a la colección
    text.Paragraphs.Add(para1);
    text.Paragraphs.Add(para2);
    text.Paragraphs.Add(para3);
    text.Paragraphs.Add(para4);

    // Escribe la presentación como archivo PPTX
    pres.Save("MultilevelBullet.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Gestionar Párrafos con Lista Numerada Personalizada**
La interfaz [IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/) proporciona la propiedad [NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith) y otras que le permiten gestionar párrafos con numeración o formato personalizado.

1. Cree una instancia de la clase [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Acceda a la diapositiva que contiene el párrafo.
3. Agregue un [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) a la diapositiva.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) del autoshape.
5. Elimine el párrafo predeterminado en el `TextFrame`.
6. Cree la instancia del primer párrafo a través de la clase [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) y establezca [NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith) en 2.
7. Cree la instancia del segundo párrafo a través de la clase `Paragraph` y establezca `NumberedBulletStartWith` en 3.
8. Cree la instancia del tercer párrafo a través de la clase `Paragraph` y establezca `NumberedBulletStartWith` en 7.
9. Agregue los nuevos párrafos a la colección de párrafos del `TextFrame`.
10. Guarde la presentación modificada.

Este código C# le muestra cómo agregar y gestionar párrafos con numeración o formato personalizado:

```c#
using (var presentation = new Presentation())
{
	var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

	// Accede al marco de texto del autoshape creado
	ITextFrame textFrame = shape.TextFrame;

	// Elimina el párrafo existente predeterminado
	textFrame.Paragraphs.RemoveAt(0);

	// Primer lista
	var paragraph1 = new Paragraph { Text = "viñeta 2" };
	paragraph1.ParagraphFormat.Depth = 4; 
	paragraph1.ParagraphFormat.Bullet.NumberedBulletStartWith = 2;
	paragraph1.ParagraphFormat.Bullet.Type = BulletType.Numbered;
	textFrame.Paragraphs.Add(paragraph1);

	var paragraph2 = new Paragraph { Text = "viñeta 3" };
	paragraph2.ParagraphFormat.Depth = 4;
	paragraph2.ParagraphFormat.Bullet.NumberedBulletStartWith = 3; 
	paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;  
	textFrame.Paragraphs.Add(paragraph2);

	
	var paragraph5 = new Paragraph { Text = "viñeta 7" };
	paragraph5.ParagraphFormat.Depth = 4;
	paragraph5.ParagraphFormat.Bullet.NumberedBulletStartWith = 7;
	paragraph5.ParagraphFormat.Bullet.Type = BulletType.Numbered;
	textFrame.Paragraphs.Add(paragraph5);

	presentation.Save("SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
}
```


## **Establecer Sangría del Párrafo**
1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Acceda a la referencia de la diapositiva relevante a través de su índice.
1. Agregue un [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) rectangular a la diapositiva.
1. Agregue un [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) con tres párrafos al autoshape rectangular.
1. Oculte las líneas del rectángulo.
1. Establezca la sangría para cada [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) a través de su propiedad BulletOffset.
1. Escriba la presentación modificada como un archivo PPT.

Este código C# le muestra cómo establecer una sangría de párrafo:

```c#
// Instancia la clase Presentation
Presentation pres = new Presentation();

// Obtiene la primera diapositiva
ISlide sld = pres.Slides[0];

// Agrega una forma rectangular
IAutoShape rect = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 500, 150);

// Agrega un TextFrame al Rectángulo
ITextFrame tf = rect.AddTextFrame("Esta es la primera línea \rEsta es la segunda línea \rEsta es la tercera línea");

// Ajusta el texto para que se ajuste a la forma
tf.TextFrameFormat.AutofitType = TextAutofitType.Shape;

// Oculta las líneas del Rectángulo
rect.LineFormat.FillFormat.FillType = FillType.Solid;

// Obtiene el primer párrafo en el TextFrame y establece su sangría
IParagraph para1 = tf.Paragraphs[0];

// Establece el estilo y símbolo de viñeta del párrafo
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

// Escribe la presentación en el disco
pres.Save("InOutDent_out.pptx", SaveFormat.Pptx);
```

## **Establecer Sangría Colgante para el Párrafo**

Este código C# le muestra cómo establecer la sangría colgante para un párrafo:  

```c#
using (Presentation pres = new Presentation())
{
    var autoShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 250, 550, 150);

    Paragraph para1 = new Paragraph
    {
        Text = "Ejemplo"
    };
    Paragraph para2 = new Paragraph
    {
        Text = "Establecer Sangría Colgante para el Párrafo"
    };
    Paragraph para3 = new Paragraph
    {
        Text = "Este código C# le muestra cómo establecer la sangría colgante para un párrafo: "
    };

    para2.ParagraphFormat.MarginLeft = 10f;
    para3.ParagraphFormat.MarginLeft = 20f;
    
    autoShape.TextFrame.Paragraphs.Add(para1);
    autoShape.TextFrame.Paragraphs.Add(para2);
    autoShape.TextFrame.Paragraphs.Add(para3);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Gestionar Propiedades de Fin del Párrafo para el Párrafo**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
1. Obtenga la referencia para la diapositiva que contiene el párrafo a través de su posición.
1. Agregue un [autoshape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) rectangular a la diapositiva.
1. Agregue un [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) con dos párrafos al Rectángulo.
1. Establezca la `FontHeight` y el tipo de fuente para los párrafos.
1. Establezca las propiedades de Fin para los párrafos.
1. Escriba la presentación modificada como un archivo PPTX.

Este código C# le muestra cómo establecer las propiedades de Fin para los párrafos en PowerPoint:

```c#
using (Presentation pres = new Presentation("Test.pptx"))
{
	IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

	Paragraph para1 = new Paragraph();
	para1.Portions.Add(new Portion("Texto de ejemplo"));

	Paragraph para2 = new Paragraph();
	para2.Portions.Add(new Portion("Texto de ejemplo 2"));
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
Aspose.Slides proporciona un soporte mejorado para importar texto HTML en párrafos.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Acceda a la referencia de la diapositiva relevante a través de su índice.
3. Agregue un [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) a la diapositiva.
4. Agregue y acceda a `autoshape` [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/).
5. Elimine el párrafo predeterminado en el `ITextFrame`.
6. Lea el archivo HTML fuente en un TextReader.
7. Cree la instancia del primer párrafo a través de la clase [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/).
8. Agregue el contenido del archivo HTML en el TextReader leído a la [ParagraphCollection](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/) del TextFrame.
9. Guarde la presentación modificada.

Este código C# es una implementación de los pasos para importar textos HTML en párrafos:

```c#
// Crea una instancia de presentación vacía
using (Presentation pres = new Presentation())
{
    // Accede a la primera diapositiva predeterminada de la presentación
    ISlide slide = pres.Slides[0];

    // Agrega un AutoShape para albergar el contenido HTML
    IAutoShape ashape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, pres.SlideSize.Size.Width - 20, pres.SlideSize.Size.Height - 10);

    ashape.FillFormat.FillType = FillType.NoFill;

    // Agrega un marco de texto a la forma
    ashape.AddTextFrame("");

    // Limpia todos los párrafos en el marco de texto agregado
    ashape.TextFrame.Paragraphs.Clear();

    // Carga el archivo HTML utilizando un lector de flujo
    TextReader tr = new StreamReader("file.html");

    // Agrega el texto del lector de flujo HTML en el marco de texto
    ashape.TextFrame.Paragraphs.AddFromHtml(tr.ReadToEnd());

    // Guarda la Presentación
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Exportar Texto de Párrafos a HTML**
Aspose.Slides proporciona un soporte mejorado para exportar textos (contenidos en párrafos) a HTML.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) y cargue la presentación deseada.
2. Acceda a la referencia de la diapositiva relevante a través de su índice.
3. Acceda a la forma que contiene el texto que se exportará a HTML.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) de la forma.
5. Cree una instancia de `StreamWriter` y agregue el nuevo archivo HTML.
6. Proporcione un índice inicial a StreamWriter y exporte sus párrafos preferidos.

Este código C# le muestra cómo exportar textos de párrafos de PowerPoint a HTML:

```c#
// Carga el archivo de presentación
using (Presentation pres = new Presentation("ExportingHTMLText.pptx"))
{

    // Accede a la primera diapositiva predeterminada de la presentación
    ISlide slide = pres.Slides[0];

    // Accede al índice requerido
    int index = 0;

    // Accede a la forma agregada
    IAutoShape ashape = (IAutoShape)slide.Shapes[index];

    StreamWriter sw = new StreamWriter("output_out.html", false, Encoding.UTF8);

    // Escribe datos de párrafos en HTML especificando el índice inicial del párrafo y la cantidad de párrafos a copiar
    sw.Write(ashape.TextFrame.Paragraphs.ExportToHtml(0, ashape.TextFrame.Paragraphs.Count, null));

    sw.Close();
}
```