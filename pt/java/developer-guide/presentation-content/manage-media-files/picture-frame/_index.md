---
title: Gerenciar Quadros de Imagem em Apresentações Usando Java
linktitle: Quadro de Imagem
type: docs
weight: 10
url: /pt/java/picture-frame/
keywords:
- quadro de imagem
- adicionar quadro de imagem
- criar quadro de imagem
- adicionar imagem
- criar imagem
- extrair imagem
- imagem raster
- imagem vetorial
- recortar imagem
- área recortada
- propriedade StretchOff
- formatação de quadro de imagem
- propriedades de quadro de imagem
- escala relativa
- efeito de imagem
- proporção de aspecto
- transparência de imagem
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Adicione quadros de imagem a apresentações PowerPoint e OpenDocument com Aspose.Slides para Java. Otimize seu fluxo de trabalho e melhore o design dos slides."
---
## **Introdução**

Um quadro de imagem é uma forma que contém uma imagem — é como uma foto em uma moldura.

Você pode adicionar uma imagem a um slide por meio de um quadro de imagem. Dessa forma, você formata a imagem formatando o quadro de imagem.

{{% alert  title="Tip" color="primary" %}} 
A Aspose fornece conversores gratuitos — [JPEG para PowerPoint](https://products.aspose.app/slides/pt/import/jpg-to-ppt) e [PNG para PowerPoint](https://products.aspose.app/slides/pt/import/png-to-ppt) — que permitem que as pessoas criem apresentações rapidamente a partir de imagens. 
{{% /alert %}} 

## **Criar um Quadro de Imagem**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation).
2. Obtenha a referência de um slide pelo seu índice. 
3. Crie um objeto [IPPImage]() adicionando uma imagem à [IImagescollection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IImageCollection) associada ao objeto de apresentação que será usado para preencher a forma.
4. Especifique a largura e a altura da imagem.
5. Crie um [PictureFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/PictureFrame) com base na largura e altura da imagem usando o método `AddPictureFrame` exposto pelo objeto de forma associado ao slide referenciado.
6. Adicione um quadro de imagem (contendo a foto) ao slide.
7. Salve a apresentação modificada como um arquivo PPTX.

Este código Java mostra como criar um quadro de imagem:

```java
// Instancia a classe Presentation que representa um arquivo PPTX
Presentation pres = new Presentation();
try {
    // Obtém o primeiro slide
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instancia a classe Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Adiciona um quadro de imagem com a mesma altura e largura da imagem
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Grava o arquivo PPTX no disco
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 
Os quadros de imagem permitem criar rapidamente slides de apresentação baseados em imagens. Quando você combina o quadro de imagem com as opções de gravação do Aspose.Slides, pode manipular operações de entrada/saída para converter imagens de um formato para outro. Você pode querer ver estas páginas: converter [imagem para JPG](https://products.aspose.com/slides/pt/java/conversion/image-to-jpg/); converter [JPG para imagem](https://products.aspose.com/slides/pt/java/conversion/jpg-to-image/); converter [JPG para PNG](https://products.aspose.com/slides/pt/java/conversion/jpg-to-png/), converter [PNG para JPG](https://products.aspose.com/slides/pt/java/conversion/png-to-jpg/); converter [PNG para SVG](https://products.aspose.com/slides/pt/java/conversion/png-to-svg/), converter [SVG para PNG](https://products.aspose.com/slides/pt/java/conversion/svg-to-png/).
{{% /alert %}}

## **Criar um Quadro de Imagem com Escala Relativa**

Alterando a escala relativa de uma imagem, você pode criar um quadro de imagem mais complexo. 

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation).
2. Obtenha a referência de um slide pelo seu índice. 
3. Adicione uma imagem à coleção de imagens da apresentação.
4. Crie um objeto [IPPImage](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IPPImage) adicionando uma imagem à [IImagescollection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IImageCollection) associada ao objeto de apresentação que será usado para preencher a forma.
5. Especifique a largura e altura relativas da imagem no quadro de imagem.
6. Salve a apresentação modificada como um arquivo PPTX.

Este código Java mostra como criar um quadro de imagem com escala relativa:

```java
// Instancia a classe Presentation que representa o PPTX
Presentation pres = new Presentation();
try {
    // Obtém o primeiro slide
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instancia a classe Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // Adiciona um Quadro de Imagem com altura e largura equivalentes da Imagem
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Definindo escala relativa de largura e altura
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // Grava o arquivo PPTX no disco
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Extrair Imagens Rasterizadas de Quadros de Imagem**

Você pode extrair imagens rasterizadas de objetos [PictureFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/PictureFrame) e salvá-las em PNG, JPG e outros formatos. O exemplo de código abaixo demonstra como extrair uma imagem do documento "sample.pptx" e salvá‑la em formato PNG.

```java
Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IShape firstShape = firstSlide.getShapes().get_Item(0);

    if (firstShape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) firstShape;
        try {
            IImage slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
            slideImage.save("slide_1_shape_1.png", ImageFormat.Png);
        } finally {
            if (slideImage != null) slideImage.dispose();
        }
    }
} catch (IOException e) {
} finally {
    presentation.dispose();
}
```

## **Extrair Imagens SVG de Quadros de Imagem**

Quando uma apresentação contém gráficos SVG colocados dentro de formas [PictureFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/pictureframe/), o Aspose.Slides for Java permite recuperar as imagens vetoriais originais com total fidelidade. Percorrendo a coleção de formas do slide, você pode identificar cada [PictureFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/pictureframe/), verificar se o [IPPImage](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ippimage/) subjacente contém conteúdo SVG e então salvar essa imagem em disco ou em um stream no seu formato SVG nativo.

O exemplo de código a seguir demonstra como extrair uma imagem SVG de um quadro de imagem:

```java
Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    if (shape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) shape;
        ISvgImage svgImage = pictureFrame.getPictureFormat().getPicture().getImage().getSvgImage();

        FileOutputStream fos = new FileOutputStream("output.svg");
        fos.write(svgImage.getSvgData());
        fos.close();
    }
} catch (IOException e) {
    System.out.println(e.getMessage());
} finally {
    presentation.dispose();
}
```

## **Obter Transparência de uma Imagem**

Aspose.Slides permite obter o efeito de transparência aplicado a uma imagem. Este código Java demonstra a operação:

```java
Presentation presentation = new Presentation("Test.pptx");

var pictureFrame = (IPictureFrame) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
for (var effect : imageTransform) {
    if (effect instanceof IAlphaModulateFixed) {
        var alphaModulateFixed = (IAlphaModulateFixed) effect;
        var transparencyValue = 100 - alphaModulateFixed.getAmount();
        System.out.println("Picture transparency: " + transparencyValue);
    }
}
```

## **Formatação de Quadro de Imagem**

Aspose.Slides oferece muitas opções de formatação que podem ser aplicadas a um quadro de imagem. Usando essas opções, você pode alterar um quadro de imagem para que atenda a requisitos específicos.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation).
2. Obtenha a referência de um slide pelo seu índice. 
3. Crie um objeto [IPPImage](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IPPImage) adicionando uma imagem à [IImagescollection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IImageCollection) associada ao objeto de apresentação que será usado para preencher a forma.
4. Especifique a largura e a altura da imagem.
5. Crie um `PictureFrame` com base na largura e altura da imagem usando o método [AddPictureFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) exposto ao objeto [IShapes](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IShapeCollection) associado ao slide referenciado.
6. Adicione o quadro de imagem (contendo a foto) ao slide.
7. Defina a cor da linha do quadro de imagem.
8. Defina a largura da linha do quadro de imagem.
9. Gire o quadro de imagem fornecendo um valor positivo ou negativo.
   * Um valor positivo gira a imagem no sentido horário. 
   * Um valor negativo gira a imagem no sentido anti‑horário.
10. Adicione o quadro de imagem (contendo a foto) ao slide.
11. Salve a apresentação modificada como um arquivo PPTX.

Este código Java demonstra o processo de formatação de quadros de imagem:

```java
// Instancia a classe Presentation que representa o PPTX
Presentation pres = new Presentation();
try {
    // Obtém o primeiro slide
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instancia a classe Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Adiciona um Quadro de Imagem com altura e largura equivalentes da Imagem
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Aplica alguma formatação ao PictureFrameEx
    pf.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    
    // Grava o arquivo PPTX no disco
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Tip" color="primary" %}}

A Aspose desenvolveu recentemente um [Collage Maker gratuito](https://products.aspose.app/slides/pt/collage). Se precisar [mesclar JPG/JPEG](https://products.aspose.app/slides/pt/collage/jpg) ou imagens PNG, [criar grades a partir de fotos](https://products.aspose.app/slides/pt/collage/photo-grid), pode usar este serviço. 
{{% /alert %}}

## **Adicionar uma Imagem como Link**

Para evitar tamanhos grandes de apresentação, você pode adicionar imagens (ou vídeos) por meio de links em vez de incorporar os arquivos diretamente nas apresentações. Este código Java mostra como adicionar uma imagem e um vídeo em um placeholder:

```java
Presentation presentation = new Presentation("input.pptx");
try {
    ArrayList<IShape> shapesToRemove = new ArrayList<IShape>();
    int shapesCount = presentation.getSlides().get_Item(0).getShapes().size();

    for (int i = 0; i < shapesCount; i++)
    {
        IShape autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(i);

        if (autoShape.getPlaceholder() == null)
        {
            continue;
        }

        switch (autoShape.getPlaceholder().getType())
        {
            case PlaceholderType.Picture:
                IPictureFrame pictureFrame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle,
                        autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), null);

                pictureFrame.getPictureFormat().getPicture().setLinkPathLong(
                        "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");

                shapesToRemove.add(autoShape);
                break;

            case PlaceholderType.Media:
                IVideoFrame videoFrame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(
                        autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), "");

                videoFrame.getPictureFormat().getPicture().setLinkPathLong(
                        "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");

                videoFrame.setLinkPathLong("https://youtu.be/t_1LYZ102RA");

                shapesToRemove.add(autoShape);
                break;
        }
    }

    for (IShape shape : shapesToRemove)
    {
        presentation.getSlides().get_Item(0).getShapes().remove(shape);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Recortar Imagens**

Este código Java mostra como recortar uma imagem existente em um slide:

```java
Presentation pres = new Presentation();
// Cria novo objeto de imagem
try {
    IPPImage picture;
    IImage image = Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Adiciona um PictureFrame a um slide
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // Recorta a imagem (valores em percentual)
    picFrame.getPictureFormat().setCropLeft(23.6f);
    picFrame.getPictureFormat().setCropRight(21.5f);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);

    // Salva o resultado
    pres.save(outPptxFile, SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Excluir Áreas Recortadas de um Quadro**

Se quiser excluir as áreas recortadas de uma imagem contida em um quadro, pode usar o método [deletePictureCroppedAreas()](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) . Esse método devolve a imagem recortada ou a imagem original se o recorte for desnecessário.

Este código Java demonstra a operação:

```java
Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Obtém o PictureFrame do primeiro slide
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Exclui áreas recortadas da imagem do PictureFrame e retorna a imagem recortada
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // Salva o resultado
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
O método [deletePictureCroppedAreas()](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) adiciona a imagem recortada à coleção de imagens da apresentação. Se a imagem for usada apenas no [PictureFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/pictureframe/) processado, essa configuração pode reduzir o tamanho da apresentação. Caso contrário, o número de imagens na apresentação resultante aumentará.

Esse método converte arquivos metafile WMF/EMF em imagens raster PNG durante a operação de recorte. 
{{% /alert %}}

## **Comprimir Imagens**

Você pode comprimir uma imagem em uma apresentação usando o método [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) . Esse método comprime uma imagem reduzindo seu tamanho com base no tamanho da forma e na resolução especificada, com a opção de excluir áreas recortadas.

Ele ajusta o tamanho e a resolução da imagem de forma semelhante ao recurso **Formato da Imagem -> Comprimir Imagens -> Resolução** do PowerPoint.

Os exemplos Java a seguir demonstram como comprimir uma imagem em uma apresentação especificando uma resolução alvo e, opcionalmente, removendo áreas recortadas:

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Compactar a imagem com resolução alvo de 150 DPI (resolução da Web) e remover áreas recortadas.
    boolean result = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);

    // Check the result of the compression.
    if (result) {
        System.out.println("Image successfully compressed.");
    } else {
        System.out.println("Image compression failed or no changes were necessary.");
    }

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ou usando diretamente um valor DPI personalizado:

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Compactar a imagem para 150 DPI (resolução da web), removendo áreas recortadas.
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
O método converte a imagem para uma resolução menor com base no tamanho da forma e no DPI fornecido. Regiões recortadas também podem ser excluídas para otimizar o tamanho do arquivo.  
Se a imagem for um metafile (WMF/EMF) ou SVG, a compressão não será aplicada. Além disso, a qualidade JPEG é preservada ou ligeiramente reduzida conforme a resolução, de modo semelhante ao tratamento de JPEGs de alta resolução pelo PowerPoint.
{{% /alert %}}

## **Bloquear Proporção de Aspecto**

Se quiser que uma forma que contém uma imagem mantenha sua proporção de aspecto mesmo após mudar as dimensões da imagem, pode usar o método [setAspectRatioLocked](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) para definir a configuração *Lock Aspect Ratio*. 

Este código Java mostra como bloquear a proporção de aspecto de uma forma:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ILayoutSlide layout = pres.getLayoutSlides().getByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.getSlides().addEmptySlide(layout);
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    IPictureFrame pictureFrame = emptySlide.getShapes().addPictureFrame(
            ShapeType.Rectangle, 50, 150, presImage.getWidth(), presImage.getHeight(), picture);

    //     definir a forma para preservar a proporção de aspecto ao redimensionar
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
Esta configuração *Lock Aspect Ratio* preserva apenas a proporção da forma e não da imagem que ela contém.
{{% /alert %}}

## **Usar a Propriedade StretchOff**

Usando as propriedades [StretchOffsetLeft](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) e [StretchOffsetBottom](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) da interface [IPictureFillFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IPictureFillFormat) e da classe [PictureFillFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IPictureFillFormat), você pode especificar um retângulo de preenchimento. 

Quando o alongamento é especificado para uma imagem, um retângulo de origem é dimensionado para caber no retângulo de preenchimento especificado. Cada borda do retângulo de preenchimento é definida por um deslocamento percentual a partir da borda correspondente da caixa delimitadora da forma. Um percentual positivo indica um recuo, enquanto um percentual negativo indica um sobresalimento.

1. Crie uma instância da [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation) class.
2. Obtenha a referência de um slide pelo seu índice.
3. Adicione um retângulo `AutoShape`. 
4. Crie uma imagem.
5. Defina o tipo de preenchimento da forma.
6. Defina o modo de preenchimento da forma com imagem.
7. Adicione uma imagem definida para preencher a forma.
8. Especifique os deslocamentos da imagem a partir da borda correspondente da caixa delimitadora da forma
9. Salve a apresentação modificada como um arquivo PPTX.

Este código Java demonstra um processo no qual a propriedade StretchOff é usada:

```java
// Instancia a classe Presentation que representa um arquivo PPTX
Presentation pres = new Presentation();
try {
    // Obtém o primeiro slide
    ISlide slide = pres.getSlides().get_Item(0);

    // Instancia a classe ImageEx
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Adiciona um AutoShape definido como Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Define o tipo de preenchimento da forma
    aShape.getFillFormat().setFillType(FillType.Picture);

    // Define o modo de preenchimento de imagem da forma
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // Define a imagem que preenche a forma
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Especifica os deslocamentos da imagem a partir da borda correspondente da caixa delimitadora da forma
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    
    // Grava o arquivo PPTX no disco
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Como posso descobrir quais formatos de imagem são suportados para PictureFrame?**

Aspose.Slides suporta tanto imagens raster (PNG, JPEG, BMP, GIF etc.) quanto imagens vetoriais (por exemplo, SVG) por meio do objeto de imagem atribuído a um [PictureFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/pictureframe/). A lista de formatos suportados geralmente coincide com as capacidades do mecanismo de conversão de slides e imagens.

**Como a adição de dezenas de imagens grandes afetará o tamanho e o desempenho do PPTX?**

Incorporar imagens grandes aumenta o tamanho do arquivo e o uso de memória; vincular imagens ajuda a manter o tamanho da apresentação mais baixo, mas requer que os arquivos externos permaneçam acessíveis. Aspose.Slides fornece a capacidade de adicionar imagens por link para reduzir o tamanho do arquivo.

**Como posso bloquear um objeto de imagem para evitar movimentação/redimensionamento acidental?**

Use [travas de forma](https://reference.aspose.com/slides/pt/java/com.aspose.slides/pictureframe/#getPictureFrameLock--) para um [PictureFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/pictureframe/) (por exemplo, desabilitar movimentação ou redimensionamento). O mecanismo de bloqueio é descrito para formas em um artigo separado de [proteção](/slides/pt/java/applying-protection-to-presentation/) e é suportado para vários tipos de forma, incluindo [PictureFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/pictureframe/).

**A fidelidade vetorial do SVG é preservada ao exportar uma apresentação para PDF/imagens?**

Aspose.Slides permite extrair um SVG de um [PictureFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/pictureframe/) como o vetor original. Ao [exportar para PDF](/slides/pt/java/convert-powerpoint-to-pdf/) ou [formatos raster](/slides/pt/java/convert-powerpoint-to-png/), o resultado pode ser rasterizado dependendo das configurações de exportação; o fato de o SVG original ser armazenado como vetor é confirmado pelo comportamento de extração.