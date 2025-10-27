---
title: Конвертировать PPT в PPTX на Python
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
description: "Конвертируйте старые презентации PPT в современный формат PPTX быстро на Python с Aspose.Slides — четкое руководство, бесплатные примеры кода, без зависимости от Microsoft Office."
---

## **Обзор**

В этой статье объясняется, как преобразовать презентацию PowerPoint в формате PPT в формат PPTX с помощью Python и онлайн‑приложения для конверсии PPT в PPTX. Рассмотрены следующие темы:

- Конвертировать PPT в PPTX в Python

## **Python: Конвертировать PPT в PPTX**

Для примеров кода на Python, преобразующих PPT в PPTX, см. раздел ниже, а именно [Конвертировать PPT в PPTX](#convert-ppt-to-pptx). Он просто загружает файл PPT и сохраняет его в формате PPTX. Указывая различные форматы сохранения, вы также можете сохранить PPT‑файл в многих других форматах, таких как PDF, XPS, ODP, HTML и т.д., как описано в следующих статьях:

- [Python: Конвертировать PPT в PDF](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-pdf/)
- [Python: Конвертировать PPT в XPS](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-xps/)
- [Python: Конвертировать PPT в HTML](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-html/)
- [Python: Конвертировать PPT в ODP](https://docs.aspose.com/slides/python-net/save-presentation/)
- [Python: Конвертировать PPT в изображение](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-png/)

## **О конверсии PPT в PPTX**
Преобразуйте старый формат PPT в PPTX с помощью API Aspose.Slides. Если необходимо конвертировать тысячи презентаций PPT в формат PPTX, наилучшее решение — сделать это программно. С API Aspose.Slides это возможно выполнить всего в несколько строк кода. API обеспечивает полную совместимость при конвертации презентации PPT в PPTX, позволяя:

- Конвертировать сложные структуры шаблонов, макетов и слайдов.
- Конвертировать презентацию с диаграммами.
- Конвертировать презентацию с групповыми объектами, авто‑фигурами (например, прямоугольниками и эллипсами) и фигурами с пользовательской геометрией.
- Конвертировать презентацию, содержащую текстуры и стили заливки изображениями для авто‑фигур.
- Конвертировать презентацию с заполнителями, текстовыми кадрами и текстовыми полями.

{{% alert color="primary" %}}

Посмотрите приложение [**Aspose.Slides PPT в PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx):

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Это приложение построено на основе **API Aspose.Slides**, поэтому вы можете увидеть работающий пример базовых возможностей конверсии PPT в PPTX. Aspose.Slides Conversion — веб‑приложение, позволяющее загрузить файл презентации в формате PPT и скачать его, преобразованным в PPTX.

Найдите другие живые примеры [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/).
{{% /alert %}}

## **Конвертировать PPT в PPTX**
Чтобы преобразовать PPT в PPTX, просто передайте имя файла и формат сохранения в метод [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) класса [**Presentation**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). Пример кода на Python ниже преобразует презентацию из PPT в PPTX, используя параметры по умолчанию.

```python
import aspose.slides as slides

# Создаём объект Presentation, представляющий файл PPT
pres = slides.Presentation("PPTtoPPTX.ppt")

# Сохраняем презентацию в формате PPTX
pres.save("PPTtoPPTX_out.pptx", slides.export.SaveFormat.PPTX)
```

Читайте подробнее о форматах презентаций [**PPT vs PPTX**](/slides/ru/python-net/ppt-vs-pptx/) и о том, как [**Aspose.Slides поддерживает конверсию PPT в PPTX**](/slides/ru/python-net/convert-ppt-to-pptx/).

## Часто задаваемые вопросы

### **В чём разница между форматами PPT и PPTX?**

PPT — старый бинарный формат файлов, используемый Microsoft PowerPoint, тогда как PPTX — новый формат на основе XML, введённый в Microsoft Office 2007. Файлы PPTX обеспечивают лучшую производительность, меньший размер и более эффективное восстановление данных.

### **Можно ли конвертировать PPT в PPTX с помощью Python?**

Да, используя библиотеку Aspose.Slides for Python via .NET, вы можете легко загрузить файл PPT и сохранить его в формате PPTX, написав всего несколько строк кода.

### **Требуется ли Aspose.Slides for Python via .NET для конверсии PPT в PPTX?**

Да, API Aspose.Slides предоставляет необходимые методы и классы для программного преобразования, манипулирования и сохранения презентаций PowerPoint без зависимости от Microsoft PowerPoint.

### **Поддерживает ли Aspose.Slides пакетную конверсию нескольких файлов PPT в PPTX?**

Да, вы можете использовать Aspose.Slides в цикле, чтобы программно преобразовать множество файлов PPT в PPTX, что удобно для сценариев пакетной обработки.

### **Сохранится ли содержание и форматирование после конверсии?**

Aspose.Slides обеспечивает высокую точность при конвертации презентаций. Макеты слайдов, анимации, фигуры, диаграммы и другие элементы дизайна сохраняются при переходе из PPT в PPTX.

### **Можно ли конвертировать другие форматы, например PDF или HTML, из файлов PPT?**

Да, Aspose.Slides поддерживает преобразование файлов PPT в различные форматы, включая PDF, XPS, HTML, ODP и графические форматы, такие как PNG и JPEG.

### **Можно ли конвертировать PPT в PPTX без установленного Microsoft PowerPoint?**

Да, Aspose.Slides for Python via .NET — автономный API и не требует установки Microsoft PowerPoint или какого‑либо стороннего программного обеспечения для выполнения конверсии.

### **Есть ли онлайн‑инструмент для конверсии PPT в PPTX?**

Да, вы можете воспользоваться бесплатным веб‑приложением [Aspose.Slides PPT в PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx), которое позволяет выполнить конверсию прямо в браузере без написания кода.