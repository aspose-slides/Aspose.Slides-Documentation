---
title: Добавить цифровые подписи к презентациям с помощью Python
linktitle: Цифровая подпись
type: docs
weight: 10
url: /ru/python-net/digital-signature-in-powerpoint/
keywords:
- цифровая подпись
- цифровой сертификат
- центр сертификации
- сертификат PFX
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как цифровой подписывать файлы PowerPoint и OpenDocument с помощью Aspose.Slides для Python через .NET. Защитите свои слайды за секунды с понятными примерами кода."
---

**Digital certificate** используется для создания защищённой паролем презентации PowerPoint, отмеченной как созданная конкретной организацией или лицом. Цифровой сертификат можно получить, обратившись в уполномоченную организацию — центр сертификации. После установки цифрового сертификата в системе его можно использовать для добавления цифровой подписи к презентации через File -> Info -> Protect Presentation:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Презентация может содержать более одной цифровой подписи. После добавления цифровой подписи к презентации в PowerPoint появится специальное сообщение:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Для подписи презентации или проверки подлинности подписей презентации **Aspose.Slides API** предоставляет [**IDigitalSignature**](https://reference.aspose.com/slides/python-net/aspose.slides/idigitalsignature/) интерфейс, [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/IDigitalSignatureCollection/) интерфейс и [**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentation/) свойство. В настоящее время цифровые подписи поддерживаются только для формата PPTX.

## **Добавить цифровую подпись из сертификата PFX**
Ниже приведён пример кода, показывающий, как добавить цифровую подпись из сертификата PFX:

1. Откройте файл PFX и передайте пароль PFX объекту DigitalSignature.
2. Добавьте созданную подпись к объекту презентации.

```py
#[TODO:Exception] RuntimeError: Ошибка прокси(FileNotFoundException): Не удалось загрузить файл или сборку 'System.Security.Cryptography.Xml, Version=4.0.2.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'. Файл не найден.

import aspose.slides as slides

with slides.Presentation() as pres:
    # Создать объект DigitalSignature с файлом PFX и паролем PFX
    signature = slides.DigitalSignature(path + "testsignature1.pfx", "testpass1")

    # Комментарий новой цифровой подписи
    signature.comments = "Aspose.Slides digital signing test."

    # Добавить цифровую подпись к презентации
    pres.digital_signatures.add(signature)

    # сохранить презентацию
    pres.save("SomePresentationSigned.pptx", slides.export.SaveFormat.PPTX)
```

Теперь можно проверить, была ли презентация подписана цифровой подписью и не была изменена:

```py
# Открыть презентацию
with slides.Presentation("SomePresentationSigned.pptx") as pres:
    if len(pres.digital_signatures) > 0:
        allSignaturesAreValid = True

        print("Signatures used to sign the presentation: ")
        # Проверить, являются ли все цифровые подписи действительными
        for signature in pres.digital_signatures :
            print(signature.certificate.subject_name.name + ", "
                    + signature.sign_time.strftime("yyyy-MM-dd HH:mm") + " -- " + "VALID" if signature.is_valid else "INVALID")
            allSignaturesAreValid = allSignaturesAreValid and signature.is_valid
        

        if allSignaturesAreValid:
            print("Presentation is genuine, all signatures are valid.")
        else:
            print("Presentation has been modified since signing.")
```

## **FAQ**

**Можно ли удалить существующие подписи из файла?**

Да. Коллекция цифровых подписей поддерживает [удаление отдельных элементов](https://reference.aspose.com/slides/python-net/aspose.slides/digitalsignaturecollection/remove_at/) и [полную очистку](https://reference.aspose.com/slides/python-net/aspose.slides/digitalsignaturecollection/clear/); после сохранения файла в презентации не будет подписей.

**Станет ли файл «только для чтения» после подписи?**

Нет. Подпись сохраняет целостность и авторство, но не блокирует редактирование. Чтобы ограничить редактирование, комбинируйте её с ["Только для чтения" или паролем](/slides/ru/python-net/password-protected-presentation/).

**Отобразится ли подпись корректно в разных версиях PowerPoint?**

Подпись создаётся для контейнера OOXML (PPTX). Современные версии PowerPoint, поддерживающие подписи OOXML, отображают статус таких подписей корректно.