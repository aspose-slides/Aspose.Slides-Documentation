---
title: Aspose.Slides for Xamarin（歷史版）
linktitle: Xamarin（歷史版）
type: docs
weight: 200
url: /zh-hant/net/aspose-slides-for-xamarin/
keywords:
- Xamarin
- 行動開發
- Android
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "歷史說明：Aspose.Slides for .NET 20.2 至 22.10 版如何透過獨立函式庫支援 Xamarin.Android。當前版本不再包含此庫。"
---
{{% alert color="info" title="注意" %}}

這是一個歷史頁面。Aspose.Slides.NET 套件的 20.2 到 22.10 版包含了獨立的 Xamarin.Android 函式庫 *Aspose.Slides.Droid.dll*，此頁面的程式碼使用了該函式庫。較新的版本不再包含它：目前的套件只提供 .NET Framework 4.6.2、.NET 6 與 .NET Standard 2.0 的組建。Microsoft 於 2024 年 5 月 1 日停止支援所有 Xamarin SDK；詳情請參閱 [Xamarin support policy](https://dotnet.microsoft.com/en-us/platform/support/policy/xamarin)。

{{% /alert %}}

## **簡介**

Xamarin 是一個用於 .NET C# 行動開發的框架。Xamarin 提供工具與函式庫，擴充 .NET 平台的功能，讓開發者能為 **Android** 作業系統建立應用程式。

{{% alert color="info" title="注意" %}}

在 Xamarin 中開發時，程式設計師可以使用其慣用的開發環境（C#、Visual Studio 以及第三方函式庫）。

{{% /alert %}}

Aspose.Slides API 在 Xamarin 平台上也能運作。為此，Aspose.Slides.NET 套件在 20.2 到 22.10 版加入了針對 Xamarin 的獨立 DLL。Aspose.Slides for Xamarin 支援 .NET 版的大多數功能：

- 轉換與檢視簡報。
- 編輯簡報內容：文字、圖形、圖表、SmartArt、音訊/視訊、字型等。
- 處理動畫、2D 效果、WordArt 等。
- 處理中繼資料與文件屬性。
- 複製、合併、比較、拆分等。

我們在本頁底部的另一節提供了完整功能的比較。

在 Aspose.Slides for Xamarin API 中，類別、命名空間、邏輯與行為盡可能與 .NET 版保持相同。您可以以最小的成本將 Aspose.Slides .NET 應用程式遷移到 Xamarin。

## **快速範例**
您可以使用 Aspose.Slides for Xamarin 透過 Slides for Android 建立並使用 C# 應用程式。

我們提供了一個使用 Aspose.Slides 顯示簡報投影片，並在觸碰時於投影片上新增圖形的 Xamarin Android 範例。完整範例原始碼可在 [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Xamarin) 取得。

讓我們從建立 Xamarin Android App 開始：

![Creating a Xamarin Android app](https://lh3.googleusercontent.com/sNkKZnuuGo8phWI-4g4jRA_ZESKpO9RXehPj46RVymXGPcCJuYooePXcBEcb7N6uUUxgocl4o9OjwnajzWKmL2i4MUz3gKKwXw6C0ow_VScN8vlyGBK3SpLKoE_m9BDJ3iNE4xPj)

首先，我們建立一個包含 ImageView、Prev 與 Next 按鈕的版面配置：

![Content layout with an image view and Prev and Next buttons](https://lh3.googleusercontent.com/rX9leIvYTVzQa0YAMj_jPUPs-c9_HwGPZUfR5A3FLiTk0-qzUQ29FfM4hammUVXbbw_Ly0LwEM_VnaI6vslEEMcVlEwVMem0LTiX5kYsA4lxtiHrvXfDPruWPOGU1YKDYSWcNM54)

**XML - content_main.xml - 建立內容版面配置**
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

在此，我們參考「Aspose.Slides.Droid.dll」函式庫，將範例簡報（「HelloWorld.pptx」）加入 Xamarin 應用程式的 Assets，並於 MainActivity 進行初始化：

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

接著，加入在按鈕點擊時顯示上一張與下一張投影片的功能：

**C# - MainActivity.cs - 在 Prev 與 Next 按鈕點擊時顯示投影片**

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

最後，實作在投影片點擊時加入橢圓形圖形的功能：

**C# - MainActivity.cs - 透過投影片點擊新增橢圓形**

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

每次點擊簡報投影片，都會新增一個隨機顏色的橢圓形：

![Slide with ellipses added by touch](https://lh4.googleusercontent.com/RhjFHm6SgzOkXaehKhsY8q7SRZLFC7vV8_jyw-Gy4Scy68wTMg_apLZ3vPzRLOt1eEw_zUZmLlVhJ8oTGCg10dRNAETLSClRTBEyj2MWuefNpJI4i7WLIe0x8A7xuh4CV91loLKi)


## **支援功能**

|**功能**|**Aspose.Slides for .NET**|**Aspose.Slides for Xamarin**|
| :- | :- | :- |
|**簡報功能**| | |
|建立新簡報|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 97 - 2003 格式開啟/儲存|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2007 格式開啟/儲存|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2010 延伸功能支援|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2013 延伸功能支援|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2016 功能支援|restricted|restricted|
|PowerPoint 2019 功能支援|restricted|restricted|
|PPT 轉 PPTX 轉換|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTX 轉 PPT 轉換|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTX 內嵌於 PPT|restricted|restricted|
|佈景主題處理|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|巨集處理|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|文件屬性處理|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|密碼保護|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|快速文字擷取|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|嵌入字型|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|註解呈現|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|長時間執行任務的中斷|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**匯出格式**| | |
|PDF|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|XPS|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|HTML|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|TIFF|{{< emoticons/tick >}}|{{< emoticons/cross >}}|
|ODP|restricted|restricted|
|SWF|restricted|restricted|
|SVG|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**匯入格式**| | |
|HTML|restricted|restricted|
|ODP|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|THMX|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**母片投影片功能**| | |
|存取所有現有母片投影片|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|建立/移除母片投影片|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|複製母片投影片|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**版面投影片功能**| | |
|存取所有現有版面投影片|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|建立/移除版面投影片|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|複製版面投影片|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**投影片功能**| | |
|存取所有現有投影片|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|建立/移除投影片|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|複製投影片|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|匯出投影片為圖像|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|建立/編輯/移除投影片分節|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**備註投影片功能**| | |
|存取所有現有備註投影片|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**圖形功能**| | |
|存取所有投影片圖形|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|新增圖形|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|複製圖形|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|匯出單獨圖形為圖像|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**支援的圖形類型**| | |
|所有預定義圖形類型|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|圖片框|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|表格|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|圖表|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|SmartArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|舊版圖示|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|WordArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|OLE、ActiveX 物件|restricted|restricted|
|視訊框|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|音訊框|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|連接線|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**群組圖形功能**| | |
|存取群組圖形|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|建立群組圖形|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|解除群組|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**圖形效果功能**| | |
|2D 效果|restricted|restricted|
|3D 效果|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|**文字功能**| | |
|段落格式設定|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|文字區段格式設定|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**動畫功能**| | |
|匯出動畫為 SWF|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|匯出動畫為 HTML|{{< emoticons/cross >}}|{{< emoticons/cross >}}|