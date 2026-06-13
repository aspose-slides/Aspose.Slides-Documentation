---
title: ".NET에서 PowerPoint 텍스트 단락 관리"
linktitle: "단락 관리"
type: docs
weight: 40
url: /ko/net/manage-paragraph/
keywords:
- "텍스트 추가"
- "단락 추가"
- "텍스트 관리"
- "단락 관리"
- "글머리 기호 관리"
- "단락 들여쓰기"
- "행걸이 들여쓰기"
- "단락 글머리 기호"
- "번호 매기기 목록"
- "글머리 목록"
- "단락 속성"
- "HTML 가져오기"
- "텍스트를 HTML로"
- "단락을 HTML로"
- "단락을 이미지로"
- "텍스트를 이미지로"
- "단락 내보내기"
- "PowerPoint"
- "프레젠테이션"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET으로 단락 서식을 마스터하고, C#에서 PPT, PPTX 및 ODP 프레젠테이션의 정렬, 간격 및 스타일을 최적화합니다."
---
## **소개**

Aspose.Slides는 C#에서 PowerPoint 텍스트, 단락 및 구절을 작업하는 데 필요한 모든 인터페이스와 클래스를 제공합니다.

* Aspose.Slides는 단락을 나타내는 객체를 추가할 수 있도록 하는 [ITextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/) 인터페이스를 제공합니다. `ITextFame` 객체는 하나 이상의 단락을 가질 수 있습니다(각 단락은 캐리지 리턴을 통해 생성).
* Aspose.Slides는 구절을 나타내는 객체를 추가할 수 있도록 하는 [IParagraph](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraph/) 인터페이스를 제공합니다. `IParagraph` 객체는 하나 이상의 구절(Portion 객체 컬렉션)을 가질 수 있습니다.
* Aspose.Slides는 텍스트와 해당 서식 속성을 나타내는 객체를 추가할 수 있도록 하는 [IPortion](https://reference.aspose.com/slides/ko/net/aspose.slides/iportion/) 인터페이스를 제공합니다. 

`IParagraph` 객체는 기본 `IPortion` 객체를 통해 다양한 서식 속성을 가진 텍스트를 처리할 수 있습니다.

## **여러 구절을 포함하는 다중 단락 추가**

다음 단계에서는 3개의 단락을 포함하고 각 단락에 3개의 구절을 포함하는 텍스트 프레임을 추가하는 방법을 보여줍니다.

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스를 인스턴스화합니다.
2. 인덱스를 통해 해당 슬라이드의 참조에 접근합니다.
3. 슬라이드에 사각형 [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/)을 추가합니다.
4. 해당 [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/)와 연결된 ITextFrame을 가져옵니다.
5. 두 개의 [IParagraph](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraph/) 객체를 생성하고 이를 [ITextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/)의 `IParagraphs` 컬렉션에 추가합니다.
6. 각 새로운 `IParagraph`에 대해 세 개의 [IPortion](https://reference.aspose.com/slides/ko/net/aspose.slides/iportion/) 객체를 생성(기본 단락은 두 개의 Portion 객체)하고 각각을 해당 `IParagraph`의 IPortion 컬렉션에 추가합니다.
7. 각 구절에 텍스트를 설정합니다.
8. `IPortion` 객체가 제공하는 서식 속성을 사용하여 각 구절에 원하는 서식 옵션을 적용합니다.
9. 수정된 프레젠테이션을 저장합니다.

다음 C# 코드는 위 단계들을 구현한 예제입니다:

```c#
// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
using (Presentation pres = new Presentation())
{
    // 첫 번째 슬라이드에 접근합니다
    ISlide slide = pres.Slides[0];

    // 사각형 IAutoShape을 추가합니다
    IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // AutoShape의 TextFrame에 접근합니다
    ITextFrame tf = ashp.TextFrame;

    // 다양한 텍스트 서식을 가진 Paragraph와 Portion을 생성합니다
    IParagraph para0 = tf.Paragraphs[0];
    IPortion port01 = new Portion();
    IPortion port02 = new Portion();
    para0.Portions.Add(port01);
    para0.Portions.Add(port02);

    IParagraph para1 = new Paragraph();
    tf.Paragraphs.Add(para1);
    IPortion port10 = new Portion();
    IPortion port11 = new Portion();
    IPortion port12 = new Portion();
    para1.Portions.Add(port10);
    para1.Portions.Add(port11);
    para1.Portions.Add(port12);

    IParagraph para2 = new Paragraph();
    tf.Paragraphs.Add(para2);
    IPortion port20 = new Portion();
    IPortion port21 = new Portion();
    IPortion port22 = new Portion();
    para2.Portions.Add(port20);
    para2.Portions.Add(port21);
    para2.Portions.Add(port22);

    for (int i = 0; i < 3; i++)
        for (int j = 0; j < 3; j++)
        {
            tf.Paragraphs[i].Portions[j].Text = "Portion0" + j.ToString();
            if (j == 0)
            {
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.FillType = FillType.Solid;
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontBold = NullableBool.True;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontHeight = 15;
            }
            else if (j == 1)
            {
                tf.Paragraphs[i].Portions[j].FillFormat.FillType = FillType.Solid;
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontItalic = NullableBool.True;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontHeight = 18;
            }
        }
    // 수정된 프레젠테이션을 저장합니다
    pres.Save("multiParaPort_out.pptx", SaveFormat.Pptx);

}
```

## **단락 글머리 기호 관리**
글머리 기호 목록은 정보를 빠르고 효율적으로 구성하고 표현하는 데 도움이 됩니다. 글머리 기호가 있는 단락은 읽고 이해하기가 항상 더 쉽습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스를 인스턴스화합니다.
2. 인덱스를 통해 해당 슬라이드의 참조에 접근합니다.
3. 선택한 슬라이드에 [autoshape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/)을 추가합니다.
4. 자동도형의 [TextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/)에 접근합니다. 
5. `TextFrame`의 기본 단락을 제거합니다.
6. [Paragraph](https://reference.aspose.com/slides/ko/net/aspose.slides/paragraph/) 클래스를 사용하여 첫 번째 단락 인스턴스를 생성합니다.
8. 단락의 `Type`을 `Symbol`로 설정하고 글머리 기호 문자를 지정합니다.
9. 단락의 `Text`를 설정합니다.
10. 글머리 기호의 `Indent`를 설정합니다.
11. 글머리 기호 색상을 설정합니다.
12. 글머리 기호 높이를 설정합니다.
13. 새 단락을 `TextFrame`의 단락 컬렉션에 추가합니다.
14. 두 번째 단락을 추가하고 7~13 단계를 반복합니다.
15. 프레젠테이션을 저장합니다.

다음 C# 코드는 단락 글머리 기호를 추가하는 방법을 보여줍니다:

```c#
// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
using (Presentation pres = new Presentation())
{

    // 첫 번째 슬라이드에 접근합니다
    ISlide slide = pres.Slides[0];


    // 자동도형을 추가하고 접근합니다
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 자동도형 텍스트 프레임에 접근합니다
    ITextFrame txtFrm = aShp.TextFrame;

    // 기본 단락을 제거합니다
    txtFrm.Paragraphs.RemoveAt(0);

    // 단락을 생성합니다
    Paragraph para = new Paragraph();

    // 단락 글머리 기호 스타일과 기호를 설정합니다
    para.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);

    // 단락 텍스트를 설정합니다
    para.Text = "Welcome to Aspose.Slides";

    // 글머리 들여쓰기를 설정합니다
    para.ParagraphFormat.Indent = 25;

    // 글머리 색상을 설정합니다
    para.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // IsBulletHardColor를 true로 설정하여 자체 글머리 색상을 사용합니다

    // 글머리 높이를 설정합니다
    para.ParagraphFormat.Bullet.Height = 100;

    // 단락을 텍스트 프레임에 추가합니다
    txtFrm.Paragraphs.Add(para);

    // 두 번째 단락을 생성합니다
    Paragraph para2 = new Paragraph();

    // 단락 글머리 기호 유형 및 스타일을 설정합니다
    para2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    para2.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;

    // 단락 텍스트를 추가합니다
    para2.Text = "This is numbered bullet";

    // 글머리 들여쓰기를 설정합니다
    para2.ParagraphFormat.Indent = 25;

    para2.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para2.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para2.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // IsBulletHardColor를 true로 설정하여 자체 글머리 색상을 사용합니다

    // 글머리 높이를 설정합니다
    para2.ParagraphFormat.Bullet.Height = 100;

    // 단락을 텍스트 프레임에 추가합니다
    txtFrm.Paragraphs.Add(para2);


    // 수정된 프레젠테이션을 저장합니다
    pres.Save("Bullet_out.pptx", SaveFormat.Pptx);

}
```

## **그림 글머리 기호 관리**
그림 목록은 정보를 빠르고 효율적으로 구성하고 표현하는 데 도움이 됩니다. 그림 단락은 읽고 이해하기가 쉽습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스를 인스턴스화합니다.
2. 인덱스를 통해 해당 슬라이드의 참조에 접근합니다.
3. 슬라이드에 [autoshape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/)을 추가합니다.
4. 자동도형의 [TextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/textframe/)에 접근합니다.
5. `TextFrame`의 기본 단락을 제거합니다.
6. [Paragraph](https://reference.aspose.com/slides/ko/net/aspose.slides/paragraph/) 클래스를 사용하여 첫 번째 단락 인스턴스를 생성합니다.
7. [IPPImage](https://reference.aspose.com/slides/ko/net/aspose.slides/ippimage/)를 사용해 이미지를 로드합니다.
8. 글머리 기호 유형을 [Picture](https://reference.aspose.com/slides/ko/net/aspose.slides/ippimage/)로 설정하고 이미지를 지정합니다.
9. 단락의 `Text`를 설정합니다.
10. 글머리 기호의 `Indent`를 설정합니다.
11. 글머리 기호 색상을 설정합니다.
12. 글머리 기호 높이를 설정합니다.
13. 새 단락을 `TextFrame`의 단락 컬렉션에 추가합니다.
14. 두 번째 단락을 추가하고 이전 단계들을 반복합니다.
15. 수정된 프레젠테이션을 저장합니다.

다음 C# 코드는 그림 글머리 기호를 추가하고 관리하는 방법을 보여줍니다:

```c#
// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation presentation = new Presentation();

// 첫 번째 슬라이드에 접근합니다
ISlide slide = presentation.Slides[0];

// 글머리 기호용 이미지를 인스턴스화합니다
IImage image = Images.FromFile("bullets.png");
IPPImage ippxImage = presentation.Images.AddImage(image);
image.Dispose();

// 자동도형을 추가하고 접근합니다
IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

// 자동도형 텍스트 프레임에 접근합니다
ITextFrame textFrame = autoShape.TextFrame;

// 기본 단락을 제거합니다
textFrame.Paragraphs.RemoveAt(0);

// 새 단락을 생성합니다
Paragraph paragraph = new Paragraph();
paragraph.Text = "Welcome to Aspose.Slides";

// 단락 글머리 기호 스타일과 이미지를 설정합니다
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = ippxImage;

// 글머리 높이를 설정합니다
paragraph.ParagraphFormat.Bullet.Height = 100;

// 단락을 텍스트 프레임에 추가합니다
textFrame.Paragraphs.Add(paragraph);

// 프레젠테이션을 PPTX 파일로 저장합니다
presentation.Save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

// 프레젠테이션을 PPT 파일로 저장합니다
presentation.Save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
```

## **다중 수준 글머리 기호 관리**
다중 수준 글머리 기호 목록은 정보를 빠르고 효율적으로 구성하고 표현하는 데 도움이 됩니다. 다중 수준 글머리 기호는 읽고 이해하기가 쉽습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스를 인스턴스화합니다.
2. 인덱스를 통해 해당 슬라이드의 참조에 접근합니다.
3. 새 슬라이드에 [autoshape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/)을 추가합니다.
4. 자동도형의 [TextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/textframe/)에 접근합니다.
5. `TextFrame`의 기본 단락을 제거합니다.
6. [Paragraph](https://reference.aspose.com/slides/ko/net/aspose.slides/paragraph/) 클래스를 통해 첫 번째 단락 인스턴스를 생성하고 깊이를 0으로 설정합니다.
7. `Paragraph` 클래스를 통해 두 번째 단락 인스턴스를 생성하고 깊이를 1로 설정합니다.
8. `Paragraph` 클래스를 통해 세 번째 단락 인스턴스를 생성하고 깊이를 2로 설정합니다.
9. `Paragraph` 클래스를 통해 네 번째 단락 인스턴스를 생성하고 깊이를 3으로 설정합니다.
10. 새 단락들을 `TextFrame`의 단락 컬렉션에 추가합니다.
11. 수정된 프레젠테이션을 저장합니다.

다음 C# 코드는 다중 수준 글머리 기호를 추가하고 관리하는 방법을 보여줍니다:

```c#
// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
using (Presentation pres = new Presentation())
{

    // 첫 번째 슬라이드에 접근합니다
    ISlide slide = pres.Slides[0];
    
    // 자동도형을 추가하고 접근합니다
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 생성된 자동도형의 텍스트 프레임에 접근합니다
    ITextFrame text = aShp.AddTextFrame("");
    
    // 기본 단락을 삭제합니다
    text.Paragraphs.Clear();

    // 첫 번째 단락을 추가합니다
    IParagraph para1 = new Paragraph();
    para1.Text = "Content";
    para1.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para1.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // 글머리 수준을 설정합니다
    para1.ParagraphFormat.Depth = 0;

    // 두 번째 단락을 추가합니다
    IParagraph para2 = new Paragraph();
    para2.Text = "Second Level";
    para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para2.ParagraphFormat.Bullet.Char = '-';
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // 글머리 수준을 설정합니다
    para2.ParagraphFormat.Depth = 1;

    // 세 번째 단락을 추가합니다
    IParagraph para3 = new Paragraph();
    para3.Text = "Third Level";
    para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // 글머리 수준을 설정합니다
    para3.ParagraphFormat.Depth = 2;

    // 네 번째 단락을 추가합니다
    IParagraph para4 = new Paragraph();
    para4.Text = "Fourth Level";
    para4.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para4.ParagraphFormat.Bullet.Char = '-';
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // 글머리 수준을 설정합니다
    para4.ParagraphFormat.Depth = 3;

    // 단락을 컬렉션에 추가합니다
    text.Paragraphs.Add(para1);
    text.Paragraphs.Add(para2);
    text.Paragraphs.Add(para3);
    text.Paragraphs.Add(para4);

    // 프레젠테이션을 PPTX 파일로 저장합니다
    pres.Save("MultilevelBullet.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **사용자 지정 번호 매기기 목록이 있는 단락 관리**
[IBulletFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/ibulletformat/) 인터페이스는 [NumberedBulletStartWith](https://reference.aspose.com/slides/ko/net/aspose.slides/ibulletformat/numberedbulletstartwith) 속성 등 번호 매기기 또는 서식을 사용자 지정할 수 있는 기능을 제공합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스를 인스턴스화합니다.
2. 단락이 포함된 슬라이드에 접근합니다.
3. 슬라이드에 [autoshape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/)을 추가합니다.
4. 자동도형의 [TextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/textframe/)에 접근합니다.
5. `TextFrame`의 기본 단락을 제거합니다.
6. [Paragraph](https://reference.aspose.com/slides/ko/net/aspose.slides/paragraph/) 클래스를 통해 첫 번째 단락 인스턴스를 생성하고 [NumberedBulletStartWith](https://reference.aspose.com/slides/ko/net/aspose.slides/ibulletformat/numberedbulletstartwith)을 2로 설정합니다.
7. `Paragraph` 클래스를 통해 두 번째 단락 인스턴스를 생성하고 `NumberedBulletStartWith`를 3으로 설정합니다.
8. `Paragraph` 클래스를 통해 세 번째 단락 인스턴스를 생성하고 `NumberedBulletStartWith`를 7으로 설정합니다.
9. 새 단락들을 `TextFrame`의 단락 컬렉션에 추가합니다.
10. 수정된 프레젠테이션을 저장합니다.

다음 C# 코드는 사용자 지정 번호 매기기 또는 서식이 적용된 단락을 추가하고 관리하는 방법을 보여줍니다:

```c#
using (var presentation = new Presentation())
{
	var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

	// 생성된 자동도형의 텍스트 프레임에 접근합니다
	ITextFrame textFrame = shape.TextFrame;

	// 기본 존재하는 단락을 제거합니다
	textFrame.Paragraphs.RemoveAt(0);

	// 첫 번째 리스트
	var paragraph1 = new Paragraph { Text = "bullet 2" };
	paragraph1.ParagraphFormat.Depth = 4; 
	paragraph1.ParagraphFormat.Bullet.NumberedBulletStartWith = 2;
	paragraph1.ParagraphFormat.Bullet.Type = BulletType.Numbered;
	textFrame.Paragraphs.Add(paragraph1);

	var paragraph2 = new Paragraph { Text = "bullet 3" };
	paragraph2.ParagraphFormat.Depth = 4;
	paragraph2.ParagraphFormat.Bullet.NumberedBulletStartWith = 3; 
	paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;  
	textFrame.Paragraphs.Add(paragraph2);

	
	var paragraph5 = new Paragraph { Text = "bullet 7" };
	paragraph5.ParagraphFormat.Depth = 4;
	paragraph5.ParagraphFormat.Bullet.NumberedBulletStartWith = 7;
	paragraph5.ParagraphFormat.Bullet.Type = BulletType.Numbered;
	textFrame.Paragraphs.Add(paragraph5);

	presentation.Save("SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
}
```

## **단락의 첫 줄 들여쓰기 설정**

[IParagraphFormat.Indent](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraphformat/indent/) 속성을 사용하여 단락의 첫 줄 들여쓰기를 제어합니다. 이 속성은 단락 본문의 왼쪽 여백에 대해 첫 줄만 이동시킵니다. 양수 값은 첫 줄을 오른쪽으로 이동하고, 나머지 줄은 그대로 유지됩니다.

전체 단락을 이동하려면 [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraphformat/marginleft/)를 사용하고, 첫 줄만 이동하려면 [IParagraphFormat.Indent](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraphformat/indent/)를 사용합니다.

아래 예제는 여러 단락을 생성하고 서로 다른 `Indent` 값을 적용하여 첫 줄 들여쓰기가 단락 레이아웃에 어떤 영향을 주는지 보여줍니다.

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스를 인스턴스화합니다.
2. 대상 슬라이드에 접근합니다.
3. 슬라이드에 사각형 [AutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/autoshape/)을 추가합니다.
4. 도형에 빈 [TextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/textframe/)을 추가하고 기본 단락을 제거합니다.
5. 여러 단락을 생성하고 각각에 다른 [Indent](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraphformat/indent/) 값을 지정합니다.
6. 단락들을 텍스트 프레임에 추가합니다.
7. 수정된 프레젠테이션을 저장합니다.

다음 코드는 단락 들여쓰기를 설정하는 방법을 보여줍니다:

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape rectangleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.FillFormat.FillType = FillType.NoFill;
    rectangleShape.LineFormat.FillFormat.FillType = FillType.Solid;
    rectangleShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

    ITextFrame textFrame = rectangleShape.AddTextFrame(string.Empty);
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
    textFrame.Paragraphs.RemoveAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    firstParagraph.Text = "No first-line indent. Wrapped lines start at the same position as the first line.";
    firstParagraph.ParagraphFormat.MarginLeft = 20f;
    firstParagraph.ParagraphFormat.Indent = 0f;

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    secondParagraph.Text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.";
    secondParagraph.ParagraphFormat.MarginLeft = 20f;
    secondParagraph.ParagraphFormat.Indent = 20f;

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    thirdParagraph.Text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.";
    thirdParagraph.ParagraphFormat.MarginLeft = 20f;
    thirdParagraph.ParagraphFormat.Indent = 40f;

    textFrame.Paragraphs.Add(firstParagraph);
    textFrame.Paragraphs.Add(secondParagraph);
    textFrame.Paragraphs.Add(thirdParagraph);

    presentation.Save("paragraph_indent.pptx", SaveFormat.Pptx);
}
```

결과:

![단락의 첫 줄 들여쓰기](first_line_indent.png)

## **단락의 행걸이 들여쓰기 설정**

행걸이 들여쓰기는 첫 번째 줄이 나머지 줄보다 왼쪽에 시작되는 레이아웃입니다. Aspose.Slides에서는 [IParagraphFormat.Indent](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraphformat/indent/) 속성을 사용하여 이 효과를 만들 수 있습니다. `Indent`에 음수 값을 지정하면 첫 줄이 단락 본문에 비해 왼쪽으로 이동합니다.

실제로는 [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraphformat/marginleft/)가 단락 본문의 왼쪽 위치를 정의하고, [IParagraphFormat.Indent](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraphformat/indent/)가 그 여백에 대한 첫 줄의 위치를 정의합니다. 행걸이 들여쓰기를 만들려면 양의 `MarginLeft` 값과 음의 `Indent` 값을 같이 설정합니다.

이 서식은 참고 문헌, 인용문, 용어 설명 등 줄바꿈된 텍스트가 첫 줄 첫 문자 아래가 아니라 단락 본문 아래에 맞춰져야 할 경우에 유용합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스를 인스턴스화합니다.
2. 대상 슬라이드에 접근합니다.
3. 슬라이드에 사각형 [AutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/autoshape/)을 추가합니다.
4. 도형에 빈 [TextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/textframe/)을 추가하고 기본 단락을 제거합니다.
5. 각 단락에 대해 양의 [MarginLeft](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraphformat/marginleft/) 값을 지정합니다.
6. 행걸이 들여쓰기 효과를 만들기 위해 음의 [Indent](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraphformat/indent/) 값을 설정합니다.
7. 단락들을 텍스트 프레임에 추가합니다.
8. 수정된 프레젠테이션을 저장합니다.

다음 코드는 단락에 행걸이 들여쓰기를 설정하는 방법을 보여줍니다:

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape rectangleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.FillFormat.FillType = FillType.NoFill;
    rectangleShape.LineFormat.FillFormat.FillType = FillType.Solid;
    rectangleShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

    ITextFrame textFrame = rectangleShape.AddTextFrame(string.Empty);
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
    textFrame.Paragraphs.RemoveAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    firstParagraph.Text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.";
    firstParagraph.ParagraphFormat.MarginLeft = 40f;
    firstParagraph.ParagraphFormat.Indent = -20f;

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    secondParagraph.Text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.";
    secondParagraph.ParagraphFormat.MarginLeft = 60f;
    secondParagraph.ParagraphFormat.Indent = -30f;

    textFrame.Paragraphs.Add(firstParagraph);
    textFrame.Paragraphs.Add(secondParagraph);

    presentation.Save("hanging_indent.pptx", SaveFormat.Pptx);
}
```

결과:

![단락의 행걸이 들여쓰기](hanging_indent.png)

## **단락 끝 속성 관리**

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스를 인스턴스화합니다.
2. 위치를 통해 단락이 포함된 슬라이드의 참조를 가져옵니다.
3. 슬라이드에 사각형 [autoshape](https://reference.aspose.com/slides/ko/net/aspose.slides/autoshape/)을 추가합니다.
4. 사각형에 두 개의 단락을 가진 [TextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/textframe/)을 추가합니다.
5. 단락의 `FontHeight`와 글꼴 유형을 설정합니다.
6. 단락의 End 속성을 설정합니다.
7. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 C# 코드는 PowerPoint 단락의 End 속성을 설정하는 방법을 보여줍니다:

```c#
using (Presentation pres = new Presentation("Test.pptx"))
{
	IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

	Paragraph para1 = new Paragraph();
	para1.Portions.Add(new Portion("Sample text"));

	Paragraph para2 = new Paragraph();
	para2.Portions.Add(new Portion("Sample text 2"));
	PortionFormat endParagraphPortionFormat = new PortionFormat();
	endParagraphPortionFormat.FontHeight = 48;
	endParagraphPortionFormat.LatinFont = new FontData("Times New Roman");
	para2.EndParagraphPortionFormat = endParagraphPortionFormat;

	shape.TextFrame.Paragraphs.Add(para1);
	shape.TextFrame.Paragraphs.Add(para2);

	pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **HTML 텍스트를 단락으로 가져오기**
Aspose.Slides는 HTML 텍스트를 단락으로 가져오는 기능을 강화했습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스를 인스턴스화합니다.
2. 인덱스를 통해 해당 슬라이드의 참조에 접근합니다.
3. 슬라이드에 [autoshape](https://reference.aspose.com/slides/ko/net/aspose.slides/autoshape/)을 추가합니다.
4. `autoshape`의 [ITextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/)에 접근합니다.
5. `ITextFrame`의 기본 단락을 제거합니다.
6. TextReader를 사용해 원본 HTML 파일을 읽어들입니다.
7. [Paragraph](https://reference.aspose.com/slides/ko/net/aspose.slides/paragraph/) 클래스를 통해 첫 번째 단락 인스턴스를 생성합니다.
8. 읽은 TextReader의 HTML 내용을 TextFrame의 [ParagraphCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/paragraphcollection/)에 추가합니다.
9. 수정된 프레젠테이션을 저장합니다.

다음 C# 코드는 HTML 텍스트를 단락에 가져오는 단계를 구현한 예제입니다:

```c#
// 빈 프레젠테이션 인스턴스를 생성합니다
using (Presentation pres = new Presentation())
{
    // 프레젠테이션의 기본 첫 번째 슬라이드에 접근합니다
    ISlide slide = pres.Slides[0];

    // HTML 콘텐츠를 담을 AutoShape을 추가합니다
    IAutoShape ashape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, pres.SlideSize.Size.Width - 20, pres.SlideSize.Size.Height - 10);

    ashape.FillFormat.FillType = FillType.NoFill;

    // 도형에 텍스트 프레임을 추가합니다
    ashape.AddTextFrame("");

    // 추가된 텍스트 프레임의 모든 단락을 삭제합니다
    ashape.TextFrame.Paragraphs.Clear();

    // 스트림 리더를 사용해 HTML 파일을 로드합니다
    TextReader tr = new StreamReader("file.html");

    // HTML 스트림 리더의 텍스트를 텍스트 프레임에 추가합니다
    ashape.TextFrame.Paragraphs.AddFromHtml(tr.ReadToEnd());

    // 프레젠테이션을 저장합니다
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **단락 텍스트를 HTML로 내보내기**
Aspose.Slides는 단락에 포함된 텍스트를 HTML로 내보내는 기능을 강화했습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스를 인스턴스화하고 원하는 프레젠테이션을 로드합니다.
2. 인덱스를 통해 해당 슬라이드의 참조에 접근합니다.
3. HTML로 내보낼 텍스트가 포함된 도형에 접근합니다.
4. 도형의 [TextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/textframe/)에 접근합니다.
5. `StreamWriter` 인스턴스를 생성하고 새 HTML 파일을 추가합니다.
6. 시작 인덱스를 지정하고 원하는 단락을 내보냅니다.

다음 C# 코드는 PowerPoint 단락 텍스트를 HTML로 내보내는 방법을 보여줍니다:

```c#
// 프레젠테이션 파일을 로드합니다
using (Presentation pres = new Presentation("ExportingHTMLText.pptx"))
{

    // 프레젠테이션의 기본 첫 번째 슬라이드에 접근합니다
    ISlide slide = pres.Slides[0];

    // 필요한 인덱스에 접근합니다
    int index = 0;

    // 추가된 도형에 접근합니다
    IAutoShape ashape = (IAutoShape)slide.Shapes[index];

    StreamWriter sw = new StreamWriter("output_out.html", false, Encoding.UTF8);

    // 복사할 단락 시작 인덱스와 단락 수를 지정하여 단락 데이터를 HTML로 씁니다
    sw.Write(ashape.TextFrame.Paragraphs.ExportToHtml(0, ashape.TextFrame.Paragraphs.Count, null));

    sw.Close();
}
```

## **단락을 이미지로 저장**

이 섹션에서는 [IParagraph](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraph/) 인터페이스로 표현되는 텍스트 단락을 이미지로 저장하는 두 가지 예제를 살펴봅니다. 두 예제 모두 [IShape](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/) 인터페이스의 `GetImage` 메서드를 사용해 단락이 포함된 도형의 이미지를 얻고, 도형 내 단락의 경계를 계산한 뒤 비트맵 이미지로 내보냅니다. 이러한 방법을 통해 PowerPoint 프레젠테이션에서 텍스트의 특정 부분을 추출하여 별도 이미지로 저장할 수 있어 다양한 시나리오에서 활용할 수 있습니다.

예를 들어 sample.pptx라는 파일에 한 슬라이드가 있고, 첫 번째 도형이 세 개의 단락을 포함한 텍스트 상자라고 가정해 보겠습니다.

![세 개의 단락이 있는 텍스트 상자](paragraph_to_image_input.png)

### **예제 1**

이 예제에서는 두 번째 단락을 이미지로 얻습니다. 이를 위해 프레젠테이션 첫 번째 슬라이드의 도형 이미지를 추출하고, 도형 텍스트 프레임에서 두 번째 단락의 경계를 계산합니다. 그런 다음 해당 단락을 새로운 비트맵 이미지에 다시 그려 PNG 형식으로 저장합니다. 이 방법은 특정 단락을 별도 이미지로 저장하면서 정확한 크기와 서식을 유지하려는 경우에 특히 유용합니다.

```csharp
using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// 도형을 메모리에 비트맵으로 저장합니다.
using var shapeImage = firstShape.GetImage();
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// 메모리에서 도형 비트맵을 생성합니다.
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// 두 번째 단락의 경계를 계산합니다.
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();

// 출력 이미지의 크기를 계산합니다 (최소 크기 - 1x1 픽셀).
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// 단락용 비트맵을 준비합니다.
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// 도형 비트맵에서 단락 비트맵으로 단락을 다시 그립니다.
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```

결과:

![단락 이미지](paragraph_to_image_output.png)

### **예제 2**

이 예제에서는 앞 예제에 스케일링 팩터를 추가합니다. 도형을 추출하여 스케일 팩터 `2`로 이미지로 저장하면 더 높은 해상도의 출력이 가능합니다. 그런 다음 스케일을 고려해 단락 경계를 계산합니다. 스케일링은 고해상도 인쇄물 등에서 자세한 이미지가 필요할 때 유용합니다.

```csharp
var imageScaleX = 2f;
var imageScaleY = imageScaleX;

using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// Save the shape in memory as a bitmap with scaling.
using var shapeImage = firstShape.GetImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// Create a shape bitmap from memory.
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// Calculate the boundaries of the second paragraph.
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();
paragraphRectangle.X *= imageScaleX;
paragraphRectangle.Y *= imageScaleY;
paragraphRectangle.Width *= imageScaleX;
paragraphRectangle.Height *= imageScaleY;

// Calculate the size for the output image (minimum size - 1x1 pixel).
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// Prepare a bitmap for the paragraph.
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// Redraw the paragraph from the shape bitmap to the paragraph bitmap.
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```

## **FAQ**

**텍스트 프레임 안에서 줄 바꿈을 완전히 비활성화할 수 있나요?**

예. 텍스트 프레임의 줄 바꿈 설정([WrapText](https://reference.aspose.com/slides/ko/net/aspose.slides/textframeformat/wraptext/))을 사용해 줄 바꿈을 끄면 프레임 가장자리에서 줄이 잘리지 않습니다.

**특정 단락의 정확한 슬라이드 상 위치를 어떻게 얻나요?**

단락(또는 단일 구절)의 경계 사각형을 가져와 슬라이드 상에서의 정확한 위치와 크기를 확인할 수 있습니다.

**단락 정렬(좌/우/가운데/양쪽 정렬)은 어디서 제어하나요?**

[Alignment](https://reference.aspose.com/slides/ko/net/aspose.slides/paragraphformat/alignment/)은 [ParagraphFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/paragraphformat/)에서 단락 수준으로 설정되며, 개별 구절 서식에 관계없이 전체 단락에 적용됩니다.

**단락의 일부(예: 한 단어)만 맞춤법 검사 언어를 설정할 수 있나요?**

예. 언어는 구절 수준([PortionFormat.LanguageId](https://reference.aspose.com/slides/ko/net/aspose.slides/baseportionformat/languageid/))에서 설정되므로 하나의 단락 안에 여러 언어를 함께 사용할 수 있습니다.