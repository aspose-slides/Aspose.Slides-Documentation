---
title: Защита презентаций паролем на Android
linktitle: Защита паролем
type: docs
weight: 20
url: /ru/androidjava/password-protected-presentation/
keywords:
- презентация, защищённая паролем
- пароль для открытия
- шифрование PowerPoint
- расшифровка PowerPoint
- валидация пароля презентации
- проверка пароля презентации
- открытие зашифрованной презентации
- удаление шифрования
- PowerPoint
- PPT
- PPTX
- презентация
- Android
- Java
- Aspose.Slides
description: "Шифруйте, обнаруживайте, проверяйте, открывайте и расшифровывайте презентации PowerPoint PPT и PPTX, защищённые паролем, с помощью Aspose.Slides для Android на Java."
---
## **Обзор**

Пароль для открытия шифрует презентацию. Правильный пароль требуется для загрузки и просмотра содержимого презентации, поэтому эта защита обеспечивает конфиденциальность.

Пароль для открытия отличается от пароля защиты от записи. Защита от записи ограничивает внесение изменений, но не шифрует содержимое и не препятствует загрузке презентации. Чтобы управлять паролями для изменения презентаций, см. [Защита презентаций от записи](/slides/ru/androidjava/write-protected-presentation/).

Ниже приведённые сценарии применимы как к презентациям PPT, так и PPTX. Примеры используют оба формата, где важно поведение при работе с файлами и потоками.

## **Зашифровать презентацию с помощью пароля для открытия**

Используйте [IProtectionManager.encrypt](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) для назначения пароля для открытия. Затем используйте [IPresentation.save](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) для сохранения зашифрованной презентации.

В следующем примере зашифровывается презентация PPTX:

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

По умолчанию Aspose.Slides включает свойства документа в шифрование презентации. Метод [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) управляет этим поведением независимо от шифрования содержимого слайдов. Перед вызовом [IProtectionManager.encrypt](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) передайте `false`, если система индексации, классификации, поиска или управления документами должна считывать метаданные без пароля для открытия.

В следующем примере создаётся зашифрованная PPTX‑презентация, при этом встроенные свойства документа остаются общедоступными:

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

Передача `false` в [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) не делает общедоступными слайды, мастеры, макеты, фигуры, медиа или другое содержимое презентации. Она влияет только на свойства документа. Чтобы считывать эти свойства без загрузки зашифрованного содержимого, см. [Manage Presentation Properties](/slides/ru/androidjava/presentation-properties/).

## **Загрузить зашифрованную презентацию**

Установите [ILoadOptions.setPassword](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) в значение пароля для открытия и передайте параметры в [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/) при загрузке файла. Загрузка завершится ошибкой, если требуется пароль для открытия, но указанный пароль отсутствует или неверен.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    // Работайте с расшифрованной презентацией.
} finally {
    presentation.dispose();
}
```

## **Удалить шифрование из презентации**

Загрузите презентацию, указав её пароль для открытия, вызовите [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iprotectionmanager/#removeEncryption--) и сохраните результат. Сохранённую презентацию затем можно загрузить без пароля.

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

## **Проверить пароль для открытия перед загрузкой**

Используйте [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) для получения [IPresentationInfo](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentationinfo/) без создания полного экземпляра презентации. Проверьте [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) перед запросом или проверкой пароля. Если защита присутствует, проверьте указанное значение с помощью [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-).

### **Рабочий процесс с файловым путём**

В следующем примере проверяется пароль для открытия PPTX‑файла, проверенное значение передаётся в [ILoadOptions.setPassword](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-), после чего загружается полная презентация:

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

Перегрузка потока метода [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) предоставляет тот же сценарий. Сбросьте позицию позиционируемого потока перед загрузкой полной презентации из этого потока.

В следующем примере используется PPT‑файл:

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

[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) возвращает `true` только когда у презентации установлен пароль для открытия и указанный пароль верен. Он возвращает `false` в каждом из следующих случаев:

- Пароль неверен.
- У презентации нет пароля для открытия.
- Указанный пароль `null` или пустой.

Поведение одинаково для презентаций PPT и PPTX.

## **Проверить, зашифрована ли загруженная презентация**

После загрузки презентации с правильным паролем проверьте [IProtectionManager.isEncrypted](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iprotectionmanager/#isEncrypted--) чтобы убедиться, что исходная презентация была зашифрована. Чтобы обнаружить защиту паролем для открытия до загрузки, используйте `IPresentationInfo.isPasswordProtected`, как показано выше.

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

{{% alert color="warning" title="Безопасность" %}}
Не регистрируйте пароли для открытия и не включайте их в диагностические сообщения. Избегайте ненужных повторных попыток проверки, держите пароли в памяти только столько, сколько требуется, и переиспользуйте результат успешной проверки при немедленной загрузке презентации.

Общие свойства документа могут раскрывать имена авторов, названия, темы, ключевые слова, информацию о компании, комментарии и пользовательские значения, даже если содержимое презентации зашифровано. Шифруйте чувствительные метаданные вместе с презентацией. Оставление свойств общедоступными должно быть явным решением, принимаемым только тогда, когда системы должны индексировать, классифицировать, искать или управлять файлом без пароля для открытия.
{{% /alert %}}

## **Защитить презентацию паролем онлайн**

1. Откройте приложение [Aspose.Slides Lock](https://products.aspose.app/slides/ru/lock).
1. Выберите или загрузите презентацию.
1. Введите пароль для защиты просмотра.
1. При необходимости введите отдельный пароль для защиты от редактирования.
1. Примените защиту и загрузите полученный файл.

{{% alert color="info" title="См. также" %}}
- [Защита презентаций от записи](/slides/ru/androidjava/write-protected-presentation/)
- [Цифровая подпись в PowerPoint](/slides/ru/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**В чём разница между паролем для открытия и паролем защиты от записи?**

Пароль для открытия шифрует презентацию и требуется для загрузки её содержимого. Пароль защиты от записи ограничивает изменение без шифрования содержимого.

**Могу ли я проверить пароль для открытия без загрузки всех слайдов?**

Да. Получите информацию о презентации, проверьте наличие защиты паролем для открытия и проверьте пароль до создания полного экземпляра презентации.

**Может ли приложение считывать метаданные без пароля для открытия?**

Да, но только когда презентация зашифрована с отключённым шифрованием свойств документа. Приложение должно использовать режим загрузки только свойств документа, описанный в [Manage Presentation Properties](/slides/ru/androidjava/presentation-properties/).

**Поддерживают ли сценарии проверки пароля как PPT, так и PPTX?**

Да. Обнаружение и проверка пароля по пути к файлу и по потоку работают одинаково для презентаций PPT и PPTX.