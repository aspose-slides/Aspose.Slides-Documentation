---
title: Comparar Slides de Apresentação em C++
linktitle: Comparar Slides
type: docs
weight: 50
url: /pt/cpp/compare-slides/
keywords:
- comparar slides
- comparação de slides
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Compare apresentações PowerPoint e OpenDocument programaticamente com Aspose.Slides para C++. Identifique diferenças de slides no código rapidamente."
---
## **Visão Geral**

Aspose.Slides permite comparar slides, slides de layout e slides mestres usando o método `Equals` fornecido pela interface `IBaseSlide` e pela classe `BaseSlide`. Este método retorna `true` quando os slides comparados são idênticos em sua estrutura e conteúdo estático.

## **Comparar Dois Slides**
O método Equals foi adicionado à interface IBaseSlide e à classe BaseSlide. Ele retorna true para os slides / slides de layout / slides mestres que são idênticos por sua estrutura e conteúdo estático.

Dois slides são iguais se todas as formas, estilos, textos, animações e outras configurações, etc. A comparação não leva em conta valores de identificadores únicos, por exemplo SlideId, e conteúdo dinâmico, por exemplo o valor da data atual em um placeholder de data.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CheckSlidesComparison-CheckSlidesComparison.cpp" >}}

## **Perguntas Frequentes**

**O fato de um slide estar oculto afeta a comparação dos próprios slides?**

[Hidden status](https://reference.aspose.com/slides/pt/cpp/aspose.slides/slide/get_hidden/) é uma propriedade de nível de apresentação/reprodução, não conteúdo visual. A igualdade de dois slides específicos é determinada por sua estrutura e conteúdo estático; o simples fato de um slide estar oculto não torna os slides diferentes.

**Os hiperlinks e seus parâmetros são levados em conta?**

Sim. Links fazem parte do conteúdo estático de um slide. Se a URL ou a ação do hyperlink diferir, isso geralmente é tratado como diferença no conteúdo estático.

**Se um gráfico se refere a um arquivo Excel externo, o conteúdo desse arquivo será considerado?**

Não. A comparação é feita com base nos próprios slides. Fontes de dados externas geralmente não são lidas no momento da comparação; apenas o que está presente na estrutura e estado estático do slide é considerado.