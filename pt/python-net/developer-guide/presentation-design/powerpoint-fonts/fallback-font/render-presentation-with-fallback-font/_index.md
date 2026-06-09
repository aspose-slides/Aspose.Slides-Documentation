---
title: Renderizar apresentações com fontes de fallback em Python
linktitle: Renderizar apresentações
type: docs
weight: 30
url: /pt/python-net/render-presentation-with-fallback-font/
keywords:
- fonte de fallback
- renderizar PowerPoint
- renderizar apresentação
- renderizar slide
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Renderizar apresentações com fontes de fallback no Aspose.Slides para Python via .NET – mantenha o texto consistente entre PPT, PPTX e ODP com exemplos de código passo a passo."
---
## **Visão geral**

O Aspose.Slides permite renderizar apresentações usando regras de fontes de fallback. Este artigo mostra como criar uma coleção de regras de fontes de fallback, modificar suas regras removendo ou adicionando fontes de fallback e atribuir a coleção à propriedade `FontsManager.font_fall_back_rules_collection`.

Depois que a coleção de regras de fontes de fallback é atribuída ao `fonts_manager` da apresentação, as regras são aplicadas durante operações como salvar, renderizar e converter a apresentação. O exemplo demonstra como usar as regras configuradas ao renderizar uma miniatura de slide e salvá‑la como uma imagem PNG.

## **Renderizar um slide usando regras de fontes de fallback**

O exemplo a seguir inclui estas etapas:

1. Nós [criamos a coleção de regras de fontes de fallback](/slides/pt/python-net/create-fallback-fonts-collection/).
2. [Remover](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fontfallbackrule/remove/) uma regra de fonte de fallback e [add_fall_back_fonts](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fontfallbackrule/add_fall_back_fonts/) a outra regra.
3. Defina a coleção de regras para a propriedade [FontsManager.font_fall_back_rules_collection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fontsmanager/font_fall_back_rules_collection/).
4. Com o método [Presentation.save()](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) podemos salvar a apresentação no mesmo formato ou em outro. Depois que a coleção de regras de fontes de fallback é definida no FontsManager, essas regras são aplicadas durante quaisquer operações sobre a apresentação: salvar, renderizar, converter, etc.

```py
import aspose.slides as slides

# Criar nova instância de uma coleção de regras
rulesList = slides.FontFallBackRulesCollection()

# criar várias regras
rulesList.add(slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"))

for fallBackRule in rulesList:
	# Tentando remover a fonte de fallback "Tahoma" das regras carregadas
	fallBackRule.remove("Tahoma")

	# E atualizar as regras para o intervalo especificado
	if fallBackRule.range_end_index >= 0x4000 and fallBackRule.range_start_index < 0x5000:
		fallBackRule.add_fall_back_fonts("Verdana")

# Também podemos remover quaisquer regras existentes da lista
if len(rulesList) > 0:
	rulesList.remove(rulesList[0])

with slides.Presentation(path + "input.pptx") as pres:
	# Atribuindo uma lista de regras preparada para uso
	pres.fonts_manager.font_fall_back_rules_collection = rulesList

	# Renderizando miniatura usando a coleção de regras inicializada e salvando como PNG
	with pres.slides[0].get_image(1, 1) as img:
		img.save("Slide_0.png", slides.ImageFormat.PNG)
```

{{% alert color="primary" %}} 
Saiba mais sobre como [Converter slides do PowerPoint para PNG em Python](/slides/pt/python-net/convert-powerpoint-to-png/).
{{% /alert %}}