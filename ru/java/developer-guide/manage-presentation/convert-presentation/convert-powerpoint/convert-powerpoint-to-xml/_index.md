---
title: Преобразовать презентации PowerPoint в XML на Java
linktitle: PowerPoint в XML
type: docs
weight: 145
url: /ru/java/convert-powerpoint-to-xml/
keywords:
- конвертировать PowerPoint в XML
- конвертировать презентацию в XML
- PPT в XML
- PPTX в XML
- ODP в XML
- презентация PowerPoint XML
- SaveFormat.Xml
- сохранить презентацию как XML
- экспортировать презентацию в XML
- XML поток
- Java
- Aspose.Slides
description: "Преобразуйте презентации PowerPoint и OpenDocument в файлы PowerPoint XML или потоки на Java с помощью Aspose.Slides для Java."
---
## **Обзор**

Aspose.Slides for Java может конвертировать презентации PowerPoint в формат PowerPoint XML Presentation. XML‑вывод полезен, когда требуется текстовое представление для проверки структуры презентации, устранения неполадок сгенерированных документов, сравнения вывода в автоматических тестах или интеграции с процессом, который использует XML вместо пакета презентации.

Используйте метод [Presentation.save](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#save-java.lang.String-int-) с значением `Xml` из класса [SaveFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/saveformat/). Вы можете записать результат непосредственно в файл или в поток.

{{% alert color="info" title="Note" %}}

`SaveFormat.Xml` создает PowerPoint XML Presentation. Он не извлекает отдельные части Office Open XML, хранящиеся внутри пакета PPTX. Если вам нужны точные части пакета PPTX, такие как `ppt/presentation.xml` или отдельные XML‑файлы слайда, исследуйте сам пакет PPTX.

{{% /alert %}}

## **Конвертировать презентацию в XML‑файл**

Загрузите исходную презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/) и затем передайте путь вывода и `SaveFormat.Xml` методу [Presentation.save](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Источник может быть в любом формате презентации, поддерживаемом для загрузки, например PPT, PPTX или ODP.

Следующий пример конвертирует презентацию PPTX в XML‑файл:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.xml", SaveFormat.Xml);
} finally {
    presentation.dispose();
}
```

## **Записать XML‑вывод в поток**

Используйте перегрузку метода [Presentation.save](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) с параметром потока, когда XML должен оставаться в памяти или передаваться другому компоненту, такому как веб‑служба, поставщик хранилища или конвейер обработки XML. Следующий пример записывает результат в [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) и получает полученный XML в виде массива байтов:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try (ByteArrayOutputStream xmlStream = new ByteArrayOutputStream()) {
    presentation.save(xmlStream, SaveFormat.Xml);
    byte[] xmlData = xmlStream.toByteArray();

    // Передайте xmlData следующему компоненту в рабочем процессе.
} finally {
    presentation.dispose();
}
```

## **Сравнение XML с форматами презентаций и экспорта**

Выберите формат вывода в зависимости от того, как будет использоваться результат:

| Формат | Вывод | Типичное использование |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML Presentation | Проверка структуры, устранение неполадок, сравнение сгенерированного вывода и интеграция на основе XML |
| PPT (`.ppt`) | Унаследованный бинарный файл презентации | Совместимость со старыми рабочими процессами PowerPoint |
| PPTX (`.pptx`) | Пакет Office Open XML, содержащий несколько частей | Обычное редактирование и обмен презентациями PowerPoint |
| PDF or TIFF | Страницы фиксированного макета или многостраничное изображение | Просмотр, печать и архивирование |
| PNG, JPEG, or SVG | Визуальное представление отдельного слайда | Миниатюры, предварительные просмотры и графические ресурсы |
| HTML or HTML5 | Веб‑ориентированный вывод презентации | Просмотр в браузере и публикация в интернете |

В отличие от PPT и PPTX, XML‑вывод предназначен в первую очередь для инспекции и рабочих процессов, ориентированных на данные. В отличие от PDF, TIFF, HTML и форматов изображений слайдов, он представляет данные презентации, а не рендерит слайды в виде страниц или визуальных ресурсов. Таблица [supported file formats](/slides/ru/java/supported-file-formats/) перечисляет все форматы, которые Aspose.Slides может загружать, импортировать, сохранять или рендерить.

## **Вопросы и ответы**

**Это `SaveFormat.Xml` то же самое, что сохранение файла PPTX?**

Нет. PPTX — это пакет, содержащий несколько частей Office Open XML, тогда как `SaveFormat.Xml` создаёт файл PowerPoint XML Presentation.

**Могу ли я сохранить XML‑вывод, не создавая файл на диске?**

Да. Передайте записываемый поток в метод [Presentation.save](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-). Например, используйте [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) для обработки в памяти.

**Может ли Aspose.Slides загрузить экспортированный XML‑файл повторно?**

Да. Передайте XML‑файл или поток в конструктор [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#Presentation-java.lang.String-). Затем [Presentation.getSourceFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#getSourceFormat--) возвращает `SourceFormat.Xml`. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) сообщает `LoadFormat.Unknown` для этого формата, поэтому не используйте его для решения, можно ли открыть XML‑файл.

**Приводит ли преобразование в XML каждый слайд к странице или изображению?**

Нет. Преобразование в XML записывает структурированные данные презентации. Используйте PDF или TIFF для вывода, ориентированного на страницы, либо PNG, JPEG и SVG для изображений отдельных слайдов.