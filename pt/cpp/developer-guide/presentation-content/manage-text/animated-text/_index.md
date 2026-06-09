---
title: Anima Texto do PowerPoint em C++
linktitle: Texto Animado
type: docs
weight: 60
url: /pt/cpp/animated-text/
keywords:
- texto animado
- animação de texto
- parágrafo animado
- animação de parágrafo
- efeito de animação
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Crie textos animados dinâmicos em apresentações PowerPoint e OpenDocument usando Aspose.Slides para C++, com exemplos de código C++ fáceis de seguir e otimizados."
---
## **Visão Geral**

Este artigo explica como trabalhar com texto animado no Aspose.Slides aplicando efeitos de animação a parágrafos individuais e recuperando os efeitos já atribuídos aos parágrafos em um quadro de texto. Ele foca nos métodos da API usados para adicionar animação ao nível de parágrafo e inspecionar os efeitos de animação de parágrafo existentes em uma apresentação.

## **Adicionar Efeitos de Animação a Parágrafos**

Adicionamos o método [**AddEffect()**](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.animation.sequence#a255eb5aaf90861b01980047bc06ead4f) às classes [**Sequence**](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.animation.sequence) e [**ISequence**](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.animation.i_sequence). Esse método permite adicionar efeitos de animação a um único parágrafo. Este código de exemplo mostra como adicionar um efeito de animação a um único parágrafo:

``` cpp
String dataDir = GetDataPath();
auto presentation = System::MakeObject<Presentation>(dataDir + u"Presentation1.pptx");

// selecionar parágrafo para adicionar efeito
auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraphs()->idx_get(0);

// adicionar efeito de animação Fly ao parágrafo selecionado
auto sequence = presentation->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();
auto effect = sequence->AddEffect(paragraph, EffectType::Fly, EffectSubtype::Left, EffectTriggerType::OnClick);

presentation->Save(dataDir + u"AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
```

## **Obter Efeitos de Animação para Parágrafos**

Você pode decidir descobrir os efeitos de animação adicionados a um parágrafo; por exemplo, em um cenário, você quer obter os efeitos de animação em um parágrafo porque planeja aplicar esses efeitos a outro parágrafo ou forma.

Aspose.Slides para C++ permite obter todos os efeitos de animação aplicados aos parágrafos contidos em um quadro de texto (forma). Este código de exemplo mostra como obter os efeitos de animação em um parágrafo:

``` cpp
String dataDir = GetDataPath();
auto pres = System::MakeObject<Presentation>(dataDir + u"Test.pptx");

auto sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();
auto autoShape = System::ExplicitCast<IAutoShape>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(1));

for (auto paragraph : autoShape->get_TextFrame()->get_Paragraphs())
{
	auto effects = sequence->GetEffectsByParagraph(paragraph);

	if (effects->get_Length() > 0)
	{
		Console::WriteLine(String(u"Paragraph \"") + paragraph->get_Text() + u"\" has " + ObjectExt::ToString(effects[0]->get_Type()) + u" effect.");
	}
}
```

## **FAQ**

**Como as animações de texto diferem das transições de slides e podem ser combinadas?**

As animações de texto controlam o comportamento de objetos ao longo do tempo em um slide, enquanto as [transitions](/slides/pt/cpp/slide-transition/) controlam como os slides mudam. Elas são independentes e podem ser usadas juntas; a ordem de reprodução é determinada pela linha do tempo da animação e pelas configurações de transição.

**As animações de texto são preservadas ao exportar para PDF ou imagens?**

Não. PDF e imagens raster são estáticos, portanto você verá um único estado do slide sem movimento. Para manter a animação, use a exportação para [video](/slides/pt/cpp/convert-powerpoint-to-video/) ou [HTML](/slides/pt/cpp/export-to-html5/).

**As animações de texto funcionam em layouts e no mestre de slides?**

Os efeitos aplicados a objetos de layout/mestre são herdados pelos slides, mas seu tempo e interação com animações ao nível do slide dependem da sequência final no slide.