---
title: Aspose.Slides for Xamarin
type: docs
weight: 150
url: /net/aspose-slides-for-xamarin/
---

## **Overview**
Xamarin is a framework used for mobile development in .NET C#. Xamarin has tools and libraries that extend the capabilities of the .NET platform. It allows developers to build applications for the **Android** operating system. 

{{% alert color="primary" %}} 

For development in Xamarin, programmers can use their regular development environments (C#, Visual Studio, and 3rd party libraries).

{{% /alert %}}

Aspose.Slides API works on the Xamarin platform. To achieve this, the Aspose.Slides .NET package adds a separate DLL for Xamarin. Aspose.Slides for Xamarin supports most of the features available in the .NET version:

- converting and viewing presentations.
- editing contents in presentations: text, shapes, charts, SmartArt, audio/video, fonts, etc.
- handling/dealing with animation, 2D effects, WordArt, etc.
- handling/dealing with metadata and document properties.
- printing, cloning, merging, comparing, splitting, etc.

We provided a comparison of the full features in another section close to the bottom of this page.

In Aspose.Slides for Xamarin API, the classes, namespaces, logic, and behavior are as similar as possible to the .NET version. You can migrate your Aspose.Slides .NET applications to Xamarin with minimal costs.


## **Quick Example**
You can use Aspose.Slides for Xamarin to build and utilize your C# application through Slides for Android.

We are providing an example of Android via Xamarin application that uses Aspose.Slides to display presentation slides and adds a new shape on the slide on touch. You can find the full source of the examples on [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Xamarin).

Let’s start by creating a Xamarin Android App:

![todo:image_alt_text](https://lh3.googleusercontent.com/sNkKZnuuGo8phWI-4g4jRA_ZESKpO9RXehPj46RVymXGPcCJuYooePXcBEcb7N6uUUxgocl4o9OjwnajzWKmL2i4MUz3gKKwXw6C0ow_VScN8vlyGBK3SpLKoE_m9BDJ3iNE4xPj)

First, we create a content layout that will contain an image view, Prev, and Next buttons:

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



Here, we reference the "Aspose.Slides.Droid.dll" library that includes a sample presentation ("HelloWorld.pptx") into Xamarin application Assets and adds its initialization to MainActivity:

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

Let’s add the function to display the Prev and Next slides on the tapping of buttons:

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



Finally, let’s implement a function to add an ellipse shape on a touch on the slide:

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

Each click on the presentation slide causes a random colored ellipse to be added:

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
|PowerPoint 2016 features support |restricted|restricted|
|PowerPoint 2019 features support |restricted |restricted|
|PPT 2 PPTX conversion |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTX 2 PPT conversion |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTX in PPT |restricted|restricted|
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
|ODP |restricted |restricted|
|SWF |restricted|restricted|
|SVG |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Import formats:** | | |
|HTML |restricted|restricted|
|ODP |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|THMX |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Master slides features:** | | |
|Accessing all existing master slide |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Creating/removing master slides |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Cloning master slides |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Layout slides features:** | | |
|Accessing all existing layout slides |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Creating/removing layout slides |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Cloning layout slides |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Slide features:** | | |
|Accessing all existing slides |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Creating/removing slides |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Cloning slides |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Exporting slides to images |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Creating/editing/removing slide sections |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Notes slides features**: | | |
|Accessing all existing notes slides |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Shape features:** | | |
|Accessing all slide shapes |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Adding new shapes |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Cloning shapes |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Exporting separate shapes to images |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Supported shape types:** | | |
|All predefined shape types |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Picture frames |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Tables |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Charts |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|SmartArt |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Legacy diagram |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|WordArt |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|OLE, ActiveX objects |restricted|restricted|
|Video frames |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Audio frames |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Connectors |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Group shape features:** | | |
|Accessing group shapes |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Creating group shapes |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Ungrouping existing group shapes |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Shape effects features:** | | |
|2D effects |restricted|restricted|
|3D effects |{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|**Text features:** | | |
|Paragraphs formatting |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Portions formatting |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Animation Features:** | | |
|Export animation to SWF |{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|Export animation to HTML |{{< emoticons/cross >}}|{{< emoticons/cross >}}|

