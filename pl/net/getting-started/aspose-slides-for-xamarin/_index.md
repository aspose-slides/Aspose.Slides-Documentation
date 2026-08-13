---
title: Aspose.Slides dla Xamarin
type: docs
weight: 150
url: /pl/net/aspose-slides-for-xamarin/
keywords:
- Xamarin
- programowanie mobilne
- Android
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Twórz aplikacje mobilne Xamarin w C#, aby wyświetlać, edytować i konwertować prezentacje przy użyciu Aspose.Slides, wspierające bogate funkcje dla PPT, PPTX i ODP na Androidzie."
---
## **Wprowadzenie**

Xamarin to framework używany do tworzenia aplikacji mobilnych w .NET C#. Xamarin posiada narzędzia i biblioteki, które rozszerzają możliwości platformy .NET. Umożliwia programistom tworzenie aplikacji dla systemu operacyjnego **Android**.

{{% alert color="info" %}} 

Do tworzenia w Xamarin programiści mogą korzystać ze swoich standardowych środowisk programistycznych (C#, Visual Studio oraz bibliotek firm trzecich).

{{% /alert %}}

API Aspose.Slides działa na platformie Xamarin. Aby to osiągnąć, pakiet Aspose.Slides .NET dodaje osobny plik DLL dla Xamarin. Aspose.Slides dla Xamarin obsługuje większość funkcji dostępnych w wersji .NET:

- konwertowanie i przeglądanie prezentacji.
- edycja zawartości w prezentacjach: tekst, kształty, wykresy, SmartArt, audio/wideo, czcionki itp.
- obsługa animacji, efektów 2D, WordArt itp.
- obsługa metadanych i właściwości dokumentu.
- drukowanie, klonowanie, scalanie, porównywanie, dzielenie itp.

Porównanie pełnej listy funkcji znajduje się w innej sekcji, blisko końca tej strony.

W API Aspose.Slides dla Xamarin klasy, przestrzenie nazw, logika i zachowanie są tak podobne, jak to możliwe do wersji .NET. Możesz migrować swoje aplikacje Aspose.Slides .NET do Xamarin przy minimalnych kosztach.


## **Szybki przykład**
Możesz używać Aspose.Slides dla Xamarin do budowania i wykorzystywania swojej aplikacji C# za pośrednictwem Slides for Android.

Udostępniamy przykład aplikacji Android przy użyciu Xamarin, która wykorzystuje Aspose.Slides do wyświetlania slajdów prezentacji i dodaje nowy kształt na slajdzie po dotknięciu. Pełne źródła przykładów znajdziesz na [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Xamarin).

Zacznijmy od utworzenia aplikacji Xamarin Android:

![todo:image_alt_text](https://lh3.googleusercontent.com/sNkKZnuuGo8phWI-4g4jRA_ZESKpO9RXehPj46RVymXGPcCJuYooePXcBEcb7N6uUUxgocl4o9OjwnajzWKmL2i4MUz3gKKwXw6C0ow_VScN8vlyGBK3SpLKoE_m9BDJ3iNE4xPj)

Najpierw tworzymy układ zawartości, który będzie zawierał widok obrazu oraz przyciski Prev i Next:

![todo:image_alt_text](https://lh3.googleusercontent.com/rX9leIvYTVzQa0YAMj_jPUPs-c9_HwGPZUfR5A3FLiTk0-qzUQ29FfM4hammUVXbbw_Ly0LwEM_VnaI6vslEEMcVlEwVMem0LTiX5kYsA4lxtiHrvXfDPruWPOGU1YKDYSWcNM54)

**XML - content_main.xml - Utwórz układ zawartości**
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

Tutaj odwołujemy się do biblioteki "Aspose.Slides.Droid.dll", która zawiera przykładową prezentację ("HelloWorld.pptx") w zasobach aplikacji Xamarin i dodaje jej inicjalizację do MainActivity:

**C# - MainActivity.cs - Inicjalizacja**

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

Dodajmy funkcję wyświetlania slajdów Prev i Next po naciśnięciu przycisków:

**C# - MainActivity.cs - Wyświetl slajdy po kliknięciu przycisku Prev i Next**

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

Na koniec zaimplementujmy funkcję dodającą kształt elipsy po dotknięciu slajdu:

**C# - MainActivity.cs - Dodaj elipsę po kliknięciu slajdu**

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

Każde kliknięcie slajdu prezentacji powoduje dodanie elipsy o losowym kolorze:

![todo:image_alt_text](https://lh4.googleusercontent.com/RhjFHm6SgzOkXaehKhsY8q7SRZLFC7vV8_jyw-Gy4Scy68wTMg_apLZ3vPzRLOt1eEw_zUZmLlVhJ8oTGCg10dRNAETLSClRTBEyj2MWuefNpJI4i7WLIe0x8A7xuh4CV91loLKi)


## **Obsługiwane funkcje**

|**FUNKCJE**|**Aspose.Slides for .NET**|**Aspose.Slides for Xamarin**|
| :- | :- | :- |
|**Funkcje prezentacji**:| | |
|Tworzenie nowych prezentacji|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Obsługa formatów PowerPoint 97 - 2003 (otwieranie/zapisywanie)|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Obsługa formatów PowerPoint 2007 (otwieranie/zapisywanie)|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Obsługa rozszerzeń PowerPoint 2010|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Obsługa rozszerzeń PowerPoint 2013|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Obsługa funkcji PowerPoint 2016|ograniczone|ograniczone|
|Obsługa funkcji PowerPoint 2019|ograniczone|ograniczone|
|Konwersja PPT do PPTX|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Konwersja PPTX do PPT|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTX w PPT|ograniczone|ograniczone|
|Przetwarzanie szablonów|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Przetwarzanie makr|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Przetwarzanie właściwości dokumentu|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Ochrona hasłem|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Szybkie wyodrębnianie tekstu|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Osadzanie czcionek|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Renderowanie komentarzy|{{< emoticons/tick >}} |{{< emoticons/tick >}}|
|Przerywanie długotrwałych zadań|{{< emoticons/tick >}}|{{< emoticons/tick >}} |
|**Formaty eksportu:**| | |
|PDF|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|XPS|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|HTML|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|TIFF|{{< emoticons/tick >}}|{{< emoticons/cross >}}|
|ODP|ograniczone|ograniczone|
|SWF|ograniczone|ograniczone|
|SVG|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Formaty importu:**| | |
|HTML|ograniczone|ograniczone|
|ODP|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|THMX|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Funkcje slajdów master:**| | |
|Dostęp do wszystkich istniejących slajdów master|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Tworzenie/usuwanie slajdów master|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Klonowanie slajdów master|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Funkcje slajdów układu:**| | |
|Dostęp do wszystkich istniejących slajdów układu|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Tworzenie/usuwanie slajdów układu|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Klonowanie slajdów układu|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Funkcje slajdu:**| | |
|Dostęp do wszystkich istniejących slajdów|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Tworzenie/usuwanie slajdów|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Klonowanie slajdów|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Eksportowanie slajdów do obrazów|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Tworzenie/edycja/usuwanie sekcji slajdu|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Funkcje notatek slajdów:**| | |
|Dostęp do wszystkich istniejących notatek slajdów|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Funkcje kształtów:**| | |
|Dostęp do wszystkich kształtów slajdu|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Dodawanie nowych kształtów|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Klonowanie kształtów|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Eksportowanie poszczególnych kształtów do obrazów|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Obsługiwane typy kształtów:**| | |
|Wszystkie wbudowane typy kształtów|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Ramki obrazów|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Tabele|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Wykresy|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|SmartArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Diagram starszy|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|WordArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Obiekty OLE, ActiveX|ograniczone|ograniczone|
|Ramki wideo|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Ramki audio|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Łączniki|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Funkcje grupowania kształtów:**| | |
|Dostęp do grup kształtów|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Tworzenie grup kształtów|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Rozgrupowywanie istniejących grup kształtów|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Funkcje efektów kształtów:**| | |
|Efekty 2D|ograniczone|ograniczone|
|Efekty 3D|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|**Funkcje tekstu:**| | |
|Formatowanie akapitów|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Formatowanie fragmentów|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Funkcje animacji:**| | |
|Eksport animacji do SWF|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|Eksport animacji do HTML|{{< emoticons/cross >}}|{{< emoticons/cross >}}|