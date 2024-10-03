---
title: Замена шрифтов
type: docs
weight: 60
url: /ru/cpp/font-replacement/
keywords: "Шрифт, замена шрифта, презентация PowerPoint, C++, CPP, Aspose.Slides для C++"
description: "Явно замените шрифты в PowerPoint на C++"
---

Если вы передумали использовать шрифт, вы можете заменить этот шрифт на другой. Все экземпляры старого шрифта будут заменены новым шрифтом.

Aspose.Slides позволяет заменить шрифт следующим образом:

1. Загрузите соответствующую презентацию.
2. Загрузите шрифт, который будет заменен.
3. Загрузите новый шрифт.
4. Замените шрифт.
5. Запишите измененную презентацию в файл PPTX.

Этот код на C++ демонстрирует замену шрифта:

``` cpp
// Загружает презентацию
auto presentation = System::MakeObject<Presentation>(u"Fonts.pptx");

// Загружает исходный шрифт, который будет заменен
auto sourceFont = System::MakeObject<FontData>(u"Arial");

// Загружает новый шрифт
auto destFont = System::MakeObject<FontData>(u"Times New Roman");

// Заменяет шрифты
presentation->get_FontsManager()->ReplaceFont(sourceFont, destFont);

// Сохраняет презентацию
presentation->Save(u"UpdatedFont_out.pptx", SaveFormat::Pptx);
```

{{% alert title="Примечание" color="warning" %}}

Чтобы установить правила, определяющие, что происходит при определенных условиях (например, если шрифт недоступен), смотрите [**Замена шрифтов**](/slides/ru/cpp/font-substitution/).

{{% /alert %}}