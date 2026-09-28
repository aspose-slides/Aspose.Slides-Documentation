---
title: Создание презентаций на Android
linktitle: Создать презентацию
type: docs
weight: 10
url: /ru/androidjava/create-presentation/
keywords:
- создать презентацию
- новая презентация
- создать PPT
- новый PPT
- создать PPTX
- новый PPTX
- создать ODP
- новый ODP
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Создавайте презентации на Java с помощью Aspose.Slides для Android — генерируйте файлы PPT, PPTX и ODP, получайте поддержку OpenDocument и сохраняйте их программно для надёжных результатов."
---
## **Обзор**

Эта статья показывает, как создать презентацию в Aspose.Slides для Android через Java, добавить текстовое поле на её первый слайд и сохранить результат в виде файла в хранилище вашего приложения. Чтобы открыть существующую презентацию или сохранить её в другом формате, см. [Открыть презентацию](/slides/ru/androidjava/open-presentation/) и [Сохранить презентацию](/slides/ru/androidjava/save-presentation/). В конце статьи приведён короткий FAQ, охватывающий часто задаваемые вопросы о форматах, шаблонах, размерах слайдов, единицах измерения, использовании памяти, многопоточности, лицензировании, цифровых подпях и поддержке VBA.

Прежде чем начать, добавьте Aspose.Slides в ваш Android‑проект из Maven‑репозитория Aspose. Смотрите [Установка](/slides/ru/androidjava/install-aspose-slides-for-android-via-java/).

## **Создание презентации PowerPoint**

Чтобы создать презентацию и разместить текстовое поле на её первом слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/). Новая презентация уже содержит один пустой слайд.
2. Получите этот слайд из [slide collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/) по его индексу 0.
3. Добавьте прямоугольник с помощью метода [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) коллекции [shape collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/) и задайте текст его [text frame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) через метод [setText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#setText-java.lang.String-).
4. Сохраните презентацию как файл PPTX с помощью метода [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) в формате [SaveFormat.Pptx](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveformat/).

Код выполняется внутри `Activity`, например в её методе `onCreate`. Файл сохраняется в каталог, возвращаемый методом [getFilesDir](https://developer.android.com/reference/android/content/Context#getFilesDir()), т.е. во внутреннее частное хранилище приложения, без необходимости запрашивать какие‑либо разрешения.

```java
import com.aspose.slides.*;
import java.io.File;

File outputFile = new File(getFilesDir(), "hello.pptx");

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Левый верхний угол прямоугольника находится на расстоянии 50 пунктов от левого края и 50 пунктов от верхнего края слайда; ширина прямоугольника — 400 пунктов, высота — 100 пунктов. Сохранённый файл содержит один слайд с этим прямоугольником и его текстом. Без лицензии Aspose.Slides также добавляет оценочный водяной знак к каждому сохраняемому слайду; см. [Лицензирование](/slides/ru/androidjava/licensing/).

Чтобы просмотреть файл, откройте [Device Explorer] в Android Studio и найдите *hello.pptx* в каталоге *data/data/* в папке *files* вашего приложения. В реальном приложении обрабатывайте презентации в фоновом потоке, чтобы пользовательский интерфейс оставался отзывчивым.

## **FAQ**

### Какие форматы доступны для сохранения новой презентации?

Можно сохранять в [PPTX, PPT и ODP](/slides/ru/androidjava/save-presentation/), а также экспортировать в [PDF](/slides/ru/androidjava/convert-powerpoint-to-pdf/), [XPS](/slides/ru/androidjava/convert-powerpoint-to-xps/), [HTML](/slides/ru/androidjava/convert-powerpoint-to-html/), [SVG](/slides/ru/androidjava/render-a-slide-as-an-svg-image/) и [изображения](/slides/ru/androidjava/convert-powerpoint-to-png/), и др.

### Можно ли начать с шаблона (POTX/POTM) и сохранить как обычный PPTX?

Да. Загрузите шаблон и сохраните в требуемый формат; форматы POTX/POTM/PPTM и аналогичные [поддерживаются](/slides/ru/androidjava/supported-file-formats/).

### Как управлять размером/соотношением сторон слайда при создании презентации?

Установите [размер слайда](/slides/ru/androidjava/slide-size/) (включая готовые варианты 4:3, 16:9 или пользовательские размеры) и задайте, как масштабировать содержимое.

### В каких единицах измеряются размеры и координаты?

В пунктах: 1 дюйм = 72 пункта.

### Как работать с очень большими презентациями (много медиа‑файлов), чтобы снизить расход памяти?

Используйте [стратегии управления BLOB](/slides/ru/androidjava/manage-blob/), ограничивайте хранение в памяти, используя временные файлы, и предпочтительно работайте с файловыми потоками вместо чисто оперативных.

### Можно ли создавать/сохранять презентации параллельно?

Нельзя работать с одним экземпляром [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) из [нескольких потоков](/slides/ru/androidjava/multithreading/). Запускайте отдельные изолированные экземпляры для каждого потока или процесса.

### Как удалить пробный водяной знак и ограничения?

[Примените лицензию](/slides/ru/androidjava/licensing/) один раз за процесс. XML‑файл лицензии должен оставаться неизменным, а процесс её установки должен быть синхронизирован при работе нескольких потоков.

### Можно ли добавить цифровую подпись к создаваемому PPTX?

Да. [Цифровые подписи](/slides/ru/androidjava/digital-signature-in-powerpoint/) (добавление и проверка) поддерживаются для презентаций.

### Поддерживаются ли макросы (VBA) в созданных презентациях?

Да. Вы можете [создавать/редактировать VBA‑проекты](/slides/ru/androidjava/presentation-via-vba/) и сохранять файлы с поддержкой макросов, такие как PPTM/PPSM.