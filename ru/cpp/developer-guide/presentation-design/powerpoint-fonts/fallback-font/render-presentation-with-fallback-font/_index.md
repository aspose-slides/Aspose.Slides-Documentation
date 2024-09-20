---
title: Отрисовка презентации с резервным шрифтом
type: docs
weight: 30
url: /cpp/render-presentation-with-fallback-font/
---

Следующий пример включает в себя эти шаги:

1. Мы [создаем коллекцию правил резервных шрифтов](/slides/cpp/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule#aaf12e563d822f6e05e27732a837bcf33) правило резервного шрифта и [AddFallBackFonts()](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule#a030268631ae616b775bdb6df8accf42c) к другому правилу.
1. Установить коллекцию правил в свойство [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/cpp/class/aspose.slides.fonts_manager#a375fc71abd64891a39673751d127d924).
1. С помощью метода [Presentation::Save()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) мы можем сохранить презентацию в том же формате или сохранить её в другом. После установки коллекции правил резервных шрифтов в FontsManager, эти правила применяются во время любых операций с презентацией: сохранение, отрисовка, конвертация и т. д.

``` cpp
// Создаем новый экземпляр коллекции правил
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// Создаем несколько правил
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

// Мы также можем удалить любые существующие правила из списка
if (rulesList->get_Count() > 0)
{
	rulesList->Remove(rulesList->idx_get(0));
}

auto pres = System::MakeObject<Presentation>(u"input.pptx");
// Назначаем подготовленный список правил для использования
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// Отрисовка миниатюры с использованием инициализированной коллекции правил и сохранение в PNG
pres->get_Slides()->idx_get(0)->GetImage(1.f, 1.f)->Save(u"Slide_0.png", ImageFormat::Png);
```

{{% alert color="primary" %}} 
Узнайте больше о [Сохранении и конвертации в презентации](/slides/cpp/creating-saving-and-converting-a-presentation/).
{{% /alert %}}