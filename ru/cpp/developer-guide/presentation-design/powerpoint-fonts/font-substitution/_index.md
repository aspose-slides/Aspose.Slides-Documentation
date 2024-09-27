---
title: Замена шрифтов
type: docs
weight: 70
url: /ru/cpp/font-substitution/
keywords: "Шрифт, заменяющий шрифт, презентация PowerPoint, C++, CPP, Aspose.Slides для C++"
description: "Замена шрифта в PowerPoint на C++"
---

Aspose.Slides позволяет устанавливать правила для шрифтов, которые определяют, что должно быть сделано в определенных условиях (например, когда шрифт недоступен) следующим образом:

1. Загрузите соответствующую презентацию.
2. Загрузите шрифт, который будет заменен.
3. Загрузите новый шрифт.
4. Добавьте правило для замены.
5. Добавьте правило в коллекцию правил замены шрифтов презентации.
6. Генерируйте изображение слайда, чтобы наблюдать эффект.

Этот код на C++ демонстрирует процесс замены шрифтов:

```c++
// Путь к директории документов.
const String outPath = u"../out/RuleBasedFontsReplacement_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// Загружает презентацию
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// Определяет шрифт, который будет заменен, и новый шрифт
SharedPtr<IFontData> sourceFont = MakeObject<FontData>(u"SomeRareFont");
SharedPtr<IFontData> destFont = MakeObject<FontData>(u"Arial");
	
// Добавляет правило шрифта для замены шрифта
SharedPtr<FontSubstRule> fontSubstRule = MakeObject<FontSubstRule>(sourceFont, destFont, FontSubstCondition::WhenInaccessible);

// Добавляет правило в коллекцию правил замены шрифтов
SharedPtr<FontSubstRuleCollection> fontSubstRuleCollection = MakeObject<FontSubstRuleCollection>();
fontSubstRuleCollection->Add(fontSubstRule);

// Добавляет коллекцию правил шрифтов в список правил
pres->get_FontsManager()->set_FontSubstRuleList ( fontSubstRuleCollection);


// Сохраняет PPTX на диск
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert title="ПРИМЕЧАНИЕ"  color="warning"   %}} 

Вам может быть интересно посмотреть [**Замена шрифта**](/slides/ru/cpp/font-replacement/). 

{{% /alert %}}