---
title: Конвертировать презентации PowerPoint в HTML с помощью Python
linktitle: PowerPoint в HTML
type: docs
weight: 30
url: /ru/python-net/convert-powerpoint-to-html/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать слайд
- конвертировать PPT
- конвертировать PPTX
- PowerPoint в HTML
- презентацию в HTML
- слайд в HTML
- PPT в HTML
- PPTX в HTML
- сохранить PowerPoint как HTML
- сохранить презентацию как HTML
- сохранить слайд как HTML
- сохранить PPT как HTML
- сохранить PPTX как HTML
- Python
- Aspose.Slides
description: "Конвертировать презентации PowerPoint в адаптивный HTML с помощью Python. Сохраните макет, ссылки и изображения с руководством по конвертации Aspose.Slides для быстрой и безупречной работы."
---

## **Обзор**

Эта статья объясняет, как конвертировать презентацию PowerPoint в формат HTML с помощью Python. Она охватывает следующие темы.

- Конвертировать PowerPoint в HTML с помощью Python
- Конвертировать PPT в HTML с помощью Python
- Конвертировать PPTX в HTML с помощью Python
- Конвертировать ODP в HTML с помощью Python
- Конвертировать слайд PowerPoint в HTML с помощью Python

## **Python PowerPoint в HTML**

Для примера кода Python по конвертации PowerPoint в HTML см. раздел ниже, т.е. [Convert PowerPoint to HTML](#convert-powerpoint-to-html). Код может загружать несколько форматов, таких как PPT, PPTX и ODP, в объект Presentation и сохранять их в формате HTML.

## **О преобразовании PowerPoint в HTML**

С помощью [**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/python-net/), приложения и разработчики могут конвертировать презентацию PowerPoint в HTML: **PPTX в HTML** или **PPT в HTML**.  

Aspose.Slides предоставляет множество вариантов (в основном из класса [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) ), которые определяют процесс конвертации PowerPoint в HTML:

* Конвертировать всю презентацию PowerPoint в HTML.
* Конвертировать конкретный слайд презентации PowerPoint в HTML.
* Конвертировать медиа презентации (изображения, видео и т.д.) в HTML.
* Конвертировать презентацию PowerPoint в адаптивный HTML. 
* Конвертировать презентацию PowerPoint в HTML с включенными или исключенными примечаниями докладчика. 
* Конвертировать презентацию PowerPoint в HTML с включенными или исключенными комментариями. 
* Конвертировать презентацию PowerPoint в HTML с оригинальными или встроенными шрифтами. 
* Конвертировать презентацию PowerPoint в HTML с использованием нового CSS‑стиля. 

{{% alert color="primary" %}} 

С помощью собственного API Aspose разработала бесплатные конвертеры [presentation to HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html): [PPT to HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX to HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP to HTML](https://products.aspose.app/slides/conversion/odp-to-html), и т.д. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Возможно, вы захотите ознакомиться с другими [бесплатными конвертерами от Aspose](https://products.aspose.app/slides/conversion).

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

Кроме описанных здесь процессов конвертации, Aspose.Slides также поддерживает следующие операции преобразования, связанные с форматом HTML: 

* [HTML в изображение](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTML в JPG](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTML в XML](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTML в TIFF](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)

{{% /alert %}}

## **Конвертировать PowerPoint в HTML**

С помощью Aspose.Slides вы можете конвертировать всю презентацию PowerPoint в HTML следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
1. Используйте метод [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) чтобы сохранить объект в виде HTML‑файла.

Этот код показывает, как конвертировать PowerPoint в HTML на python:

```python
import aspose.slides as slides

# Создайте объект Presentation, представляющий файл презентации
pres = slides.Presentation("Convert_HTML.pptx")

options = slides.export.HtmlOptions()

options.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL
options.html_formatter = slides.export.HtmlFormatter.create_document_formatter("", False)

# Сохранение презентации в HTML
pres.save("ConvertWholePresentationToHTML_out.html", slides.export.SaveFormat.HTML, options)
```

## **Конвертировать PowerPoint в адаптивный HTML**

Aspose.Slides предоставляет класс [ResponsiveHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/responsivehtmlcontroller/) , который позволяет генерировать адаптивные HTML‑файлы. Этот код показывает, как конвертировать презентацию PowerPoint в адаптивный HTML на python:

```py
# Создайте объект Presentation, представляющий файл презентации
import aspose.slides as slides

pres = slides.Presentation("Convert_HTML.pptx")

controller = slides.export.ResponsiveHtmlController()
htmlOptions = slides.export.HtmlOptions()
htmlOptions.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

# Сохранение презентации в HTML
pres.save("ConvertPresentationToResponsiveHTML_out.html", slides.export.SaveFormat.HTML, htmlOptions)
```

## **Конвертировать PowerPoint в HTML с примечаниями**

Этот код показывает, как конвертировать PowerPoint в HTML с примечаниями на python:

```py
import aspose.slides as slides

pres = slides.Presentation("Presentation.pptx")

opt = slides.export.HtmlOptions()
opt.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

pres.save("Output.html", slides.export.SaveFormat.HTML, opt)
```

## **Конвертировать PowerPoint в HTML с оригинальными шрифтами**

Aspose.Slides предоставляет класс [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) , который позволяет встраивать все шрифты презентации при конвертации её в HTML.

Чтобы не встраивать определённые шрифты, можно передать массив имён шрифтов в параметризованный конструктор класса [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) . Популярные шрифты, такие как Calibri или Arial, когда используются в презентации, не обязаны встраиваться, поскольку большинство систем уже содержат их. Если такие шрифты встраиваются, получаемый HTML‑документ становится необязательно большим.

Класс [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) поддерживает наследование и предоставляет метод `WriteFont`, который предполагается переопределить. 

```py
import aspose.slides as slides

pres = slides.Presentation("input.pptx")

# исключить шрифты презентации по умолчанию
fontNameExcludeList = ["Calibri", "Arial"]

htmlOptionsEmbed = slides.export.HtmlOptions()
htmlOptionsEmbed.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(slides.export.EmbedAllFontsHtmlController(fontNameExcludeList))

pres.save("input-PFDinDisplayPro-Regular-installed.html", slides.export.SaveFormat.HTML, htmlOptionsEmbed)
```

## **Конвертировать слайд в HTML**

Конвертировать отдельный слайд презентации в HTML. Для этого используйте тот же метод [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) , который применяется для конвертации всей презентации PPT(X) в HTML‑документ. Класс [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) также можно использовать для задания дополнительных параметров конвертации:

```py
# [TODO[not_supported_yet]: реализация python интерфейса .net]
```

## **Сохранить CSS и изображения при экспорте в HTML**

С помощью новых CSS‑стилей вы можете легко изменить стиль HTML‑файла, полученного в результате конвертации PowerPoint в HTML. 

Python‑код в этом примере показывает, как использовать переопределяемые методы для создания пользовательского HTML‑документа со ссылкой на файл CSS:

```py
# [TODO[not_supported_yet]: реализация python интерфейса .net]
```

## **Связать все шрифты при конвертации презентации в HTML**

Если вы не хотите встраивать шрифты (чтобы не увеличивать размер получаемого HTML), можно связать все шрифты, реализовав собственную версию `LinkAllFontsHtmlController`. 

Этот python‑код показывает, как конвертировать PowerPoint в HTML, связывая все шрифты и исключая «Calibri» и «Arial» (поскольку они уже присутствуют в системе):

```py
# [TODO[not_supported_yet]: реализация python интерфейса .net]
```

## **Поддержка свойства SVG Responsive**

Ниже показан пример кода, который экспортирует презентацию PPT(X) в HTML с адаптивным макетом:

```py
presentation = slides.Presentation("SomePresentation.pptx")

saveOptions = slides.export.HtmlOptions()
saveOptions.svg_responsive_layout = True

presentation.save("SomePresentation-out.html", slides.export.SaveFormat.HTML, saveOptions)
```

## **Экспорт медиа‑файлов в HTML‑файл**

С помощью Aspose.Slides для python вы можете экспортировать медиа‑файлы следующим образом:

1. Создайте экземпляр класса [Presentation].
1. Получите ссылку на слайд.
1. Добавьте видео на слайд.
1. Сохраните презентацию как HTML‑файл.

Этот python‑код показывает, как добавить видео в презентацию и затем сохранить её в HTML:

```py
import aspose.slides as slides

# Загрузка презентации
presentation = slides.Presentation("Media File.pptx")

path = "C:\\"
fileName = "ExportMediaFiles_out.html"
baseUri = "http://www.example.com/"

controller = slides.export.VideoPlayerHtmlController(path, fileName, baseUri)

htmlOptions = slides.export.HtmlOptions(controller)
svgOptions = slides.export.SVGOptions(controller)

htmlOptions.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)
htmlOptions.slide_image_format = slides.export.SlideImageFormat.svg(svgOptions)

presentation.save(path + "ExportMediaFiles_out.html", slides.export.SaveFormat.HTML, htmlOptions)
```

## Часто задаваемые вопросы

### **Как я могу конвертировать презентацию PowerPoint в HTML с помощью Python?**

Вы можете использовать библиотеку Aspose.Slides for Python via .NET для загрузки файлов PPT, PPTX или ODP и конвертации их в HTML с помощью метода `save()` с параметром `SaveFormat.HTML`.

### **Поддерживает ли Aspose.Slides конвертацию отдельных слайдов PowerPoint в HTML?**

Да, Aspose.Slides позволяет конвертировать как всю презентацию, так и отдельные слайды в HTML, задав соответствующие параметры `HtmlOptions`.

### **Могу ли я генерировать адаптивный HTML из презентаций PowerPoint?**

Да, с помощью класса `ResponsiveHtmlController` вы можете экспортировать презентацию в адаптивный HTML‑макет, который подстраивается под различные размеры экрана.

### **Можно ли включить примечания докладчика или комментарии в экспортированный HTML?**

Да, вы можете настроить `HtmlOptions` для включения или исключения примечаний докладчика и комментариев при экспорте презентаций PowerPoint в HTML.

### **Могу ли я встраивать шрифты при конвертации презентации в HTML?**

Да, Aspose.Slides предоставляет класс `EmbedAllFontsHtmlController`, который позволяет встраивать шрифты или исключать определённые шрифты для уменьшения размера выходного файла.

### **Поддерживает ли конвертация PowerPoint в HTML медиа‑файлы, такие как видео и аудио?**

Да, Aspose.Slides позволяет экспортировать медиа‑контент, встроенный в слайды, в HTML с помощью `VideoPlayerHtmlController` и связанных классов конфигурации.

### **Какие форматы файлов поддерживаются для конвертации в HTML?**

Aspose.Slides поддерживает конвертацию форматов презентаций PPT, PPTX и ODP в HTML. Он также позволяет сохранять содержимое слайдов как SVG и экспортировать медиа‑ресурсы.

### **Можно ли избежать встраивания шрифтов, чтобы уменьшить размер HTML?**

Да, вы можете связать часто используемые системные шрифты, такие как Arial или Calibri, вместо их встраивания, реализовав собственную версию `HtmlController`.

### **Есть ли онлайн‑инструмент для конвертации PowerPoint в HTML?**

Да, вы можете попробовать бесплатные веб‑инструменты Aspose, такие как [PPT to HTML](https://products.aspose.app/slides/conversion/ppt-to-html) или [PPTX to HTML](https://products.aspose.app/slides/conversion/pptx-to-html), чтобы конвертировать презентации прямо в браузере без написания кода.

### **Могу ли я использовать пользовательские стили CSS в экспортированном HTML‑файле?**

Да, Aspose.Slides позволяет привязывать внешние CSS‑файлы во время конвертации, что даёт возможность полностью настроить внешний вид полученного HTML‑контента.