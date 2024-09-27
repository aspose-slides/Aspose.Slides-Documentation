---
title: Конвертация PPT в PPTX на Python
linktitle: Конвертация PPT в PPTX
type: docs
weight: 20
url: /ru/python-net/convert-ppt-to-pptx/
keywords: "Python Конвертация PPT в PPTX, Конвертация Презентации PowerPoint, PPT в PPTX, Python, Aspose.Slides"
description: "Конвертация PowerPoint PPT в PPTX на Python"
---

## **Обзор**

Эта статья объясняет, как конвертировать презентацию PowerPoint в формате PPT в формат PPTX с использованием Python и онлайн-приложения для конвертации PPT в PPTX. Рассматриваемая тема:

- Конвертация PPT в PPTX на Python

## **Python Конвертация PPT в PPTX**

Для примера кода на Python для конвертации PPT в PPTX, пожалуйста, смотрите раздел ниже, т.е. [Конвертация PPT в PPTX](#convert-ppt-to-pptx). Он просто загружает файл PPT и сохраняет его в формате PPTX. Указывая разные форматы сохранения, вы также можете сохранить файл PPT в многие другие форматы, такие как PDF, XPS, ODP, HTML и т.д., как обсуждено в этих статьях.

- [Python Конвертация PPT в PDF](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-pdf/)
- [Python Конвертация PPT в XPS](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-xps/)
- [Python Конвертация PPT в HTML](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-html/)
- [Python Конвертация PPT в ODP](https://docs.aspose.com/slides/python-net/save-presentation/)
- [Python Конвертация PPT в Изображение](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-png/)

## **О конвертации PPT в PPTX**
Конвертируйте старый формат PPT в PPTX с помощью API Aspose.Slides. Если вам нужно конвертировать тысячи презентаций PPT в формат PPTX, лучшее решение - сделать это программно. С API Aspose.Slides это возможно сделать всего в несколько строк кода. API поддерживает полную совместимость для конвертации презентации PPT в PPTX и это возможно:

- Конвертировать сложные структуры мастеров, макетов и слайдов.
- Конвертировать презентацию с диаграммами.
- Конвертировать презентацию с группами фигур, автоматическими фигурами (такими как прямоугольники и эллипсы), фигурами с пользовательской геометрией.
- Конвертировать презентацию, содержащую текстуры и стили заполнения изображений для автоматических фигур.
- Конвертировать презентацию с заполнительными объектами, текстовыми рамками и текстовыми блоками.

{{% alert color="primary" %}} 

Посмотрите на [**Aspose.Slides Конвертация PPT в PPTX**](https://products.aspose.app/slides/conversion/ppt-to-pptx) приложение:

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Это приложение основано на **Aspose.Slides API**, поэтому вы можете видеть живой пример основных возможностей конвертации PPT в PPTX. Aspose.Slides Конвертация - это веб-приложение, которое позволяет загрузить файл презентации в формате PPT и скачать его в конвертированном формате PPTX.

Найдите другие живые примеры [**Конвертации Aspose.Slides**](https://products.aspose.app/slides/conversion/).
{{% /alert %}} 


## **Конвертировать PPT в PPTX**
Чтобы конвертировать PPT в PPTX, просто передайте имя файла и формат сохранения в метод [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) класса [**Presentation**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). Пример кода на Python ниже конвертирует презентацию из PPT в PPTX с использованием параметров по умолчанию.

```py
import aspose.slides as slides

# Создаем объект Presentation, который представляет файл PPTX
pres = slides.Presentation("PPTtoPPTX.ppt")

# Сохраняем презентацию PPTX в формате PPTX
pres.save("PPTtoPPTX_out.pptx", slides.export.SaveFormat.PPTX)
```



Читать больше о [**PPT vs PPTX**](/slides/ru/python-net/ppt-vs-pptx/) форматах презентаций и о том, как [**Aspose.Slides поддерживает конвертацию PPT в PPTX**](/slides/ru/python-net/convert-ppt-to-pptx/).