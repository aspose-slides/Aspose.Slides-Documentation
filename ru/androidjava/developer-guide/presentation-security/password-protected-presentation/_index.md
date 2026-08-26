---
title: Защита презентаций паролем на Android
linktitle: Защита паролем
type: docs
weight: 20
url: /ru/androidjava/password-protected-presentation/
keywords:
- презентация, защищённая паролем
- пароль открытия
- шифрование PowerPoint
- расшифровка PowerPoint
- валидация пароля презентации
- проверка пароля презентации
- открыть зашифрованную презентацию
- удалить шифрование
- PowerPoint
- PPT
- PPTX
- презентация
- Android
- Java
- Aspose.Slides
description: "Шифрование, обнаружение, проверка, открытие и расшифровка презентаций PowerPoint PPT и PPTX, защищённых паролем, с помощью Aspose.Slides для Android на Java."
---
## **Обзор**

Пароль открытия шифрует презентацию. Для загрузки и просмотра содержимого презентации требуется правильный пароль, поэтому эта защита обеспечивает конфиденциальность.

Пароль открытия отличается от пароля защиты от записи. Защита от записи ограничивает изменение, но не шифрует содержимое и не препятствует загрузке презентации. Чтобы управлять паролями для модификации презентаций, см. [Защита от записи презентаций](/slides/ru/androidjava/write-protected-presentation/).

Ниже приведённые рабочие процессы применимы как к PPT, так и к PPTX презентациям. Примеры используют оба формата, когда важно их файловое и потоковое поведение.

## **Зашифровать презентацию паролем открытия**

Используйте [IProtectionManager.encrypt](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) для назначения пароля открытия. Затем используйте [IPresentation.save](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) для сохранения зашифрованной презентации.

Следующий пример шифрует PPTX презентацию:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Загрузить зашифрованную презентацию**

Установите [ILoadOptions.setPassword](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) в значение пароля открытия и передайте параметры в [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/) при загрузке файла. Загрузка не удалась, если требуется пароль открытия, но предоставленный пароль отсутствует или неверен.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    // Работа с расшифрованной презентацией.
} finally {
    presentation.dispose();
}
```

## **Удалить шифрование из презентации**

Загрузите презентацию с её паролем открытия, вызовите [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iprotectionmanager/#removeEncryption--), и сохраните результат. Сохранённую презентацию затем можно загрузить без пароля.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Проверить пароль открытия перед загрузкой**

Используйте [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) чтобы получить [IPresentationInfo](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentationinfo/) без создания полной экземпляра презентации. Проверьте [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) перед запросом или проверкой пароля. Когда защита присутствует, проверьте предоставленное значение с помощью [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-).

### **Рабочий процесс с файловым путём**

Следующий пример проверяет пароль открытия для PPTX файла, передаёт проверенное значение в [ILoadOptions.setPassword](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-), а затем загружает полную презентацию:

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;

String filePath = "protected-presentation.pptx";
String password = "open_password";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(filePath);

if (!presentationInfo.isPasswordProtected()) {
    System.out.println("The presentation does not have an opening password.");
} else if (!presentationInfo.checkPassword(password)) {
    System.out.println("The opening password is incorrect.");
} else {
    LoadOptions loadOptions = new LoadOptions();
    loadOptions.setPassword(password);

    Presentation presentation = new Presentation(filePath, loadOptions);
    try {
        System.out.println("The presentation was validated and loaded successfully.");
    } finally {
        presentation.dispose();
    }
}
```

### **Потоковый рабочий процесс**

Перегрузка потока метода [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) предоставляет тот же процесс. Сбросьте позицию пригодного к перемотке потока перед загрузкой полной презентации из этого потока.

Следующий пример использует PPT файл:

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;
import java.io.FileInputStream;

String password = "open_password";

FileInputStream presentationStream = new FileInputStream("protected-presentation.ppt");
try {
    IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(presentationStream);

    if (!presentationInfo.isPasswordProtected()) {
        System.out.println("The presentation does not have an opening password.");
    } else if (!presentationInfo.checkPassword(password)) {
        System.out.println("The opening password is incorrect.");
    } else {
        presentationStream.getChannel().position(0);

        LoadOptions loadOptions = new LoadOptions();
        loadOptions.setPassword(password);

        Presentation presentation = new Presentation(presentationStream, loadOptions);
        try {
            System.out.println("The presentation was validated and loaded successfully.");
        } finally {
            presentation.dispose();
        }
    }
} finally {
    presentationStream.close();
}
```

### **Возвратные значения checkPassword**

[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) возвращает `true` только когда у презентации установлен пароль открытия и предоставленный пароль корректен. Он возвращает `false` в каждом из следующих случаев:
- Пароль неверен.
- У презентации нет пароля открытия.
- Предоставленный пароль `null` или пустой.

Поведение одинаково для PPT и PPTX презентаций.

## **Проверить, зашифрована ли загруженная презентация**

После загрузки презентации с правильным паролем проверьте [IProtectionManager.isEncrypted](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iprotectionmanager/#isEncrypted--) чтобы подтвердить, что исходная презентация была зашифрована. Чтобы обнаружить защиту паролем открытия до загрузки, используйте `IPresentationInfo.isPasswordProtected`, как показано выше.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
    System.out.println("The presentation is encrypted: " + isEncrypted);
} finally {
    presentation.dispose();
}
```

## **Рекомендации по безопасности**

{{% alert color="warning" title="Security" %}}
Не регистрируйте пароли открытия и не включайте их в диагностические сообщения. Избегайте лишних повторных попыток проверки, храните пароли в памяти лишь столько, сколько необходимо, и повторно используйте успешный результат проверки при немедленной загрузке презентации.
{{% /alert %}}

## **Защитить презентацию паролем онлайн**

1. Откройте приложение [Aspose.Slides Lock](https://products.aspose.app/slides/ru/lock).
2. Выберите или загрузите презентацию.
3. Введите пароль для защиты просмотра.
4. При необходимости введите отдельный пароль для защиты от редактирования.
5. Примените защиту и скачайте полученный файл.

{{% alert color="info" title="See also" %}}
- [Защита от записи презентаций](/slides/ru/androidjava/write-protected-presentation/)
- [Электронная подпись в PowerPoint](/slides/ru/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Часто задаваемые вопросы**

**В чём разница между паролем открытия и паролем защиты от записи?**

Пароль открытия шифрует презентацию и требуется для загрузки её содержимого. Пароль защиты от записи ограничивает изменение без шифрования содержимого.

**Могу ли я проверить пароль открытия без загрузки всех слайдов?**

Да. Получите информацию о презентации, проверьте наличие защиты паролем открытия и проверьте пароль до создания полного экземпляра презентации.

**Поддерживают ли процессы проверки пароля как PPT, так и PPTX?**

Да. Обнаружение и проверка пароля по файловому пути и на основе потоков работают одинаково для PPT и PPTX презентаций.