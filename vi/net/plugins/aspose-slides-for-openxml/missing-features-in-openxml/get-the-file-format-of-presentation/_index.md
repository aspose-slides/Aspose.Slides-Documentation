---
title: Lấy Định Dạng Tệp của Bản Trình Bày
type: docs
weight: 50
url: /vi/net/get-the-file-format-of-presentation/
---
Để lấy định dạng tệp, vui lòng thực hiện các bước sau:

- Tạo một thể hiện của lớp **IPresentationInfo**
- Lấy thông tin về bản trình bày

Trong ví dụ dưới đây, chúng tôi đã nhận được định dạng tệp.
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
## **Tải Mã Mẫu**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Tải Ví Dụ Đang Chạy**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Getting%20the%20format%20of%20a%20file)