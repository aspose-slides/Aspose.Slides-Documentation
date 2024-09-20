---
title: Форматирование текста с помощью VSTO и Aspose.Slides для Android через Java
type: docs
weight: 30
url: /androidjava/format-text-using-vsto-and-aspose-slides-for-java/
---

{{% alert color="primary" %}} 

Иногда необходимо программно форматировать текст на слайдах. Эта статья показывает, как прочитать образец презентации с текстом на первом слайде, используя [VSTO](/slides/androidjava/format-text-using-vsto-and-aspose-slides-for-java/) и [Aspose.Slides для Android через Java](/slides/androidjava/format-text-using-vsto-and-aspose-slides-for-java/). Код форматирует текст в третьем текстовом поле на слайде так, чтобы он выглядел как текст в последнем текстовом поле.

{{% /alert %}} 
## **Форматирование текста**
Методы VSTO и Aspose.Slides выполняют следующие шаги:

1. Открыть исходную презентацию.
1. Получить доступ к первому слайду.
1. Получить доступ к третьему текстовому полю.
1. Изменить форматирование текста в третьем текстовом поле.
1. Сохранить презентацию на диск.

Скриншоты ниже показывают образец слайда до и после выполнения кода VSTO и Aspose.Slides для Android через Java.

**Исходная презентация** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_1.png)
### **Пример кода VSTO**
Код ниже показывает, как переформатировать текст на слайде, используя VSTO.

**Текст, переформатированный с использованием VSTO** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_2.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-FormatTextUsingVSTO-FormatTextUsingVSTO.cs" >}}


### **Пример Aspose.Slides для Android через Java**
Чтобы отформатировать текст с помощью Aspose.Slides, добавьте шрифт перед форматированием текста.

**Выходная презентация, созданная с помощью Aspose.Slides** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_3.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FormatText-FormatText.java" >}}