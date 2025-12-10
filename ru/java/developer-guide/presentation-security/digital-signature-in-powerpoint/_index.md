---
title: Добавить цифровые подписи к презентациям в Java
linktitle: Цифровая подпись
type: docs
weight: 10
url: /ru/java/digital-signature-in-powerpoint/
keywords:
- цифровая подпись
- цифровой сертификат
- центр сертификации
- сертификат PFX
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Узнайте, как цифровой подписью подписывать файлы PowerPoint и OpenDocument с помощью Aspose.Slides для Java. Защитите свои слайды за секунды с помощью понятных примеров кода."
---

**Цифровой сертификат** используется для создания защищённой паролем презентации PowerPoint, отмеченной как созданная определённой организацией или лицом. Цифровой сертификат можно получить, обратившись в уполномоченную организацию — центр сертификации. После установки цифрового сертификата в систему им можно добавить цифровую подпись к презентации через Файл → Сведения → Защитить презентацию:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Презентация может содержать более одной цифровой подписи. После добавления цифровой подписи к презентации в PowerPoint появится специальное сообщение:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Для подписи презентации или проверки подлинности её подписей **Aspose.Slides API** предоставляет интерфейс **IDigitalSignature**, интерфейс **IDigitalSignatureCollection** и метод IPresentation.getDigitalSignatures. В настоящее время цифровые подписи поддерживаются только для формата PPTX.

## **Добавление цифровой подписи из сертификата PFX**
Приведённый ниже образец кода демонстрирует, как добавить цифровую подпись из сертификата PFX:

1. Откройте файл PFX и передайте пароль PFX объекту DigitalSignature.
2. Добавьте созданную подпись к объекту презентации.
```java
// Открытие файла презентации
Presentation pres = new Presentation();
try {
    // Создание объекта DigitalSignature с PFX-файлом и паролем PFX 
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", "testpass1");

    // Комментарий к новой цифровой подписи
    signature.setComments("Aspose.Slides digital signing test.");

    // Добавление цифровой подписи к презентации
    pres.getDigitalSignatures().add(signature);

    // Сохранение презентации
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

        // Проверить, являются ли все цифровые подписи действительными
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


## **FAQ**

**Можно ли удалить существующие подписи из файла?**

Да. Коллекция цифровых подписей поддерживает [удаление отдельных элементов](https://reference.aspose.com/slides/java/com.aspose.slides/digitalsignaturecollection/#removeAt-int-) и [полную очистку](https://reference.aspose.com/slides/java/com.aspose.slides/digitalsignaturecollection/#clear--); после сохранения файла презентация не будет иметь подписей.

**Становится ли файл "только для чтения" после подписи?**

Нет. Подпись сохраняет целостность и авторство, но не блокирует редактирование. Чтобы ограничить редактирование, комбинируйте её с ["Read-only" or a password](/slides/ru/java/password-protected-presentation/).

**Отображается ли подпись корректно в разных версиях PowerPoint?**

Подпись создаётся для контейнера OOXML (PPTX). Современные версии PowerPoint, поддерживающие подписи OOXML, корректно отображают их статус.