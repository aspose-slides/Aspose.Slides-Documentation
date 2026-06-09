---
title: "Adicionar Marcas d'água a Apresentações em Python"
linktitle: "Marca d'água"
type: docs
weight: 40
url: /pt/python-net/watermark/
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
- Python
- Aspose.Slides
description: "Saiba como gerenciar marcas d'água de texto e de imagem em apresentações PowerPoint e OpenDocument usando Python para indicar rascunho, informações confidenciais, direitos autorais e muito mais."
---
## **Introdução**

**Uma marca d'água** em uma apresentação é um selo de texto ou imagem usado em um slide ou em todas as slides da apresentação. Normalmente, uma marca d'água é usada para indicar que a apresentação é um rascunho (por exemplo, uma marca d'água "Draft"), que contém informações confidenciais (por exemplo, uma marca d'água "Confidential"), para especificar a que empresa pertence (por exemplo, uma marca d'água "Company Name"), para identificar o autor da apresentação etc. Uma marca d'água ajuda a impedir violações de direitos autorais ao indicar que a apresentação não deve ser copiada. Marcas d'água são usadas nos formatos de apresentação PowerPoint e OpenOffice. No Aspose.Slides, você pode adicionar uma marca d'água aos formatos de arquivo PowerPoint PPT, PPTX e OpenOffice ODP.

Em [**Aspose.Slides**](https://products.aspose.com/slides/pt/python-net/), há várias maneiras de criar marcas d'água em documentos PowerPoint ou OpenOffice e modificar seu design e comportamento. O aspecto comum é que, para adicionar marcas d'água de texto, você deve usar a classe [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/), e para adicionar marcas d'água de imagem, usar a classe [PictureFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/pictureframe/) ou preencher uma shape de marca d'água com uma imagem. `PictureFrame` implementa a classe [Shape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/), permitindo usar todas as configurações flexíveis do objeto shape. Como `TextFrame` não é uma shape e suas configurações são limitadas, ele é encapsulado em um objeto [Shape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/).

Existem duas formas de aplicar uma marca d'água: a um único slide ou a todas as slides da apresentação. O Slide Master é usado para aplicar uma marca d'água a todas as slides — a marca d'água é adicionada ao Slide Master, totalmente projetada lá, e aplicada a todas as slides sem afetar a permissão de modificar a marca d'água em slides individuais.

Normalmente, uma marca d'água é considerada indisponível para edição por outros usuários. Para impedir que a marca d'água (ou melhor, a shape pai da marca d'água) seja editada, o Aspose.Slides fornece funcionalidade de bloqueio de shape. Uma shape específica pode ser bloqueada em um slide normal ou no Slide Master. Quando a shape da marca d'água está bloqueada no Slide Master, ela será bloqueada em todas as slides da apresentação.

Você pode definir um nome para a marca d'água para que, no futuro, se quiser excluí‑la, possa encontrá‑la nas shapes do slide pelo nome.

Você pode criar a marca d'água de qualquer forma; porém, geralmente há recursos comuns em marcas d'água, como alinhamento central, rotação, posição em frente, etc. Consideraremos como usar esses recursos nos exemplos abaixo.

## **Marca d'água de Texto**

### **Adicionar uma Marca d'água de Texto a um Slide**

Para adicionar uma marca d'água de texto em PPT, PPTX ou ODP, você pode primeiro adicionar uma shape ao slide e, em seguida, adicionar um frame de texto a essa shape. O frame de texto é representado pela classe [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/). Esse tipo não herda de [Shape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/), que possui um amplo conjunto de propriedades para posicionar a marca d'água de forma flexível. Portanto, o objeto [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/) é encapsulado em um objeto [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/). Para adicionar texto de marca d'água à shape, use o método [add_text_frame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/add_text_frame/#str) conforme mostrado abaixo.

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    slide = presentation.slides[0]

    watermark_shape = slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="Veja também" %}} 
- [Como usar a classe TextFrame](/slides/pt/python-net/text-formatting/)
{{% /alert %}}

### **Adicionar uma Marca d'água de Texto a uma Apresentação**

Se você quiser adicionar uma marca d'água de texto a toda a apresentação (ou seja, a todas as slides de uma vez), adicione-a ao [MasterSlide](https://reference.aspose.com/slides/pt/python-net/aspose.slides/masterslide/). O restante da lógica é o mesmo que ao adicionar uma marca d'água a um único slide — crie um objeto [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) e então adicione a marca d'água usando o método [add_text_frame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/add_text_frame/#str).

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    master_slide = presentation.masters[0]

    watermark_shape = master_slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="Veja também" %}} 
- [Como usar o Slide Master](/slides/pt/python-net/slide-master/)
{{% /alert %}}

### **Definir a Transparência da Shape da Marca d'água**

Por padrão, a shape de retângulo é estilizada com cores de preenchimento e linha. As linhas de código a seguir tornam a shape transparente.

```py
watermark_shape.fill_format.fill_type = FillType.NO_FILL
watermark_shape.line_format.fill_format.fill_type = FillType.NO_FILL
```

### **Definir a Fonte para uma Marca d'água de Texto**

Você pode alterar a fonte da marca d'água de texto conforme mostrado abaixo.

```py
text_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format
text_format.latin_font = FontData("Arial")
text_format.font_height = 50
```

### **Definir a Cor do Texto da Marca d'água**

Para definir a cor do texto da marca d'água, use este código:

```py
alpha = 150
red = 200
green = 200
blue = 200

fill_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format.fill_format
fill_format.fill_type = FillType.SOLID
fill_format.solid_fill_color.color = drawing.Color.from_argb(alpha, red, green, blue)
```

### **Centralizar uma Marca d'água de Texto**

É possível centralizar a marca d'água em um slide e, para isso, você pode fazer o seguinte:

```py
slide_size = presentation.slide_size.size

watermark_width = 400
watermark_height = 40
watermark_x = (slide_size.width - watermark_width) / 2
watermark_y = (slide_size.height - watermark_height) / 2

watermark_shape = slide.shapes.add_auto_shape(
    ShapeType.RECTANGLE, watermark_x, watermark_y, watermark_width, watermark_height)

watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

![A marca d'água de texto](text_watermark.png)

## **Marca d'água de Imagem**

### **Adicionar uma Marca d'água de Imagem a uma Apresentação**

Para adicionar uma marca d'água de imagem a um slide de apresentação, você pode fazer o seguinte:

```py
with open("watermark.png", "rb") as image_stream:
    image = presentation.images.add_image(image_stream.read())

    watermark_shape.fill_format.fill_type = FillType.PICTURE
    watermark_shape.fill_format.picture_fill_format.picture.image = image
    watermark_shape.fill_format.picture_fill_format.picture_fill_mode = PictureFillMode.STRETCH
```

## **Bloquear uma Marca d'água da Edição**

Se for necessário impedir que uma marca d'água seja editada, use a propriedade [AutoShape.auto_shape_lock](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/auto_shape_lock/) na shape. Com essa propriedade, você pode proteger a shape de ser selecionada, redimensionada, recolocada, agrupada com outros elementos, bloquear seu texto contra edição e muito mais:

```py
# Bloquear a shape da marca d'água de modificações
watermark_shape.auto_shape_lock.select_locked = True
watermark_shape.auto_shape_lock.size_locked = True
watermark_shape.auto_shape_lock.text_locked = True
watermark_shape.auto_shape_lock.position_locked = True
watermark_shape.auto_shape_lock.grouping_locked = True
```

## **Trazer uma Marca d'água para a Frente**

No Aspose.Slides, a ordem Z das shapes pode ser definida via o método [ShapeCollection.reorder](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ishapecollection/reorder/#int-ishape). Para isso, chame esse método a partir da lista de slides da apresentação e passe a referência da shape e seu número de ordem ao método. Dessa forma, é possível trazer uma shape para a frente ou enviá‑la para trás do slide. Esse recurso é especialmente útil se precisar colocar uma marca d'água na frente da apresentação:

```py
shape_count = len(slide.shapes)
slide.shapes.reorder(shape_count - 1, watermark_shape)
```

## **Definir a Rotação da Marca d'água**

Aqui está um exemplo de código de como ajustar a rotação da marca d'água para que fique posicionada diagonalmente no slide:

```py
diagonal_angle = math.atan(slide_size.height / slide_size.width) * 180 / math.pi

watermark_shape.rotation = float(diagonal_angle)
```

## **Definir um Nome para uma Marca d'água**

Aspose.Slides permite definir o nome de uma shape. Usando o nome da shape, você pode acessá‑la no futuro para modificá‑la ou excluí‑la. Para definir o nome da shape da marca d'água, atribua‑o à propriedade [AutoShape.name](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/name/):

```py
watermark_shape.name = "watermark"
```

## **Remover uma Marca d'água**

Para remover a shape da marca d'água, use o método [AutoShape.name](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/name/) para encontrá‑la nas shapes do slide. Em seguida, passe a shape da marca d'água ao método [ShapeCollection.remove](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shapecollection/remove/#ishape):

```py
slide_shapes = list(slide.shapes)
for shape in slide_shapes:
    if shape.name == "watermark":
        slide.shapes.remove(watermark_shape)
```

## **Um Exemplo ao Vivo**

Você pode querer conferir as ferramentas online **Aspose.Slides free** [Adicionar Marca d'água](https://products.aspose.app/slides/pt/watermark) e [Remover Marca d'água](https://products.aspose.app/slides/pt/watermark/remove-watermark) online.

![Ferramentas online para adicionar e remover marcas d'água](online_tools.png)

## **Perguntas Frequentes**

**O que é uma marca d'água e por que devo usá‑la?**

Uma marca d'água é uma sobreposição de texto ou imagem aplicada aos slides que ajuda a proteger a propriedade intelectual, melhorar o reconhecimento da marca ou impedir o uso não autorizado das apresentações.

**Posso adicionar uma marca d'água a todas as slides de uma apresentação?**

Sim, o Aspose.Slides permite adicionar uma marca d'água a cada slide de uma apresentação. Você pode percorrer todas as slides e aplicar as configurações da marca d'água individualmente.

**Como posso ajustar a transparência da marca d'água?**

Você pode ajustar a transparência da marca d'água modificando as configurações de preenchimento ([FillFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fillformat/)) da shape. Isso garante que a marca d'água seja sutil e não distraia do conteúdo do slide.

**Quais formatos de imagem são suportados para marcas d'água?**

O Aspose.Slides suporta diversos formatos de imagem, como PNG, JPEG, GIF, BMP, SVG e outros.

**Posso personalizar a fonte e o estilo de uma marca d'água de texto?**

Sim, você pode escolher qualquer fonte, tamanho e estilo para combinar com o design da sua apresentação e manter a consistência da marca.

**Como mudar a posição ou orientação de uma marca d'água?**

Você pode ajustar a posição e a orientação da marca d'água modificando as coordenadas, tamanho e propriedades de rotação da [shape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/).