---
title: Renderizar apresentações com fontes de fallback em C++
linktitle: Renderizar apresentações
type: docs
weight: 30
url: /pt/cpp/render-presentation-with-fallback-font/
keywords:
- fonte de fallback
- renderizar PowerPoint
- renderizar apresentação
- renderizar slide
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Renderizar apresentações com fontes de fallback no Aspose.Slides para C++ – mantenha o texto consistente em PPT, PPTX e ODP com exemplos de código C++ passo a passo."
---
## **Visão geral**

Aspose.Slides permite renderizar apresentações usando regras de fontes de fallback. Este artigo mostra como criar uma coleção de regras de fontes de fallback, modificar suas regras removendo ou adicionando fontes de fallback e atribuir a coleção usando o método `FontsManager::set_FontFallBackRulesCollection`.

Depois que a coleção de regras de fontes de fallback é atribuída ao `FontsManager` da apresentação, as regras são aplicadas durante operações como salvar, renderizar e converter a apresentação. O exemplo demonstra como usar as regras configuradas ao renderizar uma miniatura de slide e salvá‑la como imagem PNG.

## **Renderizar um slide usando regras de fontes de fallback**

O exemplo a seguir inclui estas etapas:

1. Criamos a [coleção de regras de fontes de fallback](/slides/pt/cpp/create-fallback-fonts-collection/).
2. [Remove()](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fontfallbackrule/remove/) uma regra de fonte de fallback e [AddFallBackFonts()](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fontfallbackrule/addfallbackfonts/) para outra regra.
3. Passe a coleção de regras para o método [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/).
4. Com o método [Presentation::Save()](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/save/) podemos salvar a apresentação no mesmo formato ou em outro. Depois que a coleção de regras de fontes de fallback é definida no FontsManager, essas regras são aplicadas durante qualquer operação na apresentação: salvar, renderizar, converter, etc.

``` cpp
// Criar nova instância de uma coleção de regras
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// Criar várias regras
rulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x400), static_cast<uint32_t>(0x4FF), u"Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

for (const auto& fallBackRule : rulesList)
{
	// Tentando remover a fonte FallBack "Tahoma" das regras carregadas
	fallBackRule->Remove(u"Tahoma");

	// E atualizar as regras para o intervalo especificado
	if ((fallBackRule->get_RangeEndIndex() >= static_cast<uint32_t>(0x4000)) && 
		(fallBackRule->get_RangeStartIndex() < static_cast<uint32_t>(0x5000)))
	{
		fallBackRule->AddFallBackFonts(u"Verdana");
	}
}

// Também podemos remover quaisquer regras existentes da lista
if (rulesList->get_Count() > 0)
{
	rulesList->Remove(rulesList->idx_get(0));
}

auto pres = System::MakeObject<Presentation>(u"input.pptx");
// Atribuindo uma lista de regras preparada para uso
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// Renderizando miniatura usando a coleção de regras inicializada e salvando como PNG
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", ImageFormat::Png);
image->Dispose();

pres->Dispose();
```

{{% alert color="primary" %}} 
Saiba mais sobre como [Converter slides do PowerPoint para PNG em C++](/slides/pt/cpp/convert-powerpoint-to-png/).
{{% /alert %}}