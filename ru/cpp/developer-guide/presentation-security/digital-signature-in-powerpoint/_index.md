---
title: Цифровая подпись в PowerPoint
type: docs
weight: 10
url: /cpp/digital-signature-in-powerpoint/
keywords: "Цифровой сертификат подписи, удостоверяющий центр"
description: "Добавьте сертификат цифровой подписи и удостоверяющий центр в презентацию PowerPoint с помощью Aspose.Slides."
---

**Цифровой сертификат** используется для создания защищённой паролем презентации PowerPoint, отмеченной как созданная определенной организацией или лицом. Цифровой сертификат можно получить, обратившись в уполномоченную организацию - удостоверяющий центр. После установки цифрового сертификата в систему его можно использовать для добавления цифровой подписи к презентации через Файл -> Сведения -> Защитить презентацию:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Презентация может содержать более одной цифровой подписи. После добавления цифровой подписи в презентацию в PowerPoint появится специальное сообщение:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Чтобы подписать презентацию или проверить подлинность подписей презентации, **Aspose.Slides API** предоставляет [**IDigitalSignature** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_digital_signature)интерфейс, [**IDigitalSignatureCollection** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_digital_signature_collection)интерфейс и[ **IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_presentation#a6f78aff0f8ffa07ff67368fa003722b1) метод. В настоящее время поддерживаются цифровые подписи только для формата PPTX.
## **Добавить цифровую подпись из сертификата PFX**
Пример кода ниже демонстрирует, как добавить цифровую подпись из сертификата PFX:

1. Откройте файл PFX и передайте пароль PFX в [**DigitalSignature** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.digital_signature)объект.
1. Добавьте созданную подпись к объекту презентации.

``` cpp
auto pres = System::MakeObject<Presentation>();

// Создайте объект DigitalSignature с файлом PFX и паролем PFX 
auto signature = System::MakeObject<DigitalSignature>(u"testsignature1.pfx", u"testpass1");

// Комментарий к новой цифровой подписи
signature->set_Comments(u"Тест цифровой подписи Aspose.Slides.");

// Добавьте цифровую подпись к презентации
pres->get_DigitalSignatures()->Add(signature);

// Сохраните презентацию
pres->Save(u"SomePresentationSigned.pptx", SaveFormat::Pptx);
```

Теперь можно проверить, была ли презентация подписана цифровой подписью и не была ли изменена:

``` cpp
// Откройте презентацию
auto pres = System::MakeObject<Presentation>(u"SomePresentationSigned.pptx");

if (pres->get_DigitalSignatures()->get_Count() > 0)
{
    bool allSignaturesAreValid = true;

    Console::WriteLine(u"Подписи, использованные для подписания презентации: ");

    // Проверьте, действительны ли все цифровые подписи
    for (auto signature : pres->get_DigitalSignatures())
    {
        Console::WriteLine(signature->get_Certificate()->get_SubjectName()->get_Name() 
            + u", " 
            + signature->get_SignTime().ToString(u"yyyy-MM-dd HH:mm") 
            + u" -- " 
            + (signature->get_IsValid() ? System::String(u"ДЕЙСТВИТЕЛЬНО") : System::String(u"НЕДЕЙСТВИТЕЛЬНО")));
        allSignaturesAreValid &= signature->get_IsValid();
    }

    if (allSignaturesAreValid)
    {
        Console::WriteLine(u"Презентация подлинная, все подписи действительные.");
    }
    else
    {
        Console::WriteLine(u"Презентация была изменена с момента подписания.");
    }
}
```