---
title: Aspose.Slides Xamarinhez (Történelmi)
linktitle: Xamarin (Történelmi)
type: docs
weight: 200
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
description: "Történelmi: hogy az Aspose.Slides for .NET 20.2-től 22.10-ig terjedő verziói hogyan támogatták a Xamarin.Android-ot egy külön könyvtáron keresztül. A jelenlegi verziók nem tartalmazzák."
---
{{% alert color="info" title="Megjegyzés" %}}

Ez egy történelmi oldal. A Aspose.Slides.NET csomag 20.2 és 22.10 közötti verziói tartalmazták a külön Xamarin.Android könyvtárat, a *Aspose.Slides.Droid.dll*-t, amelyet az ezen az oldalon található kód használ. Későbbi verziók nem tartalmazzák: a jelenlegi csomag csak .NET Framework 4.6.2, .NET 6 és .NET Standard 2.0 buildeket tartalmaz. A Microsoft 2024. május 1-jén befejezte az összes Xamarin SDK támogatását; lásd a [Xamarin támogatási szabályzatot](https://dotnet.microsoft.com/en-us/platform/support/policy/xamarin).

{{% /alert %}}

## **Introduction**

A Xamarin egy keretrendszer, amely a .NET C# mobilfejlesztéshez használható. A Xamarin eszközökkel és könyvtárakkal bővíti a .NET platform képességeit. Lehetővé teszi a fejlesztők számára, hogy alkalmazásokat építsenek az **Android** operációs rendszerhez.

{{% alert color="info" title="Megjegyzés" %}}

Xamarin fejlesztéshez a programozók a szokásos fejlesztőkörnyezetüket (C#, Visual Studio és harmadik fél könyvtárak) használhatják.

{{% /alert %}}

Az Aspose.Slides API működött a Xamarin platformon. Ennek eléréséhez a Aspose.Slides.NET csomag a 20.2‑től 22.10‑ig terjedő verziókban külön DLL‑t adott a Xamarin számára. Az Aspose.Slides for Xamarin a .NET verzióban elérhető funkciók nagy részét támogatta:

- prezentációk konvertálása és megtekintése.
- prezentációk tartalmának szerkesztése: szöveg, alakzatok, diagramok, SmartArt, audio/videó, betűkészletek stb.
- animációk, 2D effektusok, WordArt kezelése stb.
- metaadatok és dokumentumtulajdonságok kezelése.
- klónozás, egyesítés, összehasonlítás, felosztás stb.

A teljes funkciók összehasonlítását a lap alján található másik szakaszban biztosítjuk.

Az Aspose.Slides for Xamarin API‑ban az osztályok, névterek, logika és viselkedés a lehető leginkább hasonlított a .NET verzióra. Aspose.Slides .NET alkalmazásait minimális költséggel lehetett Xamarinra migrálni.


## **Quick Example**
Az Aspose.Slides for Xamarin segítségével építheted és használhatod a C# alkalmazásodat Android diákon keresztül.

Egy Androidra Xamarin alkalmazás példáját mutatjuk be, amely az Aspose.Slides‑t használja a prezentációs diák megjelenítéséhez és érintéskor új alakzatot ad a diára. A példák teljes forráskódját megtalálod a [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Xamarin).

Kezdjük egy Xamarin Android alkalmazás létrehozásával:

![Creating a Xamarin Android app](https://lh3.googleusercontent.com/sNkKZnuuGo8phWI-4g4jRA_ZESKpO9RXehPj46RVymXGPcCJuYooePXcBEcb7N6uUUxgocl4o9OjwnajzWKmL2i4MUz3gKKwXw6C0ow_VScN8vlyGBK3SpLKoE_m9BDJ3iNE4xPj)

Először egy tartalomelrendezést hozunk létre, amely egy image view‑t, valamint Prev és Next gombokat tartalmaz:

![Content layout with an image view and Prev and Next buttons](https://lh3.googleusercontent.com/rX9leIvYTVzQa0YAMj_jPUPs-c9_HwGPZUfR5A3FLiTk0-qzUQ29FfM4hammUVXbbw_Ly0LwEM_VnaI6vslEEMcVlEwVMem0LTiX5kYsA4lxtiHrvXfDPruWPOGU1YKDYSWcNM54)

**XML - content_main.xml – Tartalomelrendezés létrehozása**
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

Itt hivatkozunk a "Aspose.Slides.Droid.dll" könyvtárra, amely tartalmaz egy mintaprezentációt ("HelloWorld.pptx") a Xamarin alkalmazás Assets mappájában, és hozzáadjuk a inicializációt a MainActivity‑hez:

**C# - MainActivity.cs – Inicializáció**
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

Adjunk hozzá egy függvényt, amely a Prev és Next gombok érintésére megjeleníti a diát:

**C# - MainActivity.cs – Diák megjelenítése Prev és Next gomb nyomásra**
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

Végül valósítsuk meg a függvényt, amely érintéskor ellipszist ad a diára:

**C# - MainActivity.cs – Ellipszis hozzáadása dia kattintásra**
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
![Slide with ellipses added by touch](https://lh4.googleusercontent.com/RhjFHm6SgzOkXaehKhsY8q7SRZLFC7vV8_jyw-Gy4Scy68wTMg_apLZ3vPzRLOt1eEw_zUZmLlVhJ8oTGCg10dRNAETLSClRTBEyj2MWuefNpJI4i7WLIe0x8A7xuh4CV91loLKi)


## **Supported Features**

|**FUNKCIÓK**|**Aspose.Slides for .NET**|**Aspose.Slides for Xamarin**|
| :- | :- | :- |
|**Prezentációs funkciók**| | |
|Új prezentációk létrehozása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 97‑2003 formátumok megnyitása/mentése|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2007 formátumok megnyitása/mentése|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2010 kiterjesztések támogatása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2013 kiterjesztések támogatása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2016 funkciók támogatása|korlátozott|korlátozott|
|PowerPoint 2019 funkciók támogatása|korlátozott|korlátozott|
|PPT → PPTX konverzió|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTX → PPT konverzió|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTX beágyazása PPT‑be|korlátozott|korlátozott|
|Témák feldolgozása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Makrók feldolgozása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Dokumentumtulajdonságok feldolgozása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Jelszóvédelem|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Gyors szövegkinyerés|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Betűk beágyazása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Megjegyzések megjelenítése|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Hosszú futású feladatok megszakítása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Export formátumok**| | |
|PDF|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|XPS|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|HTML|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|TIFF|{{< emoticons/tick >}}|{{< emoticons/cross >}}|
|ODP|korlátozott|korlátozott|
|SWF|korlátozott|korlátozott|
|SVG|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Import formátumok**| | |
|HTML|korlátozott|korlátozott|
|ODP|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|THMX|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Mesterdia funkciók**| | |
|Minden meglévő mesterdia elérése|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Mesterdiak létrehozása/eltávolítása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Mesterdiak klónozása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Elrendezési dia funkciók**| | |
|Minden meglévő elrendezési dia elérése|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Elrendezési diák létrehozása/eltávolítása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Elrendezési diák klónozása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Dia funkciók**| | |
|Minden meglévő dia elérése|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Diák létrehozása/eltávolítása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Diák klónozása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Diák exportálása képekbe|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Dia szakaszok létrehozása/szerkesztése/eltávolítása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Megjegyzés dia funkciók**| | |
|Minden meglévő megjegyzés dia elérése|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Alakzat funkciók**| | |
|Minden dia alakzat elérése|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Új alakzatok hozzáadása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Alakzatok klónozása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Alakzatok különálló exportálása képekbe|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Támogatott alakzattípusok**| | |
|Minden előre definiált alakzattípus|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Képkocka keretek|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Táblák|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Diagramok|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|SmartArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Örökölt diagram|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|WordArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|OLE, ActiveX objektumok|korlátozott|korlátozott|
|Videó keretek|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Audio keretek|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Kapcsolók|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Csoport alakzat funkciók**| | |
|Csoport alakzatok elérése|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Csoport alakzatok létrehozása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Létező csoport alakzatok szétbontása|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Alakzat hatás funkciók**| | |
|2D hatások|korlátozott|korlátozott|
|3D hatások|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|**Szöveg funkciók**| | |
|Bekezdésformázás|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Részletformázás|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Animációs funkciók**| | |
|Animáció exportálása SWF‑be|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|Animáció exportálása HTML‑be|{{< emoticons/cross >}}|{{< emoticons/cross >}}|