---
title: In Bản Trình Chiếu
type: docs
url: /vi/net/print-the-presentation/
---
Aspose.Slides for .NET cung cấp bốn phương thức overload để in các bài thuyết trình. Các phương thức này đủ linh hoạt để in bản trình chiếu ra máy in mặc định hoặc bất kỳ máy in khả dụng nào với các cài đặt tùy chỉnh. Bạn chỉ cần chọn phương thức in phù hợp theo yêu cầu.

## **In ra máy in mặc định**
Việc in bản trình chiếu ra máy in mặc định khá đơn giản trong Aspose.Slides for .NET. Thực hiện các bước sau để in bản trình chiếu ra máy in mặc định:

- Tạo một thể hiện của lớp Presentation để tải bản trình chiếu cần in
- Gọi phương thức Print mà không có tham số như được cung cấp bởi đối tượng Presentation

``` csharp

 PrintByDefaultPrinter();

    PrintBySpecificPrinter();

}

public static void PrintByDefaultPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Tải bản trình chiếu

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Gọi phương thức in để in toàn bộ bản trình chiếu ra máy in mặc định

    asposePresentation.Print();

}

public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Tải bản trình chiếu

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Gọi phương thức in để in toàn bộ bản trình chiếu ra máy in mong muốn

    asposePresentation.Print("LaserJet1100");


``` 
## **In ra máy in cụ thể**
Việc in bản trình chiếu ra máy in cụ thể yêu cầu tên máy in làm tham số cho phương thức Print của Presentation. Thực hiện các bước sau để in bản trình chiếu ra máy in mong muốn:

- Tạo một thể hiện của lớp Presentation để tải bản trình chiếu cần in
- Gọi phương thức Print của lớp Presentation với tên máy in dưới dạng tham số kiểu string cho phương thức Print

``` csharp

 public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Tải bản trình chiếu

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Gọi phương thức in để in toàn bộ bản trình chiếu ra máy in mong muốn

    asposePresentation.Print("LaserJet1100");

}

``` 
## **Tải mã mẫu**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Print%20Presentation%20%28Aspose.Slides%29.zip)