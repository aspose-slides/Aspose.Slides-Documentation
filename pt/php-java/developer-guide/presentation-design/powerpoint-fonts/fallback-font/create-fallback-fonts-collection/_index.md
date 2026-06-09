---
title: Configurar Coleções de Fontes de Fallback em PHP
linktitle: Coleção de Fontes de Fallback
type: docs
weight: 20
url: /pt/php-java/create-fallback-fonts-collection/
keywords:
- fonte de fallback
- regra de fallback
- coleção de fontes
- configurar fonte
- instalar fonte
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Configure uma coleção de fontes de fallback no Aspose.Slides para PHP via Java para manter o texto consistente e nítido em apresentações PowerPoint e OpenDocument."
---
## **Visão geral**

O Aspose.Slides permite que você configure uma coleção de regras de fonte de fallback para uma apresentação. Cada regra de fallback é representada pela classe `FontFallBackRule` e pode ser adicionada a uma `FontFallBackRulesCollection`.

Depois de criar a coleção, você pode atribuí‑la usando o método `setFontFallBackRulesCollection` do `FontsManager` da apresentação. O `FontsManager` controla as fontes em toda a apresentação, e cada instância de `Presentation` possui seu próprio `FontsManager`.

Quando o `FontsManager` é inicializado com a coleção de fontes de fallback, as fontes de fallback especificadas são aplicadas durante a renderização da apresentação.

## **Aplicar regras de fallback**

Instâncias da classe [FontFallBackRule](https://reference.aspose.com/slides/pt/php-java/aspose.slides/FontFallBackRule) podem ser organizadas em [FontFallBackRulesCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/FontFallBackRulesCollection). É possível adicionar ou remover regras da coleção.

Em seguida, essa coleção pode ser atribuída ao método [FontFallBackRulesCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/FontFallBackRulesCollection) da classe [FontsManager](https://reference.aspose.com/slides/pt/php-java/aspose.slides/FontsManager). O FontsManager controla as fontes em toda a apresentação.

Cada [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation) possui um método [getFontsManager](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation#getFontsManager) com sua própria instância da classe [FontsManager](https://reference.aspose.com/slides/pt/php-java/aspose.slides/FontsManager).

Aqui está um exemplo de como criar uma coleção de regras de fontes de fallback e atribuí‑la ao [FontsManager](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation#getFontsManager) de uma determinada apresentação:

```php
  $pres = new Presentation();
  try {
    $userRulesList = new FontFallBackRulesCollection();
    $userRulesList->add(new FontFallBackRule(0xb80, 0xbff, "Vijaya"));
    $userRulesList->add(new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic"));
    $pres->getFontsManager()->setFontFallBackRulesCollection($userRulesList);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Depois que o FontsManager é inicializado com a coleção de fontes de fallback, as fontes de fallback são aplicadas durante a renderização da apresentação.

{{% alert color="primary" %}} 
Leia mais como [Render Presentation with Fallback Font](/slides/pt/php-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Perguntas frequentes**

**As minhas regras de fallback serão incorporadas ao arquivo PPTX e ficarão visíveis no PowerPoint após a gravação?**

Não. As regras de fallback são configurações de renderização em tempo de execução; elas não são serializadas no PPTX e não aparecerão na interface do PowerPoint.

**O fallback se aplica ao texto dentro de SmartArt, WordArt, gráficos e tabelas?**

Sim. O mesmo mecanismo de substituição de glifos é usado para qualquer texto nesses objetos.

**A Aspose distribui alguma fonte com a biblioteca?**

Não. Você adiciona e usa fontes do seu lado, sob sua própria responsabilidade.

**É possível usar substituição/substituição de fontes ausentes e fallback para glifos ausentes juntos?**

Sim. Eles são estágios independentes do mesmo pipeline de resolução de fontes: primeiro o mecanismo resolve a disponibilidade de fontes ([replacement](/slides/pt/php-java/font-replacement/)/[substitution](/slides/pt/php-java/font-substitution/)), depois o fallback preenche as lacunas de glifos ausentes nas fontes disponíveis.