---
title: Цифровая подпись в PowerPoint
type: docs
weight: 10
url: /androidjava/digital-signature-in-powerpoint/
keywords: "Цифровой сертификат подписи, удостоверяющий центр"
description: "Добавьте цифровой сертификат подписи, удостоверяющий центр в презентацию PowerPoint с помощью Aspose.Slides."
---

**Цифровой сертификат** используется для создания презентации в PowerPoint с защитой паролем, помеченной как созданная определенной организацией или лицом. Цифровой сертификат можно получить, обратившись в уполномоченную организацию - удостоверяющий центр. После установки цифрового сертификата в систему его можно использовать для добавления цифровой подписи в презентацию через Файл -> Сведения -> Защитить презентацию:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Презентация может содержать более одной цифровой подписи. После добавления цифровой подписи в презентацию в PowerPoint появится специальное сообщение:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Для подписания презентации или проверки подлинности подписи презентации **Aspose.Slides API** предоставляет интерфейс [**IDigitalSignature**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IDigitalSignature), интерфейс [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IDigitalSignatureCollection) и метод [**IPresentation.getDigitalSignatures**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentation#getDigitalSignatures--). В настоящее время цифровые подписи поддерживаются только для формата PPTX.
## **Добавление цифровой подписи из сертификата PFX**
Ниже приведен пример кода, который демонстрирует, как добавить цифровую подпись из сертификата PFX:

1. Откройте файл PFX и передайте пароль PFX в объект [**DigitalSignature**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/DigitalSignature).
1. Добавьте созданную подпись в объект презентации.

```java
// Открытие файла презентации
Presentation pres = new Presentation();
try {
    // Создание объекта DigitalSignature с файлом PFX и паролем PFX 
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", "testpass1");

    // Комментарий к новой цифровой подписи
    signature.setComments("Тест цифровой подписи Aspose.Slides.");

    // Добавление цифровой подписи в презентацию
    pres.getDigitalSignatures().add(signature);

    // Сохранение презентации
    pres.save("SomePresentationSigned.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Теперь можно проверить, была ли презентация цифровым образом подписана и не была ли изменена:

```java
// Открытие презентации
Presentation pres = new Presentation("SomePresentationSigned.pptx");
try {
    if (pres.getDigitalSignatures().size() > 0)
    {
        boolean allSignaturesAreValid = true;

        System.out.println("Подписи, использованные для подписания презентации: ");

        // Проверка, являются ли все цифровые подписи действительными
        for (IDigitalSignature signature : pres.getDigitalSignatures())
        {
            System.out.println(signature.getComments() + ", "
                    + signature.getSignTime().toString() + " -- " + (signature.isValid() ? "ДОПУСТИМО" : "НЕДОПУСТИМО"));
            allSignaturesAreValid &= signature.isValid();
        }

        if (allSignaturesAreValid)
            System.out.println("Презентация подлинная, все подписи действительны.");
        else
            System.out.println("Презентация была изменена с момента подписания.");
    }
} finally {
    if (pres != null) pres.dispose();
}
```