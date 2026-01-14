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
- внешнее связанное изображение
- Python
- Aspose.Slides
description: "Узнайте, как экспортировать презентации в HTML с внешними связанными изображениями в Aspose.Slides для Python через .NET, охватывая форматы PowerPoint и OpenDocument."
---

{{% alert color="primary" %}} 

Процесс экспорта презентации в HTML позволяет указать:

1. какие ресурсы встраиваются в получающийся HTML‑файл, и
1. какие ресурсы сохраняются внешне и ссылаются из HTML‑файла.

{{% /alert %}} 

## **Общие сведения**

По умолчанию экспорт HTML встраивает все ресурсы напрямую в HTML с помощью кодирования Base64. Это создаёт один самодостаточный HTML‑файл, удобный для просмотра и распространения. Однако у этого подхода есть недостатки:

* Получающийся файл значительно больше исходных ресурсов из‑за накладных расходов Base64.
* Встроенные изображения и другие активы трудно обновлять или заменять.

## **Альтернативный подход**

Альтернативный подход с использованием [ILinkEmbedController](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/) устраняет эти ограничения.

Класс `LinkController` ниже реализует [ILinkEmbedController](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/) и передаётся конструктору [HtmlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/__init__/#ilinkembedcontroller). Класс предоставляет три метода, которые управляют тем, как ресурсы встраиваются или связываются во время экспорта HTML:

[get_object_storing_location(id, entity_data, semantic_name, content_type, recommended_extension)](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/get_object_storing_location/#int-bytes-str-str-str): Вызывается, когда экспортер встречает ресурс и должен решить, где его сохранить. Наиболее важные параметры — `id` (уникальный идентификатор ресурса для данного запуска экспорта) и `content_type` (тип MIME ресурса). Возвратите [LinkEmbedDecision.LINK](https://reference.aspose.com/slides/python-net/aspose.slides.export/linkembeddecision/) чтобы связать ресурс, или [LinkEmbedDecision.EMBED](https://reference.aspose.com/slides/python-net/aspose.slides.export/linkembeddecision/) чтобы встроить его.

[get_url(id, referrer)](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/get_url/#int-int): Возвращает URL, который будет отображаться в результирующем HTML для ресурса, идентифицированного `id` (при необходимости с учётом объекта‑реферера).

[save_external(id, entity_data)](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/save_external/#int-bytes): Вызывается, когда ресурс, выбранный для ссылки, необходимо записать во внешнее хранилище. Поскольку идентификатор и содержимое предоставлены (в виде массива байтов), вы можете сохранять ресурс любым удобным способом.

Ниже представлена реализация Python‑класса `LinkController` интерфейса [ILinkEmbedController](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/).
```py
# [TODO[not_supported_yet]: реализация .NET интерфейсов на python]
```


После реализации класса `LinkController` вы можете использовать его с классом [HtmlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/htmloptions/) для экспорта презентации в HTML с внешними ссылками на изображения, как показано ниже:
```py
# [TODO[not_supported_yet]: реализация .NET интерфейсов на python]
```


Мы присвоили `SlideImageFormat.SVG` свойству `slide_image_format`, чтобы результирующий HTML‑файл содержал SVG‑данные для отображения содержимого презентации.

Типы содержимого: если презентация содержит растровые битмапы, код класса должен быть готов обрабатывать типы содержимого `image/jpeg` и `image/png`. Содержимое экспортируемых изображений может отличаться от того, что хранится в презентации. Внутренние алгоритмы Aspose.Slides выполняют оптимизацию размеров и используют кодек JPEG или PNG (в зависимости от того, какой даёт меньший размер файла). Изображения с альфа‑каналом (прозрачность) всегда кодируются как PNG.