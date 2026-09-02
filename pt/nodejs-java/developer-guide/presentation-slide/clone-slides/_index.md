---
title: Clonar Slides de Apresentação em JavaScript
linktitle: Clonar Slides
type: docs
weight: 35
url: /pt/nodejs-java/clone-slides/
keywords:
- clonar slide
- copiar slide
- salvar slide
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Duplique slides do PowerPoint rapidamente com Aspose.Slides para Node.js. Siga nossos exemplos de código para automatizar a criação de PPT em segundos e eliminar o trabalho manual."
---
## **Introdução**

Clonar é o processo de fazer uma cópia exata ou réplica de algo. Aspose.Slides for Node.js via Java também possibilita fazer uma cópia ou clone de qualquer slide e inserir esse slide clonado na apresentação atual ou em qualquer outra apresentação aberta. O processo de clonagem de slides cria um novo slide que pode ser modificado pelos desenvolvedores sem alterar o slide original. Existem várias maneiras possíveis de clonar um slide:

- Clonar ao final dentro de uma apresentação.
- Clonar em outra posição dentro da apresentação.
- Clonar ao final em outra apresentação.
- Clonar em outra posição em outra apresentação.
- Clonar em uma posição específica em outra apresentação.

No Aspose.Slides for Node.js via Java, (uma coleção de [Slide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Slide) objetos) exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation) fornece os métodos [addClone](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) e [insertClone](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) para executar os tipos de clonagem de slide descritos acima

## **Clonar ao final dentro de uma apresentação**
Se você quiser clonar um slide e então usá‑lo dentro do mesmo arquivo de apresentação ao final dos slides existentes, use o método [addClone](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) de acordo com os passos listados abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
1. Instancie a classe [SlideCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation#getSlides--) referenciando a coleção Slides exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
1. Chame o método [addClone](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) exposto pelo objeto [SlideCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation#getSlides--) e passe o slide a ser clonado como parâmetro para o método [addClone](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
1. Grave o arquivo de apresentação modificado.

No exemplo abaixo, clonamos um slide (situado na primeira posição – índice zero – da apresentação) para o final da apresentação.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instancie a classe Presentation que representa um arquivo de apresentação
var pres = new aspose.slides.Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Clone o slide desejado para o final da coleção de slides na mesma apresentação
    var slds = pres.getSlides();
    slds.addClone(pres.getSlides().get_Item(0));
    // Grave a apresentação modificada no disco
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Clonar em outra posição dentro da apresentação**
Se você quiser clonar um slide e então usá‑lo dentro do mesmo arquivo de apresentação, mas em uma posição diferente, use o método [insertClone](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-):

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
1. Instancie a classe referenciando a coleção [**Slides**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation#getSlides--) exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
1. Chame o método [insertClone](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) exposto pelo objeto [SlideCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation#getSlides--) e passe o slide a ser clonado junto com o índice da nova posição como parâmetro para o método [insertClone](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-).
1. Grave a apresentação modificada como um arquivo PPTX.

No exemplo abaixo, clonamos um slide (situado no índice 1 – posição 2 – da apresentação) para o índice 2 – posição 3 – da apresentação.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instancie a classe Presentation que representa um arquivo de apresentação
var pres = new aspose.slides.Presentation("CloneWithInSamePresentation.pptx");
try {
    // Clone o slide desejado para o final da coleção de slides na mesma apresentação
    var slds = pres.getSlides();
    // Clone o slide desejado para o índice especificado na mesma apresentação
    slds.insertClone(2, pres.getSlides().get_Item(1));
    // Grave a apresentação modificada no disco
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Clonar ao final em outra apresentação**
Se for necessário clonar um slide de uma apresentação e usá‑lo em outra arquivo de apresentação, ao final dos slides existentes:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation) contendo a apresentação da qual o slide será clonado.
1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation) contendo a apresentação de destino à qual o slide será adicionado.
1. Instancie a classe [SlideCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SlideCollection) referenciando a coleção [**Slides**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation#getSlides--) exposta pelo objeto Presentation da apresentação de destino.
1. Chame o método [addClone](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) exposto pelo objeto [SlideCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation#getSlides--) e passe o slide da apresentação origem como parâmetro para o método [addClone](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
1. Grave o arquivo da apresentação de destino modificada.

No exemplo abaixo, clonamos um slide (do primeiro índice da apresentação origem) para o final da apresentação de destino.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instancie a classe Presentation para carregar o arquivo de apresentação fonte
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instancie a classe Presentation para o PPTX de destino (onde o slide será clonado)
    var destPres = new aspose.slides.Presentation();
    try {
        // Clone o slide desejado da apresentação fonte para o final da coleção de slides na apresentação de destino
        var slds = destPres.getSlides();
        slds.addClone(srcPres.getSlides().get_Item(0));
        // Grave a apresentação de destino no disco
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Clonar em outra posição em outra apresentação**
Se for necessário clonar um slide de uma apresentação e usá‑lo em outro arquivo de apresentação, em uma posição específica:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation) contendo a apresentação fonte da qual o slide será clonado.
1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation) contendo a apresentação à qual o slide será adicionado.
1. Instancie a classe [SlideCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation#getSlides--) referenciando a coleção Slides exposta pelo objeto Presentation da apresentação de destino.
1. Chame o método [insertClone](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) exposto pelo objeto [SlideCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation#getSlides--) e passe o slide da apresentação origem junto com a posição desejada como parâmetro para o método [insertClone](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-).
1. Grave o arquivo da apresentação de destino modificada.

No exemplo abaixo, clonamos um slide (do índice zero da apresentação origem) para o índice 1 (posição 2) da apresentação de destino.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instancie a classe Presentation para carregar o arquivo de apresentação fonte
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instancie a classe Presentation para o PPTX de destino (onde o slide será clonado)
    var destPres = new aspose.slides.Presentation();
    try {
        // Clone o slide desejado da apresentação fonte para o final da coleção de slides na apresentação de destino
        var slds = destPres.getSlides();
        slds.insertClone(1, srcPres.getSlides().get_Item(0));
        // Grave a apresentação de destino no disco
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Clonar em posição específica em outra apresentação**
Se for necessário clonar um slide com slide mestre de uma apresentação e usá‑lo em outra apresentação, primeiro você deve clonar o slide mestre desejado da apresentação origem para a apresentação destino. Em seguida, use esse slide mestre para clonar o slide com mestre. O método [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) espera um slide mestre da apresentação de destino, e não da origem. Para clonar o slide com mestre, siga os passos abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation) contendo a apresentação fonte da qual o slide será clonado.
1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation) contendo a apresentação de destino para a qual o slide será clonado.
1. Acesse o slide a ser clonado juntamente com o slide mestre.
1. Instancie a classe [MasterSlideCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/MasterSlideCollection) referenciando a coleção Masters exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation) da apresentação de destino.
1. Chame o método [addClone](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) exposto pelo objeto [MasterSlideCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/MasterSlideCollection) e passe o mestre do PPTX de origem a ser clonado como parâmetro para o método [addClone](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
1. Instancie a classe [SlideCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation#getSlides--) definindo a referência para a coleção Slides exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation) da apresentação de destino.
1. Chame o método [addClone](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) exposto pelo objeto [SlideCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation#getSlides--) e passe o slide da apresentação origem a ser clonado e o slide mestre como parâmetro para o método [addClone](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
1. Grave o arquivo da apresentação de destino modificada.

No exemplo abaixo, clonamos um slide com mestre (situado no índice zero da apresentação origem) para o final da apresentação de destino usando um mestre do slide de origem.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instancie a classe Presentation para carregar o arquivo de apresentação fonte
var srcPres = new aspose.slides.Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Instancie a classe Presentation para a apresentação de destino (onde o slide será clonado)
    var destPres = new aspose.slides.Presentation();
    try {
        // Instancie ISlide a partir da coleção de slides na apresentação fonte juntamente com
        // Slide mestre
        var SourceSlide = srcPres.getSlides().get_Item(0);
        var SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // Clone o slide mestre desejado da apresentação fonte para a coleção de mestres na
        // apresentação de destino
        var masters = destPres.getMasters();
        var DestMaster = masters.addClone(SourceMaster);
        // Clone o slide desejado da apresentação fonte com o mestre desejado para o final da
        // coleção de slides na apresentação de destino
        var slds = destPres.getSlides();
        slds.addClone(SourceSlide, DestMaster, true);
        // Grave a apresentação de destino no disco
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Clonar ao final em seção especificada**
Se você quiser clonar um slide e então usá‑lo dentro do mesmo arquivo de apresentação, mas em uma seção diferente, use o método [**addClone**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ISection-) exposto pela classe [**SlideCollection**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SlideCollection). O Aspose.Slides for Node.js via Java possibilita clonar um slide da primeira seção e inseri‑lo na segunda seção da mesma apresentação.

O trecho de código a seguir mostra como clonar um slide e inserir o slide clonado em uma seção especificada.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));
    var section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    // Grave a apresentação de destino no disco
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Garantir tamanho de slide correspondente**

Ao clonar slides para outra apresentação, certifique‑se de que a apresentação de destino tenha o mesmo tamanho de slide da origem. Se os tamanhos dos slides diferirem, o Aspose.Slides não redimensiona automaticamente as formas clonadas — suas coordenadas e dimensões originais são preservadas, o que pode fazer com que o conteúdo fique desalinhado ou ultrapasse os limites do slide.

Você pode definir o tamanho de slide da apresentação de destino para corresponder ao da origem antes de clonar o mestre e o slide:

```javascript
const sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), aspose.slides.SlideSizeScaleType.DoNotScale);
```

Faça isso antes de clonar o mestre e o slide.

## **FAQ**

**As notas do orador e os comentários de revisão são clonados?**

Sim. A página de notas e os comentários de revisão são incluídos no clone. Se não quiser deles, [remova‑os](/slides/pt/nodejs-java/presentation-notes/) após a inserção.

**Como os gráficos e suas fontes de dados são tratados?**

O objeto do gráfico, sua formatação e os dados incorporados são copiados. Se o gráfico estava vinculado a uma fonte externa (por exemplo, uma pasta de trabalho incorporada via OLE), essa vinculação é preservada como um [objeto OLE](/slides/pt/nodejs-java/manage-ole/). Após mover entre arquivos, verifique a disponibilidade dos dados e o comportamento de atualização.

**Posso controlar a posição de inserção e as seções para o clone?**

Sim. Você pode inserir o clone em um índice de slide específico e colocá‑lo em uma [seção](/slides/pt/nodejs-java/slide-section/) escolhida. Se a seção de destino não existir, crie‑a primeiro e então mova o slide para ela.