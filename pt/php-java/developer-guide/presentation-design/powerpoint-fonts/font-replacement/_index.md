---
title: Otimize a Substituição de Fontes em Apresentações Usando PHP
linktitle: Substituição de Fontes
type: docs
weight: 60
url: /pt/php-java/font-replacement/
keywords:
- fonte
- substituir fonte
- substituição de fonte
- mudar fonte
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Substitua fontes de forma transparente no Aspose.Slides para PHP via Java, garantindo tipografia consistente em apresentações PowerPoint e OpenDocument."
---
## **Visão geral**

Aspose.Slides permite substituir uma fonte por outra em toda a apresentação. Quando uma fonte é substituída, todas as instâncias da fonte original são alteradas para a nova fonte.

Para realizar a substituição de fontes, carregue a apresentação, defina a fonte de origem e a fonte de substituição, chame o método de substituição de fontes e salve a apresentação modificada como um arquivo PPTX. Essa abordagem é útil quando você deseja trocar intencionalmente uma família de fontes por outra em toda a apresentação.

## **Substituir fontes**

Se mudar de ideia sobre o uso de uma fonte, você pode substituir essa fonte por outra. Todas as instâncias da fonte antiga serão substituídas pela nova fonte. 

Aspose.Slides permite substituir uma fonte desta forma:

1. Carregue a apresentação relevante. 
2. Carregue a fonte que será substituída.
3. Carregue a nova fonte. 
4. Substitua a fonte. 
5. Salve a apresentação modificada como um arquivo PPTX.

Este código PHP demonstra a substituição de fontes:

```php
  # Carrega uma apresentação
  $pres = new Presentation("Fonts.pptx");
  try {
    # Carrega a fonte de origem que será substituída
    $sourceFont = new FontData("Arial");
    # Carrega a nova fonte
    $destFont = new FontData("Times New Roman");
    # Substitui as fontes
    $pres->getFontsManager()->replaceFont($sourceFont, $destFont);
    # Salva a apresentação
    $pres->save("UpdatedFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Note" color="warning" %}} 
Para definir regras que determinam o que acontece em determinadas condições (por exemplo, se uma fonte não puder ser acessada), veja [**Font Substitution**](/slides/pt/php-java/font-substitution/).
{{% /alert %}}

## **FAQ**

**Qual é a diferença entre "font replacement", "font substitution" e "fallback fonts"?**

A substituição é uma troca intencional de uma família por outra em todo o documento. [Substitution](/slides/pt/php-java/font-substitution/) é uma regra como "se a fonte não estiver disponível, use X". [Fallback](/slides/pt/php-java/fallback-font/) é aplicado de forma cirúrgica para glifos ausentes individuais quando a fonte base está instalada, mas não contém os caracteres necessários.

**A substituição se aplica a slides mestre, layouts, notas e comentários?**

Sim. A substituição afeta todos os objetos da apresentação que utilizam a fonte original, incluindo slides mestre e notas; comentários também fazem parte do documento e são levados em conta pelo mecanismo de fontes.

**A fonte será alterada dentro de objetos OLE incorporados (por exemplo, Excel)?**

Não. [OLE content](/slides/pt/php-java/manage-ole/) é controlado pela sua própria aplicação. A substituição na apresentação não reformata os dados internos do OLE; eles podem ser exibidos como uma imagem ou como conteúdo editável externamente.

**Posso substituir uma fonte apenas em parte da apresentação (por slides ou regiões)?**

É possível fazer substituição direcionada se você mudar a fonte no nível dos objetos/faixas necessários, em vez de aplicar uma substituição global a todo o documento. A lógica geral de seleção de fontes durante a renderização permanece a mesma.

**Como posso determinar com antecedência quais fontes a apresentação utiliza?**

Use o [font manager](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontsmanager/) da apresentação: ele fornece uma lista das [families in use](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontsmanager/getfonts/) e informações sobre [substitutions/"unknown" fonts](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontsmanager/getsubstitutions/), o que ajuda a planejar a substituição.

**A substituição de fontes funciona ao converter para PDF/imagens?**

Sim. Durante a exportação, o Aspose.Slides aplica a mesma [font selection/substitution sequence](/slides/pt/php-java/font-selection-sequence/), portanto uma substituição feita previamente será respeitada durante a conversão.

**Preciso instalar a fonte alvo no sistema ou posso anexar uma pasta de fontes?**

A instalação não é necessária: a biblioteca permite [loading external fonts](/slides/pt/php-java/custom-font/) a partir de pastas do usuário para uso durante [rendering and export](/slides/pt/php-java/convert-powerpoint/).

**A substituição corrigirá o "tofu" (quadrados) em vez de caracteres?**

Só se a fonte alvo realmente contiver os glifos necessários. Caso contrário, [configure fallback](/slides/pt/php-java/fallback-font/) para cobrir os caracteres ausentes.