---
title: Otimizar o gerenciamento de imagens em apresentações usando JavaScript
linktitle: Gerenciar Imagens
type: docs
weight: 10
url: /pt/nodejs-java/image/
keywords:
- adicionar imagem
- adicionar foto
- adicionar bitmap
- substituir imagem
- substituir foto
- da web
- plano de fundo
- adicionar PNG
- adicionar JPG
- adicionar SVG
- adicionar EMF
- adicionar WMF
- adicionar TIFF
- PowerPoint
- OpenDocument
- apresentação
- EMF
- SVG
- Node.js
- JavaScript
- Aspose.Slides
description: "Simplifique o gerenciamento de imagens no PowerPoint e OpenDocument com JavaScript e Aspose.Slides para Node.js, otimizando o desempenho e automatizando seu fluxo de trabalho."
---
## **Introdução**

Imagens tornam as apresentações mais envolventes e interessantes. No Microsoft PowerPoint, você pode inserir imagens de um arquivo, da internet ou de outros locais nos slides. Da mesma forma, o Aspose.Slides permite adicionar imagens aos slides em suas apresentações por meio de diferentes procedimentos. 

{{% alert  title="Tip" color="primary" %}} 
A Aspose fornece conversores gratuitos—[JPEG para PowerPoint](https://products.aspose.app/slides/pt/import/jpg-to-ppt) e [PNG para PowerPoint](https://products.aspose.app/slides/pt/import/png-to-ppt)—que permitem que as pessoas criem apresentações rapidamente a partir de imagens. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
Se você quiser adicionar uma imagem como um objeto de quadro—especialmente se planeja usar opções de formatação padrão para alterar seu tamanho, adicionar efeitos etc.—veja [Picture Frame](https://docs.aspose.com/slides/pt/nodejs-java/picture-frame/). 
{{% /alert %}} 

O Aspose.Slides oferece suporte a operações com imagens nesses formatos populares: JPEG, PNG, GIF e outros. 

## **Adicionando Imagens Armazenadas Localmente aos Slides**

Você pode adicionar uma ou várias imagens do seu computador a um slide em uma apresentação. Este código de exemplo em JavaScript mostra como adicionar uma imagem a um slide:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Adicionando Imagens do Stream aos Slides**

Se a imagem que você deseja adicionar a um slide não estiver disponível no seu computador, você pode adicioná‑la diretamente da web. 

Este código de exemplo mostra como adicionar uma imagem da web a um slide em JavaScript:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Acessa o primeiro slide
    var sld = pres.getSlides().get_Item(0);
    // Carrega um arquivo excel para stream
    var readStream = fs.readFileSync("book1.xlsx");
    var byteArray = Array.from(readStream);
    // Cria um objeto de dados para incorporação
    var dataInfo = new aspose.slides.OleEmbeddedDataInfo(java.newArray("byte", byteArray), "xlsx");
    // Adiciona um objeto Ole Frame
    var oleObjectFrame = sld.getShapes().addOleObjectFrame(0, 0, pres.getSlideSize().getSize().getWidth(), pres.getSlideSize().getSize().getHeight(), dataInfo);
    // Grava o arquivo PPTX no disco
    pres.save("OleEmbed_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Adicionando Imagens aos Mestres de Slides**

Um mestre de slide é o slide superior que armazena e controla informações (tema, layout etc.) de todos os slides abaixo dele. Portanto, ao adicionar uma imagem a um mestre de slide, essa imagem aparece em todos os slides que utilizam esse mestre. 

Este código de exemplo em JavaScript mostra como adicionar uma imagem a um mestre de slide:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var masterSlide = slide.getLayoutSlide().getMasterSlide();
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    masterSlide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Adicionando Imagens como Plano de Fundo de Slide**

Você pode decidir usar uma imagem como plano de fundo de um slide específico ou de vários slides. Nesse caso, consulte *[Configurar Imagens como Plano de Fundo de Slides](https://docs.aspose.com/slides/pt/nodejs-java/presentation-background/#setting-images-as-background-for-slides)*.

## **Adicionando SVG a Apresentações**

Você pode adicionar ou inserir qualquer imagem em uma apresentação usando o método [addPictureFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) que pertence à classe [ShapeCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ShapeCollection). 

Para criar um objeto de imagem baseado em SVG, você pode fazer desta forma:

1. Crie um objeto SvgImage para inseri‑lo na ImageShapeCollection
2. Crie um objeto PPImage a partir de ISvgImage
3. Crie um objeto PictureFrame usando a classe PPImage

Este código de exemplo mostra como implementar as etapas acima para adicionar uma imagem SVG em uma apresentação:
```javascript
// Instanciar a classe Presentation que representa um arquivo PPTX
var pres = new aspose.slides.Presentation();
try {
    var svgContent = java.newInstanceSync("java.lang.String", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "image.svg")));
    var svgImage = new aspose.slides.SvgImage(svgContent);
    var ppImage = pres.getImages().addImage(svgImage);
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, ppImage.getWidth(), ppImage.getHeight(), ppImage);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Convertendo SVG em um Conjunto de Formas**

A conversão de SVG em um conjunto de formas do Aspose.Slides é semelhante à funcionalidade do PowerPoint usada para trabalhar com imagens SVG:

![PowerPoint Popup Menu](img_01_01.png)

A funcionalidade é fornecida por uma das sobrecargas do método [addGroupShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ShapeCollection#addGroupShape-aspose.slides.ISvgImage-float-float-float-float-) da classe [ShapeCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ShapeCollection) que recebe um objeto [SvgImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SvgImage) como primeiro argumento.

Este código de exemplo mostra como usar o método descrito para converter um arquivo SVG em um conjunto de formas:
```javascript
// Criar nova apresentação
var presentation = new aspose.slides.Presentation();
try {
    // Ler o conteúdo do arquivo SVG
    var svgContent = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "image.svg"));
    // Criar objeto SvgImage
    var svgImage = new aspose.slides.SvgImage(svgContent);
    // Obter tamanho do slide
    var slideSize = presentation.getSlideSize().getSize();
    // Converter imagem SVG em grupo de formas dimensionando-a ao tamanho do slide
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(svgImage, 0.0, 0.0, slideSize.getWidth(), slideSize.getHeight());
    // Salvar apresentação no formato PPTX
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Adicionando Imagens como EMF em Slides**

O Aspose.Slides para Node.js via Java permite gerar imagens EMF a partir de planilhas Excel e adicionar as imagens como EMF em slides com o Aspose.Cells. 

Este código de exemplo mostra como executar a tarefa descrita:
```javascript
var book = java.newInstanceSync("aspose.cells.Workbook", "chart.xlsx");
var sheet = book.getWorksheets().get(0);
var options = java.newInstanceSync("aspose.cells.ImageOrPrintOptions");
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(java.getStaticFieldValue("ImageType", "EMF"));
var sr = java.newInstanceSync("SheetRender", sheet, options);
var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().removeAt(0);
    var EmfSheetName = "";
    for (var j = 0; j < sr.getPageCount(); j++) {
        EmfSheetName = ((("test" + sheet.getName()) + " Page") + (j + 1)) + ".out.emf";
        sr.toImage(j, EmfSheetName);
        var picture;
        var image = aspose.slides.Images.fromFile(EmfSheetName);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) {
                image.dispose();
            }
        }
        var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank));
        var m = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, pres.getSlideSize().getSize().getWidth(), pres.getSlideSize().getSize().getHeight(), picture);
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Substituindo Imagens na Coleção de Imagens**

O Aspose.Slides permite substituir imagens armazenadas na coleção de imagens de uma apresentação (incluindo as usadas por formas de slide). Esta seção mostra várias abordagens para atualizar imagens na coleção. A API fornece métodos simples para substituir uma imagem usando dados brutos em bytes, uma instância de [IImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/iimage/) ou outra imagem que já existe na coleção. 

Siga os passos abaixo:

1. Carregue o arquivo de apresentação que contém imagens usando a classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/).
2. Carregue uma nova imagem de um arquivo em um array de bytes.
3. Substitua a imagem alvo pela nova imagem usando o array de bytes.
4. Na segunda abordagem, carregue a imagem em um objeto [IImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/iimage/) e substitua a imagem alvo por esse objeto.
5. Na terceira abordagem, substitua a imagem alvo por uma imagem que já existe na coleção de imagens da apresentação.
6. Grave a apresentação modificada como um arquivo PPTX.

```js
// Instanciar a classe Presentation que representa um arquivo de apresentação.
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // A primeira maneira.
    const imageData = java.newArray("byte", Array.from(fs.readFileSync("image0.jpeg")));
    let oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);
    
    // A segunda maneira.
    const newImage = aspose.slides.Images.fromFile("image1.png");
    oldImage = presentation.getImages().get_Item(1);
    oldImage.replaceImage(newImage);
    newImage.dispose();
    
    // A terceira maneira.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));
    
    // Salvar a apresentação em um arquivo.
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Usando o conversor GRATUITO [Text to GIF](https://products.aspose.app/slides/pt/text-to-gif) da Aspose, você pode animar textos facilmente, criar GIFs a partir de textos etc. 
{{% /alert %}}

## **Perguntas Frequentes**

**A resolução original da imagem permanece intacta após a inserção?**

Sim. Os pixels originais são preservados, mas a aparência final depende de como a [imagem](/slides/pt/nodejs-java/picture-frame/) é dimensionada no slide e de qualquer compressão aplicada ao salvar.

**Qual é a melhor maneira de substituir o mesmo logotipo em dezenas de slides de uma só vez?**

Coloque o logotipo no slide mestre ou em um layout e substitua‑lo na coleção de imagens da apresentação — as atualizações serão propagadas para todos os elementos que utilizam esse recurso.

**Um SVG inserido pode ser convertido em formas editáveis?**

Sim. Você pode converter um SVG em um grupo de formas, após o qual as partes individuais se tornam editáveis com as propriedades padrão de forma.

**Como posso definir uma imagem como plano de fundo de vários slides ao mesmo tempo?**

[Defina a imagem como plano de fundo](/slides/pt/nodejs-java/presentation-background/) no slide mestre ou no layout relevante — todos os slides que utilizam esse mestre/layout herdarão o plano de fundo.

**Como impedir que a apresentação aumente muito de tamanho por causa de muitas imagens?**

Reutilize um único recurso de imagem em vez de duplicatas, escolha resoluções razoáveis, aplique compressão ao salvar e mantenha gráficos repetidos no mestre quando apropriado.