---
title: Указание шрифтов-заполнителей для презентаций в Java
linktitle: Шрифт-заполнитель
type: docs
weight: 10
url: /ru/java/create-fallback-font/
keywords:
- шрифт-заполнитель
- правило заполнения
- применить шрифт
- заменить шрифт
- диапазон Unicode
- отсутствующий глиф
- правильный глиф
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: Освойте Aspose.Slides для Java, чтобы задавать шрифты-заполнители в файлах PPT, PPTX и ODP, обеспечивая одинаковое отображение текста на любом устройстве или ОС.
---
## **Обзор**

Aspose.Slides позволяет указывать шрифты‑заполнители для операций рендеринга и экспорта презентаций. Шрифты‑заполнители используются, когда основной шрифт не содержит глифов для определённых символов.

Поведение заполнителя настраивается с помощью правил заполнения. Каждое правило связывает диапазон Unicode с одним или несколькими шрифтами, которые могут содержать необходимые глифы. Вы можете определять правила для разных диапазонов символов, добавлять или удалять шрифты‑заполнители из существующих правил и организовывать несколько правил в коллекцию правил шрифтов‑заполнителей.

Правила заполнения являются параметрами рендеринга во время выполнения. Они не изменяют сам файл презентации и не сохраняются внутри файла PPTX.

## **Правила заполнения**

Aspose.Slides поддерживает интерфейс [IFontFallBackRule](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IFontFallBackRule) и класс [FontFallBackRule](https://reference.aspose.com/slides/ru/java/com.aspose.slides/FontFallBackRule), позволяющие задавать правила применения шрифта‑заполнителя. Класс [FontFallBackRule](https://reference.aspose.com/slides/ru/java/com.aspose.slides/FontFallBackRule) представляет связь между указанным диапазоном Unicode, используемым для поиска отсутствующих глифов, и списком шрифтов, которые могут содержать подходящие глифы:

```java
import com.aspose.slides.*;

long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Используя несколько способов, вы можете добавить список шрифтов:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Также можно [remove](https://reference.aspose.com/slides/ru/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) шрифт‑заполнитель или [addFallBackFonts](https://reference.aspose.com/slides/ru/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) в существующий объект [FontFallBackRule](https://reference.aspose.com/slides/ru/java/com.aspose.slides/FontFallBackRule).

[FontFallBackRulesCollection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/FontFallBackRulesCollection) можно использовать для организации списка объектов [FontFallBackRule](https://reference.aspose.com/slides/ru/java/com.aspose.slides/FontFallBackRule), когда необходимо задать правила замены шрифтов‑заполнителей для нескольких диапазонов Unicode.

{{% alert color="info" title="See also" %}} 
- [Create Fallback Fonts Collection](/slides/ru/java/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

### В чём разница между шрифтом‑заполнителем, заменой шрифта и встраиванием шрифта?

Шрифт‑заполнитель используется только для символов, отсутствующих в основном шрифте. [Font substitution](/slides/ru/java/font-substitution/) заменяет весь указанный шрифт другим. [Font embedding](/slides/ru/java/embedded-font/) упаковывает шрифты в выходной файл, чтобы получатели могли просматривать текст в задуманном виде.

### Применяются ли шрифты‑заполнители при экспорте в PDF, PNG или SVG, или только при рендеринге на экране?

Да. Заполнитель влияет на все [rendering and export operations](/slides/ru/java/convert-presentation/), где необходимо отрисовать символы, отсутствующие в исходном шрифте.

### Изменяет ли настройка заполнителя сам файл презентации и сохранится ли она при последующих открытиях?

Нет. Правила заполнения являются параметрами рендеринга во время выполнения в вашем коде; они не сохраняются внутри .pptx и не отображаются в PowerPoint.

### Влияют ли операционная система (Windows/Linux/macOS) и набор каталогов шрифтов на выбор заполнителя?

Да. Движок ищет шрифты в доступных системных папках и любых [additional paths](/slides/ru/java/custom-font/) , которые вы указываете. Если шрифт физически недоступен, правило, ссылающееся на него, не может сработать.

### Работает ли заполнитель для WordArt, SmartArt и диаграмм?

Да. Когда эти объекты содержат текст, применяется тот же механизм подстановки глифов для рендеринга недостающих символов.