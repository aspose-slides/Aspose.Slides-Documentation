---
title: Otimizar o Gerenciamento de Imagens em Apresentações Usando PHP
linktitle: Gerenciar Imagens
type: docs
weight: 10
url: /pt/php-java/image/
keywords:
- adicionar imagem
- adicionar figura
- substituir imagem
- coleção de imagens
- quadro de imagem
- imagem vinculada
- fundo
- adicionar PNG
- adicionar JPG
- adicionar SVG
- SVG para formas
- recursos SVG externos
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Aprenda como adicionar, reutilizar, vincular, substituir e gerenciar imagens raster e SVG em apresentações PowerPoint e OpenDocument com Aspose.Slides para PHP via Java."
---
## **Introdução**

Aspose.Slides for PHP via Java oferece várias maneiras de trabalhar com imagens, e cada uma serve a um propósito diferente. Você pode armazenar uma imagem em uma apresentação, exibí‑la em um quadro de imagem, usá‑la como fundo de slide, vincular a uma imagem externa, substituir um recurso de imagem compartilhado ou converter conteúdo SVG em formas editáveis.

Este artigo foca em recursos de imagem e como eles são usados em toda a apresentação. Para recorte, transparência, efeitos, estiramento e outras formatações aplicadas a um quadro de imagem individual, consulte [Quadro de Imagem](/slides/pt/php-java/picture-frame/).

## **Entenda o Modelo de Imagem**

Os conceitos de API a seguir são intimamente relacionados, mas não intercambiáveis:

- A [coleção de imagens da apresentação](https://reference.aspose.com/slides/pt/php-java/aspose.slides/imagecollection/) armazena recursos de imagem usados pela apresentação. Use [ImageCollection::addImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/imagecollection/) para adicionar dados de imagem e obter um recurso [PPImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ppimage/).
- Um [quadro de imagem](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pictureframe/) é uma forma que exibe uma imagem em um slide, layout ou mestre. Use [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapecollection/addpictureframe/) para colocar um recurso de imagem em um slide.
- Um fundo de slide usa uma imagem como parte do preenchimento do slide, e não como uma forma. Portanto, não se comporta como um quadro de imagem.
- [PPImage::replaceImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ppimage/) substitui um recurso de imagem. Se vários elementos da apresentação usarem esse recurso, todos usarão a substituição.
- Converter um SVG em formas cria formas de slide editáveis. Após a conversão, o conteúdo não é mais gerenciado como um único recurso de imagem.

Um fluxo de trabalho típico é, portanto: adicionar dados de imagem à coleção de imagens, receber um [PPImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ppimage/), e então usar esse recurso em um ou mais quadros de imagem ou preenchimentos.

## **Adicionar uma Imagem Incorporada**

Para inserir uma imagem local, carregue o arquivo, adicione‑o à coleção de imagens e crie um quadro de imagem que use o `PPImage` retornado.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $image = Images::fromFile("photo.png");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, $ppImage);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

A imagem adicionada dessa forma está incorporada na apresentação, de modo que o arquivo resultante não depende da disponibilidade do arquivo de imagem original.

### **Adicionar uma Imagem da Web**

Quando uma imagem está disponível via HTTP ou HTTPS, baixe seus bytes, adicione‑os à coleção de imagens da apresentação e use o recurso de imagem retornado da mesma forma que uma imagem local.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $imageUrl = new Java("java.net.URL", "https://example.com/image.png");
    $connection = $imageUrl->openConnection();
    $connection->setConnectTimeout(10000);
    $connection->setReadTimeout(10000);

    $inputStream = $connection->getInputStream();
    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    try {
        $buffer = $Array->newInstance($Byte, 8192);
        $bufferLength = $Array->getLength($buffer);

        while (($bytesRead = java_values($inputStream->read($buffer, 0, $bufferLength))) != -1) {
            $outputStream->write($buffer, 0, $bytesRead);
        }

        $ppImage = $presentation->getImages()->addImage($outputStream->toByteArray());
        $slide = $presentation->getSlides()->get_Item(0);
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, $ppImage);
    } finally {
        if (!java_is_null($inputStream)) {
            $inputStream->close();
        }
        $outputStream->close();
    }

    $presentation->save("presentation-from-web.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Em aplicações de longa execução, reutilize um cliente HTTP ou estratégia de gerenciamento de conexões adequada ao aplicativo, em vez de criar repetidamente infraestrutura de rede desnecessária. Também valide URLs remotos, tamanhos de resposta e tipos de conteúdo quando a origem não for confiável.

## **Reutilizar Imagens em Vários Slides**

Se a mesma imagem for necessária mais de uma vez, adicione‑a à apresentação uma única vez e reutilize o [PPImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ppimage/) retornado ao criar quadros de imagem adicionais. Isso evita carregar repetidamente os mesmos dados de origem e torna explícita a relação entre o recurso de imagem compartilhado e seus usos.

Para gráficos que devem aparecer automaticamente em muitos slides, como o logotipo da empresa, considere colocar o quadro de imagem em um [master de slide](/slides/pt/php-java/slide-master/) ou layout em vez de adicionar uma forma equivalente a cada slide.

## **Usar uma Imagem como Fundo de Slide**

Uma imagem de fundo é atribuída ao preenchimento do slide; ela não é adicionada como uma forma de quadro de imagem. Isso é útil quando a imagem deve cobrir todo o fundo do slide e não deve ser manipulada como um objeto de slide normal.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = Images::fromFile("background.jpg");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Picture);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    $presentation->save("background-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Para opções adicionais de fundo, incluindo fundos de mestre e layout, veja [Fundo da Apresentação](/slides/pt/php-java/presentation-background/).

## **Imagens Incorporadas e Imagens Vinculadas**

Imagens incorporadas e vinculadas têm diferentes compensações de portabilidade e tamanho de arquivo:

- **Imagem incorporada:** os dados da imagem são armazenados dentro da apresentação. A apresentação é autocontida, mas o tamanho do arquivo inclui os dados da imagem.
- **Imagem vinculada:** a apresentação armazena um caminho ou URL para uma imagem externa. Isso pode reduzir o tamanho da apresentação, mas o recurso externo deve permanecer acessível quando a apresentação for aberta ou renderizada.

Uma imagem vinculada pode ser criada atribuindo o caminho ou URL externo através de [Picture::setLinkPathLong](https://reference.aspose.com/slides/pt/php-java/aspose.slides/picture/) em vez de incorporar os dados da imagem.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, null);
    $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://example.com/image.png");

    $presentation->save("linked-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Use imagens vinculadas apenas quando o ambiente de implantação puder acessar o recurso externo de forma confiável. Para apresentações que precisam funcionar off‑line ou ser movidas entre sistemas, imagens incorporadas são geralmente mais seguras.

## **Trabalhar com Imagens SVG**

SVG é um formato vetorial, podendo ser útil para ícones, diagramas e outros gráficos que devem escalar sem a mesma perda de detalhe que imagens raster. Aspose.Slides suporta SVG tanto como recurso de imagem quanto como fonte de formas editáveis de slide.

### **Adicionar um SVG como Imagem**

Crie um [SvgImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/svgimage/), adicione‑o à coleção de imagens e coloque o recurso de imagem resultante em um quadro de imagem.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SvgImage;

$presentation = new Presentation();
try {
    $svgContent = file_get_contents("icon.svg");
    $svgImage = new SvgImage($svgContent);

    $ppImage = $presentation->getImages()->addImage($svgImage);
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 200, $ppImage);

    $presentation->save("svg-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Arquivos SVG com Recursos Externos**

Um SVG pode referenciar imagens externas, folhas de estilo ou fontes. Para esses casos, [SvgImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/svgimage/) fornece construtores que aceitam um [ExternalResourceResolver](https://reference.aspose.com/slides/pt/php-java/aspose.slides/externalresourceresolver/) e um URI base. O resolvedor pode mapear um URI relativo para um URI absoluto permitido e retornar um stream para o recurso solicitado.

O resolvedor disponibiliza recursos externos enquanto Aspose.Slides processa o SVG, mas não reescreve o SVG em um documento autocontido. Se o SVG precisar permanecer portátil, incorpore seus recursos necessários no próprio SVG, por exemplo usando URIs `data:` para imagens vinculadas.

Quando arquivos SVG provêm de fontes não confiáveis, restrinja os esquemas, locais de arquivos e hosts que o resolvedor pode acessar. Resolvedores de rede também devem aplicar tempos limite, limites de tamanho de resposta e validação de conteúdo.

### **Converter SVG em Formas Editáveis**

Aspose.Slides pode converter um SVG em um grupo de formas editáveis de slide, similar ao comando correspondente do PowerPoint.

![PowerPoint Popup Menu](img_01_01.png)

Use a sobrecarga [ShapeCollection::addGroupShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapecollection/addgroupshape/) que aceita um [SvgImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/svgimage/) para realizar a conversão.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SvgImage;

$presentation = new Presentation();
try {
    $svgContent = file_get_contents("diagram.svg");
    $svgImage = new SvgImage($svgContent);

    $slideSize = $presentation->getSlideSize()->getSize();
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addGroupShape($svgImage, 0, 0, $slideSize->getWidth(), $slideSize->getHeight());

    $presentation->save("editable-svg-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Use a conversão SVG‑para‑formas quando elementos vetoriais individuais precisarem ser editados como formas do PowerPoint. Se o SVG precisar apenas ser exibido, mantê‑lo como imagem é mais simples e evita a criação de muitas formas separadas.

## **Substituir um Recurso de Imagem Existente**

Use [PPImage::replaceImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ppimage/) quando quiser substituir um recurso de imagem existente. Isso é especialmente útil para gráficos compartilhados, como logotipos.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $imageToReplace = $presentation->getImages()->get_Item(0);

    $replacementImage = Images::fromFile("new-logo.png");
    try {
        $imageToReplace->replaceImage($replacementImage);
    } finally {
        if (!java_is_null($replacementImage)) {
            $replacementImage->dispose();
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Se múltiplos quadros de imagem, fundos, mestres ou layouts usarem o mesmo recurso de imagem, substituir esse recurso atualiza todos esses usos. Se apenas um quadro de imagem deve mudar, atribua uma imagem diferente a esse quadro em vez de substituir o recurso compartilhado.

`PPImage::replaceImage` também fornece sobrecargas que aceitam um array de bytes ou outro [PPImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ppimage/).

## **Orientação Prática de Gerenciamento de Imagens**

### **Controlar o Tamanho da Apresentação**

Imagens raster grandes podem tornar uma apresentação desnecessariamente grande. Use imagens de origem com dimensões adequadas ao tamanho de exibição pretendido, reutilize recursos de imagem compartilhados quando possível e evite incorporar cópias repetidas do mesmo gráfico em alta resolução.

Para imagens raster que já foram colocadas em quadros de imagem, [PictureFillFormat::compressImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/picturefillformat/) pode reduzir os dados da imagem de acordo com a resolução selecionada e as configurações de recorte. Isso é processamento de quadro de imagem, não gerenciamento da coleção de imagens, portanto consulte [Quadro de Imagem](/slides/pt/php-java/picture-frame/) para operações de formatação relacionadas.

### **Escolher entre Conteúdo Incorporado e Vinculado**

Incorporar torna a apresentação portátil porque todos os dados de imagem necessários viajam com o arquivo. Vincular pode reduzir o tamanho do arquivo, mas introduz uma dependência externa. Use links apenas quando essa dependência for aceitável e estável.

### **Reutilizar Identidade Visual Compartilhada**

Para logotipos, marcas dʼágua ou gráficos decorativos recorrentes, use um recurso de imagem e reutilize‑o. Se o gráfico pertencer ao design da apresentação e não ao conteúdo dos slides, coloque‑o em um master ou layout para que seja herdado pelos slides apropriados.

### **Manter Recursos SVG Portáveis**

Um SVG autocontido é mais fácil de mover e renderizar consistentemente que um SVG que depende de arquivos externos ou recursos de rede. Quando possível, incorpore os recursos necessários antes de importar o SVG. Converta SVG em formas apenas quando os elementos vetoriais individuais precisarem ser editados.

### **Usar a API Moderna de Imagem Multiplataforma**

Para novos códigos PHP via Java, use as APIs Aspose.Slides [IImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/iimage/) e [Images](https://reference.aspose.com/slides/pt/php-java/aspose.slides/images/) em vez da API pública legada baseada em `java.awt.image.BufferedImage`. Consulte [API Moderna](/slides/pt/php-java/modern-api/) para orientações de migração.

WMF e EMF requerem consideração especial. Quando esses formatos são passados através de um [IImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/iimage/), [ImageCollection::addImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/imagecollection/) converte o metarquivo em uma representação PNG raster antes da inserção. Se preservar os dados do metarquivo for importante, use a sobrecarga baseada em stream de [ImageCollection::addImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/imagecollection/) . Gerar conteúdo EMF a partir de planilhas ou outros produtos é um fluxo de integração separado e está fora do escopo deste artigo.

## **Perguntas Frequentes**

**Qual é a diferença entre a coleção de imagens e um quadro de imagem?**

A coleção de imagens armazena recursos de imagem reutilizáveis. Um quadro de imagem é uma forma de slide que exibe um desses recursos e fornece formatações específicas de imagem, como recorte e efeitos.

**Qual é a melhor maneira de substituir o mesmo logo em todos os lugares?**

Se o logo já estiver compartilhado como um recurso de imagem, substitua esse recurso com [PPImage::replaceImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ppimage/). Para branding em toda a apresentação, colocar o logo em um master ou layout também pode reduzir o conteúdo duplicado nos slides.

**Por que uma imagem vinculada desaparece em outro computador?**

Uma imagem vinculada depende de seu arquivo ou URL externo. Se esse recurso não puder ser acessado a partir do outro computador, a imagem vinculada pode ficar indisponível. Incorpore a imagem quando a apresentação precisar ser autocontida.

**É possível editar um SVG inserido como formas do PowerPoint?**

Sim. Converta o SVG com [ShapeCollection::addGroupShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapecollection/addgroupshape/); o grupo resultante contém formas de slide editáveis em vez de um único SVG.

**Como posso manter apresentações com muitas imagens menores?**

Reutilize recursos de imagem compartilhados, evite fontes raster desnecessariamente grandes, comprima imagens raster adequadas quando apropriado, mantenha branding repetido em masters ou layouts e use imagens vinculadas somente quando uma dependência externa for aceitável.