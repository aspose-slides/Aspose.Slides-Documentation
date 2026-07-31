---
title: Отрисовка презентаций с резервными шрифтами в C++
linktitle: Отрисовка презентаций
type: docs
weight: 30
url: /ru/cpp/render-presentation-with-fallback-font/
keywords:
- резервный шрифт
- отрисовка PowerPoint
- отрисовка презентации
- отрисовка слайда
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Отрисовка презентаций с резервными шрифтами в Aspose.Slides для C++ – обеспечьте единообразие текста в PPT, PPTX и ODP с помощью пошаговых примеров кода на C++."
---
## **Обзор**

Aspose.Slides позволяет отрисовывать презентации с использованием правил резервных шрифтов. В этой статье показано, как создать коллекцию правил резервных шрифтов, изменить её правила, удаляя или добавляя резервные шрифты, и назначить коллекцию с помощью метода `FontsManager::set_FontFallBackRulesCollection`.

После того как коллекция правил резервных шрифтов назначена менеджеру шрифтов презентации `FontsManager`, правила применяются во время операций, таких как сохранение, отрисовка и конвертация презентации. Пример демонстрирует, как использовать сконфигурированные правила при отрисовке миниатюры слайда и сохранении её в виде PNG‑изображения.

## **Отрисовка слайда с использованием правил резервных шрифтов**

1. Мы [создаём коллекцию правил резервных шрифтов](/slides/ru/cpp/create-fallback-fonts-collection/).
1. [Remove()] правило резервного шрифта и [AddFallBackFonts()] к другому правилу.
1. Передайте коллекцию правил в метод [FontsManager::set_FontFallBackRulesCollection()].
1. С помощью метода [Presentation::Save()] мы можем сохранить презентацию в том же формате или в другом. После того как коллекция правил резервных шрифтов установлена в FontsManager, эти правила применяются при любых операциях с презентацией: сохранение, отрисовка, конвертация и т.д.

``` cpp
// Создать новый экземпляр коллекции правил
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// Создать несколько правил
rulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x400), static_cast<uint32_t>(0x4FF), u"Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

for (const auto& fallBackRule : rulesList)
{
	// Пытаемся удалить резервный шрифт "Tahoma" из загруженных правил
	fallBackRule->Remove(u"Tahoma");

	// И обновить правила для указанного диапазона
	if ((fallBackRule->get_RangeEndIndex() >= static_cast<uint32_t>(0x4000)) && 
		(fallBackRule->get_RangeStartIndex() < static_cast<uint32_t>(0x5000)))
	{
		fallBackRule->AddFallBackFonts(u"Verdana");
	}
}

// Также мы можем удалить любые существующие правила из списка
if (rulesList->get_Count() > 0)
{
	rulesList->Remove(rulesList->idx_get(0));
}

auto pres = System::MakeObject<Presentation>(u"input.pptx");
// Назначаем подготовленный список правил для использования
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// Отрисовка миниатюры с использованием инициализированной коллекции правил и сохранение в PNG
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", ImageFormat::Png);
image->Dispose();

pres->Dispose();
```

{{% alert color="primary" %}} 
Подробнее о том, как [Convert PowerPoint Slides to PNG in C++](/slides/ru/cpp/convert-powerpoint-to-png/).
{{% /alert %}}