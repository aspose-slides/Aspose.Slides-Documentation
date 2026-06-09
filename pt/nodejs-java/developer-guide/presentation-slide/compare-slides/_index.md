---
title: Comparar slides de apresentação em JavaScript
linktitle: Comparar slides
type: docs
weight: 50
url: /pt/nodejs-java/compare-slides/
keywords:
- comparar slides
- comparação de slides
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Compare apresentações PowerPoint e OpenDocument programaticamente com Aspose.Slides para Node.js via Java. Identifique diferenças de slides no código rapidamente."
---
## **Visão geral**

Aspose.Slides permite comparar slides, slides de layout e slides mestre usando o método `equals` fornecido pela classe `BaseSlide`. Esse método retorna `true` quando os slides comparados são idênticos em sua estrutura e conteúdo estático.

## **Comparar dois slides**

O método Equals foi adicionado à classe [BaseSlide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/BaseSlide) e à classe [BaseSlide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/BaseSlide). Ele retorna true para os slides de layout e slides mestre que são idênticos em sua estrutura e conteúdo estático.

Dois slides são iguais se todas as formas, estilos, textos, animações e outras configurações, etc., forem iguais. A comparação não leva em conta valores de identificadores únicos, por exemplo SlideId, e conteúdo dinâmico, como o valor da data atual em um placeholder de Data.

```javascript
var presentation1 = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    var presentation2 = new aspose.slides.Presentation("HelloWorld.pptx");
    try {
        for (var i = 0; i < presentation1.getMasters().size(); i++) {
            for (var j = 0; j < presentation2.getMasters().size(); j++) {
                if (presentation1.getMasters().get_Item(i).equals(presentation2.getMasters().get_Item(j))) {
                    console.log(java.callStaticMethodSync("java.lang.String", "format", "SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", i, j));
                }
            }
        }
    } finally {
        presentation2.dispose();
    }
} finally {
    presentation1.dispose();
}
```

## **Perguntas frequentes**

**O fato de um slide estar oculto afeta a comparação dos próprios slides?**

[Hidden status](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slide/gethidden/) é uma propriedade ao nível da apresentação/reprodução, não de conteúdo visual. A igualdade de dois slides específicos é determinada pela sua estrutura e conteúdo estático; o simples fato de um slide estar oculto não torna os slides diferentes.

**Os hyperlinks e seus parâmetros são levados em conta?**

Sim. Os links fazem parte do conteúdo estático de um slide. Se a URL ou a ação do hyperlink forem diferentes, isso geralmente é tratado como uma diferença no conteúdo estático.

**Se um gráfico referir-se a um arquivo Excel externo, o conteúdo desse arquivo será levado em conta?**

Não. A comparação é feita com base nos próprios slides. Fontes de dados externas geralmente não são lidas no momento da comparação; apenas o que está presente na estrutura e no estado estático do slide é considerado.