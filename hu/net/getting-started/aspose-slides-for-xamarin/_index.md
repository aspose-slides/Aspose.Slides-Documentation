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
description: "Készítsen Xamarin mobilalkalmazásokat C#-ban, amelyek megtekintik, szerkesztik és konvertálják a prezentációkat az Aspose.Slides segítségével, és gazdag funkciókat támogatnak a PPT, PPTX és ODP formátumokhoz Androidon."
---
## **Bevezetés**

A Xamarin egy keretrendszer, amelyet a .NET C# mobilfejlesztéshez használnak. A Xamarin eszközökkel és könyvtárakkal bővíti a .NET platform képességeit. Lehetővé teszi a fejlesztők számára, hogy alkalmazásokat építsenek az **Android** operációs rendszerre. 

{{% alert color="info" %}} 

Xamarin fejlesztéséhez a programozók a szokásos fejlesztőkörnyezetüket (C#, Visual Studio és harmadik féltől származó könyvtárakat) használhatják.

{{% /alert %}}

Az Aspose.Slides API a Xamarin platformon működik. Ennek eléréséhez az Aspose.Slides .NET csomag külön DLL‑t ad a Xamarinhoz. Az Aspose.Slides for Xamarin támogatja a .NET verzióban elérhető legtöbb funkciót:

- prezentációk konvertálása és megtekintése.
- prezentációk tartalmának szerkesztése: szöveg, alakzatok, diagramok, SmartArt, audio/videó, betűkészletek stb.
- animációk, 2D‑effektek, WordArt stb. kezelése.
- metaadatok és dokumentumtulajdonságok kezelése.
- nyomtatás, klónozás, egyesítés, összehasonlítás, szétválasztás stb.

A teljes funkciók összehasonlítását egy másik szakaszban, az oldal alja felé tettük.

Az Aspose.Slides for Xamarin API‑ban az osztályok, névterek, logika és viselkedés a lehető leginkább hasonló a .NET verzióhoz. Az Aspose.Slides .NET alkalmazásokat minimális költséggel migrálhatja Xamarinra.


## **Gyors példa**
Az Aspose.Slides for Xamarin segítségével építheti és használhatja C# alkalmazását az Android Slides-en keresztül.

Egy Androidos Xamarin alkalmazás példáját mutatjuk be, amely az Aspose.Slides‑t használja a prezentációs diák megjelenítéséhez, és érintéskor új alakzatot ad a diára. A példák teljes forráskódját megtalálja a [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Xamarin) oldalon.

Kezdjük egy Xamarin Android alkalmazás létrehozásával:

![todo:image_alt_text](https://lh3.googleusercontent.com/sNkKZnuuGo8phWI-4g4jRA_ZESKpO9RXehPj46RVymXGPcCJuYooePXcBEcb7N6uUUxgocl4o9OjwnajzWKmL2i4MUz3gKKwXw6C0ow_VScN8vlyGBK3SpLKoE_m9BDJ3iNE4xPj)

Először egy tartalomelrendezést hozunk létre, amely tartalmaz egy képnézetet, valamint Az előző és Következő gombokat:

![todo:image_alt_text](https://lh3.googleusercontent.com/rX9leIvYTVzQa0YAMj_jPUPs-c9_HwGPZUfR5A3FLiTk0-qzUQ29FfM4hammUVXbbw_Ly0LwEM_VnaI6vslEEMcVlEwVMem0LTiX5kYsA4lxtiHrvXfDPruWPOGU1YKDYSWcNM54)

**XML - content_main.xml - Tartalomelrendezés létrehozása**
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

Ebben hivatkozunk az "Aspose.Slides.Droid.dll" könyvtárra, amely egy mintaprezentációt ("HelloWorld.pptx") tartalmaz a Xamarin alkalmazás Assets mappájába, és inicializálását a MainActivity‑ben adjuk hozzá:

**C# - MainActivity.cs - Inicializálás**

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

Adjunk hozzá egy függvényt, amely a gombok érintésére megjeleníti az előző és következő diákat:

**C# - MainActivity.cs - Diák megjelenítése az Előző és Következő gomb kattintásakor**

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

Végül valósítsuk meg azt a függvényt, amely a diára érintéskor ellipszis alakzatot ad hozzá:

**C# - MainActivity.cs - Ellipszis hozzáadása diakattintásra**

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

Minden diára kattintás egy véletlenszerű színű ellipszist ad hozzá:

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
|PPT → PPTX konverzió|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTX → PPT konverzió|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTX PPT‑ben|restricted|restricted|
|Témák feldolgozása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Makrók feldolgozása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Dokumentum tulajdonságok feldolgozása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Jelszóvédelem|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Gyors szövegkinyerés|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Betűkészletek beágyazása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Megjegyzések megjelenítése|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Hosszú futású feladatok megszakítása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Export formátumok:**| | |
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
|**Mester dia funkciók:**| | |
|Az összes meglévő mester dia elérése|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Mester diák létrehozása/eltávolítása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Mester diák klónozása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Elrendezés diák funkciók:**| | |
|Az összes meglévő elrendezés dia elérése|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Elrendezés diák létrehozása/eltávolítása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Elrendezés diák klónozása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Dia funkciók:**| | |
|Az összes meglévő dia elérése|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Diaiak létrehozása/eltávolítása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Diaszámok klónozása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Diaszámok képpé exportálása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Diaszakaszok létrehozása/szerkesztése/eltávolítása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Megjegyzés diák funkciói:**| | |
|Az összes meglévő megjegyzés dia elérése|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Alakzat funkciók:**| | |
|Az összes dia alakzat elérése|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Új alakzatok hozzáadása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Alakzatok klónozása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Az egyedi alakzatok exportálása képekké|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Támogatott alakzattípusok:**| | |
|Minden előre definiált alakzattípus|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Képkockák|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Táblázatok|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Diagramok|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|SmartArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Hagyományos diagram|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|WordArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|OLE, ActiveX objektumok|restricted|restricted|
|Videókeretek|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Audio keretek|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Kapcsolók|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Csoport alakzat funkciók:**| | |
|Csoport alakzatok elérése|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Csoport alakzatok létrehozása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|A meglévő csoport alakzatok felbontása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Alakzat effektusok funkciói:**| | |
|2D effektusok|restricted|restricted|
|3D effektusok|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|**Szöveg funkciók:**| | |
|Bekezdések formázása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Részletek formázása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Animációs funkciók:**| | |
|Animáció exportálása SWF‑be|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|Animáció exportálása HTML‑be|{{< emoticons/cross >}}|{{< emoticons/cross >}}|