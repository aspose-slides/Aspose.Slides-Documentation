---
title: Aspose.Slides for Xamarin
type: docs
weight: 150
url: /net/aspose-slides-for-xamarin/
---

## **Overview**
Xamarin is a framework for cross-platform mobile development using .NET C#. Xamarin is having tools and libraries that extend the possibilities of the .NET platform and allow building applications for any mobile OS: Android, iOS and Windows. For development in Xamarin, programmers can use their usual environment including C#, Visual Studio, 3-rd party libraries.

Aspose.Slides API can work in Xamarin platform. For that, the Aspose.Slides .NET package includes a separate dll for Xamarin. Aspose.Slides for Xamarin supports most features available in .NET version:

- presentation conversion and viewing.
- presentation content editing: text, shapes, charts, SmartArt, audio/video, fonts, etc.
- animation, 2D effects, WordArt, etc.
- metadata and document properties.
- printing, cloning, merging, comparing, splitting, etc.

The full features comparison is available in this topic below.

In Aspose.Slides for Xamarin API the classes, namespaces, logic and behaviour are as close as possible to the .NET version. You may migrate your Aspose.Slides .NET applications to Xamarin with the minimal costs.


## **Quick Example**
Aspose.Slides for Xamarin can be used to build and use your C# application using Slides for Android. Below is a simple example of Android via Xamarin application that uses Aspose.Slides to display presentation slides and adding a new shape on the slide by touch. Full sources of the example are available on [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Xamarin).

Let’s start from creating a Xamarin Android App:

![todo:image_alt_text](https://lh3.googleusercontent.com/sNkKZnuuGo8phWI-4g4jRA_ZESKpO9RXehPj46RVymXGPcCJuYooePXcBEcb7N6uUUxgocl4o9OjwnajzWKmL2i4MUz3gKKwXw6C0ow_VScN8vlyGBK3SpLKoE_m9BDJ3iNE4xPj)

First, we create a content layout that will contain an image view and Prev, Next buttons:

![todo:image_alt_text](https://lh3.googleusercontent.com/rX9leIvYTVzQa0YAMj_jPUPs-c9_HwGPZUfR5A3FLiTk0-qzUQ29FfM4hammUVXbbw_Ly0LwEM_VnaI6vslEEMcVlEwVMem0LTiX5kYsA4lxtiHrvXfDPruWPOGU1YKDYSWcNM54)



**XML - content_main.xml - Create content layout**
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



Then we will reference the "Aspose.Slides.Droid.dll" library, include sample presentation ("HelloWorld.pptx") into Xamarin application Assets and add it’s initialization into MainActivity:

**C# - MainActivity.cs - Initialization**
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



Let’s add displaying Prev and Next slide on buttons click:

**C# - MainActivity.cs - Display slides on Prev and Next button click**
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



Finally, let’s implement adding an ellipse shape by touch on the slide:

**C# - MainActivity.cs - Add ellipse by slide click**
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



By each click on the presentation slide, an ellipse of a random color is added:

![todo:image_alt_text](https://lh4.googleusercontent.com/RhjFHm6SgzOkXaehKhsY8q7SRZLFC7vV8_jyw-Gy4Scy68wTMg_apLZ3vPzRLOt1eEw_zUZmLlVhJ8oTGCg10dRNAETLSClRTBEyj2MWuefNpJI4i7WLIe0x8A7xuh4CV91loLKi)


## **Supported Features**

|**FEATURES** |**Aspose.Slides for .NET**  |**Aspose.Slides for Xamarin**|
| :- | :- | :- |
|**Presentation features**: | | |
|Create new presentations |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 97 - 2003 formats open/save |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2007 formats open/save |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2010 extensions support |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2013 extensions support |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2016 features support |[restricted](https://issue.lutsk.dynabic.com/issues/SLIDESNET-40063)|[restricted](https://issue.lutsk.dynabic.com/issues/SLIDESNET-40063)|
|PowerPoint 2019 features support |[restricted](https://issue.lutsk.dynabic.com/issues/SLIDESNET-40063) |[restricted](https://issue.lutsk.dynabic.com/issues/SLIDESNET-40063)|
|PPT 2 PPTX conversion |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTX 2 PPT conversion |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTX in PPT |[restricted](https://issue.lutsk.dynabic.com/issues/SLIDESNET-35794)|[restricted](https://issue.lutsk.dynabic.com/issues/SLIDESNET-40063)|
|Themes processing |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Macros processing |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Document properties processing |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Password protection |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Fast text extraction |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Embedding fonts |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Comments rendering |{{< emoticons/tick >}} |{{< emoticons/tick >}}|
|Interrupting of long-running tasks |{{< emoticons/tick >}}|{{< emoticons/tick >}} |
|**Export formats:** | | |
|PDF |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|XPS |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|HTML |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|TIFF |{{< emoticons/tick >}}|{{< emoticons/cross >}}|
|ODP |[restricted](https://wiki.lutsk.dynabic.com/Aspose%20Slides/slides/Product%20Family%20Vision%20and%20Roadmap/) |[restricted](https://issue.lutsk.dynabic.com/issues/SLIDESNET-40063)|
|SWF |[restricted](https://issue.lutsk.dynabic.com/issues/SLIDESNET-36065) |[restricted](https://issue.lutsk.dynabic.com/issues/SLIDESNET-40063)|
|SVG |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Import formats:** | | |
|HTML |[restricted](https://issue.lutsk.dynabic.com/issues/SLIDESNET-34636)|[restricted](https://issue.lutsk.dynabic.com/issues/SLIDESNET-40063)|
|ODP |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|THMX |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Master slides features:** | | |
|Access all existing master slide |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Create/remove master slides |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Clone master slides |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Layout slides features:** | | |
|Access all existing layout slides |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Create/remove layout slides |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Clone layout slides |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Slide features:** | | |
|Access all existing slides |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Create/remove slides |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Clone slides |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Export slides to images |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Create/edit/remove slide sections |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Notes slides features**: | | |
|Access all existing notes slides |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Shape features:** | | |
|Access all slide shapes |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Add new shapes |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Clone shapes |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Export separate shapes to images |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Supported shape types:** | | |
|All predefined shape types |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Picture frames |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Tables |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Charts |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|SmartArt |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Legacy diagram |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|WordArt |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|OLE, ActiveX objects |[restricted](https://issue.lutsk.dynabic.com/issues/SLIDESNET-35108)|[restricted](https://issue.lutsk.dynabic.com/issues/SLIDESNET-40063)|
|Video frames |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Audio frames |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Connectors |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Group shape features:** | | |
|Access group shapes |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Create group shapes |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Ungroup existing group shapes |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Shape effects features:** | | |
|2D effects |[restricted](https://issue.lutsk.dynabic.com/issues/SLIDESNET-40180) |[restricted](https://issue.lutsk.dynabic.com/issues/SLIDESNET-40063)|
|3D effects |{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|**Text features:** | | |
|Paragraphs formatting |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Portions formatting |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Animation Features:** | | |
|Export animation to SWF |{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|Export animation to HTML |{{< emoticons/cross >}}|{{< emoticons/cross >}}|

