---
title: 프레젠테이션 인쇄
type: docs
url: /ko/net/print-the-presentation/
---
Aspose.Slides for .NET은 프레젠테이션 인쇄를 위한 네 가지 오버로드 메서드를 제공합니다. 이러한 메서드는 기본 프린터 또는 사용자 지정 설정이 가능한 모든 사용 가능한 프린터에 프레젠테이션을 인쇄할 수 있을 만큼 유연합니다. 요구 사항에 따라 적절한 인쇄 메서드만 선택하면 됩니다.
## **기본 프린터에 인쇄**
Aspose.Slides for .NET에서 프레젠테이션을 기본 프린터에 인쇄하는 것은 매우 간단합니다. 프레젠테이션을 기본 프린터에 인쇄하려면 다음 단계를 수행하십시오:

- 인쇄할 프레젠테이션을 로드하기 위해 Presentation 클래스의 인스턴스를 생성합니다.
- Presentation 객체에서 제공되는 매개변수가 없는 Print 메서드를 호출합니다.

``` csharp

 PrintByDefaultPrinter();

    PrintBySpecificPrinter();

}

public static void PrintByDefaultPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //프레젠테이션 로드

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //전체 프레젠테이션을 기본 프린터에 인쇄하기 위해 print 메서드 호출

    asposePresentation.Print();

}

public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //프레젠테이션 로드

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //전체 프레젠테이션을 원하는 프린터에 인쇄하기 위해 print 메서드 호출

    asposePresentation.Print("LaserJet1100");


``` 
## **특정 프린터에 인쇄**
프레젠테이션을 특정 프린터에 인쇄하려면 프린터 이름을 Presentation의 Print 메서드에 매개변수로 전달해야 합니다. 원하는 프린터에 프레젠테이션을 인쇄하려면 다음 단계를 수행하십시오:

- 인쇄할 프레젠테이션을 로드하기 위해 Presentation 클래스의 인스턴스를 생성합니다.
- 프린터 이름을 문자열 매개변수로 전달하여 Presentation 클래스의 Print 메서드를 호출합니다.

``` csharp

 public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //프레젠테이션 로드

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //전체 프레젠테이션을 원하는 프린터에 인쇄하기 위해 print 메서드 호출

    asposePresentation.Print("LaserJet1100");

}

``` 
## **샘플 코드 다운로드**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Print%20Presentation%20%28Aspose.Slides%29.zip)