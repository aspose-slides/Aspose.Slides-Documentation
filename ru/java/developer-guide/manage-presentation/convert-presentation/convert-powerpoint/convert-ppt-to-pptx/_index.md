---
title: Конвертация PPT в PPTX на Java
linktitle: Конвертация PPT в PPTX
type: docs
weight: 20
url: /ru/java/convert-ppt-to-pptx/
keywords: "Java Конвертация PPT в PPTX, PowerPoint PPT в PPTX на Java"
description: "Конвертация PowerPoint PPT в PPTX на Java."
---

## **Обзор**

В этой статье объясняется, как конвертировать презентацию PowerPoint в формате PPT в формате PPTX с помощью Java и с помощью онлайн-приложения для конвертации PPT в PPTX. Рассматриваемая тема:

- Конвертация PPT в PPTX на Java

## **Java Конвертация PPT в PPTX**

Для примера кода на Java для конвертации PPT в PPTX, пожалуйста, смотрите раздел ниже, т.е. [Конвертация PPT в PPTX](#convert-ppt-to-pptx). Он просто загружает файл PPT и сохраняет в формате PPTX. Указав различные форматы сохранения, вы также можете сохранить файл PPT в многие другие форматы, такие как PDF, XPS, ODP, HTML и др., как обсуждается в этих статьях.

- [Java Конвертация PPT в PDF](https://docs.aspose.com/slides/java/convert-powerpoint-to-pdf/)
- [Java Конвертация PPT в XPS](https://docs.aspose.com/slides/java/convert-powerpoint-to-xps/)
- [Java Конвертация PPT в HTML](https://docs.aspose.com/slides/java/convert-powerpoint-to-html/)
- [Java Конвертация PPT в ODP](https://docs.aspose.com/slides/java/save-presentation/)
- [Java Конвертация PPT в Изображение](https://docs.aspose.com/slides/java/convert-powerpoint-to-png/)

## **О конвертации PPT в PPTX**
Преобразуйте старый формат PPT в PPTX с помощью API Aspose.Slides. Если вам нужно конвертировать тысячи презентаций PPT в формат PPTX, лучшее решение - сделать это программно. С API Aspose.Slides это возможно всего за несколько строк кода. API поддерживает полную совместимость для конвертации презентаций PPT в PPTX, и это возможно:

- Конвертировать сложные структуры мастер-слайдов, макетов и слайдов.
- Конвертировать презентации с графиками.
- Конвертировать презентации с группами фигур, автозакрепленными фигурами (такими как прямоугольники и эллипсы), фигурами с пользовательской геометрией.
- Конвертировать презентации, имеющие текстуры и стили заполнения картинок для автозакрепленных фигур.
- Конвертировать презентации с заполнителями, текстовыми рамками и текстовыми контейнерами.

{{% alert color="primary" %}}

Обратите внимание на [**Aspose.Slides Конвертация PPT в PPTX**](https://products.aspose.app/slides/conversion/ppt-to-pptx):

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Это приложение основано на [**API Aspose.Slides**](https://products.aspose.com/slides/java/), поэтому вы можете увидеть живой пример основных возможностей конвертации PPT в PPTX. Aspose.Slides Conversion - это веб-приложение, которое позволяет загружать файл презентации в формате PPT и загружать его в формате PPTX.

Найдите другие живые [**Aspose.Slides Конвертация**](https://products.aspose.app/slides/conversion/) примеры.
{{% /alert %}}

## **Конвертация PPT в PPTX**
Aspose.Slides для Java теперь облегчает разработчикам доступ к PPT с помощью экземпляра класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) и конвертацию его в соответствующий формат [PPTX](https://docs.fileformat.com/presentation/pptx/). В настоящее время он поддерживает частичную конвертацию [PPT](https://docs.fileformat.com/presentation/ppt/) в PPTX. Для получения дополнительных сведений о поддерживаемых и неподдерживаемых функциях в конвертации PPT в PPTX, пожалуйста, перейдите по этой документации [ссылки](/slides/ru/java/ppt-to-pptx-conversion/).

Aspose.Slides для Java предлагает класс [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation), который представляет файл презентации **PPTX**. Класс Presentation теперь также может получать доступ к **PPT** через Presentation при создании объекта. Следующий пример показывает, как конвертировать презентацию PPT в презентацию PPTX.

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

Вышеуказанный фрагмент кода сгенерировал следующую презентацию PPTX после преобразования

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Рисунок: Сгенерированная презентация PPTX после преобразования**|