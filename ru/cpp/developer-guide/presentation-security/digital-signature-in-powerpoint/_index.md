---
title: Добавление цифровых подписей к презентациям на C++
linktitle: Цифровая подпись
type: docs
weight: 10
url: /ru/cpp/digital-signature-in-powerpoint/
keywords:
- цифровая подпись
- цифровой сертификат
- центр сертификации
- сертификат PFX
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Узнайте, как цифрово подписывать файлы PowerPoint и OpenDocument с помощью Aspose.Slides для C++. Защитите свои слайды за секунды с помощью наглядных примеров кода."
---

**Цифровой сертификат** используется для создания презентации PowerPoint, защищённой паролем, помеченной как созданная определённой организацией или лицом. Цифровой сертификат можно получить, обратившись к уполномоченной организации — центру сертификации. После установки цифрового сертификата в систему им можно добавить цифровую подпись к презентации через Файл → Сведения → Защитить презентацию:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)



В презентации может быть более одной цифровой подписи. После того как цифровая подпись добавлена к презентации, в PowerPoint появляется специальное сообщение:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)



Для подписи презентации или проверки подлинности подписей презентации **Aspose.Slides API** предоставляет интерфейс [**IDigitalSignature**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_digital_signature), интерфейс [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_digital_signature_collection) и метод [**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_presentation#a6f78aff0f8ffa07ff67368fa003722b1). В настоящее время цифровые подписи поддерживаются только для формата PPTX.
## **Добавить цифровую подпись из сертификата PFX**
Ниже приведён пример кода, демонстрирующий, как добавить цифровую подпись из сертификата PFX:

1. Откройте файл PFX и передайте пароль PFX объекту [**DigitalSignature**](https://reference.aspose.com/slides/cpp/class/aspose.slides.digital_signature).
1. Добавьте созданную подпись к объекту презентации.
``` cpp
auto pres = System::MakeObject<Presentation>();

// Создать объект DigitalSignature с файлом PFX и паролем PFX 
auto signature = System::MakeObject<DigitalSignature>(u"testsignature1.pfx", u"testpass1");

// Комментарий к новой цифровой подписи
signature->set_Comments(u"Aspose.Slides digital signing test.");

// Добавить цифровую подпись к презентации
pres->get_DigitalSignatures()->Add(signature);

// Сохранить презентацию
pres->Save(u"SomePresentationSigned.pptx", SaveFormat::Pptx);
```


Теперь можно проверить, была ли презентация подписана цифровой подписью и не была ли изменена:
``` cpp
// Открыть презентацию
auto pres = System::MakeObject<Presentation>(u"SomePresentationSigned.pptx");

if (pres->get_DigitalSignatures()->get_Count() > 0)
{
    bool allSignaturesAreValid = true;

    Console::WriteLine(u"Signatures used to sign the presentation: ");

    // Проверить, являются ли все цифровые подписи действительными
    for (auto signature : pres->get_DigitalSignatures())
    {
        Console::WriteLine(signature->get_Certificate()->get_SubjectName()->get_Name() 
            + u", " 
            + signature->get_SignTime().ToString(u"yyyy-MM-dd HH:mm") 
            + u" -- " 
            + (signature->get_IsValid() ? System::String(u"VALID") : System::String(u"INVALID")));
        allSignaturesAreValid &= signature->get_IsValid();
    }

    if (allSignaturesAreValid)
    {
        Console::WriteLine(u"Presentation is genuine, all signatures are valid.");
    }
    else
    {
        Console::WriteLine(u"Presentation has been modified since signing.");
    }
}
```


## **FAQ**

**Можно ли удалить существующие подписи из файла?**

Да. Коллекция цифровых подписей поддерживает [удаление отдельных элементов](https://reference.aspose.com/slides/cpp/aspose.slides/digitalsignaturecollection/removeat/) и [полную очистку](https://reference.aspose.com/slides/cpp/aspose.slides/digitalsignaturecollection/clear/); после сохранения файла в презентации не будет подписей.

**Станет ли файл «только для чтения» после подписи?**

Нет. Подпись сохраняет целостность и авторство, но не блокирует редактирование. Чтобы ограничить редактирование, сочетайте её с [«Только для чтения» или паролем](/slides/ru/cpp/password-protected-presentation/).

**Будет ли подпись отображаться корректно в разных версиях PowerPoint?**

Подпись создана для контейнера OOXML (PPTX). Современные версии PowerPoint, поддерживающие подписи OOXML, корректно отображают статус таких подписей.