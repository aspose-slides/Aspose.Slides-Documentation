---
title: Создать резервный шрифт
type: docs
weight: 10
url: /ru/net/create-fallback-font/
keywords: "Шрифты, резервный шрифт, презентация PowerPoint C#, Csharp, Aspose.Slides for .NET"
description: "Резервный шрифт в PowerPoint в C# или .NET"
---

## **Правила резервных шрифтов**

Aspose.Slides поддерживает интерфейс [IFontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/iFontFallBackRule) и класс [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) для указания правил применения резервного шрифта. Класс [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) представляет связь между указанным диапазоном Unicode, используемым для поиска отсутствующих глифов, и списком шрифтов, которые могут содержать нужные глифы:
```c#
uint startUnicodeIndex = 0x0B80;
uint endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Используя различные способы, вы можете добавить список шрифтов:
string[] fontNames = new string[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```


Также можно [Remove()](https://reference.aspose.com/slides/net/aspose.slides/ifontfallbackrule/methods/remove) удалить резервный шрифт или [AddFallBackFonts()](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) добавить резервные шрифты в существующий объект [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule).

[FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrulescollection)[ ](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrulescollection) можно использовать для организации списка объектов [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule), когда необходимо задать правила замены резервных шрифтов для нескольких диапазонов Unicode.

{{% alert color="primary" title="See also" %}} 
- [Создать коллекцию резервных шрифтов](/slides/ru/net/create-fallback-fonts-collection/)
{{% /alert %}}

## **Часто задаваемые вопросы**

**В чем разница между резервным шрифтом, заменой шрифта и внедрением шрифта?**

Резервный шрифт используется только для символов, отсутствующих в основном шрифте. [Замена шрифта](/slides/ru/net/font-substitution/) заменяет весь указанный шрифт другим шрифтом. [Внедрение шрифта](/slides/ru/net/embedded-font/) упаковывает шрифты в выходной файл, чтобы получатели могли увидеть текст как задумано.

**Применяются ли резервные шрифты при экспорте, например в PDF, PNG или SVG, или только при рендеринге на экране?**

Да. Резервный шрифт влияет на все [операции рендеринга и экспорта](/slides/ru/net/convert-presentation/), где необходимо отрисовать символы, но они отсутствуют в исходном шрифте.

**Изменяется ли сам файл презентации при настройке резервных шрифтов, и сохраняются ли эти настройки при последующих открытиях?**

Нет. Правила резервных шрифтов являются настройками рендеринга во время выполнения в вашем коде; они не сохраняются внутри .pptx и не будут отображаться в PowerPoint.

**Влияют ли операционная система (Windows/Linux/macOS) и набор каталогов шрифтов на выбор резервного шрифта?**

Да. Движок ищет шрифты в доступных системных папках и любых [дополнительные пути](/slides/ru/net/custom-font/), которые вы указываете. Если шрифт физически недоступен, правило, ссылающееся на него, не может сработать.

**Работают ли резервные шрифты для WordArt, SmartArt и диаграмм?**

Да. Когда эти объекты содержат текст, применяется тот же механизм замены глифов для отображения отсутствующих символов.