---
title: Gerenciar parágrafos de texto do PowerPoint em .NET
linktitle: Gerenciar Parágrafo
type: docs
weight: 40
url: /pt/net/manage-paragraph/
keywords:
- adicionar texto
- adicionar parágrafo
- gerenciar texto
- gerenciar parágrafo
- gerenciar marcador
- recuo de parágrafo
- recuo suspenso
- marcador de parágrafo
- lista numerada
- lista com marcadores
- propriedades do parágrafo
- importar HTML
- texto para HTML
- parágrafo para HTML
- parágrafo para imagem
- texto para imagem
- exportar parágrafo
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Domine a formatação de parágrafos com Aspose.Slides para .NET — otimize alinhamento, espaçamento e estilo em apresentações PPT, PPTX e ODP em C#."
---
## **Introdução**

Aspose.Slides fornece todas as interfaces e classes necessárias para trabalhar com textos, parágrafos e trechos do PowerPoint em C#.

* Aspose.Slides fornece a interface [ITextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/) para permitir que você adicione objetos que representam um parágrafo. Um objeto `ITextFame` pode ter um ou vários parágrafos (cada parágrafo é criado por meio de um retorno de carro).
* Aspose.Slides fornece a interface [IParagraph](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraph/) para permitir que você adicione objetos que representam trechos. Um objeto `IParagraph` pode ter um ou vários trechos (coleção de objetos iPortions).
* Aspose.Slides fornece a interface [IPortion](https://reference.aspose.com/slides/pt/net/aspose.slides/iportion/) para permitir que você adicione objetos que representam textos e suas propriedades de formatação. 

Um objeto `IParagraph` é capaz de lidar com textos com diferentes propriedades de formatação por meio de seus objetos subjacentes `IPortion`.

## **Adicionar Vários Parágrafos contendo Vários Trechos**

Essas etapas mostram como adicionar um quadro de texto contendo 3 parágrafos e cada parágrafo contendo 3 trechos:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
2. Acesse a referência do slide relevante por meio de seu índice.
3. Adicione um retângulo [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/) ao slide.
4. Obtenha o ITextFrame associado ao [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/).
5. Crie dois objetos [IParagraph](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraph/) e adicione-os à coleção `IParagraphs` do [ITextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/).
6. Crie três objetos [IPortion](https://reference.aspose.com/slides/pt/net/aspose.slides/iportion/) para cada novo `IParagraph` (dois objetos Portion para o Parágrafo padrão) e adicione cada objeto `IPortion` à coleção IPortion de cada `IParagraph`.
7. Defina algum texto para cada trecho.
8. Aplique os recursos de formatação de sua preferência a cada trecho usando as propriedades de formatação expostas pelo objeto `IPortion`.
9. Salve a apresentação modificada.

```c#
// Instancia uma classe Presentation que representa um arquivo PPTX
using (Presentation pres = new Presentation())
{
    // Acessa o primeiro slide
    ISlide slide = pres.Slides[0];

    // Adiciona um IAutoShape retangular
    IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // Acessa o TextFrame do AutoShape
    ITextFrame tf = ashp.TextFrame;

    // Cria Parágrafos e Trechos com diferentes formatos de texto
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
    // Salva a apresentação modificada
    pres.Save("multiParaPort_out.pptx", SaveFormat.Pptx);
}
```

## **Gerenciar Marcadores de Parágrafo**

Listas com marcadores ajudam a organizar e apresentar informações de forma rápida e eficiente. Parágrafos com marcadores são sempre mais fáceis de ler e entender.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
2. Acesse a referência do slide relevante por meio de seu índice.
3. Adicione um [autoshape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/) ao slide selecionado.
4. Acesse o [TextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/) do autoshape. 
5. Remova o parágrafo padrão no `TextFrame`.
6. Crie a primeira instância de parágrafo usando a classe [Paragraph](https://reference.aspose.com/slides/pt/net/aspose.slides/paragraph/).
8. Defina o `Type` do marcador para o parágrafo como `Symbol` e defina o caractere do marcador.
9. Defina o `Text` do parágrafo.
10. Defina o `Indent` do parágrafo para o marcador.
11. Defina uma cor para o marcador.
12. Defina a altura do marcador.
13. Adicione o novo parágrafo à coleção de parágrafos do `TextFrame`.
14. Adicione o segundo parágrafo e repita o processo descrito nas etapas 7 a 13.
15. Salve a apresentação.

```c#
// Instancia uma classe Presentation que representa um arquivo PPTX
using (Presentation pres = new Presentation())
{

    // Acessa o primeiro slide
    ISlide slide = pres.Slides[0];


    // Adiciona e acessa o Autoshape
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Acessa o quadro de texto do autoshape
    ITextFrame txtFrm = aShp.TextFrame;

    // Remove o parágrafo padrão
    txtFrm.Paragraphs.RemoveAt(0);

    // Cria um parágrafo
    Paragraph para = new Paragraph();

    // Define o estilo de marcador do parágrafo e o símbolo
    para.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);

    // Define o texto do parágrafo
    para.Text = "Welcome to Aspose.Slides";

    // Define o recuo do marcador
    para.ParagraphFormat.Indent = 25;

    // Define a cor do marcador
    para.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // define IsBulletHardColor como true para usar a própria cor do marcador

    // Define a altura do marcador
    para.ParagraphFormat.Bullet.Height = 100;

    // Adiciona o Parágrafo ao quadro de texto
    txtFrm.Paragraphs.Add(para);

    // Cria o segundo parágrafo
    Paragraph para2 = new Paragraph();

    // Define o tipo e o estilo do marcador do parágrafo
    para2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    para2.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;

    // Adiciona o texto do parágrafo
    para2.Text = "This is numbered bullet";

    // Define o recuo do marcador
    para2.ParagraphFormat.Indent = 25;

    para2.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para2.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para2.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // define IsBulletHardColor como true para usar a própria cor do marcador

    // Define a altura do marcador
    para2.ParagraphFormat.Bullet.Height = 100;

    // Adiciona o Parágrafo ao quadro de texto
    txtFrm.Paragraphs.Add(para2);


    // Salva a apresentação modificada
    pres.Save("Bullet_out.pptx", SaveFormat.Pptx);

}
```

## **Gerenciar Marcadores de Imagem**

Listas com marcadores ajudam a organizar e apresentar informações de forma rápida e eficiente. Parágrafos com imagens são fáceis de ler e entender.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
2. Acesse a referência do slide relevante por meio de seu índice.
3. Adicione um [autoshape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/) ao slide.
4. Acesse o [TextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/textframe/) do autoshape.
5. Remova o parágrafo padrão no `TextFrame`.
6. Crie a primeira instância de parágrafo usando a classe [Paragraph](https://reference.aspose.com/slides/pt/net/aspose.slides/paragraph/).
7. Carregue a imagem em [IPPImage](https://reference.aspose.com/slides/pt/net/aspose.slides/ippimage/).
8. Defina o tipo de marcador como [Picture](https://reference.aspose.com/slides/pt/net/aspose.slides/ippimage/) e defina a imagem.
9. Defina o `Text` do Parágrafo.
10. Defina o `Indent` do Parágrafo para o marcador.
11. Defina uma cor para o marcador.
12. Defina a altura do marcador.
13. Adicione o novo parágrafo à coleção de parágrafos do `TextFrame`.
14. Adicione o segundo parágrafo e repita o processo baseado nas etapas anteriores.
15. Salve a apresentação modificada.

```c#
// Instancia uma classe Presentation que representa um arquivo PPTX
Presentation presentation = new Presentation();

// Acessa o primeiro slide
ISlide slide = presentation.Slides[0];

// Instancia a imagem para marcadores
IImage image = Images.FromFile("bullets.png");
IPPImage ippxImage = presentation.Images.AddImage(image);
image.Dispose();

// Adiciona e acessa o Autoshape
IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

// Acessa o quadro de texto do autoshape
ITextFrame textFrame = autoShape.TextFrame;

// Remove o parágrafo padrão
textFrame.Paragraphs.RemoveAt(0);

// Cria um novo parágrafo
Paragraph paragraph = new Paragraph();
paragraph.Text = "Welcome to Aspose.Slides";

// Define o estilo de marcador do parágrafo e a imagem
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = ippxImage;

// Define a altura do marcador
paragraph.ParagraphFormat.Bullet.Height = 100;

// Adiciona o parágrafo ao quadro de texto
textFrame.Paragraphs.Add(paragraph);

// Grava a apresentação como arquivo PPTX
presentation.Save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

// Grava a apresentação como arquivo PPT
presentation.Save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
```

## **Gerenciar Marcadores de Vários Níveis**

Listas com marcadores ajudam a organizar e apresentar informações de forma rápida e eficiente. Marcadores de vários níveis são fáceis de ler e entender.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
2. Acesse a referência do slide relevante por meio de seu índice.
3. Adicione um [autoshape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/) no novo slide.
4. Acesse o [TextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/textframe/) do autoshape.
5. Remova o parágrafo padrão no `TextFrame`.
6. Crie a primeira instância de parágrafo através da classe [Paragraph](https://reference.aspose.com/slides/pt/net/aspose.slides/paragraph/) e defina a profundidade para 0.
7. Crie a segunda instância de parágrafo através da classe `Paragraph` e defina a profundidade para 1.
8. Crie a terceira instância de parágrafo através da classe `Paragraph` e defina a profundidade para 2.
9. Crie a quarta instância de parágrafo através da classe `Paragraph` e defina a profundidade para 3.
10. Adicione os novos parágrafos à coleção de parágrafos do `TextFrame`.
11. Salve a apresentação modificada.

```c#
// Instancia uma classe Presentation que representa um arquivo PPTX
using (Presentation pres = new Presentation())
{

    // Acessa o primeiro slide
    ISlide slide = pres.Slides[0];
    
    // Adiciona e acessa o Autoshape
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Acessa o quadro de texto do autoshape criado
    ITextFrame text = aShp.AddTextFrame("");
    
    // Limpa o parágrafo padrão
    text.Paragraphs.Clear();

    // Adiciona o primeiro parágrafo
    IParagraph para1 = new Paragraph();
    para1.Text = "Content";
    para1.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para1.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Define o nível do marcador
    para1.ParagraphFormat.Depth = 0;

    // Adiciona o segundo parágrafo
    IParagraph para2 = new Paragraph();
    para2.Text = "Second Level";
    para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para2.ParagraphFormat.Bullet.Char = '-';
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Define o nível do marcador
    para2.ParagraphFormat.Depth = 1;

    // Adiciona o terceiro parágrafo
    IParagraph para3 = new Paragraph();
    para3.Text = "Third Level";
    para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Define o nível do marcador
    para3.ParagraphFormat.Depth = 2;

    // Adiciona o quarto parágrafo
    IParagraph para4 = new Paragraph();
    para4.Text = "Fourth Level";
    para4.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para4.ParagraphFormat.Bullet.Char = '-';
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Define o nível do marcador
    para4.ParagraphFormat.Depth = 3;

    // Adiciona os parágrafos à coleção
    text.Paragraphs.Add(para1);
    text.Paragraphs.Add(para2);
    text.Paragraphs.Add(para3);
    text.Paragraphs.Add(para4);

    // Grava a apresentação como um arquivo PPTX
    pres.Save("MultilevelBullet.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Gerenciar um Parágrafo com uma Lista Numerada Personalizada**

A interface [IBulletFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/ibulletformat/) fornece a propriedade [NumberedBulletStartWith](https://reference.aspose.com/slides/pt/net/aspose.slides/ibulletformat/numberedbulletstartwith) e outras que permitem gerenciar parágrafos com numeração ou formatação personalizada. 

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
2. Acesse o slide que contém o parágrafo.
3. Adicione um [autoshape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/) ao slide.
4. Acesse o [TextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/textframe/) do autoshape.
5. Remova o parágrafo padrão no `TextFrame`.
6. Crie a primeira instância de parágrafo através da classe [Paragraph](https://reference.aspose.com/slides/pt/net/aspose.slides/paragraph/) e defina [NumberedBulletStartWith](https://reference.aspose.com/slides/pt/net/aspose.slides/ibulletformat/numberedbulletstartwith) como 2.
7. Crie a segunda instância de parágrafo através da classe `Paragraph` e defina `NumberedBulletStartWith` como 3.
8. Crie a terceira instância de parágrafo através da classe `Paragraph` e defina `NumberedBulletStartWith` como 7.
9. Adicione os novos parágrafos à coleção de parágrafos do `TextFrame`.
10. Salve a apresentação modificada.

```c#
using (var presentation = new Presentation())
{
	var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

	// Acessa o quadro de texto do autoshape criado
	ITextFrame textFrame = shape.TextFrame;

	// Remove o parágrafo padrão existente
	textFrame.Paragraphs.RemoveAt(0);

	// Primeira lista
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

## **Definir Recuo da Primeira Linha para um Parágrafo**

Use a propriedade [IParagraphFormat.Indent](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraphformat/indent/) para controlar o recuo da primeira linha de um parágrafo. Essa propriedade desloca apenas a primeira linha em relação à margem esquerda do parágrafo. Um valor positivo desloca a primeira linha para a direita, enquanto as linhas restantes permanecem alinhadas ao corpo do parágrafo.

Use [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraphformat/marginleft/) quando precisar mover o parágrafo inteiro. Use [IParagraphFormat.Indent](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraphformat/indent/) quando precisar mover apenas a primeira linha.

O exemplo abaixo cria vários parágrafos e aplica diferentes valores de `Indent` para demonstrar como o recuo da primeira linha afeta o layout do parágrafo.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/).
2. Acesse o slide de destino.
3. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/autoshape/) retangular ao slide.
4. Adicione um [TextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/textframe/) vazio à forma e remova o parágrafo padrão.
5. Crie vários parágrafos e defina diferentes valores de [Indent](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraphformat/indent/) para eles.
6. Adicione os parágrafos ao quadro de texto.
7. Salve a apresentação modificada.

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

O resultado:

![O recuo da primeira linha dos parágrafos](first_line_indent.png)

## **Definir Recuo Suspenso para um Parágrafo**

Um recuo suspenso é um layout de parágrafo em que a primeira linha começa à esquerda das linhas restantes. No Aspose.Slides, você cria esse efeito com a propriedade [IParagraphFormat.Indent](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraphformat/indent/). Defina `Indent` como um valor negativo para mover a primeira linha para a esquerda em relação ao corpo do parágrafo.

Na prática, [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraphformat/marginleft/) define a posição esquerda do corpo do parágrafo, e [IParagraphFormat.Indent](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraphformat/indent/) define a posição da primeira linha em relação a essa margem. Para criar um recuo suspenso, defina um valor positivo para `MarginLeft` e um valor negativo para `Indent`.

Essa formatação é útil para bibliografias, referências, entradas de glossário e outros parágrafos onde as linhas dobradas devem alinhar-se sob o corpo do parágrafo e não sob o primeiro caractere da primeira linha.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/).
2. Acesse o slide de destino.
3. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/autoshape/) retangular ao slide.
4. Adicione um [TextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/textframe/) vazio à forma e remova o parágrafo padrão.
5. Crie parágrafos e defina um valor positivo de [MarginLeft](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraphformat/marginleft/) para cada parágrafo.
6. Defina um valor negativo de [Indent](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraphformat/indent/) para criar o efeito de recuo suspenso.
7. Adicione os parágrafos ao quadro de texto.
8. Salve a apresentação modificada.

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

O resultado:

![O recuo suspenso dos parágrafos](hanging_indent.png)

## **Gerenciar Propriedades de Execução ao Final do Parágrafo**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation) .
1. Obtenha a referência do slide que contém o parágrafo através de sua posição.
1. Adicione um [autoshape](https://reference.aspose.com/slides/pt/net/aspose.slides/autoshape/) retangular ao slide.
1. Adicione um [TextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/textframe/) com dois parágrafos ao retângulo.
1. Defina o `FontHeight` e o tipo de fonte para os parágrafos.
1. Defina as propriedades End para os parágrafos.
1. Grave a apresentação modificada como um arquivo PPTX.

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

## **Importar Texto HTML em Parágrafos**

Aspose.Slides fornece suporte aprimorado para importar texto HTML em parágrafos.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
2. Acesse a referência do slide relevante por meio de seu índice.
3. Adicione um [autoshape](https://reference.aspose.com/slides/pt/net/aspose.slides/autoshape/) ao slide.
4. Adicione e acesse o [ITextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/) do `autoshape`.
5. Remova o parágrafo padrão no `ITextFrame`.
6. Leia o arquivo HTML de origem em um TextReader.
7. Crie a primeira instância de parágrafo usando a classe [Paragraph](https://reference.aspose.com/slides/pt/net/aspose.slides/paragraph/).
8. Adicione o conteúdo do arquivo HTML lido pelo TextReader à [ParagraphCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/paragraphcollection/) do TextFrame.
9. Salve a apresentação modificada.

```c#
// Cria uma instância vazia de apresentação
using (Presentation pres = new Presentation())
{
    // Acessa o primeiro slide padrão da apresentação
    ISlide slide = pres.Slides[0];

    // Adiciona o AutoShape para conter o conteúdo HTML
    IAutoShape ashape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, pres.SlideSize.Size.Width - 20, pres.SlideSize.Size.Height - 10);

    ashape.FillFormat.FillType = FillType.NoFill;

    // Adiciona quadro de texto à forma
    ashape.AddTextFrame("");

    // Limpa todos os parágrafos no quadro de texto adicionado
    ashape.TextFrame.Paragraphs.Clear();

    // Carrega o arquivo HTML usando StreamReader
    TextReader tr = new StreamReader("file.html");

    // Adiciona o texto do StreamReader de HTML ao quadro de texto
    ashape.TextFrame.Paragraphs.AddFromHtml(tr.ReadToEnd());

    // Salva a apresentação
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Exportar Texto de Parágrafo para HTML**

Aspose.Slides fornece suporte aprimorado para exportar textos (contidos em parágrafos) para HTML.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation) e carregue a apresentação desejada.
2. Acesse a referência do slide relevante por meio de seu índice.
3. Acesse a forma que contém o texto que será exportado para HTML.
4. Acesse o [TextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/textframe/) da forma.
5. Crie uma instância de `StreamWriter` e adicione o novo arquivo HTML.
6. Forneça um índice inicial ao StreamWriter e exporte os parágrafos desejados.

```c#
// Carrega o arquivo de apresentação
using (Presentation pres = new Presentation("ExportingHTMLText.pptx"))
{

    // Acessa o primeiro slide padrão da apresentação
    ISlide slide = pres.Slides[0];

    // Acessa o índice requerido
    int index = 0;

    // Acessa a forma adicionada
    IAutoShape ashape = (IAutoShape)slide.Shapes[index];

    StreamWriter sw = new StreamWriter("output_out.html", false, Encoding.UTF8);

    // Grava os dados dos parágrafos em HTML especificando o índice inicial do parágrafo e a quantidade de parágrafos a serem copiados
    sw.Write(ashape.TextFrame.Paragraphs.ExportToHtml(0, ashape.TextFrame.Paragraphs.Count, null));

    sw.Close();
}
```

## **Salvar um Parágrafo como Imagem**

Nesta seção, exploraremos dois exemplos que demonstram como salvar um parágrafo de texto, representado pela interface [IParagraph](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraph/), como uma imagem. Ambos os exemplos incluem obter a imagem de uma forma que contém o parágrafo usando os métodos `GetImage` da interface [IShape](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/), calcular os limites do parágrafo dentro da forma e exportá‑lo como uma imagem bitmap. Essas abordagens permitem extrair partes específicas do texto de apresentações PowerPoint e salvá‑las como imagens separadas, o que pode ser útil em diversos cenários.

Vamos supor que temos um arquivo de apresentação chamado sample.pptx com um slide, onde a primeira forma é uma caixa de texto contendo três parágrafos.

![A caixa de texto com três parágrafos](paragraph_to_image_input.png)

**Exemplo 1**

Neste exemplo, obtemos o segundo parágrafo como imagem. Para isso, extraímos a imagem da forma do primeiro slide da apresentação e então calculamos os limites do segundo parágrafo no quadro de texto da forma. O parágrafo é então redesenhado em uma nova imagem bitmap, que é salva no formato PNG. Esse método é especialmente útil quando você precisa salvar um parágrafo específico como imagem separada, preservando as dimensões e a formatação exatas do texto.

```csharp
using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// Salva a forma na memória como um bitmap.
using var shapeImage = firstShape.GetImage();
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// Cria um bitmap da forma a partir da memória.
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// Calcula os limites do segundo parágrafo.
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();

// Calcula o tamanho da imagem de saída (tamanho mínimo - 1x1 pixel).
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// Prepara um bitmap para o parágrafo.
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// Redesenha o parágrafo do bitmap da forma para o bitmap do parágrafo.
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```

O resultado:

![A imagem do parágrafo](paragraph_to_image_output.png)

**Exemplo 2**

Neste exemplo, ampliamos a abordagem anterior acrescentando fatores de escala à imagem do parágrafo. A forma é extraída da apresentação e salva como imagem com um fator de escala de `2`. Isso permite uma saída de maior resolução ao exportar o parágrafo. Os limites do parágrafo são então calculados considerando a escala. A escala pode ser particularmente útil quando é necessária uma imagem mais detalhada, por exemplo, para uso em materiais impressos de alta qualidade.

```csharp
var imageScaleX = 2f;
var imageScaleY = imageScaleX;

using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// Salva a forma na memória como um bitmap com escala.
using var shapeImage = firstShape.GetImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// Cria um bitmap da forma a partir da memória.
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// Calcula os limites do segundo parágrafo.
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();
paragraphRectangle.X *= imageScaleX;
paragraphRectangle.Y *= imageScaleY;
paragraphRectangle.Width *= imageScaleX;
paragraphRectangle.Height *= imageScaleY;

// Calcula o tamanho da imagem de saída (tamanho mínimo - 1x1 pixel).
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// Prepara um bitmap para o parágrafo.
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// Redesenha o parágrafo do bitmap da forma para o bitmap do parágrafo.
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```

## **FAQ**

**Posso desativar completamente a quebra de linha dentro de um quadro de texto?**

Sim. Use a configuração de quebra de linha do quadro de texto ([WrapText](https://reference.aspose.com/slides/pt/net/aspose.slides/textframeformat/wraptext/)) para desligar a quebra, de modo que as linhas não se dividam nas bordas do quadro.

**Como posso obter os limites exatos na lâmina de um parágrafo específico?**

Você pode recuperar o retângulo delimitador do parágrafo (e até mesmo de um único trecho) para saber sua posição e tamanho precisos na lâmina.

**Onde é controlado o alinhamento do parágrafo (esquerda/direita/centralizado/justificado)?**

[Alignment](https://reference.aspose.com/slides/pt/net/aspose.slides/paragraphformat/alignment/) é uma configuração ao nível do parágrafo em [ParagraphFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/paragraphformat/); ele se aplica a todo o parágrafo independentemente da formatação de trechos individuais.

**Posso definir um idioma de verificação ortográfica apenas para parte de um parágrafo (por exemplo, uma palavra)?**

Sim. O idioma é definido ao nível do trecho ([PortionFormat.LanguageId](https://reference.aspose.com/slides/pt/net/aspose.slides/baseportionformat/languageid/)), permitindo que múltiplos idiomas coexistam dentro de um único parágrafo.