---
title: Добавление цифровых подписей к презентациям с помощью Python
linktitle: Цифровая подпись
type: docs
weight: 10
url: /ru/python-net/digital-signature-in-powerpoint/
keywords:
- digital signature
- digital certificate
- certificate authority
- PFX certificate
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Узнайте, как подписывать файлы PowerPoint и OpenDocument цифровой подписью с помощью Aspose.Slides for Python via .NET. Защитите свои слайды за секунды с помощью понятных примеров кода."
---

**Цифровой сертификат** используется для создания презентации PowerPoint, защищённой паролем, помеченной как созданная определённой организацией или лицом. Цифровой сертификат можно получить, обратившись в уполномоченную организацию — центр сертификации. После установки цифрового сертификата в систему его можно использовать для добавления цифровой подписи к презентации через **Файл → Свойства → Защитить презентацию**:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Презентация может содержать более одной цифровой подписи. После добавления цифровой подписи к презентации в PowerPoint появляется специальное сообщение:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Для подписания презентации или проверки подлинности подписей **Aspose.Slides API** предоставляет интерфейсы [**IDigitalSignature**](https://reference.aspose.com/slides/python-net/aspose.slides/idigitalsignature/), [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/IDigitalSignatureCollection/) и свойство [**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentation/). В настоящее время цифровые подписи поддерживаются только для формата PPTX.

## **Добавление цифровой подписи из сертификата PFX**
Ниже приведён пример кода, демонстрирующий, как добавить цифровую подпись из сертификата PFX:

1. Откройте файл PFX и передайте пароль PFX в объект [**DigitalSignature**](https://reference.aspose.com/slides/python-net/aspose.slides/digitalsignature/).
2. Добавьте созданную подпись к объекту презентации.

```py

#[TODO:Exception] RuntimeError: Proxy error(FileNotFoundException): Could not load file or assembly 'System.Security.Cryptography.Xml, Version=4.0.2.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'. File was not found.

import aspose.slides as slides

with slides.Presentation() as pres:
    # Создать объект DigitalSignature с файлом PFX и паролем PFX 
    signature = slides.DigitalSignature(path + "testsignature1.pfx", "testpass1")

    # Комментарий к новой цифровой подписи
    signature.comments = "Aspose.Slides digital signing test."

    # Добавить цифровую подпись к презентации
    pres.digital_signatures.add(signature)

    # Сохранить презентацию
    pres.save("SomePresentationSigned.pptx", slides.export.SaveFormat.PPTX)
```



Теперь можно проверить, подписана ли презентация цифровой подписью и не была ли изменена:

```py
# Открыть презентацию
with slides.Presentation("SomePresentationSigned.pptx") as pres:
    if len(pres.digital_signatures) > 0:
        allSignaturesAreValid = True

        print("Подписи, использованные для подписания презентации: ")
        # Проверить, действительны ли все цифровые подписи
        for signature in pres.digital_signatures :
            print(signature.certificate.subject_name.name + ", "
                    + signature.sign_time.strftime("yyyy-MM-dd HH:mm") + " -- " + "VALID" if signature.is_valid else "INVALID")
            allSignaturesAreValid = allSignaturesAreValid and signature.is_valid
        

        if allSignaturesAreValid:
            print("Презентация оригинальна, все подписи действительны.")
        else:
            print("Презентация была изменена после подписания.")
```

## **FAQ**

**Можно ли удалить существующие подписи из файла?**

Да. Коллекция цифровых подписей поддерживает [удаление отдельных элементов](https://reference.aspose.com/slides/python-net/aspose.slides/digitalsignaturecollection/remove_at/) и [полную очистку](https://reference.aspose.com/slides/python-net/aspose.slides/digitalsignaturecollection/clear/); после сохранения файла в презентации не будет подписей.

**Становится ли файл «только для чтения» после подписи?**

Нет. Подпись сохраняет целостность и авторство, но не блокирует редакцию. Чтобы ограничить редактирование, комбинируйте её с ["Только для чтения" или паролем](/slides/ru/python-net/password-protected-presentation/).

**Будет ли подпись корректно отображаться в разных версиях PowerPoint?**

Подпись создаётся для контейнера OOXML (PPTX). Современные версии PowerPoint, поддерживающие подписи OOXML, корректно отображают их статус.