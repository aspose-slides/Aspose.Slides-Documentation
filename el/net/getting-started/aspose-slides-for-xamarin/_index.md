---
title: Aspose.Slides για Xamarin
type: docs
weight: 150
url: /el/net/aspose-slides-for-xamarin/
keywords:
- Xamarin
- ανάπτυξη κινητών
- Android
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Δημιουργήστε κινητές εφαρμογές Xamarin σε C# για προβολή, επεξεργασία και μετατροπή παρουσιάσεων με το Aspose.Slides, υποστηρίζοντας πλούσιες δυνατότητες για PPT, PPTX και ODP στο Android."
---
## **Εισαγωγή**

Το Xamarin είναι ένα πλαίσιο που χρησιμοποιείται για ανάπτυξη κινητών στην .NET C#. Το Xamarin διαθέτει εργαλεία και βιβλιοθήκες που επεκτείνουν τις δυνατότητες της πλατφόρμας .NET. Επιτρέπει στους προγραμματιστές να δημιουργούν εφαρμογές για το λειτουργικό σύστημα **Android**.

{{% alert color="info" %}} 
Για ανάπτυξη στο Xamarin, οι προγραμματιστές μπορούν να χρησιμοποιήσουν τα συνηθισμένα περιβάλλοντα ανάπτυξης (C#, Visual Studio και βιβλιοθήκες τρίτου μέρους).
{{% /alert %}}

Aspose.Slides API λειτουργεί στην πλατφόρμα Xamarin. Για να το επιτευχθεί, το πακέτο Aspose.Slides .NET προσθέτει ένα ξεχωριστό DLL για το Xamarin. Το Aspose.Slides για Xamarin υποστηρίζει τις περισσότερες δυνατότητες που διατίθενται στην έκδοση .NET:

- μετατροπή και προβολή παρουσιάσεων.
- επεξεργασία περιεχομένων παρουσιάσεων: κείμενο, σχήματα, γραφήματα, SmartArt, ήχο/βίντεο, γραμματοσειρές κ.λπ.
- διαχείριση/αντιμετώπιση κίνησης, 2Δ εφέ, WordArt κ.λπ.
- διαχείριση/αντιμετώπιση μεταδεδομένων και ιδιοτήτων εγγράφου.
- κλωνοποίηση, συγχώνευση, σύγκριση, διαχωρισμός κ.λπ.

Παρέχουμε μια σύγκριση των πλήρων δυνατοτήτων σε άλλη ενότητα κοντά στο τέλος αυτής της σελίδας.

Στο API Aspose.Slides για Xamarin, οι κλάσεις, οι χώροι ονομάτων, η λογική και η συμπεριφορά είναι όσο το δυνατόν πιο παρόμοια με την έκδοση .NET. Μπορείτε να μεταφέρετε τις εφαρμογές Aspose.Slides .NET στο Xamarin με ελάχιστο κόστος.

## **Γρήγορο Παράδειγμα**
Μπορείτε να χρησιμοποιήσετε το Aspose.Slides για Xamarin για να δημιουργήσετε και να αξιοποιήσετε την εφαρμογή C# μέσω Slides for Android.

Παρέχουμε ένα παράδειγμα εφαρμογής Android μέσω Xamarin που χρησιμοποιεί το Aspose.Slides για να εμφανίσει διαφάνειες παρουσίασης και προσθέτει ένα νέο σχήμα στη διαφάνεια με την αφή. Μπορείτε να βρείτε τον πλήρη πηγαίο κώδικα των παραδειγμάτων στο [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Xamarin).

Ας ξεκινήσουμε δημιουργώντας μια εφαρμογή Xamarin Android:

![todo:image_alt_text](https://lh3.googleusercontent.com/sNkKZnuuGo8phWI-4g4jRA_ZESKpO9RXehPj46RVymXGPcCJuYooePXcBEcb7N6uUUxgocl4o9OjwnajzWKmL2i4MUz3gKKwXw6C0ow_VScN8vlyGBK3SpLKoE_m9BDJ3iNE4xPj)

Πρώτα, δημιουργούμε μια διάταξη περιεχομένου που θα περιέχει μια προβολή εικόνας, και τα κουμπιά Prev και Next:

![todo:image_alt_text](https://lh3.googleusercontent.com/rX9leIvYTVzQa0YAMj_jPUPs-c9_HwGPZUfR5A3FLiTk0-qzUQ29FfM4hammUVXbbw_Ly0LwEM_VnaI6vslEEMcVlEwVMem0LTiX5kYsA4lxtiHrvXfDPruWPOGU1YKDYSWcNM54)

**XML - content_main.xml - Δημιουργία διάταξης περιεχομένου**
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

Εδώ, αναφερόμαστε στη βιβλιοθήκη "Aspose.Slides.Droid.dll" που περιλαμβάνει ένα δείγμα παρουσίασης ("HelloWorld.pptx") στα Assets της εφαρμογής Xamarin και προσθέτουμε την αρχικοποίησή της στο MainActivity:

**C# - MainActivity.cs - Αρχικοποίηση**
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

Ας προσθέσουμε τη λειτουργία για την εμφάνιση των διαφανειών Prev και Next με το πάτημα των κουμπιών:
**C# - MainActivity.cs - Εμφάνιση διαφανειών κατά το κλικ στα κουμπιά Prev και Next**
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

Τέλος, ας υλοποιήσουμε μια λειτουργία για την προσθήκη ενός σχήματος έλλειψης κατά το άγγιγμα της διαφάνειας:
**C# - MainActivity.cs - Προσθήκη έλλειψης με κλικ στη διαφάνεια**
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

Κάθε κλικ στη διαφάνεια παρουσίασης προσθέτει μια έλλειψη τυχαίου χρώματος:
![todo:image_alt_text](https://lh4.googleusercontent.com/RhjFHm6SgzOkXaehKhsY8q7SRZLFC7vV8_jyw-Gy4Scy68wTMg_apLZ3vPzRLOt1eEw_zUZmLlVhJ8oTGCg10dRNAETLSClRTBEyj2MWuefNpJI4i7WLIe0x8A7xuh4CV91loLKi)

## **Υποστηριζόμενες Λειτουργίες**

|**ΛΕΙΤΟΥΡΓΙΕΣ**|**Aspose.Slides για .NET**|**Aspose.Slides για Xamarin**|
| :- | :- | :- |
|**Λειτουργίες Παρουσίασης**:| | |
|Δημιουργία νέων παρουσιάσεων|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Άνοιγμα/αποθήκευση μορφών PowerPoint 97 - 2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Άνοιγμα/αποθήκευση μορφών PowerPoint 2007|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Υποστήριξη επεκτάσεων PowerPoint 2010|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Υποστήριξη επεκτάσεων PowerPoint 2013|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Υποστήριξη λειτουργιών PowerPoint 2016|περιορισμένη|περιορισμένη|
|Υποστήριξη λειτουργιών PowerPoint 2019|περιορισμένη|περιορισμένη|
|Μετατροπή PPT σε PPTX|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Μετατροπή PPTX σε PPT|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTX σε PPT|περιορισμένη|περιορισμένη|
|Επεξεργασία θεμάτων|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Επεξεργασία μακροεντολών|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Επεξεργασία ιδιοτήτων εγγράφου|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Προστασία κωδικού|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Γρήγορη εξαγωγή κειμένου|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Ενσωμάτωση γραμματοσειρών|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Απόδοση σχολίων|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Διακοπή μακροχρόνιων εργασιών|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Μορφές εξαγωγής:**| | |
|PDF|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|XPS|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|HTML|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|TIFF|{{< emoticons/tick >}}|{{< emoticons/cross >}}|
|ODP|περιορισμένη|περιορισμένη|
|SWF|περιορισμένη|περιορισμένη|
|SVG|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Μορφές εισαγωγής:**| | |
|HTML|περιορισμένη|περιορισμένη|
|ODP|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|THMX|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Λειτουργίες κύριας διαφάνειας:**| | |
|Πρόσβαση σε όλες τις υπάρχουσες κύριες διαφάνειες|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Δημιουργία/αφαίρεση κύριων διαφανειών|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Κλωνοποίηση κύριων διαφανειών|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Λειτουργίες διαφάνειας διάταξης:**| | |
|Πρόσβαση σε όλες τις υπάρχουσες διαφάνειες διάταξης|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Δημιουργία/αφαίρεση διαφανειών διάταξης|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Κλωνοποίηση διαφανειών διάταξης|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Λειτουργίες διαφάνειας:**| | |
|Πρόσβαση σε όλες τις υπάρχουσες διαφάνειες|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Δημιουργία/αφαίρεση διαφανειών|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Κλωνοποίηση διαφανειών|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Εξαγωγή διαφανειών σε εικόνες|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Δημιουργία/επεξεργασία/αφαίρεση ενοτήτων διαφάνειας|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Λειτουργίες διαφάνειας σημειώσεων:**| | |
|Πρόσβαση σε όλες τις υπάρχουσες διαφάνειες σημειώσεων|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Λειτουργίες σχήματος:**| | |
|Πρόσβαση σε όλα τα σχήματα της διαφάνειας|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Προσθήκη νέων σχημάτων|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Κλωνοποίηση σχημάτων|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Εξαγωγή ξεχωριστών σχημάτων σε εικόνες|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Υποστηριζόμενοι τύποι σχημάτων:**| | |
|Όλοι οι προ-ορισμένοι τύποι σχημάτων|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Πλαίσια εικόνας|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Πίνακες|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Διαγράμματα|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|SmartArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Διάγραμμα παλαιού τύπου|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|WordArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|OLE, αντικείμενα ActiveX|περιορισμένη|περιορισμένη|
|Πλαίσια βίντεο|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Πλαίσια ήχου|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Συνδέσμους|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Λειτουργίες ομαδικού σχήματος:**| | |
|Πρόσβαση σε ομαδικά σχήματα|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Δημιουργία ομαδικών σχημάτων|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Αποομαδοποίηση υπαρχόντων ομαδικών σχημάτων|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Λειτουργίες εφέ σχήματος:**| | |
|2Δ εφέ|περιορισμένη|περιορισμένη|
|3Δ εφέ|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|**Λειτουργίες κειμένου:**| | |
|Μορφοποίηση παραγράφων|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Μορφοποίηση τμημάτων|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Λειτουργίες κίνησης:**| | |
|Εξαγωγή κίνησης σε SWF|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|Εξαγωγή κίνησης σε HTML|{{< emoticons/cross >}}|{{< emoticons/cross >}}|