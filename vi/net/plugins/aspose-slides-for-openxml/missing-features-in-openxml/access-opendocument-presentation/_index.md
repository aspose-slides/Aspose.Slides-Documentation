---
title: Truy cập Trình chiếu OpenDocument
type: docs
weight: 10
url: /vi/net/access-opendocument-presentation/
---
Aspose.Slides for .NET cung cấp lớp **Presentation** đại diện cho một tệp trình chiếu. Lớp **Presentation** hiện cũng có thể truy cập **ODP** thông qua hàm tạo **Presentation** khi đối tượng được khởi tạo.
## **Ví dụ**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "OpenDocument Presentation.odp";

string destFileName = FilePath + "OpenDocument Presentation.pptx";

//Tạo một đối tượng Presentation đại diện cho một tệp trình chiếu

using (Presentation pres = new Presentation(srcFileName))

{

    //Lưu trình chiếu PPTX ở định dạng PPTX

    pres.Save(destFileName, SaveFormat.Pptx);

}

``` 
## **Tải mã mẫu**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Tải ví dụ chạy**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/OpenDocument%20Presentation)