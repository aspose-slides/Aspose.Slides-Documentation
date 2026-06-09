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
description: "Duplique rapidamente slides do PowerPoint com Aspose.Slides para Node.js. Siga nossos exemplos de código para automatizar a criação de PPT em segundos e eliminar o trabalho manual."
---
## **Introdução**

Clonar é o processo de fazer uma cópia exata ou réplica de algo. Aspose.Slides for Node.js via Java também possibilita fazer uma cópia ou clone de qualquer slide e, em seguida, inserir esse slide clonado na apresentação atual ou em qualquer outra apresentação aberta. O processo de clonagem de slide cria um novo slide que pode ser modificado pelos desenvolvedores sem alterar o slide original. Existem várias maneiras possíveis de clonar um slide:

- Clonar no final dentro de uma apresentação.
- Clonar em outra posição dentro da apresentação.
- Clonar no final em outra apresentação.
- Clonar em outra posição em outra apresentação.
- Clonar em uma posição específica em outra apresentação.

Em Aspose.Slides for Node.js via Java, (uma coleção de [Slide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Slide) objects) exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation) fornece os métodos [addClone](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) e [insertClone](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) para realizar os tipos de clonagem de slide acima.

## **Clonar no final dentro de uma apresentação**
Se você quiser clonar um slide e usá‑lo dentro do mesmo arquivo de apresentação ao final dos slides existentes, use o método [addClone](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) de acordo com as etapas abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
2. Instancie a classe [SlideCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation#getSlides--) referenciando a coleção Slides exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
3. Chame o método [addClone](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) exposto pelo objeto [SlideCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation#getSlides--) e passe o slide a ser clonado como parâmetro para o método [addClone](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
4. Grave o arquivo de apresentação modificado.

No exemplo abaixo, clonamos um slide (localizado na primeira posição – índice zero – da apresentação) para o final da apresentação.

```javascript
// Instanciar a classe Presentation que representa um arquivo de apresentação
var pres = new aspose.slides.Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Clonar o slide desejado para o final da coleção de slides na mesma apresentação
    var slds = pres.getSlides();
    slds.addClone(pres.getSlides().get_Item(0));
    // Gravar a apresentação modificada no disco
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Clonar em outra posição dentro da apresentação**
Se você quiser clonar um slide e usá‑lo dentro do mesmo arquivo de apresentação, porém em outra posição, use o método [insertClone](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-):

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
2. Instancie a classe referenciando a coleção [**Slides**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation#getSlides--) exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
3. Chame o método [insertClone](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) exposto pelo objeto [SlideCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation#getSlides--) e passe o slide a ser clonado junto com o índice para a nova posição como parâmetro para o método [insertClone](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-).
4. Grave a apresentação modificada como um arquivo PPTX.

No exemplo abaixo, clonamos um slide (localizado no índice zero – posição 1 – da apresentação) para o índice 1 – posição 2 – da apresentação.

```javascript
// Instanciar a classe Presentation que representa um arquivo de apresentação
var pres = new aspose.slides.Presentation("CloneWithInSamePresentation.pptx");
try {
    // Clonar o slide desejado para o final da coleção de slides na mesma apresentação
    var slds = pres.getSlides();
    // Clonar o slide desejado para o índice especificado na mesma apresentação
    slds.insertClone(2, pres.getSlides().get_Item(1));
    // Gravar a apresentação modificada no disco
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Clonar no final em outra apresentação**
Se você precisar clonar um slide de uma apresentação e usá‑lo em outra apresentação, ao final dos slides existentes:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation) que contém a apresentação de onde o slide será clonado.
2. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation) que contém a apresentação de destino à qual o slide será adicionado.
3. Instancie a classe [SlideCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SlideCollection) referenciando a coleção [**Slides**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation#getSlides--) exposta pelo objeto Presentation da apresentação de destino.
4. Chame o método [addClone](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) exposto pelo objeto [SlideCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation#getSlides--) e passe o slide da apresentação de origem como parâmetro para o método [addClone](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
5. Grave o arquivo de apresentação de destino modificado.

No exemplo abaixo, clonamos um slide (do primeiro índice da apresentação de origem) para o final da apresentação de destino.

```javascript
// Instanciar a classe Presentation para carregar o arquivo de apresentação fonte
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instanciar a classe Presentation para o PPTX de destino (onde o slide será clonado)
    var destPres = new aspose.slides.Presentation();
    try {
        // Clonar o slide desejado da apresentação fonte para o final da coleção de slides na apresentação de destino
        var slds = destPres.getSlides();
        slds.addClone(srcPres.getSlides().get_Item(0));
        // Gravar a apresentação de destino no disco
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Clonar em outra posição em outra apresentação**
Se você precisar clonar um slide de uma apresentação e usá‑lo em outra apresentação, em uma posição específica:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation) que contém a apresentação de origem da qual o slide será clonado.
2. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation) que contém a apresentação à qual o slide será adicionado.
3. Instancie a classe [SlideCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation#getSlides--) referenciando a coleção Slides exposta pelo objeto Presentation da apresentação de destino.
4. Chame o método [insertClone](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) exposto pelo objeto [SlideCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation#getSlides--) e passe o slide da apresentação de origem juntamente com a posição desejada como parâmetro para o método [insertClone](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-).
5. Grave o arquivo de apresentação de destino modificado.

No exemplo abaixo, clonamos um slide (do índice zero da apresentação de origem) para o índice 1 (posição 2) da apresentação de destino.

```javascript
// Instanciar a classe Presentation para carregar o arquivo de apresentação fonte
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instanciar a classe Presentation para o PPTX de destino (onde o slide será clonado)
    var destPres = new aspose.slides.Presentation();
    try {
        // Clonar o slide desejado da apresentação fonte para o final da coleção de slides na apresentação de destino
        var slds = destPres.getSlides();
        slds.insertClone(2, srcPres.getSlides().get_Item(0));
        // Gravar a apresentação de destino no disco
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Clonar em posição específica em outra apresentação**
Se você precisar clonar um slide com um slide mestre de uma apresentação e usá‑lo em outra apresentação, primeiro deve clonar o slide mestre desejado da apresentação de origem para a apresentação de destino. Em seguida, use esse slide mestre ao clonar o slide com mestre. O método [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) espera um slide mestre da apresentação de destino, e não da apresentação de origem. Para clonar o slide com mestre, siga as etapas abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation) que contém a apresentação de origem da qual o slide será clonado.
2. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation) que contém a apresentação de destino para a qual o slide será clonado.
3. Acesse o slide a ser clonado juntamente com o slide mestre.
4. Instancie a classe [MasterSlideCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/MasterSlideCollection) referenciando a coleção Masters exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation) da apresentação de destino.
5. Chame o método [addClone](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) exposto pelo objeto [MasterSlideCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/MasterSlideCollection) e passe o mestre da apresentação PPTX de origem a ser clonado como parâmetro para o método [addClone](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
6. Instancie a classe [SlideCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation#getSlides--) definindo a referência para a coleção Slides exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation) da apresentação de destino.
7. Chame o método [addClone](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) exposto pelo objeto [SlideCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation#getSlides--) e passe o slide da apresentação de origem a ser clonado e o slide mestre como parâmetros para o método [addClone](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
8. Grave o arquivo de apresentação de destino modificado.

No exemplo abaixo, clonamos um slide com mestre (localizado no índice zero da apresentação de origem) para o final da apresentação de destino usando um mestre da apresentação de origem.

```javascript
// Instanciar a classe Presentation para carregar o arquivo de apresentação fonte
var srcPres = new aspose.slides.Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Instanciar a classe Presentation para a apresentação de destino (onde o slide será clonado)
    var destPres = new aspose.slides.Presentation();
    try {
        // Instanciar ISlide a partir da coleção de slides na apresentação fonte juntamente com
        // slide mestre
        var SourceSlide = srcPres.getSlides().get_Item(0);
        var SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // Clonar o slide mestre desejado da apresentação fonte para a coleção de mestres na
        // apresentação de destino
        var masters = destPres.getMasters();
        var DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // Clonar o slide mestre desejado da apresentação fonte para a coleção de mestres na
        // apresentação de destino
        var iSlide = masters.addClone(SourceMaster);
        // Clonar o slide desejado da apresentação fonte com o mestre desejado para o final da
        // coleção de slides na apresentação de destino
        var slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);
        // Gravar a apresentação de destino no disco
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Clonar no final em seção especificada**
Se você quiser clonar um slide e usá‑lo dentro do mesmo arquivo de apresentação, porém em uma seção diferente, use o método [**addClone**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ISection-) exposto pela classe [**SlideCollection**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SlideCollection). Aspose.Slides for Node.js via Java permite clonar um slide da primeira seção e então inserir esse slide clonado na segunda seção da mesma apresentação.

O trecho de código a seguir mostra como clonar um slide e inserir o slide clonado em uma seção especificada.

```javascript
var presentation = new aspose.slides.Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));
    var section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    // Salvar a apresentação de destino no disco
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **FAQ**

**As anotações do palestrante e os comentários dos revisores são clonados?**

Sim. A página de notas e os comentários de revisão são incluídos no clone. Se você não quiser eles, [remova‑os](/slides/pt/nodejs-java/presentation-notes/) após a inserção.

**Como são tratados os gráficos e suas fontes de dados?**

O objeto de gráfico, sua formatação e os dados incorporados são copiados. Se o gráfico estava vinculado a uma fonte externa (por exemplo, uma pasta de trabalho OLE incorporada), esse vínculo é mantido como um [objeto OLE](/slides/pt/nodejs-java/manage-ole/). Após mover entre arquivos, verifique a disponibilidade dos dados e o comportamento de atualização.

**Posso controlar a posição de inserção e as seções do clone?**

Sim. Você pode inserir o clone em um índice de slide específico e colocá‑lo em uma [seção](/slides/pt/nodejs-java/slide-section/) escolhida. Se a seção de destino não existir, crie‑a primeiro e então mova o slide para ela.