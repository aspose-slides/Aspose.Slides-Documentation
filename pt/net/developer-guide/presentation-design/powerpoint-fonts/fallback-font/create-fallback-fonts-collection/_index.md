---
title: Configurar coleções de fontes de fallback no .NET
linktitle: Coleção de fontes de fallback
type: docs
weight: 20
url: /pt/net/create-fallback-fonts-collection/
keywords:
- fonte de fallback
- regra de fallback
- coleção de fontes
- configurar fonte
- definir fonte
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Configure uma coleção de fontes de fallback no Aspose.Slides para .NET para manter o texto consistente e nítido em apresentações do PowerPoint e OpenDocument."
---
## **Visão geral**

Aspose.Slides permite configurar uma coleção de regras de fonte de fallback para uma apresentação. Cada regra de fallback é representada pela classe `FontFallBackRule` e pode ser adicionada a uma `FontFallBackRulesCollection`, que implementa a interface `IFontFallBackRulesCollection`.

Depois de criar a coleção, você pode atribuí‑la à propriedade `FontFallBackRulesCollection` do `FontsManager` da apresentação. O `FontsManager` controla as fontes em toda a apresentação, e cada instância de `Presentation` possui seu próprio `FontsManager`.

Quando o `FontsManager` é inicializado com a coleção de fontes de fallback, as fontes de fallback especificadas são aplicadas durante a renderização da apresentação.

## **Aplicar regras de fallback**

Instâncias da classe [FontFallBackRule](https://reference.aspose.com/slides/pt/net/aspose.slides/FontFallBackRule) podem ser organizadas em [FontFallBackRulesCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/fontfallbackrulescollection), que implementa a interface [IFontFallBackRulesCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/ifontfallbackrulescollection). É possível adicionar ou remover regras da coleção.

Em seguida, essa coleção pode ser atribuída à propriedade [FontFallBackRulesCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) da classe [FontsManager](https://reference.aspose.com/slides/pt/net/aspose.slides/fontsmanager). O FontsManager controla as fontes em toda a apresentação.

Cada [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation) tem uma propriedade [FontsManager](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/properties/fontsmanager) com sua própria instância da classe FontsManager.

Aqui está um exemplo de como criar uma coleção de regras de fontes de fallback e atribuí‑la ao FontsManager de uma apresentação específica:  

```c#
using (Presentation presentation = new Presentation())
{
	IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

	userRulesList.Add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
	userRulesList.Add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

	presentation.FontsManager.FontFallBackRulesCollection = userRulesList;
}
```

Depois que o FontsManager é inicializado com a coleção de fontes de fallback, as fontes de fallback são aplicadas durante a renderização da apresentação.

{{% alert color="primary" %}} 
Saiba mais sobre como [Renderizar apresentação com fonte de fallback](/slides/pt/net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**As minhas regras de fallback serão incorporadas ao arquivo PPTX e ficarão visíveis no PowerPoint após a gravação?**

Não. As regras de fallback são configurações de renderização em tempo de execução; elas não são serializadas no PPTX e não aparecerão na interface do PowerPoint.

**O fallback se aplica ao texto dentro de SmartArt, WordArt, gráficos e tabelas?**

Sim. O mesmo mecanismo de substituição de glifos é usado para qualquer texto nesses objetos.

**A Aspose distribui alguma fonte com a biblioteca?**

Não. Você adiciona e usa fontes do seu lado e sob sua própria responsabilidade.

**A substituição/substituição para fontes ausentes e o fallback para glifos ausentes podem ser usados juntos?**

Sim. Eles são etapas independentes do mesmo pipeline de resolução de fontes: primeiro o mecanismo resolve a disponibilidade da fonte ([replacement](/slides/pt/net/font-replacement/)/[substitution](/slides/pt/net/font-substitution/)), depois o fallback preenche lacunas para glifos ausentes em fontes disponíveis.