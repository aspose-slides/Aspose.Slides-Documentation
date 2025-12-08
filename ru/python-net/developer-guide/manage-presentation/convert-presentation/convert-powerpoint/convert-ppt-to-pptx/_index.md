---
title: Преобразовать PPT в PPTX на Python
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
description: "Конвертируйте устаревшие презентации PPT в современные PPTX быстро на Python с Aspose.Slides — понятный учебник, бесплатные примеры кода, без зависимости от Microsoft Office."
---

## **Обзор**

Эта статья объясняет, как преобразовать презентацию PowerPoint в формате PPT в формат PPTX с помощью Python и онлайн‑приложения для конвертации PPT в PPTX. Рассматривается следующая тема:

- Преобразовать PPT в PPTX с помощью Python

## **Преобразование PPT в PPTX с помощью Python**

Для примера кода на Python, который преобразует PPT в PPTX, см. раздел ниже, то есть [Convert PPT to PPTX](#convert-ppt-to-pptx). Он просто загружает файл PPT и сохраняет его в формате PPTX. Указывая различные форматы сохранения, вы также можете сохранить файл PPT в многих других форматах, таких как PDF, XPS, ODP, HTML и т.д., как описано в этих статьях:

- [Python Convert PPT to PDF](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-pdf/)
- [Python Convert PPT to XPS](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-xps/)
- [Python Convert PPT to HTML](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-html/)
- [Python Convert PPT to ODP](https://docs.aspose.com/slides/python-net/save-presentation/)
- [Python Convert PPT to Image](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-png/)

## **О конвертации PPT в PPTX**

Преобразуйте старый формат PPT в PPTX с помощью Aspose.Slides API. Если вам необходимо конвертировать тысячи презентаций PPT в формат PPTX, лучшее решение — делать это программно. С помощью Aspose.Slides API это возможно выполнить всего в нескольких строках кода. API обеспечивает полную совместимость при конвертации презентации PPT в PPTX, и вы можете:

- Преобразовать сложные структуры мастеров, макетов и слайдов.
- Преобразовать презентацию с диаграммами.
- Преобразовать презентацию с группированными объектами, автофигурами (например, прямоугольниками и эллипсами) и фигурами с пользовательской геометрией.
- Преобразовать презентацию, содержащую текстуры и стили заполнения изображениями для автофигур.
- Преобразовать презентацию с заполнителями, текстовыми рамками и текстовыми контейнерами.

{{% alert color="primary" %}}

Посмотрите приложение [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx):

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Это приложение построено на основе **Aspose.Slides API**, поэтому вы увидите рабочий пример базовых возможностей конвертации PPT в PPTX. Aspose.Slides Conversion — веб‑приложение, позволяющее загрузить файл презентации в формате PPT и скачать его в формате PPTX.

Найдите другие живые примеры [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) .

{{% /alert %}}

## **Преобразовать PPT в PPTX**

Чтобы преобразовать PPT в PPTX, просто передайте имя файла и формат сохранения в метод [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) класса [**Presentation**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). Пример кода на Python ниже преобразует презентацию из PPT в PPTX, используя параметры по умолчанию.
```python
import aspose.slides as slides

# Создайте объект Presentation, представляющий файл PPT
pres = slides.Presentation("PPTtoPPTX.ppt")

# Сохраните презентацию в формате PPTX
pres.save("PPTtoPPTX_out.pptx", slides.export.SaveFormat.PPTX)
```


Подробнее о форматах презентаций [**PPT vs PPTX**](/slides/ru/python-net/ppt-vs-pptx/) и о том, как [**Aspose.Slides supports PPT to PPTX conversion**](/slides/ru/python-net/convert-ppt-to-pptx/).

## **FAQ**

**В чём разница между форматами PPT и PPTX?**

PPT — старый двоичный формат файла, используемый Microsoft PowerPoint, тогда как PPTX — новый XML‑основной формат, появившийся в Microsoft Office 2007. Файлы PPTX обеспечивают лучшую производительность, меньший размер и более надёжное восстановление данных.

**Можно ли конвертировать PPT в PPTX с помощью Python?**

Да, используя библиотеку Aspose.Slides for Python via .NET, вы можете легко загрузить файл PPT и сохранить его в формате PPTX за несколько строк кода.

**Поддерживает ли Aspose.Slides пакетную конвертацию нескольких файлов PPT в PPTX?**

Да, вы можете использовать Aspose.Slides в цикле для программного преобразования множества файлов PPT в PPTX, что подходит для пакетных сценариев.

**Сохранится ли содержимое и форматирование после конвертации?**

Aspose.Slides сохраняет высокую точность при конвертации презентаций. Макеты слайдов, анимации, фигуры, диаграммы и другие элементы дизайна сохраняются при преобразовании PPT в PPTX.

**Можно ли конвертировать другие форматы, такие как PDF или HTML, из файлов PPT?**

Да, Aspose.Slides поддерживает конвертацию PPT в различные форматы, включая PDF, XPS, HTML, ODP и графические форматы, такие как PNG и JPEG.

**Можно ли конвертировать PPT в PPTX без установленного Microsoft PowerPoint?**

Да, Aspose.Slides for Python via .NET — это автономный API, не требующий Microsoft PowerPoint или стороннего программного обеспечения для выполнения конвертации.

**Есть ли онлайн‑инструмент для конвертации PPT в PPTX?**

Да, вы можете воспользоваться бесплатным веб‑приложением [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) для выполнения конвертации напрямую в браузере без написания кода.
