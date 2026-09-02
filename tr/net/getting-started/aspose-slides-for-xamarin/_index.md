---
title: Xamarin için Aspose.Slides
type: docs
weight: 150
url: /tr/net/aspose-slides-for-xamarin/
keywords:
- Xamarin
- mobil geliştirme
- Android
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides ile Xamarin mobil uygulamaları C#'ta oluşturun, sunumları görüntüleyin, düzenleyin ve dönüştürün; Android'de PPT, PPTX ve ODP için zengin özellikleri destekler."
---
## **Giriş**

Xamarin, .NET C# içinde mobil geliştirme için kullanılan bir çerçevedir. Xamarin, .NET platformunun yeteneklerini genişleten araç ve kütüphanelere sahiptir. Geliştiricilerin **Android** işletim sistemi için uygulama oluşturmasına olanak tanır. 

{{% alert color="info" %}} 
Xamarin geliştirme için, programcılar standart geliştirme ortamlarını (C#, Visual Studio ve üçüncü taraf kütüphaneler) kullanabilir. 
{{% /alert %}}

Aspose.Slides API, Xamarin platformunda çalışır. Bunu sağlamak için Aspose.Slides .NET paketi, Xamarin için ayrı bir DLL ekler. Aspose.Slides for Xamarin, .NET sürümünde bulunan özelliklerin çoğunu destekler:

- sunumları dönüştürme ve görüntüleme.
- sunumlardaki içerikleri düzenleme: metin, şekiller, grafikler, SmartArt, ses/video, yazı tipleri vb.
- animasyon, 2D efektler, WordArt vb. ile başa çıkma.
- metadata ve belge özellikleri ile başa çıkma.
- kopyalama, birleştirme, karşılaştırma, bölme vb.

Tam özellik karşılaştırmasını sayfanın alt kısmına yakın başka bir bölümde sağladık.

Aspose.Slides for Xamarin API'sinde sınıflar, ad alanları, mantık ve davranış .NET sürümüne mümkün olduğunca benzer şekilde tasarlanmıştır. Aspose.Slides .NET uygulamalarınızı minimum maliyetle Xamarin'e taşıyabilirsiniz.

## **Hızlı Örnek**

Aspose.Slides for Xamarin'i, C# uygulamanızı Android için Slides aracılığıyla oluşturmak ve kullanmak için kullanabilirsiniz.

Aspose.Slides'i kullanarak sunum slaytlarını görüntüleyen ve slayta dokunulduğunda yeni bir şekil ekleyen bir Xamarin Android uygulama örneği sunuyoruz. Örneklerin tam kaynağını [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Xamarin) adresinde bulabilirsiniz.

Xamarin Android Uygulaması oluşturarak başlayalım:

![todo:image_alt_text](https://lh3.googleusercontent.com/sNkKZnuuGo8phWI-4g4jRA_ZESKpO9RXehPj46RVymXGPcCJuYooePXcBEcb7N6uUUxgocl4o9OjwnajzWKmL2i4MUz3gKKwXw6C0ow_VScN8vlyGBK3SpLKoE_m9BDJ3iNE4xPj)

İlk olarak, bir resim görünümü, Ön ve Sonraki düğmelerini içerecek bir içerik düzeni oluşturuyoruz:

![todo:image_alt_text](https://lh3.googleusercontent.com/rX9leIvYTVzQa0YAMj_jPUPs-c9_HwGPZUfR5A3FLiTk0-qzUQ29FfM4hammUVXbbw_Ly0LwEM_VnaI6vslEEMcVlEwVMem0LTiX5kYsA4lxtiHrvXfDPruWPOGU1YKDYSWcNM54)

**XML - content_main.xml - İçerik düzeni oluştur**
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

Burada, Xamarin uygulama Assets'ine örnek bir sunum ("HelloWorld.pptx") içeren "Aspose.Slides.Droid.dll" kütüphanesini referans gösteriyor ve onun başlatmasını MainActivity'ye ekliyoruz:

**C# - MainActivity.cs - Başlatma**
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

Ön ve Sonraki slaytları düğmelere dokunulduğunda göstermek için fonksiyonu ekleyelim:

**C# - MainActivity.cs - Ön ve Sonraki düğme tıklamasında slaytları göster**
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

Son olarak, slayta dokunulduğunda bir elips şekli eklemek için bir fonksiyon uygulayalım:

**C# - MainActivity.cs - Slayt tıklamasıyla elips ekle**
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

Sunum slaytına yapılan her tıklama, rastgele renkli bir elips ekler:
![todo:image_alt_text](https://lh4.googleusercontent.com/RhjFHm6SgzOkXaehKhsY8q7SRZLFC7vV8_jyw-Gy4Scy68wTMg_apLZ3vPzRLOt1eEw_zUZmLlVhJ8oTGCg10dRNAETLSClRTBEyj2MWuefNpJI4i7WLIe0x8A7xuh4CV91loLKi)

## **Desteklenen Özellikler**

|**ÖZELLİKLER**|**Aspose.Slides .NET için**|**Xamarin için Aspose.Slides**|
| :- | :- | :- |
|**Sunum özellikleri**:| | |
|Yeni sunumlar oluşturma|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 97 - 2003 formatlarını açma/kaydetme|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2007 formatlarını açma/kaydetme|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2010 uzantı desteği|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2013 uzantı desteği|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2016 özellik desteği|restricted|restricted|
|PowerPoint 2019 özellik desteği|restricted|restricted|
|PPT'den PPTX'e dönüşüm|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTX'den PPT'e dönüşüm|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPT içinde PPTX|restricted|restricted|
|Tema işleme|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Makro işleme|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Belge özelliği işleme|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Şifre koruması|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Hızlı metin çıkarma|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Yazı tipi gömme|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Yorumları renderleme|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Uzun süren görevlerin kesilmesi|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Dışa aktarma formatları:**| | |
|PDF|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|XPS|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|HTML|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|TIFF|{{< emoticons/tick >}}|{{< emoticons/cross >}}|
|ODP|restricted|restricted|
|SWF|restricted|restricted|
|SVG|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**İçe aktarma formatları:**| | |
|HTML|restricted|restricted|
|ODP|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|THMX|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Ana slayt özellikleri:**| | |
|Mevcut tüm ana slaytlara erişim|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Ana slayt oluşturma/kaldırma|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Ana slaytları kopyalama|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Düzen slayt özellikleri:**| | |
|Mevcut tüm düzen slaytlarına erişim|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Düzen slaytları oluşturma/kaldırma|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Düzen slaytlarını kopyalama|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Slayt özellikleri:**| | |
|Mevcut tüm slaytlara erişim|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Slayt oluşturma/kaldırma|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Slaytları kopyalama|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Slaytları görüntülere dışa aktarma|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Slayt bölümlerini oluşturma/düzenleme/kaldırma|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Not slaytları özellikleri:**| | |
|Mevcut tüm not slaytlarına erişim|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Şekil (Shape) özellikleri:**| | |
|Tüm slayt şekillerine erişim|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Yeni şekiller ekleme|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Şekilleri kopyalama|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Ayrı şekilleri görüntülere dışa aktarma|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Desteklenen şekil türleri:**| | |
|Tüm önceden tanımlı şekil türleri|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Resim çerçeveleri|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Tablolar|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Grafikler|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|SmartArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Eski diyagram|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|WordArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|OLE, ActiveX nesneleri|restricted|restricted|
|Video kareleri|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Ses kareleri|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Bağlayıcılar|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Grup şekil özellikleri:**| | |
|Grup şekillerine erişim|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Grup şekilleri oluşturma|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Mevcut grup şekillerini gruptan çıkarma|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Şekil efektleri özellikleri:**| | |
|2D efektler|restricted|restricted|
|3D efektler|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|**Metin özellikleri:**| | |
|Paragraf biçimlendirme|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Parça biçimlendirme|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Animasyon Özellikleri:**| | |
|Animasyonu SWF'ye dışa aktarma|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|Animasyonu HTML'ye dışa aktarma|{{< emoticons/cross >}}|{{< emoticons/cross >}}|