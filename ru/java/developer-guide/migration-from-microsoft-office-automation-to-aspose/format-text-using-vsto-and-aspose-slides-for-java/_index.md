---
title: Форматирование текста с использованием VSTO и Aspose.Slides для Java
type: docs
weight: 30
url: /java/format-text-using-vsto-and-aspose-slides-for-java/
---

{{% alert color="primary" %}} 

Иногда необходимо программно форматировать текст на слайдах. В этой статье описывается, как прочитать образец презентации с текстом на первом слайде, используя [VSTO](/slides/java/format-text-using-vsto-and-aspose-slides-for-java/) и [Aspose.Slides для Java](/slides/java/format-text-using-vsto-and-aspose-slides-for-java/). Код форматирует текст в третьем текстовом поле на слайде так, чтобы он выглядел как текст в последнем текстовом поле.

{{% /alert %}} 
## **Форматирование текста**
Методы VSTO и Aspose.Slides выполняют следующие шаги:

1. Открыть исходную презентацию.
1. Получить доступ к первому слайду.
1. Получить доступ к третьему текстовому полю.
1. Изменить форматирование текста в третьем текстовом поле.
1. Сохранить презентацию на диск.

Скриншоты ниже показывают образец слайда до и после выполнения кода VSTO и Aspose.Slides для Java.

**Входная презентация** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_1.png)
### **Пример кода VSTO**
Код ниже показывает, как переформатировать текст на слайде с использованием VSTO.

**Текст, переформатированный с VSTO** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_2.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-FormatTextUsingVSTO-FormatTextUsingVSTO.cs" >}}


### **Пример Aspose.Slides для Java**
Чтобы отформатировать текст с помощью Aspose.Slides, добавьте шрифт перед форматированием текста.

**Выходная презентация, созданная с помощью Aspose.Slides** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_3.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FormatText-FormatText.java" >}}