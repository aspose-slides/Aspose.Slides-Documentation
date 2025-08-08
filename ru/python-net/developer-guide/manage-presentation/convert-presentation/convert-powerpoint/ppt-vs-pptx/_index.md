---
title: "Разница между форматами: PPT и PPTX"
linktitle: PPT vs PPTX
type: docs
weight: 10
url: /ru/python-net/ppt-vs-pptx/
keywords:
- PPT vs PPTX
- PPT или PPTX
- устаревший формат
- современный формат
- двоичный формат
- современный стандарт
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Сравните PPT и PPTX для PowerPoint с помощью Aspose.Slides for Python via .NET, изучив различия форматов, преимущества, совместимость и советы по конвертации."
---

## **Что такое PPT?**
[**PPT**](https://docs.fileformat.com/presentation/ppt/) — это бинарный формат файлов, то есть невозможно просмотреть его содержимое без специальных инструментов. Первые версии PowerPoint 97-2003 работали с форматом файлов PPT, однако его расширяемость ограничена.

## **Что такое PPTX?**
[**PPTX**](https://docs.fileformat.com/presentation/pptx/) — это новый формат файлов презентаций, основанный на стандарте Office Open XML (ISO 29500:2008-2016, ECMA-376). PPTX представляет собой архивированный набор файлов XML и медиафайлов. Формат PPTX легко расширяем. Например, легко добавить поддержку нового типа диаграммы или типа фигуры, не меняя формат PPTX в каждой новой версии PowerPoint. Формат PPTX используется начиная с PowerPoint 2007.

## **PPT против PPTX**
Хотя PPTX предоставляет гораздо более широкие возможности, PPT остается довольно популярным. Необходимость конвертирования из PPT в PPTX и обратно очень востребована.

Тем не менее, конвертация между старым форматом PPT и новым форматом PPTX является самым сложным вызовом среди других форматов Microsoft Office. Хотя спецификация формата PPT открыта, с ним трудно работать. PowerPoint может создавать специальные части (MetroBlob) в файлах PPT для хранения информации из PPTX, которая не поддерживается форматом PPT и не может быть отображена в старых версиях PowerPoint. Эта информация может быть восстановлена при загрузке файла PPT в современной версии PowerPoint или при конвертации в формат PPTX.

Aspose.Slides предоставляет общий интерфейс для работы со всеми форматами презентаций. Он позволяет конвертировать из PPT в PPTX и из PPTX в PPT очень простым способом. Aspose.Slides полностью поддерживает конвертацию из PPT в PPTX, а также поддерживает конвертацию из PPTX в PPT с некоторыми ограничениями. Мы рекомендуем использовать формат PPTX, где это возможно.

{{% alert color="primary" %}} 

Проверьте качество конвертации PPT в PPTX и PPTX в PPT с помощью онлайн [**приложения Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/).

{{% /alert %}} 

```py
import aspose.slides as slides

# Создание объекта Presentation, который представляет файл PPTX
pres = slides.Presentation("PPTtoPPTX.ppt")

# Сохранение презентации PPTX в формате PPTX
pres.save("PPTtoPPTX_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 
Узнайте больше [**Как конвертировать презентации PPT в PPTX**.](/slides/ru/python-net/convert-ppt-to-pptx/)
{{% /alert %}} 