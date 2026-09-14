---
title: Adicionar Marcas d'água a Apresentações em Python
linktitle: Marca d'água
type: docs
weight: 40
url: /pt/python-java/watermark/
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
description: "Gerencie marcas d'água de texto e imagem em apresentações PowerPoint e OpenDocument usando Python para indicar rascunho, informações confidenciais, direitos autorais e muito mais."
---
## **Introdução**

**Uma marca d'água** em uma apresentação é um selo de texto ou imagem usado em um slide ou em todos os slides da apresentação. Normalmente, a marca d'água é usada para indicar que a apresentação é um rascunho (por exemplo, uma marca d'água “Rascunho”), que contém informações confidenciais (por exemplo, uma marca d'água “Confidencial”), para especificar a que empresa pertence (por exemplo, uma marca d'água “Nome da Empresa”), para identificar o autor da apresentação etc. A marca d'água ajuda a prevenir violações de direitos autorais ao indicar que a apresentação não deve ser copiada. As marcas d'água são usadas nos formatos de apresentação PowerPoint e OpenOffice. No Aspose.Slides, você pode adicionar uma marca d'água aos formatos de arquivo PowerPoint PPT, PPTX e OpenOffice ODP.

No [**Aspose.Slides**](https://products.aspose.com/slides/pt/python-java/), existem várias maneiras de criar marcas d'água em documentos PowerPoint ou OpenOffice e modificar seu design e comportamento. O aspecto comum é que, para adicionar marcas d'água de texto, você deve usar a classe [TextFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframe/), e, para adicionar marcas d'água de imagem, usar a classe [PictureFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/pictureframe/) ou preencher uma forma de marca d'água com uma imagem. [PictureFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/pictureframe/) herda da classe [Shape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/), permitindo que você use todas as configurações flexíveis do objeto shape. Como [TextFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframe/) não é uma shape e suas configurações são limitadas, ele é encapsulado em um objeto [Shape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/).

Existem duas maneiras de aplicar uma marca d'água: a um único slide ou a todos os slides da apresentação. O Slide Master é usado para aplicar uma marca d'água a todos os slides — a marca d'água é adicionada ao Slide Master, totalmente projetada lá, e aplicada a todos os slides sem afetar a permissão de modificar a marca d'água em slides individuais.

Uma marca d'água costuma ser considerada indisponível para edição por outros usuários. Para impedir que a marca d'água (ou melhor, a forma‑pai da marca d'água) seja editada, o Aspose.Slides fornece funcionalidade de bloqueio de shapes. Uma shape específica pode ser travada em um slide normal ou em um Slide Master. Quando a forma da marca d'água é travada no Slide Master, ela ficará travada em todos os slides da apresentação.

Você pode definir um nome para a marca d'água de modo que, no futuro, se quiser excluí‑la, possa encontrá‑la nas shapes do slide pelo nome.

Você pode criar a marca d'água da maneira que desejar; entretanto, há recursos comuns em marcas d'água, como alinhamento central, rotação, posição em frente, etc. Consideraremos como usar esses recursos nos exemplos abaixo.

## **Marca d'água de Texto**

### **Adicionar uma Marca d'água de Texto a um Slide**

Para adicionar uma marca d'água de texto em PPT, PPTX ou ODP, você pode primeiro adicionar uma shape ao slide e, em seguida, adicionar um frame de texto a essa shape. O frame de texto é representado pela classe [TextFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframe/). Esse tipo não herda de [Shape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/), que possui um amplo conjunto de propriedades para posicionar a marca d'água de forma flexível. Portanto, o objeto [TextFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframe/) é encapsulado em um objeto [AutoShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/autoshape/). Para adicionar texto de marca d'água à shape, use o método [addTextFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/autoshape/#addTextFrame) conforme mostrado abaixo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 
- [Como usar a classe TextFrame](/slides/pt/python-java/text-formatting/)
{{% /alert %}}

### **Adicionar uma Marca d'água de Texto a uma Apresentação**

Se quiser adicionar uma marca d'água de texto a toda a apresentação (ou seja, a todos os slides de uma vez), adicione‑a ao [MasterSlide](https://reference.aspose.com/slides/pt/python-java/aspose.slides/masterslide/). O restante da lógica é o mesmo de quando se adiciona uma marca d'água a um único slide — crie um objeto [AutoShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/autoshape/) e então adicione a marca d'água usando o método [addTextFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/autoshape/#addTextFrame).

```python
import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    watermark_shape = master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 
- [Como usar o Slide Master](/slides/pt/python-java/slide-master/)
{{% /alert %}}

### **Definir a Transparência da Forma da Marca d'água**

Por padrão, a forma retangular possui cores de preenchimento e contorno. As linhas de código a seguir tornam a forma transparente.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_shape.getFillFormat().setFillType(FillType.NoFill)
    watermark_shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
finally:
    presentation.dispose()
```

### **Definir a Fonte para uma Marca d'água de Texto**

Você pode alterar a fonte da marca d'água de texto conforme mostrado abaixo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FontData

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame("CONFIDENTIAL")
    text_format = watermark_frame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat()
    font = FontData("Arial")
    text_format.setLatinFont(font)
    text_format.setFontHeight(50)
finally:
    presentation.dispose()
```

### **Definir a Cor do Texto da Marca d'água**

Para definir a cor do texto da marca d'água, use este código:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame("CONFIDENTIAL")
    alpha, red, green, blue = 150, 200, 200, 200
    fill_format = watermark_frame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat()
    fill_format.setFillType(FillType.Solid)
    color = Color(red, green, blue, alpha)
    fill_format.getSolidFillColor().setColor(color)
finally:
    presentation.dispose()
```

### **Centralizar uma Marca d'água de Texto**

É possível centralizar a marca d'água em um slide; para isso, faça o seguinte:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide_size = presentation.getSlideSize().getSize()
    watermark_width = 400
    watermark_height = 40
    watermark_x = (slide_size.getWidth() - watermark_width) / 2
    watermark_y = (slide_size.getHeight() - watermark_height) / 2
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, watermark_x, watermark_y, watermark_width, watermark_height)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

A imagem abaixo mostra o resultado final.

![A marca d'água de texto](text_watermark.png)

## **Marca d'água de Imagem**

### **Adicionar uma Marca d'água de Imagem a uma Apresentação**

Para adicionar uma marca d'água de imagem a um slide de apresentação, você pode fazer o seguinte:

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType, PictureFillMode

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    image_data = Path("watermark.png").read_bytes()
    image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(image_data))
    watermark_shape.getFillFormat().setFillType(FillType.Picture)
    watermark_shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image)
    watermark_shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
finally:
    presentation.dispose()
```

### **Bloquear uma Marca d'água contra Edição**

Se for necessário impedir que a marca d'água seja editada, use o método [AutoShape.getAutoShapeLock](https://reference.aspose.com/slides/pt/python-java/aspose.slides/autoshape/#getAutoShapeLock) na shape. Com essa propriedade, você pode proteger a shape contra seleção, redimensionamento, reposicionamento, agrupamento com outros elementos, bloquear seu texto contra edição e muito mais:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    # Bloquear a forma da marca d'água contra modificação.
    watermark_shape.getAutoShapeLock().setSelectLocked(True)
    watermark_shape.getAutoShapeLock().setSizeLocked(True)
    watermark_shape.getAutoShapeLock().setTextLocked(True)
    watermark_shape.getAutoShapeLock().setPositionLocked(True)
    watermark_shape.getAutoShapeLock().setGroupingLocked(True)
finally:
    presentation.dispose()
```

### **Trazer uma Marca d'água para a Frente**

No Aspose.Slides, a ordem Z das shapes pode ser definida via o método [ShapeCollection.reorder](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapecollection/#reorder). Para isso, chame esse método a partir da coleção de shapes do slide e passe a referência da shape e seu número de ordem ao método. Dessa forma, é possível trazer uma shape para a frente ou enviá‑la para o fundo do slide. Esse recurso é especialmente útil se precisar colocar a marca d'água à frente da apresentação:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    shape_count = slide.getShapes().size()
    slide.getShapes().reorder(shape_count - 1, watermark_shape)
finally:
    presentation.dispose()
```

### **Definir a Rotação da Marca d'água**

Aqui está um exemplo de código que ajusta a rotação da marca d'água para que ela fique posicionada diagonalmente no slide:

```python
import jpype
import asposeslides
import math

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    slide_size = presentation.getSlideSize().getSize()
    diagonal_angle = math.atan((slide_size.getHeight() / slide_size.getWidth())) * 180 / math.pi
    watermark_shape.setRotation(diagonal_angle)
finally:
    presentation.dispose()
```

### **Definir um Nome para uma Marca d'água**

O Aspose.Slides permite definir o nome de uma shape. Ao usar o nome da shape, você pode acessá‑la no futuro para modificá‑la ou excluí‑la. Para definir o nome da shape da marca d'água, passe‑o ao método [Shape.setName](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#setName):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_shape.setName("watermark")
finally:
    presentation.dispose()
```

### **Remover uma Marca d'água**

Para remover a shape da marca d'água, use o método [Shape.getName](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#getName) para encontrá‑la nas shapes do slide. Em seguida, passe a shape da marca d'água ao método [ShapeCollection.remove](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapecollection/#remove):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    slide_shapes = slide.getShapes().toArray()
    for shape in slide_shapes:
        if shape.getName() == "watermark":
            slide.getShapes().remove(shape)
finally:
    presentation.dispose()
```

## **FAQ**

**O que é uma marca d'água e por que devo usá‑la?**

Uma marca d'água é uma sobreposição de texto ou imagem aplicada aos slides que ajuda a proteger a propriedade intelectual, reforçar o reconhecimento da marca ou impedir o uso não autorizado das apresentações.

**Posso adicionar uma marca d'água a todos os slides de uma apresentação?**

Sim, o Aspose.Slides permite adicionar programaticamente uma marca d'água a cada slide de uma apresentação. Você pode percorrer todos os slides e aplicar as configurações da marca d'água individualmente.

**Como posso ajustar a transparência da marca d'água?**

Você pode ajustar a transparência da marca d'água modificando as configurações de preenchimento ([getFillFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#getFillFormat)) da shape. Isso garante que a marca d'água seja sutil e não distraia do conteúdo do slide.

**Quais formatos de imagem são suportados para marcas d'água?**

O Aspose.Slides suporta vários formatos de imagem, como PNG, JPEG, GIF, BMP, SVG e outros.

**Posso personalizar a fonte e o estilo de uma marca d'água de texto?**

Sim, você pode escolher qualquer fonte, tamanho e estilo para combinar com o design da sua apresentação e manter a consistência da marca.

**Como altero a posição ou orientação de uma marca d'água?**

Você pode ajustar a posição e a orientação da marca d'água programaticamente modificando as coordenadas, o tamanho e as propriedades de rotação da shape.