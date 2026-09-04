---
title: Защита презентаций паролем в Java
linktitle: Защита паролем
type: docs
weight: 20
url: /ru/java/password-protected-presentation/
keywords:
- презентация с паролем
- пароль открытия
- шифрование PowerPoint
- расшифровка PowerPoint
- проверка пароля презентации
- проверка пароля презентации
- открытие зашифрованной презентации
- удаление шифрования
- PowerPoint
- PPT
- PPTX
- презентация
- Java
- Aspose.Slides
description: "Шифрование, обнаружение, проверка, открытие и расшифровка презентаций PowerPoint PPT и PPTX, защищённых паролем, в Java с Aspose.Slides."
---
## **Обзор**

Пароль открытия шифрует презентацию. Требуется правильный пароль для загрузки и просмотра содержимого презентации, поэтому эта защита обеспечивает конфиденциальность.

Пароль открытия отличается от пароля защиты от записи. Защита от записи ограничивает возможность изменения, но не шифрует содержимое и не препятствует загрузке презентации. Чтобы управлять паролями для изменения презентаций, см. [Write-Protect Presentations](/slides/ru/java/write-protected-presentation/).

Ниже приведённые рабочие процессы применимы как к PPT, так и к PPTX‑презентациям. Примеры используют оба формата, где важно их файловое и потоковое поведение.

## **Зашифровать презентацию паролем открытия**

Используйте [IProtectionManager.encrypt](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) для назначения пароля открытия. Затем примените [IPresentation.save](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) для сохранения зашифрованной презентации.

Следующий пример шифрует PPTX‑презентацию:

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

## **Сделать свойства документа общедоступными**

По умолчанию Aspose.Slides включает свойства документа в шифрование презентации. Метод [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) контролирует это поведение независимо от шифрования содержимого слайдов. Перед вызовом [IProtectionManager.encrypt](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) передайте `false`, если система индексации, классификации, поиска или управления документами должна читать метаданные без пароля открытия.

Следующий пример создаёт зашифрованную PPTX‑презентацию, оставляя её встроенные свойства документа общедоступными:

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    IDocumentProperties properties = presentation.getDocumentProperties();
    properties.setAuthor("Contoso Knowledge Management");
    properties.setTitle("Quarterly Product Roadmap");
    properties.setKeywords("roadmap, planning, internal");

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content");
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("public-properties-encrypted.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Передача `false` в [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) не делает общедоступными слайды, шаблоны, макеты, фигуры, медиа‑файлы или другое содержимое презентации. Это влияет только на свойства документа. Чтобы прочитать эти свойства без загрузки зашифрованного содержимого, см. [Manage Presentation Properties](/slides/ru/java/presentation-properties/).

## **Загрузка зашифрованной презентации**

Установите [ILoadOptions.setPassword](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) в пароль открытия и передайте параметры в [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/) при загрузке файла. Загрузка завершается ошибкой, когда требуется пароль открытия, но переданный пароль отсутствует или неверен.

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

Загрузите презентацию с её паролем открытия, вызовите [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iprotectionmanager/#removeEncryption--), и сохраните результат. Сохранённую презентацию затем можно будет открыть без пароля.

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

Используйте [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) для получения [IPresentationInfo](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipresentationinfo/) без создания полного экземпляра презентации. Проверьте [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) перед запросом или проверкой пароля. Если защита присутствует, проверьте переданное значение с помощью [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-).

### **Рабочий процесс с путем к файлу**

Следующий пример проверяет пароль открытия для PPTX‑файла, передаёт проверенное значение в [ILoadOptions.setPassword](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-), а затем загружает полную презентацию:

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

### **Рабочий процесс с потоком**

Перегруженный вариант [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) предоставляет тот же процесс. Сбросьте позицию поискового потока перед загрузкой полной презентации из этого потока.

Следующий пример использует PPT‑файл:

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

### **Возвращаемые значения checkPassword**

[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) возвращает `true` только когда у презентации есть пароль открытия и переданный пароль правильный. Он возвращает `false` в каждом из следующих случаев:

- Пароль неверен.
- У презентации нет пароля открытия.
- Переданный пароль `null` или пустой.

Поведение одинаково для PPT и PPTX‑презентаций.

## **Проверить, зашифрована ли загруженная презентация**

После загрузки презентации с правильным паролем проверьте [IProtectionManager.isEncrypted](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iprotectionmanager/#isEncrypted--) чтобы подтвердить, что исходная презентация была зашифрована. Чтобы обнаружить защиту паролем открытия до загрузки, используйте `IPresentationInfo.isPasswordProtected`, как показано выше.

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
Не записывайте пароли открытия в логи и не включайте их в диагностические сообщения. Избегайте ненужных повторных попыток проверки, храните пароли в памяти только столько, сколько требуется, и повторно используйте успешный результат проверки при немедленной загрузке презентации.

Общие свойства документа могут раскрывать имена авторов, названия, темы, ключевые слова, информацию о компании, комментарии и пользовательские значения, даже если содержимое презентации зашифровано. Шифруйте чувствительные метаданные вместе с презентацией. Оставление свойств общедоступными должно быть осознанным решением, принимаемым только когда системы обязаны индексировать, классифицировать, искать или управлять файлом без пароля открытия.
{{% /alert %}}

## **Защитить презентацию паролем онлайн**

1. Откройте приложение [Aspose.Slides Lock](https://products.aspose.app/slides/ru/lock).
1. Выберите или загрузите презентацию.
1. Введите пароль для защиты просмотра.
1. При необходимости введите отдельный пароль для защиты от редактирования.
1. Примените защиту и скачайте полученный файл.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/ru/java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/ru/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**В чём разница между паролем открытия и паролем защиты от записи?**

Пароль открытия шифрует презентацию и требуется для загрузки её содержимого. Пароль защиты от записи ограничивает возможность изменения без шифрования содержимого.

**Можно ли проверить пароль открытия без загрузки всех слайдов?**

Да. Получите информацию о презентации, проверьте наличие защиты паролем открытия и проверьте пароль перед созданием полного экземпляра презентации.

**Может ли приложение читать метаданные без пароля открытия?**

Да, но только если презентация была зашифрована с отключённым шифрованием свойств документа. В этом случае приложение должно использовать режим загрузки только свойств документа, описанный в [Manage Presentation Properties](/slides/ru/java/presentation-properties/).

**Поддерживают ли процессы проверки пароля как PPT, так и PPTX?**

Да. Определение и проверка пароля по пути к файлу и по потоку работают одинаково для PPT и PPTX‑презентаций.