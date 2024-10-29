---
title: Цифровая подпись в PowerPoint
type: docs
weight: 10
url: /ru/net/digital-signature-in-powerpoint/
keywords: "Цифровой сертификат подписи, удостоверяющий центр, презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Добавьте цифровую подпись или сертификат в PowerPoint. Удостоверяющий центр в C# или .NET"
---


**Цифровой сертификат** используется для создания защищенной паролем презентации PowerPoint, помеченной как созданная определенной организацией или человеком. Цифровой сертификат можно получить, обратившись в уполномоченную организацию - удостоверяющий центр. После установки цифрового сертификата в систему его можно использовать для добавления цифровой подписи к презентации через Файл -> Сведения -> Защитить презентацию:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)



Презентация может содержать более одной цифровой подписи. После добавления цифровой подписи к презентации в PowerPoint появится специальное сообщение:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)



Для подписания презентации или проверки подлинности подписей в презентации **Aspose.Slides API** предоставляет [**IDigitalSignature** ](https://reference.aspose.com/slides/net/aspose.slides/idigitalsignature)интерфейс, [**IDigitalSignatureCollection** ](https://reference.aspose.com/slides/net/aspose.slides/IDigitalSignatureCollection)интерфейс и[ **IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/properties/digitalsignatures) свойство. На данный момент цифровые подписи поддерживаются только для формата PPTX.
## **Добавить цифровую подпись из сертификата PFX**
Пример кода ниже демонстрирует, как добавить цифровую подпись из сертификата PFX:

1. Откройте файл PFX и передайте пароль PFX в [**DigitalSignature** ](https://reference.aspose.com/slides/net/aspose.slides/digitalsignature)объект.
1. Добавьте созданную подпись в объект презентации.

```c#
using (Presentation pres = new Presentation())
{
    // Создание объекта DigitalSignature с файлом PFX и паролем PFX 
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", @"testpass1");

    // Комментарий к новой цифровой подписи
    signature.Comments = "Тест цифровой подписи Aspose.Slides.";

    // Добавление цифровой подписи к презентации
    pres.DigitalSignatures.Add(signature);

    // Сохранение презентации
    pres.Save("SomePresentationSigned.pptx", SaveFormat.Pptx);
}
```



Теперь возможно проверить, была ли презентация цифровой подписью и не была ли изменена:



```c#
// Открытие презентации
using (Presentation pres = new Presentation("SomePresentationSigned.pptx"))
{
    if (pres.DigitalSignatures.Count > 0)
    {
        bool allSignaturesAreValid = true;

        Console.WriteLine("Подписи, используемые для подписания презентации: ");

        // Проверка, все ли цифровые подписи действительны
        foreach (DigitalSignature signature in pres.DigitalSignatures)
        {
            Console.WriteLine(signature.Certificate.SubjectName.Name + ", "
                    + signature.SignTime.ToString("yyyy-MM-dd HH:mm") + " -- " + (signature.IsValid ? "ДЕЙСТВИТЕЛЬНА" : "НЕДЕЙСТВИТЕЛЬНА"));
            allSignaturesAreValid &= signature.IsValid;
        }

        if (allSignaturesAreValid)
            Console.WriteLine("Презентация подлинная, все подписи действительны.");
        else
            Console.WriteLine("Презентация была изменена с момента подписания.");
    }
}
```