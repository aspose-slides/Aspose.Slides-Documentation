---
title: Renderizar apresentações com fontes de fallback em Python via Java
linktitle: Renderizar apresentações
type: docs
weight: 30
url: /pt/python-java/render-presentation-with-fallback-font/
keywords:
- fonte de fallback
- renderizar PowerPoint
- renderizar apresentação
- renderizar slide
- PowerPoint
- OpenDocument
- apresentação
- Python
- Java
- Aspose.Slides
description: "Renderizar apresentações com fontes de fallback no Aspose.Slides para Python via Java – mantenha o texto consistente em PPT, PPTX e ODP com exemplos de código Python passo a passo."
---
## **Visão geral**

Aspose.Slides permite renderizar apresentações usando regras de fontes de fallback. Este artigo mostra como criar uma coleção de regras de fontes de fallback, modificar suas regras removendo ou adicionando fontes de fallback e atribuir a coleção usando o método [FontsManager.setFontFallBackRulesCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection).

Quando a coleção de regras de fontes de fallback é atribuída ao [FontsManager](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontsmanager/) da apresentação, as regras são aplicadas durante operações como salvar, renderizar e converter a apresentação. O exemplo demonstra como usar as regras configuradas ao renderizar uma miniatura de slide e salvá‑la como imagem JPEG.

## **Renderizar um slide usando regras de fontes de fallback**

O exemplo a seguir inclui estas etapas:

1. [Criar uma coleção de regras de fontes de fallback](/slides/pt/python-java/create-fallback-fonts-collection/).
2. [Remover](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontfallbackrule/#remove) uma fonte de fallback de uma regra e [adicionar fontes de fallback](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontfallbackrule/#addFallBackFonts) a outra regra.
3. Atribuir a coleção de regras usando [setFontFallBackRulesCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) no gerenciador de fontes retornado por [getFontsManager](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getFontsManager).
4. Usar o método [Presentation.save](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#save) para salvar a apresentação no mesmo formato ou em outro formato. Após a coleção de regras de fontes de fallback ser atribuída ao [FontsManager](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontsmanager/), essas regras são aplicadas durante as operações na apresentação: salvar, renderizar, converter etc.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule, FontFallBackRulesCollection, ImageFormat, Presentation

# Crie uma nova coleção de regras.
fallback_rules = FontFallBackRulesCollection()

# Crie várias regras.
cyrillic_rule = FontFallBackRule(0x400, 0x4FF, "Times New Roman")
fallback_rules.add(cyrillic_rule)
arabic_rule = FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial")
fallback_rules.add(arabic_rule)

for fallback_rule in fallback_rules:
    # Tente remover a fonte de fallback "Tahoma" das regras.
    fallback_rule.remove("Tahoma")

    # Atualize as regras para o intervalo especificado.
    if fallback_rule.getRangeEndIndex() >= 0x400 and fallback_rule.getRangeStartIndex() < 0x500:
        fallback_rule.addFallBackFonts("Verdana")

# Remova uma regra existente, mantendo ao menos uma regra para renderização.
if fallback_rules.size() > 1:
    rule_to_remove = fallback_rules.get_Item(1)
    fallback_rules.remove(rule_to_remove)

presentation = Presentation("input.pptx")
try:
    # Atribua a coleção de regras preparada.
    presentation.getFontsManager().setFontFallBackRulesCollection(fallback_rules)

    # Renderize uma miniatura usando a coleção de regras configurada.
    slide_image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        # Salve a imagem no disco no formato JPEG.
        slide_image.save("Slide_0.jpg", ImageFormat.Jpeg)
    finally:
        slide_image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Observação" %}}
Saiba mais sobre como [converter PPT e PPTX para JPG em Python via Java](/slides/pt/python-java/convert-powerpoint-to-jpg/).
{{% /alert %}}