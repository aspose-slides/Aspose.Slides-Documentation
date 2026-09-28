---
title: Установить Aspose.Slides для Android через Java
type: docs
weight: 90
url: /ru/androidjava/install-aspose-slides-for-android-via-java/
keywords:
- установить Aspose.Slides
- скачать Aspose.Slides
- использовать Aspose.Slides
- установка Aspose.Slides
- Gradle
- репозиторий Maven
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Добавьте Aspose.Slides for Android via Java в проект Android Studio с помощью Gradle из Maven‑репозитория Aspose, или добавьте JAR‑файл вручную."
---
## **Обзор**

В этой статье объясняется, как добавить Aspose.Slides for Android via Java в Android проект. Рекомендуемый способ — позволить Gradle загрузить библиотеку из Maven репозитория Aspose. Вы также можете скачать JAR файл и добавить его в проект вручную.

Библиотека не опубликована в Maven Central или Maven репозитории Google. Она доступна в собственном репозитории Aspose как артефакт `aspose-slides` с классификатором `android.via.java`.

## **Установка из Maven репозитория Aspose**

### **Шаг 1: Добавить репозиторий**

Новые проекты Android Studio объявляют свои репозитории в блоке `dependencyResolutionManagement` файла *settings.gradle.kts*, и Gradle отклоняет репозитории, которые добавляет файл сборки модуля. Добавьте строку `maven`, показанную ниже, в блок `repositories` внутри существующего блока, а не вставляйте второй блок `dependencyResolutionManagement`:

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

### **Шаг 2: Добавить зависимость**

Добавьте библиотеку в блок `dependencies` файла сборки модуля приложения, *app/build.gradle.kts*:

```kotlin
dependencies {
    implementation("com.aspose:aspose-slides:26.9:android.via.java")
}
```

Последняя часть координат, `android.via.java`, — это классификатор, который выбирает Android‑версию библиотеки. Без него Gradle не может найти артефакт.

Затем синхронизируйте проект с файлами Gradle, чтобы Gradle загрузил библиотеку.

### **Выбор версии**

Aspose.Slides for Android via Java не собирается для каждой версии в репозитории. Его сборки публикуются только для некоторых версий Aspose.Slides for Java, и версия без Android‑сборки не может быть найдена. Выберите версию, указанную на странице [Aspose.Slides for Android via Java download page](https://releases.aspose.com/slides/androidjava/).

### **Скрипты сборки Groovy**

Если ваш проект использует скрипты сборки Groovy, добавьте строку `maven` в блок `repositories` внутри существующего блока `dependencyResolutionManagement` файла *settings.gradle*:

```groovy
dependencyResolutionManagement {
    repositoriesMode.set(RepositoriesMode.FAIL_ON_PROJECT_REPOS)
    repositories {
        google()
        mavenCentral()
        maven { url = 'https://releases.aspose.com/java/repo/' }
    }
}
```

И добавьте зависимость в *app/build.gradle*:

```groovy
dependencies {
    implementation 'com.aspose:aspose-slides:26.9:android.via.java'
}
```

## **Добавление JAR файла вручную**

Если вы не можете использовать Maven репозиторий, добавьте JAR файл в ваш проект:

1. Скачайте JAR файл из папки нужной версии в [Aspose's Maven repository](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). Для версии 26.9 файл называется *aspose-slides-26.9-android.via.java.jar* в папке *26.9*.
2. Скопируйте файл в папку *app/libs* вашего проекта. Создайте папку, если её нет.
3. Добавьте файл в блок `dependencies` файла *app/build.gradle.kts*, затем синхронизируйте проект:

```kotlin
dependencies {
    implementation(files("libs/aspose-slides-26.9-android.via.java.jar"))
}
```

## **Создание первой презентации**

После синхронизации проекта продолжите с руководством [Create Presentations](/slides/ru/androidjava/create-presentation/). В первом примере добавляется текстовое поле на слайд и сохраняется презентация во внутреннее хранилище вашего приложения, не требующее разрешения на доступ к хранилищу. Без лицензии Aspose.Slides добавляет отметку оценки на каждый сохранённый слайд; смотрите раздел [Licensing](/slides/ru/androidjava/licensing/).

## **Версионирование**

С 2018 года версионирование Aspose.Slides for Android via Java соответствует версионированию Aspose.Slides for Java. Android‑сборки не публикуются для каждой версии Java; смотрите раздел [Choose a Version](#choose-a-version).

## **FAQ**

### Как проверить, что Aspose.Slides интегрирован правильно?

Соберите проект, создайте пустой объект [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) и сохраните его под новым именем. Если файл создан без исключений, библиотека успешно интегрирована.

### Как ограничить потребление памяти при обработке больших презентаций?

Вызовите метод [dispose](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#dispose--) каждого экземпляра [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) в блоке `finally`, чтобы быстро освободить его ресурсы, и обрабатывайте по одной большой презентации за раз. Это помогает предотвратить ошибки нехватки памяти и поддерживает предсказуемое общее использование памяти во время пакетных операций.

### Можно ли исключить ненужные форматы экспорта, чтобы уменьшить размер конечного JAR?

Текущие релизы Aspose.Slides поставляются в виде единой монолитной библиотеки, поэтому нельзя отключить отдельные экспортеры, такие как PDF или SVG, во время сборки.