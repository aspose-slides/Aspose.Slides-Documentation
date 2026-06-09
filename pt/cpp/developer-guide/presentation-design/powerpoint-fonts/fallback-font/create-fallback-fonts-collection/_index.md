---
title: Configurar coleções de fontes de fallback em C++
linktitle: Coleção de Fonte de Fallback
type: docs
weight: 20
url: /pt/cpp/create-fallback-fonts-collection/
keywords:
- fonte de fallback
- regra de fallback
- coleção de fontes
- configurar fonte
- configurar fonte
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Configure uma coleção de fontes de fallback no Aspose.Slides para C++ para manter o texto consistente e nítido em apresentações do PowerPoint e OpenDocument."
---
## **Visão geral**

Aspose.Slides permite configurar uma coleção de regras de fontes de fallback para uma apresentação. Cada regra de fallback é representada pela classe `FontFallBackRule` e pode ser adicionada a uma `FontFallBackRulesCollection`, que implementa a interface `IFontFallBackRulesCollection`.

Após criar a coleção, você pode atribuí‑la usando o método `set_FontFallBackRulesCollection` do `FontsManager` da apresentação. O `FontsManager` controla as fontes em toda a apresentação, e cada instância de `Presentation` possui seu próprio `FontsManager`.

Depois que o `FontsManager` é inicializado com a coleção de fontes de fallback, as fontes de fallback especificadas são aplicadas durante a renderização da apresentação.

## **Aplicar regras de fallback**

Instâncias da classe [FontFallBackRule](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fontfallbackrule/) podem ser organizadas em [FontFallBackRulesCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fontfallbackrulescollection/), que implementa a interface [IFontFallBackRulesCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ifontfallbackrulescollection/). É possível adicionar ou remover regras da coleção.

Em seguida, essa coleção pode ser passada ao método [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) da classe [FontsManager](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fontsmanager/). O FontsManager controla as fontes em toda a apresentação.

Cada [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) tem um método [get_FontsManager()](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/get_fontsmanager/) com sua própria instância da classe FontsManager.

Aqui está um exemplo de como criar a coleção de regras de fontes de fallback e atribuí‑la ao FontsManager de uma determinada apresentação:  

``` cpp
auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```

Depois que o FontsManager é inicializado com a coleção de fontes de fallback, as fontes de fallback são aplicadas durante a renderização da apresentação.

{{% alert color="primary" %}} 
Saiba mais como [Render Presentation with Fallback Font](/slides/pt/cpp/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Perguntas frequentes**

**Minhas regras de fallback serão incorporadas ao arquivo PPTX e ficarão visíveis no PowerPoint após a gravação?**

Não. As regras de fallback são configurações de renderização em tempo de execução; não são serializadas no PPTX e não aparecerão na interface do PowerPoint.

**O fallback se aplica ao texto dentro de SmartArt, WordArt, gráficos e tabelas?**

Sim. O mesmo mecanismo de substituição de glifos é usado para qualquer texto nesses objetos.

**A Aspose distribui alguma fonte com a biblioteca?**

Não. Você adiciona e usa fontes do seu lado e sob sua própria responsabilidade.

**A substituição/substituição de fontes ausentes e o fallback para glifos ausentes podem ser usados juntos?**

Sim. Eles são estágios independentes do mesmo pipeline de resolução de fontes: primeiro o mecanismo resolve a disponibilidade de fontes ([replacement](/slides/pt/cpp/font-replacement/)/[substitution](/slides/pt/cpp/font-substitution/)), depois o fallback preenche lacunas de glifos ausentes em fontes disponíveis.