---
title: C++에서 PowerPoint 텍스트 애니메이션
linktitle: 애니메이션 텍스트
type: docs
weight: 60
url: /ko/cpp/animated-text/
keywords:
- 애니메이션 텍스트
- 텍스트 애니메이션
- 애니메이션 단락
- 단락 애니메이션
- 애니메이션 효과
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 동적인 애니메이션 텍스트를 만들고, 따라하기 쉬운 최적화된 C++ 코드 예제를 제공합니다."
---
## **개요**

이 문서는 Aspose.Slides에서 애니메이션 텍스트를 사용하여 개별 단락에 애니메이션 효과를 적용하고 텍스트 프레임의 단락에 이미 할당된 효과를 검색하는 방법을 설명합니다. 프레젠테이션에서 단락 수준 애니메이션을 추가하고 기존 단락 애니메이션 효과를 검사하는 데 사용되는 API 메서드에 중점을 둡니다.

## **단락에 애니메이션 효과 추가**

우리는 [**AddEffect()**](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.animation.sequence#a255eb5aaf90861b01980047bc06ead4f) 메서드를 [**Sequence**](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.animation.sequence) 및 [**ISequence**](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.animation.i_sequence) 클래스에 추가했습니다. 이 메서드를 사용하면 단일 단락에 애니메이션 효과를 추가할 수 있습니다. 다음 샘플 코드는 단일 단락에 애니메이션 효과를 추가하는 방법을 보여줍니다:

``` cpp
String dataDir = GetDataPath();
auto presentation = System::MakeObject<Presentation>(dataDir + u"Presentation1.pptx");

// 효과를 추가할 단락 선택
auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraphs()->idx_get(0);

// 선택한 단락에 Fly 애니메이션 효과 추가
auto sequence = presentation->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();
auto effect = sequence->AddEffect(paragraph, EffectType::Fly, EffectSubtype::Left, EffectTriggerType::OnClick);

presentation->Save(dataDir + u"AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
```

## **단락에 대한 애니메이션 효과 가져오기**

예를 들어 단락에 추가된 애니메이션 효과를 찾아야 할 상황이 있을 수 있습니다. 한 시나리오에서는 해당 효과를 다른 단락이나 도형에 적용하려고 할 때 단락의 애니메이션 효과를 가져오고 싶을 수 있습니다.

Aspose.Slides for C++를 사용하면 텍스트 프레임(도형) 내에 포함된 모든 단락에 적용된 애니메이션 효과를 가져올 수 있습니다. 다음 샘플 코드는 단락의 애니메이션 효과를 가져오는 방법을 보여줍니다:

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

**텍스트 애니메이션은 슬라이드 전환과 어떻게 다르며, 결합할 수 있나요?**

텍스트 애니메이션은 슬라이드에서 객체의 동작을 시간에 따라 제어하고, [transitions](/slides/ko/cpp/slide-transition/)는 슬라이드가 전환되는 방식을 제어합니다. 두 기능은 독립적이며 함께 사용할 수 있으며, 재생 순서는 애니메이션 타임라인과 전환 설정에 따라 결정됩니다.

**PDF나 이미지로 내보낼 때 텍스트 애니메이션이 유지되나요?**

아니요. PDF와 래스터 이미지 파일은 정적인 파일이므로 슬라이드의 움직임 없이 한 순간만 표시됩니다. 움직임을 보존하려면 [video](/slides/ko/cpp/convert-powerpoint-to-video/) 또는 [HTML](/slides/ko/cpp/export-to-html5/)으로 내보내세요.

**레이아웃 및 슬라이드 마스터에서도 텍스트 애니메이션이 작동하나요?**

레이아웃/마스터 객체에 적용된 효과는 슬라이드에 상속되지만, 타이밍과 슬라이드 수준 애니메이션과의 상호 작용은 해당 슬라이드의 최종 시퀀스에 따라 결정됩니다.