---
title: Aspose.Slides pro Xamarin
type: docs
weight: 150
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
description: "Vytvářejte mobilní aplikace Xamarin v C# pro prohlížení, editaci a konverzi prezentací s Aspose.Slides, podporující bohaté funkce pro PPT, PPTX a ODP na Androidu."
---
## **Úvod**

Xamarin je framework používaný pro vývoj mobilních aplikací v .NET C#. Xamarin poskytuje nástroje a knihovny, které rozšiřují možnosti platformy .NET. Umožňuje vývojářům vytvářet aplikace pro operační systém **Android**.

{{% alert color="primary" %}} 

Pro vývoj v Xamarin mohou programátoři používat své běžné vývojové prostředí (C#, Visual Studio a knihovny třetích stran).

{{% /alert %}}

Aspose.Slides API funguje na platformě Xamarin. K tomu Aspose.Slides .NET balíček přidává samostatný DLL pro Xamarin. Aspose.Slides pro Xamarin podporuje většinu funkcí dostupných ve verzi .NET:

- konverzi a prohlížení prezentací.
- úpravu obsahu v prezentacích: text, tvary, grafy, SmartArt, audio/video, písma atd.
- práci s animacemi, 2D efekty, WordArt atd.
- práci s metadaty a vlastnostmi dokumentu.
- tisk, klonování, slučování, porovnávání, rozdělování atd.

V jiné sekci blízko konce této stránky jsme poskytli srovnání kompletních funkcí.

V API Aspose.Slides pro Xamarin jsou třídy, jmenné prostory, logika a chování co nejvíce podobné verzi .NET. Vaše aplikace Aspose.Slides .NET můžete migrovat na Xamarin s minimálními náklady.


## **Rychlý příklad**
Můžete použít Aspose.Slides pro Xamarin k vytvoření a využití vaší C# aplikace přes Slides pro Android.

Poskytujeme příklad Android aplikace pomocí Xamarin, která používá Aspose.Slides k zobrazení snímků prezentace a po doteku přidá nový tvar na snímek. Kompletní zdrojové kódy příkladů najdete na [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Xamarin).

Začněme vytvořením Xamarin Android aplikace:

![todo:image_alt_text](https://lh3.googleusercontent.com/sNkKZnuuGo8phWI-4g4jRA_ZESKpO9RXehPj46RVymXGPcCJuYooePXcBEcb7N6uUUxgocl4o9OjwnajzWKmL2i4MUz3gKKwXw6C0ow_VScN8vlyGBK3SpLKoE_m9BDJ3iNE4xPj)

Nejprve vytvoříme rozložení obsahu, které bude obsahovat ImageView, tlačítka Prev a Next:

![todo:image_alt_text](https://lh3.googleusercontent.com/rX9leIvYTVzQa0YAMj_jPUPs-c9_HwGPZUfR5A3FLiTk0-qzUQ29FfM4hammUVXbbw_Ly0LwEM_VnaI6vslEEMcVlEwVMem0LTiX5kYsA4lxtiHrvXfDPruWPOGU1YKDYSWcNM54)



**XML – content_main.xml – Vytvoření rozložení obsahu**
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



Zde odkazujeme na knihovnu „Aspose.Slides.Droid.dll“, která obsahuje ukázkovou prezentaci („HelloWorld.pptx“) vloženou do složky Assets Xamarin aplikace a přidává její inicializaci do MainActivity:

**C# – MainActivity.cs – Inicializace**

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

Přidáme funkci pro zobrazení snímků Prev a Next při klepnutí na tlačítka:

**C# – MainActivity.cs – Zobrazení snímků při kliknutí na tlačítka Prev a Next**

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



Nakonec implementujeme funkci, která při dotyku na snímku přidá elipsu:

**C# – MainActivity.cs – Přidání elipsy kliknutím na snímek**

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

![todo:image_alt_text](https://lh4.googleusercontent.com/RhjFHm6SgzOkXaehKhsY8q7SRZLFC7vV8_jyw-Gy4Scy68wTMg_apLZ3vPzRLOt1eEw_zUZmLlVhJ8oTGCg10dRNAETLSClRTBEyj2MWuefNpJI4i7WLIe0x8A7xuh4CV91loLKi)


## **Podporované funkce**

|**FUNKCE**|**Aspose.Slides pro .NET**|**Aspose.Slides pro Xamarin**|
| :- | :- | :- |
|**Funkce prezentace**:| | |
|Vytváření nových prezentací|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Otevírání/ukládání formátů PowerPoint 97‑2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Otevírání/ukládání formátů PowerPoint 2007|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Podpora rozšíření PowerPoint 2010|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Podpora rozšíření PowerPoint 2013|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Podpora funkcí PowerPoint 2016|omezený|omezený|
|Podpora funkcí PowerPoint 2019|omezený|omezený|
|Konverze PPT na PPTX|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Konverze PPTX na PPT|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTX v PPT|omezený|omezený|
|Zpracování motivů|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Zpracování maker|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Zpracování vlastností dokumentu|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Ochrana heslem|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Rychlé získávání textu|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Vkládání písem|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Vykreslování komentářů|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Přerušení dlouhotrvajících úkolů|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Exportní formáty:**| | |
|PDF|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|XPS|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|HTML|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|TIFF|{{< emoticons/tick >}}|{{< emoticons/cross >}}|
|ODP|omezený|omezený|
|SWF|omezený|omezený|
|SVG|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Importní formáty:**| | |
|HTML|omezený|omezený|
|ODP|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|THMX|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Funkce hlavních snímků:**| | |
|Přístup ke všem existujícím hlavním snímkům|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Vytváření/odstraňování hlavních snímků|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Klónování hlavních snímků|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Funkce rozvržení snímků:**| | |
|Přístup ke všem existujícím rozvrhům snímků|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Vytváření/odstraňování rozvrhů snímků|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Klónování rozvrhů snímků|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Funkce snímků:**| | |
|Přístup ke všem existujícím snímkům|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Vytváření/odstraňování snímků|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Klónování snímků|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Export snímků do obrázků|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Vytváření/upravování/odstraňování sekcí snímků|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Funkce poznámkových snímků:**| | |
|Přístup ke všem existujícím poznámkovým snímkům|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Funkce tvarů:**| | |
|Přístup ke všem tvarům na snímku|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Přidávání nových tvarů|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Klónování tvarů|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Export samostatných tvarů do obrázků|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Podporované typy tvarů:**| | |
|Všechny předdefinované typy tvarů|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Rámečky obrázků|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Tabulky|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Grafy|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|SmartArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Legacy diagram|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|WordArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|OLE, ActiveX objekty|omezený|omezený|
|Video rámečky|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Audio rámečky|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Spojnice|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Funkce seskupených tvarů:**| | |
|Přístup ke skupinovým tvarům|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Vytváření skupinových tvarů|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Rozdělení existujících skupinových tvarů|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Funkce efektů tvarů:**| | |
|2D efekty|omezený|omezený|
|3D efekty|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|**Textové funkce:**| | |
|Formátování odstavců|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Formátování částí textu|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Funkce animace:**| | |
|Export animace do SWF|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|Export animace do HTML|{{< emoticons/cross >}}|{{< emoticons/cross >}}|