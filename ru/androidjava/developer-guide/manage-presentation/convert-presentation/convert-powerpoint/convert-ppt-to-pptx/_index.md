---
title: Конвертировать PPT в PPTX на Android
linktitle: PPT в PPTX
type: docs
weight: 20
url: /ru/androidjava/convert-ppt-to-pptx/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать слайд
- конвертировать PPT
- PPT в PPTX
- сохранить PPT как PPTX
- экспортировать PPT в PPTX
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Быстро конвертировать устаревшие PPT-презентации в современный PPTX на Java с помощью Aspose.Slides для Android — понятный учебник, бесплатные примеры кода, без зависимости от Microsoft Office."
---

## **Обзор**

В этой статье объясняется, как конвертировать презентацию PowerPoint в формате PPT в формат PPTX с использованием Java и онлайн‑приложения для конвертации PPT в PPTX. Рассматривается следующая тема.

- Конвертировать PPT в PPTX на Java

## **Конвертировать PPT в PPTX на Android**

Для примера кода на Java, который конвертирует PPT в PPTX, см. раздел ниже — [Конвертировать PPT в PPTX](#convert-ppt-to-pptx). Он просто загружает файл PPT и сохраняет его в формате PPTX. Указывая разные форматы сохранения, вы также можете сохранять файл PPT в многие другие форматы, такие как PDF, XPS, ODP, HTML и т.д., как описано в следующих материалах.

- [Java Конвертировать PPT в PDF](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-pdf/)
- [Java Конвертировать PPT в XPS](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-xps/)
- [Java Конвертировать PPT в HTML](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-html/)
- [Java Конвертировать PPT в ODP](https://docs.aspose.com/slides/androidjava/save-presentation/)
- [Java Конвертировать PPT в Image](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-png/)

## **О конвертации PPT в PPTX**

Конвертируйте старый формат PPT в PPTX с помощью Aspose.Slides API. Если вам требуется конвертировать тысячи презентаций PPT в формат PPTX, лучшее решение — сделать это программно. С Aspose.Slides API это возможно выполнить всего в несколько строк кода. API обеспечивает полную совместимость при конвертации презентаций PPT в PPTX, и позволяет:

- Конвертировать сложные структуры мастер‑слайдов, макетов и слайдов.
- Конвертировать презентацию с диаграммами.
- Конвертировать презентацию с группой фигур, автогенерируемыми фигурами (например, прямоугольниками и эллипсами), фигурами с пользовательской геометрией.
- Конвертировать презентацию с текстурами и стилями заполнения изображениями для автогенерируемых фигур.
- Конвертировать презентацию с заполнителями, текстовыми рамками и текстовыми контейнерами.

{{% alert color="primary" %}} 

Ознакомьтесь с [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx) приложением:

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Это приложение построено на основе [**Aspose.Slides API**](https://products.aspose.com/slides/androidjava/), поэтому вы можете увидеть живой пример базовых возможностей конвертации PPT в PPTX. Aspose.Slides Conversion — веб‑приложение, позволяющее загрузить файл презентации в формате PPT и скачать его в формате PPTX.

Найдите другие живые примеры [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) .

{{% /alert %}} 

## **Конвертировать PPT в PPTX**
Aspose.Slides for Android через Java теперь позволяет разработчикам получать доступ к PPT с помощью экземпляра класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) и конвертировать его в соответствующий формат [PPTX](https://docs.fileformat.com/presentation/pptx/). В настоящее время поддерживается частичная конвертация [PPT ](https://docs.fileformat.com/presentation/ppt/)в PPTX. Для получения более подробной информации о поддерживаемых и неподдерживаемых функциях в конвертации PPT в PPTX перейдите к этой документации [link](/slides/ru/androidjava/ppt-to-pptx-conversion/).

Aspose.Slides for Android через Java предлагает класс [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation), представляющий файл презентации **PPTX**. Класс Presentation теперь также может получить доступ к **PPT** через Presentation при создании объекта. Ниже показан пример, как конвертировать презентацию PPT в презентацию PPTX.
```java
// Создать объект Presentation, представляющий файл PPTX
Presentation pres = new Presentation("Aspose.ppt");
try {
// Сохранение презентации PPTX в формате PPTX
    pres.save("ConvertedAspose.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**Рисунок : Исходная PPT‑презентация**|

В приведённом фрагменте кода после конвертации генерируется следующая презентация PPTX.

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Рисунок: Сгенерированная PPTX‑презентация после конвертации**|

## **FAQ**

**В чём разница между форматами PPT и PPTX?**

PPT — старый бинарный формат файлов, используемый Microsoft PowerPoint, тогда как PPTX — новый формат на основе XML, введённый в Microsoft Office 2007. Файлы PPTX обеспечивают лучшую производительность, меньший размер и улучшенное восстановление данных.

**Поддерживает ли Aspose.Slides пакетную конвертацию нескольких файлов PPT в PPTX?**

Да, вы можете использовать Aspose.Slides в цикле для программного конвертирования нескольких файлов PPT в PPTX, что подходит для пакетных сценариев.

**Сохраняются ли содержание и форматирование после конвертации?**

Aspose.Slides сохраняет высокую точность при конвертации презентаций. Макеты слайдов, анимации, фигуры, диаграммы и другие элементы дизайна сохраняются при конвертации PPT в PPTX.

**Могу ли я конвертировать другие форматы, такие как PDF или HTML, из файлов PPT?**

Да, Aspose.Slides поддерживает конвертацию файлов PPT в [множество форматов](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveformat/), включая PDF, XPS, HTML, ODP и форматы изображений, такие как PNG и JPEG.

**Можно ли конвертировать PPT в PPTX без установленного Microsoft PowerPoint?**

Да, Aspose.Slides — самостоятельный API и не требует Microsoft PowerPoint или какого‑либо стороннего программного обеспечения для выполнения конвертации.

**Существует ли онлайн‑инструмент для конвертации PPT в PPTX?**

Да, вы можете воспользоваться бесплатным веб‑приложением [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx), которое позволяет выполнить конвертацию непосредственно в браузере без написания кода.