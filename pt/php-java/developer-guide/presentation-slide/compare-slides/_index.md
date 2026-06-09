---
title: Comparar Slides de Apresentação em PHP
linktitle: Comparar Slides
type: docs
weight: 50
url: /pt/php-java/compare-slides/
keywords:
- comparar slides
- comparação de slides
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Compare apresentações PowerPoint e OpenDocument programaticamente com Aspose.Slides para PHP via Java. Identifique rapidamente as diferenças de slides no código."
---
## **Introdução**

O Aspose.Slides permite comparar slides, slides de layout e slides mestres usando o método `equals` fornecido pela classe `BaseSlide`. Esse método retorna `true` quando os slides comparados são idênticos em sua estrutura e conteúdo estático.

## **Comparar Dois Slides**

O método Equals foi adicionado à classe [BaseSlide](https://reference.aspose.com/slides/pt/php-java/aspose.slides/BaseSlide). Ele retorna true para os slides de layout e slides mestres que são idênticos em sua estrutura e conteúdo estático. 

Dois slides são iguais se todas as formas, estilos, textos, animações e outras configurações, etc., forem iguais. A comparação não leva em conta valores de identificadores exclusivos, por exemplo SlideId, e conteúdo dinâmico, por exemplo o valor da data atual no Marcador de Data.

```php
  $presentation1 = new Presentation("AccessSlides.pptx");
  try {
    $presentation2 = new Presentation("HelloWorld.pptx");
    try {
      for($i = 0; $i < java_values($presentation1->getMasters()->size()) ; $i++) {
        for($j = 0; $j < java_values($presentation2->getMasters()->size()) ; $j++) {
          if ($presentation1->getMasters()->get_Item($i)->equals($presentation2->getMasters()->get_Item($j))) {
            echo(sprintf("SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", $i, $j));
          }
        }
      }
    } finally {
      $presentation2->dispose();
    }
  } finally {
    $presentation1->dispose();
  }
```

## **Perguntas Frequentes**

**O fato de um slide estar oculto afeta a comparação dos próprios slides?**

[Hidden status](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slide/gethidden/) é uma propriedade de nível de apresentação/execução, não de conteúdo visual. A igualdade de dois slides específicos é determinada pela sua estrutura e conteúdo estático; o simples fato de um slide estar oculto não torna os slides diferentes.

**Os hiperlinks e seus parâmetros são considerados?**

Sim. Os links fazem parte do conteúdo estático de um slide. Se a URL ou a ação do hiperlink for diferente, isso geralmente é tratado como uma diferença no conteúdo estático.

**Se um gráfico referir-se a um arquivo Excel externo, o conteúdo desse arquivo será levado em conta?**

Não. A comparação é feita com base nos próprios slides. Fontes de dados externas geralmente não são lidas no momento da comparação; apenas o que está presente na estrutura e no estado estático do slide é considerado.