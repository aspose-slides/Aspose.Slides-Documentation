---
title: Aspose.Slides для Xamarin
type: docs
weight: 150
url: /ru/net/aspose-slides-for-xamarin/
---

## **Обзор**
Xamarin — это фреймворк, используемый для мобильной разработки на .NET C#. Xamarin предлагает инструменты и библиотеки, которые расширяют возможности платформы .NET. Он позволяет разработчикам создавать приложения для операционной системы **Android**.

{{% alert color="primary" %}} 

Для разработки в Xamarin программисты могут использовать свои привычные среды разработки (C#, Visual Studio и сторонние библиотеки).

{{% /alert %}}

API Aspose.Slides работает на платформе Xamarin. Для этого пакет Aspose.Slides .NET добавляет отдельную DLL для Xamarin. Aspose.Slides для Xamarin поддерживает большинство функций, доступных в версии .NET:

- конвертация и просмотр презентаций.
- редактирование содержимого в презентациях: текст, фигуры, диаграммы, SmartArt, аудио/видео, шрифты и т. д.
- работа с анимацией, 2D-эффектами, WordArt и т. д.
- работа с метаданными и свойствами документа.
- печать, клонирование, слияние, сравнение, разбивка и т. д.

Мы предоставили сравнение всех функций в другом разделе, близком к нижней части этой страницы.

В API Aspose.Slides для Xamarin классы, пространства имен, логика и поведение максимально схожи с версией .NET. Вы можете мигрировать свои приложения Aspose.Slides .NET на Xamarin с минимальными затратами.

## **Быстрый пример**
Вы можете использовать Aspose.Slides для Xamarin для создания и использования своего C# приложения через Slides для Android.

Мы предоставляем пример Android-приложения через Xamarin, которое использует Aspose.Slides для отображения слайдов презентации и добавляет новую фигуру на слайд при касании. Полный исходный код примеров можно найти на [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Xamarin).

Давайте начнем с создания Xamarin Android-приложения:

![todo:image_alt_text](https://lh3.googleusercontent.com/sNkKZnuuGo8phWI-4g4jRA_ZESKpO9RXehPj46RVymXGPcCJuYooePXcBEcb7N6uUUxgocl4o9OjwnajzWKmL2i4MUz3gKKwXw6C0ow_VScN8vlyGBK3SpLKoE_m9BDJ3iNE4xPj)

Сначала мы создаем контентный макет, который будет содержать изображение, кнопки "Prev" и "Next":

![todo:image_alt_text](https://lh3.googleusercontent.com/rX9leIvYTVzQa0YAMj_jPUPs-c9_HwGPZUfR5A3FLiTk0-qzUQ29FfM4hammUVXbbw_Ly0LwEM_VnaI6vslEEMcVlEwVMem0LTiX5kYsA4lxtiHrvXfDPruWPOGU1YKDYSWcNM54)



**XML - content_main.xml - Создание контентного макета**
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



Здесь мы ссылаемся на библиотеку "Aspose.Slides.Droid.dll", которая включает в себя образец презентации ("HelloWorld.pptx") в Ассеты приложения Xamarin и добавляет инициализацию в MainActivity:

**C# - MainActivity.cs - Инициализация**

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

Давайте добавим функцию отображения предыдущих и следующих слайдов при нажатии кнопок:

**C# - MainActivity.cs - Отображение слайдов при нажатии кнопки Prev и Next**

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



Наконец, давайте реализуем функцию добавления эллипса при касании слайда:

**C# - MainActivity.cs - Добавление эллипса при нажатии на слайд**

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

Каждое нажатие на слайд презентации приводит к добавлению эллипса случайного цвета:

![todo:image_alt_text](https://lh4.googleusercontent.com/RhjFHm6SgzOkXaehKhsY8q7SRZLFC7vV8_jyw-Gy4Scy68wTMg_apLZ3vPzRLOt1eEw_zUZmLlVhJ8oTGCg10dRNAETLSClRTBEyj2MWuefNpJI4i7WLIe0x8A7xuh4CV91loLKi)


## **Поддерживаемые функции**

|**ФУНКЦИИ** |**Aspose.Slides для .NET**  |**Aspose.Slides для Xamarin**|
| :- | :- | :- |
|**Функции презентации**: | | |
|Создание новых презентаций |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Открытие/сохранение форматов PowerPoint 97 - 2003 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Открытие/сохранение форматов PowerPoint 2007 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Поддержка расширений PowerPoint 2010 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Поддержка расширений PowerPoint 2013 |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Поддержка функций PowerPoint 2016 |ограничена|ограничена|
|Поддержка функций PowerPoint 2019 |ограничена |ограничена|
|Конвертация PPT в PPTX |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Конвертация PPTX в PPT |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTX в PPT |ограничена|ограничена|
|Обработка тем |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Обработка макросов |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Обработка свойств документа |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Защита паролем |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Быстрое извлечение текста |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Встраивание шрифтов |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Отображение комментариев |{{< emoticons/tick >}} |{{< emoticons/tick >}}|
|Прерывание долгих задач |{{< emoticons/tick >}}|{{< emoticons/tick >}} |
|**Форматы экспорта:** | | |
|PDF |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|XPS |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|HTML |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|TIFF |{{< emoticons/tick >}}|{{< emoticons/cross >}}|
|ODP |ограничена |ограничена|
|SWF |ограничена|ограничена|
|SVG |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Форматы импорта:** | | |
|HTML |ограничена|ограничена|
|ODP |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|THMX |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Функции главных слайдов:** | | |
|Доступ ко всем существующим главным слайдам |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Создание/удаление главных слайдов |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Клонирование главных слайдов |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Функции макетов слайдов:** | | |
|Доступ ко всем существующим макетам слайдов |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Создание/удаление макетов слайдов |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Клонирование макетов слайдов |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Функции слайдов:** | | |
|Доступ ко всем существующим слайдам |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Создание/удаление слайдов |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Клонирование слайдов |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Экспорт слайдов в изображения |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Создание/редактирование/удаление секций слайдов |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Функции слайдов заметок:** | | |
|Доступ ко всем существующим слайдам заметок |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Функции фигур:** | | |
|Доступ ко всем фигурам слайдов |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Добавление новых фигур |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Клонирование фигур |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Экспорт отдельных фигур в изображения |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Поддерживаемые типы фигур:** | | |
|Все предопределенные типы фигур |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Рамки изображений |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Таблицы |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Диаграммы |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|SmartArt |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Устаревшие диаграммы |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|WordArt |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|OLE, объекты ActiveX |ограничена|ограничена|
|Кадры видео |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Кадры аудио |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Соединители |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Функции групповых фигур:** | | |
|Доступ к группам фигур |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Создание групп фигур |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Разгруппировка существующих групп фигур |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Эффекты фигур:** | | |
|2D-эффекты |ограничена|ограничена|
|3D-эффекты |{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|**Текстовые функции:** | | |
|Форматирование параграфов |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Форматирование частей текста |{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Анимационные функции:** | | |
|Экспорт анимации в SWF |{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|Экспорт анимации в HTML |{{< emoticons/cross >}}|{{< emoticons/cross >}}|