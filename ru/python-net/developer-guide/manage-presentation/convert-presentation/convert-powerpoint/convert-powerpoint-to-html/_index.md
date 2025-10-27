---
title: Конвертировать презентации PowerPoint в HTML на Python
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
description: "Конвертируйте презентации PowerPoint в адаптивный HTML на Python. Сохраняйте макет, ссылки и изображения с помощью руководства по конвертации Aspose.Slides для быстрых и безошибочных результатов."
---

## **Обзор**

В этой статье описывается, как конвертировать презентацию PowerPoint в формат HTML с помощью Python. Рассматриваются следующие темы.

- Конвертация PowerPoint в HTML на Python
- Конвертация PPT в HTML на Python
- Конвертация PPTX в HTML на Python
- Конвертация ODP в HTML на Python
- Конвертация слайда PowerPoint в HTML на Python

## **Python PowerPoint в HTML**

Для примера кода на Python по конвертации PowerPoint в HTML см. раздел ниже — [Convert PowerPoint to HTML](#convert-powerpoint-to-html). Код может загружать различные форматы, такие как PPT, PPTX и ODP, в объект Presentation и сохранять его в формате HTML.

## **О конвертации PowerPoint в HTML**
С помощью [**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/python-net/), приложения и разработчики могут конвертировать презентацию PowerPoint в HTML: **PPTX в HTML** или **PPT в HTML**. 

**Aspose.Slides** предоставляет множество параметров (в основном из класса [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/)), определяющих процесс конвертации PowerPoint в HTML:

* Конвертировать всю презентацию PowerPoint в HTML.
* Конвертировать конкретный слайд презентации PowerPoint в HTML.
* Конвертировать медиа‑файлы презентации (изображения, видео и т. д.) в HTML.
* Конвертировать презентацию PowerPoint в адаптивный HTML. 
* Конвертировать презентацию PowerPoint в HTML с включёнными или исключёнными заметками докладчика. 
* Конвертировать презентацию PowerPoint в HTML с включёнными или исключёнными комментариями. 
* Конвертировать презентацию PowerPoint в HTML с оригинальными или встроенными шрифтами. 
* Конвертировать презентацию PowerPoint в HTML, используя новый стиль CSS. 

{{% alert color="primary" %}} 

С помощью собственного API Aspose разработал бесплатные конвертеры [презентации в HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html): [PPT в HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX в HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP в HTML](https://products.aspose.app/slides/conversion/odp-to-html) и т. д. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Вы также можете ознакомиться с другими [бесплатными конвертерами от Aspose](https://products.aspose.app/slides/conversion).

{{% /alert %}} 

{{% alert title="Примечание" color="warning" %}} 

Помимо описанных здесь процессов конвертации, Aspose.Slides поддерживает также следующие операции, связанные с форматом HTML: 

* [HTML в изображение](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTML в JPG](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTML в XML](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTML в TIFF](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)

{{% /alert %}}

## **Конвертация PowerPoint в HTML**
С помощью Aspose.Slides вы можете конвертировать всю презентацию PowerPoint в HTML следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Вызовите метод [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) для сохранения объекта в виде HTML‑файла.

Пример кода, показывающий, как конвертировать PowerPoint в HTML на Python:

```python
import aspose.slides as slides

# Создаём объект Presentation, представляющий файл презентации
pres = slides.Presentation("Convert_HTML.pptx")

options = slides.export.HtmlOptions()

options.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL
options.html_formatter = slides.export.HtmlFormatter.create_document_formatter("", False)

# Сохраняем презентацию в HTML
pres.save("ConvertWholePresentationToHTML_out.html", slides.export.SaveFormat.HTML, options)
```

## **Конвертация PowerPoint в адаптивный HTML**

Aspose.Slides предоставляет класс [ResponsiveHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/responsivehtmlcontroller/), позволяющий генерировать адаптивные HTML‑файлы. Этот код показывает, как конвертировать презентацию PowerPoint в адаптивный HTML на Python:

```py
# Создаём объект Presentation, представляющий файл презентации
import aspose.slides as slides

pres = slides.Presentation("Convert_HTML.pptx")

controller = slides.export.ResponsiveHtmlController()
htmlOptions = slides.export.HtmlOptions()
htmlOptions.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

# Сохраняем презентацию в HTML
pres.save("ConvertPresentationToResponsiveHTML_out.html", slides.export.SaveFormat.HTML, htmlOptions)
```

## **Конвертация PowerPoint в HTML с заметками**
Этот код показывает, как конвертировать PowerPoint в HTML с включёнными заметками на Python:

```py
import aspose.slides as slides

pres = slides.Presentation("Presentation.pptx")

opt = slides.export.HtmlOptions()
opt.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

pres.save("Output.html", slides.export.SaveFormat.HTML, opt)
```

## **Конвертация PowerPoint в HTML с оригинальными шрифтами**
Aspose.Slides предоставляет класс [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/), позволяющий внедрять все шрифты презентации при её конвертации в HTML.

Чтобы исключить из внедрения определённые шрифты, можно передать массив имён шрифтов в параметризированный конструктор класса [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/). Популярные шрифты, такие как Calibri или Arial, обычно уже присутствуют в системе и не требуют внедрения. Их внедрение лишь увеличивает размер итогового HTML‑документа.

Класс [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) поддерживает наследование и предоставляет метод `WriteFont`, который следует переопределять. 

```py
import aspose.slides as slides

pres = slides.Presentation("input.pptx")

# исключаем шрифты по умолчанию
fontNameExcludeList = ["Calibri", "Arial"]

htmlOptionsEmbed = slides.export.HtmlOptions()
htmlOptionsEmbed.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(slides.export.EmbedAllFontsHtmlController(fontNameExcludeList))

pres.save("input-PFDinDisplayPro-Regular-installed.html", slides.export.SaveFormat.HTML, htmlOptionsEmbed)
```

## **Конвертация слайда в HTML**
Конвертировать отдельный слайд презентации в HTML можно, используя тот же метод — [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), который применяется для конвертации всей презентации PPT(X) в HTML‑документ. При этом можно также задать дополнительные параметры конвертации через класс [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/):

```py
# [TODO[not_supported_yet]: python implementation of .net interface]
```

## **Сохранение CSS и изображений при экспорте в HTML**
С помощью новых файлов стилей CSS вы можете легко менять внешний вид HTML‑файла, полученного в результате конвертации PowerPoint в HTML. 

Python‑код ниже показывает, как использовать переопределяемые методы для создания собственного HTML‑документа со ссылкой на файл CSS:

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

## **Связывание всех шрифтов при конвертации презентации в HTML**
Если вы не хотите внедрять шрифты (чтобы не увеличивать размер итогового HTML), вы можете связать все шрифты, реализовав собственную версию `LinkAllFontsHtmlController`. 

Этот Python‑код демонстрирует, как конвертировать PowerPoint в HTML, связывая все шрифты и исключая «Calibri» и «Arial» (так как они уже присутствуют в системе):

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

## **Поддержка свойства SVG Responsive**
Ниже приведён пример кода, показывающий, как экспортировать презентацию PPT(X) в HTML с адаптивным макетом:

```py
presentation = slides.Presentation("SomePresentation.pptx")

saveOptions = slides.export.HtmlOptions()
saveOptions.svg_responsive_layout = True

presentation.save("SomePresentation-out.html", slides.export.SaveFormat.HTML, saveOptions)
```

## **Экспорт медиа‑файлов в HTML**
С помощью Aspose.Slides for Python вы можете экспортировать медиа‑файлы следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд.
1. Добавьте видео на слайд.
1. Запишите презентацию в виде HTML‑файла.

Пример кода на Python, показывающий, как добавить видео в презентацию и затем сохранить её как HTML:

```py
import aspose.slides as slides

# Загружаем презентацию
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

### **Как конвертировать презентацию PowerPoint в HTML с помощью Python?**

Вы можете использовать библиотеку Aspose.Slides for Python via .NET для загрузки файлов PPT, PPTX или ODP и конвертации их в HTML с помощью метода `save()` и параметра `SaveFormat.HTML`.

### **Поддерживает ли Aspose.Slides конвертацию отдельных слайдов PowerPoint в HTML?**

Да, Aspose.Slides позволяет конвертировать как всю презентацию, так и отдельные слайды в HTML, настраивая `HtmlOptions` соответствующим образом.

### **Можно ли генерировать адаптивный HTML из презентаций PowerPoint?**

Да, с помощью класса `ResponsiveHtmlController` вы можете экспортировать презентацию в адаптивный HTML‑макет, который подстраивается под разные размеры экрана.

### **Можно ли включить заметки докладчика или комментарии в экспортированный HTML?**

Да, можно настроить `HtmlOptions` для включения или исключения заметок докладчика и комментариев при экспорте презентаций PowerPoint в HTML.

### **Можно ли внедрять шрифты при конвертации презентации в HTML?**

Да, Aspose.Slides предоставляет класс `EmbedAllFontsHtmlController`, позволяющий внедрять шрифты или исключать определённые шрифты для уменьшения размера выходного файла.

### **Поддерживает ли конвертация PowerPoint в HTML медиа‑файлы, такие как видео и аудио?**

Да, Aspose.Slides позволяет экспортировать медиаконтент, внедрённый в слайды, в HTML с помощью `VideoPlayerHtmlController` и связанных классов конфигурации.

### **Какие форматы файлов поддерживаются для конвертации в HTML?**

Aspose.Slides поддерживает конвертацию форматов презентаций PPT, PPTX и ODP в HTML. Он также позволяет сохранять содержимое слайда как SVG и экспортировать медиа‑ресурсы.

### **Можно ли избежать внедрения шрифтов, чтобы уменьшить размер HTML‑вывода?**

Да, вы можете связать часто используемые системные шрифты, такие как Arial или Calibri, вместо их внедрения, реализовав собственную версию `HtmlController`.

### **Есть ли онлайн‑инструмент для конвертации PowerPoint в HTML?**

Да, вы можете воспользоваться бесплатными веб‑инструментами Aspose, например [PPT в HTML](https://products.aspose.app/slides/conversion/ppt-to-html) или [PPTX в HTML](https://products.aspose.app/slides/conversion/pptx-to-html), чтобы конвертировать презентации прямо в браузере без написания кода.

### **Можно ли использовать собственные стили CSS в экспортированном HTML‑файле?**

Да, Aspose.Slides позволяет привязывать внешние CSS‑файлы во время конвертации, что даёт возможность полностью настраивать внешний вид полученного HTML‑контента.