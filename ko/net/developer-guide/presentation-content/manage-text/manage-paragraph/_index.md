---
title: .NET에서 PowerPoint 텍스트 단락 관리
linktitle: 단락 관리
type: docs
weight: 40
url: /ko/net/manage-paragraph/
aliases:
  - /net/paragraph/
  - /net/portion/
keywords:
- 텍스트 추가
- 단락 추가
- 텍스트 관리
- 단락 관리
- 글머리표 관리
- 단락 들여쓰기
- 내어쓰기
- 단락 글머리표
- 번호 매기기 목록
- 글머리표 목록
- 단락 속성
- HTML 가져오기
- 텍스트를 HTML로
- 단락을 HTML로
- 단락을 이미지로
- 텍스트를 이미지로
- 단락 내보내기
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 단락, 구역, 글머리표, 번호 매기기 목록, 들여쓰기, HTML 콘텐츠 및 단락 이미지를 만들고 서식 지정하는 방법을 배웁니다."
---
## **개요**

Aspose.Slides for .NET는 텍스트를 텍스트 프레임, 단락 및 구역의 계층 구조로 나타냅니다:

* [ITextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/) 은 도형 내 텍스트 컨테이너를 나타내며 단락 컬렉션에 대한 접근을 제공합니다.
* [IParagraph](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraph/) 은 텍스트 프레임의 한 단락을 나타내며 구역 및 단락 수준 서식에 대한 접근을 제공합니다.
* [IPortion](https://reference.aspose.com/slides/ko/net/aspose.slides/iportion/) 은 단락 내 텍스트 실행을 나타냅니다. 각 구역은 자체 텍스트와 문자 수준 서식을 가질 수 있습니다.

따라서 단락은 여러 구역을 사용하여 서로 다른 글꼴, 색상, 크기 및 기타 서식을 가진 텍스트를 포함할 수 있습니다.

## **단락 만들기 및 서식 지정**

### **여러 구역이 포함된 단락 만들기**

다음 단계는 각 구역이 세 개씩 포함된 세 개의 단락을 가진 텍스트 프레임을 생성합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스를 인스턴스화합니다.
2. 인덱스를 통해 해당 슬라이드의 참조에 접근합니다.
3. 슬라이드에 직사각형 [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/) 을 추가합니다.
4. 도형의 [ITextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/) 에 접근합니다.
5. 기본 단락을 사용하고 두 개의 추가 [IParagraph](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraph/) 객체를 텍스트 프레임에 추가합니다.
6. 각 단락에 세 구역이 포함되도록 충분한 [IPortion](https://reference.aspose.com/slides/ko/net/aspose.slides/iportion/) 객체를 추가합니다. 기본 단락에는 이미 비어 있는 구역이 하나 포함되어 있습니다.
7. 각 구역의 텍스트를 설정합니다.
8. [IPortion.PortionFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/iportion/portionformat/) 을 통해 문자 수준 서식을 적용합니다.
9. 수정된 프레젠테이션을 저장합니다.

다음 C# 예제가 위 단계를 구현합니다:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);
var textFrame = shape.TextFrame;

var firstParagraph = textFrame.Paragraphs[0];
firstParagraph.Portions.Add(new Portion());
firstParagraph.Portions.Add(new Portion());

var secondParagraph = new Paragraph();
secondParagraph.Portions.Add(new Portion());
secondParagraph.Portions.Add(new Portion());
secondParagraph.Portions.Add(new Portion());
textFrame.Paragraphs.Add(secondParagraph);

var thirdParagraph = new Paragraph();
thirdParagraph.Portions.Add(new Portion());
thirdParagraph.Portions.Add(new Portion());
thirdParagraph.Portions.Add(new Portion());
textFrame.Paragraphs.Add(thirdParagraph);

var paragraphCount = textFrame.Paragraphs.Count;
for (var paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    var paragragaph = textFrame.Paragraphs[paragraphIndex];
    var portionCount = paragragaph.Portions.Count;
    for (var portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        var portion = paragragaph.Portions[portionIndex];
        portion.Text = $"Portion {paragraphIndex + 1}.{portionIndex + 1}";

        if (portionIndex == 0)
        {
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;
            portion.PortionFormat.FontBold = NullableBool.True;
            portion.PortionFormat.FontHeight = 15;
        }
        else if (portionIndex == 1)
        {
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;
            portion.PortionFormat.FontItalic = NullableBool.True;
            portion.PortionFormat.FontHeight = 18;
        }
    }
}

presentation.Save("paragraphs_with_portions.pptx", SaveFormat.Pptx);
```

## **글머리표 및 번호 매기기 목록 만들기**

### **글머리표 또는 번호 매기기 목록 만들기**

글머리표와 번호 매기기는 관련 항목을 쉽게 스캔할 수 있게 합니다. Aspose.Slides에서 목록 설정은 [IBulletFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/ibulletformat/) 을 통해 정의됩니다.

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스를 인스턴스화합니다.
2. 인덱스를 통해 해당 슬라이드의 참조에 접근합니다.
3. 선택된 슬라이드에 [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/) 을 추가합니다.
4. 도형의 [ITextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/) 에 접근합니다.
5. 텍스트 프레임에서 기본 단락을 제거합니다.
6. 기호 글머리표용 [Paragraph](https://reference.aspose.com/slides/ko/net/aspose.slides/paragraph/) 을 생성합니다.
7. [IBulletFormat.Type](https://reference.aspose.com/slides/ko/net/aspose.slides/ibulletformat/type/) 을 [BulletType.Symbol](https://reference.aspose.com/slides/ko/net/aspose.slides/bullettype/) 로 설정하고 글머리 기호 문자를 지정합니다.
8. 단락 텍스트, 들여쓰기, 글머리 색상 및 글머리 높이를 설정합니다.
9. 단락을 텍스트 프레임에 추가합니다.
10. 두 번째 단락을 만들고 [IBulletFormat.Type](https://reference.aspose.com/slides/ko/net/aspose.slides/ibulletformat/type/) 을 [BulletType.Numbered](https://reference.aspose.com/slides/ko/net/aspose.slides/bullettype/) 로 설정합니다.
11. 번호 매기기 글머리 스타일을 구성하고 단락을 텍스트 프레임에 추가합니다.
12. 프레젠테이션을 저장합니다.

다음 C# 예제가 기호 글머리표와 번호 매기기 글머리표를 만들습니다:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var symbolParagraph = new Paragraph { Text = "Welcome to Aspose.Slides" };
symbolParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
symbolParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
symbolParagraph.ParagraphFormat.Indent = 25;
symbolParagraph.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
symbolParagraph.ParagraphFormat.Bullet.Color.Color = Color.Black;
symbolParagraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
symbolParagraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(symbolParagraph);

var numberedParagraph = new Paragraph { Text = "This is a numbered item" };
numberedParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
numberedParagraph.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;
numberedParagraph.ParagraphFormat.Indent = 25;
numberedParagraph.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
numberedParagraph.ParagraphFormat.Bullet.Color.Color = Color.Black;
numberedParagraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
numberedParagraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(numberedParagraph);

presentation.Save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx);
```

### **그림 글머리표 사용**

그림 글머리표를 사용하면 기호나 숫자 대신 사용자 정의 이미지를 사용할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스를 인스턴스화합니다.
2. 인덱스를 통해 해당 슬라이드의 참조에 접근합니다.
3. [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/) 을 추가하고 해당 [ITextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/) 에 접근합니다.
4. 텍스트 프레임에서 기본 단락을 제거합니다.
5. 글머리 이미지를 로드하고 [IPPImage](https://reference.aspose.com/slides/ko/net/aspose.slides/ippimage/) 으로 프레젠테이션의 이미지 컬렉션에 추가합니다.
6. [Paragraph](https://reference.aspose.com/slides/ko/net/aspose.slides/paragraph/) 을 생성하고 텍스트를 설정합니다.
7. [IBulletFormat.Type](https://reference.aspose.com/slides/ko/net/aspose.slides/ibulletformat/type/) 을 [BulletType.Picture](https://reference.aspose.com/slides/ko/net/aspose.slides/bullettype/) 로 설정합니다.
8. [IBulletFormat.Picture](https://reference.aspose.com/slides/ko/net/aspose.slides/ibulletformat/picture/) 로 이미지를 지정하고 글머리 높이를 설정합니다.
9. 단락을 텍스트 프레임에 추가합니다.
10. 수정된 프레젠테이션을 저장합니다.

다음 C# 예제가 그림 글머리표를 만들습니다:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var bulletImage = Images.FromFile("bullets.png");
var presentationImage = presentation.Images.AddImage(bulletImage);

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph = new Paragraph { Text = "Welcome to Aspose.Slides" };
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = presentationImage;
paragraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(paragraph);

presentation.Save("picture_bullet.pptx", SaveFormat.Pptx);
presentation.Save("picture_bullet.ppt", SaveFormat.Ppt);
```

### **다단계 목록 만들기**

[IParagraphFormat.Depth](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraphformat/depth/) 를 설정하여 목록의 서로 다른 수준에 단락을 배치합니다. 최상위 수준은 `0` 깊이를 가집니다.

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 을 만들고 슬라이드에 접근합니다.
2. [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/) 을 추가하고 해당 텍스트 프레임에서 기본 단락을 제거합니다.
3. 네 개의 단락을 만들고 글머리 기호를 구성합니다.
4. 각 단락의 [IParagraphFormat.Depth](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraphformat/depth/) 값을 `0`, `1`, `2`, `3` 으로 설정합니다.
5. 단락을 텍스트 프레임에 추가하고 프레젠테이션을 저장합니다.

다음 C# 예제가 네 수준의 글머리표 목록을 만들습니다:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "Content" };
firstParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
firstParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.Depth = 0;

var secondParagraph = new Paragraph { Text = "Second level" };
secondParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
secondParagraph.ParagraphFormat.Bullet.Char = '-';
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.Depth = 1;

var thirdParagraph = new Paragraph { Text = "Third level" };
thirdParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
thirdParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
thirdParagraph.ParagraphFormat.Depth = 2;

var fourthParagraph = new Paragraph { Text = "Fourth level" };
fourthParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
fourthParagraph.ParagraphFormat.Bullet.Char = '-';
fourthParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
fourthParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
fourthParagraph.ParagraphFormat.Depth = 3;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);
textFrame.Paragraphs.Add(thirdParagraph);
textFrame.Paragraphs.Add(fourthParagraph);

presentation.Save("multilevel_list.pptx", SaveFormat.Pptx);
```

### **번호 매기기 항목을 사용자 지정 값으로 시작하기**

[IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/ko/net/aspose.slides/ibulletformat/numberedbulletstartwith/) 를 사용하여 번호 매기기 단락에 처음 표시되는 숫자를 설정합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 을 만들고 슬라이드에 [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/) 를 추가합니다.
2. 도형의 텍스트 프레임에서 기본 단락을 제거합니다.
3. 세 개의 번호 매기기 단락을 생성합니다.
4. 각 단락에 대해 [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/ko/net/aspose.slides/ibulletformat/numberedbulletstartwith/) 를 각각 `2`, `3`, `7` 로 설정합니다.
5. 단락을 텍스트 프레임에 추가하고 프레젠테이션을 저장합니다.

다음 C# 예제가 각 단락에 사용자 지정 시작 번호를 할당합니다:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "Start at 2" };
firstParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
firstParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 2;
textFrame.Paragraphs.Add(firstParagraph);

var secondParagraph = new Paragraph { Text = "Start at 3" };
secondParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
secondParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 3;
textFrame.Paragraphs.Add(secondParagraph);

var thirdParagraph = new Paragraph { Text = "Start at 7" };
thirdParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
thirdParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 7;
textFrame.Paragraphs.Add(thirdParagraph);

presentation.Save("custom_numbered_list.pptx", SaveFormat.Pptx);
```

## **단락 레이아웃 및 종료 속성 제어**

### **첫 번째 줄 들여쓰기 설정**

[IParagraphFormat.Indent](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraphformat/indent/) 속성을 사용하여 단락의 첫 번째 줄 들여쓰기를 제어합니다. 이 속성은 단락의 왼쪽 여백에 상대적인 첫 번째 줄만 이동시킵니다. 양수 값은 첫 번째 줄을 오른쪽으로 이동시키고, 나머지 줄은 단락 본문에 맞춥니다.

전체 단락을 이동하려면 [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraphformat/marginleft/) 를 사용하고, 첫 번째 줄만 이동하려면 [IParagraphFormat.Indent](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraphformat/indent/) 를 사용합니다.

아래 예제는 여러 단락을 생성하고 서로 다른 [IParagraphFormat.Indent](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraphformat/indent/) 값을 적용하여 첫 번째 줄 들여쓰기가 단락 레이아웃에 어떻게 영향을 주는지 보여줍니다.

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 대상 슬라이드에 접근합니다.
3. 슬라이드에 직사각형 [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/) 을 추가합니다.
4. 도형의 [ITextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/) 에 접근하고 기본 단락을 제거합니다.
5. 여러 단락을 만들고 각각 다른 [Indent](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraphformat/indent/) 값을 설정합니다.
6. 단락을 텍스트 프레임에 추가합니다.
7. 수정된 프레젠테이션을 저장합니다.

다음 코드는 단락 들여쓰기를 설정하는 방법을 보여줍니다:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "No first-line indent. Wrapped lines start at the same position as the first line." };
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.MarginLeft = 20;
firstParagraph.ParagraphFormat.Indent = 0;

var secondParagraph = new Paragraph { Text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.MarginLeft = 20;
secondParagraph.ParagraphFormat.Indent = 20;

var thirdParagraph = new Paragraph { Text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see." };
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
thirdParagraph.ParagraphFormat.MarginLeft = 20;
thirdParagraph.ParagraphFormat.Indent = 40;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);
textFrame.Paragraphs.Add(thirdParagraph);

presentation.Save("paragraph_indent.pptx", SaveFormat.Pptx);
```

결과:

![The first-line indent of the paragraphs](first_line_indent.png)

### **내어쓰기 설정**

내어쓰기는 첫 번째 줄이 나머지 줄보다 왼쪽에 시작되는 단락 레이아웃입니다. Aspose.Slides에서는 [IParagraphFormat.Indent](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraphformat/indent/) 속성을 사용하여 이 효과를 만들 수 있습니다. `Indent` 를 음수 값으로 설정하면 단락 본문에 비해 첫 번째 줄이 왼쪽으로 이동합니다.

실제로는 [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraphformat/marginleft/) 이 단락 본문의 왼쪽 위치를 정의하고, [IParagraphFormat.Indent](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraphformat/indent/) 가 그 여백에 대해 첫 번째 줄의 위치를 정의합니다. 내어쓰기를 만들려면 양수 `MarginLeft` 값과 음수 `Indent` 값을 설정합니다.

이 서식은 참고문헌, 인용문, 용어 사전 항목 등 줄이 단락 본문에 맞추어야 하는 경우에 유용합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 대상 슬라이드에 접근합니다.
3. 슬라이드에 직사각형 [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/) 을 추가합니다.
4. 도형의 [ITextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/) 에 접근하고 기본 단락을 제거합니다.
5. 각 단락에 대해 양의 [MarginLeft](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraphformat/marginleft/) 값을 설정합니다.
6. 내어쓰기 효과를 만들기 위해 음의 [Indent](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraphformat/indent/) 값을 설정합니다.
7. 단락을 텍스트 프레임에 추가합니다.
8. 수정된 프레젠테이션을 저장합니다.

다음 코드는 단락에 내어쓰기를 설정하는 방법을 보여줍니다:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body." };
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.MarginLeft = 40;
firstParagraph.ParagraphFormat.Indent = -20;

var secondParagraph = new Paragraph { Text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.MarginLeft = 60;
secondParagraph.ParagraphFormat.Indent = -30;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);

presentation.Save("hanging_indent.pptx", SaveFormat.Pptx);
```

결과:

![The hanging indent of the paragraphs](hanging_indent.png)

### **끝 단락 실행 속성 설정**

[IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraph/endparagraphportionformat/) 속성은 단락 끝 마크의 서식을 제어합니다. 다음 예제는 두 번째 단락의 끝 마크에 글꼴 크기와 라틴 글꼴을 지정합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 을 로드하고 슬라이드에 접근합니다.
2. [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/) 을 추가하고 기본 단락을 제거합니다.
3. 두 개의 단락을 만들고 텍스트 구역을 추가합니다.
4. 두 번째 단락의 끝 마크용 [PortionFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/portionformat/) 을 생성합니다.
5. [IBasePortionFormat.FontHeight](https://reference.aspose.com/slides/ko/net/aspose.slides/ibaseportionformat/fontheight/) 와 [IBasePortionFormat.LatinFont](https://reference.aspose.com/slides/ko/net/aspose.slides/ibaseportionformat/latinfont/) 를 설정합니다.
6. 형식을 [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraph/endparagraphportionformat/) 에 할당하고 프레젠테이션을 저장합니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Test.pptx");
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph();
firstParagraph.Portions.Add(new Portion("Sample text"));

var secondParagraph = new Paragraph();
secondParagraph.Portions.Add(new Portion("Sample text 2"));

var endParagraphFormat = new PortionFormat();
endParagraphFormat.FontHeight = 48;
endParagraphFormat.LatinFont = new FontData("Times New Roman");
secondParagraph.EndParagraphPortionFormat = endParagraphFormat;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);

presentation.Save("end_paragraph_format.pptx", SaveFormat.Pptx);
```

## **단락 내용 가져오기 및 내보내기**

### **HTML 텍스트를 단락에 가져오기**

[ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/ko/net/aspose.slides/paragraphcollection/addfromhtml/) 을 사용하면 HTML 마크업을 텍스트 프레임의 단락 및 구역으로 변환할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
2. 슬라이드에 접근하고 [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/) 를 추가합니다.
3. 도형의 [ITextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/) 에 접근하고 기본 단락을 제거합니다.
4. 소스 HTML 파일을 읽습니다.
5. HTML 문자열을 [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/ko/net/aspose.slides/paragraphcollection/addfromhtml/) 에 전달합니다.
6. 수정된 프레젠테이션을 저장합니다.

다음 C# 예제가 텍스트 프레임에 HTML을 가져옵니다:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shapeWidth = presentation.SlideSize.Size.Width - 20;
var shapeHeight = presentation.SlideSize.Size.Height - 20;
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
shape.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Paragraphs.Clear();

using var reader = new StreamReader("file.html");
var html = reader.ReadToEnd();
shape.TextFrame.Paragraphs.AddFromHtml(html);

presentation.Save("html_text.pptx", SaveFormat.Pptx);
```

### **단락 텍스트를 HTML로 내보내기**

[ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/ko/net/aspose.slides/paragraphcollection/exporttohtml/) 을 사용하면 선택한 단락 범위를 HTML로 내보낼 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 만들고 원하는 프레젠테이션을 로드합니다.
2. 슬라이드에 접근하고 텍스트가 포함된 [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/) 를 찾습니다.
3. 도형의 [ITextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/) 에 접근합니다.
4. 시작 단락 인덱스와 내보낼 단락 수를 지정하여 [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/ko/net/aspose.slides/paragraphcollection/exporttohtml/) 를 호출합니다.
5. 반환된 HTML 문자열을 파일에 씁니다.

다음 C# 예제가 첫 번째 텍스트 도형의 모든 단락을 내보냅니다:

```csharp
using System;
using System.IO;
using System.Text;
using Aspose.Slides;

using var presentation = new Presentation("ExportingHTMLText.pptx");
var shape = presentation.Slides[0].Shapes[0];

if (shape is IAutoShape textShape && textShape.TextFrame != null)
{
    var paragraphs = textShape.TextFrame.Paragraphs;
    var html = paragraphs.ExportToHtml(0, paragraphs.Count, null);
    using var writer = new StreamWriter("paragraphs.html", false, Encoding.UTF8);
    writer.Write(html);
}
else
{
    Console.WriteLine("The first shape is not a text shape.");
}
```

### **단락을 이미지로 렌더링**

[IParagraph.GetImage](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraph/getimage/) 은 개별 단락을 직접 렌더링하고 [IImage](https://reference.aspose.com/slides/ko/net/aspose.slides/iimage/) 을 반환합니다. 반환된 이미지는 [IImage.Save](https://reference.aspose.com/slides/ko/net/aspose.slides/iimage/save/) 로 파일이나 스트림에 저장할 수 있습니다. 포함된 도형을 렌더링하거나 비트맵을 수동으로 자를 필요가 없습니다.

[IParagraph.GetImage](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraph/getimage/) 은 단락을 상위 컬렉션에서 찾을 수 없거나 유효한 렌더링 경계가 없거나 렌더링할 수 없는 경우 `null` 을 반환할 수 있습니다. 저장하기 전에 결과를 확인하고 사용 후 반환된 이미지를 폐기하십시오.

#### **기본 크기로 단락 렌더링**

sample.pptx 라는 프레젠테이션 파일에 슬라이드가 하나 있고, 첫 번째 도형이 세 개의 단락을 포함한 텍스트 상자라고 가정합니다.

![The text box with three paragraphs](paragraph_to_image_input.png)

다음 예제는 두 번째 단락을 기본 크기로 렌더링하고 PNG 형식으로 반환된 이미지를 저장합니다. `using` 선언을 사용하여 이미지가 올바르게 폐기되도록 합니다.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var shape = presentation.Slides[0].Shapes[0];
if (shape is IAutoShape textShape && 
    textShape.TextFrame != null && 
    textShape.TextFrame.Paragraphs.Count > 1)
{
    var paragraph = textShape.TextFrame.Paragraphs[1];
    using var paragraphImage = paragraph.GetImage();

    if (paragraphImage != null)
    {
        paragraphImage.Save("paragraph.png", ImageFormat.Png);
    }
    else
    {
        Console.WriteLine("The paragraph could not be rendered.");
    }
}
else
{
    Console.WriteLine("The expected text shape or paragraph was not found.");
}
```

결과:

![The paragraph image](paragraph_to_image_output.png)

#### **표 셀에서 스케일링을 적용하여 단락 렌더링**

`float scaleX` 와 `float scaleY` 매개변수를 받아 가로·세로 스케일 팩터를 설정하는 [IParagraph.GetImage](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraph/getimage/) 오버로드를 사용합니다. 다음 예제는 표를 만든 후 첫 번째 셀의 단락을 기본 너비와 높이의 두 배로 렌더링하고 PNG 이미지로 저장합니다.

```csharp
using System;
using Aspose.Slides;

var scaleX = 2f;
var scaleY = 2f;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var table = slide.Shapes.AddTable(50, 50, new[] { 300d }, new[] { 80d });
var paragraph = table[0, 0].TextFrame.Paragraphs[0];
paragraph.Text = "Text in a table cell";

using var paragraphImage = paragraph.GetImage(scaleX, scaleY);
if (paragraphImage != null)
{
    paragraphImage.Save("table_paragraph.png", ImageFormat.Png);
}
else
{
    Console.WriteLine("The paragraph could not be rendered.");
}
```

스케일 팩터 `1` 은 해당 축을 기본 픽셀 크기로 유지합니다. 예를 들어 두 축 모두 `2` 로 설정하면 이미지의 너비와 높이가 대략 두 배가 되어 픽셀 수가 네 배가 됩니다. 큰 팩터는 확대하거나 고해상도 출력 시 텍스트를 더 선명하게 하지만 메모리 사용량과 파일 크기도 증가합니다. `1` 이하의 팩터는 세부 사항이 적은 작은 이미지를 생성합니다. 비율을 유지하려면 같은 팩터를 사용하고, 서로 다른 가로·세로 팩터를 사용하면 출력이 각각 늘어나거나 줄어듭니다.

전체 도형을 렌더링하려면 [IShape.GetImage](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/getimage/) 를 사용합니다. 단락 전용 이미지는 [IParagraph.GetImage](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraph/getimage/) 를 사용하십시오.

## **FAQ**

**텍스트 프레임 내부에서 줄 바꿈을 완전히 비활성화할 수 있나요?**

예. [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframeformat/wraptext/) 을 설정하여 텍스트 프레임 가장자리에서 줄이 깨지지 않도록 할 수 있습니다.

**특정 단락의 정확한 슬라이드 내 경계는 어떻게 얻을 수 있나요?**

[IParagraph.GetRect](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraph/getrect/) 을 사용하여 단락의 경계 사각형을 가져옵니다. [IPortion.GetRect](https://reference.aspose.com/slides/ko/net/aspose.slides/iportion/getrect/) 은 개별 구역의 경계를 제공합니다.

**단락 정렬(왼쪽, 오른쪽, 가운데, 양쪽 맞춤)은 어디에서 제어되나요?**

[IParagraphFormat.Alignment](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraphformat/alignment/) 은 단락 수준 설정이며 개별 구역 서식과 무관하게 전체 단락에 적용됩니다.

**단락의 일부에 교정 언어를 설정할 수 있나요?**

예. 개별 구역에 대해 [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/ko/net/aspose.slides/ibaseportionformat/languageid/) 을 설정하면 하나의 단락에 여러 언어 텍스트를 포함할 수 있습니다.