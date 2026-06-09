---
title: Configurar Coleções de Fontes de Fallback no Android
linktitle: Coleção de Fonte de Fallback
type: docs
weight: 20
url: /pt/androidjava/create-fallback-fonts-collection/
keywords:
- fonte de fallback
- regra de fallback
- coleção de fontes
- configurar fonte
- definir fonte
- PowerPoint
- OpenDocument
- apresentação
- Android
- Java
- Aspose.Slides
description: "Configure uma coleção de fontes de fallback no Aspose.Slides para Android via Java para manter o texto consistente e nítido em apresentações PowerPoint e OpenDocument."
---
## **Visão geral**

Aspose.Slides permite configurar uma coleção de regras de fonte de fallback para uma apresentação. Cada regra de fallback é representada pela classe `FontFallBackRule` e pode ser adicionada a uma `FontFallBackRulesCollection`, que implementa a interface `IFontFallBackRulesCollection`.

Após criar a coleção, você pode atribuí‑la à propriedade `FontFallBackRulesCollection` do `FontsManager` da apresentação. O `FontsManager` controla as fontes em toda a apresentação, e cada instância de `Presentation` tem seu próprio `FontsManager`.

Quando o `FontsManager` é inicializado com a coleção de fontes de fallback, as fontes de fallback especificadas são aplicadas durante a renderização da apresentação.

## **Aplicar regras de fallback**

Instâncias da classe [FontFallBackRule](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/FontFallBackRule) podem ser organizadas em [FontFallBackRulesCollection](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/FontFallBackRulesCollection), que implementa a interface [IFontFallBackRulesCollection](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IFontFallBackRulesCollection). É possível adicionar ou remover regras da coleção.

Em seguida, essa coleção pode ser atribuída ao método [FontFallBackRulesCollection](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/FontFallBackRulesCollection) da classe [FontsManager](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/FontsManager). O FontsManager controla as fontes em toda a apresentação.

Cada [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation) possui um método [getFontsManager](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation#getFontsManager--) com sua própria instância da classe [FontsManager](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/FontsManager).

Aqui está um exemplo de como criar uma coleção de regras de fontes de fallback e atribuí‑la ao [FontsManager](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation#getFontsManager--) de uma determinada apresentação:  

```java
Presentation pres = new Presentation();
try {
    IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

    userRulesList.add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
    userRulesList.add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

    pres.getFontsManager().setFontFallBackRulesCollection(userRulesList);
} finally {
    if (pres != null) pres.dispose();
}
```

Depois que o FontsManager é inicializado com a coleção de fontes de fallback, as fontes de fallback são aplicadas durante a renderização da apresentação.

{{% alert color="primary" %}} 
Leia mais sobre como [Renderizar Apresentação com Fonte de Reserva](/slides/pt/androidjava/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Perguntas frequentes**

**As minhas regras de fallback serão incorporadas ao arquivo PPTX e visíveis no PowerPoint após a gravação?**

Não. As regras de fallback são configurações de renderização em tempo de execução; não são serializadas no PPTX e não aparecerão na interface do PowerPoint.

**O fallback se aplica a texto dentro de SmartArt, WordArt, gráficos e tabelas?**

Sim. O mesmo mecanismo de substituição de glifos é usado para qualquer texto nesses objetos.

**A Aspose distribui alguma fonte com a biblioteca?**

Não. Você adiciona e usa fontes do seu lado, sob sua própria responsabilidade.

**A substituição/substituição de fontes ausentes e o fallback para glifos ausentes podem ser usados juntos?**

Sim. Eles são estágios independentes do mesmo pipeline de resolução de fontes: primeiro o mecanismo resolve a disponibilidade da fonte ([replacement](/slides/pt/androidjava/font-replacement/)/[substitution](/slides/pt/androidjava/font-substitution/)), depois o fallback preenche lacunas para glifos ausentes nas fontes disponíveis.