---
title: .NET에서 PowerPoint 텍스트 애니메이션 만들기
linktitle: 애니메이션 텍스트
type: docs
weight: 60
url: /ko/net/animated-text/
keywords:
- 애니메이션 텍스트
- 텍스트 애니메이션
- 애니메이션 단락
- 단락 애니메이션
- 애니메이션 효과
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 동적인 애니메이션 텍스트를 만들고, 따라하기 쉬운 최적화된 C# 코드 예제를 제공합니다."
---
## **개요**

본 문서는 Aspose.Slides에서 개별 단락에 애니메이션 효과를 적용하고 텍스트 프레임의 단락에 이미 할당된 효과를 검색하는 방법을 설명합니다. 프레젠테이션에서 단락 수준 애니메이션을 추가하고 기존 단락 애니메이션 효과를 검사하는 데 사용되는 API 메서드에 중점을 둡니다.

## **단락에 애니메이션 효과 추가**

우리는 [**Sequence**](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/sequence) 및 [**ISequence**](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/isequence) 클래스에 [**AddEffect()**](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/sequence/methods/addeffect/index) 메서드를 추가했습니다. 이 메서드를 사용하면 단일 단락에 애니메이션 효과를 추가할 수 있습니다. 다음 샘플 코드는 단일 단락에 애니메이션 효과를 추가하는 방법을 보여줍니다:

```c#
using (Presentation presentation = new Presentation(dataDir + "Presentation1.pptx"))
{
    // 효과를 추가할 단락 선택
    IAutoShape autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];

    // 선택된 단락에 Fly 애니메이션 효과 추가
    IEffect effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);


    presentation.Save(dataDir + "AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
}
```

## **단락에 대한 애니메이션 효과 가져오기**

단락에 추가된 애니메이션 효과를 확인하고 싶을 수 있습니다—예를 들어, 한 시나리오에서는 다른 단락이나 모양에 해당 효과를 적용하려고 단락의 애니메이션 효과를 가져오고자 합니다.

Aspose.Slides for .NET은 텍스트 프레임(모양) 내의 단락에 적용된 모든 애니메이션 효과를 가져올 수 있게 해줍니다. 다음 샘플 코드는 단락의 애니메이션 효과를 가져오는 방법을 보여줍니다:

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

**텍스트 애니메이션은 슬라이드 전환과 어떻게 다르며, 결합할 수 있나요?**

텍스트 애니메이션은 슬라이드 상에서 객체의 동작을 시간에 따라 제어하고, [transitions](/slides/ko/net/slide-transition/)은 슬라이드가 바뀌는 방식을 제어합니다. 두 기능은 독립적이며 함께 사용할 수 있습니다; 재생 순서는 애니메이션 타임라인과 전환 설정에 따라 결정됩니다.

**PDF 또는 이미지로 내보낼 때 텍스트 애니메이션이 유지되나요?**

아니요. PDF 및 래스터 이미지 형식은 정적이므로 슬라이드의 움직임 없이 단일 상태만 표시됩니다. 움직임을 유지하려면 [video](/slides/ko/net/convert-powerpoint-to-video/) 또는 [HTML](/slides/ko/net/export-to-html5/) 형식으로 내보내세요.

**텍스트 애니메이션이 레이아웃 및 슬라이드 마스터에서도 작동하나요?**

레이아웃/마스터 객체에 적용된 효과는 슬라이드에 상속되지만, 해당 타이밍 및 슬라이드 수준 애니메이션과의 상호 작용은 슬라이드의 최종 시퀀스에 따라 달라집니다.