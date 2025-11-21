---
title: Цифровая подпись в PowerPoint
type: docs
weight: 10
url: /ru/net/digital-signature-in-powerpoint/
keywords: "Цифровой сертификат подписи, центр сертификации, презентация PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Добавление цифровой подписи или сертификата в PowerPoint. Центр сертификации в C# или .NET"
---

**Digital certificate** используется для создания презентации PowerPoint, защищённой паролем и помеченной как созданной определённой организацией или лицом. Digital certificate можно получить, обратившись в уполномоченную организацию — центр сертификации. После установки цифрового сертификата в систему его можно использовать для добавления цифровой подписи к презентации через Файл → Сведения → Защита презентации:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Презентация может содержать более одной цифровой подписи. После добавления цифровой подписи к презентации в PowerPoint появится специальное сообщение:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Для подписи презентации или проверки подлинности подписей презентации **Aspose.Slides API** предоставляет интерфейсы [**IDigitalSignature**](https://reference.aspose.com/slides/net/aspose.slides/idigitalsignature), [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/net/aspose.slides/IDigitalSignatureCollection) и свойство [**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/properties/digitalsignatures). В настоящее время цифровые подписи поддерживаются только для формата PPTX.
## **Add Digital Signature from PFX Certificate**
Ниже приведён пример кода, демонстрирующий, как добавить цифровую подпись из сертификата PFX:

1. Откройте файл PFX и передайте пароль PFX объекту [**DigitalSignature**](https://reference.aspose.com/slides/net/aspose.slides/digitalsignature).
2. Добавьте созданную подпись к объекту презентации.
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


Теперь можно проверить, была ли презентация цифрово подписана и не была изменена:
```c#
// Открыть презентацию
using (Presentation pres = new Presentation("SomePresentationSigned.pptx"))
{
    if (pres.DigitalSignatures.Count > 0)
    {
        bool allSignaturesAreValid = true;

        Console.WriteLine("Signatures used to sign the presentation: ");

        // Проверить, все ли цифровые подписи действительны
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


## **FAQ**

**Можно ли удалить существующие подписи из файла?**

Да. Коллекция цифровых подписей поддерживает [удаление отдельных элементов](https://reference.aspose.com/slides/net/aspose.slides/digitalsignaturecollection/removeat/) и [полную очистку](https://reference.aspose.com/slides/net/aspose.slides/digitalsignaturecollection/clear/); после сохранения файла в презентации не будет подписей.

**Станет ли файл “только для чтения” после подписания?**

Нет. Подпись сохраняет целостность и авторство, но не блокирует редактирование. Чтобы ограничить редактирование, комбинируйте её с ["Только для чтения" или паролем](/slides/ru/net/password-protected-presentation/).

**Будет ли подпись корректно отображаться в разных версиях PowerPoint?**

Подпись создаётся для контейнера OOXML (PPTX). Современные версии PowerPoint, поддерживающие подписи OOXML, корректно отображают их статус.