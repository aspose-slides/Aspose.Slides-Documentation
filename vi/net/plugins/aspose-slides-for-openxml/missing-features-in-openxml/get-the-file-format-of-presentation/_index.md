---
title: Lấy Định Dạng Tệp của Bản Trình Chiếu
type: docs
weight: 50
url: /vi/net/get-the-file-format-of-presentation/
aliases:
  - /net/presentation-format/
---
Để lấy định dạng tệp. Vui lòng thực hiện theo các bước dưới đây:

- Tạo một thể hiện của lớp **IPresentationInfo**
- Lấy thông tin về bản trình chiếu

Trong ví dụ dưới đây, chúng tôi đã lấy được định dạng tệp.
## **Ví dụ**
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
## **Tải mã mẫu**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Tải ví dụ đang chạy**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Getting%20the%20format%20of%20a%20file)