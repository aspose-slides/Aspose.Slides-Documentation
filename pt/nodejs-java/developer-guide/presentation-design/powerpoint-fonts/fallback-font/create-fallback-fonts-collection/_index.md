---
title: Configurar Coleções de Fontes de Reserva em JavaScript
linktitle: Coleção de Fontes de Reserva
type: docs
weight: 20
url: /pt/nodejs-java/create-fallback-fonts-collection/
keywords:
- fonte de reserva
- regra de reserva
- coleção de fontes
- configurar fonte
- configurar fonte
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Configure uma coleção de fontes de reserva em JavaScript com Aspose.Slides para Node.js para manter o texto consistente e nítido em apresentações PowerPoint e OpenDocument."
---
## **Visão geral**

O Aspose.Slides permite que você configure uma coleção de regras de fonte de reserva para uma apresentação. Cada regra de reserva é representada pela classe `FontFallBackRule` e pode ser adicionada a uma `FontFallBackRulesCollection`.

Depois de criar a coleção, você pode atribuí‑la usando o método `setFontFallBackRulesCollection` do `FontsManager` da apresentação. O `FontsManager` controla as fontes em toda a apresentação, e cada instância de `Presentation` possui seu próprio `FontsManager`.

Quando o `FontsManager` é inicializado com a coleção de fontes de reserva, as fontes de reserva especificadas são aplicadas durante a renderização da apresentação.

## **Aplicar Regras de Reserva**

Instâncias da classe [FontFallBackRule](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/FontFallBackRule) podem ser organizadas em [FontFallBackRulesCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/FontFallBackRulesCollection), que implementa a classe [FontFallBackRulesCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/FontFallBackRulesCollection). É possível adicionar ou remover regras da coleção.

Em seguida, essa coleção pode ser atribuída ao método [FontFallBackRulesCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/FontFallBackRulesCollection) da classe [FontsManager](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/FontsManager). O FontsManager controla as fontes em toda a apresentação.

Cada [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation) possui um método [getFontsManager](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation#getFontsManager--) com sua própria instância da classe [FontsManager](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/FontsManager).

Aqui está um exemplo de como criar uma coleção de regras de fontes de reserva e atribuí‑la ao [FontsManager](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation#getFontsManager--) de uma determinada apresentação:  

```javascript
var pres = new aspose.slides.Presentation();
try {
    var userRulesList = new aspose.slides.FontFallBackRulesCollection();
    userRulesList.add(new aspose.slides.FontFallBackRule(0xb80, 0xbff, "Vijaya"));
    userRulesList.add(new aspose.slides.FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic"));
    pres.getFontsManager().setFontFallBackRulesCollection(userRulesList);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Depois que o FontsManager é inicializado com a coleção de fontes de reserva, as fontes de reserva são aplicadas durante a renderização da apresentação.

{{% alert color="primary" %}} 
Leia mais sobre como [Renderizar Apresentação com Fonte de Reserva](/slides/pt/nodejs-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**As minhas regras de reserva serão incorporadas ao arquivo PPTX e ficarão visíveis no PowerPoint após a gravação?**

Não. As regras de reserva são configurações de renderização em tempo de execução; não são serializadas no PPTX e não aparecerão na interface do PowerPoint.

**A reserva se aplica ao texto dentro de SmartArt, WordArt, gráficos e tabelas?**

Sim. O mesmo mecanismo de substituição de glifos é usado para qualquer texto nesses objetos.

**A Aspose distribui fontes com a biblioteca?**

Não. Você adiciona e usa fontes do seu lado, sob sua própria responsabilidade.

**A substituição/substituição de fontes ausentes e a reserva para glifos ausentes podem ser usadas juntas?**

Sim. Elas são etapas independentes do mesmo pipeline de resolução de fontes: primeiro o mecanismo resolve a disponibilidade de fontes ([replacement](/slides/pt/nodejs-java/font-replacement/)/[substitution](/slides/pt/nodejs-java/font-substitution/)), então a reserva preenche as lacunas de glifos ausentes nas fontes disponíveis.