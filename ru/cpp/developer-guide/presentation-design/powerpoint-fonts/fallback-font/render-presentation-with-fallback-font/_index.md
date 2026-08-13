---
title: Рендеринг презентаций с резервными шрифтами на C++
linktitle: Рендеринг презентаций
type: docs
weight: 30
url: /ru/cpp/render-presentation-with-fallback-font/
keywords:
- резервный шрифт
- рендеринг PowerPoint
- рендеринг презентации
- рендеринг слайда
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Рендеринг презентаций с резервными шрифтами в Aspose.Slides для C++ – обеспечьте согласованность текста в PPT, PPTX и ODP с пошаговыми примерами кода на C++."
---
## **Обзор**

Aspose.Slides позволяет рендерить презентации, используя правила резервных шрифтов. В этой статье показано, как создать коллекцию правил резервных шрифтов, изменить её правила, удаляя или добавляя резервные шрифты, и назначить коллекцию с помощью метода `FontsManager::set_FontFallBackRulesCollection`.

После того как коллекция правил резервных шрифтов назначена менеджеру `FontsManager` презентации, правила применяются во время операций, таких как сохранение, рендеринг и конвертация презентации. Пример демонстрирует, как использовать настроенные правила при рендеринге миниатюры слайда и сохранении её в виде изображения PNG.

## **Рендеринг слайда с использованием правил резервных шрифтов**

В приведённом примере выполнены следующие шаги:

1. Мы [создаём коллекцию правил резервных шрифтов](/slides/ru/cpp/create-fallback-fonts-collection/).
2. Вызываем [Remove()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontfallbackrule/remove/) для удаления правила резервного шрифта и [AddFallBackFonts()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontfallbackrule/addfallbackfonts/) для добавления резервных шрифтов к другому правилу.
3. Передайте коллекцию правил в метод [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/).
4. С помощью метода [Presentation::Save()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/save/) можно сохранить презентацию в том же формате или в другом. После того как коллекция правил резервных шрифтов назначена FontsManager, эти правила применяются при любых операциях с презентацией: сохранение, рендеринг, конвертация и т.д.

``` cpp
#include <DOM/Fonts/FontFallBackRule.h>
#include <DOM/Fonts/FontFallBackRulesCollection.h>
#include <DOM/IFontsManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

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
// Assigning a prepared rules list for using
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// Rendering of thumbnail with using of initialized rules collection and saving to PNG
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", Aspose::Slides::ImageFormat::Png);
image->Dispose();

pres->Dispose();
```

{{% alert color="info" %}} 
Узнайте больше о том, как [Конвертировать слайды PowerPoint в PNG на C++](/slides/ru/cpp/convert-powerpoint-to-png/).
{{% /alert %}}