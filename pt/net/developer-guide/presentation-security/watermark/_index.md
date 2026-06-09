---
title: Adicionar marcas d'água a apresentações em .NET
linktitle: Marca d'água
type: docs
weight: 40
url: /pt/net/watermark/
keywords:
- marca d'água
- marca d'água de texto
- marca d'água de imagem
- adicionar marca d'água
- alterar marca d'água
- remover marca d'água
- excluir marca d'água
- adicionar marca d'água ao PPT
- adicionar marca d'água ao PPTX
- adicionar marca d'água ao ODP
- remover marca d'água do PPT
- remover marca d'água do PPTX
- remover marca d'água do ODP
- excluir marca d'água do PPT
- excluir marca d'água do PPTX
- excluir marca d'água do ODP
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Gerencie marcas d'água de texto e imagem em apresentações PowerPoint e OpenDocument no .NET para indicar rascunho, informações confidenciais, direitos autorais e muito mais."
---
## **Introdução**

**Uma marca d'água** em uma apresentação é um selo de texto ou imagem usado em um slide ou em todas as slides da apresentação. Normalmente, uma marca d'água é usada para indicar que a apresentação é um rascunho (por exemplo, uma marca d'água “Draft”), que contém informações confidenciais (por exemplo, uma marca d'água “Confidential”), para especificar a que empresa pertence (por exemplo, uma marca d'água “Company Name”), para identificar o autor da apresentação, etc. Uma marca d'água ajuda a evitar violações de direitos autorais ao indicar que a apresentação não deve ser copiada. As marcas d'água são usadas nos formatos de apresentação PowerPoint e OpenDocument. No Aspose.Slides, você pode adicionar uma marca d'água aos formatos de arquivo PowerPoint PPT, PPTX e OpenDocument ODP.

No [**Aspose.Slides**](https://products.aspose.com/slides/pt/net/), há várias maneiras de criar marcas d'água em documentos PowerPoint ou OpenDocument e modificar seu design e comportamento. O aspecto comum é que, para adicionar marcas d'água de texto, você deve usar a interface [ITextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/), e para adicionar marcas d'água de imagem, use a classe [PictureFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/pictureframe/) ou preencha uma forma de marca d'água com uma imagem. `PictureFrame` implementa a interface [IShape](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape), permitindo que você use todas as configurações flexíveis do objeto de forma. Como `ITextFrame` não é uma forma e suas configurações são limitadas, ele é encapsulado em um objeto [IShape](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape).

Existem duas maneiras de aplicar uma marca d'água: a um único slide ou a todos os slides da apresentação. O Slide Master é usado para aplicar uma marca d'água a todos os slides — a marca d'água é adicionada ao Slide Master, totalmente projetada lá, e aplicada a todos os slides sem afetar a permissão de modificar a marca d'água em slides individuais.

Uma marca d'água geralmente é considerada indisponível para edição por outros usuários. Para impedir que a marca d'água (ou melhor, a forma pai da marca d'água) seja editada, o Aspose.Slides fornece funcionalidade de bloqueio de forma. Uma forma específica pode ser bloqueada em um slide normal ou em um Slide Master. Quando a forma da marca d'água é bloqueada no Slide Master, ela será bloqueada em todos os slides da apresentação.

Você pode definir um nome para a marca d'água para que, no futuro, se quiser excluí‑la, possa encontrá‑la nas formas do slide pelo nome.

Você pode criar a marca d'água de qualquer forma; no entanto, geralmente há recursos comuns em marcas d'água, como alinhamento central, rotação, posição em frente, etc. Consideraremos como usar esses recursos nos exemplos abaixo.

## **Marca d'água de Texto**

### **Adicionar uma Marca d'água de Texto a um Slide**

Para adicionar uma marca d'água de texto em PPT, PPTX ou ODP, você pode primeiro adicionar uma forma ao slide e, em seguida, acrescentar um quadro de texto a essa forma. O quadro de texto é representado pela interface [ITextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe). Esse tipo não herda de [IShape](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/), que possui um amplo conjunto de propriedades para posicionar a marca d'água de forma flexível. Portanto, o objeto [ITextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe) é encapsulado em um objeto [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/). Para adicionar texto de marca d'água à forma, use o método [AddTextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/methods/addtextframe) como mostrado abaixo.

```cs
string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// Adicione a marca d'água ao slide.
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="primary" title="Veja também" %}} 
- [Como usar a classe TextFrame?](/slides/pt/net/text-formatting/)
{{% /alert %}}

### **Adicionar uma Marca d'água de Texto a uma Apresentação**

Se você deseja adicionar uma marca d'água de texto a toda a apresentação (ou seja, a todos os slides de uma vez), adicione‑a ao [MasterSlide](https://reference.aspose.com/slides/pt/net/aspose.slides/masterslide/). O resto da lógica é o mesmo de quando se adiciona uma marca d'água a um único slide — crie um objeto [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/) e então adicione a marca d'água a ele usando o método [AddTextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/methods/addtextframe).

```cs
string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.Masters[0];

// Adicione a marca d'água ao slide mestre.
IAutoShape watermarkShape = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="primary" title="Veja também" %}} 
- [Como usar o Slide Master?](/slides/pt/net/slide-master/)
{{% /alert %}}

### **Definir a Transparência da Forma da Marca d'água**

Por padrão, a forma retangular possui preenchimento e cores de linha. Isso significa que, ao ser adicionada, a marca d'água pode aparecer com um fundo sólido ou borda que podem distrair o conteúdo do slide. Para garantir que a marca d'água permaneça sutil e não interfira no design visual da apresentação, você pode tornar a forma completamente transparente.

As linhas de código a seguir tornam a forma transparente removendo tanto seu preenchimento quanto as cores da borda:

```cs
watermarkShape.FillFormat.FillType = FillType.NoFill;
watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;
```

### **Definir a Fonte para uma Marca d'água de Texto**

Antes de aplicar a marca d'água de texto ao seu slide, é importante personalizar sua aparência para que harmonize com o design geral. Você pode alterar o tipo e o tamanho da fonte para garantir que a marca d'água seja legível e esteticamente agradável. Personalizar a fonte também pode ajudar a reforçar a identidade da marca ou simplesmente combinar com o estilo da apresentação.

O trecho de código abaixo demonstra como ajustar as configurações de fonte da marca d'água selecionando uma fonte latina específica e definindo uma altura de fonte apropriada:

```cs
IPortionFormat textFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
textFormat.LatinFont = new FontData("Arial");
textFormat.FontHeight = 50;
```

### **Definir a Cor do Texto da Marca d'água**

Antes de aplicar sua marca d'água, é essencial garantir que a cor do texto esteja configurada adequadamente para que se misture bem com o conteúdo do slide sem sobrecarregá‑lo. Ajustar a transparência da cor (alfa) juntamente com os componentes vermelho, verde e azul permite criar uma marca d'água sutil e semitransparente que é visível porém discreta. Essa abordagem ajuda a manter o foco na apresentação principal ao mesmo tempo que protege seu conteúdo.

Para definir a cor do texto da marca d'água, use o código a seguir:

```cs
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat;
fillFormat.FillType = FillType.Solid;
fillFormat.SolidFillColor.Color = Color.FromArgb(alpha, red, green, blue);
```

### **Centralizar uma Marca d'água de Texto**

Centralizar adequadamente sua marca d'água de texto pode melhorar significativamente a estética geral da sua apresentação ao garantir que a marca d'água esteja posicionada simetricamente, independentemente das dimensões do slide. Essa abordagem não só confere um aspecto profissional aos slides, como também garante que a marca d'água não interfira no conteúdo principal do slide.

O trecho de código abaixo demonstra como calcular a posição central de um slide e posicionar a marca d'água de texto de acordo:

```cs
SizeF slideSize = presentation.SlideSize.Size;

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = (slideSize.Width - watermarkWidth) / 2;
float watermarkY = (slideSize.Height - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.Shapes.AddAutoShape(
    ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

A imagem abaixo mostra o resultado final.

![A marca d'água de texto](text_watermark.png)

## **Marca d'água de Imagem**

### **Adicionar uma Marca d'água de Imagem a uma Apresentação**

Em muitos casos, uma marca d'água de imagem pode fornecer um elemento de marca exclusivo ou uma alternativa visualmente mais atraente a uma marca d'água de texto. Antes de adicionar a marca d'água, certifique‑se de que o arquivo de imagem esteja disponível (por exemplo, PNG para transparência). O exemplo a seguir demonstra como carregar uma imagem do seu sistema de arquivos, adicioná‑la à apresentação e então aplicá‑la como marca d'água usando as propriedades de preenchimento da forma.

```cs
using FileStream imageStream = File.OpenRead("watermark.png");
IPPImage image = presentation.Images.AddImage(imageStream);

watermarkShape.FillFormat.FillType = FillType.Picture;
watermarkShape.FillFormat.PictureFillFormat.Picture.Image = image;
watermarkShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
```

## **Bloquear uma Marca d'água contra Edição**

Se for necessário impedir que uma marca d'água seja editada, use a propriedade [IAutoShape.ShapeLock](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/properties/shapelock) na forma. Com essa propriedade, você pode proteger a forma contra seleção, redimensionamento, reposicionamento, agrupamento com outros elementos, bloquear seu texto contra edição e muito mais:

```cs
// Bloqueie a forma da marca d'água contra modificações.
watermarkShape.ShapeLock.SelectLocked = true;
watermarkShape.ShapeLock.SizeLocked = true;
watermarkShape.ShapeLock.TextLocked = true;
watermarkShape.ShapeLock.PositionLocked = true;
watermarkShape.ShapeLock.GroupingLocked = true;
```

## **Trazer uma Marca d'água para a Frente**

No Aspose.Slides, a ordem Z das formas pode ser definida via o método [IShapeCollection.Reorder](https://reference.aspose.com/slides/pt/net/aspose.slides/ishapecollection/reorder/#reorder). Para isso, você precisa chamar esse método a partir da lista de slides da apresentação e passar a referência da forma e seu número de ordem para o método. Dessa forma, é possível trazer uma forma para a frente ou enviá‑la para o fundo do slide. Esse recurso é especialmente útil se precisar colocar uma marca d'água na frente da apresentação:

```cs
int shapeCount = slide.Shapes.Count;
slide.Shapes.Reorder(shapeCount - 1, watermarkShape);
```

## **Definir a Rotação da Marca d'água**

Ajustar a rotação da sua marca d'água pode melhorar significativamente o impacto visual e a sutileza da sua apresentação. Uma marca d'água diagonal, por exemplo, pode ser menos invasiva ao mesmo tempo que fornece proteção robusta contra uso não autorizado. O exemplo a seguir calcula o ângulo adequado com base nas dimensões do slide para que a marca d'água seja posicionada diagonalmente no slide. Esse cálculo dinâmico garante que a marca d'água permaneça eficaz independentemente do tamanho dos slides.

```cs
double diagonalAngle = Math.Atan((slideSize.Height / slideSize.Width)) * 180 / Math.PI;

watermarkShape.Rotation = (float)diagonalAngle;
```

## **Definir um Nome para uma Marca d'água**

O Aspose.Slides permite definir o nome de uma forma. Ao usar o nome da forma, você pode acessá‑la no futuro para modificá‑la ou excluí‑la. Para definir o nome da forma da marca d'água, atribua‑o à propriedade [IAutoShape.Name](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/properties/name):

```cs
watermarkShape.Name = "watermark";
```

## **Remover uma Marca d'água**

Para remover a forma da marca d'água, use a propriedade [IAutoShape.Name](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/properties/name) para encontrá‑la nas formas do slide. Em seguida, passe a forma da marca d'água para o método [IShapeCollection.Remove](https://reference.aspose.com/slides/pt/net/aspose.slides/ishapecollection/remove/):

```cs
List<IShape> slideShapes = slide.Shapes.ToList();
foreach (IShape shape in slideShapes)
{
    if (string.Compare(shape.Name, "watermark", StringComparison.Ordinal) == 0)
    {
        slide.Shapes.Remove(watermarkShape);
    }
}
```

## **Um Exemplo ao Vivo**

Talvez você queira conferir as ferramentas online **Aspose.Slides free** [Adicionar Marca d'água](https://products.aspose.app/slides/pt/watermark) e [Remover Marca d'água](https://products.aspose.app/slides/pt/watermark/remove-watermark).

![Ferramentas online para adicionar e remover marcas d'água](online_tools.png)

## **FAQ**

**O que é uma marca d'água e por que devo usá‑la?**

Uma marca d'água é uma sobreposição de texto ou imagem aplicada aos slides que ajuda a proteger a propriedade intelectual, aprimorar o reconhecimento da marca ou impedir o uso não autorizado de apresentações.

**Posso adicionar uma marca d'água a todos os slides de uma apresentação?**

Sim, o Aspose.Slides permite adicionar programaticamente uma marca d'água a cada slide de uma apresentação. Você pode percorrer todos os slides e aplicar as configurações da marca d'água individualmente.

**Como posso ajustar a transparência da marca d'água?**

Você pode ajustar a transparência da marca d'água modificando as configurações de preenchimento ([FillFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/shape/fillformat/)) da forma. Isso garante que a marca d'água seja sutil e não distraia do conteúdo do slide.

**Quais formatos de imagem são suportados para marcas d'água?**

O Aspose.Slides suporta vários formatos de imagem, como PNG, JPEG, GIF, BMP, SVG e outros.

**Posso personalizar a fonte e o estilo de uma marca d'água de texto?**

Sim, você pode escolher qualquer fonte, tamanho e estilo para combinar com o design da sua apresentação e manter a consistência da marca.

**Como altero a posição ou orientação de uma marca d'água?**

Você pode ajustar a posição e a orientação da marca d'água programaticamente modificando as coordenadas, o tamanho e as propriedades de rotação da forma.