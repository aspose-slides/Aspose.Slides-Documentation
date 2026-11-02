---
title: .NET에서 프레젠테이션의 글머리표 및 번호 매기기 목록 관리
linktitle: 목록 관리
type: docs
weight: 70
url: /ko/net/manage-lists/
aliases:
  - /net/manage-bullet-and-numbered-lists/
keywords:
  - 글머리표
  - 글머리표 목록
  - 번호 매기기 목록
  - 기호 글머리표
  - 그림 글머리표
  - 사용자 정의 글머리표
  - 다중 수준 목록
  - 글머리표 만들기
  - 글머리표 추가
  - 목록 추가
  - PowerPoint
  - OpenDocument
  - 프레젠테이션
  - .NET
  - C#
  - Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 글머리표, 그림, 다중 수준 및 번호 매기기 목록을 만들고 서식화하는 방법을 배웁니다."
---
## **개요**

Aspose.Slides for .NET을 사용하면 PowerPoint 및 OpenDocument 프레젠테이션에서 글머리표 및 번호 매기기 목록을 만들고 서식화할 수 있습니다. 목록 항목은 글머리표 설정이 해당 단락 서식을 통해 제어되는 단락입니다.

단락 수준 목록 설정에 액세스하려면 [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/) 속성을 사용합니다. 주요 진입점은 [IParagraphFormat.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/bullet/)이며, 이는 [IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/) 객체를 반환합니다. 이 객체를 사용하여 글머리표 유형, 기호, 그림, 색상, 크기, 번호 매기기 스타일 및 시작 번호를 설정할 수 있습니다.

이 문서에서는 다음과 같이 수행하는 방법을 보여줍니다:

- 사용자 정의 기호로 글머리표 목록 만들기
- 그림 글머리표 만들기
- 단락 깊이를 설정하여 다중 수준 목록 만들기
- 번호 매기기 목록 만들기
- 기존 프레젠테이션에서 목록 서식을 검사하고 변경하기
- 단락 텍스트와 함께 실제 목록 표시기와 번호 읽기

## **글머리표 목록 만들기**

글머리표 목록을 만들려면 [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) 개체를 [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/)에 추가하고 [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/)을 [BulletType.Symbol](https://reference.aspose.com/slides/net/aspose.slides/bullettype/)으로 설정합니다. 그런 다음 [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/), [IBulletFormat.Color](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/color/), [IBulletFormat.Height](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/height/)를 설정하여 글머리표 모양을 제어할 수 있습니다.

다음 C# 코드는 슬라이드에서 글머리표 목록을 만드는 방법을 보여줍니다:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

static Paragraph CreateParagraph(string text)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    paragraph.ParagraphFormat.Bullet.Char = '*';
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
    paragraph.ParagraphFormat.Bullet.Color.Color = Color.IndianRed;
    paragraph.ParagraphFormat.Bullet.Height = 100;
    paragraph.Text = text;
    return paragraph;
}

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = CreateParagraph("The first paragraph");
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = CreateParagraph("The second paragraph");
textFrame.Paragraphs.Add(paragraph2);

presentation.Save("symbol_bullets.pptx", SaveFormat.Pptx);
```

결과:

![The symbol bullets](symbol_bullets.png)

## **번호 매기기 목록 만들기**

항목 순서가 중요한 경우 번호 매기기 목록을 사용합니다. [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/)을 [BulletType.Numbered](https://reference.aspose.com/slides/net/aspose.slides/bullettype/)으로 설정합니다. 또한 [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstyle/)으로 번호 매기기 형식을 선택하거나 목록이 1이 아닌 값에서 시작해야 할 경우 [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/)를 설정할 수 있습니다.

다음 C# 코드는 슬라이드에서 번호 매기기 목록을 만드는 방법을 보여줍니다:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 90, 80);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = new Paragraph();
paragraph1.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph1.Text = "Apple";
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = new Paragraph();
paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph2.Text = "Orange";
textFrame.Paragraphs.Add(paragraph2);

var paragraph3 = new Paragraph();
paragraph3.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph3.Text = "Banana";
textFrame.Paragraphs.Add(paragraph3);

presentation.Save("numbered_bullets.pptx", SaveFormat.Pptx);
```

결과:

![The numbered bullets](numbered_bullets.png)

## **그림 글머리표 만들기**

Aspose.Slides를 사용하면 일반 글머리표 기호를 이미지로 교체할 수 있습니다. 그림 글머리표는 작은 크기에서도 읽을 수 있는 간단한 이미지(예: 아이콘 또는 작은 투명 PNG 파일)와 가장 잘 작동합니다.

{{% alert color="info" title="Note" %}}
가능하면 일반 글머리표 기호를 이미지로 교체하려는 경우 투명한 배경을 가진 단순한 그래픽을 선택하는 것이 가장 좋습니다. 이러한 이미지는 사용자 정의 글머리표 기호로 잘 활용됩니다.

이미지는 매우 작은 크기로 축소됩니다. 따라서 목록에서 글머리표로 사용할 때도 선명하고 시각적으로 효과적인 이미지를 선택할 것을 강력히 권장합니다.
{{% /alert %}}

그림 글머리표를 만들려면 [Presentation.Images](https://reference.aspose.com/slides/net/aspose.slides/presentation/images/)에 이미지를 추가하고 반환된 이미지 객체를 [IBulletFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/picture/)에 할당합니다. 이미지를 할당하기 전에 [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/)을 [BulletType.Picture](https://reference.aspose.com/slides/net/aspose.slides/bullettype/)으로 설정하십시오.

예를 들어 "image.png"가 있다고 가정해 보겠습니다:

![A picture for the bullets](picture_for_bullets.png)

다음 C# 코드는 슬라이드에서 그림 글머리표를 만드는 방법을 보여줍니다:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

static Paragraph CreateParagraph(string text, IPPImage image)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
    paragraph.ParagraphFormat.Bullet.Picture.Image = image;
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.Bullet.Height = 100;
    paragraph.Text = text;
    return paragraph;
}

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var imageBytes = File.ReadAllBytes("image.png");
var bulletImage = presentation.Images.AddImage(imageBytes);

var paragraph1 = CreateParagraph("The first paragraph", bulletImage);
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = CreateParagraph("The second paragraph", bulletImage);
textFrame.Paragraphs.Add(paragraph2);

presentation.Save("picture_bullets.pptx", SaveFormat.Pptx);
```

결과:

![The picture bullets](picture_bullets.png)

## **다중 수준 목록 만들기**

[IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/)를 사용하여 목록 항목을 서로 다른 수준에 배치합니다. 레벨 0은 최상위 수준이며, 레벨 1은 그 아래에 중첩됩니다.

다음 C# 코드는 다중 수준 글머리표 목록을 만드는 방법을 보여줍니다:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 260, 110);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = new Paragraph();
paragraph1.ParagraphFormat.Depth = 0;
paragraph1.Text = "My text - Depth 0";
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = new Paragraph();
paragraph2.ParagraphFormat.Depth = 1;
paragraph2.Text = "My text - Depth 1";
textFrame.Paragraphs.Add(paragraph2);

var paragraph3 = new Paragraph();
paragraph3.ParagraphFormat.Depth = 2;
paragraph3.Text = "My text - Depth 2";
textFrame.Paragraphs.Add(paragraph3);

var paragraph4 = new Paragraph();
paragraph4.ParagraphFormat.Depth = 3;
paragraph4.Text = "My text - Depth 3";
textFrame.Paragraphs.Add(paragraph4);

presentation.Save("multilevel_bullets.pptx", SaveFormat.Pptx);
```

결과:

![The multilevel list](multilevel_list.png)

## **기존 목록 변경**

기존 프레젠테이션에서 목록 서식을 변경하려면 대상 단락에 액세스하고 해당 [IParagraphFormat.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/bullet/) 설정을 업데이트합니다. 목록을 만들 때 사용한 동일한 속성을 사용하여 PPT, PPTX 또는 ODP 파일에서 로드된 목록을 검사하거나 수정할 수 있습니다.

다음 C# 코드는 텍스트 프레임의 첫 번째 단락을 번호 매기기 목록 스타일로 변경합니다:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];
var autoShape = (IAutoShape)slide.Shapes[0];

var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletRomanUCPeriod;
paragraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 1;
paragraph.ParagraphFormat.MarginLeft = 30;
paragraph.ParagraphFormat.Indent = -20;

presentation.Save("updated_list.pptx", SaveFormat.Pptx);
```

## **실제 글머리표 값 읽기**

프레젠테이션 콘텐츠를 추출할 때 목록 표시기를 단락 텍스트와 함께 유지합니다. [IParagraphFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/geteffective/)를 호출하고 [IParagraphFormatEffectiveData.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformateffectivedata/bullet/)에 액세스하여 실제 글머리표 서식을 가져옵니다. 읽기 전에 해당 [Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/type/)을 확인하고 [ActualBulletValue](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/actualbulletvalue/)를 읽습니다.

번호 매기기 목록의 경우 다음 세 값을 구별합니다:

- [NumberedBulletStyle](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/numberedbulletstyle/)은 형식을 결정합니다(예: 마침표가 뒤따르는 아라비아 숫자 또는 소문자 알파벳).
- [NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/numberedbulletstartwith/)는 번호 매기기 단락 그룹의 시작 번호를 지정합니다.
- [ActualBulletValue](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/actualbulletvalue/)는 특정 단락에 대한 형식화된 표시기를 반환합니다. 예를 들어 5부터 시작하는 목록의 두 번째 항목은 `6.`을 반환합니다.

각 단락에 [Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/)를 보존하여 중첩 수준을 유지합니다. 실제 표시기는 전체 계층 구조를 인코딩하지 않습니다. 중첩된 항목은 `c.`와 같이 반환될 수 있으며 `6.c.`와 같은 결합 레이블은 아닙니다.

다음 자체 포함 예제는 목록을 생성하고 프레젠테이션에 저장한 뒤 프레젠테이션을 다시 로드하여 각 단락의 텍스트, 깊이, 글머리표 유형 및 실제 값을 보고합니다. 작은 파란색 그림 표시기는 인라인 SVG에서 생성됩니다.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation())
{
    presentation.SlideSize.SetSize(720, 440, SlideSizeScaleType.DoNotScale);
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 20, 660, 400);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;

    var textFrame = shape.TextFrame;
    textFrame.Paragraphs.Clear();

    // 외부 이미지 파일 없이 그림 표시기를 생성합니다.
    var svg = new SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>");
    var bulletImage = presentation.Images.AddImage(svg);

    void AddParagraph(string text, short depth, BulletType type, short start = 1, NumberedBulletStyle style = NumberedBulletStyle.BulletArabicPeriod)
    {
        var paragraph = new Paragraph { Text = text };

        var format = paragraph.ParagraphFormat;
        format.Depth = depth;
        format.MarginLeft = 30 + depth * 40;
        format.Indent = -28;
        format.SpaceAfter = 8;
        format.DefaultPortionFormat.FontHeight = 22;
        format.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
        format.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
        format.Bullet.Type = type;
        format.Bullet.IsBulletHardColor = NullableBool.True;
        format.Bullet.Color.Color = Color.Black;
        if (type == BulletType.Numbered)
        {
            format.Bullet.NumberedBulletStyle = style;
            format.Bullet.NumberedBulletStartWith = start;
        }
        else if (type == BulletType.Symbol)
        {
            format.Bullet.Char = '\u2022';
        }
        else if (type == BulletType.Picture)
        {
            format.Bullet.Picture.Image = bulletImage;
        }

        textFrame.Paragraphs.Add(paragraph);
    }

    AddParagraph("First item", 0, BulletType.Numbered, 5);
    AddParagraph("Second item", 0, BulletType.Numbered, 5);
    AddParagraph("Nested item", 1, BulletType.Numbered, 3, NumberedBulletStyle.BulletAlphaLCPeriod);
    AddParagraph("Next nested item", 1, BulletType.Numbered, 3, NumberedBulletStyle.BulletAlphaLCPeriod);
    AddParagraph("Deep item", 2, BulletType.Numbered, 4, NumberedBulletStyle.BulletRomanLCPeriod);
    AddParagraph("Back to top level", 0, BulletType.Numbered, 5);
    AddParagraph("Symbol marker", 0, BulletType.Symbol);
    AddParagraph("No bullet", 0, BulletType.None);
    AddParagraph("Picture marker", 0, BulletType.Picture);
    presentation.Save("actual_bullet_values.pptx", SaveFormat.Pptx);
}

using var loadedPresentation = new Presentation("actual_bullet_values.pptx");
var loadedShape = (IAutoShape)loadedPresentation.Slides[0].Shapes[0];
Console.WriteLine("Text | Depth | Type | Actual value");
foreach (var paragraph in loadedShape.TextFrame.Paragraphs)
{
    var bullet = paragraph.ParagraphFormat.GetEffective().Bullet;
    string marker;
    switch (bullet.Type)
    {
        case BulletType.Numbered:
        case BulletType.Symbol:
            marker = bullet.ActualBulletValue;
            break;
        case BulletType.None:
            marker = $"{bullet.ActualBulletValue ?? "null"} (no bullet)";
            break;
        case BulletType.Picture:
            marker = $"{bullet.ActualBulletValue ?? "null"} (image required)";
            break;
        default:
            marker = "unsupported bullet type";
            break;
    }
    Console.WriteLine($"{paragraph.Text} | {paragraph.ParagraphFormat.Depth} | {bullet.Type} | {marker}");
}
```

소스 목록은 아래에 표시됩니다.

![Lists starting at 5, nested letter and Roman-number items, a symbol marker, a paragraph without a bullet, and a blue picture marker](actual_bullet_values.png)

보고서는 PowerPoint에 표시된 표시기와 일치합니다:

```text
Text | Depth | Type | Actual value
First item | 0 | Numbered | 5.
Second item | 0 | Numbered | 6.
Nested item | 1 | Numbered | c.
Next nested item | 1 | Numbered | d.
Deep item | 2 | Numbered | iv.
Back to top level | 0 | Numbered | 7.
Symbol marker | 0 | Symbol | •
No bullet | 0 | None | null (no bullet)
Picture marker | 0 | Picture | null (image required)
```

[BulletType.None and BulletType.Picture](https://reference.aspose.com/slides/net/aspose.slides/bullettype/)의 경우, [ActualBulletValue](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/actualbulletvalue/)는 `null`을 반환하며 빈 문자열이 아닙니다. 이러한 유형은 별도로 처리해야 합니다: 전자는 표시기가 없고 후자는 글머리표 이미지를 별도로 추출해야 합니다. 그림 글머리표는 텍스트 표시기만 추출해도 재현할 수 없습니다.

## **자주 묻는 질문**

**글머리표 및 번호 매기기 목록을 PDF 또는 이미지로 내보낼 수 있나요?**

예. Aspose.Slides는 대상 형식이 해당 텍스트 레이아웃 및 글머리표 기능을 지원하는 경우 목록 서식을 유지합니다.

**기존 프레젠테이션에서 목록을 편집할 수 있나요?**

예. 프레젠테이션을 로드하고 대상 단락에 액세스한 뒤 [IParagraphFormat.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/bullet/) 설정을 검사하거나 업데이트하고 프레젠테이션을 저장하면 됩니다.

**목록에 비라틴 문자도 포함될 수 있나요?**

예. 목록 항목 텍스트는 Unicode 문자를 포함할 수 있으므로 다국어 프레젠테이션에서 목록을 만들 수 있습니다. 프레젠테이션에 사용되는 글꼴이 필요한 문자를 지원하는지 확인하십시오.