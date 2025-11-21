---
title: Aspose.Slides for Xamarin
type: docs
weight: 150
url: /ja/net/aspose-slides-for-xamarin/
keywords:
- Xamarin
- モバイル開発
- Android
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "C# で Xamarin モバイルアプリを構築し、Aspose.Slides を使用して Android 上で PPT、PPTX、ODP のプレゼンテーションを表示、編集、変換する豊富な機能をサポートします。"
---

## **概要**
Xamarin は .NET C# でのモバイル開発に使用されるフレームワークです。Xamarin には .NET プラットフォームの機能を拡張するツールとライブラリがあります。開発者は **Android** オペレーティングシステム向けのアプリケーションを構築できます。

{{% alert color="primary" %}} 
Xamarin の開発では、プログラマーは通常の開発環境（C#、Visual Studio、サードパーティ ライブラリ）を使用できます。
{{% /alert %}}

Aspose.Slides API は Xamarin プラットフォーム上で動作します。これを実現するために、Aspose.Slides .NET パッケージは Xamarin 用の別個の DLL を追加します。Aspose.Slides for Xamarin は .NET バージョンで利用可能な機能のほとんどをサポートします。

- プレゼンテーションの変換と表示。
- プレゼンテーション内のコンテンツ編集：テキスト、図形、チャート、SmartArt、音声/ビデオ、フォントなど。
- アニメーション、2D エフェクト、WordArt などの処理。
- メタデータおよびドキュメント プロパティの処理。
- 印刷、クローン作成、マージ、比較、分割など。

ページ下部にある別セクションで、すべての機能の比較を提供しています。

Aspose.Slides for Xamarin API では、クラス、名前空間、ロジック、動作は .NET バージョンとできるだけ同様になるように設計されています。最小限のコストで Aspose.Slides .NET アプリケーションを Xamarin に移行できます。

## **クイック例**
Aspose.Slides for Xamarin を使用して、Slides for Android 経由で C# アプリケーションを構築および活用できます。

Xamarin アプリケーションで Android を使用し、Aspose.Slides を利用してプレゼンテーション スライドを表示し、タッチ時にスライドに新しい図形を追加する例を提供しています。サンプルの完全なソースは [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Xamarin) で確認できます。

Xamarin Android アプリの作成から始めましょう。

![todo:image_alt_text](https://lh3.googleusercontent.com/sNkKZnuuGo8phWI-4g4jRA_ZESKpO9RXehPj46RVymXGPcCJuYooePXcBEcb7N6uUUxgocl4o9OjwnajzWKmL2i4MUz3gKKwXw6C0ow_VScN8vlyGBK3SpLKoE_m9BDJ3iNE4xPj)

まず、画像ビュー、Prev、Next ボタンを含むコンテンツ レイアウトを作成します。

![todo:image_alt_text](https://lh3.googleusercontent.com/rX9leIvYTVzQa0YAMj_jPUPs-c9_HwGPZUfR5A3FLiTk0-qzUQ29FfM4hammUVXbbw_Ly0LwEM_VnaI6vslEEMcVlEwVMem0LTiX5kYsA4lxtiHrvXfDPruWPOGU1YKDYSWcNM54)

**XML - content_main.xml - コンテンツレイアウトの作成**
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


ここでは、サンプル プレゼンテーション（"HelloWorld.pptx"）を含む "Aspose.Slides.Droid.dll" ライブラリを Xamarin アプリケーションの Assets に参照し、MainActivity に初期化コードを追加します。

**C# - MainActivity.cs - 初期化**
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


Prev と Next ボタンのクリックでスライドを表示する関数を追加しましょう。

**C# - MainActivity.cs - Prev と Next ボタンのクリックでスライドを表示**
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


最後に、スライドをタップしたときに楕円形を追加する関数を実装します。

**C# - MainActivity.cs - スライドクリックで楕円形を追加**
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


プレゼンテーション スライドをクリックするたびに、ランダムな色の楕円形が追加されます。

![todo:image_alt_text](https://lh4.googleusercontent.com/RhjFHm6SgzOkXaehKhsY8q7SRZLFC7vV8_jyw-Gy4Scy68wTMg_apLZ3vPzRLOt1eEw_zUZmLlVhJ8oTGCg10dRNAETLSClRTBEyj2MWuefNpJI4i7WLIe0x8A7xuh4CV91loLKi)

## **サポートされている機能**

|**機能**|**Aspose.Slides for .NET**|**Aspose.Slides for Xamarin**|
| :- | :- | :- |
|**プレゼンテーション機能:**| | |
|新しいプレゼンテーションの作成|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 97‑2003 形式の開閉|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2007 形式の開閉|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2010 拡張機能のサポート|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2013 拡張機能のサポート|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2016 機能のサポート|restricted|restricted|
|PowerPoint 2019 機能のサポート|restricted |restricted|
|PPT から PPTX への変換|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTX から PPT への変換|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPT 内の PPTX|restricted|restricted|
|テーマの処理|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|マクロの処理|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|ドキュメント プロパティの処理|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|パスワード保護|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|高速テキスト抽出|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|フォントの埋め込み|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|コメントのレンダリング|{{< emoticons/tick >}} |{{< emoticons/tick >}}|
|長時間タスクの中断|{{< emoticons/tick >}}|{{< emoticons/tick >}} |
|**エクスポート形式:**| | |
|PDF|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|XPS|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|HTML|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|TIFF|{{< emoticons/tick >}}|{{< emoticons/cross >}}|
|ODP|restricted |restricted|
|SWF|restricted|restricted|
|SVG|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**インポート形式:**| | |
|HTML|restricted|restricted|
|ODP|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|THMX|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**マスタースライド機能:**| | |
|既存のすべてのマスタースライドへのアクセス|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|マスタースライドの作成/削除|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|マスタースライドのクローン作成|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**レイアウトスライド機能:**| | |
|既存のすべてのレイアウトスライドへのアクセス|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|レイアウトスライドの作成/削除|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|レイアウトスライドのクローン作成|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**スライド機能:**| | |
|既存のすべてのスライドへのアクセス|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|スライドの作成/削除|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|スライドのクローン作成|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|スライドを画像へエクスポート|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|スライド セクションの作成/編集/削除|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**ノートスライド機能**| | |
|既存のすべてのノートスライドへのアクセス|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**図形機能:**| | |
|スライド上のすべての図形へのアクセス|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|新しい図形の追加|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|図形のクローン作成|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|個別の図形を画像へエクスポート|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**サポートされている図形タイプ:**| | |
|すべての事前定義された図形タイプ|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|画像フレーム|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|テーブル|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|チャート|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|SmartArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|レガシーダイアグラム|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|WordArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|OLE、ActiveX オブジェクト|restricted|restricted|
|ビデオフレーム|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|オーディオフレーム|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|コネクタ|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**グループ図形機能:**| | |
|グループ図形へのアクセス|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|グループ図形の作成|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|既存のグループ図形の解除|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**図形エフェクト機能:**| | |
|2D エフェクト|restricted|restricted|
|3D エフェクト|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|**テキスト機能:**| | |
|段落書式設定|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|文字列書式設定|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**アニメーション機能:**| | |
|アニメーションを SWF にエクスポート|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|アニメーションを HTML にエクスポート|{{< emoticons/cross >}}|{{< emoticons/cross >}}|