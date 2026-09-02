---
title: Преобразование презентаций PowerPoint в XML на Android
linktitle: PowerPoint в XML
type: docs
weight: 145
url: /ru/androidjava/convert-powerpoint-to-xml/
keywords:
- преобразовать PowerPoint в XML
- преобразовать презентацию в XML
- PPT в XML
- PPTX в XML
- ODP в XML
- PowerPoint XML Presentation
- SaveFormat.Xml
- сохранить презентацию как XML
- экспортировать презентацию в XML
- XML поток
- Android
- Java
- Aspose.Slides
description: "Преобразуйте презентации PowerPoint и OpenDocument в файлы или потоки PowerPoint XML на Android с помощью Aspose.Slides."
---
## **Обзор**

Aspose.Slides for Android via Java может преобразовывать презентации PowerPoint в формат PowerPoint XML Presentation. Вывод в XML полезен, когда нужен текстовый представление для анализа структуры презентации, отладки сгенерированных документов, сравнения результатов в автоматических тестах или интеграции с процессом, который использует XML вместо пакета презентации.

Используйте метод [Presentation.save](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) с [SaveFormat.Xml](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/saveformat/#Xml). Вы можете записать результат напрямую в файл или в поток.

{{% alert color="info" title="Примечание" %}}

`SaveFormat.Xml` создаёт PowerPoint XML Presentation. Он не извлекает отдельные части Office Open XML, хранящиеся внутри пакета PPTX. Если вам нужны точные части пакета PPTX, такие как `ppt/presentation.xml` или отдельные XML‑файлы слайдов, изучайте сам пакет PPTX.

{{% /alert %}}

## **Преобразовать презентацию в XML‑файл**

Загрузите исходную презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/) и передайте путь вывода и [SaveFormat.Xml](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/saveformat/#Xml) в метод [Presentation.save](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). Источником может быть любой поддерживаемый формат загрузки, например PPT, PPTX или ODP.

Следующий пример преобразует презентацию PPTX в XML‑файл:

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

Используйте перегрузку метода [Presentation.save](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) с потоком, когда XML‑данные должны оставаться в памяти или передаваться другому компоненту, например веб‑службе, хранилищу или конвейеру обработки XML. В следующем примере результат записывается в [ByteArrayOutputStream](https://developer.android.com/reference/java/io/ByteArrayOutputStream) и получаем сгенерированный XML как массив байтов:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ByteArrayOutputStream xmlStream = new ByteArrayOutputStream();
    try {
        presentation.save(xmlStream, SaveFormat.Xml);
        byte[] xmlData = xmlStream.toByteArray();

        // Передайте xmlData следующему компоненту в рабочем процессе.
    } finally {
        xmlStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Сравнение XML с форматами презентаций и экспортными форматами**

Выбирайте формат вывода в зависимости от того, как будет использоваться результат:

| Формат | Вывод | Типичное использование |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Презентация PowerPoint XML | Анализ структуры, отладка, сравнение сгенерированного вывода и интеграция на основе XML |
| PPT (`.ppt`) | Унаследованный двоичный файл презентации | Совместимость со старыми рабочими процессами PowerPoint |
| PPTX (`.pptx`) | Пакет Office Open XML, содержащий несколько частей | Обычное редактирование PowerPoint и обмен презентациями |
| PDF или TIFF | Страницы фиксированного макета или многостраничное изображение | Просмотр, печать и архивирование |
| PNG, JPEG или SVG | Визуальное представление отдельного слайда | Миниатюры, предварительные просмотры и графические ресурсы |
| HTML или HTML5 | Вывод презентации, ориентированный на веб | Просмотр в браузере и публикация в интернете |

В отличие от PPT и PPTX, вывод в XML предназначен преимущественно для инспекции и рабочих процессов, ориентированных на данные. В отличие от PDF, TIFF, HTML и форматов изображений слайдов, он представляет данные презентации, а не рендерит слайды как страницы или визуальные ресурсы. Таблица [поддерживаемых форматов файлов](/slides/ru/androidjava/supported-file-formats/) перечисляет PowerPoint XML Presentation как формат только для сохранения, поэтому не используйте его, когда рабочий процесс требует загрузки экспортированного файла обратно в Aspose.Slides для дальнейшего редактирования.

## **Вопросы и ответы**

**Является ли `SaveFormat.Xml` тем же, что сохранение файла PPTX?**

Нет. PPTX — это пакет, содержащий несколько частей Office Open XML, тогда как `SaveFormat.Xml` создаёт файл PowerPoint XML Presentation.

**Можно ли сохранить XML‑вывод без создания файла на диске?**

Да. Передайте записываемый поток в метод [Presentation.save](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-). Например, используйте [ByteArrayOutputStream](https://developer.android.com/reference/java/io/ByteArrayOutputStream) для обработки в памяти.

**Может ли Aspose.Slides загрузить экспортированный XML‑файл снова?**

Нет. PowerPoint XML Presentation в текущий момент поддерживается только для сохранения, но не для загрузки. При необходимости круговой обработки используйте PPTX или другой поддерживаемый формат презентации.

**Преобразует ли XML каждый слайд в страницу или изображение?**

Нет. Преобразование в XML записывает структурированные данные презентации. Для вывода, ориентированного на страницы, используйте PDF или TIFF, а для изображений отдельных слайдов — PNG, JPEG или SVG.