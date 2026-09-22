---
title: Открытие презентаций в Java
linktitle: Открыть презентацию
type: docs
weight: 20
url: /ru/java/open-presentation/
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
- бинарный объект
- Java
- Aspose.Slides
description: "Узнайте, как открывать презентации PowerPoint и OpenDocument в Java, задавать пароли для открытия, управлять загрузкой ресурсов и уменьшать использование памяти с помощью Aspose.Slides для Java."
---
## **Введение**

[Aspose.Slides for Java](https://products.aspose.com/slides/ru/java/) может загружать презентации PowerPoint и OpenDocument из файлов и потоков. После загрузки презентации вы можете исследовать её структуру, редактировать слайды, управлять ресурсами и сохранять её в оригинальном или другом поддерживаемом формате.

Поведение загрузки можно настроить с помощью класса [LoadOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/loadoptions/). Например, вы можете указать пароль для открытия, хранить большие бинарные объекты вне кучи Java, управлять внешними ресурсами или исключать встроенные бинарные данные.

## **Открытие презентаций**

После загрузки файла или потока вы можете [определить исходный формат презентации](/slides/ru/java/detect-presentation-source-format/), чтобы выбрать способ обработки её вашим приложением.

Чтобы открыть существующую презентацию, передайте путь к её файлу в конструктор [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/). После использования освободите презентацию, чтобы дескрипторы файлов, временные данные и другие ресурсы были быстро освобождены.

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

## **Открытие презентаций с паролем**

Пароль для открытия шифрует содержимое презентации. Чтобы загрузить полную презентацию, передайте правильный пароль в [LoadOptions.setPassword](https://reference.aspose.com/slides/ru/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) , а полученные параметры укажите в конструкторе [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/). Загрузка завершится с ошибкой, если пароль отсутствует или указан неверно.

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

Для обнаружения пароля, проверки и процессов шифрования см. [Password-Protect Presentations](/slides/ru/java/password-protected-presentation/). Если зашифрованная презентация была намеренно сохранена с общедоступными свойствами документа, эти свойства можно прочитать без пароля; см. [Manage Presentation Properties](/slides/ru/java/presentation-properties/).

## **Открытие больших презентаций**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) возвращает параметры, контролирующие, как Aspose.Slides обрабатывает большие бинарные объекты, такие как изображения, аудио и видео. Вы можете удерживать исходный файл заблокированным, разрешать временные файлы и ограничивать объём BLOB‑данных, сохраняемых в памяти.

Следующий пример на Java демонстрирует загрузку большой презентации (например, 2 ГБ):

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
С помощью [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentationlockingbehavior/#KeepLocked) исходный файл остаётся заблокированным до освобождения экземпляра презентации. Не перемещайте, перезаписывайте и не удаляйте исходный файл, пока этот экземпляр жив.

Aspose.Slides может копировать содержимое входного потока во время загрузки. Для больших презентаций путь к файлу обычно более эффективен, чем поток. См. [Manage BLOBs](/slides/ru/java/manage-blob/) для дополнительных вариантов хранения и управления памятью.
{{% /alert %}}

## **Управление внешними ресурсами**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/ru/java/com.aspose.slides/loadoptions/#setResourceLoadingCallback-com.aspose.slides.IResourceLoadingCallback-) принимает реализацию [IResourceLoadingCallback](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iresourceloadingcallback/). Обратный вызов может предоставить заменяющие данные, перенаправить ресурс, использовать загрузчик по умолчанию или пропустить ресурс. Это полезно, когда презентации содержат внешние изображения, которые необходимо обрабатывать в соответствии с правилами безопасности или хранения, специфичными для приложения.

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

## **Загрузка презентаций без встроенных бинарных объектов**

Презентация может содержать встроенные бинарные данные, которые приложение не требуется или не хочет сохранять. Примеры включают:

- VBA‑проекты, доступные через [IPresentation.getVbaProject](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipresentation/#getVbaProject--);
- встроенные OLE‑данные, доступные через [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--);
- данные элементов управления ActiveX, доступные через [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/ru/java/com.aspose.slides/icontrol/#getActiveXControlBinary--).

Установите [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/ru/java/com.aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) в `true`, чтобы удалить эти бинарные данные при загрузке. Сохраните загруженную презентацию, чтобы зафиксировать очищенный результат.

Этот параметр уменьшает риск наличия нежелательных встроенных полезных нагрузок, но не является полной системой обнаружения вредоносного кода или очистки содержимого.

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

## **FAQ**

**Как узнать, что файл повреждён и его нельзя открыть?**

Aspose.Slides бросает исключение парсинга или формата во время загрузки. Обрабатывайте эту ошибку отдельно от ошибки неверного пароля, чтобы приложение могло точно сообщить причину.

**Что происходит, если требуемые шрифты отсутствуют?**

Презентацию всё ещё можно загрузить, но при рендеринге и экспорте могут использоваться заменяющие шрифты. Вы можете [configure font substitution](/slides/ru/java/font-substitution/) или [provide custom fonts](/slides/ru/java/custom-font/), чтобы сделать вывод более предсказуемым.

**Загружается ли при открытии презентации её встроенное медиа?**

Встроенное аудио и видео становятся доступными через объектную модель презентации. Внешние ресурсы разрешаются в соответствии с настроенным поведением загрузки ресурсов и могут быть недоступны, если их местоположения недоступны.