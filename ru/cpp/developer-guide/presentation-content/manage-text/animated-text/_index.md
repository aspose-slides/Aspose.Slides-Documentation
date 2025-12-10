---
title: Анимировать текст PowerPoint в C++
linktitle: Анимированный текст
type: docs
weight: 60
url: /ru/cpp/animated-text/
keywords:
- анимированный текст
- анимация текста
- анимированный абзац
- анимация абзаца
- эффект анимации
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Создайте динамический анимированный текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для C++, используя понятные и оптимизированные примеры кода на C++."
---

## **Добавление анимационных эффектов к абзацам**

Мы добавили метод **AddEffect()** в классы **Sequence** и **ISequence**. Этот метод позволяет добавлять анимационные эффекты к отдельному абзацу. Ниже приведён пример кода, показывающий, как добавить анимационный эффект к отдельному абзацу:
``` cpp
String dataDir = GetDataPath();
auto presentation = System::MakeObject<Presentation>(dataDir + u"Presentation1.pptx");

// выбрать абзац для добавления эффекта
auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraphs()->idx_get(0);

// добавить эффект анимации Fly к выбранному абзацу
auto sequence = presentation->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();
auto effect = sequence->AddEffect(paragraph, EffectType::Fly, EffectSubtype::Left, EffectTriggerType::OnClick);

presentation->Save(dataDir + u"AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
```


## **Получение анимационных эффектов для абзацев**

Возможно, вам понадобится определить, какие анимационные эффекты применены к абзацу; например, в одном случае вы хотите получить анимационные эффекты абзаца, чтобы применить их к другому абзацу или фигуре. Aspose.Slides для C++ позволяет получить все анимационные эффекты, применённые к абзацам, содержащимся в текстовом фрейме (фигуре). Ниже приведён пример кода, показывающий, как получить анимационные эффекты в абзаце:
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

**Чем анимация текста отличается от переходов слайдов и можно ли их комбинировать?**

Анимация текста управляет поведением объекта во времени на слайде, тогда как [переходы](/slides/ru/cpp/slide-transition/) управляют переключением слайдов. Они независимы и могут использоваться вместе; порядок воспроизведения определяется шкалой анимации и настройками переходов.

**Сохраняются ли анимации текста при экспорте в PDF или изображения?**

Нет. PDF и растровые изображения статичны, поэтому вы увидите только один фиксированный кадр слайда без движения. Чтобы сохранить анимацию, используйте экспорт в [видео](/slides/ru/cpp/convert-powerpoint-to-video/) или в [HTML](/slides/ru/cpp/export-to-html5/).

**Работают ли анимации текста в макетах и мастере слайдов?**

Эффекты, применённые к объектам макета/мас­тера, наследуются слайдами, однако их тайминг и взаимодействие с анимациями уровня слайда зависят от окончательной последовательности на конкретном слайде.