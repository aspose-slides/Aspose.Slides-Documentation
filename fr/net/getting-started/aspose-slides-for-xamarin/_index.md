---
title: Aspose.Slides pour Xamarin
type: docs
weight: 150
url: /fr/net/aspose-slides-for-xamarin/
---

## **Aperçu**
Xamarin est un cadre utilisé pour le développement mobile en .NET C#. Xamarin dispose d'outils et de bibliothèques qui étendent les capacités de la plateforme .NET. Il permet aux développeurs de construire des applications pour le système d'exploitation **Android**.

{{% alert color="primary" %}}

Pour le développement dans Xamarin, les programmeurs peuvent utiliser leurs environnements de développement habituels (C#, Visual Studio et bibliothèques tierces).

{{% /alert %}}

L'API Aspose.Slides fonctionne sur la plateforme Xamarin. Pour cela, le package Aspose.Slides .NET ajoute une DLL séparée pour Xamarin. Aspose.Slides pour Xamarin prend en charge la plupart des fonctionnalités disponibles dans la version .NET :

- conversion et visualisation de présentations.
- édition des contenus des présentations : texte, formes, graphiques, SmartArt, audio/vidéo, polices, etc.
- gestion des animations, effets 2D, WordArt, etc.
- gestion des métadonnées et des propriétés du document.
- impression, clonage, fusion, comparaison, séparation, etc.

Nous avons fourni une comparaison des fonctionnalités complètes dans une autre section près du bas de cette page.

Dans l'API Aspose.Slides pour Xamarin, les classes, espaces de noms, logique et comportement sont aussi similaires que possible à la version .NET. Vous pouvez migrer vos applications Aspose.Slides .NET vers Xamarin avec des coûts minimes.

## **Exemple Rapide**
Vous pouvez utiliser Aspose.Slides pour Xamarin pour construire et utiliser votre application C# via Slides pour Android.

Nous fournissons un exemple d'application Android via Xamarin qui utilise Aspose.Slides pour afficher des diapositives de présentation et ajoute une nouvelle forme sur la diapositive au toucher. Vous pouvez trouver le code source complet des exemples sur [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Xamarin).

Commençons par créer une application Xamarin Android :

![todo:image_alt_text](https://lh3.googleusercontent.com/sNkKZnuuGo8phWI-4g4jRA_ZESKpO9RXehPj46RVymXGPcCJuYooePXcBEcb7N6uUUxgocl4o9OjwnajzWKmL2i4MUz3gKKwXw6C0ow_VScN8vlyGBK3SpLKoE_m9BDJ3iNE4xPj)

Tout d'abord, nous créons une mise en page de contenu qui contiendra une image, des boutons Précédent et Suivant :

![todo:image_alt_text](https://lh3.googleusercontent.com/rX9leIvYTVzQa0YAMj_jPUPs-c9_HwGPZUfR5A3FLiTk0-qzUQ29FfM4hammUVXbbw_Ly0LwEM_VnaI6vslEEMcVlEwVMem0LTiX5kYsA4lxtiHrvXfDPruWPOGU1YKDYSWcNM54)

**XML - content_main.xml - Créer la mise en page de contenu**
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
            android:text="Précédent"
            android:layout_width="wrap_content"
            android:layout_height="wrap_content"
            android:id="@+id/buttonPrev" />
        <Button
            android:text="Suivant"
            android:layout_width="wrap_content"
            android:layout_height="wrap_content"
            android:id="@+id/buttonNext"/>
    </LinearLayout>
</LinearLayout>
```

Ici, nous référencions la bibliothèque "Aspose.Slides.Droid.dll" qui comprend une présentation d'exemple ("HelloWorld.pptx") dans les actifs de l'application Xamarin et ajoutons son initialisation à MainActivity :

**C# - MainActivity.cs - Initialisation**

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

Ajoutons la fonction pour afficher les diapositives Précédent et Suivant lors du clic sur les boutons :

**C# - MainActivity.cs - Afficher les diapositives lors du clic sur les boutons Précédent et Suivant**

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

Enfin, implémentons une fonction pour ajouter une forme ellipse lors d'un toucher sur la diapositive :

**C# - MainActivity.cs - Ajouter une ellipse par clic sur la diapositive**

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

Chaque clic sur la diapositive de la présentation entraîne l'ajout d'une ellipse de couleur aléatoire :

![todo:image_alt_text](https://lh4.googleusercontent.com/RhjFHm6SgzOkXaehKhsY8q7SRZLFC7vV8_jyw-Gy4Scy68wTMg_apLZ3vPzRLOt1eEw_zUZmLlVhJ8oTGCg10dRNAETLSClRTBEyj2MWuefNpJI4i7WLIe0x8A7xuh4CV91loLKi)

## **Fonctionnalités prises en charge**

|**FONCTIONNALITÉS** |**Aspose.Slides pour .NET**  |**Aspose.Slides pour Xamarin**|
| :- | :- | :- |
|**Fonctionnalités de présentation**: | | |
|Créer de nouvelles présentations |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Formats PowerPoint 97 - 2003 ouvrir/enregistrer |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Formats PowerPoint 2007 ouvrir/enregistrer |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Prise en charge des extensions PowerPoint 2010 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Prise en charge des extensions PowerPoint 2013 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Prise en charge des fonctionnalités PowerPoint 2016 |restreint|restreint|
|Prise en charge des fonctionnalités PowerPoint 2019 |restreint |restreint|
|Conversion PPT 2 PPTX |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Conversion PPTX 2 PPT |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTX dans PPT |restreint|restreint|
|Traitement des thèmes |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Traitement des macros |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Traitement des propriétés du document |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Protection par mot de passe |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Extraction rapide de texte |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Intégration des polices |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Rendu des commentaires |{{< emoticons/tick >}} |{{< emoticons/tick >}}|
|Interruption des tâches de longue durée |{{< emoticons/tick >}}|{{< emoticons/tick >}} |
|**Formats d'exportation :** | | |
|PDF |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|XPS |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|HTML |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|TIFF |{{< emoticons/tick >}}|{{< emoticons/cross >}}|
|ODP |restreint |restreint|
|SWF |restreint|restreint|
|SVG |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Formats d'importation :** | | |
|HTML |restreint|restreint|
|ODP |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|THMX |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Fonctionnalités des diapositives maîtresses :** | | |
|Accès à toutes les diapositives maîtresses existantes |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Création/suppression de diapositives maîtresses |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Clonage de diapositives maîtresses |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Fonctionnalités des diapositives de mise en page :** | | |
|Accès à toutes les diapositives de mise en page existantes |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Création/suppression de diapositives de mise en page |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Clonage de diapositives de mise en page |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Fonctionnalités des diapositives :** | | |
|Accès à toutes les diapositives existantes |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Création/suppression de diapositives |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Clonage de diapositives |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Exportation des diapositives vers des images |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Création/édition/suppression des sections de diapositives |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Fonctionnalités des diapositives de notes :** | | |
|Accès à toutes les diapositives de notes existantes |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Fonctionnalités des formes :** | | |
|Accès à toutes les formes de diapositives |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Ajout de nouvelles formes |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Clonage des formes |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Exportation de formes séparées vers des images |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Types de formes pris en charge :** | | |
|Tous les types de formes prédéfinis |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Cadres d'image |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Tableaux |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Graphiques |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|SmartArt |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Diagramme hérité |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|WordArt |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|OLE, objets ActiveX |restreint|restreint|
|Cadres vidéo |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Cadres audio |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Connecteurs |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Fonctionnalités des formes de groupe :** | | |
|Accès aux formes de groupe |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Création de formes de groupe |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Dissociation des formes de groupe existantes |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Fonctionnalités des effets de forme :** | | |
|Effets 2D |restreint|restreint|
|Effets 3D |{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|**Fonctionnalités de texte :** | | |
|Mise en forme des paragraphes |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Mise en forme des portions |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Fonctionnalités d'animation :** | | |
|Exporter l'animation vers SWF |{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|Exporter l'animation vers HTML |{{< emoticons/cross >}}|{{< emoticons/cross >}}|