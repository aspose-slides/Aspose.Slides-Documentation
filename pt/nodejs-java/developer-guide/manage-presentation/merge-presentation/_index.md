---
title: Mesclar apresentações de forma eficiente em JavaScript
linktitle: Mesclar apresentações
type: docs
weight: 40
url: /pt/nodejs-java/merge-presentation/
keywords:
- mesclar PowerPoint
- mesclar apresentações
- mesclar slides
- mesclar PPT
- mesclar PPTX
- mesclar ODP
- combinar PowerPoint
- combinar apresentações
- combinar slides
- combinar PPT
- combinar PPTX
- combinar ODP
- Node.js
- JavaScript
- Aspose.Slides
description: "Mescle apresentações PowerPoint (PPT, PPTX) e OpenDocument (ODP) em JavaScript com Aspose.Slides para Node.js, simplificando seu fluxo de trabalho."
---
## **Visão geral**

Aspose.Slides permite mesclar apresentações clonando slides de uma apresentação para outra. Este artigo explica como mesclar apresentações inteiras ou slides selecionados, usar um mestre de slides ou um layout específico durante a mesclagem, lidar com apresentações com diferentes tamanhos de slide e adicionar slides mesclados a uma seção de apresentação. Também aborda notas práticas relacionadas ao conteúdo mesclado, incluindo notas do apresentador, comentários, arquivos de origem protegidos por senha e uso de threads.

## **Mesclagem de Apresentações**

Ao mesclar uma apresentação com outra, você está efetivamente combinando seus slides em uma única apresentação para obter um único arquivo. 

{{% alert title="Info" color="info" %}}
A maioria dos programas de apresentação (PowerPoint ou OpenOffice) não possui funções que permitam aos usuários combinar apresentações dessa maneira. 
[**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/pt/nodejs-java/), no entanto, permite mesclar apresentações de diferentes maneiras. Você pode mesclar apresentações com todas as suas formas, estilos, textos, formatações, comentários, animações etc., sem se preocupar com perda de qualidade ou de dados.

**Veja também**  
[Clonar Slides](https://docs.aspose.com/slides/pt/nodejs-java/clone-slides/).
{{% /alert %}}

### **O que pode ser mesclado**

* apresentações inteiras. Todos os slides das apresentações acabam em uma única apresentação
* slides específicos. Slides selecionados acabam em uma única apresentação
* apresentações em um formato (PPT para PPT, PPTX para PPTX, etc.) e em formatos diferentes (PPT para PPTX, PPTX para ODP, etc.) entre si. 

### **Opções de Mesclagem**

Você pode aplicar opções que determinam se

* cada slide na apresentação de saída mantém um estilo único
* um estilo específico é usado para todos os slides na apresentação de saída. 

Para mesclar apresentações, Aspose.Slides fornece os métodos [addClone](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) (da classe [SlideCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SlideCollection)). Existem várias implementações dos métodos `addClone` que definem os parâmetros do processo de mesclagem de apresentações. Cada objeto Presentation possui uma coleção [Slides](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation#getSlides--), de modo que você pode chamar um método `addClone` a partir da apresentação na qual deseja mesclar slides.

O método `addClone` retorna um objeto `Slide`, que é um clone do slide de origem. Os slides em uma apresentação de saída são simplesmente uma cópia dos slides da origem. Portanto, você pode fazer alterações nos slides resultantes (por exemplo, aplicar estilos, opções de formatação ou layouts) sem se preocupar em afetar as apresentações de origem. 

## **Mesclar Apresentações** 

Aspose.Slides fornece o método [**AddClone(ISlide)**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) que permite combinar slides enquanto eles mantêm seus layouts e estilos (parâmetros padrão).

Este código JavaScript mostra como mesclar apresentações:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

## **Mesclar Apresentações com Mestre de Slides**

Aspose.Slides fornece o método [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) que permite combinar slides aplicando um modelo de apresentação mestre de slides. Dessa forma, se necessário, você pode alterar o estilo dos slides na apresentação de saída.

Este código em JavaScript demonstra a operação descrita:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres2.getMasters().get_Item(0), true);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

{{% alert title="Note" color="warning" %}} 
O layout do slide para o mestre de slides é determinado automaticamente. Quando um layout apropriado não pode ser determinado, se o parâmetro booleano `allowCloneMissingLayout` do método `addClone` estiver definido como true, o layout do slide de origem será usado. Caso contrário, será lançada uma [PptxEditException](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/PptxEditException).
{{% /alert %}}

Se você desejar que os slides na apresentação de saída tenham um layout de slide diferente, use o método [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) ao mesclar.

## **Mesclar Slides Específicos de Apresentações**

Mesclar slides específicos de várias apresentações é útil para criar decks de slides personalizados. Aspose.Slides for Node.js via Java permite selecionar e importar apenas os slides necessários. A API preserva a formatação, o layout e o design dos slides originais.

O código JavaScript a seguir cria uma nova apresentação, adiciona slides de título de duas outras apresentações e salva o resultado em um arquivo:

```js
function getTitleSlide(presentation) {
  for (let i = 0; i < presentation.getSlides().size(); i++) {
    let slide = presentation.getSlides().get_Item(i);
    if (slide.getLayoutSlide().getLayoutType() == aspose.slides.SlideLayoutType.Title) {
      return slide;
    }
  }
  return null;
}
```
```js
let presentation = new aspose.slides.Presentation();
let presentation1 = new aspose.slides.Presentation("presentation1.pptx");
let presentation2 = new aspose.slides.Presentation("presentation2.pptx");
try {
    presentation.getSlides().removeAt(0);
    
    let slide1 = getTitleSlide(presentation1);

    if (slide1 != null)
        presentation.getSlides().addClone(slide1);

    let slide2 = getTitleSlide(presentation2);

    if (slide2 != null)
        presentation.getSlides().addClone(slide2);

    presentation.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
    presentation.dispose();
}
```

## **Mesclar Apresentações com Layout de Slide**

Este código JavaScript mostra como combinar slides de apresentações aplicando o layout de slide de sua preferência a eles para obter uma única apresentação de saída:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres2.getLayoutSlides().get_Item(0));
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

## **Mesclar Apresentações com Tamanhos de Slide Diferentes**

{{% alert title="Note" color="warning" %}} 
Não é possível mesclar apresentações com tamanhos de slide diferentes. 
{{% /alert %}}

Para mesclar 2 apresentações com tamanhos de slide diferentes, é necessário redimensionar uma das apresentações para que seu tamanho corresponda ao da outra apresentação. 

Este código de exemplo demonstra a operação descrita:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        pres2.getSlideSize().setSize(pres1.getSlideSize().getSize().getWidth(), pres1.getSlideSize().getSize().getHeight(), aspose.slides.SlideSizeScaleType.EnsureFit);
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

## **Mesclar Slides em Seção de Apresentação**

Este código JavaScript mostra como mesclar um slide específico a uma seção em uma apresentação:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres1.getSections().get_Item(0));
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

O slide é adicionado ao final da seção. 

## **FAQ**

**As notas do apresentador são preservadas durante a mesclagem?**

Sim. Ao clonar slides, Aspose.Slides transfere todos os elementos do slide, incluindo notas, formatação e animações.

**Os comentários e seus autores são transferidos?**

Comentários, como parte do conteúdo do slide, são copiados junto com o slide. Rótulos de autores de comentários são preservados como objetos de comentário na apresentação resultante.

**E se a apresentação de origem estiver protegida por senha?**

Deve ser [aberta com a senha](/slides/pt/nodejs-java/password-protected-presentation/) via [LoadOptions.setPassword](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/loadoptions/setpassword/); após o carregamento, esses slides podem ser clonados com segurança em um arquivo de destino desprotegido (ou também protegido).

**Quão thread-safe é a operação de mesclagem?**

Não utilize a mesma instância [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) a partir de [múltiplas threads](/slides/pt/nodejs-java/multithreading/). A regra recomendada é "um documento — uma thread"; arquivos diferentes podem ser processados em paralelo em threads separadas.

## **Veja Também**

A Aspose oferece um [FALE Collage Maker GRATUITO](https://products.aspose.app/slides/pt/collage). Usando este serviço online, você pode mesclar imagens [JPG para JPG](https://products.aspose.app/slides/pt/collage/jpg) ou PNG para PNG, criar [grades de fotos](https://products.aspose.app/slides/pt/collage/photo-grid) e muito mais.

Confira o [Aspose MERGER ONLINE GRATUITO](https://products.aspose.app/slides/pt/merger). Ele permite mesclar apresentações PowerPoint no mesmo formato (por exemplo, PPT para PPT, PPTX para PPTX) ou em formatos diferentes (por exemplo, PPT para PPTX, PPTX para ODP).

[![Aspose MERGER ONLINE GRATUITO](slides-merger.png)](https://products.aspose.app/slides/pt/merger)