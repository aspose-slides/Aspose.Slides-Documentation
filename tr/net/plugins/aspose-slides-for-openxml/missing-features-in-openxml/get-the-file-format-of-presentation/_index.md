---
title: Sunumun Dosya Biçimini Alın
type: docs
weight: 50
url: /tr/net/get-the-file-format-of-presentation/
---
Dosya biçimini elde etmek için, lütfen aşağıdaki adımları izleyin:

- **IPresentationInfo** sınıfının bir örneğini oluşturun
- Sunum hakkında bilgi alın

Aşağıdaki örnekte dosya biçimini elde ettik.
## **Örnek**
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
## **Örnek Kodu İndir**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Çalışan Örneği İndir**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Getting%20the%20format%20of%20a%20file)