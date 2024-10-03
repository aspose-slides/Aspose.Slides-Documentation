---
title: Получить формат файла презентации
type: docs
weight: 50
url: /ru/net/get-the-file-format-of-presentation/
---

Чтобы получить формат файла, выполните следующие шаги:

- Создайте экземпляр класса **IPresentationInfo**
- Получите информацию о презентации

В приведенном ниже примере мы получили формат файла.
## **Пример**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Получение формата файла.pptx";

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
## **Скачать образец кода**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
## **Скачать работающий пример**
- [Codeplex](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Getting%20the%20format%20of%20a%20file)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Getting%20the%20format%20of%20a%20file)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c/view/SourceCode)