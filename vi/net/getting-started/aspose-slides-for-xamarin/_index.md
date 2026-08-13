---
title: Aspose.Slides cho Xamarin
type: docs
weight: 150
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
description: "Xây dựng ứng dụng di động Xamarin bằng C# để xem, chỉnh sửa và chuyển đổi bản trình chiếu với Aspose.Slides, hỗ trợ các tính năng phong phú cho PPT, PPTX và ODP trên Android."
---
## **Giới thiệu**

Xamarin là một khung được sử dụng để phát triển di động trong .NET C#. Xamarin có các công cụ và thư viện mở rộng khả năng của nền tảng .NET. Nó cho phép các nhà phát triển xây dựng ứng dụng cho hệ điều hành **Android**.

{{% alert color="info" %}} 

Để phát triển trên Xamarin, lập trình viên có thể sử dụng môi trường phát triển thường ngày của họ (C#, Visual Studio và các thư viện bên thứ ba).

{{% /alert %}}

Aspose.Slides API hoạt động trên nền tảng Xamarin. Để đạt được điều này, gói Aspose.Slides .NET thêm một DLL riêng cho Xamarin. Aspose.Slides for Xamarin hỗ trợ hầu hết các tính năng có trong phiên bản .NET:

- chuyển đổi và xem các bản trình chiếu.  
- chỉnh sửa nội dung trong bản trình chiếu: văn bản, hình dạng, biểu đồ, SmartArt, âm thanh/video, phông chữ, v.v.  
- xử lý/ quản lý hoạt ảnh, hiệu ứng 2D, WordArt, v.v.  
- xử lý/ quản lý siêu dữ liệu và thuộc tính tài liệu.  
- in ấn, sao chép, hợp nhất, so sánh, chia tách, v.v.

Chúng tôi đã cung cấp một so sánh toàn bộ tính năng trong một phần khác gần cuối trang này.

Trong Aspose.Slides for Xamarin API, các lớp, không gian tên, logic và hành vi được giữ càng giống càng tốt so với phiên bản .NET. Bạn có thể di chuyển các ứng dụng Aspose.Slides .NET của mình sang Xamarin với chi phí tối thiểu.

## **Ví dụ nhanh**

Bạn có thể sử dụng Aspose.Slides for Xamarin để xây dựng và tận dụng ứng dụng C# của mình thông qua Slides for Android.

Chúng tôi đang cung cấp một ví dụ về ứng dụng Android qua Xamarin sử dụng Aspose.Slides để hiển thị các slide trình chiếu và thêm một hình mới trên slide khi chạm. Bạn có thể tìm mã nguồn đầy đủ của các ví dụ trên [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Xamarin).

Hãy bắt đầu bằng việc tạo một ứng dụng Xamarin Android:

![todo:image_alt_text](https://lh3.googleusercontent.com/sNkKZnuuGo8phWI-4g4jRA_ZESKpO9RXehPj46RVymXGPcCJuYooePXcBEcb7N6uUUxgocl4o9OjwnajzWKmL2i4MUz3gKKwXw6C0ow_VScN8vlyGBK3SpLKoE_m9BDJ3iNE4xPj)

Đầu tiên, chúng ta tạo một bố cục nội dung sẽ chứa một ImageView, các nút Prev và Next:

![todo:image_alt_text](https://lh3.googleusercontent.com/rX9leIvYTVzQa0YAMj_jPUPs-c9_HwGPZUfR5A3FLiTk0-qzUQ29FfM4hammUVXbbw_Ly0LwEM_VnaI6vslEEMcVlEwVMem0LTiX5kYsA4lxtiHrvXfDPruWPOGU1YKDYSWcNM54)

**XML - content_main.xml - Tạo bố cục nội dung**
``` 
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

Ở đây, chúng ta tham chiếu thư viện "Aspose.Slides.Droid.dll" bao gồm một bản trình chiếu mẫu ("HelloWorld.pptx") vào Assets của ứng dụng Xamarin và thêm khởi tạo của nó vào MainActivity:

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

Hãy thêm hàm để hiển thị các slide Prev và Next khi nhấn các nút:

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

Cuối cùng, hãy thực hiện một hàm để thêm một hình ellipse khi chạm vào slide:

**C# - MainActivity.cs - Thêm hình ellipse khi click slide**

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

Mỗi lần click trên slide trình chiếu sẽ thêm một ellipse màu ngẫu nhiên:

![todo:image_alt_text](https://lh4.googleusercontent.com/RhjFHm6SgzOkXaehKhsY8q7SRZLFC7vV8_jyw-Gy4Scy68wTMg_apLZ3vPzRLOt1eEw_zUZmLlVhJ8oTGCg10dRNAETLSClRTBEyj2MWuefNpJI4i7WLIe0x8A7xuh4CV91loLKi)

## **Các tính năng được hỗ trợ**

|**TÍNH NĂNG**|**Aspose.Slides for .NET**|**Aspose.Slides for Xamarin**|
| :- | :- | :- |
|**Các tính năng trình chiếu**:| | |
|Tạo bản trình chiếu mới|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Mở/ lưu định dạng PowerPoint 97 - 2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Mở/ lưu định dạng PowerPoint 2007|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Hỗ trợ phần mở rộng PowerPoint 2010|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Hỗ trợ phần mở rộng PowerPoint 2013|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Hỗ trợ tính năng PowerPoint 2016|bị hạn chế|bị hạn chế|
|Hỗ trợ tính năng PowerPoint 2019|bị hạn chế|bị hạn chế|
|Chuyển đổi PPT sang PPTX|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Chuyển đổi PPTX sang PPT|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTX trong PPT|bị hạn chế|bị hạn chế|
|Xử lý themes|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Xử lý macro|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Xử lý thuộc tính tài liệu|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Bảo vệ bằng mật khẩu|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Trích xuất văn bản nhanh|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Nhúng phông chữ|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Hiển thị bình luận|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Ngắt các tác vụ chạy lâu|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Định dạng xuất:**| | |
|PDF|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|XPS|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|HTML|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|TIFF|{{< emoticons/tick >}}|{{< emoticons/cross >}}|
|ODP|bị hạn chế|bị hạn chế|
|SWF|bị hạn chế|bị hạn chế|
|SVG|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Định dạng nhập:**| | |
|HTML|bị hạn chế|bị hạn chế|
|ODP|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|THMX|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Các tính năng master slide:**| | |
|Truy cập mọi master slide hiện có|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Tạo/xóa master slide|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Sao chép master slide|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Các tính năng layout slide:**| | |
|Truy cập mọi layout slide hiện có|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Tạo/xóa layout slide|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Sao chép layout slide|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Các tính năng slide:**| | |
|Truy cập mọi slide hiện có|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Tạo/xóa slide|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Sao chép slide|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Xuất slide thành hình ảnh|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Tạo/chỉnh sửa/xóa phần đoạn slide|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Các tính năng notes slide**:| | |
|Truy cập mọi notes slide hiện có|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Các tính năng shape:**| | |
|Truy cập mọi shape trên slide|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Thêm shape mới|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Sao chép shape|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Xuất shape riêng thành hình ảnh|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Các loại shape được hỗ trợ:**| | |
|Tất cả các loại shape định sẵn|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Khung hình ảnh|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Bảng|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Biểu đồ|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|SmartArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Sơ đồ cũ|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|WordArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|OLE, ActiveX objects|bị hạn chế|bị hạn chế|
|Khung video|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Khung âm thanh|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Kết nối|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Các tính năng group shape:**| | |
|Truy cập group shape|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Tạo group shape|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Bỏ nhóm các group shape hiện có|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Các tính năng hiệu ứng shape:**| | |
|Hiệu ứng 2D|bị hạn chế|bị hạn chế|
|Hiệu ứng 3D|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|**Các tính năng văn bản:**| | |
|Định dạng đoạn văn|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Định dạng phần|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Các tính năng hoạt ảnh:**| | |
|Xuất hoạt ảnh sang SWF|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|Xuất hoạt ảnh sang HTML|{{< emoticons/cross >}}|{{< emoticons/cross >}}|