---
title: Aspose.Slides pour Xamarin (Historique)
linktitle: Xamarin (Historique)
type: docs
weight: 200
url: /fr/net/aspose-slides-for-xamarin/
keywords:
- Xamarin
- développement mobile
- Android
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Historique : comment les versions Aspose.Slides pour .NET 20.2 à 22.10 prenaient en charge Xamarin.Android via une bibliothèque distincte. Les versions actuelles ne l'incluent pas."
---
{{% alert color="info" title="Note" %}}

Il s'agit d'une page historique. Les versions 20.2 à 22.10 du package Aspose.Slides.NET comprenaient une bibliothèque Xamarin.Android distincte, *Aspose.Slides.Droid.dll*, que le code de cette page utilise. Les versions ultérieures ne la contiennent pas : le package actuel ne propose que des compilations pour .NET Framework 4.6.2, .NET 6 et .NET Standard 2.0. Microsoft a mis fin au support de tous les SDK Xamarin le 1 mai 2024 ; consultez la [politique de support Xamarin](https://dotnet.microsoft.com/en-us/platform/support/policy/xamarin).

{{% /alert %}}

## **Introduction**

Xamarin est un cadre utilisé pour le développement mobile en .NET C#. Xamarin propose des outils et des bibliothèques qui étendent les capacités de la plateforme .NET. Il permet aux développeurs de créer des applications pour le système d’exploitation **Android**.

{{% alert color="info" title="Note" %}}

Pour le développement sous Xamarin, les programmeurs peuvent utiliser leurs environnements de développement habituels (C#, Visual Studio et bibliothèques tierces).

{{% /alert %}}

L’API Aspose.Slides fonctionnait sur la plateforme Xamarin. Pour cela, le package Aspose.Slides.NET, dans les versions 20.2 à 22.10, a ajouté une DLL distincte pour Xamarin. Aspose.Slides pour Xamarin prenait en charge la plupart des fonctionnalités disponibles dans la version .NET :

- conversion et affichage de présentations.
- édition du contenu des présentations : texte, formes, graphiques, SmartArt, audio/vidéo, polices, etc.
- gestion des animations, effets 2D, WordArt, etc.
- gestion des métadonnées et des propriétés du document.
- clonage, fusion, comparaison, division, etc.

Nous avons fourni une comparaison des fonctionnalités complètes dans une autre section près du bas de cette page.

Dans l’API Aspose.Slides pour Xamarin, les classes, espaces de noms, logique et comportement étaient aussi similaires que possible à la version .NET. Vous pouviez migrer vos applications Aspose.Slides .NET vers Xamarin avec des coûts minimes.


## **Exemple rapide**
Vous pouvez utiliser Aspose.Slides pour Xamarin afin de créer et exploiter votre application C# via Slides for Android.

Nous proposons un exemple d’application Android via Xamarin qui utilise Aspose.Slides pour afficher les diapositives d’une présentation et ajouter une nouvelle forme sur la diapositive au toucher. Vous trouverez le code complet des exemples sur [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Xamarin).

Commençons par créer une application Xamarin Android :

![Creating a Xamarin Android app](https://lh3.googleusercontent.com/sNkKZnuuGo8phWI-4g4jRA_ZESKpO9RXehPj46RVymXGPcCJuYooePXcBEcb7N6uUUxgocl4o9OjwnajzWKmL2i4MUz3gKKwXw6C0ow_VScN8vlyGBK3SpLKoE_m9BDJ3iNE4xPj)

Dans un premier temps, nous créons une disposition de contenu qui contiendra une vue d’image, les boutons Précédent et Suivant :

![Content layout with an image view and Prev and Next buttons](https://lh3.googleusercontent.com/rX9leIvYTVzQa0YAMj_jPUPs-c9_HwGPZUfR5A3FLiTk0-qzUQ29FfM4hammUVXbbw_Ly0LwEM_VnaI6vslEEMcVlEwVMem0LTiX5kYsA4lxtiHrvXfDPruWPOGU1YKDYSWcNM54)

**XML - content_main.xml - Créer la disposition de contenu**
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

Ici, nous faisons référence à la bibliothèque "Aspose.Slides.Droid.dll" qui inclut une présentation d’exemple ("HelloWorld.pptx") dans les Assets de l’application Xamarin et nous ajoutons son initialisation à MainActivity :

**C# - MainActivity.cs - Initialisation**

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

Ajoutons la fonction permettant d’afficher les diapositives Précédent et Suivant lors du toucher des boutons :

**C# - MainActivity.cs - Afficher les diapositives au clic des boutons Précédent et Suivant**

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

Enfin, implémentons une fonction pour ajouter une forme ellipsoïdale lors d’un toucher sur la diapositive :

**C# - MainActivity.cs - Ajouter une ellipse au clic sur la diapositive**

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

Chaque clic sur la diapositive de la présentation ajoute une ellipse de couleur aléatoire :

![Slide with ellipses added by touch](https://lh4.googleusercontent.com/RhjFHm6SgzOkXaehKhsY8q7SRZLFC7vV8_jyw-Gy4Scy68wTMg_apLZ3vPzRLOt1eEw_zUZmLlVhJ8oTGCg10dRNAETLSClRTBEyj2MWuefNpJI4i7WLIe0x8A7xuh4CV91loLKi)


## **Fonctionnalités prises en charge**

|**FONCTIONNALITÉS**|**Aspose.Slides pour .NET**|**Aspose.Slides pour Xamarin**|
| :- | :- | :- |
|**Fonctionnalités de présentation**:| | |
|Créer de nouvelles présentations|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Formats PowerPoint 97 - 2003 ouverture/enregistrement|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Formats PowerPoint 2007 ouverture/enregistrement|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Prise en charge des extensions PowerPoint 2010|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Prise en charge des extensions PowerPoint 2013|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Prise en charge des fonctionnalités PowerPoint 2016|restricted|restricted|
|Prise en charge des fonctionnalités PowerPoint 2019|restricted|restricted|
|Conversion PPT → PPTX|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Conversion PPTX → PPT|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTX dans PPT|restricted|restricted|
|Traitement des thèmes|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Traitement des macros|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Traitement des propriétés du document|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Protection par mot de passe|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Extraction rapide de texte|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Incorporation de polices|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Rendu des commentaires|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Interruption des tâches de longue durée|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Formats d’exportation**:| | |
|PDF|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|XPS|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|HTML|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|TIFF|{{< emoticons/tick >}}|{{< emoticons/cross >}}|
|ODP|restricted|restricted|
|SWF|restricted|restricted|
|SVG|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Formats d’importation**:| | |
|HTML|restricted|restricted|
|ODP|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|THMX|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Fonctionnalités des diapositives maîtres**:| | |
|Accès à toutes les diapositives maîtres existantes|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Création/suppression de diapositives maîtres|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Clonage de diapositives maîtres|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Fonctionnalités des dispositions de diapositives**:| | |
|Accès à toutes les dispositions de diapositives existantes|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Création/suppression de dispositions de diapositives|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Clonage de dispositions de diapositives|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Fonctionnalités des diapositives**:| | |
|Accès à toutes les diapositives existantes|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Création/suppression de diapositives|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Clonage de diapositives|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Exportation de diapositives vers des images|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Création/édition/suppression de sections de diapositives|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Fonctionnalités des diapositives de notes**:| | |
|Accès à toutes les diapositives de notes existantes|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Fonctionnalités des formes**:| | |
|Accès à toutes les formes de diapositive|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Ajout de nouvelles formes|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Clonage de formes|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Exportation de formes séparées vers des images|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Types de formes pris en charge**:| | |
|Tous les types de formes prédéfinies|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Cadres d’image|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Tableaux|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Graphiques|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|SmartArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Diagrammes hérités|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|WordArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|OLE, objets ActiveX|restricted|restricted|
|Cadres vidéo|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Cadres audio|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Connecteurs|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Fonctionnalités des groupes de formes**:| | |
|Accès aux groupes de formes|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Création de groupes de formes|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Dégrouper les groupes de formes existants|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Fonctionnalités des effets de forme**:| | |
|Effets 2D|restricted|restricted|
|Effets 3D|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|**Fonctionnalités de texte**:| | |
|Mise en forme des paragraphes|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Mise en forme des portions|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Fonctionnalités d’animation**:| | |
|Exportation d’animation vers SWF|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|Exportation d’animation vers HTML|{{< emoticons/cross >}}|{{< emoticons/cross >}}|