---
title: Цифровая подпись в PowerPoint
type: docs
weight: 10
url: /ru/nodejs-java/digital-signature-in-powerpoint/
keywords: "Цифровой сертификат подписи, центр сертификации"
description: "Добавьте цифровой сертификат подписи, центр сертификации в презентацию PowerPoint с помощью Aspose.Slides."
---

**Цифровой сертификат** используется для создания защищённой паролем презентации PowerPoint, отмеченной как созданная определённой организацией или лицом. Цифровой сертификат можно получить, обратившись к уполномоченной организации — центру сертификации. После установки цифрового сертификата в систему его можно использовать для добавления цифровой подписи к презентации через File -> Info -> Protect Presentation:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Презентация может содержать более одной цифровой подписи. После того как цифровая подпись будет добавлена к презентации, в PowerPoint появится специальное сообщение:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Для подписания презентации или проверки подлинности подписей презентации **Aspose.Slides API** предоставляет класс [**DigitalSignature**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DigitalSignature), класс [**DigitalSignatureCollection**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DigitalSignatureCollection) и метод [**Presentation.getDigitalSignatures**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDigitalSignatures--). В настоящее время цифровые подписи поддерживаются только для формата PPTX.

## **Добавление цифровой подписи из сертификата PFX**
Ниже приведён пример кода, демонстрирующий, как добавить цифровую подпись из сертификата PFX:

1. Откройте файл PFX и передайте пароль PFX объекту [**DigitalSignature**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DigitalSignature).
1. Добавьте созданную подпись к объекту презентации.
```javascript
// Открытие файла презентации
var pres = new aspose.slides.Presentation();
try {
    // Создание объекта DigitalSignature с файлом PFX и паролем PFX
    var signature = new aspose.slides.DigitalSignature("testsignature1.pfx", "testpass1");
    // Установить комментарий к новой цифровой подписи
    signature.setComments("Aspose.Slides digital signing test.");
    // Добавить цифровую подпись к презентации
    pres.getDigitalSignatures().add(signature);
    // Сохранить презентацию
    pres.save("SomePresentationSigned.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


Теперь можно проверить, была ли презентация подписана цифровой подписью и не была изменена:
```javascript
// Открыть презентацию
var pres = new aspose.slides.Presentation("SomePresentationSigned.pptx");
try {
    if (pres.getDigitalSignatures().size() > 0) {
        var allSignaturesAreValid = true;
        console.log("Signatures used to sign the presentation: ");
        // Проверить, являются ли все цифровые подписи действительными
        for (let i = 0; i < pres.getDigitalSignatures().size(); i++) {
        let signature = pres.getDigitalSignatures().get_Item(i);
            console.log((((signature.getComments() + ", ") + signature.getSignTime().toString()) + " -- ") + (signature.isValid() ? "VALID" : "INVALID"));
            allSignaturesAreValid &= signature.isValid();
        }
        if (allSignaturesAreValid) {
            console.log("Presentation is genuine, all signatures are valid.");
        } else {
            console.log("Presentation has been modified since signing.");
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Можно ли удалить существующие подписи из файла?**

Да. Коллекция цифровых подписей поддерживает [removing individual items](https://reference.aspose.com/slides/nodejs-java/aspose.slides/digitalsignaturecollection/removeat/) и [clearing it entirely](https://reference.aspose.com/slides/nodejs-java/aspose.slides/digitalsignaturecollection/clear/); после сохранения файла презентация не будет содержать подписей.

**Становится ли файл «только для чтения» после подписи?**

Нет. Подпись сохраняет целостность и авторство, но не блокирует редактирование. Чтобы ограничить редактирование, сочетайте её с ["Read-only" or a password](/slides/ru/nodejs-java/password-protected-presentation/).

**Отобразится ли подпись корректно в разных версиях PowerPoint?**

Подпись создаётся для контейнера OOXML (PPTX). Современные версии PowerPoint, поддерживающие подписи OOXML, корректно отображают их статус.