---
title: Преобразовать PPT в PPTX на Python
linktitle: PPT в PPTX
type: docs
weight: 20
url: /ru/python-net/convert-ppt-to-pptx/
keywords:
- преобразовать PPT
- PPT в PPTX
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Быстро преобразуйте устаревшие презентации PPT в современный формат PPTX с помощью Python и Aspose.Slides — понятный учебник, бесплатные примеры кода, без зависимости от Microsoft Office."
---

## **Обзор**

В этой статье объясняется, как преобразовать презентацию PowerPoint в формате PPT в формат PPTX с помощью Python и онлайн‑приложения для конвертации PPT в PPTX. Рассматриваются следующие темы:

- Конвертация PPT в PPTX в Python

## **Python: Конвертация PPT в PPTX**

Пример кода на Python для конвертации PPT в PPTX см. в разделе ниже, то есть [Convert PPT to PPTX](#convert-ppt-to-pptx). Он просто загружает файл PPT и сохраняет его в формате PPTX. Указывая различные форматы сохранения, вы также можете сохранить файл PPT в многих других форматах, таких как PDF, XPS, ODP, HTML и т.д., как описано в этих статьях:

- [Convert PPT to PDF in Python](/slides/ru/python-net/convert-powerpoint-to-pdf/)
- [Convert PPT to XPS in Python](/slides/ru/python-net/convert-powerpoint-to-xps/)
- [Convert PPT to HTML in Python](/slides/ru/python-net/convert-powerpoint-to-html/)
- [Convert PPT to ODP in Python](/slides/ru/python-net/save-presentation/)
- [Convert PPT to PNG in Python](/slides/ru/python-net/convert-powerpoint-to-png/)

## **О конвертации PPT в PPTX**
Конвертируйте старый формат PPT в PPTX с помощью API Aspose.Slides. Если вам нужно конвертировать тысячи презентаций PPT в формат PPTX, лучшее решение — выполнить это программно. С API Aspose.Slides это возможно сделать всего в несколько строк кода. API обеспечивает полную совместимость при конвертации презентации PPT в PPTX, и позволяет:

- Конвертировать сложные структуры мастеров, макетов и слайдов.
- Конвертировать презентацию с диаграммами.
- Конвертировать презентацию с групповыми фигурами, автофигурами (например, прямоугольниками и эллипсами) и фигурами с пользовательской геометрией.
- Конвертировать презентацию с текстурами и заливкой изображениями для автофигур.
- Конвертировать презентацию с заполнителями, текстовыми фреймами и текстовыми объектами.

{{% alert color="primary" %}}

Посмотрите приложение [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx):

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Это приложение построено на основе **Aspose.Slides API**, поэтому вы можете увидеть работающий пример базовых возможностей конвертации PPT в PPTX. Aspose.Slides Conversion — веб‑приложение, которое позволяет загрузить файл презентации в формате PPT и скачать его в формате PPTX.

Найдите другие живые примеры [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/).
{{% /alert %}}

## **Конвертация PPT в PPTX**
Чтобы конвертировать PPT в PPTX, просто передайте имя файла и формат сохранения в метод [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) класса [**Presentation**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). Пример кода на Python ниже конвертирует презентацию из PPT в PPTX, используя параметры по умолчанию.
```python
import aspose.slides as slides

# Создайте объект Presentation, представляющий файл PPT
pres = slides.Presentation("PPTtoPPTX.ppt")

# Сохраните презентацию в формате PPTX
pres.save("PPTtoPPTX_out.pptx", slides.export.SaveFormat.PPTX)
```


Читайте подробнее о форматах презентаций [**PPT vs PPTX**](/slides/ru/python-net/ppt-vs-pptx/) и о том, как [**Aspose.Slides поддерживает конвертацию PPT в PPTX**](/slides/ru/python-net/convert-ppt-to-pptx/).

## **FAQ**

**В чем разница между форматами PPT и PPTX?**

PPT — старый двоичный формат файлов, используемый Microsoft PowerPoint, тогда как PPTX — более новый формат на основе XML, впервые представленный в Microsoft Office 2007. Файлы PPTX обеспечивают более высокую производительность, меньший размер и лучшую восстановимость данных.

**Можно ли конвертировать PPT в PPTX с помощью Python?**

Да, используя библиотеку Aspose.Slides for Python via .NET, вы можете легко загрузить файл PPT и сохранить его в формате PPTX всего несколькими строками кода.

**Поддерживает ли Aspose.Slides пакетную конвертацию нескольких файлов PPT в PPTX?**

Да, вы можете использовать Aspose.Slides в цикле для программной конвертации множества файлов PPT в PPTX, что подходит для сценариев пакетной обработки.

**Сохранится ли содержание и форматирование после конвертации?**

Aspose.Slides сохраняет высокую точность при конвертации презентаций. Макеты слайдов, анимации, фигуры, диаграммы и другие элементы дизайна сохраняются при преобразовании PPT в PPTX.

**Можно ли конвертировать другие форматы, такие как PDF или HTML, из файлов PPT?**

Да, Aspose.Slides поддерживает конвертацию файлов PPT в несколько форматов, включая PDF, XPS, HTML, ODP и графические форматы, такие как PNG и JPEG.

**Можно ли конвертировать PPT в PPTX без установленного Microsoft PowerPoint?**

Да, Aspose.Slides for Python via .NET — автономный API и не требует установки Microsoft PowerPoint или любого стороннего программного обеспечения для выполнения конвертации.

**Существует ли онлайн‑инструмент для конвертации PPT в PPTX?**

Да, вы можете воспользоваться бесплатным веб‑приложением [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) для выполнения конвертации прямо в браузере без написания кода.