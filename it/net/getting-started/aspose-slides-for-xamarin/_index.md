---
title: Aspose.Slides per Xamarin
type: docs
weight: 150
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
description: "Crea app mobile Xamarin in C# per visualizzare, modificare e convertire presentazioni con Aspose.Slides, supportando funzionalità avanzate per PPT, PPTX e ODP su Android."
---
## **Introduzione**

Xamarin è un framework utilizzato per lo sviluppo mobile in .NET C#. Xamarin dispone di strumenti e librerie che estendono le capacità della piattaforma .NET. Consente agli sviluppatori di creare applicazioni per il sistema operativo **Android**.

{{% alert color="info" %}} 

Per lo sviluppo in Xamarin, i programmatori possono utilizzare i loro ambienti di sviluppo abituali (C#, Visual Studio e librerie di terze parti).

{{% /alert %}}

Aspose.Slides API funziona sulla piattaforma Xamarin. Per ottenere ciò, il pacchetto Aspose.Slides .NET aggiunge una DLL separata per Xamarin. Aspose.Slides per Xamarin supporta la maggior parte delle funzionalità disponibili nella versione .NET:

- conversione e visualizzazione delle presentazioni.
- modifica dei contenuti nelle presentazioni: testo, forme, grafici, SmartArt, audio/video, caratteri, ecc.
- gestione/uso di animazioni, effetti 2D, WordArt, ecc.
- gestione/uso di metadati e proprietà del documento.
- clonazione, fusione, confronto, suddivisione, ecc.

Abbiamo fornito un confronto delle funzionalità complete in un’altra sezione vicino al fondo di questa pagina.

Nell’API Aspose.Slides per Xamarin, le classi, gli spazi dei nomi, la logica e il comportamento sono il più simili possibile alla versione .NET. È possibile migrare le proprie applicazioni Aspose.Slides .NET su Xamarin con costi minimi.

## **Esempio rapido**

È possibile utilizzare Aspose.Slides per Xamarin per creare e sfruttare la propria applicazione C# tramite Slides per Android.

Fornciamo un esempio di applicazione Android via Xamarin che utilizza Aspose.Slides per visualizzare le diapositive di una presentazione e aggiunge una nuova forma sulla diapositiva al tocco. È possibile trovare il codice completo degli esempi su [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Xamarin).

Iniziamo creando un'app Xamarin Android:

![todo:image_alt_text](https://lh3.googleusercontent.com/sNkKZnuuGo8phWI-4g4jRA_ZESKpO9RXehPj46RVymXGPcCJuYooePXcBEcb7N6uUUxgocl4o9OjwnajzWKmL2i4MUz3gKKwXw6C0ow_VScN8vlyGBK3SpLKoE_m9BDJ3iNE4xPj)

Prima, creiamo un layout di contenuto che conterrà una vista immagine, i pulsanti Prev e Next:

![todo:image_alt_text](https://lh3.googleusercontent.com/rX9leIvYTVzQa0YAMj_jPUPs-c9_HwGPZUfR5A3FLiTk0-qzUQ29FfM4hammUVXbbw_Ly0LwEM_VnaI6vslEEMcVlEwVMem0LTiX5kYsA4lxtiHrvXfDPruWPOGU1YKDYSWcNM54)



**XML - content_main.xml - Crea layout di contenuto**
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

Qui, facciamo riferimento alla libreria "Aspose.Slides.Droid.dll" che include una presentazione di esempio ("HelloWorld.pptx") negli Asset dell'applicazione Xamarin e ne aggiungiamo l'inizializzazione a MainActivity:

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

Aggiungiamo la funzione per visualizzare le diapositive Prev e Next al tocco dei pulsanti:

**C# - MainActivity.cs - Visualizza diapositive al clic dei pulsanti Prev e Next**

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

**C# - MainActivity.cs - Aggiungi ellisse al clic sulla diapositiva**

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

Ogni clic sulla diapositiva della presentazione aggiunge un'ellisse di colore casuale:

![todo:image_alt_text](https://lh4.googleusercontent.com/RhjFHm6SgzOkXaehKhsY8q7SRZLFC7vV8_jyw-Gy4Scy68wTMg_apLZ3vPzRLOt1eEw_zUZmLlVhJ8oTGCg10dRNAETLSClRTBEyj2MWuefNpJI4i7WLIe0x8A7xuh4CV91loLKi)


## **Funzionalità supportate**

|**CARATTERISTICHE**|**Aspose.Slides for .NET**|**Aspose.Slides for Xamarin**|
| :- | :- | :- |
|**Funzionalità presentazione**:| | |
|Crea nuove presentazioni |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Formati PowerPoint 97 - 2003 apri/salva |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Formati PowerPoint 2007 apri/salva |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Supporto estensioni PowerPoint 2010 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Supporto estensioni PowerPoint 2013 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Supporto funzionalità PowerPoint 2016 |restricted|restricted|
|Supporto funzionalità PowerPoint 2019 |restricted |restricted|
|Conversione PPT in PPTX |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Conversione PPTX in PPT |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTX in PPT |restricted|restricted|
|Elaborazione temi |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Elaborazione macro |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Elaborazione proprietà documento |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Protezione con password |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Estrazione rapida del testo |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Incorporamento font |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Rendering commenti |{{< emoticons/tick >}} |{{< emoticons/tick >}}|
|Interruzione di operazioni lunghe |{{< emoticons/tick >}}|{{< emoticons/tick >}} |
|**Formati di esportazione:** | | |
|PDF |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|XPS |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|HTML |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|TIFF |{{< emoticons/tick >}}|{{< emoticons/cross >}}|
|ODP |restricted |restricted|
|SWF |restricted|restricted|
|SVG |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Formati di importazione:** | | |
|HTML |restricted|restricted|
|ODP |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|THMX |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Funzionalità slide master:** | | |
|Accesso a tutte le slide master esistenti |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Creazione/rimozione slide master |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Clonazione slide master |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Funzionalità layout slide:** | | |
|Accesso a tutti i layout slide esistenti |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Creazione/rimozione layout slide |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Clonazione layout slide |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Funzionalità slide:** | | |
|Accesso a tutte le slide esistenti |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Creazione/rimozione slide |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Clonazione slide |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Esportazione slide in immagini |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Creazione/modifica/rimozione sezioni slide |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Funzionalità note slide**: | | |
|Accesso a tutte le note slide esistenti |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Funzionalità forma:** | | |
|Accesso a tutte le forme della slide |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Aggiunta nuove forme |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Clonazione forme |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Esportazione forme separate in immagini |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Tipi di forma supportati:** | | |
|Tutti i tipi di forma predefiniti |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Cornici immagine |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Tabelle |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Grafici |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|SmartArt |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Diagramma legacy |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|WordArt |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Oggetti OLE, ActiveX |restricted|restricted|
|Cornici video |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Cornici audio |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Connettori |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Funzionalità forme di gruppo:** | | |
|Accesso a forme di gruppo |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Creazione forme di gruppo |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Separazione forme di gruppo esistenti |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Funzionalità effetti forma:** | | |
|Effetti 2D |restricted|restricted|
|Effetti 3D |{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|**Funzionalità testo:** | | |
|Formattazione paragrafi |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Formattazione porzioni |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Funzionalità animazione:** | | |
|Esportazione animazione in SWF |{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|Esportazione animazione in HTML |{{< emoticons/cross >}}|{{< emoticons/cross >}}|