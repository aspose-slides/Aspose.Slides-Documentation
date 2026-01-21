---
title: Отображение презентаций с резервными шрифтами в С++
linktitle: Отображение презентаций
type: docs
weight: 30
url: /ru/cpp/render-presentation-with-fallback-font/
keywords:
- резервный шрифт
- отображение PowerPoint
- отображение презентации
- отображение слайда
- PowerPoint
- OpenDocument
- презентация
- С++
- Aspose.Slides
description: "Отображайте презентации с резервными шрифтами в Aspose.Slides для С++ – сохраняйте согласованность текста в PPT, PPTX и ODP с пошаговыми примерами кода на С++."
---

В следующем примере перечислены эти шаги:

1. Мы [создать коллекцию правил резервных шрифтов](/slides/ru/cpp/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrule/remove/) правило резервного шрифта и [AddFallBackFonts()](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrule/addfallbackfonts/) к другому правилу.
1. Передайте коллекцию правил в метод [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/).
1. С помощью метода [Presentation::Save()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) мы можем сохранить презентацию в том же формате или сохранить её в другом. После того как коллекция правил резервных шрифтов установлена в FontsManager, эти правила применяются при любых операциях с презентацией: сохранение, рендеринг, конвертация и т.д.
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

// Рендеринг миниатюры с использованием инициализированной коллекции правил и сохранение в PNG
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", ImageFormat::Png);
image->Dispose();

pres->Dispose();
```



{{% alert color="primary" %}} 
Узнайте подробнее о том, как [Преобразовать слайды PowerPoint в PNG в C++](/slides/ru/cpp/convert-powerpoint-to-png/).
{{% /alert %}}