---
title: Конвертация PPT в PPTX в Python
linktitle: PPT в PPTX
type: docs
weight: 20
url: /ru/python-net/developer-guide/manage-presentation/convert-presentation/convert-powerpoint/convert-ppt-to-pptx/
keywords:
- конвертация PPT
- PPT в PPTX
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Быстрая конвертация устаревших презентаций PPT в современный формат PPTX в Python с помощью Aspose.Slides — подробный учебник, бесплатные примеры кода, без зависимости от Microsoft Office."
---

## **Обзор**

В этой статье описывается, как преобразовать презентацию PowerPoint в формате PPT в формат PPTX с помощью Python и онлайн‑приложения для конвертации PPT в PPTX. Рассматривается следующая тема:

- Конвертация PPT в PPTX в Python

## **Python: конвертация PPT в PPTX**

Для примера кода на Python, преобразующего PPT в PPTX, см. раздел ниже, то есть [Конвертация PPT в PPTX](#convert-ppt-to-pptx). Он просто загружает файл PPT и сохраняет его в формате PPTX. Указав другие форматы сохранения, можно также сохранить файл PPT в множество других форматов, таких как PDF, XPS, ODP, HTML и т.п., как описано в следующих статьях:

- [Python: конвертация PPT в PDF](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-pdf/)
- [Python: конвертация PPT в XPS](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-xps/)
- [Python: конвертация PPT в HTML](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-html/)
- [Python: конвертация PPT в ODP](https://docs.aspose.com/slides/python-net/save-presentation/)
- [Python: конвертация PPT в изображение](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-png/)

## **О конвертации PPT в PPTX**
Преобразуйте старый формат PPT в PPTX с помощью Aspose.Slides API. Если необходимо конвертировать тысячи презентаций PPT в формат PPTX, наилучшее решение — выполнять это программно. С Aspose.Slides API это возможно сделать всего в несколько строк кода. API обеспечивает полную совместимость при конвертации презентации PPT в PPTX, позволяя:

- Конвертировать сложные структуры шаблонов, макетов и слайдов.
- Конвертировать презентацию с диаграммами.
- Конвертировать презентацию с группированными фигурами, автофигурой (например, прямоугольники и эллипсы) и фигурами с пользовательской геометрией.
- Конвертировать презентацию, содержащую текстуры и стили заливки изображениями для автофигур.
- Конвертировать презентацию с заполнителями, текстовыми блоками и текстовыми холдерами.

{{% alert color="primary" %}}

Ознакомьтесь с приложением [**Aspose.Slides PPT в PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx):

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Это приложение построено на основе **Aspose.Slides API**, поэтому вы можете увидеть живой пример базовых возможностей конвертации PPT в PPTX. Aspose.Slides Conversion — веб‑приложение, позволяющее перетащить файл презентации в формате PPT и загрузить его в формате PPTX.

Найдите другие живые примеры [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/).
{{% /alert %}}

## **Конвертация PPT в PPTX**
Чтобы преобразовать PPT в PPTX, просто передайте имя файла и формат сохранения методу [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) класса [**Presentation**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). Пример кода на Python ниже конвертирует презентацию из PPT в PPTX, используя параметры по умолчанию.

```python
import aspose.slides as slides

# Создаём объект Presentation, представляющий файл PPT
pres = slides.Presentation("PPTtoPPTX.ppt")

# Сохраняем презентацию в формате PPTX
pres.save("PPTtoPPTX_out.pptx", slides.export.SaveFormat.PPTX)
```

Подробнее о форматах презентаций [**PPT vs PPTX**](/slides/ru/python-net/ppt-vs-pptx/) и о том, как [**Aspose.Slides поддерживает конвертацию PPT в PPTX**](/slides/ru/python-net/convert-ppt-to-pptx/).

## Часто задаваемые вопросы

### **В чём разница между форматами PPT и PPTX?**

PPT — старый бинарный формат файлов, используемый Microsoft PowerPoint, а PPTX — новый формат на основе XML, появившийся в Microsoft Office 2007. Файлы PPTX обеспечивают лучшую производительность, меньший размер и улучшенное восстановление данных.

### **Можно ли конвертировать PPT в PPTX с помощью Python?**

Да, используя библиотеку Aspose.Slides for Python via .NET, вы можете легко загрузить файл PPT и сохранить его в формате PPTX всего несколькими строками кода.

### **Нужна ли библиотека Aspose.Slides for Python via .NET для конвертации PPT в PPTX?**

Да, API Aspose.Slides предоставляет необходимые методы и классы для программной конвертации, манипуляции и сохранения презентаций PowerPoint без зависимости от Microsoft PowerPoint.

### **Поддерживает ли Aspose.Slides пакетную конвертацию нескольких файлов PPT в PPTX?**

Да, можно использовать Aspose.Slides в цикле для программной конвертации множества файлов PPT в PPTX, что подходит для сценариев пакетной обработки.

### **Будут ли сохранены содержимое и форматирование после конвертации?**

Aspose.Slides сохраняет высокую точность при конвертации презентаций. Макеты слайдов, анимации, фигуры, диаграммы и другие элементы дизайна сохраняются при переходе из PPT в PPTX.

### **Можно ли конвертировать другие форматы, например PDF или HTML, из файлов PPT?**

Да, Aspose.Slides поддерживает конвертацию PPT в множество форматов, включая PDF, XPS, HTML, ODP и графические форматы такие как PNG и JPEG.

### **Можно ли выполнить конвертацию PPT в PPTX без установленного Microsoft PowerPoint?**

Да, Aspose.Slides for Python via .NET — автономный API, не требующий Microsoft PowerPoint или какого‑либо стороннего программного обеспечения для выполнения конвертации.

### **Существует ли онлайн‑инструмент для конвертации PPT в PPTX?**

Да, вы можете воспользоваться бесплатным веб‑приложением [Aspose.Slides PPT в PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) для выполнения конвертации прямо в браузере без написания кода.