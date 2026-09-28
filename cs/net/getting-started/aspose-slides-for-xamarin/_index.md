---
title: Aspose.Slides pro Xamarin (Historické)
linktitle: Xamarin (Historické)
type: docs
weight: 200
url: /cs/net/aspose-slides-for-xamarin/
keywords:
- Xamarin
- mobilní vývoj
- Android
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Historické: jak verze Aspose.Slides pro .NET 20.2 až 22.10 podporovaly Xamarin.Android prostřednictvím samostatné knihovny. Aktuální verze ji neobsahují."
---
{{% alert color="info" title="Poznámka" %}}
Toto je historická stránka. Verze 20.2 až 22.10 balíčku Aspose.Slides.NET zahrnovaly samostatnou knihovnu Xamarin.Android, *Aspose.Slides.Droid.dll*, kterou kód na této stránce používá. Pozdější verze ji neobsahují: aktuální balíček obsahuje sestavení jen pro .NET Framework 4.6.2, .NET 6 a .NET Standard 2.0. Microsoft ukončil podporu všech Xamarin SDK k 1. květnu 2024; viz [Xamarin support policy](https://dotnet.microsoft.com/en-us/platform/support/policy/xamarin).
{{% /alert %}}

## **Úvod**

Xamarin je framework používaný pro mobilní vývoj v .NET C#. Xamarin má nástroje a knihovny, které rozšiřují možnosti platformy .NET. Umožňuje vývojářům vytvářet aplikace pro operační systém **Android**.

{{% alert color="info" title="Poznámka" %}}
Pro vývoj v Xamarin mohou programátoři používat své běžné vývojové prostředí (C#, Visual Studio a knihovny třetích stran).
{{% /alert %}}

API Aspose.Slides fungovalo na platformě Xamarin. K dosažení tohoto cíle balíček Aspose.Slides.NET ve verzích 20.2 až 22.10 přidal samostatný DLL pro Xamarin. Aspose.Slides pro Xamarin podporovalo většinu funkcí dostupných ve verzi .NET:

- konverze a prohlížení prezentací.
- úpravu obsahu v prezentacích: text, tvary, grafy, SmartArt, audio/video, písma atd.
- práci s animacemi, 2D efekty, WordArt atd.
- práci s metadaty a vlastnostmi dokumentu.
- klonování, slučování, porovnávání, rozdělování atd.

Poskytli jsme srovnání kompletních funkcí v jiné sekci blízko konce této stránky.

V API Aspose.Slides pro Xamarin byly třídy, jmenné prostory, logika a chování co nejvíce podobné verzi .NET. Můžete migrovat své .NET aplikace Aspose.Slides do Xamarin s minimálními náklady.

## **Rychlý příklad**
Můžete použít Aspose.Slides pro Xamarin k vytvoření a využití vaší C# aplikace prostřednictvím Slides pro Android.

Poskytujeme příklad Android aplikace přes Xamarin, která používá Aspose.Slides k zobrazení snímků prezentace a při dotyku přidá nový tvar na snímek. Celý zdrojový kód příkladů najdete na [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Xamarin).

Začneme vytvořením Xamarin Android aplikace:

![Creating a Xamarin Android app](https://lh3.googleusercontent.com/sNkKZnuuGo8phWI-4g4jRA_ZESKpO9RXehPj46RVymXGPcCJuYooePXcBEcb7N6uUUxgocl4o9OjwnajzWKmL2i4MUz3gKKwXw6C0ow_VScN8vlyGBK3SpLKoE_m9BDJ3iNE4xPj)

Nejprve vytvoříme rozložení obsahu, které bude obsahovat ImageView, tlačítka Prev a Next:

![Content layout with an image view and Prev and Next buttons](https://lh3.googleusercontent.com/rX9leIvYTVzQa0YAMj_jPUPs-c9_HwGPZUfR5A3FLiTk0-qzUQ29FfM4hammUVXbbw_Ly0LwEM_VnaI6vslEEMcVlEwVMem0LTiX5kYsA4lxtiHrvXfDPruWPOGU1YKDYSWcNM54)

**XML - content_main.xml - Vytvoření rozložení obsahu**
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

Zde odkazujeme na knihovnu "Aspose.Slides.Droid.dll", která obsahuje ukázkovou prezentaci ("HelloWorld.pptx") vloženou do složky Assets Xamarin aplikace a přidává její inicializaci do MainActivity:

**C# - MainActivity.cs - Inicializace**
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

Přidáme funkci pro zobrazení snímků Prev a Next při kliknutí na tlačítka:

**C# - MainActivity.cs - Zobrazení snímků při kliknutí na tlačítka Prev a Next**
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

Nakonec implementujeme funkci pro přidání elipsovitého tvaru při dotyku snímku:

**C# - MainActivity.cs - Přidání elipsy kliknutím na snímek**
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

Každé kliknutí na snímek prezentace přidá elipsu s náhodnou barvou:

![Slide with ellipses added by touch](https://lh4.googleusercontent.com/RhjFHm6SgzOkXaehKhsY8q7SRZLFC7vV8_jyw-Gy4Scy68wTMg_apLZ3vPzRLOt1eEw_zUZmLlVhJ8oTGCg10dRNAETLSClRTBEyj2MWuefNpJI4i7WLIe0x8A7xuh4CV91loLKi)

## **Podporované funkce**

|**VLASTNOSTI**|**Aspose.Slides pro .NET**|**Aspose.Slides pro Xamarin**|
| :- | :- | :- |
|**Funkce prezentace**:| | |
|Vytváření nových prezentací|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Otevírání/ukládání formátů PowerPoint 97‑2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Otevírání/ukládání formátů PowerPoint 2007|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Podpora rozšíření PowerPoint 2010|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Podpora rozšíření PowerPoint 2013|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Podpora funkcí PowerPoint 2016|restricted|restricted|
|Podpora funkcí PowerPoint 2019|restricted|restricted|
|Konverze PPT → PPTX|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Konverze PPTX → PPT|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTX v PPT|restricted|restricted|
|Zpracování motivů|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Zpracování maker|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Zpracování vlastností dokumentu|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Ochrana heslem|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Rychlé získávání textu|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Vkládání písem|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Vykreslování komentářů|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Přerušení dlouhotrvajících úloh|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Exportní formáty:**| | |
|PDF|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|XPS|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|HTML|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|TIFF|{{< emoticons/tick >}}|{{< emoticons/cross >}}|
|ODP|restricted|restricted|
|SWF|restricted|restricted|
|SVG|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Importní formáty:**| | |
|HTML|restricted|restricted|
|ODP|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|THMX|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Funkce hlavních snímků:**| | |
|Přístup ke všem existujícím hlavním snímkům|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Vytváření/odstraňování hlavních snímků|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Klonování hlavních snímků|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Funkce rozvržení snímků:**| | |
|Přístup ke všem existujícím rozvržením snímků|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Vytváření/odstraňování rozvržení snímků|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Klonování rozvržení snímků|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Funkce snímků:**| | |
|Přístup ke všem existujícím snímkům|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Vytváření/odstraňování snímků|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Klonování snímků|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Export snímků do obrázků|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Vytváření/upravování/odstraňování sekcí snímků|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Funkce poznámkových snímků:**| | |
|Přístup ke všem existujícím poznámkovým snímkům|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Funkce tvarů:**| | |
|Přístup ke všem tvarům na snímku|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Přidávání nových tvarů|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Klonování tvarů|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Export jednotlivých tvarů do obrázků|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Podporované typy tvarů:**| | |
|Všechny předdefinované typy tvarů|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Rámečky obrázků|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Tabulky|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Grafy|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|SmartArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Legacy diagram|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|WordArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|OLE, ActiveX objekty|restricted|restricted|
|Video rámečky|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Audio rámečky|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Spojky|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Funkce seskupování tvarů:**| | |
|Přístup ke skupinovým tvarům|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Vytváření skupinových tvarů|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Rozdělování existujících skupinových tvarů|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Funkce efektů tvarů:**| | |
|2D efekty|restricted|restricted|
|3D efekty|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|**Textové funkce:**| | |
|Formátování odstavců|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Formátování úseků|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Funkce animací:**| | |
|Export animace do SWF|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|Export animace do HTML|{{< emoticons/cross >}}|{{< emoticons/cross >}}|