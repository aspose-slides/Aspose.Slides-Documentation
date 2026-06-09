---
title: Configurar coleções de fontes de reserva em Java
linktitle: Coleção de fontes de reserva
type: docs
weight: 20
url: /pt/java/create-fallback-fonts-collection/
keywords:
- fonte de reserva
- regra de reserva
- coleção de fontes
- configurar fonte
- definir fonte
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Configure uma coleção de fontes de reserva no Aspose.Slides for Java para manter o texto consistente e nítido em apresentações PowerPoint e OpenDocument."
---
## **Visão geral**

Aspose.Slides permite configurar uma coleção de regras de fonte de reserva para uma apresentação. Cada regra de reserva é representada pela classe `FontFallBackRule` e pode ser adicionada a uma `FontFallBackRulesCollection`, que implementa a interface `IFontFallBackRulesCollection`.

Após criar a coleção, você pode atribuí‑la à propriedade `FontFallBackRulesCollection` do `FontsManager` da apresentação. O `FontsManager` controla as fontes em toda a apresentação, e cada instância de `Presentation` possui seu próprio `FontsManager`.

Quando o `FontsManager` é inicializado com a coleção de fontes de reserva, as fontes de reserva especificadas são aplicadas durante a renderização da apresentação.

## **Aplicar regras de reserva**

Instâncias da classe [FontFallBackRule](https://reference.aspose.com/slides/pt/java/com.aspose.slides/FontFallBackRule) podem ser organizadas em [FontFallBackRulesCollection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/FontFallBackRulesCollection), que implementa a interface [IFontFallBackRulesCollection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IFontFallBackRulesCollection). É possível adicionar ou remover regras da coleção.

Então essa coleção pode ser atribuída ao método [FontFallBackRulesCollection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/FontFallBackRulesCollection) da classe [FontsManager](https://reference.aspose.com/slides/pt/java/com.aspose.slides/FontsManager). O FontsManager controla as fontes em toda a apresentação.

Cada [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation) tem um método [getFontsManager](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation#getFontsManager--) com sua própria instância da classe [FontsManager](https://reference.aspose.com/slides/pt/java/com.aspose.slides/FontsManager).

Aqui está um exemplo de como criar uma coleção de regras de fontes de reserva e atribuí‑la ao [FontsManager](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation#getFontsManager--) de uma determinada apresentação:  

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

Depois que o FontsManager é inicializado com a coleção de fontes de reserva, as fontes de reserva são aplicadas durante a renderização da apresentação.

{{% alert color="primary" %}} 
Leia mais sobre como [Renderizar apresentação com fonte de reserva](/slides/pt/java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**As minhas regras de reserva serão incorporadas ao arquivo PPTX e ficarão visíveis no PowerPoint após a gravação?**

Não. As regras de reserva são configurações de renderização em tempo de execução; elas não são serializadas no PPTX e não aparecerão na interface do PowerPoint.

**A reserva se aplica a texto dentro de SmartArt, WordArt, gráficos e tabelas?**

Sim. O mesmo mecanismo de substituição de glifos é usado para qualquer texto nesses objetos.

**A Aspose distribui alguma fonte com a biblioteca?**

Não. Você adiciona e usa fontes do seu lado e sob sua própria responsabilidade.

**A substituição de fontes ausentes e a reserva para glifos faltantes podem ser usadas juntas?**

Sim. Elas são estágios independentes do mesmo pipeline de resolução de fontes: primeiro o mecanismo resolve a disponibilidade da fonte ([substituição](/slides/pt/java/font-replacement/)/[substituição](/slides/pt/java/font-substitution/)), então a reserva preenche lacunas para glifos ausentes nas fontes disponíveis.