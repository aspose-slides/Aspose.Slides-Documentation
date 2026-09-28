---
title: Лицензирование
type: docs
weight: 90
url: /ru/androidjava/licensing/
keywords:
- лицензия
- временная лицензия
- установить лицензию
- использовать лицензию
- проверить лицензию
- файл лицензии
- оценочная версия
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Применяйте, управляйте и устраняйте проблемы с лицензиями в Aspose.Slides for Android via Java. Обеспечьте бесперебойный доступ к полному набору функций с помощью нашего руководства по лицензированию."
---
## **Обзор**

Aspose.Slides можно использовать в режиме оценки или с действующей лицензией. Оценочная версия предоставляет тот же функционал, что и лицензированная, но добавляет водяной знак оценки к каждому слайду каждой презентации, которую она сохраняет, и усекает текст, который ваш код читает из презентаций.

В этой статье объясняется, как работает лицензирование в Aspose.Slides и как применить лицензию перед использованием библиотеки. Лицензию можно загрузить из файла, потока или встроенного ресурса, используя класс [License](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/). Статья также показывает, как проверить, была ли лицензия применена правильно.

## **Оценка Aspose.Slides**

{{% alert color="info" title="Note" %}}
Вы можете скачать оценочную версию **Aspose.Slides for Android via Java** со своей [страницы загрузки](https://releases.aspose.com/slides/androidjava/). Оценочная версия предоставляет те же функции, что и лицензированная версия продукта. Оценочный пакет идентичен приобретенному пакету. Оценочная версия просто становится лицензированной после того, как вы добавите несколько строк кода (для применения лицензии).

Когда вы будете довольны своей оценкой **Aspose.Slides**, вы можете [приобрести лицензию](https://purchase.aspose.com/pricing/slides/android-java/). Мы рекомендуем ознакомиться с различными типами подписки. Если у вас есть вопросы, свяжитесь с отделом продаж Aspose.

Каждая лицензия Aspose включает годовую подписку на бесплатные обновления до новых версий или исправлений, выпущенных в течение периода подписки. Пользователи лицензированных продуктов (или даже оценочных версий) получают бесплатную и неограниченную техническую поддержку.
{{% /alert %}} 

**Ограничения оценочной версии**

* Оценочная версия (без указания лицензии) предоставляет весь функционал продукта, но добавляет текстовый блок с водяным знаком оценки к каждому слайду каждой презентации, которую она сохраняет.
* Текст, который ваш код читает из презентации, усечён до первых нескольких символов с последующим уведомлением об ограничениях оценки. Текст, который ваш код записывает, сохраняется полностью.

{{% alert color="info" title="Note" %}}
Чтобы протестировать Aspose.Slides без ограничений, вы можете запросить **временную лицензию на 30 дней**. Смотрите страницу [How to get a Temporary License](https://purchase.aspose.com/temporary-license) для получения дополнительной информации.
{{% /alert %}}

## **Лицензирование в Aspose.Slides**

* Оценочная версия становится лицензированной после покупки лицензии и добавления нескольких строк кода (для применения лицензии).
* Лицензия — это простой XML‑файл, содержащий детали, такие как название продукта, количество разработчиков, на которых лицензирована, дату окончания подписки и т.д.
* Файл лицензии подписан цифровой подписью, поэтому его нельзя изменять. Даже случайное добавление лишнего переноса строки в содержимое файла сделает её недействительной.
* Aspose.Slides for Android via Java обычно ищет лицензию в следующих местах:
  * Явный путь
  * Папка, содержащая Aspose.Slides.jar
* Чтобы избежать ограничений, связанных с оценочной версией, необходимо установить лицензию перед использованием **Aspose.Slides**. Лицензию нужно установить только один раз за приложение или процесс.

## **Применение лицензии**

Лицензию можно загрузить из **файла** или **потока**.

{{% alert color="info" title="Note" %}}
Aspose.Slides предоставляет класс [License](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/) для операций с лицензиями.
{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}
Новые лицензии могут активировать Aspose.Slides только начиная с версии 21.4 и новее. Ранние версии используют другую систему лицензирования и не распознают эти лицензии.
{{% /alert %}}

### **Файл**

Самый простой способ установить лицензию требует разместить файл лицензии в папке, содержащей Aspose.Slides.jar, или в JAR‑файле вашего приложения.

{{% alert color="info" title="Note" %}}
На Android библиотека и ваше приложение упаковываются в APK, поэтому нет папки, содержащей JAR‑файл библиотеки, и относительный путь, такой как *Aspose.Slides.Android.via.Java.lic*, не указывает на файл в вашем приложении. Добавьте файл лицензии в assets вашего приложения и загрузите его из потока, как показано в разделе [Stream from App Assets](#stream-from-app-assets).
{{% /alert %}}

Этот Java‑код показывает, как установить файл лицензии:

``` java
// Создаёт экземпляр класса License
com.aspose.slides.License license = new com.aspose.slides.License();

// Устанавливает путь к файлу лицензии
license.setLicense("Aspose.Slides.Android.via.Java.lic");
```

{{% alert color="warning" title="Warning" %}}
Если вы разместите файл лицензии в другой директории, при вызове метода [setLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) имя файла лицензии в конце указанного пути должно совпадать с именем вашего файла лицензии.

Например, вы можете изменить имя файла лицензии на *Aspose.Slides.Android.via.Java.lic.xml*. Затем в коде необходимо передать путь к файлу (заканчивающийся на *Aspose.Slides.Android.via.Java.lic.xml*) в метод [setLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-).
{{% /alert %}}

### **Поток**

Вы можете загрузить лицензию из потока. Этот Java‑код показывает, как применить лицензию из потока:

``` java
// Создаёт экземпляр класса License
com.aspose.slides.License license = new com.aspose.slides.License();

// Устанавливает лицензию через поток
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Android.via.Java.lic"));
```

### **Поток из ресурсов приложения**

В Android‑приложении разместите файл лицензии в папке *assets* модуля приложения, *app/src/main/assets*, чтобы он был упакован в APK. Откройте файл с помощью метода [getAssets](https://developer.android.com/reference/android/content/Context#getAssets()) и передайте поток в метод [setLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-). Код выполняется внутри `Activity`, например в её методе `onCreate`, до того как приложение использует Aspose.Slides:

```java
import android.util.Log;
import com.aspose.slides.License;
import java.io.IOException;
import java.io.InputStream;

License license = new License();
try (InputStream licenseStream = getAssets().open("Aspose.Slides.Android.via.Java.lic")) {
    license.setLicense(licenseStream);
} catch (IOException exception) {
    Log.e("Licensing", "Cannot read the license file from the app's assets.", exception);
}
```

Имя файла, передаваемое методу [open](https://developer.android.com/reference/android/content/res/AssetManager#open(java.lang.String)), указывается относительно папки *assets*. Если файл отсутствует, код записывает ошибку, и Aspose.Slides остаётся в режиме оценки. Чтобы проверить, была ли лицензия применена, см. раздел [Validating a License](#validating-a-license).

## **Проверка лицензии**

Чтобы проверить, правильно ли установлена лицензия, её можно валидировать. Этот Java‑код показывает, как проверить лицензию:

```java
import com.aspose.slides.*;

License license = new License();
license.setLicense("Aspose.Slides.Android.via.Java.lic");

if (license.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **Потокобезопасность**

{{% alert color="warning" title="Warning" %}}
Метод [setLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) не является потокобезопасным. Если его необходимо вызывать одновременно из нескольких потоков, рекомендуется использовать примитивы синхронизации (например, блокировку), чтобы избежать проблем.
{{% /alert %}}

## **FAQ**

### Могу ли я применить лицензию в полностью автономной среде (без доступа к Интернету)?

Да. Проверка лицензии выполняется локально с использованием файла лицензии; подключение к Интернету не требуется.

### Что происходит после окончания годовой подписки? Перестанет ли библиотека работать?

Нет. Лицензия бессрочная: вы можете продолжать использовать версии, выпущенные до даты окончания вашей подписки; однако вы не сможете использовать более новые релизы без продления подписки.