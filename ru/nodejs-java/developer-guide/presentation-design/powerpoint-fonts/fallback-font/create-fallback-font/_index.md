---
title: Создать резервный шрифт
type: docs
weight: 10
url: /ru/nodejs-java/create-fallback-font/
---

## **Правила резервного шрифта**

Aspose.Slides поддерживает класс [FontFallBackRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule) и класс [FontFallBackRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule) для указания правил применения резервного шрифта. Класс [FontFallBackRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule) представляет связь между указанным диапазоном Unicode, используемым для поиска отсутствующих глифов, и списком шрифтов, которые могут содержать необходимые глифы:
```javascript
var startUnicodeIndex = 0xb80;
var endUnicodeIndex = 0xbff;
var firstRule = new aspose.slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
var secondRule = new aspose.slides.FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic");
// Используя несколько способов, вы можете добавить список шрифтов:
var fontNames = java.newArray("java.lang.String", ["Segoe UI Emoji, Segoe UI Symbol", "Arial"]));
var thirdRule = new aspose.slides.FontFallBackRule(0x1f300, 0x1f64f, fontNames);
```


Также можно [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) резервный шрифт или [addFallBackFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) в существующий объект [FontFallBackRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule).

[FontFallBackRulesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRulesCollection) можно использовать для организации списка объектов [FontFallBackRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule), когда требуется указать правила замены резервных шрифтов для нескольких диапазонов Unicode.

{{% alert color="primary" title="См. также" %}} 
- [Создать коллекцию резервных шрифтов](/slides/ru/nodejs-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **Часто задаваемые вопросы**

**В чем разница между резервным шрифтом, заменой шрифта и встраиванием шрифта?**

Резервный шрифт используется только для символов, отсутствующих в основном шрифте. [Font substitution](/slides/ru/nodejs-java/font-substitution/) заменяет весь указанный шрифт другим шрифтом. [Font embedding](/slides/ru/nodejs-java/embedded-font/) упаковывает шрифты внутрь выходного файла, чтобы получатели могли видеть текст как задумано.

**Применяются ли резервные шрифты при экспорте, например PDF, PNG или SVG, или только при отображении на экране?**

Да. Резервный шрифт влияет на все [операции рендеринга и экспорта](/slides/ru/nodejs-java/convert-presentation/), где необходимо отрисовать символы, которых нет в исходном шрифте.

**Изменяет ли настройка резервного шрифта сам файл презентации и будет ли она сохраняться при последующих открытиях?**

Нет. Правила резервного шрифта являются настройками рендеринга во время выполнения в вашем коде; они не сохраняются в файле .pptx и не появятся в PowerPoint.

**Влияют ли операционная система (Windows/Linux/macOS) и набор каталогов шрифтов на выбор резервного шрифта?**

Да. Движок ищет шрифты в доступных системных папках и любых [дополнительных путях](/slides/ru/nodejs-java/custom-font/), которые вы указываете. Если шрифт физически недоступен, правило, ссылающееся на него, не может быть применено.

**Работает ли резервный шрифт для WordArt, SmartArt и диаграмм?**

Да. Когда эти объекты содержат текст, применяется тот же механизм замены глифов для отрисовки отсутствующих символов.