---
title: 슬라이드 조립
type: docs
weight: 10
url: /ko/net/assemble-slides/
---
## **프레젠테이션에 슬라이드 추가**
프레젠테이션 파일에 슬라이드를 추가하는 것에 대해 이야기하기 전에, 슬라이드에 대한 몇 가지 사실을 논의해 보겠습니다. 각 PowerPoint 프레젠테이션 파일에는 마스터/레이아웃 슬라이드와 기타 일반 슬라이드가 포함됩니다. 이는 프레젠테이션 파일에 하나 이상의 슬라이드가 포함되어 있음을 의미합니다. 슬라이드가 없는 프레젠테이션 파일은 Aspose.Slides for .NET에서 지원되지 않는다는 점을 알아두는 것이 중요합니다. 각 슬라이드에는 고유한 Id가 있으며 모든 일반 슬라이드는 0 기반 인덱스로 지정된 순서대로 배열됩니다.

Aspose.Slides for .NET은 개발자가 프레젠테이션에 빈 슬라이드를 추가할 수 있도록 합니다. 프레젠테이션에 빈 슬라이드를 추가하려면 아래 단계를 따르세요:

- Presentation 클래스의 인스턴스를 생성합니다
- Presentation 객체가 노출하는 Slides(콘텐츠 Slide 객체의 컬렉션) 속성에 대한 참조를 설정하여 **SlideCollection** 클래스를 인스턴스화합니다.
- **SlideCollection** 객체가 노출하는 **AddEmptySlide** 메서드를 호출하여 콘텐츠 슬라이드 컬렉션 끝에 빈 슬라이드를 프레젠테이션에 추가합니다
- 새로 추가된 빈 슬라이드로 작업을 수행합니다
- 마지막으로 **Presentation** 객체를 사용하여 프레젠테이션 파일을 저장합니다

``` csharp

 PresentationEx pres = new PresentationEx();

//SlideCollection 클래스를 인스턴스화합니다

SlideExCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)

{

	//Slides 컬렉션에 빈 슬라이드를 추가합니다

	slds.AddEmptySlide(pres.LayoutSlides[i]);

}

//PPTX 파일을 디스크에 저장합니다

pres.Write("EmptySlide.pptx");

``` 
## **프레젠테이션 슬라이드에 액세스하기**
Aspose.Slides for .NET은 프레젠테이션에 존재하는 원하는 슬라이드를 찾고 액세스하는 데 사용할 수 있는 Presentation 클래스를 제공합니다.

**슬라이드 컬렉션 사용**

Presentation 클래스는 프레젠테이션 파일을 나타내며, 모든 슬라이드를 **SlideCollection** 컬렉션(**Slide** 객체 컬렉션)으로 노출합니다. 이러한 모든 슬라이드는 슬라이드 인덱스를 사용하여 **Slides** 컬렉션에서 액세스할 수 있습니다.

``` csharp

 //프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다
PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

//슬라이드 인덱스를 사용하여 슬라이드에 접근합니다
SlideEx slide = pres.Slides[0];

``` 
## **슬라이드 제거**
**Aspose.Slides for .NET**의 Presentation 클래스가 프레젠테이션 파일을 나타낸다는 것을 알고 있습니다. Presentation 클래스는 프레젠테이션의 모든 슬라이드가 포함된 저장소 역할을 하는 **SlideCollection**을 캡슐화합니다. 개발자는 이 Slides 컬렉션에서 슬라이드를 두 가지 방법으로 제거할 수 있습니다:

- 슬라이드 참조 사용
- 슬라이드 인덱스 사용

**슬라이드 참조 사용**

슬라이드 참조를 사용하여 슬라이드를 제거하려면 아래 단계를 따르세요:

- Presentation 클래스의 인스턴스를 생성합니다
- Id 또는 Index를 사용하여 슬라이드의 참조를 얻습니다
- 프레젠테이션에서 참조된 슬라이드를 제거합니다
- 수정된 프레젠테이션 파일을 저장합니다

``` csharp

 //프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다
PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

//슬라이드 컬렉션에서 인덱스를 사용하여 슬라이드에 접근합니다
SlideEx slide = pres.Slides[0];

//참조를 사용하여 슬라이드를 제거합니다
pres.Slides.Remove(slide);

//프레젠테이션 파일을 저장합니다
pres.Write("modified.pptx");

``` 
## **슬라이드 위치 변경**
프레젠테이션에서 슬라이드의 위치를 변경하는 것은 매우 간단합니다. 아래 단계를 따르세요:

- Presentation 클래스의 인스턴스를 생성합니다
- Index를 사용하여 슬라이드의 참조를 얻습니다
- 참조된 슬라이드의 SlideNumber를 변경합니다
- 수정된 프레젠테이션 파일을 저장합니다

아래 예제에서는 프레젠테이션의 슬라이드(0 인덱스 위치 1에 있던)를 인덱스 1(위치 2)으로 변경했습니다.

``` csharp

 private static string MyDir = @"..\..\..\Sample Files\";

static void Main(string[] args)

{

AddingSlidetoPresentation();

AccessingSlidesOfPresentation();

RemovingSlides();

ChangingPositionOfSlide();

}

public static void AddingSlidetoPresentation()

{

Presentation pres = new Presentation();

//SlideCollection 클래스를 인스턴스화합니다
ISlideCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)

{

    //Slides 컬렉션에 빈 슬라이드를 추가합니다
    slds.AddEmptySlide(pres.LayoutSlides[i]);

}

//PPTX 파일을 디스크에 저장합니다
pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

public static void AccessingSlidesOfPresentation()

{

//프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다
Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

//슬라이드 인덱스를 사용하여 슬라이드에 접근합니다
ISlide slide = pres.Slides[0];

}

public static void RemovingSlides()

{

//프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다
Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

//슬라이드 컬렉션에서 인덱스를 사용하여 슬라이드에 접근합니다
ISlide slide = pres.Slides[0];

//참조를 사용하여 슬라이드를 제거합니다
pres.Slides.Remove(slide);

//프레젠테이션 파일을 저장합니다
pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

public static void ChangingPositionOfSlide()

{

//소스 프레젠테이션 파일을 로드하기 위해 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

{

    //위치를 변경할 슬라이드를 가져옵니다
    ISlide sld = pres.Slides[0];

    //슬라이드의 새로운 위치를 설정합니다
    sld.SlideNumber = 2;

    //프레젠테이션을 디스크에 저장합니다
    pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);
}

}
``` 
## **샘플 코드 다운로드**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Assemble%20Slides%20%28Aspose.Slides%29.zip)