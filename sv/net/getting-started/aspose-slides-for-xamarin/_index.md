---
title: Aspose.Slides för Xamarin
type: docs
weight: 150
url: /sv/net/aspose-slides-for-xamarin/
keywords:
- Xamarin
- mobilutveckling
- Android
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Skapa Xamarin-mobila appar i C# för att visa, redigera och konvertera presentationer med Aspose.Slides, med stöd för rika funktioner för PPT, PPTX och ODP på Android."
---
## **Introduktion**

Xamarin är ett ramverk som används för mobilutveckling i .NET C#. Xamarin har verktyg och bibliotek som utökar .NET-plattformens möjligheter. Det gör det möjligt för utvecklare att bygga applikationer för **Android**‑operativsystemet. 

{{% alert color="info" %}} 

För utveckling i Xamarin kan programmerare använda sina vanliga utvecklingsmiljöer (C#, Visual Studio och tredjepartsbibliotek).

{{% /alert %}}

Aspose.Slides API fungerar på Xamarin‑plattformen. För att uppnå detta lägger Aspose.Slides .NET‑paketet till en separat DLL för Xamarin. Aspose.Slides för Xamarin stöder de flesta funktionerna som finns i .NET‑versionen:

- konvertering och visning av presentationer.
- redigering av innehåll i presentationer: text, former, diagram, SmartArt, ljud/video, teckensnitt etc.
- hantering av animation, 2D‑effekter, WordArt etc.
- hantering av metadata och dokumentegenskaper.
- utskrift, kloning, sammanslagning, jämförelse, delning etc.

Vi har tillhandahållit en jämförelse av de fullständiga funktionerna i ett annat avsnitt nära botten av denna sida.

I Aspose.Slides för Xamarin API är klasser, namnrum, logik och beteende så lika som möjligt den .NET‑versionen. Du kan migrera dina Aspose.Slides .NET‑applikationer till Xamarin med minimala kostnader.


## **Snabbt exempel**
Du kan använda Aspose.Slides för Xamarin för att bygga och använda din C#‑applikation via Slides för Android.

Vi tillhandahåller ett exempel på en Android‑via‑Xamarin‑applikation som använder Aspose.Slides för att visa presentationsbilder och lägger till en ny form på bilden vid beröring. Du kan hitta hela källkoden för exemplen på [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Xamarin).

Låt oss börja med att skapa en Xamarin Android‑app:

![todo:image_alt_text](https://lh3.googleusercontent.com/sNkKZnuuGo8phWI-4g4jRA_ZESKpO9RXehPj46RVymXGPcCJuYooePXcBEcb7N6uUUxgocl4o9OjwnajzWKmL2i4MUz3gKKwXw6C0ow_VScN8vlyGBK3SpLKoE_m9BDJ3iNE4xPj)

Först skapar vi en innehållslayout som kommer att innehålla en bildvy, Prev‑ och Next‑knappar:

![todo:image_alt_text](https://lh3.googleusercontent.com/rX9leIvYTVzQa0YAMj_jPUPs-c9_HwGPZUfR5A3FLiTk0-qzUQ29FfM4hammUVXbbw_Ly0LwEM_VnaI6vslEEMcVlEwVMem0LTiX5kYsA4lxtiHrvXfDPruWPOGU1YKDYSWcNM54)



**XML - content_main.xml - Skapa innehållslayout**
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



Här refererar vi till biblioteket "Aspose.Slides.Droid.dll" som innehåller en exempelpresentation ("HelloWorld.pptx") i Xamarin‑applikationens Assets och lägger till dess initiering i MainActivity:

**C# - MainActivity.cs - Initiering**

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

Låt oss lägga till funktionen för att visa Prev‑ och Next‑bilderna när knapparna trycks:

**C# - MainActivity.cs - Visa bilder vid Prev‑ och Next‑knappklick**

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



Slutligen, låt oss implementera en funktion för att lägga till en ellipsform vid beröring av bilden:

**C# - MainActivity.cs - Lägg till ellips vid bildklick**

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

Varje klick på presentationsbilden lägger till en ellips med slumpmässig färg:

![todo:image_alt_text](https://lh4.googleusercontent.com/RhjFHm6SgzOkXaehKhsY8q7SRZLFC7vV8_jyw-Gy4Scy68wTMg_apLZ3vPzRLOt1eEw_zUZmLlVhJ8oTGCg10dRNAETLSClRTBEyj2MWuefNpJI4i7WLIe0x8A7xuh4CV91loLKi)


## **Stödda funktioner**

|**FUNKTIONER**|**Aspose.Slides for .NET**|**Aspose.Slides for Xamarin**|
| :- | :- | :- |
|**Presentationsegenskaper:**| | |
|Skapa nya presentationer|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 97‑2003-format öppna/spara|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2007-format öppna/spara|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Stöd för PowerPoint 2010‑tillägg|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Stöd för PowerPoint 2013‑tillägg|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Stöd för PowerPoint 2016‑funktioner|restricted|restricted|
|Stöd för PowerPoint 2019‑funktioner|restricted|restricted|
|PPT‑till‑PPTX‑konvertering|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTX‑till‑PPT‑konvertering|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTX i PPT|restricted|restricted|
|Bearbetning av teman|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Bearbetning av makron|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Bearbetning av dokumentegenskaper|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Lösenordsskydd|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Snabb textutdragning|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Inbäddning av teckensnitt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Rendering av kommentarer|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Avbrytande av långvariga uppgifter|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Exportformat:**| | |
|PDF|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|XPS|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|HTML|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|TIFF|{{< emoticons/tick >}}|{{< emoticons/cross >}}|
|ODP|restricted|restricted|
|SWF|restricted|restricted|
|SVG|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Importformat:**| | |
|HTML|restricted|restricted|
|ODP|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|THMX|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Master‑bildfunktioner:**| | |
|Åtkomst till alla befintliga master‑bilder|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Skapa/ta bort master‑bilder|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Klona master‑bilder|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Layout‑bildfunktioner:**| | |
|Åtkomst till alla befintliga layout‑bilder|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Skapa/ta bort layout‑bilder|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Klona layout‑bilder|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Bildfunktioner:**| | |
|Åtkomst till alla befintliga bilder|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Skapa/ta bort bilder|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Klona bilder|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Exportera bilder till bildformat|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Skapa/redigera/ta bort bildsektioner|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Notebildfunktioner:**| | |
|Åtkomst till alla befintliga notebilder|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Form‑funktioner:**| | |
|Åtkomst till alla bildformer|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Lägga till nya former|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Klona former|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Exportera enskilda former till bilder|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Stödda formtyper:**| | |
|Alla fördefinierade formtyper|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Bildramar|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Tabeller|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Diagram|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|SmartArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Äldre diagram|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|WordArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|OLE, ActiveX‑objekt|restricted|restricted|
|Videoramar|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Ljudramar|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Kopplingar|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Gruppforms‑funktioner:**| | |
|Åtkomst till gruppformer|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Skapa gruppformer|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Dela upp befintliga gruppformer|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Form‑effektfunktioner:**| | |
|2D‑effekter|restricted|restricted|
|3D‑effekter|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|**Textfunktioner:**| | |
|Formatering av stycken|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Formatering av portioner|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Animationsfunktioner:**| | |
|Exportera animation till SWF|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|Exportera animation till HTML|{{< emoticons/cross >}}|{{< emoticons/cross >}}|