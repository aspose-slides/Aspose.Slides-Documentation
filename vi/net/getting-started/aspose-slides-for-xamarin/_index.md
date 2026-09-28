---
title: Aspose.Slides cho Xamarin (Lịch sử)
linktitle: Xamarin (Lịch sử)
type: docs
weight: 200
url: /vi/net/aspose-slides-for-xamarin/
keywords:
- Xamarin
- phát triển di động
- Android
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Lịch sử: cách Aspose.Slides cho .NET phiên bản 20.2 đến 22.10 hỗ trợ Xamarin.Android thông qua một thư viện riêng. Các phiên bản hiện tại không bao gồm nó."
---
{{% alert color="info" title="Lưu ý" %}}

Đây là một trang lịch sử. Các phiên bản 20.2 đến 22.10 của gói Aspose.Slides.NET bao gồm một thư viện Xamarin.Android riêng biệt, *Aspose.Slides.Droid.dll*, mà mã trên trang này sử dụng. Các phiên bản sau không còn bao gồm nó: gói hiện tại chỉ chứa các bản dựng cho .NET Framework 4.6.2, .NET 6 và .NET Standard 2.0. Microsoft đã ngừng hỗ trợ tất cả các SDK Xamarin vào ngày 1‑5‑2024; xem [chính sách hỗ trợ Xamarin](https://dotnet.microsoft.com/en-us/platform/support/policy/xamarin).

{{% /alert %}}

## **Giới thiệu**

Xamarin là một khung công tác được sử dụng cho phát triển di động trong .NET C#. Xamarin có các công cụ và thư viện mở rộng khả năng của nền tảng .NET. Nó cho phép các nhà phát triển xây dựng các ứng dụng cho hệ điều hành **Android**.

{{% alert color="info" title="Lưu ý" %}}

Đối với phát triển trên Xamarin, lập trình viên có thể sử dụng môi trường phát triển thường ngày của mình (C#, Visual Studio và các thư viện của bên thứ ba).

{{% /alert %}}

API Aspose.Slides đã hoạt động trên nền tảng Xamarin. Để đạt được điều này, gói Aspose.Slides.NET, trong các phiên bản 20.2 đến 22.10, đã thêm một DLL riêng cho Xamarin. Aspose.Slides cho Xamarin hỗ trợ hầu hết các tính năng có trong phiên bản .NET:

- chuyển đổi và xem bản trình chiếu.
- chỉnh sửa nội dung trong bản trình chiếu: văn bản, hình dạng, biểu đồ, SmartArt, âm thanh/video, phông chữ, v.v.
- xử lý hoạt ảnh, hiệu ứng 2D, WordArt, v.v.
- xử lý siêu dữ liệu và thuộc tính tài liệu.
- sao chép, hợp nhất, so sánh, tách, v.v.

Chúng tôi đã cung cấp một bảng so sánh đầy đủ các tính năng ở một phần khác gần cuối trang này.

Trong API Aspose.Slides cho Xamarin, các lớp, không gian tên, logic và hành vi được giữ càng giống càng tốt với phiên bản .NET. Bạn có thể di chuyển các ứng dụng Aspose.Slides .NET sang Xamarin với chi phí tối thiểu.

## **Ví dụ nhanh**
Bạn có thể sử dụng Aspose.Slides cho Xamarin để xây dựng và tận dụng ứng dụng C# của mình thông qua Slides cho Android.

Chúng tôi cung cấp một ví dụ về ứng dụng Android qua Xamarin sử dụng Aspose.Slides để hiển thị các slide bài thuyết trình và thêm một hình dạng mới trên slide khi chạm. Bạn có thể tìm toàn bộ mã nguồn của các ví dụ trên [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Xamarin).

Hãy bắt đầu bằng việc tạo một ứng dụng Xamarin Android:

![Tạo một ứng dụng Xamarin Android](https://lh3.googleusercontent.com/sNkKZnuuGo8phWI-4g4jRA_ZESKpO9RXehPj46RVymXGPcCJuYooePXcBEcb7N6uUUxgocl4o9OjwnajzWKmL2i4MUz3gKKwXw6C0ow_VScN8vlyGBK3SpLKoE_m9BDJ3iNE4xPj)

Đầu tiên, chúng ta tạo một bố cục nội dung chứa một ImageView, nút Prev và Next:

![Bố cục nội dung với ImageView và nút Prev, Next](https://lh3.googleusercontent.com/rX9leIvYTVzQa0YAMj_jPUPs-c9_HwGPZUfR5A3FLiTk0-qzUQ29FfM4hammUVXbbw_Ly0LwEM_VnaI6vslEEMcVlEwVMem0LTiX5kYsA4lxtiHrvXfDPruWPOGU1YKDYSWcNM54)

**XML - content_main.xml - Tạo bố cục nội dung**
```xml
 <LinearLayout
    xmlns:android="http://schemas.android.com/apk/res/android"
    xmlns:app="http://schemas.android.com/apk/res-auto"
    xmlns:tools="http://schemas.android.com/tools"
    android:orientation=    "vertical"
    android:layout_width="match_parent"
    android:layout_height="match_parent"
    tools:showIn="@layout/activity_main">
    <LinearLayout
        android:orientation="horizontal"
        android:layout_width="match_parent"
        android:layout_height="match_parent"
        android:layout_weight="1"
        android:id="@+id/linearLayout1">
        <ImageView
            android:src="@android:drawable/ic_menu_gallery"
            android:layout_width="match_parent"
            android:layout_height="match_parent"
            android:id="@+id/imageView"
            android:scaleType="fitCenter" />
    </LinearLayout>

    <LinearLayout
        android:orientation="horizontal"
        android:layout_width="match_parent"
        android:layout_height="match_parent"
        android:layout_weight="10"
        android:id="@+id/linearLayout2">
        <Button
            android:text="Prev"
            android:layout_width="wrap_content"
            android:layout_height="wrap_content"
            android:id="@+id/buttonPrev" />
        <Button
            android:text="Next"
            android:layout_width="wrap_content"
            android:layout_height="wrap_content"
            android:id="@+id/buttonNext"/>
    </LinearLayout>
</LinearLayout>
```

Ở đây, chúng tôi tham chiếu thư viện "Aspose.Slides.Droid.dll" chứa một bản trình chiếu mẫu ("HelloWorld.pptx") vào tài sản (Assets) của ứng dụng Xamarin và thêm khởi tạo của nó vào MainActivity:

**C# - MainActivity.cs - Khởi tạo**

``` csharp
using System.Diagnostics;
using Aspose.Slides.Theme;

[Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
public class MainActivity : AppCompatActivity
{
    private Aspose.Slides.Presentation presentation;

    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        SetContentView(Resource.Layout.activity_main);
    }

    protected override void OnResume()
    {
        if (presentation == null)
        {
            using (Stream input = Assets.Open("HelloWorld.pptx"))
            {
                presentation = new Aspose.Slides.Presentation(input);
            }
        }
    }

    protected override void OnPause()
    {
        if (presentation != null)
        {
            presentation.Dispose();
            presentation = null;
        }
    }
}
```

Thêm hàm để hiển thị các slide Prev và Next khi nhấn nút:

**C# - MainActivity.cs - Hiển thị slide khi nhấn nút Prev và Next**

``` csharp
using System.Diagnostics;
using Aspose.Slides.Theme;

[Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
public class MainActivity : AppCompatActivity
{
    private Button buttonNext;
    private Button buttonPrev;
    ImageView imageView;

    private Aspose.Slides.Presentation presentation;

    private int currentSlideNumber;

    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        SetContentView(Resource.Layout.activity_main);
    }

    protected override void OnResume()
    {
        base.OnResume();
        LoadPresentation();
        currentSlideNumber = 0;
        if (buttonNext == null)
        {
            buttonNext = FindViewById<Button>(Resource.Id.buttonNext);
        }

        if (buttonPrev == null)
        {
            buttonPrev = FindViewById<Button>(Resource.Id.buttonPrev);
        }

        if(imageView == null)
        {
            imageView= FindViewById<ImageView>(Resource.Id.imageView);
        }

        buttonNext.Click += ButtonNext_Click;
        buttonPrev.Click += ButtonPrev_Click;
        RefreshButtonsStatus();
        ShowSlide(currentSlideNumber);
    }

    private void ButtonNext_Click(object sender, System.EventArgs e)
    {
        if (currentSlideNumber > (presentation.Slides.Count - 1))
        {
            return;
        }

        ShowSlide(++currentSlideNumber);
        RefreshButtonsStatus();
    }

    private void ButtonPrev_Click(object sender, System.EventArgs e)
    {
        if (currentSlideNumber == 0)
        {
            return;
        }

        ShowSlide(--currentSlideNumber);
        RefreshButtonsStatus();
    }

    protected override void OnPause()
    {
        base.OnPause();
        if (buttonNext != null)
        {
            buttonNext.Dispose();
            buttonNext = null;
        }

        if (buttonPrev != null)
        {
            buttonPrev.Dispose();
            buttonPrev = null;
        }

        if(imageView != null)
        {
            imageView.Dispose();
            imageView = null;
        }

        DisposePresentation();
    }

    private void RefreshButtonsStatus()
    {
        buttonNext.Enabled = currentSlideNumber < (presentation.Slides.Count - 1);
        buttonPrev.Enabled = currentSlideNumber > 0;
    }

    private void ShowSlide(int slideNumber)
    {
        Aspose.Slides.Drawing.Xamarin.Size size = presentation.SlideSize.Size.ToSize();
        Aspose.Slides.Drawing.Xamarin.Bitmap bitmap = presentation.Slides[slideNumber].GetThumbnail(size);
        imageView.SetImageBitmap(bitmap.ToNativeBitmap());
    }

    private void LoadPresentation()
    {
        if(presentation != null)
        {
            return;
        }

        using (Stream input = Assets.Open("HelloWorld.pptx"))
        {
            presentation = new Aspose.Slides.Presentation(input);
        }
    }

    private void DisposePresentation()
    {
        if(presentation == null)
        {
            return;
        }

        presentation.Dispose();
        presentation = null;
    }

}
```

Cuối cùng, triển khai hàm thêm một hình ellipse khi chạm vào slide:

**C# - MainActivity.cs - Thêm ellipse khi nhấn slide**

``` csharp
 private void ImageView_Touch(object sender, Android.Views.View.TouchEventArgs e)
{
    int[] location = new int[2];
    imageView.GetLocationOnScreen(location);
    int x = (int)e.Event.GetX();
    int y = (int)e.Event.GetY();
    int posX = x - location[0];
    int posY = y - location[0];

    Aspose.Slides.Drawing.Xamarin.Size presSize = presentation.SlideSize.Size.ToSize();

    float coeffX = (float)presSize.Width / imageView.Width;
    float coeffY = (float)presSize.Height / imageView.Height;
    int presPosX = (int)(posX * coeffX);
    int presPosY = (int)(posY * coeffY);
    int width = presSize.Width / 50;

    int height = width;
    Aspose.Slides.IAutoShape ellipse = presentation.Slides[currentSlideNumber].Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, presPosX, presPosY, width, height);
    ellipse.FillFormat.FillType = Aspose.Slides.FillType.Solid;

    Random random = new Random();
    Aspose.Slides.Drawing.Xamarin.Color slidesColor = Aspose.Slides.Drawing.Xamarin.Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
    ellipse.FillFormat.SolidFillColor.Color = slidesColor;
    ShowSlide(currentSlideNumber);
}
```

Mỗi lần nhấn vào slide trình chiếu sẽ thêm một ellipse có màu ngẫu nhiên:

![Slide với các ellipse được thêm bằng chạm](https://lh4.googleusercontent.com/RhjFHm6SgzOkXaehKhsY8q7SRZLFC7vV8_jyw-Gy4Scy68wTMg_apLZ3vPzRLOt1eEw_zUZmLlVhJ8oTGCg10dRNAETLSClRTBEyj2MWuefNpJI4i7WLIe0x8A7xuh4CV91loLKi)

## **Các tính năng được hỗ trợ**

|**TÍNH NĂNG**|**Aspose.Slides cho .NET**|**Aspose.Slides cho Xamarin**|
| :- | :- | :- |
|**Các tính năng của bản trình chiếu**:| | |
|Tạo bản trình chiếu mới|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Mở/lưu định dạng PowerPoint 97 - 2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Mở/lưu định dạng PowerPoint 2007|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Hỗ trợ phần mở rộng PowerPoint 2010|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Hỗ trợ phần mở rộng PowerPoint 2013|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Hỗ trợ tính năng PowerPoint 2016|restricted|restricted|
|Hỗ trợ tính năng PowerPoint 2019|restricted |restricted|
|Chuyển đổi PPT sang PPTX|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Chuyển đổi PPTX sang PPT|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTX trong PPT|restricted|restricted|
|Xử lý Themes|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Xử lý Macros|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Xử lý thuộc tính tài liệu|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Bảo vệ bằng mật khẩu|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Trích xuất văn bản nhanh|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Nhúng phông chữ|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Hiển thị bình luận|{{< emoticons/tick >}} |{{< emoticons/tick >}}|
|Ngắt các tác vụ chạy lâu|{{< emoticons/tick >}}|{{< emoticons/tick >}} |
|**Định dạng xuất**:| | |
|PDF|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|XPS|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|HTML|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|TIFF|{{< emoticons/tick >}}|{{< emoticons/cross >}}|
|ODP|restricted |restricted|
|SWF|restricted|restricted|
|SVG|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Định dạng nhập**:| | |
|HTML|restricted|restricted|
|ODP|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|THMX|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Tính năng slide Master**:| | |
|Truy cập tất cả slide Master hiện có|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Tạo/xóa slide Master|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Sao chép slide Master|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Tính năng slide Layout**:| | |
|Truy cập tất cả layout slide hiện có|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Tạo/xóa layout slide|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Sao chép layout slide|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Tính năng slide**:| | |
|Truy cập tất cả slide hiện có|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Tạo/xóa slide|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Sao chép slide|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Xuất slide thành hình ảnh|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Tạo/chỉnh sửa/xóa phần section của slide|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Tính năng slide Notes**:| | |
|Truy cập tất cả notes slide hiện có|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Tính năng hình dạng**:| | |
|Truy cập tất cả hình dạng trên slide|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Thêm hình dạng mới|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Sao chép hình dạng|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Xuất các hình dạng riêng thành hình ảnh|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Các loại hình dạng được hỗ trợ**:| | |
|Tất cả các loại hình dạng định sẵn|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Khung hình ảnh|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Bảng|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Biểu đồ|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|SmartArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Sơ đồ legacy|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|WordArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|OLE, đối tượng ActiveX|restricted|restricted|
|Khung video|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Khung âm thanh|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Kết nối|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Tính năng nhóm hình dạng**:| | |
|Truy cập nhóm hình dạng|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Tạo nhóm hình dạng|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Bóc nhóm các hình dạng hiện có|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Tính năng hiệu ứng hình dạng**:| | |
|Hiệu ứng 2D|restricted|restricted|
|Hiệu ứng 3D|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|**Tính năng văn bản**:| | |
|Định dạng đoạn văn|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Định dạng phần|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Tính năng hoạt ảnh**:| | |
|Xuất hoạt ảnh sang SWF|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|Xuất hoạt ảnh sang HTML|{{< emoticons/cross >}}|{{< emoticons/cross >}}|