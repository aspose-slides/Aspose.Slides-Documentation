---
title: Aspose.Slides Xamarin számára
type: docs
weight: 150
url: /hu/net/aspose-slides-for-xamarin/
keywords:
- Xamarin
- mobil fejlesztés
- Android
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Készítsen Xamarin mobilalkalmazásokat C#-ban, amelyek az Aspose.Slides segítségével megtekintik, szerkesztik és átalakítják a prezentációkat, gazdag PPT, PPTX és ODP funkciókat támogatva Androidon."
---
## **Bevezetés**

A Xamarin egy .NET C#-ra épülő keretrendszer mobilfejlesztéshez. A Xamarin eszközöket és könyvtárakat biztosít, amelyek kiterjesztik a .NET platform képességeit. Lehetővé teszi a fejlesztők számára, hogy **Android** operációs rendszerre építsenek alkalmazásokat.

{{% alert color="primary" %}} 

A Xamarin fejlesztéshez a programozók a szokásos fejlesztőkörnyezetüket (C#, Visual Studio és harmadik fél könyvtárak) használhatják.

{{% /alert %}}

Az Aspose.Slides API a Xamarin platformon is működik. Ennek érdekében az Aspose.Slides .NET csomag egy külön DLL‑t ad a Xamarin‑hez. Az Aspose.Slides for Xamarin támogatja a .NET változatban elérhető legtöbb funkciót:

- prezentációk konvertálása és megtekintése.
- prezentációk tartalmának szerkesztése: szöveg, alakzatok, diagramok, SmartArt, hang/video, betűtípusok stb.
- animációk, 2D‑effektek, WordArt kezelése.
- metaadatok és dokumentumtulajdonságok kezelése.
- nyomtatás, klónozás, egyesítés, összehasonlítás, felosztás stb.

A teljes funkciók összehasonlítását egy másik szakaszban, az oldal alján találja.

Az Aspose.Slides for Xamarin API‑ban az osztályok, névtér‑hierarchia, logika és viselkedés a .NET verzióhoz a lehető legközelebb áll. Aspose.Slides .NET alkalmazásait minimális költséggel migrálhatja Xamarinra.


## **Gyors példa**
Az Aspose.Slides for Xamarin‑t felhasználva C# alkalmazását Android Slides‑en keresztül építheti és használhatja.

Példaként egy Android‑Xamarin alkalmazást mutatunk be, amely az Aspose.Slides‑et használja prezentációs diák megjelenítésére és érintésre új alakzatot ad a diára. A példák teljes forráskódját megtalálja a [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Xamarin)‑on.

Kezdjük el egy Xamarin Android alkalmazás létrehozásával:

![todo:image_alt_text](https://lh3.googleusercontent.com/sNkKZnuuGo8phWI-4g4jRA_ZESKpO9RXehPj46RVymXGPcCJuYooePXcBEcb7N6uUUxgocl4o9OjwnajzWKmL2i4MUz3gKKwXw6C0ow_VScN8vlyGBK3SpLKoE_m9BDJ3iNE4xPj)

Először egy tartalom‑elrendezést hozunk létre, amely egy képnézetet, valamint Prev és Next gombokat tartalmaz:

![todo:image_alt_text](https://lh3.googleusercontent.com/rX9leIvYTVzQa0YAMj_jPUPs-c9_HwGPZUfR5A3FLiTk0-qzUQ29FfM4hammUVXbbw_Ly0LwEM_VnaI6vslEEMcVlEwVMem0LTiX5kYsA4lxtiHrvXfDPruWPOGU1YKDYSWcNM54)



**XML - content_main.xml - Tartalom elrendezés létrehozása**
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



Itt hivatkozunk az “Aspose.Slides.Droid.dll” könyvtárra, amely egy mintaprezentációt (“HelloWorld.pptx”) tartalmaz a Xamarin alkalmazás Assets mappájába, és inicializáljuk a MainActivity‑ben:

**C# - MainActivity.cs - Inicializálás**

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

Adjunk hozzá egy függvényt, amely a Prev és Next gombok érintésére megjeleníti a megfelelő diákat:

**C# - MainActivity.cs - Diák megjelenítése Prev és Next gombnyomásra**

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



Végül valósítsunk meg egy függvényt, amely érintéskor ellipszis alakzatot ad a diához:

**C# - MainActivity.cs - Ellipszis hozzáadása diá érintésekor**

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

Minden diára történő kattintás egy véletlenszerű színű ellipszist ad hozzá:

![todo:image_alt_text](https://lh4.googleusercontent.com/RhjFHm6SgzOkXaehKhsY8q7SRZLFC7vV8_jyw-Gy4Scy68wTMg_apLZ3vPzRLOt1eEw_zUZmLlVhJ8oTGCg10dRNAETLSClRTBEyj2MWuefNpJI4i7WLIe0x8A7xuh4CV91loLKi)


## **Támogatott funkciók**

|**FUNKCIÓK**|**Aspose.Slides for .NET**|**Aspose.Slides for Xamarin**|
| :- | :- | :- |
|**Prezentációs funkciók**:| | |
|Új prezentációk létrehozása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 97‑2003 formátumok megnyitása/mentése|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2007 formátumok megnyitása/mentése|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2010 kiterjesztések támogatása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2013 kiterjesztések támogatása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2016 funkciók támogatása|restricted|restricted|
|PowerPoint 2019 funkciók támogatása|restricted|restricted|
|PPT → PPTX konvertálás|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTX → PPT konvertálás|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTX beágyazása PPT‑be|restricted|restricted|
|Temák feldolgozása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Makrók feldolgozása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Dokumentumtulajdonságok feldolgozása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Jelszóvédelem|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Gyors szövegkinyerés|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Betűtípusok beágyazása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Megjegyzések megjelenítése|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Hosszú futású feladatok megszakítása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Exportálási formátumok:**| | |
|PDF|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|XPS|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|HTML|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|TIFF|{{< emoticons/tick >}}|{{< emoticons/cross >}}|
|ODP|restricted|restricted|
|SWF|restricted|restricted|
|SVG|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Importálási formátumok:**| | |
|HTML|restricted|restricted|
|ODP|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|THMX|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Mesterdia funkciók:**| | |
|Minden meglévő mesterdia elérése|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Mesterdiák létrehozása/eltávolítása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Mesterdiák klónozása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Elrendezésdia funkciók:**| | |
|Minden meglévő elrendezésdia elérése|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Elrendezésdiák létrehozása/eltávolítása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Elrendezésdiák klónozása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Dia funkciók:**| | |
|Minden meglévő dia elérése|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Diák létrehozása/eltávolítása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Diák klónozása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Diák exportálása képekbe|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Dia‑szakaszok létrehozása/szerkesztése/eltávolítása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Jegyzetdia funkciók**:| | |
|Minden meglévő jegyzetdia elérése|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Alakzatfunkciók:**| | |
|Minden dia‑alakzat elérése|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Új alakzatok hozzáadása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Alakzatok klónozása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Alakzatok különálló exportálása képekbe|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Támogatott alakzattípusok:**| | |
|Minden előre definiált alakzattípus|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Képkockák|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Táblázatok|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Diagramok|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|SmartArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Régi diagramok|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|WordArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|OLE, ActiveX objektumok|restricted|restricted|
|Videókockák|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Hangkockák|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Összekötők|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Csoportos alakzat funkciók:**| | |
|Csoportos alakzatok elérése|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Csoportos alakzatok létrehozása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Létező csoportos alakzatok felbontása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Alakzat‑effektus funkciók:**| | |
|2D‑effektek|restricted|restricted|
|3D‑effektek|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|**Szövegfunkciók:**| | |
|Bekezdésformázás|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Részletformázás|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Animációs funkciók:**| | |
|Animáció exportálása SWF‑be|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|Animáció exportálása HTML‑be|{{< emoticons/cross >}}|{{< emoticons/cross >}}|