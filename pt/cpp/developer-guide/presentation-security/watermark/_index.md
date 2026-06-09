---
title: Adicionar Marcas d'Água a Apresentações em C++
linktitle: Marca d'Água
type: docs
weight: 40
url: /pt/cpp/watermark/
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
- C++
- Aspose.Slides
description: "Gerencie marcas d'água de texto e imagem em apresentações PowerPoint e OpenDocument em C++ para indicar rascunho, informações confidenciais, direitos autorais e muito mais."
---
## **Introdução**

**Uma marca d'água** em uma apresentação é um selo de texto ou imagem usado em um slide ou em todos os slides da apresentação. Normalmente, uma marca d'água é usada para indicar que a apresentação é um rascunho (por exemplo, uma marca d'água "Rascunho"), que contém informações confidenciais (por exemplo, uma marca d'água "Confidencial"), para especificar a que empresa pertence (por exemplo, uma marca d'água "Nome da Empresa"), para identificar o autor da apresentação etc. Uma marca d'água ajuda a prevenir violações de direitos autorais ao indicar que a apresentação não deve ser copiada. Marcas d'água são usadas nos formatos de apresentação PowerPoint e OpenOffice. No Aspose.Slides, você pode adicionar uma marca d'água aos formatos de arquivo PowerPoint PPT, PPTX e OpenOffice ODP.

Em [**Aspose.Slides**](https://products.aspose.com/slides/pt/cpp/), há várias maneiras de criar marcas d'água em documentos PowerPoint ou OpenOffice e modificar seu design e comportamento. O aspecto comum é que, para adicionar marcas d'água de texto, você deve usar a interface [ITextFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/), e para adicionar marcas d'água de imagem, usar a classe [PictureFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/pictureframe/) ou preencher uma forma de marca d'água com uma imagem. `PictureFrame` implementa a interface [IShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishape/), permitindo que você use todas as configurações flexíveis do objeto shape. Como `ITextFrame` não é uma shape e suas configurações são limitadas, ele é encapsulado em um objeto [IShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishape/).

Existem duas formas de aplicar uma marca d'água: a um slide único ou a todos os slides da apresentação. O Slide Master é usado para aplicar uma marca d'água a todos os slides — a marca d'água é adicionada ao Slide Master, totalmente designada lá, e aplicada a todos os slides sem afetar a permissão de modificar a marca d'água em slides individuais.

Uma marca d'água geralmente é considerada indisponível para edição por outros usuários. Para impedir que a marca d'água (ou, mais precisamente, a shape pai da marca d'água) seja editada, o Aspose.Slides fornece funcionalidade de bloqueio de shape. Uma shape específica pode ser bloqueada em um slide normal ou em um Slide Master. Quando a shape da marca d'água está bloqueada no Slide Master, ela será bloqueada em todos os slides da apresentação.

Você pode definir um nome para a marca d'água de modo que, no futuro, se quiser excluí‑la, possa encontrá‑la nas shapes do slide pelo nome.

Você pode projetar a marca d'água de qualquer forma; entretanto, geralmente há recursos comuns em marcas d'água, como alinhamento central, rotação, posição de frente etc. Veremos como usar esses recursos nos exemplos abaixo.

## **Marca d'água de Texto**

### **Adicionar uma Marca d'água de Texto a um Slide**

Para adicionar uma marca d'água de texto em PPT, PPTX ou ODP, você pode primeiro adicionar uma shape ao slide, então adicionar um frame de texto a essa shape. O frame de texto é representado pela interface [ITextFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/). Esse tipo não herda de [IShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishape/), que possui um amplo conjunto de propriedades para posicionar a marca d'água de forma flexível. Portanto, o objeto [ITextFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/) é encapsulado em um objeto [IAutoShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iautoshape/). Para adicionar texto de marca d'água à shape, use o método [AddTextFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iautoshape/addtextframe/) conforme mostrado abaixo.

```cpp
auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="primary" title="Veja também" %}} 
- [How to Use the TextFrame Class](/slides/pt/cpp/text-formatting/)
{{% /alert %}}

### **Adicionar uma Marca d'água de Texto a uma Apresentação**

Se você quiser adicionar uma marca d'água de texto a toda a apresentação (ou seja, a todos os slides de uma vez), adicione‑a ao [MasterSlide](https://reference.aspose.com/slides/pt/cpp/aspose.slides/masterslide/). O resto da lógica é o mesmo de quando se adiciona uma marca d'água a um slide único — crie um objeto [IAutoShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iautoshape/) e então adicione a marca d'água a ele usando o método [AddTextFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iautoshape/addtextframe/).

```cpp
auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);

auto watermarkShape = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="primary" title="Veja também" %}} 
- [How to Use the Slide Master](/slides/pt/cpp/slide-master/)
{{% /alert %}}

### **Definir a Transparência da Shape da Marca d'água**

Por padrão, a shape retangular tem cores de preenchimento e linha. As linhas de código a seguir tornam a shape transparente.

```cpp
watermarkShape->get_FillFormat()->set_FillType(FillType::NoFill);
watermarkShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
```

### **Definir a Fonte para uma Marca d'água de Texto**

Você pode mudar a fonte da marca d'água de texto como mostrado abaixo.

```cpp
auto textFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat();
textFormat->set_LatinFont(MakeObject<FontData>(u"Arial"));
textFormat->set_FontHeight(50);
```

### **Definir a Cor do Texto da Marca d'água**

Para definir a cor do texto da marca d'água, use este código:

```cpp
auto alpha = 150, red = 200, green = 200, blue = 200;

auto fillFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Solid);
fillFormat->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, red, green, blue));
```

### **Centralizar uma Marca d'água de Texto**

É possível centralizar a marca d'água em um slide, e para isso você pode fazer o seguinte:

```cpp
auto slideSize = presentation->get_SlideSize()->get_Size();

auto watermarkWidth = 400;
auto watermarkHeight = 40;
auto watermarkX = (slideSize.get_Width() - watermarkWidth) / 2;
auto watermarkY = (slideSize.get_Height() - watermarkHeight) / 2;

auto watermarkShape = slide->get_Shapes()->AddAutoShape(
    ShapeType::Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);
```

A imagem abaixo mostra o resultado final.

![A marca d'água de texto](text_watermark.png)

## **Marca d'água de Imagem**

### **Adicionar uma Marca d'água de Imagem a uma Apresentação**

Para adicionar uma marca d'água de imagem a um slide de apresentação, você pode fazer o seguinte:

```cpp
auto imageStream = File::ReadAllBytes(u"watermark.png");
auto image = presentation->get_Images()->AddImage(imageStream);

watermarkShape->get_FillFormat()->set_FillType(FillType::Picture);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
```

## **Bloquear uma Marca d'água contra Edição**

Se for necessário impedir que uma marca d'água seja editada, use o método [IAutoShape::get_AutoShapeLock](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iautoshape/get_autoshapelock/) na shape. Com essa propriedade, você pode proteger a shape contra seleção, redimensionamento, reposicionamento, agrupamento com outros elementos, bloquear seu texto contra edição e muito mais:

```cpp
// Bloquear a shape da marca d'água contra modificações
watermarkShape->get_AutoShapeLock()->set_SelectLocked(true);
watermarkShape->get_AutoShapeLock()->SizeLocked(true);
watermarkShape->get_AutoShapeLock()->TextLocked(true);
watermarkShape->get_AutoShapeLock()->PositionLocked(true);
watermarkShape->get_AutoShapeLock()->GroupingLocked(true);
```

## **Trazer uma Marca d'água para a Frente**

No Aspose.Slides, a ordem Z das shapes pode ser definida via o método [IShapeCollection::Reorder](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishapecollection/reorder/). Para isso, chame esse método a partir da lista de slides da apresentação e passe a referência da shape e seu número de ordem ao método. Dessa forma, é possível trazer uma shape para a frente ou enviá‑la para o fundo do slide. Essa funcionalidade é especialmente útil se você precisar colocar uma marca d'água na frente da apresentação:

```cpp
auto shapeCount = slide->get_Shapes()->get_Count();
slide->get_Shapes()->Reorder(shapeCount - 1, watermarkShape);
```

## **Definir a Rotação da Marca d'água**

Aqui está um exemplo de código de como ajustar a rotação da marca d'água para que ela fique posicionada diagonalmente no slide:

```cpp
auto diagonalAngle = Math::Atan((slideSize.get_Height() / slideSize.get_Width())) * 180 / Math::PI;

watermarkShape->set_Rotation((float)diagonalAngle);
```

## **Definir um Nome para uma Marca d'água**

O Aspose.Slides permite definir o nome de uma shape. Ao usar o nome da shape, você pode acessá‑la no futuro para modificá‑la ou excluí‑la. Para definir o nome da shape da marca d'água, atribua‑o ao método [IAutoShape::set_Name](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishape/set_name/):

```cpp
watermarkShape->set_Name(u"watermark");
```

## **Remover uma Marca d'água**

Para remover a shape da marca d'água, use o método [IAutoShape::get_Name](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishape/get_name/) para encontrá‑la nas shapes do slide. Em seguida, passe a shape da marca d'água ao método [IShapeCollection::Remove](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishapecollection/remove/):

```cpp
auto slideShapes = slide->get_Shapes()->ToArray();
for(auto shape : slideShapes)
{
    if (String::Compare(shape->get_Name(), u"watermark", StringComparison::Ordinal) == 0)
    {
        slide->get_Shapes()->Remove(watermarkShape);
    }
}
```

## **Um Exemplo ao Vivo**

Você pode experimentar as ferramentas online gratuitas do **Aspose.Slides** [Add Watermark](https://products.aspose.app/slides/pt/watermark) e [Remove Watermark](https://products.aspose.app/slides/pt/watermark/remove-watermark).

![Ferramentas online para adicionar e remover marcas d'água](online_tools.png)

## **FAQ**

**O que é uma marca d'água e por que devo usá‑la?**

Uma marca d'água é uma sobreposição de texto ou imagem aplicada aos slides que ajuda a proteger a propriedade intelectual, reforçar o reconhecimento da marca ou impedir o uso não autorizado de apresentações.

**Posso adicionar uma marca d'água a todos os slides de uma apresentação?**

Sim, o Aspose.Slides permite adicionar programaticamente uma marca d'água a cada slide de uma apresentação. Você pode iterar por todos os slides e aplicar as configurações da marca d'água individualmente.

**Como posso ajustar a transparência da marca d'água?**

Você pode ajustar a transparência da marca d'água modificando as configurações de preenchimento ([FillFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/shape/get_fillformat/)) da shape. Isso garante que a marca d'água seja sutil e não distraia do conteúdo do slide.

**Quais formatos de imagem são suportados para marcas d'água?**

O Aspose.Slides suporta diversos formatos de imagem, como PNG, JPEG, GIF, BMP, SVG e outros.

**Posso personalizar a fonte e o estilo de uma marca d'água de texto?**

Sim, você pode escolher qualquer fonte, tamanho e estilo para combinar com o design da sua apresentação e manter a consistência da marca.

**Como altero a posição ou orientação de uma marca d'água?**

Você pode ajustar a posição e orientação da marca d'água programaticamente modificando as coordenadas, tamanho e propriedades de rotação da shape.