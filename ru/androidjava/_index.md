---
title: Aspose.Slides для Android через Java
second_title: Aspose.Slides для Android
type: docs
weight: 40
url: /ru/androidjava/
keywords:
- документация
- обработка презентаций
- конвертация презентаций
- PowerPoint
- OpenDocument
- Android
- Java
- Aspose.Slides
description: "Начните здесь: добавьте Aspose.Slides for Android via Java в ваше приложение, создайте первую презентацию и найдите руководства по общим задачам, справочник API и поддержку."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for Android via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Android via Java — это библиотека классов для создания, чтения, редактирования и преобразования презентаций PowerPoint и OpenDocument в приложениях Android, без Microsoft PowerPoint.

Она загружает и сохраняет файлы PPT, PPTX, PPS, POT и ODP, включая варианты с макросами и шаблоны, а также экспортирует в PDF, XPS, HTML, SVG, TIFF, Markdown и изображения.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Начало работы</b></p>
<hr>
<p>Первые шаги</p>
<ul>
<li><a href="/slides/ru/androidjava/install-aspose-slides-for-android-via-java/">Установка</a></li>
<li><a href="/slides/ru/androidjava/create-presentation/">Создание первой презентации</a></li>
<li><a href="/slides/ru/androidjava/getting-started/">Руководство по началу работы</a></li>
</ul>
<p>Оценка</p>
<ul>
<li><a href="/slides/ru/androidjava/supported-file-formats/">Поддерживаемые форматы файлов</a></li>
<li><a href="/slides/ru/androidjava/evaluate-aspose-slides/">Ограничения пробной версии</a></li>
<li><a href="/slides/ru/androidjava/licensing/">Лицензирование</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Создание с Slides</b></p>
<hr>
<p>Общие задачи</p>
<ul>
<li><a href="/slides/ru/androidjava/open-presentation/">Открыть презентацию</a></li>
<li><a href="/slides/ru/androidjava/save-presentation/">Сохранить презентацию</a></li>
<li><a href="/slides/ru/androidjava/convert-powerpoint-to-pdf/">Конвертировать в PDF</a></li>
<li><a href="/slides/ru/androidjava/convert-slide/">Отображать слайды как изображения</a></li>
<li><a href="/slides/ru/androidjava/manage-text/">Редактировать текст и фигуры</a></li>
</ul>
<p>Рабочие процессы Slides</p>
<ul>
<li><a href="/slides/ru/androidjava/powerpoint-charts/">Диаграммы</a></li>
<li><a href="/slides/ru/androidjava/powerpoint-animation/">Анимация</a></li>
<li><a href="/slides/ru/androidjava/manage-media-files/">Аудио и видео</a></li>
<li><a href="/slides/ru/androidjava/presentation-design/">Дизайн слайдов</a></li>
<li><a href="/slides/ru/androidjava/merge-presentation/">Объединение презентаций</a></li>
</ul>
<p>Примеры</p>
<ul>
<li><a href="/slides/ru/androidjava/examples/">Примеры по элементам слайда</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Справка и поддержка</b></p>
<hr>
<p>СПРАВОЧНИК</p>
<ul>
<li><a href="https://reference.aspose.com/slides/ru/androidjava/">Справочник API</a></li>
<li><a href="https://releases.aspose.com/slides/ru/androidjava/release-notes/">Примечания к выпуску</a></li>
<li><a href="/slides/ru/androidjava/known-issues/">Известные проблемы</a></li>
<li><a href="https://releases.aspose.com/slides/ru/androidjava/">Скачать</a></li>
</ul>
<p>ПОДДЕРЖКА</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/ru/11">Бесплатный форум поддержки</a></li>
<li><a href="https://helpdesk.aspose.com/">Платный сервис поддержки</a></li>
</ul>
</div>
</div>

------

## **Ваша первая презентация**

Библиотека находится в Maven‑репозитории Aspose. В новых проектах Android Studio уже присутствует блок `dependencyResolutionManagement` в файле *settings.gradle.kts*. Добавьте строку `maven`, показанную ниже, в блок `repositories` внутри него, а не вставляйте второй блок:

```kotlin
dependencyResolutionManagement {
    repositoriesMode.set(RepositoriesMode.FAIL_ON_PROJECT_REPOS)
    repositories {
        google()
        mavenCentral()
        maven { url = uri("https://releases.aspose.com/java/repo/") }
    }
}
```

Затем добавьте библиотеку в *app/build.gradle.kts* и синхронизируйте проект:

```kotlin
dependencies {
    implementation("com.aspose:aspose-slides:26.9:android.via.java")
}
```

[Installation](/slides/ru/androidjava/install-aspose-slides-for-android-via-java/) охватывает скрипты сборки Groovy, ручной JAR‑файл и выбор версии. Код вашей первой презентации находится в разделе [Create Presentations](/slides/ru/androidjava/create-presentation/): он добавляет текстовое поле на слайд и сохраняет презентацию во внутреннее хранилище вашего приложения. Этот пример был скомпилирован и упакован в APK; он не был запущен на устройстве. Без лицензии сохранённые презентации содержат водяной знак оценки — см. раздел [Licensing](/slides/ru/androidjava/licensing/).