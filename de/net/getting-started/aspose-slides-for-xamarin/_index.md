---
title: Aspose.Slides für Xamarin (Historisch)
linktitle: Xamarin (Historisch)
type: docs
weight: 200
url: /de/net/aspose-slides-for-xamarin/
keywords:
- Xamarin
- Mobile Entwicklung
- Android
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Historisch: Wie Aspose.Slides für .NET-Versionen 20.2 bis 22.10 Xamarin.Android über eine separate Bibliothek unterstützte. Aktuelle Versionen enthalten sie nicht."
---
{{% alert color="info" title="Hinweis" %}}
Dies ist eine historische Seite. Versionen 20.2 bis 22.10 des Aspose.Slides.NET‑Pakets enthielten eine separate Xamarin.Android‑Bibliothek, *Aspose.Slides.Droid.dll*, die der Code auf dieser Seite verwendet. Spätere Versionen enthalten sie nicht: das aktuelle Paket enthält Builds nur für .NET Framework 4.6.2, .NET 6 und .NET Standard 2.0. Microsoft hat die Unterstützung für alle Xamarin‑SDKs am 1. Mai 2024 beendet; siehe die [Xamarin-Unterstützungsrichtlinie](https://dotnet.microsoft.com/en-us/platform/support/policy/xamarin).
{{% /alert %}}

## **Einleitung**

Xamarin ist ein Framework, das für die mobile Entwicklung in .NET C# verwendet wird. Xamarin verfügt über Werkzeuge und Bibliotheken, die die Möglichkeiten der .NET‑Plattform erweitern. Es ermöglicht Entwicklern, Anwendungen für das **Android**‑Betriebssystem zu erstellen.

{{% alert color="info" title="Hinweis" %}}
Für die Entwicklung mit Xamarin können Programmierer ihre üblichen Entwicklungsumgebungen (C#, Visual Studio und Bibliotheken von Drittanbietern) verwenden.
{{% /alert %}}

Die Aspose.Slides‑API funktionierte auf der Xamarin‑Plattform. Um dies zu ermöglichen, fügte das Aspose.Slides.NET‑Paket in den Versionen 20.2 bis 22.10 eine separate DLL für Xamarin hinzu. Aspose.Slides für Xamarin unterstützte die meisten der in der .NET‑Version verfügbaren Funktionen:

- Konvertieren und Anzeigen von Präsentationen.
- Bearbeiten von Inhalten in Präsentationen: Text, Formen, Diagramme, SmartArt, Audio/Video, Schriftarten usw.
- Verarbeiten von Animationen, 2D‑Effekten, WordArt usw.
- Verarbeiten von Metadaten und Dokumenteigenschaften.
- Klonen, Zusammenführen, Vergleichen, Aufteilen usw.

Wir haben einen Vergleich der vollständigen Funktionen in einem anderen Abschnitt nahe dem Ende dieser Seite bereitgestellt.

In der Aspose.Slides für Xamarin‑API waren Klassen, Namespaces, Logik und Verhalten so weit wie möglich an die .NET‑Version angelehnt. Sie konnten Ihre Aspose.Slides‑.NET‑Anwendungen mit minimalem Aufwand zu Xamarin migrieren.

## **Schnelles Beispiel**

Sie können Aspose.Slides für Xamarin verwenden, um Ihre C#‑Anwendung über Slides für Android zu erstellen und zu nutzen.

Wir stellen ein Beispiel einer Android‑via‑Xamarin‑Anwendung bereit, die Aspose.Slides verwendet, um Präsentationsfolien anzuzeigen und bei Berührung der Folie eine neue Form hinzuzufügen. Den vollständigen Quellcode der Beispiele finden Sie auf [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Xamarin).

Beginnen wir mit der Erstellung einer Xamarin‑Android‑App:

![Erstellen einer Xamarin‑Android‑App](https://lh3.googleusercontent.com/sNkKZnuuGo8phWI-4g4jRA_ZESKpO9RXehPj46RVymXGPcCJuYooePXcBEcb7N6uUUxgocl4o9OjwnajzWKmL2i4MUz3gKKwXw6C0ow_VScN8vlyGBK3SpLKoE_m9BDJ3iNE4xPj)

Zuerst erstellen wir ein Inhaltslayout, das eine Image‑View sowie Vor‑ und Zurück‑Buttons enthält:

![Inhaltslayout mit einer Image‑View und Vor‑ und Zurück‑Buttons](https://lh3.googleusercontent.com/rX9leIvYTVzQa0YAMj_jPUPs-c9_HwGPZUfR5A3FLiTk0-qzUQ29FfM4hammUVXbbw_Ly0LwEM_VnaI6vslEEMcVlEwVMem0LTiX5kYsA4lxtiHrvXfDPruWPOGU1YKDYSWcNM54)

**XML – content_main.xml – Inhaltslayout erstellen**
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

Hier verweisen wir auf die Bibliothek "Aspose.Slides.Droid.dll", die eine Beispielpräsentation ("HelloWorld.pptx") in die Assets der Xamarin‑Anwendung einbindet und deren Initialisierung in MainActivity hinzufügt:

**C# – MainActivity.cs – Initialisierung**
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

Fügen wir die Funktion hinzu, um beim Drücken der Vor‑ und Zurück‑Buttons die jeweiligen Folien anzuzeigen:
**C# – MainActivity.cs – Folien bei Vor‑ und Zurück‑Button‑Klick anzeigen**
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

Abschließend implementieren wir eine Funktion, um bei Berührung einer Folie eine Ellipsenform hinzuzufügen:
**C# – MainActivity.cs – Ellipse per Folienklick hinzufügen**
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

Jeder Klick auf die Präsentationsfolie fügt eine zufällig farbige Ellipse hinzu:
![Folie mit durch Berührung hinzugefügten Ellipsen](https://lh4.googleusercontent.com/RhjFHm6SgzOkXaehKhsY8q7SRZLFC7vV8_jyw-Gy4Scy68wTMg_apLZ3vPzRLOt1eEw_zUZmLlVhJ8oTGCg10dRNAETLSClRTBEyj2MWuefNpJI4i7WLIe0x8A7xuh4CV91loLKi)

## **Unterstützte Funktionen**

|**FUNKTIONEN**|**Aspose.Slides für .NET**|**Aspose.Slides für Xamarin**|
| :- | :- | :- |
|**Präsentationsfunktionen**:| | |
|Neue Präsentationen erstellen|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint‑97‑2003‑Formate öffnen/speichern|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint‑2007‑Formate öffnen/speichern|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Unterstützung von PowerPoint‑2010‑Erweiterungen|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Unterstützung von PowerPoint‑2013‑Erweiterungen|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Unterstützung von PowerPoint‑2016‑Funktionen|eingeschränkt|eingeschränkt|
|Unterstützung von PowerPoint‑2019‑Funktionen|eingeschränkt|eingeschränkt|
|PPT → PPTX‑Konvertierung|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTX → PPT‑Konvertierung|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTX in PPT|eingeschränkt|eingeschränkt|
|Verarbeitung von Designs|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Verarbeitung von Makros|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Verarbeitung von Dokumenteigenschaften|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Passwortschutz|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Schnelle Texteextraktion|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Einbetten von Schriftarten|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Anzeige von Kommentaren|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Unterbrechen von langlaufenden Aufgaben|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Exportformate:**| | |
|PDF|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|XPS|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|HTML|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|TIFF|{{< emoticons/tick >}}|{{< emoticons/cross >}}|
|ODP|eingeschränkt|eingeschränkt|
|SWF|eingeschränkt|eingeschränkt|
|SVG|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Importformate:**| | |
|HTML|eingeschränkt|eingeschränkt|
|ODP|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|THMX|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Master‑Folien‑Funktionen:**| | |
|Zugriff auf alle vorhandenen Masterfolien|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Erstellen/Entfernen von Masterfolien|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Klonen von Masterfolien|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Layout‑Folien‑Funktionen:**| | |
|Zugriff auf alle vorhandenen Layout‑Folien|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Erstellen/Entfernen von Layout‑Folien|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Klonen von Layout‑Folien|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Folien‑Funktionen:**| | |
|Zugriff auf alle vorhandenen Folien|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Erstellen/Entfernen von Folien|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Klonen von Folien|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Exportieren von Folien zu Bildern|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Erstellen/Bearbeiten/Entfernen von Folienabschnitten|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Notizfolien‑Funktionen:**| | |
|Zugriff auf alle vorhandenen Notizfolien|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Form‑Funktionen:**| | |
|Zugriff auf alle Folien‑Formen|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Hinzufügen neuer Formen|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Klonen von Formen|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Exportieren einzelner Formen zu Bildern|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Unterstützte Form‑Typen:**| | |
|Alle vordefinierten Form‑Typen|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Bildrahmen|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Tabellen|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Diagramme|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|SmartArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Legacy‑Diagramm|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|WordArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|OLE-, ActiveX‑Objekte|eingeschränkt|eingeschränkt|
|Video‑Frames|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Audio‑Frames|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Verbinder|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Gruppen‑Form‑Funktionen:**| | |
|Zugriff auf Gruppenkörper|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Erstellen von Gruppenkörpern|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Auflösen vorhandener Gruppenkörper|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Form‑Effekt‑Funktionen:**| | |
|2D‑Effekte|eingeschränkt|eingeschränkt|
|3D‑Effekte|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|**Text‑Funktionen:**| | |
|Absatzformatierung|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Abschnittsformatierung|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Animations‑Funktionen:**| | |
|Animation nach SWF exportieren|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|Animation nach HTML exportieren|{{< emoticons/cross >}}|{{< emoticons/cross >}}|