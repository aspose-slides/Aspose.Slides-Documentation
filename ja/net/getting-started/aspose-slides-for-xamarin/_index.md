---
title: Aspose.Slides for Xamarin
type: docs
weight: 150
url: /net/aspose-slides-for-xamarin/
---

## **概要**
Xamarinは、.NET C#でのモバイル開発に使用されるフレームワークです。Xamarinには、.NETプラットフォームの機能を拡張するツールやライブラリがあります。これにより、開発者は**Android**オペレーティングシステム向けにアプリケーションを構築できます。

{{% alert color="primary" %}} 

Xamarinでの開発において、プログラマーは通常の開発環境（C#、Visual Studio、およびサードパーティのライブラリ）を使用できます。

{{% /alert %}}

Aspose.Slides APIはXamarinプラットフォーム上で動作します。これを実現するために、Aspose.Slides .NETパッケージはXamarin用の別個のDLLを追加します。Aspose.Slides for Xamarinは、.NETバージョンで利用可能なほとんどの機能をサポートしています。

- プレゼンテーションの変換と表示。
- プレゼンテーション内のコンテンツの編集：テキスト、形状、チャート、SmartArt、音声/動画、フォントなど。
- アニメーション、2D効果、WordArtなどの扱い。
- メタデータや文書プロパティの扱い。
- 印刷、クローン、マージ、比較、分割など。

当社は、このページの下部に近い別のセクションで完全な機能の比較を提供しています。

Aspose.Slides for Xamarin APIでは、クラス、名前空間、ロジック、動作が.NETバージョンとできるだけ類似しています。最小限のコストでAspose.Slides .NETアプリケーションをXamarinに移行できます。

## **クイック例**
Aspose.Slides for Xamarinを使用して、Slides for Androidを通じてC#アプリケーションを構築および利用できます。

Aspose.Slidesを使用してプレゼンテーションスライドを表示し、タッチ時にスライドに新しい形状を追加するXamarinアプリケーションのAndroidの例を提供します。例の完全なソースは[GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Xamarin)で見つけることができます。

Xamarin Androidアプリを作成することから始めましょう：

![todo:image_alt_text](https://lh3.googleusercontent.com/sNkKZnuuGo8phWI-4g4jRA_ZESKpO9RXehPj46RVymXGPcCJuYooePXcBEcb7N6uUUxgocl4o9OjwnajzWKmL2i4MUz3gKKwXw6C0ow_VScN8vlyGBK3SpLKoE_m9BDJ3iNE4xPj)

まず、画像ビュー、Prev、およびNextボタンを含むコンテンツレイアウトを作成します：

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

ここで、サンプルプレゼンテーション（"HelloWorld.pptx"）をXamarinアプリケーションのAssetsに含む"Aspose.Slides.Droid.dll"ライブラリを参照し、MainActivityにその初期化を追加します：

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

ボタンをタップすることでPrevとNextスライドを表示する機能を追加しましょう：

**C# - MainActivity.cs - PrevとNextボタンのクリックでスライドを表示**

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

最後に、スライドをタッチしたときに楕円形を追加する機能を実装しましょう：

**C# - MainActivity.cs - スライドのクリックで楕円を追加**

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

プレゼンテーションスライド上の各クリックでランダムな色の楕円が追加されます：

![todo:image_alt_text](https://lh4.googleusercontent.com/RhjFHm6SgzOkXaehKhsY8q7SRZLFC7vV8_jyw-Gy4Scy68wTMg_apLZ3vPzRLOt1eEw_zUZmLlVhJ8oTGCg10dRNAETLSClRTBEyj2MWuefNpJI4i7WLIe0x8A7xuh4CV91loLKi)

## **サポートされている機能**

|**機能** |**Aspose.Slides for .NET**  |**Aspose.Slides for Xamarin**|
| :- | :- | :- |
|**プレゼンテーション機能**: | | |
|新しいプレゼンテーションの作成 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 97 - 2003フォーマットのオープン/保存 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2007フォーマットのオープン/保存 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2010拡張機能のサポート |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2013拡張機能のサポート |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2016機能のサポート |制限あり|制限あり|
|PowerPoint 2019機能のサポート |制限あり |制限あり|
|PPT 2 PPTX変換 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTX 2 PPT変換 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTXをPPTに |制限あり|制限あり|
|テーマ処理 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|マクロ処理 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|文書プロパティの処理 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|パスワード保護 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|高速テキスト抽出 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|フォントの埋め込み |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|コメントのレンダリング |{{< emoticons/tick >}} |{{< emoticons/tick >}}|
|長時間実行タスクの中断 |{{< emoticons/tick >}}|{{< emoticons/tick >}} |
|**エクスポートフォーマット:** | | |
|PDF |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|XPS |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|HTML |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|TIFF |{{< emoticons/tick >}}|{{< emoticons/cross >}}|
|ODP |制限あり |制限あり |
|SWF |制限あり|制限あり|
|SVG |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**インポートフォーマット:** | | |
|HTML |制限あり|制限あり|
|ODP |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|THMX |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**マスタースライド機能:** | | |
|すべての既存のマスタースライドへのアクセス |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|マスタースライドの作成/削除 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|マスタースライドのクローン作成 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**レイアウトスライド機能:** | | |
|すべての既存のレイアウトスライドへのアクセス |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|レイアウトスライドの作成/削除 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|レイアウトスライドのクローン作成 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**スライド機能:** | | |
|すべての既存のスライドへのアクセス |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|スライドの作成/削除 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|スライドのクローン作成 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|画像へのスライドのエクスポート |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|スライドセクションの作成/編集/削除 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**ノートスライド機能:** | | |
|すべての既存のノートスライドへのアクセス |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**形状機能:** | | |
|すべてのスライド形状へのアクセス |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|新しい形状の追加 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|形状のクローン作成 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|別々の形状を画像にエクスポート |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**サポートされている形状タイプ:** | | |
|すべての定義済み形状タイプ |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|画像フレーム |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|表 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|チャート |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|SmartArt |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|レガシーダイアグラム |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|WordArt |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|OLE、ActiveXオブジェクト |制限あり|制限あり|
|ビデオフレーム |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|オーディオフレーム |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|コネクタ |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**グループ形状機能:** | | |
|グループ形状へのアクセス |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|グループ形状の作成 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|既存のグループ形状のグループ解除 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**形状効果機能:** | | |
|2D効果 |制限あり|制限あり|
|3D効果 |{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|**テキスト機能:** | | |
|段落のフォーマット |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|ポーションのフォーマット |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**アニメーション機能:** | | |
|SWFへのアニメーションのエクスポート |{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|HTMLへのアニメーションのエクスポート |{{< emoticons/cross >}}|{{< emoticons/cross >}}|