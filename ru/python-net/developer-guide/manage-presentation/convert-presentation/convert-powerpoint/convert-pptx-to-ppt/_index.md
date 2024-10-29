---
title: Конвертация PPTX в PPT на Python
linktitle: Конвертация PPTX в PPT
type: docs
weight: 21
url: /ru/python-net/convert-pptx-to-ppt/
keywords: "Python Конвертация PPTX в PPT, Конвертация презентации PowerPoint, PPTX в PPT, Python, Aspose.Slides"
description: "Конвертация PowerPoint PPTX в PPT на Python"
---

## **Обзор**

В этой статье объясняется, как конвертировать презентацию PowerPoint в формате PPTX в формат PPT с помощью Python. Рассматривается следующая тема.

- Конвертация PPTX в PPT на Python

## **Конвертация PPTX в PPT на Python**

Для получения примера кода на Python для конвертации PPTX в PPT, пожалуйста, ознакомьтесь с разделом ниже, т.е. [Конвертация PPTX в PPT](#convert-pptx-to-ppt). Он просто загружает файл PPTX и сохраняет его в формате PPT. Указав различные форматы сохранения, вы также можете сохранить файл PPTX в многие другие форматы, такие как PDF, XPS, ODP, HTML и т.д., как обсуждается в этих статьях.

- [Конвертация PPTX в PDF на Python](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-pdf/)
- [Конвертация PPTX в XPS на Python](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-xps/)
- [Конвертация PPTX в HTML на Python](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-html/)
- [Конвертация PPTX в ODP на Python](https://docs.aspose.com/slides/python-net/save-presentation/)
- [Конвертация PPTX в изображение на Python](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-png/)

## **Конвертация PPTX в PPT**
Чтобы конвертировать PPTX в PPT, просто передайте имя файла и формат сохранения в метод [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) класса [**Presentation**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). Приведенный ниже пример кода на Python конвертирует презентацию из PPTX в PPT с использованием параметров по умолчанию.

```py
import aspose.slides as slides

# Создайте объект Presentation, который представляет файл PPTX
pres = slides.Presentation("presentation.pptx")

# Сохранение презентации PPTX в формате PPT
pres.save("presentation.ppt", slides.export.SaveFormat.PPT)
```