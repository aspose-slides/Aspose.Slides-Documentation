---
title: Aspose.Slides для Xamarin
type: docs
weight: 150
url: /ru/net/aspose-slides-for-xamarin/
keywords:
- Xamarin
- мобильная разработка
- Android
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Создавайте мобильные приложения Xamarin на C# для просмотра, редактирования и конвертации презентаций с помощью Aspose.Slides, поддерживая расширенные функции для PPT, PPTX и ODP на Android."
---
## **Введение**

Xamarin — это фреймворк, используемый для мобильной разработки в .NET C#. Xamarin имеет инструменты и библиотеки, расширяющие возможности платформы .NET. Он позволяет разработчикам создавать приложения для операционной системы **Android**.

{{% alert color="info" %}} 

Для разработки в Xamarin программисты могут использовать привычные среды разработки (C#, Visual Studio и сторонние библиотеки).

{{% /alert %}}

API Aspose.Slides работает на платформе Xamarin. Для этого пакет Aspose.Slides .NET добавляет отдельный DLL‑файл для Xamarin. Aspose.Slides для Xamarin поддерживает большинство функций, доступных в версии .NET:

- конвертирование и просмотр презентаций.  
- редактирование содержимого презентаций: текст, фигуры, диаграммы, SmartArt, аудио/видео, шрифты и т.д.  
- работа с анимацией, 2D‑эффектами, WordArt и прочим.  
- работа с метаданными и свойствами документа.  
- печать, клонирование, объединение, сравнение, разбиение и т.п.

Мы предоставили сравнение полного набора функций в отдельном разделе внизу этой страницы.

В API Aspose.Slides для Xamarin классы, пространства имён, логика и поведение максимально приближены к версии .NET. Вы можете перенести свои приложения Aspose.Slides .NET в Xamarin с минимальными затратами.

## **Быстрый пример**
Вы можете использовать Aspose.Slides для Xamarin, чтобы создавать и использовать своё приложение C# через Slides for Android.

Мы предоставляем пример Android‑приложения на Xamarin, которое использует Aspose.Slides для отображения слайдов презентации и добавления новой фигуры по касанию. Полный исходный код примеров доступен на [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Xamarin).

Начнём с создания Xamarin Android App:

![todo:image_alt_text](https://lh3.googleusercontent.com/sNkKZnuuGo8phWI-4g4jRA_ZESKpO9RXehPj46RVymXGPcCJuYooePXcBEcb7N6uUUxgocl4o9OjwnajzWKmL2i4MUz3gKKwXw6C0ow_VScN8vlyGBK3SpLKoE_m9BDJ3iNE4xPj)

Сначала создадим макет содержимого, который будет включать ImageView, кнопки Prev и Next:

![todo:image_alt_text](https://lh3.googleusercontent.com/rX9leIvYTVzQa0YAMj_jPUPs-c9_HwGPZUfR5A3FLiTk0-qzUQ29FfM4hammUVXbbw_Ly0LwEM_VnaI6vslEEMcVlEwVMem0LTiX5kYsA4lxtiHrvXfDPruWPOGU1YKDYSWcNM54)

**XML - content_main.xml - Создание макета содержимого**
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

Здесь мы подключаем библиотеку «Aspose.Slides.Droid.dll», содержащую образец презентации («HelloWorld.pptx»), в Assets Xamarin‑приложения и добавляем её инициализацию в MainActivity:

**C# - MainActivity.cs - Инициализация**

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

Добавим функцию отображения слайдов Prev и Next по нажатию кнопок:

**C# - MainActivity.cs - Отображение слайдов по нажатию кнопок Prev и Next**

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

Наконец, реализуем функцию добавления эллипса при касании слайда:

**C# - MainActivity.cs - Добавление эллипса по нажатию на слайд**

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

Каждое нажатие по слайду презентации приводит к добавлению эллипса случайного цвета:

![todo:image_alt_text](https://lh4.googleusercontent.com/RhjFHm6SgzOkXaehKhsY8q7SRZLFC7vV8_jyw-Gy4Scy68wTMg_apLZ3vPzRLOt1eEw_zUZmLlVhJ8oTGCg10dRNAETLSClRTBEyj2MWuefNpJI4i7WLIe0x8A7xuh4CV91loLKi)


## **Поддерживаемые функции**

|**ФУНКЦИИ**|**Aspose.Slides for .NET**|**Aspose.Slides for Xamarin**|
| :- | :- | :- |
|**Возможности презентаций**:| | |
|Создание новых презентаций|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Открытие/сохранение форматов PowerPoint 97‑2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Открытие/сохранение форматов PowerPoint 2007|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Поддержка расширений PowerPoint 2010|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Поддержка расширений PowerPoint 2013|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Поддержка функций PowerPoint 2016|restricted|restricted|
|Поддержка функций PowerPoint 2019|restricted|restricted|
|Конвертация PPT в PPTX|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Конвертация PPTX в PPT|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Вставка PPTX в PPT|restricted|restricted|
|Обработка тем|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Обработка макросов|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Обработка свойств документа|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Защита паролем|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Быстрое извлечение текста|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Встраивание шрифтов|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Отображение комментариев|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Прерывание длительных задач|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Форматы экспорта:**| | |
|PDF|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|XPS|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|HTML|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|TIFF|{{< emoticons/tick >}}|{{< emoticons/cross >}}|
|ODP|restricted|restricted|
|SWF|restricted|restricted|
|SVG|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Форматы импорта:**| | |
|HTML|restricted|restricted|
|ODP|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|THMX|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Функции мастер‑слайдов:**| | |
|Доступ ко всем существующим мастер‑слайдам|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Создание/удаление мастер‑слайдов|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Клонирование мастер‑слайдов|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Функции макетов слайдов:**| | |
|Доступ ко всем существующим макетам слайдов|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Создание/удаление макетов слайдов|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Клонирование макетов слайдов|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Функции слайдов:**| | |
|Доступ ко всем существующим слайдам|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Создание/удаление слайдов|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Клонирование слайдов|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Экспорт слайдов в изображения|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Создание/редактирование/удаление разделов слайдов|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Функции слайдов заметок**:| | |
|Доступ ко всем существующим слайдам заметок|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Текстовые функции:**| | |
|Форматирование абзацев|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Форматирование частей|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Функции фигур:**| | |
|Доступ ко всем фигурам слайда|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Добавление новых фигур|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Клонирование фигур|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Экспорт отдельных фигур в изображения|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Поддерживаемые типы фигур:**| | |
|Все предопределённые типы фигур|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Картинные рамки|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Таблицы|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Диаграммы|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|SmartArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Устарые диаграммы|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|WordArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|OLE, объекты ActiveX|restricted|restricted|
|Видеокадры|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Аудиокадры|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Соединители|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Функции групповых фигур:**| | |
|Доступ к групповым фигурам|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Создание групповых фигур|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Разгруппировка существующих групповых фигур|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Функции эффектов фигур:**| | |
|2D‑эффекты|restricted|restricted|
|3D‑эффекты|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|**Функции анимации:**| | |
|Экспорт анимации в SWF|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|Экспорт анимации в HTML|{{< emoticons/cross >}}|{{< emoticons/cross >}}|