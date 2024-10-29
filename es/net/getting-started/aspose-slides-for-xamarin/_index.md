---
title: Aspose.Slides para Xamarin
type: docs
weight: 150
url: /es/net/aspose-slides-for-xamarin/
---

## **Descripción general**
Xamarin es un marco de trabajo utilizado para el desarrollo móvil en .NET C#. Xamarin cuenta con herramientas y bibliotecas que amplían las capacidades de la plataforma .NET. Permite a los desarrolladores crear aplicaciones para el sistema operativo **Android**.

{{% alert color="primary" %}} 

Para el desarrollo en Xamarin, los programadores pueden usar sus entornos de desarrollo habituales (C#, Visual Studio y bibliotecas de terceros).

{{% /alert %}}

La API de Aspose.Slides funciona en la plataforma Xamarin. Para lograr esto, el paquete Aspose.Slides .NET agrega una DLL separada para Xamarin. Aspose.Slides para Xamarin admite la mayoría de las características disponibles en la versión .NET:

- conversión y visualización de presentaciones.
- edición de contenidos en presentaciones: texto, formas, gráficos, SmartArt, audio/video, fuentes, etc.
- manejo/trato con animación, efectos 2D, WordArt, etc.
- manejo/trato con metadatos y propiedades del documento.
- impresión, clonación, fusión, comparación, división, etc.

Proporcionamos una comparación de las características completas en otra sección cerca de la parte inferior de esta página.

En la API de Aspose.Slides para Xamarin, las clases, espacios de nombres, lógica y comportamiento son lo más similares posible a la versión .NET. Puedes migrar tus aplicaciones Aspose.Slides .NET a Xamarin con costos mínimos.


## **Ejemplo rápido**
Puedes usar Aspose.Slides para Xamarin para construir y utilizar tu aplicación C# a través de Slides para Android.

Estamos proporcionando un ejemplo de aplicación de Android a través de Xamarin que utiliza Aspose.Slides para mostrar las diapositivas de presentación y agrega una nueva forma en la diapositiva al tocar. Puedes encontrar el código fuente completo de los ejemplos en [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Xamarin).

Comencemos creando una aplicación Xamarin Android:

![todo:image_alt_text](https://lh3.googleusercontent.com/sNkKZnuuGo8phWI-4g4jRA_ZESKpO9RXehPj46RVymXGPcCJuYooePXcBEcb7N6uUUxgocl4o9OjwnajzWKmL2i4MUz3gKKwXw6C0ow_VScN8vlyGBK3SpLKoE_m9BDJ3iNE4xPj)

Primero, creamos un diseño de contenido que contendrá una vista de imagen y los botones Anterior y Siguiente:

![todo:image_alt_text](https://lh3.googleusercontent.com/rX9leIvYTVzQa0YAMj_jPUPs-c9_HwGPZUfR5A3FLiTk0-qzUQ29FfM4hammUVXbbw_Ly0LwEM_VnaI6vslEEMcVlEwVMem0LTiX5kYsA4lxtiHrvXfDPruWPOGU1YKDYSWcNM54)



**XML - content_main.xml - Crear diseño de contenido**
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



Aquí, hacemos referencia a la biblioteca "Aspose.Slides.Droid.dll" que incluye una presentación de ejemplo ("HelloWorld.pptx") en los Assets de la aplicación Xamarin y agrega su inicialización en MainActivity:

**C# - MainActivity.cs - Inicialización**

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

Agreguemos la función para mostrar las diapositivas Anterior y Siguiente al tocar los botones:

**C# - MainActivity.cs - Mostrar diapositivas al hacer clic en los botones Anterior y Siguiente**

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



Finalmente, implementemos una función para agregar una forma elíptica al tocar la diapositiva:

**C# - MainActivity.cs - Agregar elipse al hacer clic en la diapositiva**

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

Cada clic en la diapositiva de presentación hace que se agregue una elipse de color aleatorio:

![todo:image_alt_text](https://lh4.googleusercontent.com/RhjFHm6SgzOkXaehKhsY8q7SRZLFC7vV8_jyw-Gy4Scy68wTMg_apLZ3vPzRLOt1eEw_zUZmLlVhJ8oTGCg10dRNAETLSClRTBEyj2MWuefNpJI4i7WLIe0x8A7xuh4CV91loLKi)


## **Características compatibles**

|**CARACTERÍSTICAS** |**Aspose.Slides para .NET** |**Aspose.Slides para Xamarin**|
| :- | :- | :- |
|**Características de presentación**: | | |
|Crear nuevas presentaciones |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Formatos de PowerPoint 97 - 2003 abrir/guardar |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Formatos de PowerPoint 2007 abrir/guardar |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Soporte para extensiones de PowerPoint 2010 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Soporte para extensiones de PowerPoint 2013 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Soporte para características de PowerPoint 2016 |restringido|restringido|
|Soporte para características de PowerPoint 2019 |restringido |restringido|
|Conversión de PPT a PPTX |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Conversión de PPTX a PPT |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTX en PPT |restringido|restringido|
|Procesamiento de temas |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Procesamiento de macros |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Procesamiento de propiedades del documento |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Protección por contraseña |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Extracción rápida de texto |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Incrustación de fuentes |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Renderización de comentarios |{{< emoticons/tick >}} |{{< emoticons/tick >}}|
|Interrupción de tareas de larga ejecución |{{< emoticons/tick >}}|{{< emoticons/tick >}} |
|**Formatos de exportación:** | | |
|PDF |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|XPS |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|HTML |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|TIFF |{{< emoticons/tick >}}|{{< emoticons/cross >}}|
|ODP |restringido |restringido|
|SWF |restringido|restringido|
|SVG |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Formatos de importación:** | | |
|HTML |restringido|restringido|
|ODP |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|THMX |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Características de diapositivas maestras:** | | |
|Acceder a todas las diapositivas maestras existentes |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Crear/eliminar diapositivas maestras |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Clonar diapositivas maestras |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Características de diseño de diapositivas:** | | |
|Acceder a todas las diapositivas de diseño existentes |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Crear/eliminar diapositivas de diseño |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Clonar diapositivas de diseño |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Características de diapositivas:** | | |
|Acceder a todas las diapositivas existentes |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Crear/eliminar diapositivas |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Clonar diapositivas |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Exportar diapositivas a imágenes |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Crear/editar/eliminar secciones de diapositivas |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Características de diapositivas de notas:** | | |
|Acceder a todas las diapositivas de notas existentes |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Características de formas:** | | |
|Acceder a todas las formas de las diapositivas |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Agregar nuevas formas |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Clonar formas |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Exportar formas individuales a imágenes |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Tipos de formas compatibles:** | | |
|Todos los tipos de formas predefinidos |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Marcos de imagen |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Tablas |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Gráficos |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|SmartArt |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Diagrama legado |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|WordArt |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Objetos OLE, ActiveX |restringido|restringido|
|Marcos de video |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Marcos de audio |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Conectores |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Características de formas agrupadas:** | | |
|Acceder a formas agrupadas |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Crear formas agrupadas |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Desagrupar formas agrupadas existentes |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Características de efectos de forma:** | | |
|Efectos 2D |restringido|restringido|
|Efectos 3D |{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|**Características de texto:** | | |
|Formateo de párrafos |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Formateo de porciones |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Características de animación:** | | |
|Exportar animación a SWF |{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|Exportar animación a HTML |{{< emoticons/cross >}}|{{< emoticons/cross >}}|