---
title: Aspose.Slides per Xamarin (Storico)
linktitle: Xamarin (Storico)
type: docs
weight: 200
url: /it/net/aspose-slides-for-xamarin/
keywords:
- Xamarin
- sviluppo mobile
- Android
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Storico: come le versioni Aspose.Slides per .NET 20.2 a 22.10 supportavano Xamarin.Android tramite una libreria separata. Le versioni attuali non la includono."
---
{{% alert color="info" title="Note" %}}
Questa è una pagina storica. Le versioni 20.2‑22.10 del pacchetto Aspose.Slides.NET includevano una libreria Xamarin.Android separata, *Aspose.Slides.Droid.dll*, che il codice in questa pagina utilizza. Le versioni successive non la includono: il pacchetto corrente contiene build per .NET Framework 4.6.2, .NET 6 e .NET Standard 2.0 solo. Microsoft ha terminato il supporto per tutti gli SDK Xamarin il 1 maggio 2024; vedi la [politica di supporto Xamarin](https://dotnet.microsoft.com/en-us/platform/support/policy/xamarin).
{{% /alert %}}

## **Introduzione**

Xamarin è un framework utilizzato per lo sviluppo mobile in .NET C#. Xamarin dispone di strumenti e librerie che estendono le capacità della piattaforma .NET. Consente agli sviluppatori di creare applicazioni per il sistema operativo **Android**.

{{% alert color="info" title="Note" %}}
Per lo sviluppo in Xamarin, i programmatori possono utilizzare i loro ambienti di sviluppo abituali (C#, Visual Studio e librerie di terze parti).
{{% /alert %}}

L'API Aspose.Slides funzionava sulla piattaforma Xamarin. Per raggiungere questo obiettivo, il pacchetto Aspose.Slides.NET, nelle versioni 20.2‑22.10, ha aggiunto una DLL separata per Xamarin. Aspose.Slides per Xamarin supportava la maggior parte delle funzionalità disponibili nella versione .NET:

- conversione e visualizzazione di presentazioni.  
- modifica dei contenuti nelle presentazioni: testo, forme, grafici, SmartArt, audio/video, caratteri, ecc.  
- gestione di animazioni, effetti 2D, WordArt, ecc.  
- gestione dei metadati e delle proprietà del documento.  
- clonazione, unione, confronto, suddivisione, ecc.

Abbiamo fornito un confronto delle funzionalità complete in un'altra sezione vicino al fondo di questa pagina.

Nell'API Aspose.Slides per Xamarin, le classi, i namespace, la logica e il comportamento erano il più simili possibile alla versione .NET. È possibile migrare le proprie applicazioni Aspose.Slides .NET su Xamarin con costi minimi.

## **Esempio rapido**

È possibile utilizzare Aspose.Slides per Xamarin per creare e sfruttare la propria applicazione C# tramite Slides per Android.

Stiamo fornendo un esempio di applicazione Android via Xamarin che utilizza Aspose.Slides per visualizzare le diapositive di una presentazione e aggiunge una nuova forma sulla diapositiva al tocco. È possibile trovare il codice completo degli esempi su [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Xamarin).

Iniziamo creando un'app Xamarin Android:

![Creazione di un'app Android Xamarin](https://lh3.googleusercontent.com/sNkKZnuuGo8phWI-4g4jRA_ZESKpO9RXehPj46RVymXGPcCJuYooePXcBEcb7N6uUUxgocl4o9OjwnajzWKmL2i4MUz3gKKwXw6C0ow_VScN8vlyGBK3SpLKoE_m9BDJ3iNE4xPj)

Per prima cosa creiamo un layout di contenuto che conterrà una ImageView, i pulsanti Prev e Next:

![Layout di contenuto con una vista immagine e pulsanti Precedente e Successivo](https://lh3.googleusercontent.com/rX9leIvYTVzQa0YAMj_jPUPs-c9_HwGPZUfR5A3FLiTk0-qzUQ29FfM4hammUVXbbw_Ly0LwEM_VnaI6vslEEMcVlEwVMem0LTiX5kYsA4lxtiHrvXfDPruWPOGU1YKDYSWcNM54)

**XML - content_main.xml - Crea layout di contenuto**
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

Qui facciamo riferimento alla libreria "Aspose.Slides.Droid.dll" che include una presentazione di esempio ("HelloWorld.pptx") negli Assets dell'applicazione Xamarin e ne aggiungiamo l'inizializzazione in MainActivity:

**C# - MainActivity.cs - Inizializzazione**
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

Aggiungiamo la funzione per visualizzare le diapositive Precedente e Successivo al tocco dei pulsanti:

**C# - MainActivity.cs - Visualizza diapositive al click dei pulsanti Precedente e Successivo**
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

Infine, implementiamo una funzione per aggiungere una forma ellittica al tocco della diapositiva:

**C# - MainActivity.cs - Aggiungi ellisse al click della diapositiva**
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

Ogni click sulla diapositiva della presentazione aggiunge un'ellisse colorata casuale:

![Diapositiva con ellissi aggiunte al tocco](https://lh4.googleusercontent.com/RhjFHm6SgzOkXaehKhsY8q7SRZLFC7vV8_jyw-Gy4Scy68wTMg_apLZ3vPzRLOt1eEw_zUZmLlVhJ8oTGCg10dRNAETLSClRTBEyj2MWuefNpJI4i7WLIe0x8A7xuh4CV91loLKi)

## **Funzionalità supportate**

|**CARATTERISTICHHE**|**Aspose.Slides per .NET**|**Aspose.Slides per Xamarin**|
| :- | :- | :- |
|**Caratteristiche della presentazione**:| | |
|Crea nuove presentazioni|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Apertura/salvataggio formati PowerPoint 97‑2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Apertura/salvataggio formati PowerPoint 2007|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Supporto estensioni PowerPoint 2010|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Supporto estensioni PowerPoint 2013|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Supporto funzionalità PowerPoint 2016|limitato|limitato|
|Supporto funzionalità PowerPoint 2019|limitato|limitato|
|Conversione PPT in PPTX|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Conversione PPTX in PPT|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTX in PPT|limitato|limitato|
|Elaborazione temi|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Elaborazione macro|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Elaborazione proprietà documento|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Protezione con password|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Estrazione rapida del testo|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Incorporamento font|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Rendering dei commenti|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Interruzione di operazioni lunghe|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Formati di esportazione:**| | |
|PDF|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|XPS|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|HTML|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|TIFF|{{< emoticons/tick >}}|{{< emoticons/cross >}}|
|ODP|limitato|limitato|
|SWF|limitato|limitato|
|SVG|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Formati di importazione:**| | |
|HTML|limitato|limitato|
|ODP|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|THMX|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Funzionalità diapositive master:**| | |
|Accesso a tutte le diapositive master esistenti|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Creazione/rimozione di diapositive master|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Clonazione di diapositive master|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Funzionalità diapositive layout:**| | |
|Accesso a tutte le diapositive layout esistenti|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Creazione/rimozione di diapositive layout|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Clonazione di diapositive layout|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Funzionalità diapositive:**| | |
|Accesso a tutte le diapositive esistenti|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Creazione/rimozione di diapositive|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Clonazione di diapositive|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Esportazione diapositive in immagini|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Creazione/modifica/rimozione di sezioni diapositive|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Funzionalità diapositive note**:| | |
|Accesso a tutte le diapositive note esistenti|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Funzionalità forma:**| | |
|Accesso a tutte le forme della diapositiva|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Aggiunta di nuove forme|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Clonazione di forme|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Esportazione di forme separate in immagini|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Tipi di forma supportati:**| | |
|Tutti i tipi di forma predefiniti|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Cornici immagine|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Tabelle|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Grafici|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|SmartArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Diagramma legacy|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|WordArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Oggetti OLE, ActiveX|limitato|limitato|
|Cornici video|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Cornici audio|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Connettori|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Funzionalità gruppo di forme:**| | |
|Accesso a gruppi di forme|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Creazione di gruppi di forme|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Separazione di gruppi di forme esistenti|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Funzionalità effetti forma:**| | |
|Effetti 2D|limitato|limitato|
|Effetti 3D|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|**Funzionalità testo:**| | |
|Formattazione paragrafi|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Formattazione parti|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Funzionalità animazione:**| | |
|Esportazione animazione in SWF|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|Esportazione animazione in HTML|{{< emoticons/cross >}}|{{< emoticons/cross >}}|