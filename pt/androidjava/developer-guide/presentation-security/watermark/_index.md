---
title: Adicionar marcas d'água a apresentações no Android
linktitle: Marca d'água
type: docs
weight: 40
url: /pt/androidjava/watermark/
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
- Android
- Java
- Aspose.Slides
description: "Gerencie marcas d'água de texto e imagem em apresentações PowerPoint e OpenDocument no Android em Java para indicar um rascunho, informações confidenciais e mais."
---
## **Introdução**

**Uma marca d'água** em uma apresentação é um selo de texto ou imagem usado em um slide ou em todas as slides da apresentação. Normalmente, uma marca d'água é utilizada para indicar que a apresentação é um rascunho (por exemplo, uma marca d'água “Rascunho”), que contém informações confidenciais (por exemplo, uma marca d'água “Confidencial”), para especificar a qual empresa pertence (por exemplo, uma marca d'água “Nome da Empresa”), para identificar o autor da apresentação, etc. Uma marca d'água ajuda a prevenir violações de direitos autorais ao indicar que a apresentação não deve ser copiada. Marcas d'água são usadas tanto nos formatos de apresentação PowerPoint quanto OpenOffice. No **Aspose.Slides**, você pode adicionar uma marca d'água aos formatos de arquivo PowerPoint PPT, PPTX e OpenOffice ODP.

No [**Aspose.Slides**](https://products.aspose.com/slides/pt/android-java/), há várias maneiras de criar marcas d'água em documentos PowerPoint ou OpenOffice e modificar seu design e comportamento. O ponto em comum é que, para adicionar marcas d'água de texto, você deve usar a interface [ITextFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframe/), e, para adicionar marcas d'água de imagem, use a classe [PictureFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/pictureframe/) ou preencha uma forma de marca d'água com uma imagem. `PictureFrame` implementa a interface [IShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishape/), permitindo que você utilize todas as configurações flexíveis do objeto forma. Como `ITextFrame` não é uma forma e suas configurações são limitadas, ele é encapsulado em um objeto [IShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishape/).

Existem duas maneiras de aplicar uma marca d'água: a um slide único ou a todas as slides da apresentação. O Slide Master é usado para aplicar uma marca d'água a todas as slides — a marca d'água é adicionada ao Slide Master, totalmente desenhada lá, e aplicada a todas as slides sem afetar a permissão de modificar a marca d'água em slides individuais.

Uma marca d'água costuma ser considerada indisponível para edição por outros usuários. Para impedir que a marca d'água (ou melhor, a forma‑pai da marca d'água) seja editada, o Aspose.Slides fornece funcionalidade de bloqueio de formas. Uma forma específica pode ser bloqueada em um slide normal ou no Slide Master. Quando a forma da marca d'água é bloqueada no Slide Master, ela ficará bloqueada em todas as slides da apresentação.

Você pode definir um nome para a marca d'água de modo que, no futuro, se quiser excluí‑la, possa encontrá‑la nas formas do slide pelo nome.

Você pode desenhar a marca d'água de qualquer maneira; entretanto, geralmente há características comuns em marcas d'água, como alinhamento central, rotação, posição à frente, etc. Consideraremos como usar esses recursos nos exemplos a seguir.

## **Marca d'água de Texto**

### **Adicionar uma Marca d'água de Texto a um Slide**

Para adicionar uma marca d'água de texto em PPT, PPTX ou ODP, você pode primeiro adicionar uma forma ao slide e, em seguida, adicionar um quadro de texto a essa forma. O quadro de texto é representado pela interface [ITextFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframe/). Esse tipo não herda de [IShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishape/), que possui um amplo conjunto de propriedades para posicionar a marca d'água de forma flexível. Portanto, o objeto [ITextFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframe/) é encapsulado em um objeto [IAutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iautoshape/). Para adicionar texto de marca d'água à forma, use o método [addTextFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) conforme mostrado abaixo.

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="See also" %}} 
- [How to Use the TextFrame Class](/slides/pt/androidjava/text-formatting/)
{{% /alert %}}

### **Adicionar uma Marca d'água de Texto a uma Apresentação**

Se você quiser adicionar uma marca d'água de texto a toda a apresentação (ou seja, a todas as slides de uma só vez), adicione‑a ao [MasterSlide](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/masterslide/). O resto da lógica é o mesmo de quando se adiciona uma marca d'água a um slide único — crie um objeto [IAutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iautoshape/) e então adicione a marca d'água usando o método [addTextFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-).

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="See also" %}} 
- [How to Use the Slide Master](/slides/pt/androidjava/slide-master/)
{{% /alert %}}

### **Definir Transparência da Forma da Marca d'água**

Por padrão, a forma retangular tem cores de preenchimento e de contorno. As linhas de código a seguir tornam a forma transparente.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    watermarkShape.getFillFormat().setFillType(FillType.NoFill);
    watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
} finally {
    presentation.dispose();
}
```

### **Definir a Fonte para uma Marca d'água de Texto**

Você pode alterar a fonte da marca d'água de texto conforme mostrado abaixo.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

    IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
    textFormat.setLatinFont(new FontData("Arial"));
    textFormat.setFontHeight(50);
} finally {
    presentation.dispose();
}
```

### **Definir a Cor do Texto da Marca d'água**

Para definir a cor do texto da marca d'água, use este código:

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 150, red = 200, green = 200, blue = 200;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

    IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
    fillFormat.setFillType(FillType.Solid);
    fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));
} finally {
    presentation.dispose();
}
```

### **Centralizar uma Marca d'água de Texto**

É possível centralizar a marca d'água em um slide; para isso, você pode fazer o seguinte:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    float watermarkWidth = 400;
    float watermarkHeight = 40;
    float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
    float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

    IAutoShape watermarkShape = slide.getShapes().addAutoShape(
            ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

    ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
} finally {
    presentation.dispose();
}
```

A imagem abaixo mostra o resultado final.

![A marca d'água de texto](text_watermark.png)

## **Marca d'água de Imagem**

### **Adicionar uma Marca d'água de Imagem a uma Apresentação**

Para adicionar uma marca d'água de imagem a um slide de apresentação, você pode fazer o seguinte:

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.InputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    InputStream imageStream = new FileInputStream("watermark.png");
    IPPImage image = presentation.getImages().addImage(imageStream);

    watermarkShape.getFillFormat().setFillType(FillType.Picture);
    watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
} finally {
    presentation.dispose();
}
```

### **Bloquear uma Marca d'água contra Edição**

Se for necessário impedir que uma marca d'água seja editada, use o método [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iautoshape/#getAutoShapeLock--) na forma. Com essa propriedade, você pode proteger a forma contra seleção, redimensionamento, repositicionamento, agrupamento com outros elementos, bloqueio de seu texto contra edição e muito mais:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    // Bloquear a forma da marca d'água contra modificações
    watermarkShape.getAutoShapeLock().setSelectLocked(true);
    watermarkShape.getAutoShapeLock().setSizeLocked(true);
    watermarkShape.getAutoShapeLock().setTextLocked(true);
    watermarkShape.getAutoShapeLock().setPositionLocked(true);
    watermarkShape.getAutoShapeLock().setGroupingLocked(true);
} finally {
    presentation.dispose();
}
```

### **Trazer uma Marca d'água para a Frente**

No Aspose.Slides, a ordem Z das formas pode ser definida via o método [IShapeCollection.reorder](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-). Para isso, chame esse método a partir da lista de slides da apresentação e passe a referência da forma e seu número de ordem ao método. Dessa forma, é possível trazer uma forma para a frente ou enviá‑la para o fundo do slide. Esse recurso é especialmente útil se você precisar colocar uma marca d'água à frente da apresentação:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    int shapeCount = slide.getShapes().size();
    slide.getShapes().reorder(shapeCount - 1, watermarkShape);
} finally {
    presentation.dispose();
}
```

### **Definir Rotação da Marca d'água**

Segue um exemplo de código de como ajustar a rotação da marca d'água para que ela fique posicionada diagonalmente ao longo do slide:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

    watermarkShape.setRotation((float)diagonalAngle);
} finally {
    presentation.dispose();
}
```

### **Definir um Nome para uma Marca d'água**

O Aspose.Slides permite que você defina o nome de uma forma. Usando o nome da forma, você pode acessá‑la no futuro para modificá‑la ou excluí‑la. Para definir o nome da forma da marca d'água, atribua‑o ao método [IAutoShape.setName](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishape/#setName-java.lang.String-):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    watermarkShape.setName("watermark");
} finally {
    presentation.dispose();
}
```

### **Remover uma Marca d'água**

Para remover a forma da marca d'água, use o método [IAutoShape.getName](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishape/#getName--) para encontrá‑la nas formas do slide. Em seguida, passe a forma da marca d'água ao método [IShapeCollection.remove](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("watermarked.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape[] slideShapes = slide.getShapes().toArray();
    for (IShape shape : slideShapes) {
        if ("watermark".equals(shape.getName()))
        {
            slide.getShapes().remove(shape);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Perguntas Frequentes**

### O que é uma marca d'água e por que devo usá‑la?

Uma marca d'água é uma sobreposição de texto ou imagem aplicada aos slides que ajuda a proteger a propriedade intelectual, melhorar o reconhecimento da marca ou impedir o uso não autorizado de apresentações.

### Posso adicionar uma marca d'água a todas as slides de uma apresentação?

Sim, o Aspose.Slides permite que você adicione programaticamente uma marca d'água a cada slide de uma apresentação. Você pode iterar por todas as slides e aplicar as configurações da marca d'água individualmente.

### Como posso ajustar a transparência da marca d'água?

Você pode ajustar a transparência da marca d'água modificando as configurações de preenchimento ([getFillFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/shape/#getFillFormat--)) da forma. Isso garante que a marca d'água seja sutil e não distraia do conteúdo do slide.

### Quais formatos de imagem são suportados para marcas d'água?

O Aspose.Slides suporta vários formatos de imagem, como PNG, JPEG, GIF, BMP, SVG e outros.

### Posso personalizar a fonte e o estilo de uma marca d'água de texto?

Sim, você pode escolher qualquer fonte, tamanho e estilo para combinar com o design da sua apresentação e manter a consistência da marca.

### Como altero a posição ou orientação de uma marca d'água?

Você pode ajustar a posição e a orientação da marca d'água programaticamente modificando as coordenadas, o tamanho e as propriedades de rotação da forma.