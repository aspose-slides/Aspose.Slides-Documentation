---
title: Aspose.Slides voor Xamarin
type: docs
weight: 150
url: /nl/net/aspose-slides-for-xamarin/
keywords:
- Xamarin
- mobiele ontwikkeling
- Android
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Bouw Xamarin‑mobiele apps in C# om presentaties te bekijken, bewerken en converteren met Aspose.Slides, met rijke functionaliteit voor PPT, PPTX en ODP op Android."
---
## **Introductie**

Xamarin is een framework dat wordt gebruikt voor mobiele ontwikkeling in .NET C#. Xamarin beschikt over tools en bibliotheken die de mogelijkheden van het .NET‑platform uitbreiden. Het stelt ontwikkelaars in staat om applicaties te bouwen voor het **Android**‑besturingssysteem. 

{{% alert color="info" %}} 

Voor ontwikkeling in Xamarin kunnen programmeurs hun reguliere ontwikkelomgevingen (C#, Visual Studio en bibliotheken van derden) gebruiken.

{{% /alert %}}

Aspose.Slides API werkt op het Xamarin‑platform. Om dit te realiseren voegt het Aspose.Slides .NET‑pakket een aparte DLL voor Xamarin toe. Aspose.Slides voor Xamarin ondersteunt de meeste functies die beschikbaar zijn in de .NET‑versie:

- presentaties converteren en weergeven.
- inhoud in presentaties bewerken: tekst, vormen, diagrammen, SmartArt, audio/video, lettertypen, enz.
- animaties, 2D‑effecten, WordArt, enz. behandelen.
- metadata en documenteigenschappen behandelen.
- clonen, samenvoegen, vergelijken, opsplitsen, enz.

We hebben een vergelijking van de volledige functies verstrekt in een andere sectie vlak onderaan deze pagina.

In de Aspose.Slides‑API voor Xamarin zijn de klassen, namespaces, logica en gedrag zo veel mogelijk gelijk aan de .NET‑versie. U kunt uw Aspose.Slides‑.NET‑toepassingen met minimale kosten naar Xamarin migreren.


## **Snel voorbeeld**
U kunt Aspose.Slides voor Xamarin gebruiken om uw C#‑applicatie via Slides for Android te bouwen en te benutten.

We bieden een voorbeeld van een Android‑via‑Xamarin‑applicatie die Aspose.Slides gebruikt om presentatiedia’s weer te geven en een nieuwe vorm aan de dia toe te voegen bij aanraking. U vindt de volledige broncode van de voorbeelden op [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Xamarin).

Laten we beginnen met het maken van een Xamarin Android‑app:

![todo:image_alt_text](https://lh3.googleusercontent.com/sNkKZnuuGo8phWI-4g4jRA_ZESKpO9RXehPj46RVymXGPcCJuYooePXcBEcb7N6uUUxgocl4o9OjwnajzWKmL2i4MUz3gKKwXw6C0ow_VScN8vlyGBK3SpLKoE_m9BDJ3iNE4xPj)

Eerst maken we een lay-out die een ImageView, Prev‑ en Next‑knoppen bevat:

![todo:image_alt_text](https://lh3.googleusercontent.com/rX9leIvYTVzQa0YAMj_jPUPs-c9_HwGPZUfR5A3FLiTk0-qzUQ29FfM4hammUVXbbw_Ly0LwEM_VnaI6vslEEMcVlEwVMem0LTiX5kYsA4lxtiHrvXfDPruWPOGU1YKDYSWcNM54)



**XML - content_main.xml - Layout maken**
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



Hier verwijzen we naar de “Aspose.Slides.Droid.dll”‑bibliotheek die een voorbeeldpresentatie (“HelloWorld.pptx”) bevat in de Xamarin‑applicatie‑Assets en voegen we de initialisatie toe aan MainActivity:

**C# - MainActivity.cs - Initialisatie**

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

Laten we de functie toevoegen om de Prev‑ en Next‑dia’s weer te geven bij het aanraken van de knoppen:

**C# - MainActivity.cs - Dia’s weergeven bij klik op Prev‑ en Next‑knop**

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



Tot slot implementeren we een functie om bij een aanraking op de dia een ellipsvorm toe te voegen:

**C# - MainActivity.cs - Ellips toevoegen bij klik op dia**

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

Elke klik op de presentatiedia zorgt voor een ellips met willekeurige kleur:

![todo:image_alt_text](https://lh4.googleusercontent.com/RhjFHm6SgzOkXaehKhsY8q7SRZLFC7vV8_jyw-Gy4Scy68wTMg_apLZ3vPzRLOt1eEw_zUZmLlVhJ8oTGCg10dRNAETLSClRTBEyj2MWuefNpJI4i7WLIe0x8A7xuh4CV91loLKi)


## **Ondersteunde functies**

|**FUNCTIES**|**Aspose.Slides for .NET**|**Aspose.Slides for Xamarin**|
| :- | :- | :- |
|**Presentatiefuncties:**| | |
|Nieuwe presentaties maken|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 97‑2003-formaten openen/opslaan|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint‑2007-formaten openen/opslaan|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Ondersteuning voor PowerPoint‑2010‑extensies|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Ondersteuning voor PowerPoint‑2013‑extensies|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Ondersteuning voor PowerPoint‑2016-functies|restricted|restricted|
|Ondersteuning voor PowerPoint‑2019-functies|restricted |restricted|
|Conversie PPT → PPTX|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Conversie PPTX → PPT|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTX in PPT|restricted|restricted|
|Verwerking van thema's|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Verwerking van macro's|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Verwerking van documenteigenschappen|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Wachtwoordbeveiliging|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Snelle teksextractie|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Lettertypen insluiten|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Weergave van opmerkingen|{{< emoticons/tick >}} |{{< emoticons/tick >}}|
|Onderbreken van langdurige taken|{{< emoticons/tick >}}|{{< emoticons/tick >}} |
|**Exportformaten:**| | |
|PDF|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|XPS|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|HTML|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|TIFF|{{< emoticons/tick >}}|{{< emoticons/cross >}}|
|ODP|restricted |restricted|
|SWF|restricted|restricted|
|SVG|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Importformaten:**| | |
|HTML|restricted|restricted|
|ODP|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|THMX|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Functies van meester‑dia's:**| | |
|Toegang tot alle bestaande meester‑dia's|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Meester‑dia's maken/verwijderen|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Meester‑dia's klonen|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Functies van lay-outdia's:**| | |
|Toegang tot alle bestaande lay-outdia's|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Lay-outdia's maken/verwijderen|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Lay-outdia's klonen|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Dia‑functies:**| | |
|Toegang tot alle bestaande dia's|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Dia's maken/verwijderen|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Dia's klonen|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Dia's exporteren naar afbeeldingen|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Dia‑secties maken/bewerken/verwijderen|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Notitiesdia‑functies:**| | |
|Toegang tot alle bestaande notitiesdia's|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Vormfuncties:**| | |
|Toegang tot alle dia‑vormen|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Nieuwe vormen toevoegen|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Vormen klonen|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Vormen afzonderlijk exporteren naar afbeeldingen|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Ondersteunde vormtypes:**| | |
|Alle vooraf gedefinieerde vormtypes|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Afbeeldingskaders|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Tabellen|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Diagrammen|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|SmartArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Legacy‑diagram|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|WordArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|OLE, ActiveX‑objecten|restricted|restricted|
|Video‑frames|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Audio‑frames|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Connectoren|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Functies van groepsvormen:**| | |
|Toegang tot groepsvormen|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Groepsvormen maken|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Groepsvormen ongroeperen|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Functies van vormeffecten:**| | |
|2D‑effecten|restricted|restricted|
|3D‑effecten|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|**Tekstfuncties:**| | |
|Opmaak van alinea's|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Opmaak van segmenten|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Animatiefuncties:**| | |
|Animatie exporteren naar SWF|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|Animatie exporteren naar HTML|{{< emoticons/cross >}}|{{< emoticons/cross >}}|