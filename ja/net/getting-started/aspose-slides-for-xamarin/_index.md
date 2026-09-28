---
title: Aspose.Slides for Xamarin (歴史的)
linktitle: Xamarin (歴史的)
type: docs
weight: 200
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
description: "歴史的: Aspose.Slides for .NET バージョン 20.2 から 22.10 が別個のライブラリを通じて Xamarin.Android をサポートしていた方法。現在のバージョンには含まれていません。"
---
{{% alert color="info" title="注意" %}}

これは歴史的なページです。Aspose.Slides.NET パッケージのバージョン 20.2 から 22.10 には、Xamarin.Android 用の別個のライブラリ *Aspose.Slides.Droid.dll* が含まれており、この記事のコードはそれを使用しています。後続のバージョンには含まれていません。現在のパッケージには .NET Framework 4.6.2、.NET 6、.NET Standard 2.0 用のビルドのみが含まれています。Microsoft は 2024 年 5 月 1 日にすべての Xamarin SDK のサポートを終了しました。詳細は [Xamarin サポート ポリシー](https://dotnet.microsoft.com/en-us/platform/support/policy/xamarin) を参照してください。

{{% /alert %}}

## **はじめに**

Xamarin は .NET C# 用のモバイル開発フレームワークです。Xamarin には .NET プラットフォームの機能を拡張するツールとライブラリが用意されており、開発者は **Android** オペレーティングシステム向けのアプリケーションを構築できます。

{{% alert color="info" title="注意" %}}

Xamarin での開発では、プログラマーは通常の開発環境 (C#、Visual Studio、サードパーティ ライブラリ) を使用できます。

{{% /alert %}}

Aspose.Slides API は Xamarin プラットフォーム上で動作しました。これを実現するため、Aspose.Slides.NET パッケージのバージョン 20.2 から 22.10 では Xamarin 用の別個の DLL が追加されました。Aspose.Slides for Xamarin は .NET バージョンで利用可能な多くの機能をサポートしています。

- プレゼンテーションの変換と表示。
- プレゼンテーション内コンテンツの編集: テキスト、シェイプ、チャート、SmartArt、音声/動画、フォントなど。
- アニメーション、2D エフェクト、WordArt などの処理。
- メタデータおよびドキュメント プロパティの処理。
- クローン、マージ、比較、分割など。

このページの下部近くに、フル機能比較のセクションを用意しています。

Aspose.Slides for Xamarin API では、クラス、名前空間、ロジック、動作は .NET バージョンとできるだけ同様になるよう設計されています。最小限のコストで Aspose.Slides .NET アプリケーションを Xamarin に移行できます。

## **クイック例**
Aspose.Slides for Xamarin を使用して、Android 用 Slides アプリケーションを通じて C# アプリケーションを構築および利用できます。

Xamarin アプリケーションで Android 用に Aspose.Slides を使用し、プレゼンテーション スライドを表示し、タッチ時にスライドに新しいシェイプを追加する例を提供します。サンプルの完全なソースコードは [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Xamarin) にあります。

まず、Xamarin Android アプリを作成します。

![Xamarin Android アプリの作成](https://lh3.googleusercontent.com/sNkKZnuuGo8phWI-4g4jRA_ZESKpO9RXehPj46RVymXGPcCJuYooePXcBEcb7N6uUUxgocl4o9OjwnajzWKmL2i4MUz3gKKwXw6C0ow_VScN8vlyGBK3SpLKoE_m9BDJ3iNE4xPj)

最初に、画像ビュー、Prev、Next ボタンを含むコンテンツ レイアウトを作成します。

![画像ビューと Prev、Next ボタンを含むコンテンツ レイアウト](https://lh3.googleusercontent.com/rX9leIvYTVzQa0YAMj_jPUPs-c9_HwGPZUfR5A3FLiTk0-qzUQ29FfM4hammUVXbbw_Ly0LwEM_VnaI6vslEEMcVlEwVMem0LTiX5kYsA4lxtiHrvXfDPruWPOGU1YKDYSWcNM54)

**XML - content_main.xml - コンテンツ レイアウトの作成**
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

ここでは、Xamarin アプリケーションの Assets にサンプル プレゼンテーション「HelloWorld.pptx」を含む「Aspose.Slides.Droid.dll」ライブラリを参照し、MainActivity に初期化コードを追加しています。

**C# - MainActivity.cs - 初期化**
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

次に、Prev と Next ボタンをタップしたときにスライドを表示する関数を追加します。

**C# - MainActivity.cs - Prev と Next ボタンのクリックでスライド表示**
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

最後に、スライド上をタッチしたときに楕円シェイプを追加する関数を実装します。

**C# - MainActivity.cs - スライドクリックで楕円を追加**
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

プレゼンテーション スライドをクリックするたびに、ランダムな色の楕円が追加されます。

![タッチで楕円が追加されたスライド](https://lh4.googleusercontent.com/RhjFHm6SgzOkXaehKhsY8q7SRZLFC7vV8_jyw-Gy4Scy68wTMg_apLZ3vPzRLOt1eEw_zUZmLlVhJ8oTGCg10dRNAETLSClRTBEyj2MWuefNpJI4i7WLIe0x8A7xuh4CV91loLKi)

## **サポートされている機能**

|**機能**|**Aspose.Slides for .NET**|**Aspose.Slides for Xamarin**|
| :- | :- | :- |
|**プレゼンテーション機能**:| | |
|新規プレゼンテーションの作成|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 97 - 2003 形式の開閉|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2007 形式の開閉|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2010 拡張機能のサポート|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2013 拡張機能のサポート|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2016 機能のサポート|restricted|restricted|
|PowerPoint 2019 機能のサポート|restricted|restricted|
|PPT から PPTX への変換|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTX から PPT への変換|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTX の PPT 埋め込み|restricted|restricted|
|テーマの処理|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|マクロの処理|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|ドキュメント プロパティの処理|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|パスワード保護|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|高速テキスト抽出|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|フォントの埋め込み|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|コメントの描画|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|長時間実行タスクの中断|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**エクスポート形式:**| | |
|PDF|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|XPS|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|HTML|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|TIFF|{{< emoticons/tick >}}|{{< emoticons/cross >}}|
|ODP|restricted|restricted|
|SWF|restricted|restricted|
|SVG|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**インポート形式:**| | |
|HTML|restricted|restricted|
|ODP|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|THMX|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**マスタースライド機能:**| | |
|既存のマスタースライドすべてへのアクセス|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|マスタースライドの作成/削除|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|マスタースライドのクローン|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**レイアウトスライド機能:**| | |
|既存のレイアウトスライドすべてへのアクセス|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|レイアウトスライドの作成/削除|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|レイアウトスライドのクローン|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**スライド機能:**| | |
|既存のスライドすべてへのアクセス|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|スライドの作成/削除|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|スライドのクローン|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|スライドを画像へエクスポート|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|スライド セクションの作成/編集/削除|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**ノートスライド機能:**| | |
|既存のノートスライドすべてへのアクセス|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**シェイプ機能:**| | |
|スライド上のすべてのシェイプへのアクセス|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|新規シェイプの追加|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|シェイプのクローン|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|シェイプを個別に画像へエクスポート|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**サポート対象シェイプ種別:**| | |
|すべてのプリセットシェイプ種別|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
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
|**グループシェイプ機能:**| | |
|グループシェイプへのアクセス|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|グループシェイプの作成|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|既存のグループシェイプの解除|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**シェイプエフェクト機能:**| | |
|2D エフェクト|restricted|restricted|
|3D エフェクト|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|**テキスト機能:**| | |
|段落の書式設定|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|文字列の書式設定|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**アニメーション機能:**| | |
|アニメーションの SWF へのエクスポート|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|アニメーションの HTML へのエクスポート|{{< emoticons/cross >}}|{{< emoticons/cross >}}|