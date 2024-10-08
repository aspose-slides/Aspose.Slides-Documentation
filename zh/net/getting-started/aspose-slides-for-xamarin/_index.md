---
title: Aspose.Slides for Xamarin
type: docs
weight: 150
url: /net/aspose-slides-for-xamarin/
---

## **概述**
Xamarin是一个用于.NET C#的移动开发框架。Xamarin拥有扩展.NET平台能力的工具和库。它允许开发者为**Android**操作系统构建应用程序。

{{% alert color="primary" %}} 

在Xamarin中进行开发时，程序员可以使用他们的常规开发环境（C#、Visual Studio和第三方库）。

{{% /alert %}}

Aspose.Slides API在Xamarin平台上运行。为此，Aspose.Slides .NET包为Xamarin添加了一个单独的DLL。Aspose.Slides for Xamarin支持.NET版本中大多数可用功能：

- 转换和查看演示文稿。
- 编辑演示文稿中的内容：文本、形状、图表、SmartArt、音频/视频、字体等。
- 处理/应对动画、2D效果、WordArt等。
- 处理/处理元数据和文档属性。
- 打印、克隆、合并、比较、分割等。

我们在本页底部的另一个部分提供了完整功能的比较。

在Aspose.Slides for Xamarin API中，类、命名空间、逻辑和行为尽可能与.NET版本相似。您可以以最小的成本将Aspose.Slides .NET应用程序迁移到Xamarin。

## **快速示例**
您可以使用Aspose.Slides for Xamarin通过Slides for Android构建和利用您的C#应用程序。

我们提供了一个通过Xamarin的Android应用示例，使用Aspose.Slides显示演示文稿幻灯片，并在触摸时在幻灯片上添加一个新形状。您可以在[GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Xamarin)上找到示例的完整源代码。

让我们开始创建一个Xamarin Android应用：

![todo:image_alt_text](https://lh3.googleusercontent.com/sNkKZnuuGo8phWI-4g4jRA_ZESKpO9RXehPj46RVymXGPcCJuYooePXcBEcb7N6uUUxgocl4o9OjwnajzWKmL2i4MUz3gKKwXw6C0ow_VScN8vlyGBK3SpLKoE_m9BDJ3iNE4xPj)

首先，我们创建一个将包含图像视图、上一步和下一步按钮的内容布局：

![todo:image_alt_text](https://lh3.googleusercontent.com/rX9leIvYTVzQa0YAMj_jPUPs-c9_HwGPZUfR5A3FLiTk0-qzUQ29FfM4hammUVXbbw_Ly0LwEM_VnaI6vslEEMcVlEwVMem0LTiX5kYsA4lxtiHrvXfDPruWPOGU1YKDYSWcNM54)

**XML - content_main.xml - 创建内容布局**
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
            android:text="上一步"
            android:layout_width="wrap_content"
            android:layout_height="wrap_content"
            android:id="@+id/buttonPrev" />
        <Button
            android:text="下一步"
            android:layout_width="wrap_content"
            android:layout_height="wrap_content"
            android:id="@+id/buttonNext"/>
    </LinearLayout>
</LinearLayout>
```

在这里，我们引用了包含示例演示文稿（"HelloWorld.pptx"）的"Aspose.Slides.Droid.dll"库，并将其初始化添加到MainActivity：

**C# - MainActivity.cs - 初始化**

``` csharp
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

让我们添加一个函数，用于在点击按钮时显示上一步和下一步的幻灯片：

**C# - MainActivity.cs - 点击上一步和下一步按钮时显示幻灯片**

``` csharp
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

最后，让我们实现一个在幻灯片触摸时添加椭圆形状的函数：

**C# - MainActivity.cs - 点击幻灯片时添加椭圆形**

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

![todo:image_alt_text](https://lh4.googleusercontent.com/RhjFHm6SgzOkXaehKhsY8q7SRZLFC7vV8_jyw-Gy4Scy68wTMg_apLZ3vPzRLOt1eEw_zUZmLlVhJ8oTGCg10dRNAETLSClRTBEyj2MWuefNpJI4i7WLIe0x8A7xuh4CV91loLKi)

## **支持的功能**

|**功能** |**Aspose.Slides for .NET**  |**Aspose.Slides for Xamarin**|
| :- | :- | :- |
|**演示文稿功能**: | | |
|创建新演示文稿 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 97 - 2003格式打开/保存 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2007格式打开/保存 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|支持PowerPoint 2010扩展 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|支持PowerPoint 2013扩展 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|支持PowerPoint 2016功能 |受限|受限|
|支持PowerPoint 2019功能 |受限 |受限|
|PPT到PPTX转换 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTX到PPT转换 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTX在PPT中 |受限|受限|
|主题处理 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|宏处理 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|文档属性处理 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|密码保护 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|快速文本提取 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|嵌入字体 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|评论渲染 |{{< emoticons/tick >}} |{{< emoticons/tick >}}|
|中断长时间运行的任务 |{{< emoticons/tick >}}|{{< emoticons/tick >}} |
|**导出格式:** | | |
|PDF |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|XPS |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|HTML |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|TIFF |{{< emoticons/tick >}}|{{< emoticons/cross >}}|
|ODP |受限 |受限 |
|SWF |受限|受限|
|SVG |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**导入格式:** | | |
|HTML |受限|受限|
|ODP |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|THMX |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**母版幻灯片功能:** | | |
|访问所有现有母版幻灯片 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|创建/删除母版幻灯片 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|克隆母版幻灯片 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**布局幻灯片功能:** | | |
|访问所有现有布局幻灯片 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|创建/删除布局幻灯片 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|克隆布局幻灯片 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**幻灯片功能:** | | |
|访问所有现有幻灯片 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|创建/删除幻灯片 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|克隆幻灯片 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|将幻灯片导出为图像 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|创建/编辑/删除幻灯片部分 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**备注幻灯片功能**: | | |
|访问所有现有备注幻灯片 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**形状功能:** | | |
|访问所有幻灯片形状 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|添加新形状 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|克隆形状 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|将单独形状导出为图像 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**支持的形状类型:** | | |
|所有预定义形状类型 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|图片框 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|表格 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|图表 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|SmartArt |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|旧版图 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|WordArt |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|OLE、ActiveX对象 |受限|受限|
|视频框 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|音频框 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|连接线 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**组合形状功能:** | | |
|访问组合形状 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|创建组合形状 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|取消组合现有组合形状 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**形状特效功能:** | | |
|2D特效 |受限|受限|
|3D特效 |{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|**文本功能:** | | |
|段落格式 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|部分格式 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**动画功能:** | | |
|将动画导出为SWF |{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|将动画导出为HTML |{{< emoticons/cross >}}|{{< emoticons/cross >}}|