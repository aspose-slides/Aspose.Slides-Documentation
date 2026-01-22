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
description: "Быстро преобразуйте устаревшие презентации PPT в современные PPTX на Java с Aspose.Slides для Android — понятный учебник, бесплатные примеры кода, без зависимости от Microsoft Office."
---

## **Обзор**

Эта статья объясняет, как преобразовать презентацию PowerPoint в формате PPT в формат PPTX с использованием Java и онлайн‑приложения для конвертации PPT в PPTX. Рассмотрены следующие темы.

- Конвертировать PPT в PPTX на Java

## **Конвертация PPT в PPTX на Android**

Для примера кода на Java, преобразующего PPT в PPTX, см. раздел ниже, то есть [Преобразовать PPT в PPTX](#convert-ppt-to-pptx). Он просто загружает файл PPT и сохраняет его в формате PPTX. Указывая разные форматы сохранения, вы также можете сохранять файл PPT в различные другие форматы, такие как PDF, XPS, ODP, HTML и т.д., как обсуждается в этих статьях.

- [Преобразовать PPT в PDF на Android](/slides/ru/androidjava/convert-powerpoint-to-pdf/)
- [Преобразовать PPT в XPS на Android](/slides/ru/androidjava/convert-powerpoint-to-xps/)
- [Преобразовать PPT в HTML на Android](/slides/ru/androidjava/convert-powerpoint-to-html/)
- [Преобразовать PPT в ODP на Android](/slides/ru/androidjava/save-presentation/)
- [Преобразовать PPT в PNG на Android](/slides/ru/androidjava/convert-powerpoint-to-png/)

## **О конвертации PPT в PPTX**
Преобразуйте старый формат PPT в PPTX с помощью Aspose.Slides API. Если вам нужно преобразовать тысячи презентаций PPT в формат PPTX, лучшее решение — сделать это программно. С Aspose.Slides API это возможно выполнить всего в несколько строк кода. API обеспечивает полную совместимость при конвертации презентаций PPT в PPTX, и возможно:

- Преобразовывать сложные структуры мастеров, макетов и слайдов.
- Преобразовывать презентацию с диаграммами.
- Преобразовывать презентацию с групповыми фигурами, автофигурками (например, прямоугольники и эллипсы), фигурами с пользовательской геометрией.
- Преобразовывать презентацию, содержащую текстуры и стили заливки изображениями для автофигур.
- Преобразовывать презентацию с заполнителями, текстовыми кадрами и текстовыми контейнерами.

{{% alert color="primary" %}} 

Посмотрите на [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx) приложение:

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Это приложение построено на основе [**Aspose.Slides API**](https://products.aspose.com/slides/androidjava/), поэтому вы можете увидеть живой пример базовых возможностей конвертации PPT в PPTX. Aspose.Slides Conversion — это веб‑приложение, которое позволяет перетащить файл презентации в формате PPT и загрузить его конвертированным в PPTX.

Найдите другие живые примеры [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/).

{{% /alert %}} 

## **Конвертировать PPT в PPTX**
Aspose.Slides для Android через Java теперь позволяет разработчикам получить доступ к PPT с помощью экземпляра класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation), и преобразовать его в соответствующий формат [PPTX](https://docs.fileformat.com/presentation/pptx/). В настоящее время он поддерживает частичную конвертацию [PPT](https://docs.fileformat.com/presentation/ppt/) в PPTX. Для получения более подробной информации о поддерживаемых и неподдерживаемых функциях при конвертации PPT в PPTX, перейдите к этой документации [link](/slides/ru/androidjava/ppt-to-pptx-conversion/).

Aspose.Slides для Android через Java предоставляет класс [Presentation], представляющий файл презентации **PPTX**. Класс Presentation теперь также может получать доступ к **PPT** через Presentation при создании объекта. Следующий пример показывает, как преобразовать презентацию PPT в презентацию PPTX.
```java
// Создать объект Presentation, который представляет файл PPTX
Presentation pres = new Presentation("Aspose.ppt");
try {
// Сохранение презентации PPTX в формат PPTX
    pres.save("ConvertedAspose.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**Рисунок : Исходная презентация PPT**|

The above code snippet generated the following PPTX presentation after conversion

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Рисунок: Сгенерированная презентация PPTX после конвертации**|

## **Часто задаваемые вопросы**

**В чем разница между форматами PPT и PPTX?**

PPT — это более старый двоичный формат файла, используемый Microsoft PowerPoint, тогда как PPTX — более новый формат на основе XML, введённый в Microsoft Office 2007. Файлы PPTX обеспечивают лучшую производительность, меньший размер и улучшенное восстановление данных.

**Поддерживает ли Aspose.Slides пакетную конвертацию нескольких файлов PPT в PPTX?**

Да, вы можете использовать Aspose.Slides в цикле для программного конвертирования нескольких файлов PPT в PPTX, что делает его подходящим для пакетных сценариев конвертации.

**Сохранится ли содержимое и форматирование после конвертации?**

Aspose.Slides сохраняет высокую точность при конвертации презентаций. Макеты слайдов, анимации, фигуры, диаграммы и другие элементы дизайна сохраняются при конвертации PPT в PPTX.

**Можно ли конвертировать другие форматы, такие как PDF или HTML, из файлов PPT?**

Да, Aspose.Slides поддерживает конвертацию файлов PPT в [multiple formats](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveformat/), включая PDF, XPS, HTML, ODP и форматы изображений, такие как PNG и JPEG.

**Можно ли конвертировать PPT в PPTX без установленного Microsoft PowerPoint?**

Да, Aspose.Slides — это автономный API и не требует Microsoft PowerPoint или какого-либо стороннего программного обеспечения для выполнения конвертации.

**Существует ли онлайн‑инструмент для конвертации PPT в PPTX?**

Да, вы можете воспользоваться бесплатным веб‑приложением [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) для выполнения конвертации напрямую в браузере без написания кода.