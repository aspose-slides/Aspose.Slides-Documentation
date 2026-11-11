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
- 글머리 기호 관리
- 단락 들여쓰기
- 내어쓰기
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
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 단락, 구문, 글머리 기호, 번호 매기기 목록, 들여쓰기, HTML 콘텐츠 및 단락 이미지를 만들고 서식 지정하는 방법을 배웁니다."
---
## **개요**

Aspose.Slides for .NET은 텍스트를 텍스트 프레임, 단락 및 구문(Portion)의 계층 구조로 나타냅니다:

* [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/)은 도형 내의 텍스트 컨테이너를 나타내며 해당 단락 컬렉션에 대한 접근을 제공합니다.
* [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/)은 텍스트 프레임 내의 하나의 단락을 나타내며 구문 및 단락 수준 서식에 대한 접근을 제공합니다.
* [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/)은 단락 내의 텍스트 실행을 나타냅니다. 각 구문은 자체 텍스트와 문자 수준 서식을 가질 수 있습니다.

따라서 단락은 여러 구문을 사용하여 서로 다른 글꼴, 색상, 크기 및 기타 서식을 가진 텍스트를 포함할 수 있습니다.

## **단락 만들기 및 서식 지정**

도형의 텍스트 프레임에서 단락을 만들고 구문을 사용하여 개별 텍스트 실행을 서식 지정합니다. 이 섹션에서는 각 단락에 여러 구문을 결합하고 서로 다른 색상, 글꼴 크기 및 스타일을 적용하는 방법을 보여줍니다.

### **여러 구문이 포함된 단락 만들기**

다음 C# 예제는 각각 세 개의 텍스트 실행을 포함하는 세 개의 단락을 [IParagraph.Portions](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/portions/) 컬렉션에 생성합니다. 기본 단락과 빈 구문을 재사용한 뒤 나머지 단락과 구문을 추가합니다. 서식은 [IPortion.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportion/portionformat/)을 통해 적용됩니다: 각 단락의 첫 번째 구문은 빨간색, 굵게, 15포인트이고, 두 번째는 파란색, 이탤릭, 18포인트이며, 세 번째 구문은 기본 서식을 유지합니다:

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

## **글머리 기호 및 번호 매기기 목록 만들기**

단락 텍스트를 기호, 번호 또는 사용자 지정 이미지가 있는 목록으로 구성합니다. 이 섹션의 예제는 글머리 기호 서식, 다중 수준 목록 및 사용자 지정 시작 번호를 다룹니다.

### **글머리 기호 또는 번호 매기기 목록 만들기**

글머리 기호와 번호 매기기는 관련 항목을 더 쉽게 스캔할 수 있게 합니다. Aspose.Slides에서 목록 설정은 [IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/)을 통해 정의됩니다.

이 C# 예제는 동일한 텍스트 프레임에 기호 글머리 기호와 번호 매기기 항목을 추가합니다. [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/)은 글머리 유형을 선택하고, [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/)은 기호를 제공하며, [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstyle/)은 번호 매기기 스타일을 선택합니다. 두 항목 모두 높이가 100%이고 단락 들여쓰기가 25포인트인 검은색 글머리 기호를 사용합니다:

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

### **그림 글머리 기호 사용**

그림 글머리 기호를 사용하면 기호나 번호 대신 사용자 지정 이미지를 사용할 수 있습니다.

이 C# 예제는 프레젠테이션의 이미지 컬렉션에 [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/)로 이미지를 추가하고 이를 단락 글머리 기호로 사용합니다. [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/)을 그림 글머리 기호로 설정하고, 이미지는 [IBulletFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/picture/)를 통해 할당합니다. [IBulletFormat.Height](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/height/)을 100%로 설정하여 글머리 기호가 단락 텍스트에 상대적으로 크기를 갖게 합니다:

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

### **다중 수준 목록 만들기**

[IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/)를 설정하여 단락을 목록의 서로 다른 수준에 배치합니다. 최상위 수준의 깊이는 `0`입니다.

이 C# 예제는 네 개의 단락에 대해 [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) 값을 0부터 3까지 할당하여 하나의 텍스트 프레임 내에 계층 구조를 만듭니다. 각 단락은 기호 글머리 기호를 사용하고, [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/)은 원형 글머리와 하이픈을 번갈아 사용하여 인접 수준을 구분합니다:

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

### **사용자 지정 값에서 번호 매기기 목록 시작**

[IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/)를 사용하여 번호 매기기 단락에 표시되는 초기 번호를 설정합니다.

이 C# 예제는 세 개의 단락에 대해 번호 매기기를 사용하도록 [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/)을 설정하고, [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) 값을 각각 2, 3, 7로 지정합니다. 시작 값은 각 단락마다 별도로 구성되어 표시되는 번호가 값들을 건너뛰도록 합니다:

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

## **단락 레이아웃 및 끝 속성 제어**

단락 여백과 들여쓰기를 조정하여 첫 번째 줄과 줄 바꿈된 줄의 위치를 제어합니다. 또한 눈에 보이는 텍스트 구문과 별도로 단락 끝 표시를 서식 지정할 수 있습니다.

### **첫 줄 들여쓰기 설정**

[IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) 속성을 사용하여 단락의 첫 줄 들여쓰기를 제어합니다. 이 속성은 단락 왼쪽 여백에 대해 첫 번째 줄만 이동시킵니다. 양수 값은 첫 줄을 오른쪽으로 이동하고, 나머지 줄은 단락 본문에 맞춰 정렬됩니다.

전체 단락을 이동해야 할 경우에는 [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/)를 사용합니다. 첫 줄만 이동해야 할 경우에는 [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/)를 사용합니다.

다음 예제는 세 개의 단락에 동일한 [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) 20포인트와 [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) 값을 각각 0, 20, 40포인트로 지정합니다. 첫 번째 줄은 점점 더 큰 오프셋에서 시작하고, 줄 바꿈된 줄은 동일한 왼쪽 여백을 유지합니다:

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

![단락의 첫 줄 들여쓰기](first_line_indent.png)

### **내어쓰기 설정**

내어쓰기는 첫 번째 줄이 나머지 줄보다 왼쪽에 시작되는 단락 레이아웃입니다. Aspose.Slides에서는 [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) 속성을 사용하여 이 효과를 만듭니다. `Indent`를 음수 값으로 설정하면 첫 번째 줄이 단락 본문에 대해 왼쪽으로 이동합니다.

실제로는 [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/)가 단락 본문의 왼쪽 위치를 정의하고, [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/)가 해당 여백에 대한 첫 번째 줄의 위치를 정의합니다. 내어쓰기를 만들려면 양수 `MarginLeft` 값과 음수 `Indent` 값을 설정합니다.

이 서식은 참고문헌, 인용, 용어 설명 및 줄 바꿈된 줄이 첫 번째 줄의 첫 문자 아래가 아니라 단락 본문 아래에 정렬되어야 하는 기타 단락에 유용합니다.

다음 C# 예제는 [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) 값을 40과 60포인트로, [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) 값을 각각 -20과 -30포인트로 지정합니다. 각 단락에서 첫 번째 줄은 줄 바꿈된 줄보다 왼쪽에 시작되며, 두 번째 단락은 더 깊은 내어쓰기를 가집니다:

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

![단락의 내어쓰기](hanging_indent.png)

### **단락 끝 실행 속성 설정**

[IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/endparagraphportionformat/) 속성은 단락 끝 표시의 서식을 제어합니다. 다음 예제는 [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/)을 생성하고 [IBasePortionFormat.FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/)를 48포인트, [IBasePortionFormat.LatinFont](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/latinfont/)을 Times New Roman으로 설정합니다. 이 서식을 두 번째 단락의 끝 표시에 할당하고, 눈에 보이는 텍스트 구문은 변경하지 않습니다:

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

## **렌더링된 줄 수 계산**

줄 끝에서 자동 줄 바꿈 및 구두점에 영향을 주는 단락 규칙에 대해서는 [Control Line Breaking](/slides/ko/net/text-formatting/#control-line-breaking) 및 [Control Hanging Punctuation](/slides/ko/net/text-formatting/#control-hanging-punctuation)을 참조하십시오.

[IParagraph.GetLinesCount](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getlinescount/)를 사용하여 텍스트 레이아웃 후 단락이 차지하는 줄 수를 계산할 수 있습니다(자동 줄 바꿈 포함). 이는 프레젠테이션 템플릿에서 텍스트 길이와 레이아웃을 확인할 때 유용합니다.

단락은 [ITextFrame.Paragraphs](https://reference.aspose.com/slides/net/aspose.slides/itextframe/paragraphs/)의 한 항목이며, 여러 렌더링된 줄을 차지할 수 있습니다. 단락 내에 명시적 줄 바꿈이 있으면 새로운 줄이 생성되지만 새로운 단락은 생성되지 않습니다. 자동 줄 바꿈은 텍스트에 명시적 줄 바꿈 문자를 삽입하지 않고 가용 너비에 따라 줄을 생성합니다. 따라서 단락 수나 줄 바꿈 문자 수를 세는 것은 렌더링된 줄 수를 제공하지 않습니다.

다음 예제는 텍스트 도형을 만들고, 줄 수를 계산한 뒤 도형을 좁히고, 텍스트를 짧은 문자열로 교체합니다. 예제는 [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/)을 활성화하고 [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/)를 비활성화하여 도형 너비가 자동 텍스트 축소나 도형 크기 조정 없이 줄 바꿈을 제어하도록 합니다. 각 측정은 [IParagraph.GetLinesCount](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getlinescount/)를 사용합니다. 도형 크기는 포인트 단위입니다. 마지막으로 예제는 또 다른 단락을 추가하고 텍스트 프레임 전체에 대한 줄 수를 합산합니다:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 200);
var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;

var paragraph = textFrame.Paragraphs[0];
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 20;
paragraph.Text = "This text demonstrates how automatic wrapping changes the number of rendered lines.";
Console.WriteLine($"Original width: {paragraph.GetLinesCount()}");

shape.Width = 150;
Console.WriteLine($"Narrower shape: {paragraph.GetLinesCount()}");

paragraph.Text = "Short text.";
Console.WriteLine($"Shorter text: {paragraph.GetLinesCount()}");

var secondParagraph = new Paragraph { Text = "Another paragraph." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 20;
textFrame.Paragraphs.Add(secondParagraph);

var totalLineCount = 0;
foreach (var currentParagraph in textFrame.Paragraphs)
{
    totalLineCount += currentParagraph.GetLinesCount();
}
Console.WriteLine($"Total lines in the text frame: {totalLineCount}");
```

이 텍스트와 이러한 크기로 도형을 좁히면 줄 수가 증가하고, 짧은 문자열로 교체하면 줄 수가 감소합니다. 정확한 개수는 글꼴 가용성 및 대체, 글꼴 크기, 여백, 들여쓰기, 줄 바꿈 및 자동 맞춤 설정에 따라 달라질 수 있습니다. 템플릿을 확인할 때는 대상 환경에 맞는 글꼴 및 레이아웃 설정을 사용하십시오.

줄 수만으로 텍스트가 컨테이너를 초과했는지 판단할 수 없습니다. 가용 높이, 줄 높이, 단락 및 줄 간격, 자동 맞춤 동작 등도 중요합니다; 자동 줄 바꿈이 비활성화된 경우 단일 줄이라도 가용 너비를 초과할 수 있습니다.

## **단락 내용 가져오기 및 내보내기**

HTML을 사용하여 텍스트를 프레젠테이션으로 가져오거나 기존 단락을 외부에서 사용할 수 있도록 내보낼 수 있습니다. 이 섹션에서는 테이블 셀 내 단락을 포함한 개별 단락을 이미지로 렌더링하는 방법도 보여줍니다.

### **HTML 텍스트를 단락으로 가져오기**

[ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/)를 사용하여 HTML 마크업을 텍스트 프레임의 단락 및 구문으로 변환합니다.

이 C# 예제는 파일에서 HTML을 읽고 마크업을 [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/)에 전달합니다. 텍스트 프레임의 기본 단락을 지워 프레임에 가져온 콘텐츠만 포함하도록 합니다. 직사각형 도형은 슬라이드 각 면에 10포인트 여백을 남깁니다:

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

[ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/exporttohtml/)를 사용하여 선택된 단락 범위를 HTML로 내보냅니다. 프레젠테이션 텍스트를 웹사이트에 재사용할 때 프레젠테이션의 글꼴, 크기 또는 텍스트 상자 스타일을 유지하지 않으면서 로컬 강조를 보존하고 싶을 수 있습니다. [TextToHtmlConversionOptions.TextInheritanceLimit](https://reference.aspose.com/slides/net/aspose.slides.export/texttohtmlconversionoptions/textinheritancelimit/)을 설정하여 내보내기가 서식 상속을 얼마나 따라갈지 제어합니다.

[샘플 프레젠테이션](text-inheritance.pptx)을 다운로드하고 애플리케이션 작업 디렉터리에 배치하십시오. 첫 번째 슬라이드에는 텍스트 "Inherited text; explicit red 18pt"가 있는 텍스트 도형이 하나 포함되어 있습니다. 입력은 의도적으로 여러 서식 수준을 사용합니다:

- 프레젠테이션의 기본 텍스트 스타일은 Calibri와 28pt 크기를 제공합니다.
- 텍스트 프레임의 1단계 텍스트 스타일은 파란색 텍스트와 이탤릭을 제공합니다.
- 단락은 굵은 텍스트를 명시적으로 설정합니다.
- 두 번째 구문인 "explicit red 18pt"는 빨간색 텍스트와 18pt 크기를 명시적으로 설정합니다.

다음 완전한 예제는 동일한 단락을 세 번 내보냅니다. [TextToHtmlConversionOptions](https://reference.aspose.com/slides/net/aspose.slides.export/texttohtmlconversionoptions/)을 내보내기 메서드에 전달하고 각 결과를 별도의 UTF-8 HTML 파일로 기록합니다:

```csharp
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("text-inheritance.pptx");
var textShape = (IAutoShape)presentation.Slides[0].Shapes[0];

var paragraphs = textShape.TextFrame.Paragraphs;
var modes = new[] { TextInheritanceLimit.All, TextInheritanceLimit.TextBox, TextInheritanceLimit.ParagraphOnly };

foreach (var mode in modes)
{
    var options = new TextToHtmlConversionOptions { TextInheritanceLimit = mode };

    var html = paragraphs.ExportToHtml(0, paragraphs.Count, options);
    File.WriteAllText($"{mode}.html", html, Encoding.UTF8);
}
```

생성된 HTML에는 첫 번째 구문 "Inherited text; "에 대한 다음 CSS가 포함됩니다. 표에는 관련 선언만 나열되고 다른 생성 속성은 명확성을 위해 생략되었습니다.

| 출력 | 첫 번째 구문의 관련 CSS | 표시 결과 |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Calibri가 사용 가능한 경우 28pt, 파란색, 굵게, 이탤릭 텍스트 |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | 파란색, 굵게, 이탤릭 텍스트; 주변 페이지 또는 브라우저가 글꼴 패밀리와 크기를 제공합니다 |
| `ParagraphOnly.html` | `font-weight:bold` | 굵게 텍스트; 주변 페이지 또는 브라우저가 글꼴 패밀리, 크기, 색상 및 이탤릭 스타일을 제공합니다 |

두 번째 구문은 세 출력 모두에서 `color:#ff0000`, `font-size:18pt`, `font-weight:bold`를 유지합니다. 또한 `All`과 `TextBox`에서는 이탤릭을 유지하지만 `ParagraphOnly`에서는 이탤릭이 제거됩니다. 상속 제한은 단락이나 구문에 명시적으로 지정된 서식을 제거하지 않습니다.

동일한 브라우저에서 파일을 열어 비교하십시오. 제한된 두 모드에서는 누락된 CSS 속성이 대상 페이지의 스타일 또는 브라우저 기본값에 의해 해결되므로 최종 표시 결과는 HTML이 사용되는 위치에 따라 달라집니다.

### **HTML 클립보드 조각 생성**

[AddClipboardFragmentHeader](https://reference.aspose.com/slides/net/aspose.slides.export/texttohtmlconversionoptions/addclipboardfragmentheader/)를 `false`로 설정하면 일반 HTML을, `true`로 설정하면 클립보드 헤더를 포함한 HTML을 반환합니다. 두 호출 모두 문자열을 반환합니다. 헤더는 주변 HTML(`StartHTML` 및 `EndHTML`)과 붙여넣을 내용(`StartFragment` 및 `EndFragment`)의 UTF-8 바이트 오프셋을 제공합니다.

이 예제는 두 개의 서식이 지정된 단락을 일반 HTML(`html`)과 HTML 클립보드 조각(`clipboardHtml`)으로 내보냅니다. 조각을 시스템 클립보드에 쓰는 작업은 별도의 애플리케이션 단계입니다. 원시 HTML 클립보드 바이트를 수용하는 클립보드 API는 BOM 없는 UTF-8을 요구합니다.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 400, 100);
var paragraphs = shape.TextFrame.Paragraphs;
paragraphs.Clear();
paragraphs.AddFromHtml("<p>Status: <b>Ready</b></p><p><i>Next steps</i></p>");

var options = new TextToHtmlConversionOptions { AddClipboardFragmentHeader = false };
var html = paragraphs.ExportToHtml(0, paragraphs.Count, options);

options.AddClipboardFragmentHeader = true;
var clipboardHtml = paragraphs.ExportToHtml(0, paragraphs.Count, options);
```

### **단락을 이미지로 렌더링**

[IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/)는 개별 단락을 직접 렌더링하고 [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/)를 반환합니다. 결과를 [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/)로 파일이나 스트림에 저장하십시오. 포함 도형을 렌더링하거나 비트맵을 수동으로 자를 필요가 없습니다.

[IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/)는 단락이 상위 컬렉션에 없거나 유효한 렌더링 경계가 없거나 렌더링할 수 없는 경우 `null`을 반환할 수 있습니다. 저장하기 전에 결과를 확인하고 사용 후 반환된 이미지를 폐기하십시오.

#### **기본 배율로 단락 렌더링**

예제는 첫 번째 도형이 세 개의 단락을 포함한 텍스트 상자인 프레젠테이션을 사용합니다.

![세 개의 단락이 있는 텍스트 상자](paragraph_to_image_input.png)

다음 예제는 인덱스 1에 있는 두 번째 단락을 선택하고 배율 매개변수 없이 [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/)를 호출합니다. 도형에 필요한 단락이 포함되어 있는지와 렌더링이 이미지를 반환했는지 확인한 뒤 [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/)를 사용해 PNG 형식으로 저장합니다. `using` 선언은 사용 후 이미지를 폐기합니다.

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

![단락 이미지](paragraph_to_image_output.png)

#### **표 셀 내 단락을 배율과 함께 렌더링**

`float scaleX`와 `float scaleY` 매개변수를 받아 가로 및 세로 배율을 설정하는 [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) 오버로드를 사용하십시오. 다음 예제는 표를 만든 뒤 첫 번째 셀의 단락을 기본 너비와 높이의 두 배로 렌더링하고 PNG 이미지로 저장합니다.

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

배율이 `1`이면 해당 축은 기본 픽셀 크기를 유지합니다. 예를 들어 두 배(`2`)를 지정하면 이미지의 너비와 높이가 대략 두 배가 되어 픽셀 수는 네 배가 됩니다. 큰 배율은 확대나 고해상도 출력 시 텍스트를 더 선명하게 만들지만 메모리 사용량과 파일 크기도 증가합니다. `1` 이하의 배율은 상세도가 낮은 작은 이미지를 생성합니다. 비율을 동일하게 유지하면 단락의 가로세로 비율을 보존하고, 가로와 세로 배율을 다르게 설정하면 출력이 독립적으로 늘어나거나 줄어듭니다.

도형 전체를 렌더링하려면 [IShape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/ishape/getimage/)를 사용하면 도형의 채우기, 테두리 또는 기타 시각적 컨텍스트를 포함할 수 있어 유용합니다. 단락 전용 이미지는 [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/)를 사용하십시오.

## **FAQ**

**텍스트 프레임 내부에서 줄 바꿈을 완전히 비활성화할 수 있나요?**

예. [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/)을 설정하면 줄 바꿈이 비활성화되어 텍스트 프레임 가장자리에 줄이 끊기지 않습니다.

**특정 단락의 슬라이드 내 정확한 경계는 어떻게 얻나요?**

[IParagraph.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getrect/)을 사용하면 단락의 경계 사각형을 가져올 수 있습니다. [IPortion.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iportion/getrect/)은 개별 구문의 경계를 제공합니다.

**단락 정렬(왼쪽, 오른쪽, 가운데, 양쪽 맞춤)은 어디서 제어하나요?**

[IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/)은 단락 수준 설정이며 개별 구문 서식과 무관하게 전체 단락에 적용됩니다.

각 줄에 서로 다른 글꼴 크기의 구문을 수직으로 정렬하려면 [Align Fonts Within a Line](/slides/ko/net/text-formatting/#align-fonts-within-a-line)를 참조하십시오.

**단락의 일부에 교정 언어를 설정할 수 있나요?**

예. [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/)을 개별 구문에 설정하면 하나의 단락에 여러 언어의 텍스트를 포함할 수 있습니다.