---
title: Анимированный текст
type: docs
weight: 60
url: /ru/cpp/animated-text/
keywords: "Анимированный текст в PowerPoint"
description: "Анимированный текст в презентации PowerPoint с помощью Aspose.Slides"
---

## Добавление эффектов анимации к абзацам

Мы добавили метод [**AddEffect()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.sequence#a255eb5aaf90861b01980047bc06ead4f) в классы [**Sequence**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.sequence) и [**ISequence**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.i_sequence). Этот метод позволяет добавлять эффекты анимации к одному абзацу. В данном образце кода показано, как добавить эффект анимации к одному абзацу:

``` cpp
String dataDir = GetDataPath();
auto presentation = System::MakeObject<Presentation>(dataDir + u"Presentation1.pptx");

// выберите абзац для добавления эффекта
auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraphs()->idx_get(0);

// добавьте эффект анимации Fly к выбранному абзацу
auto sequence = presentation->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();
auto effect = sequence->AddEffect(paragraph, EffectType::Fly, EffectSubtype::Left, EffectTriggerType::OnClick);

presentation->Save(dataDir + u"AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
```

## Получение эффектов анимации в абзацах

Вы можете решить узнать о эффектах анимации, добавленных к абзацу. Например, в одном сценарии вы хотите получить эффекты анимации в абзаце, потому что планируете применить эти эффекты к другому абзацу или фигуре.

Aspose.Slides для C++ позволяет вам получить все эффекты анимации, примененные к абзацам, содержащимся в текстовом фрейме (фигуре). В этом образце кода показано, как получить эффекты анимации в абзаце:

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
		Console::WriteLine(String(u"Абзац \"") + paragraph->get_Text() + u"\" имеет эффект " + ObjectExt::ToString(effects[0]->get_Type()) + u".");
	}
}
```