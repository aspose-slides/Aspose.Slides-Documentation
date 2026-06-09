---
title: Animar texto do PowerPoint em .NET
linktitle: Texto Animado
type: docs
weight: 60
url: /pt/net/animated-text/
keywords:
- texto animado
- animação de texto
- parágrafo animado
- animação de parágrafo
- efeito de animação
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Crie texto animado dinâmico em apresentações PowerPoint e OpenDocument usando Aspose.Slides para .NET, com exemplos de código C# claros e otimizados."
---
## **Visão geral**

Este artigo explica como trabalhar com texto animado no Aspose.Slides aplicando efeitos de animação a parágrafos individuais e recuperando os efeitos já atribuídos aos parágrafos em uma moldura de texto. Ele se concentra nos métodos da API usados para adicionar animação ao nível de parágrafo e inspecionar os efeitos de animação de parágrafos existentes em uma apresentação.

## **Adicionar efeitos de animação aos parágrafos**

Adicionamos o [**AddEffect()**](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/sequence/methods/addeffect/index) método às classes [**Sequence**](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/sequence) e [**ISequence**](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/isequence). Esse método permite adicionar efeitos de animação a um único parágrafo. Este código de exemplo mostra como adicionar um efeito de animação a um único parágrafo:

```c#
using (Presentation presentation = new Presentation(dataDir + "Presentation1.pptx"))
{
    // selecione o parágrafo para adicionar o efeito
    IAutoShape autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];

    // adicione o efeito de animação Fly ao parágrafo selecionado
    IEffect effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);


    presentation.Save(dataDir + "AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
}
```

## **Obter efeitos de animação para parágrafos**

Você pode decidir descobrir os efeitos de animação adicionados a um parágrafo — por exemplo, em um cenário, você quer obter os efeitos de animação de um parágrafo porque planeja aplicar esses efeitos a outro parágrafo ou forma.

O Aspose.Slides para .NET permite obter todos os efeitos de animação aplicados a parágrafos contidos em uma moldura de texto (forma). Este código de exemplo mostra como obter os efeitos de animação em um parágrafo:

```c#
using (Presentation pres = new Presentation("Test.pptx"))
{
	ISequence sequence = pres.Slides[0].Timeline.MainSequence;
	IAutoShape autoShape = (IAutoShape)pres.Slides[0].Shapes[1];

	foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs)
	{
		IEffect[] effects = sequence.GetEffectsByParagraph(paragraph);

		if (effects.Length > 0)
			Console.WriteLine("Paragraph \"" + paragraph.Text + "\" has " + effects[0].Type + " effect.");
	}
}
```

## **FAQ**

**Como as animações de texto diferem das transições de slides e podem ser combinadas?**

As animações de texto controlam o comportamento de objetos ao longo do tempo em um slide, enquanto [transições](/slides/pt/net/slide-transition/) controlam como os slides mudam. Elas são independentes e podem ser usadas juntas; a ordem de reprodução é regida pela linha do tempo da animação e pelas configurações de transição.

**As animações de texto são preservadas ao exportar para PDF ou imagens?**

Não. PDFs e imagens raster são estáticos, portanto você verá um único estado do slide sem movimento. Para manter a animação, use a exportação para [vídeo](/slides/pt/net/convert-powerpoint-to-video/) ou [HTML](/slides/pt/net/export-to-html5/).

**As animações de texto funcionam em layouts e no mestre de slides?**

Os efeitos aplicados a objetos de layout/mestre são herdados pelos slides, mas seu tempo e interação com animações ao nível do slide dependem da sequência final no slide.