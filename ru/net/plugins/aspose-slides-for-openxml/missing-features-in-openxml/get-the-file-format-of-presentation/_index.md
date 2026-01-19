---
title: Получить формат файла презентации
type: docs
weight: 50
url: /ru/net/get-the-file-format-of-presentation/
---

Чтобы получить формат файла, выполните следующие шаги:

- Создайте экземпляр класса **IPresentationInfo**
- Получите информацию о презентации

В приведённом ниже примере мы получаем формат файла.
## **Пример**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Getting the format of a file.pptx";

IPresentationInfo info;

info = PresentationFactory.Instance.GetPresentationInfo(FileName);


switch (info.LoadFormat)

{

    case LoadFormat.Pptx:

        {

            break;

        }

    case LoadFormat.Unknown:

        {

            break;

        }

}

``` 
## **Скачать пример кода**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Скачать работающий пример**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Getting%20the%20format%20of%20a%20file)