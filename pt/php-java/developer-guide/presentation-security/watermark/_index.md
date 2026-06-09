---
title: Adicionar marcas d'água a apresentações em PHP
linktitle: Marca d'água
type: docs
weight: 40
url: /pt/php-java/watermark/
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
- PHP
- Aspose.Slides
description: "Gerencie marcas d'água de texto e imagem em apresentações PowerPoint e OpenDocument em PHP para indicar um rascunho, informações confidenciais, direitos autorais e muito mais."
---
## **Introdução**

**Uma marca d'água** em uma apresentação é um selo de texto ou imagem usado em um slide ou em todas as slides da apresentação. Normalmente, uma marca d'água é usada para indicar que a apresentação é um rascunho (por exemplo, uma marca d'água “Rascunho”), que contém informações confidenciais (por exemplo, uma marca d'água “Confidencial”), para especificar a que empresa pertence (por exemplo, uma marca d'água “Nome da Empresa”), para identificar o autor da apresentação etc. Uma marca d'água ajuda a prevenir violações de direitos autorais ao indicar que a apresentação não deve ser copiada. Marcas d'água são usadas nos formatos de apresentação PowerPoint e OpenOffice. No Aspose.Slides, você pode adicionar uma marca d'água aos formatos de arquivo PowerPoint PPT, PPTX e OpenOffice ODP.

No [**Aspose.Slides**](https://products.aspose.com/slides/pt/php-java/), há várias maneiras de criar marcas d'água em documentos PowerPoint ou OpenOffice e modificar seu design e comportamento. O aspecto comum é que, para adicionar marcas d'água de texto, você deve usar a classe [TextFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/); para adicionar marcas d'água de imagem, use a classe [PictureFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pictureframe/) ou preencha uma forma de marca d'água com uma imagem. `PictureFrame` implementa a classe [Shape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/), permitindo usar todas as configurações flexíveis do objeto shape. Como `ITextFrame` não é uma shape e suas configurações são limitadas, ele é encapsulado em um objeto [Shape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/).

Existem duas maneiras de aplicar uma marca d'água: a um único slide ou a todas as slides da apresentação. O Slide Master é usado para aplicar uma marca d'água a todas as slides — a marca d'água é adicionada ao Slide Master, totalmente projetada lá, e aplicada a todas as slides sem afetar a permissão de modificar a marca d'água em slides individuais.

Uma marca d'água costuma ser considerada indisponível para edição por outros usuários. Para impedir que a marca d'água (ou melhor, a shape pai da marca d'água) seja editada, o Aspose.Slides fornece funcionalidade de bloqueio de shape. Uma shape específica pode ser bloqueada em um slide normal ou no Slide Master. Quando a shape da marca d'água está bloqueada no Slide Master, ela será bloqueada em todas as slides da apresentação.

Você pode definir um nome para a marca d'água para que, no futuro, se quiser excluí‑la, possa encontrá‑la nas shapes do slide pelo nome.

Você pode projetar a marca d'água de qualquer forma; entretanto, geralmente há recursos comuns nas marcas d'água, como alinhamento central, rotação, posição à frente, etc. Consideraremos como usar esses recursos nos exemplos a seguir.

## **Marca d'água de Texto**

### **Adicionar uma Marca d'água de Texto a um Slide**

Para adicionar uma marca d'água de texto em PPT, PPTX ou ODP, você pode primeiro adicionar uma shape ao slide e, depois, adicionar um frame de texto a essa shape. O frame de texto é representado pela classe [TextFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/). Esse tipo não herda de [Shape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/), que possui um amplo conjunto de propriedades para posicionar a marca d'água de forma flexível. Portanto, o objeto [TextFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/) é encapsulado em um objeto [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/). Para adicionar texto de marca d'água à shape, use o método [addTextFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/#addTextFrame) conforme mostrado abaixo.

```php
$watermarkText = "CONFIDENTIAL";

$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$watermarkShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```

{{% alert color="primary" title="See also" %}} 
- [How to Use the TextFrame Class](/slides/pt/php-java/text-formatting/)
{{% /alert %}}

### **Adicionar uma Marca d'água de Texto a uma Apresentação**

Se você quiser adicionar uma marca d'água de texto a toda a apresentação (ou seja, a todas as slides de uma vez), adicione‑a ao [MasterSlide](https://reference.aspose.com/slides/pt/php-java/aspose.slides/masterslide/). O restante da lógica é o mesmo de quando se adiciona uma marca d'água a um único slide — crie um objeto [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/) e depois adicione a marca d'água usando o método [addTextFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/#addTextFrame).

```php
$watermarkText = "CONFIDENTIAL";

$presentation = new Presentation();
$masterSlide = $presentation->getMasters()->get_Item(0);

$watermarkShape = $masterSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```

{{% alert color="primary" title="See also" %}} 
- [How to Use the Slide Master](/slides/pt/php-java/slide-master/)
{{% /alert %}}

### **Definir Transparência da Shape da Marca d'água**

Por padrão, a shape retangular possui cores de preenchimento e contorno. As linhas de código a seguir tornam a shape transparente.

```php
$watermarkShape->getFillFormat()->setFillType(FillType::NoFill);
$watermarkShape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
```

### **Definir a Fonte para uma Marca d'água de Texto**

Você pode alterar a fonte da marca d'água de texto conforme mostrado abaixo.

```php
$textFormat = $watermarkFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat();
$textFormat->setLatinFont(new FontData("Arial"));
$textFormat->setFontHeight(50);
```

### **Definir a Cor do Texto da Marca d'água**

Para definir a cor do texto da marca d'água, use este código:

```php
$alpha = 150;
$red = 200;
$green = 200;
$blue = 200;
$textColor = new Java("java.awt.Color", $red, $green, $blue, $alpha);

$fillFormat = $watermarkFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();
$fillFormat->setFillType(FillType::Solid);
$fillFormat->getSolidFillColor()->setColor($textColor);
```

### **Centralizar uma Marca d'água de Texto**

É possível centralizar a marca d'água em um slide; para isso, você pode fazer o seguinte:

```php
$slideSize = $presentation->getSlideSize()->getSize();
$slideWidth = java_values($slideSize->getWidth());
$slideHeight = java_values($slideSize->getHeight());

$watermarkWidth = 400;
$watermarkHeight = 40;
$watermarkX = ($slideWidth - $watermarkWidth) / 2;
$watermarkY = ($slideHeight - $watermarkHeight) / 2;

$watermarkShape = $slide->getShapes()->addAutoShape(
        ShapeType::Rectangle, $watermarkX, $watermarkY, $watermarkWidth, $watermarkHeight);

$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);
```

A imagem abaixo mostra o resultado final.

![A marca d'água de texto](text_watermark.png)

## **Marca d'água de Imagem**

### **Adicionar uma Marca d'água de Imagem a uma Apresentação**

Para adicionar uma marca d'água de imagem a um slide da apresentação, você pode fazer o seguinte:

```php
$image = Images::fromFile("watermark.png");
$picture = $presentation->getImages()->addImage($image);
$image->dispose();

$watermarkShape->getFillFormat()->setFillType(FillType::Picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
```

### **Bloquear uma Marca d'água contra Edição**

Se for necessário impedir que uma marca d'água seja editada, use o método [AutoShape.getAutoShapeLock](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/#getAutoShapeLock) na shape. Com essa propriedade, você pode proteger a shape contra seleção, redimensionamento, reposicionamento, agrupamento com outros elementos, bloqueio do texto contra edição e muito mais:

```php
// Bloquear a shape da marca d'água contra modificações
$watermarkShape->getAutoShapeLock()->setSelectLocked(true);
$watermarkShape->getAutoShapeLock()->setSizeLocked(true);
$watermarkShape->getAutoShapeLock()->setTextLocked(true);
$watermarkShape->getAutoShapeLock()->setPositionLocked(true);
$watermarkShape->getAutoShapeLock()->setGroupingLocked(true);
```

### **Trazer uma Marca d'água para a Frente**

No Aspose.Slides, a ordem Z das shapes pode ser definida via o método [ShapeCollection.reorder](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapecollection/#reorder). Para isso, chame esse método a partir da lista de slides da apresentação e passe a referência da shape e seu número de ordem ao método. Dessa forma, é possível trazer uma shape para a frente ou enviá‑la para o fundo do slide. Esse recurso é especialmente útil se você precisar posicionar a marca d'água na frente da apresentação:

```php
$shapeCount = java_values($slide->getShapes()->size());
$slide->getShapes()->reorder($shapeCount - 1, $watermarkShape);
```

### **Definir Rotação da Marca d'água**

Aqui está um exemplo de código de como ajustar a rotação da marca d'água para que ela fique posicionada diagonalmente no slide:

```php
$diagonalAngle = atan($slideWidth / $slideHeight) * 180 / M_PI;

$watermarkShape->setRotation($diagonalAngle);
```

### **Definir um Nome para uma Marca d'água**

O Aspose.Slides permite definir o nome de uma shape. Usando o nome da shape, você pode acessá‑la no futuro para modificar ou excluir. Para definir o nome da shape da marca d'água, atribua‑o ao método [AutoShape.setName](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/#setName):

```php
$watermarkShape->setName("watermark");
```

### **Remover uma Marca d'água**

Para remover a shape da marca d'água, use o método [AutoShape.getName](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/#getName) para encontrá‑la nas shapes do slide. Em seguida, passe a shape da marca d'água ao método [ShapeCollection.remove](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapecollection/#remove):

```php
$slideShapes = $slide->getShapes()->toArray();
foreach ($slideShapes as $shape) {
    if ($shape->getName() === "watermark") {
        $slide->getShapes()->remove($shape);
    }
}
```

## **FAQ**

**O que é uma marca d'água e por que devo usá‑la?**

Uma marca d'água é uma sobreposição de texto ou imagem aplicada aos slides que ajuda a proteger a propriedade intelectual, reforçar o reconhecimento da marca ou impedir o uso não autorizado das apresentações.

**Posso adicionar uma marca d'água a todas as slides de uma apresentação?**

Sim, o Aspose.Slides permite adicionar programaticamente uma marca d'água a cada slide de uma apresentação. Você pode percorrer todas as slides e aplicar as configurações da marca d'água individualmente.

**Como ajustar a transparência da marca d'água?**

Você pode ajustar a transparência da marca d'água modificando as configurações de preenchimento ([getFillFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/getfillformat/)) da shape. Isso garante que a marca d'água seja sutil e não distraia do conteúdo do slide.

**Quais formatos de imagem são suportados para marcas d'água?**

O Aspose.Slides suporta vários formatos de imagem, como PNG, JPEG, GIF, BMP, SVG e outros.

**Posso personalizar a fonte e o estilo de uma marca d'água de texto?**

Sim, você pode escolher qualquer fonte, tamanho e estilo para combinar com o design da sua apresentação e manter a consistência da marca.

**Como alterar a posição ou orientação de uma marca d'água?**

Você pode ajustar a posição e a orientação da marca d'água programaticamente modificando as coordenadas, o tamanho e as propriedades de rotação da shape.