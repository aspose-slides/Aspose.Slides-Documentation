---
title: Renderizar apresentações com fontes de fallback no .NET
linktitle: Renderizar apresentações
type: docs
weight: 30
url: /pt/net/render-presentation-with-fallback-font/
keywords:
- fonte de fallback
- renderizar PowerPoint
- renderizar apresentação
- renderizar slide
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Renderize apresentações com fontes de fallback no Aspose.Slides para .NET – mantenha o texto consistente em PPT, PPTX e ODP com exemplos de código C# passo a passo."
---
## **Visão geral**

O Aspose.Slides permite que você renderize apresentações usando regras de fontes de fallback. Este artigo mostra como criar uma coleção de regras de fontes de fallback, modificar suas regras removendo ou adicionando fontes de fallback e atribuir a coleção à propriedade `FontsManager.FontFallBackRulesCollection`.

Uma vez que a coleção de regras de fontes de fallback é atribuída ao `FontsManager` da apresentação, as regras são aplicadas durante operações como salvar, renderizar e converter a apresentação. O exemplo demonstra como usar as regras configuradas ao renderizar a miniatura de um slide e salvá‑la como imagem PNG.

## **Renderizar um Slide Usando Regras de Fonte Fallback**

1. Criamos a [coleção de regras de fonte fallback](/slides/pt/net/create-fallback-fonts-collection/).
2. [Remove()](https://reference.aspose.com/slides/pt/net/aspose.slides/fontfallbackrule/methods/remove) remove uma regra de fonte fallback e [AddFallBackFonts()](https://reference.aspose.com/slides/pt/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) adiciona fontes de fallback a outra regra.
3. Define a coleção de regras na propriedade [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection).
4. Com o método [Presentation.Save()](https://reference.aspose.com/slides/pt/net/aspose.slides.presentation/save/methods/4) podemos salvar a apresentação no mesmo formato ou em outro formato. Após a coleção de regras de fontes de fallback ser definida no FontsManager, essas regras são aplicadas durante quaisquer operações sobre a apresentação: salvar, renderizar, converter etc.

```c#
// Criar nova instância de uma coleção de regras
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// criar um número de regras
rulesList.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

foreach (IFontFallBackRule fallBackRule in rulesList)
{
	//Tentando remover a fonte FallBack "Tahoma" das regras carregadas
	fallBackRule.Remove("Tahoma");

	//E atualizar as regras para o intervalo especificado
	if ((fallBackRule.RangeEndIndex >= 0x4000) && (fallBackRule.RangeStartIndex < 0x5000))
		fallBackRule.AddFallBackFonts("Verdana");
}

//Também podemos remover quaisquer regras existentes da lista
if (rulesList.Count > 0)
	rulesList.Remove(rulesList[0]);

using (Presentation pres = new Presentation("input.pptx"))
{
    //Atribuindo uma lista de regras preparada para uso
    pres.FontsManager.FontFallBackRulesCollection = rulesList;

    // Renderizando miniatura usando a coleção de regras inicializada e salvando como PNG
    using (IImage image = pres.Slides[0].GetImage(1f, 1f))
    {
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

{{% alert color="primary" %}} 
Leia mais sobre [Salvar e Conversão em Apresentação](/slides/pt/net/convert-powerpoint-to-png/).
{{% /alert %}}