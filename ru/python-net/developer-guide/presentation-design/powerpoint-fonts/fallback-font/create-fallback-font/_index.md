---
title: Укажите резервные шрифты для презентаций на Python
linktitle: Резервный шрифт
type: docs
weight: 10
url: /ru/python-net/create-fallback-font/
keywords:
- резервный шрифт
- правило резервного шрифта
- применение шрифта
- замена шрифта
- диапазон Unicode
- пропущенный глиф
- правильный глиф
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Освойте Aspose.Slides для Python через .NET, чтобы задавать резервные шрифты в файлах PPT, PPTX и ODP, обеспечивая согласованное отображение текста на любом устройстве или ОС."
---

## **Укажите резервные шрифты**

Aspose.Slides поддерживает класс [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) для указания правил применения резервного шрифта. Класс [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) представляет связь между указанным диапазоном Unicode, используемым для поиска недостающих глифов, и списком шрифтов, которые могут содержать нужные глифы:
```py
startUnicodeIndex = 0x0B80
endUnicodeIndex = 0x0BFF

firstRule = slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya")
secondRule = slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

#Используя различные способы, вы можете добавить список шрифтов:
fontNames =  ["Segoe UI Emoji, Segoe UI Symbol", "Arial" ]

thirdRule = slides.FontFallBackRule(0x1F300, 0x1F64F, fontNames)
```




Также можно [remove](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/remove/) резервный шрифт или [add_fall_back_fonts](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/add_fall_back_fonts/) в существующий объект [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/).

[FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrulescollection/) может быть использован для организации списка объектов [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/), когда необходимо указать правила замены резервных шрифтов для нескольких диапазонов Unicode.

{{% alert color="primary" title="See also" %}} 
- [Создать коллекцию резервных шрифтов](/slides/ru/python-net/create-fallback-fonts-collection/)
{{% /alert %}}

## **Вопросы и ответы**

**В чём разница между резервным шрифтом, заменой шрифта и встраиванием шрифта?**

Резервный шрифт используется только для символов, отсутствующих в основном шрифте. [Замена шрифта](/slides/ru/python-net/font-substitution/) заменяет весь указанный шрифт другим шрифтом. [Встраивание шрифта](/slides/ru/python-net/embedded-font/) упаковывает шрифты внутри выходного файла, чтобы получатели могли просматривать текст как задумано.

**Применяются ли резервные шрифты при экспорте, например, в PDF, PNG или SVG, или только при отображении на экране?**

Да. Резервные шрифты влияют на все операции [rendering and export operations](/slides/ru/python-net/convert-presentation/), где необходимо отрисовать символы, но они отсутствуют в исходном шрифте.

**Изменяет ли настройка резервных шрифтов сам файл презентации, и сохранится ли параметр при последующих открываниях?**

Нет. Правила резервных шрифтов — это настройки рендеринга во время выполнения в вашем коде; они не сохраняются внутри .pptx и не отображаются в PowerPoint.

**Влияют ли операционная система (Windows/Linux/macOS) и набор каталогов шрифтов на выбор резервного шрифта?**

Да. Движок ищет шрифты в доступных системных папках и любых дополнительных путях, которые вы указываете. Если шрифт физически недоступен, правило, ссылающееся на него, не может сработать.

**Работают ли резервные шрифты для WordArt, SmartArt и диаграмм?**

Да. Когда эти объекты содержат текст, применяется тот же механизм подстановки глифов для отображения отсутствующих символов.