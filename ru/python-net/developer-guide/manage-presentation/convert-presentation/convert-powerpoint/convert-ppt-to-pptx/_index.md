---
title: Конвертировать PPT в PPTX в Python
linktitle: PPT в PPTX
type: docs
weight: 20
url: /ru/python-net/convert-ppt-to-pptx/
keywords:
- конвертировать PPT
- PPT в PPTX
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Конвертируйте устаревшие презентации PPT в современные PPTX быстро в Python с Aspose.Slides — понятный учебник, бесплатные примеры кода, без зависимости от Microsoft Office."
---

## **Обзор**

Эта статья объясняет, как преобразовать презентацию PowerPoint в формате PPT в формат PPTX с помощью Python и онлайн‑приложения для конвертации PPT в PPTX. Рассмотрена следующая тема:

- Конвертация PPT в PPTX на Python

## **Python Конвертация PPT в PPTX**

Пример кода на Python для конвертации PPT в PPTX см. в разделе ниже, то есть [Конвертировать PPT в PPTX](#convert-ppt-to-pptx). Он просто загружает файл PPT и сохраняет его в формате PPTX. Указывая различные форматы сохранения, можно также сохранять файл PPT в многие другие форматы, такие как PDF, XPS, ODP, HTML и т.д., как описано в следующих статьях:

- [Python Конвертация PPT в PDF](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-pdf/)
- [Python Конвертация PPT в XPS](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-xps/)
- [Python Конвертация PPT в HTML](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-html/)
- [Python Конвертация PPT в ODP](https://docs.aspose.com/slides/python-net/save-presentation/)
- [Python Конвертация PPT в Image](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-png/)

## **О конвертации PPT в PPTX**
Преобразуйте старый формат PPT в PPTX с помощью Aspose.Slides API. Если вам нужно конвертировать тысячи презентаций PPT в формат PPTX, лучшее решение — делать это программно. С Aspose.Slides API это возможно выполнить всего в несколько строк кода. API обеспечивает полную совместимость для конвертации презентации PPT в PPTX, и можно:

- Конвертировать сложные структуры мастеров, макетов и слайдов.
- Конвертировать презентацию с диаграммами.
- Конвертировать презентацию с групповыми фигурами, автофигурами (например, прямоугольниками и эллипсами) и фигурами с пользовательской геометрией.
- Конвертировать презентацию с текстурами и стилями заливки изображениями для автофигур.
- Конвертировать презентацию с заполнителями, текстовыми рамками и текстовыми объектами.

{{% alert color="primary" %}}

Посмотрите на приложение [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx):

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Это приложение построено на основе **Aspose.Slides API**, поэтому вы можете увидеть живой пример базовых возможностей конвертации PPT в PPTX. Aspose.Slides Conversion — это веб‑приложение, которое позволяет загрузить файл презентации в формате PPT и скачать его в виде конвертированного PPTX.

Найдите другие живые примеры [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) .

{{% /alert %}}

## **Конвертировать PPT в PPTX**
Чтобы конвертировать PPT в PPTX, просто передайте имя файла и формат сохранения методу [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) класса [**Presentation**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). Пример кода на Python ниже конвертирует презентацию из PPT в PPTX, используя параметры по умолчанию.
```python
import aspose.slides as slides

# Создать объект Presentation, представляющий файл PPT
pres = slides.Presentation("PPTtoPPTX.ppt")

# Сохранить презентацию в формате PPTX
pres.save("PPTtoPPTX_out.pptx", slides.export.SaveFormat.PPTX)
```


Читайте подробнее о форматах презентаций [**PPT vs PPTX**](/slides/ru/python-net/ppt-vs-pptx/) и о том, как [**Aspose.Slides поддерживает конвертацию PPT в PPTX**](/slides/ru/python-net/convert-ppt-to-pptx/).

## Часто задаваемые вопросы

### **В чем разница между форматами PPT и PPTX?**

PPT — это более старый двоичный формат файла, используемый Microsoft PowerPoint, тогда как PPTX — более новый формат на основе XML, внедренный в Microsoft Office 2007. Файлы PPTX обеспечивают лучшую производительность, меньший размер и более эффективное восстановление данных.

### **Можно ли конвертировать PPT в PPTX с помощью Python?**

Да, используя библиотеку Aspose.Slides for Python via .NET, вы можете легко загрузить файл PPT и сохранить его в формате PPTX всего несколькими строками кода.

### **Требуется ли Aspose.Slides for Python via .NET для конвертации PPT в PPTX?**

Да, API Aspose.Slides предоставляет необходимые методы и классы для программной конвертации, манипуляции и сохранения презентаций PowerPoint без необходимости использовать Microsoft PowerPoint.

### **Поддерживает ли Aspose.Slides пакетную конвертацию нескольких файлов PPT в PPTX?**

Да, вы можете использовать Aspose.Slides в цикле для программной конвертации множества файлов PPT в PPTX, что подходит для сценариев пакетной обработки.

### **Будут ли содержимое и форматирование сохранены после конвертации?**

Aspose.Slides сохраняет высокую точность при конвертации презентаций. Макеты слайдов, анимации, фигуры, диаграммы и другие элементы дизайна сохраняются при преобразовании PPT в PPTX.

### **Могу ли я конвертировать другие форматы, такие как PDF или HTML, из файлов PPT?**

Да, Aspose.Slides поддерживает конвертацию файлов PPT в несколько форматов, включая PDF, XPS, HTML, ODP и графические форматы, такие как PNG и JPEG.

### **Можно ли конвертировать PPT в PPTX без установленного Microsoft PowerPoint?**

Да, Aspose.Slides for Python via .NET является автономным API и не требует Microsoft PowerPoint или какого‑либо стороннего программного обеспечения для выполнения конвертации.

### **Существует ли онлайн‑инструмент для конвертации PPT в PPTX?**

Да, вы можете воспользоваться бесплатным веб‑приложением [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) для выполнения конвертации непосредственно в браузере без написания кода.