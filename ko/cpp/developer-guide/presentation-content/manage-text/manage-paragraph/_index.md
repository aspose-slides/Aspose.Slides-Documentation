---
title: C++에서 PowerPoint 텍스트 단락 관리
linktitle: 단락 관리
type: docs
weight: 40
url: /ko/cpp/manage-paragraph/
keywords:
- 텍스트 추가
- 단락 추가
- 텍스트 관리
- 단락 관리
- 글머리 기호 관리
- 단락 들여쓰기
- 매달린 들여쓰기
- 단락 글머리 기호
- 번호 매기기 목록
- 글머리 기호 목록
- 단락 속성
- HTML 가져오기
- 텍스트를 HTML로
- 단락을 HTML로
- 단락을 이미지로
- 텍스트를 이미지로
- 단락 내보내기
- 파워포인트
- 오픈문서
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++로 단락 서식을 마스터하고, PPT, PPTX 및 ODP 프레젠테이션에서 정렬, 간격 및 스타일을 최적화합니다."
---
## **소개**

Aspose.Slides는 C++에서 PowerPoint 텍스트, 단락 및 구문을 작업하는 데 필요한 모든 인터페이스와 클래스를 제공합니다.

* Aspose.Slides는 단락을 나타내는 개체를 추가할 수 있도록 [ITextFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframe/) 인터페이스를 제공합니다. `ITextFame` 객체는 하나 또는 여러 개의 단락을 가질 수 있습니다(각 단락은 캐리지 리턴을 통해 생성됨).
* Aspose.Slides는 구문을 나타내는 개체를 추가할 수 있도록 [IParagraph](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraph/) 인터페이스를 제공합니다. `IParagraph` 객체는 하나 또는 여러 개의 구문을 가질 수 있습니다(iPortions 객체의 컬렉션).
* Aspose.Slides는 텍스트와 해당 서식 속성을 나타내는 개체를 추가할 수 있도록 [IPortion](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iportion/) 인터페이스를 제공합니다.

`IParagraph` 객체는 기본 `IPortion` 객체를 통해 다양한 서식 속성을 가진 텍스트를 처리할 수 있습니다.

## **다중 구문을 포함하는 여러 단락 추가**

다음 단계에서는 3개의 단락을 포함하고 각 단락이 3개의 구문을 포함하는 텍스트 프레임을 추가하는 방법을 보여줍니다:

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 해당 슬라이드의 참조에 접근합니다.
3. 슬라이드에 사각형 [IAutoShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iautoshape/)을 추가합니다.
4. [IAutoShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iautoshape/)와 연결된 ITextFrame을 가져옵니다.
5. 두 개의 [IParagraph](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraph/) 객체를 생성하고 이를 [ITextFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframe/)의 `IParagraphs` 컬렉션에 추가합니다.
6. 각 새 `IParagraph`에 대해 세 개의 [IPortion](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iportion/) 객체를 생성하고(기본 단락에 대해 두 개의 Portion 객체) 각 `IPortion` 객체를 해당 `IParagraph`의 IPortion 컬렉션에 추가합니다.
7. 각 구문에 텍스트를 설정합니다.
8. `IPortion` 객체가 제공하는 서식 속성을 사용하여 각 구문에 원하는 서식 기능을 적용합니다.
9. 수정된 프레젠테이션을 저장합니다.

다음 C++ 코드는 구문을 포함하는 단락을 추가하는 단계의 구현 예시입니다: 

```c++
// 문서 디렉터리 경로.
const String outPath = u"../out/MultipleParagraphs_out.pptx";



// 원하는 프레젠테이션을 로드합니다
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 첫 번째 슬라이드에 접근합니다
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// 사각형 유형의 AutoShape을 추가합니다
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// 사각형에 TextFrame을 추가합니다
SharedPtr<ITextFrame> tf=ashp->AddTextFrame(u" ");


// 첫 번째 단락에 접근합니다
SharedPtr<IParagraph> para0 = tf->get_Paragraphs()->idx_get(0);
	
SharedPtr<Portion> port01 = MakeObject<Portion>();
SharedPtr<Portion> port02 = MakeObject<Portion>();
para0->get_Portions()->Add(port01);
para0->get_Portions()->Add(port02);

// 두 번째 단락을 추가합니다
SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
tf->get_Paragraphs()->Add(para1);
SharedPtr<Portion> port10 = MakeObject<Portion>();
SharedPtr<Portion> port11 = MakeObject<Portion>();
SharedPtr<Portion> port12 = MakeObject<Portion>();
para1->get_Portions()->Add(port10);
para1->get_Portions()->Add(port11);
para1->get_Portions()->Add(port12);

// 세 번째 단락을 추가합니다
SharedPtr<Paragraph> para2 = MakeObject<Paragraph>();
tf->get_Paragraphs()->Add(para2);
SharedPtr<Portion> port20 = MakeObject<Portion>();
SharedPtr<Portion> port21 = MakeObject<Portion>();
SharedPtr<Portion> port22 = MakeObject<Portion>();
para2->get_Portions()->Add(port20);
para2->get_Portions()->Add(port21);
para2->get_Portions()->Add(port22);


for (int i = 0; i < 3; i++)
{
	for (int j = 0; j < 3; j++)
	{
		tf->get_Paragraphs()->idx_get(i)->get_Portions()->idx_get(j)->set_Text(u"Portion_"+j);
		SharedPtr<IPortionFormat>format = tf->get_Paragraphs()->idx_get(i)->get_Portions()->idx_get(j)->get_PortionFormat();

		if (j == 0)
		{
			format->get_FillFormat()->set_FillType(FillType::Solid);
			format->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
			format->set_FontBold(NullableBool::True);
			format->set_FontHeight(15);
		}
		else if (j == 1)
		{
			format->get_FillFormat()->set_FillType(FillType::Solid);
			format->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
			format->set_FontBold(NullableBool::True);
			format->set_FontHeight(18);
		}
	}

}

// PPTX를 디스크에 저장합니다
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **단락 글머리 기호 관리**

글머리 기호 목록은 정보를 빠르고 효율적으로 조직하고 제시하는 데 도움이 됩니다. 글머리 기호가 있는 단락은 항상 읽고 이해하기가 더 쉽습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 해당 슬라이드의 참조에 접근합니다.
3. 선택한 슬라이드에 [autoshape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iautoshape/)을 추가합니다.
4. autoshape의 [TextFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframe/)에 접근합니다.
5. `TextFrame`의 기본 단락을 제거합니다.
6. [Paragraph](https://reference.aspose.com/slides/ko/cpp/aspose.slides/paragraph/) 클래스를 사용하여 첫 번째 단락 인스턴스를 생성합니다.
7. 단락의 글머리 기호 `Type`을 `Symbol`로 설정하고 글머리 기호 문자를 지정합니다.
8. 단락의 `Text`를 설정합니다.
9. 글머리 기호에 대한 단락 `Indent`를 설정합니다.
10. 글머리 기호의 색상을 설정합니다.
11. 글머리 기호의 높이를 설정합니다.
12. 새 단락을 `TextFrame`의 단락 컬렉션에 추가합니다.
13. 두 번째 단락을 추가하고 7~13단계의 과정을 반복합니다.
14. 프레젠테이션을 저장합니다.

다음 C++ 코드는 단락 글머리 기호를 추가하는 방법을 보여줍니다: 

```c++
// 문서 디렉터리 경로.
const String outPath = u"../out/ParagraphBullets_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// 원하는 프레젠테이션을 로드합니다
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 첫 번째 슬라이드에 접근합니다
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// 사각형 유형의 AutoShape을 추가합니다
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// 사각형에 TextFrame을 추가합니다
ashp->AddTextFrame(u"");

// 텍스트 프레임에 접근합니다
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();
txtFrame->get_Paragraphs()->Clear();

// 텍스트 프레임을 위한 Paragraph 객체를 생성합니다
SharedPtr<Paragraph> paragraph = MakeObject<Paragraph>();

//텍스트 설정
paragraph->set_Text(u"Welcome to Aspose.Slides");

// 글머리 들여쓰기 설정
paragraph->get_ParagraphFormat()->set_Indent (25);

// 글머리 색상 설정
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType ( ColorType::RGB);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
	
// IsBulletHardColor를 true로 설정하여 사용자 정의 글머리 색상을 사용합니다
paragraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True); 
																					
// 글머리 높이 설정
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// Paragraph를 텍스트 프레임에 추가합니다
txtFrame->get_Paragraphs()->Add(paragraph);

// 두 번째 단락 만들기
// 텍스트 프레임을 위한 Paragraph 객체를 생성합니다
SharedPtr<Paragraph> paragraph2 = MakeObject<Paragraph>();

//텍스트 설정
paragraph2->set_Text(u"This is numbered bullet");

// 단락 글머리 유형 및 스타일 설정
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Type ( BulletType::Numbered);
paragraph2->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStyle ( NumberedBulletStyle::BulletCircleNumWDBlackPlain);

// 글머리 들여쓰기 설정
paragraph2->get_ParagraphFormat()->set_Indent(25);

// 글머리 색상 설정
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());

// IsBulletHardColor를 true로 설정하여 사용자 정의 글머리 색상을 사용합니다
paragraph2->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);

// 글머리 높이 설정
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// Paragraph를 텍스트 프레임에 추가합니다
txtFrame->get_Paragraphs()->Add(paragraph2);


// PPTX를 디스크에 저장합니다
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **그림 글머리 기호 관리**

글머리 기호 목록은 정보를 빠르고 효율적으로 조직하고 제시하는 데 도움이 됩니다. 그림 단락은 읽고 이해하기 쉽습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 해당 슬라이드의 참조에 접근합니다.
3. 슬라이드에 [autoshape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iautoshape/)을 추가합니다.
4. autoshape의 [TextFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframe/)에 접근합니다.
5. `TextFrame`의 기본 단락을 제거합니다.
6. [Paragraph](https://reference.aspose.com/slides/ko/cpp/aspose.slides/paragraph/) 클래스를 사용하여 첫 번째 단락 인스턴스를 생성합니다.
7. [IPPImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ippimage/)에서 이미지를 로드합니다.
8. 글머리 기호 유형을 [Picture](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ippimage/)로 설정하고 이미지를 지정합니다.
9. Paragraph의 `Text`를 설정합니다.
10. 글머리 기호에 대한 Paragraph `Indent`를 설정합니다.
11. 글머리 기호의 색상을 설정합니다.
12. 글머리 기호의 높이를 설정합니다.
13. 새 단락을 `TextFrame`의 단락 컬렉션에 추가합니다.
14. 두 번째 단락을 추가하고 앞 단계들을 기반으로 과정을 반복합니다.
15. 수정된 프레젠테이션을 저장합니다.

다음 C++ 코드는 그림 글머리 기호를 추가하고 관리하는 방법을 보여줍니다: 

```c++
// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

// 첫 번째 슬라이드에 접근합니다
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// 글머리 기호용 이미지를 인스턴스화합니다
System::SharedPtr<IImage> image = Images::FromFile(u"bullets.png");
System::SharedPtr<IPPImage> ippxImage = presentation->get_Images()->AddImage(image);

// AutoShape을 추가하고 접근합니다
System::SharedPtr<IAutoShape> autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// AutoShape 텍스트 프레임에 접근합니다
System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();

// 기본 단락을 제거합니다
System::SharedPtr<IParagraphCollection> paragraphs = textFrame->get_Paragraphs();
paragraphs->RemoveAt(0);

// 새 단락을 생성합니다
System::SharedPtr<Paragraph> paragraph = System::MakeObject<Paragraph>();
paragraph->set_Text(u"Welcome to Aspose.Slides");

// 단락 글머리 스타일 및 이미지를 설정합니다
paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Picture);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Picture()->set_Image(ippxImage);

// 글머리 높이를 설정합니다
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100.0f);

// 단락을 텍스트 프레임에 추가합니다
paragraphs->Add(paragraph);

// 프레젠테이션을 PPTX 파일로 저장합니다
presentation->Save(u"ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);

// 프레젠테이션을 PPT 파일로 저장합니다
presentation->Save(u"ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
```

## **다단계 글머리 기호 관리**

글머리 기호 목록은 정보를 빠르고 효율적으로 조직하고 제시하는 데 도움이 됩니다. 다단계 글머리 기호는 읽고 이해하기 쉽습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 해당 슬라이드의 참조에 접근합니다.
3. 새 슬라이드에 [autoshape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iautoshape/)을 추가합니다.
4. autoshape의 [TextFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframe/)에 접근합니다.
5. `TextFrame`의 기본 단락을 제거합니다.
6. [Paragraph](https://reference.aspose.com/slides/ko/cpp/aspose.slides/paragraph/) 클래스를 통해 첫 번째 단락 인스턴스를 생성하고 깊이를 0으로 설정합니다.
7. `Paragraph` 클래스를 통해 두 번째 단락 인스턴스를 생성하고 깊이를 1로 설정합니다.
8. `Paragraph` 클래스를 통해 세 번째 단락 인스턴스를 생성하고 깊이를 2로 설정합니다.
9. `Paragraph` 클래스를 통해 네 번째 단락 인스턴스를 생성하고 깊이를 3으로 설정합니다.
10. 새 단락들을 `TextFrame` 단락 컬렉션에 추가합니다.
11. 수정된 프레젠테이션을 저장합니다.

다음 C++ 코드는 다단계 글머리 기호를 추가하고 관리하는 방법을 보여줍니다: 

```c++
// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// 첫 번째 슬라이드에 접근합니다
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// AutoShape을 추가하고 접근합니다
System::SharedPtr<IAutoShape> aShp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// 생성된 AutoShape의 텍스트 프레임에 접근합니다
System::SharedPtr<ITextFrame> text = aShp->AddTextFrame(u"");

// 기본 단락을 제거합니다
text->get_Paragraphs()->Clear();

// 첫 번째 단락을 추가합니다
System::SharedPtr<IParagraph> para1 = System::MakeObject<Paragraph>();
para1->set_Text(u"Content");
System::SharedPtr<IParagraphFormat> para1Format = para1->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet1Format = para1Format->get_Bullet();
bullet1Format->set_Type(BulletType::Symbol);
bullet1Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat1 = para1Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat1->set_FillType(FillType::Solid);
defaultFillFormat1->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// 글머리 레벨을 설정합니다
para1Format->set_Depth(0);

// 두 번째 단락을 추가합니다
System::SharedPtr<IParagraph> para2 = System::MakeObject<Paragraph>();
para2->set_Text(u"Second Level");
System::SharedPtr<IParagraphFormat> para2Format = para2->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet2Format = para2Format->get_Bullet();
bullet2Format->set_Type(BulletType::Symbol);
bullet2Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat2 = para2Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat2->set_FillType(FillType::Solid);
defaultFillFormat2->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// 글머리 레벨을 설정합니다
para2Format->set_Depth(1);

// 세 번째 단락을 추가합니다
System::SharedPtr<IParagraph> para3 = System::MakeObject<Paragraph>();
para3->set_Text(u"Third Level");
System::SharedPtr<IParagraphFormat> para3Format = para3->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet3Format = para3Format->get_Bullet();
bullet3Format->set_Type(BulletType::Symbol);
bullet3Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat3 = para3Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat3->set_FillType(FillType::Solid);
defaultFillFormat3->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// 글머리 레벨을 설정합니다
para3Format->set_Depth(2);

// 네 번째 단락을 추가합니다
System::SharedPtr<IParagraph> para4 = System::MakeObject<Paragraph>();
para4->set_Text(u"Fourth Level");
System::SharedPtr<IParagraphFormat> para4Format = para4->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet4Format = para4Format->get_Bullet();
bullet4Format->set_Type(BulletType::Symbol);
bullet4Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat4 = para4Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat4->set_FillType(FillType::Solid);
defaultFillFormat4->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// 글머리 레벨을 설정합니다
para4Format->set_Depth(3);

// 단락들을 컬렉션에 추가합니다
System::SharedPtr<IParagraphCollection> paragraphs = text->get_Paragraphs();
paragraphs->Add(para1);
paragraphs->Add(para2);
paragraphs->Add(para3);
paragraphs->Add(para4);

// 프레젠테이션을 PPTX 파일로 저장합니다
pres->Save(u"MultilevelBullet.pptx", SaveFormat::Pptx);
```

## **사용자 정의 번호 매기기 목록이 있는 단락 관리**

[IBulletFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ibulletformat/) 인터페이스는 [NumberedBulletStartWith](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) 속성 및 기타 속성을 제공하여 사용자 정의 번호 매기기 또는 서식이 있는 단락을 관리할 수 있게 합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 단락이 포함된 슬라이드에 접근합니다.
3. 슬라이드에 [autoshape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iautoshape/)을 추가합니다.
4. autoshape [TextFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframe/)에 접근합니다.
5. `TextFrame`의 기본 단락을 제거합니다.
6. [Paragraph](https://reference.aspose.com/slides/ko/cpp/aspose.slides/paragraph/) 클래스를 통해 첫 번째 단락 인스턴스를 생성하고 [NumberedBulletStartWith]를 2로 설정합니다.
7. `Paragraph` 클래스를 통해 두 번째 단락 인스턴스를 생성하고 `NumberedBulletStartWith`를 3으로 설정합니다.
8. `Paragraph` 클래스를 통해 세 번째 단락 인스턴스를 생성하고 `NumberedBulletStartWith`를 7으로 설정합니다.
9. 새 단락들을 `TextFrame` 단락 컬렉션에 추가합니다.
10. 수정된 프레젠테이션을 저장합니다.

다음 C++ 코드는 사용자 정의 번호 매기기 또는 서식이 있는 단락을 추가하고 관리하는 방법을 보여줍니다: 

```c++
auto presentation = System::MakeObject<Presentation>();

auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Accesses the text frame of created autoshape
System::SharedPtr<ITextFrame> textFrame = shape->get_TextFrame();

// Removes the default existing paragraph
textFrame->get_Paragraphs()->RemoveAt(0);

// First list
auto paragraph1 = System::MakeObject<Paragraph>();
paragraph1->set_Text(u"bullet 2");
auto paragraph1Format = paragraph1->get_ParagraphFormat();
paragraph1Format->set_Depth(4);
auto bullet1Format = paragraph1Format->get_Bullet();
bullet1Format->set_NumberedBulletStartWith(2);
bullet1Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = System::MakeObject<Paragraph>();
paragraph2->set_Text(u"bullet 3");
auto paragraph2Format = paragraph2->get_ParagraphFormat();
paragraph2Format->set_Depth(4);
auto bullet2Format = paragraph2Format->get_Bullet();
bullet2Format->set_NumberedBulletStartWith(3);
bullet2Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph2);

auto paragraph5 = System::MakeObject<Paragraph>();
paragraph5->set_Text(u"bullet 7");
auto paragraph5Format = paragraph5->get_ParagraphFormat();
paragraph5Format->set_Depth(4);
auto bullet5Format = paragraph5Format->get_Bullet();
bullet5Format->set_NumberedBulletStartWith(7);
bullet5Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph5);

presentation->Save(u"SetCustomBulletsNumber-slides.pptx", SaveFormat::Pptx);
```

## **단락 첫 줄 들여쓰기 설정**

[IParagraphFormat::set_Indent](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraphformat/set_indent/) 메서드를 사용하여 단락의 첫 줄 들여쓰기를 제어합니다. 이 메서드는 단락 왼쪽 여백에 대해 첫 줄만 이동시킵니다. 양수 값은 첫 줄을 오른쪽으로 이동시키고, 나머지 줄은 단락 본문에 맞게 정렬됩니다.

전체 단락을 이동해야 할 경우 [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraphformat/set_marginleft/)을 사용하고, 첫 줄만 이동해야 할 경우 [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraphformat/set_indent/)을 사용합니다.

아래 예제는 여러 단락을 생성하고 서로 다른 `Indent` 값을 적용하여 첫 줄 들여쓰기가 단락 레이아웃에 어떻게 영향을 미치는지 보여줍니다.

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 대상 슬라이드에 접근합니다.
3. 슬라이드에 사각형 [AutoShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/autoshape/)을 추가합니다.
4. 도형에 빈 [TextFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/textframe/)을 추가하고 기본 단락을 제거합니다.
5. 여러 단락을 생성하고 각각에 다른 [Indent](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraphformat/set_indent/) 값을 설정합니다.
6. 단락들을 텍스트 프레임에 추가합니다.
7. 수정된 프레젠테이션을 저장합니다.

다음 코드는 단락 들여쓰기를 설정하는 방법을 보여줍니다: 

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto rectangleShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
rectangleShape->get_FillFormat()->set_FillType(FillType::NoFill);
rectangleShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
rectangleShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = rectangleShape->AddTextFrame(u"");
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->RemoveAt(0);

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->set_Text(u"No first-line indent. Wrapped lines start at the same position as the first line.");
firstParagraph->get_ParagraphFormat()->set_MarginLeft(20.f);
firstParagraph->get_ParagraphFormat()->set_Indent(0.f);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->set_Text(u"First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
secondParagraph->get_ParagraphFormat()->set_MarginLeft(20.f);
secondParagraph->get_ParagraphFormat()->set_Indent(20.f);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
thirdParagraph->set_Text(u"First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
thirdParagraph->get_ParagraphFormat()->set_MarginLeft(20.f);
thirdParagraph->get_ParagraphFormat()->set_Indent(40.f);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);
textFrame->get_Paragraphs()->Add(thirdParagraph);

presentation->Save(u"paragraph_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

결과:

![단락의 첫 줄 들여쓰기](first_line_indent.png)

## **단락 매달린 들여쓰기 설정**

매달린 들여쓰기는 첫 줄이 나머지 줄보다 왼쪽에서 시작되는 단락 레이아웃입니다. Aspose.Slides에서는 [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraphformat/set_indent/) 메서드를 사용하여 이 효과를 만들 수 있습니다. 들여쓰기를 음수 값으로 설정하면 첫 줄을 단락 본문에 대해 왼쪽으로 이동시킵니다.

실제로 [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraphformat/set_marginleft/)은 단락 본문의 왼쪽 위치를 정의하고, [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraphformat/set_indent/)은 해당 여백에 대한 첫 줄의 위치를 정의합니다. 매달린 들여쓰기를 만들려면 양의 `MarginLeft` 값과 음의 `Indent` 값을 설정합니다.

이 서식은 참고문헌, 인용, 용어집 항목 및 줄 바꿈된 라인이 첫 줄의 첫 문자 아래가 아니라 단락 본문 아래에 정렬되어야 하는 기타 단락에 유용합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 대상 슬라이드에 접근합니다.
3. 슬라이드에 사각형 [AutoShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/autoshape/)을 추가합니다.
4. 도형에 빈 [TextFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/textframe/)을 추가하고 기본 단락을 제거합니다.
5. 각 단락에 대해 양의 [MarginLeft](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraphformat/set_marginleft/) 값을 설정합니다.
6. 매달린 들여쓰기 효과를 만들기 위해 음의 [Indent](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraphformat/set_indent/) 값을 설정합니다.
7. 단락들을 텍스트 프레임에 추가합니다.
8. 수정된 프레젠테이션을 저장합니다.

다음 코드는 단락에 매달린 들여쓰기를 설정하는 방법을 보여줍니다: 

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto rectangleShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
rectangleShape->get_FillFormat()->set_FillType(FillType::NoFill);
rectangleShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
rectangleShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = rectangleShape->AddTextFrame(u"");
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->RemoveAt(0);

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->set_Text(u"A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
firstParagraph->get_ParagraphFormat()->set_MarginLeft(40.f);
firstParagraph->get_ParagraphFormat()->set_Indent(-20.f);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->set_Text(u"This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
secondParagraph->get_ParagraphFormat()->set_MarginLeft(60.f);
secondParagraph->get_ParagraphFormat()->set_Indent(-30.f);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);

presentation->Save(u"hanging_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

결과:

![단락의 매달린 들여쓰기](hanging_indent.png)

## **끝 단락 실행 속성 관리**

[Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
[Presentation] 클래스의 인스턴스를 생성합니다.
1. 위치를 통해 단락이 포함된 슬라이드의 참조를 가져옵니다.
2. 슬라이드에 사각형 [autoshape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iautoshape/)을 추가합니다.
3. 사각형에 두 개의 단락이 있는 [TextFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframe/)을 추가합니다.
4. 단락의 `FontHeight`와 글꼴 유형을 설정합니다.
5. 단락의 End 속성을 설정합니다.
6. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 C++ 코드는 PowerPoint에서 단락의 End 속성을 설정하는 방법을 보여줍니다: 

```c++
// 문서 디렉터리 경로.
const String outPath = u"../out/EndParaGraphProperties_out.pptx";
//const String templatePath = u"../templates/DefaultFonts.pptx";


// 원하는 프레젠테이션을 로드합니다
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 첫 번째 슬라이드에 접근합니다
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// 사각형 유형의 AutoShape을 추가합니다
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);

// 사각형에 TextFrame을 추가합니다
SharedPtr<ITextFrame> tf = ashp->AddTextFrame(String::Empty);

// 첫 번째 단락 추가
//SharedPtr<IParagraph> para1 = tf->get_Paragraphs()->idx_get(0);

SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
SharedPtr<Portion> port01 = MakeObject<Portion>(u"Sample text");

para1->get_Portions()->Add(port01);

// 두 번째 단락 추가
SharedPtr<Paragraph> para2 = MakeObject<Paragraph>();
SharedPtr<Portion> port02 = MakeObject<Portion>(u"Sample text 2");

para2->get_Portions()->Add(port02);


SharedPtr<PortionFormat> endParagraphPortionFormat = MakeObject< PortionFormat>();
endParagraphPortionFormat->set_FontHeight ( 48);
endParagraphPortionFormat->set_LatinFont ( MakeObject< FontData>(u"Times New Roman"));
para2->set_EndParagraphPortionFormat(endParagraphPortionFormat);

ashp->get_TextFrame()->get_Paragraphs()->Add(para1);
ashp->get_TextFrame()->get_Paragraphs()->Add(para2);



// PPTX를 디스크에 저장합니다
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **HTML 텍스트를 단락으로 가져오기**

Aspose.Slides는 HTML 텍스트를 단락으로 가져오는 향상된 지원을 제공합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 해당 슬라이드의 참조에 접근합니다.
3. 슬라이드에 [autoshape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iautoshape/)을 추가합니다.
4. `autoshape` [ITextFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframe/)을 추가하고 접근합니다.
5. `ITextFrame`의 기본 단락을 제거합니다.
6. TextReader에서 원본 HTML 파일을 읽습니다.
7. [Paragraph](https://reference.aspose.com/slides/ko/cpp/aspose.slides/paragraph/) 클래스를 통해 첫 번째 단락 인스턴스를 생성합니다.
8. 읽은 TextReader의 HTML 파일 내용을 TextFrame의 [ParagraphCollection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/paragraphcollection/)에 추가합니다.
9. 수정된 프레젠테이션을 저장합니다.

다음 C++ 코드는 단락에 HTML 텍스트를 가져오는 단계의 구현 예시입니다: 

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// 문서 디렉터리 경로.
const String outPath = u"../out/ImportingHTMLText_out.pptx";
const String sampleHtml = u"../templates/file.html";

	
	// 원하는 프레젠테이션을 로드합니다
SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// 첫 번째 슬라이드에 접근합니다
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

	// 사각형 유형의 AutoShape을 추가합니다
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 700, 500);
	
	// 기본 채우기 색상 재설정
ashp->get_FillFormat()->set_FillType(FillType::NoFill);
	
	// 사각형에 TextFrame을 추가합니다
ashp->AddTextFrame(u" ");

// 텍스트 프레임에 접근합니다
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();

// Paragraphs 컬렉션 가져오기
SharedPtr<Aspose::Slides::IParagraphCollection>ParaCollection = txtFrame->get_Paragraphs();

// 추가된 텍스트 프레임의 모든 단락을 지웁니다
ParaCollection->Clear();

// 스트림 리더를 사용해 HTML 파일을 로드합니다
SharedPtr<System::IO::StreamReader>  tr = MakeObject<System::IO::StreamReader>(sampleHtml);

// 텍스트 프레임에 HTML 스트림 리더의 텍스트를 추가합니다
ParaCollection->AddFromHtml(tr->ReadToEnd());


// 텍스트 프레임을 위한 Paragraph 객체를 생성합니다
SharedPtr<IParagraph> paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// 단락을 위한 Portion 객체를 생성합니다
SharedPtr<IPortion> portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose TextBox");

// Portion 형식 가져오기
SharedPtr<IPortionFormat> pf = portion->get_PortionFormat();

// Portion의 글꼴을 설정합니다
pf->set_LatinFont(MakeObject<FontData>(u"Times New Roman"));

// 글꼴의 굵게 속성을 설정합니다
pf->set_FontBold(NullableBool::True);

// 글꼴의 이탤릭 속성을 설정합니다
pf->set_FontItalic(NullableBool::True);

// 글꼴의 밑줄 속성을 설정합니다
pf->set_FontUnderline(TextUnderlineType::Single);

// 글꼴의 높이를 설정합니다
pf->set_FontHeight(25);

// 글꼴의 색상을 설정합니다
pf->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// PPTX를 디스크에 저장합니다
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **단락 텍스트를 HTML로 내보내기**

Aspose.Slides는 단락에 포함된 텍스트를 HTML로 내보내는 향상된 지원을 제공합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성하고 원하는 프레젠테이션을 로드합니다.
2. 인덱스를 통해 해당 슬라이드의 참조에 접근합니다.
3. HTML로 내보낼 텍스트가 포함된 도형에 접근합니다.
4. 도형 [TextFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframe/)에 접근합니다.
5. `StreamWriter` 인스턴스를 생성하고 새 HTML 파일을 추가합니다.
6. StreamWriter에 시작 인덱스를 제공하고 원하는 단락을 내보냅니다.

다음 C++ 코드는 PowerPoint 단락 텍스트를 HTML로 내보내는 방법을 보여줍니다: 

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// 문서 디렉터리 경로.
const String outPath = u"../out/output.html";
const String tempplatePath = u"../templates/DefaultFonts.pptx";

// 원하는 프레젠테이션을 로드합니다
SharedPtr<Presentation> pres = MakeObject<Presentation>(tempplatePath);


// 프레젠테이션의 기본 첫 슬라이드에 접근합니다
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// 원하는 인덱스
int index = 0;

// 추가된 도형에 접근합니다
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);

SharedPtr<AutoShape> ashape = DynamicCast<Aspose::Slides::AutoShape>(shape);

// 첫 번째 단락을 HTML로 추출합니다
SharedPtr<System::IO::StreamWriter> sw = MakeObject<System::IO::StreamWriter>(outPath, false, Encoding::get_UTF8());
//	System::IO::StreamWriter^ sr = gcnew System::IO::StreamWriter("TestFile.txt", false, Encoding::get_UTF8());

// 단락 시작 인덱스와 복사할 총 단락 수를 제공하여 단락 데이터를 HTML에 씁니다
sw->Write(ashape->get_TextFrame()->get_Paragraphs()->ExportToHtml(0, ashape->get_TextFrame()->get_Paragraphs()->get_Count(), nullptr));

sw->Close();

```

## **단락을 이미지로 저장**

이 섹션에서는 [IParagraph](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraph/) 인터페이스가 나타내는 텍스트 단락을 이미지로 저장하는 방법을 보여주는 두 가지 예제를 살펴봅니다. 두 예제 모두 [IShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/) 인터페이스의 `GetImage` 메서드를 사용하여 단락을 포함하는 도형의 이미지를 얻고, 도형 내에서 단락의 경계를 계산한 뒤 비트맵 이미지로 내보냅니다. 이러한 방법을 통해 PowerPoint 프레젠테이션에서 텍스트의 특정 부분을 추출하여 별도의 이미지로 저장할 수 있으며, 다양한 시나리오에서 활용할 수 있습니다.

sample.pptx라는 프레젠테이션 파일이 하나의 슬라이드를 가지고 있으며, 첫 번째 도형이 세 개의 단락을 포함한 텍스트 상자라고 가정해 보겠습니다.

![세 개의 단락이 있는 텍스트 상자](paragraph_to_image_input.png)

**Example 1**

이 예제에서는 두 번째 단락을 이미지로 얻습니다. 이를 위해 프레젠테이션 첫 번째 슬라이드에서 도형의 이미지를 추출한 다음, 도형 텍스트 프레임에서 두 번째 단락의 경계를 계산합니다. 그 후 단락을 새로운 비트맵 이미지에 다시 그려 PNG 형식으로 저장합니다. 이 방법은 텍스트의 정확한 크기와 서식을 유지하면서 특정 단락을 별도의 이미지로 저장해야 할 때 특히 유용합니다.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstShape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// Save the shape in memory as a bitmap.
auto shapeImage = firstShape->GetImage();
auto shapeImageStream = MakeObject<MemoryStream>();
shapeImage->Save(shapeImageStream, ImageFormat::Png);
shapeImage->Dispose();

// Create a shape bitmap from memory.
shapeImageStream->set_Position(0);
auto shapeBitmap = MakeObject<Bitmap>(Image::FromStream(shapeImageStream));

// Calculate the boundaries of the second paragraph.
auto secondParagraph = firstShape->get_TextFrame()->get_Paragraph(1);
auto paragraphRectangle = secondParagraph->GetRect();

// Calculate the size for the output image (minimum size - 1x1 pixel).
auto imageWidth = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Width()));
auto imageHeight = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Height()));

// Prepare a bitmap for the paragraph.
auto paragraphBitmap = MakeObject<Bitmap>(imageWidth, imageHeight);

// Redraw the paragraph from the shape bitmap to the paragraph bitmap.
auto imageGraphics = Graphics::FromImage(paragraphBitmap.get());
RectangleF drawingRectangle(0, 0, paragraphRectangle.get_Width(), paragraphRectangle.get_Height());
imageGraphics->DrawImage(shapeBitmap.get(), drawingRectangle, paragraphRectangle, GraphicsUnit::Pixel);
imageGraphics->Dispose();

paragraphBitmap->Save(u"paragraph.png", Imaging::ImageFormat::get_Png());

presentation->Dispose();
```

결과:

![단락 이미지](paragraph_to_image_output.png)

**Example 2**

이 예제에서는 앞의 방법에 단락 이미지에 스케일링 팩터를 추가하여 확장합니다. 도형을 프레젠테이션에서 추출하고 스케일 팩터 `2`로 이미지를 저장합니다. 이렇게 하면 단락을 내보낼 때 더 높은 해상도의 출력이 가능합니다. 그런 다음 스케일을 반영하여 단락 경계를 계산합니다. 스케일링은 고품질 인쇄물 등 더 상세한 이미지가 필요할 때 특히 유용합니다.

```cpp
auto imageScaleX = 2.0f;
auto imageScaleY = imageScaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstShape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// Save the shape in memory as a bitmap with scaling.
auto shapeImage = firstShape->GetImage(ShapeThumbnailBounds::Shape, imageScaleX, imageScaleY);
auto shapeImageStream = MakeObject<MemoryStream>();
shapeImage->Save(shapeImageStream, ImageFormat::Png);
shapeImage->Dispose();

// Create a shape bitmap from memory.
shapeImageStream->set_Position(0);
auto shapeBitmap = MakeObject<Bitmap>(Image::FromStream(shapeImageStream));

// Calculate the boundaries of the second paragraph.
auto secondParagraph = firstShape->get_TextFrame()->get_Paragraph(1);
auto paragraphRectangle = secondParagraph->GetRect();
paragraphRectangle.set_X(paragraphRectangle.get_X() * imageScaleX);
paragraphRectangle.set_Y(paragraphRectangle.get_Y() * imageScaleY);
paragraphRectangle.set_Width(paragraphRectangle.get_Width() * imageScaleX);
paragraphRectangle.set_Height(paragraphRectangle.get_Height() * imageScaleY);

// Calculate the size for the output image (minimum size - 1x1 pixel).
auto imageWidth = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Width()));
auto imageHeight = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Height()));

// Prepare a bitmap for the paragraph.
auto paragraphBitmap = MakeObject<Bitmap>(imageWidth, imageHeight);

// Redraw the paragraph from the shape bitmap to the paragraph bitmap.
auto imageGraphics = Graphics::FromImage(paragraphBitmap.get());
RectangleF drawingRectangle(0, 0, paragraphRectangle.get_Width(), paragraphRectangle.get_Height());
imageGraphics->DrawImage(shapeBitmap.get(), drawingRectangle, paragraphRectangle, GraphicsUnit::Pixel);
imageGraphics->Dispose();

paragraphBitmap->Save(u"paragraph.png", Imaging::ImageFormat::get_Png());

presentation->Dispose();
```

## **자주 묻는 질문**

**텍스트 프레임 내에서 줄 바꿈을 완전히 비활성화할 수 있나요?**

예. 텍스트 프레임의 래핑 메서드([set_WrapText](https://reference.aspose.com/slides/ko/cpp/aspose.slides/textframeformat/set_wraptext/))를 사용하여 래핑을 끄면 프레임 가장자리에서 줄이 끊기지 않습니다.

**특정 단락의 슬라이드 상 정확한 경계를 가져오려면 어떻게 해야 하나요?**

단락(또는 단일 구문)의 경계 사각형을 가져와 슬라이드에서 정확한 위치와 크기를 알 수 있습니다.

**단락 정렬(왼쪽/오른쪽/가운데/양쪽 맞춤)은 어디에서 제어됩니까?**

[Alignment](https://reference.aspose.com/slides/ko/cpp/aspose.slides/paragraphformat/set_alignment/)는 [ParagraphFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/paragraphformat/)의 단락 수준 설정이며, 개별 구문 서식과 관계없이 전체 단락에 적용됩니다.

**단락의 일부(예: 한 단어)만 맞춤법 검사 언어를 설정할 수 있나요?**

예. 언어는 구문 수준에서 ([PortionFormat::set_LanguageId](https://reference.aspose.com/slides/ko/cpp/aspose.slides/baseportionformat/set_languageid/)) 설정되므로 하나의 단락 내에 여러 언어가 동시에 존재할 수 있습니다.