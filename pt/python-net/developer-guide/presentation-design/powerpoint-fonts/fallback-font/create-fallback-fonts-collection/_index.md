---
title: Configurar Coleções de Fontes de Reserva em Python
linktitle: Coleção de Fonte de Reserva
type: docs
weight: 20
url: /pt/python-net/create-fallback-fonts-collection/
keywords:
- fonte de reserva
- regra de reserva
- coleção de fontes
- configurar fonte
- instalar fonte
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Configure uma coleção de fontes de reserva no Aspose.Slides para Python via .NET para manter o texto consistente e nítido em apresentações PowerPoint e OpenDocument."
---
## **Visão geral**

Aspose.Slides permite que você configure uma coleção de regras de fontes de reserva para uma apresentação. Cada regra de reserva é representada pela classe `FontFallBackRule` e pode ser adicionada a uma `FontFallBackRulesCollection`.

Depois de criar a coleção, você pode atribuí‑la à propriedade `font_fall_back_rules_collection` do `fonts_manager` da apresentação. O `fonts_manager` controla as fontes em toda a apresentação, e cada instância de `Presentation` possui seu próprio `FontsManager`.

Quando o `FontsManager` é inicializado com a coleção de fontes de reserva, as fontes de reserva especificadas são aplicadas durante a renderização da apresentação.

## **Aplicar regras de reserva**

Instâncias da classe [FontFallBackRule](https://reference.aspose.com/slides/pt/python-net/aspose.slides/FontFallBackRule/) podem ser organizadas em [FontFallBackRulesCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fontfallbackrulescollection/). É possível adicionar ou remover regras da coleção.

Em seguida, essa coleção pode ser atribuída à propriedade [font_fall_back_rules_collection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fontsmanager/font_fall_back_rules_collection/) da classe [FontsManager](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fontsmanager/). O FontsManager controla as fontes em toda a apresentação.

Cada [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) tem uma propriedade [fonts_manager](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/fonts_manager/) com sua própria instância da classe FontsManager.

Aqui está um exemplo de como criar uma coleção de regras de fontes de reserva e atribuí‑la ao FontsManager de uma determinada apresentação:  

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
	userRulesList = slides.FontFallBackRulesCollection()

	userRulesList.add(slides.FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"))
	userRulesList.add(slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"))

	presentation.fonts_manager.font_fall_back_rules_collection = userRulesList
```

Depois que o FontsManager é inicializado com a coleção de fontes de reserva, as fontes de reserva são aplicadas durante a renderização da apresentação.

{{% alert color="primary" %}} 
Saiba mais como [Renderizar Apresentação com Fonte de Reserva](/slides/pt/python-net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**As minhas regras de reserva serão incorporadas ao arquivo PPTX e visíveis no PowerPoint após a gravação?**

Não. As regras de reserva são configurações de renderização em tempo de execução; elas não são serializadas no PPTX e não aparecerão na interface do PowerPoint.

**A reserva se aplica ao texto dentro de SmartArt, WordArt, gráficos e tabelas?**

Sim. O mesmo mecanismo de substituição de glifos é usado para qualquer texto nesses objetos.

**A Aspose distribui alguma fonte com a biblioteca?**

Não. Você adiciona e usa fontes do seu lado e sob sua própria responsabilidade.

**A substituição/substituição de fontes ausentes e a reserva para glifos ausentes podem ser usadas juntas?**

Sim. Elas são estágios independentes do mesmo pipeline de resolução de fontes: primeiro o mecanismo resolve a disponibilidade de fontes ([replacement](/slides/pt/python-net/font-replacement/)/[substitution](/slides/pt/python-net/font-substitution/)), em seguida a reserva preenche as lacunas de glifos ausentes nas fontes disponíveis.