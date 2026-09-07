---
title: Конвертация презентаций PowerPoint в XML на Python через Java
linktitle: PowerPoint в XML
type: docs
weight: 145
url: /ru/python-java/convert-powerpoint-to-xml/
keywords:
- конвертировать PowerPoint в XML
- конвертировать презентацию в XML
- PPT в XML
- PPTX в XML
- ODP в XML
- Презентация PowerPoint XML
- SaveFormat.Xml
- сохранить презентацию как XML
- экспортировать презентацию в XML
- поток XML
- Python
- Java
- Aspose.Slides
description: "Конвертируйте презентации PowerPoint и OpenDocument в файлы PowerPoint XML или потоки на Python через Java с использованием Aspose.Slides for Python via Java."
---
## **Обзор**

Aspose.Slides for Python via Java может конвертировать презентации PowerPoint в формат PowerPoint XML Presentation. XML‑вывод полезен, когда требуется текстовое представление для инспекции структуры презентации, устранения проблем с сгенерированными документами, сравнения результатов в автоматических тестах или интеграции с рабочим процессом, использующим XML вместо пакета презентации.

Используйте метод [Presentation.save](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#save) со значением [Xml](https://reference.aspose.com/slides/ru/python-java/aspose.slides/saveformat/#Xml) из класса [SaveFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/saveformat/). Вы можете записать результат непосредственно в файл или в поток.

{{% alert color="info" title="Note" %}}

[SaveFormat.Xml](https://reference.aspose.com/slides/ru/python-java/aspose.slides/saveformat/#Xml) создаёт PowerPoint XML Presentation. Он не извлекает отдельные части Office Open XML, хранящиеся внутри пакета PPTX. Если нужны точные части пакета PPTX, такие как `ppt/presentation.xml` или отдельные XML‑файлы слайда, исследуйте сам пакет PPTX.

{{% /alert %}}

## **Конвертировать презентацию в XML‑файл**

Загрузите исходную презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) и затем передайте путь вывода и [SaveFormat.Xml](https://reference.aspose.com/slides/ru/python-java/aspose.slides/saveformat/#Xml) в [Presentation.save](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#save). Источником может быть любой поддерживаемый формат, например PPT, PPTX или ODP.

Следующий пример конвертирует презентацию PPTX в XML‑файл:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.xml", SaveFormat.Xml)
finally:
    presentation.dispose()
```

## **Записать XML‑вывод в поток**

Используйте перегрузку метода [Presentation.save](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#save) для записи в поток, когда XML должен оставаться в памяти или передаваться другому компоненту, например веб‑службе, поставщику хранилища или XML‑конвейеру обработки. В следующем примере результат записывается в [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) и получается в виде объекта Python bytes:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

presentation = Presentation("presentation.pptx")
try:
    xml_stream = ByteArrayOutputStream()
    try:
        presentation.save(xml_stream, SaveFormat.Xml)
        java_bytes = xml_stream.toByteArray()
        xml_data = bytes(java_bytes)

        # Передайте xml_data следующему компоненту в рабочем процессе.
    finally:
        xml_stream.close()
finally:
    presentation.dispose()
```

## **Сравнение XML с форматами презентаций и экспортными форматами**

Выберите формат вывода в зависимости от того, как результат будет использоваться:

| Формат | Вывод | Обычное использование |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Презентация PowerPoint XML | Инспектирование структуры, устранение неполадок, сравнение сгенерированного вывода и интеграция на основе XML |
| PPT (`.ppt`) | Устаревший бинарный файл презентации | Совместимость со старыми рабочими процессами PowerPoint |
| PPTX (`.pptx`) | Пакет Office Open XML, содержащий несколько частей | Обычное редактирование PowerPoint и обмен презентациями |
| PDF или TIFF | Фиксированные страницы или многостраничное изображение | Просмотр, печать и архивирование |
| PNG, JPEG или SVG | Визуальное представление отдельного слайда | Миниатюры, предварительные просмотры и графические ресурсы |
| HTML или HTML5 | Веб‑ориентированный вывод презентации | Просмотр в браузере и публикация в интернете |

В отличие от PPT и PPTX, XML‑вывод в первую очередь предназначен для инспекции и обработки данных. В отличие от PDF, TIFF, HTML и форматов изображений слайдов, он представляет данные презентации, а не рендерит слайды как страницы или визуальные ресурсы. Таблица [supported file formats](/slides/ru/python-java/supported-file-formats/) указывает PowerPoint XML Presentation как формат только для сохранения, поэтому не используйте его, если рабочий процесс требует загрузки экспортированного файла обратно в Aspose.Slides для дальнейшего редактирования.

## **Вопросы и ответы**

**Экспорт XML одинаков ли с сохранением файла PPTX?**

Нет. PPTX — это пакет, содержащий несколько частей Office Open XML, тогда как [SaveFormat.Xml](https://reference.aspose.com/slides/ru/python-java/aspose.slides/saveformat/#Xml) создаёт файл PowerPoint XML Presentation.

**Можно ли сохранить XML‑вывод без создания файла на диске?**

Да. Передайте записываемый Java‑поток вывода в [Presentation.save](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#save). Например, используйте [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) для обработки в памяти.

**Может ли Aspose.Slides загрузить экспортированный XML‑файл снова?**

Нет. PowerPoint XML Presentation в текущий момент поддерживается только для сохранения, но не для загрузки. Используйте PPTX или другой поддерживаемый формат презентации, если требуется обратная совместимость редактирования.

**Проводит ли XML‑конверсия рендеринг каждого слайда как страницы или изображения?**

Нет. Конверсия в XML записывает структурированные данные презентации. Для вывода, ориентированного на страницы, используйте PDF или TIFF, а для отдельных изображений слайдов — PNG, JPEG или SVG.