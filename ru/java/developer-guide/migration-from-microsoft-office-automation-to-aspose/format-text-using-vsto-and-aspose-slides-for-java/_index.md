---
title: Форматирование текста с помощью VSTO и Aspose.Slides для Java
linktitle: Форматирование текста
type: docs
weight: 30
url: /ru/java/format-text-using-vsto-and-aspose-slides-for-java/
keywords:
- форматировать текст
- миграция
- VSTO
- автоматизация Office
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Перейдите с автоматизации Microsoft Office на Aspose.Slides для Java и форматируйте текст в презентациях PowerPoint (PPT, PPTX) с точным контролем."
---
{{% alert color="info" %}} 
Иногда требуется программно форматировать текст на слайдах. В этой статье показано, как считать пример презентации с некоторым текстом на первом слайде, используя либо [VSTO](/slides/ru/java/format-text-using-vsto-and-aspose-slides-for-java/) и [Aspose.Slides for Java](/slides/ru/java/format-text-using-vsto-and-aspose-slides-for-java/). Код форматирует текст в третьем текстовом поле на слайде, чтобы он выглядел как текст в последнем текстовом поле.
{{% /alert %}} 
## **Formatting Text**
Методы VSTO и Aspose.Slides выполняют следующие шаги:

1. Откройте исходную презентацию.
1. Получите первый слайд.
1. Получите третье текстовое поле.
1. Измените форматирование текста в третьем текстовом поле.
1. Сохраните презентацию на диск.

Скриншоты ниже показывают пример слайда до и после выполнения кода VSTO и Aspose.Slides for Java.

**Исходная презентация** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_1.png)
### **Пример кода VSTO**
Код ниже показывает, как переоформить текст на слайде с помощью VSTO.

**Текст, переоформленный с помощью VSTO** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_2.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-FormatTextUsingVSTO-FormatTextUsingVSTO.cs" >}}

### **Пример Aspose.Slides for Java**
Чтобы отформатировать текст с помощью Aspose.Slides, добавьте шрифт перед форматированием текста.

**Результирующая презентация, созданная с помощью Aspose.Slides** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_3.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FormatText-FormatText.java" >}}