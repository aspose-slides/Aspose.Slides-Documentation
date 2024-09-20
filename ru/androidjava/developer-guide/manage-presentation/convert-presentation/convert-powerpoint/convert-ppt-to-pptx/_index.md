---
title: Конвертировать PPT в PPTX на Java
linktitle: Конвертировать PPT в PPTX
type: docs
weight: 20
url: /androidjava/convert-ppt-to-pptx/
keywords: "Java Конвертировать PPT в PPTX, PowerPoint PPT в PPTX на Java"
description: "Конвертировать PowerPoint PPT в PPTX на Java."
---

## **Обзор**

В этой статье объясняется, как конвертировать презентацию PowerPoint в формате PPT в формат PPTX с использованием Java и с помощью онлайн-приложения для конверсии PPT в PPTX. Рассматриваемая тема:

- Конвертация PPT в PPTX на Java

## **Java Конвертировать PPT в PPTX**

Для примера кода на Java для конвертации PPT в PPTX, пожалуйста, смотрите раздел ниже, т.е. [Конвертировать PPT в PPTX](#convert-ppt-to-pptx). Он загружает файл PPT и сохраняет его в формате PPTX. Указав различные форматы сохранения, вы также можете сохранить файл PPT в многие другие форматы, такие как PDF, XPS, ODP, HTML и т.д., как обсуждается в этих статьях.

- [Java Конвертировать PPT в PDF](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-pdf/)
- [Java Конвертировать PPT в XPS](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-xps/)
- [Java Конвертировать PPT в HTML](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-html/)
- [Java Конвертировать PPT в ODP](https://docs.aspose.com/slides/androidjava/save-presentation/)
- [Java Конвертировать PPT в Изображение](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-png/)

## **О Конверсии PPT в PPTX**
Конвертируйте старый формат PPT в PPTX с помощью API Aspose.Slides. Если вам нужно конвертировать тысячи презентаций PPT в формат PPTX, лучшее решение — сделать это программным образом. С API Aspose.Slides это возможно всего за несколько строк кода. API поддерживает полную совместимость для конвертации презентации PPT в PPTX и позволяет:

- Конвертировать сложные структуры мастер-слайдов, макетов и слайдов.
- Конвертировать презентацию с диаграммами.
- Конвертировать презентацию с групповыми фигурами, автофигурами (такими как прямоугольники и эллипсы), фигурами с пользовательской геометрией.
- Конвертировать презентацию с текстурами и стилями заливки изображениями для автофигур.
- Конвертировать презентацию, имея заполнители, текстовые рамки и текстовые блоки.

{{% alert color="primary" %}} 

Посмотрите на [**Конверсию PPT в PPTX Aspose.Slides**](https://products.aspose.app/slides/conversion/ppt-to-pptx):

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Это приложение построено на основе [**API Aspose.Slides**](https://products.aspose.com/slides/androidjava/), поэтому вы можете увидеть активный пример основных возможностей конверсии PPT в PPTX. Конверсия Aspose.Slides — это веб-приложение, которое позволяет загрузить файл презентации в формате PPT и скачать его в формате PPTX.

Найдите другие живые [**Примеры Конверсии Aspose.Slides**](https://products.aspose.app/slides/conversion/).
{{% /alert %}} 

## **Конвертировать PPT в PPTX**
Aspose.Slides для Android через Java теперь облегчает разработчикам доступ к PPT, используя экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) и конвертируя его в соответствующий формат [PPTX](https://docs.fileformat.com/presentation/pptx/). В настоящее время он поддерживает частичную конвертацию [PPT](https://docs.fileformat.com/presentation/ppt/) в PPTX. Для получения дополнительных сведений о поддерживаемых и неподдерживаемых функциях при конвертации PPT в PPTX, пожалуйста, перейдите по этой документации [ссылке](/slides/androidjava/ppt-to-pptx-conversion/).

Aspose.Slides для Android через Java предлагает класс [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation), который представляет собой файл презентации **PPTX**. Класс Presentation теперь также может получить доступ к **PPT** при инициализации объекта. Следующий пример показывает, как конвертировать презентацию PPT в презентацию PPTX.

```java
// Создание объекта Presentation, представляющего файл PPTX
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
|**Рисунок: Исходная презентация PPT**|

Приведенный выше фрагмент кода сгенерировал следующую презентацию PPTX после конвертации

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Рисунок: Сгенерированная презентация PPTX после конвертации**|