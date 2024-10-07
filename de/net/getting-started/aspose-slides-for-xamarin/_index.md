---
title: Aspose.Slides für Xamarin
type: docs
weight: 150
url: /net/aspose-slides-for-xamarin/
---

## **Überblick**
Xamarin ist ein Framework, das für die mobile Entwicklung in .NET C# verwendet wird. Xamarin hat Werkzeuge und Bibliotheken, die die Möglichkeiten der .NET-Plattform erweitern. Es ermöglicht Entwicklern, Anwendungen für das Betriebssystem **Android** zu erstellen.

{{% alert color="primary" %}}

Für die Entwicklung in Xamarin können Programmierer ihre gewohnten Entwicklungsumgebungen (C#, Visual Studio und 3rd-Party-Bibliotheken) verwenden.

{{% /alert %}}

Die Aspose.Slides-API funktioniert auf der Xamarin-Plattform. Um dies zu erreichen, fügt das Aspose.Slides .NET-Paket eine separate DLL für Xamarin hinzu. Aspose.Slides für Xamarin unterstützt die meisten Funktionen, die in der .NET-Version verfügbar sind:

- Konvertieren und Anzeigen von Präsentationen.
- Bearbeiten von Inhalten in Präsentationen: Text, Formen, Charts, SmartArt, Audio/Video, Schriftarten usw.
- Umgang mit Animationen, 2D-Effekten, WordArt usw.
- Umgang mit Metadaten und Dokumenteigenschaften.
- Drucken, Klonen, Zusammenführen, Vergleichen, Teilen usw.

Wir haben einen Vergleich der vollständigen Funktionen in einem anderen Abschnitt nahe der Unterseite dieser Seite bereitgestellt.

In der Aspose.Slides für Xamarin API sind die Klassen, Namespaces, Logik und das Verhalten so ähnlich wie möglich zur .NET-Version. Sie können Ihre Aspose.Slides .NET-Anwendungen mit minimalen Kosten auf Xamarin migrieren.

## **Schnelles Beispiel**
Sie können Aspose.Slides für Xamarin verwenden, um Ihre C#-Anwendung über Slides für Android zu erstellen und zu nutzen.

Wir bieten ein Beispiel einer Android-Anwendung über Xamarin, die Aspose.Slides verwendet, um Präsentationsfolien anzuzeigen und eine neue Form bei Berührung auf der Folie hinzuzufügen. Den vollständigen Quellcode der Beispiele finden Sie auf [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Xamarin).

Lassen Sie uns mit der Erstellung einer Xamarin Android-App beginnen:

![todo:image_alt_text](https://lh3.googleusercontent.com/sNkKZnuuGo8phWI-4g4jRA_ZESKpO9RXehPj46RVymXGPcCJuYooePXcBEcb7N6uUUxgocl4o9OjwnajzWKmL2i4MUz3gKKwXw6C0ow_VScN8vlyGBK3SpLKoE_m9BDJ3iNE4xPj)

Zuerst erstellen wir ein Inhaltslayout, das eine Bildansicht, die Schaltflächen Prev und Next enthalten wird:

![todo:image_alt_text](https://lh3.googleusercontent.com/rX9leIvYTVzQa0YAMj_jPUPs-c9_HwGPZUfR5A3FLiTk0-qzUQ29FfM4hammUVXbbw_Ly0LwEM_VnaI6vslEEMcVlEwVMem0LTiX5kYsA4lxtiHrvXfDPruWPOGU1YKDYSWcNM54)

**XML - content_main.xml - Inhaltslayout erstellen**
```
<LinearLayout
    xmlns:android="http://schemas.android.com/apk/res/android"
    xmlns:app="http://schemas.android.com/apk/res-auto"
    xmlns:tools="http://schemas.android.com/tools"
    android:orientation="vertical"
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

Hier verweisen wir auf die "Aspose.Slides.Droid.dll"-Bibliothek, die eine Beispielpräsentation ("HelloWorld.pptx") in die Xamarin-Anwendung Assets einfügt und deren Initialisierung in MainActivity hinzufügt:

**C# - MainActivity.cs - Initialisierung**

```csharp
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

Lassen Sie uns die Funktion hinzufügen, um die vorherigen und nächsten Folien zu wechseln, wenn die Schaltflächen getippt werden:

**C# - MainActivity.cs - Folien beim Klicken auf die Schaltflächen Prev und Next anzeigen**

```csharp
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

Lassen Sie uns schließlich eine Funktion implementieren, um eine Ellipsenform bei Berührung der Folie hinzuzufügen:

**C# - MainActivity.cs - Ellipse bei Klick auf die Folie hinzufügen**

```csharp
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

Jeder Klick auf die Präsentationsfolie führt dazu, dass eine Ellipse in zufälliger Farbe hinzugefügt wird:

![todo:image_alt_text](https://lh4.googleusercontent.com/RhjFHm6SgzOkXaehKhsY8q7SRZLFC7vV8_jyw-Gy4Scy68wTMg_apLZ3vPzRLOt1eEw_zUZmLlVhJ8oTGCg10dRNAETLSClRTBEyj2MWuefNpJI4i7WLIe0x8A7xuh4CV91loLKi)

## **Unterstützte Funktionen**

|**FUNKTIONEN** |**Aspose.Slides für .NET**  |**Aspose.Slides für Xamarin**|
| :- | :- | :- |
|**Präsentationsfunktionen**: | | |
|Neue Präsentationen erstellen |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 97 - 2003 Formate öffnen/speichern |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2007 Formate öffnen/speichern |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2010 Erweiterungen unterstützen |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2013 Erweiterungen unterstützen |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2016 Funktionen unterstützen |eingeschränkt|eingeschränkt|
|PowerPoint 2019 Funktionen unterstützen |eingeschränkt |eingeschränkt|
|PPT 2 PPTX Konvertierung |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTX 2 PPT Konvertierung |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTX in PPT |eingeschränkt|eingeschränkt|
|Themenverarbeitung |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Makroverarbeitung |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Dokumenteigenschaftenverarbeitung |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Passwortschutz |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Schnelle Textextraktion |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Schriftarten einbetten |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Kommentare rendern |{{< emoticons/tick >}} |{{< emoticons/tick >}}|
|Unterbrechung von langlaufenden Aufgaben | {{< emoticons/tick >}}|{{< emoticons/tick >}} |
|**Exportformate:** | | |
|PDF |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|XPS |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|HTML |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|TIFF |{{< emoticons/tick >}}|{{< emoticons/cross >}}|
|ODP |eingeschränkt |eingeschränkt|
|SWF |eingeschränkt|eingeschränkt|
|SVG |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Importformate:** | | |
|HTML |eingeschränkt|eingeschränkt|
|ODP |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|THMX |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Master-Folien Funktionen:** | | |
|Zugriff auf alle vorhandenen Masterfolien |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Erstellen/Entfernen von Masterfolien |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Klonen von Masterfolien |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Layout-Folien Funktionen:** | | |
|Zugriff auf alle vorhandenen Layoutfolien |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Erstellen/Entfernen von Layoutfolien |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Klonen von Layoutfolien |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Folien Funktionen:** | | |
|Zugriff auf alle vorhandenen Folien |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Erstellen/Entfernen von Folien |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Klonen von Folien |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Exportieren von Folien in Bilder |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Erstellen/Bearbeiten/Entfernen von Folienschnitten |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Notizen-Folien Funktionen:** | | |
|Zugriff auf alle vorhandenen Notizenfolien |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Formen Funktionen:** | | |
|Zugriff auf alle Folienformen |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Hinzufügen neuer Formen |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Klonen von Formen |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Exportieren separater Formen in Bilder |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Unterstützte Formtypen:** | | |
|Alle vordefinierten Formtypen |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Bilderrahmen |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Tabellen |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Diagramme |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|SmartArt |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Legacy-Diagramm |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|WordArt |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|OLE, ActiveX-Objekte |eingeschränkt|eingeschränkt|
|Video-Rahmen |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Audio-Rahmen |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Verbindungen |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Gruppenformen Funktionen:** | | |
|Zugriff auf Gruppenformen |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Erstellen von Gruppenformen |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Gruppenformen auflösen |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Formeffekte Funktionen:** | | |
|2D-Effekte |eingeschränkt|eingeschränkt|
|3D-Effekte |{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|**Textfunktionen:** | | |
|Absatzformatierung |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Textformatierung |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Animationsfunktionen:** | | |
|Animationen in SWF exportieren |{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|Animationen in HTML exportieren |{{< emoticons/cross >}}|{{< emoticons/cross >}}|