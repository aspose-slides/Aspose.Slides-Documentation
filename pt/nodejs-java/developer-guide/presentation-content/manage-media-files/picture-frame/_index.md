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
- imagem incorporada
- imagem vinculada
- extrair imagem
- imagem raster
- imagem SVG
- recortar imagem
- excluir áreas recortadas
- comprimir imagem
- StretchOffset
- formatação de quadro de imagem
- escala relativa
- efeito de imagem
- proporção
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Criar, formatar, vincular, recortar, extrair e comprimir quadros de imagem em apresentações com Aspose.Slides para Node.js via Java."
---
## **Visão geral**

Um picture frame é uma forma de slide que exibe uma imagem. No Aspose.Slides, o recurso de imagem e a forma que a exibe são objetos separados: um [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) possui recursos de imagem incorporados por meio de sua [ImageCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/imagecollection/), enquanto um [PictureFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pictureframe/) controla a posição, tamanho, formatação de linhas, rotação, recorte, efeitos de imagem e outras configurações ao nível da moldura.

Essa separação é útil quando a mesma imagem é exibida mais de uma vez. Adicione a imagem à apresentação uma única vez, mantenha o [PPImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ppimage/) retornado e use esse recurso de imagem ao criar quadros de imagem.

Quadros de imagem podem conter imagens raster, como PNG ou JPEG, e imagens vetoriais SVG. Eles também podem referenciar imagens vinculadas em vez de armazenar os bytes da imagem na apresentação. A escolha afeta portabilidade, tamanho do arquivo, extração e comportamento de exportação, portanto é útil decidir como a imagem deve ser armazenada antes de aplicar formatação ou otimização.

## **Adicionar e formatar uma imagem incorporada**

Para uma imagem incorporada, adicione os dados da imagem à apresentação e crie um quadro de imagem com [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shapecollection/#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-). A imagem passa a fazer parte do pacote da apresentação, de modo que a apresentação permanece autocontida quando é movida para outro computador.

O exemplo a seguir adiciona uma imagem PNG, cria um quadro com as dimensões nativas da imagem e aplica formatação de linha e rotação:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    pictureFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pictureFrame.getLineFormat().setWidth(3);
    pictureFrame.setRotation(15);

    presentation.save("picture-frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O quadro de imagem controla a geometria exibida; alterar o tamanho do quadro não altera as dimensões de pixel originais armazenadas no recurso de imagem incorporado. Essa distinção se torna importante ao recortar ou comprimir uma imagem posteriormente.

## **Usar escala relativa**

[PictureFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pictureframe/) expõe a escala relativa de largura e altura do quadro por meio de [setRelativeScaleWidth](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleWidth-float-) e [setRelativeScaleHeight](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleHeight-float-). Um valor de `1.0` corresponde a 100 % do tamanho original da imagem. A escala relativa é útil quando um fluxo de trabalho precisa preservar a relação com o tamanho da imagem fonte em vez de calcular as dimensões finais manualmente.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100, image);
    pictureFrame.setRelativeScaleWidth(java.newFloat(1.35));
    pictureFrame.setRelativeScaleHeight(java.newFloat(0.8));

    presentation.save("relative-scale.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A escala relativa altera as configurações de escala do quadro; ela não reamostra nem comprime a imagem incorporada.

## **Imagens incorporadas e vinculadas**

Uma imagem incorporada armazena os dados da imagem dentro da apresentação e, portanto, é a escolha mais segura para portabilidade e renderização previsível. Uma imagem vinculada armazena um caminho externo por meio do método [Picture.setLinkPathLong](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/picture/#setLinkPathLong-java.lang.String-) em vez de incorporar os dados da imagem da mesma forma.

Imagens vinculadas podem reduzir a quantidade de dados de imagem armazenados no PPTX, mas introduzem uma dependência externa. O arquivo vinculado deve permanecer acessível à aplicação que abre ou renderiza a apresentação. Se o caminho mudar, o arquivo for movido ou o recurso ficar indisponível, a imagem vinculada pode não ser exibida como esperado. Para apresentações que precisam ser enviadas por e‑mail, arquivadas ou renderizadas em ambientes isolados, imagens incorporadas costumam ser mais confiáveis.

### **Adicionar uma imagem vinculada**

O exemplo a seguir cria um quadro de imagem e aponta para um arquivo de imagem local. Ele trata apenas de vinculação de imagem; a vinculação de vídeo é um fluxo de mídia separado e foi intencionalmente não misturada neste exemplo.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const path = require("path");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 180, null);
    const linkPath = path.resolve("image.png");
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong(linkPath);

    presentation.save("linked-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Use links quando o gerenciamento de arquivos externos for intencional. Não os use apenas como substituto da compressão: um PPTX pequeno com dependências de imagem quebradas costuma ser menos útil que uma apresentação maior e autocontida.

## **Extrair imagens de quadros de imagem**

Antes de extrair uma imagem de uma apresentação existente, verifique se a forma é realmente um [PictureFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pictureframe/) e se contém uma imagem incorporada. Quadros de imagem vinculados podem não conter bytes de imagem que possam ser extraídos da mesma forma.

### **Extrair uma imagem raster**

A API de imagem moderna usa [IImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/iimage/) diretamente. O exemplo a seguir encontra a primeira imagem raster incorporada em um slide e a salva como PNG:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            continue;
        }

        const embeddedImage = shape.getPictureFormat().getPicture().getImage();
        if (embeddedImage == null || embeddedImage.getSvgImage() != null) {
            continue;
        }

        const rasterImage = embeddedImage.getImage();
        try {
            rasterImage.save("extracted-image.png", aspose.slides.ImageFormat.Png);
        } finally {
            rasterImage.dispose();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

Salvar via [IImage.save](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/iimage/#save) converte a imagem extraída para o formato de saída solicitado. Se precisar dos bytes codificados armazenados na apresentação em vez de um arquivo raster convertido, use os dados binários do recurso de imagem.

### **Extrair uma imagem SVG**

Para uma imagem SVG, o [PPImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ppimage/) expõe um objeto [SvgImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/svgimage/). Isso permite recuperar os dados SVG diretamente em vez de rasterizar a imagem primeiro.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            continue;
        }

        const embeddedImage = shape.getPictureFormat().getPicture().getImage();
        const svgImage = embeddedImage != null ? embeddedImage.getSvgImage() : null;
        if (svgImage == null) {
            continue;
        }

        fs.writeFileSync("extracted-image.svg", svgImage.getSvgData());
        break;
    }
} finally {
    presentation.dispose();
}
```

Manter o conteúdo SVG como SVG preserva a fonte vetorial dentro da apresentação. Exportações raster, como PNG ou JPEG, necessariamente renderizam esse conteúdo vetorial em pixels. A exportação de slides para PDF ou SVG também é uma operação de renderização, portanto os gráficos exportados não devem ser tratados como uma cópia bit‑a‑bit do SVG incorporado original; use os dados de [SvgImage.getSvgData](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/svgimage/#getSvgData--) quando o recurso vetorial original for necessário.

## **Recortar uma imagem**

O recorte altera qual parte da imagem é visível dentro do quadro. Os valores de recorte em [PictureFillFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/picturefillformat/) são porcentagens das dimensões da imagem fonte. O recorte não exclui inicialmente os pixels ocultos da imagem incorporada; ele apenas altera a região visível.

O exemplo a seguir localiza um quadro de imagem de forma segura e aplica valores de recorte:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        pictureFrame.getPictureFormat().setCropLeft(java.newFloat(23.6));
        pictureFrame.getPictureFormat().setCropRight(java.newFloat(21.5));
        pictureFrame.getPictureFormat().setCropTop(java.newFloat(3));
        pictureFrame.getPictureFormat().setCropBottom(java.newFloat(31));
        presentation.save("cropped-image.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Como os dados da imagem oculta ainda estão presentes, o recorte pode ser alterado posteriormente sem perder os pixels originais. Se o tamanho do arquivo for mais importante que a reversibilidade, as regiões recortadas podem ser removidas fisicamente conforme descrito na próxima seção.

## **Remover dados de imagem recortados**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) remove os dados da imagem fora do retângulo de recorte atual e devolve o recurso de imagem resultante. Isso pode reduzir o tamanho do arquivo, mas trata‑se de uma otimização destrutiva: após a apresentação ser salva, os pixels removidos não estão mais disponíveis para uma operação de desfazer recorte.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const croppedImage = pictureFrame.getPictureFormat().deletePictureCroppedAreas();
        if (croppedImage != null) {
            presentation.save("cropped-data-removed.pptx", aspose.slides.SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

O método pode adicionar um novo recurso de imagem à apresentação. Se a imagem original também for usada por outros quadros de imagem, esses quadros ainda precisarão do recurso existente, de modo que excluir áreas recortadas não reduz necessariamente o número total de imagens. Recortar conteúdo WMF ou EMF com este método rasteriza o resultado recortado para PNG.

## **Comprimir imagens raster**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) reduz a resolução da imagem raster em relação ao tamanho em que a imagem é exibida. Ele também pode remover regiões recortadas na mesma operação. O método devolve `true` quando a imagem foi redimensionada ou recortada e `false` quando nenhuma alteração foi necessária.

Use um valor predefinido de [PicturesCompression](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/picturescompression/) quando uma resolução alvo padrão for suficiente:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const compressed = pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi150);
        console.log(compressed ? "The image was compressed." : "No compression was necessary.");
        presentation.save("compressed-image.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Um valor DPI positivo personalizado pode ser passado em vez de um valor predefinido quando um alvo específico for necessário.

A compressão destina‑se a imagens raster. Conteúdos SVG e metafile não são reduzidos por este fluxo de compressão raster. Também lembre‑se de que resolução menor e regiões recortadas excluídas não podem ser recuperadas da apresentação otimizada. Escolha a resolução alvo com base no maior tamanho em que a imagem será realmente visualizada ou exportada, em vez de aplicar o DPI mais baixo globalmente.

## **Inspecionar efeitos de imagem**

Os efeitos de imagem são armazenados na imagem usada pelo quadro. A coleção de transformações da imagem pode conter efeitos como modulação alfa fixa para transparência e luminância para brilho e contraste. O exemplo abaixo lê com segurança ambos os tipos de efeitos do primeiro quadro de imagem em um slide:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        for (let i = 0; i < imageTransform.size(); i++) {
            const effect = imageTransform.get_Item(i);
            if (java.instanceOf(effect, "com.aspose.slides.IAlphaModulateFixed")) {
                const transparency = 100 - effect.getAmount();
                console.log("Transparency: " + transparency);
            }

            if (java.instanceOf(effect, "com.aspose.slides.ILuminance")) {
                const luminance = effect.getEffective();
                console.log("Brightness: " + luminance.getBrightness());
                console.log("Contrast: " + luminance.getContrast());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Esses efeitos alteram como a imagem é renderizada no quadro; eles não reescrevem os bytes da imagem incorporada original.

## **Bloquear a geometria do quadro de imagem**

As configurações de [PictureFrameLock](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pictureframelock/) controlam quais operações de edição são desativadas para um quadro de imagem. Por exemplo, [setAspectRatioLocked](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) preserva as proporções da forma enquanto ela é redimensionada.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    presentation.save("locked-picture-frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O bloqueio se aplica à forma do quadro de imagem. Ele não força a imagem fonte a ser reamostrada ou permanentemente alterada para a mesma proporção.

## **Ajustar os valores StretchOffset**

Quando o modo de preenchimento da imagem é stretch, os valores stretch‑offset em [PictureFillFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/picturefillformat/) definem o retângulo de preenchimento relativo à caixa delimitadora do quadro de imagem. Percentuais positivos criam um recuo a partir de uma borda, enquanto percentuais negativos criam um extravasamento.

Isso difere do recorte. Valores de recorte selecionam qual parte da imagem fonte fica visível; stretch offsets alteram o retângulo no qual o preenchimento da imagem visível é esticado.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 400, 300, image);
    pictureFrame.getPictureFormat().setPictureFillMode(java.newByte(aspose.slides.PictureFillMode.Stretch));
    pictureFrame.getPictureFormat().setStretchOffsetLeft(java.newFloat(12));
    pictureFrame.getPictureFormat().setStretchOffsetRight(java.newFloat(12));
    pictureFrame.getPictureFormat().setStretchOffsetTop(java.newFloat(8));
    pictureFrame.getPictureFormat().setStretchOffsetBottom(java.newFloat(8));

    presentation.save("stretch-offsets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Use stretch offsets para posicionamento de preenchimento. Use propriedades de recorte quando o objetivo for ocultar as bordas da imagem fonte.

## **Considerações sobre armazenamento, tamanho de arquivo e exportação**

Os principais trade‑offs são mais fáceis de gerenciar quando o armazenamento de imagens e a formatação de quadros de imagem são tratados separadamente:

- **Imagens incorporadas** tornam a apresentação autocontida e são as mais confiáveis para compartilhamento e renderização no servidor, mas imagens raster grandes aumentam o tamanho do PPTX e o uso de memória.
- **Imagens vinculadas** podem manter o pacote menor, porém a apresentação depende de arquivos externos que permaneçam disponíveis nos caminhos ou locais armazenados.
- **Recorte** é inicialmente não destrutivo. Os pixels ocultos permanecem incorporados até que áreas recortadas sejam explicitamente excluídas ou removidas durante a compressão.
- **Compressão** pode reduzir o tamanho do arquivo substancialmente para imagens raster superdimensionadas, porém sacrifica a resolução fonte. Deve ser aplicada depois que o tamanho final na slide for conhecido.
- **Imagens SVG** devem permanecer como SVG quando a preservação vetorial for importante. Extraia o SVG incorporado diretamente quando precisar do recurso vetorial em si. Exportações de slide raster, como PNG ou JPEG, sempre convertem o slide renderizado em pixels.
- **Imagens repetidas** devem reutilizar um recurso [PPImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ppimage/) existente sempre que possível, em vez de carregar o mesmo arquivo repetidamente no fluxo de trabalho da apresentação.

Para apresentações grandes, a otimização de imagens costuma ser mais eficaz quando realizada seletivamente: mantenha logotipos e diagramas como conteúdo vetorial, comprima fotografias de acordo com seu tamanho real de exibição, remova pixels recortados somente quando edição posterior não for necessária e evite links externos, a menos que o gerenciamento de dependências faça parte do design de implantação.

## **Perguntas frequentes**

**Qual é a diferença entre um quadro de imagem e um recurso de imagem?**

Um [PPImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ppimage/) representa um recurso de imagem associado à apresentação. Um [PictureFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pictureframe/) é uma forma em um slide que exibe uma imagem e armazena geometria e formatação ao nível da moldura, como tamanho, rotação, valores de recorte, efeitos e bloqueios.

**Devo incorporar ou vincular imagens?**

Incorpore imagens quando a apresentação precisar ser portátil, arquivada ou renderizada sem acesso a recursos externos. Vincule imagens apenas quando manter os arquivos de imagem fora do PPTX for intencional e os locais externos puderem ser mantidos de forma confiável.

**O recorte reduz o tamanho do arquivo PPTX?**

Não por si só. Configurações de recorte padrão ocultam partes da imagem fonte, mas mantêm os pixels subjacentes. Use [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) ou compressão de imagem com remoção de áreas recortadas quando esses pixels puderem ser descartados permanentemente.

**Posso restaurar a qualidade da imagem após a compressão?**

Não. A compressão pode reduzir a resolução raster armazenada e a remoção de regiões recortadas descarta dados de imagem. Mantenha a imagem fonte original fora da apresentação se edições de alta resolução posteriores forem necessárias.

**Como devo tratar imagens SVG?**

Mantenha o conteúdo SVG como SVG quando a fidelidade vetorial for importante. O [SvgImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/svgimage/) incorporado pode ser extraído diretamente. Renderizar um slide para um formato raster, como PNG ou JPEG, rasteriza o SVG como parte da imagem do slide.

**Como evitar casts inseguros ao ler slides existentes?**

Verifique o tipo da forma antes de usar membros específicos de quadro de imagem. Uma verificação `java.instanceOf` contra [PictureFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pictureframe/) evita casts inválidos e permite que o código trate slides que não contenham quadros de imagem.