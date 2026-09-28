---
title: Aspose.Slides para Xamarin (Histórica)
linktitle: Xamarin (Histórica)
type: docs
weight: 200
url: /es/net/aspose-slides-for-xamarin/
keywords:
- Xamarin
- desarrollo móvil
- Android
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Histórico: cómo las versiones 20.2 a 22.10 de Aspose.Slides para .NET soportaban Xamarin.Android mediante una biblioteca separada. Las versiones actuales no la incluyen."
---
{{% alert color="info" title="Nota" %}}

Esta es una página histórica. Las versiones 20.2 a 22.10 del paquete Aspose.Slides.NET incluían una biblioteca Xamarin.Android independiente, *Aspose.Slides.Droid.dll*, que el código de esta página utiliza. Las versiones posteriores no la incluyen: el paquete actual contiene compilaciones solo para .NET Framework 4.6.2, .NET 6 y .NET Standard 2.0. Microsoft finalizó el soporte para todos los SDK de Xamarin el 1 de mayo de 2024; consulte la [política de soporte de Xamarin](https://dotnet.microsoft.com/en-us/platform/support/policy/xamarin).

{{% /alert %}}

## **Introducción**

Xamarin es un framework utilizado para el desarrollo móvil en .NET C#. Xamarin dispone de herramientas y bibliotecas que amplían las capacidades de la plataforma .NET. Permite a los desarrolladores crear aplicaciones para el sistema operativo **Android**.

{{% alert color="info" title="Nota" %}}

Para el desarrollo en Xamarin, los programadores pueden usar sus entornos de desarrollo habituales (C#, Visual Studio y bibliotecas de terceros).

{{% /alert %}}

La API Aspose.Slides funcionaba en la plataforma Xamarin. Para lograrlo, el paquete Aspose.Slides.NET, en las versiones 20.2 a 22.10, añadió una DLL independiente para Xamarin. Aspose.Slides para Xamarin soportaba la mayoría de las funciones disponibles en la versión .NET:

- conversión y visualización de presentaciones.  
- edición de contenidos en presentaciones: texto, formas, gráficos, SmartArt, audio/video, fuentes, etc.  
- gestión de animaciones, efectos 2D, WordArt, etc.  
- gestión de metadatos y propiedades del documento.  
- clonación, combinación, comparación, división, etc.

Proporcionamos una comparación de todas las funcionalidades en otra sección cerca del final de esta página.

En la API Aspose.Slides para Xamarin, las clases, espacios de nombres, lógica y comportamiento eran lo más parecidos posible a la versión .NET. Podía migrar sus aplicaciones Aspose.Slides .NET a Xamarin con costos mínimos.

## **Ejemplo rápido**
Puede usar Aspose.Slides para Xamarin para crear y utilizar su aplicación C# a través de Slides para Android.

Ofrecemos un ejemplo de aplicación Android mediante Xamarin que usa Aspose.Slides para mostrar diapositivas de una presentación y agrega una nueva forma en la diapositiva al tocarla. Puede encontrar el código fuente completo de los ejemplos en [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Xamarin).

Comencemos creando una aplicación Xamarin Android:

![Creando una aplicación Xamarin Android](https://lh3.googleusercontent.com/sNkKZnuuGo8phWI-4g4jRA_ZESKpO9RXehPj46RVymXGPcCJuYooePXcBEcb7N6uUUxgocl4o9OjwnajzWKmL2i4MUz3gKKwXw6C0ow_VScN8vlyGBK3SpLKoE_m9BDJ3iNE4xPj)

Primero, creamos un layout de contenido que contendrá una vista de imagen y los botones Anterior y Siguiente:

![Layout de contenido con una vista de imagen y botones Anterior y Siguiente](https://lh3.googleusercontent.com/rX9leIvYTVzQa0YAMj_jPUPs-c9_HwGPZUfR5A3FLiTk0-qzUQ29FfM4hammUVXbbw_Ly0LwEM_VnaI6vslEEMcVlEwVMem0LTiX5kYsA4lxtiHrvXfDPruWPOGU1YKDYSWcNM54)

**XML - content_main.xml - Crear layout de contenido**
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

Aquí, referenciamos la biblioteca "Aspose.Slides.Droid.dll" que incluye una presentación de muestra ("HelloWorld.pptx") en los Assets de la aplicación Xamarin y añadimos su inicialización a MainActivity:

**C# - MainActivity.cs - Inicialización**

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

Añadamos la función para mostrar las diapositivas Anterior y Siguiente al pulsar los botones:

**C# - MainActivity.cs - Mostrar diapositivas al pulsar los botones Anterior y Siguiente**

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

Por último, implementemos una función para añadir una forma elíptica al tocar la diapositiva:

**C# - MainActivity.cs - Añadir elipse al pulsar la diapositiva**

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

Cada pulsación en la diapositiva de la presentación genera una elipse de color aleatorio:

![Diapositiva con elipses añadidas al tocarla](https://lh4.googleusercontent.com/RhjFHm6SgzOkXaehKhsY8q7SRZLFC7vV8_jyw-Gy4Scy68wTMg_apLZ3vPzRLOt1eEw_zUZmLlVhJ8oTGCg10dRNAETLSClRTBEyj2MWuefNpJI4i7WLIe0x8A7xuh4CV91loLKi)

## **Funciones compatibles**

|**FUNCIONALIDADES**|**Aspose.Slides para .NET**|**Aspose.Slides para Xamarin**|
| :- | :- | :- |
|**Funciones de presentación**:| | |
|Crear nuevas presentaciones|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Abrir/guardar formatos PowerPoint 97‑2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Abrir/guardar formatos PowerPoint 2007|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Soporte de extensiones PowerPoint 2010|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Soporte de extensiones PowerPoint 2013|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Soporte de funciones PowerPoint 2016|restringido|restringido|
|Soporte de funciones PowerPoint 2019|restringido|restringido|
|Conversión PPT a PPTX|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Conversión PPTX a PPT|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTX en PPT|restringido|restringido|
|Procesamiento de temas|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Procesamiento de macros|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Procesamiento de propiedades del documento|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Protección con contraseña|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Extracción rápida de texto|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Incrustación de fuentes|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Renderizado de comentarios|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Interrupción de tareas de larga duración|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Formatos de exportación:**| | |
|PDF|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|XPS|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|HTML|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|TIFF|{{< emoticons/tick >}}|{{< emoticons/cross >}}|
|ODP|restringido|restringido|
|SWF|restringido|restringido|
|SVG|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Formatos de importación:**| | |
|HTML|restringido|restringido|
|ODP|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|THMX|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Funciones de diapositivas maestras:**| | |
|Acceso a todas las diapositivas maestras existentes|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Crear/eliminar diapositivas maestras|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Clonar diapositivas maestras|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Funciones de diapositivas de diseño:**| | |
|Acceso a todas las diapositivas de diseño existentes|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Crear/eliminar diapositivas de diseño|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Clonar diapositivas de diseño|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Funciones de diapositivas:**| | |
|Acceso a todas las diapositivas existentes|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Crear/eliminar diapositivas|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Clonar diapositivas|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Exportar diapositivas a imágenes|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Crear/editar/eliminar secciones de diapositivas|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Funciones de diapositivas de notas:**| | |
|Acceso a todas las diapositivas de notas existentes|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Funciones de formas:**| | |
|Acceso a todas las formas de la diapositiva|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Añadir nuevas formas|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Clonar formas|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Exportar formas separadas a imágenes|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Tipos de forma compatibles:**| | |
|Todos los tipos de forma predefinidos|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Marcos de imagen|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Tablas|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Gráficos|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|SmartArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Diagramas heredados|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|WordArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|OLE, objetos ActiveX|restringido|restringido|
|Marcos de vídeo|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Marcos de audio|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Conectores|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Funciones de grupos de formas:**| | |
|Acceso a grupos de formas|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Crear grupos de formas|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Desagrupar grupos de formas existentes|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Funciones de efectos de forma:**| | |
|Efectos 2D|restringido|restringido|
|Efectos 3D|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|**Funciones de texto:**| | |
|Formato de párrafos|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Formato de porciones|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Funciones de animación:**| | |
|Exportar animación a SWF|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|Exportar animación a HTML|{{< emoticons/cross >}}|{{< emoticons/cross >}}|