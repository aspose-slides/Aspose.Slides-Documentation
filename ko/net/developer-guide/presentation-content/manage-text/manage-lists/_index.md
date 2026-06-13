---
title: ".NET에서 프레젠테이션의 글머리표 및 번호 매기기 목록 관리"
linktitle: "목록 관리"
type: docs
weight: 70
url: /ko/net/manage-lists/
keywords:
- "글머리표"
- "글머리표 목록"
- "번호 매기기 목록"
- "기호 글머리표"
- "그림 글머리표"
- "사용자 정의 글머리표"
- "다단계 목록"
- "글머리표 만들기"
- "글머리표 추가"
- "목록 추가"
- "PowerPoint"
- "OpenDocument"
- "프레젠테이션"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET을 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 글머리표, 그림, 다단계 및 번호 매기기 목록을 만들고 서식 지정하는 방법을 배웁니다."
---
## **개요**

Aspose.Slides for .NET을 사용하면 PowerPoint 및 OpenDocument 프레젠테이션에서 글머리표 및 번호 매기기 목록을 만들고 서식 지정할 수 있습니다. 목록 항목은 글머리표 설정이 해당 단락 형식을 통해 제어되는 단락입니다.

단락 수준의 목록 설정에 액세스하려면 [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraph/paragraphformat/) 속성을 사용하십시오. 주요 진입점은 [IParagraphFormat.Bullet](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraphformat/bullet/)이며, 이는 [IBulletFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/ibulletformat/) 객체를 반환합니다. 이 객체를 사용하여 글머리표 유형, 기호, 그림, 색상, 크기, 번호 매기기 스타일 및 시작 번호를 설정할 수 있습니다.

이 문서에서는 다음을 수행하는 방법을 보여줍니다:

- 사용자 지정 기호로 글머리표 목록 만들기
- 그림 글머리표 만들기
- 단락 깊이를 설정하여 다단계 목록 만들기
- 번호 매기기 목록 만들기
- 기존 프레젠테이션에서 목록 서식을 검사하고 변경하기

## **글머리표 목록 만들기**

글머리표 목록을 만들려면 [IParagraph](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraph/) 객체를 [ITextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/)에 추가하고 [IBulletFormat.Type](https://reference.aspose.com/slides/ko/net/aspose.slides/ibulletformat/type/)을 [BulletType.Symbol](https://reference.aspose.com/slides/ko/net/aspose.slides/bullettype/)으로 설정합니다. 그런 다음 [IBulletFormat.Char](https://reference.aspose.com/slides/ko/net/aspose.slides/ibulletformat/char/), [IBulletFormat.Color](https://reference.aspose.com/slides/ko/net/aspose.slides/ibulletformat/color/), 및 [IBulletFormat.Height](https://reference.aspose.com/slides/ko/net/aspose.slides/ibulletformat/height/)를 설정하여 글머리표 모양을 제어할 수 있습니다.

다음 C# 코드는 슬라이드에서 글머리표 목록을 만드는 방법을 보여줍니다:

```csharp
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

![기호 글머리표](symbol_bullets.png)

## **번호 매기기 목록 만들기**

순서가 중요한 경우 번호 매기기 목록을 사용합니다. [IBulletFormat.Type](https://reference.aspose.com/slides/ko/net/aspose.slides/ibulletformat/type/)을 [BulletType.Numbered](https://reference.aspose.com/slides/ko/net/aspose.slides/bullettype/)로 설정합니다. 또한 [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/ko/net/aspose.slides/ibulletformat/numberedbulletstyle/)으로 번호 매기기 형식을 선택하거나, 목록이 1이 아닌 다른 값부터 시작해야 할 경우 [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/ko/net/aspose.slides/ibulletformat/numberedbulletstartwith/)를 설정할 수 있습니다.

다음 C# 코드는 슬라이드에서 번호 매기기 목록을 만드는 방법을 보여줍니다:

```csharp
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

![번호 매기기 글머리표](numbered_bullets.png)

## **그림 글머리표 만들기**

Aspose.Slides를 사용하면 일반 글머리표 기호를 이미지로 교체할 수 있습니다. 그림 글머리표는 아이콘이나 작은 투명 PNG 파일과 같이 작은 크기에서도 읽기 쉬운 단순한 이미지에 가장 적합합니다.

{{% alert color="primary" %}}
이상적으로는 일반 글머리표 기호를 이미지로 교체하려는 경우 투명 배경이 있는 단순한 그래픽을 선택하는 것이 가장 좋습니다. 이러한 이미지는 사용자 정의 글머리표 기호로 잘 활용됩니다.
{{% /alert %}}

그림 글머리표를 만들려면 [Presentation.Images](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/images/)에 이미지를 추가하고 반환된 이미지 객체를 [IBulletFormat.Picture](https://reference.aspose.com/slides/ko/net/aspose.slides/ibulletformat/picture/)에 할당합니다. 이미지를 할당하기 전에 [IBulletFormat.Type](https://reference.aspose.com/slides/ko/net/aspose.slides/ibulletformat/type/)을 [BulletType.Picture](https://reference.aspose.com/slides/ko/net/aspose.slides/bullettype/)으로 설정하십시오.

예를 들어 "image.png" 파일이 있다고 가정해 보겠습니다:

![글머리표용 이미지](picture_for_bullets.png)

다음 C# 코드는 슬라이드에서 그림 글머리표를 만드는 방법을 보여줍니다:

```csharp
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

![그림 글머리표](picture_bullets.png)

## **다단계 목록 만들기**

[IParagraphFormat.Depth](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraphformat/depth/)를 사용하여 목록 항목을 서로 다른 수준에 배치합니다. 레벨 0은 최상위 수준이며, 레벨 1은 그 아래에 중첩되고, 이와 같이 이어집니다.

다음 C# 코드는 다단계 글머리표 목록을 만드는 방법을 보여줍니다:

```csharp
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

![다단계 목록](multilevel_list.png)

## **기존 목록 변경하기**

기존 프레젠테이션에서 목록 서식을 변경하려면 대상 단락에 접근하여 해당 [IParagraphFormat.Bullet](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraphformat/bullet/) 설정을 업데이트합니다. 목록을 만들 때 사용한 동일한 속성을 사용하여 PPT, PPTX 또는 ODP 파일에서 로드된 목록을 검사하거나 수정할 수 있습니다.

```csharp
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

## **FAQ**

**글머리표 및 번호 매기기 목록을 PDF 또는 이미지로 내보낼 수 있나요?**

예. 대상 형식이 해당 텍스트 레이아웃 및 글머리표 기능을 지원하면 Aspose.Slides가 목록 서식을 유지합니다.

**기존 프레젠테이션에서 목록을 편집할 수 있나요?**

예. 프레젠테이션을 로드하고 대상 단락에 접근한 뒤 해당 [IParagraphFormat.Bullet](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraphformat/bullet/) 설정을 검사하거나 업데이트한 다음 프레젠테이션을 저장하면 됩니다.

**목록에 비라틴 문자 텍스트를 포함할 수 있나요?**

예. 목록 항목 텍스트는 유니코드 문자를 포함할 수 있으므로 다국어 프레젠테이션에서도 목록을 만들 수 있습니다. 프레젠테이션에 사용된 글꼴이 필요한 문자를 지원하는지 확인하십시오.