---
title: Добавление цифровых подписей к презентациям на Android
linktitle: Цифровая подпись
type: docs
weight: 10
url: /ru/androidjava/digital-signature-in-powerpoint/
keywords:
- цифровая подпись
- цифровой сертификат
- удостоверяющий центр
- сертификат PFX
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Узнайте, как цифрово подписывать файлы PowerPoint и OpenDocument с помощью Aspose.Slides для Android. Защитите свои слайды за секунды с помощью понятных примеров кода на Java."
---

**Цифровой сертификат** используется для создания защищённой паролем презентации PowerPoint, отмеченной как созданная определённой организацией или лицом. Цифровый сертификат можно получить, обратившись в уполномоченную организацию — центр сертификации. После установки цифрового сертификата в систему его можно использовать для добавления цифровой подписи к презентации через Файл → Сведения → Защита презентации:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Презентация может содержать более одной цифровой подписи. После добавления цифровой подписи к презентации в PowerPoint появится специальное сообщение:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Для подписи презентации или проверки подлинности подписей презентации **Aspose.Slides API** предоставляет интерфейс [**IDigitalSignature**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IDigitalSignature), интерфейс [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IDigitalSignatureCollection) и метод [**IPresentation.getDigitalSignatures**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentation#getDigitalSignatures--) . В текущей версии цифровые подписи поддерживаются только для формата PPTX.
## **Добавить цифровую подпись из сертификата PFX**
Ниже приведён пример кода, демонстрирующий, как добавить цифровую подпись из сертификата PFX:

1. Откройте файл PFX и передайте пароль PFX объекту [**DigitalSignature**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/DigitalSignature).
2. Добавьте созданную подпись к объекту презентации.
```java
// Открытие файла презентации
Presentation pres = new Presentation();
try {
    // Создать объект DigitalSignature с файлом PFX и паролем PFX 
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", "testpass1");

    // Комментарий к новой цифровой подписи
    signature.setComments("Aspose.Slides digital signing test.");

    // Добавить цифровую подпись к презентации
    pres.getDigitalSignatures().add(signature);

    // Сохранить презентацию
    pres.save("SomePresentationSigned.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


Теперь можно проверить, была ли презентация подписана цифровой подписью и не была изменена:
```java
// Открыть презентацию
Presentation pres = new Presentation("SomePresentationSigned.pptx");
try {
    if (pres.getDigitalSignatures().size() > 0)
    {
        boolean allSignaturesAreValid = true;

        System.out.println("Signatures used to sign the presentation: ");

        // Проверить, все ли цифровые подписи действительны
        for (IDigitalSignature signature : pres.getDigitalSignatures())
        {
            System.out.println(signature.getComments() + ", "
                    + signature.getSignTime().toString() + " -- " + (signature.isValid() ? "VALID" : "INVALID"));
            allSignaturesAreValid &= signature.isValid();
        }

        if (allSignaturesAreValid)
            System.out.println("Presentation is genuine, all signatures are valid.");
        else
            System.out.println("Presentation has been modified since signing.");
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Часто задаваемые вопросы**

**Можно ли удалить существующие подписи из файла?**

Да. Коллекция цифровых подписей поддерживает [удаление отдельных элементов](https://reference.aspose.com/slides/androidjava/com.aspose.slides/digitalsignaturecollection/#removeAt-int-) и [полную очистку](https://reference.aspose.com/slides/androidjava/com.aspose.slides/digitalsignaturecollection/#clear--); после сохранения файла в презентации не будет подписей.

**Файл становится «только для чтения» после подписи?**

Нет. Подпись сохраняет целостность и оригинальность, но не блокирует редактирование. Чтобы ограничить редактирование, комбинируйте её с ["Только для чтения" или паролем](/slides/ru/androidjava/password-protected-presentation/).

**Отобразятся ли подписи корректно в разных версиях PowerPoint?**

Подпись создаётся для контейнера OOXML (PPTX). Современные версии PowerPoint, поддерживающие подписи OOXML, отображают статус таких подписей корректно.