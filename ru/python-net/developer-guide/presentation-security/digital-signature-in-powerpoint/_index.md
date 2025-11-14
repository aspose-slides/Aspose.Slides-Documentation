---
title: Добавляйте цифровые подписи к презентациям с помощью Python
linktitle: Цифровая подпись
type: docs
weight: 10
url: /ru/python-net/digital-signature-in-powerpoint/
keywords:
  - цифровая подпись
  - цифровой сертификат
  - центр сертификации
  - PFX-сертификат
  - PowerPoint
  - OpenDocument
  - презентация
  - Python
  - Aspose.Slides
description: "Узнайте, как цифровым образом подписывать файлы PowerPoint и OpenDocument с помощью Aspose.Slides for Python via .NET. Защитите ваши слайды за секунды с помощью понятных примеров кода."
---


**Цифровой сертификат** используется для создания презентации PowerPoint с защищенным паролем, помеченной как созданная определенной организацией или лицом. Цифровой сертификат можно получить, обратившись в уполномоченную организацию – удостоверяющий центр. После установки цифрового сертификата в систему его можно использовать для добавления цифровой подписи к презентации через Файл -> Информация -> Защитить презентацию:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)



Презентация может содержать более одной цифровой подписи. После добавления цифровой подписи к презентации в PowerPoint появится специальное сообщение:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)



Чтобы подписать презентацию или проверить подлинность подписей в презентации, **Aspose.Slides API** предоставляет интерфейсы [**IDigitalSignature**](https://reference.aspose.com/slides/python-net/aspose.slides/idigitalsignature/) и [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/IDigitalSignatureCollection/) и свойство [**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentation/). В настоящее время цифровые подписи поддерживаются только для формата PPTX.
## **Добавить цифровую подпись из сертификата PFX**
Пример кода ниже демонстрирует, как добавить цифровую подпись из сертификата PFX:

1. Откройте файл PFX и передайте пароль PFX объекту [**DigitalSignature**](https://reference.aspose.com/slides/python-net/aspose.slides/digitalsignature/).
1. Добавьте созданную подпись к объекту презентации.

```py

#[TODO:Исключение] RuntimeError: Ошибка прокси (FileNotFoundException): Невозможно загрузить файл или сборку 'System.Security.Cryptography.Xml, Version=4.0.2.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'. Файл не найден.

import aspose.slides as slides

with slides.Presentation() as pres:
    # Создать объект DigitalSignature с файлом PFX и паролем PFX 
    signature = slides.DigitalSignature(path + "testsignature1.pfx", "testpass1")

    # Прокомментировать новую цифровую подпись
    signature.comments = "Тест цифровой подписи Aspose.Slides."

    # Добавить цифровую подпись к презентации
    pres.digital_signatures.add(signature)

    # сохранить презентацию
    pres.save("НекотораяПодписаннаяПрезентация.pptx", slides.export.SaveFormat.PPTX)
```



Теперь можно проверить, была ли презентация цифровой подписью и не была ли она изменена:



```py
# Открыть презентацию
with slides.Presentation("НекотораяПодписаннаяПрезентация.pptx") as pres:
    if len(pres.digital_signatures) > 0:
        всеПодписиДействительны = True

        print("Подписи, использованные для подписания презентации: ")
        # Проверить, действительны ли все цифровые подписи
        for signature in pres.digital_signatures :
            print(signature.certificate.subject_name.name + ", "
                    + signature.sign_time.strftime("yyyy-MM-dd HH:mm") + " -- " + "ДЕЙСТВИТЕЛЬНА" if signature.is_valid else "НЕДЕЙСТВИТЕЛЬНА")
            всеПодписиДействительны = всеПодписиДействительны and signature.is_valid
        

        if всеПодписиДействительны:
            print("Презентация подлинная, все подписи действительны.")
        else:
            print("Презентация была изменена с момента подписания.")
```