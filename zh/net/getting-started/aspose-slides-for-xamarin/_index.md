---
title: Aspose.Slides for Xamarin（历史）
linktitle: Xamarin（历史）
type: docs
weight: 200
url: /zh/net/aspose-slides-for-xamarin/
keywords:
- Xamarin
- 移动开发
- Android
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "历史：Aspose.Slides for .NET 20.2 至 22.10 版本如何通过单独的库支持 Xamarin.Android。当前版本不再包含该库。"
---
{{% alert color="info" title="Note" %}}

这是一个历史页面。Aspose.Slides.NET 包的 20.2 到 22.10 版本包含了一个单独的 Xamarin.Android 库 *Aspose.Slides.Droid.dll*，本页的代码使用了该库。后续版本不再包含它：当前包仅包含 .NET Framework 4.6.2、.NET 6 和 .NET Standard 2.0 的构建。Microsoft 已于 2024 年 5 月 1 日停止对所有 Xamarin SDK 的支持；请参阅 [Xamarin 支持政策](https://dotnet.microsoft.com/en-us/platform/support/policy/xamarin)。

{{% /alert %}}

## **简介**

Xamarin 是用于 .NET C# 移动开发的框架。Xamarin 提供工具和库，扩展了 .NET 平台的功能。它允许开发者为 **Android** 操作系统构建应用。

{{% alert color="info" title="Note" %}}

在 Xamarin 中开发时，程序员可以使用他们常用的开发环境（C#、Visual Studio 和第三方库）。

{{% /alert %}}

Aspose.Slides API 在 Xamarin 平台上可用。为实现此目的，Aspose.Slides.NET 包在 20.2 到 22.10 版本中为 Xamarin 添加了一个单独的 DLL。Aspose.Slides for Xamarin 支持 .NET 版本中大多数功能：

- 转换和查看演示文稿。
- 编辑演示文稿内容：文本、形状、图表、SmartArt、音视频、字体等。
- 处理动画、2D 效果、WordArt 等。
- 处理元数据和文档属性。
- 克隆、合并、比较、拆分等。

我们在页面底部的另一节提供了完整功能的对比。

在 Aspose.Slides for Xamarin API 中，类、命名空间、逻辑和行为尽可能与 .NET 版本保持一致。您可以以最小的成本将 Aspose.Slides .NET 应用迁移到 Xamarin。

## **快速示例**
您可以使用 Aspose.Slides for Xamarin 通过 Slides for Android 构建并使用 C# 应用。

我们提供了一个通过 Xamarin 的 Android 示例应用，使用 Aspose.Slides 在幻灯片上显示演示文稿并在触摸时添加新形状。完整示例源码可在 [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Xamarin) 找到。

让我们从创建一个 Xamarin Android 应用开始：

![创建 Xamarin Android 应用](https://lh3.googleusercontent.com/sNkKZnuuGo8phWI-4g4jRA_ZESKpO9RXehPj46RVymXGPcCJuYooePXcBEcb7N6uUUxgocl4o9OjwnajzWKmL2i4MUz3gKKwXw6C0ow_VScN8vlyGBK3SpLKoE_m9BDJ3iNE4xPj)

首先，我们创建一个包含 ImageView、Prev 和 Next 按钮的内容布局：

![带有 ImageView 和 Prev、Next 按钮的内容布局](https://lh3.googleusercontent.com/rX9leIvYTVzQa0YAMj_jPUPs-c9_HwGPZUfR5A3FLiTk0-qzUQ29FfM4hammUVXbbw_Ly0LwEM_VnaI6vslEEMcVlEwVMem0LTiX5kYsA4lxtiHrvXfDPruWPOGU1YKDYSWcNM54)

**XML - content_main.xml - 创建内容布局**
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

在此，我们引用了包含示例演示文稿（"HelloWorld.pptx"）的 "Aspose.Slides.Droid.dll" 库，并将其添加到 Xamarin 应用的 Assets 中，同时在 MainActivity 中进行初始化：

**C# - MainActivity.cs - 初始化**
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

将显示 Prev 和 Next 幻灯片的功能添加到按钮点击事件中：

**C# - MainActivity.cs - 在 Prev 和 Next 按钮点击时显示幻灯片**
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

最后，实现一个在幻灯片点击时添加椭圆形状的函数：

**C# - MainActivity.cs - 通过幻灯片点击添加椭圆**
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

每次点击演示文稿幻灯片都会添加一个随机颜色的椭圆：

![通过触摸添加椭圆的幻灯片](https://lh4.googleusercontent.com/RhjFHm6SgzOkXaehKhsY8q7SRZLFC7vV8_jyw-Gy4Scy68wTMg_apLZ3vPzRLOt1eEw_zUZmLlVhJ8oTGCg10dRNAETLSClRTBEyj2MWuefNpJI4i7WLIe0x8A7xuh4CV91loLKi)

## **受支持的功能**

|**功能**|**Aspose.Slides for .NET**|**Aspose.Slides for Xamarin**|
| :- | :- | :- |
|**演示文稿功能**:| | |
|创建新演示文稿|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 97 - 2003 格式打开/保存|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2007 格式打开/保存|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2010 扩展支持|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2013 扩展支持|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2016 功能支持|restricted|restricted|
|PowerPoint 2019 功能支持|restricted|restricted|
|PPT 转 PPTX 转换|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTX 转 PPT 转换|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTX 嵌入 PPT|restricted|restricted|
|主题处理|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|宏处理|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|文档属性处理|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|密码保护|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|快速文本提取|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|嵌入字体|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|注释渲染|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|中断长时间运行的任务|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**导出格式:**| | |
|PDF|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|XPS|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|HTML|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|TIFF|{{< emoticons/tick >}}|{{< emoticons/cross >}}|
|ODP|restricted|restricted|
|SWF|restricted|restricted|
|SVG|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**导入格式:**| | |
|HTML|restricted|restricted|
|ODP|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|THMX|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**母版幻灯片功能:**| | |
|访问所有现有母版幻灯片|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|创建/删除母版幻灯片|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|克隆母版幻灯片|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**版式幻灯片功能:**| | |
|访问所有现有版式幻灯片|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|创建/删除版式幻灯片|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|克隆版式幻灯片|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**幻灯片功能:**| | |
|访问所有现有幻灯片|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|创建/删除幻灯片|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|克隆幻灯片|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|将幻灯片导出为图像|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|创建/编辑/删除幻灯片节|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**备注幻灯片功能**:| | |
|访问所有现有备注幻灯片|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**形状功能:**| | |
|访问所有幻灯片形状|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|添加新形状|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|克隆形状|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|将单独形状导出为图像|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**支持的形状类型:**| | |
|所有预定义形状类型|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|图片框|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|表格|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|图表|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|SmartArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|传统图表|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|WordArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|OLE、ActiveX 对象|restricted|restricted|
|视频框|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|音频框|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|连接线|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**组合形状功能:**| | |
|访问组合形状|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|创建组合形状|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|取消组合现有组合形状|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**形状效果功能:**| | |
|2D 效果|restricted|restricted|
|3D 效果|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|**文本功能:**| | |
|段落格式化|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|文本块格式化|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**动画功能:**| | |
|导出动画为 SWF|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|导出动画为 HTML|{{< emoticons/cross >}}|{{< emoticons/cross >}}|