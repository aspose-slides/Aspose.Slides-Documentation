---
title: Преобразование PPT в PPTX в Python
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
description: "Быстро преобразуйте устаревшие PPT‑презентации в современные PPTX с помощью Python и Aspose.Slides — понятный учебник, бесплатные примеры кода, без зависимости от Microsoft Office."
---

## **Обзор**

В этой статье объясняется, как преобразовать презентацию PowerPoint в формате PPT в формат PPTX с помощью Python и онлайн‑приложения для конвертации PPT в PPTX. Рассматривается следующая тема:

- Преобразовать PPT в PPTX в Python

## **Python: преобразование PPT в PPTX**

Для примера кода на Python, преобразующего PPT в PPTX, см. раздел ниже, а именно [Преобразовать PPT в PPTX](#convert-ppt-to-pptx). Он просто загружает файл PPT и сохраняет его в формате PPTX. Указывая разные форматы сохранения, можно также сохранять файл PPT в многих других форматах, таких как PDF, XPS, ODP, HTML и др., как описано в следующих статьях:

- [Python: преобразование PPT в PDF](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-pdf/)
- [Python: преобразование PPT в XPS](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-xps/)
- [Python: преобразование PPT в HTML](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-html/)
- [Python: сохранение PPT в ODP](https://docs.aspose.com/slides/python-net/save-presentation/)
- [Python: преобразование PPT в изображение](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-png/)

## **О преобразовании PPT в PPTX**

Преобразуйте старый формат PPT в PPTX с помощью Aspose.Slides API. Если требуется преобразовать тысячи PPT‑презентаций в PPTX, лучшее решение — сделать это программно. С Aspose.Slides API это возможно выполнить всего в несколько строк кода. API поддерживает полную совместимость при конвертации PPT‑презентации в PPTX и позволяет:

- Преобразовать сложные структуры мастеров, макетов и слайдов.
- Преобразовать презентацию с диаграммами.
- Преобразовать презентацию с группировкой фигур, автофигурами (например, прямоугольниками и эллипсами) и фигурами с пользовательской геометрией.
- Преобразовать презентацию, содержащую текстуры и заливку изображениями для автофигур.
- Преобразовать презентацию с заполнителями, текстовыми фреймами и текстовыми держателями.

{{% alert color="primary" %}}

Посмотрите на приложение [**Aspose.Slides PPT в PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx):

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Это приложение построено на основе **Aspose.Slides API**, поэтому вы можете увидеть живой пример базовых возможностей конвертации PPT в PPTX. Aspose.Slides Conversion — веб‑приложение, позволяющее загрузить файл презентации в формате PPT и скачать его, преобразованный в PPTX.

Найдите другие живые примеры [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/).

{{% /alert %}}

## **Преобразовать PPT в PPTX**

Чтобы преобразовать PPT в PPTX, просто передайте имя файла и формат сохранения в метод [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) класса [**Presentation**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). Приведённый ниже пример кода на Python преобразует презентацию из PPT в PPTX, используя параметры по умолчанию.

```python
import aspose.slides as slides

# Создать объект Presentation, представляющий PPT‑файл
pres = slides.Presentation("PPTtoPPTX.ppt")

# Сохранить презентацию в формате PPTX
pres.save("PPTtoPPTX_out.pptx", slides.export.SaveFormat.PPTX)
```

Читать дальше о форматах презентаций [**PPT vs PPTX**](/slides/ru/python-net/ppt-vs-pptx/) и о том, как [**Aspose.Slides поддерживает конвертацию PPT в PPTX**](/slides/ru/python-net/convert-ppt-to-pptx/).

## Часто задаваемые вопросы

### **В чем разница между форматами PPT и PPTX?**

PPT — старый бинарный формат файлов, используемый Microsoft PowerPoint, тогда как PPTX — более новый XML‑основанный формат, представленный в Microsoft Office 2007. Файлы PPTX обеспечивают лучшую производительность, меньший размер и повышенную надёжность восстановления данных.

### **Можно ли конвертировать PPT в PPTX с помощью Python?**

Да, используя библиотеку Aspose.Slides for Python via .NET, вы можете легко загрузить файл PPT и сохранить его в формате PPTX всего за несколько строк кода.

### **Нужен ли Aspose.Slides for Python via .NET для конвертации PPT в PPTX?**

Да, API Aspose.Slides предоставляет необходимые методы и классы для программного преобразования, манипулирования и сохранения презентаций PowerPoint без зависимости от Microsoft PowerPoint.

### **Поддерживает ли Aspose.Slides пакетную конвертацию нескольких файлов PPT в PPTX?**

Да, вы можете использовать Aspose.Slides в цикле для программного преобразования множества файлов PPT в PPTX, что подходит для сценариев пакетной обработки.

### **Сохранятся ли содержимое и форматирование после конвертации?**

Aspose.Slides сохраняет высокую точность при конвертации презентаций. Макеты слайдов, анимации, фигуры, диаграммы и другие элементы дизайна сохраняются при переходе из PPT в PPTX.

### **Можно ли конвертировать другие форматы, такие как PDF или HTML, из файлов PPT?**

Да, Aspose.Slides поддерживает конвертацию PPT‑файлов в различные форматы, включая PDF, XPS, HTML, ODP и графические форматы, такие как PNG и JPEG.

### **Возможно ли преобразовать PPT в PPTX без установленного Microsoft PowerPoint?**

Да, Aspose.Slides for Python via .NET — автономный API и не требует Microsoft PowerPoint или стороннего программного обеспечения для выполнения конвертации.

### **Существует ли онлайн‑инструмент для конвертации PPT в PPTX?**

Да, вы можете воспользоваться бесплатным веб‑приложением [Aspose.Slides PPT в PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) для выполнения конвертации непосредственно в браузере без написания кода.