---
title: Gerenciar Quadros de Imagem em Apresentações Usando JavaScript
linktitle: Quadro de Imagem
type: docs
weight: 10
url: /pt/nodejs-java/picture-frame/
keywords:
- quadro de imagem
- adicionar quadro de imagem
- criar quadro de imagem
- adicionar imagem
- criar imagem
- extrair imagem
- imagem raster
- imagem vetorial
- cortar imagem
- área recortada
- propriedade StretchOff
- formatação de quadro de imagem
- propriedades do quadro de imagem
- escala relativa
- efeito de imagem
- proporção de aspecto
- transparência da imagem
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Adicione quadros de imagem a apresentações PowerPoint e OpenDocument com Aspose.Slides para Node.js via Java. Simplifique seu fluxo de trabalho e melhore o design dos slides."
---
## **Introdução**

Um quadro de imagem é uma forma que contém uma imagem — é como uma foto em uma moldura. 

Você pode adicionar uma imagem a um slide por meio de um quadro de imagem. Dessa forma, você formata a imagem formatando o quadro de imagem.

{{% alert  title="Tip" color="primary" %}} 

A Aspose fornece conversores gratuitos — [JPEG para PowerPoint](https://products.aspose.app/slides/pt/import/jpg-to-ppt) e [PNG para PowerPoint](https://products.aspose.app/slides/pt/import/png-to-ppt) — que permitem criar apresentações rapidamente a partir de imagens. 

{{% /alert %}} 

## **Criar Quadro de Imagem**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
2. Obtenha a referência de um slide através de seu índice. 
3. Crie um objeto `PPImage` adicionando uma imagem à [ImagesCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ImageCollection) associada ao objeto de apresentação que será usado para preencher a forma.
4. Especifique a largura e a altura da imagem.
5. Crie um [PictureFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/PictureFrame) com base na largura e altura da imagem usando o método `addPictureFrame` exposto pelo objeto shape associado ao slide referenciado.
6. Adicione um quadro de imagem (contendo a foto) ao slide.
7. Grave a apresentação modificada como um arquivo PPTX.

```javascript
// Instancia a classe Presentation que representa um arquivo PPTX
var pres = new aspose.slides.Presentation();
try {
    // Obtém o primeiro slide
    var sld = pres.getSlides().get_Item(0);
    // Instancia a classe Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Adiciona um quadro de imagem com a altura e largura equivalentes da imagem
    sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Grava o arquivo PPTX no disco
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Quadros de imagem permitem criar rapidamente slides de apresentação baseados em imagens. Quando você combina um quadro de imagem com as opções de salvamento do Aspose.Slides, pode manipular operações de entrada/saída para converter imagens de um formato para outro.

## **Criar Quadro de Imagem com Escala Relativa**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
2. Obtenha a referência de um slide através de seu índice. 
3. Adicione uma imagem à coleção de imagens da apresentação.
4. Crie um objeto [PPImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/PPImage) adicionando uma imagem à [ImagesCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ImageCollection) associada ao objeto de apresentação que será usado para preencher a forma.
5. Especifique a largura e altura relativas da imagem no quadro de imagem.
6. Grave a apresentação modificada como um arquivo PPTX.

```javascript
// Instancia a classe Presentation que representa o PPTX
var pres = new aspose.slides.Presentation();
try {
    // Obtém o primeiro slide
    var sld = pres.getSlides().get_Item(0);
    // Instancia a classe Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Adiciona um Quadro de Imagem com altura e largura equivalentes da Imagem
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Definindo a escala relativa de largura e altura
    pf.setRelativeScaleHeight(0.8);
    pf.setRelativeScaleWidth(1.35);
    // Grava o arquivo PPTX no disco
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Extrair Imagens Rasterizadas de Quadros de Imagem**

Você pode extrair imagens rasterizadas de objetos [PictureFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/PictureFrame) e salvá‑las em PNG, JPG e outros formatos. O exemplo de código abaixo demonstra como extrair uma imagem do documento "sample.pptx" e salvá‑la no formato PNG.

```javascript
var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    var firstSlide = presentation.getSlides().get_Item(0);
    var firstShape = firstSlide.getShapes().get_Item(0);
    if (java.instanceOf(firstShape, "com.aspose.slides.IPictureFrame")) {
        var pictureFrame = firstShape;
        try {
            var slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
            slideImage.save("slide_1_shape_1.png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} catch (e) {console.log(e);
} finally {
    presentation.dispose();
}
```

## **Extrair Imagens SVG de Quadros de Imagem**

Quando uma apresentação contém gráficos SVG inseridos em formas [PictureFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pictureframe/) , o Aspose.Slides para Node.js via Java permite recuperar as imagens vetoriais originais com total fidelidade. Percorrendo a coleção de formas do slide, você pode identificar cada [PictureFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pictureframe/), verificar se o [PPImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ppimage/) subjacente contém conteúdo SVG e, então, salvar essa imagem no disco ou em um fluxo no seu formato SVG nativo.

O exemplo de código a seguir demonstra como extrair uma imagem SVG de um quadro de imagem:

```js
var presentation = new aspose.slides.Presentation("sample.pptx");

try {
    var slide = presentation.getSlides().get_Item(0);
    var shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
        const svgImage = shape.getPictureFormat().getPicture().getImage().getSvgImage();

        if (svgImage) {
            fs.writeFileSync("output.svg", svgImage.getSvgData());
        }
    }
} catch (e) {
    console.log(e);
} finally {
    presentation.dispose();
}
```

## **Obter Transparência da Imagem**

O Aspose.Slides permite obter o efeito de transparência aplicado a uma imagem. Este código JavaScript demonstra a operação:

```javascript
var presentation = new aspose.slides.Presentation("Test.pptx");
var pictureFrame = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
for (var i = 0; i < imageTransform.size(); i++) {
    var effect = imageTransform.get_Item(i);
    if (java.instanceOf(effect, "com.aspose.slides.IAlphaModulateFixed")) {
        var alphaModulateFixed = effect;
        var transparencyValue = 100 - alphaModulateFixed.getAmount();
        console.log("Picture transparency: " + transparencyValue);
    }
}
```

## **Formatação de Quadro de Imagem**

O Aspose.Slides oferece muitas opções de formatação que podem ser aplicadas a um quadro de imagem. Usando essas opções, você pode alterar um quadro de imagem para atender a requisitos específicos.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
2. Obtenha a referência de um slide através de seu índice. 
3. Crie um objeto [PPImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/PPImage) adicionando uma imagem à [ImagesCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ImageCollection) associada ao objeto de apresentação que será usado para preencher a forma.
4. Especifique a largura e a altura da imagem.
5. Crie um `PictureFrame` com base na largura e altura da imagem através do método [addPictureFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) exposto pelo objeto [Shapes](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ShapeCollection) associado ao slide referenciado.
6. Adicione o quadro de imagem (contendo a foto) ao slide.
7. Defina a cor da linha do quadro de imagem.
8. Defina a largura da linha do quadro de imagem.
9. Gire o quadro de imagem fornecendo um valor positivo ou negativo.
   * Um valor positivo gira a imagem no sentido horário. 
   * Um valor negativo gira a imagem no sentido anti‑horário.
10. Adicione o quadro de imagem (contendo a foto) ao slide.
11. Grave a apresentação modificada como um arquivo PPTX.

```javascript
// Instancia a classe Presentation que representa o PPTX
var pres = new aspose.slides.Presentation();
try {
    // Obtém o primeiro slide
    var sld = pres.getSlides().get_Item(0);
    // Instancia a classe Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Adiciona um Quadro de Imagem com altura e largura equivalentes da Imagem
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Aplica alguma formatação ao PictureFrameEx
    pf.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    // Grava o arquivo PPTX no disco
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Tip" color="primary" %}}

A Aspose desenvolveu recentemente um [Criador de Colagens grátis](https://products.aspose.app/slides/pt/collage). Se você precisar [mesclar imagens JPG/JPEG](https://products.aspose.app/slides/pt/collage/jpg) ou PNG, [criar grades de fotos](https://products.aspose.app/slides/pt/collage/photo-grid), pode usar este serviço. 

{{% /alert %}}

## **Adicionar Imagem como Link**

Para evitar apresentações volumosas, você pode adicionar imagens (ou vídeos) por meio de links em vez de incorporar os arquivos diretamente nas apresentações. Este código JavaScript mostra como adicionar uma imagem e um vídeo em um placeholder:

```javascript
var presentation = new aspose.slides.Presentation("input.pptx");
try {
    var shapesToRemove = java.newInstanceSync("java.util.ArrayList");
    var shapesCount = presentation.getSlides().get_Item(0).getShapes().size();
    for (var i = 0; i < shapesCount; i++) {
        var autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(i);
        if (autoShape.getPlaceholder() == null) {
            continue;
        }
        switch (autoShape.getPlaceholder().getType()) {
            case aspose.slides.PlaceholderType.Picture :
                var pictureFrame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), null);
                pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
                shapesToRemove.add(autoShape);
                break;
            case aspose.slides.PlaceholderType.Media :
                var videoFrame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), "");
                videoFrame.getPictureFormat().getPicture().setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
                videoFrame.setLinkPathLong("https://youtu.be/t_1LYZ102RA");
                shapesToRemove.add(autoShape);
                break;
        }
    }
    for (var i = 0; i < shapesToRemove.length; i++) {
        var shape = shapesToRemove.get_Item(i);
        presentation.getSlides().get_Item(0).getShapes().remove(shape);
    }
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Cortar Imagem**

Este código JavaScript mostra como recortar uma imagem existente em um slide:

```javascript
var pres = new aspose.slides.Presentation();
// Cria novo objeto de imagem
try {
    var picture;
    var image = aspose.slides.Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Adiciona um Quadro de Imagem a um Slide
    var picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 100, 100, 420, 250, picture);
    // Recorta a imagem (valores percentuais)
    picFrame.getPictureFormat().setCropLeft(23.6);
    picFrame.getPictureFormat().setCropRight(21.5);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);
    // Salva o resultado
    pres.save(outPptxFile, aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Excluir Áreas Cortadas da Imagem**

Se você quiser excluir as áreas cortadas de uma imagem contida em um quadro, pode usar o método [deletePictureCroppedAreas()](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) . Esse método devolve a imagem recortada ou a imagem original se o recorte for desnecessário.

```javascript
var presentation = new aspose.slides.Presentation("PictureFrameCrop.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // Obtém o PictureFrame do primeiro slide
    var picFrame = slide.getShapes().get_Item(0);
    // Exclui as áreas recortadas da imagem do PictureFrame e retorna a imagem recortada
    var croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();
    // Salva o resultado
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

{{% alert title="NOTE" color="warning" %}} 

O método [deletePictureCroppedAreas()](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) adiciona a imagem recortada à coleção de imagens da apresentação. Se a imagem for usada apenas no [PictureFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pictureframe/) processado, essa configuração pode reduzir o tamanho da apresentação. Caso contrário, o número de imagens na apresentação resultante aumentará.

Este método converte arquivos metafile WMF/EMF em imagens PNG rasterizadas durante a operação de recorte. 

{{% /alert %}}

## **Comprimir Imagens**

Você pode comprimir uma imagem em uma apresentação usando o método [PictureFillFormat.compressImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-).
Esse método comprime uma imagem reduzindo seu tamanho com base no tamanho da forma e na resolução especificada, com a opção de excluir áreas recortadas.

Ele ajusta o tamanho e a resolução da imagem de maneira similar ao recurso **Formato da Imagem → Comprimir Imagens → Resolução** do PowerPoint.

Os exemplos JavaScript a seguir demonstram como comprimir uma imagem em uma apresentação especificando uma resolução alvo e opcionalmente removendo áreas recortadas:

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // Comprima a imagem com resolução alvo de 150 DPI (resolução web) e remova as áreas recortadas.
    const result = pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi150);

    // Verifique o resultado da compressão.
    if (result) {
        console.log("Image successfully compressed.");
    } else {
        console.log("Image compression failed or no changes were necessary.");
    }

    presentation.save("CompressedImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ou usando outro valor DPI predefinido:

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // Comprima a imagem para 96 DPI (resolução de email), removendo as áreas recortadas.
    pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi96);

    presentation.save("CompressedImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

O método converte a imagem para uma resolução mais baixa com base no tamanho da forma e no DPI fornecido. Regiões recortadas também podem ser excluídas para otimizar o tamanho do arquivo.
Se a imagem for um metafile (WMF/EMF) ou SVG, a compressão não será aplicada. Além disso, a qualidade do JPEG é preservada ou ligeiramente reduzida conforme a resolução, de forma similar ao tratamento de JPEGs de alta resolução no PowerPoint.

{{% /alert %}}

## **Bloquear Proporção de Aspecto**

Se você quiser que uma forma que contém uma imagem mantenha sua proporção de aspecto mesmo após alterar as dimensões da imagem, pode usar o método [setAspectRatioLocked](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) para definir a configuração *Lock Aspect Ratio*.

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var layout = pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Custom);
    var emptySlide = pres.getSlides().addEmptySlide(layout);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    var pictureFrame = emptySlide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, presImage.getWidth(), presImage.getHeight(), picture);
    // definir a forma para preservar a proporção de aspecto ao redimensionar
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="NOTE" color="warning" %}} 

Esta configuração *Lock Aspect Ratio* preserva apenas a proporção de aspecto da forma e não da imagem que ela contém.

{{% /alert %}}

## **Usar Propriedade StretchOff**

Usando os métodos [setStretchOffsetLeft](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetLeft-float-), [setStretchOffsetTop](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetTop--), [setStretchOffsetRight](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetRight--) e [setStretchOffsetBottom](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetBottom-float-) da classe [PictureFillFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/PictureFillFormat), você pode especificar um retângulo de preenchimento.

Quando o alongamento é especificado para uma imagem, um retângulo de origem é dimensionado para caber no retângulo de preenchimento especificado. Cada borda do retângulo de preenchimento é definida por um deslocamento percentual em relação à borda correspondente da caixa delimitadora da forma. Um percentual positivo indica um recuo, enquanto um percentual negativo indica um sobrespatamento.

1. Crie uma instância da [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation) class.
2. Obtenha a referência de um slide através de seu índice.
3. Adicione um retângulo `AutoShape`. 
4. Crie uma imagem.
5. Defina o tipo de preenchimento da forma.
6. Defina o modo de preenchimento da imagem da forma.
7. Adicione uma imagem definida para preencher a forma.
8. Especifique os deslocamentos da imagem a partir da borda correspondente da caixa delimitadora da forma
9. Grave a apresentação modificada como um arquivo PPTX.

```javascript
// Instancia a classe Presentation que representa um arquivo PPTX
var pres = new aspose.slides.Presentation();
try {
    // Obtém o primeiro slide
    var slide = pres.getSlides().get_Item(0);
    // Instancia a classe ImageEx
    var picture;
    var image = aspose.slides.Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Adiciona um AutoShape definido como Rectangle
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // Define o tipo de preenchimento da forma
    aShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    // Define o modo de preenchimento de imagem da forma
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    // Define a imagem para preencher a forma
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
    // Especifica os deslocamentos da imagem a partir da borda correspondente da caixa delimitadora da forma
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    // Grava o arquivo PPTX no disco
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Como posso descobrir quais formatos de imagem são suportados para PictureFrame?**

O Aspose.Slides suporta tanto imagens raster (PNG, JPEG, BMP, GIF, etc.) quanto imagens vetoriais (por exemplo, SVG) por meio do objeto de imagem atribuído a um [PictureFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pictureframe/). A lista de formatos suportados geralmente se sobrepõe às capacidades do mecanismo de conversão de slides e imagens.

**Como a adição de dezenas de imagens grandes afetará o tamanho e o desempenho do PPTX?**

Incorporar imagens grandes aumenta o tamanho do arquivo e o uso de memória; vincular imagens ajuda a manter o tamanho da apresentação pequeno, mas requer que os arquivos externos permaneçam acessíveis. O Aspose.Slides oferece a capacidade de adicionar imagens por link para reduzir o tamanho do arquivo.

**Como posso bloquear um objeto de imagem para evitar movimentos/redimensionamentos acidentais?**

Use [shape locks](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pictureframe/getpictureframelock/) para um [PictureFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pictureframe/) (por exemplo, desativar mover ou redimensionar). O mecanismo de bloqueio é suportado para vários tipos de forma, incluindo [PictureFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pictureframe/).

**A fidelidade vetorial do SVG é preservada ao exportar uma apresentação para PDF/imagens?**

O Aspose.Slides permite extrair um SVG de um [PictureFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pictureframe/) como o vetor original. Ao [exportar para PDF](/slides/pt/nodejs-java/convert-powerpoint-to-pdf/) ou [formatos raster](/slides/pt/nodejs-java/convert-powerpoint-to-png/), o resultado pode ser rasterizado dependendo das configurações de exportação; o fato de o SVG original ser armazenado como vetor é confirmado pelo comportamento de extração.