---
title: "Adicionar Marcas d'água a Apresentações em .NET"
linktitle: "Marca d'água"
type: docs
weight: 40
url: /pt/net/watermark/
keywords:
- "marca d'água"
- "marca d'água de texto"
- "marca d'água de imagem"
- "adicionar marca d'água"
- "alterar marca d'água"
- "remover marca d'água"
- "excluir marca d'água"
- "adicionar marca d'água ao PPT"
- "adicionar marca d'água ao PPTX"
- "adicionar marca d'água ao ODP"
- "remover marca d'água do PPT"
- "remover marca d'água do PPTX"
- "remover marca d'água do ODP"
- "excluir marca d'água do PPT"
- "excluir marca d'água do PPTX"
- "excluir marca d'água do ODP"
- "PowerPoint"
- "OpenDocument"
- "apresentação"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Gerencie marcas d'água de texto e imagem em apresentações PowerPoint e OpenDocument no .NET para indicar um rascunho, informações confidenciais, direitos autorais e muito mais."
---
## **Introdução**

**Uma marca d'água** em uma apresentação é um selo de texto ou imagem usado em um slide ou em todas as slides da apresentação. Normalmente, uma marca d'água é usada para indicar que a apresentação é um rascunho (por exemplo, uma marca d'água "Draft"), que contém informações confidenciais (por exemplo, uma marca d'água "Confidential"), para especificar a qual empresa ela pertence (por exemplo, uma marca d'água "Company Name"), para identificar o autor da apresentação, etc. Uma marca d'água ajuda a impedir violações de direitos autorais ao indicar que a apresentação não deve ser copiada. Marcas d'água são usadas nos formatos de apresentação PowerPoint e OpenDocument. No Aspose.Slides, você pode adicionar uma marca d'água aos formatos de arquivo PowerPoint PPT, PPTX e OpenDocument ODP.

No [**Aspose.Slides**](https://products.aspose.com/slides/pt/net/), há várias maneiras de criar marcas d'água em documentos PowerPoint ou OpenDocument e modificar seu design e comportamento. O aspecto comum é que, para adicionar marcas d'água de texto, você deve usar a interface [ITextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/), e, para adicionar marcas d'água de imagem, use a classe [PictureFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/pictureframe/) ou preencha uma forma de marca d'água com uma imagem. `PictureFrame` implementa a interface [IShape](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape) , permitindo usar todas as configurações flexíveis do objeto shape. Como `ITextFrame` não é uma shape e suas configurações são limitadas, ele é encapsulado em um objeto [IShape](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape).

Existem duas formas de aplicar uma marca d'água: a um único slide ou a todas as slides da apresentação. O Slide Master é usado para aplicar uma marca d'água a todas as slides — a marca d'água é adicionada ao Slide Master, totalmente projetada lá, e aplicada a todas as slides sem afetar a permissão de modificar a marca d'água em slides individuais.

Uma marca d'água geralmente é considerada indisponível para edição por outros usuários. Para impedir que a marca d'água (ou melhor, a shape pai da marca d'água) seja editada, o Aspose.Slides fornece funcionalidade de bloqueio de shapes. Uma shape específica pode ser bloqueada em um slide normal ou no Slide Master. Quando a shape da marca d'água está bloqueada no Slide Master, ela será bloqueada em todas as slides da apresentação.

Você pode definir um nome para a marca d'água para que, no futuro, se quiser excluí‑la, possa encontrá‑la nas shapes do slide pelo nome.

Você pode projetar a marca d'água de qualquer forma; porém, geralmente há recursos comuns em marcas d'água, como alinhamento central, rotação, posição em frente, etc. Consideraremos como usar esses recursos nos exemplos abaixo.

## **Marca d'água de Texto**

### **Adicionar uma Marca d'água de Texto a um Slide**

Para adicionar uma marca d'água de texto em PPT, PPTX ou ODP, você pode primeiro adicionar uma shape ao slide e, em seguida, adicionar um quadro de texto a essa shape. O quadro de texto é representado pela interface [ITextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe). Esse tipo não herda de [IShape](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/), que possui um amplo conjunto de propriedades para posicionar a marca d'água de forma flexível. Portanto, o objeto [ITextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe) é encapsulado em um objeto [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/) . Para adicionar texto de marca d'água à shape, use o método [AddTextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/methods/addtextframe) conforme mostrado abaixo.

```cs
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// Adicionar a marca d'água ao slide.
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="info" title="Veja também" %}} 
- [Como usar a classe TextFrame?](/slides/pt/net/text-formatting/)
{{% /alert %}}

### **Adicionar uma Marca d'água de Texto a uma Apresentação**

Se quiser adicionar uma marca d'água de texto a toda a apresentação (ou seja, a todas as slides de uma só vez), adicione‑a ao [MasterSlide](https://reference.aspose.com/slides/pt/net/aspose.slides/masterslide/). O restante da lógica é o mesmo de quando se adiciona uma marca d'água a um único slide — crie um objeto [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/) e, em seguida, adicione a marca d'água a ele usando o método [AddTextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/methods/addtextframe).

```cs
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.Masters[0];

// Adicionar a marca d'água ao slide mestre.
IAutoShape watermarkShape = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="info" title="Veja também" %}} 
- [Como usar o Slide Master?](/slides/pt/net/slide-master/)
{{% /alert %}}

### **Definir a Transparência da Forma da Marca d'água**

Por padrão, a forma retangular é estilizada com cores de preenchimento e linha. Isso significa que, quando a marca d'água é adicionada, ela pode aparecer com um fundo sólido ou borda que podem distrair do conteúdo do slide. Para garantir que a marca d'água permaneça sutil e não interfira no design visual da apresentação, você pode tornar a forma completamente transparente.

As linhas de código a seguir tornam a forma transparente removendo tanto a cor de preenchimento quanto a cor da borda:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.FillFormat.FillType = FillType.NoFill;
watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;
```

### **Definir a Fonte para uma Marca d'água de Texto**

Antes de aplicar a marca d'água de texto ao seu slide, é importante personalizar sua aparência para que harmonize com o design geral. Você pode alterar o tipo e o tamanho da fonte para garantir que a marca d'água seja legível e esteticamente agradável. Personalizar a fonte também pode ajudar a reforçar a identidade da marca ou simplesmente combinar com o estilo da apresentação.

O trecho de código abaixo demonstra como ajustar as configurações de fonte da marca d'água selecionando uma fonte latina específica e definindo uma altura de fonte apropriada:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame("CONFIDENTIAL");

IPortionFormat textFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
textFormat.LatinFont = new FontData("Arial");
textFormat.FontHeight = 50;
```

### **Definir a Cor do Texto da Marca d'água**

Antes de aplicar sua marca d'água, é essencial garantir que a cor do texto esteja definida adequadamente para que se integre bem ao conteúdo do slide sem sobrepujá‑lo. Ajustar a transparência da cor (alfa) juntamente com os componentes vermelho, verde e azul permite criar uma marca d'água sutil, semitransparente, que é visível porém discreta. Essa abordagem ajuda a manter o foco na sua apresentação principal enquanto ainda protege seu conteúdo.

Para definir a cor do texto da marca d'água, use o código a seguir:

```cs
using System.Drawing;
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame("CONFIDENTIAL");

int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat;
fillFormat.FillType = FillType.Solid;
fillFormat.SolidFillColor.Color = Color.FromArgb(alpha, red, green, blue);
```

### **Centralizar uma Marca d'água de Texto**

Centralizar corretamente sua marca d'água de texto pode melhorar significativamente a estética geral da apresentação, garantindo que a marca d'água esteja posicionada de forma simétrica, independentemente das dimensões do slide. Essa abordagem confere um aspecto profissional aos slides e assegura que a marca d'água não interfira no conteúdo principal.

O trecho de código abaixo demonstra como calcular a posição central de um slide e colocar a marca d'água de texto de acordo:

```cs
using System.Drawing;
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

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

Em muitos casos, uma marca d'água de imagem pode fornecer um elemento de branding único ou uma alternativa visualmente mais atraente a uma marca d'água de texto. Antes de adicionar a marca d'água, certifique‑se de que o arquivo de imagem esteja prontamente disponível (por exemplo, PNG para transparência). O exemplo a seguir demonstra como carregar uma imagem do sistema de arquivos, adicioná‑la à apresentação e, em seguida, aplicá‑la como marca d'água usando as propriedades de preenchimento da shape.

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

using FileStream imageStream = File.OpenRead("watermark.png");
IPPImage image = presentation.Images.AddImage(imageStream);

watermarkShape.FillFormat.FillType = FillType.Picture;
watermarkShape.FillFormat.PictureFillFormat.Picture.Image = image;
watermarkShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
```

## **Bloquear uma Marca d'água contra Edição**

Se for necessário impedir que uma marca d'água seja editada, use a propriedade [IAutoShape.ShapeLock](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/properties/shapelock) na shape. Com essa propriedade, você pode proteger a shape contra seleção, redimensionamento, reposicionamento, agrupamento com outros elementos, bloquear seu texto contra edição e muito mais:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

// Bloquear a shape da marca d'água contra modificações.
watermarkShape.ShapeLock.SelectLocked = true;
watermarkShape.ShapeLock.SizeLocked = true;
watermarkShape.ShapeLock.TextLocked = true;
watermarkShape.ShapeLock.PositionLocked = true;
watermarkShape.ShapeLock.GroupingLocked = true;
```

## **Trazer uma Marca d'água para a Frente**

No Aspose.Slides, a ordem Z das shapes pode ser definida via método [IShapeCollection.Reorder](https://reference.aspose.com/slides/pt/net/aspose.slides/ishapecollection/reorder/#reorder). Para isso, chame esse método na lista de slides da apresentação e passe a referência da shape e seu número de ordem ao método. Dessa forma, é possível trazer uma shape para a frente ou enviá‑la para o fundo do slide. Esse recurso é especialmente útil se precisar posicionar a marca d'água na frente da apresentação:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

int shapeCount = slide.Shapes.Count;
slide.Shapes.Reorder(shapeCount - 1, watermarkShape);
```

## **Definir rotação da Marca d'água**

Ajustar a rotação da sua marca d'água pode melhorar significativamente o impacto visual e a sutileza da apresentação. Uma marca d'água diagonal, por exemplo, pode ser menos intrusiva enquanto ainda oferece proteção robusta contra uso não autorizado. O exemplo a seguir calcula o ângulo apropriado com base nas dimensões do slide, de modo que a marca d'água fique posicionada diagonalmente ao longo do slide. Esse cálculo dinâmico garante que a marca d'água permaneça eficaz independentemente do tamanho das slides.

```cs
using System.Drawing;
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

SizeF slideSize = presentation.SlideSize.Size;

double diagonalAngle = Math.Atan((slideSize.Height / slideSize.Width)) * 180 / Math.PI;

watermarkShape.Rotation = (float)diagonalAngle;
```

## **Definir um Nome para uma Marca d'água**

O Aspose.Slides permite definir o nome de uma shape. Ao usar o nome da shape, você pode acessá‑la no futuro para modificá‑la ou excluí‑la. Para definir o nome da shape da marca d'água, atribua‑o à propriedade [IAutoShape.Name](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/properties/name):

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.Name = "watermark";
```

## **Remover uma Marca d'água**

Para remover a shape da marca d'água, use a propriedade [IAutoShape.Name](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/properties/name) para encontrá‑la nas shapes do slide. Em seguida, passe a shape da marca d'água ao método [IShapeCollection.Remove](https://reference.aspose.com/slides/pt/net/aspose.slides/ishapecollection/remove/) :

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

List<IShape> slideShapes = slide.Shapes.ToList();
foreach (IShape shape in slideShapes)
{
    if (string.Compare(shape.Name, "watermark", StringComparison.Ordinal) == 0)
    {
        slide.Shapes.Remove(shape);
    }
}
```

## **Um Exemplo ao Vivo**

Talvez você queira experimentar as ferramentas online gratuitas do **Aspose.Slides** [Adicionar Marca d'água](https://products.aspose.app/slides/pt/watermark) e [Remover Marca d'água](https://products.aspose.app/slides/pt/watermark/remove-watermark).

![Ferramentas online para adicionar e remover marcas d'água](online_tools.png)

## **Perguntas Frequentes**

### O que é uma marca d'água e por que devo usá‑la?

Uma marca d'água é uma sobreposição de texto ou imagem aplicada às slides que ajuda a proteger a propriedade intelectual, melhorar o reconhecimento da marca ou impedir o uso não autorizado de apresentações.

### Posso adicionar uma marca d'água a todas as slides de uma apresentação?

Sim, o Aspose.Slides permite adicionar programaticamente uma marca d'água a cada slide de uma apresentação. Você pode iterar por todas as slides e aplicar as configurações da marca d'água individualmente.

### Como posso ajustar a transparência da marca d'água?

Você pode ajustar a transparência da marca d'água modificando as configurações de preenchimento ([FillFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/shape/fillformat/)) da shape. Isso garante que a marca d'água seja sutil e não distraia do conteúdo da slide.

### Quais formatos de imagem são suportados para marcas d'água?

O Aspose.Slides suporta vários formatos de imagem, como PNG, JPEG, GIF, BMP, SVG e outros.

### Posso personalizar a fonte e o estilo de uma marca d'água de texto?

Sim, você pode escolher qualquer fonte, tamanho e estilo para combinar com o design da sua apresentação e manter a consistência da marca.

### Como altero a posição ou orientação de uma marca d'água?

Você pode ajustar a posição e a orientação da marca d'água programaticamente modificando as coordenadas, tamanho e propriedades de rotação da shape.