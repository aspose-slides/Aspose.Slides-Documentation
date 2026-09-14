---
title: Configurar coleções de fontes de fallback em Python via Java
linktitle: Coleção de fontes de fallback
type: docs
weight: 20
url: /pt/python-java/create-fallback-fonts-collection/
keywords:
- fonte de fallback
- regra de fallback
- coleção de fontes
- configurar fonte
- configurar fonte
- PowerPoint
- OpenDocument
- apresentação
- Python
- Java
- Aspose.Slides
description: "Configure uma coleção de fontes de fallback no Aspose.Slides para Python via Java para manter o texto consistente e nítido em apresentações PowerPoint e OpenDocument."
---
## **Visão geral**

Aspose.Slides permite que você configure uma coleção de regras de fonte de fallback para uma apresentação. Cada regra de fallback é representada pela classe [FontFallBackRule](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontfallbackrule/) e pode ser adicionada a uma [FontFallBackRulesCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontfallbackrulescollection/).

Depois de criar a coleção, você pode atribuí‑la usando o método [setFontFallBackRulesCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) do [FontsManager](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontsmanager/) da apresentação. O [FontsManager](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontsmanager/) controla as fontes em toda a apresentação, e cada instância de [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) possui seu próprio [FontsManager](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontsmanager/).

Quando o [FontsManager](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontsmanager/) é inicializado com a coleção de fontes de fallback, as fontes de fallback especificadas são aplicadas durante a renderização da apresentação.

## **Aplicar regras de fallback**

Instâncias da classe [FontFallBackRule](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontfallbackrule/) podem ser organizadas em uma [FontFallBackRulesCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontfallbackrulescollection/). Você pode adicionar ou remover regras da coleção.

Essa coleção pode então ser atribuída usando o método [setFontFallBackRulesCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) da classe [FontsManager](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontsmanager/), que controla as fontes em toda a apresentação.

Cada [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) possui um método [getFontsManager](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getFontsManager) que devolve sua própria instância da classe [FontsManager](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontsmanager/).

O exemplo a seguir mostra como criar uma coleção de regras de fonte de fallback e atribuí‑la ao [FontsManager](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontsmanager/) de uma apresentação:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule, FontFallBackRulesCollection, Presentation

presentation = Presentation()
try:
    fallback_rules = FontFallBackRulesCollection()

    tamil_rule = FontFallBackRule(0x0B80, 0x0BFF, "Vijaya")
    fallback_rules.add(tamil_rule)
    hiragana_rule = FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")
    fallback_rules.add(hiragana_rule)

    presentation.getFontsManager().setFontFallBackRulesCollection(fallback_rules)
finally:
    presentation.dispose()
```

Após o [FontsManager](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontsmanager/) ser inicializado com a coleção de fontes de fallback, as fontes de fallback são aplicadas durante a renderização da apresentação.

{{% alert color="info" title="Note" %}}
Saiba mais sobre como [renderizar uma apresentação com uma fonte de fallback](/slides/pt/python-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Perguntas frequentes**

**As minhas regras de fallback serão incorporadas ao arquivo PPTX e ficarão visíveis no PowerPoint após a gravação?**

Não. As regras de fallback são configurações de renderização em tempo de execução; elas não são serializadas no PPTX e não aparecerão na interface do PowerPoint.

**O fallback se aplica a textos dentro de SmartArt, WordArt, gráficos e tabelas?**

Sim. O mesmo mecanismo de substituição de glifos é usado para qualquer texto nesses objetos.

**A Aspose distribui alguma fonte com a biblioteca?**

Não. Você adiciona e usa fontes do seu lado, sob sua própria responsabilidade.

**A substituição/substituição de fontes ausentes e o fallback para glifos ausentes podem ser usados juntos?**

Sim. Eles são estágios independentes do mesmo pipeline de resolução de fontes: primeiro o motor resolve a disponibilidade de fontes ([replacement](/slides/pt/python-java/font-replacement/)/[substitution](/slides/pt/python-java/font-substitution/)), depois o fallback preenche lacunas de glifos ausentes nas fontes disponíveis.