---
title: Экспорт презентаций в HTML с внешними связанными изображениями на Python
linktitle: Экспорт презентаций в HTML с внешними связанными изображениями
type: docs
weight: 100
url: /ru/python-net/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- экспорт PowerPoint
- экспорт OpenDocument
- экспорт презентации
- экспорт слайда
- экспорт PPT
- экспорт PPTX
- экспорт ODP
- PowerPoint в HTML
- OpenDocument в HTML
- презентация в HTML
- слайд в HTML
- PPT в HTML
- PPTX в HTML
- ODP в HTML
- связанное изображение
- внешне связанное изображение
- Python
- Aspose.Slides
description: "Узнайте, как экспортировать презентации в HTML с внешними связанными изображениями в Aspose.Slides для Python через .NET, охватывая форматы PowerPoint и OpenDocument."
---

{{% alert color="primary" %}} 

Процесс экспорта презентации в HTML позволяет указать:

1. какие ресурсы встроены в результирующий HTML‑файл, и
1. какие ресурсы сохраняются внешне и ссылаются из HTML‑файла.

{{% /alert %}} 

## **Фон**

По умолчанию экспорт в HTML встраивает все ресурсы непосредственно в HTML с помощью кодирования Base64. Это создаёт один самодостаточный HTML‑файл, удобный для просмотра и распространения. Однако такой подход имеет недостатки:

* Полученный файл значительно больше оригинальных ресурсов из‑за накладных расходов Base64.
* Встроенные изображения и другие активы трудно обновлять или заменять.

## **Альтернативный подход**

Альтернативный подход с использованием [ILinkEmbedController](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/) устраняет эти ограничения.

Класс `LinkController`, приведённый ниже, реализует [ILinkEmbedController](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/) и передаётся конструктору [HtmlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/__init__/#ilinkembedcontroller). Класс предоставляет три метода, которые управляют тем, как ресурсы встраиваются или связываются во время экспорта в HTML:

[get_object_storing_location(id, entity_data, semantic_name, content_type, recommended_extension)](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/get_object_storing_location/#int-bytes-str-str-str): вызывается, когда экспортер встречает ресурс и должен решить, где его сохранить. Самыми важными параметрами являются `id` (уникальный идентификатор ресурса для данного запуска экспорта) и `content_type` (MIME‑тип ресурса). Верните [LinkEmbedDecision.LINK](https://reference.aspose.com/slides/python-net/aspose.slides.export/linkembeddecision/) для ссылки на ресурс или [LinkEmbedDecision.EMBED](https://reference.aspose.com/slides/python-net/aspose.slides.export/linkembeddecision/) для его встраивания.

[get_url(id, referrer)](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/get_url/#int-int): возвращает URL, который будет отображён в результирующем HTML для ресурса, идентифицируемого `id` (при необходимости учитывая объект‑реферер).

[save_external(id, entity_data)](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/save_external/#int-bytes): вызывается, когда выбранный для ссылки ресурс необходимо записать во внешнее хранилище. Поскольку идентификатор и содержимое предоставляются (в виде массива байтов), вы можете сохранять ресурс любым удобным способом.

Ниже приведена реализация `LinkController` на Python для [ILinkEmbedController](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/).
```py
# [TODO[not_supported_yet]: реализация .NET-интерфейсов на python]
```


После реализации класса `LinkController` его можно использовать вместе с классом [HtmlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) для экспорта презентации в HTML с внешними ссылками на изображения, как показано ниже:
```py
# [TODO[not_supported_yet]: реализация .NET-интерфейсов на python]
```


Мы присвоили `SlideImageFormat.SVG` свойству `slide_image_format`, чтобы результирующий HTML‑файл содержал данные SVG для визуализации содержимого презентации.

Типы контента: если презентация содержит растровые битмапы, код класса должен быть готов обрабатывать типы контента `image/jpeg` и `image/png`. Содержимое экспортированных битмап‑изображений может не совпадать с тем, что было сохранено в презентации. Внутренние алгоритмы Aspose.Slides выполняют оптимизацию размера и используют либо кодек JPEG, либо PNG (в зависимости от того, какой даёт меньший размер файла). Изображения с альфа‑каналом (прозрачностью) всегда кодируются как PNG.