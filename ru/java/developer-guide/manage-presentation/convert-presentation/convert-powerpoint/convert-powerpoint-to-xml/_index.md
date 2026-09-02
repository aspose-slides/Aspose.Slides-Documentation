---
title: Конвертация презентаций PowerPoint в XML на Java
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
- Презентация PowerPoint XML
- SaveFormat.Xml
- сохранить презентацию как XML
- экспортировать презентацию в XML
- XML поток
- Java
- Aspose.Slides
description: "Конвертируйте презентации PowerPoint и OpenDocument в файлы PowerPoint XML или потоки на Java с помощью Aspose.Slides for Java."
---
## **Обзор**

Aspose.Slides for Java может конвертировать презентации PowerPoint в формат PowerPoint XML Presentation. XML‑вывод полезен, когда вам нужен текстовый представление для инспекции структуры презентации, отладки сгенерированных документов, сравнения вывода в автоматических тестах или интеграции с рабочим процессом, который потребляет XML вместо пакета презентаций.

Используйте метод [Presentation.save](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#save-java.lang.String-int-) с параметром `Xml` из класса [SaveFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/saveformat/). Вы можете записать результат напрямую в файл или в поток.

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` создаёт PowerPoint XML Presentation. Он не извлекает отдельные части Office Open XML, хранящиеся внутри пакета PPTX. Если вам нужны точные части пакета PPTX, такие как `ppt/presentation.xml` или отдельные XML‑файлы слайдов, изучите сам пакет PPTX.
{{% /alert %}}

## **Преобразовать презентацию в XML‑файл**

Загрузите исходную презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/) , а затем передайте путь вывода и `SaveFormat.Xml` методу [Presentation.save](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Источник может быть в любом поддерживаемом формате загрузки, таком как PPT, PPTX или ODP.

В следующем примере PPTX‑презентация конвертируется в XML‑файл:

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

Используйте перегрузку метода [Presentation.save](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-), принимающую поток, когда XML должен оставаться в памяти или передаваться другому компоненту, например веб‑сервису, поставщику хранилища или XML‑конвейеру обработки. В следующем примере результат записывается в [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) и полученный XML возвращается в виде массива байтов:

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

| Формат | Вывод | Типичное применение |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Презентация PowerPoint XML | Инспекция структуры, отладка, сравнение сгенерированного вывода и интеграция на основе XML |
| PPT (`.ppt`) | Файл презентации в старом двоичном формате | Совместимость со старыми рабочими процессами PowerPoint |
| PPTX (`.pptx`) | Пакет Office Open XML, содержащий несколько частей | Обычное редактирование PowerPoint и обмен презентациями |
| PDF или TIFF | Страницы фиксированного макета или многостраничное изображение | Просмотр, печать и архивация |
| PNG, JPEG или SVG | Отображаемое представление отдельного слайда | Эскизы, превью и графические ресурсы |
| HTML или HTML5 | Web‑ориентированный вывод презентации | Просмотр в браузере и публикация в вебе |

В отличие от PPT и PPTX, XML‑вывод в первую очередь предназначен для инспекции и работы с данными. В отличие от PDF, TIFF, HTML и форматов изображений слайдов, он представляет данные презентации, а не рендерит слайды в виде страниц или визуальных ресурсов. В таблице [supported file formats](/slides/ru/java/supported-file-formats/) указано, что PowerPoint XML Presentation поддерживается только для сохранения, поэтому не используйте его, если рабочий процесс требует загрузки экспортированного файла обратно в Aspose.Slides для дальнейшего редактирования.

## **FAQ**

**`SaveFormat.Xml` то же самое, что сохранение файла PPTX?**

Нет. PPTX — это пакет, содержащий несколько частей Office Open XML, тогда как `SaveFormat.Xml` создает файл PowerPoint XML Presentation.

**Можно ли сохранить XML‑вывод без создания файла на диске?**

Да. Передайте поток для записи в метод [Presentation.save](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-). Например, используйте [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) для обработки в памяти.

**Может ли Aspose.Slides загрузить экспортированный XML‑файл снова?**

Нет. PowerPoint XML Presentation в текущей версии поддерживается только для сохранения, а не для загрузки. Используйте PPTX или другой поддерживаемый формат презентации, когда требуется круговая обработка (загрузка‑сохранение) редактирования.

**Преобразует ли XML каждый слайд в страницу или изображение?**

Нет. Конвертация в XML записывает структурированные данные презентации. Для вывода, ориентированного на страницы, используйте PDF или TIFF, а для отдельных изображений слайдов — PNG, JPEG и SVG.