---
title: Добавление цифровых подписей к презентациям в .NET
linktitle: Цифровая подпись
type: docs
weight: 10
url: /ru/net/digital-signature-in-powerpoint/
keywords:
- цифровая подпись
- цифровой сертификат
- центр сертификации
- сертификат PFX
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как цифрово подписывать файлы PowerPoint и OpenDocument с помощью Aspose.Slides для .NET. Защитите свои слайды за секунды с помощью понятных примеров кода."
---

**Цифровой сертификат** используется для создания презентации PowerPoint, защищённой паролем, отмеченной как созданная определённой организацией или лицом. Цифровой сертификат можно получить, обратившись в уполномоченную организацию — центр сертификации. После установки цифрового сертификата в системе им можно добавить цифровую подпись к презентации через File -> Info -> Protect Presentation:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Презентация может содержать более одной цифровой подписи. После добавления цифровой подписи к презентации в PowerPoint появится специальное сообщение:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Для подписи презентации или проверки подлинности её подписей **Aspose.Slides API** предоставляет интерфейсы [**IDigitalSignature**](https://reference.aspose.com/slides/net/aspose.slides/idigitalsignature), [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/net/aspose.slides/IDigitalSignatureCollection) и свойство [**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/properties/digitalsignatures). В настоящее время цифровые подписи поддерживаются только для формата PPTX.

## **Добавление цифровой подписи из сертификата PFX**
1. Откройте файл PFX и передайте пароль PFX объекту [**DigitalSignature**](https://reference.aspose.com/slides/net/aspose.slides/digitalsignature)object.
2. Добавьте созданную подпись в объект презентации.
```c#
using (Presentation pres = new Presentation())
{
    // Создать объект DigitalSignature с файлом PFX и паролем PFX 
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", @"testpass1");

    // Комментарий новой цифровой подписи
    signature.Comments = "Aspose.Slides digital signing test.";

    // Добавить цифровую подпись к презентации
    pres.DigitalSignatures.Add(signature);

    // Сохранить презентацию
    pres.Save("SomePresentationSigned.pptx", SaveFormat.Pptx);
}
```


Теперь можно проверить, была ли презентация подписана цифровой подписью и не была изменена:
```c#
// Открыть презентацию
using (Presentation pres = new Presentation("SomePresentationSigned.pptx"))
{
    if (pres.DigitalSignatures.Count > 0)
    {
        bool allSignaturesAreValid = true;

        Console.WriteLine("Signatures used to sign the presentation: ");

        // Проверить, являются ли все цифровые подписи действительными
        foreach (DigitalSignature signature in pres.DigitalSignatures)
        {
            Console.WriteLine(signature.Certificate.SubjectName.Name + ", "
                    + signature.SignTime.ToString("yyyy-MM-dd HH:mm") + " -- " + (signature.IsValid ? "VALID" : "INVALID"));
            allSignaturesAreValid &= signature.IsValid;
        }

        if (allSignaturesAreValid)
            Console.WriteLine("Presentation is genuine, all signatures are valid.");
        else
            Console.WriteLine("Presentation has been modified since signing.");
    }
}
```


## **Часто задаваемые вопросы**

**Можно ли удалить существующие подписи из файла?**

Да. Коллекция цифровых подписей поддерживает [удаление отдельных элементов](https://reference.aspose.com/slides/net/aspose.slides/digitalsignaturecollection/removeat/) и [полную очистку](https://reference.aspose.com/slides/net/aspose.slides/digitalsignaturecollection/clear/); после сохранения файла в презентации не будет подписей.

**Становится ли файл только для чтения после подписи?**

Нет. Подпись сохраняет целостность и авторство, но не блокирует редактирование. Чтобы ограничить редактирование, комбинируйте её с ["Read-only" or a password](/slides/ru/net/password-protected-presentation/).

**Будет ли подпись отображаться корректно в разных версиях PowerPoint?**

Подпись создаётся для контейнера OOXML (PPTX). Современные версии PowerPoint, поддерживающие подписи OOXML, отображают их статус корректно.