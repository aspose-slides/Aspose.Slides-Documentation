---
title: Aspose.Slides voor Xamarin (Historisch)
linktitle: Xamarin (Historisch)
type: docs
weight: 200
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
description: "Historisch: hoe Aspose.Slides voor .NET versies 20.2 tot 22.10 Xamarin.Android ondersteunde via een aparte bibliotheek. Huidige versies bevatten dit niet."
---
{{% alert color="info" title="Opmerking" %}}

Dit is een historische pagina. Versies 20.2 tot 22.10 van het Aspose.Slides.NET‑pakket bevatten een aparte Xamarin.Android‑bibliotheek, *Aspose.Slides.Droid.dll*, die in de code op deze pagina wordt gebruikt. Latere versies bevatten deze niet meer: het huidige pakket biedt alleen builds voor .NET Framework 4.6.2, .NET 6 en .NET Standard 2.0. Microsoft heeft op 1 mei 2024 de ondersteuning voor alle Xamarin‑SDK’s beëindigd; zie het [Xamarin‑ondersteuningsbeleid](https://dotnet.microsoft.com/en-us/platform/support/policy/xamarin).

{{% /alert %}}

## **Introductie**

Xamarin is een framework dat wordt gebruikt voor mobiele ontwikkeling in .NET C#. Xamarin biedt tools en bibliotheken die de mogelijkheden van het .NET‑platform uitbreiden. Het stelt ontwikkelaars in staat om applicaties te bouwen voor het **Android**‑besturingssysteem.

{{% alert color="info" title="Opmerking" %}}

Voor ontwikkeling in Xamarin kunnen programmeurs hun gewone ontwikkelomgevingen gebruiken (C#, Visual Studio en 3rd‑party‑bibliotheken).

{{% /alert %}}

De Aspose.Slides‑API werkte op het Xamarin‑platform. Om dit te bereiken heeft het Aspose.Slides.NET‑pakket, in de versies 20.2 tot 22.10, een aparte DLL voor Xamarin toegevoegd. Aspose.Slides voor Xamarin ondersteunde het grootste deel van de functies die beschikbaar zijn in de .NET‑versie:

- presentaties converteren en bekijken.
- inhoud van presentaties bewerken: tekst, vormen, grafieken, SmartArt, audio/video, lettertypen, enz.
- omgaan met animaties, 2D‑effecten, WordArt, enz.
- omgaan met metadata en documenteigenschappen.
- klonen, samenvoegen, vergelijken, splitsen, enz.

We hebben een vergelijking van de volledige functionaliteit in een andere sectie onderaan deze pagina opgenomen.

In de Aspose.Slides‑API voor Xamarin waren de klassen, namespaces, logica en gedrag zo veel mogelijk gelijk aan de .NET‑versie. U kon uw Aspose.Slides‑.NET‑applicaties met minimale inspanning naar Xamarin migreeren.

## **Snel voorbeeld**

U kunt Aspose.Slides voor Xamarin gebruiken om uw C#‑applicatie te bouwen en te benutten via Slides for Android.

We bieden een voorbeeld van een Android‑via‑Xamarin‑applicatie die Aspose.Slides gebruikt om presentatiedia's weer te geven en een nieuwe vorm toevoegt op de dia bij aanraking. De volledige broncode van de voorbeelden vindt u op [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Xamarin).

Laten we beginnen met het maken van een Xamarin Android‑app:

![Een Xamarin Android‑app maken](https://lh3.googleusercontent.com/sNkKZnuuGo8phWI-4g4jRA_ZESKpO9RXehPj46RVymXGPcCJuYooePXcBEcb7N6uUUxgocl4o9OjwnajzWKmL2i4MUz3gKKwXw6C0ow_VScN8vlyGBK3SpLKoE_m9BDJ3iNE4xPj)

Eerst maken we een layout die een ImageView, een “Prev”‑ en een “Next”‑knop bevat:

![Layout met een ImageView en Prev‑ en Next‑knoppen](https://lh3.googleusercontent.com/rX9leIvYTVzQa0YAMj_jPUPs-c9_HwGPZUfR5A3FLiTk0-qzUQ29FfM4hammUVXbbw_Ly0LwEM_VnaI6vslEEMcVlEwVMem0LTiX5kYsA4lxtiHrvXfDPruWPOGU1YKDYSWcNM54)

**XML – content_main.xml – Layout maken**  
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

Hier verwijzen we naar de bibliotheek “Aspose.Slides.Droid.dll” die een voorbeeldpresentatie (“HelloWorld.pptx”) bevat en voegen we de initialisatie toe aan MainActivity:

**C# – MainActivity.cs – Initialisatie**  
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

Laten we de functie toevoegen om de vorige en volgende dia’s weer te geven bij het indrukken van de knoppen:

**C# – MainActivity.cs – Dia’s weergeven bij Prev‑ en Next‑knop**  
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

Tot slot implementeren we een functie om bij een aanraking op de dia een elliptische vorm toe te voegen:

**C# – MainActivity.cs – Ellips toevoegen bij klik op dia**  
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

Elke klik op de presentatiedia zorgt voor een willekeurig gekleurde ellips:

![Dia met ellipsen toegevoegd door aanraking](https://lh4.googleusercontent.com/RhjFHm6SgzOkXaehKhsY8q7SRZLFC7vV8_jyw-Gy4Scy68wTMg_apLZ3vPzRLOt1eEw_zUZmLlVhJ8oTGCg10dRNAETLSClRTBEyj2MWuefNpJI4i7WLIe0x8A7xuh4CV91loLKi)

## **Ondersteunde functies**

|**FUNCTIES**|**Aspose.Slides for .NET**|**Aspose.Slides for Xamarin**|
| :- | :- | :- |
|**Presentatiefuncties:**| | |
|Nieuwe presentaties maken|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 97 – 2003‑formaten openen/opslaan|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2007‑formaten openen/opslaan|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2010‑uitbreidingen ondersteunen|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2013‑uitbreidingen ondersteunen|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2016‑functies ondersteunen|beperkt|beperkt|
|PowerPoint 2019‑functies ondersteunen|beperkt|beperkt|
|PPT → PPTX‑conversie|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTX → PPT‑conversie|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTX in PPT|beperkt|beperkt|
|Thema‑verwerking|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Macro‑verwerking|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Document‑eigenschappen verwerken|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Wachtwoordbeveiliging|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Snelle tekstextractie|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Lettertypen insluiten|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Commentaarrendering|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Onderbreken van langdurige taken|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Exportformaten:**| | |
|PDF|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|XPS|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|HTML|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|TIFF|{{< emoticons/tick >}}|{{< emoticons/cross >}}|
|ODP|beperkt|beperkt|
|SWF|beperkt|beperkt|
|SVG|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Importformaten:**| | |
|HTML|beperkt|beperkt|
|ODP|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|THMX|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Masterdia‑functies:**| | |
|Alle bestaande masterdia’s benaderen|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Masterdia’s maken/verwijderen|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Masterdia’s klonen|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Layoutdia‑functies:**| | |
|Alle bestaande layoutdia’s benaderen|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Layoutdia’s maken/verwijderen|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Layoutdia’s klonen|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Dia‑functies:**| | |
|Alle bestaande dia’s benaderen|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Dia’s maken/verwijderen|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Dia’s klonen|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Dia’s exporteren naar afbeeldingen|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Dia‑secties maken/bewerken/verwijderen|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Notitiedia‑functies:**| | |
|Alle bestaande notitiedia’s benaderen|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Vorm‑functies:**| | |
|Alle dia‑vormen benaderen|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Nieuwe vormen toevoegen|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Vormen klonen|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Vormen afzonderlijk exporteren naar afbeeldingen|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Ondersteunde vormtypen:**| | |
|Alle vooraf gedefinieerde vormtypen|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Beeldkaders|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Tabellen|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Grafieken|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|SmartArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Oude diagrammen|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|WordArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|OLE, ActiveX‑objecten|beperkt|beperkt|
|Video‑kaders|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Audio‑kaders|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Connectoren|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Groep‑vorm‑functies:**| | |
|Groep‑vormen benaderen|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Groep‑vormen maken|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Groep‑vormen opsplitsen|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Vorm‑effect‑functies:**| | |
|2D‑effecten|beperkt|beperkt|
|3D‑effecten|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|**Tekst‑functies:**| | |
|Alinea‑opmaak|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Deel‑opmaak|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Animatie‑functies:**| | |
|Animatie exporteren naar SWF|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|Animatie exporteren naar HTML|{{< emoticons/cross >}}|{{< emoticons/cross >}}|