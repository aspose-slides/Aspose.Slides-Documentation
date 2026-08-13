---
title: Renderizar apresentações com fontes de reserva no .NET
linktitle: Renderizar apresentações
type: docs
weight: 30
url: /pt/net/render-presentation-with-fallback-font/
keywords:
- fonte de reserva
- renderizar PowerPoint
- renderizar apresentação
- renderizar slide
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Renderizar apresentações com fontes de reserva no Aspose.Slides para .NET – mantenha o texto consistente entre PPT, PPTX e ODP com exemplos de código C# passo a passo."
---
## **Visão geral**

Aspose.Slides permite renderizar apresentações usando regras de fonte de reserva. Este artigo mostra como criar uma coleção de regras de fonte de reserva, modificar suas regras removendo ou adicionando fontes de reserva e atribuir a coleção à propriedade `FontsManager.FontFallBackRulesCollection`.

Depois que a coleção de regras de fonte de reserva é atribuída ao `FontsManager` da apresentação, as regras são aplicadas durante operações como salvar, renderizar e converter a apresentação. O exemplo demonstra como usar as regras configuradas ao renderizar uma miniatura de slide e salvá‑la como imagem PNG.

## **Renderizar um slide usando regras de fonte de reserva**

O exemplo a seguir inclui estas etapas:

1. Nós [criamos a coleção de regras de fonte de reserva](/slides/pt/net/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/pt/net/aspose.slides/fontfallbackrule/methods/remove) uma regra de fonte de reserva e [AddFallBackFonts()](https://reference.aspose.com/slides/pt/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) a outra regra.
1. Defina a coleção de regras na propriedade [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection).
1. Com o método [Presentation.Save()](https://reference.aspose.com/slides/pt/net/aspose.slides.presentation/save/methods/4) podemos salvar a apresentação no mesmo formato ou em outro. Após a coleção de regras de fonte de reserva ser definida no `FontsManager`, essas regras são aplicadas durante qualquer operação sobre a apresentação: salvar, renderizar, converter etc.

```c#
using Aspose.Slides;

// Criar nova instância de uma coleção de regras
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// criar um número de regras
rulesList.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.Add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

foreach (IFontFallBackRule fallBackRule in rulesList)
{
	// Tentando remover a fonte de reserva "Tahoma" das regras carregadas
	fallBackRule.Remove("Tahoma");

	// E atualizar as regras para o intervalo especificado
	if ((fallBackRule.RangeEndIndex >= 0x400) && (fallBackRule.RangeStartIndex < 0x500))
		fallBackRule.AddFallBackFonts("Verdana");
}

// Também podemos remover quaisquer regras existentes da lista, mantendo pelo menos uma regra para renderizar
if (rulesList.Count > 1)
	rulesList.Remove(rulesList[1]);

using (Presentation pres = new Presentation("input.pptx"))
{
    // Atribuindo uma lista de regras preparada para uso
    pres.FontsManager.FontFallBackRulesCollection = rulesList;

    // Renderizando miniatura usando a coleção de regras inicializada e salvando como PNG
    using (IImage image = pres.Slides[0].GetImage(1f, 1f))
    {
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

{{% alert color="info" %}} 
Saiba mais sobre [Salvar e converter em apresentação](/slides/pt/net/convert-powerpoint-to-png/).
{{% /alert %}}