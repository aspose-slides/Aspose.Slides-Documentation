---
title: Xamarin용 Aspose.Slides
type: docs
weight: 150
url: /ko/net/aspose-slides-for-xamarin/
keywords:
- Xamarin
- 모바일 개발
- Android
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides를 사용하여 C#로 Xamarin 모바일 앱을 구축하고, Android에서 PPT, PPTX 및 ODP에 대한 풍부한 기능을 지원하며 프레젠테이션을 보기, 편집 및 변환합니다."
---
## **소개**

Xamarin은 .NET C#에서 모바일 개발에 사용되는 프레임워크입니다. Xamarin은 .NET 플랫폼의 기능을 확장하는 도구와 라이브러리를 제공합니다. 이를 통해 개발자는 **Android** 운영 체제용 애플리케이션을 빌드할 수 있습니다.

{{% alert color="primary" %}} 

Xamarin에서 개발할 때, 프로그래머는 기존 개발 환경(C#, Visual Studio, 및 서드 파티 라이브러리)을 그대로 사용할 수 있습니다.

{{% /alert %}}

Aspose.Slides API는 Xamarin 플랫폼에서 작동합니다. 이를 위해 Aspose.Slides .NET 패키지는 Xamarin용 별도 DLL을 추가합니다. Aspose.Slides for Xamarin은 .NET 버전에서 제공되는 대부분의 기능을 지원합니다:

- 프레젠테이션 변환 및 보기
- 프레젠테이션 내용 편집: 텍스트, 도형, 차트, SmartArt, 오디오/비디오, 글꼴 등
- 애니메이션, 2D 효과, WordArt 등 처리
- 메타데이터 및 문서 속성 처리
- 인쇄, 복제, 병합, 비교, 분할 등

전체 기능 비교는 이 페이지 하단의 별도 섹션에서 제공합니다.

Aspose.Slides for Xamarin API의 클래스, 네임스페이스, 로직 및 동작은 .NET 버전과 가능한 한 동일합니다. 최소한의 비용으로 Aspose.Slides .NET 애플리케이션을 Xamarin으로 마이그레이션할 수 있습니다.


## **빠른 예제**
Aspose.Slides for Xamarin을 사용하면 Slides for Android을 통해 C# 애플리케이션을 빌드하고 활용할 수 있습니다.

우리는 Android용 Xamarin 애플리케이션 예제를 제공합니다. 이 예제는 Aspose.Slides를 사용해 프레젠테이션 슬라이드를 표시하고 터치 시 슬라이드에 새 도형을 추가합니다. 전체 예제 소스는 [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Xamarin)에서 확인할 수 있습니다.

Xamarin Android 앱을 생성해 보겠습니다:

![todo:image_alt_text](https://lh3.googleusercontent.com/sNkKZnuuGo8phWI-4g4jRA_ZESKpO9RXehPj46RVymXGPcCJuYooePXcBEcb7N6uUUxgocl4o9OjwnajzWKmL2i4MUz3gKKwXw6C0ow_VScN8vlyGBK3SpLKoE_m9BDJ3iNE4xPj)

먼저 이미지 뷰, Prev 및 Next 버튼을 포함할 콘텐츠 레이아웃을 만듭니다:

![todo:image_alt_text](https://lh3.googleusercontent.com/rX9leIvYTVzQa0YAMj_jPUPs-c9_HwGPZUfR5A3FLiTk0-qzUQ29FfM4hammUVXbbw_Ly0LwEM_VnaI6vslEEMcVlEwVMem0LTiX5kYsA4lxtiHrvXfDPruWPOGU1YKDYSWcNM54)



**XML - content_main.xml - 콘텐츠 레이아웃 만들기**
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



여기서는 Xamarin 애플리케이션 Assets에 샘플 프레젠테이션("HelloWorld.pptx")을 포함하고 "Aspose.Slides.Droid.dll" 라이브러리를 참조한 뒤 MainActivity에 초기화를 추가합니다:

**C# - MainActivity.cs - 초기화**

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

Prev 및 Next 버튼 클릭 시 슬라이드를 표시하는 함수를 추가해 보겠습니다:

**C# - MainActivity.cs - Prev 및 Next 버튼 클릭 시 슬라이드 표시**

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



마지막으로 슬라이드 터치 시 타원 도형을 추가하는 함수를 구현합니다:

**C# - MainActivity.cs - 슬라이드 클릭 시 타원 추가**

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

프레젠테이션 슬라이드를 클릭할 때마다 무작위 색상의 타원이 추가됩니다:

![todo:image_alt_text](https://lh4.googleusercontent.com/RhjFHm6SgzOkXaehKhsY8q7SRZLFC7vV8_jyw-Gy4Scy68wTMg_apLZ3vPzRLOt1eEw_zUZmLlVhJ8oTGCg10dRNAETLSClRTBEyj2MWuefNpJI4i7WLIe0x8A7xuh4CV91loLKi)


## **지원 기능**

|**기능**|**Aspose.Slides for .NET**|**Aspose.Slides for Xamarin**|
| :- | :- | :- |
|**프레젠테이션 기능:**| | |
|새 프레젠테이션 만들기|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 97‑2003 형식 열기/저장|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2007 형식 열기/저장|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2010 확장 지원|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2013 확장 지원|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PowerPoint 2016 기능 지원|restricted|restricted|
|PowerPoint 2019 기능 지원|restricted|restricted|
|PPT → PPTX 변환|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTX → PPT 변환|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPT 내 PPTX|restricted|restricted|
|테마 처리|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|매크로 처리|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|문서 속성 처리|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|비밀번호 보호|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|빠른 텍스트 추출|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|폰트 포함|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|주석 렌더링|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|장기 실행 작업 중단|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**내보내기 형식:**| | |
|PDF|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|XPS|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|HTML|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|TIFF|{{< emoticons/tick >}}|{{< emoticons/cross >}}|
|ODP|restricted|restricted|
|SWF|restricted|restricted|
|SVG|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**가져오기 형식:**| | |
|HTML|restricted|restricted|
|ODP|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|THMX|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**마스터 슬라이드 기능:**| | |
|전체 기존 마스터 슬라이드 접근|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|마스터 슬라이드 생성/제거|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|마스터 슬라이드 복제|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**레이아웃 슬라이드 기능:**| | |
|전체 기존 레이아웃 슬라이드 접근|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|레이아웃 슬라이드 생성/제거|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|레이아웃 슬라이드 복제|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**슬라이드 기능:**| | |
|전체 기존 슬라이드 접근|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|슬라이드 생성/제거|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|슬라이드 복제|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|슬라이드 이미지로 내보내기|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|슬라이드 섹션 생성/편집/제거|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**노트 슬라이드 기능:**| | |
|전체 기존 노트 슬라이드 접근|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**도형 기능:**| | |
|전체 슬라이드 도형 접근|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|새 도형 추가|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|도형 복제|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|도형을 별도 이미지로 내보내기|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**지원되는 도형 유형:**| | |
|모든 사전 정의 도형 유형|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|그림 프레임|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|표|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|차트|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|SmartArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|레거시 다이어그램|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|WordArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|OLE, ActiveX 개체|restricted|restricted|
|비디오 프레임|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|오디오 프레임|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|연결선|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**그룹 도형 기능:**| | |
|그룹 도형 접근|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|그룹 도형 생성|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|기존 그룹 도형 그룹 해제|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**도형 효과 기능:**| | |
|2D 효과|restricted|restricted|
|3D 효과|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|**텍스트 기능:**| | |
|문단 서식|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|구간 서식|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**애니메이션 기능:**| | |
|애니메이션을 SWF로 내보내기|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|애니메이션을 HTML로 내보내기|{{< emoticons/cross >}}|{{< emoticons/cross >}}|