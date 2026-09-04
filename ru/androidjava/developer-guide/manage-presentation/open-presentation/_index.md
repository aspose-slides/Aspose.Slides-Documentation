---
title: Открытие презентаций на Android
linktitle: Открыть презентацию
type: docs
weight: 20
url: /ru/androidjava/open-presentation/
keywords:
- открыть PowerPoint
- открыть презентацию
- открыть PPTX
- открыть PPT
- открыть ODP
- загрузить презентацию
- загрузить PPTX
- загрузить PPT
- загрузить ODP
- защищённая презентация
- большая презентация
- внешний ресурс
- двоичный объект
- Android
- Java
- Aspose.Slides
description: "Узнайте, как открывать презентации PowerPoint и OpenDocument на Android, указывать пароли для открытия, управлять загрузкой ресурсов и сокращать использование памяти с помощью Aspose.Slides for Android via Java."
---
## **Введение**

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/ru/androidjava/) может загружать презентации PowerPoint и OpenDocument из файлов и потоков. После загрузки презентации вы можете просматривать её структуру, редактировать слайды, управлять ресурсами и сохранять её в оригинальном или другом поддерживаемом формате.

Поведение загрузки можно настроить с помощью класса [LoadOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/loadoptions/). Например, можно задать пароль для открытия, хранить большие двоичные объекты вне памяти кучи Java, управлять внешними ресурсами или исключить встроенные двоичные данные.

## **Открытие презентаций**

Чтобы открыть существующую презентацию, передайте её путь к файлу в конструктор [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/). После использования освободите презентацию, чтобы дескрипторы файлов, временные данные и другие ресурсы были быстро освобождены.

Следующий пример на Java показывает, как открыть презентацию и получить количество её слайдов:

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Открытие защищённых паролем презентаций**

Пароль для открытия шифрует содержимое презентации. Чтобы загрузить полностью презентацию, передайте правильный пароль в [LoadOptions.setPassword](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) и укажите эти параметры в конструкторе [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/). Загрузка завершится ошибкой, если пароль отсутствует или неверен.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-presentation.pptx", loadOptions);
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Для обнаружения пароля, проверки и процессов шифрования см. [Password-Protect Presentations](/slides/ru/androidjava/password-protected-presentation/). Если зашифрованная презентация была намеренно сохранена с публичными свойствами документа, эти свойства можно прочитать без пароля; см. [Manage Presentation Properties](/slides/ru/androidjava/presentation-properties/).

## **Открытие больших презентаций**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) возвращает параметры, контролирующие, как Aspose.Slides обрабатывает большие двоичные объекты, такие как изображения, аудио и видео. Можно оставить исходный файл заблокированным, разрешить временные файлы и ограничить объём BLOB‑данных, хранящихся в памяти.

Следующий код Java демонстрирует загрузку большой презентации (например, 2 ГБ):

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationLockingBehavior;
import com.aspose.slides.SaveFormat;

final String filePath = "large-presentation.pptx";

LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024);

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    presentation.getSlides().get_Item(0).setName("Large presentation");
    presentation.save("large-presentation-copy.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}

С помощью [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentationlockingbehavior/#KeepLocked) исходный файл остаётся заблокированным до тех пор, пока не будет освобождён объект презентации. Не перемещайте, перезаписывайте и не удаляйте исходный файл, пока экземпляр жив.

Aspose.Slides может копировать содержимое входного потока во время загрузки. Для больших презентаций путь к файлу, как правило, более эффективен, чем поток. См. [Manage BLOBs](/slides/ru/androidjava/manage-blob/) для дополнительных вариантов хранения и управления памятью.

{{% /alert %}}

## **Управление внешними ресурсами**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/loadoptions/#setResourceLoadingCallback-com.aspose.slides.IResourceLoadingCallback-) принимает реализацию [IResourceLoadingCallback](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iresourceloadingcallback/). Обратный вызов может предоставить заменяющие данные, перенаправить ресурс, использовать загрузчик по умолчанию или пропустить ресурс. Это полезно, когда в презентациях присутствуют внешние изображения, которые должны быть получены согласно специфическим правилам безопасности или хранения приложения.

```java
import com.aspose.slides.IResourceLoadingArgs;
import com.aspose.slides.IResourceLoadingCallback;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.ResourceLoadingAction;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Locale;

class ImageLoadingHandler implements IResourceLoadingCallback {
    public int resourceLoading(IResourceLoadingArgs args) {
        boolean isJpeg = args.getOriginalUri().toLowerCase(Locale.ROOT).endsWith(".jpg");
        Path approvedImagePath = Paths.get("approved-image.jpg");
        if (!isJpeg || !Files.exists(approvedImagePath)) {
            return ResourceLoadingAction.Skip;
        }

        try {
            byte[] imageData = Files.readAllBytes(approvedImagePath);
            args.setData(imageData);
            return ResourceLoadingAction.UserProvided;
        } catch (IOException exception) {
            System.err.println("The approved replacement image could not be read.");
            return ResourceLoadingAction.Skip;
        }
    }
}

LoadOptions loadOptions = new LoadOptions();
loadOptions.setResourceLoadingCallback(new ImageLoadingHandler());

Presentation presentation = new Presentation("presentation-with-external-images.pptx", loadOptions);
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Загрузка презентаций без встроенных двоичных объектов**

Презентация может содержать встроенные двоичные данные, которые приложение не нуждается или не хочет сохранять. Примеры включают:

- VBA‑проекты, доступные через [IPresentation.getVbaProject](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentation/#getVbaProject--);
- встроенные OLE‑данные, доступные через [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--);
- данные управляющих элементов ActiveX, доступные через [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/icontrol/#getActiveXControlBinary--).

Установите [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) в `true`, чтобы удалить эти двоичные данные при загрузке. Сохраните загруженную презентацию, чтобы зафиксировать очищенный результат.

Этот параметр снижает риск наличия нежелательных встроенных полезных нагрузок, но не является полноценной системой обнаружения вредоносного кода или очистки содержимого.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation presentation = new Presentation("presentation-with-embedded-data.pptx", loadOptions);
try {
    presentation.save("presentation-without-embedded-data.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Вопросы и ответы**

**Как определить, что файл повреждён и его нельзя открыть?**

Aspose.Slides генерирует исключение парсинга или формата во время загрузки. Обрабатывайте эту ошибку отдельно от ошибки неверного пароля, чтобы приложение могло точно сообщить о причине.

**Что происходит, если требуемые шрифты отсутствуют?**

Презентацию всё равно можно загрузить, но при рендеринге и экспорте могут использоваться заменяющие шрифты. Вы можете [configure font substitution](/slides/ru/androidjava/font-substitution/) или [provide custom fonts](/slides/ru/androidjava/custom-font/), чтобы сделать вывод более предсказуемым.

**Загружается ли при загрузке презентации также её встроенные медиа?**

Встроенные аудио и видео становятся доступными через объектную модель презентации. Внешние ресурсы разрешаются в соответствии с настроенным поведением загрузки ресурсов и могут быть недоступны, если их местоположения нельзя открыть.