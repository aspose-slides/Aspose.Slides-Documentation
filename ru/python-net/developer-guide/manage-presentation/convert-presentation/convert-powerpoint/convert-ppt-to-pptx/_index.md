---
title: Преобразование PPT в PPTX на Python
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
description: "Быстро преобразуйте устаревшие презентации PPT в современные PPTX на Python с помощью Aspose.Slides — понятный учебник, бесплатные примеры кода, без зависимости от Microsoft Office."
---

## **Обзор**

В этой статье объясняется, как преобразовать презентацию PowerPoint в формате PPT в формат PPTX с помощью Python и онлайн‑приложения для конвертации PPT в PPTX. Рассмотрены следующие темы:

- Преобразование PPT в PPTX на Python

## **Преобразование PPT в PPTX на Python**

Пример кода Python для преобразования PPT в PPTX находится в разделе ниже, то есть [Convert PPT to PPTX](#convert-ppt-to-pptx). Он просто загружает файл PPT и сохраняет его в формате PPTX. Указывая разные форматы сохранения, вы также можете сохранить файл PPT в многих других форматах, таких как PDF, XPS, ODP, HTML и др., как описано в следующих статьях:

- [Python Преобразование PPT в PDF](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-pdf/)
- [Python Преобразование PPT в XPS](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-xps/)
- [Python Преобразование PPT в HTML](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-html/)
- [Python Преобразование PPT в ODP](https://docs.aspose.com/slides/python-net/save-presentation/)
- [Python Преобразование PPT в изображение](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-png/)

## **О преобразовании PPT в PPTX**

Преобразуйте старый формат PPT в PPTX с помощью API Aspose.Slides. Если вам нужно преобразовать тысячи презентаций PPT в формат PPTX, лучшим решением является сделать это программно. С API Aspose.Slides это возможно выполнить всего в нескольких строках кода. API полностью совместим для преобразования презентации PPT в PPTX, и позволяет:

- Преобразовывать сложные структуры шаблонов, макетов и слайдов.
- Преобразовывать презентацию с диаграммами.
- Преобразовывать презентацию с групповыми фигурами, автофигурами (например, прямоугольники и окружности) и фигурами с пользовательской геометрией.
- Преобразовывать презентацию, содержащую текстуры и стили заливки изображением для автофигур.
- Преобразовывать презентацию с заполнителями, текстовыми рамками и текстовыми держателями.

{{% alert color="primary" %}}

Посмотрите приложение [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx):

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Это приложение построено на основе **Aspose.Slides API**, поэтому вы можете увидеть живой пример базовых возможностей конвертации PPT в PPTX. Aspose.Slides Conversion — это веб‑приложение, позволяющее перетащить файл презентации в формате PPT и загрузить его преобразованным в PPTX.

Найдите другие живые примеры [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/).
{{% /alert %}}

## **Преобразование PPT в PPTX**

Чтобы преобразовать PPT в PPTX, просто передайте имя файла и формат сохранения методу [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) класса [**Presentation**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). Пример кода на Python ниже преобразует презентацию из PPT в PPTX, используя параметры по умолчанию.

```python
import aspose.slides as slides

# Instantiate a Presentation object that represents a PPT file
pres = slides.Presentation("PPTtoPPTX.ppt")

# Save the presentation in PPTX format
pres.save("PPTtoPPTX_out.pptx", slides.export.SaveFormat.PPTX)
```

Читайте подробнее о формате презентаций [**PPT vs PPTX**](/slides/ru/python-net/ppt-vs-pptx/) и как [**Aspose.Slides поддерживает преобразование PPT в PPTX**](/slides/ru/python-net/convert-ppt-to-pptx/).

## Часто задаваемые вопросы

### **В чём разница между форматами PPT и PPTX?**

PPT — старый двоичный формат файлов, используемый Microsoft PowerPoint, тогда как PPTX — более новый формат на основе XML, введённый в Microsoft Office 2007. Файлы PPTX обеспечивают лучшую производительность, меньший размер и улучшенное восстановление данных.

### **Можно ли преобразовать PPT в PPTX с помощью Python?**

Да, используя библиотеку Aspose.Slides for Python via .NET, вы можете легко загрузить файл PPT и сохранить его в формате PPTX, написав всего несколько строк кода.

### **Нужен ли Aspose.Slides for Python via .NET для конвертации PPT в PPTX?**

Да, API Aspose.Slides предоставляет необходимые методы и классы для программного преобразования, манипулирования и сохранения презентаций PowerPoint без зависимости от Microsoft PowerPoint.

### **Поддерживает ли Aspose.Slides пакетную конвертацию нескольких файлов PPT в PPTX?**

Да, вы можете использовать Aspose.Slides в цикле для программного преобразования множества файлов PPT в PPTX, что удобно для пакетных сценариев.

### **Будут ли сохранены содержимое и форматирование после конвертации?**

Aspose.Slides сохраняет высокую точность при преобразовании презентаций. Макеты слайдов, анимации, фигуры, диаграммы и другие элементы дизайна сохраняются при конвертации PPT в PPTX.

### **Можно ли из файлов PPT конвертировать другие форматы, например PDF или HTML?**

Да, Aspose.Slides поддерживает преобразование файлов PPT в различные форматы, включая PDF, XPS, HTML, ODP и графические форматы, такие как PNG и JPEG.

### **Можно ли выполнить конвертацию PPT в PPTX без установленного Microsoft PowerPoint?**

Да, Aspose.Slides for Python via .NET — это автономный API, не требующий Microsoft PowerPoint или какого‑либо стороннего программного обеспечения для выполнения конвертации.

### **Существует ли онлайн‑инструмент для конвертации PPT в PPTX?**

Да, вы можете воспользоваться бесплатным веб‑приложением [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) для выполнения преобразования непосредственно в браузере без написания кода.