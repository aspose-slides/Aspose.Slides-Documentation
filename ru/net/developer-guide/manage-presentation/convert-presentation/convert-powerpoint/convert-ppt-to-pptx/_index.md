---
title: Конвертация PPT в PPTX на C#
linktitle: Конвертация PPT в PPTX
type: docs
weight: 20
url: /net/convert-ppt-to-pptx/
keywords: "C# Конвертация PPT в PPTX, Конвертация презентации PowerPoint, PPT в PPTX, C#, Csharp, .NET, Aspose.Slides"
description: "Конвертация презентации PowerPoint из PPT в PPTX на C# или .NET"
---

## **Обзор**

В этой статье объясняется, как конвертировать презентацию PowerPoint в формате PPT в формат PPTX, используя C# и онлайн-приложение для конвертации PPT в PPTX. Рассматривается следующая тема.

- [Конвертация PPT в PPTX на C#](#convert-ppt-to-pptx)

## **C# Конвертация PPT в PPTX**

Для получения примера кода на C# для конвертации PPT в PPTX смотрите раздел ниже, то есть [Конвертация PPT в PPTX](#convert-ppt-to-pptx). Он просто загружает файл PPT и сохраняет его в формате PPTX. Указав разные форматы сохранения, вы также можете сохранить файл PPT в другие форматы, такие как PDF, XPS, ODP, HTML и т. д., как обсуждается в этих статьях.

- [C# Конвертация PPT в PDF](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/)
- [C# Конвертация PPT в XPS](https://docs.aspose.com/slides/net/convert-powerpoint-to-xps/)
- [C# Конвертация PPT в HTML](https://docs.aspose.com/slides/net/convert-powerpoint-to-html/)
- [C# Конвертация PPT в ODP](https://docs.aspose.com/slides/net/save-presentation/)
- [C# Конвертация PPT в изображение](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)

## **О конвертации PPT в PPTX**
Конвертируйте старый формат PPT в PPTX с помощью API Aspose.Slides. Если вам нужно конвертировать тысячи презентаций PPT в формат PPTX, лучшим решением будет сделать это программно. С API Aspose.Slides это возможно всего в несколько строк кода. API поддерживает полную совместимость для конвертации презентации PPT в PPTX и можно:

- Конвертировать сложные структуры мастер-слайдов, макетов и слайдов.
- Конвертировать презентацию с диаграммами.
- Конвертировать презентацию с группами фигур, автофигурами (такими как прямоугольники и эллипсы), фигурами с пользовательской геометрией.
- Конвертировать презентацию, имеющую текстуры и стили заливки изображениями для автофигур.
- Конвертировать презентацию с заполнителями, текстовыми рамками и текстовыми держателями.

{{% alert color="primary" %}} 

Посмотрите на [**Конвертацию PPT в PPTX Aspose.Slides**](https://products.aspose.app/slides/conversion/ppt-to-pptx):

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Это приложение построено на основе **API Aspose.Slides**, поэтому вы можете увидеть живой пример основных возможностей конвертации PPT в PPTX. Конвертация Aspose.Slides — это веб-приложение, которое позволяет загрузить файл презентации в формате PPT и скачать его конвертированным в PPTX.

Находите другие живые примеры [**Конверсии Aspose.Slides**](https://products.aspose.app/slides/conversion/).
{{% /alert %}} 

## **Конвертация PPT в PPTX**
Чтобы конвертировать PPT в PPTX, просто передайте имя файла и формат сохранения в метод [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) класса [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation). Пример кода на C# ниже преобразует Презентацию из PPT в PPTX, используя настройки по умолчанию.

```c#
// Создадим объект Presentation, который представляет файл PPTX
Presentation pres = new Presentation("PPTtoPPTX.ppt");

// Сохраняем презентацию PPTX в формате PPTX
pres.Save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
```

Читайте подробнее о [**PPT против PPTX**](/slides/net/ppt-vs-pptx/) форматах презентаций и о том, как [**Aspose.Slides поддерживает конвертацию PPT в PPTX**](/slides/net/convert-ppt-to-pptx/).